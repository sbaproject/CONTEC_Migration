Attribute VB_Name = "TKRMTA_DBM"
        Option Explicit
'==========================================================================
'   TKRMTA.DBM   ���ӕʎ戵���i�}�X�^             UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TKRMTA
    DATKB           As String * 1       '�`�[�폜�敪
    TOKCD           As String * 10      '���Ӑ�R�[�h
    SKHINGRP        As String * 4       '�d�ؗp���i�Q
    SKWRKKB         As String * 1       '�d�؏����敪
    HINCD           As String * 10      '���i�R�[�h
    RELFL           As String * 1       '�A�g�t���O
    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
    CLTID           As String * 5       '�N���C�A���g�h�c
    WRTTM           As String * 6       '�^�C���X�^���v�i���ԁj
    WRTDT           As String * 8       '�^�C���X�^���v�i���t�j
    WRTFSTTM        As String * 6       '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT        As String * 8       '�^�C���X�^���v�i�o�^���j
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_TKRMTA_Clear
    '   �T�v�F  ���ӕʎ戵���i�}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_TKRMTA_Clear(ByRef pot_DB_TKRMTA As TYPE_DB_TKRMTA)

        Dim Clr_DB_TKRMTA As TYPE_DB_TKRMTA
    
        pot_DB_TKRMTA = Clr_DB_TKRMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function TKRMTA_SEARCH
    '   �T�v�F  ���ӕʎ戵���i�}�X�^����
    '   �����F  pin_strTOKCD�@�@ : ���Ӑ�R�[�h
    '   �@�@�@�@pin_strSKHINGRP�@: �d�ؗp���i�Q
    '   �@�@�@�@pin_strHINCD�@�@ : ���i�R�[�h
    '   �@�@�@�@pot_DB_TKRMTA�@�@: ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function TKRMTA_SEARCH(ByVal pin_strTOKCD As String, _
                                  ByVal pin_strSKHINGRP As String, _
                                  ByVal pin_strHINCD As String, _
                                  ByRef pot_DB_TKRMTA As TYPE_DB_TKRMTA) As Integer
    
        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTGRPCD       As String

    On Error GoTo ERR_TKRMTA_SEARCH
    
        TKRMTA_SEARCH = 9
        
        Call DB_TKRMTA_Clear(pot_DB_TKRMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TKRMTA "
        strSQL = strSQL & "  Where DATKB     = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and TOKCD     = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
        strSQL = strSQL & "    and SKHINGRP  = '" & CF_Ora_Sgl(pin_strSKHINGRP) & "' "
        strSQL = strSQL & "    and HINCD     = '" & CF_Ora_Sgl(pin_strHINCD) & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            TKRMTA_SEARCH = 1
            GoTo END_TKRMTA_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_TKRMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '���Ӑ�R�[�h
                .SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "")              '�d�ؗp���i�Q
                .SKWRKKB = CF_Ora_GetDyn(Usr_Ody, "SKWRKKB", "")                '�d�؏����敪
                .HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")                    '���i�R�[�h
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If
        
        TKRMTA_SEARCH = 0
        
END_TKRMTA_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_TKRMTA_SEARCH:
        GoTo END_TKRMTA_SEARCH

    End Function

