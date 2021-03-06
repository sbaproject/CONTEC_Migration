Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'*** End Of Generated Declaration Section ****
	
	Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "メニューに戻ります。"
	End Sub
	
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "登録します。"
	End Sub
	
	Private Sub CM_Hardcopy_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Hardcopy.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "画面を印刷します。"
	End Sub
	
	Private Sub CM_InsertDe_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_InsertDe.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "行を挿入します。"
	End Sub
	
	Private Sub CM_DeleteDe_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_DeleteDe.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "行を削除します。"
	End Sub
	
	Private Sub CM_Slist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Slist.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "ウィンドウを表示します。"
	End Sub
	
	Private Sub CM_Prev_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Prev.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "前のページを表示します。"
	End Sub
	
	Private Sub CM_NextCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "次のページを表示します。"
	End Sub
	
	Private Sub CM_SelectCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SelectCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "一覧表示します。"
	End Sub
	
	'UPGRADE_WARNING: イベント BD_CTLCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_CTLCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_CTLCD.TextChanged
		Dim Index As Short = BD_CTLCD.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_CTLCD(Index)) Then
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_CTLCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub BD_CTLCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_CTLCD.Enter
		Dim Index As Short = BD_CTLCD.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_CTLCD(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 3 + 5 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3 + 5 * PP_SSSMAIN.De), BD_CTLCD(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 2 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_CTLCD(Index))
		BD_CTLCD(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト CTLCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = CTLCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3 + 5 * PP_SSSMAIN.De).CuVal))
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
				CP_SSSMAIN(PP_SSSMAIN.Px).TpStr = wk_Slisted
				CP_SSSMAIN(PP_SSSMAIN.Px).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				BD_CTLCD(Index).Text = wk_Slisted
				Call AE_Check_SSSMAIN_CTLCD(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True, True)
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub BD_CTLCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_CTLCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_CTLCD.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_CTLCD(Index), KeyCode, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_CTLCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
				If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_CTLCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_CTLCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_CTLCD.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 3 + 5 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_CTLCD(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_CTLCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_CTLCD.Leave
		Dim Index As Short = BD_CTLCD.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
				If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_CTLCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_CTLCD(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_CTLCD(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_CTLCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_CTLCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_CTLCD.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_CTLCD(Index))
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
				PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = BD_CTLCD(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				BD_CTLCD(Index).Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = BD_CTLCD(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_CTLCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_CTLCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_CTLCD.GetIndex(eventSender) 'Generated.
		BD_CTLCD(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_CTLCD(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_CTLNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_CTLNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_CTLNM.TextChanged
		Dim Index As Short = BD_CTLNM.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_CTLNM(Index)) Then
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_CTLNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub BD_CTLNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_CTLNM.Enter
		Dim Index As Short = BD_CTLNM.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_CTLNM(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 4 + 5 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4 + 5 * PP_SSSMAIN.De), BD_CTLNM(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 2 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_CTLNM(Index))
		BD_CTLNM(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub BD_CTLNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_CTLNM.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_CTLNM.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_CTLNM(Index), KeyCode, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_CTLNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
				If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_CTLNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_CTLNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_CTLNM.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 4 + 5 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_CTLNM(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_CTLNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_CTLNM.Leave
		Dim Index As Short = BD_CTLNM.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
				If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_CTLNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_CTLNM(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_CTLNM(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_CTLNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_CTLNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_CTLNM.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_CTLNM(Index))
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
				PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = BD_CTLNM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				BD_CTLNM(Index).Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = BD_CTLNM(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_CTLNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_CTLNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_CTLNM.GetIndex(eventSender) 'Generated.
		BD_CTLNM(Index).ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント BD_FIXVAL.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_FIXVAL_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_FIXVAL.TextChanged
		Dim Index As Short = BD_FIXVAL.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FIXVAL(Index)) Then
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_FIXVAL(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub BD_FIXVAL_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_FIXVAL.Enter
		Dim Index As Short = BD_FIXVAL.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_FIXVAL(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 5 + 5 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5 + 5 * PP_SSSMAIN.De), BD_FIXVAL(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 2 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FIXVAL(Index))
		BD_FIXVAL(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub BD_FIXVAL_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_FIXVAL.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_FIXVAL.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_FIXVAL(Index), KeyCode, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_FIXVAL(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
				If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_FIXVAL_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_FIXVAL.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_FIXVAL.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 5 + 5 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FIXVAL(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_FIXVAL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_FIXVAL.Leave
		Dim Index As Short = BD_FIXVAL.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
				If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_FIXVAL(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_FIXVAL(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_FIXVAL(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_FIXVAL_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_FIXVAL.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_FIXVAL.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FIXVAL(Index))
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
				PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = BD_FIXVAL(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				BD_FIXVAL(Index).Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = BD_FIXVAL(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_FIXVAL_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_FIXVAL.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_FIXVAL.GetIndex(eventSender) 'Generated.
		BD_FIXVAL(Index).ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント BD_REMARK.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_REMARK_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_REMARK.TextChanged
		Dim Index As Short = BD_REMARK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_REMARK(Index)) Then
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_REMARK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub BD_REMARK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_REMARK.Enter
		Dim Index As Short = BD_REMARK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_REMARK(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 6 + 5 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6 + 5 * PP_SSSMAIN.De), BD_REMARK(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 2 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_REMARK(Index))
		BD_REMARK(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub BD_REMARK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_REMARK.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_REMARK.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_REMARK(Index), KeyCode, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_REMARK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
				If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_REMARK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_REMARK.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_REMARK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 6 + 5 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_REMARK(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_REMARK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_REMARK.Leave
		Dim Index As Short = BD_REMARK.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
				If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_REMARK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_REMARK(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_REMARK(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_REMARK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_REMARK.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_REMARK.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_REMARK(Index))
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
				PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = BD_REMARK(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				BD_REMARK(Index).Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = BD_REMARK(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_REMARK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_REMARK.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_REMARK.GetIndex(eventSender) 'Generated.
		BD_REMARK(Index).ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント BD_UPDKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_UPDKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UPDKB.TextChanged
		Dim Index As Short = BD_UPDKB.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
			If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UPDKB(Index)) Then
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				PP_SSSMAIN.CursorDest = Cn_Dest9
				Call AE_Check_SSSMAIN_UPDKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
			End If
		End If
	End Sub
	
	Private Sub BD_UPDKB_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UPDKB.DoubleClick
		Dim Index As Short = BD_UPDKB.GetIndex(eventSender) 'Generated.
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		'UPGRADE_WARNING: オブジェクト UPDKB_GetEvent() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk_Var = UPDKB_GetEvent()
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
	End Sub
	
	Private Sub BD_UPDKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UPDKB.Enter
		Dim Index As Short = BD_UPDKB.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_UPDKB(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 2 + 5 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2 + 5 * PP_SSSMAIN.De), BD_UPDKB(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 2 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UPDKB(Index))
		BD_UPDKB(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub BD_UPDKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UPDKB.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_UPDKB.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_UPDKB(Index), KeyCode, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_UPDKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
				If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_UPDKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UPDKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_UPDKB.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 2 + 5 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UPDKB(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_UPDKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UPDKB.Leave
		Dim Index As Short = BD_UPDKB.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
				If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_UPDKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_UPDKB(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_UPDKB(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_UPDKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UPDKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_UPDKB.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UPDKB(Index))
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
				PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = BD_UPDKB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				BD_UPDKB(Index).Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = BD_UPDKB(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_UPDKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UPDKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_UPDKB.GetIndex(eventSender) 'Generated.
		BD_UPDKB(Index).ReadOnly = False
	End Sub
	
	Private Sub CM_DeleteDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_DeleteDe.Click 'Generated.
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 77 Then
			If (PP_SSSMAIN.Tx - 2) \ 5 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
				Call AE_DeleteDe_SSSMAIN()
			End If
		Else
			Beep()
		End If
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub CM_DELETEDE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_DELETEDE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_DELETEDE.Image = IM_DELETEDE(1).Image
	End Sub
	
	Private Sub CM_DELETEDE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_DELETEDE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_DELETEDE.Image = IM_DELETEDE(0).Image
	End Sub
	
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
	
	Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click 'Generated.
		Dim wk_Cursor As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Executing Then Exit Sub
		PP_SSSMAIN.Executing = True
		PP_SSSMAIN.ExplicitExec = True
		wk_Cursor = AE_Execute_SSSMAIN()
		PP_SSSMAIN.ExplicitExec = False
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorSub_SSSMAIN(wk_Cursor)
		PP_SSSMAIN.Executing = False
	End Sub
	
	Private Sub CM_EXECUTE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EXECUTE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_Execute.Image = IM_Execute(1).Image
	End Sub
	
	Private Sub CM_EXECUTE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EXECUTE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_Execute.Image = IM_Execute(0).Image
	End Sub
	
	Private Sub CM_Hardcopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Hardcopy.Click 'Generated.
		Dim wk_Cursor As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If SSSMAIN_Hardcopy_Getevent() Then
			wk_Cursor = AE_Hardcopy_SSSMAIN()
		End If
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorSub_SSSMAIN(wk_Cursor)
	End Sub
	
	Private Sub CM_HARDCOPY_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_HARDCOPY.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_Hardcopy.Image = IM_Hardcopy(1).Image
	End Sub
	
	Private Sub CM_HARDCOPY_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_HARDCOPY.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_Hardcopy.Image = IM_Hardcopy(0).Image
	End Sub
	
	Private Sub CM_InsertDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_InsertDe.Click 'Generated.
		Dim wk_Cursor As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If INSERTDE_GETEVENT() Then
			If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 77 Then
				If (PP_SSSMAIN.Tx - 2) \ 5 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
					wk_Cursor = AE_InsertDe_SSSMAIN()
				End If
			Else
				Beep()
			End If
		End If
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorSub_SSSMAIN(wk_Cursor)
	End Sub
	
	Private Sub CM_INSERTDE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_INSERTDE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_INSERTDE.Image = IM_INSERTDE(1).Image
	End Sub
	
	Private Sub CM_INSERTDE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_INSERTDE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_INSERTDE.Image = IM_INSERTDE(0).Image
	End Sub
	
	Private Sub CM_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_NextCm.Click 'Generated.
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
		Else
			If NEXTCm_GETEVENT() Then
				If PP_SSSMAIN.Mode >= Cn_Mode3 Then
					wk_Int = AE_NextCm_SSSMAIN(True)
				Else
					Beep()
				End If
			End If
		End If
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorInit_SSSMAIN()
	End Sub
	
	Private Sub CM_NEXTCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NEXTCM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_NEXTCm.Image = IM_NEXTCM(1).Image
	End Sub
	
	Private Sub CM_NEXTCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NEXTCM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_NEXTCm.Image = IM_NEXTCM(0).Image
	End Sub
	
	Private Sub CM_Prev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Prev.Click 'Generated.
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
		Else
			If PREV_GETEVENT() Then
				If PP_SSSMAIN.Mode >= Cn_Mode3 Then
					wk_Int = AE_Prev_SSSMAIN(True)
				Else
					Beep()
				End If
			End If
		End If
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorInit_SSSMAIN()
	End Sub
	
	Private Sub CM_PREV_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PREV.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_PREV.Image = IM_PREV(1).Image
	End Sub
	
	Private Sub CM_PREV_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PREV.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_PREV.Image = IM_PREV(0).Image
	End Sub
	
	Private Sub CM_SelectCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SelectCm.Click 'Generated.
		Dim wk_Cursor As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Mode = Cn_Mode2 Then
			Beep()
			wk_Cursor = Cn_CuCurrent
		Else
			wk_Cursor = AE_SelectCm_SSSMAIN(PP_SSSMAIN.Mode, False)
		End If
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorSub_SSSMAIN(wk_Cursor)
	End Sub
	
	Private Sub CM_SELECTCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_SelectCm.Image = IM_SelectCm(1).Image
	End Sub
	
	Private Sub CM_SELECTCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		If PP_SSSMAIN.Operable Then CM_SelectCm.Image = IM_SelectCm(0).Image
	End Sub
	
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
	
	Private Sub CM_UPDKB_Click() 'Generated.
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		PP_SSSMAIN.NeglectLostFocusCheck = True
		'UPGRADE_WARNING: オブジェクト UPDKB_GetEvent() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UPDKB_GetEvent() Then
		End If
		PP_SSSMAIN.NeglectLostFocusCheck = False
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub CM_UPDKB_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CM_UPDKB_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KeyCode = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CM_UPDKB_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub CS_CTLCD_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		Dim wk_TxBase As Short
		Dim wk_PxBase As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.De2 >= 0 And PP_SSSMAIN.Tx < 77 Then
			wk_PxBase = 5 * PP_SSSMAIN.De
			wk_TxBase = 5 * (PP_SSSMAIN.De - PP_SSSMAIN.TopDe)
		Else
			wk_PxBase = 5 * PP_SSSMAIN.TopDe
			wk_TxBase = 0
		End If
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(3 + wk_PxBase).TypeA, 3 + wk_TxBase) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(3 + wk_TxBase)
			If PP_SSSMAIN.Tx <> 3 + wk_TxBase Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_CTLCD_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_CTLCD_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KeyCode = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_CTLCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub FM_CTLNM_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_FIXVAL_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
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
	
	Private Sub FM_PANEL3D3_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_PANEL3D4_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_REMARK_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	'UPGRADE_WARNING: Form イベント FR_SSSMAIN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub FR_SSSMAIN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated 'Generated.
		Dim wk_ww As Short
		Dim Wk_De As Short
		Dim wk_xx As Short
		If PP_SSSMAIN.Activated = 0 Then
			PP_SSSMAIN.Activated = 1
			Wk_De = 1
			Do While Wk_De <= PP_SSSMAIN.MaxDspC
				wk_ww = 0
				Do While wk_ww < 5
					wk_xx = 2 + 5 * Wk_De + wk_ww
					AE_Controls(PP_SSSMAIN.CtB + wk_xx).Visible = AE_Controls(PP_SSSMAIN.CtB + 2 + wk_ww).Visible
					wk_ww = wk_ww + 1
				Loop 
				Wk_De = Wk_De + 1
			Loop 
		End If
	End Sub
	
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim NewLargeChange As Short 'Generated.
		Dim Wk_De As Short
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
		Dim PY_BBtm As Single
		Dim PY_BTSpace As Single
		Dim PY_TTop As Single
		AE_Title = "固定値登録                         "
		'初画面表示の性能チューニング用 ----------
		'Dim StartTime
		'   AE_MsgBox "Start Point", vbInformation, AE_Title$
		'   StartTime = Timer
		'-----------------------------------------
		With PP_SSSMAIN
			.FormWidth = 12855
			.FormHeight = 7875
			.MaxDe = 14
			.MaxDsp = 14
			.HeadN = 2
			.BodyN = 5
			.BodyV = 5
			.MaxEDe = -1
			.MaxEDsp = -1
			.EBodyN = 0
			.EBodyV = 0
			.TailN = 0
			.BodyPx = 2
			.EBodyPx = 77
			.TailPx = 77
			.PrpC = 77
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
				ReDim Preserve AE_ScrlBar(.ScX)
				.CtB = AE_CtB
				AE_CtB = AE_CtB + 77
				ReDim Preserve AE_Controls(.CtB + 76)
				.MainFormFile = "FIXMT51.FRM"
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
				Wk_De = 1
				wk_HeadN = 0 : wk_BodyN = 0 : wk_EBodyN = 0 : wk_TailN = 0
				Do While wk_ww < AE_PSIC
					wk_SmrBuf = Trim(AE_PSI(wk_ww)) & Space(1)
					wk_ww = wk_ww + 1
					Select Case UCase(VB.Left(wk_SmrBuf, Cn_PrfxLen))
						Case "HD_", "HV_"
							Call AE_SetCp(CP_SSSMAIN(wk_HeadN), wk_HeadN, wk_SmrBuf, CQ_SSSMAIN(wk_HeadN))
							wk_HeadN = wk_HeadN + 1
						Case "BD_", "BV_"
							Call AE_SetCp(CP_SSSMAIN(wk_BodyN + 2), wk_BodyN + 2, wk_SmrBuf, CQ_SSSMAIN(wk_BodyN + 2))
							wk_BodyN = wk_BodyN + 1
					End Select
				Loop 
				Do While Wk_De <= 14
					wk_PxBase = 2
					Do While wk_PxBase < 7
						wk_Px = wk_PxBase + 5 * Wk_De
						Call AE_CopyCp_SSSMAIN(wk_Px, wk_PxBase)
						wk_PxBase = wk_PxBase + 1
					Loop 
					Wk_De = Wk_De + 1
				Loop 
			End If
			HD_OPEID.Text = ""
			HD_OPENM.Text = ""
			BD_UPDKB(0).Text = ""
			BD_CTLCD(0).Text = ""
			BD_CTLNM(0).Text = ""
			BD_FIXVAL(0).Text = ""
			BD_REMARK(0).Text = ""
			For Wk_De = 1 To 14
				BD_REMARK.Load(Wk_De)
				BD_FIXVAL.Load(Wk_De)
				BD_CTLNM.Load(Wk_De)
				BD_CTLCD.Load(Wk_De)
				BD_UPDKB.Load(Wk_De)
			Next Wk_De
			HD_OPEID.TabIndex = 0
			AE_Controls(.CtB + 0) = HD_OPEID
			HD_OPENM.TabIndex = 1
			AE_Controls(.CtB + 1) = HD_OPENM
			For Wk_De = 0 To 14
				wk_TxBase = 5 * Wk_De
				BD_UPDKB(Wk_De).TabIndex = 2 + wk_TxBase
				AE_Controls(.CtB + 2 + wk_TxBase) = BD_UPDKB(Wk_De)
				BD_CTLCD(Wk_De).TabIndex = 3 + wk_TxBase
				AE_Controls(.CtB + 3 + wk_TxBase) = BD_CTLCD(Wk_De)
				BD_CTLNM(Wk_De).TabIndex = 4 + wk_TxBase
				AE_Controls(.CtB + 4 + wk_TxBase) = BD_CTLNM(Wk_De)
				BD_FIXVAL(Wk_De).TabIndex = 5 + wk_TxBase
				AE_Controls(.CtB + 5 + wk_TxBase) = BD_FIXVAL(Wk_De)
				BD_REMARK(Wk_De).TabIndex = 6 + wk_TxBase
				AE_Controls(.CtB + 6 + wk_TxBase) = BD_REMARK(Wk_De)
			Next Wk_De
			TX_CursorRest.TabIndex = 77
			AE_Timer(.ScX) = TM_StartUp
			AE_CursorRest(.ScX) = TX_CursorRest
			AE_ModeBar(.ScX) = TX_Mode
			AE_StatusBar(.ScX) = TX_Message
			AE_StatusCodeBar(.ScX) = TX_Message
			.Mode = Cn_Mode1 : TX_Mode.Text = "追加"
			Call AE_ClearInitValStatus_SSSMAIN()
			.PY_BTop = VB6.PixelsToTwipsY(Me.Height)
			ReDim AE_BodyTop(5)
			wk_Tx = 2
			Do While wk_Tx < 7
				wk_Top = VB6.PixelsToTwipsY(AE_Controls(.CtB + wk_Tx).Top)
				If wk_Top < .PY_BTop Then .PY_BTop = wk_Top
				AE_BodyTop(wk_Tx - 2) = wk_Top
				wk_Tx = wk_Tx + 1
			Loop 
			.PY_EBTop = VB6.PixelsToTwipsY(Me.Height)
			PY_TTop = VB6.PixelsToTwipsY(Me.Height)
			AE_ScrlBar(.ScX) = VS_Scrl
			PY_BBtm = 0
			wk_Tx = 2 : wk_ww = 0
			Do While wk_Tx < 7
				wk_Height = VB6.PixelsToTwipsY(AE_Controls(.CtB + wk_Tx).Height)
				wk_Top = AE_BodyTop(wk_ww)
				If wk_Top + wk_Height > PY_BBtm Then PY_BBtm = wk_Top + wk_Height
				wk_Tx = wk_Tx + 1 : wk_ww = wk_ww + 1
			Loop 
			.PY_BHgt = PY_BBtm - .PY_BTop - 15
			If .PY_BHgt = 0 Then .PY_BHgt = 15
			PY_BTSpace = 120
			.MaxDspC = (PY_TTop - PY_BTSpace - .PY_BTop) \ .PY_BHgt - 1
			If .MaxDspC < 0 Then .MaxDspC = 0
			If .MaxDspC > 14 Then .MaxDspC = 14
			.NrBodyTx = 2 + 5 * (.MaxDspC + 1)
			.ScrlMaxL = .MaxDspC : If .ScrlMaxL = 0 Then .ScrlMaxL = 1
			wk_Top = .PY_BTop
			VS_Scrl.Top = VB6.TwipsToPixelsY(wk_Top)
			wk_Height = .PY_BHgt * (.MaxDspC + 1)
			VS_Scrl.Height = VB6.TwipsToPixelsY(wk_Height + 15)
			VS_Scrl.TabStop = False
			VS_Scrl.Minimum = 0
			VS_Scrl.Maximum = (0 + VS_Scrl.LargeChange - 1)
			NewLargeChange = .ScrlMaxL
			VS_Scrl.Maximum = VS_Scrl.Maximum + NewLargeChange - VS_Scrl.LargeChange
			VS_Scrl.LargeChange = NewLargeChange
			If .MaxDspC = 14 Then VS_Scrl.Visible = False
			.MaxEDspC = 0
			.NrEBodyTx = 77
			.EScrlMaxL = 1
			Call AE_TabStop_SSSMAIN(0, 76, True)
			TX_CursorRest.TabStop = False
			TX_Mode.TabStop = False
			TX_Message.TabStop = False
			TX_Message.Text = ""
			Wk_De = 1
			Do While Wk_De <= .MaxDspC
				wk_ww = 0
				Do While wk_ww < 5
					wk_Tx = 2 + 5 * Wk_De + wk_ww
					AE_Controls(.CtB + wk_Tx).Top = VB6.TwipsToPixelsY(AE_BodyTop(wk_ww) + .PY_BHgt * Wk_De)
					wk_ww = wk_ww + 1
				Loop 
				Wk_De = Wk_De + 1
			Loop 
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
		
		' === 20081002 === UPDATE S - RISE)Izumi チェック項目追加
		''2007/12/18 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'    ReDim M_MOTO_A_inf(14)
		''2007/12/18 add-end T.KAWAMUKAI
		ReDim M_FIXMT_A_inf(14)
		' === 20081002 === UPDATE E - RISE)Izumi
		
		
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
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Close() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk_Var = SSSMAIN_Close()
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
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OPEID, KeyCode, Shift, CP_SSSMAIN(0).TpStr) Then
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
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPEID)
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
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
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OPENM, KeyCode, Shift, CP_SSSMAIN(1).TpStr) Then
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
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPENM)
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
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
	
	Public Sub MN_ClearDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearDe.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 77 Then
			If (PP_SSSMAIN.Tx - 2) \ 5 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
				If Not AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
					Call AE_ClearDe2_SSSMAIN()
				End If
			End If
		Else
			Beep()
		End If
		Call AE_CursorCurrent_SSSMAIN()
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
	
	Public Sub MN_DeleteDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_DeleteDe.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 77 Then
			If (PP_SSSMAIN.Tx - 2) \ 5 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
				Call AE_DeleteDe_SSSMAIN()
			End If
		Else
			Beep()
		End If
	End Sub
	
	Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click 'Generated.
		Const CF_TEXT As Short = 1
		If Not PP_SSSMAIN.Operable Then Exit Sub
		MN_APPENDC.Enabled = True
		If PP_SSSMAIN.Mode <> Cn_Mode2 Then
			MN_SelectCm.Enabled = True
		Else
			MN_SelectCm.Enabled = False
		End If
		MN_ClearItm.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 77 Then
			If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm.Enabled = True
		End If
		MN_UnDoDe.Enabled = False
		If PP_SSSMAIN.Mode = Cn_Mode3 Then
		ElseIf PP_SSSMAIN.UnDoDeOp = 1 Then 
			If AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.UnDoDeNo) And PP_SSSMAIN.UnDoDeNo <= PP_SSSMAIN.LastDe Then MN_UnDoDe.Enabled = True
		ElseIf PP_SSSMAIN.UnDoDeOp = 2 Then 
			If PP_SSSMAIN.ActiveDe >= 0 Then
				If PP_SSSMAIN.UnDoDeNo < PP_SSSMAIN.LastDe Then MN_UnDoDe.Enabled = True
			Else
				If PP_SSSMAIN.UnDoDeNo <= PP_SSSMAIN.LastDe Then MN_UnDoDe.Enabled = True
			End If
		End If
		MN_ClearDE.Enabled = False
		MN_DeleteDE.Enabled = False
		MN_InsertDE.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 77 And PP_SSSMAIN.Mode <> Cn_Mode3 Then
			If (PP_SSSMAIN.Tx - 2) \ 5 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
				If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 77 Then
					If Not AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then MN_ClearDE.Enabled = True
				End If
				MN_DeleteDE.Enabled = True
				MN_InsertDE.Enabled = True
			End If
		End If
		MN_Copy.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 77 Then
			If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If Not IsDbNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Copy.Enabled = True
			End If
		End If
		MN_Cut.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 77 Then
			If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
				'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
					If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
						If CP_SSSMAIN(PP_SSSMAIN.Px).FixedFormat <> 1 Then
							'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
							If Not IsDbNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Cut.Enabled = True
						End If
					End If
				End If
			End If
		End If
		MN_Paste.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 77 Then
			If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
				'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetFormat はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
				If My.Computer.Clipboard.GetFormat(CF_TEXT) Then
					If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste.Enabled = True
				End If
			End If
		End If
		MN_UnDoItem.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 77 Then
			If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
				If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <= Cn_Status2 Then
					MN_UnDoItem.Enabled = True
				ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> Cn_Status0 Then 
					'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
					If IsDbNull(CP_SSSMAIN(PP_SSSMAIN.Px).CuVal) Xor IsDbNull(CP_SSSMAIN(PP_SSSMAIN.Px).ExVal) Then
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
	
	Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click 'Generated.
		Dim wk_Cursor As Short
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Executing Then Exit Sub
		PP_SSSMAIN.Executing = True
		PP_SSSMAIN.ExplicitExec = True
		wk_Cursor = AE_Execute_SSSMAIN()
		PP_SSSMAIN.ExplicitExec = False
		If wk_Cursor = Cn_CuInit Then PP_SSSMAIN.SuppressGotLostFocus = 1
		Call AE_CursorSub_SSSMAIN(wk_Cursor)
		PP_SSSMAIN.Executing = False
	End Sub
	
	Public Sub MN_InsertDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_InsertDe.Click 'Generated.
		Dim wk_Cursor As Short
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If INSERTDE_GETEVENT() Then
			If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 77 Then
				If (PP_SSSMAIN.Tx - 2) \ 5 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
					wk_Cursor = AE_InsertDe_SSSMAIN()
				End If
			Else
				Beep()
			End If
		End If
		Call AE_CursorSub_SSSMAIN(wk_Cursor)
	End Sub
	
	Public Sub MN_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_NextCm.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
		Else
			If NEXTCm_GETEVENT() Then
				If PP_SSSMAIN.Mode >= Cn_Mode3 Then
					wk_Int = AE_NextCm_SSSMAIN(True)
				Else
					Beep()
				End If
			End If
		End If
		Call AE_CursorInit_SSSMAIN()
	End Sub
	
	Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		MN_Slist.Enabled = False
		If False Then
		ElseIf (PP_SSSMAIN.Tx - 2) Mod 5 = 1 And PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 77 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		End If
		If PP_SSSMAIN.Mode >= Cn_Mode3 Then
			MN_NextCm.Enabled = True
			MN_Prev.Enabled = True
		Else
			MN_NextCm.Enabled = False
			MN_Prev.Enabled = False
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
				If VB6.GetActiveControl().TabIndex >= 77 Then
					'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
					'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
					VB6.GetActiveControl().SelText = My.Computer.Clipboard.GetText()
				Else
					Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), VB6.GetActiveControl())
				End If
			End If
		End If
	End Sub
	
	Public Sub MN_Prev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Prev.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
		Else
			If PREV_GETEVENT() Then
				If PP_SSSMAIN.Mode >= Cn_Mode3 Then
					wk_Int = AE_Prev_SSSMAIN(True)
				Else
					Beep()
				End If
			End If
		End If
		Call AE_CursorInit_SSSMAIN()
	End Sub
	
	Public Sub MN_SelectCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_SelectCm.Click 'Generated.
		Dim wk_Cursor As Short
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Mode = Cn_Mode2 Then
			Beep()
			wk_Cursor = Cn_CuCurrent
		Else
			wk_Cursor = AE_SelectCm_SSSMAIN(PP_SSSMAIN.Mode, False)
		End If
		If wk_Cursor >= Cn_CuInit Then Call AE_CursorInit_SSSMAIN()
	End Sub
	
	Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		PP_SSSMAIN.SlistSw = True
		PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
		Call AE_Slist_SSSMAIN()
		PP_SSSMAIN.SlistSw = False
	End Sub
	
	Public Sub MN_UnDoDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoDe.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		Call AE_UnDoDe_SSSMAIN()
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		Call AE_UnDoItem_SSSMAIN()
	End Sub
	
	Public Sub MN_UPDKB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UPDKB.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		'UPGRADE_WARNING: オブジェクト UPDKB_GetEvent() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UPDKB_GetEvent() Then
		End If
	End Sub
	
	Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.ShortCutTx = -2 Then
			My.Computer.Clipboard.Clear()
			On Error Resume Next
			My.Computer.Clipboard.SetText(TX_Mode.Text)
			On Error GoTo 0
		ElseIf PP_SSSMAIN.ShortCutTx = -3 Then 
			My.Computer.Clipboard.Clear()
			On Error Resume Next
			My.Computer.Clipboard.SetText(TX_Message.Text)
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
			De = 1
			Do While De <= PP_SSSMAIN.MaxDspC
				wk_ww = 0
				Do While wk_ww < 5
					Tx = 2 + 5 * De + wk_ww
					AE_Controls(PP_SSSMAIN.CtB + Tx).Visible = AE_Controls(PP_SSSMAIN.CtB + 2 + wk_ww).Visible
					wk_ww = wk_ww + 1
				Loop 
				De = De + 1
				System.Windows.Forms.Application.DoEvents()
			Loop 
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
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		Dim wk_TopDe As Short
		PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
		If KeyCode = System.Windows.Forms.Keys.Up And Shift = 0 Then
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
				wk_Bool = AE_CursorUp_SSSMAIN(77)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.Down And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
				wk_Bool = AE_CursorDown_SSSMAIN(-1)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.Right And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
				wk_Bool = AE_CursorNext_SSSMAIN(-1)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.Left And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(77)
			End If
		ElseIf (KeyCode = System.Windows.Forms.Keys.Execute Or KeyCode = System.Windows.Forms.Keys.Return) And Shift = 0 Then 
		ElseIf KeyCode = System.Windows.Forms.Keys.End And Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			If PP_SSSMAIN.Mode = Cn_Mode3 Then Call AE_Scrl_SSSMAIN(14, False)
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				If AE_CursorPrevDsp_SSSMAIN(77) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.Home And Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			If PP_SSSMAIN.Mode = Cn_Mode3 Then Call AE_Scrl_SSSMAIN(0, False)
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				If AE_CursorNextDsp_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.PageDown And Shift = 0 Then 
			If (PP_SSSMAIN.ScrollObject And 1) > 0 Then Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + PP_SSSMAIN.ScrlMaxL, PP_SSSMAIN.Mode <> Cn_Mode3)
		ElseIf KeyCode = System.Windows.Forms.Keys.PageUp And Shift = 0 Then 
			If (PP_SSSMAIN.ScrollObject And 1) > 0 Then Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - PP_SSSMAIN.ScrlMaxL, PP_SSSMAIN.Mode <> Cn_Mode3)
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
	
	Private Sub TX_Message_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Click 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Message.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		Call AE_CursorInit_SSSMAIN()
		KeyCode = 0
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
			SM_FullPast.Enabled = False
			'UPGRADE_ISSUE: 定数 vbPopupMenuRightButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
			TX_Message.Enabled = True
		End If
	End Sub
	
	Private Sub TX_Mode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Mode.Enter 'Generated.
		Beep()
		Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.Tx)
	End Sub
	
	Private Sub TX_Mode_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Mode.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		Call AE_CursorInit_SSSMAIN()
		KeyCode = 0
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
			SM_FullPast.Enabled = False
			'UPGRADE_ISSUE: 定数 vbPopupMenuRightButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
			PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
			TX_Mode.Enabled = True
		End If
	End Sub
	
	'UPGRADE_NOTE: VS_Scrl.Change はイベントからプロシージャに変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' をクリックしてください。
	'UPGRADE_WARNING: VScrollBar イベント VS_Scrl.Change には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub VS_Scrl_Change(ByVal newScrollValue As Integer) 'Generated.
		If PP_SSSMAIN.Tx >= 0 Then
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
				Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
			End If
		End If
		Call AE_Scrl_SSSMAIN((newScrollValue), (PP_SSSMAIN.SuppressVSScroll And 2) = 0)
		PP_SSSMAIN.SuppressVSScroll = PP_SSSMAIN.SuppressVSScroll And 5
	End Sub
	Private Sub VS_Scrl_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VS_Scrl.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				VS_Scrl_Change(eventArgs.newValue)
		End Select
	End Sub
End Class