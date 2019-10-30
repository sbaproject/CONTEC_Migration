Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSSUB
	Inherits System.Windows.Forms.Form
	
	Dim blnUsableEvent As Boolean 'ｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ(汎用)
	Dim intChkKb As Short 'チェック区分(1:チェック
	'             2:チェック(前回から変更時のみ)
	'             3:チェック(フォーカスは移動しない)
	
	Dim strHDkouza As String 'ヘッダの勘定口座の値を格納
	Dim CurrentLine As Short 'フォーカスのある行番号をセット(ヘッダの時は-1）
	
	
	Dim intEventUkai As Short 'ｲﾍﾞﾝﾄを迂回するかどうかのﾌﾗｸﾞ(汎用)
	
	
	'フォームロード時
	Private Sub FR_SSSSUB_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		'初期化
		initForm()
		'項目初期化
		initItem()
	End Sub
	
	'フォームアンロード時
	Private Sub FR_SSSSUB_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		'●終了確認のMSG
		If chkLineNull(0) = True Then
			If chkLineNull(1) = True Then
				If chkLineNull(2) = True Then
					If showMsg("0", "_ENDCM", CStr(0)) = MsgBoxResult.No Then
						Cancel = MsgBoxResult.Cancel
						Exit Sub
					Else
						Me.Close() '●PG終了
						Exit Sub
					End If
				End If
			End If
		End If
		
		If showMsg("0", "_ENDCK", CStr(0)) = MsgBoxResult.No Then
			Cancel = MsgBoxResult.Cancel
			Exit Sub
		End If
		
		Me.Close() '●PG終了
		eventArgs.Cancel = Cancel
	End Sub
	
	
	
	
	Private Sub initForm()
		Dim ssBevelNone As Object
		'★ひとまず行追加は保留
		mnu_gyoin.Visible = False
		img_gyoin.Visible = False
		
		'運用日の表示
		'UPGRADE_WARNING: オブジェクト pnl_unydt.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_unydt.Caption = CNV_DATE(gstrUnydt.Value)
		
		'入金日の表示
		txt_nyudt.Text = CNV_DATE(gstrKesidt.Value)
		
		'請求先の表示
		txt_tokseicd.Text = DB_TOKMTA.TOKSEICD
		txt_tokseinma.Text = DB_TOKMTA.TOKNMA
		
		'入力担当者の表示
		txt_opeid.Text = FR_SSSMAIN.txt_opeid.Text
		txt_openm.Text = FR_SSSMAIN.txt_openm.Text
		
		'表示限定テキストボックス設定用パネルを隠す
		'UPGRADE_WARNING: オブジェクト pnl_hihyoji.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_hihyoji.Caption = ""
		'UPGRADE_WARNING: オブジェクト pnl_hihyoji.BevelOuter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ssBevelNone の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_hihyoji.BevelOuter = ssBevelNone
	End Sub
	
	'項目の初期化
	Private Sub initItem()
		txt_HDkouza.Text = "          " '10byte space
		txt_HDkouza.ForeColor = System.Drawing.Color.Black
		txt_HDkouza.BackColor = System.Drawing.Color.White
		strHDkouza = ""
		
		blnUsableEvent = True
		intChkKb = 2
		
		initBody()
	End Sub
	
	'明細部の削除
	Private Sub initBody()
		Dim i As Short
		For i = 0 To 2
			initLine((i))
		Next i
	End Sub
	
	'行の初期化
	Private Sub initLine(ByRef intRow As Short)
		txt_BDdkbid(intRow).Text = "  " '2byte space
		txt_BDdkbnm(intRow).Text = ""
		txt_BDkouza(intRow).Text = "          " '10byte space
		txt_BDnyukn(intRow).Text = ""
		txt_BDlincma(intRow).Text = "                    " '20byte space
		
		txt_BDdkbid(intRow).ForeColor = System.Drawing.Color.Black
		txt_BDdkbid(intRow).BackColor = System.Drawing.Color.White
		txt_BDkouza(intRow).ForeColor = System.Drawing.Color.Black
		txt_BDkouza(intRow).BackColor = System.Drawing.Color.White
		txt_BDnyukn(intRow).ForeColor = System.Drawing.Color.Black
		txt_BDnyukn(intRow).BackColor = System.Drawing.Color.White
		txt_BDlincma(intRow).ForeColor = System.Drawing.Color.Black
		txt_BDlincma(intRow).BackColor = System.Drawing.Color.White
		
		Call initSubFormType(intRow)
	End Sub
	
	Private Function chkHDkouza() As Boolean
		chkHDkouza = False
		
		'チェック区分が1,3のとき、あるいは変更されていたらチェックを行う
		If intChkKb = 1 Or txt_HDkouza.Text <> strHDkouza Or intChkKb = 3 Then
			
			'空白入力時はチェックしない
			If Trim(txt_HDkouza.Text) = "" Then Exit Function
			
			'●名称ﾏｽﾀから勘定口座名称を取得
			Select Case GET_MEIMTA_KANKOZ(txt_HDkouza.Text)
				'存在するとき
				Case 0
					txt_HDkouza.ForeColor = System.Drawing.Color.Black
					chkHDkouza = True
					
					
					'存在するが、削除レコードの場合
				Case 8
					'チェック区分が3でないとき、メッセージを表示
					If intChkKb <> 3 Then
						Call showMsg("2", "URKET73_039", "0") '●削除済みレコードです
						txt_HDkouza.ForeColor = System.Drawing.Color.Red
						txt_HDkouza.Focus()
					End If
					
					
					'存在しない時
				Case 9
					'チェック区分が3でないとき、メッセージを表示
					If intChkKb <> 3 Then
						Call showMsg("2", "RNOTFOUND", "0") '●該当データなし
						txt_HDkouza.ForeColor = System.Drawing.Color.Red
						txt_HDkouza.Focus()
					End If
			End Select
		End If
		strHDkouza = txt_HDkouza.Text
		intChkKb = 2 '●基本は変更時にチェック
	End Function
	
	'明細部勘定口座の入力チェック
	Private Function chkBDkouza(ByRef Index As Short) As Boolean
		chkBDkouza = False
		
		'チェック区分が1のとき、あるいは変更されていたらチェックを行う。
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(Index).SUB_KOUZA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If intChkKb = 1 Or txt_BDkouza(Index).Text <> gtypeFR_SUB(Index).SUB_KOUZA Then
			
			'空白入力時はチェックしない
			If Trim(txt_BDkouza(Index).Text) <> "" Then
				
				'●名称ﾏｽﾀから勘定口座名称を取得
				Select Case GET_MEIMTA_KANKOZ(txt_BDkouza(Index).Text)
					'存在するとき
					Case 0
						txt_BDkouza(Index).ForeColor = System.Drawing.Color.Black
						chkBDkouza = True
						
						
						'存在するが、削除レコードの場合
					Case 8
						Call showMsg("2", "URKET73_039", "0") '●削除済みレコードです
						txt_HDkouza.ForeColor = System.Drawing.Color.Red
						txt_HDkouza.Focus()
						
						
						'存在しない時
					Case 9
						Call showMsg("2", "RNOTFOUND", "0") '●該当データなし
						txt_BDkouza(Index).ForeColor = System.Drawing.Color.Red
						txt_BDkouza(Index).Focus()
				End Select
			End If
		End If
		
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(Index).SUB_KOUZA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gtypeFR_SUB(Index).SUB_KOUZA = txt_BDkouza(Index).Text
		intChkKb = 2 '●基本は変更時にチェック
	End Function
	
	'入金種別の入力チェック
	Private Function chkBDdkbid(ByRef Index As Short) As Boolean
		Dim tmp As String
		
		chkBDdkbid = False
		
		'チェック区分が1のとき、あるいは変更されていたらチェックを行う
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If intChkKb = 1 Or Trim(txt_BDdkbid(Index).Text) <> Trim(gtypeFR_SUB(Index).SUB_DKBID) Then
			txt_BDdkbnm(Index).Text = ""
			
			'空白入力時はチェックしない
			If Trim(txt_BDdkbid(Index).Text) <> "" Then
				
				'入力値が2byteで無い時は0埋め
				blnUsableEvent = False
				txt_BDdkbid(Index).Text = VB6.Format(txt_BDdkbid(Index).Text, "00")
				blnUsableEvent = True
				
				'●SYSTBDから入金種別名称を取得
				tmp = getDkbnm(txt_BDdkbid(Index).Text, Index)
				If tmp <> "" Then
					'存在するとき
					txt_BDdkbid(Index).ForeColor = System.Drawing.Color.Black
					txt_BDdkbnm(Index).Text = tmp
					'ヘッダに勘定口座が指定されていて、かつ明細に勘定口座が入力されていなければコピー
					intChkKb = 3 'チェックのみ
					If txt_HDkouza.Text <> "" And chkHDkouza = True Then
						blnUsableEvent = False
						
						If Trim(txt_BDkouza(Index).Text) = "" Then
							txt_BDkouza(Index).Text = txt_HDkouza.Text
						End If
						
						blnUsableEvent = True
					End If
					chkBDdkbid = True
					
					'存在しない時
				Else
					Call showMsg("2", "RNOTFOUND", "0") '●該当データなし
					txt_BDdkbid(Index).ForeColor = System.Drawing.Color.Red
					txt_BDdkbid(Index).Focus()
				End If
				
				'空白のとき、登録処理を実行する
			Else
				'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				gtypeFR_SUB(Index).SUB_DKBID = ""
				mnu_regist_Click(mnu_regist, New System.EventArgs())
			End If
		End If
		
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(Index).SUB_DKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gtypeFR_SUB(Index).SUB_DKBID = txt_BDdkbid(Index).Text
		intChkKb = 2 '●基本は変更時にチェック
	End Function
	
	'行単位に入力チェックを行う
	'intPatternが0の時は必ずチェック
	Private Function chkLine(ByRef intRow As Short, Optional ByRef intPattern As Short = 1) As Boolean
		chkLine = False
		
		CurrentLine = intRow
		'行にいずれかに項目が入力されていたら、別の必須項目の入力チェックを行う
		If Trim(txt_BDdkbid(intRow).Text) <> "" Or Trim(txt_BDkouza(intRow).Text) <> "" Or Trim(txt_BDkouza(intRow).Text) <> "" Or Trim(txt_BDlincma(intRow).Text) <> "" Or intPattern = 0 Then
			
			If Trim(txt_BDdkbid(intRow).Text) = "" Then
				showMsg("0", "_COMPLETEC", "0") '●必須項目未入力のMSG
				txt_BDdkbid(intRow).ForeColor = System.Drawing.Color.Red
				txt_BDdkbid(intRow).Focus()
				Exit Function
			Else
				intChkKb = 1
				If chkBDdkbid(intRow) = False Then
					Exit Function
				End If
			End If
			
			If Trim(txt_BDkouza(intRow).Text) = "" Then
				txt_BDkouza(intRow).ForeColor = System.Drawing.Color.Red
				txt_BDkouza(intRow).Focus()
				showMsg("0", "_COMPLETEC", "0")
				Exit Function
			Else
				intChkKb = 1
				If chkBDkouza(intRow) = False Then
					Exit Function
				End If
			End If
			
			If Trim(txt_BDnyukn(intRow).Text) = "" Then
				showMsg("0", "_COMPLETEC", "0")
				txt_BDnyukn(intRow).ForeColor = System.Drawing.Color.Red
				txt_BDnyukn(intRow).Focus()
				Exit Function
			End If
		End If
		
		chkLine = True
	End Function
	
	'行がNULLがどうかを確認
	Private Function chkLineNull(ByRef intRow As Short) As Boolean
		chkLineNull = False
		
		If Trim(txt_BDdkbid(intRow).Text) <> "" Then Exit Function
		If Trim(txt_BDkouza(intRow).Text) <> "" Then Exit Function
		If Trim(txt_BDnyukn(intRow).Text) <> "" Then Exit Function
		If Trim(txt_BDlincma(intRow).Text) <> "" Then Exit Function
		
		chkLineNull = True
	End Function
	
	
	
	'終了ボタンクリック時
	Private Sub img_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_exit.Click
		mnu_exit_Click(mnu_exit, New System.EventArgs())
	End Sub
	'終了マウスダウン時
	Private Sub img_exit_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_exit.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_exit.Image = img_bkexit(1).Image
	End Sub
	'終了マウスムーブ時
	Private Sub img_exit_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_exit.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "メニューに戻ります。"
	End Sub
	'終了マウスアップ時
	Private Sub img_exit_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_exit.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_exit.Image = img_bkexit(0).Image
	End Sub
	
	'行削除ボタンクリック時
	Private Sub img_gyodel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_gyodel.Click
		If mnu_gyodel.Enabled = False Then Exit Sub
		mnu_gyodel_Click(mnu_gyodel, New System.EventArgs())
	End Sub
	'行削除マウスダウン時
	Private Sub img_gyodel_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_gyodel.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_gyodel.Image = img_bkgyodel(1).Image
	End Sub
	'行削除マウスムーブ時
	Private Sub img_gyodel_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_gyodel.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "明細を一行削除します。"
	End Sub
	'行削除マウスアップ時
	Private Sub img_gyodel_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_gyodel.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_gyodel.Image = img_bkgyodel(0).Image
	End Sub
	
	'行挿入ボタンクリック時
	Private Sub img_gyoin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_gyoin.Click
		If mnu_gyoin.Enabled = False Then Exit Sub
		mnu_gyoin_Click(mnu_gyoin, New System.EventArgs())
	End Sub
	'行挿入マウスダウン時
	Private Sub img_gyoin_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_gyoin.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_gyoin.Image = img_bkgyoin(1).Image
	End Sub
	'行挿入マウスムーブ時
	Private Sub img_gyoin_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_gyoin.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "明細行を挿入します。"
	End Sub
	'行挿入マウスアップ時
	Private Sub img_gyoin_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_gyoin.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_gyoin.Image = img_bkgyoin(0).Image
	End Sub
	
	'登録ボタンクリック時
	Private Sub img_regist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_regist.Click
		mnu_regist_Click(mnu_regist, New System.EventArgs())
	End Sub
	'登録マウスダウン時
	Private Sub img_regist_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_regist.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_regist.Image = img_bkregist(1).Image
	End Sub
	'登録マウスムーブ時
	Private Sub img_regist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_regist.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "登録します。"
	End Sub
	'登録マウスアップ時
	Private Sub img_regist_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_regist.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_regist.Image = img_bkregist(0).Image
	End Sub
	
	'検索ボタンクリック時
	Private Sub img_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_showwnd.Click
		mnu_showwnd_Click(mnu_showwnd, New System.EventArgs())
	End Sub
	'検索マウスダウン時
	Private Sub img_showwnd_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_showwnd.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_showwnd.Image = img_bkshowwnd(1).Image
	End Sub
	'検索マウスムーブ時
	Private Sub img_showwnd_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_showwnd.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "ウィンドウを表示します。"
	End Sub
	'検索マウスアップ時
	Private Sub img_showwnd_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_showwnd.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_showwnd.Image = img_bkshowwnd(0).Image
	End Sub
	
	'明細行初期化メニュークリック時
	Public Sub mnu_bdinitdsp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_bdinitdsp.Click
		'行の消去を行う
		initLine(CurrentLine)
		txt_BDdkbid(CurrentLine).Focus()
		txt_BDdkbid(CurrentLine).BackColor = System.Drawing.Color.Yellow
	End Sub
	
	'終了メニュークリック時
	Public Sub mnu_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_exit.Click
		Me.Close()
	End Sub
	
	'行削除メニュークリック時
	Public Sub mnu_gyodel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_gyodel.Click
		Dim i As Short
		
		'行の消去を行う
		initLine(CurrentLine)
		'下段の行を現在行に移動
		If CurrentLine < 2 Then
			For i = CurrentLine To 1 - CurrentLine
				'下段の行が空白でなかったら、上段にコピー
				If chkLineNull(i + 1) = False Then
					blnUsableEvent = False
					
					txt_BDdkbid(i).Text = txt_BDdkbid(i + 1).Text
					txt_BDdkbnm(i).Text = txt_BDdkbnm(i + 1).Text
					txt_BDkouza(i).Text = txt_BDkouza(i + 1).Text
					txt_BDnyukn(i).Text = txt_BDnyukn(i + 1).Text
					txt_BDlincma(i).Text = txt_BDlincma(i + 1).Text
					Call moveSubFormType(i) '構造体の値もコピー
					initLine(i + 1) '下段の情報を削除
					
					blnUsableEvent = True
				End If
			Next i
		End If
		txt_BDdkbid(CurrentLine).Focus()
		txt_BDdkbid(CurrentLine).BackColor = System.Drawing.Color.Yellow
	End Sub
	
	'行追加メニュークリック時
	Public Sub mnu_gyoin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_gyoin.Click
		'
	End Sub
	
	'画面初期化メニュークリック時
	Public Sub mnu_initdsp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_initdsp.Click
		'初期化
		initItem()
		'ヘッダ部勘定口座にフォーカスを移動
		CurrentLine = -1 'ヘッダを示す-1をセット
		txt_HDkouza.Focus()
		txt_HDkouza.BackColor = System.Drawing.Color.Yellow
	End Sub
	
	'登録メニュークリック時
	Public Sub mnu_regist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_regist.Click
		Dim p As Short
		Dim i As Short
		
		
		intEventUkai = 1
		p = CurrentLine
		If chkLine(0, 0) = False Then
			intEventUkai = 0
			Exit Sub '1行目は必須入力
		End If
		If chkLine(1) = False Then
			intEventUkai = 0
			Exit Sub
		End If
		If chkLine(2) = False Then
			intEventUkai = 0
			Exit Sub
		End If
		CurrentLine = p
		intEventUkai = 0
		
		
		
		'●登録確認のMSG
		If showMsg("0", "_UPDATE", CStr(0)) = MsgBoxResult.Yes Then
			'★権限の判断
			If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
				showMsg("2", "UPDAUTH", "0")
			Else
				Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
				If F_UPDATE_SUB = 1 Then
					mnu_initdsp_Click(mnu_initdsp, New System.EventArgs()) '画面表示の初期化
				Else
					'●更新処理失敗時
					MsgBox("更新に失敗しました。", MsgBoxStyle.Critical, "更新エラー")
				End If
				Me.Cursor = System.Windows.Forms.Cursors.Default
			End If
		Else
			If CurrentLine <> -1 Then
				txt_BDdkbid(CurrentLine).Focus()
			End If
		End If
	End Sub
	
	'検索メニュークリック時
	Public Sub mnu_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_showwnd.Click
		'ヘッダ部勘定口座にフォーカスがあるとき
		'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		If Me.ActiveControl.Name = txt_HDkouza.Name Then
			blnUsableEvent = False
			cmd_HDkouza_Click()
			blnUsableEvent = True
			
			'明細部にフォーカスがあるとき
		ElseIf CurrentLine >= 0 Then 
			'入金種別のとき
			'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			If Me.ActiveControl.Name = txt_BDdkbid(CurrentLine).Name Then
				blnUsableEvent = False
				cmd_BDdkbid_Click()
				blnUsableEvent = True
				
				'勘定口座のとき
				'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			ElseIf Me.ActiveControl.Name = txt_BDkouza(CurrentLine).Name Then 
				blnUsableEvent = False
				cmd_BDkouza_Click()
				blnUsableEvent = True
			End If
		End If
	End Sub
	
	'ヘッダパネルマウスムーブ時
	Private Sub pnl_head_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'ヒントの表示を初期化する
		img_light.Image = img_bklight(0).Image
		txt_message.Text = ""
	End Sub
	
	
	
	
	
	
	'=======================================================入金種別(明細)必須項目=======================================================
	
	
	'UPGRADE_WARNING: イベント txt_BDdkbid.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_BDdkbid_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDdkbid.TextChanged
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		Dim p As Short
		
		'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
		If blnUsableEvent = False Then Exit Sub
		
		'カーソルが右端に移動した時は、次の項目へ移動
		If txt_BDdkbid(Index).SelectionStart = 2 Then
			intChkKb = 1 '★入金種別の入力チェック
			txt_BDkouza(Index).Focus() '明細部勘定口座項目へ移動
		End If
		
	End Sub
	
	Private Sub txt_BDdkbid_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDdkbid.Enter
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		'全選択状態にする
		txt_BDdkbid(Index).SelectionStart = 0
		txt_BDdkbid(Index).SelectionLength = 2
		'背景色を黄色にする
		txt_BDdkbid(Index).BackColor = System.Drawing.Color.Yellow
		'明細行コマンドを実行可とする
		mnu_bdinitdsp.Enabled = True
		mnu_gyoin.Enabled = True
		mnu_gyodel.Enabled = True
		'検索処理を実行可能とする
		mnu_showwnd.Enabled = True
		'現在行番号を保存
		CurrentLine = Index
	End Sub
	
	Private Sub txt_BDdkbid_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_BDdkbid.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		
		'右矢印押下時
		If KeyCode = System.Windows.Forms.Keys.Right Then
			If txt_BDdkbid(Index).SelectionStart < (2 - 1) Then
				txt_BDdkbid(Index).SelectionStart = txt_BDdkbid(Index).SelectionStart + 1
				
				'カーソルが右端に来たら次の項目へ移動
			Else
				intChkKb = 2 '★入金種別の入力チェック（変更時のみ）
				txt_BDkouza(Index).Focus() '明細部勘定口座項目へ移動
			End If
			txt_BDdkbid(Index).SelectionLength = 1
			
			'Backspace or 左矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Back Or KeyCode = System.Windows.Forms.Keys.Left Then 
			If txt_BDdkbid(Index).SelectionStart > 0 Then
				txt_BDdkbid(Index).SelectionStart = txt_BDdkbid(Index).SelectionStart - 1
				
				'カーソルが左端に来たら前の項目へ移動
			Else
				'Backspaceの時は、入力値が空白の時、前項目へ移動
				If Trim(txt_BDdkbid(Index).Text) <> "" And KeyCode = System.Windows.Forms.Keys.Back Then
					Exit Sub
				End If
				
				intChkKb = 2 '★入金種別の入力チェック（変更時のみ）
				If Index = 0 Then
					txt_HDkouza.Focus() 'ヘッダ部勘定口座項目へ移動
				Else
					txt_BDlincma(Index - 1).Focus() '備考項目へ移動
				End If
			End If
			txt_BDdkbid(Index).SelectionLength = 1
			
			'上矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
			intChkKb = 2 '★入金種別の入力チェック（変更時のみ）
			If Index = 0 Then
				txt_HDkouza.Focus() 'ヘッダ部勘定口座項目へ移動
			Else
				txt_BDdkbid(Index - 1).Focus() '備考項目へ移動
			End If
			
			'下矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
			intChkKb = 2 '★入金種別の入力チェック（変更時のみ）
			If Index < 2 Then
				txt_BDdkbid(Index + 1).Focus() '明細部勘定口座項目へ移動
			End If
			
			'Enter押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
			intChkKb = 1 '★入金種別の入力チェック
			txt_BDkouza(Index).Focus() '明細部勘定口座項目へ移動
			
			'Delete押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
			Exit Sub
			
		End If
		KeyCode = 0
	End Sub
	
	Private Sub txt_BDdkbid_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_BDdkbid.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		If KeyAscii = System.Windows.Forms.Keys.Back Then GoTo EventExitSub
		'数値のみ入力可とする
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txt_BDdkbid_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDdkbid.Leave
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		'ｲﾍﾞﾝﾄﾌﾗｸﾞが立っていないときは実行しない
		If blnUsableEvent = False Then Exit Sub
		
		'入力チェック
		chkBDdkbid(Index)
		'背景色を白に戻す
		txt_BDdkbid(Index).BackColor = System.Drawing.Color.White
	End Sub
	
	
	'=======================================================勘定口座(明細)必須項目=======================================================
	
	
	'UPGRADE_WARNING: イベント txt_BDkouza.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_BDkouza_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDkouza.TextChanged
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		Dim p As Short
		
		'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
		If blnUsableEvent = False Then Exit Sub
		
		blnUsableEvent = False
		p = txt_BDkouza(Index).SelectionStart
		
		'全角を削除する
		txt_BDkouza(Index).Text = delZenkaku(txt_BDkouza(Index).Text)
		'入力値が10byteで無い時は空白埋め
		txt_BDkouza(Index).Text = txt_BDkouza(Index).Text & Space(10 - Len(txt_BDkouza(Index).Text))
		
		txt_BDkouza(Index).SelectionStart = p
		blnUsableEvent = True
		
		'カーソルが右端に移動した時は、次の項目へ移動
		If txt_BDkouza(Index).SelectionStart = 10 Then
			intChkKb = 1 '★勘定口座ｺｰﾄﾞの入力チェック
			txt_BDnyukn(Index).Focus() '入金額項目へ移動
		End If
		txt_BDkouza(Index).SelectionLength = 1
	End Sub
	
	Private Sub txt_BDkouza_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDkouza.Enter
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		'先頭位置を選択状態にする
		txt_BDkouza(Index).SelectionStart = 0
		txt_BDkouza(Index).SelectionLength = 1
		'背景色を黄色にする
		txt_BDkouza(Index).BackColor = System.Drawing.Color.Yellow
		'明細行コマンドを実行可とする
		mnu_bdinitdsp.Enabled = True
		mnu_gyoin.Enabled = True
		mnu_gyodel.Enabled = True
		'検索処理を実行可能とする
		mnu_showwnd.Enabled = True
		'現在行番号を保存
		CurrentLine = Index
	End Sub
	
	Private Sub txt_BDkouza_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_BDkouza.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		
		'右矢印押下時
		If KeyCode = System.Windows.Forms.Keys.Right Then
			If txt_BDkouza(Index).SelectionStart < (10 - 1) Then
				txt_BDkouza(Index).SelectionStart = txt_BDkouza(Index).SelectionStart + 1
				
				'カーソルが右端に来たら次の項目へ移動
			Else
				intChkKb = 2 '★勘定口座ｺｰﾄﾞの入力チェック（変更時のみ）
				txt_BDnyukn(Index).Focus() '入金額項目へ移動
			End If
			txt_BDkouza(Index).SelectionLength = 1
			
			'Backspace or 左矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Back Or KeyCode = System.Windows.Forms.Keys.Left Then 
			If txt_BDkouza(Index).SelectionStart > 0 Then
				txt_BDkouza(Index).SelectionStart = txt_BDkouza(Index).SelectionStart - 1
				
				'カーソルが左端に来たら前の項目へ移動
			Else
				'Backspaceの時は、入力値が空白の時、前項目へ移動
				If Trim(txt_BDkouza(Index).Text) <> "" And KeyCode = System.Windows.Forms.Keys.Back Then
					Exit Sub
				End If
				intChkKb = 2 '★勘定口座ｺｰﾄﾞの入力チェック（変更時のみ）
				txt_BDdkbid(Index).Focus() '入金種別項目へ移動
			End If
			txt_BDkouza(Index).SelectionLength = 1
			
			'上矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
			intChkKb = 2 '★勘定口座ｺｰﾄﾞの入力チェック（変更時のみ）
			If Index = 0 Then
				txt_HDkouza.Focus()
			Else
				txt_BDkouza(Index - 1).Focus() '入金種別項目へ移動
			End If
			
			'下矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
			intChkKb = 2 '★勘定口座ｺｰﾄﾞの入力チェック（変更時のみ）
			If Index < 2 Then
				txt_BDkouza(Index + 1).Focus() '入金額項目へ移動
			End If
			
			'Enter押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
			intChkKb = 1 '★勘定口座ｺｰﾄﾞの入力チェック
			txt_BDnyukn(Index).Focus() '入金額項目へ移動
			
			'Delete押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
			Exit Sub
			
		End If
		KeyCode = 0
	End Sub
	
	Private Sub txt_BDkouza_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_BDkouza.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		'アルファベット小文字を大文字に変換する
		If Chr(KeyAscii) Like "[a-z]" Then
			KeyAscii = KeyAscii - 32
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txt_BDkouza_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDkouza.Leave
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		'ｲﾍﾞﾝﾄﾌﾗｸﾞが立っていないときは実行しない
		If blnUsableEvent = False Then Exit Sub
		
		'入力チェック(空白は無視)
		chkBDkouza(Index)
		'背景色を白に戻す
		txt_BDkouza(Index).BackColor = System.Drawing.Color.White
	End Sub
	
	
	'=======================================================備考(明細)=======================================================
	
	
	'UPGRADE_WARNING: イベント txt_BDlincma.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_BDlincma_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDlincma.TextChanged
		Dim Index As Short = txt_BDlincma.GetIndex(eventSender)
		Dim p As Short
		
		'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
		If blnUsableEvent = False Then Exit Sub
		
		With txt_BDlincma(Index)
			blnUsableEvent = False
			p = .SelectionStart
			
			'入力値が10byteで無い時は空白埋め
			.Text = LeftWid(.Text, 20)
			
			.SelectionStart = p
			blnUsableEvent = True
			
			'カーソルが右端に移動した時は、次の項目へ移動
			If .SelectionStart = 20 Then
				If Index < 2 Then
					txt_BDdkbid(Index + 1).Focus() '入金種別項目へ移動
				Else
					intChkKb = 2 '★登録実行
					txt_HDkouza.Focus()
				End If
			End If
			.SelectionLength = 1
			
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(Index).SUB_LINCMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			gtypeFR_SUB(Index).SUB_LINCMA = .Text
		End With
		
	End Sub
	
	Private Sub txt_BDlincma_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDlincma.Enter
		Dim Index As Short = txt_BDlincma.GetIndex(eventSender)
		'先頭位置を選択状態にする
		txt_BDlincma(Index).SelectionStart = 0
		txt_BDlincma(Index).SelectionLength = 1
		'背景色を黄色にする
		txt_BDlincma(Index).BackColor = System.Drawing.Color.Yellow
		'明細行コマンドを実行可とする
		mnu_bdinitdsp.Enabled = True
		mnu_gyoin.Enabled = True
		mnu_gyodel.Enabled = True
		'検索処理を実行不可とする
		mnu_showwnd.Enabled = False
		'現在行番号を保存
		CurrentLine = Index
	End Sub
	
	Private Sub txt_BDlincma_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_BDlincma.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = txt_BDlincma.GetIndex(eventSender)
		
		'右矢印押下時
		If KeyCode = System.Windows.Forms.Keys.Right Then
			If txt_BDlincma(Index).SelectionStart < 19 Then
				txt_BDlincma(Index).SelectionStart = txt_BDlincma(Index).SelectionStart + 1
				
				'カーソルが右端に来たら次の項目へ移動
			Else
				If Index < 2 Then
					txt_BDdkbid(Index + 1).Focus() '入金種別項目へ移動
				Else
					intChkKb = 1 '★登録実行
					txt_HDkouza.Focus()
				End If
			End If
			txt_BDlincma(Index).SelectionLength = 1
			
			'Backspace or 左矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Back Or KeyCode = System.Windows.Forms.Keys.Left Then 
			If txt_BDlincma(Index).SelectionStart > 0 Then
				txt_BDlincma(Index).SelectionStart = txt_BDlincma(Index).SelectionStart - 1
				
				'カーソルが左端に来たら前の項目へ移動
			Else
				'Backspaceの時は、入力値が空白の時、前項目へ移動
				If Trim(txt_BDlincma(Index).Text) <> "" And KeyCode = System.Windows.Forms.Keys.Back Then
					Exit Sub
				End If
				intChkKb = 1 '登録しない
				txt_BDnyukn(Index).Focus() '入金額項目へ移動
			End If
			txt_BDlincma(Index).SelectionLength = 1
			
			'上矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
			intChkKb = 1 '登録しない
			If Index = 0 Then
				txt_HDkouza.Focus()
			Else
				txt_BDlincma(Index - 1).Focus() '消込日項目へ移動
			End If
			
			'下矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
			If Index < 2 Then
				txt_BDlincma(Index + 1).Focus() '入金種別項目へ移動
			Else
				intChkKb = 2 '★登録実行
				txt_HDkouza.Focus()
			End If
			
			'Enter押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
			If Index < 2 Then
				txt_BDdkbid(Index + 1).Focus() '入金種別項目へ移動
			Else
				intChkKb = 2 '★登録実行
				txt_HDkouza.Focus()
			End If
			
			'Delete押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
			Exit Sub
			
		End If
		KeyCode = 0
	End Sub
	
	Private Sub txt_BDlincma_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDlincma.Leave
		Dim Index As Short = txt_BDlincma.GetIndex(eventSender)
		'背景色を白に戻す
		txt_BDlincma(Index).BackColor = System.Drawing.Color.White
		'★登録実行
		If Index = 2 And intChkKb = 2 Then
			
			If intEventUkai = 0 Then
				mnu_regist_Click(mnu_regist, New System.EventArgs())
			End If
			
		End If
		intChkKb = 1
	End Sub
	
	
	'=======================================================入金額(明細)必須項目=======================================================
	
	
	'入金額項目変更時
	'UPGRADE_WARNING: イベント txt_BDnyukn.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_BDnyukn_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDnyukn.TextChanged
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
		If blnUsableEvent = False Then Exit Sub
		
		With txt_BDnyukn(Index)
			blnUsableEvent = False
			'金額の桁数表示文字を付加
			
			'UPGRADE_WARNING: オブジェクト SSSVal(txt_BDnyukn(Index).Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(.Text) <> 0 Then
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Text = VB6.Format(SSSVal(.Text), "#,###,##0")
			Else
				.Text = VB6.Format(.Text, "#,###,##0")
			End If
			.SelectionStart = Len(.Text)
			
			blnUsableEvent = True
			
			
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(Index).SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			gtypeFR_SUB(Index).SUB_NYUKN = SSSVal(.Text)
		End With
	End Sub
	
	Private Sub txt_BDnyukn_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDnyukn.Enter
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		'全選択状態にする
		txt_BDnyukn(Index).SelectionStart = 0
		txt_BDnyukn(Index).SelectionLength = 9
		'背景色を黄色にする
		txt_BDnyukn(Index).BackColor = System.Drawing.Color.Yellow
		'明細行コマンドを実行可とする
		mnu_bdinitdsp.Enabled = True
		mnu_gyoin.Enabled = True
		mnu_gyodel.Enabled = True
		'検索処理を実行不可とする
		mnu_showwnd.Enabled = False
		'現在行番号を保存
		CurrentLine = Index
	End Sub
	
	Private Sub txt_BDnyukn_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_BDnyukn.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		With txt_BDnyukn(Index)
			
			'右矢印 or Space押下時
			If KeyCode = System.Windows.Forms.Keys.Right Or KeyCode = System.Windows.Forms.Keys.Space Then
				If .SelectionStart < 9 Then
					
					.SelectionStart = .SelectionStart + 1
					If Mid(.Text, .SelectionStart + 1, 1) = "," Then
						.SelectionStart = .SelectionStart + 1
					End If
					
					
					'カーソルが右端に来たら次の項目へ移動
				Else
					txt_BDlincma(Index).Focus() '備考項目へ移動
				End If
				
				'Backspace or 左矢印押下時
			ElseIf KeyCode = System.Windows.Forms.Keys.Left Then 
				If .SelectionStart > 0 Then
					
					.SelectionStart = .SelectionStart - 1
					If Mid(.Text, .SelectionStart + 1, 1) = "," Then
						.SelectionStart = .SelectionStart - 1
					End If
					
					'カーソルが左端に来たら前の項目へ移動
				Else
					txt_BDkouza(Index).Focus() '勘定口座項目へ移動
				End If
				
				'上矢印押下時
			ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
				If Index = 0 Then
					txt_HDkouza.Focus()
				Else
					txt_BDnyukn(Index - 1).Focus() '勘定口座項目へ移動
				End If
				
				'下矢印押下時
			ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
				If Index < 2 Then
					txt_BDnyukn(Index + 1).Focus() '備考項目へ移動
				End If
				
				'Enter押下時
			ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
				txt_BDlincma(Index).Focus() '備考項目へ移動
				
			ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
				Exit Sub
			End If
			
		End With
		KeyCode = 0
	End Sub
	
	Private Sub txt_BDnyukn_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_BDnyukn.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		'Backspace, マイナス記号は入力できる
		If KeyAscii = System.Windows.Forms.Keys.Back Then GoTo EventExitSub
		If KeyAscii = 45 And VB.Left(txt_BDnyukn(Index).Text, 1) <> "-" Then GoTo EventExitSub
		
		
		'UPGRADE_WARNING: オブジェクト SSSVal(txt_BDnyukn(Index)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(txt_BDnyukn(Index)) >= 9999999 Or SSSVal(txt_BDnyukn(Index)) <= -999999 Then
			KeyAscii = 0
			GoTo EventExitSub
		End If
		
		
		'数値のみ入力可とする
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txt_BDnyukn_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDnyukn.Leave
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		'文字色を黒に戻す
		txt_BDnyukn(Index).ForeColor = System.Drawing.Color.Black
		'背景色を白に戻す
		txt_BDnyukn(Index).BackColor = System.Drawing.Color.White
	End Sub
	
	
	'=======================================================勘定口座(ヘッダ)=======================================================
	
	'UPGRADE_WARNING: イベント txt_HDkouza.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_HDkouza_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_HDkouza.TextChanged
		Dim p As Short
		
		'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
		If blnUsableEvent = False Then Exit Sub
		
		blnUsableEvent = False
		p = txt_HDkouza.SelectionStart
		
		'全角を削除する
		txt_HDkouza.Text = delZenkaku((txt_HDkouza.Text))
		'入力値が10byteで無い時は空白埋め
		txt_HDkouza.Text = txt_HDkouza.Text & Space(10 - Len(txt_HDkouza.Text))
		
		txt_HDkouza.SelectionStart = p
		blnUsableEvent = True
		
		'カーソルが右端に移動した時は、次の項目へ移動
		If txt_HDkouza.SelectionStart = 10 Then
			intChkKb = 1 '★勘定口座ｺｰﾄﾞの入力チェック
			txt_BDdkbid(0).Focus() '入金種別項目へ移動
		End If
		txt_HDkouza.SelectionLength = 1
	End Sub
	
	Private Sub txt_HDkouza_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_HDkouza.Enter
		'先頭位置を選択状態にする
		txt_HDkouza.SelectionStart = 0
		txt_HDkouza.SelectionLength = 1
		'背景色を黄色にする
		txt_HDkouza.BackColor = System.Drawing.Color.Yellow
		
		'明細行コマンドを実行不可とする
		mnu_bdinitdsp.Enabled = False
		mnu_gyoin.Enabled = False
		mnu_gyodel.Enabled = False
		
		'検索処理を実行可能とする
		mnu_showwnd.Enabled = True
		
		CurrentLine = -1 'ヘッダを表す値をセット
	End Sub
	
	Private Sub txt_HDkouza_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_HDkouza.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'右矢印押下時
		If KeyCode = System.Windows.Forms.Keys.Right Then
			If txt_HDkouza.SelectionStart < (10 - 1) Then
				txt_HDkouza.SelectionStart = txt_HDkouza.SelectionStart + 1
				
				'カーソルが右端に来たら次の項目へ移動
			Else
				intChkKb = 1 '★勘定口座ｺｰﾄﾞの入力チェック
				txt_BDdkbid(0).Focus() '入金種別項目へ移動
			End If
			txt_HDkouza.SelectionLength = 1
			
			'Backspace or 左矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Back Or KeyCode = System.Windows.Forms.Keys.Left Then 
			If txt_HDkouza.SelectionStart > 0 Then
				txt_HDkouza.SelectionStart = txt_HDkouza.SelectionStart - 1
			End If
			txt_HDkouza.SelectionLength = 1
			
			'上矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
			'
			
			'下矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
			intChkKb = 1 '★勘定口座ｺｰﾄﾞの入力チェック
			txt_BDdkbid(0).Focus() '入金種別項目へ移動
			
			'Enter押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
			intChkKb = 1 '★勘定口座ｺｰﾄﾞの入力チェック
			txt_BDdkbid(0).Focus() '入金種別項目へ移動
			
			'Delete押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
			Exit Sub
			
		End If
		KeyCode = 0
	End Sub
	
	Private Sub txt_HDkouza_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_HDkouza.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'アルファベット小文字を大文字に変換する
		If Chr(KeyAscii) Like "[a-z]" Then
			KeyAscii = KeyAscii - 32
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txt_HDkouza_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_HDkouza.Leave
		'ｲﾍﾞﾝﾄﾌﾗｸﾞが立っていないときは実行しない
		If blnUsableEvent = False Then Exit Sub
		
		'入力チェック(空白は無視)
		chkHDkouza()
		'背景色を白に戻す
		txt_HDkouza.BackColor = System.Drawing.Color.White
	End Sub
	
	'明細部入金種別ボタンクリック時
	Private Sub cmd_BDdkbid_Click()
		If CurrentLine >= 0 Then
			'リストを表示
			WLS_LIST1.ShowDialog()
			WLS_LIST1.Close()
			
			txt_BDdkbid(CurrentLine).Focus()
			If WLSTBD_RTNCODE <> "" Then
				txt_BDdkbid(CurrentLine).Text = WLSTBD_RTNCODE
				txt_BDkouza(CurrentLine).Focus()
			End If
		End If
	End Sub
	
	'明細部勘定口座ボタンクリック時
	Private Sub cmd_BDkouza_Click()
		If CurrentLine >= 0 Then
			'リストを表示
			WLS_LIST2.ShowDialog()
			WLS_LIST2.Close()
			
			txt_BDkouza(CurrentLine).Focus()
			If WLSKOZ_RTNCODE <> "" Then
				txt_BDkouza(CurrentLine).Text = WLSKOZ_RTNCODE
				txt_BDnyukn(CurrentLine).Focus()
			End If
		End If
	End Sub
	
	'ヘッダ部勘定口座ボタンクリック時
	Private Sub cmd_HDkouza_Click()
		'リストを表示
		WLS_LIST2.ShowDialog()
		WLS_LIST2.Close()
		
		txt_HDkouza.Focus()
		If WLSKOZ_RTNCODE <> "" Then
			txt_HDkouza.Text = WLSKOZ_RTNCODE
			txt_BDdkbid(0).Focus()
		End If
	End Sub
End Class