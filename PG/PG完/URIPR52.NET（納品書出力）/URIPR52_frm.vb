Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'*** End Of Generated Declaration Section ****

    '2019/03/27 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '2019/03/27 ADD END

    '2019.04.08 del start
    '   Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '       IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '       TX_Message.Text = "メニューに戻ります。"
    '   End Sub

    '   Private Sub CM_LSTART_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '       IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '       TX_Message.Text = "印刷を開始します。"
    '   End Sub

    '   Private Sub CM_VSTART_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '       IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '       TX_Message.Text = "印刷イメージを表示します。"
    '   End Sub

    'Private Sub CM_FSTART_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_FSTART.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '	IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '	TX_Message.Text = "ファイルに出力します。"
    'End Sub

    '   Private Sub CM_LCONFIG_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '       IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '       TX_Message.Text = "プリンターを選択します。"
    '   End Sub

    'Private Sub CM_Slist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Slist.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '	IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '	TX_Message.Text = "ウィンドウを表示します。"
    'End Sub

    '   Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '       PP_SSSMAIN.ButtonClick = True
    '       If Not PP_SSSMAIN.Operable Then Exit Sub
    '       PP_SSSMAIN.NeglectLostFocusCheck = True
    '       PP_SSSMAIN.CloseCode = 1
    '       Call AE_EndCm_SSSMAIN()
    '       PP_SSSMAIN.NeglectLostFocusCheck = False
    '       Call AE_CursorCurrent_SSSMAIN()
    '   End Sub

    'Private Sub CM_ENDCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_ENDCM.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_ENDCM.Image = IM_ENDCM(1).Image
    'End Sub

    'Private Sub CM_ENDCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_ENDCM.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_ENDCM.Image = IM_ENDCM(0).Image
    'End Sub

    'Private Sub CM_FSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_FSTART.Click 'Generated.
    '	PP_SSSMAIN.ButtonClick = True
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	PP_SSSMAIN.NeglectLostFocusCheck = True
    '	If FSTART_GetEvent() Then
    '	End If
    '	PP_SSSMAIN.NeglectLostFocusCheck = False
    '	Call AE_CursorCurrent_SSSMAIN()
    'End Sub

    'Private Sub CM_FSTART_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_FSTART.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_FSTART.Image = IM_FSTART(1).Image
    'End Sub

    'Private Sub CM_FSTART_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_FSTART.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_FSTART.Image = IM_FSTART(0).Image
    'End Sub

    'Private Sub CM_LCANCEL_Click() 'Generated.
    '	PP_SSSMAIN.ButtonClick = True
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	PP_SSSMAIN.NeglectLostFocusCheck = True
    '	'UPGRADE_WARNING: オブジェクト LCANCEL_GetEvent() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If LCANCEL_GetEvent() Then
    '	End If
    '	PP_SSSMAIN.NeglectLostFocusCheck = False
    '	Call AE_CursorCurrent_SSSMAIN()
    'End Sub

    'Private Sub CM_LCANCEL_GotFocus() 'Generated.
    '	PP_SSSMAIN.ButtonClick = False
    'End Sub

    'Private Sub CM_LCANCEL_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short) 'Generated.
    '	If PP_SSSMAIN.ButtonClick = False Then
    '		If KeyCode = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
    '	End If
    'End Sub

    'Private Sub CM_LCANCEL_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
    '	Call AE_CursorCurrent_SSSMAIN()
    'End Sub

    '   Private Sub CM_LCONFIG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '       PP_SSSMAIN.ButtonClick = True
    '       If Not PP_SSSMAIN.Operable Then Exit Sub
    '       PP_SSSMAIN.NeglectLostFocusCheck = True
    '       If LCONFIG_GetEvent() Then
    '       End If
    '       PP_SSSMAIN.NeglectLostFocusCheck = False
    '       Call AE_CursorCurrent_SSSMAIN()
    '   End Sub

    '   Private Sub CM_LCONFIG_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '       If PP_SSSMAIN.Operable Then CM_LCONFIG.Image = IM_LCONFIG(1).Image
    '   End Sub

    '   Private Sub CM_LCONFIG_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '       If PP_SSSMAIN.Operable Then CM_LCONFIG.Image = IM_LCONFIG(0).Image
    '   End Sub

    '   Private Sub CM_LSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '       PP_SSSMAIN.ButtonClick = True
    '       If Not PP_SSSMAIN.Operable Then Exit Sub
    '       PP_SSSMAIN.NeglectLostFocusCheck = True
    '       If LSTART_GetEvent() Then
    '       End If
    '       PP_SSSMAIN.NeglectLostFocusCheck = False
    '       Call AE_CursorCurrent_SSSMAIN()
    '   End Sub

    '   Private Sub CM_LSTART_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '       If PP_SSSMAIN.Operable Then CM_LSTART.Image = IM_LSTART(1).Image
    '   End Sub

    '   Private Sub CM_LSTART_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '       If PP_SSSMAIN.Operable Then CM_LSTART.Image = IM_LSTART(0).Image
    '   End Sub

    'Private Sub CM_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Slist.Click 'Generated.
    '	PP_SSSMAIN.ButtonClick = True
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
    '	Call AE_Slist_SSSMAIN()
    '	PP_SSSMAIN.NeglectLostFocusCheck = False
    '	'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN()
    'End Sub

    '   Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '       If PP_SSSMAIN.Operable Then CM_Slist.Image = IM_SLIST(1).Image
    '   End Sub

    '   Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '       If PP_SSSMAIN.Operable Then CM_Slist.Image = IM_Slist(0).Image
    '   End Sub

    '   Private Sub CM_VSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '       PP_SSSMAIN.ButtonClick = True
    '       If Not PP_SSSMAIN.Operable Then Exit Sub
    '       PP_SSSMAIN.NeglectLostFocusCheck = True
    '       If VSTART_GetEvent() Then
    '       End If
    '       PP_SSSMAIN.NeglectLostFocusCheck = False
    '       Call AE_CursorCurrent_SSSMAIN()
    '   End Sub

    '   Private Sub CM_VSTART_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '       If PP_SSSMAIN.Operable Then CM_VSTART.Image = IM_VSTART(1).Image
    '   End Sub

    '   Private Sub CM_VSTART_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '       If PP_SSSMAIN.Operable Then CM_VSTART.Image = IM_VSTART(0).Image
    '   End Sub
    '2019.04.08 del end
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
        '2019.04.02 ADD START
        Dim Index_Wk As Short = 0
        '2019.04.02 ADD END 

        AE_Title = "納品書                           "
		'初画面表示の性能チューニング用 ----------
		'Dim StartTime
		'   AE_MsgBox "Start Point", vbInformation, AE_Title$
		'   StartTime = Timer
		'-----------------------------------------
		With PP_SSSMAIN
			.FormWidth = 9000
			.FormHeight = 7785
			.MaxDe = -1
			.MaxDsp = -1
			.HeadN = 15
			.BodyN = 0
			.BodyV = 0
			.MaxEDe = -1
			.MaxEDsp = -1
			.EBodyN = 0
			.EBodyV = 0
			.TailN = 0
			.BodyPx = 16
			.EBodyPx = 16
			.TailPx = 16
			.PrpC = 16
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
				AE_CtB = AE_CtB + 15
				ReDim Preserve AE_Controls(.CtB + 14)
				.MainFormFile = "URIPR52.FRM"
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
			HD_HAKKOU.Text = ""
			HD_KINKYU.Text = ""
			HD_TANCD.Text = ""
			HD_TANNM.Text = ""
			HD_BMNCD.Text = ""
			HD_BMNNM.Text = ""
			HD_DENDT.Text = ""
			HD_JDNNO.Text = ""
			HD_TOKCD.Text = ""
			HD_TOKRN.Text = ""
			HD_JDNTRKB.Text = ""
			HD_JDNTRNM.Text = ""
			HD_PRTKB.Text = ""
			HD_OPEID.TabIndex = 0
			AE_Controls(.CtB + 0) = HD_OPEID
			HD_OPENM.TabIndex = 1
			AE_Controls(.CtB + 1) = HD_OPENM
			HD_HAKKOU.TabIndex = 2
			AE_Controls(.CtB + 2) = HD_HAKKOU
			HD_KINKYU.TabIndex = 3
			AE_Controls(.CtB + 3) = HD_KINKYU
			HD_TANCD.TabIndex = 4
			AE_Controls(.CtB + 4) = HD_TANCD
			HD_TANNM.TabIndex = 5
			AE_Controls(.CtB + 5) = HD_TANNM
			HD_BMNCD.TabIndex = 6
			AE_Controls(.CtB + 6) = HD_BMNCD
			HD_BMNNM.TabIndex = 7
			AE_Controls(.CtB + 7) = HD_BMNNM
			HD_DENDT.TabIndex = 8
			AE_Controls(.CtB + 8) = HD_DENDT
			HD_JDNNO.TabIndex = 9
			AE_Controls(.CtB + 9) = HD_JDNNO
			HD_TOKCD.TabIndex = 10
			AE_Controls(.CtB + 10) = HD_TOKCD
			HD_TOKRN.TabIndex = 11
			AE_Controls(.CtB + 11) = HD_TOKRN
			HD_JDNTRKB.TabIndex = 12
			AE_Controls(.CtB + 12) = HD_JDNTRKB
			HD_JDNTRNM.TabIndex = 13
			AE_Controls(.CtB + 13) = HD_JDNTRNM
			HD_PRTKB.TabIndex = 14
			AE_Controls(.CtB + 14) = HD_PRTKB
			TX_CursorRest.TabIndex = 15
			AE_Timer(.ScX) = TM_StartUp
            AE_CursorRest(.ScX) = TX_CursorRest
            '2019.04.08 DEL start
            'AE_ModeBar(.ScX) = TX_Mode
            'AE_StatusBar(.ScX) = TX_Message
            'AE_StatusCodeBar(.ScX) = TX_Message
            '.Mode = Cn_Mode1 : TX_Mode.Text = "追加"
            '2019.04.08 DEL end
			Call AE_ClearInitValStatus_SSSMAIN()
			.PY_BTop = VB6.PixelsToTwipsY(Me.Height)
			.PY_EBTop = VB6.PixelsToTwipsY(Me.Height)
			PY_TTop = VB6.PixelsToTwipsY(Me.Height)
			.MaxDspC = 0
			.NrBodyTx = 15
			.ScrlMaxL = 1
			.MaxEDspC = 0
			.NrEBodyTx = 15
            .EScrlMaxL = 1
            '2019.04.09 add start
            PP_SSSMAIN.Mode = 1
            '2019.04.09 add end
			Call AE_TabStop_SSSMAIN(0, 14, True)
            TX_CursorRest.TabStop = False
            '2019.04.09 del start
            'TX_Mode.TabStop = False
            'TX_Message.TabStop = False
            'TX_Message.Text = ""
            'wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
            '2019.04.09 DEL end
            Call AE_WindowProcSet_SSSMAIN()
            '2019.04.08 DEL start
            'ReleaseTabCapture(0)
            'SetTabCapture(Me.Handle.ToInt32)
            '2019.04.08 DEL end
			'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Var = SSSMAIN_BeginPrg()
			.FormWidth = VB6.PixelsToTwipsX(Me.Width)
			.FormHeight = VB6.PixelsToTwipsY(Me.Height)
            '初画面表示の性能チューニング用 ----------
            '   AE_MsgBox Str$(Timer - StartTime), vbInformation, AE_Title$
            '-----------------------------------------
            .TimerStartUp = True

            '2019.04.02 ADD START
            '使用しないファンクションキーは非活性にする
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = False
            Button8.Enabled = False
            Button10.Enabled = False
            Button11.Enabled = False

            'ファンクションキーのインデックスの設定
            Index_Wk += 1
            Button4.Tag = Index_Wk
            Index_Wk += 1
            Button5.Tag = Index_Wk
            Index_Wk += 1
            Button9.Tag = Index_Wk
            Index_Wk += 1
            Button12.Tag = Index_Wk
            '2019.04.02 ADD END
        End With
        TM_StartUp.Enabled = True
        '2019.04.02 ADD START
        SetBar(Me)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason 'Generated.
		PP_SSSMAIN.UnloadMode = UnloadMode
		Select Case UnloadMode
            Case 0, 3
                'delete start 20190809 kuwahara
                'PP_SSSMAIN.CloseCode = 2
                'delete end 20190809 kuwahara
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
                '2019.04.08 CHG START
                'Cancel = True : Exit Sub
                eventSender.CANCEL = True : Exit Sub
                '2019.04.08 CHG END
			End If
		Else
			If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then
				'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
                '2019.04.08 CHG START
                'Cancel = True : Exit Sub
                eventSender.CANCEL = True : Exit Sub
                '2019.04.08 CHG END
			End If
		End If
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Close() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk_Var = SSSMAIN_Close()
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If wk_Var <> 0 Then
		End If
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If wk_Var = -1 Then
            '2019.04.09 del start
            'wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
            'Call AE_WindowProcReset(PP_SSSMAIN)
            'ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
            '2019.04.09 del end
            If PP_SSSMAIN.hIMC <> 0 Then
				Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
			End If
#If ActiveXcompile = 0 Then
			End
#End If
			'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf wk_Var = 0 Then 
			'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
            '2019.04.08 CHG START
            'Cancel = True
            eventSender.CANCEL = True
            '2019.04.08 CHG END
			'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf wk_Var = 1 Then
            '2019.04.09 del start
            'wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
            'Call AE_WindowProcReset(PP_SSSMAIN)
            'ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
            '2019.04.09 del end
            If PP_SSSMAIN.hIMC <> 0 Then
				Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
			End If
		End If
		PP_SSSMAIN.CloseCode = -1
	End Sub
	
	'UPGRADE_WARNING: イベント HD_BMNCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_BMNCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_BMNCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_BMNCD, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_BMNCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
		End If
	End Sub
	
	Private Sub HD_BMNCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 6
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 6
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_BMNCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_BMNCD)
		HD_BMNCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト BMNCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = BMNCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6).CuVal))
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
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(6).TpStr = wk_Slisted
				CP_SSSMAIN(6).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_BMNCD.Text = wk_Slisted
				Call AE_Check_SSSMAIN_BMNCD(AE_Val3(CP_SSSMAIN(6), HD_BMNCD.Text), Cn_Status6, True, True)
			End If
        End If
        '2019.04.08 DEL start
        'CM_Slist.Enabled = True
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_BMNCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_BMNCD, KeyCode, Shift, CP_SSSMAIN(6).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BMNCD(AE_Val3(CP_SSSMAIN(6), HD_BMNCD.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(6)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_BMNCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BMNCD.KeyPress
        '2019.04.01 ADD START
        HD_BMNCD.Text = Trim(HD_BMNCD.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        'If PP_SSSMAIN.Tx <> 6 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_BMNCD, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_BMNCD.Text = Trim(HD_BMNCD.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_BMNCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BMNCD(AE_Val3(CP_SSSMAIN(6), HD_BMNCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_BMNCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_BMNCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_BMNCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BMNCD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_BMNCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_BMNCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 6
		End If
	End Sub
	
	Private Sub HD_BMNCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_BMNCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(6), HD_BMNCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_BMNNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_BMNNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_BMNNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_BMNNM, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_BMNNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
		End If
	End Sub
	
	Private Sub HD_BMNNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 7
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 7
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(7), HD_BMNNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(7), HD_BMNNM)
		HD_BMNNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_BMNNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNNM.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_BMNNM, KeyCode, Shift, CP_SSSMAIN(7).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BMNNM(AE_Val3(CP_SSSMAIN(7), HD_BMNNM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(7)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_BMNNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BMNNM.KeyPress
        '2019.04.01 ADD START
        HD_BMNNM.Text = Trim(HD_BMNNM.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        'If PP_SSSMAIN.Tx <> 7 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(7), HD_BMNNM, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_BMNNM.Text = Trim(HD_BMNNM.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_BMNNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(7).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BMNNM(AE_Val3(CP_SSSMAIN(7), HD_BMNNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_BMNNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_BMNNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_BMNNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BMNNM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                ''2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_BMNNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_BMNNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 7
		End If
	End Sub
	
	Private Sub HD_BMNNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_BMNNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_DENDT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_DENDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DENDT.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_DENDT) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_DENDT, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_DENDT(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
		End If
	End Sub
	
	Private Sub HD_DENDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DENDT.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 8
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 8
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8), HD_DENDT)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		'UPGRADE_WARNING: オブジェクト DENDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 8)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If DENDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 8)) Then
			PP_SSSMAIN.CursorDest = Cn_DestBySkip
			If AE_CursorSkip_SSSMAIN() Then
				PP_SSSMAIN.SlistCall = False
				Exit Sub
			End If
			wk_Int = AE_ExecuteX_SSSMAIN()
			If wk_Int <> Cn_CuCurrent And wk_Int <> Cn_CuInCompletePx Then
				Call AE_CursorSub_SSSMAIN(wk_Int)
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8), HD_DENDT)
		HD_DENDT.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト DENDT_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = DENDT_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8).CuVal))
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
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(8).TpStr = wk_Slisted
				CP_SSSMAIN(8).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_DENDT.Text = wk_Slisted
				Call AE_Check_SSSMAIN_DENDT(AE_Val3(CP_SSSMAIN(8), HD_DENDT.Text), Cn_Status6, True, True)
			End If
        End If
        '2019.04.08 DEL start
        'CM_Slist.Enabled = True
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_DENDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DENDT.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_DENDT, KeyCode, Shift, CP_SSSMAIN(8).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_DENDT(AE_Val3(CP_SSSMAIN(8), HD_DENDT.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(8)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_DENDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_DENDT.KeyPress
        '2019.04.01 ADD START
        HD_DENDT.Text = Trim(HD_DENDT.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.02 DEL START
        'If PP_SSSMAIN.Tx <> 8 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8), HD_DENDT, KeyAscii)
        '2019.04.02 DEL START
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_DENDT.Text = Trim(HD_DENDT.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_DENDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DENDT.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(8).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_DENDT(AE_Val3(CP_SSSMAIN(8), HD_DENDT.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_DENDT.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_DENDT.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_DENDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DENDT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.08 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_DENDT)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.08 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_DENDT.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_DENDT.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 8
		End If
	End Sub
	
	Private Sub HD_DENDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DENDT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_DENDT.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8), HD_DENDT)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_HAKKOU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_HAKKOU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HAKKOU.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_HAKKOU) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_HAKKOU, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_HAKKOU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_HAKKOU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HAKKOU.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 2
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 2
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_HAKKOU)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_HAKKOU)
        HD_HAKKOU.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_HAKKOU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HAKKOU.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_HAKKOU, KeyCode, Shift, CP_SSSMAIN(2).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HAKKOU(AE_Val3(CP_SSSMAIN(2), HD_HAKKOU.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(2)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_HAKKOU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HAKKOU.KeyPress
        '2019.04.01 ADD START
        HD_HAKKOU.Text = Trim(HD_HAKKOU.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        'If PP_SSSMAIN.Tx <> 2 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_HAKKOU, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_HAKKOU.Text = Trim(HD_HAKKOU.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_HAKKOU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HAKKOU.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HAKKOU(AE_Val3(CP_SSSMAIN(2), HD_HAKKOU.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_HAKKOU.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_HAKKOU.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_HAKKOU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HAKKOU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_HAKKOU)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_HAKKOU.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_HAKKOU.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 2
		End If
	End Sub
	
	Private Sub HD_HAKKOU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HAKKOU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_HAKKOU.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_HAKKOU)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_JDNNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_JDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_JDNNO) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_JDNNO, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_JDNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_JDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 9
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 9
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(9), HD_JDNNO)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(9), HD_JDNNO)
		HD_JDNNO.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト JDNNO_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = JDNNO_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(9).CuVal))
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
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(9).TpStr = wk_Slisted
				CP_SSSMAIN(9).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_JDNNO.Text = wk_Slisted
				Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(9), HD_JDNNO.Text), Cn_Status6, True, True)
			End If
        End If
        '2019.04.08 DEL start
        'CM_Slist.Enabled = True
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_JDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNNO.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_JDNNO, KeyCode, Shift, CP_SSSMAIN(9).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(9), HD_JDNNO.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(9)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_JDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNNO.KeyPress
        '2019.04.01 ADD START
        HD_JDNNO.Text = Trim(HD_JDNNO.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        'If PP_SSSMAIN.Tx <> 9 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(9), HD_JDNNO, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_JDNNO.Text = Trim(HD_JDNNO.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_JDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(9).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(9), HD_JDNNO.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_JDNNO.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_JDNNO.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_JDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_JDNNO)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_JDNNO.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_JDNNO.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 9
		End If
	End Sub
	
	Private Sub HD_JDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_JDNNO.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(9), HD_JDNNO)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_JDNTRKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_JDNTRKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_JDNTRKB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_JDNTRKB, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_JDNTRKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_JDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 12
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 12
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(12), HD_JDNTRKB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(12), HD_JDNTRKB)
		HD_JDNTRKB.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト JDNTRKB_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = JDNTRKB_Slist(PP_SSSMAIN)
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
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(12).TpStr = wk_Slisted
				CP_SSSMAIN(12).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_JDNTRKB.Text = wk_Slisted
				Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(12), HD_JDNTRKB.Text), Cn_Status6, True, True)
			End If
        End If
        '2019.04.08 DEL start
        'CM_Slist.Enabled = True
        '2019.04.08 DEL end
    End Sub
	
	Private Sub HD_JDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRKB.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_JDNTRKB, KeyCode, Shift, CP_SSSMAIN(12).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(12), HD_JDNTRKB.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(12)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_JDNTRKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRKB.KeyPress
        '2019.04.01 ADD START
        HD_JDNTRKB.Text = Trim(HD_JDNTRKB.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        '      If PP_SSSMAIN.Tx <> 12 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(12), HD_JDNTRKB, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_JDNTRKB.Text = Trim(HD_JDNTRKB.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_JDNTRKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(12).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(12), HD_JDNTRKB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_JDNTRKB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_JDNTRKB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(12), CL_SSSMAIN(12), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_JDNTRKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_JDNTRKB)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_JDNTRKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_JDNTRKB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 12
		End If
	End Sub
	
	Private Sub HD_JDNTRKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_JDNTRKB.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(12), HD_JDNTRKB)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_JDNTRNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_JDNTRNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(13), HD_JDNTRNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(13), HD_JDNTRNM, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_JDNTRNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_JDNTRNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 13
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 13
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(13), HD_JDNTRNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(13), HD_JDNTRNM)
        HD_JDNTRNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 del end
	End Sub
	
	Private Sub HD_JDNTRNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRNM.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_JDNTRNM, KeyCode, Shift, CP_SSSMAIN(13).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNTRNM(AE_Val3(CP_SSSMAIN(13), HD_JDNTRNM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(13)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_JDNTRNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRNM.KeyPress
        '2019.04.01 ADD START
        HD_JDNTRNM.Text = Trim(HD_JDNTRNM.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        '      If PP_SSSMAIN.Tx <> 13 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(13), HD_JDNTRNM, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_JDNTRNM.Text = Trim(HD_JDNTRNM.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_JDNTRNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(13).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNTRNM(AE_Val3(CP_SSSMAIN(13), HD_JDNTRNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_JDNTRNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_JDNTRNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(13), CL_SSSMAIN(13), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_JDNTRNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_JDNTRNM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_JDNTRNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_JDNTRNM.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 13
		End If
	End Sub
	
	Private Sub HD_JDNTRNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_JDNTRNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_KINKYU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_KINKYU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KINKYU.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_KINKYU) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_KINKYU, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_KINKYU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_KINKYU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KINKYU.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 3
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 3
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_KINKYU)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_KINKYU)
        HD_KINKYU.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_KINKYU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KINKYU.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_KINKYU, KeyCode, Shift, CP_SSSMAIN(3).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_KINKYU(AE_Val3(CP_SSSMAIN(3), HD_KINKYU.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(3)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_KINKYU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KINKYU.KeyPress
        '2019.04.01 ADD START
        HD_KINKYU.Text = Trim(HD_KINKYU.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        '      If PP_SSSMAIN.Tx <> 3 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_KINKYU, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_KINKYU.Text = Trim(HD_KINKYU.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_KINKYU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KINKYU.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_KINKYU(AE_Val3(CP_SSSMAIN(3), HD_KINKYU.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_KINKYU.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_KINKYU.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_KINKYU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KINKYU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_KINKYU)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_KINKYU.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_KINKYU.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 3
		End If
	End Sub
	
	Private Sub HD_KINKYU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KINKYU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_KINKYU.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(3), HD_KINKYU)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_OPEID.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OPEID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
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
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_OPEID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPEID.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_OPEID, KeyCode, Shift, CP_SSSMAIN(0).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), HD_OPEID.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(0)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_OPEID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPEID.KeyPress
        '2019.04.01 ADD START
        HD_OPEID.Text = Trim(HD_OPEID.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        '      If PP_SSSMAIN.Tx <> 0 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_OPEID.Text = Trim(HD_OPEID.Text)
        '2019.04.01 ADD END
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
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPEID)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_OPEID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_OPEID.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
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
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
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
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_OPENM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPENM.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_OPENM, KeyCode, Shift, CP_SSSMAIN(1).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), HD_OPENM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(1)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_OPENM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPENM.KeyPress
        '2019.04.01 ADD START
        HD_OPENM.Text = Trim(HD_OPENM.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        'If PP_SSSMAIN.Tx <> 1 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_OPENM.Text = Trim(HD_OPENM.Text)
        '2019.04.01 ADD END
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
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPENM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_OPENM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_OPENM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
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
	
	'UPGRADE_WARNING: イベント HD_PRTKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_PRTKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_PRTKB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(14), HD_PRTKB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(14), HD_PRTKB, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_PRTKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_PRTKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_PRTKB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 14
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 14
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(14), HD_PRTKB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(14), HD_PRTKB)
		HD_PRTKB.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_PRTKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_PRTKB.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_PRTKB, KeyCode, Shift, CP_SSSMAIN(14).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_PRTKB(AE_Val3(CP_SSSMAIN(14), HD_PRTKB.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(14)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_PRTKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_PRTKB.KeyPress
        '2019.04.01 ADD START
        HD_PRTKB.Text = Trim(HD_PRTKB.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        'If PP_SSSMAIN.Tx <> 14 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(14), HD_PRTKB, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_PRTKB.Text = Trim(HD_PRTKB.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_PRTKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_PRTKB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(14).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_PRTKB(AE_Val3(CP_SSSMAIN(14), HD_PRTKB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_PRTKB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_PRTKB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(14), CL_SSSMAIN(14), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_PRTKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_PRTKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_PRTKB)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_PRTKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_PRTKB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 14
		End If
	End Sub
	
	Private Sub HD_PRTKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_PRTKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_PRTKB.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(14), HD_PRTKB)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TANCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_TANCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_TANCD, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_TANCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 4
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 4
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_TANCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_TANCD)
		HD_TANCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト TANCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = TANCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal))
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
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(4).TpStr = wk_Slisted
				CP_SSSMAIN(4).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_TANCD.Text = wk_Slisted
				Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(4), HD_TANCD.Text), Cn_Status6, True, True)
			End If
		End If
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
	End Sub

    Private Sub HD_TANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_TANCD, KeyCode, Shift, CP_SSSMAIN(4).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(4), HD_TANCD.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(4)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_TANCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TANCD.KeyPress
        '2019.04.01 ADD START
        HD_TANCD.Text = Trim(HD_TANCD.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        'If PP_SSSMAIN.Tx <> 4 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_TANCD, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_TANCD.Text = Trim(HD_TANCD.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(4), HD_TANCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_TANCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_TANCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_TANCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TANCD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_TANCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_TANCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 4
		End If
	End Sub
	
	Private Sub HD_TANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_TANCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(4), HD_TANCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TANNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_TANNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_TANNM, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_TANNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 5
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_TANNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_TANNM)
		HD_TANNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_TANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANNM.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_TANNM, KeyCode, Shift, CP_SSSMAIN(5).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TANNM(AE_Val3(CP_SSSMAIN(5), HD_TANNM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(5)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_TANNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TANNM.KeyPress
        '2019.04.01 ADD START
        HD_TANNM.Text = Trim(HD_TANNM.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        'If PP_SSSMAIN.Tx <> 5 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_TANNM, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_TANNM.Text = Trim(HD_TANNM.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TANNM(AE_Val3(CP_SSSMAIN(5), HD_TANNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_TANNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_TANNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_TANNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TANNM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_TANNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_TANNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 5
		End If
	End Sub
	
	Private Sub HD_TANNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_TANNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TOKCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_TOKCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_TOKCD, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_TOKCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_TOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 10
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 10
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(10), HD_TOKCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(10), HD_TOKCD)
		HD_TOKCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト TOKCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = TOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(10).CuVal))
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
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(10).TpStr = wk_Slisted
				CP_SSSMAIN(10).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_TOKCD.Text = wk_Slisted
				Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(10), HD_TOKCD.Text), Cn_Status6, True, True)
			End If
		End If
        '2019.04.08 DEL start
        'CM_Slist.Enabled = true
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_TOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_TOKCD, KeyCode, Shift, CP_SSSMAIN(10).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(10), HD_TOKCD.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(10)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_TOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKCD.KeyPress
        '2019.04.01 ADD START
        HD_TOKCD.Text = Trim(HD_TOKCD.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        '      If PP_SSSMAIN.Tx <> 10 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(10), HD_TOKCD, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_TOKCD.Text = Trim(HD_TOKCD.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_TOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(10).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(10), HD_TOKCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_TOKCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_TOKCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(10), CL_SSSMAIN(10), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_TOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TOKCD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_TOKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_TOKCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 10
		End If
	End Sub
	
	Private Sub HD_TOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_TOKCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(10), HD_TOKCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TOKRN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TOKRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_TOKRN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_TOKRN, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_TOKRN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_TOKRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 11
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 11
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(11), HD_TOKRN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(11), HD_TOKRN)
		HD_TOKRN.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
	End Sub
	
	Private Sub HD_TOKRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKRN.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_TOKRN, KeyCode, Shift, CP_SSSMAIN(11).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKRN(AE_Val3(CP_SSSMAIN(11), HD_TOKRN.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(11)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub
	
	Private Sub HD_TOKRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKRN.KeyPress
        '2019.04.01 ADD START
        HD_TOKRN.Text = Trim(HD_TOKRN.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.11 del start
        'If PP_SSSMAIN.Tx <> 11 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(11), HD_TOKRN, KeyAscii)
        '2019.04.11 del end
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_TOKRN.Text = Trim(HD_TOKRN.Text)
        '2019.04.01 ADD END
    End Sub
	
	Private Sub HD_TOKRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(11).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKRN(AE_Val3(CP_SSSMAIN(11), HD_TOKRN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_TOKRN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_TOKRN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(11), CL_SSSMAIN(11), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_TOKRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKRN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.04.11 del start
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TOKRN)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.04.11 del end
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_TOKRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_TOKRN.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 11
		End If
	End Sub
	
	Private Sub HD_TOKRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKRN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_TOKRN.ReadOnly = False
	End Sub
	
    Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
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
	
	Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearItm.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		Call AE_ClearItm_SSSMAIN(False)
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			My.Computer.Clipboard.Clear()
			'UPGRADE_ISSUE: Control SelLength は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            '2019.04.08 CHG start
            'If VB6.GetActiveControl().SelLength <= 1 Then
            '    On Error Resume Next
            '    'UPGRADE_ISSUE: Control Text は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            '    My.Computer.Clipboard.SetText(VB6.GetActiveControl().Text)
            '    On Error GoTo 0
            'Else
            '    On Error Resume Next
            '    'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            '    My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
            '    On Error GoTo 0
            'End If
            If DirectCast(VB6.GetActiveControl(), TextBox).SelectionLength <= 1 Then
                On Error Resume Next
                My.Computer.Clipboard.SetText(VB6.GetActiveControl().Text)
                On Error GoTo 0
            Else
                On Error Resume Next
                My.Computer.Clipboard.SetText(DirectCast(VB6.GetActiveControl(), TextBox).SelectedText)
                On Error GoTo 0
            End If
            '2019.04.08 CHG end
		End If
	End Sub
	
	Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
	End Sub
	
	Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Cut.Click 'Generated.
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
		MN_AppendC.Enabled = True
		MN_ClearItm.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 15 Then
			If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm.Enabled = True
		End If
		MN_Copy.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 15 Then
			If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If Not IsDbNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Copy.Enabled = True
			End If
		End If
		MN_Cut.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 15 Then
			If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
				'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019.04.08 CHG start
                'If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
                If DirectCast(AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx), TextBox).SelectionLength > 0 Then
                    '2019.04.08 CHG end
                    If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
                        If CP_SSSMAIN(PP_SSSMAIN.Px).FixedFormat <> 1 Then
                            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                            If Not IsDBNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Cut.Enabled = True
                        End If
                    End If
                End If
            End If
        End If
        MN_Paste.Enabled = False
        If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 15 Then
            If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
                'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetFormat はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                '2019.04.08 CHG START
                'If My.Computer.Clipboard.GetFormat(CF_TEXT) Then
                If My.Computer.Clipboard.ContainsText(CF_TEXT) Then
                    '2019.04.08 CHG END
                    If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste.Enabled = True
                End If
            End If
        End If
        MN_UnDoItem.Enabled = False
        If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 15 Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
                If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <= Cn_Status2 Then
                    MN_UnDoItem.Enabled = True
                ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> Cn_Status0 Then
                    'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                    If IsDBNull(CP_SSSMAIN(PP_SSSMAIN.Px).CuVal) Xor IsDBNull(CP_SSSMAIN(PP_SSSMAIN.Px).ExVal) Then
                        MN_UnDoItem.Enabled = True
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(PP_SSSMAIN.Px).ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(PP_SSSMAIN.Px).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> CP_SSSMAIN(PP_SSSMAIN.Px).StatusF Or CP_SSSMAIN(PP_SSSMAIN.Px).CuVal <> CP_SSSMAIN(PP_SSSMAIN.Px).ExVal Then
                        MN_UnDoItem.Enabled = True
                    End If
                End If
            End If
        End If
	End Sub
	
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		PP_SSSMAIN.CloseCode = 1
		Call AE_EndCm_SSSMAIN()
	End Sub
	
	Public Sub MN_LCONFIG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_LCONFIG.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If LCONFIG_GetEvent() Then
		End If
	End Sub
	
	Public Sub MN_LSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_LSTART.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If LSTART_GetEvent() Then
		End If
	End Sub
	
	Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		MN_Slist.Enabled = False
		If False Then
		ElseIf PP_SSSMAIN.Tx = 4 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 6 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 8 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 9 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 10 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 12 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		End If
		If PP_SSSMAIN.Mode >= Cn_Mode3 Then
		Else
		End If
	End Sub
	
	Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click 'Generated.
		Dim MaxLB As Short
		Dim wk_LnSt As Short
		Dim Tx As Short
		Dim Px As Short
		Dim wk_Txt As String
		Dim st_Work As String
		Dim wk_Moji As String
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
			If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
				'UPGRADE_ISSUE: Control TabIndex は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				If VB6.GetActiveControl().TabIndex >= 15 Then
					'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
					'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                    '2019.04.08 chg start
                    'VB6.GetActiveControl().SelText = My.Computer.Clipboard.GetText()
                    DirectCast(VB6.GetActiveControl(), TextBox).SelectedText = My.Computer.Clipboard.GetText()
                    '2019.04.08 chg end
				Else
					Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), VB6.GetActiveControl())
				End If
			End If
		End If
	End Sub
	
	Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		PP_SSSMAIN.SlistSw = True
		PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
		Call AE_Slist_SSSMAIN()
		PP_SSSMAIN.SlistSw = False
	End Sub
	
	Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		Call AE_UnDoItem_SSSMAIN()
	End Sub
	
	Public Sub MN_VSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_VSTART.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If VSTART_GetEvent() Then
		End If
	End Sub
	
	Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.ShortCutTx = -2 Then
			My.Computer.Clipboard.Clear()
            On Error Resume Next
            '2019.04.09 del start
            'My.Computer.Clipboard.SetText(TX_Mode.Text)
            '2019.04.09 del end
            On Error GoTo 0
		ElseIf PP_SSSMAIN.ShortCutTx = -3 Then 
			My.Computer.Clipboard.Clear()
            On Error Resume Next
            '2019.04.08 del start
            'My.Computer.Clipboard.SetText(TX_Message.Text)
            '2019.04.08 del end
			On Error GoTo 0
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		ElseIf TypeOf AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx) Is System.Windows.Forms.TextBox Then 
			My.Computer.Clipboard.Clear()
			On Error Resume Next
			My.Computer.Clipboard.SetText(AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx).Text)
			On Error GoTo 0
		End If
	End Sub
	
	Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_FullPast.Click 'Generated.
		If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
			PP_SSSMAIN.Tx = PP_SSSMAIN.PopupTx
			Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx))
			PP_SSSMAIN.Tx = -1
		End If
	End Sub
	
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
        '2019.04.08 DEL start
        'CM_Slist.Enabled = False
        '2019.04.08 DEL end
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
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		Dim wk_TopDe As Short
		PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
		If KeyCode = System.Windows.Forms.Keys.Up And Shift = 0 Then
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
				wk_Bool = AE_CursorUp_SSSMAIN(15)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.Down And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
				wk_Bool = AE_CursorDown_SSSMAIN(-1)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.Right And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
				wk_Bool = AE_CursorNext_SSSMAIN(-1)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.Left And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(15)
			End If
		ElseIf (KeyCode = System.Windows.Forms.Keys.Execute Or KeyCode = System.Windows.Forms.Keys.Return) And Shift = 0 Then 
		ElseIf KeyCode = System.Windows.Forms.Keys.End And Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				If AE_CursorPrevDsp_SSSMAIN(15) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.Home And Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				If AE_CursorNextDsp_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.PageDown And Shift = 0 Then 
		ElseIf KeyCode = System.Windows.Forms.Keys.PageUp And Shift = 0 Then 
		ElseIf KeyCode = System.Windows.Forms.Keys.ShiftKey Then 
		ElseIf KeyCode = System.Windows.Forms.Keys.ControlKey Then 
		ElseIf KeyCode = System.Windows.Forms.Keys.Menu Then 
		ElseIf KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then 
			wk_Int = AE_FuncKey_SSSMAIN(KeyCode, Shift)
			If KeyCode = System.Windows.Forms.Keys.F10 And Shift = 0 Then Exit Sub
			If KeyCode = System.Windows.Forms.Keys.F4 And (Shift And 6) = 4 Then Exit Sub
		Else
			If Shift <> 4 Then Beep()
		End If
		KeyCode = 0
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
	
    Private Sub TX_Message_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        Call AE_CursorCurrent_SSSMAIN()
    End Sub
	
    Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        Call AE_CursorInit_SSSMAIN()
        KeyCode = 0
    End Sub
	
    Private Sub TX_Message_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        Call AE_CursorInit_SSSMAIN()
        KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub TX_Message_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
            '2019.04.08 del start
            'TX_Message.Enabled = False
            '2019.04.08 del end
            PP_SSSMAIN.ShortCutTx = -3
            SM_FullPast.Enabled = False
            'UPGRADE_ISSUE: 定数 vbPopupMenuRightButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '2019.04.08 del START
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            '2019.04.08 del END
            '2019.04.08 del start
            'TX_Message.Enabled = True
            '2019.04.08 del end
        End If
    End Sub
	
    Private Sub TX_Mode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        Beep()
        Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.Tx)
    End Sub
	
    Private Sub TX_Mode_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        Call AE_CursorInit_SSSMAIN()
        KeyCode = 0
    End Sub
	
    Private Sub TX_Mode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        Call AE_CursorInit_SSSMAIN()
        KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub TX_Mode_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
            '2019.04.09 del start
            'TX_Mode.Enabled = False
            '2019.04.09 del end
            PP_SSSMAIN.ShortCutTx = -2
            SM_FullPast.Enabled = False
            'UPGRADE_ISSUE: 定数 vbPopupMenuRightButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '2019.04.08 del START
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            '2019.04.08 del END
            '2019.04.09 del start
            'TX_Mode.Enabled = True
            '2019.04.09 del end
        End If
    End Sub

    '2019.04.09 add start
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call Ctl_Item_Click(Button4)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Call Ctl_Item_Click(Button5)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Call Ctl_Item_Click(Button9)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Call Ctl_Item_Click(Button12)
    End Sub

    Private Function Ctl_Item_Click(ByRef pm_Ctl As System.Windows.Forms.Control) As Short

        Dim Act_Index As Short

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
        Act_Index = CShort(pm_Ctl.Tag)

        Select Case Act_Index

            Case CShort(Button4.Tag)
                '印刷
                If Not PP_SSSMAIN.Operable Then Exit Function
                CP_SSSMAIN(14).CuVal = HD_PRTKB.Text
                CP_SSSMAIN(14).TpStr = HD_PRTKB.Text
                INQ_LIST()
            Case CShort(Button5.Tag)
                'add start 20190808 kuwahara
                'ヘルプ
                PP_SSSMAIN.ButtonClick = True
                If Not PP_SSSMAIN.Operable Then Exit Function
                PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
                Call AE_Slist_SSSMAIN()
                PP_SSSMAIN.NeglectLostFocusCheck = False
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN()
                'add end 20190808 kuwahara

            Case CShort(Button9.Tag)
                'クリア
                Call MN_APPENDC.PerformClick()

            Case CShort(Button12.Tag)
                '終了
                Me.Close()

        End Select

    End Function

    Public Function SetBar(ByRef po_Form As Form) As Boolean

        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBoxの戻り値

        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '---戻り値設定---'
            SetBar = False

            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = SSS_PrgId

            '---戻り値設定---'
            SetBar = True

            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("ﾀｲﾄﾙﾊﾞｰ,ｽﾃｰﾀｽﾊﾞｰ設定関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    Private Sub FKeyDown(sender As Object, e As KeyEventArgs)

        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F4
                    Me.Button4.PerformClick()

                Case Keys.F5
                    Me.Button5.PerformClick()

                Case Keys.F9
                    Me.Button9.PerformClick()

                Case Keys.F12
                    Me.Button12.PerformClick()

                Case Keys.Enter

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub

    Private Sub FR_SSSMAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub Button4_KeyDown(sender As Object, e As KeyEventArgs) Handles Button4.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub Button5_KeyDown(sender As Object, e As KeyEventArgs) Handles Button5.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub Button9_KeyDown(sender As Object, e As KeyEventArgs) Handles Button9.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub Button12_KeyDown(sender As Object, e As KeyEventArgs) Handles Button12.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub CM_LCANCEL_Click(sender As Object, e As EventArgs) Handles CM_LCANCEL.Click
        SSS_LSTOP = True
    End Sub
    '2019.04.09 add end
End Class