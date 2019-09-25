Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_DATE
	Inherits System.Windows.Forms.Form
	Dim DAYIDX As Short
	'   システムの日付
	Dim Sys_date As New VB6.FixedLengthString(10)
	Dim Sys_year As New VB6.FixedLengthString(4)
	Dim Sys_month As New VB6.FixedLengthString(2)
	Dim Sys_day As New VB6.FixedLengthString(2)
	'   カレンダー表示の年月
	Dim Cur_year As New VB6.FixedLengthString(4)
	Dim Cur_month As New VB6.FixedLengthString(2)
	'   祝日のバッファー
	' H_KB 祝日区分  0:祝日でない（取りやめ／施行前）, 1:振り替え休日のある祝日,
	'               2:振り替えのない休日, 3:春分/秋分, 4:第ｎ○曜
	'               第ｎ○曜の日付の意味  一桁目:第ｎ 二桁目:2～6 を 月～金 とする
	'                 例)第二月曜 = 22, 第四金曜 = 46
	' H_SttYY 施行年
	' H_OldDD 施行年以前の設定日
	' H_OldKB 施行年以前の祝日区分
	' 施行年の設定例 07/20(1)1996:00(0) = 1996年から7月20日が通常の祝日として新設された
	'               01/22(4)2000:15(1) = 2000年から第2月曜に変更された(以前は15日だった)
	Private Structure HOLIDAY_TYPE
		Dim H_MM As Short
		Dim H_DD As Short
		Dim H_KB As Short
		Dim H_SttYY As Short
		Dim H_OldDD As Short
		Dim H_OldKB As Short
	End Structure
	Dim WLS_HoliDay() As HOLIDAY_TYPE
	Dim HdayCnt As Short
	Dim D_MAX As Short
	Dim W_DAY As Short
	Dim W_DAYIDX As Short
	
	Private DblClickFl As Boolean 'DblClickイベント障害対応  97/04/07
	
	'UPGRADE_WARNING: Form イベント WLS_DATE.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_DATE_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		'DblClickイベント障害対応  97/04/07
		DblClickFl = False
		
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(Set_date.Value) Or Not IsDate(Set_date.Value) Then
			Sys_date.Value = DateString
			Sys_year.Value = VB.Left(Sys_date.Value, 4)
			Sys_month.Value = Mid(Sys_date.Value, 6, 2)
			Sys_day.Value = VB.Right(Sys_date.Value, 2)
		Else
			Sys_date.Value = Set_date.Value
			Sys_year.Value = VB.Left(Set_date.Value, 4)
			Sys_month.Value = Mid(Set_date.Value, 6, 2)
			Sys_day.Value = VB.Right(Set_date.Value, 2)
		End If
		Cur_year.Value = Sys_year.Value
		Cur_month.Value = Sys_month.Value
		Set_calendar()
		
	End Sub
	
	Private Sub WLS_DATE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = 27 Then Hide()
	End Sub
	
	Private Sub WLS_DATE_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim w_date As String
		w_date = CStr(Today)
		If Len(w_date) <> 10 Then
			MsgBox("日付の形式が違います。" & Chr(13) & "コントロールパネルの各国対応の短い形式を修正して下さい。", 48)
			Hide()
		End If
		
		'   祝日の設定
		Dim INI_NO As Short
		Dim sLine As String
		INI_NO = FreeFile
		
		On Error Resume Next
		FileOpen(INI_NO, SSS_INIDAT(2) & "CALENDAR.INI", OpenMode.Input)
		If Err.Number <> 0 Then
			On Error GoTo CALENDAR_ERR
			FileOpen(INI_NO, SSS_INIDAT(0) & "CALENDAR.INI", OpenMode.Input)
		End If
		
		ReDim WLS_HoliDay(20)
		
		HdayCnt = 0
		Do Until EOF(INI_NO)
			sLine = LineInput(INI_NO)
			If InStr(sLine, "=") = 3 And InStr(sLine, "/") = 6 And Len(sLine) > 10 Then
				If HdayCnt > UBound(WLS_HoliDay) Then ReDim Preserve WLS_HoliDay(HdayCnt + 10)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_HoliDay(HdayCnt).H_MM = SSSVal(Mid(sLine, 4, 2))
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_HoliDay(HdayCnt).H_DD = SSSVal(Mid(sLine, 7, 2))
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_HoliDay(HdayCnt).H_KB = SSSVal(Mid(sLine, 10, 1))
				If InStr(sLine, ":") = 16 And InStr(sLine, ";") = 22 Then
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WLS_HoliDay(HdayCnt).H_SttYY = SSSVal(Mid(sLine, 12, 4))
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WLS_HoliDay(HdayCnt).H_OldDD = SSSVal(Mid(sLine, 17, 2))
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WLS_HoliDay(HdayCnt).H_OldKB = SSSVal(Mid(sLine, 20, 1))
				End If
				HdayCnt = HdayCnt + 1
			End If
		Loop 
		FileClose(INI_NO)
		
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		Exit Sub
		
CALENDAR_ERR: 
		MsgBox("カレンダー情報が正しくありません。", 48)
	End Sub
	
	Private Sub Label1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label1.Click
		Dim Index As Short = Label1.GetIndex(eventSender)
		Sys_year.Value = Cur_year.Value
		Sys_month.Value = Cur_month.Value
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Sys_day.Value = VB6.Format(SSSVal(Me.Label1(Index).Text), "00")
		Me.Label1(W_DAYIDX).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0C0C0)
		W_DAYIDX = Index
		Me.Label1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HFFFF00)
	End Sub
	
	Private Sub Label1_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label1.DoubleClick
		Dim Index As Short = Label1.GetIndex(eventSender)
		Dim C_day As Short
		C_day = Index + 2 - W_DAY
		If C_day > 0 And C_day <= D_MAX Then
			Set_date.Value = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
			Call WLS_SLIST_MOVE(Set_date.Value, Len(Set_date.Value))
			'DblClickイベント障害対応  97/04/07
			DblClickFl = True
		End If
	End Sub
	
	Private Sub Set_calendar()
		'   初期化設定
		Dim yy As Short
		Dim mm As Short
		Dim hday, hyear, hidx As Short
		Dim HdayArr() As Short
		
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		yy = SSSVal(Cur_year.Value)
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mm = SSSVal(Cur_month.Value)
		'UPGRADE_WARNING: オブジェクト WLS_DATE.ymdpanel.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Me.ymdpanel.Caption = VB6.Format(yy, "0000") & "年 " & VB6.Format(mm, "00") & "月"
		
		'   当月の日数計算(28-31)
		If mm = 1 Or mm = 3 Or mm = 5 Or mm = 7 Or mm = 8 Or mm = 10 Or mm = 12 Then
			D_MAX = 31
		ElseIf mm = 4 Or mm = 6 Or mm = 9 Or mm = 11 Then 
			D_MAX = 30
		ElseIf (yy Mod 4 = 0 And yy Mod 100 <> 0) Or yy Mod 400 = 0 Then 
			D_MAX = 29
		Else
			D_MAX = 28
		End If
		
		ReDim HdayArr(D_MAX)
		Dim tmpX, tmpN, tmpD As Short
		
		'   当月一日の曜日計算(1-7)
		Dim s_date As New VB6.FixedLengthString(10)
		s_date.Value = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/01"
		'UPGRADE_WARNING: DateValue に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		W_DAY = WeekDay(DateValue(s_date.Value))
		
		'   各日付への区分設定 0:通常, 1:振替可能祝日, 2:振替不可休日
		For hidx = 0 To HdayCnt - 1
			If WLS_HoliDay(hidx).H_MM = mm Then
				If WLS_HoliDay(hidx).H_KB = 3 Then '春分/秋分
					'   春分と秋分の計算
					hyear = yy - 1980
					If mm = 3 Then
						Select Case hyear
							Case 0, 4, 8, 12, 13, 16, 17, 20, 21, 24, 25, 28, 29, 32, 33, 36, 37, 40, 41, 44, 45, 46, 48, 49, 50, 52, 53, 54, 56, 57, 58, 60, 61, 62, 64, 65, 66, 68, 69, 70
								hday = 20
							Case Else
								hday = 21
						End Select
					ElseIf mm = 9 Then 
						Select Case hyear
							Case 32, 36, 40, 44, 48, 52, 56, 60, 64, 65, 68, 69
								hday = 22
							Case Else
								hday = 23
						End Select
					End If
					HdayArr(hday) = 1
				ElseIf WLS_HoliDay(hidx).H_SttYY > yy Then  '施行日以前
					'H_OldDD =0 の場合はダミー配列(=0)に入る
					If WLS_HoliDay(hidx).H_OldKB = 4 Then '第N X曜日
						tmpN = WLS_HoliDay(hidx).H_OldDD / 10
						tmpX = WLS_HoliDay(hidx).H_OldDD Mod 10
						tmpD = tmpX - W_DAY + (tmpN - 1) * 7
						If tmpX < W_DAY Then tmpD = tmpD + 7
						HdayArr(tmpD) = 2
					Else
						HdayArr(WLS_HoliDay(hidx).H_OldDD) = WLS_HoliDay(hidx).H_OldKB
					End If
				ElseIf WLS_HoliDay(hidx).H_KB = 4 Then  '第N X曜日
					tmpN = WLS_HoliDay(hidx).H_DD / 10
					tmpX = WLS_HoliDay(hidx).H_DD Mod 10
					tmpD = tmpX - W_DAY + (tmpN - 1) * 7 + 1
					If tmpX < W_DAY Then tmpD = tmpD + 7
					HdayArr(tmpD) = 2
				Else
					HdayArr(WLS_HoliDay(hidx).H_DD) = WLS_HoliDay(hidx).H_KB
				End If
			End If
		Next hidx
		
		'   日付の計算
		Dim count As Short ' count:日数
		Dim hnext As Short ' hnext:振替休日かどうか
		Dim k, X, Y, L As Short ' x:X座標, y:Y座標, k:座標連番(0～41),
		hnext = False
		count = 2 - W_DAY
		For Y = 0 To 5
			For X = 0 To 6
				k = Y * 7 + X
				If count > 0 And count <= D_MAX Then
					Me.Label1(k).Enabled = True
					Me.Label1(k).Text = Str(count)
					Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(&H80000008)
					Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0C0C0)
					If hnext Then ' 振替休日かどうか
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
						hnext = False
					ElseIf X = 0 Then  ' 日曜日
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
						If HdayArr(count) = 1 Then hnext = True '当日が振替可能な祝日なら振替休日を設定する
					ElseIf HdayArr(count) > 0 Then 
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
					ElseIf X = 6 Then  '土曜日
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
					End If
					'UPGRADE_WARNING: オブジェクト SSSVal(Sys_day) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(Sys_month) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(Sys_year) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If SSSVal(Sys_year.Value) = yy And SSSVal(Sys_month.Value) = mm And SSSVal(Sys_day.Value) = count Then
						Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(&HFFFF00)
						W_DAYIDX = k
					End If
				Else
					Me.Label1(k).Enabled = False
					Me.Label1(k).Text = ""
					Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(&H80000008)
					Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0C0C0)
				End If
				count = count + 1
			Next X
		Next Y
	End Sub
	
	Private Sub Label1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = Label1.GetIndex(eventSender)
		'UnLoadイベント障害対応  97/04/07
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		Dim yy As Short
		Dim mm As Short
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		yy = SSSVal(Cur_year.Value)
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mm = SSSVal(Cur_month.Value)
		If mm = 12 Then
			yy = yy + 1
			mm = 1
		Else
			mm = mm + 1
		End If
		Cur_year.Value = VB6.Format(yy, "0000")
		Cur_month.Value = VB6.Format(mm, "00")
		Set_calendar()
		
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
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'UnLoadイベント障害対応  97/04/07
		'Unload Me
		Hide()
	End Sub
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		Dim yy As Short
		Dim mm As Short
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		yy = SSSVal(Cur_year.Value)
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mm = SSSVal(Cur_month.Value)
		If mm = 1 Then
			yy = yy - 1
			mm = 12
		Else
			mm = mm - 1
		End If
		Cur_year.Value = VB6.Format(yy, "0000")
		Cur_month.Value = VB6.Format(mm, "00")
		Set_calendar()
		
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
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		Dim C_day As Short
		If (Sys_year.Value = Cur_year.Value) And (Sys_month.Value = Cur_month.Value) Then
			C_day = W_DAYIDX + 2 - W_DAY
			If C_day > 0 And C_day <= D_MAX Then
				Set_date.Value = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
				'            internal_flag = 3
				Call WLS_SLIST_MOVE(Set_date.Value, Len(Set_date.Value))
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			End If
		Else
			MsgBox("日付が選択されていません")
		End If
	End Sub
End Class