Option Strict Off
Option Explicit On
Friend Class WLSBMN
	Inherits System.Windows.Forms.Form
	'以下の ３行の設定を行うこと
	'    '検索キーNo（使用しない場合は-1を設定）
	Const WM_WLS_BmnKey As Short = 1

    'ウィンドﾕｰｻﾞｰ設定変数
    '20190808 CHG START
    'Dim WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_MFIL As Object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    '20190808 CHG END

    '   Dim WM_WLS_SFIL As Integer
    Dim WM_WLS_LEN As Short '文字数
	Dim WM_WLS_STTLEN As Short '開始ｺｰﾄﾞ入力文字数
	'    Dim WM_WLS_KANALEN As Integer       'カナ入力文字数
	'    Dim WM_WLS_TANLEN As Integer        '担当者名入力文字数
	
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
	Dim SWlsSelList As String
	Dim WlsHint As String
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	Dim DblClickFl As Boolean 'DblClickイベント障害対応  97/04/07
	
	Private Sub WLS_FORM_INIT()
		'=== WINDOW 表示ファイル設定 ===
		WM_WLS_MFIL = DBN_BMNMTA

        '=== 表示開始コード桁数設定 ===
        '20190808 DEL START
        'WM_WLS_LEN = Len(DB_BMNMTA.BMNCD) + Len(DB_BMNMTA.STTTKDT) 'LenWid はダメ
        '20190808 DEL END

        WlsSelList = "BMNCD,BMNNM,STTTKDT,ENDTKDT"
		SWlsSelList = "*"
        '=== ＬＡＢＥＬ設定 ===
        'UPGRADE_WARNING: オブジェクト WLSLABEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190807 CHG START
        'WLSLABEL = "部門ｺｰﾄﾞ 部門名                                   適用開始日 適用終了日"
        WLSLABEL.Text = "部門ｺｰﾄﾞ 部門名                                   適用開始日 適用終了日"
        '20190807 CHG END
        'XXXXX6　 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4 YYYY/MM/DD YYYY/MM/DD

        WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
	End Sub
	
	Private Function WLS_DSP_CHECK() As Object
		If DB_BMNMTA.BMNCD = "9" Then
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
		WM_WLS_DSPArray(ArrayCnt) = DB_BMNMTA.BMNCD & "   " & LeftWid(DB_BMNMTA.BMNNM, 40) & " " & CNV_DATE(DB_BMNMTA.STTTKDT) & " " & CNV_DATE(DB_BMNMTA.ENDTKDT) & "        " & DB_BMNMTA.BMNCD & DB_BMNMTA.STTTKDT
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WM_WLS_STTLEN = LenWid(WM_WLS_DSPArray(ArrayCnt))
		
	End Sub
	Sub WLS_BMNSQL()
		WM_WLS_KeyNo = WM_WLS_BmnKey
		''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WlsFromWhere = "From BMNMTA Where DATKB = '1' AND BMNCD >= '" & WM_WLS_STTKEY & "'"
		
		'WlsFromWhere = "From BMNMTA "
		WlsOrderBy = "Order By DATKB,BMNCD,STTTKDT"
		DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Private Sub WLS_DspNew()
		Dim WL_Mode As Short
		Dim cnt As Short
		
		WL_Mode = 0
        cnt = 0

        '20190808 CHG START
        '      Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
        '	'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	WL_Mode = WLS_DSP_CHECK()
        '	If WL_Mode = SSS_OK Then
        '		If cnt = 0 Then
        '			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '			WM_WLS_LastPage = WM_WLS_Pagecnt
        '			ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '		End If
        '		Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
        '		cnt = cnt + 1
        '	End If
        '	If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
        '		Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '	End If
        'Loop
        '      If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True


        Dim dt As DataTable = dsList.Tables(WM_WLS_MFIL)

        For i As Integer = 0 To dt.Rows.Count - 1

            '取得内容退避
            DB_BMNMTA.BMNCD = DB_NullReplace(dsList.Tables(WM_WLS_MFIL).Rows(i).Item("BMNCD"), "")
            DB_BMNMTA.BMNNM = DB_NullReplace(dsList.Tables(WM_WLS_MFIL).Rows(i).Item("BMNNM"), "")
            DB_BMNMTA.STTTKDT = DB_NullReplace(dsList.Tables(WM_WLS_MFIL).Rows(i).Item("STTTKDT"), "")
            DB_BMNMTA.ENDTKDT = DB_NullReplace(dsList.Tables(WM_WLS_MFIL).Rows(i).Item("ENDTKDT"), "")

            '表示改ページ
            If cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                '最終ページ退避
                WM_WLS_LastPage = WM_WLS_Pagecnt
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                cnt = 0
            End If

            '表示メモリ展開
            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)

            cnt = cnt + 1

        Next

        '取得データ有無に関わらず最終データ到達
        WM_WLS_LastFL = True

        WM_WLS_LEN = Len(DB_BMNMTA.BMNCD) + Len(DB_BMNMTA.STTTKDT) 'LenWid はダメ
        '20190808 CHG END

        If cnt > 0 Then
            '20190808 ADD START
            WM_WLS_Pagecnt = 0
            '20190808 ADD END
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
	'
	'以下は画面イベント処理
	'
	'UPGRADE_WARNING: Form イベント WLSBMN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSBMN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190808 DEL START
        '      '=== WINDOW 位置設定 ===
        '      Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        ''UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'WM_WLS_STTKEY = ""
        ''UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'WM_WLS_ENDKEY = System.DBNull.Value
        'WM_WLS_Dspflg = False

        'WM_WLS_Dspflg = True
        'WM_WLS_Pagecnt = -1
        'WM_WLS_LastPage = -1
        'WM_WLS_LastFL = False
        'ReDim WM_WLS_DSPArray(0)

        'Call WLS_BMNSQL()
        'Call WLS_DspNew()

        '      'DblClickイベント障害対応  97/04/07
        '      DblClickFl = False
        '20190808 DEL END

    End Sub

    Private Sub WLSBMN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window初期設定
        Call WLS_FORM_INIT()

        '20190808 ADD START
        '=== WINDOW 位置設定 ===
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_STTKEY = ""
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WM_WLS_ENDKEY = System.DBNull.Value
        WM_WLS_Dspflg = False

        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_BMNSQL()
        Call WLS_DspNew()

        'DblClickイベント障害対応  97/04/07
        DblClickFl = False
        '20190808 ADD END

    End Sub

    '20190808 ADD START
    Private Sub WLS_BMN1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.btnF1.PerformClick()

                Case Keys.F7
                    Me.btnF7.PerformClick()

                Case Keys.F8
                    Me.btnF8.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub
    '20190808 ADD END

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		Dim WM_WLS_MIDLEN As Short
		
		'DblClickイベント障害対応  97/04/07
		DblClickFl = True
		''''Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), WM_WLS_LEN)
		WM_WLS_MIDLEN = (WM_WLS_STTLEN + 1) - WM_WLS_LEN
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SlistCom = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_MIDLEN, WM_WLS_LEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'UnLoadイベント障害対応  97/04/07
        '20190808 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190808 CHG END
    End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KEYCODE
			Case System.Windows.Forms.Keys.Return
                '20190808 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190808 CHG END

            Case System.Windows.Forms.Keys.Escape
                '20190808 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190808 CHG END

            Case System.Windows.Forms.Keys.Left '←キー
                '20190808 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190808 CHG END

            Case System.Windows.Forms.Keys.Right '→キー
                '20190808 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190808 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
	End Sub

    '20190808 CHG START
    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '	If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '		If Not WM_WLS_LastFL Then Call WLS_DspNew()
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
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190808 CHG END

    '20190808 CHG START
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
    '20190808 CHG END

    '20190808 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	Dim WM_WLS_MIDLEN As Short
    '	''''Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), WM_WLS_LEN)
    '	WM_WLS_MIDLEN = (WM_WLS_STTLEN + 1) - WM_WLS_LEN
    '	'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	PP_SSSMAIN.SlistCom = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_MIDLEN, WM_WLS_LEN)
    '	'PP_SSSMAIN.SlistCom = MidWid$(LST.List(LST.ListIndex), WM_WLS_STTLEN, WM_WLS_LEN)
    '	Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '       'UnLoadイベント障害対応  97/04/07
    '       'Unload Me
    '       Hide()
    '   End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Dim WM_WLS_MIDLEN As Short
        ''''Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), WM_WLS_LEN)
        WM_WLS_MIDLEN = (WM_WLS_STTLEN + 1) - WM_WLS_LEN
        'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.SlistCom = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_MIDLEN, WM_WLS_LEN)
        'PP_SSSMAIN.SlistCom = MidWid$(LST.List(LST.ListIndex), WM_WLS_STTLEN, WM_WLS_LEN)
        Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        'UnLoadイベント障害対応  97/04/07
        'Unload Me
        Hide()
    End Sub
    '20190808 CHG END

End Class