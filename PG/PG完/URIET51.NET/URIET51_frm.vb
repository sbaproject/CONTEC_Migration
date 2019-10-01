Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'*** End Of Generated Declaration Section ****
	 
    '2019/03/26 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '2019/03/26 ADD E N D
	  
	'UPGRADE_WARNING: イベント BD_HINCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_HINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINCD.TextChanged
		Dim Index As Short = BD_HINCD.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_HINCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_HINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINCD.Enter
		Dim Index As Short = BD_HINCD.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_HINCD(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 54 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(54 + 56 * PP_SSSMAIN.De), BD_HINCD(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index))
        BD_HINCD(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_HINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HINCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_HINCD.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_HINCD(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_HINCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_HINCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_HINCD.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 21 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_HINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINCD.Leave
		Dim Index As Short = BD_HINCD.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_HINCD(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_HINCD(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_HINCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_HINCD.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_HINCD(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_HINCD(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_HINCD(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_HINCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_HINCD.GetIndex(eventSender) 'Generated.
		BD_HINCD(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_HINNMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_HINNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMA.TextChanged
		Dim Index As Short = BD_HINNMA.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMA(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMA(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_HINNMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_HINNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMA.Enter
		Dim Index As Short = BD_HINNMA.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_HINNMA(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 56 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(56 + 56 * PP_SSSMAIN.De), BD_HINNMA(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMA(Index))
        BD_HINNMA(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_HINNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HINNMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_HINNMA.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_HINNMA(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINNMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINNMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_HINNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_HINNMA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_HINNMA.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 23 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMA(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_HINNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMA.Leave
		Dim Index As Short = BD_HINNMA.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINNMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINNMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_HINNMA(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_HINNMA(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_HINNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINNMA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_HINNMA.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMA(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_HINNMA(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_HINNMA(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_HINNMA(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_HINNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINNMA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_HINNMA.GetIndex(eventSender) 'Generated.
		BD_HINNMA(Index).ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント BD_HINNMB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_HINNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMB.TextChanged
		Dim Index As Short = BD_HINNMB.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMB(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMB(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_HINNMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_HINNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMB.Enter
		Dim Index As Short = BD_HINNMB.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_HINNMB(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 57 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(57 + 56 * PP_SSSMAIN.De), BD_HINNMB(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMB(Index))
        BD_HINNMB(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_HINNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HINNMB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_HINNMB.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_HINNMB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINNMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINNMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_HINNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_HINNMB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_HINNMB.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 24 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMB(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_HINNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMB.Leave
		Dim Index As Short = BD_HINNMB.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINNMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINNMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_HINNMB(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_HINNMB(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_HINNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINNMB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_HINNMB.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMB(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_HINNMB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_HINNMB(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_HINNMB(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_HINNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINNMB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_HINNMB.GetIndex(eventSender) 'Generated.
		BD_HINNMB(Index).ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント BD_LINCMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_LINCMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMA.TextChanged
		Dim Index As Short = BD_LINCMA.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMA(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMA(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_LINCMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_LINCMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMA.Enter
		Dim Index As Short = BD_LINCMA.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_LINCMA(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 65 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(65 + 56 * PP_SSSMAIN.De), BD_LINCMA(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMA(Index))
        BD_LINCMA(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_LINCMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_LINCMA.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_LINCMA(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_LINCMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_LINCMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_LINCMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_LINCMA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_LINCMA.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 32 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMA(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_LINCMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMA.Leave
		Dim Index As Short = BD_LINCMA.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_LINCMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_LINCMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_LINCMA(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_LINCMA(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_LINCMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_LINCMA.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMA(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_LINCMA(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_LINCMA(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_LINCMA(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_LINCMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_LINCMA.GetIndex(eventSender) 'Generated.
		BD_LINCMA(Index).ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント BD_LINCMB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_LINCMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMB.TextChanged
		Dim Index As Short = BD_LINCMB.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMB(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMB(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_LINCMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_LINCMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMB.Enter
		Dim Index As Short = BD_LINCMB.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_LINCMB(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 66 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(66 + 56 * PP_SSSMAIN.De), BD_LINCMB(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMB(Index))
        BD_LINCMB(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_LINCMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_LINCMB.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_LINCMB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_LINCMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_LINCMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_LINCMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_LINCMB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_LINCMB.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 33 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMB(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_LINCMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMB.Leave
		Dim Index As Short = BD_LINCMB.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_LINCMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_LINCMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_LINCMB(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_LINCMB(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_LINCMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_LINCMB.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMB(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_LINCMB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_LINCMB(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_LINCMB(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_LINCMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_LINCMB.GetIndex(eventSender) 'Generated.
		BD_LINCMB(Index).ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント BD_LINNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_LINNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINNO.TextChanged
		Dim Index As Short = BD_LINNO.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_LINNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_LINNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINNO.Enter
		Dim Index As Short = BD_LINNO.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_LINNO(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 52 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(52 + 56 * PP_SSSMAIN.De), BD_LINNO(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index))
        BD_LINNO(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_LINNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_LINNO.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_LINNO(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_LINNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_LINNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_LINNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_LINNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_LINNO.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 19 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_LINNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINNO.Leave
		Dim Index As Short = BD_LINNO.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_LINNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_LINNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_LINNO(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_LINNO(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_LINNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_LINNO.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_LINNO(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_LINNO(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_LINNO(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_LINNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_LINNO.GetIndex(eventSender) 'Generated.
		BD_LINNO(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_SBNNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_SBNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SBNNO.TextChanged
		Dim Index As Short = BD_SBNNO.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SBNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_SBNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SBNNO.Enter
		Dim Index As Short = BD_SBNNO.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_SBNNO(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 53 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(53 + 56 * PP_SSSMAIN.De), BD_SBNNO(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index))
        BD_SBNNO(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_SBNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SBNNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SBNNO.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_SBNNO(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SBNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SBNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_SBNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SBNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_SBNNO.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 20 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_SBNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SBNNO.Leave
		Dim Index As Short = BD_SBNNO.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SBNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SBNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_SBNNO(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_SBNNO(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_SBNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SBNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SBNNO.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_SBNNO(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_SBNNO(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_SBNNO(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_SBNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SBNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SBNNO.GetIndex(eventSender) 'Generated.
		BD_SBNNO(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_SIKTK.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_SIKTK_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKTK.TextChanged
		Dim Index As Short = BD_SIKTK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SIKTK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_SIKTK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKTK.Enter
		Dim Index As Short = BD_SIKTK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_SIKTK(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 61 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(61 + 56 * PP_SSSMAIN.De), BD_SIKTK(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index))
        BD_SIKTK(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_SIKTK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIKTK.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SIKTK.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_SIKTK(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SIKTK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SIKTK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_SIKTK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SIKTK.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_SIKTK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 28 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_SIKTK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKTK.Leave
		Dim Index As Short = BD_SIKTK.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SIKTK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_SIKTK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_SIKTK(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_SIKTK(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_SIKTK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKTK.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SIKTK.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_SIKTK(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_SIKTK(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_SIKTK(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_SIKTK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKTK.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SIKTK.GetIndex(eventSender) 'Generated.
		BD_SIKTK(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_TEIKATK.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_TEIKATK_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEIKATK.TextChanged
		Dim Index As Short = BD_TEIKATK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_TEIKATK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_TEIKATK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEIKATK.Enter
		Dim Index As Short = BD_TEIKATK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_TEIKATK(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 64 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(64 + 56 * PP_SSSMAIN.De), BD_TEIKATK(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index))
        BD_TEIKATK(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_TEIKATK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TEIKATK.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TEIKATK.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_TEIKATK(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TEIKATK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TEIKATK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_TEIKATK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TEIKATK.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_TEIKATK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 31 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_TEIKATK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEIKATK.Leave
		Dim Index As Short = BD_TEIKATK.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TEIKATK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_TEIKATK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_TEIKATK(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_TEIKATK(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_TEIKATK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TEIKATK.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TEIKATK.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_TEIKATK(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_TEIKATK(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_TEIKATK(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_TEIKATK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TEIKATK.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TEIKATK.GetIndex(eventSender) 'Generated.
		BD_TEIKATK(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_TNKNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_TNKNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TNKNM.TextChanged
		Dim Index As Short = BD_TNKNM.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKNM(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKNM(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_TNKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_TNKNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TNKNM.Enter
		Dim Index As Short = BD_TNKNM.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_TNKNM(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 62 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(62 + 56 * PP_SSSMAIN.De), BD_TNKNM(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKNM(Index))
        BD_TNKNM(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_TNKNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TNKNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TNKNM.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_TNKNM(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TNKNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TNKNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_TNKNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TNKNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_TNKNM.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 29 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKNM(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_TNKNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TNKNM.Leave
		Dim Index As Short = BD_TNKNM.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TNKNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_TNKNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_TNKNM(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_TNKNM(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_TNKNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TNKNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TNKNM.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKNM(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_TNKNM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_TNKNM(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_TNKNM(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_TNKNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TNKNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TNKNM.GetIndex(eventSender) 'Generated.
		BD_TNKNM(Index).ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント BD_TOKJDNNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_TOKJDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKJDNNO.TextChanged
		Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_TOKJDNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_TOKJDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKJDNNO.Enter
		Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_TOKJDNNO(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 55 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(55 + 56 * PP_SSSMAIN.De), BD_TOKJDNNO(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index))
        BD_TOKJDNNO(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_TOKJDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TOKJDNNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_TOKJDNNO(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKJDNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKJDNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_TOKJDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TOKJDNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 22 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_TOKJDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKJDNNO.Leave
		Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKJDNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_TOKJDNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_TOKJDNNO(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_TOKJDNNO(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_TOKJDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TOKJDNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_TOKJDNNO(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_TOKJDNNO(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_TOKJDNNO(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_TOKJDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TOKJDNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender) 'Generated.
		BD_TOKJDNNO(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_UNTNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_UNTNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UNTNM.TextChanged
		Dim Index As Short = BD_UNTNM.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UNTNM(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UNTNM(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_UNTNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_UNTNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UNTNM.Enter
		Dim Index As Short = BD_UNTNM.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_UNTNM(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 59 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(59 + 56 * PP_SSSMAIN.De), BD_UNTNM(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UNTNM(Index))
        BD_UNTNM(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_UNTNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UNTNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_UNTNM.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_UNTNM(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_UNTNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_UNTNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_UNTNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UNTNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_UNTNM.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 26 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UNTNM(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_UNTNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UNTNM.Leave
		Dim Index As Short = BD_UNTNM.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_UNTNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_UNTNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_UNTNM(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_UNTNM(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_UNTNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UNTNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_UNTNM.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UNTNM(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_UNTNM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_UNTNM(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_UNTNM(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_UNTNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UNTNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_UNTNM.GetIndex(eventSender) 'Generated.
		BD_UNTNM(Index).ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント BD_URIKN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_URIKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_URIKN.TextChanged
		Dim Index As Short = BD_URIKN.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_URIKN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_URIKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_URIKN.Enter
		Dim Index As Short = BD_URIKN.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_URIKN(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 63 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(63 + 56 * PP_SSSMAIN.De), BD_URIKN(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		'UPGRADE_WARNING: オブジェクト URIKN_Skip(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(54 + 56 * PP_SSSMAIN.De).CuVal), AE_NullCnv1_SSSMAIN(CP_SSSMAIN(60 + 56 * PP_SSSMAIN.De).CuVal), AE_NullCnv1_SSSMAIN(CP_SSSMAIN(58 + 56 * PP_SSSMAIN.De).CuVal)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If URIKN_Skip(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(54 + 56 * PP_SSSMAIN.De).CuVal), AE_NullCnv1_SSSMAIN(CP_SSSMAIN(60 + 56 * PP_SSSMAIN.De).CuVal), AE_NullCnv1_SSSMAIN(CP_SSSMAIN(58 + 56 * PP_SSSMAIN.De).CuVal)) Then
			PP_SSSMAIN.CursorDest = Cn_DestBySkip
			If AE_CursorSkip_SSSMAIN() Then
				PP_SSSMAIN.CursorDirection = AE_ChangeDirection(PP_SSSMAIN.CursorDirection)
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
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index))
        BD_URIKN(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_URIKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_URIKN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_URIKN.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_URIKN(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URIKN(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URIKN(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_URIKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_URIKN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_URIKN.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 30 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_URIKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_URIKN.Leave
		Dim Index As Short = BD_URIKN.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URIKN(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_URIKN(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_URIKN(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_URIKN(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_URIKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_URIKN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_URIKN.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_URIKN(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_URIKN(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_URIKN(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_URIKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_URIKN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_URIKN.GetIndex(eventSender) 'Generated.
		BD_URIKN(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_URISU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_URISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_URISU.TextChanged
		Dim Index As Short = BD_URISU.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_URISU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_URISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_URISU.Enter
		Dim Index As Short = BD_URISU.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_URISU(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 58 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(58 + 56 * PP_SSSMAIN.De), BD_URISU(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index))
		BD_URISU(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト URISU_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = URISU_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(54 + 56 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(53 + 56 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(11).CuVal), PP_SSSMAIN.De2)
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
				BD_URISU(Index).Text = wk_Slisted
				Call AE_Check_SSSMAIN_URISU(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True, True)
			End If
        End If
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = True
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_URISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_URISU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_URISU.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_URISU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_URISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_URISU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_URISU.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 25 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_URISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_URISU.Leave
		Dim Index As Short = BD_URISU.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_URISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_URISU(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_URISU(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_URISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_URISU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_URISU.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_URISU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_URISU(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_URISU(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_URISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_URISU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_URISU.GetIndex(eventSender) 'Generated.
		BD_URISU(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_URITK.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_URITK_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_URITK.TextChanged
		Dim Index As Short = BD_URITK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index), FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_URITK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub BD_URITK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_URITK.Enter
		Dim Index As Short = BD_URITK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = BD_URITK(Index).TabIndex
		PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
		PP_SSSMAIN.Px = 60 + 56 * PP_SSSMAIN.De
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(60 + 56 * PP_SSSMAIN.De), BD_URITK(Index))
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index))
        BD_URITK(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub BD_URITK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_URITK.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_URITK.GetIndex(eventSender) 'Generated.
		If AE_KeyDown_SSSMAIN(BD_URITK(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
			If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				Call AE_ClearItm_SSSMAIN(True)
				wk_Bool = AE_CursorSkip_SSSMAIN()
			Else
                '2019/04/03 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URITK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URITK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '2019/04/03 CHG E N D
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
			End If
		End If
	End Sub
	
	Private Sub BD_URITK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_URITK.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_URITK.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.Tx <> 27 + 15 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index), KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_URITK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_URITK.Leave
		Dim Index As Short = BD_URITK.GetIndex(eventSender) 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If PP_SSSMAIN.ScrlFlag Then
			PP_SSSMAIN.ScrlFlag = False
		Else
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '2019/04/03 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URITK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then
                    Call AE_Check_SSSMAIN_URITK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                End If
                '2019/04/03 CHG E N D
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
					On Error Resume Next
					BD_URITK(Index).Focus()
				End If
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(BD_URITK(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub BD_URITK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_URITK.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_URITK.GetIndex(eventSender) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index))
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_URITK(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_URITK(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = BD_URITK(Index).TabIndex
		End If
	End Sub
	
	Private Sub BD_URITK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_URITK.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_URITK.GetIndex(eventSender) 'Generated.
		BD_URITK(Index).ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント CHECK_EMGODNKB.CheckStateChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub CHECK_EMGODNKB_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHECK_EMGODNKB.CheckStateChanged
		Call change_Check_Emgodnkb()
	End Sub
	
    Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
        IM_Denkyu(0).Image = IM_Denkyu(2).Image
        TX_Message.Text = "メニューに戻ります。"
    End Sub
	
    Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
        IM_Denkyu(0).Image = IM_Denkyu(2).Image
        TX_Message.Text = "登録します。"
    End Sub
	
    Private Sub CM_Hardcopy_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
        IM_Denkyu(0).Image = IM_Denkyu(2).Image
        TX_Message.Text = "画面を印刷します。"
    End Sub
	
	Private Sub CM_InsertDe_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "明細行を挿入します。"
	End Sub

    '2019/03/26 DEL START
    'Private Sub CM_DeleteDe_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_DeleteDe.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '	IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '	TX_Message.Text = "明細を一行削除します。"
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START 
    'Private Sub CM_Slist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Slist.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '	IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '	TX_Message.Text = "ウィンドウを表示します。"
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_DeleteDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_DeleteDe.Click 'Generated.
    '	PP_SSSMAIN.ButtonClick = True
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
    '	'UPGRADE_WARNING: オブジェクト DeleteDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(69 + 56 * PP_SSSMAIN.De).CuVal)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If DeleteDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(69 + 56 * PP_SSSMAIN.De).CuVal)) Then
    '		If PP_SSSMAIN.Tx >= 19 And PP_SSSMAIN.Tx < 94 Then
    '			If (PP_SSSMAIN.Tx - 19) \ 15 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
    '				Call AE_DeleteDe_SSSMAIN()
    '			End If
    '		Else
    '			Beep()
    '		End If
    '	End If
    '	PP_SSSMAIN.NeglectLostFocusCheck = False
    '	Call AE_CursorCurrent_SSSMAIN()
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_DELETEDE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_DELETEDE.Image = IM_DELETEDE(1).Image
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_DELETEDE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_DELETEDE.Image = IM_DELETEDE(0).Image
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '    PP_SSSMAIN.ButtonClick = True
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    PP_SSSMAIN.NeglectLostFocusCheck = True
    '    PP_SSSMAIN.CloseCode = 1
    '    Call AE_EndCm_SSSMAIN()
    '    PP_SSSMAIN.NeglectLostFocusCheck = False
    '    Call AE_CursorCurrent_SSSMAIN()
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_ENDCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_ENDCM.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_EndCm.Image = IM_EndCm(1).Image
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_ENDCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_ENDCM.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_EndCm.Image = IM_EndCm(0).Image
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '    Dim wk_Cursor As Short
    '    PP_SSSMAIN.ButtonClick = True
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    If PP_SSSMAIN.Executing Then Exit Sub
    '    PP_SSSMAIN.Executing = True
    '    PP_SSSMAIN.ExplicitExec = True
    '    wk_Cursor = AE_Execute_SSSMAIN()
    '    PP_SSSMAIN.ExplicitExec = False
    '    PP_SSSMAIN.NeglectLostFocusCheck = False
    '    Call AE_CursorSub_SSSMAIN(wk_Cursor)
    '    PP_SSSMAIN.Executing = False
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_EXECUTE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EXECUTE.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_Execute.Image = IM_Execute(1).Image
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_EXECUTE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EXECUTE.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_Execute.Image = IM_Execute(0).Image
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_Hardcopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '    Dim wk_Cursor As Short
    '    PP_SSSMAIN.ButtonClick = True
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    If SSSMAIN_Hardcopy_Getevent() Then
    '        wk_Cursor = AE_Hardcopy_SSSMAIN()
    '    End If
    '    PP_SSSMAIN.NeglectLostFocusCheck = False
    '    Call AE_CursorSub_SSSMAIN(wk_Cursor)
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_HARDCOPY_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_HARDCOPY.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_Hardcopy.Image = IM_Hardcopy(1).Image
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_HARDCOPY_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_HARDCOPY.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_Hardcopy.Image = IM_Hardcopy(0).Image
    '   End Sub
    '2019/03/26 DEL E N D
	
    Private Sub CM_LCONFIG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        PP_SSSMAIN.NeglectLostFocusCheck = True
        If LCONFIG_GetEvent() Then
        End If
        PP_SSSMAIN.NeglectLostFocusCheck = False
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    '2019/03/26 DEL START
    'Private Sub CM_LCONFIG_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_LCONFIG.Image = IM_LCONFIG(1).Image
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_LCONFIG_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_LCONFIG.Image = IM_LCONFIG(0).Image
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Slist.Click 'Generated.
    '	PP_SSSMAIN.ButtonClick = True
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
    '	Call AE_Slist_SSSMAIN()
    '	PP_SSSMAIN.NeglectLostFocusCheck = False
    '	'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN()
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_SLIST.Image = IM_Slist(1).Image
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_SLIST.Image = IM_Slist(0).Image
    'End Sub
    '2019/03/26 DEL E N D
	
	Private Sub CS_JDNNO_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(1).TypeA, 1) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(1)
			If PP_SSSMAIN.Tx <> 1 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_JDNNO_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_JDNNO_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_JDNNO_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub CS_NXTKB_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(15).TypeA, 15) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(15)
			If PP_SSSMAIN.Tx <> 15 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_NXTKB_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_NXTKB_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_NXTKB_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub CS_UDNDT_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(4).TypeA, 4) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(4)
			If PP_SSSMAIN.Tx <> 4 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_UDNDT_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_UDNDT_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub

    '2019/03/26 DEL START
    'Private Sub CS_UDNDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
    '	If Not PP_SSSMAIN.ButtonClick Then
    '		Call AE_CursorCurrent_SSSMAIN()
    '	Else
    '		PP_SSSMAIN.SSCommand5Ajst = False
    '	End If
    '   End Sub
    '2019/03/26 DEL E N D
	
	Private Sub CS_URISU_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		Dim wk_TxBase As Short
		Dim wk_PxBase As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.De2 >= 0 And PP_SSSMAIN.Tx < 94 Then
			wk_PxBase = 56 * PP_SSSMAIN.De
			wk_TxBase = 15 * (PP_SSSMAIN.De - PP_SSSMAIN.TopDe)
		Else
			wk_PxBase = 56 * PP_SSSMAIN.TopDe
			wk_TxBase = 0
		End If
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(58 + wk_PxBase).TypeA, 25 + wk_TxBase) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(25 + wk_TxBase)
			If PP_SSSMAIN.Tx <> 25 + wk_TxBase Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_URISU_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_URISU_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_URISU_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub FM_PANEL3D10_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_PANEL3D12_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_PANEL3D13_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
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
	
	Private Sub FM_PANEL3D3_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	Private Sub FM_PANEL3D4_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		Call AE_CursorCurrent_SSSMAIN()
	End Sub
	
	'UPGRADE_WARNING: Form イベント FR_SSSMAIN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub FR_SSSMAIN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated 'Generated.
		Dim wk_ww As Short
		Dim wk_De As Short
		Dim wk_xx As Short
		If PP_SSSMAIN.Activated = 0 Then
			PP_SSSMAIN.Activated = 1
			wk_De = 1
			Do While wk_De <= PP_SSSMAIN.MaxDspC
				wk_ww = 0
				Do While wk_ww < 15
					wk_xx = 19 + 15 * wk_De + wk_ww
					AE_Controls(PP_SSSMAIN.CtB + wk_xx).Visible = AE_Controls(PP_SSSMAIN.CtB + 19 + wk_ww).Visible
					wk_ww = wk_ww + 1
				Loop 
				wk_De = wk_De + 1
			Loop 
		End If
	End Sub
	
    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'add 20190805 START hou
        MyBase.KeyPreview = True
        'add 20190805 END hou

        '2019/03/26 ADD START
        FORM_LOAD_FLG = True
        '2019/03/26 ADD E N D

        Dim NewLargeChange As Short 'Generated.
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
        Dim PY_BBtm As Single
        Dim PY_BTSpace As Single
        Dim PY_TTop As Single
        AE_Title = "売上登録                          "
        '初画面表示の性能チューニング用 ----------
        'Dim StartTime
        '   AE_MsgBox "Start Point", vbInformation, AE_Title$
        '   StartTime = Timer
        '-----------------------------------------
        With PP_SSSMAIN
            .FormWidth = 14925
            .FormHeight = 9915
            .MaxDe = 98
            .MaxDsp = 4
            .HeadN = 19
            .BodyN = 15
            .BodyV = 56
            .MaxEDe = -1
            .MaxEDsp = -1
            .EBodyN = 0
            .EBodyV = 0
            .TailN = 15
            .BodyPx = 52
            .EBodyPx = 5596
            .TailPx = 5596
            .PrpC = 5613
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
                AE_CtB = AE_CtB + 109
                ReDim Preserve AE_Controls(.CtB + 108)
                .MainFormFile = "URIET51.FRM"
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
                AE_MsgBox("再生成が必要です。", vbCritical, "ｅｅｅ")
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
                        Case "BD_", "BV_"
                            Call AE_SetCp(CP_SSSMAIN(wk_BodyN + 52), wk_BodyN + 52, wk_SmrBuf, CQ_SSSMAIN(wk_BodyN + 52))
                            wk_BodyN = wk_BodyN + 1
                        Case "TL_", "TV_"
                            Do While wk_De <= 98
                                wk_PxBase = 52
                                Do While wk_PxBase < 108
                                    wk_Px = wk_PxBase + 56 * wk_De
                                    Call AE_CopyCp_SSSMAIN(wk_Px, wk_PxBase)
                                    wk_PxBase = wk_PxBase + 1
                                Loop
                                wk_De = wk_De + 1
                            Loop
                            Call AE_SetCp(CP_SSSMAIN(wk_TailN + 5596), wk_TailN + 5596, wk_SmrBuf, CQ_SSSMAIN(wk_TailN + 108))
                            wk_TailN = wk_TailN + 1
                    End Select
                Loop
            End If
            HD_OKRJONO.Text = ""
            HD_JDNNO.Text = ""
            HD_JDNTRKB.Text = ""
            HD_JDNTRNM.Text = ""
            HD_UDNDT.Text = ""
            HD_TOKCD.Text = ""
            HD_TOKRN.Text = ""
            HD_TANCD.Text = ""
            HD_TANNM.Text = ""
            HD_BUMCD.Text = ""
            HD_BUNNM.Text = ""
            HD_SOUCD.Text = ""
            HD_SOUNM.Text = ""
            HD_URIKJN.Text = ""
            HD_URIKJNNM.Text = ""
            HD_NXTKB.Text = ""
            HD_NXTNM.Text = ""
            HD_OPEID.Text = ""
            HD_OPENM.Text = ""
            BD_LINNO(0).Text = ""
            BD_SBNNO(0).Text = ""
            BD_HINCD(0).Text = ""
            BD_TOKJDNNO(0).Text = ""
            BD_HINNMA(0).Text = ""
            BD_HINNMB(0).Text = ""
            BD_URISU(0).Text = ""
            BD_UNTNM(0).Text = ""
            BD_URITK(0).Text = ""
            BD_SIKTK(0).Text = ""
            BD_TNKNM(0).Text = ""
            BD_URIKN(0).Text = ""
            BD_TEIKATK(0).Text = ""
            BD_LINCMA(0).Text = ""
            BD_LINCMB(0).Text = ""
            TL_KENNMA.Text = ""
            TL_KENNMB.Text = ""
            TL_NHSCD.Text = ""
            TL_NHSNMA.Text = ""
            TL_NHSNMB.Text = ""
            TL_NHSADA.Text = ""
            TL_NHSADB.Text = ""
            TL_NHSADC.Text = ""
            TL_MAEUKKB.Text = ""
            TL_MAEUKNM.Text = ""
            TL_DENCM.Text = ""
            TL_DENCMIN.Text = ""
            TL_SBAURIKN.Text = ""
            TL_SBAUZEKN.Text = ""
            TL_SBADENKN.Text = ""
            For wk_De = 1 To 4
                BD_LINCMB.Load(wk_De)
                BD_LINCMA.Load(wk_De)
                BD_TEIKATK.Load(wk_De)
                BD_URIKN.Load(wk_De)
                BD_TNKNM.Load(wk_De)
                BD_SIKTK.Load(wk_De)
                BD_URITK.Load(wk_De)
                BD_UNTNM.Load(wk_De)
                BD_URISU.Load(wk_De)
                BD_HINNMB.Load(wk_De)
                BD_HINNMA.Load(wk_De)
                BD_TOKJDNNO.Load(wk_De)
                BD_HINCD.Load(wk_De)
                BD_SBNNO.Load(wk_De)
                BD_LINNO.Load(wk_De)
            Next wk_De
            HD_OKRJONO.TabIndex = 0
            AE_Controls(.CtB + 0) = HD_OKRJONO
            HD_JDNNO.TabIndex = 1
            AE_Controls(.CtB + 1) = HD_JDNNO
            HD_JDNTRKB.TabIndex = 2
            AE_Controls(.CtB + 2) = HD_JDNTRKB
            HD_JDNTRNM.TabIndex = 3
            AE_Controls(.CtB + 3) = HD_JDNTRNM
            HD_UDNDT.TabIndex = 4
            AE_Controls(.CtB + 4) = HD_UDNDT
            HD_TOKCD.TabIndex = 5
            AE_Controls(.CtB + 5) = HD_TOKCD
            HD_TOKRN.TabIndex = 6
            AE_Controls(.CtB + 6) = HD_TOKRN
            HD_TANCD.TabIndex = 7
            AE_Controls(.CtB + 7) = HD_TANCD
            HD_TANNM.TabIndex = 8
            AE_Controls(.CtB + 8) = HD_TANNM
            HD_BUMCD.TabIndex = 9
            AE_Controls(.CtB + 9) = HD_BUMCD
            HD_BUNNM.TabIndex = 10
            AE_Controls(.CtB + 10) = HD_BUNNM
            HD_SOUCD.TabIndex = 11
            AE_Controls(.CtB + 11) = HD_SOUCD
            HD_SOUNM.TabIndex = 12
            AE_Controls(.CtB + 12) = HD_SOUNM
            HD_URIKJN.TabIndex = 13
            AE_Controls(.CtB + 13) = HD_URIKJN
            HD_URIKJNNM.TabIndex = 14
            AE_Controls(.CtB + 14) = HD_URIKJNNM
            HD_NXTKB.TabIndex = 15
            AE_Controls(.CtB + 15) = HD_NXTKB
            HD_NXTNM.TabIndex = 16
            AE_Controls(.CtB + 16) = HD_NXTNM
            HD_OPEID.TabIndex = 17
            AE_Controls(.CtB + 17) = HD_OPEID
            HD_OPENM.TabIndex = 18
            AE_Controls(.CtB + 18) = HD_OPENM
            For wk_De = 0 To 4
                wk_TxBase = 15 * wk_De
                BD_LINNO(wk_De).TabIndex = 19 + wk_TxBase
                AE_Controls(.CtB + 19 + wk_TxBase) = BD_LINNO(wk_De)
                BD_SBNNO(wk_De).TabIndex = 20 + wk_TxBase
                AE_Controls(.CtB + 20 + wk_TxBase) = BD_SBNNO(wk_De)
                BD_HINCD(wk_De).TabIndex = 21 + wk_TxBase
                AE_Controls(.CtB + 21 + wk_TxBase) = BD_HINCD(wk_De)
                BD_TOKJDNNO(wk_De).TabIndex = 22 + wk_TxBase
                AE_Controls(.CtB + 22 + wk_TxBase) = BD_TOKJDNNO(wk_De)
                BD_HINNMA(wk_De).TabIndex = 23 + wk_TxBase
                AE_Controls(.CtB + 23 + wk_TxBase) = BD_HINNMA(wk_De)
                BD_HINNMB(wk_De).TabIndex = 24 + wk_TxBase
                AE_Controls(.CtB + 24 + wk_TxBase) = BD_HINNMB(wk_De)
                BD_URISU(wk_De).TabIndex = 25 + wk_TxBase
                AE_Controls(.CtB + 25 + wk_TxBase) = BD_URISU(wk_De)
                BD_UNTNM(wk_De).TabIndex = 26 + wk_TxBase
                AE_Controls(.CtB + 26 + wk_TxBase) = BD_UNTNM(wk_De)
                BD_URITK(wk_De).TabIndex = 27 + wk_TxBase
                AE_Controls(.CtB + 27 + wk_TxBase) = BD_URITK(wk_De)
                BD_SIKTK(wk_De).TabIndex = 28 + wk_TxBase
                AE_Controls(.CtB + 28 + wk_TxBase) = BD_SIKTK(wk_De)
                BD_TNKNM(wk_De).TabIndex = 29 + wk_TxBase
                AE_Controls(.CtB + 29 + wk_TxBase) = BD_TNKNM(wk_De)
                BD_URIKN(wk_De).TabIndex = 30 + wk_TxBase
                AE_Controls(.CtB + 30 + wk_TxBase) = BD_URIKN(wk_De)
                BD_TEIKATK(wk_De).TabIndex = 31 + wk_TxBase
                AE_Controls(.CtB + 31 + wk_TxBase) = BD_TEIKATK(wk_De)
                BD_LINCMA(wk_De).TabIndex = 32 + wk_TxBase
                AE_Controls(.CtB + 32 + wk_TxBase) = BD_LINCMA(wk_De)
                BD_LINCMB(wk_De).TabIndex = 33 + wk_TxBase
                AE_Controls(.CtB + 33 + wk_TxBase) = BD_LINCMB(wk_De)
            Next wk_De
            TL_KENNMA.TabIndex = 94
            AE_Controls(.CtB + 94) = TL_KENNMA
            TL_KENNMB.TabIndex = 95
            AE_Controls(.CtB + 95) = TL_KENNMB
            TL_NHSCD.TabIndex = 96
            AE_Controls(.CtB + 96) = TL_NHSCD
            TL_NHSNMA.TabIndex = 97
            AE_Controls(.CtB + 97) = TL_NHSNMA
            TL_NHSNMB.TabIndex = 98
            AE_Controls(.CtB + 98) = TL_NHSNMB
            TL_NHSADA.TabIndex = 99
            AE_Controls(.CtB + 99) = TL_NHSADA
            TL_NHSADB.TabIndex = 100
            AE_Controls(.CtB + 100) = TL_NHSADB
            TL_NHSADC.TabIndex = 101
            AE_Controls(.CtB + 101) = TL_NHSADC
            TL_MAEUKKB.TabIndex = 102
            AE_Controls(.CtB + 102) = TL_MAEUKKB
            TL_MAEUKNM.TabIndex = 103
            AE_Controls(.CtB + 103) = TL_MAEUKNM
            TL_DENCM.TabIndex = 104
            AE_Controls(.CtB + 104) = TL_DENCM
            TL_DENCMIN.TabIndex = 105
            AE_Controls(.CtB + 105) = TL_DENCMIN
            TL_SBAURIKN.TabIndex = 106
            AE_Controls(.CtB + 106) = TL_SBAURIKN
            TL_SBAUZEKN.TabIndex = 107
            AE_Controls(.CtB + 107) = TL_SBAUZEKN
            TL_SBADENKN.TabIndex = 108
            AE_Controls(.CtB + 108) = TL_SBADENKN
            TX_CursorRest.TabIndex = 109
            AE_Timer(.ScX) = TM_StartUp
            AE_CursorRest(.ScX) = TX_CursorRest
            AE_ModeBar(.ScX) = TX_Mode
            AE_StatusBar(.ScX) = TX_Message
            AE_StatusCodeBar(.ScX) = TX_Message
            .Mode = Cn_Mode1 : TX_Mode.Text = "追加"
            Call AE_ClearInitValStatus_SSSMAIN()
            .PY_BTop = VB6.PixelsToTwipsY(Me.Height)
            ReDim AE_BodyTop(15)
            wk_Tx = 19
            Do While wk_Tx < 34
                wk_Top = VB6.PixelsToTwipsY(AE_Controls(.CtB + wk_Tx).Top)
                If wk_Top < .PY_BTop Then .PY_BTop = wk_Top
                AE_BodyTop(wk_Tx - 19) = wk_Top
                wk_Tx = wk_Tx + 1
            Loop
            .PY_EBTop = VB6.PixelsToTwipsY(Me.Height)
            PY_TTop = VB6.PixelsToTwipsY(Me.Height)
            wk_Tx = 94
            Do While wk_Tx < 109
                'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If TypeOf AE_Controls(.CtB + wk_Tx) Is System.Windows.Forms.RadioButton Then
                Else
                    wk_Top = VB6.PixelsToTwipsY(AE_Controls(.CtB + wk_Tx).Top)
                    If wk_Top < PY_TTop Then PY_TTop = wk_Top
                End If
                wk_Tx = wk_Tx + 1
            Loop
            AE_ScrlBar(.ScX) = VS_Scrl
            PY_BBtm = 0
            wk_Tx = 19 : wk_ww = 0
            Do While wk_Tx < 34
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
            If .MaxDspC > 4 Then .MaxDspC = 4
            .NrBodyTx = 19 + 15 * (.MaxDspC + 1)
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
            If .MaxDspC = 98 Then VS_Scrl.Visible = False
            .MaxEDspC = 0
            .NrEBodyTx = 94
            .EScrlMaxL = 1
            Call AE_TabStop_SSSMAIN(0, 108, True)
            TX_CursorRest.TabStop = False
            TX_Mode.TabStop = False
            TX_Message.TabStop = False
            TX_Message.Text = ""
            wk_De = 1
            Do While wk_De <= .MaxDspC
                wk_ww = 0
                Do While wk_ww < 15
                    wk_Tx = 19 + 15 * wk_De + wk_ww
                    AE_Controls(.CtB + wk_Tx).Top = VB6.TwipsToPixelsY(AE_BodyTop(wk_ww) + .PY_BHgt * wk_De)
                    wk_ww = wk_ww + 1
                Loop
                wk_De = wk_De + 1
            Loop
            '2019/03/27　仮　API
            'wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
            '2019/03/27　仮　API
            Call AE_WindowProcSet_SSSMAIN()
            '2019/03/27　仮　API
            'ReleaseTabCapture(0)
            '2019/03/27　仮　API
            '2019/03/27　仮　API
            'SetTabCapture(Me.Handle.ToInt32)
            '2019/03/27　仮　API
            'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Var = SSSMAIN_BeginPrg(PP_SSSMAIN)
            .FormWidth = VB6.PixelsToTwipsX(Me.Width)
            .FormHeight = VB6.PixelsToTwipsY(Me.Height)
            '初画面表示の性能チューニング用 ----------
            '   AE_MsgBox Str$(Timer - StartTime), vbInformation, AE_Title$
            '-----------------------------------------
            .TimerStartUp = True
        End With
        TM_StartUp.Enabled = True

        '2019/04/25 ADD START
        Call SetBar(Me)
        '2019/04/25 ADD E N D

    End Sub
	
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason 'Generated.
		PP_SSSMAIN.UnloadMode = UnloadMode
		Select Case UnloadMode
            Case 0, 3
                '20190710 DEL START
                'PP_SSSMAIN.CloseCode = 2
                '20190710 DEL END
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
                '2019/03/25 CHG START
                'Cancel = True : Exit Sub
                eventSender.Cancel = True
                Exit Sub
                '2019/03/25 CHG E N D
			End If
		Else
			If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then
				'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
                '2019/03/25 CHG START
                'Cancel = True : Exit Sub
                eventSender.Cancel = True
                Exit Sub
                '2019/03/25 CHG E N D
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
            '2019/03/25 CHG START
            'Cancel = True
            eventSender.Cancel = True
            '2019/03/25 CHG E N D
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
	
	'UPGRADE_WARNING: イベント HD_BUMCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_BUMCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUMCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_BUMCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_BUMCD, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_BUMCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_BUMCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUMCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 9
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 9
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(9), HD_BUMCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(9), HD_BUMCD)
        HD_BUMCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_BUMCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BUMCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_BUMCD, KEYCODE, Shift, CP_SSSMAIN(9).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BUMCD(AE_Val3(CP_SSSMAIN(9), HD_BUMCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(9)
		End If
	End Sub
	
	Private Sub HD_BUMCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BUMCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 9 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(9), HD_BUMCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_BUMCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUMCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(9).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BUMCD(AE_Val3(CP_SSSMAIN(9), HD_BUMCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_BUMCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_BUMCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_BUMCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BUMCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BUMCD)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_BUMCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_BUMCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 9
		End If
	End Sub
	
	Private Sub HD_BUMCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BUMCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_BUMCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(9), HD_BUMCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_BUNNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_BUNNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUNNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_BUNNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_BUNNM, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_BUNNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_BUNNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUNNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 10
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 10
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(10), HD_BUNNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(10), HD_BUNNM)
        HD_BUNNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_BUNNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BUNNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_BUNNM, KEYCODE, Shift, CP_SSSMAIN(10).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BUNNM(AE_Val3(CP_SSSMAIN(10), HD_BUNNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(10)
		End If
	End Sub
	
	Private Sub HD_BUNNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BUNNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 10 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(10), HD_BUNNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_BUNNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUNNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(10).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BUNNM(AE_Val3(CP_SSSMAIN(10), HD_BUNNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_BUNNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_BUNNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(10), CL_SSSMAIN(10), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_BUNNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BUNNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BUNNM)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_BUNNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_BUNNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 10
		End If
	End Sub
	
	Private Sub HD_BUNNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BUNNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_BUNNM.ReadOnly = False
	End Sub

    'UPGRADE_WARNING: イベント HD_JDNNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_JDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.TextChanged 'Generated.
        Try
            If PP_SSSMAIN.MultiLineF > 0 Then
                PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
                If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
            End If
            If PP_SSSMAIN.MaskMode = False Then
                '2019/03/27 CHG START
                'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_JDNNO) Then
                If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_JDNNO, FORM_LOAD_FLG) Then
                    '2019/03/27 CHG E N D
                    PP_SSSMAIN.CursorDirection = Cn_Direction1
                    PP_SSSMAIN.CursorDest = Cn_Dest9
                    Call AE_Check_SSSMAIN_JDNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub HD_JDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 1
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 1
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_JDNNO)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_JDNNO)
		HD_JDNNO.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト JDNNO_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = JDNNO_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal))
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
				CP_SSSMAIN(1).TpStr = wk_Slisted
				CP_SSSMAIN(1).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_JDNNO.Text = wk_Slisted
				Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(1), HD_JDNNO.Text), Cn_Status6, True, True)
			End If
        End If
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = True
        '2019/03/26 DEL E N D
	End Sub
	
    Private Sub HD_JDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNNO.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_JDNNO, KEYCODE, Shift, CP_SSSMAIN(1).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(1), HD_JDNNO.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(1)
		End If
	End Sub
	
	Private Sub HD_JDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 1 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_JDNNO, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(1), HD_JDNNO.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_JDNNO.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_JDNNO.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
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
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_JDNNO)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_JDNNO.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_JDNNO.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 1
		End If
	End Sub
	
	Private Sub HD_JDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_JDNNO.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(1), HD_JDNNO)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_JDNTRKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_JDNTRKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNTRKB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNTRKB, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_JDNTRKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_JDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 2
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 2
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNTRKB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNTRKB)
        HD_JDNTRKB.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_JDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_JDNTRKB, KEYCODE, Shift, CP_SSSMAIN(2).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(2), HD_JDNTRKB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(2)
		End If
	End Sub
	
	Private Sub HD_JDNTRKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 2 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNTRKB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNTRKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(2), HD_JDNTRKB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_JDNTRKB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_JDNTRKB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
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
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_JDNTRKB)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_JDNTRKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_JDNTRKB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 2
		End If
	End Sub
	
	Private Sub HD_JDNTRKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_JDNTRKB.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNTRKB)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_JDNTRNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_JDNTRNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNTRNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNTRNM, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
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
		PP_SSSMAIN.Tx = 3
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 3
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNTRNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNTRNM)
        HD_JDNTRNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_JDNTRNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_JDNTRNM, KEYCODE, Shift, CP_SSSMAIN(3).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNTRNM(AE_Val3(CP_SSSMAIN(3), HD_JDNTRNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(3)
		End If
	End Sub
	
	Private Sub HD_JDNTRNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 3 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNTRNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNTRNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNTRNM(AE_Val3(CP_SSSMAIN(3), HD_JDNTRNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_JDNTRNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_JDNTRNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
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
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_JDNTRNM)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_JDNTRNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_JDNTRNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 3
		End If
	End Sub
	
	Private Sub HD_JDNTRNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_JDNTRNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NXTKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NXTKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NXTKB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(15), HD_NXTKB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(15), HD_NXTKB, FORM_LOAD_FLG) Then
                '2019/03/27 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NXTKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_NXTKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NXTKB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 15
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 15
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(15), HD_NXTKB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(15), HD_NXTKB)
		HD_NXTKB.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト NXTKB_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = NXTKB_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(22).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(23).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(24).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal))
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
				CP_SSSMAIN(15).TpStr = wk_Slisted
				CP_SSSMAIN(15).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_NXTKB.Text = wk_Slisted
				Call AE_Check_SSSMAIN_NXTKB(AE_Val3(CP_SSSMAIN(15), HD_NXTKB.Text), Cn_Status6, True, True)
			End If
        End If
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = True
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_NXTKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NXTKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NXTKB, KEYCODE, Shift, CP_SSSMAIN(15).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NXTKB(AE_Val3(CP_SSSMAIN(15), HD_NXTKB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(15)
		End If
	End Sub
	
	Private Sub HD_NXTKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NXTKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 15 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(15), HD_NXTKB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NXTKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NXTKB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(15).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NXTKB(AE_Val3(CP_SSSMAIN(15), HD_NXTKB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NXTKB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NXTKB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(15), CL_SSSMAIN(15), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NXTKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NXTKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NXTKB)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_NXTKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_NXTKB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 15
		End If
	End Sub
	
	Private Sub HD_NXTKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NXTKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NXTKB.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(15), HD_NXTKB)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NXTNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NXTNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NXTNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(16), HD_NXTNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(16), HD_NXTNM, FORM_LOAD_FLG) Then
                '2019/03/27 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NXTNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_NXTNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NXTNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 16
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 16
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(16), HD_NXTNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(16), HD_NXTNM)
        HD_NXTNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_NXTNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NXTNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NXTNM, KEYCODE, Shift, CP_SSSMAIN(16).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NXTNM(AE_Val3(CP_SSSMAIN(16), HD_NXTNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(16)
		End If
	End Sub
	
	Private Sub HD_NXTNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NXTNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 16 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(16), HD_NXTNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NXTNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NXTNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(16).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NXTNM(AE_Val3(CP_SSSMAIN(16), HD_NXTNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NXTNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NXTNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(16), CL_SSSMAIN(16), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NXTNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NXTNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NXTNM)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_NXTNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_NXTNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 16
		End If
	End Sub
	
	Private Sub HD_NXTNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NXTNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NXTNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_OKRJONO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OKRJONO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OKRJONO.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_OKRJONO) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_OKRJONO, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_OKRJONO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_OKRJONO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OKRJONO.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 0
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 0
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_OKRJONO)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(0), HD_OKRJONO)
        HD_OKRJONO.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_OKRJONO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OKRJONO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OKRJONO, KEYCODE, Shift, CP_SSSMAIN(0).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OKRJONO(AE_Val3(CP_SSSMAIN(0), HD_OKRJONO.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(0)
		End If
	End Sub
	
	Private Sub HD_OKRJONO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OKRJONO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 0 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_OKRJONO, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_OKRJONO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OKRJONO.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OKRJONO(AE_Val3(CP_SSSMAIN(0), HD_OKRJONO.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_OKRJONO.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_OKRJONO.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_OKRJONO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OKRJONO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OKRJONO)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_OKRJONO.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_OKRJONO.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 0
		End If
	End Sub
	
	Private Sub HD_OKRJONO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OKRJONO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_OKRJONO.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), HD_OKRJONO)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_OPEID.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OPEID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(17), HD_OPEID) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(17), HD_OPEID, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
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
		PP_SSSMAIN.Tx = 17
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 17
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(17), HD_OPEID)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(17), HD_OPEID)
        HD_OPEID.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_OPEID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPEID.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OPEID, KEYCODE, Shift, CP_SSSMAIN(17).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(17), HD_OPEID.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(17)
		End If
	End Sub
	
	Private Sub HD_OPEID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPEID.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 17 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(17), HD_OPEID, KeyAscii)
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
		If CP_SSSMAIN(17).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(17), HD_OPEID.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_OPEID.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_OPEID.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(17), CL_SSSMAIN(17), PP_SSSMAIN.Tx)
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
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPEID)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_OPEID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_OPEID.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 17
		End If
	End Sub
	
	Private Sub HD_OPEID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPEID.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_OPEID.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(17), HD_OPEID)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_OPENM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OPENM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(18), HD_OPENM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(18), HD_OPENM, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
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
		PP_SSSMAIN.Tx = 18
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 18
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(18), HD_OPENM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(18), HD_OPENM)
        HD_OPENM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_OPENM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPENM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OPENM, KEYCODE, Shift, CP_SSSMAIN(18).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(18), HD_OPENM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(18)
		End If
	End Sub
	
	Private Sub HD_OPENM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPENM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 18 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(18), HD_OPENM, KeyAscii)
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
		If CP_SSSMAIN(18).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(18), HD_OPENM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_OPENM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_OPENM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(18), CL_SSSMAIN(18), PP_SSSMAIN.Tx)
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
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPENM)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_OPENM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_OPENM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 18
		End If
	End Sub
	
	Private Sub HD_OPENM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPENM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_OPENM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_SOUCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_SOUCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_SOUCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_SOUCD, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SOUCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_SOUCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 11
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 11
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(11), HD_SOUCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(11), HD_SOUCD)
        HD_SOUCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_SOUCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_SOUCD, KEYCODE, Shift, CP_SSSMAIN(11).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(11), HD_SOUCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(11)
		End If
	End Sub
	
	Private Sub HD_SOUCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SOUCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 11 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(11), HD_SOUCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_SOUCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(11).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(11), HD_SOUCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_SOUCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_SOUCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(11), CL_SSSMAIN(11), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_SOUCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_SOUCD)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_SOUCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_SOUCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 11
		End If
	End Sub
	
	Private Sub HD_SOUCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_SOUCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(11), HD_SOUCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_SOUNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_SOUNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_SOUNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_SOUNM, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SOUNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_SOUNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 12
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 12
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(12), HD_SOUNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(12), HD_SOUNM)
        HD_SOUNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_SOUNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_SOUNM, KEYCODE, Shift, CP_SSSMAIN(12).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(12), HD_SOUNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(12)
		End If
	End Sub
	
	Private Sub HD_SOUNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SOUNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 12 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(12), HD_SOUNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_SOUNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(12).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(12), HD_SOUNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_SOUNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_SOUNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(12), CL_SSSMAIN(12), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_SOUNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_SOUNM)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_SOUNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_SOUNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 12
		End If
	End Sub
	
	Private Sub HD_SOUNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_SOUNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TANCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_TANCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_TANCD, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_TANCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 7
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 7
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(7), HD_TANCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(7), HD_TANCD)
        HD_TANCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_TANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_TANCD, KEYCODE, Shift, CP_SSSMAIN(7).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(7), HD_TANCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(7)
		End If
	End Sub
	
	Private Sub HD_TANCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TANCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 7 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(7), HD_TANCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(7).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(7), HD_TANCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_TANCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_TANCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7), PP_SSSMAIN.Tx)
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
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TANCD)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_TANCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_TANCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 7
		End If
	End Sub
	
	Private Sub HD_TANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_TANCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(7), HD_TANCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TANNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_TANNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_TANNM, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
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
		PP_SSSMAIN.Tx = 8
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 8
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8), HD_TANNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8), HD_TANNM)
        HD_TANNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_TANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_TANNM, KEYCODE, Shift, CP_SSSMAIN(8).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TANNM(AE_Val3(CP_SSSMAIN(8), HD_TANNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(8)
		End If
	End Sub
	
	Private Sub HD_TANNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TANNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 8 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8), HD_TANNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(8).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TANNM(AE_Val3(CP_SSSMAIN(8), HD_TANNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_TANNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_TANNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8), PP_SSSMAIN.Tx)
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
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TANNM)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_TANNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_TANNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 8
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
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
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
		PP_SSSMAIN.Tx = 5
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD)
		HD_TOKCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト TOKCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = TOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal))
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
				CP_SSSMAIN(5).TpStr = wk_Slisted
				CP_SSSMAIN(5).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_TOKCD.Text = wk_Slisted
				Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(5), HD_TOKCD.Text), Cn_Status6, True, True)
			End If
        End If
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = True
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_TOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_TOKCD, KEYCODE, Shift, CP_SSSMAIN(5).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(5), HD_TOKCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(5)
		End If
	End Sub
	
	Private Sub HD_TOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 5 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(5), HD_TOKCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_TOKCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_TOKCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
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
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TOKCD)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_TOKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_TOKCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 5
		End If
	End Sub
	
	Private Sub HD_TOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_TOKCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TOKRN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TOKRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_TOKRN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_TOKRN, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
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
		PP_SSSMAIN.Tx = 6
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 6
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_TOKRN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_TOKRN)
        HD_TOKRN.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_TOKRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKRN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_TOKRN, KEYCODE, Shift, CP_SSSMAIN(6).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKRN(AE_Val3(CP_SSSMAIN(6), HD_TOKRN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(6)
		End If
	End Sub
	
	Private Sub HD_TOKRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKRN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 6 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_TOKRN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TOKRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKRN(AE_Val3(CP_SSSMAIN(6), HD_TOKRN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_TOKRN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_TOKRN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
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
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TOKRN)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_TOKRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_TOKRN.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 6
		End If
	End Sub
	
	Private Sub HD_TOKRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKRN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_TOKRN.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_UDNDT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_UDNDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_UDNDT.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_UDNDT) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_UDNDT, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_UDNDT(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_UDNDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_UDNDT.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 4
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 4
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_UDNDT)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		'UPGRADE_WARNING: オブジェクト UDNDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 4)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UDNDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 4)) Then
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
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_UDNDT)
		HD_UDNDT.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト UDNDT_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = UDNDT_Slist(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal), PP_SSSMAIN)
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
				HD_UDNDT.Text = wk_Slisted
				Call AE_Check_SSSMAIN_UDNDT(AE_Val3(CP_SSSMAIN(4), HD_UDNDT.Text), Cn_Status6, True, True)
			End If
        End If
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = True
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_UDNDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_UDNDT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_UDNDT, KEYCODE, Shift, CP_SSSMAIN(4).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_UDNDT(AE_Val3(CP_SSSMAIN(4), HD_UDNDT.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(4)
		End If
	End Sub
	
	Private Sub HD_UDNDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_UDNDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 4 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_UDNDT, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_UDNDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_UDNDT.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_UDNDT(AE_Val3(CP_SSSMAIN(4), HD_UDNDT.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_UDNDT.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_UDNDT.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_UDNDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_UDNDT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_UDNDT)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_UDNDT.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_UDNDT.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 4
		End If
	End Sub
	
	Private Sub HD_UDNDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_UDNDT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_UDNDT.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(4), HD_UDNDT)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_URIKJN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_URIKJN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(13), HD_URIKJN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(13), HD_URIKJN, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_URIKJN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_URIKJN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 13
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 13
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(13), HD_URIKJN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(13), HD_URIKJN)
        HD_URIKJN.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_URIKJN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_URIKJN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_URIKJN, KEYCODE, Shift, CP_SSSMAIN(13).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URIKJN(AE_Val3(CP_SSSMAIN(13), HD_URIKJN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(13)
		End If
	End Sub
	
	Private Sub HD_URIKJN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_URIKJN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 13 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(13), HD_URIKJN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_URIKJN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(13).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URIKJN(AE_Val3(CP_SSSMAIN(13), HD_URIKJN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_URIKJN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_URIKJN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(13), CL_SSSMAIN(13), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_URIKJN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_URIKJN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_URIKJN)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_URIKJN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_URIKJN.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 13
		End If
	End Sub
	
	Private Sub HD_URIKJN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_URIKJN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_URIKJN.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(13), HD_URIKJN)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_URIKJNNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_URIKJNNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJNNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(14), HD_URIKJNNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(14), HD_URIKJNNM, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_URIKJNNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub HD_URIKJNNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJNNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 14
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 14
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(14), HD_URIKJNNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(14), HD_URIKJNNM)
        HD_URIKJNNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub HD_URIKJNNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_URIKJNNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_URIKJNNM, KEYCODE, Shift, CP_SSSMAIN(14).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URIKJNNM(AE_Val3(CP_SSSMAIN(14), HD_URIKJNNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(14)
		End If
	End Sub
	
	Private Sub HD_URIKJNNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_URIKJNNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 14 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(14), HD_URIKJNNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_URIKJNNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJNNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(14).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URIKJNNM(AE_Val3(CP_SSSMAIN(14), HD_URIKJNNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_URIKJNNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_URIKJNNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(14), CL_SSSMAIN(14), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_URIKJNNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_URIKJNNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_URIKJNNM)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_URIKJNNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_URIKJNNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 14
		End If
	End Sub
	
	Private Sub HD_URIKJNNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_URIKJNNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_URIKJNNM.ReadOnly = False
	End Sub
	
    Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
        Call Init_Prompt()
    End Sub

    '2019/03/26 DEL START
    'Public Sub MN_AppendC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_AppendC.Click 'Generated.
    '	Dim wk_Cursor As Short
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
    '	If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN()
    '	' === 20130416 === INSERT S - FWEST)Koroyasu 排他制御の解除
    '	Call SSSWIN_Unlock_EXCTBZ()
    '	' === 20130416 === INSERT E -
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Public Sub MN_ClearDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearDe.Click 'Generated.
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
    '	'UPGRADE_WARNING: オブジェクト ClearDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(69 + 56 * PP_SSSMAIN.De).CuVal)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If ClearDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(69 + 56 * PP_SSSMAIN.De).CuVal)) Then
    '		If PP_SSSMAIN.Tx >= 19 And PP_SSSMAIN.Tx < 94 Then
    '			If (PP_SSSMAIN.Tx - 19) \ 15 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
    '				If Not AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
    '					Call AE_ClearDe2_SSSMAIN()
    '				End If
    '			End If
    '		Else
    '			Beep()
    '		End If
    '	End If
    '	Call AE_CursorCurrent_SSSMAIN()
    '   End Sub
    '2019/03/26 DEL E N D
	
    Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        Call AE_ClearItm_SSSMAIN(False)
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    '2019/03/25 DEL START
    'Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click 'Generated.
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
    '		My.Computer.Clipboard.Clear()
    '		'UPGRADE_ISSUE: Control SelLength は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
    '		If VB6.GetActiveControl().SelLength <= 1 Then
    '			On Error Resume Next
    '			'UPGRADE_ISSUE: Control Text は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
    '			My.Computer.Clipboard.SetText(VB6.GetActiveControl().Text)
    '			On Error GoTo 0
    '		Else
    '			On Error Resume Next
    '			'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
    '			My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
    '			On Error GoTo 0
    '		End If
    '	End If
    '   End Sub
    '2019/03/25 DEL E N D
	
    Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
    End Sub
	
    Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
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

    '2019/03/26 DEL START
    'Public Sub MN_DeleteDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_DeleteDe.Click 'Generated.
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
    '	'UPGRADE_WARNING: オブジェクト DeleteDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(69 + 56 * PP_SSSMAIN.De).CuVal)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If DeleteDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(69 + 56 * PP_SSSMAIN.De).CuVal)) Then
    '		If PP_SSSMAIN.Tx >= 19 And PP_SSSMAIN.Tx < 94 Then
    '			If (PP_SSSMAIN.Tx - 19) \ 15 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
    '				Call AE_DeleteDe_SSSMAIN()
    '			End If
    '		Else
    '			Beep()
    '		End If
    '	End If
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/25 DEL START
    'Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click 'Generated.
    '	Const CF_TEXT As Short = 1
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	MN_APPENDC.Enabled = True
    '	MN_ClearItm.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 109 Then
    '		If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm.Enabled = True
    '	End If
    '	MN_UnDoDe.Enabled = False
    '	If PP_SSSMAIN.Mode = Cn_Mode3 Then
    '	ElseIf PP_SSSMAIN.UnDoDeOp = 1 Then 
    '		If AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.UnDoDeNo) And PP_SSSMAIN.UnDoDeNo <= PP_SSSMAIN.LastDe Then MN_UnDoDe.Enabled = True
    '	ElseIf PP_SSSMAIN.UnDoDeOp = 2 Then 
    '		If PP_SSSMAIN.ActiveDe >= 0 Then
    '			If PP_SSSMAIN.UnDoDeNo < PP_SSSMAIN.LastDe Then MN_UnDoDe.Enabled = True
    '		Else
    '			If PP_SSSMAIN.UnDoDeNo <= PP_SSSMAIN.LastDe Then MN_UnDoDe.Enabled = True
    '		End If
    '	End If
    '	MN_ClearDE.Enabled = False
    '	MN_DeleteDE.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 19 And PP_SSSMAIN.Tx < 94 And PP_SSSMAIN.Mode <> Cn_Mode3 Then
    '		If (PP_SSSMAIN.Tx - 19) \ 15 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
    '			If PP_SSSMAIN.Tx >= 19 And PP_SSSMAIN.Tx < 94 Then
    '				If Not AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then MN_ClearDE.Enabled = True
    '			End If
    '			MN_DeleteDE.Enabled = True
    '		End If
    '	End If
    '	MN_Copy.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 109 Then
    '		If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
    '			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '			If Not IsDbNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Copy.Enabled = True
    '		End If
    '	End If
    '	MN_Cut.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 109 Then
    '		If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
    '			'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
    '				If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
    '					If CP_SSSMAIN(PP_SSSMAIN.Px).FixedFormat <> 1 Then
    '						'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '						If Not IsDbNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Cut.Enabled = True
    '					End If
    '				End If
    '			End If
    '		End If
    '	End If
    '	MN_Paste.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 109 Then
    '		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
    '			'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetFormat はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '			If My.Computer.Clipboard.GetFormat(CF_TEXT) Then
    '				If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste.Enabled = True
    '			End If
    '		End If
    '	End If
    '	MN_UnDoItem.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 109 Then
    '		If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
    '			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <= Cn_Status2 Then
    '				MN_UnDoItem.Enabled = True
    '			ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> Cn_Status0 Then 
    '				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '				If IsDbNull(CP_SSSMAIN(PP_SSSMAIN.Px).CuVal) Xor IsDbNull(CP_SSSMAIN(PP_SSSMAIN.Px).ExVal) Then
    '					MN_UnDoItem.Enabled = True
    '					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(PP_SSSMAIN.Px).ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(PP_SSSMAIN.Px).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> CP_SSSMAIN(PP_SSSMAIN.Px).StatusF Or CP_SSSMAIN(PP_SSSMAIN.Px).CuVal <> CP_SSSMAIN(PP_SSSMAIN.Px).ExVal Then 
    '					MN_UnDoItem.Enabled = True
    '				End If
    '			End If
    '		End If
    '	End If
    '   End Sub
    '2019/03/25 DEL E N D
	
    Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        PP_SSSMAIN.CloseCode = 1
        Call AE_EndCm_SSSMAIN()
    End Sub

    '2019/03/26 DEL START
    'Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '    Dim wk_Cursor As Short
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    If PP_SSSMAIN.Executing Then Exit Sub
    '    PP_SSSMAIN.Executing = True
    '    PP_SSSMAIN.ExplicitExec = True
    '    wk_Cursor = AE_Execute_SSSMAIN()
    '    PP_SSSMAIN.ExplicitExec = False
    '    If wk_Cursor = Cn_CuInit Then PP_SSSMAIN.SuppressGotLostFocus = 1
    '    Call AE_CursorSub_SSSMAIN(wk_Cursor)
    '    PP_SSSMAIN.Executing = False
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Public Sub MN_Hardcopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Hardcopy.Click 'Generated.
    '	Dim wk_Cursor As Short
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	If SSSMAIN_Hardcopy_Getevent() Then
    '		wk_Cursor = AE_Hardcopy_SSSMAIN()
    '	End If
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    MN_Slist.Enabled = False
    '    If False Then
    '    ElseIf PP_SSSMAIN.Tx = 1 Then
    '        If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '    ElseIf PP_SSSMAIN.Tx = 4 Then
    '        If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '    ElseIf PP_SSSMAIN.Tx = 5 Then
    '        If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '    ElseIf PP_SSSMAIN.Tx = 15 Then
    '        If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '    ElseIf (PP_SSSMAIN.Tx - 19) Mod 15 = 6 And PP_SSSMAIN.Tx >= 19 And PP_SSSMAIN.Tx < 94 Then
    '        If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '    End If
    '    If PP_SSSMAIN.Mode >= Cn_Mode3 Then
    '    Else
    '    End If
    'End Sub
    '2019/03/26 DEL E N D

    '2019/03/25 DEL START
    'Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click 'Generated.
    '	Dim MaxLB As Short
    '	Dim wk_LnSt As Short
    '	Dim Tx As Short
    '	Dim Px As Short
    '	Dim wk_Txt As String
    '	Dim st_Work As String
    '	Dim wk_Moji As String
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
    '		If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
    '			'UPGRADE_ISSUE: Control TabIndex は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
    '			If VB6.GetActiveControl().TabIndex >= 109 Then
    '				'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
    '				'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '				VB6.GetActiveControl().SelText = My.Computer.Clipboard.GetText()
    '			Else
    '				Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), VB6.GetActiveControl())
    '			End If
    '		End If
    '	End If
    '   End Sub
    '2019/03/25 DEL E N D
	
    Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        PP_SSSMAIN.SlistSw = True
        PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
        Call AE_Slist_SSSMAIN()
        PP_SSSMAIN.SlistSw = False
    End Sub
	
    Public Sub MN_UnDoDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        Call AE_UnDoDe_SSSMAIN()
        Call AE_CursorCurrent_SSSMAIN()
    End Sub
	
    Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        Call AE_UnDoItem_SSSMAIN()
    End Sub
	
    Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
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
	
    Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
            PP_SSSMAIN.Tx = PP_SSSMAIN.PopupTx
            Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx))
            PP_SSSMAIN.Tx = -1
        End If
    End Sub
	
	'UPGRADE_WARNING: イベント TL_DENCM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_DENCM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_DENCM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5606), TL_DENCM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5606), TL_DENCM, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_DENCM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_DENCM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_DENCM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 104
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5606
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5606), TL_DENCM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5606), TL_DENCM)
        TL_DENCM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_DENCM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_DENCM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_DENCM, KEYCODE, Shift, CP_SSSMAIN(5606).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_DENCM(AE_Val3(CP_SSSMAIN(5606), TL_DENCM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(104)
		End If
	End Sub
	
	Private Sub TL_DENCM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_DENCM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 104 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5606), TL_DENCM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_DENCM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_DENCM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5606).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_DENCM(AE_Val3(CP_SSSMAIN(5606), TL_DENCM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_DENCM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_DENCM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5606), CL_SSSMAIN(5606), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_DENCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_DENCM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_DENCM)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_DENCM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_DENCM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 104
		End If
	End Sub
	
	Private Sub TL_DENCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_DENCM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_DENCM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_DENCMIN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_DENCMIN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_DENCMIN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5607), TL_DENCMIN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5607), TL_DENCMIN, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_DENCMIN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_DENCMIN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_DENCMIN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 105
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5607
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5607), TL_DENCMIN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5607), TL_DENCMIN)
        TL_DENCMIN.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_DENCMIN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_DENCMIN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_DENCMIN, KEYCODE, Shift, CP_SSSMAIN(5607).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_DENCMIN(AE_Val3(CP_SSSMAIN(5607), TL_DENCMIN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(105)
		End If
	End Sub
	
	Private Sub TL_DENCMIN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_DENCMIN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 105 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5607), TL_DENCMIN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_DENCMIN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_DENCMIN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5607).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_DENCMIN(AE_Val3(CP_SSSMAIN(5607), TL_DENCMIN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_DENCMIN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_DENCMIN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5607), CL_SSSMAIN(5607), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_DENCMIN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_DENCMIN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_DENCMIN)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_DENCMIN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_DENCMIN.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 105
		End If
	End Sub
	
	Private Sub TL_DENCMIN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_DENCMIN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_DENCMIN.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_KENNMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_KENNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_KENNMA.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5596), TL_KENNMA) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5596), TL_KENNMA, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_KENNMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_KENNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_KENNMA.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 94
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5596
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5596), TL_KENNMA)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5596), TL_KENNMA)
        TL_KENNMA.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_KENNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_KENNMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_KENNMA, KEYCODE, Shift, CP_SSSMAIN(5596).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_KENNMA(AE_Val3(CP_SSSMAIN(5596), TL_KENNMA.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(94)
		End If
	End Sub
	
	Private Sub TL_KENNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_KENNMA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 94 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5596), TL_KENNMA, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_KENNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_KENNMA.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5596).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_KENNMA(AE_Val3(CP_SSSMAIN(5596), TL_KENNMA.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_KENNMA.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_KENNMA.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5596), CL_SSSMAIN(5596), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_KENNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_KENNMA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_KENNMA)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_KENNMA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_KENNMA.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 94
		End If
	End Sub
	
	Private Sub TL_KENNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_KENNMA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_KENNMA.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_KENNMB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_KENNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_KENNMB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5597), TL_KENNMB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5597), TL_KENNMB, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_KENNMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_KENNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_KENNMB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 95
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5597
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5597), TL_KENNMB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5597), TL_KENNMB)
        TL_KENNMB.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_KENNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_KENNMB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_KENNMB, KEYCODE, Shift, CP_SSSMAIN(5597).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_KENNMB(AE_Val3(CP_SSSMAIN(5597), TL_KENNMB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(95)
		End If
	End Sub
	
	Private Sub TL_KENNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_KENNMB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 95 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5597), TL_KENNMB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_KENNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_KENNMB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5597).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_KENNMB(AE_Val3(CP_SSSMAIN(5597), TL_KENNMB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_KENNMB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_KENNMB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5597), CL_SSSMAIN(5597), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_KENNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_KENNMB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_KENNMB)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_KENNMB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_KENNMB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 95
		End If
	End Sub
	
	Private Sub TL_KENNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_KENNMB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_KENNMB.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_MAEUKKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_MAEUKKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_MAEUKKB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5604), TL_MAEUKKB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5604), TL_MAEUKKB, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_MAEUKKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_MAEUKKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_MAEUKKB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 102
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5604
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5604), TL_MAEUKKB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5604), TL_MAEUKKB)
        TL_MAEUKKB.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_MAEUKKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_MAEUKKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_MAEUKKB, KEYCODE, Shift, CP_SSSMAIN(5604).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_MAEUKKB(AE_Val3(CP_SSSMAIN(5604), TL_MAEUKKB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(102)
		End If
	End Sub
	
	Private Sub TL_MAEUKKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_MAEUKKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 102 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5604), TL_MAEUKKB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_MAEUKKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_MAEUKKB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5604).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_MAEUKKB(AE_Val3(CP_SSSMAIN(5604), TL_MAEUKKB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_MAEUKKB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_MAEUKKB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5604), CL_SSSMAIN(5604), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_MAEUKKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_MAEUKKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_MAEUKKB)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_MAEUKKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_MAEUKKB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 102
		End If
	End Sub
	
	Private Sub TL_MAEUKKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_MAEUKKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_MAEUKKB.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5604), TL_MAEUKKB)
	End Sub
	
	'UPGRADE_WARNING: イベント TL_MAEUKNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_MAEUKNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_MAEUKNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5605), TL_MAEUKNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5605), TL_MAEUKNM, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_MAEUKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_MAEUKNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_MAEUKNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 103
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5605
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5605), TL_MAEUKNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5605), TL_MAEUKNM)
        TL_MAEUKNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_MAEUKNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_MAEUKNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_MAEUKNM, KEYCODE, Shift, CP_SSSMAIN(5605).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_MAEUKNM(AE_Val3(CP_SSSMAIN(5605), TL_MAEUKNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(103)
		End If
	End Sub
	
	Private Sub TL_MAEUKNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_MAEUKNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 103 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5605), TL_MAEUKNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_MAEUKNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_MAEUKNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5605).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_MAEUKNM(AE_Val3(CP_SSSMAIN(5605), TL_MAEUKNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_MAEUKNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_MAEUKNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5605), CL_SSSMAIN(5605), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_MAEUKNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_MAEUKNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_MAEUKNM)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_MAEUKNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_MAEUKNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 103
		End If
	End Sub
	
	Private Sub TL_MAEUKNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_MAEUKNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_MAEUKNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_NHSADA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_NHSADA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSADA.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5601), TL_NHSADA) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5601), TL_NHSADA, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSADA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_NHSADA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSADA.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 99
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5601
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5601), TL_NHSADA)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5601), TL_NHSADA)
        TL_NHSADA.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_NHSADA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_NHSADA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_NHSADA, KEYCODE, Shift, CP_SSSMAIN(5601).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADA(AE_Val3(CP_SSSMAIN(5601), TL_NHSADA.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(99)
		End If
	End Sub
	
	Private Sub TL_NHSADA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_NHSADA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 99 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5601), TL_NHSADA, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_NHSADA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSADA.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5601).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADA(AE_Val3(CP_SSSMAIN(5601), TL_NHSADA.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_NHSADA.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_NHSADA.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5601), CL_SSSMAIN(5601), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_NHSADA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSADA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSADA)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_NHSADA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_NHSADA.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 99
		End If
	End Sub
	
	Private Sub TL_NHSADA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSADA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_NHSADA.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_NHSADB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_NHSADB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSADB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5602), TL_NHSADB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5602), TL_NHSADB, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSADB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_NHSADB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSADB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 100
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5602
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5602), TL_NHSADB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5602), TL_NHSADB)
        TL_NHSADB.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_NHSADB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_NHSADB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_NHSADB, KEYCODE, Shift, CP_SSSMAIN(5602).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADB(AE_Val3(CP_SSSMAIN(5602), TL_NHSADB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(100)
		End If
	End Sub
	
	Private Sub TL_NHSADB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_NHSADB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 100 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5602), TL_NHSADB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_NHSADB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSADB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5602).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADB(AE_Val3(CP_SSSMAIN(5602), TL_NHSADB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_NHSADB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_NHSADB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5602), CL_SSSMAIN(5602), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_NHSADB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSADB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSADB)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_NHSADB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_NHSADB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 100
		End If
	End Sub
	
	Private Sub TL_NHSADB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSADB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_NHSADB.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_NHSADC.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_NHSADC_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSADC.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5603), TL_NHSADC) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5603), TL_NHSADC, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSADC(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_NHSADC_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSADC.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 101
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5603
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5603), TL_NHSADC)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5603), TL_NHSADC)
        TL_NHSADC.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_NHSADC_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_NHSADC.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_NHSADC, KEYCODE, Shift, CP_SSSMAIN(5603).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADC(AE_Val3(CP_SSSMAIN(5603), TL_NHSADC.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(101)
		End If
	End Sub
	
	Private Sub TL_NHSADC_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_NHSADC.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 101 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5603), TL_NHSADC, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_NHSADC_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSADC.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5603).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADC(AE_Val3(CP_SSSMAIN(5603), TL_NHSADC.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_NHSADC.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_NHSADC.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5603), CL_SSSMAIN(5603), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_NHSADC_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSADC.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSADC)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_NHSADC.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_NHSADC.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 101
		End If
	End Sub
	
	Private Sub TL_NHSADC_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSADC.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_NHSADC.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_NHSCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_NHSCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5598), TL_NHSCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5598), TL_NHSCD, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_NHSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 96
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5598
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5598), TL_NHSCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5598), TL_NHSCD)
        TL_NHSCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_NHSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_NHSCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_NHSCD, KEYCODE, Shift, CP_SSSMAIN(5598).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(5598), TL_NHSCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(96)
		End If
	End Sub
	
	Private Sub TL_NHSCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_NHSCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 96 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5598), TL_NHSCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_NHSCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5598).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(5598), TL_NHSCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_NHSCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_NHSCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5598), CL_SSSMAIN(5598), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_NHSCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSCD)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_NHSCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_NHSCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 96
		End If
	End Sub
	
	Private Sub TL_NHSCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_NHSCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5598), TL_NHSCD)
	End Sub
	
	'UPGRADE_WARNING: イベント TL_NHSNMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_NHSNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSNMA.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5599), TL_NHSNMA) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5599), TL_NHSNMA, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSNMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_NHSNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSNMA.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 97
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5599
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5599), TL_NHSNMA)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5599), TL_NHSNMA)
        TL_NHSNMA.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_NHSNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_NHSNMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_NHSNMA, KEYCODE, Shift, CP_SSSMAIN(5599).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMA(AE_Val3(CP_SSSMAIN(5599), TL_NHSNMA.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(97)
		End If
	End Sub
	
	Private Sub TL_NHSNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_NHSNMA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 97 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5599), TL_NHSNMA, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_NHSNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSNMA.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5599).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMA(AE_Val3(CP_SSSMAIN(5599), TL_NHSNMA.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_NHSNMA.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_NHSNMA.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5599), CL_SSSMAIN(5599), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_NHSNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSNMA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSNMA)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_NHSNMA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_NHSNMA.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 97
		End If
	End Sub
	
	Private Sub TL_NHSNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSNMA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_NHSNMA.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_NHSNMB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_NHSNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSNMB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5600), TL_NHSNMB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5600), TL_NHSNMB, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSNMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_NHSNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSNMB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 98
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5600
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5600), TL_NHSNMB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5600), TL_NHSNMB)
        TL_NHSNMB.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_NHSNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_NHSNMB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_NHSNMB, KEYCODE, Shift, CP_SSSMAIN(5600).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMB(AE_Val3(CP_SSSMAIN(5600), TL_NHSNMB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(98)
		End If
	End Sub
	
	Private Sub TL_NHSNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_NHSNMB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 98 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5600), TL_NHSNMB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_NHSNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_NHSNMB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5600).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMB(AE_Val3(CP_SSSMAIN(5600), TL_NHSNMB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_NHSNMB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_NHSNMB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5600), CL_SSSMAIN(5600), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_NHSNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSNMB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSNMB)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_NHSNMB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_NHSNMB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 98
		End If
	End Sub
	
	Private Sub TL_NHSNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_NHSNMB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_NHSNMB.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント TL_SBADENKN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_SBADENKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBADENKN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5610), TL_SBADENKN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5610), TL_SBADENKN, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SBADENKN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_SBADENKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBADENKN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 108
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5610
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5610), TL_SBADENKN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5610), TL_SBADENKN)
        TL_SBADENKN.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_SBADENKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_SBADENKN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_SBADENKN, KEYCODE, Shift, CP_SSSMAIN(5610).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SBADENKN(AE_Val3(CP_SSSMAIN(5610), TL_SBADENKN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(108)
		End If
	End Sub
	
	Private Sub TL_SBADENKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_SBADENKN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 108 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5610), TL_SBADENKN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_SBADENKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBADENKN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5610).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SBADENKN(AE_Val3(CP_SSSMAIN(5610), TL_SBADENKN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_SBADENKN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_SBADENKN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5610), CL_SSSMAIN(5610), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_SBADENKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBADENKN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_SBADENKN)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_SBADENKN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_SBADENKN.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 108
		End If
	End Sub
	
	Private Sub TL_SBADENKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBADENKN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_SBADENKN.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5610), TL_SBADENKN)
	End Sub
	
	'UPGRADE_WARNING: イベント TL_SBAURIKN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_SBAURIKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAURIKN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5608), TL_SBAURIKN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5608), TL_SBAURIKN, FORM_LOAD_FLG) Then
                '2019/03/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SBAURIKN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_SBAURIKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAURIKN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 106
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5608
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5608), TL_SBAURIKN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5608), TL_SBAURIKN)
        TL_SBAURIKN.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_SBAURIKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_SBAURIKN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_SBAURIKN, KEYCODE, Shift, CP_SSSMAIN(5608).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SBAURIKN(AE_Val3(CP_SSSMAIN(5608), TL_SBAURIKN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(106)
		End If
	End Sub
	
	Private Sub TL_SBAURIKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_SBAURIKN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 106 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5608), TL_SBAURIKN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_SBAURIKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAURIKN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5608).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SBAURIKN(AE_Val3(CP_SSSMAIN(5608), TL_SBAURIKN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_SBAURIKN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_SBAURIKN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5608), CL_SSSMAIN(5608), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_SBAURIKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAURIKN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_SBAURIKN)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_SBAURIKN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_SBAURIKN.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 106
		End If
	End Sub
	
	Private Sub TL_SBAURIKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAURIKN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_SBAURIKN.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5608), TL_SBAURIKN)
	End Sub
	
	'UPGRADE_WARNING: イベント TL_SBAUZEKN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TL_SBAUZEKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUZEKN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/03/27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5609), TL_SBAUZEKN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5609), TL_SBAUZEKN, FORM_LOAD_FLG) Then
                '2019/03/27 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SBAUZEKN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
	End Sub
	
	Private Sub TL_SBAUZEKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUZEKN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 107
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5609
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5609), TL_SBAUZEKN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		If PP_SSSMAIN.ExTx < 19 Then
			If AE_CompleteCheck_SSSMAIN(True) > 0 Then
				If PP_SSSMAIN.InCompletePx >= 0 Then
					If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
				End If
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			End If
		End If
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5609), TL_SBAUZEKN)
        TL_SBAUZEKN.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
	End Sub
	
	Private Sub TL_SBAUZEKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_SBAUZEKN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(TL_SBAUZEKN, KEYCODE, Shift, CP_SSSMAIN(5609).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SBAUZEKN(AE_Val3(CP_SSSMAIN(5609), TL_SBAUZEKN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(107)
		End If
	End Sub
	
	Private Sub TL_SBAUZEKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_SBAUZEKN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 107 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5609), TL_SBAUZEKN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TL_SBAUZEKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUZEKN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5609).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SBAUZEKN(AE_Val3(CP_SSSMAIN(5609), TL_SBAUZEKN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				TL_SBAUZEKN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(TL_SBAUZEKN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5609), CL_SSSMAIN(5609), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub TL_SBAUZEKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAUZEKN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019/03/26 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_SBAUZEKN)
                '2019/03/26 DEL E N D
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/03/25　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/03/25　仮
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = TL_SBAUZEKN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                TL_SBAUZEKN.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
			PP_SSSMAIN.MouseDownTx = 107
		End If
	End Sub
	
	Private Sub TL_SBAUZEKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAUZEKN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		TL_SBAUZEKN.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5609), TL_SBAUZEKN)
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
				Do While wk_ww < 15
					Tx = 19 + 15 * De + wk_ww
					AE_Controls(PP_SSSMAIN.CtB + Tx).Visible = AE_Controls(PP_SSSMAIN.CtB + 19 + wk_ww).Visible
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
        '2019/03/26 DEL START
        'CM_SLIST.Enabled = False
        '2019/03/26 DEL E N D
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
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
				wk_Bool = AE_CursorUp_SSSMAIN(109)
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.Down And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
				wk_Bool = AE_CursorDown_SSSMAIN(-1)
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.Right And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
				wk_Bool = AE_CursorNext_SSSMAIN(-1)
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.Left And Shift = 0 Then 
			If PP_SSSMAIN.Mode = Cn_Mode3 Then
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
			Else
				PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
				wk_Bool = AE_CursorPrev_SSSMAIN(109)
			End If
		ElseIf (KEYCODE = System.Windows.Forms.Keys.Execute Or KEYCODE = System.Windows.Forms.Keys.Return) And Shift = 0 Then 
		ElseIf KEYCODE = System.Windows.Forms.Keys.End And Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			If PP_SSSMAIN.Mode = Cn_Mode3 Then Call AE_Scrl_SSSMAIN(98, False)
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				If AE_CursorPrevDsp_SSSMAIN(109) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.Home And Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			If PP_SSSMAIN.Mode = Cn_Mode3 Then Call AE_Scrl_SSSMAIN(0, False)
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				If AE_CursorNextDsp_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			End If
		ElseIf KEYCODE = System.Windows.Forms.Keys.PageDown And Shift = 0 Then 
			If (PP_SSSMAIN.ScrollObject And 1) > 0 Then Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + PP_SSSMAIN.ScrlMaxL, PP_SSSMAIN.Mode <> Cn_Mode3)
		ElseIf KEYCODE = System.Windows.Forms.Keys.PageUp And Shift = 0 Then 
			If (PP_SSSMAIN.ScrollObject And 1) > 0 Then Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - PP_SSSMAIN.ScrlMaxL, PP_SSSMAIN.Mode <> Cn_Mode3)
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
            '2019/03/26 DEL START
            'SM_FullPast.Enabled = False
            '2019/03/26 DEL E N D
			'UPGRADE_ISSUE: 定数 vbPopupMenuRightButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '2019/03/25　仮
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            '2019/03/25　仮
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
            '2019/03/26 DEL START
            'SM_FullPast.Enabled = False
            '2019/03/26 DEL E N D
			'UPGRADE_ISSUE: 定数 vbPopupMenuRightButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '2019/03/25　仮
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            '2019/03/25　仮
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

    '2019/03/27 ADD START
    Private Sub CS_JDNNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_JDNNO.Click
        Dim wk_Slisted As Object
        Dim wk_SaveTx As Short
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(1).TypeA, 1) Then
            PP_SSSMAIN.SlistCall = True
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            Call AE_CursorMove_SSSMAIN(1)
            If PP_SSSMAIN.Tx <> 1 Then PP_SSSMAIN.SSCommand5Ajst = True
        Else
            Beep()
            Call AE_CursorCurrent_SSSMAIN()
        End If
        PP_SSSMAIN.CursorDirection = 0
    End Sub

    Private Sub CS_NXTKB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_NXTKB.Click
        Dim wk_Slisted As Object
        Dim wk_SaveTx As Short
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(15).TypeA, 15) Then
            PP_SSSMAIN.SlistCall = True
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            Call AE_CursorMove_SSSMAIN(15)
            If PP_SSSMAIN.Tx <> 15 Then PP_SSSMAIN.SSCommand5Ajst = True
        Else
            Beep()
            Call AE_CursorCurrent_SSSMAIN()
        End If
        PP_SSSMAIN.CursorDirection = 0
    End Sub
    '2019/03/27 ADD E N D

    '2019/04/02 ADD START
    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
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
    '2019/04/02 ADD E N D

    '2019/04/02 ADD START
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If Not PP_SSSMAIN.Operable Then Exit Sub
        PP_SSSMAIN.CloseCode = 1
        Call AE_EndCm_SSSMAIN()
    End Sub
    '2019/04/02 ADD E N D

    'add 20190805 START 

    Private Sub FR_SSSMAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    '更新
                    Me.btnF1.PerformClick()

                Case Keys.F5
                    '参照
                    Me.btnF5.PerformClick()

                Case Keys.F8
                    '行削除
                    Me.btnF8.PerformClick()

                Case Keys.F9
                    'クリア
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    '終了
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub

    Private Sub CS_UDNDT_Click(sender As Object, e As EventArgs) Handles CS_UDNDT.Click
        Dim wk_Slisted As Object
        Dim wk_SaveTx As Short
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(4).TypeA, 4) Then
            PP_SSSMAIN.SlistCall = True
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            Call AE_CursorMove_SSSMAIN(4)
            If PP_SSSMAIN.Tx <> 4 Then PP_SSSMAIN.SSCommand5Ajst = True
        Else
            Beep()
            Call AE_CursorCurrent_SSSMAIN()
        End If
        PP_SSSMAIN.CursorDirection = 0
    End Sub

    Private Sub btnF5_Click(sender As Object, e As EventArgs) Handles btnF5.Click
        '参照
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then
            Exit Sub
        End If
        PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
        Call AE_Slist_SSSMAIN()
        PP_SSSMAIN.NeglectLostFocusCheck = False
        'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then
            Call AE_CursorCurrent_SSSMAIN()
        End If
    End Sub

    Private Sub btnF8_Click(sender As Object, e As EventArgs) Handles btnF8.Click
        '行削除
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If PP_SSSMAIN.Mode = Cn_Mode3 Then
            Beep()
            Call AE_CursorCurrent_SSSMAIN()
            Exit Sub
        End If
        'UPGRADE_WARNING: オブジェクト DeleteDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(69 + 56 * PP_SSSMAIN.De).CuVal)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If DeleteDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(69 + 56 * PP_SSSMAIN.De).CuVal)) Then
            If PP_SSSMAIN.Tx >= 19 And PP_SSSMAIN.Tx < 94 Then
                If (PP_SSSMAIN.Tx - 19) \ 15 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
                    Call AE_DeleteDe_SSSMAIN()
                End If
            Else
                Beep()
            End If
        End If
        PP_SSSMAIN.NeglectLostFocusCheck = False
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        'クリア
        'PP_SSSMAIN.ButtonClick = True
        'If Not PP_SSSMAIN.Operable Then Exit Sub
        Dim wk_Cursor As Short
        If Not PP_SSSMAIN.Operable Then
            Exit Sub
        End If
        wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
        If wk_Cursor = Cn_CuInit Then
            Call AE_CursorInit_SSSMAIN()
        End If
    End Sub
    'add 20190805 END hou

    'add 20190814 START hou
    Private Sub btnF2_Click(sender As Object, e As EventArgs) Handles btnF2.Click
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
        Call AE_Slist_SSSMAIN()
        PP_SSSMAIN.NeglectLostFocusCheck = False
        'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN()

    End Sub
    'add 20190814 END hou
End Class