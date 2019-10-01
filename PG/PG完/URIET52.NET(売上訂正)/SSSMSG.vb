Option Strict Off
Option Explicit On
Module SSSMSG_BAS
	'Copyright 1994-2002 by AppliTech, Inc. All Rights Reserved.
	'
	'Message Library V6.60 'レベルアップの際に変更。
	'
	'色 の値。
	'UPGRADE_NOTE: Cn_BLACK は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_BLACK As System.Drawing.Color = System.Drawing.Color.Black '黒色 = &H0&
	'UPGRADE_NOTE: Cn_RED は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_RED As System.Drawing.Color = System.Drawing.Color.Red '赤色 = &HFF&
	'UPGRADE_NOTE: Cn_GREEN は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_GREEN As System.Drawing.Color = System.Drawing.Color.Lime '緑色 = &HFF00&
	'UPGRADE_NOTE: Cn_YELLOW は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_YELLOW As System.Drawing.Color = System.Drawing.Color.Yellow '黄色 = &HFFFF&
	'UPGRADE_NOTE: Cn_BLUE は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_BLUE As System.Drawing.Color = System.Drawing.Color.Blue '青色 = &HFF0000
	Public Const Cn_GREENBLUE As Integer = &H808000 '青緑色 = &H808000
	'UPGRADE_NOTE: Cn_MAGENTA は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_MAGENTA As System.Drawing.Color = System.Drawing.Color.Magenta '紫色 = &HFF00FF
	'UPGRADE_NOTE: Cn_CYAN は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_CYAN As System.Drawing.Color = System.Drawing.Color.Cyan '水色 = &HFFFF00
	'UPGRADE_NOTE: Cn_WHITE は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_WHITE As System.Drawing.Color = System.Drawing.Color.White '白色 = &HFFFFFF
	'
	'UPGRADE_NOTE: Cn_ClBrightON は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_ClBrightON As System.Drawing.Color = System.Drawing.Color.Yellow '黄色 = &HFFFF&
	'Public Const Cn_ClBrightON = vbCyan     '水色 = &HFFFF00
	Public Const Cn_ClIncomplete As Integer = &H808000 '青緑色 = &H808000
	'Public Const Cn_ClIncomplete = vbBlack  '黒色 = &H0&
	'UPGRADE_NOTE: Cn_ClCheckError は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_ClCheckError As System.Drawing.Color = System.Drawing.Color.Red '赤色 = &HFF&
	'Public Const Cn_ClCheckError = &H8080FF '明るい赤色
	'UPGRADE_NOTE: Cn_ClRelCheck は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_ClRelCheck As System.Drawing.Color = System.Drawing.Color.Magenta '紫色 = &HFF00FF
	'UPGRADE_NOTE: Cn_ClChecked は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_ClChecked As System.Drawing.Color = System.Drawing.Color.Black '黒色 = &H0&
	'UPGRADE_NOTE: Cn_ClIndicator は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_ClIndicator As System.Drawing.Color = System.Drawing.Color.White '白色 = &HFFFFFF
	'UPGRADE_NOTE: Cn_ClNormalBack は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_ClNormalBack As System.Drawing.Color = System.Drawing.Color.White '白色 = &HFFFFFF
	'
	'UPGRADE_NOTE: Cn_ClPromptStatus は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_ClPromptStatus As System.Drawing.Color = System.Drawing.Color.Blue '青色 = &HFF0000
	'UPGRADE_NOTE: Cn_ClErrorStatus は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public Cn_ClErrorStatus As System.Drawing.Color = System.Drawing.Color.Red '赤色 = &HFF&
	'
	Public Const Cn_ai21 As Boolean = False
	'
	Public AE_Title As String
	'
	Public AE_NL As String 'New Line (CRLF) コード
	'
	'Private AE_LogPointer As Integer
	'Private AE_LogBody$(100)
	'
	'アプリの実行時に出力される標準メッセージを変更したり、出力を抑止したりするに
	'は、先ずこのモジュールの名前 AE_MSGL0.BAS を変更してください。
	'なお、名前を変更するには、Visual Basic の『ファイル(F)』というメニューを開い
	'て、『名前を付けてファイルの保存(A)...』という操作を行ってください。
	'そして、プロシジャ AE_MsgLibrary の中の以下のような点線の間に更新ステップを
	'挿入してください。
	'
	'------------------------------------------------------------------ 'Original
	'（これは見本ですので、ここに挿入してはいけません。）
	'------------------------------------------------------------------ 'Original
	'
	'例えば、メッセージコード "APPEND" の "伝票を発行します。" というメッセージの
	'出力を抑止し、メッセージコード "APPENDC" の "データエントリに移行します。"
	'というメッセージを "貸出し業務に移行します。" というメッセージに変更するには
	'点線の間に以下のような更新ステップを挿入します。
	'なお、以下では更新ステップがコメントになっていますが、ここにはコメントしか書
	'けないためにこうなっているわけで、実際にはコメントにしないでください。
	'
	'------------------------------------------------------------------ 'Original
	'        Case "APPEND"
	'        Case "APPENDC"
	'            If AE_MsgBox("貸出し業務に移行します。", vbQuestion + vbOkCancel, AE_Title$) <> vbOk Then AE_MsgLibrary = True
	'------------------------------------------------------------------ 'Original
	'
	
	'キーイン可能な文字かどうかの判定。
	Public Function AE_KeyInOkChar(ByRef PP As clsPP, ByRef Pm_Moji As String, ByVal Pm_KeyInOkClass As Short) As Boolean
		AE_KeyInOkChar = False
		If PP.Mode = Cn_Mode3 Then Exit Function '---------- 'V6.54I
		Select Case UCase(Chr(Pm_KeyInOkClass))
			Case "0" '数字
				If Pm_Moji >= "0" And Pm_Moji <= "9" Then AE_KeyInOkChar = True
			Case "1", "2", "3" '数字１文字ｺｰﾄﾞ 'V4.30
				If Pm_Moji >= "0" And Pm_Moji <= "9" Then AE_KeyInOkChar = True
			Case "A" 'Alphanumeric
				Select Case Pm_Moji
					Case "A" To "Z", "a" To "z", "0" To "9", "-", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "B" 'Basic Idetifier
				Select Case Pm_Moji
					Case "A" To "Z", "a" To "z", "0" To "9", "_"
						AE_KeyInOkChar = True
				End Select
			Case "C" 'Currency
				If InStr("0123456789+-. ", Pm_Moji) > 0 Then AE_KeyInOkChar = True
				'
				'-------開発プロジェクトごとに定義する部分(開始) --------
			Case "D" 'Project Definition 1
				Pm_Moji = UCase(Pm_Moji) 'V4.24
				If Asc(Pm_Moji) >= 0 And Asc(Pm_Moji) < 256 And Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Space(1) Then AE_KeyInOkChar = True 'V4.24
			Case "E" 'Project Definition 2
				Pm_Moji = UCase(Pm_Moji) 'V4.25
				Select Case Pm_Moji
					Case "｡" To "ﾟ", "0" To "9", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "F" 'Project Definition 3
				Pm_Moji = UCase(Pm_Moji)
				Select Case Pm_Moji
					Case "A" To "Z", "0" To "9", "-", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "G" 'Project Definition 4
				Pm_Moji = UCase(Pm_Moji)
				Select Case Pm_Moji
					Case "A" To "Z", "0" To "9", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "H" 'Project Definition 5
				Pm_Moji = UCase(Pm_Moji) 'V4.34
				If Asc(Pm_Moji) >= 0 And Asc(Pm_Moji) < 256 And Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) Then AE_KeyInOkChar = True 'V4.34
				'-------開発プロジェクトごとに定義する部分(終了) --------
				'
			Case "K" 'Katakana
				If Pm_Moji = "　" Then Pm_Moji = Space(1) '全角空白変換
				Select Case Pm_Moji
					Case "｡" To "ﾟ", "0" To "9", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "L" 'Lower Case
				Pm_Moji = LCase(Pm_Moji)
				Select Case Pm_Moji
					Case "a" To "z", "0" To "9", "-", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "M" '２バイトコード
				'UPGRADE_WARNING: オブジェクト LenWid(Pm_Moji$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If LenWid(Pm_Moji) = 2 Then
					AE_KeyInOkChar = True
				ElseIf Pm_Moji = Space(1) Then  '後刻、２バイト文字のスペースに変換。
					AE_KeyInOkChar = True
				End If
			Case "N" 'Nihongo (空白変換あり)
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) Then AE_KeyInOkChar = True
			Case "S" 'Single Byte
				If Asc(Pm_Moji) >= 0 And Asc(Pm_Moji) < 256 And Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) Then AE_KeyInOkChar = True
				'If Asc(Pm_Moji$) >= 0 And Asc(Pm_Moji$) < 256 And Pm_Moji$ <> Chr$(vbKeyReturn) And Pm_Moji$ <> Chr$(vbKeyBack) And Pm_Moji$ <> Space$(1) Then AE_KeyInOkChar = True
			Case "T" '電話番号(Telephone Number)
				'            If InStr("0123456789-()", Pm_Moji$) > 0 Then AE_KeyInOkChar = True
				If InStr("0123456789-", Pm_Moji) > 0 Then AE_KeyInOkChar = True
			Case "U" 'Upper Case
				Pm_Moji = UCase(Pm_Moji)
				Select Case Pm_Moji
					Case "A" To "Z", "0" To "9", "-", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "V" 'Nihongo (空白変換なし)
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) Then AE_KeyInOkChar = True
			Case "W" '和暦
				Pm_Moji = UCase(Pm_Moji) 'If InStr("mtsh", Pm_Moji$) > 0 Then
				If InStr("MTSH", Pm_Moji) > 0 Then
					Pm_Moji = Mid("明大昭平", InStr("MTSH", Pm_Moji), 1)
					AE_KeyInOkChar = True
				ElseIf InStr("0123456789明大昭平", Pm_Moji) > 0 Then 
					AE_KeyInOkChar = True
				End If
			Case "Z" '郵便番号(Zip Code)
				If InStr("0123456789- ", Pm_Moji) > 0 Then AE_KeyInOkChar = True
			Case "-" '一切の文字のインプットが不可
		End Select
	End Function
	
	
	Public Sub AE_Log(ByRef PP As clsPP, ByVal Pm_LogMsg As String)
		'    AE_LogBody$(AE_LogPointer) = PP.MainForm & Str$(Timer) & ": " & Pm_LogMsg$
		'    AE_LogPointer = AE_LogPointer + 1
		'    If AE_LogPointer >= 100 Then AE_LogPointer = 0
	End Sub
	
	'MsgBox の代わりに、AE_MsgBox を用いることでこの部分の変更を一括してできるようにしている。
	Function AE_MsgBox(ByVal Pm_Msg As String, Optional ByVal Pm_MsgCode As Object = Nothing, Optional ByVal Pm_MsgTitle As Object = Nothing) As Object
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(Pm_MsgCode) Then
			'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
			If IsNothing(Pm_MsgTitle) Then
				AE_MsgBox = MsgBox(Pm_Msg)
			Else
				'UPGRADE_WARNING: オブジェクト Pm_MsgTitle の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				AE_MsgBox = MsgBox(Pm_Msg,  , Pm_MsgTitle)
			End If
		Else
			'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
			If IsNothing(Pm_MsgTitle) Then
				'UPGRADE_WARNING: オブジェクト Pm_MsgCode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				AE_MsgBox = MsgBox(Pm_Msg, Pm_MsgCode)
			Else
				'UPGRADE_WARNING: オブジェクト Pm_MsgTitle の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Pm_MsgCode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				AE_MsgBox = MsgBox(Pm_Msg, Pm_MsgCode, Pm_MsgTitle)
			End If
		End If
	End Function
	
	'アプリの実行時に出力される標準メッセージ。
	Public Function AE_MsgLibrary(ByRef PP As clsPP, ByVal Pm_MsgCode As String) As Boolean 'Original
		Dim Wk_Msg As String 'Original
		Dim rtn As Short
		Dim frm As String
		'
		'復帰値 AE_MsgLibrary を一旦 False にした後に処理を行う。'Original
		AE_MsgLibrary = False 'Original
		'なお、復帰値が False だと中断せずに処理を継続することを意味する。'Original
		'      復帰値が True だと処理を中断することを意味する。'Original
		'
		Call Init_Prompt()
		frm = Mid(SSS_PrgId, 4, 2)
		'
		AE_NL = Chr(13) & Chr(10) 'Original
		'
		PP.SlistCall = False
		'
		'SSS_VALKB(有効データ区分)=True の場合、明細行なしでも登録可
		If SSS_VALKB = True Then
			Select Case UCase(Pm_MsgCode)
				Case "CURRENT", "NEXTCM", "PREVCM", "FIRSTCM", "LASTCM"
					AE_MsgLibrary = True
					Exit Function
			End Select
		End If
		'
		Select Case UCase(Pm_MsgCode) 'Original
			'以下の点線の間に更新ステップを挿入してください。'Original
			'------------------------------------------------------------------ 'SSS/Win
			'------------------------------------------------------------------ 'Original
			Case "APPEND" ' データを更新します。
				If PP.MainForm = "SSSMAIN" Then
					Select Case frm
						Case "ET"
							If PP_sssmain.LastDe = 0 And SSS_VALKB = False Then
								rtn = DSP_MsgBox(SSS_EEE, "_APPEND", 2)
								AE_MsgLibrary = True
							ElseIf SSS_BILFL = 9 Then 
								If DSP_MsgBox(SSS_EEE, "_APPEND", 0) <> 6 Then AE_MsgLibrary = True
							End If
						Case "FP"
							If DSP_MsgBox(SSS_EEE, "_APPEND", 1) <> 6 Then AE_MsgLibrary = True
						Case "PR"
						Case Else
							If DSP_MsgBox(SSS_EEE, "_APPEND", 0) <> 6 Then AE_MsgLibrary = True
					End Select
				Else
					AE_MsgLibrary = False
				End If
			Case "APPENDC"
			Case "CANCEL" ' 入力途中のデータは反映されません。
				PP.SuppressGotLostFocus = 1 'Original (Cancel 処理の中で、以下のように MsgBox を発する場合にのみ必要です) 'V6.47
				If DSP_MsgBox(SSS_EEE, "_CANCEL", 0) <> 6 Then AE_MsgLibrary = True
			Case "CLEARDE" ' 空白の明細行を先に削除してください。
				rtn = DSP_MsgBox(SSS_EEE, "_CLEARDE", 0)
			Case "COMPLETEC" ' 不完全な入力項目があります。
				Beep()
				rtn = DSP_MsgBox(SSS_EEE, "_COMPLETEC", 0)
			Case "COPYDE", "COPYITEM" 'Original
				Beep()
				rtn = DSP_MsgBox(SSS_EEE, "_COPYDE", 0)
			Case "CURRENT" ' データが存在しません。
				rtn = DSP_MsgBox(SSS_EEE, "_CURRENT", 0)
			Case "CURSOR" ' 先に上の行を入力してください。
				rtn = DSP_MsgBox(SSS_EEE, "_CURSOR", 0)
			Case "DELETECM" ' データを削除します。
				If DSP_MsgBox(SSS_EEE, "_DELETECM", 0) <> 6 Then AE_MsgLibrary = True
			Case "ENDCK" ' 終了します。
				If PP.MainForm = "SSSMAIN" Then
					Select Case frm
						'Case "PR"
						'Case "FP"
						'Case "DL"
						Case "DL", "FP", "PR"
							If DSP_MsgBox(SSS_EEE, "_ENDCM", 0) <> 6 Then AE_MsgLibrary = True
						Case Else
							If DSP_MsgBox(SSS_EEE, "_ENDCK", 0) <> 6 Then AE_MsgLibrary = True
					End Select
				Else
					AE_MsgLibrary = False
				End If
			Case "ENDCM" ' 終了します。
				If PP.MainForm = "SSSMAIN" Then
					If DSP_MsgBox(SSS_EEE, "_ENDCM", 0) <> 6 Then AE_MsgLibrary = True
				Else
					AE_MsgLibrary = False
				End If
			Case "FIRSTC" ' 先頭のデータに移ります。
				If DSP_MsgBox(SSS_EEE, "_FIRSTC", 0) <> 6 Then AE_MsgLibrary = True
			Case "FIRSTCM" ' データが存在しません。
				rtn = DSP_MsgBox(SSS_EEE, "_FIRSTCM", 0)
			Case "HARDCOPY" ' 画面のイメージを印刷します。
				If DSP_MsgBox(SSS_EEE, "_HARDCOPY", 0) <> 6 Then AE_MsgLibrary = True
			Case "HARDCOPYERROR" ' プリンターを確認してください。
				rtn = DSP_MsgBox(SSS_EEE, "_HARDCOPYERROR", 0)
			Case "HEADCOMPLETEC" ' 見出部の入力を先に済ませてください。
				Beep()
				rtn = DSP_MsgBox(SSS_EEE, "_HEADCOMPLETEC", 0)
			Case "INACTIVEDE" ' 入力可能な項目ではありません。
				rtn = DSP_MsgBox(SSS_EEE, "_INACTIVEDE", 0)
			Case "INDICATE"
			Case "INSERTDE" ' 明細部に余裕がありません。
				rtn = DSP_MsgBox(SSS_EEE, "_INSERTDE", 0)
			Case "LASTC" ' 最後のデータに移ります。
				If DSP_MsgBox(SSS_EEE, "_LASTC", 0) <> 6 Then AE_MsgLibrary = True
			Case "LASTCM" ' データが存在しません。
				rtn = DSP_MsgBox(SSS_EEE, "_LASTCM", 0)
				'Case "MUSTINPUT"
				'Rtn = DSP_MsgBox(SSS_EEE, "_MUSTINPUT", 0)
			Case "NEXTC"
			Case "NEXTCM" ' 最後のデータです。
				rtn = DSP_MsgBox(SSS_EEE, "_NEXTCM", 0)
			Case "OUTPUTONLY" ' この項目には入力できません。
				rtn = DSP_MsgBox(SSS_EEE, "_OUTPUTONLY", 0)
			Case "PRECHECK1" 'Original 'V4.28
                'Call AE_StatusOut(PP, "この項目にはインプットが必要です。", vbRed) 'Original 'V4.28
            Case "PRECHECK2" 'Original 'V4.28
				'Call AE_StatusOut(PP, "この項目には左端から右端まで文字をインプットしてください。", vbRed) 'Original 'V4.28
			Case "QUERYUNLOAD" ' 実行中です。
				rtn = DSP_MsgBox(SSS_EEE, "_QUERYUNLOAD", 0)
			Case "PREVC" ' 一つ前のデータに移ります。
			Case "PREVCM" ' 最初のデータです。
				rtn = DSP_MsgBox(SSS_EEE, "_PREVCM", 0)
			Case "RECALC" ' 誤りがあります。修正してください。
				rtn = DSP_MsgBox(SSS_EEE, "_RECALC", 0)
			Case "RELCHECK" ' 先にエラー項目を修正してください。
				rtn = DSP_MsgBox(SSS_EEE, "_RELCHECK", 0)
			Case "SELECTCM" ' 入力途中のデータは反映されません。
			Case "SELECTE" '1998/03/30  追加
			Case "UPDATE" ' 更新します。
				If PP.MainForm = "SSSMAIN" Then
					Select Case frm
						Case "ET"
							If PP_sssmain.LastDe = 0 And SSS_VALKB = False Then
								rtn = DSP_MsgBox(SSS_EEE, "_UPDATE", 2)
								AE_MsgLibrary = True
							ElseIf SSS_BILFL = 9 Then 
								If DSP_MsgBox(SSS_EEE, "_UPDATE", 0) <> 6 Then AE_MsgLibrary = True
							End If
						Case Else
							If DSP_MsgBox(SSS_EEE, "_APPEND", 0) <> 6 Then AE_MsgLibrary = True
					End Select
				End If
			Case "UPDATE2" ' 更新します。
				If PP.MainForm = "SSSMAIN" Then
					Select Case frm
						Case "ET"
							If PP_sssmain.LastDe = 0 And SSS_VALKB = False Then
								rtn = DSP_MsgBox(SSS_EEE, "_UPDATE2", 2)
								AE_MsgLibrary = True
							ElseIf SSS_BILFL = 9 Then 
								If DSP_MsgBox(SSS_EEE, "_UPDATE2", 0) <> 6 Then AE_MsgLibrary = True
							End If
						Case Else
							If DSP_MsgBox(SSS_EEE, "_APPEND", 0) <> 6 Then AE_MsgLibrary = True
					End Select
				End If
			Case "UPDATEC" ' 入力途中のデータは反映されません。
			Case Else 'Original
				Wk_Msg = "アプリケーション開発時に実施したメッセージの変更に問題があります。" 'Original
				Wk_Msg = Wk_Msg & AE_NL & "メッセージコード（" & Pm_MsgCode & "）の受け口のプログラムがありません。" 'Original
				AE_MsgBox(Wk_Msg, MsgBoxStyle.Exclamation, AE_Title) 'Original
		End Select
	End Function 'Original
	
	Public Sub AE_Stop()
		'Dim LogF
		'Dim LogFName$
		'Dim I As Integer
		'    LogFName$ = App.Path & "\@ApplLog.LOG" 'ログファイル名
		'    LogF = FreeFile
		'    Open LogFName$ For Output As #LogF
		'    Print #LogF, "LogPointer = " & CStr(AE_LogPointer) & "     (Next Point to Log)"
		'    For I = 0 To 99
		'        Print #LogF, "Log[" & Right$("00" & CStr(I), 2) & "] = """ & AE_LogBody$(I) & """"
		'    Next I
		'    Close #LogF
		Call Error_Exit("AE_Stop による中断")
		'   Stop
	End Sub
End Module