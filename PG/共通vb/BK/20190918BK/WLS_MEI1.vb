Option Strict Off
Option Explicit On
Friend Class WLS_MEI1
	Inherits System.Windows.Forms.Form
	
	Private DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07
	'2006/07/19 ���C�A�E�g�ύX�啝���� �y�[�W�J��@�\�ǉ��@(�����R�ꂠ�邩��)
	'�E�B���h�����g�p�ϐ�
	Dim WM_WLS_MAX As Short '�P��ʂ̕\������
	Dim WM_WLS_STTKEY As Object '�J�n�L�[
	Dim WM_WLS_ENDKEY As Object '�I���L�[
	Dim WM_WLS_KeyNo As Short 'Ҳ�̧�ٓǂݍ��݃L�[No
	Dim WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Dim WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Dim WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Dim WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Dim WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	'UPGRADE_WARNING: Form �C�x���g WLS_MEI1.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLS_MEI1_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		WLSOK.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Me.Width) - (VB6.PixelsToTwipsX(WLSOK.Width) + VB6.PixelsToTwipsX(WLSCANCEL.Width) + 60)) / 2)
		WLSCANCEL.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSOK.Left) + VB6.PixelsToTwipsX(WLSOK.Width) + 60)
		If (LST.Items.Count > 0) And (LST.SelectedIndex < 0) Then LST.SelectedIndex = 0
		'DblClick�C�x���g��Q�Ή�  97/04/07
        DblClickFl = False

	End Sub

    Private Sub WLS_MEI1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)

        '20190226
        WM_WLS_Pagecnt = -1

        '20190218
        'Call Init_Prompt()
        Call WLS_DspNew()

    End Sub

    '20190531 ADD START
    Private Sub WLS_MEI1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub
    '20190531 ADD END

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = True
		
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub

    Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        '    Select Case KEYCODE
        '        Case 13
        '            Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), SSS_WLSLIST_KETA)
        '            'DblClick�C�x���g��Q�Ή�  97/04/07
        '            'Call WLSCANCEL_CLICK
        '            If DblClickFl = False Then Call WLSCANCEL_CLICK
        '        Case 27
        '            Call WLSCANCEL_CLICK
        '    End Select
        Select Case KEYCODE
            Case System.Windows.Forms.Keys.Return
                '20190531 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190531 CHG END
            Case System.Windows.Forms.Keys.Escape
                '20190531 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190531 CHG END
            Case System.Windows.Forms.Keys.Left '���L�[
                'Call WLSMAE_Click
                ''            If LST.ListIndex <> 0 Then
                ''                LST.ListIndex = LST.ListIndex - 1
                ''            End If

                '20190531 ADD START
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190531 ADD END

            Case System.Windows.Forms.Keys.Right '���L�[
                'Call WLSATO_Click
                ''            If LST.ListCount > 0 Then
                ''                LST.ListIndex = -1
                ''            End If
                '            If WM_WLS_Pagecnt > 0 Then
                '                WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
                '                Call WLS_DspPage
                '            End If
                ''            If LST.ListIndex < LST.ListCount - 1 Then
                ''                LST.ListIndex = LST.ListIndex + 1
                ''            End If

                '20190531 ADD START
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190531 ADD END

        End Select

    End Sub

    '20190531 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click
        '20190531 CHG END

        Dim lngIndex As Integer

        '    If LST.ListCount <= 0 Then Exit Sub
        '    If LST.ListCount <= WM_WLS_MAX Then Exit Sub
        '    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
        '        If Not WM_WLS_LastFL Then Call WLS_DspNew
        '    Else
        ''        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        ''        Call WLS_DspPage
        '    End If

        lngIndex = LST.TopIndex
        lngIndex = lngIndex + WM_WLS_MAX

        If lngIndex <= LST.Items.Count - 1 Then
            If lngIndex + WM_WLS_MAX > LST.Items.Count Then
                LST.TopIndex = LST.Items.Count - WM_WLS_MAX
                LST.SelectedIndex = LST.Items.Count - WM_WLS_MAX
            Else
                LST.TopIndex = lngIndex
                LST.SelectedIndex = lngIndex
            End If
        End If

        '20190405 ADD
        If LST.Items.Count <= 0 Then Exit Sub

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If

    End Sub

    Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'UnLoad�C�x���g��Q�Ή�  97/04/07
        '20190531 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190531 CHG END
    End Sub

    '20190531 CHG START
    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	'UnLoad�C�x���g��Q�Ή�  97/04/07
    '	'Unload Me
    '	Hide()
    'End Sub

    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '       Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), SSS_WLSLIST_KETA)
    '       'DblClick�C�x���g��Q�Ή�  97/04/07
    '       'Call WLSCANCEL_CLICK
    '       If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    '   End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        'UnLoad�C�x���g��Q�Ή�  97/04/07
        'Unload Me
        Hide()
    End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), SSS_WLSLIST_KETA)
        'DblClick�C�x���g��Q�Ή�  97/04/07
        'Call WLSCANCEL_CLICK
        If DblClickFl = False Then Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub
    '20190531 CHG END

    '20190226
    Private Sub WLS_SetsArray(ByVal ArrayCnt As Short)

        '====================================
        '   WINDOW ���אݒ�
        '====================================
        'WM_WLS_DSPArray(ArrayCnt) = DB_MEIMTA.MEICDA & " " & DB_MEIMTA.MEINMA
        WM_WLS_DSPArray(ArrayCnt) = dsList.Tables("MEIMTA").Rows(ArrayCnt).Item("MEICDA") & " " & dsList.Tables("MEIMTA").Rows(ArrayCnt).Item("MEINMA")

    End Sub

	Private Sub WLS_DspNew()
		Dim WL_Mode As Short
		Dim cnt As Short
		
		WL_Mode = 0
        cnt = 0

        '20190708 CHG START
        'Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
        '    WL_Mode = WLS_DSP_CHECK()
        '    If WL_Mode = SSS_OK Then
        '        If cnt = 0 Then
        '            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '            WM_WLS_LastPage = WM_WLS_Pagecnt
        '            ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '        End If

        '        '20190226
        '        'Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
        '        If dsList.Tables("MEIMTA") IsNot Nothing Then
        '            If dsList.Tables("MEIMTA").Rows.Count > cnt Then
        '                Call WLS_SetsArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
        '            End If
        '        End If

        '        cnt = cnt + 1
        '    End If
        '    'If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
        '    '	Call DB_GetNext(SSS_MFIL, BtrNormal)
        '    'End If
        'Loop

        If LST.Items.Count > 0 Then
            Exit Sub
        End If

        Dim dt As DataTable = dsList.Tables("MEIMTA")

        For i As Integer = 0 To dt.Rows.Count - 1

            If cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                cnt = 0
                '�ŏI�y�[�W�ޔ�
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            '�\���������W�J
            Call WLS_SetsArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)

            cnt = cnt + 1
        Next
        '20190708 CHG END

        '20190603 CHG START
        'If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
        WM_WLS_LastFL = True
        '20190603 CHG END

        If cnt > 0 Then
			Call WLS_DspPage()
		Else
			LST.Items.Clear()
		End If
	End Sub
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		
		'====================================
		'   WINDOW ���אݒ�
		'====================================
		' WM_WLS_DSPArray(ArrayCnt) = DB_MEIMTB.KEYCD & " " & DB_MEIMTB.MEIKMKNM
		' WM_WLS_DSPArray(ArrayCnt) = LST.List(LST.ListIndex)
		WM_WLS_DSPArray(ArrayCnt) = VB6.GetItemString(LST, ArrayCnt)
	End Sub
    Private Function WLS_DSP_CHECK() As Object
        If DB_MEIMTA.DATKB = "9" Then
            WLS_DSP_CHECK = SSS_NEXT
        Else
            WLS_DSP_CHECK = SSS_OK
        End If
    End Function
	
	Private Sub WLS_DspPage()
        'Dim WL_Mode As Short
		Dim cnt As Short

        '20190607 ADD START
        If LST.Items.Count > 0 Then
            LST.SelectedIndex = 0
            LST.Focus()
            Exit Sub
        End If
        '20190607 ADD END

        LST.Items.Clear()
		cnt = 0
		Do While cnt < WM_WLS_MAX
            If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)) > "" Then
                LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt))
            End If

            cnt = cnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			LST.Focus()
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

    '20190531 CHG START
    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click

        '20190531 CHG END
        '    If WM_WLS_Pagecnt > 0 Then
        '        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
        '        Call WLS_DspPage
        '    End If

        Dim lngIndex As Integer

        lngIndex = LST.TopIndex
        lngIndex = lngIndex - WM_WLS_MAX

        If lngIndex > 0 Then
            LST.TopIndex = lngIndex
            LST.SelectedIndex = lngIndex
        Else
            LST.TopIndex = 0
            LST.SelectedIndex = 0
        End If

        '20190409 ADD START
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
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
End Class