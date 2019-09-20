Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSTOK3
    Inherits System.Windows.Forms.Form
    '以下の ３行の設定を行うこと
    Const WM_WLS_MSTKB As String = "1" 'マスタ区分（1:得意先 2:納品先 3:担当者 4:仕入先 5:商品 "":分類なし）
    Const WM_WLSKEY_ZOKUSEI As String = "X" '開始コード入力属性 [0,X]
    Const WM_WLS_KanaINPUT As Boolean = False 'カナ直接入力使用（True:直接入力 False:カナコンボ）

    '検索キーNo（使用しない場合は-1を設定）
    Const WM_WLS_TextKey As Short = 1 '開始コードのソートキーNo
    Const WM_WLS_KanaKey As Short = 2 'カナ検索のソートキーNo+第一キー
    Const WM_WLS_RNKey As Short = 3 '得意先略称検索のソートキーNo+第一キー

    'ウィンドﾕｰｻﾞｰ設定変数
    '20190617 chg start
    'Dim WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Dim WM_WLS_MFIL As Object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    '20190617 chg end
    Dim WM_WLS_LEN As Short '開始ｺｰﾄﾞ入力文字数
    Dim WM_WLS_KANALEN As Short 'カナ入力文字数
    Dim WM_WLS_RNLEN As Short '得意先略称入力文字数

    'ウィンド内部使用変数
    Dim WM_WLS_MAX As Short '１画面の表示件数
    Dim WM_WLS_STTKEY As Object '開始キー
    Dim WM_WLS_ENDKEY As Object '終了キー
    Dim WM_WLS_KeyNo As Short 'ﾒｲﾝﾌｧｲﾙ読み込みキーNo
    Dim WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
    Dim WM_WLS_LastPage As Short 'ウィンド最終ページ
    Dim WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
    Dim WM_WLS_DSPArray() As String 'ウィンド表示データ
    Dim WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)

    Dim WlsSelList As String
    Dim WlsHint As String
    Dim WlsOrderBy As String
    Dim WlsFromWhere As String

    Dim DblClickFl As Boolean 'DblClickイベント障害対応  97/04/07

    Private Sub WLS_FORM_INIT()
        '20190603 add start
        Dim Space1 As Object
        Dim Space2 As Object
        Dim Space3 As Object
        Dim Space4 As Object
        '20190602 add end

        '20190621 del start
        ''=== WINDOW 表示ファイル設定 ===
        'WM_WLS_MFIL = DBN_TOKMTA
        '20190621 del end

        '20190603 del start
        '=== 表示開始コード桁数設定 ===
        WM_WLS_LEN = Len(DB_TOKMTA.TOKCD) 'LenWid はダメ
        WM_WLS_KANALEN = Len(DB_TOKMTA.TOKNK) 'LenWid はダメ
        WM_WLS_RNLEN = Len(DB_TOKMTA.TOKRN) 'LenWid はダメ
        WlsSelList = "TOKNMA, TOKNMB, DATKB, TOKZEIKB, TOKSMEKB, TOKSMEDD, TOKKESCC, TOKKESDD, TOKNK, TOKKDWKB, TOKCD, TOKRN, TOKTL, TOKSEICD"
        '20190603 del end

        '=== ＬＡＢＥＬ設定 ===
        'WLSLABEL = "ｺｰﾄﾞ  得意先名                 　　　締  日   　回収条件      税区  　電話番号     請求先"
        '12345 123456789012345678901234567890 1234567890 1234567890123 123456  1234567890123 12345

        'UPGRADE_WARNING: オブジェクト WLSLABEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/03/25 CHG START
        'WLSLABEL = " ｺｰﾄﾞ" & Space(Len(DB_TOKMTA.TOKCD) - Len(" ｺｰﾄﾞ") + 1) & "得意先名" & Space(Len(DB_TOKMTA.TOKRN) - Len("得意先名") - 1) & "締  日" & Space(7 - Len("締  日")) & "回収条件" & Space(10 - Len("回収条件")) & "税区" & Space(3 - Len("税区") + 1) & "電話番号" & Space(Len(DB_TOKMTA.TOKTL) - Len("電話番号") - 9) & "請求先" & Space(Len(DB_TOKMTA.TOKSEICD) - Len("請求先") + 1)
        Space1 = WM_WLS_LEN - Len(" ｺｰﾄﾞ") + 1
        Space1 = Space(IIf(Space1 > 0, Space1, 0))
        Space2 = WM_WLS_RNLEN - Len("得意先名") - 1
        Space2 = Space(IIf(Space2 > 0, Space2, 0))
        Space3 = Len(IIf(IsDBNull(DB_TOKMTA.TOKTL), "", DB_TOKMTA.TOKTL)) - Len("電話番号") - 9
        Space3 = Space(IIf(Space3 > 0, Space3, 0))
        Space4 = Len(IIf(IsDBNull(DB_TOKMTA.TOKSEICD), "", DB_TOKMTA.TOKSEICD)) - Len("請求先") + 1
        Space4 = Space(IIf(Space4 > 0, Space4, 0))
        WLSLABEL.Text = " ｺｰﾄﾞ" & Space1 & "得意先名" & Space2 & "締  日" & Space(7 - Len("締  日")) & "回収条件" & Space(10 - Len("回収条件")) & "税区" & Space(3 - Len("税区") + 1) & "電話番号" & Space3 & "請求先" & Space4
        '2019/03/25 CHG E N D
        WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
        'HD_TEXT.Height = 330
        'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        HD_TEXT.MaxLength = WM_WLS_LEN
        HD_TEXT.Width = VB6.TwipsToPixelsX((WM_WLS_LEN + 1) * 120)

    End Sub

    Private Function WLS_DSP_CHECK() As Object
        If DB_TOKMTA.DATKB = "9" Then
            'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WLS_DSP_CHECK = SSS_NEXT
        Else
            'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WLS_DSP_CHECK = SSS_OK
        End If
    End Function

    Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
        '====================================
        '   WINDOW 明細設定
        '====================================

        Dim WK_ZEINM, WK_KESNM, WK_SMENM As String
        Dim WK_TK As New VB6.FixedLengthString(13)
        Dim WK_KESDD As String
        '
        Select Case SSSVal(DB_TOKMTA.TOKZEIKB)
            Case 1
                WK_ZEINM = " 税抜 "
            Case 2
                WK_ZEINM = " 税込 "
            Case 9
                WK_ZEINM = "非課税"
        End Select
        '
        Select Case SSSVal(DB_TOKMTA.TOKSMEKB)
            Case 1
                WK_SMENM = "  " & DB_TOKMTA.TOKSMEDD & "日締 "
                Select Case SSSVal(DB_TOKMTA.TOKKESCC)
                    Case 0
                        WK_KESNM = "  当月"
                    Case 1
                        WK_KESNM = "  翌月"
                    Case 2
                        WK_KESNM = "翌々月"
                    Case Else
                        WK_KESNM = "その他"
                End Select
                WK_KESNM = WK_KESNM & DB_TOKMTA.TOKKESDD & "日回収"
            Case 2
                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMTA.TOKSDWKB)) & "締     " & SSS_WEEKNM(SSSVal(DB_TOKMTA.TOKKDWKB)) & "回収"
        End Select
        '
        WM_WLS_DSPArray(ArrayCnt) = DB_TOKMTA.TOKCD & " " & LeftWid(DB_TOKMTA.TOKRN, Len(DB_TOKMTA.TOKRN)) & " " & WK_SMENM & WK_KESNM & " " & WK_ZEINM & " " & LeftWid(DB_TOKMTA.TOKTL, 13) & "  " & VB6.Format(Trim(DB_TOKMTA.TOKSEICD), "!@@@@@")
    End Sub

    Sub WLS_TextSQL()
        WM_WLS_KeyNo = WM_WLS_TextKey
        ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
        '    WlsFromWhere = "From TOKMTA Where TOKCD >= '" & WM_WLS_STTKEY & "'"
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        WlsFromWhere = "From TOKMTA Where TOKCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
        '''' UPD 2009/12/03  FKS) T.Yamamoto    End
        If SSS_PrgId = "SSZET62" Or SSS_PrgId = "SSZET63" Then
            WlsFromWhere = WlsFromWhere & "          AND FRNKB = '1'"
        End If
        WlsOrderBy = "Order By TOKCD"
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)

    End Sub

    Sub WLS_KanaSQL()
        WM_WLS_KeyNo = WM_WLS_KanaKey
        ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WlsFromWhere = "From TOKMTA Where TOKNK >= '" & WM_WLS_STTKEY & "' And TOKNK < '" & WM_WLS_ENDKEY & "'"
        If SSS_PrgId = "SSZET62" Or SSS_PrgId = "SSZET63" Then
            WlsFromWhere = WlsFromWhere & "          AND FRNKB = '1'"
        End If
        WlsOrderBy = "Order By TOKNK, TOKCD"
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)

    End Sub

    Sub WLS_RnSQL()
        WM_WLS_KeyNo = WM_WLS_RNKey
        ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        'WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & WM_WLS_STTKEY & "%'"
        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
        '    WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & WM_WLS_STTKEY & "%' Or TOKNK Like " & " '%" & WM_WLS_STTKEY & "%'"
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%' Or TOKNK Like " & " '%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'"
        '''' UPD 2009/12/03  FKS) T.Yamamoto    End
        If SSS_PrgId = "SSZET62" Or SSS_PrgId = "SSZET63" Then
            WlsFromWhere = WlsFromWhere & "          AND FRNKB = '1'"
        End If
        WlsOrderBy = "Order By TOKRN,TOKNK, TOKCD"
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)

    End Sub

    Private Sub WLS_DspNew()
        Dim WL_Mode As Short
        Dim cnt As Short

        WL_Mode = 0
        cnt = 0

        Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
            'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WL_Mode = WLS_DSP_CHECK()
            If WL_Mode = SSS_OK Then
                If cnt = 0 Then
                    WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                    WM_WLS_LastPage = WM_WLS_Pagecnt
                    ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                End If
                Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
                cnt = cnt + 1
            End If
            If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)

            End If
        Loop
        If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
        If cnt > 0 Then
            Call WLS_DspPage()
        Else
            LST.Items.Clear()
        End If
    End Sub

    Private Sub WLS_DspPage()
        Dim WL_Mode As Short
        Dim cnt As Short

        LST.Items.Clear()
        cnt = 0
        Do While cnt < WM_WLS_MAX
            If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)) > "" Then
                LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt))
            End If
            cnt = cnt + 1
        Loop
        If LST.Items.Count > 0 Then
            LST.SelectedIndex = 0
            LST.Focus()
        End If
    End Sub

    Sub WLS_Kana_Init()

        'カナ検索 Combo 初期化
        'この一行を実行しないと, WLSKANA.ListIndex = 0 でエラーになる
        WLSKANA.Items.Add("コード")

        If WM_WLS_KanaKey < 1 Then
            'カナ検索をしない
            'UPGRADE_WARNING: オブジェクト PNL_USENM().Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            PNL_USENM(3).Visible = False
            WLSKANA.Visible = False
            HD_Kana.Visible = False
        ElseIf WM_WLS_KanaINPUT Then
            'カナ手入力項目の有効化
            WLSKANA.Visible = False
            HD_Kana.Visible = True
            HD_Kana.Width = WLSKANA.Width
            HD_Kana.Left = WLSKANA.Left
        Else
            WLSKANA.Items.Add("ア　      ｱｵ")
            WLSKANA.Items.Add("カ　      ｶｺ")
            WLSKANA.Items.Add("サ　      ｻｿ")
            WLSKANA.Items.Add("タ　      ﾀﾄ")
            WLSKANA.Items.Add("ナ　      ﾅﾉ")
            WLSKANA.Items.Add("ハ　      ﾊﾎ")
            WLSKANA.Items.Add("マ　      ﾏﾓ")
            WLSKANA.Items.Add("ヤ　      ﾔﾖ")
            WLSKANA.Items.Add("ラ　      ﾗﾛ")
            WLSKANA.Items.Add("ワ　      ﾜﾝ")
        End If
    End Sub

    '
    '以下は画面イベント処理
    '
    'UPGRADE_WARNING: Form イベント WLSTOK.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    '20190603 del start
    'Private Sub WLSTOK_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

    '    '=== WINDOW 位置設定 ===
    '    Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
    '    Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

    '    'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    WM_WLS_STTKEY = ""
    '    'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    WM_WLS_ENDKEY = System.DBNull.Value
    '    HD_TEXT.Text = ""
    '    WM_WLS_Dspflg = False
    '    WLSKANA.SelectedIndex = 0
    '    HD_Kana.Text = ""
    '    'WLSRN.ListIndex = 0
    '    HD_RN.Text = ""
    '    WM_WLS_Dspflg = True
    '    WM_WLS_Pagecnt = -1
    '    WM_WLS_LastPage = -1
    '    WM_WLS_LastFL = False
    '    ReDim WM_WLS_DSPArray(0)

    '    Call WLS_TextSQL()
    '    Call WLS_DspNew()

    '    'DblClickイベント障害対応  97/04/07
    '    DblClickFl = False
    'End Sub
    '20190603 del end

    Private Sub WLSTOK_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '20190603 add start
        '=== WINDOW 表示ファイル設定 ===
        WM_WLS_MFIL = DBN_TOKMTA

        '=== WINDOW 位置設定 ===
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        WM_WLS_STTKEY = ""
        WM_WLS_ENDKEY = System.DBNull.Value
        HD_TEXT.Text = ""
        WM_WLS_Dspflg = False
        HD_Kana.Text = ""
        HD_RN.Text = ""
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        '=== 表示開始コード桁数設定 ===
        WlsSelList = "TOKNMA, TOKNMB, DATKB, TOKZEIKB, TOKSMEKB, TOKSMEDD, TOKKESCC, TOKKESDD, TOKNK, TOKKDWKB, TOKCD, TOKRN, TOKTL, TOKSEICD"

        Call WLS_TextSQL()
        Call WLS_DspNew()

        DblClickFl = False
        WM_WLS_LEN = Len(DB_TOKMTA.TOKCD)
        WM_WLS_KANALEN = Len(DB_TOKMTA.TOKNK)
        WM_WLS_RNLEN = Len(DB_TOKMTA.TOKRN)
        '20190603 add end

        'Window初期設定
        Call WLS_FORM_INIT()
        Call WLS_Kana_Init()

        '20190603 add start
        WLSKANA.SelectedIndex = 0
        '20190603 add end
    End Sub

    Private Sub HD_RN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_RN.Enter
        '''    If LenWid(HD_RN.Text) > 0 Then
        '''        HD_RN.Text = SSS_EDTITM_WLS(HD_RN.Text, HD_RN.MaxLength, WM_WLSKEY_ZOKUSEI)
        '''    Else
        '''        HD_RN.Text = Space$(HD_RN.MaxLength)
        '''    End If
        HD_RN.SelectionStart = 0
        'UPGRADE_WARNING: TextBox プロパティ HD_RN.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        HD_RN.SelectionLength = HD_RN.MaxLength
    End Sub

    Private Sub HD_Rn_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_RN.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            HD_TEXT.Text = ""
            'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_STTKEY = HD_RN.Text
            'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_ENDKEY = HD_RN.Text
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            WM_WLS_LastPage = -1
            WM_WLS_LastFL = False
            ReDim WM_WLS_DSPArray(0)

            Call WLS_RnSQL()
            Call WLS_DspNew()
        End If
    End Sub

    Private Sub HD_Kana_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_Kana.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            HD_TEXT.Text = ""
            'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_STTKEY = HD_Kana.Text
            'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_ENDKEY = Chr(Asc("ﾝ") + 1)
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            WM_WLS_LastPage = -1
            WM_WLS_LastFL = False
            ReDim WM_WLS_DSPArray(0)

            Call WLS_KanaSQL()
            Call WLS_DspNew()
        End If
    End Sub

    Private Sub HD_Kana_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_Kana.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii < Asc(" ") Then GoTo EventExitSub
        ''2000/04/18 カナ入力文字範囲の誤りを修正
        ''If KeyAscii < Asc("ｱ") Or KeyAscii > Asc("ﾝ") Then
        If KeyAscii >= Asc("0") And KeyAscii <= Asc("9") Then GoTo EventExitSub
        If KeyAscii < Asc("｡") Or KeyAscii > Asc("ﾟ") Then
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
        '''    If LenWid(HD_TEXT.Text) > 0 Then
        '''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
        '''    Else
        '''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
        '''    End If
        HD_TEXT.SelectionStart = 0
        'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        HD_TEXT.SelectionLength = HD_TEXT.MaxLength
    End Sub

    Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
            HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
            'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_STTKEY = HD_TEXT.Text
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_ENDKEY = System.DBNull.Value
            WLSKANA.SelectedIndex = 0
            HD_Kana.Text = ""
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            WM_WLS_LastPage = -1
            WM_WLS_LastFL = False
            ReDim WM_WLS_DSPArray(0)

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If
    End Sub

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
        'DblClickイベント障害対応  97/04/07
        DblClickFl = True
        Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
    End Sub

    Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'UnLoadイベント障害対応  97/04/07
        '20190606 chg start
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190606 chg end
    End Sub

    Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KEYCODE
            Case System.Windows.Forms.Keys.Return
                '20190606 chg start
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190606 chg end
            Case System.Windows.Forms.Keys.Escape
                '20190606 chg start
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190606 chg end
            Case System.Windows.Forms.Keys.Left '←キー
                '20190606 chg start
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190606 chg end
            Case System.Windows.Forms.Keys.Right '→キー
                '20190606 chg start
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190606 chg end
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
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        If WLSKANA.SelectedIndex > 0 Then
            HD_TEXT.Text = ""
            HD_RN.Text = ""
            'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
            'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_STTKEY = VB.Left(W_BUF, 1)
            'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_ENDKEY = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
            Call WLS_KanaSQL()
        Else
            If HD_RN.Text <> "" Then
                'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WM_WLS_STTKEY = VB6.Format(HD_RN.Text)
                Call WLS_RnSQL()
            Else
                'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WM_WLS_STTKEY = VB6.Format(HD_TEXT.Text)
                Call WLS_TextSQL()
            End If
        End If
        Call WLS_DspNew()
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

    '20190606 del start
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '    If LST.Items.Count <= 0 Then Exit Sub

    '    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '        If Not WM_WLS_LastFL Then Call WLS_DspNew()
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

    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '    Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
    '    Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '    'UnLoadイベント障害対応  97/04/07
    '    'Unload Me
    '    Hide()
    'End Sub
    '20190606 del end

    '20190606 add start
    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
        Call btnF12_Click(WLSCANCEL, New System.EventArgs())
    End Sub

    Private Sub btnF2_Click(sender As Object, e As EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_RN.Focused Then
                Call HD_Rn_KeyDown(HD_RN, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_TEXT_KeyDown(HD_TEXT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面検索エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub

    Private Sub btnF7_Click(sender As Object, e As EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
        End If
    End Sub

    Private Sub btnF8_Click(sender As Object, e As EventArgs) Handles btnF8.Click
        If LST.Items.Count <= 0 Then Exit Sub

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            'Window初期設定
            Call WLS_FORM_INIT()
            Call WLS_Kana_Init()

            Me.HD_TEXT.Text = ""
            Me.HD_RN.Text = ""
            LST.Items.Clear()
            Me.HD_TEXT.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Hide()
    End Sub

    Private Sub WLS_TOK3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    '20190606 add end

End Class