Attribute VB_Name = "HINMTA_DBM"
        Option Explicit
'==========================================================================
'   HINMTA.DBM   ���i�}�X�^                       UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_HINMTA
    DATKB          As String * 1     '�`�[�폜�敪
    HINMSTKB       As String * 1     '�}�X�^�敪�i���i�j
    HINCD          As String * 10    '���i�R�[�h
    HINNMA         As String * 50    '�^��
    HINNMB         As String * 50    '���i���P
    HINNMC         As String * 30    '���i���Q
    HINNK          As String * 10    '���i���J�i
    HINNMD         As String * 40    '�V���[�Y���i���i���p�j
    HINNME         As String * 80    '�V���[�Y���i���i�S�p�j
    UNTCD          As String * 2     '�P�ʃR�[�h
    UNTNM          As String * 4     '�P�ʖ�
    HINKB          As String * 1     '���i�敪
    HINID          As String * 2     '���i���
    HINCLAKB       As String * 1     '���ދ敪�P�i���i�j
    HINCLBKB       As String * 1     '���ދ敪�Q�i���i�j
    HINCLCKB       As String * 1     '���ދ敪�R�i���i�j
    HINCLAID       As String * 6     '���ރR�[�h�P�i���i�j
    HINCLBID       As String * 6     '���ރR�[�h�Q�i���i�j
    HINCLCID       As String * 6     '���ރR�[�h�R�i���i�j
    HINCLANM       As String * 20    '���ޖ��̂P�i���i�j
    HINCLBNM       As String * 20    '���ޖ��̂Q�i���i�j
    HINCLCNM       As String * 20    '���ޖ��̂R�i���i�j
    DSPKB          As String * 1     '�����\���敪
    ZAIKB          As String * 1     '�݌ɊǗ��敪
    HINZEIKB       As String * 1     '���i����ŋ敪
    ZEIRNKKB       As String * 1     '����Ń����N
    ZEIRT          As Currency       '����ŗ�
    HINJUNKB       As String * 1     '���ӕ\�o�͋敪
    MAKCD          As String * 6     '���[�J�[�R�[�h
    HINCMA         As String * 20    '���i���l�`
    HINCMB         As String * 20    '���i���lB
    HINCMC         As String * 20    '���i���lC
    HINCMD         As String * 20    '���i���lD
    HINCME         As String * 20    '���i���l�d
    TEIKATK        As Currency       '�艿
    ZNKURITK       As Currency       '�Ŕ��̔��P��
    ZKMURITK       As Currency       '�ō��̔��P��
    ZNKSRETK       As Currency       '�Ŕ��d���P��
    ZKMSRETK       As Currency       '�ō��d���P��
    GNKTK          As Currency       '�����P��
    PLANTK         As Currency       '�v��P��
    OLDGNKTK       As Currency       '�������P��
    GNKTKDT        As String * 8     '�K�p��(�����P��)
    OLDPLNTK       As Currency       '���v��P��
    PLNTKDT        As String * 8     '�K�p���i�v��P��)
    SODUNTSU       As Currency       '�����P�ʐ�
    TEKZAISU       As Currency       '�K���݌ɐ�
    ANZZAISU       As Currency       '���S�݌ɐ��i�̔��v��p�j
    HRTDD          As String * 2     '�������[�h�^�C��
    ORTDD          As String * 2     '�o�׃��[�h�^�C��
    PRCDD          As String * 2     '���B���[�h�^�C��
    MNFDD          As String * 2     '�������[�h�^�C��
    HINSIRCD       As String * 10    '���i�d����R�[�h
    HINSIRRN       As String * 40    '���i�d���於��
    TNACM          As String * 10    '�I�ԍ�
    HINNMMKB       As String * 1     '�����ƭ�ٓ��͋敪(���i)
    JANCD          As String * 13    '�i�`�m�R�[�h
    HINFRNNM       As String * 50    '���i���C�O�\�L
    ZAIRNK         As String * 3     '�݌Ƀ����N
    GNKCD          As String * 3     '�����Ǘ��R�[�h
    MINSODSU       As Currency       '�ŏ�������
    SODADDSU       As Currency       '����������
    JODHIKKB       As String * 1     '�󒍈����敪
    ORTSTPKB       As String * 1     '�o�ג�~
    ORTSTPDT       As String * 8     '�o�ג�~��
    ORTKJDT        As String * 8     '�o�ג�~������
    ORTSTYDT       As String * 8     '�o�׊J�n�\���
    CTLGKB         As String * 1     '�J�^���O�i�Ώ�
    MLOKB          As String * 1     '�ʔ̑Ώ�
    MLOHINID       As String * 10    '�ʔ̐��i�h�c
    MLOIDORT       As Currency       '�ʔ̈ړ��䗦
    MLOLMTSU       As Currency       '�ʔ̈ړ����x��
    PRDENDKB       As String * 1     '���Y�I��
    PRDENDDT       As String * 8     '���Y�I�����t
    SLENDKB        As String * 1     '�̔�����
    SLENDDT        As String * 8     '�̔��������t
    JODSTPKB       As String * 1     '�󒍒�~
    JODSTPDT       As String * 8     '�󒍒�~���t
    MNTENDKB       As String * 1     '�ێ�I��
    MNTENDDT       As String * 8     '�ێ�I�����t
    ABODT          As String * 8     '�p�~��
    ORTKB          As String * 1     '�o�׋敪
    SERIKB         As String * 1     '�V���A���Ǘ��敪
    MAKNM          As String * 30    '���[�J�[��
    NXTMDL         As String * 40    '��p�@��
    JODSTDT        As String * 8     '�󒍊J�n��
    ORTSTDT        As String * 8     '�o�׊J�n��
    KOUZA          As String * 3     '����
    MDLCL          As String * 15    '�@�핪��
    OLDMDLCL       As String * 15    '���@�핪��
    HINGRP         As String * 4     '���i�Q
    SKHINGRP       As String * 4     '�d�ؗp���i�Q
    OEMKB          As String * 1     '�n�d�l
    OEMTOKRN       As String * 10    '�n�d�l���Ӑ�
    OPENKB         As String * 1     '�I�[�v�����i�敪
    STRMATKB       As String * 2     '�헪�����敪
    TITNM1         As String * 44    '��ڂP
    TITNM2         As String * 44    '��ڂQ
    TITNM3         As String * 44    '��ڂR
    CATSPCNM       As String * 100   '�J�^���O�X�y�b�N
    HINURLNM       As String * 100   '���iURL
    CHARANM        As String * 254   '����
    VSNNM          As String * 19    '�o�[�W����
    EDIHINSY       As String * 10    'EDI���i���
    BTOKB          As String * 10    'BTO�敪
    KONPOP         As Currency       '����|�C���g
    LOTSEQNO       As String * 2     '���b�g�A��
    KHNKB          As String * 1     '���{�敪
    RELFL          As String * 1     '�A�g�t���O
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h
    CLTID          As String * 5     '�N���C�A���g�h�c
    WRTTM          As String * 6     '�^�C���X�^���v�i���ԁj
    WRTDT          As String * 8     '�^�C���X�^���v�i���t�j
    WRTFSTTM       As String * 6     '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT       As String * 8     '�^�C���X�^���v�i�o�^���j
End Type
Global DB_HINMTA As TYPE_DB_HINMTA
Global DBN_HINMTA As Integer

'���i�}�X�^��������
Public WLSHIN_BHNSEARCH     As String           '���i���i�}�X�^�����t���O�i1:�������� 1�ȊO:�������Ȃ��j
' === 20060828 === INSERT S - ACE)Sejima ���{�敪�Ή�
' === 20060829 === UPDATE S - ACE)Nagasawa
'Public WLSHIN_KHNKB         As String           '���{�敪�i1:�{�@9:���j
Public WLSHIN_KHNSEARCH     As String           '�����i�����t���O�i1:�����i���܂߂Č��� 1�ȊO:�{���i�̂݌����j
' === 20060829 === UPDATE E -
' === 20060828 === INSERT E
' === 20061026 === INSERT S - FKS)KUMEDA
Public WLSHIN_SKHINGRP      As String           '���o�����i�d�ؗp���i�Q�j
' === 20061026 === INSERT E
'���i�}�X�^�����߂�l
Public WLSHIN_RTNCODE       As String           '���i�R�[�h

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_HINMTA_Clear
    '   �T�v�F  ���i�}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_HINMTA_Clear(ByRef pot_DB_HINMTA As TYPE_DB_HINMTA)

        Dim Clr_DB_HINMTA As TYPE_DB_HINMTA
    
        pot_DB_HINMTA = Clr_DB_HINMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPHINCD_SEARCH
    '   �T�v�F  ���i�R�[�h����
    '   �����F  pin_strHINCD  : �����Ώې��i�R�[�h
    '           pot_DB_HINMTA : ��������
    '           pin_strKJNDT  : �����P���K�p���
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
'    Public Function DSPHINCD_SEARCH(ByVal pin_strHINCD As String, _
'                                    ByRef pot_DB_HINMTA As TYPE_DB_HINMTA) As Integer
    Public Function DSPHINCD_SEARCH(ByVal pin_strHINCD As String, _
                                    ByRef pot_DB_HINMTA As TYPE_DB_HINMTA, _
                                    Optional pin_strKJNDT As String = "") As Integer
' === 20060828 === UPDATE E -

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPHINCD_SEARCH
    
        DSPHINCD_SEARCH = 9
        
' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
        Select Case True
            '����̎w�肪�Ȃ��ꍇ
            Case Trim(pin_strKJNDT) = ""
                pin_strKJNDT = GV_UNYDate
                
            '���t�̌`���œn�����ꍇ
            Case IsDate(pin_strKJNDT)
                pin_strKJNDT = Format(pin_strKJNDT, "yyyymmdd")
                
            Case Else
        End Select
' === 20060828 === UPDATE E -

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from HINMTA "
        strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPHINCD_SEARCH = 1
            GoTo END_DSPHINCD_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_HINMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .HINMSTKB = CF_Ora_GetDyn(Usr_Ody, "HINMSTKB", "")              '�}�X�^�敪�i���i�j
                .HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")                    '���i�R�[�h
                .HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "")                  '�^��
                .HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "")                  '���i���P
                .HINNMC = CF_Ora_GetDyn(Usr_Ody, "HINNMC", "")                  '���i���Q
                .HINNK = CF_Ora_GetDyn(Usr_Ody, "HINNK", "")                    '���i���J�i
                .HINNMD = CF_Ora_GetDyn(Usr_Ody, "HINNMD", "")                  '�V���[�Y���i���i���p�j
                .HINNME = CF_Ora_GetDyn(Usr_Ody, "HINNME", "")                  '�V���[�Y���i���i�S�p�j
                .UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "")                    '�P�ʃR�[�h
                .UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "")                    '�P�ʖ�
                .HINKB = CF_Ora_GetDyn(Usr_Ody, "HINKB", "")                    '���i�敪
                .HINID = CF_Ora_GetDyn(Usr_Ody, "HINID", "")                    '���i���
                .HINCLAKB = CF_Ora_GetDyn(Usr_Ody, "HINCLAKB", "")              '���ދ敪�P�i���i�j
                .HINCLBKB = CF_Ora_GetDyn(Usr_Ody, "HINCLBKB", "")              '���ދ敪�Q�i���i�j
                .HINCLCKB = CF_Ora_GetDyn(Usr_Ody, "HINCLCKB", "")              '���ދ敪�R�i���i�j
                .HINCLAID = CF_Ora_GetDyn(Usr_Ody, "HINCLAID", "")              '���ރR�[�h�P�i���i�j
                .HINCLBID = CF_Ora_GetDyn(Usr_Ody, "HINCLBID", "")              '���ރR�[�h�Q�i���i�j
                .HINCLCID = CF_Ora_GetDyn(Usr_Ody, "HINCLCID", "")              '���ރR�[�h�R�i���i�j
                .HINCLANM = CF_Ora_GetDyn(Usr_Ody, "HINCLANM", "")              '���ޖ��̂P�i���i�j
                .HINCLBNM = CF_Ora_GetDyn(Usr_Ody, "HINCLBNM", "")              '���ޖ��̂Q�i���i�j
                .HINCLCNM = CF_Ora_GetDyn(Usr_Ody, "HINCLCNM", "")              '���ޖ��̂R�i���i�j
                .DSPKB = CF_Ora_GetDyn(Usr_Ody, "DSPKB", "")                    '�����\���敪
                .ZAIKB = CF_Ora_GetDyn(Usr_Ody, "ZAIKB", "")                    '�݌ɊǗ��敪
                .HINZEIKB = CF_Ora_GetDyn(Usr_Ody, "HINZEIKB", "")              '���i����ŋ敪
                .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody, "ZEIRNKKB", "")              '����Ń����N
                .ZEIRT = CF_Ora_GetDyn(Usr_Ody, "ZEIRT", 0)                     '����ŗ�
                .HINJUNKB = CF_Ora_GetDyn(Usr_Ody, "HINJUNKB", "")              '���ӕ\�o�͋敪
                .MAKCD = CF_Ora_GetDyn(Usr_Ody, "MAKCD", "")                    '���[�J�[�R�[�h
                .HINCMA = CF_Ora_GetDyn(Usr_Ody, "HINCMA", "")                  '���i���l�`
                .HINCMB = CF_Ora_GetDyn(Usr_Ody, "HINCMB", "")                  '���i���lB
                .HINCMC = CF_Ora_GetDyn(Usr_Ody, "HINCMC", "")                  '���i���lC
                .HINCMD = CF_Ora_GetDyn(Usr_Ody, "HINCMD", "")                  '���i���lD
                .HINCME = CF_Ora_GetDyn(Usr_Ody, "HINCME", "")                  '���i���l�d
                .TEIKATK = CF_Ora_GetDyn(Usr_Ody, "TEIKATK", 0)                 '�艿
                .ZNKURITK = CF_Ora_GetDyn(Usr_Ody, "ZNKURITK", 0)               '�Ŕ��̔��P��
                .ZKMURITK = CF_Ora_GetDyn(Usr_Ody, "ZKMURITK", 0)               '�ō��̔��P��
                .ZNKSRETK = CF_Ora_GetDyn(Usr_Ody, "ZNKSRETK", 0)               '�Ŕ��d���P��
                .ZKMSRETK = CF_Ora_GetDyn(Usr_Ody, "ZKMSRETK", 0)               '�ō��d���P��
                .GNKTK = CF_Ora_GetDyn(Usr_Ody, "GNKTK", 0)                     '�����P��
                .PLANTK = CF_Ora_GetDyn(Usr_Ody, "PLANTK", 0)                   '�v��P��
                .OLDGNKTK = CF_Ora_GetDyn(Usr_Ody, "OLDGNKTK", 0)               '�������P��
                .GNKTKDT = CF_Ora_GetDyn(Usr_Ody, "GNKTKDT", "")                '�K�p��(�����P��)
                .OLDPLNTK = CF_Ora_GetDyn(Usr_Ody, "OLDPLNTK", 0)               '���v��P��
                .PLNTKDT = CF_Ora_GetDyn(Usr_Ody, "PLNTKDT", "")                '�K�p���i�@�핪��)
                .SODUNTSU = CF_Ora_GetDyn(Usr_Ody, "SODUNTSU", 0)               '�����P�ʐ�
                .TEKZAISU = CF_Ora_GetDyn(Usr_Ody, "TEKZAISU", 0)               '�K���݌ɐ�
                .ANZZAISU = CF_Ora_GetDyn(Usr_Ody, "ANZZAISU", 0)               '���S�݌ɐ��i�̔��v��p�j
                .HRTDD = CF_Ora_GetDyn(Usr_Ody, "HRTDD", "")                    '�������[�h�^�C��
                .ORTDD = CF_Ora_GetDyn(Usr_Ody, "ORTDD", "")                    '�o�׃��[�h�^�C��
                .PRCDD = CF_Ora_GetDyn(Usr_Ody, "PRCDD", "")                    '���B���[�h�^�C��
                .MNFDD = CF_Ora_GetDyn(Usr_Ody, "MNFDD", "")                    '�������[�h�^�C��
                .HINSIRCD = CF_Ora_GetDyn(Usr_Ody, "HINSIRCD", "")              '���i�d����R�[�h
                .HINSIRRN = CF_Ora_GetDyn(Usr_Ody, "HINSIRRN", "")              '���i�d���於��
                .TNACM = CF_Ora_GetDyn(Usr_Ody, "TNACM", "")                    '�I�ԍ�
                .HINNMMKB = CF_Ora_GetDyn(Usr_Ody, "HINNMMKB", "")              '�����ƭ�ٓ��͋敪(���i)
                .JANCD = CF_Ora_GetDyn(Usr_Ody, "JANCD", "")                    '�i�`�m�R�[�h
                .HINFRNNM = CF_Ora_GetDyn(Usr_Ody, "HINFRNNM", "")              '���i���C�O�\�L
                .ZAIRNK = CF_Ora_GetDyn(Usr_Ody, "ZAIRNK", "")                  '�݌Ƀ����N
                .GNKCD = CF_Ora_GetDyn(Usr_Ody, "GNKCD", "")                    '�����Ǘ��R�[�h
                .MINSODSU = CF_Ora_GetDyn(Usr_Ody, "MINSODSU", 0)               '�ŏ�������
                .SODADDSU = CF_Ora_GetDyn(Usr_Ody, "SODADDSU", 0)               '����������
                .JODHIKKB = CF_Ora_GetDyn(Usr_Ody, "JODHIKKB", "")              '�󒍈����敪
                .ORTSTPKB = CF_Ora_GetDyn(Usr_Ody, "ORTSTPKB", "")              '�o�ג�~
                .ORTSTPDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTPDT", "")              '�o�ג�~��
                .ORTKJDT = CF_Ora_GetDyn(Usr_Ody, "ORTKJDT", "")                '�o�ג�~������
                .ORTSTYDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTYDT", "")              '�o�׊J�n�\���
                .CTLGKB = CF_Ora_GetDyn(Usr_Ody, "CTLGKB", "")                  '�J�^���O�i�Ώ�
                .MLOKB = CF_Ora_GetDyn(Usr_Ody, "MLOKB", "")                    '�ʔ̑Ώ�
                .MLOHINID = CF_Ora_GetDyn(Usr_Ody, "MLOHINID", "")              '�ʔ̐��i�h�c
                .MLOIDORT = CF_Ora_GetDyn(Usr_Ody, "MLOIDORT", 0)               '�ʔ̈ړ��䗦
                .MLOLMTSU = CF_Ora_GetDyn(Usr_Ody, "MLOLMTSU", "")              '�ʔ̈ړ����x��
                .PRDENDKB = CF_Ora_GetDyn(Usr_Ody, "PRDENDKB", "")              '���Y�I��
                .PRDENDDT = CF_Ora_GetDyn(Usr_Ody, "PRDENDDT", "")              '���Y�I�����t
                .SLENDKB = CF_Ora_GetDyn(Usr_Ody, "SLENDKB", "")                '�̔�����
                .SLENDDT = CF_Ora_GetDyn(Usr_Ody, "SLENDDT", "")                '�̔��������t
                .JODSTPKB = CF_Ora_GetDyn(Usr_Ody, "JODSTPKB", "")              '�󒍒�~
                .JODSTPDT = CF_Ora_GetDyn(Usr_Ody, "JODSTPDT", "")              '�󒍒�~���t
                .MNTENDKB = CF_Ora_GetDyn(Usr_Ody, "MNTENDKB", "")              '�ێ�I��
                .MNTENDDT = CF_Ora_GetDyn(Usr_Ody, "MNTENDDT", "")              '�ێ�I�����t
                .ABODT = CF_Ora_GetDyn(Usr_Ody, "ABODT", "")                    '�p�~��
                .ORTKB = CF_Ora_GetDyn(Usr_Ody, "ORTKB", "")                    '�o�׋敪
                .SERIKB = CF_Ora_GetDyn(Usr_Ody, "SERIKB", "")                  '�V���A���Ǘ��敪
                .MAKNM = CF_Ora_GetDyn(Usr_Ody, "MAKNM", "")                    '���[�J�[��
                .NXTMDL = CF_Ora_GetDyn(Usr_Ody, "NXTMDL", "")                  '��p�@��
                .JODSTDT = CF_Ora_GetDyn(Usr_Ody, "JODSTDT", "")                '�󒍊J�n��
                .ORTSTDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTDT", "")                '�o�׊J�n��
                .KOUZA = CF_Ora_GetDyn(Usr_Ody, "KOUZA", "")                    '����
                .MDLCL = CF_Ora_GetDyn(Usr_Ody, "MDLCL", "")                    '�@�핪��
                .OLDMDLCL = CF_Ora_GetDyn(Usr_Ody, "OLDMDLCL", "")              '���@�핪��
                .HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "")                  '���i�Q
                .SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "")              '�d�ؗp���i�Q
                .OEMKB = CF_Ora_GetDyn(Usr_Ody, "OEMKB", "")                    '�n�d�l
                .OEMTOKRN = CF_Ora_GetDyn(Usr_Ody, "OEMTOKRN", "")              '�n�d�l���Ӑ�
                .OPENKB = CF_Ora_GetDyn(Usr_Ody, "OPENKB", "")                  '�I�[�v�����i�敪
                .STRMATKB = CF_Ora_GetDyn(Usr_Ody, "STRMATKB", "")              '�헪�����敪
                .TITNM1 = CF_Ora_GetDyn(Usr_Ody, "TITNM1", "")                  '��ڂP
                .TITNM2 = CF_Ora_GetDyn(Usr_Ody, "TITNM2", "")                  '��ڂQ
                .TITNM3 = CF_Ora_GetDyn(Usr_Ody, "TITNM3", "")                  '��ڂR
                .CATSPCNM = CF_Ora_GetDyn(Usr_Ody, "CATSPCNM", "")              '�J�^���O�X�y�b�N
                .HINURLNM = CF_Ora_GetDyn(Usr_Ody, "HINURLNM", "")              '���iURL
                .CHARANM = CF_Ora_GetDyn(Usr_Ody, "CHARANM", "")                '����
                .VSNNM = CF_Ora_GetDyn(Usr_Ody, "VSNNM", "")                    '�o�[�W����
                .EDIHINSY = CF_Ora_GetDyn(Usr_Ody, "EDIHINSY", "")              'EDI���i���
                .BTOKB = CF_Ora_GetDyn(Usr_Ody, "BTOKB", "")                    'BTO�敪
                .KONPOP = CF_Ora_GetDyn(Usr_Ody, "KONPOP", 0)                   '����|�C���g
                .LOTSEQNO = CF_Ora_GetDyn(Usr_Ody, "LOTSEQNO", "")              '���b�g�A��
                .KHNKB = CF_Ora_GetDyn(Usr_Ody, "KHNKB", "")                    '���{�敪
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
                
' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
                If Trim(.GNKTKDT) <> "" Then
                    If .GNKTKDT > pin_strKJNDT Then
                        .GNKTK = .OLDGNKTK
                        .PLANTK = .OLDPLNTK
                    End If
                End If
' === 20060828 === UPDATE E -

' === 20061107 === INSERT S - ACE)Nagasawa �@�핪�ޓK�p���Ή�
                If Trim(.PLNTKDT) <> "" Then
                    If .PLNTKDT > pin_strKJNDT Then
                        .MDLCL = .OLDMDLCL
                    End If
                End If
' === 20061107 === INSERT E -

            End With
        End If

        DSPHINCD_SEARCH = 0
        
END_DSPHINCD_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        Exit Function
    
ERR_DSPHINCD_SEARCH:
        GoTo END_DSPHINCD_SEARCH
        
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPHINCD_SEARCH_B
    '   �T�v�F  ���i�R�[�h�����i���i���i�}�X�^�����킹�Č����j
    '   �����F  pin_strHINCD  : �����Ώې��i�R�[�h
    '           pot_DB_HINMTA : ��������
    '           pin_strKJNDT  : �����P���K�p���
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
'    Public Function DSPHINCD_SEARCH_B(ByVal pin_strHINCD As String, _
'                                      ByRef pot_DB_HINMTA As TYPE_DB_HINMTA) As Integer
    Public Function DSPHINCD_SEARCH_B(ByVal pin_strHINCD As String, _
                                      ByRef pot_DB_HINMTA As TYPE_DB_HINMTA, _
                                      Optional ByVal pin_strKJNDT As String = "") As Integer
' === 20060828 === UPDATE E -

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPHINCD_SEARCH_B
    
        DSPHINCD_SEARCH_B = 9
        
' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
        If Trim(pin_strKJNDT) = "" Then
            pin_strKJNDT = GV_UNYDate
        End If
' === 20060828 === UPDATE E -

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from HINMTA "
        strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            '�N���[�Y
            Call CF_Ora_CloseDyn(Usr_Ody)
            
            '���i���i�}�X�^
            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from BHNMTA "
            strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "
            
            'DB�A�N�Z�X
            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
            If CF_Ora_EOF(Usr_Ody) = True Then
                '�Y���f�[�^����
                DSPHINCD_SEARCH_B = 1
                GoTo END_DSPHINCD_SEARCH_B
            End If
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_HINMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
                .HINMSTKB = CF_Ora_GetDyn(Usr_Ody, "HINMSTKB", "")              '�}�X�^�敪�i���i�j
                .HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")                    '���i�R�[�h
                .HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "")                  '�^��
                .HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "")                  '���i���P
                .HINNMC = CF_Ora_GetDyn(Usr_Ody, "HINNMC", "")                  '���i���Q
                .HINNK = CF_Ora_GetDyn(Usr_Ody, "HINNK", "")                    '���i���J�i
                .HINNMD = CF_Ora_GetDyn(Usr_Ody, "HINNMD", "")                  '�V���[�Y���i���i���p�j
                .HINNME = CF_Ora_GetDyn(Usr_Ody, "HINNME", "")                  '�V���[�Y���i���i�S�p�j
                .UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "")                    '�P�ʃR�[�h
                .UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "")                    '�P�ʖ�
                .HINKB = CF_Ora_GetDyn(Usr_Ody, "HINKB", "")                    '���i�敪
                .HINID = CF_Ora_GetDyn(Usr_Ody, "HINID", "")                    '���i���
                .HINCLAKB = CF_Ora_GetDyn(Usr_Ody, "HINCLAKB", "")              '���ދ敪�P�i���i�j
                .HINCLBKB = CF_Ora_GetDyn(Usr_Ody, "HINCLBKB", "")              '���ދ敪�Q�i���i�j
                .HINCLCKB = CF_Ora_GetDyn(Usr_Ody, "HINCLCKB", "")              '���ދ敪�R�i���i�j
                .HINCLAID = CF_Ora_GetDyn(Usr_Ody, "HINCLAID", "")              '���ރR�[�h�P�i���i�j
                .HINCLBID = CF_Ora_GetDyn(Usr_Ody, "HINCLBID", "")              '���ރR�[�h�Q�i���i�j
                .HINCLCID = CF_Ora_GetDyn(Usr_Ody, "HINCLCID", "")              '���ރR�[�h�R�i���i�j
                .HINCLANM = CF_Ora_GetDyn(Usr_Ody, "HINCLANM", "")              '���ޖ��̂P�i���i�j
                .HINCLBNM = CF_Ora_GetDyn(Usr_Ody, "HINCLBNM", "")              '���ޖ��̂Q�i���i�j
                .HINCLCNM = CF_Ora_GetDyn(Usr_Ody, "HINCLCNM", "")              '���ޖ��̂R�i���i�j
                .DSPKB = CF_Ora_GetDyn(Usr_Ody, "DSPKB", "")                    '�����\���敪
                .ZAIKB = CF_Ora_GetDyn(Usr_Ody, "ZAIKB", "")                    '�݌ɊǗ��敪
                .HINZEIKB = CF_Ora_GetDyn(Usr_Ody, "HINZEIKB", "")              '���i����ŋ敪
                .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody, "ZEIRNKKB", "")              '����Ń����N
                .ZEIRT = CF_Ora_GetDyn(Usr_Ody, "ZEIRT", 0)                     '����ŗ�
                .HINJUNKB = CF_Ora_GetDyn(Usr_Ody, "HINJUNKB", "")              '���ӕ\�o�͋敪
                .MAKCD = CF_Ora_GetDyn(Usr_Ody, "MAKCD", "")                    '���[�J�[�R�[�h
                .HINCMA = CF_Ora_GetDyn(Usr_Ody, "HINCMA", "")                  '���i���l�`
                .HINCMB = CF_Ora_GetDyn(Usr_Ody, "HINCMB", "")                  '���i���lB
                .HINCMC = CF_Ora_GetDyn(Usr_Ody, "HINCMC", "")                  '���i���lC
                .HINCMD = CF_Ora_GetDyn(Usr_Ody, "HINCMD", "")                  '���i���lD
                .HINCME = CF_Ora_GetDyn(Usr_Ody, "HINCME", "")                  '���i���l�d
                .TEIKATK = CF_Ora_GetDyn(Usr_Ody, "TEIKATK", 0)                 '�艿
                .ZNKURITK = CF_Ora_GetDyn(Usr_Ody, "ZNKURITK", 0)               '�Ŕ��̔��P��
                .ZKMURITK = CF_Ora_GetDyn(Usr_Ody, "ZKMURITK", 0)               '�ō��̔��P��
                .ZNKSRETK = CF_Ora_GetDyn(Usr_Ody, "ZNKSRETK", 0)               '�Ŕ��d���P��
                .ZKMSRETK = CF_Ora_GetDyn(Usr_Ody, "ZKMSRETK", 0)               '�ō��d���P��
                .GNKTK = CF_Ora_GetDyn(Usr_Ody, "GNKTK", 0)                     '�����P��
                .PLANTK = CF_Ora_GetDyn(Usr_Ody, "PLANTK", 0)                   '�v��P��
                .OLDGNKTK = CF_Ora_GetDyn(Usr_Ody, "OLDGNKTK", 0)               '�������P��
                .GNKTKDT = CF_Ora_GetDyn(Usr_Ody, "GNKTKDT", "")                '�K�p��(�����P��)
                .OLDPLNTK = CF_Ora_GetDyn(Usr_Ody, "OLDPLNTK", 0)               '���v��P��
                .PLNTKDT = CF_Ora_GetDyn(Usr_Ody, "PLNTKDT", "")                '�K�p���i�v��P��)
                .SODUNTSU = CF_Ora_GetDyn(Usr_Ody, "SODUNTSU", 0)               '�����P�ʐ�
                .TEKZAISU = CF_Ora_GetDyn(Usr_Ody, "TEKZAISU", 0)               '�K���݌ɐ�
                .ANZZAISU = CF_Ora_GetDyn(Usr_Ody, "ANZZAISU", 0)               '���S�݌ɐ��i�̔��v��p�j
                .HRTDD = CF_Ora_GetDyn(Usr_Ody, "HRTDD", "")                    '�������[�h�^�C��
                .ORTDD = CF_Ora_GetDyn(Usr_Ody, "ORTDD", "")                    '�o�׃��[�h�^�C��
                .PRCDD = CF_Ora_GetDyn(Usr_Ody, "PRCDD", "")                    '���B���[�h�^�C��
                .MNFDD = CF_Ora_GetDyn(Usr_Ody, "MNFDD", "")                    '�������[�h�^�C��
                .HINSIRCD = CF_Ora_GetDyn(Usr_Ody, "HINSIRCD", "")              '���i�d����R�[�h
                .HINSIRRN = CF_Ora_GetDyn(Usr_Ody, "HINSIRRN", "")              '���i�d���於��
                .TNACM = CF_Ora_GetDyn(Usr_Ody, "TNACM", "")                    '�I�ԍ�
                .HINNMMKB = CF_Ora_GetDyn(Usr_Ody, "HINNMMKB", "")              '�����ƭ�ٓ��͋敪(���i)
                .JANCD = CF_Ora_GetDyn(Usr_Ody, "JANCD", "")                    '�i�`�m�R�[�h
                .HINFRNNM = CF_Ora_GetDyn(Usr_Ody, "HINFRNNM", "")              '���i���C�O�\�L
                .ZAIRNK = CF_Ora_GetDyn(Usr_Ody, "ZAIRNK", "")                  '�݌Ƀ����N
                .GNKCD = CF_Ora_GetDyn(Usr_Ody, "GNKCD", "")                    '�����Ǘ��R�[�h
                .MINSODSU = CF_Ora_GetDyn(Usr_Ody, "MINSODSU", 0)               '�ŏ�������
                .SODADDSU = CF_Ora_GetDyn(Usr_Ody, "SODADDSU", 0)               '����������
                .JODHIKKB = CF_Ora_GetDyn(Usr_Ody, "JODHIKKB", "")              '�󒍈����敪
                .ORTSTPKB = CF_Ora_GetDyn(Usr_Ody, "ORTSTPKB", "")              '�o�ג�~
                .ORTSTPDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTPDT", "")              '�o�ג�~��
                .ORTKJDT = CF_Ora_GetDyn(Usr_Ody, "ORTKJDT", "")                '�o�ג�~������
                .ORTSTYDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTYDT", "")              '�o�׊J�n�\���
                .CTLGKB = CF_Ora_GetDyn(Usr_Ody, "CTLGKB", "")                  '�J�^���O�i�Ώ�
                .MLOKB = CF_Ora_GetDyn(Usr_Ody, "MLOKB", "")                    '�ʔ̑Ώ�
                .MLOHINID = CF_Ora_GetDyn(Usr_Ody, "MLOHINID", "")              '�ʔ̐��i�h�c
                .MLOIDORT = CF_Ora_GetDyn(Usr_Ody, "MLOIDORT", 0)               '�ʔ̈ړ��䗦
                .MLOLMTSU = CF_Ora_GetDyn(Usr_Ody, "MLOLMTSU", "")              '�ʔ̈ړ����x��
                .PRDENDKB = CF_Ora_GetDyn(Usr_Ody, "PRDENDKB", "")              '���Y�I��
                .PRDENDDT = CF_Ora_GetDyn(Usr_Ody, "PRDENDDT", "")              '���Y�I�����t
                .SLENDKB = CF_Ora_GetDyn(Usr_Ody, "SLENDKB", "")                '�̔�����
                .SLENDDT = CF_Ora_GetDyn(Usr_Ody, "SLENDDT", "")                '�̔��������t
                .JODSTPKB = CF_Ora_GetDyn(Usr_Ody, "JODSTPKB", "")              '�󒍒�~
                .JODSTPDT = CF_Ora_GetDyn(Usr_Ody, "JODSTPDT", "")              '�󒍒�~���t
                .MNTENDKB = CF_Ora_GetDyn(Usr_Ody, "MNTENDKB", "")              '�ێ�I��
                .MNTENDDT = CF_Ora_GetDyn(Usr_Ody, "MNTENDDT", "")              '�ێ�I�����t
                .ABODT = CF_Ora_GetDyn(Usr_Ody, "ABODT", "")                    '�p�~��
                .ORTKB = CF_Ora_GetDyn(Usr_Ody, "ORTKB", "")                    '�o�׋敪
                .SERIKB = CF_Ora_GetDyn(Usr_Ody, "SERIKB", "")                  '�V���A���Ǘ��敪
                .MAKNM = CF_Ora_GetDyn(Usr_Ody, "MAKNM", "")                    '���[�J�[��
                .NXTMDL = CF_Ora_GetDyn(Usr_Ody, "NXTMDL", "")                  '��p�@��
                .JODSTDT = CF_Ora_GetDyn(Usr_Ody, "JODSTDT", "")                '�󒍊J�n��
                .ORTSTDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTDT", "")                '�o�׊J�n��
                .KOUZA = CF_Ora_GetDyn(Usr_Ody, "KOUZA", "")                    '����
                .MDLCL = CF_Ora_GetDyn(Usr_Ody, "MDLCL", "")                    '�@�핪��
                .OLDMDLCL = CF_Ora_GetDyn(Usr_Ody, "OLDMDLCL", "")              '���@�핪��
                .HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "")                  '���i�Q
                .SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "")              '�d�ؗp���i�Q
                .OEMKB = CF_Ora_GetDyn(Usr_Ody, "OEMKB", "")                    '�n�d�l
                .OEMTOKRN = CF_Ora_GetDyn(Usr_Ody, "OEMTOKRN", "")              '�n�d�l���Ӑ�
                .OPENKB = CF_Ora_GetDyn(Usr_Ody, "OPENKB", "")                  '�I�[�v�����i�敪
                .STRMATKB = CF_Ora_GetDyn(Usr_Ody, "STRMATKB", "")              '�헪�����敪
                .TITNM1 = CF_Ora_GetDyn(Usr_Ody, "TITNM1", "")                  '��ڂP
                .TITNM2 = CF_Ora_GetDyn(Usr_Ody, "TITNM2", "")                  '��ڂQ
                .TITNM3 = CF_Ora_GetDyn(Usr_Ody, "TITNM3", "")                  '��ڂR
                .CATSPCNM = CF_Ora_GetDyn(Usr_Ody, "CATSPCNM", "")              '�J�^���O�X�y�b�N
                .HINURLNM = CF_Ora_GetDyn(Usr_Ody, "HINURLNM", "")              '���iURL
                .CHARANM = CF_Ora_GetDyn(Usr_Ody, "CHARANM", "")                '����
                .VSNNM = CF_Ora_GetDyn(Usr_Ody, "VSNNM", "")                    '�o�[�W����
                .EDIHINSY = CF_Ora_GetDyn(Usr_Ody, "EDIHINSY", "")              'EDI���i���
                .BTOKB = CF_Ora_GetDyn(Usr_Ody, "BTOKB", "")                    'BTO�敪
                .KONPOP = CF_Ora_GetDyn(Usr_Ody, "KONPOP", 0)                   '����|�C���g
                .LOTSEQNO = CF_Ora_GetDyn(Usr_Ody, "LOTSEQNO", "")              '���b�g�A��
                .KHNKB = CF_Ora_GetDyn(Usr_Ody, "KHNKB", "")                    '���{�敪
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
                If Trim(.GNKTKDT) <> "" Then
                    If .GNKTKDT > pin_strKJNDT Then
                        .GNKTK = .OLDGNKTK
' === 20080104 === INSERT S - ACE)Nagasawa
                        .PLANTK = .OLDPLNTK
' === 20080104 === INSERT E -
                    End If
                End If
' === 20060828 === UPDATE E -

' === 20080104 === INSERT S - ACE)Nagasawa
                If Trim(.PLNTKDT) <> "" Then
                    If .PLNTKDT > pin_strKJNDT Then
                        .MDLCL = .OLDMDLCL
                    End If
                End If
' === 20080104 === INSERT E -

            End With
        End If
        
        DSPHINCD_SEARCH_B = 0
        
END_DSPHINCD_SEARCH_B:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        Exit Function
    
ERR_DSPHINCD_SEARCH_B:
        GoTo END_DSPHINCD_SEARCH_B
        
    End Function


