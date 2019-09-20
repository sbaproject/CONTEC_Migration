Option Strict Off
Option Explicit On
Friend Class WLSEND
	Inherits System.Windows.Forms.Form
	
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@�G���h���[�U����
	'*  �v���O�����h�c�@�F  WLSEND
	'*  �쐬�ҁ@�@�@�@�@�F�@FWEST)����
	'*  �쐬���@�@�@�@�@�F  2013.07.19
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
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]

    '************************************************************************************
    '   Private�ϐ�
    '************************************************************************************
    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 chg start
    'Private WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    Private WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    '20190619 chg end
    Private WM_WLS_CODELEN As Short '�G���h���[�U�R�[�h�\��������
	Private WM_WLS_NAMELEN As Short '�G���h���[�U���̓��͕�����
	
	'�E�B���h�����g�p�ϐ�
	Private WM_WLS_MAX As Short '�P��ʂ̕\������
	Private WM_WLS_NAME As String '�G���h���[�U�����p
	Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    'Private Usr_Ody As U_Ody '�ް��ް����ð���
	Private Dyn_Open As Boolean '�_�C�i�Z�b�g��ԁiTrue:Open False:Close)
	
	Private WM_WLS_ENDUSRCD As String '�G���h���[�U�R�[�h
	Private WM_WLS_ENDUSRNM As String '�G���h���[�U����
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_FORM_INIT
	'   �T�v�F  ��ʏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		
		'=== �\���J�n�R�[�h�����ݒ� ===
		'�G���h���[�U�Ή�2 CHG START �x�m��)���{ 2018/05/18
		'�؂��镶������6������9�����֕ύX
		'WM_WLS_CODELEN = 6
		WM_WLS_CODELEN = 9
		'�G���h���[�U�Ή�2 CHG END   �x�m��)���{ 2018/05/18
		WM_WLS_MAX = 20 '��ʕ\������
		'�ϐ�������
		WLSMEI_RTNMEICDA = ""
		Call WLS_Clear()
		'�߂�l�ݒ�
		gv_bolEndUsrFlg = False
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_SetArray
	'   �T�v�F  ���X�g�ҏW
	'   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'CHG STRAT 2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
	'Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)
	Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)
		'CHG END   2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
		'====================================
		'   WINDOW ���אݒ�
		'====================================
		
		WM_WLS_DSPArray(ArrayCnt) = WM_WLS_ENDUSRCD & Space(5) & WM_WLS_ENDUSRNM
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
		
		'20171220 CIS)�����@�C���@�J�n�@����հ�ޑΉ��Q
		'        strSQL = ""
		'        strSQL = strSQL & " Select Trim(MEICDA) CODE "       '�R�[�h�P
		'        strSQL = strSQL & "      , RTrim(MEINMA) || RTrim(MEINMB) || RTrim(MEINMC) NAME"     '����
		'        strSQL = strSQL & " from   MEIMTA "                  '���̃}�X�^
		'        strSQL = strSQL & " Where  DATKB = '" & gc_strDATKB_USE & "' "          '�`�[�폜�敪
		'        strSQL = strSQL & " And    KEYCD = '" & gc_strKEYCD_ENDUSRKB & "' "     '�L�[
		'        strSQL = strSQL & " And    TO_MULTI_BYTE(UPPER(Rtrim(MEINMA)) || UPPER(Rtrim(MEINMB)) || UPPER(Rtrim(MEINMC))) LIKE TO_MULTI_BYTE(UPPER('%" & CF_Ora_String(WM_WLS_NAME, CF_Ctr_AnsiLenB(WM_WLS_NAME)) & "%'))"     '�����\���敪
		'        strSQL = strSQL & " order by "
		'        strSQL = strSQL & "        MEICDA "         '�R�[�h�P
		strSQL = ""
		strSQL = strSQL & " Select Trim(ENDUSRCD) CODE " '�R�[�h
		strSQL = strSQL & "      , Trim(ENDUSRNM) NAME" '����
		strSQL = strSQL & " from   ENDMTA " '����հ�ރ}�X�^
        strSQL = strSQL & " Where  DATKB = '" & gc_strDATKB_USE & "' " '�`�[�폜�敪
        '20190517 CHG START
        'strSQL = strSQL & " And    TO_MULTI_BYTE(UPPER(Trim(ENDUSRNM))) LIKE TO_MULTI_BYTE(UPPER('%" & CF_Ora_String(WM_WLS_NAME, CF_Ctr_AnsiLenB(WM_WLS_NAME)) & "%'))" '�����\���敪
        strSQL = strSQL & " And    UPPER(Trim(ENDUSRNM)) LIKE UPPER('%" & CF_Ora_String(WM_WLS_NAME, CF_Ctr_AnsiLenB(WM_WLS_NAME)) & "%')" '�����\���敪
        '20190517 CHG END
        strSQL = strSQL & " order by "
        strSQL = strSQL & "        ENDUSRCD " '�R�[�h
        '20171220 CIS)�����@�C���@�I��

        'DB�A�N�Z�X
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        DB_GetTable(strSQL)
		
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
		'CHG START 2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
		'Dim Wk_Pagecnt      As Integer
		Dim Wk_Pagecnt As Integer
		'CHG END   2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
		'ADD START 2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
		Dim wk_Listcnt As Integer '�z��̗v�f��
		Dim wk_Pagecnt1 As Integer
		Dim wk_WM_WLS_MAX As Integer
		Dim wk_Pagecnt_long As Integer
		Dim wk_Cnt_long As Integer
		Dim wk_Setarray As Integer
		wk_Listcnt = 0
		wk_Pagecnt1 = 0
		wk_WM_WLS_MAX = 0
		wk_Pagecnt_long = 0
		wk_Cnt_long = 0
		wk_Setarray = 0
		'ADD END   2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
		
		Cnt = 0
        Wk_Pagecnt = -1
        '20190319 CHG START 
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '    '�擾���e�ޔ�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    WM_WLS_ENDUSRCD = CF_Ora_GetDyn(Usr_Ody, "CODE", "") '�R�[�h�P
        '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    WM_WLS_ENDUSRNM = CF_Ora_GetDyn(Usr_Ody, "NAME", "") '����

        '    '�\�����y�[�W
        '    If Cnt Mod WM_WLS_MAX = 0 Then
        '        Wk_Pagecnt = Wk_Pagecnt + 1
        '        '�ŏI�y�[�W�ޔ�
        '        WM_WLS_LastPage = Wk_Pagecnt
        '        'CHG START 2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
        '        'ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
        '        wk_Pagecnt1 = (Wk_Pagecnt + 1)
        '        wk_WM_WLS_MAX = WM_WLS_MAX
        '        wk_Listcnt = wk_Pagecnt1 * wk_WM_WLS_MAX
        '        ReDim Preserve WM_WLS_DSPArray(wk_Listcnt)
        '        'CHG START 2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
        '        Cnt = 0
        '    End If

        '    '�\���������W�J
        '    'CHG START 2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
        '    'Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + Cnt)
        '    wk_Pagecnt_long = Wk_Pagecnt
        '    wk_WM_WLS_MAX = WM_WLS_MAX
        '    wk_Cnt_long = Cnt

        '    wk_Setarray = wk_Pagecnt_long * wk_WM_WLS_MAX + wk_Cnt_long
        '    Call WLS_SetArray(wk_Setarray)
        '    'CHG END   2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{

        '    Cnt = Cnt + 1

        '    Call CF_Ora_MoveNext(Usr_Ody)
        'Loop
        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1

            WM_WLS_ENDUSRCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("CODE"), "")
            WM_WLS_ENDUSRNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NAME"), "")

            '�\�����y�[�W
            If Cnt Mod WM_WLS_MAX = 0 Then
                Wk_Pagecnt = Wk_Pagecnt + 1
                '�ŏI�y�[�W�ޔ�
                WM_WLS_LastPage = Wk_Pagecnt
                'CHG START 2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
                'ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
                wk_Pagecnt1 = (Wk_Pagecnt + 1)
                wk_WM_WLS_MAX = WM_WLS_MAX
                wk_Listcnt = wk_Pagecnt1 * wk_WM_WLS_MAX
                ReDim Preserve WM_WLS_DSPArray(wk_Listcnt)
                'CHG START 2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
                Cnt = 0
            End If

            '�\���������W�J
            'CHG START 2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{
            'Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + Cnt)
            wk_Pagecnt_long = Wk_Pagecnt
            wk_WM_WLS_MAX = WM_WLS_MAX
            wk_Cnt_long = Cnt

            wk_Setarray = wk_Pagecnt_long * wk_WM_WLS_MAX + wk_Cnt_long
            Call WLS_SetArray(wk_Setarray)
            'CHG END   2018/05/21 �G���h���[�U�Ή�2 �x�m��)���{

            Cnt = Cnt + 1
        Next
        '20190319 CHG END 
		
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
	Sub WLS_Clear()
		
		'��������
		WM_WLS_NAME = ""
		
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
	'UPGRADE_WARNING: Form �C�x���g WLSEND.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSEND_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190521 DEL START
        '      'WINDOW �ʒu�ݒ�
        '      Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'WM_WLS_Dspflg = False

        ''���ڏ�����
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
        '20190521 DEL END

    End Sub
	
	Private Sub WLSEND_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window�����ݒ�
        Call WLS_FORM_INIT()

        '20190521 ADD START
        'WINDOW �ʒu�ݒ�
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        WM_WLS_Dspflg = False

        '���ڏ�����
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
        '20190521 ADD END

    End Sub

    '20190521 ADD START
    Private Sub WLSEND_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190521 ADD END

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
			WM_WLS_NAME = HD_NAME.Text
			
			'�����������N���A
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSMEI_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '20190521 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190521 CHG END

    End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			'Enter�L�[����
			Case System.Windows.Forms.Keys.Return
                '20190521 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190521 CHG END

                'Escape�L�[����
            Case System.Windows.Forms.Keys.Escape
                '20190521 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190521 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Left
                '20190521 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190521 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Right
                '20190521 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190521 CHG END
                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '20190521 CHG START
    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '	If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '		If Not WM_WLS_LastFL Then Call WLS_DspPage()
    '	Else
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
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
    '20190521 CHG END

    '20190521 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            Call HD_NAME_KeyDown(HD_NAME, New System.Windows.Forms.KeyEventArgs(Keys.Return))

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʌ����G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            Me.HD_NAME.Text = ""
            LST.Items.Clear()
            Me.HD_NAME.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    '20190521 ADD END

    '20190521 CHG START
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
    '20190521 CHG END

    '20190521 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	WLSMEI_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
    '	Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click

    '	If Dyn_Open = True Then
    '		'�N���[�Y
    '           'Call CF_Ora_CloseDyn(Usr_Ody)
    '		Dyn_Open = False
    '	End If

    '	Hide()
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        WLSMEI_RTNMEICDA = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
        Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click

        If Dyn_Open = True Then
            '�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If

        Hide()
    End Sub


    '20171220 CIS)�����@�폜�@�J�n�@����հ�ޑΉ��Q
    'Private Sub WLSEXECUTE_Click()
    '    gv_bolEndUsrFlg = True
    '
    '    Hide
    'End Sub
    '20171220 CIS)�����@�폜�@�I��
End Class