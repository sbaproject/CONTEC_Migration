Attribute VB_Name = "MEIMTA_DBM"
        Option Explicit
'==========================================================================
'   MEIMTA.DBM   ���̃}�X�^                       UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_MEIMTA
    DATKB          As String * 1     '�`�[�폜�敪          0
    KEYCD          As String * 3     '�L�[                  000
    MEIKMKNM       As String * 20    '���ږ�
    MEICDA         As String * 20    '�R�[�h�P
    MEICDB         As String * 5     '�R�[�h�Q
    MEINMA         As String * 40    '���̂P
    MEINMB         As String * 20    '���̂Q
    MEINMC         As String * 20    '���̂R
    MEISUA         As Currency       '���l���ڂP            ###,###,##0.0000;;#
    MEISUB         As Currency       '���l���ڂQ            ###,##0.0000;;#
    MEISUC         As Currency       '���l���ڂR            ###,##0.0000;;#
    MEIKBA         As String * 1     '�敪�P
    MEIKBB         As String * 1     '�敪�Q
    MEIKBC         As String * 1     '�敪�R
    DSPORD         As String * 3     '�\������
    RELFL          As String * 1     '�A�g�t���O            X
' === 20061227 === UPDATE S - ACE)Nagasawa
'    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
'    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@
'    WRTTM          As String * 6     '��ѽ����(����)        9(06)
'    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD
'    WRTFSTTM       As String * 6     '��ѽ����(�o�^����)    9(06)
'    WRTFSTDT       As String * 8     '��ѽ����(�o�^��)      YYYY/MM/DD
    FOPEID         As String * 8     '����o�^�S����ID
    FCLTID         As String * 5     '����o�^�N���C�A���gID
    WRTFSTTM       As String * 6     '��ѽ����(����o�^����)
    WRTFSTDT       As String * 8     '��ѽ����(����o�^���t)
    OPEID          As String * 8     '�X�V�S���҃R�[�h
    CLTID          As String * 5     '�X�V�N���C�A���g�h�c
    WRTTM          As String * 6     '��ѽ����(�X�V����)
    WRTDT          As String * 8     '��ѽ����(�X�V���t)
    UOPEID         As String * 8     '�o�b�`�X�V�S���҃R�[�h
    UCLTID         As String * 5     '�o�b�`�X�V�N���C�A���gID
    UWRTTM         As String * 6     '��ѽ����(�o�b�`�X�V����)
    UWRTDT         As String * 8     '��ѽ����(�o�b�`�X�V���t)
    PGID           As String * 7      '��۸���ID
' === 20061227 === UPDATE E -

End Type
Global DB_MEIMTA As TYPE_DB_MEIMTA
Global DBN_MEIMTA As Integer

'���̃}�X�^������ʃp�����[�^
Public WLSMEI_KEYCD         As String           '�L�[

'���̃}�X�^�����߂�l
Public WLSMEI_RTNMEICDA      As String           '�R�[�h�P
Public WLSMEI_RTNMEINMA      As String           '���̂P

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Sub DB_MEIMTA_Clear
'   �T�v�F  ���̃}�X�^�\���̃N���A
'   �����F�@�Ȃ�
'   �ߒl�F
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Sub DB_MEIMTA_Clear(ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)
    Dim Clr_DB_MEIMTA As TYPE_DB_MEIMTA
    pot_DB_MEIMTA = Clr_DB_MEIMTA
End Sub

' === 20060920 === INSERT S - ACE)Sejima �����Ή�
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Sub DB_MEIMTA_SetData
'   �T�v�F  ���̃}�X�^�\���̃f�[�^�ޔ�
'   �����F�@�Ȃ�
'   �ߒl�F
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)
    
        '�f�[�^�ޔ�
        With pot_DB_MEIMTA
            .DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "")               '�`�[�폜�敪
            .KEYCD = CF_Ora_GetDyn(pin_Usr_Ody, "KEYCD", "")               '�L�[
            .MEIKMKNM = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKMKNM", "")         '���ږ�
            .MEICDA = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDA", "")             '�R�[�h�P
            .MEICDB = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDB", "")             '�R�[�h�Q
            .MEINMA = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMA", "")             '���̂P
            .MEINMB = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMB", "")             '���̂Q
            .MEINMC = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMC", "")             '���̂R
            .MEISUA = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUA", 0)              '���l���ڂP
            .MEISUB = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUB", 0)              '���l���ڂQ
            .MEISUC = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUC", 0)              '���l���ڂR
            .MEIKBA = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBA", "")             '�敪�P
            .MEIKBB = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBB", "")             '�敪�Q
            .MEIKBC = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBC", "")             '�敪�R
            .DSPORD = CF_Ora_GetDyn(pin_Usr_Ody, "DSPORD", "")             '�\������
            .RELFL = CF_Ora_GetDyn(pin_Usr_Ody, "RELFL", "")               '�A�g�t���O
' === 20061227 === UPDATE S - ACE)Nagasawa
'            .OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
'            .CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "")               '�N���C�A���g�h�c
'            .WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
'            .WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "")               '�^�C���X�^���v�i���t�j
'            .WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
'            .WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
            .FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "")             '����o�^�S����ID
            .FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "")             '����o�^�N���C�A���gID
            .WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "")         '��ѽ����(����o�^����)
            .WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "")         '��ѽ����(����o�^���t)
            .OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "")               '�X�V�S���҃R�[�h
            .CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "")               '�X�V�N���C�A���g�h�c
            .WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "")               '��ѽ����(�X�V����)
            .WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "")               '��ѽ����(�X�V���t)
            .UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "")             '�o�b�`�X�V�S���҃R�[�h
            .UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "")             '�o�b�`�X�V�N���C�A���gID
            .UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "")             '��ѽ����(�o�b�`�X�V����)
            .UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "")             '��ѽ����(�o�b�`�X�V���t)
            .PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "")                 '��۸���ID
' === 20061227 === UPDATE E -
        End With
    
    End Sub
' === 20060920 === INSERT E

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function DSPMEIM_SEARCH
'   �T�v�F  ���̃}�X�^����
'   �����F  pin_strKEYCD  : �L�[�P
'           pin_strMEICDA : �R�[�h�P
'           pot_DB_MEIMTA : ��������
'           pin_strMEICDB : �R�[�h�Q�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIM_SEARCH(ByVal pin_strKEYCD As String, _
                                   ByVal pin_strMEICDA As String, _
                                   ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, _
                          Optional ByVal pin_strMEICDB As Variant) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody_LC      As U_Ody
        
    On Error GoTo ERR_DSPMEIM_SEARCH
    
        DSPMEIM_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
        If IsMissing(pin_strMEICDB) = False Then
            strSQL = strSQL & "   and  MEICDB = '" & pin_strMEICDB & "' "
        End If
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '�擾�f�[�^�Ȃ�
            DSPMEIM_SEARCH = 1
            GoTo END_DSPMEIM_SEARCH
        End If
        
        '�擾�f�[�^�ޔ�
' === 20060920 === UPDATE S - ACE)Sejima
'D        With pot_DB_MEIMTA
'D            .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '�`�[�폜�敪
'D            .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               '�L�[
'D            .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '���ږ�
'D            .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             '�R�[�h�P
'D            .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             '�R�[�h�Q
'D            .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '���̂P
'D            .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '���̂Q
'D            .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '���̂R
'D            .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '���l���ڂP
'D            .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '���l���ڂQ
'D            .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '���l���ڂR
'D            .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '�敪�P
'D            .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '�敪�Q
'D            .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '�敪�R
'D            .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '�\������
'D            .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '�A�g�t���O
'D            .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
'D            .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               '�N���C�A���g�h�c
'D            .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
'D            .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               '�^�C���X�^���v�i���t�j
'D            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
'D            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
'D        End With
' === 20060920 === UPDATE ��
        Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
' === 20060920 === UPDATE E
     
        DSPMEIM_SEARCH = 0
        
END_DSPMEIM_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
   
        Exit Function
    
ERR_DSPMEIM_SEARCH:
    
    End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function DSPMEINMA_SEARCH_A1
'   �T�v�F  ���̃}�X�^����(���̂P�̂����܂������j
'   �����F  pin_strKEYCD  : �L�[�P
'           pin_strMEINMA : ���̂P
'           pot_DB_MEIMTA : ��������
'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEINMA_SEARCH_A1(ByVal pin_strKEYCD As String, _
                                        ByVal pin_strMEINMA As String, _
                                        ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA) As Integer

        Dim strSQL          As String
        Dim strSQLCount     As String
        Dim intData         As Integer
        Dim Usr_Ody_LC      As U_Ody
        Dim intIdx          As Integer
        
    On Error GoTo ERR_DSPMEINMA_SEARCH_A1
    
        DSPMEINMA_SEARCH_A1 = 9
        
        strSQL = ""
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEINMA Like '" & pin_strMEINMA & "%' "
        
        '�����擾
        strSQLCount = ""
        strSQLCount = strSQLCount & " Select Count(*) as DataCount "
        strSQLCount = strSQLCount & strSQL
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)
        
        intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)
        
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
        
        If intData = 0 Then
            '�擾�f�[�^�Ȃ�
            DSPMEINMA_SEARCH_A1 = 1
            Exit Function
        End If
            
        strSQL = " Select * " & strSQL
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '�擾�f�[�^�Ȃ�
            DSPMEINMA_SEARCH_A1 = 1
            GoTo END_DSPMEINMA_SEARCH_A1
        End If
        
        '�擾�f�[�^�ޔ�
        ReDim pot_DB_MEIMTA(intData)
        intIdx = 1
        Do Until CF_Ora_EOF(Usr_Ody_LC) = True
' === 20060920 === UPDATE S - ACE)Sejima
'D            With pot_DB_MEIMTA(intIdx)
'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '�`�[�폜�敪
'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               '�L�[
'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '���ږ�
'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             '�R�[�h�P
'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             '�R�[�h�Q
'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '���̂P
'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '���̂Q
'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '���̂R
'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '���l���ڂP
'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '���l���ڂQ
'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '���l���ڂR
'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '�敪�P
'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '�敪�Q
'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '�敪�R
'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '�\������
'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '�A�g�t���O
'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               '�N���C�A���g�h�c
'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               '�^�C���X�^���v�i���t�j
'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
'D            End With
' === 20060920 === UPDATE ��
            Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intIdx))
' === 20060920 === UPDATE E
            intIdx = intIdx + 1
            Call CF_Ora_MoveNext(Usr_Ody_LC)
        Loop
        
        DSPMEINMA_SEARCH_A1 = 0
        
END_DSPMEINMA_SEARCH_A1:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function
    
ERR_DSPMEINMA_SEARCH_A1:
    
    End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function DSPMEINMB_SEARCH
'   �T�v�F  ���̃}�X�^����(���̂Q�̌����j
'   �����F  pin_strKEYCD  : �L�[�P
'           pin_strMEINMB : ���̂Q
'           pot_DB_MEIMTA : ��������
'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEINMB_SEARCH(ByVal pin_strKEYCD As String, _
                                        ByVal pin_strMEINMB As String, _
                                        ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Integer

        Dim strSQL          As String
        Dim strSQLCount     As String
        Dim intData         As Integer
        Dim Usr_Ody_LC      As U_Ody
        Dim intIdx          As Integer
        
    On Error GoTo ERR_DSPMEINMB_SEARCH
    
        DSPMEINMB_SEARCH = 9
        
        strSQL = ""
        strSQL = " Select * " & strSQL
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEINMB =    '" & CF_Ora_String(pin_strMEINMB, 20) & "' "
            
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '�擾�f�[�^�Ȃ�
            DSPMEINMB_SEARCH = 1
            GoTo END_DSPMEINMB_SEARCH
        End If
        
        '�擾�f�[�^�ޔ�
        If CF_Ora_EOF(Usr_Ody_LC) = False Then
' === 20060920 === UPDATE S - ACE)Sejima �����Ή�
'D            With pot_DB_MEIMTA
'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '�`�[�폜�敪
'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               '�L�[
'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '���ږ�
'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             '�R�[�h�P
'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             '�R�[�h�Q
'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '���̂P
'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '���̂Q
'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '���̂R
'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '���l���ڂP
'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '���l���ڂQ
'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '���l���ڂR
'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '�敪�P
'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '�敪�Q
'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '�敪�R
'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '�\������
'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '�A�g�t���O
'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               '�N���C�A���g�h�c
'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               '�^�C���X�^���v�i���t�j
'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
'D            End With
' === 20060920 === UPDATE ��
            Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
' === 20060920 === UPDATE E
        End If
        
        DSPMEINMB_SEARCH = 0
        
END_DSPMEINMB_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function
    
ERR_DSPMEINMB_SEARCH:
    
    End Function

' === 20060920 === INSERT S - ACE)Sejima �����Ή�
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function DSPMEIKBA_SEARCH
'   �T�v�F  ���̃}�X�^����
'   �����F  pin_strKEYCD  : �L�[�P
'           pin_strMEICDA : �R�[�h�P
'           pot_DB_MEIMTA : ��������
'           pin_strMEICDB : �R�[�h�Q�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIKBA_SEARCH(ByVal pin_strKEYCD As String, _
                                     ByVal pin_strMEIKBA As String, _
                                     ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody_LC      As U_Ody
        
    On Error GoTo ERR_DSPMEIKBA_SEARCH
    
        DSPMEIKBA_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEIKBA = '" & pin_strMEIKBA & "' "
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '�擾�f�[�^�Ȃ�
            DSPMEIKBA_SEARCH = 1
            GoTo END_DSPMEIKBA_SEARCH
        End If
        
        '�擾�f�[�^�ޔ�
        Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
     
        DSPMEIKBA_SEARCH = 0
        
END_DSPMEIKBA_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
   
        Exit Function
    
ERR_DSPMEIKBA_SEARCH:
    
    End Function
' === 20060920 === INSERT E

' === 20060822 === INSERT S - ACE)Sejima
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Get_KNNOUGYO
    '   �T�v�F  ����[���|�[���Ǝҁi�[�����o�^�p�j�擾
    '   �����F  pm_All           : ��ʏ��
    '           pot_intMaxLinNo  : �擾�s��
    '   �ߒl�F  0 : ����@1 : �Y���f�[�^�Ȃ��@9 : �ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_KNNOUGYO(ByVal pin_strBINCD As String, _
                                ByRef pot_strKNNOUGYO As String) As Integer

    Dim strKNNOUGYO    As String
    Dim intRet         As Integer
    Dim Mst_Inf        As TYPE_DB_MEIMTA
    Dim Ret_Value      As Integer
    
    On Error GoTo CF_Get_KNNOUGYO_Err

    '��������u�ُ�v
    Ret_Value = 9
    '��������u�Ȃ��v
    strKNNOUGYO = gc_strKNNOUGYO_NO
    
    If Trim(pin_strBINCD) <> "" Then
                
        '�֖��R�[�h�̓��͂�����ꍇ�A���R�[�h���L�[�Ƃ��Ė��̃}�X�^������
        Call DB_MEIMTA_Clear(Mst_Inf)
        intRet = DSPMEIM_SEARCH(gc_strKEYCD_BINCD, pin_strBINCD, Mst_Inf)
        
        If intRet = 0 Then
            If Trim(Mst_Inf.MEINMB) <> "" Then
                '�f�[�^���擾�ł��A�����̂Q�ɒl�������Ă���
                '�@�˂��̒l��Ԃ��i���[���Ǝҁj
                strKNNOUGYO = Trim(Mst_Inf.MEINMB)
            
            End If
        End If
        
    End If
    
    '�u����v
    Ret_Value = 0
    
CF_Get_KNNOUGYO_End:
    '�擾�����R�[�h��Ԃ�
    pot_strKNNOUGYO = strKNNOUGYO
    
    CF_Get_KNNOUGYO = Ret_Value
    Exit Function

CF_Get_KNNOUGYO_Err:
    GoTo CF_Get_KNNOUGYO_End

End Function
' === 20060822 === INSERT E

' === 20060921 === INSERT S - ACE)Sejima
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Get_CRM_RsnCnKb
    '   �T�v�F  �󒍁i��ݾفj���R�擾�iCRM�p�j
    '   �����F�@pin_strKEYCD   : �L�[
    '           pin_strMEICDA  : �R�[�h�P
    '           pot_strRsnCnKb : ���R���ށi���̂R�j
    '           pot_strRsnCnNm : ���R���́i���̂Q�j
    '   �ߒl�F�@0:����  9:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_CRM_RsnCnKb(ByVal pin_strKEYCD As String, _
                                   ByVal pin_strMEICDA As String, _
                                   ByRef pot_strRsnCnKb As String, _
                                   ByRef pot_strRsnCnNm As String) As Integer
    
    Dim Ret_Value        As Integer
    Dim Mst_Inf          As TYPE_DB_MEIMTA
    
    On Error GoTo CF_Get_CRM_RsnCnKb_End
    
    CF_Get_CRM_RsnCnKb = 9
    
    '��������G���[����
    Ret_Value = 9
    
    '�߂��ϐ���������
    pot_strRsnCnKb = ""
    pot_strRsnCnNm = ""
    
    If DSPMEIM_SEARCH(pin_strKEYCD, pin_strMEICDA, Mst_Inf) = 0 Then
        '�_���폜�`�F�b�N
        If Mst_Inf.DATKB = "9" Then
        Else
            '�擾�l���i�[
            pot_strRsnCnKb = Trim(Mst_Inf.MEINMC)
            pot_strRsnCnNm = Trim(Mst_Inf.MEINMB)
        End If
    End If
    
    'CRM�ҏW�p�ɉ��H
    pot_strRsnCnKb = CF_ZeroLenFormat(pot_strRsnCnKb, 6, True)
    pot_strRsnCnNm = CF_Ctr_AnsiLeftB(pot_strRsnCnNm & Space(40), 40)
    
    '���툵��
    Ret_Value = 0
    
CF_Get_CRM_RsnCnKb_End:
    '�߂�l��Ԃ�
    CF_Get_CRM_RsnCnKb = Ret_Value
    
End Function
' === 20060921 === INSERT E

' === 20061110 === INSERT S - ACE)Nagasawa �Z�b�g�A�b�v�d�ύX�Ή�
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function DSPMEIM_SEARCH_ALL
'   �T�v�F  ���̃}�X�^����
'   �����F  pin_strKEYCD  : �L�[�P
'           pot_DB_MEIMTA : �������ʁi�z��j
'   �ߒl�F�@0:����I�� 9:�ُ�I��
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIM_SEARCH_ALL(ByVal pin_strKEYCD As String, _
                                       ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA) As Integer

        Dim strSQL          As String
        Dim strSQL_Where    As String
        Dim intData         As Integer
        Dim Usr_Ody_LC      As U_Ody
        
    On Error GoTo ERR_DSPMEIM_SEARCH_ALL
    
        DSPMEIM_SEARCH_ALL = 9
        
        '�߂�l�̃N���A
        Erase pot_DB_MEIMTA
        
        strSQL = ""
        strSQL = strSQL & " Select Count(*) As CNTDATA"
        
        strSQL_Where = ""
        strSQL_Where = strSQL_Where & "   from MEIMTA "
        strSQL_Where = strSQL_Where & "  Where KEYCD  = '" & pin_strKEYCD & "' "
        
        strSQL = strSQL & strSQL_Where
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        
        '�����擾
        intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))
        
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
        
        '����
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & strSQL_Where
        
        ReDim pot_DB_MEIMTA(intData)
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        
        '�擾�f�[�^�ޔ�
        intData = 1
        Do Until CF_Ora_EOF(Usr_Ody_LC) = True
        
            Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intData))
            
            Call CF_Ora_MoveNext(Usr_Ody_LC)
            intData = intData + 1
        Loop
        
        DSPMEIM_SEARCH_ALL = 0
        
END_DSPMEIM_SEARCH_ALL:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
   
        Exit Function
    
ERR_DSPMEIM_SEARCH_ALL:
    
    End Function
' === 20061110 === INSERT E -
