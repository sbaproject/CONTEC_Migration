Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'�v���O�����������v���V�W��
	'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	''================================================================================
	'���@��ʃ{�f�B���̍s�P�ʂ̋Ɩ����@�@�@�@�@��
	'���@�@Cls_Dsp_Body_Row_Inf�Ƃ̌݊������@�@�@��
	'���@�@���ʂ̑S�Ă̂o�f�Ő錾����@�@�@�@�@�@��
	'���@�@���̂��߈ȉ��̢Dummy��͕K�{�I�I �@�@�@��
	Public Structure Cls_Dsp_Body_Bus_Inf
		Dim Dummy As String '�_�~�[
		'����݌ɏƉ�p
		Dim IsDataRow As Boolean '�f�[�^�ێ��s�t���O
		Dim DATKB As String '�f�[�^�敪
		Dim LINNO As Integer '�s�ԍ�
		Dim JDNNO As String '�󒍔ԍ�
		Dim MITNO As String '�Q�ƌ��ϔԍ�
		Dim MITNOV As String '�Ő�
		'***add-S-tom
		Dim LIN As String '�s�ԍ�
		'***add-E-tom
		Dim STKDLVDT As String '���o�ɓ�
		Dim DLVSU As Decimal '�o�ɐ�
		Dim HIKSU As Decimal '������
		Dim JOTAI As String '���
		Dim STKSU As Decimal '���ɐ�
		Dim SZAISU As Decimal '����݌ɐ�
		' === 20070209 === INSERT S - ACE)Yano
		Dim DENDT As String '�󒍓�
		' === 20070209 === INSERT E -
		Dim SBNNO As String '����
		Dim TOKRN As String '���Ӑ於��
		Dim SOUNM As String '�q�ɖ�
		Dim TOKJDNNO As String '�q�撍���ԍ�
		Dim COLORFLG1 As String '�J���[�t���O�P
		Dim COLORFLG2 As String '�J���[�t���O�Q
		Dim COLORFLG3 As String '�J���[�t���O�R
		Dim COLORFLG4 As String '�J���[�t���O�S
		Dim COLORFLG5 As String '�J���[�t���O�T
		' === 20060803 === INSERT S - ACE)Nagasawa �^�p���̍Ō�̃f�[�^�ɑ΂��Ē��F���s��
		Dim COLORFLG6 As String '�J���[�t���O�U
		' === 20060803 === INSERT E -
		' === 20110131 === INSERT S - TOM)Morimoto �Ǘ��ԍ��ǉ�
		Dim DATNO As String '�Ǘ��ԍ�
		' === 20110131 === INSERT E -
		'����݌ɏƉ�i���ׁj�p
		Dim SUB_IsDataRow As Boolean '�f�[�^�ێ��s�t���O
		Dim SUB_LINNO As String '�s�ԍ�
		Dim SUB_HINCD As String '���i�R�[�h
		Dim SUB_HINNMA As String '�^��
		' === 20110124 === INSERT S - TOM)Morimoto �����p�`�[�Ǘ��ԍ���ێ�
		'    SUB_HINNMB          As String           '���i���P
		Dim SUB_TOKJDNNO As String '�q�撍���ԍ�
		' === 20110124 === INSERT E -
		Dim SUB_UODSU As Decimal '�󒍐���
		Dim SUB_UNTNM As String '�P�ʖ�
		Dim SUB_UODTK As Decimal '�󒍒P��
		Dim SUB_UODKN As Decimal '�󒍋��z
		Dim SUB_SBT As String '���
		Dim SUB_SIKTK As Decimal '�c�Ǝd�ؒP��
		Dim SUB_TEIKATK As Decimal '�艿
		Dim SUB_SIKRT As String '�d�ؗ�(�o�͂��Ȃ��ꍇ�p��String)
		Dim SUB_SIKSA As String '�d�؍�(�o�͂��Ȃ��ꍇ�p��String)
		Dim SUB_ODNYTDT As String '�o�ח\���
		Dim SUB_OTPSU As String '�o�׎��ѐ�(�o�͂��Ȃ��ꍇ�p��String)
		Dim SUB_OTYSU As String '�o�ח\�萔(�o�͂��Ȃ��ꍇ�p��String)
		' === 20061114 === INSERT S - ACE)Yano  ���ԏo�� ����݌ɏƉ�i���ׁj�p
		Dim SUB2_IsDataRow As Boolean '�f�[�^�ێ��s�t���O
		Dim SUB2_HINCD As String '���i�R�[�h
		Dim SUB2_HINNMA As String '�^��
		Dim SUB2_HINNMB As String '���i���P
		Dim SUB2_UODSU As Decimal '����
		Dim SUB2_OUTSMSU As Decimal '�o�׎��ѐ���
		Dim SUB2_UNTNM As String '�P�ʖ�
		Dim SUB2_LINCMA As String '���ה��l�P
		Dim SUB2_LINCMB As String '���ה��l�Q
		' === 20061114 === INSERT E -
		'***add-S-tom*** �����󋵏Ɖ�ǉ�
		Dim SUB3_IsDataRow As Boolean '�f�[�^�ێ��s�t���O
		Dim SUB3_TRAKB As String '���
		Dim SUB3_TRANO As String '����
		Dim SUB3_TRADT As String '���o�ɓ�
		Dim SUB3_SYUSU As Decimal '�o��
		Dim SUB3_HIKSU As Decimal '����
		Dim SUB3_ATMNKB As String '���^��
		Dim SUB3_NYUSU As Decimal '����
		Dim SUB3_TOKRN As String '���Ӑ�
		Dim SUB3_BUMNM As String '�c�ƕ���
		Dim SUB3_SOUNM As String '�q��
		'***add-E-tom***
	End Structure
	''================================================================================
	'���b�Z�[�W�R�[�h
	'����݌ɏƉ�i���ׁj
	Public Const gc_strMsgTNADL71_E_001 As String = "2TNADL71_001" '�Y������f�[�^�����݂��܂���B
	'����݌ɏƉ�
	Public Const gc_strMsgTNADL71_A_002 As String = "1TNADL71_002" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgTNADL71_E_003 As String = "2TNADL71_003" '�c�a�X�V�G���[���������܂����B
	Public Const gc_strMsgTNADL71_E_004 As String = "2TNADL71_004" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgTNADL71_E_005 As String = "2TNADL71_005" '�폜�ς݃��R�[�h�ł��B
	Public Const gc_strMsgTNADL71_E_006 As String = "2TNADL71_006" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgTNADL71_E_007 As String = "2TNADL71_007" '�f�[�^�擾�����ňُ킪�������܂����B
	Public Const gc_strMsgTNADL71_E_008 As String = "2TNADL71_008" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgTNADL71_E_009 As String = "2TNADL71_009" '�󒍁E���ρA���͐��ԏo�ɂ̃f�[�^�ł͂���܂���B
	Public Const gc_strMsgTNADL71_E_010 As String = "2TNADL71_010" '���̃R�[�h�͎g�p�ł��܂���B
	' === 20060908 === INSERT S - ACE)Sejima ���s�{�^���C���[�W�Ή�
	Public Const gc_strMsgTNADL71_E_011 As String = "2TNADL71_011" '����ȍ~�̃f�[�^�͂���܂���B
	' === 20060908 === INSERT E
	' === 20061121 === INSERT S - ACE)Nagasawa �x���i���̕\��
	Public Const gc_strMsgTNADL71_E_012 As String = "2TNADL71_012" '�����̎x���i�̂��ߖ��ׂ̕\���͍s���܂���B
	' === 20061121 === INSERT E -
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module