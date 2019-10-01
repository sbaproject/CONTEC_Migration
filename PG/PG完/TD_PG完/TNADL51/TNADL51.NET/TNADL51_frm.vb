Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
    'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
    '*** End Of Generated Declaration Section ****
    '20190705 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '20190705 ADD END



    Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "メニューに戻ります。"
	End Sub
	
	Private Sub CM_Hardcopy_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Hardcopy.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "画面を印刷します。"
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
	
	Private Sub CM_SelectCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SelectCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "画面をクリアしてコードの入力を待ちます。"
	End Sub
	
	Private Sub CM_NextCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "次のページを表示します。"
	End Sub
	
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "実行します。"
	End Sub
	
	'UPGRADE_WARNING: イベント BD_RELZAISU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_RELZAISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_RELZAISU.TextChanged
		Dim Index As Short = BD_RELZAISU.GetIndex(eventSender) 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
		If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_RELZAISU(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_RELZAISU(Index), FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_RELZAISU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub BD_RELZAISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_RELZAISU.Enter
        Dim Index As Short = BD_RELZAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = BD_RELZAISU(Index).TabIndex
        PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
        PP_SSSMAIN.Px = 15 + 8 * PP_SSSMAIN.De
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(15 + 8 * PP_SSSMAIN.De), BD_RELZAISU(Index))
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        If PP_SSSMAIN.ExTx < 8 Then
            If AE_CompleteCheck_SSSMAIN(True) > 0 Then
                If PP_SSSMAIN.InCompletePx >= 0 Then
                    If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
                End If
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
            End If
        End If
        PP_SSSMAIN.De2 = PP_SSSMAIN.De
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_RELZAISU(Index))
        BD_RELZAISU(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub BD_RELZAISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_RELZAISU.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_RELZAISU.GetIndex(eventSender) 'Generated.
        If AE_KeyDown_SSSMAIN(BD_RELZAISU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
            If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
                Call AE_ClearItm_SSSMAIN(True)
                wk_Bool = AE_CursorSkip_SSSMAIN()
            Else '20190705 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_RELZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_RELZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '20190705 CHG END
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
    End Sub

    Private Sub BD_RELZAISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_RELZAISU.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_RELZAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.Tx <> 15 + 8 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_RELZAISU(Index), KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_RELZAISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_RELZAISU.Leave
        Dim Index As Short = BD_RELZAISU.GetIndex(eventSender) 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If PP_SSSMAIN.ScrlFlag Then
            PP_SSSMAIN.ScrlFlag = False
        Else
            If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '20190705 CHG START    
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_RELZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_RELZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '20190705 CHG END
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                    On Error Resume Next
                    BD_RELZAISU(Index).Focus()
                End If
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(BD_RELZAISU(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub BD_RELZAISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_RELZAISU.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_RELZAISU.GetIndex(eventSender) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_RELZAISU(Index))
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_RELZAISU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_RELZAISU(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = BD_RELZAISU(Index).TabIndex
        End If
    End Sub

    Private Sub BD_RELZAISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_RELZAISU.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_RELZAISU.GetIndex(eventSender) 'Generated.
        BD_RELZAISU(Index).ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_RELZAISU(Index))
    End Sub

    'UPGRADE_WARNING: イベント BD_SMAINPSU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub BD_SMAINPSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMAINPSU.TextChanged
        Dim Index As Short = BD_SMAINPSU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAINPSU(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAINPSU(Index), FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SMAINPSU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub BD_SMAINPSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMAINPSU.Enter
        Dim Index As Short = BD_SMAINPSU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = BD_SMAINPSU(Index).TabIndex
        PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
        PP_SSSMAIN.Px = 11 + 8 * PP_SSSMAIN.De
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(11 + 8 * PP_SSSMAIN.De), BD_SMAINPSU(Index))
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        If PP_SSSMAIN.ExTx < 8 Then
            If AE_CompleteCheck_SSSMAIN(True) > 0 Then
                If PP_SSSMAIN.InCompletePx >= 0 Then
                    If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
                End If
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
            End If
        End If
        PP_SSSMAIN.De2 = PP_SSSMAIN.De
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAINPSU(Index))
        BD_SMAINPSU(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub BD_SMAINPSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SMAINPSU.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SMAINPSU.GetIndex(eventSender) 'Generated.
        If AE_KeyDown_SSSMAIN(BD_SMAINPSU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
            If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
                Call AE_ClearItm_SSSMAIN(True)
                wk_Bool = AE_CursorSkip_SSSMAIN()
            Else '20190705 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SMAINPSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SMAINPSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '20190705 CHG END
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
    End Sub

    Private Sub BD_SMAINPSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SMAINPSU.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SMAINPSU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.Tx <> 11 + 8 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAINPSU(Index), KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_SMAINPSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMAINPSU.Leave
        Dim Index As Short = BD_SMAINPSU.GetIndex(eventSender) 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If PP_SSSMAIN.ScrlFlag Then
            PP_SSSMAIN.ScrlFlag = False
        Else
            If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '20190705 CHG START    
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SMAINPSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SMAINPSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '20190705 CHG END
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                    On Error Resume Next
                    BD_SMAINPSU(Index).Focus()
                End If
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(BD_SMAINPSU(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub BD_SMAINPSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SMAINPSU.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SMAINPSU.GetIndex(eventSender) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAINPSU(Index))
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_SMAINPSU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_SMAINPSU(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = BD_SMAINPSU(Index).TabIndex
        End If
    End Sub

    Private Sub BD_SMAINPSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SMAINPSU.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SMAINPSU.GetIndex(eventSender) 'Generated.
        BD_SMAINPSU(Index).ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAINPSU(Index))
    End Sub

    'UPGRADE_WARNING: イベント BD_SMAOUTSU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub BD_SMAOUTSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMAOUTSU.TextChanged
        Dim Index As Short = BD_SMAOUTSU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAOUTSU(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAOUTSU(Index), FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SMAOUTSU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub BD_SMAOUTSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMAOUTSU.Enter
        Dim Index As Short = BD_SMAOUTSU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = BD_SMAOUTSU(Index).TabIndex
        PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
        PP_SSSMAIN.Px = 12 + 8 * PP_SSSMAIN.De
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(12 + 8 * PP_SSSMAIN.De), BD_SMAOUTSU(Index))
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        If PP_SSSMAIN.ExTx < 8 Then
            If AE_CompleteCheck_SSSMAIN(True) > 0 Then
                If PP_SSSMAIN.InCompletePx >= 0 Then
                    If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
                End If
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
            End If
        End If
        PP_SSSMAIN.De2 = PP_SSSMAIN.De
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAOUTSU(Index))
        BD_SMAOUTSU(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub BD_SMAOUTSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SMAOUTSU.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SMAOUTSU.GetIndex(eventSender) 'Generated.
        If AE_KeyDown_SSSMAIN(BD_SMAOUTSU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
            If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
                Call AE_ClearItm_SSSMAIN(True)
                wk_Bool = AE_CursorSkip_SSSMAIN()
            Else '20190705 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SMAOUTSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SMAOUTSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '20190705 CHG END
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
    End Sub

    Private Sub BD_SMAOUTSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SMAOUTSU.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SMAOUTSU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.Tx <> 12 + 8 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAOUTSU(Index), KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_SMAOUTSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMAOUTSU.Leave
        Dim Index As Short = BD_SMAOUTSU.GetIndex(eventSender) 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If PP_SSSMAIN.ScrlFlag Then
            PP_SSSMAIN.ScrlFlag = False
        Else
            If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '20190705 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SMAOUTSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SMAOUTSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '20190705 CHG END
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                    On Error Resume Next
                    BD_SMAOUTSU(Index).Focus()
                End If
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(BD_SMAOUTSU(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub BD_SMAOUTSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SMAOUTSU.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SMAOUTSU.GetIndex(eventSender) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAOUTSU(Index))
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_SMAOUTSU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_SMAOUTSU(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = BD_SMAOUTSU(Index).TabIndex
        End If
    End Sub

    Private Sub BD_SMAOUTSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SMAOUTSU.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SMAOUTSU.GetIndex(eventSender) 'Generated.
        BD_SMAOUTSU(Index).ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAOUTSU(Index))
    End Sub

    'UPGRADE_WARNING: イベント BD_SMAZAISU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub BD_SMAZAISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMAZAISU.TextChanged
        Dim Index As Short = BD_SMAZAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAZAISU(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAZAISU(Index), FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SMAZAISU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub BD_SMAZAISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMAZAISU.Enter
        Dim Index As Short = BD_SMAZAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = BD_SMAZAISU(Index).TabIndex
        PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
        PP_SSSMAIN.Px = 14 + 8 * PP_SSSMAIN.De
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(14 + 8 * PP_SSSMAIN.De), BD_SMAZAISU(Index))
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        If PP_SSSMAIN.ExTx < 8 Then
            If AE_CompleteCheck_SSSMAIN(True) > 0 Then
                If PP_SSSMAIN.InCompletePx >= 0 Then
                    If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
                End If
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
            End If
        End If
        PP_SSSMAIN.De2 = PP_SSSMAIN.De
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAZAISU(Index))
        BD_SMAZAISU(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub BD_SMAZAISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SMAZAISU.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SMAZAISU.GetIndex(eventSender) 'Generated.
        If AE_KeyDown_SSSMAIN(BD_SMAZAISU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
            If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
                Call AE_ClearItm_SSSMAIN(True)
                wk_Bool = AE_CursorSkip_SSSMAIN()
            Else '20190705 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SMAZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SMAZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '20190705 CHG END
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
    End Sub

    Private Sub BD_SMAZAISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SMAZAISU.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SMAZAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.Tx <> 14 + 8 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAZAISU(Index), KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_SMAZAISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMAZAISU.Leave
        Dim Index As Short = BD_SMAZAISU.GetIndex(eventSender) 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If PP_SSSMAIN.ScrlFlag Then
            PP_SSSMAIN.ScrlFlag = False
        Else
            If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '20190705 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SMAZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SMAZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '20190705 CHG END
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                    On Error Resume Next
                    BD_SMAZAISU(Index).Focus()
                End If
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(BD_SMAZAISU(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub BD_SMAZAISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SMAZAISU.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SMAZAISU.GetIndex(eventSender) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAZAISU(Index))
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_SMAZAISU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_SMAZAISU(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = BD_SMAZAISU(Index).TabIndex
        End If
    End Sub

    Private Sub BD_SMAZAISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SMAZAISU.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SMAZAISU.GetIndex(eventSender) 'Generated.
        BD_SMAZAISU(Index).ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMAZAISU(Index))
    End Sub

    'UPGRADE_WARNING: イベント BD_SMZZAISU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub BD_SMZZAISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMZZAISU.TextChanged
        Dim Index As Short = BD_SMZZAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMZZAISU(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMZZAISU(Index), FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SMZZAISU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub BD_SMZZAISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMZZAISU.Enter
        Dim Index As Short = BD_SMZZAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = BD_SMZZAISU(Index).TabIndex
        PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
        PP_SSSMAIN.Px = 10 + 8 * PP_SSSMAIN.De
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(10 + 8 * PP_SSSMAIN.De), BD_SMZZAISU(Index))
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        If PP_SSSMAIN.ExTx < 8 Then
            If AE_CompleteCheck_SSSMAIN(True) > 0 Then
                If PP_SSSMAIN.InCompletePx >= 0 Then
                    If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
                End If
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
            End If
        End If
        PP_SSSMAIN.De2 = PP_SSSMAIN.De
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMZZAISU(Index))
        BD_SMZZAISU(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub BD_SMZZAISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SMZZAISU.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SMZZAISU.GetIndex(eventSender) 'Generated.
        If AE_KeyDown_SSSMAIN(BD_SMZZAISU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
            If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
                Call AE_ClearItm_SSSMAIN(True)
                wk_Bool = AE_CursorSkip_SSSMAIN()
            Else '20190705 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SMZZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SMZZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '20190705 CHG END
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
    End Sub

    Private Sub BD_SMZZAISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SMZZAISU.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SMZZAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.Tx <> 10 + 8 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMZZAISU(Index), KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_SMZZAISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SMZZAISU.Leave
        Dim Index As Short = BD_SMZZAISU.GetIndex(eventSender) 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If PP_SSSMAIN.ScrlFlag Then
            PP_SSSMAIN.ScrlFlag = False
        Else
            If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '20190705 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SMZZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SMZZAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '20190705 CHG END
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                    On Error Resume Next
                    BD_SMZZAISU(Index).Focus()
                End If
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(BD_SMZZAISU(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub BD_SMZZAISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SMZZAISU.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SMZZAISU.GetIndex(eventSender) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMZZAISU(Index))
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_SMZZAISU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_SMZZAISU(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = BD_SMZZAISU(Index).TabIndex
        End If
    End Sub

    Private Sub BD_SMZZAISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SMZZAISU.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SMZZAISU.GetIndex(eventSender) 'Generated.
        BD_SMZZAISU(Index).ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SMZZAISU(Index))
    End Sub

    'UPGRADE_WARNING: イベント BD_SOUCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub BD_SOUCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUCD.TextChanged
        Dim Index As Short = BD_SOUCD.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index), FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SOUCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub BD_SOUCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUCD.Enter
        Dim Index As Short = BD_SOUCD.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = BD_SOUCD(Index).TabIndex
        PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
        PP_SSSMAIN.Px = 8 + 8 * PP_SSSMAIN.De
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8 + 8 * PP_SSSMAIN.De), BD_SOUCD(Index))
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        If PP_SSSMAIN.ExTx < 8 Then
            If AE_CompleteCheck_SSSMAIN(True) > 0 Then
                If PP_SSSMAIN.InCompletePx >= 0 Then
                    If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
                End If
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
            End If
        End If
        PP_SSSMAIN.De2 = PP_SSSMAIN.De
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index))
        BD_SOUCD(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub BD_SOUCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SOUCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SOUCD.GetIndex(eventSender) 'Generated.
        If AE_KeyDown_SSSMAIN(BD_SOUCD(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
            If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
                Call AE_ClearItm_SSSMAIN(True)
                wk_Bool = AE_CursorSkip_SSSMAIN()
            Else '20190705 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '20190705 CHG END
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
    End Sub

    Private Sub BD_SOUCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SOUCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SOUCD.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.Tx <> 8 + 8 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index), KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_SOUCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUCD.Leave
        Dim Index As Short = BD_SOUCD.GetIndex(eventSender) 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If PP_SSSMAIN.ScrlFlag Then
            PP_SSSMAIN.ScrlFlag = False
        Else
            If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '20190705 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '20190705 CHG END
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                    On Error Resume Next
                    BD_SOUCD(Index).Focus()
                End If
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(BD_SOUCD(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub BD_SOUCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SOUCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SOUCD.GetIndex(eventSender) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index))
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_SOUCD(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_SOUCD(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = BD_SOUCD(Index).TabIndex
        End If
    End Sub

    Private Sub BD_SOUCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SOUCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SOUCD.GetIndex(eventSender) 'Generated.
        BD_SOUCD(Index).ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index))
    End Sub

    'UPGRADE_WARNING: イベント BD_SOUNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub BD_SOUNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.TextChanged
        Dim Index As Short = BD_SOUNM.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUNM(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUNM(Index), FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SOUNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub BD_SOUNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.Enter
        Dim Index As Short = BD_SOUNM.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = BD_SOUNM(Index).TabIndex
        PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
        PP_SSSMAIN.Px = 9 + 8 * PP_SSSMAIN.De
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(9 + 8 * PP_SSSMAIN.De), BD_SOUNM(Index))
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        If PP_SSSMAIN.ExTx < 8 Then
            If AE_CompleteCheck_SSSMAIN(True) > 0 Then
                If PP_SSSMAIN.InCompletePx >= 0 Then
                    If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
                End If
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
            End If
        End If
        PP_SSSMAIN.De2 = PP_SSSMAIN.De
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUNM(Index))
        BD_SOUNM(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub BD_SOUNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SOUNM.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SOUNM.GetIndex(eventSender) 'Generated.
        If AE_KeyDown_SSSMAIN(BD_SOUNM(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
            If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
                Call AE_ClearItm_SSSMAIN(True)
                wk_Bool = AE_CursorSkip_SSSMAIN()
            Else '20190705 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '20190705 CHG END
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
    End Sub

    Private Sub BD_SOUNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SOUNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SOUNM.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.Tx <> 9 + 8 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUNM(Index), KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_SOUNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.Leave
        Dim Index As Short = BD_SOUNM.GetIndex(eventSender) 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If PP_SSSMAIN.ScrlFlag Then
            PP_SSSMAIN.ScrlFlag = False
        Else
            If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '20190705 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '20190705 CHG END
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                    On Error Resume Next
                    BD_SOUNM(Index).Focus()
                End If
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(BD_SOUNM(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub BD_SOUNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SOUNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SOUNM.GetIndex(eventSender) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUNM(Index))
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_SOUNM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_SOUNM(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = BD_SOUNM(Index).TabIndex
        End If
    End Sub

    Private Sub BD_SOUNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SOUNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SOUNM.GetIndex(eventSender) 'Generated.
        BD_SOUNM(Index).ReadOnly = False
    End Sub

    'UPGRADE_WARNING: イベント BD_ZAISAISU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub BD_ZAISAISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ZAISAISU.TextChanged
        Dim Index As Short = BD_ZAISAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ZAISAISU(Index)) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ZAISAISU(Index), FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_ZAISAISU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub BD_ZAISAISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ZAISAISU.Enter
        Dim Index As Short = BD_ZAISAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = BD_ZAISAISU(Index).TabIndex
        PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
        PP_SSSMAIN.Px = 13 + 8 * PP_SSSMAIN.De
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(13 + 8 * PP_SSSMAIN.De), BD_ZAISAISU(Index))
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        If PP_SSSMAIN.ExTx < 8 Then
            If AE_CompleteCheck_SSSMAIN(True) > 0 Then
                If PP_SSSMAIN.InCompletePx >= 0 Then
                    If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx) : Exit Sub
                End If
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
            End If
        End If
        PP_SSSMAIN.De2 = PP_SSSMAIN.De
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ZAISAISU(Index))
        BD_ZAISAISU(Index).BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub BD_ZAISAISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_ZAISAISU.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_ZAISAISU.GetIndex(eventSender) 'Generated.
        If AE_KeyDown_SSSMAIN(BD_ZAISAISU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
            If RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
                Call AE_ClearItm_SSSMAIN(True)
                wk_Bool = AE_CursorSkip_SSSMAIN()
            Else '20190705 CHG START
                'If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ZAISAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, True, True)
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ZAISAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, True, True)
                '20190705 CHG END
                If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
    End Sub

    Private Sub BD_ZAISAISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_ZAISAISU.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_ZAISAISU.GetIndex(eventSender) 'Generated.
        If PP_SSSMAIN.Tx <> 13 + 8 * Index Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ZAISAISU(Index), KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_ZAISAISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ZAISAISU.Leave
        Dim Index As Short = BD_ZAISAISU.GetIndex(eventSender) 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If PP_SSSMAIN.ScrlFlag Then
            PP_SSSMAIN.ScrlFlag = False
        Else
            If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
                '20190705 CHG START
                'If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ZAISAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).ToString()), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ZAISAISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)).Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
                '20190705 CHG END
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                    On Error Resume Next
                    BD_ZAISAISU(Index).Focus()
                End If
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(BD_ZAISAISU(Index).BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub BD_ZAISAISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ZAISAISU.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_ZAISAISU.GetIndex(eventSender) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ZAISAISU(Index))
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = BD_ZAISAISU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                BD_ZAISAISU(Index).Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = BD_ZAISAISU(Index).TabIndex
        End If
    End Sub

    Private Sub BD_ZAISAISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ZAISAISU.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_ZAISAISU.GetIndex(eventSender) 'Generated.
        BD_ZAISAISU(Index).ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ZAISAISU(Index))
    End Sub
    '20190710 dell start
    'Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click 'Generated.
    '    PP_SSSMAIN.ButtonClick = True
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    PP_SSSMAIN.NeglectLostFocusCheck = True
    '    PP_SSSMAIN.CloseCode = 1
    '    Call AE_EndCm_SSSMAIN()
    '    PP_SSSMAIN.NeglectLostFocusCheck = False
    '    Call AE_CursorCurrent_SSSMAIN()
    'End Sub


    'Private Sub CM_ENDCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_EndCm.Image = IM_EndCm(1).Image
    'End Sub

    'Private Sub CM_ENDCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_EndCm.Image = IM_EndCm(0).Image
    'End Sub
    '20190710 dell end

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

    Private Sub CM_EXECUTE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        If PP_SSSMAIN.Operable Then CM_Execute.Image = IM_Execute(1).Image
    End Sub

    Private Sub CM_EXECUTE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseUp
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

    Private Sub CM_HARDCOPY_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Hardcopy.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        If PP_SSSMAIN.Operable Then CM_Hardcopy.Image = IM_Hardcopy(1).Image
    End Sub

    Private Sub CM_HARDCOPY_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Hardcopy.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        If PP_SSSMAIN.Operable Then CM_Hardcopy.Image = IM_Hardcopy(0).Image
    End Sub

    Private Sub CM_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_NEXTCM.Click 'Generated.
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
            Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
        End If
        If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
            Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
            PP_SSSMAIN.CursorSet = True
        Else
            If PP_SSSMAIN.Mode >= Cn_Mode3 Then
                wk_Int = AE_NextCm_SSSMAIN(True)
            Else
                Beep()
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
        If PP_SSSMAIN.Operable Then CM_NEXTCM.Image = IM_NEXTCM(1).Image
    End Sub

    Private Sub CM_NEXTCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NEXTCM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        If PP_SSSMAIN.Operable Then CM_NEXTCM.Image = IM_NEXTCM(0).Image
    End Sub

    Private Sub CM_Prev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_PREV.Click 'Generated.
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
            Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
        End If
        If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
            Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
            PP_SSSMAIN.CursorSet = True
        Else
            If PP_SSSMAIN.Mode >= Cn_Mode3 Then
                wk_Int = AE_Prev_SSSMAIN(True)
            Else
                Beep()
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

    Private Sub CM_SelectCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SELECTCM.Click 'Generated.
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
        If PP_SSSMAIN.Operable Then CM_SELECTCM.Image = IM_SELECTCM(1).Image
    End Sub

    Private Sub CM_SELECTCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        If PP_SSSMAIN.Operable Then CM_SELECTCM.Image = IM_SELECTCM(0).Image
    End Sub

    Private Sub CM_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SLIST.Click 'Generated.
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
    '20190710 DELL START
    'Private Sub CS_HINCD_Click() 'Generated.
    '    Dim wk_Slisted As Object
    '    Dim wk_SaveTx As Short
    '    PP_SSSMAIN.ButtonClick = True
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(1).TypeA, 1) Then
    '        PP_SSSMAIN.SlistCall = True
    '        PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
    '        Call AE_CursorMove_SSSMAIN(1)
    '        If PP_SSSMAIN.Tx <> 1 Then PP_SSSMAIN.SSCommand5Ajst = True
    '    Else
    '        Beep()
    '        Call AE_CursorCurrent_SSSMAIN()
    '    End If
    '    PP_SSSMAIN.CursorDirection = 0
    'End Sub
    '20190710 DELL END
    Private Sub CS_HINCD_GotFocus() 'Generated.
        PP_SSSMAIN.ButtonClick = False
    End Sub

    Private Sub CS_HINCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
        If PP_SSSMAIN.ButtonClick = False Then
            If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
        End If
    End Sub

    Private Sub CS_HINCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
        If Not PP_SSSMAIN.ButtonClick Then
            Call AE_CursorCurrent_SSSMAIN()
        Else
            PP_SSSMAIN.SSCommand5Ajst = False
        End If
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
            wk_De = 1
            Do While wk_De <= PP_SSSMAIN.MaxDspC
                wk_ww = 0
                Do While wk_ww < 8
                    wk_xx = 8 + 8 * wk_De + wk_ww
                    AE_Controls(PP_SSSMAIN.CtB + wk_xx).Visible = AE_Controls(PP_SSSMAIN.CtB + 8 + wk_ww).Visible
                    wk_ww = wk_ww + 1
                Loop
                wk_De = wk_De + 1
            Loop
        End If
    End Sub

    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '20190705 ADD START
        FORM_LOAD_FLG = True
        '20190705 ADD END
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
        AE_Title = "在庫照会（製品別）                     "
        '初画面表示の性能チューニング用 ----------
        'Dim StartTime
        '   AE_MsgBox "Start Point", vbInformation, AE_Title$
        '   StartTime = Timer
        '-----------------------------------------
        With PP_SSSMAIN
            .FormWidth = 10710
            .FormHeight = 7890
            .MaxDe = 14
            .MaxDsp = 14
            .HeadN = 8
            .BodyN = 8
            .BodyV = 8
            .MaxEDe = -1
            .MaxEDsp = -1
            .EBodyN = 0
            .EBodyV = 0
            .TailN = 0
            .BodyPx = 8
            .EBodyPx = 128
            .TailPx = 128
            .PrpC = 128
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
                AE_CtB = AE_CtB + 128
                ReDim Preserve AE_Controls(.CtB + 127)
                .MainFormFile = "TNADL51.FRM"
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
                        Case "BD_", "BV_"
                            Call AE_SetCp(CP_SSSMAIN(wk_BodyN + 8), wk_BodyN + 8, wk_SmrBuf, CQ_SSSMAIN(wk_BodyN + 8))
                            wk_BodyN = wk_BodyN + 1
                    End Select
                Loop
                Do While wk_De <= 14
                    wk_PxBase = 8
                    Do While wk_PxBase < 16
                        wk_Px = wk_PxBase + 8 * wk_De
                        Call AE_CopyCp_SSSMAIN(wk_Px, wk_PxBase)
                        wk_PxBase = wk_PxBase + 1
                    Loop
                    wk_De = wk_De + 1
                Loop
            End If
            HD_DSPYM.Text = ""
            HD_HINCD.Text = ""
            HD_HINNMA.Text = ""
            HD_HINNMB.Text = ""
            HD_IRISU.Text = ""
            HD_UNTNM.Text = ""
            HD_OPEID.Text = ""
            HD_OPENM.Text = ""
            BD_SOUCD(0).Text = ""
            BD_SOUNM(0).Text = ""
            BD_SMZZAISU(0).Text = ""
            BD_SMAINPSU(0).Text = ""
            BD_SMAOUTSU(0).Text = ""
            BD_ZAISAISU(0).Text = ""
            BD_SMAZAISU(0).Text = ""
            BD_RELZAISU(0).Text = ""
            For wk_De = 1 To 14
                BD_RELZAISU.Load(wk_De)
                BD_SMAZAISU.Load(wk_De)
                BD_ZAISAISU.Load(wk_De)
                BD_SMAOUTSU.Load(wk_De)
                BD_SMAINPSU.Load(wk_De)
                BD_SMZZAISU.Load(wk_De)
                BD_SOUNM.Load(wk_De)
                BD_SOUCD.Load(wk_De)
            Next wk_De
            HD_DSPYM.TabIndex = 0
            AE_Controls(.CtB + 0) = HD_DSPYM
            HD_HINCD.TabIndex = 1
            AE_Controls(.CtB + 1) = HD_HINCD
            HD_HINNMA.TabIndex = 2
            AE_Controls(.CtB + 2) = HD_HINNMA
            HD_HINNMB.TabIndex = 3
            AE_Controls(.CtB + 3) = HD_HINNMB
            HD_IRISU.TabIndex = 4
            AE_Controls(.CtB + 4) = HD_IRISU
            HD_UNTNM.TabIndex = 5
            AE_Controls(.CtB + 5) = HD_UNTNM
            HD_OPEID.TabIndex = 6
            AE_Controls(.CtB + 6) = HD_OPEID
            HD_OPENM.TabIndex = 7
            AE_Controls(.CtB + 7) = HD_OPENM
            For wk_De = 0 To 14
                wk_TxBase = 8 * wk_De
                BD_SOUCD(wk_De).TabIndex = 8 + wk_TxBase
                AE_Controls(.CtB + 8 + wk_TxBase) = BD_SOUCD(wk_De)
                BD_SOUNM(wk_De).TabIndex = 9 + wk_TxBase
                AE_Controls(.CtB + 9 + wk_TxBase) = BD_SOUNM(wk_De)
                BD_SMZZAISU(wk_De).TabIndex = 10 + wk_TxBase
                AE_Controls(.CtB + 10 + wk_TxBase) = BD_SMZZAISU(wk_De)
                BD_SMAINPSU(wk_De).TabIndex = 11 + wk_TxBase
                AE_Controls(.CtB + 11 + wk_TxBase) = BD_SMAINPSU(wk_De)
                BD_SMAOUTSU(wk_De).TabIndex = 12 + wk_TxBase
                AE_Controls(.CtB + 12 + wk_TxBase) = BD_SMAOUTSU(wk_De)
                BD_ZAISAISU(wk_De).TabIndex = 13 + wk_TxBase
                AE_Controls(.CtB + 13 + wk_TxBase) = BD_ZAISAISU(wk_De)
                BD_SMAZAISU(wk_De).TabIndex = 14 + wk_TxBase
                AE_Controls(.CtB + 14 + wk_TxBase) = BD_SMAZAISU(wk_De)
                BD_RELZAISU(wk_De).TabIndex = 15 + wk_TxBase
                AE_Controls(.CtB + 15 + wk_TxBase) = BD_RELZAISU(wk_De)
            Next wk_De
            TX_CursorRest.TabIndex = 128
            AE_Timer(.ScX) = TM_StartUp
            AE_CursorRest(.ScX) = TX_CursorRest
            AE_ModeBar(.ScX) = TX_Mode
            AE_StatusBar(.ScX) = TX_Message
            AE_StatusCodeBar(.ScX) = TX_Message
            .Mode = Cn_Mode1 : TX_Mode.Text = "追加"
            Call AE_ClearInitValStatus_SSSMAIN()
            .PY_BTop = VB6.PixelsToTwipsY(Me.Height)
            ReDim AE_BodyTop(8)
            wk_Tx = 8
            Do While wk_Tx < 16
                wk_Top = VB6.PixelsToTwipsY(AE_Controls(.CtB + wk_Tx).Top)
                If wk_Top < .PY_BTop Then .PY_BTop = wk_Top
                AE_BodyTop(wk_Tx - 8) = wk_Top
                wk_Tx = wk_Tx + 1
            Loop
            .PY_EBTop = VB6.PixelsToTwipsY(Me.Height)
            PY_TTop = VB6.PixelsToTwipsY(Me.Height)
            AE_ScrlBar(.ScX) = VS_Scrl
            PY_BBtm = 0
            wk_Tx = 8 : wk_ww = 0
            Do While wk_Tx < 16
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
            .NrBodyTx = 8 + 8 * (.MaxDspC + 1)
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
            .NrEBodyTx = 128
            .EScrlMaxL = 1
            Call AE_TabStop_SSSMAIN(0, 127, True)
            TX_CursorRest.TabStop = False
            TX_Mode.TabStop = False
            TX_Message.TabStop = False
            TX_Message.Text = ""
            wk_De = 1
            Do While wk_De <= .MaxDspC
                wk_ww = 0
                Do While wk_ww < 8
                    wk_Tx = 8 + 8 * wk_De + wk_ww
                    AE_Controls(.CtB + wk_Tx).Top = VB6.TwipsToPixelsY(AE_BodyTop(wk_ww) + .PY_BHgt * wk_De)
                    wk_ww = wk_ww + 1
                Loop
                wk_De = wk_De + 1
            Loop
            '20190705 DELL START
            'wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
            '20190705 DELL END
            Call AE_WindowProcSet_SSSMAIN()
            '20190705 DELL START
            'ReleaseTabCapture(0)
            'SetTabCapture(Me.Handle.ToInt32)
            '20190705 DELL END
            'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Var = SSSMAIN_BeginPrg(PP_SSSMAIN)
            'UPGRADE_WARNING: オブジェクト SSSMAIN_HINNMA_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Var = SSSMAIN_HINNMA_BeginPrg(PP_SSSMAIN, CP_SSSMAIN(2))
            'UPGRADE_WARNING: オブジェクト SSSMAIN_HINNMB_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Var = SSSMAIN_HINNMB_BeginPrg(PP_SSSMAIN, CP_SSSMAIN(3))
            'UPGRADE_WARNING: オブジェクト SSSMAIN_UNTNM_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Var = SSSMAIN_UNTNM_BeginPrg(PP_SSSMAIN, CP_SSSMAIN(5))
            'UPGRADE_WARNING: オブジェクト SSSMAIN_OPEID_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Var = SSSMAIN_OPEID_BeginPrg(PP_SSSMAIN, CP_SSSMAIN(6))
            'UPGRADE_WARNING: オブジェクト SSSMAIN_OPENM_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Var = SSSMAIN_OPENM_BeginPrg(PP_SSSMAIN, CP_SSSMAIN(7))
            'UPGRADE_WARNING: オブジェクト SSSMAIN_SOUCD_BeginPrg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Var = SSSMAIN_SOUCD_BeginPrg(PP_SSSMAIN, CP_SSSMAIN(8 + 8 * PP_SSSMAIN.De))
            .FormWidth = VB6.PixelsToTwipsX(Me.Width)
            .FormHeight = VB6.PixelsToTwipsY(Me.Height)
            '初画面表示の性能チューニング用 ----------
            '   AE_MsgBox Str$(Timer - StartTime), vbInformation, AE_Title$
            '-----------------------------------------
            .TimerStartUp = True
        End With
        TM_StartUp.Enabled = True
        '20190705 ADD START
        GetRowsCommon("TANMTA", "where TANCD = '" & SSS_OPEID.Value & "'")

        If DBSTAT = 1 Then
            Me.HD_OPEID.Text = ""
            Me.HD_OPENM.Text = ""
        Else
            Me.HD_OPEID.Text = DB_TANMTA.TANCD
            Me.HD_OPENM.Text = DB_TANMTA.TANNM
        End If

        Call SetBar(Me)
        '20190705 ADD END
    End Sub
    '20190705 ADD START
    Public Sub SetBar(ByRef pForm As Form)

        Try
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = My.Application.Info.AssemblyName
        Catch ex As Exception
            MsgBox("ﾀｲﾄﾙﾊﾞｰ,ｽﾃｰﾀｽﾊﾞｰ設定関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub
    '20190705 ADD END

    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason 'Generated.
        PP_SSSMAIN.UnloadMode = UnloadMode
        Select Case UnloadMode
            Case 0, 3
                PP_SSSMAIN.CloseCode = 2
                '20190710 CHG START
                'Cancel = True
                eventArgs.Cancel = Cancel
                '20190710 CHG EDN
                Call AE_EndCm_SSSMAIN()
                Exit Sub
            Case 2
                PP_SSSMAIN.Caption = Me.Text
                '20190710 CHG START
                'If AE_MsgLibrary(PP_SSSMAIN, "QueryUnload") = False Then Cancel = True
                If AE_MsgLibrary(PP_SSSMAIN, "QueryUnload") = False Then
                    eventArgs.Cancel = Cancel
                    Exit Sub
                End If
                '20190710 CHG END
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
                '20190705 CHG START
                'ancel = True : Exit Sub
                eventSender.Cancel = True
                Exit Sub
                '20190705 CHG END
            End If
        Else
            If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then
                'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
                '20190705 CHG START
                'Cancel = True : Exit Sub
                eventSender.Cancel = True
                Exit Sub
                '20190705 CHG END
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
            '20190705 CHG START
            'Cancel = True
            eventSender.Cancel = True
            '20190705 CHG END
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

    'UPGRADE_WARNING: イベント HD_DSPYM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_DSPYM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DSPYM.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_DSPYM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_DSPYM, FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_DSPYM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub HD_DSPYM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DSPYM.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 0
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 0
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_DSPYM)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        'UPGRADE_WARNING: オブジェクト DSPYM_Skip(AE_Controls(PP_SSSMAIN.CtB + 0)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If DSPYM_Skip(AE_Controls(PP_SSSMAIN.CtB + 0)) Then
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
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(0), HD_DSPYM)
        HD_DSPYM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub HD_DSPYM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DSPYM.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_DSPYM, KEYCODE, Shift, CP_SSSMAIN(0).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_DSPYM(AE_Val3(CP_SSSMAIN(0), HD_DSPYM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(0)
        End If
    End Sub

    Private Sub HD_DSPYM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_DSPYM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 0 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_DSPYM, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_DSPYM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DSPYM.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_DSPYM(AE_Val3(CP_SSSMAIN(0), HD_DSPYM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_DSPYM.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_DSPYM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_DSPYM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DSPYM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_DSPYM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_DSPYM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_DSPYM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 0
        End If
    End Sub

    Private Sub HD_DSPYM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DSPYM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_DSPYM.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), HD_DSPYM)
    End Sub

    'UPGRADE_WARNING: イベント HD_HINCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_HINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_HINCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_HINCD, FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_HINCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub HD_HINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        Dim wk_Slisted As Object
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 1
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 1
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_HINCD)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_HINCD)
        HD_HINCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
        If PP_SSSMAIN.SlistCall Then
            PP_SSSMAIN.SlistCall = False
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
            'UPGRADE_WARNING: オブジェクト HINCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Slisted = HINCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal))
        Else
            'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Slisted = PP_SSSMAIN.SlistCom
        End If
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If Not IsDBNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
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
                HD_HINCD.Text = wk_Slisted
                Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(1), HD_HINCD.Text), Cn_Status6, True, True)
            End If
        End If
        CM_SLIST.Enabled = True
    End Sub

    Private Sub HD_HINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_HINCD, KEYCODE, Shift, CP_SSSMAIN(1).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(1), HD_HINCD.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(1)
        End If
    End Sub

    Private Sub HD_HINCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 1 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_HINCD, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_HINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(1), HD_HINCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_HINCD.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_HINCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_HINCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_HINCD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_HINCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_HINCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 1
        End If
    End Sub

    Private Sub HD_HINCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_HINCD.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(1), HD_HINCD)
    End Sub

    'UPGRADE_WARNING: イベント HD_HINNMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_HINNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_HINNMA) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_HINNMA, FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_HINNMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub HD_HINNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 2
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 2
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_HINNMA)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_HINNMA)
        HD_HINNMA.BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub HD_HINNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMA.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_HINNMA, KEYCODE, Shift, CP_SSSMAIN(2).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINNMA(AE_Val3(CP_SSSMAIN(2), HD_HINNMA.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(2)
        End If
    End Sub

    Private Sub HD_HINNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINNMA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 2 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_HINNMA, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_HINNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINNMA(AE_Val3(CP_SSSMAIN(2), HD_HINNMA.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_HINNMA.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_HINNMA.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_HINNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMA.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_HINNMA)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_HINNMA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_HINNMA.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 2
        End If
    End Sub

    Private Sub HD_HINNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMA.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_HINNMA.ReadOnly = False
    End Sub

    'UPGRADE_WARNING: イベント HD_HINNMB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_HINNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_HINNMB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_HINNMB, FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_HINNMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub HD_HINNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 3
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 3
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_HINNMB)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_HINNMB)
        HD_HINNMB.BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub HD_HINNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMB.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_HINNMB, KEYCODE, Shift, CP_SSSMAIN(3).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINNMB(AE_Val3(CP_SSSMAIN(3), HD_HINNMB.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(3)
        End If
    End Sub

    Private Sub HD_HINNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINNMB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 3 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_HINNMB, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_HINNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINNMB(AE_Val3(CP_SSSMAIN(3), HD_HINNMB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_HINNMB.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_HINNMB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_HINNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_HINNMB)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_HINNMB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_HINNMB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 3
        End If
    End Sub

    Private Sub HD_HINNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_HINNMB.ReadOnly = False
    End Sub

    'UPGRADE_WARNING: イベント HD_IRISU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_IRISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IRISU.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_IRISU) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_IRISU, FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_IRISU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub HD_IRISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IRISU.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 4
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 4
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_IRISU)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_IRISU)
        HD_IRISU.BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub HD_IRISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IRISU.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_IRISU, KEYCODE, Shift, CP_SSSMAIN(4).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_IRISU(AE_Val3(CP_SSSMAIN(4), HD_IRISU.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(4)
        End If
    End Sub

    Private Sub HD_IRISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_IRISU.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 4 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_IRISU, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_IRISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IRISU.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_IRISU(AE_Val3(CP_SSSMAIN(4), HD_IRISU.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_IRISU.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_IRISU.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_IRISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IRISU.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_IRISU)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_IRISU.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_IRISU.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 4
        End If
    End Sub

    Private Sub HD_IRISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IRISU.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_IRISU.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(4), HD_IRISU)
    End Sub

    'UPGRADE_WARNING: イベント HD_OPEID.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_OPEID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_OPEID) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_OPEID, FORM_LOAD_FLG) Then
                '20190705 CHG END
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
        PP_SSSMAIN.Tx = 6
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 6
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_OPEID)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_OPEID)
        HD_OPEID.BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub HD_OPEID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPEID.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_OPEID, KEYCODE, Shift, CP_SSSMAIN(6).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(6), HD_OPEID.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(6)
        End If
    End Sub

    Private Sub HD_OPEID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPEID.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 6 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_OPEID, KeyAscii)
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
        If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(6), HD_OPEID.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_OPEID.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_OPEID.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
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
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_OPEID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_OPEID.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 6
        End If
    End Sub

    Private Sub HD_OPEID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPEID.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_OPEID.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(6), HD_OPEID)
    End Sub

    'UPGRADE_WARNING: イベント HD_OPENM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_OPENM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPENM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPENM, FORM_LOAD_FLG) Then
                '20190705 CHG END
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
        PP_SSSMAIN.Tx = 7
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 7
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPENM)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPENM)
        HD_OPENM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub HD_OPENM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPENM.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_OPENM, KEYCODE, Shift, CP_SSSMAIN(7).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(7), HD_OPENM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(7)
        End If
    End Sub

    Private Sub HD_OPENM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPENM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 7 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPENM, KeyAscii)
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
        If CP_SSSMAIN(7).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(7), HD_OPENM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_OPENM.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_OPENM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7), PP_SSSMAIN.Tx)
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
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_OPENM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_OPENM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 7
        End If
    End Sub

    Private Sub HD_OPENM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPENM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_OPENM.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPENM)
    End Sub

    'UPGRADE_WARNING: イベント HD_UNTNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_UNTNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_UNTNM.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '20190705 CHG START'
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_UNTNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_UNTNM, FORM_LOAD_FLG) Then
                '20190705 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_UNTNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub HD_UNTNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_UNTNM.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 5
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 5
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_UNTNM)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_UNTNM)
        HD_UNTNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        CM_SLIST.Enabled = False
    End Sub

    Private Sub HD_UNTNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_UNTNM.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_UNTNM, KEYCODE, Shift, CP_SSSMAIN(5).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_UNTNM(AE_Val3(CP_SSSMAIN(5), HD_UNTNM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(5)
        End If
    End Sub

    Private Sub HD_UNTNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_UNTNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 5 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_UNTNM, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_UNTNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_UNTNM.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_UNTNM(AE_Val3(CP_SSSMAIN(5), HD_UNTNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_UNTNM.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_UNTNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_UNTNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_UNTNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_UNTNM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '20190705 CHG START
                SM_ShortCut.Show()
                '20190705 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_UNTNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_UNTNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 5
        End If
    End Sub

    Private Sub HD_UNTNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_UNTNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_UNTNM.ReadOnly = False
    End Sub

    Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
        Call Init_Prompt()
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
            '20190705 CHG START
            'If VB6.GetActiveControl().SelLength <= 1 Then
            If DirectCast(VB6.GetActiveControl(), TextBox).SelectionLength <= 1 Then
                '20190705 CHG EDN
                On Error Resume Next
                'UPGRADE_ISSUE: Control Text は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                My.Computer.Clipboard.SetText(VB6.GetActiveControl().Text)
                On Error GoTo 0
            Else
                On Error Resume Next
                'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '20190705 CHG START
                'My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
                My.Computer.Clipboard.SetText(DirectCast(VB6.GetActiveControl(), TextBox).SelectedText)
                '20190705 CHG END
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

    Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click 'Generated.
        Const CF_TEXT As Short = 1
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If PP_SSSMAIN.Mode <> Cn_Mode2 Then
            MN_SELECTCM.Enabled = True
        Else
            MN_SELECTCM.Enabled = False
        End If
        MN_ClearItm.Enabled = False
        If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 128 Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm.Enabled = True
        End If
        If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 8 And PP_SSSMAIN.Tx < 128 And PP_SSSMAIN.Mode <> Cn_Mode3 Then
            If (PP_SSSMAIN.Tx - 8) \ 8 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
            End If
        End If
        MN_Copy.Enabled = False
        If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 128 Then
            If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
                'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                If Not IsDBNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Copy.Enabled = True
            End If
        End If
        MN_Cut.Enabled = False
        If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 128 Then
            If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
                'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190705 CHG START
                'If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
                If DirectCast(AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx), TextBox).SelectionLength > 0 Then
                    '20190705 CHG END
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
        If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 128 Then
            If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
                'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetFormat はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                '20190705 CHG START
                'If My.Computer.Clipboard.GetFormat(CF_TEXT) Then
                If My.Computer.Clipboard.ContainsText(CF_TEXT) Then
                    '20190705 CHG END
                    If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste.Enabled = True
                End If
            End If
        End If
        MN_UnDoItem.Enabled = False
        If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 128 Then
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

    Public Sub MN_Hardcopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_HARDCOPY.Click 'Generated.
        Dim wk_Cursor As Short
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If SSSMAIN_Hardcopy_Getevent() Then
            wk_Cursor = AE_Hardcopy_SSSMAIN()
        End If
    End Sub

    Public Sub MN_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_NEXTCM.Click 'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
            Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
        End If
        If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
            Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
            PP_SSSMAIN.CursorSet = True
        Else
            If PP_SSSMAIN.Mode >= Cn_Mode3 Then
                wk_Int = AE_NextCm_SSSMAIN(True)
            Else
                Beep()
            End If
        End If
        Call AE_CursorInit_SSSMAIN()
    End Sub

    Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click 'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        MN_Slist.Enabled = False
        If False Then
        ElseIf PP_SSSMAIN.Tx = 1 Then
            If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
        End If
        If PP_SSSMAIN.Mode >= Cn_Mode3 Then
            MN_NEXTCM.Enabled = True
            MN_PREV.Enabled = True
        Else
            MN_NEXTCM.Enabled = False
            MN_PREV.Enabled = False
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
                If VB6.GetActiveControl().TabIndex >= 128 Then
                    'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                    '20190705 CHG START
                    'VB6.GetActiveControl().SelText = My.Computer.Clipboard.GetText()
                    DirectCast(VB6.GetActiveControl(), TextBox).SelectedText = My.Computer.Clipboard.GetText()
                    '20190705 CHG END
                Else
                    Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), VB6.GetActiveControl())
                End If
            End If
        End If
    End Sub

    Public Sub MN_Prev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_PREV.Click 'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
            Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
        End If
        If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
            Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
            PP_SSSMAIN.CursorSet = True
        Else
            If PP_SSSMAIN.Mode >= Cn_Mode3 Then
                wk_Int = AE_Prev_SSSMAIN(True)
            Else
                Beep()
            End If
        End If
        Call AE_CursorInit_SSSMAIN()
    End Sub

    Public Sub MN_SelectCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_SELECTCM.Click 'Generated.
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

    Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click 'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        Call AE_UnDoItem_SSSMAIN()
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
                Do While wk_ww < 8
                    Tx = 8 + 8 * De + wk_ww
                    AE_Controls(PP_SSSMAIN.CtB + Tx).Visible = AE_Controls(PP_SSSMAIN.CtB + 8 + wk_ww).Visible
                    wk_ww = wk_ww + 1
                Loop
                De = De + 1
                System.Windows.Forms.Application.DoEvents()
            Loop
            PP_SSSMAIN.MaskMode = False
            PP_SSSMAIN.Operable = True
            '20190711 dell start
            'wk_Cursor = AE_SelectCm_SSSMAIN(PP_SSSMAIN.Mode, True)
            'If wk_Cursor = Cn_CuCurrent Then
            '    PP_SSSMAIN.CloseCode = 0
            '    Call AE_EndCm_SSSMAIN()
            'Else
            '    Call AE_CursorSub_SSSMAIN(wk_Cursor)
            'End If
            '20190711 dell end
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
                Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
            Else
                PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
                wk_Bool = AE_CursorUp_SSSMAIN(128)
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
                wk_Bool = AE_CursorPrev_SSSMAIN(128)
            End If
        ElseIf (KEYCODE = System.Windows.Forms.Keys.Execute Or KEYCODE = System.Windows.Forms.Keys.Return) And Shift = 0 Then
        ElseIf KEYCODE = System.Windows.Forms.Keys.End And Shift = 0 Then
            PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
            If PP_SSSMAIN.Mode = Cn_Mode3 Then Call AE_Scrl_SSSMAIN(14, False)
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                If AE_CursorPrevDsp_SSSMAIN(128) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
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
            SM_FullPast.Enabled = False
            'UPGRADE_ISSUE: 定数 vbPopupMenuRightButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '20190705 CHG START
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            SM_ShortCut.Show()
            '20190705 CHG END
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
			SM_FullPast.Enabled = False
            'UPGRADE_ISSUE: 定数 vbPopupMenuRightButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
            '20190705 CHG START
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            SM_ShortCut.Show()
            '20190705 CHG END
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
    '20190705 ADD START
    'Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
    '    Call Ctl_Item_Click(btnF1)
    'End Sub

    'Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
    '    Call Ctl_Item_Click(btnF2)
    'End Sub

    'Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
    '    Call Ctl_Item_Click(btnF3)
    'End Sub

    'Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
    '    Call Ctl_Item_Click(btnF4)
    'End Sub

    'Private Sub btnF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF5.Click
    '    Call Ctl_Item_Click(btnF5)
    'End Sub

    'Private Sub btnF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF6.Click
    '    Call Ctl_Item_Click(btnF6)
    'End Sub

    'Private Sub btnF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF7.Click
    '    Call Ctl_Item_Click(btnF7)
    'End Sub

    'Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
    '    Call Ctl_Item_Click(btnF8)
    'End Sub

    'Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
    '    Call Ctl_Item_Click(btnF9)
    'End Sub

    'Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
    '    Call Ctl_Item_Click(btnF10)
    'End Sub

    'Private Sub btnF11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF11.Click
    '    Call Ctl_Item_Click(btnF11)
    'End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        PP_SSSMAIN.NeglectLostFocusCheck = True
        PP_SSSMAIN.CloseCode = 1
        Call AE_EndCm_SSSMAIN()
        PP_SSSMAIN.NeglectLostFocusCheck = False
        Call AE_CursorCurrent_SSSMAIN()
    End Sub
    Private Sub CS_HINCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_HINCD.Click 'Generated.
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
    Private Sub btnF5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF5.Click 'Generated.
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
        Call AE_Slist_SSSMAIN()
        PP_SSSMAIN.NeglectLostFocusCheck = False
        'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN()
    End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click 'Generated.
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

    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click 'Generated.
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

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click 'Generated.
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
            Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
        End If
        If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
            Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
            PP_SSSMAIN.CursorSet = True
        Else
            If PP_SSSMAIN.Mode >= Cn_Mode3 Then
                wk_Int = AE_Prev_SSSMAIN(True)
            Else
                Beep()
            End If
        End If
        PP_SSSMAIN.NeglectLostFocusCheck = False
        Call AE_CursorInit_SSSMAIN()
    End Sub
    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click 'Generated.
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
            Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
        End If
        If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
            Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
            PP_SSSMAIN.CursorSet = True
        Else
            If PP_SSSMAIN.Mode >= Cn_Mode3 Then
                wk_Int = AE_NextCm_SSSMAIN(True)
            Else
                Beep()
            End If
        End If
        PP_SSSMAIN.NeglectLostFocusCheck = False
        Call AE_CursorInit_SSSMAIN()
    End Sub
    '20190705 ADD END
End Class