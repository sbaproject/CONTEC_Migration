Option Strict Off
Option Explicit On

Module HKKET143M

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

    Public gvintIndex As Short
    Public Const gvstrClass As String = "056" '//���
    Public Const gvstrOrder_Rcv As String = "1" '//��
    Public Const gvstrOrder As String = "2" '//����
    Public Const gvstrEstimate As String = "3" '//����
    Public Const gvstrIssue As String = "4" '//�Č�
    Public Const gvstrProvision As String = "5" '//�x��
    Public Const gvstrOrderRcvEstimate As String = "6" '//����(��)
    Public Const gvstrSeiban As String = "7" '//���ԏo��

    '2019/04/16 ADD START
    'SortOrder
    Private LvSortOrder As SortOrder
    '2019/04/16 ADD E N D

    '2019/04/24 ADD START
    Private InitSortColumn As Integer
    '2019/04/24 ADD E N D

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Set_Initialize
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�                  I/O           ���e
    '//*
    '//* <��  ��>
    '//*    ��������
    '//*****************************************************************************************
    Function Set_Initialize() As Boolean
        '2019/04/11 DEL START
        'Dim SetLvFormat As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Set_Initialize"

        Set_Initialize = False

        On Error GoTo ONERR_STEP

        '// �e�n�q�l�L���v�V�����Z�b�g
        'HKKET143F.Caption = gvcstJOB_Titl

        '//�e�n�q�l�����Z�b�g
        Call SetFormInitOrg(HKKET143F, 1)

        '//�\�����Ǘ��擾
        '2019/04/16 CHG START
        'Call SetLvFormat("E03", HKKET143F.lvwMEISAI)
        Call SetLvFormat("E03", HKKET143F.lvwMEISAI, LvSortOrder, InitSortColumn)
        '2019/04/16 CHG E N D

        '// ��ʃN���A�[
        Call HKKET143M.Clr_Display()

        '//��ʕ\���ɕK�v�ȃf�[�^���擾���\������
        If Not HKKET143M.Get_DisplayData Then
            GoTo EXIT_STEP
        End If

        Set_Initialize = True

        '--------------------------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '--------------------------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Clr_Display
    '//*
    '//* <�߂�l>   �^                  ����
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    ��ʃN���A����
    '//*****************************************************************************************
    Sub Clr_Display()

        Const PROCEDURE As String = "Clr_Display"


        On Error GoTo ONERR_STEP

        With HKKET143F
            .txtTERM.Text = vbNullString
            .txtYEAR.Text = vbNullString
            .txtMONTH.Text = vbNullString
            .txtHINCD.Text = vbNullString
            .txtHINNMA.Text = vbNullString
            .txtHINNMB.Text = vbNullString
            .txtZAIRNK.Text = vbNullString
            'UPGRADE_WARNING: �I�u�W�F�N�g HKKET143F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            '.lvwMEISAI.ListItems.Clear()
            .lvwMEISAI.Items.Clear()
            '2019/04/11 CHG E N D

            '2019/04/16 ADD START
            .LvSorter143F.Order = SortOrder.None
            '2019/04/16 ADD E N D

            .txtINQTY.Text = vbNullString
            .txtOUTQTY.Text = vbNullString
            .txtSKYQTY.Text = vbNullString
            .txtISSUE.Text = vbNullString
            .txtESTIMATE.Text = vbNullString
            .txtMKOUTQTY.Text = vbNullString

        End With

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Get_DisplayData
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*
    '//*****************************************************************************************
    Public Function Get_DisplayData() As Boolean

        Const PROCEDURE As String = "Get_DisplayData"
        Dim vntArray As Object

        Get_DisplayData = False

        On Error GoTo ONERR_STEP

        With HKKET143F
            If HKKET142F.cmdMONTH(gvintIndex).Tag >= CDbl(Mid(gvstrUNYDT, 1, 4)) - 1 & "04" And HKKET142F.cmdMONTH(gvintIndex).Tag <= Mid(gvstrUNYDT, 1, 4) & "03" Then
                .txtTERM.Text = CStr(CDbl(gvstrTERMNO) - 1)
            End If
            If HKKET142F.cmdMONTH(gvintIndex).Tag >= Mid(gvstrUNYDT, 1, 4) & "04" And HKKET142F.cmdMONTH(gvintIndex).Tag <= CDbl(Mid(gvstrUNYDT, 1, 4)) + 1 & "03" Then
                .txtTERM.Text = gvstrTERMNO
            End If
            If HKKET142F.cmdMONTH(gvintIndex).Tag >= CDbl(Mid(gvstrUNYDT, 1, 4)) + 1 & "04" And HKKET142F.cmdMONTH(gvintIndex).Tag <= CDbl(Mid(gvstrUNYDT, 1, 4)) + 2 & "03" Then
                .txtTERM.Text = CStr(CDbl(gvstrTERMNO) + 1)
            End If

            .txtTODAY.Text = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")
            .txtYEAR.Text = Mid(HKKET142F.cmdMONTH(gvintIndex).Tag, 1, 4)
            .txtMONTH.Text = Mid(HKKET142F.cmdMONTH(gvintIndex).Tag, 5, 2)
            .txtHINCD.Text = HKKET142F.txtHINCD.Text
            .txtHINNMA.Text = HKKET142F.txtHINNMA.Text
            .txtHINNMB.Text = HKKET142F.txtHINNMB.Text
            .txtZAIRNK.Text = HKKET142F.txtZAIRNK.Text
            .txtTODAY.Text = HKKET142F.txtTODAY.Text
            .txtINQTY.Text = CStr(musrHKKZTRA.dblINPTRA(gvlngNowPage + gvintIndex))
            .txtOUTQTY.Text = CStr(musrHKKZTRA.dblOUTTRA(gvlngNowPage + gvintIndex))
            .txtSKYQTY.Text = CStr(musrHKKZTRA.dblSKYOUT(gvlngNowPage + gvintIndex))
            .txtISSUE.Text = CStr(musrMKMTRA.dblMKMAK(gvlngNowPage + gvintIndex))
            .txtESTIMATE.Text = CStr(musrMKMTRA.dblMKMMT(gvlngNowPage + gvintIndex))
            .txtMKOUTQTY.Text = CStr(musrMKMTRA.dblMKMOUTTRA(gvlngNowPage + gvintIndex))

        End With
        '//�̔��v��ڍ׏��擾
        If Not Get_HKDTRA() Then
            GoTo EXIT_STEP
        End If

        Get_DisplayData = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Get_HKDTRA
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    �̔��v��ڍ׏����擾����
    '//*****************************************************************************************
    Public Function Get_HKDTRA() As Boolean

        Const PROCEDURE As String = "Get_HKDTRA"

        Dim strSQL As String
        '2019/05/13 DEL START
        ''UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        'Dim objRec As OraDynaset
        '2019/05/13 DEL E N D

        Get_HKDTRA = False

        On Error GoTo ONERR_STEP

        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & "SELECT HKDTRA.* , MEIMTA.* , HKDTRA.DATKB AS HKDDATKB" & vbCrLf
        strSQL = strSQL & "FROM   HKDTRA,MEIMTA " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "WHERE  HKKYM = " & D0.Edt_SQL("S", HKKET143F.txtYEAR.Text & HKKET143F.txtMONTH.Text) & vbCrLf
        '// 2007/06/08 �� REP
        '    strSQL = strSQL & "  AND  HINCD = " & D0.Edt_SQL("S", HKKET143F.txtHINCD.Text) & vbCrLf
        If HKKET141F.optVERSION.Checked Then
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "  AND  HINCD LIKE (" & D0.Edt_SQL("S", HKKET143F.txtHINCD.Text & "%") & ")" & vbCrLf
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "  AND  HINCD = " & D0.Edt_SQL("S", HKKET143F.txtHINCD.Text) & vbCrLf
        End If
        '// 2007/06/08 �� REP
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "  AND  KEYCD = " & D0.Edt_SQL("S", gvstrClass) & vbCrLf
        strSQL = strSQL & "  AND  SBCD  = MEICDA "
        strSQL = strSQL & "  AND  SBCD  in  ("
        '// 2007/03/10 �� DEL
        '    If HKKET143F.txtYEAR.Text & HKKET143F.txtMONTH.Text >= Mid(gvstrUNYDT, 1, 6) Then
        '// 2007/03/10 �� DEL
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrder_Rcv) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrder) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & D0.Edt_SQL("S", gvstrEstimate) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & D0.Edt_SQL("S", gvstrIssue) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & D0.Edt_SQL("S", gvstrProvision) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrderRcvEstimate) & vbCrLf
        '// 2007/02/20 �� ADD
        strSQL = strSQL & ","
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & D0.Edt_SQL("S", gvstrSeiban) & vbCrLf
        '// 2007/02/20 �� ADD
        '// 2007/03/10 �� DEL
        '    Else
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrder_Rcv) & vbCrLf
        '        strSQL = strSQL & ","
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrder) & vbCrLf
        '        strSQL = strSQL & ","
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrProvision) & vbCrLf
        '        strSQL = strSQL & ","
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrderRcvEstimate) & vbCrLf
        ''// 2007/02/20 �� ADD
        '        strSQL = strSQL & ","
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrSeiban) & vbCrLf
        ''// 2007/02/20 �� ADD
        '    End If
        '// 2007/03/10 �� DEL
        strSQL = strSQL & "  )"

        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            '//�̔��v��ڍ׏�����ʂɕ\������
            '2019/04/15 CHG START
            'If Not Set_HKDTRA(objRec) Then
            If Not Set_HKDTRA(dt) Then
                '2019/04/15 CHG E N D
                GoTo EXIT_STEP
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g HKKET143F.lvwMEISAI.FullRowSelect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            HKKET143F.lvwMEISAI.FullRowSelect = True
            'UPGRADE_WARNING: �I�u�W�F�N�g HKKET143F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'HKKET143F.lvwMEISAI.ListItems.Item(1).Selected = True
            HKKET143F.lvwMEISAI.Items.Item(0).Selected = True
            '2019/04/11 CHG E N D
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

        Get_HKDTRA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Set_HKDTRA
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*            objRec              OraDynaset       I
    '//*
    '//* <��  ��>
    '//*    �̔��v��ڍ׏��\��
    '//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HKDTRA(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HKDTRA(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKDTRA"

        'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/11 DEL START
        'Dim objLitem As ListItem
        'Dim i As Short
        '2019/04/11 DEL E N D
        Set_HKDTRA = False

        On Error GoTo ONERR_STEP

        '2019/04/11 ADD START
        With HKKET143F.lvwMEISAI
            '2019/04/11 ADD E N D

            '2019/04/11 DEL START
            'i = 1
            '2019/04/11 DEL E N D

            '2019/04/15 ADD START
            Dim itemCnt As Integer = 0
            '2019/04/15 ADD E N D

            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'Do Until clsOra.OraEOF(objRec)
            For Each row As DataRow In pDT.Rows
                '2019/04/11 CHG E N D
                '// 2007/01/09 �� UPD STR
                '        Set objLitem = HKKET143F.lvwMEISAI.ListItems.Add(i, , D0.Chk_Null(objRec("MEINMA")))      '//���
                '        objLitem.SubItems(1) = D0.Chk_Null(objRec("HKKSU"))    '//�̔��v�搔��
                '        objLitem.SubItems(2) = D0.Chk_Null(objRec("HKKINFA"))  '//�󒍔ԍ���
                '        objLitem.SubItems(3) = D0.Chk_Null(objRec("TANNM"))    '//�S���Җ�
                '        objLitem.SubItems(4) = Format(D0.Chk_Null(objRec("HKKINFC")), "@@@@/@@/@@") '//�󒍓���
                '        objLitem.SubItems(5) = Format(D0.Chk_Null(objRec("HKKINFD")), "@@@@/@@/@@") '//�o�ד���
                '        objLitem.SubItems(6) = D0.Chk_Null(objRec("HKKINFE"))  '//������
                '        objLitem.SubItems(7) = D0.Chk_Null(objRec("HKKINFF"))  '//���Ӑ於��
                '        objLitem.SubItems(8) = D0.Chk_Null(objRec("PHINCD"))   '//�e���i�R�[�h
                '        objLitem.SubItems(9) = D0.Chk_Null(objRec("PHINKTA"))  '//�e�^��
                '        objLitem.SubItems(10) = D0.Chk_Null(objRec("ORDSCLNM")) '//�󒍋K�́^�m�x��
                '        objLitem.SubItems(11) = IIf(D0.Chk_Null(objRec("KHIKKB")) = "1", "��", "") '//�������敪
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g HKKET143F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/11 CHG START
                'objLitem = HKKET143F.lvwMEISAI.ListItems.Add(i, , D0.Chk_Null(objRec("MEINMA"))) '//���
                '0�`13(�S14��)
                '//0:
                .Items.Add(D0.Chk_Null(row("MEINMA")), itemCnt) '//���
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '//1:
                Select Case D0.Chk_Null(row("HKDDATKB")) '//�폜�敪
                    Case "1"
                        'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/11 CHG START
                        'objLitem.SubItems(1) = "��"
                        .Items(itemCnt).SubItems.Add("��")
                        '2019/04/11 CHG E N D
                    Case "9"
                        'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/11 CHG START
                        'objLitem.SubItems(1) = "��"
                        .Items(itemCnt).SubItems.Add("��")
                        '2019/04/11 CHG E N D
                    Case Else
                        'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/11 CHG START
                        'objLitem.SubItems(1) = ""
                        .Items(itemCnt).SubItems.Add("")
                        '2019/04/11 CHG E N D
                End Select
                '2019/04/11 CHG START
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(2) = D0.Chk_Null(objRec("HKKSU")) '//�̔��v�搔��
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(3) = D0.Chk_Null(objRec("HKKINFA")) '//�󒍔ԍ���
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(4) = D0.Chk_Null(objRec("MITNO")) '//���ϔԍ�
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(5) = D0.Chk_Null(objRec("TANNM")) '//�S���Җ�
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(6) = VB6.Format(D0.Chk_Null(objRec("HKKINFC")), "@@@@/@@/@@") '//�󒍓���
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(7) = VB6.Format(D0.Chk_Null(objRec("HKKINFD")), "@@@@/@@/@@") '//�o�ד���
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(8) = D0.Chk_Null(objRec("HKKINFE")) '//������
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(9) = D0.Chk_Null(objRec("HKKINFF")) '//���Ӑ於��
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(10) = D0.Chk_Null(objRec("PHINCD")) '//�e���i�R�[�h
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(11) = D0.Chk_Null(objRec("PHINKTA")) '//�e�^��
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(12) = D0.Chk_Null(objRec("ORDSCLNM")) '//�󒍋K�́^�m�x��
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(13) = IIf(D0.Chk_Null(objRec("KHIKKB")) = "1", "��", "") '//�������敪
                '//2:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HKKSU"))) '//�̔��v�搔��
                '//3:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HKKINFA"))) '//�󒍔ԍ���
                Debug.Print("itemCnt:" & itemCnt)
                Debug.Print("row(""HKKINFA""):" & row("HKKINFA"))
                Debug.Print("Text:" & HKKET143F.lvwMEISAI.Items(itemCnt).SubItems(3).Text)
                '//4:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("MITNO"))) '//���ϔԍ�
                '//5:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("TANNM"))) '//�S���Җ�
                '//6:
                .Items(itemCnt).SubItems.Add(VB6.Format(D0.Chk_Null(row("HKKINFC")), "@@@@/@@/@@")) '//�󒍓���
                '//7:
                .Items(itemCnt).SubItems.Add(VB6.Format(D0.Chk_Null(row("HKKINFD")), "@@@@/@@/@@")) '//�o�ד���
                '//8:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HKKINFE"))) '//������
                '//9:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HKKINFF"))) '//���Ӑ於��
                '//10:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("PHINCD"))) '//�e���i�R�[�h
                '//11:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("PHINKTA"))) '//�e�^��
                '//12:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("ORDSCLNM"))) '//�󒍋K�́^�m�x��
                '//13:
                .Items(itemCnt).SubItems.Add(IIf(D0.Chk_Null(row("KHIKKB")) = "1", "��", "")) '//�������敪
                '2019/04/11 CHG E N D
                '// 2007/01/09 �� UPD END
                '2019/04/15 DEL START
                'i = i + 1
                '2019/04/15 DEL E N D

                '2019/04/15 DEL START
                ''//��ں��ތ���
                ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraMoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'clsOra.OraMoveNext(objRec)
                '2019/04/15 DEL E N D

                '2019/04/15 ADD START
                itemCnt += 1
                '2019/04/15 ADD E N D

                '2019/04/15 CHG START
                'Loop
            Next
            '2019/04/15 CHG E N D

        '2019/04/11 ADD START
        End With
        '2019/04/11 ADD E N D

        '2019/04/16 ADD START
        HKKET143F.lvSorter143F.Order = LvSortOrder  'ItemAdd��ɐݒ肷��
        Call SortLv(HKKET143F.lvwMEISAI, InitSortColumn, HKKET143F.lvSorter143F, True)
        '2019/04/16 ADD E N D

        Set_HKDTRA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
End Module