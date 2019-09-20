Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

'2019/04/24 ADD START
Imports Oracle.DataAccess.Client
'2019/04/24 ADD E N D

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

    '2019/04/26 ADD START
    Public CON As OracleConnection = Nothing
    '2019/04/26 ADD E N D
    '2019/05/07 ADD START
    Public CON_USR9 As OracleConnection = Nothing
    '2019/05/07 ADD E N D

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
        '2019/04/26 DEL START
        'Dim DB_TANMTA As TYPE_DB_TANMTA
        'Dim DB_UNYMTA As TYPE_DB_UNYMTA
        '2019/04/26 DEL E N D
        Dim strYMD As String
		Dim intLenCommand As String
		Dim intRet As Short
		
		CF_Init_BAT = 9
		
		pot_strErrMsg = ""
		
		'��d�N������
		'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '2019/04/26�@��
        'If App.PrevInstance Then
        '    pot_strErrMsg = "�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B"
        '    Exit Function
        'End If
        '2019/04/26�@��

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

                'delete start 20190820 kuwa
                'Call DB_TANMTA_Clear(DB_TANMTA)
                'delete end 20190820 kuwa
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
        '2019/04/26 DEL START
        'Dim WL_WinDir As String
        '2019/04/26 DEL E N D
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
        '2019/04/26 DEL START
        'Dim DB_TANMTA As TYPE_DB_TANMTA
        '2019/04/26 DEL E N D
        Dim intRet As Short
		
		Ret_Value = ""

        '�S���҃}�X�^����
        'delete start 20190820 kuwa
        'Call DB_TANMTA_Clear(DB_TANMTA)
        'delete end 20190820 kuwa
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
		
        '2019/04/26 CHG START
        'Dim Mst_Inf As TYPE_DB_FIXMTA
        Dim Mst_Inf As TYPE_DB_FIXMTA = Nothing
        '2019/04/26 CHG E N D
		Dim intRet As Short
		
		CF_Get_BATUSER = 9

        '�Œ�l�}�X�^����
        '�o�b�`�p�S���҂h�c�擾
        'delete start 20190820 kuwa
        'Call DB_FIXMTA_Clear(Mst_Inf)
        'delete end 20190820 kuwa

        intRet = DSPCTLCD_SEARCH(gc_strCTLCD_TANCD_BAT, Mst_Inf)
		If intRet = 0 Then
			SSS_OPEID.Value = Mst_Inf.FIXVAL
		Else
			Exit Function
		End If

        '�o�b�`�p�[���h�c�擾
        'delete start 20190820 kuwa
        'Call DB_FIXMTA_Clear(Mst_Inf)
        'delete end 20190820 kuwa

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
    '2019/04/26 CHG START
    '	Public Function CF_Get_SysDt() As Boolean

    '		On Error GoTo ERR_HANDLE

    '		Dim Str_Sql As String
    '		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '		Dim Usr_Ody As U_Ody
    '		Dim Str_Val As String
    '		Dim Lng_Cnt As Integer
    '		Dim Lng_Idx As Integer
    '		Dim Str_SysDt As String

    '		CF_Get_SysDt = False

    '		'// ������
    '		GV_SysDate = ""
    '		GV_SysTime = ""
    '		Str_SysDt = ""

    '		Str_Sql = ""
    '		Str_Sql = Str_Sql & "SELECT"
    '		Str_Sql = Str_Sql & "       To_Char(sysdate,'YYYYMMDDHH24MISS') AAA "
    '		Str_Sql = Str_Sql & "FROM"
    '		Str_Sql = Str_Sql & "       Dual "

    '		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
    '			GoTo ERR_HANDLE
    '		End If

    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		Str_SysDt = Trim(CF_Ora_GetDyn(Usr_Ody, "AAA"))

    '		GV_SysDate = Mid(Str_SysDt, 1, 8)
    '		GV_SysTime = Mid(Str_SysDt, 9, 6)

    '		CF_Get_SysDt = True

    'EXIT_HANDLE: 
    '		Call CF_Ora_CloseDyn(Usr_Ody)
    '		Exit Function

    'ERR_HANDLE: 
    '		GoTo EXIT_HANDLE

    '    End Function
    Public Function CF_Get_SysDt() As Boolean

        '�߂�l
        Dim rtnVal As Boolean = False

        'SQL��
        Dim StrSql As String = Nothing

        Try
            StrSql = ""
            StrSql &= " SELECT "
            StrSql &= "  TO_CHAR(SYSDATE,'YYYYMMDDHH24MISS') VAL1 "
            StrSql &= " FROM DUAL "

            Dim dt As DataTable = DB_GetTable(StrSql)

            Dim val1 As String = Trim(DB_NullReplace(dt.Rows(0)("VAL1"), ""))

            GV_SysDate = Mid(val1, 1, 8)
            GV_SysTime = Mid(val1, 9, 6)

            rtnVal = True

        Catch ex As Exception

            Throw ex

            'Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

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
        '2019/04/26 CHG START
        'Dim Mst_Inf As TYPE_DB_UNYMTA
        Dim Mst_Inf As TYPE_DB_UNYMTA = Nothing
        '2019/04/26 CHG E N D

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
    '2019/04/26 CHG START
    'Public Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String

    '    'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '    'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '    'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '    CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)

    '    Exit Function

    'End Function
    Public Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
        Return LeftB(pm_Value, pm_Len)
    End Function
    '2019/04/26 CHG E N D

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
    '2019/04/26 CHG START
    'Public Function CF_Ctr_AnsiRightB(ByVal pm_Value As String, ByVal pm_Len As Integer) As Object

    '    'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '    'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '    'UPGRADE_ISSUE: RightB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '    CF_Ctr_AnsiRightB = StrConv(RightB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)

    '    Exit Function

    'End Function
    Public Function CF_Ctr_AnsiRightB(ByVal pm_Value As String, ByVal pm_Len As Integer) As Object
        Return RightB(pm_Value, pm_Len)
    End Function
    '2019/04/26 CHG E N D

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
    '2019/04/26 CHG START
    'Public Function CF_Ctr_AnsiMidB(ByVal pm_Value As String, ByVal pm_Start As Integer, Optional ByVal pm_Len As Integer = 0) As String

    '    Dim Str_Value As String

    '    If pm_Len < 1 Then
    '        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '        Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start), vbUnicode)
    '    Else
    '        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '        Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start, pm_Len), vbUnicode)

    '        '//�S�p�������r���œr�؂��ꍇ�P�������߂ɃJ�b�g����B
    '        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '        If LenB(StrConv(Str_Value, vbFromUnicode)) > pm_Len Then
    '            Str_Value = Mid(Str_Value, Len(Str_Value) - 1, 1)
    '        End If
    '    End If

    '    CF_Ctr_AnsiMidB = Str_Value

    '    Exit Function

    'End Function
    Public Function CF_Ctr_AnsiMidB(ByVal pm_Value As String, ByVal pm_Start As Integer, Optional ByVal pm_Len As Integer = 0) As String

        Dim rtnVal As String = ""

        If pm_Len < 1 Then
            rtnVal = MidB(pm_Value, pm_Start)
        Else
            rtnVal = MidB(pm_Value, pm_Start, pm_Len)

            '//�S�p�������r���œr�؂��ꍇ�P�������߂ɃJ�b�g����B
            If LenB(rtnVal) > pm_Len Then
                rtnVal = Mid(rtnVal, Len(rtnVal) - 1, 1)
            End If
        End If

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

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
    '2019/04/26 CHG START
    'Public Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer

    '    'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '    'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '    CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))

    '    Exit Function

    'End Function
    Public Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer
        Return LenB(pm_Value)
    End Function
    '2019/04/26 CHG E N D

	Function Get_DBHEAD() As String
		'���݂̊���DBHEAD ��Ԃ��A�����ݒ�̏ꍇ�́A""��Ԃ��B
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		
		Get_DBHEAD = ""
		ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr.Value, 128, "SSSWIN.INI")
		If ret > 0 Then Get_DBHEAD = Left(wkStr.Value, ret)
	End Function
	
	Sub Error_Exit(ByVal ErrorMsg As String)
        '2019/04/26 DEL START
        'Dim rtn As Object
        'Dim I As Short
        '2019/04/26 DEL E N D
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
		
        '2019/04/26 CHG START
        'Dim Mst_Inf As TYPE_DB_SYSTBH
        Dim Mst_Inf As TYPE_DB_SYSTBH = Nothing
        '2019/04/26 CHG E N D
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
    '2019/04/26 CHG START
    '    Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, ByRef Pot_strMsg As String) As Short

    '        Dim strSQL As String 'SQL��
    '        Dim strPara1 As String '���Ұ�1(�S���҃R�[�h)
    '        Dim strPara2 As String '���Ұ�2(�N���C�A���gID)
    '        Dim strPara3 As String '���Ұ�3(�����P�[�X)
    '        Dim strPara4 As String '���Ұ�4(�Ɩ��R�[�h(PGID))
    '        Dim lngPara5 As Integer '���Ұ�5(���A����)
    '        Dim lngPara6 As Integer '���Ұ�6(�װ����)
    '        Dim strPara7 As String '���Ұ�7(�װ���e)
    '        'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '        Dim param(7) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
    '        Dim bolRet As Boolean

    '        AE_Execute_PLSQL_EXCTBZ = 9

    '        '��n���ϐ������ݒ�
    '        strPara1 = Inp_Inf.InpTanCd
    '        strPara2 = SSS_CLTID.Value
    '        strPara3 = Pin_strPRCCASE
    '        strPara4 = SSS_PrgId
    '        lngPara5 = 0
    '        lngPara6 = 0
    '        strPara7 = ""

    '        Pot_strMsg = ""

    '        '�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_OUTPUT)
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Add("P6", lngPara6, ORAPARM_OUTPUT)
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Add("P7", strPara7, ORAPARM_OUTPUT)

    '        '�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(1) = gv_Odb_USR1.Parameters("P1")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(2) = gv_Odb_USR1.Parameters("P2")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(3) = gv_Odb_USR1.Parameters("P3")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(4) = gv_Odb_USR1.Parameters("P4")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(5) = gv_Odb_USR1.Parameters("P5")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(6) = gv_Odb_USR1.Parameters("P6")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(7) = gv_Odb_USR1.Parameters("P7")

    '        '�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(1).serverType = ORATYPE_CHAR
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(2).serverType = ORATYPE_CHAR
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(3).serverType = ORATYPE_CHAR
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(4).serverType = ORATYPE_CHAR
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(5).serverType = ORATYPE_NUMBER
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(6).serverType = ORATYPE_NUMBER
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        param(7).serverType = ORATYPE_VARCHAR2

    '        'PL/SQL�Ăяo��SQL
    '        strSQL = "BEGIN PRC_EXCTBZ(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"

    '        'DB�A�N�Z�X
    '        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    '        If bolRet = False Then
    '            GoTo AE_Execute_PLSQL_EXCTBZ_END
    '        End If

    '        '** �߂�l�擾
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        lngPara5 = param(5).Value
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        lngPara6 = param(6).Value
    '        'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
    '        If IsDBNull(param(7).Value) = False Then
    '            'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            strPara7 = param(7).Value
    '            Pot_strMsg = strPara7
    '        End If

    '        '�G���[���ݒ�
    '        gv_Int_OraErr = lngPara6
    '        gv_Str_OraErrText = strPara7

    '        AE_Execute_PLSQL_EXCTBZ = lngPara5

    'AE_Execute_PLSQL_EXCTBZ_END:
    '        '** �p�����^����
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Remove("P1")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Remove("P2")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Remove("P3")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Remove("P4")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Remove("P5")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Remove("P6")
    '        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        gv_Odb_USR1.Parameters.Remove("P7")

    '    End Function
    Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, ByRef Pot_strMsg As String) As Short

        '�߂�l
        Dim rtnVal As Short = 9

        'OracleCommand
        Dim cmd As New OracleCommand

        'PLSQL�p�����[�^�ϐ�
        Dim inP1 As OracleParameter = New OracleParameter  '���Ұ�1(�S���҃R�[�h)           
        Dim inP2 As OracleParameter = New OracleParameter  '���Ұ�2(�N���C�A���gID)           
        Dim inP3 As OracleParameter = New OracleParameter  '���Ұ�3(�����P�[�X)           
        Dim inP4 As OracleParameter = New OracleParameter  '���Ұ�4(�Ɩ��R�[�h(PGID))           
        Dim outP5 As OracleParameter = New OracleParameter '���Ұ�5(���A����)            
        Dim outP6 As OracleParameter = New OracleParameter '���Ұ�6(�װ����)            
        Dim outP7 As OracleParameter = New OracleParameter '���Ұ�7(�װ���e)         

        'PLSQL�߂�l
        Dim rtnP5 As Integer = 0
        Dim rtnP6 As Integer = 0
        Dim rtnP7 As String = ""

        Try
            Pot_strMsg = ""

            cmd.Connection = CON
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "PRC_EXCTBZ"

            '//���O�̐ݒ�
            inP1.ParameterName = "P1"
            inP2.ParameterName = "P2"
            inP3.ParameterName = "P3"
            inP4.ParameterName = "P4"
            outP5.ParameterName = "P5"
            outP6.ParameterName = "P6"
            outP7.ParameterName = "P7"

            '//IN/OUT�̐ݒ�
            inP1.Direction = ParameterDirection.Input
            inP2.Direction = ParameterDirection.Input
            inP3.Direction = ParameterDirection.Input
            inP4.Direction = ParameterDirection.Input
            outP5.Direction = ParameterDirection.Output
            outP6.Direction = ParameterDirection.Output
            outP7.Direction = ParameterDirection.Output

            '//�^�̐ݒ�
            inP1.OracleDbType = OracleDbType.Char
            inP2.OracleDbType = OracleDbType.Char
            inP3.OracleDbType = OracleDbType.Char
            inP4.OracleDbType = OracleDbType.Char
            outP5.OracleDbType = OracleDbType.Decimal
            outP6.OracleDbType = OracleDbType.Decimal
            outP7.OracleDbType = OracleDbType.Varchar2

            '//�l�̐ݒ�
            inP1.Value = Inp_Inf.InpTanCd
            inP2.Value = SSS_CLTID.Value
            inP3.Value = Pin_strPRCCASE
            inP4.Value = SSS_PrgId
            outP5.Value = 0
            outP6.Value = 0
            outP7.Value = ""

            '//�v���V�[�W�������s
            cmd.ExecuteNonQuery()

            '//�߂�l���擾
            rtnP5 = outP5.Value.ToString
            rtnP6 = outP6.Value.ToString
            If outP7.Value.ToString <> "null" Then
                rtnP7 = outP7.Value.ToString
                Pot_strMsg = rtnP7
            End If

            '�G���[���ݒ�
            gv_Int_OraErr = rtnP6
            gv_Str_OraErrText = rtnP7

            rtnVal = rtnP5

            '//�p�����[�^���N���A
            cmd.Parameters.Clear()

        Catch ex As Exception
            Throw ex

            'Finally 

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_Lock_EXCTBZ
	'   �T�v�F�@�r�����䏈��
	'   �����F�@Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������i�r���`�F�b�N���r���e�[�u���ւ̏������݁j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_Lock_EXCTBZ(ByRef Pot_strMsg As String) As Short
		
		Dim intRet As Short
        '2019/04/26 CHG START
        'Dim strMsg As String
        Dim strMsg As String = Nothing
        '2019/04/26 CHG E N D
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
        '2019/04/26 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/26 CHG E N D
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
        '2019/04/26 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/04/26 CHG E N D
        bolTrn = False
		
		CF_Chk_Lock_EXCTBZ = 0
		
		Exit Function
		
CF_Chk_Lock_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
            '2019/04/26 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/04/26 CHG E N D
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
        '2019/04/26 CHG START
        'Dim strMsg As String
        Dim strMsg As String = Nothing
        '2019/04/26 CHG E N D
        Dim bolTrn As Boolean
		
		On Error GoTo CF_Unlock_EXCTBZ_Err
		
		CF_Unlock_EXCTBZ = 9
		Pot_strMsg = ""
		bolTrn = False
		
		'�g�����U�N�V�����̊J�n
        '2019/04/26 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/26 CHG E N D
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
        '2019/04/26 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/04/26 CHG E N D
		bolTrn = False
		
		CF_Unlock_EXCTBZ = 0
		
		Exit Function
		
CF_Unlock_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
            '2019/04/26 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/04/26 CHG E N D
		End If
		
	End Function
    ' === 20061105 === INSERT E -


    'add start 20190820 kuwa
    'ACE_CMN�ɑ��݂��邪�A�����Ƀ����N�Q�Ɓi�ǉ��j������ƒ�`�������܂��ɂȂ邽�ߒǉ��B
    Public Function CF_ZeroLenFormat(ByRef pin_strIn As String, ByRef pin_intLength As Short, Optional ByRef pin_bolCut As Boolean = False) As String

        'local variable +---------------+---------------+---------------+---------------
        Dim strIn As String
        Dim strRet As String
        Dim intIdx As Short
        Dim strEdt As String
        'execute -------+---------------+---------------+---------------+---------------

        strIn = pin_strIn

        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(strIn) Then
            strIn = ""
        End If
        '���p�����`�F�b�N
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pin_strIn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Not (IsNumeric(strIn) And Len(pin_strIn) = LenWid(pin_strIn)) Then
            CF_ZeroLenFormat = strIn
            Exit Function
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(strIn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(strIn) > pin_intLength Then
            If pin_bolCut Then
                strRet = ""
                intIdx = Len(strIn)
                strEdt = Mid(strIn, intIdx, 1)
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(strRet + strEdt) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Do While LenWid(strRet & strEdt) <= pin_intLength
                    strRet = strEdt & strRet
                    intIdx = intIdx - 1
                    strEdt = Mid(strIn, intIdx, 1)
                Loop
            Else
                strRet = strIn
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(strIn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ElseIf LenWid(strIn) = pin_intLength Then
            strRet = strIn
        Else
            strRet = RightWid(New String("0", pin_intLength) & strIn, pin_intLength)
        End If

        CF_ZeroLenFormat = strRet

    End Function

    Public Function LenB(ByVal str As String) As Integer
        If String.IsNullOrEmpty(str) = True Then
            Return 0
        End If
        'Shift JIS�ɕϊ������Ƃ��ɕK�v�ȃo�C�g����Ԃ�
        Return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str)
    End Function

    Public Function LeftB(ByVal str As String, ByVal byteCount As Integer) As String
        If String.IsNullOrEmpty(str) = True Then
            Return ""
        End If

        Dim hEncode As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncode.GetBytes(str)

        If byteCount <= btBytes.Length Then
            Return hEncode.GetString(btBytes, 0, byteCount)
        End If

        Return str
    End Function

    Public Function MidB(ByVal str As String, ByVal startindex As Integer) As String
        If String.IsNullOrEmpty(str) = True Then
            Return ""
        End If

        Dim hEncode As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncode.GetBytes(str)

        If startindex <= btBytes.Length Then
            Dim byteCount As Integer = btBytes.Length - startindex + 1
            Return hEncode.GetString(btBytes, startindex - 1, byteCount)
        End If

        Return String.Empty
    End Function

    Public Function MidB(ByVal str As String, ByVal startindex As Integer, ByVal byteCount As Integer) As String
        If String.IsNullOrEmpty(str) = True Then
            Return ""
        End If

        Dim hEncode As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncode.GetBytes(str)

        If startindex <= btBytes.Length Then
            If (btBytes.Length - startindex) < byteCount Then
                byteCount = btBytes.Length - startindex + 1
            End If
            Return hEncode.GetString(btBytes, startindex - 1, byteCount)
        End If

        Return String.Empty
    End Function

    Public Function LenWid(ByVal pm_Characters As Object) As Object
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(pm_Characters) Then
            Call AE_SystemError("LenWid �̃p�����^��", 190)
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            LenWid = System.DBNull.Value
            Exit Function '--------------------
        End If
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Characters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/03/12 CHG START
        'LenWid = LenB(StrConv(pm_Characters, vbFromUnicode))
        LenWid = LenB(pm_Characters)
        '2019/03/12 CHG E N D
    End Function
    Public AE_Title As String
    Public Sub AE_Stop()
        'Dim LogF
        'Dim LogFName$
        'Dim I As Integer
        '    LogFName$ = App.Path & "\@ApplLog.LOG" '���O�t�@�C����
        '    LogF = FreeFile
        '    Open LogFName$ For Output As #LogF
        '    Print #LogF, "LogPointer = " & CStr(AE_LogPointer) & "     (Next Point to Log)"
        '    For I = 0 To 99
        '        Print #LogF, "Log[" & Right$("00" & CStr(I), 2) & "] = """ & AE_LogBody$(I) & """"
        '    Next I
        '    Close #LogF
        Call Error_Exit("AE_Stop �ɂ�钆�f")
        '   Stop
    End Sub
    Public Sub AE_SystemError(ByVal Pm_Msg As String, ByVal pm_ErrorId As Short)
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_MsgBox(Pm_Msg$ & �G���[������܂� (System Error & CStr(pm_ErrorId) & )�B���A�������肢�������܂��B, vbExclamation, AE_Title$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If AE_MsgBox(Pm_Msg & "�G���[������܂� (System Error" & CStr(pm_ErrorId) & ")�B���A�������肢�������܂��B", MsgBoxStyle.Exclamation, AE_Title) Then Call AE_Stop()
    End Sub

    Function AE_MsgBox(ByVal Pm_Msg As String, Optional ByVal Pm_MsgCode As Object = Nothing, Optional ByVal Pm_MsgTitle As Object = Nothing) As Object
        'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        If IsNothing(Pm_MsgCode) Then
            'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
            If IsNothing(Pm_MsgTitle) Then
                AE_MsgBox = MsgBox(Pm_Msg)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g Pm_MsgTitle �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                AE_MsgBox = MsgBox(Pm_Msg,  , Pm_MsgTitle)
            End If
        Else
            'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
            If IsNothing(Pm_MsgTitle) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Pm_MsgCode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                AE_MsgBox = MsgBox(Pm_Msg, Pm_MsgCode)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g Pm_MsgTitle �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Pm_MsgCode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                AE_MsgBox = MsgBox(Pm_Msg, Pm_MsgCode, Pm_MsgTitle)
            End If
        End If
    End Function

    Public Function RightB(ByVal str As String, ByVal byteCount As Integer) As String
        If String.IsNullOrEmpty(str) = True Then
            Return ""
        End If

        Dim hEncode As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncode.GetBytes(str)

        If byteCount <= btBytes.Length Then
            Return hEncode.GetString(btBytes, btBytes.Length - byteCount, byteCount)
        End If

        Return str
    End Function

    Public Function RightWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: RightB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/03/12 CHG START
        'RightWid = StrConv(RightB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
        RightWid = RightB(pm_Characters, pm_Wid)
        '2019/03/12 CHG E N D
    End Function


    'add end 20190820 kuwa

    'add start 20190821 kuwa
    Public Structure Cls_All
        '��ʊ�b���
        Dim Dsp_Base As Cls_Dsp_Base
        '��ʍ��ڏ��
        Dim Dsp_Sub_Inf() As Cls_Dsp_Sub_Inf
        '��ʃ{�f�B���
        'UPGRADE_WARNING: �\���� Dsp_Body_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Dsp_Body_Inf As Cls_Dsp_Body_Inf
        '�����ݒ�p�^�C�}�[
        Dim TM_StartUp_Ctl As System.Windows.Forms.Timer
        '���b�Z�[�W�d��
        '2019/03/12 CHG START
        'Dim Dsp_IM_Denkyu As System.Windows.Forms.Control '��ʕ\���p
        'Dim On_IM_Denkyu As System.Windows.Forms.Control '�d��ON
        'Dim Off_IM_Denkyu As System.Windows.Forms.Control '�d��Off
        Dim Dsp_IM_Denkyu As PictureBox '��ʕ\���p
        Dim On_IM_Denkyu As PictureBox  '�d��ON
        Dim Off_IM_Denkyu As PictureBox '�d��Off
        '2019/03/12 CHG E N D
        '���b�Z�[�W
        Dim Dsp_TX_Message As System.Windows.Forms.Control '��ʃ��b�Z�[�W
        '���׏c�X�N���[���o�[
        Dim Bd_Vs_Scrl As System.Windows.Forms.VScrollBar
        '�I���C���[�W���
        Dim IM_EndCm_Inf As Cls_Img_Inf
        '���s�C���[�W���
        Dim IM_Execute_Inf As Cls_Img_Inf
        '���[�v�����^�o�̓C���[�W���
        Dim IM_LSTART_Inf As Cls_Img_Inf
        '���[��ʕ\���C���[�W���
        Dim IM_VSTART_Inf As Cls_Img_Inf
        '�v�����^�ݒ�C���[�W���
        Dim IM_LCONFIG_Inf As Cls_Img_Inf
        '���גǉ��C���[�W���
        Dim IM_INSERTDE_Inf As Cls_Img_Inf
        '���׍폜�C���[�W���
        Dim IM_DELETEDE_Inf As Cls_Img_Inf
        '�����C���[�W���
        Dim IM_Slist_Inf As Cls_Img_Inf
        '�O�y�[�W�C���[�W���
        Dim IM_PrevCm_Inf As Cls_Img_Inf
        '���y�[�W�C���[�W���
        Dim IM_NextCm_Inf As Cls_Img_Inf
        '���ו��N���A�{�^���C���[�W���i���{�f�B������w�b�_���ɐ����߂��{�^���j
        Dim IM_SelectCm_Inf As Cls_Img_Inf
    End Structure


    '��ʃ{�f�B���\����
    Public Structure Cls_Dsp_Body_Inf
        Dim Cur_Top_Index As Short '�ŏ㖾�ײ��ޯ��
        Dim Row_Inf() As Cls_Dsp_Body_Row_Inf '�P�s�P�ʂ̏��
        'UPGRADE_WARNING: �\���� Init_Row_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Init_Row_Inf As Cls_Dsp_Body_Row_Inf '�������p�̂P�s�P�ʂ̏��
        Dim Rest_Inf As Cls_Dsp_Rest_Inf '�����s�̂P�s�P�ʂ̏��
    End Structure

    '-----------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------
    '��ʍ��ڏ��\����
    Public Structure Cls_Dsp_Sub_Inf
        Dim Ctl As System.Windows.Forms.Control '��ʃR���g���[��
        Dim Detail As Cls_Dsp_Sub_Detail_Inf '��ʍ��ڏڍ׏��
    End Structure
    '-----------------------------------------------------------------------------------------------------------

    '-----------------------------------------------------------------------------------------------------------
    '��ʊ�b���\����
    Public Structure Cls_Dsp_Base
        Dim Dsp_Ctg As String '��ʕ���(�Ɖ�n�A�o�^�n�A�C���n�j
        Dim Item_Cnt As Short '��ʍ��ڐ�
        Dim Dsp_Body_Cnt As Short '��ʕ\�����א��i�|�P,�O�F���ׂȂ��A�P�`�F�\�������א��j
        Dim Max_Body_Cnt As Short '�ő���͖��א��i�|�P�F���ׂȂ��A�O�F���׏�����P�`�F�\�������א��j
        Dim Body_Col_Cnt As Short '���ׂ̗񍀖ڐ�
        Dim Head_Lst_Idx As Short '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��
        Dim Body_Fst_Idx As Short '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��
        Dim Foot_Fst_Idx As Short '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��
        Dim Dsp_Body_Move_Qty As Short '��ʈړ��ʁi�ő彸۰ٗʁA�y�[�W�{�^���̈ړ��ʁj
        '�i�O�F���ׂȂ��A�P�`�F�ړ��ʁj
        Dim Cursor_Idx As Short '���݂�̫����̲��ޯ��
        Dim Bef_Cursor_Idx As Short '�P�O��̫����̲��ޯ��
        Dim Change_Flg As Boolean '��ݼ޲���Đ����׸�
        Dim VS_Scr_Flg As Boolean '��۰���ݼ޲���Đ����׸�
        Dim LostFocus_Flg As Boolean '۽�̫�������Đ����׸�
        Dim Head_Ok_Flg As Boolean '�w�b�_���`�F�b�N�n�j�t���O
        Dim PopupMenu_Idx As Short '�߯�߱����ƭ���̫����̲��ޯ��
        Dim Head2_Lst_Idx As Short '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��(���ϓo�^���ł̂ݎg�p)
        Dim Head3_Lst_Idx As Short '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��(�V�X�e���󒍓o�^���ł̂ݎg�p)
        ' === 20060907 === INSERT S - ACE)Sejima
        Dim IsUnload As Boolean '�I���������t���O�iQueryUnload�ŗ��Ă�j
        ' === 20060907 === INSERT E
        ' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
        Dim FormCtl As System.Windows.Forms.Form '�t�H�[���R���g���[���̊i�[
        ' === 20060920 === INSERT E
    End Structure
    '-----------------------------------------------------------------------------------------------------------

    '//��ʂ̲Ұ�ޏ��
    Public Structure Cls_Img_Inf
        Dim Click_On_Img As System.Windows.Forms.PictureBox
        Dim Click_Off_Img As System.Windows.Forms.PictureBox
    End Structure

    Public Structure Cls_Dsp_Sub_Detail_Inf
        '2019/03/12 CHG E N D
        Dim Item_Nm As String '��ʍ��ږ�(���۰ٖ�)
        Dim In_Area As String '��ʓ��͈�
        Dim In_Typ As Short '���̓^�C�v
        Dim In_Str_Typ As String '���͕����^�C�v
        Dim MaxLengthB As Short '�ő�o�C�g��
        Dim Dsp_MaxLengthB As Short '�\���ő�o�C�g��
        Dim Num_Int_Fig As Short '���l�̐�������
        Dim Num_Fra_Fig As Short '���l�̏���������
        Dim Num_Sign_Fig As Short '���l�}�t���O
        Dim Fil_Chr As String '�\�����̋l����
        Dim Fil_Point As Short '÷�ď�ŋl�߂镶���̈ʒu
        Dim Dsp_Fmt As String '�\������
        Dim Body_Index As Short '���ו��m�n�i�P�`�A�w�b�_/�t�b�^�̏ꍇ�́A�O�Œ�j
        '********�������ݒ肩��ύX����Ȃ��A����������ŕύX����***********************************************************
        Dim Dsp_Value As Object '��ʍ��ړ��e
        Dim Focus_Ctl As Boolean '�t�H�[�J�X����(T:̫����Ȃ��AF:̫�������)
        '�\��/���͂��؂�ւ��ꍇ�ɐݒ肷��
        ' === 20060829 === INSERT S - ACE)Sejima �������l�Z�b�g������
        Dim Def_Value As Object '���ڏ����l
        Dim Clr_Value As Object '���ڏ������p���e
        '���ꎞ�I�ɒl�����鎖�͂��邪�A��{�X�y�[�X
        ' === 20060829 === INSERT E
        Dim Focus_Ctl_Bk As Boolean '�ޔ��t�H�[�J�X����(�����������ɒ�`���ꂽFocus_Ctl�̐ݒ�ێ�����)
        Dim Bef_Value As Object '�O����e
        Dim Bef_Value_Flg As Short '�O����e�t���O
        Dim Rest_Value As Object '�������e
        Dim Rest_Value_Flg As Short '�������e�t���O
        Dim In_Value_Flg As Boolean '���̓t���O(T:հ�ް���͗L�AF:��ް���͖�)
        Dim Item_Init_Flg As Boolean '���ڏ������t���O(T:�������n�j�AF:�������m�f)
        Dim Item_Rest_Flg As Boolean '���ڕ����t���O(T:�����n�j�AF:�����m�f)
        Dim Bef_Chk_Value As Object '�O��`�F�b�N���e
        Dim Err_Status As String '���ڂ̃G���[���
        Dim Locked As Boolean '�ǎ��p�t���O
        Dim Not_Input_Chk_Fin_Flg As Boolean '�����͈ȊO�̃`�F�b�N�σt���O
        'T:�����͈ȊO�̃`�F�b�N�����s�����ꍇ
        'F:���̑��̏��
        Dim Chk_From_Process As String '�`�F�b�N�֐��ďo������
    End Structure
    '-----------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------
    '��ʃ{�f�B�s���\����
    Public Structure Cls_Dsp_Body_Row_Inf
        Dim Status As Short '�Ώۍs�̏��
        Dim Item_Detail() As Cls_Dsp_Sub_Detail_Inf '�P�s�Ɋi�[����鍀�ڏ��
        Dim Bus_Inf As Cls_Dsp_Body_Bus_Inf '�P�s�P�ʂ̋Ɩ����'�i�e�v���O������SSSMAIN0001�ŕK���錾����j
    End Structure

    '��ʃ{�f�B�����s���\����
    Public Structure Cls_Dsp_Rest_Inf
        Dim Rest_Flg As Short '�������̗L/��
        Dim Rest_Row As Short '�����s
        'UPGRADE_WARNING: �\���� Rest_Row_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Rest_Row_Inf As Cls_Dsp_Body_Row_Inf '�����s���
    End Structure
    'add start 20190821 kuwa

End Module