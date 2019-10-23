Attribute VB_Name = "TRKMTA_DBM"
        Option Explicit
'==========================================================================
'   TRKMTA.DBM   ���ӕʏ��i�����N�}�X�^             UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TRKMTA
    DATKB           As String * 1       '�`�[�폜�敪
    TOKCD           As String * 10      '���Ӑ�R�[�h
    SKHINGRP        As String * 4       '�d�ؗp���i�Q
    TRKRNK          As String * 1       '�����N
    TRKOEM          As String * 1       'OEM
    STTKSTDT        As String * 8       '�J�n�P���ݒ���t
    NBKRT           As Currency         '�l����
    RELFL           As String * 1       '�A�g�t���O
    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
    CLTID           As String * 5       '�N���C�A���g�h�c
    WRTTM           As String * 6       '�^�C���X�^���v�i���ԁj
    WRTDT           As String * 8       '�^�C���X�^���v�i���t�j
    WRTFSTTM        As String * 6       '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT        As String * 8       '�^�C���X�^���v�i�o�^���j
' === 20080909 === INSERT S - RISE)Izumi
    UOPEID          As String * 8       '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
    UCLTID          As String * 5       '�N���C�A���g�h�c�i�o�b�`�j
    UWRTTM          As String * 6       '�^�C���X�^���v�i�o�b�`���ԁj
    UWRTDT          As String * 8       '�^�C���X�^���v�i�o�b�`���t�j
' === 20080909 === INSERT S - RISE)Izumi
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_TRKMTA_Clear
    '   �T�v�F  ���ӕʏ��i�����N�}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_TRKMTA_Clear(ByRef pot_DB_TRKMTA As TYPE_DB_TRKMTA)

        Dim Clr_DB_TRKMTA As TYPE_DB_TRKMTA
    
        pot_DB_TRKMTA = Clr_DB_TRKMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function TRKMTA_SEARCH
    '   �T�v�F  ���ӕʏ��i�����N�}�X�^����
    '   �����F  pin_strTOKCD�@�@ : ���Ӑ�R�[�h
    '   �@�@�@�@pin_strSKHINGRP�@: �d�ؗp���i�Q
    '   �@�@�@�@pin_strSTTKSTDT  : �J�n�P���ݒ���t
    '   �@�@�@�@pin_strTRKRNK    : �����N
    '   �@�@�@�@pot_DB_TRKMTA�@�@: ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function TRKMTA_SEARCH(ByVal pin_strTOKCD As String, _
                                  ByVal pin_strSKHINGRP As String, _
                                  ByVal pin_strSTTKSTDT As String, _
                                  ByVal pin_strTRKRNK As String, _
                                  ByRef pot_DB_TRKMTA As TYPE_DB_TRKMTA) As Integer
    
        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTGRPCD       As String

    On Error GoTo ERR_TRKMTA_SEARCH
    
        TRKMTA_SEARCH = 9
        
        Call DB_TRKMTA_Clear(pot_DB_TRKMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TRKMTA "
        strSQL = strSQL & "  Where DATKB     = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and TOKCD     = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
        strSQL = strSQL & "    and SKHINGRP  = '" & CF_Ora_Sgl(pin_strSKHINGRP) & "' "
        strSQL = strSQL & "    and STTKSTDT  = '" & CF_Ora_Sgl(pin_strSTTKSTDT) & "' "
        strSQL = strSQL & "    and TRKRNK    = '" & CF_Ora_Sgl(pin_strTRKRNK) & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            TRKMTA_SEARCH = 1
            GoTo END_TRKMTA_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_TRKMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '���Ӑ�R�[�h
                .SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "")              '�d�ؗp���i�Q
                .TRKRNK = CF_Ora_GetDyn(Usr_Ody, "TRKRNK", "")                  '�����N
                .TRKOEM = CF_Ora_GetDyn(Usr_Ody, "TRKOEM", "")                  'OEM
                .STTKSTDT = CF_Ora_GetDyn(Usr_Ody, "STTKSTDT", "")              '�J�n�P���ݒ���t
                .NBKRT = CF_Ora_GetDyn(Usr_Ody, "NBKRT", "")                    '�l����
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If
        
        TRKMTA_SEARCH = 0
        
END_TRKMTA_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_TRKMTA_SEARCH:
        GoTo END_TRKMTA_SEARCH

    End Function

