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
	'����
	Public Const gc_strMsgURKFP55_I_001 As String = "1URKFP55_001" '�����s���Ă�낵���ł����H
	Public Const gc_strMsgURKFP55_I_002 As String = "1URKFP55_002" '���I�����Ă�낵���ł����H
	Public Const gc_strMsgURKFP55_I_003 As String = "1URKFP55_003" '���������I�����܂����B
	Public Const gc_strMsgURKFP55_I_004 As String = "1URKFP55_004" '�������𒆒f���܂����B
	Public Const gc_strMsgURKFP55_I_006 As String = "1URKFP55_006" '���e�L�X�g�t�@�C��������������}�X�^���X�V���܂��B
	Public Const gc_strMsgURKFP55_I_007 As String = "1URKFP55_007" '���I�����܂��B
	Public Const gc_strMsgURKFP55_I_008 As String = "1URKFP55_008" '���t�@�C�������݂��܂���B
	Public Const gc_strMsgURKFP55_I_009 As String = "1URKFP55_009" '�����������}�X�^���X�V����܂���ł����B
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgURKFP55_E_011 As String = "2URKFP55_011" '�����敪��1,2,3�ȊO�͎w��ł��܂���B
	Public Const gc_strMsgURKFP55_E_012 As String = "2URKFP55_012" '�Y�������s�R�[�h�����݂��܂���B
	Public Const gc_strMsgURKFP55_E_013 As String = "2URKFP55_013" '�o�[�`���������̌������V�����𒴂��Ă��܂��B
	Public Const gc_strMsgURKFP55_E_014 As String = "2URKFP55_014" '�Y�����鐿����R�[�h�����݂��܂���B
	Public Const gc_strMsgURKFP55_E_015 As String = "2URKFP55_015" '�Y�����������ʃR�[�h�����݂��܂���B
	Public Const gc_strMsgURKFP55_E_016 As String = "2URKFP55_016" '�Y�����銨������R�[�h�����݂��܂���B
	Public Const gc_strMsgURKFP55_E_017 As String = "2URKFP55_017" 'DB�X�V���ɃG���[������܂����B
	Public Const gc_strMsgURKFP55_E_018 As String = "2URKFP55_018" 'DB���o���ɃG���[������܂����B
	Public Const gc_strMsgURKFP55_E_019 As String = "2URKFP55_019" '�c�a�ŃA�N�Z�X�ł��܂���ł����B
	Public Const gc_strMsgURKFP55_E_020 As String = "2URKFP55_020" '���ڐ��Ɍ�肪����܂��B
	Public Const gc_strMsgURKFP55_E_021 As String = "2URKFP55_021" '�e�L�X�g�ǂݎ�莞�ɂɃG���[������܂����B
	Public Const gc_strMsgURKFP55_E_022 As String = "2URKFP55_022" 'INI�t�@�C������擾�ł��܂���ł����B
	Public Const gc_strMsgURKFP55_E_023 As String = "2URKFP55_023" '�e�L�X�g�t�@�C�����T�[�o�ɃR�s�[�ł��܂���ł����B
	Public Const gc_strMsgURKFP55_E_024 As String = "2URKFP55_024" '���O�t�@�C�����T�[�o����R�s�[�ł��܂���ł����B
	Public Const gc_strMsgURKFP55_E_025 As String = "2URKFP55_025" '�Y�����鐿����̌����ԍ�������Ă��܂��B
End Module