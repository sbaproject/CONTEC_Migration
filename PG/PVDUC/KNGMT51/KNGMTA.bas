Attribute VB_Name = "KNGMTA_DBM"
        Option Explicit
'==========================================================================
'   KNGMTA.DBM   �����}�X�^                UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_KNGMTA
    DATKB           As String * 1       '�`�[�폜�敪
    KNGGRCD         As String * 3       '�����O���[�v
    SALTKKB         As String * 1       '�̔��P���ύX
    HDNTKKB         As String * 1       '�����P���ύX
    SAPMODKB        As String * 1       '�̔��v��N���v��C��
    SAPCSVKB        As String * 1       '�̔��v��CSV�o��
    TRIUPDKB        As String * 1       '�����}�X�^�X�V
    NHSUPDKB        As String * 1       '�[����}�X�^�X�V
    HINUPDKB        As String * 1       '���i�}�X�^�X�V
    SIKUPDKB        As String * 1       '�d�؊֘A�}�X�^�X�V
    TUPUPDKB        As String * 1       '�C�O�̔��P���}�X�^�X�V
    SUPUPDKB        As String * 1       '�d���P���}�X�^�X�V
    SBNUPDKB        As String * 1       '���ԃ}�X�^�X�V
    BMNUPDKB        As String * 1       '����}�X�^�X�V
    TANUPDKB        As String * 1       '�S���҃}�X�^�X�V
    KNGUPDKB        As String * 1       '�����}�X�^�X�V
    BNKUPDKB        As String * 1       '��s�}�X�^�X�V
    SOUUPDKB        As String * 1       '�q�Ƀ}�X�^�X�V
    MEIUPDKB        As String * 1       '���̃}�X�^�X�V
    FIXUPDKB        As String * 1       '�Œ�l�}�X�^�X�V
    TUKUPDKB        As String * 1       '���[�g�}�X�^�X�V
    UNTUPDKB        As String * 1       '�P�ʃ}�X�^�X�V
    CLDUPDKB        As String * 1       '�J�����_�[�}�X�^�X�V
    TAXUPDKB        As String * 1       '����ŗ��}�X�^�X�V
    TZNUPDKB        As String * 1       '���Ӑ�c���X�V
    SZNUPDKB        As String * 1       '�d����c���X�V
    JDNUPDKB        As String * 1       '�󒍍X�V
    HDNUPDKB        As String * 1       '�����X�V
    YOBKBA          As String * 1       '�\���敪A
    YOBKBB          As String * 1       '�\���敪B
    YOBKBC          As String * 1       '�\���敪C
    YOBKBD          As String * 1       '�\���敪D
    YOBKBE          As String * 1       '�\���敪E
    RELFL           As String * 1       '�A�g�t���O
    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
    CLTID           As String * 5       '�N���C�A���g�h�c
    WRTTM           As String * 6       '�^�C���X�^���v�i���ԁj
    WRTDT           As String * 8       '�^�C���X�^���v�i���t�j
    WRTFSTTM        As String * 6       '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT        As String * 8       '�^�C���X�^���v�i�o�^���j
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_KNGMTA_Clear
    '   �T�v�F  �����}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_KNGMTA_Clear(ByRef pot_DB_KNGMTA As TYPE_DB_KNGMTA)

        Dim Clr_DB_KNGMTA As TYPE_DB_KNGMTA
    
        pot_DB_KNGMTA = Clr_DB_KNGMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function KNGMTA_SEARCH
    '   �T�v�F  �����}�X�^����
    '   �����F  pin_strKNGGRCD�@ : �����O���[�v
    '   �@�@�@�@pot_DB_KNGMTA  �@: ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function KNGMTA_SEARCH(ByVal pin_strKNGGRCD As String, _
                                  ByRef pot_DB_KNGMTA As TYPE_DB_KNGMTA) As Integer

        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTGRPCD       As String

    On Error GoTo ERR_KNGMTA_SEARCH
    
        KNGMTA_SEARCH = 9
        
        Call DB_KNGMTA_Clear(pot_DB_KNGMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from KNGMTA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and KNGGRCD = '" & CF_Ora_Sgl(pin_strKNGGRCD) & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            KNGMTA_SEARCH = 1
            GoTo END_KNGMTA_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_KNGMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .KNGGRCD = CF_Ora_GetDyn(Usr_Ody, "KNGGRCD", "")                '�����O���[�v
                .SALTKKB = CF_Ora_GetDyn(Usr_Ody, "SALTKKB", "")                '�̔��P���ύX
                .HDNTKKB = CF_Ora_GetDyn(Usr_Ody, "HDNTKKB", "")                '�����P���ύX
                .SAPMODKB = CF_Ora_GetDyn(Usr_Ody, "SAPMODKB", "")              '�̔��v��N���v��C��
                .SAPCSVKB = CF_Ora_GetDyn(Usr_Ody, "SAPCSVKB", "")              '�̔��v��CSV�o��
                .TRIUPDKB = CF_Ora_GetDyn(Usr_Ody, "TRIUPDKB", "")              '�����}�X�^�X�V
                .NHSUPDKB = CF_Ora_GetDyn(Usr_Ody, "NHSUPDKB", "")              '�[����}�X�^�X�V
                .HINUPDKB = CF_Ora_GetDyn(Usr_Ody, "HINUPDKB", "")              '���i�}�X�^�X�V
                .SIKUPDKB = CF_Ora_GetDyn(Usr_Ody, "SIKUPDKB", "")              '�d�؊֘A�}�X�^�X�V
                .TUPUPDKB = CF_Ora_GetDyn(Usr_Ody, "TUPUPDKB", "")              '�C�O�̔��P���}�X�^�X�V
                .SUPUPDKB = CF_Ora_GetDyn(Usr_Ody, "SUPUPDKB", "")              '�d���P���}�X�^�X�V
                .SBNUPDKB = CF_Ora_GetDyn(Usr_Ody, "SBNUPDKB", "")              '���ԃ}�X�^�X�V
                .BMNUPDKB = CF_Ora_GetDyn(Usr_Ody, "BMNUPDKB", "")              '����}�X�^�X�V
                .TANUPDKB = CF_Ora_GetDyn(Usr_Ody, "TANUPDKB", "")              '�S���҃}�X�^�X�V
                .KNGUPDKB = CF_Ora_GetDyn(Usr_Ody, "KNGUPDKB", "")              '�����}�X�^�X�V
                .BNKUPDKB = CF_Ora_GetDyn(Usr_Ody, "BNKUPDKB", "")              '��s�}�X�^�X�V
                .SOUUPDKB = CF_Ora_GetDyn(Usr_Ody, "SOUUPDKB", "")              '�q�Ƀ}�X�^�X�V
                .MEIUPDKB = CF_Ora_GetDyn(Usr_Ody, "MEIUPDKB", "")              '���̃}�X�^�X�V
                .FIXUPDKB = CF_Ora_GetDyn(Usr_Ody, "FIXUPDKB", "")              '�Œ�l�}�X�^�X�V
                .TUKUPDKB = CF_Ora_GetDyn(Usr_Ody, "TUKUPDKB", "")              '���[�g�}�X�^�X�V
                .UNTUPDKB = CF_Ora_GetDyn(Usr_Ody, "UNTUPDKB", "")              '�P�ʃ}�X�^�X�V
                .CLDUPDKB = CF_Ora_GetDyn(Usr_Ody, "CLDUPDKB", "")              '�J�����_�[�}�X�^�X�V
                .TAXUPDKB = CF_Ora_GetDyn(Usr_Ody, "TAXUPDKB", "")              '����ŗ��}�X�^�X�V
                .TZNUPDKB = CF_Ora_GetDyn(Usr_Ody, "TZNUPDKB", "")              '���Ӑ�c���X�V
                .SZNUPDKB = CF_Ora_GetDyn(Usr_Ody, "SZNUPDKB", "")              '�d����c���X�V
                .JDNUPDKB = CF_Ora_GetDyn(Usr_Ody, "JDNUPDKB", "")              '�󒍍X�V
                .HDNUPDKB = CF_Ora_GetDyn(Usr_Ody, "HDNUPDKB", "")              '�����X�V
                .YOBKBA = CF_Ora_GetDyn(Usr_Ody, "YOBKBA", "")                  '�\���敪A
                .YOBKBB = CF_Ora_GetDyn(Usr_Ody, "YOBKBB", "")                  '�\���敪B
                .YOBKBC = CF_Ora_GetDyn(Usr_Ody, "YOBKBC", "")                  '�\���敪C
                .YOBKBD = CF_Ora_GetDyn(Usr_Ody, "YOBKBD", "")                  '�\���敪D
                .YOBKBE = CF_Ora_GetDyn(Usr_Ody, "YOBKBE", "")                  '�\���敪E
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If
        
        KNGMTA_SEARCH = 0
        
END_KNGMTA_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_KNGMTA_SEARCH:
        GoTo END_KNGMTA_SEARCH
        
    End Function

