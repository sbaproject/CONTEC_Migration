Option Strict Off
Option Explicit On
Friend Class WLSTNK
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　単価履歴検索(５履歴表示)
	'*  プログラムＩＤ　：  WLSTNK
	'*  作成者　　　　　：　ACE)長澤
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
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "0" '開始コード入力属性 [0,X]

    '************************************************************************************
    '   Private変数
    '************************************************************************************
    'ウィンドﾕｰｻﾞｰ設定変数
    '20190619 chg start
    'Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_MFIL As Object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    '20190619 chg end

    'ウィンド内部使用変数
    Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray(5) As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_FORM_INIT
	'   概要：  画面初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		WM_WLS_MAX = 5 '画面表示件数
		'変数初期化
		WLSTNK_RTNCODE = ""
		Call WLS_Clear()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_TextSQL
	'   概要：  検索sql作成
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL()
		
		Select Case WLSTNK_TNKCD
			'販売単価履歴検索
			Case "1"
				Call WLS_TextSQL_TOK()
				
				'仕入単価履歴検索
			Case "2"
				Call WLS_TextSQL_SIR()
				
			Case Else
		End Select
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_TextSQL_TOK
	'   概要：  販売単価履歴検索sql作成
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL_TOK()
		
		Dim strSQL As String
		Dim intData As Short
		Dim intCnt As Short
		Dim strDate As String
		Dim strTanka As String
		Dim strTanka_Hide As String
		Dim curTanka As Decimal
		
		strSQL = ""
		strSQL = strSQL & " Select URITKDT00 " '販売単価設定日付０
		strSQL = strSQL & "      , HISURITK00 " '販売履歴単価０
		strSQL = strSQL & "      , URITKDT01 " '販売単価設定日付１
		strSQL = strSQL & "      , HISURITK01 " '販売履歴単価１
		strSQL = strSQL & "      , URITKDT02 " '販売単価設定日付２
		strSQL = strSQL & "      , HISURITK02 " '販売履歴単価２
		strSQL = strSQL & "      , URITKDT03 " '販売単価設定日付３
		strSQL = strSQL & "      , HISURITK03 " '販売履歴単価３
		strSQL = strSQL & "      , URITKDT04 " '販売単価設定日付４
		strSQL = strSQL & "      , HISURITK04 " '販売履歴単価４
		strSQL = strSQL & "      , URITKDT05 " '販売単価設定日付５
		strSQL = strSQL & "      , HISURITK05 " '販売履歴単価５
		strSQL = strSQL & "   from TOKMTB "
		strSQL = strSQL & "  Where DATKB = '1' "
		strSQL = strSQL & "    and TOKCD = '" & WLSTNK_CODE & "' "
		strSQL = strSQL & "    and HINCD = '" & WLSTNK_HINCD & "' "

        '20190319 CHG START
        ''DBアクセス
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        DB_GetTable(strSQL)
        '20190319 CHG END

		intCnt = 0

        '20190319 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	For intCnt = 0 To WM_WLS_MAX
        '		'単価設定日付
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		strDate = CF_Ora_GetDyn(Usr_Ody, "URITKDT0" & Trim(Str(intCnt)), "")
        '		If Trim(strDate) <> "" Then
        '			strDate = VB6.Format(strDate, "@@@@/@@/@@")
        '		Else
        '			strDate = Space(10)
        '		End If

        '		'販売履歴単価
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		strTanka = CF_Ora_GetDyn(Usr_Ody, "HISURITK0" & Trim(Str(intCnt)), "")
        '		If Trim(strTanka) <> "" Then
        '			curTanka = CDec(strTanka)
        '			strTanka = VB6.Format(curTanka, "###,###,##0.0###")
        '			strTanka = Space(16 - Len(strTanka)) & strTanka
        '			strTanka_Hide = Str(curTanka)
        '			strTanka_Hide = Space(14 - Len(strTanka_Hide)) & strTanka_Hide
        '		Else
        '			strTanka = Space(16)
        '			strTanka_Hide = Space(14)
        '		End If

        '		'販売履歴
        '		If intCnt = 0 Then
        '			' === 20070308 === UPDATE S - ACE)Nagasawa 売上後の入力可否制御の変更
        '			'                    WM_WLS_DSPArray(intCnt) = " (定価) " & strDate & _
        '			''                                              Space(8) & strTanka & _
        '			''                                              Space(11) & strTanka_Hide
        '			WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
        '			' === 20070308 === UPDATE E -
        '		Else
        '			WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
        '		End If

        '	Next intCnt
        'End If

        ''ダイナセットクローズ
        'Call CF_Ora_CloseDyn(Usr_Ody)

        If dsList.Tables("tableName").Rows.Count > 0 Then
            For intCnt = 0 To WM_WLS_MAX
                '単価設定日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strDate = DB_NullReplace(dsList.Tables("tableName").Rows(0).Item("URITKDT0" & Trim(Str(intCnt))), "")
                If Trim(strDate) <> "" Then
                    strDate = VB6.Format(strDate, "@@@@/@@/@@")
                Else
                    strDate = Space(10)
                End If

                '販売履歴単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strTanka = DB_NullReplace(dsList.Tables("tableName").Rows(0).Item("HISURITK0" & Trim(Str(intCnt))), "")
                If Trim(strTanka) <> "" Then
                    curTanka = CDec(strTanka)
                    strTanka = VB6.Format(curTanka, "###,###,##0.0###")
                    strTanka = Space(16 - Len(strTanka)) & strTanka
                    strTanka_Hide = Str(curTanka)
                    strTanka_Hide = Space(14 - Len(strTanka_Hide)) & strTanka_Hide
                Else
                    strTanka = Space(16)
                    strTanka_Hide = Space(14)
                End If

                '販売履歴
                If intCnt = 0 Then
                    ' === 20070308 === UPDATE S - ACE)Nagasawa 売上後の入力可否制御の変更
                    '                    WM_WLS_DSPArray(intCnt) = " (定価) " & strDate & _
                    ''                                              Space(8) & strTanka & _
                    ''                                              Space(11) & strTanka_Hide
                    WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
                    ' === 20070308 === UPDATE E -
                Else
                    WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
                End If

            Next intCnt
        End If
        '20190319 CHG END

		'リスト編集
		Call WLS_DspPage()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_TextSQL_SIR
	'   概要：  仕入単価履歴検索sql作成
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL_SIR()
		
		Dim strSQL As String
		Dim intData As Short
		Dim intCnt As Short
		Dim strDate As String
		Dim strTanka As String
		Dim strTanka_Hide As String
		Dim curTanka As Decimal
		
		strSQL = ""
		strSQL = strSQL & " Select SRETKDT00 " '仕入単価設定日付０
		strSQL = strSQL & "      , HISSRETK00 " '仕入履歴単価０
		strSQL = strSQL & "      , SRETKDT01 " '仕入単価設定日付１
		strSQL = strSQL & "      , HISSRETK01 " '仕入履歴単価１
		strSQL = strSQL & "      , SRETKDT02 " '仕入単価設定日付２
		strSQL = strSQL & "      , HISSRETK02 " '仕入履歴単価２
		strSQL = strSQL & "      , SRETKDT03 " '仕入単価設定日付３
		strSQL = strSQL & "      , HISSRETK03 " '仕入履歴単価３
		strSQL = strSQL & "      , SRETKDT04 " '仕入単価設定日付４
		strSQL = strSQL & "      , HISSRETK04 " '仕入履歴単価４
		strSQL = strSQL & "      , SRETKDT05 " '仕入単価設定日付５
		strSQL = strSQL & "      , HISSRETK05 " '仕入履歴単価５
		strSQL = strSQL & "   from SIRMTB "
		strSQL = strSQL & "  Where DATKB = '1' "
		strSQL = strSQL & "    and SIRCD = '" & WLSTNK_CODE & "' "
		strSQL = strSQL & "    and HINCD = '" & WLSTNK_HINCD & "' "

        '20190319 CHG START
        ''DBアクセス
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        DB_GetTable(strSQL)
        '20190319 CHG END
		
		intCnt = 0

        '20190319 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	For intCnt = 0 To WM_WLS_MAX
        '		'単価設定日付
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		strDate = CF_Ora_GetDyn(Usr_Ody, "SRETKDT0" & Trim(Str(intCnt)), "")
        '		If Trim(strDate) <> "" Then
        '			strDate = VB6.Format(strDate, "@@@@/@@/@@")
        '		Else
        '			strDate = Space(10)
        '		End If

        '		'仕入履歴単価
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		strTanka = CF_Ora_GetDyn(Usr_Ody, "HISSRETK0" & Trim(Str(intCnt)), "")
        '		If Trim(strTanka) <> "" Then
        '			curTanka = CDec(strTanka)
        '			strTanka = VB6.Format(curTanka, "###,###,##0.0###")
        '			strTanka = Space(16 - Len(strTanka)) & strTanka
        '			strTanka_Hide = Str(curTanka)
        '			strTanka_Hide = Space(14 - Len(strTanka_Hide)) & strTanka_Hide
        '		Else
        '			strTanka = Space(16)
        '			strTanka_Hide = Space(14)
        '		End If

        '		'仕入履歴
        '		If intCnt = 0 Then
        '			WM_WLS_DSPArray(intCnt) = " (定価) " & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
        '		Else
        '			WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
        '		End If

        '	Next intCnt
        'End If

        ''ダイナセットクローズ
        'Call CF_Ora_CloseDyn(Usr_Ody)

        If dsList.Tables("tableName").Rows.Count > 0 Then
            For intCnt = 0 To WM_WLS_MAX
                '単価設定日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strDate = DB_NullReplace(dsList.Tables("tableName").Rows(0).Item("SRETKDT0" & Trim(Str(intCnt))), "")
                If Trim(strDate) <> "" Then
                    strDate = VB6.Format(strDate, "@@@@/@@/@@")
                Else
                    strDate = Space(10)
                End If

                '仕入履歴単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strTanka = DB_NullReplace(dsList.Tables("tableName").Rows(0).Item("HISSRETK0" & Trim(Str(intCnt))), "")
                If Trim(strTanka) <> "" Then
                    curTanka = CDec(strTanka)
                    strTanka = VB6.Format(curTanka, "###,###,##0.0###")
                    strTanka = Space(16 - Len(strTanka)) & strTanka
                    strTanka_Hide = Str(curTanka)
                    strTanka_Hide = Space(14 - Len(strTanka_Hide)) & strTanka_Hide
                Else
                    strTanka = Space(16)
                    strTanka_Hide = Space(14)
                End If

                '仕入履歴
                If intCnt = 0 Then
                    WM_WLS_DSPArray(intCnt) = " (定価) " & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
                Else
                    WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
                End If

            Next intCnt
        End If
        '20190319 CHG END

		'リスト編集
		Call WLS_DspPage()
		
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
		
		LST.Items.Clear()
		
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		intCnt = 0
		Do While intCnt <= WM_WLS_MAX
			If Trim(Mid(WM_WLS_DSPArray(intCnt), 9, 10)) <> "" Then
				LST.Items.Add(WM_WLS_DSPArray(intCnt))
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
		
		Dim intCnt As Short
		
		'検索結果保持配列
		For intCnt = 0 To WM_WLS_MAX
			WM_WLS_DSPArray(intCnt) = ""
		Next intCnt
		
	End Sub
	'
	'以下は画面イベント処理
	'
	'UPGRADE_WARNING: Form イベント WLSTNK.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSTNK_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		Dim intSts As String
		Dim TOKMTA As TYPE_DB_TOKMTA
		Dim HINMTA As TYPE_DB_HINMTA
		
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WM_WLS_Dspflg = False
		
		HD_TOKRN.Text = ""
		HD_HINNMA.Text = ""
		HD_HINNMB.Text = ""
		LST.Items.Clear()
		
		'得意先名取得
		intSts = CStr(DSPTOKCD_SEARCH(WLSTNK_CODE, TOKMTA))
		HD_TOKRN.Text = TOKMTA.TOKRN
		
		'型式、品名取得
		intSts = CStr(DSPHINCD_SEARCH_B(WLSTNK_HINCD, HINMTA))
		HD_HINNMA.Text = HINMTA.HINNMA
		HD_HINNMB.Text = HINMTA.HINNMB
		
		'リスト表示
		Call WLS_TextSQL()
		
		WM_WLS_Dspflg = True
		
		DblClickFl = False
		
		Me.Refresh()
	End Sub
	
	Private Sub WLSTNK_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window初期設定
		Call WLS_FORM_INIT()
	End Sub
	
	' === 20060728 === INSERT S - ACE)Furukawa
	Private Sub HD_TOKRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Enter
		Call F_Ctl_HD_Focus()
	End Sub
	Private Sub HD_HINNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.Enter
		Call F_Ctl_HD_Focus()
	End Sub
	Private Sub HD_HINNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.Enter
		Call F_Ctl_HD_Focus()
	End Sub
	
	Private Function F_Ctl_HD_Focus() As Short
		If LST.Enabled = True Then
			' === 20061228 === INSERT S - ACE)Nagasawa
			On Error Resume Next
			' === 20061228 === INSERT E -
			LST.Focus()
		Else
			If WLSOK.Enabled = True Then
				' === 20061228 === INSERT S - ACE)Nagasawa
				On Error Resume Next
				' === 20061228 === INSERT E -
				WLSOK.Focus()
			End If
		End If
	End Function
	' === 20060728 === INSERT E
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSTNK_RTNCODE = Mid(VB6.GetItemString(LST, LST.SelectedIndex), 53)
		
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
		End Select
		
	End Sub
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		WLSTNK_RTNCODE = Mid(VB6.GetItemString(LST, LST.SelectedIndex), 53)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		Hide()
	End Sub
End Class