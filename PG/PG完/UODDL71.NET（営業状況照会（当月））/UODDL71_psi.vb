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
		Dim Selected As String '�I��/��I��
		Dim DIVISION As String '����ʑ����\�i1:����A2:�n��A3:�c�Ə��A99:�S�Ёj�A�@��ʑ����\�i1:���i�Q�ʍ��v�A2:���ׁA99:�����v�j�A�@�햾�ו\�i1:���i�Q���v�A2:���ނ`���v�A3:���ނa���v�A99:�����v�j
		Dim DIVCODE As String '����ʑ����\�i����R�[�hor�n��敪or�c�Ə��R�[�h�j
		Dim MEISYO As String '����
		Dim BD_UODSU_T As Decimal '�󒍐�
		Dim BD_UODKN_T As Decimal '�󒍋��z
		Dim BD_SIKKN_T As Decimal '�d��
		Dim BD_BAISA_T As Decimal '����
		Dim BD_BSART_T As Decimal '������
	End Structure
	
	''================================================================================
	'���b�Z�[�W�R�[�h
	'�c�Ə󋵏Ɖ�
	Public Const gc_strMsgUODDL71_E_001 As String = "2UODDL71_001" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgUODDL71_E_002 As String = "2UODDL71_002" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgUODDL71_E_003 As String = "2UODDL71_003" '�폜�ς݃��R�[�h�ł��B
	Public Const gc_strMsgUODDL71_E_004 As String = "2UODDL71_004" '���̃R�[�h�͎g�p�ł��܂���B
	Public Const gc_strMsgUODDL71_E_005 As String = "2UODDL71_005" '������������͂��Ă��������B
	Public Const gc_strMsgUODDL71_E_006 As String = "1UODDL71_006" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgUODDL71_E_007 As String = "2UODDL71_007" '����ȍ~�̃f�[�^�͂���܂���B
	Public Const gc_strMsgUODDL71_E_008 As String = "2UODDL71_008" '���ׂ�I�����Ă��������B
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module