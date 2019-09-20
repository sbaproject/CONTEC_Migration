Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSJDN1
    Inherits System.Windows.Forms.Form
    '以下の４行の設定を行うこと
    Const WM_WLS_MSTKB As String = "1" 'マスタ区分(1:得意先 2:納品先 3:担当者 4:仕入先 5:商品)
    Const WM_WLSKEY_ZOKUSEI As String = "0" '開始コード入力属性 [0,X]

    '検索キーNo（使用しない場合は-1を設定）
    Const WM_WLS_TextKey As Short = 2 '開始コードのソートキーNo
    Const WM_WLS_CDKey As Short = -1 'カナ検索のソートキーNo+第一キー

    'ウィンドﾕｰｻﾞｰ設定変数
    '20190619 chg start
    'Dim WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    'Dim WM_WLS_SFIL As Short 'ウィンド表示ｻﾌﾞﾌｧｲﾙ
    Dim WM_WLS_MFIL As Object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Dim WM_WLS_SFIL As Object 'ウィンド表示ｻﾌﾞﾌｧｲﾙ
    '20190619 chg end

    Dim WM_WLS_LEN As Short '開始ｺｰﾄﾞ入力文字数

    'ウィンド内部使用変数
    Dim WM_WLS_MAX As Short '１画面の表示件数
    Dim WM_WLS_STTKEY As Object '開始キー
    Dim WM_WLS_ENDKEY As Object '終了キー
    Dim WM_WLS_KeyCode As Short 'ｺﾝﾎﾞﾎﾞｯｸｽ表示用
    Dim WM_WLS_KeyNo As Short 'ﾒｲﾝﾌｧｲﾙ読み込みキーNo
    Dim WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
    Dim WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
    Dim WM_WLS_INIT As Short 'ウィンド初期表示ﾌﾗｸﾞ(True or False)

    '''''    Dim WlsSelList$
    Dim SWlsSelList As Object
    Dim WlsOrderBy As String
    Dim WlsFromWhere As String

    Private pv_blnChange_Flg As Boolean

    Private DblClickFl As Boolean 'DblClickイベント障害対応  97/04/07

    '20190730 ADD START
    Public JDN1_PARA1 As String
    '20190730 ADD END

    Private Sub COM_TANCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TANCD.Click

        '20190730 DEL START
        'DB_PARA(DBN_TANWTA).KeyBuf = WLSTANCD.Text
        '20190730 DEL END

        WLSTAN1.ShowDialog() '0:入力候補一覧は入力後に残す指定。
        ''98/09/25 追加
        WLSTAN1.Close()
        System.Windows.Forms.Application.DoEvents()
        WM_WLS_Dspflg = False
        KEYBAK.Items.Clear()
        LST.Items.Clear()
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        '20190516 CHG START
        'If IsDBNull(PP_SSSMAIN.SlistCom) Then
        If IsDBNull(WLSTAN_RTNCODE) Then
            '20190516 CHG END
            WLSTANCD.Text = ""
            WLSTANNM.Text = ""
        Else
            '20190730 CHG START
            'Call DB_GetEq(DBN_TANWTA, 1, PP_SSSMAIN.SlistCom, BtrNormal)
            Call DB_GetEq(DBN_TANWTA, 1, WLSTAN_RTNCODE, BtrNormal)
            '20190730 CHG END

            If DBSTAT = 0 Then
                WLSTANCD.Text = DB_TANWTA.TANCD
                WLSTANNM.Text = DB_TANWTA.TANNM
            End If
        End If
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_STTKEY = "1"
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_ENDKEY = System.DBNull.Value
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        '''''    WM_WLS_KeyNo = WM_WLS_TextKey
        '20190607 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '20190607 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call WLS_BaseSQL(WM_WLS_STTKEY)
        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WLSSSS_SET_KEYBAK() = True Then
            Call WLSSSS_DSP()
        End If
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.SlistCom = System.DBNull.Value

    End Sub

    Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
        Dim wkTOKCD As String

        '20190730 DEL START
        'DB_PARA(DBN_TOKMTA).KeyBuf = WLSTOKCD.Text
        '20190730 DEL END

        '2019/03/25 CHG START
        'WLSTOK.ShowDialog() '0:入力候補一覧は入力後に残す指定。 
        'WLSTOK.Close()
        WLSTOK3.ShowDialog() '0:入力候補一覧は入力後に残す指定。 
        WLSTOK3.Close()
        '2019/03/25 CHG E N D
        System.Windows.Forms.Application.DoEvents()
        WM_WLS_Dspflg = False
        KEYBAK.Items.Clear()
        LST.Items.Clear()
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(PP_SSSMAIN.SlistCom) Then
            WLSTOKCD.Text = ""
        Else
            'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wkTOKCD = VB.Left(PP_SSSMAIN.SlistCom, 5) & Space(Len(DB_TOKMTA.TOKCD) - 5)
            Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)

            If DBSTAT = 0 Then
                WLSTOKCD.Text = DB_TOKMTA.TOKCD
            End If
        End If
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_STTKEY = "1"
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_ENDKEY = System.DBNull.Value
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        '''''    WM_WLS_KeyNo = WM_WLS_TextKey
        '20190607 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '20190607 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call WLS_BaseSQL(WM_WLS_STTKEY)
        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WLSSSS_SET_KEYBAK() = True Then
            Call WLSSSS_DSP()
        End If
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.SlistCom = System.DBNull.Value

    End Sub

    Private Sub COM_JDNTRKB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_JDNTRKB.Click
        Dim wkJDNTRKB As String

        WLS_MEI1.Text = "受注取引区分一覧"
        CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()

        '20190606 CHG START
        'Call DB_GetGrEq(DBN_MEIMTA, 3, "006", BtrNormal)

        'Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "006"
        '    If DB_MEIMTA.DATKB <> "9" Then
        '        CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
        '    End If
        '    Call DB_GetNext(DBN_MEIMTA, BtrNormal)
        'Loop
        Dim strSQL As String

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "  from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  = '006' "
        strSQL = strSQL & "  Order By MEICDA "

        Dim dt As DataTable = DB_GetTable(strSQL)
        For i As Integer = 0 To dt.Rows.Count - 1
            Call Set_DB_MEIMTA(dt, DB_MEIMTA, i)
            CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
        Next
        '20190606 CHG END

        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
        WLS_MEI1.ShowDialog()
        WLS_MEI1.Close()
        System.Windows.Forms.Application.DoEvents()
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(PP_SSSMAIN.SlistCom) Then
            WLSJDNTRKB.Text = ""
            WLSJDNTRNM.Text = ""
        Else
            'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wkJDNTRKB = LeftWid(PP_SSSMAIN.SlistCom, 2) & Space(CShort(Len(DB_MEIMTA.MEICDA) - Len(LeftWid(PP_SSSMAIN.SlistCom, 2)) & Space(Len(DB_MEIMTA.MEICDB))))

            '20190820 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 1, "006" & wkJDNTRKB, BtrNormal)
            Call GetRowsCommon(DBN_MEIMTA, "WHERE KEYCD = '006' AND MEICDA = '" & wkJDNTRKB & "'")
            '20190820 CHG END

            If DBSTAT = 0 Then
                WLSJDNTRKB.Text = LeftWid(DB_MEIMTA.MEICDA, 2)
                WLSJDNTRNM.Text = DB_MEIMTA.MEINMA
            End If
        End If
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_STTKEY = "1"
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_ENDKEY = System.DBNull.Value
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        '''''    WM_WLS_KeyNo = WM_WLS_TextKey
        '20190607 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '20190607 CHG END
        KEYBAK.Items.Clear()
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call WLS_BaseSQL(WM_WLS_STTKEY)
        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WLSSSS_SET_KEYBAK() = True Then
            Call WLSSSS_DSP()
        End If
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.SlistCom = System.DBNull.Value

    End Sub

    Private Sub COM_DENDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_DENDT.Click
        Dim i As Short

        Set_date.Value = CNV_DATE(DB_UNYMTA.UNYDT)
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()

        WLSDENDT.Text = Set_date.Value
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_STTKEY = "1"
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_ENDKEY = System.DBNull.Value
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        '20190607 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '20190607 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call WLS_BaseSQL(WM_WLS_STTKEY)
        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WLSSSS_SET_KEYBAK() = True Then
            Call WLSSSS_DSP()
        End If
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.SlistCom = System.DBNull.Value

    End Sub

    'UPGRADE_WARNING: Form イベント WLSJDN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
    Private Sub WLSJDN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        'DEL START FKS)INABA 2009/02/27 ****************
        'レスポンス対応
        '    Call WLSSSS_FORM_ACTIVATE
        'DEL  END  FKS)INABA 2009/02/27 ****************
        'DblClickイベント障害対応  97/04/07
        DblClickFl = False
    End Sub

    Private Sub WLSJDN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call WLS_FORM_LOAD()
        Call WLSSSS_FORM_INIT()
        pv_blnChange_Flg = False

    End Sub


    '20190606 ADD START
    Private Sub WLSJDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190606 ADD END

    'UPGRADE_WARNING: イベント HD_TEXT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_TEXT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.TextChanged
        Dim s As Integer
        s = HD_TEXT.SelectionStart
        HD_TEXT.Text = StrConv(HD_TEXT.Text, VbStrConv.Uppercase)
        HD_TEXT.SelectionStart = s
    End Sub

    Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
        '''    If LenWid(HD_TEXT.Text) > 0 Then
        '''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
        '''    Else
        '''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
        '''    End If
        HD_TEXT.SelectionStart = 0
        'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        HD_TEXT.SelectionLength = HD_TEXT.Maxlength
    End Sub

    Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim i As Object
        Dim STAT As Short

        Select Case KEYCODE
            Case 13
                WM_WLS_Dspflg = False
                'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
                HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
                HD_TEXT.SelectionStart = 0
                'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
                HD_TEXT.SelectionLength = HD_TEXT.Maxlength
                'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WM_WLS_STTKEY = "11" & HD_TEXT.Text
                'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WM_WLS_ENDKEY = System.DBNull.Value
                WM_WLS_KeyCode = 0
                WM_WLS_Dspflg = True
                WM_WLS_KeyNo = WM_WLS_TextKey
                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call WLS_BaseSQL(WM_WLS_STTKEY)
                KEYBAK.Items.Clear()
                LST.Items.Clear()
                '20190607 CHG START
                'WM_WLS_Pagecnt = -1
                WM_WLS_Pagecnt = 0
                '20190607 CHG END
                'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If WLSSSS_SET_KEYBAK() = True Then
                    Call WLSSSS_DSP()
                End If
                '        Case 40  '↓キー
                '            LST.ListIndex = 0
                '            LST.SetFocus
            Case 112 'F･１キー
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F･１キー
                System.Windows.Forms.SendKeys.Send("%2")
        End Select
    End Sub

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
        'DblClickイベント障害対応  97/04/07
        DblClickFl = True

        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub

    Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KEYCODE
            Case 13
                Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
                'DblClickイベント障害対応  97/04/07
                'Call WLSCANCEL_CLICK
                '20190606 CHG START
                'If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190606 CHG END

            Case 27
                '20190606 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190606 CHG END

            Case 37 '←キー
                '20190606 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190606 CHG END

                '       Case 38  '↑キー
                '           If LST.ListIndex = 0 Then
                '               LST.ListIndex = -1
                '               HD_TEXT.SetFocus
                '           End If
            Case 39 '→キー
                '20190606 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190606 CHG END

                If LST.Items.Count > 0 Then
                    LST.SelectedIndex = -1
                End If
            Case 112 'F･１キー
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F･１キー
                System.Windows.Forms.SendKeys.Send("%2")
        End Select
    End Sub

    Private Sub WLS_DISPLAY()
        '====================================
        '   WINDOW 明細表示
        '====================================
        Dim WK_TK As New VB6.FixedLengthString(13)
        Dim WK_DENDT As New VB6.FixedLengthString(10)
        Dim WK_NOKDT As New VB6.FixedLengthString(10)

        Call WLS_MEISQL()
        WK_DENDT.Value = VB.Left(DB_JDNTHA.DENDT, 4) & "/" & Mid(DB_JDNTHA.DENDT, 5, 2) & "/" & VB.Right(DB_JDNTHA.DENDT, 2)
        LST.Items.Add(VB.Left(DB_JDNTHA.JDNNO, 6) & "   " & LeftWid(DB_MEIMTA.MEINMA, 10) & " " & WK_DENDT.Value & " " & LeftWid(DB_JDNTHA.TOKRN, 40) & " " & LeftWid(DB_JDNTHA.KENNMA, 40))
    End Sub

    Sub WLS_MEISQL()

        ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
        '20190709 DEL START
        'Call MEIMTA_RClear()
        '20190709 DEL END

        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "

        '20190516 CHG START
        'WlsFromWhere = "From MEIMTA Where KEYCD = '006'" & " And MEICDA = '" & DB_JDNTHA.JDNTRKB & "'" & " And MEICDB = ' '"
        'WlsOrderBy = "Order By MEICDA, MEICDB"
        ''UPGRADE_WARNING: オブジェクト SWlsSelList の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        'Call DB_GetSQL2(WM_WLS_SFIL, DB_SQLBUFF)

        'Call DB_GetData("MEIMTA", " Where KEYCD = '006'" & " And MEICDA = '" & DB_JDNTHA.JDNTRKB & "'" & " And MEICDB = ' '", "")
        'DB_MEIMTA = MEIMTA_GetNext(0)


        Call GetRowsCommon("MEIMTA", " Where KEYCD = '006'" & " And MEICDA = '" & DB_JDNTHA.JDNTRKB & "'" & " And MEICDB = ' '")
        '20190516 CHG END

    End Sub

    Private Function WLS_DSP_CHECK() As Object
        Dim wkTOKCD As String

        '====================================
        '   WINDOW 表示可能チェック
        '       WLS_DSP_CHECK = True  :表示可
        '       WLS_DSP_CHECK = FALSE :表示不可
        '====================================
        'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLS_DSP_CHECK = SSS_OK
        If DB_JDNTHA.DATKB <> "1" Then
            'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WLS_DSP_CHECK = SSS_END
            Exit Function
        End If
        'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If DB_JDNTHA.DENKB <> "1" Then WLS_DSP_CHECK = SSS_END
        ''    If DB_JDNTHA.AKAKROKB <> "1" Then WLS_DSP_CHECK = SSS_NEXT
        ''    wkTOKCD = WLSTOKCD.Text & Space(Len(DB_JDNTHA.TOKCD) - Len(WLSTOKCD.Text))
        ''    If (Trim$(WLSTOKCD.Text) <> "") And (DB_JDNTHA.TOKCD <> wkTOKCD) Then WLS_DSP_CHECK = SSS_NEXT
        ''    If (Trim$(WLSTANCD.Text) <> "") And (DB_JDNTHA.TANCD <> WLSTANCD.Text) Then WLS_DSP_CHECK = SSS_NEXT
        ''    If (Trim$(WLSJDNTRKB.Text) <> "") And (DB_JDNTHA.JDNTRKB <> WLSJDNTRKB.Text) Then WLS_DSP_CHECK = SSS_NEXT
        ''    If (Trim$(WLSDENDT.Text) <> "") And (DB_JDNTHA.DENDT < DeCNV_DATE(WLSDENDT)) Then WLS_DSP_CHECK = SSS_NEXT
        ''    If (Trim$(WLSKENNMA.Text) <> "") And (InStr(1, DB_JDNTHA.KENNMA, WLSKENNMA.Text) = 0) Then WLS_DSP_CHECK = SSS_NEXT

    End Function

    Private Function WLS_DSP_SUB_CHECK() As Object

        'UPGRADE_WARNING: オブジェクト WLS_DSP_SUB_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLS_DSP_SUB_CHECK = SSS_OK
    End Function

    Private Sub WLS_FORM_LOAD()

        '=== WINDOW 位置設定 ===
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)

        '=== ｺｰﾄﾞTEXT ===
        'WLSTOKCD.Height = 330
        'WLSRN.Height = 330
        '''''    WLSTOKCD.Text = ""
        '''''    WLSTOKRN.Caption = ""

        '=== WINDOW 表示ファイル設定 ===
        WM_WLS_MFIL = DBN_JDNTHA
        WM_WLS_SFIL = DBN_MEIMTA

        '=== 表示開始コード桁数設定 ===
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190516 CHG START
        'WM_WLS_LEN = LenWid(DB_JDNTHA.JDNNO)
        WM_WLS_LEN = 10
        '20190516 CHG END

        'UPGRADE_WARNING: オブジェクト SWlsSelList の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SWlsSelList = "*"

        '=== ＬＡＢＥＬ設定 ===
        'UPGRADE_WARNING: オブジェクト WLSLABEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/03/25 CHG START
        'WLSLABEL = "受注番号 受注取区   受注日付   得意先                                   件名"
        WLSLABEL.Text = "受注番号 受注取区   受注日付  得意先                                  件名"
        '2019/03/25 CHG E N D
        '=== コンボＢＯＸ設定 ===
        WM_WLS_INIT = 0
    End Sub

    Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'UnLoadイベント障害対応  97/04/07
        '20190606 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190606 CHG END

    End Sub

    '20190606 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
    '    Dim WL_Key As String

    '    If LST.Items.Count > 0 Then
    '        If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
    '            Exit Sub
    '        Else
    '            If (WM_WLS_Pagecnt + 1) > (KEYBAK.Items.Count - 1) Then
    '                'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
    '                'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                If WLSSSS_SET_KEYBAK() = False Then Exit Sub
    '            Else
    '                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '                WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
    '                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
    '                Call WLS_BaseSQL(WL_Key)

    '            End If
    '            Call WLSSSS_DSP()
    '        End If
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
        Dim WL_Key As String

        If LST.Items.Count > 0 Then
            If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
                Exit Sub
            Else
                If (WM_WLS_Pagecnt + 1) > (KEYBAK.Items.Count - 1) Then
                    'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                    'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If WLSSSS_SET_KEYBAK() = False Then Exit Sub
                Else
                    WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                    '20190607 CHG START
                    'WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
                    WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt * 19)
                    '20190607 CHG END
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                    Call WLS_BaseSQL(WL_Key)

                End If
                Call WLSSSS_DSP()
            End If
        End If
    End Sub
    '20190606 CHG END


    '20190606 CHG START
    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '    'UnLoadイベント障害対応  97/04/07
    '    'Unload Me
    '    Hide()
    'End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        'UnLoadイベント障害対応  97/04/07
        'Unload Me
        Hide()
    End Sub
    '20190606 CHG END


    'UPGRADE_WARNING: イベント WLSDENDT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub WLSDENDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSDENDT.TextChanged
        WLSDENDT.SelectionLength = 1
        If pv_blnChange_Flg = True Then
            Exit Sub
        Else
            Call CtrlDatChange(WLSDENDT)
        End If
    End Sub

    Private Sub WLSDENDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSDENDT.Click
        WLSDENDT.SelectionStart = 0
        WLSDENDT.SelectionLength = 1
    End Sub

    Private Sub WLSDENDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSDENDT.Enter
        If Len(Trim(WLSDENDT.Text)) = 0 Then
            pv_blnChange_Flg = True
            WLSDENDT.Text = Space(10)
            pv_blnChange_Flg = False
            WLSDENDT.SelectionStart = 0
            WLSDENDT.SelectionLength = 1
        ElseIf Len(Trim(WLSDENDT.Text)) >= 8 Then
            WLSDENDT.SelectionStart = 8
            WLSDENDT.SelectionLength = 1
        Else
            WLSDENDT.SelectionStart = 0
            WLSDENDT.SelectionLength = 1
        End If
    End Sub

    Private Sub WLSDENDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles WLSDENDT.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = System.Windows.Forms.Keys.Back Then
            KeyAscii = 0
            pv_blnChange_Flg = True
            If WLSDENDT.SelectionStart > 0 Then
                WLSDENDT.SelectionStart = WLSDENDT.SelectionStart - 1
            End If
            WLSDENDT.SelectionLength = 1
            Call PrevForcus(WLSDENDT)
            pv_blnChange_Flg = False
        Else
            ' ADD 2007/02/20 数値以外は入力不可
            Select Case True
                Case (KeyAscii >= Asc("0") And KeyAscii <= Asc("9"))

                Case Else
                    KeyAscii = 0
            End Select
            ' ADD 2007/02/20 数値以外は入力不可
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub WLSKENNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKENNMA.Enter
        WLSKENNMA.SelectionStart = 0
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLSKENNMA.SelectionLength = LenWid(WLSKENNMA.Text)
    End Sub

    'UPGRADE_WARNING: イベント WLSTANCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub WLSTANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTANCD.TextChanged
        Dim s As Integer
        s = WLSTANCD.SelectionStart
        WLSTANCD.Text = StrConv(WLSTANCD.Text, VbStrConv.Uppercase)
        WLSTANCD.SelectionStart = s
    End Sub

    Private Sub WLSTANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTANCD.Enter
        '''    If LenWid(WLSTANCD.Text) > 0 Then
        '''        WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, LenWid(DB_TANWTA.TANCD), "0")
        '''    Else
        '''        WLSTANCD.Text = Space$(LenWid(DB_TANWTA.TANCD))
        '''    End If
        WLSTANCD.SelectionStart = 0
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLSTANCD.SelectionLength = LenWid(DB_TANWTA.TANCD)

    End Sub

    Private Sub WLSTANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTANCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim i As Object
        Dim STAT As Short

        Select Case KEYCODE
            Case 13
                WM_WLS_Dspflg = False
                KEYBAK.Items.Clear()
                LST.Items.Clear()
                '20190607 CHG START
                'WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, LenWid(DB_TANWTA.TANCD), "0")
                WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, 6, "0")
                '20190607 CHG END
                WLSTANCD.SelectionStart = 0
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WLSTANCD.SelectionLength = LenWid(DB_TANWTA.TANCD)
                If Trim(WLSTANCD.Text) = "" Then
                    WLSTANNM.Text = ""
                    'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    WM_WLS_STTKEY = "1"
                    'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    WM_WLS_ENDKEY = System.DBNull.Value
                    WM_WLS_KeyCode = 0
                    WM_WLS_Dspflg = True
                    '20190607 CHG START
                    'WM_WLS_Pagecnt = -1
                    WM_WLS_Pagecnt = 0
                    '20190607 CHG END
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If WLSSSS_SET_KEYBAK() = True Then
                        Call WLSSSS_DSP()
                    End If
                Else
                    '20190820 CHG START
                    'Call DB_GetEq(DBN_TANWTA, 1, WLSTANCD.Text, BtrNormal)
                    GetRowsCommon(DBN_TANWTA, "Where TANCD = '" & WLSTANCD.Text & "'")
                    '20190820 CHG END

                    If DBSTAT = 0 Then
                        WLSTANNM.Text = DB_TANWTA.TANNM
                        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        WM_WLS_STTKEY = "1"
                        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        WM_WLS_ENDKEY = System.DBNull.Value
                        WM_WLS_KeyCode = 0
                        WM_WLS_Dspflg = True
                        '20190607 CHG START
                        'WM_WLS_Pagecnt = -1
                        WM_WLS_Pagecnt = 0
                        '20190607 CHG END
                        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call WLS_BaseSQL(WM_WLS_STTKEY)
                        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If WLSSSS_SET_KEYBAK() = True Then
                            Call WLSSSS_DSP()
                        End If
                    End If
                End If
                '        Case 40  '↓キー
                '            LST.ListIndex = 0
                '            LST.SetFocus
            Case 112 'F･１キー
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F･１キー
                System.Windows.Forms.SendKeys.Send("%2")
        End Select

    End Sub

    Private Sub WLSTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.Enter
        '''    If LenWid(WLSTOKCD.Text) > 0 Then
        '''        WLSTOKCD.Text = SSS_EDTITM_WLS(WLSTOKCD.Text, 5, "0")
        '''    Else
        '''        WLSTOKCD.Text = Space$(LenWid(DB_TOKMTA.TOKCD))
        '''    End If
        WLSTOKCD.SelectionStart = 0
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLSTOKCD.SelectionLength = LenWid(DB_TOKMTA.TOKCD)

    End Sub

    Private Sub WLSTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTOKCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim i As Object
        Dim STAT As Short

        Select Case KEYCODE
            Case 13
                WM_WLS_Dspflg = False
                KEYBAK.Items.Clear()
                LST.Items.Clear()
                WLSTOKCD.Text = SSS_EDTITM_WLS(WLSTOKCD.Text, 5, "0")
                WLSTOKCD.SelectionStart = 0
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WLSTOKCD.SelectionLength = LenWid(DB_TOKMTA.TOKCD)
                If Trim(WLSTOKCD.Text) = "" Then
                    'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    WM_WLS_STTKEY = "1"
                    'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    WM_WLS_ENDKEY = System.DBNull.Value
                    WM_WLS_KeyCode = 0
                    WM_WLS_Dspflg = True
                    '20190607 CHG START
                    'WM_WLS_Pagecnt = -1
                    WM_WLS_Pagecnt = 0
                    '20190607 CHG END
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If WLSSSS_SET_KEYBAK() = True Then
                        Call WLSSSS_DSP()
                    End If
                Else
                    Call DB_GetEq(DBN_TOKMTA, 1, WLSTOKCD.Text, BtrNormal)

                    If DBSTAT = 0 Then
                        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        WM_WLS_STTKEY = "1"
                        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        WM_WLS_ENDKEY = System.DBNull.Value
                        WM_WLS_KeyCode = 0
                        WM_WLS_Dspflg = True
                        '20190607 CHG START
                        'WM_WLS_Pagecnt = -1
                        WM_WLS_Pagecnt = 0
                        '20190607 CHG END
                        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call WLS_BaseSQL(WM_WLS_STTKEY)
                        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If WLSSSS_SET_KEYBAK() = True Then
                            Call WLSSSS_DSP()
                        End If
                    End If
                End If
                '        Case 40  '↓キー
                '            LST.ListIndex = 0
                '            LST.SetFocus
            Case 112 'F･１キー
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F･１キー
                System.Windows.Forms.SendKeys.Send("%2")
        End Select

    End Sub

    Private Sub WLSJDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSJDNTRKB.Enter
        '''    If LenWid(WLSJDNTRKB.Text) > 0 Then
        '''        WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_JDNTHA.JDNTRKB), "0")
        '''    Else
        '''        WLSJDNTRKB.Text = Space$(LenWid(DB_JDNTHA.JDNTRKB))
        '''    End If
        WLSJDNTRKB.SelectionStart = 0
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLSJDNTRKB.SelectionLength = LenWid(DB_JDNTHA.JDNTRKB)

    End Sub

    Private Sub WLSJDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSJDNTRKB.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim i As Object
        Dim STAT As Short
        Dim wkJDNTRKB As String

        Select Case KEYCODE
            Case 13
                WM_WLS_Dspflg = False
                KEYBAK.Items.Clear()
                LST.Items.Clear()
                '20190607 CHG START
                'WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_JDNTHA.JDNTRKB), "0")
                If DB_JDNTHA.JDNTRKB Is Nothing Then
                    WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, 2, "0")
                Else
                    WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_JDNTHA.JDNTRKB), "0")
                End If
                '20190607 CHG END
                WLSJDNTRKB.SelectionStart = 0
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WLSJDNTRKB.SelectionLength = LenWid(DB_JDNTHA.JDNTRKB)
                If Trim(WLSJDNTRKB.Text) = "" Then
                    WLSJDNTRNM.Text = ""
                    'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    WM_WLS_STTKEY = "1"
                    'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    WM_WLS_ENDKEY = System.DBNull.Value
                    WM_WLS_KeyCode = 0
                    WM_WLS_Dspflg = True
                    '20190607 CHG START
                    'WM_WLS_Pagecnt = -1
                    WM_WLS_Pagecnt = 0
                    '20190607 CHG END
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If WLSSSS_SET_KEYBAK() = True Then
                        Call WLSSSS_DSP()
                    End If
                Else
                    '20190607 CHG START
                    'wkJDNTRKB = WLSJDNTRKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSJDNTRKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
                    If DB_MEIMTA.MEICDA Is Nothing Then
                        wkJDNTRKB = WLSJDNTRKB.Text & Space(20 - Len(WLSJDNTRKB.Text)) & Space(5)
                    Else
                        wkJDNTRKB = WLSJDNTRKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSJDNTRKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
                    End If
                    '20190607 CHG END

                    Call DB_GetEq(DBN_MEIMTA, 1, "006" & wkJDNTRKB, BtrNormal)

                    If DBSTAT = 0 Then

                        WLSJDNTRKB.Text = LeftWid(DB_MEIMTA.MEICDA, 2)
                        WLSJDNTRNM.Text = DB_MEIMTA.MEINMA

                        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        WM_WLS_STTKEY = "1"
                        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        WM_WLS_ENDKEY = System.DBNull.Value
                        WM_WLS_KeyCode = 0
                        WM_WLS_Dspflg = True
                        '20190607 CHG START
                        'WM_WLS_Pagecnt = -1
                        WM_WLS_Pagecnt = 0
                        '20190607 CHG END
                        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call WLS_BaseSQL(WM_WLS_STTKEY)
                        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If WLSSSS_SET_KEYBAK() = True Then
                            Call WLSSSS_DSP()
                        End If
                    End If
                End If
                '        Case 40  '↓キー
                '            LST.ListIndex = 0
                '            LST.SetFocus
            Case 112 'F･１キー
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F･１キー
                System.Windows.Forms.SendKeys.Send("%2")
        End Select

    End Sub

    Private Sub WLSDENDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSDENDT.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim strDat As String

        Dim i As Short
        Dim W_Key As String
        Select Case True
            'ｴﾝﾀｰｷｰ押
            Case KEYCODE = System.Windows.Forms.Keys.Return And Shift = 0

                If Trim(WLSDENDT.Text) <> "" Then
                    '20190607 CHG START
                    'If CHECK_DATE(WLSDENDT) = False Then
                    If CHECK_DATE(WLSDENDT.Text) = False Then
                        '20190607 CHG END
                        Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '日付エラー
                        WLSDENDT.Focus()
                        Exit Sub
                    End If
                End If

                'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WM_WLS_STTKEY = "1"
                'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WM_WLS_ENDKEY = System.DBNull.Value
                WM_WLS_KeyCode = 0
                WM_WLS_Dspflg = True
                '20190607 CHG START
                'WM_WLS_Pagecnt = -1
                WM_WLS_Pagecnt = 0
                '20190607 CHG END
                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call WLS_BaseSQL(WM_WLS_STTKEY)
                'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If WLSSSS_SET_KEYBAK() = True Then
                    Call WLSSSS_DSP()
                End If

                '→押
            Case KEYCODE = System.Windows.Forms.Keys.Right And Shift = 0
                KEYCODE = 0
                '→制御
                If WLSDENDT.SelectionStart < Len(WLSDENDT.Text) Then
                    WLSDENDT.SelectionStart = WLSDENDT.SelectionStart + 1
                    WLSDENDT.SelectionLength = 1
                    Call NextForcus(WLSDENDT)
                End If

                '↓押
            Case KEYCODE = System.Windows.Forms.Keys.Down And Shift = 0
                '↓制御
                KEYCODE = 0

                '↓押
            Case KEYCODE = System.Windows.Forms.Keys.Up And Shift = 0
                '↓制御
                KEYCODE = 0

                '←押
            Case KEYCODE = System.Windows.Forms.Keys.Left And Shift = 0
                KEYCODE = 0
                '←制御
                If WLSDENDT.SelectionStart > 0 Then
                    WLSDENDT.SelectionStart = WLSDENDT.SelectionStart - 1
                    WLSDENDT.SelectionLength = 1
                    Call PrevForcus(WLSDENDT)
                End If

            Case KEYCODE = System.Windows.Forms.Keys.Delete And Shift = 0
                KEYCODE = 0

                ''        'TAB押
                ''        Case KEYCODE = vbKeyF16
                ''            Call F_SendKey(KEYCODE, "HD_KESIDT")
                ''        Case KEYCODE = vbKeyS And Shift = 2
                ''            pv_blnChange_Flg = True
                ''            WLSDENDT.Text = Space(10)
                ''            WLSDENDT.SelStart = 0
                ''            WLSDENDT.SelLength = 1
                ''            pv_blnChange_Flg = False

        End Select
    End Sub

    Private Sub WLSDENDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSDENDT.Leave
        Dim i As Short
        Dim W_Key As String
        Dim strDat As String

        If Trim(WLSDENDT.Text) <> "" Then
            If ConvDat(Trim(WLSDENDT.Text), strDat) = False Then
                WLSDENDT.Focus()
                Exit Sub
            End If
            '20190607 CHG START
            'If CHECK_DATE(WLSDENDT) = False Then
            If CHECK_DATE(WLSDENDT.Text) = False Then
                '20190607 CHG END
                Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '日付エラー
                WLSDENDT.Focus()
                Exit Sub
            End If
        End If
        ''    WM_WLS_STTKEY = "1"
        ''    WM_WLS_ENDKEY = Null
        ''    WM_WLS_KeyCode = 0
        ''    WM_WLS_Dspflg = True
        ''    WM_WLS_Pagecnt = -1
        ''    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        ''    Call WLS_BaseSQL(WM_WLS_STTKEY)
        ''    If WLSSSS_SET_KEYBAK() = True Then
        ''        Call WLSSSS_DSP
        ''    End If

    End Sub

    Private Sub WLSKENNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKENNMA.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim i As Short
        Dim W_Key As String
        If KEYCODE = System.Windows.Forms.Keys.Return Then

            'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_STTKEY = "1"
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WM_WLS_ENDKEY = System.DBNull.Value
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            '20190607 CHG START
            'WM_WLS_Pagecnt = -1
            WM_WLS_Pagecnt = 0
            '20190607 CHG END
            'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
            'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call WLS_BaseSQL(WM_WLS_STTKEY)
            'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If WLSSSS_SET_KEYBAK() = True Then
                Call WLSSSS_DSP()
            End If
        End If
    End Sub

    Private Sub WLSHINNMA_LOSTFocus()
        Dim i As Short
        Dim W_Key As String

        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_STTKEY = "1"
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_ENDKEY = System.DBNull.Value
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        '20190607 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '20190607 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call WLS_BaseSQL(WM_WLS_STTKEY)
        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WLSSSS_SET_KEYBAK() = True Then
            Call WLSSSS_DSP()
        End If

    End Sub

    '20190606 CHG START
    'Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '    Dim WL_Key As String

    '    If WM_WLS_Pagecnt > 0 Then
    '        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '    Else
    '        Exit Sub
    '    End If
    '    WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
    '    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
    '    Call WLS_BaseSQL(WL_Key)
    '    Call WLSSSS_DSP()
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
        Dim WL_Key As String

        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
        Else
            Exit Sub
        End If
        '20190607 CHG START
        'WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
        WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt * 19)
        '20190607 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
        Call WLS_BaseSQL(WL_Key)
        Call WLSSSS_DSP()
    End Sub
    '20190606 CHG END


    '20190606 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.WLSJDNTRKB.Focused Then
                Call WLSJDNTRKB_KeyDown(WLSJDNTRKB, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.WLSDENDT.Focused Then
                Call WLSDENDT_KeyDown(WLSDENDT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.WLSTOKCD.Focused Then
                Call WLSTOKCD_KeyDown(WLSTOKCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_TEXT.Focused Then
                Call HD_TEXT_KeyDown(HD_TEXT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.WLSKENNMA.Focused Then
                Call WLSKENNMA_KeyDown(WLSKENNMA, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call WLSTANCD_KeyDown(WLSTANCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面検索エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            LST.Items.Clear()
            Me.WLSTANCD.Text = ""
            Me.WLSTANNM.Text = ""
            Me.HD_TEXT.Text = ""
            Me.WLSJDNTRKB.Text = ""
            Me.WLSJDNTRNM.Text = ""
            Me.WLSDENDT.Text = ""
            Me.WLSTOKCD.Text = ""
            Me.WLSKENNMA.Text = ""

            Me.WLSTANCD.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    '20190606 ADD END


    '20190606 CHG START
    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '    Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub
    '20190606 CHG END

    Private Sub WLSSSS_DSP()
        Dim WL_Mode As Short
        Dim WL_Key As String

        If WM_WLS_Dspflg = False Then Exit Sub

        LST.Items.Clear()
        If DBSTAT = 0 Then
            '20190516 CHG START
            'Do While (DBSTAT = 0) And (LST.Items.Count < WM_WLS_MAX) And (WL_Mode <> SSS_END)
            '    'UPGRADE_WARNING: オブジェクト WLSSSS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    WL_Mode = WLSSSS_DSP_CHECK()
            '    If WL_Mode = SSS_OK Then
            '        'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        WL_Mode = WLS_DSP_CHECK()
            '        If WL_Mode = SSS_OK Then
            '            Call WLS_DISPLAY()
            '        End If
            '    End If
            '    If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
            '        Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            '    ElseIf WL_Mode = SSS_RPSN Then
            '        'UPGRADE_WARNING: オブジェクト WLSSSS_RPSN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        WL_Key = WLSSSS_RPSN()
            '        'UPGRADE_WARNING: オブジェクト LenWid(WL_Key) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        If LenWid(WL_Key) = 0 Then
            '            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            '        Else
            '            'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
            '            Call WLS_BaseSQL(WL_Key)
            '        End If
            '    ElseIf WL_Mode = SSS_NPSN Then
            '        'UPGRADE_WARNING: オブジェクト WLSSSS_NPSN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        WL_Key = WLSSSS_NPSN()
            '        'UPGRADE_WARNING: オブジェクト LenWid(WL_Key) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        If LenWid(WL_Key) = 0 Then
            '            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            '        Else
            '            'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
            '            Call WLS_BaseSQL(WL_Key)
            '        End If
            '    End If
            'Loop


            Dim dt As DataTable = dsList.Tables("tableName")

            For i As Integer = 0 To dt.Rows.Count - 1
                DB_JDNTHA.DENDT = DB_NullReplace(dt.Rows(i).Item("DENDT"), "")
                DB_JDNTHA.JDNNO = DB_NullReplace(dt.Rows(i).Item("JDNNO"), "")
                DB_JDNTHA.TOKRN = DB_NullReplace(dt.Rows(i).Item("TOKRN"), "")
                DB_JDNTHA.KENNMA = DB_NullReplace(dt.Rows(i).Item("KENNMA"), "")
                DB_JDNTHA.JDNTRKB = DB_NullReplace(dt.Rows(i).Item("JDNTRKB"), "")

                Call WLS_DISPLAY()
            Next
            '20190516 CHG END

            If LST.Items.Count > 0 Then
                LST.SelectedIndex = 0
            End If
        End If
        If (DBSTAT <> 0) Or (WL_Mode = SSS_END) Then
            If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) <> HighValue(1)) Then
                KEYBAK.Items.Add(HighValue(1))
            End If
        End If
    End Sub

    Private Function WLSSSS_DSP_CHECK() As Object
        Dim CHKDAT As Object

        'UPGRADE_WARNING: オブジェクト WLSSSS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLSSSS_DSP_CHECK = SSS_OK

        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If Not IsDBNull(WM_WLS_ENDKEY) Then
            'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト LenWid(WM_WLS_ENDKEY) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            '20190730 CHG START
            'If LeftWid(DB_PARA(WM_WLS_MFIL).KeyBuf, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
            '    'UPGRADE_WARNING: オブジェクト WLSSSS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    WLSSSS_DSP_CHECK = SSS_END
            '    Exit Function
            'End If
            If LeftWid(JDN1_PARA1, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
                'UPGRADE_WARNING: オブジェクト WLSSSS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WLSSSS_DSP_CHECK = SSS_END
                Exit Function
            End If
            '20190730 CHG END

        End If

    End Function

    Private Sub WLSSSS_FORM_ACTIVATE()
        Dim i As Short
        Dim W_Key As String

        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        '20190607 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '20190607 CHG END
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey

        '20190730 CHG START
        'W_Key = DB_PARA(WM_WLS_MFIL).KeyBuf
        W_Key = JDN1_PARA1
        '20190730 CHG END

        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        Call WLS_BaseSQL(W_Key)
        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If WLSSSS_SET_KEYBAK() = True And WM_WLS_INIT = 0 Then
            '2001/07/25 追加一行
            WM_WLS_INIT = 1
            Call WLSSSS_DSP()
        End If
    End Sub

    Private Sub WLSSSS_FORM_INIT()
        Dim i As Short

        WM_WLS_KeyCode = False
        WM_WLS_MAX = VB6.PixelsToTwipsY(LST.Height) \ 240
        'HD_TEXT.Height = 330
        'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        HD_TEXT.Maxlength = WM_WLS_LEN
        HD_TEXT.Width = VB6.TwipsToPixelsX((WM_WLS_LEN + 1) * 120)
        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_STTKEY = "1"
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_ENDKEY = System.DBNull.Value
        HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
        'UPGRADE_WARNING: オブジェクト LenWid(Trim$(DB_PARA(WM_WLS_MFIL).KeyBuf)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        '20190730 CHG START
        'If LenWid(Trim(DB_PARA(WM_WLS_MFIL).KeyBuf)) = 0 Then
        '    HD_TEXT.Text = ""
        'End If
        If LenWid(Trim(JDN1_PARA1)) = 0 Then
            HD_TEXT.Text = ""
        End If
        '20190730 CHG END

        ''98/09/25 追加
        WM_WLS_KeyNo = WM_WLS_TextKey

    End Sub

    Private Function WLSSSS_NPSN() As Object
        Dim WL_Key As String
        WL_Key = ""
        'UPGRADE_WARNING: オブジェクト WLSSSS_NPSN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLSSSS_NPSN = WL_Key
    End Function

    Private Function WLSSSS_RPSN() As Object
        Dim WL_Key As String
        WL_Key = ""
        'UPGRADE_WARNING: オブジェクト WLSSSS_RPSN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLSSSS_RPSN = WL_Key
    End Function

    Private Function WLSSSS_SET_KEYBAK() As Object
        Dim WL_Mode As Short
        Dim WL_Key As String

        'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLSSSS_SET_KEYBAK = True

        '20190606 CHG START
        'Do While DBSTAT = 0
        '    'UPGRADE_WARNING: オブジェクト WLSSSS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    WL_Mode = WLSSSS_DSP_CHECK()
        '    If WL_Mode = SSS_OK Then
        '        'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        WL_Mode = WLS_DSP_CHECK()
        '        If WL_Mode = SSS_OK Then
        '            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '            'KEYBAK.AddItem DB_PARA(WM_WLS_MFIL).KeyBuf
        '            KEYBAK.Items.Add(DB_JDNTHA.DATKB & DB_JDNTHA.DENKB & DB_JDNTHA.JDNNO)
        '        End If
        '    End If
        '    If WL_Mode = SSS_NEXT Then
        '        Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '    ElseIf WL_Mode = SSS_RPSN Then
        '        'UPGRADE_WARNING: オブジェクト WLSSSS_RPSN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        WL_Key = WLSSSS_RPSN()
        '        'UPGRADE_WARNING: オブジェクト LenWid(WL_Key) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        If LenWid(WL_Key) = 0 Then
        '            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '        Else
        '            'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
        '            Call WLS_BaseSQL(WL_Key)
        '        End If
        '    ElseIf WL_Mode = SSS_NPSN Then
        '        'UPGRADE_WARNING: オブジェクト WLSSSS_NPSN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        WL_Key = WLSSSS_NPSN()
        '        'UPGRADE_WARNING: オブジェクト LenWid(WL_Key) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        If LenWid(WL_Key) = 0 Then
        '            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '        Else
        '            'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
        '            Call WLS_BaseSQL(WL_Key)
        '        End If
        '    Else
        '        Exit Do
        '    End If
        'Loop


        Dim dt As DataTable = dsList.Tables("tableName")

        For i As Integer = 0 To dt.Rows.Count - 1
            DB_JDNTHA.DENDT = DB_NullReplace(dt.Rows(i).Item("DENDT"), "")
            DB_JDNTHA.JDNNO = DB_NullReplace(dt.Rows(i).Item("JDNNO"), "")
            DB_JDNTHA.TOKRN = DB_NullReplace(dt.Rows(i).Item("TOKRN"), "")
            DB_JDNTHA.KENNMA = DB_NullReplace(dt.Rows(i).Item("KENNMA"), "")
            DB_JDNTHA.JDNTRKB = DB_NullReplace(dt.Rows(i).Item("JDNTRKB"), "")

            KEYBAK.Items.Add(DB_JDNTHA.DATKB & DB_JDNTHA.DENKB & DB_JDNTHA.JDNNO)
        Next
        '20190606 CHG END

        '20190516 DEL START
        'If DBSTAT <> 0 Or WL_Mode = SSS_END Then
        '    'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    WLSSSS_SET_KEYBAK = False
        'End If
        '20190516 DEL END

    End Function

    Private Function ConvDat(ByVal strTarget As String, ByRef strDat As String) As Boolean

        Dim blnRtnVal As Boolean
        Dim strYYYY As String
        Dim strMM As String
        Dim strDD As String

        blnRtnVal = False
        strDat = ""
        strYYYY = ""
        strMM = ""
        strDD = ""

        If IsDate(strTarget) = True Then
            strDat = strTarget
            blnRtnVal = True
        Else
            If Len(strTarget) = 8 Then
                strYYYY = VB.Left(strTarget, 4)
                strMM = Mid(strTarget, 5, 2)
                strDD = VB.Right(strTarget, 2)
                If IsDate(strYYYY & "/" & strMM & "/" & strDD) = True Then
                    strDat = strYYYY & "/" & strMM & "/" & strDD
                    blnRtnVal = True
                End If
            End If
        End If

        ConvDat = blnRtnVal

    End Function

    Private Function CtrlDatChange(ByRef Ctl As System.Windows.Forms.TextBox) As String

        Dim lngSelstart As Integer
        Dim Wk_DspMoji As String
        Dim Wk_EditMoji As String
        Wk_EditMoji = CnvDspItem_Date(Ctl.Text)

        '編集後の文字を表示形式に変換
        Wk_DspMoji = CnvDspItem_Date(Wk_EditMoji)

        pv_blnChange_Flg = True
        lngSelstart = Ctl.SelectionStart
        Ctl.Text = VB.Left(Wk_DspMoji & Space(10), 10)
        Ctl.SelectionStart = lngSelstart
        Ctl.SelectionLength = 1
        'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ可
        pv_blnChange_Flg = False

        '現在ﾌｫｰｶｽ位置から右へ移動
        Call NextForcus(Ctl)

    End Function

    Private Function CnvDspItem_Date(ByVal strValue As String) As String

        Dim Rtn_Str_Value As String

        Rtn_Str_Value = strValue

        '日付の場合
        If Trim(Rtn_Str_Value) = "" Then
            '未入力の場合
            Rtn_Str_Value = New String(Space(1), 10)
        Else
            '入力ありの場合
            If Len(Trim(Rtn_Str_Value)) <> Len("YYYYMMDD") Then
                '入力形式が異なる場合
                '詰文字が左詰の場合、、詰文字をバイト数(桁数として使用)を左側に追加
                Rtn_Str_Value = LTrim(Rtn_Str_Value) & New String(Space(1), 10)
                '右からバイト数分だけ取得
                Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, 10)
            Else
                '表示形式有
                Rtn_Str_Value = CF_Ctr_AnsiLeftB(VB6.Format(Rtn_Str_Value, "0000/00/00") & New String(Space(1), 10), 10)
            End If
        End If

        CnvDspItem_Date = Rtn_Str_Value

    End Function

    Private Function NextForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object

        Dim Index_Wk As Short
        Dim Act_SelStart As Short
        Dim Act_SelLength As Short
        Dim Act_SelStr As String
        Dim Act_SelStrB As Integer
        Dim Str_Wk As String
        Dim Next_SelStart As Short
        Dim Wk_Point As Short
        Dim Wk_SelLength As Short

        '    '移動フラグ初期化
        '    pm_Move_Flg = False

        '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合

        '現在のﾃｷｽﾄ上の選択状態を取得
        Act_SelStart = Ctl.SelectionStart
        Act_SelLength = Ctl.SelectionLength
        Act_SelStr = Ctl.SelectedText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

        If Act_SelStart = 0 And Act_SelStrB = 10 Then
            '全選択の場合（選択文字が最大バイト数と一致）
            '詰文字が左詰の場合
            '最終文字を選択する
            Ctl.SelectionStart = Len(Ctl.Text) - 1
            Ctl.SelectionLength = 1
        Else
            If Act_SelStart = Len(Ctl.Text) Then
                '選択開始位置が一番右の場合
                ''                Select Case Ctl.NAME
                ''                    Case WLSHDNDT.NAME
                ''                        If IsDate(Ctl.Text) = True Then
                ''                            WLSHDNDT.ForeColor = COLOR_BLACK
                ''                            WLSSIRCD.SetFocus
                ''                        End If
                ''                End Select
                Ctl.SelectionStart = Len(Ctl.Text) - 1
                Ctl.SelectionLength = 1
            Else
                '選択開始位置が一番右でない場合

                '１つ右の１桁を取得
                Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)

                If Str_Wk = "" Then
                    '一番右へ移動し選択なし状態に
                    Ctl.SelectionStart = Len(Ctl.Text)
                    Ctl.SelectionLength = 0
                Else
                    '右に１桁ずつずらし入力可能な文字を検索
                    Next_SelStart = -1
                    For Wk_Point = Act_SelStart + 1 To Len(Ctl.Text) Step 1

                        Str_Wk = Mid(Ctl.Text, Wk_Point, 1)

                        '日付/年月/時刻項目の場合
                        '入力可能文字＆と空白も移動可能
                        If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
                            Next_SelStart = Wk_Point - 1
                            Exit For
                        End If
                    Next

                    If Next_SelStart = -1 Then
                        '選択可能な文字がない場合
                        ''                        Select Case Ctl.NAME
                        ''                            Case WLSHDNDT.NAME
                        ''                                If IsDate(Ctl.Text) = True Then
                        ''                                    WLSHDNDT.ForeColor = COLOR_BLACK
                        ''                                    WLSSIRCD.SetFocus
                        ''                                End If
                        ''                        End Select
                    Else
                        '選択可能な文字がある場合

                        If Act_SelLength = 0 Then
                            '移動前の選択文字数がない場合
                            '同じ項目で移動する場合に選択文字数は継続する
                            Wk_SelLength = 0
                        Else
                            Wk_SelLength = 1
                        End If

                        Ctl.SelectionStart = Next_SelStart
                        Ctl.SelectionLength = Wk_SelLength
                    End If
                End If
            End If

        End If

    End Function

    Private Function PrevForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object

        Dim Index_Wk As Short
        Dim Act_SelStart As Short
        Dim Act_SelLength As Short
        Dim Act_SelStr As String
        Dim Act_SelStrB As Integer
        Dim Str_Wk As String
        Dim Next_SelStart As Short
        Dim Wk_Point As Short
        Dim Wk_SelLength As Short

        '    '移動フラグ初期化
        '    pm_Move_Flg = False

        '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合

        '現在のﾃｷｽﾄ上の選択状態を取得
        Act_SelStart = Ctl.SelectionStart
        Act_SelLength = Ctl.SelectionLength
        Act_SelStr = Ctl.SelectedText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

        If Act_SelStart = 0 And Act_SelStrB = 10 Then
            '全選択の場合（選択文字が最大バイト数と一致）
            '詰文字が左詰の場合
            '最終文字を選択する
            Ctl.SelectionStart = Len(Ctl.Text) - 1
            Ctl.SelectionLength = 1
        Else
            If Act_SelStart = Len(Ctl.Text) Then
                '選択開始位置が一番右の場合
                ''                Select Case Ctl.NAME
                ''                    Case WLSHDNDT.NAME
                ''                        If IsDate(Ctl.Text) = True Then
                ''                            WLSHDNDT.ForeColor = COLOR_BLACK
                ''                            WLSHDNTRKB.SetFocus
                ''                        End If
                ''                End Select
            Else
                '選択開始位置が一番右でない場合

                '１つ右の１桁を取得
                Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)

                If Str_Wk = "" Then
                    '一番右へ移動し選択なし状態に
                    Ctl.SelectionStart = Len(Ctl.Text)
                    Ctl.SelectionLength = 0
                Else
                    '右に１桁ずつずらし入力可能な文字を検索
                    Next_SelStart = -1
                    '                    For Wk_Point = Act_SelStart + 1 To 0 Step -1       ' DEL 2007/02/20
                    For Wk_Point = Act_SelStart + 1 To 1 Step -1 ' ADD 2007/02/20

                        Str_Wk = Mid(Ctl.Text, Wk_Point, 1)

                        '日付/年月/時刻項目の場合
                        '入力可能文字＆と空白も移動可能
                        If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
                            Next_SelStart = Wk_Point - 1
                            Exit For
                        End If
                    Next

                    If Next_SelStart = -1 Then
                        '選択可能な文字がない場合
                        ''                Select Case Ctl.NAME
                        ''                    Case WLSHDNDT.NAME
                        ''                        If IsDate(Ctl.Text) = True Then
                        ''                            WLSHDNDT.ForeColor = COLOR_BLACK
                        ''                            WLSHDNTRKB.SetFocus
                        ''                        End If
                        ''                End Select
                    Else
                        '選択可能な文字がある場合

                        If Act_SelLength = 0 Then
                            '移動前の選択文字数がない場合
                            '同じ項目で移動する場合に選択文字数は継続する
                            Wk_SelLength = 0
                        Else
                            Wk_SelLength = 1
                        End If

                        Ctl.SelectionStart = Next_SelStart
                        Ctl.SelectionLength = Wk_SelLength
                    End If
                End If
            End If

        End If

    End Function


    Private Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer

        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/03/25 CHG START
        'CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))
        CF_Ctr_AnsiLenB = LenB(pm_Value)
        '2019/03/25 CHG E N D

        Exit Function

    End Function

    Private Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String

        'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/03/25 CHG START
        'CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
        CF_Ctr_AnsiLeftB = LeftB(pm_Value, pm_Len)
        '2019/03/25 CHG E N D

        Exit Function

    End Function


    Private Function GP_Get_NM(ByVal strNM As String, ByVal lngMR As Integer) As String

        Dim lngMoji As Integer
        Dim lngKeta As Integer

        lngMoji = 0
        lngKeta = 0
        GP_Get_NM = ""

        If AnsiLenB(strNM) <= lngMR Then
            GP_Get_NM = strNM
            Exit Function
        End If

        If AnsiLenB(strNM) > lngMR Then

            Do Until lngKeta >= lngMR
                lngMoji = lngMoji + 1
                'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
                '2019/03/25 CHG START
                'lngKeta = lngKeta + LenB(StrConv(Mid(strNM, lngMoji, 1), vbFromUnicode))
                lngKeta = lngKeta + LenB(Mid(strNM, lngMoji, 1))
                '2019/03/25 CHG E N D
            Loop

            If lngKeta > lngMR Then
                GP_Get_NM = VB.Left(strNM, lngMoji - 1)
            Else
                GP_Get_NM = VB.Left(strNM, lngMoji)
            End If
        End If

    End Function

    Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
        'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/03/25 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/03/25 CHG E N D
    End Function

    Function AnsiLenB(ByVal StrArg As String) As Integer
        '概要：文字数ｶｳﾝﾄ
        '引数：StrArg,Input,String,対象文字列
        '説明：Ansiｺｰﾄﾞのﾊﾞｲﾄｵｰﾀﾞで文字列のﾊﾞｲﾄ数を返す
#If Win32 Then
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/03/25 CHG START
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
        '2019/03/25 CHG E N D
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiLenB = LenB(StrArg)
#End If
    End Function

    ' StrConv を呼び出します。
    Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
        'UPGRADE_WARNING: オブジェクト flag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト StrArg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiStrConv = StrArg
#End If

    End Function

    Sub WLS_BaseSQL(Optional ByVal strKeyBak As String = " ")
        Dim strSQL As String
        Dim wkTOKCD As String
        Dim strSQLWhere As String
        'Dim strSQLWhereB   As String

        strSQL = ""
        strSQLWhere = ""
        ''''strSQLWhereB = ""

        '20190806 CHG START
        'wkTOKCD = WLSTOKCD.Text & Space(Len(DB_JDNTHA.TOKCD) - Len(WLSTOKCD.Text))
        If DB_JDNTHA.TOKCD Is Nothing Then
            wkTOKCD = WLSTOKCD.Text & Space(10 - Len(WLSTOKCD.Text))
        Else
            wkTOKCD = WLSTOKCD.Text & Space(Len(DB_JDNTHA.TOKCD) - Len(WLSTOKCD.Text))
        End If
        '20190806 CHG END


        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
        '    If (Trim$(WLSTOKCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TOKCD = '" & wkTOKCD & "' "
        '    If (Trim$(WLSTANCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TANCD = '" & WLSTANCD.Text & "' "
        '    If (Trim$(WLSJDNTRKB.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNTRKB = '" & WLSJDNTRKB.Text & "' "
        If (Trim(WLSTOKCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TOKCD = '" & AE_EditSQLText(wkTOKCD) & "' "
        If (Trim(WLSTANCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TANCD = '" & AE_EditSQLText(WLSTANCD.Text) & "' "
        If (Trim(WLSJDNTRKB.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "' "
        '''' UPD 2009/12/03  FKS) T.Yamamoto    End
        ''''If (Trim$(WLSDENDT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.DENDT > '" & DeCNV_DATE(WLSDENDT) & "' "
        If (Trim(WLSDENDT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.DENDT >= '" & DeCNV_DATE(WLSDENDT.Text) & "' "
        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
        '    If (Trim$(WLSKENNMA.Text) <> "") And (InStr(1, DB_JDNTHA.KENNMA, WLSKENNMA.Text) = 0) Then strSQLWhere = strSQLWhere & "   AND A.KENNMA LIKE '%" & WLSKENNMA.Text & "%' "
        If (Trim(WLSKENNMA.Text) <> "") And (InStr(1, DB_JDNTHA.KENNMA, WLSKENNMA.Text) = 0) Then strSQLWhere = strSQLWhere & "   AND A.KENNMA LIKE '%" & AE_EditSQLText(WLSKENNMA.Text) & "%' "
        '''' UPD 2009/12/03  FKS) T.Yamamoto    End

        ''''If (Trim$(WLSTOKCD.Text) <> "") Then strSQLWhereB = strSQLWhereB & "   AND TOKCD = '" & wkTOKCD & "' "
        ''''If (Trim$(WLSTANCD.Text) <> "") Then strSQLWhereB = strSQLWhereB & "   AND TANCD = '" & WLSTANCD.Text & "' "
        ''''If (Trim$(WLSJDNTRKB.Text) <> "") Then strSQLWhereB = strSQLWhereB & "   AND JDNTRKB = '" & WLSJDNTRKB.Text & "' "
        ''''If (Trim$(WLSDENDT.Text) <> "") Then strSQLWhereB = strSQLWhereB & "   AND DENDT < '" & DeCNV_DATE(WLSDENDT) & "' "
        ''''If (Trim$(WLSKENNMA.Text) <> "") And (InStr(1, DB_JDNTHA.KENNMA, WLSKENNMA.Text) = 0) Then strSQLWhereB = strSQLWhereB & "   AND KENNMA LIKE '%" & WLSKENNMA.Text & "%' "

        strSQL = "SELECT * FROM (    "
        'CHG START FKS)INABA 2009/02/27 ***********************************************************************************************************
        strSQL = strSQL & "SELECT /*+ ORDERED */ A.* FROM JDNTHC B, JDNTHA A"
        '    strSQL = strSQL & "SELECT A.* FROM JDNTHA A ,( SELECT JDNNO,MAX(DATNO) as DATNO FROM JDNTHA WHERE DENKB = '1'  GROUP BY JDNNO ) B"
        'CHG START FKS)INABA 2009/02/27 ***********************************************************************************************************
        strSQL = strSQL & " WHERE A.DATKB = '1' "
        strSQL = strSQL & "   AND A.DENKB = '1' "
        strSQL = strSQL & "   AND A.AKAKROKB = '1' "
        strSQL = strSQL & "   AND A.DATNO = B.DATNO "
        strSQL = strSQL & "   AND A.JDNNO = B.JDNNO "
        strSQL = strSQL & strSQLWhere
        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
        '    strSQL = strSQL & "   AND A.DATKB || A.DENKB || A.JDNNO >= '" & strKeyBak & "' "
        '20190606 CHG START
        'strSQL = strSQL & "   AND A.DATKB || A.DENKB || A.JDNNO >= '" & AE_EditSQLText(strKeyBak) & "' "
        strSQL = strSQL & "   AND A.JDNNO >= '" & AE_EditSQLText(strKeyBak) & "' "
        '20190606 CHG END

        '''' UPD 2009/12/03  FKS) T.Yamamoto    End
        strSQL = strSQL & "   Order By A.JDNNO ) C"

        '20190516 CHG START
        'Call DB_GetSQL2(WM_WLS_MFIL, strSQL)
        Call DB_GetTable(strSQL)
        '20190516 CHG END

    End Sub

    Private Sub WLSKENNMA_TextChanged(sender As Object, e As EventArgs) Handles WLSKENNMA.TextChanged

    End Sub

    Private Sub WLSJDNTRNM_Click(sender As Object, e As EventArgs) Handles WLSJDNTRNM.Click

    End Sub

    Private Sub WLSJDNTRKB_TextChanged(sender As Object, e As EventArgs) Handles WLSJDNTRKB.TextChanged

    End Sub
End Class