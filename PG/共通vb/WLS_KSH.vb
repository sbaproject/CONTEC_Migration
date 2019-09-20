Option Strict Off
Option Explicit On
Friend Class WLS_KSH
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　決済方法検索
	'*  プログラムＩＤ　：  WLS_KSH
	'*  作成者　　　　　：　両備)inoue
	'*  作成日　　　　　：  2013.07.01
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	
	'ウィンドﾕｰｻﾞｰ設定変数
	Private WM_WLS_KSHCDALEN As Short 'コード１文字数
	Private WM_WLS_KSHNMALEN As Short '名称１文字数
	Private WM_WLS_KSHNMBLEN As Short '名称２文字数
	
	'ウィンド内部使用変数
	Private WM_WLS_DSP_Caption As String '画面ｷｬﾌﾟｼｮﾝ表示データ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ

    '20190904 CHG START
    'Private WM_WLS_MAX As Short '１画面の表示件数
    Private WM_WLS_MAX As Short = 15 '１画面の表示件数
    '20190904 CHG END

    Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	
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
		WM_WLS_MAX = 15 '画面表示件数

        '20190904 CHG START
        '項目文字数取得
        'WM_WLS_KSHCDALEN = Len(DB_MEIMTA_W.MEICDA) 'LenWid はダメ
        'WM_WLS_KSHNMALEN = Len(DB_MEIMTA_W.MEINMA) 'LenWid はダメ
        'WM_WLS_KSHNMBLEN = Len(DB_MEIMTA_W.MEINMB) 'LenWid はダメ

        WM_WLS_KSHCDALEN = 20 'MEIMTA.MEICDA Field Length
        WM_WLS_KSHNMALEN = 40 'MEIMTA.MEINMA Field Length
        WM_WLS_KSHNMBLEN = 20 'MEIMTA.MEINMB Field Length
        '20190904 CHG END

        '変数初期化
        WLSMEI_RTNMEICDA = ""
		WLSMEI_RTNMEINMA = ""
		WLSMEI_RTNMEINMB = ""
		
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
        WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_MEIMTA_W.MEINMB, WM_WLS_KSHNMBLEN) & Space(1) & LeftWid(DB_MEIMTA_W.MEINMA, WM_WLS_KSHNMALEN)
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
		strSQL = strSQL & "      , MEINMB " '名称２
		strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "


        strSQL = strSQL & "   and  KEYCD = '" & WLSMEI_KEYCD & "'"

        strSQL = strSQL & "   order by "
		strSQL = strSQL & "        KEYCD " 'キー
		strSQL = strSQL & "      , DSPORD " '表示順序
		strSQL = strSQL & "      , MEINMB " '名称２（得意先コード）
		
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
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
		Dim Cnt As Integer
		
		Cnt = 0
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			'取得内容退避
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_MEIMTA_W.KEYCD = CF_Ora_GetDyn(Usr_Ody, "KEYCD", "") 'キー
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_MEIMTA_W.MEIKMKNM = CF_Ora_GetDyn(Usr_Ody, "MEIKMKNM", "") '項目名
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_MEIMTA_W.MEICDA = CF_Ora_GetDyn(Usr_Ody, "MEICDA", "") 'コード１
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_MEIMTA_W.MEINMA = CF_Ora_GetDyn(Usr_Ody, "MEINMA", "") '名称１
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_MEIMTA_W.MEINMB = CF_Ora_GetDyn(Usr_Ody, "MEINMB", "") '名称２
			
			'表示メモリ展開
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
			
			Call CF_Ora_MoveNext(Usr_Ody)
			
			If Cnt >= WM_WLS_MAX Then
				Exit Do
			End If
		Loop 
		
		'最終データ到達
		If CF_Ora_EOF(Usr_Ody) = True Then
			WM_WLS_LastFL = True
		End If
		
		If Cnt > 0 Then
			'ページを表示
			Call WLS_Dsp()
		Else
			If WM_WLS_Pagecnt = 1 Then
				Me.Text = ""
				LST.Items.Clear()
			End If
		End If
		
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
		
		'フォーカス設定
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			On Error Resume Next
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
		
		'画面表示ページ
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
	End Sub
	
	'UPGRADE_WARNING: Form イベント WLS_KSH.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_KSH_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		'// 画面編集
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		If (LST.Items.Count > 0) And (LST.SelectedIndex < 0) Then LST.SelectedIndex = 0
		
		DblClickFl = False
	End Sub
	
	Private Sub WLS_KSH_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)

        Call Init_Prompt()
        Call WLS_FORM_INIT()

        '20190904 ADD START
        '// 画面編集
        Call WLS_TextSQL()
        Call WLS_DspNew()
        If (LST.Items.Count > 0) And (LST.SelectedIndex < 0) Then LST.SelectedIndex = 0
        DblClickFl = False
        '20190904 ADD END

    End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 13
				WLSMEI_RTNMEINMB = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_KSHNMBLEN)
				WLSMEI_RTNMEINMA = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_KSHNMBLEN + 2, WM_WLS_KSHNMALEN)
				If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case 27
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
				'←キー押下
			Case System.Windows.Forms.Keys.Left
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
				
				'→キー押下
			Case System.Windows.Forms.Keys.Right
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Hide()
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
		Else
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_Dsp()
		End If
	End Sub
	
	Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(1).Image
	End Sub
	
	Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(0).Image
	End Sub
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
			Call WLS_Dsp()
		End If
	End Sub
	
	Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(1).Image
	End Sub
	
	Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(0).Image
	End Sub

    Private Sub WLS_KSH_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub

    Private Sub btnF7_Click(sender As Object, e As EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_Dsp()
        End If
    End Sub

    Private Sub btnF8_Click(sender As Object, e As EventArgs) Handles btnF8.Click

        If LST.Items.Count <= 0 Then Exit Sub

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_Dsp()
        End If
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        Hide()
    End Sub
End Class