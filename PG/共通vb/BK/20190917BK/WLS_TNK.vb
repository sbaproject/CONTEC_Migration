Option Strict Off
Option Explicit On
Friend Class WLSTNK
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@�P����������(�T����\��)
	'*  �v���O�����h�c�@�F  WLSTNK
	'*  �쐬�ҁ@�@�@�@�@�F�@ACE)���V
	'*  �쐬���@�@�@�@�@�F  2006.05.15
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
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "0" '�J�n�R�[�h���͑��� [0,X]

    '************************************************************************************
    '   Private�ϐ�
    '************************************************************************************
    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 chg start
    'Private WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    Private WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    '20190619 chg end

    '�E�B���h�����g�p�ϐ�
    Private WM_WLS_MAX As Short '�P��ʂ̕\������
	Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_DSPArray(5) As String '�E�B���h�\���f�[�^
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Usr_Ody As U_Ody '�ް��ް����ð���
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_FORM_INIT
	'   �T�v�F  ��ʏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		WM_WLS_MAX = 5 '��ʕ\������
		'�ϐ�������
		WLSTNK_RTNCODE = ""
		Call WLS_Clear()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_TextSQL
	'   �T�v�F  ����sql�쐬
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL()
		
		Select Case WLSTNK_TNKCD
			'�̔��P����������
			Case "1"
				Call WLS_TextSQL_TOK()
				
				'�d���P����������
			Case "2"
				Call WLS_TextSQL_SIR()
				
			Case Else
		End Select
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_TextSQL_TOK
	'   �T�v�F  �̔��P����������sql�쐬
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL_TOK()
		
		Dim strSQL As String
		Dim intData As Short
		Dim intCnt As Short
		Dim strDate As String
		Dim strTanka As String
		Dim strTanka_Hide As String
		Dim curTanka As Decimal
		
		strSQL = ""
		strSQL = strSQL & " Select URITKDT00 " '�̔��P���ݒ���t�O
		strSQL = strSQL & "      , HISURITK00 " '�̔�����P���O
		strSQL = strSQL & "      , URITKDT01 " '�̔��P���ݒ���t�P
		strSQL = strSQL & "      , HISURITK01 " '�̔�����P���P
		strSQL = strSQL & "      , URITKDT02 " '�̔��P���ݒ���t�Q
		strSQL = strSQL & "      , HISURITK02 " '�̔�����P���Q
		strSQL = strSQL & "      , URITKDT03 " '�̔��P���ݒ���t�R
		strSQL = strSQL & "      , HISURITK03 " '�̔�����P���R
		strSQL = strSQL & "      , URITKDT04 " '�̔��P���ݒ���t�S
		strSQL = strSQL & "      , HISURITK04 " '�̔�����P���S
		strSQL = strSQL & "      , URITKDT05 " '�̔��P���ݒ���t�T
		strSQL = strSQL & "      , HISURITK05 " '�̔�����P���T
		strSQL = strSQL & "   from TOKMTB "
		strSQL = strSQL & "  Where DATKB = '1' "
		strSQL = strSQL & "    and TOKCD = '" & WLSTNK_CODE & "' "
		strSQL = strSQL & "    and HINCD = '" & WLSTNK_HINCD & "' "

        '20190319 CHG START
        ''DB�A�N�Z�X
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        DB_GetTable(strSQL)
        '20190319 CHG END

		intCnt = 0

        '20190319 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	For intCnt = 0 To WM_WLS_MAX
        '		'�P���ݒ���t
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		strDate = CF_Ora_GetDyn(Usr_Ody, "URITKDT0" & Trim(Str(intCnt)), "")
        '		If Trim(strDate) <> "" Then
        '			strDate = VB6.Format(strDate, "@@@@/@@/@@")
        '		Else
        '			strDate = Space(10)
        '		End If

        '		'�̔�����P��
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		strTanka = CF_Ora_GetDyn(Usr_Ody, "HISURITK0" & Trim(Str(intCnt)), "")
        '		If Trim(strTanka) <> "" Then
        '			curTanka = CDec(strTanka)
        '			strTanka = VB6.Format(curTanka, "###,###,##0.0###")
        '			strTanka = Space(16 - Len(strTanka)) & strTanka
        '			strTanka_Hide = Str(curTanka)
        '			strTanka_Hide = Space(14 - Len(strTanka_Hide)) & strTanka_Hide
        '		Else
        '			strTanka = Space(16)
        '			strTanka_Hide = Space(14)
        '		End If

        '		'�̔�����
        '		If intCnt = 0 Then
        '			' === 20070308 === UPDATE S - ACE)Nagasawa �����̓��͉ې���̕ύX
        '			'                    WM_WLS_DSPArray(intCnt) = " (�艿) " & strDate & _
        '			''                                              Space(8) & strTanka & _
        '			''                                              Space(11) & strTanka_Hide
        '			WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
        '			' === 20070308 === UPDATE E -
        '		Else
        '			WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
        '		End If

        '	Next intCnt
        'End If

        ''�_�C�i�Z�b�g�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody)

        If dsList.Tables("tableName").Rows.Count > 0 Then
            For intCnt = 0 To WM_WLS_MAX
                '�P���ݒ���t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strDate = DB_NullReplace(dsList.Tables("tableName").Rows(0).Item("URITKDT0" & Trim(Str(intCnt))), "")
                If Trim(strDate) <> "" Then
                    strDate = VB6.Format(strDate, "@@@@/@@/@@")
                Else
                    strDate = Space(10)
                End If

                '�̔�����P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strTanka = DB_NullReplace(dsList.Tables("tableName").Rows(0).Item("HISURITK0" & Trim(Str(intCnt))), "")
                If Trim(strTanka) <> "" Then
                    curTanka = CDec(strTanka)
                    strTanka = VB6.Format(curTanka, "###,###,##0.0###")
                    strTanka = Space(16 - Len(strTanka)) & strTanka
                    strTanka_Hide = Str(curTanka)
                    strTanka_Hide = Space(14 - Len(strTanka_Hide)) & strTanka_Hide
                Else
                    strTanka = Space(16)
                    strTanka_Hide = Space(14)
                End If

                '�̔�����
                If intCnt = 0 Then
                    ' === 20070308 === UPDATE S - ACE)Nagasawa �����̓��͉ې���̕ύX
                    '                    WM_WLS_DSPArray(intCnt) = " (�艿) " & strDate & _
                    ''                                              Space(8) & strTanka & _
                    ''                                              Space(11) & strTanka_Hide
                    WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
                    ' === 20070308 === UPDATE E -
                Else
                    WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
                End If

            Next intCnt
        End If
        '20190319 CHG END

		'���X�g�ҏW
		Call WLS_DspPage()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_TextSQL_SIR
	'   �T�v�F  �d���P����������sql�쐬
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL_SIR()
		
		Dim strSQL As String
		Dim intData As Short
		Dim intCnt As Short
		Dim strDate As String
		Dim strTanka As String
		Dim strTanka_Hide As String
		Dim curTanka As Decimal
		
		strSQL = ""
		strSQL = strSQL & " Select SRETKDT00 " '�d���P���ݒ���t�O
		strSQL = strSQL & "      , HISSRETK00 " '�d������P���O
		strSQL = strSQL & "      , SRETKDT01 " '�d���P���ݒ���t�P
		strSQL = strSQL & "      , HISSRETK01 " '�d������P���P
		strSQL = strSQL & "      , SRETKDT02 " '�d���P���ݒ���t�Q
		strSQL = strSQL & "      , HISSRETK02 " '�d������P���Q
		strSQL = strSQL & "      , SRETKDT03 " '�d���P���ݒ���t�R
		strSQL = strSQL & "      , HISSRETK03 " '�d������P���R
		strSQL = strSQL & "      , SRETKDT04 " '�d���P���ݒ���t�S
		strSQL = strSQL & "      , HISSRETK04 " '�d������P���S
		strSQL = strSQL & "      , SRETKDT05 " '�d���P���ݒ���t�T
		strSQL = strSQL & "      , HISSRETK05 " '�d������P���T
		strSQL = strSQL & "   from SIRMTB "
		strSQL = strSQL & "  Where DATKB = '1' "
		strSQL = strSQL & "    and SIRCD = '" & WLSTNK_CODE & "' "
		strSQL = strSQL & "    and HINCD = '" & WLSTNK_HINCD & "' "

        '20190319 CHG START
        ''DB�A�N�Z�X
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        DB_GetTable(strSQL)
        '20190319 CHG END
		
		intCnt = 0

        '20190319 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	For intCnt = 0 To WM_WLS_MAX
        '		'�P���ݒ���t
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		strDate = CF_Ora_GetDyn(Usr_Ody, "SRETKDT0" & Trim(Str(intCnt)), "")
        '		If Trim(strDate) <> "" Then
        '			strDate = VB6.Format(strDate, "@@@@/@@/@@")
        '		Else
        '			strDate = Space(10)
        '		End If

        '		'�d������P��
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		strTanka = CF_Ora_GetDyn(Usr_Ody, "HISSRETK0" & Trim(Str(intCnt)), "")
        '		If Trim(strTanka) <> "" Then
        '			curTanka = CDec(strTanka)
        '			strTanka = VB6.Format(curTanka, "###,###,##0.0###")
        '			strTanka = Space(16 - Len(strTanka)) & strTanka
        '			strTanka_Hide = Str(curTanka)
        '			strTanka_Hide = Space(14 - Len(strTanka_Hide)) & strTanka_Hide
        '		Else
        '			strTanka = Space(16)
        '			strTanka_Hide = Space(14)
        '		End If

        '		'�d������
        '		If intCnt = 0 Then
        '			WM_WLS_DSPArray(intCnt) = " (�艿) " & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
        '		Else
        '			WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
        '		End If

        '	Next intCnt
        'End If

        ''�_�C�i�Z�b�g�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody)

        If dsList.Tables("tableName").Rows.Count > 0 Then
            For intCnt = 0 To WM_WLS_MAX
                '�P���ݒ���t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strDate = DB_NullReplace(dsList.Tables("tableName").Rows(0).Item("SRETKDT0" & Trim(Str(intCnt))), "")
                If Trim(strDate) <> "" Then
                    strDate = VB6.Format(strDate, "@@@@/@@/@@")
                Else
                    strDate = Space(10)
                End If

                '�d������P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strTanka = DB_NullReplace(dsList.Tables("tableName").Rows(0).Item("HISSRETK0" & Trim(Str(intCnt))), "")
                If Trim(strTanka) <> "" Then
                    curTanka = CDec(strTanka)
                    strTanka = VB6.Format(curTanka, "###,###,##0.0###")
                    strTanka = Space(16 - Len(strTanka)) & strTanka
                    strTanka_Hide = Str(curTanka)
                    strTanka_Hide = Space(14 - Len(strTanka_Hide)) & strTanka_Hide
                Else
                    strTanka = Space(16)
                    strTanka_Hide = Space(14)
                End If

                '�d������
                If intCnt = 0 Then
                    WM_WLS_DSPArray(intCnt) = " (�艿) " & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
                Else
                    WM_WLS_DSPArray(intCnt) = Space(8) & strDate & Space(8) & strTanka & Space(11) & strTanka_Hide
                End If

            Next intCnt
        End If
        '20190319 CHG END

		'���X�g�ҏW
		Call WLS_DspPage()
		
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
		
		LST.Items.Clear()
		
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		intCnt = 0
		Do While intCnt <= WM_WLS_MAX
			If Trim(Mid(WM_WLS_DSPArray(intCnt), 9, 10)) <> "" Then
				LST.Items.Add(WM_WLS_DSPArray(intCnt))
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
		
		Dim intCnt As Short
		
		'�������ʕێ��z��
		For intCnt = 0 To WM_WLS_MAX
			WM_WLS_DSPArray(intCnt) = ""
		Next intCnt
		
	End Sub
	'
	'�ȉ��͉�ʃC�x���g����
	'
	'UPGRADE_WARNING: Form �C�x���g WLSTNK.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSTNK_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		Dim intSts As String
		Dim TOKMTA As TYPE_DB_TOKMTA
		Dim HINMTA As TYPE_DB_HINMTA
		
		'WINDOW �ʒu�ݒ�
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WM_WLS_Dspflg = False
		
		HD_TOKRN.Text = ""
		HD_HINNMA.Text = ""
		HD_HINNMB.Text = ""
		LST.Items.Clear()
		
		'���Ӑ於�擾
		intSts = CStr(DSPTOKCD_SEARCH(WLSTNK_CODE, TOKMTA))
		HD_TOKRN.Text = TOKMTA.TOKRN
		
		'�^���A�i���擾
		intSts = CStr(DSPHINCD_SEARCH_B(WLSTNK_HINCD, HINMTA))
		HD_HINNMA.Text = HINMTA.HINNMA
		HD_HINNMB.Text = HINMTA.HINNMB
		
		'���X�g�\��
		Call WLS_TextSQL()
		
		WM_WLS_Dspflg = True
		
		DblClickFl = False
		
		Me.Refresh()
	End Sub
	
	Private Sub WLSTNK_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window�����ݒ�
		Call WLS_FORM_INIT()
	End Sub
	
	' === 20060728 === INSERT S - ACE)Furukawa
	Private Sub HD_TOKRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Enter
		Call F_Ctl_HD_Focus()
	End Sub
	Private Sub HD_HINNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.Enter
		Call F_Ctl_HD_Focus()
	End Sub
	Private Sub HD_HINNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.Enter
		Call F_Ctl_HD_Focus()
	End Sub
	
	Private Function F_Ctl_HD_Focus() As Short
		If LST.Enabled = True Then
			' === 20061228 === INSERT S - ACE)Nagasawa
			On Error Resume Next
			' === 20061228 === INSERT E -
			LST.Focus()
		Else
			If WLSOK.Enabled = True Then
				' === 20061228 === INSERT S - ACE)Nagasawa
				On Error Resume Next
				' === 20061228 === INSERT E -
				WLSOK.Focus()
			End If
		End If
	End Function
	' === 20060728 === INSERT E
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSTNK_RTNCODE = Mid(VB6.GetItemString(LST, LST.SelectedIndex), 53)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			'Enter�L�[����
			Case System.Windows.Forms.Keys.Return
				Call WLSOK_Click(WLSOK, New System.EventArgs())
				
				'Escape�L�[����
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		End Select
		
	End Sub
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		WLSTNK_RTNCODE = Mid(VB6.GetItemString(LST, LST.SelectedIndex), 53)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		Hide()
	End Sub
End Class