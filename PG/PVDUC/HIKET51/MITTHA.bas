Attribute VB_Name = "MITTHA_DBM"
        Option Explicit
'==========================================================================
'   MITTHA.DBM   ���ό��o�g����                   UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_MITTHA
    DATNO           As String * 10      '�`�[�Ǘ���
    DATKB           As String * 1       '�`�[�폜�敪
    DENKB           As String * 1       '�`�[�敪
    MITNO           As String * 10      '���ϔԍ�
    MITNOV          As String * 2       '�Ő�
    AKNID           As String * 8       '�Č��h�c
    MITDT           As String * 8       '���ϓ��t
    JDNYTDT         As String * 8       '�󒍗\���
    DEFNOKDT        As String * 8       '�[��
    NOKDTPRT        As String * 40      '�q��[���i�󎚗p�j
    TOKCD           As String * 10      '���Ӑ�R�[�h
    TOKRN           As String * 40      '���Ӑ旪��
    NHSCD           As String * 10      '�[����R�[�h
    NHSNMA          As String * 60      '�[���於�̂P
    NHSNMB          As String * 60      '�[���於�̂Q
    TANCD           As String * 6       '�S���҃R�[�h
    TANNM           As String * 40      '�S���Җ�
    BUMCD           As String * 6       '����R�[�h
    BUMNM           As String * 40      '�c�ƕ��喼
    SOUCD           As String * 3       '�q�ɃR�[�h
    SOUNM           As String * 20      '�q�ɖ�
    ZKTKB           As String * 1       '����敪
    ZKTNM           As String * 4       '����敪��
    SBAMITKN        As Currency         '���ϋ��z�i�{�̍��v�j
    SBAMZEKN        As Currency         '���ϋ��z�i����Ŋz�j
    SBAMZKKN        As Currency         '���ϋ��z�i�`�[�v�j
    DENCMA          As String * 80      '���l�P
    DENCMB          As String * 80      '���l�Q
    DENCMC          As String * 80      '���l�R
    DENCMD          As String * 80      '���l�S
    DENCME          As String * 80      '���l�T
    DENCMF          As String * 80      '���l�U
    TFPATH          As String * 128     '�Y�t�t�@�C���p�X
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
    JDNNO           As String * 10      '�󒍔ԍ�
    MSBNNO          As String * 20      '����
    KENNMA          As String * 40      '�����P
    KENNMB          As String * 40      '�����Q
    YUKOKGN         As String * 30      '�L������
    SHAJKN          As String * 30      '�x������
    JDNTRKB         As String * 2       '�󒍎���敪
    NHSADA          As String * 60      '�[����Z���P
    NHSADB          As String * 60      '�[����Z���Q
    NHSADC          As String * 60      '�[����Z���R
    KKTMTFL         As String * 1       '�m�茩�σt���O
    HANPLFL         As String * 1       '�̔��v��A�g�t���O
    TKAFL           As String * 1       '�����t���O
    KHIKFL          As String * 1       '�������t���O
    TOKTL           As String * 20      '���Ӑ�d�b�ԍ�
    TOKFX           As String * 20      '���Ӑ�e�`�w�ԍ�
    TOKTANNM        As String * 30      '���Ӑ��S���Җ�
    TOKMLAD         As String * 50      '���Ӑ惁�[���A�h���X
    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
    CLTID           As String * 5       '�N���C�A���g�h�c
    WRTTM           As String * 6       '�^�C���X�^���v�i���ԁj
    WRTDT           As String * 8       '�^�C���X�^���v�i���t�j
    WRTFSTTM        As String * 6       '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT        As String * 8       '�^�C���X�^���v�i�o�^���j
End Type
Global DB_MITTHA As TYPE_DB_MITTHA
Global DBN_MITTHA As Integer
' Index1( DATNO )
' Index2( DATKB + DENKB + MITNO )
' Index3( SMADT )
' Index4( DATKB + MITDT + MITNO + TOKCD )

Sub MITTHA_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_MITTHA, G_LB)
    Call ResetBuf(DBN_MITTHA)
End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMITTHA_SEARCH
    '   �T�v�F  ���ό��o���g��������
    '   �����F�@pin_strMITNO          :���ϔԍ�
    '           pin_strMITNOV  �@�@�@ :�Ő�
    '           pot_DB_MITTHA  �@�@�@ :���ό��o���g�����f�[�^
    '           pin_strDATKB   �@�@�@ :�`�[�폜�敪�iOptional�A�n����Ȃ��ꍇ"1"�j
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function DSPMITTHA_SEARCH(ByVal pin_strMITNO As String, _
                                  ByVal pin_strMITNOV As String, _
                                  ByRef pot_DB_MITTHA As TYPE_DB_MITTHA, _
                         Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Integer

    Dim strSQL          As String
    Dim intData         As Integer
    Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPMITTHA_SEARCH
    
    DSPMITTHA_SEARCH = 9
    
    strSQL = ""
    strSQL = strSQL & " Select * "
    strSQL = strSQL & "   from MITTHA "
    strSQL = strSQL & "  Where MITNO = '" & pin_strMITNO & "' "
    strSQL = strSQL & "  And   MITNOV = '" & pin_strMITNOV & "' "
    strSQL = strSQL & "  And   DATKB = '" & pin_strDATKB & "' "

    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    If CF_Ora_EOF(Usr_Ody) = True Then
        '�擾�f�[�^�Ȃ�
        DSPMITTHA_SEARCH = 1
        Exit Function
    End If
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        With pot_DB_MITTHA
            .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")                    '�`�[�Ǘ���
            .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '�`�[�폜�敪
            .DENKB = CF_Ora_GetDyn(Usr_Ody, "DENKB", "")                    '�`�[�敪
            .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "")                    '���ϔԍ�
            .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")                  '�Ő�
            .AKNID = CF_Ora_GetDyn(Usr_Ody, "AKNID", "")                    '�Č��h�c
            .MITDT = CF_Ora_GetDyn(Usr_Ody, "MITDT", "")                    '���ϓ��t
            .JDNYTDT = CF_Ora_GetDyn(Usr_Ody, "JDNYTDT", "")                '�󒍗\���
            .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "DEFNOKDT", "")              '�[��
            .NOKDTPRT = CF_Ora_GetDyn(Usr_Ody, "NOKDTPRT", "")              '�q��[���i�󎚗p�j
            .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '���Ӑ�R�[�h
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '���Ӑ旪��
            .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "")                    '�[����R�[�h
            .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "")                  '�[���於�̂P
            .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "")                  '�[���於�̂Q
            .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    '�S���҃R�[�h
            .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    '�S���Җ�
            .BUMCD = CF_Ora_GetDyn(Usr_Ody, "BUMCD", "")                    '����R�[�h
            .BUMNM = CF_Ora_GetDyn(Usr_Ody, "BUMNM", "")                    '�c�ƕ��喼
            .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")                    '�q�ɃR�[�h
            .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")                    '�q�ɖ�
            .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "ZKTKB", "")                    '����敪
            .ZKTNM = CF_Ora_GetDyn(Usr_Ody, "ZKTNM", "")                    '����敪��
            .SBAMITKN = CF_Ora_GetDyn(Usr_Ody, "SBAMITKN", 0)               '���ϋ��z�i�{�̍��v�j
            .SBAMZEKN = CF_Ora_GetDyn(Usr_Ody, "SBAMZEKN", 0)               '���ϋ��z�i����Ŋz�j
            .SBAMZKKN = CF_Ora_GetDyn(Usr_Ody, "SBAMZKKN", 0)               '���ϋ��z�i�`�[�v�j
            .DENCMA = CF_Ora_GetDyn(Usr_Ody, "DENCMA", "")                  '���l�P
            .DENCMB = CF_Ora_GetDyn(Usr_Ody, "DENCMB", "")                  '���l�Q
            .DENCMC = CF_Ora_GetDyn(Usr_Ody, "DENCMC", "")                  '���l�R
            .DENCMD = CF_Ora_GetDyn(Usr_Ody, "DENCMD", "")                  '���l�S
            .DENCME = CF_Ora_GetDyn(Usr_Ody, "DENCME", "")                  '���l�T
            .DENCMF = CF_Ora_GetDyn(Usr_Ody, "DENCMF", "")                  '���l�U
            .TFPATH = CF_Ora_GetDyn(Usr_Ody, "TFPATH", "")                  '�Y�t�t�@�C���p�X
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
            .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")                    '�󒍔ԍ�
            .MSBNNO = CF_Ora_GetDyn(Usr_Ody, "MSBNNO", "")                  '����
            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "")                  '�����P
            .KENNMB = CF_Ora_GetDyn(Usr_Ody, "KENNMB", "")                  '�����Q
            .YUKOKGN = CF_Ora_GetDyn(Usr_Ody, "YUKOKGN", "")                '�L������
            .SHAJKN = CF_Ora_GetDyn(Usr_Ody, "SHAJKN", "")                  '�x������
            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")                '�󒍎���敪
            .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "")                  '�[����Z���P
            .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "")                  '�[����Z���Q
            .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "")                  '�[����Z���R
            .KKTMTFL = CF_Ora_GetDyn(Usr_Ody, "KKTMTFL", "")                '�m�茩�σt���O
            .HANPLFL = CF_Ora_GetDyn(Usr_Ody, "HANPLFL", "")                '�̔��v��A�g�t���O
            .TKAFL = CF_Ora_GetDyn(Usr_Ody, "TKAFL", "")                    '�����t���O
            .KHIKFL = CF_Ora_GetDyn(Usr_Ody, "KHIKFL", "")                  '�������t���O
            .TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")                    '���Ӑ�d�b�ԍ�
            .TOKFX = CF_Ora_GetDyn(Usr_Ody, "TOKFX", "")                    '���Ӑ�e�`�w�ԍ�
            .TOKTANNM = CF_Ora_GetDyn(Usr_Ody, "TOKTANNM", "")              '���Ӑ��S���Җ�
            .TOKMLAD = CF_Ora_GetDyn(Usr_Ody, "TOKMLAD", "")                '���Ӑ惁�[���A�h���X
            .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '�ŏI��Ǝ҃R�[�h
            .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    '�N���C�A���g�h�c
            .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '�^�C���X�^���v�i���ԁj
            .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '�^�C���X�^���v�i���t�j
            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '�^�C���X�^���v�i�o�^���ԁj
            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '�^�C���X�^���v�i�o�^���j
        End With
    End If

    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody)
    

    DSPMITTHA_SEARCH = 0
    
    Exit Function
    
ERR_DSPMITTHA_SEARCH:
        
End Function
    


