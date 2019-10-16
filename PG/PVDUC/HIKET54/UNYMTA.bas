Attribute VB_Name = "UNYMTA_DBM"
        Option Explicit
'==========================================================================
'   UNYMTA.DBM   �^�p��ð���                      UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_UNYMTA
    UNYDT          As String * 8     '�^�p���t
    UNYKBA         As String * 1     '�^�p�敪�P
    UNYKBB         As String * 1     '�^�p�敪�Q
    UNYKBC         As String * 1     '�^�p�敪�R
    UNYKBD         As String * 1     '�^�p�敪�S
    UNYKBE         As String * 1     '�^�p�敪�T
    TERMNO         As String * 2     '��
    ACCYY          As String * 4     '��v�N�x
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h
    CLTID          As String * 5     '�N���C�A���g�h�c
    WRTTM          As String * 6     '�^�C���X�^���v�i���ԁj
    WRTDT          As String * 8     '�^�C���X�^���v�i���t�j
    WRTFSTTM       As String * 6     '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT       As String * 8     '�^�C���X�^���v�i�o�^���j
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_UNYMTA_Clear
    '   �T�v�F  �^�p���e�[�u���\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_UNYMTA_Clear(ByRef pot_DB_UNYMTA As TYPE_DB_UNYMTA)

        Dim Clr_DB_UNYMTA As TYPE_DB_UNYMTA
    
        pot_DB_UNYMTA = Clr_DB_UNYMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPUNYDT_SEARCH
    '   �T�v�F  �^�p������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPUNYDT_SEARCH(ByRef pot_DB_UNYMTA As TYPE_DB_UNYMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPUNYDT_SEARCH
    
        DSPUNYDT_SEARCH = 9
        
        Call DB_UNYMTA_Clear(pot_DB_UNYMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from UNYMTA "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPUNYDT_SEARCH = 1
            GoTo END_DSPUNYDT_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_UNYMTA
                .UNYDT = CF_Ora_GetDyn(Usr_Ody, "UNYDT", "")                    '�^�p���t
                .UNYKBA = CF_Ora_GetDyn(Usr_Ody, "UNYKBA", "")                  '�^�p�敪�P
                .UNYKBB = CF_Ora_GetDyn(Usr_Ody, "UNYKBB", "")                  '�^�p�敪�Q
                .UNYKBC = CF_Ora_GetDyn(Usr_Ody, "UNYKBC", "")                  '�^�p�敪�R
                .UNYKBD = CF_Ora_GetDyn(Usr_Ody, "UNYKBD", "")                  '�^�p�敪�S
                .UNYKBE = CF_Ora_GetDyn(Usr_Ody, "UNYKBE", "")                  '�^�p�敪�T
                .TERMNO = CF_Ora_GetDyn(Usr_Ody, "TERMNO", "")                  '��
                .ACCYY = CF_Ora_GetDyn(Usr_Ody, "ACCYY", "")                    '��v�N�x
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If
        
        DSPUNYDT_SEARCH = 0
        
END_DSPUNYDT_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_DSPUNYDT_SEARCH:
        GoTo END_DSPUNYDT_SEARCH
        
    End Function


