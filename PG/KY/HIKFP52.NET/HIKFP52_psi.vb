Option Strict Off
Option Explicit On
Module SSSMAIN0002
	''�v���O�����������v���V�W��
	''���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	'''================================================================================
	''���@��ʃ{�f�B���̍s�P�ʂ̋Ɩ����@�@�@�@�@��
	''���@�@Cls_Dsp_Body_Row_Inf�Ƃ̌݊������@�@�@��
	''���@�@���ʂ̑S�Ă̂o�f�Ő錾����@�@�@�@�@�@��
	''���@�@���̂��߈ȉ��̢Dummy��͕K�{�I�I �@�@�@��
	Public Structure Cls_Dsp_Body_Bus_Inf
		Dim Dummy As String '�_�~�[
	End Structure
	'''================================================================================
	'�󒍎c�Ɖ�i����\��m�F�j
	Public Const gc_strMsgHIKFP52_Q_EXIT03 As String = "1HIKFP52_001" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgHIKFP52_E_NODATA01 As String = "2HIKFP52_002" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgHIKFP52_E_DELDATA As String = "2HIKFP52_003" '�폜�ς݃��R�[�h�ł��B
	Public Const gc_strMsgHIKFP52_E_INPUTERR As String = "2HIKFP52_004" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgHIKFP52_Q_RUN As String = "1HIKFP52_005" '���s���Ă�낵���ł����H
	Public Const gc_strMsgHIKFP52_Q_ZAIKBNG As String = "1HIKFP52_006" '�݌ɊǗ��ΏۊO�ł��B
	Public Const gc_strMsgHIKFP52_A_UPDATEOK As String = "1HIKFP52_007" '�������I�����܂����B
	Public Const gc_strMsgHIKFP52_A_COMPLETEC As String = "2HIKFP52_008" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgHIKFP52_E_UPDATENG As String = "2HIKFP52_009" '�c�a�X�V�G���[���������܂����B
	Public Const gc_strMsgHIKFP52_E_NOTSEIHIN As String = "2HIKFP52_010" '���i�ł͂���܂���B
	Public Const gc_strMsgHIKFP52_E_011 As String = "2HIKFP52_011" '���̃R�[�h�͎g�p�ł��܂���B
	' === 20061105 === INSERT S - ACE)Nagasawa �r������̒ǉ�
	Public Const gc_strMsgHIKFP52_E_012 As String = "2HIKFP52_012" '�����s���ł��B���΂炭���Ď��s���Ă��������B
	' === 20061105 === INSERT E -
	' === 20061129 === INSERT S - ACE)Nagasawa �X�V�����`�F�b�N��ύX����
	Public Const gc_strMsgHIKFP52_E_013 As String = "2HIKFP52_013" '�X�V����������܂���B
	' === 20061129 === INSERT E -
	''���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module