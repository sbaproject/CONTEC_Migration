Option Strict Off
Option Explicit On
Friend Class WLS_TOK1
	Inherits System.Windows.Forms.Form
	'*************************************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　勘定口座検索 → 請求先検索に改造 2007/03/05 Saito
	'*  プログラムＩＤ　：  WLS_MEI
	'*  作成者　　　　　：　SYSTEM CREATE Co.,Ltd.
	'*  作成日　　　　　：  2006.10.21
	'*------------------------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'*************************************************************************************************
	
	'************************************************************************************
	'   Private定数
	'************************************************************************************
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '開始コード入力属性 [0,X]
	
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	'ウィンドﾕｰｻﾞｰ設定変数
	Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
	Private WM_WLS_CODELEN As Short '開始ｺｰﾄﾞ入力文字数
	Private WM_WLS_NAMELEN As Short '得意先略称入力文字数
	
	'ウィンド内部使用変数
	Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_CODE As String '入金種別コード検索用
	Private WM_WLS_MEIRN As String '入金種別略称検索用
	Private WM_WLS_MEINK_S As String '入金種別検索用(開始)
	Private WM_WLS_MEINK_E As String '入金種別検索用(終了)
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	
	Private Structure TYPE_DB_TOKMTB
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public TOKSEICD() As Char
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(40),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=40)> Public TOKSEIRN() As Char
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public TOKCD() As Char
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(40),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=40)> Public TOKRN() As Char
	End Structure
	Private DB_TOKMTA_W As TYPE_DB_TOKMTB '検索結果退避
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_FORM_INIT
	'   概要：  画面初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		
		'=== 表示開始コード桁数設定 ===
		WM_WLS_CODELEN = 10
		WM_WLS_MAX = 15 '画面表示件数
		'変数初期化
		WLSTOKSUB_RTNCODE = ""
		Call WLS_Clear()
		
		'条件項目クリア
		HD_TEXT.Text = ""
		HD_RN.Text = ""
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_SetArray
	'   概要：  リスト編集
	'   引数：　ArrayCnt : リスト編集対象INDEX
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		'        '====================================
		'        '   WINDOW 明細設定
		'        '====================================
		
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_TOKMTA_W.TOKSEICD, 10) & Space(1) & LeftWid(DB_TOKMTA_W.TOKSEIRN, 40) & Space(1) & LeftWid(DB_TOKMTA_W.TOKCD, 10) & Space(1) & LeftWid(DB_TOKMTA_W.TOKRN, 40)
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_TextSQL
	'   概要：  検索sql作成
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Sub WLS_TextSQL()
		
		Dim strSql As String
		Dim intData As Short
		
		strSql = "SELECT tm1.tokseicd, tm1.tokrn tokseirn, tm2.tokcd, tm2.tokrn " & "FROM ( " & "SELECT tokseicd, tokrn FROM tokmta " & "WHERE datkb = '1' AND frnkb = '0' " & " AND dspkb = '1' AND tokcd = tokseicd "
		'●国内請求先、検索区分＝１のみ表示
		
		'得意先ｺｰﾄﾞが入力されている時
		If Trim(HD_TEXT.Text) <> "" Then
			strSql = strSql & "AND tokcd >= '" & RTrim(HD_TEXT.Text) & "' "
		End If
		
		strSql = strSql & "ORDER BY 1 " & ") tm1, " & "tokmta tm2 " & "WHERE tm2.datkb = '1' " & "AND tm2.tokseicd in tm1.tokseicd "
		
		'得意先ｺｰﾄﾞが入力されている時
		If Trim(HD_TEXT.Text) <> "" Then
			strSql = strSql & "AND tm2.tokcd >= '" & RTrim(HD_TEXT.Text) & "' "
		End If
		
		'得意先略称名が入力されている時(あいまい検索とする)
		If Trim(HD_RN.Text) <> "" Then
			strSql = strSql & "AND tm2.tokrn LIKE '%" & RTrim(HD_RN.Text) & "%' "
		End If
		
		'整列条件
		strSql = strSql & "ORDER BY tokseicd"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
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
		Dim Wk_Pagecnt As Short
		
		Cnt = 0
		Wk_Pagecnt = -1
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			'取得内容退避
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTA_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTA_W.TOKSEIRN = CF_Ora_GetDyn(Usr_Ody, "tokseirn", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTA_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "tokcd", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTA_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "tokrn", "")
			
			'表示改ページ
			If Cnt Mod WM_WLS_MAX = 0 Then
				Wk_Pagecnt = Wk_Pagecnt + 1
				'最終ページ退避
				WM_WLS_LastPage = Wk_Pagecnt
				ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
				Cnt = 0
			End If
			
			'表示メモリ展開
			Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + Cnt)
			
			Cnt = Cnt + 1
			
			Call CF_Ora_MoveNext(Usr_Ody)
		Loop 
		
		'取得データ有無に関わらず最終データ到達
		WM_WLS_LastFL = True
		
		If Cnt > 0 Then
			'１ページを表示
			WM_WLS_Pagecnt = 0
			Call WLS_DspPage()
		Else
			LST.Items.Clear()
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
			LST.Focus()
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_Clear
	'   概要：  変数初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_Clear()
		'Sub WLS_Clear
		
		'検索条件
		WM_WLS_CODE = ""
		WM_WLS_MEIRN = ""
		WM_WLS_MEINK_S = ""
		WM_WLS_MEINK_E = ""
		
		'画面表示ページ
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
		'検索結果保持配列
		ReDim WM_WLS_DSPArray(0)
		
	End Sub
	
	'得意先ｺｰﾄﾞボタンクリック時
	Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
		WLS_TOK2.ShowDialog()
		WLS_TOK2.Close()
		
		HD_TEXT.Focus()
		If WLSTOK_RTNCODE <> "" Then
			HD_TEXT.Text = WLSTOK_RTNCODE
			'検索実行
			Call WLS_Clear()
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	'
	'以下は画面イベント処理
	'
	'UPGRADE_WARNING: Form イベント WLS_TOK1.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_TOK1_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		
		System.Windows.Forms.Application.DoEvents()
		
		
		WM_WLS_Dspflg = False
		
		'項目初期化
		'Call WLS_Kana_Init
		'HD_CODE.Text = ""
		'HD_NAME.Text = ""
		'WLSKANA.ListIndex = 0
		LST.Items.Clear()
		WM_WLS_Dspflg = True
		
		ReDim WM_WLS_DSPArray(0)
		
		'初期状態全件表示
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		DblClickFl = False
		
		Me.Refresh()
		'HD_CODE.SetFocus
	End Sub
	
	Private Sub WLS_TOK1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		'Window初期設定
		Call WLS_FORM_INIT()
	End Sub
	
	'得意先略称項目でキーを押した時
	Private Sub HD_RN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_RN.Enter
		'全選択状態にする
		HD_RN.SelectionStart = 0
		HD_RN.SelectionLength = 40
	End Sub
	
	'得意先略称項目でキーを押した時
	Private Sub HD_RN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_RN.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Enter押下時に再検索を実行
		If KeyCode = System.Windows.Forms.Keys.Return Then
			Call WLS_Clear()
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	'得意先ｺｰﾄﾞ項目にフォーカスが移動した時
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		'全選択状態にする
		HD_TEXT.SelectionStart = 0
		HD_TEXT.SelectionLength = 5
	End Sub
	
	'得意先ｺｰﾄﾞ項目でキーを押した時
	Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Enter押下時に再検索を実行
		If KeyCode = System.Windows.Forms.Keys.Return Then
			Call WLS_Clear()
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	'''Private Sub HD_CODE_GotFocus()
	'''    If LenWid(HD_CODE.Text) > 0 Then
	'''        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
	'''    Else
	'''        HD_CODE.Text = Space$(HD_CODE.MaxLength)
	'''    End If
	'''    HD_CODE.SelStart = 0
	'''    HD_CODE.SelLength = HD_CODE.MaxLength
	'''End Sub
	'''
	'''Private Sub HD_CODE_KeyDown(KeyCode As Integer, Shift As Integer)
	'''    If KeyCode = vbKeyReturn Then
	'''        WM_WLS_Dspflg = False
	'''        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
	'''
	'''        '検索用変数セット
	'''        Call WLS_Clear
	'''        WM_WLS_CODE = HD_CODE.Text
	'''
	'''        '他検索条件クリア
	'''        WM_WLS_Dspflg = True
	'''
	'''        Call WLS_TextSQL
	'''        Call WLS_DspNew
	'''    End If
	'''End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSTOKSUB_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
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
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspPage()
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
		WLSTOKSUB_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		Hide()
	End Sub
End Class