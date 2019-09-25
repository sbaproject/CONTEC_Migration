Attribute VB_Name = "GRKBP00M"
Option Explicit
'//*****************************************************************************************
'//*
'//*�����́�
'//*    GRKBP00M.BAS
'//*
'//*���o�[�W������
'//*    1.00
'//*���쐬�ҁ�
'//*    Rise
'//*��������
'//*    �X�g�A�h�N�� ���W���[��
'//*****************************************************************************************
'//* CHANGE HISTORY
'//* Version  |YYYYMMDD|Programmer     |Description
'//* ---------|--------|---------------|---------------------------------------------------*
'//* 1.00     |20060710|Rise)          |�V�K
'//* ---------|--------|---------------|---------------------------------------------------*
'//* 1.01     |20071026|Rise)          |�r���������������~���ُ�I��
'//* ---------|--------|---------------|---------------------------------------------------*
'//* 1.10     |20080514|Rise)          |�Ǎ��񂾃t�@�C��������ёւ���(�t�@�C������)
'//*          |20080515|Rise)          |���M�t�@�C�������ɑ��݂��Ă���ꍇ�̓t�@�C������
'//*          |        |               |���Ԏ����Ɂ{�P���t�@�C�����쐬����
'//* 1.11     |20090128|Rise)          |1.10�Ή���RETRY�񐔂�INI̧�ق��擾����l�ɕύX
'//* 1.20     |20091015|Rise)          |�e�L�X�g�o�́��q�c�a�X�V�̃v���O�����̃��J�o���[�΍�
'//*****************************************************************************************
'//----------------------------------------------
'//�X���[�v
'//----------------------------------------------
Private Declare Function Sleep Lib "kernel32.dll" (ByVal mstime As Long) As Long

' -- ADD -- 2008/05/15 START (1.10)
'//�t�@�C�����R�s�[���܂��B
Private Declare Function CopyFile Lib "kernel32" _
    Alias "CopyFileA" _
    (ByVal lpExistingFileName As String, _
     ByVal lpNewFileName As String, _
     ByVal bFailIfExists As Long) _
    As Long
' -- ADD -- 2008/05/15 END   (1.10)

'//*****************************************************************************************
'// �v���O�������
'//*****************************************************************************************
'//�W���u�h�c�E�W���u����
Public Const gvcstJOB_ID                    As String = "GRKBP00"
Public Const gvcstJOB_Titl                  As String = "GRKBP00SQL"

'//���b�Z�[�W�{�b�N�X�\���t���O
Public Const gvcstDspMsg                    As Boolean = False

'//*****************************************************************************************
'// �C���X�^���X��`
'//*****************************************************************************************
Public D0                                   As ClsComn                  '//System �֐�
Public ClsMessage                           As ClsMessage               '//Message
Public clsOra                               As ClsOraDB

'//*****************************************************************************************
'// �ϐ���`
'//*****************************************************************************************
Public gvINIInformation                     As gvtypIniFile             '//�h�m�h�t�@�C���\����

'//*****************************************************************************************
'// �\���̒�`
'//*****************************************************************************************
Public Type typFileInfo
    strFilePath                             As String
    strFileName1                            As String
    strFileExtn1                            As String
    strFileName2                            As String
    strFileExtn2                            As String
    strFileTimeStampAddFlg                  As String
End Type

Public Type typFileName
    strFileName()                           As Variant
End Type

'//*****************************************************************************************
'// �o�f�ʕϐ���`
'//*****************************************************************************************
Public gvstrJOBID                           As String                   '//�p�����[�^���擾�����W���uID
Public gvstrPLSQLPACKAGE                    As String                   '//�N��PLSQL�p�b�P�[�W
Public gvstrPLSQLFUNCTION                   As String                   '//�N��PLSQL�t�@���N�V����

Public gvaryPARAMETER()                     As String                   '//�ǉ�PARAMETER
Public gvintInFileCount                     As Integer                  '//IN �t�@�C����
Public gvaryInFileInfo()                    As typFileInfo              '//IN �t�@�C�����
Public gvintOtFileCount                     As Integer                  '//OUT�t�@�C����
Public gvaryOtFileInfo()                    As typFileInfo              '//OUT�t�@�C�����
Public gvaryInGetFile()                     As typFileName              '//�t�H���_���t�@�C���ꗗ
Public gvaryOtGetFile()                     As typFileName              '//�t�H���_���t�@�C���ꗗ

' -- ADD -- 2007/02/08 START
Public Const pc_strIni_LOGPATH              As String = "LOG_PATH"
Public Const pc_strIni_LOGNAME              As String = "LOG_NAME"
Public Const pc_strIni_RETRY_INTERVAL       As String = "RETRY_INTERVAL"
Public Const pc_strIni_RETRY_TIMES          As String = "RETRY_TIMES"
Public pv_curRETRY_INTERVAL                 As Currency                 '���g���C�Ԋu
Public pv_curRETRY_TIMES                    As Currency                 '���g���C��
Public pv_strLOG_PATH                       As String                   '�G���[���O�t�@�C���p�X
Public pv_strLOG_NAME                       As String                   '�G���[���O�t�@�C����
Public gv_Int_OraErr                        As Integer                  '//ORACLE�G���[�ԍ�
Public gv_Str_OraErrText                    As String                   '//ORACLE�G���[�e�L�X�g
' -- ADD -- 2007/02/08 END

' -- ADD -- 2008/05/15 START (1.10)
Public gvstrPLSqlWkFileName                 As String                   '//�X�g�A�h�֓n�����[�N�t�@�C���̖��O�iJOBID + "WK")
' -- ADD -- 2008/05/15 END   (1.10)

' -- ADD -- 2009/01/28 START (1.11)
Public Const pc_strIni_RETRY_TIMESTAMP      As String = "RETRY_TIMESTAMP"
Public gvintRETRY_TIMESTAMP                 As Integer                  '//�^�C���X�^���v���O�ύXRETRY��
' -- ADD -- 2009/01/28 END   (1.11)

'//*****************************************************************************************
'//*
'//* <��  ��>
'//*    Main
'//*
'//* <�߂�l>
'//*
'//* <��  ��>     ���ږ�                  I/O           ���e
'//*
'//* <��  ��>
'//*    �V�X�e���N�����̎��s�v���V�W���[
'//*****************************************************************************************
Sub Main()
    
    On Error GoTo ONERR_STEP
    
    '//���ʃI�u�W�F�N�g�̃C���X�^���X�쐬
    If Not Ctr_Object(True) Then
'        GoTo EXIT_STEP     2007.10.26
        GoTo EXIT_STEP2
    End If

    '//�v���O�����Q�d�N���`�F�b�N
    If Not D0.ChkDuplicateInstance(gvcstJOB_Titl) Then
        If gvcstDspMsg Then
            MsgBox "�y" & Trim(gvcstJOB_Titl) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", _
                                                            vbExclamation Or vbOKOnly, gvcstJOB_Titl
        End If
        AppActivate gvcstJOB_Titl
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If
    
    '//�p�����[�^�̎擾
    If Not Get_CommandLine() Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If
    
    '//�ŗL�p�����[�^�̎擾
    If Not Get_CommandLineByPosition(2, gvstrJOBID) Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If
        
    '//�N���X�g�A�h���̐���
    gvstrPLSQLPACKAGE = Mid(gvstrJOBID, 1, 7)
    gvstrPLSQLFUNCTION = Mid(gvstrJOBID, 1, 7) & "B"
    
    '//�X�e�[�^�X�t�@�C���Ɉُ�I����������
    Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_Status.TXT", "NG", True)
    
    '//�h�m�h�t�@�C���̎擾(����)
    If Not GetIniFile(gvINIInformation) Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If

    '//�h�m�h�t�@�C���̎擾(��)
    If Not GetIndividualIniFile() Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If

    '//�f�[�^�x�[�X�ڑ�(ORACLE���ް)
    If Not clsOra.OraConnect(gvINIInformation.strSQLDATABASE, _
                                    gvINIInformation.strSQLUID, gvINIInformation.strSQLPWD, gvcstDspMsg) Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If

    '//���b�Z�[�W�N���X��OraDatabase�v���p�e�B���Z�b�g����
    ClsMessage.OraDatabase = clsOra.OraDatabase
    
' -- UPD -- 2007/10/26 START --------------------------
' -- ADD -- 2007/02/08 START
    '//�r������n�m
'   Call Ctr_HaitaOn
    If Not Ctr_HaitaOn() Then
        GoTo EXIT_STEP2
    End If
' -- ADD -- 2007/02/08 END
' -- UPD -- 2007/10/26 END ----------------------------
    
    '//�X�g�A�h�N������
    If Not Ctr_StoredProcedure Then
        GoTo EXIT_STEP
    End If

    '//�X�e�[�^�X�t�@�C���ɐ���I����������
    Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_Status.TXT", "OK", True)
    
'----------------------------------------------------------------------------------------
EXIT_STEP:
''''    '//���ʃI�u�W�F�N�g�̉��
''''    Call Ctr_Object(False)
    
' -- ADD -- 2007/02/08 START
    '//�r������n�e�e
    Call Ctr_HaitaOff
' -- ADD -- 2007/02/08 END

' -- ADD -- 2007/10/26 START
EXIT_STEP2:
' -- ADD -- 2007/10/26 END
    '//�I������
    Call Ctr_END
    
    On Error GoTo 0
    
    End
    
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        MsgBox "<Sub_Main> " & vbCrLf & "���s���G���[�ł��B�����𒆎~���܂��B" _
                            & vbCrLf & Err.Description, _
                            vbOKOnly + vbCritical, App.Title
    End If
    Resume EXIT_STEP

End Sub

'//*****************************************************************************************
'//*
'//* <��  ��>
'//*    Ctr_END
'//*
'//* <�߂�l>     �^          ����
'//*
'//* <��  ��>     ���ږ�             �^              I/O           ���e
'//*
'//* <��  ��>
'//*    �v���O�����̏I������
'//*****************************************************************************************
Public Sub Ctr_END()

    '//�f�[�^�x�[�X�ڑ�����(ORACLE���ް)
    Call clsOra.OraDisConnect
    '//���ʃI�u�W�F�N�g�̉��
    Call Ctr_Object(False)
    '//�v���O�����I��
    End

End Sub

'//*****************************************************************************************
'//*
'//* <��  ��>
'//*    Ctr_Object
'//*
'//* <�߂�l>     �^          ����
'//*              Boolean     True    :�ݒ�ł���
'//*                          False   :�ݒ�ł��Ȃ�����
'//*
'//* <��  ��>     ���ږ�             �^              I/O           ���e
'//*              pmf_Set          Boolean          I             True:�쐬 False:���
'//* <��  ��>
'//*    �I�u�W�F�N�g�C���X�^���X�̍쐬�^���
'//*****************************************************************************************
Function Ctr_Object(ByRef pmf_Set As Boolean) As Boolean

    Const PROCEDURE         As String = "Ctr_Object"
    
    On Error GoTo ONERR_STEP
    
    Ctr_Object = False
    
    If pmf_Set Then
        '//���ʃI�u�W�F�N�g�̃C���X�^���X�쐬
        Set D0 = New ClsComn                                '//���ʸ׽
        Set clsOra = New ClsOraDB                           '//Oracle
        Set ClsMessage = New ClsMessage                     '//Message
    Else
        '//���ʃI�u�W�F�N�g�̃C���X�^���X���
        If Not (ClsMessage Is Nothing) Then                 '//Message
            Set ClsMessage = Nothing
        End If
        If Not (clsOra Is Nothing) Then                     '//Oracle
            Set clsOra = Nothing
        End If
        If Not (D0 Is Nothing) Then                         '//���ʸ׽
            Set D0 = Nothing
        End If
    End If
    
    Ctr_Object = True
    
'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP
    
End Function

'//*****************************************************************************************
'//*
'//* <��  ��>
'//*    GetIndividualIniFile
'//*
'//* <�߂�l>
'//*              True    :�Ǎ��݂n�j
'//*              False   :�Ǎ��݂d�q�q
'//*
'//* <��  ��>     ���ږ�             I/O      ���e
'//*
'//* <��  ��>
'//*    �V�X�e�����ʏ����ݒ�t�@�C��(INI̧��)�̓Ǎ��ݏ���
'//*****************************************************************************************
Public Function GetIndividualIniFile() As Boolean
    
    Const PROCEDURE         As String = "GetIndividualIniFile"
    
    '//INI̧�َ擾��
    Const cstInFileCountKey As String = "INFILECOUNT"
    Const cstOtFileCountKey As String = "OTFILECOUNT"
    Const cstInFilePathKey  As String = "INFILEPATH"
    Const cstOtFilePathKey  As String = "OTFILEPATH"
    Const cstInFileNAMEKey  As String = "INFILENAME"
    Const cstOtFileNAMEKey  As String = "OTFILENAME"
    Const cstInFileCopyKey  As String = "INFILECPNM"
    Const cstOtFileTimeKey  As String = "OTFILETMSP"
    Const cstPARAMETERKey   As String = "PARAMETER"
    
    Dim wk_String                       As String
    Dim str_Key                         As String
    Dim str_Path                        As String
    Dim int_Idx                         As Integer
    Dim i                               As Integer
    
' -- ADD -- 2007/02/08 START
    Dim intRet      As Integer
    Dim strWK       As String
' -- ADD -- 2007/02/08 END
    
    On Error GoTo ONERR_STEP
    
    GetIndividualIniFile = False
    
    '��PATH�擾
    str_Path = GetFullPath(gvcst_IniFilePath)
    
    '//-------------------------------------------------------------
    '//�ǉ��p�����[�^�擾
    '//-------------------------------------------------------------
    ReDim gvaryPARAMETER(0)
    i = 0
    Do
        i = i + 1
        wk_String = D0.GetIniString(gvstrJOBID, cstPARAMETERKey & CStr(i), str_Path)
        If Trim(wk_String) = "" Then
            Exit Do
        End If
        ReDim Preserve gvaryPARAMETER(i)
        gvaryPARAMETER(i) = Trim(wk_String)
    Loop
    
    '//-------------------------------------------------------------
    '//IN ̧�ُ��擾
    '//-------------------------------------------------------------
    wk_String = D0.GetIniString(gvstrJOBID, cstInFileCountKey, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    gvintInFileCount = Val(wk_String)
    
    ReDim gvaryInFileInfo(gvintInFileCount)
    For i = 1 To gvintInFileCount
    
        '//--�t�@�C���p�X �擾--
        str_Key = cstInFilePathKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
        gvaryInFileInfo(i).strFilePath = wk_String
    
        '//--�t�@�C����   �擾--
        str_Key = cstInFileNAMEKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
        
        int_Idx = InStr(1, wk_String, ".")
        gvaryInFileInfo(i).strFileName1 = Mid(wk_String, 1, int_Idx - 1)
        gvaryInFileInfo(i).strFileExtn1 = Mid(wk_String, int_Idx)
    
        '//--�O��t�@�C����   �擾--
        str_Key = cstInFileCopyKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            gvaryInFileInfo(i).strFileName2 = ""
            gvaryInFileInfo(i).strFileExtn2 = ""
        Else
            int_Idx = InStr(1, wk_String, ".")
            gvaryInFileInfo(i).strFileName2 = Mid(wk_String, 1, int_Idx - 1)
            gvaryInFileInfo(i).strFileExtn2 = Mid(wk_String, int_Idx)
        End If
    
    Next i
    
    '//-------------------------------------------------------------
    '//OUŢ�ُ��擾
    '//-------------------------------------------------------------
    wk_String = D0.GetIniString(gvstrJOBID, cstOtFileCountKey, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    gvintOtFileCount = Val(wk_String)
    
    ReDim gvaryOtFileInfo(gvintOtFileCount)
    For i = 1 To gvintOtFileCount
    
        '//--�t�@�C���p�X �擾--
        str_Key = cstOtFilePathKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
        gvaryOtFileInfo(i).strFilePath = wk_String
    
        '//--�t�@�C����   �擾--
        str_Key = cstOtFileNAMEKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
    
        int_Idx = InStr(1, wk_String, ".")
        gvaryOtFileInfo(i).strFileName1 = Mid(wk_String, 1, int_Idx - 1)
        gvaryOtFileInfo(i).strFileExtn1 = Mid(wk_String, int_Idx)
    
        '//--�^�C���X�^���v�t���t���O �擾 (0:�t�����Ȃ� 1:�t������) --
        str_Key = cstOtFileTimeKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
        
        gvaryOtFileInfo(i).strFileTimeStampAddFlg = wk_String
    
    Next i
    
' -- ADD -- 2007/02/08 START
    '//-------------------------------------------------------------
    '//�e�v���O�����ɑΉ��������g���C�����擾����
    '//-------------------------------------------------------------
    '���g���C�Ԋu
    pv_curRETRY_INTERVAL = 1000
    wk_String = D0.GetIniString(gvstrJOBID, pc_strIni_RETRY_INTERVAL, str_Path)
    strWK = wk_String
    If IsNumeric(strWK) = True Then
        pv_curRETRY_INTERVAL = CCur(strWK)
    End If
    
    '���g���C��
    pv_curRETRY_TIMES = 5
    wk_String = D0.GetIniString(gvstrJOBID, pc_strIni_RETRY_TIMES, str_Path)
    strWK = wk_String
    If IsNumeric(strWK) = True Then
        pv_curRETRY_TIMES = CCur(strWK)
    End If
    '//-------------------------------------------------------------
    '//�r������p��INI�擾
    '//-------------------------------------------------------------
    '���O�t�@�C���p�X
    wk_String = D0.GetIniString(gvcstJOB_ID, pc_strIni_LOGPATH, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    pv_strLOG_PATH = wk_String
    
    '���O�t�@�C����
    wk_String = D0.GetIniString(gvcstJOB_ID, pc_strIni_LOGNAME, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    pv_strLOG_NAME = wk_String

' -- ADD -- 2007/02/08 END
    
' -- ADD -- 2009/01/28 START (1.11)
    '//-------------------------------------------------------------
    '//�^�C���X�^���v�̖��O�ύX������RETRY�񐔂̎擾
    '//-------------------------------------------------------------
    'RETRY��
    wk_String = D0.GetIniString(gvcstJOB_ID, pc_strIni_RETRY_TIMESTAMP, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    If IsNumeric(wk_String) = True Then
        gvintRETRY_TIMESTAMP = CInt(wk_String)
    End If
' -- ADD -- 2009/01/28 END   (1.11)
    
    GetIndividualIniFile = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ERROR_STEP:
    If gvcstDspMsg Then
        MsgBox "�y" & Trim(gvcstJOB_Titl) & "�z�͂h�m�h�t�@�C���̎擾�Ɏ��s���܂����B�����𒆎~���܂��B", _
                                                        vbExclamation Or vbOKOnly, App.Title
    End If
    GoTo EXIT_STEP
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP
End Function

'//*****************************************************************************************
'//*
'//* <��  ��>
'//*    Ctr_StoredProcedure
'//*
'//* <�߂�l>   �^                  ����
'//*            Boolean             True:OK , False:Error
'//*
'//* <��  ��>   ���ږ�              �^              I/O     ���e
'//*
'//* <��  ��>
'//*    �X�g�A�h�����̋N��
'//*****************************************************************************************
Public Function Ctr_StoredProcedure() As Boolean

    Const PROCEDURE         As String = "Ctr_StoredProcedure"
    
    Dim i                   As Integer
    Dim vntArray            As Variant
    Dim strNewTimeStamp     As String
    Dim strOldTimeStamp     As String
    Dim strNewFileName      As String
    Dim strOldFileName      As String
    Dim strFrFileName       As String
    Dim strToFileName       As String
    Dim strZnFileName       As String
    Dim int_LoopCnt         As Integer
    Dim int_LoopMax         As Integer
    
    On Error Resume Next
    Kill GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_DelLst.TXT"
    On Error GoTo 0
    
    On Error GoTo ONERR_STEP
    
    Ctr_StoredProcedure = False

    int_LoopMax = 1
    int_LoopCnt = 1
    
' -- ADD -- 2008/05/15 START (1.10)
    gvstrPLSqlWkFileName = gvstrJOBID & "_WK"
' -- ADD -- 2008/05/15 END   (1.10)
    
    '// IN ̧�وꗗ���擾
    ReDim gvaryInGetFile(0)
    For i = 1 To gvintInFileCount
        ReDim Preserve gvaryInGetFile(i)
        Call Get_FileList(gvaryInFileInfo(i).strFilePath, _
                          gvaryInFileInfo(i).strFileName1 & "*" & gvaryInFileInfo(i).strFileExtn1, _
                          vntArray, int_LoopMax)
        gvaryInGetFile(i).strFileName = vntArray
    Next i

    '// IN ̧�وꗗ�̔z��̎��������킹��
    For i = 1 To gvintInFileCount
        ReDim Preserve gvaryInGetFile(i).strFileName(int_LoopMax)
    Next i

    '//�X�g�A�h�N��
    Do Until int_LoopCnt > int_LoopMax
        
        '// �^�C���X�^���v�擾
        Do
            strNewTimeStamp = clsOra.OraGetNowDt(1) & clsOra.OraGetNowTm
            If strOldTimeStamp <> strNewTimeStamp Then
                Exit Do
            End If
            D0.Ctr_WaitTime (1)
        Loop
        strOldTimeStamp = strNewTimeStamp
        
        '// OUŢ�وꗗ�𐶐�
        ReDim gvaryOtGetFile(0)
        For i = 1 To gvintOtFileCount
            ReDim Preserve gvaryOtGetFile(i)
            ReDim Preserve gvaryOtGetFile(i).strFileName(1)
            '// ��ѽ���ߕt������
            If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
                gvaryOtGetFile(i).strFileName(1) = gvaryOtFileInfo(i).strFileName1 & _
                                    strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
            Else
                gvaryOtGetFile(i).strFileName(1) = gvaryOtFileInfo(i).strFileName1 & _
                                                      gvaryOtFileInfo(i).strFileExtn1
            End If
        Next i
        
' -- ADD -- 2007/01/14 START
        '// ���M�t�@�C���̃o�b�N�A�b�v�Ƒ��M�t�@�C���̖��O��ύX
        On Error Resume Next
        For i = 1 To gvintOtFileCount
            '//���O�ύX
            If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) <> 1 Then
' -- UPD -- 2008/05/15 START (1.10)
'                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                             "WK" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
                             gvstrPLSqlWkFileName & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
' -- UPD -- 2008/05/15 END   (1.10)
                strNewFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
                                    gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
                If Dir(strOldFileName) <> "" Then
                    Kill strOldFileName
                End If
                If Dir(strNewFileName) <> "" Then
' -- UPD -- 2009/10/15 START (1.20)
'                    Name strNewFileName As strOldFileName
                    '//�R�s�[����
                    Call CopyFile(strNewFileName, strOldFileName, 0)
' -- UPD -- 2009/10/15 END   (1.20)
                End If
            End If
        Next i
        On Error GoTo 0
        On Error GoTo ONERR_STEP
' -- ADD -- 2007/01/14 END
        
        '// �X�g�A�h�����̎��s����
        If Not RunStoredProcedure(int_LoopCnt) Then
            GoTo EXIT_STEP
        End If
        
' -- UPD -- 2009/01/28 START (1.11)
' -- UPD -- 2006/12/15 START
        '// ���M�t�@�C���̃o�b�N�A�b�v�Ƒ��M�t�@�C���̖��O��ύX
        If Not Snd_FileCopy(strNewTimeStamp) Then
            GoTo EXIT_STEP
        End If

'        '// ���M�t�@�C���̃o�b�N�A�b�v�Ƒ��M�t�@�C���̖��O��ύX
'        On Error Resume Next
'        For i = 1 To gvintOtFileCount
'
'            '//�o�b�N�A�b�v
'            If UCase(Right(gvaryOtFileInfo(i).strFilePath, 3)) <> "TMP" Then
'                '// ��ѽ���ߕt������
'                If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
'                    strFrFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                                 "WK" & gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'                    strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\SND\" & _
'                                        gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'                Else
'                    strFrFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                                 "WK" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
'                    strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\SND\" & _
'                                        gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'                End If
'                FileCopy strFrFileName, strToFileName
'            End If
'
'            '//���O�ύX
'            '// ��ѽ���ߕt������
'            If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
'                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                             "WK" & gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'                strNewFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                                    gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'            Else
'                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                             "WK" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
'                strNewFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                                    gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
'            End If
'            If Dir(strNewFileName) <> "" Then
'                Kill strNewFileName
'            End If
'            Name strOldFileName As strNewFileName
'
'        Next i
'        On Error GoTo 0
' -- UPD -- 2006/12/15 END
' -- UPD -- 2009/01/28 END   (1.11)
        
        '// ��M�t�@�C���̃o�b�N�A�b�v�ƍ폜���X�g���쐬
        On Error GoTo ONERR_STEP
        For i = 1 To gvintInFileCount
            
            If Not IsEmpty(gvaryInGetFile(i).strFileName(int_LoopCnt)) Then
                '//�o�b�N�A�b�v
                strFrFileName = gvaryInFileInfo(i).strFilePath & "\" & gvaryInGetFile(i).strFileName(int_LoopCnt)
' -- UPD -- 2006/12/15 START
'                strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\RCV\" & gvaryInGetFile(i).strFileName(int_LoopCnt)
                strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\RCV\" & _
                                    AddTimeStampFileName(gvaryInGetFile(i).strFileName(int_LoopCnt))
' -- UPD -- 2006/12/15 END
                If UCase(Right(gvaryInFileInfo(i).strFilePath, 3)) <> "TMP" Then
                    FileCopy strFrFileName, strToFileName
                End If
    
                If gvaryInFileInfo(i).strFileName2 = "" Then
                    If UCase(Right(gvaryInFileInfo(i).strFileName1, 3)) <> "ZEN" Then
                        '//�t�@�C���폜
                        Kill strFrFileName
                    End If
                Else
                    '//�O�񕪂֕ۑ�
                    strZnFileName = Replace(UCase(strFrFileName), UCase(gvaryInFileInfo(i).strFileName1), UCase(gvaryInFileInfo(i).strFileName2))
                    strZnFileName = Replace(UCase(strZnFileName), UCase(gvaryInFileInfo(i).strFileExtn1), UCase(gvaryInFileInfo(i).strFileExtn2))
                    If Dir(strZnFileName) <> "" Then
                        Kill strZnFileName
                    End If
                    Name strFrFileName As strZnFileName
                End If
                
                '//�폜���X�g�쐬
                If UCase(Right(gvaryInFileInfo(i).strFilePath, 3)) <> "TMP" Then
                    Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_DelLst.TXT", gvaryInGetFile(i).strFileName(int_LoopCnt), False)
                End If
            End If
        
        Next i
    
        int_LoopCnt = int_LoopCnt + 1
    
    Loop
    
    Ctr_StoredProcedure = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP

End Function

' -- ADD -- 2008/05/15 START (1.10)
'//****************************************************************************************
'//*
'//* <��  ��>
'//*    Snd_FileCopy
'//*
'//* <�߂�l>     �^          ����
'//*
'//* <��  ��>     ���ږ�             �^              I/O           ���e
'//*
'//* <��  ��>
'//*    ���M�t�@�C���̃o�b�N�A�b�v�Ɩ��O�̕ύX���s��
'//****************************************************************************************
Function Snd_FileCopy(ByRef pstrNewTimeStamp As String) As Boolean

    Const PROCEDURE             As String = "Snd_FileCopy"
    
    Dim str_FromFileName        As String
    Dim str_BackToFileName      As String
    Dim str_SendToFileName      As String
    Dim dtaNewTimeStamp         As Date
    Dim i                       As Integer
    Dim intLoopCnt              As Integer

    On Error GoTo ONERR_STEP
            
    Snd_FileCopy = False
    
    For i = 1 To gvintOtFileCount
        '//�o�b�`�ō쐬����Ă���t�@�C�����𐶐�
        If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
            str_FromFileName _
                            = gvaryOtFileInfo(i).strFilePath _
                            & "\" _
                            & gvstrPLSqlWkFileName & gvaryOtFileInfo(i).strFileName1 _
                            & pstrNewTimeStamp _
                            & gvaryOtFileInfo(i).strFileExtn1
        Else
            str_FromFileName _
                            = gvaryOtFileInfo(i).strFilePath _
                            & "\" _
                            & gvstrPLSqlWkFileName & gvaryOtFileInfo(i).strFileName1 _
                            & gvaryOtFileInfo(i).strFileExtn1
        End If
    
        '//-------------- ���M        �t�H���_�̃t�@�C������ ---------------
        
        dtaNewTimeStamp = Format(pstrNewTimeStamp, "0000/00/00 00:00:00")
    
        '// �R�s�[����
        intLoopCnt = 0
        Do
            '//�����Ώۂ̃t�@�C�������݂��Ȃ��ꍇ�̓��[�v�𔲂���
            If Dir(str_FromFileName) = "" Then
                Exit Do
            End If
            
            '//���[�v�ُ�I��(99�񃋁[�v���Ă��ʖڂ�������I������)
' -- UPD -- 2009/01/28 START (1.11)
'            intLoopCnt = intLoopCnt + 1
'            If intLoopCnt > 99 Then
'                Call F_Edit_ErrLog(0, "�X�X�񃊃g���C���܂������A�t�@�C���R�s�[���ł��܂���ł����B", "Snd_FileCopy")
'                GoTo EXIT_STEP
'            End If
            If intLoopCnt > gvintRETRY_TIMESTAMP Then
                Call F_Edit_ErrLog(0, CStr(gvintRETRY_TIMESTAMP) & " �񃊃g���C���܂������A�t�@�C���R�s�[���ł��܂���ł����B�y���M�t�H���_�����z" & str_FromFileName, "Snd_FileCopy")
                GoTo EXIT_STEP
            End If
            intLoopCnt = intLoopCnt + 1
' -- UPD -- 2009/01/28 END   (1.11)
            
            '//���M�t�@�C���R�s�[
            If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
                
                '//�t�H���_�֒u���t�@�C�����̐���
                str_SendToFileName _
                                = gvaryOtFileInfo(i).strFilePath _
                                & "\" _
                                & gvaryOtFileInfo(i).strFileName1 _
                                & Format(dtaNewTimeStamp, "YYYYMMDDHHMMSS") _
                                & gvaryOtFileInfo(i).strFileExtn1
                
                '//�R�s�[����
                If CopyFile(str_FromFileName, str_SendToFileName, 1) <> 0 Then
                    '//�R�s�[������ɍs��ꂽ�i�R�s�[��̃t�@�C�������݂��Ă��Ȃ����[�h�j
                    Exit Do
                End If
            
            Else
                
                '//�t�H���_�֒u���t�@�C�����̐���
                str_SendToFileName _
                                = gvaryOtFileInfo(i).strFilePath _
                                & "\" _
                                & gvaryOtFileInfo(i).strFileName1 _
                                & gvaryOtFileInfo(i).strFileExtn1
                
' -- UPD -- 2009/10/15 START (1.20)
'                '//�R�s�[����
'                If CopyFile(str_FromFileName, str_SendToFileName, 1) <> 0 Then
'                    '//�R�s�[������ɍs��ꂽ�i�R�s�[��̃t�@�C�������݂��Ă��Ȃ����[�h�j
'                    Exit Do
'                End If
'                '//�R�s�[������ɍs���Ȃ������B
'                Call F_Edit_ErrLog(0, "���Ƀt�@�C�������݂��邽�߁A�t�@�C���R�s�[���ł��܂���ł����B", "Snd_FileCopy")
'                GoTo EXIT_STEP
                '//�R�s�[����
                If CopyFile(str_FromFileName, str_SendToFileName, 0) <> 0 Then
                    '//�R�s�[������ɍs��ꂽ�i����t�@�C��������Ƃ��㏑�����郂�[�h�j
                    Exit Do
                End If
                '//�R�s�[������ɍs���Ȃ������B
                Call F_Edit_ErrLog(0, "�t�@�C���R�s�[���ł��܂���ł����B", "Snd_FileCopy")
                GoTo EXIT_STEP
' -- UPD -- 2009/10/15 END   (1.20)
            
            End If
        
            '// �R�s�[������ɂł��Ȃ����߃^�C���X�^���v�ɂP���Z
            dtaNewTimeStamp = DateAdd("s", 1, dtaNewTimeStamp)
        Loop
    
        '//-------------- �o�b�N�A�b�v�t�H���_�̃t�@�C������ ---------------
        
        '// ���o�b�N�A�b�v�t�H���_�Ƀt�@�C�����R�s�[����ꍇ�́A
        '//   �^�C���X�^���v�t���敪�̗L���Ɋւ�炸�^�C���X�^���v������B
        
        '//�o�b�N�A�b�v
        If UCase(Right(gvaryOtFileInfo(i).strFilePath, 3)) <> "TMP" Then
        
            dtaNewTimeStamp = Format(pstrNewTimeStamp, "0000/00/00 00:00:00")
        
            '// �R�s�[����
            intLoopCnt = 0
            Do
                '//�����Ώۂ̃t�@�C�������݂��Ȃ��ꍇ�̓��[�v�𔲂���
                If Dir(str_FromFileName) = "" Then
                    Exit Do
                End If
                
                '//���[�v�ُ�I��(99�񃋁[�v���Ă��ʖڂ�������I������)
' -- UPD -- 2009/01/28 START (1.11)
'                intLoopCnt = intLoopCnt + 1
'                If intLoopCnt > 99 Then
'                    Call F_Edit_ErrLog(0, "�X�X�񃊃g���C���܂������A�t�@�C���R�s�[���ł��܂���ł����B", "Snd_FileCopy")
'                    GoTo EXIT_STEP
'                End If
                If intLoopCnt > gvintRETRY_TIMESTAMP Then
                    Call F_Edit_ErrLog(0, CStr(gvintRETRY_TIMESTAMP) & " �񃊃g���C���܂������A�t�@�C���R�s�[���ł��܂���ł����B�y���M�t�H���_�i�o�b�N�A�b�v�j�����z" & str_FromFileName, "Snd_FileCopy")
                    GoTo EXIT_STEP
                End If
                intLoopCnt = intLoopCnt + 1
' -- UPD -- 2009/01/28 END   (1.11)
                
                '//���M�t�@�C���R�s�[
                If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
                    
                    '//�t�H���_�֒u���t�@�C�����̐���
                    str_BackToFileName _
                                    = GetFullPath(gvcst_BakFilePath) _
                                    & "\DAT\SND\" _
                                    & gvaryOtFileInfo(i).strFileName1 _
                                    & Format(dtaNewTimeStamp, "YYYYMMDDHHMMSS") _
                                    & gvaryOtFileInfo(i).strFileExtn1
                Else
                    
                    '//�t�H���_�֒u���t�@�C�����̐���
                    str_BackToFileName _
                                    = GetFullPath(gvcst_BakFilePath) _
                                    & "\DAT\SND\" _
                                    & gvaryOtFileInfo(i).strFileName1 _
                                    & Format(dtaNewTimeStamp, "YYYYMMDDHHMMSS") _
                                    & gvaryOtFileInfo(i).strFileExtn1
                
                End If
            
                '//�o�b�N�A�b�v�t�H���_�̃t�@�C������
                If CopyFile(str_FromFileName, str_BackToFileName, 1) <> 0 Then
                    '//�R�s�[������ɍs��ꂽ�i�R�s�[��̃t�@�C�������݂��Ă��Ȃ����[�h�j
                    Exit Do
                End If
    
                '// �R�s�[������ɂł��Ȃ����߃^�C���X�^���v�ɂP���Z
                dtaNewTimeStamp = DateAdd("s", 1, dtaNewTimeStamp)
            Loop
    
        End If
        
        '//�o�b�`�ō쐬����Ă���t�@�C�����폜
        If Dir(str_FromFileName) <> "" Then
            Kill str_FromFileName
        End If
    
    Next i
    
    Snd_FileCopy = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP

End Function
' -- ADD -- 2008/05/15 END   (1.10)

'//*****************************************************************************************
'//*
'//* <��  ��>
'//*    Get_FileList
'//*
'//* <�߂�l>   �^                  ����
'//*            Boolean             True:OK , False:Error
'//*
'//* <��  ��>   ���ږ�              �^              I/O     ���e
'//*
'//* <��  ��>
'//*    �w�肳�ꂽ�t�H���_�[�̃t�@�C���ꗗ��Ԃ��i�w�肳�ꂽ�����Łj
'//*****************************************************************************************
Public Function Get_FileList(ByVal pmsGetFilePath As String, ByVal pmsGetFileName As String, _
                             ByRef pmvArray As Variant, ByRef pmiLoopMax As Integer) As Boolean

    Const PROCEDURE         As String = "Get_FileList"
    
    Dim i                   As Integer
    Dim strFileNmae         As String
    
    On Error GoTo ONERR_STEP
    
    Get_FileList = False

    i = 0
    ReDim pmvArray(i)

    strFileNmae = Dir(pmsGetFilePath & "\" & pmsGetFileName, vbNormal)      ' �ŏ��̃t�H���_����Ԃ��܂��B
    Do While strFileNmae <> ""                                              ' ���[�v���J�n���܂��B

        i = i + 1
        ReDim Preserve pmvArray(i)

        pmvArray(i) = strFileNmae                                           ' �t�@�C�����̊i�[

        strFileNmae = Dir                                                   ' ���̃t�@�C������Ԃ��܂��B
    Loop
    
    If pmiLoopMax <= i Then
        pmiLoopMax = i
    End If
        
' -- ADD -- 2008/05/14 START (1.10)
    Dim int_i       As Integer
    Dim int_j       As Integer
    Dim vnt_Work    As Variant

    For int_i = 1 To UBound(pmvArray)
        For int_j = int_i + 1 To UBound(pmvArray)
            If pmvArray(int_i) >= pmvArray(int_j) Then
                vnt_Work = pmvArray(int_i)
                pmvArray(int_i) = pmvArray(int_j)
                pmvArray(int_j) = vnt_Work
            End If
        Next int_j
    Next int_i
' -- ADD -- 2008/05/14 END   (1.10)

    Get_FileList = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP

End Function

'//*****************************************************************************************
'//*
'//* <��  ��>
'//*    RunStoredProcedure
'//*
'//* <�߂�l>   �^                  ����
'//*            Boolean             True:OK , False:Error
'//*
'//* <��  ��>   ���ږ�              �^              I/O     ���e
'//*
'//* <��  ��>
'//*    �X�g�A�h�����̎��s����
'//*****************************************************************************************
Public Function RunStoredProcedure(ByVal pmiIndex As Integer) As Boolean

    Const PROCEDURE         As String = "RunStoredProcedure"

    Dim i            As Integer
    Dim intRtnCd     As Integer     '�߂�l
    Dim strEXECUTE   As String

    RunStoredProcedure = False

    On Error GoTo ONERR_STEP

'// ��ݻ޸��ݐ���́A�I���N�����Ŏ��{����̂ŃR�����g�ɂ���
''''    '//��ݻ޸��ݐ���J�n
''''    clsOra.OraBeginTrans

    '//PL/SQL���Ăԁi�O�����j
    
    '// -- ���Ұ��̸ر --
    clsOra.OraDatabase.Parameters.Remove "RTNCD"
    clsOra.OraDatabase.Parameters.Remove "PARA_OPEID"
    clsOra.OraDatabase.Parameters.Remove "PARA_CLTID"
    For i = 1 To UBound(gvaryPARAMETER)
        clsOra.OraDatabase.Parameters.Remove "PARA_ADDPARA" & CStr(i)
    Next i
    For i = 1 To gvintInFileCount
        clsOra.OraDatabase.Parameters.Remove "PARA_INPATH" & CStr(i)
        clsOra.OraDatabase.Parameters.Remove "PARA_INFILE" & CStr(i)
    Next i
    For i = 1 To gvintOtFileCount
        clsOra.OraDatabase.Parameters.Remove "PARA_OTPATH" & CStr(i)
        clsOra.OraDatabase.Parameters.Remove "PARA_OTFILE" & CStr(i)
    Next i

    '// -- ���Ұ��̐ݒ� --
    
    '//���O�C�����[�U�[�h�c
    clsOra.OraDatabase.Parameters.Add "PARA_OPEID", gvstrOPEID, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters("PARA_OPEID").serverType = ORATYPE_CHAR

    '//�[���ԍ�
    clsOra.OraDatabase.Parameters.Add "PARA_CLTID", gvstrCLTID, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters("PARA_CLTID").serverType = ORATYPE_CHAR
        
    '//�ǉ��p�����[�^
    For i = 1 To UBound(gvaryPARAMETER)
        clsOra.OraDatabase.Parameters.Add "PARA_ADDPARA" & CStr(i), gvaryPARAMETER(i), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters("PARA_ADDPARA" & CStr(i)).serverType = ORATYPE_CHAR
    Next i
    
    '//IN �t�@�C���p�X�E�t�@�C����
    For i = 1 To gvintInFileCount
        clsOra.OraDatabase.Parameters.Add "PARA_INPATH" & CStr(i), D0.Chk_Null(gvaryInFileInfo(i).strFilePath), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters("PARA_INPATH" & CStr(i)).serverType = ORATYPE_VARCHAR2
        clsOra.OraDatabase.Parameters.Add "PARA_INFILE" & CStr(i), D0.Chk_Null(gvaryInGetFile(i).strFileName(pmiIndex)), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters("PARA_INFILE" & CStr(i)).serverType = ORATYPE_VARCHAR2
    Next i
    
    '//OUT�t�@�C���p�X�E�t�@�C����
    For i = 1 To gvintOtFileCount
        clsOra.OraDatabase.Parameters.Add "PARA_OTPATH" & CStr(i), D0.Chk_Null(gvaryOtFileInfo(i).strFilePath), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters("PARA_OTPATH" & CStr(i)).serverType = ORATYPE_VARCHAR2
' -- UPD -- 2008/05/15 START (1.10)
'        clsOra.OraDatabase.Parameters.Add "PARA_OTFILE" & CStr(i), "WK" & D0.Chk_Null(gvaryOtGetFile(i).strFileName(1)), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters.Add "PARA_OTFILE" & CStr(i), gvstrPLSqlWkFileName & D0.Chk_Null(gvaryOtGetFile(i).strFileName(1)), ORAPARM_INPUT
' -- UPD -- 2008/05/15 END   (1.10)
        clsOra.OraDatabase.Parameters("PARA_OTFILE" & CStr(i)).serverType = ORATYPE_VARCHAR2
    Next i
    
    '//�߂�l
    intRtnCd = 0
    clsOra.OraDatabase.Parameters.Add "RTNCD", intRtnCd, ORAPARM_OUTPUT
    clsOra.OraDatabase.Parameters("RTNCD").serverType = ORATYPE_NUMBER

    '//PL/SQL���ĂԁiMAIN�j
    strEXECUTE = ""
    strEXECUTE = strEXECUTE & "BEGIN"
    strEXECUTE = strEXECUTE & ":RTNCD := " & gvstrPLSQLPACKAGE & "." & gvstrPLSQLFUNCTION & "("
    strEXECUTE = strEXECUTE & " :PARA_OPEID"
    strEXECUTE = strEXECUTE & ",:PARA_CLTID"
    For i = 1 To UBound(gvaryPARAMETER)
        strEXECUTE = strEXECUTE & ",:PARA_ADDPARA" & CStr(i)
    Next i
    For i = 1 To gvintInFileCount
        strEXECUTE = strEXECUTE & ",:PARA_INPATH" & CStr(i)
        strEXECUTE = strEXECUTE & ",:PARA_INFILE" & CStr(i)
    Next i
    For i = 1 To gvintOtFileCount
        strEXECUTE = strEXECUTE & ",:PARA_OTPATH" & CStr(i)
        strEXECUTE = strEXECUTE & ",:PARA_OTFILE" & CStr(i)
    Next i
    strEXECUTE = strEXECUTE & ");"
    strEXECUTE = strEXECUTE & "END;"
        
    If Not clsOra.OraExecute(strEXECUTE, , PROCEDURE, gvcstDspMsg) Then
        '//���Ұ��̸ر
        clsOra.OraDatabase.Parameters.Remove "RTNCD"
        clsOra.OraDatabase.Parameters.Remove "PARA_OPEID"
        clsOra.OraDatabase.Parameters.Remove "PARA_CLTID"
        For i = 1 To gvintInFileCount
            clsOra.OraDatabase.Parameters.Remove "PARA_INPATH" & CStr(i)
            clsOra.OraDatabase.Parameters.Remove "PARA_INFILE" & CStr(i)
        Next i
        For i = 1 To gvintOtFileCount
            clsOra.OraDatabase.Parameters.Remove "PARA_OTPATH" & CStr(i)
            clsOra.OraDatabase.Parameters.Remove "PARA_OTFILE" & CStr(i)
        Next i
        GoTo EXIT_STEP
    End If
    
    '//�߂�l�m�F
    If clsOra.OraDatabase.Parameters("RTNCD").Value <> 0 Then
        '//(�ُ�)
        '//���Ұ��̸ر
        clsOra.OraDatabase.Parameters.Remove "RTNCD"
        clsOra.OraDatabase.Parameters.Remove "PARA_OPEID"
        clsOra.OraDatabase.Parameters.Remove "PARA_CLTID"
        For i = 1 To UBound(gvaryPARAMETER)
            clsOra.OraDatabase.Parameters.Remove "PARA_ADDPARA" & CStr(i)
        Next i
        For i = 1 To gvintInFileCount
            clsOra.OraDatabase.Parameters.Remove "PARA_INPATH" & CStr(i)
            clsOra.OraDatabase.Parameters.Remove "PARA_INFILE" & CStr(i)
        Next i
        For i = 1 To gvintOtFileCount
            clsOra.OraDatabase.Parameters.Remove "PARA_OTPATH" & CStr(i)
            clsOra.OraDatabase.Parameters.Remove "PARA_OTFILE" & CStr(i)
        Next i
'// ��ݻ޸��ݐ���́A�I���N�����Ŏ��{����̂ŃR�����g�ɂ���
''''        '//��ݻ޸���(۰��ޯ�)
''''        clsOra.OraRollback
        GoTo EXIT_STEP
    End If
    
    '//PL/SQL���Ăԁi�㏈���j
    '//���Ұ��̸ر
    clsOra.OraDatabase.Parameters.Remove "RTNCD"
    clsOra.OraDatabase.Parameters.Remove "PARA_OPEID"
    clsOra.OraDatabase.Parameters.Remove "PARA_CLTID"
    For i = 1 To UBound(gvaryPARAMETER)
        clsOra.OraDatabase.Parameters.Remove "PARA_ADDPARA" & CStr(i)
    Next i
    For i = 1 To gvintInFileCount
        clsOra.OraDatabase.Parameters.Remove "PARA_INPATH" & CStr(i)
        clsOra.OraDatabase.Parameters.Remove "PARA_INFILE" & CStr(i)
    Next i
    For i = 1 To gvintOtFileCount
        clsOra.OraDatabase.Parameters.Remove "PARA_OTPATH" & CStr(i)
        clsOra.OraDatabase.Parameters.Remove "PARA_OTFILE" & CStr(i)
    Next i

'// ��ݻ޸��ݐ���́A�I���N�����Ŏ��{����̂ŃR�����g�ɂ���
''''    '//��ݻ޸���(�Я�)
''''    clsOra.OraCommitTrans

    RunStoredProcedure = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP
    
End Function

' -- ADD -- 2006/12/15 START
'//*****************************************************************************************
'//*
'//* <��  ��>
'//*    AddTimeStampFileName
'//*
'//* <�߂�l>   �^                  ����
'//*            String              �^�C���X�^���v�t�����ꂽ�t�@�C����
'//*
'//* <��  ��>   ���ږ�              �^              I/O     ���e
'//*            strFilePathName     String          I       �t�@�C����
'//*
'//* <��  ��>
'//*    �t�@�C�����Ƀ^�C���X�^���v��t�������t�@�C������Ԃ�
'//*****************************************************************************************
Function AddTimeStampFileName(ByVal strFilePathName As String) As String

    Dim int_Idx                         As Integer
    Dim strFileName                     As String
    Dim strFileExtn                     As String
    
    '�t�@�C�����Ƀ^�C���X�^���v��t������ׂ̔��f������
    Const intLength As Integer = 19
    
    If Len(strFilePathName) <= intLength Then
        '�t�@�C�������ݒ蕶���ȉ��Ȃ̂Ń^�C���X�^���v��t������
        int_Idx = InStr(1, strFilePathName, ".")
        strFileName = Mid(strFilePathName, 1, int_Idx - 1) & clsOra.OraGetNowDt(1) & clsOra.OraGetNowTm
        strFileExtn = Mid(strFilePathName, int_Idx)
    
        '�t�@�C��������
        AddTimeStampFileName = strFileName & strFileExtn
    Else
        '�t�@�C�������ݒ蕶�����傫���̂Ń^�C���X�^���v��t������
        
        '�t�@�C��������
        AddTimeStampFileName = strFilePathName
    End If

End Function
' -- ADD -- 2006/12/15 END

' -- ADD -- 2007/02/08 START
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function ctr_HaitaOn
'   �T�v�F�@�r�����䏈��
'   �����F�@����
'   �ߒl�F�@True : ���� False : �ُ�
'   ���l�F  �r������n�m
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function Ctr_HaitaOn() As Boolean

    Dim strMsg          As String
    Dim IntCnt          As Integer
    
    Ctr_HaitaOn = False
    
    IntCnt = 0
    Do Until IntCnt > pv_curRETRY_TIMES
    
        IntCnt = IntCnt + 1
        
        '�r���`�F�b�N���s��
        Select Case CF_Chk_Lock_EXCTBZ(strMsg)
            '����
            Case 0
                Exit Do
                
            '�r��������
            Case 1
                If IntCnt > pv_curRETRY_TIMES Then
                    '�G���[���O�o��
                    Call F_Edit_ErrLog(0, Trim(strMsg) & "�����s���̂��ߏ����𒆎~���܂����B", "Ctr_HaitaOn")
                    Exit Function
                Else
                    Sleep (pv_curRETRY_INTERVAL)
                End If
                
            '�ُ�I��
            Case 9
                '�G���[���O�o��
                Call F_Edit_ErrLog(0, "�Ɩ��r�������ɂĂc�a�G���[���������܂����B", "Ctr_HaitaOn")
                Exit Function
                
        End Select
    Loop

    Ctr_HaitaOn = True
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function Ctr_HaitaOff
'   �T�v�F�@�r�����䏈��
'   �����F�@����
'   �ߒl�F�@True : ���� False : �ُ�
'   ���l�F  �r������n�e�e
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function Ctr_HaitaOff() As Boolean

    Dim strMsg          As String
    
    '�r����������
    Call CF_Unlock_EXCTBZ(strMsg)

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function CF_Chk_Lock_EXCTBZ
'   �T�v�F�@�r�����䏈��
'   �����F�@Pot_strMsg       : �G���[���e
'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
'   ���l�F  �r������i�r���`�F�b�N���r���e�[�u���ւ̏������݁j���s��
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_Lock_EXCTBZ(ByRef Pot_strMsg As String) As Integer
    
    Dim intRet          As Integer
    Dim strMsg          As String
    Dim bolTrn          As Boolean
    
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
    
    '//��ݻ޸��ݐ���J�n
    clsOra.OraBeginTrans
    bolTrn = True
    
    '�r������
    intRet = AE_Execute_PLSQL_EXCTBZ("W", strMsg)
    If intRet <> 0 Then
        '�r���G���[
        Pot_strMsg = strMsg
        CF_Chk_Lock_EXCTBZ = intRet
        GoTo CF_Chk_Lock_EXCTBZ_Err
    End If
    
    '//��ݻ޸���(�Я�)
    clsOra.OraCommitTrans
    bolTrn = False
    
    CF_Chk_Lock_EXCTBZ = 0
    
    Exit Function
    
CF_Chk_Lock_EXCTBZ_Err:

    '���[���o�b�N
    If bolTrn = True Then
        '//��ݻ޸���(۰��ޯ�)
        clsOra.OraRollback
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function CF_Unlock_EXCTBZ
'   �T�v�F�@�r�������������
'   �����F�@Pot_strMsg       : �G���[���e
'   �ߒl�F�@0 : ����  9 : �ُ�
'   ���l�F  �r������i�r���e�[�u������̍폜�j���s��
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Unlock_EXCTBZ(ByRef Pot_strMsg As String) As Integer
    
    Dim intRet          As Integer
    Dim strMsg          As String
    Dim bolTrn          As Boolean
    
On Error GoTo CF_Unlock_EXCTBZ_Err

    CF_Unlock_EXCTBZ = 9
    Pot_strMsg = ""
    bolTrn = False
    
    '//��ݻ޸��ݐ���J�n
    clsOra.OraBeginTrans
    bolTrn = True
    
    '�r���������
    intRet = AE_Execute_PLSQL_EXCTBZ("D", strMsg)
    If intRet <> 0 Then
        '�r���G���[
        Pot_strMsg = strMsg
        CF_Unlock_EXCTBZ = intRet
        GoTo CF_Unlock_EXCTBZ_Err
    End If
    
    '//��ݻ޸���(�Я�)
    clsOra.OraCommitTrans
    bolTrn = False
    
    CF_Unlock_EXCTBZ = 0
    
    Exit Function
    
CF_Unlock_EXCTBZ_Err:

    '���[���o�b�N
    If bolTrn = True Then
        '//��ݻ޸���(۰��ޯ�)
        clsOra.OraRollback
    End If
    
End Function
' === 20061105 === INSERT E -

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function AE_Execute_PLSQL_EXCTBZ
'   �T�v�F  PL/SQL���s����(�r�����䏈��)
'   �����F�@Pin_strPRCCASE   : �����P�[�X(C:�`�F�b�N W:�������� D:�폜����)
'           Pot_strMsg       : �G���[���e
'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
'   ���l�F  �r������pPL/SQL(PRC_EXCTBZ)�����s����
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, _
                                        ByRef Pot_strMsg As String) As Integer

    Dim strSQL      As String           'SQL��
    Dim strPara1    As String           '���Ұ�1(�S���҃R�[�h)
    Dim strPara2    As String           '���Ұ�2(�N���C�A���gID)
    Dim strPara3    As String           '���Ұ�3(�����P�[�X)
    Dim strPara4    As String           '���Ұ�4(�Ɩ��R�[�h(PGID))
    Dim lngPara5    As Long             '���Ұ�5(���A����)
    Dim lngPara6    As Long             '���Ұ�6(�װ����)
    Dim strPara7    As String           '���Ұ�7(�װ���e)
    Dim param(7)    As OraParameter     'PL/SQL�̃o�C���h�ϐ�
    Dim bolRet      As Boolean
    
    AE_Execute_PLSQL_EXCTBZ = 9
    
    '��n���ϐ������ݒ�
'    strPara1 = Inp_Inf.InpTanCd
'    strPara2 = SSS_CLTID
'    strPara3 = Pin_strPRCCASE
'    strPara4 = SSS_PrgId
'    lngPara5 = 0
'    lngPara6 = 0
'    strPara7 = ""
    strPara1 = gvstrOPEID
    strPara2 = gvstrCLTID
    strPara3 = Pin_strPRCCASE
    strPara4 = gvstrJOBID
    lngPara5 = 0
    lngPara6 = 0
    strPara7 = ""
    
    Pot_strMsg = ""

    '�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
    clsOra.OraDatabase.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters.Add "P5", lngPara5, ORAPARM_OUTPUT
    clsOra.OraDatabase.Parameters.Add "P6", lngPara6, ORAPARM_OUTPUT
    clsOra.OraDatabase.Parameters.Add "P7", strPara7, ORAPARM_OUTPUT

    '�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
    Set param(1) = clsOra.OraDatabase.Parameters("P1")
    Set param(2) = clsOra.OraDatabase.Parameters("P2")
    Set param(3) = clsOra.OraDatabase.Parameters("P3")
    Set param(4) = clsOra.OraDatabase.Parameters("P4")
    Set param(5) = clsOra.OraDatabase.Parameters("P5")
    Set param(6) = clsOra.OraDatabase.Parameters("P6")
    Set param(7) = clsOra.OraDatabase.Parameters("P7")

    '�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
    param(1).serverType = ORATYPE_CHAR
    param(2).serverType = ORATYPE_CHAR
    param(3).serverType = ORATYPE_CHAR
    param(4).serverType = ORATYPE_CHAR
    param(5).serverType = ORATYPE_NUMBER
    param(6).serverType = ORATYPE_NUMBER
    param(7).serverType = ORATYPE_VARCHAR2

    'PL/SQL�Ăяo��SQL
    strSQL = "BEGIN PRC_EXCTBZ(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"
    
    'DB�A�N�Z�X
    If Not clsOra.OraExecute(strSQL, , "AE_Execute_PLSQL_EXCTBZ", gvcstDspMsg) Then
        GoTo AE_Execute_PLSQL_EXCTBZ_END
    End If

    '** �߂�l�擾
    lngPara5 = param(5).Value
    lngPara6 = param(6).Value
    If IsNull(param(7).Value) = False Then
        strPara7 = param(7).Value
        Pot_strMsg = strPara7
    End If

    '�G���[���ݒ�
    gv_Int_OraErr = lngPara6
    gv_Str_OraErrText = strPara7
    
    AE_Execute_PLSQL_EXCTBZ = lngPara5
    
AE_Execute_PLSQL_EXCTBZ_END:
    '** �p�����^����
    clsOra.OraDatabase.Parameters.Remove "P1"
    clsOra.OraDatabase.Parameters.Remove "P2"
    clsOra.OraDatabase.Parameters.Remove "P3"
    clsOra.OraDatabase.Parameters.Remove "P4"
    clsOra.OraDatabase.Parameters.Remove "P5"
    clsOra.OraDatabase.Parameters.Remove "P6"
    clsOra.OraDatabase.Parameters.Remove "P7"
    
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
    strDate = clsOra.OraGetNowDt(1)
    strTime = clsOra.OraGetNowTm()
    
    '�G���[���O��������
    Call CF_Edit_ErrLog(pv_strLOG_PATH _
                      , pv_strLOG_NAME _
                      , gvstrJOBID _
                      , pin_intErrCd _
                      , pin_strErrMsg _
                      , pin_strErrLocation _
                      , strTime _
                      , strDate)
    
    F_Edit_ErrLog = 0

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
Public Function CF_Edit_ErrLog(ByVal pin_strLOG_PATH As String _
                             , ByVal pin_strLOG_NAME As String _
                             , ByVal pin_strPrgId As String _
                             , ByVal pin_intErrCd As Integer _
                             , ByVal pin_strErrMsg As String _
                             , ByVal pin_strErrLocation As String _
                             , ByVal pin_strTime As String _
                             , ByVal pin_strDate As String) As Integer

    Dim intFNo          As Integer
    Dim strCSV          As String
    Dim bolOpen         As Boolean
    
On Error GoTo CF_Edit_ErrLog_End

    CF_Edit_ErrLog = 9
    bolOpen = False
    
    intFNo = FreeFile

    If Right$(Trim(pin_strLOG_PATH), 1) <> "\" Then
        pin_strLOG_PATH = Trim(pin_strLOG_PATH) & "\"
    End If
    
    '�t�@�C���I�[�v��
    Open Trim(pin_strLOG_PATH) & Trim(pin_strLOG_NAME) For Append As intFNo
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
    
    Print #intFNo, strCSV
    
    CF_Edit_ErrLog = 0

CF_Edit_ErrLog_End:

    If bolOpen = True Then
        '�N���[�Y
        Close intFNo
    End If

End Function

' -- ADD -- 2007/02/08 END


