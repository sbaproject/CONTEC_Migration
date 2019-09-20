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
	'   Public�萔
	'************************************************************************************
	Public Structure Cmn_Inp_Inf
		Dim InpTanCd As String '���͒S���҂h�c
		Dim InpTanNm As String '���͒S���Җ�
		Dim InpTKCHGKB As String '�P���ύX����
		Dim InpCLIID As String '�N���C�A���g�h�c
	End Structure
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
	
	'************************************************************************************
	'   Private�ϐ�
	'************************************************************************************
	Dim strINIDATNM(4) As String '�h�m�h�̃V���{��
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Init
	'   �T�v�F  �v���O�����N������������
	'   �����F  �Ȃ�
	'   �ߒl�F  �Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub CF_Init()
		
		'''    Dim datDT           As Date
		'''    Dim DB_TANMTA       As TYPE_DB_TANMTA
		'''    Dim strYMD          As String
		'''    Dim strUNYDT        As String
		'''    Dim intLenCommand   As String
		'''    Dim intRet          As Integer
		'''
		'''    '��d�N������
		'''    If App.PrevInstance Then
		'''        MsgBox "�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", vbExclamation Or vbOKOnly, SSS_PrgNm
		'''        End
		'''    End If
		'''
		'''    ' "���΂炭���҂���������" �E�B���h�E�\��
		''''    Load ICN_ICON
		'''
		''''   ���t�`���`�F�b�N
		'''    datDT = Date
		'''    strYMD = Format(Year(datDT), "0000") & "/" & Format(Month(datDT), "00") & "/" & Format(Day(datDT), "00")
		'''
		'''    If CStr(datDT) <> strYMD Then
		'''        MsgBox "���t�̌`�� '" & CStr(datDT) & "' ���Ⴂ�܂��B" & vbCrLf _
		''''             & "�R���g���[���p�l���̒n��i�n���̊G�j�̓��t" & vbCrLf _
		''''             & "�̒Z���`���� yyyy/MM/dd �ɕύX���ĉ������B", vbCritical
		'''        Call Error_Exit("���t�̌`�����Ⴂ�܂��B")
		'''    End If
		'''
		'''    '---------------------
		'''    ' �N���p�����[�^�ݒ�
		'''    '---------------------
		'''    intLenCommand = LenWid(Trim$(Command$))
		''''    If intLenCommand < 15 Then
		''''        MsgBox "���j���[������s���Ă��������B", vbOKOnly, SSS_PrgNm
		''''        Call Error_Exit("���j���[������s���Ă��������B")
		''''    End If
		'''
		'''    SSS_CLTID = MidWid$(Command$, 2, 5)
		'''    SSS_OPEID = MidWid$(Command$, 7, 8)
		'''    SSS_OPEID = "000001"                            'TEST
		'''    '���[�h�I�����[���[�h�ݒ�
		'''    If Left$(Command$, 1) = "'" Then SSS_ReadOnly = True
		'''
		'''    '���͒S���Җ��擾
		'''    FR_SSSMAIN.HD_TANCD.Text = SSS_OPEID
		'''    If DSPTANCD_SEARCH(SSS_OPEID, DB_TANMTA) = 0 Then
		'''        FR_SSSMAIN.HD_TANNM.Text = DB_TANMTA.TANNM             '���͒S���Җ�
		'''      Else
		'''        FR_SSSMAIN.HD_TANNM.Text = "XXXXX"
		'''    End If
		'''
		'''    '---------------------
		'''    ' SSSWIN.INI �e�[�u���ݒ�
		'''    '---------------------
		'''    strINIDATNM(0) = "USR_PATH"
		'''    strINIDATNM(1) = "DAT_PATH"
		'''    strINIDATNM(2) = "PRG_PATH"
		'''    strINIDATNM(3) = "WRK_PATH"
		'''    strINIDATNM(4) = "IMG_PATH"
		'''    SSS_INICnt = 4
		'''    'Ini�t�@�C���Ǎ���
		'''    Call CF_INIT_GETINI
		'''
		'''    '�^�p���t�擾
		'''    Call CF_Get_UnyDt
		'''
		'''    ' "���΂炭���҂���������" �E�B���h�E����
		''''    Unload ICN_ICON
		
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
	'   ���́F  Function CF_Get_TANNM
	'   �T�v�F  �S���Җ��̎擾
	'   �����F�@pm_Def_LineNo
	'           pm_HIKET51_DSP_DATA    :��ʋƖ����\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANNM(ByRef pm_TANCD As String) As String
		
		'''    Dim Ret_Value        As String
		'''    Dim DB_TANMTA        As TYPE_DB_TANMTA
		'''    Dim intRet           As Integer
		'''
		'''    Ret_Value = ""
		'''
		'''    '�S���҃}�X�^����
		'''    Call DB_TANMTA_Clear(DB_TANMTA)
		'''    intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
		'''    If intRet = 0 Then
		'''        Ret_Value = DB_TANMTA.TANNM
		'''    End If
		'''
		'''    CF_Get_TANNM = Ret_Value
		
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
		strSQL = strSQL & "    for Update NoWait "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
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
		'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Edit �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		usrOdy.Obj_Ody.Edit()
		'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		usrOdy.Obj_Ody.Fields("DATNO").Value = pot_strDatNo(UBound(pot_strDatNo))
		If UBound(Pot_strRECNO) > 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("RECNO").Value = Pot_strRECNO(UBound(Pot_strRECNO))
		End If
		If Trim(GV_SysTime) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
		End If
		If Trim(GV_SysDate) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		usrOdy.Obj_Ody.Update()
		
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
		
		If gv_Int_OraErr = 54 Then
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
		Static intRet As Short
		
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
				
				
				'���ϔԍ��̔ԏ���
				intRet = F_SYSTBC_Update(Pin_strADDDENCD, Pot_strDENNO)
				If intRet <> 0 Then
					AE_SYSTBCSaiban = intRet
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
				'�󒍔ԍ��̍̔�
			Case gc_strDKBSB_UOD
				'�̔ԃ}�X�^�擾
				strSQL = ""
				strSQL = strSQL & " Select *             "
				strSQL = strSQL & "   from SAIMTA        "
				strSQL = strSQL & "  Where SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
				strSQL = strSQL & "    for Update NoWait "
				
				'SQL���s
				bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
				'EOF����
				If CF_Ora_EOF(usrOdy) = True Then
					Pot_strDENNO = "00001"
					'���[�U�[�`�[No�e�[�u���ǉ�
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.AddNew �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.AddNew()
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Fields("SDKBSB").Value = gc_strSDKBSB_UOD '�`�[���
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Fields("FIXCD").Value = "R" '�Œ�l
					strFixCd = "R"
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO '�A��
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Fields("SAIKBA").Value = Space(1) '�敪�P
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Fields("SAIKBB").Value = Space(1) '�敪�Q
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Fields("SAIKBC").Value = Space(1) '�敪�R
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '�ŏI��ƎҺ���
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value '�N���C�A���gID
					If Trim(GV_SysTime) <> "" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime '�^�C���X�^���v�i���ԁj
						'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
					End If
					If Trim(GV_SysDate) <> "" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate '�^�C���X�^���v�i���t�j
						'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate '�^�C���X�^���v�i�o�^���t�j
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Update()
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
					
					If strDenNo = "00000" Then
						strDenNo = "00001"
					End If
					
					Pot_strDENNO = strDenNo
					
					'���[�U�[�`�[No�e�[�u���X�V
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Edit �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Edit()
					'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO '�`�[No
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
					Case gc_strJDNTRKB_TAN '�P�i
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_SET '�Z�b�g�A�b�v
						Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_SYS '�V�X�e��
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_SYR '�C��
						Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_HSY '�ێ�
						Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_KAS '�ݏo
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_ELS '���̑�
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case Else
				End Select
			Case Else
				
		End Select
		
		AE_SYSTBCSaiban = 0
		
EXIT_AE_SYSTBCSaiban: 
		Exit Function
		
ERR_AE_SYSTBCSaiban: 
		
		If gv_Int_OraErr = 54 Then
			'���Ŏg�p��
			AE_SYSTBCSaiban = 2
		End If
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban
		
	End Function
	
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
		strSQL = strSQL & "    for Update NoWait "
		
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
		
		If gv_Int_OraErr = 54 Then
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
	'   �����F�@Pm_strPUDLNO()  :���o�ɔԍ�
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBCSaiban_PUDLNO(ByRef Pm_strPUDLNO() As String) As Short
		
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
		
		On Error GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		
		AE_SYSTBCSaiban_PUDLNO = 9
		
		bolTran = False
		
		'�g�����U�N�V�����J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'���[�U�[�`�[���e�[�u���擾
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_PUDL & "' "
		strSQL = strSQL & "    for Update NoWait "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
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
		
		For intCnt = 1 To UBound(Pm_strPUDLNO)
			Pm_strPUDLNO(intCnt) = strADDDENCD & VB6.Format(curDENNO, New String("0", 8))
			curDENNO = curDENNO + 1
			If curDENNO > curENDNO Then
				'�I���`�[No�𒴂����ꍇ�͖߂�
				curDENNO = curSTTNO
			End If
		Next intCnt
		
		'���[�U�[�`�[���e�[�u���X�V
		'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Edit �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		usrOdy.Obj_Ody.Edit()
		'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		usrOdy.Obj_Ody.Fields("DENNO").Value = Right(Pm_strPUDLNO(UBound(Pm_strPUDLNO)), 8)
		If Trim(GV_SysTime) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
		End If
		If Trim(GV_SysDate) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		usrOdy.Obj_Ody.Update()
		
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
		
		If gv_Int_OraErr = 54 Then
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
		
		Select Case pin_strJDNNO
			Case "9"
				pot_strRtn = "A"
				Exit Function
				
			Case "Z"
				pot_strRtn = "0"
				JDNNO_CntUp = True
				Exit Function
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
	Public Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, ByVal Pin_curZEIRT As Decimal, ByVal Pin_curTANKA As Decimal, ByVal Pin_curSURYO As Decimal, ByVal Pin_strTOKZEIKB As String, ByVal Pin_strTOKRPSKB As String, ByVal Pin_strTOKZRNKB As String, ByRef Pot_curUZEKN As Decimal) As Short
		
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
						curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
						Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
						Pot_curUZEKN = curZeigk
						
						'��ې�
					Case gc_strTOKZEIKB_HIK
				End Select
				
				'�Ŕ���,�ō���
			Case gc_strHINZEIKB_KOM, gc_strHINZEIKB_NUK
				curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
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
	Public Sub AE_CalcRoundKingk(ByRef Pio_curKingk As Decimal, ByVal Pin_strRPSKB As String, ByVal Pin_strZRNKB As String)
		
		Dim curKingk As Decimal
		Dim curKingk_wk As Decimal
		
		curKingk = 0
		
		Select Case Pin_strRPSKB '���z�[����������
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
		
		Select Case Pin_strZRNKB '���z�[�������敪
			'�؎̂�
			Case gc_strTOKZRNKB_DWN
				curKingk = Fix(curKingk)
				'�l�̌ܓ�
			Case gc_strTOKZRNKB_RND
				curKingk = System.Math.Round(curKingk)
				'�؂�グ
			Case gc_strTOKZRNKB_UP
				curKingk_wk = Fix(curKingk)
				If curKingk_wk < curKingk Then
					curKingk = curKingk_wk + 1
				Else
					curKingk = curKingk_wk
				End If
		End Select
		
		Select Case Pin_strRPSKB '���z�[����������
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
		Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D1, strZRNKB)
		
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
		Call AE_CalcRoundKingk(curBSART, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
		
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
	'Public Function AE_CalcDateAdd(ByRef Pio_strDate As String, _
	''                               ByVal Pin_intAddDate As Integer, _
	''                               Optional ByVal Pin_strKind As String = "0") As Integer
	'
	'    Dim strDate         As String
	'    Dim Mst_Inf         As TYPE_DB_CLDMTA
	'    Dim intAddDate      As Integer              '���t�v�Z�p
	'
	'    AE_CalcDateAdd = 9
	'
	'    strDate = ""
	'
	'    '���t�������`�F�b�N
	'    If IsDate(Pio_strDate) = True Then
	'        strDate = Pio_strDate
	'    End If
	'
	'    '���t�l���ɕϊ�
	'    If IsDate(Format(Pio_strDate, "@@@@/@@/@@")) = True Then
	'        strDate = Format(Pio_strDate, "@@@@/@@/@@")
	'    End If
	'
	'    If Trim(strDate) = "" Then
	'        Exit Function
	'    End If
	'
	'    '���t���Z
	'    strDate = DateAdd("d", Pin_intAddDate, strDate)
	'
	'    '�J�����_�}�X�^����
	'    If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
	'        Exit Function
	'    End If
	'
	'    If Pin_intAddDate >= 0 Then
	'        intAddDate = 1
	'    Else
	'        intAddDate = -1
	'    End If
	'
	'    Select Case Pin_strKind
	'        '�c�Ɠ��v�Z
	'        Case "1"
	'            Do Until Mst_Inf.SLDKB = "1"
	'                strDate = DateAdd("d", intAddDate, strDate)
	'                '�J�����_�}�X�^����
	'                If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
	'                    Exit Function
	'                End If
	'            Loop
	'
	'        '��s�ғ����v�Z
	'        Case "2"
	'            Do Until Mst_Inf.BNKKDKB = "1"
	'                strDate = DateAdd("d", intAddDate, strDate)
	'                '�J�����_�}�X�^����
	'                If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
	'                    Exit Function
	'                End If
	'            Loop
	'
	'        '�����ғ����v�Z
	'        Case "3"
	'            Do Until Mst_Inf.DTBKDKB = "1"
	'                strDate = DateAdd("d", intAddDate, strDate)
	'                '�J�����_�}�X�^����
	'                If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
	'                    Exit Function
	'                End If
	'            Loop
	'
	'        Case Else
	'
	'    End Select
	'
	'    Pio_strDate = strDate
	'    AE_CalcDateAdd = 0
	'
	'End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CmnMsgLibrary
	'   �T�v�F  �W�����b�Z�[�W�\������
	'   �����F  Pin_strPgNm     : �v���O������
	'           Pin_strMsgCode  : ���b�Z�[�W�R�[�h�iDB�����p�j
	'           pm_All  �@�@�@  : ��ʏ��
	'           pin_strMsg      : �ǉ����b�Z�[�W
	'   �ߒl�F  �I���{�^��
	'   ���l�F  �A�v���̎��s���ɏo�͂����W�����b�Z�[�W�B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, ByRef pm_All As Cls_All, Optional ByVal pin_strMsg As String = "") As Short
		
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
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
		'UPGRADE_WARNING: AE_CmnMsgLibrary �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
		If intRet <> 0 Then
			'UPGRADE_WARNING: AE_CmnMsgLibrary �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
			If intRet <> 0 Then
				Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				Exit Function
			End If
		End If
		
		'�ǉ����b�Z�[�W�̕ҏW
		strMsg_add = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGSQ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Mst_Inf.MSGSQ = "9" Then
			'�c�a�A�N�Z�X�n�G���[�Ƃ���
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "�����ӏ�   : " & pin_strMsg
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		'Windows�ɐ����߂�
		System.Windows.Forms.Application.DoEvents()
		
		'���b�Z�[�W�\��
		'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.BTNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.ICNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				
				'OK/�L�����Z��
			Case gc_strBTNKB_OKCancel
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.BTNON �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.ICNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'���~/�Ď��s/����
			Case gc_strBTNKB_AbortRetryIgnore
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.BTNON �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.ICNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������/�L�����Z��
			Case gc_strBTNKB_YesNoCancel
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.BTNON �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.ICNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������
			Case gc_strBTNKB_YesNo
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.BTNON �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.ICNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�Ď��s/�L�����Z��
			Case gc_strBTNKB_RetryCancel
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.ICNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				
			Case Else
				
		End Select
		
	End Function
	
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
		Dim cnt As Short
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
			cnt = Int(30 / intTOKSMECC) '���񐔁^��
			setidx = False
			For I = 0 To cnt - 1
				smeday(I) = intTOKSMEDD + intTOKSMECC * I
				If smeday(I) > 27 Then smeday(I) = 99
				If dd <= smeday(I) And setidx = False Then
					idx = I + Pin_intCHTNKB '�Y�����t�̒����z��Y��
					setidx = True
				End If
			Next I
			If setidx = False Then idx = cnt + Pin_intCHTNKB
			addMM = Int(idx / cnt)
			idx = idx Mod cnt
			If idx < 0 Then idx = idx + cnt
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
	''''Function AE_GetUDNYTDT(ByVal Pin_strDEFNOKDT As String, _
	'''''                       ByVal Pin_strODNYTDT As String, _
	'''''                       ByVal Pin_strUDNYTDT As String, _
	'''''                       ByVal Pin_strTOKSMEKB As String, _
	'''''                       ByVal Pin_strTOKSMEDD As String, _
	'''''                       ByVal Pin_strTOKSMECC As String, _
	'''''                       ByVal Pin_strTOKSDWKB As String, _
	'''''                       ByVal Pin_strURIKJN As String, _
	'''''                       ByRef Pot_strUDNYTDT As String) As Integer
	''''
	''''    Dim strDate     As String
	''''    Dim strDate2    As String
	''''    Dim intRet      As Integer
	''''    Dim strSMEDT    As String
	''''
	''''    AE_GetUDNYTDT = 9
	''''    Pot_strUDNYTDT = ""
	''''
	''''    Select Case Pin_strURIKJN
	''''        '�o�׊
	''''        Case gc_strURIKJN_SYK
	''''            '���t�`�F�b�N
	''''            If IsDate(Pin_strODNYTDT) = True Then
	''''                strDate = Format(Pin_strODNYTDT, "yyyymmdd")
	''''            Else
	''''                If IsDate(Format(Pin_strODNYTDT, "@@@@/@@/@@")) = True Then
	''''                    strDate = Pin_strODNYTDT
	''''                Else
	''''                    Exit Function
	''''                End If
	''''            End If
	''''
	''''            '�c�Ɠ��擾
	''''            intRet = DSPCLDDT_SEARCH_KDKB(strDate, "1", "1", Pot_strUDNYTDT)
	''''            If intRet <> 0 Then
	''''                Exit Function
	''''            End If
	''''
	''''        '������A�H�������
	''''        Case gc_strURIKJN_KNS, gc_strURIKJN_KOJ
	''''            '���t�`�F�b�N
	''''
	''''' === 20060726 === INSERT S - ACE)Nagasawa
	''''            If Trim(Pin_strUDNYTDT) <> "" Then
	''''' === 20060726 === INSERT E -
	''''            If IsDate(Pin_strUDNYTDT) = True Then
	''''                strDate = Format(Pin_strUDNYTDT, "yyyymmdd")
	''''            Else
	''''                If IsDate(Format(Pin_strUDNYTDT, "@@@@/@@/@@")) = True Then
	''''                    strDate = Pin_strUDNYTDT
	''''                Else
	''''                    Exit Function
	''''                End If
	''''            End If
	''''' === 20060726 === INSERT S - ACE)Nagasawa
	''''            Else
	''''                If IsDate(Pin_strODNYTDT) = True Then
	''''                    strDate = Format(Pin_strODNYTDT, "yyyymmdd")
	''''                Else
	''''                    If IsDate(Format(Pin_strODNYTDT, "@@@@/@@/@@")) = True Then
	''''                        strDate = Pin_strODNYTDT
	''''                    Else
	''''                        Exit Function
	''''                    End If
	''''                End If
	''''            End If
	''''' === 20060726 === INSERT E -
	''''
	''''            Pot_strUDNYTDT = strDate
	''''
	''''        '�𖱊����
	''''        Case gc_strURIKJN_EKM
	''''            '���t�`�F�b�N
	''''            If IsDate(Pin_strDEFNOKDT) = True Then
	''''                strDate = Format(Pin_strDEFNOKDT, "yyyymmdd")
	''''            Else
	''''                If IsDate(Format(Pin_strDEFNOKDT, "@@@@/@@/@@")) = True Then
	''''                    strDate = Pin_strDEFNOKDT
	''''                Else
	''''                    Exit Function
	''''                End If
	''''            End If
	''''
	''''            '����\������v�Z
	''''            intRet = AE_GetSMEDT(strDate, _
	'''''                                 Pin_strTOKSMEKB, _
	'''''                                 Pin_strTOKSMEDD, _
	'''''                                 Pin_strTOKSMECC, _
	'''''                                 Pin_strTOKSDWKB, _
	'''''                                 1, _
	'''''                                 strDate2)
	''''            If intRet = 9 Then
	''''                Exit Function
	''''            End If
	''''
	''''            '�c�Ɠ��擾
	''''            intRet = DSPCLDDT_SEARCH_KDKB(strDate2, "1", "2", Pot_strUDNYTDT)
	''''            If intRet <> 0 Then
	''''                Exit Function
	''''            End If
	''''
	''''    End Select
	''''
	''''
	''''    AE_GetUDNYTDT = 0
	''''
	''''End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GetKRSMADT
	'   �T�v�F  �o�������v�Z����
	'   �����F  Pin_strKJNDT    : ���
	'           Pot_strSMADT  �@: �v�Z���ʌo������(yyyymmdd�̌`���j
	'   �ߒl�F  0�F����@9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Function AE_GetKRSMADT(ByVal Pin_strKJNDT As String, _
	'''''                       ByRef pot_strSMADT As String) As Integer
	''''
	''''    Dim strSMEDT                As String
	''''    Dim strSQL                  As String
	''''    Dim Mst_Inf_SYSTBA          As TYPE_DB_SYSTBA
	''''    Dim intRet                  As Integer
	''''
	''''    AE_GetKRSMADT = 9
	''''    pot_strSMADT = ""
	''''
	''''    Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
	''''
	''''    '���[�U�[���Ǘ��e�[�u������
	''''    If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
	''''        Exit Function
	''''    End If
	''''
	''''    '�o�������v�Z
	''''    intRet = AE_GetSMEDT(Pin_strKJNDT _
	'''''                       , gc_strSMEKB_DAY _
	'''''                       , Mst_Inf_SYSTBA.SMEDD _
	'''''                       , "99" _
	'''''                       , "" _
	'''''                       , 0 _
	'''''                       , strSMEDT)
	''''    If intRet <> 0 Then
	''''        Exit Function
	''''    End If
	''''
	''''    pot_strSMADT = strSMEDT
	''''
	''''    AE_GetKRSMADT = 0
	''''
	''''End Function
	
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
	''''Public Function AE_Execute_PLSQL_GetTanka(ByVal pin_strHINCD As String, _
	'''''                                          ByVal pin_strTOKCD As String, _
	'''''                                          ByVal pin_strDate As String, _
	'''''                                          ByVal pin_strTUKKB As String, _
	'''''                                          ByVal Pin_lngSU As Long, _
	'''''                                          ByRef Pot_curTANKA As Currency, _
	'''''                                          ByRef Pot_curSIKRT As Currency, _
	'''''                                          Optional ByRef Pin_strJDNKB As String = "", _
	'''''                                          Optional ByRef Pot_curTEITK As Currency) As Integer
	''''
	''''    Dim strSQL      As String           'SQL��
	''''    Dim strPara1    As String           '���Ұ�1(���i�R�[�h)
	''''    Dim strPara2    As String           '���Ұ�2(���Ӑ�R�[�h)
	''''    Dim strPara3    As String           '���Ұ�3(�K�p��)
	''''    Dim strPara4    As String           '���Ұ�4(�ʉ݋敪)
	''''    Dim lngPara5    As Long             '���Ұ�5(����)
	''''    Dim strPara6    As String           '���Ұ�6(�󒍋敪)
	''''    Dim lngPara7    As Long             '���Ұ�7(���A����)
	''''    Dim lngPara8    As Long             '���Ұ�8(�װ����)
	''''    Dim strPara9    As String           '���Ұ�9(�װ���e)
	''''    Dim lngPara10   As Long             '���Ұ�10(�̔��P��)
	''''    Dim lngPara11   As Long             '���Ұ�11(�d�ؗ�)
	''''    Dim lngPara12   As Long             '���Ұ�12(�艿)
	''''    Dim param(13)   As OraParameter     'PL/SQL�̃o�C���h�ϐ�
	''''    Dim bolRet      As Boolean
	''''
	''''    AE_Execute_PLSQL_GetTanka = 9
	''''
	''''    '��n���ϐ������ݒ�
	''''    strPara1 = pin_strHINCD
	''''    strPara2 = pin_strTOKCD
	''''    strPara3 = pin_strDate
	''''    strPara4 = pin_strTUKKB
	''''    lngPara5 = Pin_lngSU
	''''    strPara6 = Pin_strJDNKB
	''''    lngPara7 = 0
	''''    lngPara8 = 0
	''''    strPara9 = ""
	''''    lngPara10 = 0
	''''    lngPara11 = 0
	''''    lngPara12 = 0
	''''
	''''    '�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
	''''    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P5", lngPara5, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P6", strPara6, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P7", lngPara7, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P8", lngPara8, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P9", strPara9, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P11", lngPara11, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P12", lngPara12, ORAPARM_OUTPUT
	''''
	''''    '�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
	''''    Set param(1) = gv_Odb_USR1.Parameters("P1")
	''''    Set param(2) = gv_Odb_USR1.Parameters("P2")
	''''    Set param(3) = gv_Odb_USR1.Parameters("P3")
	''''    Set param(4) = gv_Odb_USR1.Parameters("P4")
	''''    Set param(5) = gv_Odb_USR1.Parameters("P5")
	''''    Set param(6) = gv_Odb_USR1.Parameters("P6")
	''''    Set param(7) = gv_Odb_USR1.Parameters("P7")
	''''    Set param(8) = gv_Odb_USR1.Parameters("P8")
	''''    Set param(9) = gv_Odb_USR1.Parameters("P9")
	''''    Set param(10) = gv_Odb_USR1.Parameters("P10")
	''''    Set param(11) = gv_Odb_USR1.Parameters("P11")
	''''    Set param(12) = gv_Odb_USR1.Parameters("P12")
	''''
	''''    '�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
	''''    param(1).serverType = ORATYPE_CHAR
	''''    param(2).serverType = ORATYPE_CHAR
	''''    param(3).serverType = ORATYPE_CHAR
	''''    param(4).serverType = ORATYPE_CHAR
	''''    param(5).serverType = ORATYPE_NUMBER
	''''    param(6).serverType = ORATYPE_CHAR
	''''    param(7).serverType = ORATYPE_NUMBER
	''''    param(8).serverType = ORATYPE_NUMBER
	''''    param(9).serverType = ORATYPE_VARCHAR2
	''''    param(10).serverType = ORATYPE_NUMBER
	''''    param(11).serverType = ORATYPE_NUMBER
	''''    param(12).serverType = ORATYPE_NUMBER
	''''
	''''    'PL/SQL�Ăяo��SQL
	''''    strSQL = "BEGIN PRC_CMNPL90_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12); End;"
	''''
	''''    'DB�A�N�Z�X
	''''    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
	''''    If bolRet = False Then
	''''        GoTo AE_Execute_PLSQL_GetTanka_END
	''''    End If
	''''
	''''    '** �߂�l�擾
	''''    lngPara7 = param(7).Value
	''''    lngPara8 = param(8).Value
	''''    If IsNull(param(9).Value) = False Then
	''''        strPara9 = param(9).Value
	''''    End If
	''''
	''''    If IsNull(param(10).Value) = False Then
	''''        lngPara10 = param(10).Value
	''''    Else
	''''        lngPara10 = 0
	''''    End If
	''''
	''''    If IsNull(param(11).Value) = False Then
	''''        lngPara11 = param(11).Value
	''''    Else
	''''        lngPara11 = 0
	''''    End If
	''''
	''''    If IsNull(param(12).Value) = False Then
	''''        lngPara12 = param(12).Value
	''''    Else
	''''        lngPara12 = 0
	''''    End If
	''''
	''''    Pot_curTANKA = CCur(lngPara10)
	''''    Pot_curSIKRT = CCur(lngPara11)
	''''    Pot_curTEITK = CCur(lngPara12)
	''''
	''''    '�G���[���ݒ�
	''''    gv_Int_OraErr = lngPara8
	''''    gv_Str_OraErrText = strPara9 & vbCrLf
	''''
	''''    AE_Execute_PLSQL_GetTanka = lngPara7
	''''
	''''AE_Execute_PLSQL_GetTanka_END:
	''''    '** �p�����^����
	''''    gv_Odb_USR1.Parameters.Remove "P1"
	''''    gv_Odb_USR1.Parameters.Remove "P2"
	''''    gv_Odb_USR1.Parameters.Remove "P3"
	''''    gv_Odb_USR1.Parameters.Remove "P4"
	''''    gv_Odb_USR1.Parameters.Remove "P5"
	''''    gv_Odb_USR1.Parameters.Remove "P6"
	''''    gv_Odb_USR1.Parameters.Remove "P7"
	''''    gv_Odb_USR1.Parameters.Remove "P8"
	''''    gv_Odb_USR1.Parameters.Remove "P9"
	''''    gv_Odb_USR1.Parameters.Remove "P10"
	''''    gv_Odb_USR1.Parameters.Remove "P11"
	''''    gv_Odb_USR1.Parameters.Remove "P12"
	''''
	''''
	''''End Function
	''''
	
	''''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''''   ���́F  Function AE_Get_TANKA
	'''''   �T�v�F  �P���A�d�ؗ��擾����
	'''''   �����F�@Pin_strHINCD       :���i�R�[�h
	'''''           Pin_strTOKCD       :���Ӑ�R�[�h
	'''''           Pin_strDATE        :���
	'''''           Pot_curSIKRT       :�d�ؗ�
	'''''           Pot_curTANKA       :�擾�P��
	'''''   �ߒl�F  0 : ����@9 : �ُ�
	'''''   ���l�F
	''''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Public Static Function AE_Get_TANKA(ByVal pin_strHINCD As String, _
	'''''                                    ByVal pin_strTOKCD As String, _
	'''''                                    ByVal pin_strDate As String, _
	'''''                                    ByRef Pot_curSIKRT As Currency, _
	'''''                                    ByRef Pot_curTANKA As Currency) As Integer
	''''
	''''    Dim Mst_Inf_HINMTA      As TYPE_DB_HINMTA       '���i�}�X�^��������
	'''''    Dim Mst_Inf_RNKMTA      As TYPE_DB_RNKMTA       '�����N�ʎd�؂藦�}�X�^��������
	''''    Dim Mst_Inf_TOKMTA      As TYPE_DB_TOKMTA       '���Ӑ�}�X�^��������
	'''''    Dim Mst_Inf_TRKMTA      As type_db_trkmta       '���Ӑ�ʏ��i�����N�}�X�^��������
	''''
	''''    AE_Get_TANKA = 9
	''''
	''''    Pot_curSIKRT = 100
	''''    Pot_curTANKA = 0
	''''
	''''    '���i�}�X�^����
	''''    If DSPHINCD_SEARCH(pin_strHINCD, Mst_Inf_HINMTA) <> 0 Then
	''''        GoTo AE_Get_TANKA_ERR
	''''    End If
	''''
	''''    If Mst_Inf_HINMTA.DATKB <> gc_strDATKB_USE Then
	''''        GoTo AE_Get_TANKA_ERR
	''''    End If
	''''
	'''''**********************����������
	''''    Pot_curSIKRT = 90
	''''    Pot_curTANKA = Mst_Inf_HINMTA.ZNKURITK
	'''''**********************����������
	'''''    '���Ӑ�}�X�^����
	'''''    If DSPTOKCD_SEARCH(Pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    '���Ӑ�ʏ��i�����N�}�X�^����
	'''''    If DSPTRKRNK_SEARCH(Pin_strTOKCD, Mst_Inf_HINMTA.HINGRP, Pin_strDATE, Mst_Inf_TRKMTA) <> 0 Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    '�d�ؗ��擾
	'''''    If DSPRNKM_SEARCH(Mst_Inf_HINMTA.HINGRP, "", Pin_strDATE, Mst_Inf_RNKMTA) <> 0 Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    If Mst_Inf_RNKMTA.DATKB <> gc_strDATKB_USE Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    '�d�ؗ��擾
	'''''    Pot_curSIKRT = Mst_Inf_RNKMTA.SIKRT
	'''''
	'''''    '�P���擾
	'''''    Pot_curTANKA = AE_Calc_TANKA(Pot_curSIKRT, _
	''''''                                 Mst_Inf_HINMTA.TEIKATK, _
	''''''                                 Mst_Inf_TOKMTA.TKNRPSKB, _
	''''''                                 Mst_Inf_TOKMTA.TKNZRNKB)
	''''
	''''    AE_Get_TANKA = 0
	''''
	''''    Exit Function
	''''
	''''AE_Get_TANKA_ERR:
	''''
	''''End Function
	
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
		
		'''    Dim intRet      As Integer
		'''    Dim Mst_Inf     As TYPE_DB_UNYMTA
		'''
		'''    CF_Get_UnyDt = False
		'''
		'''    '������
		'''    GV_UNYDate = ""
		'''
		'''    '�T�[�o�[�̃V�X�e�����t�擾
		'''    Call CF_Get_SysDt
		'''
		'''    '�^�p���t���擾
		'''    intRet = DSPUNYDT_SEARCH(Mst_Inf)
		'''    If intRet = 0 Then
		'''        GV_UNYDate = Mst_Inf.UNYDT
		'''    Else
		'''        GV_UNYDate = GV_SysDate
		'''    End If
		'''
		'''    CF_Get_UnyDt = True
		
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
	'   �ߒl�F�@0 : ����  1 : �x��  9 : �ُ�
	'   ���l�F  ������������PL/SQL(PRC_UODFP53_01)�����s����
	'           �������A�ύX�O�󒍐��ʁ��ύX��󒍐��ʂ̏ꍇ�͎��s���Ȃ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String _
	'''''                                           , ByVal pin_strJDNNO As String _
	'''''                                           , ByVal pin_strLINNO As String _
	'''''                                           , ByVal pin_strSBNNO As String _
	'''''                                           , ByVal pin_strHINCD As String _
	'''''                                           , ByVal Pin_lngBFRSU As Currency _
	'''''                                           , ByVal Pin_lngAFTSU As Currency) As Integer
	''''
	''''    Dim strSQL      As String           'SQL��
	''''    Dim strPara1    As String           '���Ұ�1(�S���҃R�[�h)
	''''    Dim strPara2    As String           '���Ұ�2(�N���C�A���gID)
	''''    Dim strPara3    As String           '���Ұ�3(�����P�[�X)
	''''    Dim strPara4    As String           '���Ұ�4(�󒍔ԍ�)
	''''    Dim strPara5    As String           '���Ұ�5(�s�ԍ�)
	''''    Dim strPara6    As String           '���Ұ�6(����)
	''''    Dim strPara7    As String           '���Ұ�7(���i�R�[�h)
	''''    Dim lngPara8    As Long             '���Ұ�8(�ύX�O�󒍐���)
	''''    Dim lngPara9    As Long             '���Ұ�9(�ύX��󒍐���)
	''''    Dim lngPara10   As Long             '���Ұ�10(���A����)
	''''    Dim lngPara11   As Long             '���Ұ�11(�װ����)
	''''    Dim strPara12   As String * 1000    '���Ұ�12(�װ���e)
	''''    Dim lngPara13   As Long             '���Ұ�13(�Ǎ�����)
	''''    Dim lngPara14   As Long             '���Ұ�14(�o�^����)
	''''    Dim param(15)   As OraParameter     'PL/SQL�̃o�C���h�ϐ�
	''''    Dim bolRet      As Boolean
	''''
	''''    AE_Execute_PLSQL_PRC_UODFP53 = 9
	''''
	''''    '�ύX�O�󒍐��ʁ��ύX��󒍐��ʂ̏ꍇ�͏����I��
	''''    If Pin_lngBFRSU = Pin_lngAFTSU Then
	''''        AE_Execute_PLSQL_PRC_UODFP53 = 0
	''''        Exit Function
	''''    End If
	''''
	''''    '��n���ϐ������ݒ�
	''''    strPara1 = SSS_OPEID
	''''    strPara2 = SSS_CLTID
	''''    strPara3 = Pin_strPRCCASE
	''''    strPara4 = pin_strJDNNO
	''''    strPara5 = pin_strLINNO
	''''    strPara6 = pin_strSBNNO
	''''    strPara7 = pin_strHINCD
	''''    lngPara8 = Pin_lngBFRSU
	''''    lngPara9 = Pin_lngAFTSU
	''''    lngPara10 = 0
	''''    lngPara11 = 0
	''''    strPara12 = ""
	''''    lngPara13 = 0
	''''    lngPara14 = 0
	''''
	''''    '�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
	''''    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P5", strPara5, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P6", strPara6, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P7", strPara7, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P8", lngPara8, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P9", lngPara9, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P11", lngPara11, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P12", strPara12, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P13", lngPara13, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P14", lngPara14, ORAPARM_OUTPUT
	''''
	''''    '�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
	''''    Set param(1) = gv_Odb_USR1.Parameters("P1")
	''''    Set param(2) = gv_Odb_USR1.Parameters("P2")
	''''    Set param(3) = gv_Odb_USR1.Parameters("P3")
	''''    Set param(4) = gv_Odb_USR1.Parameters("P4")
	''''    Set param(5) = gv_Odb_USR1.Parameters("P5")
	''''    Set param(6) = gv_Odb_USR1.Parameters("P6")
	''''    Set param(7) = gv_Odb_USR1.Parameters("P7")
	''''    Set param(8) = gv_Odb_USR1.Parameters("P8")
	''''    Set param(9) = gv_Odb_USR1.Parameters("P9")
	''''    Set param(10) = gv_Odb_USR1.Parameters("P10")
	''''    Set param(11) = gv_Odb_USR1.Parameters("P11")
	''''    Set param(12) = gv_Odb_USR1.Parameters("P12")
	''''    Set param(13) = gv_Odb_USR1.Parameters("P13")
	''''    Set param(14) = gv_Odb_USR1.Parameters("P14")
	''''
	''''    '�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
	''''    param(1).serverType = ORATYPE_CHAR
	''''    param(2).serverType = ORATYPE_CHAR
	''''    param(3).serverType = ORATYPE_CHAR
	''''    param(4).serverType = ORATYPE_CHAR
	''''    param(5).serverType = ORATYPE_CHAR
	''''    param(6).serverType = ORATYPE_CHAR
	''''    param(7).serverType = ORATYPE_CHAR
	''''    param(8).serverType = ORATYPE_NUMBER
	''''    param(9).serverType = ORATYPE_NUMBER
	''''    param(10).serverType = ORATYPE_NUMBER
	''''    param(11).serverType = ORATYPE_NUMBER
	''''    param(12).serverType = ORATYPE_VARCHAR2
	''''    param(13).serverType = ORATYPE_NUMBER
	''''    param(14).serverType = ORATYPE_NUMBER
	''''
	''''    'PL/SQL�Ăяo��SQL
	''''    strSQL = "BEGIN PRC_UODFP53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12,:P13,:P14); End;"
	''''
	''''    'DB�A�N�Z�X
	''''    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
	''''    If bolRet = False Then
	''''        GoTo AE_Execute_PLSQL_PRC_UODFP53_END
	''''    End If
	''''
	''''    '** �߂�l�擾
	''''    lngPara10 = param(10).Value
	''''    lngPara11 = param(11).Value
	''''    If IsNull(param(12).Value) = False Then
	''''        strPara12 = param(12).Value
	''''    End If
	''''    lngPara13 = param(13).Value
	''''    lngPara14 = param(14).Value
	''''
	''''    '�G���[���ݒ�
	''''    gv_Int_OraErr = lngPara11
	''''    gv_Str_OraErrText = Trim(strPara12) & vbCrLf
	''''
	''''    AE_Execute_PLSQL_PRC_UODFP53 = lngPara10
	''''
	''''AE_Execute_PLSQL_PRC_UODFP53_END:
	''''    '** �p�����^����
	''''    gv_Odb_USR1.Parameters.Remove "P1"
	''''    gv_Odb_USR1.Parameters.Remove "P2"
	''''    gv_Odb_USR1.Parameters.Remove "P3"
	''''    gv_Odb_USR1.Parameters.Remove "P4"
	''''    gv_Odb_USR1.Parameters.Remove "P5"
	''''    gv_Odb_USR1.Parameters.Remove "P6"
	''''    gv_Odb_USR1.Parameters.Remove "P7"
	''''    gv_Odb_USR1.Parameters.Remove "P8"
	''''    gv_Odb_USR1.Parameters.Remove "P9"
	''''    gv_Odb_USR1.Parameters.Remove "P10"
	''''    gv_Odb_USR1.Parameters.Remove "P11"
	''''    gv_Odb_USR1.Parameters.Remove "P12"
	''''    gv_Odb_USR1.Parameters.Remove "P13"
	''''    gv_Odb_USR1.Parameters.Remove "P14"
	''''
	''''End Function
End Module