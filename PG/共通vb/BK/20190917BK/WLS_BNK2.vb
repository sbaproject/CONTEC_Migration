Option Strict Off
Option Explicit On
Friend Class WLSBNK2
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　銀行検索
	'*  プログラムＩＤ　：  WLSBNK2
	'*  作成者　　　　　：　RISE)宮島
	'*  作成日　　　　　：  2008.08.25
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	
	'************************************************************************************
	'   Public変数
	'************************************************************************************
	'戻り値
	
	'************************************************************************************
	'   Private定数
	'************************************************************************************
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '開始コード入力属性 [0,X]
	
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	'ウィンドﾕｰｻﾞｰ設定変数
	'20190621 chg start
	'Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
	Private WM_WLS_MFIL As object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
	'20190621 chg end
	Private WM_WLS_BNKCDLEN As Short '銀行ｺｰﾄﾞ入力文字数
	Private WM_WLS_BNKNMLEN As Short '銀行名称入力文字数
	Private WM_WLS_STNNMLEN As Short '支店名称入力文字数
	
	'ウィンド内部使用変数
	Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private DB_BNKMTA_W As TYPE_DB_BNKMTA '検索結果退避
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_FORM_INIT
	'   概要：  画面初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		
		'=== 表示開始コード桁数設定 ===
		WM_WLS_BNKCDLEN = 7
		WM_WLS_BNKNMLEN = 50
		WM_WLS_STNNMLEN = 50
		WM_WLS_MAX = 15 '画面表示件数
		'変数初期化
		WLSBNKMTA2_RTNCODE = ""
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
		'====================================
		'   WINDOW 明細設定
		'====================================
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_BNKMTA_W.BNKCD, WM_WLS_BNKCDLEN) & Space(3) & LeftWid(DB_BNKMTA_W.BNKNM, WM_WLS_BNKNMLEN) & Space(2) & LeftWid(DB_BNKMTA_W.STNNM, WM_WLS_STNNMLEN)
		
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
		
		strSQL = ""
		strSQL = strSQL & " Select BNKCD " '銀行ｺｰﾄﾞ
		strSQL = strSQL & "      , BNKNM " '銀行名称
		strSQL = strSQL & "      , STNNM " '支店名称
		strSQL = strSQL & "   from BNKMTA "
		strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "Order By BNKCD"
		
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
        'DBアクセス
        '2019/04/02 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/02 CHG E N D
		Dyn_Open = True
		LST.Items.Clear()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_DspNew
	'   概要：  リスト編集処理(初期情報)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		Dim cnt As Integer
		
        cnt = 0

        '2019/04/05 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '	'取得内容退避
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_BNKMTA_W.BNKCD = CF_Ora_GetDyn(Usr_Ody, "BNKCD", "") '銀行ｺｰﾄﾞ
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_BNKMTA_W.BNKNM = CF_Ora_GetDyn(Usr_Ody, "BNKNM", "") '銀行名称
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_BNKMTA_W.STNNM = CF_Ora_GetDyn(Usr_Ody, "STNNM", "") '支店名称

        '	'表示改ページ
        '	If cnt Mod WM_WLS_MAX = 0 Then
        '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '		ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '		cnt = 0
        '		'最終ページ退避
        '		WM_WLS_LastPage = WM_WLS_Pagecnt
        '	End If

        '	'表示メモリ展開
        '	Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)

        '	cnt = cnt + 1

        '	Call CF_Ora_MoveNext(Usr_Ody)

        '	If cnt >= WM_WLS_MAX Then
        '		Exit Do
        '	End If
        'Loop 

        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1
            '取得内容退避
            DB_BNKMTA_W.BNKCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("BNKCD"), "") '銀行ｺｰﾄﾞ
            DB_BNKMTA_W.BNKNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("BNKNM"), "") '銀行名称
            DB_BNKMTA_W.STNNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("STNNM"), "") '支店名称

            '表示改ページ
            If cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                cnt = 0
                '最終ページ退避
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            '表示メモリ展開
            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)

            cnt = cnt + 1

            If cnt >= WM_WLS_MAX Then
                Exit For
            End If
        Next
        '2019/04/05 CHG E N D

        '最終データ到達
        '2019/05/31 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dsList.Tables("tableName") Is Nothing OrElse dsList.Tables("tableName").Rows.Count <= 0 Then
            '2019/05/31 CHG E N D
            WM_WLS_LastFL = True
        End If

        If cnt > 0 Then
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
	'   名称：  Sub WLS_Clear
	'   概要：  変数初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Clear()
		
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
	'UPGRADE_WARNING: Form イベント WLSBNK2.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSBNK2_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WM_WLS_Dspflg = False
		
		'項目初期化
		LST.Items.Clear()
		WM_WLS_Dspflg = True
		
		ReDim WM_WLS_DSPArray(0)
		
		'初期状態全件表示
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		DblClickFl = False
		
		Me.Refresh()
		' === 20060821 === UPDATE S - ACE)Nagasawa
		'        HD_CODE.SetFocus
		' === 20061228 === INSERT S - ACE)Nagasawa
		On Error Resume Next
		' === 20061228 === INSERT E -
		LST.Focus()
		' === 20060821 === UPDATE E -
	End Sub
	
	Private Sub WLSBNK2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window初期設定
		Call WLS_FORM_INIT()
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSBNKMTA2_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_BNKCDLEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '2019/05/31 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '2019/05/31 CHG E N D
    End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KEYCODE
            'Enterキー押下
            Case System.Windows.Forms.Keys.Return
                '2019/05/31 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '2019/05/31 CHG E N D

                'Escapeキー押下
            Case System.Windows.Forms.Keys.Escape
                '2019/05/31 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '2019/05/31 CHG E N D

                '←キー押下
            Case System.Windows.Forms.Keys.Left
                '2019/05/31 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '2019/05/31 CHG E N D

                '→キー押下
            Case System.Windows.Forms.Keys.Right
                '2019/05/31 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '2019/05/31 CHG E N D
                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '2019/05/31 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '	' === 20060728 === DELETE S - ACE)Furukawa
    '	'    Call WLS_DspNew
    '	' === 20060728 === DELETE E

    '	If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '		' === 20060728 === UPDATE S - ACE)Furukawa
    '		'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
    '		' === 20060728 === UPDATE ↓
    '		If Not WM_WLS_LastFL Then Call WLS_DspNew()
    '		' === 20060728 === UPDATE E
    '	Else
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '		Call WLS_DspPage()
    '	End If
    'End Sub

    'Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSATO.Image = IM_ATO(1).Image
    'End Sub

    'Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSATO.Image = IM_ATO(0).Image
    'End Sub
    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click
        If LST.Items.Count <= 0 Then Exit Sub

        ' === 20060728 === DELETE S - ACE)Furukawa
        '    Call WLS_DspNew
        ' === 20060728 === DELETE E

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            ' === 20060728 === UPDATE S - ACE)Furukawa
            'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
            ' === 20060728 === UPDATE ↓
            '2019/05/31 CHG START
            'If Not WM_WLS_LastFL Then Call WLS_DspNew()
            If Not WM_WLS_LastFL Then Call WLS_DspPage()
            '2019/05/31 CHG E N D
            ' === 20060728 === UPDATE E
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub
    '2019/05/31 CHG E N D

    '2019/05/31 CHG START
    'Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '	If WM_WLS_Pagecnt > 0 Then
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '		Call WLS_DspPage()
    '	End If
    'End Sub

    'Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSMAE.Image = IM_MAE(1).Image
    'End Sub

    'Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSMAE.Image = IM_MAE(0).Image
    'End Sub
    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
        End If
    End Sub
    '2019/05/31 CHG E N D

    '2019/05/31 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	WLSBNKMTA2_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_BNKCDLEN)

    '	Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click

    '	If Dyn_Open = True Then
    '		'クローズ
    '		Call CF_Ora_CloseDyn(Usr_Ody)
    '		Dyn_Open = False
    '	End If

    '	Hide()
    'End Sub
    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        WLSBNKMTA2_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_BNKCDLEN)

        Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        If Dyn_Open = True Then
            'クローズ
            Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If

        Hide()
    End Sub
    '2019/05/31 CHG E N D

End Class