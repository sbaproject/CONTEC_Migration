Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSNHS1
    Inherits System.Windows.Forms.Form
    '********************************************************************************
    '*  システム名　　　：  新総合情報システム
    '*  サブシステム名　：　販売システム
    '*  機能　　　　　　：　検索ウィンドウ
    '*  プログラム名　　：　納入先検索
    '*  プログラムＩＤ　：  WLSNHS
    '*  作成者　　　　　：　ACE)高橋
    '*  作成日　　　　　：  2006.05.15
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
    '20190619 chg start
    'Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_MFIL As Object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    '20190619 chg end
    Private WM_WLS_CODELEN As Short '開始ｺｰﾄﾞ入力文字数
    Private WM_WLS_NAMELEN As Short '納入先名略入力文字数

    'ウィンド内部使用変数
    Private WM_WLS_MAX As Short '１画面の表示件数
    Private WM_WLS_CODE As String '納入先コード検索用
    Private WM_WLS_NHSNK As String '納入先名略称検索用
    Private WM_WLS_NHSNK_S As String '納入先名称カナ検索用(開始)
    Private WM_WLS_NHSNK_E As String '納入先名称カナ検索用(終了)
    Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
    Private WM_WLS_LastPage As Short 'ウィンド最終ページ
    Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
    Private WM_WLS_DSPArray() As String 'ウィンド表示データ
    Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)

    Private DblClickFl As Boolean

    'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    'Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    Private DB_NHSMTAT_W As TYPE_DB_NHSMTA '検索結果退避
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
        WM_WLS_CODELEN = 9
        WM_WLS_NAMELEN = 40
        WM_WLS_MAX = 15 '画面表示件数
        '変数初期化
        WLSNHSMTA_RTNCODE = ""
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
        WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_NHSMTAT_W.NHSCD, WM_WLS_CODELEN) & Space(6) & LeftWid(DB_NHSMTAT_W.NHSRN, WM_WLS_NAMELEN) & Space(2) & DB_NHSMTAT_W.NHSTL

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
        strSQL = strSQL & " Select NHSCD " '納入先コード
        strSQL = strSQL & "      , NHSRN " '納入先略称
        strSQL = strSQL & "      , NHSTL " '納入先郵便番号
        strSQL = strSQL & "   from NHSMTA "
        ' === 20060814 === UPDATE S - ACE)Nagasawa
        '        strSQL = strSQL & "  Where DATKB = '1' "
        strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "
        ' === 20060814 === UPDATE E -

        '納入先コード検索
        If Trim(WM_WLS_CODE) <> "" Then
            ' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
            '            strSQL = strSQL & "    and NHSCD >=   '" & WM_WLS_CODE & "'"
            strSQL = strSQL & "    and NHSCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
            ' === 20080929 === UPDATE E -
        End If

        '納入先略称検索(あいまい検索)
        If Trim(WM_WLS_NHSNK) <> "" Then
            ' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
            '            strSQL = strSQL & "    and NHSRN LIKE '%" & WM_WLS_NHSNK & "%'"
            strSQL = strSQL & "    and NHSRN LIKE '%" & CF_Ora_String(WM_WLS_NHSNK, CF_Ctr_AnsiLenB(WM_WLS_NHSNK)) & "%'"
            ' === 20080929 === UPDATE E -
        End If

        '納入先名称カナ検索
        If Trim(WM_WLS_NHSNK_S) <> "" Then
            strSQL = strSQL & "    and NHSNK >= '" & WM_WLS_NHSNK_S & "' And NHSNK < '" & WM_WLS_NHSNK_E & "'"
        End If

        'ソート条件
        strSQL = strSQL & "   order by "
        If Trim(WM_WLS_NHSNK_S) <> "" Then
            '納入先名称カナ検索の場合
            strSQL = strSQL & "   NHSRN "
            strSQL = strSQL & "  ,NHSCD "
        Else
            '納入先コード検索,納入先略称検索
            strSQL = strSQL & "   NHSCD "
        End If

        If Dyn_Open = True Then
            'クローズ
            'Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If

        '20190319 CHG START
        ''DBアクセス
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        'dsList.Tables("tableName").Clear()
        DB_GetTable(strSQL)
        '20190319 CHG END

        Dyn_Open = True
        ' === 20060728 === INSERT S - ACE)Furukawa
        LST.Items.Clear()
        ' === 20060728 === INSERT E

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

        '20190319 CHG START 
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '	'取得内容退避
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_NHSMTAT_W.NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '納入先コード
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_NHSMTAT_W.NHSRN = CF_Ora_GetDyn(Usr_Ody, "NHSRN", "") '納入先略称
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_NHSMTAT_W.NHSTL = CF_Ora_GetDyn(Usr_Ody, "NHSTL", "") '納入先郵便番号

        '	'表示改ページ
        '	If Cnt Mod WM_WLS_MAX = 0 Then
        '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '		ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '		Cnt = 0
        '		'最終ページ退避
        '		WM_WLS_LastPage = WM_WLS_Pagecnt
        '	End If

        '	'表示メモリ展開
        '	Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

        '	Cnt = Cnt + 1

        '	Call CF_Ora_MoveNext(Usr_Ody)

        '	If Cnt >= WM_WLS_MAX Then
        '		Exit Do
        '	End If
        'Loop 

        ''最終データ到達
        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	WM_WLS_LastFL = True
        '      End If
        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1
            '取得内容退避
            DB_NHSMTAT_W.NHSCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSCD"), "") '納入先コード
            DB_NHSMTAT_W.NHSRN = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSRN"), "") '納入先略称
            DB_NHSMTAT_W.NHSTL = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSTL"), "") '納入先郵便番号

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

            'If Cnt >= WM_WLS_MAX Then
            '    Exit For
            'End If
        Next
        '20190319 CHG END 

        If Cnt > 0 Then
            'ページを表示
            WM_WLS_Pagecnt = 0
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
        WM_WLS_NHSNK = ""
        WM_WLS_NHSNK_S = ""
        WM_WLS_NHSNK_E = ""

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
    'UPGRADE_WARNING: Form イベント WLSNHS.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    Private Sub WLSNHS_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190517 DEL START
        ''WINDOW 位置設定
        'Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'WM_WLS_Dspflg = False

        ''項目初期化
        'Call WLS_Kana_Init()
        'HD_CODE.Text = ""
        'HD_NAME.Text = ""
        'WLSKANA.SelectedIndex = 0
        'LST.Items.Clear()
        'WM_WLS_Dspflg = True

        'ReDim WM_WLS_DSPArray(0)

        ''初期状態全件表示
        'Call WLS_TextSQL()
        'Call WLS_DspNew()

        'DblClickFl = False

        'Me.Refresh()
        '' === 20060821 === UPDATE S - ACE)Nagasawa
        ''        HD_CODE.SetFocus
        '' === 20061228 === INSERT S - ACE)Nagasawa
        'On Error Resume Next
        '' === 20061228 === INSERT E -
        'LST.Focus()
        '' === 20060821 === UPDATE E -
        '20190517 DEL END

    End Sub

    Private Sub WLSNHS_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window初期設定
        Call WLS_FORM_INIT()

        '20190517 ADD START
        'WINDOW 位置設定
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        WM_WLS_Dspflg = False

        '項目初期化
        Call WLS_Kana_Init()
        HD_CODE.Text = ""
        HD_NAME.Text = ""
        WLSKANA.SelectedIndex = 0
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
        '20190517 ADD END

    End Sub

    '20190529 ADD START
    Private Sub WLSNHS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190529 ADD END

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
            WLSKANA.SelectedIndex = 0
            HD_NAME.Text = ""
            WM_WLS_Dspflg = True

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If
    End Sub

    ' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
    Private Sub HD_CODE_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_CODE.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        KeyAscii = Asc(UCase(Chr(KeyAscii)))

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    ' === 20070206 === UPDATE E -

    Private Sub HD_NAME_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NAME.Enter
        '---------- 20061019 ACE MENTE START ----------
        '   If LenWid(HD_NAME.Text) <= 0 Then
        '       HD_NAME.Text = Space$(HD_NAME.MaxLength)
        '   End If
        '---------- 20061019 ACE MENTE E N D ----------
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
            WM_WLS_NHSNK = HD_NAME.Text

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
        WLSNHSMTA_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)

    End Sub

    Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '20190529 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190529 CHG END

    End Sub

    Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            'Enterキー押下
            Case System.Windows.Forms.Keys.Return
                '20190529 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190529 CHG END

                'Escapeキー押下
            Case System.Windows.Forms.Keys.Escape
                '20190529 CHG START
                'WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190529 CHG END

                '←キー押下
            Case System.Windows.Forms.Keys.Left
                '20190529 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190529 CHG END

                '→キー押下
            Case System.Windows.Forms.Keys.Right
                '20190529 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190529 CHG END

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
            WM_WLS_NHSNK_S = VB.Left(W_BUF, 1)
            'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_NHSNK_E = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
            '他検索条件クリア
            HD_CODE.Text = ""
            HD_NAME.Text = ""

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If

    End Sub

    Private Sub WLSKANA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKANA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = True
            Call WLSKANA_SelectedIndexChanged(WLSKANA, New System.EventArgs())
        Else
            WM_WLS_Dspflg = False
        End If
    End Sub

    '20190529 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '    If LST.Items.Count <= 0 Then Exit Sub

    '    ' === 20060728 === DELETE S - ACE)Furukawa
    '    '    Call WLS_DspNew
    '    ' === 20060728 === DELETE E

    '    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '        ' === 20060728 === UPDATE S - ACE)Furukawa
    '        'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
    '        ' === 20060728 === UPDATE ↓
    '        If Not WM_WLS_LastFL Then Call WLS_DspNew()
    '        ' === 20060728 === UPDATE E
    '    Else
    '        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '        Call WLS_DspPage()
    '    End If
    'End Sub

    'Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSATO.Image = IM_ATO(1).Image
    'End Sub

    'Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSATO.Image = IM_ATO(0).Image
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
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
            ' === 20060728 === UPDATE E
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190529 CHG END

    '20190521 ADD START
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
    '20190521 ADD END

    '20190529 CHG START
    'Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '    If WM_WLS_Pagecnt > 0 Then
    '        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '        Call WLS_DspPage()
    '    End If
    'End Sub

    'Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSMAE.Image = IM_MAE(1).Image
    'End Sub

    'Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSMAE.Image = IM_MAE(0).Image
    'End Sub

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190529 CHG END

    '20190529 CHG START
    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '    WLSNHSMTA_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
    '    Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click

    '    If Dyn_Open = True Then
    '        'クローズ
    '        'Call CF_Ora_CloseDyn(Usr_Ody)
    '        Dyn_Open = False
    '    End If

    '    Hide()
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        WLSNHSMTA_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
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
    '20190529 CHG END

End Class