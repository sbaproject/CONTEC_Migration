Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module AE_CMN
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@����
	'*  ���W���[�����@�@�F�@�Ɩ����ʏ���
	'*  �쐬�ҁ@�@�@�@�@�F�@ACE)���V
	'*  �쐬���@�@�@�@�@�F  2006.05.24
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'************************************************************************************
	'   �\����
	'************************************************************************************
	Public Structure Cmn_Inp_Inf
		Dim InpTanCd As String '���͒S���҂h�c
		Dim InpTanNm As String '���͒S���Җ�
		Dim InpTKCHGKB As String '�P���ύX����
		Dim InpCLIID As String '�N���C�A���g�h�c
		' === 20060828 === INSERT S - ACE)Sejima
		Dim InpJDNUPDKB As String '�󒍍X�V����
		' === 20060828 === INSERT E
		' === 20061030 === INSERT S - ACE)Nagasawa �����̓ǂݕ��̕ύX
		Dim InpPRTAUTH As String '�������
		Dim InpFILEAUTH As String '�t�@�C���o�͌���
		' === 20061030 === INSERT E -
	End Structure
	
	' === 20061014 === INSERT S - ACE)Nagasawa �󒍒������̍��ڂ̓��͉ې���̕ύX
	Public Structure Cmn_JDNUPDATE_Enable
		Dim bolJHD As Boolean '�Z�b�g�A�b�v����
		Dim bolFRD As Boolean '�o�׎w��
		' === 20061123 === INSERT S - ACE)Nagasawa ���[�J�[�R�[�h�ɂ͏o�׎w�}����ҏW
		Dim bolSSZ As Boolean '�o�׎w�}
		' === 20061123 === INSERT E -
		Dim bolODN As Boolean '�o�׎���
		' === 20061127 === INSERT S - ACE)Nagasawa �C�O�q�ɂ���̏o�׎��эl���ǉ�
		Dim bolFRNMOV As Boolean '�C�O�q�Ɉړ�
		' === 20061127 === INSERT E -
		Dim bolURI As Boolean '����
		Dim bolSSA As Boolean '����
		Dim bolNYU As Boolean '����
		Dim bolJDN_End As Boolean '�󒍊���
	End Structure
	' === 20061014 === INSERT E -
	
	' === 20061217 === INSERT S - ACE)Nagasawa ��������t�@�C���̍X�V���s��
	'��������t�@�C���X�V���
	Public Structure Cmn_DTLTRA_Upd
		Dim Moto_TRANO As String '�X�V�O�g�����ԍ�
		Dim MOTO_MITNOV As String '�X�V�O�Ő�
		Dim Moto_LINNO As String '�X�V�O�s�ԍ�
		Dim TRANO As String '�g�����ԍ�
		Dim MITNOV As String '�Ő�
		Dim LINNO As String '�s�ԍ�
		Dim TRADT As String '�o�ח\���
	End Structure
	' === 20061217 === INSERT E -
	'************************************************************************************
	'   Public�萔
	'************************************************************************************
	'�[���v�Z����
	Public Const gc_strRPSKB_D1 As String = "1" '��������
	Public Const gc_strRPSKB_D2 As String = "2" '��������
	Public Const gc_strRPSKB_D3 As String = "3" '������O��
	Public Const gc_strRPSKB_D4 As String = "4" '������l��
	Public Const gc_strRPSKB_D5 As String = "5" '������܈�
	Public Const gc_strRPSKB_I1 As String = "10" '�P
	Public Const gc_strRPSKB_I2 As String = "11" '�P�O
	Public Const gc_strRPSKB_I3 As String = "12" '�P�O�O
	'************************************************************************************
	'   Public�ϐ�
	'************************************************************************************
	Public Inp_Inf As Cmn_Inp_Inf '���͎ҏ��
	Public GV_SysDate As String '�c�a�T�[�o�[���t
	Public GV_SysTime As String '�c�a�T�[�o�[����
	Public GV_UNYDate As String '�^�p���t
	' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
	Public GV_bolMsgFlg As Boolean '���b�Z�[�W�o�̓t���O
	' === 20060920 === INSERT E
	
	'************************************************************************************
	'   Private�萔
	'************************************************************************************
	' === 20060828 === INSERT S - ACE)Sejima
	'�����O���[�v����p
	Private Const mc_intCD As Short = 1 '�����O���[�v�ݒ肠��
	Private Const mc_intOLDCD As Short = 2 '�������O���[�v�ݒ肠��
	Private Const mc_intTKDT As Short = 4 '�K�p���ݒ肠��
	' === 20060828 === INSERT E
	'************************************************************************************
	'   Private�ϐ�
	'************************************************************************************
	Dim strINIDATNM(4) As String '�h�m�h�̃V���{��
	
	' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
	'************************************************************************************
	'   �L�[�o�b�t�@�N���A�pAPI
	'************************************************************************************
	Private Structure POINTAPI
		Dim X As Integer
		Dim Y As Integer
	End Structure
	Private Structure Msg
		Dim hwnd As Integer
		Dim message As Integer
		Dim wParam As Integer
		Dim lParam As Integer
		Dim time As Integer
		Dim pt As POINTAPI
	End Structure
	'UPGRADE_WARNING: �\���� Msg �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Private Declare Function PeekMessage Lib "user32"  Alias "PeekMessageA"(ByRef lpMsg As Msg, ByVal hwnd As Integer, ByVal wMsgFilterMin As Integer, ByVal wMsgFilterMax As Integer, ByVal wRemoveMsg As Integer) As Integer
	Private Const WM_KEYFIRST As Short = &H100s
	Private Const WM_KEYLAST As Short = &H108s
	Private Const PM_REMOVE As Short = &H1s
	' === 20060920 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Init
	'   �T�v�F  �v���O�����N������������
	'   �����F  �Ȃ�
	'   �ߒl�F  �Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub CF_Init()
		
		Dim datDT As Date
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim DB_UNYMTA As TYPE_DB_UNYMTA
		Dim strYMD As String
		Dim intLenCommand As String
		Dim intRet As Short
		'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
		Dim strRet As String
		'''' ADD 2009/11/26  FKS) T.Yamamoto    End
		
		'��d�N������
		'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
		If App.PrevInstance Then
			MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		End If
		
		' "���΂炭���҂���������" �E�B���h�E�\��
		'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
		Load(ICN_ICON)
		
		'   ���t�`���`�F�b�N
		datDT = Today
		strYMD = VB6.Format(Year(datDT), "0000") & "/" & VB6.Format(Month(datDT), "00") & "/" & VB6.Format(VB.Day(datDT), "00")
		
		If CStr(datDT) <> strYMD Then
			MsgBox("���t�̌`�� '" & CStr(datDT) & "' ���Ⴂ�܂��B" & vbCrLf & "�R���g���[���p�l���̒n��i�n���̊G�j�̓��t" & vbCrLf & "�̒Z���`���� yyyy/MM/dd �ɕύX���ĉ������B", MsgBoxStyle.Critical)
			Call Error_Exit("���t�̌`�����Ⴂ�܂��B")
		End If
		
		'---------------------
		' �N���p�����[�^�ݒ�
		'---------------------
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intLenCommand = LenWid(Trim(VB.Command()))
		If CDbl(intLenCommand) < 15 Then
			MsgBox("���j���[������s���Ă��������B", MsgBoxStyle.OKOnly, SSS_PrgNm)
			Call Error_Exit("���j���[������s���Ă��������B")
		End If
		
		SSS_CLTID.Value = MidWid(VB.Command(), 2, 5)
		SSS_OPEID.Value = MidWid(VB.Command(), 7, 8)
		
		'���[�h�I�����[���[�h�ݒ�
		If Left(VB.Command(), 1) = "'" Then SSS_ReadOnly = True
		
		' === 20060828 === INSERT S - ACE)Sejima �P���ύX�����擾�ɕK�v�Ȃ��߁A������ړ�
		'�^�p���t�擾
		Call CF_Get_UnyDt()
		' === 20060828 === INSERT E
		
		'���͒S���Җ��擾
		Inp_Inf.InpTanCd = SSS_OPEID.Value
		Inp_Inf.InpCLIID = SSS_CLTID.Value
		
		'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
		'���͒S���ҏ��ݒ�
		gs_userid = SSS_OPEID.Value
		gs_pgid = SSS_PrgId
		
		'�����擾
		strRet = Get_Authority(GV_UNYDate)
		If strRet = "9" Then
			'�N�������Ȃ��̏ꍇ�A�����I��
			Call AE_CmnMsgLibrary_2(SSS_PrgNm, "2RUNAUTH")
			End
		End If
		'''' ADD 2009/11/26  FKS) T.Yamamoto    End
		
		' === 20060830 === UPDATE S - ACE)Nagasawa �����̍l���̏C��
		'    Call DB_TANMTA_Clear(DB_TANMTA)
		'    intRet = DSPTANCD_SEARCH(Inp_Inf.InpTanCd, DB_TANMTA)
		'    If intRet = 0 Then
		'        Inp_Inf.InpTanNm = DB_TANMTA.TANNM              '���͒S���Җ�
		'' === 20060828 === UPDATE S - ACE)Sejima
		''D        Inp_Inf.InpTKCHGKB = DB_TANMTA.TKCHGKB          '�P���ύX����
		'' === 20060828 === UPDATE ��
		'        '�������擾�i�P���ύX�����A�󒍍X�V�����Aetc...�j
		'        Call F_Get_KNG_Inf(DB_TANMTA, GV_UNYDate, Inp_Inf)
		'' === 20060828 === UPDATE E
		'    End If
		
		'���͒S���ҏ��擾
		Call F_Get_INPTANCD_Inf(Inp_Inf.InpTanCd, Inp_Inf)
		' === 20060830 === UPDATE E -
		
		'---------------------
		' SSSWIN.INI �e�[�u���ݒ�
		'---------------------
		strINIDATNM(0) = "USR_PATH"
		strINIDATNM(1) = "DAT_PATH"
		strINIDATNM(2) = "PRG_PATH"
		strINIDATNM(3) = "WRK_PATH"
		strINIDATNM(4) = "IMG_PATH"
		SSS_INICnt = 4
		'Ini�t�@�C���Ǎ���
		Call CF_INIT_GETINI()
		
		' === 20060828 === DELETE S - ACE)Sejima �P���ύX�����擾�ɕK�v�Ȃ��߁A��Ɉړ�
		'D    '�^�p���t�擾
		'D    Call CF_Get_UnyDt
		' === 20060828 === DELETE E
		
		' === 20061102 === INSERT S - ACE)Yano ۸�̧�ُ����݁i�v���O�����N���j
		Call SSSWIN_LOGWRT("�v���O�����N��")
		' === 20061102 === INSERT E
		
		' "���΂炭���҂���������" �E�B���h�E����
		ICN_ICON.Close()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_INIT_GETINI
	'   �T�v�F  INI�t�@�C���Ǎ��݁i���ʁj
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub CF_INIT_GETINI()
		Dim WL_WinDir As String
		Dim I, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		'---------------------
		' SSSWIN.INI �Ǎ���
		'---------------------
		For I = 0 To SSS_INICnt
			rtnPara.Value = ""
			LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(I), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
			If LENGTH = 0 Then
				MsgBox("SSSWIN.INI ���m�F���Ă��������B" & Chr(13) & "[" & strINIDATNM(I) & "]")
				Call Error_Exit("SSSUSR.INI ���m�F���Ă��������B[" & strINIDATNM(I) & "]")
			Else
				SSS_INIDAT(I) = LeftWid(rtnPara.Value, LENGTH)
			End If
			If Right(SSS_INIDAT(I), 1) <> "\" And Right(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
		Next I
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_DspLineNo
	'   �T�v�F  �\���p�s�ԍ��擾
	'   �����F�@pm_Def_LineNo
	'           pm_HIKET51_DSP_DATA    :��ʋƖ����\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_DspLineNo(ByRef pm_Def_LineNo As String, ByRef pm_JdnTrKb As String) As String
		
		Dim Ret_Value As String
		
		Select Case pm_JdnTrKb
			Case gc_strJDNTRKB_SET
				'�Z�b�g�A�b�v�͓��Q��
				Ret_Value = Mid(pm_Def_LineNo, 1, 2)
				
			Case Else
				'�ȊO�͌�Q��
				Ret_Value = Mid(pm_Def_LineNo, 2, 2)
				
		End Select
		
		F_Get_DspLineNo = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_TANNM
	'   �T�v�F  �S���Җ��̎擾
	'   �����F�@pm_Def_LineNo
	'           pm_HIKET51_DSP_DATA    :��ʋƖ����\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANNM(ByRef pm_TANCD As String) As String
		
		Dim Ret_Value As String
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim intRet As Short
		
		Ret_Value = ""
		
		'�S���҃}�X�^����
		Call DB_TANMTA_Clear(DB_TANMTA)
		intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
		If intRet = 0 Then
			Ret_Value = DB_TANMTA.TANNM
		End If
		
		CF_Get_TANNM = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Frm_Location
	'   �T�v�F  �����\���ʒu�ݒ�
	'   �����F�@pm_Form        :�t�H�[��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Frm_Location(ByRef pm_Form As System.Windows.Forms.Form) As Short
		
		With pm_Form
			.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(.Width)) / 2)
			.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(.Height)) / 2)
		End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Frm_IN_TANCD
	'   �T�v�F  ���͒S���ҕҏW
	'   �����F�@pm_Form        :�t�H�[��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As System.Windows.Forms.Form, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		With pm_Form
			'���͒S���҃R�[�h
			'UPGRADE_ISSUE: Control HD_IN_TANCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Trg_Index = CShort(.HD_IN_TANCD.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
			
			'���͒S���Җ�
			'UPGRADE_ISSUE: Control HD_IN_TANNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Trg_Index = CShort(.HD_IN_TANNM.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
		End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_SYSTBASaiban
	'   �T�v�F  �`�[�Ǘ�NO�̔ԏ���
	'   �����F�@Pm_strDATNO()  :�`�[�Ǘ�No
	'           Pm_strRECNO()  :���R�[�h�Ǘ�No
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBASaiban(ByRef pot_strDatNo() As String, ByRef Pot_strRECNO() As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDatNo As Decimal
		Static curRecNo As Decimal
		Static intCnt As Short
		Static strDATNO As String
		Static strRecNo As String
		
		On Error GoTo ERR_AE_SYSTBASaiban
		
		AE_SYSTBASaiban = 9
		
		bolTran = False
		
		'�g�����U�N�V�����J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'���[�U�[���Ǘ��e�[�u���擾
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBA        "
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    strSQL = strSQL & "    for Update NoWait "
		strSQL = strSQL & "    for Update  "
		' === 20061108 === UPDATE E -
		
		'SQL���s
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		' === 20061108 === UPDATE E -
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'EOF����
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBASaiban = 1
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'�`�[�Ǘ�No�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curDatNo = CDec(CF_Ora_GetDyn(usrOdy, "DATNO", "0")) + 1
		If curDatNo > 9999999999# Then
			'9999999999�𒴂����ꍇ�͖߂�
			curDatNo = 1
		End If
		For intCnt = 1 To UBound(pot_strDatNo)
			pot_strDatNo(intCnt) = VB6.Format(CStr(curDatNo), "0000000000")
			curDatNo = curDatNo + 1
			If curDatNo > 9999999999# Then
				'9999999999�𒴂����ꍇ�͖߂�
				curDatNo = 1
			End If
		Next intCnt
		
		'���R�[�h�Ǘ�No�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curRecNo = CDec(CF_Ora_GetDyn(usrOdy, "RECNO", "0")) + 1
		If curRecNo > 9999999999# Then
			'9999999999�𒴂����ꍇ�͖߂�
			curRecNo = 1
		End If
		
		For intCnt = 1 To UBound(Pot_strRECNO)
			Pot_strRECNO(intCnt) = VB6.Format(CStr(curRecNo), "0000000000")
			curRecNo = curRecNo + 1
			If curRecNo > 9999999999# Then
				'9999999999�𒴂����ꍇ�͖߂�
				curRecNo = 1
			End If
		Next intCnt
		
		'���[�U�[���Ǘ��e�[�u���X�V
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    usrOdy.Obj_Ody.Edit
		'    usrOdy.Obj_Ody.Fields("DATNO").Value = pot_strDatNo(UBound(pot_strDatNo))
		'    If UBound(Pot_strRECNO) > 0 Then
		'        usrOdy.Obj_Ody.Fields("RECNO").Value = Pot_strRECNO(UBound(Pot_strRECNO))
		'    End If
		'    If Trim(GV_SysTime) <> "" Then
		'        usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
		'    End If
		'    If Trim(GV_SysDate) <> "" Then
		'        usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
		'    End If
		'    usrOdy.Obj_Ody.Update
		
		If Trim(pot_strDatNo(UBound(pot_strDatNo))) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strDATNO = CF_Ora_GetDyn(usrOdy, "DATNO", "")
		Else
			strDATNO = pot_strDatNo(UBound(pot_strDatNo))
		End If
		
		If Trim(Pot_strRECNO(UBound(Pot_strRECNO))) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strRecNo = CF_Ora_GetDyn(usrOdy, "RECNO", "")
		Else
			strRecNo = Pot_strRECNO(UBound(Pot_strRECNO))
		End If
		
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBA "
		strSQL = strSQL & "    SET DATNO = '" & strDATNO & "' "
		strSQL = strSQL & "      , RECNO = '" & strRecNo & "' "
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		' === 20061108 === UPDATE E -
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBASaiban = 0
		
EXIT_AE_SYSTBASaiban: 
		Exit Function
		
ERR_AE_SYSTBASaiban: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 2049 Then
			' === 20061108 === UPDATE E -
			'���Ŏg�p��
			AE_SYSTBASaiban = 2
		End If
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBASaiban
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_SYSTBCSaiban
	'   �T�v�F  �`�[NO�̔ԏ���
	'   �����F�@Pin_strDKBSB     :�̔ԑΏۂ̓`�[����敪���
	'           Pot_strDENNO     :�擾���ꂽ�`�[��
	'           Pin_strADDDENCD  :���ϔԍ��̍̔Ԃ̏ꍇ�A�����N��(�����U���j
	'           Pin_strKbn       :�󒍔ԍ��̏ꍇ����敪
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBCSaiban(ByVal Pin_strDKBSB As String, ByRef Pot_strDENNO As String, Optional ByVal Pin_strADDDENCD As String = "", Optional ByVal Pin_strKbn As String = "") As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static strDenNo As String
		Static intCnt As Short
		Static strRtn As String
		Static strFixCd As String
		' === 20060814 === INSERT S - ACE)Nagasawa
		Static intRet As Short
		' === 20060814 === INSERT E -
		' === 20061119 === INSERT S - ACE)Nagasawa
		Static strDate As String
		Static strTIME As String
		' === 20061119 === INSERT E -
		
		On Error GoTo ERR_AE_SYSTBCSaiban
		
		AE_SYSTBCSaiban = 9
		
		bolTran = False
		Pot_strDENNO = ""
		strFixCd = ""
		
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(Pin_strADDDENCD) = True And Pin_strDKBSB = gc_strDKBSB_MIT Then
			GoTo EXIT_AE_SYSTBCSaiban
		End If
		
		'�g�����U�N�V�����J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		Select Case Pin_strDKBSB
			'���ϔԍ��̍̔�
			Case gc_strDKBSB_MIT
				
				' === 20060814 === UPDATE S - ACE)Nagasawa
				'            '���[�U�[�`�[No�e�[�u���擾
				'            strSQL = ""
				'            strSQL = strSQL & " Select *             "
				'            strSQL = strSQL & "   from SYSTBC        "
				'            strSQL = strSQL & "  Where DKBSB    = '" & Pin_strDKBSB & "' "
				'            strSQL = strSQL & "    and ADDDENCD = '" & Pin_strADDDENCD & "' "
				'            strSQL = strSQL & "    for Update NoWait "
				'
				'            'SQL���s
				'            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
				'            If bolRet = False Then
				'                GoTo ERR_AE_SYSTBCSaiban
				'            End If
				'
				'            'EOF����
				'            If CF_Ora_EOF(usrOdy) = True Then
				'                Pot_strDENNO = "00000001"
				'                '���[�U�[�`�[No�e�[�u���ǉ�
				'                usrOdy.Obj_Ody.AddNew
				'                usrOdy.Obj_Ody.Fields("DKBSB").Value = gc_strDKBSB_MIT              '�`�[����敪���
				'                usrOdy.Obj_Ody.Fields("ADDDENCD").Value = Pin_strADDDENCD           '�`�[�t������
				'                usrOdy.Obj_Ody.Fields("DENNM").Value = gc_strDENNM_MIT              '�`�[����
				'                usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                 '�`�[No
				'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '�ŏI��ƎҺ���
				'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    '�N���C�A���gID
				'                If Trim(GV_SysTime) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime               '�^�C���X�^���v�i���ԁj
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
				'                End If
				'                If Trim(GV_SysDate) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate               '�^�C���X�^���v�i���t�j
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
				'                End If
				'                usrOdy.Obj_Ody.Update
				'            Else
				'                curDenNo = CCur(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
				'
				'                '���ϔԍ��͂S��
				'                If curDenNo > 9999 Then
				'                    curDenNo = 1
				'                End If
				'                strDenNo = Format(CStr(curDenNo), "00000000")
				'
				'                Pot_strDENNO = strDenNo
				'
				'                '���[�U�[�`�[No�e�[�u���X�V
				'                usrOdy.Obj_Ody.Edit
				'                usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                     '�`�[No
				'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '�ŏI��ƎҺ���
				'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    '�N���C�A���gID
				'                If Trim(GV_SysTime) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
				'                End If
				'                If Trim(GV_SysDate) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
				'                End If
				'                usrOdy.Obj_Ody.Update
				'            End If
				'
				'            bolRet = CF_Ora_CloseDyn(usrOdy)
				'            If bolRet = False Then
				'                    GoTo ERR_AE_SYSTBCSaiban
				'            End If
				
				'���ϔԍ��̔ԏ���
				intRet = F_SYSTBC_Update(Pin_strADDDENCD, Pot_strDENNO)
				If intRet <> 0 Then
					AE_SYSTBCSaiban = intRet
					GoTo ERR_AE_SYSTBCSaiban
				End If
				' === 20060814 === UPDATE E -
				
				'�󒍔ԍ��̍̔�
			Case gc_strDKBSB_UOD
				'�̔ԃ}�X�^�擾
				strSQL = ""
				strSQL = strSQL & " Select *             "
				strSQL = strSQL & "   from SAIMTA        "
				strSQL = strSQL & "  Where SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
				' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
				'            strSQL = strSQL & "    for Update NoWait "
				strSQL = strSQL & "    for Update "
				' === 20061108 === UPDATE E -
				
				'SQL���s
				' === 20061119 === UPDATE S - ACE)Nagasawa
				'            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
				bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
				' === 20061119 === UPDATE E -
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
				' === 20061119 === INSERT S - ACE)Nagasawa
				'�^�C���X�^���v����
				strDate = ""
				strTIME = ""
				If Trim(GV_SysTime) <> "" Then
					strDate = GV_SysTime
					strTIME = GV_SysTime
				Else
					strDate = CStr(VB6.Format(Now, "yyyymmdd"))
					strTIME = CStr(VB6.Format(Now, "hhmmss"))
				End If
				' === 20061119 === INSERT E -
				
				'EOF����
				If CF_Ora_EOF(usrOdy) = True Then
					' === 20060927 === UPDATE S - ACE)Nagasawa
					'                Pot_strDENNO = "00001"
					Pot_strDENNO = "0001"
					' === 20060927 === UPDATE E -
					'���[�U�[�`�[No�e�[�u���ǉ�
					' === 20061119 === UPDATE S - ACE)Nagasawa
					'                usrOdy.Obj_Ody.AddNew
					'                usrOdy.Obj_Ody.Fields("SDKBSB").Value = gc_strSDKBSB_UOD            '�`�[���
					'                usrOdy.Obj_Ody.Fields("FIXCD").Value = "R"                          '�Œ�l
					'                strFixCd = "R"
					'                usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO                '�A��
					'                usrOdy.Obj_Ody.Fields("SAIKBA").Value = Space(1)                    '�敪�P
					'                usrOdy.Obj_Ody.Fields("SAIKBB").Value = Space(1)                    '�敪�Q
					'                usrOdy.Obj_Ody.Fields("SAIKBC").Value = Space(1)                    '�敪�R
					'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '�ŏI��ƎҺ���
					'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    '�N���C�A���gID
					'                If Trim(GV_SysTime) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime               '�^�C���X�^���v�i���ԁj
					'                    usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime            '�^�C���X�^���v�i�o�^���ԁj
					'                End If
					'                If Trim(GV_SysDate) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate               '�^�C���X�^���v�i���t�j
					'                    usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate            '�^�C���X�^���v�i�o�^���t�j
					'                End If
					'                usrOdy.Obj_Ody.Update
					
					strSQL = ""
					strSQL = strSQL & " INSERT INTO SYSTBC "
					strSQL = strSQL & "     SDKBSB    "
					strSQL = strSQL & "   , FIXCD     "
					strSQL = strSQL & "   , SDENNO    "
					strSQL = strSQL & "   , SAIKBA    "
					strSQL = strSQL & "   , SAIKBB    "
					strSQL = strSQL & "   , SAIKBC    "
					strSQL = strSQL & "   , FOPEID    "
					strSQL = strSQL & "   , FCLTID    "
					strSQL = strSQL & "   , WRTFSTTM  "
					strSQL = strSQL & "   , WRTFSTDT  "
					strSQL = strSQL & "   , OPEID     "
					strSQL = strSQL & "   , CLTID     "
					strSQL = strSQL & "   , WRTTM     "
					strSQL = strSQL & "   , WRTDT     "
					strSQL = strSQL & "   , UOPEID    "
					strSQL = strSQL & "   , UCLTID    "
					strSQL = strSQL & "   , UWRTTM    "
					strSQL = strSQL & "   , UWRTDT    "
					strSQL = strSQL & "   , PGID      "
					strSQL = strSQL & " VALUES  "
					strSQL = strSQL & "   ( '" & gc_strSDKBSB_UOD & "' "
					strSQL = strSQL & "   , '" & "R" & "' "
					strSQL = strSQL & "   , '" & Pot_strDENNO & "' "
					strSQL = strSQL & "   , '" & "Space(1) & " ' "
					strSQL = strSQL & "   , '" & "Space(1) & " ' "
					strSQL = strSQL & "   , '" & "Space(1) & " ' "
					strSQL = strSQL & "   , '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , '" & strTIME & "' "
					strSQL = strSQL & "   , '" & strDate & "' "
					strSQL = strSQL & "   , '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , '" & strTIME & "' "
					strSQL = strSQL & "   , '" & strDate & "' "
					strSQL = strSQL & "   , '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , '" & strTIME & "' "
					strSQL = strSQL & "   , '" & strDate & "' "
					strSQL = strSQL & "   , '" & SSS_PrgId & "') "
					' === 20061119 === UPDATE E -
				Else
					'�A�Ԏ擾
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strDenNo = CF_Ora_GetDyn(usrOdy, "SDENNO", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strFixCd = CF_Ora_GetDyn(usrOdy, "FIXCD", "")
					
					If strDenNo = "" Then
						GoTo ERR_AE_SYSTBCSaiban
					End If
					
					'�󒍔ԍ�
					For intCnt = 4 To 1 Step -1
						bolRet = JDNNO_CntUp(Mid(strDenNo, 1 + intCnt, 1), strRtn)
						strDenNo = Left(strDenNo, 1 + intCnt - 1) & strRtn & Mid(strDenNo, 1 + intCnt + 1)
						If bolRet = False Then
							Exit For
						End If
					Next intCnt
					
					' === 20060927 === INSERT S - ACE)Nagasawa
					'                If strDenNo = "00000" Then
					'                   strDenNo = "00001"
					'                End If
					If Trim(strDenNo) = "0000" Then
						strDenNo = "0001 "
					End If
					' === 20060927 === INSERT E -
					
					Pot_strDENNO = strDenNo
					
					'���[�U�[�`�[No�e�[�u���X�V
					' === 20061119 === UPDATE S - ACE)Nagasawa
					'                usrOdy.Obj_Ody.Edit
					'                usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO                '�`�[No
					'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '�ŏI��ƎҺ���
					'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    '�N���C�A���gID
					'                If Trim(GV_SysTime) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
					'                Else
					'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
					'                End If
					'                If Trim(GV_SysDate) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
					'                Else
					'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
					'                End If
					'                usrOdy.Obj_Ody.Update
					
					strSQL = ""
					strSQL = strSQL & " UPDATE SAIMTA "
					strSQL = strSQL & " SET "
					strSQL = strSQL & "     SDENNO = '" & Pot_strDENNO & "' "
					strSQL = strSQL & "   , OPEID  = '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , CLTID  = '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , WRTTM  = '" & strTIME & "' "
					strSQL = strSQL & "   , WRTDT  = '" & strDate & "' "
					strSQL = strSQL & "   , UOPEID = '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , UCLTID = '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , UWRTTM = '" & strTIME & "' "
					strSQL = strSQL & "   , UWRTDT = '" & strDate & "' "
					strSQL = strSQL & "   , PGID   = '" & SSS_PrgId & "' "
					strSQL = strSQL & "  WHERE SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
					' === 20061119 === UPDATE E -
				End If
				
				' === 20061119 === INSERT S - ACE)Nagasawa
				'SQL���s
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				' === 20061119 === INSERT E -
				
				bolRet = CF_Ora_CloseDyn(usrOdy)
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
		End Select
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		'�̔�
		Select Case Pin_strDKBSB
			'���ϔԍ�
			Case gc_strDKBSB_MIT
				Pot_strDENNO = Mid(Pin_strADDDENCD, 3, 4) & Mid(Pot_strDENNO, 5, 4)
				
				'�󒍔ԍ�
			Case gc_strDKBSB_UOD
				Select Case Pin_strKbn
					' === 20060927 === UPDATE S - ACE)Nagasawa
					'                Case gc_strJDNTRKB_TAN                     '�P�i
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_SET                     '�Z�b�g�A�b�v
					'                    Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_SYS                     '�V�X�e��
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_SYR                     '�C��
					'                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_HSY                     '�ێ�
					'                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_KAS                     '�ݏo
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_ELS                     '���̑�
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_TAN '�P�i
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_SET '�Z�b�g�A�b�v
						Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_SYS '�V�X�e��
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_SYR '�C��
						Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_HSY '�ێ�
						Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_KAS '�ݏo
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_ELS '���̑�
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
						' === 20060927 === UPDATE E -
					Case Else
				End Select
			Case Else
				
		End Select
		
		AE_SYSTBCSaiban = 0
		
EXIT_AE_SYSTBCSaiban: 
		Exit Function
		
ERR_AE_SYSTBCSaiban: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 51 Then
			' === 20061108 === UPDATE E -
			'���Ŏg�p��
			AE_SYSTBCSaiban = 2
		End If
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban
		
	End Function
	
	' === 20060814 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SYSTBC_Update
	'   �T�v�F  SYSTBC�X�V����
	'   �����F�@Pin_strADDDENCD  :�����N��(�����U���j
	' �@�@�@�@�@Pot_strDENNO     :�擾���ꂽ�`�[��
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBC_Update(ByVal Pin_strADDDENCD As String, ByRef Pot_strDENNO As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static curDENNO As Decimal
		Static strDenNo As String
		Static strSTTNO As String
		Static strENDNO As String
		
		On Error GoTo ERR_F_SYSTBC_Update
		
		F_SYSTBC_Update = 9
		
		Pot_strDENNO = ""
		strSTTNO = ""
		strENDNO = ""
		
		'���[�U�[�`�[No�e�[�u���擾
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_MIT & "' "
		strSQL = strSQL & "    and ADDDENCD = '" & Pin_strADDDENCD & "' "
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    strSQL = strSQL & "    for Update NoWait "
		strSQL = strSQL & "    for Update "
		' === 20061108 === UPDATE E -
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		If bolRet = False Then
			GoTo ERR_F_SYSTBC_Update
		End If
		
		'EOF����
		If CF_Ora_EOF(usrOdy) = True Then
			strSTTNO = "00000001"
			strENDNO = "00009999"
			Pot_strDENNO = strSTTNO
			'���[�U�[�`�[No�e�[�u���ǉ�
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.AddNew �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.AddNew()
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DKBSB").Value = gc_strDKBSB_MIT '�`�[����敪���
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("ADDDENCD").Value = Pin_strADDDENCD '�`�[�t������
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DENNM").Value = gc_strDENNM_MIT '�`�[����
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '�`�[No
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("STTNO").Value = strSTTNO '�J�n�`�[NO.
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("ENDNO").Value = strENDNO '�I���`�[NO.
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '�`�[No
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '�ŏI��ƎҺ���
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value '�N���C�A���gID
			If Trim(GV_SysTime) <> "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime '�^�C���X�^���v�i���ԁj
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
			End If
			If Trim(GV_SysDate) <> "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate '�^�C���X�^���v�i���t�j
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate '�^�C���X�^���v�i�o�^���t�j
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Update()
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSTTNO = CF_Ora_GetDyn(usrOdy, "STTNO", "0")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strENDNO = CF_Ora_GetDyn(usrOdy, "ENDNO", "")
			If IsNumeric(strENDNO) = False Then
				strENDNO = "00009999"
			End If
			
			'���ϔԍ��͂S��
			If curDENNO > CF_Get_CCurString(strENDNO) Then
				curDENNO = CF_Get_CCurString(strSTTNO)
			End If
			strDenNo = VB6.Format(CStr(curDENNO), New String("0", 8))
			
			Pot_strDENNO = strDenNo
			
			'���[�U�[�`�[No�e�[�u���X�V
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Edit �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Edit()
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '�`�[No
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '�ŏI��ƎҺ���
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value '�N���C�A���gID
			If Trim(GV_SysTime) <> "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
			End If
			If Trim(GV_SysDate) <> "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Update()
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_F_SYSTBC_Update
		End If
		
		F_SYSTBC_Update = 0
		
EXIT_F_SYSTBC_Update: 
		Exit Function
		
ERR_F_SYSTBC_Update: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 51 Then
			' === 20061108 === UPDATE E -
			'���Ŏg�p��
			F_SYSTBC_Update = 2
		End If
		
		GoTo EXIT_F_SYSTBC_Update
		
	End Function
	' === 20060814 === INSERT E -
	
	' === 20060815 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_SYSTBCSaiban_PUDLNO
	'   �T�v�F  ���o�ɔԍ��̔ԏ���
	'   �����F�@Pm_strJDNTRKB   :�󒍎���敪
	'           Pm_strPUDLNO()  :���o�ɔԍ�
	'           Pm_intEntryKb   :�o�^�����敪�i1:�o�^�@2:�����j
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20060822 === UPDATE S - ACE)Sejima ���o�ɔԍ��̔ԏ���
	'DPublic Static Function AE_SYSTBCSaiban_PUDLNO(ByVal Pm_strJDNTRKB As String, _
	''D                                              ByRef Pm_strPUDLNO() As String) As Integer
	' === 20060822 === UPDATE ��
	Public Function AE_SYSTBCSaiban_PUDLNO(ByVal Pm_strJDNTRKB As String, ByRef Pm_strPUDLNO() As String, Optional ByVal Pm_intEntryKb As Short = 1) As Short
		' === 20060822 === UPDATE E
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static curSTTNO As Decimal
		Static curENDNO As Decimal
		Static strADDDENCD As String
		Static intCnt As Short
		Static intGetData As Short
		' === 20060822 === INSERT S - ACE)Sejima
		Static strNewPUDLNO As String 'SYSTBC�X�V�p
		' === 20060822 === INSERT E
		
		On Error GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		
		AE_SYSTBCSaiban_PUDLNO = 9
		
		bolTran = False
		
		intGetData = 0
		'�󒍎���敪�ɂ�蔻��
		Select Case Pm_strJDNTRKB
			'�P�i�A�V�X�e���A���̑�
			Case gc_strJDNTRKB_TAN, gc_strJDNTRKB_SYS, gc_strJDNTRKB_ELS
				intGetData = UBound(Pm_strPUDLNO)
				
				'�Z�b�g�A�b�v
			Case gc_strJDNTRKB_SET
				' === 20060822 === UPDATE S - ACE)Sejima ���o�ɔԍ��̔ԏ���
				'D            intGetData = 1
				' === 20060822 === UPDATE ��
				Select Case Pm_intEntryKb
					Case 1
						'�o�^�̏ꍇ
						intGetData = 1
					Case Else
						'�����̏ꍇ
						intGetData = 0
						
				End Select
				' === 20060822 === UPDATE E
				
				'�C���A�ێ�A�ݏo
			Case gc_strJDNTRKB_SYR, gc_strJDNTRKB_HSY, gc_strJDNTRKB_KAS
				intGetData = 0
				
			Case Else
		End Select
		
		'�g�����U�N�V�����J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'���[�U�[�`�[���e�[�u���擾
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_PUDL & "' "
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    strSQL = strSQL & "    for Update NoWait "
		strSQL = strSQL & "    for Update "
		' === 20061108 === UPDATE E -
		
		'SQL���s
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		' === 20061108 === UPDATE E -
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'EOF����
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBCSaiban_PUDLNO = 1
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'�`�[�t���R�[�h�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strADDDENCD = Trim(CF_Ora_GetDyn(usrOdy, "ADDDENCD", ""))
		
		'�J�n�`�[No�擾
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
			curSTTNO = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curSTTNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
		End If
		
		'�I���`�[No�擾
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
			curENDNO = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curENDNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
		End If
		
		'�`�[NO.�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
		If curDENNO > curENDNO Then
			'�I���`�[NO�𒴂����ꍇ�͖߂�
			curDENNO = curSTTNO
		End If
		
		For intCnt = 1 To intGetData
			' === 20060822 === UPDATE S - ACE)Sejima
			'D        Pm_strPUDLNO(intCnt) = strADDDENCD & Format(curDENNO, String(8, "0"))
			' === 20060822 === UPDATE ��
			strNewPUDLNO = VB6.Format(curDENNO, New String("0", 8))
			Pm_strPUDLNO(intCnt) = strADDDENCD & strNewPUDLNO
			' === 20060822 === UPDATE E
			curDENNO = curDENNO + 1
			If curDENNO > curENDNO Then
				'�I���`�[No�𒴂����ꍇ�͖߂�
				curDENNO = curSTTNO
			End If
		Next intCnt
		
		'���[�U�[�`�[���e�[�u���X�V
		If intGetData > 0 Then
			' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
			'        usrOdy.Obj_Ody.Edit
			'' === 20060822 === UPDATE S - ACE)Sejima
			''D        usrOdy.Obj_Ody.Fields("DENNO").Value = Right(Pm_strPUDLNO(UBound(Pm_strPUDLNO)), 8)
			'' === 20060822 === UPDATE ��
			'        usrOdy.Obj_Ody.Fields("DENNO").Value = strNewPUDLNO
			'' === 20060822 === UPDATE E
			'        If Trim(GV_SysTime) <> "" Then
			'            usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
			'        Else
			'            usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
			'        End If
			'        If Trim(GV_SysDate) <> "" Then
			'            usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
			'        Else
			'            usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
			'        End If
			'        usrOdy.Obj_Ody.Update
			
			strSQL = ""
			strSQL = strSQL & " UPDATE SYSTBC "
			strSQL = strSQL & "    SET DENNO      = '" & CF_Ora_String(strNewPUDLNO, 8) & "' "
			
			If Trim(GV_SysTime) <> "" Then
				strSQL = strSQL & "      , WRTTM      = '" & CF_Ora_String(GV_SysTime, 6) & "' "
			Else
				strSQL = strSQL & "      , WRTTM      = '" & CStr(VB6.Format(Now, "hhmmss")) & "' "
			End If
			
			If Trim(GV_SysDate) <> "" Then
				strSQL = strSQL & "      , WRTDT      = '" & CF_Ora_String(GV_SysDate, 8) & "' "
			Else
				strSQL = strSQL & "      , WRTDT      = '" & CStr(VB6.Format(Now, "yyyymmdd")) & "' "
			End If
			
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        DKBSB    = '" & gc_strDKBSB_PUDL & "' "
			
			'�r�p�k���s
			bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
			If bolRet = False Then
				GoTo ERR_AE_SYSTBCSaiban_PUDLNO
			End If
			' === 20061108 === UPDATE E -
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBCSaiban_PUDLNO = 0
		
EXIT_AE_SYSTBCSaiban_PUDLNO: 
		Exit Function
		
ERR_AE_SYSTBCSaiban_PUDLNO: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 51 Then
			' === 20061108 === UPDATE E -
			'���Ŏg�p��
			AE_SYSTBCSaiban_PUDLNO = 2
		End If
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban_PUDLNO
		
	End Function
	' === 20060815 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function JDNNO_CntUp
	'   �T�v�F  �󒍔ԍ��J�E���g�A�b�v����
	'   �����F�@pin_strJDNNO     :�J�E���g�A�b�v�Ώە���
	'           pot_strRtn     :�J�E���g�A�b�v�㕶��
	'   �ߒl�F  True:���オ�肠��  False:���オ��Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function JDNNO_CntUp(ByVal pin_strJDNNO As String, ByRef pot_strRtn As String) As Boolean
		
		Dim intJDNNO As Short
		Dim strJdnNo As String
		
		JDNNO_CntUp = False
		
		' === 20060927 === UPDATE S - ACE)Nagasawa
		'    Select Case pin_strJDNNO
		Select Case Trim(pin_strJDNNO)
			' === 20060927 === UPDATE E -
			Case "9"
				pot_strRtn = "A"
				Exit Function
				
			Case "Z"
				pot_strRtn = "0"
				JDNNO_CntUp = True
				Exit Function
				
				' === 20060927 === INSERT S - ACE)Nagasawa
			Case ""
				pot_strRtn = " "
				JDNNO_CntUp = True
				Exit Function
				' === 20060927 === INSERT E -
		End Select
		
		intJDNNO = Asc(pin_strJDNNO)
		pot_strRtn = Chr(intJDNNO + 1)
		
		Select Case pot_strRtn
			Case "I", "O"
				intJDNNO = Asc(pot_strRtn)
				pot_strRtn = Chr(intJDNNO + 1)
			Case Else
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CalcTAX_Meisai
	'   �T�v�F  ����Ōv�Z����
	'   �����F�@Pin_strHINZEIKB    :���i����ŋ敪
	'           Pin_curZEIRT       :����ŗ�
	'           Pin_curTANKA       :�P��(�Ŕ����P��)
	'           Pin_curSURYO       :����
	'           Pin_strTOKZEIKB    :���Ӑ����ŋ敪
	'           Pin_strTOKRPSKB    :����Œ[����������
	'           Pin_strTOKZRNKB    :����Œ[�������敪
	'           Pot_curUZEKN       :����Ŋz
	'   �ߒl�F  True:����  False:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061116 === UPDATE S - ACE)Nagasawa �V�X�e���̏ꍇ�͒P�� * ����<>���z���\�Ƃ���
	'Public Static Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, _
	''                                         ByVal Pin_curZEIRT As Currency, _
	''                                         ByVal Pin_curTANKA As Currency, _
	''                                         ByVal Pin_curSURYO As Currency, _
	''                                         ByVal Pin_strTOKZEIKB As String, _
	''                                         ByVal Pin_strTOKRPSKB As String, _
	''                                         ByVal Pin_strTOKZRNKB As String, _
	''                                         ByRef Pot_curUZEKN As Currency) As Integer
	
	Public Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, ByVal Pin_curZEIRT As Decimal, ByVal Pin_curTANKA As Decimal, ByVal Pin_curSURYO As Decimal, ByVal Pin_strTOKZEIKB As String, ByVal Pin_strTOKRPSKB As String, ByVal Pin_strTOKZRNKB As String, ByRef Pot_curUZEKN As Decimal, Optional ByVal Pin_curKingk As Decimal = 0) As Short
		' === 20061116 === UPDATE E -
		
		Static curZeigk As Decimal
		Static strRPSKB As String
		
		On Error GoTo ERR_AE_CalcTAX_Meisai
		
		AE_CalcTAX_Meisai = False
		
		Pot_curUZEKN = 0
		
		strRPSKB = ""
		Select Case Pin_strTOKRPSKB
			'�~����
			Case gc_strTOKRPSKB_0
				strRPSKB = gc_strRPSKB_I1
				'�\�~����
			Case gc_strTOKRPSKB_10
				strRPSKB = gc_strRPSKB_I2
				'�S�~����
			Case gc_strTOKRPSKB_100
				strRPSKB = gc_strRPSKB_I3
		End Select
		
		Select Case Pin_strHINZEIKB '���i����ŋ敪
			'�����敪�ǂ���
			Case gc_strHINZEIKB_TOK
				Select Case Pin_strTOKZEIKB '���Ӑ����ŋ敪
					'�Ŕ����A�ō���
					Case gc_strTOKZEIKB_KOM, gc_strTOKZEIKB_NUK
						' === 20061116 === UPDATE S - ACE)Nagasawa �V�X�e���̏ꍇ�͒P�� * ����<>���z���\�Ƃ���
						'                    curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
						If Pin_curKingk = 0 Then
							curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
						Else
							curZeigk = Pin_curKingk * Pin_curZEIRT / 100
						End If
						' === 20061116 === UPDATE E -
						Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
						Pot_curUZEKN = curZeigk
						
						'��ې�
					Case gc_strTOKZEIKB_HIK
				End Select
				
				'�Ŕ���,�ō���
			Case gc_strHINZEIKB_KOM, gc_strHINZEIKB_NUK
				' === 20061116 === UPDATE S - ACE)Nagasawa �V�X�e���̏ꍇ�͒P�� * ����<>���z���\�Ƃ���
				'            curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
				If Pin_curKingk = 0 Then
					curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
				Else
					curZeigk = Pin_curKingk * Pin_curZEIRT / 100
				End If
				' === 20061116 === UPDATE E -
				Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
				Pot_curUZEKN = curZeigk
				'��ې�
			Case gc_strHINZEIKB_HIK
			Case Else
		End Select
		
		AE_CalcTAX_Meisai = True
		
EXIT_AE_CalcTAX_Meisai: 
		Exit Function
		
ERR_AE_CalcTAX_Meisai: 
		
		GoTo EXIT_AE_CalcTAX_Meisai
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CalcRoundKingk
	'   �T�v�F  ���z�܂�ߌv�Z����
	'   �����F�@Pio_curKingk       :�܂�ߋ��z
	'           Pin_strRPSKB    :���z�[�����������i����Œ[�����������̏ꍇ
	'           Pin_strZRNKB    :���z�[�������敪
	'   �ߒl�F  �Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub AE_CalcRoundKingk(ByRef Pio_curKingk As Decimal, ByVal pin_strRPSKB As String, ByVal pin_strZRNKB As String)
		
		Dim curKingk As Decimal
		Dim curKingk_wk As Decimal
		
		curKingk = 0
		
		Select Case pin_strRPSKB '���z�[����������
			'�P
			Case gc_strRPSKB_I1
				curKingk = Pio_curKingk
				'�P�O
			Case gc_strRPSKB_I2
				curKingk = Pio_curKingk / 10
				'�P�O�O
			Case gc_strRPSKB_I3
				curKingk = Pio_curKingk / 100
				'��������
			Case gc_strRPSKB_D1
				curKingk = Pio_curKingk
				'��������
			Case gc_strRPSKB_D2
				curKingk = Pio_curKingk * 10
				'������O��
			Case gc_strRPSKB_D3
				curKingk = Pio_curKingk * 100
				'������l��
			Case gc_strRPSKB_D4
				curKingk = Pio_curKingk * 1000
				'������܈�
			Case gc_strRPSKB_D5
				curKingk = Pio_curKingk * 10000
		End Select
		
		Select Case pin_strZRNKB '���z�[�������敪
			'�؎̂�
			Case gc_strTOKZRNKB_DWN
				curKingk = Fix(curKingk)
				'�l�̌ܓ�
			Case gc_strTOKZRNKB_RND
				' === 20061115 === UPDATE S - ACE)Nagasawa
				'            curKingk = Round(curKingk)
				If curKingk >= 0 Then
					curKingk = Fix(curKingk + 0.5)
				Else
					curKingk = Fix(curKingk - 0.5)
				End If
				' === 20061115 === UPDATE E -
				'�؂�グ
			Case gc_strTOKZRNKB_UP
				curKingk_wk = Fix(curKingk)
				If curKingk_wk < curKingk Then
					curKingk = curKingk_wk + 1
				Else
					curKingk = curKingk_wk
				End If
		End Select
		
		Select Case pin_strRPSKB '���z�[����������
			'�P
			Case gc_strRPSKB_I1
				curKingk = curKingk
				'�P�O
			Case gc_strRPSKB_I2
				curKingk = curKingk * 10
				'�P�O�O
			Case gc_strRPSKB_I3
				curKingk = curKingk * 100
				'��������
			Case gc_strRPSKB_D1
				curKingk = curKingk
				'��������
			Case gc_strRPSKB_D2
				curKingk = curKingk / 10
				'������O��
			Case gc_strRPSKB_D3
				curKingk = curKingk / 100
				'������l��
			Case gc_strRPSKB_D4
				curKingk = curKingk / 1000
				'������܈�
			Case gc_strRPSKB_D5
				curKingk = curKingk / 10000
		End Select
		
		Pio_curKingk = curKingk
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Calc_SIKRT
	'   �T�v�F  �d�ؗ��v�Z����
	'   �����F�@Pin_curTANKA       :�P��
	'           Pin_curTEIKATK     :�艿
	'           Pin_strTKNZRNKB    :���z�[�������敪
	'   �ߒl�F  �d�ؗ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_SIKRT(ByVal Pin_curTANKA As Decimal, ByVal Pin_curTEIKATK As Decimal, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curSIKRT As Decimal
		Static strZRNKB As String
		
		AE_Calc_SIKRT = 0
		If Pin_curTEIKATK = 0 Then
			curSIKRT = 0
		Else
			curSIKRT = Pin_curTANKA / Pin_curTEIKATK * 100
		End If
		
		Select Case Pin_strTKNZRNKB '���z�[�������敪
			'�؎̂�
			Case gc_strTOKZRNKB_DWN
				strZRNKB = gc_strTOKZRNKB_UP
				'�l�̌ܓ�
			Case gc_strTOKZRNKB_RND
				strZRNKB = gc_strTOKZRNKB_RND
				'�؂�グ
			Case gc_strTOKZRNKB_UP
				strZRNKB = gc_strTOKZRNKB_DWN
		End Select
		
		'���z�ۂߏ���
		' === 20061020 === UPDATE S - ACE)Nagasawa �I�[�o�[�t���[�Ή�
		'    Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D1, strZRNKB)
		Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D2, strZRNKB)
		' === 20061020 === UPDATE E -
		
		AE_Calc_SIKRT = curSIKRT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Calc_TANKA
	'   �T�v�F  �P���v�Z�����i�d�ؗ����j
	'   �����F�@Pin_curSIKRT       :�d�ؗ�
	'           Pin_curTEIKATK     :�艿
	'           Pin_strTKNRPSKB    :���z�[����������
	'           Pin_strTKNZRNKB    :���z�[�������敪
	'   �ߒl�F  �P��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_TANKA(ByVal Pin_curSIKRT As Decimal, ByVal Pin_curTEIKATK As Decimal, ByVal Pin_strTKNRPSKB As String, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curTanka As Decimal
		
		AE_Calc_TANKA = 0
		curTanka = Pin_curTEIKATK * Pin_curSIKRT / 100
		
		'���z�ۂߏ���
		Call AE_CalcRoundKingk(curTanka, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
		
		AE_Calc_TANKA = curTanka
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Calc_BSART
	'   �T�v�F  �������v�Z����
	'   �����F�@Pin_curTANKA       :�P��
	'           Pin_curSIKTK       :�d�ؒP��
	'           Pin_strTKNRPSKB    :���z�[����������
	'           Pin_strTKNZRNKB    :���z�[�������敪
	'   �ߒl�F  �d�ؗ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_BSART(ByVal Pin_curTANKA As Decimal, ByVal Pin_curSIKTK As Decimal, ByVal Pin_strTKNRPSKB As String, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curBSART As Decimal
		
		AE_Calc_BSART = 0
		
		If Pin_curTANKA = 0 Then
			curBSART = 0
		Else
			curBSART = (Pin_curTANKA - Pin_curSIKTK) / Pin_curTANKA * 100
		End If
		
		'���z�ۂߏ���
		' === 20061025 === UPDATE S - ACE)Nagasawa �K���������ʂŊۂ߂�
		'    Call AE_CalcRoundKingk(curBSART, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
		Call AE_CalcRoundKingk(curBSART, gc_strRPSKB_D2, Pin_strTKNZRNKB)
		' === 20061025 === UPDATE E -
		
		AE_Calc_BSART = curBSART
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CalcDateAdd
	'   �T�v�F  ���t�v�Z����
	'   �����F�@Pio_strDate     :�v�Z�Ώۓ�(�����W���A�܂���yyyy/mm/dd�̌`���j
	'           Pin_intAddDate  :���Z�Ώۓ����i�}�C�i�X�l�͌��Z�j
	'           Pin_strKind     :�c�Ɠ����("1":�c�Ɠ� "2":��s�ғ����@"3":�����ғ����j
	'                            �ȗ����͉c�Ɠ��ɂ��l������
	'   �ߒl�F  0 : ���� 9 : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CalcDateAdd(ByRef Pio_strDate As String, ByVal Pin_intAddDate As Short, Optional ByVal Pin_strKind As String = "0") As Short
		
		Dim strDate As String
		Dim Mst_Inf As TYPE_DB_CLDMTA
		Dim intAddDate As Short '���t�v�Z�p
		
		AE_CalcDateAdd = 9
		
		strDate = ""
		
		'���t�������`�F�b�N
		If IsDate(Pio_strDate) = True Then
			strDate = Pio_strDate
		End If
		
		'���t�l���ɕϊ�
		If IsDate(VB6.Format(Pio_strDate, "@@@@/@@/@@")) = True Then
			strDate = VB6.Format(Pio_strDate, "@@@@/@@/@@")
		End If
		
		If Trim(strDate) = "" Then
			Exit Function
		End If
		
		'���t���Z
		strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, Pin_intAddDate, CDate(strDate)))
		
		'�J�����_�}�X�^����
		If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
			Exit Function
		End If
		
		If Pin_intAddDate >= 0 Then
			intAddDate = 1
		Else
			intAddDate = -1
		End If
		
		Select Case Pin_strKind
			'�c�Ɠ��v�Z
			Case "1"
				Do Until Mst_Inf.SLDKB = "1"
					strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, intAddDate, CDate(strDate)))
					'�J�����_�}�X�^����
					If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
						Exit Function
					End If
				Loop 
				
				'��s�ғ����v�Z
			Case "2"
				Do Until Mst_Inf.BNKKDKB = "1"
					strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, intAddDate, CDate(strDate)))
					'�J�����_�}�X�^����
					If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
						Exit Function
					End If
				Loop 
				
				'�����ғ����v�Z
			Case "3"
				Do Until Mst_Inf.DTBKDKB = "1"
					strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, intAddDate, CDate(strDate)))
					'�J�����_�}�X�^����
					If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
						Exit Function
					End If
				Loop 
				
			Case Else
				
		End Select
		
		Pio_strDate = strDate
		AE_CalcDateAdd = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CmnMsgLibrary
	'   �T�v�F  �W�����b�Z�[�W�\������
	'   �����F  Pin_strPgNm     : �v���O������
	'           Pin_strMsgCode  : ���b�Z�[�W�R�[�h�iDB�����p�j
	'           pm_All  �@�@�@  : ��ʏ��
	'           pin_strMsg      : �ǉ����b�Z�[�W
	'           pin_strHeadMsg  : ���b�Z�[�W�擪�ւ̒ǉ����b�Z�[�W
	'   �ߒl�F  �I���{�^��
	'   ���l�F  �A�v���̎��s���ɏo�͂����W�����b�Z�[�W�B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061031 === UPDATE S - ACE)Nagasawa
	'Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, _
	''                                 ByVal Pin_strMsgCode As String, _
	''                                 ByRef pm_All As Cls_All, _
	''                                 Optional ByVal pin_strMsg As String = "") As Integer
	Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, ByRef pm_All As Cls_All, Optional ByVal pin_strMsg As String = "", Optional ByVal pin_strHeadMsg As String = "") As Short
		' === 20061031 === UPDATE E -
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
		' === 20060914 === INSERT S - ACE)Nagasawa
		On Error Resume Next
		' === 20060914 === INSERT E -
		
		AE_CmnMsgLibrary = False
		
		If pm_All.Dsp_IM_Denkyu Is Nothing Then
		Else
			'�v�����v�g���b�Z�[�W�̃N���A
			Call CF_Clr_Prompt(pm_All)
		End If
		
		strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1) '���b�Z�[�W���
		strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2) '���b�Z�[�W�A�C�e��
		
		' === 20060810 === INSERT S - ACE)Nagasawa
		Beep()
		' === 20060810 === INSERT E -
		
		'���b�Z�[�W�}�X�^����
		intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
		If intRet <> 0 Then
			intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
			If intRet <> 0 Then
				Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				Exit Function
			End If
		End If
		
		'�ǉ����b�Z�[�W�̕ҏW
		strMsg_add = ""
		If Mst_Inf.MSGSQ = "9" Then
			'�c�a�A�N�Z�X�n�G���[�Ƃ���
			' === 20061026 === UPDATE S - ACE)Nagasawa ���b�Z�[�W�\���̕ύX�i�����ӏ���\�����Ȃ��ꍇ����j
			'        strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "�����ӏ�   : " & pin_strMsg
			
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText
			
			'�ǉ����b�Z�[�W������ꍇ�A�����ӏ��Ƃ��ĕ\������
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = strMsg_add & "�����ӏ�   : " & pin_strMsg
			End If
			' === 20061026 === UPDATE E -
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
		'���b�Z�[�W�t���OTrue
		GV_bolMsgFlg = True
		'�L�[�o�b�t�@�̃N���A
		Call ClearKeyBuffers(pm_All)
		' === 20060920 === INSERT E
		
		'Windows�ɐ����߂�
		System.Windows.Forms.Application.DoEvents()
		
		' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
		'���b�Z�[�W�o�͏I������܂ł͔�����
		If GV_bolMsgFlg = False Then
			Exit Function
		End If
		' === 20060920 === INSERT E
		
		'���b�Z�[�W�\��
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'OK/�L�����Z��
			Case gc_strBTNKB_OKCancel
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'���~/�Ď��s/����
			Case gc_strBTNKB_AbortRetryIgnore
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbAbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'�͂�/������/�L�����Z��
			Case gc_strBTNKB_YesNoCancel
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'�͂�/������
			Case gc_strBTNKB_YesNo
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'�Ď��s/�L�����Z��
			Case gc_strBTNKB_RetryCancel
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbRetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
			Case Else
				
		End Select
		' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
		'���b�Z�[�W�t���OFalse
		GV_bolMsgFlg = False
		' === 20060920 === INSERT E
		
	End Function
	' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
	
	'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CmnMsgLibrary_2
	'   �T�v�F  �W�����b�Z�[�W�\�������i��ʏ��Ȃ��Łj
	'   �����F  Pin_strPgNm     : �v���O������
	'           Pin_strMsgCode  : ���b�Z�[�W�R�[�h�iDB�����p�j
	'           pin_strMsg      : �ǉ����b�Z�[�W
	'           pin_strHeadMsg  : ���b�Z�[�W�擪�ւ̒ǉ����b�Z�[�W
	'   �ߒl�F  �I���{�^��
	'   ���l�F  �A�v���̎��s���ɏo�͂����W�����b�Z�[�W�B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CmnMsgLibrary_2(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, Optional ByVal pin_strMsg As String = "", Optional ByVal pin_strHeadMsg As String = "") As Short
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
		On Error Resume Next
		
		AE_CmnMsgLibrary_2 = False
		
		strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1) '���b�Z�[�W���
		strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2) '���b�Z�[�W�A�C�e��
		
		Beep()
		
		'���b�Z�[�W�}�X�^����
		intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
		If intRet <> 0 Then
			intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
			If intRet <> 0 Then
				Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				Exit Function
			End If
		End If
		
		'�ǉ����b�Z�[�W�̕ҏW
		strMsg_add = ""
		If Mst_Inf.MSGSQ = "9" Then
			'�c�a�A�N�Z�X�n�G���[�Ƃ���
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText
			
			'�ǉ����b�Z�[�W������ꍇ�A�����ӏ��Ƃ��ĕ\������
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = strMsg_add & "�����ӏ�   : " & pin_strMsg
			End If
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		'���b�Z�[�W�t���OTrue
		GV_bolMsgFlg = True
		
		'Windows�ɐ����߂�
		System.Windows.Forms.Application.DoEvents()
		
		'���b�Z�[�W�o�͏I������܂ł͔�����
		If GV_bolMsgFlg = False Then
			Exit Function
		End If
		
		'���b�Z�[�W�\��
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				
				'OK/�L�����Z��
			Case gc_strBTNKB_OKCancel
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'���~/�Ď��s/����
			Case gc_strBTNKB_AbortRetryIgnore
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������/�L�����Z��
			Case gc_strBTNKB_YesNoCancel
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������
			Case gc_strBTNKB_YesNo
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�Ď��s/�L�����Z��
			Case gc_strBTNKB_RetryCancel
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				
			Case Else
				
		End Select
		
		'���b�Z�[�W�t���OFalse
		GV_bolMsgFlg = False
		
	End Function
	'''' ADD 2009/11/26  FKS) T.Yamamoto    End
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub ClearKeyBuffers
	'   �T�v�F  �L�[�o�b�t�@�N���A����
	'   �����F  pm_All  �@�@�@  : ��ʏ��
	'   �ߒl�F  �Ȃ�
	'   ���l�F  API�ɂ��L�[�o�b�t�@�̃N���A
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub ClearKeyBuffers(ByRef pm_All As Cls_All)
		Dim tMsg As Msg
		Dim lngRet As Integer
		
		Do 
			lngRet = PeekMessage(tMsg, pm_All.Dsp_Base.FormCtl.Handle.ToInt32, WM_KEYFIRST, WM_KEYLAST, PM_REMOVE)
		Loop Until lngRet = 0
	End Sub
	' === 20060920 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GetSMEDT
	'   �T�v�F  �����v�Z����
	'   �����F  Pin_strDate     : �v�Z�Ώۓ��t(�W���̐��lOr���t�j
	'           Pin_strTOKSMEKB : ���敪
	'           Pin_strTOKSMEDD : ���������t�i����j
	'           Pin_strTOKSMECC : ���T�C�N���i����j
	'           Pin_strTOKSDWKB : ���ߗj��
	'           Pin_intCHTNKB   : ���[�敪(�v�Z�Ώۓ����牽��ڂ̒��������w��)
	'           Pot_strSMEDT    : �v�Z���ʒ���
	'   �ߒl�F  0�F����@9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetSMEDT(ByVal pin_strDate As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKSMEDD As String, ByVal Pin_strTOKSMECC As String, ByVal Pin_strTOKSDWKB As String, ByVal Pin_intCHTNKB As Short, ByRef Pot_strSMEDT As String) As Short
		
		Dim strDate As String
		Dim yy As Short
		Dim mm As Short
		Dim dd As Short
		Dim Cnt As Short
		Dim I As Short
		Dim setidx As Short
		Dim idx As Short
		Dim addMM As Short
		Dim smeday(15) As Short
		Dim intTOKSMECC As Short
		Dim intTOKSMEDD As Short
		Dim intTOKSDWKB As Short
		
		AE_GetSMEDT = 9
		Pot_strSMEDT = ""
		
		'���t�`�F�b�N
		If IsDate(pin_strDate) = True Then
			strDate = VB6.Format(pin_strDate, "yyyy/mm/dd")
		Else
			If IsDate(VB6.Format(pin_strDate, "@@@@/@@/@@")) = True Then
				strDate = VB6.Format(pin_strDate, "@@@@/@@/@@")
			Else
				Exit Function
			End If
		End If
		
		yy = Year(CDate(strDate))
		mm = Month(CDate(strDate))
		dd = VB.Day(CDate(strDate))
		
		If Pin_strTOKSMEKB = gc_strSMEKB_DAY Then
			'���������t�擾
			If IsNumeric(Pin_strTOKSMEDD) = True Then
				intTOKSMEDD = CShort(Pin_strTOKSMEDD)
			Else
				Exit Function
			End If
			
			'���T�C�N���擾
			If IsNumeric(Pin_strTOKSMECC) = True Then
				intTOKSMECC = CShort(Pin_strTOKSMECC)
			Else
				Exit Function
			End If
			
			'���敪��"��"�̏ꍇ
			If intTOKSMECC = 1 Then '��������
				Pot_strSMEDT = CStr(DateSerial(yy, mm, dd + Pin_intCHTNKB))
				Exit Function
			End If
			'
			If intTOKSMECC <= 0 Or intTOKSMECC > 15 Then intTOKSMECC = 30
			Cnt = Int(30 / intTOKSMECC) '���񐔁^��
			setidx = False
			For I = 0 To Cnt - 1
				smeday(I) = intTOKSMEDD + intTOKSMECC * I
				If smeday(I) > 27 Then smeday(I) = 99
				If dd <= smeday(I) And setidx = False Then
					idx = I + Pin_intCHTNKB '�Y�����t�̒����z��Y��
					setidx = True
				End If
			Next I
			If setidx = False Then idx = Cnt + Pin_intCHTNKB
			addMM = Int(idx / Cnt)
			idx = idx Mod Cnt
			If idx < 0 Then idx = idx + Cnt
			'
			If smeday(idx) = 99 Then
				Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM + 1, 0))
			Else
				Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM, smeday(idx)))
			End If
			
		Else
			'���j���擾
			If IsNumeric(Pin_strTOKSDWKB) = True Then
				intTOKSDWKB = CShort(Pin_strTOKSDWKB)
			Else
				Exit Function
			End If
			
			'�����敪��"�j��"�̏ꍇ
			If WeekDay(CDate(strDate)) > intTOKSDWKB Then
				Pot_strSMEDT = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (7 - WeekDay(CDate(strDate)) + intTOKSDWKB) + (7 * Pin_intCHTNKB)))
			Else
				Pot_strSMEDT = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (intTOKSDWKB - WeekDay(CDate(strDate))) + (7 * Pin_intCHTNKB)))
			End If
		End If
		
		Pot_strSMEDT = VB6.Format(Pot_strSMEDT, "yyyymmdd")
		
		AE_GetSMEDT = 0
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GetUDNYTDT
	'   �T�v�F  ����\����v�Z����
	'   �����F  Pin_strDEFNOKDT : �[��(�W���̐��lOr���t�j
	'           Pin_strODNYTDT  : �o�ח\���
	'           Pin_strUDNYTDT  : ����\����i��ʓ��͍���)
	'           Pin_strTOKSMEKB : ���敪
	'           Pin_strTOKSMEDD : ���������t�i����j
	'           Pin_strTOKSMECC : ���T�C�N���i����j
	'           Pin_strTOKSDWKB : ���ߗj��
	'           Pin_strURIKJN   : ����
	'           Pot_strUDNYTDT  : �v�Z���ʔ���\���(yyyymmdd�̌`���j
	'   �ߒl�F  0�F����@9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetUDNYTDT(ByVal Pin_strDEFNOKDT As String, ByVal pin_strODNYTDT As String, ByVal Pin_strUDNYTDT As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKSMEDD As String, ByVal Pin_strTOKSMECC As String, ByVal Pin_strTOKSDWKB As String, ByVal pin_strURIKJN As String, ByRef Pot_strUDNYTDT As String) As Short
		
		Dim strDate As String
		Dim strDate2 As String
		Dim intRet As Short
		Dim strSMEDT As String
		
		AE_GetUDNYTDT = 9
		Pot_strUDNYTDT = ""
		
		Select Case pin_strURIKJN
			'�o�׊
			Case gc_strURIKJN_SYK
				'���t�`�F�b�N
				If IsDate(pin_strODNYTDT) = True Then
					strDate = VB6.Format(pin_strODNYTDT, "yyyymmdd")
				Else
					If IsDate(VB6.Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
						strDate = pin_strODNYTDT
					Else
						Exit Function
					End If
				End If
				
				'�c�Ɠ��擾
				intRet = DSPCLDDT_SEARCH_KDKB(strDate, "1", "1", Pot_strUDNYTDT)
				If intRet <> 0 Then
					Exit Function
				End If
				
				'������A�H�������
			Case gc_strURIKJN_KNS, gc_strURIKJN_KOJ
				'���t�`�F�b�N
				
				' === 20060726 === INSERT S - ACE)Nagasawa
				If Trim(Pin_strUDNYTDT) <> "" Then
					' === 20060726 === INSERT E -
					If IsDate(Pin_strUDNYTDT) = True Then
						strDate = VB6.Format(Pin_strUDNYTDT, "yyyymmdd")
					Else
						If IsDate(VB6.Format(Pin_strUDNYTDT, "@@@@/@@/@@")) = True Then
							strDate = Pin_strUDNYTDT
						Else
							Exit Function
						End If
					End If
					' === 20060726 === INSERT S - ACE)Nagasawa
				Else
					If IsDate(pin_strODNYTDT) = True Then
						strDate = VB6.Format(pin_strODNYTDT, "yyyymmdd")
					Else
						If IsDate(VB6.Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
							strDate = pin_strODNYTDT
						Else
							Exit Function
						End If
					End If
				End If
				' === 20060726 === INSERT E -
				
				Pot_strUDNYTDT = strDate
				
				'�𖱊����
			Case gc_strURIKJN_EKM
				' === 20060830 === UPDATE S - ACE)Nagasawa
				'            '���t�`�F�b�N
				'            If IsDate(Pin_strDEFNOKDT) = True Then
				'                strDate = Format(Pin_strDEFNOKDT, "yyyymmdd")
				'            Else
				'                If IsDate(Format(Pin_strDEFNOKDT, "@@@@/@@/@@")) = True Then
				'                    strDate = Pin_strDEFNOKDT
				'                Else
				'                    Exit Function
				'                End If
				'            End If
				'
				'            '����\������v�Z
				'            intRet = AE_GetSMEDT(strDate, _
				''                                 Pin_strTOKSMEKB, _
				''                                 Pin_strTOKSMEDD, _
				''                                 Pin_strTOKSMECC, _
				''                                 Pin_strTOKSDWKB, _
				''                                 1, _
				''                                 strDate2)
				
				'���t�`�F�b�N
				If IsDate(pin_strODNYTDT) = True Then
					strDate2 = VB6.Format(pin_strODNYTDT, "yyyymmdd")
				Else
					If IsDate(VB6.Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
						strDate2 = pin_strODNYTDT
					Else
						Exit Function
					End If
				End If
				' === 20060830 === UPDATE E -
				
				If intRet = 9 Then
					Exit Function
				End If
				
				'�c�Ɠ��擾
				intRet = DSPCLDDT_SEARCH_KDKB(strDate2, "1", "2", Pot_strUDNYTDT)
				If intRet <> 0 Then
					Exit Function
				End If
				
		End Select
		
		
		AE_GetUDNYTDT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GetKRSMADT
	'   �T�v�F  �o�������v�Z����
	'   �����F  Pin_strKJNDT    : ���
	'           Pot_strSMADT  �@: �v�Z���ʌo������(yyyymmdd�̌`���j
	'   �ߒl�F  0�F����@9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetKRSMADT(ByVal pin_strKJNDT As String, ByRef Pot_strSMADT As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Mst_Inf_SYSTBA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim intRet As Short
		
		AE_GetKRSMADT = 9
		Pot_strSMADT = ""
		
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'���[�U�[���Ǘ��e�[�u������
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			Exit Function
		End If
		
		'�o�������v�Z
		intRet = AE_GetSMEDT(pin_strKJNDT, gc_strSMEKB_DAY, Mst_Inf_SYSTBA.SMEDD, "99", "", 0, strSMEDT)
		If intRet <> 0 Then
			Exit Function
		End If
		
		Pot_strSMADT = strSMEDT
		
		AE_GetKRSMADT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_GetTanka
	'   �T�v�F  PL/SQL���s����(�P���擾����)
	'   �����F�@Pin_strHINCD  : ���i�R�[�h
	'           Pin_strTOKCD  : ���Ӑ�R�[�h
	'           Pin_strDATE   : �K�p��
	'           Pin_strTUKKB  : �ʉ݋敪
	'           Pin_lngSU     : ����
	'           Pot_curTanka  : �擾�P��
	'           Pot_curSIKRT  : �擾�d�ؗ�
	'           Pin_strJDNKB  : �󒍋敪�i"1"�C�O�@����ȊO�͋󔒁j
	'           Pot_curTEITK  : �艿
	'   �ߒl�F�@0 : ���� 9: �ُ�
	'   ���l�F  �P���擾�pPL/SQL(PRC_CMNPL90_01)�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_GetTanka(ByVal pin_strHINCD As String, ByVal pin_strTOKCD As String, ByVal pin_strDate As String, ByVal pin_strTUKKB As String, ByVal Pin_lngSU As Integer, ByRef Pot_curTANKA As Decimal, ByRef Pot_curSIKRT As Decimal, Optional ByRef Pin_strJDNKB As String = "", Optional ByRef Pot_curTEITK As Decimal = 0) As Short
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1(���i�R�[�h)
		Dim strPara2 As String '���Ұ�2(���Ӑ�R�[�h)
		Dim strPara3 As String '���Ұ�3(�K�p��)
		Dim strPara4 As String '���Ұ�4(�ʉ݋敪)
		Dim lngPara5 As Integer '���Ұ�5(����)
		Dim strPara6 As String '���Ұ�6(�󒍋敪)
		Dim lngPara7 As Integer '���Ұ�7(���A����)
		Dim lngPara8 As Integer '���Ұ�8(�װ����)
		Dim strPara9 As String '���Ұ�9(�װ���e)
		' === 20060920 === UPDATE S - ACE)Nagasawa
		'    Dim lngPara10   As Long             '���Ұ�10(�̔��P��)
		Dim lngPara10 As Decimal '���Ұ�10(�̔��P��)
		' === 20060920 === UPDATE E -
		Dim lngPara11 As Integer '���Ұ�11(�d�ؗ�)
		Dim lngPara12 As Integer '���Ұ�12(�艿)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(13) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_GetTanka = 9
		
		'��n���ϐ������ݒ�
		strPara1 = pin_strHINCD
		strPara2 = pin_strTOKCD
		strPara3 = pin_strDate
		strPara4 = pin_strTUKKB
		lngPara5 = Pin_lngSU
		strPara6 = Pin_strJDNKB
		lngPara7 = 0
		lngPara8 = 0
		strPara9 = ""
		lngPara10 = 0
		lngPara11 = 0
		lngPara12 = 0
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P12", lngPara12, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11) = gv_Odb_USR1.Parameters("P11")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(12) = gv_Odb_USR1.Parameters("P12")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(12).serverType = ORATYPE_NUMBER
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_CMNPL90_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12); End;"
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_GetTanka_END
		End If
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara7 = param(7).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara8 = param(8).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(9).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strPara9 = param(9).Value
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(10).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			lngPara10 = param(10).Value
		Else
			lngPara10 = 0
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(11).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			lngPara11 = param(11).Value
		Else
			lngPara11 = 0
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(12).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			lngPara12 = param(12).Value
		Else
			lngPara12 = 0
		End If
		
		Pot_curTANKA = CDec(lngPara10)
		Pot_curSIKRT = CDec(lngPara11)
		Pot_curTEITK = CDec(lngPara12)
		
		'�G���[���ݒ�
		gv_Int_OraErr = lngPara8
		gv_Str_OraErrText = strPara9 & vbCrLf
		
		AE_Execute_PLSQL_GetTanka = lngPara7
		
AE_Execute_PLSQL_GetTanka_END: 
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P11")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P12")
		
		
	End Function
	
	' === 20060829 === DELETE S - ACE)Nagasawa �g�p����Ă��Ȃ����ߍ폜
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F  Function AE_Get_TANKA
	''   �T�v�F  �P���A�d�ؗ��擾����
	''   �����F�@Pin_strHINCD       :���i�R�[�h
	''           Pin_strTOKCD       :���Ӑ�R�[�h
	''           Pin_strDATE        :���
	''           Pot_curSIKRT       :�d�ؗ�
	''           Pot_curTANKA       :�擾�P��
	''   �ߒl�F  0 : ����@9 : �ُ�
	''   ���l�F
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Static Function AE_Get_TANKA(ByVal pin_strHINCD As String, _
	''                                    ByVal pin_strTOKCD As String, _
	''                                    ByVal pin_strDate As String, _
	''                                    ByRef Pot_curSIKRT As Currency, _
	''                                    ByRef Pot_curTANKA As Currency) As Integer
	'
	'    Dim Mst_Inf_HINMTA      As TYPE_DB_HINMTA       '���i�}�X�^��������
	''    Dim Mst_Inf_RNKMTA      As TYPE_DB_RNKMTA       '�����N�ʎd�؂藦�}�X�^��������
	'    Dim Mst_Inf_TOKMTA      As TYPE_DB_TOKMTA       '���Ӑ�}�X�^��������
	''    Dim Mst_Inf_TRKMTA      As type_db_trkmta       '���Ӑ�ʏ��i�����N�}�X�^��������
	'
	'    AE_Get_TANKA = 9
	'
	'    Pot_curSIKRT = 100
	'    Pot_curTANKA = 0
	'
	'    '���i�}�X�^����
	'    If DSPHINCD_SEARCH(pin_strHINCD, Mst_Inf_HINMTA) <> 0 Then
	'        GoTo AE_Get_TANKA_ERR
	'    End If
	'
	'    If Mst_Inf_HINMTA.DATKB <> gc_strDATKB_USE Then
	'        GoTo AE_Get_TANKA_ERR
	'    End If
	'
	''**********************����������
	'    Pot_curSIKRT = 90
	'    Pot_curTANKA = Mst_Inf_HINMTA.ZNKURITK
	''**********************����������
	''    '���Ӑ�}�X�^����
	''    If DSPTOKCD_SEARCH(Pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    '���Ӑ�ʏ��i�����N�}�X�^����
	''    If DSPTRKRNK_SEARCH(Pin_strTOKCD, Mst_Inf_HINMTA.HINGRP, Pin_strDATE, Mst_Inf_TRKMTA) <> 0 Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    '�d�ؗ��擾
	''    If DSPRNKM_SEARCH(Mst_Inf_HINMTA.HINGRP, "", Pin_strDATE, Mst_Inf_RNKMTA) <> 0 Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    If Mst_Inf_RNKMTA.DATKB <> gc_strDATKB_USE Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    '�d�ؗ��擾
	''    Pot_curSIKRT = Mst_Inf_RNKMTA.SIKRT
	''
	''    '�P���擾
	''    Pot_curTANKA = AE_Calc_TANKA(Pot_curSIKRT, _
	'''                                 Mst_Inf_HINMTA.TEIKATK, _
	'''                                 Mst_Inf_TOKMTA.TKNRPSKB, _
	'''                                 Mst_Inf_TOKMTA.TKNZRNKB)
	'
	'    AE_Get_TANKA = 0
	'
	'    Exit Function
	'
	'AE_Get_TANKA_ERR:
	'
	'End Function
	' === 20060829 === DELETE E -
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Get_SysDt
	'//*
	'//* <�߂�l>     �^          ����
	'//*              Boolean     True:���� / False:�ُ�
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*
	'//* <��  ��>
	'//*    DB�T�[�o�[�̓��t(����)���擾����B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20041016|ACE)Moriga     |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Get_SysDt() As Boolean
		
		On Error GoTo ERR_HANDLE
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim Str_Val As String
		Dim Lng_Cnt As Integer
		Dim Lng_Idx As Integer
		Dim Str_SysDt As String
		
		CF_Get_SysDt = False
		
		'// ������
		GV_SysDate = ""
		GV_SysTime = ""
		Str_SysDt = ""
		
		Str_Sql = ""
		Str_Sql = Str_Sql & "SELECT"
		Str_Sql = Str_Sql & "       To_Char(sysdate,'YYYYMMDDHH24MISS') AAA "
		Str_Sql = Str_Sql & "FROM"
		Str_Sql = Str_Sql & "       Dual "
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo ERR_HANDLE
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Str_SysDt = Trim(CF_Ora_GetDyn(Usr_Ody, "AAA"))
		
		GV_SysDate = Mid(Str_SysDt, 1, 8)
		GV_SysTime = Mid(Str_SysDt, 9, 6)
		
		CF_Get_SysDt = True
		
EXIT_HANDLE: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Get_UnyDt
	'//*
	'//* <�߂�l>     �^          ����
	'//*              Boolean     True:���� / False:�ُ�
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*
	'//* <��  ��>
	'//*    �^�p���t(����)���擾����B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20060706|ACE)Nagasawa   |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Get_UnyDt() As Boolean
		
		Dim intRet As Short
		Dim Mst_Inf As TYPE_DB_UNYMTA
		
		CF_Get_UnyDt = False
		
		'������
		GV_UNYDate = ""
		
		'�T�[�o�[�̃V�X�e�����t�擾
		Call CF_Get_SysDt()
		
		'�^�p���t���擾
		intRet = DSPUNYDT_SEARCH(Mst_Inf)
		If intRet = 0 Then
			GV_UNYDate = Mst_Inf.UNYDT
		Else
			GV_UNYDate = GV_SysDate
		End If
		
		CF_Get_UnyDt = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_PRC_UODFP53
	'   �T�v�F  PL/SQL���s����(������������)
	'   �����F�@Pin_strPRCCASE  : �����P�[�X�i"1":�o�^ "2":���� "3": �폜�j
	'           Pin_strJDNNO    : �󒍔ԍ�
	'           Pin_strLINNO    : �s�ԍ�
	'           Pin_strSBNNO    : ����
	'           Pin_strHINCD    : ���i�R�[�h
	'           Pin_lngBFRSU    : �ύX�O�󒍐��ʁi�o�^�̏ꍇ�̓[���j
	'           Pin_lngAFTSU    : �ύX��󒍐��ʁi�폜�̏ꍇ�̓[���j
	'           Pin_strZAIRNK   : �݌Ƀ����N
	'           Pin_lngBFRSU    : �ύX�O�o�ח\����i�o�^�A�폜�̏ꍇ�͐ݒ�Ȃ��j
	'           Pin_lngAFTSU    : �ύX��o�ח\����i�o�^�A�폜�̏ꍇ�͐ݒ�Ȃ��j
	'   �ߒl�F�@0 : ����  1 : �x��  9 : �ُ�
	'   ���l�F  ������������PL/SQL(PRC_UODFP53_01)�����s����
	'           �������A�ύX�O�󒍐��ʁ��ύX��󒍐��ʂ̏ꍇ�͎��s���Ȃ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061102 === UPDATE S - ACE)Nagasawa �������������̌Ăяo�������̒ǉ�
	'Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String _
	''                                           , ByVal pin_strJDNNO As String _
	''                                           , ByVal pin_strLINNO As String _
	''                                           , ByVal pin_strSBNNO As String _
	''                                           , ByVal pin_strHINCD As String _
	''                                           , ByVal Pin_lngBFRSU As Currency _
	''                                           , ByVal Pin_lngAFTSU As Currency _
	''                                           , Optional ByVal Pin_strBFRSYK As String = "" _
	''                                           , Optional ByVal Pin_strAFTSYK As String = "") As Integer
	Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String, ByVal pin_strJDNNO As String, ByVal pin_strLINNO As String, ByVal pin_strSBNNO As String, ByVal pin_strHINCD As String, ByVal Pin_lngBFRSU As Decimal, ByVal Pin_lngAFTSU As Decimal, ByVal Pin_strZAIRNK As String, Optional ByVal Pin_strBFRSYK As String = "", Optional ByVal Pin_strAFTSYK As String = "") As Short
		' === 20061102 === UPDATE E -
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1(�S���҃R�[�h)
		Dim strPara2 As String '���Ұ�2(�N���C�A���gID)
		Dim strPara3 As String '���Ұ�3(�����P�[�X)
		Dim strPara4 As String '���Ұ�4(�󒍔ԍ�)
		Dim strPara5 As String '���Ұ�5(�s�ԍ�)
		Dim strPara6 As String '���Ұ�6(����)
		Dim strPara7 As String '���Ұ�7(���i�R�[�h)
		Dim lngPara8 As Integer '���Ұ�8(�ύX�O�󒍐���)
		Dim lngPara9 As Integer '���Ұ�9(�ύX��󒍐���)
		Dim lngPara10 As Integer '���Ұ�10(���A����)
		Dim lngPara11 As Integer '���Ұ�11(�װ����)
		Dim strPara12 As New VB6.FixedLengthString(1000) '���Ұ�12(�װ���e)
		Dim lngPara13 As Integer '���Ұ�13(�Ǎ�����)
		Dim lngPara14 As Integer '���Ұ�14(�o�^����)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(15) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		' === 20061102 === INSERT S - ACE)Nagasawa �������������̌Ăяo�������̒ǉ�
		Dim Mst_Inf As TYPE_DB_MEIMTA
		Dim bolExit As Boolean
		' === 20061102 === INSERT E -
		
		AE_Execute_PLSQL_PRC_UODFP53 = 9
		
		' === 20060824 === UPDATE S - ACE)Nagasawa �[���ύX�������������������Ăяo��
		'    '�ύX�O�󒍐��ʁ��ύX��󒍐��ʂ̏ꍇ�͏����I��
		'    If Pin_lngBFRSU = Pin_lngAFTSU Then
		'        AE_Execute_PLSQL_PRC_UODFP53 = 0
		'        Exit Function
		'    End If
		
		'�ύX�O�󒍐��ʁ��ύX��󒍐��ʁA�ύX�O�o�ח\������ύX��o�ח\����̏ꍇ�͏����I��
		If Pin_lngBFRSU = Pin_lngAFTSU And Pin_strBFRSYK = Pin_strAFTSYK Then
			AE_Execute_PLSQL_PRC_UODFP53 = 0
			Exit Function
		End If
		' === 20060824 === UPDATE E -
		
		' === 20061102 === INSERT S - ACE)Nagasawa �������������̌Ăяo�������̒ǉ�
		bolExit = True
		Call DB_MEIMTA_Clear(Mst_Inf)
		If DSPMEIM_SEARCH(gc_strKEYCD_ZAIRNK, Pin_strZAIRNK, Mst_Inf) = 0 Then
			If Mst_Inf.DATKB = gc_strDATKB_USE Then
				If Mst_Inf.MEIKBA = gc_strJDNSEISAN_OK Then
					bolExit = False
				End If
			End If
		End If
		
		'�󒍐��Y�Ώەi�ȊO�͏������s��Ȃ�
		If bolExit = True Then
			AE_Execute_PLSQL_PRC_UODFP53 = 0
			Exit Function
		End If
		' === 20061102 === INSERT E -
		
		'��n���ϐ������ݒ�
		strPara1 = SSS_OPEID.Value
		strPara2 = SSS_CLTID.Value
		strPara3 = Pin_strPRCCASE
		strPara4 = pin_strJDNNO
		strPara5 = pin_strLINNO
		strPara6 = pin_strSBNNO
		strPara7 = pin_strHINCD
		lngPara8 = Pin_lngBFRSU
		lngPara9 = Pin_lngAFTSU
		lngPara10 = 0
		lngPara11 = 0
		strPara12.Value = ""
		lngPara13 = 0
		lngPara14 = 0
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", strPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", strPara7, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P9", lngPara9, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P12", strPara12.Value, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P13", lngPara13, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P14", lngPara14, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11) = gv_Odb_USR1.Parameters("P11")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(12) = gv_Odb_USR1.Parameters("P12")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(13) = gv_Odb_USR1.Parameters("P13")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(14) = gv_Odb_USR1.Parameters("P14")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(12).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(13).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(14).serverType = ORATYPE_NUMBER
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_UODFP53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12,:P13,:P14); End;"
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_PRC_UODFP53_END
		End If
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara10 = param(10).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara11 = param(11).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(12).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strPara12.Value = param(12).Value
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara13 = param(13).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara14 = param(14).Value
		
		'�G���[���ݒ�
		gv_Int_OraErr = lngPara11
		gv_Str_OraErrText = Trim(strPara12.Value) & vbCrLf
		
		AE_Execute_PLSQL_PRC_UODFP53 = lngPara10
		
AE_Execute_PLSQL_PRC_UODFP53_END: 
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P11")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P12")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P13")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P14")
		
	End Function
	
	' === 20060828 === INSERT S - ACE)Sejima
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_TKCHGKB
	'   �T�v�F  �������擾
	'   �����F�@pin_DB_TANMTA  : �S���҃}�X�^���
	'           pin_strUnyDate : �^�p���t
	'   �ߒl�F�@�����O���[�v
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_KNG_Inf(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, ByVal pin_strUnyDate As String, ByRef Inp_Inf As Cmn_Inp_Inf) As Short
		
		Dim Mst_Inf_KNGMTA As TYPE_DB_KNGMTA
		Dim strKNGGRCD As String
		
		'������
		With Inp_Inf
			'��������A�����Ȃ��Ƃ���
			.InpTKCHGKB = gc_strTKCHGKB_NG
			.InpJDNUPDKB = gc_strJDNUPDKB_NG
		End With
		
		'�����O���[�v�擾
		strKNGGRCD = F_Get_KNGGRCD(pin_DB_TANMTA, pin_strUnyDate)
		
		If Trim(strKNGGRCD) <> "" Then
			'�����O���[�v���擾�ł����ꍇ�A�����}�X�^������
			Call DB_KNGMTA_Clear(Mst_Inf_KNGMTA)
			If KNGMTA_SEARCH(strKNGGRCD, Mst_Inf_KNGMTA) = 0 Then
				With Inp_Inf
					'�P���ύX����
					.InpTKCHGKB = Mst_Inf_KNGMTA.SALTKKB
					'�󒍍X�V����
					.InpJDNUPDKB = Mst_Inf_KNGMTA.JDNUPDKB
				End With
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_KNGGRCD
	'   �T�v�F  �����O���[�v�擾
	'   �����F�@pin_DB_TANMTA  : �S���҃}�X�^���
	'           pin_strDate    : �^�p���t
	'   �ߒl�F�@�����O���[�v
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_KNGGRCD(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, ByRef pin_strDate As String) As String
		
		Dim bolTANTKDT As Boolean '�K�p������t���O�iTrue�F�K�p�������^�p���j
		Dim intWk As Short
		Dim Ret_Value As String
		
		'������
		bolTANTKDT = False
		Ret_Value = ""
		intWk = 0
		
		With pin_DB_TANMTA
			
			'�����O���[�v�ݒ肠��
			If Trim(.KNGGRCD) <> "" Then
				intWk = intWk + mc_intCD
			End If
			
			'�������O���[�v�ݒ肠��
			If Trim(.OLDGRCD) <> "" Then
				intWk = intWk + mc_intOLDCD
			End If
			
			'�K�p���ݒ肠��
			If Trim(.TANTKDT) <> "" Then
				intWk = intWk + mc_intTKDT
				'�K�p������
				If Trim(.TANTKDT) <= pin_strDate Then
					bolTANTKDT = True
				End If
			End If
			
			'�����O���[�v�A�������O���[�v�A�K�p���̐ݒ�L���ɉ����Ĕ�����s���B
			'�i2^3��8����݁j
			Select Case intWk
				Case mc_intCD + mc_intOLDCD + mc_intTKDT
					'�@�����O���[�v�A�������O���[�v�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.KNGGRCD)
					Else
						Ret_Value = Trim(.OLDGRCD)
					End If
					
				Case mc_intCD + mc_intOLDCD
					'�A�����O���[�v�A�������O���[�v�̐ݒ肠��
					Ret_Value = Trim(.KNGGRCD)
					
				Case mc_intCD + mc_intTKDT
					'�B�����O���[�v�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.KNGGRCD)
					Else
						Ret_Value = Trim(.OLDGRCD)
					End If
					
				Case mc_intOLDCD + mc_intTKDT
					'�C�������O���[�v�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.KNGGRCD)
					Else
						Ret_Value = Trim(.OLDGRCD)
					End If
					
				Case mc_intCD
					'�D�����O���[�v�̐ݒ肠��
					Ret_Value = Trim(.KNGGRCD)
					
				Case mc_intOLDCD
					'�E�������O���[�v�̐ݒ肠��
					
				Case mc_intTKDT
					'�F�K�p���̐ݒ肠��
					
				Case Else
					'�G��������ݒ�Ȃ�
					
			End Select
			
		End With
		
		F_Get_KNGGRCD = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_TANBMNCD
	'   �T�v�F  ��������R�[�h�擾
	'   �����F�@pin_DB_TANMTA  : �S���҃}�X�^���
	'           pin_strDate : �^�p���t
	'   �ߒl�F�@��������R�[�h
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANBMNCD(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, ByRef pin_strDate As String) As String
		
		Dim bolTANTKDT As Boolean '�K�p������t���O�iTrue�F�K�p����������j
		Dim intWk As Short
		Dim Ret_Value As String
		
		'������
		bolTANTKDT = False
		Ret_Value = ""
		intWk = 0
		
		With pin_DB_TANMTA
			
			'��������R�[�h�ݒ肠��
			If Trim(.TANBMNCD) <> "" Then
				intWk = intWk + mc_intCD
			End If
			
			'����������R�[�h�ݒ肠��
			If Trim(.OLDBMNCD) <> "" Then
				intWk = intWk + mc_intOLDCD
			End If
			
			'�K�p���ݒ肠��
			If Trim(.TANTKDT) <> "" Then
				intWk = intWk + mc_intTKDT
				'�K�p������
				If Trim(.TANTKDT) <= pin_strDate Then
					bolTANTKDT = True
				End If
			End If
			
			'��������R�[�h�A����������R�[�h�A�K�p���̐ݒ�L���ɉ����Ĕ�����s���B
			'�i2^3��8����݁j
			Select Case intWk
				Case mc_intCD + mc_intOLDCD + mc_intTKDT
					'�@��������R�[�h�A����������R�[�h�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.TANBMNCD)
					Else
						Ret_Value = Trim(.OLDBMNCD)
					End If
					
				Case mc_intCD + mc_intOLDCD
					'�A��������R�[�h�A����������R�[�h�̐ݒ肠��
					Ret_Value = Trim(.TANBMNCD)
					
				Case mc_intCD + mc_intTKDT
					'�B��������R�[�h�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.TANBMNCD)
					Else
						Ret_Value = Trim(.OLDBMNCD)
					End If
					
				Case mc_intOLDCD + mc_intTKDT
					'�C����������R�[�h�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.TANBMNCD)
					Else
						Ret_Value = Trim(.OLDBMNCD)
					End If
					
				Case mc_intCD
					'�D��������R�[�h�̐ݒ肠��
					Ret_Value = Trim(.TANBMNCD)
					
				Case mc_intOLDCD
					'�E����������R�[�h�̐ݒ肠��
					
				Case mc_intTKDT
					'�F�K�p���̐ݒ肠��
					
				Case Else
					'�G��������ݒ�Ȃ�
					
			End Select
			
		End With
		
		CF_Get_TANBMNCD = Ret_Value
		
	End Function
	' === 20060828 === INSERT E
	
	' === 20060829 === INSERT S - ACE)Nagasawa �ԍ��`�[����������ꍇ�͌x����\������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_UpdateJDN_Chk
	'   �T�v�F  �󒍒����`�F�b�N
	'   �����F  pin_strKJNDT    : �������i�󒍓��j
	'           pin_strTOKCD  �@: ���Ӑ�R�[�h
	'   �ߒl�F  0�F����@1: �����������߂��@2: ���������߂��@9: �ُ�
	'   ���l�F  ���Ӑ�}�X�^.���������A���[�U�[���Ǘ��e�[�u��.����������������
	'�@�@�@�@�@ �󒍒������\���ǂ����̔��f���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_UpdateJDN_Chk(ByVal pin_strKJNDT As String, ByVal pin_strTOKCD As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Mst_Inf_SYSTBA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		Dim intRet As Short
		
		AE_UpdateJDN_Chk = 9
		
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'���[�U�[���Ǘ��e�[�u������
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			Exit Function
		End If
		
		'����ƌ����������̔�r
		If Trim(Mst_Inf_SYSTBA.UKSMEDT) <> "" Then
			If CF_Ora_Date(pin_strKJNDT) <= Mst_Inf_SYSTBA.UKSMEDT Then
				AE_UpdateJDN_Chk = 1
				Exit Function
			End If
		End If
		
		Call DB_TOKMTA_Clear(Mst_Inf_TOKMTA)
		
		' === 20061026 === DELETE S - ACE)Nagasawa �������̃`�F�b�N�͍s��Ȃ�
		'    '���Ӑ�}�X�^����
		'    If DSPTOKCD_SEARCH(pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
		'        Exit Function
		'    End If
		'
		'    '����Ɛ��������̔�r
		'    If Trim(Mst_Inf_TOKMTA.TOKSMEDT) <> "" Then
		'        If CF_Ora_Date(pin_strKJNDT) <= Mst_Inf_TOKMTA.TOKSMEDT Then
		'            AE_UpdateJDN_Chk = 2
		'            Exit Function
		'        End If
		'    End If
		' === 20061026 === DELETE E -
		
		AE_UpdateJDN_Chk = 0
		
	End Function
	' === 20060829 === INSERT E -
	
	' === 20060830 === INSERT S - ACE)Nagasawa �����̎擾�͉�ʂ̓��t����ɍs��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_INPTANCD_Inf
	'   �T�v�F  ���͒S���ҏ��擾����
	'   �����F  pin_strTANCD    : �S���҃R�[�h
	'           pot_Inp_Inf     : �擾���ʓ��͒S���ҏ��
	'           pin_strKJNDT    : �������i�ȗ����ꂽ�ꍇ�͉^�p���Ƃ���j
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function F_Get_INPTANCD_Inf(ByVal pin_strTANCD As String, ByRef pot_Inp_Inf As Cmn_Inp_Inf, Optional ByVal pin_strKJNDT As String = "") As Short
		
		Dim Mst_Inf_TANMTA As TYPE_DB_TANMTA
		Dim intRet As Short
		Dim strKJNDT As String
		' === 20061030 === INSERT S - ACE)Nagasawa �����̓ǂݕ��̕ύX
		Dim strRet As String
		' === 20061030 === INSERT E -
		
		F_Get_INPTANCD_Inf = 9
		
		'������ȗ����ꂽ�ꍇ�͉^�p�����g�p����
		If Trim(pin_strKJNDT) = "" Then
			strKJNDT = GV_UNYDate
		Else
			strKJNDT = CF_Ora_Date(pin_strKJNDT)
		End If
		
		'�S���҃}�X�^����
		Call DB_TANMTA_Clear(Mst_Inf_TANMTA)
		intRet = DSPTANCD_SEARCH(pin_strTANCD, Mst_Inf_TANMTA)
		If intRet = 0 Then
			pot_Inp_Inf.InpTanNm = Mst_Inf_TANMTA.TANNM '���͒S���Җ�
			' === 20061030 === UPDATE S - ACE)Nagasawa �����̓ǂݕ��̕ύX
			'        '�������擾�i�P���ύX�����A�󒍍X�V�����Aetc...�j
			'        Call F_Get_KNG_Inf(Mst_Inf_TANMTA, strKJNDT, pot_Inp_Inf)
			'    End If
		End If
		
		'������
		With Inp_Inf
			'��������A�����Ȃ��Ƃ���
			.InpTKCHGKB = gc_strTKCHGKB_NG '�̔��P���ύX����
			.InpJDNUPDKB = gc_strJDNUPDKB_NG '�X�V����
			.InpPRTAUTH = gc_strJDNUPDKB_NG '�������
			.InpFILEAUTH = gc_strJDNUPDKB_NG '�t�@�C���o�͌���
		End With
		
		'�����擾���W�b�N�ւ̈����Z�b�g
		gs_userid = pin_strTANCD '���͒S����ID
		gs_pgid = SSS_PrgId '�v���O����ID
		
		'�����擾
		strRet = Get_Authority(strKJNDT)
		
		'�擾���ꂽ�����Z�b�g
		With Inp_Inf
			.InpTKCHGKB = gs_SALTAUTH '�̔��P���ύX����
			.InpJDNUPDKB = gs_UPDAUTH '�X�V����
			.InpPRTAUTH = gs_PRTAUTH '�������
			.InpFILEAUTH = gs_FILEAUTH '�t�@�C���o�͌���
		End With
		' === 20061030 === UPDATE E -
		
		F_Get_INPTANCD_Inf = 0
		
	End Function
	' === 20060830 === INSERT E -
	
	' === 20060905 === INSERT S - ACE)Hashiri �ԓ`�[���쐬
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_INSERT
	'   �T�v�F  �ԓ`�[�쐬����
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMOTODATNO  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'           pin_strJODCNKB    �@: �󒍃L�����Z�����R�敪
	'           pin_strJDNDT      �@: �󒍓`�[���t(�ȗ����ꂽ�ꍇ�A�^�p��)
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �p�����[�^�̒l�����ɐԓ`�[���쐬����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061108 === UPDATE S - ACE)Nagasawa
	'Public Function AE_AKADEN_INSERT(ByVal pin_strDATNO As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJODCNKB As String) As Integer
	Public Function AE_AKADEN_INSERT(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strJODCNKB As String, Optional ByVal pin_strJDNDT As String = "") As Short
		' === 200611018 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		' === 20061119 === INSERT S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		Dim strDLFLG As String
		' === 20061119 === INSERT E -
		
		On Error GoTo AE_AKADEN_INSERT_err
		
		AE_AKADEN_INSERT = 9
		
		If Trim(pin_strJDNDT) = "" Then
			pin_strJDNDT = GV_UNYDate
		End If
		
		' === 20061119 === INSERT S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'�폜�t���O�ҏW
		strDLFLG = ""
		If Trim(pin_strJODCNKB) <> "" Then
			strDLFLG = gc_strDLFLG_DEL
		Else
			strDLFLG = gc_strDLFLG_UPD
		End If
		' === 20061119 === INSERT E -
		
		'�󒍌��o���g�����ǉ��r�p�k
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = AE_AKADEN_JDNTHA_SQL(pin_strDATNO, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID, pin_strJODCNKB)
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = AE_AKADEN_JDNTHA_SQL(pin_strDatNo, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID, pin_strJODCNKB, pin_strJDNDT)
		strSQL = AE_AKADEN_JDNTHA_SQL(pin_strDatNo, pin_strMotoDatNo, pin_strOPEID, pin_strCLTID, pin_strJODCNKB, strDLFLG, pin_strJDNDT)
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_AKADEN_INSERT_err
		End If
		
		'�󒍃g�����ǉ��r�p�k
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = AE_AKADEN_JDNTRA_SQL(pin_strDATNO, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID)
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = AE_AKADEN_JDNTRA_SQL(pin_strDatNo, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID, pin_strJDNDT)
		strSQL = AE_AKADEN_JDNTRA_SQL(pin_strDatNo, pin_strMotoDatNo, pin_strOPEID, pin_strCLTID, strDLFLG, pin_strJDNDT)
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_AKADEN_INSERT_err
		End If
		
		AE_AKADEN_INSERT = 0
		
AE_AKADEN_INSERT_err: 
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_JDNTHA_SQL
	'   �T�v�F  �ԓ`�[�쐬����_�󒍌��o���g����SQL���쐬
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMOTODATNO  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'           pin_strJODCNKB    �@: �󒍃L�����Z�����R�敪
	'           pin_strDLFLG        : �폜�t���O
	'           pin_strJDNDT        : �󒍓`�[���t
	'   �ߒl�F  SQL������
	'   ���l�F  �󒍃g����INSERT���̍쐬
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061108 === UPDATE S - ACE)Nagasawa
	'Private Function AE_AKADEN_JDNTHA_SQL(ByVal pin_strDATNO As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJODCNKB As String) As String
	' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
	'Private Function AE_AKADEN_JDNTHA_SQL(ByVal pin_strDatNo As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJODCNKB As String, _
	''                          ByVal pin_strJDNDT As String) As String
	Private Function AE_AKADEN_JDNTHA_SQL(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strJODCNKB As String, ByVal pin_strDLFLG As String, ByVal pin_strJDNDT As String) As String
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		Dim strSQL As String
		
		strSQL = ""
		strSQL = strSQL & " Insert into JDNTHA "
		strSQL = strSQL & "        ( DATNO " '�`�[�Ǘ���
		strSQL = strSQL & "        , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "        , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "        , DENKB " '�`�[�敪
		strSQL = strSQL & "        , JDNNO " '�󒍔ԍ�
		strSQL = strSQL & "        , JHDNO " '�󔭒���
		strSQL = strSQL & "        , JDNDT " '�󒍓`�[���t
		strSQL = strSQL & "        , DENDT " '�󒍓��t
		strSQL = strSQL & "        , REGDT " '����`�[���t
		strSQL = strSQL & "        , DEFNOKDT " '�[��
		strSQL = strSQL & "        , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , TOKRN " '���Ӑ旪��
		strSQL = strSQL & "        , NHSCD " '�[����R�[�h
		strSQL = strSQL & "        , NHSNMA " '�[���於�̂P
		strSQL = strSQL & "        , NHSNMB " '�[���於�̂Q
		strSQL = strSQL & "        , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "        , TANNM " '�S���Җ�
		strSQL = strSQL & "        , BUMCD " '����R�[�h
		strSQL = strSQL & "        , BUMNM " '���喼
		strSQL = strSQL & "        , TOKSEICD " '������R�[�h
		strSQL = strSQL & "        , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "        , SOUNM " '�q�ɖ�
		strSQL = strSQL & "        , ZKTKB " '����敪
		strSQL = strSQL & "        , ZKTNM " '����敪��
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , JDNENDKB " '�󒍊����敪
		strSQL = strSQL & "        , SBAUODKN " '�󒍋��z�i�{�̍��v�j
		strSQL = strSQL & "        , SBAUZEKN " '�󒍋��z�i����Ŋz�j
		strSQL = strSQL & "        , SBAUZKKN " '�󒍋��z�i�`�[�v�j
		strSQL = strSQL & "        , DENCM " '���l
		strSQL = strSQL & "        , TOKSMEKB " '���敪
		strSQL = strSQL & "        , TOKSMEDD " '���������t�i����j
		strSQL = strSQL & "        , TOKSMECC " '���T�C�N���i����j
		strSQL = strSQL & "        , TOKSDWKB " '���ߗj��
		strSQL = strSQL & "        , TOKKESCC " '����T�C�N��
		strSQL = strSQL & "        , TOKKESDD " '������t
		strSQL = strSQL & "        , TOKKDWKB " '����j��
		strSQL = strSQL & "        , LSTID " '�`�[���
		strSQL = strSQL & "        , TKNRPSKB " '���z�[����������
		strSQL = strSQL & "        , TKNZRNKB " '���z�[�������敪
		strSQL = strSQL & "        , TOKZEIKB " '����ŋ敪
		strSQL = strSQL & "        , TOKZCLKB " '����ŎZ�o�敪
		strSQL = strSQL & "        , TOKRPSKB " '����Œ[����������
		strSQL = strSQL & "        , TOKZRNKB " '����Œ[�������敪
		strSQL = strSQL & "        , TOKNMMKB " '�����ƭ�ً敪�i���j
		strSQL = strSQL & "        , NHSNMMKB " '�����ƭ�ً敪�i�[�j
		strSQL = strSQL & "        , TOKMSTKB " '�}�X�^�敪�i���Ӑ�j
		strSQL = strSQL & "        , NHSMSTKB " '�}�X�^�敪�i�[����j
		strSQL = strSQL & "        , TANMSTKB " '�}�X�^�敪�i�S���ҁj
		strSQL = strSQL & "        , MITNO " '���ϔԍ�
		strSQL = strSQL & "        , MITNOV " '�Ő�
		strSQL = strSQL & "        , AKNID " '�Č��h�c
		strSQL = strSQL & "        , CLMDL " '���ތ^��
		strSQL = strSQL & "        , URIKJN " '����
		strSQL = strSQL & "        , BINCD " '�֖��R�[�h
		strSQL = strSQL & "        , KENNMA " '�����P
		strSQL = strSQL & "        , KENNMB " '�����Q
		strSQL = strSQL & "        , BKTHKKB " '�����s�敪
		strSQL = strSQL & "        , MAEUKKB " '�O��敪
		strSQL = strSQL & "        , SEIKB " '�����敪
		strSQL = strSQL & "        , JDNTRKB " '�󒍎���敪
		strSQL = strSQL & "        , NHSADA " '�[����Z���P
		strSQL = strSQL & "        , NHSADB " '�[����Z���Q
		strSQL = strSQL & "        , NHSADC " '�[����Z���R
		strSQL = strSQL & "        , JDNINKB " '�󒍎捞���
		strSQL = strSQL & "        , DFKJDNNO " '�_�C�t�N�󒍔ԍ�
		strSQL = strSQL & "        , TOKJDNNO " '�q�撍��No.
		strSQL = strSQL & "        , HDKEIKN " '�n�[�h�_����z
		strSQL = strSQL & "        , HDSIKKN " '�n�[�h�d�؋��z
		strSQL = strSQL & "        , SFKEIKN " '�\�t�g�_����z
		strSQL = strSQL & "        , SFSIKKN " '�\�t�g�d�؋��z
		strSQL = strSQL & "        , CMPKTCD " '�R���s���[�^�^���R�[�h
		strSQL = strSQL & "        , CMPKTNM " '�R���s���[�^�^����
		strSQL = strSQL & "        , PRDTBMCD " '���Y�S������R�[�h
		strSQL = strSQL & "        , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "        , SBAFRCKN " '�O�ݎ󒍋��z�i�`�[�v�j
		strSQL = strSQL & "        , JODRSNKB " '�󒍗��R�敪
		strSQL = strSQL & "        , JODCNKB " '�󒍃L�����Z�����R�敪
		strSQL = strSQL & "        , FRNKB " '�C�O����敪
		strSQL = strSQL & "        , SIMUKE " '�d���n
		strSQL = strSQL & "        , JDNPRKB " '���s�敪
		strSQL = strSQL & "        , DENCMIN " '�Г����l
		strSQL = strSQL & "        , SETUPKB " '�Z�b�g�A�b�v�V�[�g�捞�敪
		strSQL = strSQL & "        , MOTDATNO " '���`�[�Ǘ��ԍ�
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = strSQL & "        , OPEID "           '�ŏI��Ǝ҃R�[�h
		'    strSQL = strSQL & "        , CLTID "           '�N���C�A���g�h�c
		'    strSQL = strSQL & "        , WRTTM "           '�^�C���X�^���v�i���ԁj
		'    strSQL = strSQL & "        , WRTDT "           '�^�C���X�^���v�i���t�j
		'    strSQL = strSQL & "        , WRTFSTTM "        '�^�C���X�^���v�i�o�^���ԁj
		'    strSQL = strSQL & "        , WRTFSTDT "        '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , FOPEID " '����o�^���[�U�[�h�c
		strSQL = strSQL & "        , FCLTID " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "        , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "        , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , OPEID " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "        , CLTID " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "        , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , WRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "        , UOPEID " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "        , UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "        , UWRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , UWRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "        , PGID " '�o�f�h�c
		strSQL = strSQL & "        , DLFLG " '�폜�t���O
		' === 20061119 === UPDATE E -
		strSQL = strSQL & "        , JDNENDNM " '�󒍊����敪��
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " Select "
		strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "        ,  DATKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
		strSQL = strSQL & "        ,  DENKB "
		strSQL = strSQL & "        ,  JDNNO "
		strSQL = strSQL & "        ,  JHDNO "
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  JDNDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(pin_strJDNDT) & "'"
		' === 20061108 === UPDATE E -
		strSQL = strSQL & "        ,  DENDT "
		strSQL = strSQL & "        ,  REGDT "
		strSQL = strSQL & "        ,  DEFNOKDT "
		strSQL = strSQL & "        ,  TOKCD "
		strSQL = strSQL & "        ,  TOKRN "
		strSQL = strSQL & "        ,  NHSCD "
		strSQL = strSQL & "        ,  NHSNMA "
		strSQL = strSQL & "        ,  NHSNMB "
		strSQL = strSQL & "        ,  TANCD "
		strSQL = strSQL & "        ,  TANNM "
		strSQL = strSQL & "        ,  BUMCD "
		strSQL = strSQL & "        ,  BUMNM "
		strSQL = strSQL & "        ,  TOKSEICD "
		strSQL = strSQL & "        ,  SOUCD "
		strSQL = strSQL & "        ,  SOUNM "
		strSQL = strSQL & "        ,  ZKTKB "
		strSQL = strSQL & "        ,  ZKTNM "
		strSQL = strSQL & "        ,  SMADT "
		strSQL = strSQL & "        ,  JDNENDKB "
		strSQL = strSQL & "        ,  SBAUODKN * (-1) "
		strSQL = strSQL & "        ,  SBAUZEKN * (-1) "
		strSQL = strSQL & "        ,  SBAUZKKN * (-1) "
		strSQL = strSQL & "        ,  DENCM "
		strSQL = strSQL & "        ,  TOKSMEKB "
		strSQL = strSQL & "        ,  TOKSMEDD "
		strSQL = strSQL & "        ,  TOKSMECC "
		strSQL = strSQL & "        ,  TOKSDWKB "
		strSQL = strSQL & "        ,  TOKKESCC "
		strSQL = strSQL & "        ,  TOKKESDD "
		strSQL = strSQL & "        ,  TOKKDWKB "
		strSQL = strSQL & "        ,  LSTID "
		strSQL = strSQL & "        ,  TKNRPSKB "
		strSQL = strSQL & "        ,  TKNZRNKB "
		strSQL = strSQL & "        ,  TOKZEIKB "
		strSQL = strSQL & "        ,  TOKZCLKB "
		strSQL = strSQL & "        ,  TOKRPSKB "
		strSQL = strSQL & "        ,  TOKZRNKB "
		strSQL = strSQL & "        ,  TOKNMMKB "
		strSQL = strSQL & "        ,  NHSNMMKB "
		strSQL = strSQL & "        ,  TOKMSTKB "
		strSQL = strSQL & "        ,  NHSMSTKB "
		strSQL = strSQL & "        ,  TANMSTKB "
		strSQL = strSQL & "        ,  MITNO "
		strSQL = strSQL & "        ,  MITNOV "
		strSQL = strSQL & "        ,  AKNID "
		strSQL = strSQL & "        ,  CLMDL "
		strSQL = strSQL & "        ,  URIKJN "
		strSQL = strSQL & "        ,  BINCD "
		strSQL = strSQL & "        ,  KENNMA "
		strSQL = strSQL & "        ,  KENNMB "
		strSQL = strSQL & "        ,  BKTHKKB "
		strSQL = strSQL & "        ,  MAEUKKB "
		strSQL = strSQL & "        ,  SEIKB "
		strSQL = strSQL & "        ,  JDNTRKB "
		strSQL = strSQL & "        ,  NHSADA "
		strSQL = strSQL & "        ,  NHSADB "
		strSQL = strSQL & "        ,  NHSADC "
		strSQL = strSQL & "        ,  JDNINKB "
		strSQL = strSQL & "        ,  DFKJDNNO "
		strSQL = strSQL & "        ,  TOKJDNNO "
		strSQL = strSQL & "        ,  HDKEIKN * (-1) "
		strSQL = strSQL & "        ,  HDSIKKN * (-1) "
		strSQL = strSQL & "        ,  SFKEIKN * (-1) "
		strSQL = strSQL & "        ,  SFSIKKN * (-1) "
		strSQL = strSQL & "        ,  CMPKTCD "
		strSQL = strSQL & "        ,  CMPKTNM "
		strSQL = strSQL & "        ,  PRDTBMCD "
		strSQL = strSQL & "        ,  TUKKB "
		strSQL = strSQL & "        ,  SBAFRCKN "
		strSQL = strSQL & "        ,  JODRSNKB "
		'�폜�̏ꍇ�͎󒍷�ݾً敪��ҏW
		If Trim(pin_strJODCNKB) = "" Then
			strSQL = strSQL & "        ,  JODCNKB "
		Else
			strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strDLFLG, 3) & "' "
		End If
		strSQL = strSQL & "        ,  FRNKB "
		strSQL = strSQL & "        ,  SIMUKE "
		' === 20061219 === UPDATE S - ACE)Nagasawa ���s�敪�́u�����s�v�ɖ߂�
		'    strSQL = strSQL & "        ,  JDNPRKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strHAKKB_MI, 1) & "' "
		' === 20061219 === UPDATE E -
		strSQL = strSQL & "        ,  DENCMIN "
		strSQL = strSQL & "        ,  SETUPKB "
		strSQL = strSQL & "        ,  DATNO "
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		
		' === 20061205 === UPDATE S - ACE)Nagasawa ����o�^���ڂ̍X�V�d�l�̕ύX
		'    strSQL = strSQL & "        ,  FOPEID "
		'    strSQL = strSQL & "        ,  FCLTID "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		' === 20061205 === UPDATE E -
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strDLFLG, 1) & "' "
		' === 20061119 === UPDATE E -
		strSQL = strSQL & "        ,  JDNENDNM "
		strSQL = strSQL & " From  "
		strSQL = strSQL & "     JDNTHA  "
		strSQL = strSQL & " Where  "
		strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"
		
		AE_AKADEN_JDNTHA_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_JDNTRA_SQL
	'   �T�v�F  �ԓ`�[�쐬����_�󒍃g����SQL���쐬
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMOTODATNO  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'           pin_strJODCNKB    �@: �󒍃L�����Z�����R�敪
	'           pin_strDLFLG        : �폜�t���O
	'           pin_strJDNDT        : �󒍓`�[���t
	'   �ߒl�F  SQL������
	'   ���l�F  �󒍃g����INSERT���̍쐬
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061108 === UPDATE S - ACE)Nagasawa
	'Private Function AE_AKADEN_JDNTRA_SQL(ByVal pin_strDATNO As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String) As String
	' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
	'Private Function AE_AKADEN_JDNTRA_SQL(ByVal pin_strDatNo As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJDNDT As String) As String
	Private Function AE_AKADEN_JDNTRA_SQL(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strDLFLG As String, ByVal pin_strJDNDT As String) As String
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		Dim strSQL As String
		
		strSQL = ""
		strSQL = strSQL & " Insert into JDNTRA "
		strSQL = strSQL & "        ( DATNO " '�`�[�Ǘ���
		strSQL = strSQL & "        , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "        , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "        , DENKB " '�`�[�敪
		strSQL = strSQL & "        , JDNNO " '�󒍔ԍ�
		strSQL = strSQL & "        , LINNO " '�s�ԍ�
		strSQL = strSQL & "        , RECNO " '���R�[�h�Ǘ���
		strSQL = strSQL & "        , JDNKB " '�󒍓`�[�敪
		strSQL = strSQL & "        , JHDNO " '�����ԍ�
		strSQL = strSQL & "        , JDNDT " '�󒍓`�[���t
		strSQL = strSQL & "        , DENDT " '�󒍓��t
		strSQL = strSQL & "        , DEFNOKDT " '�[��
		strSQL = strSQL & "        , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , NHSCD " '�[����R�[�h
		strSQL = strSQL & "        , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "        , BUMCD " '����R�[�h
		strSQL = strSQL & "        , TOKSEICD " '������R�[�h
		strSQL = strSQL & "        , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "        , ZKTKB " '����敪
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , HINCD " '���i�R�[�h
		strSQL = strSQL & "        , HINNMA " '�^��
		strSQL = strSQL & "        , HINNMB " '���i���P
		strSQL = strSQL & "        , UODSU " '�󒍐���
		strSQL = strSQL & "        , UNTCD " '�P�ʃR�[�h
		strSQL = strSQL & "        , UNTNM " '�P�ʖ�
		strSQL = strSQL & "        , UODTK " '�󒍒P��
		strSQL = strSQL & "        , UODKN " '�󒍋��z
		strSQL = strSQL & "        , SIKTK " '�c�Ǝd�ؒP��
		strSQL = strSQL & "        , SIKKN " '�c�Ǝd�؋��z
		strSQL = strSQL & "        , TEIKATK " '�艿
		strSQL = strSQL & "        , SIKRT " '�d�ؗ�
		strSQL = strSQL & "        , KONSIKRT " '����d�ؗ�
		strSQL = strSQL & "        , ZAIKB " '�݌ɊǗ��敪
		strSQL = strSQL & "        , LINCMA " '���ה��l�P
		strSQL = strSQL & "        , LINCMB " '���ה��l�Q
		strSQL = strSQL & "        , LSTID " '�`�[���
		strSQL = strSQL & "        , HINZEIKB " '���i����ŋ敪
		strSQL = strSQL & "        , ZEIRT " '����ŗ�
		strSQL = strSQL & "        , UZEKN " '����Ŋz
		strSQL = strSQL & "        , ZEIRNKKB " '����Ń����N
		strSQL = strSQL & "        , HINNMMKB " '�����ƭ�ً敪�i���i�j
		strSQL = strSQL & "        , MAKCD " '���[�J�[�R�[�h
		strSQL = strSQL & "        , HINKB " '���i�敪
		strSQL = strSQL & "        , HRTDD " '�������[�h�^�C��
		strSQL = strSQL & "        , ORTDD " '�o�׃��[�h�^�C��
		strSQL = strSQL & "        , TOKMSTKB " '�}�X�^�敪�i���Ӑ�j
		strSQL = strSQL & "        , NHSMSTKB " '�}�X�^�敪�i�[����j
		strSQL = strSQL & "        , TANMSTKB " '�}�X�^�敪�i�S���ҁj
		strSQL = strSQL & "        , HINMSTKB " '�}�X�^�敪�i���i�j
		strSQL = strSQL & "        , ODNYTDT " '�o�ח\���
		strSQL = strSQL & "        , UDNYTDT " '����\���
		strSQL = strSQL & "        , TNKKB " '�P�����
		strSQL = strSQL & "        , GNKCD " '�����Ǘ��R�[�h
		strSQL = strSQL & "        , CLMDL " '���ތ^��
		strSQL = strSQL & "        , HINGRP " '���i�Q
		strSQL = strSQL & "        , ATZHIKSU " '�����݌Ɉ�����
		strSQL = strSQL & "        , ATNHIKSU " '�������ɗ\�������
		strSQL = strSQL & "        , MNZHIKSU " '�蓮�݌Ɉ�����
		strSQL = strSQL & "        , MNNHIKSU " '�蓮���ɗ\�������
		strSQL = strSQL & "        , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "        , RATERT " '�בփ��[�g
		strSQL = strSQL & "        , FRCTK " '�O�ݒP��
		strSQL = strSQL & "        , FRCKN " '�O�݋��z
		strSQL = strSQL & "        , FRCTEITK " '�O�ݒ艿
		strSQL = strSQL & "        , HSTJDNNO " '�z�X�g�󒍔ԍ�
		strSQL = strSQL & "        , TOKJDNNO " '�q�撍��No.
		strSQL = strSQL & "        , TOKJDNED " '�q�撍��No.�}��
		strSQL = strSQL & "        , MAKNM " '���[�J�[��
		strSQL = strSQL & "        , SBNNO " '����
		strSQL = strSQL & "        , JDNDELDT " '�󒍎����
		strSQL = strSQL & "        , FDNDT " '�o�׎w����
		strSQL = strSQL & "        , FRDSU " '�o�׎w������
		strSQL = strSQL & "        , ODNDT " '�o�׎��ѓ�
		strSQL = strSQL & "        , OTPSU " '�o�׎��ѐ���
		strSQL = strSQL & "        , UDNDT " '�����
		strSQL = strSQL & "        , URISU " '���㐔��
		strSQL = strSQL & "        , URIKN " '������z
		strSQL = strSQL & "        , FURIKN " '�O�ݔ�����z
		strSQL = strSQL & "        , URISIKKN " '���㕪�d�؋��z
		strSQL = strSQL & "        , NYUDT " '������
		strSQL = strSQL & "        , NYUKN " '�����z
		strSQL = strSQL & "        , FNYUKN " '�O�ݓ����z
		strSQL = strSQL & "        , NYUKB " '�������
		strSQL = strSQL & "        , INVNO " '�C���{�C�X��
		strSQL = strSQL & "        , FRNMOVSU " '�C�O�q�Ɉړ���
		strSQL = strSQL & "        , TOKDNKB " '�q��`�[�w��敪
		strSQL = strSQL & "        , ZAIRNK " '�݌Ƀ����N
		strSQL = strSQL & "        , PUDLNO " '���o�ɔԍ�
		strSQL = strSQL & "        , MOTDATNO " '���`�[�Ǘ��ԍ�
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = strSQL & "        , OPEID "           '�ŏI��Ǝ҃R�[�h
		'    strSQL = strSQL & "        , CLTID "           '�N���C�A���g�h�c
		'    strSQL = strSQL & "        , WRTTM "           '�^�C���X�^���v�i���ԁj
		'    strSQL = strSQL & "        , WRTDT "           '�^�C���X�^���v�i���t�j
		'    strSQL = strSQL & "        , WRTFSTTM "        '�^�C���X�^���v�i�o�^���ԁj
		'    strSQL = strSQL & "        , WRTFSTDT "        '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , FOPEID " '����o�^���[�U�[�h�c
		strSQL = strSQL & "        , FCLTID " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "        , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "        , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , OPEID " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "        , CLTID " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "        , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , WRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "        , UOPEID " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "        , UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "        , UWRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , UWRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "        , PGID " '�o�f�h�c
		strSQL = strSQL & "        , DLFLG " '�폜�t���O
		' === 20061119 === UPDATE E -
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " Select "
		strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "        ,  DATKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
		strSQL = strSQL & "        ,  DENKB "
		strSQL = strSQL & "        ,  JDNNO "
		strSQL = strSQL & "        ,  LINNO "
		strSQL = strSQL & "        ,  RECNO "
		strSQL = strSQL & "        ,  JDNKB "
		strSQL = strSQL & "        ,  JHDNO "
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  JDNDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(pin_strJDNDT) & "'"
		' === 20061108 === UPDATE E -
		strSQL = strSQL & "        ,  DENDT "
		strSQL = strSQL & "        ,  DEFNOKDT "
		strSQL = strSQL & "        ,  TOKCD "
		strSQL = strSQL & "        ,  NHSCD "
		strSQL = strSQL & "        ,  TANCD "
		strSQL = strSQL & "        ,  BUMCD "
		strSQL = strSQL & "        ,  TOKSEICD "
		strSQL = strSQL & "        ,  SOUCD "
		strSQL = strSQL & "        ,  ZKTKB "
		strSQL = strSQL & "        ,  SMADT "
		strSQL = strSQL & "        ,  HINCD "
		strSQL = strSQL & "        ,  HINNMA "
		strSQL = strSQL & "        ,  HINNMB "
		strSQL = strSQL & "        ,  UODSU * (-1) "
		strSQL = strSQL & "        ,  UNTCD "
		strSQL = strSQL & "        ,  UNTNM "
		strSQL = strSQL & "        ,  UODTK "
		strSQL = strSQL & "        ,  UODKN * (-1) "
		strSQL = strSQL & "        ,  SIKTK "
		strSQL = strSQL & "        ,  SIKKN * (-1) "
		strSQL = strSQL & "        ,  TEIKATK "
		strSQL = strSQL & "        ,  SIKRT "
		strSQL = strSQL & "        ,  KONSIKRT "
		strSQL = strSQL & "        ,  ZAIKB "
		strSQL = strSQL & "        ,  LINCMA "
		strSQL = strSQL & "        ,  LINCMB "
		strSQL = strSQL & "        ,  LSTID "
		strSQL = strSQL & "        ,  HINZEIKB "
		strSQL = strSQL & "        ,  ZEIRT "
		strSQL = strSQL & "        ,  UZEKN * (-1) "
		strSQL = strSQL & "        ,  ZEIRNKKB "
		strSQL = strSQL & "        ,  HINNMMKB "
		strSQL = strSQL & "        ,  MAKCD "
		strSQL = strSQL & "        ,  HINKB "
		strSQL = strSQL & "        ,  HRTDD "
		strSQL = strSQL & "        ,  ORTDD "
		strSQL = strSQL & "        ,  TOKMSTKB "
		strSQL = strSQL & "        ,  NHSMSTKB "
		strSQL = strSQL & "        ,  TANMSTKB "
		strSQL = strSQL & "        ,  HINMSTKB "
		strSQL = strSQL & "        ,  ODNYTDT "
		strSQL = strSQL & "        ,  UDNYTDT "
		strSQL = strSQL & "        ,  TNKKB "
		strSQL = strSQL & "        ,  GNKCD "
		strSQL = strSQL & "        ,  CLMDL "
		strSQL = strSQL & "        ,  HINGRP "
		strSQL = strSQL & "        ,  ATZHIKSU "
		strSQL = strSQL & "        ,  ATNHIKSU "
		strSQL = strSQL & "        ,  MNZHIKSU "
		strSQL = strSQL & "        ,  MNNHIKSU "
		strSQL = strSQL & "        ,  TUKKB "
		strSQL = strSQL & "        ,  RATERT "
		strSQL = strSQL & "        ,  FRCTK "
		strSQL = strSQL & "        ,  FRCKN * (-1) "
		strSQL = strSQL & "        ,  FRCTEITK "
		strSQL = strSQL & "        ,  HSTJDNNO "
		strSQL = strSQL & "        ,  TOKJDNNO "
		strSQL = strSQL & "        ,  TOKJDNED "
		strSQL = strSQL & "        ,  MAKNM "
		strSQL = strSQL & "        ,  SBNNO "
		' === 20061223 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  JDNDELDT "
		If Trim(pin_strDLFLG) = gc_strDLFLG_DEL Then
			strSQL = strSQL & "        ,  '" & GV_UNYDate & "' "
		Else
			strSQL = strSQL & "        ,  JDNDELDT "
		End If
		' === 20061223 === UPDATE E -
		strSQL = strSQL & "        ,  FDNDT "
		strSQL = strSQL & "        ,  FRDSU "
		strSQL = strSQL & "        ,  ODNDT "
		strSQL = strSQL & "        ,  OTPSU "
		strSQL = strSQL & "        ,  UDNDT "
		strSQL = strSQL & "        ,  URISU * (-1) "
		strSQL = strSQL & "        ,  URIKN * (-1) "
		strSQL = strSQL & "        ,  FURIKN "
		strSQL = strSQL & "        ,  URISIKKN "
		strSQL = strSQL & "        ,  NYUDT "
		strSQL = strSQL & "        ,  NYUKN * (-1) "
		strSQL = strSQL & "        ,  FNYUKN "
		strSQL = strSQL & "        ,  NYUKB "
		strSQL = strSQL & "        ,  INVNO "
		strSQL = strSQL & "        ,  FRNMOVSU "
		strSQL = strSQL & "        ,  TOKDNKB "
		strSQL = strSQL & "        ,  ZAIRNK "
		strSQL = strSQL & "        ,  PUDLNO "
		strSQL = strSQL & "        ,  DATNO "
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		' === 20061205 === UPDATE S - ACE)Nagasawa ����o�^���ڂ̍X�V�d�l�̕ύX
		'    strSQL = strSQL & "        ,  FOPEID "
		'    strSQL = strSQL & "        ,  FCLTID "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		' === 20061205 === UPDATE E -
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strDLFLG, 1) & "' "
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " From  "
		strSQL = strSQL & "     JDNTRA  "
		strSQL = strSQL & " Where  "
		strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"
		
		AE_AKADEN_JDNTRA_SQL = strSQL
		
	End Function
	' === 20060905 === INSERT E -
	
	' === 20061223 === INSERT S - ACE)Nagasawa �X�֔ԍ�/�d�b�ԍ�/FAX�ԍ��̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_INSERT_JDNTHB
	'   �T�v�F  �ԓ`�[�쐬����
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMotoDatNo  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �p�����[�^�̒l�����ɐԓ`�[���쐬����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_AKADEN_INSERT_JDNTHB(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo AE_AKADEN_INSERT_JDNTHB_err
		
		AE_AKADEN_INSERT_JDNTHB = 9
		
		'�󒍔[����g�����ǉ��r�p�k
		strSQL = AE_AKADEN_JDNTHB_SQL(pin_strDatNo, pin_strMotoDatNo, pin_strOPEID, pin_strCLTID)
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_AKADEN_INSERT_JDNTHB_err
		End If
		
		AE_AKADEN_INSERT_JDNTHB = 0
		
AE_AKADEN_INSERT_JDNTHB_err: 
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_JDNTHB_SQL
	'   �T�v�F  �ԓ`�[�쐬����_�󒍔[����g����SQL���쐬
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMotoDatNo  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'   �ߒl�F  SQL������
	'   ���l�F  �󒍔[����g����INSERT���̍쐬
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_AKADEN_JDNTHB_SQL(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String) As String
		
		Dim strSQL As String
		
		strSQL = ""
		strSQL = strSQL & " Insert into JDNTHB "
		strSQL = strSQL & "        ( DATNO " '�`�[�Ǘ���
		strSQL = strSQL & "        , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "        , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "        , JDNNO " '�󒍔ԍ�
		strSQL = strSQL & "        , NHSZP " '�[����X�֔ԍ�
		strSQL = strSQL & "        , NHSTL " '�[����d�b�ԍ�
		strSQL = strSQL & "        , NHSFX " '�[����FAX�ԍ�
		strSQL = strSQL & "        , FOPEID " '����o�^���[�UID
		strSQL = strSQL & "        , FCLTID " '����o�^�N���C�A���gID
		strSQL = strSQL & "        , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "        , WRTFSTDT " '�^�C���X�^���v�i�o�^���t�j
		strSQL = strSQL & "        , OPEID " '���[�UID�i�����j
		strSQL = strSQL & "        , CLTID " '�N���C�A���gID�i�����j
		strSQL = strSQL & "        , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , WRTDT " '�^�C���X�^���v�i�������j
		strSQL = strSQL & "        , UOPEID " '���[�UID�i�o�b�`�j
		strSQL = strSQL & "        , UCLTID " '�N���C�A���gID�i�o�b�`�j
		strSQL = strSQL & "        , UWRTTM " '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "        , UWRTDT " '�^�C���X�^���v�i�o�b�`���j
		strSQL = strSQL & "        , PGID " '�X�VPGID
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " Select "
		strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "        ,  DATKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
		strSQL = strSQL & "        ,  JDNNO "
		strSQL = strSQL & "        ,  NHSZP "
		strSQL = strSQL & "        ,  NHSTL "
		strSQL = strSQL & "        ,  NHSFX "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
		strSQL = strSQL & " From  "
		strSQL = strSQL & "     JDNTHB  "
		strSQL = strSQL & " Where  "
		strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"
		
		AE_AKADEN_JDNTHB_SQL = strSQL
		
	End Function
	' === 20061223 === INSERT E -
	
	' === 20060912 === INSERT S - ACE)Sejima CRM�A�gCSV�r���Ή�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_INI_CRM
	'   �T�v�F  CRM�֘AINI�t�@�C�����擾
	'   �����F  pin_strFileName     : INI̧�ٖ���
	'           pot_strCSVFilePath�@: CSV̧���߽
	'           pot_curRetry  �@    : ��ײ��
	'           pot_curWait       �@: ��ײ�Ԋu
	'           pot_strAddMsg     �@: �ǋL�װү����
	'   �ߒl�F  0:����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_INI_CRM(ByVal pin_strFileName As String, ByRef pot_strCSVFilePath As String, ByRef pot_curRetry As Decimal, ByRef pot_curWait As Decimal) As Short
		
		Dim Ret_Value As Short
		Dim lRet As Integer
		Dim strRet As New VB6.FixedLengthString(256)
		Dim strWk As String
		Dim intRet As Short
		
		CF_Get_INI_CRM = 9
		
		'�������񐳏툵��
		Ret_Value = 0
		
		'ini�t�@�C�����A
		'�@�@CSV�Ǎ����g���C�Ԋu
		strRet.Value = ""
		' === 20061102 === UPDATE S - ACE)Nagasawa INI�t�@�C���Ǎ��ݕύX
		'    lRet = GetPrivateProfileString("CRM", "Wait", "", strRet, Len(strRet), pin_strFileName)
		'    If lRet > 0 Then
		'        If IsNumeric(strRet) = True Then
		'            'ini�t�@�C������擾�ł��āA�����l�Ƃ��Đ�����
		'            pot_curWait = LeftWid(strRet, lRet)
		'
		'        Else
		'            'ini�t�@�C������擾�ł������A���l�Ƃ��Đ������Ȃ�
		'            Ret_Value = 9
		'
		'        End If
		'
		'    Else
		'        'ini�t�@�C������擾�ł��Ȃ�
		'        Ret_Value = 9
		'
		'    End If
		
		intRet = CF_Get_IniInf("CRM", "Wait", strRet.Value)
		If intRet = 0 Then
			If IsNumeric(strRet.Value) = True Then
				'ini�t�@�C������擾�ł��āA�����l�Ƃ��Đ�����
				pot_curWait = CF_Get_CCurString(strRet.Value)
			Else
				'ini�t�@�C������擾�ł������A���l�Ƃ��Đ������Ȃ�
				Ret_Value = 9
				
			End If
			
		Else
			'ini�t�@�C������擾�ł��Ȃ�
			Ret_Value = 9
			
		End If
		' === 20061102 === UPDATE E -
		
		'�@�@�i�ǂݍ��߂Ȃ��ꍇ�� AE_CONST.bas �̌Œ�l���g�p���A�G���[�Ƃ��Ȃ��j
		If Ret_Value = 9 Then
			pot_curWait = CRM_RETRY_WAIT
			Ret_Value = 0
		End If
		
		
		'�@�ACSV�Ǎ����g���C��
		strRet.Value = ""
		' === 20061102 === UPDATE S - ACE)Nagasawa INI�t�@�C���Ǎ��ݕύX
		'    lRet = GetPrivateProfileString("CRM", "Retry", "", strRet, Len(strRet), pin_strFileName)
		'    If lRet > 0 Then
		'        If IsNumeric(strRet) = True Then
		'            'ini�t�@�C������擾�ł��āA�����l�Ƃ��Đ�����
		'            pot_curRetry = LeftWid(strRet, lRet)
		'
		'        Else
		'            'ini�t�@�C������擾�ł������A���l�Ƃ��Đ������Ȃ�
		'            Ret_Value = 9
		'
		'        End If
		'
		'    Else
		'        'ini�t�@�C������擾�ł��Ȃ�
		'        Ret_Value = 9
		'
		'    End If
		
		intRet = CF_Get_IniInf("CRM", "Retry", strRet.Value)
		If intRet = 0 Then
			If IsNumeric(strRet.Value) = True Then
				'ini�t�@�C������擾�ł��āA�����l�Ƃ��Đ�����
				pot_curRetry = CF_Get_CCurString(strRet.Value)
			Else
				'ini�t�@�C������擾�ł������A���l�Ƃ��Đ������Ȃ�
				Ret_Value = 9
				
			End If
			
		Else
			'ini�t�@�C������擾�ł��Ȃ�
			Ret_Value = 9
			
		End If
		' === 20061102 === UPDATE E -
		
		'�@�@�i�ǂݍ��߂Ȃ��ꍇ�� AE_CONST.bas �̌Œ�l���g�p���A�G���[�Ƃ��Ȃ��j
		If Ret_Value = 9 Then
			pot_curRetry = CRM_RETRY_MAX
			Ret_Value = 0
		End If
		
		
		'�@�BCSV�t�@�C���p�X
		strRet.Value = ""
		' === 20061102 === UPDATE S - ACE)Nagasawa INI�t�@�C���Ǎ��ݕύX
		'    lRet = GetPrivateProfileString("CRM", "CSVPath", "", strRet, Len(strRet), pin_strFileName)
		'    If lRet > 0 Then
		'        pot_strCSVFilePath = LeftWid(strRet, lRet)
		'    Else
		'        'ini�t�@�C������擾�ł��Ȃ�
		'        Ret_Value = 9
		'    End If
		
		'�@�BCSV�t�@�C���p�X
		intRet = CF_Get_IniInf("CRM", "CSVPath", strRet.Value)
		If intRet = 0 Then
			pot_strCSVFilePath = strRet.Value
		Else
			'ini�t�@�C������擾�ł��Ȃ�
			Ret_Value = 9
		End If
		' === 20061102 === UPDATE E -
		
		CF_Get_INI_CRM = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_OpenCRMCsv
	'   �T�v�F  CRM�֘AINI�t�@�C���I�[�v������
	'   �����F  pin_intFileNo       : �t�@�C���ԍ�
	'           pin_strCSVFilePath�@: CSV̧���߽
	'           pin_curRetry  �@    : ��ײ��
	'           pin_curWait       �@: ��ײ�Ԋu
	'   �ߒl�F  0:����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_OpenCRMCsv(ByVal pin_intFileNo As Short, ByVal pin_strCSVFilePath As String, ByVal pin_curRetry As Decimal, ByVal pin_curWait As Decimal) As Boolean
		
		Dim bolOpen As Boolean
		Dim curRetryCnt As Decimal
		Dim curRetryMax As Decimal
		
		CF_Ctl_OpenCRMCsv = False
		
		'���g���C�񐔂̏����ݒ�
		curRetryMax = pin_curRetry
		'    If curRetryMax >= 10 Then
		'        curRetryMax = 10
		'    End If
		
		curRetryCnt = 0
		bolOpen = False
		'�t�@�C�����J�����A�ő�񐔂𒴂��ă��g���C����܂Ń��[�v
		Do Until bolOpen = True Or curRetryCnt > curRetryMax
			
			System.Windows.Forms.Application.DoEvents()
			
			'�㏑���֎~�A�ǋL���[�h�ŃI�[�v��
			On Error Resume Next
			FileOpen(pin_intFileNo, pin_strCSVFilePath, OpenMode.Append, , OpenShare.LockWrite)
			Select Case Err.Number
				Case 70
					'���Ƀt�@�C�����J����Ă���ꍇ�A���g���C
					'�i���g���C�Ԋu���̎��ԁA�ꎞ��~�B�������ŏI��������j
					If curRetryCnt < curRetryMax Then
						Call Sleep(pin_curWait * 1000)
					End If
					
				Case 0
					'����ɃI�[�v��
					bolOpen = True
					
				Case Else
					
			End Select
			
			curRetryCnt = curRetryCnt + 1
			
		Loop 
		
		CF_Ctl_OpenCRMCsv = bolOpen
		
	End Function
	' === 20060912 === INSERT E
	
	' === 20061013 === INSERT S - ACE)Nagasawa �����̓��͐����ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_URIKJN_Input
	'   �T�v�F  ���͔����`�F�b�N����
	'   �����F  pin_strJDNTRKB      : �󒍎���敪
	'           pin_strURIKJN     �@: ����
	'   �ߒl�F  0:����I��(�`�F�b�N�n�j�j�@1:�`�F�b�N�m�f  9:�ُ�I��
	'   ���l�F  �󒍎���敪�����͂��ꂽ���������͉\�l���ǂ������肵�܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_URIKJN_Input(ByVal pin_strJDNTRKB As String, ByVal pin_strURIKJN As String) As Short
		
		' === 20061030 === INSERT S - ACE)Nagasawa �����̃`�F�b�N�ύX
		Dim Mst_Inf As TYPE_DB_MEIMTA
		Dim intRet As Short
		' === 20061030 === INSERT E -
		
		CF_Chk_URIKJN_Input = 9
		
		' === 20061030 === UPDATE S - ACE)Nagasawa �����̃`�F�b�N�ύX
		'    Select Case pin_strJDNTRKB
		'        '�P�i�̏ꍇ
		'        Case gc_strJDNTRKB_TAN
		'            '�o�׊�ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_SYK Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�Z�b�g�A�b�v�̏ꍇ
		'        Case gc_strJDNTRKB_SET
		'            '�o�׊�ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_SYK Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�V�X�e���̏ꍇ
		'        Case gc_strJDNTRKB_SYS
		'            '�o�׊�A������A�H��������ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_SYK _
		''            And pin_strURIKJN <> gc_strURIKJN_KNS _
		''            And pin_strURIKJN <> gc_strURIKJN_KOJ Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�C���̏ꍇ
		'        Case gc_strJDNTRKB_SYR
		'            '������ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_KNS Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�ێ�̏ꍇ
		'        Case gc_strJDNTRKB_HSY
		'            '�𖱊�����ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_EKM Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�ݏo�̏ꍇ
		'        Case gc_strJDNTRKB_KAS
		'            '����������ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_KNS Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '��L�ȊO
		'        Case Else
		'            CF_Chk_URIKJN_Input = 1
		'            Exit Function
		'
		'    End Select
		'
		'    CF_Chk_URIKJN_Input = 0
		
		Call DB_MEIMTA_Clear(Mst_Inf)
		
		'���̃}�X�^����
		CF_Chk_URIKJN_Input = 1
		intRet = DSPMEIM_SEARCH(gc_strKEYCD_URIKJN_Chk, pin_strJDNTRKB, Mst_Inf, pin_strURIKJN)
		If intRet = 0 Then
			If Mst_Inf.DATKB = gc_strDATKB_USE Then
				CF_Chk_URIKJN_Input = 0
			End If
		End If
		' === 20061030 === UPDATE E -
		
	End Function
	' === 20061013 === INSERT E -
	
	' === 20061026 === INSERT S - ACE)Nagasawa �q��`�[�w��敪�ύX
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_DspTOKDNKB
	'   �T�v�F  ��ʕ\���p�q��`�[�w��敪�擾����
	'   �����F  pin_strTOKDNKB      : �q��`�[�w��敪
	'   �ߒl�F  ��ʕ\���p�q��`�[�w��敪(vbChecked/vbUnchecked)
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_DspTOKDNKB(ByVal pin_strTOKDNKB As String) As Short
		
		If pin_strTOKDNKB = gc_strTOKDNKB_NML Then
			'"�ʏ�"�̏ꍇ�A�`�F�b�NOFF
			CF_Get_DspTOKDNKB = System.Windows.Forms.CheckState.Unchecked
		Else
			'"�ʏ�"�ȊO�̏ꍇ�A�`�F�b�NON
			CF_Get_DspTOKDNKB = System.Windows.Forms.CheckState.Checked
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_UpdTOKDNKB
	'   �T�v�F  �󒍃g�����X�V�p�q��`�[�w��敪�擾����
	'   �����F  pin_intTOKDNKB              : ��ʂ̋q��`�[�w��敪
	'   �����F  pin_strTOKDNKB_TOKMTA       : ���Ӑ�}�X�^�̋q��`�[�w��敪
	'   �ߒl�F  �󒍃g�����s�i�p�q��`�[�w��敪
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_UpdTOKDNKB(ByVal pin_intTOKDNKB As Short, ByVal pin_strTOKDNKB_TOKMTA As String) As String
		
		If pin_intTOKDNKB = System.Windows.Forms.CheckState.Unchecked Then
			'�`�F�b�NOFF�̏ꍇ�A"�ʏ�"
			CF_Get_UpdTOKDNKB = gc_strTOKDNKB_NML
		Else
			'�`�F�b�NON�̏ꍇ
			If pin_strTOKDNKB_TOKMTA = gc_strTOKDNKB_NML Then
				'���Ӑ�}�X�^�̋q��w��`�[�敪��"�ʏ�"�̏ꍇ�͎w��
				CF_Get_UpdTOKDNKB = gc_strTOKDNKB_STI
			Else
				'���Ӑ�}�X�^�̋q��`�[�w��敪�g�p
				CF_Get_UpdTOKDNKB = pin_strTOKDNKB_TOKMTA
			End If
		End If
		
	End Function
	' === 20061026 === INSERT E -
	
	' === 20061028 === INSERT S - ACE)Nagasawa FAX�ԍ��`�F�b�N�̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_FAXNO
	'   �T�v�F  FAX�ԍ��`�F�b�N����
	'   �����F  pin_strFAXNO       : �`�F�b�N�Ώ�FAX�ԍ�
	'           pin_intKETA        : FAX�ԍ����͉\����
	'           pin_intFAX_HAIHUN  : FAX�ԍ��n�C�t����
	'           pin_intFAX_LSTNUM  : FAX�ԍ��ŏI���l��������
	'           pin_strFRNKB       : �C�O����敪
	'   �ߒl�F  0 : �`�F�b�NOK   9 : �`�F�b�NNG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_FAXNO(ByVal pin_strFAXNO As String, ByVal pin_intKETA As Short, ByVal pin_intFAX_HAIHUN As Short, ByVal pin_intFAX_LSTNUM As Short, ByVal pin_strFRNKB As String) As Short
		
		Dim intHaihun As Short
		Dim intCnt As Short
		Dim intLstHaihun As Short '�Ō�̃n�C�t���ʒu
		
		CF_Chk_FAXNO = 9
		
		'�t�@�b�N�X�ԍ��̏����`�F�b�N��ǉ�
		If pin_strFRNKB <> gc_strFRNKB_FRN Then
			
			'�󔒂�OK�Ƃ���
			If Trim(pin_strFAXNO) = "" Then
				CF_Chk_FAXNO = 0
				Exit Function
			End If
			
			'�n�C�t�����擪�̏ꍇ�̓G���[
			If Mid(pin_strFAXNO, 1, 1) = "-" Then
				CF_Chk_FAXNO = 10
				Exit Function
			End If
			
			'�n�C�t�����Ō�̏ꍇ�̓G���[
			If Right(pin_strFAXNO, 1) = "-" Then
				CF_Chk_FAXNO = 30
				Exit Function
			End If
			
			'�n�C�t�����A�����đ��݂���ꍇ�G���[
			If InStr(pin_strFAXNO, "--") > 0 Then
				CF_Chk_FAXNO = 20
				Exit Function
			End If
			
			'�����`�F�b�N
			If Len(pin_strFAXNO) > pin_intKETA Then
				CF_Chk_FAXNO = 40
				Exit Function
			End If
			
			'�n�C�t�����`�F�b�N
			intHaihun = 0
			intLstHaihun = 0
			For intCnt = 1 To Len(pin_strFAXNO)
				If Mid(pin_strFAXNO, intCnt, 1) = "-" Then
					intHaihun = intHaihun + 1
					intLstHaihun = intCnt
				End If
			Next 
			
			If intHaihun <> pin_intFAX_HAIHUN Then
				CF_Chk_FAXNO = 50
				Exit Function
			End If
			
			'�ŏI���̌����`�F�b�N
			If Len(Mid(Trim(pin_strFAXNO), intLstHaihun + 1)) <> pin_intFAX_LSTNUM Then
				CF_Chk_FAXNO = 60
				Exit Function
			End If
			
		End If
		
		CF_Chk_FAXNO = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_CLMDL_FRN
	'   �T�v�F  ���ތ^���擾�����i�C�O�j
	'   �����F  pin_strJDNTRKB     : �󒍎���敪
	'           pin_strMDLCL       : ���i�}�X�^.�W�v���ށi�󒍃g����.���ތ^���j
	'           pin_strCLMDL_DSP   : ���.���ތ^��
	'   �ߒl�F  �擾���ꂽ���ތ^��
	'   ���l�F�@�󒍎���敪�ɂ��󒍃g�����ɕҏW���镪�ތ^���̒l�����肵�܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_CLMDL_FRN(ByVal pin_strJDNTRKB As String, ByVal pin_strMDLCL As String, ByVal pin_strCLMDL_DSP As String) As String
		
		Dim Rtn_Value As String
		
		CF_Get_CLMDL_FRN = ""
		Rtn_Value = ""
		
		Select Case pin_strJDNTRKB
			'�P�i
			Case gc_strJDNTRKB_TAN
				Rtn_Value = pin_strMDLCL
				
				'�Z�b�g�A�b�v
			Case gc_strJDNTRKB_SET
				
				'�V�X�e��
			Case gc_strJDNTRKB_SYS
				
				'�C��
			Case gc_strJDNTRKB_SYR
				' === 20061119 === INSERT S - ACE)Nagasawa
				'            Rtn_Value = pin_strCLMDL_DSP
				Rtn_Value = pin_strMDLCL
				' === 20061119 === INSERT E -
				
				'�ێ�
			Case gc_strJDNTRKB_HSY
				' === 20061119 === INSERT S - ACE)Nagasawa
				'            Rtn_Value = pin_strCLMDL_DSP
				Rtn_Value = pin_strMDLCL
				' === 20061119 === INSERT E -
				
				'�ݏo
			Case gc_strJDNTRKB_KAS
				Rtn_Value = pin_strMDLCL
				
			Case Else
		End Select
		
		CF_Get_CLMDL_FRN = Rtn_Value
		
	End Function
	' === 20061028 === INSERT E -
	
	' === 20061031 === INSERT S - ACE)Nagasawa �r������̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_EXCTBZ
	'   �T�v�F  PL/SQL���s����(�r�����䏈��)
	'   �����F�@Pin_strPRCCASE   : �����P�[�X(C:�`�F�b�N W:�������� D:�폜����)
	'           Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������pPL/SQL(PRC_EXCTBZ)�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, ByRef Pot_strMsg As String) As Short
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1(�S���҃R�[�h)
		Dim strPara2 As String '���Ұ�2(�N���C�A���gID)
		Dim strPara3 As String '���Ұ�3(�����P�[�X)
		Dim strPara4 As String '���Ұ�4(�Ɩ��R�[�h(PGID))
		Dim lngPara5 As Integer '���Ұ�5(���A����)
		Dim lngPara6 As Integer '���Ұ�6(�װ����)
		Dim strPara7 As String '���Ұ�7(�װ���e)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(7) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_EXCTBZ = 9
		
		'��n���ϐ������ݒ�
		strPara1 = Inp_Inf.InpTanCd
		strPara2 = SSS_CLTID.Value
		strPara3 = Pin_strPRCCASE
		strPara4 = SSS_PrgId
		lngPara5 = 0
		lngPara6 = 0
		strPara7 = ""
		
		Pot_strMsg = ""
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", lngPara6, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", strPara7, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_VARCHAR2
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_EXCTBZ(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_EXCTBZ_END
		End If
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara5 = param(5).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara6 = param(6).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(7).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strPara7 = param(7).Value
			Pot_strMsg = strPara7
		End If
		
		'�G���[���ݒ�
		gv_Int_OraErr = lngPara6
		gv_Str_OraErrText = strPara7
		
		AE_Execute_PLSQL_EXCTBZ = lngPara5
		
AE_Execute_PLSQL_EXCTBZ_END: 
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_Lock_EXCTBZ
	'   �T�v�F�@�r�����䏈��
	'   �����F�@Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������i�r���`�F�b�N���r���e�[�u���ւ̏������݁j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_Lock_EXCTBZ(ByRef Pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Chk_Lock_EXCTBZ_Err
		
		CF_Chk_Lock_EXCTBZ = 9
		Pot_strMsg = ""
		bolTrn = False
		
		'�r���`�F�b�N
		intRet = AE_Execute_PLSQL_EXCTBZ("C", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			Pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'�g�����U�N�V�����̊J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'�r������
		intRet = AE_Execute_PLSQL_EXCTBZ("W", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			Pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Chk_Lock_EXCTBZ = 0
		
		Exit Function
		
CF_Chk_Lock_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Unlock_EXCTBZ
	'   �T�v�F�@�r�������������
	'   �����F�@Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ����  9 : �ُ�
	'   ���l�F  �r������i�r���e�[�u������̍폜�j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Unlock_EXCTBZ(ByRef Pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Unlock_EXCTBZ_Err
		
		CF_Unlock_EXCTBZ = 9
		Pot_strMsg = ""
		bolTrn = False
		
		'�g�����U�N�V�����̊J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'�r���������
		intRet = AE_Execute_PLSQL_EXCTBZ("D", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			Pot_strMsg = strMsg
			CF_Unlock_EXCTBZ = intRet
			GoTo CF_Unlock_EXCTBZ_Err
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Unlock_EXCTBZ = 0
		
		Exit Function
		
CF_Unlock_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_IniInf
	'   �T�v�F  Ini�t�@�C���Ǎ��ݏ����i�v���O�����ŗL�j
	'   �����F  pin_strSection :
	'   �ߒl�F  0 : ���� 9 : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_IniInf(ByRef pin_strSection As String, ByRef pin_strKey As String, ByRef pot_strValue As String) As Short
		
		Dim Wk As New VB6.FixedLengthString(256)
		Dim lngRet As Integer
		
		CF_Get_IniInf = 9
		
		pot_strValue = ""
		
		'Ini�t�@�C���Ǎ���
		lngRet = GetPrivateProfileString(pin_strSection, pin_strKey, "", Wk.Value, Len(Wk.Value), My.Application.Info.DirectoryPath & "\" & SSS_PrgId & ".ini")
		If lngRet > 0 Then
			pot_strValue = CF_Ctr_AnsiLeftB(Wk.Value, lngRet)
			pot_strValue = Trim(pot_strValue)
		Else
			Exit Function
		End If
		
		CF_Get_IniInf = 0
		
	End Function
	' === 20061031 === INSERT E -
	
	' === 20061206 === INSERT S - ACE)Nagasawa ���i��ԃ`�F�b�N�̕ύX
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_HINCD
	'   �T�v�F  ���i�R�[�h��ԃ`�F�b�N����
	'   �����F  pm_Mst_Inf : ���i�}�X�^�p�\����
	'   �ߒl�F  0  : ����
	'           10 : �󒍒�~
	'           20 : ���Y�I��(��z�I��)
	'           30 : �o�ג�~
	'           40 : �o�׏�����
	'   ���l�F�@���͂��ꂽ���i�R�[�h�̏�Ԃ̃`�F�b�N���s���܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_HINCD(ByRef pm_Mst_Inf As TYPE_DB_HINMTA) As Short
		
		CF_Chk_HINCD = 0
		
		'�o�׏������`�F�b�N
		If pm_Mst_Inf.ORTSTPKB = gc_strORTSTPKB_PRE Then
			CF_Chk_HINCD = 40
		End If
		
		'�o�ג�~�i�`�F�b�N
		If pm_Mst_Inf.ORTSTPKB = gc_strORTSTPKB_STOP Then
			CF_Chk_HINCD = 30
		End If
		
		'���Y�I���i�`�F�b�N
		If pm_Mst_Inf.PRDENDKB = gc_strPRDENDKB_END Then
			CF_Chk_HINCD = 20
		End If
		
		'�󒍒�~�i�`�F�b�N
		If pm_Mst_Inf.JODSTPKB = gc_strJODSTPKB_STOP Then
			CF_Chk_HINCD = 10
		End If
		
	End Function
	' === 20061206 === INSERT E -
	
	' === 20061216 === INSERT S - ACE)Nagasawa ���i�R�[�h�̓��͐����ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_HINCD2
	'   �T�v�F  ���i�R�[�h���i�敪�`�F�b�N����
	'   �����F  pin_strHINKB   : ���i�敪
	'           pin_strJDNTRKB : �󒍎���敪
	'   �ߒl�F  0 : ����@9 : �G���[
	'   ���l�F�@���͂��ꂽ���i�R�[�h�̏�Ԃ̃`�F�b�N���s���܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_HINCD2(ByRef pin_strHINKB As String, ByRef pin_strJDNTRKB As String) As Short
		
		CF_Chk_HINCD2 = 9
		
		'�󒍎���敪�ɂ�蔻��
		Select Case Trim(pin_strJDNTRKB)
			'�P�i�̏ꍇ
			Case gc_strJDNTRKB_TAN
				
				'���i�敪�ɂ�蔻�f
				Select Case Trim(pin_strHINKB)
					'���i�̏ꍇ
					Case gc_strHINKB_SEIHIN
						CF_Chk_HINCD2 = 0
						'���i�̏ꍇ
					Case gc_strHINKB_SYOHIN
						CF_Chk_HINCD2 = 0
						
					Case Else
				End Select
				
				'�Z�b�g�A�b�v�̏ꍇ
			Case gc_strJDNTRKB_SET
				'�S�Ăn�j
				CF_Chk_HINCD2 = 0
				
				'�V�X�e���̏ꍇ
			Case gc_strJDNTRKB_SYS
				'�S�Ăn�j
				CF_Chk_HINCD2 = 0
				
				'�C���̏ꍇ
			Case gc_strJDNTRKB_SYR
				'�S�Ăn�j
				CF_Chk_HINCD2 = 0
				
				'�ێ�̏ꍇ
			Case gc_strJDNTRKB_HSY
				'�S�Ăn�j
				CF_Chk_HINCD2 = 0
				
				'�ݏo�̏ꍇ
			Case gc_strJDNTRKB_KAS
				'�S�Ăn�j
				CF_Chk_HINCD2 = 0
				
		End Select
		
	End Function
	' === 20061216 === INSERT E -
	
	
	' === 20061208 === INSERT S - ACE)Nagasawa �[���񓚂̔��f�͑�\��ЃR�[�h��EDI�敪����s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_EDIKBN
	'   �T�v�F  �[���񓚎��s���菈��
	'   �����F  pin_strTGRPCD   : ��\��ЃR�[�h
	'           pin_strROKCD    : ���Ӑ�R�[�h
	'   �ߒl�F  True : �[���񓚂���@False : �[���񓚂��Ȃ�
	'   ���l�F�@�[���񓚂����s���邩�ǂ����̔�����s���܂��B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_EDIKBN(ByRef pin_strTGRPCD As String, ByRef pin_strTOKCD As String) As Boolean
		
		Dim strTGRPCD As String
		Dim Mst_Inf_TOK As TYPE_DB_TOKMTA
		Dim Mst_Inf_TGRP As TYPE_DB_TOKMTA
		Dim intRet_TOK As Short
		Dim intRet_TGRP As Short
		
		CF_Chk_EDIKBN = False
		
		'��\��ЃR�[�h���Ȃ��ꍇ�͓��Ӑ�R�[�h�Ŕ���
		If Trim(pin_strTGRPCD) = "" Then
			strTGRPCD = pin_strTOKCD
		Else
			strTGRPCD = pin_strTGRPCD
		End If
		
		'�\���̃N���A
		Call DB_TOKMTA_Clear(Mst_Inf_TGRP)
		Call DB_TOKMTA_Clear(Mst_Inf_TOK)
		
		'���Ӑ�}�X�^����
		intRet_TGRP = DSPTOKCD_SEARCH(strTGRPCD, Mst_Inf_TGRP)
		intRet_TOK = DSPTOKCD_SEARCH(pin_strTOKCD, Mst_Inf_TOK)
		
		'EDI�敪��"VAN"�ŁAEDI�敪�i�[�����j��"����"�̏ꍇ�A�[���񓚏������s
		If intRet_TGRP = 0 And Mst_Inf_TGRP.DATKB = gc_strDATKB_USE Then
			If Mst_Inf_TGRP.EDIKB = gc_strEDIKB_VAN And Mst_Inf_TGRP.EDIKBN = gc_strEDIKB_OK Then
				CF_Chk_EDIKBN = True
			End If
		Else
			If intRet_TOK = 0 And Mst_Inf_TOK.DATKB = gc_strDATKB_USE Then
				If Mst_Inf_TOK.EDIKB = gc_strEDIKB_VAN And Mst_Inf_TOK.EDIKBN = gc_strEDIKB_OK Then
					CF_Chk_EDIKBN = True
				End If
			End If
		End If
		
	End Function
	' === 20061208 === INSERT E -
	
	' === 20061213 === INSERT S - ACE)Nagasawa ���ތ^���̃`�F�b�N�ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_CLMDL
	'   �T�v�F  ���ތ^���`�F�b�N����
	'   �����F  pin_strCLMDL    : �`�F�b�N�Ώۋ@�핪��
	'           pin_strJDNDT    : ����i���.�󒍓��j
	'   �ߒl�F  0 : �`�F�b�NOK�@9 : �`�F�b�NNG
	'   ���l�F�@����Ɏg�p�ł���@�핪�ނ��ǂ����𔻒肵�܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_CLMDL(ByRef pin_strCLMDL As String, ByRef pin_strJDNDT As String) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_KATA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_KATA As U_Ody
		Dim strRtn As String
		
		On Error GoTo Err_CF_Chk_CLMDL
		
		CF_Chk_CLMDL = 9
		strRtn = ""
		
		If Trim(pin_strCLMDL) = "" Or Trim(pin_strJDNDT) = "" Then
			CF_Chk_CLMDL = 0
			Exit Function
		End If
		
		'���ތ^���`�F�b�N�֐��Ăяo��
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        GET_PCODE_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
		strSQL = strSQL & "                      ,'" & CF_Ora_Sgl(pin_strJDNDT) & "') AS RTN "
		strSQL = strSQL & "   FROM DUAL "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_KATA, strSQL)
		
		'���e�擾
		If CF_Ora_EOF(Usr_Ody_KATA) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strRtn = CF_Ora_GetDyn(Usr_Ody_KATA, "RTN", "")
		End If
		
		If Trim(strRtn) <> "" Then
			CF_Chk_CLMDL = 0
		End If
		
End_CF_Chk_CLMDL: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_KATA)
		
		Exit Function
		
Err_CF_Chk_CLMDL: 
		GoTo End_CF_Chk_CLMDL
		
	End Function
	' === 20061213 === INSERT E -
	
	' === 20061217 === INSERT S - ACE)Nagasawa ��������t�@�C���̍X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Update_MainJDN
	'   �T�v�F  ��������t�@�C���X�V(���C������)
	'   �����F�@pm_strMotoDatNo  : �`�[�Ǘ��ԍ�(��)
	'           pm_strDatNo      : �`�[�Ǘ��ԍ�(�V)
	'           pm_strErrCd      : �X�V�ُ�G���[�R�[�h
	'           pm_All            : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F  �󒍗p
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_DTLTRA_Update_MainJDN(ByVal pm_strMotoDatNo As String, ByVal pm_strDATNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim intCnt As Short
		Dim intRet As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strJDNNO_NEW As String
		Dim strLINNO_NEW As String
		Dim strODNYTDT_NEW As String
		Dim strJDNNO_OLD As String
		Dim strLINNO_OLD As String
		Dim strODNYTDT_OLD As String
		
		On Error GoTo CF_DTLTRA_Update_MainJDN_Err
		CF_DTLTRA_Update_MainJDN = 9
		
		'�r�p�k�ҏW
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        NEW.JDNNO             AS JDNNO_NEW " '�󒍔ԍ��i�V�j
		strSQL = strSQL & "      , NVL(NEW.LINNO, '000') AS LINNO_NEW " '�s�ԍ��i�V�j
		strSQL = strSQL & "      , NEW.ODNYTDT           AS ODNYTDT_NEW " '�o�ח\����i�V�j
		strSQL = strSQL & "      , OLD.JDNNO             AS JDNNO_OLD " '�󒍔ԍ��i���j
		strSQL = strSQL & "      , OLD.LINNO             AS LINNO_OLD " '�s�ԍ��i���j
		strSQL = strSQL & "      , OLD.ODNYTDT           AS ODNYTDT_OLD " '�o�ח\����i���j
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        JDNTRA NEW "
		strSQL = strSQL & "      , JDNTRA OLD "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        OLD.JDNNO     = NEW.JDNNO (+) "
		strSQL = strSQL & "    AND OLD.RECNO     = NEW.RECNO (+) "
		strSQL = strSQL & "    AND OLD.DATNO     = '" & CF_Ora_String(pm_strMotoDatNo, 10) & "' "
		strSQL = strSQL & "    AND NEW.DATNO (+) = '" & CF_Ora_String(pm_strDATNO, 10) & "' "
		strSQL = strSQL & "  ORDER BY "
		strSQL = strSQL & "        LINNO_NEW ASC "
		strSQL = strSQL & "      , LINNO_OLD ASC "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		'�擾�f�[�^����������t�@�C���̍X�V���s��
		Do Until CF_Ora_EOF(Usr_Ody) = True
			'�f�[�^�擾
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strJDNNO_NEW = Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO_NEW", "")) '�󒍔ԍ��i�V�j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strLINNO_NEW = Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO_NEW", "")) '�s�ԍ��i�V�j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strODNYTDT_NEW = Trim(CF_Ora_GetDyn(Usr_Ody, "ODNYTDT_NEW", "")) '�o�ח\����i�V�j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strJDNNO_OLD = Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO_OLD", "")) '�󒍔ԍ��i���j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strLINNO_OLD = Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO_OLD", "")) '�s�ԍ��i���j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strODNYTDT_OLD = Trim(CF_Ora_GetDyn(Usr_Ody, "ODNYTDT_OLD", "")) '�o�ח\����i���j
			
			Select Case True
				'�폜���ꂽ����
				Case strLINNO_NEW = "000"
					'��������t�@�C���폜
					intRet = CF_DTLTRA_Delete(strJDNNO_OLD, "", strLINNO_OLD, pm_strErrCd, pm_All)
					
					'�o�ח\����A�܂��͍s�ԍ����ς�����ꍇ
				Case (strLINNO_NEW <> strLINNO_OLD Or strODNYTDT_NEW <> strODNYTDT_OLD)
					'��������t�@�C���X�V
					intRet = CF_DTLTRA_Update(strJDNNO_OLD, "", strLINNO_OLD, strLINNO_NEW, strODNYTDT_NEW, pm_strErrCd, pm_All)
					
				Case Else
			End Select
			
			'���f�[�^�Ǎ�
			Call CF_Ora_MoveNext(Usr_Ody)
		Loop 
		
		CF_DTLTRA_Update_MainJDN = 0
		
CF_DTLTRA_Update_MainJDN_End: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
CF_DTLTRA_Update_MainJDN_Err: 
		GoTo CF_DTLTRA_Update_MainJDN_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Update
	'   �T�v�F  ��������t�@�C���X�V����
	'   �����F�@pm_strTRANO     : �g�����ԍ�
	'           pm_strMITNOV    : �Ő�
	'           pm_strLINNO_OLD : �s�ԍ�(�X�V�O)
	'           pm_strLINNO_NEW : �s�ԍ�(�X�V��)
	'           pm_strODNYTDT   : �o�ח\���
	'           pm_strErrCd     : �X�V�ُ�G���[�R�[�h
	'  �@     �@pm_All       �@ : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_DTLTRA_Update(ByVal pm_strTRANO As String, ByVal pm_strMITNOV As String, ByVal pm_strLINNO_OLD As String, ByVal pm_strLINNO_NEW As String, ByVal pm_strODNYTDT As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Update_Err
		
		CF_DTLTRA_Update = 9
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "    SET "
		strSQL = strSQL & "        LINNO   = '" & CF_Ora_String(pm_strLINNO_NEW, 3) & "' "
		strSQL = strSQL & "      , TRADT   = '" & CF_Ora_Date(pm_strODNYTDT) & "' "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
		strSQL = strSQL & "    AND MITNOV  = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO_OLD, 3) & "' "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Update_Err
		End If
		
		CF_DTLTRA_Update = 0
		
CF_DTLTRA_Update_End: 
		Exit Function
		
CF_DTLTRA_Update_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Update")
		GoTo CF_DTLTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Delete
	'   �T�v�F  ��������t�@�C���X�V����
	'   �����F�@pm_strTRANO     : ���ϔԍ�
	'           pm_strMITNOV    : ���ϔԍ��Ő�
	'           pm_strLINNO     : �s�ԍ�(�X�V�O)
	'           pm_strErrCd     : �X�V�ُ�G���[�R�[�h
	'  �@     �@pm_All          : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_DTLTRA_Delete(ByVal pm_strTRANO As String, ByVal pm_strMITNOV As String, ByVal pm_strLINNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Delete_Err
		
		CF_DTLTRA_Delete = 9
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
		strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Delete_Err
		End If
		
		CF_DTLTRA_Delete = 0
		
CF_DTLTRA_Delete_End: 
		Exit Function
		
CF_DTLTRA_Delete_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Delete")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Update_Ins
	'   �T�v�F  ��������t�@�C���X�V����
	'   �����F�@pm_strTRANO_NEW   : �g�����ԍ�(�V)
	'  �@     �@pm_strMITNOV_NEW  : �Ő�(�V)
	'  �@     �@pm_strLINNO_NEW   : �s�ԍ�(�V)
	'  �@     �@pm_strTRADT       : �o�ח\���(�V)
	'   �@      pm_strTRANO_NEW   : �g�����ԍ�(��)
	'  �@     �@pm_strMITNOV_NEW  : �Ő�(��)
	'  �@     �@pm_strLINNO_NEW   : �s�ԍ�(��)
	'  �@     �@pm_strErrCd   �@�@: �X�V�ُ�G���[�R�[�h
	'  �@     �@pm_All        : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F  �󒍓o�^���̍X�V����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_DTLTRA_Update_Ins(ByVal pm_strTRANO_NEW As String, ByVal pm_strMITNOV_NEW As String, ByVal pm_strLINNO_NEW As String, ByVal pm_strTRADT As String, ByVal pm_strTRANO_OLD As String, ByVal pm_strMITNOV_OLD As String, ByVal pm_strLINNO_OLD As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Update_Ins_Err
		
		CF_DTLTRA_Update_Ins = 9
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "    SET "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO_NEW, 20) & "' "
		strSQL = strSQL & "      , MITNOV  = '" & CF_Ora_String(pm_strMITNOV_NEW, 2) & "' "
		strSQL = strSQL & "      , LINNO   = '" & CF_Ora_String(pm_strLINNO_NEW, 3) & "' "
		strSQL = strSQL & "      , TRADT   = '" & CF_Ora_Date(pm_strTRADT) & "' "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO_OLD, 20) & "' "
		strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV_OLD, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO_OLD, 3) & "' "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Update_Ins_Err
		End If
		
		CF_DTLTRA_Update_Ins = 0
		
CF_DTLTRA_Update_Ins_End: 
		Exit Function
		
CF_DTLTRA_Update_Ins_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Update_Ins")
		GoTo CF_DTLTRA_Update_Ins_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Delete_Ins
	'   �T�v�F  ��������t�@�C���폜����
	'   �����F  pm_strTRANO   : �g�����ԍ�
	'  �@     �@pm_strMITNOV  : �Ő�
	'  �@     �@pm_strLINNO   : �s�ԍ�
	'  �@     �@pm_strErrCd   : �X�V�ُ�G���[�R�[�h
	'  �@     �@pm_All        : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F  �󒍓o�^���̍폜����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_DTLTRA_Delete_Ins(ByVal pm_strTRANO As String, ByVal pm_strMITNOV As String, ByVal pm_strLINNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Delete_Ins_Err
		
		CF_DTLTRA_Delete_Ins = 9
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
		strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Delete_Ins_Err
		End If
		
		CF_DTLTRA_Delete_Ins = 0
		
CF_DTLTRA_Delete_Ins_End: 
		Exit Function
		
CF_DTLTRA_Delete_Ins_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Delete_Ins")
		
	End Function
	' === 20061217 === INSERT E -
	
	' === 20061217 === INSERT S - ACE)Nagasawa
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_TNADL53
	'   �T�v�F  ����݌ɏƉ�pPL/SQL���s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�߂�l
	'   ���l�F  PL/SQL�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_TNADL53(ByRef pin_strHINCD As String, ByRef pin_strSOUCD As String, ByRef pin_curRELZAISU As Decimal) As Short
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1
		Dim strPara2 As String '���Ұ�2
		Dim strPara3 As String '���Ұ�3
		Dim strPara4 As String '���Ұ�4
		Dim lngPara5 As Integer '���Ұ�5
		Dim strPara6 As String '���Ұ�6
		Dim lngPara7 As Integer '���Ұ�7
		Dim lngPara8 As Integer '���Ұ�8
		Dim strPara9 As String '���Ұ�9
		Dim lngPara10 As Integer '���Ұ�10
		Dim lngPara11 As Integer '���Ұ�11
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(12) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		
		'��n���ϐ������ݒ�
		strPara1 = Inp_Inf.InpTanCd '���͒S���҃R�[�h
		strPara2 = Inp_Inf.InpCLIID '�N���C�A���gID
		strPara3 = CF_Ora_String(pin_strHINCD, 10) '���i�R�[�h
		strPara4 = CF_Ora_String(pin_strSOUCD, 3) '�q�ɃR�[�h
		lngPara5 = pin_curRELZAISU '���ݍ݌ɐ�
		strPara6 = CF_Ora_String(SSS_PrgId, 10)
		lngPara7 = 0
		lngPara8 = 0
		strPara9 = ""
		lngPara10 = 0
		lngPara10 = 0
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11) = gv_Odb_USR1.Parameters("P11")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11).serverType = ORATYPE_NUMBER
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_TNADL53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11); End;"
		
		'DB�A�N�Z�X
		Call CF_Ora_Execute(gv_Odb_USR1, strSQL)
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara7 = param(7).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara8 = param(8).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strPara9 = param(9).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara10 = param(10).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara11 = param(11).Value
		
		'�߂�l�ݒ�
		AE_Execute_PLSQL_TNADL53 = lngPara7
		
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P11")
		
	End Function
	' === 20061217 === INSERT E -
	
	' === 20061219 === INSERT S - ACE)Nagasawa �݌ɐ��`�F�b�N�̕ύX
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_INPSU_ZAISU
	'   �T�v�F  �݌ɐ��`�F�b�N����
	'   �����F  pm_strHINCD    : ���i�R�[�h
	'  �@     �@pm_curUODSU    : �`�F�b�N�Ώې���(�o�׎��ѐ��{�o�׎w������ϲŽ���Ă���)
	'  �@     �@pm_strJDNINKB  : �󒍎捞���
	'  �@     �@pm_All         : ��ʏ��
	'           pm_strTHNSOUCD : �ʔ̑q�ɃR�[�h
	'   �ߒl�F�@0:����OK 1:���݌�����NG 2:�L���݌�����NG 3:���S�݌�����NG 9:�ُ�
	'   ���l�F�@�`�F�b�N�Ώې��ʂɑ΂��āA�݌ɂ�����Ă��邩���`�F�b�N����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_INPSU_ZAISU(ByVal pm_strHINCD As String, ByVal pm_curCHKSU As Decimal, ByVal pm_strJDNINKB As String, ByRef pm_All As Cls_All, Optional ByVal pm_strTHNSOUCD As String = "") As Short
		
		Dim strSQL As String
		Dim strSOUCD As String
		Dim bolRet As Boolean
		Dim Mst_Inf_HINMTA As TYPE_DB_HINMTA
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim curRELZAISU As Decimal
		Dim curHIKSU As Decimal
		Dim bolDyn_Open As Boolean
		
		On Error GoTo CF_Chk_INPSU_ZAISU_Err
		
		CF_Chk_INPSU_ZAISU = 9
		
		curRELZAISU = 0
		curHIKSU = 0
		bolDyn_Open = False
		
		If Trim(pm_strHINCD) = "" Then
			CF_Chk_INPSU_ZAISU = 0
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'���i�R�[�h��菤�i�}�X�^����
		Call DB_HINMTA_Clear(Mst_Inf_HINMTA)
		If DSPHINCD_SEARCH(pm_strHINCD, Mst_Inf_HINMTA) = 9 Then
			Exit Function
		End If
		
		'�݌ɊǗ����Ȃ����̂̓`�F�b�N���Ȃ�
		If Mst_Inf_HINMTA.ZAIKB = gc_strZAIKB_NG Then
			CF_Chk_INPSU_ZAISU = 0
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'�q�ɃR�[�h����
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			strSOUCD = Trim(pm_strTHNSOUCD)
		Else
			strSOUCD = Trim(Mst_Inf_HINMTA.TNACM)
		End If
		
		'�q�ɕʍ݌Ƀ}�X�^����
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        RELZAISU "
		strSQL = strSQL & "      , HIKSU "
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        HINMTB "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        SOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
		strSQL = strSQL & "    AND HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		
		'SQL���s
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		bolDyn_Open = True
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curRELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curHIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0)
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		bolDyn_Open = False
		
		'���݌Ƀ`�F�b�N
		If (curRELZAISU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU = 1
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'�L���݌Ƀ`�F�b�N
		If (curRELZAISU - curHIKSU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU = 2
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'�ʔ͈̂��S�݌ɐ��`�F�b�N�͍s��Ȃ�
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			CF_Chk_INPSU_ZAISU = 0
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'���S�݌ɐ��`�F�b�N
		If ((curRELZAISU) - curHIKSU - pm_curCHKSU) - Mst_Inf_HINMTA.ANZZAISU < 0 Then
			CF_Chk_INPSU_ZAISU = 3
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		CF_Chk_INPSU_ZAISU = 0
		
CF_Chk_INPSU_ZAISU_End: 
		
		If bolDyn_Open = True Then
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
		End If
		
		Exit Function
		
CF_Chk_INPSU_ZAISU_Err: 
		GoTo CF_Chk_INPSU_ZAISU_End
		
	End Function
	' === 20061219 === INSERT E -
	
	' === 20061223 === INSERT S - ACE)Nagasawa �X�֔ԍ�/�d�b�ԍ�/FAX�ԍ��̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_ZIPCD
	'   �T�v�F  �X�֔ԍ��`�F�b�N����
	'   �����F  pin_strZIPCD            : �`�F�b�N�ΏۗX�֔ԍ�
	'           pin_intKETA             : �X�֔ԍ����͉\����
	'           pin_intZIP_HAIHUN       : �n�C�t���ʒu�i�����j
	'           pin_strFRNKB            : �C�O����敪
	'   �ߒl�F  0 : �`�F�b�NOK   9 : �`�F�b�NNG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_ZIPCD(ByVal pin_strZIPCD As String, ByVal pin_intKETA As Short, ByVal pin_intZIP_HAIHUN As Short, ByVal pin_strFRNKB As String) As Short
		
		Dim intHaihun As Short
		Dim intCnt As Short
		Dim intLstHaihun As Short '�Ō�̃n�C�t���ʒu
		
		CF_Chk_ZIPCD = 9
		
		'����悪�����̏ꍇ�̂݃`�F�b�N���s��
		If pin_strFRNKB <> gc_strFRNKB_FRN Then
			
			'�󔒂�OK�Ƃ���
			If Trim(pin_strZIPCD) = "" Then
				CF_Chk_ZIPCD = 0
				Exit Function
			End If
			
			'�����`�F�b�N
			If Len(pin_strZIPCD) <> pin_intKETA Then
				CF_Chk_ZIPCD = 10
				Exit Function
			End If
			
			'�n�C�t���ʒu�`�F�b�N
			For intCnt = 1 To pin_intKETA
				If intCnt = pin_intZIP_HAIHUN Then
					If MidWid(pin_strZIPCD, intCnt, 1) <> "-" Then
						CF_Chk_ZIPCD = 20
						Exit Function
					End If
				Else
					If IsNumeric(MidWid(pin_strZIPCD, intCnt, 1)) = False Then
						CF_Chk_ZIPCD = 20
						Exit Function
					End If
				End If
			Next 
		End If
		
		CF_Chk_ZIPCD = 0
		
	End Function
	' === 20061223 === INSERT E -
End Module