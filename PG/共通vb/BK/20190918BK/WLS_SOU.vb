Option Strict Off
Option Explicit On
Friend Class WLSSOU
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@�q�Ɍ���
	'*  �v���O�����h�c�@�F  WLSSOU
	'*  �쐬�ҁ@�@�@�@�@�F�@ACE)���V
	'*  �쐬���@�@�@�@�@�F  2006.05.15
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'************************************************************************************
	'   �\����
	'************************************************************************************
	Private Structure TYPE_DB_SOUMTA_W
		Dim WK_DB_SOUMTA As TYPE_DB_SOUMTA
		Dim TOKRN As String '����於
		' === 20060828 === INSERT S - ACE)Nagasawa
		Dim BASYO As String '�ꏊ��
		' === 20060828 === INSERT E -
	End Structure
	'************************************************************************************
	'   Public�ϐ�
	'************************************************************************************
	'�߂�l
	
	'************************************************************************************
	'   Private�萔
	'************************************************************************************
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "0" '�J�n�R�[�h���͑��� [0,X]

    '************************************************************************************
    '   Private�ϐ�
    '************************************************************************************
    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 chg start
    'Private WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    Private WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    '20190619 chg end
    Private WM_WLS_CODELEN As Short '�J�n���ޓ��͕�����
	Private WM_WLS_NAMELEN As Short '�q�ɖ����͕�����
	
	'�E�B���h�����g�p�ϐ�
	Private WM_WLS_MAX As Short '�P��ʂ̕\������
	Private WM_WLS_CODE As String '�q�ɃR�[�h�����p
	Private WM_WLS_SOUNM As String '�q�ɖ������p
	Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Usr_Ody As U_Ody '�ް��ް����ð���
	Private DB_SOUMTA_W As TYPE_DB_SOUMTA_W
	Private Dyn_Open As Boolean '�_�C�i�Z�b�g��ԁiTrue:Open False:Close)
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_FORM_INIT
	'   �T�v�F  ��ʏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		WM_WLS_CODELEN = 3
		WM_WLS_NAMELEN = 20
		
		WM_WLS_MAX = 15 '��ʕ\������
		'�ϐ�������
		WLSSOU_RTNCODE = ""
		Call WLS_Clear()
		Dyn_Open = False
		
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_SetArray
	'   �T�v�F  ���X�g�ҏW
	'   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		
		Dim WK_SHUBETU As String '���
		Dim WK_SHISAN As String '���Y��
		
		' === 20060828 === UPDATE S - ACE)Nagasawa
		'        '��ʕҏW
		'        Select Case DB_SOUMTA_W.WK_DB_SOUMTA.SOUKB
		'            Case "1"
		'                WK_SHUBETU = "�_��"
		'            Case "2"
		'                WK_SHUBETU = "����"
		'            Case Else
		'                WK_SHUBETU = ""
		'        End Select
		'
		'        '���Y���ҏW
		'        Select Case DB_SOUMTA_W.WK_DB_SOUMTA.SISNKB
		'            Case "0"
		'                WK_SHISAN = "����"
		'            Case "1"
		'                WK_SHISAN = "����"
		'            Case Else
		'                WK_SHISAN = ""
		'        End Select
		'
		'        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_SOUMTA_W.WK_DB_SOUMTA.SOUCD, WM_WLS_CODELEN) & "       " & _
		''                                    LeftWid$(DB_SOUMTA_W.WK_DB_SOUMTA.SOUNM, WM_WLS_NAMELEN) & "  " & _
		''                                    WK_SHUBETU & "  " & _
		''                                    WK_SHISAN & "    " & _
		''                                    LeftWid$(DB_SOUMTA_W.TOKRN, 40)
		
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_SOUMTA_W.WK_DB_SOUMTA.SOUCD, WM_WLS_CODELEN) & "       " & LeftWid(DB_SOUMTA_W.WK_DB_SOUMTA.SOUNM, WM_WLS_NAMELEN) & "     " & LeftWid(DB_SOUMTA_W.BASYO, 20)
		' === 20060828 === UPDATE E -
		
		
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
		' === 20060828 === UPDATE S - ACE)Nagasawa
		'        strSQL = strSQL & " Select SOUCD "          '�q�ɃR�[�h
		'        strSQL = strSQL & "      , SOUNM "          '�q�ɖ�
		'        strSQL = strSQL & "      , SOUKB "          '�q�Ɏ��
		'        strSQL = strSQL & "      , SISNKB "         '���Y���敪
		'        strSQL = strSQL & "      , SOUTRICD "       '�����R�[�h
		'        strSQL = strSQL & "      , TOKRN "          '���Ӑ旪��
		'        strSQL = strSQL & "   from SOUMTA, TOKMTA "
		'' === 20060814 === UPDATE S - ACE)Nagasawa
		''        strSQL = strSQL & "  Where SOUMTA.DATKB = '1' "
		'        strSQL = strSQL & "  Where SOUMTA.DATKB = '" & gc_strDATKB_USE & "' "
		'' === 20060814 === UPDATE E -
		'        strSQL = strSQL & "    and SOUMTA.SOUTRICD = TOKMTA.TOKCD (+) "
		
		strSQL = strSQL & " Select SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "      , SOUNM " '�q�ɖ�
		strSQL = strSQL & "      , MEINMA AS BASYO " '�ꏊ��
		strSQL = strSQL & "   from SOUMTA, MEIMTA "
		strSQL = strSQL & "  Where SOUMTA.DATKB     = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    and MEIMTA.DATKB (+) = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    and MEIMTA.KEYCD (+) = '" & gc_strKEYCD_BSCD & "' "
		strSQL = strSQL & "    and SOUMTA.SOUBSCD   = MEIMTA.MEICDA (+) "
		' === 20060828 === UPDATE E -
		
		'�q�ɃR�[�h����
		If Trim(WM_WLS_CODE) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
			'            strSQL = strSQL & "    and SOUCD >=   '" & WM_WLS_CODE & "'"
			strSQL = strSQL & "    and SOUCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
			' === 20080929 === UPDATE E -
		End If
		
		'�q�ɖ�����(�����܂�����)
		If Trim(WM_WLS_SOUNM) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
			'            strSQL = strSQL & "    and SOUNM LIKE '%" & WM_WLS_SOUNM & "%'"
			strSQL = strSQL & "    and SOUNM LIKE '%" & CF_Ora_String(WM_WLS_SOUNM, CF_Ctr_AnsiLenB(WM_WLS_SOUNM)) & "%'"
			' === 20080929 === UPDATE E -
		End If
		
		'�\�[�g����
		strSQL = strSQL & "   order by "
		strSQL = strSQL & "   SOUCD "

        If Dyn_Open = True Then
            '�N���[�Y
            '20190513 DEL START
            'Call CF_Ora_CloseDyn(Usr_Ody)
            '20190513 DEL END
            Dyn_Open = False
        End If

        '20190513 CHG START
        'DB�A�N�Z�X
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        DB_GetTable(strSQL)
        '20190513 CHG END

        Dyn_Open = True
        ' === 20060728 === INSERT S - ACE)Furukawa
        LST.Items.Clear()
		' === 20060728 === INSERT E
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_DspNew
	'   �T�v�F  ���X�g�ҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		Dim Cnt As Integer

        Cnt = 0

        '20190513 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '	'�擾���e�ޔ�
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_SOUMTA_W.WK_DB_SOUMTA.SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '�q�ɃR�[�h
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_SOUMTA_W.WK_DB_SOUMTA.SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "") '�q�ɖ�
        '	' === 20060828 === UPDATE S - ACE)Nagasawa
        '	'        DB_SOUMTA_W.WK_DB_SOUMTA.SOUKB = CF_Ora_GetDyn(Usr_Ody, "SOUKB", "")            '�q�Ɏ��
        '	'        DB_SOUMTA_W.WK_DB_SOUMTA.SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "")          '���Y���敪
        '	'        DB_SOUMTA_W.WK_DB_SOUMTA.SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "")      '�����R�[�h
        '	'        DB_SOUMTA_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                         '���Ӑ旪��
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_SOUMTA_W.BASYO = CF_Ora_GetDyn(Usr_Ody, "BASYO", "") '�ꏊ��
        '	' === 20060828 === UPDATE E -

        '	'�\�����y�[�W
        '	If Cnt Mod WM_WLS_MAX = 0 Then
        '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '		ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '		Cnt = 0
        '		'�ŏI�y�[�W�ޔ�
        '		WM_WLS_LastPage = WM_WLS_Pagecnt
        '	End If

        '	'�\���������W�J
        '	Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

        '	Cnt = Cnt + 1

        '	Call CF_Ora_MoveNext(Usr_Ody)

        '	If Cnt >= WM_WLS_MAX Then
        '		Exit Do
        '	End If
        'Loop 

        ''�ŏI�f�[�^���B
        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	WM_WLS_LastFL = True
        'End If

        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1
            '�擾���e�ޔ�
            DB_SOUMTA_W.WK_DB_SOUMTA.SOUCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SOUCD"), "") '�q�ɃR�[�h
            DB_SOUMTA_W.WK_DB_SOUMTA.SOUNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SOUNM"), "") '�q�ɖ�
            DB_SOUMTA_W.BASYO = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("BASYO"), "") '�ꏊ��

            '�\�����y�[�W
            If Cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                Cnt = 0
                '�ŏI�y�[�W�ޔ�
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            '�\���������W�J
            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

            Cnt = Cnt + 1

            'If Cnt >= WM_WLS_MAX Then
            '    Exit For
            'End If
        Next

        WM_WLS_LastFL = True
        '20190513 CHG END

        If Cnt > 0 Then
            '�y�[�W��\��
            WM_WLS_Pagecnt = 0
            Call WLS_DspPage()
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
		
		'��������
		WM_WLS_CODE = ""
		WM_WLS_SOUNM = ""
		
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
	'UPGRADE_WARNING: Form �C�x���g WLSSOU.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSSOU_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190521 DEL START
        'WINDOW �ʒu�ݒ�
        '      Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
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
        '' === 20060821 === UPDATE S - ACE)Nagasawa
        ''        HD_CODE.SetFocus
        '' === 20061228 === INSERT S - ACE)Nagasawa
        'On Error Resume Next
        '' === 20061228 === INSERT E -
        'LST.Focus()
        '      ' === 20060821 === UPDATE E -
        '20190521 DEL END

    End Sub

    Private Sub WLSSOU_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window�����ݒ�
        Call WLS_FORM_INIT()

        '201905121 ADD START
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete

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
        ' === 20060821 === UPDATE S - ACE)Nagasawa
        '        HD_CODE.SetFocus
        ' === 20061228 === INSERT S - ACE)Nagasawa
        On Error Resume Next
        ' === 20061228 === INSERT E -
        LST.Focus()
        ' === 20060821 === UPDATE E -
        '20190521 ADD END

    End Sub

    '20190529 ADD START
    Private Sub WLSSOU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190529 ADD END

    Private Sub HD_CODE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CODE.Enter
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(HD_CODE.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(HD_CODE.Text) > 0 Then
            'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
            HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
            '---------- 20061019 ACE MENTE START ----------
            '   Else
            '       HD_CODE.Text = Space$(HD_CODE.MaxLength)
            '---------- 20061019 ACE MENTE E N D ----------
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
	
	Private Sub HD_NAME_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NAME.Enter
		'---------- 20061019 ACE MENTE START ----------
		'   If LenWid(HD_NAME.Text) <= 0 Then
		'       HD_NAME.Text = Space$(HD_NAME.MaxLength)
		'   End If
		'---------- 20061019 ACE MENTE E N D ----------
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
			WM_WLS_SOUNM = HD_NAME.Text
			
			'�����������N���A
			HD_CODE.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
#Disable Warning BC40000 ' Type or member is obsolete
		WLSSOU_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
#Enable Warning BC40000 ' Type or member is obsolete
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
#Disable Warning BC40000 ' Type or member is obsolete
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
#Enable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
#Enable Warning BC40000 ' Type or member is obsolete

        '20190529 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190529 CHG END

    End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			'Enter�L�[����
			Case System.Windows.Forms.Keys.Return
                '20190529 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190529 CHG END

                'Escape�L�[����
            Case System.Windows.Forms.Keys.Escape
                '20190529 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190529 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Left
                '20190529 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190529 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Right
                '20190529 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190529 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '20190529 CHG START
    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '	' === 20060728 === DELETE S - ACE)Furukawa
    '	'    Call WLS_DspNew
    '	' === 20060728 === DELETE E

    '	If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '           ' === 20060728 === UPDATE S - ACE)Furukawa
    '           'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
    '           ' === 20060728 === UPDATE ��
    '           '20190513 CHG START
    '           'If Not WM_WLS_LastFL Then Call WLS_DspNew()
    '           If Not WM_WLS_LastFL Then Call WLS_DspPage()
    '           '20190513 CHG START
    '           ' === 20060728 === UPDATE E
    '       Else
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

        ' === 20060728 === DELETE S - ACE)Furukawa
        '    Call WLS_DspNew
        ' === 20060728 === DELETE E

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            ' === 20060728 === UPDATE S - ACE)Furukawa
            'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
            ' === 20060728 === UPDATE ��
            '20190513 CHG START
            'If Not WM_WLS_LastFL Then Call WLS_DspNew()
            If Not WM_WLS_LastFL Then Call WLS_DspPage()
            '20190513 CHG START
            ' === 20060728 === UPDATE E
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190529 CHG END

    '20190521 ADD START
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
    '20190521 ADD END

    '20190529 CHG START
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
    '20190529 CHG END


    '20190529 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	WLSSOU_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
    '	Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click

    '       If Dyn_Open = True Then
    '           '�N���[�Y
    '           Call CF_Ora_CloseDyn(Usr_Ody)
    '           Dyn_Open = False
    '       End If

    '       Hide()
    '   End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
#Disable Warning BC40000 ' Type or member is obsolete
        WLSSOU_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
#Enable Warning BC40000 ' Type or member is obsolete
        Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click

        If Dyn_Open = True Then
            '�N���[�Y
            Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If

        Hide()
    End Sub
    '20190529 CHG END

End Class