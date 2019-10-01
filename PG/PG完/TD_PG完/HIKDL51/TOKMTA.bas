Attribute VB_Name = "TOKMTA_DBM"
        Option Explicit
'==========================================================================
'   TOKMTA.DBM   ���Ӑ�}�X�^                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TOKMTA
    DATKB           As String * 1       '�`�[�폜�敪
    TOKMSTKB        As String * 1       '�}�X�^�敪�i���Ӑ�j
    THSCD           As String * 1       '����敪��
    TOKCD           As String * 10      '���Ӑ�R�[�h
    TOKNMA          As String * 60      '���Ӑ於�̂P
    TOKNMB          As String * 60      '���Ӑ於�̂Q
    TOKRN           As String * 40      '���Ӑ旪��
    TOKNK           As String * 10      '���Ӑ於�̃J�i
    TOKNMC          As String * 30      '���Ӑ於�̔��p�P
    TOKNMD          As String * 30      '���Ӑ於�̔��p�Q
    TOKRNNK         As String * 20      '���Ӑ旪�̃J�i
    TOKZP           As String * 20      '���Ӑ�X�֔ԍ�
    TOKADA          As String * 60      '���Ӑ�Z���P
    TOKADB          As String * 60      '���Ӑ�Z���Q
    TOKADC          As String * 60      '���Ӑ�Z���R
    TOKTL           As String * 20      '���Ӑ�d�b�ԍ�
    TOKFX           As String * 20      '���Ӑ�e�`�w�ԍ�
    TOKBOSNM        As String * 30      '���Ӑ��\�Җ�
    TOKTANNM        As String * 30      '���Ӑ��S���Җ�
    TOKMLAD         As String * 50      '���Ӑ惁�[���A�h���X
    TANCD           As String * 6       '�S���҃R�[�h
    TANNM           As String * 40      '�S���Җ�
    LMTKN           As Currency         '�^�M���x�z
    TOKCLAKB        As String * 1       '���ދ敪�P�i���Ӑ�j
    TOKCLBKB        As String * 1       '���ދ敪�Q�i���Ӑ�j
    TOKCLCKB        As String * 1       '���ދ敪�R�i���Ӑ�j
    TOKCLAID        As String * 6       '���ރR�[�h�P�i���Ӑ�j
    TOKCLBID        As String * 6       '���ރR�[�h�Q�i���Ӑ�j
    TOKCLCID        As String * 6       '���ރR�[�h�R�i���Ӑ�j
    TOKCLANM        As String * 20      '�^�M���x�ݒ��
    TOKCLBNM        As String * 20      '���ޖ��̂Q�i���Ӑ�j
    TOKCLCNM        As String * 20      '���ޖ��̂R�i���Ӑ�j
    DSPKB           As String * 1       '�����\���敪
    TOKJUNKB        As String * 1       '���ʕ\�o�͋敪
    TOKSEICD        As String * 10      '������R�[�h
    MAINHSCD        As String * 10      '��\�[����R�[�h
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
    TOKNMMKB        As String * 1       '�����ƭ�ً敪(��)
    SKCHKB          As String * 1       '�����敪
    IKOUKB          As String * 1       '�ڍs�f�[�^�敪
    TOKLEADD        As String * 2       '�^������
    URKZANDT        As String * 8       '���|�c�����t
    URKZANKN        As Currency         '���|�c�����z
    SEIZANDT        As String * 8       '�����c�����t
    SEIZANKN        As Currency         '�����c�����z
    SMAZANDT        As String * 8       '�o�����c�����t
    SMAZANKN        As Currency         '�o�����c�����z
    SSAZANDT        As String * 8       '�����E�x�����c�����t
    SSAZANKN        As Currency         '�����E�x�����c�����z
    TOKSMEDT        As String * 8       '���������t
    SSKKZADT        As String * 8       '�����������c�����t
    SSKKZAKN        As Currency         '�����������c�����z
    OLDTOKCD        As String * 5       '�������R�[�h
    TGRPCD          As String * 10      '��\��ЃR�[�h
    OLTGRPCD        As String * 5       '����\��ЃR�[�h
    KIGYOCD         As String * 6       '�����ƃR�[�h�i���ʁj
    KGYEDACD        As String * 6       '�����ƃR�[�h�i�}�ԁj
    KAKZUKE         As String * 10      '�i�t
    BNKCD           As String * 7       '��s�R�[�h
    YKNKB           As String * 1       '�a�����
    KOZNO           As String * 7       '�����ԍ�
    HMEIGI          As String * 40      '�U�����`
    SHAKB           As String * 1       '�x���敪
    TEGSHKN         As Currency         '��`�x�����z
    TEGRT           As Currency         '��`�䗦
    NYUDD           As Currency         '�T�C�g
    TEGSHBS         As String * 1       '��`�x���ꏊ
    HTSUKB          As String * 1       '�U���萔�����S�敪
    FCTCMCD         As String * 10      '�t�@�N�^�����O��ЃR�[�h
    GYOSHU          As String * 5       '�Ǝ�
    CHIIKI          As String * 5       '�n��
    SEIHKKB         As String * 1       '���������s�敪
    TOKDNKB         As String * 1       '�q��w��`�[�敪
    TUKKB           As String * 3       '�ʉ݋敪
    BINCD           As String * 2       '�֖��R�[�h
    FRNKB           As String * 1       '�C�O����敪
    SIMUKE          As String * 5       '�d���n
    EDIKB           As String * 1       '�d�c�h�敪
    EDIKBC          As String * 1       '�d�c�h�����敪�i�������j
    EDIKBCU         As String * 1       '�d�c�h�����敪�i�������j
    EDIKBN          As String * 1       '�d�c�h�����敪�i�[���񓚁j
    EDIKBS          As String * 1       '�d�c�h�����敪�i�o�גʒm�j
    EDIKBSEI        As String * 1       '�d�c�h�����敪�i�������j
    EDIKBNYU        As String * 1       '�d�c�h�����敪�i�������j
    EDIKBP          As String * 1       '�d�c�h�����敪�i�x�����ׁj
    EDIKBYBA        As String * 1       '�d�c�h�����敪�i���i���j
    EDIKBYBB        As String * 1       '�d�c�h�����敪�i�\���Q�j
    EDIKBYBC        As String * 1       '�d�c�h�����敪�i�\���R�j
    RELFL           As String * 1       '�A�g�t���O
    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
    CLTID           As String * 5       '�N���C�A���g�h�c
    WRTTM           As String * 6       '�^�C���X�^���v�i���ԁj
    WRTDT           As String * 8       '�^�C���X�^���v�i���t�j
    WRTFSTTM        As String * 6       '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT        As String * 8       '�^�C���X�^���v�i�o�^���j
End Type
Global DB_TOKMTA As TYPE_DB_TOKMTA
Global DBN_TOKMTA As Integer

' === 20060824 === INSERT S - ACE)Sejima �����Ή�
'���Ӑ�}�X�^��������
Public WLSTOK_SKCHKB        As String           '�����敪
' === 20060824 === INSERT E
' === 20060926 === INSERT S - ACE)Nagasawa
Public WLSTOK_FRNKB         As String           '�C�O����敪
' === 20060926 === INSERT E -
'���Ӑ�}�X�^�����߂�l
Public WLSTOK_RTNCODE       As String           '���Ӑ�R�[�h

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_TOKMTA_Clear
    '   �T�v�F  ���Ӑ�}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_TOKMTA_Clear(ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA)

        Dim Clr_DB_TOKMTA As TYPE_DB_TOKMTA
    
        pot_DB_TOKMTA = Clr_DB_TOKMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPTOKCD_SEARCH
    '   �T�v�F  ���Ӑ�R�[�h����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTOKCD_SEARCH(ByVal pin_strTOKCD As String, _
                                    ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPTOKCD_SEARCH
    
        DSPTOKCD_SEARCH = 9
        
        Call DB_TOKMTA_Clear(pot_DB_TOKMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TOKMTA "
        strSQL = strSQL & "  Where TOKCD = '" & pin_strTOKCD & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPTOKCD_SEARCH = 1
            GoTo END_DSPTOKCD_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_TOKMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "")              '�}�X�^�敪�i���Ӑ�j
                .THSCD = CF_Ora_GetDyn(Usr_Ody, "THSCD", "")                    '����敪��
                .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '���Ӑ�R�[�h
                .TOKNMA = CF_Ora_GetDyn(Usr_Ody, "TOKNMA", "")                  '���Ӑ於�̂P
                .TOKNMB = CF_Ora_GetDyn(Usr_Ody, "TOKNMB", "")                  '���Ӑ於�̂Q
                .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '���Ӑ旪��
                .TOKNK = CF_Ora_GetDyn(Usr_Ody, "TOKNK", "")                    '���Ӑ於�̃J�i
                .TOKNMC = CF_Ora_GetDyn(Usr_Ody, "TOKNMC", "")                  '���Ӑ於�̔��p�P
                .TOKNMD = CF_Ora_GetDyn(Usr_Ody, "TOKNMD", "")                  '���Ӑ於�̔��p�Q
                .TOKRNNK = CF_Ora_GetDyn(Usr_Ody, "TOKRNNK", "")                '���Ӑ旪�̃J�i
                .TOKZP = CF_Ora_GetDyn(Usr_Ody, "TOKZP", "")                    '���Ӑ�X�֔ԍ�
                .TOKADA = CF_Ora_GetDyn(Usr_Ody, "TOKADA", "")                  '���Ӑ�Z���P
                .TOKADB = CF_Ora_GetDyn(Usr_Ody, "TOKADB", "")                  '���Ӑ�Z���Q
                .TOKADC = CF_Ora_GetDyn(Usr_Ody, "TOKADC", "")                  '���Ӑ�Z���R
                .TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")                    '���Ӑ�d�b�ԍ�
                .TOKFX = CF_Ora_GetDyn(Usr_Ody, "TOKFX", "")                    '���Ӑ�e�`�w�ԍ�
                .TOKBOSNM = CF_Ora_GetDyn(Usr_Ody, "TOKBOSNM", "")              '���Ӑ��\�Җ�
                .TOKTANNM = CF_Ora_GetDyn(Usr_Ody, "TOKTANNM", "")              '���Ӑ��S���Җ�
                .TOKMLAD = CF_Ora_GetDyn(Usr_Ody, "TOKMLAD", "")                '���Ӑ惁�[���A�h���X
                .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    '�S���҃R�[�h
                .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    '�S���Җ�
                .LMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", 0)                     '�^�M���x�z
                .TOKCLAKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLAKB", "")              '���ދ敪�P�i���Ӑ�j
                .TOKCLBKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLBKB", "")              '���ދ敪�Q�i���Ӑ�j
                .TOKCLCKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLCKB", "")              '���ދ敪�R�i���Ӑ�j
                .TOKCLAID = CF_Ora_GetDyn(Usr_Ody, "TOKCLAID", "")              '���ރR�[�h�P�i���Ӑ�j
                .TOKCLBID = CF_Ora_GetDyn(Usr_Ody, "TOKCLBID", "")              '���ރR�[�h�Q�i���Ӑ�j
                .TOKCLCID = CF_Ora_GetDyn(Usr_Ody, "TOKCLCID", "")              '���ރR�[�h�R�i���Ӑ�j
                .TOKCLANM = CF_Ora_GetDyn(Usr_Ody, "TOKCLANM", "")              '�^�M���x�ݒ��
                .TOKCLBNM = CF_Ora_GetDyn(Usr_Ody, "TOKCLBNM", "")              '���ޖ��̂Q�i���Ӑ�j
                .TOKCLCNM = CF_Ora_GetDyn(Usr_Ody, "TOKCLCNM", "")              '���ޖ��̂R�i���Ӑ�j
                .DSPKB = CF_Ora_GetDyn(Usr_Ody, "DSPKB", "")                    '�����\���敪
                .TOKJUNKB = CF_Ora_GetDyn(Usr_Ody, "TOKJUNKB", "")              '���ʕ\�o�͋敪
                .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")              '������R�[�h
                .MAINHSCD = CF_Ora_GetDyn(Usr_Ody, "MAINHSCD", "")              '��\�[����R�[�h
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
                .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "TOKNMMKB", "")              '�����ƭ�ً敪(��)
                .SKCHKB = CF_Ora_GetDyn(Usr_Ody, "SKCHKB", "")                  '�����敪
                .IKOUKB = CF_Ora_GetDyn(Usr_Ody, "IKOUKB", "")                  '�ڍs�f�[�^�敪
                .TOKLEADD = CF_Ora_GetDyn(Usr_Ody, "TOKLEADD", "")              '�^������
                .URKZANDT = CF_Ora_GetDyn(Usr_Ody, "URKZANDT", "")              '���|�c�����t
                .URKZANKN = CF_Ora_GetDyn(Usr_Ody, "URKZANKN", 0)               '���|�c�����z
                .SEIZANDT = CF_Ora_GetDyn(Usr_Ody, "SEIZANDT", "")              '�����c�����t
                .SEIZANKN = CF_Ora_GetDyn(Usr_Ody, "SEIZANKN", 0)               '�����c�����z
                .SMAZANDT = CF_Ora_GetDyn(Usr_Ody, "SMAZANDT", "")              '�o�����c�����t
                .SMAZANKN = CF_Ora_GetDyn(Usr_Ody, "SMAZANKN", 0)               '�o�����c�����z
                .SSAZANDT = CF_Ora_GetDyn(Usr_Ody, "SSAZANDT", "")              '�����E�x�����c�����t
                .SSAZANKN = CF_Ora_GetDyn(Usr_Ody, "SSAZANKN", 0)               '�����E�x�����c�����z
                .TOKSMEDT = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDT", "")              '���������t
                .SSKKZADT = CF_Ora_GetDyn(Usr_Ody, "SSKKZADT", "")              '�����������c�����t
'���C�A�E�g���C�������܂Ŏb��
'''                .SSKKZAKN = CF_Ora_GetDyn(Usr_Ody, "SSKKZAKN", 0)               '�����������c�����z
                .OLDTOKCD = CF_Ora_GetDyn(Usr_Ody, "OLDTOKCD", "")              '�������R�[�h
                .TGRPCD = CF_Ora_GetDyn(Usr_Ody, "TGRPCD", "")                  '��\��ЃR�[�h
                .OLTGRPCD = CF_Ora_GetDyn(Usr_Ody, "OLTGRPCD", "")              '����\��ЃR�[�h
                .KIGYOCD = CF_Ora_GetDyn(Usr_Ody, "KIGYOCD", "")                '�����ƃR�[�h�i���ʁj
                .KGYEDACD = CF_Ora_GetDyn(Usr_Ody, "KGYEDACD", "")              '�����ƃR�[�h�i�}�ԁj
                .KAKZUKE = CF_Ora_GetDyn(Usr_Ody, "KAKZUKE", "")                '�i�t
                .BNKCD = CF_Ora_GetDyn(Usr_Ody, "BNKCD", "")                    '��s�R�[�h
                .YKNKB = CF_Ora_GetDyn(Usr_Ody, "YKNKB", "")                    '�a�����
                .KOZNO = CF_Ora_GetDyn(Usr_Ody, "KOZNO", "")                    '�����ԍ�
                .HMEIGI = CF_Ora_GetDyn(Usr_Ody, "HMEIGI", "")                  '�U�����`
                .SHAKB = CF_Ora_GetDyn(Usr_Ody, "SHAKB", "")                    '�x���敪
                .TEGSHKN = CF_Ora_GetDyn(Usr_Ody, "TEGSHKN", 0)                 '��`�x�����z
                .TEGRT = CF_Ora_GetDyn(Usr_Ody, "TEGRT", 0)                     '��`�䗦
                .NYUDD = CF_Ora_GetDyn(Usr_Ody, "NYUDD", 0)                     '�T�C�g
                .TEGSHBS = CF_Ora_GetDyn(Usr_Ody, "TEGSHBS", "")                '��`�x���ꏊ
                .HTSUKB = CF_Ora_GetDyn(Usr_Ody, "HTSUKB", "")                  '�U���萔�����S�敪
                .FCTCMCD = CF_Ora_GetDyn(Usr_Ody, "FCTCMCD", "")                '�t�@�N�^�����O��ЃR�[�h
                .GYOSHU = CF_Ora_GetDyn(Usr_Ody, "GYOSHU", "")                  '�Ǝ�
                .CHIIKI = CF_Ora_GetDyn(Usr_Ody, "CHIIKI", "")                  '�n��
                .SEIHKKB = CF_Ora_GetDyn(Usr_Ody, "SEIHKKB", "")                '���������s�敪
                .TOKDNKB = CF_Ora_GetDyn(Usr_Ody, "TOKDNKB", "")                '�q��w��`�[�敪
                .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "")                    '�ʉ݋敪
                .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "")                    '�֖��R�[�h
                .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "")                    '�C�O����敪
                .SIMUKE = CF_Ora_GetDyn(Usr_Ody, "SIMUKE", "")                  '�d���n
                .EDIKB = CF_Ora_GetDyn(Usr_Ody, "EDIKB", "")                    '�d�c�h�敪
                .EDIKBC = CF_Ora_GetDyn(Usr_Ody, "EDIKBC", "")                  '�d�c�h�����敪�i�������j
                .EDIKBCU = CF_Ora_GetDyn(Usr_Ody, "EDIKBCU", "")                '�d�c�h�����敪�i�������j
                .EDIKBN = CF_Ora_GetDyn(Usr_Ody, "EDIKBN", "")                  '�d�c�h�����敪�i�[���񓚁j
                .EDIKBS = CF_Ora_GetDyn(Usr_Ody, "EDIKBS", "")                  '�d�c�h�����敪�i�o�גʒm�j
                .EDIKBSEI = CF_Ora_GetDyn(Usr_Ody, "EDIKBSEI", "")              '�d�c�h�����敪�i�������j
                .EDIKBNYU = CF_Ora_GetDyn(Usr_Ody, "EDIKBNYU", "")              '�d�c�h�����敪�i�������j
                .EDIKBP = CF_Ora_GetDyn(Usr_Ody, "EDIKBP", "")                  '�d�c�h�����敪�i�x�����ׁj
                .EDIKBYBA = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBA", "")              '�d�c�h�����敪�i���i���j
                .EDIKBYBB = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBB", "")              '�d�c�h�����敪�i�\���Q�j
                .EDIKBYBC = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBC", "")              '�d�c�h�����敪�i�\���R�j
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If
        
        DSPTOKCD_SEARCH = 0
        
END_DSPTOKCD_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_DSPTOKCD_SEARCH:
        GoTo END_DSPTOKCD_SEARCH
        
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPTOKRN_SEARCH
    '   �T�v�F  ���Ӑ旪�̌���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTOKRN_SEARCH(ByVal pin_strTOKRN As String, _
                                    ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPTOKRN_SEARCH
    
        DSPTOKRN_SEARCH = 9
        
        Call DB_TOKMTA_Clear(pot_DB_TOKMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TOKMTA "
' === 20070219 === UPDATE S - ACE)Nagasawa ���Ӑ於�̕ێ��Ή�
'        strSQL = strSQL & "  Where TRIM(TOKRN) = '" & Trim(pin_strTOKRN) & "' "
        strSQL = strSQL & "  Where TOKRN = '" & CF_Ora_Sgl(pin_strTOKRN) & "' "
' === 20070219 === UPDATE E -

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPTOKRN_SEARCH = 1
            GoTo END_DSPTOKRN_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_TOKMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "")              '�}�X�^�敪�i���Ӑ�j
                .THSCD = CF_Ora_GetDyn(Usr_Ody, "THSCD", "")                    '����敪��
                .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '���Ӑ�R�[�h
                .TOKNMA = CF_Ora_GetDyn(Usr_Ody, "TOKNMA", "")                  '���Ӑ於�̂P
                .TOKNMB = CF_Ora_GetDyn(Usr_Ody, "TOKNMB", "")                  '���Ӑ於�̂Q
                .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '���Ӑ旪��
                .TOKNK = CF_Ora_GetDyn(Usr_Ody, "TOKNK", "")                    '���Ӑ於�̃J�i
                .TOKNMC = CF_Ora_GetDyn(Usr_Ody, "TOKNMC", "")                  '���Ӑ於�̔��p�P
                .TOKNMD = CF_Ora_GetDyn(Usr_Ody, "TOKNMD", "")                  '���Ӑ於�̔��p�Q
                .TOKRNNK = CF_Ora_GetDyn(Usr_Ody, "TOKRNNK", "")                '���Ӑ旪�̃J�i
                .TOKZP = CF_Ora_GetDyn(Usr_Ody, "TOKZP", "")                    '���Ӑ�X�֔ԍ�
                .TOKADA = CF_Ora_GetDyn(Usr_Ody, "TOKADA", "")                  '���Ӑ�Z���P
                .TOKADB = CF_Ora_GetDyn(Usr_Ody, "TOKADB", "")                  '���Ӑ�Z���Q
                .TOKADC = CF_Ora_GetDyn(Usr_Ody, "TOKADC", "")                  '���Ӑ�Z���R
                .TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")                    '���Ӑ�d�b�ԍ�
                .TOKFX = CF_Ora_GetDyn(Usr_Ody, "TOKFX", "")                    '���Ӑ�e�`�w�ԍ�
                .TOKBOSNM = CF_Ora_GetDyn(Usr_Ody, "TOKBOSNM", "")              '���Ӑ��\�Җ�
                .TOKTANNM = CF_Ora_GetDyn(Usr_Ody, "TOKTANNM", "")              '���Ӑ��S���Җ�
                .TOKMLAD = CF_Ora_GetDyn(Usr_Ody, "TOKMLAD", "")                '���Ӑ惁�[���A�h���X
                .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    '�S���҃R�[�h
                .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    '�S���Җ�
                .LMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", 0)                     '�^�M���x�z
                .TOKCLAKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLAKB", "")              '���ދ敪�P�i���Ӑ�j
                .TOKCLBKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLBKB", "")              '���ދ敪�Q�i���Ӑ�j
                .TOKCLCKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLCKB", "")              '���ދ敪�R�i���Ӑ�j
                .TOKCLAID = CF_Ora_GetDyn(Usr_Ody, "TOKCLAID", "")              '���ރR�[�h�P�i���Ӑ�j
                .TOKCLBID = CF_Ora_GetDyn(Usr_Ody, "TOKCLBID", "")              '���ރR�[�h�Q�i���Ӑ�j
                .TOKCLCID = CF_Ora_GetDyn(Usr_Ody, "TOKCLCID", "")              '���ރR�[�h�R�i���Ӑ�j
                .TOKCLANM = CF_Ora_GetDyn(Usr_Ody, "TOKCLANM", "")              '�^�M���x�ݒ��
                .TOKCLBNM = CF_Ora_GetDyn(Usr_Ody, "TOKCLBNM", "")              '���ޖ��̂Q�i���Ӑ�j
                .TOKCLCNM = CF_Ora_GetDyn(Usr_Ody, "TOKCLCNM", "")              '���ޖ��̂R�i���Ӑ�j
                .DSPKB = CF_Ora_GetDyn(Usr_Ody, "DSPKB", "")                    '�����\���敪
                .TOKJUNKB = CF_Ora_GetDyn(Usr_Ody, "TOKJUNKB", "")              '���ʕ\�o�͋敪
                .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")              '������R�[�h
                .MAINHSCD = CF_Ora_GetDyn(Usr_Ody, "MAINHSCD", "")              '��\�[����R�[�h
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
                .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "TOKNMMKB", "")              '�����ƭ�ً敪(��)
                .SKCHKB = CF_Ora_GetDyn(Usr_Ody, "SKCHKB", "")                  '�����敪
                .IKOUKB = CF_Ora_GetDyn(Usr_Ody, "IKOUKB", "")                  '�ڍs�f�[�^�敪
                .TOKLEADD = CF_Ora_GetDyn(Usr_Ody, "TOKLEADD", "")              '�^������
                .URKZANDT = CF_Ora_GetDyn(Usr_Ody, "URKZANDT", "")              '���|�c�����t
                .URKZANKN = CF_Ora_GetDyn(Usr_Ody, "URKZANKN", 0)               '���|�c�����z
                .SEIZANDT = CF_Ora_GetDyn(Usr_Ody, "SEIZANDT", "")              '�����c�����t
                .SEIZANKN = CF_Ora_GetDyn(Usr_Ody, "SEIZANKN", 0)               '�����c�����z
                .SMAZANDT = CF_Ora_GetDyn(Usr_Ody, "SMAZANDT", "")              '�o�����c�����t
                .SMAZANKN = CF_Ora_GetDyn(Usr_Ody, "SMAZANKN", 0)               '�o�����c�����z
                .SSAZANDT = CF_Ora_GetDyn(Usr_Ody, "SSAZANDT", "")              '�����E�x�����c�����t
                .SSAZANKN = CF_Ora_GetDyn(Usr_Ody, "SSAZANKN", 0)               '�����E�x�����c�����z
                .TOKSMEDT = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDT", "")              '���������t
                .SSKKZADT = CF_Ora_GetDyn(Usr_Ody, "SSKKZADT", "")              '�����������c�����t
'���C�A�E�g���C�������܂Ŏb��
'''                .SSKKZAKN = CF_Ora_GetDyn(Usr_Ody, "SSKKZAKN", 0)               '�����������c�����z
                .OLDTOKCD = CF_Ora_GetDyn(Usr_Ody, "OLDTOKCD", "")              '�������R�[�h
                .TGRPCD = CF_Ora_GetDyn(Usr_Ody, "TGRPCD", "")                  '��\��ЃR�[�h
                .OLTGRPCD = CF_Ora_GetDyn(Usr_Ody, "OLTGRPCD", "")              '����\��ЃR�[�h
                .KIGYOCD = CF_Ora_GetDyn(Usr_Ody, "KIGYOCD", "")                '�����ƃR�[�h�i���ʁj
                .KGYEDACD = CF_Ora_GetDyn(Usr_Ody, "KGYEDACD", "")              '�����ƃR�[�h�i�}�ԁj
                .KAKZUKE = CF_Ora_GetDyn(Usr_Ody, "KAKZUKE", "")                '�i�t
                .BNKCD = CF_Ora_GetDyn(Usr_Ody, "BNKCD", "")                    '��s�R�[�h
                .YKNKB = CF_Ora_GetDyn(Usr_Ody, "YKNKB", "")                    '�a�����
                .KOZNO = CF_Ora_GetDyn(Usr_Ody, "KOZNO", "")                    '�����ԍ�
                .HMEIGI = CF_Ora_GetDyn(Usr_Ody, "HMEIGI", "")                  '�U�����`
                .SHAKB = CF_Ora_GetDyn(Usr_Ody, "SHAKB", "")                    '�x���敪
                .TEGSHKN = CF_Ora_GetDyn(Usr_Ody, "TEGSHKN", 0)                 '��`�x�����z
                .TEGRT = CF_Ora_GetDyn(Usr_Ody, "TEGRT", 0)                     '��`�䗦
                .NYUDD = CF_Ora_GetDyn(Usr_Ody, "NYUDD", 0)                     '�T�C�g
                .TEGSHBS = CF_Ora_GetDyn(Usr_Ody, "TEGSHBS", "")                '��`�x���ꏊ
                .HTSUKB = CF_Ora_GetDyn(Usr_Ody, "HTSUKB", "")                  '�U���萔�����S�敪
                .FCTCMCD = CF_Ora_GetDyn(Usr_Ody, "FCTCMCD", "")                '�t�@�N�^�����O��ЃR�[�h
                .GYOSHU = CF_Ora_GetDyn(Usr_Ody, "GYOSHU", "")                  '�Ǝ�
                .CHIIKI = CF_Ora_GetDyn(Usr_Ody, "CHIIKI", "")                  '�n��
                .SEIHKKB = CF_Ora_GetDyn(Usr_Ody, "SEIHKKB", "")                '���������s�敪
                .TOKDNKB = CF_Ora_GetDyn(Usr_Ody, "TOKDNKB", "")                '�q��w��`�[�敪
                .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "")                    '�ʉ݋敪
                .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "")                    '�֖��R�[�h
                .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "")                    '�C�O����敪
                .SIMUKE = CF_Ora_GetDyn(Usr_Ody, "SIMUKE", "")                  '�d���n
                .EDIKB = CF_Ora_GetDyn(Usr_Ody, "EDIKB", "")                    '�d�c�h�敪
                .EDIKBC = CF_Ora_GetDyn(Usr_Ody, "EDIKBC", "")                  '�d�c�h�����敪�i�������j
                .EDIKBCU = CF_Ora_GetDyn(Usr_Ody, "EDIKBCU", "")                '�d�c�h�����敪�i�������j
                .EDIKBN = CF_Ora_GetDyn(Usr_Ody, "EDIKBN", "")                  '�d�c�h�����敪�i�[���񓚁j
                .EDIKBS = CF_Ora_GetDyn(Usr_Ody, "EDIKBS", "")                  '�d�c�h�����敪�i�o�גʒm�j
                .EDIKBSEI = CF_Ora_GetDyn(Usr_Ody, "EDIKBSEI", "")              '�d�c�h�����敪�i�������j
                .EDIKBNYU = CF_Ora_GetDyn(Usr_Ody, "EDIKBNYU", "")              '�d�c�h�����敪�i�������j
                .EDIKBP = CF_Ora_GetDyn(Usr_Ody, "EDIKBP", "")                  '�d�c�h�����敪�i�x�����ׁj
                .EDIKBYBA = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBA", "")              '�d�c�h�����敪�i���i���j
                .EDIKBYBB = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBB", "")              '�d�c�h�����敪�i�\���Q�j
                .EDIKBYBC = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBC", "")              '�d�c�h�����敪�i�\���R�j
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If
        
        DSPTOKRN_SEARCH = 0
        
END_DSPTOKRN_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_DSPTOKRN_SEARCH:
        
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPLMTKN_SEARCH
    '   �T�v�F  �^�M���x�z����
    '   �����F�@pin_strTOKCD  : ���Ӑ�R�[�h
    '           pin_strTGRPCD : ���Ӑ�O���[�v�R�[�h
    '           pot_curLMTKN  : �^�M���x�z
    '   �ߒl�F�@0:����I�� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPLMTKN_SEARCH(ByVal pin_strTOKCD As String, _
                                    ByVal pin_strTGRPCD As String, _
                                    ByRef pot_curLMTKN As Currency) As Integer

        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTOKCD_Where  As String

    On Error GoTo ERR_DSPLMTKN_SEARCH
    
        DSPLMTKN_SEARCH = 9
        pot_curLMTKN = 0
        
        If Trim(pin_strTGRPCD) = "" Then
            strTOKCD_Where = pin_strTOKCD
        Else
            strTOKCD_Where = pin_strTGRPCD
        End If
        
        strSQL = ""
        strSQL = strSQL & " Select LMTKN "
        strSQL = strSQL & "   from TOKMTA "
        strSQL = strSQL & "  Where DATKB        = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and TRIM(TOKCD)  = '" & Trim(strTOKCD_Where) & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = False Then
            pot_curLMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", "")                  '�^�M���x�z
            DSPLMTKN_SEARCH = 0
            
            GoTo END_DSPLMTKN_SEARCH
        End If
            
        '�擾�f�[�^�����݂��Ȃ������ꍇ�ŁA�������e�ȊO�̏ꍇ
        If strTOKCD_Where <> pin_strTOKCD Then
            '�N���[�Y
            Call CF_Ora_CloseDyn(Usr_Ody)
            
            strSQL = ""
            strSQL = strSQL & " Select LMTKN "
            strSQL = strSQL & "   from TOKMTA "
            strSQL = strSQL & "  Where DATKB        = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "    and TRIM(TOKCD)  = '" & Trim(pin_strTOKCD) & "' "
        
           'DB�A�N�Z�X
           Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    
           If CF_Ora_EOF(Usr_Ody) = False Then
               pot_curLMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", "")                  '�^�M���x�z
           End If
        End If
        
        DSPLMTKN_SEARCH = 0
        
END_DSPLMTKN_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_DSPLMTKN_SEARCH:
        
    End Function


