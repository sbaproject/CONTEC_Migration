Option Strict Off
Option Explicit On
Friend Class WLS_BMN1
	Inherits System.Windows.Forms.Form
	'�����L�[No�i�g�p���Ȃ��ꍇ��-1��ݒ�j
	Const WM_WLS_BmnKey As Short = 1

    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 chg start
    'Dim WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    'Dim WM_WLS_LEN As Short '�J�n���ޓ��͕�����
    Dim WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    Dim WM_WLS_LEN As Object '�J�n���ޓ��͕�����
    '20190619 chg end

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
	
	Dim WlsSelList As String '�e�[�u������
	Dim SWlsSelList As String '�e�[�u���S����
	Dim WlsHint As String
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	
	Private DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07
	
	'UPGRADE_WARNING: Form �C�x���g WLS_BMN1.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLS_BMN1_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190808 DEL START
        '      WLSMAE.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Me.Width) - (VB6.PixelsToTwipsX(WLSMAE.Width) + VB6.PixelsToTwipsX(WLSOK.Width) + VB6.PixelsToTwipsX(WLSCANCEL.Width) + VB6.PixelsToTwipsX(WLSATO.Width) + 60)) / 2)
        '      WLSOK.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSMAE.Left) + VB6.PixelsToTwipsX(WLSMAE.Width) + 60)
        'WLSCANCEL.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSOK.Left) + VB6.PixelsToTwipsX(WLSOK.Width) + 60)
        'WLSATO.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSCANCEL.Left) + VB6.PixelsToTwipsX(WLSCANCEL.Width) + 60)
        ''=== WINDOW �ʒu�ݒ� ===
        'Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
        ''UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'WM_WLS_STTKEY = ""
        ''UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'WM_WLS_ENDKEY = System.DBNull.Value

        'WM_WLS_Dspflg = True
        'WM_WLS_Pagecnt = -1
        'WM_WLS_LastPage = -1
        'WM_WLS_LastFL = False
        'ReDim WM_WLS_DSPArray(0)

        '' Call WLS_BMNSQL
        ''  Call WLS_DspNew
        ''If (LST.ListCount > 0) And (LST.ListIndex < 0) Then LST.ListIndex = 0

        ''DblClick�C�x���g��Q�Ή�  97/04/07
        'DblClickFl = False
        '20190808 DEL END

    End Sub
	
	Private Sub WLS_BMN1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		'=== WINDOW �\���t�@�C���ݒ� ===
		WM_WLS_MFIL = DBN_BMNMTA
		
		'=== �\���J�n�R�[�h�����ݒ� ===
		WM_WLS_LEN = Len(DB_BMNMTA.BMNCD) 'LenWid �̓_��
		WlsSelList = "BMNCD,BMNNM,STTTKDT,ENDTKDT"
		SWlsSelList = "*"
		'=== �k�`�a�d�k�ݒ� ===
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019.04.08 CHG START
        'WLSLABEL = "���庰�� ���喼                                   �K�p�J�n�� �K�p�I����"
        WLSLABEL.Text = "���庰�� ���喼                                   �K�p�J�n�� �K�p�I����"
        '2019.04.08 CHG END
		'XXXXX6�@ MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4 YYYY/MM/DD�@YYYY/MM/DD
		
		WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)

        Call Init_Prompt()

        '20190808 ADD START
        WLSMAE.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Me.Width) - (VB6.PixelsToTwipsX(WLSMAE.Width) + VB6.PixelsToTwipsX(WLSOK.Width) + VB6.PixelsToTwipsX(WLSCANCEL.Width) + VB6.PixelsToTwipsX(WLSATO.Width) + 60)) / 2)
        WLSOK.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSMAE.Left) + VB6.PixelsToTwipsX(WLSMAE.Width) + 60)
        WLSCANCEL.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSOK.Left) + VB6.PixelsToTwipsX(WLSOK.Width) + 60)
        WLSATO.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSCANCEL.Left) + VB6.PixelsToTwipsX(WLSCANCEL.Width) + 60)
        '=== WINDOW �ʒu�ݒ� ===
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WM_WLS_STTKEY = ""
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WM_WLS_ENDKEY = System.DBNull.Value

        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        ' Call WLS_BMNSQL
        '  Call WLS_DspNew
        'If (LST.ListCount > 0) And (LST.ListIndex < 0) Then LST.ListIndex = 0

        'DblClick�C�x���g��Q�Ή�  97/04/07
        DblClickFl = False
        '20190808 ADD END

    End Sub
	Private Function WLS_DSP_CHECK() As Object
		If DB_BMNMTA.DATKB = "9" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLS_DSP_CHECK = SSS_NEXT
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLS_DSP_CHECK = SSS_OK
		End If
	End Function
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		'====================================
		'   WINDOW ���אݒ�
		'====================================
		'    WM_WLS_DSPArray(ArrayCnt) = DB_BMNMTA.BMNCD & "  " & LeftWid(DB_BMNMTA.BMNNM, 40) & "  " & CNV_DATE(DB_BMNMTA.STTTKDT) & "  " & CNV_DATE(DB_BMNMTA.ENDTKDT)
		WM_WLS_DSPArray(ArrayCnt) = DB_BMNMTA.BMNCD & "   " & DB_BMNMTA.BMNNM & " " & CNV_DATE(DB_BMNMTA.STTTKDT) & "  " & CNV_DATE(DB_BMNMTA.ENDTKDT)
		
	End Sub
	Private Sub WLS_DspNew()
		'    Dim WL_Mode As Integer
		'Dim cnt%
		'
		'    WL_Mode = 0
		'    cnt = 0
		'    Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
		'        WL_Mode = WLS_DSP_CHECK()
		'        If WL_Mode = SSS_OK Then
		'            If cnt = 0 Then
		'                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
		'                WM_WLS_LastPage = WM_WLS_Pagecnt
		'                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
		'            End If
		'            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
		'            cnt = cnt + 1
		'        End If
		'        If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
		'            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
		'        End If
		'    Loop
		'    If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
		'    If cnt > 0 Then
		'        Call WLS_DspPage
		'    Else
		'        LST.Clear
		'    End If
	End Sub
	Private Sub WLS_DspPage()
		Dim WL_Mode As Short
		Dim cnt As Short
		
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
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = True

        'add start 20190819 kuwahara
        If (WM_WLS_LEN = 0) Then 'LENGTH��0�ɂȂ��Ă��܂����߁A6�ɕς���
            WM_WLS_LEN = 6 'BMNMTA��BMNCD��6���ł��邽��
        End If
        'add end 20190819 kuwahara

        'Call LST_KeyDown(13, 0)
        Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
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
				Call WLSOK_Click(WLSOK, New System.EventArgs())
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case System.Windows.Forms.Keys.Left '���L�[
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
			Case System.Windows.Forms.Keys.Right '���L�[
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '20190808 CHG START
    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '       ''    If LST.ListCount <= 0 Then Exit Sub
    '       ''
    '       ''    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '       ''        If Not WM_WLS_LastFL Then Call WLS_DspNew
    '       ''    Else
    '       ''        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '       ''        Call WLS_DspPage
    '       ''    End If

    '       Dim lngIndex As Integer
    '       lngIndex = LST.TopIndex
    '       lngIndex = lngIndex + WM_WLS_MAX

    '       If lngIndex <= LST.Items.Count - 1 Then
    '           If lngIndex + WM_WLS_MAX > LST.Items.Count Then
    '               LST.TopIndex = LST.Items.Count - WM_WLS_MAX
    '               LST.SelectedIndex = LST.Items.Count - WM_WLS_MAX
    '           Else
    '               LST.TopIndex = lngIndex
    '               LST.SelectedIndex = lngIndex
    '           End If
    '       End If

    '   End Sub

    '   Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSATO.Image = IM_ATO(1).Image
    'End Sub

    'Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSATO.Image = IM_ATO(0).Image
    'End Sub

    Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

        ''    If LST.ListCount <= 0 Then Exit Sub
        ''
        ''    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
        ''        If Not WM_WLS_LastFL Then Call WLS_DspNew
        ''    Else
        ''        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        ''        Call WLS_DspPage
        ''    End If

        Dim lngIndex As Integer
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

    End Sub
    '20190808 CHG END


    Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		'''    If WM_WLS_Pagecnt > 0 Then
		'''        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
		'''        Call WLS_DspPage
		'''    End If
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
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		'Unload Me
		Hide()
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		'Call LST_KeyDown(13, 0)
		Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
End Class