Option Strict Off
Option Explicit On
Friend Class WLS_LIST2
	Inherits System.Windows.Forms.Form
	'*************************************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　勘定口座検索
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
	
	Private Structure TYPE_DB_MEIMTA
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(9),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=9)> Public MEICDA() As Char
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MEICDB() As Char
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(40),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=40)> Public MEINMA() As Char
	End Structure
	Private DB_SYSMEI_W As TYPE_DB_MEIMTA '検索結果退避
	
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
		WLSKOZ_RTNCODE = ""
		Call WLS_Clear()
		
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
		
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_SYSMEI_W.MEICDB, 1) & LeftWid(DB_SYSMEI_W.MEICDA, 9) & Space(2) & LeftWid(DB_SYSMEI_W.MEINMA, 40)
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
		
		strSql = ""
		strSql = strSql & " Select MEICDB"
		strSql = strSql & "      , MEICDA " '勘定口座コード"
		strSql = strSql & "      , MEINMA " '勘定口座名
		strSql = strSql & "   from MEIMTA "
		strSql = strSql & "  Where DATKB    = '1' "
		strSql = strSql & "  And   KEYCD    = '062' "
		''''''''strSQL = strSQL & "  And   MEIKBA   = '1'"                          '2006.10.24仕変
		
		'ソート条件
		strSql = strSql & "   order by MEICDB, MEICDA"
		
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
			DB_SYSMEI_W.MEICDB = CF_Ora_GetDyn(Usr_Ody, "MEICDB", "") '勘定口座コード
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_SYSMEI_W.MEICDA = CF_Ora_GetDyn(Usr_Ody, "MEICDA", "") '勘定口座コード
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_SYSMEI_W.MEINMA = CF_Ora_GetDyn(Usr_Ody, "MEINMA", "") '勘定口座名
			
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
	
	'
	'以下は画面イベント処理
	'
	'UPGRADE_WARNING: Form イベント WLS_LIST2.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_LIST2_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		
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
	
	Private Sub WLS_LIST2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		'Window初期設定
		Call WLS_FORM_INIT()
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
		WLSKOZ_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
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
		WLSKOZ_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		Hide()
	End Sub
End Class