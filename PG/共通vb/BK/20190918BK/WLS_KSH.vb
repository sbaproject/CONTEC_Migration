Option Strict Off
Option Explicit On
Friend Class WLS_KSH
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@���ϕ��@����
	'*  �v���O�����h�c�@�F  WLS_KSH
	'*  �쐬�ҁ@�@�@�@�@�F�@����)inoue
	'*  �쐬���@�@�@�@�@�F  2013.07.01
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'�E�B���hհ�ް�ݒ�ϐ�
	Private WM_WLS_KSHCDALEN As Short '�R�[�h�P������
	Private WM_WLS_KSHNMALEN As Short '���̂P������
	Private WM_WLS_KSHNMBLEN As Short '���̂Q������
	
	'�E�B���h�����g�p�ϐ�
	Private WM_WLS_DSP_Caption As String '��ʷ��߼�ݕ\���f�[�^
	Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^

    '20190904 CHG START
    'Private WM_WLS_MAX As Short '�P��ʂ̕\������
    Private WM_WLS_MAX As Short = 15 '�P��ʂ̕\������
    '20190904 CHG END

    Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	Private Dyn_Open As Boolean '�_�C�i�Z�b�g��ԁiTrue:Open False:Close)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Usr_Ody As U_Ody '�ް��ް����ð���
	Private DB_MEIMTA_W As TYPE_DB_MEIMTA '�������ʑޔ�
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_FORM_INIT
	'   �T�v�F  ��ʏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		'=== �\�������ݒ� ===
		WM_WLS_MAX = 15 '��ʕ\������

        '20190904 CHG START
        '���ڕ������擾
        'WM_WLS_KSHCDALEN = Len(DB_MEIMTA_W.MEICDA) 'LenWid �̓_��
        'WM_WLS_KSHNMALEN = Len(DB_MEIMTA_W.MEINMA) 'LenWid �̓_��
        'WM_WLS_KSHNMBLEN = Len(DB_MEIMTA_W.MEINMB) 'LenWid �̓_��

        WM_WLS_KSHCDALEN = 20 'MEIMTA.MEICDA Field Length
        WM_WLS_KSHNMALEN = 40 'MEIMTA.MEINMA Field Length
        WM_WLS_KSHNMBLEN = 20 'MEIMTA.MEINMB Field Length
        '20190904 CHG END

        '�ϐ�������
        WLSMEI_RTNMEICDA = ""
		WLSMEI_RTNMEINMA = ""
		WLSMEI_RTNMEINMB = ""
		
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
        WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_MEIMTA_W.MEINMB, WM_WLS_KSHNMBLEN) & Space(1) & LeftWid(DB_MEIMTA_W.MEINMA, WM_WLS_KSHNMALEN)
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
		strSQL = strSQL & "      , MEINMB " '���̂Q
		strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "


        strSQL = strSQL & "   and  KEYCD = '" & WLSMEI_KEYCD & "'"

        strSQL = strSQL & "   order by "
		strSQL = strSQL & "        KEYCD " '�L�[
		strSQL = strSQL & "      , DSPORD " '�\������
		strSQL = strSQL & "      , MEINMB " '���̂Q�i���Ӑ�R�[�h�j
		
		If Dyn_Open = True Then
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		Dyn_Open = True
		LST.Items.Clear()
		
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
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			'�擾���e�ޔ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_MEIMTA_W.KEYCD = CF_Ora_GetDyn(Usr_Ody, "KEYCD", "") '�L�[
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_MEIMTA_W.MEIKMKNM = CF_Ora_GetDyn(Usr_Ody, "MEIKMKNM", "") '���ږ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_MEIMTA_W.MEICDA = CF_Ora_GetDyn(Usr_Ody, "MEICDA", "") '�R�[�h�P
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_MEIMTA_W.MEINMA = CF_Ora_GetDyn(Usr_Ody, "MEINMA", "") '���̂P
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_MEIMTA_W.MEINMB = CF_Ora_GetDyn(Usr_Ody, "MEINMB", "") '���̂Q
			
			'�\���������W�J
			'�P���ڂ͉�ʷ��߼�ݗp
			If Cnt = 0 And WM_WLS_Pagecnt = -1 Then
				WM_WLS_DSP_Caption = DB_MEIMTA_W.MEIKMKNM
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
			
			Cnt = Cnt + 1
			
			Call CF_Ora_MoveNext(Usr_Ody)
			
			If Cnt >= WM_WLS_MAX Then
				Exit Do
			End If
		Loop 
		
		'�ŏI�f�[�^���B
		If CF_Ora_EOF(Usr_Ody) = True Then
			WM_WLS_LastFL = True
		End If
		
		If Cnt > 0 Then
			'�y�[�W��\��
			Call WLS_Dsp()
		Else
			If WM_WLS_Pagecnt = 1 Then
				Me.Text = ""
				LST.Items.Clear()
			End If
		End If
		
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
		
		'�t�H�[�J�X�ݒ�
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			On Error Resume Next
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
		
		'��ʕ\���y�[�W
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
	End Sub
	
	'UPGRADE_WARNING: Form �C�x���g WLS_KSH.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLS_KSH_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		'// ��ʕҏW
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		If (LST.Items.Count > 0) And (LST.SelectedIndex < 0) Then LST.SelectedIndex = 0
		
		DblClickFl = False
	End Sub
	
	Private Sub WLS_KSH_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)

        Call Init_Prompt()
        Call WLS_FORM_INIT()

        '20190904 ADD START
        '// ��ʕҏW
        Call WLS_TextSQL()
        Call WLS_DspNew()
        If (LST.Items.Count > 0) And (LST.SelectedIndex < 0) Then LST.SelectedIndex = 0
        DblClickFl = False
        '20190904 ADD END

    End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 13
				WLSMEI_RTNMEINMB = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_KSHNMBLEN)
				WLSMEI_RTNMEINMA = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_KSHNMBLEN + 2, WM_WLS_KSHNMALEN)
				If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case 27
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
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Hide()
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
		Else
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_Dsp()
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
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
			Call WLS_Dsp()
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

    Private Sub WLS_KSH_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub

    Private Sub btnF7_Click(sender As Object, e As EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_Dsp()
        End If
    End Sub

    Private Sub btnF8_Click(sender As Object, e As EventArgs) Handles btnF8.Click

        If LST.Items.Count <= 0 Then Exit Sub

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_Dsp()
        End If
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        Hide()
    End Sub
End Class