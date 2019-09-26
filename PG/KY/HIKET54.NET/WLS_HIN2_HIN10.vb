Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSHIN
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　製品検索
	'*  プログラムＩＤ　：  WLSSHIN
	'*  作成者　　　　　：　ACE)長澤
	'*  作成日　　　　　：  2006.05.12
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	
	'************************************************************************************
	'   Private定数
	'************************************************************************************
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '開始コード入力属性 [0,X]
	
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	'ウィンドﾕｰｻﾞｰ設定変数
	Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
	Private WM_WLS_CODELEN As Short '開始製品ｺｰﾄﾞ入力文字数
	Private WM_WLS_HINNMALEN As Short '型式入力文字数
	Private WM_WLS_HINNMBLEN As Short '品名表示文字数
	' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
	Private WM_WLS_HINKBLEN As Short '商品区分文字数
	Private WM_WLS_HINKBNMLEN As Short '商品区分名文字数
	' === 20061205 === INSERT E -
	
	'ウィンド内部使用変数
	Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_CODE As String '製品コード検索用
	Private WM_WLS_HINNMA As String '型式検索用
	Private WM_WLS_HINNK_S As String '商品名カナ検索用(開始)
	Private WM_WLS_HINNK_E As String '商品名カナ検索用(終了)
	' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
	Private WM_WLS_HINKB As String '商品区分
	' === 20061205 === INSERT E -
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private DB_HINMTA_W As TYPE_DB_HINMTA
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
	Private bolInitWindow As Boolean '画面初期化フラグ(True:初期化)
	' === 20061205 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_FORM_INIT
	'   概要：  画面初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		'=== 表示開始コード桁数設定 ===
		'''' UPD 2009/02/19  FKS) S.Nakajima    Start
		'        WM_WLS_CODELEN = 8
		WM_WLS_CODELEN = 10
		'''' UPD 2009/02/19  FKS) S.Nakajima    End
		WM_WLS_HINNMALEN = 30
		' === 20060902 === UPDATE S - ACE)Nagasawa
		'        WM_WLS_HINNMBLEN = 30
		WM_WLS_HINNMBLEN = 50
		' === 20060902 === UPDATE E -
		' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
		WM_WLS_HINKBLEN = 1
		WM_WLS_HINKBNMLEN = 6
		' === 20061205 === INSERT E -
		WM_WLS_MAX = 15 '画面表示件数
		
		'変数初期化
		WLSHIN_RTNCODE = ""
		Call WLS_Clear()
		Dyn_Open = False
		
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_SetArray
	'   概要：  リスト編集
	'   引数：　ArrayCnt : リスト編集対象INDEX
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_HINMTA_W.HINCD, WM_WLS_CODELEN) & Space(2) & LeftWid(DB_HINMTA_W.HINNMA, WM_WLS_HINNMALEN) & Space(2) & LeftWid(DB_HINMTA_W.HINNMB, WM_WLS_HINNMBLEN)
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_TextSQL
	'   概要：  検索sql作成
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL()
		
		Dim strSQL As String
		Dim intData As Short
		
		strSQL = ""
		' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
		'D        strSQL = strSQL & " Select HINCD "          '製品コード
		strSQL = strSQL & " Select "
		
		'ヒント句の編集
		Select Case True
			'入力検索条件がない場合、主キー検索
			Case Trim(WM_WLS_CODE) & Trim(WM_WLS_HINNMA) & Trim(WM_WLS_HINNK_S) & Trim(WM_WLS_HINKB) = ""
				If Trim(WLSHIN_SKHINGRP) <> "" Then
					strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA07) */ "
				Else
					strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA01) */ "
				End If
				'カナが指定されている場合、キー０２で検索
			Case Trim(WM_WLS_HINNK_S) <> ""
				strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA02) */ "
				
				'開始製品コードが指定されている場合、主キーで検索
			Case Trim(WM_WLS_CODE) <> ""
				strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA01) */ "
				
				'型式が１文字のみでの場合は主キーで検索
			Case Len(Trim(WM_WLS_HINNMA)) = 1 And Trim(WM_WLS_CODE) & Trim(WM_WLS_HINNK_S) & Trim(WM_WLS_HINKB) = ""
				strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA01) */ "
				
				'上記以外の場合は編集なし（キー０６が使用される？？）
			Case Else
				
		End Select
		
		strSQL = strSQL & "        HINCD " '製品コード
		' === 20081205 === UPDATE E - ACE)Nagasawa
		strSQL = strSQL & "      , HINNMA " '型式
		strSQL = strSQL & "      , HINNMB " '商品名
		' === 20060726 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "      , HINNK " '商品名カナ
		' === 20060726 === INSERT E -
		strSQL = strSQL & "   from HINMTA "
		strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    and DSPKB    = '" & gc_strDSPKB_OK & "' "
		'        strSQL = strSQL & "    and MNTENDKB = '" & gc_strMNTENDKB_NML & "' "
		'        strSQL = strSQL & "    and SLENDKB  = '" & gc_strSLENDKB_NML & "' "
		'        strSQL = strSQL & "    and JODSTPKB = '" & gc_strJODSTPKB_NML & "' "
		
		'製品コード検索
		If Trim(WM_WLS_CODE) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
			'            strSQL = strSQL & "    and HINCD >=   '" & WM_WLS_CODE & "'"
			strSQL = strSQL & "    and HINCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
			' === 20080929 === UPDATE E -
		End If
		
		'型式検索(あいまい検索)
		If Trim(WM_WLS_HINNMA) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
			'            strSQL = strSQL & "    and HINNMA LIKE '%" & WM_WLS_HINNMA & "%'"
			strSQL = strSQL & "    and HINNMA LIKE '%" & CF_Ora_String(WM_WLS_HINNMA, CF_Ctr_AnsiLenB(WM_WLS_HINNMA)) & "%'"
			' === 20080929 === UPDATE E -
		End If
		
		'商品名カナ検索
		If Trim(WM_WLS_HINNK_S) <> "" Then
			strSQL = strSQL & "    and HINNK >= '" & WM_WLS_HINNK_S & "' And HINNK < '" & WM_WLS_HINNK_E & "'"
		End If
		
		' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
		'商品区分検索
		If Trim(WM_WLS_HINKB) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
			'            strSQL = strSQL & "    and HINKB  = '" & WM_WLS_HINKB & "' "
			strSQL = strSQL & "    and HINKB  = '" & CF_Ora_String(WM_WLS_HINKB, CF_Ctr_AnsiLenB(WM_WLS_HINKB)) & "' "
			' === 20080929 === UPDATE E -
		End If
		' === 20061205 === INSERT E -
		
		' === 20061026 === INSERT S - FKS)KUMEDA
		If Trim(WLSHIN_SKHINGRP) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
			'            strSQL = strSQL & "    and SKHINGRP = '" & WLSHIN_SKHINGRP & "' "
			strSQL = strSQL & "    and SKHINGRP = '" & CF_Ora_String(WLSHIN_SKHINGRP, CF_Ctr_AnsiLenB(WLSHIN_SKHINGRP)) & "' "
			' === 20080929 === UPDATE E -
		End If
		' === 20061026 === INSERT E
		
		' === 20060828 === INSERT S - ACE)Sejima 仮本区分対応
		' === 20060829 === UPDATE S - ACE)Nagasawa
		'        '仮本区分検索（※画面入力項目でない）
		'        If Trim(WLSHIN_KHNKB) <> "" Then
		'            strSQL = strSQL & "    and KHNKB = '" & WLSHIN_KHNKB & "'"
		'        End If
		
		'本製品のみ検索（※画面入力項目でない）
		If Trim(WLSHIN_KHNSEARCH) <> "1" Then
			strSQL = strSQL & "    and KHNKB = '" & gc_strKHNKB_HON & "'"
		End If
		
		' === 20060829 === UPDATE E -
		' === 20060828 === INSERT E
		
		'セットアップ受注登録、訂正は部品商品マスタも合わせて検索
		If Trim(WLSHIN_BHNSEARCH) = "1" Then
			strSQL = strSQL & " union " '製品コード
			strSQL = strSQL & " Select HINCD " '製品コード
			strSQL = strSQL & "      , HINNMA " '型式
			strSQL = strSQL & "      , HINNMB " '商品名
			' === 20060726 === INSERT S - ACE)Nagasawa
			strSQL = strSQL & "      , HINNK " '商品名カナ
			' === 20060726 === INSERT E -
			strSQL = strSQL & "   from BHNMTA "
			strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
			strSQL = strSQL & "    and DSPKB    = '" & gc_strDSPKB_OK & "' "
			strSQL = strSQL & "    and MNTENDKB = '" & gc_strMNTENDKB_NML & "' "
			strSQL = strSQL & "    and SLENDKB  = '" & gc_strSLENDKB_NML & "' "
			strSQL = strSQL & "    and JODSTPKB = '" & gc_strJODSTPKB_NML & "' "
			
			'製品コード検索
			If Trim(WM_WLS_CODE) <> "" Then
				' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
				'                strSQL = strSQL & "    and HINCD >=   '" & WM_WLS_CODE & "'"
				strSQL = strSQL & "    and HINCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
				' === 20080929 === UPDATE E -
			End If
			
			'型式検索(あいまい検索)
			If Trim(WM_WLS_HINNMA) <> "" Then
				' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
				'                strSQL = strSQL & "    and HINNMA LIKE '%" & WM_WLS_HINNMA & "%'"
				strSQL = strSQL & "    and HINNMA LIKE '%" & CF_Ora_String(WM_WLS_HINNMA, CF_Ctr_AnsiLenB(WM_WLS_HINNMA)) & "%'"
				' === 20080929 === UPDATE E -
			End If
			
			'商品名カナ検索
			If Trim(WM_WLS_HINNK_S) <> "" Then
				strSQL = strSQL & "    and HINNK >= '" & WM_WLS_HINNK_S & "' And HINNK < '" & WM_WLS_HINNK_E & "'"
			End If
			
			' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
			'商品区分検索
			If Trim(WM_WLS_HINKB) <> "" Then
				' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
				'                strSQL = strSQL & "    and HINKB  = '" & WM_WLS_HINKB & "' "
				strSQL = strSQL & "    and HINKB  = '" & CF_Ora_String(WM_WLS_HINKB, CF_Ctr_AnsiLenB(WM_WLS_HINKB)) & "' "
				' === 20080929 === UPDATE E -
			End If
			' === 20061205 === INSERT E -
			
		End If
		'ソート条件
		strSQL = strSQL & "   order by "
		If Trim(WM_WLS_HINNK_S) <> "" Then
			'商品名カナ検索の場合
			strSQL = strSQL & "   HINNK "
			strSQL = strSQL & "  ,HINCD "
		Else
			'製品コード検索,型式検索
			strSQL = strSQL & "   HINCD "
		End If
		
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		Dyn_Open = True
		' === 20060726 === INSERT S - ACE)Nagasawa
		LST.Items.Clear()
		' === 20060726 === INSERT E -
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_DspNew
	'   概要：  リスト編集処理(初期情報)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		Dim Cnt As Integer
		
		Cnt = 0
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			'取得内容退避
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_HINMTA_W.HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '製品コード
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_HINMTA_W.HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "") '型式
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_HINMTA_W.HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "") '商品名
			
			'表示改ページ
			If Cnt Mod WM_WLS_MAX = 0 Then
				WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
				ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
				Cnt = 0
				'最終ページ退避
				WM_WLS_LastPage = WM_WLS_Pagecnt
			End If
			
			'表示メモリ展開
			Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)
			
			Cnt = Cnt + 1
			
			Call CF_Ora_MoveNext(Usr_Ody)
			
			If Cnt >= WM_WLS_MAX Then
				Exit Do
			End If
		Loop 
		
		'最終データ到達
		If CF_Ora_EOF(Usr_Ody) = True Then
			WM_WLS_LastFL = True
		End If
		
		If Cnt > 0 Then
			'ページを表示
			Call WLS_DspPage()
		End If
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_DspPage
	'   概要：  リスト編集処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspPage()
		Dim WL_Mode As Short
		Dim intCnt As Short
		
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		LST.Items.Clear()
		intCnt = 0
		Do While intCnt < WM_WLS_MAX
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt))
			End If
			intCnt = intCnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			' === 20061228 === INSERT S - ACE)Nagasawa
			On Error Resume Next
			' === 20061228 === INSERT E -
			LST.Focus()
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_Kana_Init
	'   概要：  カナコンボボックス初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Kana_Init()
		
		'カナ検索 Combo 初期化
		WLSKANA.Items.Add("コード")
		WLSKANA.Items.Add("ア行      ｱｵ")
		WLSKANA.Items.Add("カ行      ｶｺ")
		WLSKANA.Items.Add("サ行      ｻｿ")
		WLSKANA.Items.Add("タ行      ﾀﾄ")
		WLSKANA.Items.Add("ナ行      ﾅﾉ")
		WLSKANA.Items.Add("ハ行      ﾊﾎ")
		WLSKANA.Items.Add("マ行      ﾏﾓ")
		WLSKANA.Items.Add("ヤ行      ﾔﾖ")
		WLSKANA.Items.Add("ラ行      ﾗﾛ")
		WLSKANA.Items.Add("ワ行      ﾜﾝ")
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_Clear
	'   概要：  変数初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Clear()
		
		'検索条件
		WM_WLS_CODE = ""
		WM_WLS_HINNMA = ""
		WM_WLS_HINNK_S = ""
		WM_WLS_HINNK_E = ""
		' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
		WM_WLS_HINKB = ""
		' === 20061205 === INSERT E -
		
		'画面表示ページ
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
		'検索結果保持配列
		ReDim WM_WLS_DSPArray(0)
		
	End Sub
	
	'
	'以下は画面イベント処理
	'
	'UPGRADE_WARNING: Form イベント WLSHIN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSHIN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		
		' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
		If bolInitWindow = False Then
			Exit Sub
		Else
			bolInitWindow = False
		End If
		' === 20061205 === INSERT E -
		
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WM_WLS_Dspflg = False
		
		'項目初期化
		Call WLS_Kana_Init()
		HD_CODE.Text = ""
		HD_KATA.Text = ""
		' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
		HD_HINKB.Text = ""
		HD_HINKBNM.Text = ""
		' === 20061205 === INSERT E -
		WLSKANA.SelectedIndex = 0
		LST.Items.Clear()
		WM_WLS_Dspflg = True
		
		ReDim WM_WLS_DSPArray(0)
		
		'''' UPD 2011/02/07  FKS) T.Yamamoto    Start    連絡票№FC11020701
		'画面表示時に検索しない
		'        '初期状態全件表示
		'        Call WLS_TextSQL
		'        Call WLS_DspNew
		'デフォルトで製品を設定
		HD_HINKB.Text = "1"
		WM_WLS_HINKB = HD_HINKB.Text
		'商品区分名編集
		Call F_Dsp_HD_HINKBNM()
		'''' UPD 2011/02/07  FKS) T.Yamamoto    End
		
		DblClickFl = False
		
		Me.Refresh()
		'''' UPD 2011/02/07  FKS) T.Yamamoto    Start    連絡票№FC11020701
		'' === 20060821 === UPDATE S - ACE)Nagasawa
		''        HD_KATA.SetFocus
		'' === 20061228 === INSERT S - ACE)Nagasawa
		'                On Error Resume Next
		'' === 20061228 === INSERT E -
		'        LST.SetFocus
		'' === 20060821 === UPDATE E -
		On Error Resume Next
		HD_KATA.Focus()
		'''' UPD 2011/02/07  FKS) T.Yamamoto    End
	End Sub
	
	Private Sub WLSHIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window初期設定
		Call WLS_FORM_INIT()
		' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
		bolInitWindow = True
		' === 20061205 === INSERT E -
	End Sub
	
	Private Sub HD_CODE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CODE.Enter
		'UPGRADE_WARNING: オブジェクト LenWid(HD_CODE.Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(HD_CODE.Text) > 0 Then
			'UPGRADE_WARNING: TextBox プロパティ HD_CODE.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			'---------- 20061019 ACE MENTE START ----------
			'   Else
			'       HD_CODE.Text = Space$(HD_CODE.MaxLength)
			'---------- 20061019 ACE MENTE E N D ----------
		End If
		HD_CODE.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_CODE.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_CODE.SelectionLength = HD_CODE.Maxlength
	End Sub
	
	Private Sub HD_CODE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_CODE.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox プロパティ HD_CODE.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_CODE = HD_CODE.Text
			' === 20061211 === INSERT S - ACE)Nagasawa
			WM_WLS_HINKB = HD_HINKB.Text
			' === 20061211 === INSERT E -
			
			'他検索条件クリア
			WLSKANA.SelectedIndex = 0
			HD_KATA.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_CODE_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_CODE.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		KeyAscii = Asc(UCase(Chr(KeyAscii)))
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'2008/08/13 START ADD FKS)HAYASHI-連絡票№：FC08081301
	'UPGRADE_WARNING: イベント HD_KATA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_KATA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KATA.TextChanged
		
		Dim lngCnt As Integer
		
		lngCnt = HD_KATA.SelectionStart
		HD_KATA.Text = StrConv(HD_KATA.Text, VbStrConv.UpperCase)
		HD_KATA.SelectionStart = lngCnt
		
	End Sub
	'2008/08/13 E.N.D ADD FKS)HAYASHI-連絡票№：FC08081301
	
	Private Sub HD_KATA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KATA.Enter
		'---------- 20061019 ACE MENTE START ----------
		'   If LenWid(HD_KATA.Text) <= 0 Then
		'       HD_KATA.Text = Space$(HD_KATA.MaxLength)
		'   End If
		'---------- 20061019 ACE MENTE E N D ----------
		HD_KATA.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_KATA.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_KATA.SelectionLength = HD_KATA.Maxlength
	End Sub
	
	Private Sub HD_KATA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KATA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_HINNMA = HD_KATA.Text
			' === 20061211 === INSERT S - ACE)Nagasawa
			WM_WLS_HINKB = HD_HINKB.Text
			' === 20061211 === INSERT E -
			
			'他検索条件クリア
			WLSKANA.SelectedIndex = 0
			HD_CODE.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSHIN_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KEYCODE
			'Enterキー押下
			Case System.Windows.Forms.Keys.Return
				Call WLSOK_Click(WLSOK, New System.EventArgs())
				
				'Escapeキー押下
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
				
				'←キー押下
			Case System.Windows.Forms.Keys.Left
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
				
				'→キー押下
			Case System.Windows.Forms.Keys.Right
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: イベント WLSKANA.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub WLSKANA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKANA.SelectedIndexChanged
		Dim W_BUF As Object
		If WM_WLS_Dspflg = False Then Exit Sub
		WM_WLS_Dspflg = False
		WM_WLS_Dspflg = True
		
		Call WLS_Clear()
		
		'検索用変数セット
		If WLSKANA.SelectedIndex > 0 Then
			'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
			'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_HINNK_S = VB.Left(W_BUF, 1)
			'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_HINNK_E = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
			' === 20061211 === INSERT S - ACE)Nagasawa
			WM_WLS_HINKB = HD_HINKB.Text
			' === 20061211 === INSERT E -
			
			'他検索条件クリア
			HD_CODE.Text = ""
			HD_KATA.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
			' === 20061211 === INSERT S - ACE)Nagasawa
		Else
			If WLSKANA.SelectedIndex = 0 Then
				WM_WLS_HINNK_S = ""
				WM_WLS_HINNK_E = ""
				WM_WLS_HINKB = HD_HINKB.Text
				
				'他検索条件クリア
				HD_CODE.Text = ""
				HD_KATA.Text = ""
				WM_WLS_Dspflg = True
				
				Call WLS_TextSQL()
				Call WLS_DspNew()
			End If
			' === 20061211 === INSERT E -
		End If
		
	End Sub
	
	Private Sub WLSKANA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKANA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = True
			Call WLSKANA_SelectedIndexChanged(WLSKANA, New System.EventArgs())
		Else
			WM_WLS_Dspflg = False
		End If
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		' === 20060728 === DELETE S - ACE)Furukawa
		'    Call WLS_DspNew
		' === 20060728 === DELETE E
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			' === 20060728 === UPDATE S - ACE)Furukawa
			'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
			' === 20060728 === UPDATE ↓
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
			' === 20060728 === UPDATE E
		Else
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_DspPage()
		End If
	End Sub
	
	Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(1).Image
	End Sub
	
	Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(0).Image
	End Sub
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
			Call WLS_DspPage()
		End If
	End Sub
	
	Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(1).Image
	End Sub
	
	Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(0).Image
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		
		WLSHIN_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
		Hide()
	End Sub
	
	' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
	Private Sub HD_HINKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINKB.Enter
		'UPGRADE_WARNING: オブジェクト LenWid(HD_HINKB.Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(HD_HINKB.Text) > 0 Then
			'UPGRADE_WARNING: TextBox プロパティ HD_HINKB.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_HINKB.Text = SSS_EDTITM_WLS(HD_HINKB.Text, HD_HINKB.Maxlength, WM_WLSKEY_ZOKUSEI)
		End If
		HD_HINKB.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_HINKB.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_HINKB.SelectionLength = HD_HINKB.Maxlength
	End Sub
	
	Private Sub HD_HINKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			' === 20061222 === INSERT S - ACE)Nagasawa
			'画面表示ページ
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			
			'検索結果保持配列
			ReDim WM_WLS_DSPArray(0)
			' === 20061222 === INSERT E -
			
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox プロパティ HD_HINKB.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_HINKB.Text = SSS_EDTITM_WLS(HD_HINKB.Text, HD_HINKB.Maxlength, WM_WLSKEY_ZOKUSEI)
			
			'商品区分名編集
			Call F_Dsp_HD_HINKBNM()
			
			WM_WLS_HINKB = HD_HINKB.Text
			
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_HINKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		KeyAscii = Asc(UCase(Chr(KeyAscii)))
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HINKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINKB.Leave
		
		WM_WLS_Dspflg = False
		'UPGRADE_WARNING: TextBox プロパティ HD_HINKB.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_HINKB.Text = SSS_EDTITM_WLS(HD_HINKB.Text, HD_HINKB.Maxlength, WM_WLSKEY_ZOKUSEI)
		
		'商品区分名編集
		Call F_Dsp_HD_HINKBNM()
		
		'検索用変数セット
		WM_WLS_HINKB = HD_HINKB.Text
		
		WM_WLS_Dspflg = True
		
	End Sub
	
	Private Sub HD_HINKBNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINKBNM.Enter
		Call F_Ctl_HD_Focus()
	End Sub
	
	Private Function F_Dsp_HD_HINKBNM() As Short
		
		Dim Mst_Inf_MEI As TYPE_DB_MEIMTA
		
		'商品区分名編集
		HD_HINKBNM.Text = ""
		If DSPMEIM_SEARCH(gc_strKEYCD_HINKB, HD_HINKB.Text, Mst_Inf_MEI) = 0 Then
			If Mst_Inf_MEI.DATKB = gc_strDATKB_USE Then
				'UPGRADE_WARNING: TextBox プロパティ HD_HINKBNM.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
				HD_HINKBNM.Text = SSS_EDTITM_WLS(Mst_Inf_MEI.MEINMA, HD_HINKBNM.Maxlength, WM_WLSKEY_ZOKUSEI)
			End If
		End If
		
	End Function
	
	Private Function F_Ctl_HD_Focus() As Short
		If LST.Enabled = True Then
			' === 20061228 === INSERT S - ACE)Nagasawa
			On Error Resume Next
			' === 20061228 === INSERT E -
			LST.Focus()
		Else
			If WLSOK.Enabled = True Then
				' === 20061228 === INSERT S - ACE)Nagasawa
				On Error Resume Next
				' === 20061228 === INSERT E -
				WLSOK.Focus()
			End If
		End If
	End Function
	
	Private Sub CS_HINKB_Click()
		
		' === 20061228 === INSERT S - ACE)Nagasawa
		On Error Resume Next
		' === 20061228 === INSERT E -
		Me.HD_HINKB.Focus()
		
		WLSMEI_KEYCD = gc_strKEYCD_HINKB
		
		System.Windows.Forms.Application.DoEvents()
		
		WLS_MEI.ShowDialog()
		WLS_MEI.Close()
		
		'UPGRADE_NOTE: オブジェクト WLS_MEI をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		WLS_MEI = Nothing
		
		If Trim(WLSMEI_RTNMEICDA) <> "" Then
			'商品区分編集
			HD_HINKB.Text = Trim(WLSMEI_RTNMEICDA)
			
			Call HD_HINKB_KeyDown(HD_HINKB, New System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Return Or 0 * &H10000))
			
		End If
		
	End Sub
	' === 20061205 === INSERT E -
End Class