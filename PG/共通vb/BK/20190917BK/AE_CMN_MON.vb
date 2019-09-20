Option Strict Off
Option Explicit On

'2019/04/26 ADD START
Imports Oracle.DataAccess.Client
'2019/04/26 ADD E N D

Module AE_CMN_MON
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function funcMNTPR_WK_INS
	'   �T�v�F ���[�p���[�N�̍쐬
	'   �����F strLIST_ID      �o�͒��[�h�c
	'          strPRT_SEQ      ���[�V�[�P���X
	'   �ߒl�F TRUE : ���� FALSE : �ُ�
	'   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '    Public Function funcMNTPR_WK_INS(ByVal strLIST_ID As String, ByRef strPRT_SEQ As String) As Boolean

    '        Dim bolRet As Boolean
    '        Dim bolTrans As Boolean
    '        Dim strSQL As String

    '        On Error GoTo Err_Run

    '        funcMNTPR_WK_INS = False

    '        'USR1�Ńg�����U�N�V�����J�n
    '        Call CF_Ora_BeginTrans(gv_Oss_USR1)
    '        bolTrans = True

    '        'SEQ�̎擾
    '        strPRT_SEQ = GetPrtSeq()
    '        If strPRT_SEQ = "" Then
    '            GoTo Err_Run
    '        End If

    '        '���[�p���[�N�쐬�����̌Ăяo���iPLSQL�j
    '        strSQL = "DECLARE "
    '        strSQL = strSQL & "BEGIN "
    '        strSQL = strSQL & Get_DBHEAD() & "_" & ORA_MAX_USR1 & "." & strLIST_ID & "_PACK." & strLIST_ID & "BAT"
    '        strSQL = strSQL & "( "
    '        strSQL = strSQL & " '" & SSS_OPEID.Value & "'" '�o�͒S����
    '        strSQL = strSQL & ", " & strPRT_SEQ '���[�V�[�P���X
    '        strSQL = strSQL & "); "
    '        strSQL = strSQL & "END;"

    '        'SQL���s
    '        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    '        If Not bolRet Then
    '            GoTo Err_Run
    '        End If

    '        '�R�~�b�g
    '        bolRet = CF_Ora_CommitTrans(gv_Oss_USR1)
    '        If Not bolRet Then
    '            GoTo Err_Run
    '        End If
    '        bolTrans = False

    '        funcMNTPR_WK_INS = True

    'Exit_Run:

    '        Exit Function

    'Err_Run:

    '        If bolTrans = True Then
    '            '���[���o�b�N
    '            Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    '        End If

    '        GoTo Exit_Run

    '    End Function
    Public Function funcMNTPR_WK_INS(ByVal strLIST_ID As String, ByRef strPRT_SEQ As String) As Boolean

        '�߂�l
        Dim rtnVal As Boolean = False

        'SQL��
        Dim strSQL As String = Nothing

        'OracleCommand
        Dim cmd As New OracleCommand

        Try
            '//�g�����U�N�V�����J�n
            Call DB_BeginTrans(CON)

            'SEQ�̎擾
            strPRT_SEQ = GetPrtSeq()
            If strPRT_SEQ = "" Then
                Return rtnVal
            End If

            cmd.Connection = CON
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = strLIST_ID & "_PACK." & strLIST_ID & "BAT"

            '//�p�����[�^�ݒ�
            Dim inPARA_USR As OracleParameter = New OracleParameter '�o�͒S����
            inPARA_USR.ParameterName = "PARA_USR"
            inPARA_USR.Direction = ParameterDirection.Input
            inPARA_USR.OracleDbType = OracleDbType.Char
            inPARA_USR.Value = SSS_OPEID.Value
            cmd.Parameters.Add(inPARA_USR)

            Dim inPARA_SEQ As OracleParameter = New OracleParameter '���[�V�[�P���X
            inPARA_SEQ.ParameterName = "PARA_SEQ"
            inPARA_SEQ.Direction = ParameterDirection.Input
            inPARA_SEQ.OracleDbType = OracleDbType.Decimal
            inPARA_SEQ.Value = strPRT_SEQ
            cmd.Parameters.Add(inPARA_SEQ)

            '//���s
            cmd.ExecuteNonQuery()

            '//�R�~�b�g
            Call DB_Commit()

            rtnVal = True

        Catch ex As Exception

            Call DB_Rollback()
            Throw ex

            'Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function funcMNTPR_WK_DEL
	'   �T�v�F ���[�p���[�N�̍폜
	'   �����F strLIST_ID      �o�͒��[�h�c
	'          strPRT_SEQ      ���[�V�[�P���X
	'   �ߒl�F TRUE : ���� FALSE : �ُ�
	'   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '	Public Function funcMNTPR_WK_DEL(ByVal strLIST_ID As String, ByVal strPRT_SEQ As String) As Boolean

    '		Dim bolRet As Boolean
    '		Dim bolTrans As Boolean
    '		Dim strSQL As String

    '		On Error GoTo Err_Run

    '		funcMNTPR_WK_DEL = False

    '		'USR9�Ńg�����U�N�V�����J�n
    '		Call CF_Ora_BeginTrans(gv_Oss_USR9)
    '		bolTrans = True

    '		'SQL����
    '		strSQL = ""
    '		strSQL = strSQL & " DELETE " & vbCrLf
    '		strSQL = strSQL & " FROM " & strLIST_ID & vbCrLf
    '		strSQL = strSQL & " WHERE " & vbCrLf
    '		strSQL = strSQL & "     PRTTANID = '" & SSS_OPEID.Value & "' " & vbCrLf
    '		strSQL = strSQL & " AND PRTSEQ = '" & strPRT_SEQ & "' "

    '		'SQL���s
    '		bolRet = CF_Ora_Execute(gv_Odb_USR9, strSQL)
    '		If bolRet = False Then
    '			GoTo Err_Run
    '		End If

    '		'�R�~�b�g
    '		bolRet = CF_Ora_CommitTrans(gv_Oss_USR9)
    '		If Not bolRet Then
    '			GoTo Err_Run
    '		End If
    '		bolTrans = False

    '		funcMNTPR_WK_DEL = True

    'Exit_Run: 

    '		Exit Function

    'Err_Run: 

    '		If bolTrans = True Then
    '			'���[���o�b�N
    '			Call CF_Ora_RollbackTrans(gv_Oss_USR9)
    '		End If

    '		GoTo Exit_Run

    '    End Function
    Public Function funcMNTPR_WK_DEL(ByVal strLIST_ID As String, ByVal strPRT_SEQ As String) As Boolean

        '�߂�l
        Dim rtnVal As Boolean = False

        'SQL��
        Dim strSQL As String = Nothing

        Try
            '//�g�����U�N�V�����J�n
            Call DB_BeginTrans(CON)


            '//SQL
            strSQL = ""
            strSQL &= vbCrLf & " DELETE "
            strSQL &= vbCrLf & " FROM CNT_USR9." & strLIST_ID
            strSQL &= vbCrLf & " WHERE PRTTANID = '" & SSS_OPEID.Value & "' "
            strSQL &= vbCrLf & " AND   PRTSEQ = '" & strPRT_SEQ & "' "

            '//���s
            Call DB_Execute(strSQL)

            '//�R�~�b�g
            Call DB_Commit()

            rtnVal = True

        Catch ex As Exception

            Call DB_Rollback()
            Throw ex

            'Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F Sub GetPrtSeq
    '   �T�v�F ���[�p�V�[�P���X�擾����
    '   �����F �Ȃ�
    '   �ߒl�F �擾�����V�[�P���X�@�ُ�I���̏ꍇ�͋󕶎���Ԃ�
    '   ���l�F USR9�ւ̐ڑ��͌Ăяo�����ōs������
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '    Public Function GetPrtSeq() As String

    '        Dim strSQL As String
    '        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '        Dim Usr_Ody As U_Ody
    '        Dim strSeq As String

    '        GetPrtSeq = ""

    '        'SQL���̍쐬
    '        strSQL = ""
    '        strSQL = strSQL & " SELECT PRTSEQ.NEXTVAL PRTSEQ " & vbCrLf
    '        strSQL = strSQL & " FROM DUAL "

    '        'DB�A�N�Z�X
    '        If CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody, strSQL) = False Then
    '            GoTo Err_Run
    '        End If

    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        strSeq = CStr(CF_Ora_GetDyn(Usr_Ody, "PRTSEQ", 0))

    '        GetPrtSeq = strSeq

    'Exit_Run:

    '        '�N���[�Y
    '        Call CF_Ora_CloseDyn(Usr_Ody)

    '        Exit Function

    'Err_Run:

    '        GoTo Exit_Run

    '    End Function
    Public Function GetPrtSeq() As String

        '�߂�l
        Dim rtnVal As String = ""

        'SQL��
        Dim strSQL As String = Nothing

        Try
            '//SQL
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "  CNT_USR9.PRTSEQ.NEXTVAL PRTSEQ "
            strSQL &= vbCrLf & " FROM DUAL "

            '//���s
            Dim dt As DataTable = DB_GetTable(strSQL)

            rtnVal = CStr(DB_NullReplace(dt.Rows(0)("PRTSEQ"), 0))

        Catch ex As Exception

            Throw ex

            'Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function funcGetColComment
	'   �T�v�F �R�����g�擾SQL�쐬
	'   �����F strTBL_NAME    : �e�[�u����
	'          strCOL_NAME    : ��
	'   �ߒl�F �R�����g�擾SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function funcGetColComment(ByVal strTBL_NAME As String, ByVal strCOL_NAME As String) As String
		
		Dim strSQL As String
		
		strSQL = ""
		strSQL = strSQL & "SELECT COMMENTS "
		strSQL = strSQL & "FROM USER_COL_COMMENTS "
		strSQL = strSQL & "WHERE TABLE_NAME = '" & strTBL_NAME & "' "
		strSQL = strSQL & "AND COLUMN_NAME = '" & strCOL_NAME & "'"
		
		funcGetColComment = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function funcGetOutName
	'   �T�v�F �t�@�C�����쐬����
	'   �����F strOUT_PATH    : �t�@�C���p�X
	'          strOUT_NAME    : �ϊ��O�t�@�C����
	'          strOUT_TYPE    : �g���q
	'          strCNT_FORM    : �J�E���g�̃t�H�[�}�b�g
	'          strFILEPATH    : �ϊ���t�@�C����(�g���q�t)
	'   �ߒl�F TRUE : ���� FALSE : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '    Public Function funcGetOutName(ByVal strOUT_PATH As String, ByVal strOUT_NAME As String, ByVal strOUT_TYPE As String, ByVal strCNT_FORM As String, ByRef strFILEPATH As String) As Boolean

    '        Dim cnt As Short
    '        Dim cntMax As Short
    '        Dim strPath As String
    '        Dim strDir As String
    '        Dim strGETUDO As String
    '        Dim strCnt As String
    '        Dim strSQL As String
    '        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '        Dim Usr_Ody As U_Ody

    '        On Error GoTo Err_Run

    '        funcGetOutName = False
    '        strPath = strOUT_NAME
    '        cnt = 0
    '        cntMax = 0
    '        strGETUDO = ""
    '        strCnt = ""

    '        '�����������i����j��茎�x���擾
    '        'SQL���̍쐬
    '        strSQL = ""
    '        strSQL = strSQL & "SELECT GET_GETUDO(" & vbCrLf
    '        strSQL = strSQL & "         (SELECT UKSMEDT     FROM SYSTBA)," & vbCrLf
    '        strSQL = strSQL & "         (SELECT SMEDD       FROM SYSTBA)" & vbCrLf
    '        strSQL = strSQL & "     ) GETUDO" & vbCrLf
    '        strSQL = strSQL & " FROM DUAL"

    '        'DB�A�N�Z�X
    '        If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL) = False Then
    '            GoTo Err_Run
    '        End If

    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        strGETUDO = CStr(CF_Ora_GetDyn(Usr_Ody, "GETUDO", 0))
    '        strGETUDO = Mid(strGETUDO, 1, 4) & "�N" & Mid(strGETUDO, 5, 2) & "���x"

    '        strPath = strPath & "_" & strGETUDO

    '        '�t�@�C���̃J�E���g�擾
    '        If Right(Trim(strOUT_PATH), 1) <> "\" Then
    '            strOUT_PATH = Trim(strOUT_PATH) & "\"
    '        End If

    '        'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
    '        strDir = Dir(strOUT_PATH & strPath & "*" & strOUT_TYPE)
    '        Do While (strDir <> "")
    '            strDir = Replace(strDir, strPath & "_", "")
    '            strDir = Replace(strDir, strOUT_TYPE, "")
    '            If IsNumeric(strDir) Then
    '                cnt = CShort(strDir)
    '            Else
    '                cnt = 0
    '            End If

    '            If cnt > cntMax Then
    '                cntMax = cnt
    '            End If
    '            'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
    '            strDir = Dir()
    '        Loop

    '        strCnt = VB6.Format(cntMax + 1, strCNT_FORM)

    '        strFILEPATH = strPath & "_" & strCnt & strOUT_TYPE

    '        funcGetOutName = True

    'Exit_Run:

    '        '�N���[�Y
    '        Call CF_Ora_CloseDyn(Usr_Ody)

    '        Exit Function

    'Err_Run:

    '        GoTo Exit_Run

    '    End Function
    Public Function funcGetOutName(ByVal strOUT_PATH As String, ByVal strOUT_NAME As String, ByVal strOUT_TYPE As String, ByVal strCNT_FORM As String, ByRef strFILEPATH As String) As Boolean

        '�߂�l
        Dim rtnVal As Boolean = False

        'SQL��
        Dim strSQL As String = Nothing

        Try
            Dim cnt As Short
            Dim cntMax As Short
            Dim strPath As String
            Dim strDir As String
            Dim strGETUDO As String
            strPath = strOUT_NAME
            cnt = 0
            cntMax = 0
            strGETUDO = ""

            '//SQL
            strSQL = ""
            strSQL &= vbCrLf & " SELECT GET_GETUDO((SELECT UKSMEDT FROM SYSTBA),(SELECT SMEDD FROM SYSTBA)) GETUDO"
            strSQL &= vbCrLf & " FROM DUAL "

            '//���s
            Dim dt As DataTable = DB_GetTable(strSQL)

            strGETUDO = CStr(DB_NullReplace(dt.Rows(0)("GETUDO"), 0))
            strGETUDO = Mid(strGETUDO, 1, 4) & "�N" & Mid(strGETUDO, 5, 2) & "���x"

            strPath = strPath & "_" & strGETUDO

            '�t�@�C���̃J�E���g�擾
            If Right(Trim(strOUT_PATH), 1) <> "\" Then
                strOUT_PATH = Trim(strOUT_PATH) & "\"
            End If

            strDir = Dir(strOUT_PATH & strPath & "*" & strOUT_TYPE)
            Do While (strDir <> "")
                strDir = Replace(strDir, strPath & "_", "")
                strDir = Replace(strDir, strOUT_TYPE, "")
                If IsNumeric(strDir) Then
                    cnt = CShort(strDir)
                Else
                    cnt = 0
                End If

                If cnt > cntMax Then
                    cntMax = cnt
                End If

                strDir = Dir()
            Loop

            strFILEPATH = strPath & "_" & VB6.Format(cntMax + 1, strCNT_FORM) & strOUT_TYPE

            rtnVal = True

        Catch ex As Exception

            Throw ex

        Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function funcOutput
	'   �T�v�F �t�@�C���o�͏���
	'   �����F pin_strOUT_PATH    : �o�̓t�@�C���p�X
	'          pin_strOUT_NAME    : �o�̓t�@�C����
	'   �ߒl�F 0 : ���� 9 : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function funcOutput(ByVal pin_strOUT_PATH As String, ByVal pin_strOUT_NAME As String, ByVal pin_strOUT_TXT As Object) As Short
		
		Dim intFNo As Short
		Dim strOUT As String
		Dim bolOpen As Boolean
		
		On Error GoTo Err_Run
		
		funcOutput = 9
		bolOpen = False
		
		intFNo = FreeFile
		
		If Right(Trim(pin_strOUT_PATH), 1) <> "\" Then
			pin_strOUT_PATH = Trim(pin_strOUT_PATH) & "\"
		End If
		
		'�t�@�C���I�[�v��
		FileOpen(intFNo, Trim(pin_strOUT_PATH) & Trim(pin_strOUT_NAME), OpenMode.Append)
		bolOpen = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pin_strOUT_TXT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strOUT = pin_strOUT_TXT
		
		PrintLine(intFNo, strOUT)
		
		funcOutput = 0
		
Exit_Run: 
		
		If bolOpen = True Then
			'�N���[�Y
			FileClose(intFNo)
		End If
		
		Exit Function
		
Err_Run: 
		
		'''' ADD 2009/10/27  FKS) T.Yamamoto    Start    �A���[��FC09102703
		gv_Int_OraErr = CShort("0")
		gv_Str_OraErrText = Trim(pin_strOUT_PATH) & Trim(pin_strOUT_NAME) & "�ւ̏������݂Ɏ��s���܂����B"
		'''' ADD 2009/10/27  FKS) T.Yamamoto    End
		GoTo Exit_Run
		
	End Function
	
	'''' ADD 2009/06/17  FKS) T.Yamamoto    Start
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function funcGetMNTPR_PARA
	'   �T�v�F �p�����[�^�g�p�t���O�ƑΏی��x���擾
	'   �����F strLIST_ID        : �o�͒��[�h�c
	'          strCOL_GETUDO     : �Ώی��x���i�[����Ă����
	'          strPARAFLG        : �p�����[�^�g�p�t���O
	'          strGETUDO         : �Ώی��x
	'   �ߒl�F TRUE : ���� FALSE : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '    Public Function funcGetMNTPR_PARA(ByVal strLIST_ID As String, ByVal strCOL_GETUDO As String, ByRef strPARAFLG As String, ByRef strGETUDO As String) As Boolean

    '        Dim strSQL As String
    '        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '        Dim Usr_Ody As U_Ody

    '        On Error GoTo Err_Run

    '        funcGetMNTPR_PARA = False

    '        'SQL���̍쐬
    '        strSQL = ""
    '        strSQL = strSQL & "SELECT PARAFLG," & vbCrLf
    '        strSQL = strSQL & "       (" & vbCrLf
    '        strSQL = strSQL & "           CASE WHEN LENGTHB(RTRIM(" & strCOL_GETUDO & ")) = 6 THEN" & vbCrLf
    '        strSQL = strSQL & "               RTRIM(" & strCOL_GETUDO & ")" & vbCrLf
    '        strSQL = strSQL & "           ELSE" & vbCrLf
    '        strSQL = strSQL & "               GET_GETUDO(" & strCOL_GETUDO & ", (SELECT SMEDD FROM SYSTBA))" & vbCrLf
    '        strSQL = strSQL & "           END" & vbCrLf
    '        strSQL = strSQL & "       ) GETUDO" & vbCrLf
    '        strSQL = strSQL & " FROM  MNTPR_PARA"
    '        strSQL = strSQL & " WHERE LISTID = '" & strLIST_ID & "'"

    '        'DB�A�N�Z�X
    '        If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL) = False Then
    '            GoTo Err_Run
    '        End If

    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        strPARAFLG = CStr(CF_Ora_GetDyn(Usr_Ody, "PARAFLG", 0))
    '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        strGETUDO = CStr(CF_Ora_GetDyn(Usr_Ody, "GETUDO", 0))
    '        strGETUDO = Mid(strGETUDO, 1, 4) & "�N" & Mid(strGETUDO, 5, 2) & "���x"


    '        funcGetMNTPR_PARA = True

    'Exit_Run:

    '        '�N���[�Y
    '        Call CF_Ora_CloseDyn(Usr_Ody)

    '        Exit Function

    'Err_Run:

    '        GoTo Exit_Run

    '    End Function
    Public Function funcGetMNTPR_PARA(ByVal strLIST_ID As String, ByVal strCOL_GETUDO As String, ByRef strPARAFLG As String, ByRef strGETUDO As String) As Boolean

        '�߂�l
        Dim rtnVal As Boolean = False

        'SQL��
        Dim strSQL As String = Nothing

        Try
            '//SQL
            strSQL = ""
            strSQL = strSQL & "SELECT PARAFLG," & vbCrLf
            strSQL = strSQL & "       (" & vbCrLf
            strSQL = strSQL & "           CASE WHEN LENGTHB(RTRIM(" & strCOL_GETUDO & ")) = 6 THEN" & vbCrLf
            strSQL = strSQL & "               RTRIM(" & strCOL_GETUDO & ")" & vbCrLf
            strSQL = strSQL & "           ELSE" & vbCrLf
            strSQL = strSQL & "               GET_GETUDO(" & strCOL_GETUDO & ", (SELECT SMEDD FROM SYSTBA))" & vbCrLf
            strSQL = strSQL & "           END" & vbCrLf
            strSQL = strSQL & "       ) GETUDO" & vbCrLf
            strSQL = strSQL & " FROM  MNTPR_PARA"
            strSQL = strSQL & " WHERE LISTID = '" & strLIST_ID & "'"

            '//���s
            Dim dt As DataTable = DB_GetTable(strSQL)

            strPARAFLG = CStr(DB_NullReplace(dt.Rows(0)("PARAFLG"), 0))
            strGETUDO = CStr(DB_NullReplace(dt.Rows(0)("GETUDO"), 0))
            strGETUDO = Mid(strGETUDO, 1, 4) & "�N" & Mid(strGETUDO, 5, 2) & "���x"

            rtnVal = True

        Catch ex As Exception
            Throw ex

            'Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F Function funcGetOutName2
	'   �T�v�F �t�@�C�����쐬����
	'   �����F strOUT_PATH    : �t�@�C���p�X
	'          strOUT_NAME    : �ϊ��O�t�@�C����
	'          strGETUDO      : �Ώی��x
	'          strOUT_TYPE    : �g���q
	'          strCNT_FORM    : �J�E���g�̃t�H�[�}�b�g
	'   �ߒl�F �ϊ���t�@�C����(�g���q�t)
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function funcGetOutName2(ByVal strOUT_PATH As String, ByVal strOUT_NAME As String, ByVal strGETUDO As String, ByVal strOUT_TYPE As String, ByVal strCNT_FORM As String) As Object
		
		Dim cnt As Short
		Dim cntMax As Short
		Dim strDir As String
		Dim strCnt As String
		Dim strSQL As String
        '2019/04/26 DEL START
        ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        'Dim Usr_Ody As U_Ody
        '2019/04/26 DEL E N D

		On Error GoTo Err_Run
		
		'UPGRADE_WARNING: �I�u�W�F�N�g funcGetOutName2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		funcGetOutName2 = strOUT_NAME & "_" & strGETUDO
		cnt = 0
		cntMax = 0
		strGETUDO = ""
		strCnt = ""
		
		'�t�@�C���̃J�E���g�擾
		If Right(Trim(strOUT_PATH), 1) <> "\" Then
			strOUT_PATH = Trim(strOUT_PATH) & "\"
		End If
		
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		strDir = Dir(strOUT_PATH & funcGetOutName2 & "*" & strOUT_TYPE)
		Do While (strDir <> "")
			strDir = Replace(strDir, funcGetOutName2 & "_", "")
			strDir = Replace(strDir, strOUT_TYPE, "")
			If IsNumeric(strDir) Then
				cnt = CShort(strDir)
			Else
				cnt = 0
			End If
			
			If cnt > cntMax Then
				cntMax = cnt
			End If
			'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			strDir = Dir()
		Loop 
		
		strCnt = VB6.Format(cntMax + 1, strCNT_FORM)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g funcGetOutName2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		funcGetOutName2 = funcGetOutName2 & "_" & strCnt
		
Exit_Run: 
		
		'UPGRADE_WARNING: �I�u�W�F�N�g funcGetOutName2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		funcGetOutName2 = funcGetOutName2 & strOUT_TYPE
		
        '2019/04/26 DEL START
        ''�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/26 DEL E N D

		Exit Function
		
Err_Run: 
		
		GoTo Exit_Run
		
	End Function
	'''' ADD 2009/06/17  FKS) T.Yamamoto    End
End Module