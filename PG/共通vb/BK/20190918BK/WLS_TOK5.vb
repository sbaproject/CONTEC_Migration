Option Strict Off
Option Explicit On
Friend Class WLSTOK5
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@�����挟��
	'*  �v���O�����h�c�@�F  WLSTOK5
	'*  �쐬�ҁ@�@�@�@�@�F�@RISE)�{��
	'*  �쐬���@�@�@�@�@�F  2008.08.26
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'************************************************************************************
	'   Public�ϐ�
	'************************************************************************************
	'�߂�l
	
	'************************************************************************************
	'   Private�萔
	'************************************************************************************
	
	' === 20060730 === UPDATE S - ACE)Nagasawa
	'    Private Const WM_WLSKEY_ZOKUSEI = "0"       '�J�n�R�[�h���͑��� [0,X]
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]
    ' === 20060730 === UPDATE E -

    '************************************************************************************
    '   Private�ϐ�
    '************************************************************************************

    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 CHG START
    'Private WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    Private WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    '20190619 CHG END
    Private WM_WLS_CODELEN As Short '�J�n���ޓ��͕�����
	Private WM_WLS_NAMELEN As Short '���Ӑ旪�̓��͕�����
	
	Private WM_WLS_TOKSEICDLEN As Short '������R�[�h�@ListBox��
	Private WM_WLS_TOKNMALEN As Short '���Ӑ於�̂P  ListBox��
	Private WM_WLS_TOKCDLEN As Short '���Ӑ�R�[�h  ListBox��
	Private WM_WLS_TOKRNLEN As Short '���Ӑ旪��    ListBox��
	
	'�E�B���h�����g�p�ϐ�
	Private WM_WLS_MAX As Short '�P��ʂ̕\������
	Private WM_WLS_CODE As String '���Ӑ�R�[�h�����p
	Private WM_WLS_TOKRN As String '���Ӑ旪�̌����p
	Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Usr_Ody As U_Ody '�ް��ް����ð���
	Private DB_TOKMAT_W As TYPE_DB_TOKMTA '�������ʑޔ�
	Private bolInitWindow As Boolean '��ʏ������t���O(True:������)
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_FORM_INIT
	'   �T�v�F  ��ʏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		
		'=== �\���J�n�R�[�h�����ݒ� ===
		WM_WLS_CODELEN = 5
		WM_WLS_MAX = 15 '��ʕ\������
		WM_WLS_TOKSEICDLEN = 10 '������R�[�h�@ListBox��
		WM_WLS_TOKNMALEN = 40 '���Ӑ於�̂P  ListBox��
		WM_WLS_TOKCDLEN = 10 '���Ӑ�R�[�h  ListBox��
		WM_WLS_TOKRNLEN = 40 '���Ӑ旪��    ListBox��
		'�ϐ�������
		WLSTOK_RTNCODE = ""
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
		'====================================
		'   WINDOW ���אݒ�
		'====================================
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_TOKMAT_W.TOKSEICD, WM_WLS_TOKSEICDLEN) & Space(6) & LeftWid(DB_TOKMAT_W.TOKNMA, WM_WLS_TOKNMALEN) & Space(6) & LeftWid(DB_TOKMAT_W.TOKCD, WM_WLS_TOKCDLEN) & Space(2) & LeftWid(DB_TOKMAT_W.TOKRN, WM_WLS_TOKRNLEN)
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_TextSQL
	'   �T�v�F  ����sql�쐬
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL()
		
		Dim strSQL As String
		Dim intData As Short
		
		strSQL = ""
		strSQL = strSQL & " Select TOKSEICD " '������R�[�h
		strSQL = strSQL & "      , TOKNMA " '���Ӑ於�̂P
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TOKRN " '���Ӑ旪��
		strSQL = strSQL & "   from TOKMTA "
		strSQL = strSQL & "  Where TOKSEICD = TOKCD "
		
		'���Ӑ�R�[�h����
		If Trim(WM_WLS_CODE) <> "" Then
			strSQL = strSQL & "    and TOKCD >=   '" & WM_WLS_CODE & "'"
		End If
		
		'���Ӑ旪�̌���(�����܂�����)
		If Trim(WM_WLS_TOKRN) <> "" Then
			strSQL = strSQL & "    and ( TOKRN LIKE '%" & WM_WLS_TOKRN & "%'"
			strSQL = strSQL & "       or TOKNK LIKE '%" & WM_WLS_TOKRN & "%' )"
		End If
		
		'�\�[�g����
		strSQL = strSQL & "   order by "
		strSQL = strSQL & "   TOKCD "
		strSQL = strSQL & "  ,TOKSEICD "
		
        'DB�A�N�Z�X
        '2019/04/02 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/02 CHG E N D

	End Sub
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_DspNew
	'   �T�v�F  ���X�g�ҏW����(�������)
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		Dim cnt As Integer
		Dim Wk_Pagecnt As Short
		
		cnt = 0
        Wk_Pagecnt = -1

        '2019/04/05 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '	'�擾���e�ޔ�
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TOKMAT_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "") '������R�[�h
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TOKMAT_W.TOKNMA = CF_Ora_GetDyn(Usr_Ody, "TOKNMA", "") '���Ӑ於�̂P
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TOKMAT_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TOKMAT_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '���Ӑ旪��

        '	'�\�����y�[�W
        '	If cnt Mod WM_WLS_MAX = 0 Then
        '		Wk_Pagecnt = Wk_Pagecnt + 1
        '		'�ŏI�y�[�W�ޔ�
        '		WM_WLS_LastPage = Wk_Pagecnt
        '		ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
        '		cnt = 0
        '	End If

        '	'�\���������W�J
        '	Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + cnt)

        '	cnt = cnt + 1

        '	Call CF_Ora_MoveNext(Usr_Ody)
        'Loop 
        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1
            '�擾���e�ޔ�
            DB_TOKMAT_W.TOKSEICD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKSEICD"), "") '������R�[�h
            DB_TOKMAT_W.TOKNMA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKNMA"), "") '���Ӑ於�̂P
            DB_TOKMAT_W.TOKCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKCD"), "") '���Ӑ�R�[�h
            DB_TOKMAT_W.TOKRN = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKRN"), "") '���Ӑ旪��


            'DB_TOKMAT_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "") '������R�[�h
            'DB_TOKMAT_W.TOKNMA = CF_Ora_GetDyn(Usr_Ody, "TOKNMA", "") '���Ӑ於�̂P
            'DB_TOKMAT_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
            'DB_TOKMAT_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '���Ӑ旪��

            '�\�����y�[�W
            If cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                cnt = 0
                '�ŏI�y�[�W�ޔ�
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)

            cnt = cnt + 1

            'If cnt >= WM_WLS_MAX Then
            '    Exit For
            'End If
        Next
        '2019/04/05 CHG E N D

		'�擾�f�[�^�L���Ɋւ�炸�ŏI�f�[�^���B
		WM_WLS_LastFL = True
		
		If cnt > 0 Then
            '�P�y�[�W��\��
            WM_WLS_Pagecnt = 0
            Call WLS_DspPage()
		Else
			LST.Items.Clear()
		End If
		
	End Sub
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_DspPage
	'   �T�v�F  ���X�g�ҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspPage()
		Dim WL_Mode As Short
		Dim intCnt As Short
		
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
		
		'��������
		WM_WLS_CODE = ""
		WM_WLS_TOKRN = ""
		
		'��ʕ\���y�[�W
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
		'�������ʕێ��z��
		ReDim WM_WLS_DSPArray(0)
		
	End Sub
	
	'
	'�ȉ��͉�ʃC�x���g����
	'
	'UPGRADE_WARNING: Form �C�x���g WLSTOK5.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSTOK5_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190626 DEL START
        '      If bolInitWindow = False Then
        '	Exit Sub
        'Else
        '	bolInitWindow = False
        'End If

        ''WINDOW �ʒu�ݒ�
        'Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'WM_WLS_Dspflg = False

        ''���ڏ�����
        'HD_CODE.Text = ""
        'HD_NAME.Text = ""
        'LST.Items.Clear()
        'WM_WLS_Dspflg = True

        'ReDim WM_WLS_DSPArray(0)

        ''������ԑS���\��
        'Call WLS_TextSQL()
        'Call WLS_DspNew()

        'DblClickFl = False

        'Me.Refresh()
        'On Error Resume Next
        '      LST.Focus()
        '20190626 DEL START

    End Sub

    Private Sub WLSTOK5_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window�����ݒ�
        Call WLS_FORM_INIT()

        bolInitWindow = True

        '20190626 ADD START
        If bolInitWindow = False Then
            Exit Sub
        Else
            bolInitWindow = False
        End If

        'WINDOW �ʒu�ݒ�
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        WM_WLS_Dspflg = False

        '���ڏ�����
        HD_CODE.Text = ""
        HD_NAME.Text = ""
        LST.Items.Clear()
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)

        '������ԑS���\��
        Call WLS_TextSQL()
        Call WLS_DspNew()

        DblClickFl = False

        Me.Refresh()
        On Error Resume Next
        LST.Focus()
        '20190626 ADD END

    End Sub


    '20190626 ADD START
    Private Sub WLSTOK5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.btnF1.PerformClick()

                Case Keys.F2
                    Me.btnF2.PerformClick()

                Case Keys.F7
                    Me.btnF7.PerformClick()

                Case Keys.F8
                    Me.btnF8.PerformClick()

                Case Keys.F9
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub
    '20190626 ADD END


    Private Sub HD_CODE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CODE.Enter
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(HD_CODE.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(HD_CODE.Text) > 0 Then
			'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
		End If
		HD_CODE.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_CODE.SelectionLength = HD_CODE.Maxlength
	End Sub
	
	Private Sub HD_CODE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_CODE.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			
			'�����p�ϐ��Z�b�g
			Call WLS_Clear()
			WM_WLS_CODE = HD_CODE.Text
			
			'�����������N���A
			HD_NAME.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_CODE_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_CODE.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		KeyAscii = Asc(UCase(Chr(KeyAscii)))
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NAME_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NAME.Enter
		HD_NAME.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_NAME.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_NAME.SelectionLength = HD_NAME.Maxlength
	End Sub
	
	Private Sub HD_NAME_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NAME.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			
			'�����p�ϐ��Z�b�g
			Call WLS_Clear()
			WM_WLS_TOKRN = HD_NAME.Text
			
			'�����������N���A
			HD_CODE.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '20190626 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190626 CHG END

    End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			'Enter�L�[����
			Case System.Windows.Forms.Keys.Return
                '20190626 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190626 CHG END

                'Escape�L�[����
            Case System.Windows.Forms.Keys.Escape
                '20190626 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190626 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Left
                '20190626 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190626 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Right
                '20190626 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190626 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub


    '20190626 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '       If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '           If Not WM_WLS_LastFL Then Call WLS_DspPage()
    '       Else
    '           WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '		Call WLS_DspPage()
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
            If Not WM_WLS_LastFL Then Call WLS_DspPage()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190626 CHG END


    '20190626 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_NAME.Focused Then
                Call HD_NAME_KeyDown(HD_NAME, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_CODE_KeyDown(HD_CODE, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʌ����G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            Me.HD_CODE.Text = ""
            Me.HD_NAME.Text = ""
            LST.Items.Clear()
            Me.HD_CODE.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    '20190626 ADD END


    '20190626 CHG START
    '   Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '	If WM_WLS_Pagecnt > 0 Then
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '		Call WLS_DspPage()
    '	End If
    'End Sub

    'Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSMAE.Image = IM_MAE(1).Image
    'End Sub

    '   Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '       WLSMAE.Image = IM_MAE(0).Image
    '   End Sub

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190626 CHG END

    '20190626 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
    '	Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '       Hide()
    '   End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
        Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        Hide()
    End Sub
    '20190626 CHG END


    Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
		
		On Error Resume Next
		
		Me.HD_CODE.Focus()
		
		System.Windows.Forms.Application.DoEvents()
		
		WLSTOK6.ShowDialog()
		WLSTOK6.Close()
		
		'UPGRADE_NOTE: �I�u�W�F�N�g WLSTOK6 ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		WLSTOK6 = Nothing
		
		If Trim(WLSTOK_RTNCODE) <> "" Then
			'���i�敪�ҏW
			HD_CODE.Text = Trim(WLSTOK_RTNCODE)
			
			Call HD_CODE_KeyDown(HD_CODE, New System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Return Or 0 * &H10000))
			
		End If
		
	End Sub
End Class