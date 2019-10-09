Attribute VB_Name = "GET_DATA"
Option Explicit

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function DSPMSGCM_SEARCH
'   �T�v�F  �V�X�e�����b�Z�[�W����
'   �����F  pin_strMSGKB    : ���b�Z�[�W���
'           pin_strMSGNM    : ���b�Z�[�W�A�C�e��
'           pin_strMSGSQ�@�@: ���b�Z�[�W�A��
'           pot_DB_SYSTBH   : ��������
'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function DSPMSGCM_SEARCH(ByVal pin_strMSGKB As String, _
                                ByVal pin_strMSGNM As String, _
                                ByVal pin_strMSGSQ As String, _
                                ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH) As Integer

    Dim strSQL          As String
    Dim intData         As Integer
    Dim Usr_Ody_LC      As U_Ody

    On Error GoTo ERR_DSPMSGCM_SEARCH

    DSPMSGCM_SEARCH = 9
    
    strSQL = ""
    strSQL = strSQL & "Select * From SYSTBH"
    strSQL = strSQL & " Where MSGKB = " & "'" & CF_Ora_Sgl(pin_strMSGKB) & "'"
    strSQL = strSQL & "   And MSGNM = " & "'" & CF_Ora_Sgl(pin_strMSGNM) & "'"
    strSQL = strSQL & "   And MSGSQ = " & "'" & CF_Ora_Sgl(pin_strMSGSQ) & "'"
    
    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = True Then
        '�擾�f�[�^�Ȃ�
        DSPMSGCM_SEARCH = 1
        GoTo END_DSPMSGCM_SEARCH
    End If
    
    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        With pot_DB_SYSTBH
            .MSGKB = CF_Ora_GetDyn(Usr_Ody_LC, "MSGKB", "")                    '���b�Z�[�W���
            .MSGNM = CF_Ora_GetDyn(Usr_Ody_LC, "MSGNM", "")                    '���b�Z�[�W�A�C�e��
            .MSGSQ = CF_Ora_GetDyn(Usr_Ody_LC, "MSGSQ", "")                    '���b�Z�[�W�A��
            .BTNKB = CF_Ora_GetDyn(Usr_Ody_LC, "BTNKB", 0)                     '�{�^�����
            .BTNON = CF_Ora_GetDyn(Usr_Ody_LC, "BTNON", 0)                     '�{�^�������l
            .ICNKB = CF_Ora_GetDyn(Usr_Ody_LC, "ICNKB", 0)                     '�A�C�R�����
            .MSGCM = CF_Ora_GetDyn(Usr_Ody_LC, "MSGCM", "")                    '���b�Z�[�W
            .COLSQ = CF_Ora_GetDyn(Usr_Ody_LC, "COLSQ", "")                    '�F�V�[�P���X
            .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
            .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")                    '�N���C�A���g�h�c
            .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")                    '��ѽ����(����)
            .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")                    '��ѽ����(���t)
        End With
    End If

    DSPMSGCM_SEARCH = 0
    
END_DSPMSGCM_SEARCH:
    
    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody_LC)

    Exit Function

ERR_DSPMSGCM_SEARCH:
    GoTo END_DSPMSGCM_SEARCH
    
End Function




