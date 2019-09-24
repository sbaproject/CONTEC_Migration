Attribute VB_Name = "RNKMTA_DBM"
        Option Explicit
'==========================================================================
'   RNKMTA.DBM   �����N�ʎd�ؗ��}�X�^�@           UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_RNKMTA
    DATKB           As String * 1       '�`�[�폜�敪
    HINGRP          As String * 4       '���i�Q
    RNKCD           As String * 1       '�����N
    URISETDT        As String * 8       '�̔��P���ݒ���t
    SIKRT           As Currency         '�d�ؗ�
    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
    CLTID           As String * 5       '�N���C�A���g�h�c
    WRTTM           As String * 6       '�^�C���X�^���v�i���ԁj
    WRTDT           As String * 8       '�^�C���X�^���v�i���t�j
    WRTFSTTM        As String * 6       '�^�C���X�^���v�i���ԁj
    WRTFSTDT        As String * 8       '�^�C���X�^���v�i�o�^���j
End Type
Global DB_RNKMTA As TYPE_DB_RNKMTA
Global DBN_RNKMTA As Integer

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_RNKMTA_Clear
    '   �T�v�F  �����N�ʎd�ؗ��}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_RNKMTA_Clear(ByRef pot_DB_RNKMTA As TYPE_DB_RNKMTA)

        Dim Clr_DB_RNKMTA As TYPE_DB_RNKMTA
    
        pot_DB_RNKMTA = Clr_DB_RNKMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPRNKM_SEARCH
    '   �T�v�F  �����N�ʎd�ؗ��}�X�^����
    '   �����F�@pin_strHINGRP   : ���i�Q
    '           pin_strRNKCD    : �����N
    '           pin_strURISETDT : �̔��P���ݒ���t
    '           pot_DB_RNKMTA �@: ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPRNKM_SEARCH(ByVal pin_strHINGRP As String, _
                                   ByVal pin_strRNKCD As String, _
                                   ByVal pin_strURISETDT As String, _
                                   ByRef pot_DB_RNKMTA As TYPE_DB_RNKMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPRNKM_SEARCH
    
        DSPRNKM_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from RNKMTA "
        strSQL = strSQL & "  Where HINGRP = '" & pin_strHINGRP & "' "
        strSQL = strSQL & "  and RNKCD = '" & pin_strRNKCD & "' "
        strSQL = strSQL & "  and URISETDT = ( Select MAX(URISETDT) AS _MAX_URISETDT "
        strSQL = strSQL & "                     from RNKMTA "
        strSQL = strSQL & "                    Where HINGRP = '" & pin_strHINGRP & "' "
        strSQL = strSQL & "                      and RNKCD = '" & pin_strRNKCD & "' "
        strSQL = strSQL & "                      and URISETDT <= '" & pin_strURISETDT & "' )"
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPRNKM_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_RNKMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "")                  '���i�Q
                .RNKCD = CF_Ora_GetDyn(Usr_Ody, "RNKCD", "")                    '�����N
                .URISETDT = CF_Ora_GetDyn(Usr_Ody, "URISETDT", "")              '�̔��P���ݒ���t
                .SIKRT = CF_Ora_GetDyn(Usr_Ody, "SIKRT", 0)                     '�d�ؗ�
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        

        DSPRNKM_SEARCH = 0
        
        Exit Function
    
ERR_DSPRNKM_SEARCH:
        
        
    End Function

