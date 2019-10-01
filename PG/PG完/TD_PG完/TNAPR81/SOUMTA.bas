Attribute VB_Name = "SOUMTA_DBM"
        Option Explicit
'==========================================================================
'   SOUMTA.DBM   �q�Ƀ}�X�^                       UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SOUMTA
    DATKB          As String * 1     '�`�[�폜�敪          0
    SOUCD          As String * 3     '�q�ɃR�[�h            000
    SOUNM          As String * 20    '�q�ɖ�
    SOUZP          As String * 20    '�q�ɗX�֔ԍ�
    SOUADA         As String * 60    '�q�ɏZ���P
    SOUADB         As String * 60    '�q�ɏZ���Q
    SOUADC         As String * 60    '�q�ɏZ���R
    SOUTL          As String * 20    '�q�ɓd�b�ԍ�
    SOUFX          As String * 20    '�q�ɂe�`�w�ԍ�
    SOUBSCD        As String * 3     '�ꏊ�R�[�h            000
    SOUKB          As String * 1     '�q�Ɏ��              0
    SRSCNKB        As String * 1     '�رٽ��ݗv�ۋ敪      0
    SISNKB         As String * 1     '���Y���敪            0
    SOUTRICD       As String * 10    '�����R�[�h          !@@@@@@@@@@
    SOUKOKB        As String * 2     '�q�ɋ敪              00
    HIKKB          As String * 1     '�����Ώۋ敪          0
    SALPALKB       As String * 1     '�̔��v��Ώۋ敪
    RELFL          As String * 1     '�A�g�t���O            X
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@
    WRTTM          As String * 6     '��ѽ����(����)        9(06)
    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD
    WRTFSTTM       As String * 6     '��ѽ����(�o�^����)    9(06)
    WRTFSTDT       As String * 8     '��ѽ����(�o�^��)      YYYY/MM/DD
End Type
Global DB_SOUMTA As TYPE_DB_SOUMTA
Global DBN_SOUMTA As Integer

'�q�Ƀ}�X�^�����߂�l
Public WLSSOU_RTNCODE       As String           '�q�ɃR�[�h

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_SOUMTA_Clear
    '   �T�v�F  �q�Ƀ}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_SOUMTA_Clear(ByRef pot_DB_SOUMTA As TYPE_DB_SOUMTA)

        Dim Clr_DB_SOUMTA As TYPE_DB_SOUMTA
    
        pot_DB_SOUMTA = Clr_DB_SOUMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPSOUCD_SEARCH
    '   �T�v�F  �q�ɃR�[�h����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPSOUCD_SEARCH(ByVal pin_strSOUCD As String, _
                                    ByRef pot_DB_SOUMTA As TYPE_DB_SOUMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody
        
    On Error GoTo ERR_DSPSOUCD_SEARCH
    
        DSPSOUCD_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SOUMTA "
        strSQL = strSQL & "  Where SOUCD = '" & pin_strSOUCD & "' "
        

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            Call CF_Ora_CloseDyn(Usr_Ody)
            DSPSOUCD_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_SOUMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")                    '�q�ɃR�[�h
                .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")                    '�q�ɖ�
                .SOUZP = CF_Ora_GetDyn(Usr_Ody, "SOUZP", "")                    '�q�ɗX�֔ԍ�
                .SOUADA = CF_Ora_GetDyn(Usr_Ody, "SOUADA", "")                  '�q�ɏZ���P
                .SOUADB = CF_Ora_GetDyn(Usr_Ody, "SOUADB", "")                  '�q�ɏZ���Q
                .SOUADC = CF_Ora_GetDyn(Usr_Ody, "SOUADC", "")                  '�q�ɏZ���R
                .SOUTL = CF_Ora_GetDyn(Usr_Ody, "SOUTL", "")                    '�q�ɓd�b�ԍ�
                .SOUFX = CF_Ora_GetDyn(Usr_Ody, "SOUFX", "")                    '�q�ɂe�`�w�ԍ�
                .SOUBSCD = CF_Ora_GetDyn(Usr_Ody, "SOUBSCD", "")                '�ꏊ�R�[�h
                .SOUKB = CF_Ora_GetDyn(Usr_Ody, "SOUKB", "")                    '�q�Ɏ��
                .SRSCNKB = CF_Ora_GetDyn(Usr_Ody, "SRSCNKB", "")                '�V���A���X�L�����v�ۋ敪
                .SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "")                  '���Y���敪
                .SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "")              '�����R�[�h
                .SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "")                '�q�ɋ敪
                .HIKKB = CF_Ora_GetDyn(Usr_Ody, "HIKKB", "")                    '�����Ώۋ敪
                .SALPALKB = CF_Ora_GetDyn(Usr_Ody, "SALPALKB", "")              '�̔��v��Ώۋ敪
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        DSPSOUCD_SEARCH = 0
        
        Exit Function
    
ERR_DSPSOUCD_SEARCH:
        
        
    End Function


