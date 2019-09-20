Attribute VB_Name = "FIXMTA_DBM"
        Option Explicit
'==========================================================================
'   FIXMTA.DBM   �Œ�l�}�X�^                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_FIXMTA
    DATKB          As String * 1     '�폜�敪
    CTLCD          As String * 10    '�Ǘ��R�[�h
    CTLNM          As String * 50    '�Ǘ�����
    FIXVAL         As String * 20    '�Œ�l
    REMARK         As String * 128   '���l
    RELFL          As String * 1     '�A�g�t���O
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h
    CLTID          As String * 5     '�N���C�A���g�h�c
    WRTTM          As String * 6     '�^�C���X�^���v�i���ԁj
    WRTDT          As String * 8     '�^�C���X�^���v�i���t�j
    WRTFSTTM       As String * 6     '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT       As String * 8     '�^�C���X�^���v�i�o�^���j
End Type
Global DB_FIXMTA As TYPE_DB_FIXMTA
Global DBN_FIXMTA As Integer

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_FIXMTA_Clear
    '   �T�v�F  �Œ�l�}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_FIXMTA_Clear(ByRef pot_DB_FIXMTA As TYPE_DB_FIXMTA)

        Dim Clr_DB_FIXMTA As TYPE_DB_FIXMTA
    
        pot_DB_FIXMTA = Clr_DB_FIXMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPCTLCD_SEARCH
    '   �T�v�F  �Ǘ��R�[�h����
    '   �����F  pin_strCTLCD  : �����ΏۊǗ��R�[�h
    '           pot_DB_FIXMTA : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCTLCD_SEARCH(ByVal pin_strCTLCD As String, _
                                    ByRef pot_DB_FIXMTA As TYPE_DB_FIXMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPCTLCD_SEARCH
    
        DSPCTLCD_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from FIXMTA "
        strSQL = strSQL & "  Where CTLCD = '" & pin_strCTLCD & "' "
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPCTLCD_SEARCH = 1
            GoTo END_DSPCTLCD_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_FIXMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�폜�敪
                .CTLCD  = CF_Ora_GetDyn(Usr_Ody, "CTLCD", "")                   '�Ǘ��R�[�h
                .CTLNM  = CF_Ora_GetDyn(Usr_Ody, "CTLNM", "")                   '�Ǘ�����
                .FIXVAL = CF_Ora_GetDyn(Usr_Ody, "FIXVAL", "")                  '�Œ�l
                .REMARK = CF_Ora_GetDyn(Usr_Ody, "REMARK", "")                  '���l
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '�A�g�t���O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
            End With
        End If

        DSPCTLCD_SEARCH = 0
        
END_DSPCTLCD_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        Exit Function
    
ERR_DSPCTLCD_SEARCH:
        GoTo END_DSPCTLCD_SEARCH
        
    End Function
