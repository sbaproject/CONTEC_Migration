Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

'2019/05/13 ADD START
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
'2019/05/13 ADD E N D
Module Module1

    '//**************************************************************************************
    '//*
    '//* <��  ��>
    '//*    MAIN
    '//* <�T�@�v>
    '//*    �������
    '//*    �e�v���O�����ɂ���āA���o�������قȂ�
    '//*
    '//* <�߂�l>     �^          ����
    '//*�@�@�Ȃ�
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*�@�@�@�@�@�@�@���[PK
    '//*�@�@�@�@�@�@�@�v�����g�敪
    '//*�@�@�@�@�@�@�@�v���r���[�敪
    '//*�@�@�@�@�@�@�@�v���l�X���ʈ���
    '//*
    '//* <��  ��>
    '//*
    '//*
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20091127|ECHO)          |�V�K�쐬
    '//* 1.01     |20100420|ECHO)          |<ST-0038>�b�r�u�o�̓p�X�ύX
    '//* 1.02     |20100517|ECHO)          |<IT-0036,0037>
    '//*                                   |���㌴���Ώƕ\(�o�������E�S��)��CSV�o�͏����ǉ�
    '//* 1.03     |20100518|ECHO)          |<ST-0134>�������������̃^�C�g���ύX
    '//* 1.05     |20100526|ECHO)�A��      |<ST-0152>�i�s��t���O���o��
    '//* 1.06     |20100604|ECHO)          |<IT2-00XX>�d�|�i���ו\�E���㎞�������ו\�E
    '//*                                   |�ǉ��������ו\�̃^�C�g���ύX
    '//* 1.06     |20100625|ECHO)          |<OT-00XX>���X�|���X�Ή�
    '//*                                   |���o��SQL��oo4o���g�p����悤�ɕύX
    '//*                                   |�d�|�i���ו[�̂ݎb��Ή�
    '//* 1.07     |20100720|ECHO)          |<OT-0138>���o�����ڂ̏C��(�J���� �� �J���E�Ԑڔ�)
    '//* 1.08     |20150109|RS)            |������������CSV�o�͏��̐ݒ�ǉ��@���ԑ̌n�敪�A���ԁASQL
    '//*                                   |�������z���͕\CSV�^�C�g���C��
    '//*          |20151006|FWEST          |PDF�o�͏����ǉ�
    '//*          |20151029|FWEST          |CSV�o�͏����ǉ�
    '//**************************************************************************************

    '**** ���|�[�g�t�@�C���ۑ��ꏊ ****
    '** �@���L�t�H���_���ɁARPT�t�H���_���쐬���A���̒��Ƀ��|�[�g�t�@�C�����܂Ƃ߂ĕۑ� **
    '**********************************

    '**** �R�}���h���C������ ****
    Public ps_UserName As String '�׸�հ��
    Public ps_Password As String '�׸ِڑ� �߽ܰ��
    Public ps_DatabaseName As String '�׸ِڑ�������
    Public ps_GENKAUserName As String '��������հ��
    Public ps_User_Lang As String '
    Public ps_Rpt_Lang As String
    Public ps_Param_Mode As String
    Public ps_Param_Factory As String
    Public ps_Param_AnyNo As String
    Public li_StartIdx As String
    Public ps_prtPmKey As String

    Public SSS_PrgId As String '��۸��тh�c
    Public SSS_PrgNm As String '��۸��і�
    Public SSS_PrtID As String '���|�[�g�h�c
    Public SSS_RPT_DIR As String '���|�[�g�i�[�ꏊ
    Public SSS_TblID As String '�e�[�u���h�c
    Public SSS_PRINTER_NM As String '�v�����^����

    '���|�[�g�h�c
    Public Const ps_rptid_GNKPR01 As String = "GNKPR01"
    Public Const ps_rptid_GNKPR02 As String = "GNKPR02"
    Public Const ps_rptid_GNKPR03 As String = "GNKPR03"
    Public Const ps_rptid_GNKPR04 As String = "GNKPR04"
    Public Const ps_rptid_GNKPR05 As String = "GNKPR05"
    Public Const ps_rptid_GNKPR06 As String = "GNKPR06"
    Public Const ps_rptid_GNKPR07 As String = "GNKPR07"
    Public Const ps_rptid_GNKPR08 As String = "GNKPR08"
    Public Const ps_rptid_GNKPR09 As String = "GNKPR09"
    Public Const ps_rptid_GNKPR10 As String = "GNKPR10"
    Public Const ps_rptid_GNKPR18 As String = "GNKPR18"
    Public Const ps_rptid_GNKPR12 As String = "GNKPR12"
    Public Const ps_rptid_GNKPR13 As String = "GNKPR13"
    Public Const ps_rptid_GNKPR14 As String = "GNKPR14"
    Public Const ps_rptid_GNKPR16 As String = "GNKPR16"
    '���|�[�g��
    Const ps_rptnm_GNKPR01 As String = "���㌴���Ώƕ\�i�o��������j(�S�Ёj"
    Const ps_rptnm_GNKPR02 As String = "���㌴���Ώƕ\(�S�Ёj"
    Const ps_rptnm_GNKPR03 As String = "���㌴���Ώƕ\(�{���ʁj"
    Const ps_rptnm_GNKPR04 As String = "���㌴���Ώƕ\(�����ʁj"
    Const ps_rptnm_GNKPR05 As String = "���㎞�������ו\"
    Const ps_rptnm_GNKPR06 As String = "�ǉ��������ו\"
    Const ps_rptnm_GNKPR07 As String = "�d�|�i���ו\"
    Const ps_rptnm_GNKPR08 As String = "������������"
    Const ps_rptnm_GNKPR09 As String = "�����i����"
    '<2014/10/21 UPD STR>
    'Const ps_rptnm_GENPR10 As String = "�I�D"
    Const ps_rptnm_GNKPR10 As String = "�d�|�i�`�F�b�N���X�g"
    Const ps_rptnm_GNKPR18 As String = "�������͕\"
    Const ps_rptnm_GNKPR12 As String = "�H���W�v�����\"
    Const ps_rptnm_GNKPR13 As String = "�������z���͕\"
    Const ps_rptnm_GNKPR14 As String = "�J����E�Ԑڔ�z�������\"
    Const ps_rptnm_GNKPR16 As String = "�����U�փ��X�g"
    '<2014/10/21 UPD END>


    'UPGRADE_WARNING: Sub Main() �����������Ƃ��ɃA�v���P�[�V�����͏I�����܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"' ���N���b�N���Ă��������B
    Public Sub Main()


        Dim li_MsgRtn As Short 'MsgBox�̖߂�l
        Dim li_UpperBound As Short 'MsgBox�̖߂�l
        Dim wrk As String '�R�}���h���C�������ݒ�p���[�N
        Dim prtCmd() As String
        Dim prtKbn As String '�v�����g�敪
        Dim prvKbn As String '�v���r���[�敪
        Dim is_Proness As String '�v���l�X���ʈ���
        Dim li_Ret As Short
        Dim li_StrLen As Short
        Dim li_UserSTR As Short
        Dim li_PassSTR As Short
        Dim li_DbNameSTR As Short
        Dim li_PRONES_UserSTR As Short
        Dim li_ULangSTR As Short
        Dim li_RLangSTR As Short
        Dim li_ModeSTR As Short
        Dim li_FactorySTR As Short
        Dim li_AnyNoSTR As Short
        Dim li_UserLen As Short
        Dim li_PassLen As Short
        Dim li_DbNameLen As Short
        Dim li_PRONES_UserLen As Short
        Dim li_ULangLen As Short
        Dim li_RLangLen As Short
        Dim li_ModeLen As Short
        Dim li_FactoryLen As Short
        Dim li_AnyNoLen As Short
        Dim li_Idx As Short
        Dim ls_CmdFlg As String
        Dim ls_WorkStr As String
        Dim ls_StartTxt As String
        Dim ls_FileName As String '2015/10/6�ǋL�@FWEST


        '--------------------------------------------------------------------------
        '�����J�n
        '--------------------------------------------------------------------------
        '---�߂�l�ݒ�---'
        li_UpperBound = 0

        '---������---'
        '�R�}���h���C�������̐ݒ�
        wrk = VB.Command()

        prtCmd = Split(Trim(wrk), ",")

        ' ���[PK
        ps_prtPmKey = prtCmd(1)
        ' ���|�[�g�h�c
        SSS_PrtID = prtCmd(2)
        '�v�����^�[��
        SSS_PRINTER_NM = prtCmd(3)
        ' �v�����g�敪
        prtKbn = prtCmd(4)
        ' �v���r���[�敪
        '            prvKbn = Left(prtCmd(3), 1)
        prvKbn = prtCmd(5)
        ' �v���l�X���ʈ���
        is_Proness = Trim(prtCmd(6))

        '2015/10/6�ǋL�@FWEST
        '����PDF�o�͗p�̃R�}���h���C������������Ȃ��
        If UBound(prtCmd) - LBound(prtCmd) + 1 = 8 Then
            ' PDF�̃t�@�C����(��΃p�X)
            ls_FileName = Trim(prtCmd(7))
        End If

        '������
        li_UpperBound = Len(ps_prtPmKey) + Len(prtKbn) + Len(prvKbn)
        '''�R�}���h���C�������m�F�p
        '''MsgBox("�R�}���h���C������:" & wrk)
        '''MsgBox("���|�[�g�h�c:" & SSS_PrtID)
        '''MsgBox("�v�����^��:" & SSS_PRINTER_NM)
        '''MsgBox("���[PK:" & ps_prtPmKey)
        '''MsgBox("�v�����g�敪:" & prtKbn)
        '''MsgBox("�v���r���[�敪:" & prvKbn)
        '''MsgBox("�v���l�X���ʈ���:" & is_Proness)
        '''MsgBox("PDF��:" & PDF_NM)


        li_StrLen = Len(is_Proness)
        li_UserSTR = 1
        li_PassSTR = 1
        li_DbNameSTR = 1
        li_PRONES_UserSTR = 1
        li_ULangSTR = 1
        li_RLangSTR = 1
        li_ModeSTR = 1
        li_FactorySTR = 1
        li_AnyNoSTR = 1
        li_UserLen = 0
        li_PassLen = 0
        li_DbNameLen = 0
        li_PRONES_UserLen = 0
        li_ULangLen = 0
        li_RLangLen = 0
        li_ModeLen = 0
        li_FactoryLen = 0
        li_AnyNoLen = 0

        ls_CmdFlg = "USER"
        For li_Idx = 1 To li_StrLen
            Select Case Trim(ls_CmdFlg)
                Case "USER"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "/" Then
                        li_PassSTR = li_Idx + 1
                        ls_CmdFlg = "PASS"
                    Else
                        li_UserLen = li_UserLen + 1
                    End If
                Case "PASS"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "@" Then
                        li_DbNameSTR = li_Idx + 1
                        ls_CmdFlg = "DBNAME"
                    Else
                        li_PassLen = li_PassLen + 1
                    End If
                Case "DBNAME"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_PRONES_UserSTR = li_Idx + 1
                        ls_CmdFlg = "PRONES_USER"
                    Else
                        li_DbNameLen = li_DbNameLen + 1
                    End If
                Case "PRONES_USER"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_ULangSTR = li_Idx + 1
                        ls_CmdFlg = "ULang"
                    Else
                        li_PRONES_UserLen = li_PRONES_UserLen + 1
                    End If
                Case "ULang"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_RLangSTR = li_Idx + 1
                        ls_CmdFlg = "RLang"
                    Else
                        li_ULangLen = li_ULangLen + 1
                    End If
                Case "RLang"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_ModeSTR = li_Idx + 1
                        ls_CmdFlg = "Mode"
                    Else
                        li_RLangLen = li_RLangLen + 1
                    End If
                Case "Mode"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_FactorySTR = li_Idx + 1
                        ls_CmdFlg = "Factory"
                    Else
                        li_ModeLen = li_ModeLen + 1
                    End If
                Case "Factory"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_AnyNoSTR = li_Idx + 1
                        ls_CmdFlg = "AnyNo"
                    Else
                        li_FactoryLen = li_FactoryLen + 1
                    End If
                Case "AnyNo"
                    li_AnyNoLen = li_AnyNoLen + 1
            End Select
        Next li_Idx

        ps_UserName = Mid(is_Proness, li_UserSTR, li_UserLen)
        ps_Password = Mid(is_Proness, li_PassSTR, li_PassLen)
        ps_DatabaseName = Mid(is_Proness, li_DbNameSTR, li_DbNameLen)
        ps_GENKAUserName = Mid(is_Proness, li_PRONES_UserSTR, li_PRONES_UserLen)
        ps_User_Lang = Mid(is_Proness, li_ULangSTR, li_ULangLen)
        ps_Rpt_Lang = Mid(is_Proness, li_RLangSTR, li_RLangLen)
        ps_Param_Mode = Mid(is_Proness, li_ModeSTR, li_ModeLen)
        ps_Param_Factory = Mid(is_Proness, li_FactorySTR, li_FactoryLen)
        ps_Param_AnyNo = Mid(is_Proness, li_AnyNoSTR, li_AnyNoLen)


        '****************************************
        '***
        '***   ini�t�@�C�� �擾�i�ۗ��j
        '***
        '****************************************
        'CALL GENKA_GETINI()


        '****************************************
        '***
        '***   ���|�[�g�t�@�C���i�[�ꏊ�@�擾
        '***
        '****************************************
        Dim sDIR As String
        Dim lLen As Integer
        Dim lStt As Integer
        Dim lEnd As Integer

        sDIR = My.Application.Info.DirectoryPath
        lLen = Len(sDIR)
        For lStt = 1 To lLen
            If InStr(lStt, sDIR, "\") <> 0 Then
                lEnd = InStr(lStt, sDIR, "\")
                lStt = lEnd
            Else
                Exit For
            End If
        Next
        SSS_RPT_DIR = Left(sDIR, lEnd) & "RPT"

        'MsgBox SSS_RPT_DIR

        '****************************************
        '***
        '***   ���[���@�擾
        '***
        '****************************************
        If GET_RPTNM() = 0 Then

            '2015/10/6�ǋL�@FWEST
            If UBound(prtCmd) - LBound(prtCmd) + 1 = 8 Then
                '���[PDF�o�͏���
                PDF_OUTPUT(ls_FileName)

                '2015/10/29�ǋL�@FWEST
                '�H���W�v�����\��CSV�o�̓{�^����\�����Ȃ�
                If SSS_PrtID <> ps_rptid_GNKPR12 Then
                    'CSV�o�͏���
                    CSV_OUTPUT_B(ls_FileName)
                End If
            Else
                '���[VIEWER����
                Call frmRptViewer.Show()
            End If
        End If

    End Sub


    Private Function GET_RPTNM() As Short

        Dim li_Ret As Short

        li_Ret = 0


        Select Case SSS_PrtID

            Case ps_rptid_GNKPR01 '���㌴���Ώƕ\�i�o��������j(�S�Ёj
                SSS_TblID = "C_G105W"
                SSS_PrgNm = ps_rptnm_GNKPR01

            Case ps_rptid_GNKPR02 '���㌴���Ώƕ\(�S�Ёj
                SSS_TblID = "C_G106W"
                SSS_PrgNm = ps_rptnm_GNKPR02

            Case ps_rptid_GNKPR03 '���㌴���Ώƕ\(���ƕ��j
                SSS_TblID = "C_G107W"
                SSS_PrgNm = ps_rptnm_GNKPR03

            Case ps_rptid_GNKPR04 '���㌴���Ώƕ\(�����ʁj
                SSS_TblID = "C_G108W"
                SSS_PrgNm = ps_rptnm_GNKPR04

            Case ps_rptid_GNKPR05 '���㎞�������ו\
                SSS_TblID = "C_G103W"
                SSS_PrgNm = ps_rptnm_GNKPR05

            Case ps_rptid_GNKPR06 '�ǉ��������ו\
                SSS_TblID = "C_G104W"
                SSS_PrgNm = ps_rptnm_GNKPR06

            Case ps_rptid_GNKPR07 '�d�|�i���ו\
                SSS_TblID = "C_G101W"
                SSS_PrgNm = ps_rptnm_GNKPR07

            Case ps_rptid_GNKPR08 '������������
                SSS_TblID = "C_G110W"
                SSS_PrgNm = ps_rptnm_GNKPR08

            Case ps_rptid_GNKPR09 '�����i����
                SSS_TblID = "C_G102W"
                SSS_PrgNm = ps_rptnm_GNKPR09

                '        Case ps_rptid_GENPR10           '�I�D
                '            SSS_TblID = "C_G013W"
                '            SSS_PrgNm = ps_rptnm_GENPR10

            Case ps_rptid_GNKPR10 '�d�|�i�`�F�b�N���X�g
                SSS_TblID = "C_G114W"
                SSS_PrgNm = ps_rptnm_GNKPR10

            Case ps_rptid_GNKPR18 '�������͕\
                SSS_TblID = "C_G112W"
                SSS_PrgNm = ps_rptnm_GNKPR18

            Case ps_rptid_GNKPR12 '�H���W�v�����\
                SSS_TblID = "C_G109W"
                SSS_PrgNm = ps_rptnm_GNKPR12

            Case ps_rptid_GNKPR13 '�������z���͕\
                SSS_TblID = "C_G111W"
                SSS_PrgNm = ps_rptnm_GNKPR13

            Case ps_rptid_GNKPR14 '�J����E�Ԑڔ�z�������\
                SSS_TblID = "C_G115W"
                SSS_PrgNm = ps_rptnm_GNKPR14

            Case ps_rptid_GNKPR16 '�����U�փ��X�g
                SSS_TblID = "C_G117W"
                SSS_PrgNm = ps_rptnm_GNKPR16

            Case Else
                MsgBox("�w�肳�ꂽ���[�͑��݂��܂���B")
                li_Ret = 9
        End Select

        GET_RPTNM = li_Ret

    End Function

    '2019/05/21 CHG START
    '    Public Function CSV_OUTPUT(ByVal ps_FormID As String, ByVal ps_Sql As String, ByVal ps_ClmHedNm As String, ByVal ps_RowHedNm As String, ByVal ps_RowHedNm2 As String, Optional ByVal ps_FilePath As String = "") As Boolean
    '        '==========================================================================
    '        '   �֐�:CSV�o��
    '        '   �T�v:������SQL����CSV�𒼐ڍ쐬����
    '        '   IO  ����            �l          ���e
    '        '   IN  ps_FormID                   ���ID
    '        '   IN  ps_CSV_Data                 �o�͑Ώە�����
    '        '   IN  ps_FilePath                 �o��̧���߽
    '        '
    '        '   �߂�l              �l          ���e
    '        '                       True        ����I��
    '        '                       False       �ُ�I��
    '        '
    '        '   �쐬�E�X�V      �S����      �ύX���e
    '        '   2009/12/18      ���        �V�K�쐬
    '        '
    '        '==========================================================================
    '        '--------------------------------------------------------------------------
    '        '�ϐ��̒�`
    '        '--------------------------------------------------------------------------
    '        Dim li_MsgRtn As Short 'MsgBox�̖߂�l
    '        Dim ls_CSV_Data As String
    '        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '        Dim Usr_Ody As U_Ody
    '        Dim i As Short

    '        'UPGRADE_ISSUE: OraFields �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '        '2019/05/13 CHG START
    '        'Dim OraFields As OraFields
    '        Dim OraFields As Object
    '        '2019/05/13 CHG E N D

    '        On Error GoTo ERR_END

    '        '--------------------------------------------------------------------------
    '        '�G���[�g���b�v�錾
    '        '--------------------------------------------------------------------------

    '        '--------------------------------------------------------------------------
    '        '�����J�n
    '        '--------------------------------------------------------------------------
    '        '//�ڑ�
    '        ' < OT-00XX> UPD STR
    '        '            If F_Ora_Connect(gv_Oss, gv_Odb, ps_DatabaseName, ps_UserName, ps_Password) = False Then
    '        '                GoTo ERR_END
    '        '            End If
    '        'UPGRADE_WARNING: CSV_OUTPUT �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
    '        ' < OT-00XX> UPD END

    '        '---�߂�l�ݒ�---'
    '        CSV_OUTPUT = False

    '        '�޲ž�ď�����()
    '        ' < OT-00XX> UPD STR
    '        '''            Usr_Ody.Obj_Ody = Nothing
    '        '            'SQL���s()
    '        '            Call CF_Ora_CreateDyn(gv_Odb, Usr_Ody, ps_Sql)
    '        '''            lo_Dynaset = OraDatabase.CreateDynaset(ps_Sql, 2)
    '        'UPGRADE_WARNING: �I�u�W�F�N�g ODatabase.DbCreateDynaset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        Odynaset = ODatabase.DbCreateDynaset(ps_Sql, ORADYN_ORAMODE)

    '        ' < OT-00XX> UPD END

    '        '---0�����ʹװү���ޕ\��---'
    '        'UPGRADE_WARNING: �I�u�W�F�N�g Odynaset.RecordCount �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        If Odynaset.RecordCount = 0 Then
    '            '2015/10/29�ǋL�@FWEST
    '            If Len(Trim(ps_FilePath)) = 0 Then
    '                li_MsgRtn = MsgBox("CSV�o���ް������݂��܂���ł����B", MsgBoxStyle.OkOnly, "�����Ǘ��V�X�e��")
    '            End If
    '            '---�߂�l�ݒ�---'
    '            CSV_OUTPUT = True
    '            Exit Function
    '        Else

    '            '�������z���͕\�̂ݗ�w�b�_��2�s�o�͂���
    '            If SSS_PrtID = ps_rptid_GNKPR13 Then
    '                '---��ͯ�ް���ݒ�---'
    '                If Len(Trim(ps_RowHedNm2)) <> 0 Then
    '                    ls_CSV_Data = ls_CSV_Data & ("""" & ps_RowHedNm2 & """" & vbCrLf)
    '                End If
    '            End If

    '            '---��ͯ�ް���ݒ�---'
    '            If Len(Trim(ps_ClmHedNm)) <> 0 Then
    '                ls_CSV_Data = ls_CSV_Data & ("""" & ps_ClmHedNm & """" & vbCrLf)
    '            End If

    '            '�Ǎ�
    '            ' < OT-00XX> UPD STR
    '            '*D*Usr_Ody.Obj_Ody.movefirst
    '            '*D*OraFields = Usr_Ody
    '            'UPGRADE_WARNING: �I�u�W�F�N�g Odynaset.MoveFirst �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            Odynaset.MoveFirst()

    '            'UPGRADE_WARNING: �I�u�W�F�N�g Odynaset.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            OraFields = Odynaset.Fields

    '            'UPGRADE_WARNING: �I�u�W�F�N�g Odynaset.EOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            Do Until Odynaset.EOF

    '                '---�sͯ�ް���ݒ�---'
    '                If Len(Trim(ps_RowHedNm)) <> 0 Then
    '                    ls_CSV_Data = ls_CSV_Data & ("""" & ps_RowHedNm & """,")
    '                End If

    '                'UPGRADE_WARNING: �I�u�W�F�N�g OraFields().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                ls_CSV_Data = ls_CSV_Data & CStr(OraFields(0).Value) & vbCrLf

    '                '                    '---���ڌ������������{---'
    '                '                    For i = 0 To Odynaset.Fields.Count - 1
    '                '                        '---�ް��擾---'
    '                '                        '*D*ls_CSV_Data = ls_CSV_Data & ("""" & CF_Ora_GetDyn(Usr_Ody, i, "") & "")
    '                '
    '                '                        If i >= Odynaset.Fields.Count - 1 Then
    '                '                            '---�ŏI���ڂ̏ꍇ���s---'
    '                '                            ls_CSV_Data = ls_CSV_Data & ("""" & vbCrLf)
    '                '                        Else
    '                '                            ls_CSV_Data = ls_CSV_Data & (""",")
    '                '                        End If
    '                '                    Next
    '                'UPGRADE_WARNING: �I�u�W�F�N�g Odynaset.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                Odynaset.MoveNext()
    '            Loop
    '        End If
    '        ' < OT-00XX> UPD END

    '        'CSV�o��
    '        If CSV_OUTPUT2(ps_FormID, ls_CSV_Data, ps_FilePath) = False Then Exit Function


    '        '---�߂�l�ݒ�---'
    '        CSV_OUTPUT = True

    '        Exit Function

    '        '--------------------------------------------------------------------------
    '        '�G���[�g���b�v���[�`��
    '        '--------------------------------------------------------------------------
    'ERR_END:
    '        li_MsgRtn = MsgBox("CSV�o�͊֐��G���[" & vbCrLf, MsgBoxStyle.Critical, "�G���[")

    '    End Function
    Public Function CSV_OUTPUT(ByVal ps_FormID As String, ByVal ps_Sql As String, ByVal ps_ClmHedNm As String, ByVal ps_RowHedNm As String, ByVal ps_RowHedNm2 As String, Optional ByVal ps_FilePath As String = "") As Boolean
        '==========================================================================
        '   �֐�:CSV�o��
        '   �T�v:������SQL����CSV�𒼐ڍ쐬����
        '   IO  ����            �l          ���e
        '   IN  ps_FormID                   ���ID
        '   IN  ps_CSV_Data                 �o�͑Ώە�����
        '   IN  ps_FilePath                 �o��̧���߽
        '
        '   �߂�l              �l          ���e
        '                       True        ����I��
        '                       False       �ُ�I��
        '
        '   �쐬�E�X�V      �S����      �ύX���e
        '   2009/12/18      ���        �V�K�쐬
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '�ϐ��̒�`
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Short 'MsgBox�̖߂�l
        Dim ls_CSV_Data As String

        On Error GoTo ERR_END
        'add test 20190822 kuwa
        'MsgBox(ps_FilePath)
        'ps_FilePath = ""
        'MsgBox(ps_FilePath)
        'add end 20190822 kuwa
        '--------------------------------------------------------------------------
        '�����J�n
        '--------------------------------------------------------------------------
        '//�ڑ�
        DB_START_GENKA()

        '---�߂�l�ݒ�---'
        CSV_OUTPUT = False

        '�f�[�^�擾
        Dim dt As DataTable = DB_GetTable(ps_Sql, CON_GENKA)

        '---0�����ʹװү���ޕ\��---'
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            If Len(Trim(ps_FilePath)) = 0 Then
                li_MsgRtn = MsgBox("CSV�o���ް������݂��܂���ł����B", MsgBoxStyle.OkOnly, "�����Ǘ��V�X�e��")
            End If
            '---�߂�l�ݒ�---'
            CSV_OUTPUT = True
            Exit Function
        Else

            '�������z���͕\�̂ݗ�w�b�_��2�s�o�͂���
            If SSS_PrtID = ps_rptid_GNKPR13 Then
                '---��ͯ�ް���ݒ�---'
                If Len(Trim(ps_RowHedNm2)) <> 0 Then
                    ls_CSV_Data = ls_CSV_Data & ("""" & ps_RowHedNm2 & """" & vbCrLf)
                End If
            End If

            '---��ͯ�ް���ݒ�---'
            If Len(Trim(ps_ClmHedNm)) <> 0 Then
                ls_CSV_Data = ls_CSV_Data & ("""" & ps_ClmHedNm & """" & vbCrLf)
            End If

            '�Ǎ�
            For cnt As Integer = 0 To dt.Rows.Count - 1
                If Len(Trim(ps_RowHedNm)) <> 0 Then
                    ls_CSV_Data = ls_CSV_Data & ("""" & ps_RowHedNm & """,")
                End If

                ls_CSV_Data = ls_CSV_Data & CStr(dt.Rows(cnt)("data")) & vbCrLf

            Next
        End If

        'CSV�o��
        If CSV_OUTPUT2(ps_FormID, ls_CSV_Data, ps_FilePath) = False Then Exit Function


        '---�߂�l�ݒ�---'
        CSV_OUTPUT = True

        Exit Function

        '--------------------------------------------------------------------------
        '�G���[�g���b�v���[�`��
        '--------------------------------------------------------------------------
ERR_END:
        li_MsgRtn = MsgBox("CSV�o�͊֐��G���[" & vbCrLf, MsgBoxStyle.Critical, "�G���[")

    End Function
    '2019/05/21 CHG E N D

    ''' <summary>
    ''' CSV�o��(�����񂩂�o��)
    Public Function CSV_OUTPUT2(ByVal ps_FormID As String, ByVal ps_CSV_Data As String, Optional ByVal ps_FilePath As String = "") As Boolean
        Dim cdlCancel As Object
        '==========================================================================
        '   �֐�:CSV�o��
        '   �T�v:�����̕����񂩂�CSV�𒼐ڍ쐬����
        '   IO  ����            �l          ���e
        '   IN  ps_FormID                   ���ID
        '   IN  ps_CSV_Data                 �o�͑Ώە�����(�R���}��؂����s���A���`�ς݂ł��邱��)
        '   IN  ps_FilePath                 �o��̧���߽(�ȗ����̓t�@�C���w��_�C�A���O��\�����܂�)
        '
        '   �߂�l              �l          ���e
        '                       True        ����I��
        '                       False       �ُ�I��
        '
        '   �쐬�E�X�V      �S����      �ύX���e
        '   2009/12/21      ���        �V�K�쐬
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '�ϐ��̒�`
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Short 'MsgBox�̖߂�l
        Dim ls_CSV_Data As String
        Dim ls_FilePath As String '�o��̧���߽
        Dim iFno As Short
        Dim li_ExeMsgRtn As Short

        '        Dim lo_SW As System.IO.StreamWriter

        '--------------------------------------------------------------------------
        '�����J�n
        '--------------------------------------------------------------------------
        '---�߂�l�ݒ�---'
        CSV_OUTPUT2 = False

        '2019/05/13 ADD START
        frmRptViewer.CmDlg = New OpenFileDialog()
        '2019/05/13 ADD E N D

        '------------------------------
        '�ۑ�̧�ٖ��擾
        '------------------------------
        '---����̧���߽����---'
        ls_FilePath = ps_FilePath
        '̧���߽��������΁A������̧���߽�𕷂�
        If Len(Trim(ls_FilePath)) = 0 Then

            'CancelError�̏�����
            'UPGRADE_WARNING: �I�u�W�F�N�g frmRptViewer.CmDlg.CancelError �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/5/13 CHG START
            'frmRptViewer.CmDlg.CancelError = True
            frmRptViewer.CmDlg.CheckFileExists = True
            '2019/05/13 CHG E N D

            On Error Resume Next

            '�t�B���^�ݒ�
            ' === ST-0038 ===
            '*D*frmRptViewer.CmDlg.InitDir = "V:\"
            ' === ST-0038 ===
            'UPGRADE_WARNING: �I�u�W�F�N�g frmRptViewer.CmDlg.Filter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            frmRptViewer.CmDlg.Filter = "csv �t�@�C�� (*.csv)|*.csv|���ׂẴt�@�C�� (*.*)|*.*"

            '2019/05/13 CHG 
            ''�_�C�A���O��\������
            ''UPGRADE_WARNING: �I�u�W�F�N�g frmRptViewer.CmDlg.ShowSave �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'frmRptViewer.CmDlg.ShowSave()

            ''�L�����Z���̃G���[�C�x���g���擾�����ꍇ
            ''UPGRADE_WARNING: �I�u�W�F�N�g cdlCancel �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'If Err.Number = cdlCancel Then
            '	Exit Function
            'End If
            '2019/05/21 CHG START
            'If frmRptViewer.CmDlg.ShowDialog() <> DialogResult.Cancel Then
            '    Exit Function
            'End If
            ''2019/05/13 CHG E N D

            ''UPGRADE_WARNING: �I�u�W�F�N�g frmRptViewer.CmDlg.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'ls_FilePath = frmRptViewer.CmDlg.FileName
            'If Trim(ls_FilePath) = CStr(VariantType.Null) Then
            '    Exit Function
            'End If
            ls_FilePath = "C:\Users\nb003674.CONTEC\Desktop"
            '2019/05/21 CHG E N D

            'add test 20190822 kuwa
            'ps_FilePath�ɒl�������Ă��Ȃ����(̧���߽���������)���L�̃p�X��test.csv�Ƃ������̂�csv���o��
            ls_FilePath = "C:\Users\nb003380.CONTEC\Desktop\test.csv"
            ls_FilePath = "C:\Users\CIS03\Desktop\test.csv"

            'message 20190822 �t�H�[��������ۂ�bin�t�H���_��3.csv�Ƃ������O��csv���o�͂����s�����
            'add test 20190822 kuwa

        End If

        '�������ޒl�̃Z�b�g
        ls_CSV_Data = ps_CSV_Data

        '�t�@�C���I�[�v��
        iFno = FreeFile()
        MsgBox("csv") 'add test
        FileOpen(iFno, ls_FilePath, OpenMode.Output)
        MsgBox("csv2") 'add test
        'CSV����
        PrintLine(iFno, ls_CSV_Data)

        '�t�@�C���N���[�Y
        FileClose(iFno)


        ''            '��ݻ޸��݂̊J�n
        ''            OraSession.BeginTrans()
        ''
        ''            Try
        ''                '------------------------------
        ''                'CSV�o�͗����Ǘ��e�[�u���ǉ�
        ''                '------------------------------
        ''                'SQL���쐬
        ''                EmpQuery = ""
        ''                EmpQuery = EmpQuery & " insert into C_Z025T ( "
        ''                EmpQuery = EmpQuery & "     C_EXP_CSV_DDT, "
        ''                EmpQuery = EmpQuery & "     C_EMP_CD, "
        ''                EmpQuery = EmpQuery & "     C_PG_ID, "
        ''                EmpQuery = EmpQuery & "     C_EXP_CSV_DESC, "
        ''                EmpQuery = EmpQuery & "     C_EXP_CSV_SQL "
        ''                EmpQuery = EmpQuery & " ) values ( "
        ''                EmpQuery = EmpQuery & " '" & Format(Now(), "yyyyMMddHHmmss") & "', "        'CSV�o�͓���
        ''                EmpQuery = EmpQuery & " '" & ps_PRONESUserName & "', "                      '�]�ƈ�����
        ''                EmpQuery = EmpQuery & " '" & ps_FormID & "', "                              '���ID
        ''                EmpQuery = EmpQuery & " '" & ls_FilePath & "', "                             '�o��CSV̧�ٖ�
        ''                EmpQuery = EmpQuery & " '��ʖ��׏o��' "                                    'CSV�o��SQL��
        ''                EmpQuery = EmpQuery & " ) "
        ''                'SQL���s
        ''                OraDatabase.ExecuteSQL (EmpQuery)
        ''
        ''            Catch ex As Exception
        ''                '۰��ޯ�
        ''                OraSession.Rollback()
        ''                If pb_YakanFlg = False Then
        ''                    li_MsgRtn = MsgBox("CSV�o�͗����X�V���G���[(Oracle�EInsert)" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        ''                Else
        ''                    WRITE_LOG ("CSV�o�͗����X�V���G���[(Oracle�EInsert)" & " , " & ex.Message.ToString)
        ''                End If
        ''                Exit Function
        ''            End Try

        ''            '�Я�
        ''            OraSession.CommitTrans()

        '2015/10/29�ǋL�@FWEST
        If Len(Trim(ls_FilePath)) = 0 Then
            '�������b�Z�[�W�o�̓t���O��True�̏ꍇ����ԃt���O��False�̏ꍇ�̓��b�Z�[�W�\��
            li_MsgRtn = MsgBox("CSV�o�͂��������܂����B", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "�����Ǘ��V�X�e��") 'CSV�o�͂��������܂����B
        End If

        '---�߂�l�ݒ�---'
        CSV_OUTPUT2 = True

        Exit Function

        '--------------------------------------------------------------------------
        '�G���[�g���b�v���[�`��
        '--------------------------------------------------------------------------


ERR_END:
        li_MsgRtn = MsgBox("CSV�o�͊֐��G���[" & vbCrLf, MsgBoxStyle.Critical, "�G���[")

    End Function



    Public Function Get_Sql(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String, ByRef sColHeader2 As String) As Boolean


        Dim bolRet As Boolean

        On Error GoTo ERR_END


        Get_Sql = False

        '�r�p�k�E�w�b�_�̎擾
        Select Case SSS_PrtID

            Case ps_rptid_GNKPR01 '���㌴���Ώƕ\�i�o��������j(�S�Ёj
                bolRet = GET_SQL_���㌴���Ώƕ\_�o��������(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR02 '���㌴���Ώƕ\(�S�Ёj
                bolRet = GET_SQL_���㌴���Ώƕ\_�S��(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR03 '���㌴���Ώƕ\(�{���ʁj
                bolRet = GET_SQL_���㌴���Ώƕ\_�{����(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR04 '���㌴���Ώƕ\(�����ʁj
                bolRet = GET_SQL_���㌴���Ώƕ\_������(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR05 '���㎞�������ו\
                bolRet = GET_SQL_���㎞�������ו\(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR06 '�ǉ��������ו\
                bolRet = GET_SQL_�ǉ��������ו\(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR07 '�d�|�i���ו\
                bolRet = GET_SQL_�d�|�i���ו\(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR08 '������������
                bolRet = GET_SQL_������������(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR09 '�����i����
                bolRet = GET_SQL_�����i����(sSql, sColHeader, sRowHeader)

                '        Case ps_rptid_GENPR10           '�I�D
                '            bolRet = GET_SQL_�I�D(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR10 '�d�|�i�`�F�b�N���X�g
                bolRet = GET_SQL_�d�|�i�`�F�b�N���X�g(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR18 '�������͕\
                bolRet = GET_SQL_�������͕\(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR12 '�H���W�v�����\
                bolRet = GET_SQL_�H���W�v�����\(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR13 '�������z���͕\
                bolRet = GET_SQL_�������z���͕\(sSql, sColHeader, sRowHeader, sColHeader2)

            Case ps_rptid_GNKPR14 '�J����E�Ԑڔ�z�������\
                bolRet = GET_SQL_�J����Ԑڔ�z�������\(sSql, sColHeader, sRowHeader, sColHeader2)

            Case ps_rptid_GNKPR16 '�����U�փ��X�g
                bolRet = GET_SQL_�����U�փ��X�g(sSql, sColHeader, sRowHeader, sColHeader2)

            Case Else
                MsgBox("�w�肳�ꂽ���[�͑��݂��܂���B")
        End Select


        Get_Sql = bolRet

        Exit Function

ERR_END:
        '�G���[

        Exit Function
    End Function

    '==========================================================================
    '   �֐�:GET_SQL_���㌴���Ώƕ\_�o��������
    '   �T�v:���㌴���Ώە\�i�o��������j�i�S�Ёj�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_���㌴���Ώƕ\_�o��������(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_���㌴���Ώƕ\_�o�������� = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_GYO_DESC             || '"",""' || "
        sSql = sSql & "C_SALES_AMT            || '"",""' || "
        sSql = sSql & "C_SALES_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT           || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT_SUM       || '"",""' || "
        sSql = sSql & "C_SALES_CST            || '"",""' || "
        sSql = sSql & "C_SALES_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ADD_CST              || '"",""' || "
        sSql = sSql & "C_ADD_CST_SUM          || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL      || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL_SUM  || '"",""' || "
        sSql = sSql & "C_BAISA_AMT            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_BAISA_RATE           || '"",""' || "
        sSql = sSql & "C_BAISA_RATE_SUM       || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        '====< IT-0037 > ADD STR ====
        sSql = sSql & "   AND " & "C_GYO_SUB_NO = '1' "
        '====< IT-0037 > ADD END ====
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = ""


        '�s�w�b�_
        sColHeader = sColHeader & "�s����"","""
        sColHeader = sColHeader & "������z(����)"","""
        sColHeader = sColHeader & "������z(�݌v)"","""
        'sColHeader = sColHeader & "�d�،���(����)"","""
        'sColHeader = sColHeader & "�d�،���(�݌v)"","""
        sColHeader = sColHeader & "�v�挴��(����)"","""
        sColHeader = sColHeader & "�v�挴��(�݌v)"","""
        sColHeader = sColHeader & "���㎞����(����)"","""
        sColHeader = sColHeader & "���㎞����(�݌v)"","""
        sColHeader = sColHeader & "�ǉ�����(����)"","""
        sColHeader = sColHeader & "�ǉ�����(�݌v)"","""
        sColHeader = sColHeader & "���㌴���v(����)"","""
        sColHeader = sColHeader & "���㌴���v(�݌v)"","""
        sColHeader = sColHeader & "�����z(����)"","""
        sColHeader = sColHeader & "�����z(�݌v)"","""
        sColHeader = sColHeader & "������(����)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "������(�݌v)"","""
        sColHeader = sColHeader & "������(�݌v)"
        '2010/05/14 UPD END
        GET_SQL_���㌴���Ώƕ\_�o�������� = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   �֐�:GET_SQL_���㌴���Ώƕ\_�S��
    '   �T�v:���㌴���Ώە\�i�S�Ёj�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_���㌴���Ώƕ\_�S��(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_���㌴���Ώƕ\_�S�� = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_GYO_DESC             || '"",""' || "
        sSql = sSql & "C_SALES_AMT            || '"",""' || "
        sSql = sSql & "C_SALES_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT           || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT_SUM       || '"",""' || "
        sSql = sSql & "C_SALES_CST            || '"",""' || "
        sSql = sSql & "C_SALES_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ADD_CST              || '"",""' || "
        sSql = sSql & "C_ADD_CST_SUM          || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL      || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL_SUM  || '"",""' || "
        sSql = sSql & "C_BAISA_AMT            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_BAISA_RATE           || '"",""' || "
        sSql = sSql & "C_BAISA_RATE_SUM       || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        '====< IT-0037 > ADD STR ====
        sSql = sSql & "   AND " & "C_GYO_SUB_NO = '1' "
        '====< IT-0037 > ADD END ====
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01


        '��w�b�_
        sColHeader = ""


        '�s�w�b�_
        sColHeader = sColHeader & "�s����"","""
        sColHeader = sColHeader & "������z(����)"","""
        sColHeader = sColHeader & "������z(�݌v)"","""
        'sColHeader = sColHeader & "�d�،���(����)"","""
        'sColHeader = sColHeader & "�d�،���(�݌v)"","""
        sColHeader = sColHeader & "�v�挴��(����)"","""
        sColHeader = sColHeader & "�v�挴��(�݌v)"","""
        sColHeader = sColHeader & "���㎞����(����)"","""
        sColHeader = sColHeader & "���㎞����(�݌v)"","""
        sColHeader = sColHeader & "�ǉ�����(����)"","""
        sColHeader = sColHeader & "�ǉ�����(�݌v)"","""
        sColHeader = sColHeader & "���㌴���v(����)"","""
        sColHeader = sColHeader & "���㌴���v(�݌v)"","""
        sColHeader = sColHeader & "�����z(����)"","""
        sColHeader = sColHeader & "�����z(�݌v)"","""
        sColHeader = sColHeader & "������(����)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "������(�݌v)" & vbCrLf
        sColHeader = sColHeader & "������(�݌v)"
        '2010/05/14 UPD END

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_���㌴���Ώƕ\_�S�� = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   �֐�:GET_SQL_���㌴���Ώƕ\_�{����
    '   �T�v:���㌴���Ώە\�i���ƕ��j�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_���㌴���Ώƕ\_�{����(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_���㌴���Ώƕ\_�{���� = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_JIGYO_CD             || '"",""' || "
        sSql = sSql & "C_JIGYO_DESC           || '"",""' || "
        sSql = sSql & "C_GYO_DESC             || '"",""' || "
        sSql = sSql & "C_SALES_AMT            || '"",""' || "
        sSql = sSql & "C_SALES_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT           || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT_SUM       || '"",""' || "
        sSql = sSql & "C_SALES_CST            || '"",""' || "
        sSql = sSql & "C_SALES_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ADD_CST              || '"",""' || "
        sSql = sSql & "C_ADD_CST_SUM          || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL      || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL_SUM  || '"",""' || "
        sSql = sSql & "C_BAISA_AMT            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_BAISA_RATE           || '"",""' || "
        sSql = sSql & "C_BAISA_RATE_SUM       || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        sSql = sSql & "   AND " & "C_GYO_SUB_NO = '1' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = ""
        sColHeader = sColHeader & "���Ə��R�[�h"","""
        sColHeader = sColHeader & "���Ə�����"","""
        sColHeader = sColHeader & "�s����"","""
        sColHeader = sColHeader & "������z(����)"","""
        sColHeader = sColHeader & "������z(�݌v)"","""
        'sColHeader = sColHeader & "�d�،���(����)"","""
        'sColHeader = sColHeader & "�d�،���(�݌v)"","""
        sColHeader = sColHeader & "�v�挴��(����)"","""
        sColHeader = sColHeader & "�v�挴��(�݌v)"","""
        sColHeader = sColHeader & "���㎞����(����)"","""
        sColHeader = sColHeader & "���㎞����(�݌v)"","""
        sColHeader = sColHeader & "�ǉ�����(����)"","""
        sColHeader = sColHeader & "�ǉ�����(�݌v)"","""
        sColHeader = sColHeader & "���㌴���v(����)"","""
        sColHeader = sColHeader & "���㌴���v(�݌v)"","""
        sColHeader = sColHeader & "�����z(����)"","""
        sColHeader = sColHeader & "�����z(�݌v)"","""
        sColHeader = sColHeader & "������(����)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "������(�݌v)" & vbCrLf
        sColHeader = sColHeader & "������(�݌v)"
        '2010/05/14 UPD END

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_���㌴���Ώƕ\_�{���� = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   �֐�:GET_SQL_���㌴���Ώƕ\_������
    '   �T�v:���㌴���Ώە\�i�����ʁj�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_���㌴���Ώƕ\_������(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_���㌴���Ώƕ\_������ = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_GYO_DESC             || '"",""' || "
        sSql = sSql & "C_SALES_AMT            || '"",""' || "
        sSql = sSql & "C_SALES_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT           || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT_SUM       || '"",""' || "
        sSql = sSql & "C_SALES_CST            || '"",""' || "
        sSql = sSql & "C_SALES_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ADD_CST              || '"",""' || "
        sSql = sSql & "C_ADD_CST_SUM          || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL      || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL_SUM  || '"",""' || "
        sSql = sSql & "C_BAISA_AMT            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_BAISA_RATE           || '"",""' || "
        sSql = sSql & "C_BAISA_RATE_SUM       || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = sColHeader & "�s����"","""
        sColHeader = sColHeader & "������z(����)"","""
        sColHeader = sColHeader & "������z(�݌v)"","""
        'sColHeader = sColHeader & "�d�،���(����)"","""
        'sColHeader = sColHeader & "�d�،���(�݌v)"","""
        sColHeader = sColHeader & "�v�挴��(����)"","""
        sColHeader = sColHeader & "�v�挴��(�݌v)"","""
        sColHeader = sColHeader & "���㎞����(����)"","""
        sColHeader = sColHeader & "���㎞����(�݌v)"","""
        sColHeader = sColHeader & "�ǉ�����(����)"","""
        sColHeader = sColHeader & "�ǉ�����(�݌v)"","""
        sColHeader = sColHeader & "���㌴���v(����)"","""
        sColHeader = sColHeader & "���㌴���v(�݌v)"","""
        sColHeader = sColHeader & "�����z(����)"","""
        sColHeader = sColHeader & "�����z(�݌v)"","""
        sColHeader = sColHeader & "������(����)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "������(�݌v)"","""
        sColHeader = sColHeader & "������(�݌v)"
        '2010/05/14 UPD END

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_���㌴���Ώƕ\_������ = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   �֐�:GET_SQL_���㎞�������ו\
    '   �T�v:���㎞�������ו\�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '   2014/10/22      RS)�Ζ{     �V�X�e�������ɂ�荀�ڂ�ύX
    '
    '==========================================================================
    Private Function GET_SQL_���㎞�������ו\(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_���㎞�������ו\ = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = ""
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'|| '"",""' || "
        sSql = sSql & "C_CRT_DATE         || '"",""' || "
        sSql = sSql & "C_Y || '�N' || C_M || '���x ���㎞�������ו\ �y' || C_CO_DESC || '�z' || '"",""' || "
        sSql = sSql & "C_SEI_TAI_CLS      || '"",""' || "
        sSql = sSql & "C_SEI_TAI_DESC     || '"",""' || "
        '=== < ST-0152 > ADD STR
        sSql = sSql & "C_SINKO_FLG        || '"",""' || "
        '=== < ST-0152 > ADD END
        sSql = sSql & "C_SEIBAN           || '"",""' || "
        '<2014/10/22 UPD STR>
        sSql = sSql & "C_SEIBAN_DESC      || '"",""' || "
        sSql = sSql & "C_CUS_CD           || '"",""' || "
        'sSql = sSql + "C_NONYU_DESC       || '"",""' || "
        sSql = sSql & "C_CUS_DESC         || '"",""' || "
        sSql = sSql & "C_SALES_AMT        || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT     || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST        || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST      || '"",""' || "
        sSql = sSql & "C_TOTAL_CST        || '"",""' || "
        'sSql = sSql + "C_BAISA_RATE       || '"",""' || "
        sSql = sSql & "C_PLAN_BAISA_RATE  || '"",""' || "
        sSql = sSql & "C_JSK_BAISA_RATE   || '"",""' || "
        sSql = sSql & "C_GENKA_FLG        || '"" ' "
        'sSql = sSql + "C_BAISA_FLG        || '"" ' "
        '<2014/10/22 UPD END>
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = ""
        sColHeader = sColHeader & "���[ID"","""
        sColHeader = sColHeader & "�쐬��"","""
        sColHeader = sColHeader & "���[�^�C�g��"","""
        sColHeader = sColHeader & "���ԑ̌n�敪"","""
        sColHeader = sColHeader & "���ԑ̌n����"","""
        '=== < ST-0152 > ADD STR
        sColHeader = sColHeader & "�i�s��t���O"","""
        '=== < ST-0152 > ADD END
        sColHeader = sColHeader & "����"","""
        '<2014/10/22 UPD STR>
        sColHeader = sColHeader & "���Ԗ���"","""
        sColHeader = sColHeader & "���Ӑ�CD"","""
        sColHeader = sColHeader & "���Ӑ於"","""
        '*D*sColHeader = sColHeader & "�[���於"","""
        '< IT2-00XX > UPD STR
        '*D*sColHeader = sColHeader & "���Ӑ於��"","""
        'sColHeader = sColHeader & "�i��"","""
        '< IT2-00XX > UPD END
        sColHeader = sColHeader & "������z"","""
        '*D*sColHeader = sColHeader & "�d�،���"","""
        sColHeader = sColHeader & "�v�挴��"","""
        sColHeader = sColHeader & "�ޗ���"","""
        sColHeader = sColHeader & "�o��"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "�J����"","""
        sColHeader = sColHeader & "�J���E�Ԑڔ�"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "�U��"","""
        sColHeader = sColHeader & "���v"","""
        '*D*sColHeader = sColHeader & "����"","""
        sColHeader = sColHeader & "�v�攄��"","""
        sColHeader = sColHeader & "���є���"","""
        sColHeader = sColHeader & "�����c�t���O"
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "�����t���O"","""
        '*D*sColHeader = sColHeader & "�����t���O"
        '2010/05/14 UPD END
        '<2014/10/22 UPD END>

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_���㎞�������ו\ = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   �֐�:GET_SQL_�ǉ��������ו\
    '   �T�v:�ǉ��������ו\�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '   2014/10/21      RS)�Ζ{     �V�X�e�������ɂ�荀�ڂ�ύX
    '
    '==========================================================================
    Private Function GET_SQL_�ǉ��������ו\(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_�ǉ��������ו\ = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = ""
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'                                                    || '"",""' || "
        sSql = sSql & "C_CRT_DATE                                                             || '"",""' || "
        sSql = sSql & "C_Y || '�N' || C_M || '���x �ǉ��������ו\ �y' || C_CO_DESC || '�z'    || '"",""' || "
        sSql = sSql & "C_SEI_TAI_CLS                                                          || '"",""' || "
        sSql = sSql & "C_SEI_TAI_DESC                                                         || '"",""' || "
        sSql = sSql & "C_SEIBAN                                                               || '"",""' || "
        '<2014/10/21 ADD STR>
        sSql = sSql & "C_SEIBAN_DESC                                                          || '"",""' || "
        sSql = sSql & "C_CUS_CD                                                               || '"",""' || "
        sSql = sSql & "C_CUS_DESC                                                             || '"",""' || "
        'sSql = sSql + "C_NONYU_DESC                                                           || '"",""' || "
        'sSql = sSql + "C_CUS_DESC                                                             || '"",""' || "
        sSql = sSql & "C_SALES_AMT                                                            || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT                                                         || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST                                                           || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST_SUM                                                       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST                                                            || '"",""' || "
        sSql = sSql & "C_KEIHI_CST_SUM                                                        || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST                                                     || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST_SUM                                                 || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST                                                          || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST_SUM                                                      || '"",""' || "
        'sSql = sSql + "C_ADD_CST_TOU_TOTAL                                                    || '"",""' || "
        'sSql = sSql + "C_ADD_CST_RUI_TOTAL                                                    || '"",""' || "
        sSql = sSql & "C_ADD_CST_TOTAL                                                        || '"",""' || "
        sSql = sSql & "C_ADD_CST_TOTAL_SUM                                                    || '"",""' || "
        sSql = sSql & "C_SALES_CST                                                            || '"",""' || "
        sSql = sSql & "C_TOTAL_CST                                                            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT                                                            || '"",""' || "
        sSql = sSql & "C_BAISA_RATE                                                           || '"",""' || "
        sSql = sSql & "C_SALES_YM                                                             || '"",""' || "
        'sSql = sSql + "C_BAISA_RATE                                                           || '"",""' || "
        sSql = sSql & "C_BAISA_FLG                                                            || '"" ' "
        '<2014/10/21 ADD END>
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = ""
        sColHeader = sColHeader & "���[ID"","""
        sColHeader = sColHeader & "�쐬��"","""
        sColHeader = sColHeader & "���[�^�C�g��"","""
        sColHeader = sColHeader & "���ԑ̌n�敪"","""
        sColHeader = sColHeader & "���ԑ̌n����"","""
        sColHeader = sColHeader & "����"","""
        '<2014/10/21 ADD STR>
        sColHeader = sColHeader & "���Ԗ���"","""
        sColHeader = sColHeader & "���Ӑ�R�[�h"","""
        sColHeader = sColHeader & "���Ӑ於"","""
        'sColHeader = sColHeader & "�[���於"","""
        '< IT2-00XX > UPD STR
        '*D*sColHeader = sColHeader & "���Ӑ於��"","""
        'sColHeader = sColHeader & "�i��"","""
        '< IT2-00XX > UPD END
        sColHeader = sColHeader & "������z"","""
        sColHeader = sColHeader & "�v�挴��"","""
        sColHeader = sColHeader & "�ޗ���"","""
        sColHeader = sColHeader & "�ޗ���i�݌v�j"","""
        sColHeader = sColHeader & "�o��"","""
        sColHeader = sColHeader & "�o��i�݌v�j"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "�J����"","""
        sColHeader = sColHeader & "�J���E�Ԑڔ�"","""
        sColHeader = sColHeader & "�J���E�Ԑڔ�i�݌v�j"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "�U��"","""
        sColHeader = sColHeader & "�U�ցi�݌v�j"","""
        'sColHeader = sColHeader & "����"","""
        'sColHeader = sColHeader & "�݌v"","""
        sColHeader = sColHeader & "���������ǉ������v"","""
        sColHeader = sColHeader & "�ǉ������݌v"","""
        sColHeader = sColHeader & "���㎞�������z"","""
        sColHeader = sColHeader & "�������v"","""
        sColHeader = sColHeader & "�������z"","""
        'sColHeader = sColHeader & "����N��"","""
        'sColHeader = sColHeader & "����"","""
        sColHeader = sColHeader & "������"","""
        sColHeader = sColHeader & "����N��"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "�����t���O"","""
        sColHeader = sColHeader & "�����t���O"
        '2010/05/14 UPD END
        '<2014/10/21 ADD END>

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�ǉ��������ו\ = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   �֐�:GET_SQL_�d�|�i���ו\
    '   �T�v:�d�|�i���ו\�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '   2014/10/21      RS)�Ζ{     �V�X�e�������ɂ�荀�ڂ�ύX
    '
    '==========================================================================
    Private Function GET_SQL_�d�|�i���ו\(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_�d�|�i���ו\ = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "' || '"",""' || "
        sSql = sSql & "C_CRT_DATE         || '"",""' || "
        sSql = sSql & "C_Y || '�N' || C_M || '���x �d�|�i���ו\ �y' || C_CO_DESC || '�z' || '"",""' || "
        sSql = sSql & "C_SEI_TAI_CLS      || '"",""' || "
        sSql = sSql & "C_SEI_TAI_DESC     || '"",""' || "
        '=== < ST-0152 > UPD STR
        sSql = sSql & "C_SINKO_FLG        || '"",""' || "
        sSql = sSql & "C_SEIBAN           || '"",""' || "
        '<2014/10/21 ADD STR>
        sSql = sSql & "C_SEIBAN_DESC      || '"",""' || "
        sSql = sSql & "C_CUS_CD           || '"",""' || "
        '=== < ST-0152 > UPD END
        '*D* sSql = sSql & " C_SEIBAN "
        'sSql = sSql & "C_NONYU_DESC       || '"",""' || "
        sSql = sSql & "C_CUS_DESC         || '"",""' || "
        sSql = sSql & "C_KEIYAKU_AMT      || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT     || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST       || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST_SUM   || '"",""' || "
        sSql = sSql & "C_KEIHI_CST        || '"",""' || "
        sSql = sSql & "C_KEIHI_CST_SUM    || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST_SUM || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST      || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST_SUM  || '"",""' || "
        sSql = sSql & "C_TOTAL_CST        || '"",""' || "
        sSql = sSql & "C_TOTAL_CST_SUM    || '"",""' || "
        sSql = sSql & "C_NOUKI_DATE       || '"" ' "
        'sSql = sSql & "C_DEL_FLG          || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = ""
        sColHeader = sColHeader & "���[ID"","""
        sColHeader = sColHeader & "�쐬��"","""
        sColHeader = sColHeader & "���[�^�C�g��"","""
        sColHeader = sColHeader & "���ԑ̌n�敪"","""
        sColHeader = sColHeader & "���ԑ̌n����"","""
        '=== < ST-0152 > ADD STR
        sColHeader = sColHeader & "�i�s��t���O"","""
        '=== < ST-0152 > ADD END
        sColHeader = sColHeader & "����"","""
        '<2014/10/21 CHG STR>
        sColHeader = sColHeader & "���Ԗ���"","""
        sColHeader = sColHeader & "���Ӑ�R�[�h"","""
        sColHeader = sColHeader & "���Ӑ於"","""
        'sColHeader = sColHeader & "�[���於"","""
        '< IT2-00XX > UPD STR
        '*D*sColHeader = sColHeader & "���Ӑ於��"","""
        'sColHeader = sColHeader & "�i��"","""
        '< IT2-00XX > UPD END
        sColHeader = sColHeader & "�󒍋��z"","""
        sColHeader = sColHeader & "�d�؋��z"","""
        sColHeader = sColHeader & "�ޗ���"","""
        sColHeader = sColHeader & "�ޗ���i�݌v�j"","""
        sColHeader = sColHeader & "�o��"","""
        sColHeader = sColHeader & "�o��i�݌v�j"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "�J����"","""
        sColHeader = sColHeader & "�J���E�Ԑڔ�"","""
        sColHeader = sColHeader & "�J���E�Ԑڔ�i�݌v�j"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "�U��"","""
        sColHeader = sColHeader & "�U�ցi�݌v�j"","""
        sColHeader = sColHeader & "���v"","""
        sColHeader = sColHeader & "���v�i�݌v�j"","""
        sColHeader = sColHeader & "�[��"
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "����t���O" & vbCrLf
        'sColHeader = sColHeader & "����t���O"
        '2010/05/14 UPD END
        '<2014/10/21 CHG END>

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�d�|�i���ו\ = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   �֐�:GET_SQL_������������
    '   �T�v:�������������̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '   2014/10/22      RS)�Ζ{     �V�X�e�������ɂ�荀�ڂ�ύX
    '
    '==========================================================================
    Private Function GET_SQL_������������(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_������������ = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'                                               || '"",""' || "
        '<2015/01/09 UPD STR>
        sSql = sSql & "C_SEQ_10                                                          || '"",""' || "
        '<2015/01/09 UPD STR>
        sSql = sSql & "C_CRT_DATE                                                        || '"",""' || "
        sSql = sSql & "C_Y || '�N' || C_M || '���x ������������ �y' || C_CO_DESC || '�z' || '"",""' || "
        sSql = sSql & "C_SEI_TAI_CLS                                                     || '"",""' || "
        sSql = sSql & "C_SEI_TAI_DESC                                                    || '"",""' || "
        sSql = sSql & "C_SEIBAN                                                          || '"",""' || "
        '<2014/10/22 UPD STR>
        sSql = sSql & "C_SEIBAN_DESC                                                     || '"",""' || "
        sSql = sSql & "C_COMMENT20        �@                                             || '"",""' || "
        'sSql = sSql + "C_NONYU_DESC                                                      || '"",""' || "
        'sSql = sSql + "C_ITEM_DESC                                                       || '"",""' || "
        '<2014/10/22 UPD END>
        sSql = sSql & "C_DEL                                                             || '"",""' || "
        sSql = sSql & "C_URI_KAN                                                         || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT                                                    || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST                                                      || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST_SUM                                                  || '"",""' || "
        sSql = sSql & "C_KEIHI_CST                                                       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST_SUM                                                   || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST                                                || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST_SUM                                            || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST                                                     || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST_SUM                                                 || '"",""' || "
        sSql = sSql & "C_TOTAL_CST                                                       || '"",""' || "
        sSql = sSql & "C_TOTAL_CST_SUM                                                   || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        '<2015/01/09 UPD STR>
        sSql = sSql & " Order By C_SEI_TAI_CLS,C_SEIBAN,C_SEQ_10"
        '<2015/01/09 UPD END>


        '��w�b�_
        sColHeader = ""
        sColHeader = sColHeader & "���[ID"","""
        sColHeader = sColHeader & "SEQ"","""
        sColHeader = sColHeader & "�쐬��"","""
        sColHeader = sColHeader & "���[�^�C�g��"","""
        sColHeader = sColHeader & "���ԑ̌n�敪"","""
        sColHeader = sColHeader & "���ԑ̌n����"","""
        sColHeader = sColHeader & "����"","""
        '<2014/10/22 UPD STR>
        sColHeader = sColHeader & "���Ԗ���"","""
        sColHeader = sColHeader & "���l"","""
        'sColHeader = sColHeader & "�[���於"","""
        'sColHeader = sColHeader & "�i��"","""
        sColHeader = sColHeader & "�[��"","""
        '*D*sColHeader = sColHeader & "����E����"","""
        sColHeader = sColHeader & "�����E����"","""
        '<2014/10/22 UPD END>
        '==== < ST-0134 > UPD STR =====
        '*D*sColHeader = sColHeader & "�_����z"","""
        '=== < �����Ή� > 2015/03/25 UPD STR ===
        '*D*sColHeader = sColHeader & "�d�؁E�\��"","""
        sColHeader = sColHeader & "�\�茴��(�W�����i)"","""
        '=== < �����Ή� > 2015/03/25 UPD END ===
        '==== < ST-0134 > UPD END =====
        sColHeader = sColHeader & "�ޗ���(����)"","""
        sColHeader = sColHeader & "�ޗ���(�݌v)"","""
        sColHeader = sColHeader & "�o��(����)"","""
        sColHeader = sColHeader & "�o��(�݌v)"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "�J����"","""
        '*D* sColHeader = sColHeader & "�J����(�݌v)"","""
        sColHeader = sColHeader & "�J���E�Ԑڔ�"","""
        sColHeader = sColHeader & "�J���E�Ԑڔ�(�݌v)"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "�U��(����)"","""
        sColHeader = sColHeader & "�U��(�݌v)"","""
        sColHeader = sColHeader & "���v(����)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "���v(�݌v)" & vbCrLf
        sColHeader = sColHeader & "���v(�݌v)"
        '2010/05/14 UPD END

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_������������ = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   �֐�:GET_SQL_�����i����
    '   �T�v:�����i�����̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '   2014/10/22      RS)�Ζ{     �V�X�e�������ɂ�荀�ڂ�ύX
    '
    '==========================================================================
    Private Function GET_SQL_�����i����(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_�����i���� = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'    || '"",""' || "
        sSql = sSql & "C_CRT_DATE        || '"",""' || "
        sSql = sSql & "C_Y || '�N' || C_M || '���x �����i���� �y' || C_CO_DESC || '�z' || '"",""' || "
        '<2014/10/22 ADD STR>
        sSql = sSql & "C_SEIHIN               || '"",""' || "
        sSql = sSql & "C_SEIBAN               || '"",""' || "
        sSql = sSql & "C_ITEM_CD              || '"",""' || "
        sSql = sSql & "C_ITEM_DESC            || '"",""' || "
        sSql = sSql & "C_COM_DATE             || '"",""' || "
        sSql = sSql & "C_DEL                  || '"",""' || "
        sSql = sSql & "C_COM_QTY              || '"",""' || "
        '<2014/10/22 ADD END>
        sSql = sSql & "C_PO_QTY               || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST           || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST_SUM       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST            || '"",""' || "
        sSql = sSql & "C_KEIHI_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST     || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST_SUM || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST          || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST_SUM      || '"",""' || "
        sSql = sSql & "C_TOTAL_CST            || '"",""' || "
        sSql = sSql & "C_TOTAL_CST_SUM        || '"",""' || "
        sSql = sSql & "C_NYUKO_QTY            || '"",""' || "
        sSql = sSql & "C_NYUKO_QTY_SUM        || '"",""' || "
        sSql = sSql & "C_NYUKO_AMT            || '"",""' || "
        sSql = sSql & "C_NYUKO_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_WIP_QTY              || '"",""' || "
        sSql = sSql & "C_WIP_AMT              || '"",""' || "
        sSql = sSql & "C_SAGAKU_SONEKI_AMT    || '"",""' || "
        sSql = sSql & "C_SONEKI_RATE          || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = ""
        sColHeader = sColHeader & "���[ID"","""
        sColHeader = sColHeader & "�쐬��"","""
        sColHeader = sColHeader & "���[�^�C�g��"","""
        '<2014/10/22 ADD STR>
        sColHeader = sColHeader & "���i�敪"","""
        sColHeader = sColHeader & "����"","""
        sColHeader = sColHeader & "�i��"","""
        sColHeader = sColHeader & "�i��"","""
        sColHeader = sColHeader & "����"","""
        sColHeader = sColHeader & "�[��"","""
        sColHeader = sColHeader & "������"","""
        '<2014/10/22 ADD END>
        sColHeader = sColHeader & "��z��"","""
        sColHeader = sColHeader & "�ޗ���"","""
        sColHeader = sColHeader & "�ޗ���(�݌v)"","""
        sColHeader = sColHeader & "�o��"","""
        sColHeader = sColHeader & "�o��(�݌v)"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "�J����"","""
        '*D* sColHeader = sColHeader & "�J����(�݌v)"","""
        sColHeader = sColHeader & "�J���E�Ԑڔ�"","""
        sColHeader = sColHeader & "�J���E�Ԑڔ�(�݌v)"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "�U��"","""
        sColHeader = sColHeader & "�U��(�݌v)"","""
        sColHeader = sColHeader & "�����v"","""
        sColHeader = sColHeader & "�����v(�݌v)"","""
        sColHeader = sColHeader & "���ɐ�"","""
        sColHeader = sColHeader & "���ɐ�(�݌v)"","""
        sColHeader = sColHeader & "���ɋ��z"","""
        sColHeader = sColHeader & "���ɋ��z(�݌v)"","""
        sColHeader = sColHeader & "�d�|��"","""
        sColHeader = sColHeader & "�d�|���z"","""
        sColHeader = sColHeader & "���z���v"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "���v��" & vbCrLf
        sColHeader = sColHeader & "���v��"
        '2010/05/14 UPD END

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�����i���� = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   �֐�:GET_SQL_�I�D
    '   �T�v:�I�D�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_�I�D(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_�I�D = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = ""


        '��w�b�_
        sColHeader = ""


        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�I�D = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   �֐�:GET_SQL_�d�|�i�`�F�b�N���X�g
    '   �T�v:�d�|�i�`�F�b�N���X�g�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2014/10/22      RS)�Ζ{     �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_�d�|�i�`�F�b�N���X�g(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_�d�|�i�`�F�b�N���X�g = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "' || '"",""' || "
        sSql = sSql & "C_CRT_DATE         || '"",""' || "
        sSql = sSql & "C_Y || '�N' || C_M || '���x �d�|�i�`�F�b�N���X�g �y' || C_CO_DESC || '�z' || '"",""' || "
        sSql = sSql & "C_SHU_KOJYO_CLS    || '"",""' || "
        sSql = sSql & "C_SHU_KOJYO_DESC   || '"",""' || "
        sSql = sSql & "C_LISTTYPE_CD      || '"",""' || "
        sSql = sSql & "C_LISTTYPE         || '"",""' || "
        sSql = sSql & "C_SEIBAN           || '"",""' || "
        sSql = sSql & "C_SEIBAN_DESC      || '"",""' || "
        sSql = sSql & "C_DEL_DEST_DESC    || '"",""' || "
        sSql = sSql & "C_KEIYAKU_AMT      || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT     || '"",""' || "
        sSql = sSql & "C_CANSEL_DATE      || '"",""' || "
        sSql = sSql & "C_DEL              || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST        || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST      || '"",""' || "
        sSql = sSql & "C_TOTAL_CST        || '"",""' || "
        sSql = sSql & "C_CST_ST_DATE      || '"",""' || "
        sSql = sSql & "C_CST_END_DATE     || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = ""
        sColHeader = sColHeader & "���[ID"","""
        sColHeader = sColHeader & "�쐬��"","""
        sColHeader = sColHeader & "���[�^�C�g��"","""
        sColHeader = sColHeader & "���ƕ��R�[�h"","""
        sColHeader = sColHeader & "���ƕ�����"","""
        sColHeader = sColHeader & "��ʃR�[�h"","""
        sColHeader = sColHeader & "���"","""
        sColHeader = sColHeader & "����"","""
        sColHeader = sColHeader & "���Ԗ�"","""
        sColHeader = sColHeader & "���Ӑ於"","""
        '=== < �����Ή� > 2015/03/25 UPD STR ===
        '*D*sColHeader = sColHeader & "�_����z"","""
        sColHeader = sColHeader & "�󒍋��z"","""
        '=== < �����Ή� > 2015/03/25 UPD END ===
        sColHeader = sColHeader & "�v�挴��"","""
        sColHeader = sColHeader & "�����"","""
        sColHeader = sColHeader & "�[��"","""
        sColHeader = sColHeader & "���ڍޗ���"","""
        sColHeader = sColHeader & "���ڌo��"","""
        sColHeader = sColHeader & "�J����E�Ԑڔ�"","""
        sColHeader = sColHeader & "�U��"","""
        sColHeader = sColHeader & "�������v"","""
        sColHeader = sColHeader & "���������J�n�N��"","""
        sColHeader = sColHeader & "���������ŏI�N��"

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�d�|�i�`�F�b�N���X�g = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   �֐�:GET_SQL_�������͕\
    '   �T�v:�������͕\�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_�������͕\(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_�������͕\ = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = ""
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_PLANT_NO                 || '"",""' || "
        sSql = sSql & "C_SO_NO                    || '"",""' || "
        sSql = sSql & "C_NONYUSAKI_DESC           || '"",""' || "
        sSql = sSql & "C_ITEM_DESC                || '"",""' || "
        sSql = sSql & "C_SO_DATE                  || '"",""' || "
        sSql = sSql & "C_MODEL                    || '"",""' || "
        sSql = sSql & "C_MODEL_BUNRUI             || '"",""' || "
        sSql = sSql & "C_SALES_DATE               || '"",""' || "
        sSql = sSql & "C_TAN_DESC                 || '"",""' || "
        sSql = sSql & "C_SEISAN_TAN_DESC          || '"",""' || "
        sSql = sSql & "C_HD_KEIYAKU_AMT           || '"",""' || "
        sSql = sSql & "C_SF_KEIYAKU_AMT           || '"",""' || "
        sSql = sSql & "C_KEI_KEIYAKU_AMT          || '"",""' || "
        sSql = sSql & "C_HD_KEI_SIK_CST           || '"",""' || "
        sSql = sSql & "C_SF_KEI_SIK_CST           || '"",""' || "
        sSql = sSql & "C_KEI_SIK_CST              || '"",""' || "
        sSql = sSql & "C_HD_KEI_MOKUHYOU_CST      || '"",""' || "
        sSql = sSql & "C_SF_KEI_MOKUHYOU_CST      || '"",""' || "
        sSql = sSql & "C_KEI_MOKUHYOU_CST         || '"",""' || "
        sSql = sSql & "C_HD_KEI_JISS_CST          || '"",""' || "
        sSql = sSql & "C_SF_KEI_JISS_CST          || '"",""' || "
        sSql = sSql & "C_KEI_JISS_CST             || '"",""' || "
        sSql = sSql & "C_HD_SIK_CST_RATE          || '"",""' || "
        sSql = sSql & "C_SF_SIK_CST_RATE          || '"",""' || "
        sSql = sSql & "C_KEI_SIK_CST_RATE         || '"",""' || "
        sSql = sSql & "C_HD_MOKUHYOU_CST_RATE     || '"",""' || "
        sSql = sSql & "C_SF_MOKUHYOU_CST_RATE     || '"",""' || "
        sSql = sSql & "C_KEI_MOKUHYOU_CST_RATE    || '"",""' || "
        sSql = sSql & "C_HD_KEI_JISS_CST_RATE     || '"",""' || "
        sSql = sSql & "C_SF_KEI_JISS_CST_RATE     || '"",""' || "
        sSql = sSql & "C_KEI_JISS_CST_RATE        || '"",""' || "
        sSql = sSql & "C_HD_SEK_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_HD_SEK_NAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEK_GAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEK_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEK_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_HD_SEK_NAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEK_GAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEK_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_HD_SEZ_NAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEZ_GAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_HD_SEZ_NAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEZ_GAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_KENSA_SIK_CST         || '"",""' || "
        sSql = sSql & "C_HD_KENSA_JISS_CST        || '"",""' || "
        sSql = sSql & "C_HD_KENSA_CST_RATE        || '"",""' || "
        sSql = sSql & "C_HD_KENSA_KOSEI_RATE      || '"",""' || "
        sSql = sSql & "C_HD_KOUNYU_SIK_CST        || '"",""' || "
        sSql = sSql & "C_HD_KOUNYU_JISS_CST       || '"",""' || "
        sSql = sSql & "C_HD_KOUNYU_CST_RATE       || '"",""' || "
        sSql = sSql & "C_HD_KOUNYU_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_HD_SEQ_SIK_CST           || '"",""' || "
        sSql = sSql & "C_HD_SEQ_JISS_CST          || '"",""' || "
        sSql = sSql & "C_HD_SEQ_CST_RATE          || '"",""' || "
        sSql = sSql & "C_HD_SEQ_KOSEI_RATE        || '"",""' || "
        sSql = sSql & "C_HD_HANNYU_SIK_CST        || '"",""' || "
        sSql = sSql & "C_HD_HANNYU_JISS_CST       || '"",""' || "
        sSql = sSql & "C_HD_HANNYU_CST_RATE       || '"",""' || "
        sSql = sSql & "C_HD_HANNYU_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_SIK_CST         || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_JISS_CST        || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_CST_RATE        || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_KOSEI_RATE      || '"",""' || "
        sSql = sSql & "C_HD_COMPUTER_SIK_CST      || '"",""' || "
        sSql = sSql & "C_HD_COMPUTER_JISS_CST     || '"",""' || "
        sSql = sSql & "C_HD_COMPUTER_CST_RATE     || '"",""' || "
        sSql = sSql & "C_HD_COMPUTER_KOSEI_RATE   || '"",""' || "
        sSql = sSql & "C_HD_KEIHI_SIK_CST         || '"",""' || "
        sSql = sSql & "C_HD_KEIHI_JISS_CST        || '"",""' || "
        sSql = sSql & "C_HD_KEIHI_CST_RATE        || '"",""' || "
        sSql = sSql & "C_HD_KEIHI_KOSEI_RATE      || '"",""' || "
        sSql = sSql & "C_HD_FURIKAE_SIK_CST       || '"",""' || "
        sSql = sSql & "C_HD_FURIKAE_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_FURIKAE_CST_RATE      || '"",""' || "
        sSql = sSql & "C_HD_FURIKAE_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_MEI_HD_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_MEI_HD_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_MEI_HD_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_MEI_HD_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KEI_SIK_CST     || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_NAI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_GAI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KEI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KEI_CST_RATE    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_NAI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_GAI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KEI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KEI_SIK_CST     || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_NAI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_GAI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KEI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KEI_CST_RATE    || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_NAI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_GAI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KEI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_PG_KEI_SIK_CST        || '"",""' || "
        sSql = sSql & "C_SF_PG_NAI_JISS_CST       || '"",""' || "
        sSql = sSql & "C_SF_PG_GAI_JISS_CST       || '"",""' || "
        sSql = sSql & "C_SF_PG_KEI_JISS_CST       || '"",""' || "
        sSql = sSql & "C_SF_PG_KEI_CST_RATE       || '"",""' || "
        sSql = sSql & "C_SF_PG_NAI_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_SF_PG_GAI_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_SF_PG_KEI_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_SF_TYS_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_SF_TYS_NAI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_SF_TYS_GAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_SF_TYS_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_SF_TYS_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_SF_TYS_NAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_SF_TYS_GAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_SF_TYS_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_SF_TYSKE_SIK_CST         || '"",""' || "
        sSql = sSql & "C_SF_TYSKE_JISS_CST        || '"",""' || "
        sSql = sSql & "C_SF_TYSKE_CST_RATE        || '"",""' || "
        sSql = sSql & "C_SF_TYSKE_KOSEI_RATE      || '"",""' || "
        sSql = sSql & "C_SF_SYOK_SIK_CST          || '"",""' || "
        sSql = sSql & "C_SF_SYOK_JISS_CST         || '"",""' || "
        sSql = sSql & "C_SF_SYOK_CST_RATE         || '"",""' || "
        sSql = sSql & "C_SF_SYOK_KOSEI_RATE       || '"",""' || "
        sSql = sSql & "C_MEI_SF_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_MEI_SF_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_MEI_SF_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_MEI_SF_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_MEI_KEI_SIK_CST          || '"",""' || "
        sSql = sSql & "C_MEI_KEI_JISS_CST         || '"",""' || "
        sSql = sSql & "C_MEI_KEI_CST_RATE         || '"",""' || "
        sSql = sSql & "C_HD_SEK_KOS_QTY           || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KOS_QTY           || '"",""' || "
        sSql = sSql & "C_HD_KENSA_KOS_QTY         || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_KOS_QTY         || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KOS_QTY         || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KOS_QTY         || '"",""' || "
        sSql = sSql & "C_SF_PG_KOS_QTY            || '"",""' || "
        sSql = sSql & "C_SF_TYS_KOS_QTY           || '"",""' || "
        sSql = sSql & "C_SF_HOKA_KOS_QTY          || '"",""' || "
        sSql = sSql & "C_SF_HOKA_KOS_QTY          || '"",""' || "
        sSql = sSql & "C_SOU_PGM_QTY              || '"",""' || "
        sSql = sSql & "C_PGM_UP                   || '"",""' || "
        sSql = sSql & "C_SOU_STEP_QTY             || '"",""' || "
        sSql = sSql & "C_STEP_UP                  || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'UPD 20160603 START C2-20160603-01
        '        sSql = sSql & "Order By C_SO_NO"
        sSql = sSql & "Order By C_SO_NO, C_SEQ_10 "
        'UPD 20160603  END  C2-20160603-01


        '��w�b�_
        sColHeader = sColHeader & "�v�����gNo"","""
        sColHeader = sColHeader & "��No"","""
        sColHeader = sColHeader & "�[���於"","""
        sColHeader = sColHeader & "�i��"","""
        sColHeader = sColHeader & "�󒍓�"","""
        sColHeader = sColHeader & "�^��"","""
        sColHeader = sColHeader & "����"","""
        sColHeader = sColHeader & "�����"","""
        sColHeader = sColHeader & "�S����"","""
        sColHeader = sColHeader & "���Y�S����"","""
        sColHeader = sColHeader & "�_����z�E�n�[�h"","""
        sColHeader = sColHeader & "�_����z�E�\�t�g"","""
        sColHeader = sColHeader & "�_����z�E�v"","""
        sColHeader = sColHeader & "�d�،����v�E�n�[�h"","""
        sColHeader = sColHeader & "�d�،����v�E�\�t�g"","""
        sColHeader = sColHeader & "�d�،����v"","""
        sColHeader = sColHeader & "�ڕW�����v�E�n�[�h"","""
        sColHeader = sColHeader & "�ڕW�����v�E�\�t�g"","""
        sColHeader = sColHeader & "�ڕW�����v"","""
        sColHeader = sColHeader & "���ь����v�E�n�[�h"","""
        sColHeader = sColHeader & "���ь����v�E�\�t�g"","""
        sColHeader = sColHeader & "���ь����v"","""
        sColHeader = sColHeader & "�d�،������E�n�[�h"","""
        sColHeader = sColHeader & "�d�،������E�\�t�g"","""
        sColHeader = sColHeader & "�d�،������E�v"","""
        sColHeader = sColHeader & "�ڕW�������E�n�[�h"","""
        sColHeader = sColHeader & "�ڕW�������E�\�t�g"","""
        sColHeader = sColHeader & "�ڕW�������E�v"","""
        sColHeader = sColHeader & "���ь������E�n�[�h"","""
        sColHeader = sColHeader & "���ь������E�\�t�g"","""
        sColHeader = sColHeader & "���ь������E�v"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�݌v�E�v"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�݌v�E�Г�"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�݌v�E�O��"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�݌v�E�v"","""
        sColHeader = sColHeader & "�������E�n�[�h�E�݌v�E�v"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�݌v�E�Г�"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�݌v�E�O��"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�݌v�E�v"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�����E�v"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�����E�Г�"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�����E�O��"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�����E�v"","""
        sColHeader = sColHeader & "�������E�n�[�h�E�����E�v"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�����E�Г�"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�����E�O��"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�����E�v"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E����"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E����"","""
        sColHeader = sColHeader & "�������E�n�[�h�E����"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E����"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�w���@��"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�w���@��"","""
        sColHeader = sColHeader & "�������E�n�[�h�E�w���@��"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�w���@��"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�V�[�P���T�["","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�V�[�P���T�["","""
        sColHeader = sColHeader & "�������E�n�[�h�E�V�[�P���T�["","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�V�[�P���T�["","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�����^��"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�����^��"","""
        sColHeader = sColHeader & "�������E�n�[�h�E�����^��"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�����^��"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�H�����t"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�H�����t"","""
        sColHeader = sColHeader & "�������E�n�[�h�E�H�����t"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�H�����t"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�v�Z�@"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�v�Z�@"","""
        sColHeader = sColHeader & "�������E�n�[�h�E�v�Z�@"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�v�Z�@"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�o��"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�o��"","""
        sColHeader = sColHeader & "�������E�n�[�h�E�o��"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�o��"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�U��"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�U��"","""
        sColHeader = sColHeader & "�������E�n�[�h�E�U��"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�U��"","""
        sColHeader = sColHeader & "�d�،����E�n�[�h�E�v"","""
        sColHeader = sColHeader & "���ь����E�n�[�h�E�v"","""
        sColHeader = sColHeader & "�������E�n�[�h�E�v"","""
        sColHeader = sColHeader & "�\����E�n�[�h�E�v"","""
        sColHeader = sColHeader & "�d�،����E�\�t�g�E�V�X�e���݌v�E�v"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E�V�X�e���݌v�E�Г�"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E�V�X�e���݌v�E�O��"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E�V�X�e���݌v�E�v"","""
        sColHeader = sColHeader & "�������E�\�t�g�E�V�X�e���݌v�E�v"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E�V�X�e���݌v�E�Г�"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E�V�X�e���݌v�E�O��"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E�V�X�e���݌v�E�v"","""
        sColHeader = sColHeader & "�d�،����E�\�t�g�E��{�݌v�E�v"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E��{�݌v�E�Г�"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E��{�݌v�E�O��"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E��{�݌v�E�v"","""
        sColHeader = sColHeader & "�������E�\�t�g�E��{�݌v�E�v"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E��{�݌v�E�Г�"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E��{�݌v�E�O��"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E��{�݌v�E�v"","""
        sColHeader = sColHeader & "�d�،����E�\�t�g�E�v���O�����E�v"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E�v���O�����E�Г�"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E�v���O�����E�O��"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E�v���O�����E�v"","""
        sColHeader = sColHeader & "�������E�\�t�g�E�v���O�����E�v"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E�v���O�����E�Г�"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E�v���O�����E�O��"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E�v���O�����E�v"","""
        sColHeader = sColHeader & "�d�،����E�\�t�g�E���n�����E�v"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E���n�����E�Г�"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E���n�����E�O��"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E���n�����E�v"","""
        sColHeader = sColHeader & "�������E�\�t�g�E���n�����E�v"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E���n�����E�Г�"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E���n�����E�O��"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E���n�����E�v"","""
        sColHeader = sColHeader & "�d�،����E�\�t�g�E���n�����o��"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E���n�����o��"","""
        sColHeader = sColHeader & "�������E�\�t�g�E���n�����o��"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E���n�����o��"","""
        sColHeader = sColHeader & "�d�،����E�\�t�g�E���̑����o��"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E���̑����o��"","""
        sColHeader = sColHeader & "�������E�\�t�g�E���̑����o��"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E���̑����o��"","""
        sColHeader = sColHeader & "�d�،����E�\�t�g�E�v"","""
        sColHeader = sColHeader & "���ь����E�\�t�g�E�v"","""
        sColHeader = sColHeader & "�������E�\�t�g�E�v"","""
        sColHeader = sColHeader & "�\����E�\�t�g�E�v"","""
        sColHeader = sColHeader & "�d�،����E���v"","""
        sColHeader = sColHeader & "���ь����E���v"","""
        sColHeader = sColHeader & "�������E���v"","""
        sColHeader = sColHeader & "�H������E�n�[�h�E�݌v"","""
        sColHeader = sColHeader & "�H������E�n�[�h�E����"","""
        sColHeader = sColHeader & "�H������E�n�[�h�E����"","""
        sColHeader = sColHeader & "�H������E�n�[�h�E�H�����t"","""
        sColHeader = sColHeader & "�H������E�\�t�g�E�V�X�e���݌v"","""
        sColHeader = sColHeader & "�H������E�\�t�g�E��{�݌v"","""
        sColHeader = sColHeader & "�H������E�\�t�g�E�v���O����"","""
        sColHeader = sColHeader & "�H������E�\�t�g�E���n����"","""
        sColHeader = sColHeader & "�H������E�\�t�g�E���̑�"","""
        sColHeader = sColHeader & "�H������E���v"","""
        sColHeader = sColHeader & "�o�f���{��"","""
        sColHeader = sColHeader & "�o�f�P�{����P��"","""
        sColHeader = sColHeader & "���X�e�b�v��"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "�X�e�b�v����P��"","""
        sColHeader = sColHeader & "�X�e�b�v����P��"
        '2010/05/14 UPD END

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�������͕\ = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   �֐�:GET_SQL_�H���W�v�����\
    '   �T�v:�H���W�v�����\�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_�H���W�v�����\(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_�H���W�v�����\ = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = ""


        '��w�b�_
        sColHeader = ""


        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�H���W�v�����\ = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   �֐�:GET_SQL_�������z���͕\
    '   �T�v:�������z���͕\�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2009/12/18      ���        �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_�������z���͕\(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String, ByRef sColHeader2 As String) As Boolean


        GET_SQL_�������z���͕\ = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & " C_BMN_CD                || '"",""' || "
        sSql = sSql & " C_MEI2                  || '"",""' || "

        sSql = sSql & " C_YUKO_TIME                     || '"",""' || "
        sSql = sSql & " C_MUKO_TIME                     || '"",""' || "
        sSql = sSql & " C_TOTAL_TIME                    || '"",""' || "
        sSql = sSql & " C_YUKO_TIME_RITU                || '"",""' || "
        sSql = sSql & " C_SOGYODO                       || '"",""' || "
        sSql = sSql & " C_YOTEI_HAI_TAN                 || '"",""' || "
        sSql = sSql & " C_TYOKU_YOTEI_AMT               || '"",""' || "
        sSql = sSql & " C_TYOKU_JISS_ROUMU_AMT          || '"",""' || "
        sSql = sSql & " C_TYOKU_TIME_FURIKAE            || '"",""' || "
        sSql = sSql & " C_TYOKU_KOUSU_HOJYO_BMN_AMT     || '"",""' || "
        sSql = sSql & " C_TYOKU_TOTAL_AMT               || '"",""' || "
        sSql = sSql & " C_TYOKU_SAGAKU_AMT              || '"",""' || "
        sSql = sSql & " C_KAN_YOTEI_HAI_AMT             || '"",""' || "
        sSql = sSql & " C_KAN_JISS_ROUMU_AMT            || '"",""' || "
        sSql = sSql & " C_KAN_KEI_AMT                   || '"",""' || "
        sSql = sSql & " C_KAN_BMN_AMT                   || '"",""' || "
        sSql = sSql & " C_KAN_TOTAL_AMT                 || '"",""' || "
        sSql = sSql & " C_KAN_SAGAKU_AMT                || '"",""' || "
        sSql = sSql & " C_SAGAKU_KEI_CST                || '"",""' || "
        sSql = sSql & " C_JISS_RATE                     || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        sSql = sSql & "ORDER BY C_PAGE_INS "
        sSql = sSql & " , C_SYUKEI_1 "
        sSql = sSql & " , C_SYUKEI_2 "
        sSql = sSql & " , C_SYUKEI_3 "
        sSql = sSql & " , C_UPDOWN "

        '��w�b�_
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & "�J����E�Ԑڔ�\��z��"","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & "�Ԑڔ�\��z���z"","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & "�Ԑڔ����"","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "

        sColHeader = sColHeader & "���喼"","""
        sColHeader = sColHeader & " "","""
        '2015/01/09 DEL STR
        'sColHeader = sColHeader & " "","""
        '2015/01/09 DEL END

        sColHeader = sColHeader & "�L���H��"","""
        sColHeader = sColHeader & "�����H��"","""
        sColHeader = sColHeader & "���H��"","""
        sColHeader = sColHeader & "�L���H����"","""
        sColHeader = sColHeader & "���Ɠx�Ώےl"","""
        sColHeader = sColHeader & "�\��z���P��(��)"","""
        sColHeader = sColHeader & "���ژJ���� �\��z���z"","""
        sColHeader = sColHeader & "���ژJ���� �J�������"","""
        sColHeader = sColHeader & "���ژJ���� �H���U��"","""
        sColHeader = sColHeader & "���ژJ���� �H���⏕�����"","""
        sColHeader = sColHeader & "���ژJ���� �v"","""
        sColHeader = sColHeader & "���ژJ���� �J����z"","""
        sColHeader = sColHeader & "�����Ԑڔ� �\��z���z"","""
        sColHeader = sColHeader & "�����Ԑڔ� �J�������"","""
        sColHeader = sColHeader & "�����Ԑڔ� �Ԑڌo��"","""
        sColHeader = sColHeader & "�����Ԑڔ� �Ԑڕ����"","""
        sColHeader = sColHeader & "�����Ԑڔ� �v"","""
        sColHeader = sColHeader & "�����Ԑڔ� �Ԑڔ�z"","""
        sColHeader = sColHeader & "�������z ���v"","""
        sColHeader = sColHeader & "���ђ���"


        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�������z���͕\ = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   �֐�:GET_SQL_�J����Ԑڔ�z�������\
    '   �T�v:�J����Ԑڔ�z�������\�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2014/10/22      RS)�Ζ{     �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_�J����Ԑڔ�z�������\(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String, ByRef sColHeader2 As String) As Boolean


        GET_SQL_�J����Ԑڔ�z�������\ = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "' || '"",""' || "
        sSql = sSql & "C_CRT_DATE          || '"",""' || "
        sSql = sSql & "C_Y || '�N' || C_M || '���x �J����E�Ԑڔ�z�������\ �y' || C_CO_DESC || '�z' || '"",""' || "
        sSql = sSql & "C_SHU_KOJYO_CLS     || '"",""' || "
        sSql = sSql & "C_SHU_KOJYO_DESC    || '"",""' || "
        sSql = sSql & "C_BMN_DESC          || '"",""' || "
        sSql = sSql & "C_TIME_CST          || '"",""' || "
        sSql = sSql & "C_TIME_CST_SUM      || '"",""' || "
        sSql = sSql & "C_MACHINE_TIME_CST  || '"",""' || "
        sSql = sSql & "C_MACHINE_TIME_CST_SUM    || '"",""' || "
        sSql = sSql & "C_GIJ_CST           || '"",""' || "
        sSql = sSql & "C_GIJ_CST_SUM       || '"",""' || "
        sSql = sSql & "C_KOU1_CST          || '"",""' || "
        sSql = sSql & "C_KOU1_CST_SUM      || '"",""' || "
        sSql = sSql & "C_KOU2_CST          || '"",""' || "
        sSql = sSql & "C_KOU2_CST_SUM      || '"",""' || "
        sSql = sSql & "C_KOU3_CST          || '"",""' || "
        sSql = sSql & "C_KOU3_CST_SUM      || '"",""' || "
        sSql = sSql & "C_KANRI_CST         || '"",""' || "
        sSql = sSql & "C_KANRI_CST_SUM     || '"",""' || "
        sSql = sSql & "C_KOTEI_CST         || '"",""' || "
        sSql = sSql & "C_KOTEI_CST_SUM     || '"",""' || "
        sSql = sSql & "C_TOTAL_CST         || '"",""' || "
        sSql = sSql & "C_TOTAL_CST_SUM     || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = ""
        sColHeader = sColHeader & "���[ID"","""
        sColHeader = sColHeader & "�쐬��"","""
        sColHeader = sColHeader & "���[�^�C�g��"","""
        sColHeader = sColHeader & "���ƕ��R�[�h"","""
        sColHeader = sColHeader & "���ƕ���"","""
        sColHeader = sColHeader & "��Ǖ��喼��"","""
        sColHeader = sColHeader & "�H���z��"","""
        sColHeader = sColHeader & "�H���z��(�݌v)"","""
        sColHeader = sColHeader & "�@�B���H��"","""
        sColHeader = sColHeader & "�@�B���H��(�݌v)"","""
        sColHeader = sColHeader & "�Z�p���z��"","""
        sColHeader = sColHeader & "�Z�p���z��(�݌v)"","""
        sColHeader = sColHeader & "�w����z���i�������ڍޗ���j"","""
        sColHeader = sColHeader & "�w����z���i�������ڍޗ���j(�݌v)"","""
        sColHeader = sColHeader & "�w����z��(�o�ɒ��ڍޗ���)"","""
        sColHeader = sColHeader & "�w����z��(�o�ɒ��ڍޗ���)(�݌v)"","""
        sColHeader = sColHeader & "�w����z���i�O����j"","""
        sColHeader = sColHeader & "�w����z���i�O����j(�݌v)"","""
        sColHeader = sColHeader & "�Ǘ���z��"","""
        sColHeader = sColHeader & "�Ǘ���z��(�݌v)"","""
        sColHeader = sColHeader & "���ʌŒ��z��"","""
        sColHeader = sColHeader & "���ʌŒ��z��(�݌v)"","""
        sColHeader = sColHeader & "���v"","""
        sColHeader = sColHeader & "���v�i�݌v�j"

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�J����Ԑڔ�z�������\ = True

        Exit Function

ERR_END:


    End Function



    '==========================================================================
    '   �֐�:GET_SQL_�����U�փ��X�g
    '   �T�v:�����U�փ��X�g�̂b�r�u�o�͗p�r�p�k�A�w�b�_���쐬
    '   IO  ����            �l          ���e
    '   OUT sSql                       ���o�r�p�k
    '   OUT sColHeader                 ��w�b�_
    '   OUT sRowHeader                 �s�w�b�_
    '
    '   �߂�l              �l          ���e
    '                       True        ����I��
    '                       False       �ُ�I��
    '
    '   �쐬�E�X�V      �S����      �ύX���e
    '   2014/10/22      RS)�Ζ{     �V�K�쐬
    '
    '==========================================================================
    Private Function GET_SQL_�����U�փ��X�g(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String, ByRef sColHeader2 As String) As Boolean


        GET_SQL_�����U�փ��X�g = False
        On Error GoTo ERR_END

        '���oSQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'  || '"",""' || "
        sSql = sSql & "C_CRT_DATE           || '"",""' || "
        sSql = sSql & "C_Y || '�N' || C_M || '���x �����U�փ��X�g �y' || C_CO_DESC || '�z' || '"",""' || "
        sSql = sSql & "C_ORDER_NO           || '"",""' || "
        sSql = sSql & "C_FURI_DATE          || '"",""' || "
        sSql = sSql & "C_FURIKAE_DESC       || '"",""' || "
        sSql = sSql & "C_MOTO_SEIBAN        || '"",""' || "
        sSql = sSql & "C_MOTO_SYUYAKU_NO    || '"",""' || "
        sSql = sSql & "C_SAKI_SEIBAN        || '"",""' || "
        sSql = sSql & "C_SAKI_SYUYAKU_NO    || '"",""' || "
        sSql = sSql & "C_AMT                || '"",""' || "
        sSql = sSql & "C_SYORI_KBN          || '"",""' || "
        sSql = sSql & "C_CREATE_CD          || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '��w�b�_
        sColHeader = ""
        sColHeader = sColHeader & "���[ID"","""
        sColHeader = sColHeader & "�쐬��"","""
        sColHeader = sColHeader & "���[�^�C�g��"","""
        sColHeader = sColHeader & "������"","""
        sColHeader = sColHeader & "�U�֓�"","""
        sColHeader = sColHeader & "�U�֋敪����"","""
        sColHeader = sColHeader & "������"","""
        sColHeader = sColHeader & "���W��"","""
        sColHeader = sColHeader & "�搻��"","""
        sColHeader = sColHeader & "��W��"","""
        sColHeader = sColHeader & "�U�֋��z"","""
        sColHeader = sColHeader & "�����敪"","""
        sColHeader = sColHeader & "�����S��"

        '�s�w�b�_
        sRowHeader = ""


        GET_SQL_�����U�փ��X�g = True

        Exit Function

ERR_END:


    End Function

    'PDF�o�͗p�֐�
    '2015/10/6�ǋL�@FWEST

    '2019/05/13 CHG START
    'Private Function PDF_OUTPUT_BK(ByVal PDF_NM As String) As Object
    '    Dim crEFTPortableDocFormat As Object
    '    Dim crEDTDiskFile As Object
    '    Dim CRAXDRT As Object

    '    Dim CRAPP As CRAXDRT.Application
    '    'UPGRADE_ISSUE: CRAXDRT.Report �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '    Dim Report As CRAXDRT.Report
    '    'UPGRADE_ISSUE: CRAXDRT.ConnectionProperty �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '    Dim ConnectProperty As CRAXDRT.ConnectionProperty

    '    Dim iPaperOrnt As Short
    '    Dim iPaperSize As Short
    '    Dim i As Short

    '    '���|�[�g�t�@�C���w��
    '    CRAPP = CreateObject("Crystalruntime.Application")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CRAPP.OpenReport �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Report = CRAPP.OpenReport(SSS_RPT_DIR & "\" & SSS_PrtID & ".RPT")
    '    '�p�����@�ޔ�
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.PaperOrientation �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    iPaperOrnt = Report.PaperOrientation
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.PaperSize �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    iPaperSize = Report.PaperSize


    '    '�c�a�ڑ�
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    For i = 1 To Report.Database.Tables.Count

    '        'IT2-0005 UPD STR
    '        '*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("Server")
    '        '*D*        ConnectProperty.Value = ps_DatabaseName
    '        '*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("User ID")
    '        '*D*        ConnectProperty.Value = ps_UserName
    '        '*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("Password")
    '        '*D*        ConnectProperty.Value = ps_Password
    '        'SID
    '        'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        Report.Database.Tables(i).ConnectionProperties.Item("Server") = ps_DatabaseName
    '        'հ��
    '        'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        Report.Database.Tables(i).ConnectionProperties.Item("User ID") = ps_UserName
    '        '�߽ܰ��
    '        'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        Report.Database.Tables(i).ConnectionProperties.Item("Password") = ps_Password
    '        '۹���݁@��հ�ނ�啶���ϊ����Ȃ��Ɛ������v���r���[����Ȃ�
    '        'UPGRADE_WARNING: �I�u�W�F�N�g Report.Database �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        Report.Database.Tables(i).Location = UCase(ps_UserName) & "." & SSS_TblID
    '        'IT2-0005 UPD END

    '    Next i


    '    '���o�����w��
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.RecordSelectionFormula �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    If Trim(Report.RecordSelectionFormula) <> "" Then
    '        'UPGRADE_WARNING: �I�u�W�F�N�g Report.RecordSelectionFormula �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        Report.RecordSelectionFormula = Report.RecordSelectionFormula & " AND {" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
    '    Else
    '        'UPGRADE_WARNING: �I�u�W�F�N�g Report.RecordSelectionFormula �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        Report.RecordSelectionFormula = "{" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
    '    End If


    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.PaperOrientation �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Report.PaperOrientation = iPaperOrnt
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.PaperSize �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Report.PaperSize = iPaperSize

    '    '�t�@�C�����ɓ��t������
    '    PDF_NM = PDF_NM & ".pdf"

    '    '// pdf�Ƃ��ĊO���t�@�C���o�͂��s��
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.ExportOptions �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'UPGRADE_WARNING: �I�u�W�F�N�g crEDTDiskFile �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Report.ExportOptions.DestinationType = crEDTDiskFile
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.ExportOptions �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Report.ExportOptions.DiskFileName = PDF_NM '"C:\output.pdf"
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.ExportOptions �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'UPGRADE_WARNING: �I�u�W�F�N�g crEFTPortableDocFormat �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Report.ExportOptions.FormatType = crEFTPortableDocFormat
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Report.Export �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Report.Export(False)

    'End Function
    Private Sub PDF_OUTPUT(ByVal PDF_NM As String)

        Dim CR As New CrstlRpt
        Dim Report = CR.NewCRReport()
        Dim iPaperOrnt As Short
        Dim iPaperSize As Short

        '���|�[�g�t�@�C���w��
        Report.Load(SSS_RPT_DIR & "\" & SSS_PrtID & ".rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)

        '�p�����@�ޔ�
        iPaperOrnt = Report.PrintOptions.PaperOrientation
        iPaperSize = Report.PrintOptions.PaperSize

        Dim sSql As String '���o�r�p�k
        Dim sColHeader As String '��^�C�g��
        Dim sColHeader2 As String '��^�C�g���Q
        Dim sRowHeader As String '�s�^�C�g��

        If Get_Sql(sSql, sColHeader, sRowHeader, sColHeader2) = False Then
            Exit Sub
        End If

        '���o�����w��
        If Trim(Report.RecordSelectionFormula) <> "" Then
            Report.RecordSelectionFormula = Report.RecordSelectionFormula & " AND {" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
        Else
            Report.RecordSelectionFormula = "{" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
        End If

        'CR = New CrstlRpt

        '�p���ݒ�
        Report.PrintOptions.PaperOrientation = iPaperOrnt
        Report.PrintOptions.PaperSize = iPaperSize
        '���|�[�g���ڑ�����c�a�����Z�b�g����ʕ\�����̃��O�C����ʂ̕\�������***
        Report.SetDatabaseLogon("GENKA_USR1", "GENKA_USR1")
        '***************************************************************************
        'CR.SetDatabase("CONORCL", "GENKA_USR1P", "GENKA_USR1", sSql, SSS_TblID, Report)
        CR.SetDatabase("DEV02", "GENKA_USR1", "GENKA_USR1", sSql, SSS_TblID, Report)

        '�t�@�C�����ɓ��t������
        PDF_NM = PDF_NM & ".pdf"

        CR.ReportPreview(Report, sSql, "01")

        CR.ReportPrint(Report, 4)

    End Sub
    '2019/05/13 CHG E N D


    'CSV�o�͗p�֐�
    '2015/10/29�ǋL�@FWEST
    Private Function CSV_OUTPUT_B(ByVal CSV_NM As String) As Object

        Dim sSql As String '���o�r�p�k
        Dim sColHeader As String '��^�C�g��
        Dim sColHeader2 As String '��^�C�g���Q
        Dim sRowHeader As String '�s�^�C�g��

        '�w�b�_���E�r�p�k���쐬
        If Get_Sql(sSql, sColHeader, sRowHeader, sColHeader2) = False Then
            Exit Function
        End If

        '�b�r�u�o��
        If CSV_OUTPUT("BATCH", sSql, sColHeader, sRowHeader, sColHeader2, CSV_NM & ".csv") = False Then
            Exit Function
        End If

    End Function
End Module