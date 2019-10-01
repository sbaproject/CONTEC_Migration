Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
'2019/04/17 ADD START AE_CMN�ǉ����������
Imports PronesDbAccess
Imports Oracle.DataAccess.Client
'2019/04/17 ADD EN D
Module SSSWIN


    '******************************************************************'
    '* PG��:URKET53 ��������
    '* �X�V��   : 2008/07/25
    '* �X�V��   : FKS)���c
    '* �������e : ���ׂ�2�s�ȏ゠��󒍂ɑ΂��A�ԕi�o�^���s������
    '*            �󒍒������s���Ɩ{���o�͑Ώۂɂ���Ȃ��f�[�^��
    '*            ��ʏ�ɏo�Ă��Ă��܂��̂��C��
    '******************************************************************'

    '2019/04/17 ADD START
    Public Const SSS_MAX_DB As Short = 22
    Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
    Public SSS_VALKB As Boolean '�L���f�[�^�敪(True=���׍s�Ȃ��ł̓o�^��)
    '�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
    Public PP_SSSMAIN As clsPP
    Public CP_SSSMAIN(169 + 23 + 0 + 1) As clsCP
    Public CL_SSSMAIN(169) As Short
    Public CQ_SSSMAIN(54) As String

    Public SSS_BILFL As Short '�r�����O���s�敪(1:���s/9:�Ȃ�)
    Public SSS_ReadOnly As Short

    ' MsgKB ���b�Z�[�W���
    Public Const SSS_EEE As String = "0" ' �������̃��b�Z�[�W
    Public Const SSS_ERROR As String = "2" ' �r�r�r�G���[���b�Z�[�W

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

    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim Dummy As String '�_�~�[
        Dim DKBID As String
        Dim DKBNM As String
        Dim KANKOZ As String
        Dim NYUKN As Decimal
        Dim FNYUKN As Double
        Dim BNKCD As String
        Dim BNKNM As String
        Dim JDNNO As String
        Dim JDNLINNO As String
        Dim STNNM As String
        Dim TEGDT As String
        Dim TEGNO As String
        Dim LINCMA As String
        Dim LINCMB As String
        Dim SYSTBD As TYPE_DB_SYSTBD
    End Structure
    '2019/04/17 ADD E N D

    '--------------------
    '���֐���
    '--------------------


    Public Function AnsiStrConv(ByRef varArg As Object, ByRef varCnv As Object) As Object
		'�T�v�F������̺��ޕϊ�
		'�����FvarArg,Input,Variant,�ϊ���������
		'�@�@�FvarCnv,Input,Variant,conversion�萔(StrConv �֐��Q��)
		'�����F�`������ �� �t�����b�������ɕϊ������������Ԃ�
		
#If Win32 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g varCnv �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g varArg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiStrConv = StrConv(varArg, varCnv)
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiStrConv = varArg
#End If
		
	End Function

    Public Function AnsiLenB(ByVal strArg As String) As Integer
        '�T�v�F�������J�E���g
        '�����FstrArg,Input,String,�Ώە�����
        '�����F�`�������R�[�h�̃o�C�g�I�[�_�ŕ�������޲Đ���Ԃ�

#If Win32 Then
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/04/17 CHG START
        'AnsiLenB = LenB(AnsiStrConv(strArg, vbFromUnicode))
        AnsiLenB = LenB(strArg)
        '2019/04/17 CHG E N D
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiLenB = LenB(strArg)
#End If

    End Function

    '2019/04/17 DEL START
    '   Public Function LenWid(ByVal pm_Characters As Object) As Object
    '	'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
    '	If IsDbNull(pm_Characters) Then
    '		'        Call AE_SystemError("LenWid �̃p�����^��", 190)
    '		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
    '		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		LenWid = System.DBNull.Value
    '		Exit Function '--------------------
    '	End If
    '	'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_Characters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '	LenWid = LenB(StrConv(pm_Characters, vbFromUnicode))
    'End Function
    '2019/04/17 DEL E N D

    '2019/04/17 DEL START
    'Public Function LeftWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
    '    'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '    'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '    'UPGRADE_ISSUE: LeftB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '    LeftWid = StrConv(LeftB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
    'End Function
    '2019/04/17 DEL E N D

    '2019/04/17 DEL START
    '   Public Function MidWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer, Optional ByVal pm_LnWid As Object = Nothing) As String
    '	'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
    '	If IsNothing(pm_LnWid) Then
    '		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '		'UPGRADE_ISSUE: MidB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '		MidWid = StrConv(MidB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
    '	Else
    '		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '		'UPGRADE_ISSUE: MidB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '		MidWid = StrConv(MidB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid, pm_LnWid), vbUnicode)
    '	End If
    'End Function
    '2019/04/17 DEL E N D

    '2019/04/17 DEL START
    'Public Function RightWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
    '	'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '	'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '	'UPGRADE_ISSUE: RightB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '	RightWid = StrConv(RightB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
    'End Function
    '2019/04/17 DEL E N D

    Function Get_DBHEAD() As String
		'���݂̊���DBHEAD ��Ԃ��A�����ݒ�̏ꍇ�́A""��Ԃ��B
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		
		Get_DBHEAD = ""
		ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr.Value, 128, "SSSWIN.INI")
		If ret > 0 Then Get_DBHEAD = Left(wkStr.Value, ret)
	End Function

    '2019/04/19�@DEL START ��
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Init
    '   �T�v�F  �v���O�����N������������
    '   �����F  �Ȃ�
    '   �ߒl�F  �Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Sub CF_Init()
    Public Sub CF_Init_URKET53()

        'Dim datDT           As Date
        'Dim strYMD          As String
        'Dim strUNYDT        As String
        Dim intLenCommand As String
        'Dim intRet          As Integer

        '��d�N������
        'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '2019/04/17 DEL START
        'If App.PrevInstance Then
        '    MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/04/17 DEL E N D

        '// V2.00�� ADD
        ' "���΂炭���҂���������" �E�B���h�E�\��
        'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        '2019/04/17 CHG START
        'Load(ICN_ICON)
        ICN_ICON.Show()
        '2019/04/17 CHG E N D
        '// V2.00�� ADD

        '---------------------
        ' �N���p�����[�^�ݒ�
        '---------------------
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        intLenCommand = LenWid(Trim(VB.Command()))
        If CDbl(intLenCommand) < 15 Then
            MsgBox("���j���[������s���Ă��������B", MsgBoxStyle.OkOnly, SSS_PrgNm)
            End
            'Call Error_Exit("���j���[������s���Ă��������B")
        End If

        SSS_CLTID.Value = MidWid(VB.Command(), 2, 5)
        SSS_OPEID.Value = MidWid(VB.Command(), 7, 6)

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

        '// V2.00�� ADD
        ' "���΂炭���҂���������" �E�B���h�E����
        ICN_ICON.Close()
        '// V2.00�� ADD

    End Sub
    '2019/04/19 DEL E N D

    Function SSSVal(ByRef INP_Value As Object) As Object
		If IsNumeric(INP_Value) = True Then
			'UPGRADE_WARNING: �I�u�W�F�N�g INP_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSVal = CDec(INP_Value)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSVal = 0
		End If
	End Function
	
	Function CNV_DATE(ByRef pdate As String) As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pdate) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(pdate) = 8 Then
			CNV_DATE = LeftWid(pdate, 4) & "/" & MidWid(pdate, 5, 2) & "/" & RightWid(pdate, 2)
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pdate) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf LenWid(pdate) = 6 Then 
			CNV_DATE = LeftWid(pdate, 2) & "/" & MidWid(pdate, 3, 2) & "/" & RightWid(pdate, 2)
		Else
			CNV_DATE = ""
		End If
	End Function
	
	Function DeCNV_DATE(ByRef pdate As String) As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pdate) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(pdate) = 10 Then
			DeCNV_DATE = LeftWid(pdate, 4) & MidWid(pdate, 6, 2) & RightWid(pdate, 2)
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pdate) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf LenWid(pdate) = 8 Then 
			DeCNV_DATE = LeftWid(pdate, 2) & MidWid(pdate, 4, 2) & RightWid(pdate, 2)
		Else
			DeCNV_DATE = ""
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_INIT_GETINI
	'   �T�v�F  INI�t�@�C���Ǎ��݁i���ʁj
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub CF_INIT_GETINI()
		Dim WL_WinDir As String
		Dim i, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		'---------------------
		' SSSWIN.INI �Ǎ���
		'---------------------
		For i = 0 To SSS_INICnt
            rtnPara.Value = ""
            '2019/04/23 CHG START
            'LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(i), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
            LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(i), "", rtnPara.Value, Len(rtnPara.Value), Application.StartupPath & "\SSSWIN.INI")
            '2019/04/23 CHG E N D

            If LENGTH = 0 Then
				MsgBox("SSSWIN.INI ���m�F���Ă��������B" & Chr(13) & "[" & strINIDATNM(i) & "]")
				'            Call Error_Exit("SSSUSR.INI ���m�F���Ă��������B[" & strINIDATNM(I) & "]")
			Else
				SSS_INIDAT(i) = LeftWid(rtnPara.Value, LENGTH)
			End If
			If Right(SSS_INIDAT(i), 1) <> "\" And Right(SSS_INIDAT(i), 1) <> ":" Then SSS_INIDAT(i) = SSS_INIDAT(i) & "\"
		Next i
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   �����F  Pin_strDate     : �v�Z�Ώۓ��t(�W���̐��lOr���t�j
	'           Pin_strTOKSMEKB : ���敪
	'           Pin_strTOKSMEDD : ���������t�i����j
	'           Pin_strTOKSMECC : ���T�C�N���i����j
	'           Pin_strTOKSDWKB : ���ߗj��
	'   ���l�F����(Saito 2007/02/24)
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function getSmedt(ByVal pin_strDate As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKSMEDD As String, ByVal Pin_strTOKSMECC As String, ByVal Pin_strTOKSDWKB As String) As String
		
		Dim strDate As String
		Dim yy As Short
		Dim mm As Short
		Dim dd As Short
		Dim Cnt As Short
		Dim i As Short
		Dim setidx As Short
		Dim idx As Short
		Dim addMM As Short
		Dim smeday(15) As Short
		Dim intToksmeCc As Short
		Dim intToksmeDD As Short
		Dim intTOKSDWKB As Short
		Dim strSmedt As String
		
		getSmedt = ""
		
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
		
		'���敪��"��"�̏ꍇ
		If CDbl(Pin_strTOKSMEKB) = 1 Then
			'���������t�擾
			If IsNumeric(Pin_strTOKSMEDD) = True Then
				intToksmeDD = CShort(Pin_strTOKSMEDD)
			Else
				Exit Function
			End If
			
			'���T�C�N���擾
			If IsNumeric(Pin_strTOKSMECC) = True Then
				intToksmeCc = CShort(Pin_strTOKSMECC)
			Else
				Exit Function
			End If
			
			If intToksmeCc = 1 Then '��������
				getSmedt = DeCNV_DATE(CStr(DateSerial(yy, mm, dd)))
				Exit Function
			End If
			'
			If intToksmeCc <= 0 Or intToksmeCc > 15 Then intToksmeCc = 30
			Cnt = Int(30 / intToksmeCc) '���񐔁^��
			setidx = False
			For i = 0 To Cnt - 1
				smeday(i) = intToksmeDD + intToksmeCc * i
				If smeday(i) > 27 Then smeday(i) = 99
				If dd <= smeday(i) And setidx = False Then
					'idx = I + Pin_intCHTNKB '�Y�����t�̒����z��Y��
					setidx = True
				End If
			Next i
			If setidx = False Then idx = Cnt '+ Pin_intCHTNKB
			addMM = Int(idx / Cnt)
			idx = idx Mod Cnt
			If idx < 0 Then idx = idx + Cnt
			'
			If smeday(idx) = 99 Then
				strSmedt = CStr(DateSerial(yy, mm + addMM + 1, 0))
			Else
				strSmedt = CStr(DateSerial(yy, mm + addMM, smeday(idx)))
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
				strSmedt = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (7 - WeekDay(CDate(strDate)) + intTOKSDWKB)))
			Else
				strSmedt = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (intTOKSDWKB - WeekDay(CDate(strDate)))))
			End If
		End If
		
		getSmedt = DeCNV_DATE(strSmedt)
		
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function GET_MEIMTA_KANKOZ
	'   �T�v�F ���̃}�X�^���݃`�F�b�N
	'   �����F pin_MEICDA   : ���̃L�[
	'   �ߒl�F 0:����I�� 9:�ُ�I�� 8:�폜�ς݃��R�[�h
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_MEIMTA_KANKOZ(ByVal pin_MEICDA As String) As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim strMEICDA As String
		
		On Error GoTo ERR_GET_MEIMTA_KANKOZ
		
		GET_MEIMTA_KANKOZ = 9
		
		strMEICDA = Trim(pin_MEICDA) & Space(10)
		
		strSql = ""
		strSql = strSql & vbCrLf & "Select * From MEIMTA"
		strSql = strSql & vbCrLf & " Where KEYCD    = '062'"
		strSql = strSql & vbCrLf & "   And MEICDA   = " & "'" & Mid(Trim(strMEICDA) & Space(20), 2, 9) & "'"
		strSql = strSql & vbCrLf & "   And MEICDB   = " & "'" & Left(Trim(strMEICDA) & Space(5), 1) & "'"

        'DB�A�N�Z�X
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        ''// V2.00�� UPD
        ''        GET_MEIMTA_KANKOZ = 0
        'Select Case CF_Ora_GetDyn(Usr_Ody, "DATKB", "")

        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            Select Case DB_NullReplace(dt.Rows(0)("DATKB"), "")
                '2019/04/23 CHG E N D
                Case "1"
                    GET_MEIMTA_KANKOZ = 0
                Case "9"
                    GET_MEIMTA_KANKOZ = 8
            End Select
            '// V2.00�� UPD

            GoTo END_GET_MEIMTA_KANKOZ
        End If

END_GET_MEIMTA_KANKOZ:
        '�N���[�Y
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
ERR_GET_MEIMTA_KANKOZ: 
		GoTo END_GET_MEIMTA_KANKOZ
		
	End Function

    '2019/04/26 DEL START
    '   '**************************************************************************************************
    '   '�v���V�W����   �FGet_Authority
    '   '�����T�v       �F�v���O�����̎��s�������擾����
    '   '                 CrystalReport�̃v���r���[��ʂ̈���{�^�������[�U�����ɂ���Đ��䂷��
    '   '����   �P�Fec_DATE(�S���҂̓K�p���𔻒f������t)
    '   '       �Q�Fec_CRW(CrystalReport�R���g���[����) �I�v�V����
    '   '�ߒl   1�F�����}�X�^�Ƀf�[�^�L��
    '   '       9�F�����}�X�^�Ƀf�[�^�Ȃ�
    '   '**************************************************************************************************
    '   Public Function Get_Authority(ByRef ec_DATE As String, Optional ByRef ec_CRW As Object = Nothing) As String

    '	'�ϐ��錾
    '	Dim strSql As String
    '	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '	Dim Usr_Ody As U_Ody

    '	'�����l�͑S�����Ȃ�
    '	gs_UPDAUTH = "9" '�X�V����
    '	gs_PRTAUTH = "9" '�������
    '	gs_FILEAUTH = "9" '�t�@�C���o�͌���
    '	gs_SALTAUTH = "9" '�̔��P���ύX����
    '	gs_HDNTAUTH = "9" '�����P���ύX����
    '	gs_SAPMAUTH = "9" '�̔��v��N���v��C������

    '	'���[�UID�������������擾����
    '	strSql = "Select"
    '	strSql = strSql & " K.UPDAUTH"
    '	strSql = strSql & ",K.PRTAUTH"
    '	strSql = strSql & ",K.FILEAUTH"
    '	strSql = strSql & ",K.SALTAUTH"
    '	strSql = strSql & ",K.HDNTAUTH"
    '	strSql = strSql & ",K.SAPMAUTH"
    '	strSql = strSql & " From KNGMTB K"
    '	strSql = strSql & "     ,TANMTA T"
    '	strSql = strSql & " Where K.KNGGRCD = (CASE WHEN T.TANTKDT <= '" & ec_DATE & "' THEN T.KNGGRCD ELSE T.OLDGRCD END)"
    '	strSql = strSql & "   And T.TANCD   = " & "'" & Trim(SSS_OPEID.Value) & "'"
    '	strSql = strSql & "   And K.PGID    = " & "'" & SSS_PrgId & "'"
    '	strSql = strSql & "   And K.DATKB   = '1'"
    '	strSql = strSql & "   And T.DATKB   = '1'"

    '       '2019/04/23 CHG START
    '       'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    '       'If CF_Ora_EOF(Usr_Ody) = True Then
    '       '	'�擾�f�[�^�Ȃ��̏ꍇ�͌����Ȃ��Ƃ݂Ȃ��B
    '       '	Get_Authority = CStr(9)
    '       'Else
    '       '	Do While CF_Ora_EOF(Usr_Ody) = False

    '       '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       '		gs_UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "") '�X�V����
    '       '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       '		gs_PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "") '�������
    '       '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       '		gs_FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "") '�t�@�C���o�͌���
    '       '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       '		gs_SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "") '�̔��P���ύX����
    '       '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       '		gs_HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "") '�����P���ύX����
    '       '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       '		gs_SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "") '�̔��v��N���v��C������

    '       '		'�����R�[�h
    '       '		'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       '		Usr_Ody.Obj_Ody.MoveNext()
    '       '	Loop 
    '       '	Get_Authority = CStr(1)
    '       'End If
    '       Dim dt As DataTable = DB_GetTable(strSql)

    '       If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '           '�擾�f�[�^�Ȃ��̏ꍇ�͌����Ȃ��Ƃ݂Ȃ��B
    '           Get_Authority = CStr(9)
    '       Else
    '           For i As Integer = 0 To dt.Rows.Count - 1
    '               gs_UPDAUTH = DB_NullReplace(dt.Rows(i)("UPDAUTH"), "") '�X�V����
    '               gs_PRTAUTH = DB_NullReplace(dt.Rows(i)("PRTAUTH"), "") '�������
    '               gs_FILEAUTH = DB_NullReplace(dt.Rows(i)("FILEAUTH"), "") '�t�@�C���o�͌���
    '               gs_SALTAUTH = DB_NullReplace(dt.Rows(i)("SALTAUTH"), "") '�̔��P���ύX����
    '               gs_HDNTAUTH = DB_NullReplace(dt.Rows(i)("HDNTAUTH"), "") '�����P���ύX����
    '               gs_SAPMAUTH = DB_NullReplace(dt.Rows(i)("SAPMAUTH"), "") '�̔��v��N���v��C������
    '           Next
    '       End If
    '       '2019/04/23 CHG E N D

    '       If ec_CRW Is Nothing Then
    '	Else
    '		If gs_PRTAUTH = "1" Then
    '			'�������������ꍇ
    '			'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowPrintBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			ec_CRW.WindowShowPrintBtn = True '����{�^��
    '		Else
    '			'��������������ꍇ
    '			'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowPrintBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			ec_CRW.WindowShowPrintBtn = False '����{�^��
    '		End If
    '		If gs_FILEAUTH = "1" Then
    '			'�G�N�X�|�[�g����������ꍇ
    '			'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowExportBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			ec_CRW.WindowShowExportBtn = True '�G�N�X�|�[�g�{�^��
    '		Else
    '			'�G�N�X�|�[�g�����������ꍇ
    '			'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowExportBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			ec_CRW.WindowShowExportBtn = False '�G�N�X�|�[�g�{�^��
    '		End If
    '	End If

    'End Function
    '2019/04/26 DEL E N D

    Function Get_Acedt(ByVal wdate As String) As String
		' �Y���o�������t
		
		wdate = CNV_DATE(wdate)
		'    If Not CHECK_DATE(wdate) Then
		'        Call Error_Exit("���t�G���[(Get_Acedt): " & wdate)
		'    End If
		If DB_SYSTBA.SMADD > "27" Then
			Get_Acedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, 0))
		ElseIf Right(wdate, 2) <= DB_SYSTBA.SMADD Then 
			Get_Acedt = Left(wdate, 8) & DB_SYSTBA.SMADD
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYSTBA.SMADD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Get_Acedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, SSSVal(DB_SYSTBA.SMADD)))
		End If
	End Function
	
	'// V2.04�� UPD
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function GET_TANMTA_KEIBMNCD
	'   �T�v�F  �o������R�[�h���擾
	'   �����F�@pot_TANCD       : �S���҃R�[�h
	'       �F�@pot_KEIBMNCD    : �o������R�[�h
	'   �ߒl�F�@0:����I�� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_TANMTA_KEIBMNCD(ByRef pot_TANCD As String, ByRef pot_KEIBMNCD As String) As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		' === 20081015 === ADD    S - RISE)Miyajima �A���[��664
		Dim strKEIBMNCD As String '��������R�[�h
		Dim strOLDBMNCD As String '����������R�[�h
		Dim strTANTKDT As String '�K�p��
		Dim strZMBMNCD As String '��v����R�[�h
		' === 20081015 === ADD    E - RISE)Miyajima
		
		On Error GoTo ERR_GET_TANMTA_KEIBMNCD
		
		GET_TANMTA_KEIBMNCD = 9
		
		' === 20081015 === UPDATE S - RISE)Miyajima �A���[��664
		'    strSql = ""
		'    strSql = strSql & "Select KEIBMNCD From TANMTA"
		'    strSql = strSql & " Where TANCD  = " & "'" & pot_TANCD & "'"
		'
		'    'DB�A�N�Z�X
		'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		'
		'    If CF_Ora_EOF(Usr_Ody) = False Then
		'        pot_KEIBMNCD = CF_Ora_GetDyn(Usr_Ody, "KEIBMNCD", "")
		'        GET_TANMTA_KEIBMNCD = 0
		'
		'        GoTo END_GET_TANMTA_KEIBMNCD
		'    End If
		
		'�S���҂l
		strSql = ""
		strSql = strSql & "Select TANBMNCD,OLDBMNCD,TANTKDT From TANMTA"
		strSql = strSql & " Where TANCD  = " & "'" & pot_TANCD & "'"

        'DB�A�N�Z�X
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	strKEIBMNCD = CF_Ora_GetDyn(Usr_Ody, "TANBMNCD", "")
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	strOLDBMNCD = CF_Ora_GetDyn(Usr_Ody, "OLDBMNCD", "")
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	strTANTKDT = CF_Ora_GetDyn(Usr_Ody, "TANTKDT", "")
        'Else
        '	GoTo END_GET_TANMTA_KEIBMNCD
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strKEIBMNCD = DB_NullReplace(dt.Rows(0)("TANBMNCD"), "")
            strOLDBMNCD = DB_NullReplace(dt.Rows(0)("OLDBMNCD"), "")
            strTANTKDT = DB_NullReplace(dt.Rows(0)("TANTKDT"), "")
        Else
            GoTo END_GET_TANMTA_KEIBMNCD
        End If
        '2019/04/23 CHG E N D

        '����l
        strSql = ""
		strSql = strSql & "Select ZMBMNCD From BMNMTA"
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(strTANTKDT) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(gstrKesidt) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(gstrKesidt.Value) >= SSSVal(strTANTKDT) Then
			strSql = strSql & " Where BMNCD = " & "'" & strKEIBMNCD & "'"
		Else
			strSql = strSql & " Where BMNCD = " & "'" & strOLDBMNCD & "'"
		End If
		strSql = strSql & "   and " & "'" & gstrKesidt.Value & "'" & " BETWEEN STTTKDT AND ENDTKDT "

        'DB�A�N�Z�X
        '2019/04/23 CHG START
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	strZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "")
        'Else
        '	GoTo END_GET_TANMTA_KEIBMNCD
        'End If
        dt = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strZMBMNCD = DB_NullReplace(dt.Rows(0)("ZMBMNCD"), "")
        Else
            GoTo END_GET_TANMTA_KEIBMNCD
        End If
        '2019/04/23 CHG E N D

        '�o������R�[�h�������֐ݒ肷��
        pot_KEIBMNCD = strZMBMNCD
		
		' === 20081015 === UPDATE E - RISE)Miyajima
		
		GET_TANMTA_KEIBMNCD = 0
		
END_GET_TANMTA_KEIBMNCD:
        '�N���[�Y
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
ERR_GET_TANMTA_KEIBMNCD: 
		GoTo END_GET_TANMTA_KEIBMNCD
		
	End Function
	'// V2.04�� UPD
	
	Function SSS_WEEKNM(ByVal idx As Short) As String
		' �j������Ԃ��B
		Select Case idx
			Case 1
				SSS_WEEKNM = "���j��"
			Case 2
				SSS_WEEKNM = "���j��"
			Case 3
				SSS_WEEKNM = "�Ηj��"
			Case 4
				SSS_WEEKNM = "���j��"
			Case 5
				SSS_WEEKNM = "�ؗj��"
			Case 6
				SSS_WEEKNM = "���j��"
			Case 7
				SSS_WEEKNM = "�y�j��"
			Case Else
				SSS_WEEKNM = ""
		End Select
	End Function
	
	'���O�t�@�C���̏����o��
	'�኱����
	Sub SSSWIN_LOGWRT(ByVal LogMsg As String)
		Dim errcnt, Fno, rtn As Short
		Dim wbuf As String
        '    '
        '    Call ResetDBSTAT(DBN_SYSTBE)
        '    '
        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '2019/04/17 DEL START
        'DB_SYSTBE = LSet(DB_CLRREC)
        '2019/04/17 DEL E N D
        DB_SYSTBE.PRGID = SSS_PrgId
		DB_SYSTBE.LOGNM = LogMsg
		DB_SYSTBE.OPEID = SSS_OPEID.Value
		DB_SYSTBE.CLTID = SSS_CLTID.Value
		DB_SYSTBE.WRTTM = VB6.Format(Now, "hhnnss")
		DB_SYSTBE.WRTDT = VB6.Format(Now, "YYYYMMDD")
		
		errcnt = 0
		Fno = FreeFile
		On Error Resume Next
		'�f�B���N�g�����݃`�F�b�N
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		wbuf = Dir(SSS_INIDAT(1), 16)
		If wbuf = "" Then
			Call MsgBox("SSSWIN.INI �� DAT_PATH �̐ݒ肳��Ă���f�B���N�g�������݂��܂���B" & Chr(13) & "SSSWIN.INI���C�����ĉ������B", 48)
			'Call WRT_ERRLOG(0, "              USR_PATH=" & USR_PATH)
			'''Call SSS_CLOSE
			rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
			End
		End If
		Err.Clear()
		On Error GoTo ErrorLogFile
        'FileOpen(Fno, SSS_INIDAT(1) & SSS_PrgId & ".DTA", OpenMode.Append, OpenAccess.Write, OpenShare.LockWrite)
        ''    Open SSS_INIDAT(1) & "SYSTBE.DTA" For Append Access Write Lock Write As Fno
        'On Error GoTo 0
        ''    Print #Fno, SSS_PrgId & LogMsg & SSS_OPEID & SSS_CLTID & Format$(Now, "hhnnss") & Format$(Now, "YYYYMMDD")
        'PrintLine(Fno, DB_SYSTBE.PRGID & DB_SYSTBE.LOGNM & DB_SYSTBE.OPEID & DB_SYSTBE.CLTID & DB_SYSTBE.WRTTM & DB_SYSTBE.WRTDT)
        'FileClose(Fno)
        Exit Sub
ErrorLogFile: 
		errcnt = errcnt + 1
		If errcnt > SSS_ReTryCnt Then
			If MsgBox("�����t�@�C�����b�N�G���[ !" & Chr(13) & "���~���Ă��X�����ł����H", 20) = 6 Then
				'''Call SSS_CLOSE
				rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
				End
			Else
				errcnt = 0
			End If
		End If
		System.Windows.Forms.Application.DoEvents()
		Resume 
	End Sub
	
	'Sub ResetBuf(ByVal Fno As Integer)  'Generated.
	'End Sub
	'
	
	'=======================================================Saito�쐬��=======================================================
	
	
	'��۰��ٕϐ��̏�����
	Public Sub initVal()
		gstrKesidt.Value = Space(8)
		'// V2.00�� UPD
		''    gstrKaidt = Space(8)
		gstrKaidt_Fr.Value = Space(8)
		gstrKaidt_To.Value = Space(8)
		gstrTokseicd.Value = Space(5)
		'// V2.00�� UPD
		gstrFridt.Value = Space(8)

        '20190621 CHG START
        'With DB_TOKMTA
        With DB_TOKMTA2
            '20190621 CHG END

            .TOKSEICD = Space(5)
            .TOKNMA = Space(60)
            .TOKSMEDT = Space(8)
            .SHAKB = Space(1)
            .SHAKBNM = Space(10)
            .TOKSMEKB = Space(1)
            .TOKSMEDD = Space(2)
            .TOKSMECC = Space(2)
            .TOKSDWKB = Space(1)
            .TOKKESDD = Space(2)
            .TOKKESCC = Space(2)
            .HYTOKKESDD = Space(2)
            .TOKKDWKB = Space(1)
            .KESISMEDT = Space(8)
            .FRNKB = Space(1)
            .TUKKB = Space(3)
            .TOKJUNKB = Space(1)
            .TOKMSTKB = Space(1)
            .TKNRPSKB = Space(1)
            .TKNZRNKB = Space(1)
            .TOKZEIKB = Space(1)
            .TOKZCLKB = Space(1)
            .TOKRPSKB = Space(1)
            .TOKZRNKB = Space(1)
            .TOKNMMKB = Space(1)
        End With
    End Sub
	
	'�^�p�����t���擾����
	Public Function getUnydt() As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String

        strSql = "SELECT unydt FROM unymta"
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'getUnydt = CF_Ora_GetDyn(Usr_Ody, "unydt", "")
        Dim dt As DataTable = DB_GetTable(strSql)
        getUnydt = DB_NullReplace(dt.Rows(0)("unydt"), "")
        '2019/04/23 CHG E N D

        GV_UNYDate = getUnydt '2007.03.05

        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D
    End Function

    'SYSTBA�����擾����
    Public Sub getSYSTBA()
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String

        strSql = "SELECT * FROM systba"
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_SYSTBA.SMAUPDDT = CF_Ora_GetDyn(Usr_Ody, "smaupddt", "")
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_SYSTBA.MONUPDDT = CF_Ora_GetDyn(Usr_Ody, "monupddt", "")
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_SYSTBA.SMADD = CF_Ora_GetDyn(Usr_Ody, "smadd", "")
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            DB_SYSTBA.SMAUPDDT = DB_NullReplace(dt.Rows(0)("smaupddt"), "")
            DB_SYSTBA.MONUPDDT = DB_NullReplace(dt.Rows(0)("monupddt"), "")
            DB_SYSTBA.SMADD = DB_NullReplace(dt.Rows(0)("smadd"), "")
        End If
        '2019/04/23 CHG E N D
    End Sub
	
	'�S���Җ����擾����
	Public Function getTannm(ByRef strTancd As String) As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String

        strSql = "SELECT tannm FROM tanmta" & " WHERE tancd = '" & strTancd & "'"

        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'getTannm = CF_Ora_GetDyn(Usr_Ody, "tannm", "")

        'Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
        Dim dt As DataTable = DB_GetTable(strSql)
        getTannm = DB_NullReplace(dt.Rows(0)("tannm"), "")
        '2019/04/23 CHG E N D
    End Function
	
	'���ݓ��t�A�������Z�b�g����
	Public Sub setSysdate(ByRef strWRTTM As String, ByRef strWRTDT As String)
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		strSql = "SELECT TO_CHAR(SYSDATE, 'HH24MISS') wrttm, " & "TO_CHAR(SYSDATE, 'YYYYMMDD') wrtdt " & "FROM dual"

        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	strWRTTM = CF_Ora_GetDyn(Usr_Ody, "wrttm", "")
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	strWRTDT = CF_Ora_GetDyn(Usr_Ody, "wrtdt", "")
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strWRTTM = DB_NullReplace(dt.Rows(0)("wrttm"), "")
            strWRTDT = DB_NullReplace(dt.Rows(0)("wrtdt"), "")
        End If
        '2019/04/23 CHG E N D
    End Sub
	
	'�����於���擾����(�����Ɏx�������A���������A�������ɂ�����������擾)
	'0:���������
	'1:�C�O�����
	'8:������ł͂Ȃ����Ӑ�
	'9:�Y���f�[�^�Ȃ�
	Public Function getTokseinm(ByRef strKesidt As String, ByVal strTokseicd As String) As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		'�x�������̖��̐錾
		Dim SHAKB_NAME() As Object
		
		getTokseinm = 9
		
		'UPGRADE_WARNING: Array �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		SHAKB_NAME = New Object(){"", "�U��", "��`", "�U���܂��͎�`", "�U����`���p", "�����U��", "̧���ݸ�"}
		
		strSql = "SELECT * FROM tokmta " & "WHERE tokcd = '" & strTokseicd & "' " & "AND tokcd = tokseicd"

        'DB�A�N�Z�X
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	With DB_TOKMTA
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKNMA = CF_Ora_GetDyn(Usr_Ody, "toknma", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKRN = CF_Ora_GetDyn(Usr_Ody, "tokrn", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKSMEDT = CF_Ora_GetDyn(Usr_Ody, "toksmedt", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.SHAKB = CF_Ora_GetDyn(Usr_Ody, "shakb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		'UPGRADE_WARNING: �I�u�W�F�N�g SHAKB_NAME(SSSVal()) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.SHAKBNM = SHAKB_NAME(SSSVal(CF_Ora_GetDyn(Usr_Ody, "shakb", "")))

        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "toksmekb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "toksmedd", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKSMECC = CF_Ora_GetDyn(Usr_Ody, "toksmecc", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "toksdwkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "tokkescc", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "tokkesdd", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "tokkdwkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.FRNKB = CF_Ora_GetDyn(Usr_Ody, "frnkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TUKKB = CF_Ora_GetDyn(Usr_Ody, "tukkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKJUNKB = CF_Ora_GetDyn(Usr_Ody, "tokjunkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "tokmstkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TKNRPSKB = CF_Ora_GetDyn(Usr_Ody, "tknrpskb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TKNZRNKB = CF_Ora_GetDyn(Usr_Ody, "tknzrnkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "tokzeikb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKZCLKB = CF_Ora_GetDyn(Usr_Ody, "tokzclkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKRPSKB = CF_Ora_GetDyn(Usr_Ody, "tokrpskb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKZRNKB = CF_Ora_GetDyn(Usr_Ody, "tokzrnkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "toknmmkb", "")
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.TANCD = CF_Ora_GetDyn(Usr_Ody, "tancd", "")

        '		If .TOKSMEKB = "1" Then
        '			'������
        '			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_TOKMTA.TOKSMEDD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			If SSSVal(.TOKSMEDD) > 27 Then
        '				.HYTOKKESDD = "����"
        '			Else
        '				.HYTOKKESDD = .TOKSMEDD & "��"
        '			End If
        '		Else
        '			'�T����
        '			.HYTOKKESDD = "�T��"
        '		End If

        '		'�������ɂ�����������擾
        '		.KESISMEDT = getSmedt(strKesidt, .TOKSMEKB, .TOKSMEDD, .TOKSMECC, .TOKSDWKB)

        '		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		getTokseinm = SSSVal(.FRNKB)
        '	End With
        'Else
        '	'������ł͂Ȃ����Ӑ�Ƃ��đ��݂����8��Ԃ� 2007/02/28 Add
        '	strSql = "SELECT * FROM tokmta WHERE tokcd = '" & strTokseicd & "'"
        '	Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        '	If CF_Ora_EOF(Usr_Ody) = True Then
        '		getTokseinm = 9
        '	Else
        '		getTokseinm = 8
        '	End If
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            '20190621 CHG START
            'With DB_TOKMTA
            With DB_TOKMTA2
                '20190621 CHG END

                .TOKSEICD = DB_NullReplace(dt.Rows(0)("tokseicd"), "")
                .TOKNMA = DB_NullReplace(dt.Rows(0)("toknma"), "")
                .TOKRN = DB_NullReplace(dt.Rows(0)("tokrn"), "")
                .TOKSMEDT = DB_NullReplace(dt.Rows(0)("toksmedt"), "")
                .SHAKB = DB_NullReplace(dt.Rows(0)("shakb"), "")
                .SHAKBNM = SHAKB_NAME(SSSVal(DB_NullReplace(dt.Rows(0)("shakb"), "")))
                .TOKSMEKB = DB_NullReplace(dt.Rows(0)("toksmekb"), "")
                .TOKSMEDD = DB_NullReplace(dt.Rows(0)("toksmedd"), "")
                .TOKSMECC = DB_NullReplace(dt.Rows(0)("toksmecc"), "")
                .TOKSDWKB = DB_NullReplace(dt.Rows(0)("toksdwkb"), "")
                .TOKKESCC = DB_NullReplace(dt.Rows(0)("tokkescc"), "")
                .TOKKESDD = DB_NullReplace(dt.Rows(0)("tokkesdd"), "")
                .TOKKDWKB = DB_NullReplace(dt.Rows(0)("tokkdwkb"), "")
                .FRNKB = DB_NullReplace(dt.Rows(0)("frnkb"), "")
                .TUKKB = DB_NullReplace(dt.Rows(0)("tukkb"), "")
                .TOKJUNKB = DB_NullReplace(dt.Rows(0)("tokjunkb"), "")
                .TOKMSTKB = DB_NullReplace(dt.Rows(0)("tokmstkb"), "")
                .TKNRPSKB = DB_NullReplace(dt.Rows(0)("tknrpskb"), "")
                .TKNZRNKB = DB_NullReplace(dt.Rows(0)("tknzrnkb"), "")
                .TOKZEIKB = DB_NullReplace(dt.Rows(0)("tokzeikb"), "")
                .TOKZCLKB = DB_NullReplace(dt.Rows(0)("tokzclkb"), "")
                .TOKRPSKB = DB_NullReplace(dt.Rows(0)("tokrpskb"), "")
                .TOKZRNKB = DB_NullReplace(dt.Rows(0)("tokzrnkb"), "")
                .TOKNMMKB = DB_NullReplace(dt.Rows(0)("toknmmkb"), "")
                .TANCD = DB_NullReplace(dt.Rows(0)("tancd"), "")

                If .TOKSMEKB = "1" Then
                    '������
                    If SSSVal(.TOKSMEDD) > 27 Then
                        .HYTOKKESDD = "����"
                    Else
                        .HYTOKKESDD = .TOKSMEDD & "��"
                    End If
                Else
                    '�T����
                    .HYTOKKESDD = "�T��"
                End If

                '�������ɂ�����������擾
                .KESISMEDT = getSmedt(strKesidt, .TOKSMEKB, .TOKSMEDD, .TOKSMECC, .TOKSDWKB)

                getTokseinm = SSSVal(.FRNKB)
            End With
        Else
            '������ł͂Ȃ����Ӑ�Ƃ��đ��݂����8��Ԃ� 2007/02/28 Add
            strSql = "SELECT * FROM tokmta WHERE tokcd = '" & strTokseicd & "'"

            dt = DB_GetTable(strSql)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                getTokseinm = 9
            Else
                getTokseinm = 8
            End If
        End If
        '2019/04/23 CHG E N D
    End Function
	
	'�����Ɋ܂܂��S�p���ڂ��폜���A���̒l��Ԃ�
	Public Function delZenkaku(ByRef strText As String) As String
		Dim tmp1 As String
		Dim tmp2 As String
		Dim i As Integer
		
		If strText = "" Then Exit Function
		
		tmp2 = ""
		
		For i = 1 To Len(strText)
			tmp1 = Mid(strText, i, 1)
			
			'���p�ȊO�̕����͖����ɂ���
			If Len(tmp1) = AnsiLenB(tmp1) Then
			Else
				tmp1 = Space(1)
			End If
			
			tmp2 = tmp2 & tmp1
		Next 
		
		delZenkaku = tmp2
	End Function
	
	'���b�Z�[�W�{�b�N�X�̕\��
	Public Function showMsg(ByRef strMsgkb As String, ByRef strMsgnm As String, ByRef strMsgsq As String) As MsgBoxResult
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim strMsgcm As String
		Dim intMsgkb As Short
		
		strSql = "SELECT * FROM systbh"
		strSql = strSql & " WHERE msgkb = '" & Trim(strMsgkb) & "'"
		strSql = strSql & "   AND msgnm = '" & Trim(strMsgnm) & "'"
		strSql = strSql & "   AND msgsq = '" & Trim(strMsgsq) & "'"

        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'strMsgcm = CF_Ora_GetDyn(Usr_Ody, "msgcm", "")
        'intMsgkb = Int(CDbl(CF_Ora_GetDyn(Usr_Ody, "btnkb", "")))
        'intMsgkb = intMsgkb + Int(CDbl(CF_Ora_GetDyn(Usr_Ody, "btnon", "")))
        'intMsgkb = intMsgkb + Int(CDbl(CF_Ora_GetDyn(Usr_Ody, "icnkb", "")))
        Dim dt As DataTable = DB_GetTable(strSql)

        strMsgcm = DB_NullReplace(dt.Rows(0)("msgcm"), "")
        intMsgkb = Int(CDbl(DB_NullReplace(dt.Rows(0)("btnkb"), "")))
        intMsgkb = intMsgkb + Int(CDbl(DB_NullReplace(dt.Rows(0)("btnon"), "")))
        intMsgkb = intMsgkb + Int(CDbl(DB_NullReplace(dt.Rows(0)("icnkb"), "")))
        '2019/04/23 CHG E N D

        showMsg = MsgBox(Trim(strMsgcm), intMsgkb, Trim(SSS_PrgNm))
	End Function
	
	'// V2.00�� DEL
	''
	'''���ו��\���f�[�^�擾SQL���쐬���� .
	''Public Function getSQLforBody(strSmaupddt As String, _
	'''                              strTokseicd As String, _
	'''                              strKaidt As String, _
	'''                              strKesikb As String, _
	'''                     Optional intSortkb As Integer = 0) As String
	''
	''    Dim strSql  As String
	'''CHG START FKS)INABA 2007/07/26 ********************************************************************************************************
	'''***chg-S-tom***
	'''    strSql = _
	''''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''          & ",jr.datno jdndatno " & vbCrLf _
	''''          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	''''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3') ur " _
	''''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt <= "
	'''2007/12/05 FKS)minamoto CHG START
	'''    strSql = _
	''''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''         & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''          & ",jr.datno jdndatno " & vbCrLf _
	''''          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	''''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3' AND IRISU <> 9) ur " _
	''''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt <= "
	''
	'''2008/1/10 FKS)ichihara CHG START
	'''    strSql = _
	''''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''          & ",jr.datno jdndatno " & vbCrLf _
	''''          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	''''          & ",ur.wrtdt udnwrtdt, ur.wrttm udnwrttm, ur.uwrtdt udnuwrtdt, ur.uwrttm udnuwrttm  " & vbCrLf _
	''''          & ",jr.wrtdt jdnwrtdt, jr.wrttm jdnwrttm, jr.uwrtdt jdnuwrtdt, jr.uwrttm jdnuwrttm  " & vbCrLf _
	''''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3' AND IRISU <> 9) ur " _
	''''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt <= "
	''''2007/12/05 FKS)minamoto CHG END
	''
	'''XX 2008/07/08 CHG START FKS)NAKATA
	'''XX   �擾���ڂɁuUDNTRA.UDNNO�v��ǉ�
	'''XX    strSql = _
	''''XX      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''XX          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''XX          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''XX          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''XX          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''XX          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''XX          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''XX          & ",ur.RECNO,ur.AKAKROKB, ur.KESIKB, ur.HENRSNCD, ur.HENSTTCD " _
	''''XX          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''XX         & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''XX          & ",jr.datno jdndatno " & vbCrLf _
	''''XX          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	''''XX          & ",ur.wrtdt udnwrtdt, ur.wrttm udnwrttm, ur.uwrtdt udnuwrtdt, ur.uwrttm udnuwrttm  " & vbCrLf _
	''''XX          & ",jr.wrtdt jdnwrtdt, jr.wrttm jdnwrttm, jr.uwrtdt jdnuwrtdt, jr.uwrttm jdnuwrttm  " & vbCrLf _
	''''XX      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3' AND IRISU <> 9) ur " _
	''''XX          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''XX          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	''''XX             & "WHERE datkb = '1' AND (nyudt <= "
	''    strSql = _
	'''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	'''          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	'''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	'''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	'''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	'''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	'''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	'''          & ",ur.RECNO,ur.AKAKROKB, ur.KESIKB, ur.HENRSNCD, ur.HENSTTCD " _
	'''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	'''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	'''          & "  ,ur.udnno " _
	'''          & ",jr.datno jdndatno " & vbCrLf _
	'''          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	'''          & ",ur.wrtdt udnwrtdt, ur.wrttm udnwrttm, ur.uwrtdt udnuwrtdt, ur.uwrttm udnuwrttm  " & vbCrLf _
	'''          & ",jr.wrtdt jdnwrtdt, jr.wrttm jdnwrttm, jr.uwrtdt jdnuwrtdt, jr.uwrttm jdnuwrttm  " & vbCrLf _
	'''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3' AND IRISU <> 9) ur " _
	'''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	'''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	'''             & "WHERE datkb = '1' AND (nyudt <= "
	''
	'''2007/12/05 FKS)minamoto CHG END
	'''2008/1/10 FKS)ichihara CHG END
	'''XX 2008/07/28 CHG E.N.D FKS)NAKATA
	''
	'''***chg-S-tom***
	'''          & ",DECODE(nr2.TEGDT,' ',' ', TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	'''
	'''    strSql = _
	''''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''          & ",jr.datno jdndatno " & vbCrLf _
	''''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1') ur " _
	''''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''          & ",(SELECT udndatno, udnlinno, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt <= "
	'''CHG  END  FKS)INABA 2007/07/26 ********************************************************************************************************
	'''CHG START FKS)INABA 2007/07/26 ********************************************************************************************************
	''
	''    strSql = strSql & "'" & strSmaupddt & "' OR nyukb = '3') " _
	'''             & "GROUP BY udndatno, udnlinno) nr1 " _
	'''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	'''             & "WHERE datkb = '1' AND (nyudt > '" & strSmaupddt & "' AND nyukb <> '3') " _
	'''             & "GROUP BY udndatno, udnlinno) nr2 " & vbCrLf _
	'''          & ",(SELECT * FROM jdntra WHERE datno in " _
	'''             & "(SELECT MAX(datno) FROM jdntra WHERE tokseicd = '" & strTokseicd & "' " _
	'''               & "GROUP BY jdnno)) jr " & vbCrLf
	'''    strSql = strSql & "'" & strSmaupddt & "' OR nyukb = '3') " _
	''''             & "GROUP BY udndatno, udnlinno) nr1 " _
	''''          & ",(SELECT udndatno, udnlinno, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt > '" & strSmaupddt & "' AND nyukb <> '3') " _
	''''             & "GROUP BY udndatno, udnlinno) nr2 " & vbCrLf _
	''''          & ",(SELECT * FROM jdntra WHERE datno in " _
	''''             & "(SELECT MAX(datno) FROM jdntra WHERE tokseicd = '" & strTokseicd & "' " _
	''''               & "GROUP BY jdnno)) jr " & vbCrLf
	'''CHG  END  FKS)INABA 2007/07/26 ********************************************************************************************************
	'''CHG START FKS)INABA 2007/07/23 ******************************************************************
	'''���o����������\������甄����ɕύX
	''    strSql = strSql _
	'''     & "WHERE ur.tokseicd = '" & strTokseicd & "' " _
	'''       & "AND ((ur.urikn >= 0 AND ur.UDNDT <= '" & strKaidt & "') OR ur.urikn < 0)" _
	'''       & "AND ((ur.DKBID = '01' AND ur.AKAKROKB = '1') OR (ur.DKBID <> '01' AND ur.AKAKROKB = '9')) " _
	'''       & "AND ur.WRTFSTDT || ur.WRTFSTTM = B.DT AND ur.UDNNO = B.UDNNO AND ur.LINNO = B.LINNO " _
	'''       & "AND ur.datno = uh.datno AND uh.maeukkb = '1' "
	'''    strSql = strSql _
	''''     & "WHERE ur.tokseicd = '" & strTokseicd & "' " _
	''''       & "AND ((ur.urikn >= 0 AND ur.kesdt <= '" & strKaidt & "') OR ur.urikn < 0)" _
	''''       & "AND ((ur.DKBID = '01' AND ur.AKAKROKB = '1') OR (ur.DKBID <> '01' AND ur.AKAKROKB = '9')) " _
	''''       & "AND ur.WRTFSTDT || ur.WRTFSTTM = B.DT AND ur.UDNNO = B.UDNNO AND ur.LINNO = B.LINNO " _
	''''       & "AND ur.datno = uh.datno AND uh.maeukkb = '1' "
	'''CHG  END  FKS)INABA 2007/07/23 ******************************************************************
	''
	''
	''    '�����ς݃f�[�^��\�����鎞�́A�����ȍ~�̏������t�̖��ׂ̂ݕ\��
	''    If strKesikb = 9 Then
	''        'strSql = strSql & "AND (ur.kesikb = '9' OR (ur.kesikb = '1' AND ur.nyudt > '" & strSmaupddt & "')) "
	''        strSql = strSql & "AND (ur.kesikb <> '1' OR (ur.kesikb = '1' AND ur.nyudt > '" & strSmaupddt & "')) "
	''    Else
	''        'strSql = strSql & "AND ur.kesikb = '9' "
	''        strSql = strSql & "AND ur.kesikb <> '1' "
	''    End If
	''
	''    strSql = strSql _
	'''       & "AND TRIM(jr.jdndeldt) IS NULL " _
	'''       & "AND ur.jdnno = jr.jdnno AND ur.jdnlinno = jr.linno " _
	'''       & "AND ur.datno = nr1.udndatno(+) AND ur.linno = nr1.udnlinno(+) " _
	'''       & "AND ur.datno = nr2.udndatno(+) AND ur.linno = nr2.udnlinno(+) "
	''
	''    '��ď��̕ύX
	'''CHG START FKS)INABA 2007/07/23 *******************************************************************************
	''    Select Case intSortkb
	''        Case 0
	''            strSql = strSql & "ORDER BY udndt, kesdt,  jdnno, jdnlinno, datno"
	''        Case 1
	'''2008/07/30 CHG START FKS)NAKATA
	'''XX            strSql = strSql & "ORDER BY jdnno, jdnlinno, datno, udndt, kesdt"
	''           strSql = strSql & "ORDER BY jdnno, jdnlinno, udndt, kesdt, datno"
	'''2008/07/30 CHG E.N.D FKS)NAKATA
	''        Case 2
	''            strSql = strSql & "ORDER BY TOKJDNNO, udndt, kesdt, jdnno, jdnlinno, datno"
	''    End Select
	'''    If intSortkb <> 0 Then
	'''        strSql = strSql & "ORDER BY kesdt, udndt, jdnno, jdnlinno, datno"
	'''    Else
	'''        strSql = strSql & "ORDER BY jdnno, jdnlinno, datno, kesdt, udndt"
	'''    End If
	'''CHG  END  FKS)INABA 2007/07/23 *******************************************************************************
	''
	''    getSQLforBody = strSql
	''    Debug.Print strSql
	''End Function
	'// V2.00�� UPD
	
	'����\������擾����
	'�X���b�V���Ȃ��ŕԂ�
	Public Function getKesdt(ByRef strToksmekb As String, ByRef strToksmedt As String, ByRef strToksmecc As String, ByRef strToksdwkb As String, ByRef strTokkescc As String, ByRef strTokkesdd As String, ByRef strTokkdwkb As String, ByVal strDate As String) As String
		
		Dim tmp As Short
		
		'�X���b�V�����ɕϊ�
		strDate = CNV_DATE(strDate)
		'������
		If strToksmekb = "1" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(strToksmecc) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(strToksmecc) = 1 Then
				getKesdt = DeCNV_DATE(strDate)
				Exit Function
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			tmp = SSSVal(strTokkesdd)
			If tmp = 99 Then tmp = 30
			If tmp > 27 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(strTokkescc) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				getKesdt = DeCNV_DATE(CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)) + SSSVal(strTokkescc) + 1, 0)))
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(strTokkescc) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				getKesdt = DeCNV_DATE(CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)) + SSSVal(strTokkescc), tmp)))
			End If
			'�T����
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(strToksdwkb) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(strTokkdwkb) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(strTokkescc) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			getKesdt = DeCNV_DATE(CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + SSSVal(strTokkescc) * 7 + SSSVal(strTokkdwkb) - SSSVal(strToksdwkb))))
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function getDkbnm
	'   �T�v�F ������ʖ��̂��擾
	'   �����F pin_MEICDA   : ���̃L�[  intRow  :�s�ԍ�
	'   �ߒl�F �敪����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function getDkbnm(ByRef strDKBID As String, ByRef intRow As Short) As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_GET_DKBNM
		
		getDkbnm = ""
		
		'dkbflb��1�̂��̂����z�����őI���ł���敪�ƂȂ�
		strSql = "SELECT * FROM systbd " & "WHERE dkbsb = '050' " & "AND dkbid = '" & strDKBID & "' " & "AND dkbflb = '1'"

        'DB�A�N�Z�X
        '2019/04/17 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            '2019/04/17 CHG E N D
            With gtypeFR_SUB(intRow)
                '2019/04/17 CHG START
                ''UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.SUB_DKBNM = CF_Ora_GetDyn(Usr_Ody, "dkbnm", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_UPDID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.SUB_UPDID = CF_Ora_GetDyn(Usr_Ody, "updid", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DFLDKBCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.SUB_DFLDKBCD = CF_Ora_GetDyn(Usr_Ody, "dfldkbcd", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBZAIFL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.SUB_DKBZAIFL = CF_Ora_GetDyn(Usr_Ody, "dkbzaifl", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBTEGFL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.SUB_DKBTEGFL = CF_Ora_GetDyn(Usr_Ody, "dkbtegfl", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBFLA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.SUB_DKBFLA = CF_Ora_GetDyn(Usr_Ody, "dkbfla", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBFLB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.SUB_DKBFLB = CF_Ora_GetDyn(Usr_Ody, "dkbflb", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBFLC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.SUB_DKBFLC = CF_Ora_GetDyn(Usr_Ody, "dkbflc", "")
                ''UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'getDkbnm = .SUB_DKBNM
                .SUB_DKBNM = DB_NullReplace(dt.Rows(0)("dkbnm"), "")
                .SUB_UPDID = DB_NullReplace(dt.Rows(0)("updid"), "")
                .SUB_DFLDKBCD = DB_NullReplace(dt.Rows(0)("dfldkbcd"), "")
                .SUB_DKBZAIFL = DB_NullReplace(dt.Rows(0)("dkbzaifl"), "")
                .SUB_DKBTEGFL = DB_NullReplace(dt.Rows(0)("dkbtegfl"), "")
                .SUB_DKBFLA = DB_NullReplace(dt.Rows(0)("dkbfla"), "")
                .SUB_DKBFLB = DB_NullReplace(dt.Rows(0)("dkbflb"), "")
                .SUB_DKBFLC = DB_NullReplace(dt.Rows(0)("dkbflc"), "")
                getDkbnm = .SUB_DKBNM.ToString
                '2019/04/17 CHG E N D
            End With
        End If

END_GET_DKBNM:
        '�N���[�Y
        '2019/04/17 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/17 DEL E N D
        Exit Function
		
ERR_GET_DKBNM: 
		GoTo END_GET_DKBNM
		
	End Function
	
	'���z�����Ŏg���\���̂̃N���A
	Public Sub initSubFormType(ByRef intRow As Short)
		With gtypeFR_SUB(intRow)
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBID = Space(2) '2byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBNM = Space(6) '6byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_UPDID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_UPDID = Space(2) '2byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DFLDKBCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DFLDKBCD = Space(13) '13byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBZAIFL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBZAIFL = Space(1) '1byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBTEGFL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBTEGFL = Space(1) '1byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBFLA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBFLA = Space(1) '1byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBFLB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBFLB = Space(1) '1byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBFLC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBFLC = Space(1) '1byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_KOUZA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_KOUZA = Space(10) '10byte space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_NYUKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_NYUKN = Space(9) '9byte  space
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_LINCMA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_LINCMA = Space(20) '20byte space
		End With
	End Sub
	
	'���z�����Ŏg���\���̂̈ړ�
	Public Sub moveSubFormType(ByRef intRow As Short)
		With gtypeFR_SUB(intRow)
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBID = gtypeFR_SUB(intRow + 1).SUB_DKBID
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBNM = gtypeFR_SUB(intRow + 1).SUB_DKBNM
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_UPDID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_UPDID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_UPDID = gtypeFR_SUB(intRow + 1).SUB_UPDID
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DFLDKBCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DFLDKBCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DFLDKBCD = gtypeFR_SUB(intRow + 1).SUB_DFLDKBCD
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBZAIFL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBZAIFL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBZAIFL = gtypeFR_SUB(intRow + 1).SUB_DKBZAIFL
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBTEGFL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBTEGFL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBTEGFL = gtypeFR_SUB(intRow + 1).SUB_DKBTEGFL
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBFLA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBFLA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBFLA = gtypeFR_SUB(intRow + 1).SUB_DKBFLA
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBFLB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBFLB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBFLB = gtypeFR_SUB(intRow + 1).SUB_DKBFLB
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_DKBFLC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBFLC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_DKBFLC = gtypeFR_SUB(intRow + 1).SUB_DKBFLC
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_KOUZA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_KOUZA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_KOUZA = gtypeFR_SUB(intRow + 1).SUB_KOUZA
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_NYUKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_NYUKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_NYUKN = gtypeFR_SUB(intRow + 1).SUB_NYUKN
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(intRow).SUB_LINCMA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_LINCMA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SUB_LINCMA = gtypeFR_SUB(intRow + 1).SUB_LINCMA
		End With
		initSubFormType((intRow + 1))
	End Sub
	
	'2009/09/10 UPD START RISE)MIYAJIMA
	''// V2.00�� ADD
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F Function getDkbnm
	''   �T�v�F ���ו��\���f�[�^�擾SQL���쐬����
	''   �����F pm_strSmaupddt   : ������
	''       �F pm_strTokseicd   : ������R�[�h
	''       �F pm_strKaidt_Fr   : �����(�J�n)
	''       �F pm_strKaidt_To   : �����(�I��)
	''       �F pm_strKesikb     : �����\���敪
	''       �F pm_intSortkb     : �\�[�g��
	''   �ߒl�F ��������SQL��
	''   ���l�F
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function getSQLforBody(pm_strSmaupddt As String, _
	''                              pm_strTokseicd As String, _
	''                              pm_strKaidt_Fr As String, _
	''                              pm_strKaidt_to As String, _
	''                              pm_strKesikb As String, _
	''                     Optional pm_intSortkb As Integer = 0) As String
	'
	'    Dim strSql  As String
	'
	'    strSql = ""
	'    strSql = strSql & "SELECT " & vbCrLf
	'    strSql = strSql & "  UH.NXTKB " & vbCrLf
	'    strSql = strSql & " ,TO_DATE(UR.UDNDT, 'YYYY/MM/DD') HY_UDNDT  " & vbCrLf
	'    strSql = strSql & " ,TRIM(UR.JDNNO) || SUBSTR(UR.JDNLINNO, 2, 2) HY_JDNNO  " & vbCrLf
	'    strSql = strSql & " ,TO_DATE(UR.KESDT, 'YYYY/MM/DD') HY_KAIDT " & vbCrLf
	'    strSql = strSql & " ,UR.TOKJDNNO " & vbCrLf
	'    strSql = strSql & " ,UH.TANNM  " & vbCrLf
	'    strSql = strSql & " ,UR.URIKN " & vbCrLf
	'    strSql = strSql & " ,UR.UZEKN " & vbCrLf
	'    strSql = strSql & " ,UR.URIKN + UR.UZEKN KOMIKN  " & vbCrLf
	'    strSql = strSql & " ,NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) KESIKN  " & vbCrLf
	'    strSql = strSql & " ,NVL(NR1.JKESIKN, 0) BFKESIKN " & vbCrLf
	'    strSql = strSql & " ,NVL(NR2.JKESIKN, 0) AFKESIKN  " & vbCrLf
	'    strSql = strSql & " ,UR.JDNNO " & vbCrLf
	'    strSql = strSql & " ,UR.JDNLINNO " & vbCrLf
	'    strSql = strSql & " ,UR.UDNDT " & vbCrLf
	'    strSql = strSql & " ,UR.KESDT  " & vbCrLf
	'    strSql = strSql & " ,UR.RECNO " & vbCrLf
	'    strSql = strSql & " ,UR.AKAKROKB " & vbCrLf
	'    strSql = strSql & " ,UR.KESIKB " & vbCrLf
	'    strSql = strSql & " ,UR.HENRSNCD " & vbCrLf
	'    strSql = strSql & " ,UR.HENSTTCD  " & vbCrLf
	'    strSql = strSql & " ,UR.TOKCD " & vbCrLf
	'    strSql = strSql & " ,UR.TOKSEICD " & vbCrLf
	'    strSql = strSql & " ,UH.TANCD " & vbCrLf
	'    strSql = strSql & " ,JR.JDNDT " & vbCrLf
	'    strSql = strSql & " ,UH.TUKKB  " & vbCrLf
	'    strSql = strSql & " ,UR.INVNO " & vbCrLf
	'    strSql = strSql & " ,UR.FURIKN " & vbCrLf
	'    strSql = strSql & " ,UH.FRNKB " & vbCrLf
	'    strSql = strSql & " ,UR.DATNO " & vbCrLf
	'    strSql = strSql & " ,UR.LINNO " & vbCrLf
	'    strSql = strSql & " ,UH.MAEUKKB    " & vbCrLf
	'    strSql = strSql & " ,UR.UDNNO  " & vbCrLf
	'    strSql = strSql & " ,JR.DATNO JDNDATNO  " & vbCrLf
	'''    strSql = strSql & " ,DECODE(NVL(TRIM(TG.TEGDT),' '),' ',NULL,TO_DATE(TG.TEGDT, 'YYYY/MM/DD') )TEGDT   " & vbCrLf
	''V3.00 2009/03/10 ADD START FKS)NAKATA
	'    strSql = strSql & " ,UR.URITK  " & vbCrLf
	'    strSql = strSql & " ,UR.WRTFSTDT  UDNWRTFSTDT  " & vbCrLf
	'    strSql = strSql & " ,UR.WRTFSTTM  UDNWRTFSTTM  " & vbCrLf
	''NAKATA 2009/03/10 ADD E.N.D FKS)NAKATA
	'    '�r�������p
	'    strSql = strSql & " ,UR.OPEID  UDNOPEID  " & vbCrLf
	'    strSql = strSql & " ,UR.CLTID  UDNCLTID  " & vbCrLf
	'    strSql = strSql & " ,UR.WRTDT  UDNWRTDT  " & vbCrLf
	'    strSql = strSql & " ,UR.WRTTM  UDNWRTTM  " & vbCrLf
	'    strSql = strSql & " ,UR.UOPEID UDNUOPEID " & vbCrLf
	'    strSql = strSql & " ,UR.UCLTID UDNUCLTID " & vbCrLf
	'    strSql = strSql & " ,UR.UWRTDT UDNUWRTDT " & vbCrLf
	'    strSql = strSql & " ,UR.UWRTTM UDNUWRTTM " & vbCrLf
	'    strSql = strSql & " ,JR.OPEID  JDNOPEID  " & vbCrLf
	'    strSql = strSql & " ,JR.CLTID  JDNCLTID  " & vbCrLf
	'    strSql = strSql & " ,JR.WRTDT  JDNWRTDT  " & vbCrLf
	'    strSql = strSql & " ,JR.WRTTM  JDNWRTTM  " & vbCrLf
	'    strSql = strSql & " ,JR.UOPEID JDNUOPEID " & vbCrLf
	'    strSql = strSql & " ,JR.UCLTID JDNUCLTID " & vbCrLf
	'    strSql = strSql & " ,JR.UWRTDT JDNUWRTDT " & vbCrLf
	'    strSql = strSql & " ,JR.UWRTTM JDNUWRTTM " & vbCrLf
	'
	'    strSql = strSql & "FROM " & vbCrLf
	'    strSql = strSql & "  (SELECT " & vbCrLf
	'    strSql = strSql & "          * " & vbCrLf
	'    strSql = strSql & "   FROM   UDNTRA" & vbCrLf
	'    strSql = strSql & "   WHERE  DATKB =  '1' " & vbCrLf
	'    strSql = strSql & "   AND    DENKB =  '1' " & vbCrLf
	''// V3.20�� DEL
	''    strSql = strSql & "   AND    NYUKB <> '3' " & vbCrLf
	''// V3.20�� DEL
	'    strSql = strSql & "   AND    IRISU <>  9 " & vbCrLf
	'    strSql = strSql & "  ) UR " & vbCrLf
	'
	'    strSql = strSql & " ,UDNTHA UH " & vbCrLf
	'
	'    strSql = strSql & " ,(SELECT UDNNO " & vbCrLf
	'    strSql = strSql & "         ,LINNO " & vbCrLf
	'    strSql = strSql & "         ,MAX(WRTFSTDT || WRTFSTTM) AS DT " & vbCrLf
	'    strSql = strSql & "   FROM   UDNTRA " & vbCrLf
	'    strSql = strSql & "   WHERE  DENKB = '1' " & vbCrLf
	'    strSql = strSql & "   GROUP BY UDNNO,LINNO " & vbCrLf
	'    strSql = strSql & "  ) B " & vbCrLf
	'
	'    strSql = strSql & " ,(SELECT " & vbCrLf
	'    strSql = strSql & "          UDNDATNO " & vbCrLf
	'    strSql = strSql & "         ,UDNLINNO " & vbCrLf
	'    strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
	'    strSql = strSql & "   FROM   NKSTRA " & vbCrLf
	'    strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
	'    strSql = strSql & "   AND   (NYUDT <=" & "'" & pm_strSmaupddt & "' OR NYUKB = '3') " & vbCrLf
	'    strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
	'    strSql = strSql & "  ) NR1 " & vbCrLf
	'
	'    strSql = strSql & " ,(SELECT " & vbCrLf
	'    strSql = strSql & "          UDNDATNO " & vbCrLf
	'    strSql = strSql & "         ,UDNLINNO " & vbCrLf
	'    strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
	'    strSql = strSql & "   FROM   NKSTRA " & vbCrLf
	'    strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
	'    strSql = strSql & "   AND   (NYUDT > '" & pm_strSmaupddt & "' AND NYUKB <> '3') " & vbCrLf
	'    strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
	'    strSql = strSql & "  ) NR2 " & vbCrLf
	'
	'''    strSql = strSql & " ,(SELECT " & vbCrLf
	'''    strSql = strSql & "          V1.UDNDATNO " & vbCrLf
	'''    strSql = strSql & "         ,V1.UDNLINNO " & vbCrLf
	'''    strSql = strSql & "         ,V1.TEGDT " & vbCrLf
	'''    strSql = strSql & "   FROM   NKSTRA V1 " & vbCrLf
	'''    strSql = strSql & "        ,(SELECT  MAX(KDNNO) KDNNO " & vbCrLf
	'''    strSql = strSql & "                 ,UDNDATNO " & vbCrLf
	'''    strSql = strSql & "                 ,UDNLINNO " & vbCrLf
	'''    strSql = strSql & "          FROM    NKSTRA " & vbCrLf
	'''    strSql = strSql & "          WHERE   DATKB = '1' " & vbCrLf
	'''    strSql = strSql & "          GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
	'''    strSql = strSql & "         ) V2 " & vbCrLf
	'''    strSql = strSql & "   WHERE  V1.KDNNO    = V2.KDNNO " & vbCrLf
	'''    strSql = strSql & "   AND    V1.MOTKDNNO = ' ' " & vbCrLf
	'''    strSql = strSql & "  ) TG " & vbCrLf
	'
	'    strSql = strSql & " ,(SELECT " & vbCrLf
	'    strSql = strSql & "          * " & vbCrLf
	'    strSql = strSql & "   FROM   JDNTRA " & vbCrLf
	'    strSql = strSql & "   WHERE  DATNO IN ( " & vbCrLf
	'    strSql = strSql & "                     SELECT MAX(DATNO) " & vbCrLf
	'    strSql = strSql & "                     FROM JDNTRA " & vbCrLf
	'    strSql = strSql & "                     WHERE TOKSEICD = '" & pm_strTokseicd & "' " & vbCrLf
	'    strSql = strSql & "                     GROUP BY JDNNO " & vbCrLf
	'    strSql = strSql & "                   ) " & vbCrLf
	'    strSql = strSql & "  ) JR  " & vbCrLf
	'
	'    strSql = strSql & "WHERE " & vbCrLf
	'    strSql = strSql & "      UR.TOKSEICD = '" & CF_Ora_Sgl(pm_strTokseicd) & "' " & vbCrLf
	''// V2.13�� UPD
	''    If Trim(pm_strKaidt_Fr) <> "" Then
	''        strSql = strSql & "AND ((UR.URIKN >= 0 AND UR.UDNDT >= '" & pm_strKaidt_Fr & "' AND UR.UDNDT <= '" & pm_strKaidt_to & "') " & vbCrLf
	''        strSql = strSql & "OR    UR.URIKN < 0) " & vbCrLf
	''    Else
	''        strSql = strSql & "AND ((UR.URIKN >= 0 AND UR.UDNDT <= '" & pm_strKaidt_to & "') " & vbCrLf
	''        strSql = strSql & "OR    UR.URIKN < 0) " & vbCrLf
	''    End If
	'    strSql = strSql & "AND ((UR.URIKN >= 0 AND UR.UDNDT <= '" & pm_strKaidt_to & "') " & vbCrLf
	'    strSql = strSql & "OR    UR.URIKN < 0) " & vbCrLf
	''// V2.13�� UPD
	'    strSql = strSql & "AND ((UR.DKBID  = '01' AND UR.AKAKROKB = '1') " & vbCrLf
	'    strSql = strSql & "      OR  " & vbCrLf
	'    strSql = strSql & "     (UR.DKBID <> '01' AND UR.AKAKROKB = '9')) " & vbCrLf
	'    strSql = strSql & "AND UR.WRTFSTDT || UR.WRTFSTTM = B.DT " & vbCrLf
	'    strSql = strSql & "AND UR.UDNNO   = B.UDNNO " & vbCrLf
	'    strSql = strSql & "AND UR.LINNO   = B.LINNO " & vbCrLf
	'    strSql = strSql & "AND UR.DATNO   = UH.DATNO " & vbCrLf
	'    strSql = strSql & "AND UH.MAEUKKB = '1' " & vbCrLf
	'
	'
	''2009/09/03 ADD START RISE)MIYAJIMA
	'    strSql = strSql & "AND UR.SSADT  <= " & DB_TOKMTA.TOKSMEDT & vbCrLf
	''2009/09/03 ADD E.N.D RISE)MIYAJIMA
	'
	'    '�����ς݃f�[�^��\�����鎞�́A�����ȍ~�̏������t�̖��ׂ̂ݕ\��
	''// V2.11�� UPD
	''2009/09/08 DEL START RISE)MIYAJIMA
	''    If pm_strKesikb = 1 Then
	''        strSql = strSql & "AND  UR.URIKN + UR.UZEKN <> UR.JKESIKN " & vbCrLf
	''    End If
	''2009/09/08 DEL E.N.D RISE)MIYAJIMA
	''''''// V2.10�� UPD
	'''''''''    If pm_strKesikb = 1 Then
	'''''''''        strSql = strSql & "AND  UR.URIKN + UR.UZEKN <> NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) " & vbCrLf
	'''''''''    Else
	'''''''''        strSql = strSql & "AND (UR.URIKN + UR.UZEKN <> NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) " & vbCrLf
	''''''''''// V2.01�� UPD
	''''''''''        strSql = strSql & "    OR (UR.URIKN + UR.UZEKN = NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) AND UR.NYUDT > '" & pm_strSmaupddt & "')) " & vbCrLf
	'''''''''        strSql = strSql & "    OR (UR.URIKN + UR.UZEKN = NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) )) " & vbCrLf
	''''''''''// V2.01�� UPD
	'''''''''    End If
	'''''    If pm_strKesikb = 1 Then
	'''''        strSql = strSql & "AND  UR.URIKN + UR.UZEKN <> UR.JKESIKN " & vbCrLf
	'''''    Else
	'''''        strSql = strSql & "AND (UR.URIKN + UR.UZEKN <> UR.JKESIKN " & vbCrLf
	'''''        strSql = strSql & "     OR " & vbCrLf
	'''''        strSql = strSql & "     (UR.URIKN + UR.UZEKN = UR.JKESIKN AND UR.NYUDT > '" & pm_strSmaupddt & "') " & vbCrLf
	'''''        strSql = strSql & "    ) " & vbCrLf
	'''''    End If
	''''''// V2.10�� UPD
	''// V2.11�� UPD
	'
	'    strSql = strSql & "AND TRIM(JR.JDNDELDT) IS NULL " & vbCrLf
	'    strSql = strSql & "AND UR.JDNNO    = JR.JDNNO " & vbCrLf
	'    strSql = strSql & "AND UR.JDNLINNO = JR.LINNO " & vbCrLf
	'    strSql = strSql & "AND UR.DATNO    = NR1.UDNDATNO(+) " & vbCrLf
	'    strSql = strSql & "AND UR.LINNO    = NR1.UDNLINNO(+) " & vbCrLf
	'    strSql = strSql & "AND UR.DATNO    = NR2.UDNDATNO(+) " & vbCrLf
	'    strSql = strSql & "AND UR.LINNO    = NR2.UDNLINNO(+) " & vbCrLf
	'''    strSql = strSql & "AND UR.DATNO    = TG.UDNDATNO(+)  " & vbCrLf
	'''    strSql = strSql & "AND UR.LINNO    = TG.UDNLINNO(+)  " & vbCrLf
	'
	'    '��ď��̕ύX
	'    Select Case pm_intSortkb
	'        Case 0
	'            strSql = strSql & "ORDER BY UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
	'        Case 1
	'            strSql = strSql & "ORDER BY JDNNO, JDNLINNO, UDNDT, KESDT, DATNO"
	'        Case 2
	'            strSql = strSql & "ORDER BY TOKJDNNO, UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
	'    End Select
	'
	'    getSQLforBody = strSql
	'
	'    Debug.Print strSql
	'
	'End Function
	''// V2.00�� ADD
	
	'// V2.00�� ADD
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function getDkbnm
	'   �T�v�F ���ו��\���f�[�^�擾SQL���쐬����
	'   �����F pm_strSmaupddt   : ������
	'       �F pm_strTokseicd   : ������R�[�h
	'       �F pm_strKaidt_Fr   : �����(�J�n)
	'       �F pm_strKaidt_To   : �����(�I��)
	'       �F pm_strKesikb     : �����\���敪
	'       �F pm_intSortkb     : �\�[�g��
	'   �ߒl�F ��������SQL��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function getSQLforBody(ByRef pm_strSmaupddt As String, ByRef pm_strTokseicd As String, ByRef pm_strKaidt_Fr As String, ByRef pm_strKaidt_to As String, ByRef pm_strKesikb As String, Optional ByRef pm_intSortkb As Short = 0) As String
		
		Dim strSql As String
		
		strSql = ""
		strSql = strSql & "SELECT " & vbCrLf
		strSql = strSql & "  UH.NXTKB " & vbCrLf
		strSql = strSql & " ,TO_DATE(UR.UDNDT, 'YYYY/MM/DD') HY_UDNDT " & vbCrLf
		strSql = strSql & " ,TRIM(UR.JDNNO) || SUBSTR(UR.JDNLINNO, 2, 2) HY_JDNNO " & vbCrLf
		strSql = strSql & " ,TO_DATE(UR.KESDT, 'YYYY/MM/DD') HY_KAIDT " & vbCrLf
		strSql = strSql & " ,UR.TOKJDNNO " & vbCrLf
		strSql = strSql & " ,UH.TANNM " & vbCrLf
		strSql = strSql & " ,UR.URIKN " & vbCrLf
		strSql = strSql & " ,UR.UZEKN " & vbCrLf
		strSql = strSql & " ,UR.URIKN + UR.UZEKN KOMIKN " & vbCrLf
		strSql = strSql & " ,NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) KESIKN " & vbCrLf
		strSql = strSql & " ,NVL(NR1.JKESIKN, 0) BFKESIKN " & vbCrLf
		strSql = strSql & " ,NVL(NR2.JKESIKN, 0) AFKESIKN " & vbCrLf
		strSql = strSql & " ,UR.JDNNO " & vbCrLf
		strSql = strSql & " ,UR.JDNLINNO " & vbCrLf
		strSql = strSql & " ,UR.UDNDT " & vbCrLf
		strSql = strSql & " ,UR.KESDT " & vbCrLf
		strSql = strSql & " ,UR.RECNO " & vbCrLf
		strSql = strSql & " ,UR.AKAKROKB " & vbCrLf
		strSql = strSql & " ,UR.KESIKB " & vbCrLf
		strSql = strSql & " ,UR.HENRSNCD " & vbCrLf
		strSql = strSql & " ,UR.HENSTTCD " & vbCrLf
		strSql = strSql & " ,UR.TOKCD " & vbCrLf
		strSql = strSql & " ,UR.TOKSEICD " & vbCrLf
		strSql = strSql & " ,UH.TANCD " & vbCrLf
		strSql = strSql & " ,JR.JDNDT " & vbCrLf
		strSql = strSql & " ,UH.TUKKB " & vbCrLf
		strSql = strSql & " ,UR.INVNO " & vbCrLf
		strSql = strSql & " ,UR.FURIKN " & vbCrLf
		strSql = strSql & " ,UH.FRNKB " & vbCrLf
		strSql = strSql & " ,UR.DATNO " & vbCrLf
		strSql = strSql & " ,UR.LINNO " & vbCrLf
		strSql = strSql & " ,UH.MAEUKKB " & vbCrLf
		strSql = strSql & " ,UR.UDNNO " & vbCrLf
		strSql = strSql & " ,JR.DATNO JDNDATNO  " & vbCrLf
		strSql = strSql & " ,UR.URITK " & vbCrLf
		'2009/09/15 ADD START RISE)MIYAJIMA
		strSql = strSql & " ,UR.SSADT " & vbCrLf
		'2009/09/15 ADD E.N.D RISE)MIYAJIMA
		strSql = strSql & " ,UR.WRTFSTDT  UDNWRTFSTDT " & vbCrLf
		strSql = strSql & " ,UR.WRTFSTTM  UDNWRTFSTTM " & vbCrLf
		
		'�r�������p
		strSql = strSql & " ,UR.OPEID  UDNOPEID  " & vbCrLf
		strSql = strSql & " ,UR.CLTID  UDNCLTID  " & vbCrLf
		strSql = strSql & " ,UR.WRTDT  UDNWRTDT  " & vbCrLf
		strSql = strSql & " ,UR.WRTTM  UDNWRTTM  " & vbCrLf
		strSql = strSql & " ,UR.UOPEID UDNUOPEID " & vbCrLf
		strSql = strSql & " ,UR.UCLTID UDNUCLTID " & vbCrLf
		strSql = strSql & " ,UR.UWRTDT UDNUWRTDT " & vbCrLf
		strSql = strSql & " ,UR.UWRTTM UDNUWRTTM " & vbCrLf
		strSql = strSql & " ,JR.OPEID  JDNOPEID  " & vbCrLf
		strSql = strSql & " ,JR.CLTID  JDNCLTID  " & vbCrLf
		strSql = strSql & " ,JR.WRTDT  JDNWRTDT  " & vbCrLf
		strSql = strSql & " ,JR.WRTTM  JDNWRTTM  " & vbCrLf
		strSql = strSql & " ,JR.UOPEID JDNUOPEID " & vbCrLf
		strSql = strSql & " ,JR.UCLTID JDNUCLTID " & vbCrLf
		strSql = strSql & " ,JR.UWRTDT JDNUWRTDT " & vbCrLf
		strSql = strSql & " ,JR.UWRTTM JDNUWRTTM " & vbCrLf
		
		'2009/09/27 ADD START RISE)MIYAJIMA
		strSql = strSql & " ,(SELECT " & vbCrLf
		strSql = strSql & "       MAX(TEGDT) TEGDT " & vbCrLf
		strSql = strSql & "   FROM " & vbCrLf
		strSql = strSql & "       NKSTRA " & vbCrLf
		strSql = strSql & "   WHERE " & vbCrLf
		strSql = strSql & "          UDNDATNO = UR.DATNO " & vbCrLf
		strSql = strSql & "   AND    UDNLINNO = UR.LINNO " & vbCrLf
		strSql = strSql & "   AND    DATKB    = '1' " & vbCrLf
		strSql = strSql & "   AND    AKAKROKB = '1' " & vbCrLf
		strSql = strSql & "   AND    KDNNO NOT IN ( " & vbCrLf
		strSql = strSql & "          SELECT " & vbCrLf
		strSql = strSql & "              MOTKDNNO " & vbCrLf
		strSql = strSql & "          FROM " & vbCrLf
		strSql = strSql & "              NKSTRA " & vbCrLf
		strSql = strSql & "          WHERE " & vbCrLf
		strSql = strSql & "                 UDNDATNO = UR.DATNO " & vbCrLf
		strSql = strSql & "          AND    UDNLINNO = UR.LINNO " & vbCrLf
		strSql = strSql & "          AND    TRIM(MOTKDNNO) IS NOT NULL " & vbCrLf
		strSql = strSql & "       ) ) TEGDT " & vbCrLf
		'2009/09/27 ADD E.N.D RISE)MIYAJIMA
		
		strSql = strSql & "FROM " & vbCrLf
		strSql = strSql & "  (SELECT " & vbCrLf
		strSql = strSql & "          * " & vbCrLf
		strSql = strSql & "   FROM   UDNTRA" & vbCrLf
		strSql = strSql & "   WHERE  DATKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND    DENKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    IRISU    <> 9 " & vbCrLf
		If Trim(pm_strKaidt_Fr) <> "" Then
			strSql = strSql & "   AND    UDNDT    >= '" & pm_strKaidt_Fr & "' " & vbCrLf
		End If
		strSql = strSql & "   AND    UDNDT    <= '" & pm_strKaidt_to & "' " & vbCrLf
		'2009/09/27 DEL START RISE)MIYAJIMA
		''2009/09/15 UPD START RISE)MIYAJIMA
		''    strSql = strSql & "   AND    SSADT    <= '" & DB_TOKMTA.TOKSMEDT & "'" & vbCrLf
		'    If pm_strKesikb = 1 Then
		'        strSql = strSql & "   AND    SSADT    <= '" & DB_TOKMTA.TOKSMEDT & "'" & vbCrLf
		'    Else
		'        strSql = strSql & "   AND    (SSADT    <= '" & DB_TOKMTA.TOKSMEDT & "' " & vbCrLf
		'        strSql = strSql & "           OR " & vbCrLf
		'        strSql = strSql & "           JKESIKN > 0 ) " & vbCrLf
		'    End If
		''2009/09/15 UPD E.N.D RISE)MIYAJIMA
		'2009/09/27 DEL E.N.D RISE)MIYAJIMA
		'2018/10/26 ADD START <C2-20181001-02> CIS)�R��
		strSql = strSql & "   UNION ALL " & vbCrLf
		strSql = strSql & "   SELECT " & vbCrLf
		strSql = strSql & "          * " & vbCrLf
		strSql = strSql & "   FROM   UDNTRA A " & vbCrLf
		strSql = strSql & "   WHERE  A.DATKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    A.TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND    A.DENKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    A.IRISU    = 9 " & vbCrLf
		strSql = strSql & "   AND    (SELECT CASE COUNT(*) " & vbCrLf
		strSql = strSql & "                           WHEN 2 THEN SUM(B.URIKN + B.UZEKN) " & vbCrLf
		strSql = strSql & "                           ELSE 0 END " & vbCrLf
		strSql = strSql & "              FROM    UDNTRA B" & vbCrLf
		strSql = strSql & "              WHERE  ( B.DATNO = A.DATNO " & vbCrLf
		strSql = strSql & "                           AND B.LINNO = A.LINNO)" & vbCrLf
		strSql = strSql & "              OR        ( DECODE(A.DKBID,'06',B.DATNO,B.MOTDATNO) = " & vbCrLf
		strSql = strSql & "                            DECODE(A.DKBID,'06',A.MOTDATNO,A.DATNO)  " & vbCrLf
		strSql = strSql & "                           AND B.JDNNO = A.JDNNO " & vbCrLf
		strSql = strSql & "                           AND B.JDNLINNO = A.JDNLINNO " & vbCrLf
		strSql = strSql & "                           AND B.RECNO = A.RECNO )) <> 0 " & vbCrLf
		If Trim(pm_strKaidt_Fr) <> "" Then
			strSql = strSql & "   AND    A.UDNDT    >= '" & pm_strKaidt_Fr & "' " & vbCrLf
		End If
		strSql = strSql & "   AND    A.UDNDT    <= '" & pm_strKaidt_to & "' " & vbCrLf
		'2018/10/26 ADD END <C2-20181001-02> CIS)�R��
		strSql = strSql & "  ) UR " & vbCrLf
		
		strSql = strSql & " ,UDNTHA UH " & vbCrLf
		
		strSql = strSql & " ,(SELECT UDNNO " & vbCrLf
		strSql = strSql & "         ,LINNO " & vbCrLf
		strSql = strSql & "         ,MAX(WRTFSTDT || WRTFSTTM) AS DT " & vbCrLf
		strSql = strSql & "   FROM   UDNTRA " & vbCrLf
		strSql = strSql & "   WHERE  DENKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   GROUP BY UDNNO,LINNO " & vbCrLf
		strSql = strSql & "  ) B " & vbCrLf
		
		strSql = strSql & " ,(SELECT " & vbCrLf
		strSql = strSql & "          UDNDATNO " & vbCrLf
		strSql = strSql & "         ,UDNLINNO " & vbCrLf
		strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
		strSql = strSql & "   FROM   NKSTRA " & vbCrLf
		strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
		strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND   (NYUDT <=" & "'" & pm_strSmaupddt & "' OR NYUKB = '3') " & vbCrLf
		strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
		strSql = strSql & "  ) NR1 " & vbCrLf
		
		strSql = strSql & " ,(SELECT " & vbCrLf
		strSql = strSql & "          UDNDATNO " & vbCrLf
		strSql = strSql & "         ,UDNLINNO " & vbCrLf
		strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
		strSql = strSql & "   FROM   NKSTRA " & vbCrLf
		strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
		strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND   (NYUDT > '" & pm_strSmaupddt & "' AND NYUKB <> '3') " & vbCrLf
		strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
		strSql = strSql & "  ) NR2 " & vbCrLf
		
		strSql = strSql & " ,(SELECT " & vbCrLf
		strSql = strSql & "          * " & vbCrLf
		strSql = strSql & "   FROM   JDNTRA " & vbCrLf
		strSql = strSql & "   WHERE  DATNO IN ( " & vbCrLf
		strSql = strSql & "                     SELECT MAX(DATNO) " & vbCrLf
		strSql = strSql & "                     FROM JDNTRA " & vbCrLf
		'DEL START FKS)INABA 2010/06/07 **********************************
		'�A���[��817
		'    strSql = strSql & "                     WHERE TOKSEICD = '" & pm_strTokseicd & "' " & vbCrLf
		'DEL  END  FKS)INABA 2010/06/07 **********************************
		strSql = strSql & "                     GROUP BY JDNNO " & vbCrLf
		strSql = strSql & "                   ) " & vbCrLf
		'ADD START FKS)INABA 2010/06/07 **********************************
		'�A���[��817
		strSql = strSql & "    AND  TOKSEICD = '" & pm_strTokseicd & "' " & vbCrLf
		'ADD  END  FKS)INABA 2010/06/07 **********************************
		strSql = strSql & "  ) JR  " & vbCrLf
		
		strSql = strSql & "WHERE " & vbCrLf
		strSql = strSql & "  NOT EXISTS " & vbCrLf
		strSql = strSql & "  (SELECT * FROM UDNTRA " & vbCrLf
		strSql = strSql & "   WHERE " & vbCrLf
		strSql = strSql & "        DATKB    = '1'" & vbCrLf
		strSql = strSql & "   AND  TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND  JDNNO    = UR.JDNNO " & vbCrLf
		strSql = strSql & "   AND  JDNLINNO = UR.JDNLINNO " & vbCrLf
		strSql = strSql & "   AND  RECNO    = UR.RECNO " & vbCrLf
		strSql = strSql & "   AND  IRISU    <> 9 " & vbCrLf
		strSql = strSql & "   AND  UR.AKAKROKB = '9' " & vbCrLf
		strSql = strSql & "   AND (DKBID    = '01' AND AKAKROKB = '1')" & vbCrLf
		strSql = strSql & "   AND  DENKB    = '1'" & vbCrLf
		strSql = strSql & " AND UDNDT < '" & pm_strKaidt_Fr & "'" & vbCrLf
		'2018/10/26 ADD START <C2-20181001-02> CIS)�R��
		strSql = strSql & "   UNION ALL " & vbCrLf
		strSql = strSql & "   SELECT " & vbCrLf
		strSql = strSql & "          * " & vbCrLf
		strSql = strSql & "   FROM   UDNTRA A " & vbCrLf
		strSql = strSql & "   WHERE  A.DATKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    A.TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND    A.JDNNO    = UR.JDNNO " & vbCrLf
		strSql = strSql & "   AND    A.JDNLINNO = UR.JDNLINNO " & vbCrLf
		strSql = strSql & "   AND    A.RECNO    = UR.RECNO " & vbCrLf
		strSql = strSql & "   AND    A.IRISU    = 9 " & vbCrLf
		strSql = strSql & "   AND    (SELECT CASE COUNT(*) " & vbCrLf
		strSql = strSql & "                           WHEN 2 THEN SUM(B.URIKN + B.UZEKN) " & vbCrLf
		strSql = strSql & "                           ELSE 0 END " & vbCrLf
		strSql = strSql & "              FROM    UDNTRA B" & vbCrLf
		strSql = strSql & "              WHERE  ( B.DATNO = A.DATNO " & vbCrLf
		strSql = strSql & "                           AND B.LINNO = A.LINNO)" & vbCrLf
		strSql = strSql & "              OR        ( DECODE(A.DKBID,'06',B.DATNO,B.MOTDATNO) = " & vbCrLf
		strSql = strSql & "                            DECODE(A.DKBID,'06',A.MOTDATNO,A.DATNO)  " & vbCrLf
		strSql = strSql & "                           AND B.JDNNO = A.JDNNO " & vbCrLf
		strSql = strSql & "                           AND B.JDNLINNO = A.JDNLINNO " & vbCrLf
		strSql = strSql & "                           AND B.RECNO = A.RECNO )) <> 0 " & vbCrLf
		strSql = strSql & "   AND    UR.AKAKROKB = '9' " & vbCrLf
		strSql = strSql & "   AND    (A.DKBID    = '01' AND A.AKAKROKB = '1')" & vbCrLf
		strSql = strSql & "   AND    A.DENKB    = '1'" & vbCrLf
		strSql = strSql & "   AND    A.UDNDT < '" & pm_strKaidt_Fr & "'" & vbCrLf
		'2018/10/26 ADD END <C2-20181001-02> CIS)�R��
		strSql = strSql & " ) " & vbCrLf
		'    strSql = strSql & " (UR.AKAKROKB = '9' AND " & vbCrLf
		'    strSql = strSql & "  NOT EXISTS " & vbCrLf
		'    strSql = strSql & "  (SELECT * FROM UDNTRA " & vbCrLf
		'    strSql = strSql & "   WHERE " & vbCrLf
		'    strSql = strSql & "        DATKB    = '1'" & vbCrLf
		'    strSql = strSql & "   AND  TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		'    strSql = strSql & "   AND  JDNNO    = UR.JDNNO " & vbCrLf
		'    strSql = strSql & "   AND  JDNLINNO = UR.JDNLINNO " & vbCrLf
		'    strSql = strSql & "   AND  RECNO    = UR.RECNO " & vbCrLf
		'    strSql = strSql & "   AND  IRISU    <> 9 " & vbCrLf
		'    strSql = strSql & "   AND (DKBID    = '01' AND AKAKROKB = '1')" & vbCrLf
		'    strSql = strSql & "   AND  DENKB    = '1'" & vbCrLf
		'    strSql = strSql & " AND UDNDT < '" & pm_strKaidt_Fr & "'" & vbCrLf
		'    strSql = strSql & " ) OR " & vbCrLf
		'    strSql = strSql & " (UR.AKAKROKB = '1' AND " & vbCrLf
		'    strSql = strSql & "  NOT EXISTS " & vbCrLf
		'    strSql = strSql & "  (SELECT * FROM UDNTRA " & vbCrLf
		'    strSql = strSql & "   WHERE " & vbCrLf
		'    strSql = strSql & "        DATKB    = '1'" & vbCrLf
		'    strSql = strSql & "   AND  TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		'    strSql = strSql & "   AND  JDNNO    = UR.JDNNO " & vbCrLf
		'    strSql = strSql & "   AND  JDNLINNO = UR.JDNLINNO " & vbCrLf
		'    strSql = strSql & "   AND  RECNO    = UR.RECNO " & vbCrLf
		'    strSql = strSql & "   AND  IRISU    <> 9 " & vbCrLf
		'    strSql = strSql & "   AND (DKBID  <> '01' AND AKAKROKB = '9')" & vbCrLf
		'    strSql = strSql & "   AND  DENKB    = '1'" & vbCrLf
		'    strSql = strSql & "   AND  UDNDT > '" & pm_strKaidt_to & "'" & vbCrLf
		'    strSql = strSql & " )))" & vbCrLf
		
		strSql = strSql & "AND   UR.TOKSEICD = '" & CF_Ora_Sgl(pm_strTokseicd) & "' " & vbCrLf
		strSql = strSql & "AND   UR.UDNDT   <= '" & pm_strKaidt_to & "' " & vbCrLf
		strSql = strSql & "AND ((UR.DKBID  = '01' AND UR.AKAKROKB = '1') " & vbCrLf
		strSql = strSql & "      OR  " & vbCrLf
		strSql = strSql & "     (UR.DKBID <> '01' AND UR.AKAKROKB = '9')) " & vbCrLf
		strSql = strSql & "AND UR.WRTFSTDT || UR.WRTFSTTM = B.DT " & vbCrLf
		strSql = strSql & "AND UR.UDNNO   = B.UDNNO " & vbCrLf
		strSql = strSql & "AND UR.LINNO   = B.LINNO " & vbCrLf
		strSql = strSql & "AND UR.DATNO   = UH.DATNO " & vbCrLf
		strSql = strSql & "AND UH.MAEUKKB = '1' " & vbCrLf
		
		If CDbl(pm_strKesikb) = 1 Then
			strSql = strSql & "AND (" & vbCrLf
			'''' UPD 2014/02/05  FWEST) Yamamoto    Start    �A���[��FC14013101
			'        strSql = strSql & "     (UR.URIKN + UR.UZEKN <> UR.JKESIKN) " & vbCrLf
			strSql = strSql & "     ((UR.URIKN + UR.UZEKN <> UR.JKESIKN) " & vbCrLf
			strSql = strSql & "       AND UR.URIKN + UR.UZEKN <> " & vbCrLf
			strSql = strSql & "                (SELECT NVL(SUM(JKESIKN),0) FROM NKSTRA " & vbCrLf
			strSql = strSql & "                 WHERE  DATKB    = '1' " & vbCrLf
			strSql = strSql & "                 AND    UDNDATNO = UR.DATNO " & vbCrLf
			strSql = strSql & "                 AND    UDNLINNO = UR.LINNO) " & vbCrLf
			strSql = strSql & "      ) " & vbCrLf
			'''' UPD 2014/02/05  FWEST) Yamamoto    End
			strSql = strSql & "      OR" & vbCrLf
			strSql = strSql & "     ((UR.URIKN + UR.UZEKN =  UR.JKESIKN) " & vbCrLf
			strSql = strSql & "       AND EXISTS " & vbCrLf
			strSql = strSql & "       (SELECT * FROM UDNTRA " & vbCrLf
			strSql = strSql & "        WHERE  JDNNO    =  UR.JDNNO" & vbCrLf
			strSql = strSql & "        AND    JDNLINNO =  UR.JDNLINNO" & vbCrLf
			strSql = strSql & "        AND    DATKB    =  '1'" & vbCrLf
			strSql = strSql & "        AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
			strSql = strSql & "        AND    AKAKROKB =  '9'" & vbCrLf
			strSql = strSql & "        AND    IRISU    <> 9 " & vbCrLf
			strSql = strSql & "        AND    DKBID    IN  ('02','06')" & vbCrLf
			strSql = strSql & "        AND    URIKN + UZEKN   <> JKESIKN " & vbCrLf
			If Trim(pm_strKaidt_Fr) <> "" Then
				strSql = strSql & "        AND    UDNDT    >= '" & pm_strKaidt_Fr & "'" & vbCrLf
			End If
			strSql = strSql & "        AND    UDNDT    <= '" & pm_strKaidt_to & "'" & vbCrLf
			'2018/10/26 ADD START <C2-20181001-02> CIS)�R��
			strSql = strSql & "        UNION ALL " & vbCrLf
			strSql = strSql & "        SELECT * FROM UDNTRA A " & vbCrLf
			strSql = strSql & "        WHERE  A.JDNNO    =  UR.JDNNO" & vbCrLf
			strSql = strSql & "        AND    A.JDNLINNO =  UR.JDNLINNO" & vbCrLf
			strSql = strSql & "        AND    A.DATKB    =  '1'" & vbCrLf
			strSql = strSql & "        AND    A.TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
			strSql = strSql & "        AND    A.AKAKROKB =  '9'" & vbCrLf
			strSql = strSql & "        AND    A.IRISU    = 9 " & vbCrLf
			strSql = strSql & "        AND    (SELECT CASE COUNT(*) " & vbCrLf
			strSql = strSql & "                               WHEN 2 THEN SUM(B.URIKN + B.UZEKN) " & vbCrLf
			strSql = strSql & "                               ELSE 0 END " & vbCrLf
			strSql = strSql & "                   FROM    UDNTRA B" & vbCrLf
			strSql = strSql & "                   WHERE  ( B.DATNO = A.DATNO " & vbCrLf
			strSql = strSql & "                                AND B.LINNO = A.LINNO)" & vbCrLf
			strSql = strSql & "                   OR        ( DECODE(A.DKBID,'06',B.DATNO,B.MOTDATNO) = " & vbCrLf
			strSql = strSql & "                                 DECODE(A.DKBID,'06',A.MOTDATNO,A.DATNO)  " & vbCrLf
			strSql = strSql & "                                AND B.JDNNO = A.JDNNO " & vbCrLf
			strSql = strSql & "                                AND B.JDNLINNO = A.JDNLINNO " & vbCrLf
			strSql = strSql & "                                AND B.RECNO = A.RECNO )) <> 0 " & vbCrLf
			strSql = strSql & "        AND    A.DKBID    IN  ('02','06')" & vbCrLf
			strSql = strSql & "        AND    A.URIKN + A.UZEKN   <> A.JKESIKN " & vbCrLf
			If Trim(pm_strKaidt_Fr) <> "" Then
				strSql = strSql & "        AND    A.UDNDT    >= '" & pm_strKaidt_Fr & "'" & vbCrLf
			End If
			strSql = strSql & "        AND    A.UDNDT    <= '" & pm_strKaidt_to & "'" & vbCrLf
			'2018/10/26 ADD END <C2-20181001-02> CIS)�R��
			
			strSql = strSql & "       )" & vbCrLf
			'''' ADD 2010/09/28  FKS) T.Yamamoto    Start    �A���[��FC10092801
			'�P����������Ă��Ȃ�
			strSql = strSql & "       AND NOT EXISTS " & vbCrLf
			strSql = strSql & "       (SELECT * FROM UDNTRA " & vbCrLf
			strSql = strSql & "        WHERE  JDNNO    =  UR.JDNNO" & vbCrLf
			strSql = strSql & "        AND    JDNLINNO =  UR.JDNLINNO" & vbCrLf
			strSql = strSql & "        AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
			strSql = strSql & "        AND    AKAKROKB =  '1'" & vbCrLf
			strSql = strSql & "        AND    DKBID    =  '01'" & vbCrLf
			strSql = strSql & "        AND    RECNO    =  UR.RECNO" & vbCrLf
			strSql = strSql & "        AND    URITK    <> UR.URITK" & vbCrLf
			strSql = strSql & "        AND    (WRTFSTDT || WRTFSTTM)" & vbCrLf
			strSql = strSql & "                        <  (UR.WRTFSTDT || UR.WRTFSTTM)" & vbCrLf
			strSql = strSql & "       )" & vbCrLf
			'''' ADD 2010/09/28  FKS) T.Yamamoto    End
			strSql = strSql & "      ) " & vbCrLf
			strSql = strSql & "    ) " & vbCrLf
		End If
		
		'2009/09/15 DEL START RISE)MIYAJIMA
		'    strSql = strSql & "AND UR.SSADT  <= '" & DB_TOKMTA.TOKSMEDT & "'" & vbCrLf
		'2009/09/15 DEL E.N.D RISE)MIYAJIMA
		
		strSql = strSql & "AND TRIM(JR.JDNDELDT) IS NULL " & vbCrLf
		strSql = strSql & "AND UR.JDNNO    = JR.JDNNO " & vbCrLf
		strSql = strSql & "AND UR.JDNLINNO = JR.LINNO " & vbCrLf
		'ADD START FKS)INABA 2010/06/07 **********************************
		'�A���[��817
		strSql = strSql & "AND UR.TOKSEICD = JR.TOKSEICD " & vbCrLf
		'ADD  END  FKS)INABA 2010/06/07 **********************************
		strSql = strSql & "AND UR.DATNO    = NR1.UDNDATNO(+) " & vbCrLf
		strSql = strSql & "AND UR.LINNO    = NR1.UDNLINNO(+) " & vbCrLf
		strSql = strSql & "AND UR.DATNO    = NR2.UDNDATNO(+) " & vbCrLf
		strSql = strSql & "AND UR.LINNO    = NR2.UDNLINNO(+) " & vbCrLf
		
		'��ď��̕ύX
		Select Case pm_intSortkb
			'''' UPD 2010/02/10  FKS) T.Yamamoto    Start    �A���[��771
			'        Case 0
			'            strSql = strSql & "ORDER BY UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
			'        Case 1
			'            strSql = strSql & "ORDER BY JDNNO, JDNLINNO, UDNDT, KESDT, DATNO"
			'        Case 2
			'            strSql = strSql & "ORDER BY TOKJDNNO, UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
			Case 0
				strSql = strSql & "ORDER BY UDNDT, KESDT, JDNNO, JDNLINNO, UDNWRTFSTDT, UDNWRTFSTTM"
			Case 1
				strSql = strSql & "ORDER BY JDNNO, JDNLINNO, UDNDT, KESDT, UDNWRTFSTDT, UDNWRTFSTTM"
			Case 2
				strSql = strSql & "ORDER BY TOKJDNNO, UDNDT, KESDT, JDNNO, JDNLINNO, UDNWRTFSTDT, UDNWRTFSTTM"
				'''' UPD 2010/02/10  FKS) T.Yamamoto    End
		End Select
		
		getSQLforBody = strSql
		
		'    Debug.Print strSql
		
	End Function
    '// V2.00�� ADD
    '2009/09/10 UPD E.N.D RISE)MIYAJIMA

    '2019/04/17 ADD START
    Sub Error_Exit(ByVal ErrorMsg As String)
        Dim rtn As Object
        Dim I As Short
        '
        Call SSSWIN_LOGWRT(ErrorMsg)
        MsgBox("�v���O�������I�����܂��B", MsgBoxStyle.OkOnly, Trim(SSS_PrgNm))
        '
        If DBSTAT <> 0 Then
            MsgBox("�G���[���O�̏������݃G���[ ! Windows ���ċN�����Ă�������")
            '
        Else
            For I = SSS_MAX_DB - 1 To 0 Step -1
                Call DB_NCCLOSE(I)
            Next I
        End If
        Call DB_End()
        'UPGRADE_WARNING: �I�u�W�F�N�g rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
        End
    End Sub

    Function DSP_MsgBox(ByRef MSGKB As String, ByRef msgName As String, ByRef MSGSQ As Short) As Short
        '    '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȉ��ǉ�
        '    '�����C����ʂ���̃��b�Z-�W�o�͂̂ݑΉ��B�T�u��ʖ��Ή��B
        '    Dim WK_PP As clsPP
        '    WK_PP = PP_SSSMAIN
        '    '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȏ�ǉ�
        '' SSS/Win ���ʂ̃��b�Z�[�W��\�����܂��B
        '    '
        '    ''Close��̓��b�Z�[�W��\�����Ȃ�
        '    If RsOpened(DBN_SYSTBH) = False Then Exit Function
        '    ''
        '    DB_SYSTBH.MSGNM = msgName
        '    Call DB_GetEq(DBN_SYSTBH, 1, MSGKB & DB_SYSTBH.MSGNM & Format$(MSGSQ, "0"), BtrNormal)
        '    If DBSTAT = 0 Then
        '        DSP_MsgBox = MsgBox(Trim$(DB_SYSTBH.MSGCM), SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim$(SSS_PrgNm))
        '    Else
        '        MsgBox "���b�Z�[�W�t�@�C���G���[  " & Chr(13) & Chr(13) & "DBSTAT=" & Format$(DBSTAT, "##0") & Chr(13) & "MsgKb=" & MSGKB & " MsgName=(" & msgName & ") MsgSq=" & Format$(MSGSQ, "0"), MB_OK, Trim$(SSS_PrgNm)
        '        Call Error_Exit("���b�Z�[�W�t�@�C���G���[!")
        '    End If
        '    '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȉ��ǉ�
        '    PP_SSSMAIN = WK_PP
        '    '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȏ�ǉ�
    End Function

    Function SSS_EDTITM_WLS(ByVal Item As Object, ByVal KETA As Object, ByVal HENSYU As Object) As String
        Select Case HENSYU
            Case "0"
                'UPGRADE_WARNING: �I�u�W�F�N�g KETA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                SSS_EDTITM_WLS = RightWid(FormatAndRound(Item, "00000000000000000000"), KETA)
            Case Else
                'UPGRADE_WARNING: �I�u�W�F�N�g Item �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                SSS_EDTITM_WLS = Item
        End Select
    End Function

    '2019/04/17 ADD E N D


    'add 20190808 START
    Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
        'UPGRADE_WARNING: �I�u�W�F�N�g SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
        'PP_SSSMAIN.CursorDirection = 1
        'WLS_SLISTCOM = SlistCom
    End Sub
    'add 20190808 END

End Module