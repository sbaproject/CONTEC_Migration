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
	End Structure
	''================================================================================
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
	Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)

    '���b�Z�[�W�R�[�h
    '����gc_strMsgHINFP61_E_008
    Public Const gc_strMsgHINFP61_I_001 As String = "1HINFP61_001" '�����s���Ă�낵���ł����H
	Public Const gc_strMsgHINFP61_I_002 As String = "1HINFP61_002" '���I�����Ă�낵���ł����H
	Public Const gc_strMsgHINFP61_I_003 As String = "1HINFP61_003" '���������I�����܂����B
	Public Const gc_strMsgHINFP61_I_004 As String = "1HINFP61_004" '�������𒆒f���܂����B
	Public Const gc_strMsgHINFP61_I_005 As String = "1HINFP61_005" '���t�@�C�������݂��܂��B�㏑�����Ă���낵���ł���?
	Public Const gc_strMsgHINFP61_I_006 As String = "1HINFP61_006" '�����o�����f�[�^���t�@�C���ɏo�͂��܂��B
	Public Const gc_strMsgHINFP61_I_007 As String = "1HINFP61_007" '���I�����܂��B
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgHINFP61_E_008 As String = "2HINFP61_008" '�����͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgHINFP61_E_009 As String = "2HINFP61_009" '���Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgHINFP61_E_010 As String = "2HINFP61_010" '���c�a�Q�ƃG���[���������܂����B
    Public Const gc_strMsgHINFP61_E_011 As String = "2HINFP61_011" '���b�r�u�o�͏����ŃG���[���������܂����B

End Module