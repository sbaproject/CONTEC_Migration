Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSUDN
	Inherits System.Windows.Forms.Form
	'�ȉ��̂S�s�̐ݒ���s������
	Const WM_WLS_MSTKB As String = "1" '�}�X�^�敪(1:���Ӑ� 2:�[�i�� 3:�S���� 4:���Ӑ� 5:���i)
	Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]
	
	'�����L�[No�i�g�p���Ȃ��ꍇ��-1��ݒ�j
	Const WM_WLS_TextKey As Short = 10 '�J�n�R�[�h�̃\�[�g�L�[No
	Const WM_WLS_CDKey As Short = -1 '�J�i�����̃\�[�g�L�[No+���L�[

    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 CHG START
    'Dim WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    'Dim WM_WLS_SFIL As Short '�E�B���h�\�����̧��
    'Dim WM_WLS_SFIL1 As Short '�E�B���h�\�����̧��
    Dim WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    Dim WM_WLS_SFIL As Object '�E�B���h�\�����̧��
    Dim WM_WLS_SFIL1 As Object '�E�B���h�\�����̧��
    '20190619 CHG END

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
	
	'''''    Dim WlsSelList$
	Dim SWlsSelList As Object
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	Private pv_blnChange_Flg As Boolean
	
	Private DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07

    '20190620 ADD START
    Public UDN2_PARA1 As String
    '20190620 ADD END



    Private Sub COM_TANCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TANCD.Click

        '20190620 DEL START
        'DB_PARA(DBN_TANMTA).KeyBuf = WLSTANCD.Text
        '20190620 DEL END

        '2019/06/04 CHG START
        'WLSTAN.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
        '''98/09/25 �ǉ�
        'WLSTAN.Close()
        WLSTAN2.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
        ''98/09/25 �ǉ�
        WLSTAN2.Close()
        '2019/06/04 CHG END
        System.Windows.Forms.Application.DoEvents()
		WM_WLS_Dspflg = False
		KEYBAK.Items.Clear()
		LST.Items.Clear()
		Lst1.Items.Clear()
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        '2019/06/10 CHG START
        If IsDBNull(PP_SSSMAIN.SlistCom) Then
            'If IsDBNull(WLSTAN_RTNCODE) Then
            '2019/06/10 CHG END
            WLSTANCD.Text = ""
			WLSTANNM.Text = ""
		Else
            Call DB_GetEq(DBN_TANMTA, 1, PP_SSSMAIN.SlistCom, BtrNormal)

            If DBSTAT = 0 Then
				WLSTANCD.Text = DB_TANMTA.TANCD
				WLSTANNM.Text = DB_TANMTA.TANNM
			End If
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_STTKEY = "1"
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_ENDKEY = System.DBNull.Value
		WM_WLS_KeyCode = 0
		WM_WLS_Dspflg = True
        '''''    WM_WLS_KeyNo = WM_WLS_TextKey
        '2019/06/10 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '2019/06/10 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call WLS_BaseSQL(WM_WLS_STTKEY)


        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WLSSSS_SET_KEYBAK() = True Then
			Call WLSSSS_DSP()
		End If
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub

    Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click

        '20190620 DEL START
        'DB_PARA(DBN_TOKMTA).KeyBuf = WLSTOKCD.Text
        '20190620 DEL END

        '2019/06/04 CHG START
        'WLSTOK.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
        '''98/09/25 �ǉ�
        'WLSTOK.Close()
        WLSTOK3.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
        ''98/09/25 �ǉ�
        WLSTOK3.Close()
        '2019/06/04 CHG END
        System.Windows.Forms.Application.DoEvents()
        WM_WLS_Dspflg = False
        KEYBAK.Items.Clear()
        LST.Items.Clear()
        Lst1.Items.Clear()
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(PP_SSSMAIN.SlistCom) Then
            WLSTOKCD.Text = ""
            WLSTOKNM.Text = ""
        Else
            Call DB_GetEq(DBN_TOKMTA, 1, PP_SSSMAIN.SlistCom, BtrNormal)

            If DBSTAT = 0 Then
                WLSTOKCD.Text = DB_TOKMTA.TOKCD
                WLSTOKNM.Text = DB_TOKMTA.TOKRN
            End If
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WM_WLS_STTKEY = "1"
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WM_WLS_ENDKEY = System.DBNull.Value
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        '''''    WM_WLS_KeyNo = WM_WLS_TextKey
        '2019/06/11 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '2019/06/11 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call WLS_BaseSQL(WM_WLS_STTKEY)
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

        If WLSSSS_SET_KEYBAK() = True Then
            Call WLSSSS_DSP()
        End If
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        PP_SSSMAIN.SlistCom = System.DBNull.Value

    End Sub

    Private Sub COM_JDNTRKB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_JDNTRKB.Click
		Dim wkJDNTRKB As String
		
		WLS_MEI1.Text = "�󒍎���敪�ꗗ"
        CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
        '2019/06/10 CHG START
        '      Call DB_GetGrEq(DBN_MEIMTA, 3, "006", BtrNormal)
        'Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "006"
        '	If DB_MEIMTA.DATKB <> "9" Then
        '		CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
        '	End If
        '	Call DB_GetNext(DBN_MEIMTA, BtrNormal)
        'Loop 
        Dim strSQL As String

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "  from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  = '006' "
        strSQL = strSQL & "  Order By MEICDA "

        Dim dt As DataTable = DB_GetTable(strSQL)
        For i As Integer = 0 To dt.Rows.Count - 1
            Call Set_DB_MEIMTA(dt, DB_MEIMTA, i)
            CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
        Next
        '2019/06/10 CHG START
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
		WLS_MEI1.ShowDialog()
		WLS_MEI1.Close()
		System.Windows.Forms.Application.DoEvents()
		WM_WLS_Dspflg = False
		KEYBAK.Items.Clear()
		LST.Items.Clear()
		Lst1.Items.Clear()
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			WLSJDNTRKB.Text = ""
			WLSJDNTRNM.Text = ""
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkJDNTRKB = LeftWid(PP_SSSMAIN.SlistCom, 2) & Space(Len(DB_MEIMTA.MEICDA) - Len(LeftWid(PP_SSSMAIN.SlistCom, 2))) & Space(Len(DB_MEIMTA.MEICDB))
            '2019/06/10 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 1, "006" & wkJDNTRKB, BtrNormal)
            Call DSPMEIM_SEARCH("006", wkJDNTRKB, DB_MEIMTA)
            '2019/06/10 CHG END
            If DBSTAT = 0 Then
				WLSJDNTRKB.Text = LeftWid(DB_MEIMTA.MEICDA, 2)
				WLSJDNTRNM.Text = DB_MEIMTA.MEINMA
			End If
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_STTKEY = "1"
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_ENDKEY = System.DBNull.Value
		WM_WLS_KeyCode = 0
		WM_WLS_Dspflg = True
        '''''    WM_WLS_KeyNo = WM_WLS_TextKey
        '2019/06/10 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '2019/06/10 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call WLS_BaseSQL(WM_WLS_STTKEY)
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WLSSSS_SET_KEYBAK() = True Then
			Call WLSSSS_DSP()
		End If
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
	
	Private Sub COM_UDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_UDNDT.Click
		Dim I As Short
		
		Set_date.Value = CNV_DATE(DB_UNYMTA.UNYDT)
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		System.Windows.Forms.Application.DoEvents()
		WM_WLS_Dspflg = False
		KEYBAK.Items.Clear()
		LST.Items.Clear()
		Lst1.Items.Clear()
		WLSUDNDT.Text = Set_date.Value
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_STTKEY = "1"
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_ENDKEY = System.DBNull.Value
		WM_WLS_KeyCode = 0
		WM_WLS_Dspflg = True
        '2019/06/10 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '2019/06/10 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call WLS_BaseSQL(WM_WLS_STTKEY)
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WLSSSS_SET_KEYBAK() = True Then
			Call WLSSSS_DSP()
		End If
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
	
	'UPGRADE_WARNING: Form �C�x���g WLSUDN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSUDN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		'DEL START FKS)INABA 2009/02/27 ***********
		'���X�|���X�Ή�
		'    Call WLSSSS_FORM_ACTIVATE
		'DEL  END  FKS)INABA 2009/02/27 ***********
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = False
	End Sub

    Private Sub WLSUDN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call WLS_FORM_LOAD()
        Call WLSSSS_FORM_INIT()
        pv_blnChange_Flg = False
    End Sub

    '20190614 ADD START
    Private Sub WLSUDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190614 ADD END

    'UPGRADE_WARNING: �C�x���g HD_TEXT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TEXT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.TextChanged
		Dim s As Integer
		s = HD_TEXT.SelectionStart
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_TEXT.Text = VB.Left(StrConv(HD_TEXT.Text, VbStrConv.UpperCase), HD_TEXT.Maxlength)
		HD_TEXT.SelectionStart = s
		
	End Sub
	
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		'''    If LenWid(HD_TEXT.Text) > 0 Then
		'''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
		'''    Else
		'''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
		'''    End If
		HD_TEXT.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_TEXT.SelectionLength = HD_TEXT.Maxlength
	End Sub
	
	Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Object
		Dim STAT As Short
		
		Select Case KEYCODE
			Case 13
				WM_WLS_Dspflg = False
				KEYBAK.Items.Clear()
				LST.Items.Clear()
				Lst1.Items.Clear()
				'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
				HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
				HD_TEXT.SelectionStart = 0
				'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
				HD_TEXT.SelectionLength = HD_TEXT.Maxlength
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WM_WLS_STTKEY = "11" & HD_TEXT.Text
				'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WM_WLS_ENDKEY = System.DBNull.Value
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_KeyNo = WM_WLS_TextKey
				'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call WLS_BaseSQL(WM_WLS_STTKEY)
				KEYBAK.Items.Clear()
				LST.Items.Clear()
				Lst1.Items.Clear()
                '2019/06/10 CHG START
                'WM_WLS_Pagecnt = -1
                WM_WLS_Pagecnt = 0
                '20190607 CHG END
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If WLSSSS_SET_KEYBAK() = True Then
					Call WLSSSS_DSP()
				End If
				'        Case 40  '���L�[
				'            LST.ListIndex = 0
				'            LST.SetFocus
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
	End Sub
	
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
				Call WLS_SLIST_MOVE(VB6.GetItemString(Lst1, LST.SelectedIndex), WM_WLS_LEN)
                'DblClick�C�x���g��Q�Ή�  97/04/07
                'Call WLSCANCEL_CLICK
                '20190614 CHG START
                'If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                If DblClickFl = False Then Call btnF12_Click(btnF12, New System.EventArgs())
                '20190614 CHG END

            Case 27
                '20190614 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190614 CHG END

            Case 37 '���L�[
                '20190614 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190614 CHG END

                '       Case 38  '���L�[
                '           If LST.ListIndex = 0 Then
                '               LST.ListIndex = -1
                '               HD_TEXT.SetFocus
                '           End If
            Case 39 '���L�[
                '20190614 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190614 CHG END

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
		
		Call WLS_MEISQL()
        Call WLS_TRASQL()
        '2019/06/11  CHG START
        WK_DENDT.Value = VB.Left(DB_UDNTHA.DENDT, 4) & "/" & Mid(DB_UDNTHA.DENDT, 5, 2) & "/" & VB.Right(DB_UDNTHA.DENDT, 2)
        LST.Items.Add(VB.Left(DB_UDNTHA.JDNNO, 6) & "   " & LeftWid(DB_MEIMTA.MEINMA, 10) & " " & WK_DENDT.Value & " " & LeftWid(DB_UDNTHA.TOKRN, 40) & " " & LeftWid(DB_UDNTHA.KENNMA, 40))

        'WK_DENDT.Value = VB.Left(DB_UDNTHA.UDNDT, 4) & "/" & Mid(DB_UDNTHA.UDNDT, 5, 2) & "/" & VB.Right(DB_UDNTHA.UDNDT, 2)
        ''WK_DENDT.Value = VB.Left(DB_UDNTHA.UDNDT, 4) & "/" & Mid(DB_UDNTHA.UDNDT, 5, 2) & "/" & VB.Right(DB_UDNTHA.UDNDT, 2)
        '''''LST.AddItem Left$(DB_UDNTHA.JDNNO, 6) + Mid$(DB_UDNTRA.JDNLINNO, 2, 2) + "   " + AnsiLeftB(DB_MEIMTA.MEINMA, 10) + "  " + WK_DENDT + "  " _
        ''''''          + AnsiLeftB(DB_UDNTHA.TOKRN, 40) + "  " + AnsiLeftB(DB_UDNTHA.KENNMA, 40)
        'LST.Items.Add(VB.Left(DB_UDNTHA.JDNNO, 6) & "   " & AnsiLeftB(DB_MEIMTA.MEINMA, 10) & "  " & WK_DENDT.Value & "  " & AnsiLeftB(DB_UDNTHA.TOKRN, 40) & "  " & AnsiLeftB(DB_UDNTHA.KENNMA, 40))
        '2019/06/11 CHG END
        '2019/06/11 dell start
        Lst1.Items.Add(DB_UDNTHA.DATNO)
        '2019/06/11 dell end
    End Sub
	
	Sub WLS_TRASQL()
		
		''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
		'''    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		'''    WlsFromWhere = "From UDNTRA Where DATNO = '" & DB_UDNTHA.DATNO & "'" & " AND LINNO = '001'"
		'''    WlsOrderBy = ""
		'''    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		'''    Call DB_GetSQL2(WM_WLS_SFIL1, DB_SQLBUFF)
	End Sub
	
	Sub WLS_MEISQL()

        ''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
        '20190619 DEL START
        'Call MEIMTA_RClear()
        '20190619 DEL END

        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        '2019/06/10 CHG START
        '      WlsFromWhere = "From MEIMTA Where KEYCD = '006'" & " And MEICDA = '" & DB_UDNTHA.JDNTRKB & "'" & " And MEICDB = ' '"
        'WlsOrderBy = "Order By MEICDA, MEICDB"
        ''UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        '      Call DB_GetSQL2(WM_WLS_SFIL, DB_SQLBUFF)
        'WlsFromWhere = "Where KEYCD = '006'" & " And MEICDA = '" & DB_UDNTHA.JDNTRKB & "'" & " And MEICDB = ' '"
        ' WlsOrderBy = "Order By MEICDA, MEICDB"

        Call DSPMEIM_SEARCH("006", DB_UDNTHA.JDNTRKB, DB_MEIMTA)
        '2019/06/10
    End Sub
	
	Private Function WLS_DSP_CHECK() As Object
		Dim wkTOKCD As String
		Dim wkTANCD As String
		
		'====================================
		'   WINDOW �\���\�`�F�b�N
		'       WLS_DSP_CHECK = True  :�\����
		'       WLS_DSP_CHECK = FALSE :�\���s��
		'====================================
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLS_DSP_CHECK = SSS_OK
		If DB_UDNTHA.DATKB <> "1" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLS_DSP_CHECK = SSS_END
			Exit Function
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If DB_UDNTHA.DENKB <> "1" Then WLS_DSP_CHECK = SSS_END
        'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If DB_UDNTHA.AKAKROKB <> "1" Then WLS_DSP_CHECK = SSS_NEXT
        '2019/06/11 DELL START
        '      wkTOKCD = WLSTOKCD.Text & Space(Len(DB_UDNTHA.TOKCD) - Len(WLSTOKCD.Text))
        ''CHG START FKS)INABA 2009/02/27 ******************
        ''�󔒏����Ή�
        'wkTANCD = WLSTANCD.Text & Space(Len(DB_UDNTHA.TANCD) - Len(WLSTANCD.Text))
        ''UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If (Trim(WLSTOKCD.Text) <> "") And (Trim(DB_UDNTHA.TOKCD) <> Trim(wkTOKCD)) Then WLS_DSP_CHECK = SSS_NEXT
        ''UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If (Trim(WLSTANCD.Text) <> "") And (Trim(DB_UDNTHA.TANCD) <> Trim(wkTANCD)) Then WLS_DSP_CHECK = SSS_NEXT
        ''UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If (Trim(WLSJDNTRKB.Text) <> "") And (Trim(DB_UDNTHA.JDNTRKB) <> Trim(WLSJDNTRKB.Text)) Then WLS_DSP_CHECK = SSS_NEXT
        ''    wkTANCD = WLSTANCD.Text & Space(Len(DB_UDNTHA.TANCD) - Len(WLSTANCD.Text))
        ''    If (Trim$(WLSTOKCD.Text) <> "") And (DB_UDNTHA.TOKCD <> wkTOKCD) Then WLS_DSP_CHECK = SSS_NEXT
        ''    If (Trim$(WLSTANCD.Text) <> "") And (DB_UDNTHA.OPEID <> wkTANCD) Then WLS_DSP_CHECK = SSS_NEXT
        ''    If (Trim$(WLSJDNTRKB.Text) <> "") And (DB_UDNTHA.JDNTRKB <> WLSJDNTRKB.Text) Then WLS_DSP_CHECK = SSS_NEXT
        ''CHG START FKS)INABA 2009/02/27 ******************
        ''UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If (Trim(WLSUDNDT.Text) <> "") And (DB_UDNTHA.UDNDT < DeCNV_DATE(WLSUDNDT.Text)) Then WLS_DSP_CHECK = SSS_NEXT
        ''UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If (Trim(HD_TEXT.Text) <> "") And (DB_UDNTHA.JDNNO < HD_TEXT.Text) Then WLS_DSP_CHECK = SSS_NEXT
        '      Call DB_GetEq(DBN_UDNTRA, 1, DB_UDNTHA.DATNO & "001", BtrNormal)
        '      '����f�[�^�𒊏o
        '2019/06/11 DELL END
        'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If DB_UDNTRA.DKBID <> "01" Then WLS_DSP_CHECK = SSS_NEXT
	End Function
	
	Private Function WLS_DSP_SUB_CHECK() As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_SUB_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLS_DSP_SUB_CHECK = SSS_OK
	End Function
	
	Private Sub WLS_FORM_LOAD()
		
		'=== WINDOW �ʒu�ݒ� ===
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		
		'=== ����TEXT ===
		'WLSTOKCD.Height = 330
		'WLSRN.Height = 330
		'''''    WLSTOKCD.Text = ""
		'''''    WLSTOKRN.Caption = ""
		
		'=== WINDOW �\���t�@�C���ݒ� ===
		WM_WLS_MFIL = DBN_UDNTHA
		WM_WLS_SFIL = DBN_MEIMTA
		WM_WLS_SFIL1 = DBN_UDNTRA

        '=== �\���J�n�R�[�h�����ݒ� ===
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/06/05 CHG START
        'WM_WLS_LEN = LenWid(DB_UDNTHA.DATNO)
        WM_WLS_LEN = 10
        '2019/06/05 CHG END

        'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SWlsSelList = "*"

        '=== �k�`�a�d�k�ݒ� ===
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/06/05 CHG START
        '		WLSLABEL = "�󒍔ԍ� �󒍎��    �����      ���Ӑ�                                   ����"

        WLSLABEL.Text = "�󒍔ԍ� �󒍎��  �����     ���Ӑ�                                  ����"
        '2019/06/05 CHG END
        '=== �R���{�a�n�w�ݒ� ===
        WM_WLS_INIT = 0
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'UnLoad�C�x���g��Q�Ή�  97/04/07

        '20190614 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190614 CHG END
    End Sub

    '20190611 CHG START
    '   Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
    '	Dim WL_Key As String

    '	If LST.Items.Count > 0 Then
    '		If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
    '			Exit Sub
    '		Else
    '			If (WM_WLS_Pagecnt + 1) > (KEYBAK.Items.Count - 1) Then
    '				'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
    '				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				If WLSSSS_SET_KEYBAK() = False Then Exit Sub
    '			Else
    '				WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '				WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
    '				'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
    '				Call WLS_BaseSQL(WL_Key)
    '			End If
    '			Call WLSSSS_DSP()
    '		End If
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
        Dim WL_Key As String
        'change start 20190829 kuwa
        'If LST.Items.Count > 0 Then 
        If LST.Items.Count > 19 Then '1�y�[�W�ɕ\�����閾�׍s��19�s�ł��邽�߁B
            'change end 20190829 kuwa
            If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
                Exit Sub
            Else
                If (WM_WLS_Pagecnt + 1) > (KEYBAK.Items.Count - 1) Then
                    'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If WLSSSS_SET_KEYBAK() = False Then Exit Sub
                Else
                    WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                    '20190614 CHG START
                    'WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
                    WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt * 19)
                    '20190614 CHG END

                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                    Call WLS_BaseSQL(WL_Key)
                End If
                Call WLSSSS_DSP()
            End If
        End If
    End Sub


    '20190614 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_TEXT.Focused Then
                Call HD_TEXT_KeyDown(HD_TEXT, New System.Windows.Forms.KeyEventArgs(Keys.Return))

            ElseIf Me.WLSJDNTRKB.Focused Then
                Call WLSJDNTRKB_KeyDown(WLSJDNTRKB, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.WLSUDNDT.Focused Then
                Call WLSUDNDT_KeyDown(WLSUDNDT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.WLSTOKCD.Focused Then
                Call WLSTOKCD_KeyDown(WLSTOKCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))

            Else
                Call WLSTANCD_KeyDown(WLSTANCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʌ����G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try

            Me.WLSTANCD.Text = ""
            Me.WLSTANNM.Text = ""
            Me.HD_TEXT.Text = ""
            Me.WLSJDNTRKB.Text = ""
            Me.WLSJDNTRNM.Text = ""
            Me.WLSUDNDT.Text = ""
            Me.WLSTOKCD.Text = ""
            Me.WLSTOKNM.Text = ""
            LST.Items.Clear()
            Me.WLSTANCD.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    '20190614 ADD END

    '20190614 CHG START
    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	'UnLoad�C�x���g��Q�Ή�  97/04/07
    '	'Unload Me
    '	Hide()
    'End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        'UnLoad�C�x���g��Q�Ή�  97/04/07
        'Unload Me
        Hide()
    End Sub
    '20190614 CHG END


    'UPGRADE_WARNING: �C�x���g WLSTANCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub WLSTANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTANCD.TextChanged
		Dim s As Integer
		s = WLSTANCD.SelectionStart
		WLSTANCD.Text = StrConv(WLSTANCD.Text, VbStrConv.UpperCase)
		WLSTANCD.SelectionStart = s
	End Sub
	
	Private Sub WLSTANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTANCD.Enter
		'''    If LenWid(WLSTANCD.Text) > 0 Then
		'''        WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, LenWid(DB_TANMTA.TANCD), "0")
		'''    Else
		'''        WLSTANCD.Text = Space$(LenWid(DB_TANMTA.TANCD))
		'''    End If
		WLSTANCD.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSTANCD.SelectionLength = LenWid(DB_TANMTA.TANCD)
		
	End Sub
	
	Private Sub WLSTANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTANCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Object
		Dim STAT As Short
		
		Select Case KEYCODE
			Case 13

                WM_WLS_Dspflg = False
                KEYBAK.Items.Clear()
				LST.Items.Clear()
				Lst1.Items.Clear()
                '2019/06/10 CHG START
                'WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, LenWid(DB_TANMTA.TANCD), "0")
                WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, 6S, "0")
                '2019/06/10 CHG END
                WLSTANCD.SelectionStart = 0
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLSTANCD.SelectionLength = LenWid(DB_TANMTA.TANCD)
				If Trim(WLSTANCD.Text) = "" Then
					WLSTANNM.Text = ""
					'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WM_WLS_STTKEY = "1"
					'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WM_WLS_ENDKEY = System.DBNull.Value
					WM_WLS_KeyCode = 0
					WM_WLS_Dspflg = True
                    '2019/06/10 CHG START
                    'WM_WLS_Pagecnt = -1
                    WM_WLS_Pagecnt = 0
                    '2019/06/10 CHG END
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If WLSSSS_SET_KEYBAK() = True Then
						Call WLSSSS_DSP()
					End If
				Else
                    Call DB_GetEq(DBN_TANMTA, 1, WLSTANCD.Text, BtrNormal)

                    If DBSTAT = 0 Then
						WLSTANNM.Text = DB_TANMTA.TANNM
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_STTKEY = "1"
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_ENDKEY = System.DBNull.Value
						WM_WLS_KeyCode = 0
						WM_WLS_Dspflg = True
                        '2019/06/10 CHG START
                        'WM_WLS_Pagecnt = -1
                        WM_WLS_Pagecnt = 0
                        '2019/06/10 CHG END
                        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        Call WLS_BaseSQL(WM_WLS_STTKEY)
                        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If WLSSSS_SET_KEYBAK() = True Then
							Call WLSSSS_DSP()
						End If
					End If
				End If
				'        Case 40  '���L�[
				'            LST.ListIndex = 0
				'            LST.SetFocus
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	Private Sub WLSTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.Enter
		'''    If LenWid(WLSTOKCD.Text) > 0 Then
		'''        WLSTOKCD.Text = SSS_EDTITM_WLS(WLSTOKCD.Text, LenWid(DB_TOKMTA.TOKCD), "0")
		'''    Else
		'''        WLSTOKCD.Text = Space$(LenWid(DB_TOKMTA.TOKCD))
		'''    End If
		WLSTOKCD.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSTOKCD.SelectionLength = LenWid(DB_TOKMTA.TOKCD)
		
	End Sub
	
	Private Sub WLSTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTOKCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Object
		Dim STAT As Short
		
		Select Case KEYCODE
			Case 13
				WM_WLS_Dspflg = False
				KEYBAK.Items.Clear()
				LST.Items.Clear()
				Lst1.Items.Clear()
				'WLSTOKCD.Text = SSS_EDTITM_WLS(WLSTOKCD.Text, LenWid(DB_TOKMTA.TOKCD), "0")
				WLSTOKCD.SelectionStart = 0
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLSTOKCD.SelectionLength = LenWid(DB_TOKMTA.TOKCD)
				If Trim(WLSTOKCD.Text) = "" Then
					WLSTOKNM.Text = ""
					'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WM_WLS_STTKEY = "1"
					'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WM_WLS_ENDKEY = System.DBNull.Value
					WM_WLS_KeyCode = 0
					WM_WLS_Dspflg = True
                    '2019/06/10 CHG START
                    'WM_WLS_Pagecnt = -1
                    WM_WLS_Pagecnt = 0
                    '2019/06/10 CHG END
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If WLSSSS_SET_KEYBAK() = True Then
						Call WLSSSS_DSP()
					End If
				Else
                    Call DB_GetEq(DBN_TOKMTA, 1, WLSTOKCD.Text, BtrNormal)

                    If DBSTAT = 0 Then
						WLSTOKNM.Text = DB_TOKMTA.TOKRN
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_STTKEY = "1"
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_ENDKEY = System.DBNull.Value
						WM_WLS_KeyCode = 0
						WM_WLS_Dspflg = True
                        '2019/06/10 CHG START
                        'WM_WLS_Pagecnt = -1
                        WM_WLS_Pagecnt = 0
                        '2019/06/10 CHG END
                        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        Call WLS_BaseSQL(WM_WLS_STTKEY)
                        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If WLSSSS_SET_KEYBAK() = True Then
							Call WLSSSS_DSP()
						End If
					End If
				End If
				'        Case 40  '���L�[
				'            LST.ListIndex = 0
				'            LST.SetFocus
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	Private Sub WLSJDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSJDNTRKB.Enter
		'''    If LenWid(WLSJDNTRKB.Text) > 0 Then
		'''        WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_UDNTHA.JDNTRKB), "0")
		'''    Else
		'''        WLSJDNTRKB.Text = Space$(LenWid(DB_UDNTHA.JDNTRKB))
		'''    End If
		WLSJDNTRKB.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSJDNTRKB.SelectionLength = LenWid(DB_UDNTHA.JDNTRKB)
		
	End Sub
	
	Private Sub WLSJDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSJDNTRKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Object
		Dim STAT As Short
		Dim wkJDNTRKB As String
		
		Select Case KEYCODE
			Case 13
				WM_WLS_Dspflg = False
				KEYBAK.Items.Clear()
				LST.Items.Clear()
				Lst1.Items.Clear()
                '2019/06/10 CHG START
                'WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_JDNTHA.JDNTRKB), "0")
                If DB_JDNTHA.JDNTRKB Is Nothing Then
                    WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, 2, "0")
                Else
                    WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_JDNTHA.JDNTRKB), "0")
                End If
                '2019/06/10 CHG END
                WLSJDNTRKB.SelectionStart = 0
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLSJDNTRKB.SelectionLength = LenWid(DB_UDNTHA.JDNTRKB)
				If Trim(WLSJDNTRKB.Text) = "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WM_WLS_STTKEY = "1"
					'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WM_WLS_ENDKEY = System.DBNull.Value
					WM_WLS_KeyCode = 0
					WM_WLS_Dspflg = True
                    '2019/06/10 CHG START
                    'WM_WLS_Pagecnt = -1
                    WM_WLS_Pagecnt = 0
                    '2019/06/10 CHG END
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If WLSSSS_SET_KEYBAK() = True Then
						Call WLSSSS_DSP()
					End If
				Else
                    '2019/06/10 CHG START
                    'wkJDNTRKB = WLSJDNTRKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSJDNTRKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
                    If DB_MEIMTA.MEICDA Is Nothing Then
                        wkJDNTRKB = WLSJDNTRKB.Text & Space(20 - Len(WLSJDNTRKB.Text)) & Space(5)
                    Else
                        wkJDNTRKB = WLSJDNTRKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSJDNTRKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
                    End If
                    '2019/06/10 CHG END
                    '2019/06/10 CHG START
                    'Call DB_GetEq(DBN_MEIMTA, 1, "006" & wkJDNTRKB, BtrNormal)
                    Call DSPMEIM_SEARCH("006", wkJDNTRKB, DB_MEIMTA)
                    '2019/06/10 CHG END
                    If DBSTAT = 0 Then
						WLSJDNTRNM.Text = DB_MEIMTA.MEINMA
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_STTKEY = "1"
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_ENDKEY = System.DBNull.Value
						WM_WLS_KeyCode = 0
						WM_WLS_Dspflg = True
                        '2019/06/10 CHG START
                        'WM_WLS_Pagecnt = -1
                        WM_WLS_Pagecnt = 0
                        '2019/06/10 CHG END
                        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        Call WLS_BaseSQL(WM_WLS_STTKEY)
                        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If WLSSSS_SET_KEYBAK() = True Then
							Call WLSSSS_DSP()
						End If
					End If
				End If
				'        Case 40  '���L�[
				'            LST.ListIndex = 0
				'            LST.SetFocus
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSUDNDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSUDNDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.TextChanged
		WLSUDNDT.SelectionLength = 1
		If pv_blnChange_Flg = True Then
			Exit Sub
		Else
			Call CtrlDatChange(WLSUDNDT)
		End If
	End Sub
	
	Private Sub WLSUDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.Click
		WLSUDNDT.SelectionStart = 0
		WLSUDNDT.SelectionLength = 1
	End Sub
	
	Private Sub WLSUDNDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.Enter
		If Len(Trim(WLSUDNDT.Text)) = 0 Then
			pv_blnChange_Flg = True
			WLSUDNDT.Text = Space(10)
			pv_blnChange_Flg = False
			WLSUDNDT.SelectionStart = 0
			WLSUDNDT.SelectionLength = 1
		ElseIf Len(Trim(WLSUDNDT.Text)) >= 8 Then 
			WLSUDNDT.SelectionStart = 8
			WLSUDNDT.SelectionLength = 1
		Else
			WLSUDNDT.SelectionStart = 0
			WLSUDNDT.SelectionLength = 1
		End If
	End Sub
	
	Private Sub WLSUDNDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSUDNDT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim strDat As String
		
		Dim I As Short
		Dim W_Key As String
		Select Case True
			'��������
			Case KEYCODE = System.Windows.Forms.Keys.Return And Shift = 0
				
				If Trim(WLSUDNDT.Text) <> "" Then
                    '2019/06/10 CHG START
                    'If CHECK_DATE(WLSUDNDT) = False Then
                    If CHECK_DATE(WLSUDNDT.Text) = False Then
                        '2019/06/10 CHG END
                        Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '���t�G���[
                        WLSUDNDT.Focus()
                        Exit Sub
                    End If
                End If
				WM_WLS_Dspflg = False
				KEYBAK.Items.Clear()
				LST.Items.Clear()
				Lst1.Items.Clear()
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WM_WLS_STTKEY = "1"
				'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WM_WLS_ENDKEY = System.DBNull.Value
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
                '2019/06/10  CHG START
                'WM_WLS_Pagecnt = -1
                WM_WLS_Pagecnt = 0
                '2019/06/10  CHG END
                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call WLS_BaseSQL(WM_WLS_STTKEY)
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If WLSSSS_SET_KEYBAK() = True Then
					Call WLSSSS_DSP()
				End If
				
				'����
			Case KEYCODE = System.Windows.Forms.Keys.Right And Shift = 0
				KEYCODE = 0
				'������
				If WLSUDNDT.SelectionStart < Len(WLSUDNDT.Text) Then
					WLSUDNDT.SelectionStart = WLSUDNDT.SelectionStart + 1
					WLSUDNDT.SelectionLength = 1
					Call NextForcus(WLSUDNDT)
				End If
				
				'����
			Case KEYCODE = System.Windows.Forms.Keys.Down And Shift = 0
				'������
				KEYCODE = 0
				
				'����
			Case KEYCODE = System.Windows.Forms.Keys.Up And Shift = 0
				'������
				KEYCODE = 0
				
				'����
			Case KEYCODE = System.Windows.Forms.Keys.Left And Shift = 0
				KEYCODE = 0
				'������
				If WLSUDNDT.SelectionStart > 0 Then
					WLSUDNDT.SelectionStart = WLSUDNDT.SelectionStart - 1
					WLSUDNDT.SelectionLength = 1
					Call PrevForcus(WLSUDNDT)
				End If
				
			Case KEYCODE = System.Windows.Forms.Keys.Delete And Shift = 0
				KEYCODE = 0
				
				''        'TAB��
				''        Case KEYCODE = vbKeyF16
				''            Call F_SendKey(KEYCODE, "HD_KESIDT")
				''        Case KEYCODE = vbKeyS And Shift = 2
				''            pv_blnChange_Flg = True
				''            WLSUDNDT.Text = Space(10)
				''            WLSUDNDT.SelStart = 0
				''            WLSUDNDT.SelLength = 1
				''            pv_blnChange_Flg = False
				
		End Select
	End Sub
	
	Private Sub WLSUDNDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles WLSUDNDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = System.Windows.Forms.Keys.Back Then
			KeyAscii = 0
			pv_blnChange_Flg = True
			If WLSUDNDT.SelectionStart > 0 Then
				WLSUDNDT.SelectionStart = WLSUDNDT.SelectionStart - 1
			End If
			WLSUDNDT.SelectionLength = 1
			Call PrevForcus(WLSUDNDT)
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
	
	Private Sub WLSUDNDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.Leave
		'''    Dim I As Integer
		'''    Dim W_Key As String
		'''    Dim strDat As String
		'''
		'''    If Trim$(WLSUDNDT) <> "" Then
		'''        If ConvDat(Trim(WLSUDNDT.Text), strDat) = False Then
		'''            WLSUDNDT.SetFocus
		'''            Exit Sub
		'''        End If
		'''        If CHECK_DATE(WLSUDNDT) = False Then
		'''            Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '���t�G���[
		'''            WLSUDNDT.SetFocus
		'''            Exit Sub
		'''        End If
		'''    End If
		'''    WM_WLS_STTKEY = "1"
		'''    WM_WLS_ENDKEY = Null
		'''    WM_WLS_KeyCode = 0
		'''    WM_WLS_Dspflg = True
		'''    WM_WLS_Pagecnt = -1
		'''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
		'''    If WLSSSS_SET_KEYBAK() = True Then
		'''        Call WLSSSS_DSP
		'''    End If
		'''
	End Sub
    '''''
    '''''Private Sub WLSHINNMA_LOSTFocus()
    '''''    Dim I As Integer
    '''''    Dim W_Key As String
    '''''
    '''''    WM_WLS_STTKEY = "1"
    '''''    WM_WLS_ENDKEY = Null
    '''''    WM_WLS_KeyCode = 0
    '''''    WM_WLS_Dspflg = True
    '''''    WM_WLS_Pagecnt = -1
    '''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
    '''''    If WLSSSS_SET_KEYBAK() = True Then
    '''''        Call WLSSSS_DSP
    '''''    End If
    '''''
    '''''End Sub

    '20190614 CHG START
    '   Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '	Dim WL_Key As String

    '	If WM_WLS_Pagecnt > 0 Then
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '	Else
    '		Exit Sub
    '	End If
    '	WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
    '	'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
    '	Call WLS_BaseSQL(WL_Key)
    '	Call WLSSSS_DSP()
    'End Sub

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

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        Dim WL_Key As String

        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
        Else
            Exit Sub
        End If
        '20190614 CHG START
        'WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
        WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt * 19)
        '20190614 CHG END
        'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
        Call WLS_BaseSQL(WL_Key)
        Call WLSSSS_DSP()
    End Sub
    '20190614 CHG END


    '20190614 CHG START
    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '    Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub
    '20190614 CHG END

    Private Sub WLSSSS_DSP()
		Dim WL_Mode As Short
		Dim WL_Key As String
		
		If WM_WLS_Dspflg = False Then Exit Sub
		
		LST.Items.Clear()
        Lst1.Items.Clear()

        '20190614 DEL START
        'If DBSTAT = 0 Then
        '20190614 DEL END

        '2019/06/10 CHG START
        'Do While (DBSTAT = 0) And (LST.Items.Count < WM_WLS_MAX) And (WL_Mode <> SSS_END)
        '    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    WL_Mode = WLSSSS_DSP_CHECK()
        '    If WL_Mode = SSS_OK Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        WL_Mode = WLS_DSP_CHECK()
        '        If WL_Mode = SSS_OK Then
        '            Call WLS_DISPLAY()
        '        End If
        '    End If
        '    If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
        '        Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '    ElseIf WL_Mode = SSS_RPSN Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        WL_Key = WLSSSS_RPSN()
        '        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        If LenWid(WL_Key) = 0 Then
        '            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '        Else
        '            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
        '        End If
        '    ElseIf WL_Mode = SSS_NPSN Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        WL_Key = WLSSSS_NPSN()
        '        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        If LenWid(WL_Key) = 0 Then
        '            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '        Else
        '            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
        '        End If
        '    End If
        'Loop

        Dim dt As DataTable = dsList.Tables("tableName")

        For i As Integer = 0 To dt.Rows.Count - 1
            DB_UDNTHA.DENDT = DB_NullReplace(dt.Rows(i).Item("DENDT"), "")
            DB_UDNTHA.JDNNO = DB_NullReplace(dt.Rows(i).Item("JDNNO"), "")
            DB_UDNTHA.TOKRN = DB_NullReplace(dt.Rows(i).Item("TOKRN"), "")
            DB_UDNTHA.KENNMA = DB_NullReplace(dt.Rows(i).Item("KENNMA"), "")
            DB_UDNTHA.JDNTRKB = DB_NullReplace(dt.Rows(i).Item("JDNTRKB"), "")

            DB_UDNTHA.DATNO = DB_NullReplace(dt.Rows(i).Item("DATNO"), "")

            Call WLS_DISPLAY()
        Next
        '2019/06/10 CHG END
        If LST.Items.Count > 0 Then
            LST.SelectedIndex = 0
        End If

        '20190614 DEL START
        'End If
        '20190614 DEL END

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

            '20190620 CHG START
            'If LeftWid(DB_PARA(WM_WLS_MFIL).KeyBuf, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    WLSSSS_DSP_CHECK = SSS_END
            '    Exit Function
            'End If
            If LeftWid(UDN2_PARA1, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WLSSSS_DSP_CHECK = SSS_END
                Exit Function
            End If
            '20190620 CHG END

        End If
		
	End Function
	
	Private Sub WLSSSS_FORM_ACTIVATE()
		Dim I As Short
		Dim W_Key As String
		
		WM_WLS_Dspflg = False
		WM_WLS_KeyCode = 0
		WM_WLS_Dspflg = True
        '2019/06/10 CHG START
        'WM_WLS_Pagecnt = -1
        WM_WLS_Pagecnt = 0
        '2019/06/10 CHG END
        ''98/09/25 �폜
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        '20190620 CHG START
        'W_Key = DB_PARA(WM_WLS_MFIL).KeyBuf
        W_Key = UDN2_PARA1
        '20190620 CHG END

        Call WLS_BaseSQL(W_Key)
		'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WLSSSS_SET_KEYBAK() = True And WM_WLS_INIT = 0 Then
			'2001/07/25 �ǉ���s
			WM_WLS_INIT = 1
			Call WLSSSS_DSP()
		End If
	End Sub
	
	Private Sub WLSSSS_FORM_INIT()
		Dim I As Short
		
		WM_WLS_KeyCode = False
		WM_WLS_MAX = VB6.PixelsToTwipsY(LST.Height) \ 240
		'HD_TEXT.Height = 330
		''''HD_TEXT.MaxLength = WM_WLS_LEN
		''''HD_TEXT.Width = (WM_WLS_LEN + 1) * 120
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_TEXT.Maxlength = 6
		HD_TEXT.Width = VB6.TwipsToPixelsX((6 + 1) * 120)
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_STTKEY = "1"
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_ENDKEY = System.DBNull.Value
		HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(DB_PARA(WM_WLS_MFIL).KeyBuf)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

        '20190620 CHG START
        'If LenWid(Trim(DB_PARA(WM_WLS_MFIL).KeyBuf)) = 0 Then
        '    HD_TEXT.Text = ""
        'End If
        If LenWid(Trim(UDN2_PARA1)) = 0 Then
            HD_TEXT.Text = ""
        End If
        '20190620 CHG END

        ''98/09/25 �ǉ�
        WM_WLS_KeyNo = WM_WLS_TextKey
		
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
        '2019/06/10 CHG START
        '      Do While DBSTAT = 0
        '	'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	WL_Mode = WLSSSS_DSP_CHECK()
        '	If WL_Mode = SSS_OK Then
        '		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		WL_Mode = WLS_DSP_CHECK()
        '		If WL_Mode = SSS_OK Then
        '			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '			'KEYBAK.AddItem DB_PARA(WM_WLS_MFIL).KeyBuf
        '			KEYBAK.Items.Add(DB_UDNTHA.DATKB & DB_UDNTHA.DENKB & DB_UDNTHA.JDNNO & DB_UDNTHA.DATNO)
        '		End If
        '	End If
        '	If WL_Mode = SSS_NEXT Then
        '		Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '	ElseIf WL_Mode = SSS_RPSN Then 
        '		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		WL_Key = WLSSSS_RPSN()
        '		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		If LenWid(WL_Key) = 0 Then
        '			Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '		Else
        '			Call WLS_BaseSQL(WL_Key)
        '			'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
        '		End If
        '	ElseIf WL_Mode = SSS_NPSN Then 
        '		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		WL_Key = WLSSSS_NPSN()
        '		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		If LenWid(WL_Key) = 0 Then
        '			Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '		Else
        '			Call WLS_BaseSQL(WL_Key)
        '			'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
        '		End If
        '	Else
        '		Exit Do
        '	End If
        'Loop 
        Dim dt As DataTable = dsList.Tables("tableName")

        For i As Integer = 0 To dt.Rows.Count - 1
            DB_UDNTHA.DENDT = DB_NullReplace(dt.Rows(i).Item("DENDT"), "")
            DB_UDNTHA.JDNNO = DB_NullReplace(dt.Rows(i).Item("JDNNO"), "")
            DB_UDNTHA.TOKRN = DB_NullReplace(dt.Rows(i).Item("TOKRN"), "")
            DB_UDNTHA.KENNMA = DB_NullReplace(dt.Rows(i).Item("KENNMA"), "")
            DB_UDNTHA.JDNTRKB = DB_NullReplace(dt.Rows(i).Item("JDNTRKB"), "")

            KEYBAK.Items.Add(DB_UDNTHA.DATKB & DB_UDNTHA.DENKB & DB_UDNTHA.JDNNO)
        Next
        '2019/06/10 CHG END
        '2019/06/10 DELL START
        '      If DBSTAT <> 0 Or WL_Mode = SSS_END Then
        '	'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	WLSSSS_SET_KEYBAK = False
        'End If
        '2019/06/10 DELL END
    End Function
	
	Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/06/04 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/06/04 CHG END
    End Function
	
	Function AnsiLenB(ByVal StrArg As String) As Integer
        '�T�v�F����������
        '�����FStrArg,Input,String,�Ώە�����
        '�����FAnsi���ނ��޲ĵ��ނŕ�������޲Đ���Ԃ�
#If Win32 Then
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/06/04 CHG START
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
        '2019/06/04 CHG END
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiLenB = LenB(StrArg)
#End If
    End Function
	
	' StrConv ���Ăяo���܂��B
	Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g flag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g StrArg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiStrConv = StrArg
#End If
		
	End Function
	
	Public Function GP_Get_NM(ByVal strNM As String, ByVal lngMR As Integer) As String
		
		Dim lngMoji As Integer
		Dim lngKeta As Integer
		
		lngMoji = 0
		lngKeta = 0
		GP_Get_NM = ""
		
		If AnsiLenB(strNM) <= lngMR Then
			GP_Get_NM = strNM
			Exit Function
		End If
		
		If AnsiLenB(strNM) > lngMR Then
			
			Do Until lngKeta >= lngMR
				lngMoji = lngMoji + 1
                'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
                '2019/06/04 CHG START
                'lngKeta = lngKeta + LenB(StrConv(Mid(strNM, lngMoji, 1), vbFromUnicode))
                lngKeta = lngKeta + LenB(Mid(strNM, lngMoji, 1))
                '2019/06/04 CHG END
            Loop 
			
			If lngKeta > lngMR Then
				GP_Get_NM = VB.Left(strNM, lngMoji - 1)
			Else
				GP_Get_NM = VB.Left(strNM, lngMoji)
			End If
		End If
		
	End Function
	
	Private Function ConvDat(ByVal strTarget As String, ByRef strDat As String) As Boolean
		
		Dim blnRtnVal As Boolean
		Dim strYYYY As String
		Dim strMM As String
		Dim strDD As String
		
		blnRtnVal = False
		strDat = ""
		strYYYY = ""
		strMM = ""
		strDD = ""
		
		If IsDate(strTarget) = True Then
			strDat = strTarget
			blnRtnVal = True
		Else
			If Len(strTarget) = 8 Then
				strYYYY = VB.Left(strTarget, 4)
				strMM = Mid(strTarget, 5, 2)
				strDD = VB.Right(strTarget, 2)
				If IsDate(strYYYY & "/" & strMM & "/" & strDD) = True Then
					strDat = strYYYY & "/" & strMM & "/" & strDD
					blnRtnVal = True
				End If
			End If
		End If
		
		ConvDat = blnRtnVal
		
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
                '2019/06/04 CHG START
                'Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, 10)
                Rtn_Str_Value = LeftB(Rtn_Str_Value, 10)
                '2019/06/04 CHG END
            Else
                '�\���`���L
                ''2019/06/04 CHG START
                '				Rtn_Str_Value = CF_Ctr_AnsiLeftB(VB6.Format(Rtn_Str_Value, "0000/00/00") & New String(Space(1), 10), 10)

                Rtn_Str_Value = LeftB(VB6.Format(Rtn_Str_Value, "0000/00/00") & New String(Space(1), 10), 10)

                '2019/06/04 CHG END
            End If
		End If
		
		CnvDspItem_Date = Rtn_Str_Value
		
	End Function
	
	Private Function NextForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object
		
		Dim Index_Wk As Short
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
				''                Select Case Ctl.NAME
				''                    Case WLSHDNDT.NAME
				''                        If IsDate(Ctl.Text) = True Then
				''                            WLSHDNDT.ForeColor = COLOR_BLACK
				''                            WLSSIRCD.SetFocus
				''                        End If
				''                End Select
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
						''                        Select Case Ctl.NAME
						''                            Case WLSHDNDT.NAME
						''                                If IsDate(Ctl.Text) = True Then
						''                                    WLSHDNDT.ForeColor = COLOR_BLACK
						''                                    WLSSIRCD.SetFocus
						''                                End If
						''                        End Select
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
	
	Private Function PrevForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object
		
		Dim Index_Wk As Short
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
				''                Select Case Ctl.NAME
				''                    Case WLSHDNDT.NAME
				''                        If IsDate(Ctl.Text) = True Then
				''                            WLSHDNDT.ForeColor = COLOR_BLACK
				''                            WLSHDNTRKB.SetFocus
				''                        End If
				''                End Select
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
					'                    For Wk_Point = Act_SelStart + 1 To 0 Step -1       ' DEL 2007/02/20
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
						''                Select Case Ctl.NAME
						''                    Case WLSHDNDT.NAME
						''                        If IsDate(Ctl.Text) = True Then
						''                            WLSHDNDT.ForeColor = COLOR_BLACK
						''                            WLSHDNTRKB.SetFocus
						''                        End If
						''                End Select
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
	
	
	Private Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer

        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/06/04 CHG START
        'CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))
        CF_Ctr_AnsiLenB = LenB(pm_Value)
        '2019/06/04 CHG END

        Exit Function
		
	End Function
	
	Private Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String

        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/06/04 CHG START
        'CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
        CF_Ctr_AnsiLeftB = LeftB(pm_Value, pm_Len)
        '2019/06/04 CHG END

        Exit Function
		
	End Function
	
	
	Sub WLS_BaseSQL(Optional ByVal strKeyBak As String = " ")
		Dim strSQL As String
		Dim wkTOKCD As String
		Dim wkTANCD As String
		Dim strSQLWhere As String
		Dim strSQLWhereB As String
		
		strSQL = ""
        strSQLWhere = ""
        '2019/06/10 DELL  START
        'strSQLWhereB = ""
        '2019/06/10 DELL END
        '2019/06/11 CHG START
        'wkTOKCD = WLSTOKCD.Text & Space(Len(DB_UDNTHA.TOKCD) - Len(WLSTOKCD.Text))
        If (Len(DB_UDNTHA.TOKCD) - Len(WLSTOKCD.Text) >= 0) Then
            wkTOKCD = WLSTOKCD.Text & Space(Len(DB_UDNTHA.TOKCD) - Len(WLSTOKCD.Text))
        Else
            wkTOKCD = WLSTOKCD.Text
        End If
        'wkTANCD = WLSTANCD.Text & Space(Len(DB_UDNTHA.TANCD) - Len(WLSTANCD.Text))
        If (Len(DB_UDNTHA.TANCD) - Len(WLSTANCD.Text) >= 0) Then
            wkTANCD = WLSTANCD.Text & Space(Len(DB_UDNTHA.TANCD) - Len(WLSTANCD.Text))
        Else
            wkTANCD = WLSTANCD.Text
        End If
        '2019/06/11 CHG END
        'CHG START FKS)INABA 2009/02/27 ***************************************************
        '���������ύX�Ή�

        '    wkTANCD = WLSTANCD.Text & Space(Len(DB_UDNTHA.OPEID) - Len(WLSTANCD.Text))
        'CHG  END  FKS)INABA 2009/02/27 ***************************************************
        'CHG START FKS)INABA 2009/11/25 ***************************************************
        '�A���[��661
        '    If (Trim$(WLSTOKCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TOKCD = '" & wkTOKCD & "' "
        '    If (Trim$(WLSTANCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TANCD = '" & wkTANCD & "' "
        '    If (Trim$(WLSJDNTRKB.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNTRKB = '" & WLSJDNTRKB.Text & "' "
        '    If (Trim$(WLSUDNDT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.UDNDT >= '" & DeCNV_DATE(WLSUDNDT) & "' "
        '    If (Trim$(HD_TEXT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNNO >= '" & HD_TEXT & "' "
        If (Trim(WLSTOKCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TOKCD = '" & AE_EditSQLText(wkTOKCD) & "' "
        If (Trim(WLSTANCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TANCD = '" & AE_EditSQLText(wkTANCD) & "' "
        If (Trim(WLSJDNTRKB.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "' "
		If (Trim(WLSUDNDT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.UDNDT >= '" & DeCNV_DATE(WLSUDNDT.Text) & "' "
		If (Trim(HD_TEXT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNNO >= '" & AE_EditSQLText(HD_TEXT.Text) & "' "
		'CHG  END  FKS)INABA 2009/11/25 ***************************************************
		strSQL = "SELECT * FROM (    "
		'CHG START FKS)INABA 2009/02/27 ***************************************************
		'���X�|���X�Ή�
		strSQL = strSQL & "SELECT /*+ ORDERED */ A.* FROM ( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B, UDNTHA A "
		'    strSQL = strSQL & "SELECT A.* FROM UDNTHA A ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B"
		'CHG  END  FKS)INABA 2009/02/27 ***************************************************
		strSQL = strSQL & " WHERE A.DATKB = '1' "
		strSQL = strSQL & "   AND A.DENKB = '1' "
		strSQL = strSQL & "   AND A.AKAKROKB = '1' "
		strSQL = strSQL & "   AND A.WRTFSTDT || A.WRTFSTTM = B.DT "
		strSQL = strSQL & "   AND A.UDNNO = B.UDNNO "
		strSQL = strSQL & strSQLWhere
        'CHG START FKS)INABA 2009/11/25 ***************************************************
        '�A���[��661
        '    strSQL = strSQL & "   AND A.DATKB || A.DENKB || A.JDNNO || A.DATNO >= '" & strKeyBak & "' "

        '20190614 CHG START
        'strSQL = strSQL & "   AND A.DATKB || A.DENKB || A.JDNNO || A.DATNO >= '" & AE_EditSQLText(strKeyBak) & "' "
        strSQL = strSQL & "   AND A.JDNNO >= '" & AE_EditSQLText(strKeyBak) & "' "
        '20190614 CHG END

        'CHG  END  FKS)INABA 2009/11/25 ***************************************************
        strSQL = strSQL & "   Order By A.JDNNO ) C"


        '2019/06/10 CHG START
        'Call DB_GetSQL2(WM_WLS_MFIL, strSQL)
        Call DB_GetTable(strSQL)
        '2019/06/10 CHG END

    End Sub
End Class