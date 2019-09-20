Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSNDN
	Inherits System.Windows.Forms.Form
	
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@����No�ꗗ�E�B���h�E
	'*  �v���O�����h�c�@�F  WLSNDN
	'*  �쐬�ҁ@�@�@�@�@�F�@RISE)�X�c
	'*  �쐬���@�@�@�@�@�F  2008.09.05
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'*<02> 2009.03.18�@�F�@�O���x�̌����f�[�^�ɑ΂��ď������s���Ă͂����Ȃ��ׁB
	'*     RISE)�{��       ���f�[�^�����͍ŐV�f�[�^�ɑ΂��Ă̂ݎ��{����B
	'********************************************************************************
	
	'�E�B���h�����g�p�ϐ�
	Private DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07
	
	Private SSS_CurPage As Short
	Private SSS_LastPage As Short
	Private SSS_PageLine As Short
	Private WRK_NKNDL01() As TYPE_DB_NKNDL01

    Private pv_blnChange_Flg As Boolean

    '20190729 ADD START
    Private TANCD_LEN As Object
    '20190729 ADD END

    Private Sub WLS_FORM_LOAD()
		Dim strLABEL As String
		
		'=== WINDOW �ʒu�ݒ� ===
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		
		'=== ����TEXT ===
		WLSTANCD.Text = ""
		WLSTANNM.Text = ""
		WLSNYUCD.Text = ""
		WLSNDNDT.Text = ""
		WLSTOKCD.Text = ""
		WLSTOKRN.Text = ""
		
		'=== �k�`�a�d�k�ݒ� ===
		strLABEL = ""
		strLABEL = strLABEL & "������" & New String(" ", 5)
		strLABEL = strLABEL & "�����敪" & New String(" ", 3)
		strLABEL = strLABEL & "�������" & New String(" ", 3)
		strLABEL = strLABEL & "������" & New String(" ", 35)
		strLABEL = strLABEL & "�����z"
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190522 CHG START
        'WLSLABEL = strLABEL
        WLSLABEL.Text = strLABEL
        '20190522 CHG END
    End Sub
	
	Private Sub WLSSSS_FORM_INIT()
        SSS_PageLine = VB6.PixelsToTwipsY(LST.Height) \ 240

        '20190729 ADD START
        If DB_TANMTA.TANCD Is Nothing Then
            TANCD_LEN = "6"
        Else
            TANCD_LEN = LenWid(DB_TANMTA.TANCD)
        End If
        '20190729 ADD END

    End Sub
	
	Private Sub WLSSSS_FORM_ACTIVATE()
		''��ʂ̓�����ʗ��ɏ����l�u1�v��\��
		WLSNYUCD.Text = "1"
	End Sub
	
	Private Sub WLS_DIS_CurrentPage(ByVal intPage As Short)
		'intPage�F�J�����g�؁|�W��
		Dim lngPOS As Integer
		Dim lngCnt As Integer
		Dim I As Integer
		Dim strNYUNM As String
		Dim strDKBNM As String
		Dim strTOKRN As String
		Dim strNYUKN As String
		Dim lngSW As Integer
		
		lngSW = 0
		
		LST.Items.Clear()
		LST1.Items.Clear()
		
		lngPOS = (intPage - 1) * SSS_PageLine + 1 '�\���J�n�ʒu
		lngCnt = 0
		
		If UBound(WRK_NKNDL01) > 0 Then
			For I = lngPOS To UBound(WRK_NKNDL01)
				lngCnt = lngCnt + 1
				If lngCnt > SSS_PageLine Then Exit For
                '
                With WRK_NKNDL01(I)
                    '20190522 CHG START
                    'strNYUNM = AnsiTrimStringByByteCount(Trim(.NYUNM) & New String(" ", 10), 10)
                    'strDKBNM = AnsiTrimStringByByteCount(Trim(.DKBNM) & New String(" ", 10), 10)
                    'strTOKRN = AnsiTrimStringByByteCount(Trim(.TOKRN) & New String(" ", 40), 40)
                    strNYUNM = Trim(.NYUNM)
                    strDKBNM = Trim(.DKBNM)
                    strTOKRN = Trim(.TOKRN)
                    '20190522 CHG END

                    '�����̍ő包�܂őΉ�
                    strNYUKN = New String(" ", 19 - Len(VB6.Format(.NYUKN, "###,###,##0.0000"))) & VB6.Format(.NYUKN, "###,###,##0.0000")

                    LST.Items.Add(CNV_DATE(.UDNDT) & " " & strNYUNM & " " & strDKBNM & " " & strTOKRN & " " & strNYUKN)
                    LST1.Items.Add(.DATNO)
                End With
                '
                lngSW = 1
			Next 
		End If
		
		If lngSW = 1 Then LST.SelectedIndex = 0 '�ꗗ���X�g�Ƀt�H�[�J�X�����Ă�
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub GET_UDNTRA_NKN
	'   �T�v�F  ��������
	'   �����F�@�Ȃ�
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub GET_UDNTRA_NKN()
		Dim lngCnt As Integer
		Dim I As Short
		Dim strMsg As String '�������ʗp���b�Z�[�W
		Dim Retn_Code As Short
		Dim strDATNO As String
		Dim Tbl_Inf_NKNDL01() As TYPE_DB_NKNDL01
		
		'�K�{�L�[���̓`�F�b�N
		If Trim(WLSTANCD.Text) = "" Then
			Call MsgBox("���͒S���� ����͂��Ă��������B", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
			Call WLSTANCD.Focus()
			Exit Sub
		End If
		
		If Trim(WLSNYUCD.Text) = "" Then
			Call MsgBox("�����敪 ����͂��Ă��������B", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
			Call WLSNYUCD.Focus()
			Exit Sub
		End If
		
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		Retn_Code = DSPNKNDL01_SEARCH(WLSTANCD.Text, WLSNYUCD.Text, DeCNV_DATE((WLSNDNDT.Text)), WLSTOKCD.Text, Tbl_Inf_NKNDL01)
		If Retn_Code <> 0 Then
			Me.Cursor = System.Windows.Forms.Cursors.Arrow
			Exit Sub
		End If
		
		WRK_NKNDL01 = VB6.CopyArray(Tbl_Inf_NKNDL01)
		
		lngCnt = UBound(Tbl_Inf_NKNDL01)
		
		'�������ʕ\��(100���ȏ�)
		If lngCnt >= 100 Then
			strMsg = "�������ʁF" & lngCnt & "��"
			
			If MsgBox(strMsg, MsgBoxStyle.OKCancel Or MsgBoxStyle.Question, Me.Text) = MsgBoxResult.Cancel Then
				LST.Items.Clear()
				LST1.Items.Clear()
				SSS_CurPage = 0 '�J�����g�؁|�W��
				SSS_LastPage = 0
				Erase Tbl_Inf_NKNDL01
				Me.Cursor = System.Windows.Forms.Cursors.Arrow
				Exit Sub
			End If
		End If
		
		If lngCnt > 0 Then
			SSS_LastPage = Int((lngCnt - 1) / SSS_PageLine) + 1 '�ŏI�؁|�W��
			SSS_CurPage = 1 '�J�����g�؁|�W��
			Call WLS_DIS_CurrentPage(SSS_CurPage) '�J�����g�؁|�W�\��
			Call LST.Focus()
		Else
			LST.Items.Clear()
			LST1.Items.Clear()
			SSS_CurPage = 0 '�J�����g�؁|�W��
			SSS_LastPage = 0
			Erase Tbl_Inf_NKNDL01
			'�f�[�^�����݂��Ȃ����Ƀ��b�Z�[�W��\������B
			Call MsgBox("�Y������f�[�^�����݂��܂���B", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
		End If
		
		Me.Cursor = System.Windows.Forms.Cursors.Arrow
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub COM_TANCD_Click
	'   �T�v�F  ���͒S���҃{�^���N���b�N�C�x���g
	'   �����F�@�Ȃ�
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub COM_TANCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TANCD.Click
		Dim Mst_Inf_TANMTA As TYPE_DB_TANMTA
		
		WLSTAN_RTNCODE = ""

        '�S���Ҍ�����ʃR�[��
        WLSTAN1.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
        WLSTAN1.Close()

        System.Windows.Forms.Application.DoEvents()
		
		'�f�[�^���I�����ꂽ�ꍇ
		If WLSTAN_RTNCODE <> "" Then
			WLSTANCD.Text = WLSTAN_RTNCODE
			
			'�S���҃R�[�h���猟��
			If DSPTANCD_SEARCH(WLSTAN_RTNCODE, Mst_Inf_TANMTA) = 0 Then
				WLSTANNM.Text = Mst_Inf_TANMTA.TANNM
				
				'�I�����ꂽ���̂݌������s��
				Call GET_UDNTRA_NKN()
			Else
				WLSTANNM.Text = ""
			End If
			
			WLSTAN_RTNCODE = ""
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub COM_UDNDT_Click
	'   �T�v�F  �������{�^���N���b�N�C�x���g
	'   �����F�@�Ȃ�
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub COM_UDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_UDNDT.Click
		WLSDATE_RTNCODE = ""
		
		'�J�����_�[��ʃR�[��
		Set_date.Value = CNV_DATE(GV_UNYDate)
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		System.Windows.Forms.Application.DoEvents()
		
		'�f�[�^���I�����ꂽ�ꍇ
		If WLSDATE_RTNCODE <> "" Then
			WLSNDNDT.Text = WLSDATE_RTNCODE
			
			'�I�����ꂽ���̂݌������s��
			Call GET_UDNTRA_NKN()
			
			WLSDATE_RTNCODE = ""
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub COM_TOKCD_Click
	'   �T�v�F  ���Ӑ�{�^���N���b�N�C�x���g
	'   �����F�@�Ȃ�
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		
		WLSTOK_RTNCODE = ""
		
		'���Ӑ挟����ʃR�[��
		WLSTOK6.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
		WLSTOK6.Close()
		
		System.Windows.Forms.Application.DoEvents()
		
		'�f�[�^���I�����ꂽ�ꍇ
		If WLSTOK_RTNCODE <> "" Then
			WLSTOKCD.Text = WLSTOK_RTNCODE
			
			If DSPTOKCD_SEARCH(WLSTOK_RTNCODE, Mst_Inf_TOKMTA) = 0 Then
				WLSTOKRN.Text = Mst_Inf_TOKMTA.TOKRN
				
				'�I�����ꂽ���̂݌������s��
				Call GET_UDNTRA_NKN()
			Else
				WLSTOKRN.Text = ""
			End If
			
			WLSTOK_RTNCODE = ""
		End If
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSNDNDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSNDNDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNDNDT.TextChanged
		WLSNDNDT.SelectionLength = 1
		If pv_blnChange_Flg = True Then
			Exit Sub
		Else
			Call CtrlDatChange(WLSNDNDT)
		End If
	End Sub
	
	Private Sub WLSNDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNDNDT.Click
		WLSNDNDT.SelectionStart = 0
		WLSNDNDT.SelectionLength = 1
	End Sub
	
	Private Sub WLSNDNDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNDNDT.Enter
		If Len(Trim(WLSNDNDT.Text)) = 0 Then
			pv_blnChange_Flg = True
			WLSNDNDT.Text = Space(10)
			pv_blnChange_Flg = False
			WLSNDNDT.SelectionStart = 0
			WLSNDNDT.SelectionLength = 1
		ElseIf Len(Trim(WLSNDNDT.Text)) >= 8 Then 
			WLSNDNDT.SelectionStart = 8
			WLSNDNDT.SelectionLength = 1
		Else
			WLSNDNDT.SelectionStart = 0
			WLSNDNDT.SelectionLength = 1
		End If
	End Sub
	
	Private Sub WLSNDNDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles WLSNDNDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = System.Windows.Forms.Keys.Back Then
			KeyAscii = 0
			pv_blnChange_Flg = True
			If WLSNDNDT.SelectionStart > 0 Then
				WLSNDNDT.SelectionStart = WLSNDNDT.SelectionStart - 1
			End If
			WLSNDNDT.SelectionLength = 1
			Call PrevForcus(WLSNDNDT)
			pv_blnChange_Flg = False
		Else
			' ADD 2007/02/20 ���l�ȊO�͓��͕s��
			Select Case True
				Case (KeyAscii >= Asc("0") And KeyAscii <= Asc("9"))
					
				Case Else
					KeyAscii = 0
			End Select
			' ADD 2007/02/20 ���l�ȊO�͓��͕s��
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub WLSNDNDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSNDNDT.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case True
			'��������
			Case KeyCode = System.Windows.Forms.Keys.Return And Shift = 0
				If Trim(WLSNDNDT.Text) <> "" Then
					If CHECK_DATE(WLSNDNDT) = False Then
						Call MsgBox("���t�Ɍ�肪����܂��B�C�����Ă��������B", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
						WLSNDNDT.Focus()
						Exit Sub
					End If
				End If
				Call GET_UDNTRA_NKN()
				
				'����
			Case KeyCode = System.Windows.Forms.Keys.Right And Shift = 0
				KeyCode = 0
				'������
				If WLSNDNDT.SelectionStart < Len(WLSNDNDT.Text) Then
					WLSNDNDT.SelectionStart = WLSNDNDT.SelectionStart + 1
					WLSNDNDT.SelectionLength = 1
					Call NextForcus(WLSNDNDT)
				End If
				
				'����
			Case KeyCode = System.Windows.Forms.Keys.Down And Shift = 0
				'������
				KeyCode = 0
				
				'����
			Case KeyCode = System.Windows.Forms.Keys.Up And Shift = 0
				'������
				KeyCode = 0
				
				'����
			Case KeyCode = System.Windows.Forms.Keys.Left And Shift = 0
				KeyCode = 0
				'������
				If WLSNDNDT.SelectionStart > 0 Then
					WLSNDNDT.SelectionStart = WLSNDNDT.SelectionStart - 1
					WLSNDNDT.SelectionLength = 1
					Call PrevForcus(WLSNDNDT)
				End If
				
			Case KeyCode = System.Windows.Forms.Keys.Delete And Shift = 0
				KeyCode = 0
				
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSTANCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSTANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTANCD.TextChanged
		Dim S As Integer
		S = WLSTANCD.SelectionStart
		WLSTANCD.Text = StrConv(WLSTANCD.Text, VbStrConv.UpperCase)
		WLSTANCD.SelectionStart = S
	End Sub
	
	Private Sub WLSTANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTANCD.Enter
		WLSTANCD.SelectionStart = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190729 CHG START
        'WLSTANCD.SelectionLength = LenWid(DB_TANMTA.TANCD)
        WLSTANCD.SelectionLength = TANCD_LEN
        '20190729 CHG END

    End Sub

    Private Sub WLSTANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTANCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Mst_Inf_TANMTA As TYPE_DB_TANMTA

        Select Case KeyCode
            Case 13
                '20190729 CHG START
                'WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, LenWid(DB_TANMTA.TANCD), "0")
                WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, TANCD_LEN, "0")
                '20190729 CHG END
                WLSTANCD.SelectionStart = 0
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '20190729 CHG START
                'WLSTANCD.SelectionLength = LenWid(DB_TANMTA.TANCD)
                WLSTANCD.SelectionLength = TANCD_LEN
                '20190729 CHG END

                If Trim(WLSTANCD.Text) = "" Then
                    WLSTANNM.Text = ""
                Else
                    '�S���҃R�[�h���猟�����āA�S���Җ��擾
                    If DSPTANCD_SEARCH(Trim(WLSTANCD.Text), Mst_Inf_TANMTA) = 0 Then
                        WLSTANNM.Text = Mst_Inf_TANMTA.TANNM
                    Else
                        '�S���Җ����Ȃ������x�����N���A����
                        WLSTANNM.Text = ""
                    End If
                End If
                Call GET_UDNTRA_NKN()

            Case 112 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%2")
        End Select

    End Sub

    Private Sub WLSNYUCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSNYUCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000

        '20190823 ADD START
        Dim NYUCDLEN As Integer = 0

        If DB_UDNTHA.NYUCD Is Nothing Then
            NYUCDLEN = 1
        Else
            NYUCDLEN = LenWid(DB_UDNTHA.NYUCD)
        End If
        '20190823 ADD END

        Select Case KeyCode
            Case 13
                '20190823 CHG START
                '            WLSNYUCD.Text = SSS_EDTITM_WLS(WLSNYUCD.Text, LenWid(DB_UDNTHA.NYUCD), "0")
                'WLSNYUCD.SelectionStart = 0
                '            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '            WLSNYUCD.SelectionLength = LenWid(DB_UDNTHA.NYUCD)

                WLSNYUCD.Text = SSS_EDTITM_WLS(WLSNYUCD.Text, NYUCDLEN, "0")
                WLSNYUCD.SelectionStart = 0
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WLSNYUCD.SelectionLength = NYUCDLEN
                '20190823 CHG END

                Call GET_UDNTRA_NKN()
				
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	Private Sub WLSNYUCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNYUCD.Enter
		WLSNYUCD.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSNYUCD.SelectionLength = LenWid(DB_UDNTHA.NYUCD)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSNYUCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSNYUCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNYUCD.TextChanged
		Dim S As Integer
		S = WLSNYUCD.SelectionStart
		WLSNYUCD.Text = StrConv(WLSNYUCD.Text, VbStrConv.UpperCase)
		WLSNYUCD.SelectionStart = S
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSTOKCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSTOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.TextChanged
		Dim S As Integer
		S = WLSTOKCD.SelectionStart
		WLSTOKCD.Text = StrConv(WLSTOKCD.Text, VbStrConv.UpperCase)
		WLSTOKCD.SelectionStart = S
	End Sub
	
	Private Sub WLSTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.Enter
		WLSTOKCD.SelectionStart = 0
		WLSTOKCD.SelectionLength = 0
	End Sub
	
	Private Sub WLSTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTOKCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		
		Select Case KeyCode
			Case 13
				WLSTOKCD.SelectionStart = 0
				WLSTOKCD.SelectionLength = 0
				If Trim(WLSTOKCD.Text) = "" Then
					WLSTOKRN.Text = ""
				Else
					'���Ӑ�R�[�h���猟�����āA���Ӑ於�擾
					If DSPTOKCD_SEARCH(Trim(WLSTOKCD.Text), Mst_Inf_TOKMTA) = 0 Then
						WLSTOKRN.Text = Mst_Inf_TOKMTA.TOKRN
					Else
						'���Ӑ於���Ȃ������x�����N���A����
						WLSTOKRN.Text = ""
					End If
				End If
				Call GET_UDNTRA_NKN()
				
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: Form �C�x���g WLSNDN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSNDN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190726 DEL START
        'Call WLSSSS_FORM_ACTIVATE()
        'DblClickFl = False
        '20190726 DEL END

    End Sub

    Private Sub WLSNDN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call WLS_FORM_LOAD()
        Call WLSSSS_FORM_INIT()

        '20190726 ADD START
        Call WLSSSS_FORM_ACTIVATE()
        DblClickFl = False
        '20190726 ADD END

    End Sub


    '20190726 ADD START
    Private Sub WLSNDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190726 ADD END


    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		DblClickFl = True
		WLSNDN_RTNCODE = LeftWid(VB.Right(VB6.GetItemString(LST1, LST.SelectedIndex), 10), 10) 'DATNO��Ԃ��B
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			Case 13
				WLSNDN_RTNCODE = LeftWid(VB.Right(VB6.GetItemString(LST1, LST.SelectedIndex), 10), 10) 'DATNO��Ԃ��B
                '20190726 CHG START
                'If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                If DblClickFl = False Then Call btnF12_Click(btnF12, New System.EventArgs())
                '20190726 CHG END

            Case 27
                '20190726 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190726 CHG END

            Case 37 '���L�[
                '20190726 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190726 CHG END

            Case 39 '���L�[
                '20190726 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190726 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        '20190726 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190726 CHG END

    End Sub

    '20190726 DEL START
    '   Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
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
    '20190726 DEL END

    '20190726 CHG START
    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	Hide()
    'End Sub

    'Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click

    '	If SSS_CurPage > 1 Then
    '		SSS_CurPage = SSS_CurPage - 1
    '		Call WLS_DIS_CurrentPage(SSS_CurPage)
    '	Else
    '		Call MsgBox("����ȉ��͗L��܂���A�����������ē��͂��ĉ������B", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
    '		Exit Sub
    '	End If

    'End Sub

    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '       If SSS_CurPage < SSS_LastPage Then
    '           SSS_CurPage = SSS_CurPage + 1
    '           Call WLS_DIS_CurrentPage(SSS_CurPage)
    '       Else
    '           Call MsgBox("����ȏ�͗L��܂���A�����������ē��͂��ĉ������B", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, Me.Text)
    '       End If

    '   End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Hide()
    End Sub

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click

        If SSS_CurPage > 1 Then
            SSS_CurPage = SSS_CurPage - 1
            Call WLS_DIS_CurrentPage(SSS_CurPage)
        Else
            Call MsgBox("����ȉ��͗L��܂���A�����������ē��͂��ĉ������B", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

    End Sub

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click

        If SSS_CurPage < SSS_LastPage Then
            SSS_CurPage = SSS_CurPage + 1
            Call WLS_DIS_CurrentPage(SSS_CurPage)
        Else
            Call MsgBox("����ȏ�͗L��܂���A�����������ē��͂��ĉ������B", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, Me.Text)
        End If

    End Sub
    '20190726 CHG END


    '20190726 DEL START
    '   Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
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
    '20190726 DEL END

    '20190726 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub
    '20190726 CHG END

    '20190522 DEL START
    '    Public Function AnsiTrimStringByByteCount(ByRef ArgSrc As String, ByRef ArgCnt As Integer) As String
    '		'�T�v�F�S�p���p�܂���̂t�����b��������������A   ��������
    '		'                   ����������Ȃ��悤�Ɏw�肳�ꂽ�o�C�g���Ɋۂ߂��������Ԃ��B
    '		'                                                 ��������
    '		'�����FArgSrc ,Input ,String ,���̕�����
    '		'�@�@�FArgCnt ,Input ,Long   ,�ۂ߂镶����

    '		Dim strResult As String
    '		Dim strTmpChr As String
    '		Dim lngLength As Integer
    '		Dim lngCalCnt As Integer
    '		Dim lngTmpCnt As Integer
    '		Dim lngI As Integer

    '		strResult = ""
    '		lngLength = Len(Trim(ArgSrc))
    '		lngCalCnt = 0
    '		For lngI = 1 To lngLength
    '			strTmpChr = Mid(ArgSrc, lngI, 1)
    '			lngTmpCnt = AnsiLenB(strTmpChr)
    '			If lngCalCnt + lngTmpCnt > ArgCnt Then
    '				GoTo AnsiTrimStringByByteCount_End
    '			Else
    '				lngCalCnt = lngCalCnt + lngTmpCnt
    '				strResult = strResult & strTmpChr
    '			End If
    '		Next 

    'AnsiTrimStringByByteCount_End: 

    '		If AnsiLenB(strResult) < ArgCnt Then
    '			AnsiTrimStringByByteCount = strResult & New String(" ", ArgCnt - AnsiLenB(strResult))
    '		Else
    '			AnsiTrimStringByByteCount = strResult
    '		End If

    '	End Function

    '	Public Function AnsiTrimStringByMojiCount(ByRef strSrc As String, ByRef lngDstCount As Integer) As String
    '		'�T�v�F�S�p���p�܂���̂t�����b��������������A   ������
    '		'                   ����������Ȃ��悤�Ɏw�肳�ꂽ�������i���o�C�g���j�Ɋۂ߂��������Ԃ��B
    '		'                                                 ������
    '		'�����FstrSrc     ,Input,String,���̕�����
    '		'�@�@�FlngDstCount,Input,Long,�ۂ߂镶����
    '		Dim strDst As String
    '		Dim strTmp As String
    '		Dim lngSrcCount As Integer
    '		Dim lngCalCount As Integer
    '		Dim lngTmpCount As Integer
    '		Dim strFmt As String
    '		Dim lngI As Integer

    '		strDst = ""
    '		lngSrcCount = Len(strSrc)
    '		lngCalCount = 0
    '		For lngI = 1 To lngSrcCount
    '			strTmp = Mid(strSrc, lngI, 1)
    '			lngTmpCount = AnsiLenB(strTmp)
    '			If lngCalCount + lngTmpCount > lngDstCount Then
    '				GoTo AnsiTrimStringByMojiCount_End
    '			Else
    '				lngCalCount = lngCalCount + lngTmpCount
    '				strDst = strDst & strTmp
    '			End If
    '		Next 

    'AnsiTrimStringByMojiCount_End: 

    '		strFmt = "!"
    '		For lngI = 1 To lngDstCount
    '			strFmt = strFmt & "@"
    '		Next 
    '		strDst = VB6.Format(strDst, strFmt)
    '		AnsiTrimStringByMojiCount = strDst

    '	End Function

    '    Public Function AnsiInStrB(ByRef varArg1 As Object, ByRef varArg2 As Object, Optional ByRef varArg3 As Object = Nothing) As Integer
    '		'�T�v�F������ʒu�̌���
    '		'�����FvarArg1,Input,Variant,�����J�n�ʒu or �����Ώە�����
    '		'�@�@�FvarArg2,Input,Variant,����������
    '		'�@�@�FvarArg3,Input,Variant(Optional),����������(�ȗ��\)
    '		'�����`�������R�[�h�̃o�C�g�I�[�_�Ō���������̕����ʒu(������)��Ԃ�
    '		Dim lngPOS As Integer

    '#If Win32 Then
    '		If IsNumeric(varArg1) Then
    '			'UPGRADE_WARNING: �I�u�W�F�N�g varArg1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			'UPGRADE_WARNING: �I�u�W�F�N�g varArg2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '			lngPOS = LenB(AnsiLeftB(varArg2, varArg1))
    '			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '			'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '			AnsiInStrB = InStrB(varArg1, AnsiStrConv(varArg2, vbFromUnicode), AnsiStrConv(varArg3, vbFromUnicode))
    '		Else
    '			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '			'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '			AnsiInStrB = InStrB(AnsiStrConv(varArg1, vbFromUnicode), AnsiStrConv(varArg2, vbFromUnicode))
    '		End If
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		If IsNumeric(varArg1) Then
    '		lngPOS = LenB(LeftB(varArg2, varArg1))
    '		AnsiInStrB = InStrB(varArg1, varArg2, varArg3)
    '		Else
    '		AnsiInStrB = InStrB(varArg1, varArg2)
    '		End If
    '#End If

    '	End Function

    '	Public Function AnsiLeftB(ByVal StrArg As String, ByVal lngArg As Integer) As String
    '		'�T�v�F���l�ߕ�����̒��o
    '		'�����FstrArg,Input,String,���o��������
    '		'�@�@�FlngArg,Input,Long,���o������
    '		'�����F�`�������R�[�h�̃o�C�g�I�[�_�ŕ�����̍��[���當�������̕������Ԃ�

    '#If Win32 Then
    '		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '		'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '		'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), lngArg), vbUnicode)
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		AnsiLeftB = LeftB(StrArg, lngArg)
    '#End If

    '	End Function

    '	Public Function AnsiLenB(ByVal StrArg As String) As Integer
    '		'�T�v�F�������J�E���g
    '		'�����FstrArg,Input,String,�Ώە�����
    '		'�����F�`�������R�[�h�̃o�C�g�I�[�_�ŕ�������޲Đ���Ԃ�

    '#If Win32 Then
    '		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '		AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		AnsiLenB = LenB(StrArg)
    '#End If

    '	End Function

    '	Public Function AnsiMidB(ByVal StrArg As String, ByVal lngArg As Integer, Optional ByRef varArg As Object = Nothing) As String
    '		'�T�v�F������̒��o
    '		'�����FstrArg,Input,String,���o��������
    '		'�@�@�FlngArg,Input,Long,�擪����̒��o�J�n�ʒu
    '		'�@�@�FvarArg,Input,Variant(Optional),���o������(�ȗ��\)
    '		'�����F�`�������R�[�h�̃o�C�g�I�[�_�ŕ�����̒��o�J�n�ʒu���當�������̕������Ԃ�

    '#If Win32 Then
    '		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
    '		If IsNothing(varArg) Then
    '			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '			'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '			'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode), lngArg), vbUnicode)
    '		Else
    '			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '			'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '			'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode), lngArg, varArg), vbUnicode)
    '		End If
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		If IsMissing(varArg) Then
    '		AnsiMidB = MidB(StrArg, lngArg)
    '		Else
    '		AnsiMidB = MidB(StrArg, lngArg, varArg)
    '		End If
    '#End If

    '	End Function

    '	Public Function AnsiRightB(ByVal StrArg As String, ByVal lngArg As Integer) As String
    '		'�T�v�F�E�l�ߕ�����̒��o
    '		'�����FstrArg,Input,String,���o��������
    '		'�@�@�FlngArg,Input,Long,���o������
    '		'�����F�`�������R�[�h�̃o�C�g�I�[�_�ŕ�����̉E�[���當�������̕������Ԃ�

    '#If Win32 Then
    '		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '		'UPGRADE_ISSUE: RightB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '		'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		AnsiRightB = AnsiStrConv(RightB(AnsiStrConv(StrArg, vbFromUnicode), lngArg), vbUnicode)
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		AnsiRightB = RightB(StrArg, lngArg)
    '#End If

    '	End Function
    '20190522 DEL END

    Public Function AnsiStrConv(ByRef varArg As Object, ByRef varCnv As Object) As Object
		'�T�v�F������̺��ޕϊ�
		'�����FvarArg,Input,Variant,�ϊ���������
		'�@�@�FvarCnv,Input,Variant,conversion�萔(StrConv �֐��Q��)
		'�����F�`������ �� �t�����b�������ɕϊ������������Ԃ�
		
#If Win32 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g varCnv �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g varArg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiStrConv = StrConv(varArg, varCnv)
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiStrConv = varArg
#End If
		
	End Function
	
	Private Function CtrlDatChange(ByRef Ctl As System.Windows.Forms.TextBox) As String
		
		Dim lngSelstart As Integer
		Dim Wk_DspMoji As String
		Dim Wk_EditMoji As String
		
		Wk_EditMoji = CnvDspItem_Date(Ctl.Text)
		
		'�ҏW��̕�����\���`���ɕϊ�
		Wk_DspMoji = CnvDspItem_Date(Wk_EditMoji)
		
		pv_blnChange_Flg = True
		lngSelstart = Ctl.SelectionStart
		Ctl.Text = VB.Left(Wk_DspMoji & Space(10), 10)
		Ctl.SelectionStart = lngSelstart
		Ctl.SelectionLength = 1
		'��ݼ޲���ĉ�
		pv_blnChange_Flg = False
		
		'����̫����ʒu����E�ֈړ�
		Call NextForcus(Ctl)
		
	End Function
	
	Private Function PrevForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'    '�ړ��t���O������
		'    pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		
		'���݂�÷�ď�̑I����Ԃ��擾
		Act_SelStart = Ctl.SelectionStart
		Act_SelLength = Ctl.SelectionLength
		Act_SelStr = Ctl.SelectedText
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		
		If Act_SelStart = 0 And Act_SelStrB = 10 Then
			'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
			'�l���������l�̏ꍇ
			'�ŏI������I������
			Ctl.SelectionStart = Len(Ctl.Text) - 1
			Ctl.SelectionLength = 1
		Else
			If Act_SelStart = Len(Ctl.Text) Then
				'�I���J�n�ʒu����ԉE�̏ꍇ
			Else
				'�I���J�n�ʒu����ԉE�łȂ��ꍇ
				
				'�P�E�̂P�����擾
				Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)
				
				If Str_Wk = "" Then
					'��ԉE�ֈړ����I���Ȃ���Ԃ�
					Ctl.SelectionStart = Len(Ctl.Text)
					Ctl.SelectionLength = 0
				Else
					'�E�ɂP�������炵���͉\�ȕ���������
					Next_SelStart = -1
					For Wk_Point = Act_SelStart + 1 To 1 Step -1 ' ADD 2007/02/20
						
						Str_Wk = Mid(Ctl.Text, Wk_Point, 1)
						
						'���t/�N��/�������ڂ̏ꍇ
						'���͉\�������Ƌ󔒂��ړ��\
						If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
							Next_SelStart = Wk_Point - 1
							Exit For
						End If
					Next 
					
					If Next_SelStart = -1 Then
						'�I���\�ȕ������Ȃ��ꍇ
					Else
						'�I���\�ȕ���������ꍇ
						
						If Act_SelLength = 0 Then
							'�ړ��O�̑I�𕶎������Ȃ��ꍇ
							'�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						Ctl.SelectionStart = Next_SelStart
						Ctl.SelectionLength = Wk_SelLength
					End If
				End If
			End If
		End If
		
	End Function
	
	Private Function CnvDspItem_Date(ByVal strValue As String) As String
		
		Dim Rtn_Str_Value As String
		
		Rtn_Str_Value = strValue
		
		'���t�̏ꍇ
		If Trim(Rtn_Str_Value) = "" Then
			'�����͂̏ꍇ
			Rtn_Str_Value = New String(Space(1), 10)
		Else
			'���͂���̏ꍇ
			If Len(Trim(Rtn_Str_Value)) <> Len("YYYYMMDD") Then
				'���͌`�����قȂ�ꍇ
				'�l���������l�̏ꍇ�A�A�l�������o�C�g��(�����Ƃ��Ďg�p)�������ɒǉ�
				Rtn_Str_Value = LTrim(Rtn_Str_Value) & New String(Space(1), 10)
				'�E����o�C�g���������擾
				Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, 10)
			Else
				'�\���`���L
				Rtn_Str_Value = CF_Ctr_AnsiLeftB(VB6.Format(Rtn_Str_Value, "0000/00/00") & New String(Space(1), 10), 10)
			End If
		End If
		
		CnvDspItem_Date = Rtn_Str_Value
		
	End Function
	
	Private Function NextForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'    '�ړ��t���O������
		'    pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		
		'���݂�÷�ď�̑I����Ԃ��擾
		Act_SelStart = Ctl.SelectionStart
		Act_SelLength = Ctl.SelectionLength
		Act_SelStr = Ctl.SelectedText
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		
		If Act_SelStart = 0 And Act_SelStrB = 10 Then
			'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
			'�l���������l�̏ꍇ
			'�ŏI������I������
			Ctl.SelectionStart = Len(Ctl.Text) - 1
			Ctl.SelectionLength = 1
		Else
			If Act_SelStart = Len(Ctl.Text) Then
				'�I���J�n�ʒu����ԉE�̏ꍇ
				Ctl.SelectionStart = Len(Ctl.Text) - 1
				Ctl.SelectionLength = 1
			Else
				'�I���J�n�ʒu����ԉE�łȂ��ꍇ
				
				'�P�E�̂P�����擾
				Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)
				
				If Str_Wk = "" Then
					'��ԉE�ֈړ����I���Ȃ���Ԃ�
					Ctl.SelectionStart = Len(Ctl.Text)
					Ctl.SelectionLength = 0
				Else
					'�E�ɂP�������炵���͉\�ȕ���������
					Next_SelStart = -1
					For Wk_Point = Act_SelStart + 1 To Len(Ctl.Text) Step 1
						
						Str_Wk = Mid(Ctl.Text, Wk_Point, 1)
						
						'���t/�N��/�������ڂ̏ꍇ
						'���͉\�������Ƌ󔒂��ړ��\
						If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
							Next_SelStart = Wk_Point - 1
							Exit For
						End If
					Next 
					
					If Next_SelStart = -1 Then
						'�I���\�ȕ������Ȃ��ꍇ
					Else
						'�I���\�ȕ���������ꍇ
						
						If Act_SelLength = 0 Then
							'�ړ��O�̑I�𕶎������Ȃ��ꍇ
							'�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						Ctl.SelectionStart = Next_SelStart
						Ctl.SelectionLength = Wk_SelLength
					End If
				End If
			End If
		End If
		
	End Function

    '20190522 DEL START
    '   Private Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer

    '	'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '	'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '	CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))

    'End Function

    '   Private Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String

    '       'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '       'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '       'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '       CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)

    '   End Function
    '20190522 DEL END

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_NKNDL01_Clear
    '   �T�v�F  �����f�[�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_NKNDL01_Clear(ByRef pot_DB_NKNDL01 As TYPE_DB_NKNDL01)
		
		Dim Clr_DB_NKNDL01 As TYPE_DB_NKNDL01
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_NKNDL01 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_DB_NKNDL01 = Clr_DB_NKNDL01
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPNKNDL01_SEARCH
	'   �T�v�F  �����f�[�^����
	'   �����F  pin_strTANCD     : ���͒S����
	'           pin_strNYUCD     : �����敪
	'           pin_strNDNDT     : ������
	'           pin_strTOKCD     : ���Ӑ�
	'           pot_DB_NKNDL01   : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function DSPNKNDL01_SEARCH(ByVal pin_strTANCD As String, ByVal pin_strNYUCD As String, ByVal pin_strNDNDT As String, ByVal pin_strTOKCD As String, ByRef pot_DB_NKNDL01() As TYPE_DB_NKNDL01) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strSubSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            '20190522 DEL START
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPNKNDL01_SEARCH
            '20190522 DEL END

            DSPNKNDL01_SEARCH = 9

            '20190619 DEL START URKET52����Ă΂��ꍇ�͕K�v
            'Debug.Print("START " & GetLocalTimeText())
            '20190619 DEL END

            '�߂�l�̃N���A
            Erase pot_DB_NKNDL01

            '�ŐV�̓`�[�ԍ����擾���Ďg��(�����`�[�ԍ�)
            strSubSQL = ""
            strSubSQL = strSubSQL & " SELECT /*+ INDEX UDNTHA X_UDNTHA94 */ MAX(DATNO) AS DATNO "
            strSubSQL = strSubSQL & " FROM UDNTHA "

            '�����F���͒S����
            strSubSQL = strSubSQL & " WHERE OPEID = '" & CF_Ora_Sgl(pin_strTANCD) & "'"
            '    If Trim(pin_strTANCD) <> "" Then
            '        strSubSQL = strSubSQL & " AND OPEID = '" & CF_Ora_Sgl(pin_strTANCD) & "'"
            '    End If

            '�����F�����敪
            strSubSQL = strSubSQL & " AND NYUCD = '" & CF_Ora_Sgl(pin_strNYUCD) & "'"
            '    If Trim(pin_strNYUCD) <> "" Then
            '        strSubSQL = strSubSQL & " AND NYUCD = '" & CF_Ora_Sgl(pin_strNYUCD) & "'"
            '    End If

            '�����F������
            If Trim(pin_strNDNDT) <> "" Then
                strSubSQL = strSubSQL & " AND UDNDT >= '" & CF_Ora_Sgl(pin_strNDNDT) & "'"
            End If

            '�����F���Ӑ�
            If Trim(pin_strTOKCD) <> "" Then
                strSubSQL = strSubSQL & " AND TOKCD >= '" & CF_Ora_Sgl(pin_strTOKCD) & "'"
                strSubSQL = strSubSQL & " AND TOKCD <= '" & CF_Ora_Sgl(pin_strTOKCD) & "'"
            End If

            strSubSQL = strSubSQL & " GROUP BY UDNNO "

            '���C��SQL
            strSQL = ""
            strSQL = strSQL & " SELECT R.DATNO "
            strSQL = strSQL & "      , R.LINNO "
            strSQL = strSQL & "      , R.UDNNO "
            strSQL = strSQL & "      , R.UDNDT "
            strSQL = strSQL & "      , H.NYUCD "
            strSQL = strSQL & "      , (CASE WHEN H.NYUCD = '1' THEN '����' "
            strSQL = strSQL & "              WHEN H.NYUCD = '2' THEN '�O�����' "
            strSQL = strSQL & "              ELSE '' "
            strSQL = strSQL & "         END "
            strSQL = strSQL & "        ) AS NYUNM "
            strSQL = strSQL & "      , NULL AS NYUKB "
            strSQL = strSQL & "      , R.DKBNM "
            strSQL = strSQL & "      , R.TOKCD "
            strSQL = strSQL & "      , R.TOKSEICD "
            strSQL = strSQL & "      , T.TOKRN "
            strSQL = strSQL & "      , (CASE WHEN T.FRNKB = '1' THEN R.FNYUKN "
            strSQL = strSQL & "              ELSE R.NYUKN "
            strSQL = strSQL & "         END "
            strSQL = strSQL & "        ) AS NYUKN "
            strSQL = strSQL & " FROM UDNTHA H "
            strSQL = strSQL & "    , UDNTRA R "
            strSQL = strSQL & "    , (SELECT * FROM TOKMTA WHERE DATKB = '1') T "
            strSQL = strSQL & " WHERE R.DATNO IN ( " & strSubSQL & " ) "
            strSQL = strSQL & "   AND R.DATKB    = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "   AND R.DENKB    = '8' "
            strSQL = strSQL & "   AND R.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
            strSQL = strSQL & "   AND R.DATNO = H.DATNO "
            strSQL = strSQL & "   AND R.TOKSEICD = T.TOKCD (+) "
            ' <02> 2009.03.18 ��ADD
            strSQL = strSQL & "   AND NOT EXISTS (SELECT * FROM UDNTHA B WHERE R.DATNO = B.MOTDATNO)"
            ' <02> 2009.03.18 ��ADD
            strSQL = strSQL & " ORDER BY R.UDNDT "
            strSQL = strSQL & "        , H.NYUCD "
            strSQL = strSQL & "        , R.DKBID "
            strSQL = strSQL & "        , R.TOKSEICD "
            strSQL = strSQL & "        , R.UDNNO "
            strSQL = strSQL & "        , R.LINNO "

            Debug.Print("  SQL " & strSQL)

            'DB�A�N�Z�X
            '20190522 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '20190522 CHG END

            ReDim pot_DB_NKNDL01(0)

            '�擾�f�[�^�ޔ�
            intData = 1
            '20190522 CHG START
            'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            '    ReDim Preserve pot_DB_NKNDL01(intData)

            '    Call DB_NKNDL01_SetData(Usr_Ody_LC, pot_DB_NKNDL01(intData))

            '    Call CF_Ora_MoveNext(Usr_Ody_LC)

            '    intData = intData + 1
            'Loop
            For i As Integer = 0 To dt.Rows.Count - 1
                ReDim Preserve pot_DB_NKNDL01(intData)

                Call Set_DB_NKNDL01(dt, pot_DB_NKNDL01(intData), i)
                intData = intData + 1
            Next
            '20190522 CHG END

            '20190619 DEL START URKET52����Ă΂��ꍇ�͕K�v
            'Debug.Print("E N D " & GetLocalTimeText())
            '20190619 DEL END

            DSPNKNDL01_SEARCH = 0

            'END_DSPNKNDL01_SEARCH:
            '            '�N���[�Y
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPNKNDL01_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPNKNDL01_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function


    '20190522 CHG START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_NKNDL01_SetData
    '   �T�v�F  �����f�[�^�\���̃f�[�^�ޔ�
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Sub DB_NKNDL01_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_NKNDL01 As TYPE_DB_NKNDL01)
    '    '�f�[�^�ޔ�
    '    With pot_DB_NKNDL01
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .DATNO = CF_Ora_GetDyn(pin_Usr_Ody, "DATNO", "") '�`�[�Ǘ�NO.
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .LINNO = CF_Ora_GetDyn(pin_Usr_Ody, "LINNO", "") '�s�ԍ�
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .UDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "UDNNO", "") '����`�[�ԍ�
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .UDNDT = CF_Ora_GetDyn(pin_Usr_Ody, "UDNDT", "") '����`�[���t
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .NYUCD = CF_Ora_GetDyn(pin_Usr_Ody, "NYUCD", "") '�����敪
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .NYUNM = CF_Ora_GetDyn(pin_Usr_Ody, "NYUNM", "") '�����敪����
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .NYUKB = CF_Ora_GetDyn(pin_Usr_Ody, "NYUKB", "") '�������
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .DKBNM = CF_Ora_GetDyn(pin_Usr_Ody, "DKBNM", "") '����敪����
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .TOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .TOKSEICD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSEICD", "") '������R�[�h
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .TOKRN = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRN", "") '���Ӑ旪��
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        .NYUKN = CF_Ora_GetDyn(pin_Usr_Ody, "NYUKN", "") '�����z
    '    End With
    'End Sub

    Private Sub Set_DB_NKNDL01(ByRef pDT As DataTable, ByRef pot_DB_NKNDL01 As TYPE_DB_NKNDL01, ByVal DataCount As Integer)

        With pot_DB_NKNDL01
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .DATNO = DB_NullReplace(pDT.Rows(DataCount)("DATNO"), "") '�`�[�Ǘ�NO.
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .LINNO = DB_NullReplace(pDT.Rows(DataCount)("LINNO"), "") '�s�ԍ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .UDNNO = DB_NullReplace(pDT.Rows(DataCount)("UDNNO"), "") '����`�[�ԍ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .UDNDT = DB_NullReplace(pDT.Rows(DataCount)("UDNDT"), "") '����`�[���t
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NYUCD = DB_NullReplace(pDT.Rows(DataCount)("NYUCD"), "") '�����敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NYUNM = DB_NullReplace(pDT.Rows(DataCount)("NYUNM"), "") '�����敪����
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NYUKB = DB_NullReplace(pDT.Rows(DataCount)("NYUKB"), "") '�������
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .DKBNM = DB_NullReplace(pDT.Rows(DataCount)("DKBNM"), "") '����敪����
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .TOKCD = DB_NullReplace(pDT.Rows(DataCount)("TOKCD"), "") '���Ӑ�R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .TOKSEICD = DB_NullReplace(pDT.Rows(DataCount)("TOKSEICD"), "") '������R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .TOKRN = DB_NullReplace(pDT.Rows(DataCount)("TOKRN"), "") '���Ӑ旪��
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NYUKN = DB_NullReplace(pDT.Rows(DataCount)("NYUKN"), "") '�����z
        End With

    End Sub
    '20190522 CHG END

End Class