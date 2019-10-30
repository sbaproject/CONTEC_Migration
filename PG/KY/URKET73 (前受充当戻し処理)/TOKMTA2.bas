Attribute VB_Name = "TOKMTA_DBM"
        Option Explicit
'==========================================================================
'   TOKMTA.DBM   ���Ӑ�}�X�^                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TOKMTA
    DATKB          As String * 1     '�`�[�폜�敪          0
    TOKMSTKB       As String * 1     '�}�X�^�敪(���Ӑ�)    0
    THSCD          As String * 1     '����敪��            0
    TOKCD          As String * 10    '���Ӑ�R�[�h          !@@@@@@@@@@
    TOKNMA         As String * 60    '���Ӑ於�̂P
    TOKNMB         As String * 60    '���Ӑ於�̂Q
    TOKRN          As String * 40    '���Ӑ旪��
    TOKNK          As String * 10    '���Ӑ於�̃J�i
    TOKNMC         As String * 30    '���Ӑ於�̔��p�P
    TOKNMD         As String * 30    '���Ӑ於�̔��p�Q
    TOKRNNK        As String * 20    '���Ӑ旪�̃J�i
    TOKZP          As String * 20    '���Ӑ�X�֔ԍ�
    TOKADA         As String * 60    '���Ӑ�Z���P
    TOKADB         As String * 60    '���Ӑ�Z���Q
    TOKADC         As String * 60    '���Ӑ�Z���R
    TOKTL          As String * 20    '���Ӑ�d�b�ԍ�
    TOKFX          As String * 20    '���Ӑ�e�`�w�ԍ�
    TOKBOSNM       As String * 30    '���Ӑ��\�Җ�
    TOKTANNM       As String * 30    '���Ӑ��S���Җ�
    TOKMLAD        As String * 50    '���Ӑ惁�[���A�h���X
    TANCD          As String * 6     '�S���҃R�[�h          000000
    TANNM          As String * 40    '�S���Җ�
    LMTKN          As Currency       '�^�M���x�z            ####,###,##0.0000;;#
    TOKCLAKB       As String * 1     '���ދ敪�P�i���Ӑ�j  0
    TOKCLBKB       As String * 1     '���ދ敪�Q�i���Ӑ�j  0
    TOKCLCKB       As String * 1     '���ދ敪�R�i���Ӑ�j  0
    TOKCLAID       As String * 6     '���ރR�[�h�P(���Ӑ�)  !@@@@@@
    TOKCLBID       As String * 6     '���ރR�[�h�Q(���Ӑ�)  !@@@@@@
    TOKCLCID       As String * 6     '���ރR�[�h�R(���Ӑ�)  !@@@@@@
    TOKCLANM       As String * 20    '���ޖ��̂P(���Ӑ�)
    TOKCLBNM       As String * 20    '���ޖ��̂Q(���Ӑ�)
    TOKCLCNM       As String * 20    '���ޖ��̂R(���Ӑ�)
    DSPKB          As String * 1     '�����\���敪          0
    TOKJUNKB       As String * 1     '���ʕ\�o�͋敪        0
    TOKSEICD       As String * 10    '������R�[�h          !@@@@@@@@@@
    MAINHSCD       As String * 10    '��\�[����R�[�h      !@@@@@@@@@@
    TOKSMEKB       As String * 1     '���敪                0
    TOKSMEDD       As String * 2     '���������t(����)      DD
    TOKSMECC       As String * 2     '���T�C�N��(����)      99
    TOKSDWKB       As String * 1     '���ߗj��              0
    TOKKESCC       As String * 2     '����T�C�N��          00
    TOKKESDD       As String * 2     '������t              DD
    TOKKDWKB       As String * 1     '����j��              0
    LSTID          As String * 7     '�`�[���              !@@@@@@@
    TKNRPSKB       As String * 1     '���z�[����������      0
    TKNZRNKB       As String * 1     '���z�[�������敪      0
    TOKZEIKB       As String * 1     '����ŋ敪            0
    TOKZCLKB       As String * 1     '����ŎZ�o�敪        0
    TOKRPSKB       As String * 1     '����Œ[����������    0
    TOKZRNKB       As String * 1     '����Œ[�������敪    0
    TOKNMMKB       As String * 1     '�����ƭ�ً敪�i���j   0
    SKCHKB         As String * 1     '�����敪              0
    IKOUKB         As String * 1     '�ڍs�f�[�^�敪        0
    TOKLEADD       As String * 2     '�^������              DD
    URKZANDT       As String * 8     '���|�c�����t          YYYY/MM/DD
    URKZANKN       As Currency       '���|�c�����z          ##,###,###,###
    SEIZANDT       As String * 8     '�����c�����t          YYYY/MM/DD
    SEIZANKN       As Currency       '�����c�����z          ##,###,###,###
    SMAZANDT       As String * 8     '�o�����c�����t        YYYY/MM/DD
    SMAZANKN       As Currency       '�o�����c�����z        ##,###,###,###
    SSAZANDT       As String * 8     '�����E�x�����c�����t  YYYY/MM/DD
    SSAZANKN       As Currency       '�����E�x�����c�����z  ##,###,###,###
    TOKSMEDT       As String * 8     '���������t            YYYY/MM/DD
    SSKKZADT       As String * 8     '�����������c�����t    YYYY/MM/DD
    SSKKZAKN       As Currency       '�����������c�����z    ##,###,###,###
    OLDTOKCD       As String * 5     '�������R�[�h        00000
    TGRPCD         As String * 10    '��\��ЃR�[�h        0000000000
    OLTGRPCD       As String * 5     '����\��ЃR�[�h      00000
    KIGYOCD        As String * 6     '�����ƃR�[�h����    000000
    KGYEDACD       As String * 6     '�����ƃR�[�h�}��    000000
    KAKZUKE        As String * 10    '�i�t
    BNKCD          As String * 7     '��s�R�[�h            !@@@@@@@
    YKNKB          As String * 1     '�a�����              0
    KOZNO          As String * 7     '�����ԍ�              0000000
    HMEIGI         As String * 40    '�U�����`
    SHAKB          As String * 1     '�x���敪              0
    TEGSHKN        As Currency       '��`�x�����z          ##,###,###,###
    TEGRT          As Currency       '��`�䗦              ##0.00;;#
    NYUDD          As Currency       '�T�C�g
    TEGSHBS        As String * 1     '��`�x���ꏊ          0
    HTSUKB         As String * 1     '�U���萔�����S�敪    0
    FCTCMCD        As String * 10    '�t�@�N�^�����O��ЃR  0000000000
    GYOSHU         As String * 5     '�Ǝ�                  00000
    CHIIKI         As String * 5     '�n��                  00000
    SEIHKKB        As String * 1     '���������s�敪        0
    TOKDNKB        As String * 1     '�q��w��`�[�敪      0
    TUKKB          As String * 3     '�ʉ݋敪              !@@@
    BINCD          As String * 2     '�֖��R�[�h            00
    FRNKB          As String * 1     '�C�O����敪          0
    SIMUKE         As String * 5     '�d���n                00000
    EDIKB          As String * 1     'EDI�敪               0
    EDIKBC         As String * 1     'EDI�����敪(�������  0
    EDIKBCU        As String * 1     'EDI�����敪(������    0
    EDIKBN         As String * 1     'EDI�����敪(�[����  0
    EDIKBS         As String * 1     'EDI�����敪(�o�גʒm  0
    EDIKBSEI       As String * 1     'EDI�����敪(�������  0
    EDIKBNYU       As String * 1     'EDI�����敪(�������  0
    EDIKBP         As String * 1     'EDI�����敪(�x������  0
    EDIKBYBA       As String * 1     'EDI�����敪(���i���  0
    EDIKBYBB       As String * 1     'EDI�����敪(�\���Q    0
    EDIKBYBC       As String * 1     'EDI�����敪(�\���R    0
    RELFL          As String * 1     '�A�g�t���O            0
    FOPEID         As String * 8     '����o�^հ�ްID       !@@@@@@@@
    FCLTID         As String * 5     '����o�^�ײ���ID      !@@@@@
    WRTFSTTM       As String * 6     '��ѽ����(�o�^����)    9(06)
    WRTFSTDT       As String * 8     '��ѽ����(�o�^��)      YYYY/MM/DD
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@
    WRTTM          As String * 6     '��ѽ����(����)        9(06)
    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD
    UOPEID         As String * 8     '���[�UID(�ޯ�)        !@@@@@@@@
    UCLTID         As String * 5     '�ײ���ID(�ޯ�)        !@@@@@
    UWRTTM         As String * 6     '��ѽ����(����)        9(06)
    UWRTDT         As String * 8     '��ѽ����(���t)        YYYY/MM/DD
    PGID           As String * 7     '�v���O����ID          !@@@@@@@@
    
    SHAKBNM        As String * 10    '�x���������i�[�i�I�v�V�����p�j
    HYTOKKESDD     As String * 4     '������t(�\���p)���i�[ (�I�v�V�����p)
    KESISMEDT      As String * 8     '�������ɂ����鐿���������i�[   (�X���b�V���܂�)
End Type
Global DB_TOKMTA As TYPE_DB_TOKMTA
'Global DBN_TOKMTA As Integer
' Index1( TOKCD )
' Index2( TOKNK + TOKCD )
' Index3( TOKCLAID + TOKCLBID + TOKCLCID + TOKCD )
' Index4( TOKCLBID + TOKCLCID + TOKCD )
' Index5( TOKCLCID + TOKCD )
' Index6( TANCD + TOKCD )
' Index7( TOKSEICD + TOKCD )
' Index8( DATKB + KOZNO + HMEIGI )
' Index9( TGRPCD + TOKCD )
' Index10( DATKB + KOZNO )

'Sub TOKMTA_RClear()
'Dim TmpStat
'    TmpStat = Dll_RClear(DBN_TOKMTA, G_LB)
'    Call ResetBuf(DBN_TOKMTA)
'End Sub
