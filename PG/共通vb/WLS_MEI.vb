Option Strict Off
Option Explicit On
Friend Class WLS_MEI
	Inherits System.Windows.Forms.Form
    '********************************************************************************
    '*  システム名　　　：  新総合情報システム
    '*  サブシステム名　：　販売システム
    '*  機能　　　　　　：　検索ウィンドウ
    '*  プログラム名　　：　名称マスタ検索
    '*  プログラムＩＤ　：  WLS_MEI
    '*  作成者　　　　　：　ACE)高橋
    '*  作成日　　　　　：  2006.05.12
    '*-------------------------------------------------------------------------------
    '*<01> YYYY.MM.DD　：　修正情報
    '*     修正者
    '********************************************************************************

    'ウィンドﾕｰｻﾞｰ設定変数
    Private WM_WLS_MEICDALEN As Short 'コード１文字数
    Private WM_WLS_MEINMALEN As Short '名称１文字数
	
	'ウィンド内部使用変数
	Private WM_WLS_DSP_Caption As String '画面ｷｬﾌﾟｼｮﾝ表示データ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	
	' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
	Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	' === 20060828 === INSERT E -
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private DB_MEIMTA_W As TYPE_DB_MEIMTA '検索結果退避
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_FORM_INIT
	'   概要：  画面初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		'=== 表示桁数設定 ===
		' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
		WM_WLS_MAX = 15 '画面表示件数
		' === 20060828 === INSERT E -

        WM_WLS_MEICDALEN = Len(DB_MEIMTA_W.MEICDA) 'LenWid はダメ
        WM_WLS_MEINMALEN = Len(DB_MEIMTA_W.MEINMA) 'LenWid はダメ

		'変数初期化
		WLSMEI_RTNMEICDA = ""
		WLSMEI_RTNMEINMA = ""
		'変数初期化
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

        '20190319 CHG START
        'WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_MEIMTA_W.MEICDA, WM_WLS_MEICDALEN) & Space(1) & LeftWid(DB_MEIMTA_W.MEINMA, WM_WLS_MEINMALEN)
        WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_MEIMTA_W.MEICDA, LenB(DB_MEIMTA_W.MEICDA)) & Space(1) & LeftWid(DB_MEIMTA_W.MEINMA, LenB(DB_MEIMTA_W.MEINMA))
        '20190319 CHG END

	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_TextSQL
	'   概要：  検索sql作成
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_TextSQL()
		Dim strSQL As String
		
		strSQL = ""
		strSQL = strSQL & " Select KEYCD " 'キー
		strSQL = strSQL & "      , MEIKMKNM " '項目名
		strSQL = strSQL & "      , MEICDA " 'コード１
		strSQL = strSQL & "      , MEINMA " '名称１
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "   and  KEYCD = '" & WLSMEI_KEYCD & "'"
		strSQL = strSQL & "   order by "
		strSQL = strSQL & "        KEYCD " 'キー
		' === 20060726 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "      , DSPORD " '表示順序
		' === 20060726 === INSERT E -
		strSQL = strSQL & "      , MEICDA " 'コード１
		
		' === 20060828 === UPDATE S - ACE)Nagasawa ▲▼ボタン追加
		'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)    'DBアクセス
		
		If Dyn_Open = True Then
			'クローズ
            'Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If

        '20190319 CHG START
        'DBアクセス
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        'dsList.Tables("tableName").Clear()
        DB_GetTable(strSQL)
        '20190319 CHG END

		Dyn_Open = True
		LST.Items.Clear()
		' === 20060828 === UPDATE E -
		
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

        '	' === 20060828 === DELETE S - ACE)Nagasawa ▲▼ボタン追加
        '	'        If Cnt > 0 Then
        '	'            ReDim Preserve WM_WLS_DSPArray(Cnt)
        '	'        End If
        '	' === 20060828 === DELETE E -

        '	'取得内容退避
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_MEIMTA_W.KEYCD = CF_Ora_GetDyn(Usr_Ody, "KEYCD", "") 'キー
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_MEIMTA_W.MEIKMKNM = CF_Ora_GetDyn(Usr_Ody, "MEIKMKNM", "") '項目名
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_MEIMTA_W.MEICDA = CF_Ora_GetDyn(Usr_Ody, "MEICDA", "") 'コード１
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_MEIMTA_W.MEINMA = CF_Ora_GetDyn(Usr_Ody, "MEINMA", "") '名称１

        '	'表示メモリ展開
        '	' === 20060828 === UPDATE S - ACE)Nagasawa ▲▼ボタン追加
        '	'        '１件目は画面ｷｬﾌﾟｼｮﾝ用
        '	'        If Cnt = 0 Then
        '	'            WM_WLS_DSP_Caption = DB_MEIMTA_W.MEIKMKNM
        '	'        End If
        '	'
        '	'        Call WLS_SetArray(Cnt)

        '	'１件目は画面ｷｬﾌﾟｼｮﾝ用
        '	If Cnt = 0 And WM_WLS_Pagecnt = -1 Then
        '		WM_WLS_DSP_Caption = DB_MEIMTA_W.MEIKMKNM
        '	End If

        '	'表示改ページ
        '	If Cnt Mod WM_WLS_MAX = 0 Then
        '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '		ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '		Cnt = 0
        '		'最終ページ退避
        '		WM_WLS_LastPage = WM_WLS_Pagecnt
        '	End If

        '	Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)
        '	' === 20060828 === UPDATE E -

        '	Cnt = Cnt + 1

        '	Call CF_Ora_MoveNext(Usr_Ody)

        '	' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
        '	If Cnt >= WM_WLS_MAX Then
        '		Exit Do
        '	End If
        '	' === 20060828 === INSERT E -
        'Loop 

        '' === 20060828 === UPDATE S - ACE)Nagasawa ▲▼ボタン追加
        ''    If Cnt > 0 Then
        ''        '画面表示
        ''        Call WLS_Dsp
        ''    Else
        ''        Me.Caption = ""
        ''        LST.Clear
        ''    End If
        ''
        ''    'クローズ
        ''    Call CF_Ora_CloseDyn(Usr_Ody)

        ''最終データ到達
        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	WM_WLS_LastFL = True
        'End If

        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1
            '取得内容退避
            DB_MEIMTA_W.KEYCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("KEYCD"), "") 'キー
            DB_MEIMTA_W.MEIKMKNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("MEIKMKNM"), "") '項目名
            DB_MEIMTA_W.MEICDA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("MEICDA"), "") 'コード１
            DB_MEIMTA_W.MEINMA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("MEINMA"), "") '名称１

            '１件目は画面ｷｬﾌﾟｼｮﾝ用
            If Cnt = 0 And WM_WLS_Pagecnt = -1 Then
                WM_WLS_DSP_Caption = DB_MEIMTA_W.MEIKMKNM
            End If

            '表示改ページ
            If Cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                Cnt = 0
                '最終ページ退避
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

            Cnt = Cnt + 1

            'If Cnt >= WM_WLS_MAX Then
            '    Exit For
            'End If
        Next

        WM_WLS_LastFL = True
        '20190319 CHG START

		If Cnt > 0 Then
			'ページを表示
			Call WLS_Dsp()
		Else
			If WM_WLS_Pagecnt = 1 Then
				Me.Text = ""
				LST.Items.Clear()
			End If
		End If
		' === 20060828 === UPDATE E -
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_Dsp
	'   概要：  画面編集処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_Dsp()
		Dim intCnt As Short
		
		'画面ｷｬﾌﾟｼｮﾝ編集
		Me.Text = WM_WLS_DSP_Caption
		
		' === 20060828 === UPDATE S - ACE)Nagasawa ▲▼ボタン追加
		'        '表示リスト編集
		'        LST.Clear
		'        intCnt = 0
		'        For intCnt = 0 To UBound(WM_WLS_DSPArray)
		'            LST.AddItem WM_WLS_DSPArray(intCnt)
		'        Next
		
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
		' === 20060828 === UPDATE E -
		
		'フォーカス設定
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
		
		'検索結果保持変数
		WM_WLS_DSP_Caption = ""
		'検索結果保持配列
		ReDim WM_WLS_DSPArray(0)
		
		' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
		'画面表示ページ
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		' === 20060828 === INSERT E -
		
	End Sub
	
	
	'UPGRADE_WARNING: Form イベント WLS_MEI.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_MEI_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        '// 各ボタン配置
        ' === 20060828 === DELETE S - ACE)Nagasawa ▲▼ボタン追加
        '    WLSOK.Left = (WLS_MEI.Width - (WLSOK.Width + WLSCANCEL.Width + 60)) / 2
        '    WLSCANCEL.Left = WLSOK.Left + WLSOK.Width + 60
        ' === 20060828 === DELETE E -

        '20190522 DEL START
        '      '// 画面編集
        '      Call WLS_TextSQL()
        'Call WLS_DspNew()

        'If (LST.Items.Count > 0) And (LST.SelectedIndex < 0) Then LST.SelectedIndex = 0

        '      DblClickFl = False
        '20190522 DEL END

    End Sub

    Private Sub WLS_MEI_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
        Call Init_Prompt()
        Call WLS_FORM_INIT()

        '20190522 ADD START
        '// 画面編集
        Call WLS_TextSQL()
        Call WLS_DspNew()

        If (LST.Items.Count > 0) And (LST.SelectedIndex < 0) Then LST.SelectedIndex = 0

        DblClickFl = False
        '20190522 ADD END

    End Sub

    '20190521 ADD START
    Private Sub WLS_MEI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190521 ADD END

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KEYCODE
			Case 13
                '20190514 CHG START
                'WLSMEI_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_MEICDALEN)
                'WLSMEI_RTNMEINMA = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_MEICDALEN + 2, WM_WLS_MEINMALEN)
#Disable Warning BC40000 ' Type or member is obsolete
                WLSMEI_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), LenB(DB_MEIMTA_W.MEICDA))
#Enable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
                WLSMEI_RTNMEINMA = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), LenB(DB_MEIMTA_W.MEICDA) + 2, Len(DB_MEIMTA_W.MEINMA))
#Enable Warning BC40000 ' Type or member is obsolete
                '20190514 CHG END

                '20190522 CHG START
                'If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                If DblClickFl = False Then Call btnF12_Click(btnF12, New System.EventArgs())
                '20190522 CHG END
            Case 27
                '20190522 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190522 CHG END
                ' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
                '←キー押下
            Case System.Windows.Forms.Keys.Left
                '20190522 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190522 CHG END

                '→キー押下
            Case System.Windows.Forms.Keys.Right
                '20190522 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190522 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
				' === 20060828 === INSERT E -
		End Select
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
#Disable Warning BC40000 ' Type or member is obsolete
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
#Enable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
#Enable Warning BC40000 ' Type or member is obsolete

        '20190522 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190522 CHG END
    End Sub

    '20190522 CHG START
    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
    '	'クローズ
    '       'Call CF_Ora_CloseDyn(Usr_Ody)
    '	' === 20060828 === INSERT E -

    '	Hide()
    'End Sub

    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    'End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        ' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
        'クローズ
        'Call CF_Ora_CloseDyn(Usr_Ody)
        ' === 20060828 === INSERT E -

        Hide()
    End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub
    '20190522 CHG END

    '20190522 CHG START
    ' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '	If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '		If Not WM_WLS_LastFL Then Call WLS_DspNew()
    '	Else
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '		Call WLS_Dsp()
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
            Call WLS_Dsp()
        End If
    End Sub
    '20190522 CHG END

    '20190522 CHG START
    '   Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '	If WM_WLS_Pagecnt > 0 Then
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '		Call WLS_Dsp()
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
    '   ' === 20060828 === INSERT E -

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_Dsp()
        End If
    End Sub
    '20190522 CHG END

End Class