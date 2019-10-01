Attribute VB_Name = "SYSTBA_DBM"
        Option Explicit
'==========================================================================
'   SYSTBA.DBM   հ�ް���Ǘ�ð���               UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBA
    USRID          As String * 8     '���[�U�[ID            !@@@@@@@@
    USRNMA         As String * 30    '���[�U�[��1(����)
    USRNMB         As String * 30    '���[�U�[��2(����)
    USRRN          As String * 20    '���[�U�[����
    USRNK          As String * 10    '���[�U�[����(�J�i)
    USRZP          As String * 8     '���[�U�[�X�֔ԍ�
    USRADA         As String * 30    '���[�U�[�Z��1
    USRADB         As String * 30    '���[�U�[�Z��2
    USRADC         As String * 30    '���[�U�[�Z��3
    USRTL          As String * 12    '���[�U�[�d�b�ԍ�
    USRFX          As String * 12    '���[�U�[FAX�ԍ�
    USRBOSNM       As String * 30    '���[�U�[��\�Җ���
    USRTANNM       As String * 30    '���[�U�[�S���Җ�
    SMAMM          As String * 2     '���Z��                MM
    SMADD          As String * 2     '���Z��                DD
    SMAMONDD       As String * 2     '�������Z��            DD
    SMEDD          As String * 2     '���ߓ�                DD
    KESCC          As String * 2     '����x����            MM
    KESDD          As String * 2     '����x����            DD
    DATNO          As String * 10    '�`�[�Ǘ�NO.           0000000000
    RECNO          As String * 10    '���R�[�h�Ǘ�NO.       0000000000
    STTDATNO       As String * 10    '�J�n�`�[�Ǘ�NO.
    ENDDATNO       As String * 10    '�I���`�[�Ǘ�NO.
    STTRECNO       As String * 10    '�J�n���R�[�h�Ǘ�NO.
    ENDRECNO       As String * 10    '�I�����R�[�h�Ǘ�NO.
    GYMSTTDT       As String * 8     '�Ɩ��J�n���t          YYYY/MM/DD
    TOKSSAKB       As String * 1     '���Ӑ搿���������敪  0
    TOKSMAKB       As String * 1     '���Ӑ�o���������敪  0
    SIRSSAKB       As String * 1     '�d����x���������敪  0
    SIRSMAKB       As String * 1     '�d����o���������敪  0
    SMAUPDDT       As String * 8     '�O��o�������s��      YYYY/MM/DD
    UKSMEDT        As String * 8     '�����������i����j
    SKSMEDT        As String * 8     '�����������i�d���j
    MINSPCCP       As String * 8     '�Œ�󂫗e��(�l)      9(8)
    MONUPDSC       As String * 2     '�g�����ۑ�����(��)    99
    YERUPDSC       As String * 2     '�T�}���ۑ�����(��)    99
    MONUPDDT       As String * 8     '�O�񌎎��X�V���s��    YYYY/MM/DD
    YERUPDDT       As String * 8     '�O��N���X�V���s��    YYYY/MM/DD
    NEGKB(1)       As String * 1     '�a��̗p�敪          0
    NEGDT(4)       As String * 8     '���N(����)            YYYY/MM/DD
    NEGYY(4)       As String * 4     '����(�N)              YYYY
    NEGNM(4)       As String * 4     '����
    VERNO          As String * 3     'VERNO                 !@@@
    LEVNO          As String * 2     'LEBEL NO              00
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@
    ZAIHYKKB       As String * 1     '�݌ɕ]�����@          0
    GNKHYKKB       As String * 1     '�����]�����@-�e���p   0
    HYKSTTDT       As String * 8     '�]���v�Z�J�n���t      YYYY/MM/DD
    WRTTM          As String * 6     '��ѽ����(����)        9(06)
    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD
    WRTFSTTM       As String * 8     '��ѽ����(�o�^����)
    WRTFSTDT       As String * 8     '��ѽ����(�o�^���t)
End Type
Global DB_SYSTBA As TYPE_DB_SYSTBA
Global DBN_SYSTBA As Integer
' Index1( USRID )

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_SYSTBA_Clear
    '   �T�v�F  ���[�U�[���Ǘ��e�[�u���\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_SYSTBA_Clear(ByRef pot_DB_SYSTBA As TYPE_DB_SYSTBA)

        Dim Clr_DB_SYSTBA As TYPE_DB_SYSTBA
    
        pot_DB_SYSTBA = Clr_DB_SYSTBA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function SYSTBA_SEARCH
    '   �T�v�F  ���[�U�[���Ǘ��e�[�u������
    '   �����F  pot_DB_SYSTBA   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function SYSTBA_SEARCH(ByRef pot_DB_SYSTBA As TYPE_DB_SYSTBA) As Integer

        Dim strSQL          As String
        Dim Usr_Ody_LC      As U_Ody
        Dim intCnt          As Integer

    On Error GoTo ERR_SYSTBA_SEARCH
    
        SYSTBA_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SYSTBA "
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
 
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '�擾�f�[�^�Ȃ�
            SYSTBA_SEARCH = 1
            GoTo END_SYSTBA_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody_LC) = False Then
            With pot_DB_SYSTBA
                .USRID = CF_Ora_GetDyn(Usr_Ody_LC, "USRID", "")                    '���[�U�[ID
                .USRNMA = CF_Ora_GetDyn(Usr_Ody_LC, "USRNMA", "")                  '���[�U�[��1(����)
                .USRNMB = CF_Ora_GetDyn(Usr_Ody_LC, "USRNMB", "")                  '���[�U�[��2(����)
                .USRRN = CF_Ora_GetDyn(Usr_Ody_LC, "USRRN", "")                    '���[�U�[����
                .USRNK = CF_Ora_GetDyn(Usr_Ody_LC, "USRNK", "")                    '���[�U�[����(�J�i)
                .USRZP = CF_Ora_GetDyn(Usr_Ody_LC, "USRZP", "")                    '���[�U�[�X�֔ԍ�
                .USRADA = CF_Ora_GetDyn(Usr_Ody_LC, "USRADA", "")                  '���[�U�[�Z��1
                .USRADB = CF_Ora_GetDyn(Usr_Ody_LC, "USRADB", "")                  '���[�U�[�Z��2
                .USRADC = CF_Ora_GetDyn(Usr_Ody_LC, "USRADC", "")                  '���[�U�[�Z��3
                .USRTL = CF_Ora_GetDyn(Usr_Ody_LC, "USRTL", "")                    '���[�U�[�d�b�ԍ�
                .USRFX = CF_Ora_GetDyn(Usr_Ody_LC, "USRFX", "")                    '���[�U�[FAX�ԍ�
                .USRBOSNM = CF_Ora_GetDyn(Usr_Ody_LC, "USRBOSNM", "")              '���[�U�[��\�Җ���
                .USRTANNM = CF_Ora_GetDyn(Usr_Ody_LC, "USRTANNM", "")              '���[�U�[�S���Җ�
                .SMAMM = CF_Ora_GetDyn(Usr_Ody_LC, "SMAMM", "")                    '���Z��
                .SMADD = CF_Ora_GetDyn(Usr_Ody_LC, "SMADD", "")                    '���Z��
                .SMAMONDD = CF_Ora_GetDyn(Usr_Ody_LC, "SMAMONDD", "")              '�������Z��
                .SMEDD = CF_Ora_GetDyn(Usr_Ody_LC, "SMEDD", "")                    '���ߓ�
                .KESCC = CF_Ora_GetDyn(Usr_Ody_LC, "KESCC", "")                    '����x����
                .KESDD = CF_Ora_GetDyn(Usr_Ody_LC, "KESDD", "")                    '����x����
                .DATNO = CF_Ora_GetDyn(Usr_Ody_LC, "DATNO", "")                    '�`�[�Ǘ�NO.
                .RECNO = CF_Ora_GetDyn(Usr_Ody_LC, "RECNO", "")                    '���R�[�h�Ǘ�NO.
                .STTDATNO = CF_Ora_GetDyn(Usr_Ody_LC, "STTDATNO", "")              '�J�n�`�[�Ǘ�NO.
                .ENDDATNO = CF_Ora_GetDyn(Usr_Ody_LC, "ENDDATNO", "")              '�I���`�[�Ǘ�NO.
                .STTRECNO = CF_Ora_GetDyn(Usr_Ody_LC, "STTRECNO", "")              '�J�n���R�[�h�Ǘ�NO.
                .ENDRECNO = CF_Ora_GetDyn(Usr_Ody_LC, "ENDRECNO", "")              '�I�����R�[�h�Ǘ�NO.
                .GYMSTTDT = CF_Ora_GetDyn(Usr_Ody_LC, "GYMSTTDT", "")              '�Ɩ��J�n���t
                .TOKSSAKB = CF_Ora_GetDyn(Usr_Ody_LC, "TOKSSAKB", "")              '���Ӑ搿���������敪
                .TOKSMAKB = CF_Ora_GetDyn(Usr_Ody_LC, "TOKSMAKB", "")              '���Ӑ�o���������敪
                .SIRSSAKB = CF_Ora_GetDyn(Usr_Ody_LC, "SIRSSAKB", "")              '�d����x���������敪
                .SIRSMAKB = CF_Ora_GetDyn(Usr_Ody_LC, "SIRSMAKB", "")              '�d����o���������敪
                .SMAUPDDT = CF_Ora_GetDyn(Usr_Ody_LC, "SMAUPDDT", "")              '�O��o�������s��
                .UKSMEDT = CF_Ora_GetDyn(Usr_Ody_LC, "UKSMEDT", "")                '�����������i����j
                .SKSMEDT = CF_Ora_GetDyn(Usr_Ody_LC, "SKSMEDT", "")                '�����������i�d���j
                .MINSPCCP = CF_Ora_GetDyn(Usr_Ody_LC, "MINSPCCP", "")              '�Œ�󂫗e��(�l)
                .MONUPDSC = CF_Ora_GetDyn(Usr_Ody_LC, "MONUPDSC", "")              '�g�����ۑ�����(��)
                .YERUPDSC = CF_Ora_GetDyn(Usr_Ody_LC, "YERUPDSC", "")              '�T�}���ۑ�����(��)
                .MONUPDDT = CF_Ora_GetDyn(Usr_Ody_LC, "MONUPDDT", "")              '�O�񌎎��X�V���s��
                .YERUPDDT = CF_Ora_GetDyn(Usr_Ody_LC, "YERUPDDT", "")              '�O��N���X�V���s��
                '�a��̗p�敪
                For intCnt = 0 To 1
                    .NEGKB(intCnt) = CF_Ora_GetDyn(Usr_Ody_LC, "NEGKB" & Format(intCnt, "00"), "")
                Next
                '���N(����)
                For intCnt = 0 To 4
                    .NEGDT(intCnt) = CF_Ora_GetDyn(Usr_Ody_LC, "NEGDT" & Format(intCnt, "00"), "")
                Next
                '����(�N)
                For intCnt = 0 To 4
                    .NEGYY(intCnt) = CF_Ora_GetDyn(Usr_Ody_LC, "NEGYY" & Format(intCnt, "00"), "")
                Next
                '����
                For intCnt = 0 To 4
                    .NEGNM(intCnt) = CF_Ora_GetDyn(Usr_Ody_LC, "NEGNM" & Format(intCnt, "00"), "")
                Next
                .VERNO = CF_Ora_GetDyn(Usr_Ody_LC, "VERNO", "")                    'VERNO
                .LEVNO = CF_Ora_GetDyn(Usr_Ody_LC, "LEVNO", "")                    'LEBEL NO
                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")                    '�N���C�A���g�h�c
                .ZAIHYKKB = CF_Ora_GetDyn(Usr_Ody_LC, "ZAIHYKKB", "")              '�݌ɕ]�����@
                .GNKHYKKB = CF_Ora_GetDyn(Usr_Ody_LC, "GNKHYKKB", "")              '�����]�����@-�e���p
                .HYKSTTDT = CF_Ora_GetDyn(Usr_Ody_LC, "HYKSTTDT", "")              '�]���v�Z�J�n���t
                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")                    '��ѽ����(����)
                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")                    '��ѽ����(���t)
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")              '��ѽ����(�o�^����)
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")              '��ѽ����(�o�^���t)
            End With
        End If

        SYSTBA_SEARCH = 0
        
END_SYSTBA_SEARCH:
        
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
        Exit Function
    
ERR_SYSTBA_SEARCH:
        GoTo END_SYSTBA_SEARCH
        
    End Function
