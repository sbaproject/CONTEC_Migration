Attribute VB_Name = "SYSTBB_DBM"
        Option Explicit
'==========================================================================
'   SYSTBB.DBM   ����Ńe�[�u��                   UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBB
    ZEIDT          As String * 8     '������t              YYYY/MM/DD
    ZEIRNKKB       As String * 1     '����Ń����N          0
    ZEIRT          As Currency       '����ŗ�              ##0.00;;#
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@
    WRTTM          As String * 6     '��ѽ����(����)        9(06)
    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD
    WRTFSTTM       As String * 6     '��ѽ����(�o�^����)    9(06)
    WRTFSTDT       As String * 8     '��ѽ����(�o�^���t)    YYYY/MM/DD
End Type
Global DB_SYSTBB As TYPE_DB_SYSTBB
Global DBN_SYSTBB As Integer

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_SYSTBB_Clear
    '   �T�v�F  ����Ńe�[�u���\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_SYSTBB_Clear(ByRef pot_DB_SYSTBB As TYPE_DB_SYSTBB)

        Dim Clr_DB_SYSTBB As TYPE_DB_SYSTBB
    
        pot_DB_SYSTBB = Clr_DB_SYSTBB
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPZEIRT_SEARCH
    '   �T�v�F  ����ŗ�����
    '   �����F  pin_strZEIDT    : ���
    '           pin_strZEIRNKKB : ����Ń����N
    '           pot_DB_SYSTBB   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPZEIRT_SEARCH(ByVal pin_strZEIDT As String, _
                                    ByVal pin_strZEIRNKKB As String, _
                                    ByRef pot_DB_SYSTBB As TYPE_DB_SYSTBB) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody_LC      As U_Ody

    On Error GoTo ERR_DSPZEIRT_SEARCH
    
        DSPZEIRT_SEARCH = 9
        
' === 20131203 === INSERT S - RS)Ishida ����Ŗ@�����Ή�
        '�p�����[�^�̎擾���t���A"/"����������B
        pin_strZEIDT = Replace(pin_strZEIDT, "/", "")
' === 20131203 === INSERT E -

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SYSTBB "
        strSQL = strSQL & "  Where ZEIDT    <= '" & pin_strZEIDT & "' "
        strSQL = strSQL & "    and ZEIRNKKB  = '" & pin_strZEIRNKKB & "' "
        strSQL = strSQL & "  Order by ZEIDT DESC "
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
 
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '�擾�f�[�^�Ȃ�
            DSPZEIRT_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody_LC) = False Then
            With pot_DB_SYSTBB
                .ZEIDT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIDT", "")                    '�`�[�폜�敪
                .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRNKKB", "")              '�`�[�폜�敪
                .ZEIRT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRT", 0)                     '�`�[�폜�敪
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
        

        DSPZEIRT_SEARCH = 0
        
        Exit Function
    
ERR_DSPZEIRT_SEARCH:
        
        
    End Function


