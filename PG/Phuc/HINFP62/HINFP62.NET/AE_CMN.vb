Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module AE_CMN
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　共通
	'*  モジュール名　　：　業務共通処理
	'*  作成者　　　　　：　ACE)長澤
	'*  作成日　　　　　：  2006.05.24
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	
	'************************************************************************************
	'   構造体
	'************************************************************************************
	Public Structure Cmn_Inp_Inf
		Dim InpTanCd As String '入力担当者ＩＤ
		Dim InpTanNm As String '入力担当者名
		Dim InpTKCHGKB As String '単価変更権限
		Dim InpCLIID As String 'クライアントＩＤ
		' === 20060828 === INSERT S - ACE)Sejima
		Dim InpJDNUPDKB As String '受注更新権限
		' === 20060828 === INSERT E
		' === 20061030 === INSERT S - ACE)Nagasawa 権限の読み方の変更
		Dim InpPRTAUTH As String '印刷権限
		Dim InpFILEAUTH As String 'ファイル出力権限
		' === 20061030 === INSERT E -
	End Structure
	
	' === 20061014 === INSERT S - ACE)Nagasawa 受注訂正時の項目の入力可否制御の変更
	Public Structure Cmn_JDNUPDATE_Enable
		Dim bolJHD As Boolean 'セットアップ発注
		Dim bolFRD As Boolean '出荷指示
		' === 20070715 === INSERT S - ACE)Nagasawa 出荷指示中でも出荷指示されていない明細は訂正可とする
		Dim bolFRD_TAN As Boolean '出荷指示(単品)
		Dim bolSSZ_TAN As Boolean '出荷指図（単品）
		' === 20070715 === INSERT E -
		' === 20061123 === INSERT S - ACE)Nagasawa メーカーコードには出荷指図数を編集
		Dim bolSSZ As Boolean '出荷指図
		' === 20061123 === INSERT E -
		Dim bolODN As Boolean '出荷実績
		' === 20061127 === INSERT S - ACE)Nagasawa 海外倉庫からの出荷実績考慮追加
		Dim bolFRNMOV As Boolean '海外倉庫移動
		' === 20061127 === INSERT E -
		Dim bolURI As Boolean '売上
		Dim bolSSA As Boolean '請求
		Dim bolNYU As Boolean '入金
		Dim bolJDN_End As Boolean '受注完了
	End Structure
	' === 20061014 === INSERT E -
	
	' === 20061217 === INSERT S - ACE)Nagasawa 引当内訳ファイルの更新を行う
	'引当内訳ファイル更新情報
	Public Structure Cmn_DTLTRA_Upd
		Dim Moto_TRANO As String '更新前トラン番号
		Dim MOTO_MITNOV As String '更新前版数
		Dim Moto_LINNO As String '更新前行番号
		Dim TRANO As String 'トラン番号
		Dim MITNOV As String '版数
		Dim LINNO As String '行番号
		Dim TRADT As String '出荷予定日
	End Structure
	' === 20061217 === INSERT E -
	
	' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
	'売上トラン請求書区分更新用
	Public Structure Cmn_JDNTRA_UDNUpdate
		Dim JDNNO As String '受注番号
		Dim LINNO As String '行番号
		Dim RECNO As String 'レコード管理番号
		Dim SBNNO As String '製番
		Dim MRPKB As String '請求書出力区分
	End Structure
	' === 20071213 === INSERT E -
	
	' === 20070307 === INSERT S - ACE)Nagasawa
	'売上見出しトラン更新内容
	Public Structure Cmn_UDNTHA_Upd
		Dim DATNO() As String '伝票管理番号（更新対象）
		Dim DATNO_KRO() As String '伝票管理番号（新/黒伝票用）
		Dim DATNO_AKA() As String '伝票管理番号（新/赤伝票用）
		Dim ODNNO() As String '出荷伝票番号（返品有りの場合のみ採番）
		Dim ODNNO_GetSu As Decimal '出荷伝票番号採番数
		Dim UDNNO_KRO() As String '売上伝票番号（新/黒伝票用）
		Dim UDNNO_AKA() As String '売上伝票番号（新/赤伝票用）
		' === 20070331 === INSERT S - ACE)Nagasawa 売上訂正返品対応
		Dim FDNNO_KRO() As String '納品書番号（新/黒伝票用）
		Dim FDNNO_AKA() As String '納品書番号（新/赤伝票用）
		' === 20070331 === INSERT E -
		Dim UDNNO_GetSu As Decimal '出荷伝票番号採番数
		Dim JDNNO As String '受注番号
		Dim FDNNO() As String '納品書番号
		Dim TOKCD As String '得意先コード
		Dim TOKSEICD As String '請求先コード
		Dim UDNDT As String '売上伝票日付（受注訂正日)
		Dim JDNTRKB As String '受注取引区分
		Dim URIKJN As String '売上基準
		Dim TANCD As String '営業担当者コード
		Dim TANNM As String '営業担当者名
		Dim BUMCD As String '営業部門コード
		Dim BUMNM As String '営業部門名
		Dim CLMDL As String '分類型式
		Dim SMADT As String '経理締日付
		Dim SSADT() As String '締日付
		Dim KESDT() As String '決算日付
		Dim SSADT_Chk As String '最大締日付（受注訂正日制御用）
		Dim UDNDENDT_Chk As String '最大売上日付（受注訂正日制御用）
		Dim SMADT_Chk As String '最大経理締日付（受注訂正日制御用）
		Dim MAEUKKB As String '前受区分
		Dim FRNKB As String '海外取引区分
		Dim TUKKB As String '通貨区分
		Dim SSAKBN As String '決算日付計算区分
		Dim TOKZEIKB As String '消費税区分（得意先）
		Dim TOKRPSKB As String '消費税端数処理桁数
		Dim TOKZRNKB As String '消費税端数処理区分
		Dim curUrikn_Old() As Decimal '更新前売上金額    （伝票計）
		Dim curFUrikn_Old() As Decimal '更新前外貨売上金額（伝票計）
		Dim curUzeikn_Old() As Decimal '更新前消費税合計  （伝票計）
		Dim curUrikn_New() As Decimal '更新後売上金額    （伝票計）
		Dim curFUrikn_New() As Decimal '更新後外貨売上金額（伝票計）
		Dim curUzeikn_New() As Decimal '更新後消費税合計  （伝票計）
		Dim curSUrikn_Old As Decimal '更新前売上金額    （総合計）
		Dim curSFUrikn_Old As Decimal '更新前外貨売上金額（総合計）
		Dim curSUzeikn_Old As Decimal '更新前消費税合計　（総合計）
		Dim curSUrikn_New As Decimal '更新後売上金額    （総合計）
		Dim curSFUrikn_New As Decimal '更新後外貨売上金額（総合計）
		Dim curSUzeikn_New As Decimal '更新後消費税合計  （総合計）
		Dim bolAKAKRO() As Boolean '赤黒作成フラグ
		Dim bolUpd As Boolean '更新フラグ(True　: 更新）
		Dim strErr As String 'エラー箇所
		' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
		Dim usrBodyInf() As Cmn_JDNTRA_UDNUpdate '明細情報
		' === 20071213 === INSERT E -
	End Structure
	
	'売上トラン更新内容
	Public Structure Cmn_UDNTRA_Upd
		Dim JDNNO As String '受注番号
		Dim LINNO As String '行番号
		Dim URILINNO As String '行番号(売上トラン）
		Dim RECNO As String 'レコード管理番号
		Dim SBNNO As String '製番
		Dim HINCD As String '製品コード
		Dim TOKJDNNO As String '客先注文番号
		Dim BIKO As String '備考
		Dim URISU As Decimal '売上数量
		Dim URITK As Decimal '単価
		Dim FURITK As Decimal '外貨単価
		Dim SIKTK As String '仕切単価
		Dim URIKN As Decimal '売上金額
		Dim FURIKN As Decimal '外貨売上金額
		Dim SIKKN As Decimal '仕切金額
		Dim UZEKN As Decimal '消費税額
		Dim HNURIKN As Decimal '返品分売上金額
		Dim HNFURIKN As Decimal '返品分外貨売上税額
		Dim HNUZEKN As Decimal '返品分消費税額
		Dim HINZEIKB As String '商品消費税区分
		Dim ZEIRT As String '税率
		Dim bolHNPN As Boolean '返品フラグ（True : 返品有り）
		Dim bolUpd As Boolean '更新フラグ（True : 更新）
		Dim Bd_Index As Short '受注訂正画面の該当行
		' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
		Dim MRPKB As String '請求書出力区分
		' === 20071213 === INSERT E -
	End Structure
	' === 20070307 === INSERT E -
	'************************************************************************************
	'   Public定数
	'************************************************************************************
	'端数計算桁数
	Public Const gc_strRPSKB_D1 As String = "1" '小数第一位
	Public Const gc_strRPSKB_D2 As String = "2" '小数第二位
	Public Const gc_strRPSKB_D3 As String = "3" '小数第三位
	Public Const gc_strRPSKB_D4 As String = "4" '小数第四位
	Public Const gc_strRPSKB_D5 As String = "5" '小数第五位
	Public Const gc_strRPSKB_I1 As String = "10" '１
	Public Const gc_strRPSKB_I2 As String = "11" '１０
	Public Const gc_strRPSKB_I3 As String = "12" '１００
	
	' === 20070908 === INSERT S - ACE)Nagasawa 受注番号"RA000T"と"RA001T"は行追加行わないように修正(受注番号採番ミス)
	Public Const gc_strJDNNO_RA000T As String = "RA000T"
	Public Const gc_strJDNNO_RA001T As String = "RA001T"
	' === 20070908 === INSERT E -
	'************************************************************************************
	'   Public変数
	'************************************************************************************
	Public Inp_Inf As Cmn_Inp_Inf '入力者情報
	Public GV_SysDate As String 'ＤＢサーバー日付
	Public GV_SysTime As String 'ＤＢサーバー時刻
	Public GV_UNYDate As String '運用日付
	' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
	Public GV_bolMsgFlg As Boolean 'メッセージ出力フラグ
	' === 20060920 === INSERT E
	' === 20140129 === INSERT S - 両備)Shikichi
	Public NonRaisedMsg As Boolean 'メッセージボックスを上げるかどうかのフラグ(False時は、メッセージボックスの代わりに、EVTTBLテーブルに書き込む)
	' === 20140129 === INSERT E - 両備)Shikichi
	' === 20140211 === INSERT S - 両備)Shikichi
	Public EvJdnno As String 'イベント書き込み用受注番号
	' === 20140211 === INSERT E - 両備)Shikichi
	
	'************************************************************************************
	'   Private定数
	'************************************************************************************
	' === 20060828 === INSERT S - ACE)Sejima
	'権限グループ判定用
	Private Const mc_intCD As Short = 1 '権限グループ設定あり
	Private Const mc_intOLDCD As Short = 2 '旧権限グループ設定あり
	Private Const mc_intTKDT As Short = 4 '適用日設定あり
	' === 20060828 === INSERT E
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	Dim strINIDATNM(4) As String 'ＩＮＩのシンボル
	
	' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
	'************************************************************************************
	'   キーバッファクリア用API
	'************************************************************************************
	Private Structure POINTAPI
		Dim X As Integer
		Dim Y As Integer
	End Structure
	Private Structure Msg
		Dim hwnd As Integer
		Dim message As Integer
		Dim wParam As Integer
		Dim lParam As Integer
		Dim time As Integer
		Dim pt As POINTAPI
	End Structure
	'UPGRADE_WARNING: 構造体 Msg に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	Private Declare Function PeekMessage Lib "user32"  Alias "PeekMessageA"(ByRef lpMsg As Msg, ByVal hwnd As Integer, ByVal wMsgFilterMin As Integer, ByVal wMsgFilterMax As Integer, ByVal wRemoveMsg As Integer) As Integer
	Private Const WM_KEYFIRST As Short = &H100s
	Private Const WM_KEYLAST As Short = &H108s
	Private Const PM_REMOVE As Short = &H1s
	' === 20060920 === INSERT E
	
	'''' ADD 2009/03/04  FKS) S.Nakajima    Start
	Public Const gc_strMsgEIGYOSHO_E_001 As String = "2EIGYOSHO_01" '対象の営業所が廃止されています。
	'''' ADD 2009/03/04  FKS) S.Nakajima    End
	
	
	' === 20140129 === INSERT S - 両備)Shikichi
	'イベントログ作成パラメータ
	Structure M_TYPE_EVTTBL_PARA
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public IVWRDT() As Char 'イベント発生日
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public IVWRTM() As Char 'イベント開始時間
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public PGID() As Char 'プログラムＩＤ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public IVCLASS() As Char 'イベント種別
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public IVCODE() As Char 'イベントコード
		Dim IVMSG As String 'イベント内容
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public IVPOINT() As Char 'イベント発生箇所
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SNDPROFLG() As Char '送信可否フラグ
	End Structure
	' === 20140129 === INSERT E - 両備)Shikichi
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Init
	'   概要：  プログラム起動時初期処理
	'   引数：  なし
	'   戻値：  なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub CF_Init()
		
		Dim datDT As Date
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim DB_UNYMTA As TYPE_DB_UNYMTA
		Dim strYMD As String
		Dim intLenCommand As String
		Dim intRet As Short
		'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
		Dim strRet As String
		'''' ADD 2009/11/26  FKS) T.Yamamoto    End
		
		'二重起動ﾁｪｯｸ
		'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
		If App.PrevInstance Then
			MsgBox("【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		End If
		
		' "しばらくお待ちください" ウィンドウ表示
		'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
		Load(ICN_ICON)
		
		'   日付形式チェック
		datDT = Today
		strYMD = VB6.Format(Year(datDT), "0000") & "/" & VB6.Format(Month(datDT), "00") & "/" & VB6.Format(VB.Day(datDT), "00")
		
		If CStr(datDT) <> strYMD Then
			MsgBox("日付の形式 '" & CStr(datDT) & "' が違います。" & vbCrLf & "コントロールパネルの地域（地球の絵）の日付" & vbCrLf & "の短い形式を yyyy/MM/dd に変更して下さい。", MsgBoxStyle.Critical)
			Call Error_Exit("日付の形式が違います。")
		End If
		
		'---------------------
		' 起動パラメータ設定
		'---------------------
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intLenCommand = LenWid(Trim(VB.Command()))
		If CDbl(intLenCommand) < 15 Then
			MsgBox("メニューから実行してください。", MsgBoxStyle.OKOnly, SSS_PrgNm)
			Call Error_Exit("メニューから実行してください。")
		End If
		
		SSS_CLTID.Value = MidWid(VB.Command(), 2, 5)
		SSS_OPEID.Value = MidWid(VB.Command(), 7, 8)
		
		'リードオンリーモード設定
		If Left(VB.Command(), 1) = "'" Then SSS_ReadOnly = True
		
		' === 20060828 === INSERT S - ACE)Sejima 単価変更権限取得に必要なため、下から移動
		'運用日付取得
		Call CF_Get_UnyDt()
		' === 20060828 === INSERT E
		
		'入力担当者名取得
		Inp_Inf.InpTanCd = SSS_OPEID.Value
		Inp_Inf.InpCLIID = SSS_CLTID.Value
		
		'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
		'入力担当者情報設定
		gs_userid = SSS_OPEID.Value
		gs_pgid = SSS_PrgId
		
		'権限取得
		strRet = Get_Authority(GV_UNYDate)
		If strRet = "9" Then
			'起動権限なしの場合、処理終了
			Call AE_CmnMsgLibrary_2(SSS_PrgNm, "2RUNAUTH")
			End
		End If
		'''' ADD 2009/11/26  FKS) T.Yamamoto    End
		
		' === 20060830 === UPDATE S - ACE)Nagasawa 権限の考慮の修正
		'    Call DB_TANMTA_Clear(DB_TANMTA)
		'    intRet = DSPTANCD_SEARCH(Inp_Inf.InpTanCd, DB_TANMTA)
		'    If intRet = 0 Then
		'        Inp_Inf.InpTanNm = DB_TANMTA.TANNM              '入力担当者名
		'' === 20060828 === UPDATE S - ACE)Sejima
		''D        Inp_Inf.InpTKCHGKB = DB_TANMTA.TKCHGKB          '単価変更権限
		'' === 20060828 === UPDATE ↓
		'        '権限情報取得（単価変更権限、受注更新権限、etc...）
		'        Call F_Get_KNG_Inf(DB_TANMTA, GV_UNYDate, Inp_Inf)
		'' === 20060828 === UPDATE E
		'    End If
		
		'入力担当者情報取得
		Call F_Get_INPTANCD_Inf(Inp_Inf.InpTanCd, Inp_Inf)
		' === 20060830 === UPDATE E -
		
		'---------------------
		' SSSWIN.INI テーブル設定
		'---------------------
		strINIDATNM(0) = "USR_PATH"
		strINIDATNM(1) = "DAT_PATH"
		strINIDATNM(2) = "PRG_PATH"
		strINIDATNM(3) = "WRK_PATH"
		strINIDATNM(4) = "IMG_PATH"
		SSS_INICnt = 4
		'Iniファイル読込み
		Call CF_INIT_GETINI()
		
		' === 20060828 === DELETE S - ACE)Sejima 単価変更権限取得に必要なため、上に移動
		'D    '運用日付取得
		'D    Call CF_Get_UnyDt
		' === 20060828 === DELETE E
		
		' === 20061102 === INSERT S - ACE)Yano ﾛｸﾞﾌｧｲﾙ書込み（プログラム起動）
		Call SSSWIN_LOGWRT("プログラム起動")
		' === 20061102 === INSERT E
		
		' "しばらくお待ちください" ウィンドウ消去
		ICN_ICON.Close()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_INIT_GETINI
	'   概要：  INIファイル読込み（共通）
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub CF_INIT_GETINI()
		Dim WL_WinDir As String
		Dim I, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		'---------------------
		' SSSWIN.INI 読込み
		'---------------------
		For I = 0 To SSS_INICnt
			rtnPara.Value = ""
			LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(I), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
			If LENGTH = 0 Then
				MsgBox("SSSWIN.INI を確認してください。" & Chr(13) & "[" & strINIDATNM(I) & "]")
				Call Error_Exit("SSSUSR.INI を確認してください。[" & strINIDATNM(I) & "]")
			Else
				SSS_INIDAT(I) = LeftWid(rtnPara.Value, LENGTH)
			End If
			If Right(SSS_INIDAT(I), 1) <> "\" And Right(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
		Next I
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_DspLineNo
	'   概要：  表示用行番号取得
	'   引数：　pm_Def_LineNo
	'           pm_HIKET51_DSP_DATA    :画面業務情報構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_DspLineNo(ByRef pm_Def_LineNo As String, ByRef pm_JdnTrKb As String) As String
		
		Dim Ret_Value As String
		
		Select Case pm_JdnTrKb
			Case gc_strJDNTRKB_SET
				'セットアップは頭２桁
				Ret_Value = Mid(pm_Def_LineNo, 1, 2)
				
			Case Else
				'以外は後２桁
				Ret_Value = Mid(pm_Def_LineNo, 2, 2)
				
		End Select
		
		F_Get_DspLineNo = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_TANNM
	'   概要：  担当者名称取得
	'   引数：　pm_Def_LineNo
	'           pm_HIKET51_DSP_DATA    :画面業務情報構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANNM(ByRef pm_TANCD As String) As String
		
		Dim Ret_Value As String
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim intRet As Short
		
		Ret_Value = ""
		
		'担当者マスタ検索
		Call DB_TANMTA_Clear(DB_TANMTA)
		intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
		If intRet = 0 Then
			Ret_Value = DB_TANMTA.TANNM
		End If
		
		CF_Get_TANNM = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Frm_Location
	'   概要：  初期表示位置設定
	'   引数：　pm_Form        :フォーム
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Frm_Location(ByRef pm_Form As System.Windows.Forms.Form) As Short
		
		With pm_Form
			.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(.Width)) / 2)
			.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(.Height)) / 2)
		End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Frm_IN_TANCD
	'   概要：  入力担当者編集
	'   引数：　pm_Form        :フォーム
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As System.Windows.Forms.Form, ByRef pm_All As Cls_All) As Short
		
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
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_SYSTBASaiban
	'   概要：  伝票管理NO採番処理
	'   引数：　Pm_strDATNO()  :伝票管理No
	'           Pm_strRECNO()  :レコード管理No
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBASaiban(ByRef pot_strDatNo() As String, ByRef pot_strRECNO() As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDatNo As Decimal
		Static curRecNo As Decimal
		Static intCnt As Short
		Static strDATNO As String
		Static strRecNo As String
		
		On Error GoTo ERR_AE_SYSTBASaiban
		
		AE_SYSTBASaiban = 9
		
		bolTran = False
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'ユーザー情報管理テーブル取得
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBA        "
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    strSQL = strSQL & "    for Update NoWait "
		strSQL = strSQL & "    for Update  "
		' === 20061108 === UPDATE E -
		
		'SQL実行
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		' === 20061108 === UPDATE E -
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'EOF判定
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBASaiban = 1
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'伝票管理No取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curDatNo = CDec(CF_Ora_GetDyn(usrOdy, "DATNO", "0")) + 1
		If curDatNo > 9999999999# Then
			'9999999999を超えた場合は戻る
			curDatNo = 1
		End If
		For intCnt = 1 To UBound(pot_strDatNo)
			pot_strDatNo(intCnt) = VB6.Format(CStr(curDatNo), "0000000000")
			curDatNo = curDatNo + 1
			If curDatNo > 9999999999# Then
				'9999999999を超えた場合は戻る
				curDatNo = 1
			End If
		Next intCnt
		
		'レコード管理No取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curRecNo = CDec(CF_Ora_GetDyn(usrOdy, "RECNO", "0")) + 1
		If curRecNo > 9999999999# Then
			'9999999999を超えた場合は戻る
			curRecNo = 1
		End If
		
		For intCnt = 1 To UBound(pot_strRECNO)
			pot_strRECNO(intCnt) = VB6.Format(CStr(curRecNo), "0000000000")
			curRecNo = curRecNo + 1
			If curRecNo > 9999999999# Then
				'9999999999を超えた場合は戻る
				curRecNo = 1
			End If
		Next intCnt
		
		'ユーザー情報管理テーブル更新
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    usrOdy.Obj_Ody.Edit
		'    usrOdy.Obj_Ody.Fields("DATNO").Value = pot_strDatNo(UBound(pot_strDatNo))
		'    If UBound(Pot_strRECNO) > 0 Then
		'        usrOdy.Obj_Ody.Fields("RECNO").Value = Pot_strRECNO(UBound(Pot_strRECNO))
		'    End If
		'    If Trim(GV_SysTime) <> "" Then
		'        usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
		'    End If
		'    If Trim(GV_SysDate) <> "" Then
		'        usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
		'    End If
		'    usrOdy.Obj_Ody.Update
		
		If Trim(pot_strDatNo(UBound(pot_strDatNo))) = "" Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strDATNO = CF_Ora_GetDyn(usrOdy, "DATNO", "")
		Else
			strDATNO = pot_strDatNo(UBound(pot_strDatNo))
		End If
		
		If Trim(pot_strRECNO(UBound(pot_strRECNO))) = "" Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strRecNo = CF_Ora_GetDyn(usrOdy, "RECNO", "")
		Else
			strRecNo = pot_strRECNO(UBound(pot_strRECNO))
		End If
		
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBA "
		strSQL = strSQL & "    SET DATNO = '" & strDATNO & "' "
		strSQL = strSQL & "      , RECNO = '" & strRecNo & "' "
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		' === 20061108 === UPDATE E -
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBASaiban = 0
		
EXIT_AE_SYSTBASaiban: 
		Exit Function
		
ERR_AE_SYSTBASaiban: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 2049 Then
			' === 20061108 === UPDATE E -
			'他で使用中
			AE_SYSTBASaiban = 2
		End If
		
		If bolTran = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBASaiban
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_SYSTBCSaiban
	'   概要：  伝票NO採番処理
	'   引数：　Pin_strDKBSB     :採番対象の伝票取引区分種別
	'           Pot_strDENNO     :取得された伝票№
	'           Pin_strADDDENCD  :見積番号の採番の場合、処理年月(数字６桁）
	'           Pin_strKbn       :受注番号の場合取引区分
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'2017/03/02 CHG START CIS <課金システム対応>
	'Public Static Function AE_SYSTBCSaiban(ByVal Pin_strDKBSB As String, _
	''                                       ByRef Pot_strDENNO As String, _
	''                                       Optional ByVal Pin_strADDDENCD As String, _
	''                                       Optional ByVal Pin_strKbn As String) As Integer
	Public Function AE_SYSTBCSaiban(ByVal Pin_strDKBSB As String, ByRef Pot_strDENNO As String, Optional ByVal Pin_strADDDENCD As String = "", Optional ByVal Pin_strKbn As String = "", Optional ByVal Pin_bolService As Boolean = False) As Short
		'2017/03/02 CHG E N D CIS <課金システム対応>
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static strDenNo As String
		Static intCnt As Short
		Static strRtn As String
		Static strFixCd As String
		' === 20060814 === INSERT S - ACE)Nagasawa
		Static intRet As Short
		' === 20060814 === INSERT E -
		' === 20061119 === INSERT S - ACE)Nagasawa
		Static strDate As String
		Static strTime As String
		' === 20061119 === INSERT E -
		' === 20070909 === INSERT S - ACE)Nagasawa 受注番号が既に受注見出しトランに存在する場合はとばす("RA000T"と"RA001T"は使用不可)
		Static bolJDNNO_OK As Boolean
		'UPGRADE_WARNING: 構造体 usrOdy_JDN の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy_JDN As U_Ody
		' === 20070909 === INSERT E -
		
		On Error GoTo ERR_AE_SYSTBCSaiban
		
		AE_SYSTBCSaiban = 9
		
		bolTran = False
		Pot_strDENNO = ""
		strFixCd = ""
		
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(Pin_strADDDENCD) = True And Pin_strDKBSB = gc_strDKBSB_MIT Then
			GoTo EXIT_AE_SYSTBCSaiban
		End If
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		Select Case Pin_strDKBSB
			'見積番号の採番
			Case gc_strDKBSB_MIT
				
				' === 20060814 === UPDATE S - ACE)Nagasawa
				'            'ユーザー伝票Noテーブル取得
				'            strSQL = ""
				'            strSQL = strSQL & " Select *             "
				'            strSQL = strSQL & "   from SYSTBC        "
				'            strSQL = strSQL & "  Where DKBSB    = '" & Pin_strDKBSB & "' "
				'            strSQL = strSQL & "    and ADDDENCD = '" & Pin_strADDDENCD & "' "
				'            strSQL = strSQL & "    for Update NoWait "
				'
				'            'SQL実行
				'            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
				'            If bolRet = False Then
				'                GoTo ERR_AE_SYSTBCSaiban
				'            End If
				'
				'            'EOF判定
				'            If CF_Ora_EOF(usrOdy) = True Then
				'                Pot_strDENNO = "00000001"
				'                'ユーザー伝票Noテーブル追加
				'                usrOdy.Obj_Ody.AddNew
				'                usrOdy.Obj_Ody.Fields("DKBSB").Value = gc_strDKBSB_MIT              '伝票取引区分種別
				'                usrOdy.Obj_Ody.Fields("ADDDENCD").Value = Pin_strADDDENCD           '伝票付属ｺｰﾄﾞ
				'                usrOdy.Obj_Ody.Fields("DENNM").Value = gc_strDENNM_MIT              '伝票名称
				'                usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                 '伝票No
				'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
				'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
				'                If Trim(GV_SysTime) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime               'タイムスタンプ（時間）
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
				'                End If
				'                If Trim(GV_SysDate) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate               'タイムスタンプ（日付）
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
				'                End If
				'                usrOdy.Obj_Ody.Update
				'            Else
				'                curDenNo = CCur(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
				'
				'                '見積番号は４桁
				'                If curDenNo > 9999 Then
				'                    curDenNo = 1
				'                End If
				'                strDenNo = Format(CStr(curDenNo), "00000000")
				'
				'                Pot_strDENNO = strDenNo
				'
				'                'ユーザー伝票Noテーブル更新
				'                usrOdy.Obj_Ody.Edit
				'                usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                     '伝票No
				'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
				'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
				'                If Trim(GV_SysTime) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
				'                End If
				'                If Trim(GV_SysDate) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
				'                End If
				'                usrOdy.Obj_Ody.Update
				'            End If
				'
				'            bolRet = CF_Ora_CloseDyn(usrOdy)
				'            If bolRet = False Then
				'                    GoTo ERR_AE_SYSTBCSaiban
				'            End If
				
				'見積番号採番処理
				intRet = F_SYSTBC_Update(Pin_strADDDENCD, Pot_strDENNO)
				If intRet <> 0 Then
					AE_SYSTBCSaiban = intRet
					GoTo ERR_AE_SYSTBCSaiban
				End If
				' === 20060814 === UPDATE E -
				
				'受注番号の採番
			Case gc_strDKBSB_UOD
				'採番マスタ取得
				strSQL = ""
				strSQL = strSQL & " Select *             "
				strSQL = strSQL & "   from SAIMTA        "
				strSQL = strSQL & "  Where SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
				' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
				'            strSQL = strSQL & "    for Update NoWait "
				strSQL = strSQL & "    for Update "
				' === 20061108 === UPDATE E -
				
				'SQL実行
				' === 20061119 === UPDATE S - ACE)Nagasawa
				'            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
				bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
				' === 20061119 === UPDATE E -
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
				' === 20061119 === INSERT S - ACE)Nagasawa
				'タイムスタンプ決定
				strDate = ""
				strTime = ""
				If Trim(GV_SysTime) <> "" Then
					'                strDate = GV_SysTime
					strDate = GV_SysDate
					strTime = GV_SysTime
				Else
					strDate = CStr(VB6.Format(Now, "yyyymmdd"))
					strTime = CStr(VB6.Format(Now, "hhmmss"))
				End If
				' === 20061119 === INSERT E -
				
				'EOF判定
				If CF_Ora_EOF(usrOdy) = True Then
					' === 20060927 === UPDATE S - ACE)Nagasawa
					'                Pot_strDENNO = "00001"
					Pot_strDENNO = "0001"
					' === 20060927 === UPDATE E -
					
					' === 20070909 === INSERT S - ACE)Nagasawa
					strFixCd = "R"
					' === 20070909 === INSERT E - ACE)Nagasawa
					
					'ユーザー伝票Noテーブル追加
					' === 20061119 === UPDATE S - ACE)Nagasawa
					'                usrOdy.Obj_Ody.AddNew
					'                usrOdy.Obj_Ody.Fields("SDKBSB").Value = gc_strSDKBSB_UOD            '伝票種別
					'                usrOdy.Obj_Ody.Fields("FIXCD").Value = "R"                          '固定値
					'                strFixCd = "R"
					'                usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO                '連番
					'                usrOdy.Obj_Ody.Fields("SAIKBA").Value = Space(1)                    '区分１
					'                usrOdy.Obj_Ody.Fields("SAIKBB").Value = Space(1)                    '区分２
					'                usrOdy.Obj_Ody.Fields("SAIKBC").Value = Space(1)                    '区分３
					'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
					'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
					'                If Trim(GV_SysTime) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime               'タイムスタンプ（時間）
					'                    usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime            'タイムスタンプ（登録時間）
					'                End If
					'                If Trim(GV_SysDate) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate               'タイムスタンプ（日付）
					'                    usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate            'タイムスタンプ（登録日付）
					'                End If
					'                usrOdy.Obj_Ody.Update
					
					strSQL = ""
					' === 20070909 === UPDATE S - ACE)Nagasawa
					'                strSQL = strSQL & " INSERT INTO SYSTBC "
					strSQL = strSQL & " INSERT INTO SAIMTA "
					strSQL = strSQL & " ( "
					' === 20070909 === UPDATE E -
					strSQL = strSQL & "     SDKBSB    "
					strSQL = strSQL & "   , FIXCD     "
					strSQL = strSQL & "   , SDENNO    "
					strSQL = strSQL & "   , SAIKBA    "
					strSQL = strSQL & "   , SAIKBB    "
					strSQL = strSQL & "   , SAIKBC    "
					strSQL = strSQL & "   , FOPEID    "
					strSQL = strSQL & "   , FCLTID    "
					strSQL = strSQL & "   , WRTFSTTM  "
					strSQL = strSQL & "   , WRTFSTDT  "
					strSQL = strSQL & "   , OPEID     "
					strSQL = strSQL & "   , CLTID     "
					strSQL = strSQL & "   , WRTTM     "
					strSQL = strSQL & "   , WRTDT     "
					strSQL = strSQL & "   , UOPEID    "
					strSQL = strSQL & "   , UCLTID    "
					strSQL = strSQL & "   , UWRTTM    "
					strSQL = strSQL & "   , UWRTDT    "
					strSQL = strSQL & "   , PGID      "
					' === 20070909 === INSERT S - ACE)Nagasawa
					strSQL = strSQL & " ) "
					' === 20070909 === INSERT E -
					strSQL = strSQL & " VALUES  "
					strSQL = strSQL & "   ( '" & gc_strSDKBSB_UOD & "' "
					strSQL = strSQL & "   , '" & "R" & "' "
					strSQL = strSQL & "   , '" & Pot_strDENNO & "' "
					' === 20070909 === UPDATE S - ACE)Nagasawa
					'                strSQL = strSQL & "   , '" & "Space(1) & " ' "
					'                strSQL = strSQL & "   , '" & "Space(1) & " ' "
					'                strSQL = strSQL & "   , '" & "Space(1) & " ' "
					strSQL = strSQL & "   , '" & Space(1) & "' "
					strSQL = strSQL & "   , '" & Space(1) & "' "
					strSQL = strSQL & "   , '" & Space(1) & "' "
					' === 20070909 === UPDATE E -
					strSQL = strSQL & "   , '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , '" & strTime & "' "
					strSQL = strSQL & "   , '" & strDate & "' "
					strSQL = strSQL & "   , '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , '" & strTime & "' "
					strSQL = strSQL & "   , '" & strDate & "' "
					strSQL = strSQL & "   , '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , '" & strTime & "' "
					strSQL = strSQL & "   , '" & strDate & "' "
					strSQL = strSQL & "   , '" & SSS_PrgId & "') "
					' === 20061119 === UPDATE E -
				Else
					'連番取得
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strDenNo = CF_Ora_GetDyn(usrOdy, "SDENNO", "")
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strFixCd = CF_Ora_GetDyn(usrOdy, "FIXCD", "")
					
					If strDenNo = "" Then
						GoTo ERR_AE_SYSTBCSaiban
					End If
					
					' === 20070909 === INSERT S - ACE)Nagasawa 受注番号が既に受注見出しトランに存在する場合はとばす("RA000T"と"RA001T"は使用不可)
					bolJDNNO_OK = False
					Do Until bolJDNNO_OK = True
						' === 20070909 === INSERT E -
						
						'受注番号
						For intCnt = 4 To 1 Step -1
							'CHG START FKS)INABA 2007/09/07 *************************************************************************
							bolRet = JDNNO_CntUp(Mid(strDenNo, intCnt, 1), strRtn)
							strDenNo = Left(strDenNo, intCnt - 1) & strRtn & Mid(strDenNo, intCnt + 1)
							'                    bolRet = JDNNO_CntUp(Mid(strDenNo, 1 + intCnt, 1), strRtn)
							'                    strDenNo = Left(strDenNo, 1 + intCnt - 1) & strRtn & Mid(strDenNo, 1 + intCnt + 1)
							'CHG  END  FKS)INABA 2007/09/07 *************************************************************************
							If bolRet = False Then
								Exit For
							End If
						Next intCnt
						
						' === 20060927 === INSERT S - ACE)Nagasawa
						'                If strDenNo = "00000" Then
						'                   strDenNo = "00001"
						'                End If
						If Trim(strDenNo) = "0000" Then
							strDenNo = "0001 "
						End If
						' === 20060927 === INSERT E -
						
						' === 20070909 === INSERT S - ACE)Nagasawa 受注番号が既に受注見出しトランに存在する場合はとばす("RA000T"と"RA001T"は使用不可)
						'"RA000T"と"RA001T"は除外
						If Mid(strDenNo, 1, 4) <> Mid(gc_strJDNNO_RA000T, 3, 4) And Mid(strDenNo, 1, 4) <> Mid(gc_strJDNNO_RA001T, 3, 4) Then
							'受注マスタ検索
							strSQL = ""
							strSQL = strSQL & " Select JDNNO         "
							strSQL = strSQL & "   from JDNTHA        "
							'2017/04/06 CHG START CIS <課金システム対応>
							'                        strSQL = strSQL & "  Where JDNNO IN ('" & strFixCd & "A" & Mid(strDenNo, 1, 4) & "' "
							'                        strSQL = strSQL & "                , '" & strFixCd & "B" & Mid(strDenNo, 1, 4) & "' "
							'                        strSQL = strSQL & "                , '" & strFixCd & "S" & Mid(strDenNo, 1, 4) & "')"
							strSQL = strSQL & "  Where JDNNO IN ('" & strFixCd & "A" & Mid(strDenNo, 1, 4) & "' "
							strSQL = strSQL & "                , '" & strFixCd & "B" & Mid(strDenNo, 1, 4) & "' "
							strSQL = strSQL & "                , '" & strFixCd & "S" & Mid(strDenNo, 1, 4) & "' "
							strSQL = strSQL & "                , '" & strFixCd & "T" & Mid(strDenNo, 1, 4) & "' "
							strSQL = strSQL & "                , '" & strFixCd & "U" & Mid(strDenNo, 1, 4) & "')"
							'2017/04/06 CHG E N D CIS <課金システム対応>
							
							'SQL実行
							bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_JDN, strSQL)
							If bolRet = False Then
								GoTo ERR_AE_SYSTBCSaiban
							End If
							
							'EOF判定
							If CF_Ora_EOF(usrOdy_JDN) = True Then
								bolJDNNO_OK = True
							End If
							
							bolRet = CF_Ora_CloseDyn(usrOdy_JDN)
							If bolRet = False Then
								GoTo ERR_AE_SYSTBCSaiban
							End If
						End If
						
					Loop 
					' === 20070909 === INSERT E -
					
					Pot_strDENNO = strDenNo
					
					'ユーザー伝票Noテーブル更新
					' === 20061119 === UPDATE S - ACE)Nagasawa
					'                usrOdy.Obj_Ody.Edit
					'                usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO                '伝票No
					'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
					'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
					'                If Trim(GV_SysTime) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
					'                Else
					'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
					'                End If
					'                If Trim(GV_SysDate) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
					'                Else
					'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
					'                End If
					'                usrOdy.Obj_Ody.Update
					
					strSQL = ""
					strSQL = strSQL & " UPDATE SAIMTA "
					strSQL = strSQL & " SET "
					strSQL = strSQL & "     SDENNO = '" & Pot_strDENNO & "' "
					strSQL = strSQL & "   , OPEID  = '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , CLTID  = '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , WRTTM  = '" & strTime & "' "
					strSQL = strSQL & "   , WRTDT  = '" & strDate & "' "
					strSQL = strSQL & "   , UOPEID = '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , UCLTID = '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , UWRTTM = '" & strTime & "' "
					strSQL = strSQL & "   , UWRTDT = '" & strDate & "' "
					strSQL = strSQL & "   , PGID   = '" & SSS_PrgId & "' "
					strSQL = strSQL & "  WHERE SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
					' === 20061119 === UPDATE E -
				End If
				
				' === 20061119 === INSERT S - ACE)Nagasawa
				'SQL実行
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				' === 20061119 === INSERT E -
				
				bolRet = CF_Ora_CloseDyn(usrOdy)
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
		End Select
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		'採番
		Select Case Pin_strDKBSB
			'見積番号
			Case gc_strDKBSB_MIT
				Pot_strDENNO = Mid(Pin_strADDDENCD, 3, 4) & Mid(Pot_strDENNO, 5, 4)
				
				'受注番号
			Case gc_strDKBSB_UOD
				Select Case Pin_strKbn
					' === 20060927 === UPDATE S - ACE)Nagasawa
					'                Case gc_strJDNTRKB_TAN                     '単品
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_SET                     'セットアップ
					'                    Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_SYS                     'システム
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_SYR                     '修理
					'                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_HSY                     '保守
					'                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_KAS                     '貸出
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_ELS                     'その他
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_TAN '単品
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_SET 'セットアップ
						Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_SYS 'システム
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_SYR '修理
						'2017/03/02 CHG START CIS <課金システム対応>
						'Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
						Pot_strDENNO = strFixCd & "T" & Mid(Pot_strDENNO, 1, 4)
						'2017/03/02 CHG E N D CIS <課金システム対応>
					Case gc_strJDNTRKB_HSY '保守
						'2017/03/02 CHG START CIS <課金システム対応>
						'Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
						If Pin_bolService = True Then
							'サービス品番の場合
							Pot_strDENNO = strFixCd & "U" & Mid(Pot_strDENNO, 1, 4)
						Else
							Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
						End If
						'2017/03/02 CHG E N D CIS <課金システム対応>
					Case gc_strJDNTRKB_KAS '貸出
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_ELS 'その他
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
						' === 20060927 === UPDATE E -
					Case Else
				End Select
			Case Else
				
		End Select
		
		AE_SYSTBCSaiban = 0
		
EXIT_AE_SYSTBCSaiban: 
		Exit Function
		
ERR_AE_SYSTBCSaiban: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 51 Then
			' === 20061108 === UPDATE E -
			'他で使用中
			AE_SYSTBCSaiban = 2
		End If
		
		If bolTran = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban
		
	End Function
	
	' === 20060814 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SYSTBC_Update
	'   概要：  SYSTBC更新処理
	'   引数：　Pin_strADDDENCD  :処理年月(数字６桁）
	' 　　　　　Pot_strDENNO     :取得された伝票№
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBC_Update(ByVal Pin_strADDDENCD As String, ByRef Pot_strDENNO As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static curDENNO As Decimal
		Static strDenNo As String
		Static strSTTNO As String
		Static strENDNO As String
		
		On Error GoTo ERR_F_SYSTBC_Update
		
		F_SYSTBC_Update = 9
		
		Pot_strDENNO = ""
		strSTTNO = ""
		strENDNO = ""
		
		'ユーザー伝票Noテーブル取得
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_MIT & "' "
		strSQL = strSQL & "    and ADDDENCD = '" & Pin_strADDDENCD & "' "
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    strSQL = strSQL & "    for Update NoWait "
		strSQL = strSQL & "    for Update "
		' === 20061108 === UPDATE E -
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		If bolRet = False Then
			GoTo ERR_F_SYSTBC_Update
		End If
		
		'EOF判定
		If CF_Ora_EOF(usrOdy) = True Then
			strSTTNO = "00000001"
			strENDNO = "00009999"
			Pot_strDENNO = strSTTNO
			'ユーザー伝票Noテーブル追加
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.AddNew の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.AddNew()
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DKBSB").Value = gc_strDKBSB_MIT '伝票取引区分種別
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("ADDDENCD").Value = Pin_strADDDENCD '伝票付属ｺｰﾄﾞ
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DENNM").Value = gc_strDENNM_MIT '伝票名称
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '伝票No
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("STTNO").Value = strSTTNO '開始伝票NO.
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("ENDNO").Value = strENDNO '終了伝票NO.
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '伝票No
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '最終作業者ｺｰﾄﾞ
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value 'クライアントID
			If Trim(GV_SysTime) <> "" Then
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime 'タイムスタンプ（時間）
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime 'タイムスタンプ（登録時間）
			Else
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
			End If
			If Trim(GV_SysDate) <> "" Then
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate 'タイムスタンプ（日付）
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate 'タイムスタンプ（登録日付）
			Else
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
			End If
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Update()
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSTTNO = CF_Ora_GetDyn(usrOdy, "STTNO", "0")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strENDNO = CF_Ora_GetDyn(usrOdy, "ENDNO", "")
			If IsNumeric(strENDNO) = False Then
				strENDNO = "00009999"
			End If
			
			'見積番号は４桁
			If curDENNO > CF_Get_CCurString(strENDNO) Then
				curDENNO = CF_Get_CCurString(strSTTNO)
			End If
			strDenNo = VB6.Format(CStr(curDENNO), New String("0", 8))
			
			Pot_strDENNO = strDenNo
			
			'ユーザー伝票Noテーブル更新
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Edit の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Edit()
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '伝票No
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '最終作業者ｺｰﾄﾞ
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value 'クライアントID
			If Trim(GV_SysTime) <> "" Then
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
			Else
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
			End If
			If Trim(GV_SysDate) <> "" Then
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
			Else
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
			End If
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Update()
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_F_SYSTBC_Update
		End If
		
		F_SYSTBC_Update = 0
		
EXIT_F_SYSTBC_Update: 
		Exit Function
		
ERR_F_SYSTBC_Update: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 51 Then
			' === 20061108 === UPDATE E -
			'他で使用中
			F_SYSTBC_Update = 2
		End If
		
		GoTo EXIT_F_SYSTBC_Update
		
	End Function
	' === 20060814 === INSERT E -
	
	' === 20060815 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_SYSTBCSaiban_PUDLNO
	'   概要：  入出庫番号採番処理
	'   引数：　Pm_strJDNTRKB   :受注取引区分
	'           Pm_strPUDLNO()  :入出庫番号
	'           Pm_intEntryKb   :登録訂正区分（1:登録　2:訂正）
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20060822 === UPDATE S - ACE)Sejima 入出庫番号採番処理
	'DPublic Static Function AE_SYSTBCSaiban_PUDLNO(ByVal Pm_strJDNTRKB As String, _
	''D                                              ByRef Pm_strPUDLNO() As String) As Integer
	' === 20060822 === UPDATE ↓
	Public Function AE_SYSTBCSaiban_PUDLNO(ByVal Pm_strJDNTRKB As String, ByRef Pm_strPUDLNO() As String, Optional ByVal Pm_intEntryKb As Short = 1) As Short
		' === 20060822 === UPDATE E
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static curSTTNO As Decimal
		Static curENDNO As Decimal
		Static strADDDENCD As String
		Static intCnt As Short
		Static intGetData As Short
		' === 20060822 === INSERT S - ACE)Sejima
		Static strNewPUDLNO As String 'SYSTBC更新用
		' === 20060822 === INSERT E
		
		On Error GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		
		AE_SYSTBCSaiban_PUDLNO = 9
		
		bolTran = False
		
		intGetData = 0
		'受注取引区分により判定
		Select Case Pm_strJDNTRKB
			'単品、システム、その他
			Case gc_strJDNTRKB_TAN, gc_strJDNTRKB_SYS, gc_strJDNTRKB_ELS
				intGetData = UBound(Pm_strPUDLNO)
				
				'セットアップ
			Case gc_strJDNTRKB_SET
				' === 20070312 === UPDATE S - ACE)Nagasawa セットアップも入出庫番号は全部取得
				'' === 20060822 === UPDATE S - ACE)Sejima 入出庫番号採番処理
				''D            intGetData = 1
				'' === 20060822 === UPDATE ↓
				'            Select Case Pm_intEntryKb
				'                Case 1
				'                    '登録の場合
				'                    intGetData = 1
				'                Case Else
				'                    '訂正の場合
				'                    intGetData = 0
				'
				'            End Select
				'' === 20060822 === UPDATE E
				intGetData = UBound(Pm_strPUDLNO)
				' === 20070312 === UPDATE E -
				
				'修理、保守、貸出
			Case gc_strJDNTRKB_SYR, gc_strJDNTRKB_HSY, gc_strJDNTRKB_KAS
				intGetData = 0
				
			Case Else
		End Select
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'ユーザー伝票№テーブル取得
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_PUDL & "' "
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    strSQL = strSQL & "    for Update NoWait "
		strSQL = strSQL & "    for Update "
		' === 20061108 === UPDATE E -
		
		'SQL実行
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		' === 20061108 === UPDATE E -
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'EOF判定
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBCSaiban_PUDLNO = 1
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'伝票付属コード取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strADDDENCD = Trim(CF_Ora_GetDyn(usrOdy, "ADDDENCD", ""))
		
		'開始伝票No取得
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
			curSTTNO = 1
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curSTTNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
		End If
		
		'終了伝票No取得
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
			curENDNO = 1
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curENDNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
		End If
		
		'伝票NO.取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
		If curDENNO > curENDNO Then
			'終了伝票NOを超えた場合は戻る
			curDENNO = curSTTNO
		End If
		
		For intCnt = 1 To intGetData
			' === 20060822 === UPDATE S - ACE)Sejima
			'D        Pm_strPUDLNO(intCnt) = strADDDENCD & Format(curDENNO, String(8, "0"))
			' === 20060822 === UPDATE ↓
			strNewPUDLNO = VB6.Format(curDENNO, New String("0", 8))
			Pm_strPUDLNO(intCnt) = strADDDENCD & strNewPUDLNO
			' === 20060822 === UPDATE E
			curDENNO = curDENNO + 1
			If curDENNO > curENDNO Then
				'終了伝票Noを超えた場合は戻る
				curDENNO = curSTTNO
			End If
		Next intCnt
		
		'ユーザー伝票№テーブル更新
		If intGetData > 0 Then
			' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
			'        usrOdy.Obj_Ody.Edit
			'' === 20060822 === UPDATE S - ACE)Sejima
			''D        usrOdy.Obj_Ody.Fields("DENNO").Value = Right(Pm_strPUDLNO(UBound(Pm_strPUDLNO)), 8)
			'' === 20060822 === UPDATE ↓
			'        usrOdy.Obj_Ody.Fields("DENNO").Value = strNewPUDLNO
			'' === 20060822 === UPDATE E
			'        If Trim(GV_SysTime) <> "" Then
			'            usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
			'        Else
			'            usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
			'        End If
			'        If Trim(GV_SysDate) <> "" Then
			'            usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
			'        Else
			'            usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
			'        End If
			'        usrOdy.Obj_Ody.Update
			
			strSQL = ""
			strSQL = strSQL & " UPDATE SYSTBC "
			strSQL = strSQL & "    SET DENNO      = '" & CF_Ora_String(strNewPUDLNO, 8) & "' "
			
			If Trim(GV_SysTime) <> "" Then
				strSQL = strSQL & "      , WRTTM      = '" & CF_Ora_String(GV_SysTime, 6) & "' "
			Else
				strSQL = strSQL & "      , WRTTM      = '" & CStr(VB6.Format(Now, "hhmmss")) & "' "
			End If
			
			If Trim(GV_SysDate) <> "" Then
				strSQL = strSQL & "      , WRTDT      = '" & CF_Ora_String(GV_SysDate, 8) & "' "
			Else
				strSQL = strSQL & "      , WRTDT      = '" & CStr(VB6.Format(Now, "yyyymmdd")) & "' "
			End If
			
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        DKBSB    = '" & gc_strDKBSB_PUDL & "' "
			
			'ＳＱＬ実行
			bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
			If bolRet = False Then
				GoTo ERR_AE_SYSTBCSaiban_PUDLNO
			End If
			' === 20061108 === UPDATE E -
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBCSaiban_PUDLNO = 0
		
EXIT_AE_SYSTBCSaiban_PUDLNO: 
		Exit Function
		
ERR_AE_SYSTBCSaiban_PUDLNO: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 51 Then
			' === 20061108 === UPDATE E -
			'他で使用中
			AE_SYSTBCSaiban_PUDLNO = 2
		End If
		
		If bolTran = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban_PUDLNO
		
	End Function
	' === 20060815 === INSERT E -
	
	' === 20130719 === INSERT S - FWEST)Koroyasu ｴﾝﾄﾞﾕｰｻﾞ対応
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_SYSTBCSaiban_ENDUSRCD
	'   概要：  エンドユーザコード採番処理
	'   引数：  Pm_strEndUsrCd  :エンドユーザコード
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBCSaiban_ENDUSRCD(ByRef Pm_strEndUsrCd As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static curSTTNO As Decimal
		Static curENDNO As Decimal
		Static strADDDENCD As String
		Static strNewENDUSRCD As String 'SYSTBC更新用
		
		On Error GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		
		AE_SYSTBCSaiban_ENDUSRCD = 9
		
		bolTran = False
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'ユーザー伝票№テーブル取得
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_ENDUSRCD & "' "
		strSQL = strSQL & "    for Update "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		End If
		
		'EOF判定
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBCSaiban_ENDUSRCD = 1
			GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		End If
		
		'伝票付属コード取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strADDDENCD = Trim(CF_Ora_GetDyn(usrOdy, "ADDDENCD", ""))
		
		'開始伝票No取得
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
			curSTTNO = 1
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curSTTNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
		End If
		
		'終了伝票No取得
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
			curENDNO = 1
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curENDNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
		End If
		
		'伝票NO.取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
		If curDENNO > curENDNO Then
			'終了伝票NOを超えた場合は戻る
			curDENNO = curSTTNO
		End If
		
		strNewENDUSRCD = VB6.Format(curDENNO, New String("0", 8))
		Pm_strEndUsrCd = strADDDENCD & VB6.Format(strNewENDUSRCD, New String("0", 5))
		curDENNO = curDENNO + 1
		If curDENNO > curENDNO Then
			'終了伝票Noを超えた場合は戻る
			curDENNO = curSTTNO
		End If
		
		'ユーザー伝票№テーブル更新
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBC "
		strSQL = strSQL & "    SET DENNO      = '" & CF_Ora_String(strNewENDUSRCD, 8) & "' "
		
		If Trim(GV_SysTime) <> "" Then
			strSQL = strSQL & "      , WRTTM      = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		Else
			strSQL = strSQL & "      , WRTTM      = '" & CStr(VB6.Format(Now, "hhmmss")) & "' "
		End If
		
		If Trim(GV_SysDate) <> "" Then
			strSQL = strSQL & "      , WRTDT      = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		Else
			strSQL = strSQL & "      , WRTDT      = '" & CStr(VB6.Format(Now, "yyyymmdd")) & "' "
		End If
		
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        DKBSB    = '" & gc_strDKBSB_ENDUSRCD & "' "
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBCSaiban_ENDUSRCD = 0
		
EXIT_AE_SYSTBCSaiban_ENDUSRCD: 
		Exit Function
		
ERR_AE_SYSTBCSaiban_ENDUSRCD: 
		
		If gv_Int_OraErr = 51 Then
			'他で使用中
			AE_SYSTBCSaiban_ENDUSRCD = 2
		End If
		
		If bolTran = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban_ENDUSRCD
		
	End Function
	' === 20130719 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function JDNNO_CntUp
	'   概要：  受注番号カウントアップ処理
	'   引数：　pin_strJDNNO     :カウントアップ対象文字
	'           pot_strRtn     :カウントアップ後文字
	'   戻値：  True:桁上がりあり  False:桁上がりなし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function JDNNO_CntUp(ByVal pin_strJDNNO As String, ByRef pot_strRtn As String) As Boolean
		
		Dim intJDNNO As Short
		Dim strJdnNo As String
		
		JDNNO_CntUp = False
		
		' === 20060927 === UPDATE S - ACE)Nagasawa
		'    Select Case pin_strJDNNO
		Select Case Trim(pin_strJDNNO)
			' === 20060927 === UPDATE E -
			Case "9"
				pot_strRtn = "A"
				Exit Function
				
			Case "Z"
				pot_strRtn = "0"
				JDNNO_CntUp = True
				Exit Function
				
				' === 20060927 === INSERT S - ACE)Nagasawa
			Case ""
				pot_strRtn = " "
				JDNNO_CntUp = True
				Exit Function
				' === 20060927 === INSERT E -
		End Select
		
		intJDNNO = Asc(pin_strJDNNO)
		pot_strRtn = Chr(intJDNNO + 1)
		
		Select Case pot_strRtn
			Case "I", "O"
				intJDNNO = Asc(pot_strRtn)
				pot_strRtn = Chr(intJDNNO + 1)
			Case Else
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CalcTAX_Meisai
	'   概要：  消費税計算処理
	'   引数：　Pin_strHINZEIKB    :商品消費税区分
	'           Pin_curZEIRT       :消費税率
	'           Pin_curTANKA       :単価(税抜き単価)
	'           Pin_curSURYO       :数量
	'           Pin_strTOKZEIKB    :得意先消費税区分
	'           Pin_strTOKRPSKB    :消費税端数処理桁数
	'           Pin_strTOKZRNKB    :消費税端数処理区分
	'           Pot_curUZEKN       :消費税額
	'   戻値：  True : 正常  False : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061116 === UPDATE S - ACE)Nagasawa システムの場合は単価 * 数量<>金額を可能とする
	'Public Static Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, _
	''                                         ByVal Pin_curZEIRT As Currency, _
	''                                         ByVal Pin_curTANKA As Currency, _
	''                                         ByVal Pin_curSURYO As Currency, _
	''                                         ByVal Pin_strTOKZEIKB As String, _
	''                                         ByVal Pin_strTOKRPSKB As String, _
	''                                         ByVal Pin_strTOKZRNKB As String, _
	''                                         ByRef Pot_curUZEKN As Currency) As Integer
	
	Public Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, ByVal Pin_curZEIRT As Decimal, ByVal Pin_curTANKA As Decimal, ByVal Pin_curSURYO As Decimal, ByVal Pin_strTOKZEIKB As String, ByVal Pin_strTOKRPSKB As String, ByVal Pin_strTOKZRNKB As String, ByRef Pot_curUZEKN As Decimal, Optional ByVal Pin_curKingk As Decimal = 0) As Boolean
		' === 20061116 === UPDATE E -
		
		Static curZeigk As Decimal
		Static strRPSKB As String
		
		On Error GoTo ERR_AE_CalcTAX_Meisai
		
		AE_CalcTAX_Meisai = False
		
		Pot_curUZEKN = 0
		
		strRPSKB = ""
		Select Case Pin_strTOKRPSKB
			'円未満
			Case gc_strTOKRPSKB_0
				strRPSKB = gc_strRPSKB_I1
				'十円未満
			Case gc_strTOKRPSKB_10
				strRPSKB = gc_strRPSKB_I2
				'百円未満
			Case gc_strTOKRPSKB_100
				strRPSKB = gc_strRPSKB_I3
				
		End Select
		
		Select Case Pin_strHINZEIKB '商品消費税区分
			'取引先区分どおり
			Case gc_strHINZEIKB_TOK
				Select Case Pin_strTOKZEIKB '得意先消費税区分
					'税抜き、税込み
					Case gc_strTOKZEIKB_KOM, gc_strTOKZEIKB_NUK
						' === 20061116 === UPDATE S - ACE)Nagasawa システムの場合は単価 * 数量<>金額を可能とする
						'                    curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
						If Pin_curKingk = 0 Then
							curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
						Else
							curZeigk = Pin_curKingk * Pin_curZEIRT / 100
						End If
						' === 20061116 === UPDATE E -
						Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
						Pot_curUZEKN = curZeigk
						
						'非課税
					Case gc_strTOKZEIKB_HIK
						
				End Select
				
				'税抜き,税込み
			Case gc_strHINZEIKB_KOM, gc_strHINZEIKB_NUK
				' === 20061116 === UPDATE S - ACE)Nagasawa システムの場合は単価 * 数量<>金額を可能とする
				'            curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
				If Pin_curKingk = 0 Then
					curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
				Else
					curZeigk = Pin_curKingk * Pin_curZEIRT / 100
				End If
				' === 20061116 === UPDATE E -
				Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
				Pot_curUZEKN = curZeigk
				'非課税
			Case gc_strHINZEIKB_HIK
			Case Else
		End Select
		
		AE_CalcTAX_Meisai = True
		
EXIT_AE_CalcTAX_Meisai: 
		
		Exit Function
		
ERR_AE_CalcTAX_Meisai: 
		
		GoTo EXIT_AE_CalcTAX_Meisai
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CalcRoundKingk
	'   概要：  金額まるめ計算処理
	'   引数：　Pio_curKingk       :まるめ金額
	'           Pin_strRPSKB    :金額端数処理桁数（消費税端数処理桁数の場合
	'           Pin_strZRNKB    :金額端数処理区分
	'   戻値：  なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub AE_CalcRoundKingk(ByRef Pio_curKingk As Decimal, ByVal pin_strRPSKB As String, ByVal pin_strZRNKB As String)
		
		Dim curKingk As Decimal
		Dim curKingk_wk As Decimal
		
		curKingk = 0
		
		Select Case pin_strRPSKB '金額端数処理桁数
			'１
			Case gc_strRPSKB_I1
				curKingk = Pio_curKingk
				'１０
			Case gc_strRPSKB_I2
				curKingk = Pio_curKingk / 10
				'１００
			Case gc_strRPSKB_I3
				curKingk = Pio_curKingk / 100
				'小数第一位
			Case gc_strRPSKB_D1
				curKingk = Pio_curKingk
				'小数第二位
			Case gc_strRPSKB_D2
				curKingk = Pio_curKingk * 10
				'小数第三位
			Case gc_strRPSKB_D3
				curKingk = Pio_curKingk * 100
				'小数第四位
			Case gc_strRPSKB_D4
				curKingk = Pio_curKingk * 1000
				'小数第五位
			Case gc_strRPSKB_D5
				curKingk = Pio_curKingk * 10000
		End Select
		
		Select Case pin_strZRNKB '金額端数処理区分
			'切捨て
			Case gc_strTOKZRNKB_DWN
				curKingk = Fix(curKingk)
				'四捨五入
			Case gc_strTOKZRNKB_RND
				' === 20061115 === UPDATE S - ACE)Nagasawa
				'            curKingk = Round(curKingk)
				If curKingk >= 0 Then
					curKingk = Fix(curKingk + 0.5)
				Else
					curKingk = Fix(curKingk - 0.5)
				End If
				' === 20061115 === UPDATE E -
				'切り上げ
			Case gc_strTOKZRNKB_UP
				curKingk_wk = Fix(curKingk)
				If curKingk_wk < curKingk Then
					curKingk = curKingk_wk + 1
				Else
					curKingk = curKingk_wk
				End If
		End Select
		
		Select Case pin_strRPSKB '金額端数処理桁数
			'１
			Case gc_strRPSKB_I1
				curKingk = curKingk
				'１０
			Case gc_strRPSKB_I2
				curKingk = curKingk * 10
				'１００
			Case gc_strRPSKB_I3
				curKingk = curKingk * 100
				'小数第一位
			Case gc_strRPSKB_D1
				curKingk = curKingk
				'小数第二位
			Case gc_strRPSKB_D2
				curKingk = curKingk / 10
				'小数第三位
			Case gc_strRPSKB_D3
				curKingk = curKingk / 100
				'小数第四位
			Case gc_strRPSKB_D4
				curKingk = curKingk / 1000
				'小数第五位
			Case gc_strRPSKB_D5
				curKingk = curKingk / 10000
		End Select
		
		Pio_curKingk = curKingk
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Calc_SIKRT
	'   概要：  仕切率計算処理
	'   引数：　Pin_curTANKA       :単価
	'           Pin_curTEIKATK     :定価
	'           Pin_strTKNZRNKB    :金額端数処理区分
	'   戻値：  仕切率
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_SIKRT(ByVal Pin_curTANKA As Decimal, ByVal Pin_curTEIKATK As Decimal, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curSIKRT As Decimal
		Static strZRNKB As String
		
		AE_Calc_SIKRT = 0
		If Pin_curTEIKATK = 0 Then
			curSIKRT = 0
		Else
			curSIKRT = Pin_curTANKA / Pin_curTEIKATK * 100
		End If
		
		Select Case Pin_strTKNZRNKB '金額端数処理区分
			'切捨て
			Case gc_strTOKZRNKB_DWN
				strZRNKB = gc_strTOKZRNKB_UP
				'四捨五入
			Case gc_strTOKZRNKB_RND
				strZRNKB = gc_strTOKZRNKB_RND
				'切り上げ
			Case gc_strTOKZRNKB_UP
				strZRNKB = gc_strTOKZRNKB_DWN
		End Select
		
		'金額丸め処理
		' === 20061020 === UPDATE S - ACE)Nagasawa オーバーフロー対応
		'    Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D1, strZRNKB)
		Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D2, strZRNKB)
		' === 20061020 === UPDATE E -
		
		AE_Calc_SIKRT = curSIKRT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Calc_TANKA
	'   概要：  単価計算処理（仕切率より）
	'   引数：　Pin_curSIKRT       :仕切率
	'           Pin_curTEIKATK     :定価
	'           Pin_strTKNRPSKB    :金額端数処理桁数
	'           Pin_strTKNZRNKB    :金額端数処理区分
	'   戻値：  単価
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_TANKA(ByVal Pin_curSIKRT As Decimal, ByVal Pin_curTEIKATK As Decimal, ByVal Pin_strTKNRPSKB As String, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curTanka As Decimal
		
		AE_Calc_TANKA = 0
		curTanka = Pin_curTEIKATK * Pin_curSIKRT / 100
		
		'金額丸め処理
		Call AE_CalcRoundKingk(curTanka, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
		
		AE_Calc_TANKA = curTanka
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Calc_BSART
	'   概要：  売差率計算処理
	'   引数：　Pin_curTANKA       :単価
	'           Pin_curSIKTK       :仕切単価
	'           Pin_strTKNRPSKB    :金額端数処理桁数
	'           Pin_strTKNZRNKB    :金額端数処理区分
	'   戻値：  仕切率
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_BSART(ByVal Pin_curTANKA As Decimal, ByVal Pin_curSIKTK As Decimal, ByVal Pin_strTKNRPSKB As String, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curBSART As Decimal
		
		AE_Calc_BSART = 0
		
		If Pin_curTANKA = 0 Then
			curBSART = 0
		Else
			curBSART = (Pin_curTANKA - Pin_curSIKTK) / Pin_curTANKA * 100
		End If
		
		'金額丸め処理
		' === 20061025 === UPDATE S - ACE)Nagasawa 必ず小数第二位で丸める
		'    Call AE_CalcRoundKingk(curBSART, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
		Call AE_CalcRoundKingk(curBSART, gc_strRPSKB_D2, Pin_strTKNZRNKB)
		' === 20061025 === UPDATE E -
		
		AE_Calc_BSART = curBSART
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CalcDateAdd
	'   概要：  日付計算処理
	'   引数：　Pio_strDate     :計算対象日(数字８桁、またはyyyy/mm/ddの形式）
	'           Pin_intAddDate  :加算対象日数（マイナス値は減算）
	'           Pin_strKind     :営業日種別("1":営業日 "2":銀行稼働日　"3":物流稼働日）
	'                            省略時は営業日による考慮無し
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CalcDateAdd(ByRef Pio_strDate As String, ByVal Pin_intAddDate As Short, Optional ByVal Pin_strKind As String = "0") As Short
		
		Dim strDate As String
		Dim Mst_Inf As TYPE_DB_CLDMTA
		Dim intAddDate As Short '日付計算用
		
		AE_CalcDateAdd = 9
		
		strDate = ""
		
		'日付整合性チェック
		If IsDate(Pio_strDate) = True Then
			strDate = Pio_strDate
		End If
		
		'日付様式に変換
		If IsDate(VB6.Format(Pio_strDate, "@@@@/@@/@@")) = True Then
			strDate = VB6.Format(Pio_strDate, "@@@@/@@/@@")
		End If
		
		If Trim(strDate) = "" Then
			Exit Function
		End If
		
		'日付加算
		strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, Pin_intAddDate, CDate(strDate)))
		
		'カレンダマスタ検索
		If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
			Exit Function
		End If
		
		If Pin_intAddDate >= 0 Then
			intAddDate = 1
		Else
			intAddDate = -1
		End If
		
		Select Case Pin_strKind
			'営業日計算
			Case "1"
				Do Until Mst_Inf.SLDKB = "1"
					strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, intAddDate, CDate(strDate)))
					'カレンダマスタ検索
					If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
						Exit Function
					End If
				Loop 
				
				'銀行稼働日計算
			Case "2"
				Do Until Mst_Inf.BNKKDKB = "1"
					strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, intAddDate, CDate(strDate)))
					'カレンダマスタ検索
					If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
						Exit Function
					End If
				Loop 
				
				'物流稼働日計算
			Case "3"
				Do Until Mst_Inf.DTBKDKB = "1"
					strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, intAddDate, CDate(strDate)))
					'カレンダマスタ検索
					If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
						Exit Function
					End If
				Loop 
				
			Case Else
				
		End Select
		
		Pio_strDate = strDate
		AE_CalcDateAdd = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CmnMsgLibrary
	'   概要：  標準メッセージ表示処理
	'   引数：  Pin_strPgNm     : プログラム名
	'           Pin_strMsgCode  : メッセージコード（DB検索用）
	'           pm_All  　　　  : 画面情報
	'           pin_strMsg      : 追加メッセージ
	'           pin_strHeadMsg  : メッセージ先頭への追加メッセージ
	'   戻値：  選択ボタン
	'   備考：  アプリの実行時に出力される標準メッセージ。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061031 === UPDATE S - ACE)Nagasawa
	'Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, _
	''                                 ByVal Pin_strMsgCode As String, _
	''                                 ByRef pm_All As Cls_All, _
	''                                 Optional ByVal pin_strMsg As String = "") As Integer
	Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, ByRef pm_All As Cls_All, Optional ByVal pin_strMsg As String = "", Optional ByVal pin_strHeadMsg As String = "") As Short
		' === 20061031 === UPDATE E -
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
		' === 20060914 === INSERT S - ACE)Nagasawa
		On Error Resume Next
		' === 20060914 === INSERT E -
		
		AE_CmnMsgLibrary = False
		
		If pm_All.Dsp_IM_Denkyu Is Nothing Then
		Else
			'プロンプトメッセージのクリア
			Call CF_Clr_Prompt(pm_All)
		End If
		
		strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1) 'メッセージ種別
		strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2) 'メッセージアイテム
		
		' === 20060810 === INSERT S - ACE)Nagasawa
		Beep()
		' === 20060810 === INSERT E -
		
		'メッセージマスタ検索
		intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
		If intRet <> 0 Then
			intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
			If intRet <> 0 Then
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				Exit Function
			End If
		End If
		
		'追加メッセージの編集
		strMsg_add = ""
		If Mst_Inf.MSGSQ = "9" Then
			'ＤＢアクセス系エラーとする
			' === 20061026 === UPDATE S - ACE)Nagasawa メッセージ表示の変更（発生箇所を表示しない場合あり）
			'        strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "発生箇所   : " & pin_strMsg
			
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText
			
			'追加メッセージがある場合、発生箇所として表示する
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = strMsg_add & "発生箇所   : " & pin_strMsg
			End If
			' === 20061026 === UPDATE E -
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
		'メッセージフラグTrue
		GV_bolMsgFlg = True
		'キーバッファのクリア
		Call ClearKeyBuffers(pm_All)
		' === 20060920 === INSERT E
		
		'Windowsに制御を戻す
		System.Windows.Forms.Application.DoEvents()
		
		' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
		'メッセージ出力終了するまでは抜ける
		If GV_bolMsgFlg = False Then
			Exit Function
		End If
		' === 20060920 === INSERT E
		
		' === 20140129 === INSERT S - 両備)Shikichi
		If AE_CMN.NonRaisedMsg Then
			
			' イベントテーブル書き込み
			Call EVTLOG_OUT(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, "WRTTRN")
			
			' 「はい」ボタン押下時と同じにする
			AE_CmnMsgLibrary = MsgBoxResult.Yes
			
			GV_bolMsgFlg = False
			Exit Function
		End If
		' === 20140129 === INSERT E - 両備)Shikichi
		
		'メッセージ表示
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'OK/キャンセル
			Case gc_strBTNKB_OKCancel
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'中止/再試行/無視
			Case gc_strBTNKB_AbortRetryIgnore
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbAbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'はい/いいえ/キャンセル
			Case gc_strBTNKB_YesNoCancel
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'はい/いいえ
			Case gc_strBTNKB_YesNo
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'再試行/キャンセル
			Case gc_strBTNKB_RetryCancel
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbRetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
			Case Else
				
		End Select
		' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
		'メッセージフラグFalse
		GV_bolMsgFlg = False
		' === 20060920 === INSERT E
		
	End Function
	' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
	
	'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CmnMsgLibrary_2
	'   概要：  標準メッセージ表示処理（画面情報なし版）
	'   引数：  Pin_strPgNm     : プログラム名
	'           Pin_strMsgCode  : メッセージコード（DB検索用）
	'           pin_strMsg      : 追加メッセージ
	'           pin_strHeadMsg  : メッセージ先頭への追加メッセージ
	'   戻値：  選択ボタン
	'   備考：  アプリの実行時に出力される標準メッセージ。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CmnMsgLibrary_2(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, Optional ByVal pin_strMsg As String = "", Optional ByVal pin_strHeadMsg As String = "") As Short
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
		On Error Resume Next
		
		AE_CmnMsgLibrary_2 = False
		
		strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1) 'メッセージ種別
		strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2) 'メッセージアイテム
		
		Beep()
		
		'メッセージマスタ検索
		intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
		If intRet <> 0 Then
			intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
			If intRet <> 0 Then
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				Exit Function
			End If
		End If
		
		'追加メッセージの編集
		strMsg_add = ""
		If Mst_Inf.MSGSQ = "9" Then
			'ＤＢアクセス系エラーとする
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText
			
			'追加メッセージがある場合、発生箇所として表示する
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = strMsg_add & "発生箇所   : " & pin_strMsg
			End If
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		'メッセージフラグTrue
		GV_bolMsgFlg = True
		
		'Windowsに制御を戻す
		System.Windows.Forms.Application.DoEvents()
		
		'メッセージ出力終了するまでは抜ける
		If GV_bolMsgFlg = False Then
			Exit Function
		End If
		
		'メッセージ表示
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				
				'OK/キャンセル
			Case gc_strBTNKB_OKCancel
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'中止/再試行/無視
			Case gc_strBTNKB_AbortRetryIgnore
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'はい/いいえ/キャンセル
			Case gc_strBTNKB_YesNoCancel
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'はい/いいえ
			Case gc_strBTNKB_YesNo
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'再試行/キャンセル
			Case gc_strBTNKB_RetryCancel
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				
			Case Else
				
		End Select
		
		'メッセージフラグFalse
		GV_bolMsgFlg = False
		
	End Function
	'''' ADD 2009/11/26  FKS) T.Yamamoto    End
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub ClearKeyBuffers
	'   概要：  キーバッファクリア処理
	'   引数：  pm_All  　　　  : 画面情報
	'   戻値：  なし
	'   備考：  APIによるキーバッファのクリア
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub ClearKeyBuffers(ByRef pm_All As Cls_All)
		Dim tMsg As Msg
		Dim lngRet As Integer
		
		Do 
			lngRet = PeekMessage(tMsg, pm_All.Dsp_Base.FormCtl.Handle.ToInt32, WM_KEYFIRST, WM_KEYLAST, PM_REMOVE)
		Loop Until lngRet = 0
	End Sub
	' === 20060920 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_GetSMEDT
	'   概要：  締日計算処理
	'   引数：  Pin_strDate     : 計算対象日付(８桁の数値Or日付）
	'           Pin_strTOKSMEKB : 締区分
	'           Pin_strTOKSMEDD : 締初期日付（売上）
	'           Pin_strTOKSMECC : 締サイクル（売上）
	'           Pin_strTOKSDWKB : 締め曜日
	'           Pin_intCHTNKB   : 帳端区分(計算対象日から何回目の締日かを指定)
	'           Pot_strSMEDT    : 計算結果締日
	'   戻値：  0：正常　9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetSMEDT(ByVal pin_strDate As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKSMEDD As String, ByVal Pin_strTOKSMECC As String, ByVal Pin_strTOKSDWKB As String, ByVal Pin_intCHTNKB As Short, ByRef Pot_strSMEDT As String) As Short
		
		Dim strDate As String
		Dim yy As Short
		Dim mm As Short
		Dim dd As Short
		Dim Cnt As Short
		Dim I As Short
		Dim setidx As Short
		Dim idx As Short
		Dim addMM As Short
		Dim smeday(15) As Short
		Dim intTOKSMECC As Short
		Dim intTOKSMEDD As Short
		Dim intTOKSDWKB As Short
		
		AE_GetSMEDT = 9
		Pot_strSMEDT = ""
		
		'日付チェック
		If IsDate(pin_strDate) = True Then
			strDate = VB6.Format(pin_strDate, "yyyy/mm/dd")
		Else
			If IsDate(VB6.Format(pin_strDate, "@@@@/@@/@@")) = True Then
				strDate = VB6.Format(pin_strDate, "@@@@/@@/@@")
			Else
				Exit Function
			End If
		End If
		
		yy = Year(CDate(strDate))
		mm = Month(CDate(strDate))
		dd = VB.Day(CDate(strDate))
		
		If Pin_strTOKSMEKB = gc_strSMEKB_DAY Then
			'締初期日付取得
			If IsNumeric(Pin_strTOKSMEDD) = True Then
				intTOKSMEDD = CShort(Pin_strTOKSMEDD)
			Else
				Exit Function
			End If
			
			'締サイクル取得
			If IsNumeric(Pin_strTOKSMECC) = True Then
				intTOKSMECC = CShort(Pin_strTOKSMECC)
			Else
				Exit Function
			End If
			
			'締区分＝"日"の場合
			If intTOKSMECC = 1 Then '毎日締め
				Pot_strSMEDT = CStr(DateSerial(yy, mm, dd + Pin_intCHTNKB))
				Exit Function
			End If
			'
			If intTOKSMECC <= 0 Or intTOKSMECC > 15 Then intTOKSMECC = 30
			Cnt = Int(30 / intTOKSMECC) '締回数／月
			setidx = False
			For I = 0 To Cnt - 1
				smeday(I) = intTOKSMEDD + intTOKSMECC * I
				If smeday(I) > 27 Then smeday(I) = 99
				If dd <= smeday(I) And setidx = False Then
					idx = I + Pin_intCHTNKB '該当日付の締日配列添字
					setidx = True
				End If
			Next I
			If setidx = False Then idx = Cnt + Pin_intCHTNKB
			addMM = Int(idx / Cnt)
			idx = idx Mod Cnt
			If idx < 0 Then idx = idx + Cnt
			'
			If smeday(idx) = 99 Then
				Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM + 1, 0))
			Else
				Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM, smeday(idx)))
			End If
			
		Else
			'締曜日取得
			If IsNumeric(Pin_strTOKSDWKB) = True Then
				intTOKSDWKB = CShort(Pin_strTOKSDWKB)
			Else
				Exit Function
			End If
			
			'締日区分＝"曜日"の場合
			If WeekDay(CDate(strDate)) > intTOKSDWKB Then
				Pot_strSMEDT = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (7 - WeekDay(CDate(strDate)) + intTOKSDWKB) + (7 * Pin_intCHTNKB)))
			Else
				Pot_strSMEDT = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (intTOKSDWKB - WeekDay(CDate(strDate))) + (7 * Pin_intCHTNKB)))
			End If
		End If
		
		Pot_strSMEDT = VB6.Format(Pot_strSMEDT, "yyyymmdd")
		
		AE_GetSMEDT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_GetUDNYTDT
	'   概要：  売上予定日計算処理
	'   引数：  Pin_strDEFNOKDT : 納期(８桁の数値Or日付）
	'           Pin_strODNYTDT  : 出荷予定日
	'           Pin_strUDNYTDT  : 売上予定日（画面入力項目)
	'           Pin_strTOKSMEKB : 締区分
	'           Pin_strTOKSMEDD : 締初期日付（売上）
	'           Pin_strTOKSMECC : 締サイクル（売上）
	'           Pin_strTOKSDWKB : 締め曜日
	'           Pin_strURIKJN   : 売上基準
	'           Pot_strUDNYTDT  : 計算結果売上予定日(yyyymmddの形式）
	'   戻値：  0：正常　9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetUDNYTDT(ByVal Pin_strDEFNOKDT As String, ByVal pin_strODNYTDT As String, ByVal Pin_strUDNYTDT As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKSMEDD As String, ByVal Pin_strTOKSMECC As String, ByVal Pin_strTOKSDWKB As String, ByVal pin_strURIKJN As String, ByRef Pot_strUDNYTDT As String) As Short
		
		Dim strDate As String
		Dim strDate2 As String
		Dim intRet As Short
		Dim strSMEDT As String
		
		AE_GetUDNYTDT = 9
		Pot_strUDNYTDT = ""
		
		Select Case pin_strURIKJN
			'出荷基準
			Case gc_strURIKJN_SYK
				'日付チェック
				If IsDate(pin_strODNYTDT) = True Then
					strDate = VB6.Format(pin_strODNYTDT, "yyyymmdd")
				Else
					If IsDate(VB6.Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
						strDate = pin_strODNYTDT
					Else
						Exit Function
					End If
				End If
				
				'営業日取得
				intRet = DSPCLDDT_SEARCH_KDKB(strDate, "1", "1", Pot_strUDNYTDT)
				If intRet <> 0 Then
					Exit Function
				End If
				
				'検収基準、工事完了基準
			Case gc_strURIKJN_KNS, gc_strURIKJN_KOJ
				'日付チェック
				
				' === 20060726 === INSERT S - ACE)Nagasawa
				If Trim(Pin_strUDNYTDT) <> "" Then
					' === 20060726 === INSERT E -
					If IsDate(Pin_strUDNYTDT) = True Then
						strDate = VB6.Format(Pin_strUDNYTDT, "yyyymmdd")
					Else
						If IsDate(VB6.Format(Pin_strUDNYTDT, "@@@@/@@/@@")) = True Then
							strDate = Pin_strUDNYTDT
						Else
							Exit Function
						End If
					End If
					' === 20060726 === INSERT S - ACE)Nagasawa
				Else
					If IsDate(pin_strODNYTDT) = True Then
						strDate = VB6.Format(pin_strODNYTDT, "yyyymmdd")
					Else
						If IsDate(VB6.Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
							strDate = pin_strODNYTDT
						Else
							Exit Function
						End If
					End If
				End If
				' === 20060726 === INSERT E -
				
				Pot_strUDNYTDT = strDate
				
				'役務完了基準
			Case gc_strURIKJN_EKM
				' === 20060830 === UPDATE S - ACE)Nagasawa
				'            '日付チェック
				'            If IsDate(Pin_strDEFNOKDT) = True Then
				'                strDate = Format(Pin_strDEFNOKDT, "yyyymmdd")
				'            Else
				'                If IsDate(Format(Pin_strDEFNOKDT, "@@@@/@@/@@")) = True Then
				'                    strDate = Pin_strDEFNOKDT
				'                Else
				'                    Exit Function
				'                End If
				'            End If
				'
				'            '売上予定日を計算
				'            intRet = AE_GetSMEDT(strDate, _
				''                                 Pin_strTOKSMEKB, _
				''                                 Pin_strTOKSMEDD, _
				''                                 Pin_strTOKSMECC, _
				''                                 Pin_strTOKSDWKB, _
				''                                 1, _
				''                                 strDate2)
				
				'日付チェック
				If IsDate(pin_strODNYTDT) = True Then
					strDate2 = VB6.Format(pin_strODNYTDT, "yyyymmdd")
				Else
					If IsDate(VB6.Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
						strDate2 = pin_strODNYTDT
					Else
						Exit Function
					End If
				End If
				' === 20060830 === UPDATE E -
				
				If intRet = 9 Then
					Exit Function
				End If
				
				'営業日取得
				intRet = DSPCLDDT_SEARCH_KDKB(strDate2, "1", "2", Pot_strUDNYTDT)
				If intRet <> 0 Then
					Exit Function
				End If
				
		End Select
		
		
		AE_GetUDNYTDT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_GetKRSMADT
	'   概要：  経理締日計算処理
	'   引数：  Pin_strKJNDT    : 基準日
	'           Pot_strSMADT  　: 計算結果経理締日(yyyymmddの形式）
	'   戻値：  0：正常　9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetKRSMADT(ByVal pin_strKJNDT As String, ByRef Pot_strSMADT As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Mst_Inf_SYSTBA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim intRet As Short
		
		AE_GetKRSMADT = 9
		Pot_strSMADT = ""
		
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'ユーザー情報管理テーブル検索
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			Exit Function
		End If
		
		'経理締日計算
		intRet = AE_GetSMEDT(pin_strKJNDT, gc_strSMEKB_DAY, Mst_Inf_SYSTBA.SMEDD, "99", "", 0, strSMEDT)
		If intRet <> 0 Then
			Exit Function
		End If
		
		Pot_strSMADT = strSMEDT
		
		AE_GetKRSMADT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_GetTanka
	'   概要：  PL/SQL実行処理(単価取得処理)
	'   引数：　Pin_strHINCD  : 商品コード
	'           Pin_strTOKCD  : 得意先コード
	'           Pin_strDATE   : 適用日
	'           Pin_strTUKKB  : 通貨区分
	'           Pin_lngSU     : 数量
	'           Pot_curTanka  : 取得単価
	'           Pot_curSIKRT  : 取得仕切率
	'           Pin_strJDNKB  : 受注区分（"1"海外　それ以外は空白）
	'           Pot_curTEITK  : 定価
	'   戻値：　0 : 正常 9: 異常
	'   備考：  単価取得用PL/SQL(PRC_CMNPL90_01)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_GetTanka(ByVal pin_strHINCD As String, ByVal pin_strTOKCD As String, ByVal pin_strDate As String, ByVal pin_strTUKKB As String, ByVal Pin_lngSU As Integer, ByRef Pot_curTANKA As Decimal, ByRef Pot_curSIKRT As Decimal, Optional ByRef Pin_strJDNKB As String = "", Optional ByRef Pot_curTEITK As Decimal = 0) As Short
		
		Dim strSQL As String 'SQL文
		Dim strPara1 As String 'ﾊﾟﾗﾒｰﾀ1(製品コード)
		Dim strPara2 As String 'ﾊﾟﾗﾒｰﾀ2(得意先コード)
		Dim strPara3 As String 'ﾊﾟﾗﾒｰﾀ3(適用日)
		Dim strPara4 As String 'ﾊﾟﾗﾒｰﾀ4(通貨区分)
		Dim lngPara5 As Integer 'ﾊﾟﾗﾒｰﾀ5(数量)
		Dim strPara6 As String 'ﾊﾟﾗﾒｰﾀ6(受注区分)
		Dim lngPara7 As Integer 'ﾊﾟﾗﾒｰﾀ7(復帰ｺｰﾄﾞ)
		Dim lngPara8 As Integer 'ﾊﾟﾗﾒｰﾀ8(ｴﾗｰｺｰﾄﾞ)
		Dim strPara9 As String 'ﾊﾟﾗﾒｰﾀ9(ｴﾗｰ内容)
		' === 20060920 === UPDATE S - ACE)Nagasawa
		'    Dim lngPara10   As Long             'ﾊﾟﾗﾒｰﾀ10(販売単価)
		Dim lngPara10 As Decimal 'ﾊﾟﾗﾒｰﾀ10(販売単価)
		' === 20060920 === UPDATE E -
		Dim lngPara11 As Integer 'ﾊﾟﾗﾒｰﾀ11(仕切率)
		Dim lngPara12 As Integer 'ﾊﾟﾗﾒｰﾀ12(定価)
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(13) As OraParameter 'PL/SQLのバインド変数
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_GetTanka = 9
		
		'受渡し変数初期設定
		strPara1 = pin_strHINCD
		strPara2 = pin_strTOKCD
		strPara3 = pin_strDate
		strPara4 = pin_strTUKKB
		lngPara5 = Pin_lngSU
		strPara6 = Pin_strJDNKB
		lngPara7 = 0
		lngPara8 = 0
		strPara9 = ""
		lngPara10 = 0
		lngPara11 = 0
		lngPara12 = 0
		
		'パラメータの初期設定を行う（バインド変数）
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P12", lngPara12, ORAPARM_OUTPUT)
		
		'データ型をオブジェクトにセット
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11) = gv_Odb_USR1.Parameters("P11")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(12) = gv_Odb_USR1.Parameters("P12")
		
		'各オブジェクトのデータ型を設定
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(12).serverType = ORATYPE_NUMBER
		
		'PL/SQL呼び出しSQL
		strSQL = "BEGIN PRC_CMNPL90_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12); End;"
		
		'DBアクセス
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_GetTanka_END
		End If
		
		'** 戻り値取得
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara7 = param(7).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara8 = param(8).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(param(9).Value) = False Then
			'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strPara9 = param(9).Value
		End If
		
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(param(10).Value) = False Then
			'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			lngPara10 = param(10).Value
		Else
			lngPara10 = 0
		End If
		
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(param(11).Value) = False Then
			'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			lngPara11 = param(11).Value
		Else
			lngPara11 = 0
		End If
		
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(param(12).Value) = False Then
			'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			lngPara12 = param(12).Value
		Else
			lngPara12 = 0
		End If
		
		Pot_curTANKA = CDec(lngPara10)
		Pot_curSIKRT = CDec(lngPara11)
		Pot_curTEITK = CDec(lngPara12)
		
		'エラー情報設定
		gv_Int_OraErr = lngPara8
		gv_Str_OraErrText = strPara9 & vbCrLf
		
		AE_Execute_PLSQL_GetTanka = lngPara7
		
AE_Execute_PLSQL_GetTanka_END: 
		'** パラメタ解消
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P11")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P12")
		
		
	End Function
	
	' === 20060829 === DELETE S - ACE)Nagasawa 使用されていないため削除
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称：  Function AE_Get_TANKA
	''   概要：  単価、仕切率取得処理
	''   引数：　Pin_strHINCD       :製品コード
	''           Pin_strTOKCD       :得意先コード
	''           Pin_strDATE        :基準日
	''           Pot_curSIKRT       :仕切率
	''           Pot_curTANKA       :取得単価
	''   戻値：  0 : 正常　9 : 異常
	''   備考：
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Static Function AE_Get_TANKA(ByVal pin_strHINCD As String, _
	''                                    ByVal pin_strTOKCD As String, _
	''                                    ByVal pin_strDate As String, _
	''                                    ByRef Pot_curSIKRT As Currency, _
	''                                    ByRef Pot_curTANKA As Currency) As Integer
	'
	'    Dim Mst_Inf_HINMTA      As TYPE_DB_HINMTA       '商品マスタ検索結果
	''    Dim Mst_Inf_RNKMTA      As TYPE_DB_RNKMTA       'ランク別仕切り率マスタ検索結果
	'    Dim Mst_Inf_TOKMTA      As TYPE_DB_TOKMTA       '得意先マスタ検索結果
	''    Dim Mst_Inf_TRKMTA      As type_db_trkmta       '得意先別商品ランクマスタ検索結果
	'
	'    AE_Get_TANKA = 9
	'
	'    Pot_curSIKRT = 100
	'    Pot_curTANKA = 0
	'
	'    '商品マスタ検索
	'    If DSPHINCD_SEARCH(pin_strHINCD, Mst_Inf_HINMTA) <> 0 Then
	'        GoTo AE_Get_TANKA_ERR
	'    End If
	'
	'    If Mst_Inf_HINMTA.DATKB <> gc_strDATKB_USE Then
	'        GoTo AE_Get_TANKA_ERR
	'    End If
	'
	''**********************仮☆★☆★
	'    Pot_curSIKRT = 90
	'    Pot_curTANKA = Mst_Inf_HINMTA.ZNKURITK
	''**********************仮☆★☆★
	''    '得意先マスタ検索
	''    If DSPTOKCD_SEARCH(Pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    '得意先別商品ランクマスタ検索
	''    If DSPTRKRNK_SEARCH(Pin_strTOKCD, Mst_Inf_HINMTA.HINGRP, Pin_strDATE, Mst_Inf_TRKMTA) <> 0 Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    '仕切率取得
	''    If DSPRNKM_SEARCH(Mst_Inf_HINMTA.HINGRP, "", Pin_strDATE, Mst_Inf_RNKMTA) <> 0 Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    If Mst_Inf_RNKMTA.DATKB <> gc_strDATKB_USE Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    '仕切率取得
	''    Pot_curSIKRT = Mst_Inf_RNKMTA.SIKRT
	''
	''    '単価取得
	''    Pot_curTANKA = AE_Calc_TANKA(Pot_curSIKRT, _
	'''                                 Mst_Inf_HINMTA.TEIKATK, _
	'''                                 Mst_Inf_TOKMTA.TKNRPSKB, _
	'''                                 Mst_Inf_TOKMTA.TKNZRNKB)
	'
	'    AE_Get_TANKA = 0
	'
	'    Exit Function
	'
	'AE_Get_TANKA_ERR:
	'
	'End Function
	' === 20060829 === DELETE E -
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Get_SysDt
	'//*
	'//* <戻り値>     型          説明
	'//*              Boolean     True:正常 / False:異常
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*
	'//* <説  明>
	'//*    DBサーバーの日付(西暦)を取得する。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20041016|ACE)Moriga     |新規作成
	'//**************************************************************************************
	Public Function CF_Get_SysDt() As Boolean
		
		On Error GoTo ERR_HANDLE
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim Str_Val As String
		Dim Lng_Cnt As Integer
		Dim Lng_Idx As Integer
		Dim Str_SysDt As String
		
		CF_Get_SysDt = False
		
		'// 初期化
		GV_SysDate = ""
		GV_SysTime = ""
		Str_SysDt = ""
		
		Str_Sql = ""
		Str_Sql = Str_Sql & "SELECT"
		Str_Sql = Str_Sql & "       To_Char(sysdate,'YYYYMMDDHH24MISS') AAA "
		Str_Sql = Str_Sql & "FROM"
		Str_Sql = Str_Sql & "       Dual "
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo ERR_HANDLE
		End If
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Str_SysDt = Trim(CF_Ora_GetDyn(Usr_Ody, "AAA"))
		
		GV_SysDate = Mid(Str_SysDt, 1, 8)
		GV_SysTime = Mid(Str_SysDt, 9, 6)
		
		CF_Get_SysDt = True
		
EXIT_HANDLE: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Get_UnyDt
	'//*
	'//* <戻り値>     型          説明
	'//*              Boolean     True:正常 / False:異常
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*
	'//* <説  明>
	'//*    運用日付(西暦)を取得する。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20060706|ACE)Nagasawa   |新規作成
	'//**************************************************************************************
	Public Function CF_Get_UnyDt() As Boolean
		
		Dim intRet As Short
		Dim Mst_Inf As TYPE_DB_UNYMTA
		
		CF_Get_UnyDt = False
		
		'初期化
		GV_UNYDate = ""
		
		'サーバーのシステム日付取得
		Call CF_Get_SysDt()
		
		'運用日付を取得
		intRet = DSPUNYDT_SEARCH(Mst_Inf)
		If intRet = 0 Then
			GV_UNYDate = Mst_Inf.UNYDT
		Else
			GV_UNYDate = GV_SysDate
		End If
		
		CF_Get_UnyDt = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_PRC_UODFP53
	'   概要：  PL/SQL実行処理(自動発注処理)
	'   引数：　Pin_strPRCCASE  : 処理ケース（"1":登録 "2":訂正 "3": 削除）
	'           Pin_strJDNNO    : 受注番号
	'           Pin_strLINNO    : 行番号
	'           Pin_strSBNNO    : 製番
	'           Pin_strHINCD    : 商品コード
	'           Pin_lngBFRSU    : 変更前受注数量（登録の場合はゼロ）
	'           Pin_lngAFTSU    : 変更後受注数量（削除の場合はゼロ）
	'           Pin_strZAIRNK   : 在庫ランク
	'           Pin_lngBFRSU    : 変更前出荷予定日（登録、削除の場合は設定なし）
	'           Pin_lngAFTSU    : 変更後出荷予定日（登録、削除の場合は設定なし）
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：  自動発注処理PL/SQL(PRC_UODFP53_01)を実行する
	'           ただし、変更前受注数量＝変更後受注数量の場合は実行しない
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061102 === UPDATE S - ACE)Nagasawa 自動発注処理の呼び出し条件の追加
	'Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String _
	''                                           , ByVal pin_strJDNNO As String _
	''                                           , ByVal pin_strLINNO As String _
	''                                           , ByVal pin_strSBNNO As String _
	''                                           , ByVal pin_strHINCD As String _
	''                                           , ByVal Pin_lngBFRSU As Currency _
	''                                           , ByVal Pin_lngAFTSU As Currency _
	''                                           , Optional ByVal Pin_strBFRSYK As String = "" _
	''                                           , Optional ByVal Pin_strAFTSYK As String = "") As Integer
	Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String, ByVal pin_strJDNNO As String, ByVal pin_strLINNO As String, ByVal pin_strSBNNO As String, ByVal pin_strHINCD As String, ByVal Pin_lngBFRSU As Decimal, ByVal Pin_lngAFTSU As Decimal, ByVal Pin_strZAIRNK As String, Optional ByVal Pin_strBFRSYK As String = "", Optional ByVal Pin_strAFTSYK As String = "") As Short
		' === 20061102 === UPDATE E -
		
		Dim strSQL As String 'SQL文
		Dim strPara1 As String 'ﾊﾟﾗﾒｰﾀ1(担当者コード)
		Dim strPara2 As String 'ﾊﾟﾗﾒｰﾀ2(クライアントID)
		Dim strPara3 As String 'ﾊﾟﾗﾒｰﾀ3(処理ケース)
		Dim strPara4 As String 'ﾊﾟﾗﾒｰﾀ4(受注番号)
		Dim strPara5 As String 'ﾊﾟﾗﾒｰﾀ5(行番号)
		Dim strPara6 As String 'ﾊﾟﾗﾒｰﾀ6(製番)
		Dim strPara7 As String 'ﾊﾟﾗﾒｰﾀ7(製品コード)
		Dim lngPara8 As Integer 'ﾊﾟﾗﾒｰﾀ8(変更前受注数量)
		Dim lngPara9 As Integer 'ﾊﾟﾗﾒｰﾀ9(変更後受注数量)
		Dim lngPara10 As Integer 'ﾊﾟﾗﾒｰﾀ10(復帰ｺｰﾄﾞ)
		Dim lngPara11 As Integer 'ﾊﾟﾗﾒｰﾀ11(ｴﾗｰｺｰﾄﾞ)
		Dim strPara12 As New VB6.FixedLengthString(1000) 'ﾊﾟﾗﾒｰﾀ12(ｴﾗｰ内容)
		Dim lngPara13 As Integer 'ﾊﾟﾗﾒｰﾀ13(読込件数)
		Dim lngPara14 As Integer 'ﾊﾟﾗﾒｰﾀ14(登録件数)
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(15) As OraParameter 'PL/SQLのバインド変数
		Dim bolRet As Boolean
		' === 20061102 === INSERT S - ACE)Nagasawa 自動発注処理の呼び出し条件の追加
		Dim Mst_Inf As TYPE_DB_MEIMTA
		Dim bolExit As Boolean
		' === 20061102 === INSERT E -
		
		AE_Execute_PLSQL_PRC_UODFP53 = 9
		
		'''' DEL 2009/09/16  FKS) T.Yamamoto    Start    連絡票№385
		'受注数量、出荷予定日に変更がなくても自動発注処理を呼び出す
		'' === 20060824 === UPDATE S - ACE)Nagasawa 納期変更時も自動発注処理を呼び出す
		''    '変更前受注数量＝変更後受注数量の場合は処理終了
		''    If Pin_lngBFRSU = Pin_lngAFTSU Then
		''        AE_Execute_PLSQL_PRC_UODFP53 = 0
		''        Exit Function
		''    End If
		'
		'    '変更前受注数量＝変更後受注数量、変更前出荷予定日＝変更後出荷予定日の場合は処理終了
		'    If Pin_lngBFRSU = Pin_lngAFTSU _
		''    And Pin_strBFRSYK = Pin_strAFTSYK Then
		'        AE_Execute_PLSQL_PRC_UODFP53 = 0
		'        Exit Function
		'    End If
		'' === 20060824 === UPDATE E -
		'''' DEL 2009/09/16  FKS) T.Yamamoto    End
		
		' === 20061102 === INSERT S - ACE)Nagasawa 自動発注処理の呼び出し条件の追加
		bolExit = True
		Call DB_MEIMTA_Clear(Mst_Inf)
		If DSPMEIM_SEARCH(gc_strKEYCD_ZAIRNK, Pin_strZAIRNK, Mst_Inf) = 0 Then
			If Mst_Inf.DATKB = gc_strDATKB_USE Then
				If Mst_Inf.MEIKBA = gc_strJDNSEISAN_OK Then
					bolExit = False
				End If
			End If
		End If
		
		'受注生産対象品以外は処理を行わない
		If bolExit = True Then
			AE_Execute_PLSQL_PRC_UODFP53 = 0
			Exit Function
		End If
		' === 20061102 === INSERT E -
		
		'受渡し変数初期設定
		strPara1 = SSS_OPEID.Value
		strPara2 = SSS_CLTID.Value
		strPara3 = Pin_strPRCCASE
		strPara4 = pin_strJDNNO
		strPara5 = pin_strLINNO
		strPara6 = pin_strSBNNO
		strPara7 = pin_strHINCD
		lngPara8 = Pin_lngBFRSU
		lngPara9 = Pin_lngAFTSU
		lngPara10 = 0
		lngPara11 = 0
		strPara12.Value = ""
		lngPara13 = 0
		lngPara14 = 0
		
		'パラメータの初期設定を行う（バインド変数）
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P5", strPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P7", strPara7, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P9", lngPara9, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P12", strPara12.Value, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P13", lngPara13, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P14", lngPara14, ORAPARM_OUTPUT)
		
		'データ型をオブジェクトにセット
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11) = gv_Odb_USR1.Parameters("P11")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(12) = gv_Odb_USR1.Parameters("P12")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(13) = gv_Odb_USR1.Parameters("P13")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(14) = gv_Odb_USR1.Parameters("P14")
		
		'各オブジェクトのデータ型を設定
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(12).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(13).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(14).serverType = ORATYPE_NUMBER
		
		'PL/SQL呼び出しSQL
		strSQL = "BEGIN PRC_UODFP53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12,:P13,:P14); End;"
		
		'DBアクセス
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_PRC_UODFP53_END
		End If
		
		'** 戻り値取得
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara10 = param(10).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara11 = param(11).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(param(12).Value) = False Then
			'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strPara12.Value = param(12).Value
		End If
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara13 = param(13).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara14 = param(14).Value
		
		'エラー情報設定
		gv_Int_OraErr = lngPara11
		gv_Str_OraErrText = Trim(strPara12.Value) & vbCrLf
		
		AE_Execute_PLSQL_PRC_UODFP53 = lngPara10
		
AE_Execute_PLSQL_PRC_UODFP53_END: 
		'** パラメタ解消
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P11")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P12")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P13")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P14")
		
	End Function
	
	' === 20060828 === INSERT S - ACE)Sejima
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_TKCHGKB
	'   概要：  権限情報取得
	'   引数：　pin_DB_TANMTA  : 担当者マスタ情報
	'           pin_strUnyDate : 運用日付
	'   戻値：　権限グループ
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_KNG_Inf(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, ByVal pin_strUnyDate As String, ByRef Inp_Inf As Cmn_Inp_Inf) As Short
		
		Dim Mst_Inf_KNGMTA As TYPE_DB_KNGMTA
		Dim strKNGGRCD As String
		
		'初期化
		With Inp_Inf
			'いったん、権限なしとする
			.InpTKCHGKB = gc_strTKCHGKB_NG
			.InpJDNUPDKB = gc_strJDNUPDKB_NG
		End With
		
		'権限グループ取得
		strKNGGRCD = F_Get_KNGGRCD(pin_DB_TANMTA, pin_strUnyDate)
		
		If Trim(strKNGGRCD) <> "" Then
			'権限グループが取得できた場合、権限マスタを検索
			Call DB_KNGMTA_Clear(Mst_Inf_KNGMTA)
			If KNGMTA_SEARCH(strKNGGRCD, Mst_Inf_KNGMTA) = 0 Then
				With Inp_Inf
					'単価変更権限
					.InpTKCHGKB = Mst_Inf_KNGMTA.SALTKKB
					'受注更新権限
					.InpJDNUPDKB = Mst_Inf_KNGMTA.JDNUPDKB
				End With
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_KNGGRCD
	'   概要：  権限グループ取得
	'   引数：　pin_DB_TANMTA  : 担当者マスタ情報
	'           pin_strDate    : 運用日付
	'   戻値：　権限グループ
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_KNGGRCD(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, ByRef pin_strDate As String) As String
		
		Dim bolTANTKDT As Boolean '適用日判定フラグ（True：適用日＜＝運用日）
		Dim intWk As Short
		Dim Ret_Value As String
		
		'初期化
		bolTANTKDT = False
		Ret_Value = ""
		intWk = 0
		
		With pin_DB_TANMTA
			
			'権限グループ設定あり
			If Trim(.KNGGRCD) <> "" Then
				intWk = intWk + mc_intCD
			End If
			
			'旧権限グループ設定あり
			If Trim(.OLDGRCD) <> "" Then
				intWk = intWk + mc_intOLDCD
			End If
			
			'適用日設定あり
			If Trim(.TANTKDT) <> "" Then
				intWk = intWk + mc_intTKDT
				'適用日判定
				If Trim(.TANTKDT) <= pin_strDate Then
					bolTANTKDT = True
				End If
			End If
			
			'権限グループ、旧権限グループ、適用日の設定有無に応じて判定を行う。
			'（2^3の8ﾊﾟﾀｰﾝ）
			Select Case intWk
				Case mc_intCD + mc_intOLDCD + mc_intTKDT
					'①権限グループ、旧権限グループ、適用日の設定あり
					If bolTANTKDT = True Then
						Ret_Value = Trim(.KNGGRCD)
					Else
						Ret_Value = Trim(.OLDGRCD)
					End If
					
				Case mc_intCD + mc_intOLDCD
					'②権限グループ、旧権限グループの設定あり
					Ret_Value = Trim(.KNGGRCD)
					
				Case mc_intCD + mc_intTKDT
					'③権限グループ、適用日の設定あり
					If bolTANTKDT = True Then
						Ret_Value = Trim(.KNGGRCD)
					Else
						Ret_Value = Trim(.OLDGRCD)
					End If
					
				Case mc_intOLDCD + mc_intTKDT
					'④旧権限グループ、適用日の設定あり
					If bolTANTKDT = True Then
						Ret_Value = Trim(.KNGGRCD)
					Else
						Ret_Value = Trim(.OLDGRCD)
					End If
					
				Case mc_intCD
					'⑤権限グループの設定あり
					Ret_Value = Trim(.KNGGRCD)
					
				Case mc_intOLDCD
					'⑥旧権限グループの設定あり
					
				Case mc_intTKDT
					'⑦適用日の設定あり
					
				Case Else
					'⑧いずれも設定なし
					
			End Select
			
		End With
		
		F_Get_KNGGRCD = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_TANBMNCD
	'   概要：  所属部門コード取得
	'   引数：　pin_DB_TANMTA  : 担当者マスタ情報
	'           pin_strDate : 運用日付
	'   戻値：　所属部門コード
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANBMNCD(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, ByRef pin_strDate As String) As String
		
		Dim bolTANTKDT As Boolean '適用日判定フラグ（True：適用日＜＝基準日）
		Dim intWk As Short
		Dim Ret_Value As String
		
		'初期化
		bolTANTKDT = False
		Ret_Value = ""
		intWk = 0
		
		With pin_DB_TANMTA
			'所属部門コード設定あり
			If Trim(.TANBMNCD) <> "" Then
				intWk = intWk + mc_intCD
			End If
			'旧所属部門コード設定あり
			If Trim(.OLDBMNCD) <> "" Then
				intWk = intWk + mc_intOLDCD
			End If
			
			'適用日設定あり
			If Trim(.TANTKDT) <> "" Then
				intWk = intWk + mc_intTKDT
				'適用日判定
				If Trim(.TANTKDT) <= pin_strDate Then
					bolTANTKDT = True
				End If
			End If
			
			'所属部門コード、旧所属部門コード、適用日の設定有無に応じて判定を行う。
			'（2^3の8ﾊﾟﾀｰﾝ）
			Select Case intWk
				Case mc_intCD + mc_intOLDCD + mc_intTKDT
					'①所属部門コード、旧所属部門コード、適用日の設定あり
					If bolTANTKDT = True Then
						Ret_Value = Trim(.TANBMNCD)
					Else
						Ret_Value = Trim(.OLDBMNCD)
					End If
					
				Case mc_intCD + mc_intOLDCD
					'②所属部門コード、旧所属部門コードの設定あり
					Ret_Value = Trim(.TANBMNCD)
					
				Case mc_intCD + mc_intTKDT
					'③所属部門コード、適用日の設定あり
					If bolTANTKDT = True Then
						Ret_Value = Trim(.TANBMNCD)
					Else
						Ret_Value = Trim(.OLDBMNCD)
					End If
					
				Case mc_intOLDCD + mc_intTKDT
					'④旧所属部門コード、適用日の設定あり
					If bolTANTKDT = True Then
						Ret_Value = Trim(.TANBMNCD)
					Else
						Ret_Value = Trim(.OLDBMNCD)
					End If
					
				Case mc_intCD
					'⑤所属部門コードの設定あり
					Ret_Value = Trim(.TANBMNCD)
					
				Case mc_intOLDCD
					'⑥旧所属部門コードの設定あり
					
				Case mc_intTKDT
					'⑦適用日の設定あり
					
				Case Else
					'⑧いずれも設定なし
					
			End Select
			
		End With
		
		CF_Get_TANBMNCD = Ret_Value
		
	End Function
	' === 20060828 === INSERT E
	
	' === 20060829 === INSERT S - ACE)Nagasawa 赤黒伝票が発生する場合は警告を表示する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_UpdateJDN_Chk
	'   概要：  受注訂正チェック
	'   引数：  pin_strKJNDT    : 判定基準日（受注日）
	'           pin_strTOKCD  　: 得意先コード
	'   戻値：  0：正常　1: 月次仮締日過ぎ　2: 請求締日過ぎ　9: 異常
	'   備考：  得意先マスタ.請求締日、ユーザー情報管理テーブル.月次仮締日を見て
	'　　　　　 受注訂正が可能かどうかの判断を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_UpdateJDN_Chk(ByVal pin_strKJNDT As String, ByVal pin_strTOKCD As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Mst_Inf_SYSTBA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		Dim intRet As Short
		
		AE_UpdateJDN_Chk = 9
		
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'ユーザー情報管理テーブル検索
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			Exit Function
		End If
		
		'基準日と月次仮締日の比較
		If Trim(Mst_Inf_SYSTBA.UKSMEDT) <> "" Then
			If CF_Ora_Date(pin_strKJNDT) <= Mst_Inf_SYSTBA.UKSMEDT Then
				AE_UpdateJDN_Chk = 1
				Exit Function
			End If
		End If
		
		Call DB_TOKMTA_Clear(Mst_Inf_TOKMTA)
		
		' === 20061026 === DELETE S - ACE)Nagasawa 請求締のチェックは行わない
		'    '得意先マスタ検索
		'    If DSPTOKCD_SEARCH(pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
		'        Exit Function
		'    End If
		'
		'    '基準日と請求締日の比較
		'    If Trim(Mst_Inf_TOKMTA.TOKSMEDT) <> "" Then
		'        If CF_Ora_Date(pin_strKJNDT) <= Mst_Inf_TOKMTA.TOKSMEDT Then
		'            AE_UpdateJDN_Chk = 2
		'            Exit Function
		'        End If
		'    End If
		' === 20061026 === DELETE E -
		
		AE_UpdateJDN_Chk = 0
		
	End Function
	' === 20060829 === INSERT E -
	
	' === 20060830 === INSERT S - ACE)Nagasawa 権限の取得は画面の日付を基準に行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_INPTANCD_Inf
	'   概要：  入力担当者情報取得処理
	'   引数：  pin_strTANCD    : 担当者コード
	'           pot_Inp_Inf     : 取得結果入力担当者情報
	'           pin_strKJNDT    : 判定基準日（省略された場合は運用日とする）
	'   戻値：  0：正常　9: 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function F_Get_INPTANCD_Inf(ByVal pin_strTANCD As String, ByRef pot_Inp_Inf As Cmn_Inp_Inf, Optional ByVal pin_strKJNDT As String = "") As Short
		
		Dim Mst_Inf_TANMTA As TYPE_DB_TANMTA
		Dim intRet As Short
		Dim strKJNDT As String
		' === 20061030 === INSERT S - ACE)Nagasawa 権限の読み方の変更
		Dim strRet As String
		' === 20061030 === INSERT E -
		
		F_Get_INPTANCD_Inf = 9
		
		'基準日が省略された場合は運用日を使用する
		If Trim(pin_strKJNDT) = "" Then
			strKJNDT = GV_UNYDate
		Else
			strKJNDT = CF_Ora_Date(pin_strKJNDT)
		End If
		
		'担当者マスタ検索
		Call DB_TANMTA_Clear(Mst_Inf_TANMTA)
		intRet = DSPTANCD_SEARCH(pin_strTANCD, Mst_Inf_TANMTA)
		If intRet = 0 Then
			pot_Inp_Inf.InpTanNm = Mst_Inf_TANMTA.TANNM '入力担当者名
			' === 20061030 === UPDATE S - ACE)Nagasawa 権限の読み方の変更
			'        '権限情報取得（単価変更権限、受注更新権限、etc...）
			'        Call F_Get_KNG_Inf(Mst_Inf_TANMTA, strKJNDT, pot_Inp_Inf)
			'    End If
		End If
		
		'初期化
		With Inp_Inf
			'いったん、権限なしとする
			.InpTKCHGKB = gc_strTKCHGKB_NG '販売単価変更権限
			.InpJDNUPDKB = gc_strJDNUPDKB_NG '更新権限
			.InpPRTAUTH = gc_strJDNUPDKB_NG '印刷権限
			.InpFILEAUTH = gc_strJDNUPDKB_NG 'ファイル出力権限
		End With
		
		'権限取得ロジックへの引数セット
		gs_userid = pin_strTANCD '入力担当者ID
		gs_pgid = SSS_PrgId 'プログラムID
		
		'権限取得
		strRet = Get_Authority(strKJNDT)
		
		'取得された権限セット
		With Inp_Inf
			.InpTKCHGKB = gs_SALTAUTH '販売単価変更権限
			.InpJDNUPDKB = gs_UPDAUTH '更新権限
			.InpPRTAUTH = gs_PRTAUTH '印刷権限
			.InpFILEAUTH = gs_FILEAUTH 'ファイル出力権限
		End With
		' === 20061030 === UPDATE E -
		
		F_Get_INPTANCD_Inf = 0
		
	End Function
	' === 20060830 === INSERT E -
	
	' === 20060905 === INSERT S - ACE)Hashiri 赤伝票を作成
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_AKADEN_INSERT
	'   概要：  赤伝票作成処理
	'   引数：  pin_strDATNO        : 伝票管理№
	'           pin_strMOTODATNO  　: 元伝票管理№
	'           pin_strOPEID  　    : 最終作業者コード
	'           pin_strCLTID      　: クライアントＩＤ
	'           pin_strJODCNKB    　: 受注キャンセル理由区分
	'           pin_strJDNDT      　: 受注伝票日付(省略された場合、運用日)
	'   戻値：  0：正常　9: 異常
	'   備考：  パラメータの値を元に赤伝票を作成する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061108 === UPDATE S - ACE)Nagasawa
	'Public Function AE_AKADEN_INSERT(ByVal pin_strDATNO As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJODCNKB As String) As Integer
	Public Function AE_AKADEN_INSERT(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strJODCNKB As String, Optional ByVal pin_strJDNDT As String = "") As Short
		' === 200611018 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		' === 20061119 === INSERT S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
		Dim strDLFLG As String
		' === 20061119 === INSERT E -
		
		On Error GoTo AE_AKADEN_INSERT_err
		
		AE_AKADEN_INSERT = 9
		
		If Trim(pin_strJDNDT) = "" Then
			pin_strJDNDT = GV_UNYDate
		End If
		
		' === 20061119 === INSERT S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
		'削除フラグ編集
		strDLFLG = ""
		If Trim(pin_strJODCNKB) <> "" Then
			strDLFLG = gc_strDLFLG_DEL
		Else
			strDLFLG = gc_strDLFLG_UPD
		End If
		' === 20061119 === INSERT E -
		
		'受注見出しトラン追加ＳＱＬ
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = AE_AKADEN_JDNTHA_SQL(pin_strDATNO, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID, pin_strJODCNKB)
		' === 20061119 === UPDATE S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
		'    strSQL = AE_AKADEN_JDNTHA_SQL(pin_strDatNo, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID, pin_strJODCNKB, pin_strJDNDT)
		strSQL = AE_AKADEN_JDNTHA_SQL(pin_strDatNo, pin_strMotoDatNo, pin_strOPEID, pin_strCLTID, pin_strJODCNKB, strDLFLG, pin_strJDNDT)
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_AKADEN_INSERT_err
		End If
		
		'受注トラン追加ＳＱＬ
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = AE_AKADEN_JDNTRA_SQL(pin_strDATNO, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID)
		' === 20061119 === UPDATE S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
		'    strSQL = AE_AKADEN_JDNTRA_SQL(pin_strDatNo, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID, pin_strJDNDT)
		strSQL = AE_AKADEN_JDNTRA_SQL(pin_strDatNo, pin_strMotoDatNo, pin_strOPEID, pin_strCLTID, strDLFLG, pin_strJDNDT)
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_AKADEN_INSERT_err
		End If
		
		AE_AKADEN_INSERT = 0
		
AE_AKADEN_INSERT_err: 
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_AKADEN_JDNTHA_SQL
	'   概要：  赤伝票作成処理_受注見出しトランSQL文作成
	'   引数：  pin_strDATNO        : 伝票管理№
	'           pin_strMOTODATNO  　: 元伝票管理№
	'           pin_strOPEID  　    : 最終作業者コード
	'           pin_strCLTID      　: クライアントＩＤ
	'           pin_strJODCNKB    　: 受注キャンセル理由区分
	'           pin_strDLFLG        : 削除フラグ
	'           pin_strJDNDT        : 受注伝票日付
	'   戻値：  SQL文字列
	'   備考：  受注トランINSERT文の作成
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061108 === UPDATE S - ACE)Nagasawa
	'Private Function AE_AKADEN_JDNTHA_SQL(ByVal pin_strDATNO As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJODCNKB As String) As String
	' === 20061119 === UPDATE S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
	'Private Function AE_AKADEN_JDNTHA_SQL(ByVal pin_strDatNo As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJODCNKB As String, _
	''                          ByVal pin_strJDNDT As String) As String
	Private Function AE_AKADEN_JDNTHA_SQL(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strJODCNKB As String, ByVal pin_strDLFLG As String, ByVal pin_strJDNDT As String) As String
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		Dim strSQL As String
		' === 20070325 === INSERT S - ACE)Nagasawa 赤伝票も締日付更新
		Dim strSMADT As String
		
		'経理締日付算出
		Call AE_GetKRSMADT(pin_strJDNDT, strSMADT)
		' === 20070325 === INSERT E -
		
		strSQL = ""
		strSQL = strSQL & " Insert into JDNTHA "
		strSQL = strSQL & "        ( DATNO " '伝票管理№
		strSQL = strSQL & "        , DATKB " '伝票削除区分
		strSQL = strSQL & "        , AKAKROKB " '赤黒区分
		strSQL = strSQL & "        , DENKB " '伝票区分
		strSQL = strSQL & "        , JDNNO " '受注番号
		strSQL = strSQL & "        , JHDNO " '受発注№
		strSQL = strSQL & "        , JDNDT " '受注伝票日付
		strSQL = strSQL & "        , DENDT " '受注日付
		strSQL = strSQL & "        , REGDT " '初回伝票日付
		strSQL = strSQL & "        , DEFNOKDT " '納期
		strSQL = strSQL & "        , TOKCD " '得意先コード
		strSQL = strSQL & "        , TOKRN " '得意先略称
		strSQL = strSQL & "        , NHSCD " '納入先コード
		strSQL = strSQL & "        , NHSNMA " '納入先名称１
		strSQL = strSQL & "        , NHSNMB " '納入先名称２
		strSQL = strSQL & "        , TANCD " '担当者コード
		strSQL = strSQL & "        , TANNM " '担当者名
		strSQL = strSQL & "        , BUMCD " '部門コード
		strSQL = strSQL & "        , BUMNM " '部門名
		strSQL = strSQL & "        , TOKSEICD " '請求先コード
		strSQL = strSQL & "        , SOUCD " '倉庫コード
		strSQL = strSQL & "        , SOUNM " '倉庫名
		strSQL = strSQL & "        , ZKTKB " '取引区分
		strSQL = strSQL & "        , ZKTNM " '取引区分名
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , JDNENDKB " '受注完了区分
		strSQL = strSQL & "        , SBAUODKN " '受注金額（本体合計）
		strSQL = strSQL & "        , SBAUZEKN " '受注金額（消費税額）
		strSQL = strSQL & "        , SBAUZKKN " '受注金額（伝票計）
		strSQL = strSQL & "        , DENCM " '備考
		strSQL = strSQL & "        , TOKSMEKB " '締区分
		strSQL = strSQL & "        , TOKSMEDD " '締初期日付（売上）
		strSQL = strSQL & "        , TOKSMECC " '締サイクル（売上）
		strSQL = strSQL & "        , TOKSDWKB " '締め曜日
		strSQL = strSQL & "        , TOKKESCC " '回収サイクル
		strSQL = strSQL & "        , TOKKESDD " '回収日付
		strSQL = strSQL & "        , TOKKDWKB " '回収曜日
		strSQL = strSQL & "        , LSTID " '伝票種別
		strSQL = strSQL & "        , TKNRPSKB " '金額端数処理桁数
		strSQL = strSQL & "        , TKNZRNKB " '金額端数処理区分
		strSQL = strSQL & "        , TOKZEIKB " '消費税区分
		strSQL = strSQL & "        , TOKZCLKB " '消費税算出区分
		strSQL = strSQL & "        , TOKRPSKB " '消費税端数処理桁数
		strSQL = strSQL & "        , TOKZRNKB " '消費税端数処理区分
		strSQL = strSQL & "        , TOKNMMKB " '名称ﾏﾆｭｱﾙ区分（得）
		strSQL = strSQL & "        , NHSNMMKB " '名称ﾏﾆｭｱﾙ区分（納）
		strSQL = strSQL & "        , TOKMSTKB " 'マスタ区分（得意先）
		strSQL = strSQL & "        , NHSMSTKB " 'マスタ区分（納入先）
		strSQL = strSQL & "        , TANMSTKB " 'マスタ区分（担当者）
		strSQL = strSQL & "        , MITNO " '見積番号
		strSQL = strSQL & "        , MITNOV " '版数
		strSQL = strSQL & "        , AKNID " '案件ＩＤ
		strSQL = strSQL & "        , CLMDL " '分類型式
		strSQL = strSQL & "        , URIKJN " '売上基準
		strSQL = strSQL & "        , BINCD " '便名コード
		strSQL = strSQL & "        , KENNMA " '件名１
		strSQL = strSQL & "        , KENNMB " '件名２
		strSQL = strSQL & "        , BKTHKKB " '分割不可区分
		strSQL = strSQL & "        , MAEUKKB " '前受区分
		strSQL = strSQL & "        , SEIKB " '請求区分
		strSQL = strSQL & "        , JDNTRKB " '受注取引区分
		strSQL = strSQL & "        , NHSADA " '納入先住所１
		strSQL = strSQL & "        , NHSADB " '納入先住所２
		strSQL = strSQL & "        , NHSADC " '納入先住所３
		strSQL = strSQL & "        , JDNINKB " '受注取込種別
		strSQL = strSQL & "        , DFKJDNNO " 'ダイフク受注番号
		strSQL = strSQL & "        , TOKJDNNO " '客先注文No.
		strSQL = strSQL & "        , HDKEIKN " 'ハード契約金額
		strSQL = strSQL & "        , HDSIKKN " 'ハード仕切金額
		strSQL = strSQL & "        , SFKEIKN " 'ソフト契約金額
		strSQL = strSQL & "        , SFSIKKN " 'ソフト仕切金額
		strSQL = strSQL & "        , CMPKTCD " 'コンピュータ型式コード
		strSQL = strSQL & "        , CMPKTNM " 'コンピュータ型式名
		strSQL = strSQL & "        , PRDTBMCD " '生産担当部門コード
		strSQL = strSQL & "        , TUKKB " '通貨区分
		strSQL = strSQL & "        , SBAFRCKN " '外貨受注金額（伝票計）
		strSQL = strSQL & "        , JODRSNKB " '受注理由区分
		strSQL = strSQL & "        , JODCNKB " '受注キャンセル理由区分
		strSQL = strSQL & "        , FRNKB " '海外取引区分
		strSQL = strSQL & "        , SIMUKE " '仕向地
		strSQL = strSQL & "        , JDNPRKB " '発行区分
		strSQL = strSQL & "        , DENCMIN " '社内備考
		strSQL = strSQL & "        , SETUPKB " 'セットアップシート取込区分
		strSQL = strSQL & "        , MOTDATNO " '元伝票管理番号
		' === 20061119 === UPDATE S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
		'    strSQL = strSQL & "        , OPEID "           '最終作業者コード
		'    strSQL = strSQL & "        , CLTID "           'クライアントＩＤ
		'    strSQL = strSQL & "        , WRTTM "           'タイムスタンプ（時間）
		'    strSQL = strSQL & "        , WRTDT "           'タイムスタンプ（日付）
		'    strSQL = strSQL & "        , WRTFSTTM "        'タイムスタンプ（登録時間）
		'    strSQL = strSQL & "        , WRTFSTDT "        'タイムスタンプ（登録日）
		strSQL = strSQL & "        , FOPEID " '初回登録ユーザーＩＤ
		strSQL = strSQL & "        , FCLTID " '初回登録クライアントＩＤ
		strSQL = strSQL & "        , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "        , WRTFSTDT " 'タイムスタンプ（登録日）
		strSQL = strSQL & "        , OPEID " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "        , CLTID " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "        , WRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "        , WRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "        , UOPEID " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "        , UCLTID " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "        , UWRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "        , UWRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "        , PGID " 'ＰＧＩＤ
		strSQL = strSQL & "        , DLFLG " '削除フラグ
		' === 20061119 === UPDATE E -
		strSQL = strSQL & "        , JDNENDNM " '受注完了区分名
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " Select "
		strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "        ,  DATKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
		strSQL = strSQL & "        ,  DENKB "
		strSQL = strSQL & "        ,  JDNNO "
		strSQL = strSQL & "        ,  JHDNO "
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  JDNDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(pin_strJDNDT) & "'"
		' === 20061108 === UPDATE E -
		strSQL = strSQL & "        ,  DENDT "
		strSQL = strSQL & "        ,  REGDT "
		strSQL = strSQL & "        ,  DEFNOKDT "
		strSQL = strSQL & "        ,  TOKCD "
		strSQL = strSQL & "        ,  TOKRN "
		strSQL = strSQL & "        ,  NHSCD "
		strSQL = strSQL & "        ,  NHSNMA "
		strSQL = strSQL & "        ,  NHSNMB "
		strSQL = strSQL & "        ,  TANCD "
		strSQL = strSQL & "        ,  TANNM "
		strSQL = strSQL & "        ,  BUMCD "
		strSQL = strSQL & "        ,  BUMNM "
		strSQL = strSQL & "        ,  TOKSEICD "
		strSQL = strSQL & "        ,  SOUCD "
		strSQL = strSQL & "        ,  SOUNM "
		strSQL = strSQL & "        ,  ZKTKB "
		strSQL = strSQL & "        ,  ZKTNM "
		' === 20070325 === UPDATE S - ACE)Nagasawa 赤伝票も締日付更新
		'    strSQL = strSQL & "        ,  SMADT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(strSMADT) & "' "
		' === 20070325 === UPDATE E -
		strSQL = strSQL & "        ,  JDNENDKB "
		strSQL = strSQL & "        ,  SBAUODKN * (-1) "
		strSQL = strSQL & "        ,  SBAUZEKN * (-1) "
		strSQL = strSQL & "        ,  SBAUZKKN * (-1) "
		strSQL = strSQL & "        ,  DENCM "
		strSQL = strSQL & "        ,  TOKSMEKB "
		strSQL = strSQL & "        ,  TOKSMEDD "
		strSQL = strSQL & "        ,  TOKSMECC "
		strSQL = strSQL & "        ,  TOKSDWKB "
		strSQL = strSQL & "        ,  TOKKESCC "
		strSQL = strSQL & "        ,  TOKKESDD "
		strSQL = strSQL & "        ,  TOKKDWKB "
		strSQL = strSQL & "        ,  LSTID "
		strSQL = strSQL & "        ,  TKNRPSKB "
		strSQL = strSQL & "        ,  TKNZRNKB "
		strSQL = strSQL & "        ,  TOKZEIKB "
		strSQL = strSQL & "        ,  TOKZCLKB "
		strSQL = strSQL & "        ,  TOKRPSKB "
		strSQL = strSQL & "        ,  TOKZRNKB "
		strSQL = strSQL & "        ,  TOKNMMKB "
		strSQL = strSQL & "        ,  NHSNMMKB "
		strSQL = strSQL & "        ,  TOKMSTKB "
		strSQL = strSQL & "        ,  NHSMSTKB "
		strSQL = strSQL & "        ,  TANMSTKB "
		strSQL = strSQL & "        ,  MITNO "
		strSQL = strSQL & "        ,  MITNOV "
		strSQL = strSQL & "        ,  AKNID "
		strSQL = strSQL & "        ,  CLMDL "
		strSQL = strSQL & "        ,  URIKJN "
		strSQL = strSQL & "        ,  BINCD "
		strSQL = strSQL & "        ,  KENNMA "
		strSQL = strSQL & "        ,  KENNMB "
		strSQL = strSQL & "        ,  BKTHKKB "
		strSQL = strSQL & "        ,  MAEUKKB "
		strSQL = strSQL & "        ,  SEIKB "
		strSQL = strSQL & "        ,  JDNTRKB "
		strSQL = strSQL & "        ,  NHSADA "
		strSQL = strSQL & "        ,  NHSADB "
		strSQL = strSQL & "        ,  NHSADC "
		strSQL = strSQL & "        ,  JDNINKB "
		strSQL = strSQL & "        ,  DFKJDNNO "
		strSQL = strSQL & "        ,  TOKJDNNO "
		strSQL = strSQL & "        ,  HDKEIKN * (-1) "
		strSQL = strSQL & "        ,  HDSIKKN * (-1) "
		strSQL = strSQL & "        ,  SFKEIKN * (-1) "
		strSQL = strSQL & "        ,  SFSIKKN * (-1) "
		strSQL = strSQL & "        ,  CMPKTCD "
		strSQL = strSQL & "        ,  CMPKTNM "
		strSQL = strSQL & "        ,  PRDTBMCD "
		strSQL = strSQL & "        ,  TUKKB "
		' === 20060107 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  SBAFRCKN "
		strSQL = strSQL & "        ,  SBAFRCKN * (-1) "
		' === 20060107 === UPDATE E -
		strSQL = strSQL & "        ,  JODRSNKB "
		'削除の場合は受注ｷｬﾝｾﾙ区分を編集
		If Trim(pin_strJODCNKB) = "" Then
			strSQL = strSQL & "        ,  JODCNKB "
		Else
			strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strJODCNKB, 3) & "' "
		End If
		strSQL = strSQL & "        ,  FRNKB "
		strSQL = strSQL & "        ,  SIMUKE "
		' === 20061219 === UPDATE S - ACE)Nagasawa 発行区分は「未発行」に戻す
		'    strSQL = strSQL & "        ,  JDNPRKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strHAKKB_MI, 1) & "' "
		' === 20061219 === UPDATE E -
		strSQL = strSQL & "        ,  DENCMIN "
		strSQL = strSQL & "        ,  SETUPKB "
		strSQL = strSQL & "        ,  DATNO "
		' === 20061119 === UPDATE S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		
		' === 20061205 === UPDATE S - ACE)Nagasawa 初回登録項目の更新仕様の変更
		'    strSQL = strSQL & "        ,  FOPEID "
		'    strSQL = strSQL & "        ,  FCLTID "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		' === 20061205 === UPDATE E -
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strDLFLG, 1) & "' "
		' === 20061119 === UPDATE E -
		strSQL = strSQL & "        ,  JDNENDNM "
		strSQL = strSQL & " From  "
		strSQL = strSQL & "     JDNTHA  "
		strSQL = strSQL & " Where  "
		strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"
		
		AE_AKADEN_JDNTHA_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_AKADEN_JDNTRA_SQL
	'   概要：  赤伝票作成処理_受注トランSQL文作成
	'   引数：  pin_strDATNO        : 伝票管理№
	'           pin_strMOTODATNO  　: 元伝票管理№
	'           pin_strOPEID  　    : 最終作業者コード
	'           pin_strCLTID      　: クライアントＩＤ
	'           pin_strJODCNKB    　: 受注キャンセル理由区分
	'           pin_strDLFLG        : 削除フラグ
	'           pin_strJDNDT        : 受注伝票日付
	'   戻値：  SQL文字列
	'   備考：  受注トランINSERT文の作成
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061108 === UPDATE S - ACE)Nagasawa
	'Private Function AE_AKADEN_JDNTRA_SQL(ByVal pin_strDATNO As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String) As String
	' === 20061119 === UPDATE S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
	'Private Function AE_AKADEN_JDNTRA_SQL(ByVal pin_strDatNo As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJDNDT As String) As String
	Private Function AE_AKADEN_JDNTRA_SQL(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strDLFLG As String, ByVal pin_strJDNDT As String) As String
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		Dim strSQL As String
		' === 20070325 === INSERT S - ACE)Nagasawa 赤伝票も締日付更新
		Dim strSMADT As String
		
		'経理締日付算出
		Call AE_GetKRSMADT(pin_strJDNDT, strSMADT)
		' === 20070325 === INSERT E -
		
		strSQL = ""
		strSQL = strSQL & " Insert into JDNTRA "
		strSQL = strSQL & "        ( DATNO " '伝票管理№
		strSQL = strSQL & "        , DATKB " '伝票削除区分
		strSQL = strSQL & "        , AKAKROKB " '赤黒区分
		strSQL = strSQL & "        , DENKB " '伝票区分
		strSQL = strSQL & "        , JDNNO " '受注番号
		strSQL = strSQL & "        , LINNO " '行番号
		strSQL = strSQL & "        , RECNO " 'レコード管理№
		strSQL = strSQL & "        , JDNKB " '受注伝票区分
		strSQL = strSQL & "        , JHDNO " '発注番号
		strSQL = strSQL & "        , JDNDT " '受注伝票日付
		strSQL = strSQL & "        , DENDT " '受注日付
		strSQL = strSQL & "        , DEFNOKDT " '納期
		strSQL = strSQL & "        , TOKCD " '得意先コード
		strSQL = strSQL & "        , NHSCD " '納入先コード
		strSQL = strSQL & "        , TANCD " '担当者コード
		strSQL = strSQL & "        , BUMCD " '部門コード
		strSQL = strSQL & "        , TOKSEICD " '請求先コード
		strSQL = strSQL & "        , SOUCD " '倉庫コード
		strSQL = strSQL & "        , ZKTKB " '取引区分
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , HINCD " '製品コード
		strSQL = strSQL & "        , HINNMA " '型式
		strSQL = strSQL & "        , HINNMB " '商品名１
		strSQL = strSQL & "        , UODSU " '受注数量
		strSQL = strSQL & "        , UNTCD " '単位コード
		strSQL = strSQL & "        , UNTNM " '単位名
		strSQL = strSQL & "        , UODTK " '受注単価
		strSQL = strSQL & "        , UODKN " '受注金額
		strSQL = strSQL & "        , SIKTK " '営業仕切単価
		strSQL = strSQL & "        , SIKKN " '営業仕切金額
		strSQL = strSQL & "        , TEIKATK " '定価
		strSQL = strSQL & "        , SIKRT " '仕切率
		strSQL = strSQL & "        , KONSIKRT " '今回仕切率
		strSQL = strSQL & "        , ZAIKB " '在庫管理区分
		strSQL = strSQL & "        , LINCMA " '明細備考１
		strSQL = strSQL & "        , LINCMB " '明細備考２
		strSQL = strSQL & "        , LSTID " '伝票種別
		strSQL = strSQL & "        , HINZEIKB " '商品消費税区分
		strSQL = strSQL & "        , ZEIRT " '消費税率
		strSQL = strSQL & "        , UZEKN " '消費税額
		strSQL = strSQL & "        , ZEIRNKKB " '消費税ランク
		strSQL = strSQL & "        , HINNMMKB " '名称ﾏﾆｭｱﾙ区分（商品）
		strSQL = strSQL & "        , MAKCD " 'メーカーコード
		strSQL = strSQL & "        , HINKB " '商品区分
		strSQL = strSQL & "        , HRTDD " '発注リードタイム
		strSQL = strSQL & "        , ORTDD " '出荷リードタイム
		strSQL = strSQL & "        , TOKMSTKB " 'マスタ区分（得意先）
		strSQL = strSQL & "        , NHSMSTKB " 'マスタ区分（納入先）
		strSQL = strSQL & "        , TANMSTKB " 'マスタ区分（担当者）
		strSQL = strSQL & "        , HINMSTKB " 'マスタ区分（商品）
		strSQL = strSQL & "        , ODNYTDT " '出荷予定日
		strSQL = strSQL & "        , UDNYTDT " '売上予定日
		strSQL = strSQL & "        , TNKKB " '単価種別
		strSQL = strSQL & "        , GNKCD " '原価管理コード
		strSQL = strSQL & "        , CLMDL " '分類型式
		strSQL = strSQL & "        , HINGRP " '商品群
		strSQL = strSQL & "        , ATZHIKSU " '自動在庫引当数
		strSQL = strSQL & "        , ATNHIKSU " '自動入庫予定引当数
		strSQL = strSQL & "        , MNZHIKSU " '手動在庫引当数
		strSQL = strSQL & "        , MNNHIKSU " '手動入庫予定引当数
		strSQL = strSQL & "        , TUKKB " '通貨区分
		strSQL = strSQL & "        , RATERT " '為替レート
		strSQL = strSQL & "        , FRCTK " '外貨単価
		strSQL = strSQL & "        , FRCKN " '外貨金額
		strSQL = strSQL & "        , FRCTEITK " '外貨定価
		strSQL = strSQL & "        , HSTJDNNO " 'ホスト受注番号
		strSQL = strSQL & "        , TOKJDNNO " '客先注文No.
		strSQL = strSQL & "        , TOKJDNED " '客先注文No.枝番
		strSQL = strSQL & "        , MAKNM " 'メーカー名
		strSQL = strSQL & "        , SBNNO " '製番
		strSQL = strSQL & "        , JDNDELDT " '受注取消日
		strSQL = strSQL & "        , FDNDT " '出荷指示日
		strSQL = strSQL & "        , FRDSU " '出荷指示数量
		strSQL = strSQL & "        , ODNDT " '出荷実績日
		strSQL = strSQL & "        , OTPSU " '出荷実績数量
		strSQL = strSQL & "        , UDNDT " '売上日
		strSQL = strSQL & "        , URISU " '売上数量
		strSQL = strSQL & "        , URIKN " '売上金額
		strSQL = strSQL & "        , FURIKN " '外貨売上金額
		strSQL = strSQL & "        , URISIKKN " '売上分仕切金額
		strSQL = strSQL & "        , NYUDT " '入金日
		strSQL = strSQL & "        , NYUKN " '入金額
		strSQL = strSQL & "        , FNYUKN " '外貨入金額
		strSQL = strSQL & "        , NYUKB " '入金種別
		strSQL = strSQL & "        , INVNO " 'インボイス№
		strSQL = strSQL & "        , FRNMOVSU " '海外倉庫移動数
		strSQL = strSQL & "        , TOKDNKB " '客先伝票指定区分
		strSQL = strSQL & "        , ZAIRNK " '在庫ランク
		strSQL = strSQL & "        , PUDLNO " '入出庫番号
		strSQL = strSQL & "        , MOTDATNO " '元伝票管理番号
		' === 20061119 === UPDATE S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
		'    strSQL = strSQL & "        , OPEID "           '最終作業者コード
		'    strSQL = strSQL & "        , CLTID "           'クライアントＩＤ
		'    strSQL = strSQL & "        , WRTTM "           'タイムスタンプ（時間）
		'    strSQL = strSQL & "        , WRTDT "           'タイムスタンプ（日付）
		'    strSQL = strSQL & "        , WRTFSTTM "        'タイムスタンプ（登録時間）
		'    strSQL = strSQL & "        , WRTFSTDT "        'タイムスタンプ（登録日）
		strSQL = strSQL & "        , FOPEID " '初回登録ユーザーＩＤ
		strSQL = strSQL & "        , FCLTID " '初回登録クライアントＩＤ
		strSQL = strSQL & "        , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "        , WRTFSTDT " 'タイムスタンプ（登録日）
		strSQL = strSQL & "        , OPEID " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "        , CLTID " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "        , WRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "        , WRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "        , UOPEID " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "        , UCLTID " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "        , UWRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "        , UWRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "        , PGID " 'ＰＧＩＤ
		strSQL = strSQL & "        , DLFLG " '削除フラグ
		' === 20061119 === UPDATE E -
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " Select "
		strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "        ,  DATKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
		strSQL = strSQL & "        ,  DENKB "
		strSQL = strSQL & "        ,  JDNNO "
		strSQL = strSQL & "        ,  LINNO "
		strSQL = strSQL & "        ,  RECNO "
		strSQL = strSQL & "        ,  JDNKB "
		strSQL = strSQL & "        ,  JHDNO "
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  JDNDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(pin_strJDNDT) & "'"
		' === 20061108 === UPDATE E -
		strSQL = strSQL & "        ,  DENDT "
		strSQL = strSQL & "        ,  DEFNOKDT "
		strSQL = strSQL & "        ,  TOKCD "
		strSQL = strSQL & "        ,  NHSCD "
		strSQL = strSQL & "        ,  TANCD "
		strSQL = strSQL & "        ,  BUMCD "
		strSQL = strSQL & "        ,  TOKSEICD "
		strSQL = strSQL & "        ,  SOUCD "
		strSQL = strSQL & "        ,  ZKTKB "
		' === 20070325 === UPDATE S - ACE)Nagasawa 赤伝票も経理締日付更新
		'    strSQL = strSQL & "        ,  SMADT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(strSMADT) & "' "
		' === 20070325 === UPDATE E -
		strSQL = strSQL & "        ,  HINCD "
		strSQL = strSQL & "        ,  HINNMA "
		strSQL = strSQL & "        ,  HINNMB "
		strSQL = strSQL & "        ,  UODSU * (-1) "
		strSQL = strSQL & "        ,  UNTCD "
		strSQL = strSQL & "        ,  UNTNM "
		strSQL = strSQL & "        ,  UODTK "
		strSQL = strSQL & "        ,  UODKN * (-1) "
		strSQL = strSQL & "        ,  SIKTK "
		strSQL = strSQL & "        ,  SIKKN * (-1) "
		strSQL = strSQL & "        ,  TEIKATK "
		strSQL = strSQL & "        ,  SIKRT "
		strSQL = strSQL & "        ,  KONSIKRT "
		strSQL = strSQL & "        ,  ZAIKB "
		strSQL = strSQL & "        ,  LINCMA "
		strSQL = strSQL & "        ,  LINCMB "
		strSQL = strSQL & "        ,  LSTID "
		strSQL = strSQL & "        ,  HINZEIKB "
		strSQL = strSQL & "        ,  ZEIRT "
		strSQL = strSQL & "        ,  UZEKN * (-1) "
		strSQL = strSQL & "        ,  ZEIRNKKB "
		strSQL = strSQL & "        ,  HINNMMKB "
		strSQL = strSQL & "        ,  MAKCD "
		strSQL = strSQL & "        ,  HINKB "
		strSQL = strSQL & "        ,  HRTDD "
		strSQL = strSQL & "        ,  ORTDD "
		strSQL = strSQL & "        ,  TOKMSTKB "
		strSQL = strSQL & "        ,  NHSMSTKB "
		strSQL = strSQL & "        ,  TANMSTKB "
		strSQL = strSQL & "        ,  HINMSTKB "
		strSQL = strSQL & "        ,  ODNYTDT "
		strSQL = strSQL & "        ,  UDNYTDT "
		strSQL = strSQL & "        ,  TNKKB "
		strSQL = strSQL & "        ,  GNKCD "
		strSQL = strSQL & "        ,  CLMDL "
		strSQL = strSQL & "        ,  HINGRP "
		strSQL = strSQL & "        ,  ATZHIKSU "
		strSQL = strSQL & "        ,  ATNHIKSU "
		strSQL = strSQL & "        ,  MNZHIKSU "
		strSQL = strSQL & "        ,  MNNHIKSU "
		strSQL = strSQL & "        ,  TUKKB "
		strSQL = strSQL & "        ,  RATERT "
		strSQL = strSQL & "        ,  FRCTK "
		strSQL = strSQL & "        ,  FRCKN * (-1) "
		strSQL = strSQL & "        ,  FRCTEITK "
		strSQL = strSQL & "        ,  HSTJDNNO "
		strSQL = strSQL & "        ,  TOKJDNNO "
		strSQL = strSQL & "        ,  TOKJDNED "
		strSQL = strSQL & "        ,  MAKNM "
		strSQL = strSQL & "        ,  SBNNO "
		' === 20061223 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  JDNDELDT "
		If Trim(pin_strDLFLG) = gc_strDLFLG_DEL Then
			' === 20060112 === UPDATE S - ACE)Nagasawa 受注取消日＝受注伝票日になるよう変更
			'        strSQL = strSQL & "        ,  '" & GV_UNYDate & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_Date(pin_strJDNDT) & "'"
			' === 20060112 === UPDATE E -
		Else
			strSQL = strSQL & "        ,  JDNDELDT "
		End If
		' === 20061223 === UPDATE E -
		strSQL = strSQL & "        ,  FDNDT "
		strSQL = strSQL & "        ,  FRDSU "
		strSQL = strSQL & "        ,  ODNDT "
		strSQL = strSQL & "        ,  OTPSU "
		strSQL = strSQL & "        ,  UDNDT "
		strSQL = strSQL & "        ,  URISU * (-1) "
		strSQL = strSQL & "        ,  URIKN * (-1) "
		' === 20060107 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  FURIKN "
		strSQL = strSQL & "        ,  FURIKN * (-1) "
		' === 20060107 === UPDATE E -
		' === 20070329 === UPDATE S - ACE)Nagasawa 売上訂正返品対応
		'    strSQL = strSQL & "        ,  URISIKKN "
		strSQL = strSQL & "        ,  URISIKKN * (-1) "
		' === 20070329 === UPDATE E -
		strSQL = strSQL & "        ,  NYUDT "
		strSQL = strSQL & "        ,  NYUKN * (-1) "
		' === 20060107 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  FNYUKN "
		strSQL = strSQL & "        ,  FNYUKN * (-1) "
		' === 20060107 === UPDATE E -
		strSQL = strSQL & "        ,  NYUKB "
		strSQL = strSQL & "        ,  INVNO "
		strSQL = strSQL & "        ,  FRNMOVSU "
		strSQL = strSQL & "        ,  TOKDNKB "
		strSQL = strSQL & "        ,  ZAIRNK "
		strSQL = strSQL & "        ,  PUDLNO "
		strSQL = strSQL & "        ,  DATNO "
		' === 20061119 === UPDATE S - ACE)Nagasawa テーブルレイアウト変更対応（タイムスタンプ追加）
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		' === 20061205 === UPDATE S - ACE)Nagasawa 初回登録項目の更新仕様の変更
		'    strSQL = strSQL & "        ,  FOPEID "
		'    strSQL = strSQL & "        ,  FCLTID "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		' === 20061205 === UPDATE E -
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strDLFLG, 1) & "' "
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " From  "
		strSQL = strSQL & "     JDNTRA  "
		strSQL = strSQL & " Where  "
		strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"
		
		AE_AKADEN_JDNTRA_SQL = strSQL
		
	End Function
	' === 20060905 === INSERT E -
	
	' === 20061223 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_AKADEN_INSERT_JDNTHB
	'   概要：  赤伝票作成処理
	'   引数：  pin_strDATNO        : 伝票管理№
	'           pin_strMotoDatNo  　: 元伝票管理№
	'           pin_strOPEID  　    : 最終作業者コード
	'           pin_strCLTID      　: クライアントＩＤ
	'   戻値：  0：正常　9: 異常
	'   備考：  パラメータの値を元に赤伝票を作成する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_AKADEN_INSERT_JDNTHB(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo AE_AKADEN_INSERT_JDNTHB_err
		
		AE_AKADEN_INSERT_JDNTHB = 9
		
		'受注納入先トラン追加ＳＱＬ
		strSQL = AE_AKADEN_JDNTHB_SQL(pin_strDatNo, pin_strMotoDatNo, pin_strOPEID, pin_strCLTID)
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_AKADEN_INSERT_JDNTHB_err
		End If
		
		AE_AKADEN_INSERT_JDNTHB = 0
		
AE_AKADEN_INSERT_JDNTHB_err: 
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_AKADEN_JDNTHB_SQL
	'   概要：  赤伝票作成処理_受注納入先トランSQL文作成
	'   引数：  pin_strDATNO        : 伝票管理№
	'           pin_strMotoDatNo  　: 元伝票管理№
	'           pin_strOPEID  　    : 最終作業者コード
	'           pin_strCLTID      　: クライアントＩＤ
	'   戻値：  SQL文字列
	'   備考：  受注納入先トランINSERT文の作成
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_AKADEN_JDNTHB_SQL(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String) As String
		
		Dim strSQL As String
		
		strSQL = ""
		strSQL = strSQL & " Insert into JDNTHB "
		strSQL = strSQL & "        ( DATNO " '伝票管理№
		strSQL = strSQL & "        , DATKB " '伝票削除区分
		strSQL = strSQL & "        , AKAKROKB " '赤黒区分
		strSQL = strSQL & "        , JDNNO " '受注番号
		strSQL = strSQL & "        , NHSZP " '納入先郵便番号
		strSQL = strSQL & "        , NHSTL " '納入先電話番号
		strSQL = strSQL & "        , NHSFX " '納入先FAX番号
		' === 20070220 === INSERT S - ACE)Nagasawa 得意先名称保持対応
		strSQL = strSQL & "        , TOKNMA " '得意先名称１
		strSQL = strSQL & "        , TOKNMB " '得意先名称２
		' === 20070220 === INSERT E -
		' === 20070307 === INSERT S - ACE)Nagasawa EDI備考対応（40バイト→100バイト）
		strSQL = strSQL & "        , DENCMEDI " 'ＥＤＩ備考
		' === 20070307 === INSERT E -
		strSQL = strSQL & "        , FOPEID " '初回登録ユーザID
		strSQL = strSQL & "        , FCLTID " '初回登録クライアントID
		strSQL = strSQL & "        , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "        , WRTFSTDT " 'タイムスタンプ（登録日付）
		strSQL = strSQL & "        , OPEID " 'ユーザID（訂正）
		strSQL = strSQL & "        , CLTID " 'クライアントID（訂正）
		strSQL = strSQL & "        , WRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "        , WRTDT " 'タイムスタンプ（訂正日）
		strSQL = strSQL & "        , UOPEID " 'ユーザID（バッチ）
		strSQL = strSQL & "        , UCLTID " 'クライアントID（バッチ）
		strSQL = strSQL & "        , UWRTTM " 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "        , UWRTDT " 'タイムスタンプ（バッチ日）
		strSQL = strSQL & "        , PGID " '更新PGID
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " Select "
		strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "        ,  DATKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
		strSQL = strSQL & "        ,  JDNNO "
		strSQL = strSQL & "        ,  NHSZP "
		strSQL = strSQL & "        ,  NHSTL "
		strSQL = strSQL & "        ,  NHSFX "
		' === 20070220 === INSERT S - ACE)Nagasawa 得意先名称保持対応
		strSQL = strSQL & "        ,  TOKNMA "
		strSQL = strSQL & "        ,  TOKNMB "
		' === 20070220 === INSERT E -
		' === 20070307 === INSERT S - ACE)Nagasawa EDI備考対応（40バイト→100バイト）
		strSQL = strSQL & "        ,  DENCMEDI "
		' === 20070307 === INSERT E -
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
		strSQL = strSQL & " From  "
		strSQL = strSQL & "     JDNTHB  "
		strSQL = strSQL & " Where  "
		strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"
		
		AE_AKADEN_JDNTHB_SQL = strSQL
		
	End Function
	' === 20061223 === INSERT E -
	
	' === 20060912 === INSERT S - ACE)Sejima CRM連携CSV排他対応
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_INI_CRM
	'   概要：  CRM関連INIファイル情報取得
	'   引数：  pin_strFileName     : INIﾌｧｲﾙ名称
	'           pot_strCSVFilePath　: CSVﾌｧｲﾙﾊﾟｽ
	'           pot_curRetry  　    : ﾘﾄﾗｲ回数
	'           pot_curWait       　: ﾘﾄﾗｲ間隔
	'           pot_strAddMsg     　: 追記ｴﾗｰﾒｯｾｰｼﾞ
	'   戻値：  0:正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_INI_CRM(ByVal pin_strFileName As String, ByRef pot_strCSVFilePath As String, ByRef pot_curRetry As Decimal, ByRef pot_curWait As Decimal) As Short
		
		Dim Ret_Value As Short
		Dim lRet As Integer
		Dim strRet As New VB6.FixedLengthString(256)
		Dim strWk As String
		Dim intRet As Short
		
		CF_Get_INI_CRM = 9
		
		'いったん正常扱い
		Ret_Value = 0
		
		'iniファイルより、
		'　①CSV読込リトライ間隔
		strRet.Value = ""
		' === 20061102 === UPDATE S - ACE)Nagasawa INIファイル読込み変更
		'    lRet = GetPrivateProfileString("CRM", "Wait", "", strRet, Len(strRet), pin_strFileName)
		'    If lRet > 0 Then
		'        If IsNumeric(strRet) = True Then
		'            'iniファイルから取得できて、かつ数値として正しい
		'            pot_curWait = LeftWid(strRet, lRet)
		'
		'        Else
		'            'iniファイルから取得できたが、数値として正しくない
		'            Ret_Value = 9
		'
		'        End If
		'
		'    Else
		'        'iniファイルから取得できない
		'        Ret_Value = 9
		'
		'    End If
		
		intRet = CF_Get_IniInf("CRM", "Wait", strRet.Value)
		If intRet = 0 Then
			If IsNumeric(strRet.Value) = True Then
				'iniファイルから取得できて、かつ数値として正しい
				pot_curWait = CF_Get_CCurString(strRet.Value)
			Else
				'iniファイルから取得できたが、数値として正しくない
				Ret_Value = 9
				
			End If
			
		Else
			'iniファイルから取得できない
			Ret_Value = 9
			
		End If
		' === 20061102 === UPDATE E -
		
		'　　（読み込めない場合は AE_CONST.bas の固定値を使用し、エラーとしない）
		If Ret_Value = 9 Then
			pot_curWait = CRM_RETRY_WAIT
			Ret_Value = 0
		End If
		
		
		'　②CSV読込リトライ回数
		strRet.Value = ""
		' === 20061102 === UPDATE S - ACE)Nagasawa INIファイル読込み変更
		'    lRet = GetPrivateProfileString("CRM", "Retry", "", strRet, Len(strRet), pin_strFileName)
		'    If lRet > 0 Then
		'        If IsNumeric(strRet) = True Then
		'            'iniファイルから取得できて、かつ数値として正しい
		'            pot_curRetry = LeftWid(strRet, lRet)
		'
		'        Else
		'            'iniファイルから取得できたが、数値として正しくない
		'            Ret_Value = 9
		'
		'        End If
		'
		'    Else
		'        'iniファイルから取得できない
		'        Ret_Value = 9
		'
		'    End If
		
		intRet = CF_Get_IniInf("CRM", "Retry", strRet.Value)
		If intRet = 0 Then
			If IsNumeric(strRet.Value) = True Then
				'iniファイルから取得できて、かつ数値として正しい
				pot_curRetry = CF_Get_CCurString(strRet.Value)
			Else
				'iniファイルから取得できたが、数値として正しくない
				Ret_Value = 9
				
			End If
			
		Else
			'iniファイルから取得できない
			Ret_Value = 9
			
		End If
		' === 20061102 === UPDATE E -
		
		'　　（読み込めない場合は AE_CONST.bas の固定値を使用し、エラーとしない）
		If Ret_Value = 9 Then
			pot_curRetry = CRM_RETRY_MAX
			Ret_Value = 0
		End If
		
		
		'　③CSVファイルパス
		strRet.Value = ""
		' === 20061102 === UPDATE S - ACE)Nagasawa INIファイル読込み変更
		'    lRet = GetPrivateProfileString("CRM", "CSVPath", "", strRet, Len(strRet), pin_strFileName)
		'    If lRet > 0 Then
		'        pot_strCSVFilePath = LeftWid(strRet, lRet)
		'    Else
		'        'iniファイルから取得できない
		'        Ret_Value = 9
		'    End If
		
		'　③CSVファイルパス
		intRet = CF_Get_IniInf("CRM", "CSVPath", strRet.Value)
		If intRet = 0 Then
			pot_strCSVFilePath = strRet.Value
		Else
			'iniファイルから取得できない
			Ret_Value = 9
		End If
		' === 20061102 === UPDATE E -
		
		CF_Get_INI_CRM = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_OpenCRMCsv
	'   概要：  CRM関連INIファイルオープン処理
	'   引数：  pin_intFileNo       : ファイル番号
	'           pin_strCSVFilePath　: CSVﾌｧｲﾙﾊﾟｽ
	'           pin_curRetry  　    : ﾘﾄﾗｲ回数
	'           pin_curWait       　: ﾘﾄﾗｲ間隔
	'   戻値：  0:正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_OpenCRMCsv(ByVal pin_intFileNo As Short, ByVal pin_strCSVFilePath As String, ByVal pin_curRetry As Decimal, ByVal pin_curWait As Decimal) As Boolean
		
		Dim bolOpen As Boolean
		Dim curRetryCnt As Decimal
		Dim curRetryMax As Decimal
		
		CF_Ctl_OpenCRMCsv = False
		
		'リトライ回数の上限を設定
		curRetryMax = pin_curRetry
		'    If curRetryMax >= 10 Then
		'        curRetryMax = 10
		'    End If
		
		curRetryCnt = 0
		bolOpen = False
		'ファイルを開くか、最大回数を超えてリトライするまでループ
		Do Until bolOpen = True Or curRetryCnt > curRetryMax
			
			System.Windows.Forms.Application.DoEvents()
			
			'上書き禁止、追記モードでオープン
			On Error Resume Next
			FileOpen(pin_intFileNo, pin_strCSVFilePath, OpenMode.Append, , OpenShare.LockWrite)
			Select Case Err.Number
				Case 70
					'既にファイルが開かれている場合、リトライ
					'（リトライ間隔分の時間、一時停止。ただし最終回を除く）
					If curRetryCnt < curRetryMax Then
						Call SSSMAIN0002.Sleep(pin_curWait * 1000)
					End If
					
				Case 0
					'正常にオープン
					bolOpen = True
					
				Case Else
					
			End Select
			
			curRetryCnt = curRetryCnt + 1
			
		Loop 
		
		CF_Ctl_OpenCRMCsv = bolOpen
		
	End Function
	' === 20060912 === INSERT E
	
	' === 20061013 === INSERT S - ACE)Nagasawa 売上基準の入力制限追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_URIKJN_Input
	'   概要：  入力売上基準チェック処理
	'   引数：  pin_strJDNTRKB      : 受注取引区分
	'           pin_strURIKJN     　: 売上基準
	'   戻値：  0:正常終了(チェックＯＫ）　1:チェックＮＧ  9:異常終了
	'   備考：  受注取引区分より入力された売上基準が入力可能値かどうか判定します
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_URIKJN_Input(ByVal pin_strJDNTRKB As String, ByVal pin_strURIKJN As String) As Short
		
		' === 20061030 === INSERT S - ACE)Nagasawa 売上基準のチェック変更
		Dim Mst_Inf As TYPE_DB_MEIMTA
		Dim intRet As Short
		' === 20061030 === INSERT E -
		
		CF_Chk_URIKJN_Input = 9
		
		' === 20061030 === UPDATE S - ACE)Nagasawa 売上基準のチェック変更
		'    Select Case pin_strJDNTRKB
		'        '単品の場合
		'        Case gc_strJDNTRKB_TAN
		'            '出荷基準以外はエラー
		'            If pin_strURIKJN <> gc_strURIKJN_SYK Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        'セットアップの場合
		'        Case gc_strJDNTRKB_SET
		'            '出荷基準以外はエラー
		'            If pin_strURIKJN <> gc_strURIKJN_SYK Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        'システムの場合
		'        Case gc_strJDNTRKB_SYS
		'            '出荷基準、検収基準、工事完了基準以外はエラー
		'            If pin_strURIKJN <> gc_strURIKJN_SYK _
		''            And pin_strURIKJN <> gc_strURIKJN_KNS _
		''            And pin_strURIKJN <> gc_strURIKJN_KOJ Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '修理の場合
		'        Case gc_strJDNTRKB_SYR
		'            '検収基準以外はエラー
		'            If pin_strURIKJN <> gc_strURIKJN_KNS Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '保守の場合
		'        Case gc_strJDNTRKB_HSY
		'            '役務完了基準以外はエラー
		'            If pin_strURIKJN <> gc_strURIKJN_EKM Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '貸出の場合
		'        Case gc_strJDNTRKB_KAS
		'            '検収完了基準以外はエラー
		'            If pin_strURIKJN <> gc_strURIKJN_KNS Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '上記以外
		'        Case Else
		'            CF_Chk_URIKJN_Input = 1
		'            Exit Function
		'
		'    End Select
		'
		'    CF_Chk_URIKJN_Input = 0
		
		Call DB_MEIMTA_Clear(Mst_Inf)
		
		'名称マスタ検索
		CF_Chk_URIKJN_Input = 1
		intRet = DSPMEIM_SEARCH(gc_strKEYCD_URIKJN_Chk, pin_strJDNTRKB, Mst_Inf, pin_strURIKJN)
		If intRet = 0 Then
			If Mst_Inf.DATKB = gc_strDATKB_USE Then
				CF_Chk_URIKJN_Input = 0
			End If
		End If
		' === 20061030 === UPDATE E -
		
	End Function
	' === 20061013 === INSERT E -
	
	' === 20061026 === INSERT S - ACE)Nagasawa 客先伝票指定区分変更
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_DspTOKDNKB
	'   概要：  画面表示用客先伝票指定区分取得処理
	'   引数：  pin_strTOKDNKB      : 客先伝票指定区分
	'   戻値：  画面表示用客先伝票指定区分(vbChecked/vbUnchecked)
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_DspTOKDNKB(ByVal pin_strTOKDNKB As String) As Short
		
		If pin_strTOKDNKB = gc_strTOKDNKB_NML Then
			'"通常"の場合、チェックOFF
			CF_Get_DspTOKDNKB = System.Windows.Forms.CheckState.Unchecked
		Else
			'"通常"以外の場合、チェックON
			CF_Get_DspTOKDNKB = System.Windows.Forms.CheckState.Checked
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_UpdTOKDNKB
	'   概要：  受注トラン更新用客先伝票指定区分取得処理
	'   引数：  pin_intTOKDNKB              : 画面の客先伝票指定区分
	'   引数：  pin_strTOKDNKB_TOKMTA       : 得意先マスタの客先伝票指定区分
	'   戻値：  受注トラン行進用客先伝票指定区分
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_UpdTOKDNKB(ByVal pin_intTOKDNKB As Short, ByVal pin_strTOKDNKB_TOKMTA As String) As String
		
		If pin_intTOKDNKB = System.Windows.Forms.CheckState.Unchecked Then
			'チェックOFFの場合、"通常"
			CF_Get_UpdTOKDNKB = gc_strTOKDNKB_NML
		Else
			'チェックONの場合
			If pin_strTOKDNKB_TOKMTA = gc_strTOKDNKB_NML Then
				'得意先マスタの客先指定伝票区分が"通常"の場合は指定
				CF_Get_UpdTOKDNKB = gc_strTOKDNKB_STI
			Else
				'得意先マスタの客先伝票指定区分使用
				CF_Get_UpdTOKDNKB = pin_strTOKDNKB_TOKMTA
			End If
		End If
		
	End Function
	' === 20061026 === INSERT E -
	
	' === 20061028 === INSERT S - ACE)Nagasawa FAX番号チェックの追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_FAXNO
	'   概要：  FAX番号チェック処理
	'   引数：  pin_strFAXNO       : チェック対象FAX番号
	'           pin_intKETA        : FAX番号入力可能桁数
	'           pin_intFAX_HAIHUN  : FAX番号ハイフン数
	'           pin_intFAX_LSTNUM  : FAX番号最終数値部分桁数
	'           pin_strFRNKB       : 海外取引区分
	'   戻値：  0 : チェックOK   9 : チェックNG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_FAXNO(ByVal pin_strFAXNO As String, ByVal pin_intKETA As Short, ByVal pin_intFAX_HAIHUN As Short, ByVal pin_intFAX_LSTNUM As Short, ByVal pin_strFRNKB As String) As Short
		
		Dim intHaihun As Short
		Dim intCnt As Short
		Dim intLstHaihun As Short '最後のハイフン位置
		
		CF_Chk_FAXNO = 9
		
		'ファックス番号の書式チェックを追加
		If pin_strFRNKB <> gc_strFRNKB_FRN Then
			
			'空白はOKとする
			If Trim(pin_strFAXNO) = "" Then
				CF_Chk_FAXNO = 0
				Exit Function
			End If
			
			'ハイフンが先頭の場合はエラー
			If Mid(pin_strFAXNO, 1, 1) = "-" Then
				CF_Chk_FAXNO = 10
				Exit Function
			End If
			
			'ハイフンが最後の場合はエラー
			If Right(pin_strFAXNO, 1) = "-" Then
				CF_Chk_FAXNO = 30
				Exit Function
			End If
			
			'ハイフンが連続して存在する場合エラー
			If InStr(pin_strFAXNO, "--") > 0 Then
				CF_Chk_FAXNO = 20
				Exit Function
			End If
			
			'桁数チェック
			If Len(pin_strFAXNO) > pin_intKETA Then
				CF_Chk_FAXNO = 40
				Exit Function
			End If
			
			'ハイフン数チェック
			intHaihun = 0
			intLstHaihun = 0
			For intCnt = 1 To Len(pin_strFAXNO)
				If Mid(pin_strFAXNO, intCnt, 1) = "-" Then
					intHaihun = intHaihun + 1
					intLstHaihun = intCnt
				End If
			Next 
			
			If intHaihun <> pin_intFAX_HAIHUN Then
				CF_Chk_FAXNO = 50
				Exit Function
			End If
			
			'最終部の桁数チェック
			'''' UPD 2012/03/07  FKS) T.Yamamoto    Start    連絡票№FC12030701
			'        If Len(Mid(Trim(pin_strFAXNO), intLstHaihun + 1)) <> pin_intFAX_LSTNUM Then
			If Len(Mid(Trim(pin_strFAXNO), intLstHaihun + 1)) > pin_intFAX_LSTNUM Then
				'''' UPD 2012/03/07  FKS) T.Yamamoto    End
				CF_Chk_FAXNO = 60
				Exit Function
			End If
			
		End If
		
		CF_Chk_FAXNO = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_CLMDL_FRN
	'   概要：  分類型式取得処理（海外）
	'   引数：  pin_strJDNTRKB     : 受注取引区分
	'           pin_strMDLCL       : 商品マスタ.集計分類（受注トラン.分類型式）
	'           pin_strCLMDL_DSP   : 画面.分類型式
	'   戻値：  取得された分類型式
	'   備考：　受注取引区分により受注トランに編集する分類型式の値を決定します
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_CLMDL_FRN(ByVal pin_strJDNTRKB As String, ByVal pin_strMDLCL As String, ByVal pin_strCLMDL_DSP As String) As String
		
		Dim Rtn_Value As String
		
		CF_Get_CLMDL_FRN = ""
		Rtn_Value = ""
		
		Select Case pin_strJDNTRKB
			'単品
			Case gc_strJDNTRKB_TAN
				Rtn_Value = pin_strMDLCL
				
				'セットアップ
			Case gc_strJDNTRKB_SET
				
				'システム
			Case gc_strJDNTRKB_SYS
				
				'修理
			Case gc_strJDNTRKB_SYR
				' === 20061119 === INSERT S - ACE)Nagasawa
				'            Rtn_Value = pin_strCLMDL_DSP
				Rtn_Value = pin_strMDLCL
				' === 20061119 === INSERT E -
				
				'保守
			Case gc_strJDNTRKB_HSY
				' === 20061119 === INSERT S - ACE)Nagasawa
				'            Rtn_Value = pin_strCLMDL_DSP
				Rtn_Value = pin_strMDLCL
				' === 20061119 === INSERT E -
				
				'貸出
			Case gc_strJDNTRKB_KAS
				Rtn_Value = pin_strMDLCL
				
			Case Else
		End Select
		
		CF_Get_CLMDL_FRN = Rtn_Value
		
	End Function
	' === 20061028 === INSERT E -
	
	' === 20061031 === INSERT S - ACE)Nagasawa 排他制御の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_EXCTBZ
	'   概要：  PL/SQL実行処理(排他制御処理)
	'   引数：　Pin_strPRCCASE   : 処理ケース(C:チェック W:書込処理 D:削除処理)
	'           Pot_strMsg       : エラー内容
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御用PL/SQL(PRC_EXCTBZ)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, ByRef pot_strMsg As String) As Short
		
		Dim strSQL As String 'SQL文
		Dim strPara1 As String 'ﾊﾟﾗﾒｰﾀ1(担当者コード)
		Dim strPara2 As String 'ﾊﾟﾗﾒｰﾀ2(クライアントID)
		Dim strPara3 As String 'ﾊﾟﾗﾒｰﾀ3(処理ケース)
		Dim strPara4 As String 'ﾊﾟﾗﾒｰﾀ4(業務コード(PGID))
		Dim lngPara5 As Integer 'ﾊﾟﾗﾒｰﾀ5(復帰ｺｰﾄﾞ)
		Dim lngPara6 As Integer 'ﾊﾟﾗﾒｰﾀ6(ｴﾗｰｺｰﾄﾞ)
		Dim strPara7 As String 'ﾊﾟﾗﾒｰﾀ7(ｴﾗｰ内容)
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(7) As OraParameter 'PL/SQLのバインド変数
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_EXCTBZ = 9
		
		'受渡し変数初期設定
		strPara1 = Inp_Inf.InpTanCd
		strPara2 = SSS_CLTID.Value
		strPara3 = Pin_strPRCCASE
		strPara4 = SSS_PrgId
		lngPara5 = 0
		lngPara6 = 0
		strPara7 = ""
		
		pot_strMsg = ""
		
		'パラメータの初期設定を行う（バインド変数）
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P6", lngPara6, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P7", strPara7, ORAPARM_OUTPUT)
		
		'データ型をオブジェクトにセット
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7) = gv_Odb_USR1.Parameters("P7")
		
		'各オブジェクトのデータ型を設定
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7).serverType = ORATYPE_VARCHAR2
		
		'PL/SQL呼び出しSQL
		strSQL = "BEGIN PRC_EXCTBZ(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"
		
		'DBアクセス
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_EXCTBZ_END
		End If
		
		'** 戻り値取得
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara5 = param(5).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara6 = param(6).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(param(7).Value) = False Then
			'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strPara7 = param(7).Value
			pot_strMsg = strPara7
		End If
		
		'エラー情報設定
		gv_Int_OraErr = lngPara6
		gv_Str_OraErrText = strPara7
		
		AE_Execute_PLSQL_EXCTBZ = lngPara5
		
AE_Execute_PLSQL_EXCTBZ_END: 
		'** パラメタ解消
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P7")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_Lock_EXCTBZ
	'   概要：　排他制御処理
	'   引数：　Pot_strMsg       : エラー内容
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御（排他チェック＆排他テーブルへの書き込み）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_Lock_EXCTBZ(ByRef pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Chk_Lock_EXCTBZ_Err
		
		CF_Chk_Lock_EXCTBZ = 9
		pot_strMsg = ""
		bolTrn = False
		
		'排他チェック
		intRet = AE_Execute_PLSQL_EXCTBZ("C", strMsg)
		If intRet <> 0 Then
			'排他エラー
			pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'排他制御
		intRet = AE_Execute_PLSQL_EXCTBZ("W", strMsg)
		If intRet <> 0 Then
			'排他エラー
			pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Chk_Lock_EXCTBZ = 0
		
		Exit Function
		
CF_Chk_Lock_EXCTBZ_Err: 
		
		'ロールバック
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Unlock_EXCTBZ
	'   概要：　排他制御解除処理
	'   引数：　Pot_strMsg       : エラー内容
	'   戻値：　0 : 正常  9 : 異常
	'   備考：  排他制御（排他テーブルからの削除）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Unlock_EXCTBZ(ByRef pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Unlock_EXCTBZ_Err
		
		CF_Unlock_EXCTBZ = 9
		pot_strMsg = ""
		bolTrn = False
		
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'排他制御解除
		intRet = AE_Execute_PLSQL_EXCTBZ("D", strMsg)
		If intRet <> 0 Then
			'排他エラー
			pot_strMsg = strMsg
			CF_Unlock_EXCTBZ = intRet
			GoTo CF_Unlock_EXCTBZ_Err
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Unlock_EXCTBZ = 0
		
		Exit Function
		
CF_Unlock_EXCTBZ_Err: 
		
		'ロールバック
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_IniInf
	'   概要：  Iniファイル読込み処理（プログラム固有）
	'   引数：  pin_strSection :
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_IniInf(ByRef pin_strSection As String, ByRef pin_strKey As String, ByRef pot_strValue As String) As Short
		
		Dim Wk As New VB6.FixedLengthString(256)
		Dim lngRet As Integer
		
		CF_Get_IniInf = 9
		
		pot_strValue = ""
		
		'Iniファイル読込み
		lngRet = GetPrivateProfileString(pin_strSection, pin_strKey, "", Wk.Value, Len(Wk.Value), My.Application.Info.DirectoryPath & "\" & SSS_PrgId & ".ini")
		If lngRet > 0 Then
			pot_strValue = CF_Ctr_AnsiLeftB(Wk.Value, lngRet)
			pot_strValue = Trim(pot_strValue)
		Else
			Exit Function
		End If
		
		CF_Get_IniInf = 0
		
	End Function
	' === 20061031 === INSERT E -
	
	' === 20130416 === INSERT S - FWEST)Koroyasu 排他制御の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_EXCTBZ
	'   概要：　排他チェック処理
	'   引数：  pm_All  ：画面情報
	'       ：　pin_strJDNNO    ：業務コード
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御（排他チェック）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20130530 === UPDATE S - FWEST)Koroyasu
	'Public Function CF_Chk_EXCTBZ(pm_All As Cls_All) As Integer
	Public Function CF_Chk_EXCTBZ(ByRef pm_All As Cls_All, ByRef pin_strGYMCD As String) As Short
		' === 20130530 === UPDATE E
		
		Dim strSQL As String
		Dim bolRet As Boolean
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		
		On Error GoTo CF_Chk_EXCTBZ_Err
		
		CF_Chk_EXCTBZ = 9
		
		'排他チェック
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "  FROM "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "  WHERE "
		' === 20130530 === UPDATE S - FWEST)Koroyasu
		'    strSQL = strSQL & "        GYMCD   = '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_JDNNO.Tag).Detail.Dsp_Value, 6) & "'"    '受注番号
		strSQL = strSQL & "        GYMCD   = '" & pin_strGYMCD & "'" '業務コード
		' === 20130530 === UPDATE E
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If bolRet = False Then
			GoTo CF_Chk_EXCTBZ_Err
		End If
		
		'検索結果が0件の場合
		If CF_Ora_RecordCount(Usr_Ody) = 0 Then
			'排他制御（排他テーブルへ書き込み）
			' === 20130530 === UPDATE S - FWEST)Koroyasu
			'        bolRet = CF_Execute_EXCTBZ(pm_All)
			bolRet = CF_Execute_EXCTBZ(pm_All, pin_strGYMCD)
			' === 20130530 === UPDATE E
			If bolRet = False Then
				GoTo CF_Chk_EXCTBZ_Err
			End If
			CF_Chk_EXCTBZ = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) = Inp_Inf.InpCLIID And Trim(CF_Ora_GetDyn(Usr_Ody, "INTLCD", "")) = SSS_PrgId Then
				CF_Chk_EXCTBZ = 0
			Else
				'検索結果が存在した場合
				CF_Chk_EXCTBZ = 1
				'処理終了
				Exit Function
			End If
		End If
		
CF_Chk_EXCTBZ_Err: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Execute_EXCTBZ
	'   概要：  排他制御処理
	'   引数：  pm_All : 画面情報
	'       ：　pin_strGYMCD：業務コード
	'   戻値：　True : 正常 False : 異常
	'   備考：  排他制御を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20130530 === UPDATE S - FWEST)Koroyasu
	'Public Function CF_Execute_EXCTBZ(pm_All As Cls_All) As Boolean
	Public Function CF_Execute_EXCTBZ(ByRef pm_All As Cls_All, ByRef pin_strGYMCD As String) As Boolean
		' === 20130530 === UPDATE E
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Execute_EXCTBZ_Err
		
		CF_Execute_EXCTBZ = False
		
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'排他制御
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " INSERT INTO "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "      ( CLTID " 'クライアントID
		strSQL = strSQL & "      , GYMCD " '受注番号
		strSQL = strSQL & "      , LCKTM " 'タイムスタンプ
		strSQL = strSQL & "      , INTLCD " 'プログラムID
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & Inp_Inf.InpCLIID & "' " 'クライアントID
		' === 20130530 === UPDATE S - FWEST)Koroyasu
		'    strSQL = strSQL & "      , '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_JDNNO.Tag).Detail.Dsp_Value, 6) & "' "   '受注番号
		strSQL = strSQL & "      , '" & pin_strGYMCD & "' " '業務コード
		' === 20130530 === UPDATE E
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ
		strSQL = strSQL & "      , '" & SSS_PrgId & "'" 'プログラムID
		strSQL = strSQL & "      ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_Execute_EXCTBZ_Err
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Execute_EXCTBZ = True
		
CF_Execute_EXCTBZ_Err: 
		
		'ロールバック
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Unlock_EXCTBZ2
	'   概要：　排他制御解除処理
	'   引数：  pm_All : 画面情報
	'   戻値：　True : 正常  False : 異常
	'   備考：  排他制御（排他テーブルからの削除）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Unlock_EXCTBZ2() As Boolean
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Unlock_EXCTBZ2_Err
		
		CF_Unlock_EXCTBZ2 = False
		
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'排他制御解除
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        CLTID    = '" & Inp_Inf.InpCLIID & "' " 'クライアントID
		strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' " 'プログラムID
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_Unlock_EXCTBZ2_Err
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Unlock_EXCTBZ2 = True
		
		Exit Function
		
CF_Unlock_EXCTBZ2_Err: 
		
		'ロールバック
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	' === 20130416 === INSERT E -
	
	' === 20061206 === INSERT S - ACE)Nagasawa 商品状態チェックの変更
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_HINCD
	'   概要：  製品コード状態チェック処理
	'   引数：  pm_Mst_Inf : 商品マスタ用構造体
	'   戻値：  0  : 正常
	'           10 : 受注停止
	'           20 : 生産終了(手配終了)
	'           30 : 出荷停止
	'           40 : 出荷準備中
	'   備考：　入力された製品コードの状態のチェックを行います
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_HINCD(ByRef pm_Mst_Inf As TYPE_DB_HINMTA) As Short
		
		CF_Chk_HINCD = 0
		
		'出荷準備中チェック
		If pm_Mst_Inf.ORTSTPKB = gc_strORTSTPKB_PRE Then
			CF_Chk_HINCD = 40
		End If
		
		'出荷停止品チェック
		If pm_Mst_Inf.ORTSTPKB = gc_strORTSTPKB_STOP Then
			CF_Chk_HINCD = 30
		End If
		
		'生産終了品チェック
		If pm_Mst_Inf.PRDENDKB = gc_strPRDENDKB_END Then
			CF_Chk_HINCD = 20
		End If
		
		'受注停止品チェック
		If pm_Mst_Inf.JODSTPKB = gc_strJODSTPKB_STOP Then
			CF_Chk_HINCD = 10
		End If
		
	End Function
	' === 20061206 === INSERT E -
	
	' === 20061216 === INSERT S - ACE)Nagasawa 製品コードの入力制限追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_HINCD2
	'   概要：  製品コード商品区分チェック処理
	'   引数：  pin_strHINKB   : 商品区分
	'           pin_strJDNTRKB : 受注取引区分
	'   戻値：  0 : 正常　9 : エラー
	'   備考：　入力された製品コードの状態のチェックを行います
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_HINCD2(ByRef pin_strHINKB As String, ByRef pin_strJDNTRKB As String) As Short
		
		CF_Chk_HINCD2 = 9
		
		'受注取引区分により判定
		Select Case Trim(pin_strJDNTRKB)
			'単品の場合
			Case gc_strJDNTRKB_TAN
				
				'商品区分により判断
				Select Case Trim(pin_strHINKB)
					'製品の場合
					Case gc_strHINKB_SEIHIN
						CF_Chk_HINCD2 = 0
						'商品の場合
					Case gc_strHINKB_SYOHIN
						CF_Chk_HINCD2 = 0
						
					Case Else
				End Select
				
				'セットアップの場合
			Case gc_strJDNTRKB_SET
				'全てＯＫ
				CF_Chk_HINCD2 = 0
				
				'システムの場合
			Case gc_strJDNTRKB_SYS
				'全てＯＫ
				CF_Chk_HINCD2 = 0
				
				'修理の場合
			Case gc_strJDNTRKB_SYR
				'MOD 20141219 START
				'            '全てＯＫ
				'            CF_Chk_HINCD2 = 0
				
				'商品区分により判断
				Select Case Trim(pin_strHINKB)
					'その他の場合
					Case gc_strHINKB_ELSE
						CF_Chk_HINCD2 = 0
						
					Case Else
				End Select
				'MOD 20141219 END
				
				'保守の場合
			Case gc_strJDNTRKB_HSY
				'全てＯＫ
				CF_Chk_HINCD2 = 0
				
				'貸出の場合
			Case gc_strJDNTRKB_KAS
				' === 20060112 === UPDATE S - ACE)Nagasawa 製品コードの入力制限追加
				'            '全てＯＫ
				'            CF_Chk_HINCD2 = 0
				
				'商品区分により判断
				Select Case Trim(pin_strHINKB)
					'製品の場合
					Case gc_strHINKB_SEIHIN
						CF_Chk_HINCD2 = 0
						'商品の場合
					Case gc_strHINKB_SYOHIN
						CF_Chk_HINCD2 = 0
						
					Case Else
				End Select
				' === 20060112 === UPDATE E -
				
		End Select
		
	End Function
	' === 20061216 === INSERT E -
	
	
	' === 20061208 === INSERT S - ACE)Nagasawa 納期回答の判断は代表会社コードのEDI区分から行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_EDIKBN
	'   概要：  納期回答実行判定処理
	'   引数：  pin_strTGRPCD   : 代表会社コード
	'           pin_strROKCD    : 得意先コード
	'   戻値：  True : 納期回答する　False : 納期回答しない
	'   備考：　納期回答を実行するかどうかの判定を行います。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_EDIKBN(ByRef pin_strTGRPCD As String, ByRef pin_strTOKCD As String) As Boolean
		
		Dim strTGRPCD As String
		Dim Mst_Inf_TOK As TYPE_DB_TOKMTA
		Dim Mst_Inf_TGRP As TYPE_DB_TOKMTA
		Dim intRet_TOK As Short
		Dim intRet_TGRP As Short
		
		CF_Chk_EDIKBN = False
		
		'代表会社コードがない場合は得意先コードで判定
		If Trim(pin_strTGRPCD) = "" Then
			strTGRPCD = pin_strTOKCD
		Else
			strTGRPCD = pin_strTGRPCD
		End If
		
		'構造体クリア
		Call DB_TOKMTA_Clear(Mst_Inf_TGRP)
		Call DB_TOKMTA_Clear(Mst_Inf_TOK)
		
		'得意先マスタ検索
		intRet_TGRP = DSPTOKCD_SEARCH(strTGRPCD, Mst_Inf_TGRP)
		intRet_TOK = DSPTOKCD_SEARCH(pin_strTOKCD, Mst_Inf_TOK)
		
		'EDI区分が"VAN"で、EDI区分（納期情報）が"する"の場合、納期回答処理実行
		If intRet_TGRP = 0 And Mst_Inf_TGRP.DATKB = gc_strDATKB_USE Then
			If Mst_Inf_TGRP.EDIKB = gc_strEDIKB_VAN And Mst_Inf_TGRP.EDIKBN = gc_strEDIKB_OK Then
				CF_Chk_EDIKBN = True
			End If
		Else
			If intRet_TOK = 0 And Mst_Inf_TOK.DATKB = gc_strDATKB_USE Then
				If Mst_Inf_TOK.EDIKB = gc_strEDIKB_VAN And Mst_Inf_TOK.EDIKBN = gc_strEDIKB_OK Then
					CF_Chk_EDIKBN = True
				End If
			End If
		End If
		
	End Function
	' === 20061208 === INSERT E -
	
	' === 20061213 === INSERT S - ACE)Nagasawa 分類型式のチェック追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_CLMDL
	'   概要：  分類型式チェック処理
	'   引数：  pin_strCLMDL    : チェック対象機種分類
	'           pin_strJDNDT    : 基準日（画面.受注日）
	'           pin_strJDNTRKB  : 受注取引区分
	'           pin_strCMPKTCD  : コンピュータ型式
	'   戻値：  0 : チェックOK　9 : チェックNG
	'   備考：　基準日に使用できる機種分類かどうかを判定します
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070207 === UPDATE S - ACE)Nagasawa システム受注で機器受注を入力可とする
	' === 20061228 === UPDATE S - ACE)Nagasawa 分類型式のチェック変更
	'Public Function CF_Chk_CLMDL(pin_strCLMDL As String, _
	''                             pin_strJDNDT As String) As Integer
	'Public Function CF_Chk_CLMDL(pin_strCLMDL As String, _
	''                             pin_strJDNDT As String, _
	''                             pin_strJDNTRKB As String) As Integer
	'' === 20061228 === UPDATE E -
	Public Function CF_Chk_CLMDL(ByRef pin_strCLMDL As String, ByRef pin_strJDNDT As String, ByRef pin_strJDNTRKB As String, Optional ByRef pin_strCMPKTCD As String = " ") As Short
		' === 20070207 === UPDATE E -
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody_KATA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_KATA As U_Ody
		Dim strRtn As String
		
		On Error GoTo Err_CF_Chk_CLMDL
		
		CF_Chk_CLMDL = 9
		strRtn = ""
		
		' === 20061228 === UPDATE S - ACE)Nagasawa 分類型式のチェック変更
		'    If Trim(pin_strCLMDL) = "" Or Trim(pin_strJDNDT) = "" Then
		If Trim(pin_strCLMDL) = "" Or Trim(pin_strJDNDT) = "" Or Trim(pin_strJDNTRKB) = "" Then
			' === 20061228 === UPDATE E -
			CF_Chk_CLMDL = 0
			Exit Function
		End If
		
		'分類型式チェック関数呼び出し
		' === 20070207 === UPDATE S - ACE)Nagasawa システム受注で機器受注を入力可とする
		'    strSQL = ""
		'    strSQL = strSQL & " SELECT "
		'' === 20061228 === UPDATE S - ACE)Nagasawa 分類型式のチェック変更
		''    strSQL = strSQL & "        GET_PCODE_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
		''    strSQL = strSQL & "                      ,'" & CF_Ora_Sgl(pin_strJDNDT) & "') AS RTN "
		'    strSQL = strSQL & "        CHECK_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
		'    strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNDT) & "' "
		'    strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNTRKB) & "') AS RTN "
		'' === 20061228 === UPDATE E -
		'    strSQL = strSQL & "   FROM DUAL "
		
		If Trim(pin_strJDNTRKB) = gc_strJDNTRKB_SYS Then
			'システム受注の場合システム用分類型式チェック
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        CHECK_KATA_SYS('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNDT) & "' "
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNTRKB) & "'"
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strCMPKTCD) & "') AS RTN "
			strSQL = strSQL & "   FROM DUAL "
		Else
			'システム受注以外の場合は通常の分類型式チェック
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        CHECK_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNDT) & "' "
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNTRKB) & "') AS RTN "
			strSQL = strSQL & "   FROM DUAL "
		End If
		' === 20070207 === UPDATE E -
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_KATA, strSQL)
		
		'内容取得
		If CF_Ora_EOF(Usr_Ody_KATA) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strRtn = CF_Ora_GetDyn(Usr_Ody_KATA, "RTN", "")
		End If
		
		If Trim(strRtn) <> "" Then
			CF_Chk_CLMDL = 0
		End If
		
End_CF_Chk_CLMDL: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_KATA)
		
		Exit Function
		
Err_CF_Chk_CLMDL: 
		GoTo End_CF_Chk_CLMDL
		
	End Function
	' === 20061213 === INSERT E -
	
	' === 20061217 === INSERT S - ACE)Nagasawa 引当内訳ファイルの更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_DTLTRA_Update_MainJDN
	'   概要：  引当内訳ファイル更新(メイン処理)
	'   引数：　pm_strMotoDatNo  : 伝票管理番号(旧)
	'           pm_strDatNo      : 伝票管理番号(新)
	'           pm_strErrCd      : 更新異常エラーコード
	'           pm_All            : 画面情報
	'   戻値：　0:正常  9:異常
	'   備考：  受注用
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_DTLTRA_Update_MainJDN(ByVal pm_strMotoDatNo As String, ByVal pm_strDATNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim intCnt As Short
		Dim intRet As Short
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strJDNNO_NEW As String
		Dim strLINNO_NEW As String
		Dim strODNYTDT_NEW As String
		Dim strJDNNO_OLD As String
		Dim strLINNO_OLD As String
		Dim strODNYTDT_OLD As String
		
		On Error GoTo CF_DTLTRA_Update_MainJDN_Err
		CF_DTLTRA_Update_MainJDN = 9
		
		'ＳＱＬ編集
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        NEW.JDNNO             AS JDNNO_NEW " '受注番号（新）
		strSQL = strSQL & "      , NVL(NEW.LINNO, '000') AS LINNO_NEW " '行番号（新）
		strSQL = strSQL & "      , NEW.ODNYTDT           AS ODNYTDT_NEW " '出荷予定日（新）
		strSQL = strSQL & "      , OLD.JDNNO             AS JDNNO_OLD " '受注番号（旧）
		strSQL = strSQL & "      , OLD.LINNO             AS LINNO_OLD " '行番号（旧）
		strSQL = strSQL & "      , OLD.ODNYTDT           AS ODNYTDT_OLD " '出荷予定日（旧）
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        JDNTRA NEW "
		strSQL = strSQL & "      , JDNTRA OLD "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        OLD.JDNNO     = NEW.JDNNO (+) "
		strSQL = strSQL & "    AND OLD.RECNO     = NEW.RECNO (+) "
		strSQL = strSQL & "    AND OLD.DATNO     = '" & CF_Ora_String(pm_strMotoDatNo, 10) & "' "
		strSQL = strSQL & "    AND NEW.DATNO (+) = '" & CF_Ora_String(pm_strDATNO, 10) & "' "
		strSQL = strSQL & "  ORDER BY "
		strSQL = strSQL & "        LINNO_NEW ASC "
		strSQL = strSQL & "      , LINNO_OLD ASC "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		'取得データより引当内訳ファイルの更新を行う
		Do Until CF_Ora_EOF(Usr_Ody) = True
			'データ取得
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strJDNNO_NEW = Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO_NEW", "")) '受注番号（新）
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strLINNO_NEW = Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO_NEW", "")) '行番号（新）
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strODNYTDT_NEW = Trim(CF_Ora_GetDyn(Usr_Ody, "ODNYTDT_NEW", "")) '出荷予定日（新）
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strJDNNO_OLD = Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO_OLD", "")) '受注番号（旧）
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strLINNO_OLD = Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO_OLD", "")) '行番号（旧）
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strODNYTDT_OLD = Trim(CF_Ora_GetDyn(Usr_Ody, "ODNYTDT_OLD", "")) '出荷予定日（旧）
			
			Select Case True
				'削除された明細
				Case strLINNO_NEW = "000"
					'引当内訳ファイル削除
					' === 20070126 === UPDATE S - ACE)Nagasawa
					'                intRet = CF_DTLTRA_Delete(strJDNNO_OLD, _
					''                                          "", _
					''                                          strLINNO_OLD, _
					''                                          pm_strErrCd, _
					''                                          pm_All)
					intRet = CF_DTLTRA_Delete(gc_strDTLTRA_TRAKB_JDN, strJDNNO_OLD, "", strLINNO_OLD, pm_strErrCd, pm_All)
					' === 20070126 === UPDATE E -
					
					'出荷予定日、または行番号が変わった場合
				Case (strLINNO_NEW <> strLINNO_OLD Or strODNYTDT_NEW <> strODNYTDT_OLD)
					'引当内訳ファイル更新
					' === 20070126 === UPDATE S - ACE)Nagasawa
					'                intRet = CF_DTLTRA_Update(strJDNNO_OLD, _
					''                                          "", _
					''                                          strLINNO_OLD, _
					''                                          strLINNO_NEW, _
					''                                          strODNYTDT_NEW, _
					''                                          pm_strErrCd, _
					''                                          pm_All)
					intRet = CF_DTLTRA_Update(gc_strDTLTRA_TRAKB_JDN, strJDNNO_OLD, "", strLINNO_OLD, strLINNO_NEW, strODNYTDT_NEW, pm_strErrCd, pm_All)
					' === 20070126 === UPDATE E -
					
				Case Else
			End Select
			
			'次データ読込
			Call CF_Ora_MoveNext(Usr_Ody)
		Loop 
		
		CF_DTLTRA_Update_MainJDN = 0
		
CF_DTLTRA_Update_MainJDN_End: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
CF_DTLTRA_Update_MainJDN_Err: 
		GoTo CF_DTLTRA_Update_MainJDN_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_DTLTRA_Update
	'   概要：  引当内訳ファイル更新処理
	'   引数：　pm_strTRAKB     : トラン種別
	'           pm_strTRANO     : トラン番号
	'           pm_strMITNOV    : 版数
	'           pm_strLINNO_OLD : 行番号(更新前)
	'           pm_strLINNO_NEW : 行番号(更新後)
	'           pm_strODNYTDT   : 出荷予定日
	'           pm_strErrCd     : 更新異常エラーコード
	'  　     　pm_All       　 : 画面情報
	'   戻値：　0:正常  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070126 === UPDATE S - ACE)Nagasawa
	'Public Function CF_DTLTRA_Update(ByVal pm_strTRANO As String, _
	''                                 ByVal pm_strMITNOV As String, _
	''                                 ByVal pm_strLINNO_OLD As String, _
	''                                 ByVal pm_strLINNO_NEW As String, _
	''                                 ByVal pm_strODNYTDT As String, _
	''                                 ByVal pm_strErrCd As String, _
	''                                 ByRef pm_All As Cls_All) As Integer
	Public Function CF_DTLTRA_Update(ByVal pm_strTRAKB As String, ByVal pm_strTRANO As String, ByVal pm_strMITNOV As String, ByVal pm_strLINNO_OLD As String, ByVal pm_strLINNO_NEW As String, ByVal pm_strODNYTDT As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		' === 20070126 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Update_Err
		
		CF_DTLTRA_Update = 9
		
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "    SET "
		strSQL = strSQL & "        LINNO   = '" & CF_Ora_String(pm_strLINNO_NEW, 3) & "' "
		strSQL = strSQL & "      , TRADT   = '" & CF_Ora_Date(pm_strODNYTDT) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "      , OPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
		strSQL = strSQL & "      , CLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
		strSQL = strSQL & "      , WRTTM   = '" & GV_SysTime & "' "
		strSQL = strSQL & "      , WRTDT   = '" & GV_SysDate & "' "
		' === 20070126 === INSERT E -
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
		strSQL = strSQL & "    AND MITNOV  = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO_OLD, 3) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(pm_strTRAKB, 1) & "' "
		' === 20070126 === INSERT E -
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Update_Err
		End If
		
		CF_DTLTRA_Update = 0
		
CF_DTLTRA_Update_End: 
		Exit Function
		
CF_DTLTRA_Update_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Update")
		GoTo CF_DTLTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_DTLTRA_Delete
	'   概要：  引当内訳ファイル削除処理
	'   引数：　pm_strTRAKB     : トラン種別
	'           pm_strTRANO     : 見積番号
	'           pm_strMITNOV    : 見積番号版数
	'           pm_strLINNO     : 行番号(更新前)
	'           pm_strErrCd     : 更新異常エラーコード
	'  　     　pm_All          : 画面情報
	'   戻値：　0:正常  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070126 === UPDATE S - ACE)Nagasawa
	'Public Function CF_DTLTRA_Delete(ByVal pm_strTRANO As String, _
	''                                 ByVal pm_strMITNOV As String, _
	''                                 ByVal pm_strLINNO As String, _
	''                                 ByVal pm_strErrCd As String, _
	''                                 ByRef pm_All As Cls_All) As Integer
	Public Function CF_DTLTRA_Delete(ByVal pm_strTRAKB As String, ByVal pm_strTRANO As String, ByVal pm_strMITNOV As String, ByVal pm_strLINNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		' === 20070126 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Delete_Err
		
		CF_DTLTRA_Delete = 9
		
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
		strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(pm_strTRAKB, 1) & "' "
		' === 20070126 === INSERT E -
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Delete_Err
		End If
		
		CF_DTLTRA_Delete = 0
		
CF_DTLTRA_Delete_End: 
		Exit Function
		
CF_DTLTRA_Delete_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Delete")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_DTLTRA_Update_Ins
	'   概要：  引当内訳ファイル更新処理
	'   引数：　pm_strTRANO_NEW   : トラン番号(新)
	'  　     　pm_strMITNOV_NEW  : 版数(新)
	'  　     　pm_strLINNO_NEW   : 行番号(新)
	'  　     　pm_strTRADT       : 出荷予定日(新)
	'   　      pm_strTRANO_NEW   : トラン番号(旧)
	'  　     　pm_strMITNOV_NEW  : 版数(旧)
	'  　     　pm_strLINNO_NEW   : 行番号(旧)
	'  　     　Pm_strPUDLNO      : 入出庫番号
	'  　     　pm_strErrCd   　　: 更新異常エラーコード
	'  　     　pm_All        : 画面情報
	'   戻値：　0:正常  9:異常
	'   備考：  受注登録時の更新処理(見積の仮引当を受注に付け替える処理）
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070126 === UPDATE S - ACE)Nagasawa
	'Public Function CF_DTLTRA_Update_Ins(ByVal pm_strTRANO_NEW As String, _
	''                                      ByVal pm_strMITNOV_NEW As String, _
	''                                      ByVal pm_strLINNO_NEW As String, _
	''                                      ByVal pm_strTRADT As String, _
	''                                      ByVal pm_strTRANO_OLD As String, _
	''                                      ByVal pm_strMITNOV_OLD As String, _
	''                                      ByVal pm_strLINNO_OLD As String, _
	''                                      ByVal pm_strErrCd As String, _
	''                                      ByRef pm_All As Cls_All) As Integer
	Public Function CF_DTLTRA_Update_Ins(ByVal pm_strTRANO_NEW As String, ByVal pm_strMITNOV_NEW As String, ByVal pm_strLINNO_NEW As String, ByVal pm_strTRADT As String, ByVal pm_strTRANO_OLD As String, ByVal pm_strMITNOV_OLD As String, ByVal pm_strLINNO_OLD As String, ByVal Pm_strPUDLNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		' === 20070126 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Update_Ins_Err
		
		CF_DTLTRA_Update_Ins = 9
		
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "    SET "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO_NEW, 20) & "' "
		strSQL = strSQL & "      , MITNOV  = '" & CF_Ora_String(pm_strMITNOV_NEW, 2) & "' "
		strSQL = strSQL & "      , LINNO   = '" & CF_Ora_String(pm_strLINNO_NEW, 3) & "' "
		strSQL = strSQL & "      , TRADT   = '" & CF_Ora_Date(pm_strTRADT) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "      , TRAKB   = '" & CF_Ora_String(gc_strDTLTRA_TRAKB_JDN, 1) & "' "
		strSQL = strSQL & "      , PUDLNO  = '" & CF_Ora_String(Pm_strPUDLNO, 10) & "' "
		strSQL = strSQL & "      , OPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
		strSQL = strSQL & "      , CLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
		strSQL = strSQL & "      , WRTTM   = '" & GV_SysTime & "' "
		strSQL = strSQL & "      , WRTDT   = '" & GV_SysDate & "' "
		' === 20070126 === INSERT E -
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO_OLD, 20) & "' "
		strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV_OLD, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO_OLD, 3) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(gc_strDTLTRA_TRAKB_MIT, 1) & "' "
		' === 20070126 === INSERT E -
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Update_Ins_Err
		End If
		
		CF_DTLTRA_Update_Ins = 0
		
CF_DTLTRA_Update_Ins_End: 
		Exit Function
		
CF_DTLTRA_Update_Ins_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Update_Ins")
		GoTo CF_DTLTRA_Update_Ins_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_DTLTRA_Delete_Ins
	'   概要：  引当内訳ファイル削除処理
	'   引数：  pm_strTRAKB   : トラン種別
	'  　     　pm_strTRANO   : トラン番号
	'  　     　pm_strMITNOV  : 版数
	'  　     　pm_strLINNO   : 行番号
	'  　     　pm_strErrCd   : 更新異常エラーコード
	'  　     　pm_All        : 画面情報
	'   戻値：　0:正常  9:異常
	'   備考：  受注登録時の削除処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070126 === UPDATE S - ACE)Nagasawa
	'Public Function CF_DTLTRA_Delete_Ins(ByVal pm_strTRANO As String, _
	''                                      ByVal pm_strMITNOV As String, _
	''                                      ByVal pm_strLINNO As String, _
	''                                      ByVal pm_strErrCd As String, _
	''                                      ByRef pm_All As Cls_All) As Integer
	Public Function CF_DTLTRA_Delete_Ins(ByVal pm_strTRAKB As String, ByVal pm_strTRANO As String, ByVal pm_strMITNOV As String, ByVal pm_strLINNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		' === 20070126 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Delete_Ins_Err
		
		CF_DTLTRA_Delete_Ins = 9
		
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
		strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(pm_strTRAKB, 1) & "' "
		' === 20070126 === INSERT E -
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Delete_Ins_Err
		End If
		
		CF_DTLTRA_Delete_Ins = 0
		
CF_DTLTRA_Delete_Ins_End: 
		Exit Function
		
CF_DTLTRA_Delete_Ins_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Delete_Ins")
		
	End Function
	' === 20061217 === INSERT E -
	
	' === 20061217 === INSERT S - ACE)Nagasawa
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_TNADL53
	'   概要：  推定在庫照会用PL/SQL実行処理
	'   引数：　なし
	'   戻値：　戻り値
	'   備考：  PL/SQLを実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_TNADL53(ByRef pin_strHINCD As String, ByRef pin_strSOUCD As String, ByRef pin_curRELZAISU As Decimal) As Short
		
		Dim strSQL As String 'SQL文
		Dim strPara1 As String 'ﾊﾟﾗﾒｰﾀ1
		Dim strPara2 As String 'ﾊﾟﾗﾒｰﾀ2
		Dim strPara3 As String 'ﾊﾟﾗﾒｰﾀ3
		Dim strPara4 As String 'ﾊﾟﾗﾒｰﾀ4
		Dim lngPara5 As Integer 'ﾊﾟﾗﾒｰﾀ5
		Dim strPara6 As String 'ﾊﾟﾗﾒｰﾀ6
		Dim lngPara7 As Integer 'ﾊﾟﾗﾒｰﾀ7
		Dim lngPara8 As Integer 'ﾊﾟﾗﾒｰﾀ8
		Dim strPara9 As String 'ﾊﾟﾗﾒｰﾀ9
		Dim lngPara10 As Integer 'ﾊﾟﾗﾒｰﾀ10
		Dim lngPara11 As Integer 'ﾊﾟﾗﾒｰﾀ11
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(12) As OraParameter 'PL/SQLのバインド変数
		
		'受渡し変数初期設定
		strPara1 = Inp_Inf.InpTanCd '入力担当者コード
		strPara2 = Inp_Inf.InpCLIID 'クライアントID
		strPara3 = CF_Ora_String(pin_strHINCD, 10) '製品コード
		strPara4 = CF_Ora_String(pin_strSOUCD, 3) '倉庫コード
		lngPara5 = pin_curRELZAISU '現在在庫数
		strPara6 = CF_Ora_String(SSS_PrgId, 10)
		lngPara7 = 0
		lngPara8 = 0
		strPara9 = ""
		lngPara10 = 0
		lngPara10 = 0
		
		'パラメータの初期設定を行う（バインド変数）
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		
		'データ型をオブジェクトにセット
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11) = gv_Odb_USR1.Parameters("P11")
		
		'各オブジェクトのデータ型を設定
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11).serverType = ORATYPE_NUMBER
		
		'PL/SQL呼び出しSQL
		strSQL = "BEGIN PRC_TNADL53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11); End;"
		
		'DBアクセス
		Call CF_Ora_Execute(gv_Odb_USR1, strSQL)
		
		'** 戻り値取得
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara7 = param(7).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara8 = param(8).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strPara9 = param(9).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara10 = param(10).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara11 = param(11).Value
		
		'戻り値設定
		AE_Execute_PLSQL_TNADL53 = lngPara7
		
		'** パラメタ解消
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P11")
		
	End Function
	' === 20061217 === INSERT E -
	
	' === 20061219 === INSERT S - ACE)Nagasawa 在庫数チェックの変更
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_INPSU_ZAISU
	'   概要：  在庫数チェック処理
	'   引数：  pm_strHINCD    : 製品コード
	'  　     　pm_curUODSU    : チェック対象数量(出荷実績数＋出荷指示数はﾏｲﾅｽしておく)
	'  　     　pm_strJDNINKB  : 受注取込種別
	'  　     　pm_All         : 画面情報
	'           pm_strTHNSOUCD : 通販倉庫コード
	'   戻値：　0:ﾁｪｯｸOK 1:現在庫ﾁｪｯｸNG 2:有効在庫ﾁｪｯｸNG 3:安全在庫ﾁｪｯｸNG 9:異常
	'   備考：　チェック対象数量に対して、在庫が足りているかをチェックする
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_INPSU_ZAISU(ByVal pm_strHINCD As String, ByVal pm_curCHKSU As Decimal, ByVal pm_strJDNINKB As String, ByRef pm_All As Cls_All, Optional ByVal pm_strTHNSOUCD As String = "") As Short
		
		Dim strSQL As String
		Dim strSOUCD As String
		Dim bolRet As Boolean
		Dim Mst_Inf_HINMTA As TYPE_DB_HINMTA
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim curRELZAISU As Decimal
		Dim curHIKSU As Decimal
		Dim bolDyn_Open As Boolean
		
		On Error GoTo CF_Chk_INPSU_ZAISU_Err
		
		CF_Chk_INPSU_ZAISU = 9
		
		curRELZAISU = 0
		curHIKSU = 0
		bolDyn_Open = False
		
		If Trim(pm_strHINCD) = "" Then
			CF_Chk_INPSU_ZAISU = 0
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'製品コードより商品マスタ検索
		Call DB_HINMTA_Clear(Mst_Inf_HINMTA)
		If DSPHINCD_SEARCH(pm_strHINCD, Mst_Inf_HINMTA) = 9 Then
			Exit Function
		End If
		
		'在庫管理しないものはチェックしない
		If Mst_Inf_HINMTA.ZAIKB = gc_strZAIKB_NG Then
			CF_Chk_INPSU_ZAISU = 0
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'倉庫コード判定
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			strSOUCD = Trim(pm_strTHNSOUCD)
		Else
			strSOUCD = Trim(Mst_Inf_HINMTA.TNACM)
		End If
		
		'倉庫別在庫マスタ検索
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        RELZAISU "
		strSQL = strSQL & "      , HIKSU "
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        HINMTB "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        SOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
		strSQL = strSQL & "    AND HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		
		'SQL実行
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		bolDyn_Open = True
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curRELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curHIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0)
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		bolDyn_Open = False
		
		'現在庫チェック
		If (curRELZAISU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU = 1
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'有効在庫チェック
		If (curRELZAISU - curHIKSU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU = 2
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'通販は安全在庫数チェックは行わない
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			CF_Chk_INPSU_ZAISU = 0
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'安全在庫数チェック
		If ((curRELZAISU) - curHIKSU - pm_curCHKSU) - Mst_Inf_HINMTA.ANZZAISU < 0 Then
			CF_Chk_INPSU_ZAISU = 3
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		CF_Chk_INPSU_ZAISU = 0
		
CF_Chk_INPSU_ZAISU_End: 
		
		If bolDyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
		End If
		
		Exit Function
		
CF_Chk_INPSU_ZAISU_Err: 
		GoTo CF_Chk_INPSU_ZAISU_End
		
	End Function
	' === 20061219 === INSERT E -
	
	' === 20070208 === INSERT S - ACE)Nagasawa 在庫数チェックの変更Ver2
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_INPSU_ZAISU_2
	'   概要：  在庫数チェック処理
	'   引数：  pm_strHINCD    : 製品コード
	'  　     　pm_curUODSU    : チェック対象数量(出荷実績数はﾏｲﾅｽしておく)
	'  　     　pm_curMNSSU    : 控除数量(見積登録の場合は参照元見積数量
	'  　     　　　　　　　　　 　　　　 見積訂正の場合は元見積数量
	'  　     　　　　　　　　　 　　　　 受注登録の場合は仮引当数
	'  　     　　　　　　　　　 　　　　 受注訂正の場合は元数量－（出荷実績数）)
	'  　     　pm_strJDNINKB  : 受注取込種別（見積のチェックの際は"0"）
	'  　     　pm_All         : 画面情報
	'           pm_strTHNSOUCD : 通販倉庫コード
	'   戻値：　0:ﾁｪｯｸOK 1:現在庫ﾁｪｯｸNG 2:有効在庫ﾁｪｯｸNG 3:安全在庫ﾁｪｯｸNG 9:異常
	'   備考：　チェック対象数量に対して、在庫が足りているかをチェックする
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_INPSU_ZAISU_2(ByVal pm_strHINCD As String, ByVal pm_curCHKSU As Decimal, ByVal pm_curMNSSU As Decimal, ByVal pm_strJDNINKB As String, ByRef pm_All As Cls_All, Optional ByVal pm_strTHNSOUCD As String = "") As Short
		
		Dim strSQL As String
		Dim strSOUCD As String
		Dim strTHNSOUCD As String
		Dim bolRet As Boolean
		Dim Mst_Inf_HINMTA As TYPE_DB_HINMTA
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim curRELZAISU As Decimal
		Dim curHIKSU As Decimal
		Dim bolDyn_Open As Boolean
		
		On Error GoTo CF_Chk_INPSU_ZAISU_2_Err
		
		CF_Chk_INPSU_ZAISU_2 = 9
		
		curRELZAISU = 0
		curHIKSU = 0
		bolDyn_Open = False
		
		If Trim(pm_strHINCD) = "" Then
			CF_Chk_INPSU_ZAISU_2 = 0
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'//////////////////////////////////////////////////
		'/ マスタ系のチェック
		'//////////////////////////////////////////////////
		
		'製品コードより商品マスタ検索
		Call DB_HINMTA_Clear(Mst_Inf_HINMTA)
		If DSPHINCD_SEARCH(pm_strHINCD, Mst_Inf_HINMTA) = 9 Then
			Exit Function
		End If
		
		'在庫管理しないものはチェックしない
		If Mst_Inf_HINMTA.ZAIKB = gc_strZAIKB_NG Then
			CF_Chk_INPSU_ZAISU_2 = 0
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'倉庫コード判定
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			strSOUCD = Trim(pm_strTHNSOUCD)
			strTHNSOUCD = Trim(pm_strTHNSOUCD)
		Else
			strSOUCD = Trim(Mst_Inf_HINMTA.TNACM)
			
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        SOUCD "
			strSQL = strSQL & "   FROM "
			strSQL = strSQL & "        SOUMTA "
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        SOUKOKB = '02' "
			'SQL実行
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			bolDyn_Open = True
			If CF_Ora_EOF(Usr_Ody) = False Then
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strTHNSOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")
			End If
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			bolDyn_Open = False
		End If
		
		'倉庫別在庫マスタ検索
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        RELZAISU "
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        HINMTB "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        SOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
		strSQL = strSQL & "    AND HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		
		'SQL実行
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		bolDyn_Open = True
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curRELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0)
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		bolDyn_Open = False
		
		'//////////////////////////////////////////////////
		'/ 見積（仮引当）分の見積数の合計
		'//////////////////////////////////////////////////
		'通販以外のときのみ
		If Trim(pm_strJDNINKB) <> gc_strJDNINKB_ML Then
			'見積検索
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        SUM(TRA.MITSU) YTSU "
			strSQL = strSQL & "   FROM "
			strSQL = strSQL & "        MITTHA THA "
			strSQL = strSQL & "       ,MITTRA TRA "
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        THA.DATNO = TRA.DATNO "
			strSQL = strSQL & "    AND THA.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "    AND THA.JDNNO = '          ' "
			strSQL = strSQL & "    AND TRA.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "    AND TRA.HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
			strSQL = strSQL & "    AND TRA.KHIKKB = '1' "
			'SQL実行
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			bolDyn_Open = True
			If CF_Ora_EOF(Usr_Ody) = False Then
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
			End If
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			bolDyn_Open = False
		End If
		
		'//////////////////////////////////////////////////
		'/ 受注分の（受注数 - 実績数）の合計
		'//////////////////////////////////////////////////
		'受注検索
		strSQL = ""
		' === 20081210 === UPDATE S - ACE)Nagasawa レスポンス対応
		'D    strSQL = strSQL & " SELECT "
		'D    strSQL = strSQL & "        SUM(TRA.UODSU - TRA.OTPSU) YTSU "
		'D    strSQL = strSQL & "   FROM "
		'D    strSQL = strSQL & "        JDNTHA THA "
		'D    strSQL = strSQL & "       ,JDNTRA TRA "
		'D    strSQL = strSQL & "       ,( SELECT MAX(DATNO) As DATNO "
		'D    strSQL = strSQL & "                ,JDNNO "
		'D    strSQL = strSQL & "          FROM   JDNTHA "
		'D    strSQL = strSQL & "          WHERE  JDNENDKB = '0' "
		'D    strSQL = strSQL & "          GROUP BY JDNNO "
		'D    strSQL = strSQL & "        ) THB "
		'D    strSQL = strSQL & "       ,( SELECT MAX(DATNO) As DATNO "
		'D    strSQL = strSQL & "                ,JDNNO "
		'D    strSQL = strSQL & "                ,LINNO "
		'D    strSQL = strSQL & "          FROM   JDNTRA "
		'D    strSQL = strSQL & "          WHERE  DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		'D    strSQL = strSQL & "            AND  HINCD  = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		'D    strSQL = strSQL & "            AND  UODSU > OTPSU "
		'D    strSQL = strSQL & "          GROUP BY JDNNO "
		'D    strSQL = strSQL & "                  ,LINNO "
		'D    strSQL = strSQL & "        ) TRB "
		'D    strSQL = strSQL & "  WHERE "
		'D    strSQL = strSQL & "        THA.DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		'D    strSQL = strSQL & "    AND THA.AKAKROKB = '1' "
		'D    strSQL = strSQL & "    AND THA.DATNO    = THB.DATNO "
		'D    strSQL = strSQL & "    AND THA.JDNNO    = THB.JDNNO "
		'D    strSQL = strSQL & "    AND TRA.DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		'D    strSQL = strSQL & "    AND TRA.AKAKROKB = '1' "
		'D    strSQL = strSQL & "    AND TRA.DATNO    = TRB.DATNO "
		'D    strSQL = strSQL & "    AND TRA.JDNNO    = TRB.JDNNO "
		'D    strSQL = strSQL & "    AND TRA.LINNO    = TRB.LINNO "
		'D    strSQL = strSQL & "    AND THA.DATNO    = TRA.DATNO "
		'D    strSQL = strSQL & "    AND THA.JDNTRKB  IN ( '01', '11', '21' ) "
		'D    strSQL = strSQL & "    AND TRA.HINCD    = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		'D    strSQL = strSQL & "    AND TRA.JDNKB    IN ( '1', '2' ) "
		'D    '通販時は通販倉庫
		'D    If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
		'D        strSQL = strSQL & " AND TRA.SOUCD = '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
		'D    Else
		'D        strSQL = strSQL & " AND TRA.SOUCD <> '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
		'D    End If
		
		strSQL = ""
		strSQL = strSQL & " SELECT TRA.JDNKB               JDNKB "
		strSQL = strSQL & "      , (TRA.UODSU - TRA.OTPSU) YTSU  "
		strSQL = strSQL & " FROM  "
		strSQL = strSQL & "      (SELECT THB.DATNO "
		strSQL = strSQL & "            , THB.JDNNO "
		strSQL = strSQL & "            , THB.JDNENDKB "
		strSQL = strSQL & "            , THB.JDNTRKB  "
		strSQL = strSQL & "         FROM JDNTHA THB  "
		strSQL = strSQL & "        WHERE EXISTS (SELECT DATNO  "
		strSQL = strSQL & "                        FROM JDNTHC THC  "
		strSQL = strSQL & "                       WHERE THB.DATNO = THC.DATNO  "
		strSQL = strSQL & "                         AND THB.JDNNO = THC.JDNNO)  "
		strSQL = strSQL & "          AND THB.JDNENDKB = '0'  "
		strSQL = strSQL & "          AND THB.JDNTRKB IN ('01' "
		strSQL = strSQL & "                           ,  '11' "
		strSQL = strSQL & "                           ,  '21') "
		strSQL = strSQL & "      ) THA, "
		'''' UPD 2009/02/27  FKS) S.Nakajima    Start
		'    strSQL = strSQL & "      (SELECT TRB.DATNO "
		strSQL = strSQL & "      (SELECT /*+ INDEX (TRB X_JDNTRA94) */ TRB.DATNO "
		'''' UPD 2009/02/27  FKS) S.Nakajima    End
		strSQL = strSQL & "            , TRB.JDNNO "
		strSQL = strSQL & "            , TRB.LINNO "
		strSQL = strSQL & "            , TRB.DATKB "
		strSQL = strSQL & "            , TRB.AKAKROKB "
		strSQL = strSQL & "            , TRB.JDNKB "
		strSQL = strSQL & "            , TRB.HINKB "
		strSQL = strSQL & "            , TRB.HINCD "
		strSQL = strSQL & "            , TRB.SOUCD "
		strSQL = strSQL & "            , TRB.UODSU "
		strSQL = strSQL & "            , TRB.OTPSU  "
		strSQL = strSQL & "         FROM JDNTRA TRB  "
		strSQL = strSQL & "        WHERE EXISTS (SELECT TRC.DATNO  "
		strSQL = strSQL & "                        FROM JDNTHC TRC  "
		strSQL = strSQL & "                       WHERE TRC.DATNO = TRB.DATNO  "
		strSQL = strSQL & "                         AND TRC.JDNNO = TRB.JDNNO) "
		strSQL = strSQL & "          AND TRB.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "          AND TRB.HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		'''' UPD 2009/02/27  FKS) S.Nakajima    Start
		'    strSQL = strSQL & "          AND TRB.UODSU > TRB.OTPSU  "
		strSQL = strSQL & "          AND TRB.UODSU - TRB.OTPSU > 0  "
		'''' UPD 2009/02/27  FKS) S.Nakajima    End
		
		'通販時は通販倉庫
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			strSQL = strSQL & "          AND TRB.SOUCD = '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
		Else
			strSQL = strSQL & "          AND TRB.SOUCD <> '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
		End If
		
		strSQL = strSQL & "      ) TRA  "
		strSQL = strSQL & " WHERE     THA.DATNO = TRA.DATNO  "
		' === 20081210 === UPDATE E -
		
		'SQL実行
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		bolDyn_Open = True
		' === 20081210 === UPDATE S - ACE)Nagasawa レスポンス対応
		'D    If CF_Ora_EOF(Usr_Ody) = False Then
		'D        curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
		'D    End If
		
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(CF_Ora_GetDyn(Usr_Ody, "JDNKB", "")) = "1" Or Trim(CF_Ora_GetDyn(Usr_Ody, "JDNKB", "")) = "2" Then
				
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
			End If
			
			Call CF_Ora_MoveNext(Usr_Ody)
		Loop 
		' === 20081210 === UPDATE E -
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		bolDyn_Open = False
		
		'//////////////////////////////////////////////////
		'/ 支給品分の（予定数 - 実績数）の合計
		'//////////////////////////////////////////////////
		'通販以外のときのみ
		If Trim(pm_strJDNINKB) <> gc_strJDNINKB_ML Then
			'支給品検索
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        SUM(OUTYOTSU - OUTZMISU) YTSU "
			strSQL = strSQL & "   FROM "
			strSQL = strSQL & "        SKYTBL "
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "    AND HINCD  = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
			strSQL = strSQL & "    AND PLANKB = ' ' "
			'SQL実行
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			bolDyn_Open = True
			If CF_Ora_EOF(Usr_Ody) = False Then
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
			End If
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			bolDyn_Open = False
		End If
		
		'//////////////////////////////////////////////////
		'/ 製番出庫の（予定数 - 実績数）の合計
		'//////////////////////////////////////////////////
		'通販以外のときのみ
		If Trim(pm_strJDNINKB) <> gc_strJDNINKB_ML Then
			'製番出庫検索
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        SUM(FRDYTSU - OUTSMSU) YTSU "
			strSQL = strSQL & "   FROM "
			strSQL = strSQL & "        SBNTRA "
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "    AND HINCD  = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
			strSQL = strSQL & "    AND OUTSOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
			'SQL実行
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			bolDyn_Open = True
			If CF_Ora_EOF(Usr_Ody) = False Then
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
			End If
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			bolDyn_Open = False
		End If
		
		'出荷予定数の補正
		curHIKSU = curHIKSU - pm_curMNSSU
		
		
		'//////////////////////////////////////////////////
		'/ 各種チェック
		'//////////////////////////////////////////////////
		'現在庫チェック
		If (curRELZAISU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU_2 = 1
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'有効在庫チェック
		If (curRELZAISU - curHIKSU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU_2 = 2
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'通販は安全在庫数チェックは行わない
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			CF_Chk_INPSU_ZAISU_2 = 0
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'安全在庫数チェック
		If ((curRELZAISU) - curHIKSU - pm_curCHKSU) - Mst_Inf_HINMTA.ANZZAISU < 0 Then
			CF_Chk_INPSU_ZAISU_2 = 3
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		CF_Chk_INPSU_ZAISU_2 = 0
		
CF_Chk_INPSU_ZAISU_2_End: 
		
		If bolDyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
		End If
		
		Exit Function
		
CF_Chk_INPSU_ZAISU_2_Err: 
		GoTo CF_Chk_INPSU_ZAISU_2_End
		
	End Function
	' === 20070208 === INSERT E -
	
	'ADD START FKS)INABA 2009/09/04
	'新入金対応
	'引数　　ps_JDNNO　   受注№
	'        ps_JDNLINNO  受注行№
	'　　　　pv_ChkKIN　　チェック金額(受注金額)
	'戻り値　1:チェック金額(受注金額)が消込金額以上
	'　　　　2:前受金あり
	Public Function CF_NYUKN_MAEUKE_CHK(ByRef ps_JDNNO As String, ByRef ps_JDNLINNO As String, Optional ByRef pv_ChkKIN As Object = Nothing) As Short
		Dim ls_sql As String
		Dim bolRet As Boolean
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim bolDyn_Open As Boolean
		'Dim lv_JKESIKN          As Variant
		Dim lv_NYUKN As Object
		On Error GoTo ERR_HANDLE
		'    lv_JKESIKN = 0
		'UPGRADE_WARNING: オブジェクト lv_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lv_NYUKN = 0
		''消込済チェック
		'    ls_sql = " SELECT SUM(NVL(JKESIKN,0)) JKESIKN_SUM "
		'    ls_sql = ls_sql & " FROM UDNTRA "
		'    ls_sql = ls_sql & " WHERE DATKB = '1' "
		'    ls_sql = ls_sql & "   AND DENKB = '1' "
		'    ls_sql = ls_sql & "   AND JDNNO= '" & Trim$(ps_JDNNO) & "' "
		'    ls_sql = ls_sql & "   AND JDNLINNO= '" & Trim$(ps_JDNLINNO) & "' "
		'    ls_sql = ls_sql & " GROUP BY JDNNO ,JDNLINNO"
		'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
		'    bolDyn_Open = True
		'    If CF_Ora_EOF(Usr_Ody) = False Then
		'        lv_JKESIKN = CF_Ora_GetDyn(Usr_Ody, "JKESIKN_SUM", "")
		'    Else
		'        lv_JKESIKN = 0
		'    End If
		'    'クローズ
		'    Call CF_Ora_CloseDyn(Usr_Ody)
		'    bolDyn_Open = False
		'    If lv_JKESIKN >= pv_ChkKIN Then
		'        CF_NYUKN_MAEUKE_CHK = 1
		'    Else
		'        CF_NYUKN_MAEUKE_CHK = 0
		'    End If
		CF_NYUKN_MAEUKE_CHK = 0
		'前受金チェック
		ls_sql = " SELECT SUM(NVL(NYUKN,0)) NYUKN_SUM "
		ls_sql = ls_sql & " FROM UDNTRA "
		ls_sql = ls_sql & " WHERE DATKB = '1' "
		ls_sql = ls_sql & "   AND DENKB = '8' "
		ls_sql = ls_sql & "   AND OKRJONO = '" & Trim(ps_JDNNO) & Trim(ps_JDNLINNO) & "' "
		ls_sql = ls_sql & " GROUP BY OKRJONO "
		'SQL実行
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
		bolDyn_Open = True
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト lv_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			lv_NYUKN = CF_Ora_GetDyn(Usr_Ody, "NYUKN_SUM", "")
		Else
			'UPGRADE_WARNING: オブジェクト lv_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			lv_NYUKN = 0
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		bolDyn_Open = False
		'UPGRADE_WARNING: オブジェクト lv_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If lv_NYUKN <> 0 Then
			CF_NYUKN_MAEUKE_CHK = 2
		End If
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		CF_NYUKN_MAEUKE_CHK = -1
		GoTo EXIT_HANDLE
		
	End Function
	
	
	
	' === 20061223 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_ZIPCD
	'   概要：  郵便番号チェック処理
	'   引数：  pin_strZIPCD            : チェック対象郵便番号
	'           pin_intKETA             : 郵便番号入力可能桁数
	'           pin_intZIP_HAIHUN       : ハイフン位置（左より）
	'           pin_strFRNKB            : 海外取引区分
	'   戻値：  0 : チェックOK   9 : チェックNG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_ZIPCD(ByVal pin_strZIPCD As String, ByVal pin_intKETA As Short, ByVal pin_intZIP_HAIHUN As Short, ByVal pin_strFRNKB As String) As Short
		
		Dim intHaihun As Short
		Dim intCnt As Short
		Dim intLstHaihun As Short '最後のハイフン位置
		
		CF_Chk_ZIPCD = 9
		
		'取引先が国内の場合のみチェックを行う
		If pin_strFRNKB <> gc_strFRNKB_FRN Then
			
			'空白はOKとする
			If Trim(pin_strZIPCD) = "" Then
				CF_Chk_ZIPCD = 0
				Exit Function
			End If
			
			'桁数チェック
			If Len(pin_strZIPCD) <> pin_intKETA Then
				CF_Chk_ZIPCD = 10
				Exit Function
			End If
			
			'ハイフン位置チェック
			For intCnt = 1 To pin_intKETA
				If intCnt = pin_intZIP_HAIHUN Then
					If MidWid(pin_strZIPCD, intCnt, 1) <> "-" Then
						CF_Chk_ZIPCD = 20
						Exit Function
					End If
				Else
					If IsNumeric(MidWid(pin_strZIPCD, intCnt, 1)) = False Then
						CF_Chk_ZIPCD = 20
						Exit Function
					End If
				End If
			Next 
		End If
		
		CF_Chk_ZIPCD = 0
		
	End Function
	' === 20061223 === INSERT E -
	
	' === 20070115 === INSERT S - ACE)Nagasawa 訂正前に更新時間チェックを入れる
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_UWRTDTTM
	'   概要：  バッチ更新日付時間取得処理
	'   引数：  pin_strTBLNM            : 検索対象テーブル名
	'           pin_strDATNO            : 伝票管理番号（省略時条件に含めない）
	'           pin_strRECNO            : レコード管理番号（省略時条件に含めない）
	'           pot_strUWRTDT           : バッチ更新日付
	'           pot_strUWRTTM           : バッチ更新時刻
	'   戻値：  0 : 正常終了  9 : 異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_UWRTDTTM(ByVal pin_strTBLNM As String, ByRef pot_strUWRTDT As String, ByRef pot_strUWRTTM As String, Optional ByVal pin_strDatNo As String = "", Optional ByVal pin_strRECNO As String = "", Optional ByVal pin_strELSE As String = "") As Short
		
		On Error GoTo CF_Get_UWRTDTTM_ERR
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim Str_Where As String
		
		CF_Get_UWRTDTTM = 9
		
		'// 初期化
		pot_strUWRTDT = ""
		pot_strUWRTTM = ""
		
		'引数チェック
		If Trim(pin_strDatNo) = "" And Trim(pin_strRECNO) = "" And Trim(pin_strELSE) = "" Then
			GoTo CF_Get_UWRTDTTM_END
		End If
		
		Str_Sql = ""
		Str_Sql = Str_Sql & " SELECT "
		Str_Sql = Str_Sql & "        UWRTDT "
		Str_Sql = Str_Sql & "      , UWRTTM "
		Str_Sql = Str_Sql & "   FROM "
		Str_Sql = Str_Sql & "        " & Trim(pin_strTBLNM)
		
		'検索条件編集
		Str_Where = ""
		'伝票管理番号
		If Trim(pin_strDatNo) <> "" Then
			Str_Where = Str_Where & "        DATNO = '" & CF_Ora_String(pin_strDatNo, 10) & "' "
		End If
		
		'レコード管理番号
		If Trim(pin_strRECNO) <> "" Then
			If Trim(Str_Where) <> "" Then
				Str_Where = Str_Where & " AND "
			End If
			
			Str_Where = Str_Where & "        RECNO = '" & CF_Ora_String(pin_strRECNO, 10) & "' "
		End If
		
		'それ以外
		If Trim(pin_strELSE) <> "" Then
			If Trim(Str_Where) <> "" Then
				Str_Where = Str_Where & " AND "
			End If
			
			Str_Where = Str_Where & pin_strELSE
		End If
		
		If Trim(Str_Where) <> "" Then
			Str_Sql = Str_Sql & "  WHERE " & Str_Where
		End If
		
		' === 20080209 === INSERT S - ACE)Nagasawa 行ロック追加
		Str_Sql = Str_Sql & "  For Update "
		' === 20080209 === INSERT E -
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo CF_Get_UWRTDTTM_ERR
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strUWRTDT = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTDT"))
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strUWRTTM = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTTM"))
		End If
		
		CF_Get_UWRTDTTM = 0
		
CF_Get_UWRTDTTM_END: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
CF_Get_UWRTDTTM_ERR: 
		GoTo CF_Get_UWRTDTTM_END
		
	End Function
	' === 20070115 === INSERT E -
	
	' === 20070207 === INSERT S - ACE)Nagasawa システム受注で機器受注を入力可とする
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_PRDTBMCD
	'   概要：  生産担当コードチェック処理
	'   引数：  pm_strPRDTBMCD : 生産担当コード
	'           pm_strCMPKTCD　: コンピュータ型式コード
	'   戻値：  0  : 正常
	'           1  : 機器受注用の生産担当ではない
	'           2  : 機器受注用以外の生産担当ではない
	'   備考：　入力された生産担当コードが使用可能かどうかチェックします
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_PRDTBMCD(ByRef pm_strPRDTBMCD As String, ByRef pm_strCMPKTCD As String) As Short
		
		Dim Mst_Inf_PRDTBMCD As TYPE_DB_MEIMTA
		Dim Mst_Inf_CMPKTCD As TYPE_DB_MEIMTA
		Dim strKiki_PRDTBMCD As String
		Dim strKiki_CMPKTCD As String
		
		CF_Chk_PRDTBMCD = 0
		
		If Trim(pm_strPRDTBMCD) = "" And Trim(pm_strCMPKTCD) = "" Then
			Exit Function
		End If
		
		'名称マスタ検索（生産担当コード）
		strKiki_PRDTBMCD = gc_strPRDTBMCD_KIKI_Else
		If DSPMEIM_SEARCH(gc_strKEYCD_STANCD, pm_strPRDTBMCD, Mst_Inf_PRDTBMCD) = 0 Then
			If Mst_Inf_PRDTBMCD.DATKB = gc_strDATKB_USE Then
				strKiki_PRDTBMCD = Mst_Inf_PRDTBMCD.MEIKBB
			End If
		End If
		
		'名称マスタ検索（コンピュータ型式コード）
		strKiki_CMPKTCD = gc_strCMPKTCD_KIKI_Else
		If Trim(pm_strCMPKTCD) <> "" Then
			If DSPMEIM_SEARCH(gc_strKEYCD_CMPKTCD, pm_strCMPKTCD, Mst_Inf_CMPKTCD) = 0 Then
				If Mst_Inf_CMPKTCD.DATKB = gc_strDATKB_USE Then
					strKiki_CMPKTCD = Mst_Inf_CMPKTCD.MEIKBA
				End If
			End If
		End If
		
		'機器受注用の生産担当ではない
		If strKiki_CMPKTCD = gc_strCMPKTCD_KIKI And strKiki_PRDTBMCD = gc_strPRDTBMCD_KIKI_Else Then
			CF_Chk_PRDTBMCD = 1
			Exit Function
		End If
		
		'機器受注用以外の生産担当ではない
		If strKiki_CMPKTCD = gc_strCMPKTCD_KIKI_Else And strKiki_PRDTBMCD = gc_strPRDTBMCD_KIKI Then
			CF_Chk_PRDTBMCD = 2
			Exit Function
		End If
		
	End Function
	' === 20070207 === INSERT E -
	
	' === 20070301 === INSERT S - ACE)Nagasawa 消費税が算出できなかった場合にメッセージ表示
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_TAXKBN_TOK
	'   概要：  消費税取得用の区分チェック処理（得意先）
	'   引数：  Pin_strTOKZEIKB　: 得意先消費税区分
	'           Pin_strTOKRPSKB　: 消費税端数処理桁数
	'           Pin_strTOKZRNKB　: 消費税端数処理区分
	'           Pot_strErrMsg　　: エラーメッセージ
	'   戻値：  True : チェックOK  False : チェックNG
	'   備考：　消費税が取得できるかどうかのチェックを行います
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_TAXKBN_TOK(ByVal Pin_strTOKZEIKB As String, ByVal Pin_strTOKRPSKB As String, ByVal Pin_strTOKZRNKB As String, ByRef Pot_strErrMsg As String) As Boolean
		
		Dim strErrMsg As String
		
		CF_Chk_TAXKBN_TOK = True
		Pot_strErrMsg = ""
		strErrMsg = ""
		
		'得意先消費税区分チェック
		Select Case Trim(Pin_strTOKZEIKB)
			Case gc_strTOKZEIKB_NUK, gc_strTOKZEIKB_KOM, gc_strTOKZEIKB_HIK
			Case Else
				strErrMsg = "消費税区分"
		End Select
		
		'消費税端数処理桁数チェック
		Select Case Trim(Pin_strTOKRPSKB)
			Case gc_strTOKRPSKB_0, gc_strTOKRPSKB_10, gc_strTOKRPSKB_100
			Case Else
				If Trim(strErrMsg) <> "" Then
					strErrMsg = strErrMsg & "、"
				End If
				strErrMsg = strErrMsg & "得意先消費税端数処理"
		End Select
		
		'消費税端数処理区分チェック
		Select Case Trim(Pin_strTOKZRNKB)
			Case gc_strTOKZRNKB_DWN, gc_strTOKZRNKB_RND, gc_strTOKZRNKB_UP
			Case Else
				If InStr(1, strErrMsg, "得意先消費税端数処理") = 0 Then
					If Trim(strErrMsg) <> "" Then
						strErrMsg = strErrMsg & "、"
					End If
					strErrMsg = strErrMsg & "得意先消費税端数処理"
				End If
		End Select
		
		If Trim(strErrMsg) <> "" Then
			Pot_strErrMsg = vbCrLf & "取引先詳細登録画面で" & strErrMsg & "を確認してください。"
			CF_Chk_TAXKBN_TOK = False
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_TAXKBN_HIN
	'   概要：  消費税取得用の区分チェック処理（商品）
	'   引数：  Pin_strHINZEIKB　: 商品消費税区分
	'           Pin_strZEIRNKKB　: 消費税ランク
	'           Pot_strErrMsg　　: エラーメッセージ
	'   戻値：  True : チェックOK  False : チェックNG
	'   備考：　消費税が取得できるかどうかのチェックを行います
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_TAXKBN_HIN(ByVal Pin_strHINZEIKB As String, ByVal pin_strZEIRNKKB As String, ByRef Pot_strErrMsg As String) As Boolean
		
		Dim strErrMsg As String
		
		CF_Chk_TAXKBN_HIN = True
		Pot_strErrMsg = ""
		strErrMsg = ""
		
		'商品消費税区分チェック
		Select Case Trim(Pin_strHINZEIKB)
			Case gc_strHINZEIKB_TOK, gc_strHINZEIKB_NUK, gc_strHINZEIKB_KOM, gc_strHINZEIKB_HIK
			Case Else
				strErrMsg = "消費税区分"
		End Select
		
		'消費税ランク
		If Trim(pin_strZEIRNKKB) = "" Then
			If Trim(strErrMsg) <> "" Then
				strErrMsg = strErrMsg & "、"
			End If
			strErrMsg = strErrMsg & "消費税率"
		End If
		
		If Trim(strErrMsg) <> "" Then
			Pot_strErrMsg = vbCrLf & "商品詳細登録画面で" & strErrMsg & "を確認してください。"
			CF_Chk_TAXKBN_HIN = False
		End If
		
	End Function
	' === 20070301 === INSERT E -
	
	' === 20070307 === INSERT S - ACE)Nagasawa 売上後の入力可否制御の変更
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_GET_URIInf_DATNO
	'   概要：  更新対象売上情報の伝票管理番号取得
	'   引数：  pin_strJDNNO      : 受注番号
	'   　　　  pin_strTOKCD      : 得意先コード
	'   戻値：  0：正常　9: 異常
	'   備考：  更新対象売上情報の伝票管理番号、赤黒作成フラグを取得する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_GET_URIInf_DATNO(ByRef pin_usrUDNTHA As Cmn_UDNTHA_Upd, ByRef pin_usrUDNTRA() As Cmn_UDNTRA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim intCnt2 As Short
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy_UDNTHA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_UDNTHA As U_Ody
		'UPGRADE_WARNING: 構造体 usrOdy_UDNTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolTran As Boolean
		Dim intRet As Short
		Dim strDATNO() As String
		Dim strFDNNO() As String
		Dim bolAKAKRO() As Boolean
		Dim strSSADT() As String
		Dim strKESDT() As String
		Dim strKEYDATNO As String
		Dim curKensu As Decimal
		Dim strNXTKB As String
		Dim strSMADT As String
		Dim strSSADT_Chk As String
		Dim strKESDT_Chk As String
		Dim strUDNDT As String
		Dim strDENDT As String
		Dim strTOKSMEKB As String
		Dim strTOKSMEDD As String
		Dim strTOKSMECC As String
		Dim strTOKSDWKB As String
		Dim strTOKKESCC As String
		Dim strTOKKESDD As String
		Dim strTOKKDWKB As String
		Dim strDate As String
		Dim strJdnNo As String
		Dim strDATNO_Esc As String
		Dim strSSADT_MAX As String
		Dim strSMADT_MAX As String
		Dim strDENDT_MAX As String
		Dim strSSADT_Chk_Calc As String
		Dim strRet_HNPN As String
		Dim strODNNO_Get() As String
		Dim strUDNNO_KRO() As String
		Dim strUDNNO_AKA() As String
		' === 20070331 === INSERT S - ACE)Nagasawa 売上訂正返品対応
		Dim strFDNNO_KRO() As String
		Dim strFDNNO_AKA() As String
		' === 20070331 === INSERT E -
		Dim intODNNO_GetSu As Short
		Dim intUDNNO_GetSu As Short
		
		On Error GoTo AE_GET_URIInf_DATNO_Err
		
		AE_GET_URIInf_DATNO = 9
		
		bolTran = False
		ReDim strDATNO(0)
		ReDim strFDNNO(0)
		ReDim bolAKAKRO(0)
		ReDim strSSADT(0)
		ReDim strKESDT(0)
		ReDim strODNNO_Get(0)
		ReDim strUDNNO_KRO(0)
		ReDim strUDNNO_AKA(0)
		' === 20070331 === INSERT S - ACE)Nagasawa 売上訂正返品対応
		ReDim strFDNNO_KRO(0)
		ReDim strFDNNO_AKA(0)
		' === 20070331 === INSERT E -
		intODNNO_GetSu = 0
		intUDNNO_GetSu = 0
		
		strKEYDATNO = ""
		strJdnNo = pin_usrUDNTHA.JDNNO
		
		strSMADT_MAX = "00000000"
		strSSADT_MAX = "00000000"
		strDENDT_MAX = "00000000"
		pin_usrUDNTHA.strErr = ""
		
		'売上見出しトラン取得
		strSQL = ""
		strSQL = strSQL & " SELECT DATNO "
		strSQL = strSQL & "      , UDNNO "
		strSQL = strSQL & "      , FDNNO "
		strSQL = strSQL & "      , UDNDT "
		strSQL = strSQL & "      , DENDT "
		strSQL = strSQL & "      , NXTKB "
		strSQL = strSQL & "      , SMADT "
		strSQL = strSQL & "      , SSADT "
		strSQL = strSQL & "      , KESDT "
		strSQL = strSQL & "      , TOKSMEKB "
		strSQL = strSQL & "      , TOKSMEDD "
		strSQL = strSQL & "      , TOKSMECC "
		strSQL = strSQL & "      , TOKSDWKB "
		strSQL = strSQL & "      , TOKKESCC "
		strSQL = strSQL & "      , TOKKESDD "
		strSQL = strSQL & "      , TOKKDWKB "
		strSQL = strSQL & "   FROM UDNTHA "
		strSQL = strSQL & "  WHERE UDNTHA.DATNO NOT IN "
		'CHG START FKS)INABA 2009/08/07 *******************************************************************************
		'連絡票№FC09080601(連絡票№747)
		strSQL = strSQL & "                     (SELECT  DECODE(TRIM(UDNTRA.DKBSB) || TRIM(UDNTRA.DKBID),'04002','          ','04006','          ',UDNTHA.MOTDATNO) MOTDATNO "
		strSQL = strSQL & "                        FROM UDNTHA ,UDNTRA "
		strSQL = strSQL & "                       WHERE UDNTHA.JDNNO = '" & CF_Ora_String(strJdnNo, 10) & "' "
		strSQL = strSQL & "                         AND UDNTHA.DATNO = UDNTRA.DATNO "
		strSQL = strSQL & "                       GROUP BY DECODE(TRIM(UDNTRA.DKBSB) || TRIM(UDNTRA.DKBID),'04002','          ','04006','          ',UDNTHA.MOTDATNO) )"
		'    strSQL = strSQL & "                     (SELECT UDNTHA.MOTDATNO "
		'    strSQL = strSQL & "                        FROM UDNTHA "
		'    strSQL = strSQL & "                       WHERE UDNTHA.JDNNO = '" & CF_Ora_String(strJdnNo, 10) & "' "
		'    strSQL = strSQL & "                       GROUP BY MOTDATNO)"
		'CHG  END  FKS)INABA 2009/08/07 *******************************************************************************
		strSQL = strSQL & "    AND UDNTHA.DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    AND UDNTHA.AKAKROKB  = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "    AND UDNTHA.JDNNO = '" & CF_Ora_String(strJdnNo, 10) & "' "
		strSQL = strSQL & "    AND UDNTHA.DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    AND UDNTHA.AKAKROKB  = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "  ORDER BY DATNO, JDNNO "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTHA, strSQL)
		If bolRet = False Then
			GoTo AE_GET_URIInf_DATNO_Err
		End If
		
		bolTran = True
		
		intCnt = 1
		Do Until CF_Ora_EOF(usrOdy_UDNTHA)
			'伝票管理番号退避
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strDATNO_Esc = CF_Ora_GetDyn(usrOdy_UDNTHA, "DATNO", "")
			
			For intCnt2 = 1 To UBound(pin_usrUDNTRA)
				'売上トラン取得
				strSQL = ""
				strSQL = strSQL & " SELECT COUNT(*)   AS CNT "
				strSQL = strSQL & "   FROM UDNTRA "
				strSQL = strSQL & "  WHERE UDNTRA.DATNO = '" & CF_Ora_String(strDATNO_Esc, 10) & "' "
				
				'受注取引区分により検索条件変更
				Select Case True
					'システム受注で出荷基準のもの、またはセットアップ受注
					Case (pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrUDNTHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SET
						strSQL = strSQL & "    AND JDNLINNO = '" & CF_Ora_String(pin_usrUDNTRA(intCnt2).LINNO, 10) & "' "
						
						'システム受注で出荷基準以外のもの
					Case pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS
						strSQL = strSQL & "    AND RECNO    = '" & CF_Ora_String(pin_usrUDNTRA(intCnt2).RECNO, 10) & "' "
						
						'上記以外
					Case Else
						strSQL = strSQL & "    AND SBNNO    = '" & CF_Ora_String(pin_usrUDNTRA(intCnt2).SBNNO, 20) & "' "
				End Select
				
				'SQL実行
				bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
				If bolRet = False Then
					GoTo AE_GET_URIInf_DATNO_Err
				End If
				
				'検索結果取得
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				curKensu = CF_Ora_GetDyn(usrOdy_UDNTRA, "CNT", 0)
				
				'クローズ
				Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
				
				If curKensu <> 0 Then
					'更新対象が存在する伝票に返品が存在するかチェック
					strRet_HNPN = AE_CHK_URIInf_HNPN(strDATNO_Esc, pin_usrUDNTHA, pin_usrUDNTRA)
					If Mid(strRet_HNPN, 2, 1) = "0" Then
						'更新対象外とする
						curKensu = 0
					End If
				End If
				
				'更新対象の明細が存在している場合
				If curKensu > 0 Then
					
					ReDim Preserve strDATNO(intCnt)
					ReDim Preserve strFDNNO(intCnt)
					ReDim Preserve bolAKAKRO(intCnt)
					ReDim Preserve strSSADT(intCnt)
					ReDim Preserve strKESDT(intCnt)
					ReDim Preserve strODNNO_Get(intCnt)
					ReDim Preserve strUDNNO_KRO(intCnt)
					ReDim Preserve strUDNNO_AKA(intCnt)
					' === 20070331 === INSERT S - ACE)Nagasawa 売上訂正返品対応
					ReDim Preserve strFDNNO_KRO(intCnt)
					ReDim Preserve strFDNNO_AKA(intCnt)
					' === 20070331 === INSERT E -
					
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strDATNO(intCnt) = CF_Ora_GetDyn(usrOdy_UDNTHA, "DATNO", "") '伝票管理番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strFDNNO(intCnt) = CF_Ora_GetDyn(usrOdy_UDNTHA, "FDNNO", "") '納品書番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strNXTKB = CF_Ora_GetDyn(usrOdy_UDNTHA, "NXTKB", "") '帳端区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strUDNDT = CF_Ora_GetDyn(usrOdy_UDNTHA, "UDNDT", "") '伝票日付
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strDENDT = CF_Ora_GetDyn(usrOdy_UDNTHA, "DENDT", "") '売上日付
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSMADT = CF_Ora_GetDyn(usrOdy_UDNTHA, "SMADT", "") '経理締日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSSADT_Chk = CF_Ora_GetDyn(usrOdy_UDNTHA, "SSADT", "") '締日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strKESDT_Chk = CF_Ora_GetDyn(usrOdy_UDNTHA, "KESDT", "") '決済日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strTOKSMEKB = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKSMEKB", "") '締区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strTOKSMEDD = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKSMEDD", "") '締初期日付(売上)
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strTOKSMECC = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKSMECC", "") '締サイクル(売上)
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strTOKSDWKB = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKSDWKB", "") '締め曜日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strTOKKESCC = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKKESCC", "") '回収サイクル
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strTOKKESDD = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKKESDD", "") '回収日付
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strTOKKDWKB = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKKDWKB", "") '回収曜日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strUDNNO_KRO(intCnt) = CF_Ora_GetDyn(usrOdy_UDNTHA, "UDNNO", "") '売上伝票番号
					' === 20070331 === INSERT S - ACE)Nagasawa 売上訂正返品対応
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strFDNNO_KRO(intCnt) = CF_Ora_GetDyn(usrOdy_UDNTHA, "FDNNO", "") '納品書番号
					' === 20070331 === INSERT E -
					
					'返品が発生している場合は赤黒作成
					If Mid(strRet_HNPN, 1, 1) = "1" Then
						bolAKAKRO(intCnt) = True
						intODNNO_GetSu = intODNNO_GetSu + 1
						intUDNNO_GetSu = intUDNNO_GetSu + 2
						strUDNNO_KRO(intCnt) = "" '売上伝票番号(採番対象とする)
						' === 20070331 === INSERT S - ACE)Nagasawa 売上訂正返品対応
						strFDNNO_KRO(intCnt) = "" '納品書番号(採番対象とする)
						' === 20070331 === INSERT E -
					Else
						'月またぎかどうか判断する
						intRet = AE_UpdateURI_Chk_AkaKro(pin_usrUDNTHA.UDNDT, strSMADT, strSSADT_Chk)
						If intRet = 0 Then
							bolAKAKRO(intCnt) = False
						Else
							bolAKAKRO(intCnt) = True
						End If
					End If
					
					'締日計算(伝票日付が請求締日を越える場合のみ）
					If strSSADT_Chk < CF_Ora_Date(pin_usrUDNTHA.UDNDT) Then
						intRet = AE_GetSMEDT(pin_usrUDNTHA.UDNDT, strTOKSMEKB, strTOKSMEDD, strTOKSMECC, strTOKSDWKB, CShort(strNXTKB), strDate)
						If intRet = 0 Then
							strSSADT(intCnt) = strDate
							strSSADT_Chk_Calc = strDate
						Else
							GoTo AE_GET_URIInf_DATNO_Err
						End If
						
						'決算日付計算
						intRet = AE_GetKESDT(strSSADT(intCnt), strTOKSMEKB, strTOKKESCC, strTOKKESDD, strTOKKDWKB, pin_usrUDNTHA.SSAKBN, strDate)
						If intRet = 0 Then
							strKESDT(intCnt) = strDate
						Else
							GoTo AE_GET_URIInf_DATNO_Err
						End If
					Else
						strSSADT(intCnt) = strSSADT_Chk
						strKESDT(intCnt) = strKESDT_Chk
						
						'請求締日算出（チェック用)
						intRet = AE_GetSMEDT(pin_usrUDNTHA.UDNDT, strTOKSMEKB, strTOKSMEDD, strTOKSMECC, strTOKSDWKB, CShort(strNXTKB), strSSADT_Chk_Calc)
					End If
					
					If bolAKAKRO(intCnt) = True Then
						'最大経理締日格納
						If strSMADT < CF_Ora_Date(pin_usrUDNTHA.UDNDT) Then
							If strSMADT_MAX < strSMADT Then
								strSMADT_MAX = strSMADT
							End If
						End If
						
						'最大請求締日格納
						If strSSADT_Chk < CF_Ora_Date(pin_usrUDNTHA.UDNDT) Then
							If strSSADT_MAX < strSSADT_Chk Then
								strSSADT_MAX = strSSADT_Chk
							End If
						End If
					End If
					
					'最大伝票日付格納
					If strDENDT_MAX < strDENDT Then
						strDENDT_MAX = strDENDT
					End If
					
					'請求締め日チェック
					If strSSADT_Chk_Calc < strSSADT_Chk Then
						pin_usrUDNTHA.strErr = "SSADT_ERR"
					End If
					
					intCnt = intCnt + 1
					Exit For
				End If
			Next 
			
			Call CF_Ora_MoveNext(usrOdy_UDNTHA)
		Loop 
		
		'取得した内容を戻り値に格納
		pin_usrUDNTHA.DATNO = VB6.CopyArray(strDATNO) '伝票管理番号
		pin_usrUDNTHA.FDNNO = VB6.CopyArray(strFDNNO) '納品書番号
		pin_usrUDNTHA.bolAKAKRO = VB6.CopyArray(bolAKAKRO) '赤黒区分
		pin_usrUDNTHA.SSADT = VB6.CopyArray(strSSADT) '請求締日
		pin_usrUDNTHA.KESDT = VB6.CopyArray(strKESDT) '決済日
		pin_usrUDNTHA.UDNDENDT_Chk = strDENDT_MAX '売上日付（受注訂正日チェック用）
		pin_usrUDNTHA.SMADT_Chk = strSMADT_MAX '経理締日（受注訂正日チェック用）
		pin_usrUDNTHA.SSADT_Chk = strSSADT_MAX '請求締日（受注訂正日チェック用）
		pin_usrUDNTHA.ODNNO = VB6.CopyArray(strODNNO_Get) '出荷伝票番号
		pin_usrUDNTHA.UDNNO_KRO = VB6.CopyArray(strUDNNO_KRO) '売上伝票番号
		pin_usrUDNTHA.UDNNO_AKA = VB6.CopyArray(strUDNNO_AKA) '売上伝票番号
		' === 20070331 === INSERT S - ACE)Nagasawa 売上訂正返品対応
		pin_usrUDNTHA.FDNNO_KRO = VB6.CopyArray(strFDNNO_KRO) '納品書番号
		pin_usrUDNTHA.FDNNO_AKA = VB6.CopyArray(strFDNNO_AKA) '納品書番号
		' === 20070331 === INSERT E -
		pin_usrUDNTHA.ODNNO_GetSu = intODNNO_GetSu '出荷伝票番号採番数
		pin_usrUDNTHA.UDNNO_GetSu = intUDNNO_GetSu '売上伝票番号採番数
		
		AE_GET_URIInf_DATNO = 0
		
AE_GET_URIInf_DATNO_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
		End If
		
		Exit Function
		
AE_GET_URIInf_DATNO_Err: 
		GoTo AE_GET_URIInf_DATNO_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_UpdateURI_Chk
	'   概要：  売上訂正チェック
	'   引数：  pin_strKJNDT    : 判定基準日（入力される訂正日）
	'           pin_strDENDT  　: 売上日付（複数伝票の場合は最大のもの）
	'           pin_strSMADT  　: 経理締日（複数伝票の場合は最大のもの）
	'           pin_strSSADT  　: 請求締日（複数伝票の場合は最大のもの）
	'           pin_strTOKCD  　: 得意先コード
	'   戻値：  0：正常　1: 月次仮締日過ぎ　2: 請求締日過ぎ 3:売上日付以前　9: 異常
	'   備考：  売上伝票の経理締め日、締日をみて、基準日が赤黒が発生する日付かどうか
	'　　　　　 判断する（締めが行われている日付は入力不可）
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_UpdateURI_Chk(ByVal pin_strKJNDT As String, ByVal pin_strDENDT As String, ByVal pin_strSMADT As String, ByVal pin_strSSADT As String, ByVal pin_strTOKCD As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Mst_Inf_SYSTBA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		Dim intRet As Short
		
		AE_UpdateURI_Chk = 9
		
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'ユーザー情報管理テーブル検索
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			Exit Function
		End If
		
		'売上伝票日付が以前の日付はエラー
		If CF_Ora_Date(pin_strKJNDT) < pin_strDENDT Then
			AE_UpdateURI_Chk = 3
			Exit Function
		End If
		
		'月次仮締めが行われている場合基準日と経理締日の比較
		If Trim(Mst_Inf_SYSTBA.UKSMEDT) <> "" Then
			If CF_Ora_Date(pin_strSMADT) <= Mst_Inf_SYSTBA.UKSMEDT Then
				If CF_Ora_Date(pin_strKJNDT) <= CF_Ora_Date(pin_strSMADT) Then
					AE_UpdateURI_Chk = 1
					Exit Function
				End If
			End If
		End If
		
		Call DB_TOKMTA_Clear(Mst_Inf_TOKMTA)
		
		'得意先マスタ検索
		If DSPTOKCD_SEARCH(pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
			Exit Function
		End If
		
		'請求締めが行われている場合基準日と請求締日の比較
		If Trim(Mst_Inf_TOKMTA.TOKSMEDT) <> "" Then
			If CF_Ora_Date(pin_strSSADT) <= Mst_Inf_TOKMTA.TOKSMEDT Then
				If CF_Ora_Date(pin_strKJNDT) <= CF_Ora_Date(pin_strSSADT) Then
					AE_UpdateURI_Chk = 2
					Exit Function
				End If
			End If
		End If
		
		'赤黒伝票が発生する場合警告
		If CF_Get_CCurString(pin_strSSADT) <> 0 Then
			If CF_Ora_Date(pin_strKJNDT) > pin_strSSADT Then
				AE_UpdateURI_Chk = 4
				Exit Function
			End If
		End If
		If CF_Get_CCurString(pin_strSMADT) <> 0 Then
			If CF_Ora_Date(pin_strKJNDT) > pin_strSMADT Then
				AE_UpdateURI_Chk = 4
				Exit Function
			End If
		End If
		
		AE_UpdateURI_Chk = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_UpdateURI_Chk_AkaKro
	'   概要：  売上訂正チェック(赤黒判定)
	'   引数：  pin_strKJNDT    : 判定基準日（伝票日付）
	'           pin_strSMADT  　: 経理締日
	'           pin_strSSADT  　: 請求締日
	'   戻値：  0：正常　1: 月次仮締日過ぎ　2: 請求締日過ぎ 9: 異常
	'   備考：  売上伝票の経理締日、請求締日をみて、基準日が赤黒が発生する日付かどうか
	'　　　　　 判断する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_UpdateURI_Chk_AkaKro(ByVal pin_strKJNDT As String, ByVal pin_strSMADT As String, ByVal pin_strSSADT As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		Dim intRet As Short
		
		AE_UpdateURI_Chk_AkaKro = 9
		
		'経理締日チェック
		If CF_Ora_Date(pin_strKJNDT) > pin_strSMADT Then
			AE_UpdateURI_Chk_AkaKro = 1
			Exit Function
		End If
		
		'請求先の締日チェック
		If CF_Ora_Date(pin_strKJNDT) > pin_strSSADT Then
			AE_UpdateURI_Chk_AkaKro = 2
			Exit Function
		End If
		
		AE_UpdateURI_Chk_AkaKro = 0
		
	End Function
	
	'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称：  Function AE_URIinf_UPDATE
	''   概要：  売上情報更新処理
	''   引数：  pin_usrURITHA     : 売上見出し情報
	''   　　　  pin_usrURITRA     : 売上情報
	''   戻値：  0：正常　9: 異常
	''   備考：  パラメータの値を元に売上情報を更新する
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function AE_URIinf_UPDATE(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, _
	''                                 ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd) As Integer
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_URIinf_UPDATE
	'   概要：  売上情報更新処理
	'   引数：  pin_usrURITHA     : 売上見出し情報
	'   　　　  pin_usrURITRA     : 売上情報
	'   　　　  pin_Upd_Inf       : 受注訂正時の項目の入力可否制御
	'   戻値：  0：正常　9: 異常
	'   備考：  パラメータの値を元に売上情報を更新する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_URIinf_UPDATE(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd, ByRef pin_Upd_Inf As Cmn_JDNUPDATE_Enable) As Short
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		Dim intCnt As Short
		Dim intRet As Short
		
		On Error GoTo AE_URIinf_UPDATE_Err
		
		AE_URIinf_UPDATE = 9
		
		'売上トラン更新
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
		'    intRet = AE_URIINF_UDNTRA_UPD_Main(pin_usrURITHA, pin_usrURITRA)
		intRet = AE_URIINF_UDNTRA_UPD_Main(pin_usrURITHA, pin_usrURITRA, pin_Upd_Inf)
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		If intRet <> 0 Then
			GoTo AE_URIinf_UPDATE_Err
		End If
		
		'売上データの更新対象全てに対し更新を行う
		For intCnt = 1 To UBound(pin_usrURITHA.DATNO)
			
			'売上見出しトラン更新
			intRet = AE_URIINF_UDNTHA_UPD_Main(pin_usrURITHA, intCnt)
			If intRet <> 0 Then
				GoTo AE_URIinf_UPDATE_Err
			End If
			
			'金額の集計
			pin_usrURITHA.curSUrikn_New = pin_usrURITHA.curSUrikn_New + pin_usrURITHA.curUrikn_New(intCnt)
			pin_usrURITHA.curSUrikn_Old = pin_usrURITHA.curSUrikn_Old + pin_usrURITHA.curUrikn_Old(intCnt)
			pin_usrURITHA.curSFUrikn_New = pin_usrURITHA.curSFUrikn_New + pin_usrURITHA.curFUrikn_New(intCnt)
			pin_usrURITHA.curSFUrikn_Old = pin_usrURITHA.curSFUrikn_Old + pin_usrURITHA.curFUrikn_Old(intCnt)
			pin_usrURITHA.curSUzeikn_New = pin_usrURITHA.curSUzeikn_New + pin_usrURITHA.curUzeikn_New(intCnt)
			pin_usrURITHA.curSUzeikn_Old = pin_usrURITHA.curSUzeikn_Old + pin_usrURITHA.curUzeikn_Old(intCnt)
		Next 
		
		'売掛サマリ更新
		intRet = AE_TOKSINF_UPDATE(pin_usrURITHA)
		If intRet <> 0 Then
			GoTo AE_URIinf_UPDATE_Err
		End If
		
		'販売単価履歴マスタの更新
		intRet = AE_TOKMTB_UPD_Main(pin_usrURITHA, pin_usrURITRA)
		If intRet <> 0 Then
			GoTo AE_URIinf_UPDATE_Err
		End If
		
		AE_URIinf_UPDATE = 0
		
AE_URIinf_UPDATE_End: 
		Exit Function
		
AE_URIinf_UPDATE_Err: 
		GoTo AE_URIinf_UPDATE_End
		
	End Function
	
	'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称：  Function AE_URIINF_UDNTRA_UPD_Main
	''   概要：  売上トラン更新
	''   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	''   　　　  pin_usrURITRA     : 売上トラン更新情報
	''   戻値：  0：正常　9: 異常
	''   備考：  売上トランの追加、更新を行う
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function AE_URIINF_UDNTRA_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, _
	''                                           ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd) As Integer
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_URIINF_UDNTRA_UPD_Main
	'   概要：  売上トラン更新
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   　　　  pin_usrURITRA     : 売上トラン更新情報
	'   　　　  pin_Upd_Inf       : 受注訂正時の項目の入力可否制御
	'   戻値：  0：正常　9: 異常
	'   備考：  売上トランの追加、更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTRA_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd, ByRef pin_Upd_Inf As Cmn_JDNUPDATE_Enable) As Short
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		Dim bolRet As Boolean
		Dim intCntH As Short
		Dim intCntR As Short
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy_UDNTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolTran As Boolean
		Dim curURISU As Decimal
		Dim curUZEIKN As Decimal
		Dim bolUpd As Boolean
		Dim usrUDNTRA As Cmn_UDNTRA_Upd
		Dim Init_TRA As Cmn_UDNTRA_Upd
		Dim strODNNO As String
		Dim strRecNo As String
		Dim curHNPNSU As Decimal
		Dim curHNPNKN As Decimal
		Dim curHNPNZKN As Decimal
		Dim curHNPNFKN As Decimal
		' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
		Dim strMRPKB As String
		Dim strMRPKB_BFR As String
		Dim strSSADT_BFR As String
		' === 20071213 === INSERT E -
		
		On Error GoTo AE_URIINF_UDNTRA_UPD_Main_Err
		
		AE_URIINF_UDNTRA_UPD_Main = 9
		
		bolTran = False
		
		'伝票合計金額初期化
		With pin_usrURITHA
			ReDim .curUrikn_Old(UBound(.DATNO))
			ReDim .curFUrikn_Old(UBound(.DATNO))
			ReDim .curUzeikn_Old(UBound(.DATNO))
			ReDim .curUrikn_New(UBound(.DATNO))
			ReDim .curFUrikn_New(UBound(.DATNO))
			ReDim .curUzeikn_New(UBound(.DATNO))
		End With
		
		Dim intRet As Short
		For intCntH = 1 To UBound(pin_usrURITHA.DATNO)
			'売上トラン取得
			strSQL = ""
			strSQL = strSQL & " SELECT * "
			strSQL = strSQL & "   FROM UDNTRA "
			strSQL = strSQL & "  WHERE DATNO    = '" & CF_Ora_String(pin_usrURITHA.DATNO(intCntH), 10) & "' "
			strSQL = strSQL & "    AND JDNNO    = '" & CF_Ora_String(pin_usrURITHA.JDNNO, 10) & "' "
			strSQL = strSQL & "  ORDER BY DATNO, JDNNO, JDNLINNO "
			
			'SQL実行
			bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
			If bolRet = False Then
				GoTo AE_URIINF_UDNTRA_UPD_Main_Err
			End If
			
			bolTran = True
			
			Do Until CF_Ora_EOF(usrOdy_UDNTRA) = True
				
				'売上トランの値を取得
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				curURISU = CF_Ora_GetDyn(usrOdy_UDNTRA, "URISU", 0) '売上数量
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrUDNTRA.URILINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "LINNO", "") '行番号（売上トラン）
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strODNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "ODNNO", "") '出荷伝票番号
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strRecNo = CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "") 'レコード管理番号
				
				'返品数取得
				Call AE_GET_URIInf_HNPN(pin_usrURITHA.FDNNO(intCntH), strODNNO, strRecNo, curHNPNSU, curHNPNKN, curHNPNZKN, curHNPNFKN)
				
				'伝票合計金額
				With pin_usrURITHA
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_UDNTRA, URIKN, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.curUrikn_Old(intCntH) = .curUrikn_Old(intCntH) - curHNPNKN + CF_Ora_GetDyn(usrOdy_UDNTRA, "URIKN", 0) '売上金額
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_UDNTRA, FURIKN, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.curFUrikn_Old(intCntH) = .curFUrikn_Old(intCntH) - curHNPNFKN + CF_Ora_GetDyn(usrOdy_UDNTRA, "FURIKN", 0) '外貨売上金額
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_UDNTRA, UZEKN, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.curUzeikn_Old(intCntH) = .curUzeikn_Old(intCntH) - curHNPNZKN + CF_Ora_GetDyn(usrOdy_UDNTRA, "UZEKN", 0) '消費税金額
				End With
				
				'更新対象行かどうかを判断する
				bolUpd = False
				
				For intCntR = 1 To UBound(pin_usrURITRA)
					
					'UPGRADE_WARNING: オブジェクト usrUDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrUDNTRA = pin_usrURITRA(intCntR)
					
					'更新対象行を判断（受注取引区分により検索条件変更）
					Select Case True
						'システム受注で出荷基準のもの
						Case (pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrURITHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SET
							'行番号一致
							'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNLINNO", "")) = Trim(usrUDNTRA.LINNO) Then
								bolUpd = True
							End If
							
							'システム受注で出荷基準以外のもの
						Case pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SYS
							'レコード管理番号一致
							'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "")) = Trim(usrUDNTRA.RECNO) Then
								bolUpd = True
							End If
							
							'上記以外
						Case Else
							'製番一致
							'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "SBNNO", "")) = Trim(usrUDNTRA.SBNNO) Then
								bolUpd = True
							End If
					End Select
					
					If bolUpd = True Then
						Exit For
					End If
				Next 
				
				' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
				'更新前売上トラン内容取得
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strMRPKB_BFR = CF_Ora_GetDyn(usrOdy_UDNTRA, "MRPKB", "") '請求書発行区分
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSSADT_BFR = CF_Ora_GetDyn(usrOdy_UDNTRA, "SSADT", "") '締日付
				
				strMRPKB = ""
				For intCntR = 1 To UBound(pin_usrURITHA.usrBodyInf)
					'更新対象行を判断（受注取引区分により検索条件変更）
					Select Case True
						'システム受注で出荷基準のもの
						Case (pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrURITHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SET
							'行番号一致
							'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNLINNO", "")) = Trim(pin_usrURITHA.usrBodyInf(intCntR).LINNO) Then
								strMRPKB = pin_usrURITHA.usrBodyInf(intCntR).MRPKB
								Exit For
							End If
							
							'システム受注で出荷基準以外のもの
						Case pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SYS
							'レコード管理番号一致
							'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "")) = Trim(pin_usrURITHA.usrBodyInf(intCntR).RECNO) Then
								strMRPKB = pin_usrURITHA.usrBodyInf(intCntR).MRPKB
								Exit For
							End If
							
							'上記以外
						Case Else
							'製番一致
							'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "SBNNO", "")) = Trim(pin_usrURITHA.usrBodyInf(intCntR).SBNNO) Then
								strMRPKB = pin_usrURITHA.usrBodyInf(intCntR).MRPKB
								Exit For
							End If
					End Select
				Next 
				
				'請求書出力区分の判定・場合によっては以前のデータを更新
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_UDNTRA, LINNO, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				bolRet = AE_Get_MRPKB(strMRPKB_BFR, pin_usrURITHA.bolAKAKRO(intCntH), pin_usrURITHA.DATNO(intCntH), CF_Ora_GetDyn(usrOdy_UDNTRA, "LINNO", ""), strSSADT_BFR, pin_usrURITHA.SSADT(intCntH), strMRPKB)
				If bolRet = False Then
					GoTo AE_URIINF_UDNTRA_UPD_Main_Err
				End If
				' === 20071213 === INSERT E -
				
				If bolUpd = True Then
					'更新対象行の場合再計算
					
					With usrUDNTRA
						'売上金額に値がない場合（システムの諸口、通販受注以外の場合）は再計算
						'(通販受注の場合の返品による再計算ロジックがないのは通販受注は全数返品のみ行うため)
						If .URIKN = 0 Then
							'売上金額再計算
							.URIKN = .URITK * (curURISU - curHNPNSU)
							'外貨売上金額再計算
							.FURIKN = .FURITK * (curURISU - curHNPNSU)
							'消費税額再計算
							If .FURITK <> 0 Then
								.UZEKN = 0
							Else
								bolRet = AE_CalcTAX_Meisai(.HINZEIKB, CDec(.ZEIRT), .URITK, curURISU - curHNPNSU, pin_usrURITHA.TOKZEIKB, pin_usrURITHA.TOKRPSKB, pin_usrURITHA.TOKZRNKB, curUZEIKN)
								If bolRet = True Then
									.UZEKN = curUZEIKN
								Else
									GoTo AE_URIINF_UDNTRA_UPD_Main_Err
								End If
							End If
						Else
							If curHNPNSU > 0 Then
								'売上金額
								.URIKN = 0
								'外貨売上金額
								.FURIKN = 0
								'消費税額
								.UZEKN = 0
							End If
						End If
						
						'仕切金額取得
						If Trim(.SIKTK) <> "" Then
							.SIKKN = (curURISU - curHNPNSU) * CF_Get_CCurString(.SIKTK)
						Else
							'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.SIKTK = CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKTK", 0)
							'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.SIKKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKKN", 0)
							
							If curHNPNSU > 0 Then
								'返品がある場合は再計算
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.SIKKN = CDec(CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKTK", 0)) * (curURISU - curHNPNSU)
							End If
						End If
						
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.URILINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "LINNO", "")
						.URISU = (curURISU - curHNPNSU) '売上数量
						
						' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
						.MRPKB = strMRPKB '請求書出力区分
						' === 20071213 === INSERT E -
						
					End With
				Else
					'売上トランの値をそのまま格納
					'UPGRADE_WARNING: オブジェクト usrUDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrUDNTRA = Init_TRA
					With usrUDNTRA
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.JDNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNNO", "") '受注番号
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.LINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNLINNO", "") '行番号
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.URILINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "LINNO", "") '行番号(売上トラン）
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.RECNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "") 'レコード管理番号
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SBNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "SBNNO", "") '製番
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.HINCD = CF_Ora_GetDyn(usrOdy_UDNTRA, "HINCD", "") '製品コード
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.TOKJDNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "TOKJDNNO", "") '客先注文番号
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.BIKO = CF_Ora_GetDyn(usrOdy_UDNTRA, "LINCMA", "") '備考
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.URISU = CF_Ora_GetDyn(usrOdy_UDNTRA, "URISU", 0) '売上数量
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.URITK = CF_Ora_GetDyn(usrOdy_UDNTRA, "URITK", 0) '単価
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.FURITK = CF_Ora_GetDyn(usrOdy_UDNTRA, "FURITK", 0) '外貨単価
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SIKTK = CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKTK", 0) '仕切単価
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.URIKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "URIKN", 0) '売上金額
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.FURIKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "FURIKN", 0) '外貨売上金額
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SIKKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKKN", 0) '仕切金額
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.UZEKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "UZEKN", 0) '消費税額
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.HINZEIKB = CF_Ora_GetDyn(usrOdy_UDNTRA, "HINZEIKB", "") '商品消費税区分
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.ZEIRT = CF_Ora_GetDyn(usrOdy_UDNTRA, "ZEIRT", 0) '税率
						' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
						.MRPKB = strMRPKB '請求書出力区分
						' === 20071213 === INSERT E -
						
						'返品がある場合は金額再計算
						If curHNPNSU > 0 Then
							.URISU = .URISU - curHNPNSU '売上数量
							.URIKN = .URITK * .URISU '売上金額
							.FURIKN = .FURITK * .URISU '外貨売上金額
							.SIKKN = CDbl(.SIKTK) * .URISU '仕切金額
							'消費税額
							bolRet = AE_CalcTAX_Meisai(.HINZEIKB, CDec(.ZEIRT), .URITK, .URISU, pin_usrURITHA.TOKZEIKB, pin_usrURITHA.TOKRPSKB, pin_usrURITHA.TOKZRNKB, curUZEIKN)
							If bolRet = True Then
								.UZEKN = curUZEIKN
							Else
								GoTo AE_URIINF_UDNTRA_UPD_Main_Err
							End If
						End If
					End With
					
				End If
				
				'返品フラグ
				If curHNPNSU > 0 Then
					usrUDNTRA.bolHNPN = True
					usrUDNTRA.HNURIKN = curHNPNKN '返品分売上金額
					usrUDNTRA.HNFURIKN = curHNPNFKN '返品分外貨売上金額
					usrUDNTRA.HNUZEKN = curHNPNZKN '返品分消費税金額
				Else
					usrUDNTRA.bolHNPN = False
					usrUDNTRA.HNURIKN = 0 '返品分売上金額
					usrUDNTRA.HNFURIKN = 0 '返品分外貨売上金額
					usrUDNTRA.HNUZEKN = 0 '返品分消費税金額
				End If
				
				'伝票合計金額
				With pin_usrURITHA
					.curUrikn_New(intCntH) = .curUrikn_New(intCntH) + usrUDNTRA.URIKN '売上金額
					.curFUrikn_New(intCntH) = .curFUrikn_New(intCntH) + usrUDNTRA.FURIKN '外貨売上金額
					.curUzeikn_New(intCntH) = .curUzeikn_New(intCntH) + usrUDNTRA.UZEKN '消費税金額
				End With
				
				Call CF_Ora_MoveNext(usrOdy_UDNTRA)
				
				If curURISU - curHNPNSU > 0 Then
					'黒伝票の作成
					strSQL = AE_URIINF_UDNTRA_INS_KRO_SQL(pin_usrURITHA, usrUDNTRA, CStr(intCntH))
					
					'ＳＱＬ実行
					bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
					If bolRet = False Then
						GoTo AE_URIINF_UDNTRA_UPD_Main_Err
					End If
					
					'''' ADD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
					'新入金対応
					If pin_Upd_Inf.bolNYU = True Then
						intRet = F_GRKBP98_RunStored(CF_Ora_String(SSS_CLTID.Value, 5), CF_Ora_String(SSS_OPEID.Value, 8), pin_usrURITHA.DATNO(intCntH), usrUDNTRA.URILINNO)
						If intRet <> 0 Then
							GoTo AE_URIINF_UDNTRA_UPD_Main_Err
						End If
					End If
					'''' ADD 2009/12/23  FKS) T.Yamamoto    End
				End If
				
				'赤伝票の作成
				If pin_usrURITHA.bolAKAKRO(intCntH) = True Then
					If curURISU - curHNPNSU > 0 Then
						'赤伝票INSERT
						strSQL = AE_URIINF_UDNTRA_INS_AKA_SQL(pin_usrURITHA, usrUDNTRA, CStr(intCntH))
					Else
						strSQL = ""
					End If
				Else
					'元データの伝票管理番号を"削除"にする
					strSQL = AE_URIINF_UDNTRA_UPD_SQL(pin_usrURITHA, usrUDNTRA, CStr(intCntH))
				End If
				
				'ＳＱＬ実行
				If Trim(strSQL) <> "" Then
					bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
					If bolRet = False Then
						GoTo AE_URIINF_UDNTRA_UPD_Main_Err
					End If
				End If
				
			Loop 
			
			'クローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
			bolTran = False
			
		Next 
		
		AE_URIINF_UDNTRA_UPD_Main = 0
		bolTran = False
		
AE_URIINF_UDNTRA_UPD_Main_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
		End If
		
		Exit Function
		
AE_URIINF_UDNTRA_UPD_Main_Err: 
		'エラー箇所編集
		pin_usrURITHA.strErr = "AE_URIINF_UDNTRA_UPD_Main"
		GoTo AE_URIINF_UDNTRA_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_URIINF_UDNTHA_UPD_Main
	'   概要：  売上見出しトラン更新
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   　　　  pin_intCnt　      : 番号
	'   戻値：  0：正常　9: 異常
	'   備考：  売上見出しトランに追加、更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTHA_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByVal pin_intCnt As Short) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		
		On Error GoTo AE_URIINF_UDNTHA_UPD_Main_Err
		
		AE_URIINF_UDNTHA_UPD_Main = 9
		
		'黒伝票の作成
		strSQL = AE_URIINF_UDNTHA_INS_KRO_SQL(pin_usrURITHA, CStr(pin_intCnt))
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_URIINF_UDNTHA_UPD_Main_Err
		End If
		
		'赤伝票の作成
		If pin_usrURITHA.bolAKAKRO(pin_intCnt) = True Then
			'赤伝票INSERT
			strSQL = AE_URIINF_UDNTHA_INS_AKA_SQL(pin_usrURITHA, CStr(pin_intCnt))
		Else
			'元データの伝票管理番号を"削除"にする
			strSQL = AE_URIINF_UDNTHA_UPD_SQL(pin_usrURITHA, CStr(pin_intCnt))
		End If
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_URIINF_UDNTHA_UPD_Main_Err
		End If
		
		AE_URIINF_UDNTHA_UPD_Main = 0
		
AE_URIINF_UDNTHA_UPD_Main_End: 
		
		Exit Function
		
AE_URIINF_UDNTHA_UPD_Main_Err: 
		'エラー箇所編集
		pin_usrURITHA.strErr = "AE_URIINF_UDNTHA_UPD_Main"
		GoTo AE_URIINF_UDNTHA_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_URIINF_UDNTHA_INS_KRO_SQL
	'   概要：  売上見出しトラン黒伝票作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   　　　  pin_intCnt　      : 番号
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTHA_INS_KRO_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTHA_INS_KRO_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTHA "
		strSQL = strSQL & "      ( DATNO " '伝票管理NO.
		strSQL = strSQL & "      , DATKB " '伝票削除区分
		strSQL = strSQL & "      , AKAKROKB " '赤黒区分
		strSQL = strSQL & "      , DENKB " '伝票区分
		strSQL = strSQL & "      , UDNNO " '売上伝票番号
		strSQL = strSQL & "      , FDNNO " '納品書№
		strSQL = strSQL & "      , JDNNO " '受注伝票番号
		strSQL = strSQL & "      , USDNO " '直送伝票NO
		strSQL = strSQL & "      , UDNDT " '売上伝票日付
		strSQL = strSQL & "      , DENDT " '売上日付
		strSQL = strSQL & "      , REGDT " '初回伝票日付
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , TOKRN " '得意先略称
		strSQL = strSQL & "      , NHSCD " '納入先コード
		strSQL = strSQL & "      , NHSRN " '納入先略称
		strSQL = strSQL & "      , NHSNMA " '納入先名称１
		strSQL = strSQL & "      , NHSNMB " '納入先名称２
		strSQL = strSQL & "      , TANCD " '担当者コード
		strSQL = strSQL & "      , TANNM " '担当者名
		strSQL = strSQL & "      , BUMCD " '部門コード
		strSQL = strSQL & "      , BUMNM " '部門名
		strSQL = strSQL & "      , TOKSEICD " '請求先コード
		strSQL = strSQL & "      , SOUCD " '倉庫コード
		strSQL = strSQL & "      , SOUNM " '倉庫名
		strSQL = strSQL & "      , NXTKB " '帳端区分
		strSQL = strSQL & "      , NXTNM " '帳端名称
		strSQL = strSQL & "      , EMGODNKB " '緊急出荷区分
		strSQL = strSQL & "      , OKRJONO " '送り状№
		strSQL = strSQL & "      , INVNO " 'インボイス№
		strSQL = strSQL & "      , SMADT " '経理締日付
		strSQL = strSQL & "      , SSADT " '締日付
		strSQL = strSQL & "      , KESDT " '決済日付
		strSQL = strSQL & "      , NYUCD " '入金区分
		strSQL = strSQL & "      , ZKTKB " '取引区分
		strSQL = strSQL & "      , ZKTNM " '取引区分名
		strSQL = strSQL & "      , KENNMA " '件名１
		strSQL = strSQL & "      , KENNMB " '件名２
		strSQL = strSQL & "      , NHSADA " '納入先住所１
		strSQL = strSQL & "      , NHSADB " '納入先住所２
		strSQL = strSQL & "      , NHSADC " '納入先住所３
		strSQL = strSQL & "      , MAEUKNM " '前受区分名称
		strSQL = strSQL & "      , KEIBUMCD " '経理部門コード
		strSQL = strSQL & "      , UPFKB " '売上同時出荷区分
		strSQL = strSQL & "      , SBAURIKN " '売上金額(本体合計)
		strSQL = strSQL & "      , SBAUZEKN " '売上金額(消費税額)
		strSQL = strSQL & "      , SBAUZKKN " '売上金額(伝票計)
		strSQL = strSQL & "      , SBAFRUKN " '外貨売上金額(伝票計)
		strSQL = strSQL & "      , SBANYUKN " '入金金額(伝票計)
		strSQL = strSQL & "      , SBAFRNKN " '外貨入金額(伝票計)
		strSQL = strSQL & "      , DENCM " '備考
		strSQL = strSQL & "      , DENCMIN " '社内備考
		strSQL = strSQL & "      , TOKSMEKB " '締区分
		strSQL = strSQL & "      , TOKSMEDD " '締初期日付(売上)
		strSQL = strSQL & "      , TOKSMECC " '締サイクル(売上)
		strSQL = strSQL & "      , TOKSDWKB " '締め曜日
		strSQL = strSQL & "      , TOKKESCC " '回収サイクル
		strSQL = strSQL & "      , TOKKESDD " '回収日付
		strSQL = strSQL & "      , TOKKDWKB " '回収曜日
		strSQL = strSQL & "      , LSTID " '伝票種別
		strSQL = strSQL & "      , TOKJUNKB " '順位表出力区分
		strSQL = strSQL & "      , TOKMSTKB " 'マスタ区分(得意先)
		strSQL = strSQL & "      , TKNRPSKB " '金額端数処理桁数
		strSQL = strSQL & "      , TKNZRNKB " '金額端数処理区分
		strSQL = strSQL & "      , TOKZEIKB " '消費税区分
		strSQL = strSQL & "      , TOKZCLKB " '消費税算出区分
		strSQL = strSQL & "      , TOKRPSKB " '消費税端数処理桁数
		strSQL = strSQL & "      , TOKZRNKB " '消費税端数処理区分
		strSQL = strSQL & "      , TOKNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "      , NHSMSTKB " 'マスタ区分(納入先)
		strSQL = strSQL & "      , NHSNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "      , TANMSTKB " 'マスタ区分(担当者)
		strSQL = strSQL & "      , URIKJN " '売上基準
		strSQL = strSQL & "      , MAEUKKB " '前受区分
		strSQL = strSQL & "      , SEIKB " '請求区分
		strSQL = strSQL & "      , JDNTRKB " '受注取引区分
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , FRNKB " '海外取引区分
		strSQL = strSQL & "      , UDNPRAKB " '納品書発行区分
		strSQL = strSQL & "      , UDNPRBKB " '個別請求発行区分
		strSQL = strSQL & "      , MOTDATNO " '元伝票管理番号
		strSQL = strSQL & "      , FOPEID " '初回登録ユーザーＩＤ
		strSQL = strSQL & "      , FCLTID " '初回登録クライアントＩＤ
		strSQL = strSQL & "      , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , WRTFSTDT " 'タイムスタンプ（登録日）
		strSQL = strSQL & "      , OPEID " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      , CLTID " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      , WRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , WRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , UOPEID " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      , UCLTID " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      , UWRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , UWRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , PGID " 'ＰＧＩＤ
		strSQL = strSQL & "      , DLFLG " '削除フラグ
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        '" & CF_Ora_String(pin_usrURITHA.DATNO_KRO(CInt(pin_intCnt)), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , DATKB " '伝票削除区分
		strSQL = strSQL & "      , AKAKROKB " '赤黒区分
		strSQL = strSQL & "      , DENKB " '伝票区分
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.UDNNO_KRO(CInt(pin_intCnt)), 8) & "' " '売上伝票番号
		' === 20070331 === INSERT S - ACE)Nagasawa 売上訂正返品対応
		'    strSQL = strSQL & "      , FDNNO "          '納品書№
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.FDNNO_KRO(CInt(pin_intCnt)), 8) & "' " '納品書番号
		' === 20070331 === INSERT E -
		strSQL = strSQL & "      , JDNNO " '受注伝票番号
		strSQL = strSQL & "      , USDNO " '直送伝票NO
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '売上伝票日付
		strSQL = strSQL & "      , DENDT " '売上日付
		strSQL = strSQL & "      , REGDT " '初回伝票日付
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , TOKRN " '得意先略称
		strSQL = strSQL & "      , NHSCD " '納入先コード
		strSQL = strSQL & "      , NHSRN " '納入先略称
		strSQL = strSQL & "      , NHSNMA " '納入先名称１
		strSQL = strSQL & "      , NHSNMB " '納入先名称２
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TANCD, 6) & "' " '担当者コード
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TANNM, 40) & "' " '担当者名
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.BUMCD, 6) & "' " '部門コード
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.BUMNM, 40) & "' " '部門名
		strSQL = strSQL & "      , TOKSEICD " '請求先コード
		strSQL = strSQL & "      , SOUCD " '倉庫コード
		strSQL = strSQL & "      , SOUNM " '倉庫名
		strSQL = strSQL & "      , NXTKB " '帳端区分
		strSQL = strSQL & "      , NXTNM " '帳端名称
		strSQL = strSQL & "      , EMGODNKB " '緊急出荷区分
		strSQL = strSQL & "      , OKRJONO " '送り状№
		strSQL = strSQL & "      , INVNO " 'インボイス№
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '経理締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(CInt(pin_intCnt))) & "' " '締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(CInt(pin_intCnt))) & "' " '決済日付
		strSQL = strSQL & "      , NYUCD " '入金区分
		strSQL = strSQL & "      , ZKTKB " '取引区分
		strSQL = strSQL & "      , ZKTNM " '取引区分名
		strSQL = strSQL & "      , KENNMA " '件名１
		strSQL = strSQL & "      , KENNMB " '件名２
		strSQL = strSQL & "      , NHSADA " '納入先住所１
		strSQL = strSQL & "      , NHSADB " '納入先住所２
		strSQL = strSQL & "      , NHSADC " '納入先住所３
		strSQL = strSQL & "      , MAEUKNM " '前受区分名称
		strSQL = strSQL & "      , KEIBUMCD " '経理部門コード
		strSQL = strSQL & "      , UPFKB " '売上同時出荷区分
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUrikn_New(CInt(pin_intCnt)))) '売上金額(本体合計)
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUzeikn_New(CInt(pin_intCnt)))) '売上金額(消費税額)
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUrikn_New(CInt(pin_intCnt)) + pin_usrURITHA.curUzeikn_New(CInt(pin_intCnt)))) '売上金額(伝票計)
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curFUrikn_New(CInt(pin_intCnt)))) '外貨売上金額(伝票計)
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , SBANYUKN " '入金金額(伝票計)
			strSQL = strSQL & "      , SBAFRNKN " '外貨入金額(伝票計)
		Else
			strSQL = strSQL & "      , 0 " '入金金額(伝票計)
			strSQL = strSQL & "      , 0 " '外貨入金額(伝票計)
		End If
		
		strSQL = strSQL & "      , DENCM " '備考
		strSQL = strSQL & "      , DENCMIN " '社内備考
		strSQL = strSQL & "      , TOKSMEKB " '締区分
		strSQL = strSQL & "      , TOKSMEDD " '締初期日付(売上)
		strSQL = strSQL & "      , TOKSMECC " '締サイクル(売上)
		strSQL = strSQL & "      , TOKSDWKB " '締め曜日
		strSQL = strSQL & "      , TOKKESCC " '回収サイクル
		strSQL = strSQL & "      , TOKKESDD " '回収日付
		strSQL = strSQL & "      , TOKKDWKB " '回収曜日
		strSQL = strSQL & "      , LSTID " '伝票種別
		strSQL = strSQL & "      , TOKJUNKB " '順位表出力区分
		strSQL = strSQL & "      , TOKMSTKB " 'マスタ区分(得意先)
		strSQL = strSQL & "      , TKNRPSKB " '金額端数処理桁数
		strSQL = strSQL & "      , TKNZRNKB " '金額端数処理区分
		strSQL = strSQL & "      , TOKZEIKB " '消費税区分
		strSQL = strSQL & "      , TOKZCLKB " '消費税算出区分
		strSQL = strSQL & "      , TOKRPSKB " '消費税端数処理桁数
		strSQL = strSQL & "      , TOKZRNKB " '消費税端数処理区分
		strSQL = strSQL & "      , TOKNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "      , NHSMSTKB " 'マスタ区分(納入先)
		strSQL = strSQL & "      , NHSNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "      , TANMSTKB " 'マスタ区分(担当者)
		strSQL = strSQL & "      , URIKJN " '売上基準
		strSQL = strSQL & "      , MAEUKKB " '前受区分
		strSQL = strSQL & "      , SEIKB " '請求区分
		strSQL = strSQL & "      , JDNTRKB " '受注取引区分
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , FRNKB " '海外取引区分
		strSQL = strSQL & "      , UDNPRAKB " '納品書発行区分
		strSQL = strSQL & "      , UDNPRBKB " '個別請求発行区分
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' " '元伝票管理番号
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '初回登録ユーザーＩＤ
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '初回登録クライアントＩＤ
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（登録日）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' " 'ＰＧＩＤ
		strSQL = strSQL & "      ,  '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '削除フラグ
		strSQL = strSQL & "   FROM UDNTHA "
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		
		AE_URIINF_UDNTHA_INS_KRO_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_URIINF_UDNTHA_INS_AKA_SQL
	'   概要：  売上見出しトラン赤伝票作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   　　　  pin_intCnt　      : 番号
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTHA_INS_AKA_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTHA_INS_AKA_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTHA "
		strSQL = strSQL & "      ( DATNO " '伝票管理NO.
		strSQL = strSQL & "      , DATKB " '伝票削除区分
		strSQL = strSQL & "      , AKAKROKB " '赤黒区分
		strSQL = strSQL & "      , DENKB " '伝票区分
		strSQL = strSQL & "      , UDNNO " '売上伝票番号
		strSQL = strSQL & "      , FDNNO " '納品書№
		strSQL = strSQL & "      , JDNNO " '受注伝票番号
		strSQL = strSQL & "      , USDNO " '直送伝票NO
		strSQL = strSQL & "      , UDNDT " '売上伝票日付
		strSQL = strSQL & "      , DENDT " '売上日付
		strSQL = strSQL & "      , REGDT " '初回伝票日付
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , TOKRN " '得意先略称
		strSQL = strSQL & "      , NHSCD " '納入先コード
		strSQL = strSQL & "      , NHSRN " '納入先略称
		strSQL = strSQL & "      , NHSNMA " '納入先名称１
		strSQL = strSQL & "      , NHSNMB " '納入先名称２
		strSQL = strSQL & "      , TANCD " '担当者コード
		strSQL = strSQL & "      , TANNM " '担当者名
		strSQL = strSQL & "      , BUMCD " '部門コード
		strSQL = strSQL & "      , BUMNM " '部門名
		strSQL = strSQL & "      , TOKSEICD " '請求先コード
		strSQL = strSQL & "      , SOUCD " '倉庫コード
		strSQL = strSQL & "      , SOUNM " '倉庫名
		strSQL = strSQL & "      , NXTKB " '帳端区分
		strSQL = strSQL & "      , NXTNM " '帳端名称
		strSQL = strSQL & "      , EMGODNKB " '緊急出荷区分
		strSQL = strSQL & "      , OKRJONO " '送り状№
		strSQL = strSQL & "      , INVNO " 'インボイス№
		strSQL = strSQL & "      , SMADT " '経理締日付
		strSQL = strSQL & "      , SSADT " '締日付
		strSQL = strSQL & "      , KESDT " '決済日付
		strSQL = strSQL & "      , NYUCD " '入金区分
		strSQL = strSQL & "      , ZKTKB " '取引区分
		strSQL = strSQL & "      , ZKTNM " '取引区分名
		strSQL = strSQL & "      , KENNMA " '件名１
		strSQL = strSQL & "      , KENNMB " '件名２
		strSQL = strSQL & "      , NHSADA " '納入先住所１
		strSQL = strSQL & "      , NHSADB " '納入先住所２
		strSQL = strSQL & "      , NHSADC " '納入先住所３
		strSQL = strSQL & "      , MAEUKNM " '前受区分名称
		strSQL = strSQL & "      , KEIBUMCD " '経理部門コード
		strSQL = strSQL & "      , UPFKB " '売上同時出荷区分
		strSQL = strSQL & "      , SBAURIKN " '売上金額(本体合計)
		strSQL = strSQL & "      , SBAUZEKN " '売上金額(消費税額)
		strSQL = strSQL & "      , SBAUZKKN " '売上金額(伝票計)
		strSQL = strSQL & "      , SBAFRUKN " '外貨売上金額(伝票計)
		strSQL = strSQL & "      , SBANYUKN " '入金金額(伝票計)
		strSQL = strSQL & "      , SBAFRNKN " '外貨入金額(伝票計)
		strSQL = strSQL & "      , DENCM " '備考
		strSQL = strSQL & "      , DENCMIN " '社内備考
		strSQL = strSQL & "      , TOKSMEKB " '締区分
		strSQL = strSQL & "      , TOKSMEDD " '締初期日付(売上)
		strSQL = strSQL & "      , TOKSMECC " '締サイクル(売上)
		strSQL = strSQL & "      , TOKSDWKB " '締め曜日
		strSQL = strSQL & "      , TOKKESCC " '回収サイクル
		strSQL = strSQL & "      , TOKKESDD " '回収日付
		strSQL = strSQL & "      , TOKKDWKB " '回収曜日
		strSQL = strSQL & "      , LSTID " '伝票種別
		strSQL = strSQL & "      , TOKJUNKB " '順位表出力区分
		strSQL = strSQL & "      , TOKMSTKB " 'マスタ区分(得意先)
		strSQL = strSQL & "      , TKNRPSKB " '金額端数処理桁数
		strSQL = strSQL & "      , TKNZRNKB " '金額端数処理区分
		strSQL = strSQL & "      , TOKZEIKB " '消費税区分
		strSQL = strSQL & "      , TOKZCLKB " '消費税算出区分
		strSQL = strSQL & "      , TOKRPSKB " '消費税端数処理桁数
		strSQL = strSQL & "      , TOKZRNKB " '消費税端数処理区分
		strSQL = strSQL & "      , TOKNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "      , NHSMSTKB " 'マスタ区分(納入先)
		strSQL = strSQL & "      , NHSNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "      , TANMSTKB " 'マスタ区分(担当者)
		strSQL = strSQL & "      , URIKJN " '売上基準
		strSQL = strSQL & "      , MAEUKKB " '前受区分
		strSQL = strSQL & "      , SEIKB " '請求区分
		strSQL = strSQL & "      , JDNTRKB " '受注取引区分
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , FRNKB " '海外取引区分
		strSQL = strSQL & "      , UDNPRAKB " '納品書発行区分
		strSQL = strSQL & "      , UDNPRBKB " '個別請求発行区分
		strSQL = strSQL & "      , MOTDATNO " '元伝票管理番号
		strSQL = strSQL & "      , FOPEID " '初回登録ユーザーＩＤ
		strSQL = strSQL & "      , FCLTID " '初回登録クライアントＩＤ
		strSQL = strSQL & "      , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , WRTFSTDT " 'タイムスタンプ（登録日）
		strSQL = strSQL & "      , OPEID " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      , CLTID " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      , WRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , WRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , UOPEID " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      , UCLTID " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      , UWRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , UWRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , PGID " 'ＰＧＩＤ
		strSQL = strSQL & "      , DLFLG " '削除フラグ
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        '" & CF_Ora_String(pin_usrURITHA.DATNO_AKA(CInt(pin_intCnt)), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , DATKB " '伝票削除区分
		strSQL = strSQL & "      , '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "' " '赤黒区分
		strSQL = strSQL & "      , DENKB " '伝票区分
		
		'売上伝票番号
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , UDNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt)), 8) & "' "
		End If
		
		' === 20070331 === UPDATE S - ACE)Nagasawa 売上訂正返品対応
		'    strSQL = strSQL & "      , FDNNO "          '納品書№
		
		'納品書№
		If Trim(pin_usrURITHA.FDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , FDNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.FDNNO_AKA(CInt(pin_intCnt)), 8) & "' "
		End If
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "      , JDNNO " '受注伝票番号
		strSQL = strSQL & "      , USDNO " '直送伝票NO
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '売上伝票日付
		strSQL = strSQL & "      , DENDT " '売上日付
		strSQL = strSQL & "      , REGDT " '初回伝票日付
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , TOKRN " '得意先略称
		strSQL = strSQL & "      , NHSCD " '納入先コード
		strSQL = strSQL & "      , NHSRN " '納入先略称
		strSQL = strSQL & "      , NHSNMA " '納入先名称１
		strSQL = strSQL & "      , NHSNMB " '納入先名称２
		strSQL = strSQL & "      , TANCD " '担当者コード
		strSQL = strSQL & "      , TANNM " '担当者名
		strSQL = strSQL & "      , BUMCD " '部門コード
		strSQL = strSQL & "      , BUMNM " '部門名
		strSQL = strSQL & "      , TOKSEICD " '請求先コード
		strSQL = strSQL & "      , SOUCD " '倉庫コード
		strSQL = strSQL & "      , SOUNM " '倉庫名
		strSQL = strSQL & "      , NXTKB " '帳端区分
		strSQL = strSQL & "      , NXTNM " '帳端名称
		strSQL = strSQL & "      , EMGODNKB " '緊急出荷区分
		strSQL = strSQL & "      , OKRJONO " '送り状№
		strSQL = strSQL & "      , INVNO " 'インボイス№
		' === 20070325 === UPDATE S - ACE)Nagasawa 赤伝票も締日付更新
		'    strSQL = strSQL & "      , SMADT "          '経理締日付
		'    strSQL = strSQL & "      , SSADT "          '締日付
		'    strSQL = strSQL & "      , KESDT "          '決済日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '経理締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(CInt(pin_intCnt))) & "' " '締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(CInt(pin_intCnt))) & "' " '決済日付
		' === 20070325 === UPDATE E -
		strSQL = strSQL & "      , NYUCD " '入金区分
		strSQL = strSQL & "      , ZKTKB " '取引区分
		strSQL = strSQL & "      , ZKTNM " '取引区分名
		strSQL = strSQL & "      , KENNMA " '件名１
		strSQL = strSQL & "      , KENNMB " '件名２
		strSQL = strSQL & "      , NHSADA " '納入先住所１
		strSQL = strSQL & "      , NHSADB " '納入先住所２
		strSQL = strSQL & "      , NHSADC " '納入先住所３
		strSQL = strSQL & "      , MAEUKNM " '前受区分名称
		strSQL = strSQL & "      , KEIBUMCD " '経理部門コード
		strSQL = strSQL & "      , UPFKB " '売上同時出荷区分
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			'返品がない場合
			strSQL = strSQL & "      , SBAURIKN * (-1) " '売上金額(本体合計)
			strSQL = strSQL & "      , SBAUZEKN * (-1) " '売上金額(消費税額)
			strSQL = strSQL & "      , SBAUZKKN * (-1) " '売上金額(伝票計)
			strSQL = strSQL & "      , SBAFRUKN * (-1) " '外貨売上金額(伝票計)
			strSQL = strSQL & "      , SBANYUKN * (-1) " '入金金額(伝票計)
			strSQL = strSQL & "      , SBAFRNKN * (-1) " '外貨入金額(伝票計)
		Else
			'返品が存在する場合
			'売上金額(本体合計)
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUrikn_Old(CInt(pin_intCnt)) * (-1)))
			'売上金額(消費税額)
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUzeikn_Old(CInt(pin_intCnt)) * (-1)))
			'売上金額(伝票計)
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUrikn_Old(CInt(pin_intCnt)) * (-1) + pin_usrURITHA.curUzeikn_Old(CInt(pin_intCnt)) * (-1)))
			'外貨売上金額(伝票計)
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curFUrikn_Old(CInt(pin_intCnt)) * (-1)))
			strSQL = strSQL & "      , 0 " '入金金額(伝票計)
			strSQL = strSQL & "      , 0 " '外貨入金額(伝票計)
		End If
		strSQL = strSQL & "      , DENCM " '備考
		strSQL = strSQL & "      , DENCMIN " '社内備考
		strSQL = strSQL & "      , TOKSMEKB " '締区分
		strSQL = strSQL & "      , TOKSMEDD " '締初期日付(売上)
		strSQL = strSQL & "      , TOKSMECC " '締サイクル(売上)
		strSQL = strSQL & "      , TOKSDWKB " '締め曜日
		strSQL = strSQL & "      , TOKKESCC " '回収サイクル
		strSQL = strSQL & "      , TOKKESDD " '回収日付
		strSQL = strSQL & "      , TOKKDWKB " '回収曜日
		strSQL = strSQL & "      , LSTID " '伝票種別
		strSQL = strSQL & "      , TOKJUNKB " '順位表出力区分
		strSQL = strSQL & "      , TOKMSTKB " 'マスタ区分(得意先)
		strSQL = strSQL & "      , TKNRPSKB " '金額端数処理桁数
		strSQL = strSQL & "      , TKNZRNKB " '金額端数処理区分
		strSQL = strSQL & "      , TOKZEIKB " '消費税区分
		strSQL = strSQL & "      , TOKZCLKB " '消費税算出区分
		strSQL = strSQL & "      , TOKRPSKB " '消費税端数処理桁数
		strSQL = strSQL & "      , TOKZRNKB " '消費税端数処理区分
		strSQL = strSQL & "      , TOKNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "      , NHSMSTKB " 'マスタ区分(納入先)
		strSQL = strSQL & "      , NHSNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "      , TANMSTKB " 'マスタ区分(担当者)
		strSQL = strSQL & "      , URIKJN " '売上基準
		strSQL = strSQL & "      , MAEUKKB " '前受区分
		strSQL = strSQL & "      , SEIKB " '請求区分
		strSQL = strSQL & "      , JDNTRKB " '受注取引区分
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , FRNKB " '海外取引区分
		strSQL = strSQL & "      , UDNPRAKB " '納品書発行区分
		strSQL = strSQL & "      , UDNPRBKB " '個別請求発行区分
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' " '元伝票管理番号
		strSQL = strSQL & "      , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '初回登録ユーザーＩＤ
		strSQL = strSQL & "      , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '初回登録クライアントＩＤ
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（登録日）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' " 'ＰＧＩＤ
		strSQL = strSQL & "      ,  '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '削除フラグ
		strSQL = strSQL & "   FROM UDNTHA "
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		
		AE_URIINF_UDNTHA_INS_AKA_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_URIINF_UDNTHA_UPD_SQL
	'   概要：  売上見出しトラン更新SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   　　　  pin_intCnt　      : 番号
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTHA_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTHA_UPD_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTHA SET "
		strSQL = strSQL & "        DATKB    = '" & CF_Ora_String(gc_strDATKB_DEL, 1) & "' " '伝票削除区分
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , UOPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      , UCLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      , UWRTTM   = '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , UWRTDT   = '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , PGID     = '" & CF_Ora_String(SSS_PrgId, 7) & "' " 'ＰＧＩＤ
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		
		AE_URIINF_UDNTHA_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_URIINF_UDNTRA_INS_KRO_SQL
	'   概要：  売上トラン黒伝票作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   　　　  pin_usrURITRA     : 売上トラン更新情報
	'   　　　  pin_intCnt　      : 番号
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTRA_INS_KRO_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTRA_INS_KRO_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTRA "
		strSQL = strSQL & "      ( DATNO " '伝票管理NO.
		strSQL = strSQL & "      , DATKB " '伝票削除区分
		strSQL = strSQL & "      , AKAKROKB " '赤黒区分
		strSQL = strSQL & "      , DENKB " '伝票区分
		strSQL = strSQL & "      , UDNNO " '売上伝票番号
		strSQL = strSQL & "      , LINNO " '行番号
		strSQL = strSQL & "      , ZKTKB " '取引区分
		strSQL = strSQL & "      , ODNNO " '出荷伝票番号
		strSQL = strSQL & "      , ODNLINNO " '行番号
		strSQL = strSQL & "      , JDNNO " '受注伝票番号
		strSQL = strSQL & "      , JDNLINNO " '受注伝票行番号
		strSQL = strSQL & "      , RECNO " 'レコード管理NO.
		strSQL = strSQL & "      , USDNO " '直送伝票NO
		strSQL = strSQL & "      , UDNDT " '売上伝票日付
		strSQL = strSQL & "      , DKBSB " '伝票取引区分種別
		strSQL = strSQL & "      , DKBID " '取引区分コード
		strSQL = strSQL & "      , DKBNM " '取引区分名称
		strSQL = strSQL & "      , HENRSNCD " '返品理由
		strSQL = strSQL & "      , HENSTTCD " '返品状態
		strSQL = strSQL & "      , SMADT " '経理締日付
		strSQL = strSQL & "      , SSADT " '締日付
		strSQL = strSQL & "      , KESDT " '決済日付
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , TANCD " '担当者コード
		strSQL = strSQL & "      , NHSCD " '納入先コード
		strSQL = strSQL & "      , TOKSEICD " '請求先コード
		strSQL = strSQL & "      , SOUCD " '倉庫コード
		strSQL = strSQL & "      , SBNNO " '製番
		strSQL = strSQL & "      , HINCD " '製品コード
		strSQL = strSQL & "      , TOKJDNNO " '客先注文番号
		strSQL = strSQL & "      , HINNMA " '型式
		strSQL = strSQL & "      , HINNMB " '商品名１
		strSQL = strSQL & "      , UNTCD " '単位コード
		strSQL = strSQL & "      , UNTNM " '単位名
		strSQL = strSQL & "      , IRISU " '入数
		strSQL = strSQL & "      , CASSU " 'ケース数
		strSQL = strSQL & "      , URISU " '売上数量
		strSQL = strSQL & "      , URITK " '単価
		strSQL = strSQL & "      , GNKTK " '原価単価
		strSQL = strSQL & "      , SIKTK " '営業仕切単価
		strSQL = strSQL & "      , FURITK " '外貨単価
		strSQL = strSQL & "      , URIKN " '売上金額
		strSQL = strSQL & "      , FURIKN " '外貨売上金額
		strSQL = strSQL & "      , SIKKN " '営業仕切金額
		strSQL = strSQL & "      , UZEKN " '消費税金額
		strSQL = strSQL & "      , NYUDT " '入金日
		strSQL = strSQL & "      , NYUKN " '入金額
		strSQL = strSQL & "      , FNYUKN " '外貨入金額
		strSQL = strSQL & "      , GNKKN " '原価金額
		strSQL = strSQL & "      , JKESIKN " '消込金額
		strSQL = strSQL & "      , FKESIKN " '外貨消込金額
		strSQL = strSQL & "      , KESIKB " '消込区分
		strSQL = strSQL & "      , NYUKB " '入金種別
		strSQL = strSQL & "      , TNKID " '種別
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , RATERT " '為替レート
		strSQL = strSQL & "      , EMGODNKB " '緊急出荷区分
		strSQL = strSQL & "      , OKRJONO " '送り状№
		strSQL = strSQL & "      , INVNO " 'インボイス№
		strSQL = strSQL & "      , LINCMA " '明細備考１
		strSQL = strSQL & "      , LINCMB " '明細備考２
		strSQL = strSQL & "      , BNKCD " '銀行コード
		strSQL = strSQL & "      , BNKNM " '銀行名称
		strSQL = strSQL & "      , TEGNO " '手形番号
		strSQL = strSQL & "      , TEGDT " '手形期日
		strSQL = strSQL & "      , UPDID " '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
		strSQL = strSQL & "      , DFLDKBCD " 'デフォルトコード
		strSQL = strSQL & "      , DKBZAIFL " '在庫関連フラグ
		strSQL = strSQL & "      , DKBTEGFL " '手形発生フラグ
		strSQL = strSQL & "      , DKBFLA " 'ダミーフラグ１
		strSQL = strSQL & "      , DKBFLB " 'ダミーフラグ２
		strSQL = strSQL & "      , DKBFLC " 'ダミーフラグ３
		strSQL = strSQL & "      , LSTID " '伝票種別
		strSQL = strSQL & "      , HINZEIKB " '商品消費税区分
		strSQL = strSQL & "      , HINMSTKB " 'マスタ区分(商品)
		strSQL = strSQL & "      , TOKMSTKB " 'マスタ区分(得意先)
		strSQL = strSQL & "      , NHSMSTKB " 'マスタ区分(納入先)
		strSQL = strSQL & "      , TANMSTKB " 'マスタ区分(担当者)
		strSQL = strSQL & "      , ZEIRNKKB " '消費税ランク
		strSQL = strSQL & "      , HINKB " '商品区分
		strSQL = strSQL & "      , ZEIRT " '消費税率
		strSQL = strSQL & "      , ZAIKB " '在庫管理区分
		strSQL = strSQL & "      , MRPKB " '展開区分
		strSQL = strSQL & "      , HINJUNKB " '順位表出力区分
		strSQL = strSQL & "      , MAKCD " 'メーカーコード
		strSQL = strSQL & "      , HINSIRCD " '商品仕入先コード
		strSQL = strSQL & "      , HINNMMKB " '名称ﾏﾆｭｱﾙ区分(商品)
		strSQL = strSQL & "      , HRTDD " '発注リードタイム
		strSQL = strSQL & "      , ORTDD " '出荷リードタイム
		strSQL = strSQL & "      , ZNKURIKN " '税抜課税対象額
		strSQL = strSQL & "      , ZKMURIKN " '税込課税対象額
		strSQL = strSQL & "      , ZKMUZEKN " '税込消費税
		strSQL = strSQL & "      , MOTDATNO " '元伝票管理番号
		strSQL = strSQL & "      , FOPEID " '初回登録ユーザーＩＤ
		strSQL = strSQL & "      , FCLTID " '初回登録クライアントＩＤ
		strSQL = strSQL & "      , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , WRTFSTDT " 'タイムスタンプ（登録日）
		strSQL = strSQL & "      , OPEID " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      , CLTID " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      , WRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , WRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , UOPEID " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      , UCLTID " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      , UWRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , UWRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , PGID " 'ＰＧＩＤ
		strSQL = strSQL & "      , DLFLG " '削除フラグ
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        '" & CF_Ora_String(pin_usrURITHA.DATNO_KRO(CInt(pin_intCnt)), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , DATKB " '伝票削除区分
		strSQL = strSQL & "      , AKAKROKB " '赤黒区分
		strSQL = strSQL & "      , DENKB " '伝票区分
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.UDNNO_KRO(CInt(pin_intCnt)), 8) & "' " '売上伝票番号
		strSQL = strSQL & "      , LINNO " '行番号
		strSQL = strSQL & "      , ZKTKB " '取引区分
		
		'出荷伝票番号
		If Trim(pin_usrURITHA.ODNNO(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , ODNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.ODNNO(CInt(pin_intCnt)), 8) & "' "
		End If
		
		strSQL = strSQL & "      , ODNLINNO " '行番号
		strSQL = strSQL & "      , JDNNO " '受注伝票番号
		strSQL = strSQL & "      , JDNLINNO " '受注伝票行番号
		strSQL = strSQL & "      , RECNO " 'レコード管理NO.
		strSQL = strSQL & "      , USDNO " '直送伝票NO
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '売上伝票日付
		strSQL = strSQL & "      , DKBSB " '伝票取引区分種別
		strSQL = strSQL & "      , DKBID " '取引区分コード
		strSQL = strSQL & "      , DKBNM " '取引区分名称
		strSQL = strSQL & "      , HENRSNCD " '返品理由
		strSQL = strSQL & "      , HENSTTCD " '返品状態
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '経理締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(CInt(pin_intCnt))) & "' " '締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(CInt(pin_intCnt))) & "' " '決済日付
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TANCD, 6) & "' " '担当者コード
		strSQL = strSQL & "      , NHSCD " '納入先コード
		strSQL = strSQL & "      , TOKSEICD " '請求先コード
		strSQL = strSQL & "      , SOUCD " '倉庫コード
		strSQL = strSQL & "      , SBNNO " '製番
		strSQL = strSQL & "      , HINCD " '製品コード
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.TOKJDNNO, 23) & "' " '客先注文番号
		strSQL = strSQL & "      , HINNMA " '型式
		strSQL = strSQL & "      , HINNMB " '商品名１
		strSQL = strSQL & "      , UNTCD " '単位コード
		strSQL = strSQL & "      , UNTNM " '単位名
		strSQL = strSQL & "      , IRISU " '入数
		strSQL = strSQL & "      , CASSU " 'ケース数
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URISU)) '売上数量
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URITK)) '単価
		'セットアップの場合のみ更新
		If pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SET Then
			strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.SIKTK) '原価単価
		Else
			strSQL = strSQL & "      , GNKTK " '原価単価
		End If
		
		strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.SIKTK) '営業仕切単価
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.FURITK)) '外貨単価
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URIKN)) '売上金額
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.FURIKN)) '外貨売上金額
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.SIKKN)) '営業仕切金額
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.UZEKN)) '消費税金額
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , NYUDT " '入金日
			strSQL = strSQL & "      , NYUKN " '入金額
			strSQL = strSQL & "      , FNYUKN " '外貨入金額
		Else
			strSQL = strSQL & "      , '" & CF_Ora_Date("") & "' " '入金日
			strSQL = strSQL & "      , 0 " '入金額
			strSQL = strSQL & "      , 0 " '外貨入金額
		End If
		
		'セットアップの場合のみ更新
		If pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SET Then
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.SIKKN)) '原価金額
		Else
			If pin_usrURITRA.bolHNPN = True Then
				'返品発生時は再計算
				strSQL = strSQL & "      , GNKTK * " & CF_Ora_Number(CStr(pin_usrURITRA.URISU)) '原価金額
			Else
				strSQL = strSQL & "      , GNKKN " '原価金額
			End If
		End If
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , JKESIKN " '消込金額
			strSQL = strSQL & "      , FKESIKN " '外貨消込金額
			strSQL = strSQL & "      , KESIKB " '消込区分
			strSQL = strSQL & "      , NYUKB " '入金種別
		Else
			strSQL = strSQL & "      , 0 " '消込金額
			strSQL = strSQL & "      , 0 " '外貨消込金額
			strSQL = strSQL & "      , '" & CF_Ora_String(gc_strKESIKB_NOT, 1) & "' " '消込区分
			strSQL = strSQL & "      , '" & CF_Ora_String("", 1) & "' " '入金種別
		End If
		
		strSQL = strSQL & "      , TNKID " '種別
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , RATERT " '為替レート
		strSQL = strSQL & "      , EMGODNKB " '緊急出荷区分
		strSQL = strSQL & "      , OKRJONO " '送り状№
		strSQL = strSQL & "      , INVNO " 'インボイス№
		strSQL = strSQL & "      , LINCMA " '明細備考１
		strSQL = strSQL & "      , LINCMB " '明細備考２
		strSQL = strSQL & "      , BNKCD " '銀行コード
		strSQL = strSQL & "      , BNKNM " '銀行名称
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , TEGNO " '手形番号
			strSQL = strSQL & "      , TEGDT " '手形期日
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String("", 10) & "' " '手形番号
			strSQL = strSQL & "      , '" & CF_Ora_Date("") & "' " '手形期日
		End If
		
		strSQL = strSQL & "      , UPDID " '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
		strSQL = strSQL & "      , DFLDKBCD " 'デフォルトコード
		strSQL = strSQL & "      , DKBZAIFL " '在庫関連フラグ
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , DKBTEGFL " '手形発生フラグ
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String("", 1) & "' " '手形発生フラグ
		End If
		
		strSQL = strSQL & "      , DKBFLA " 'ダミーフラグ１
		strSQL = strSQL & "      , DKBFLB " 'ダミーフラグ２
		strSQL = strSQL & "      , DKBFLC " 'ダミーフラグ３
		strSQL = strSQL & "      , LSTID " '伝票種別
		strSQL = strSQL & "      , HINZEIKB " '商品消費税区分
		strSQL = strSQL & "      , HINMSTKB " 'マスタ区分(商品)
		strSQL = strSQL & "      , TOKMSTKB " 'マスタ区分(得意先)
		strSQL = strSQL & "      , NHSMSTKB " 'マスタ区分(納入先)
		strSQL = strSQL & "      , TANMSTKB " 'マスタ区分(担当者)
		strSQL = strSQL & "      , ZEIRNKKB " '消費税ランク
		strSQL = strSQL & "      , HINKB " '商品区分
		
		' === 20131226 === UPDATE S - RS)Ishida 消費税法改正対応
		'受注訂正時の税率（画面で再計算する税率）を設定する
		'strSQL = strSQL & "      , ZEIRT "          '消費税率
		strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.ZEIRT) '消費税率
		' === 20131226 === UPDATE E -
		
		strSQL = strSQL & "      , ZAIKB " '在庫管理区分
		' === 20071213 === UPDATE S - ACE)Nagasawa 請求書出力区分の追加
		'strSQL = strSQL & "      , MRPKB "          '展開区分
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.MRPKB, 1) & "' " '請求書出力区分
		' === 20071213 === UPDATE E -
		strSQL = strSQL & "      , HINJUNKB " '順位表出力区分
		strSQL = strSQL & "      , MAKCD " 'メーカーコード
		strSQL = strSQL & "      , HINSIRCD " '商品仕入先コード
		strSQL = strSQL & "      , HINNMMKB " '名称ﾏﾆｭｱﾙ区分(商品)
		strSQL = strSQL & "      , HRTDD " '発注リードタイム
		strSQL = strSQL & "      , ORTDD " '出荷リードタイム
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URIKN)) '税抜課税対象額
		' === 20070331 === UPDATE S - ACE)Nagasawa 売上訂正返品対応
		'    strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.URIKN + pin_usrURITRA.UZEKN) '税込課税対象額
		'    strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.UZEKN)               '税込消費税
		strSQL = strSQL & "      , 0 " '税込課税対象額
		strSQL = strSQL & "      , 0 " '税込消費税
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' " '元伝票管理番号
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '初回登録ユーザーＩＤ
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '初回登録クライアントＩＤ
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（登録日）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' " 'ＰＧＩＤ
		strSQL = strSQL & "      ,  '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '削除フラグ
		strSQL = strSQL & "   FROM UDNTRA "
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_usrURITRA.URILINNO, 3) & "' "
		
		AE_URIINF_UDNTRA_INS_KRO_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_URIINF_UDNTRA_INS_AKA_SQL
	'   概要：  売上トラン赤伝票作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   　　　  pin_usrURITRA     : 売上トラン更新情報
	'   　　　  pin_intCnt　      : 番号
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTRA_INS_AKA_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTRA_INS_AKA_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTRA "
		strSQL = strSQL & "      ( DATNO " '伝票管理NO.
		strSQL = strSQL & "      , DATKB " '伝票削除区分
		strSQL = strSQL & "      , AKAKROKB " '赤黒区分
		strSQL = strSQL & "      , DENKB " '伝票区分
		strSQL = strSQL & "      , UDNNO " '売上伝票番号
		strSQL = strSQL & "      , LINNO " '行番号
		strSQL = strSQL & "      , ZKTKB " '取引区分
		strSQL = strSQL & "      , ODNNO " '出荷伝票番号
		strSQL = strSQL & "      , ODNLINNO " '行番号
		strSQL = strSQL & "      , JDNNO " '受注伝票番号
		strSQL = strSQL & "      , JDNLINNO " '受注伝票行番号
		strSQL = strSQL & "      , RECNO " 'レコード管理NO.
		strSQL = strSQL & "      , USDNO " '直送伝票NO
		strSQL = strSQL & "      , UDNDT " '売上伝票日付
		strSQL = strSQL & "      , DKBSB " '伝票取引区分種別
		strSQL = strSQL & "      , DKBID " '取引区分コード
		strSQL = strSQL & "      , DKBNM " '取引区分名称
		strSQL = strSQL & "      , HENRSNCD " '返品理由
		strSQL = strSQL & "      , HENSTTCD " '返品状態
		strSQL = strSQL & "      , SMADT " '経理締日付
		strSQL = strSQL & "      , SSADT " '締日付
		strSQL = strSQL & "      , KESDT " '決済日付
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , TANCD " '担当者コード
		strSQL = strSQL & "      , NHSCD " '納入先コード
		strSQL = strSQL & "      , TOKSEICD " '請求先コード
		strSQL = strSQL & "      , SOUCD " '倉庫コード
		strSQL = strSQL & "      , SBNNO " '製番
		strSQL = strSQL & "      , HINCD " '製品コード
		strSQL = strSQL & "      , TOKJDNNO " '客先注文番号
		strSQL = strSQL & "      , HINNMA " '型式
		strSQL = strSQL & "      , HINNMB " '商品名１
		strSQL = strSQL & "      , UNTCD " '単位コード
		strSQL = strSQL & "      , UNTNM " '単位名
		strSQL = strSQL & "      , IRISU " '入数
		strSQL = strSQL & "      , CASSU " 'ケース数
		strSQL = strSQL & "      , URISU " '売上数量
		strSQL = strSQL & "      , URITK " '単価
		strSQL = strSQL & "      , GNKTK " '原価単価
		strSQL = strSQL & "      , SIKTK " '営業仕切単価
		strSQL = strSQL & "      , FURITK " '外貨単価
		strSQL = strSQL & "      , URIKN " '売上金額
		strSQL = strSQL & "      , FURIKN " '外貨売上金額
		strSQL = strSQL & "      , SIKKN " '営業仕切金額
		strSQL = strSQL & "      , UZEKN " '消費税金額
		strSQL = strSQL & "      , NYUDT " '入金日
		strSQL = strSQL & "      , NYUKN " '入金額
		strSQL = strSQL & "      , FNYUKN " '外貨入金額
		strSQL = strSQL & "      , GNKKN " '原価金額
		strSQL = strSQL & "      , JKESIKN " '消込金額
		strSQL = strSQL & "      , FKESIKN " '外貨消込金額
		strSQL = strSQL & "      , KESIKB " '消込区分
		strSQL = strSQL & "      , NYUKB " '入金種別
		strSQL = strSQL & "      , TNKID " '種別
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , RATERT " '為替レート
		strSQL = strSQL & "      , EMGODNKB " '緊急出荷区分
		strSQL = strSQL & "      , OKRJONO " '送り状№
		strSQL = strSQL & "      , INVNO " 'インボイス№
		strSQL = strSQL & "      , LINCMA " '明細備考１
		strSQL = strSQL & "      , LINCMB " '明細備考２
		strSQL = strSQL & "      , BNKCD " '銀行コード
		strSQL = strSQL & "      , BNKNM " '銀行名称
		strSQL = strSQL & "      , TEGNO " '手形番号
		strSQL = strSQL & "      , TEGDT " '手形期日
		strSQL = strSQL & "      , UPDID " '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
		strSQL = strSQL & "      , DFLDKBCD " 'デフォルトコード
		strSQL = strSQL & "      , DKBZAIFL " '在庫関連フラグ
		strSQL = strSQL & "      , DKBTEGFL " '手形発生フラグ
		strSQL = strSQL & "      , DKBFLA " 'ダミーフラグ１
		strSQL = strSQL & "      , DKBFLB " 'ダミーフラグ２
		strSQL = strSQL & "      , DKBFLC " 'ダミーフラグ３
		strSQL = strSQL & "      , LSTID " '伝票種別
		strSQL = strSQL & "      , HINZEIKB " '商品消費税区分
		strSQL = strSQL & "      , HINMSTKB " 'マスタ区分(商品)
		strSQL = strSQL & "      , TOKMSTKB " 'マスタ区分(得意先)
		strSQL = strSQL & "      , NHSMSTKB " 'マスタ区分(納入先)
		strSQL = strSQL & "      , TANMSTKB " 'マスタ区分(担当者)
		strSQL = strSQL & "      , ZEIRNKKB " '消費税ランク
		strSQL = strSQL & "      , HINKB " '商品区分
		strSQL = strSQL & "      , ZEIRT " '消費税率
		strSQL = strSQL & "      , ZAIKB " '在庫管理区分
		strSQL = strSQL & "      , MRPKB " '展開区分
		strSQL = strSQL & "      , HINJUNKB " '順位表出力区分
		strSQL = strSQL & "      , MAKCD " 'メーカーコード
		strSQL = strSQL & "      , HINSIRCD " '商品仕入先コード
		strSQL = strSQL & "      , HINNMMKB " '名称ﾏﾆｭｱﾙ区分(商品)
		strSQL = strSQL & "      , HRTDD " '発注リードタイム
		strSQL = strSQL & "      , ORTDD " '出荷リードタイム
		strSQL = strSQL & "      , ZNKURIKN " '税抜課税対象額
		strSQL = strSQL & "      , ZKMURIKN " '税込課税対象額
		strSQL = strSQL & "      , ZKMUZEKN " '税込消費税
		strSQL = strSQL & "      , MOTDATNO " '元伝票管理番号
		strSQL = strSQL & "      , FOPEID " '初回登録ユーザーＩＤ
		strSQL = strSQL & "      , FCLTID " '初回登録クライアントＩＤ
		strSQL = strSQL & "      , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , WRTFSTDT " 'タイムスタンプ（登録日）
		strSQL = strSQL & "      , OPEID " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      , CLTID " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      , WRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , WRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , UOPEID " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      , UCLTID " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      , UWRTTM " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , UWRTDT " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , PGID " 'ＰＧＩＤ
		strSQL = strSQL & "      , DLFLG " '削除フラグ
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        '" & CF_Ora_String(pin_usrURITHA.DATNO_AKA(CInt(pin_intCnt)), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , DATKB " '伝票削除区分
		strSQL = strSQL & "      , '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "' " '赤黒区分
		strSQL = strSQL & "      , DENKB " '伝票区分
		
		'売上伝票番号
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , UDNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt)), 8) & "' "
		End If
		
		strSQL = strSQL & "      , LINNO " '行番号
		strSQL = strSQL & "      , ZKTKB " '取引区分
		
		'出荷伝票番号
		If Trim(pin_usrURITHA.ODNNO(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , ODNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.ODNNO(CInt(pin_intCnt)), 8) & "' "
		End If
		
		strSQL = strSQL & "      , ODNLINNO " '行番号
		strSQL = strSQL & "      , JDNNO " '受注伝票番号
		strSQL = strSQL & "      , JDNLINNO " '受注伝票行番号
		strSQL = strSQL & "      , RECNO " 'レコード管理NO.
		strSQL = strSQL & "      , USDNO " '直送伝票NO
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '売上伝票日付
		strSQL = strSQL & "      , DKBSB " '伝票取引区分種別
		strSQL = strSQL & "      , DKBID " '取引区分コード
		strSQL = strSQL & "      , DKBNM " '取引区分名称
		strSQL = strSQL & "      , HENRSNCD " '返品理由
		strSQL = strSQL & "      , HENSTTCD " '返品状態
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '経理締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(CInt(pin_intCnt))) & "' " '締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(CInt(pin_intCnt))) & "' " '決済日付
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , TANCD " '担当者コード
		strSQL = strSQL & "      , NHSCD " '納入先コード
		strSQL = strSQL & "      , TOKSEICD " '請求先コード
		strSQL = strSQL & "      , SOUCD " '倉庫コード
		strSQL = strSQL & "      , SBNNO " '製番
		strSQL = strSQL & "      , HINCD " '製品コード
		strSQL = strSQL & "      , TOKJDNNO " '客先注文番号
		strSQL = strSQL & "      , HINNMA " '型式
		strSQL = strSQL & "      , HINNMB " '商品名１
		strSQL = strSQL & "      , UNTCD " '単位コード
		strSQL = strSQL & "      , UNTNM " '単位名
		strSQL = strSQL & "      , IRISU " '入数
		strSQL = strSQL & "      , CASSU * (-1) " 'ケース数
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URISU)) * (-1) '売上数量
		strSQL = strSQL & "      , URITK " '単価
		strSQL = strSQL & "      , GNKTK " '原価単価
		strSQL = strSQL & "      , SIKTK " '営業仕切単価
		strSQL = strSQL & "      , FURITK " '外貨単価
		
		If pin_usrURITRA.bolHNPN = False Then
			'返品なしの場合
			strSQL = strSQL & "      , URIKN  * (-1) " '売上金額
			strSQL = strSQL & "      , FURIKN  * (-1) " '外貨売上金額
			strSQL = strSQL & "      , SIKKN  * (-1) " '営業仕切金額
			strSQL = strSQL & "      , UZEKN  * (-1) " '消費税金額
		Else
			'返品がある場合
			'売上金額
			strSQL = strSQL & "      , URIKN * (-1) + " & CF_Ora_Number(CStr(pin_usrURITRA.HNURIKN))
			'外貨売上金額
			strSQL = strSQL & "      , FURIKN  * (-1) + " & CF_Ora_Number(CStr(pin_usrURITRA.HNFURIKN))
			'営業仕切金額
			strSQL = strSQL & "      , SIKTK  * (-1) * " & CF_Ora_Number(CStr(pin_usrURITRA.URISU))
			'消費税金額
			strSQL = strSQL & "      , UZEKN * (-1) + " & CF_Ora_Number(CStr(pin_usrURITRA.HNUZEKN))
		End If
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , NYUDT " '入金日
			strSQL = strSQL & "      , NYUKN  * (-1) " '入金額
			strSQL = strSQL & "      , FNYUKN  * (-1) " '外貨入金額
		Else
			strSQL = strSQL & "      , '" & CF_Ora_Date("") & "' " '入金日
			strSQL = strSQL & "      , 0 " '入金額
			strSQL = strSQL & "      , 0 " '外貨入金額
		End If
		
		If pin_usrURITRA.bolHNPN = False Then
			'返品なしの場合
			strSQL = strSQL & "      , GNKKN  * (-1) " '原価金額
		Else
			'返品がある場合
			'原価金額
			strSQL = strSQL & "      , GNKTK  * (-1) * " & CF_Ora_Number(CStr(pin_usrURITRA.URISU))
		End If
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , JKESIKN  * (-1) " '消込金額
			strSQL = strSQL & "      , FKESIKN  * (-1) " '外貨消込金額
			strSQL = strSQL & "      , KESIKB " '消込区分
			strSQL = strSQL & "      , NYUKB " '入金種別
		Else
			strSQL = strSQL & "      , 0 " '消込金額
			strSQL = strSQL & "      , 0 " '外貨消込金額
			strSQL = strSQL & "      , '" & CF_Ora_String(gc_strKESIKB_NOT, 1) & "' " '消込区分
			strSQL = strSQL & "      , '" & CF_Ora_String("", 1) & "' " '入金種別
		End If
		
		strSQL = strSQL & "      , TNKID " '種別
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , RATERT " '為替レート
		strSQL = strSQL & "      , EMGODNKB " '緊急出荷区分
		strSQL = strSQL & "      , OKRJONO " '送り状№
		strSQL = strSQL & "      , INVNO " 'インボイス№
		strSQL = strSQL & "      , LINCMA " '明細備考１
		strSQL = strSQL & "      , LINCMB " '明細備考２
		strSQL = strSQL & "      , BNKCD " '銀行コード
		strSQL = strSQL & "      , BNKNM " '銀行名称
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , TEGNO " '手形番号
			strSQL = strSQL & "      , TEGDT " '手形期日
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String("", 10) & "' " '手形番号
			strSQL = strSQL & "      , '" & CF_Ora_Date("") & "' " '手形期日
		End If
		
		strSQL = strSQL & "      , UPDID " '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
		strSQL = strSQL & "      , DFLDKBCD " 'デフォルトコード
		strSQL = strSQL & "      , DKBZAIFL " '在庫関連フラグ
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , DKBTEGFL " '手形発生フラグ
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String("", 1) & "' " '手形発生フラグ
		End If
		
		strSQL = strSQL & "      , DKBFLA " 'ダミーフラグ１
		strSQL = strSQL & "      , DKBFLB " 'ダミーフラグ２
		strSQL = strSQL & "      , DKBFLC " 'ダミーフラグ３
		strSQL = strSQL & "      , LSTID " '伝票種別
		strSQL = strSQL & "      , HINZEIKB " '商品消費税区分
		strSQL = strSQL & "      , HINMSTKB " 'マスタ区分(商品)
		strSQL = strSQL & "      , TOKMSTKB " 'マスタ区分(得意先)
		strSQL = strSQL & "      , NHSMSTKB " 'マスタ区分(納入先)
		strSQL = strSQL & "      , TANMSTKB " 'マスタ区分(担当者)
		strSQL = strSQL & "      , ZEIRNKKB " '消費税ランク
		strSQL = strSQL & "      , HINKB " '商品区分
		strSQL = strSQL & "      , ZEIRT " '消費税率
		strSQL = strSQL & "      , ZAIKB " '在庫管理区分
		' === 20071213 === UPDATE S - ACE)Nagasawa 請求書出力区分の追加
		'strSQL = strSQL & "      , MRPKB "          '展開区分
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.MRPKB, 1) & "' " '請求書出力区分
		' === 20071213 === UPDATE E -
		strSQL = strSQL & "      , HINJUNKB " '順位表出力区分
		strSQL = strSQL & "      , MAKCD " 'メーカーコード
		strSQL = strSQL & "      , HINSIRCD " '商品仕入先コード
		strSQL = strSQL & "      , HINNMMKB " '名称ﾏﾆｭｱﾙ区分(商品)
		strSQL = strSQL & "      , HRTDD " '発注リードタイム
		strSQL = strSQL & "      , ORTDD " '出荷リードタイム
		
		If pin_usrURITRA.bolHNPN = False Then
			'返品なしの場合
			strSQL = strSQL & "      , ZNKURIKN  * (-1) " '税抜課税対象額
			strSQL = strSQL & "      , ZKMURIKN  * (-1) " '税込課税対象額
			strSQL = strSQL & "      , ZKMUZEKN  * (-1) " '税込消費税
		Else
			'返品がある場合
			'税抜課税対象額
			strSQL = strSQL & "      , ZNKURIKN  * (-1) + " & CF_Ora_Number(CStr(pin_usrURITRA.HNURIKN))
			' === 20070331 === UPDATE S - ACE)Nagasawa 売上訂正返品対応
			'        '税込課税対象額
			'        strSQL = strSQL & "      , ZKMURIKN  * (-1) + " & CF_Ora_Number(pin_usrURITRA.HNURIKN + pin_usrURITRA.HNUZEKN)
			'        '税込消費税
			'        strSQL = strSQL & "      , ZKMUZEKN  * (-1) + " & CF_Ora_Number(pin_usrURITRA.HNUZEKN)
			strSQL = strSQL & "      , 0 " '税込課税対象額
			strSQL = strSQL & "      , 0 " '税込消費税
			' === 20070331 === UPDATE E -
		End If
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' " '元伝票管理番号
		strSQL = strSQL & "      , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '初回登録ユーザーＩＤ
		strSQL = strSQL & "      , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '初回登録クライアントＩＤ
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（登録日）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' " 'ＰＧＩＤ
		strSQL = strSQL & "      ,  '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '削除フラグ
		strSQL = strSQL & "   FROM UDNTRA "
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_usrURITRA.URILINNO, 3) & "' "
		
		AE_URIINF_UDNTRA_INS_AKA_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_URIINF_UDNTRA_UPD_SQL
	'   概要：  売上トラン更新SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   　　　  pin_usrURITRA     : 売上トラン更新情報
	'   　　　  pin_intCnt　      : 番号
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTRA_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTRA_UPD_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTRA SET "
		strSQL = strSQL & "        DATKB    = '" & CF_Ora_String(gc_strDATKB_DEL, 1) & "' " '伝票削除区分
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（訂正）
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（訂正）
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , UOPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      , UCLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      , UWRTTM   = '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , UWRTDT   = '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , PGID     = '" & CF_Ora_String(SSS_PrgId, 7) & "' " 'ＰＧＩＤ
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_usrURITRA.URILINNO, 3) & "' "
		
		AE_URIINF_UDNTRA_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSINF_UPDATE
	'   概要：  売掛、請求サマリ情報更新処理
	'   引数：  pin_usrURITHA     : 売上見出し情報
	'   戻値：  0：正常　9: 異常
	'   備考：  パラメータの値を元に売掛、請求サマリ情報を更新する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSINF_UPDATE(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim intRet As Short
		Dim intCnt As Short
		
		On Error GoTo AE_TOKSINF_UPDATE_Err
		
		AE_TOKSINF_UPDATE = 9
		
		'サマリ更新
		Select Case True
			'国内、前受なし
			Case pin_usrURITHA.FRNKB = gc_strFRNKB_DMS And pin_usrURITHA.MAEUKKB = gc_strMAEUKKB_NML
				
				'売掛サマリ更新
				intRet = AE_TOKSMA_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				'売掛サマリ請求更新
				intRet = AE_TOKSME_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				For intCnt = 1 To UBound(pin_usrURITHA.SSADT)
					
					'請求サマリ更新
					intRet = AE_TOKSSA_UPD_Main(intCnt, pin_usrURITHA)
					If intRet <> 0 Then
						GoTo AE_TOKSINF_UPDATE_Err
					End If
				Next 
				
				'国内、前受
			Case pin_usrURITHA.FRNKB = gc_strFRNKB_DMS And pin_usrURITHA.MAEUKKB = gc_strMAEUKKB_MAE
				
				'売掛サマリ更新
				intRet = AE_TOKSMA_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				'売掛サマリ請求更新
				intRet = AE_TOKSME_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				For intCnt = 1 To UBound(pin_usrURITHA.SSADT)
					
					'前受請求サマリ更新
					intRet = AE_TOKSSB_UPD_Main(intCnt, pin_usrURITHA)
					If intRet <> 0 Then
						GoTo AE_TOKSINF_UPDATE_Err
					End If
				Next 
				
				'海外
			Case pin_usrURITHA.FRNKB = gc_strFRNKB_FRN
				'売掛サマリ更新
				intRet = AE_TOKSMA_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				'売掛サマリ外貨更新
				intRet = AE_TOKSMD_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				'売掛サマリ請求更新
				intRet = AE_TOKSME_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				For intCnt = 1 To UBound(pin_usrURITHA.SSADT)
					'請求サマリ更新
					intRet = AE_TOKSSA_UPD_Main(intCnt, pin_usrURITHA)
					If intRet <> 0 Then
						GoTo AE_TOKSINF_UPDATE_Err
					End If
					
					'請求サマリ外貨更新
					intRet = AE_TOKSSC_UPD_Main(intCnt, pin_usrURITHA)
					If intRet <> 0 Then
						GoTo AE_TOKSINF_UPDATE_Err
					End If
				Next 
				
			Case Else
		End Select
		
		AE_TOKSINF_UPDATE = 0
		
AE_TOKSINF_UPDATE_End: 
		Exit Function
		
AE_TOKSINF_UPDATE_Err: 
		GoTo AE_TOKSINF_UPDATE_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSMA_UPD_Main
	'   概要：  売掛サマリ更新
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  0：正常　9: 異常
	'   備考：  売掛サマリに追加、更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMA_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: 構造体 usrOdy_TOKSMA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_TOKSMA As U_Ody
		
		On Error GoTo AE_TOKSMA_UPD_Main_Err
		
		AE_TOKSMA_UPD_Main = 9
		bolTran = False
		
		'売掛サマリ検索
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSMA "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND SMADT  = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSMA, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSMA_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_TOKSMA, CNT, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Ora_GetDyn(usrOdy_TOKSMA, "CNT", 0) = 0 Then
			'売掛サマリの作成
			strSQL = AE_TOKSMA_INS_SQL(pin_usrURITHA)
		Else
			'売掛サマリの更新
			strSQL = AE_TOKSMA_UPD_SQL(pin_usrURITHA)
		End If
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSMA_UPD_Main_Err
		End If
		
		AE_TOKSMA_UPD_Main = 0
		
AE_TOKSMA_UPD_Main_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_TOKSMA)
		End If
		
		Exit Function
		
AE_TOKSMA_UPD_Main_Err: 
		'エラー箇所編集
		pin_usrURITHA.strErr = "AE_TOKSMA_UPD_Main"
		GoTo AE_TOKSMA_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSMA_INS_SQL
	'   概要：  売掛サマリ作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMA_INS_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMAURIKN As Decimal
		Dim curSMAUZEKN As Decimal
		
		AE_TOKSMA_INS_SQL = ""
		
		'売上金額の差分算出
		curSMAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'消費税額の差分算出
		curSMAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSMA "
		strSQL = strSQL & "      ( TOKCD " '得意先コード
		strSQL = strSQL & "      , SMADT " '経理締日付
		strSQL = strSQL & "      , SMAURIKN00 " '売上集計金額00
		strSQL = strSQL & "      , SMAURIKN01 " '売上集計金額01
		strSQL = strSQL & "      , SMAURIKN02 " '売上集計金額02
		strSQL = strSQL & "      , SMAURIKN03 " '売上集計金額03
		strSQL = strSQL & "      , SMAURIKN04 " '売上集計金額04
		strSQL = strSQL & "      , SMAURIKN05 " '売上集計金額05
		strSQL = strSQL & "      , SMAURIKN06 " '売上集計金額06
		strSQL = strSQL & "      , SMAURIKN07 " '売上集計金額07
		strSQL = strSQL & "      , SMAURIKN08 " '売上集計金額08
		strSQL = strSQL & "      , SMAURIKN09 " '売上集計金額09
		strSQL = strSQL & "      , SMAUZEKN " '売上消費税金額
		strSQL = strSQL & "      , SZAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SZBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SMAGNKKN00 " '原価集計金額00
		strSQL = strSQL & "      , SMAGNKKN01 " '原価集計金額01
		strSQL = strSQL & "      , SMAGNKKN02 " '原価集計金額02
		strSQL = strSQL & "      , SMAGNKKN03 " '原価集計金額03
		strSQL = strSQL & "      , SMAGNKKN04 " '原価集計金額04
		strSQL = strSQL & "      , SMAGNKKN05 " '原価集計金額05
		strSQL = strSQL & "      , SMAGNKKN06 " '原価集計金額06
		strSQL = strSQL & "      , SMAGNKKN07 " '原価集計金額07
		strSQL = strSQL & "      , SMAGNKKN08 " '原価集計金額08
		strSQL = strSQL & "      , SMAGNKKN09 " '原価集計金額09
		strSQL = strSQL & "      , SMANYUKN00 " '入金集計金額00
		strSQL = strSQL & "      , SMANYUKN01 " '入金集計金額01
		strSQL = strSQL & "      , SMANYUKN02 " '入金集計金額02
		strSQL = strSQL & "      , SMANYUKN03 " '入金集計金額03
		strSQL = strSQL & "      , SMANYUKN04 " '入金集計金額04
		strSQL = strSQL & "      , SMANYUKN05 " '入金集計金額05
		strSQL = strSQL & "      , SMANYUKN06 " '入金集計金額06
		strSQL = strSQL & "      , SMANYUKN07 " '入金集計金額07
		strSQL = strSQL & "      , SMANYUKN08 " '入金集計金額08
		strSQL = strSQL & "      , SMANYUKN09 " '入金集計金額09
		strSQL = strSQL & "      , DATNO " '伝票管理NO.
		strSQL = strSQL & "      , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '経理締日付
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMAURIKN)) '売上集計金額00
		strSQL = strSQL & "      , 0 " '売上集計金額01
		strSQL = strSQL & "      , 0 " '売上集計金額02
		strSQL = strSQL & "      , 0 " '売上集計金額03
		strSQL = strSQL & "      , 0 " '売上集計金額04
		strSQL = strSQL & "      , 0 " '売上集計金額05
		strSQL = strSQL & "      , 0 " '売上集計金額06
		strSQL = strSQL & "      , 0 " '売上集計金額07
		strSQL = strSQL & "      , 0 " '売上集計金額08
		strSQL = strSQL & "      , 0 " '売上集計金額09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMAUZEKN)) '売上消費税金額
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " '原価集計金額00
		strSQL = strSQL & "      , 0 " '原価集計金額01
		strSQL = strSQL & "      , 0 " '原価集計金額02
		strSQL = strSQL & "      , 0 " '原価集計金額03
		strSQL = strSQL & "      , 0 " '原価集計金額04
		strSQL = strSQL & "      , 0 " '原価集計金額05
		strSQL = strSQL & "      , 0 " '原価集計金額06
		strSQL = strSQL & "      , 0 " '原価集計金額07
		strSQL = strSQL & "      , 0 " '原価集計金額08
		strSQL = strSQL & "      , 0 " '原価集計金額09
		strSQL = strSQL & "      , 0 " '入金集計金額00
		strSQL = strSQL & "      , 0 " '入金集計金額01
		strSQL = strSQL & "      , 0 " '入金集計金額02
		strSQL = strSQL & "      , 0 " '入金集計金額03
		strSQL = strSQL & "      , 0 " '入金集計金額04
		strSQL = strSQL & "      , 0 " '入金集計金額05
		strSQL = strSQL & "      , 0 " '入金集計金額06
		strSQL = strSQL & "      , 0 " '入金集計金額07
		strSQL = strSQL & "      , 0 " '入金集計金額08
		strSQL = strSQL & "      , 0 " '入金集計金額09
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      ) "
		
		AE_TOKSMA_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSMA_UPD_SQL
	'   概要：  売掛サマリ更新SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMA_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMAURIKN As Decimal
		Dim curSMAUZEKN As Decimal
		
		AE_TOKSMA_UPD_SQL = ""
		
		'売上金額の差分算出
		curSMAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'消費税額の差分算出
		curSMAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSMA SET "
		strSQL = strSQL & "        SMAURIKN00 = SMAURIKN00 + " & CF_Ora_Number(CStr(curSMAURIKN)) '売上集計金額00
		strSQL = strSQL & "      , SMAUZEKN   = SMAUZEKN   + " & CF_Ora_Number(CStr(curSMAUZEKN)) '売上消費税金額
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		AE_TOKSMA_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSMD_UPD_Main
	'   概要：  売掛サマリ外貨更新
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  0：正常　9: 異常
	'   備考：  売掛サマリ外貨に追加、更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMD_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: 構造体 usrOdy_TOKSMD の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_TOKSMD As U_Ody
		
		On Error GoTo AE_TOKSMD_UPD_Main_Err
		
		AE_TOKSMD_UPD_Main = 9
		bolTran = False
		
		'売掛サマリ外貨検索
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSMD "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' "
		strSQL = strSQL & "    AND SMADT  = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSMD, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSMD_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_TOKSMD, CNT, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Ora_GetDyn(usrOdy_TOKSMD, "CNT", 0) = 0 Then
			'売掛サマリ外貨の作成
			strSQL = AE_TOKSMD_INS_SQL(pin_usrURITHA)
		Else
			'売掛サマリ外貨の更新
			strSQL = AE_TOKSMD_UPD_SQL(pin_usrURITHA)
		End If
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSMD_UPD_Main_Err
		End If
		
		AE_TOKSMD_UPD_Main = 0
		
AE_TOKSMD_UPD_Main_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_TOKSMD)
		End If
		
		Exit Function
		
AE_TOKSMD_UPD_Main_Err: 
		'エラー箇所編集
		pin_usrURITHA.strErr = "AE_TOKSMD_UPD_Main"
		GoTo AE_TOKSMD_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSMD_INS_SQL
	'   概要：  売掛サマリ外貨作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMD_INS_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMDURIKN As Decimal
		Dim curSMDUZEKN As Decimal
		
		AE_TOKSMD_INS_SQL = ""
		
		'売上金額の差分算出
		curSMDURIKN = pin_usrURITHA.curSFUrikn_New - pin_usrURITHA.curSFUrikn_Old
		'消費税額の算出
		curSMDUZEKN = 0
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSMD "
		strSQL = strSQL & "      ( TOKCD " '得意先コード
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , SMADT " '経理締日付
		strSQL = strSQL & "      , SMDURIKN00 " '売上集計金額00
		strSQL = strSQL & "      , SMDURIKN01 " '売上集計金額01
		strSQL = strSQL & "      , SMDURIKN02 " '売上集計金額02
		strSQL = strSQL & "      , SMDURIKN03 " '売上集計金額03
		strSQL = strSQL & "      , SMDURIKN04 " '売上集計金額04
		strSQL = strSQL & "      , SMDURIKN05 " '売上集計金額05
		strSQL = strSQL & "      , SMDURIKN06 " '売上集計金額06
		strSQL = strSQL & "      , SMDURIKN07 " '売上集計金額07
		strSQL = strSQL & "      , SMDURIKN08 " '売上集計金額08
		strSQL = strSQL & "      , SMDURIKN09 " '売上集計金額09
		strSQL = strSQL & "      , SMDUZEKN " '売上消費税金額
		strSQL = strSQL & "      , FAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , FAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , FAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , FAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , FAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , FAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , FBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , FBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , FBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , FBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , FBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , FBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SMDGNKKN00 " '原価集計金額00
		strSQL = strSQL & "      , SMDGNKKN01 " '原価集計金額01
		strSQL = strSQL & "      , SMDGNKKN02 " '原価集計金額02
		strSQL = strSQL & "      , SMDGNKKN03 " '原価集計金額03
		strSQL = strSQL & "      , SMDGNKKN04 " '原価集計金額04
		strSQL = strSQL & "      , SMDGNKKN05 " '原価集計金額05
		strSQL = strSQL & "      , SMDGNKKN06 " '原価集計金額06
		strSQL = strSQL & "      , SMDGNKKN07 " '原価集計金額07
		strSQL = strSQL & "      , SMDGNKKN08 " '原価集計金額08
		strSQL = strSQL & "      , SMDGNKKN09 " '原価集計金額09
		strSQL = strSQL & "      , SMDNYUKN00 " '入金集計金額00
		strSQL = strSQL & "      , SMDNYUKN01 " '入金集計金額01
		strSQL = strSQL & "      , SMDNYUKN02 " '入金集計金額02
		strSQL = strSQL & "      , SMDNYUKN03 " '入金集計金額03
		strSQL = strSQL & "      , SMDNYUKN04 " '入金集計金額04
		strSQL = strSQL & "      , SMDNYUKN05 " '入金集計金額05
		strSQL = strSQL & "      , SMDNYUKN06 " '入金集計金額06
		strSQL = strSQL & "      , SMDNYUKN07 " '入金集計金額07
		strSQL = strSQL & "      , SMDNYUKN08 " '入金集計金額08
		strSQL = strSQL & "      , SMDNYUKN09 " '入金集計金額09
		strSQL = strSQL & "      , DATNO " '伝票管理NO.
		strSQL = strSQL & "      , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' " '通貨区分
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '経理締日付
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMDURIKN)) '売上集計金額00
		strSQL = strSQL & "      , 0 " '売上集計金額01
		strSQL = strSQL & "      , 0 " '売上集計金額02
		strSQL = strSQL & "      , 0 " '売上集計金額03
		strSQL = strSQL & "      , 0 " '売上集計金額04
		strSQL = strSQL & "      , 0 " '売上集計金額05
		strSQL = strSQL & "      , 0 " '売上集計金額06
		strSQL = strSQL & "      , 0 " '売上集計金額07
		strSQL = strSQL & "      , 0 " '売上集計金額08
		strSQL = strSQL & "      , 0 " '売上集計金額09
		strSQL = strSQL & "      , 0 " '売上消費税金額
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " '原価集計金額00
		strSQL = strSQL & "      , 0 " '原価集計金額01
		strSQL = strSQL & "      , 0 " '原価集計金額02
		strSQL = strSQL & "      , 0 " '原価集計金額03
		strSQL = strSQL & "      , 0 " '原価集計金額04
		strSQL = strSQL & "      , 0 " '原価集計金額05
		strSQL = strSQL & "      , 0 " '原価集計金額06
		strSQL = strSQL & "      , 0 " '原価集計金額07
		strSQL = strSQL & "      , 0 " '原価集計金額08
		strSQL = strSQL & "      , 0 " '原価集計金額09
		strSQL = strSQL & "      , 0 " '入金集計金額00
		strSQL = strSQL & "      , 0 " '入金集計金額01
		strSQL = strSQL & "      , 0 " '入金集計金額02
		strSQL = strSQL & "      , 0 " '入金集計金額03
		strSQL = strSQL & "      , 0 " '入金集計金額04
		strSQL = strSQL & "      , 0 " '入金集計金額05
		strSQL = strSQL & "      , 0 " '入金集計金額06
		strSQL = strSQL & "      , 0 " '入金集計金額07
		strSQL = strSQL & "      , 0 " '入金集計金額08
		strSQL = strSQL & "      , 0 " '入金集計金額09
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      ) "
		
		AE_TOKSMD_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSMD_UPD_SQL
	'   概要：  売掛サマリ外貨更新SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMD_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMDURIKN As Decimal
		
		AE_TOKSMD_UPD_SQL = ""
		
		'売上金額の差分算出
		curSMDURIKN = pin_usrURITHA.curSFUrikn_New - pin_usrURITHA.curSFUrikn_Old
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSMD SET "
		strSQL = strSQL & "        SMDURIKN00 = SMDURIKN00 + " & CF_Ora_Number(CStr(curSMDURIKN)) '売上集計金額00
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' "
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		AE_TOKSMD_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSME_UPD_Main
	'   概要：  売掛サマリ請求更新
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  0：正常　9: 異常
	'   備考：  売掛サマリ請求に追加、更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSME_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: 構造体 usrOdy_TOKSME の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_TOKSME As U_Ody
		
		On Error GoTo AE_TOKSME_UPD_Main_Err
		
		AE_TOKSME_UPD_Main = 9
		bolTran = False
		
		'売掛サマリ請求検索
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSME "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SMADT  = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSME, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSME_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_TOKSME, CNT, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Ora_GetDyn(usrOdy_TOKSME, "CNT", 0) = 0 Then
			'売掛サマリ請求の作成
			strSQL = AE_TOKSME_INS_SQL(pin_usrURITHA)
		Else
			'売掛サマリ請求の更新
			strSQL = AE_TOKSME_UPD_SQL(pin_usrURITHA)
		End If
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSME_UPD_Main_Err
		End If
		
		AE_TOKSME_UPD_Main = 0
		
AE_TOKSME_UPD_Main_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_TOKSME)
		End If
		
		Exit Function
		
AE_TOKSME_UPD_Main_Err: 
		'エラー箇所編集
		pin_usrURITHA.strErr = "AE_TOKSME_UPD_Main"
		GoTo AE_TOKSME_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSME_INS_SQL
	'   概要：  売掛サマリ請求作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSME_INS_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMAURIKN As Decimal
		Dim curSMAUZEKN As Decimal
		
		AE_TOKSME_INS_SQL = ""
		
		'売上金額の差分算出
		curSMAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'消費税額の差分算出
		curSMAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSME "
		strSQL = strSQL & "      ( TOKCD " '得意先コード
		strSQL = strSQL & "      , SMADT " '経理締日付
		strSQL = strSQL & "      , SMAURIKN00 " '売上集計金額00
		strSQL = strSQL & "      , SMAURIKN01 " '売上集計金額01
		strSQL = strSQL & "      , SMAURIKN02 " '売上集計金額02
		strSQL = strSQL & "      , SMAURIKN03 " '売上集計金額03
		strSQL = strSQL & "      , SMAURIKN04 " '売上集計金額04
		strSQL = strSQL & "      , SMAURIKN05 " '売上集計金額05
		strSQL = strSQL & "      , SMAURIKN06 " '売上集計金額06
		strSQL = strSQL & "      , SMAURIKN07 " '売上集計金額07
		strSQL = strSQL & "      , SMAURIKN08 " '売上集計金額08
		strSQL = strSQL & "      , SMAURIKN09 " '売上集計金額09
		strSQL = strSQL & "      , SMAUZEKN " '売上消費税金額
		strSQL = strSQL & "      , SZAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SZBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SMAGNKKN00 " '原価集計金額00
		strSQL = strSQL & "      , SMAGNKKN01 " '原価集計金額01
		strSQL = strSQL & "      , SMAGNKKN02 " '原価集計金額02
		strSQL = strSQL & "      , SMAGNKKN03 " '原価集計金額03
		strSQL = strSQL & "      , SMAGNKKN04 " '原価集計金額04
		strSQL = strSQL & "      , SMAGNKKN05 " '原価集計金額05
		strSQL = strSQL & "      , SMAGNKKN06 " '原価集計金額06
		strSQL = strSQL & "      , SMAGNKKN07 " '原価集計金額07
		strSQL = strSQL & "      , SMAGNKKN08 " '原価集計金額08
		strSQL = strSQL & "      , SMAGNKKN09 " '原価集計金額09
		strSQL = strSQL & "      , SMANYUKN00 " '入金集計金額00
		strSQL = strSQL & "      , SMANYUKN01 " '入金集計金額01
		strSQL = strSQL & "      , SMANYUKN02 " '入金集計金額02
		strSQL = strSQL & "      , SMANYUKN03 " '入金集計金額03
		strSQL = strSQL & "      , SMANYUKN04 " '入金集計金額04
		strSQL = strSQL & "      , SMANYUKN05 " '入金集計金額05
		strSQL = strSQL & "      , SMANYUKN06 " '入金集計金額06
		strSQL = strSQL & "      , SMANYUKN07 " '入金集計金額07
		strSQL = strSQL & "      , SMANYUKN08 " '入金集計金額08
		strSQL = strSQL & "      , SMANYUKN09 " '入金集計金額09
		strSQL = strSQL & "      , DATNO " '伝票管理NO.
		strSQL = strSQL & "      , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' " '得意先コード
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '経理締日付
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMAURIKN)) '売上集計金額00
		strSQL = strSQL & "      , 0 " '売上集計金額01
		strSQL = strSQL & "      , 0 " '売上集計金額02
		strSQL = strSQL & "      , 0 " '売上集計金額03
		strSQL = strSQL & "      , 0 " '売上集計金額04
		strSQL = strSQL & "      , 0 " '売上集計金額05
		strSQL = strSQL & "      , 0 " '売上集計金額06
		strSQL = strSQL & "      , 0 " '売上集計金額07
		strSQL = strSQL & "      , 0 " '売上集計金額08
		strSQL = strSQL & "      , 0 " '売上集計金額09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMAUZEKN)) '売上消費税金額
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " '原価集計金額00
		strSQL = strSQL & "      , 0 " '原価集計金額01
		strSQL = strSQL & "      , 0 " '原価集計金額02
		strSQL = strSQL & "      , 0 " '原価集計金額03
		strSQL = strSQL & "      , 0 " '原価集計金額04
		strSQL = strSQL & "      , 0 " '原価集計金額05
		strSQL = strSQL & "      , 0 " '原価集計金額06
		strSQL = strSQL & "      , 0 " '原価集計金額07
		strSQL = strSQL & "      , 0 " '原価集計金額08
		strSQL = strSQL & "      , 0 " '原価集計金額09
		strSQL = strSQL & "      , 0 " '入金集計金額00
		strSQL = strSQL & "      , 0 " '入金集計金額01
		strSQL = strSQL & "      , 0 " '入金集計金額02
		strSQL = strSQL & "      , 0 " '入金集計金額03
		strSQL = strSQL & "      , 0 " '入金集計金額04
		strSQL = strSQL & "      , 0 " '入金集計金額05
		strSQL = strSQL & "      , 0 " '入金集計金額06
		strSQL = strSQL & "      , 0 " '入金集計金額07
		strSQL = strSQL & "      , 0 " '入金集計金額08
		strSQL = strSQL & "      , 0 " '入金集計金額09
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      ) "
		
		AE_TOKSME_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSME_UPD_SQL
	'   概要：  売掛サマリ請求更新SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSME_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMAURIKN As Decimal
		Dim curSMAUZEKN As Decimal
		
		AE_TOKSME_UPD_SQL = ""
		
		'売上金額の差分算出
		curSMAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'消費税額の差分算出
		curSMAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSME SET "
		strSQL = strSQL & "        SMAURIKN00 = SMAURIKN00 + " & CF_Ora_Number(CStr(curSMAURIKN)) '売上集計金額00
		strSQL = strSQL & "      , SMAUZEKN   = SMAUZEKN   + " & CF_Ora_Number(CStr(curSMAUZEKN)) '売上消費税金額
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		AE_TOKSME_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSSA_UPD_Main
	'   概要：  請求サマリ更新
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  0：正常　9: 異常
	'   備考：  請求サマリに追加、更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSA_UPD_Main(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: 構造体 usrOdy_TOKSSA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_TOKSSA As U_Ody
		
		On Error GoTo AE_TOKSSA_UPD_Main_Err
		
		AE_TOKSSA_UPD_Main = 9
		bolTran = False
		
		'請求サマリ検索
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSSA "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SSADT  = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSSA, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSA_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_TOKSSA, CNT, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Ora_GetDyn(usrOdy_TOKSSA, "CNT", 0) = 0 Then
			'請求サマリの作成
			strSQL = AE_TOKSSA_INS_SQL(pin_intCnt, pin_usrURITHA)
		Else
			'請求サマリの更新
			strSQL = AE_TOKSSA_UPD_SQL(pin_intCnt, pin_usrURITHA)
		End If
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSA_UPD_Main_Err
		End If
		
		AE_TOKSSA_UPD_Main = 0
		
AE_TOKSSA_UPD_Main_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_TOKSSA)
		End If
		
		Exit Function
		
AE_TOKSSA_UPD_Main_Err: 
		'エラー箇所編集
		pin_usrURITHA.strErr = "AE_TOKSSA_UPD_Main"
		GoTo AE_TOKSSA_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSSA_INS_SQL
	'   概要：  請求サマリ作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSA_INS_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSAURIKN As Decimal
		Dim curSSAUZEKN As Decimal
		
		AE_TOKSSA_INS_SQL = ""
		
		'売上金額の差分算出
		curSSAURIKN = pin_usrURITHA.curUrikn_New(pin_intCnt) - pin_usrURITHA.curUrikn_Old(pin_intCnt)
		'消費税額の差分算出
		curSSAUZEKN = pin_usrURITHA.curUzeikn_New(pin_intCnt) - pin_usrURITHA.curUzeikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSA "
		strSQL = strSQL & "      ( TOKCD " '得意先コード
		strSQL = strSQL & "      , SSADT " '締日付
		strSQL = strSQL & "      , KESDT " '決済日付
		strSQL = strSQL & "      , SSAURIKN00 " '売上集計金額00
		strSQL = strSQL & "      , SSAURIKN01 " '売上集計金額01
		strSQL = strSQL & "      , SSAURIKN02 " '売上集計金額02
		strSQL = strSQL & "      , SSAURIKN03 " '売上集計金額03
		strSQL = strSQL & "      , SSAURIKN04 " '売上集計金額04
		strSQL = strSQL & "      , SSAURIKN05 " '売上集計金額05
		strSQL = strSQL & "      , SSAURIKN06 " '売上集計金額06
		strSQL = strSQL & "      , SSAURIKN07 " '売上集計金額07
		strSQL = strSQL & "      , SSAURIKN08 " '売上集計金額08
		strSQL = strSQL & "      , SSAURIKN09 " '売上集計金額09
		strSQL = strSQL & "      , SSAUZEKN " '売上消費税金額
		strSQL = strSQL & "      , SZAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SZBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "      , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "      , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "      , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "      , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "      , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "      , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "      , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "      , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "      , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "      , KSKNYKKN " '消込入金額
		strSQL = strSQL & "      , KSKZANKN " '消込入金額残
		strSQL = strSQL & "      , SSADENSU " '伝票枚数
		strSQL = strSQL & "      , DATNO " '伝票管理NO.
		strSQL = strSQL & "      , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' " '得意先コード
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' " '締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(pin_intCnt)) & "' " '決済日付
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSAURIKN)) '売上集計金額00
		strSQL = strSQL & "      , 0 " '売上集計金額01
		strSQL = strSQL & "      , 0 " '売上集計金額02
		strSQL = strSQL & "      , 0 " '売上集計金額03
		strSQL = strSQL & "      , 0 " '売上集計金額04
		strSQL = strSQL & "      , 0 " '売上集計金額05
		strSQL = strSQL & "      , 0 " '売上集計金額06
		strSQL = strSQL & "      , 0 " '売上集計金額07
		strSQL = strSQL & "      , 0 " '売上集計金額08
		strSQL = strSQL & "      , 0 " '売上集計金額09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSAUZEKN)) '売上消費税金額
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " '入金集計金額00
		strSQL = strSQL & "      , 0 " '入金集計金額01
		strSQL = strSQL & "      , 0 " '入金集計金額02
		strSQL = strSQL & "      , 0 " '入金集計金額03
		strSQL = strSQL & "      , 0 " '入金集計金額04
		strSQL = strSQL & "      , 0 " '入金集計金額05
		strSQL = strSQL & "      , 0 " '入金集計金額06
		strSQL = strSQL & "      , 0 " '入金集計金額07
		strSQL = strSQL & "      , 0 " '入金集計金額08
		strSQL = strSQL & "      , 0 " '入金集計金額09
		strSQL = strSQL & "      , 0 " '消込入金額
		strSQL = strSQL & "      , 0 " '消込入金額残
		strSQL = strSQL & "      , 0 " '伝票枚数
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      ) "
		
		AE_TOKSSA_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSSA_UPD_SQL
	'   概要：  請求サマリ更新SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSA_UPD_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSAURIKN As Decimal
		Dim curSSAUZEKN As Decimal
		
		AE_TOKSSA_UPD_SQL = ""
		
		'売上金額の差分算出
		curSSAURIKN = pin_usrURITHA.curUrikn_New(pin_intCnt) - pin_usrURITHA.curUrikn_Old(pin_intCnt)
		'消費税額の差分算出
		curSSAUZEKN = pin_usrURITHA.curUzeikn_New(pin_intCnt) - pin_usrURITHA.curUzeikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSA SET "
		strSQL = strSQL & "        SSAURIKN00 = SSAURIKN00 + " & CF_Ora_Number(CStr(curSSAURIKN)) '売上集計金額00
		strSQL = strSQL & "      , SSAUZEKN   = SSAUZEKN   + " & CF_Ora_Number(CStr(curSSAUZEKN)) '売上消費税金額
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SSADT = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		AE_TOKSSA_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSSB_UPD_Main
	'   概要：  前受請求サマリ更新
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  0：正常　9: 異常
	'   備考：  前受請求サマリに追加、更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSB_UPD_Main(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: 構造体 usrOdy_TOKSSB の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_TOKSSB As U_Ody
		
		On Error GoTo AE_TOKSSB_UPD_Main_Err
		
		AE_TOKSSB_UPD_Main = 9
		bolTran = False
		
		'前受請求サマリ検索
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSSB "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SSADT  = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSSB, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSB_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_TOKSSB, CNT, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Ora_GetDyn(usrOdy_TOKSSB, "CNT", 0) = 0 Then
			'前受請求サマリの作成
			strSQL = AE_TOKSSB_INS_SQL(pin_intCnt, pin_usrURITHA)
		Else
			'前受請求サマリの更新
			strSQL = AE_TOKSSB_UPD_SQL(pin_intCnt, pin_usrURITHA)
		End If
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSB_UPD_Main_Err
		End If
		
		AE_TOKSSB_UPD_Main = 0
		
AE_TOKSSB_UPD_Main_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_TOKSSB)
		End If
		
		Exit Function
		
AE_TOKSSB_UPD_Main_Err: 
		'エラー箇所編集
		pin_usrURITHA.strErr = "AE_TOKSSB_UPD_Main"
		GoTo AE_TOKSSB_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSSB_INS_SQL
	'   概要：  前受請求サマリ作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSB_INS_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSAURIKN As Decimal
		Dim curSSAUZEKN As Decimal
		
		AE_TOKSSB_INS_SQL = ""
		
		'売上金額の差分算出
		curSSAURIKN = pin_usrURITHA.curUrikn_New(pin_intCnt) - pin_usrURITHA.curUrikn_Old(pin_intCnt)
		'消費税額の差分算出
		curSSAUZEKN = pin_usrURITHA.curUzeikn_New(pin_intCnt) - pin_usrURITHA.curUzeikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSB "
		strSQL = strSQL & "      ( TOKCD " '得意先コード
		strSQL = strSQL & "      , SSADT " '締日付
		strSQL = strSQL & "      , KESDT " '決済日付
		strSQL = strSQL & "      , SSAURIKN00 " '売上集計金額00
		strSQL = strSQL & "      , SSAURIKN01 " '売上集計金額01
		strSQL = strSQL & "      , SSAURIKN02 " '売上集計金額02
		strSQL = strSQL & "      , SSAURIKN03 " '売上集計金額03
		strSQL = strSQL & "      , SSAURIKN04 " '売上集計金額04
		strSQL = strSQL & "      , SSAURIKN05 " '売上集計金額05
		strSQL = strSQL & "      , SSAURIKN06 " '売上集計金額06
		strSQL = strSQL & "      , SSAURIKN07 " '売上集計金額07
		strSQL = strSQL & "      , SSAURIKN08 " '売上集計金額08
		strSQL = strSQL & "      , SSAURIKN09 " '売上集計金額09
		strSQL = strSQL & "      , SSAUZEKN " '売上消費税金額
		strSQL = strSQL & "      , SZAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SZBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "      , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "      , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "      , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "      , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "      , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "      , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "      , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "      , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "      , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "      , KSKNYKKN " '消込入金額
		strSQL = strSQL & "      , KSKZANKN " '消込入金額残
		strSQL = strSQL & "      , SSADENSU " '伝票枚数
		strSQL = strSQL & "      , DATNO " '伝票管理NO.
		strSQL = strSQL & "      , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' " '得意先コード
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' " '締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(pin_intCnt)) & "' " '決済日付
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSAURIKN)) '売上集計金額00
		strSQL = strSQL & "      , 0 " '売上集計金額01
		strSQL = strSQL & "      , 0 " '売上集計金額02
		strSQL = strSQL & "      , 0 " '売上集計金額03
		strSQL = strSQL & "      , 0 " '売上集計金額04
		strSQL = strSQL & "      , 0 " '売上集計金額05
		strSQL = strSQL & "      , 0 " '売上集計金額06
		strSQL = strSQL & "      , 0 " '売上集計金額07
		strSQL = strSQL & "      , 0 " '売上集計金額08
		strSQL = strSQL & "      , 0 " '売上集計金額09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSAUZEKN)) '売上消費税金額
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " '入金集計金額00
		strSQL = strSQL & "      , 0 " '入金集計金額01
		strSQL = strSQL & "      , 0 " '入金集計金額02
		strSQL = strSQL & "      , 0 " '入金集計金額03
		strSQL = strSQL & "      , 0 " '入金集計金額04
		strSQL = strSQL & "      , 0 " '入金集計金額05
		strSQL = strSQL & "      , 0 " '入金集計金額06
		strSQL = strSQL & "      , 0 " '入金集計金額07
		strSQL = strSQL & "      , 0 " '入金集計金額08
		strSQL = strSQL & "      , 0 " '入金集計金額09
		strSQL = strSQL & "      , 0 " '消込入金額
		strSQL = strSQL & "      , 0 " '消込入金額残
		strSQL = strSQL & "      , 0 " '伝票枚数
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      ) "
		
		AE_TOKSSB_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSSB_UPD_SQL
	'   概要：  前受請求サマリ更新SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSB_UPD_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSAURIKN As Decimal
		Dim curSSAUZEKN As Decimal
		
		AE_TOKSSB_UPD_SQL = ""
		
		'売上金額の差分算出
		curSSAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'消費税額の差分算出
		curSSAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSB SET "
		strSQL = strSQL & "        SSAURIKN00 = SSAURIKN00 + " & CF_Ora_Number(CStr(curSSAURIKN)) '売上集計金額00
		strSQL = strSQL & "      , SSAUZEKN   = SSAUZEKN   + " & CF_Ora_Number(CStr(curSSAUZEKN)) '売上消費税金額
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SSADT = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		AE_TOKSSB_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSSC_UPD_Main
	'   概要：  請求サマリ外貨更新
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  0：正常　9: 異常
	'   備考：  請求サマリ外貨に追加、更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSC_UPD_Main(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: 構造体 usrOdy_TOKSSC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_TOKSSC As U_Ody
		
		On Error GoTo AE_TOKSSC_UPD_Main_Err
		
		AE_TOKSSC_UPD_Main = 9
		bolTran = False
		
		'請求サマリ外貨検索
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSSC "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' "
		strSQL = strSQL & "    AND SSADT  = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSSC, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSC_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_TOKSSC, CNT, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Ora_GetDyn(usrOdy_TOKSSC, "CNT", 0) = 0 Then
			'請求サマリ外貨の作成
			strSQL = AE_TOKSSC_INS_SQL(pin_intCnt, pin_usrURITHA)
		Else
			'請求サマリ外貨の更新
			strSQL = AE_TOKSSC_UPD_SQL(pin_intCnt, pin_usrURITHA)
		End If
		
		'ＳＱＬ実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSC_UPD_Main_Err
		End If
		
		AE_TOKSSC_UPD_Main = 0
		
AE_TOKSSC_UPD_Main_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_TOKSSC)
		End If
		
		Exit Function
		
AE_TOKSSC_UPD_Main_Err: 
		'エラー箇所編集
		pin_usrURITHA.strErr = "AE_TOKSSC_UPD_Main"
		GoTo AE_TOKSSC_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSSC_INS_SQL
	'   概要：  請求サマリ外貨作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSC_INS_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSCURIKN As Decimal
		Dim curSSCUZEKN As Decimal
		
		AE_TOKSSC_INS_SQL = ""
		
		'売上金額の差分算出
		curSSCURIKN = pin_usrURITHA.curFUrikn_New(pin_intCnt) - pin_usrURITHA.curFUrikn_Old(pin_intCnt)
		'消費税額の差分算出
		curSSCUZEKN = pin_usrURITHA.curUzeikn_New(pin_intCnt) - pin_usrURITHA.curUzeikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSC "
		strSQL = strSQL & "      ( TOKCD " '得意先コード
		strSQL = strSQL & "      , TUKKB " '通貨区分
		strSQL = strSQL & "      , SSADT " '締日付
		strSQL = strSQL & "      , KESDT " '決済日付
		strSQL = strSQL & "      , SSCURIKN00 " '売上集計金額00
		strSQL = strSQL & "      , SSCURIKN01 " '売上集計金額01
		strSQL = strSQL & "      , SSCURIKN02 " '売上集計金額02
		strSQL = strSQL & "      , SSCURIKN03 " '売上集計金額03
		strSQL = strSQL & "      , SSCURIKN04 " '売上集計金額04
		strSQL = strSQL & "      , SSCURIKN05 " '売上集計金額05
		strSQL = strSQL & "      , SSCURIKN06 " '売上集計金額06
		strSQL = strSQL & "      , SSCURIKN07 " '売上集計金額07
		strSQL = strSQL & "      , SSCURIKN08 " '売上集計金額08
		strSQL = strSQL & "      , SSCURIKN09 " '売上集計金額09
		strSQL = strSQL & "      , SSCUZEKN " '売上消費税金額
		strSQL = strSQL & "      , FAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , FAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , FAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , FAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , FAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , FAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , FBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , FBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , FBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , FBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , FBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , FBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , SSCNYUKN00 " '入金集計金額00
		strSQL = strSQL & "      , SSCNYUKN01 " '入金集計金額01
		strSQL = strSQL & "      , SSCNYUKN02 " '入金集計金額02
		strSQL = strSQL & "      , SSCNYUKN03 " '入金集計金額03
		strSQL = strSQL & "      , SSCNYUKN04 " '入金集計金額04
		strSQL = strSQL & "      , SSCNYUKN05 " '入金集計金額05
		strSQL = strSQL & "      , SSCNYUKN06 " '入金集計金額06
		strSQL = strSQL & "      , SSCNYUKN07 " '入金集計金額07
		strSQL = strSQL & "      , SSCNYUKN08 " '入金集計金額08
		strSQL = strSQL & "      , SSCNYUKN09 " '入金集計金額09
		strSQL = strSQL & "      , FKSNYKKN " '消込入金額
		strSQL = strSQL & "      , FKSZANKN " '消込入金額残
		strSQL = strSQL & "      , SSCDENSU " '伝票枚数
		strSQL = strSQL & "      , DATNO " '伝票管理NO.
		strSQL = strSQL & "      , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' " '得意先コード
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' " '通貨区分
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' " '締日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(pin_intCnt)) & "' " '決済日付
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSCURIKN)) '売上集計金額00
		strSQL = strSQL & "      , 0 " '売上集計金額01
		strSQL = strSQL & "      , 0 " '売上集計金額02
		strSQL = strSQL & "      , 0 " '売上集計金額03
		strSQL = strSQL & "      , 0 " '売上集計金額04
		strSQL = strSQL & "      , 0 " '売上集計金額05
		strSQL = strSQL & "      , 0 " '売上集計金額06
		strSQL = strSQL & "      , 0 " '売上集計金額07
		strSQL = strSQL & "      , 0 " '売上集計金額08
		strSQL = strSQL & "      , 0 " '売上集計金額09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSCUZEKN)) '売上消費税金額
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税込課税金額02
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "      , 0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "      , 0 " '入金集計金額00
		strSQL = strSQL & "      , 0 " '入金集計金額01
		strSQL = strSQL & "      , 0 " '入金集計金額02
		strSQL = strSQL & "      , 0 " '入金集計金額03
		strSQL = strSQL & "      , 0 " '入金集計金額04
		strSQL = strSQL & "      , 0 " '入金集計金額05
		strSQL = strSQL & "      , 0 " '入金集計金額06
		strSQL = strSQL & "      , 0 " '入金集計金額07
		strSQL = strSQL & "      , 0 " '入金集計金額08
		strSQL = strSQL & "      , 0 " '入金集計金額09
		strSQL = strSQL & "      , 0 " '消込入金額
		strSQL = strSQL & "      , 0 " '消込入金額残
		strSQL = strSQL & "      , 0 " '伝票枚数
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      ) "
		
		AE_TOKSSC_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKSSC_UPD_SQL
	'   概要：  請求サマリ外貨更新SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSC_UPD_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSCURIKN As Decimal
		Dim curSSCUZEKN As Decimal
		
		AE_TOKSSC_UPD_SQL = ""
		
		'売上金額の差分算出
		curSSCURIKN = pin_usrURITHA.curFUrikn_New(pin_intCnt) - pin_usrURITHA.curFUrikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSC SET "
		strSQL = strSQL & "        SSCURIKN00 = SSCURIKN00 + " & CF_Ora_Number(CStr(curSSCURIKN)) '売上集計金額00
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' "
		strSQL = strSQL & "    AND SSADT = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		AE_TOKSSC_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKMTB_UPD_Main
	'   概要：  販売単価履歴マスタ更新
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  0：正常　9: 異常
	'   備考：  販売単価履歴マスタに追加、更新を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKMTB_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: 構造体 usrOdy_TOKMTB の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_TOKMTB As U_Ody
		
		On Error GoTo AE_TOKMTB_UPD_Main_Err
		
		AE_TOKMTB_UPD_Main = 9
		bolTran = False
		
		For intCnt = 1 To UBound(pin_usrURITRA)
			
			'販売単価履歴マスタ検索
			strSQL = ""
			strSQL = strSQL & " SELECT * "
			strSQL = strSQL & "   FROM TOKMTB "
			strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
			strSQL = strSQL & "    AND HINCD  = '" & CF_Ora_String(pin_usrURITRA(intCnt).HINCD, 10) & "' "
			
			'SQL実行
			bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKMTB, strSQL)
			If bolRet = False Then
				GoTo AE_TOKMTB_UPD_Main_Err
			End If
			
			bolTran = True
			
			If CF_Ora_EOF(usrOdy_TOKMTB) = True Then
				'販売単価履歴マスタの作成
				strSQL = AE_TOKMTB_INS_SQL(pin_usrURITHA, pin_usrURITRA(intCnt))
				
				'ＳＱＬ実行
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo AE_TOKMTB_UPD_Main_Err
				End If
			Else
				If pin_usrURITHA.FRNKB = gc_strFRNKB_DMS Then
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_TOKMTB, HISURITK00, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If CF_Ora_GetDyn(usrOdy_TOKMTB, "HISURITK00", 0) <> pin_usrURITRA(intCnt).URITK Then
						'販売単価履歴マスタの更新
						strSQL = AE_TOKMTB_UPD_SQL(pin_usrURITHA, pin_usrURITRA(intCnt), usrOdy_TOKMTB)
						
						'ＳＱＬ実行
						bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
						If bolRet = False Then
							GoTo AE_TOKMTB_UPD_Main_Err
						End If
					End If
				Else
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy_TOKMTB, HISURITK00, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If CF_Ora_GetDyn(usrOdy_TOKMTB, "HISURITK00", 0) <> pin_usrURITRA(intCnt).FURITK Then
						'販売単価履歴マスタの更新
						strSQL = AE_TOKMTB_UPD_SQL(pin_usrURITHA, pin_usrURITRA(intCnt), usrOdy_TOKMTB)
						
						'ＳＱＬ実行
						bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
						If bolRet = False Then
							GoTo AE_TOKMTB_UPD_Main_Err
						End If
					End If
				End If
			End If
			
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_TOKMTB)
			
		Next 
		
		AE_TOKMTB_UPD_Main = 0
		
AE_TOKMTB_UPD_Main_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_TOKMTB)
		End If
		
		Exit Function
		
AE_TOKMTB_UPD_Main_Err: 
		'エラー箇所編集
		pin_usrURITHA.strErr = "AE_TOKMTB_UPD_Main"
		GoTo AE_TOKMTB_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKMTB_INS_SQL
	'   概要：  販売単価履歴マスタ作成SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKMTB_INS_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd) As String
		
		Dim strSQL As String
		
		AE_TOKMTB_INS_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKMTB "
		strSQL = strSQL & "      ( DATKB " '伝票削除区分
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , HINCD " '製品コード
		strSQL = strSQL & "      , URITKDT00 " '適用日
		strSQL = strSQL & "      , URITKDT01 " '適用日
		strSQL = strSQL & "      , URITKDT02 " '適用日
		strSQL = strSQL & "      , URITKDT03 " '適用日
		strSQL = strSQL & "      , URITKDT04 " '適用日
		strSQL = strSQL & "      , URITKDT05 " '適用日
		strSQL = strSQL & "      , UDNNO00 " '売上伝票番号
		strSQL = strSQL & "      , UDNNO01 " '売上伝票番号
		strSQL = strSQL & "      , UDNNO02 " '売上伝票番号
		strSQL = strSQL & "      , UDNNO03 " '売上伝票番号
		strSQL = strSQL & "      , UDNNO04 " '売上伝票番号
		strSQL = strSQL & "      , UDNNO05 " '売上伝票番号
		strSQL = strSQL & "      , UDNDT00 " '売上伝票日付
		strSQL = strSQL & "      , UDNDT01 " '売上伝票日付
		strSQL = strSQL & "      , UDNDT02 " '売上伝票日付
		strSQL = strSQL & "      , UDNDT03 " '売上伝票日付
		strSQL = strSQL & "      , UDNDT04 " '売上伝票日付
		strSQL = strSQL & "      , UDNDT05 " '売上伝票日付
		strSQL = strSQL & "      , HISURITK00 " '販売履歴単価
		strSQL = strSQL & "      , HISURITK01 " '販売履歴単価
		strSQL = strSQL & "      , HISURITK02 " '販売履歴単価
		strSQL = strSQL & "      , HISURITK03 " '販売履歴単価
		strSQL = strSQL & "      , HISURITK04 " '販売履歴単価
		strSQL = strSQL & "      , HISURITK05 " '販売履歴単価
		strSQL = strSQL & "      , BIKO00 " '備考
		strSQL = strSQL & "      , BIKO01 " '備考
		strSQL = strSQL & "      , BIKO02 " '備考
		strSQL = strSQL & "      , BIKO03 " '備考
		strSQL = strSQL & "      , BIKO04 " '備考
		strSQL = strSQL & "      , BIKO05 " '備考
		strSQL = strSQL & "      , RELFL " '連携フラグ
		strSQL = strSQL & "      , OPEID " '最終作業者コード
		strSQL = strSQL & "      , CLTID " 'クライアントＩＤ
		strSQL = strSQL & "      , WRTTM " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT " 'タイムスタンプ（日付）
		strSQL = strSQL & "      , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , WRTFSTDT " 'タイムスタンプ（登録日）
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '伝票削除区分
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.HINCD, 10) & "' " '製品コード
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '適用日
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '適用日
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '適用日
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '適用日
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '適用日
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '適用日
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '売上伝票番号
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '売上伝票番号
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '売上伝票番号
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '売上伝票番号
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '売上伝票番号
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '売上伝票番号
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '売上伝票日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '売上伝票日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '売上伝票日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '売上伝票日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '売上伝票日付
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '売上伝票日付
		
		If pin_usrURITHA.FRNKB = gc_strFRNKB_DMS Then
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URITK)) '販売履歴単価
		Else
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.FURITK)) '販売履歴単価
		End If
		
		strSQL = strSQL & "      , 0 " '販売履歴単価
		strSQL = strSQL & "      , 0 " '販売履歴単価
		strSQL = strSQL & "      , 0 " '販売履歴単価
		strSQL = strSQL & "      , 0 " '販売履歴単価
		strSQL = strSQL & "      , 0 " '販売履歴単価
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.BIKO, 20) & "' " '備考
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '備考
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '備考
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '備考
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '備考
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '備考
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 1) & "' " '連携フラグ
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      , '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      ) "
		
		AE_TOKMTB_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_TOKMTB_UPD_SQL
	'   概要：  販売単価履歴マスタ更新SQL編集
	'   引数：  pin_usrURITHA     : 売上見出しトラン更新情報
	'   戻値：  SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKMTB_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd, ByRef pin_usrOdy As U_Ody) As String
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy_UDNTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolOpen As Boolean
		
		AE_TOKMTB_UPD_SQL = ""
		
		'販売単価履歴マスタの更新
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKMTB SET "
		strSQL = strSQL & "        URITKDT00  = '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , URITKDT01  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT00", "")) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , URITKDT02  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT01", "")) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , URITKDT03  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT02", "")) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , URITKDT04  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT03", "")) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , URITKDT05  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT04", "")) & "' "
		strSQL = strSQL & "      , UDNNO00    = '" & CF_Ora_String(Space(1), 8) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNNO01    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO00", ""), 8) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNNO02    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO01", ""), 8) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNNO03    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO02", ""), 8) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNNO04    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO03", ""), 8) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNNO05    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO04", ""), 8) & "' "
		strSQL = strSQL & "      , UDNDT00    = '" & CF_Ora_Date(Space(1)) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNDT01    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT00", "")) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNDT02    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT01", "")) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNDT03    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT02", "")) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNDT04    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT03", "")) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , UDNDT05    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT04", "")) & "' "
		
		If pin_usrURITHA.FRNKB = gc_strFRNKB_DMS Then
			strSQL = strSQL & "      , HISURITK00 = " & CF_Ora_Number(CStr(pin_usrURITRA.URITK))
		Else
			strSQL = strSQL & "      , HISURITK00 = " & CF_Ora_Number(CStr(pin_usrURITRA.FURITK))
		End If
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , HISURITK01 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK00", ""))
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , HISURITK02 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK01", ""))
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , HISURITK03 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK02", ""))
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , HISURITK04 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK03", ""))
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , HISURITK05 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK04", ""))
		strSQL = strSQL & "      , BIKO00     = '" & CF_Ora_String(pin_usrURITRA.BIKO, 20) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , BIKO01     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO00", ""), 20) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , BIKO02     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO01", ""), 20) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , BIKO03     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO02", ""), 20) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , BIKO04     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO03", ""), 20) & "' "
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , BIKO05     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO04", ""), 20) & "' "
		strSQL = strSQL & "      , OPEID      = '" & SSS_OPEID.Value & "' "
		strSQL = strSQL & "      , CLTID      = '" & SSS_CLTID.Value & "' "
		strSQL = strSQL & "      , WRTTM      = '" & GV_SysTime & "' "
		strSQL = strSQL & "      , WRTDT      = '" & GV_SysDate & "' "
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND HINCD = '" & CF_Ora_String(pin_usrURITRA.HINCD, 10) & "' "
		
		AE_TOKMTB_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_GetKESDT
	'   概要：  決済日計算処理
	'   引数：  Pin_strSSADT    : 計算対象締日付(８桁の数値Or日付）
	'           Pin_strTOKSMEKB : 締め区分
	'           Pin_strTOKKESCC : 回収サイクル
	'           Pin_strTOKKESDD : 回収日付
	'           Pin_strTOKKDWKB : 回収曜日
	'           Pin_strSSAKBN   : 休日請求時の処理区分（1：前倒し、2：後倒し）
	'           Pot_strKESDT    : 計算結果決算日
	'   戻値：  0：正常　9:異常
	'   備考：　締区分が"日"の場合の決算日算出
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetKESDT(ByVal pin_strSSADT As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKKESCC As String, ByVal Pin_strTOKKESDD As String, ByVal Pin_strTOKKDWKB As String, ByVal Pin_strSSAKBN As String, ByRef Pot_strKESDT As String) As Short
		
		Dim strDate As String
		Dim strWKDate As String
		Dim yy As Short
		Dim mm As Short
		Dim dd As Short
		Dim intTOKKESCC As Short '回収サイクル
		Dim intTOKKESDD As Short
		Dim intTOKSDWKB As Short
		Dim Mst_Inf_Dt As TYPE_DB_CLDMTA
		
		AE_GetKESDT = 9
		Pot_strKESDT = ""
		
		'日付チェック
		If IsDate(pin_strSSADT) = True Then
			strDate = VB6.Format(pin_strSSADT, "yyyy/mm/dd")
		Else
			If IsDate(VB6.Format(pin_strSSADT, "@@@@/@@/@@")) = True Then
				strDate = VB6.Format(pin_strSSADT, "@@@@/@@/@@")
			Else
				Exit Function
			End If
		End If
		
		yy = Year(CDate(strDate))
		mm = Month(CDate(strDate))
		dd = VB.Day(CDate(strDate))
		
		'回収サイクル取得
		intTOKKESCC = CShort(CF_Get_CCurString(Pin_strTOKKESCC))
		
		If Pin_strTOKSMEKB = gc_strSMEKB_DAY Then
			'回収サイクルの加算
			strDate = CStr(DateSerial(yy, mm + intTOKKESCC, CInt("01")))
			
			yy = Year(CDate(strDate))
			mm = Month(CDate(strDate))
			
			'回収日付の考慮
			intTOKKESDD = CShort(CF_Get_CCurString(Pin_strTOKKESDD))
			If intTOKKESDD > 31 Then intTOKKESDD = 99
			If intTOKKESDD = 99 Then
				Pot_strKESDT = CStr(DateSerial(yy, mm + 1, 0))
			Else
				Pot_strKESDT = CStr(DateSerial(yy, mm, intTOKKESDD))
				If Month(CDate(Pot_strKESDT)) <> mm Then
					Pot_strKESDT = CStr(DateSerial(yy, mm + 1, 0))
				End If
			End If
			
			strDate = VB6.Format(Pot_strKESDT, "yyyymmdd")
		Else
			'計算対象締め日の週の日曜日取得
			Call DSPCLDDT_SEARCH_WK(VB6.Format(yy, "0000") & VB6.Format(mm, "00") & VB6.Format(dd, "00"), gc_strCLDWKKB_SUN, "1", strWKDate)
			
			yy = CShort(MidWid(strWKDate, 1, 4))
			mm = CShort(MidWid(strWKDate, 5, 2))
			dd = CShort(MidWid(strWKDate, 7, 2))
			
			'回収サイクルの加算
			strDate = CStr(DateSerial(yy, mm, dd + intTOKKESCC * 7))
			
			'計算結果日付の週の回収曜日にあたる日付取得
			Call DSPCLDDT_SEARCH_WK(CF_Ora_Date(strDate), Pin_strTOKKDWKB, "1", strDate)
		End If
		
		'営業日、銀行稼働日チェック
		Pot_strKESDT = ""
		If DSPCLDDT_SEARCH(strDate, Mst_Inf_Dt) = 0 Then
			If Mst_Inf_Dt.DATKB = gc_strDATKB_USE And Mst_Inf_Dt.SLDKB = KDKB_WORK And Mst_Inf_Dt.BNKKDKB = KDKB_WORK Then
				Pot_strKESDT = strDate
			Else
				If Pin_strSSAKBN = "1" Then
					'前倒し
					Call DSPCLDDT_SEARCH_KDKB(strDate, "12", "2", Pot_strKESDT)
				Else
					'後倒し
					Call DSPCLDDT_SEARCH_KDKB(strDate, "12", "1", Pot_strKESDT)
				End If
			End If
		End If
		
		AE_GetKESDT = 0
		
	End Function
	' === 20070307 === INSERT E -
	
	' === 20070327 === INSERT S - ACE)Nagasawa 売上訂正返品対応
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CHK_URIInf_HNPN
	'   概要：  売上返品チェック処理
	'   引数：  pin_strDATNO    : 伝票管理番号
	'           pin_usrUDNTHA   : 更新対象売上見出しトラン情報
	'           pin_usrUDNTRA   : 更新対象売上トラン情報
	'   戻値：  00 : 返品なし、売上更新なし
	'           01 : 返品なし、売上更新あり
	'           10 : 返品が発生し、売上更新なし
	'           11 : 返品が発生し、売上更新あり
	'           99 : 異常
	'   備考：　売上に対して返品データが発生しているかどうかを検索し、チェックする
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_CHK_URIInf_HNPN(ByVal pin_strDatNo As String, ByRef pin_usrUDNTHA As Cmn_UDNTHA_Upd, ByRef pin_usrUDNTRA() As Cmn_UDNTRA_Upd) As String
		
		Dim curHNPNSU As Decimal
		Dim strSQL As String
		Dim strFDNNO As String
		Dim strODNNO As String
		Dim strJDNLINNO As String
		Dim strSBNNO As String
		Dim strRecNo As String
		Dim curURISU As String
		'UPGRADE_WARNING: 構造体 usrOdy_UDNTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolOpen As Boolean
		Dim intCnt As Short
		Dim bolUpd As Boolean
		Dim bolHNPN As Boolean
		Dim bolFind As Boolean
		Dim bolRet As Boolean
		
		On Error GoTo AE_CHK_URIInf_HNPN_Err
		
		AE_CHK_URIInf_HNPN = "99"
		
		bolOpen = False
		bolUpd = False
		bolHNPN = False
		
		'更新対象（と思われる)売上伝票の明細を全て取得
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        UDNTHA.FDNNO "
		strSQL = strSQL & "      , UDNTRA.ODNNO "
		strSQL = strSQL & "      , UDNTRA.JDNLINNO "
		strSQL = strSQL & "      , UDNTRA.SBNNO "
		strSQL = strSQL & "      , UDNTRA.RECNO "
		strSQL = strSQL & "      , UDNTRA.URISU "
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        UDNTHA "
		strSQL = strSQL & "      , UDNTRA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        UDNTHA.DATNO  = '" & CF_Ora_String(pin_strDatNo, 10) & "' "
		strSQL = strSQL & "    AND UDNTHA.DATNO  = UDNTRA.DATNO "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
		If bolRet = False Then
			GoTo AE_CHK_URIInf_HNPN_Err
		End If
		
		bolOpen = True
		
		Do Until CF_Ora_EOF(usrOdy_UDNTRA)
			
			'取得データ退避
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strFDNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "FDNNO", "") '納品書番号
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strODNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "ODNNO", "") '出荷伝票番号
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strJDNLINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNLINNO", "") '受注行番号
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSBNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "SBNNO", "") '出荷伝票番号
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strRecNo = CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "") 'レコード管理番号
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curURISU = CF_Ora_GetDyn(usrOdy_UDNTRA, "URISU", 0) '売上数
			
			'返品データ検索
			Call AE_GET_URIInf_HNPN(strFDNNO, strODNNO, strRecNo, curHNPNSU)
			
			If curHNPNSU > 0 Then
				'返品フラグON
				bolHNPN = True
			End If
			
			bolFind = False
			
			'更新対象データかどうかを調べる
			For intCnt = 1 To UBound(pin_usrUDNTRA)
				
				'受注取引区分により検索条件変更
				Select Case True
					'システム受注で出荷基準のもの、またはセットアップ受注
					Case (pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrUDNTHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SET
						If Trim(pin_usrUDNTRA(intCnt).LINNO) = Trim(strJDNLINNO) Then
							bolFind = True
						End If
						
						'システム受注で出荷基準以外のもの
					Case pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS
						If Trim(pin_usrUDNTRA(intCnt).RECNO) = Trim(strRecNo) Then
							bolFind = True
						End If
						
						'上記以外
					Case Else
						If Trim(pin_usrUDNTRA(intCnt).SBNNO) = Trim(strSBNNO) Then
							bolFind = True
						End If
				End Select
				
				If bolFind = True Then
					Exit For
				End If
			Next 
			
			If bolFind = True Then
				'売上数－返品数＞ゼロは更新対象データ
				If CDbl(curURISU) - curHNPNSU > 0 Then
					bolUpd = True
				End If
			End If
			
			'次データへ
			Call CF_Ora_MoveNext(usrOdy_UDNTRA)
		Loop 
		
		'チェック
		Select Case True
			'返品なし、売上更新なし
			Case bolUpd = False And bolHNPN = False
				AE_CHK_URIInf_HNPN = "00"
				
				'返品なし、売上更新あり
			Case bolUpd = True And bolHNPN = False
				AE_CHK_URIInf_HNPN = "01"
				
				'返品が発生し、売上更新なし
			Case bolUpd = False And bolHNPN = True
				AE_CHK_URIInf_HNPN = "10"
				
				'返品が発生し、売上更新あり
			Case bolUpd = True And bolHNPN = True
				AE_CHK_URIInf_HNPN = "11"
				
			Case Else
		End Select
		
AE_CHK_URIInf_HNPN_End: 
		
		If bolOpen = True Then
			'クローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
		End If
		
		Exit Function
		
AE_CHK_URIInf_HNPN_Err: 
		GoTo AE_CHK_URIInf_HNPN_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_GET_URIInf_HNPN
	'   概要：  売上返品数取得処理
	'   引数：  pin_strFDNNO    : 納品書番号
	'           pin_strODNNO    : 出荷伝票番号
	'           pin_strRECNO    : レコード管理番号
	'           pot_curHNPNSU   : 返品数量
	'           pot_strHNPNKN   : 返品金額
	'           pot_strHNPNZKN  : 返品消費税金額
	'           pot_strHNPNFKN  : 返品外貨金額
	'   戻値：  True : 正常終了  False : 異常
	'   備考：　売上に対して発生している返品数を取得する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GET_URIInf_HNPN(ByVal pin_strFDNNO As String, ByVal pin_strODNNO As String, ByVal pin_strRECNO As String, ByRef pot_curHNPNSU As Decimal, Optional ByRef pot_strHNPNKN As Decimal = 0, Optional ByRef pot_strHNPNZKN As Decimal = 0, Optional ByRef pot_strHNPNFKN As Decimal = 0) As Boolean
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy_UDNTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolRet As Boolean
		Dim curHNPNSU As Decimal
		Dim bolOpen As Boolean
		
		On Error GoTo AE_GET_URIInf_HNPN_Err
		
		AE_GET_URIInf_HNPN = False
		
		bolOpen = False
		
		pot_curHNPNSU = 0
		pot_strHNPNKN = 0
		pot_strHNPNZKN = 0
		pot_strHNPNFKN = 0
		
		'返品データ検索
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        SUM(UDNTRA.URISU) AS HNPNSU"
		strSQL = strSQL & "      , SUM(UDNTRA.URIKN) AS HNPNKN"
		strSQL = strSQL & "      , SUM(UDNTRA.UZEKN) AS HNPNZKN"
		strSQL = strSQL & "      , SUM(UDNTRA.FURIKN) AS HNPNFKN"
		strSQL = strSQL & "   FROM "
		' === 20070331 === UPDATE S - ACE)Nagasawa 売上訂正返品対応
		'    strSQL = strSQL & "        UDNTRA "
		'    strSQL = strSQL & "      , UDNTRA "
		strSQL = strSQL & "        UDNTRA "
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "  WHERE "
		' === 20070331 === UPDATE S - ACE)Nagasawa 売上訂正返品対応
		'    strSQL = strSQL & "        UDNTHA.FDNNO     = '" & CF_Ora_String(pin_strFDNNO, 8) & "' "
		'    strSQL = strSQL & "    AND UDNTHA.DATNO     = UDNTRA.DATNO "
		'    strSQL = strSQL & "    AND UDNTRA.ODNNO     = '" & CF_Ora_String(pin_strODNNO, 8) & "' "
		strSQL = strSQL & "        UDNTRA.USDNO     = '" & CF_Ora_String(pin_strFDNNO, 8) & "' "
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "    AND UDNTRA.RECNO     = '" & CF_Ora_String(pin_strRECNO, 10) & "' "
		strSQL = strSQL & "    AND UDNTRA.DKBID     IN ('" & CF_Ora_String(gc_strDKBID_HP, 2) & "' "
		strSQL = strSQL & "                          ,  '" & CF_Ora_String(gc_strDKBID_JHP, 2) & "') "
		strSQL = strSQL & "    AND UDNTRA.AKAKROKB  = '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "' "
		strSQL = strSQL & "    AND UDNTRA.DATKB     = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND UDNTRA.DATNO     NOT IN "
		' === 20070331 === UPDATE S - ACE)Nagasawa 売上訂正返品対応
		'    strSQL = strSQL & "                              (SELECT UDNTHA.MOTDATNO "
		'    strSQL = strSQL & "                               FROM UDNTHA,UDNTRA "
		'    strSQL = strSQL & "                              WHERE UDNTHA.FDNNO     = '" & CF_Ora_String(pin_strFDNNO, 8) & "' "
		'    strSQL = strSQL & "                                AND UDNTHA.DATNO     = UDNTRA.DATNO "
		'    strSQL = strSQL & "                                AND UDNTRA.ODNNO     = '" & CF_Ora_String(pin_strODNNO, 8) & "' "
		strSQL = strSQL & "                              (SELECT UDNTRA.MOTDATNO "
		strSQL = strSQL & "                               FROM UDNTRA "
		strSQL = strSQL & "                              WHERE UDNTRA.USDNO     = '" & CF_Ora_String(pin_strFDNNO, 8) & "' "
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "                                AND UDNTRA.RECNO     = '" & CF_Ora_String(pin_strRECNO, 10) & "' "
		strSQL = strSQL & "                                AND UDNTRA.DKBID     IN ('" & CF_Ora_String(gc_strDKBID_HP, 2) & "' "
		strSQL = strSQL & "                                               ,  '" & CF_Ora_String(gc_strDKBID_JHP, 2) & "') "
		' === 20070331 === UPDATE S - ACE)Nagasawa 売上訂正返品対応
		'    strSQL = strSQL & "                        GROUP BY UDNTHA.MOTDATNO)"
		strSQL = strSQL & "                        GROUP BY UDNTRA.MOTDATNO)"
		' === 20070331 === UPDATE E -
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
		If bolRet = False Then
			GoTo AE_GET_URIInf_HNPN_Err
		End If
		
		bolOpen = True
		
		'返品数取得
		If CF_Ora_EOF(usrOdy_UDNTRA) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_curHNPNSU = CF_Ora_GetDyn(usrOdy_UDNTRA, "HNPNSU", 0) * (-1)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strHNPNKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "HNPNKN", 0) * (-1)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strHNPNZKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "HNPNZKN", 0) * (-1)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strHNPNFKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "HNPNFKN", 0) * (-1)
		End If
		
		AE_GET_URIInf_HNPN = True
		
AE_GET_URIInf_HNPN_End: 
		
		If bolOpen = True Then
			'クローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
		End If
		
		Exit Function
		
AE_GET_URIInf_HNPN_Err: 
		
		GoTo AE_GET_URIInf_HNPN_End
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CmnSYSTBCSaiban
	'   概要：  SYSTBCより伝票番号採番処理
	'   引数：　Pm_strJDNTRKB      :伝票取引区分種別
	'           Pm_strADDDENCD     :伝票付属コード("":空文字の場合は検索条件に含めない)
	'           Pm_strDENNO()      :採番された伝票番号
	'           Pm_strGetADDDENCD  :伝票付属コード
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CmnSYSTBCSaiban(ByVal Pm_strDKBSB As String, ByVal Pm_strADDDENCD As String, ByRef Pm_strDENNO() As String, Optional ByRef Pm_strGetADDDENCD As String = "") As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static curSTTNO As Decimal
		Static curENDNO As Decimal
		Static strADDDENCD As String
		Static intCnt As Short
		Static strNewNO As String
		
		On Error GoTo ERR_AE_CmnSYSTBCSaiban
		
		AE_CmnSYSTBCSaiban = 9
		
		bolTran = False
		
		Pm_strGetADDDENCD = ""
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'ユーザー伝票№テーブル取得
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & CF_Ora_String(Pm_strDKBSB, 3) & "' "
		If Pm_strADDDENCD <> "" Then
			strSQL = strSQL & "    And ADDDENCD = '" & CF_Ora_String(Pm_strADDDENCD, 13) & "' "
		End If
		strSQL = strSQL & "    for Update "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		If bolRet = False Then
			GoTo ERR_AE_CmnSYSTBCSaiban
		End If
		
		'EOF判定
		If CF_Ora_EOF(usrOdy) = True Then
			AE_CmnSYSTBCSaiban = 1
			GoTo ERR_AE_CmnSYSTBCSaiban
		End If
		
		'伝票付属コード取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Pm_strGetADDDENCD = CF_Ora_GetDyn(usrOdy, "ADDDENCD", "")
		
		'開始伝票No取得
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
			curSTTNO = 1
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curSTTNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
		End If
		
		'終了伝票No取得
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
			curENDNO = 1
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curENDNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
		End If
		
		'伝票NO.取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
		If curDENNO > curENDNO Then
			'終了伝票NOを超えた場合は戻る
			curDENNO = curSTTNO
		End If
		
		For intCnt = 1 To UBound(Pm_strDENNO)
			strNewNO = VB6.Format(curDENNO, New String("0", 8))
			Pm_strDENNO(intCnt) = strNewNO
			curDENNO = curDENNO + 1
			If curDENNO > curENDNO Then
				'終了伝票Noを超えた場合は戻る
				curDENNO = curSTTNO
			End If
		Next intCnt
		
		'ユーザー伝票№テーブル更新
		If UBound(Pm_strDENNO) > 0 Then
			
			strSQL = ""
			strSQL = strSQL & " UPDATE SYSTBC "
			strSQL = strSQL & "    SET DENNO      = '" & CF_Ora_String(strNewNO, 8) & "' "
			
			If Trim(GV_SysTime) <> "" Then
				strSQL = strSQL & "      , WRTTM      = '" & CF_Ora_String(GV_SysTime, 6) & "' "
			Else
				strSQL = strSQL & "      , WRTTM      = '" & CStr(VB6.Format(Now, "hhmmss")) & "' "
			End If
			
			If Trim(GV_SysDate) <> "" Then
				strSQL = strSQL & "      , WRTDT      = '" & CF_Ora_String(GV_SysDate, 8) & "' "
			Else
				strSQL = strSQL & "      , WRTDT      = '" & CStr(VB6.Format(Now, "yyyymmdd")) & "' "
			End If
			
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        DKBSB    = '" & CF_Ora_String(Pm_strDKBSB, 3) & "' "
			
			'ＳＱＬ実行
			bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
			If bolRet = False Then
				GoTo ERR_AE_CmnSYSTBCSaiban
			End If
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_CmnSYSTBCSaiban
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_CmnSYSTBCSaiban = 0
		
EXIT_AE_CmnSYSTBCSaiban: 
		Exit Function
		
ERR_AE_CmnSYSTBCSaiban: 
		
		If gv_Int_OraErr = 51 Then
			'他で使用中
			AE_CmnSYSTBCSaiban = 2
		End If
		
		If bolTran = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_CmnSYSTBCSaiban
		
	End Function
	' === 20070327 === INSERT E -
	
	' === 20060729 === INSERT S - ACE)Nagasawa 出荷指示トランの出荷予定管理番号を書き換える
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_FDNTRA_Update
	'   概要：  出荷指示トラン更新処理
	'   引数：　pm_strJDNNO     : 受注番号
	'           pm_strLINNO     : 行番号
	'           pm_strHINCD     : 製品コード
	'           pm_strNewDATNO  : 伝票管理番号(更新後)
	'           pm_strErrCd     : 更新異常エラーコード
	'  　     　pm_All          : 画面情報
	'   戻値：　0:正常  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_FDNTRA_Update(ByVal pm_strJDNNO As String, ByVal pm_strLINNO As String, ByVal pm_strHINCD As String, ByVal pm_strNewDATNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim strWhere As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_FDNTRA_Update_Err
		
		CF_FDNTRA_Update = 9
		
		'SQL編集(WHERE条件(共通))
		strWhere = ""
		strWhere = strWhere & "  WHERE "
		strWhere = strWhere & "        JDNNO      = '" & CF_Ora_String(pm_strJDNNO, 10) & "' "
		strWhere = strWhere & "    AND JDNLINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
		strWhere = strWhere & "    AND HINCD      = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		strWhere = strWhere & "    AND DATKB      = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        FDNTRA "
		strSQL = strSQL & "    SET SYKDATNO   = '" & CF_Ora_String(pm_strNewDATNO, 10) & "' "
		strSQL = strSQL & "      , UOPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      , UCLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      , UWRTTM   = '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , UWRTDT   = '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , PGID     = '" & CF_Ora_String(SSS_PrgId, 7) & "' " 'ＰＧＩＤ
		strSQL = strSQL & strWhere
		strSQL = strSQL & "    AND DATNO      = (SELECT MAX(DATNO) FROM FDNTRA "
		strSQL = strSQL & strWhere & ") "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_FDNTRA_Update_Err
		End If
		
		CF_FDNTRA_Update = 0
		
CF_FDNTRA_Update_End: 
		Exit Function
		
CF_FDNTRA_Update_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_FDNTRA_Update")
		
	End Function
	' === 20060729 === INSERT E
	
	' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CHK_MRPKB_PRT
	'   概要：  請求書出力対象明細チェック
	'   引数：  pin_strJDNNO      : 受注番号
	'   　　　  pin_strTOKCD      : 得意先コード
	'   戻値：  True : チェックOK　False : チェックNG（請求書が出力されないのに"要"となっている)
	'   備考：  請求書出力＝"要"となっている明細について売上情報の更新が行われるかを
	'           チェックする
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CHK_MRPKB_PRT(ByRef pin_usrUDNTHA As Cmn_UDNTHA_Upd, ByRef pot_strLinno As String) As Boolean
		
		Dim bolRet As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy_UDNTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolTran As Boolean
		Dim strDATNO As String
		Dim intCnt As Short
		Dim curKensu As Decimal
		
		On Error GoTo AE_CHK_MRPKB_PRT_Err
		
		AE_CHK_MRPKB_PRT = False
		
		pot_strLinno = ""
		
		bolTran = False
		
		strDATNO = ""
		For intCnt = 1 To UBound(pin_usrUDNTHA.DATNO)
			If Trim(strDATNO) <> "" Then
				strDATNO = strDATNO & ", "
			End If
			strDATNO = strDATNO & "'" & CF_Ora_String(pin_usrUDNTHA.DATNO(intCnt), 10) & "'"
		Next 
		
		For intCnt = 1 To UBound(pin_usrUDNTHA.usrBodyInf)
			'請求書出力区分="要"の明細のみチェック
			If Trim(pin_usrUDNTHA.usrBodyInf(intCnt).MRPKB) = gc_strMRPKB_PRT Then
				'売上トラン取得
				strSQL = ""
				strSQL = strSQL & " SELECT COUNT(*)   AS CNT "
				strSQL = strSQL & "   FROM UDNTRA "
				strSQL = strSQL & "  WHERE UDNTRA.DATNO in (" & strDATNO & ") "
				
				'受注取引区分により検索条件変更
				Select Case True
					'システム受注で出荷基準のもの、またはセットアップ受注
					Case (pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrUDNTHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SET
						strSQL = strSQL & "    AND JDNLINNO = '" & CF_Ora_String(pin_usrUDNTHA.usrBodyInf(intCnt).LINNO, 10) & "' "
						
						'システム受注で出荷基準以外のもの
					Case pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS
						strSQL = strSQL & "    AND RECNO    = '" & CF_Ora_String(pin_usrUDNTHA.usrBodyInf(intCnt).RECNO, 10) & "' "
						
						'上記以外
					Case Else
						strSQL = strSQL & "    AND SBNNO    = '" & CF_Ora_String(pin_usrUDNTHA.usrBodyInf(intCnt).SBNNO, 20) & "' "
				End Select
				
				'SQL実行
				bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
				If bolRet = False Then
					GoTo AE_CHK_MRPKB_PRT_Err
				End If
				bolTran = True
				
				'検索結果取得
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				curKensu = CF_Ora_GetDyn(usrOdy_UDNTRA, "CNT", 0)
				
				'クローズ
				Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
				bolTran = False
				
				If curKensu <= 0 Then
					
					If Trim(pot_strLinno) = "" Then
						pot_strLinno = pot_strLinno & "行No "
					Else
						pot_strLinno = pot_strLinno & ", "
					End If
					
					'UPGRADE_WARNING: オブジェクト CF_Ctr_AnsiRightB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pot_strLinno = pot_strLinno & CF_Ctr_AnsiRightB(pin_usrUDNTHA.usrBodyInf(intCnt).LINNO, 2)
				End If
			End If
		Next 
		
		If Trim(pot_strLinno) = "" Then
			AE_CHK_MRPKB_PRT = True
		End If
		
AE_CHK_MRPKB_PRT_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
		End If
		
		Exit Function
		
AE_CHK_MRPKB_PRT_Err: 
		GoTo AE_CHK_MRPKB_PRT_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Get_MRPKB
	'   概要：  請求書出力区分取得
	'   引数：  pin_strMRPKB_BFR  : 請求書出力区分(更新前データ)
	'   　　　  pin_bolAKAKRO     : 赤黒発生区分(True：赤黒発生有り)
	'   　　　  pin_strDATNO      : 伝票管理番号(更新前データ)
	'   　　　  pin_strURILINNO   : 売上行番号(更新前データ)
	'   　　　  pin_strSSADT_BFR  : 締日付(更新前データ)
	'   　　　  pin_strSSADT_AFT  : 締日付(更新後データ)
	'   　　　  pio_strMRPKB　　  : 請求書出力区分(IN:画面の値 OUT：更新値)
	'   戻値：  True : 正常終了　False : 異常終了
	'   備考：  画面で入力された請求書出力区分を条件より判定し、更新値として戻す。
	'　　　　　 必要な場合は過去データの請求書出力区分を更新する。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Get_MRPKB(ByVal pin_strMRPKB_BFR As String, ByVal pin_bolAKAKRO As Boolean, ByVal pin_strDatNo As String, ByVal pin_strURILINNO As String, ByVal pin_strSSADT_BFR As String, ByVal pin_strSSADT_AFT As String, ByRef pio_strMRPKB As String) As Boolean
		
		Dim bolRet As Boolean
		Dim strDatNo_Upd As String
		
		On Error GoTo AE_Get_MRPKB_Err
		
		AE_Get_MRPKB = False
		
		If Trim(pio_strMRPKB) = gc_strMRPKB_PRT Then
			'画面.請求書出力区分="要"の場合
			If pin_bolAKAKRO = True Then
				
				'赤黒伝票が発生する場合、入力値のままで終了(要)
				GoTo AE_Get_MRPKB_NormalEnd
				
			Else
				
				'赤黒伝票が発生しない場合
				If Trim(pin_strMRPKB_BFR) = gc_strMRPKB_NOPRT Then
					'元データの請求書発行区分＝"不要"の場合
					
					'データをさかのぼり最初に発見された赤伝票の請求書出力区分を"要"とする
					strDatNo_Upd = AE_Get_DATNO_MRPKBUpd(pin_strDatNo, pin_strSSADT_BFR)
					If Trim(strDatNo_Upd) = "" Then
						GoTo AE_Get_MRPKB_Err
					End If
					
					bolRet = AE_Upd_MRPKB_BfrUDNTRAData(strDatNo_Upd, pin_strURILINNO, gc_strMRPKB_PRT)
					If bolRet = False Then
						GoTo AE_Get_MRPKB_Err
					End If
					
					'入力値のままで終了(要)
					GoTo AE_Get_MRPKB_NormalEnd
					
				Else
					'元データの請求書発行区分<>"不要"の場合、入力値のままで終了(要)
					GoTo AE_Get_MRPKB_NormalEnd
					
				End If
				
			End If
		Else
			'画面.請求書出力区分="不要"の場合
			If pin_bolAKAKRO = True Then
				'赤黒伝票が発生する場合
				
				If AE_CHK_URIInf_HNPN_Exist(pin_strDatNo) = True Then
					'返品が発生している伝票場合、入力値のままで終了（不要)
					GoTo AE_Get_MRPKB_NormalEnd
				End If
				
				If Trim(pin_strSSADT_BFR) <> Trim(pin_strSSADT_AFT) Then
					'請求締日が変更になる場合、入力値のままで終了（不要)
					GoTo AE_Get_MRPKB_NormalEnd
				End If
				
				'請求締日が変更にならない赤黒の場合は、元データの値を引き継ぐ
				pio_strMRPKB = pin_strMRPKB_BFR
				GoTo AE_Get_MRPKB_NormalEnd
			Else
				'赤黒伝票が発生しない場合
				
				If Trim(pin_strMRPKB_BFR) = gc_strMRPKB_NOPRT Then
					'元データの請求書発行区分＝"不要"の場合、入力値のままで終了(不要)
					GoTo AE_Get_MRPKB_NormalEnd
				Else
					'元データの請求書発行区分を継承する(要 or 空白)
					pio_strMRPKB = pin_strMRPKB_BFR
					GoTo AE_Get_MRPKB_NormalEnd
				End If
			End If
		End If
		
AE_Get_MRPKB_NormalEnd: 
		AE_Get_MRPKB = True
		
AE_Get_MRPKB_End: 
		Exit Function
		
AE_Get_MRPKB_Err: 
		GoTo AE_Get_MRPKB_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Get_DATNO_MRPKBUpd
	'   概要：  同一請求書内で更新対象の赤伝票売上トランの伝票管理番号を取得する
	'   引数：  pin_strDATNO      : 検索対象伝票管理No
	'   　      pin_strDATNO      : 請求締日
	'   戻値：  伝票管理No（検索結果)
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Get_DATNO_MRPKBUpd(ByVal pin_strDatNo As String, ByVal pin_strSSADT As String) As String
		
		Dim bolRet As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy_UDNTHA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_UDNTHA As U_Ody
		Dim bolTran As Boolean
		Dim strDATNO As String
		Dim strDatNo_Sel As String '伝票管理No(黒伝票検索条件)
		Dim strMotoDatNo As String
		Dim strSSADT As String
		Dim bolLoopEnd As Boolean
		
		On Error GoTo AE_Get_DATNO_MRPKBUpd_Err
		
		AE_Get_DATNO_MRPKBUpd = ""
		
		strDatNo_Sel = pin_strDatNo
		bolLoopEnd = False
		bolTran = False
		
		Do Until bolLoopEnd = True
			'売上見出しトラン取得（元伝票管理No)
			strSQL = ""
			strSQL = strSQL & " SELECT UDNTHA.MOTDATNO "
			strSQL = strSQL & "      , UDNTHA.SSADT "
			strSQL = strSQL & "   FROM UDNTHA "
			strSQL = strSQL & "  WHERE UDNTHA.DATNO = '" & CF_Ora_String(strDatNo_Sel, 10) & "'"
			
			'SQL実行
			bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTHA, strSQL)
			If bolRet = False Then
				GoTo AE_Get_DATNO_MRPKBUpd_Err
			End If
			bolTran = True
			
			'EOF判定
			If CF_Ora_EOF(usrOdy_UDNTHA) = True Then
				bolLoopEnd = True
				Exit Do
			End If
			
			'検索結果取得
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strMotoDatNo = CF_Ora_GetDyn(usrOdy_UDNTHA, "MOTDATNO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSSADT = CF_Ora_GetDyn(usrOdy_UDNTHA, "SSADT", "")
			
			'請求締日が変わる場合、そこで処理終了
			If Trim(pin_strSSADT) <> Trim(strSSADT) Then
				bolLoopEnd = True
				Exit Do
			End If
			
			'元伝票管理Noが空白の場合、そこで処理終了
			If Trim(strMotoDatNo) = "" Then
				bolLoopEnd = True
				Exit Do
			End If
			
			'返品が発生している伝票の場合は処理終了
			If AE_CHK_URIInf_HNPN_Exist(strDatNo_Sel) = True Then
				bolLoopEnd = True
				Exit Do
			End If
			
			'クローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
			bolTran = False
			
			'売上見出しトラン取得（元伝票管理Noより赤伝票を取得)
			strSQL = ""
			strSQL = strSQL & " SELECT DATNO "
			strSQL = strSQL & "      , MOTDATNO "
			strSQL = strSQL & "   FROM UDNTHA "
			strSQL = strSQL & "  WHERE UDNTHA.MOTDATNO  = '" & CF_Ora_String(strMotoDatNo, 10) & "'"
			strSQL = strSQL & "    AND UDNTHA.AKAKROKB  = '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
			
			'SQL実行
			bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTHA, strSQL)
			If bolRet = False Then
				GoTo AE_Get_DATNO_MRPKBUpd_Err
			End If
			bolTran = True
			
			'EOF判定
			If CF_Ora_EOF(usrOdy_UDNTHA) = False Then
				'検索結果取得
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strDATNO = CF_Ora_GetDyn(usrOdy_UDNTHA, "DATNO", "")
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strDatNo_Sel = CF_Ora_GetDyn(usrOdy_UDNTHA, "MOTDATNO", "")
			Else
				strDATNO = ""
				strDatNo_Sel = strMotoDatNo
			End If
			
			'クローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
			bolTran = False
		Loop 
		
		AE_Get_DATNO_MRPKBUpd = strDATNO
		
AE_Get_DATNO_MRPKBUpd_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
		End If
		
		Exit Function
		
AE_Get_DATNO_MRPKBUpd_Err: 
		GoTo AE_Get_DATNO_MRPKBUpd_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CHK_URIInf_HNPN_Exist
	'   概要：  検索対象売上伝票に返品が発生しているかをチェックする
	'   引数：  pin_strDATNO      : 検索対象伝票管理No
	'   戻値：  True：返品あり　False：返品なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CHK_URIInf_HNPN_Exist(ByVal pin_strDatNo As String) As Boolean
		
		Dim bolRet As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy_UDNTHA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy_UDNTHA As U_Ody
		Dim bolTran As Boolean
		Dim strFDNNO As String
		Dim strODNNO As String
		Dim strRecNo As String
		Dim curHNPNSU As Decimal
		
		On Error GoTo AE_CHK_URIInf_HNPN_Exist_Err
		
		AE_CHK_URIInf_HNPN_Exist = False
		
		bolTran = False
		
		'売上見出しトラン取得
		strSQL = ""
		strSQL = strSQL & " SELECT UDNTHA.FDNNO "
		strSQL = strSQL & "      , UDNTRA.ODNNO "
		strSQL = strSQL & "      , UDNTRA.RECNO "
		strSQL = strSQL & "   FROM UDNTRA "
		strSQL = strSQL & "      , UDNTHA "
		strSQL = strSQL & "  WHERE UDNTRA.DATNO = '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "    AND UDNTRA.DATNO = UDNTHA.DATNO "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTHA, strSQL)
		If bolRet = False Then
			GoTo AE_CHK_URIInf_HNPN_Exist_Err
		End If
		bolTran = True
		
		Do Until CF_Ora_EOF(usrOdy_UDNTHA) = True
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strFDNNO = CF_Ora_GetDyn(usrOdy_UDNTHA, "FDNNO", "") '納品書番号
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strODNNO = CF_Ora_GetDyn(usrOdy_UDNTHA, "ODNNO", "") '出荷伝票番号
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strRecNo = CF_Ora_GetDyn(usrOdy_UDNTHA, "RECNO", "") 'レコード管理番号
			
			'返品データ検索
			Call AE_GET_URIInf_HNPN(strFDNNO, strODNNO, strRecNo, curHNPNSU)
			
			'返品が発生しているかをチェック(返品発生時は処理終了)
			If curHNPNSU <> 0 Then
				AE_CHK_URIInf_HNPN_Exist = True
				GoTo AE_CHK_URIInf_HNPN_Exist_End
			End If
			
			'次データ読込
			Call CF_Ora_MoveNext(usrOdy_UDNTHA)
		Loop 
		
		'クローズ
		Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
		bolTran = False
		
AE_CHK_URIInf_HNPN_Exist_End: 
		If bolTran = True Then
			'レコードセットクローズ
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
		End If
		
		Exit Function
		
AE_CHK_URIInf_HNPN_Exist_Err: 
		GoTo AE_CHK_URIInf_HNPN_Exist_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Upd_MRPKB_BfrUDNTRAData
	'   概要：  前データ売上トラン請求書出力区分更新処理
	'   引数：　pin_strDATNO    : 伝票管理番号
	'           pin_strMRPKB    : 請求書発行区分
	'   戻値：　True:正常  False:異常
	'   備考：　引数.伝票管理番号、売上行番号を条件に売上トランの請求書発行区分を更新する。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Upd_MRPKB_BfrUDNTRAData(ByVal pin_strDatNo As String, ByVal pin_strUDNLINNO As String, ByVal pin_strMRPKB As String) As Boolean
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo AE_Upd_MRPKB_BfrUDNTRAData_Err
		
		AE_Upd_MRPKB_BfrUDNTRAData = False
		
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTRA SET "
		strSQL = strSQL & "        MRPKB    = '" & CF_Ora_String(pin_strMRPKB, 1) & "' " '請求書発行区分
		'''' DEL 2012/06/14  FWEST) T.Yamamoto    Start    連絡票№FC12061401
		'    strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID, 8) & "' "       'ユーザーＩＤ（訂正）
		'    strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID, 5) & "' "       'クライアントＩＤ（訂正）
		'    strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' "                        'タイムスタンプ（訂正時間）
		'    strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' "                        'タイムスタンプ（訂正日付）
		'''' DEL 2012/06/14  FWEST) T.Yamamoto    End
		strSQL = strSQL & "      , UOPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザーＩＤ（バッチ）
		strSQL = strSQL & "      , UCLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      , UWRTTM   = '" & GV_SysTime & "' " 'タイムスタンプ（訂正時間）
		strSQL = strSQL & "      , UWRTDT   = '" & GV_SysDate & "' " 'タイムスタンプ（訂正日付）
		strSQL = strSQL & "      , PGID     = '" & CF_Ora_String(SSS_PrgId, 7) & "' " 'ＰＧＩＤ
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_strDatNo, 10) & "' "
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_strUDNLINNO, 3) & "' "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Upd_MRPKB_BfrUDNTRAData_Err
		End If
		
		AE_Upd_MRPKB_BfrUDNTRAData = True
		
AE_Upd_MRPKB_BfrUDNTRAData_End: 
		Exit Function
		
AE_Upd_MRPKB_BfrUDNTRAData_Err: 
		GoTo AE_Upd_MRPKB_BfrUDNTRAData_End
		
	End Function
	' === 20071213 === INSERT E -
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_TNADL71
	'   概要：  推定在庫照会用PL/SQL実行処理
	'   引数：　なし
	'   戻値：　戻り値
	'   備考：  PL/SQLを実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_TNADL71(ByRef pin_strHINCD As String, ByRef pin_strSOUCD As String, ByRef pin_curRELZAISU As Decimal) As Short
		
		Dim strSQL As String 'SQL文
		Dim strPara1 As String 'ﾊﾟﾗﾒｰﾀ1
		Dim strPara2 As String 'ﾊﾟﾗﾒｰﾀ2
		Dim strPara3 As String 'ﾊﾟﾗﾒｰﾀ3
		Dim strPara4 As String 'ﾊﾟﾗﾒｰﾀ4
		Dim lngPara5 As Integer 'ﾊﾟﾗﾒｰﾀ5
		Dim strPara6 As String 'ﾊﾟﾗﾒｰﾀ6
		Dim lngPara7 As Integer 'ﾊﾟﾗﾒｰﾀ7
		Dim lngPara8 As Integer 'ﾊﾟﾗﾒｰﾀ8
		Dim strPara9 As String 'ﾊﾟﾗﾒｰﾀ9
		Dim lngPara10 As Integer 'ﾊﾟﾗﾒｰﾀ10
		Dim lngPara11 As Integer 'ﾊﾟﾗﾒｰﾀ11
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(12) As OraParameter 'PL/SQLのバインド変数
		
		'受渡し変数初期設定
		strPara1 = Inp_Inf.InpTanCd '入力担当者コード
		strPara2 = Inp_Inf.InpCLIID 'クライアントID
		strPara3 = CF_Ora_String(pin_strHINCD, 10) '製品コード
		strPara4 = CF_Ora_String(pin_strSOUCD, 3) '倉庫コード
		lngPara5 = pin_curRELZAISU '現在在庫数
		strPara6 = CF_Ora_String(SSS_PrgId, 10)
		lngPara7 = 0
		lngPara8 = 0
		strPara9 = ""
		lngPara10 = 0
		lngPara10 = 0
		
		'パラメータの初期設定を行う（バインド変数）
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		
		'データ型をオブジェクトにセット
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11) = gv_Odb_USR1.Parameters("P11")
		
		'各オブジェクトのデータ型を設定
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(9).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(11).serverType = ORATYPE_NUMBER
		
		'PL/SQL呼び出しSQL
		strSQL = "BEGIN PRC_TNADL71_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11); End;"
		
		'DBアクセス
		Call CF_Ora_Execute(gv_Odb_USR1, strSQL)
		
		'** 戻り値取得
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara7 = param(7).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara8 = param(8).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strPara9 = param(9).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara10 = param(10).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara11 = param(11).Value
		
		'戻り値設定
		AE_Execute_PLSQL_TNADL71 = lngPara7
		
		'** パラメタ解消
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P11")
		
	End Function
	' === 20061217 === INSERT E -
	
	'''' ADD 2009/03/04  FKS) S.Nakajima    Start
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function funcEigyoshoHaishi
	'   概要：  恒久対応チェック
	'   引数：　strUNYDT_ : 対象日付   strBMNCD_ : 部門コード  strSTTTKDT_ : 適用開始日
	'   戻値：　戻り値 TRUE : ﾁｪｯｸOK  FALSE : ﾁｪｯｸNG
	'   備考：  恒久対応（営業所廃止）のチェックを行う。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function funcEigyoshoHaishi(ByVal strUNYDT_ As String, ByVal strBMNCD_ As String, ByVal strSTTTKDT_ As String) As Boolean
		
		Dim bolRet As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy As U_Ody
		Dim strENDTKDT As String
		
		On Error GoTo Err_Run
		
		funcEigyoshoHaishi = False
		
		' 適用日名称マスタ検索用ＳＱＬ文作成
		strSQL = ""
		strSQL = strSQL & " SELECT * " & vbCrLf
		strSQL = strSQL & "   FROM MEIMTC " & vbCrLf
		strSQL = strSQL & "  WHERE KEYCD   = '102' " & vbCrLf
		strSQL = strSQL & "    AND MEICDA  = '" & strBMNCD_ & "'" & vbCrLf
		strSQL = strSQL & "    AND STTTKDT = '" & strSTTTKDT_ & "'" & vbCrLf
		
		' ＳＱＬ文実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		If bolRet = False Then
			GoTo Exit_Run
		End If
		
		' データが存在した場合
		If Not CF_Ora_EOF(usrOdy) Then
			
			' 停止日の取得
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strENDTKDT = Trim(CStr(CF_Ora_GetDyn(usrOdy, "ENDTKDT", ""))) '停止日
			
			' 運用日が停止日以降の場合はエラー
			If strENDTKDT < strUNYDT_ Then
				GoTo Exit_Run
			End If
			
		End If
		
		funcEigyoshoHaishi = True
		
Exit_Run: 
		
		'クローズ
		Call CF_Ora_CloseDyn(usrOdy)
		
		Exit Function
		
Err_Run: 
		
		GoTo Exit_Run
		
	End Function
	
	'''' ADD 2009/03/04  FKS) S.Nakajima    End
	
	'''' ADD 2009/12/25  FKS) T.Yamamoto    Start    連絡票№768
	'''' ADD 2009/01/27  RISE) K.Miyajima    Start 連絡票№630
	'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'    '   名称：  Function F_GRKBP98_RunStored
	'    '   概要：  入金消込データの変更処理の実行処理（ストアド処理の呼出し）
	'    '   引数：  pmstrCLTID    : 端末番号
	'    '           pmstrOPEID    : ログインユーザーＩＤ
	'    '           pmstrJdnNo    : 受注番号
	'    '           pmstrNewDatNo : 伝票管理№
	'    '           pm_All        : 画面情報
	'    '   戻値：　0：正常終了　9:異常終了
	'    '   備考：
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_GRKBP98_RunStored( _
	''                                    ByVal pmstrCLTID As String, _
	''                                    ByVal pmstrOPEID As String, _
	''                                    ByVal pmstrJdnNo As String, _
	''                                    ByVal pmstrNewDatNo As String, _
	''                                    ByRef pm_All As Cls_All) As Integer
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GRKBP98_RunStored
	'   概要：  入金消込データの変更処理の実行処理（ストアド処理の呼出し）
	'   引数：  pmstrCLTID    : 端末番号
	'           pmstrOPEID    : ログインユーザーＩＤ
	'           pmstrUdnDatNo : 売上伝票管理番号
	'           pmstrUdnLinNo : 売上行番号
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GRKBP98_RunStored(ByVal pmstrCLTID As String, ByVal pmstrOPEID As String, ByVal pmstrUdnDatNo As String, ByVal pmstrUdnLinNo As String) As Short
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		Dim bolRet As Boolean
		Dim intRtnCd As Short '戻り値
		Dim strExecuteSQL As String
		
		F_GRKBP98_RunStored = 9
		
		On Error GoTo F_GRKBP98_RunStored_err
		
		'// -- ﾊﾟﾗﾒｰﾀのｸﾘｱ --
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("RTNCD")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("PARA_OPEID")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("PARA_CLTID")
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
		'    gv_Odb_USR1.Parameters.Remove "PARA_JDNNO"
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("PARA_UDNDATNO")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("PARA_UDNLINNO")
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		'// -- ﾊﾟﾗﾒｰﾀの設定 --
		
		'//戻り値
		intRtnCd = 0
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("RTNCD", intRtnCd, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters("RTNCD").serverType = ORATYPE_NUMBER
		
		'//ログインユーザーＩＤ
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("PARA_OPEID", pmstrOPEID, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters("PARA_OPEID").serverType = ORATYPE_CHAR
		
		'//端末番号
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("PARA_CLTID", pmstrCLTID, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters("PARA_CLTID").serverType = ORATYPE_CHAR
		
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
		'    '//受注番号
		'    gv_Odb_USR1.Parameters.Add "PARA_JDNNO", pmstrJdnNo, ORAPARM_INPUT
		'    gv_Odb_USR1.Parameters("PARA_JDNNO").serverType = ORATYPE_CHAR
		'
		'    '//伝票管理№
		'    gv_Odb_USR1.Parameters.Add "PARA_JDATNO", pmstrNewDatNo, ORAPARM_INPUT
		'    gv_Odb_USR1.Parameters("PARA_JDATNO").serverType = ORATYPE_CHAR
		
		'//売上伝票管理番号
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("PARA_UDNDATNO", pmstrUdnDatNo, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters("PARA_UDNDATNO").serverType = ORATYPE_CHAR
		
		'//売上行番号
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("PARA_UDNLINNO", pmstrUdnLinNo, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters("PARA_UDNLINNO").serverType = ORATYPE_CHAR
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		'//PL/SQLを呼ぶ（MAIN）
		strExecuteSQL = ""
		strExecuteSQL = strExecuteSQL & "BEGIN"
		strExecuteSQL = strExecuteSQL & " :RTNCD := GRKBP98.GRKBP98B ( "
		strExecuteSQL = strExecuteSQL & " :PARA_OPEID "
		strExecuteSQL = strExecuteSQL & ",:PARA_CLTID "
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
		'    strExecuteSQL = strExecuteSQL & ",:PARA_JDNNO "
		'    strExecuteSQL = strExecuteSQL & ",:PARA_JDATNO "
		strExecuteSQL = strExecuteSQL & ",:PARA_UDNDATNO "
		strExecuteSQL = strExecuteSQL & ",:PARA_UDNLINNO "
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		strExecuteSQL = strExecuteSQL & " );"
		strExecuteSQL = strExecuteSQL & "END;"
		
		'DBアクセス
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strExecuteSQL)
		If bolRet = False Then
			'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
			'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_042, pm_All)
			Call AE_CmnMsgLibrary_2(SSS_PrgNm, "2UODET52_042") 'ＤＢエラーが発生しました。
			'''' UPD 2009/12/23  FKS) T.Yamamoto    End
			GoTo F_GRKBP98_RunStored_End
		End If
		
		'//戻り値確認
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If gv_Odb_USR1.Parameters("RTNCD").Value <> 0 Then
			'//(異常)
			'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			F_GRKBP98_RunStored = gv_Odb_USR1.Parameters("RTNCD").Value
			GoTo F_GRKBP98_RunStored_End
		End If
		
		F_GRKBP98_RunStored = 0
		
F_GRKBP98_RunStored_End: 
		'//ﾊﾟﾗﾒｰﾀのｸﾘｱ
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("RTNCD")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("PARA_OPEID")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("PARA_CLTID")
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
		'    gv_Odb_USR1.Parameters.Remove "PARA_JDNNO"
		'    gv_Odb_USR1.Parameters.Remove "PARA_JDATNO"
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("PARA_UDNDATNO")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("PARA_UDNLINNO")
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		Exit Function
		
F_GRKBP98_RunStored_err: 
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    連絡票№768
		'    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_042, pm_All, "F_GRKBP98_RunStored")
		Call AE_CmnMsgLibrary_2(SSS_PrgNm, "2UODET52_042", "F_GRKBP98_RunStored") 'ＤＢエラーが発生しました。
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		GoTo F_GRKBP98_RunStored_End
		
	End Function
	'''' ADD 2009/01/27  RISE) K.Miyajima    End   連絡票№630
	'''' ADD 2009/12/25  FKS) T.Yamamoto    End
	
	'20130701 ADD START 新通販連携対応
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_Seq_STSTRA
	'   概要：  STSTRAシーケンス番号取得
	'   引数：　なし
	'   戻値：　所属部門コード
	'   備考：  シーケンス番号
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Seq_STSTRA() As String
		
		On Error GoTo ERR_HANDLE
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		
		CF_Get_Seq_STSTRA = ""
		
		Str_Sql = ""
		Str_Sql = Str_Sql & "SELECT"
		Str_Sql = Str_Sql & "       STSSEQ.nextval as VAL "
		Str_Sql = Str_Sql & "FROM"
		Str_Sql = Str_Sql & "       Dual "
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo ERR_HANDLE
		End If
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CF_Get_Seq_STSTRA = Trim(CF_Ora_GetDyn(Usr_Ody, "VAL"))
		
EXIT_HANDLE: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	'20130701 ADD END
	
	' === 20140129 === INSERT S - 両備)Shikichi
	Sub EVTLOG_OUT(ByRef PS_Msg_Txt As String, Optional ByRef PS_ProcName As String = "")
		'パラメータ構造体の宣言
		Dim M_EVTTBL_PARA As M_TYPE_EVTTBL_PARA
		Dim strExePath As String
		Dim dblRet As Double
		'コマンドライン引数の設定
		With M_EVTTBL_PARA
			.IVWRDT = VB6.Format(Now, "YYYYMMDD") 'イベント発生日
			.IVWRTM = VB6.Format(Now, "HHNNSS") 'イベント開始時間
			.PGID = SSS_PrgId 'プログラムＩＤ
			.CLTID = SSS_CLTID.Value 'クライアントＩＤ
			.IVCLASS = "ERR" 'イベント種別
			.IVMSG = PS_Msg_Txt 'イベント内容
			.IVPOINT = PS_ProcName 'イベント発生箇所
			.SNDPROFLG = "1" '送信可否フラグ
			
			If EvJdnno = "" Then
				.IVCODE = "0"
			Else
				.IVCODE = EvJdnno
			End If
			
			
			'EXEパスとコマンドラインの設定
			strExePath = SSS_INIDAT(2) & "EXE\EVTLG01.EXE " & Chr(34) & .IVWRDT & .IVWRTM & .PGID & .CLTID & .IVCLASS & .IVCODE & .IVPOINT & .SNDPROFLG & .IVMSG & Chr(34)
		End With
		'イベントログ作成プログラム起動
		dblRet = Shell(strExePath)
	End Sub
	' === 20140129 === INSERT E - 両備)Shikichi
End Module