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
		Dim INPYTDT As String '���ɗ\���
		Dim HINNMA As String '�^��
		Dim LOTNO As String '����
		Dim INPYTSU As Decimal '����
		Dim SIRCD As String '�d����(�R�[�h�j
		Dim SIRRN As String '�d����(���́j
	End Structure
	
	''================================================================================
	'���b�Z�[�W�R�[�h
	'������������
	Public Const gc_strMsgENDFP61_E_001 As String = "2ENDFP61_001" '���̃R�[�h�͎g�p�ł��܂���B
	Public Const gc_strMsgENDFP61_E_002 As String = "2ENDFP61_002" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgENDFP61_E_003 As String = "2ENDFP61_003" '�{���ߍςׁ݂̈A�����ł��܂���B
	Public Const gc_strMsgENDFP61_E_004 As String = "2ENDFP61_004" '�������ւ̉����߂��s�����Ƃ͂ł��܂���B
	Public Const gc_strMsgENDFP61_A_005 As String = "1ENDFP61_005" '�������������������s���܂��B
	Public Const gc_strMsgENDFP61_A_006 As String = "1ENDFP61_006" '���������������s���܂��B
	Public Const gc_strMsgENDFP61_E_007 As String = "2ENDFP61_007" '�������I�����܂����
	Public Const gc_strMsgENDFP61_A_008 As String = "1ENDFP61_008" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgENDFP61_E_009 As String = "2ENDFP61_009" '�V�X�e���G���[
	Public Const gc_strMsgENDFP61_E_010 As String = "2ENDFP61_010" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgENDFP61_E_011 As String = "2ENDFP61_011" '�X�V����������܂���B
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module