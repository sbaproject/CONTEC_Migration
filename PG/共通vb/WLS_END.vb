Option Strict Off
Option Explicit On
Friend Class WLSEND
	Inherits System.Windows.Forms.Form
	
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　エンドユーザ検索
	'*  プログラムＩＤ　：  WLSEND
	'*  作成者　　　　　：　FWEST)頃安
	'*  作成日　　　　　：  2013.07.19
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
    '20190619 chg start
    'Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_MFIL As Object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    '20190619 chg end
    Private WM_WLS_CODELEN As Short 'エンドユーザコード表示文字数
	Private WM_WLS_NAMELEN As Short 'エンドユーザ名称入力文字数
	
	'ウィンド内部使用変数
	Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_NAME As String 'エンドユーザ検索用
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    'Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	
	Private WM_WLS_ENDUSRCD As String 'エンドユーザコード
	Private WM_WLS_ENDUSRNM As String 'エンドユーザ名称
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_FORM_INIT
	'   概要：  画面初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		
		'=== 表示開始コード桁数設定 ===
		'エンドユーザ対応2 CHG START 富士通)橋本 2018/05/18
		'切り取る文字数を6文字→9文字へ変更
		'WM_WLS_CODELEN = 6
		WM_WLS_CODELEN = 9
		'エンドユーザ対応2 CHG END   富士通)橋本 2018/05/18
		WM_WLS_MAX = 20 '画面表示件数
		'変数初期化
		WLSMEI_RTNMEICDA = ""
		Call WLS_Clear()
		'戻り値設定
		gv_bolEndUsrFlg = False
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_SetArray
	'   概要：  リスト編集
	'   引数：　ArrayCnt : リスト編集対象INDEX
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'CHG STRAT 2018/05/21 エンドユーザ対応2 富士通)橋本
	'Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)
	Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)
		'CHG END   2018/05/21 エンドユーザ対応2 富士通)橋本
		'====================================
		'   WINDOW 明細設定
		'====================================
		
		WM_WLS_DSPArray(ArrayCnt) = WM_WLS_ENDUSRCD & Space(5) & WM_WLS_ENDUSRNM
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
		
		'20171220 CIS)西村　修正　開始　ｴﾝﾄﾞﾕｰｻﾞ対応２
		'        strSQL = ""
		'        strSQL = strSQL & " Select Trim(MEICDA) CODE "       'コード１
		'        strSQL = strSQL & "      , RTrim(MEINMA) || RTrim(MEINMB) || RTrim(MEINMC) NAME"     '名称
		'        strSQL = strSQL & " from   MEIMTA "                  '名称マスタ
		'        strSQL = strSQL & " Where  DATKB = '" & gc_strDATKB_USE & "' "          '伝票削除区分
		'        strSQL = strSQL & " And    KEYCD = '" & gc_strKEYCD_ENDUSRKB & "' "     'キー
		'        strSQL = strSQL & " And    TO_MULTI_BYTE(UPPER(Rtrim(MEINMA)) || UPPER(Rtrim(MEINMB)) || UPPER(Rtrim(MEINMC))) LIKE TO_MULTI_BYTE(UPPER('%" & CF_Ora_String(WM_WLS_NAME, CF_Ctr_AnsiLenB(WM_WLS_NAME)) & "%'))"     '検索表示区分
		'        strSQL = strSQL & " order by "
		'        strSQL = strSQL & "        MEICDA "         'コード１
		strSQL = ""
		strSQL = strSQL & " Select Trim(ENDUSRCD) CODE " 'コード
		strSQL = strSQL & "      , Trim(ENDUSRNM) NAME" '名称
		strSQL = strSQL & " from   ENDMTA " 'ｴﾝﾄﾞﾕｰｻﾞマスタ
        strSQL = strSQL & " Where  DATKB = '" & gc_strDATKB_USE & "' " '伝票削除区分
        '20190517 CHG START
        'strSQL = strSQL & " And    TO_MULTI_BYTE(UPPER(Trim(ENDUSRNM))) LIKE TO_MULTI_BYTE(UPPER('%" & CF_Ora_String(WM_WLS_NAME, CF_Ctr_AnsiLenB(WM_WLS_NAME)) & "%'))" '検索表示区分
        strSQL = strSQL & " And    UPPER(Trim(ENDUSRNM)) LIKE UPPER('%" & CF_Ora_String(WM_WLS_NAME, CF_Ctr_AnsiLenB(WM_WLS_NAME)) & "%')" '検索表示区分
        '20190517 CHG END
        strSQL = strSQL & " order by "
        strSQL = strSQL & "        ENDUSRCD " 'コード
        '20171220 CIS)西村　修正　終了

        'DBアクセス
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        DB_GetTable(strSQL)
		
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
		'CHG START 2018/05/21 エンドユーザ対応2 富士通)橋本
		'Dim Wk_Pagecnt      As Integer
		Dim Wk_Pagecnt As Integer
		'CHG END   2018/05/21 エンドユーザ対応2 富士通)橋本
		'ADD START 2018/05/21 エンドユーザ対応2 富士通)橋本
		Dim wk_Listcnt As Integer '配列の要素数
		Dim wk_Pagecnt1 As Integer
		Dim wk_WM_WLS_MAX As Integer
		Dim wk_Pagecnt_long As Integer
		Dim wk_Cnt_long As Integer
		Dim wk_Setarray As Integer
		wk_Listcnt = 0
		wk_Pagecnt1 = 0
		wk_WM_WLS_MAX = 0
		wk_Pagecnt_long = 0
		wk_Cnt_long = 0
		wk_Setarray = 0
		'ADD END   2018/05/21 エンドユーザ対応2 富士通)橋本
		
		Cnt = 0
        Wk_Pagecnt = -1
        '20190319 CHG START 
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '    '取得内容退避
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    WM_WLS_ENDUSRCD = CF_Ora_GetDyn(Usr_Ody, "CODE", "") 'コード１
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    WM_WLS_ENDUSRNM = CF_Ora_GetDyn(Usr_Ody, "NAME", "") '名称

        '    '表示改ページ
        '    If Cnt Mod WM_WLS_MAX = 0 Then
        '        Wk_Pagecnt = Wk_Pagecnt + 1
        '        '最終ページ退避
        '        WM_WLS_LastPage = Wk_Pagecnt
        '        'CHG START 2018/05/21 エンドユーザ対応2 富士通)橋本
        '        'ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
        '        wk_Pagecnt1 = (Wk_Pagecnt + 1)
        '        wk_WM_WLS_MAX = WM_WLS_MAX
        '        wk_Listcnt = wk_Pagecnt1 * wk_WM_WLS_MAX
        '        ReDim Preserve WM_WLS_DSPArray(wk_Listcnt)
        '        'CHG START 2018/05/21 エンドユーザ対応2 富士通)橋本
        '        Cnt = 0
        '    End If

        '    '表示メモリ展開
        '    'CHG START 2018/05/21 エンドユーザ対応2 富士通)橋本
        '    'Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + Cnt)
        '    wk_Pagecnt_long = Wk_Pagecnt
        '    wk_WM_WLS_MAX = WM_WLS_MAX
        '    wk_Cnt_long = Cnt

        '    wk_Setarray = wk_Pagecnt_long * wk_WM_WLS_MAX + wk_Cnt_long
        '    Call WLS_SetArray(wk_Setarray)
        '    'CHG END   2018/05/21 エンドユーザ対応2 富士通)橋本

        '    Cnt = Cnt + 1

        '    Call CF_Ora_MoveNext(Usr_Ody)
        'Loop
        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1

            WM_WLS_ENDUSRCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("CODE"), "")
            WM_WLS_ENDUSRNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NAME"), "")

            '表示改ページ
            If Cnt Mod WM_WLS_MAX = 0 Then
                Wk_Pagecnt = Wk_Pagecnt + 1
                '最終ページ退避
                WM_WLS_LastPage = Wk_Pagecnt
                'CHG START 2018/05/21 エンドユーザ対応2 富士通)橋本
                'ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
                wk_Pagecnt1 = (Wk_Pagecnt + 1)
                wk_WM_WLS_MAX = WM_WLS_MAX
                wk_Listcnt = wk_Pagecnt1 * wk_WM_WLS_MAX
                ReDim Preserve WM_WLS_DSPArray(wk_Listcnt)
                'CHG START 2018/05/21 エンドユーザ対応2 富士通)橋本
                Cnt = 0
            End If

            '表示メモリ展開
            'CHG START 2018/05/21 エンドユーザ対応2 富士通)橋本
            'Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + Cnt)
            wk_Pagecnt_long = Wk_Pagecnt
            wk_WM_WLS_MAX = WM_WLS_MAX
            wk_Cnt_long = Cnt

            wk_Setarray = wk_Pagecnt_long * wk_WM_WLS_MAX + wk_Cnt_long
            Call WLS_SetArray(wk_Setarray)
            'CHG END   2018/05/21 エンドユーザ対応2 富士通)橋本

            Cnt = Cnt + 1
        Next
        '20190319 CHG END 
		
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
	Sub WLS_Clear()
		
		'検索条件
		WM_WLS_NAME = ""
		
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
	'UPGRADE_WARNING: Form イベント WLSEND.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSEND_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190521 DEL START
        '      'WINDOW 位置設定
        '      Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'WM_WLS_Dspflg = False

        ''項目初期化
        'HD_NAME.Text = ""
        'LST.Items.Clear()
        'WM_WLS_Dspflg = True

        'ReDim WM_WLS_DSPArray(0)

        ''初期状態全件表示
        'Call WLS_TextSQL()
        'Call WLS_DspNew()

        'DblClickFl = False

        'Me.Refresh()
        'On Error Resume Next
        '      LST.Focus()
        '20190521 DEL END

    End Sub
	
	Private Sub WLSEND_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window初期設定
        Call WLS_FORM_INIT()

        '20190521 ADD START
        'WINDOW 位置設定
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        WM_WLS_Dspflg = False

        '項目初期化
        HD_NAME.Text = ""
        LST.Items.Clear()
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)

        '初期状態全件表示
        Call WLS_TextSQL()
        Call WLS_DspNew()

        DblClickFl = False

        Me.Refresh()
        On Error Resume Next
        LST.Focus()
        '20190521 ADD END

    End Sub

    '20190521 ADD START
    Private Sub WLSEND_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.btnF1.PerformClick()

                Case Keys.F2
                    Me.btnF2.PerformClick()

                Case Keys.F7
                    Me.btnF7.PerformClick()

                Case Keys.F8
                    Me.btnF8.PerformClick()

                Case Keys.F9
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub
    '20190521 ADD END

    Private Sub HD_NAME_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NAME.Enter
		HD_NAME.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_NAME.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_NAME.SelectionLength = HD_NAME.Maxlength
	End Sub
	
	Private Sub HD_NAME_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NAME.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_NAME = HD_NAME.Text
			
			'他検索条件クリア
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSMEI_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '20190521 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190521 CHG END

    End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			'Enterキー押下
			Case System.Windows.Forms.Keys.Return
                '20190521 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190521 CHG END

                'Escapeキー押下
            Case System.Windows.Forms.Keys.Escape
                '20190521 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190521 CHG END

                '←キー押下
            Case System.Windows.Forms.Keys.Left
                '20190521 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190521 CHG END

                '→キー押下
            Case System.Windows.Forms.Keys.Right
                '20190521 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190521 CHG END
                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '20190521 CHG START
    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '	If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '		If Not WM_WLS_LastFL Then Call WLS_DspPage()
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

    '   Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '       WLSATO.Image = IM_ATO(0).Image
    '   End Sub

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click

        If LST.Items.Count <= 0 Then Exit Sub

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            If Not WM_WLS_LastFL Then Call WLS_DspPage()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190521 CHG END

    '20190521 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            Call HD_NAME_KeyDown(HD_NAME, New System.Windows.Forms.KeyEventArgs(Keys.Return))

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面検索エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            Me.HD_NAME.Text = ""
            LST.Items.Clear()
            Me.HD_NAME.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    '20190521 ADD END

    '20190521 CHG START
    '   Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
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

    '   Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '       WLSMAE.Image = IM_MAE(0).Image
    '   End Sub

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190521 CHG END

    '20190521 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	WLSMEI_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
    '	Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click

    '	If Dyn_Open = True Then
    '		'クローズ
    '           'Call CF_Ora_CloseDyn(Usr_Ody)
    '		Dyn_Open = False
    '	End If

    '	Hide()
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        WLSMEI_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
        Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click

        If Dyn_Open = True Then
            'クローズ
            'Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If

        Hide()
    End Sub


    '20171220 CIS)西村　削除　開始　ｴﾝﾄﾞﾕｰｻﾞ対応２
    'Private Sub WLSEXECUTE_Click()
    '    gv_bolEndUsrFlg = True
    '
    '    Hide
    'End Sub
    '20171220 CIS)西村　削除　終了
End Class