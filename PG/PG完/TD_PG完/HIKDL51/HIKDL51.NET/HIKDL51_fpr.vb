Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
'20190703 ADD START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'20190703 ADD END
Module SSSMAIN0001
	
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	
	Public gv_bolKeyFlg As Boolean
	
	'**�����֐��֘A Start **
	'//�ߒl
	Public Const CHK_OK As Short = 0 '����
	Public Const CHK_WARN As Short = 1 '�x��
	Public Const CHK_ERR_NOT_INPUT As Short = 10 '�����̓G���[
	Public Const CHK_ERR_ELSE As Short = 11 '���̑��G���[
	
	'F_Chk_Jge_Action�֐��p
	Public Const CHK_KEEP As Short = 0 '�`�F�b�N���s
	Public Const CHK_STOP As Short = 1 '�`�F�b�N���f
	'**�����֐��֘A End  **
	
	'//F_Set_Next_Focus�������[�h
	Public Const NEXT_FOCUS_MODE_KEYRETURN As Short = 1 'KEYRETURN�Ɠ��l�̐���
	Public Const NEXT_FOCUS_MODE_KEYRIGHT As Short = 2 'KEYRIGHT�Ɠ��l�̐���
	Public Const NEXT_FOCUS_MODE_KEYDOWN As Short = 3 'KEYDOWN�Ɠ��l�̐���
	
	'//F_Dsp_Item_Detail�������[�h
	Public Const DSP_SET As Short = 0 '�\��
    Public Const DSP_CLR As Short = 1 '�N���A
    '20190703 ADD START
    Public D0 As ClsComn = New ClsComn
    Public LV_Col_Order() As Integer
    '20190703 ADD END
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_DSP_TNADL71C
    '   �T�v�F  �����󋵏Ɖ��ʂ̕\��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  ��ʘA�g����
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_DSP_TNADL71C() As Short
		
		Dim stArrayData() As String
		
		stArrayData = Split(VB.Command(), "|")
		
		'�Ɖ�󂯓n���p�����[�^�ݒ�
		'�w�b�_���i���S���擾
		'���i�R�[�h
		TNADL71C_HINCD = stArrayData(2)
		'�^��
		TNADL71C_HINNMA = stArrayData(3)
		'���i���P
		TNADL71C_HINNMB = stArrayData(4)
		
		'���ו����S���擾
		'���o�ɓ�
		TNADL71C_STKDLVDT = stArrayData(5)
		'�o�ɐ�
		TNADL71C_DLVSU = 0
		'������
		TNADL71C_HIKSU = 0
		'���
		TNADL71C_JOTAI = stArrayData(6)
		'����
		TNADL71C_STKSU = CDec(stArrayData(7))
		'����
		TNADL71C_SZAISU = CDec(stArrayData(8))
		'�o�^��
		TNADL71C_DENDT = ""
		'����
		TNADL71C_SBNNO = stArrayData(9)
		'���Ӑ�
		TNADL71C_TOKRN = stArrayData(10)
		'�q��
		TNADL71C_SOUNM = stArrayData(11)
		'�q�撍���ԍ�
		TNADL71C_TOKJDNNO = stArrayData(12)
		
		'�����ϐ��擾
		'��ԋ敪
		TNADL71C_TRAKB = "4"
		'�󒍔ԍ�
		TNADL71C_JDNNO = ""
		'�Q�ƌ��ϔԍ�
		TNADL71C_MITNO = ""
		'�Ő�
		TNADL71C_MITNOV = "  "
		'�s�ԍ�
		TNADL71C_LINNO = "   "

        '�����󋵏Ɖ�\��
        FR_SSSSUB03.Show()

        'ICN_ICON.Close()

        ''��ʏI��
        'FR_SSSMAIN.Close()

    End Function
End Module