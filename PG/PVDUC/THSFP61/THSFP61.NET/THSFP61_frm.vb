Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'*** End Of Generated Declaration Section ****
	' === 20110217 === INSERT S TOM)Morimoto
	Private Const gv_strOUT_TYPE As String = ".TXT"
	' === 20110217 === INSERT E
	
	
	Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "メニューに戻ります。"
	End Sub
	' === 20110216 === INSERT S TOM)Morimoto ファイル書き込み実行を追加
	Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
		'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CuVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_STTTOKCD.TabIndex).CuVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(HD_FRNKB.TabIndex).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_Execute(CP_SSSMAIN(HD_THSCD.TabIndex).CuVal, CP_SSSMAIN(HD_FRNKB.TabIndex).CuVal, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_STTTOKCD.TabIndex).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CuVal))
	End Sub
	
	Private Sub CM_Execute_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		If PP_SSSMAIN.Operable Then CM_Execute.Image = IM_Execute(1).Image
	End Sub
	
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "実行します。"
	End Sub
	
	Private Sub CM_Execute_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		If PP_SSSMAIN.Operable Then CM_Execute.Image = IM_Execute(0).Image
	End Sub
	' === 20110216 === INSERT E
	
	Private Sub CM_FSTART_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "ファイルに出力します。"
	End Sub
	' === 20110216 === DELETE S TOM)Morimoto
	'Private Sub CM_LCONFIG_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
	'    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
	'    TX_Message.Text = "プリンターを選択します。"
	'End Sub
	'
	'Private Sub CM_LSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
	'    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
	'    TX_Message.Text = "印刷を開始します。"
	'End Sub
	'
	Private Sub CM_Slist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Slist.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "ウィンドウを表示します。"
	End Sub
	'
	'Private Sub CM_VSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
	'    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
	'    TX_Message.Text = "印刷イメージを表示します。"
	'End Sub
	' === 20110216 === DELETE E
	
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click 'Generated.
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		PP_SSSMAIN.NeglectLostFocusCheck = True
		PP_SSSMAIN.CloseCode = 1
		Call AE_EndCm_SSSMAIN()
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub CM_ENDCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_ENDCM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_EndCm.Image = IM_EndCm(1).Image
	End Sub
	
	Private Sub CM_ENDCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_ENDCM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_EndCm.Image = IM_EndCm(0).Image
	End Sub
	' === 20110217 === DELETE S TOM)Morimoto
	'Private Sub CM_FSTART_Click() 'Generated.
	'   PP_SSSMAIN.ButtonClick = True
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   PP_SSSMAIN.NeglectLostFocusCheck = True
	'   If FSTART_GetEvent() Then
	'   End If
	'   PP_SSSMAIN.NeglectLostFocusCheck = False
	'   Call AE_CursorCurrent_SSSMAIN
	'End Sub
	'
	'Private Sub CM_FSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
	'   If PP_SSSMAIN.Operable Then CM_FSTART.Picture = IM_FSTART(1).Picture
	'End Sub
	'
	'Private Sub CM_FSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
	'   If PP_SSSMAIN.Operable Then CM_FSTART.Picture = IM_FSTART(0).Picture
	'End Sub
	' === 20110217 === DELETE E
	
	Private Sub CM_LCANCEL_Click() 'Generated.
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		PP_SSSMAIN.NeglectLostFocusCheck = True
		' === 20110217 === DELETE S TOM)Morimoto
		'   If LCANCEL_GetEvent() Then
		'   End If
		' === 20110217 === DELETE E
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub CM_LCANCEL_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CM_LCANCEL_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CM_LCANCEL_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	
	' === 20110216 === DELETE S TOM)Morimoto
	'Private Sub CM_LCONFIG_Click() 'Generated.
	'   PP_SSSMAIN.ButtonClick = True
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   PP_SSSMAIN.NeglectLostFocusCheck = True
	'   If LCONFIG_GetEvent() Then
	'   End If
	'   PP_SSSMAIN.NeglectLostFocusCheck = False
	'   Call AE_CursorCurrent_SSSMAIN
	'End Sub
	'
	'Private Sub CM_LCONFIG_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
	'   If PP_SSSMAIN.Operable Then CM_LCONFIG.Picture = IM_LCONFIG(1).Picture
	'End Sub
	'
	'Private Sub CM_LCONFIG_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
	'   If PP_SSSMAIN.Operable Then CM_LCONFIG.Picture = IM_LCONFIG(0).Picture
	'End Sub
	'
	'Private Sub CM_LSTART_Click() 'Generated.
	'   PP_SSSMAIN.ButtonClick = True
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   PP_SSSMAIN.NeglectLostFocusCheck = True
	'   If LSTART_GetEvent() Then
	'   End If
	'   PP_SSSMAIN.NeglectLostFocusCheck = False
	'   Call AE_CursorCurrent_SSSMAIN
	'End Sub
	'
	'Private Sub CM_LSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
	'   If PP_SSSMAIN.Operable Then CM_LSTART.Picture = IM_LSTART(1).Picture
	'End Sub
	'
	'Private Sub CM_LSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
	'   If PP_SSSMAIN.Operable Then CM_LSTART.Picture = IM_LSTART(0).Picture
	'End Sub
	
	Private Sub CM_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Slist.Click 'Generated.
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
		Call AE_Slist_SSSMAIN()
		PP_SSSMAIN.NeglectLostFocusCheck = False
		'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_SLIST.Image = IM_Slist(1).Image
	End Sub
	
	Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_SLIST.Image = IM_Slist(0).Image
	End Sub
	
	'Private Sub CM_VSTART_Click() 'Generated.
	'   PP_SSSMAIN.ButtonClick = True
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   PP_SSSMAIN.NeglectLostFocusCheck = True
	'   If VSTART_GetEvent() Then
	'   End If
	'   PP_SSSMAIN.NeglectLostFocusCheck = False
	'   Call AE_CursorCurrent_SSSMAIN
	'End Sub
	'
	'Private Sub CM_VSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
	'   If PP_SSSMAIN.Operable Then CM_VSTART.Picture = IM_VSTART(1).Picture
	'End Sub
	'
	'Private Sub CM_VSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
	'   If PP_SSSMAIN.Operable Then CM_VSTART.Picture = IM_VSTART(0).Picture
	'End Sub
	' === 20110216 === DELETE E
	
	Private Sub FM_PANEL3D1_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_PANEL3D14_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_PANEL3D15_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_PANEL3D2_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_PANEL3D4_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	'UPGRADE_WARNING: Form イベント FR_SSSMAIN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub FR_SSSMAIN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated 'Generated.
		Dim wk_ww As Short
		Dim wk_De As Short
		Dim wk_xx As Short
		If PP_SSSMAIN.Activated = 0 Then
			PP_SSSMAIN.Activated = 1
		End If
	End Sub
	
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load 'Generated.
		Dim wk_De As Short
		Dim wk_ww As Short
		Dim wk_Tx As Short
		Dim wk_TxBase As Short
		Dim wk_HeadN As Short
		Dim wk_BodyN As Short
		Dim wk_EBodyN As Short
		Dim wk_TailN As Short
		Dim wk_Top As Single
		Dim wk_Height As Single
		Dim wk_Px As Short
		Dim wk_PxBase As Short
		Dim wk_SmrBuf As String
		Dim PY_TTop As Single
		
		' === 20110216 === INSERT S TOM)Morimoto
		Dim Wk_Index As Short
		show_GAGE(False)
		' === 20110216 === INSERT E
		' === 20110216 === UPDATE S TOM)Morimoto
		'   AE_Title$ = "取引先一覧マスタリスト                   "
		AE_Title = "取引先マスタ一括抽出                     "
		' === 20110216 === UPDATE E
		'初画面表示の性能チューニング用 ----------
		'Dim StartTime
		'   AE_MsgBox "Start Point", vbInformation, AE_Title$
		'   StartTime = Timer
		'-----------------------------------------
		With PP_SSSMAIN
			.FormWidth = 8625
			' === 20110216 === UPDATE S TOM)Morimoto
			'   .FormHeight = 6015
			.FormHeight = 7305
			' === 20110216 === UPDATE E
			.MaxDe = -1
			.MaxDsp = -1
			' === 20110216 === UPDATE S TOM)Morimoto
			'   .HeadN = 7
			.HeadN = 8
			' === 20110216 === UPDATE E
			.BodyN = 0
			.BodyV = 0
			.MaxEDe = -1
			.MaxEDsp = -1
			.EBodyN = 0
			.EBodyV = 0
			.TailN = 0
			' === 20110216 === UPDATE S TOM)Morimoto
			'   .BodyPx = 7
			'   .EBodyPx = 7
			'   .TailPx = 7
			'   .PrpC = 7
			.BodyPx = .HeadN
			.EBodyPx = .HeadN
			.TailPx = .HeadN
			.PrpC = .HeadN
			' === 20110216 === UPDATE E
			.Operable = False
			.BrightOnOff = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON)
			.SuppressVSScroll = 0
			.UniScrl = False
			.SetCursorRR = True
			.SetCursorLF = False
			.VisibleForItem = False
			.AllowNullDes = False
			.No2Scroll = False
			.SpecSubID = "sss"
			.UnDoDeOp = 0
			.ActiveBlockNo = -1
			.MaxBlockNo = 1
			If .MainForm = "" Then
				.ScX = AE_ScX
				AE_ScX = AE_ScX + 1
				ReDim Preserve AE_Timer(.ScX)
				ReDim Preserve AE_CursorRest(.ScX)
				ReDim Preserve AE_ModeBar(.ScX)
				ReDim Preserve AE_StatusBar(.ScX)
				ReDim Preserve AE_StatusCodeBar(.ScX)
				.CtB = AE_CtB
				' === 20110216 === UPDATE S TOM)Morimoto
				'      AE_CtB = AE_CtB + 7
				'      ReDim Preserve AE_Controls(.CtB + 6)
				'      .MainFormFile = "THSPR51.FRM"
				AE_CtB = AE_CtB + .HeadN
				ReDim Preserve AE_Controls(.CtB + .HeadN - 1)
				.MainFormFile = "THSFP61.FRM"
				' === 20110216 === UPDATE E
				.MainFormObj = "FR_SSSMAIN"
				.SelValid = False
				.ArrowLimit = False
				.NullZero = True
				.ErrorByBackColor = False
				AE_SSSWin = True
				.AL = False
			End If
			If AE_FormInit(PP_SSSMAIN, Me, AE_Title, Cn_ClIncomplete, System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClCheckError), System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClRelCheck), System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClChecked)) <> "V6.60" Then
#If ActiveXcompile = 0 Then
				AE_MsgBox("再生成が必要です。", MsgBoxStyle.Critical, "ｅｅｅ") : End
#Else
				'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
				AE_MsgBox "再生成が必要です。", vbCritical, "ｅｅｅ"
#End If
			End If
			If .MainForm = "" Then
				.MainForm = "SSSMAIN"
				Call AE_PSIR_SSSMAIN()
				wk_ww = 0
				wk_De = 1
				wk_HeadN = 0 : wk_BodyN = 0 : wk_EBodyN = 0 : wk_TailN = 0
				Do While wk_ww < AE_PSIC
					wk_SmrBuf = Trim(AE_PSI(wk_ww)) & Space(1)
					wk_ww = wk_ww + 1
					Select Case UCase(VB.Left(wk_SmrBuf, Cn_PrfxLen))
						Case "HD_", "HV_"
							Call AE_SetCp(CP_SSSMAIN(wk_HeadN), wk_HeadN, wk_SmrBuf, CQ_SSSMAIN(wk_HeadN))
							wk_HeadN = wk_HeadN + 1
					End Select
				Loop 
			End If
			HD_OPEID.Text = ""
			HD_OPENM.Text = ""
			HD_THSCD.Text = ""
			' === 20110216 === INSERT S TOM)Morimoto
			HD_FRNKB.Text = ""
			' === 20110216 === INSERT E
			HD_STTTOKCD.Text = ""
			HD_STTTOKNM.Text = ""
			HD_ENDTOKCD.Text = ""
			HD_ENDTOKNM.Text = ""
			' === 20110216 === UPDATE S TOM)Morimoto
			'   HD_OPEID.TabIndex = 0
			'   Set AE_Controls(.CtB + 0) = HD_OPEID
			'   HD_OPENM.TabIndex = 1
			'   Set AE_Controls(.CtB + 1) = HD_OPENM
			'   HD_THSCD.TabIndex = 2
			'   Set AE_Controls(.CtB + 2) = HD_THSCD
			'   HD_STTTOKCD.TabIndex = 3
			'   Set AE_Controls(.CtB + 3) = HD_STTTOKCD
			'   HD_STTTOKNM.TabIndex = 4
			'   Set AE_Controls(.CtB + 4) = HD_STTTOKNM
			'   HD_ENDTOKCD.TabIndex = 5
			'   Set AE_Controls(.CtB + 5) = HD_ENDTOKCD
			'   HD_ENDTOKNM.TabIndex = 6
			'   Set AE_Controls(.CtB + 6) = HD_ENDTOKNM
			'   TX_CursorRest.TabIndex = 7
			Wk_Index = 0
			HD_OPEID.TabIndex = Wk_Index
			AE_Controls(.CtB + Wk_Index) = HD_OPEID
			Wk_Index = Wk_Index + 1
			HD_OPENM.TabIndex = Wk_Index
			AE_Controls(.CtB + Wk_Index) = HD_OPENM
			Wk_Index = Wk_Index + 1
			HD_THSCD.TabIndex = Wk_Index
			AE_Controls(.CtB + Wk_Index) = HD_THSCD
			Wk_Index = Wk_Index + 1
			HD_FRNKB.TabIndex = Wk_Index
			AE_Controls(.CtB + Wk_Index) = HD_FRNKB
			Wk_Index = Wk_Index + 1
			HD_STTTOKCD.TabIndex = Wk_Index
			AE_Controls(.CtB + Wk_Index) = HD_STTTOKCD
			Wk_Index = Wk_Index + 1
			HD_STTTOKNM.TabIndex = Wk_Index
			AE_Controls(.CtB + Wk_Index) = HD_STTTOKNM
			Wk_Index = Wk_Index + 1
			HD_ENDTOKCD.TabIndex = Wk_Index
			AE_Controls(.CtB + Wk_Index) = HD_ENDTOKCD
			Wk_Index = Wk_Index + 1
			HD_ENDTOKNM.TabIndex = Wk_Index
			AE_Controls(.CtB + Wk_Index) = HD_ENDTOKNM
			Wk_Index = Wk_Index + 1
			TX_CursorRest.TabIndex = Wk_Index
			' === 20110216 === UPDATE E
			AE_Timer(.ScX) = TM_StartUp
			AE_CursorRest(.ScX) = TX_CursorRest
			AE_ModeBar(.ScX) = TX_Mode
			AE_StatusBar(.ScX) = TX_Message
			AE_StatusCodeBar(.ScX) = TX_Message
			.Mode = Cn_Mode1 : TX_Mode.Text = "追加"
			Call AE_ClearInitValStatus_SSSMAIN()
			.PY_BTop = VB6.PixelsToTwipsY(Me.Height)
			.PY_EBTop = VB6.PixelsToTwipsY(Me.Height)
			PY_TTop = VB6.PixelsToTwipsY(Me.Height)
			.MaxDspC = 0
			' === 20110216 === UPDATE S TOM)Morimoto
			'   .NrBodyTx = 7
			.NrBodyTx = Wk_Index
			' === 20110216 === UPDATE E
			.ScrlMaxL = 1
			.MaxEDspC = 0
			' === 20110216 === UPDATE S TOM)Morimoto
			'   .NrEBodyTx = 7
			.NrEBodyTx = Wk_Index
			' === 20110216 === UPDATE E
			.EScrlMaxL = 1
			' === 20110216 === UPDATE S TOM)Morimoto
			'   Call AE_TabStop_SSSMAIN(0, 6, True)
			Call AE_TabStop_SSSMAIN(0, Wk_Index - 1, True)
			' === 20110216 === UPDATE E
			TX_CursorRest.TabStop = False
			TX_Mode.TabStop = False
			TX_Message.TabStop = False
			TX_Message.Text = ""
			wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
			Call AE_WindowProcSet_SSSMAIN()
			ReleaseTabCapture(0)
			SetTabCapture(Me.Handle.ToInt32)
			'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Var = SSSMAIN_BeginPrg()
			.FormWidth = VB6.PixelsToTwipsX(Me.Width)
			.FormHeight = VB6.PixelsToTwipsY(Me.Height)
			'初画面表示の性能チューニング用 ----------
			'   AE_MsgBox Str$(Timer - StartTime), vbInformation, AE_Title$
			'-----------------------------------------
			.TimerStartUp = True
		End With
		TM_StartUp.Enabled = True
	End Sub
	
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason 'Generated.
		PP_SSSMAIN.UnloadMode = UnloadMode
		Select Case UnloadMode
			Case 0, 3
				PP_SSSMAIN.CloseCode = 2
				Cancel = True
				Call AE_EndCm_SSSMAIN()
			Case 2
				PP_SSSMAIN.Caption = Me.Text
				If AE_MsgLibrary(PP_SSSMAIN, "QueryUnload") = False Then Cancel = True
		End Select
		eventArgs.Cancel = Cancel
	End Sub
	
	'UPGRADE_WARNING: イベント FR_SSSMAIN.Resize は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub FR_SSSMAIN_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize 'Generated.
		Static FirstTime As Object
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(FirstTime) Then
			'UPGRADE_WARNING: オブジェクト FirstTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FirstTime = False
		ElseIf Not PP_SSSMAIN.Operable Then 
		Else
			If Me.WindowState = 0 Then
				If VB6.PixelsToTwipsY(Me.Height) > PP_SSSMAIN.FormHeight Then Me.Height = VB6.TwipsToPixelsY(PP_SSSMAIN.FormHeight)
				If VB6.PixelsToTwipsX(Me.Width) > PP_SSSMAIN.FormWidth Then Me.Width = VB6.TwipsToPixelsX(PP_SSSMAIN.FormWidth)
			End If
		End If
		'   Call AE_Resize(PP_SSSMAIN)
	End Sub
	
	Private Sub FR_SSSMAIN_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed 'Generated.
		Dim ReturnCode As Short
		PP_SSSMAIN.CloseCode = 11
		If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then
			If AE_MsgLibrary(PP_SSSMAIN, "EndCk") Then
				'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
				Cancel = True : Exit Sub
			End If
		Else
			If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then
				'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
				Cancel = True : Exit Sub
			End If
		End If
		' === 20110217 === DELETE S TOM)Morimoto
		'    wk_Var = SSSMAIN_Close()
		' === 20110217 === DELETE E
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If wk_Var <> 0 Then
		End If
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If wk_Var = -1 Then
			wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
			Call AE_WindowProcReset(PP_SSSMAIN)
			ReleaseTabCapture(Me.Handle.ToInt32)
			If PP_SSSMAIN.hIMC <> 0 Then
				Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
			End If
#If ActiveXcompile = 0 Then
			End
#End If
			'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf wk_Var = 0 Then 
			'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
			Cancel = True
			'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf wk_Var = 1 Then 
			wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
			Call AE_WindowProcReset(PP_SSSMAIN)
			ReleaseTabCapture(Me.Handle.ToInt32)
			If PP_SSSMAIN.hIMC <> 0 Then
				Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
			End If
		End If
		PP_SSSMAIN.CloseCode = -1
	End Sub
	
	'UPGRADE_WARNING: イベント HD_ENDTOKCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_ENDTOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDTOKCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			' === 20110216 === UPDATE S TOM)Morimoto
			'      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD) Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD) Then
				' === 20110216 === UPDATE E
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_ENDTOKCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub HD_ENDTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDTOKCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		' === 20110216 === UPDATE S TOM)Morimoto
		'   PP_SSSMAIN.Tx = 5
		PP_SSSMAIN.Tx = HD_ENDTOKCD.TabIndex
		' === 20110216 === UPDATE E
		PP_SSSMAIN.De2 = -1
		' === 20110216 === UPDATE S TOM)Morimoto
		'   PP_SSSMAIN.Px = 5
		PP_SSSMAIN.Px = HD_ENDTOKCD.TabIndex
		' === 20110216 === UPDATE E
		If Not PP_SSSMAIN.Operable Then Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD)
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD)
		' === 20110216 === UPDATE E
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD)
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD)
		' === 20110216 === UPDATE E
		HD_ENDTOKCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト ENDTOKCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = ENDTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal))
			'UPGRADE_WARNING: オブジェクト ENDTOKCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = ENDTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CuVal))
		Else
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = PP_SSSMAIN.SlistCom
		End If
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If Not IsDbNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
			PP_SSSMAIN.SlistPx = -1
			PP_SSSMAIN.CursorDirection = Cn_Direction1
			PP_SSSMAIN.CursorDest = Cn_Dest9
			PP_SSSMAIN.JustAfterSList = True
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				' === 20110216 === UPDATE S TOM)Morimoto
				'         CP_SSSMAIN(5).TpStr = wk_Slisted
				'         CP_SSSMAIN(5).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(HD_ENDTOKCD.TabIndex).TpStr = wk_Slisted
				CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CIn = Cn_ChrInput
				' === 20110216 === UPDATE E
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_ENDTOKCD.Text = wk_Slisted
				' === 20110216 === UPDATE S TOM)Morimoto
				'         Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(5), (HD_ENDTOKCD)), Cn_Status6, True, True)
				Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD.Text), Cn_Status6, True, True)
				' === 20110216 === UPDATE E
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_ENDTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_ENDTOKCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If AE_KeyDown_SSSMAIN(HD_ENDTOKCD, KeyCode, Shift, CP_SSSMAIN(5).TpStr) Then
		'      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(5), (HD_ENDTOKCD)), Cn_Status6, True, True)
		'      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (5)
		If AE_KeyDown_SSSMAIN(HD_ENDTOKCD, KEYCODE, Shift, CP_SSSMAIN(HD_ENDTOKCD.TabIndex).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(HD_ENDTOKCD.TabIndex)
			' === 20110216 === UPDATE E
		End If
	End Sub
	
	Private Sub HD_ENDTOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_ENDTOKCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If PP_SSSMAIN.Tx <> 5 Then Beep: KeyAscii = 0: Exit Sub
		'   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD, KeyAscii)
		If PP_SSSMAIN.Tx <> HD_ENDTOKCD.TabIndex Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD, KeyAscii)
		' === 20110216 === UPDATE E
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_ENDTOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDTOKCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
		'      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(5), (HD_ENDTOKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
		If CP_SSSMAIN(HD_ENDTOKCD.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_ENDTOKCD.Focus()
			End If
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If HD_ENDTOKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
		If System.Drawing.ColorTranslator.ToOle(HD_ENDTOKCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), CL_SSSMAIN(HD_ENDTOKCD.TabIndex), PP_SSSMAIN.Tx)
		' === 20110216 === UPDATE E
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_ENDTOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDTOKCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then
			' === 20110216 === DELETE S TOM)Morimoto
			'      If (Button And vbRightButton) = vbRightButton Then
			'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_ENDTOKCD)
			'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
			'         PP_SSSMAIN.NeglectPopupFocus = False
			'         Dim wk_Tx As Integer
			'         wk_Tx = PP_SSSMAIN.Tx
			'         If PP_SSSMAIN.PopupTx = HD_ENDTOKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
			'         DoEvents
			'         HD_ENDTOKCD.Enabled = True
			'         Call AE_CursorMove_SSSMAIN(wk_Tx)
			'      End If
			' === 20110216 === DELETE E
			' === 20110216 === UPDATE S TOM)Morimoto
			'      PP_SSSMAIN.MouseDownTx = 5
			PP_SSSMAIN.MouseDownTx = HD_ENDTOKCD.TabIndex
			' === 20110216 === UPDATE E
		End If
	End Sub
	
	Private Sub HD_ENDTOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDTOKCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_ENDTOKCD.ReadOnly = False
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD)
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD)
		' === 20110216 === UPDATE E
	End Sub
	
	'UPGRADE_WARNING: イベント HD_ENDTOKNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_ENDTOKNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDTOKNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			' === 20110216 === UPDATE S TOM)Morimoto
			'      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM) Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKNM) Then
				' === 20110216 === UPDATE E
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_ENDTOKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub HD_ENDTOKNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDTOKNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		' === 20110216 === UPDATE S TOM)Morimoto
		'   PP_SSSMAIN.Tx = 6
		PP_SSSMAIN.Tx = HD_ENDTOKNM.TabIndex
		' === 20110216 === UPDATE E
		PP_SSSMAIN.De2 = -1
		' === 20110216 === UPDATE S TOM)Morimoto
		'   PP_SSSMAIN.Px = 6
		PP_SSSMAIN.Px = HD_ENDTOKNM.TabIndex
		' === 20110216 === UPDATE E
		If Not PP_SSSMAIN.Operable Then Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM)
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM)
		' === 20110216 === UPDATE E
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM)
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM)
		' === 20110216 === UPDATE E
		HD_ENDTOKNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_ENDTOKNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_ENDTOKNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If AE_KeyDown_SSSMAIN(HD_ENDTOKNM, KeyCode, Shift, CP_SSSMAIN(6).TpStr) Then
		'      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val3(CP_SSSMAIN(6), (HD_ENDTOKNM)), Cn_Status6, True, True)
		'      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (6)
		If AE_KeyDown_SSSMAIN(HD_ENDTOKNM, KEYCODE, Shift, CP_SSSMAIN(HD_ENDTOKNM.TabIndex).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val3(CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(HD_ENDTOKNM.TabIndex)
			' === 20110216 === UPDATE E
		End If
	End Sub
	
	Private Sub HD_ENDTOKNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_ENDTOKNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If PP_SSSMAIN.Tx <> 6 Then Beep: KeyAscii = 0: Exit Sub
		'   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM, KeyAscii)
		If PP_SSSMAIN.Tx <> HD_ENDTOKNM.TabIndex Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM, KeyAscii)
		' === 20110216 === UPDATE E
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_ENDTOKNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDTOKNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
		'      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val3(CP_SSSMAIN(6), (HD_ENDTOKNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
		If CP_SSSMAIN(HD_ENDTOKNM.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val3(CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_ENDTOKNM.Focus()
			End If
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If HD_ENDTOKNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
		If System.Drawing.ColorTranslator.ToOle(HD_ENDTOKNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), CL_SSSMAIN(HD_ENDTOKNM.TabIndex), PP_SSSMAIN.Tx)
		' === 20110216 === UPDATE E
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_ENDTOKNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDTOKNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then
			' === 20110216 === DELETE S TOM)Morimoto
			'      If (Button And vbRightButton) = vbRightButton Then
			'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_ENDTOKNM)
			'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
			'         PP_SSSMAIN.NeglectPopupFocus = False
			'         Dim wk_Tx As Integer
			'         wk_Tx = PP_SSSMAIN.Tx
			'         If PP_SSSMAIN.PopupTx = HD_ENDTOKNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
			'         DoEvents
			'         HD_ENDTOKNM.Enabled = True
			'         Call AE_CursorMove_SSSMAIN(wk_Tx)
			'      End If
			' === 20110216 === DELETE E
			' === 20110216 === UPDATE S TOM)Morimoto
			'      PP_SSSMAIN.MouseDownTx = 6
			PP_SSSMAIN.MouseDownTx = HD_ENDTOKNM.TabIndex
			' === 20110216 === UPDATE E
		End If
	End Sub
	
	Private Sub HD_ENDTOKNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDTOKNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_ENDTOKNM.ReadOnly = False
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM)
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM)
		' === 20110216 === UPDATE E
	End Sub
	' === 20110216 === INSERT S TOM)Morimoto
	'UPGRADE_WARNING: イベント HD_FRNKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_FRNKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_FRNKB.TextChanged
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB) Then
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_FRNKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub HD_FRNKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_FRNKB.Enter
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = HD_FRNKB.TabIndex
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = HD_FRNKB.TabIndex
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB)
		HD_FRNKB.BackColor = SSSMSG_BAS.Cn_ClBrightON
	End Sub
	
	Private Sub HD_FRNKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_FRNKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If AE_KeyDown_SSSMAIN(HD_FRNKB, KEYCODE, Shift, CP_SSSMAIN(HD_FRNKB.TabIndex).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_FRNKB(AE_Val3(CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(HD_FRNKB.TabIndex)
		End If
	End Sub
	
	Private Sub HD_FRNKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_FRNKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If PP_SSSMAIN.Tx <> HD_FRNKB.TabIndex Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_FRNKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_FRNKB.Leave
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(HD_FRNKB.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_THSCD(AE_Val3(CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_FRNKB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_FRNKB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), CL_SSSMAIN(HD_FRNKB.TabIndex), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_FRNKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_FRNKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		If PP_SSSMAIN.Operable Then
			PP_SSSMAIN.MouseDownTx = HD_FRNKB.TabIndex
		End If
	End Sub
	
	Private Sub HD_FRNKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_FRNKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		HD_FRNKB.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB)
	End Sub
	' === 20110216 === INSERT E
	
	'UPGRADE_WARNING: イベント HD_OPEID.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OPEID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID) Then
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_OPEID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub HD_OPEID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 0
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 0
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
		HD_OPEID.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_OPEID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPEID.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OPEID, KEYCODE, Shift, CP_SSSMAIN(0).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), HD_OPEID.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(0)
		End If
	End Sub
	
	Private Sub HD_OPEID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPEID.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 0 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_OPEID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), HD_OPEID.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_OPEID.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_OPEID.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_OPEID_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPEID.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then
			' === 20110216 === DELETE S TOM)Morimoto
			'      If (Button And vbRightButton) = vbRightButton Then
			'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPEID)
			'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
			'         PP_SSSMAIN.NeglectPopupFocus = False
			'         Dim wk_Tx As Integer
			'         wk_Tx = PP_SSSMAIN.Tx
			'         If PP_SSSMAIN.PopupTx = HD_OPEID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
			'         DoEvents
			'         HD_OPEID.Enabled = True
			'         Call AE_CursorMove_SSSMAIN(wk_Tx)
			'      End If
			' === 20110216 === DELETE E
			PP_SSSMAIN.MouseDownTx = 0
		End If
	End Sub
	
	Private Sub HD_OPEID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPEID.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_OPEID.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_OPENM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OPENM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM) Then
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_OPENM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub HD_OPENM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 1
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 1
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM)
		HD_OPENM.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_OPENM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPENM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OPENM, KEYCODE, Shift, CP_SSSMAIN(1).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), HD_OPENM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(1)
		End If
	End Sub
	
	Private Sub HD_OPENM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPENM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 1 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_OPENM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), HD_OPENM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_OPENM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_OPENM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_OPENM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPENM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then
			' === 20110216 === DELETE S TOM)Morimoto
			'      If (Button And vbRightButton) = vbRightButton Then
			'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPENM)
			'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
			'         PP_SSSMAIN.NeglectPopupFocus = False
			'         Dim wk_Tx As Integer
			'         wk_Tx = PP_SSSMAIN.Tx
			'         If PP_SSSMAIN.PopupTx = HD_OPENM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
			'         DoEvents
			'         HD_OPENM.Enabled = True
			'         Call AE_CursorMove_SSSMAIN(wk_Tx)
			'      End If
			' === 20110216 === DELETE E
			PP_SSSMAIN.MouseDownTx = 1
		End If
	End Sub
	
	Private Sub HD_OPENM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPENM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_OPENM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_STTTOKCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_STTTOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			' === 20110216 === UPDATE S TOM)Morimoto
			'      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD) Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD) Then
				' === 20110216 === UPDATE E
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_STTTOKCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub HD_STTTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		' === 20110216 === UPDATE S TOM)Morimoto
		'   PP_SSSMAIN.Tx = 3
		PP_SSSMAIN.Tx = HD_STTTOKCD.TabIndex
		' === 20110216 === UPDATE E
		PP_SSSMAIN.De2 = -1
		' === 20110216 === UPDATE S TOM)Morimoto
		'   PP_SSSMAIN.Px = 3
		PP_SSSMAIN.Px = HD_STTTOKCD.TabIndex
		' === 20110216 === UPDATE E
		If Not PP_SSSMAIN.Operable Then Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD)
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD)
		' === 20110216 === UPDATE E
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD)
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD)
		' === 20110216 === UPDATE E
		HD_STTTOKCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			' === 20110216 === UPDATE S TOM)Morimoto
			'      wk_Slisted = STTTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal))
			'UPGRADE_WARNING: オブジェクト STTTOKCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = STTTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_STTTOKCD.TabIndex).CuVal))
			' === 20110216 === UPDATE E
		Else
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = PP_SSSMAIN.SlistCom
		End If
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If Not IsDbNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
			PP_SSSMAIN.SlistPx = -1
			PP_SSSMAIN.CursorDirection = Cn_Direction1
			PP_SSSMAIN.CursorDest = Cn_Dest9
			PP_SSSMAIN.JustAfterSList = True
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				' === 20110216 === UPDATE S TOM)Morimoto
				'         CP_SSSMAIN(3).TpStr = wk_Slisted
				'         CP_SSSMAIN(3).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(HD_STTTOKCD.TabIndex).TpStr = wk_Slisted
				CP_SSSMAIN(HD_STTTOKCD.TabIndex).CIn = Cn_ChrInput
				' === 20110216 === UPDATE E
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_STTTOKCD.Text = wk_Slisted
				' === 20110216 === UPDATE S TOM)Morimoto
				'         Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(3), (HD_STTTOKCD)), Cn_Status6, True, True)
				Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD.Text), Cn_Status6, True, True)
				' === 20110216 === UPDATE E
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_STTTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STTTOKCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If AE_KeyDown_SSSMAIN(HD_STTTOKCD, KeyCode, Shift, CP_SSSMAIN(3).TpStr) Then
		'      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(3), (HD_STTTOKCD)), Cn_Status6, True, True)
		'      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (3)
		If AE_KeyDown_SSSMAIN(HD_STTTOKCD, KEYCODE, Shift, CP_SSSMAIN(HD_STTTOKCD.TabIndex).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(HD_STTTOKCD.TabIndex)
			' === 20110216 === UPDATE E
		End If
	End Sub
	
	Private Sub HD_STTTOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STTTOKCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If PP_SSSMAIN.Tx <> 3 Then Beep: KeyAscii = 0: Exit Sub
		'   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD, KeyAscii)
		If PP_SSSMAIN.Tx <> HD_STTTOKCD.TabIndex Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD, KeyAscii)
		' === 20110216 === UPDATE E
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_STTTOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
		'      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(3), (HD_STTTOKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
		If CP_SSSMAIN(HD_STTTOKCD.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_STTTOKCD.Focus()
			End If
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If HD_STTTOKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
		If System.Drawing.ColorTranslator.ToOle(HD_STTTOKCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), CL_SSSMAIN(HD_STTTOKCD.TabIndex), PP_SSSMAIN.Tx)
		' === 20110216 === UPDATE E
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_STTTOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTTOKCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then
			' === 20110216 === DELETE S TOM)Morimoto
			'      If (Button And vbRightButton) = vbRightButton Then
			'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTTOKCD)
			'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
			'         PP_SSSMAIN.NeglectPopupFocus = False
			'         Dim wk_Tx As Integer
			'         wk_Tx = PP_SSSMAIN.Tx
			'         If PP_SSSMAIN.PopupTx = HD_STTTOKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
			'         DoEvents
			'         HD_STTTOKCD.Enabled = True
			'         Call AE_CursorMove_SSSMAIN(wk_Tx)
			'      End If
			' === 20110216 === DELETE E
			' === 20110216 === UPDATE S TOM)Morimoto
			'      PP_SSSMAIN.MouseDownTx = 3
			PP_SSSMAIN.MouseDownTx = HD_STTTOKCD.TabIndex
			' === 20110216 === UPDATE E
		End If
	End Sub
	
	Private Sub HD_STTTOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTTOKCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_STTTOKCD.ReadOnly = False
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD)
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD)
		' === 20110216 === UPDATE E
	End Sub
	
	'UPGRADE_WARNING: イベント HD_STTTOKNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_STTTOKNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			' === 20110216 === UPDATE S TOM)Morimoto
			'      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM) Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM) Then
				' === 20110216 === UPDATE E
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_STTTOKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub HD_STTTOKNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		' === 20110216 === UPDATE S TOM)Morimoto
		'   PP_SSSMAIN.Tx = 4
		PP_SSSMAIN.Tx = HD_STTTOKNM.TabIndex
		' === 20110216 === UPDATE E
		PP_SSSMAIN.De2 = -1
		' === 20110216 === UPDATE S TOM)Morimoto
		'   PP_SSSMAIN.Px = 4
		PP_SSSMAIN.Px = HD_STTTOKNM.TabIndex
		' === 20110216 === UPDATE E
		If Not PP_SSSMAIN.Operable Then Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM)
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM)
		' === 20110216 === UPDATE E
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM)
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM)
		' === 20110216 === UPDATE E
		HD_STTTOKNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_STTTOKNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STTTOKNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If AE_KeyDown_SSSMAIN(HD_STTTOKNM, KeyCode, Shift, CP_SSSMAIN(4).TpStr) Then
		'      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val3(CP_SSSMAIN(4), (HD_STTTOKNM)), Cn_Status6, True, True)
		'      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (4)
		If AE_KeyDown_SSSMAIN(HD_STTTOKNM, KEYCODE, Shift, CP_SSSMAIN(HD_STTTOKNM.TabIndex).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val3(CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(HD_STTTOKNM.TabIndex)
			' === 20110216 === UPDATE E
		End If
	End Sub
	
	Private Sub HD_STTTOKNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STTTOKNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If PP_SSSMAIN.Tx <> 4 Then Beep: KeyAscii = 0: Exit Sub
		'   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM, KeyAscii)
		If PP_SSSMAIN.Tx <> 4 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM, KeyAscii)
		' === 20110216 === UPDATE E
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_STTTOKNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
		'      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val3(CP_SSSMAIN(4), (HD_STTTOKNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
		If CP_SSSMAIN(HD_STTTOKNM.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val3(CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_STTTOKNM.Focus()
			End If
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If HD_STTTOKNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
		If System.Drawing.ColorTranslator.ToOle(HD_STTTOKNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), CL_SSSMAIN(HD_STTTOKNM.TabIndex), PP_SSSMAIN.Tx)
		' === 20110216 === UPDATE E
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_STTTOKNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTTOKNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then
			' === 20110216 === DELETE S TOM)Morimoto
			'      If (Button And vbRightButton) = vbRightButton Then
			'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTTOKNM)
			'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
			'         PP_SSSMAIN.NeglectPopupFocus = False
			'         Dim wk_Tx As Integer
			'         wk_Tx = PP_SSSMAIN.Tx
			'         If PP_SSSMAIN.PopupTx = HD_STTTOKNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
			'         DoEvents
			'         HD_STTTOKNM.Enabled = True
			'         Call AE_CursorMove_SSSMAIN(wk_Tx)
			'      End If
			' === 20110216 === DELETE E
			' === 20110216 === UPDATE S TOM)Morimoto
			'      PP_SSSMAIN.MouseDownTx = 4
			PP_SSSMAIN.MouseDownTx = HD_STTTOKNM.TabIndex
			' === 20110216 === UPDATE E
		End If
	End Sub
	
	Private Sub HD_STTTOKNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTTOKNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_STTTOKNM.ReadOnly = False
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM)
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM)
		' === 20110216 === UPDATE E
	End Sub
	
	'UPGRADE_WARNING: イベント HD_THSCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_THSCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_THSCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD) Then
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_THSCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub HD_THSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_THSCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 2
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 2
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD)
		HD_THSCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_THSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_THSCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_THSCD, KEYCODE, Shift, CP_SSSMAIN(2).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_THSCD(AE_Val3(CP_SSSMAIN(2), HD_THSCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(2)
		End If
	End Sub
	
	Private Sub HD_THSCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_THSCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 2 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_THSCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_THSCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_THSCD(AE_Val3(CP_SSSMAIN(2), HD_THSCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_THSCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_THSCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_THSCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_THSCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then
			' === 20110216 === DELETE S TOM)Morimoto
			'      If (Button And vbRightButton) = vbRightButton Then
			'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_THSCD)
			'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
			'         PP_SSSMAIN.NeglectPopupFocus = False
			'         Dim wk_Tx As Integer
			'         wk_Tx = PP_SSSMAIN.Tx
			'         If PP_SSSMAIN.PopupTx = HD_THSCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
			'         DoEvents
			'         HD_THSCD.Enabled = True
			'         Call AE_CursorMove_SSSMAIN(wk_Tx)
			'      End If
			' === 20110216 === DELETE E
			PP_SSSMAIN.MouseDownTx = 2
		End If
	End Sub
	
	Private Sub HD_THSCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_THSCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_THSCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD)
	End Sub
	
	Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		Call Init_Prompt()
	End Sub
	
	
	
	
	Public Sub MN_AppendC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_AppendC.Click 'Generated.
		Dim wk_Cursor As Short
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
		If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN()
	End Sub
	
	Private Sub MN_ClearItm_Click() 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		Call AE_ClearItm_SSSMAIN(False)
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub MN_Copy_Click() 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			My.Computer.Clipboard.Clear()
			'UPGRADE_ISSUE: Control SelLength は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			If VB6.GetActiveControl().SelLength <= 1 Then
				On Error Resume Next
				'UPGRADE_ISSUE: Control Text は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				My.Computer.Clipboard.SetText(VB6.GetActiveControl().Text)
				On Error GoTo 0
			Else
				On Error Resume Next
				'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
				On Error GoTo 0
			End If
		End If
	End Sub
	
	Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
	End Sub
	
	Private Sub MN_Cut_Click() 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
				On Error Resume Next
				'UPGRADE_ISSUE: Control Text は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				My.Computer.Clipboard.SetText(VB6.GetActiveControl().Text)
				Call AE_ClearItm_SSSMAIN(False)
				On Error GoTo 0
				Call AE_CursorCurrent_SSSMAIN()
			End If
		End If
	End Sub
	
	Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click 'Generated.
		Const CF_TEXT As Short = 1
		If Not PP_SSSMAIN.Operable Then Exit Sub
		MN_APPENDC.Enabled = True
		' === 20110216 === DELETE S TOM)Morimoto
		'   MN_ClearItm = False
		'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
		'      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm = True
		'   End If
		'   MN_Copy = False
		'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
		'      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
		'         If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Copy = True
		'      End If
		'   End If
		'   MN_Cut = False
		'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
		'      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
		'         If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
		'            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
		'               If CP_SSSMAIN(PP_SSSMAIN.Px).FixedFormat <> 1 Then
		'                  If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Cut = True
		'               End If
		'            End If
		'         End If
		'      End If
		'   End If
		'   MN_Paste = False
		'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
		'      If TypeOf Screen.ActiveControl Is TextBox Then
		'         If Clipboard.GetFormat(CF_TEXT) Then
		'            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste = True
		'         End If
		'      End If
		'   End If
		'   MN_UnDoItem = False
		'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
		'      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
		'         If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <= Cn_Status2 Then
		'            MN_UnDoItem = True
		'         ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> Cn_Status0 Then
		'            If IsNull(CP_SSSMAIN(PP_SSSMAIN.Px).CuVal) Xor IsNull(CP_SSSMAIN(PP_SSSMAIN.Px).ExVal) Then
		'               MN_UnDoItem = True
		'            ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> CP_SSSMAIN(PP_SSSMAIN.Px).StatusF Or CP_SSSMAIN(PP_SSSMAIN.Px).CuVal <> CP_SSSMAIN(PP_SSSMAIN.Px).ExVal Then
		'               MN_UnDoItem = True
		'            End If
		'         End If
		'      End If
		'   End If
		' === 20110216 === DELETE E
	End Sub
	
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		PP_SSSMAIN.CloseCode = 1
		Call AE_EndCm_SSSMAIN()
	End Sub
	
	' === 20110216 === INSERT S TOM)Morimoto
	Public Sub MN_EXECUTE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EXECUTE.Click
		'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CuVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_STTTOKCD.TabIndex).CuVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(HD_FRNKB.TabIndex).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_Execute(CP_SSSMAIN(HD_THSCD.TabIndex).CuVal, CP_SSSMAIN(HD_FRNKB.TabIndex).CuVal, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_STTTOKCD.TabIndex).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CuVal))
	End Sub
	' === 20110216 === INSERT E
	
	' === 20110216 === DELETE S TOM)Morimoto
	'Private Sub MN_FSTART_Click() 'Generated.
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   If FSTART_GetEvent() Then
	'   End If
	'End Sub
	'
	'Private Sub MN_LCONFIG_Click() 'Generated.
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   If LCONFIG_GetEvent() Then
	'   End If
	'End Sub
	'
	'Private Sub MN_LSTART_Click() 'Generated.
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   If LSTART_GetEvent() Then
	'   End If
	'End Sub
	'
	Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		MN_Slist.Enabled = False
		If False Then
			' === 20110216 === UPDATE S TOM)Morimoto
			'   ElseIf PP_SSSMAIN.Tx = 3 Then
		ElseIf PP_SSSMAIN.Tx = HD_STTTOKCD.TabIndex Then 
			' === 20110216 === UPDATE E
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
			' === 20110216 === UPDATE S TOM)Morimoto
			'   ElseIf PP_SSSMAIN.Tx = 5 Then
		ElseIf PP_SSSMAIN.Tx = HD_ENDTOKCD.TabIndex Then 
			' === 20110216 === UPDATE E
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		End If
		If PP_SSSMAIN.Mode >= Cn_Mode3 Then
		Else
		End If
	End Sub
	'
	'Private Sub MN_Paste_Click() 'Generated.
	'Dim MaxLB As Integer
	'Dim wk_LnSt As Integer
	'Dim Tx As Integer
	'Dim Px As Integer
	'Dim wk_Txt$
	'Dim st_Work$
	'Dim wk_Moji$
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   If TypeOf Screen.ActiveControl Is TextBox Then
	'      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
	'' === 20110216 === UPDATE S TOM)Morimoto
	''      If Screen.ActiveControl.TabIndex >= 7 Then
	'      If Screen.ActiveControl.TabIndex >= PP_SSSMAIN.HeadN Then
	'' === 20110216 === UPDATE E
	'            Screen.ActiveControl.SelText = Clipboard.GetText()
	'         Else
	'            Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), Screen.ActiveControl)
	'         End If
	'      End If
	'   End If
	'End Sub
	'
	Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		PP_SSSMAIN.SlistSw = True
		PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
		Call AE_Slist_SSSMAIN()
		PP_SSSMAIN.SlistSw = False
	End Sub
	
	'Private Sub MN_UnDoItem_Click() 'Generated.
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   Call AE_UnDoItem_SSSMAIN
	'End Sub
	'
	'Private Sub MN_VSTART_Click() 'Generated.
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   If VSTART_GetEvent() Then
	'   End If
	'End Sub
	'
	'Private Sub SM_AllCopy_Click() 'Generated.
	'   If Not PP_SSSMAIN.Operable Then Exit Sub
	'   If PP_SSSMAIN.ShortCutTx = -2 Then
	'      Clipboard.Clear
	'      On Error Resume Next
	'      Clipboard.SetText TX_Mode.Text
	'      On Error GoTo 0
	'   ElseIf PP_SSSMAIN.ShortCutTx = -3 Then
	'      Clipboard.Clear
	'      On Error Resume Next
	'      Clipboard.SetText TX_Message.Text
	'      On Error GoTo 0
	'   ElseIf TypeOf AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx) Is TextBox Then
	'      Clipboard.Clear
	'      On Error Resume Next
	'      Clipboard.SetText AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx).Text
	'      On Error GoTo 0
	'   End If
	'End Sub
	'
	'Private Sub SM_FullPast_Click() 'Generated.
	'   If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
	'      PP_SSSMAIN.Tx = PP_SSSMAIN.PopupTx
	'      Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx))
	'      PP_SSSMAIN.Tx = -1
	'   End If
	'End Sub
	' === 20110216 === DELETE E
	
	Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick 'Generated.
		Dim wk_ww As Short
		Dim De As Short
		Dim Tx As Short
		Dim wk_Cursor As Short
		TM_StartUp.Enabled = False
		If PP_SSSMAIN.TimerStartUp = True Then
			PP_SSSMAIN.TimerStartUp = False
			PP_SSSMAIN.MaskMode = False
			PP_SSSMAIN.Operable = True
			If AE_AppendC_SSSMAIN(Cn_Mode1) = Cn_CuCurrent Then
				PP_SSSMAIN.CloseCode = 0
				Call AE_EndCm_SSSMAIN()
			Else
				Call AE_CursorInit_SSSMAIN()
			End If
		End If
		If PP_SSSMAIN.TimerWorkId = 1 Then
			PP_SSSMAIN.TimerWorkId = 0
			Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
		ElseIf PP_SSSMAIN.TimerWorkId = 8 Then 
			PP_SSSMAIN.TimerWorkId = 0
			On Error Resume Next
			AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorSave).Focus()
		ElseIf PP_SSSMAIN.TimerWorkId = 9 Then 
			PP_SSSMAIN.TimerWorkId = 0
			Call AE_CursorSub_SSSMAIN(AE_NextCm_SSSMAIN(True))
		End If
	End Sub
	
	Private Sub TX_CursorRest_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_CursorRest.Enter 'Generated.
		CM_SLIST.Enabled = False
		If PP_SSSMAIN.PrpC = 0 Then
			PP_SSSMAIN.De2 = -1
			TX_CursorRest.TabStop = False
		ElseIf PP_SSSMAIN.SSCommand5Ajst Then 
			TX_CursorRest.TabStop = False
			PP_SSSMAIN.BrightOnOff = AE_BackColor(CL_SSSMAIN(PP_SSSMAIN.Px) Mod 10)
			PP_SSSMAIN.SSCommand5Ajst = False
		ElseIf PP_SSSMAIN.NextTx = Cn_NextTxCleared Then 
			PP_SSSMAIN.De2 = -1
			PP_SSSMAIN.Tx = -1
			If PP_SSSMAIN.CursorToWhere >= 0 Then
				If PP_SSSMAIN.CursorToWhere = Cn_CursorToHome Then
					PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
					If AE_CursorNext_SSSMAIN(-1) Then TX_CursorRest.TabStop = False
				Else
					If CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OutputOnly Then
					ElseIf CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OptionButtonC Then 
					Else
						If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Visible And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Enabled And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).TabStop Then
							PP_SSSMAIN.NextTx = PP_SSSMAIN.CursorToWhere
							On Error Resume Next
							AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Focus()
							TX_CursorRest.TabStop = False
						End If
					End If
				End If
				PP_SSSMAIN.CursorToWhere = Cn_CursorToRest
			Else
				PP_SSSMAIN.ExMode = PP_SSSMAIN.Mode
			End If
		Else
			PP_SSSMAIN.De2 = -1
			If PP_SSSMAIN.Tx >= 0 Then
				If CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OutputOnly Then
				ElseIf CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OptionButtonC Then 
				Else
					If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Visible And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Enabled And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).TabStop Then
						On Error Resume Next
						AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Focus()
						TX_CursorRest.TabStop = False
						Exit Sub
					End If
				End If
			End If
			TX_CursorRest.TabStop = True
			PP_SSSMAIN.Tx = -1
			PP_SSSMAIN.CursorToWhere = Cn_CursorToRest
		End If
	End Sub
	
	Private Sub TX_CursorRest_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_CursorRest.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		Dim wk_TopDe As Short
		PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
		If KEYCODE = System.Windows.Forms.Keys.Up And Shift = 0 Then
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
				' === 20110216 === UPDATE S TOM)Morimoto
				'         wk_Bool = AE_CursorUp_SSSMAIN(7)
				wk_Bool = AE_CursorUp_SSSMAIN(PP_SSSMAIN.HeadN)
				' === 20110216 === UPDATE E
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.Down And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
				wk_Bool = AE_CursorDown_SSSMAIN(-1)
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.Right And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
				wk_Bool = AE_CursorNext_SSSMAIN(-1)
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.Left And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				' === 20110216 === UPDATE S TOM)Morimoto
				'         wk_Bool = AE_CursorPrev_SSSMAIN(7)
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.HeadN)
				' === 20110216 === UPDATE E
			End If
		ElseIf (KEYCODE = System.Windows.Forms.Keys.Execute Or KEYCODE = System.Windows.Forms.Keys.Return) And Shift = 0 Then 
		ElseIf KEYCODE = System.Windows.Forms.Keys.End And Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				' === 20110216 === UPDATE S TOM)Morimoto
				'         If AE_CursorPrevDsp_SSSMAIN(7) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				If AE_CursorPrevDsp_SSSMAIN(PP_SSSMAIN.HeadN) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				' === 20110216 === UPDATE E
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.Home And Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				If AE_CursorNextDsp_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.PageDown And Shift = 0 Then 
		ElseIf KEYCODE = System.Windows.Forms.Keys.PageUp And Shift = 0 Then 
		ElseIf KEYCODE = System.Windows.Forms.Keys.ShiftKey Then 
		ElseIf KEYCODE = System.Windows.Forms.Keys.ControlKey Then 
		ElseIf KEYCODE = System.Windows.Forms.Keys.Menu Then 
		ElseIf KEYCODE >= System.Windows.Forms.Keys.F1 And KEYCODE <= System.Windows.Forms.Keys.F12 Then 
			wk_Int = AE_FuncKey_SSSMAIN(KEYCODE, Shift)
			If KEYCODE = System.Windows.Forms.Keys.F10 And Shift = 0 Then Exit Sub
			If KEYCODE = System.Windows.Forms.Keys.F4 And (Shift And 6) = 4 Then Exit Sub
		Else
			If Shift <> 4 Then Beep()
		End If
		KEYCODE = 0
	End Sub
	
	Private Sub TX_CursorRest_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_CursorRest.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Mode = Cn_Mode3 Then
			KeyAscii = 0
		Else
			KeyAscii = 0
			Call AE_CursorInit_SSSMAIN()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TX_Message_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Click 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Message.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		Call AE_CursorInit_SSSMAIN()
		KEYCODE = 0
	End Sub
	
	Private Sub TX_Message_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_Message.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		Call AE_CursorInit_SSSMAIN()
		KeyAscii = 0
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TX_Message_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
			TX_Message.Enabled = False
			PP_SSSMAIN.ShortCutTx = -3
			' === 20110216 === DELETE S TOM)Morimoto
			'      SM_FullPast.Enabled = False
			'      PopupMenu SM_ShortCut, vbPopupMenuRightButton
			' === 20110216 === DELETE E
			TX_Message.Enabled = True
		End If
	End Sub
	
	Private Sub TX_Mode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Mode.Enter 'Generated.
		Beep()
		Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.Tx)
	End Sub
	
	Private Sub TX_Mode_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Mode.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		Call AE_CursorInit_SSSMAIN()
		KEYCODE = 0
	End Sub
	
	Private Sub TX_Mode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_Mode.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		Call AE_CursorInit_SSSMAIN()
		KeyAscii = 0
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TX_Mode_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Mode.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
			TX_Mode.Enabled = False
			PP_SSSMAIN.ShortCutTx = -2
			' === 20110216 === DELETE S TOM)Morimoto
			'      SM_FullPast.Enabled = False
			'      PopupMenu SM_ShortCut, vbPopupMenuRightButton
			' === 20110216 === DELETE E
			TX_Mode.Enabled = True
		End If
	End Sub
	
	' === 20110217 === INSERT S TOM)Morimoto
	Public Function selectFile(ByRef strFile As String) As Boolean
		On Error GoTo err_selectFile
		With CMDialogL
			'UPGRADE_WARNING: オブジェクト CMDialogL.DefaultExt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.DefaultExt = gv_strOUT_TYPE 'ファイル拡張子の既定値
			'UPGRADE_WARNING: オブジェクト CMDialogL.Filter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE & "|*.*|*.*"
			'UPGRADE_WARNING: オブジェクト CMDialogL.CancelError の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CancelError = True
			'UPGRADE_WARNING: オブジェクト CMDialogL.ShowSave の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ShowSave()
			'UPGRADE_WARNING: オブジェクト CMDialogL.fileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strFile = .fileName
			selectFile = True
		End With
		selectFile = True
		Exit Function
err_selectFile: 
		If Err.Number = 32755 Then
			Exit Function
		End If
		On Error GoTo 0
	End Function
	Public Sub show_GAGE(ByVal flg As Boolean)
		'UPGRADE_WARNING: オブジェクト GAUGE.FloodPercent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		GAUGE.FloodPercent = 0
		'UPGRADE_WARNING: オブジェクト GAUGE.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		GAUGE.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
		'UPGRADE_WARNING: オブジェクト GAUGE.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		GAUGE.Visible = flg
		'UPGRADE_WARNING: オブジェクト CM_LCANCEL.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CM_LCANCEL.Visible = flg
	End Sub
	Public Sub count_GAGE(ByVal cnt As Integer, ByVal all_cnt As Integer)
		If all_cnt > 0 Then
			'UPGRADE_WARNING: オブジェクト GAUGE.FloodPercent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			GAUGE.FloodPercent = cnt / all_cnt * 100
			'UPGRADE_WARNING: オブジェクト GAUGE.FloodPercent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If GAUGE.FloodPercent > 50 Then
				'UPGRADE_WARNING: オブジェクト GAUGE.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				GAUGE.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			End If
		End If
	End Sub
	Public Sub formenabled(ByVal flg As Boolean)
		Dim I As Short
		Dim objctrl As System.Windows.Forms.Control
		On Error Resume Next
		For	Each objctrl In Me.Controls
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf objctrl Is System.Windows.Forms.TextBox
					objctrl.Enabled = flg
				Case TypeOf objctrl Is System.Windows.Forms.PictureBox
					objctrl.Enabled = flg
				Case TypeOf objctrl Is System.Windows.Forms.ToolStripMenuItem
					objctrl.Enabled = flg
			End Select
		Next objctrl
		On Error GoTo 0
	End Sub
	' === 20110217 === INSERT E
End Class