VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form FR_SSSMAIN 
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "���������}�X�^�ꊇ�o�^"
   ClientHeight    =   4335
   ClientLeft      =   150
   ClientTop       =   720
   ClientWidth     =   8265
   Icon            =   "URKFP55.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4335
   ScaleWidth      =   8265
   StartUpPosition =   3  'Windows �̊���l
   Begin Threed5.SSPanel5 Gage 
      Height          =   495
      Left            =   840
      TabIndex        =   15
      Top             =   2520
      Width           =   6975
      _ExtentX        =   12303
      _ExtentY        =   873
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      AutoSize        =   3
      BevelOuter      =   1
      Caption         =   "SSPanel51"
      FloodType       =   1
   End
   Begin VB.CommandButton Cmd_cancel 
      Caption         =   "���~"
      Height          =   375
      Left            =   3240
      TabIndex        =   14
      Top             =   3240
      Width           =   1215
   End
   Begin VB.TextBox TX_CursorRest 
      Appearance      =   0  '�ׯ�
      BorderStyle     =   0  '�Ȃ�
      Height          =   330
      IMEMode         =   2  '��
      Left            =   36900
      TabIndex        =   12
      Top             =   36855
      Width           =   285
   End
   Begin VB.Timer TM_StartUp 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   36900
      Top             =   36855
   End
   Begin VB.Frame Frame3D1 
      Caption         =   "�����w��"
      ForeColor       =   &H00000000&
      Height          =   1080
      Left            =   285
      TabIndex        =   7
      Top             =   1215
      Width           =   7860
      Begin VB.TextBox HD_TFPATH_B 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   345
         IMEMode         =   2  '��
         Left            =   2280
         TabIndex        =   8
         TabStop         =   0   'False
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
         Top             =   360
         Width           =   5355
      End
      Begin Threed5.SSCommand5 CS_TFPATH_B 
         Height          =   345
         Left            =   150
         TabIndex        =   9
         TabStop         =   0   'False
         Top             =   360
         Width           =   2145
         _ExtentX        =   3784
         _ExtentY        =   609
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Caption         =   "�X�V�p�t�@�C����"
         BevelWidth      =   1
         RoundedCorners  =   0   'False
      End
   End
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   5145
      MaxLength       =   10
      TabIndex        =   1
      TabStop         =   0   'False
      Text            =   "XXXXX6"
      Top             =   645
      Width           =   795
   End
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   5925
      MaxLength       =   24
      TabIndex        =   0
      TabStop         =   0   'False
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   645
      Width           =   2205
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   1
      Left            =   -60
      TabIndex        =   2
      Top             =   0
      Width           =   8475
      _ExtentX        =   14949
      _ExtentY        =   979
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin Threed5.SSPanel5 SYSDT 
         Height          =   285
         Left            =   6705
         TabIndex        =   3
         Top             =   135
         Width           =   1410
         _ExtentX        =   2963
         _ExtentY        =   582
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "YYYY/MM/DD"
      End
      Begin VB.Image CM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   600
         Picture         =   "URKFP55.frx":030A
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   240
         Picture         =   "URKFP55.frx":0494
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  '�ׯ�
         Height          =   510
         Left            =   0
         Top             =   0
         Width           =   6195
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   645
      Index           =   3
      Left            =   -60
      TabIndex        =   4
      Top             =   3720
      Width           =   8475
      _ExtentX        =   17568
      _ExtentY        =   1296
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   4
         Left            =   585
         TabIndex        =   5
         Top             =   135
         Width           =   7560
         _ExtentX        =   13335
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Begin VB.TextBox TX_Message 
            Appearance      =   0  '�ׯ�
            BackColor       =   &H8000000F&
            BorderStyle     =   0  '�Ȃ�
            ForeColor       =   &H00000000&
            Height          =   240
            Left            =   90
            MultiLine       =   -1  'True
            TabIndex        =   6
            TabStop         =   0   'False
            Text            =   "URKFP55.frx":061E
            Top             =   90
            Width           =   5955
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "URKFP55.frx":0655
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   1410
      Index           =   0
      Left            =   45
      TabIndex        =   10
      Top             =   4440
      Width           =   8295
      _ExtentX        =   11933
      _ExtentY        =   2011
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFC0FF&
         Height          =   330
         Left            =   1575
         TabIndex        =   11
         Text            =   "Ӱ��"
         Top             =   630
         Width           =   735
      End
      Begin MSComDlg.CommonDialog CMDialogL 
         Left            =   45
         Top             =   630
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   540
         Picture         =   "URKFP55.frx":07DF
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "URKFP55.frx":0969
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2025
         Picture         =   "URKFP55.frx":0AF3
         Top             =   495
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   2
         Left            =   2430
         Picture         =   "URKFP55.frx":0C7D
         Top             =   495
         Width           =   300
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   1035
         Picture         =   "URKFP55.frx":0E07
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1425
         Picture         =   "URKFP55.frx":1479
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   2
      Left            =   3900
      TabIndex        =   13
      Top             =   645
      Width           =   1260
      _ExtentX        =   2223
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   " ���͒S����"
      OutLine         =   -1  'True
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "���� (&1)"
      Begin VB.Menu MN_EXECUTE 
         Caption         =   "���s(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "�I��(&X)"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "�ҏW (&2)"
      Begin VB.Menu MN_APPENDC 
         Caption         =   "��ʏ�����(&S)"
         Shortcut        =   ^S
      End
   End
End
Attribute VB_Name = "FR_SSSMAIN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim objim1(1) As New Toolbox
Dim pm_All As Cls_All
Dim bolStop_flg As Boolean
Const mc_lngRunMode_Web As Long = 2

Private Sub CM_EndCm_Click()
    MN_EndCm_Click
End Sub

Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Dim objp_msg As New P_Mes
    CF_Set_Prompt objp_msg.Dsp_Message_Prompt(gc_strMsgURKFP55_I_007), vbBlack, pm_All
    Set objp_msg = Nothing
End Sub

Private Sub CM_Execute_Click()
    MN_EXECUTE_Click
End Sub

Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Dim objp_msg As New P_Mes
    CF_Set_Prompt objp_msg.Dsp_Message_Prompt(gc_strMsgURKFP55_I_006), vbBlack, pm_All
    Set objp_msg = Nothing
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    Dim I As Integer
    If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_002, pm_All) = vbNo Then
        Cancel = 1
    Else
        CF_Ora_DisConnect gv_Oss_USR1, gv_Odb_USR1
        For I = 0 To UBound(objim1)
            Set objim1(I) = Nothing
        Next
    End If
End Sub


Private Sub HD_IN_TANCD_GotFocus()
    SendKeys "{Tab}"
End Sub

Private Sub HD_IN_TANNM_GotFocus()
    SendKeys "{Tab}"
End Sub

Private Sub HD_TFPATH_B_GotFocus()
    SendKeys "{Tab}"
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    CF_Clr_Prompt pm_All
End Sub

Private Sub CS_TFPATH_B_Click()
    On Error GoTo err_CS_TFPATH_B_Click
    With CMDialogL
        .CancelError = True
        .DefaultExt = gv_strOUT_TYPE
        .Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE & "|*.*|*.*"
        .ShowOpen
        HD_TFPATH_B.Text = .FileName
    End With
    Exit Sub
err_CS_TFPATH_B_Click:
    HD_TFPATH_B.Text = ""
End Sub

Private Sub Form_Load()
    Dim I As Integer
    Dim objctrl As Control
    Dim pot_Inp_Inf As Cmn_Inp_Inf
    Dim bolRet As Boolean
    Dim strMsgCd As String
    Dim bolTrans As Boolean
    Dim objgage As New Gage
    'DB�ڑ�
    Call CF_Ora_USR1_Open       'USR1
    
    '���ʏ���������
    Call CF_Init
    Set pm_All.Dsp_Base.FormCtl = Me
    Set pm_All.Dsp_IM_Denkyu = IM_Denkyu(0)
    Set pm_All.On_IM_Denkyu = IM_Denkyu(2)
    Set pm_All.Off_IM_Denkyu = IM_Denkyu(1)
    Set pm_All.Dsp_TX_Message = TX_Message
    TX_Message.Tag = 1
    ReDim pm_All.Dsp_Sub_Inf(1)
    Set pm_All.Dsp_Sub_Inf(1).Ctl = TX_Message
    '
    CF_Clr_Prompt pm_All
    objgage.setGage Gage, Cmd_cancel
    objgage.ShowGauge False
    Set objgage = Nothing
    HD_TFPATH_B.Text = vbNullString
    
'    '��ʏ��ݒ�
'    For Each objctrl In Me.Controls
'        ReDim Preserve objctrl1(I)
'        objctrl1(I).bind objctrl
'        I = I + 1
'    Next
    objim1(0).bind CM_EndCm, IM_EndCm(0), IM_EndCm(1)
    objim1(1).bind CM_Execute, IM_Execute(0), IM_Execute(1)
    gv_strTAB_CHAR = vbTab
    gv_strOUT_TYPE = ".TXT"
    '��ʓ��e������
    Me.ScaleTop = (Screen.Height - Me.ScaleHeight) / 2
    Me.ScaleLeft = (Screen.Width - Me.ScaleWidth) / 2
    Me.Top = (Screen.Height - Me.Height) / 2
    Me.Left = (Screen.Width - Me.Width) / 2
    SYSDT.Caption = Format(GV_UNYDate, "@@@@/@@/@@")
    HD_IN_TANCD.Text = Inp_Inf.InpTanCd
    HD_IN_TANNM.Text = Inp_Inf.InpTanNm
Exit Sub
Error_Handler:
    '���[���o�b�N
    If bolTrans Then
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If
    bolTrans = False



End Sub
'��ʏ����ݒ�
Private Sub MN_APPENDC_Click()
    HD_TFPATH_B.Text = vbNullString
End Sub
'��ʏI��
Private Sub MN_EndCm_Click()
    Unload Me
End Sub
'�f�[�^��荞�ݎ��s
Private Sub MN_EXECUTE_Click()
    Dim objfso As New FileSystemObject
    Dim objFile As File
    Dim strfile As String '�R�s�[��t�@�C����
    'PL/SQL�Ăяo���p
    Dim strSQL              As String
    Dim lngParam1           As Long
    Dim strParam2           As String * 2
    Dim strParam3           As String
    Dim strParam4           As String
    Dim strParam5           As String
    Dim strParam6           As String
    Dim strParam7           As String
    Dim strParam8           As String
    Dim strParam9           As String
    Dim strParam10          As String
    Dim lngParam11          As Long
    Dim strParam12          As String * 3000
    Dim param(13)           As OraParameter     'PL/SQL�̃o�C���h�ϐ�
    Dim bolRet              As Boolean
    Dim intret              As Integer
    Dim intCursor           As Integer
    Dim Err_Cd              As Long
    Dim strlogfile          As String           '���O�t�@�C����
    Dim strSVfolder           As String
    Dim strERR_CODE         As String
    Dim strLocalPath        As String           '�T�[�o���̃��[�J���p�X�ϐ�
    Dim strNYUKINKB     As String * 2
    On Error GoTo err_MN_EXECUTE_Click
    If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKFP55_I_001, pm_All) = vbNo Then
        AE_CmnMsgLibrary SSS_PrgNm, gc_strMsgURKFP55_I_004, pm_All
        Exit Sub
    End If
    '�t�@�C���̑��݉�
    If objfso.FileExists(HD_TFPATH_B.Text) Then
    Else
        '���݂��Ȃ��Ƃ��I������B
        AE_CmnMsgLibrary SSS_PrgNm, gc_strMsgURKFP55_I_008, pm_All
        Exit Sub
    End If
        '�X�V�������Ȃ��ꍇ�͏������s��Ȃ�
'    If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODFP51_E_NOUPDKNG, pm_All)
'        Exit Sub: Inp_Inf.InpFILEAUTH
'    End If
    '�J�[�\���ޔ�
    intCursor = Me.MousePointer
    Me.MousePointer = vbHourglass

    Set objFile = objfso.GetFile(HD_TFPATH_B.Text)
    Select Case F_Ctl_CopyFiles(objFile.NAME, strfile)
    Case 0
        '����
    Case 8
        'INI�t�@�C�����ǂݍ��߂Ȃ�
        AE_CmnMsgLibrary SSS_PrgNm, gc_strMsgURKFP55_E_022, pm_All
        Exit Sub
    Case 9
        '�R�s�[���ł��Ȃ�
        AE_CmnMsgLibrary SSS_PrgNm, gc_strMsgURKFP55_E_023, pm_All
        Exit Sub
    End Select
    '�T�[�o�̃��[�J���p�X���擾����B
    If Get_INIFile_String(App.Path & IIf(Right(App.Path, 1) = "\", "", "\") & SSS_PrgId & ".INI", "PATH", "ServerLocalLOG", strLocalPath) Then
    Else
        AE_CmnMsgLibrary SSS_PrgNm, gc_strMsgURKFP55_E_022, pm_All
        Exit Sub
    End If
    '=== 20110517 === INSERT S TOM)Morimoto
    '������ʂ��擾����B
    If Get_INIFile_String(App.Path & IIf(Right(App.Path, 1) = "\", "", "\") & SSS_PrgId & ".INI", "PROPERTY", "�������", strNYUKINKB) Then
    Else
        AE_CmnMsgLibrary SSS_PrgNm, gc_strMsgURKFP55_E_022, pm_All
        Exit Sub
    End If
    '=== 20110517 === INSERT E
    'PL/SQL�Ɉ�����n���B
    '�t�@�C���p�X
    '�t�@�C����
    '
        '���s�����̎擾
        Call CF_Get_SysDt
        
        '�^�p���t�̎擾
        Call CF_Get_UnyDt
        
        '�����ݒ�
        lngParam1 = mc_lngRunMode_Web
        strParam2 = strNYUKINKB
        strParam3 = strLocalPath
        strParam4 = objfso.GetFile(strfile).ParentFolder
        strParam5 = objfso.GetFileName(strfile)
        strParam6 = SSS_CLTID
        strParam7 = SSS_OPEID
        strParam8 = GV_SysDate
        strParam9 = GV_SysTime
        strParam10 = GV_UNYDate
        lngParam11 = 0
        strParam12 = ""
    'PL/SQL�����s����B
        '�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
        gv_Odb_USR1.Parameters.Add "P1", lngParam1, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P2", strParam2, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P3", strParam3, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P4", strParam4, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P5", strParam5, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P6", strParam6, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P7", strParam7, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P8", strParam8, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P9", strParam9, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P10", strParam10, ORAPARM_INPUT
        gv_Odb_USR1.Parameters.Add "P11", lngParam11, ORAPARM_OUTPUT
        gv_Odb_USR1.Parameters.Add "P12", strParam12, ORAPARM_OUTPUT
    
        '�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
        Set param(1) = gv_Odb_USR1.Parameters("P1")
        Set param(2) = gv_Odb_USR1.Parameters("P2")
        Set param(3) = gv_Odb_USR1.Parameters("P3")
        Set param(4) = gv_Odb_USR1.Parameters("P4")
        Set param(5) = gv_Odb_USR1.Parameters("P5")
        Set param(6) = gv_Odb_USR1.Parameters("P6")
        Set param(7) = gv_Odb_USR1.Parameters("P7")
        Set param(8) = gv_Odb_USR1.Parameters("P8")
        Set param(9) = gv_Odb_USR1.Parameters("P9")
        Set param(10) = gv_Odb_USR1.Parameters("P10")
        Set param(11) = gv_Odb_USR1.Parameters("P11")
        Set param(12) = gv_Odb_USR1.Parameters("P12")
    
        '�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
        param(1).serverType = ORATYPE_NUMBER
        param(2).serverType = ORATYPE_CHAR
        param(3).serverType = ORATYPE_VARCHAR2
        param(4).serverType = ORATYPE_VARCHAR2
        param(5).serverType = ORATYPE_VARCHAR2
        param(6).serverType = ORATYPE_VARCHAR2
        param(7).serverType = ORATYPE_VARCHAR2
        param(8).serverType = ORATYPE_CHAR
        param(9).serverType = ORATYPE_CHAR
        param(10).serverType = ORATYPE_CHAR
        param(11).serverType = ORATYPE_NUMBER
        param(12).serverType = ORATYPE_VARCHAR2
        'PL/SQL�Ăяo��SQL
        strSQL = "BEGIN " & SSS_PrgId & ".MAIN_SUB(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12); End;"
    
        'DB�A�N�Z�X
        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        If bolRet = False Then
            GoTo Ctl_MN_Execute_Click_END
        End If
    
        '�G���[���擾
        lngParam11 = param(11).Value
        If Not IsNull(param(12).Value) Then
            strParam12 = param(12).Value
        Else
            strParam12 = ""
        End If
        
        Err_Cd = lngParam11
        
        If InStr(strParam12, ":") <> 0 Then
            strlogfile = Trim(Mid(strParam12, InStr(strParam12, ":") + 1))
            strERR_CODE = Left(strParam12, InStr(strParam12, ":") - 1)
            '���O�t�@�C�����T�[�o����擾����B
            Select Case F_Ctl_CopyFiles2(strlogfile, objFile.ParentFolder)
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
            strERR_CODE = strParam12
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

Ctl_MN_Execute_Click_END:
        '** �p�����^����
        gv_Odb_USR1.Parameters.Remove "P1"
        gv_Odb_USR1.Parameters.Remove "P2"
        gv_Odb_USR1.Parameters.Remove "P3"
        gv_Odb_USR1.Parameters.Remove "P4"
        gv_Odb_USR1.Parameters.Remove "P5"
        gv_Odb_USR1.Parameters.Remove "P6"
        gv_Odb_USR1.Parameters.Remove "P7"
        gv_Odb_USR1.Parameters.Remove "P8"
        gv_Odb_USR1.Parameters.Remove "P9"
        gv_Odb_USR1.Parameters.Remove "P10"
        gv_Odb_USR1.Parameters.Remove "P11"
        gv_Odb_USR1.Parameters.Remove "P12"
        
        '�捞�t�@�C���̍폜
        Call F_Ctl_DeleteFiles(strfile)
        
Ctl_MN_Execute_Click_END2:

        '�J�[�\���߂�
        Me.MousePointer = intCursor
    
    Exit Sub
err_MN_EXECUTE_Click:
    'PL/SQL�G���[
    AE_CmnMsgLibrary SSS_PrgNm, gc_strMsgURKFP55_E_019, pm_All 'DB�G���[������܂����B
    '�捞�t�@�C���̍폜
    Call F_Ctl_DeleteFiles(strfile)
    '�J�[�\���߂�
    Me.MousePointer = intCursor
End Sub

Private Sub TX_Message_GotFocus()
    SendKeys "{Tab}"
End Sub
