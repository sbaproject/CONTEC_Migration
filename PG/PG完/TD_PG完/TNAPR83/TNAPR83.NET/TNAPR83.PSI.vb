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
	
	'���b�Z�[�W�R�[�h
	'����
	Public Const gc_strMsgTNAPR83_I_001 As String = "1TNAPR83_001" '�����s���Ă�낵���ł����H
	Public Const gc_strMsgTNAPR83_I_002 As String = "1TNAPR83_002" '���I�����Ă�낵���ł����H
	Public Const gc_strMsgTNAPR83_I_003 As String = "1TNAPR83_003" '���������I�����܂����B
	Public Const gc_strMsgTNAPR83_I_004 As String = "1TNAPR83_014" '�������𒆒f���܂����B
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgTNAPR83_E_005 As String = "2TNAPR83_005" '�����͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgTNAPR83_E_006 As String = "2TNAPR83_006" '���Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgTNAPR83_E_007 As String = "2TNAPR83_017" '���V�[�P���X�擾�ŃG���[���������܂����B
	Public Const gc_strMsgTNAPR83_E_008 As String = "2TNAPR83_008" '���c�a�X�V�G���[���������܂����B
	Public Const gc_strMsgTNAPR83_E_009 As String = "2TNAPR83_009" '���c�a�Q�ƃG���[���������܂����B
	Public Const gc_strMsgTNAPR83_E_010 As String = "2TNAPR83_010" '���c�a�A�N�Z�X�G���[���������܂����B
	Public Const gc_strMsgTNAPR83_E_011 As String = "2TNAPR83_011" '�����[�o�͏����ŃG���[���������܂����B
	Public Const gc_strMsgTNAPR83_E_012 As String = "2TNAPR83_012" '�����͂���Ă��Ȃ����ڂ�����܂��B���͂��ĉ������B
	Public Const gc_strMsgTNAPR83_E_013 As String = "2TNAPR83_013" '�����t�Ɍ�肪����܂��B�C�����Ă��������B
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgTNAPR83_E_014 As String = "2TNAPR83_014" '���N���Ɍ�肪����܂��B�C�����Ă��������B
End Module