Attribute VB_Name = "CLDMTA_DBM"
        Option Explicit
'==========================================================================
'   CLDMTA.DBM   �J�����_�}�X�^                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Public Const DATE_KBN_SLDKB As Integer = 1          '�c�Ɠ��敪
Public Const DATE_KBN_BNKKDKB As Integer = 2        '��s�ғ��敪
Public Const DATE_KBN_DTBKDKB As Integer = 3        '�����ғ��敪
Public Const DATE_KBN_ETCKBA As Integer = 4         '���̑��敪�P
Public Const DATE_KBN_ETCKBB As Integer = 5         '���̑��敪�Q
Public Const DATE_KBN_ETCKBC As Integer = 6         '���̑��敪�R
Public Const DATE_KBN_ETCKBD As Integer = 7         '���̑��敪�S
Public Const DATE_KBN_ETCKBE As Integer = 8         '���̑��敪�T
Public Const DATE_KBN_ETCKBF As Integer = 9         '���̑��敪�U
Public Const DATE_KBN_ETCKBG As Integer = 10        '���̑��敪�V
Public Const DATE_KBN_ETCKBH As Integer = 11        '���̑��敪�W
Public Const DATE_KBN_ETCKBI As Integer = 12        '���̑��敪�X
Public Const DATE_KBN_ETCKBJ As Integer = 13        '���̑��敪�P�O

Type TYPE_DB_CLDMTA
    DATKB               As String * 1     '�`�[�폜�敪
    CLDDT               As String * 8     '���t
    CLDWKKB             As String * 1     '�j��
    CLDHLKB             As String * 6     '�j��
    SLSMDD              As Currency       '�c�ƒʎZ����
    PRDKDDD             As Currency       '���Y�ғ�����
    DTBKDDD             As Currency       '�����ғ�����
    CLDSMDD             As Currency       '����ʎZ����
    SLDKB               As String * 1     '�c�Ɠ��敪
    BNKKDKB             As String * 1     '��s�ғ��敪
    PRDKDKB             As String * 1     '���Y�ғ��敪
    DTBKDKB             As String * 1     '�����ғ��敪
    ETCKBA              As String * 1     '���̑��敪�P
    ETCKBB              As String * 1     '���̑��敪�Q
    ETCKBC              As String * 1     '���̑��敪�R
    ETCKBD              As String * 1     '���̑��敪�S
    ETCKBE              As String * 1     '���̑��敪�T
    ETCKBF              As String * 1     '���̑��敪�U
    ETCKBG              As String * 1     '���̑��敪�V
    ETCKBH              As String * 1     '���̑��敪�W
    ETCKBI              As String * 1     '���̑��敪�X
    ETCKBJ              As String * 1     '���̑��敪�P�O
    OPEID               As String * 8     '�ŏI��Ǝ҃R�[�h
    CLTID               As String * 5     '�N���C�A���g�h�c
    WRTTM               As String * 6     '�^�C���X�^���v�i���ԁj
    WRTDT               As String * 8     '�^�C���X�^���v�i���t�j
    WRTFSTTM            As String * 6     '�^�C���X�^���v�i�o�^���ԁj
    WRTFSTDT            As String * 8     '�^�C���X�^���v�i�o�^���j
End Type
Global DB_CLDMTA As TYPE_DB_CLDMTA
Global DBN_TCLDMTA As Integer

'�J�����_�}�X�^������ʃp�����[�^
'�c�Ɠ��敪,��s�ғ��敪,�����ғ��敪,���̑��敪�P,���̑��敪�Q
'���̑��敪�R,���̑��敪�S,���̑��敪�T,���̑��敪�U,���̑��敪�V
'���̑��敪�W,���̑��敪�X,���̑��敪�P�O
Public WLSDATE_KBN         As Integer

'�J�����_�����߂�l
Public WLSDATE_RTNCODE       As String           '���t�iyyyy/mm/dd�j

' === 20070309 === UPDATE S - ACE)Nagasawa
'Private Const KDKB_Holiday As String = "9"
'Private Const KDKB_WORK    As String = "1"
Public Const KDKB_Holiday As String = "9"
Public Const KDKB_WORK    As String = "1"
' === 20070309 === UPDATE E -


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_CLDMTA_Clear
    '   �T�v�F  �J�����_�}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_CLDMTA_Clear(ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA)

        Dim Clr_DB_CLDMTA As TYPE_DB_CLDMTA
    
        pot_DB_CLDMTA = Clr_DB_CLDMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPCLDDT_SEARCH
    '   �T�v�F  �J�����_�}�X�^����
    '   �����F  pin_strCLDDT  : �����Ώۓ��t
    '           pot_DB_CLDMTA : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCLDDT_SEARCH(ByVal pin_strCLDDT As String, _
                                    ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPCLDDT_SEARCH
    
        DSPCLDDT_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where CLDDT = '" & pin_strCLDDT & "' "
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPCLDDT_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_CLDMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                       '�`�[�폜�敪
                .CLDDT = CF_Ora_GetDyn(Usr_Ody, "CLDDT", "")                       '���t
                .CLDWKKB = CF_Ora_GetDyn(Usr_Ody, "CLDWKKB", "")                   '�j��
                .CLDHLKB = CF_Ora_GetDyn(Usr_Ody, "CLDHLKB", "")                   '�j��
                .SLSMDD = CF_Ora_GetDyn(Usr_Ody, "SLSMDD", 0)                      '�c�ƒʎZ����
                .PRDKDDD = CF_Ora_GetDyn(Usr_Ody, "PRDKDDD", 0)                    '���Y�ғ�����
                .DTBKDDD = CF_Ora_GetDyn(Usr_Ody, "DTBKDDD", 0)                    '�����ғ�����
                .CLDSMDD = CF_Ora_GetDyn(Usr_Ody, "CLDSMDD", 0)                    '����ʎZ����
                .SLDKB = CF_Ora_GetDyn(Usr_Ody, "SLDKB", "")                       '�c�Ɠ��敪
                .BNKKDKB = CF_Ora_GetDyn(Usr_Ody, "BNKKDKB", "")                   '��s�ғ��敪
                .PRDKDKB = CF_Ora_GetDyn(Usr_Ody, "PRDKDKB", "")                   '���Y�ғ��敪
                .DTBKDKB = CF_Ora_GetDyn(Usr_Ody, "DTBKDKB", "")                   '�����ғ��敪
                .ETCKBA = CF_Ora_GetDyn(Usr_Ody, "ETCKBA", "")                     '���̑��敪�P
                .ETCKBB = CF_Ora_GetDyn(Usr_Ody, "ETCKBB", "")                     '���̑��敪�Q
                .ETCKBC = CF_Ora_GetDyn(Usr_Ody, "ETCKBC", "")                     '���̑��敪�R
                .ETCKBD = CF_Ora_GetDyn(Usr_Ody, "ETCKBD", "")                     '���̑��敪�S
                .ETCKBE = CF_Ora_GetDyn(Usr_Ody, "ETCKBE", "")                     '���̑��敪�T
                .ETCKBF = CF_Ora_GetDyn(Usr_Ody, "ETCKBF", "")                     '���̑��敪�U
                .ETCKBG = CF_Ora_GetDyn(Usr_Ody, "ETCKBG", "")                     '���̑��敪�V
                .ETCKBH = CF_Ora_GetDyn(Usr_Ody, "ETCKBH", "")                     '���̑��敪�W
                .ETCKBI = CF_Ora_GetDyn(Usr_Ody, "ETCKBI", "")                     '���̑��敪�X
                .ETCKBJ = CF_Ora_GetDyn(Usr_Ody, "ETCKBJ", "")                     '���̑��敪�P�O
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                       '�ŏI��Ǝ҃R�[�h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                       '�N���C�A���g�h�c
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                       '�^�C���X�^���v�i���ԁj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                       '�^�C���X�^���v�i���t�j
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")                 '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")                 '�^�C���X�^���v�i�o�^���j
            End With
        End If

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        DSPCLDDT_SEARCH = 0
        
        Exit Function
    
ERR_DSPCLDDT_SEARCH:
        
        
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CHK_CLDDT
    '   �T�v�F  �x���`�F�b�N
    '   �����F  pin_strCLDDT  : �`�F�b�N�Ώۓ��t
    '           pin_strChkKbn : �`�F�b�N�敪(1:�c�Ɠ��`�F�b�N�@2:��s�ғ��`�F�b�N�@3:�����ғ��`�F�b�N�j
    '   �ߒl�F�@0:�ʏ�� 1:�x�� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CHK_CLDDT(ByVal pin_strCLDDT As String, _
                              ByVal pin_strChkKbn As String, _
                              ByRef pm_All As Cls_All) As Integer

        Dim Mst_Inf         As TYPE_DB_CLDMTA
        Dim intRet          As Integer
        
        '������
        Call DB_CLDMTA_Clear(Mst_Inf)
        CHK_CLDDT = 0

        '�J�����_�}�X�^����
        intRet = DSPCLDDT_SEARCH(pin_strCLDDT, Mst_Inf)
        Select Case intRet
            Case 0
                If Mst_Inf.DATKB = gc_strDATKB_USE Then
                    '���t�`�F�b�N
                    Select Case pin_strChkKbn
                        '�c�Ɠ��`�F�b�N
                        Case "1"
                            If Mst_Inf.SLDKB = KDKB_Holiday Then
                                CHK_CLDDT = 1
                            End If
                            
                        '��s�ғ��`�F�b�N
                        Case "2"
                            If Mst_Inf.BNKKDKB = KDKB_Holiday Then
                                CHK_CLDDT = 1
                            End If
                            
                        '�����ғ��`�F�b�N
                        Case "3"
                            If Mst_Inf.DTBKDKB = KDKB_Holiday Then
                                CHK_CLDDT = 1
                            End If
                            
                        Case Else
                    End Select
                Else
                    CHK_CLDDT = 9
                End If
                
            Case 1
                CHK_CLDDT = 9
                            
            Case Else
                CHK_CLDDT = 9
        End Select
        
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPCLDDT_SEARCH_KDKB
    '   �T�v�F  �J�����_�}�X�^����(�ғ����̂ݎ擾)
    '   �����F  pin_strCLDDT  : �����Ώۓ��t
    '           pin_strKDKB   : �����ғ��敪("1":�c�Ɠ� "2":��s�ғ��� "3":�����ғ���)
    '           �@�@�@�@�@�@�@�@�@�@�@�@�@�@ "12":�c�Ɠ��E��s�ғ���)
    '           pin_strKEISAN : �v�Z�敪("1":���Z "2":���Z)
    '           pot_strCLDDT  : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCLDDT_SEARCH_KDKB(ByVal pin_strCLDDT As String, _
                                         ByVal pin_strKDKB As String, _
                                         ByVal pin_strKEISAN As String, _
                                         ByRef pot_strCLDDT As String) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPCLDDT_SEARCH_KDKB
    
        DSPCLDDT_SEARCH_KDKB = 9
        pot_strCLDDT = ""
        
        strSQL = ""
        If pin_strKEISAN = "1" Then
            strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
        Else
            strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
        End If
        
        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where DATKB >= '" & gc_strDATKB_USE & "' "
        
        If pin_strKEISAN = "1" Then
            strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
        Else
            strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
        End If
        
        Select Case pin_strKDKB
            '�c�Ɠ�
            Case "1"
                strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "
                
            '��s�ғ���
            Case "2"
                strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "
                
            '�����ғ���
            Case "3"
                strSQL = strSQL & "    and DTBKDKB = '" & KDKB_WORK & "' "
                
' === 20070309 === INSERT S - ACE)Nagasawa
            '�c�Ɠ��E��s�ғ���
            Case "12"
                strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "
                strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "
' === 20070309 === INSERT E -

        End Select
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPCLDDT_SEARCH_KDKB = 1
            Exit Function
        Else
            pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
        End If
        

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        DSPCLDDT_SEARCH_KDKB = 0
        
        Exit Function
    
ERR_DSPCLDDT_SEARCH_KDKB:
        
        
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPKDDT_SEARCH
    '   �T�v�F  �J�����_�}�X�^����(�c�ƒʎZ������茟��)
    '   �����F  pin_strCLDDT  : �����ΏےʎZ���t
    '           pin_strKDKB   : �����ғ��敪("1":�c�Ɠ� "2":��s�ғ��� "3":�����ғ��� "4":���Y�ғ���)
    '           pot_strCLDDT  : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPKDDT_SEARCH(ByVal pin_strCLDDT As String, _
                                   ByVal pin_strKDKB As String, _
                                   ByRef pot_strCLDDT As String) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPKDDT_SEARCH
    
        DSPKDDT_SEARCH = 9
        pot_strCLDDT = ""
        
        strSQL = ""
        strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "
        
        Select Case pin_strKDKB
            '�c�Ɠ�
            Case "1", "2"
                strSQL = strSQL & "    and SLSMDD = " & CF_Ora_Number(pin_strCLDDT)
                     
            '�����ғ���
            Case "3"
                strSQL = strSQL & "    and DTBKDDD = " & CF_Ora_Number(pin_strCLDDT)
            
            '���Y�ғ���
            Case "4"
                strSQL = strSQL & "    and PRDKDDD = " & CF_Ora_Number(pin_strCLDDT)
        End Select
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPKDDT_SEARCH = 1
            Exit Function
        Else
            pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
        End If
        

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        DSPKDDT_SEARCH = 0
        
        Exit Function
        
ERR_DSPKDDT_SEARCH:
        
        
    End Function
    
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function AE_CalcDate_Add
'   �T�v�F  ���t�v�Z����
'   �����F�@Pio_strDate     :�v�Z�Ώۓ�(�����W���A�܂���yyyy/mm/dd�̌`���j
'           Pin_intAddDate  :���Z�Ώۓ����i�}�C�i�X�l�͌��Z�j
'           Pin_strKind     :�c�Ɠ����("1":�c�Ɠ� "2":��s�ғ����@"3":�����ғ��� "4":���Y�ғ���)
'                            �ȗ����͉c�Ɠ��ɂ��l������
'   �ߒl�F  0 : ���� 9 : �ُ�
'   ���l�F�@�o�ח\��������߂�ꍇ�̏C����A���[No.516�ōs����
'   �@�@�@�@���̓��t�����߂鎞�ɓ��֐����g�p����ꍇ�́A�����C�����K�v�ƂȂ�
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function AE_CalcDate_Add(ByRef Pio_strDate As String, _
                               ByVal Pin_intAddDate As Integer, _
                               Optional ByVal Pin_strKind As String = "0") As Integer

    Dim strDate         As String
    Dim strDate_W       As String
    Dim Mst_Inf_NOW     As TYPE_DB_CLDMTA
    Dim curCALCDATE     As Currency
    Dim curKDDATE       As Currency
    
    AE_CalcDate_Add = 9
    
    strDate = ""
    
    '���Z���l�`�F�b�N
    If IsNumeric(Pin_intAddDate) = False Then
        Exit Function
    End If
    
    '���t�������`�F�b�N
    If IsDate(Pio_strDate) = True Then
        strDate = Format(Pio_strDate, "yyyymmdd")
    End If
    
    '���t�l���ɕϊ�
    If IsDate(Format(Pio_strDate, "@@@@/@@/@@")) = True Then
        strDate = Pio_strDate
    End If
    
    If Trim(strDate) = "" Then
        Exit Function
    End If
    
    '�\���̃N���A
    Call DB_CLDMTA_Clear(Mst_Inf_NOW)
    
    curKDDATE = 0
    Select Case Pin_strKind
        '�c�Ɠ��ɂ��l������
        Case "0"
            strDate = Format(strDate, "@@@@/@@/@@")
            strDate_W = DateAdd("d", Pin_intAddDate, strDate)
            Pio_strDate = strDate_W
            AE_CalcDate_Add = 0
            
        '�c�Ɠ��A��s�ғ����l��
        Case "1", "2"
            '�J�����_�}�X�^����
            If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
                If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
                    If IsNumeric(Mst_Inf_NOW.SLSMDD) = True Then
                        curKDDATE = CCur(Mst_Inf_NOW.SLSMDD)
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If
            Else
                Exit Function
            End If
    
            '���t���Z
            curCALCDATE = curKDDATE + CCur(Pin_intAddDate)
        
        '�����ғ����l��
        Case "3"
            '�J�����_�}�X�^����
            If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
                If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
                    If IsNumeric(Mst_Inf_NOW.DTBKDDD) = True Then
                        curKDDATE = CCur(Mst_Inf_NOW.DTBKDDD)

'20081111 ADD START RISE)Tanimura  �A���[No.516
                        ' ���Z�Ώۓ������}�C�i�X�̏ꍇ
                        If Pin_intAddDate < 0 Then
                            ' �����ғ��敪 �� �x�� �̏ꍇ
                            If Mst_Inf_NOW.DTBKDKB = KDKB_Holiday Then
                                ' �Œ�l�l����擾�����l + 1
                                Pin_intAddDate = Pin_intAddDate + 1
                            End If
                        End If
'20081111 ADD END   RISE)Tanimura

                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If
            Else
                Exit Function
            End If
    
        '���Y�ғ����l��
        Case "4"
            '�J�����_�}�X�^����
            If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
                If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
                    If IsNumeric(Mst_Inf_NOW.PRDKDDD) = True Then
                        curKDDATE = CCur(Mst_Inf_NOW.PRDKDDD)
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If
            Else
                Exit Function
            End If
            
    End Select
    
    '���t���Z
    curCALCDATE = curKDDATE + CCur(Pin_intAddDate)
    
    If DSPKDDT_SEARCH(CStr(curCALCDATE), Pin_strKind, strDate_W) <> 0 Then
        Exit Function
    End If

    Pio_strDate = strDate_W
    
    AE_CalcDate_Add = 0

End Function


' === 20070309 === INSERT S - ACE)Nagasawa �����̓��͉ې���̕ύX
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPCLDDT_SEARCH_WK
    '   �T�v�F  �J�����_�}�X�^����(�j���v�Z)
    '   �����F  pin_strCLDDT   : �����Ώۓ��t
    '           pin_strCLDWKKB : �j���敪
    '           pin_strKEISAN  : �v�Z�敪("1":���Z "2":���Z)
    '           pot_strCLDDT   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F  �����Ώۓ��t���O�A�܂��͌�̗j���敪�Ŏw�肳�ꂽ�j���ɓ�������t������
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCLDDT_SEARCH_WK(ByVal pin_strCLDDT As String, _
                                       ByVal pin_strCLDWKKB As String, _
                                       ByVal pin_strKEISAN As String, _
                                       ByRef pot_strCLDDT As String) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPCLDDT_SEARCH_WK
    
        DSPCLDDT_SEARCH_WK = 9
        pot_strCLDDT = ""
        
        strSQL = ""
        If pin_strKEISAN = "1" Then
            strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
        Else
            strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
        End If
        
        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    And CLDWKKB = '" & CF_Ora_String(pin_strCLDWKKB, 1) & "' "
        
        If pin_strKEISAN = "1" Then
            strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
        Else
            strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
        End If
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPCLDDT_SEARCH_WK = 1
            Exit Function
        Else
            pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
        End If
        
        DSPCLDDT_SEARCH_WK = 0
    
ERR_DSPCLDDT_SEARCH_WK:
        
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        
    End Function
' === 20070309 === INSERT E -

