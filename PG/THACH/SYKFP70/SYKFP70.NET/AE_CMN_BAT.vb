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
	'   API
	'************************************************************************************
	'//----------------------------------------------
	'//�e�v���Z�X�ւ̏I���R�[�h���A
	'//----------------------------------------------
	Public Declare Sub ExitProcess Lib "kernel32" (ByVal uExitCode As Integer)
	'//----------------------------------------------
	'//�X���[�v
	'//----------------------------------------------
	Public Declare Function Sleep Lib "kernel32.dll" (ByVal mstime As Integer) As Integer
	
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
	
	Public Const MAX_PATH As Short = 260
	
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
	Dim SSS_INIDAT(4) As String
	Dim SSS_INICnt As Short
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Init_BAT
	'   �T�v�F  �v���O�����N������������(�o�b�`�p)
	'   �����F  pot_strErrMsg : �G���[���b�Z�[�W
	'           pin_strPGID   : �󔒂͒ʏ폈���@��۸���ID�������Ă���ꍇ�͂��ꂼ��̌ŗL�̏��������s
	'   �ߒl�F  �Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_BAT(ByRef pot_strErrMsg As String, Optional ByRef pin_strPGID As String = "") As Short
		
		Dim datDT As Date
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim DB_UNYMTA As TYPE_DB_UNYMTA
		Dim strYMD As String
		Dim intLenCommand As String
		Dim intRet As Short
		
		CF_Init_BAT = 9
		
		pot_strErrMsg = ""
		
		'��d�N������
		'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
		If App.PrevInstance Then
			pot_strErrMsg = "�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B"
			Exit Function
		End If
		
		'   ���t�`���`�F�b�N
		datDT = Today
		strYMD = VB6.Format(Year(datDT), "0000") & "/" & VB6.Format(Month(datDT), "00") & "/" & VB6.Format(VB.Day(datDT), "00")
		
		If CStr(datDT) <> strYMD Then
			pot_strErrMsg = "���t�̌`�� '" & CStr(datDT) & "' ���Ⴂ�܂��B" & " " & "�R���g���[���p�l���̒n��i�n���̊G�j�̓��t" & " " & "�̒Z���`���� yyyy/MM/dd �ɕύX���ĉ������B"
			Exit Function
		End If
		
		'---------------------
		' �N���p�����[�^�ݒ�
		'---------------------
		Select Case UCase(Trim(pin_strPGID))
			'�o�ח\��f�[�^�쐬����
			Case "SYKFP70"
				
				'�ʏ�
			Case Else
				'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
				intLenCommand = CStr(LenB(Trim(VB.Command())))
				If CDbl(intLenCommand) < 15 Then
					intRet = CF_Get_BATUSER
					If intRet <> 0 Then
						pot_strErrMsg = "�o�b�`�����s����S���҂h�c�A�[���h�c������܂���B�ݒ���m�F���ĉ������B"
						Exit Function
					End If
				Else
					SSS_CLTID.Value = CF_Ctr_AnsiMidB(VB.Command(), 2, 5) '�N���C�A���gID
					SSS_OPEID.Value = CF_Ctr_AnsiMidB(VB.Command(), 7, 8) '���͒S����ID
				End If
				
				'���͒S���Җ��擾
				Inp_Inf.InpTanCd = SSS_OPEID.Value
				Inp_Inf.InpCLIID = SSS_CLTID.Value
				
				Call DB_TANMTA_Clear(DB_TANMTA)
				intRet = DSPTANCD_SEARCH(Inp_Inf.InpTanCd, DB_TANMTA)
				If intRet = 0 Then
					Inp_Inf.InpTanNm = DB_TANMTA.TANNM '���͒S���Җ�
				End If
		End Select
		
		
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
		
		'�^�p���t�擾
		Call CF_Get_UnyDt()
		
		CF_Init_BAT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_INIT_GETINI
	'   �T�v�F  INI�t�@�C���Ǎ��݁i���ʁj
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CF_INIT_GETINI() As String
		Dim WL_WinDir As String
		Dim I, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		
		CF_INIT_GETINI = ""
		
		'---------------------
		' SSSWIN.INI �Ǎ���
		'---------------------
		For I = 0 To SSS_INICnt
			rtnPara.Value = ""
			LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(I), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
			If LENGTH = 0 Then
				CF_INIT_GETINI = "SSSWIN.INI ���m�F���Ă��������B" & Chr(13) & "[" & strINIDATNM(I) & "]"
				Exit For
			Else
				SSS_INIDAT(I) = CF_Ctr_AnsiLeftB(rtnPara.Value, LENGTH)
			End If
			If Right(SSS_INIDAT(I), 1) <> "\" And Right(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
		Next I
		
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
	'   ���́F  Function CF_Get_BATUSER
	'   �T�v�F  �o�b�`�p�S���Ҏ擾
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0 : ����@9 : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_BATUSER() As Short
		
		Dim Mst_Inf As TYPE_DB_FIXMTA
		Dim intRet As Short
		
		CF_Get_BATUSER = 9
		
		'�Œ�l�}�X�^����
		'�o�b�`�p�S���҂h�c�擾
		Call DB_FIXMTA_Clear(Mst_Inf)
		
		intRet = DSPCTLCD_SEARCH(gc_strCTLCD_TANCD_BAT, Mst_Inf)
		If intRet = 0 Then
			SSS_OPEID.Value = Mst_Inf.FIXVAL
		Else
			Exit Function
		End If
		
		'�o�b�`�p�[���h�c�擾
		Call DB_FIXMTA_Clear(Mst_Inf)
		
		intRet = DSPCTLCD_SEARCH(gc_strCTLCD_CLTID_BAT, Mst_Inf)
		If intRet = 0 Then
			SSS_CLTID.Value = Mst_Inf.FIXVAL
		Else
			Exit Function
		End If
		
		CF_Get_BATUSER = 0
		
	End Function
	
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
	'   ���́F  Function CF_Edit_ErrLog
	'   �T�v�F  �G���[���O�o�͏���
	'   �����F  pin_strLOG_PATH    : �o�̓��O�t�@�C���p�X
	'           pin_strLOG_NAME    : �o�̓��O�t�@�C����
	'           pin_strPrgId       : �o�̓v���O������
	'           pin_intErrCd       : �G���[�R�[�h
	'           pin_strErrMsg      : �G���[���b�Z�[�W
	'           pin_strErrLocation : �����ӏ��i�t�@���N�V�������j
	'           pin_strTime        : ��������
	'           pin_strDate        : �������t
	'   �ߒl�F  0 : ���� 9 : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Edit_ErrLog(ByVal pin_strLOG_PATH As String, ByVal pin_strLOG_NAME As String, ByVal pin_strPrgId As String, ByVal pin_intErrCd As Short, ByVal pin_strErrMsg As String, ByVal pin_strErrLocation As String, ByVal pin_strTime As String, ByVal pin_strDate As String) As Short
		
		Dim intFNo As Short
		Dim strCSV As String
		Dim bolOpen As Boolean
		
		On Error GoTo CF_Edit_ErrLog_End
		
		CF_Edit_ErrLog = 9
		bolOpen = False
		
		intFNo = FreeFile
		
		If Right(Trim(pin_strLOG_PATH), 1) <> "\" Then
			pin_strLOG_PATH = Trim(pin_strLOG_PATH) & "\"
		End If
		
		'�t�@�C���I�[�v��
		FileOpen(intFNo, Trim(pin_strLOG_PATH) & Trim(pin_strLOG_NAME), OpenMode.Append)
		bolOpen = True
		
		strCSV = ""
		'�v���O����ID
		strCSV = strCSV & pin_strPrgId & ","
		'�G���[�ԍ�
		strCSV = strCSV & Trim(CStr(pin_intErrCd)) & ","
		'�G���[���e
		strCSV = strCSV & pin_strErrMsg & ","
		'�����ꏊ�i�t�@���N�V���������j
		strCSV = strCSV & pin_strErrLocation & ","
		'������
		strCSV = strCSV & pin_strDate & ","
		'��������
		strCSV = strCSV & pin_strTime
		
		PrintLine(intFNo, strCSV)
		
		CF_Edit_ErrLog = 0
		
CF_Edit_ErrLog_End: 
		
		If bolOpen = True Then
			'�N���[�Y
			FileClose(intFNo)
		End If
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ctr_AnsiLeftB
	'//*
	'//* <�߂�l>     �^          ����
	'//*              String      �ϊ���̕�����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//*              pm_Len             Long             I            ������̒���
	'//* <��  ��>
	'//*    ���p������1�o�C�g�A�S�p������2�o�C�g�Ƃ��č�����w��̒����̕�������擾���܂��B
	'//*    �w�肵���������A�S�p�������r���Ő؂��o�C�g���̏ꍇ�A�������擾�ł��܂���B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
		
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ctr_AnsiRightB
	'//*
	'//* <�߂�l>     �^          ����
	'//*              String      �ϊ���̕�����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//*              pm_Len             Long             I            ������̒���
	'//* <��  ��>
	'//*    ���p������1�o�C�g�A�S�p������2�o�C�g�Ƃ��ĉE����w��̒����̕�������擾���܂��B
	'//*    �w�肵���������A�S�p�������r���Ő؂��o�C�g���̏ꍇ�A�������擾�ł��܂���B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiRightB(ByVal pm_Value As String, ByVal pm_Len As Integer) As Object
		
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: RightB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		CF_Ctr_AnsiRightB = StrConv(RightB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ctr_AnsiMidB
	'//*
	'//* <�߂�l>     �^          ����
	'//*              String      �ϊ���̕�����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//*              pm_Start           Long             I            �؂���J�n�o�C�g��
	'//*              pm_Len             Long             I            ������̒���
	'//* <��  ��>
	'//*    ���p������1�o�C�g�A�S�p������2�o�C�g�Ƃ��Ďw�肵���ʒu����w��̒����̕�������擾���܂��B
	'//*    �w�肵���������A�S�p�������r���Ő؂��o�C�g���̏ꍇ�A�������擾�ł��܂���B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiMidB(ByVal pm_Value As String, ByVal pm_Start As Integer, Optional ByVal pm_Len As Integer = 0) As String
		
		Dim Str_Value As String
		
		If pm_Len < 1 Then
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start), vbUnicode)
		Else
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start, pm_Len), vbUnicode)
			
			'//�S�p�������r���œr�؂��ꍇ�P�������߂ɃJ�b�g����B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			If LenB(StrConv(Str_Value, vbFromUnicode)) > pm_Len Then
				Str_Value = Mid(Str_Value, Len(Str_Value) - 1, 1)
			End If
		End If
		
		CF_Ctr_AnsiMidB = Str_Value
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ctr_AnsiLenB
	'//*
	'//* <�߂�l>     �^          ����
	'//*              Long        �����o�C�g��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//* <��  ��>
	'//*    ���p������1�o�C�g�A�S�p������2�o�C�g�Ƃ��đΏە�����̒����o�C�g�����擾���܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer
		
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))
		
		Exit Function
		
	End Function
	
	Function Get_DBHEAD() As String
		'���݂̊���DBHEAD ��Ԃ��A�����ݒ�̏ꍇ�́A""��Ԃ��B
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		
		Get_DBHEAD = ""
		ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr.Value, 128, "SSSWIN.INI")
		If ret > 0 Then Get_DBHEAD = Left(wkStr.Value, ret)
	End Function
	
	Sub Error_Exit(ByVal ErrorMsg As String)
		Dim rtn As Object
		Dim I As Short
		End
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CmnMsgLibrary_Bat
	'   �T�v�F  �W�����b�Z�[�W�\������(�o�b�`�p)
	'   �����F  Pin_strPgNm     : �v���O������
	'           Pin_strMsgCode  : ���b�Z�[�W�R�[�h�iDB�����p�j
	'           pin_strMsg      : �ǉ����b�Z�[�W
	'   �ߒl�F
	'   ���l�F  �A�v���̎��s���ɏo�͂����W�����b�Z�[�W�B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CmnMsgLibrary_Bat(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, Optional ByVal pin_strMsg As String = "") As Short
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
		On Error Resume Next
		
		AE_CmnMsgLibrary_Bat = False
		
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
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "�����ӏ�   : " & pin_strMsg
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		'���b�Z�[�W�\��
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				
				'OK/�L�����Z��
			Case gc_strBTNKB_OKCancel
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'���~/�Ď��s/����
			Case gc_strBTNKB_AbortRetryIgnore
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������/�L�����Z��
			Case gc_strBTNKB_YesNoCancel
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������
			Case gc_strBTNKB_YesNo
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�Ď��s/�L�����Z��
			Case gc_strBTNKB_RetryCancel
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				
			Case Else
				
		End Select
		
	End Function
	
	' === 20061102 === INSERT S - ACE)Nagasawa INI�t�@�C���i�[�ꏊ�ύX
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
	' === 20061102 === INSERT E -
	
	' === 20061105 === INSERT S - ACE)Nagasawa �r������̒ǉ�
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
	' === 20061105 === INSERT E -
End Module