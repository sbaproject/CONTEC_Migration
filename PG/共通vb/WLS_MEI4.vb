Option Strict Off
Option Explicit On
Friend Class WLS_MEI4
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@���̃}�X�^����
	'*  �v���O�����h�c�@�F  WLS_MEI
	'*  �쐬�ҁ@�@�@�@�@�F�@ACE)����
	'*  �쐬���@�@�@�@�@�F  2006.05.12
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'�E�B���hհ�ް�ݒ�ϐ�
	Private WM_WLS_MEICDALEN As Short '�R�[�h�P������
	Private WM_WLS_MEINMALEN As Short '���̂P������
	
	'�E�B���h�����g�p�ϐ�
	Private WM_WLS_DSP_Caption As String '��ʷ��߼�ݕ\���f�[�^
	Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	
	' === 20060828 === INSERT S - ACE)Nagasawa �����{�^���ǉ�
	Private WM_WLS_MAX As Short '�P��ʂ̕\������
	Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	Private Dyn_Open As Boolean '�_�C�i�Z�b�g��ԁiTrue:Open False:Close)
	' === 20060828 === INSERT E -
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Usr_Ody As U_Ody '�ް��ް����ð���
    Private DB_MEIMTC_W As TYPE_DB_MEIMTC '�������ʑޔ�

    'ADD 20190404 START saiki
    Private dt As DataTable
    Private PageCount As Integer '�y�[�W���J�E���g
    'ADD 20190404 END saiki

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_FORM_INIT
    '   �T�v�F  ��ʏ�����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()
		'=== �\�������ݒ� ===
		' === 20060828 === INSERT S - ACE)Nagasawa �����{�^���ǉ�
		WM_WLS_MAX = 15 '��ʕ\������
        ' === 20060828 === INSERT E -

        WM_WLS_MEICDALEN = Len(DB_MEIMTC_W.MEICDA) 'LenWid �̓_��
        WM_WLS_MEINMALEN = Len(DB_MEIMTC_W.MEINMA) 'LenWid �̓_��

        '�ϐ�������
        WLSMEIC_RTNMEICDA = ""
		WLSMEIC_RTNMEINMA = ""
		'�ϐ�������
		Call WLS_Clear()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_SetArray
	'   �T�v�F  ���X�g�ҏW
	'   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
        '20190405 CHG START
        'WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_MEIMTC_W.MEICDA, WM_WLS_MEICDALEN) & Space(1) & LeftWid(DB_MEIMTC_W.MEINMA, WM_WLS_MEINMALEN)
        WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_MEIMTC_W.MEICDA, Len(DB_MEIMTC_W.MEICDA)) & Space(1) & LeftWid(DB_MEIMTC_W.MEINMA, Len(DB_MEIMTC_W.MEINMA))
    End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_TextSQL
	'   �T�v�F  ����sql�쐬
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_TextSQL()
		Dim strSQL As String
		
		strSQL = ""
		strSQL = strSQL & " Select KEYCD " '�L�[
		strSQL = strSQL & "      , MEIKMKNM " '���ږ�
		strSQL = strSQL & "      , MEICDA " '�R�[�h�P
		strSQL = strSQL & "      , MEINMA " '���̂P
		strSQL = strSQL & "   from MEIMTC "
		strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "   and  KEYCD = '" & WLSMEIC_KEYCD & "'"
		strSQL = strSQL & "   and  STTTKDT <= '" & WLSMEIC_TKDT & "'"
		strSQL = strSQL & "   and  ENDTKDT >= '" & WLSMEIC_TKDT & "'"
		strSQL = strSQL & "   order by "
		strSQL = strSQL & "        KEYCD " '�L�[
		strSQL = strSQL & "      , DSPORD " '�\������
		strSQL = strSQL & "      , MEICDA " '�R�[�h�P
		
		' === 20060828 === UPDATE S - ACE)Nagasawa �����{�^���ǉ�
		'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)    'DB�A�N�Z�X
		
		If Dyn_Open = True Then
            '�N���[�Y
            '20190628 DEL START
            'Call CF_Ora_CloseDyn(Usr_Ody)
            '20190628 DEL END
            Dyn_Open = False
		End If

        'DB�A�N�Z�X
        'change 20190404 START saiki
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        'change 20190404 END saiki
        Dyn_Open = True
		LST.Items.Clear()
		' === 20060828 === UPDATE E -
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_DspNew
	'   �T�v�F  ���X�g�ҏW����(�������)
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		Dim Cnt As Integer

        Cnt = 0

        'change 20190404 START saiki
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        ' === 20060828 === DELETE S - ACE)Nagasawa �����{�^���ǉ�
        '        If Cnt > 0 Then
        '            ReDim Preserve WM_WLS_DSPArray(Cnt)
        '        End If
        ' === 20060828 === DELETE E -


        '         '�擾���e�ޔ�
        '         'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '         DB_MEIMTC_W.KEYCD = CF_Ora_GetDyn(Usr_Ody, "KEYCD", "") '�L�[
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_MEIMTC_W.MEIKMKNM = CF_Ora_GetDyn(Usr_Ody, "MEIKMKNM", "") '���ږ�
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_MEIMTC_W.MEICDA = CF_Ora_GetDyn(Usr_Ody, "MEICDA", "") '�R�[�h�P
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_MEIMTC_W.MEINMA = CF_Ora_GetDyn(Usr_Ody, "MEINMA", "") '���̂P



        '�\���������W�J
        ' === 20060828 === UPDATE S - ACE)Nagasawa �����{�^���ǉ�
        '        '�P���ڂ͉�ʷ��߼�ݗp
        '        If Cnt = 0 Then
        '            WM_WLS_DSP_Caption = DB_MEIMTC_W.MEIKMKNM
        '        End If
        '
        '        Call WLS_SetArray(Cnt)

        '     '�P���ڂ͉�ʷ��߼�ݗp
        '     If Cnt = 0 And WM_WLS_Pagecnt = -1 Then
        '	WM_WLS_DSP_Caption = DB_MEIMTC_W.MEIKMKNM
        'End If

        ''�\�����y�[�W
        'If Cnt Mod WM_WLS_MAX = 0 Then
        '	WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '	ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '	Cnt = 0
        '	'�ŏI�y�[�W�ޔ�
        '	WM_WLS_LastPage = WM_WLS_Pagecnt
        'End If

        'Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)
        '' === 20060828 === UPDATE E -

        'Cnt = Cnt + 1

        'Call CF_Ora_MoveNext(Usr_Ody)

        '' === 20060828 === INSERT S - ACE)Nagasawa �����{�^���ǉ�
        'If Cnt >= WM_WLS_MAX Then
        '	Exit Do
        'End If
        '     ' === 20060828 === INSERT E -
        '     Loop


        For i As Integer = 0 To dt.Rows.Count - 1

            '�擾���e�ޔ�
            DB_MEIMTC_W.KEYCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("KEYCD"), "") '�[����R�[�h
            DB_MEIMTC_W.MEIKMKNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("MEIKMKNM"), "") '�[���旪��
            DB_MEIMTC_W.MEICDA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("MEICDA"), "") '�[����X�֔ԍ�
            DB_MEIMTC_W.MEINMA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("MEINMA"), "") '�[����X�֔ԍ�


            '�P���ڂ͉�ʷ��߼�ݗp
            If Cnt = 0 And WM_WLS_Pagecnt = -1 Then
                WM_WLS_DSP_Caption = DB_MEIMTC_W.MEIKMKNM
            End If

            '�\�����y�[�W
            If Cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                Cnt = 0
                '�ŏI�y�[�W�ޔ�
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)
            ' === 20060828 === UPDATE E -

            Cnt = Cnt + 1

        Next

        WM_WLS_LastFL = True
        'change 20190404 END saiki


        If Cnt > 0 Then
            '20190805 ADD START
            WM_WLS_Pagecnt = 0
            '20190805 ADD END

            '�y�[�W��\��
            Call WLS_Dsp()
        Else
            If WM_WLS_Pagecnt = 1 Then
				Me.Text = ""
				LST.Items.Clear()
			End If
		End If
		' === 20060828 === UPDATE E -
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Dsp
	'   �T�v�F  ��ʕҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_Dsp()
		Dim intCnt As Short
		
		'��ʷ��߼�ݕҏW
		Me.Text = WM_WLS_DSP_Caption
		
		' === 20060828 === UPDATE S - ACE)Nagasawa �����{�^���ǉ�
		'        '�\�����X�g�ҏW
		'        LST.Clear
		'        intCnt = 0
		'        For intCnt = 0 To UBound(WM_WLS_DSPArray)
		'            LST.AddItem WM_WLS_DSPArray(intCnt)
		'        Next
		
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		LST.Items.Clear()
		intCnt = 0
		Do While intCnt < WM_WLS_MAX
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt))
			End If
			intCnt = intCnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			' === 20061228 === INSERT S - ACE)Nagasawa
			On Error Resume Next
			' === 20061228 === INSERT E -
			LST.Focus()
		End If
		' === 20060828 === UPDATE E -
		
		'�t�H�[�J�X�ݒ�
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			' === 20061228 === INSERT S - ACE)Nagasawa
			On Error Resume Next
			' === 20061228 === INSERT E -
			LST.Focus()
		End If
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Clear
	'   �T�v�F  �ϐ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Clear()
		
		'�������ʕێ��ϐ�
		WM_WLS_DSP_Caption = ""
		'�������ʕێ��z��
		ReDim WM_WLS_DSPArray(0)
		
		' === 20060828 === INSERT S - ACE)Nagasawa �����{�^���ǉ�
		'��ʕ\���y�[�W
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		' === 20060828 === INSERT E -
		
	End Sub
	
	
	'UPGRADE_WARNING: Form �C�x���g WLS_MEI4.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLS_MEI4_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        '// �e�{�^���z�u
        ' === 20060828 === DELETE S - ACE)Nagasawa �����{�^���ǉ�
        '    WLSOK.Left = (WLS_MEI.Width - (WLSOK.Width + WLSCANCEL.Width + 60)) / 2
        '    WLSCANCEL.Left = WLSOK.Left + WLSOK.Width + 60
        ' === 20060828 === DELETE E -

        '20190628 DEL START
        '      '// ��ʕҏW
        '      Call WLS_TextSQL()
        'Call WLS_DspNew()

        'If (LST.Items.Count > 0) And (LST.SelectedIndex < 0) Then LST.SelectedIndex = 0

        '      DblClickFl = False
        '20190628 DEL END

    End Sub

    Private Sub WLS_MEI4_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        Call Init_Prompt()
        Call WLS_FORM_INIT()

        '20190628 ADD START
        '// ��ʕҏW
        Call WLS_TextSQL()
        Call WLS_DspNew()

        If (LST.Items.Count > 0) And (LST.SelectedIndex < 0) Then LST.SelectedIndex = 0

        DblClickFl = False
        '20190628 ADD END

    End Sub

    '20190628 ADD START
    Private Sub WLS_MEI4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190628 ADD END

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KEYCODE
            Case 13
                ''change 20190405 START saiki
                'WLSMEIC_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_MEICDALEN)
                WLSMEIC_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), Len(DB_MEIMTC_W.MEINMA))
                'change 20190405 END saiki

                '20190628 CHG START
                'WLSMEIC_RTNMEINMA = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_MEICDALEN + 2, WM_WLS_MEINMALEN)
                'If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                WLSMEIC_RTNMEINMA = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), Len(DB_MEIMTC_W.MEICDA) + 2, Len(DB_MEIMTC_W.MEINMA))
                If DblClickFl = False Then Call btnF12_Click(btnF12, New System.EventArgs())
                '20190628 CHG END

            Case 27
                '20190628 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190628 CHG END

                ' === 20060828 === INSERT S - ACE)Nagasawa �����{�^���ǉ�
                '���L�[����
            Case System.Windows.Forms.Keys.Left
                '20190628 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190628 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Right
                '20190628 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190628 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
				' === 20060828 === INSERT E -
		End Select
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '20190628 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190628 CHG END

    End Sub

    '20190628 CHG START
    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	' === 20060828 === INSERT S - ACE)Nagasawa �����{�^���ǉ�
    '	'�N���[�Y
    '	Call CF_Ora_CloseDyn(Usr_Ody)
    '	' === 20060828 === INSERT E -

    '	Hide()
    'End Sub

    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '       Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    '   End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        ' === 20060828 === INSERT S - ACE)Nagasawa �����{�^���ǉ�
        '�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody)
        ' === 20060828 === INSERT E -

        Hide()
    End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub
    '20190628 CHG END


    '20190628 CHG START
    ' === 20060828 === INSERT S - ACE)Nagasawa �����{�^���ǉ�
    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '	If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '		If Not WM_WLS_LastFL Then Call WLS_DspNew()
    '	Else
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '		Call WLS_Dsp()
    '	End If
    'End Sub

    'Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSATO.Image = IM_ATO(1).Image
    'End Sub

    '   Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '       WLSATO.Image = IM_ATO(0).Image
    '   End Sub

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click

        If LST.Items.Count <= 0 Then Exit Sub

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_Dsp()
        End If
    End Sub
    '20190628 CHG END

    '20190628 CHG START
    '   Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '	If WM_WLS_Pagecnt > 0 Then
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '		Call WLS_Dsp()
    '	End If
    'End Sub

    'Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSMAE.Image = IM_MAE(1).Image
    'End Sub

    'Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSMAE.Image = IM_MAE(0).Image
    'End Sub
    '   ' === 20060828 === INSERT E -

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_Dsp()
        End If
    End Sub
    '20190628 CHG END

End Class