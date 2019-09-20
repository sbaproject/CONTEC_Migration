Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSNDN
	Inherits System.Windows.Forms.Form
	
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　入金No一覧ウィンドウ
	'*  プログラムＩＤ　：  WLSNDN
	'*  作成者　　　　　：　RISE)森田
	'*  作成日　　　　　：  2008.09.05
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'*<02> 2009.03.18　：　前月度の元黒データに対して処理を行ってはいけない為。
	'*     RISE)宮島       ※データ処理は最新データに対してのみ実施する。
	'********************************************************************************
	
	'ウィンド内部使用変数
	Private DblClickFl As Boolean 'DblClickイベント障害対応  97/04/07
	
	Private SSS_CurPage As Short
	Private SSS_LastPage As Short
	Private SSS_PageLine As Short
	Private WRK_NKNDL01() As TYPE_DB_NKNDL01

    Private pv_blnChange_Flg As Boolean

    '20190729 ADD START
    Private TANCD_LEN As Object
    '20190729 ADD END

    Private Sub WLS_FORM_LOAD()
		Dim strLABEL As String
		
		'=== WINDOW 位置設定 ===
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		
		'=== ｺｰﾄﾞTEXT ===
		WLSTANCD.Text = ""
		WLSTANNM.Text = ""
		WLSNYUCD.Text = ""
		WLSNDNDT.Text = ""
		WLSTOKCD.Text = ""
		WLSTOKRN.Text = ""
		
		'=== ＬＡＢＥＬ設定 ===
		strLABEL = ""
		strLABEL = strLABEL & "入金日" & New String(" ", 5)
		strLABEL = strLABEL & "入金区分" & New String(" ", 3)
		strLABEL = strLABEL & "入金種別" & New String(" ", 3)
		strLABEL = strLABEL & "請求先" & New String(" ", 35)
		strLABEL = strLABEL & "入金額"
        'UPGRADE_WARNING: オブジェクト WLSLABEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190522 CHG START
        'WLSLABEL = strLABEL
        WLSLABEL.Text = strLABEL
        '20190522 CHG END
    End Sub
	
	Private Sub WLSSSS_FORM_INIT()
        SSS_PageLine = VB6.PixelsToTwipsY(LST.Height) \ 240

        '20190729 ADD START
        If DB_TANMTA.TANCD Is Nothing Then
            TANCD_LEN = "6"
        Else
            TANCD_LEN = LenWid(DB_TANMTA.TANCD)
        End If
        '20190729 ADD END

    End Sub
	
	Private Sub WLSSSS_FORM_ACTIVATE()
		''画面の入金種別欄に初期値「1」を表示
		WLSNYUCD.Text = "1"
	End Sub
	
	Private Sub WLS_DIS_CurrentPage(ByVal intPage As Short)
		'intPage：カレントぺ－ジ数
		Dim lngPOS As Integer
		Dim lngCnt As Integer
		Dim I As Integer
		Dim strNYUNM As String
		Dim strDKBNM As String
		Dim strTOKRN As String
		Dim strNYUKN As String
		Dim lngSW As Integer
		
		lngSW = 0
		
		LST.Items.Clear()
		LST1.Items.Clear()
		
		lngPOS = (intPage - 1) * SSS_PageLine + 1 '表示開始位置
		lngCnt = 0
		
		If UBound(WRK_NKNDL01) > 0 Then
			For I = lngPOS To UBound(WRK_NKNDL01)
				lngCnt = lngCnt + 1
				If lngCnt > SSS_PageLine Then Exit For
                '
                With WRK_NKNDL01(I)
                    '20190522 CHG START
                    'strNYUNM = AnsiTrimStringByByteCount(Trim(.NYUNM) & New String(" ", 10), 10)
                    'strDKBNM = AnsiTrimStringByByteCount(Trim(.DKBNM) & New String(" ", 10), 10)
                    'strTOKRN = AnsiTrimStringByByteCount(Trim(.TOKRN) & New String(" ", 40), 40)
                    strNYUNM = Trim(.NYUNM)
                    strDKBNM = Trim(.DKBNM)
                    strTOKRN = Trim(.TOKRN)
                    '20190522 CHG END

                    '入金の最大桁まで対応
                    strNYUKN = New String(" ", 19 - Len(VB6.Format(.NYUKN, "###,###,##0.0000"))) & VB6.Format(.NYUKN, "###,###,##0.0000")

                    LST.Items.Add(CNV_DATE(.UDNDT) & " " & strNYUNM & " " & strDKBNM & " " & strTOKRN & " " & strNYUKN)
                    LST1.Items.Add(.DATNO)
                End With
                '
                lngSW = 1
			Next 
		End If
		
		If lngSW = 1 Then LST.SelectedIndex = 0 '一覧リストにフォーカスをあてる
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub GET_UDNTRA_NKN
	'   概要：  検索処理
	'   引数：　なし
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub GET_UDNTRA_NKN()
		Dim lngCnt As Integer
		Dim I As Short
		Dim strMsg As String '検索結果用メッセージ
		Dim Retn_Code As Short
		Dim strDATNO As String
		Dim Tbl_Inf_NKNDL01() As TYPE_DB_NKNDL01
		
		'必須キー入力チェック
		If Trim(WLSTANCD.Text) = "" Then
			Call MsgBox("入力担当者 を入力してください。", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
			Call WLSTANCD.Focus()
			Exit Sub
		End If
		
		If Trim(WLSNYUCD.Text) = "" Then
			Call MsgBox("入金区分 を入力してください。", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
			Call WLSNYUCD.Focus()
			Exit Sub
		End If
		
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		Retn_Code = DSPNKNDL01_SEARCH(WLSTANCD.Text, WLSNYUCD.Text, DeCNV_DATE((WLSNDNDT.Text)), WLSTOKCD.Text, Tbl_Inf_NKNDL01)
		If Retn_Code <> 0 Then
			Me.Cursor = System.Windows.Forms.Cursors.Arrow
			Exit Sub
		End If
		
		WRK_NKNDL01 = VB6.CopyArray(Tbl_Inf_NKNDL01)
		
		lngCnt = UBound(Tbl_Inf_NKNDL01)
		
		'検索結果表示(100件以上)
		If lngCnt >= 100 Then
			strMsg = "検索結果：" & lngCnt & "件"
			
			If MsgBox(strMsg, MsgBoxStyle.OKCancel Or MsgBoxStyle.Question, Me.Text) = MsgBoxResult.Cancel Then
				LST.Items.Clear()
				LST1.Items.Clear()
				SSS_CurPage = 0 'カレントぺ－ジ数
				SSS_LastPage = 0
				Erase Tbl_Inf_NKNDL01
				Me.Cursor = System.Windows.Forms.Cursors.Arrow
				Exit Sub
			End If
		End If
		
		If lngCnt > 0 Then
			SSS_LastPage = Int((lngCnt - 1) / SSS_PageLine) + 1 '最終ぺ－ジ数
			SSS_CurPage = 1 'カレントぺ－ジ数
			Call WLS_DIS_CurrentPage(SSS_CurPage) 'カレントぺ－ジ表示
			Call LST.Focus()
		Else
			LST.Items.Clear()
			LST1.Items.Clear()
			SSS_CurPage = 0 'カレントぺ－ジ数
			SSS_LastPage = 0
			Erase Tbl_Inf_NKNDL01
			'データが存在しない時にメッセージを表示する。
			Call MsgBox("該当するデータが存在しません。", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
		End If
		
		Me.Cursor = System.Windows.Forms.Cursors.Arrow
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub COM_TANCD_Click
	'   概要：  入力担当者ボタンクリックイベント
	'   引数：　なし
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub COM_TANCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TANCD.Click
		Dim Mst_Inf_TANMTA As TYPE_DB_TANMTA
		
		WLSTAN_RTNCODE = ""

        '担当者検索画面コール
        WLSTAN1.ShowDialog() '0:入力候補一覧は入力後に残す指定。
        WLSTAN1.Close()

        System.Windows.Forms.Application.DoEvents()
		
		'データが選択された場合
		If WLSTAN_RTNCODE <> "" Then
			WLSTANCD.Text = WLSTAN_RTNCODE
			
			'担当者コードから検索
			If DSPTANCD_SEARCH(WLSTAN_RTNCODE, Mst_Inf_TANMTA) = 0 Then
				WLSTANNM.Text = Mst_Inf_TANMTA.TANNM
				
				'選択された時のみ検索を行う
				Call GET_UDNTRA_NKN()
			Else
				WLSTANNM.Text = ""
			End If
			
			WLSTAN_RTNCODE = ""
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub COM_UDNDT_Click
	'   概要：  入金日ボタンクリックイベント
	'   引数：　なし
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub COM_UDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_UDNDT.Click
		WLSDATE_RTNCODE = ""
		
		'カレンダー画面コール
		Set_date.Value = CNV_DATE(GV_UNYDate)
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		System.Windows.Forms.Application.DoEvents()
		
		'データが選択された場合
		If WLSDATE_RTNCODE <> "" Then
			WLSNDNDT.Text = WLSDATE_RTNCODE
			
			'選択された時のみ検索を行う
			Call GET_UDNTRA_NKN()
			
			WLSDATE_RTNCODE = ""
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub COM_TOKCD_Click
	'   概要：  得意先ボタンクリックイベント
	'   引数：　なし
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		
		WLSTOK_RTNCODE = ""
		
		'得意先検索画面コール
		WLSTOK6.ShowDialog() '0:入力候補一覧は入力後に残す指定。
		WLSTOK6.Close()
		
		System.Windows.Forms.Application.DoEvents()
		
		'データが選択された場合
		If WLSTOK_RTNCODE <> "" Then
			WLSTOKCD.Text = WLSTOK_RTNCODE
			
			If DSPTOKCD_SEARCH(WLSTOK_RTNCODE, Mst_Inf_TOKMTA) = 0 Then
				WLSTOKRN.Text = Mst_Inf_TOKMTA.TOKRN
				
				'選択された時のみ検索を行う
				Call GET_UDNTRA_NKN()
			Else
				WLSTOKRN.Text = ""
			End If
			
			WLSTOK_RTNCODE = ""
		End If
	End Sub
	
	'UPGRADE_WARNING: イベント WLSNDNDT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub WLSNDNDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNDNDT.TextChanged
		WLSNDNDT.SelectionLength = 1
		If pv_blnChange_Flg = True Then
			Exit Sub
		Else
			Call CtrlDatChange(WLSNDNDT)
		End If
	End Sub
	
	Private Sub WLSNDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNDNDT.Click
		WLSNDNDT.SelectionStart = 0
		WLSNDNDT.SelectionLength = 1
	End Sub
	
	Private Sub WLSNDNDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNDNDT.Enter
		If Len(Trim(WLSNDNDT.Text)) = 0 Then
			pv_blnChange_Flg = True
			WLSNDNDT.Text = Space(10)
			pv_blnChange_Flg = False
			WLSNDNDT.SelectionStart = 0
			WLSNDNDT.SelectionLength = 1
		ElseIf Len(Trim(WLSNDNDT.Text)) >= 8 Then 
			WLSNDNDT.SelectionStart = 8
			WLSNDNDT.SelectionLength = 1
		Else
			WLSNDNDT.SelectionStart = 0
			WLSNDNDT.SelectionLength = 1
		End If
	End Sub
	
	Private Sub WLSNDNDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles WLSNDNDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = System.Windows.Forms.Keys.Back Then
			KeyAscii = 0
			pv_blnChange_Flg = True
			If WLSNDNDT.SelectionStart > 0 Then
				WLSNDNDT.SelectionStart = WLSNDNDT.SelectionStart - 1
			End If
			WLSNDNDT.SelectionLength = 1
			Call PrevForcus(WLSNDNDT)
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
	
	Private Sub WLSNDNDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSNDNDT.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case True
			'ｴﾝﾀｰｷｰ押
			Case KeyCode = System.Windows.Forms.Keys.Return And Shift = 0
				If Trim(WLSNDNDT.Text) <> "" Then
					If CHECK_DATE(WLSNDNDT) = False Then
						Call MsgBox("日付に誤りがあります。修正してください。", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
						WLSNDNDT.Focus()
						Exit Sub
					End If
				End If
				Call GET_UDNTRA_NKN()
				
				'→押
			Case KeyCode = System.Windows.Forms.Keys.Right And Shift = 0
				KeyCode = 0
				'→制御
				If WLSNDNDT.SelectionStart < Len(WLSNDNDT.Text) Then
					WLSNDNDT.SelectionStart = WLSNDNDT.SelectionStart + 1
					WLSNDNDT.SelectionLength = 1
					Call NextForcus(WLSNDNDT)
				End If
				
				'↓押
			Case KeyCode = System.Windows.Forms.Keys.Down And Shift = 0
				'↓制御
				KeyCode = 0
				
				'↓押
			Case KeyCode = System.Windows.Forms.Keys.Up And Shift = 0
				'↓制御
				KeyCode = 0
				
				'←押
			Case KeyCode = System.Windows.Forms.Keys.Left And Shift = 0
				KeyCode = 0
				'←制御
				If WLSNDNDT.SelectionStart > 0 Then
					WLSNDNDT.SelectionStart = WLSNDNDT.SelectionStart - 1
					WLSNDNDT.SelectionLength = 1
					Call PrevForcus(WLSNDNDT)
				End If
				
			Case KeyCode = System.Windows.Forms.Keys.Delete And Shift = 0
				KeyCode = 0
				
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: イベント WLSTANCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub WLSTANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTANCD.TextChanged
		Dim S As Integer
		S = WLSTANCD.SelectionStart
		WLSTANCD.Text = StrConv(WLSTANCD.Text, VbStrConv.UpperCase)
		WLSTANCD.SelectionStart = S
	End Sub
	
	Private Sub WLSTANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTANCD.Enter
		WLSTANCD.SelectionStart = 0
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190729 CHG START
        'WLSTANCD.SelectionLength = LenWid(DB_TANMTA.TANCD)
        WLSTANCD.SelectionLength = TANCD_LEN
        '20190729 CHG END

    End Sub

    Private Sub WLSTANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTANCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Mst_Inf_TANMTA As TYPE_DB_TANMTA

        Select Case KeyCode
            Case 13
                '20190729 CHG START
                'WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, LenWid(DB_TANMTA.TANCD), "0")
                WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, TANCD_LEN, "0")
                '20190729 CHG END
                WLSTANCD.SelectionStart = 0
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190729 CHG START
                'WLSTANCD.SelectionLength = LenWid(DB_TANMTA.TANCD)
                WLSTANCD.SelectionLength = TANCD_LEN
                '20190729 CHG END

                If Trim(WLSTANCD.Text) = "" Then
                    WLSTANNM.Text = ""
                Else
                    '担当者コードから検索して、担当者名取得
                    If DSPTANCD_SEARCH(Trim(WLSTANCD.Text), Mst_Inf_TANMTA) = 0 Then
                        WLSTANNM.Text = Mst_Inf_TANMTA.TANNM
                    Else
                        '担当者名がない時ラベルをクリアする
                        WLSTANNM.Text = ""
                    End If
                End If
                Call GET_UDNTRA_NKN()

            Case 112 'F･１キー
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F･１キー
                System.Windows.Forms.SendKeys.Send("%2")
        End Select

    End Sub

    Private Sub WLSNYUCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSNYUCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000

        '20190823 ADD START
        Dim NYUCDLEN As Integer = 0

        If DB_UDNTHA.NYUCD Is Nothing Then
            NYUCDLEN = 1
        Else
            NYUCDLEN = LenWid(DB_UDNTHA.NYUCD)
        End If
        '20190823 ADD END

        Select Case KeyCode
            Case 13
                '20190823 CHG START
                '            WLSNYUCD.Text = SSS_EDTITM_WLS(WLSNYUCD.Text, LenWid(DB_UDNTHA.NYUCD), "0")
                'WLSNYUCD.SelectionStart = 0
                '            'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            WLSNYUCD.SelectionLength = LenWid(DB_UDNTHA.NYUCD)

                WLSNYUCD.Text = SSS_EDTITM_WLS(WLSNYUCD.Text, NYUCDLEN, "0")
                WLSNYUCD.SelectionStart = 0
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                WLSNYUCD.SelectionLength = NYUCDLEN
                '20190823 CHG END

                Call GET_UDNTRA_NKN()
				
			Case 112 'F･１キー
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F･１キー
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	Private Sub WLSNYUCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNYUCD.Enter
		WLSNYUCD.SelectionStart = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSNYUCD.SelectionLength = LenWid(DB_UDNTHA.NYUCD)
	End Sub
	
	'UPGRADE_WARNING: イベント WLSNYUCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub WLSNYUCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNYUCD.TextChanged
		Dim S As Integer
		S = WLSNYUCD.SelectionStart
		WLSNYUCD.Text = StrConv(WLSNYUCD.Text, VbStrConv.UpperCase)
		WLSNYUCD.SelectionStart = S
	End Sub
	
	'UPGRADE_WARNING: イベント WLSTOKCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub WLSTOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.TextChanged
		Dim S As Integer
		S = WLSTOKCD.SelectionStart
		WLSTOKCD.Text = StrConv(WLSTOKCD.Text, VbStrConv.UpperCase)
		WLSTOKCD.SelectionStart = S
	End Sub
	
	Private Sub WLSTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.Enter
		WLSTOKCD.SelectionStart = 0
		WLSTOKCD.SelectionLength = 0
	End Sub
	
	Private Sub WLSTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTOKCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		
		Select Case KeyCode
			Case 13
				WLSTOKCD.SelectionStart = 0
				WLSTOKCD.SelectionLength = 0
				If Trim(WLSTOKCD.Text) = "" Then
					WLSTOKRN.Text = ""
				Else
					'得意先コードから検索して、得意先名取得
					If DSPTOKCD_SEARCH(Trim(WLSTOKCD.Text), Mst_Inf_TOKMTA) = 0 Then
						WLSTOKRN.Text = Mst_Inf_TOKMTA.TOKRN
					Else
						'得意先名がない時ラベルをクリアする
						WLSTOKRN.Text = ""
					End If
				End If
				Call GET_UDNTRA_NKN()
				
			Case 112 'F･１キー
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F･１キー
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: Form イベント WLSNDN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSNDN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190726 DEL START
        'Call WLSSSS_FORM_ACTIVATE()
        'DblClickFl = False
        '20190726 DEL END

    End Sub

    Private Sub WLSNDN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call WLS_FORM_LOAD()
        Call WLSSSS_FORM_INIT()

        '20190726 ADD START
        Call WLSSSS_FORM_ACTIVATE()
        DblClickFl = False
        '20190726 ADD END

    End Sub


    '20190726 ADD START
    Private Sub WLSNDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190726 ADD END


    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		DblClickFl = True
		WLSNDN_RTNCODE = LeftWid(VB.Right(VB6.GetItemString(LST1, LST.SelectedIndex), 10), 10) 'DATNOを返す。
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			Case 13
				WLSNDN_RTNCODE = LeftWid(VB.Right(VB6.GetItemString(LST1, LST.SelectedIndex), 10), 10) 'DATNOを返す。
                '20190726 CHG START
                'If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                If DblClickFl = False Then Call btnF12_Click(btnF12, New System.EventArgs())
                '20190726 CHG END

            Case 27
                '20190726 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190726 CHG END

            Case 37 '←キー
                '20190726 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190726 CHG END

            Case 39 '→キー
                '20190726 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190726 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
			Case 112 'F･１キー
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F･１キー
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        '20190726 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190726 CHG END

    End Sub

    '20190726 DEL START
    '   Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
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
    '20190726 DEL END

    '20190726 CHG START
    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	Hide()
    'End Sub

    'Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click

    '	If SSS_CurPage > 1 Then
    '		SSS_CurPage = SSS_CurPage - 1
    '		Call WLS_DIS_CurrentPage(SSS_CurPage)
    '	Else
    '		Call MsgBox("これ以下は有りません、検索条件を再入力して下さい。", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
    '		Exit Sub
    '	End If

    'End Sub

    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '       If SSS_CurPage < SSS_LastPage Then
    '           SSS_CurPage = SSS_CurPage + 1
    '           Call WLS_DIS_CurrentPage(SSS_CurPage)
    '       Else
    '           Call MsgBox("これ以上は有りません、検索条件を再入力して下さい。", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
    '       End If

    '   End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Hide()
    End Sub

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click

        If SSS_CurPage > 1 Then
            SSS_CurPage = SSS_CurPage - 1
            Call WLS_DIS_CurrentPage(SSS_CurPage)
        Else
            Call MsgBox("これ以下は有りません、検索条件を再入力して下さい。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

    End Sub

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click

        If SSS_CurPage < SSS_LastPage Then
            SSS_CurPage = SSS_CurPage + 1
            Call WLS_DIS_CurrentPage(SSS_CurPage)
        Else
            Call MsgBox("これ以上は有りません、検索条件を再入力して下さい。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, Me.Text)
        End If

    End Sub
    '20190726 CHG END


    '20190726 DEL START
    '   Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
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
    '20190726 DEL END

    '20190726 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub
    '20190726 CHG END

    '20190522 DEL START
    '    Public Function AnsiTrimStringByByteCount(ByRef ArgSrc As String, ByRef ArgCnt As Integer) As String
    '		'概要：全角半角まじりのＵｎｉＣｏｄｅ文字列を、   ■■■■
    '		'                   文字をきらないように指定されたバイト数に丸めた文字列を返す。
    '		'                                                 ■■■■
    '		'引数：ArgSrc ,Input ,String ,元の文字列
    '		'　　：ArgCnt ,Input ,Long   ,丸める文字数

    '		Dim strResult As String
    '		Dim strTmpChr As String
    '		Dim lngLength As Integer
    '		Dim lngCalCnt As Integer
    '		Dim lngTmpCnt As Integer
    '		Dim lngI As Integer

    '		strResult = ""
    '		lngLength = Len(Trim(ArgSrc))
    '		lngCalCnt = 0
    '		For lngI = 1 To lngLength
    '			strTmpChr = Mid(ArgSrc, lngI, 1)
    '			lngTmpCnt = AnsiLenB(strTmpChr)
    '			If lngCalCnt + lngTmpCnt > ArgCnt Then
    '				GoTo AnsiTrimStringByByteCount_End
    '			Else
    '				lngCalCnt = lngCalCnt + lngTmpCnt
    '				strResult = strResult & strTmpChr
    '			End If
    '		Next 

    'AnsiTrimStringByByteCount_End: 

    '		If AnsiLenB(strResult) < ArgCnt Then
    '			AnsiTrimStringByByteCount = strResult & New String(" ", ArgCnt - AnsiLenB(strResult))
    '		Else
    '			AnsiTrimStringByByteCount = strResult
    '		End If

    '	End Function

    '	Public Function AnsiTrimStringByMojiCount(ByRef strSrc As String, ByRef lngDstCount As Integer) As String
    '		'概要：全角半角まじりのＵｎｉＣｏｄｅ文字列を、   ■■■
    '		'                   文字をきらないように指定された文字数（≠バイト数）に丸めた文字列を返す。
    '		'                                                 ■■■
    '		'引数：strSrc     ,Input,String,元の文字列
    '		'　　：lngDstCount,Input,Long,丸める文字数
    '		Dim strDst As String
    '		Dim strTmp As String
    '		Dim lngSrcCount As Integer
    '		Dim lngCalCount As Integer
    '		Dim lngTmpCount As Integer
    '		Dim strFmt As String
    '		Dim lngI As Integer

    '		strDst = ""
    '		lngSrcCount = Len(strSrc)
    '		lngCalCount = 0
    '		For lngI = 1 To lngSrcCount
    '			strTmp = Mid(strSrc, lngI, 1)
    '			lngTmpCount = AnsiLenB(strTmp)
    '			If lngCalCount + lngTmpCount > lngDstCount Then
    '				GoTo AnsiTrimStringByMojiCount_End
    '			Else
    '				lngCalCount = lngCalCount + lngTmpCount
    '				strDst = strDst & strTmp
    '			End If
    '		Next 

    'AnsiTrimStringByMojiCount_End: 

    '		strFmt = "!"
    '		For lngI = 1 To lngDstCount
    '			strFmt = strFmt & "@"
    '		Next 
    '		strDst = VB6.Format(strDst, strFmt)
    '		AnsiTrimStringByMojiCount = strDst

    '	End Function

    '    Public Function AnsiInStrB(ByRef varArg1 As Object, ByRef varArg2 As Object, Optional ByRef varArg3 As Object = Nothing) As Integer
    '		'概要：文字列位置の検索
    '		'引数：varArg1,Input,Variant,検索開始位置 or 検索対象文字列
    '		'　　：varArg2,Input,Variant,検索文字列
    '		'　　：varArg3,Input,Variant(Optional),検索文字列(省略可能)
    '		'説明Ａｎｓｉコードのバイトオーダで検索文字列の文字位置(文字数)を返す
    '		Dim lngPOS As Integer

    '#If Win32 Then
    '		If IsNumeric(varArg1) Then
    '			'UPGRADE_WARNING: オブジェクト varArg1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			'UPGRADE_WARNING: オブジェクト varArg2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '			lngPOS = LenB(AnsiLeftB(varArg2, varArg1))
    '			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '			'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '			AnsiInStrB = InStrB(varArg1, AnsiStrConv(varArg2, vbFromUnicode), AnsiStrConv(varArg3, vbFromUnicode))
    '		Else
    '			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '			'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '			AnsiInStrB = InStrB(AnsiStrConv(varArg1, vbFromUnicode), AnsiStrConv(varArg2, vbFromUnicode))
    '		End If
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		If IsNumeric(varArg1) Then
    '		lngPOS = LenB(LeftB(varArg2, varArg1))
    '		AnsiInStrB = InStrB(varArg1, varArg2, varArg3)
    '		Else
    '		AnsiInStrB = InStrB(varArg1, varArg2)
    '		End If
    '#End If

    '	End Function

    '	Public Function AnsiLeftB(ByVal StrArg As String, ByVal lngArg As Integer) As String
    '		'概要：左詰め文字列の抽出
    '		'引数：strArg,Input,String,抽出元文字列
    '		'　　：lngArg,Input,Long,抽出文字数
    '		'説明：Ａｎｓｉコードのバイトオーダで文字列の左端から文字数分の文字列を返す

    '#If Win32 Then
    '		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '		'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '		'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), lngArg), vbUnicode)
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		AnsiLeftB = LeftB(StrArg, lngArg)
    '#End If

    '	End Function

    '	Public Function AnsiLenB(ByVal StrArg As String) As Integer
    '		'概要：文字数カウント
    '		'引数：strArg,Input,String,対象文字列
    '		'説明：Ａｎｓｉコードのバイトオーダで文字列のﾊﾞｲﾄ数を返す

    '#If Win32 Then
    '		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '		'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '		AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		AnsiLenB = LenB(StrArg)
    '#End If

    '	End Function

    '	Public Function AnsiMidB(ByVal StrArg As String, ByVal lngArg As Integer, Optional ByRef varArg As Object = Nothing) As String
    '		'概要：文字列の抽出
    '		'引数：strArg,Input,String,抽出元文字列
    '		'　　：lngArg,Input,Long,先頭からの抽出開始位置
    '		'　　：varArg,Input,Variant(Optional),抽出文字数(省略可能)
    '		'説明：Ａｎｓｉコードのバイトオーダで文字列の抽出開始位置から文字数分の文字列を返す

    '#If Win32 Then
    '		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
    '		If IsNothing(varArg) Then
    '			'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '			'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '			'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode), lngArg), vbUnicode)
    '		Else
    '			'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '			'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '			'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode), lngArg, varArg), vbUnicode)
    '		End If
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		If IsMissing(varArg) Then
    '		AnsiMidB = MidB(StrArg, lngArg)
    '		Else
    '		AnsiMidB = MidB(StrArg, lngArg, varArg)
    '		End If
    '#End If

    '	End Function

    '	Public Function AnsiRightB(ByVal StrArg As String, ByVal lngArg As Integer) As String
    '		'概要：右詰め文字列の抽出
    '		'引数：strArg,Input,String,抽出元文字列
    '		'　　：lngArg,Input,Long,抽出文字数
    '		'説明：Ａｎｓｉコードのバイトオーダで文字列の右端から文字数分の文字列を返す

    '#If Win32 Then
    '		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '		'UPGRADE_ISSUE: RightB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '		'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		AnsiRightB = AnsiStrConv(RightB(AnsiStrConv(StrArg, vbFromUnicode), lngArg), vbUnicode)
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		AnsiRightB = RightB(StrArg, lngArg)
    '#End If

    '	End Function
    '20190522 DEL END

    Public Function AnsiStrConv(ByRef varArg As Object, ByRef varCnv As Object) As Object
		'概要：文字列のｺｰﾄﾞ変換
		'引数：varArg,Input,Variant,変換元文字列
		'　　：varCnv,Input,Variant,conversion定数(StrConv 関数参照)
		'説明：Ａｎｓｉ ⇔ ＵｎｉＣｏｄｅに変換した文字列を返す
		
#If Win32 Then
		'UPGRADE_WARNING: オブジェクト varCnv の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト varArg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiStrConv = StrConv(varArg, varCnv)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiStrConv = varArg
#End If
		
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
	
	Private Function PrevForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object
		
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

    '20190522 DEL START
    '   Private Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer

    '	'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '	CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))

    'End Function

    '   Private Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String

    '       'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '       'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '       'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '       CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)

    '   End Function
    '20190522 DEL END

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_NKNDL01_Clear
    '   概要：  入金データ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_NKNDL01_Clear(ByRef pot_DB_NKNDL01 As TYPE_DB_NKNDL01)
		
		Dim Clr_DB_NKNDL01 As TYPE_DB_NKNDL01
		
		'UPGRADE_WARNING: オブジェクト pot_DB_NKNDL01 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_DB_NKNDL01 = Clr_DB_NKNDL01
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPNKNDL01_SEARCH
	'   概要：  入金データ検索
	'   引数：  pin_strTANCD     : 入力担当者
	'           pin_strNYUCD     : 入金区分
	'           pin_strNDNDT     : 入金日
	'           pin_strTOKCD     : 得意先
	'           pot_DB_NKNDL01   : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function DSPNKNDL01_SEARCH(ByVal pin_strTANCD As String, ByVal pin_strNYUCD As String, ByVal pin_strNDNDT As String, ByVal pin_strTOKCD As String, ByRef pot_DB_NKNDL01() As TYPE_DB_NKNDL01) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strSubSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            '20190522 DEL START
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPNKNDL01_SEARCH
            '20190522 DEL END

            DSPNKNDL01_SEARCH = 9

            '20190619 DEL START URKET52から呼ばれる場合は必要
            'Debug.Print("START " & GetLocalTimeText())
            '20190619 DEL END

            '戻り値のクリア
            Erase pot_DB_NKNDL01

            '最新の伝票番号を取得して使う(複数伝票番号)
            strSubSQL = ""
            strSubSQL = strSubSQL & " SELECT /*+ INDEX UDNTHA X_UDNTHA94 */ MAX(DATNO) AS DATNO "
            strSubSQL = strSubSQL & " FROM UDNTHA "

            '条件：入力担当者
            strSubSQL = strSubSQL & " WHERE OPEID = '" & CF_Ora_Sgl(pin_strTANCD) & "'"
            '    If Trim(pin_strTANCD) <> "" Then
            '        strSubSQL = strSubSQL & " AND OPEID = '" & CF_Ora_Sgl(pin_strTANCD) & "'"
            '    End If

            '条件：入金区分
            strSubSQL = strSubSQL & " AND NYUCD = '" & CF_Ora_Sgl(pin_strNYUCD) & "'"
            '    If Trim(pin_strNYUCD) <> "" Then
            '        strSubSQL = strSubSQL & " AND NYUCD = '" & CF_Ora_Sgl(pin_strNYUCD) & "'"
            '    End If

            '条件：入金日
            If Trim(pin_strNDNDT) <> "" Then
                strSubSQL = strSubSQL & " AND UDNDT >= '" & CF_Ora_Sgl(pin_strNDNDT) & "'"
            End If

            '条件：得意先
            If Trim(pin_strTOKCD) <> "" Then
                strSubSQL = strSubSQL & " AND TOKCD >= '" & CF_Ora_Sgl(pin_strTOKCD) & "'"
                strSubSQL = strSubSQL & " AND TOKCD <= '" & CF_Ora_Sgl(pin_strTOKCD) & "'"
            End If

            strSubSQL = strSubSQL & " GROUP BY UDNNO "

            'メインSQL
            strSQL = ""
            strSQL = strSQL & " SELECT R.DATNO "
            strSQL = strSQL & "      , R.LINNO "
            strSQL = strSQL & "      , R.UDNNO "
            strSQL = strSQL & "      , R.UDNDT "
            strSQL = strSQL & "      , H.NYUCD "
            strSQL = strSQL & "      , (CASE WHEN H.NYUCD = '1' THEN '入金' "
            strSQL = strSQL & "              WHEN H.NYUCD = '2' THEN '前受入金' "
            strSQL = strSQL & "              ELSE '' "
            strSQL = strSQL & "         END "
            strSQL = strSQL & "        ) AS NYUNM "
            strSQL = strSQL & "      , NULL AS NYUKB "
            strSQL = strSQL & "      , R.DKBNM "
            strSQL = strSQL & "      , R.TOKCD "
            strSQL = strSQL & "      , R.TOKSEICD "
            strSQL = strSQL & "      , T.TOKRN "
            strSQL = strSQL & "      , (CASE WHEN T.FRNKB = '1' THEN R.FNYUKN "
            strSQL = strSQL & "              ELSE R.NYUKN "
            strSQL = strSQL & "         END "
            strSQL = strSQL & "        ) AS NYUKN "
            strSQL = strSQL & " FROM UDNTHA H "
            strSQL = strSQL & "    , UDNTRA R "
            strSQL = strSQL & "    , (SELECT * FROM TOKMTA WHERE DATKB = '1') T "
            strSQL = strSQL & " WHERE R.DATNO IN ( " & strSubSQL & " ) "
            strSQL = strSQL & "   AND R.DATKB    = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "   AND R.DENKB    = '8' "
            strSQL = strSQL & "   AND R.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
            strSQL = strSQL & "   AND R.DATNO = H.DATNO "
            strSQL = strSQL & "   AND R.TOKSEICD = T.TOKCD (+) "
            ' <02> 2009.03.18 ↓ADD
            strSQL = strSQL & "   AND NOT EXISTS (SELECT * FROM UDNTHA B WHERE R.DATNO = B.MOTDATNO)"
            ' <02> 2009.03.18 ↑ADD
            strSQL = strSQL & " ORDER BY R.UDNDT "
            strSQL = strSQL & "        , H.NYUCD "
            strSQL = strSQL & "        , R.DKBID "
            strSQL = strSQL & "        , R.TOKSEICD "
            strSQL = strSQL & "        , R.UDNNO "
            strSQL = strSQL & "        , R.LINNO "

            Debug.Print("  SQL " & strSQL)

            'DBアクセス
            '20190522 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '20190522 CHG END

            ReDim pot_DB_NKNDL01(0)

            '取得データ退避
            intData = 1
            '20190522 CHG START
            'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            '    ReDim Preserve pot_DB_NKNDL01(intData)

            '    Call DB_NKNDL01_SetData(Usr_Ody_LC, pot_DB_NKNDL01(intData))

            '    Call CF_Ora_MoveNext(Usr_Ody_LC)

            '    intData = intData + 1
            'Loop
            For i As Integer = 0 To dt.Rows.Count - 1
                ReDim Preserve pot_DB_NKNDL01(intData)

                Call Set_DB_NKNDL01(dt, pot_DB_NKNDL01(intData), i)
                intData = intData + 1
            Next
            '20190522 CHG END

            '20190619 DEL START URKET52から呼ばれる場合は必要
            'Debug.Print("E N D " & GetLocalTimeText())
            '20190619 DEL END

            DSPNKNDL01_SEARCH = 0

            'END_DSPNKNDL01_SEARCH:
            '            'クローズ
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPNKNDL01_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPNKNDL01_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function


    '20190522 CHG START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_NKNDL01_SetData
    '   概要：  入金データ構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Sub DB_NKNDL01_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_NKNDL01 As TYPE_DB_NKNDL01)
    '    'データ退避
    '    With pot_DB_NKNDL01
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .DATNO = CF_Ora_GetDyn(pin_Usr_Ody, "DATNO", "") '伝票管理NO.
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .LINNO = CF_Ora_GetDyn(pin_Usr_Ody, "LINNO", "") '行番号
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .UDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "UDNNO", "") '売上伝票番号
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .UDNDT = CF_Ora_GetDyn(pin_Usr_Ody, "UDNDT", "") '売上伝票日付
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .NYUCD = CF_Ora_GetDyn(pin_Usr_Ody, "NYUCD", "") '入金区分
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .NYUNM = CF_Ora_GetDyn(pin_Usr_Ody, "NYUNM", "") '入金区分名称
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .NYUKB = CF_Ora_GetDyn(pin_Usr_Ody, "NYUKB", "") '入金種別
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .DKBNM = CF_Ora_GetDyn(pin_Usr_Ody, "DKBNM", "") '取引区分名称
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .TOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCD", "") '得意先コード
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .TOKSEICD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSEICD", "") '請求先コード
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .TOKRN = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRN", "") '得意先略称
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .NYUKN = CF_Ora_GetDyn(pin_Usr_Ody, "NYUKN", "") '入金額
    '    End With
    'End Sub

    Private Sub Set_DB_NKNDL01(ByRef pDT As DataTable, ByRef pot_DB_NKNDL01 As TYPE_DB_NKNDL01, ByVal DataCount As Integer)

        With pot_DB_NKNDL01
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATNO = DB_NullReplace(pDT.Rows(DataCount)("DATNO"), "") '伝票管理NO.
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LINNO = DB_NullReplace(pDT.Rows(DataCount)("LINNO"), "") '行番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UDNNO = DB_NullReplace(pDT.Rows(DataCount)("UDNNO"), "") '売上伝票番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UDNDT = DB_NullReplace(pDT.Rows(DataCount)("UDNDT"), "") '売上伝票日付
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUCD = DB_NullReplace(pDT.Rows(DataCount)("NYUCD"), "") '入金区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUNM = DB_NullReplace(pDT.Rows(DataCount)("NYUNM"), "") '入金区分名称
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUKB = DB_NullReplace(pDT.Rows(DataCount)("NYUKB"), "") '入金種別
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DKBNM = DB_NullReplace(pDT.Rows(DataCount)("DKBNM"), "") '取引区分名称
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKCD = DB_NullReplace(pDT.Rows(DataCount)("TOKCD"), "") '得意先コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKSEICD = DB_NullReplace(pDT.Rows(DataCount)("TOKSEICD"), "") '請求先コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKRN = DB_NullReplace(pDT.Rows(DataCount)("TOKRN"), "") '得意先略称
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUKN = DB_NullReplace(pDT.Rows(DataCount)("NYUKN"), "") '入金額
        End With

    End Sub
    '20190522 CHG END

End Class