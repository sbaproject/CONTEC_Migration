Attribute VB_Name = "JDNTHA_DBM"
        Option Explicit
'==========================================================================
'   JDNTHA.DBM   �󒍌��o�g����                   UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_JDNTHA
    DATNO           As String * 10      '�`�[�Ǘ���
    DATKB           As String * 1       '�`�[�폜�敪
    DENKB           As String * 1       '�`�[�敪
    JDNNO           As String * 10      '�󒍔ԍ�
    JHDNO           As String * 10      '�󔭒���
    JDNDT           As String * 8       '�󒍓`�[���t
    DENDT           As String * 8       '�󒍓��t
    DEFNOKDT        As String * 8       '�[��
    TOKCD           As String * 10      '���Ӑ�R�[�h
    TOKRN           As String * 40      '���Ӑ旪��
    NHSCD           As String * 10      '�[����R�[�h
    NHSNMA          As String * 60      '�[���於�̂P
    NHSNMB          As String * 60      '�[���於�̂Q
    TANCD           As String * 6       '�S���҃R�[�h
    TANNM           As String * 40      '�S���Җ�
    BUMCD           As String * 6       '����R�[�h
    BUMNM           As String * 40      '���喼
    TOKSEICD        As String * 10      '������R�[�h
    SOUCD           As String * 3       '�q�ɃR�[�h
    SOUNM           As String * 20      '�q�ɖ�
    ZKTKB           As String * 1       '����敪
    ZKTNM           As String * 4       '����敪��
    SMADT           As String * 8       '�o�������t
    JDNENDKB        As String * 1       '�󒍊����敪
    SBAUODKN        As Currency         '�󒍋��z�i�{�̍��v�j
    SBAUZEKN        As Currency         '�󒍋��z�i����Ŋz�j
    SBAUZKKN        As Currency         '�󒍋��z�i�`�[�v�j
    DENCM           As String * 40      '���l
    TOKSMEKB        As String * 1       '���敪
    TOKSMEDD        As String * 2       '���������t�i����j
    TOKSMECC        As String * 2       '���T�C�N���i����j
    TOKSDWKB        As String * 1       '���ߗj��
    TOKKESCC        As String * 2       '����T�C�N��
    TOKKESDD        As String * 2       '������t
    TOKKDWKB        As String * 1       '����j��
    LSTID           As String * 7       '�`�[���
    TKNRPSKB        As String * 1       '���z�[����������
    TKNZRNKB        As String * 1       '���z�[�������敪
    TOKZEIKB        As String * 1       '����ŋ敪
    TOKZCLKB        As String * 1       '����ŎZ�o�敪
    TOKRPSKB        As String * 1       '����Œ[����������
    TOKZRNKB        As String * 1       '����Œ[�������敪
    TOKNMMKB        As String * 1       '�����ƭ�ٓ��͋敪�i���Ӑ�j
    NHSNMMKB        As String * 1       '�����ƭ�ٓ��͋敪�i�[����j
    TOKMSTKB        As String * 1       '�}�X�^�敪�i���Ӑ�j
    NHSMSTKB        As String * 1       '�}�X�^�敪�i�[����j
    TANMSTKB        As String * 1       '�}�X�^�敪�i�S���ҁj
    MITNO           As String * 10      '���ϔԍ�
    MITNOV          As String * 2       '�Ő�
' === 20060726 === UPDATE S - ACE)Nagasawa
'    AKNID           As Currency         '�Č��h�c
    AKNID           As String           '�Č��h�c
' === 20060726 === UPDATE E -
    CLMDL           As String * 15      '���ތ^��
    URIKJN          As String * 1       '����
    BINCD           As String * 2       '�֖��R�[�h
    KENNMA          As String * 40      '�����P
    KENNMB          As String * 40      '�����Q
    BKTHKKB         As String * 1       '�����s�敪
    MAEUKKB         As String * 1       '�O��敪
    SEIKB           As String * 1       '�����敪
    JDNTRKB         As String * 2       '�󒍎���敪
    NHSADA          As String * 60      '�[����Z���P
    NHSADB          As String * 60      '�[����Z���Q
    NHSADC          As String * 60      '�[����Z���R
    JDNINKB         As String * 1       '�󒍎捞���
    DFKJDNNO        As String * 12      '�_�C�t�N�󒍔ԍ�
    TOKJDNNO        As String * 23      '�q�撍��No.
    HDKEIKN         As Currency         '�n�[�h�_����z
    HDSIKKN         As Currency         '�n�[�h�d�؋��z
    SFKEIKN         As Currency         '�\�t�g�_����z
    SFSIKKN         As Currency         '�\�t�g�d�؋��z
    CMPKTCD         As String * 2       '�R���s���[�^�^���R�[�h
    CMPKTNM         As String * 20      '�R���s���[�^�^����
    PRDTBMCD        As String * 6       '���Y�S������R�[�h
    TUKKB           As String * 3       '�ʉ݋敪
    SBAFRCKN        As Currency         '�O�ݎ󒍋��z�i�`�[�v�j
    JODRSNKB        As String * 3       '�󒍗��R�敪
    JODCNKB         As String * 3       '�󒍃L�����Z�����R�敪
    JSKTANCD        As String * 6       '�n����ђS���҃R�[�h
    JSKTANNM        As String * 40      '�n����ђS���Җ�
    JSKBMNCD        As String * 6       '�n����ѕ���R�[�h
    JSKBMNNM        As String * 40      '�n����ѕ��喼
    FRNKB           As String * 1       '�C�O����敪
    SIMUKE          As String * 5       '�d���n
    JDNPRKB         As String * 1       '���s�敪
    DENCMIN         As String * 40      '�Г����l
    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
    CLTID           As String * 5       '�N���C�A���g�h�c
    WRTTM           As String * 6       '�^�C���X�^���v�i���ԁj
    WRTDT           As String * 8       '�^�C���X�^���v�i���t�j
    WRTFSTTM        As String * 6       '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT        As String * 8       '�^�C���X�^���v�i�o�^���j
    JDNENDNM        As String * 6       '�󒍊����敪��
End Type
Global DB_JDNTHA As TYPE_DB_JDNTHA
Global DBN_JDNTHA As Integer
' Index1( DATNO )
' Index2( DATKB + DENKB + JDNNO )
' Index3( SMADT )
' Index4( DATKB + JDNDT + JDNNO + TOKCD )
' Index5( DATKB + TOKCD + JDNNO )
' Index6( DATKB + JDNENDKB + TOKCD + DEFNOKDT + JDNNO )

Sub JDNTHA_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_JDNTHA, G_LB)
    Call ResetBuf(DBN_JDNTHA)
End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPJDNTHA_SEARCH
    '   �T�v�F  �󒍌��o���g��������
    '   �����F�@pin_strJDNNO          :�󒍔ԍ�
    '           pot_DB_JDNTHA�@�@�@�@ :�󒍌��o���g�����f�[�^
    '           pin_strDATKB �@�@�@�@ :�`�[�폜�敪�iOptional�A�n����Ȃ��ꍇ"1"�j
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function DSPJDNTHA_SEARCH(ByVal pin_strJDNNO As String, _
                                 ByRef pot_DB_JDNTHA As TYPE_DB_JDNTHA, _
                        Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Integer

    Dim strSQL          As String
    Dim intData         As Integer
    Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPJDNTHA_SEARCH
    
    DSPJDNTHA_SEARCH = 9
    
    strSQL = ""
    strSQL = strSQL & " Select * "
    strSQL = strSQL & "   from JDNTHA "
    strSQL = strSQL & "  Where JDNNO = '" & pin_strJDNNO & "' "
    strSQL = strSQL & "  And   DATKB = '" & pin_strDATKB & "' "

    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    If CF_Ora_EOF(Usr_Ody) = True Then
        '�擾�f�[�^�Ȃ�
        DSPJDNTHA_SEARCH = 1
        Exit Function
    End If
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        With pot_DB_JDNTHA
            .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")                    '�`�[�Ǘ���
            .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
            .DENKB = CF_Ora_GetDyn(Usr_Ody, "DENKB", "")                    '�`�[�敪
            .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")                    '�󒍔ԍ�
            .JHDNO = CF_Ora_GetDyn(Usr_Ody, "JHDNO", "")                    '�󔭒���
            .JDNDT = CF_Ora_GetDyn(Usr_Ody, "JDNDT", "")                    '�󒍓`�[���t
            .DENDT = CF_Ora_GetDyn(Usr_Ody, "DENDT", "")                    '�󒍓��t
            .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "DEFNOKDT", "")              '�[��
            .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '���Ӑ�R�[�h
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '���Ӑ旪��
            .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "")                    '�[����R�[�h
            .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "")                  '�[���於�̂P
            .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "")                  '�[���於�̂Q
            .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    '�S���҃R�[�h
            .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    '�S���Җ�
            .BUMCD = CF_Ora_GetDyn(Usr_Ody, "BUMCD", "")                    '����R�[�h
            .BUMNM = CF_Ora_GetDyn(Usr_Ody, "BUMNM", "")                    '���喼
            .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")              '������R�[�h
            .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")                    '�q�ɃR�[�h
            .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")                    '�q�ɖ�
            .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "ZKTKB", "")                    '����敪
            .ZKTNM = CF_Ora_GetDyn(Usr_Ody, "ZKTNM", "")                    '����敪��
            .SMADT = CF_Ora_GetDyn(Usr_Ody, "SMADT", "")                    '�o�������t
            .JDNENDKB = CF_Ora_GetDyn(Usr_Ody, "JDNENDKB", "")              '�󒍊����敪
            .SBAUODKN = CF_Ora_GetDyn(Usr_Ody, "SBAUODKN", 0)               '�󒍋��z�i�{�̍��v�j
            .SBAUZEKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZEKN", 0)               '�󒍋��z�i����Ŋz�j
            .SBAUZKKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZKKN", 0)               '�󒍋��z�i�`�[�v�j
            .DENCM = CF_Ora_GetDyn(Usr_Ody, "DENCM", "")                    '���l
            .TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "")              '���敪
            .TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "")              '���������t�i����j
            .TOKSMECC = CF_Ora_GetDyn(Usr_Ody, "TOKSMECC", "")              '���T�C�N���i����j
            .TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "")              '���ߗj��
            .TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "")              '����T�C�N��
            .TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "")              '������t
            .TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "")              '����j��
            .LSTID = CF_Ora_GetDyn(Usr_Ody, "LSTID", "")                    '�`�[���
            .TKNRPSKB = CF_Ora_GetDyn(Usr_Ody, "TKNRPSKB", "")              '���z�[����������
            .TKNZRNKB = CF_Ora_GetDyn(Usr_Ody, "TKNZRNKB", "")              '���z�[�������敪
            .TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "")              '����ŋ敪
            .TOKZCLKB = CF_Ora_GetDyn(Usr_Ody, "TOKZCLKB", "")              '����ŎZ�o�敪
            .TOKRPSKB = CF_Ora_GetDyn(Usr_Ody, "TOKRPSKB", "")              '����Œ[����������
            .TOKZRNKB = CF_Ora_GetDyn(Usr_Ody, "TOKZRNKB", "")              '����Œ[�������敪
            .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "TOKNMMKB", "")              '�����ƭ�ٓ��͋敪�i���Ӑ�j
            .NHSNMMKB = CF_Ora_GetDyn(Usr_Ody, "NHSNMMKB", "")              '�����ƭ�ٓ��͋敪�i�[����j
            .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "")              '�}�X�^�敪�i���Ӑ�j
            .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "")              '�}�X�^�敪�i�[����j
            .TANMSTKB = CF_Ora_GetDyn(Usr_Ody, "TANMSTKB", "")              '�}�X�^�敪�i�S���ҁj
            .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "")                    '���ϔԍ�
            .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")                  '�Ő�
            .AKNID = CF_Ora_GetDyn(Usr_Ody, "AKNID", "")                    '�Č��h�c
            .CLMDL = CF_Ora_GetDyn(Usr_Ody, "CLMDL", "")                    '���ތ^��
            .URIKJN = CF_Ora_GetDyn(Usr_Ody, "URIKJN", "")                  '����
            .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "")                    '�֖��R�[�h
            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "")                  '�����P
            .KENNMB = CF_Ora_GetDyn(Usr_Ody, "KENNMB", "")                  '�����Q
            .BKTHKKB = CF_Ora_GetDyn(Usr_Ody, "BKTHKKB", "")                '�����s�敪
            .MAEUKKB = CF_Ora_GetDyn(Usr_Ody, "MAEUKKB", "")                '�O��敪
            .SEIKB = CF_Ora_GetDyn(Usr_Ody, "SEIKB", "")                    '�����敪
            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")                '�󒍎���敪
            .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "")                  '�[����Z���P
            .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "")                  '�[����Z���Q
            .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "")                  '�[����Z���R
            .JDNINKB = CF_Ora_GetDyn(Usr_Ody, "JDNINKB", "")                '�󒍎捞���
            .DFKJDNNO = CF_Ora_GetDyn(Usr_Ody, "DFKJDNNO", "")              '�_�C�t�N�󒍔ԍ�
            .TOKJDNNO = CF_Ora_GetDyn(Usr_Ody, "TOKJDNNO", "")              '�q�撍��No.
            .HDKEIKN = CF_Ora_GetDyn(Usr_Ody, "HDKEIKN", 0)                 '�n�[�h�_����z
            .HDSIKKN = CF_Ora_GetDyn(Usr_Ody, "HDSIKKN", 0)                 '�n�[�h�d�؋��z
            .SFKEIKN = CF_Ora_GetDyn(Usr_Ody, "SFKEIKN", 0)                 '�\�t�g�_����z
            .SFSIKKN = CF_Ora_GetDyn(Usr_Ody, "SFSIKKN", 0)                 '�\�t�g�d�؋��z
            .CMPKTCD = CF_Ora_GetDyn(Usr_Ody, "CMPKTCD", "")                '�R���s���[�^�^���R�[�h
            .CMPKTNM = CF_Ora_GetDyn(Usr_Ody, "CMPKTNM", "")                '�R���s���[�^�^����
            .PRDTBMCD = CF_Ora_GetDyn(Usr_Ody, "PRDTBMCD", "")              '���Y�S������R�[�h
            .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "")                    '�ʉ݋敪
            .SBAFRCKN = CF_Ora_GetDyn(Usr_Ody, "SBAFRCKN", 0)               '�O�ݎ󒍋��z�i�`�[�v�j
            .JODRSNKB = CF_Ora_GetDyn(Usr_Ody, "JODRSNKB", "")              '�󒍗��R�敪
            .JODCNKB = CF_Ora_GetDyn(Usr_Ody, "JODCNKB", "")                '�󒍃L�����Z�����R�敪
            .JSKTANCD = CF_Ora_GetDyn(Usr_Ody, "JSKTANCD", "")              '�n����ђS���҃R�[�h
            .JSKTANNM = CF_Ora_GetDyn(Usr_Ody, "JSKTANNM", "")              '�n����ђS���Җ�
            .JSKBMNCD = CF_Ora_GetDyn(Usr_Ody, "JSKBMNCD", "")              '�n����ѕ���R�[�h
            .JSKBMNNM = CF_Ora_GetDyn(Usr_Ody, "JSKBMNNM", "")              '�n����ѕ��喼
            .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "")                    '�C�O����敪
            .SIMUKE = CF_Ora_GetDyn(Usr_Ody, "SIMUKE", "")                  '�d���n
            .JDNPRKB = CF_Ora_GetDyn(Usr_Ody, "JDNPRKB", "")                '���s�敪
            .DENCMIN = CF_Ora_GetDyn(Usr_Ody, "DENCMIN", "")                '�Г����l
            .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
            .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
            .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
            .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            .JDNENDNM = CF_Ora_GetDyn(Usr_Ody, "JDNENDNM", "")              '�󒍊����敪��
        End With
    End If

    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody)
    

    DSPJDNTHA_SEARCH = 0
    
    Exit Function
    
ERR_DSPJDNTHA_SEARCH:
        
End Function


