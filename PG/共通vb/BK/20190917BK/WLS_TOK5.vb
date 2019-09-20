Option Strict Off
Option Explicit On
Friend Class WLSTOK5
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　請求先検索
	'*  プログラムＩＤ　：  WLSTOK5
	'*  作成者　　　　　：　RISE)宮島
	'*  作成日　　　　　：  2008.08.26
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
	
	' === 20060730 === UPDATE S - ACE)Nagasawa
	'    Private Const WM_WLSKEY_ZOKUSEI = "0"       '開始コード入力属性 [0,X]
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '開始コード入力属性 [0,X]
    ' === 20060730 === UPDATE E -

    '************************************************************************************
    '   Private変数
    '************************************************************************************

    'ウィンドﾕｰｻﾞｰ設定変数
    '20190619 CHG START
    'Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_MFIL As Object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    '20190619 CHG END
    Private WM_WLS_CODELEN As Short '開始ｺｰﾄﾞ入力文字数
	Private WM_WLS_NAMELEN As Short '得意先略称入力文字数
	
	Private WM_WLS_TOKSEICDLEN As Short '請求先コード　ListBox桁
	Private WM_WLS_TOKNMALEN As Short '得意先名称１  ListBox桁
	Private WM_WLS_TOKCDLEN As Short '得意先コード  ListBox桁
	Private WM_WLS_TOKRNLEN As Short '得意先略称    ListBox桁
	
	'ウィンド内部使用変数
	Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_CODE As String '得意先コード検索用
	Private WM_WLS_TOKRN As String '得意先略称検索用
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private DB_TOKMAT_W As TYPE_DB_TOKMTA '検索結果退避
	Private bolInitWindow As Boolean '画面初期化フラグ(True:初期化)
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_FORM_INIT
	'   概要：  画面初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		
		'=== 表示開始コード桁数設定 ===
		WM_WLS_CODELEN = 5
		WM_WLS_MAX = 15 '画面表示件数
		WM_WLS_TOKSEICDLEN = 10 '請求先コード　ListBox桁
		WM_WLS_TOKNMALEN = 40 '得意先名称１  ListBox桁
		WM_WLS_TOKCDLEN = 10 '得意先コード  ListBox桁
		WM_WLS_TOKRNLEN = 40 '得意先略称    ListBox桁
		'変数初期化
		WLSTOK_RTNCODE = ""
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
		'====================================
		'   WINDOW 明細設定
		'====================================
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_TOKMAT_W.TOKSEICD, WM_WLS_TOKSEICDLEN) & Space(6) & LeftWid(DB_TOKMAT_W.TOKNMA, WM_WLS_TOKNMALEN) & Space(6) & LeftWid(DB_TOKMAT_W.TOKCD, WM_WLS_TOKCDLEN) & Space(2) & LeftWid(DB_TOKMAT_W.TOKRN, WM_WLS_TOKRNLEN)
		
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
		strSQL = strSQL & " Select TOKSEICD " '請求先コード
		strSQL = strSQL & "      , TOKNMA " '得意先名称１
		strSQL = strSQL & "      , TOKCD " '得意先コード
		strSQL = strSQL & "      , TOKRN " '得意先略称
		strSQL = strSQL & "   from TOKMTA "
		strSQL = strSQL & "  Where TOKSEICD = TOKCD "
		
		'得意先コード検索
		If Trim(WM_WLS_CODE) <> "" Then
			strSQL = strSQL & "    and TOKCD >=   '" & WM_WLS_CODE & "'"
		End If
		
		'得意先略称検索(あいまい検索)
		If Trim(WM_WLS_TOKRN) <> "" Then
			strSQL = strSQL & "    and ( TOKRN LIKE '%" & WM_WLS_TOKRN & "%'"
			strSQL = strSQL & "       or TOKNK LIKE '%" & WM_WLS_TOKRN & "%' )"
		End If
		
		'ソート条件
		strSQL = strSQL & "   order by "
		strSQL = strSQL & "   TOKCD "
		strSQL = strSQL & "  ,TOKSEICD "
		
        'DBアクセス
        '2019/04/02 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/02 CHG E N D

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
		Dim Wk_Pagecnt As Short
		
		cnt = 0
        Wk_Pagecnt = -1

        '2019/04/05 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '	'取得内容退避
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_TOKMAT_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "") '請求先コード
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_TOKMAT_W.TOKNMA = CF_Ora_GetDyn(Usr_Ody, "TOKNMA", "") '得意先名称１
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_TOKMAT_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '得意先コード
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_TOKMAT_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '得意先略称

        '	'表示改ページ
        '	If cnt Mod WM_WLS_MAX = 0 Then
        '		Wk_Pagecnt = Wk_Pagecnt + 1
        '		'最終ページ退避
        '		WM_WLS_LastPage = Wk_Pagecnt
        '		ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
        '		cnt = 0
        '	End If

        '	'表示メモリ展開
        '	Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + cnt)

        '	cnt = cnt + 1

        '	Call CF_Ora_MoveNext(Usr_Ody)
        'Loop 
        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1
            '取得内容退避
            DB_TOKMAT_W.TOKSEICD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKSEICD"), "") '請求先コード
            DB_TOKMAT_W.TOKNMA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKNMA"), "") '得意先名称１
            DB_TOKMAT_W.TOKCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKCD"), "") '得意先コード
            DB_TOKMAT_W.TOKRN = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKRN"), "") '得意先略称


            'DB_TOKMAT_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "") '請求先コード
            'DB_TOKMAT_W.TOKNMA = CF_Ora_GetDyn(Usr_Ody, "TOKNMA", "") '得意先名称１
            'DB_TOKMAT_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '得意先コード
            'DB_TOKMAT_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '得意先略称

            '表示改ページ
            If cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                cnt = 0
                '最終ページ退避
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)

            cnt = cnt + 1

            'If cnt >= WM_WLS_MAX Then
            '    Exit For
            'End If
        Next
        '2019/04/05 CHG E N D

		'取得データ有無に関わらず最終データ到達
		WM_WLS_LastFL = True
		
		If cnt > 0 Then
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
		WM_WLS_CODE = ""
		WM_WLS_TOKRN = ""
		
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
	'UPGRADE_WARNING: Form イベント WLSTOK5.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSTOK5_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190626 DEL START
        '      If bolInitWindow = False Then
        '	Exit Sub
        'Else
        '	bolInitWindow = False
        'End If

        ''WINDOW 位置設定
        'Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'WM_WLS_Dspflg = False

        ''項目初期化
        'HD_CODE.Text = ""
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
        '20190626 DEL START

    End Sub

    Private Sub WLSTOK5_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window初期設定
        Call WLS_FORM_INIT()

        bolInitWindow = True

        '20190626 ADD START
        If bolInitWindow = False Then
            Exit Sub
        Else
            bolInitWindow = False
        End If

        'WINDOW 位置設定
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        WM_WLS_Dspflg = False

        '項目初期化
        HD_CODE.Text = ""
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
        '20190626 ADD END

    End Sub


    '20190626 ADD START
    Private Sub WLSTOK5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190626 ADD END


    Private Sub HD_CODE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CODE.Enter
		'UPGRADE_WARNING: オブジェクト LenWid(HD_CODE.Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(HD_CODE.Text) > 0 Then
			'UPGRADE_WARNING: TextBox プロパティ HD_CODE.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
		End If
		HD_CODE.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_CODE.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_CODE.SelectionLength = HD_CODE.Maxlength
	End Sub
	
	Private Sub HD_CODE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_CODE.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox プロパティ HD_CODE.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_CODE = HD_CODE.Text
			
			'他検索条件クリア
			HD_NAME.Text = ""
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
			WM_WLS_TOKRN = HD_NAME.Text
			
			'他検索条件クリア
			HD_CODE.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '20190626 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190626 CHG END

    End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			'Enterキー押下
			Case System.Windows.Forms.Keys.Return
                '20190626 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190626 CHG END

                'Escapeキー押下
            Case System.Windows.Forms.Keys.Escape
                '20190626 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190626 CHG END

                '←キー押下
            Case System.Windows.Forms.Keys.Left
                '20190626 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190626 CHG END

                '→キー押下
            Case System.Windows.Forms.Keys.Right
                '20190626 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190626 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub


    '20190626 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '       If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '           If Not WM_WLS_LastFL Then Call WLS_DspPage()
    '       Else
    '           WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
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
    '20190626 CHG END


    '20190626 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_NAME.Focused Then
                Call HD_NAME_KeyDown(HD_NAME, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_CODE_KeyDown(HD_CODE, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面検索エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            Me.HD_CODE.Text = ""
            Me.HD_NAME.Text = ""
            LST.Items.Clear()
            Me.HD_CODE.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    '20190626 ADD END


    '20190626 CHG START
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
    '20190626 CHG END

    '20190626 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
    '	Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '       Hide()
    '   End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
        Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        Hide()
    End Sub
    '20190626 CHG END


    Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
		
		On Error Resume Next
		
		Me.HD_CODE.Focus()
		
		System.Windows.Forms.Application.DoEvents()
		
		WLSTOK6.ShowDialog()
		WLSTOK6.Close()
		
		'UPGRADE_NOTE: オブジェクト WLSTOK6 をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		WLSTOK6 = Nothing
		
		If Trim(WLSTOK_RTNCODE) <> "" Then
			'商品区分編集
			HD_CODE.Text = Trim(WLSTOK_RTNCODE)
			
			Call HD_CODE_KeyDown(HD_CODE, New System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Return Or 0 * &H10000))
			
		End If
		
	End Sub
End Class