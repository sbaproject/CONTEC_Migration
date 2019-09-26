Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
    'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
    '*** End Of Generated Declaration Section ****
    '2019/09/26 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '2019/09/26 ADD E N D

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
	
	Private Sub CS_BINCD_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(21).TypeA, 21) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(21)
			If PP_SSSMAIN.Tx <> 21 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_BINCD_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_BINCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_BINCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub CS_CHIIKI_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(19).TypeA, 19) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(19)
			If PP_SSSMAIN.Tx <> 19 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_CHIIKI_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_CHIIKI_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_CHIIKI_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub CS_DENNOA_Click() 'Generated.
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
	
	Private Sub CS_DENNOA_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_DENNOA_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_DENNOA_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub CS_GYOSHU_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(17).TypeA, 17) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(17)
			If PP_SSSMAIN.Tx <> 17 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_GYOSHU_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_GYOSHU_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_GYOSHU_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub CS_NHSCD_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(2).TypeA, 2) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(2)
			If PP_SSSMAIN.Tx <> 2 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_NHSCD_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_NHSCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_NHSCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub CS_NHSCLAID_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(26).TypeA, 26) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(26)
			If PP_SSSMAIN.Tx <> 26 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_NHSCLAID_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_NHSCLAID_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_NHSCLAID_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub CS_NHSCLBID_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(28).TypeA, 28) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(28)
			If PP_SSSMAIN.Tx <> 28 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_NHSCLBID_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_NHSCLBID_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_NHSCLBID_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
	End Sub
	
	Private Sub CS_NHSCLCID_Click() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_SaveTx As Short
		PP_SSSMAIN.ButtonClick = True
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(30).TypeA, 30) Then
			PP_SSSMAIN.SlistCall = True
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			Call AE_CursorMove_SSSMAIN(30)
			If PP_SSSMAIN.Tx <> 30 Then PP_SSSMAIN.SSCommand5Ajst = True
		Else
			Beep()
			Call AE_CursorCurrent_SSSMAIN()
		End If
		PP_SSSMAIN.CursorDirection = 0
	End Sub
	
	Private Sub CS_NHSCLCID_GotFocus() 'Generated.
		PP_SSSMAIN.ButtonClick = False
	End Sub
	
	Private Sub CS_NHSCLCID_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short) 'Generated.
		If PP_SSSMAIN.ButtonClick = False Then
			If KEYCODE = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
		End If
	End Sub
	
	Private Sub CS_NHSCLCID_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
		If Not PP_SSSMAIN.ButtonClick Then
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.SSCommand5Ajst = False
		End If
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
        '2019/09/23 ADD START
        FORM_LOAD_FLG = True
        '2019/09/23 ADD E N D
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
        AE_Title = "納入先マスタ登録／訂正                   "
        '初画面表示の性能チューニング用 ----------
        'Dim StartTime
        '   AE_MsgBox "Start Point", vbInformation, AE_Title$
        '   StartTime = Timer
        '-----------------------------------------
        With PP_SSSMAIN
            .FormWidth = 11715
            .FormHeight = 7890
            .MaxDe = -1
            .MaxDsp = -1
            .HeadN = 35
            .BodyN = 0
            .BodyV = 0
            .MaxEDe = -1
            .MaxEDsp = -1
            .EBodyN = 0
            .EBodyV = 0
            .TailN = 0
            .BodyPx = 35
            .EBodyPx = 35
            .TailPx = 35
            .PrpC = 35
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
                AE_CtB = AE_CtB + 35
                ReDim Preserve AE_Controls(.CtB + 34)
                .MainFormFile = "NHSMR52.FRM"
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
            HD_FRNKB.Text = ""
            HD_DENNOA.Text = ""
            HD_NHSCD.Text = ""
            HD_NHSNMA.Text = ""
            HD_NHSNMB.Text = ""
            HD_NHSNK.Text = ""
            HD_NHSRN.Text = ""
            HD_NHSRNNK.Text = ""
            HD_NHSZP.Text = ""
            HD_NHSADA.Text = ""
            HD_NHSADB.Text = ""
            HD_NHSADC.Text = ""
            HD_NHSTL.Text = ""
            HD_NHSFX.Text = ""
            HD_NHSCTANM.Text = ""
            HD_NHSBOSNM.Text = ""
            HD_NHSMLAD.Text = ""
            HD_GYOSHU.Text = ""
            HD_GYOSHURN.Text = ""
            HD_CHIIKI.Text = ""
            HD_CHIIKIRN.Text = ""
            HD_BINCD.Text = ""
            HD_BINRN.Text = ""
            HD_NGRPCD.Text = ""
            HD_OLDNHSCD.Text = ""
            HD_OLNGRPCD.Text = ""
            HD_NHSCLAID.Text = ""
            HD_NHSCLANM.Text = ""
            HD_NHSCLBID.Text = ""
            HD_NHSCLBNM.Text = ""
            HD_NHSCLCID.Text = ""
            HD_NHSCLCNM.Text = ""
            HD_NHSNMMKB.Text = ""
            HD_OPEID.Text = ""
            HD_OPENM.Text = ""
            HD_FRNKB.TabIndex = 0
            AE_Controls(.CtB + 0) = HD_FRNKB
            HD_DENNOA.TabIndex = 1
            AE_Controls(.CtB + 1) = HD_DENNOA
            HD_NHSCD.TabIndex = 2
            AE_Controls(.CtB + 2) = HD_NHSCD
            HD_NHSNMA.TabIndex = 3
            AE_Controls(.CtB + 3) = HD_NHSNMA
            HD_NHSNMB.TabIndex = 4
            AE_Controls(.CtB + 4) = HD_NHSNMB
            HD_NHSNK.TabIndex = 5
            AE_Controls(.CtB + 5) = HD_NHSNK
            HD_NHSRN.TabIndex = 6
            AE_Controls(.CtB + 6) = HD_NHSRN
            HD_NHSRNNK.TabIndex = 7
            AE_Controls(.CtB + 7) = HD_NHSRNNK
            HD_NHSZP.TabIndex = 8
            AE_Controls(.CtB + 8) = HD_NHSZP
            HD_NHSADA.TabIndex = 9
            AE_Controls(.CtB + 9) = HD_NHSADA
            HD_NHSADB.TabIndex = 10
            AE_Controls(.CtB + 10) = HD_NHSADB
            HD_NHSADC.TabIndex = 11
            AE_Controls(.CtB + 11) = HD_NHSADC
            HD_NHSTL.TabIndex = 12
            AE_Controls(.CtB + 12) = HD_NHSTL
            HD_NHSFX.TabIndex = 13
            AE_Controls(.CtB + 13) = HD_NHSFX
            HD_NHSCTANM.TabIndex = 14
            AE_Controls(.CtB + 14) = HD_NHSCTANM
            HD_NHSBOSNM.TabIndex = 15
            AE_Controls(.CtB + 15) = HD_NHSBOSNM
            HD_NHSMLAD.TabIndex = 16
            AE_Controls(.CtB + 16) = HD_NHSMLAD
            HD_GYOSHU.TabIndex = 17
            AE_Controls(.CtB + 17) = HD_GYOSHU
            HD_GYOSHURN.TabIndex = 18
            AE_Controls(.CtB + 18) = HD_GYOSHURN
            HD_CHIIKI.TabIndex = 19
            AE_Controls(.CtB + 19) = HD_CHIIKI
            HD_CHIIKIRN.TabIndex = 20
            AE_Controls(.CtB + 20) = HD_CHIIKIRN
            HD_BINCD.TabIndex = 21
            AE_Controls(.CtB + 21) = HD_BINCD
            HD_BINRN.TabIndex = 22
            AE_Controls(.CtB + 22) = HD_BINRN
            HD_NGRPCD.TabIndex = 23
            AE_Controls(.CtB + 23) = HD_NGRPCD
            HD_OLDNHSCD.TabIndex = 24
            AE_Controls(.CtB + 24) = HD_OLDNHSCD
            HD_OLNGRPCD.TabIndex = 25
            AE_Controls(.CtB + 25) = HD_OLNGRPCD
            HD_NHSCLAID.TabIndex = 26
            AE_Controls(.CtB + 26) = HD_NHSCLAID
            HD_NHSCLANM.TabIndex = 27
            AE_Controls(.CtB + 27) = HD_NHSCLANM
            HD_NHSCLBID.TabIndex = 28
            AE_Controls(.CtB + 28) = HD_NHSCLBID
            HD_NHSCLBNM.TabIndex = 29
            AE_Controls(.CtB + 29) = HD_NHSCLBNM
            HD_NHSCLCID.TabIndex = 30
            AE_Controls(.CtB + 30) = HD_NHSCLCID
            HD_NHSCLCNM.TabIndex = 31
            AE_Controls(.CtB + 31) = HD_NHSCLCNM
            HD_NHSNMMKB.TabIndex = 32
            AE_Controls(.CtB + 32) = HD_NHSNMMKB
            HD_OPEID.TabIndex = 33
            AE_Controls(.CtB + 33) = HD_OPEID
            HD_OPENM.TabIndex = 34
            AE_Controls(.CtB + 34) = HD_OPENM
            TX_CursorRest.TabIndex = 35
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
            .NrBodyTx = 35
            .ScrlMaxL = 1
            .MaxEDspC = 0
            .NrEBodyTx = 35
            .EScrlMaxL = 1
            Call AE_TabStop_SSSMAIN(0, 34, True)
            TX_CursorRest.TabStop = False
            TX_Mode.TabStop = False
            TX_Message.TabStop = False
            TX_Message.Text = ""
            '2019/09/26　仮
            'wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
            '2019/09/26　仮
            Call AE_WindowProcSet_SSSMAIN()
            '2019/09/26　仮
            'ReleaseTabCapture(0)
            'SetTabCapture(Me.Handle.ToInt32)
            '2019/09/26　仮
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
                '2019/09/26 CHG START
                'Cancel = True : Exit Sub
                eventSender.Cancel = True
                Exit Sub
                '2019/09/26 CHG E N D
            End If
		Else
			If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then
                'UPGRADE_ISSUE: Event パラメータ Cancel はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' をクリックしてください。
                '2019/09/26 CHG START
                'Cancel = True : Exit Sub
                eventSender.Cancel = True
                Exit Sub
                '2019/09/26 CHG E N D
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
            '2019/09/26 CHG START
            'Cancel = True
            eventSender.Cancel = True
            '2019/09/26 CHG E N D
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
	
	'UPGRADE_WARNING: イベント HD_BINCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_BINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD, FORM_LOAD_FLG) Then
                    '2019/09/26 CHG END
                    PP_SSSMAIN.CursorDirection = Cn_Direction1
                    PP_SSSMAIN.CursorDest = Cn_Dest9
                    Call AE_Check_SSSMAIN_BINCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
                End If
            End If
    End Sub
	
	Private Sub HD_BINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 21
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 21
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD)
		HD_BINCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト BINCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = BINCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(21).CuVal))
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
				CP_SSSMAIN(21).TpStr = wk_Slisted
				CP_SSSMAIN(21).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_BINCD.Text = wk_Slisted
				Call AE_Check_SSSMAIN_BINCD(AE_Val3(CP_SSSMAIN(21), HD_BINCD.Text), Cn_Status6, True, True)
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_BINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BINCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_BINCD, KEYCODE, Shift, CP_SSSMAIN(21).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BINCD(AE_Val3(CP_SSSMAIN(21), HD_BINCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(21)
		End If
	End Sub
	
	Private Sub HD_BINCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BINCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 21 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_BINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(21).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BINCD(AE_Val3(CP_SSSMAIN(21), HD_BINCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_BINCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_BINCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(21), CL_SSSMAIN(21), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_BINCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BINCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BINCD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_BINCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_BINCD.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 21
		End If
	End Sub
	
	Private Sub HD_BINCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BINCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_BINCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_BINRN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_BINRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINRN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(22), HD_BINRN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(22), HD_BINRN, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_BINRN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_BINRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINRN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 22
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 22
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(22), HD_BINRN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(22), HD_BINRN)
		HD_BINRN.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_BINRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BINRN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_BINRN, KEYCODE, Shift, CP_SSSMAIN(22).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BINRN(AE_Val3(CP_SSSMAIN(22), HD_BINRN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(22)
		End If
	End Sub
	
	Private Sub HD_BINRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BINRN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 22 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(22), HD_BINRN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_BINRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINRN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(22).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BINRN(AE_Val3(CP_SSSMAIN(22), HD_BINRN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_BINRN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_BINRN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(22), CL_SSSMAIN(22), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_BINRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BINRN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BINRN)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。                
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_BINRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_BINRN.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 22
		End If
	End Sub
	
	Private Sub HD_BINRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BINRN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_BINRN.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_CHIIKI.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_CHIIKI_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CHIIKI.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_CHIIKI(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_CHIIKI_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CHIIKI.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 19
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 19
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI)
		HD_CHIIKI.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト CHIIKI_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = CHIIKI_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(19).CuVal))
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
				CP_SSSMAIN(19).TpStr = wk_Slisted
				CP_SSSMAIN(19).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_CHIIKI.Text = wk_Slisted
				Call AE_Check_SSSMAIN_CHIIKI(AE_Val3(CP_SSSMAIN(19), HD_CHIIKI.Text), Cn_Status6, True, True)
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_CHIIKI_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_CHIIKI.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_CHIIKI, KEYCODE, Shift, CP_SSSMAIN(19).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_CHIIKI(AE_Val3(CP_SSSMAIN(19), HD_CHIIKI.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(19)
		End If
	End Sub
	
	Private Sub HD_CHIIKI_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_CHIIKI.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 19 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_CHIIKI_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CHIIKI.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(19).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_CHIIKI(AE_Val3(CP_SSSMAIN(19), HD_CHIIKI.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_CHIIKI.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_CHIIKI.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(19), CL_SSSMAIN(19), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_CHIIKI_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_CHIIKI.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_CHIIKI)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_CHIIKI.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_CHIIKI.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 19
		End If
	End Sub
	
	Private Sub HD_CHIIKI_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_CHIIKI.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_CHIIKI.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_CHIIKIRN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_CHIIKIRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CHIIKIRN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(20), HD_CHIIKIRN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(20), HD_CHIIKIRN, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_CHIIKIRN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_CHIIKIRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CHIIKIRN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 20
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 20
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(20), HD_CHIIKIRN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(20), HD_CHIIKIRN)
		HD_CHIIKIRN.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_CHIIKIRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_CHIIKIRN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_CHIIKIRN, KEYCODE, Shift, CP_SSSMAIN(20).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_CHIIKIRN(AE_Val3(CP_SSSMAIN(20), HD_CHIIKIRN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(20)
		End If
	End Sub
	
	Private Sub HD_CHIIKIRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_CHIIKIRN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 20 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(20), HD_CHIIKIRN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_CHIIKIRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CHIIKIRN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(20).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_CHIIKIRN(AE_Val3(CP_SSSMAIN(20), HD_CHIIKIRN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_CHIIKIRN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_CHIIKIRN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(20), CL_SSSMAIN(20), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_CHIIKIRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_CHIIKIRN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_CHIIKIRN)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_CHIIKIRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_CHIIKIRN.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 20
		End If
	End Sub
	
	Private Sub HD_CHIIKIRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_CHIIKIRN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_CHIIKIRN.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_DENNOA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_DENNOA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DENNOA.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA, FORM_LOAD_FLG) Then
                '2019/09/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_DENNOA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_DENNOA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DENNOA.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 1
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 1
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		'UPGRADE_WARNING: オブジェクト DENNOA_Skip(AE_Controls(PP_SSSMAIN.CtB + 1)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If DENNOA_Skip(AE_Controls(PP_SSSMAIN.CtB + 1)) Then
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
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA)
		HD_DENNOA.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト DENNOA_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = DENNOA_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal))
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
				HD_DENNOA.Text = wk_Slisted
				Call AE_Check_SSSMAIN_DENNOA(AE_Val3(CP_SSSMAIN(1), HD_DENNOA.Text), Cn_Status6, True, True)
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_DENNOA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DENNOA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_DENNOA, KEYCODE, Shift, CP_SSSMAIN(1).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_DENNOA(AE_Val3(CP_SSSMAIN(1), HD_DENNOA.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(1)
		End If
	End Sub
	
	Private Sub HD_DENNOA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_DENNOA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 1 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_DENNOA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DENNOA.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_DENNOA(AE_Val3(CP_SSSMAIN(1), HD_DENNOA.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_DENNOA.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_DENNOA.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_DENNOA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DENNOA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_DENNOA)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_DENNOA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_DENNOA.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 1
		End If
	End Sub
	
	Private Sub HD_DENNOA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DENNOA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_DENNOA.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_FRNKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_FRNKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_FRNKB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB, FORM_LOAD_FLG) Then
                '2019/09/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_FRNKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_FRNKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_FRNKB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 0
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 0
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB)
		HD_FRNKB.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_FRNKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_FRNKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_FRNKB, KEYCODE, Shift, CP_SSSMAIN(0).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_FRNKB(AE_Val3(CP_SSSMAIN(0), HD_FRNKB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(0)
		End If
	End Sub
	
	Private Sub HD_FRNKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_FRNKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 0 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_FRNKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_FRNKB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_FRNKB(AE_Val3(CP_SSSMAIN(0), HD_FRNKB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_FRNKB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_FRNKB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_FRNKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_FRNKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_FRNKB)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_FRNKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_FRNKB.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 0
		End If
	End Sub
	
	Private Sub HD_FRNKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_FRNKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_FRNKB.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_GYOSHU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_GYOSHU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_GYOSHU.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU, FORM_LOAD_FLG) Then
                '2019/09/26 CHG E N D
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_GYOSHU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_GYOSHU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_GYOSHU.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 17
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 17
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU)
		HD_GYOSHU.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト GYOSHU_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = GYOSHU_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(17).CuVal))
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
				CP_SSSMAIN(17).TpStr = wk_Slisted
				CP_SSSMAIN(17).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_GYOSHU.Text = wk_Slisted
				Call AE_Check_SSSMAIN_GYOSHU(AE_Val3(CP_SSSMAIN(17), HD_GYOSHU.Text), Cn_Status6, True, True)
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_GYOSHU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_GYOSHU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_GYOSHU, KEYCODE, Shift, CP_SSSMAIN(17).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_GYOSHU(AE_Val3(CP_SSSMAIN(17), HD_GYOSHU.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(17)
		End If
	End Sub
	
	Private Sub HD_GYOSHU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_GYOSHU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 17 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_GYOSHU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_GYOSHU.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(17).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_GYOSHU(AE_Val3(CP_SSSMAIN(17), HD_GYOSHU.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_GYOSHU.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_GYOSHU.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(17), CL_SSSMAIN(17), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_GYOSHU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_GYOSHU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_GYOSHU)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_GYOSHU.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_GYOSHU.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 17
		End If
	End Sub
	
	Private Sub HD_GYOSHU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_GYOSHU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_GYOSHU.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_GYOSHURN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_GYOSHURN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_GYOSHURN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(18), HD_GYOSHURN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(18), HD_GYOSHURN, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_GYOSHURN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_GYOSHURN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_GYOSHURN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 18
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 18
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(18), HD_GYOSHURN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(18), HD_GYOSHURN)
		HD_GYOSHURN.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_GYOSHURN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_GYOSHURN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_GYOSHURN, KEYCODE, Shift, CP_SSSMAIN(18).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_GYOSHURN(AE_Val3(CP_SSSMAIN(18), HD_GYOSHURN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(18)
		End If
	End Sub
	
	Private Sub HD_GYOSHURN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_GYOSHURN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 18 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(18), HD_GYOSHURN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_GYOSHURN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_GYOSHURN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(18).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_GYOSHURN(AE_Val3(CP_SSSMAIN(18), HD_GYOSHURN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_GYOSHURN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_GYOSHURN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(18), CL_SSSMAIN(18), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_GYOSHURN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_GYOSHURN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_GYOSHURN)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_GYOSHURN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_GYOSHURN.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 18
		End If
	End Sub
	
	Private Sub HD_GYOSHURN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_GYOSHURN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_GYOSHURN.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NGRPCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NGRPCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NGRPCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG END
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NGRPCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NGRPCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NGRPCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 23
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 23
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD)
		HD_NGRPCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NGRPCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NGRPCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NGRPCD, KEYCODE, Shift, CP_SSSMAIN(23).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NGRPCD(AE_Val3(CP_SSSMAIN(23), HD_NGRPCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(23)
		End If
	End Sub
	
	Private Sub HD_NGRPCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NGRPCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 23 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NGRPCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NGRPCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(23).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NGRPCD(AE_Val3(CP_SSSMAIN(23), HD_NGRPCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NGRPCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NGRPCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(23), CL_SSSMAIN(23), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NGRPCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NGRPCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NGRPCD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NGRPCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NGRPCD.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 23
		End If
	End Sub
	
	Private Sub HD_NGRPCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NGRPCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NGRPCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSADA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSADA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSADA.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_NHSADA) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_NHSADA, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSADA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSADA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSADA.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 9
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 9
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(9), HD_NHSADA)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(9), HD_NHSADA)
		HD_NHSADA.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSADA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSADA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSADA, KEYCODE, Shift, CP_SSSMAIN(9).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADA(AE_Val3(CP_SSSMAIN(9), HD_NHSADA.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(9)
		End If
	End Sub
	
	Private Sub HD_NHSADA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSADA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 9 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(9), HD_NHSADA, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSADA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSADA.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(9).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADA(AE_Val3(CP_SSSMAIN(9), HD_NHSADA.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSADA.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSADA.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSADA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSADA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSADA)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSADA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSADA.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 9
		End If
	End Sub
	
	Private Sub HD_NHSADA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSADA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSADA.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSADB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSADB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSADB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_NHSADB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_NHSADB, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSADB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSADB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSADB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 10
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 10
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(10), HD_NHSADB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(10), HD_NHSADB)
		HD_NHSADB.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSADB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSADB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSADB, KEYCODE, Shift, CP_SSSMAIN(10).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADB(AE_Val3(CP_SSSMAIN(10), HD_NHSADB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(10)
		End If
	End Sub
	
	Private Sub HD_NHSADB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSADB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 10 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(10), HD_NHSADB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSADB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSADB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(10).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADB(AE_Val3(CP_SSSMAIN(10), HD_NHSADB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSADB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSADB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(10), CL_SSSMAIN(10), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSADB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSADB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSADB)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSADB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSADB.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 10
		End If
	End Sub
	
	Private Sub HD_NHSADB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSADB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSADB.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSADC.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSADC_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSADC.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_NHSADC) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_NHSADC, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSADC(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSADC_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSADC.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 11
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 11
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(11), HD_NHSADC)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(11), HD_NHSADC)
		HD_NHSADC.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSADC_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSADC.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSADC, KEYCODE, Shift, CP_SSSMAIN(11).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADC(AE_Val3(CP_SSSMAIN(11), HD_NHSADC.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(11)
		End If
	End Sub
	
	Private Sub HD_NHSADC_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSADC.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 11 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(11), HD_NHSADC, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSADC_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSADC.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(11).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADC(AE_Val3(CP_SSSMAIN(11), HD_NHSADC.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSADC.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSADC.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(11), CL_SSSMAIN(11), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSADC_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSADC.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSADC)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSADC.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSADC.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 11
		End If
	End Sub
	
	Private Sub HD_NHSADC_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSADC.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSADC.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSBOSNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSBOSNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSBOSNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(15), HD_NHSBOSNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(15), HD_NHSBOSNM, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSBOSNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSBOSNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSBOSNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 15
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 15
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(15), HD_NHSBOSNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(15), HD_NHSBOSNM)
		HD_NHSBOSNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSBOSNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSBOSNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSBOSNM, KEYCODE, Shift, CP_SSSMAIN(15).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSBOSNM(AE_Val3(CP_SSSMAIN(15), HD_NHSBOSNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(15)
		End If
	End Sub
	
	Private Sub HD_NHSBOSNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSBOSNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 15 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(15), HD_NHSBOSNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSBOSNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSBOSNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(15).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSBOSNM(AE_Val3(CP_SSSMAIN(15), HD_NHSBOSNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSBOSNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSBOSNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(15), CL_SSSMAIN(15), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSBOSNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSBOSNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSBOSNM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSBOSNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSBOSNM.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 15
		End If
	End Sub
	
	Private Sub HD_NHSBOSNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSBOSNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSBOSNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 2
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 2
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD)
		HD_NHSCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト NHSCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = NHSCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(2).CuVal))
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
				CP_SSSMAIN(2).TpStr = wk_Slisted
				CP_SSSMAIN(2).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_NHSCD.Text = wk_Slisted
				Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(2), HD_NHSCD.Text), Cn_Status6, True, True)
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_NHSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSCD, KEYCODE, Shift, CP_SSSMAIN(2).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(2), HD_NHSCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(2)
		End If
	End Sub
	
	Private Sub HD_NHSCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 2 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(2), HD_NHSCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSCD.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 2
		End If
	End Sub
	
	Private Sub HD_NHSCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSCLAID.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSCLAID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLAID.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSCLAID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSCLAID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLAID.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 26
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 26
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID)
		HD_NHSCLAID.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト NHSCLAID_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = NHSCLAID_Slist(PP_SSSMAIN)
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
				CP_SSSMAIN(26).TpStr = wk_Slisted
				CP_SSSMAIN(26).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_NHSCLAID.Text = wk_Slisted
				Call AE_Check_SSSMAIN_NHSCLAID(AE_Val3(CP_SSSMAIN(26), HD_NHSCLAID.Text), Cn_Status6, True, True)
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_NHSCLAID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCLAID.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSCLAID, KEYCODE, Shift, CP_SSSMAIN(26).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLAID(AE_Val3(CP_SSSMAIN(26), HD_NHSCLAID.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(26)
		End If
	End Sub
	
	Private Sub HD_NHSCLAID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCLAID.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 26 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSCLAID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLAID.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(26).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLAID(AE_Val3(CP_SSSMAIN(26), HD_NHSCLAID.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSCLAID.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSCLAID.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(26), CL_SSSMAIN(26), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSCLAID_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLAID.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLAID)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSCLAID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSCLAID.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 26
		End If
	End Sub
	
	Private Sub HD_NHSCLAID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLAID.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSCLAID.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSCLANM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSCLANM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLANM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(27), HD_NHSCLANM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(27), HD_NHSCLANM, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSCLANM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSCLANM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLANM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 27
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 27
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(27), HD_NHSCLANM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(27), HD_NHSCLANM)
		HD_NHSCLANM.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSCLANM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCLANM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSCLANM, KEYCODE, Shift, CP_SSSMAIN(27).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLANM(AE_Val3(CP_SSSMAIN(27), HD_NHSCLANM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(27)
		End If
	End Sub
	
	Private Sub HD_NHSCLANM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCLANM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 27 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(27), HD_NHSCLANM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSCLANM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLANM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(27).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLANM(AE_Val3(CP_SSSMAIN(27), HD_NHSCLANM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSCLANM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSCLANM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(27), CL_SSSMAIN(27), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSCLANM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLANM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLANM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSCLANM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSCLANM.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 27
		End If
	End Sub
	
	Private Sub HD_NHSCLANM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLANM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSCLANM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSCLBID.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSCLBID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLBID.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSCLBID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSCLBID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLBID.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 28
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 28
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID)
		HD_NHSCLBID.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト NHSCLBID_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = NHSCLBID_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(26).CuVal))
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
				CP_SSSMAIN(28).TpStr = wk_Slisted
				CP_SSSMAIN(28).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_NHSCLBID.Text = wk_Slisted
				Call AE_Check_SSSMAIN_NHSCLBID(AE_Val3(CP_SSSMAIN(28), HD_NHSCLBID.Text), Cn_Status6, True, True)
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_NHSCLBID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCLBID.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSCLBID, KEYCODE, Shift, CP_SSSMAIN(28).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLBID(AE_Val3(CP_SSSMAIN(28), HD_NHSCLBID.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(28)
		End If
	End Sub
	
	Private Sub HD_NHSCLBID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCLBID.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 28 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSCLBID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLBID.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(28).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLBID(AE_Val3(CP_SSSMAIN(28), HD_NHSCLBID.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSCLBID.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSCLBID.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(28), CL_SSSMAIN(28), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSCLBID_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLBID.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLBID)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSCLBID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSCLBID.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 28
		End If
	End Sub
	
	Private Sub HD_NHSCLBID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLBID.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSCLBID.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSCLBNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSCLBNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLBNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(29), HD_NHSCLBNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(29), HD_NHSCLBNM, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSCLBNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSCLBNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLBNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 29
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 29
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(29), HD_NHSCLBNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(29), HD_NHSCLBNM)
		HD_NHSCLBNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSCLBNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCLBNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSCLBNM, KEYCODE, Shift, CP_SSSMAIN(29).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLBNM(AE_Val3(CP_SSSMAIN(29), HD_NHSCLBNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(29)
		End If
	End Sub
	
	Private Sub HD_NHSCLBNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCLBNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 29 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(29), HD_NHSCLBNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSCLBNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLBNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(29).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLBNM(AE_Val3(CP_SSSMAIN(29), HD_NHSCLBNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSCLBNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSCLBNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(29), CL_SSSMAIN(29), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSCLBNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLBNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLBNM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSCLBNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSCLBNM.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 29
		End If
	End Sub
	
	Private Sub HD_NHSCLBNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLBNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSCLBNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSCLCID.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSCLCID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLCID.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSCLCID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSCLCID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLCID.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		Dim wk_Slisted As Object
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 30
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 30
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID)
		HD_NHSCLCID.BackColor = SSSMSG_BAS.Cn_ClBrightON
		If PP_SSSMAIN.SlistCall Then
			PP_SSSMAIN.SlistCall = False
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
			'UPGRADE_WARNING: オブジェクト NHSCLCID_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = NHSCLCID_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(26).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(28).CuVal))
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
				CP_SSSMAIN(30).TpStr = wk_Slisted
				CP_SSSMAIN(30).CIn = Cn_ChrInput
				'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HD_NHSCLCID.Text = wk_Slisted
				Call AE_Check_SSSMAIN_NHSCLCID(AE_Val3(CP_SSSMAIN(30), HD_NHSCLCID.Text), Cn_Status6, True, True)
			End If
		End If
		CM_SLIST.Enabled = True
	End Sub
	
	Private Sub HD_NHSCLCID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCLCID.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSCLCID, KEYCODE, Shift, CP_SSSMAIN(30).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLCID(AE_Val3(CP_SSSMAIN(30), HD_NHSCLCID.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(30)
		End If
	End Sub
	
	Private Sub HD_NHSCLCID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCLCID.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 30 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSCLCID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLCID.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(30).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLCID(AE_Val3(CP_SSSMAIN(30), HD_NHSCLCID.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSCLCID.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSCLCID.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(30), CL_SSSMAIN(30), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSCLCID_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLCID.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLCID)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSCLCID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSCLCID.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 30
		End If
	End Sub
	
	Private Sub HD_NHSCLCID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLCID.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSCLCID.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSCLCNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSCLCNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLCNM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(31), HD_NHSCLCNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(31), HD_NHSCLCNM, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSCLCNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSCLCNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLCNM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 31
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 31
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(31), HD_NHSCLCNM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(31), HD_NHSCLCNM)
		HD_NHSCLCNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSCLCNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCLCNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSCLCNM, KEYCODE, Shift, CP_SSSMAIN(31).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLCNM(AE_Val3(CP_SSSMAIN(31), HD_NHSCLCNM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(31)
		End If
	End Sub
	
	Private Sub HD_NHSCLCNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCLCNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 31 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(31), HD_NHSCLCNM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSCLCNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCLCNM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(31).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLCNM(AE_Val3(CP_SSSMAIN(31), HD_NHSCLCNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSCLCNM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSCLCNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(31), CL_SSSMAIN(31), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSCLCNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLCNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLCNM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSCLCNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSCLCNM.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 31
		End If
	End Sub
	
	Private Sub HD_NHSCLCNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCLCNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSCLCNM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSCTANM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSCTANM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCTANM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(14), HD_NHSCTANM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(14), HD_NHSCTANM, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSCTANM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSCTANM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCTANM.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 14
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 14
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(14), HD_NHSCTANM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(14), HD_NHSCTANM)
		HD_NHSCTANM.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSCTANM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCTANM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSCTANM, KEYCODE, Shift, CP_SSSMAIN(14).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCTANM(AE_Val3(CP_SSSMAIN(14), HD_NHSCTANM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(14)
		End If
	End Sub
	
	Private Sub HD_NHSCTANM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCTANM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 14 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(14), HD_NHSCTANM, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSCTANM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCTANM.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(14).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCTANM(AE_Val3(CP_SSSMAIN(14), HD_NHSCTANM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSCTANM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSCTANM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(14), CL_SSSMAIN(14), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSCTANM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCTANM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCTANM)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSCTANM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSCTANM.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 14
		End If
	End Sub
	
	Private Sub HD_NHSCTANM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCTANM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSCTANM.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSFX.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSFX_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSFX.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSFX(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSFX_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSFX.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 13
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 13
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX)
		HD_NHSFX.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSFX_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSFX.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSFX, KEYCODE, Shift, CP_SSSMAIN(13).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSFX(AE_Val3(CP_SSSMAIN(13), HD_NHSFX.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(13)
		End If
	End Sub
	
	Private Sub HD_NHSFX_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSFX.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 13 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSFX_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSFX.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(13).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSFX(AE_Val3(CP_SSSMAIN(13), HD_NHSFX.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSFX.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSFX.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(13), CL_SSSMAIN(13), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSFX_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSFX.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSFX)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSFX.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSFX.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 13
		End If
	End Sub
	
	Private Sub HD_NHSFX_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSFX.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSFX.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSMLAD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSMLAD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSMLAD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSMLAD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSMLAD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSMLAD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 16
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 16
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD)
		HD_NHSMLAD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSMLAD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSMLAD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSMLAD, KEYCODE, Shift, CP_SSSMAIN(16).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSMLAD(AE_Val3(CP_SSSMAIN(16), HD_NHSMLAD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(16)
		End If
	End Sub
	
	Private Sub HD_NHSMLAD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSMLAD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 16 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSMLAD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSMLAD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(16).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSMLAD(AE_Val3(CP_SSSMAIN(16), HD_NHSMLAD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSMLAD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSMLAD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(16), CL_SSSMAIN(16), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSMLAD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSMLAD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSMLAD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSMLAD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSMLAD.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 16
		End If
	End Sub
	
	Private Sub HD_NHSMLAD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSMLAD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSMLAD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSNK.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSNK_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNK.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_NHSNK) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_NHSNK, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSNK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSNK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNK.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 5
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 5
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_NHSNK)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_NHSNK)
		HD_NHSNK.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSNK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSNK.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSNK, KEYCODE, Shift, CP_SSSMAIN(5).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNK(AE_Val3(CP_SSSMAIN(5), HD_NHSNK.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(5)
		End If
	End Sub
	
	Private Sub HD_NHSNK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSNK.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 5 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_NHSNK, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSNK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNK.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNK(AE_Val3(CP_SSSMAIN(5), HD_NHSNK.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSNK.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSNK.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSNK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNK.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSNK)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSNK.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSNK.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 5
		End If
	End Sub
	
	Private Sub HD_NHSNK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNK.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSNK.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSNMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMA.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_NHSNMA) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_NHSNMA, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSNMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMA.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 3
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 3
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_NHSNMA)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_NHSNMA)
		HD_NHSNMA.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSNMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSNMA, KEYCODE, Shift, CP_SSSMAIN(3).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMA(AE_Val3(CP_SSSMAIN(3), HD_NHSNMA.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(3)
		End If
	End Sub
	
	Private Sub HD_NHSNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSNMA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 3 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_NHSNMA, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMA.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMA(AE_Val3(CP_SSSMAIN(3), HD_NHSNMA.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSNMA.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSNMA.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSNMA)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSNMA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSNMA.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 3
		End If
	End Sub
	
	Private Sub HD_NHSNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSNMA.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSNMB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_NHSNMB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_NHSNMB, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSNMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 4
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 4
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_NHSNMB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_NHSNMB)
		HD_NHSNMB.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSNMB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSNMB, KEYCODE, Shift, CP_SSSMAIN(4).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMB(AE_Val3(CP_SSSMAIN(4), HD_NHSNMB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(4)
		End If
	End Sub
	
	Private Sub HD_NHSNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSNMB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 4 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_NHSNMB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMB(AE_Val3(CP_SSSMAIN(4), HD_NHSNMB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSNMB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSNMB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSNMB)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSNMB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSNMB.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 4
		End If
	End Sub
	
	Private Sub HD_NHSNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSNMB.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSNMMKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSNMMKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMMKB.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSNMMKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSNMMKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMMKB.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 32
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 32
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB)
		HD_NHSNMMKB.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSNMMKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSNMMKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSNMMKB, KEYCODE, Shift, CP_SSSMAIN(32).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMMKB(AE_Val3(CP_SSSMAIN(32), HD_NHSNMMKB.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(32)
		End If
	End Sub
	
	Private Sub HD_NHSNMMKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSNMMKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 32 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSNMMKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMMKB.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(32).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMMKB(AE_Val3(CP_SSSMAIN(32), HD_NHSNMMKB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSNMMKB.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSNMMKB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(32), CL_SSSMAIN(32), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSNMMKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMMKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSNMMKB)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSNMMKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSNMMKB.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 32
		End If
	End Sub
	
	Private Sub HD_NHSNMMKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMMKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSNMMKB.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSRN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSRN.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_NHSRN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_NHSRN, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSRN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSRN.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 6
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 6
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_NHSRN)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_NHSRN)
		HD_NHSRN.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSRN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSRN, KEYCODE, Shift, CP_SSSMAIN(6).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSRN(AE_Val3(CP_SSSMAIN(6), HD_NHSRN.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(6)
		End If
	End Sub
	
	Private Sub HD_NHSRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSRN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 6 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_NHSRN, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSRN.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSRN(AE_Val3(CP_SSSMAIN(6), HD_NHSRN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSRN.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSRN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSRN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSRN)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSRN.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 6
		End If
	End Sub
	
	Private Sub HD_NHSRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSRN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSRN.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSRNNK.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSRNNK_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSRNNK.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_NHSRNNK) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_NHSRNNK, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSRNNK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSRNNK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSRNNK.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 7
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 7
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(7), HD_NHSRNNK)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(7), HD_NHSRNNK)
		HD_NHSRNNK.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSRNNK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSRNNK.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSRNNK, KEYCODE, Shift, CP_SSSMAIN(7).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSRNNK(AE_Val3(CP_SSSMAIN(7), HD_NHSRNNK.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(7)
		End If
	End Sub
	
	Private Sub HD_NHSRNNK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSRNNK.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 7 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(7), HD_NHSRNNK, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSRNNK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSRNNK.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(7).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSRNNK(AE_Val3(CP_SSSMAIN(7), HD_NHSRNNK.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSRNNK.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSRNNK.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSRNNK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSRNNK.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSRNNK)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSRNNK.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSRNNK.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 7
		End If
	End Sub
	
	Private Sub HD_NHSRNNK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSRNNK.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSRNNK.ReadOnly = False
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSTL.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSTL_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSTL.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSTL(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSTL_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSTL.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 12
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 12
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL)
		HD_NHSTL.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSTL_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSTL.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSTL, KEYCODE, Shift, CP_SSSMAIN(12).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSTL(AE_Val3(CP_SSSMAIN(12), HD_NHSTL.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(12)
		End If
	End Sub
	
	Private Sub HD_NHSTL_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSTL.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 12 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSTL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSTL.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(12).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSTL(AE_Val3(CP_SSSMAIN(12), HD_NHSTL.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSTL.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSTL.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(12), CL_SSSMAIN(12), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSTL_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSTL.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSTL)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSTL.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSTL.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 12
		End If
	End Sub
	
	Private Sub HD_NHSTL_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSTL.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSTL.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NHSZP.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NHSZP_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSZP.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_NHSZP(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_NHSZP_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSZP.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 8
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 8
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP)
		HD_NHSZP.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_NHSZP_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSZP.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_NHSZP, KEYCODE, Shift, CP_SSSMAIN(8).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSZP(AE_Val3(CP_SSSMAIN(8), HD_NHSZP.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(8)
		End If
	End Sub
	
	Private Sub HD_NHSZP_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSZP.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 8 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSZP_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSZP.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(8).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSZP(AE_Val3(CP_SSSMAIN(8), HD_NHSZP.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_NHSZP.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_NHSZP.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_NHSZP_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSZP.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSZP)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_NHSZP.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_NHSZP.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 8
		End If
	End Sub
	
	Private Sub HD_NHSZP_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSZP.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_NHSZP.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_OLDNHSCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OLDNHSCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OLDNHSCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_OLDNHSCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_OLDNHSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OLDNHSCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 24
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 24
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD)
		HD_OLDNHSCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_OLDNHSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OLDNHSCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OLDNHSCD, KEYCODE, Shift, CP_SSSMAIN(24).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OLDNHSCD(AE_Val3(CP_SSSMAIN(24), HD_OLDNHSCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(24)
		End If
	End Sub
	
	Private Sub HD_OLDNHSCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OLDNHSCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 24 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_OLDNHSCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OLDNHSCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(24).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OLDNHSCD(AE_Val3(CP_SSSMAIN(24), HD_OLDNHSCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_OLDNHSCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_OLDNHSCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(24), CL_SSSMAIN(24), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_OLDNHSCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OLDNHSCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OLDNHSCD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_OLDNHSCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_OLDNHSCD.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 24
		End If
	End Sub
	
	Private Sub HD_OLDNHSCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OLDNHSCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_OLDNHSCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_OLNGRPCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OLNGRPCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OLNGRPCD.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_OLNGRPCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
	
	Private Sub HD_OLNGRPCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OLNGRPCD.Enter 'Generated.
		If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
		PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
		If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
		PP_SSSMAIN.Tx = 25
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 25
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD)
		HD_OLNGRPCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_OLNGRPCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OLNGRPCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OLNGRPCD, KEYCODE, Shift, CP_SSSMAIN(25).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OLNGRPCD(AE_Val3(CP_SSSMAIN(25), HD_OLNGRPCD.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(25)
		End If
	End Sub
	
	Private Sub HD_OLNGRPCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OLNGRPCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 25 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD, KeyAscii)
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_OLNGRPCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OLNGRPCD.Leave 'Generated.
		PP_SSSMAIN.OnFocus = False
		If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
		PP_SSSMAIN.SuppressGotLostFocus = 0
		If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
		If CP_SSSMAIN(25).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OLNGRPCD(AE_Val3(CP_SSSMAIN(25), HD_OLNGRPCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_OLNGRPCD.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_OLNGRPCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(25), CL_SSSMAIN(25), PP_SSSMAIN.Tx)
		Call AE_CursorRivise_SSSMAIN()
	End Sub
	
	Private Sub HD_OLNGRPCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OLNGRPCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		Dim wk_Tx As Short
		If PP_SSSMAIN.Operable Then
			If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
				SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OLNGRPCD)
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_OLNGRPCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_OLNGRPCD.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 25
		End If
	End Sub
	
	Private Sub HD_OLNGRPCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OLNGRPCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_OLNGRPCD.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_OPEID.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OPEID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
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
		PP_SSSMAIN.Tx = 33
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 33
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID)
		HD_OPEID.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_OPEID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPEID.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OPEID, KEYCODE, Shift, CP_SSSMAIN(33).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(33), HD_OPEID.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(33)
		End If
	End Sub
	
	Private Sub HD_OPEID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPEID.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 33 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID, KeyAscii)
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
		If CP_SSSMAIN(33).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(33), HD_OPEID.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_OPEID.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_OPEID.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(33), CL_SSSMAIN(33), PP_SSSMAIN.Tx)
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
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_OPEID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_OPEID.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 33
		End If
	End Sub
	
	Private Sub HD_OPEID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPEID.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_OPEID.ReadOnly = False
		Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_OPENM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_OPENM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.TextChanged 'Generated.
		If PP_SSSMAIN.MultiLineF > 0 Then
			PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
			If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
		End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019/09/26 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(34), HD_OPENM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(34), HD_OPENM, FORM_LOAD_FLG) Then
                '2019/09/26 CHG END
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
		PP_SSSMAIN.Tx = 34
		PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.Px = 34
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(34), HD_OPENM)
		If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
		Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(34), HD_OPENM)
		HD_OPENM.BackColor = SSSMSG_BAS.Cn_ClBrightON
		CM_SLIST.Enabled = False
	End Sub
	
	Private Sub HD_OPENM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPENM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
		If AE_KeyDown_SSSMAIN(HD_OPENM, KEYCODE, Shift, CP_SSSMAIN(34).TpStr) Then
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(34), HD_OPENM.Text), Cn_Status6, True, True)
			If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(34)
		End If
	End Sub
	
	Private Sub HD_OPENM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPENM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
		If PP_SSSMAIN.Tx <> 34 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
		Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(34), HD_OPENM, KeyAscii)
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
		If CP_SSSMAIN(34).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
			If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(34), HD_OPENM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
				On Error Resume Next
				HD_OPENM.Focus()
			End If
		End If
		If System.Drawing.ColorTranslator.ToOle(HD_OPENM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(34), CL_SSSMAIN(34), PP_SSSMAIN.Tx)
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
                '2019/09/26　仮
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26　仮
                PP_SSSMAIN.NeglectPopupFocus = False
				wk_Tx = PP_SSSMAIN.Tx
				If PP_SSSMAIN.PopupTx = HD_OPENM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
				System.Windows.Forms.Application.DoEvents()
				HD_OPENM.Enabled = True
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			End If
			PP_SSSMAIN.MouseDownTx = 34
		End If
	End Sub
	
	Private Sub HD_OPENM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPENM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
		HD_OPENM.ReadOnly = False
	End Sub
	
	Private Sub Image2_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image2.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		Call Init_Prompt()
	End Sub
	
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
	
	Private Sub CM_Hardcopy_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Hand Made
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
	
	Private Sub CM_NextCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "次のページを表示します。"
	End Sub
	
	Private Sub Image1_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Hand Made
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
            '2019/09/26 CHG START
            'If VB6.GetActiveControl().SelLength <= 1 Then
            If DirectCast(VB6.GetActiveControl(), TextBox).SelectionLength <= 1 Then
                '2019/09/26 CHG E N D
                On Error Resume Next
				'UPGRADE_ISSUE: Control Text は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				My.Computer.Clipboard.SetText(VB6.GetActiveControl().Text)
				On Error GoTo 0
			Else
				On Error Resume Next
                'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                '2019/09/26 CHG START
                'My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
                My.Computer.Clipboard.SetText(DirectCast(VB6.GetActiveControl(), TextBox).SelectedText)
                '2019/09/26 CHG E N D
                On Error GoTo 0
			End If
		End If
	End Sub
	
	Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click 'Generated.
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Mode = Cn_Mode4 Then
			MN_DeleteCm.Enabled = True
		Else
			MN_DeleteCm.Enabled = False
		End If
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
	
	Public Sub MN_DeleteCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_DeleteCm.Click 'Generated.
		Dim wk_Cursor As Short
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If PP_SSSMAIN.Mode < Cn_Mode4 Then
			Beep()
			wk_Cursor = Cn_CuCurrent
		Else
			wk_Cursor = AE_DeleteCm_SSSMAIN()
		End If
		If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN()
	End Sub
	
	Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click 'Generated.
		Const CF_TEXT As Short = 1
		If Not PP_SSSMAIN.Operable Then Exit Sub
		MN_APPENDC.Enabled = True
		MN_ClearItm.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
			If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm.Enabled = True
		End If
		MN_Copy.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
			If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If Not IsDbNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Copy.Enabled = True
			End If
		End If
		MN_Cut.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
			If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
                'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/09/26 CHG START
                'If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
                If DirectCast(AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx), TextBox).SelectionLength > 0 Then
                    '2019/09/26 CHG E N D
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
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
			If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
                'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetFormat はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
                '2019/09/26 CHG START
                'If My.Computer.Clipboard.GetFormat(CF_TEXT) Then
                If My.Computer.Clipboard.ContainsText(CF_TEXT) Then
                    '2019/09/26 CHG E N D
                    If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste.Enabled = True
				End If
			End If
		End If
		MN_UnDoItem.Enabled = False
		If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
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
	
	Public Sub MN_Hardcopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Hardcopy.Click 'Generated.
		Dim wk_Cursor As Short
		If Not PP_SSSMAIN.Operable Then Exit Sub
		If SSSMAIN_Hardcopy_Getevent() Then
			wk_Cursor = AE_Hardcopy_SSSMAIN()
		End If
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
		ElseIf PP_SSSMAIN.Tx = 1 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 2 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 17 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 19 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 21 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 26 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 28 Then 
			If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
		ElseIf PP_SSSMAIN.Tx = 30 Then 
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
				If VB6.GetActiveControl().TabIndex >= 35 Then
                    'UPGRADE_ISSUE: Control SelText は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                    'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。                    
                    '2019/09/26 CHG START
                    'VB6.GetActiveControl().SelText = My.Computer.Clipboard.GetText()
                    DirectCast(VB6.GetActiveControl(), TextBox).SelectedText = My.Computer.Clipboard.GetText()
                    '2019/09/26 CHG E N D
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
				wk_Bool = AE_CursorUp_SSSMAIN(35)
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
				wk_Bool = AE_CursorPrev_SSSMAIN(35)
			End If
		ElseIf (KEYCODE = System.Windows.Forms.Keys.Execute Or KEYCODE = System.Windows.Forms.Keys.Return) And Shift = 0 Then 
		ElseIf KEYCODE = System.Windows.Forms.Keys.End And Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			If PP_SSSMAIN.Mode <> Cn_Mode3 Then
				If AE_CursorPrevDsp_SSSMAIN(35) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
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
			SM_FullPast.Enabled = False
            'UPGRADE_ISSUE: 定数 vbPopupMenuRightButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。            
            '2019/09/26　仮
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            '2019/09/26　仮
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
            '2019/09/26　仮
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            '2019/09/26　仮
            TX_Mode.Enabled = True
		End If
	End Sub
End Class