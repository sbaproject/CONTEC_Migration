Attribute VB_Name = "KNGMTB_DBM"
        Option Explicit
'==========================================================================
'   KNGMTB.DBM   �����}�X�^                UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_KNGMTB
    DATKB           As String * 1       '�`�[�폜�敪
    KNGGRCD         As String * 3       '�����O���[�v
    PGID            As String * 7       '�v���O����ID
    UPDFLG          As String * 1       '�X�V�ύX�t���O
    UPDAUTH         As String * 1       '�X�V����
    PRTFLG          As String * 1       '����ύX�t���O
    PRTAUTH         As String * 1       '�������
    FILEFLG         As String * 1       '�t�@�C���ύX�t���O
    FILEAUTH        As String * 1       '�t�@�C���o�͌���
    SALTFLG         As String * 1       '�̔��P���ύX�t���O
    SALTAUTH        As String * 1       '�̔��P���ύX����
    HDNTFLG         As String * 1       '�����P���ύX�t���O
    HDNTAUTH        As String * 1       '�����P���ύX����
    SAPMFLG         As String * 1       '�N���v��ύX�t���O
    SAPMAUTH        As String * 1       '�N���v��C������
    RELFL           As String * 1       '�A�g�t���O
    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
    CLTID           As String * 5       '�N���C�A���g�h�c
    WRTTM           As String * 6       '�^�C���X�^���v�i���ԁj
    WRTDT           As String * 8       '�^�C���X�^���v�i���t�j
    WRTFSTTM        As String * 6       '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT        As String * 8       '�^�C���X�^���v�i�o�^���j
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_KNGMTB_Clear
    '   �T�v�F  �����}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_KNGMTB_Clear(ByRef pot_DB_KNGMTB As TYPE_DB_KNGMTB)

        Dim Clr_DB_KNGMTB As TYPE_DB_KNGMTB
    
        pot_DB_KNGMTB = Clr_DB_KNGMTB
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function KNGMTB_SEARCH
    '   �T�v�F  �����}�X�^����
    '   �����F  pin_strKNGGRCD�@ : �����O���[�v
    '   �@�@�@�@pin_strPGID �@�@ : �v���O����ID
    '   �@�@�@�@pot_DB_KNGMTB  �@: ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function KNGMTB_SEARCH(ByVal pin_strKNGGRCD As String, _
                                  ByVal pin_strPGID As String, _
                                  ByRef pot_DB_KNGMTB As TYPE_DB_KNGMTB) As Integer

        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTGRPCD       As String

    On Error GoTo ERR_KNGMTB_SEARCH
    
        KNGMTB_SEARCH = 9
        
        Call DB_KNGMTB_Clear(pot_DB_KNGMTB)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from KNGMTB "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and KNGGRCD = '" & CF_ORA_SGL(pin_strKNGGRCD) & "' "
        strSQL = strSQL & "    and PGID    = '" & CF_ORA_SGL(pin_strPGID) & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            KNGMTB_SEARCH = 1
            GoTo END_KNGMTB_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_KNGMTB
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .KNGGRCD = CF_Ora_GetDyn(Usr_Ody, "KNGGRCD", "")                '�����O���[�v
                .UPDFLG = CF_Ora_GetDyn(Usr_Ody, "UPDFLG", "")                  '�X�V�ύX�t���O
                .UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "")                '�X�V����
                .PRTFLG = CF_Ora_GetDyn(Usr_Ody, "PRTFLG", "")                  '����ύX�t���O
                .PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "")                '�������
                .FILEFLG = CF_Ora_GetDyn(Usr_Ody, "FILEFLG", "")                '�t�@�C���ύX�t���O
                .FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "")              '�t�@�C���o�͌���
                .SALTFLG = CF_Ora_GetDyn(Usr_Ody, "SALTFLG", "")                '�̔��P���ύX�t���O
                .SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "")              '�̔��P���ύX����
                .HDNTFLG = CF_Ora_GetDyn(Usr_Ody, "HDNTFLG", "")                '�����P���ύX�t���O
                .HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "")              '�����P���ύX����
                .SAPMFLG = CF_Ora_GetDyn(Usr_Ody, "SAPMFLG", "")                '�N���v��ύX�t���O
                .SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "")              '�N���v��C������
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If
        
        KNGMTB_SEARCH = 0
        
END_KNGMTB_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_KNGMTB_SEARCH:
        GoTo END_KNGMTB_SEARCH
        
    End Function

