Option Strict Off
Option Explicit On
Imports Oracle.DataAccess.Client
Imports VB = Microsoft.VisualBasic
Module SSSMAIN0001

    '�v���O�����������v���V�W��
    '2019/09/18 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure

    Public PP_SSSMAIN As clsPP
    Public Const SSS_ERROR As String = "2" ' �r�r�r�G���[���b�Z�[�W

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
        '20190618 CHG START
        'Call DB_TANMTA_Clear(DB_TANMTA)
        Call InitDataCommon("TANMTA")
        '20190618 CHG END

        intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
        If intRet = 0 Then
            Ret_Value = DB_TANMTA.TANNM
        End If

        CF_Get_TANNM = Ret_Value

    End Function

    Function DSP_MsgBox(ByRef MSGKB As String, ByRef msgName As String, ByRef MSGSQ As Short) As Short
        '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȉ��ǉ�
        '�����C����ʂ���̃��b�Z-�W�o�͂̂ݑΉ��B�T�u��ʖ��Ή��B
        Dim WK_PP As clsPP
        'UPGRADE_WARNING: �I�u�W�F�N�g WK_PP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WK_PP = PP_SSSMAIN
        '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȏ�ǉ�
        ' SSS/Win ���ʂ̃��b�Z�[�W��\�����܂��B
        '
        ''Close��̓��b�Z�[�W��\�����Ȃ�
        'If RsOpened(DBN_SYSTBH) = False Then Exit Function
        ''
        DB_SYSTBH.MSGNM = msgName
        'Call DB_GetEq(DBN_SYSTBH, 1, MSGKB & DB_SYSTBH.MSGNM & VB6.Format(MSGSQ, "0"), BtrNormal)
        '2019/06/26 CHG START
        'Call SYSTBH_GetFirst(MSGKB, DB_SYSTBH.MSGNM, "")
        Dim sqlWhereStr As String = ""
        sqlWhereStr = " WHERE MSGKB = '" & MSGKB & "'"
        sqlWhereStr = sqlWhereStr & " AND MSGNM = '" & DB_SYSTBH.MSGNM & "'"
        Call GetRowsCommon("SYSTBH", sqlWhereStr)

        If DB_SYSTBH.MSGKB Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '2019/06/25 CHG E N D

        If DBSTAT = 0 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYSTBH.ICNKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYSTBH.BTNON) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYSTBH.BTNKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            DSP_MsgBox = MsgBox(Trim(DB_SYSTBH.MSGCM), SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim(SSS_PrgNm))
        Else
            MsgBox("���b�Z�[�W�t�@�C���G���[  " & Chr(13) & Chr(13) & "DBSTAT=" & VB6.Format(DBSTAT, "##0") & Chr(13) & "MsgKb=" & MSGKB & " MsgName=(" & msgName & ") MsgSq=" & VB6.Format(MSGSQ, "0"), MsgBoxStyle.OkOnly, Trim(SSS_PrgNm))
            Call Error_Exit("���b�Z�[�W�t�@�C���G���[!")
        End If
        '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȉ��ǉ�
        'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        PP_SSSMAIN = WK_PP
        '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȏ�ǉ�
    End Function

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
    '2019/09/18 ADD E N D

    '2019/09/18 DEL START
    'Public Structure Cls_All
    '    Dim dummy As String
    'End Structure
    '2019/09/18 DEL E N D

    Public SSS_CLTID As New VB6.FixedLengthString(5)
    Public SSS_OPEID As New VB6.FixedLengthString(8)

    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/09/18 CHG START
    'Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '2019/09/18 CHG E N D

    '�v���O�������
    Public Const SSS_PrgId As String = "SYKFP70"
    Public Const SSS_PrgNm As String = "�o�ח\��f�[�^�쐬"

    '���b�Z�[�W�R�[�h
    Private Const pc_strMsgCode_001 As String = "2SYKFP70_001" 'PLSQL���s�G���[�p���b�Z�[�W
    Private Const pc_strMsgCode_002 As String = "2SYKFP70_002"

    'INI�t�@�C����
    Private Const pc_strININame As String = "SSSWIN.ini"

    'INI�t�@�C���Ǎ��p�萔
    Private Const pc_strIni_LOGPATH As String = "LOG_PATH"
    Private Const pc_strIni_LOGNAME As String = "LOG_NAME"

    'INI�t�@�C���Ǎ����e�i�[�ϐ�
    Private pv_strLOG_PATH As String '�G���[���O�t�@�C���p�X
    Private pv_strLOG_NAME As String '�G���[���O�t�@�C����

    '�R�}���h���C���������e�i�[�ϐ�
    Private pv_strPGID_Moto As String '�ďo���v���O����ID
    Private pv_strPGNM_Moto As String '�ďo���v���O������

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Main
    '   �T�v�F  �又��
    '   �����F  �Ȃ�
    '   �ߒl�F  �Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Sub Main()

        Dim intRet As Short
        Dim intRet_Main As Short

        On Error GoTo Err_Main

        '��������
        intRet = InitMain()
        If intRet <> 0 Then
            GoTo Err_Main
        End If

        '�g�����U�N�V�����J�n
        '2019/09/20 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/09/20 CHG E N D

        'PLSQL���s����
        intRet_Main = F_Execute_PLSQL()

        If intRet_Main <> 0 Then
            '�G���[���O�o��
            Call F_Edit_ErrLog(gv_Int_OraErr, gv_Str_OraErrText, "F_Execute_PLSQL")
        End If

        If intRet_Main = 0 Then
            '�R�~�b�g
            Call CF_Ora_CommitTrans(gv_Odb_USR1)
        Else
            '���[���o�b�N
            Call CF_Ora_RollbackTrans(gv_Odb_USR1)
        End If

        '�I������
        intRet = EndMain()

End_Main:
        '�I��
        Exit Sub

Err_Main:
        GoTo End_Main

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function InitMain
    '   �T�v�F  ��������
    '   �����F  �Ȃ�
    '   �ߒl�F  0 : ���� 9 : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function InitMain() As Short

        Dim intRet As Short
        Dim bolRet As Boolean
        Dim strErrMsg As String

        InitMain = 9

        strErrMsg = ""

        'INI�t�@�C���Ǎ���
        intRet = F_INIT_GETINI()
        If intRet <> 0 Then
            Exit Function
        End If

        'DB�ڑ�
        bolRet = CF_Ora_USR1_Open_BAT()
        If bolRet = False Then
            '�G���[���O�o��
            Call F_Edit_ErrLog(gv_Int_OraErr, gv_Str_OraErrText, "InitMain")
            Exit Function
        End If

        '���ʏ���������
        intRet = CF_Init_BAT(strErrMsg, SSS_PrgId)
        If intRet <> 0 Then
            '�G���[���O�o��
            Call F_Edit_ErrLog(0, strErrMsg, "InitMain")
            Exit Function
        End If

        '�R�}���h���C�������擾����
        intRet = F_Get_CmdLine(strErrMsg)
        If intRet <> 0 Then
            '�G���[���O�o��
            Call F_Edit_ErrLog(0, strErrMsg, "InitMain")
            Exit Function
        End If

        InitMain = 0

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Execute_PLSQL
    '   �T�v�F  SQL���s����
    '   �����F  �Ȃ�
    '   �ߒl�F  0 : ���� 9: �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Execute_PLSQL() As Short

        Dim intRet As Short
        Dim strSQL As String 'SQL��
        Dim strParam1 As String '���Ұ�1(��۸���ID)
        Dim strParam2 As String '���Ұ�2(�ײ���ID)
        Dim lngParam3 As Integer '���Ұ�7(���A����)
        Dim strParam4 As New VB6.FixedLengthString(3000) '���Ұ�8(�װ���e)
        'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/09/18 DEL START
        'Dim param(4) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
        '2019/09/18 DEL START
        Dim bolRet As Boolean

        F_Execute_PLSQL = 9

        '��n���ϐ������ݒ�
        strParam1 = pv_strPGID_Moto
        strParam2 = SSS_CLTID.Value
        lngParam3 = 0
        strParam4.Value = ""

        '2019/09/18 ADD START
        Dim cmd As New OracleCommand
        cmd.Connection = CON
        cmd.CommandType = CommandType.StoredProcedure
        '2019/09/18 ADD E N D

        '2019/09/18 CHG START
        ''�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
        ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'gv_Odb_USR1.Parameters.Add("P1", strParam1, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'gv_Odb_USR1.Parameters.Add("P2", strParam2, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'gv_Odb_USR1.Parameters.Add("P3", lngParam3, ORAPARM_OUTPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'gv_Odb_USR1.Parameters.Add("P4", strParam4.Value, ORAPARM_OUTPUT)
        Dim inP1 As OracleParameter = New OracleParameter
        inP1.ParameterName = "P1"
        inP1.Direction = ParameterDirection.Input
        inP1.Value = strParam1
        cmd.Parameters.Add(inP1)
        Dim inP2 As OracleParameter = New OracleParameter
        inP2.ParameterName = "P2"
        inP2.Direction = ParameterDirection.Input
        inP2.Value = strParam2
        cmd.Parameters.Add(inP2)
        Dim inP3 As OracleParameter = New OracleParameter
        inP3.ParameterName = "P3"
        inP3.Direction = ParameterDirection.Input
        inP3.Value = lngParam3
        cmd.Parameters.Add(inP3)
        Dim inP4 As OracleParameter = New OracleParameter
        inP4.ParameterName = "P4"
        inP4.Direction = ParameterDirection.Input
        inP4.Value = strParam4
        cmd.Parameters.Add(inP4)
        '2019/09/18 CHG E N D

        '2019/09/18 DEL START
        ''�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
        ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'param(1) = gv_Odb_USR1.Parameters("P1")
        ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'param(2) = gv_Odb_USR1.Parameters("P2")
        ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'param(3) = gv_Odb_USR1.Parameters("P3")
        ''UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'param(4) = gv_Odb_USR1.Parameters("P4")
        '2019/09/18 DEL E N D

        '2019/09/18 CHG START
        ''�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
        ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'param(1).serverType = ORATYPE_CHAR
        ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'param(2).serverType = ORATYPE_CHAR
        ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'param(3).serverType = ORATYPE_NUMBER
        ''UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'param(4).serverType = ORATYPE_CHAR
        inP1.OracleDbType = OracleDbType.Char
        inP2.OracleDbType = OracleDbType.Char
        inP3.OracleDbType = OracleDbType.Char
        inP4.OracleDbType = OracleDbType.Char

        '2019/09/18 CHG E N D

        'PL/SQL�Ăяo��SQL
        strSQL = "BEGIN SYKFP70.P01(:P1,:P2,:P3,:P4); End;"

        'DB�A�N�Z�X
        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        If bolRet = False Then
            GoTo F_Execute_PLSQL_END
        End If

        '** �߂�l�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/09/18 CHG START
        'lngParam3 = param(3).Value
        lngParam3 = inP3.Value.ToString
        ''UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        'If IsDBNull(param(4).Value) = False Then
        '    'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    strParam4.Value = param(4).Value
        'End If
        If inP4.Value <> Nothing Then
            If IsDBNull(inP4.Value) = False Then
                'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strParam4.Value = inP4.Value.ToString
            Else
                strParam4.Value = 0
            End If
        Else
            strParam4.Value = 0
        End If

        '2019/09/18 CHG E N D

        '�G���[���ݒ�
        gv_Str_OraErrText = Trim(strParam4.Value)

        F_Execute_PLSQL = lngParam3

F_Execute_PLSQL_END:
        '** �p�����^����
        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gv_Odb_USR1.Parameters.Remove("P1")
        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gv_Odb_USR1.Parameters.Remove("P2")
        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gv_Odb_USR1.Parameters.Remove("P3")
        'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gv_Odb_USR1.Parameters.Remove("P4")

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function EndMain
    '   �T�v�F  �I������
    '   �����F  �Ȃ�
    '   �ߒl�F  0 : ���� 9 : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function EndMain() As Short

        Dim bolRet As Boolean

        EndMain = 9

        '2019/09/18 DEL START
        ''DB�ڑ�����
        'bolRet = CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        'If bolRet = False Then
        '    '�G���[���O�o��
        '    Call F_Edit_ErrLog(gv_Int_OraErr, gv_Str_OraErrText, "EndMain")
        '    Exit Function
        'End If
        '2019/09/18 DEL START

        EndMain = 0

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_INIT_GETINI
    '   �T�v�F  Ini�t�@�C���Ǎ��ݏ����i�v���O�����ŗL�j
    '   �����F  �Ȃ�
    '   �ߒl�F  0 : ���� 9 : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_INIT_GETINI() As Short

        Dim Wk As New VB6.FixedLengthString(256)
        Dim lngRet As Integer
        Dim intRet As Short

        F_INIT_GETINI = 9

        ' === 20061102 === UPDATE S - ACE)Nagasawa INI�t�@�C���i�[�ꏊ�ύX
        '    'SSSWIN.INI �Ǎ���
        '    '���O�t�@�C���p�X
        '    lngRet = GetPrivateProfileString(SSS_PrgId, pc_strIni_LOGPATH, "", Wk, Len(Wk), pc_strININame)
        '    If lngRet > 0 Then
        '        pv_strLOG_PATH = CF_Ctr_AnsiLeftB(Wk, lngRet)
        '        pv_strLOG_PATH = Trim$(pv_strLOG_PATH)
        '        If Right(pv_strLOG_PATH, 1) <> "\" Then
        '            pv_strLOG_PATH = pv_strLOG_PATH & "\"
        '        End If
        '    Else
        '        Exit Function
        '    End If
        '
        '    '���O�t�@�C����
        '    lngRet = GetPrivateProfileString(SSS_PrgId, pc_strIni_LOGNAME, "", Wk, Len(Wk), pc_strININame)
        '    If lngRet > 0 Then
        '        pv_strLOG_NAME = CF_Ctr_AnsiLeftB(Wk, lngRet)
        '        pv_strLOG_NAME = Trim$(pv_strLOG_NAME)
        '    Else
        '        Exit Function
        '    End If

        'SSSWIN.INI �Ǎ���
        '���O�t�@�C���p�X
        intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_LOGPATH, pv_strLOG_PATH)
        If lngRet <> 0 Then
            Exit Function
        End If

        '���O�t�@�C����
        intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_LOGNAME, pv_strLOG_NAME)
        If lngRet <> 0 Then
            Exit Function
        End If
        ' === 20061102 === UPDATE E -

        F_INIT_GETINI = 0

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Edit_ErrLog
    '   �T�v�F  �G���[���O�o�͏���
    '   �����F  pin_intErrCd       : �G���[�R�[�h�i�I���N���G���[���ȊO�̓[���j
    '           pin_strErrMsg      : �G���[���b�Z�[�W
    '           pin_strErrLocation : �����ӏ��i�t�@���N�V�������j
    '   �ߒl�F  0 : ���� 9 : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Edit_ErrLog(ByVal pin_intErrCd As Short, ByVal pin_strErrMsg As String, ByVal pin_strErrLocation As String) As Short

        Dim intRet As Short
        Dim strTime As String
        Dim strDate As String

        F_Edit_ErrLog = 9

        strTime = ""
        strDate = ""

        '�V�X�e�����t�擾
        Call CF_Get_SysDt()
        If GV_SysDate = "" Then
            strDate = VB6.Format(Now, "yyyymmdd")
        Else
            strDate = GV_SysDate
        End If

        If GV_SysTime = "" Then
            strTime = VB6.Format(Now, "HHMMSS")
        Else
            strTime = GV_SysTime
        End If

        '�G���[���O��������
        Call CF_Edit_ErrLog(pv_strLOG_PATH, pv_strLOG_NAME, SSS_PrgId, pin_intErrCd, pin_strErrMsg, pin_strErrLocation, strTime, strDate)

        '�G���[���b�Z�[�W�o�͏���
        If pin_intErrCd <> 0 Then
            Call AE_CmnMsgLibrary_Bat(pv_strPGNM_Moto, pc_strMsgCode_001, "SYKFP70.P01")
        Else
            Call AE_CmnMsgLibrary_Bat(pv_strPGNM_Moto, pc_strMsgCode_002, pin_strErrMsg)
        End If

        F_Edit_ErrLog = 0

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Get_CmdLine
    '   �T�v�F  �R�}���h���C�������擾����
    '   �����F  pot_strErrMsg : �G���[���b�Z�[�W
    '   �ߒl�F  0 : ���� 9 : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Get_CmdLine(ByRef pot_strErrMsg As String) As Short

        Dim intRet As Short
        Dim strTime As String
        Dim strDate As String
        Dim strCmd() As String
        Dim strCmd2() As String

        F_Get_CmdLine = 9

        pot_strErrMsg = ""

        strCmd = Split(Trim(VB.Command()), "/")
        If UBound(strCmd) < 3 Then
            pot_strErrMsg = SSS_PrgNm & "�������s�p�̈���������������܂���B�ݒ���m�F���Ă��������B"
            Exit Function
        End If

        '�N���C�A���gID�擾
        strCmd2 = Split(Trim(strCmd(1)), ":")
        Select Case True
            '�������R�����ŋ�؂��Ă��Ȃ��ꍇ
            Case UBound(strCmd2) < 1
                pot_strErrMsg = SSS_PrgNm & "�������s�p�̈���������������܂���B�ݒ���m�F���Ă��������B"
                '�����̈ʒu���������Ȃ��ꍇ
            Case UCase(Trim(strCmd2(0))) <> "CLTID"
                pot_strErrMsg = SSS_PrgNm & "�������s�p�̈���(�ײ���ID)������������܂���B�ݒ���m�F���Ă��������B"
            Case Else
                SSS_CLTID.Value = Trim(strCmd2(1))
        End Select

        If Trim(pot_strErrMsg) <> "" Then
            Exit Function
        End If

        '�v���O����ID�擾
        strCmd2 = Split(Trim(strCmd(2)), ":")
        Select Case True
            '�������R�����ŋ�؂��Ă��Ȃ��ꍇ
            Case UBound(strCmd2) < 1
                pot_strErrMsg = SSS_PrgNm & "�������s�p�̈���������������܂���B�ݒ���m�F���Ă��������B"
                '�����̈ʒu���������Ȃ��ꍇ
            Case UCase(Trim(strCmd2(0))) <> "PGID"
                pot_strErrMsg = SSS_PrgNm & "�������s�p�̈���(��۸���ID)������������܂���B�ݒ���m�F���Ă��������B"
            Case Else
                pv_strPGID_Moto = Trim(strCmd2(1))
        End Select

        If Trim(pot_strErrMsg) <> "" Then
            Exit Function
        End If

        '�v���O�������擾
        strCmd2 = Split(Trim(strCmd(3)), ":")
        Select Case True
            '�������R�����ŋ�؂��Ă��Ȃ��ꍇ
            Case UBound(strCmd2) < 1
                pot_strErrMsg = SSS_PrgNm & "�������s�p�̈���������������܂���B�ݒ���m�F���Ă��������B"
                '�����̈ʒu���������Ȃ��ꍇ
            Case UCase(Trim(strCmd2(0))) <> "PGNM"
                pot_strErrMsg = SSS_PrgNm & "�������s�p�̈���(��۸��і�)������������܂���B�ݒ���m�F���Ă��������B"
            Case Else
                pv_strPGNM_Moto = Trim(strCmd2(1))
        End Select

        If Trim(pot_strErrMsg) <> "" Then
            Exit Function
        End If

        F_Get_CmdLine = 0

    End Function
End Module