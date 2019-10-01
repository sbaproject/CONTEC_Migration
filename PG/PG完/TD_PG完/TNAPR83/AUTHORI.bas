Attribute VB_Name = "AUTHORITY_DBM"
Option Explicit
Public gs_kengen As String
Public gs_ari As String
Public gs_userid As String
Public gs_pgid   As String
Public gs_UPDAUTH As String
Public gs_PRTAUTH As String
Public gs_FILEAUTH As String
Public gs_SALTAUTH As String
Public gs_HDNTAUTH As String
Public gs_SAPMAUTH As String


'**************************************************************************************************
'�v���V�W����   �FGet_Authority
'�����T�v       �F�v���O�����̎��s�������擾����
'                 CrystalReport�̃v���r���[��ʂ̈���{�^�������[�U�����ɂ���Đ��䂷��
'����   �P�Fec_DATE(�S���҂̓K�p���𔻒f������t)
'       �Q�Fec_CRW(CrystalReport�R���g���[����) �I�v�V����
'�ߒl   1�F�����}�X�^�Ƀf�[�^�L��
'       9�F�����}�X�^�Ƀf�[�^�Ȃ�
'**************************************************************************************************
Public Function Get_Authority(ec_DATE As String, Optional ec_CRW As Control) As String

'�ϐ��錾
Dim ls_sql  As String
Dim Usr_Ody As U_Ody

'�����l�͑S�����Ȃ�
gs_UPDAUTH = "9" '�X�V����
gs_PRTAUTH = "9" '�������
gs_FILEAUTH = "9" '�t�@�C���o�͌���
gs_SALTAUTH = "9" '�̔��P���ύX����
gs_HDNTAUTH = "9" '�����P���ύX����
gs_SAPMAUTH = "9" '�̔��v��N���v��C������

'���[�UID�������������擾����
ls_sql = "  SELECT "
ls_sql = ls_sql & " K.UPDAUTH,"
ls_sql = ls_sql & " K.PRTAUTH,"
ls_sql = ls_sql & " K.FILEAUTH,"
ls_sql = ls_sql & " K.SALTAUTH,"
ls_sql = ls_sql & " K.HDNTAUTH,"
ls_sql = ls_sql & " K.SAPMAUTH "
ls_sql = ls_sql & " FROM KNGMTB K,TANMTA T "
'ls_sql = ls_sql & " WHERE K.KNGGRCD = T.KNGGRCD "
ls_sql = ls_sql & " WHERE K.KNGGRCD = (CASE WHEN T.TANTKDT <= '" & ec_DATE & "' THEN T.KNGGRCD ELSE T.OLDGRCD END) "
ls_sql = ls_sql & "   AND T.TANCD   = '" & gs_userid & "'"
ls_sql = ls_sql & "   AND K.PGID    = '" & gs_pgid & "'"
ls_sql = ls_sql & "   AND K.DATKB   = '1'"
ls_sql = ls_sql & "   AND T.DATKB    = '1'"

Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)

If CF_Ora_EOF(Usr_Ody) = True Then
    '�擾�f�[�^�Ȃ��̏ꍇ�͌����Ȃ��Ƃ݂Ȃ��B
    Get_Authority = 9
Else
    Do Until CF_Ora_EOF(Usr_Ody) = True
        gs_UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "")      '�X�V����
        gs_PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "")      '�������
        gs_FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "")    '�t�@�C���o�͌���
        gs_SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "")    '�̔��P���ύX����
        gs_HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "")    '�����P���ύX����
        gs_SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "")    '�̔��v��N���v��C������
        '�����R�[�h
        Call CF_Ora_MoveNext(Usr_Ody)
    Loop
    Get_Authority = 1
End If

If ec_CRW Is Nothing Then
Else
    If gs_PRTAUTH = "1" Then
        '�������������ꍇ
        ec_CRW.WindowShowPrintBtn = True    '����{�^��
    Else
        '��������������ꍇ
        ec_CRW.WindowShowPrintBtn = False   '����{�^��
    End If
    If gs_FILEAUTH = "1" Then
        '�G�N�X�|�[�g����������ꍇ
        ec_CRW.WindowShowExportBtn = True   '�G�N�X�|�[�g�{�^��
    Else
        '�G�N�X�|�[�g�����������ꍇ
        ec_CRW.WindowShowExportBtn = False  '�G�N�X�|�[�g�{�^��
    End If
End If

End Function



