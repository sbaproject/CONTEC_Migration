Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
'2019/10/14 ADD START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'2019/10/14 ADD END
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
    'UPGRADE_WARNING: �z��� New �Ő錾���邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC9D3AE5-6B95-4B43-91C7-28276302A5E8"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: Toolbox �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '2019/10/14 DEL START
    'Dim objim1(1) As New Toolbox
    '2019/10/14 DEL END
    'UPGRADE_WARNING: �\���� pm_All �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    Dim pm_All As Cls_All
	Dim bolStop_flg As Boolean
	Const mc_lngRunMode_Web As Integer = 2
	
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
		MN_EndCm_Click(MN_EndCm, New System.EventArgs())
	End Sub
	
	Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        '2019/10/14 DEL START
        '      'UPGRADE_ISSUE: P_Mes �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '      Dim objp_msg As New P_Mes
        ''UPGRADE_WARNING: �I�u�W�F�N�g objp_msg.Dsp_Message_Prompt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgURKFP55_I_007), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), pm_All)
        '      'UPGRADE_NOTE: �I�u�W�F�N�g objp_msg ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        '      objp_msg = Nothing
        '2019/10/14 DEL END
    End Sub
	
	Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
		MN_EXECUTE_Click(MN_EXECUTE, New System.EventArgs())
	End Sub
	
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        '2019/10/14 DEL START
        '      'UPGRADE_ISSUE: P_Mes �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '      Dim objp_msg As New P_Mes
        ''UPGRADE_WARNING: �I�u�W�F�N�g objp_msg.Dsp_Message_Prompt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'CF_Set_Prompt(objp_msg.Dsp_Message_Prompt(gc_strMsgURKFP55_I_006), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), pm_All)
        '      'UPGRADE_NOTE: �I�u�W�F�N�g objp_msg ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        '      objp_msg = Nothing
        '2019/10/14 DEL END
    End Sub
	
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		Dim I As Short
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_002, pm_All) = MsgBoxResult.No Then
            Cancel = 1
        Else
            '2019/10/14 DEL START
            'CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
            'For I = 0 To UBound(objim1)
            '    'UPGRADE_NOTE: �I�u�W�F�N�g objim1() ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
            '    objim1(I) = Nothing
            'Next
            '2019/10/14 DEL END
        End If
		eventArgs.Cancel = Cancel
	End Sub
	
	
	Private Sub HD_IN_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Enter
		System.Windows.Forms.SendKeys.Send("{Tab}")
	End Sub
	
	Private Sub HD_IN_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Enter
		System.Windows.Forms.SendKeys.Send("{Tab}")
	End Sub
	
	Private Sub HD_TFPATH_B_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TFPATH_B.Enter
		System.Windows.Forms.SendKeys.Send("{Tab}")
	End Sub
	
	Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		CF_Clr_Prompt(pm_All)
	End Sub
	
	Private Sub CS_TFPATH_B_Click()
		On Error GoTo err_CS_TFPATH_B_Click
		With CMDialogL
            'UPGRADE_WARNING: �I�u�W�F�N�g CMDialogL.CancelError �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/14 DEL START
            '.CancelError = True
            '2019/10/14 DEL END
            'UPGRADE_WARNING: �I�u�W�F�N�g CMDialogL.DefaultExt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .DefaultExt = gv_strOUT_TYPE
			'UPGRADE_WARNING: �I�u�W�F�N�g CMDialogL.Filter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE & "|*.*|*.*"
            'UPGRADE_WARNING: �I�u�W�F�N�g CMDialogL.ShowOpen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/14 CHG START
            '.ShowOpen()
            .ShowDialog()
            '2019/10/14 CHG END
            'UPGRADE_WARNING: �I�u�W�F�N�g CMDialogL.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            HD_TFPATH_B.Text = .FileName
		End With
		Exit Sub
err_CS_TFPATH_B_Click: 
		HD_TFPATH_B.Text = ""
	End Sub
	
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim I As Short
		Dim objctrl As System.Windows.Forms.Control
		Dim pot_Inp_Inf As Cmn_Inp_Inf
		Dim bolRet As Boolean
		Dim strMsgCd As String
		Dim bolTrans As Boolean
        'UPGRADE_ISSUE: Gage �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/10/14 DEL START
        'Dim objgage As New Gage
        '2019/10/14 DEL END
        'DB�ڑ�
        Call CF_Ora_USR1_Open() 'USR1
		
		'���ʏ���������
		Call CF_Init()
		pm_All.Dsp_Base.FormCtl = Me
        '2019/10/14 DEL START
        '      pm_All.Dsp_IM_Denkyu = IM_Denkyu(0)
        '      pm_All.On_IM_Denkyu = IM_Denkyu(2)
        'pm_All.Off_IM_Denkyu = IM_Denkyu(1)
        'pm_All.Dsp_TX_Message = TX_Message
        'TX_Message.Tag = 1
        'ReDim pm_All.Dsp_Sub_Inf(1)
        'pm_All.Dsp_Sub_Inf(1).Ctl = TX_Message
        ''
        'CF_Clr_Prompt(pm_All)
        ''UPGRADE_WARNING: �I�u�W�F�N�g objgage.setGage �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'objgage.setGage(Gage, Cmd_cancel)
        ''UPGRADE_WARNING: �I�u�W�F�N�g objgage.ShowGauge �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'objgage.ShowGauge(False)
        ''UPGRADE_NOTE: �I�u�W�F�N�g objgage ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        'objgage = Nothing
        '2019/10/14 DEL END
        HD_TFPATH_B.Text = vbNullString

        '    '��ʏ��ݒ�
        '    For Each objctrl In Me.Controls
        '        ReDim Preserve objctrl1(I)
        '        objctrl1(I).bind objctrl
        '        I = I + 1
        '    Next
        'UPGRADE_WARNING: �I�u�W�F�N�g objim1().bind �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/14 DEL START
        'objim1(0).bind(CM_EndCm, IM_EndCm(0), IM_EndCm(1))
        ''UPGRADE_WARNING: �I�u�W�F�N�g objim1().bind �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'objim1(1).bind(CM_Execute, IM_Execute(0), IM_Execute(1))
        '2019/10/14 DEL END
        gv_strTAB_CHAR = vbTab
		gv_strOUT_TYPE = ".TXT"
        '��ʓ��e������
        'UPGRADE_ISSUE: Form �v���p�e�B FR_SSSMAIN.ScaleTop �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
        '2019/10/14 DEL START
        'Me.ScaleTop = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.ClientRectangle.Height)) / 2
        ''UPGRADE_ISSUE: Form �v���p�e�B FR_SSSMAIN.ScaleLeft �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
        'Me.ScaleLeft = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.ClientRectangle.Width)) / 2
        '2019/10/14 DEL END
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/14 CHG START
        'SYSDT.Caption = VB6.Format(GV_UNYDate, "@@@@/@@/@@")
        SYSDT.Text = VB6.Format(GV_UNYDate, "@@@@/@@/@@")
        '2019/10/14 CHG END
        HD_IN_TANCD.Text = Inp_Inf.InpTanCd
        HD_IN_TANNM.Text = Inp_Inf.InpTanNm

        '2019/10/14 ADD START
        SetBar(Me)
        '2019/10/14 ADD END

        Exit Sub
Error_Handler:
        '���[���o�b�N
        If bolTrans Then
            '2019/10/14 DEL START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            '2019/10/14 DEL END
        End If
        bolTrans = False
		
		
		
	End Sub
	'��ʏ����ݒ�
	Public Sub MN_APPENDC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_APPENDC.Click
		HD_TFPATH_B.Text = vbNullString
	End Sub
	'��ʏI��
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
		Me.Close()
	End Sub
	'�f�[�^��荞�ݎ��s
	Public Sub MN_EXECUTE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EXECUTE.Click
		Dim objfso As New Scripting.FileSystemObject
		Dim objFile As Scripting.File
		Dim strfile As String '�R�s�[��t�@�C����
		'PL/SQL�Ăяo���p
		Dim strSQL As String
		Dim lngParam1 As Integer
		Dim strParam2 As New VB6.FixedLengthString(2)
		Dim strParam3 As String
		Dim strParam4 As String
		Dim strParam5 As String
		Dim strParam6 As String
		Dim strParam7 As String
		Dim strParam8 As String
		Dim strParam9 As String
		Dim strParam10 As String
		Dim lngParam11 As Integer
		Dim strParam12 As New VB6.FixedLengthString(3000)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(13) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
        Dim intret As Short
        '2019/10/14 CHG START
        'Dim intCursor As Short
        Dim intCursor As Cursor
        '2019/10/14 CHG END
        Dim Err_Cd As Integer
		Dim strlogfile As String '���O�t�@�C����
		Dim strSVfolder As String
		Dim strERR_CODE As String
		Dim strLocalPath As String '�T�[�o���̃��[�J���p�X�ϐ�
		Dim strNYUKINKB As New VB6.FixedLengthString(2)

        '2019/10/14 DEL START
        'On Error GoTo err_MN_EXECUTE_Click
        '2019/10/14 DEL END

        '2019/10/14 ADD START
        Try
            '2019/10/14 ADD END

            If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_001, pm_All) = MsgBoxResult.No Then
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_004, pm_All)
                Exit Sub
            End If
            '�t�@�C���̑��݉�
            If objfso.FileExists(HD_TFPATH_B.Text) Then
            Else
                '���݂��Ȃ��Ƃ��I������B
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_008, pm_All)
                Exit Sub
            End If
            '�X�V�������Ȃ��ꍇ�͏������s��Ȃ�
            '    If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
            '        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODFP51_E_NOUPDKNG, pm_All)
            '        Exit Sub: Inp_Inf.InpFILEAUTH
            '    End If
            '�J�[�\���ޔ�
            intCursor = Me.Cursor
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            objFile = objfso.GetFile(HD_TFPATH_B.Text)
            Select Case F_Ctl_CopyFiles(objFile.NAME, strfile)
                Case 0
                '����
                Case 8
                    'INI�t�@�C�����ǂݍ��߂Ȃ�
                    AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_022, pm_All)
                    Exit Sub
                Case 9
                    '�R�s�[���ł��Ȃ�
                    AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_023, pm_All)
                    Exit Sub
            End Select
            '�T�[�o�̃��[�J���p�X���擾����B
            If Get_INIFile_String(My.Application.Info.DirectoryPath & IIf(VB.Right(My.Application.Info.DirectoryPath, 1) = "\", "", "\") & SSS_PrgId & ".INI", "PATH", "ServerLocalLOG", strLocalPath) Then
            Else
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_022, pm_All)
                Exit Sub
            End If
            '=== 20110517 === INSERT S TOM)Morimoto
            '������ʂ��擾����B
            If Get_INIFile_String(My.Application.Info.DirectoryPath & IIf(VB.Right(My.Application.Info.DirectoryPath, 1) = "\", "", "\") & SSS_PrgId & ".INI", "PROPERTY", "�������", strNYUKINKB.Value) Then
            Else
                AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_022, pm_All)
                Exit Sub
            End If
            '=== 20110517 === INSERT E
            'PL/SQL�Ɉ�����n���B
            '�t�@�C���p�X
            '�t�@�C����
            '
            '���s�����̎擾
            Call CF_Get_SysDt()

            '�^�p���t�̎擾
            Call CF_Get_UnyDt()

            '�����ݒ�
            lngParam1 = mc_lngRunMode_Web
            strParam2.Value = strNYUKINKB.Value
            strParam3 = strLocalPath
            strParam4 = objfso.GetFile(strfile).ParentFolder.Path
            strParam5 = objfso.GetFileName(strfile)
            strParam6 = SSS_CLTID.Value
            strParam7 = SSS_OPEID.Value
            strParam8 = GV_SysDate
            strParam9 = GV_SysTime
            strParam10 = GV_UNYDate
            lngParam11 = 0
            strParam12.Value = ""

            '2019/10/14 ADD START

            Dim cmd As New OracleCommand

            cmd.Connection = CON

            cmd.CommandType = CommandType.StoredProcedure

            '2019/10/14 ADD END

            '2019/10/14 CHG START

            '      'PL/SQL�����s����B
            '      '�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
            '      'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '      gv_Odb_USR1.Parameters.Add("P1", lngParam1, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P2", strParam2.Value, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P3", strParam3, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P4", strParam4, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P5", strParam5, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P6", strParam6, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P7", strParam7, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P8", strParam8, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P9", strParam9, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P10", strParam10, ORAPARM_INPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P11", lngParam11, ORAPARM_OUTPUT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'gv_Odb_USR1.Parameters.Add("P12", strParam12.Value, ORAPARM_OUTPUT)

            ''�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(1) = gv_Odb_USR1.Parameters("P1")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(2) = gv_Odb_USR1.Parameters("P2")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(3) = gv_Odb_USR1.Parameters("P3")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(4) = gv_Odb_USR1.Parameters("P4")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(5) = gv_Odb_USR1.Parameters("P5")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(6) = gv_Odb_USR1.Parameters("P6")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(7) = gv_Odb_USR1.Parameters("P7")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(8) = gv_Odb_USR1.Parameters("P8")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(9) = gv_Odb_USR1.Parameters("P9")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(10) = gv_Odb_USR1.Parameters("P10")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(11) = gv_Odb_USR1.Parameters("P11")
            ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(12) = gv_Odb_USR1.Parameters("P12")

            ''�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(1).serverType = ORATYPE_NUMBER
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(2).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(3).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(4).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(5).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(6).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(7).serverType = ORATYPE_VARCHAR2
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(8).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(9).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(10).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(11).serverType = ORATYPE_NUMBER
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'param(12).serverType = ORATYPE_VARCHAR2
            '      'PL/SQL�Ăяo��SQL
            '      strSQL = "BEGIN " & SSS_PrgId & ".MAIN_SUB(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12); End;"


            Dim inP1 As OracleParameter = New OracleParameter
            inP1.ParameterName = "P1"
            inP1.Direction = ParameterDirection.Input
            inP1.Value = lngParam1
            cmd.Parameters.Add(inP1)

            Dim inP2 As OracleParameter = New OracleParameter
            inP2.ParameterName = "P2"
            inP2.Direction = ParameterDirection.Input
            inP2.Value = strParam2.Value
            cmd.Parameters.Add(inP2)

            Dim inP3 As OracleParameter = New OracleParameter
            inP3.ParameterName = "P3"
            inP3.Direction = ParameterDirection.Input
            inP3.Value = strParam3
            cmd.Parameters.Add(inP3)

            Dim inP4 As OracleParameter = New OracleParameter
            inP4.ParameterName = "P4"
            inP4.Direction = ParameterDirection.Input
            inP4.Value = strParam4
            cmd.Parameters.Add(inP4)

            Dim inP5 As OracleParameter = New OracleParameter
            inP5.ParameterName = "P5"
            inP5.Direction = ParameterDirection.Input
            inP5.Value = strParam5
            cmd.Parameters.Add(inP5)

            Dim inP6 As OracleParameter = New OracleParameter
            inP6.ParameterName = "P6"
            inP6.Direction = ParameterDirection.Input
            inP6.Value = strParam6
            cmd.Parameters.Add(inP6)

            Dim inP7 As OracleParameter = New OracleParameter
            inP7.ParameterName = "P7"
            inP7.Direction = ParameterDirection.Input
            inP7.Value = strParam7
            cmd.Parameters.Add(inP7)

            Dim inP8 As OracleParameter = New OracleParameter
            inP8.ParameterName = "P8"
            inP8.Direction = ParameterDirection.Input
            inP8.Value = strParam8
            cmd.Parameters.Add(inP8)

            Dim inP9 As OracleParameter = New OracleParameter
            inP9.ParameterName = "P9"
            inP9.Direction = ParameterDirection.Input
            inP9.Value = strParam9
            cmd.Parameters.Add(inP9)

            Dim inP10 As OracleParameter = New OracleParameter
            inP10.ParameterName = "P10"
            inP10.Direction = ParameterDirection.Input
            inP10.Value = strParam10
            cmd.Parameters.Add(inP10)

            Dim outP11 As OracleParameter = New OracleParameter
            outP11.ParameterName = "P11"
            outP11.Direction = ParameterDirection.Output
            outP11.Value = lngParam11
            cmd.Parameters.Add(outP11)

            Dim outP12 As OracleParameter = New OracleParameter
            outP12.ParameterName = "P12"
            outP12.Direction = ParameterDirection.Output
            outP12.Value = strParam12.Value
            cmd.Parameters.Add(outP12)

            inP1.OracleDbType = OracleDbType.Decimal
            inP2.OracleDbType = OracleDbType.Char
            inP3.OracleDbType = OracleDbType.Varchar2
            inP4.OracleDbType = OracleDbType.Varchar2
            inP5.OracleDbType = OracleDbType.Varchar2
            inP6.OracleDbType = OracleDbType.Varchar2
            inP7.OracleDbType = OracleDbType.Varchar2
            inP8.OracleDbType = OracleDbType.Char
            inP9.OracleDbType = OracleDbType.Char
            inP10.OracleDbType = OracleDbType.Char
            outP11.OracleDbType = OracleDbType.Decimal
            outP12.OracleDbType = OracleDbType.Varchar2

            cmd.CommandText = SSS_PrgId & ".MAIN_SUB"

            '2019/10/14 CHG END


            '2019/10/14 CHG START
            'DB�A�N�Z�X
            'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            'If bolRet = False Then
            '    GoTo Ctl_MN_Execute_Click_END
            'End If
            cmd.ExecuteNonQuery()
            '2019/10/14 CHG END

            '2019/10/14 CHG START
            '�G���[���擾
            'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'lngParam11 = param(11).Value
            ''UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'If Not IsDbNull(param(12).Value) Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    strParam12.Value = param(12).Value
            'Else
            '    strParam12.Value = ""
            'End If

            lngParam11 = outP11.Value.ToString()

            If Not IsDBNull(outP12.Value.ToString()) Then
                strParam12.Value = outP12.Value.ToString()
            Else
                strParam12.Value = ""
            End If

            '2019/10/14 CHG END

            Err_Cd = lngParam11

            If InStr(strParam12.Value, ":") <> 0 Then
                strlogfile = Trim(Mid(strParam12.Value, InStr(strParam12.Value, ":") + 1))
                strERR_CODE = VB.Left(strParam12.Value, InStr(strParam12.Value, ":") - 1)
                '���O�t�@�C�����T�[�o����擾����B
                Select Case F_Ctl_CopyFiles2(strlogfile, objFile.ParentFolder.Path)
                    Case 0
                        '����
                        '���O�t�@�C���̍폜
                        Call F_Ctl_DeleteFiles(strlogfile)
                        If lngParam11 = 0 Then
                            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_003, pm_All)
                        Else
                            If InStr(strERR_CODE, SSS_PrgId) <> 0 Then
                                Call AE_CmnMsgLibrary(SSS_PrgNm, strERR_CODE, pm_All)
                            Else
                                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_009, pm_All)
                            End If
                        End If
                    Case 8
                        'INI�t�@�C���擾�~�X
                        strERR_CODE = gc_strMsgURKFP55_E_022
                    Case 9
                        '�R�s�[���ł��Ȃ��B
                        strERR_CODE = gc_strMsgURKFP55_E_023
                End Select
            Else
                strERR_CODE = strParam12.Value
                If lngParam11 = 0 Then
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_003, pm_All)
                Else
                    If InStr(strERR_CODE, SSS_PrgId) <> 0 Then
                        Call AE_CmnMsgLibrary(SSS_PrgNm, strERR_CODE, pm_All)
                    Else
                        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_009, pm_All)
                    End If
                End If
            End If

            '2019/10/14 CHG START

            'Ctl_MN_Execute_Click_END: 
            '		'** �p�����^����
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P1")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P2")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P3")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P4")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P5")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P6")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P7")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P8")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P9")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P10")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P11")
            '		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		gv_Odb_USR1.Parameters.Remove("P12")

            cmd.Parameters.Clear()

            '2019/10/14 CHG END

            '�捞�t�@�C���̍폜
            Call F_Ctl_DeleteFiles(strfile)

            '2019/10/14 CHG START

            'Ctl_MN_Execute_Click_END2: 

            '		'�J�[�\���߂�
            '		'UPGRADE_ISSUE: Form �v���p�e�B FR_SSSMAIN.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
            '		Me.Cursor = intCursor

            '		Exit Sub
            'err_MN_EXECUTE_Click: 
            '		'PL/SQL�G���[
            '		AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_019, pm_All) 'DB�G���[������܂����B
            '		'�捞�t�@�C���̍폜
            '		Call F_Ctl_DeleteFiles(strfile)
            '		'�J�[�\���߂�
            '		'UPGRADE_ISSUE: Form �v���p�e�B FR_SSSMAIN.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
            '		Me.Cursor = intCursor

            Me.Cursor = intCursor

        Catch ex As Exception

            AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_E_019, pm_All) 'DB�G���[������܂����B

            Call F_Ctl_DeleteFiles(strfile)

            '�J�[�\���߂�
            Me.Cursor = intCursor
        End Try

        '2019/10/14 CHG END
    End Sub
	
	Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
		System.Windows.Forms.SendKeys.Send("{Tab}")
	End Sub

    '2019/10/14 ADD START
    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        MN_EXECUTE_Click(MN_EXECUTE, New System.EventArgs())
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Call MN_APPENDC_Click(MN_EndCm, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Call MN_EndCm_Click(MN_EndCm, New System.EventArgs())
    End Sub

    Private Sub FR_SSSMAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    '�X�V
                    Me.btnF1.PerformClick()

                Case Keys.F9
                    '�N���A
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    '�I��
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub

    Private Sub CS_TFPATH_B_Click(sender As Object, e As EventArgs) Handles CS_TFPATH_B.Click
        Call CS_TFPATH_B_Click()
    End Sub

    Private Sub Cmd_cancel_Click(sender As Object, e As EventArgs) Handles Cmd_cancel.Click

    End Sub

    '2019/10/14 ADD END
End Class