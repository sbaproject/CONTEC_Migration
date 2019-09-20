Attribute VB_Name = "SSSMAIN0001"
Option Explicit

Public Type Cls_All
    dummy As String
End Type

Global SSS_CLTID            As String * 5
Global SSS_OPEID            As String * 8

Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long

'�v���O�������
Public Const SSS_PrgId                  As String = "SYKFP70"
Public Const SSS_PrgNm                  As String = "�o�ח\��f�[�^�쐬"

'���b�Z�[�W�R�[�h
Private Const pc_strMsgCode_001         As String = "2SYKFP70_001"      'PLSQL���s�G���[�p���b�Z�[�W
Private Const pc_strMsgCode_002         As String = "2SYKFP70_002"

'INI�t�@�C����
Private Const pc_strININame             As String = "SSSWIN.ini"

'INI�t�@�C���Ǎ��p�萔
Private Const pc_strIni_LOGPATH         As String = "LOG_PATH"
Private Const pc_strIni_LOGNAME         As String = "LOG_NAME"

'INI�t�@�C���Ǎ����e�i�[�ϐ�
Private pv_strLOG_PATH                  As String           '�G���[���O�t�@�C���p�X
Private pv_strLOG_NAME                  As String           '�G���[���O�t�@�C����

'�R�}���h���C���������e�i�[�ϐ�
Private pv_strPGID_Moto                 As String           '�ďo���v���O����ID
Private pv_strPGNM_Moto                 As String           '�ďo���v���O������

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Sub Main
'   �T�v�F  �又��
'   �����F  �Ȃ�
'   �ߒl�F  �Ȃ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Sub Main()

    Dim intRet      As Integer
    Dim intRet_Main As Integer
    
On Error GoTo Err_Main
    
    '��������
    intRet = InitMain()
    If intRet <> 0 Then
        GoTo Err_Main
    End If
    
    '�g�����U�N�V�����J�n
    Call CF_Ora_BeginTrans(gv_Odb_USR1)
    
    'PLSQL���s����
    intRet_Main = F_Execute_PLSQL
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
Private Function InitMain() As Integer

    Dim intRet          As Integer
    Dim bolRet          As Boolean
    Dim strErrMsg       As String
    
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
Private Function F_Execute_PLSQL() As Integer
    
    Dim intRet              As Integer
    Dim strSQL              As String           'SQL��
    Dim strParam1           As String           '���Ұ�1(��۸���ID)
    Dim strParam2           As String           '���Ұ�2(�ײ���ID)
    Dim lngParam3           As Long             '���Ұ�7(���A����)
    Dim strParam4           As String * 3000    '���Ұ�8(�װ���e)
    Dim param(4)            As OraParameter     'PL/SQL�̃o�C���h�ϐ�
    Dim bolRet              As Boolean
    
    F_Execute_PLSQL = 9
    
    '��n���ϐ������ݒ�
    strParam1 = pv_strPGID_Moto
    strParam2 = SSS_CLTID
    lngParam3 = 0
    strParam4 = ""
    
    '�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
    gv_Odb_USR1.Parameters.Add "P1", strParam1, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P2", strParam2, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P3", lngParam3, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P4", strParam4, ORAPARM_OUTPUT
    
    '�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
    Set param(1) = gv_Odb_USR1.Parameters("P1")
    Set param(2) = gv_Odb_USR1.Parameters("P2")
    Set param(3) = gv_Odb_USR1.Parameters("P3")
    Set param(4) = gv_Odb_USR1.Parameters("P4")
    
    '�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
    param(1).serverType = ORATYPE_CHAR
    param(2).serverType = ORATYPE_CHAR
    param(3).serverType = ORATYPE_NUMBER
    param(4).serverType = ORATYPE_CHAR
    
    'PL/SQL�Ăяo��SQL
    strSQL = "BEGIN SYKFP70.P01(:P1,:P2,:P3,:P4); End;"

    'DB�A�N�Z�X
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo F_Execute_PLSQL_END
    End If

    '** �߂�l�擾
    lngParam3 = param(3).Value
    If IsNull(param(4).Value) = False Then
        strParam4 = param(4).Value
    End If

    '�G���[���ݒ�
    gv_Str_OraErrText = Trim(strParam4)

    F_Execute_PLSQL = lngParam3
    
F_Execute_PLSQL_END:
    '** �p�����^����
    gv_Odb_USR1.Parameters.Remove "P1"
    gv_Odb_USR1.Parameters.Remove "P2"
    gv_Odb_USR1.Parameters.Remove "P3"
    gv_Odb_USR1.Parameters.Remove "P4"

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function EndMain
'   �T�v�F  �I������
'   �����F  �Ȃ�
'   �ߒl�F  0 : ���� 9 : �ُ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function EndMain() As Integer

    Dim bolRet          As Boolean
    
    EndMain = 9
    
    'DB�ڑ�����
    bolRet = CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
    If bolRet = False Then
        '�G���[���O�o��
        Call F_Edit_ErrLog(gv_Int_OraErr, gv_Str_OraErrText, "EndMain")
        Exit Function
    End If
    
    EndMain = 0

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function F_INIT_GETINI
'   �T�v�F  Ini�t�@�C���Ǎ��ݏ����i�v���O�����ŗL�j
'   �����F  �Ȃ�
'   �ߒl�F  0 : ���� 9 : �ُ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function F_INIT_GETINI() As Integer

    Dim Wk          As String * 256
    Dim lngRet      As Long
    Dim intRet      As Integer
    
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
Private Function F_Edit_ErrLog(ByVal pin_intErrCd As Integer, _
                               ByVal pin_strErrMsg As String, _
                               ByVal pin_strErrLocation As String) As Integer

    Dim intRet          As Integer
    Dim strTime         As String
    Dim strDate         As String
    
    F_Edit_ErrLog = 9
    
    strTime = ""
    strDate = ""
    
    '�V�X�e�����t�擾
    Call CF_Get_SysDt
    If GV_SysDate = "" Then
        strDate = Format(Now(), "yyyymmdd")
    Else
        strDate = GV_SysDate
    End If
    
    If GV_SysTime = "" Then
        strTime = Format(Now(), "HHMMSS")
    Else
        strTime = GV_SysTime
    End If
    
    '�G���[���O��������
    Call CF_Edit_ErrLog(pv_strLOG_PATH _
                      , pv_strLOG_NAME _
                      , SSS_PrgId _
                      , pin_intErrCd _
                      , pin_strErrMsg _
                      , pin_strErrLocation _
                      , strTime _
                      , strDate)
    
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
Private Function F_Get_CmdLine(ByRef pot_strErrMsg As String) As Integer

    Dim intRet          As Integer
    Dim strTime         As String
    Dim strDate         As String
    Dim strCmd()        As String
    Dim strCmd2()       As String
    
    F_Get_CmdLine = 9
    
    pot_strErrMsg = ""
    
    strCmd = Split(Trim$(Command$), "/")
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
            SSS_CLTID = Trim(strCmd2(1))
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



