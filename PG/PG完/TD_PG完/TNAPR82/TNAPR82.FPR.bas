Attribute VB_Name = "SSSMAIN0001"
Option Explicit
'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
'
'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
Public PP_SSSMAIN As clsPP
Public CP_SSSMAIN(6 + 0 + 0 + 1) As clsCP
Public CQ_SSSMAIN(6) As String

'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
'�����������`�F�b�N���s�t���O
Public gv_bolInit                   As Boolean      '������������True(�`�F�b�N�Ȃ��j�@����ȊO��False
'��ʏ������t���O
Public gv_bolTNAPR82_INIT           As Boolean              'True:�ύX����
Public gv_bolTNAPR82_LF_Enable      As Boolean              'LF�������s�t���O(True�F���s����j
Public gv_bolKeyFlg                 As Boolean
'�r���������������������������������������������������������r
Public Type TNAPR82_TYPE_INPUT
    TEISYOYM            As String
    SOUBSCD             As String
    SOUBSNM             As String
    SOUCD               As String           '�q�ɺ���
    SOUNM               As String           '�q�ɖ�
End Type
'��ʏ��
Public TNAPR82_InputData    As TNAPR82_TYPE_INPUT

'**********Private�萔**********

'�o�͒��[�h�c
Private Const mc_strLIST_ID         As String = "TNAPR82"
'������t���O
Public gv_bolNowPrinting            As Boolean

'�O����������s���̗���
Public gv_strInitYM                 As String
'�d���������������������������������������������������������d

''**�����֐��֘A Start **
'//�ߒl
Public Const CHK_OK                 As Integer = 0              '����
Public Const CHK_WARN               As Integer = 1              '�x��
Public Const CHK_ERR_NOT_INPUT      As Integer = 10             '�����̓G���[
Public Const CHK_ERR_ELSE           As Integer = 11             '���̑��G���[

'F_Chk_Jge_Action�֐��p
Public Const CHK_KEEP              As Integer = 0              '�`�F�b�N���s
Public Const CHK_STOP              As Integer = 1              '�`�F�b�N���f

'**�����֐��֘A End  **

'//F_Set_Next_Focus�������[�h
Public Const NEXT_FOCUS_MODE_KEYRETURN     As Integer = 1      'KEYRETURN�Ɠ��l�̐���
Public Const NEXT_FOCUS_MODE_KEYRIGHT      As Integer = 2      'KEYRIGHT�Ɠ��l�̐���
Public Const NEXT_FOCUS_MODE_KEYDOWN       As Integer = 3      'KEYDOWN�Ɠ��l�̐���
'//F_Dsp_Item_Detail�������[�h
Public Const DSP_SET                As Integer = 0              '�\��
Public Const DSP_CLR                As Integer = 1              '�N���A

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Chk_HD_SOUCD
    '   �T�v�F  �q�ɃR�[�h������
    '   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
    '           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
    '           pm_All                :��ʏ��
    '   �ߒl�F�@�`�F�b�N����
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_HD_SOUCD(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                             , pm_Chk_Move As Boolean _
                             , pm_All As Cls_All) As Integer

    Dim Input_Value         As String
    Dim Mst_Inf             As TYPE_DB_SOUMTA
    Dim Retn_Code           As Integer
    Dim Msg_Flg             As Boolean
    Dim Rtn_Cd              As Integer
    Dim Err_Cd              As String

    '�`�F�b�N���s����
    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
    If Rtn_Cd = CHK_STOP Then
        '���f�̏ꍇ
        F_Chk_HD_SOUCD = Retn_Code
        Exit Function
    End If

'�r���������������������������������������������������������r
    '������
    Retn_Code = CHK_OK
    Err_Cd = ""
    Msg_Flg = False
    pm_Chk_Move = True
    Call DB_SOUMTA_Clear(Mst_Inf)

    '�����̓`�F�b�N
    If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
'        Retn_Code = CHK_ERR_NOT_INPUT
        TNAPR82_InputData.SOUCD = ""
        TNAPR82_InputData.SOUNM = ""
    Else
        '�����͈ȊO�̃`�F�b�N��
        pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

        '��b�`�F�b�N
        If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
            Retn_Code = CHK_ERR_ELSE
            Err_Cd = gc_strMsgTNAPR82_E_005              '���͔͈͊O
        Else
            '�}�X�^�`�F�b�N
            If DSPSOUCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
                '�_���폜�`�F�b�N
                If Mst_Inf.DATKB = gc_strDATKB_DEL Then
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgTNAPR82_E_015       '�폜�ς݃f�[�^
                Else
                    If Trim$(TNAPR82_InputData.SOUBSCD) <> "" And _
                        Trim$(TNAPR82_InputData.SOUBSCD) <> Trim$(Mst_Inf.SOUBSCD) Then
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgTNAPR82_E_016  '���ꏊ���ނƑq�ɺ��ނ̊֌W���s���ł��B
                    Else
                        '�n�j
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True
        
                        '�擾���ڊi�[
                        TNAPR82_InputData.SOUCD = Trim(Mst_Inf.SOUCD)
                        TNAPR82_InputData.SOUNM = Trim(Mst_Inf.SOUNM)
                    End If
                End If
            Else
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgTNAPR82_E_006          '�Y���f�[�^�Ȃ�
            End If
        End If
        
    End If
'�d���������������������������������������������������������d

    '�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
    Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

    If Msg_Flg = True And Trim(Err_Cd) <> "" Then
        '���b�Z�[�W�o��
        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    End If

    F_Chk_HD_SOUCD = Retn_Code

End Function
    

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Chk_HD_SOUBSCD
    '   �T�v�F  �ꏊ�R�[�h������
    '   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
    '           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
    '           pm_All                :��ʏ��
    '   �ߒl�F�@�`�F�b�N����
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_HD_SOUBSCD(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                             , pm_Chk_Move As Boolean _
                             , pm_All As Cls_All) As Integer

    Dim Input_Value         As String
    Dim Mst_Inf             As TYPE_DB_MEIMTA
    Dim Retn_Code           As Integer
    Dim Msg_Flg             As Boolean
    Dim Rtn_Cd              As Integer
    Dim Err_Cd              As String
    
    '�`�F�b�N���s����
    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
    If Rtn_Cd = CHK_STOP Then
        '���f�̏ꍇ
        F_Chk_HD_SOUBSCD = Retn_Code
        Exit Function
    End If

'�r���������������������������������������������������������r
    '������
    Retn_Code = CHK_OK
    Err_Cd = ""
    Msg_Flg = False
    pm_Chk_Move = True
    Call DB_MEIMTA_Clear(Mst_Inf)

    '�����̓`�F�b�N
    If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
'        Retn_Code = CHK_ERR_NOT_INPUT
        TNAPR82_InputData.SOUBSCD = ""
        TNAPR82_InputData.SOUBSNM = ""
    Else
        '�����͈ȊO�̃`�F�b�N��
        pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

        '��b�`�F�b�N
        If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
            Retn_Code = CHK_ERR_ELSE
            Err_Cd = gc_strMsgTNAPR82_E_005              '���͔͈͊O
        Else
            '�}�X�^�`�F�b�N
            If DSPMEIM_SEARCH("015", Input_Value, Mst_Inf) = 0 Then
                    '�n�j
                    Retn_Code = CHK_OK
                    pm_Chk_Move = True
    
                    '�擾���ڊi�[
                    TNAPR82_InputData.SOUBSCD = Trim(Mst_Inf.MEICDA)
                    TNAPR82_InputData.SOUBSNM = Trim(Mst_Inf.MEINMA)
'                End If
            Else
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgTNAPR82_E_006          '�Y���f�[�^�Ȃ�
            End If
        End If
        
    End If
'�d���������������������������������������������������������d

    '�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
    Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

    If Msg_Flg = True And Trim(Err_Cd) <> "" Then
        '���b�Z�[�W�o��
        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    End If

    F_Chk_HD_SOUBSCD = Retn_Code

End Function
    


   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Change
    '   �T�v�F  �Ώۍ��ڂ�CHANGE�̐���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Item_Change(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Wk_CurMoji          As String
    Dim Wk_Cnt              As Integer
    Dim Wk_EditMoji         As String
    Dim Wk_DspMoji          As String
    Dim Move_Flg            As Boolean
    
    Select Case True
        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox
        '÷���ޯ���̏ꍇ
            '���݂�÷�ď�̑I����Ԃ��擾
            Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
            
            '���݂̒l���擾
            Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
            
            Wk_EditMoji = ""
            
            Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                Case IN_TYP_NUM
                '���l���ڂ̏ꍇ
                    Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                Case IN_TYP_DATE
                '���t���ڂ̏ꍇ
                    Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                Case IN_TYP_CODE, IN_TYP_STR
                '�R�[�h�A��������
                    Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
                    '�ύX��̒l�ϊ�
                    Case IN_STR_TYP_N
                        '�S�p�̏ꍇ
                            '���p�󔒁ˑS�p��
                            For Wk_Cnt = 1 To Len(Wk_CurMoji)
                                If Mid(Wk_CurMoji, Wk_Cnt, 1) = Space(1) Then
                                    Wk_EditMoji = Wk_EditMoji & "�@"
                                Else
                                    Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
                                End If
                            Next
                            
                    Case Else
                        '�S�p�ȊO
                            '���p�󔒁ˑS�p��
                            For Wk_Cnt = 1 To Len(Wk_CurMoji)
                                If Mid(Wk_CurMoji, Wk_Cnt, 1) = "�@" Then
                                    Wk_EditMoji = Wk_EditMoji & Space(2)
                                Else
                                    Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
                                End If
                            Next
                
                    End Select
                Case IN_TYP_YYYYMM
                '�N�����ڂ̏ꍇ
                    Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                
                Case IN_TYP_HHMM
                '�������ڂ̏ꍇ
                    Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                
                Case Else
            End Select
            
            '�ҏW��̕�����\���`���ɕϊ�
            Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
        
            '�I�𕶎��Ɠ��͕����̒u������
            '�����ݒ�
            Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
            
            '����̫����ʒu����E�ֈړ�
            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, pm_All, True)
        
        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox
    
        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton
    
        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox
    
    End Select

    '���͌㏈��
    Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
    
    '���ד��͌�̌㏈��
    Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)

End Function

   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Ctl_Item_GotFocus
    '   �T�v�F  �Ώۍ��ڂ�GOTFOCUS�̐���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Item_GotFocus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Move_Flg As Boolean
    
    If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = False Then
    '̫������󂯎��Ȃ��ꍇ
        '���̍��ڂ�̫����ړ�
        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
    Else
        
        '�ړ��O�ƈقȂ�ꍇ�̂ݑޔ�
        If pm_All.Dsp_Base.Cursor_Idx <> CInt(pm_Dsp_Sub_Inf.Ctl.Tag) Then
            '�O̫����̲��ޯ����ޔ�
            pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
            '�ړ���̲��ޯ����ޔ�
            pm_All.Dsp_Base.Cursor_Idx = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)
        End If
        
        '�I����Ԃ̐ݒ�i�����I���j
        Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
        '���ڐF�ݒ�
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
    End If

End Function

   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KeyPress
    '   �T�v�F  �Ώۍ��ڂ�KEYPRESS�̐���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Item_KeyPress(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                                   , ByRef pm_KeyAscii As Integer _
                                   , ByRef pm_Move_Flg As Boolean _
                                   , pm_All As Cls_All _
                                   , pm_Run_Flg As Boolean) As Integer
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim All_Sel_Flg         As Boolean
    Dim wk_Moji             As String
    Dim Wk_SelMoji          As String
    Dim Wk_BefMoji          As String
    Dim Wk_DelMoji          As String
    Dim Wk_EditMoji         As String
    Dim Wk_DspMoji          As String
    Dim Wk_Cnt              As Integer
    Dim Wk_SelStart         As Integer
    Dim Wk_SelLength        As Integer
    Dim Wk_CurMoji          As String
    Dim Input_Flg           As Boolean
    Dim Re_Body_Crt         As Boolean
    
    '�ړ��t���O������
    pm_Move_Flg = False
    
    '���̓t���O������
    Input_Flg = False
    '���ו��č쐬�t���O������
    Re_Body_Crt = False
    
    '�ȉ��̓��͂̏ꍇ�A��������
    Select Case pm_KeyAscii
        Case 1 To 7, 9 To 12, 14 To 29, 127
            Beep
            pm_KeyAscii = 0
            Exit Function
    End Select
    
    '���͕����擾
    wk_Moji = Chr$(pm_KeyAscii)
    
    '÷���ޯ���̂ݑΏ�
    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Then
        
        '���݂�÷�ď�̑I����Ԃ��擾
        Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
        
        '���݂̒l���擾
        Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
        
        All_Sel_Flg = False
        If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
        '�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
            All_Sel_Flg = True
            If Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB _
            And pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB = 1 Then
                All_Sel_Flg = False
            End If
        End If
        
        '���̓R�[�h����
        If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
        '���͉\�����̏ꍇ
            
           '���͉\�ȕ����̏ꍇ�A���͌㏈���A���ו��č쐬���s��
            Input_Flg = True
            Re_Body_Crt = True
            
            'CF_Jge_Input_Str�֐��̕����ύX���l��
            pm_KeyAscii = Asc(wk_Moji)
            
            '���t/�N��/�����ł��I����Ԃ��P�ȊO�̏ꍇ�A���͕s��
            '�\���`�������܂��Ă��邽�߈�����͂�����
            Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                    If Act_SelLength <> 1 Then
                        Beep
                        pm_KeyAscii = 0
                        Exit Function
                    End If
            End Select
            
            If All_Sel_Flg = True Then
            '�S�I����
                
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
                                      
                Else
                    '�l���������l�ȊO�̏ꍇ
                    Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                
                End If
                
                '�ҏW��̕�����\���`���ɕϊ�
                Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                
                '�ҏW���SelStart������
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '�E�[�ֈړ�
                    Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                    Wk_SelLength = 0
                Else
                    '�l���������l�ȊO�̏ꍇ
                    Wk_SelStart = 0
                    Wk_SelLength = 1
                End If
                
                '�폜��̕����u������
                '�����ݒ�
                Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                pm_KeyAscii = 0
    
                '�ҏW���SelStart������
                pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                '�ҏW���SelLength������
                pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                
            Else
            '�����I���������́A�I���Ȃ�
                
                If Act_SelLength = 0 Then
                '�I���Ȃ��̏ꍇ(�}�����)
                    '�}�������̑O�̕������擾
                    Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
                    '���l���ړ��ʏ���
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        Select Case wk_Moji
                            Case "+"
                                '��{����͎�
                                If Trim(Wk_BefMoji) <> "" Then
                                '�O��������L�̕����ȊO�͑}���ł��Ȃ�
                                    '���͕s��
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                                
                            Case "-"
                                '��|����͎�
                                If Trim(Wk_BefMoji) <> "" Then
                                '�O��������L�̕����ȊO�͑}���ł��Ȃ�
                                    '���͕s��
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                    
                            Case "."
                                '��D����͎�
                                If InStr(Wk_CurMoji, ".") > 1 Then
                                '���łɢ�D������͂��ꂢ��ꍇ
                                    '���͕s��
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                        End Select
                    End If

                    If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                    '�󔒏�����̌��݂̕�����MAX�̏ꍇ�A�I�[�o�[�t���[

                        '���l���ړ��ʏ���
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            '��ԉE�ŃI�[�o�[�t���[�����ꍇ�A���̍��ڂ�
                            If Act_SelStart >= Len(Wk_CurMoji) Then
                            '�ҏW�O�̊J�n�ʒu����ԉE�̏ꍇ
                                '����̫����ʒu����E�ֈړ�
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            Else
                                '���͕s��
                                Beep
                            End If
                        Else
                            
                            '�ҏW��̈ړ���𔻒�
                            If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                                '�l���������l�̏ꍇ
                            Else
                            '�ҏW���SelStart������
                                If Act_SelStart + 1 > Len(Wk_CurMoji) Then
                                '�P�E�̈ʒu���E�[�̏ꍇ
                                    Wk_SelStart = Len(Wk_CurMoji)
                                Else
                                '�P�E��
                                    Wk_SelStart = Act_SelStart + 1
                                End If
                                '�ҏW���SelLength������
                                Wk_SelLength = 0
                                
                                '�ҏW���SelStart������
                                pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                '�ҏW���SelLength������
                                pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            End If
                            
                            '���͕s��
                            Beep
                        End If

                        '���͕s��
                        pm_KeyAscii = 0
                        Exit Function
                    End If
                
                    '�����ҏW
                    Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                                 & Chr$(pm_KeyAscii) _
                                 & Mid$(Wk_CurMoji, Act_SelStart + 1)
                
                    '�ҏW��̕�����\���`���ɕϊ�
                    Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                    
                    '���l���ړ��ʏ���
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        '�������Ő���������葽�����͂���Ă���ꍇ
                        If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
                            '���͕s��
                            pm_KeyAscii = 0
                            Exit Function
                        End If
                        
                        '�����������菬�������Ɛݒ�l�������ꍇ
                        If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 _
                        And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                            '����̫����ʒu����E�ֈړ�
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            '���͕s��
                            pm_KeyAscii = 0
                            Exit Function
                        End If
                    End If
                    
                    '�ҏW���SelStart������
                    If Act_SelStart + 1 > Len(Wk_DspMoji) Then
                    '�P�E�̈ʒu���E�[�̏ꍇ
                        Wk_SelStart = Len(Wk_DspMoji)
                    Else
                    '�P�E��
                        Wk_SelStart = Act_SelStart + 1
                    End If
                    '�ҏW���SelLength������
                    Wk_SelLength = 0
                    
                    '�폜��̕����u������
                    '�����ݒ�
                    Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                    pm_KeyAscii = 0
        
                    '�ҏW���SelStart������
                    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    '�ҏW���SelLength������
                    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    
                    '�ҏW��̈ړ���𔻒�
                    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                        '�l���������l�̏ꍇ
                        
                        If Wk_SelStart >= Len(Wk_DspMoji) Then
                        '�ҏW��̊J�n�ʒu����ԉE�̏ꍇ
                            '���l���ړ��ʏ���
                            If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                                '�����������菬�������Ɛݒ�l�������ꍇ
                                If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 _
                                And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                                    '����̫����ʒu����E�ֈړ�
                                    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                Else
                                    If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                    '�ҏW��̕�����MAX�̏ꍇ
                                        '����̫����ʒu����E�ֈړ�
                                        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                    End If
                                End If
                            Else
                            '���l���ڈȊO
                                If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '�ҏW��̕�����MAX�̏ꍇ
                                    '����̫����ʒu����E�ֈړ�
                                    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                End If
                            End If
                        End If
                    Else
                        '�l���������l�ȊO�̏ꍇ
                        If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                        '�ҏW��̕�����MAX�̏ꍇ
                            
                            '�ҏW���SelStart������
                            pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            '�ҏW���SelLength������
                            pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                            
                            '����̫����ʒu����E�ֈړ�
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                        End If
                    End If
                Else
                '�ꕔ�I��
                    '���ݑI������Ă��镶���̂P�����擾
                     Wk_SelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
                
                    If Trim(Wk_SelMoji) <> "" And CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_SelMoji) <> 1 Then
                    '�I�𕶎����󕶎��ȊO�ł����͑Ώۂ̕����ȊO�̏ꍇ
                        
                        '���͕s��
                        Beep
                        pm_KeyAscii = 0
                        Exit Function
                    End If
                    
                    '���l���ړ��ʏ���
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        Select Case wk_Moji
                            Case "+"
                                '��{����͎�
                                If Wk_SelMoji <> "-" _
                                And Wk_SelMoji <> "." _
                                And Wk_SelMoji <> "%" _
                                And Trim(Wk_SelMoji) <> "" Then
                                '�I�𕶎�����L�̕����ȊO�͒u���������Ȃ�
                                    '���͕s��
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                                
                            Case "-"
                                '��|����͎�
                                If Wk_SelMoji <> "+" _
                                And Wk_SelMoji <> "." _
                                And Wk_SelMoji <> "%" _
                                And Trim(Wk_SelMoji) <> "" Then
                                '�I�𕶎�����L�̕����ȊO�͒u���������Ȃ�
                                    '���͕s��
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                    
                            Case "."
                                '��D����͎�
                                If InStr(Wk_CurMoji, ".") > 0 Then
                                '���łɢ�D������͂��ꂢ��ꍇ
                                    '���͕s��
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                        End Select
                    End If
                     
                    '�����ҏW
                    Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                                 & Chr$(pm_KeyAscii) _
                                 & Mid$(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
                    
                    '�ҏW��̕�����\���`���ɕϊ�
                    Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                    
                    '���l���ړ��ʏ���
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        '�����������̏ꍇ
                        '����������Ő���������葽�����͂���Ă���ꍇ
                        If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
                            '���͕s��
                            pm_KeyAscii = 0
                            Exit Function
                        End If
                        
                        '�����������菬�������Ɛݒ�l�������ꍇ
                        If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 _
                        And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                            '����̫����ʒu����E�ֈړ�
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            '���͕s��
                            pm_KeyAscii = 0
                            Exit Function
                        End If
                    End If
                    
                    If Act_SelStart >= Len(Wk_DspMoji) - 1 Then
                    '�ҏW�O�̊J�n�ʒu���Ō�̕����ȍ~�̏ꍇ
                        '�ҏW���SelStart������
                        Wk_SelStart = Len(Wk_DspMoji)
                        '�ҏW���SelLength������
                        Wk_SelLength = 0
                    Else
                        '�ҏW���SelStart������
                        Wk_SelStart = Act_SelStart
                        '�ҏW���SelLength������
                        Wk_SelLength = 1
                    End If
                    
                    '���l���ړ��ʏ���
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        If Len(CF_Get_Input_Ok_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) = 1 Then
                        '���͉\�ȕ������P���̏ꍇ
                            '�J�n�ʒu����ԉE�ɐݒ�
                            '�ҏW���SelStart������
                            Wk_SelStart = Len(Wk_DspMoji)
                            '�ҏW���SelLength������
                            Wk_SelLength = 0
                        End If
                    
                    End If
                    
                    '�ҏW��̕����u������
                    '�����ݒ�
                    Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                    pm_KeyAscii = 0
        
                    '�ҏW���SelStart������
                    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    '�ҏW���SelLength������
                    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    
                    '�ҏW��̈ړ���𔻒�
                    If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
                    '�ҏW��̊J�n�ʒu���Ō�̕����ȍ~�̏ꍇ
                        '���l���ړ��ʏ���
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        
                            '�����������菬�������Ɛݒ�l�������ꍇ
                            If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 _
                            And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                                '����̫����ʒu����E�ֈړ�
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            Else
                                If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '�ҏW��̕�����MAX�̏ꍇ
                                    '����̫����ʒu����E�ֈړ�
                                    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                End If
                            End If
                        
                        Else
                        '���l���ڈȊO
                            If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                            '�ҏW��̕�����MAX�̏ꍇ
                                '����̫����ʒu����E�ֈړ�
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            End If
                        End If
                    Else
                        '����̫����ʒu����E�ֈړ�
                        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                    End If
                
                End If
            End If
        
        Else
        '���̓R�[�h�ȊO
            Select Case pm_KeyAscii
                Case vbKeyBack
                    'BackSpace�L�[
                    pm_KeyAscii = 0
                    Input_Flg = True
                    
                    '���t/�N��/�����̏ꍇ
                    Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                        Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                            '�폜���SelStart������
                            Wk_SelStart = Act_SelStart
                            For Wk_Cnt = Act_SelStart - 1 To 0 Step -1
                                '�팻�݂̊J�n�ʒu���獶�ֈړ������������͑Ώۂ��𔻒�
                                If CF_Jge_Input_Str(pm_Dsp_Sub_Inf _
                                               , Mid(Wk_CurMoji, Wk_Cnt + 1, 1)) = 1 Then
                                    '���͕����łȂ��ꍇ
                                    Wk_SelStart = Wk_Cnt
                                    Exit For
                                End If
                            
                            Next
                            '�ҏW���SelLength������
                            Wk_SelLength = Act_SelLength
                            
                            '�ҏW���SelStart������
                            pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                            '�ҏW���SelLength������
                            pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            
                            '�폜�s��
                            Exit Function
                        Case Else
                        
                    End Select
                    
                    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                        '�J�n�ʒu�����̏ꍇ�A�I��
                        If Act_SelStart = 0 Then
                            '�폜�s��
                            Exit Function
                        End If
                        
                        '�폜�Ώۂ̕����P�����擾
                         Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
                        
                        '���l���ړ��ʏ���
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            If Wk_DelMoji = "." Then
                            '�폜�Ώۂ̕����������_�̏ꍇ
                                If Len(CF_Get_Num_Int_Part(Wk_CurMoji)) _
                                + Len(CF_Get_Num_Fra_Part(Wk_CurMoji)) _
                                > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
                                '�폜��̌����I�[�o�[�̏ꍇ
                                    '�폜�s��
                                    Exit Function
                                End If
                            End If
                        End If
                    
                        '�폜�����̔���
                        If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
                        '�폜���������͑Ώۂ̕����̏ꍇ
                            If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
                            '�����ҏW
                                Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) _
                                            & Left(Wk_CurMoji, Act_SelStart - 1) _
                                            & Mid(Wk_CurMoji, Act_SelStart + 1)
                            Else
                            '�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
                                Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                            End If
                        Else
                        '�폜���������͑Ώۂ̕����̈ȊO�ꍇ
                            '���̂܂�
                            Wk_EditMoji = Wk_CurMoji
                        End If
                    
                        '�폜��̕�����\���`���ɕϊ�
                        Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                        
                        '�폜���SelStart������
                        Wk_SelStart = Act_SelStart
                        For Wk_Cnt = Act_SelStart To Len(Wk_CurMoji) - 1
                            '�폜��Ɍ��݂̊J�n�ʒu����̕��������͑Ώۂ��𔻒�
                            If CF_Jge_Input_Str(pm_Dsp_Sub_Inf _
                                           , Mid(Wk_DspMoji, Wk_Cnt + 1, 1)) = 1 Then
                                Exit For
                            End If
                            '���͕����łȂ��ꍇ�A�E�ֈړ�
                            Wk_SelStart = Wk_SelStart + 1
                        Next
                        '�ҏW���SelLength������
                        Wk_SelLength = Act_SelLength
                        
                        '���l���ړ��ʏ���
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            '���l���ڂŖ����͂̏ꍇ�́A��ԉE���J�n�ʒu�ɐݒ�
                            If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
                                Wk_SelStart = Len(Wk_DspMoji)
                                '�ҏW���SelLength������
                                Wk_SelLength = 0
                            End If
                        End If
                    Else
                    '�l���������l�ȊO�̏ꍇ
                        If Act_SelStart = 0 Then
                        '�J�n�ʒu����ԍ��̏ꍇ
                            If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
                                '�����ҏW
                                Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) _
                                            & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                            Else
                                '�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
                                Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                            End If
                        
                            '�폜���SelStart������
                            Wk_SelStart = Act_SelStart
                        Else
                            '�����ҏW
                            Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart - 1) _
                                        & Mid(Wk_CurMoji, Act_SelStart + 1) _
                                        & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                        
                            '�폜���SelStart������
                            Wk_SelStart = Act_SelStart - 1
                        End If
                        '�ҏW���SelLength������
                        Wk_SelLength = Act_SelLength
                    
                        '�ҏW��̕�����\���`���ɕϊ�
                        Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                    End If
            
                    '�폜��̕����u������
                    '�����ݒ�
                    Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
            
                    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                
                Case Else
                    pm_KeyAscii = 0
            
            End Select
        End If
    End If

    If Input_Flg = True Then
        '���͌㏈��
        Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
    End If

    If Re_Body_Crt = True Then
        '���ד��͌�̌㏈��
        Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Ctl_Item_MouseDown
    '   �T�v�F  �Ώۍ��ڂ�MOUSEDOWN�̐���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Item_MouseDown(pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All, pm_Button As Integer, pm_Shift As Integer, pm_X As Single, pm_Y As Single) As Integer
    Dim Wk_Index    As Integer
    Dim bolSameCtl  As Boolean

    If pm_Button = vbRightButton Then
    '�E�N���b�N
        
        bolSameCtl = False
        If CInt(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CInt(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
        '�E�N���b�N�����R���g���[�����A�N�e�B�u�ȃR���g���[���ƈ�v
            '�J�[�\������p�e�L�X�g�Ƀt�H�[�J�X���ꎞ�I�ɑޔ�
            Wk_Index = CInt(FR_SSSMAIN.TX_CursorRest.Tag)
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
            bolSameCtl = True
        End If
        
        '����ړ��e�R�s�[�����
        FR_SSSMAIN.SM_AllCopy = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
        
        '����ړ��e�ɓ\��t�������
        FR_SSSMAIN.SM_FullPast = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
        
        '�ΏۃR���g���[���̎g�p�s��
        pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
        
        '��߯�߱����ƭ������
        If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
            '۽�̫�������Ă̗}��
            pm_All.Dsp_Base.LostFocus_Flg = True
            '�߯�߱����ƭ��\��
            FR_SSSMAIN.PopupMenu FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton
            '۽�̫�������Ă̗}������
            pm_All.Dsp_Base.LostFocus_Flg = False
            DoEvents
        End If
    
        '�߯�߱����ƭ��\����Ԃŉ�ʂ̏I�������ɓ����Ă��܂����ꍇ�́A
        '�ȍ~�̏����͍s��Ȃ��B
        If pm_All.Dsp_Base.IsUnload = True Then
            Exit Function
        End If
        
        '�ΏۃR���g���[���̎g�p��
        pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
        '�t�H�[�J�X���ړ������ɖ߂�
        If bolSameCtl = True Then
            Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
        End If
    
    End If

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Ctl_VS_Scrl_Change
    '   �T�v�F  VS_Scrl��CHANGE�̐���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_VS_Scrl_Change(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Cur_Top_Index           As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    Dim Move_Flg                As Boolean
    Dim Row_Move_Value          As Integer
    Dim Cur_Row                 As Integer
    Dim Next_Row                As Integer
    Dim Next_Index              As Integer
    
    '�ŏ㖾�ײ��ޯ����ޔ�
    Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index

    '��ʂ̓��e��ޔ�
    Call CF_Body_Bkup(pm_All)
    '�c�X�N���[���o�[�̒l���ŏ㖾�ײ��ޯ���ɐݒ�
    pm_All.Dsp_Body_Inf.Cur_Top_Index = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
    
    '��ʃ{�f�B���̔z����Đݒ�
    Call CF_Dell_Refresh_Body_Inf(pm_All)
    
    '��ʕ\��
    Call CF_Body_Dsp(pm_All)

    '��è�޺��۰ق����ו��̂ݐ���
    If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
    And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
        
        '���݂̍s���擾
        Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
        '̫�������
        '�ړ���
        Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
        
        '�ړ���̍s
        Next_Row = Cur_Row + Row_Move_Value
        If Next_Row <= 0 Then
            Next_Row = 1
        End If
        If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
            Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
        End If
        
        '�ړ���̍s�̂̓��ꍀ�ڂ̲��ޯ�����擾
        Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
         If Next_Index > 0 Then
            If Next_Index = CInt(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
            '������۰ق̏ꍇ
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
                '���ڐF�ݒ�
                Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
            Else
            '������۰قłȂ��ꍇ
                '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            End If
        Else
            '���͉\�ȍŏ��̃C���f�b�N�X���擾
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
            If Focus_Ctl_Ok_Fst_Idx > 0 Then
                '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            Else
                
                If Row_Move_Value > 0 Then
                '��ֈړ�
                    '�w�b�_���̍Ō�̍��ڂ̂P��납��
                    '�P�O�̍��ڂ�
                    Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
                Else
                '���ֈړ�
                    '�t�b�^���̍ŏ��̍��ڂ̂P�O����
                    'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                End If
            End If
        End If
    End If
    
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Ctl_Dsp_Body_Page
    '   �T�v�F  ���ו����̃y�[�W����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Dsp_Body_Page(pm_Page_Value As Integer, pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Cur_Top_Index           As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    Dim Move_Flg                As Boolean
    Dim Row_Move_Value          As Integer
    Dim Cur_Row                 As Integer
    Dim Next_Row                As Integer
    Dim Next_Index              As Integer
    
    '�ŏ㖾�ײ��ޯ����ޔ�
    Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index

    '��ʂ̓��e��ޔ�
    Call CF_Body_Bkup(pm_All)
    '�ŏ㖾�ײ��ޯ���ɐݒ�
    '�i��ʕ\�����א��|�P�j�~�i�y�[�W���|�P�j�{�P�@�@�˂P�A�U�A�P�P�A�P�U�ƂȂ�
    pm_All.Dsp_Body_Inf.Cur_Top_Index = (pm_All.Dsp_Base.Dsp_Body_Cnt - 1) _
                                      * (pm_Page_Value - 1) _
                                      + 1
    '��ʕ\��
    Call CF_Body_Dsp(pm_All)

    '��è�޺��۰ق����ו��̂ݐ���
    If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
    And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
        
        '���݂̍s���擾
        Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
        '̫�������
        '�ړ���
        Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
        
        '�ړ���̍s
        Next_Row = Cur_Row + Row_Move_Value
        If Next_Row <= 0 Then
            Next_Row = 1
        End If
        If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
            Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
        End If
        
        '�ړ���̍s�̂̓��ꍀ�ڂ̲��ޯ�����擾
        Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
         If Next_Index > 0 Then
            If Next_Index = CInt(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
            '������۰ق̏ꍇ
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
                '���ڐF�ݒ�
                Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
            Else
            '������۰قłȂ��ꍇ
                '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            End If
        Else
            '���͉\�ȍŏ��̃C���f�b�N�X���擾
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
            If Focus_Ctl_Ok_Fst_Idx > 0 Then
                '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            Else
                
                If Row_Move_Value > 0 Then
                '��ֈړ�
                    '�w�b�_���̍Ō�̍��ڂ̂P��납��
                    '�P�O�̍��ڂ�
                    Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
                Else
                '���ֈړ�
                    '�t�b�^���̍ŏ��̍��ڂ̂P�O����
                    'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                End If
            End If
        End If
    End If
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Ctl_MN_Cmn_DE_Focus
    '   �T�v�F  ���j���[�̖��׏������^���׍폜�^���ו������̃t�H�[�J�X����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Row As Integer, pm_All As Cls_All) As Boolean

    Dim Trg_Index               As Integer
    Dim Move_Flg                As Boolean
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    
    '��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
    Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
    
     If Trg_Index > 0 Then
        If Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) Then
        '�ړ��悪�����ꍇ
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '���ڐF�ݒ�
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
        
        Else
            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
        End If
    
    Else
        '���͉\�ȍŏ��̃C���f�b�N�X���擾
        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
        If Focus_Ctl_Ok_Fst_Idx > 0 Then
            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
        End If
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Ctl_MN_Paste
    '   �T�v�F  �\��t��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_MN_Paste(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Clip_Value As String
    Dim Paste_Value As String
    
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Wk_SelStart         As Integer
    Dim Wk_SelLength        As Integer
    Dim Wk_EditMoji         As String
    Dim Wk_CurMoji          As String
    Dim Wk_DspMoji          As String
    
    '�د���ް�ނ�����e�擾
    Clip_Value = Clipboard.GetText()
    '���͕����\�����o��
    Paste_Value = CF_Get_Input_Ok_Item(Clip_Value, pm_Dsp_Sub_Inf)
    
    '�\��t�����e���Ȃ��ꍇ�A�������f
    If Paste_Value = "" Then
        Exit Function
    End If
    
    '���݂�÷�ď�̑I����Ԃ��擾
    Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
    Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
    Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
    Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
    '���݂̒l���擾
    Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
    
    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
    '�l���������l�̏ꍇ
        
        '�����ҏW
        Wk_EditMoji = CF_Cnv_Dsp_Item(Paste_Value, pm_Dsp_Sub_Inf, False)
        
        '�ҏW���SelStart������
        '�E�[�ֈړ�
        Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
        Wk_SelLength = 0
    Else
    '�l���������l�ȊO�̏ꍇ
    
        If Act_SelLength = 0 Then
        '�I���Ȃ��̏ꍇ(�}�����)
            '�����ҏW
            Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                         & Paste_Value _
                         & Mid$(Wk_CurMoji, Act_SelStart + 1)
        Else
        '�ꕔ�I��
            If Act_SelLength >= 2 Then
            '�Q�����ȏ�I�����Ă���ꍇ��
            '�I�𕶎������̕���������
                '�����ҏW
                Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                             & Paste_Value _
                             & Mid$(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
            Else
            '�P�����ȉ��I�����Ă���ꍇ��
            '�I�𕶎��ȍ~�͓��ꊷ��
                '�����ҏW
                Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                             & Paste_Value
            
            End If
        
        End If
    
        '�ҏW���SelStart������
        '���[�ֈړ�
        Wk_SelStart = 0
        Wk_SelLength = 1
    
    End If
    
    Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
        Case IN_TYP_DATE
        '���t�̏ꍇ�A���͌`�������܂��Ă���ꍇ
            '���t���͌`���̌��������擾
            Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_DATE))
        Case IN_TYP_YYYYMM
        '�N���̏ꍇ�A���͌`�������܂��Ă���ꍇ
            '���t���͌`���̌��������擾
            Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_YYYMM))
        Case IN_TYP_HHMM
        '�����̏ꍇ�A���͌`�������܂��Ă���ꍇ
            '���t���͌`���̌��������擾
            Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_HHMM))
        Case Else
    
    End Select
    
    '�ҏW��̕�����\���`���ɕϊ�
    Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
    
    '��ݼ޲���Ă��N�������ɕҏW
    Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
    
    '�ҏW���SelStart������
    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
    '�ҏW���SelLength������
    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
    
    '���͌�̌㏈��
    Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)

    '���ד��͌�̌㏈��
    Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Init_Dsp_Body
    '   �T�v�F  �w�肳�ꂽ���ׂ̏����l��ݒ肷��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Init_Dsp_Body(pm_Bd_Index As Integer, pm_All As Cls_All) As Integer
    Dim Wk_Index As Integer

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_Item_Input_Aft
    '   �T�v�F  ��ʂō��ړ��͂��ꂽ�ꍇ�̌㏈�����s���܂�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Boolean
    
    Dim Row_Inf_Max_S       As Integer
    Dim Row_Inf_Max_E       As Integer
    Dim Bd_Index            As Integer
    
    '���ׂ̍č쐬���s��
     Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)

End Function
        
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Set_Befe_Focus
    '   �T�v�F  �O�̃t�H�[�J�X�ʒu�ݒ�(LEFT�Ȃ�)
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Befe_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, Optional pm_Run_Flg As Boolean = True) As Integer
    Dim Trg_Index               As Integer
    Dim Index_Wk                As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    Dim Cur_Top_Index           As Integer
    Dim Focus_Ctl_Ok_Lst_Idx    As Integer

    '�ړ��t���O������
    pm_Move_Flg = False

    '�������ޯ���擾
    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)

    '���̍��ڂ�����
    For Index_Wk = Trg_Index - 1 To 1 Step -1

        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL _
        And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
        '�t�b�^������{�f�B���ֈړ�����ꍇ
            '���͉\�ȍŏ��̃C���f�b�N�X���擾
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
            If Focus_Ctl_Ok_Fst_Idx > 0 Then
                Index_Wk = Focus_Ctl_Ok_Fst_Idx
            End If

        End If

        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
        And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
        '�{�f�B������w�b�_���ֈړ�����ꍇ
            If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
            '���ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ

                '��ʂ̓��e��ޔ�
                Call CF_Body_Bkup(pm_All)
                '�ړ��\�s����ԏ�ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
                pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                    '�c�X�N���[���o�[��ݒ�
                    Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                End If
                '��ʃ{�f�B���̔z����Đݒ�
                Call CF_Dell_Refresh_Body_Inf(pm_All)
                '��ʕ\��
                Call CF_Body_Dsp(pm_All)

                '���͉\�ȍŌ�̃C���f�b�N�X���擾
                Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
                If Focus_Ctl_Ok_Lst_Idx > 0 Then
                    Index_Wk = Focus_Ctl_Ok_Lst_Idx
                End If

            End If
        End If

        '̫����ړ���OK
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
            If pm_Run_Flg = True Then
                '���s�w�肪����ꍇ(��{����)
                '̫����ړ�
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
            End If
            '�ړ��t���O����
            pm_Move_Flg = True
            Exit For
        End If
    Next

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Set_Next_Focus
    '   �T�v�F  ���̃t�H�[�J�X�ʒu�ݒ�(ENT�ARIGHT�Ȃ�)
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, Optional pm_Run_Flg As Boolean = True) As Integer
    Dim Sta_Index           As Integer
    Dim Index_Wk            As Integer
    Dim Rtn_Chk             As Integer
    Dim Bd_Index            As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    Dim Focus_Ctl_Ok_Lst_Idx    As Integer
    Dim Focus_Ctl_Ok_Fst_Idx_Wk As Integer
    Dim Cur_Top_Index       As Integer
    Dim intRet              As Integer

    '�ړ��t���O������
    pm_Move_Flg = False

    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CInt(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
    '�{�f�B��
        'Dsp_Body_Inf�̍s�m�n���擾
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
        '�ŏI�����s�̏ꍇ
            '���͉\�ȍŏ��̃C���f�b�N�X���擾
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)

            If CInt(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
            '���͉\�ȍŏ��̍��ڂ̏ꍇ
                '���[�h�ɂ�茟���J�n�ʒu������
                Select Case pm_Mode
                    Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
                    'KEYRETURN�AKEYDOWN�̏ꍇ
                        '�����J�n�̓t�b�^���̍ŏ��̍��ڂ���
                        Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx

                    Case NEXT_FOCUS_MODE_KEYRIGHT
                    'KEYRIGHT�̏ꍇ
                        '�������ޯ���擾
                        '�����J�n�͑Ώۂ̍��ڂ̎�
                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1

                End Select
            Else
                '�����J�n�͑Ώۂ̍��ڂ̎�
                Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
            End If

        Else
        '�ŏI�����s�ȊO�̏ꍇ
            If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
            '�\������Ă���ŏI�s�̏ꍇ
                '���͉\�ȍŌ�̃C���f�b�N�X���擾
                Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)

                If CInt(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
                '���͉\�ȍŌ�̍��ڂ̏ꍇ
                    If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
                    '�ŏI�����s�ȊO����ʏ�̍ŏI�s���ŏI����
                    '����ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ

                        '��ʂ̓��e��ޔ�
                        Call CF_Body_Bkup(pm_All)
                        '�ړ��\�s����ԉ��ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
                        pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                            '�c�X�N���[���o�[��ݒ�
                            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                        End If
                        '��ʃ{�f�B���̔z����Đݒ�
                        Call CF_Dell_Refresh_Body_Inf(pm_All)
                        '��ʕ\��
                        Call CF_Body_Dsp(pm_All)

                        '���ׂP�ԉ��s�̓��͉\�ȍŏ��̃C���f�b�N�X���擾
                        Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
                        If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
                            '���ׂP�ԉ��s�̍ŏ��̍��ڂ̈�O���猟��
                            Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
                        Else
                            '�����J�n�͑Ώۂ̍��ڂ̎�
                            Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
                        End If

                     Else
                    '����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
                        '�����J�n�͑Ώۂ̍��ڂ̎�
                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
                     End If
                Else
                '���͉\�ȍŌ�̍��ڈȊO�̏ꍇ
                    '�����J�n�͑Ώۂ̍��ڂ̎�
                    Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
                End If

            Else
            '�ŏI�s�ȊO�ꍇ
                '�����J�n�͑Ώۂ̍��ڂ̎�
                Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
            End If
        End If

    Else
    '�{�f�B���ȊO
        '�����J�n�͑Ώۂ̍��ڂ̎�
        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
    End If

    '���̍��ڂ�����
    For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt

        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD _
        And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
        '�w�b�_������{�f�B���ֈړ�����ꍇ
'�r���������������������������������������������������������r
            'ͯ�ޕ�����
            If gv_bolInit = False Then
                Rtn_Chk = F_Ctl_Head_Chk(pm_All)
            Else
                Rtn_Chk = CHK_OK
            End If
'�d���������������������������������������������������������d
            If Rtn_Chk <> CHK_OK Then
            '�`�F�b�N�m�f�̏ꍇ
                '�L�[�t���O�����ɖ߂�
                gv_bolKeyFlg = False
                Exit For
            End If
        End If

        '̫����ړ���OK
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
            If pm_Run_Flg = True Then
            '���s�w�肪����ꍇ(��{����)
                '̫����ړ�
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
            End If
            '�ړ��t���O����
            pm_Move_Flg = True
            Exit For
        End If

    Next

    '�ŏI���ڂ܂Ō����I����
    If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
        '���[�h�ɂ�茟���I����̏���������
        Select Case pm_Mode
            Case NEXT_FOCUS_MODE_KEYRETURN
            'KEYRETURN�̏ꍇ
'�r���������������������������������������������������������r
            Call PrintTNAPR82_Main(pm_All, -1)
            '�L�[�t���O�����ɖ߂�
            gv_bolKeyFlg = False
On Error Resume Next
            FR_SSSMAIN.HD_TEISYOYM.SetFocus
'�d���������������������������������������������������������d
                pm_Move_Flg = True
            Case NEXT_FOCUS_MODE_KEYRIGHT
            'KEYRIGHT�̏ꍇ
                '�����J�n���ڂőI����Ԃ��ړ�����
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_1)
            Case NEXT_FOCUS_MODE_KEYDOWN
            'KEYDOWN�̏ꍇ

        End Select
    End If
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Set_Left_Next_Focus
    '   �T�v�F  Left�������̃t�H�[�J�X�ʒu�ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, Optional pm_Run_Flg As Boolean = True) As Integer
    Dim Index_Wk            As Integer
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Str_Wk              As String
    Dim Wk_Point            As Integer
    Dim Wk_SelStart         As Integer
    Dim Wk_SelLength        As Integer

    '�ړ��t���O������
    pm_Move_Flg = False

    '���݂̺��۰ق�÷���ޯ���̏ꍇ
    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Then
        '���݂�÷�ď�̑I����Ԃ��擾
        Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

        If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
        '�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
            If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                '�l���������l�̏ꍇ
                '�P�����ڂ�I������
                pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                pm_Dsp_Sub_Inf.Ctl.SelLength = 1
            Else
                '�l���������l�ȊO�̏ꍇ
                '�P�O�̍��ڂ�
                Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)

            End If
        Else
            If Act_SelStart = 0 Then
            '�J�n�ʒu����ԍ��̏ꍇ
                '�P�O�̍��ڂ�
                Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
            Else

                '���ɂP�������炵���͉\�ȕ���������
                Wk_SelStart = -1
                For Wk_Point = Act_SelStart - 1 To 0 Step -1
                    Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
                    If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
                        Wk_SelStart = Wk_Point
                        Exit For
                    End If
                Next

                If Wk_SelStart = -1 Then
                '�I���\�ȕ������Ȃ��ꍇ
                    '�P�O�̍��ڂ�
                    Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                Else
                '�I���\�ȕ���������ꍇ
                    If Act_SelStart < Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) _
                    And Act_SelLength = 0 Then
                    '�ړ��O�̑I���J�n�ʒu����ԉE�ȊO�ł���
                    '�I�𕶎������Ȃ��ꍇ�̂݁A
                        '�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
                        Wk_SelLength = 0
                    Else
                        Wk_SelLength = 1
                    End If

                    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                End If

            End If
        End If
    Else
    '���݂̺��۰ق�÷���ޯ���̈ȊO�ꍇ
        '�P�O�̍��ڂ�
        Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Set_Right_Next_Focus
    '   �T�v�F  Right�������̃t�H�[�J�X�ʒu�ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, pm_Run_Flg As Boolean) As Integer
    Dim Index_Wk            As Integer
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Str_Wk              As String
    Dim Next_SelStart       As Integer
    Dim Wk_Point            As Integer
    Dim Wk_SelLength        As Integer

    '�ړ��t���O������
    pm_Move_Flg = False

    '���݂̺��۰ق�÷���ޯ���̏ꍇ
    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Then
        '���݂�÷�ď�̑I����Ԃ��擾
        Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

        If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
        '�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
            If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                '�l���������l�̏ꍇ
                '�ŏI������I������
                pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                pm_Dsp_Sub_Inf.Ctl.SelLength = 1
            Else
                '�l���������l�ȊO�̏ꍇ
                '�P���ڂ�I������
                pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                pm_Dsp_Sub_Inf.Ctl.SelLength = 1
            End If
        Else
            If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
            '�I���J�n�ʒu����ԉE�̏ꍇ
                'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
            Else
            '�I���J�n�ʒu����ԉE�łȂ��ꍇ

                '�P�E�̂P�����擾
                Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)

                If Str_Wk = "" Then
                    '���̂P�����Ȃ��ꍇ
                    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '��ԉE�ֈړ����I���Ȃ���Ԃ�
                        pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                        pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                    Else
                    '�l���������l�ȊO�̏ꍇ
                        If Act_SelLength = 0 Then
                        '�ړ��O�̑I�𕶎������Ȃ��ꍇ
                            '��ԉE�ֈړ����I���Ȃ���Ԃ�
                            pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                        Else
                            'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                        End If
                    End If
                Else

                    '�E�ɂP�������炵���͉\�ȕ���������
                    Next_SelStart = -1
                    For Wk_Point = Act_SelStart + 1 To Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Step 1

                        Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)

                        Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                            Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                            '���t/�N��/�������ڂ̏ꍇ
                                '���͉\�������Ƌ󔒂��ړ��\
                                If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 _
                                Or Str_Wk = Space(1) Then
                                    Next_SelStart = Wk_Point
                                    Exit For
                                End If
                            Case Else
                            '���t/�N��/�������ڈȊO�̏ꍇ
                                If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
                                    Next_SelStart = Wk_Point
                                    Exit For
                                End If
                            
                        End Select
                    Next

                    If Next_SelStart = -1 Then
                    '�I���\�ȕ������Ȃ��ꍇ
                        'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                    Else
                    '�I���\�ȕ���������ꍇ

                        If Act_SelLength = 0 Then
                        '�ړ��O�̑I�𕶎������Ȃ��ꍇ
                            '�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
                            Wk_SelLength = 0
                        Else
                            Wk_SelLength = 1
                        End If

                        pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                        pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    End If
                End If
            End If

        End If
    Else
    '���݂̺��۰ق�÷���ޯ���̈ȊO�ꍇ
        'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Set_Down_Next_Focus
    '   �T�v�F  Down�������̃t�H�[�J�X�ʒu�ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All) As Integer
    Dim Trg_Index   As Integer
    Dim Index_Wk    As Integer
    Dim Next_Index  As Integer
    Dim Wk_Cnt      As Integer
    Dim Cur_Top_Index As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer

    '�ړ��t���O������
    pm_Move_Flg = False

    '�������ޯ���擾
    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)

    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CInt(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
    '���ו��̏ꍇ
        Wk_Cnt = 0
        Do
            Wk_Cnt = Wk_Cnt + 1
            '���݂̍��ڂɗ񕪂������Ɉړ��������ޯ�������߂�
            Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)

            If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
            '���ڐ��𒴂����ꍇ
                'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                Exit Do
            End If

            If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD _
            And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.NAME = pm_Dsp_Sub_Inf.Ctl.NAME Then
            '�ړ��悪���ו��ł��ړ��O�Ɠ������۰ٖ��̏ꍇ
                If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
                '̫������n�j
                    '�����Ɉړ�
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
                    pm_Move_Flg = True
                    Exit Do
                End If
            Else
            '���̍��ږ������ו��łȂ��ꍇ
                If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
                '����ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
                    '��ʂ̓��e��ޔ�
                    Call CF_Body_Bkup(pm_All)
                    '�ړ��\�s����ԉ��ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
                    pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                    If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                        '�c�X�N���[���o�[��ݒ�
                        Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                    End If
                    '��ʕ\��
                    Call CF_Body_Dsp(pm_All)
                    '���ׂ̈�ԉ��̓��ꍀ�ڂ̲��ޯ�����擾
                    Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
                    If Next_Index > 0 Then
                        If Next_Index = Trg_Index Then
                        '������۰ق̏ꍇ
                            '�ړ������ŏI��
                            pm_Move_Flg = False
                            Exit Do
                        Else
                        '������۰قłȂ��ꍇ
                            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                            Exit Do
                        End If
                    Else
                        '���͉\�ȍŏ��̃C���f�b�N�X���擾
                        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
                        If Focus_Ctl_Ok_Fst_Idx > 0 Then
                            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                            Exit Do
                        Else
                            '�t�b�^���̍ŏ��̍��ڂ̂P�O����
                            'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                            Exit Do
                        End If
                    End If

                Else
                '����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
                    '�t�b�^���̍ŏ��̍��ڂ̂P�O����
                    'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                    Exit Do
                End If
            End If
        Loop

    Else
    '���ו��ȊO�̏ꍇ
        'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Set_Up_Next_Focus
    '   �T�v�F  Up�������̃t�H�[�J�X�ʒu�ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All) As Integer
    Dim Trg_Index   As Integer
    Dim Index_Wk    As Integer
    Dim Next_Index  As Integer
    Dim Wk_Cnt      As Integer
    Dim Cur_Top_Index As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer

    '�ړ��t���O������
    pm_Move_Flg = False

    '�������ޯ���擾
    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)

    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CInt(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
    '���ו��̏ꍇ
        Wk_Cnt = 0
        Do
            Wk_Cnt = Wk_Cnt + 1
            '���݂̍��ڂɗ񕪂�����Ɉړ��������ޯ�������߂�
            Next_Index = Trg_Index - (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)

            If Next_Index < 0 Then
            '�}�C�i�X�̏ꍇ
                '�P�O�̍��ڂ�
                Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
                Exit Do
            End If

            If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD _
            And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.NAME = pm_Dsp_Sub_Inf.Ctl.NAME Then
            '�ړ��悪���ו��ł��ړ��O�Ɠ������۰ٖ��̏ꍇ
                If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
                '̫������n�j
                    '�����Ɉړ�
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
                    pm_Move_Flg = True
                    Exit Do
                End If
            Else
            '���̍��ږ������ו��łȂ��ꍇ
                If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
                '���ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
                    '��ʂ̓��e��ޔ�
                    Call CF_Body_Bkup(pm_All)
                    '�ړ��\�s����ԏ�ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
                    pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                    If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                        '�c�X�N���[���o�[��ݒ�
                        Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                    End If
                    '��ʃ{�f�B���̔z����Đݒ�
                    Call CF_Dell_Refresh_Body_Inf(pm_All)
                    '��ʕ\��
                    Call CF_Body_Dsp(pm_All)
                    '���ׂ̈�ԏ�̓��ꍀ�ڂ̲��ޯ�����擾
                    Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
                    If Next_Index > 0 Then
                        If Next_Index = Trg_Index Then
                        '������۰ق̏ꍇ
                            '�ړ������ŏI��
                            pm_Move_Flg = False
                            Exit Do
                        Else
                        '������۰قłȂ��ꍇ
                            '���ꍀ�ڂ̂P��납��
                            '�P�O�̍��ڂ�
                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
                            Exit Do
                        End If
                    Else
                        '���͉\�ȍŏ��̃C���f�b�N�X���擾
                        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
                        If Focus_Ctl_Ok_Fst_Idx > 0 Then
                            '���͉\�ȍŏ��̍��ڂ̂P��납��
                            '�P�O�̍��ڂ�
                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
                            Exit Do
                        Else
                            '�w�b�_���̍Ō�̍��ڂ̂P��납��
                            '�P�O�̍��ڂ�
                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
                            Exit Do

                        End If
                    End If
                Else
                    '�w�b�_���̍Ō�̍��ڂ̂P��납��
                    '�P�O�̍��ڂ�
                    Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
                    Exit Do
                End If

            End If
        Loop
    Else
    '���ו��ȊO�̏ꍇ
        '�P�O�̍��ڂ�
        Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Init_Clr_Dsp
    '   �T�v�F  �e��ʂ̍��ڂ�������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Init_Clr_Dsp(pm_Index As Integer, pm_All As Cls_All) As Integer

    Dim Index_Wk        As Integer
    Dim Wk_Index_S      As Integer
    Dim Wk_Index_E      As Integer
    Dim Now_Dt          As Date
    Dim Wk_Mode         As Integer

'�r���������������������������������������������������������r
    Now_Dt = Now
'�d���������������������������������������������������������d

    If pm_Index = -1 Then
        Wk_Index_S = 1
        Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
        pm_All.Dsp_Base.Head_Ok_Flg = False
        Wk_Mode = ITM_ALL_CLR
    Else
        Wk_Index_S = pm_Index
        Wk_Index_E = pm_Index
        Wk_Mode = ITM_ALL_ONLY
    End If

    For Index_Wk = Wk_Index_S To Wk_Index_E

        '���ʏ�����
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)

        '�S�̏������̏ꍇ
        If Wk_Mode = ITM_ALL_CLR Then
            '�t�b�^���ȍ~�̍��ڂ�S̫����Ȃ��Ƃ���
            If Index_Wk > pm_All.Dsp_Base.Foot_Fst_Idx Then
                Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
            End If
        End If

'�r���������������������������������������������������������r
        '�ʏ�����
        Select Case Index_Wk
            Case CInt(FR_SSSMAIN.HD_TEISYOYM.Tag)
            '�o�������t
                '������ʕҏW���A�l�������Ă��Ȃ����ߕҏW��
                If Len(Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value)) = 0 Then
                    pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value = gv_strInitYM
                End If
                Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(gv_strInitYM, pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)

            Case CInt(FR_SSSMAIN.HD_SOUBSCD.Tag)
            '�q��
                '������ʕҏW���A�l�������Ă��Ȃ����ߕҏW��
                If Len(Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value)) = 0 Then
                    pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value = "" '
                End If
                Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item("", pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
            Case CInt(FR_SSSMAIN.HD_SOUCD.Tag)
            '�q��
                '������ʕҏW���A�l�������Ă��Ȃ����ߕҏW��
                If Len(Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value)) = 0 Then
                    pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value = "" '
                End If
                Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item("", pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
        
        End Select
'�d���������������������������������������������������������d

    Next

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Init_Clr_Dsp_Body
    '   �T�v�F  �e��ʂ̃{�f�B���ڂ�������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Init_Clr_Dsp_Body(pm_Bd_Index As Integer, pm_All As Cls_All) As Integer
'
'    Dim Index_Bd_Wk         As Integer
'    Dim Wk_Bd_Index_S       As Integer
'    Dim Wk_Bd_Index_E       As Integer
'    Dim Wk_Mode             As Integer
'    Dim Wk_Index            As Integer
'    Dim Wk_Row              As Integer
'
'    If pm_Bd_Index = -1 Then
'        Wk_Bd_Index_S = 1
'        Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
'
'        '��ʃ{�f�B���
'        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
'
''�r���������������������������������������������������������r
'        '�X�N���[��������
'        '�ő�l
'        Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
'        '�ŏ��l
'        Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
'        '�ő彸۰ٗ�
'        Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Move_Qty, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
'        '�ŏ���۰ٗ�
'        Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
'        '�����l
'        Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
''�d���������������������������������������������������������d
'        Wk_Mode = BODY_ALL_CLR
'    Else
'        Wk_Bd_Index_S = pm_Bd_Index
'        Wk_Bd_Index_E = pm_Bd_Index
'        Wk_Mode = BODY_ALL_ONLY
'    End If
'
'    For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
'
'        '���ʏ�����
'        Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
'
'        '�z��O�̏�������Ώۍs�ɃR�s�[
'        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
'
'        '�S�̏������̏ꍇ
'        If Wk_Mode = BODY_ALL_CLR Then
'            '�S�s�������
'            pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
'        End If
'
'        '�ʏ�����
''�r���������������������������������������������������������r
'        '�ȉ��̺��۰ق͖��ו����̺��۰قł���΂Ȃ�ł��n�j�ł�
'        '(�Ώۂ̖��ׂ̔ԍ���񂾂����K�v�A)
'        Wk_Index = CInt(FR_SSSMAIN.BD_LINNO(Index_Bd_Wk).Tag)
''�d���������������������������������������������������������d
'        'Dsp_Body_Inf�̍s�m�n�ɕϊ�
'        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
''�r���������������������������������������������������������r
'        'Dsp_Body_Inf�ɒl�������l��ݒ�
'        Call F_Init_Dsp_Body(Wk_Row, pm_All)
''�d���������������������������������������������������������d
'
'    Next
'
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Init_Cursor_Set
    '   �T�v�F  ��ʏ�����Ԏ��̃t�H�[�J�X�ʒu�ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Init_Cursor_Set(pm_All As Cls_All) As Integer

    Dim Trg_Index    As Integer

'�r���������������������������������������������������������r
    '�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
    '���͒S���҃R�[�h�i�����j�Ƀt�H�[�J�X�ݒ�
    '�������ޯ���擾
    Trg_Index = CInt(FR_SSSMAIN.HD_TEISYOYM.Tag)
    
    '̫����ړ�
    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
    '�I����Ԃ̐ݒ�i�����I���j
    Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
    '���ڐF�ݒ�
    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Chk_Jge_Action
    '   �T�v�F  �e�`�F�b�N�֐��̃`�F�b�N�O��
    '�@�@�@�@�@ �`�F�b�N���s�𔻒�
    '   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
    '           pm_From_Process�@�@�@ :�ďo������
    '           pm_Err_Rtn�@�@     �@ :�G���[�ߒl
    '           pm_Msg_Flg�@�@     �@ :���b�Z�[�W�t���O
    '           pm_Move�@�@�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
    '   �ߒl�F�@�`�F�b�N����
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                                 , ByRef pm_Err_Rtn As Integer _
                                 , ByRef pm_Msg_Flg As Boolean _
                                 , ByRef pm_Move As Boolean) As Integer
    Dim Rtn_Cd     As Integer

    '���s
    Rtn_Cd = CHK_KEEP

    Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
        Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN _
           , CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            '�O��Ɠ����`�F�b�N���e�̏ꍇ
                If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
                '���ڂ̃X�e�[�^�X���G���[�Ȃ�
                    '���f
                    Rtn_Cd = CHK_STOP
                    '���b�Z�[�W��\��
                    pm_Msg_Flg = False
                    '�ړ���
                    pm_Move = True
                    '�`�F�b�N�n�j
                    pm_Err_Rtn = CHK_OK
                End If
            End If

        Case CHK_FROM_KEYPRESS
            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            '�O��Ɠ����`�F�b�N���e�̏ꍇ
                If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
                '���ڂ̃X�e�[�^�X���G���[�Ȃ�
                    '���f
                    Rtn_Cd = CHK_STOP
                    '���b�Z�[�W��\��
                    pm_Msg_Flg = False
                    '�ړ���
                    pm_Move = True
                    '�`�F�b�N�n�j
                    pm_Err_Rtn = CHK_OK
                End If

            End If

        Case CHK_FROM_KEYRETURN
            '�KEYRETURN�
            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            '�O��Ɠ����`�F�b�N���e�̏ꍇ
                If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
                '���ڂ̃X�e�[�^�X���G���[�Ȃ�
                    '���f
                    Rtn_Cd = CHK_STOP
                    '���b�Z�[�W��\��
                    pm_Msg_Flg = False
                    '�ړ���
                    pm_Move = True
                    '�`�F�b�N�n�j
                    pm_Err_Rtn = CHK_OK
                End If

            End If

        Case CHK_FROM_ALL_CHK
            '�ꊇ�`�F�b�N�Ȃǣ
            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            '�O��Ɠ����`�F�b�N���e�̏ꍇ
                If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT _
                And pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True Then
                '���ڂ̃X�e�[�^�X���G���[�Ȃ��ł������͈ȊO�̃`�F�b�N���s���Ă���ꍇ
                    '���f
                    Rtn_Cd = CHK_STOP
                    '���b�Z�[�W��\��
                    pm_Msg_Flg = False
                    '�ړ���
                    pm_Move = True
                    '�`�F�b�N�n�j
                    pm_Err_Rtn = CHK_OK
                End If

            End If
    
    End Select

    If Rtn_Cd = CHK_STOP Then
    '�`�F�b�N�𒆒f
        '�`�F�b�N�֐��ďo���������N���A
        pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
    End If

    F_Chk_Jge_Action = Rtn_Cd

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Chk_Jge_Msg_Move
    '   �T�v�F  �e�`�F�b�N�֐��̃`�F�b�N���
    '�@�@�@�@�@ ���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
    '   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
    '           pm_From_Process�@�@�@ :�ďo������
    '           pm_Err_Rtn�@�@     �@ :�G���[�ߒl
    '           pm_Msg_Flg�@�@     �@ :���b�Z�[�W�t���O
    '           pm_Move�@�@�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
    '   �ߒl�F�@�`�F�b�N����
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                                 , ByRef pm_Err_Rtn As Integer _
                                 , ByRef pm_Msg_Flg As Boolean _
                                 , ByRef pm_Move As Boolean) As Integer

    '���b�Z�[�W�\���Ȃ�
    pm_Msg_Flg = False
    '�ړ���
    pm_Move = True

    If pm_Err_Rtn = CHK_OK Then
    '�`�F�b�N�n�j
        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
    Else

        Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
            Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN _
               , CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
                Select Case pm_Err_Rtn
                    Case CHK_ERR_NOT_INPUT
                    '�K�{���͂Ŗ�����
                        If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
                        '�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
                            '�`�F�b�N�n�j�Ƃ���
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
                            pm_Err_Rtn = CHK_OK
                            '���b�Z�[�W�o�͂Ȃ�
                            pm_Msg_Flg = False
                            '�ړ��n�j
                            pm_Move = True
                        Else
                        '�P�x�ł������̓`�F�b�N�����Ă���ꍇ
                            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                            '�O��Ɠ����`�F�b�N���e�̏ꍇ
                                '�`�F�b�N�G���[�Ƃ���
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                                '���b�Z�[�W�o�͂Ȃ�
                                pm_Msg_Flg = False
                                '�ړ��n�j
                                pm_Move = True
                            Else
                                '�O��ƈقȂ�`�F�b�N���e�̏ꍇ
                                '�`�F�b�N�G���[�Ƃ���
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                                '���b�Z�[�W�o�͂Ȃ�
                                pm_Msg_Flg = False
                                '�ړ��n�j
                                pm_Move = False
                            End If
                        
                        End If
                    Case CHK_ERR_ELSE
                    '���̑��G���[��
                        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                        '�O��Ɠ����`�F�b�N���e�̏ꍇ
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                            '���b�Z�[�W�o�͂Ȃ�
                            pm_Msg_Flg = False
                            '�ړ��n�j
                            pm_Move = True
                        Else
                        '�O��ƈقȂ�`�F�b�N���e�̏ꍇ
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                            '���b�Z�[�W�o�͂���
                            pm_Msg_Flg = True
                            '�ړ��n�j
                            pm_Move = False
                        End If

                End Select

            Case CHK_FROM_KEYPRESS
                Select Case pm_Err_Rtn
                    Case CHK_ERR_NOT_INPUT
                    '�K�{���͂Ŗ�����
                        If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
                        '�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
                            '�`�F�b�N�n�j�Ƃ���
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
                            pm_Err_Rtn = CHK_OK
                            '���b�Z�[�W�o�͂Ȃ�
                            pm_Msg_Flg = False
                            '�ړ��n�j
                            pm_Move = True
                        Else
                        '�P�x�ł������̓`�F�b�N�����Ă���ꍇ
                            '�`�F�b�N�G���[�Ƃ���
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                            '���b�Z�[�W�o�͂Ȃ�
                            pm_Msg_Flg = False
                            '�ړ��n�j
                            pm_Move = True
                        End If
                    Case CHK_ERR_ELSE
                    '���̑��G���[��
                        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                        '���b�Z�[�W�o�͂���
                        pm_Msg_Flg = True
                        '�ړ��m�f
                        pm_Move = False

                End Select

            Case CHK_FROM_KEYRETURN
                '�KEYRETURN�
                Select Case pm_Err_Rtn
                    Case CHK_ERR_NOT_INPUT
                    '�K�{���͂Ŗ�����
                        If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
                        '�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
                            pm_Err_Rtn = CHK_OK
                            '���b�Z�[�W�o�͂Ȃ�
                            pm_Msg_Flg = False
                            '�ړ��n�j
                            pm_Move = True
                        Else
                        '�P�x�ł������̓`�F�b�N�����Ă���ꍇ
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                            '���b�Z�[�W�o�͂���
                            pm_Msg_Flg = True
                            '�ړ��m�f
                            pm_Move = False
                        End If

                    Case CHK_ERR_ELSE
                    '���̑��G���[��
                        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                        '���b�Z�[�W�o�͂���
                        pm_Msg_Flg = True
                        '�ړ��m�f
                        pm_Move = False

                End Select
            Case CHK_FROM_ALL_CHK

                Select Case pm_Err_Rtn
                    Case CHK_ERR_NOT_INPUT
                    '�K�{���͂Ŗ�����
                        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                        '���b�Z�[�W�o�͂���
                        pm_Msg_Flg = True
                        '�ړ��m�f
                        pm_Move = False

                    Case CHK_ERR_ELSE
                    '���̑��G���[��
                        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                        '���b�Z�[�W�o�͂���
                        pm_Msg_Flg = True
                        '�ړ��m�f
                        pm_Move = False

                End Select

        End Select

    End If

    '�`�F�b�N�֐��ďo���������N���A
    pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Dsp_Item_Detail
    '   �T�v�F  �e���ڂ̉�ʕ\��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Dsp_Item_Detail(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, pm_All As Cls_All) As Integer

    Dim Trg_Index   As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)

    Select Case pm_Dsp_Sub_Inf.Ctl.NAME
'�r���������������������������������������������������������r
        Case FR_SSSMAIN.HD_SOUBSCD.NAME
            '�ꏊ�R�[�h�ɂ���ʕ\��
            Call F_Dsp_HD_SOUBSCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
        Case FR_SSSMAIN.HD_TEISYOYM.NAME
            '�o�������t�ɂ���ʕ\��
            Call F_Dsp_HD_TEISYOYM_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
        Case FR_SSSMAIN.HD_SOUCD.NAME
            '�q�ɃR�[�h�ɂ���ʕ\��
            Call F_Dsp_HD_SOUCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
'�d���������������������������������������������������������d

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Dsp_HD_SOUCD_Inf
    '   �T�v�F  �q�ɃR�[�h�ɂ���ʕ\��
    '   �����F  pm_Dsp_Sub_Inf   : ��ʍ��ڏ��
    '           pm_Mode          : ��ʕ\�����[�h
    '           pm_All           : ��ʏ��
    '   �ߒl�F
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Dsp_HD_SOUCD_Inf(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, pm_All As Cls_All) As Integer

    Dim Trg_Index   As Integer
    Dim Focus_Ctl   As Boolean
    Dim Dsp_Value   As Variant
    Dim Wk_Index    As Integer

    If pm_Mode = DSP_SET Then
    '�\��
        '���ړ��e���ύX���ꂽ�ꍇ
        If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

'�r���������������������������������������������������������r
            '�y�q�ɖ��z
            Trg_Index = CInt(FR_SSSMAIN.HD_SOUNM.Tag)
            Dsp_Value = CF_Cnv_Dsp_Item(TNAPR82_InputData.SOUNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

'�d���������������������������������������������������������d
            
            '�������e�A�O����e��ޔ�
            Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
        
        End If
    Else
    '�N���A
'�r���������������������������������������������������������r
        '�y�q�ɖ��z
        Trg_Index = CInt(FR_SSSMAIN.HD_SOUNM.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

'�d���������������������������������������������������������d
    End If

    '�O��`�F�b�N���e�ɑޔ�
    pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Dsp_HD_SOUBSCD_Inf
    '   �T�v�F  �ꏊ�R�[�h�ɂ���ʕ\��
    '   �����F  pm_Dsp_Sub_Inf   : ��ʍ��ڏ��
    '           pm_Mode          : ��ʕ\�����[�h
    '           pm_All           : ��ʏ��
    '   �ߒl�F
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Dsp_HD_SOUBSCD_Inf(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, pm_All As Cls_All) As Integer

    Dim Trg_Index   As Integer
    Dim Focus_Ctl   As Boolean
    Dim Dsp_Value   As Variant
    Dim Wk_Index    As Integer

    If pm_Mode = DSP_SET Then
    '�\��
        '���ړ��e���ύX���ꂽ�ꍇ
        If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

'�r���������������������������������������������������������r
            '�y�ꏊ���z
            Trg_Index = CInt(FR_SSSMAIN.HD_SOUBSNM.Tag)
            Dsp_Value = CF_Cnv_Dsp_Item(TNAPR82_InputData.SOUBSNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

'�d���������������������������������������������������������d
            
            '�������e�A�O����e��ޔ�
            Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
        
        End If
    Else
    '�N���A
'�r���������������������������������������������������������r
        '�y�ꏊ���z
        Trg_Index = CInt(FR_SSSMAIN.HD_SOUBSNM.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

'�d���������������������������������������������������������d
    End If

    '�O��`�F�b�N���e�ɑޔ�
    pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_Item_Chk
    '   �T�v�F  �e���ڂ�����ٰ�ݐ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Item_Chk(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, pm_All As Cls_All) As Integer

    Dim Rtn_Chk      As Integer
    
    '�e�����֐��Ɠ����ߒl
    Rtn_Chk = CHK_OK
    pm_Chk_Move_Flg = True
    
    '�@��{���͓��e�̃`�F�b�N
    Select Case pm_Dsp_Sub_Inf.Ctl.NAME
'�r���������������������������������������������������������r

        Case FR_SSSMAIN.HD_TEISYOYM.NAME
        '�o�������t�R�[�h
            '�����O����(�����֐��̑O�ŕK�{����)
            Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
            '����
            Rtn_Chk = F_Chk_HD_TEISYOYM(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        Case FR_SSSMAIN.HD_SOUBSCD.NAME
        '�ꏊ�R�[�h
            '�����O����(�����֐��̑O�ŕK�{����)
            Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
            '����
            Rtn_Chk = F_Chk_HD_SOUBSCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        Case FR_SSSMAIN.HD_SOUCD.NAME
        '�q�ɃR�[�h
            '�����O����(�����֐��̑O�ŕK�{����)
            Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
            '����
            Rtn_Chk = F_Chk_HD_SOUCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)


    End Select
'�d���������������������������������������������������������d

    F_Ctl_Item_Chk = Rtn_Chk

End Function

'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Chk_HD_TEISYOYM
    '   �T�v�F  ���������
    '   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
    '           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
    '           pm_All                :��ʏ��
    '   �ߒl�F�@�`�F�b�N����
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_HD_TEISYOYM(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                             , pm_Chk_Move As Boolean _
                             , pm_All As Cls_All) As Integer

    Dim Input_Value         As String
    Dim Retn_Code           As Integer
    Dim Msg_Flg             As Boolean
    Dim Rtn_Cd              As Integer
    Dim Err_Cd              As String

    '�`�F�b�N���s����
    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
    If Rtn_Cd = CHK_STOP Then
        '���f�̏ꍇ
        F_Chk_HD_TEISYOYM = Retn_Code
        Exit Function
    End If

'�r���������������������������������������������������������r
    '������
    Retn_Code = CHK_OK
    Err_Cd = ""
    Msg_Flg = False
    pm_Chk_Move = True

    '�����̓`�F�b�N
    If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        Retn_Code = CHK_ERR_ELSE
        Err_Cd = gc_strMsgTNAPR82_E_015              '�N���G���[
    Else
        '�����͈ȊO�̃`�F�b�N��
        pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

        '��b�`�F�b�N
        If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
            Retn_Code = CHK_ERR_ELSE
            Err_Cd = gc_strMsgTNAPR82_E_014              '�N���G���[
        Else
            '�n�j
            Retn_Code = CHK_OK
            pm_Chk_Move = True

            '�擾���ڊi�[
            TNAPR82_InputData.TEISYOYM = Input_Value
        End If
        
    End If
'�d���������������������������������������������������������d

    '�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
    Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

    If Msg_Flg = True And Trim(Err_Cd) <> "" Then
        '���b�Z�[�W�o��
        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    End If

    F_Chk_HD_TEISYOYM = Retn_Code

End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_Head_Chk
    '   �T�v�F  ͯ�ޕ�������ٰ�ݐ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Head_Chk(pm_All As Cls_All) As Integer

    Dim Index_Wk        As Integer
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer
    Dim intMoveFocus    As Integer

    '�e�����֐��Ɠ����ߒl
    Rtn_Chk = CHK_OK

    '�w�b�_���̍ŏI���ڂ܂Ŋe���ڂ��������s��
    For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx

        '�e����������S�������Ƃ��Čďo
        Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)

        If Rtn_Chk = CHK_OK Then
        '�`�F�b�N�n�j��
            '�擾���e�\��
            Dsp_Mode = DSP_SET
        Else
        '�`�F�b�N�m�f��
            '�擾���e�N���A
            Dsp_Mode = DSP_CLR
        End If
        
        '�擾���e�\��/�N���A
        Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
        
        '�`�F�b�N�m�f
        If Rtn_Chk <> CHK_OK Then

            '�����̓��b�Z�[�W
'            If Rtn_Chk = CHK_ERR_NOT_INPUT Then
'                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgMITET51_E_011, pm_All)
'            End If

            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)

            F_Ctl_Head_Chk = Rtn_Chk
            Exit Function
        End If
    Next

    '�֘A����
'�r���������������������������������������������������������r
    Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
    '�`�F�b�N�m�f
    If Rtn_Chk <> CHK_OK Then

        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)

        F_Ctl_Head_Chk = Rtn_Chk
        Exit Function
    End If
'�d���������������������������������������������������������d
    
    If Rtn_Chk = CHK_OK _
    And pm_All.Dsp_Base.Head_Ok_Flg = False Then
    '�`�F�b�N�n�j�ł���
    '�w�b�_���̃`�F�b�N�����߂Ă̏ꍇ
'        '�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
'        pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
        '�t�b�^�����J������
        Call F_Foot_In_Ready(pm_All)
        '�`�F�b�N�n�j
        pm_All.Dsp_Base.Head_Ok_Flg = True
    End If

    F_Ctl_Head_Chk = Rtn_Chk

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_Head_RelChk
    '   �T�v�F  ͯ�ޕ��̊֘A����
    '   �����F�@pm_ErrIdx : �G���[�������̃t�H�[�J�X�ړ��Ώہi�[��:�Č�ID�ֈړ��j
    '   �ߒl�F�@CHK_OK:�`�F�b�NOK�@CHK_ERR_ELSE:���̑��G���[
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Head_RelChk(pm_All As Cls_All, ByRef pm_ErrIdx As Integer) As Integer

    Dim Index_Wk        As Integer
    Dim Rtn_Chk         As Integer
    Dim Trg_IndexStt    As Integer
    Dim ValueStt        As String
    Dim ValueEnd        As String
    Dim Err_Cd          As String       '�G���[�R�[�h

    '�e�����֐��Ɠ����ߒl
    Rtn_Chk = CHK_ERR_ELSE
    Err_Cd = ""
    pm_ErrIdx = CInt(FR_SSSMAIN.HD_SOUCD.Tag)
    
    Rtn_Chk = CHK_OK
    
F_Ctl_Head_RelChk_END:

    If Trim(Err_Cd) <> "" Then
        '���b�Z�[�W�o��
        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    End If

    F_Ctl_Head_RelChk = Rtn_Chk

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_Body_Chk
    '   �T�v�F  ���ި��������ٰ�ݐ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Body_Chk(pm_All As Cls_All) As Integer
'
'    Dim Index_Wk_Col    As Integer
'    Dim Index_Wk_Row    As Integer
'    Dim Trg_Index       As Integer
'    Dim Rtn_Chk         As Integer
'    Dim Chk_Move_Flg    As Boolean
'    Dim Dsp_Sub_Inf_Wk  As Cls_Dsp_Sub_Inf
'    Dim Dsp_Mode        As Integer
'
'    Dim Err_Row         As Integer
'    Dim Err_Dsp_Sub_Inf_Wk  As Cls_Dsp_Sub_Inf
'    Dim Bd_Idx          As Integer
'    Dim Err_Index       As Integer
'    Dim Move_Flg        As Boolean
'    Dim Focus_Ctl_Ok_Fst_Idx As Integer
'
'
'    '�e�����֐��Ɠ����ߒl
'    Rtn_Chk = CHK_OK
'
'    '�{�f�B���̍ŏI���ڂ܂Ŋe���ڂ��������s��
'    For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
'
'        Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
'            Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
'                '���͑ҏ�ԁA���͍Ϗ�ԏ�Ԃ�Ώ�
'
'                For Index_Wk_Col = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail)
'
'                    '��ʖ��ׂ̉B�s�̍��ڂ̲��ޯ�����擾
'                    Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row( _
'                                  pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm _
'                                , pm_All)
'
'                    '���[�N�̢��ʍ��ڏ��ɉB�s���۰ق�����
'                    Set Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
'
'                    '���[�N�̢��ʍ��ڏ��ɢ��ʃ{�f�B����ҏW
'                    Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value _
'                                          , Dsp_Sub_Inf_Wk _
'                                          , pm_All)
'                    '��ʍ��ڏڍ׏���ݒ�
'                    Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col)
'
'                    '�e����������S�������Ƃ��Čďo
'                    Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
'
'                    If Rtn_Chk = CHK_OK Then
'                    '�`�F�b�N�n�j��
'                        '�擾���e�\��
'                        Dsp_Mode = DSP_SET
'                    Else
'                    '�`�F�b�N�m�f��
'                        '�擾���e�N���A
'                        Dsp_Mode = DSP_CLR
'                    End If
'                    '�擾���e�\��/�N���A
'                    Call F_Dsp_Item_Detail(Dsp_Sub_Inf_Wk, Dsp_Mode, pm_All)
'
'                    '���ʃ{�f�B���Ƀ��[�N�̢��ʍ��ڏ���ҏW
'                    '��ʍ��ڏڍ׏���ݒ�
'                    '�����ɂ���ĕύX����鍀�ڂ̂�
'                    Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col) _
'                                                      , Dsp_Sub_Inf_Wk.Detail)
'
'                    '�`�F�b�N�m�f
'                    If Rtn_Chk <> CHK_OK Then
'
'                        '�G���[�̏ꍇ�A�Ώۍs��\����̫����ړ�����
'                        '�G���[�p�ϐ��i�[
'                        '�s���
'                        Err_Row = Index_Wk_Row
'                        '�Ώۺ��۰ُ��
'                        Set Err_Dsp_Sub_Inf_Wk.Ctl = Dsp_Sub_Inf_Wk.Ctl
'                        '��ʍ��ڏڍ׏���ݒ�
'                        Err_Dsp_Sub_Inf_Wk.Detail = Dsp_Sub_Inf_Wk.Detail
'
'                        GoTo ERR_EXIT
'                    End If
'
'                Next
'        End Select
'    Next
'
'
''    '�֘A����
''    Rtn_Chk = F_Ctl_Body_RelChk(pm_All)
'    '�`�F�b�N�m�f
'    If Rtn_Chk <> CHK_OK Then
'
'        '������ړ��Ȃ�
''            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
'
'        F_Ctl_Body_Chk = Rtn_Chk
'        Exit Function
'    End If
'
'
'    F_Ctl_Body_Chk = Rtn_Chk
'
'    Exit Function
'
'ERR_EXIT:
''�G���[���A̫����ړ�
'    '�Ώۍs����ʂɕ\��
'    Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
'    '�Ώۍs�����ʖ��ׂ̍s���擾
'    Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
'    '��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
'    Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)
'
'     If Err_Index > 0 Then
'        '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
'        Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
''        '�I����Ԃ̐ݒ�i�����I���j
''        Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index - 1), SEL_INI_MODE_2)
''        '���ڐF�ݒ�
''        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index - 1), ITEM_NORMAL_STATUS, pm_All)
'
'    Else
'        '���͉\�ȍŏ��̃C���f�b�N�X���擾
'        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
'        If Focus_Ctl_Ok_Fst_Idx > 0 Then
'            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
'            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
'        End If
'    End If
'
'    F_Ctl_Body_Chk = Rtn_Chk
'    Exit Function
'
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Foot_In_Ready
    '   �T�v�F  �t�b�^���̓��͏���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Foot_In_Ready(pm_All As Cls_All) As Integer
'
'    Dim Index_Wk        As Integer
'
'    '�t�b�^�����ŏ���
'    For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
'        Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.NAME
''�r���������������������������������������������������������r
'            Case FR_SSSMAIN.TL_NHSCD.NAME _
'               , FR_SSSMAIN.TL_NOKDTPRT.NAME _
'               , FR_SSSMAIN.TL_YUKODT.NAME _
'               , FR_SSSMAIN.TL_DENCMA.NAME _
'               , FR_SSSMAIN.TL_TFPATH.NAME _
'               , FR_SSSMAIN.TL_SBAMITKN.NAME
''�d���������������������������������������������������������d
'            '������Ԃœ��͉\�Ⱥ��۰�
'                '���͉\
'                Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
'        End Select
'    Next
'
End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_MitList_PrtMain
    '   �T�v�F  �I�����ʕ\�o�͏o�͏���
    '   �����F�@pm_TNAPR82Data      ��ʓ��̓f�[�^
    '           pm_intMode          1:�v�����^�o��  2:��ʕ\��  3:�t�@�C���o��
    '   �ߒl�F�@0:����I��  1:���ň����  3:�Y���f�[�^���� 5:���f 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function PrintTNAPR82_Main(pm_All As Cls_All, pm_intMode As Integer) As Integer

    Dim intRet          As Integer
    Dim intRet2         As Integer
    Dim intMode         As Integer
    Dim bolRet          As Boolean
    Dim bolTrans        As Boolean
    Dim strPrtSeq       As String
    Dim strSQL          As String
    Dim strMsgCd        As String
    Dim bolOraErr       As Boolean
    Dim intCursor       As Integer
    Dim strLIST_ID      As String

    bolTrans = False

    '���łɈ�����J�n���Ă���ꍇ�͏������s���Ȃ�
    If gv_bolNowPrinting = True Then
        Exit Function
    End If

    '������t���O�Z�b�g
    gv_bolNowPrinting = True

    PrintTNAPR82_Main = 9

    SSS_LSTOP = False
    strMsgCd = ""
    bolOraErr = False

    '�{�^���̎g�p�^�s��
    FR_SSSMAIN.MN_LSTART.Enabled = False
    FR_SSSMAIN.MN_VSTART.Enabled = False
    FR_SSSMAIN.CM_LSTART.Visible = False
    FR_SSSMAIN.CM_VSTART.Visible = False
    FR_SSSMAIN.CM_LCANCEL.Enabled = True

    '�J�[�\���ޔ�
    intCursor = FR_SSSMAIN.MousePointer
    FR_SSSMAIN.MousePointer = vbHourglass

    '�w�b�_���̃`�F�b�N
    intRet = F_Ctl_Head_Chk(pm_All)
    If intRet <> CHK_OK Then
    '�`�F�b�N�m�f�̏ꍇ
        GoTo Error_Handler
    End If

    '���[�h�Ȃ��̏ꍇ�A�I����ʕ\��
    If pm_intMode = -1 Then

        gv_bolTNAPR82_LF_Enable = False

        DoEvents

        DLGLST02_ACE.Show vbModal
        intMode = SSS_RTNWIN + 1

        gv_bolTNAPR82_LF_Enable = True
    Else
        intMode = pm_intMode
    End If

    If intMode <> SSS_PRINTER And intMode <> SSS_VIEW And intMode <> SSS_FILE Then
        '���f
        PrintTNAPR82_Main = 0
        GoTo Exit_Handler
    End If

    '***�X�V����***

    '�Q�[�W�̏�����
    Call InitGauge
    Call ShowGauge(True)

    'USR9�Ńg�����U�N�V�����J�n
    bolRet = CF_Ora_BeginTrans(gv_Oss_USR1)
    If Not bolRet Then
        strMsgCd = gc_strMsgTNAPR82_E_010
        bolOraErr = True
        GoTo Error_Handler
    End If
    bolTrans = True

    '�r�d�p�̎擾
'    strPrtSeq = GetPrtSeq()
'    If strPrtSeq = "" Then
'        strMsgCd = gc_strMsgTNAPR82_E_007
'        bolOraErr = True
'        Exit Function
'    End If
    strLIST_ID = "TNAPR82"
    '���[�p���[�N�쐬�����̌Ăяo���iPLSQL�j
     Call F_Execute_PLSQL
    If Not bolRet Then
        strMsgCd = gc_strMsgTNAPR82_E_008
        bolOraErr = True
        GoTo Error_Handler
    End If

    '�Q�[�W�̍X�V
    Call RefreshGauge(1, 1)

    If SSS_LSTOP = False Then
        '�R�~�b�g
        bolRet = CF_Ora_CommitTrans(gv_Oss_USR1)
        If Not bolRet Then
            strMsgCd = gc_strMsgTNAPR82_E_010
            bolOraErr = True
            GoTo Error_Handler
        End If
        bolTrans = False

        '���[�o��
        intRet = OutPutList_Main(intMode, strLIST_ID, "", strPrtSeq)
        If intRet <> 0 Then
            PrintTNAPR82_Main = intRet
            Select Case intRet
                Case 1      '���ň����
                    '���b�Z�[�W�o�͍ς�
                Case 2      '�L�����Z��
                    strMsgCd = gc_strMsgTNAPR82_I_004
                Case 3      '�f�[�^�Ȃ�
                    strMsgCd = gc_strMsgTNAPR82_E_006
                Case Else   '����ȊO
                    strMsgCd = gc_strMsgTNAPR82_E_011
            End Select
            GoTo Error_Handler
        End If

    Else
        '�������f
        '���[���o�b�N
        If bolTrans Then
            Call CF_Ora_RollbackTrans(gv_Oss_USR1)
        End If
        bolTrans = False
    End If

    PrintTNAPR82_Main = 0

Exit_Handler:
    '���b�Z�[�W�̕\��
    If strMsgCd <> "" Then
        If bolOraErr Then
            Call AE_CmnMsgLibrary(SSS_PrgNm, strMsgCd, pm_All, "PrintTNAPR82_Main")
        Else
            Call AE_CmnMsgLibrary(SSS_PrgNm, strMsgCd, pm_All)
        End If
    End If

    '�{�^���̎g�p�^�s��
    FR_SSSMAIN.MN_LSTART.Enabled = True
    FR_SSSMAIN.MN_VSTART.Enabled = True
    FR_SSSMAIN.CM_LSTART.Visible = True
    FR_SSSMAIN.CM_VSTART.Visible = True
    FR_SSSMAIN.CM_LCANCEL.Enabled = False

    '�J�[�\����߂�
    FR_SSSMAIN.MousePointer = intCursor

    '�Q�[�W�̏�����
    Call InitGauge
    Call ShowGauge(False)

    '������t���O�Z�b�g
    gv_bolNowPrinting = False

    Exit Function

Error_Handler:

    '���[���o�b�N
    If bolTrans Then
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If
    bolTrans = False

    GoTo Exit_Handler

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function F_Execute_PLSQL
'   �T�v�F  SQL���s����
'   �����F  �Ȃ�
'   �ߒl�F  0 : ���� 9: �ُ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function F_Execute_PLSQL() As Integer
        
    
    Dim strSQL      As String           'SQL��
    
    Dim strPara1    As String           '���Ұ�1(�S���Һ���)
    Dim strPara2    As String           '���Ұ�2(�ײ���ID)
    Dim strPara3    As String           '���Ұ�3(�o�������t)
    Dim strPara4    As String           '���Ұ�4(�ꏊ����)
    Dim strPara5    As String           '���Ұ�5(�q�ɺ���)
    
    Dim lngPara6    As Long             '���Ұ�3(���ݺ���)
    Dim lngPara7    As Long             '���Ұ�5(�װ����)
    Dim strPara8    As String           '���Ұ�6(�װ���e)
    Dim lngPara9    As Long             '���Ұ�7(�Ǎ�����)
    Dim lngPara10    As Long             '���Ұ�8(�o�^����)
    Dim param(10)    As OraParameter      'PL/SQL�̃o�C���h�ϐ�
    Dim bolRet      As Boolean
    
    F_Execute_PLSQL = 9
    
    '��n���ϐ������ݒ�
    strPara1 = SSS_OPEID
    strPara2 = SSS_CLTID
    strPara3 = TNAPR82_InputData.TEISYOYM
    strPara4 = TNAPR82_InputData.SOUBSCD
    strPara5 = TNAPR82_InputData.SOUCD
    lngPara6 = 0
    lngPara7 = 0
    strPara8 = ""
    lngPara9 = 0
    lngPara10 = 0

    '�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P5", strPara5, ORAPARM_INPUT
    
    gv_Odb_USR1.Parameters.Add "P6", lngPara6, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P7", lngPara7, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P8", strPara8, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P9", lngPara9, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT

    '�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
    Set param(1) = gv_Odb_USR1.Parameters("P1")
    Set param(2) = gv_Odb_USR1.Parameters("P2")
    Set param(3) = gv_Odb_USR1.Parameters("P3")
    Set param(4) = gv_Odb_USR1.Parameters("P4")
    Set param(5) = gv_Odb_USR1.Parameters("P5")
    
    Set param(6) = gv_Odb_USR1.Parameters("P6")
    Set param(7) = gv_Odb_USR1.Parameters("P7")
    Set param(8) = gv_Odb_USR1.Parameters("P8")
    Set param(9) = gv_Odb_USR1.Parameters("P9")
    Set param(10) = gv_Odb_USR1.Parameters("P10")
    
    '�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
    param(1).serverType = ORATYPE_CHAR
    param(2).serverType = ORATYPE_CHAR
    param(3).serverType = ORATYPE_CHAR
    param(4).serverType = ORATYPE_CHAR
    param(5).serverType = ORATYPE_CHAR
    
    param(6).serverType = ORATYPE_NUMBER
    param(7).serverType = ORATYPE_NUMBER
    param(8).serverType = ORATYPE_VARCHAR2
    param(9).serverType = ORATYPE_NUMBER
    param(10).serverType = ORATYPE_NUMBER

    'PL/SQL�Ăяo��SQL
    strSQL = "BEGIN PRC_TNAPR82_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10); End;"

    'DB�A�N�Z�X
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo F_Execute_PLSQL_END
    End If

    '** �߂�l�擾
    lngPara6 = param(6).Value
    If IsNull(param(8).Value) = False Then
        strPara8 = param(8).Value
    End If
    
    '�G���[���ݒ�
    gv_Str_OraErrText = strPara8
    
    F_Execute_PLSQL = lngPara6
    
F_Execute_PLSQL_END:
    '** �p�����^����
    gv_Odb_USR1.Parameters.Remove "P1"
    gv_Odb_USR1.Parameters.Remove "P2"
    gv_Odb_USR1.Parameters.Remove "P3"
    
    gv_Odb_USR1.Parameters.Remove "P4"
    gv_Odb_USR1.Parameters.Remove "P5"
    gv_Odb_USR1.Parameters.Remove "P6"
    gv_Odb_USR1.Parameters.Remove "P7"
    gv_Odb_USR1.Parameters.Remove "P8"
    gv_Odb_USR1.Parameters.Remove "P9"
    gv_Odb_USR1.Parameters.Remove "P10"
End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Get_GATUDO
    '   �T�v�F  ���t�A�������猎�x���Z�o
    '   �����F�@pm_DT   ���t(YYYYMMDD)
    '   �ߒl�F�@���x(YYYYMM)
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Get_GATUDO(pm_DT As String, pm_SMEDD As String) As String

    Dim bolRet                  As Boolean
    Dim strSQL                  As String
    Dim Usr_Ody                 As U_Ody
    Dim strYM                   As String

    On Error GoTo ERR_HANDLE
    F_Get_GATUDO = Mid(pm_DT, 1, 6)
    
    '�O��o�������s���̌��x���Z�o
    strSQL = " select GET_GATUDO("
    strSQL = strSQL & "  '" & pm_DT & "'"
    strSQL = strSQL & " ,'" & pm_SMEDD & "'"
    strSQL = strSQL & " ) from dual "

    'DB�A�N�Z�X
    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    If bolRet = False Then
        GoTo ERR_HANDLE
    End If

    If CF_Ora_EOF(Usr_Ody) = False Then
        strYM = CF_Ora_GetDyn(Usr_Ody, 0)
    End If

    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody)

    F_Get_GATUDO = strYM

EXIT_HANDLE:
    Call CF_Ora_CloseDyn(Usr_Ody)
    Exit Function
    
ERR_HANDLE:
    GoTo EXIT_HANDLE
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Get_InitYM
    '   �T�v�F  �����\���p�̌��x���擾
    '   �����F�@����
    '   �ߒl�F�@���x(YYYYMM)
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Get_InitYM() As String

    Dim strYM                   As String
    Dim datDT                   As Date
    Dim Mst_Inf_SYSTBA          As TYPE_DB_SYSTBA

    '������
    F_Get_InitYM = ""
    Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
    
    '���[�U�[���Ǘ��e�[�u������
    If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
        Exit Function
    End If
    
    '�O��o�������s���̌��x���Z�o
    strYM = F_Get_GATUDO(Mst_Inf_SYSTBA.SMAUPDDT, Mst_Inf_SYSTBA.SMEDD)

    ''���x�{�P��
    datDT = Format(Format(strYM & "01", "@@@@/@@/@@"), "YYYY/MM/DD")
    datDT = DateAdd("d", -1, DateAdd("m", 2, datDT))
    F_Get_InitYM = datDT
'    F_Get_InitYM = Format(datDT, "YYYYMM")

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Dsp_HD_TEISYOYM_Inf
    '   �T�v�F  ����ɂ���ʕ\��
    '   �����F  pm_Dsp_Sub_Inf   : ��ʍ��ڏ��
    '           pm_Mode          : ��ʕ\�����[�h
    '           pm_All           : ��ʏ��
    '   �ߒl�F
    '   ���l�F  �v���O�����P�ʂ̋��ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Dsp_HD_TEISYOYM_Inf(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, pm_All As Cls_All) As Integer

    Dim Trg_Index   As Integer
    Dim Focus_Ctl   As Boolean
    Dim Dsp_Value   As Variant
    Dim Wk_Index    As Integer

    If pm_Mode = DSP_SET Then
    '�\��
        '���ړ��e���ύX���ꂽ�ꍇ
        If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
            
            '�������e�A�O����e��ޔ�
            Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
        
        End If
    Else
    '�N���A
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
    End If

    '�O��`�F�b�N���e�ɑޔ�
    pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Sub RefreshGauge
'   �T�v�F  �Q�[�W�̃J�E���g�A�b�v
'   �����F�@pin_intAllLine      : �S�̌���
'           pin_intNowCnt       : �����ό���
'   �ߒl�F�@�Ȃ�
'   ���l�F  �Ȃ�
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub InitGauge()
    FR_SSSMAIN.GAUGE.FloodPercent = 0
    FR_SSSMAIN.GAUGE.ForeColor = Cn_BLACK
End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Sub RefreshGauge
'   �T�v�F  �Q�[�W�̃J�E���g�A�b�v
'   �����F�@pin_intAllLine      : �S�̌���
'           pin_intNowCnt       : �����ό���
'   �ߒl�F�@�Ȃ�
'   ���l�F  �Ȃ�
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub RefreshGauge(pin_intAllLine As Integer, pin_intNowCnt As Integer)
    '
    '�Q�[�W�̕\��
    If pin_intAllLine > 0 And pin_intNowCnt > 0 Then
        FR_SSSMAIN.GAUGE.FloodPercent = pin_intNowCnt / pin_intAllLine * 100
        If FR_SSSMAIN.GAUGE.FloodPercent > 45 Then
            FR_SSSMAIN.GAUGE.ForeColor = Cn_WHITE
        Else
            FR_SSSMAIN.GAUGE.ForeColor = Cn_BLACK
        End If
    End If
    DoEvents
End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Sub ShowGauge
'   �T�v�F  �Q�[�W�̃J�E���g�A�b�v
'   �����F�@pin_intAllLine      : �S�̌���
'           pin_intNowCnt       : �����ό���
'   �ߒl�F�@�Ȃ�
'   ���l�F  �Ȃ�
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Sub ShowGauge(pin_bolVisible As Boolean)
    
    '�Q�[�W�̕\���E��\����ݒ�
    FR_SSSMAIN.GAUGE.Visible = pin_bolVisible
    FR_SSSMAIN.CM_LCANCEL.Visible = pin_bolVisible

End Sub

