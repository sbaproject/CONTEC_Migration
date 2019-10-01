Option Strict Off
Option Explicit On
Friend Class ClsFocusCtrl
	'//****************************************************************************************
	'//*
	'//*�����́�
	'//*    ClsFocusCtrl
	'//*
	'//*���o�[�W������
	'//*    1.00
	'//*���쐬�ҁ�
	'//*    RISE
	'//*��������
	'//*    ���s�L�[���͎��̎��t�H�[�J�X�R���g���[���̐��䃂�W���[��
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20040401|Rise)          |�V�K
	'//*****************************************************************************************
	'//-----------------------------------------------------------------------------------------
	'// �G���[���b�Z�[�W�p
	'//-----------------------------------------------------------------------------------------
	Private Const cst_�ُ� As String = "���s���G���[�ł��B�V�X�e���S���҂ɘA�����ĉ������B"
	Private Const cst_�ڍ� As String = vbCrLf & vbCrLf & "[ �ڍ� ]" & vbCrLf
	Private Const cst_�Q�l As String = vbCrLf & vbCrLf & "[ �Q�l ]" & vbCrLf
	
	'//*****************************************************************************************
	'// �萔�@�@��`
	'//*****************************************************************************************
	Private Const gvcst_OBJMax���� As Short = 500
	
	'//*****************************************************************************************
	'// �ϐ�   �錾
	'//*****************************************************************************************
	Private gvint_MaxEnterCtrl As Short '//�ړ��R���g���[���̐�
	Private gvobj_EnterCtrl() As Object '//�ړ��R���g���[���̃I�u�W�F�N�g�𗭍��ޔz��
	
	'//****************************************************************************************
	'//�C�j�V�����C�Y
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Initialize �� Class_Initialize_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub Class_Initialize_Renamed()
		gvint_MaxEnterCtrl = -1
		Erase gvobj_EnterCtrl
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'//****************************************************************************************
	'//�^�[�~�l�C�g
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Terminate �� Class_Terminate_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub Class_Terminate_Renamed()
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub

    '//*****************************************************************************************
    '//*
    '//* <���\�b�h>
    '//*    SetFocusCtrl
    '//*
    '//* <�߂�l>
    '//*              True    :����
    '//*              False   :���s
    '//*
    '//* <��  ��>     ���ږ�                I/O    ���e
    '//*              pmo_FmObj    �@       I     Form
    '//*
    '//* <��  ��>
    '//*    �t�H�[���̃t�H�[�J�X�\�R���g���[���̒��o
    '//*****************************************************************************************
    Function SetFocusCtrl(ByRef pmo_FmObj As Object) As Boolean

        Dim o_CTRL(gvcst_OBJMax����) As Object
        Dim i_TabIDX(gvcst_OBJMax����) As Short

        Dim i_COUNT As Short
        Dim i As Short
        Dim j As Short

        Dim i_wkobj As Object
        Dim i_wkidx As Short

        SetFocusCtrl = False

        '//���݂̈ړ��\�R���g���[�����擾
        i_COUNT = 0
        'add start 20190930 test kuwa

        'add end 20190930 kuwa
        'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        For i = 0 To pmo_FmObj.Controls.Count - 1
            'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: TypeName �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            Select Case TypeName(pmo_FmObj.Controls(i))
                Case "Label"

                Case "Frame"

                    '//�I�u�W�F�N�g���Ώ�
                Case "TextBox" '//÷���ޯ��
                    'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "ComboBox" '//�����ޯ��
                    'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "CommandButton" '//���������
                    'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "CheckBox" '//�����ޯ��
                    'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "OptionButton" '//��߼������
                    'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "ListView" '//ؽ��ޭ�
                    'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "MSFlexGrid" '//MSFlexGrid
                    'UPGRADE_ISSUE: GoSub �X�e�[�g�����g�̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case Else
            End Select

        Next i

        '//�ړ��\�R���g���[�������݂��Ȃ��ꍇ�͏I������
        If (i_COUNT = 0) Then
            Exit Function
        End If

        '//�ړ��\�R���g���[�������݂���ꍇ�͈ړ��\�R���g���[����ݒ肷��
        For i = 1 To i_COUNT - 1 'sort���� (�P�������@)
            For j = i + 1 To i_COUNT
                If (i_TabIDX(i) > i_TabIDX(j)) Then
                    i_wkidx = i_TabIDX(j)
                    i_wkobj = o_CTRL(j)
                    i_TabIDX(j) = i_TabIDX(i)
                    o_CTRL(j) = o_CTRL(i)
                    i_TabIDX(i) = i_wkidx
                    o_CTRL(i) = i_wkobj
                End If
            Next j
        Next i

        '//�ړ��������R���g���[������ݒ�
        gvint_MaxEnterCtrl = i_COUNT
        ReDim gvobj_EnterCtrl(gvint_MaxEnterCtrl)

        For i = 1 To i_COUNT
            gvobj_EnterCtrl(i) = o_CTRL(i)
        Next i

        SetFocusCtrl = True

        Exit Function

        'delete start 20190930 kuwa GET_CONTROL�����\�b�h���������߁A�폜����B
        '        '//���͉\�R���g���[���̔z��捞--------------------------------
        'GET_CONTROL:

        '        '//TabStop�AEnabled�AVisible�����ׂ�True�̂��̂��Ώ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        If (pmo_FmObj.Controls(i).TabStop = True And pmo_FmObj.Controls(i).Enabled = True And pmo_FmObj.Controls(i).Visible = True) Then

        '            '//�ΏۃI�u�W�F�N�g�Z�b�g
        '            i_COUNT = i_COUNT + 1
        '            'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            o_CTRL(i_COUNT) = pmo_FmObj.Controls(i)
        '            'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            i_TabIDX(i_COUNT) = Val(pmo_FmObj.Controls(i).TabIndex)
        '        End If

        '        'UPGRADE_WARNING: Return �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        '        '2019/04/11 CHG START
        '        'Return
        '        Return Nothing   '20190930 �T�����͂�������BEnterPress����For�����񐔂ɖ����Ȃ��܂ܔ����Ă��܂��BGoSub��Return�̖�����VB6��.Net�ňقȂ邽�߁B�@�u�b�N�}�[�N�̃T�C�g���Q�Ƃ��č��ς���B
        '        '2019/04/11 CHG E N D
        'delete end 20190930 kuwa

    End Function

    'add start 20190930 kuwa GET_CONTROL�̑���Ƀ��\�b�h���쐬�BGO_Sub���g��Ȃ��B
    '//*****************************************************************************************
    '//*
    '//* <���\�b�h>
    '//*    GET_CONTRL
    '//*
    '//* <�߂�l>
    '//*              �Ȃ�
    '//*
    '//* <��  ��>     ���ږ�              I/O    ���e
    '//*              
    '//*
    '//* <��  ��>
    '//*    ���͉\�R���g���[���̔z��捞--------------------------------
    '//*****************************************************************************************
    Sub GET_CONTROL(ByRef pmo_FmObj As Object, ByRef o_CTRL() As Object, ByRef i_TabIDX() As Short, ByRef i As Short, ByRef i_COUNT As Short)
        '//TabStop�AEnabled�AVisible�����ׂ�True�̂��̂��Ώ�
        'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If (pmo_FmObj.Controls(i).TabStop = True And pmo_FmObj.Controls(i).Enabled = True And pmo_FmObj.Controls(i).Visible = True) Then

            '//�ΏۃI�u�W�F�N�g�Z�b�g
            i_COUNT = i_COUNT + 1
            'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            o_CTRL(i_COUNT) = pmo_FmObj.Controls(i)
            'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            i_TabIDX(i_COUNT) = Val(pmo_FmObj.Controls(i).TabIndex)
        End If

    End Sub
    'add end 20190930 kuwa

    'add
    Sub GET_CONTROL2(ByRef paramc As Control, ByRef o_CTRL() As Object, ByRef i_TabIDX() As Short, ByRef i_COUNT As Integer)
        '//TabStop�AEnabled�AVisible�����ׂ�True�̂��̂��Ώ�
        'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If (paramc.TabStop = True And paramc.Enabled = True And paramc.Visible = True) Then

            '//�ΏۃI�u�W�F�N�g�Z�b�g
            i_COUNT = i_COUNT + 1
            'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            o_CTRL(i_COUNT) = paramc
            'UPGRADE_WARNING: �I�u�W�F�N�g pmo_FmObj.Controls �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            i_TabIDX(i_COUNT) = Val(paramc.TabIndex)        End If    End Sub    Function SetFocusCtrl2(ByRef pmo_FmObj As Object) As Boolean        Dim o_CTRL(gvcst_OBJMax����) As Object        Dim i_TabIDX(gvcst_OBJMax����) As Short        Dim i_COUNT As Short        Dim i As Short        Dim j As Short        Dim i_wkobj As Object        Dim i_wkidx As Short        SetFocusCtrl2 = False
        '//���݂̈ړ��\�R���g���[�����擾
        i_COUNT = 0        For Each topc As Control In pmo_FmObj.controls            For Each c As Control In topc.Controls                Select Case TypeName(c)                    Case "Label"                    Case "Frame"

                    '//�I�u�W�F�N�g���Ώ�
                    Case "TextBox" '//÷���ޯ��

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "ComboBox" '//�����ޯ��

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "CommandButton" '//���������

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "CheckBox" '//�����ޯ��

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "OptionButton" '//��߼������

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "ListView" '//ؽ��ޭ�

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "MSFlexGrid" '//MSFlexGrid
                        '
                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case Else                End Select            Next        Next        If (i_COUNT = 0) Then            Exit Function        End If

        '//�ړ��\�R���g���[�������݂���ꍇ�͈ړ��\�R���g���[����ݒ肷��
        For i = 1 To i_COUNT - 1 'sort���� (�P�������@)
            For j = i + 1 To i_COUNT                If (i_TabIDX(i) > i_TabIDX(j)) Then                    i_wkidx = i_TabIDX(j)                    i_wkobj = o_CTRL(j)                    i_TabIDX(j) = i_TabIDX(i)                    o_CTRL(j) = o_CTRL(i)                    i_TabIDX(i) = i_wkidx                    o_CTRL(i) = i_wkobj                End If            Next j        Next i

        '//�ړ��������R���g���[������ݒ�
        gvint_MaxEnterCtrl = i_COUNT        ReDim gvobj_EnterCtrl(gvint_MaxEnterCtrl)        For i = 1 To i_COUNT            gvobj_EnterCtrl(i) = o_CTRL(i)        Next i        SetFocusCtrl2 = True        Exit Function    End Function
    'add


    '//*****************************************************************************************
    '//*
    '//* <���\�b�h>
    '//*    EnterNext
    '//*
    '//* <�߂�l>
    '//*              True    :����
    '//*              False   :���s
    '//*
    '//* <��  ��>     ���ږ�              I/O    ���e
    '//*              pmf_BackKey         I      �t�H�[�J�X�o�b�N�i����l = False:�o�b�N���Ȃ��j
    '//*
    '//* <��  ��>
    '//*    ���s�L�[�����͂��ꂽ���ɁA���R���g���[���փt�H�[�J�X���ړ�������
    '//*****************************************************************************************
    'change start 20190930 kuwa
    '   Function EnterNext(Optional ByVal pmf_BackKey As Boolean = False) As Boolean

    '	Dim i_SETIDX As Short
    '	Dim i_NOWIDX As Short
    '	Dim i As Short

    '       EnterNext = False

    '	'//�ړ�����J�[�\���̈ʒu�����߂�
    '	i_NOWIDX = 0
    '	For i = 1 To gvint_MaxEnterCtrl
    '           'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
    '           If Not IsNothing(gvobj_EnterCtrl(i)) Then
    '               'change start test 20190930 kuwa
    '               'If (gvobj_EnterCtrl(i) Is VB6.GetActiveControl()) Then
    '               If (gvobj_EnterCtrl(i) Is VB6.GetActiveControl()) Then
    '                   'change test end 20190930 kuwa
    '                   i_NOWIDX = i
    '                   Exit For
    '               End If
    '           End If
    '       Next i

    '       '//�J�[�\���̈ʒu��������Ȃ��ꍇ
    '       If i_NOWIDX = 0 Then
    '		Exit Function
    '	End If

    '	'//�J�[�\���̈ʒu�����������ꍇ
    '	For i = 1 To gvint_MaxEnterCtrl
    '		'//�o�b�N�L�[�̎g�p����
    '		If pmf_BackKey Then
    '			i_SETIDX = i_NOWIDX - 1
    '			If i_SETIDX = 0 Then
    '				i_SETIDX = gvint_MaxEnterCtrl
    '			End If
    '		Else
    '			i_SETIDX = Int(i_NOWIDX Mod gvint_MaxEnterCtrl) + 1
    '		End If

    '		'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
    '		If IsNothing(gvobj_EnterCtrl(i_SETIDX)) Then
    '			i_NOWIDX = i_SETIDX
    '		Else
    '			'UPGRADE_WARNING: �I�u�W�F�N�g gvobj_EnterCtrl(i_SETIDX).Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			'UPGRADE_WARNING: �I�u�W�F�N�g gvobj_EnterCtrl(i_SETIDX).Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			If gvobj_EnterCtrl(i_SETIDX).Enabled = True And gvobj_EnterCtrl(i_SETIDX).Visible = True Then
    '				Exit For
    '			End If
    '		End If
    '	Next i

    '	'//�J�[�\�������̃R���g���[���ֈړ�&&
    '	On Error Resume Next
    '	'UPGRADE_WARNING: �I�u�W�F�N�g gvobj_EnterCtrl().SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	gvobj_EnterCtrl(i_SETIDX).SetFocus()
    '	On Error GoTo 0

    '	EnterNext = True

    'End Function

    Function EnterNext(Optional ByVal pmf_BackKey As Boolean = False, Optional ByVal prmName As String = "") As Boolean        Dim i_SETIDX As Short        Dim i_NOWIDX As Short        Dim i As Short        EnterNext = False

        '//�ړ�����J�[�\���̈ʒu�����߂�
        i_NOWIDX = 0        For i = 1 To gvint_MaxEnterCtrl
            'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            If Not IsNothing(gvobj_EnterCtrl(i)) Then

                'If (gvobj_EnterCtrl(i) Is VB6.GetActiveControl()) Then
                If DirectCast(gvobj_EnterCtrl(i), System.Windows.Forms.Control).Name = prmName Then                    i_NOWIDX = i                    Exit For                End If            End If        Next i

        '//�J�[�\���̈ʒu��������Ȃ��ꍇ
        If i_NOWIDX = 0 Then            Exit Function        End If

        '//�J�[�\���̈ʒu�����������ꍇ
        For i = 1 To gvint_MaxEnterCtrl
            '//�o�b�N�L�[�̎g�p����
            If pmf_BackKey Then                i_SETIDX = i_NOWIDX - 1                If i_SETIDX = 0 Then                    i_SETIDX = gvint_MaxEnterCtrl                End If            Else                i_SETIDX = Int(i_NOWIDX Mod gvint_MaxEnterCtrl) + 1            End If

            'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            If IsNothing(gvobj_EnterCtrl(i_SETIDX)) Then                i_NOWIDX = i_SETIDX            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g gvobj_EnterCtrl(i_SETIDX).Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g gvobj_EnterCtrl(i_SETIDX).Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If gvobj_EnterCtrl(i_SETIDX).Enabled = True And gvobj_EnterCtrl(i_SETIDX).Visible = True Then                    Exit For                End If            End If        Next i

        '//�J�[�\�������̃R���g���[���ֈړ�&&
        On Error Resume Next
        'UPGRADE_WARNING: �I�u�W�F�N�g gvobj_EnterCtrl().SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvobj_EnterCtrl(i_SETIDX).Focus()        On Error GoTo 0        EnterNext = True    End Function
    'change end 20190930 kuwa

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    GetKeyDown
    '//*
    '//* <�߂�l>
    '//*              ��NO
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*              KeyCode            I       �L�[�R�[�h
    '//*
    '//* <��  ��>
    '//*    �L�[�_�E������
    '//*****************************************************************************************
    Function GetKeyDown(ByRef KeyCode As Short) As Short
		
		Dim Int_PFKEY As Short
		
		GetKeyDown = 0
		
		'UPGRADE_WARNING: TypeName �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeName(VB6.GetActiveControl()) = "CommandButton" And KeyCode = System.Windows.Forms.Keys.Space Then
			KeyCode = 0
			Exit Function
		End If
		
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.Return
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F1
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F2
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F3
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F4
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F5
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F6
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F7
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F8
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F9
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F10
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F11
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F12
				Int_PFKEY = KeyCode
		End Select
		
		GetKeyDown = Int_PFKEY
		
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <��  ��>
	'//*    SetSelCursor
	'//*
	'//* <�߂�l>
	'//*              ��NO
	'//*
	'//* <��  ��>     ���ږ�              I/O      ���e
	'//*              Ctl                  I       �ΏۃR���g���[��
	'//*
	'//* <��  ��>
	'//*    �J�[�\�����]����
	'//*****************************************************************************************
	Public Sub SetSelCursor(ByRef Ctl As System.Windows.Forms.Control)
		
		On Error GoTo ErrorTrap
		
        '2019/04/11 CHG START
        'With Ctl
        '    'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        '    If TypeOf Ctl Is System.Windows.Forms.TextBox Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SelStart = 0
        '        'UPGRADE_WARNING: �I�u�W�F�N�g Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SelLength = Len(.Text)
        '    End If
        'End With
         If TypeOf Ctl Is System.Windows.Forms.TextBox Then
            With DirectCast(Ctl, TextBox)
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
            End With
        End If
        '2019/04/11 CHG E N D

        On Error GoTo 0
        Exit Sub

ErrorTrap:
        Err.Clear()
        On Error GoTo 0
        Exit Sub
		
	End Sub
End Class