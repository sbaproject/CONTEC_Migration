Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSFDN
	Inherits System.Windows.Forms.Form
	'�ȉ��̂S�s�̐ݒ���s������
	Const WM_WLS_MSTKB As String = "1" '�}�X�^�敪(1:���Ӑ� 2:�[�i�� 3:�S���� 4:�d���� 5:���i)
	Const WM_WLSKEY_ZOKUSEI As String = "0" '�J�n�R�[�h���͑��� [0,X]
	
	'�����L�[No�i�g�p���Ȃ��ꍇ��-1��ݒ�j
	Const WM_WLS_TextKey As Short = 2 '�J�n�R�[�h�̃\�[�g�L�[No
	Const WM_WLS_CDKey As Short = -1 '�J�i�����̃\�[�g�L�[No+���L�[
	
	'�E�B���hհ�ް�ݒ�ϐ�
	Dim WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
	Dim WM_WLS_SFIL As Short '�E�B���h�\�����̧��
	
	Dim WM_WLS_LEN As Short '�J�n���ޓ��͕�����
	
	'�E�B���h�����g�p�ϐ�
	Dim WM_WLS_MAX As Short '�P��ʂ̕\������
	Dim WM_WLS_STTKEY As Object '�J�n�L�[
	Dim WM_WLS_ENDKEY As Object '�I���L�[
	Dim WM_WLS_KeyCode As Short '�����ޯ���\���p
	Dim WM_WLS_KeyNo As Short 'Ҳ�̧�ٓǂݍ��݃L�[No
	Dim WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Dim WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	Dim WM_WLS_INIT As Short '�E�B���h�����\���׸�(True or False)
	
	Dim WlsSelList As String
	Dim SWlsSelList As Object
	'''''    Dim WlsHint$
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	
	Private DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07
	
	Private Sub COM_HINCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_HINCD.Click
		Dim I As Short
		Dim W_Key As String
		
		DB_PARA(DBN_HINMTA).KeyBuf = WLSHINCD.Text
		WLSHIN.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
		''98/09/25 �ǉ�
		WLSHIN.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			DB_HINMTA.HINCD = ""
		Else
			'''' UPD 2009/02/20  FKS) S.Nakajima    Start
			'        Call DB_GetEq(DBN_HINMTA, 1, Left$(PP_SSSMAIN.SlistCom, 8), BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_HINMTA, 1, VB.Left(PP_SSSMAIN.SlistCom, 10), BtrNormal)
			'''' UPD 2009/02/20  FKS) S.Nakajima    End
			If DBSTAT = 0 Then
				WLSHINCD.Text = DB_HINMTA.HINCD
				WM_WLS_KeyCode = -1
				WM_WLS_Dspflg = False
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_Pagecnt = -1
				W_Key = SSS_CLTID.Value & SSS_PrgId & "1"
				Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If WLSSSS_SET_KEYBAK() = True Then
					WM_WLS_INIT = 1
					Call WLSSSS_DSP()
				End If
			End If
		End If
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
	
	Private Sub COM_SOUCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_SOUCD.Click
		Dim I As Short
		Dim W_Key As String
		
		DB_PARA(DBN_SOUMTA).KeyBuf = WLSSOUCD.Text
		WLSSOU.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
		''98/09/25 �ǉ�
		WLSSOU.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			DB_SOUMTA.SOUCD = ""
		Else
			Call DB_GetEq(DBN_SOUMTA, 1, PP_SSSMAIN.SlistCom, BtrNormal)
			If DBSTAT = 0 Then
				WLSSOUCD.Text = Trim(DB_SOUMTA.SOUCD)
				WM_WLS_KeyCode = -1
				'Call DB_GetEq(TOKMTA, 1, PP_SSSMAIN.SLISTCOM, BtrNormal)
				'Call WLS_DSP
				
				WM_WLS_Dspflg = False
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_Pagecnt = -1
				W_Key = SSS_CLTID.Value & SSS_PrgId & "1"
				Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If WLSSSS_SET_KEYBAK() = True Then
					WM_WLS_INIT = 1
					Call WLSSSS_DSP()
				End If
			End If
		End If
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
	
	Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
		Dim I As Short
		Dim W_Key As String
		
		DB_PARA(DBN_TOKMTA).KeyBuf = WLSTOKCD.Text
		WLSTOK.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
		''98/09/25 �ǉ�
		WLSTOK.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			DB_TOKMTA.TOKCD = ""
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_TOKMTA, 1, VB.Left(PP_SSSMAIN.SlistCom, 5), BtrNormal)
			If DBSTAT = 0 Then
				WLSTOKCD.Text = Trim(DB_TOKMTA.TOKCD)
				WM_WLS_KeyCode = -1
				WM_WLS_Dspflg = False
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_Pagecnt = -1
				W_Key = SSS_CLTID.Value & SSS_PrgId & "1"
				Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If WLSSSS_SET_KEYBAK() = True Then
					WM_WLS_INIT = 1
					Call WLSSSS_DSP()
				End If
			End If
		End If
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
	
	'UPGRADE_WARNING: Form �C�x���g WLSFDN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSFDN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Call WLSSSS_FORM_ACTIVATE()
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = False
	End Sub
	
	Private Sub WLSFDN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Call WLS_FORM_LOAD()
		Call WLSSSS_FORM_INIT()
	End Sub
	'
	'''''Private Sub HD_TEXT_GotFocus()
	'''''    If LenWid(HD_TEXT.Text) > 0 Then
	'''''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
	'''''    Else
	'''''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
	'''''    End If
	'''''    HD_TEXT.SelStart = 0
	'''''    HD_TEXT.SelLength = HD_TEXT.MaxLength
	'''''End Sub
	'
	'''''Private Sub HD_TEXT_KeyDown(KeyCode As Integer, Shift As Integer)
	'''''    Dim I, STAT%
	'''''
	'''''    Select Case KeyCode
	'''''        Case 13
	'''''            WM_WLS_Dspflg = False
	'''''            HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
	'''''            HD_TEXT.SelStart = 0
	'''''            HD_TEXT.SelLength = HD_TEXT.MaxLength
	'''''            WM_WLS_STTKEY = "11" & HD_TEXT.Text
	'''''            WM_WLS_ENDKEY = Null
	'''''            WM_WLS_KeyCode = 0
	'''''            WM_WLS_Dspflg = True
	'''''            WM_WLS_KeyNo = WM_WLS_TextKey
	'''''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
	'''''            KEYBAK.Clear
	'''''            LST.Clear
	'''''            WM_WLS_Pagecnt = -1
	'''''            If WLSSSS_SET_KEYBAK() = True Then
	'''''                Call WLSSSS_DSP
	'''''            End If
	''''''        Case 40  '���L�[
	''''''            LST.ListIndex = 0
	''''''            LST.SetFocus
	'''''        Case 112  'F��P�L�[
	'''''            SendKeys "%1"
	'''''        Case 113  'F��P�L�[
	'''''            SendKeys "%2"
	'''''    End Select
	'''''End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = True
		
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KEYCODE
			Case 13
				Call WLS_SLIST_MOVE(VB6.GetItemString(LST1, LST.SelectedIndex), WM_WLS_LEN)
				'DblClick�C�x���g��Q�Ή�  97/04/07
				'Call WLSCANCEL_CLICK
				If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case 27
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case 37 '���L�[
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
				'       Case 38  '���L�[
				'           If LST.ListIndex = 0 Then
				'               LST.ListIndex = -1
				'               HD_TEXT.SetFocus
				'           End If
			Case 39 '���L�[
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
	End Sub
	
	Private Sub WLS_DISPLAY()
		'====================================
		'   WINDOW ���ו\��
		'====================================
		Dim WK_TK As New VB6.FixedLengthString(13)
		Dim WK_DENDT As New VB6.FixedLengthString(10)
		Dim WK_NOKDT As New VB6.FixedLengthString(10)
		WK_DENDT.Value = VB.Left(DB_SYKTRA.ODNYTDT, 4) & "/" & Mid(DB_SYKTRA.ODNYTDT, 5, 2) & "/" & VB.Right(DB_SYKTRA.ODNYTDT, 2)
		
		WlsFromWhere = "From SOUMTA Where SOUCD = '" & DB_SYKTRA.OUTSOUCD & "'"
		WlsOrderBy = "Order By SOUCD"
		'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		Call DB_GetSQL2(WM_WLS_SFIL, DB_SQLBUFF)
		
		''    LST.AddItem DB_SYKTRA.JDNNO + "       " + WK_DENDT + " " + Left$(DB_SYKTRA.HINNMA, 30) + " " + Left$(DB_SYKTRA.TOKNMA, 40) + " " + Left$(DB_SOUMTA.SOUNM, 20)
		'''    LST.AddItem DB_SYKTRA.JDNNO + "       " + WK_DENDT + " " + Left(StrConv(DB_SYKTRA.HINNMA, vbWide), 15) + " " + Left(StrConv(DB_SYKTRA.TOKNMA, vbWide), 20) + " " + Left(StrConv(DB_SOUMTA.SOUNM, vbWide), 10)
		''''LST.AddItem DB_SYKTRA.JDNNO + "       " + WK_DENDT + " " + LeftWid$(DB_SYKTRA.HINNMA, 30) + " " + LeftWid$(DB_SYKTRA.TOKNMA, 40) + " " + LeftWid$(DB_SOUMTA.SOUNM, 20)
		LST.Items.Add(VB.Left(DB_SYKTRA.SBNNO, 10) & "  " & WK_DENDT.Value & " " & LeftWid(DB_SYKTRA.HINNMA, 30) & " " & LeftWid(DB_SYKTRA.TOKNMA, 40) & " " & LeftWid(DB_SOUMTA.SOUNM, 20))
		LST1.Items.Add(DB_SYKTRA.JDNNO & DB_SYKTRA.OUTSOUCD & DB_SYKTRA.TOKCD)
	End Sub
	
	Private Function WLS_DSP_CHECK() As Object
		Dim wkTOKCD As String
		Dim wkHINCD As String
		'====================================
		'   WINDOW �\���\�`�F�b�N
		'       WLS_DSP_CHECK = True  :�\����
		'       WLS_DSP_CHECK = FALSE :�\���s��
		'====================================
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLS_DSP_CHECK = SSS_OK
		If DB_SYKTRA.DATKB <> "1" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLS_DSP_CHECK = SSS_END
			Exit Function
		End If
		'''''    If SSSVal(DB_FDNTHA.FDNENDKB) = 8 Or SSSVal(DB_FDNTHA.FDNENDKB) = 7 Then
		'''''        WLS_DSP_CHECK = SSS_NEXT
		'''''    Else
		'''''        WLS_DSP_CHECK = SSS_OK
		'''''        DBSTAT = 0
		'    ElseIf SSSVal(DB_FDNTHA.FDNENDKB) = 9 Then
		'        WLS_DSP_CHECK = WLS_DSP_SUB_CHECK
		'''''    End If
		If WM_WLS_KeyNo = WM_WLS_TextKey Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If DB_SYKTRA.CLTID <> SSS_CLTID.Value Then WLS_DSP_CHECK = SSS_END
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If DB_SYKTRA.PGID <> SSS_PrgId Then WLS_DSP_CHECK = SSS_END
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If DB_SYKTRA.DATKB <> "1" Then WLS_DSP_CHECK = SSS_END
			Select Case HD_WRKKB.Text
				Case "2"
					'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If DB_SYKTRA.WRKKB <> "4" Then WLS_DSP_CHECK = SSS_NEXT
				Case "3"
					'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If DB_SYKTRA.WRKKB <> "6" Then WLS_DSP_CHECK = SSS_NEXT
				Case "4"
					'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If DB_SYKTRA.WRKKB <> "7" Then WLS_DSP_CHECK = SSS_NEXT
				Case "5"
					'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If DB_SYKTRA.WRKKB <> "8" Then WLS_DSP_CHECK = SSS_NEXT
				Case "6"
					If DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Then
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WLS_DSP_CHECK = SSS_NEXT
					End If
				Case Else
					''''''''''''''''If DB_SYKTRA.WRKKB = "1" Or DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Or DB_SYKTRA.WRKKB = "5" Then
					If DB_SYKTRA.WRKKB = "1" Or DB_SYKTRA.WRKKB = "5" Then
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WLS_DSP_CHECK = SSS_NEXT
					End If
			End Select
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If DB_SYKTRA.ODNYTDT > DeCNV_DATE(HD_FDNDT.Text) Then WLS_DSP_CHECK = SSS_NEXT
		End If
		wkTOKCD = WLSTOKCD.Text & Space(Len(DB_SYKTRA.TOKCD) - Len(WLSTOKCD.Text))
		wkHINCD = WLSHINCD.Text & Space(Len(DB_SYKTRA.HINCD) - Len(WLSHINCD.Text))
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (Trim(WLSSOUCD.Text) <> "") And (DB_SYKTRA.OUTSOUCD <> WLSSOUCD.Text) Then WLS_DSP_CHECK = SSS_NEXT
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (Trim(WLSTOKCD.Text) <> "") And (DB_SYKTRA.TOKCD <> wkTOKCD) Then WLS_DSP_CHECK = SSS_NEXT
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (Trim(WLSHINCD.Text) <> "") And (DB_SYKTRA.HINCD <> wkHINCD) Then WLS_DSP_CHECK = SSS_NEXT
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (Trim(WLSHINNMA.Text) <> "") And (InStr(1, DB_SYKTRA.HINNMA, WLSHINNMA.Text) = 0) Then WLS_DSP_CHECK = SSS_NEXT
	End Function
	
	Private Function WLS_DSP_SUB_CHECK() As Object
		Dim WL_OTPSU As Decimal
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_SUB_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLS_DSP_SUB_CHECK = SSS_OK
		Call DB_GetGrEq(DBN_SYKTRA, 1, "1" & DB_SYKTRA.JDNNO, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYKTRA.JDNLINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Do While (DBSTAT = 0) And (DB_SYKTRA.DATKB = "1") And (SSSVal(DB_SYKTRA.JDNLINNO) < 990)
			WL_OTPSU = 0
			Do While (DBSTAT = 0) And (DB_SYKTRA.DATKB = "1")
				Call DB_GetNext(DBN_SYKTRA, BtrNormal)
			Loop 
			WL_OTPSU = DB_SYKTRA.FRDSU - DB_SYKTRA.HIKSU
			If WL_OTPSU > 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_SUB_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_SUB_CHECK = SSS_OK
				DBSTAT = 0
				Exit Function
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_SUB_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_SUB_CHECK = SSS_NEXT
			End If
			Call DB_GetNext(DBN_SYKTRA, BtrNormal)
		Loop 
		DBSTAT = 0
	End Function
	
	Private Sub WLS_FORM_LOAD()
		
		'=== WINDOW �ʒu�ݒ� ===
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		
		'=== ����TEXT ===
		'WLSTOKCD.Height = 285
		'WLSRN.Height = 285
		'WLSTOKCD.Text = ""
		
		'=== WINDOW �\���t�@�C���ݒ� ===
		WM_WLS_MFIL = DBN_SYKTRA
		WM_WLS_SFIL = DBN_SOUMTA
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SWlsSelList = "*"
		
		
		'=== �\���J�n�R�[�h�����ݒ� ===
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(DB_SYKTRA.TOKCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(DB_SYKTRA.OUTSOUCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_LEN = LenWid(DB_SYKTRA.JDNNO) + LenWid(DB_SYKTRA.OUTSOUCD) + LenWid(DB_SYKTRA.TOKCD)
		
		'=== �k�`�a�d�k�ݒ� ===
		''''WLSLABEL = "�󒍔ԍ�or����   �o�׎w���� �^ ��                          ���Ӑ�@�@�@�@�@�@�@�@�@�@�@           �@�q�ɖ�"
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSLABEL = "����        �o�׎w���� �^ ��                          ���Ӑ�@�@�@�@�@�@�@�@�@�@�@           �@�q�ɖ�"
		
		'=== �R���{�a�n�w�ݒ� ===
		'''''    WLSCOMBO.AddItem "�`�[No.��"
		'''''    WLSCOMBO.AddItem "���Ӑ揇"
		'''''    WLSCOMBO.ListIndex = 0
		WM_WLS_INIT = 0
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		Dim WL_Key As String
		
		If LST.Items.Count > 0 Then
			If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
				Exit Sub
			Else
				If (WM_WLS_Pagecnt + 1) > (KEYBAK.Items.Count - 1) Then
					'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
					'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If WLSSSS_SET_KEYBAK() = False Then Exit Sub
				Else
					WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
					WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
					Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
				End If
				Call WLSSSS_DSP()
			End If
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
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		'Unload Me
		Hide()
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSHINCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSHINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSHINCD.TextChanged
		Dim s As Integer
		s = WLSHINCD.SelectionStart
		WLSHINCD.Text = StrConv(WLSHINCD.Text, VbStrConv.UpperCase)
		WLSHINCD.SelectionStart = s
	End Sub
	
	Private Sub WLSHINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSHINCD.Enter
		WLSHINCD.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSHINCD.SelectionLength = LenWid(WLSHINCD.Text)
	End Sub
	
	Private Sub WLSHINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSHINCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = SSS_CLTID.Value & SSS_PrgId & "1"
			Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			Else
				LST.Items.Clear()
				LST1.Items.Clear()
			End If
		End If
	End Sub
	
	Private Sub WLSHINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSHINCD.Leave
		''    Dim I As Integer
		''    Dim W_Key As String
		''
		''    WM_WLS_Dspflg = False
		''    WM_WLS_KeyCode = 0
		''    WM_WLS_Dspflg = True
		''    WM_WLS_Pagecnt = -1
		''    ''98/09/25 �폜
		''    ''WM_WLS_KeyNo = WM_WLS_TextKey
		''    W_Key = "1"
		''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
		''    If WLSSSS_SET_KEYBAK() = True Then
		''        WM_WLS_INIT = 1
		''        Call WLSSSS_DSP
		''    Else
		''        LST.Clear
		''    End If
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSHINNMA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSHINNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSHINNMA.TextChanged
		Dim s As Integer
		s = WLSHINNMA.SelectionStart
		WLSHINNMA.Text = StrConv(WLSHINNMA.Text, VbStrConv.UpperCase)
		WLSHINNMA.SelectionStart = s
	End Sub
	
	Private Sub WLSHINNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSHINNMA.Enter
		WLSHINNMA.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSHINNMA.SelectionLength = LenWid(WLSHINNMA.Text)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSSOUCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSSOUCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSSOUCD.TextChanged
		Dim s As Integer
		s = WLSSOUCD.SelectionStart
		WLSSOUCD.Text = StrConv(WLSSOUCD.Text, VbStrConv.UpperCase)
		WLSSOUCD.SelectionStart = s
	End Sub
	
	Private Sub WLSSOUCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSSOUCD.Enter
		WLSSOUCD.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSSOUCD.SelectionLength = LenWid(WLSSOUCD.Text)
	End Sub
	
	Private Sub WLSSOUCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSSOUCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = SSS_CLTID.Value & SSS_PrgId & "1"
			Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			Else
				LST.Items.Clear()
				LST1.Items.Clear()
			End If
		End If
	End Sub
	
	Private Sub WLSSOUCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSSOUCD.Leave
		''    Dim I As Integer
		''    Dim W_Key As String
		''
		''    WM_WLS_Dspflg = False
		''    WM_WLS_KeyCode = 0
		''    WM_WLS_Dspflg = True
		''    WM_WLS_Pagecnt = -1
		''    ''98/09/25 �폜
		''    ''WM_WLS_KeyNo = WM_WLS_TextKey
		''    W_Key = "1"
		''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
		''    If WLSSSS_SET_KEYBAK() = True Then
		''        WM_WLS_INIT = 1
		''        Call WLSSSS_DSP
		''    Else
		''        LST.Clear
		''    End If
		''
	End Sub
	
	Private Sub WLSHINNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSHINNMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = SSS_CLTID.Value & SSS_PrgId & "1"
			Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			Else
				LST.Items.Clear()
				LST1.Items.Clear()
			End If
		End If
	End Sub
	
	Private Sub WLSHINNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSHINNMA.Leave
		''    Dim I As Integer
		''    Dim W_Key As String
		''
		''    WM_WLS_Dspflg = False
		''    WM_WLS_KeyCode = 0
		''    WM_WLS_Dspflg = True
		''    WM_WLS_Pagecnt = -1
		''    ''98/09/25 �폜
		''    ''WM_WLS_KeyNo = WM_WLS_TextKey
		''    W_Key = "1"
		''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
		''    If WLSSSS_SET_KEYBAK() = True Then
		''        WM_WLS_INIT = 1
		''        Call WLSSSS_DSP
		''    Else
		''        LST.Clear
		''    End If
		
	End Sub
	
	Private Sub WLSTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.Enter
		WLSTOKCD.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSTOKCD.SelectionLength = LenWid(WLSTOKCD.Text)
	End Sub
	
	Private Sub WLSTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTOKCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = SSS_CLTID.Value & SSS_PrgId & "1"
			Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			''        WM_WLS_INIT = 1
			''        Call WLSSSS_DSP
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			Else
				LST.Items.Clear()
				LST1.Items.Clear()
			End If
		End If
	End Sub
	
	Private Sub WLSTOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.Leave
		''    Dim I As Integer
		''    Dim W_Key As String
		''
		''    WM_WLS_Dspflg = False
		''    WM_WLS_KeyCode = 0
		''    WM_WLS_Dspflg = True
		''    WM_WLS_Pagecnt = -1
		''    ''98/09/25 �폜
		''    ''WM_WLS_KeyNo = WM_WLS_TextKey
		''    W_Key = "1"
		''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
		''    If WLSSSS_SET_KEYBAK() = True Then
		''        WM_WLS_INIT = 1
		''        Call WLSSSS_DSP
		''    Else
		''        LST.Clear
		''    End If
		
	End Sub
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		Dim WL_Key As String
		
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
		Else
			Exit Sub
		End If
		WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
		Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
		Call WLSSSS_DSP()
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
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub WLSSSS_DSP()
		Dim WL_Mode As Short
		Dim WL_Key As String
		
		If WM_WLS_Dspflg = False Then Exit Sub
		
		LST.Items.Clear()
		LST1.Items.Clear()
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (LST.Items.Count < WM_WLS_MAX) And (WL_Mode <> SSS_END)
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WL_Mode = WLSSSS_DSP_CHECK()
				If WL_Mode = SSS_OK Then
					'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WL_Mode = WLS_DSP_CHECK()
					If WL_Mode = SSS_OK Then
						Call WLS_DISPLAY()
					End If
				End If
				If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
					Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
				ElseIf WL_Mode = SSS_RPSN Then 
					'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WL_Key = WLSSSS_RPSN()
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If LenWid(WL_Key) = 0 Then
						Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
					Else
						Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
					End If
				ElseIf WL_Mode = SSS_NPSN Then 
					'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WL_Key = WLSSSS_NPSN()
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If LenWid(WL_Key) = 0 Then
						Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
					Else
						Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
					End If
				End If
			Loop 
			If LST.Items.Count > 0 Then
				LST.SelectedIndex = 0
			End If
		End If
		If (DBSTAT <> 0) Or (WL_Mode = SSS_END) Then
			If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) <> HighValue(1)) Then
				KEYBAK.Items.Add(HighValue(1))
			End If
		End If
	End Sub
	
	Private Function WLSSSS_DSP_CHECK() As Object
		Dim CHKDAT As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSSSS_DSP_CHECK = SSS_OK
		
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If Not IsDbNull(WM_WLS_ENDKEY) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WM_WLS_ENDKEY) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LeftWid(DB_PARA(WM_WLS_MFIL).KeyBuf, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLSSSS_DSP_CHECK = SSS_END
				Exit Function
			End If
		End If
		
	End Function
	
	Private Sub WLSSSS_FORM_ACTIVATE()
		Dim I As Short
		Dim W_Key As String
		
		WM_WLS_Dspflg = False
		WM_WLS_KeyCode = 2
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		''98/09/25 �폜
		''WM_WLS_KeyNo = WM_WLS_TextKey
		W_Key = SSS_CLTID.Value & SSS_PrgId & "1"
		Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WLSSSS_SET_KEYBAK() = True And WM_WLS_INIT = 0 Then
			WM_WLS_INIT = 1
			Call WLSSSS_DSP()
		End If
	End Sub
	
	Private Sub WLSSSS_FORM_INIT()
		Dim I As Short
		
		WM_WLS_KeyCode = False
		WM_WLS_MAX = VB6.PixelsToTwipsY(LST.Height) \ 225
		
		WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
		'HD_TEXT.Height = 285
		'''''    HD_TEXT.MaxLength = WM_WLS_LEN
		'''''    HD_TEXT.Width = (WM_WLS_LEN + 1) * 100
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_STTKEY = SSS_CLTID.Value & SSS_PrgId & "1"
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_ENDKEY = SSS_CLTID.Value & SSS_PrgId & "9"
		'''''    HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
		'''''    If LenWid(Trim$(DB_PARA(WM_WLS_MFIL).KeyBuf)) = 0 Then
		'''''        HD_TEXT.Text = ""
		'''''    End If
		''98/09/25 �ǉ�
		WM_WLS_KeyNo = WM_WLS_TextKey
		Select Case MidWid(DB_PARA(WM_WLS_MFIL).KeyBuf, 14, 1)
			Case "2"
				HD_WRKNM.Text = "�ʔ�"
			Case "3"
				HD_WRKNM.Text = "�����s��"
			Case "4"
				HD_WRKNM.Text = "����"
			Case "5"
				HD_WRKNM.Text = "�x���i"
			Case "6"
				HD_WRKNM.Text = "�ړ�"
			Case Else
				HD_WRKNM.Text = "�ʏ�"
		End Select
		HD_WRKKB.Text = MidWid(DB_PARA(WM_WLS_MFIL).KeyBuf, 14, 1)
		HD_FDNDT.Text = MidWid(DB_PARA(WM_WLS_MFIL).KeyBuf, 15, 10)
		WLSSOUCD.Text = ""
		WLSTOKCD.Text = ""
		WLSHINCD.Text = ""
		WLSHINNMA.Text = ""
		
	End Sub
	
	Private Function WLSSSS_NPSN() As Object
		Dim WL_Key As String
		WL_Key = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSSSS_NPSN = WL_Key
	End Function
	
	Private Function WLSSSS_RPSN() As Object
		Dim WL_Key As String
		WL_Key = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSSSS_RPSN = WL_Key
	End Function
	
	Private Function WLSSSS_SET_KEYBAK() As Object
		Dim WL_Mode As Short
		Dim WL_Key As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSSSS_SET_KEYBAK = True
		
		LST.Items.Clear()
		LST1.Items.Clear()
		Do While DBSTAT = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_Mode = WLSSSS_DSP_CHECK()
			If WL_Mode = SSS_OK Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WL_Mode = WLS_DSP_CHECK()
				If WL_Mode = SSS_OK Then
					WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
					KEYBAK.Items.Add(DB_PARA(WM_WLS_MFIL).KeyBuf)
				End If
			End If
			If WL_Mode = SSS_NEXT Then
				Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
			ElseIf WL_Mode = SSS_RPSN Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WL_Key = WLSSSS_RPSN()
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If LenWid(WL_Key) = 0 Then
					Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
				Else
					Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
				End If
			ElseIf WL_Mode = SSS_NPSN Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WL_Key = WLSSSS_NPSN()
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If LenWid(WL_Key) = 0 Then
					Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
				Else
					Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
				End If
			Else
				Exit Do
			End If
		Loop 
		If DBSTAT <> 0 Or WL_Mode = SSS_END Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLSSSS_SET_KEYBAK = False
		End If
	End Function
End Class