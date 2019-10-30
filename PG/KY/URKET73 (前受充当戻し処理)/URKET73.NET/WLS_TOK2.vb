Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_TOK2
	Inherits System.Windows.Forms.Form
	'*************************************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@����������� �� �����挟���ɉ��� 2007/03/05 Saito
	'*  �v���O�����h�c�@�F  WLS_MEI
	'*  �쐬�ҁ@�@�@�@�@�F�@SYSTEM CREATE Co.,Ltd.
	'*  �쐬���@�@�@�@�@�F  2006.10.21
	'*------------------------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'*************************************************************************************************
	
	'************************************************************************************
	'   Private�萔
	'************************************************************************************
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]
	
	'************************************************************************************
	'   Private�ϐ�
	'************************************************************************************
	'�E�B���hհ�ް�ݒ�ϐ�
	Private WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
	Private WM_WLS_CODELEN As Short '�J�n���ޓ��͕�����
	Private WM_WLS_NAMELEN As Short '���Ӑ旪�̓��͕�����
	
	'�E�B���h�����g�p�ϐ�
	Private WM_WLS_MAX As Short '�P��ʂ̕\������
	Private WM_WLS_CODE As String '������ʃR�[�h�����p
	Private WM_WLS_MEIRN As String '������ʗ��̌����p
	Private WM_WLS_TOKNK_S As String '������ʌ����p(�J�n)
	Private WM_WLS_TOKNK_E As String '������ʌ����p(�I��)
	Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Usr_Ody As U_Ody '�ް��ް����ð���
	
	Private DB_TOKMTA_W As TYPE_DB_TOKMTA '�������ʑޔ�
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_FORM_INIT
	'   �T�v�F  ��ʏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		
		'=== �\���J�n�R�[�h�����ݒ� ===
		WM_WLS_CODELEN = 10
		WM_WLS_MAX = 15 '��ʕ\������
		'�ϐ�������
		WLSTOK_RTNCODE = ""
		Call WLS_Clear()
		
		'�������ڃN���A
		HD_TEXT.Text = ""
		HD_RN.Text = ""
		'�R���{�{�b�N�X�Z�b�g
		WLS_Kana_Init()
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
		
		Dim WK_ZEINM, WK_KESNM, WK_SMENM As String
		Dim WK_TK As New VB6.FixedLengthString(13)
		Dim WK_KESDD As String
		'
		Select Case SSSVal(DB_TOKMTA_W.TOKZEIKB)
			Case 1
				WK_ZEINM = "�Ŕ�  "
			Case 2
				WK_ZEINM = "�ō�  "
			Case 9
				WK_ZEINM = "�ΏۊO"
			Case Else
				WK_ZEINM = "      "
		End Select
		'
		Select Case SSSVal(DB_TOKMTA_W.TOKSMEKB)
			Case 1
				WK_SMENM = DB_TOKMTA_W.TOKSMEDD & "����    "
				Select Case SSSVal(DB_TOKMTA_W.TOKKESCC)
					Case 0
						WK_KESNM = "  ����"
					Case 1
						WK_KESNM = "  ����"
					Case 2
						WK_KESNM = "���X��"
					Case Else
						WK_KESNM = "���̑�"
				End Select
				WK_KESNM = WK_KESNM & DB_TOKMTA_W.TOKKESDD & "�����"
			Case 2
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMTA_W.TOKSDWKB)) & "��      " & SSS_WEEKNM(SSSVal(DB_TOKMTA_W.TOKKDWKB)) & "���"
			Case Else
				WK_SMENM = Space(8)
		End Select
		'
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_TOKMTA_W.TOKCD, 5) & Space(5) & LeftWid(DB_TOKMTA_W.TOKRN, 40) & Space(1) & WK_SMENM & WK_KESNM & Space(2) & WK_ZEINM & Space(2) & LeftWid(DB_TOKMTA_W.TOKTL, 13) & Space(1) & LeftWid(DB_TOKMTA_W.TOKSEICD, 5)
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_TextSQL
	'   �T�v�F  ����sql�쐬
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Sub WLS_TextSQL()
		
		Dim strSql As String
		Dim intData As Short
		
		strSql = "SELECT * FROM tokmta " & "WHERE datkb = '1' AND frnkb = '0' AND dspkb = '1' "
		'������������A�����Ώۋ敪���P�̂ݕ\��
		
		'�J�n���ނ����͂���Ă��鎞
		If Trim(HD_TEXT.Text) <> "" Then
			strSql = strSql & "AND tokcd >= '" & RTrim(HD_TEXT.Text) & "' "
		End If
		
		'���Ӑ旪�̖������͂���Ă��鎞(�����܂������Ƃ���)
		If Trim(HD_RN.Text) <> "" Then
			strSql = strSql & "AND tokrn LIKE '%" & RTrim(HD_RN.Text) & "%' "
		End If
		
		'���Ӑ�J�i����
		If Trim(WM_WLS_TOKNK_S) <> "" Then
			strSql = strSql & "AND TOKNK >= '" & WM_WLS_TOKNK_S & "' And TOKNK < '" & WM_WLS_TOKNK_E & "' "
			
		End If
		
		'�������
		If Trim(WM_WLS_TOKNK_S) <> "" Then
			strSql = strSql & "ORDER BY toknk, tokcd"
		Else
			strSql = strSql & "ORDER BY tokcd"
		End If
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
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
		Dim Wk_Pagecnt As Short
		
		Cnt = 0
		Wk_Pagecnt = -1
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			'�擾���e�ޔ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '���Ӑ旪��
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "") '����ŋ敪
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "") '���敪
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "") '���������t�i����j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "") '����T�C�N�����������t�i����j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "") '������t
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "") '����j��
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "") '���ߗj��
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "") '���Ӑ�d�b�ԍ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTA_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "") '������R�[�h
			
			
			'�\�����y�[�W
			If Cnt Mod WM_WLS_MAX = 0 Then
				Wk_Pagecnt = Wk_Pagecnt + 1
				'�ŏI�y�[�W�ޔ�
				WM_WLS_LastPage = Wk_Pagecnt
				ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
				Cnt = 0
			End If
			
			'�\���������W�J
			Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + Cnt)
			
			Cnt = Cnt + 1
			
			Call CF_Ora_MoveNext(Usr_Ody)
		Loop 
		
		'�擾�f�[�^�L���Ɋւ�炸�ŏI�f�[�^���B
		WM_WLS_LastFL = True
		
		If Cnt > 0 Then
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
	Private Sub WLS_Clear()
		'Sub WLS_Clear
		
		'��������
		WM_WLS_CODE = ""
		WM_WLS_MEIRN = ""
		WM_WLS_TOKNK_S = ""
		WM_WLS_TOKNK_E = ""
		
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
	'UPGRADE_WARNING: Form �C�x���g WLS_TOK2.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLS_TOK2_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		
		WM_WLS_Dspflg = False
		
		'���ڏ�����
		'Call WLS_Kana_Init
		'HD_CODE.Text = ""
		'HD_NAME.Text = ""
		'WLSKANA.ListIndex = 0
		LST.Items.Clear()
		WM_WLS_Dspflg = True
		
		ReDim WM_WLS_DSPArray(0)
		
		'������ԑS���\��
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		DblClickFl = False
		
		Me.Refresh()
		'HD_CODE.SetFocus
	End Sub
	
	Private Sub WLS_TOK2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'WINDOW �ʒu�ݒ�
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		'Window�����ݒ�
		Call WLS_FORM_INIT()
	End Sub
	
	'���Ӑ旪�̍��ڂŃL�[����������
	Private Sub HD_RN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_RN.Enter
		'�S�I����Ԃɂ���
		HD_RN.SelectionStart = 0
		HD_RN.SelectionLength = 40
	End Sub
	
	'���Ӑ旪�̍��ڂŃL�[����������
	Private Sub HD_RN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_RN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Enter�������ɍČ��������s
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WLSKANA.SelectedIndex = -1
			Call WLS_Clear()
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	'���Ӑ溰�ލ��ڂɃt�H�[�J�X���ړ�������
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		'�S�I����Ԃɂ���
		HD_TEXT.SelectionStart = 0
		HD_TEXT.SelectionLength = 5
	End Sub
	
	'���Ӑ溰�ލ��ڂŃL�[����������
	Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Enter�������ɍČ��������s
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WLSKANA.SelectedIndex = -1
			Call WLS_Clear()
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	'''Private Sub HD_CODE_GotFocus()
	'''    If LenWid(HD_CODE.Text) > 0 Then
	'''        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
	'''    Else
	'''        HD_CODE.Text = Space$(HD_CODE.MaxLength)
	'''    End If
	'''    HD_CODE.SelStart = 0
	'''    HD_CODE.SelLength = HD_CODE.MaxLength
	'''End Sub
	'''
	'''Private Sub HD_CODE_KeyDown(KeyCode As Integer, Shift As Integer)
	'''    If KeyCode = vbKeyReturn Then
	'''        WM_WLS_Dspflg = False
	'''        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
	'''
	'''        '�����p�ϐ��Z�b�g
	'''        Call WLS_Clear
	'''        WM_WLS_CODE = HD_CODE.Text
	'''
	'''        '�����������N���A
	'''        WM_WLS_Dspflg = True
	'''
	'''        Call WLS_TextSQL
	'''        Call WLS_DspNew
	'''    End If
	'''End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KEYCODE
			'Enter�L�[����
			Case System.Windows.Forms.Keys.Return
				Call WLSOK_Click(WLSOK, New System.EventArgs())
				
				'Escape�L�[����
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
				
				'���L�[����
			Case System.Windows.Forms.Keys.Left
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
				
				'���L�[����
			Case System.Windows.Forms.Keys.Right
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspPage()
		Else
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_DspPage()
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
	
	
	'UPGRADE_WARNING: �C�x���g WLSKANA.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSKANA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKANA.SelectedIndexChanged
		Dim W_BUF As New VB6.FixedLengthString(2)
		
		Call WLS_Clear()
		
		'�����p�ϐ��Z�b�g
		If WLSKANA.SelectedIndex > 0 Then
			W_BUF.Value = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
			WM_WLS_TOKNK_S = VB.Left(W_BUF.Value, 1)
			WM_WLS_TOKNK_E = Chr(Asc(VB.Right(W_BUF.Value, 1)) + 1)
			'�����������N���A
			HD_TEXT.Text = ""
			HD_RN.Text = ""
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		Else
			'            W_BUF = ""
			'            WM_WLS_TOKNK_S = ""
			'            WM_WLS_TOKNK_E = ""
			'�����������N���A
			HD_TEXT.Text = ""
			HD_RN.Text = ""
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
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
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		Hide()
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Kana_Init
	'   �T�v�F  �J�i�R���{�{�b�N�X������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Kana_Init()
		
		'�J�i���� Combo ������
		WLSKANA.Items.Clear()
		WLSKANA.Items.Add("�R�[�h")
		WLSKANA.Items.Add("�A�s      ��")
		WLSKANA.Items.Add("�J�s      ��")
		WLSKANA.Items.Add("�T�s      ��")
		WLSKANA.Items.Add("�^�s      ��")
		WLSKANA.Items.Add("�i�s      ��")
		WLSKANA.Items.Add("�n�s      ��")
		WLSKANA.Items.Add("�}�s      ��")
		WLSKANA.Items.Add("���s      ��")
		WLSKANA.Items.Add("���s      ��")
		WLSKANA.Items.Add("���s      ��")
		
	End Sub
End Class