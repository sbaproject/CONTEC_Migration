Attribute VB_Name = "TANMTA_DBM"
        Option Explicit
'==========================================================================
'   TANMTA.DBM   �S���҃}�X�^                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TANMTA
    DATKB           As String * 1       '�`�[�폜�敪
    TANMSTKB        As String * 1       '�}�X�^�敪�i�S���ҁj
    TANCD           As String * 6       '�S���҃R�[�h
    MAETANCD        As String * 6       '�O��S���҃R�[�h
    MMTANCD         As String * 6       '�O�X��S���҃R�[�h
    TANNM           As String * 40      '�S���Җ�
    TANNK           As String * 10      '�S���Җ��̃J�i
    TANCLAKB        As String * 1       '�c�ƒS���҃t���O
    TANCLBKB        As String * 1       '���c�ƒS���҃t���O
    TANCLCKB        As String * 1       '���ދ敪�R�i�S���ҁj
    TANCLAID        As String * 6       '���ރR�[�h�P�i�S���ҁj
    TANCLBID        As String * 6       '���ރR�[�h�Q�i�S���ҁj
    TANCLCID        As String * 6       '���ރR�[�h�R�i�S���ҁj
    TANCLANM        As String * 20      '���ޖ��̂P�i�S���ҁj
    TANCLBNM        As String * 20      '���ޖ��̂Q�i�S���ҁj
    TANCLCNM        As String * 20      '���ޖ��̂R�i�S���ҁj
    TANBMNCD        As String * 6       '��������R�[�h
    KEIBMNCD        As String * 6       '�o������R�[�h
    TANMLAD         As String * 50      '���[���A�h���X
    KNGGRCD         As String * 3       '�����O���[�v
    TANTKDT         As String * 8       '�K�p��
    OLDBMNCD        As String * 6       '����������R�[�h
    OLDGRCD         As String * 3       '�������O���[�v
    TANDELDT        As String * 8       '�폜�N����
    RELFL           As String * 1       '�A�g�t���O
    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
    CLTID           As String * 5       '�N���C�A���g�h�c
    WRTTM           As String * 6       '�^�C���X�^���v�i���ԁj
    WRTDT           As String * 8       '�^�C���X�^���v�i���t�j
    WRTFSTTM        As String * 6       '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT        As String * 8       '�^�C���X�^���v�i�o�^���j
End Type
Global DB_TANMTA As TYPE_DB_TANMTA
Global DBN_TANMTA As Integer

' === 20060828 === INSERT S - ACE)Sejima
Public WLSTAN_TANTKDT       As String           '�K�p��
' === 20060828 === INSERT E
' === 20061204 === INSERT S - ACE)Nagasawa ����/�󒍂ł͉c�ƒS���҂̂ݕ\��
Public WLSTAN_TANCLAKB      As String           '�c�ƒS���Ҍ����t���O(��:�S���\�� "1":�c�ƒS���҂̂�)
' === 20061204 === INSERT E -

'�S���҃}�X�^�����߂�l
Public WLSTAN_RTNCODE       As String           '�S���҃R�[�h

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_TANMTA_Clear
    '   �T�v�F  �S���҃}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_TANMTA_Clear(ByRef pot_DB_TANMTA As TYPE_DB_TANMTA)

        Dim Clr_DB_TANMTA As TYPE_DB_TANMTA
    
        pot_DB_TANMTA = Clr_DB_TANMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPTANCD_SEARCH
    '   �T�v�F  �S���҃R�[�h����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTANCD_SEARCH(ByVal pin_strTANCD As String, _
                                    ByRef pot_DB_TANMTA As TYPE_DB_TANMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody_LC      As U_Ody

    On Error GoTo ERR_DSPTANCD_SEARCH
    
        DSPTANCD_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TANMTA "
        strSQL = strSQL & "  Where TANCD = '" & pin_strTANCD & "' "
        

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
 
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '�擾�f�[�^�Ȃ�
            DSPTANCD_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody_LC) = False Then
            With pot_DB_TANMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")                    '�`�[�폜�敪
                .TANMSTKB = CF_Ora_GetDyn(Usr_Ody_LC, "TANMSTKB", "")              '�}�X�^�敪�i�S���ҁj
                .TANCD = CF_Ora_GetDyn(Usr_Ody_LC, "TANCD", "")                    '�S���҃R�[�h
                .MAETANCD = CF_Ora_GetDyn(Usr_Ody_LC, "MAETANCD", "")              '�O��S���҃R�[�h
                .MMTANCD = CF_Ora_GetDyn(Usr_Ody_LC, "MMTANCD", "")                '�O�X��S���҃R�[�h
                .TANNM = CF_Ora_GetDyn(Usr_Ody_LC, "TANNM", "")                    '�S���Җ�
                .TANNK = CF_Ora_GetDyn(Usr_Ody_LC, "TANNK", "")                    '�S���Җ��̃J�i
                .TANCLAKB = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLAKB", "")              '�c�ƒS���҃t���O
                .TANCLBKB = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLBKB", "")              '���c�ƒS���҃t���O
                .TANCLCKB = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLCKB", "")              '���ދ敪�R�i�S���ҁj
                .TANCLAID = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLAID", "")              '���ރR�[�h�P�i�S���ҁj
                .TANCLBID = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLBID", "")              '���ރR�[�h�Q�i�S���ҁj
                .TANCLCID = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLCID", "")              '���ރR�[�h�R�i�S���ҁj
                .TANCLANM = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLANM", "")              '���ޖ��̂P�i�S���ҁj
                .TANCLBNM = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLBNM", "")              '���ޖ��̂Q�i�S���ҁj
                .TANCLCNM = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLCNM", "")              '���ޖ��̂R�i�S���ҁj
                .TANBMNCD = CF_Ora_GetDyn(Usr_Ody_LC, "TANBMNCD", "")              '��������R�[�h
                .KEIBMNCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEIBMNCD", "")              '�o������R�[�h
                .TANMLAD = CF_Ora_GetDyn(Usr_Ody_LC, "TANMLAD", "")                '���[���A�h���X
                .KNGGRCD = CF_Ora_GetDyn(Usr_Ody_LC, "KNGGRCD", "")                '�����O���[�v
                .TANTKDT = CF_Ora_GetDyn(Usr_Ody_LC, "TANTKDT", "")                '�K�p��
                .OLDBMNCD = CF_Ora_GetDyn(Usr_Ody_LC, "OLDBMNCD", "")              '����������R�[�h
                .OLDGRCD = CF_Ora_GetDyn(Usr_Ody_LC, "OLDGRCD", "")                '�������O���[�v
                .TANDELDT = CF_Ora_GetDyn(Usr_Ody_LC, "TANDELDT", "")              '�폜�N����
                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
        

        DSPTANCD_SEARCH = 0
        
        Exit Function
    
ERR_DSPTANCD_SEARCH:
        
        
    End Function
