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
	Public Const gc_strMsgHINFP62_I_001 As String = "1HINFP62_001" '�����s���Ă�낵���ł����H
	Public Const gc_strMsgHINFP62_I_002 As String = "1HINFP62_002" '���I�����Ă�낵���ł����H
	Public Const gc_strMsgHINFP62_I_003 As String = "1HINFP62_003" '���������I�����܂����B
	Public Const gc_strMsgHINFP62_I_004 As String = "1HINFP62_004" '�������𒆒f���܂����B
	Public Const gc_strMsgHINFP62_I_006 As String = "1HINFP62_006" '��CSV�t�@�C�����珤�i�}�X�^���X�V���܂��B
	Public Const gc_strMsgHINFP62_I_007 As String = "1HINFP62_007" '���I�����܂��B
	Public Const gc_strMsgHINFP62_I_008 As String = "1HINFP62_008" '���t�@�C�������݂��܂���B
	Public Const gc_strMsgHINFP62_I_009 As String = "1HINFP62_009" '�����i�}�X�^���X�V����܂���ł����B
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgHINFP62_E_011 As String = "2HINFP62_011" '�ŏ��������ɐ����ȊO�������Ă��܂��B
	Public Const gc_strMsgHINFP62_E_012 As String = "2HINFP62_012" '�ŏ��������ɐ����ȊO�������Ă��܂��B
	Public Const gc_strMsgHINFP62_E_013 As String = "2HINFP62_013" '���S�݌ɐ��ɐ����ȊO�������Ă��܂��B
	Public Const gc_strMsgHINFP62_E_014 As String = "2HINFP62_014" '�󒍒�~���Ɍ�肪����܂��B
	Public Const gc_strMsgHINFP62_E_015 As String = "2HINFP62_015" '�̔��������Ɍ�肪����܂��B
	Public Const gc_strMsgHINFP62_E_016 As String = "2HINFP62_016" '��z�I�����Ɍ�肪����܂��B
	Public Const gc_strMsgHINFP62_E_017 As String = "2HINFP62_017" '�C����t���Ɍ�肪����܂��B
	Public Const gc_strMsgHINFP62_E_018 As String = "2HINFP62_018" '�i���̌������T�O�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_019 As String = "2HINFP62_019" '���i�敪�̌������P�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_020 As String = "2HINFP62_020" '�݌Ƀ����N�̌��������p�R�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_021 As String = "2HINFP62_021" '�ŏ��������̌������S���𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_022 As String = "2HINFP62_022" '�����������̌������S���𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_023 As String = "2HINFP62_023" '���S�݌ɐ��̌������U���𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_024 As String = "2HINFP62_024" '��p�@��̌������S�O�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_025 As String = "2HINFP62_025" '�󒍒�~�̌������P�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_026 As String = "2HINFP62_026" '�̔������̌������P�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_027 As String = "2HINFP62_027" '��z�I���̌������P�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_028 As String = "2HINFP62_028" '�C����t�̌������P�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_029 As String = "2HINFP62_029" '���[�J�̌������R�O�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_030 As String = "2HINFP62_030" '���l�`�̌������Q�O�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_031 As String = "2HINFP62_031" '���l�a�̌������Q�O�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_032 As String = "2HINFP62_032" '���l�b�̌������Q�O�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_033 As String = "2HINFP62_033" '���l�c�̌������Q�O�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_034 As String = "2HINFP62_034" '���l�d�̌������Q�O�����𒴂��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_035 As String = "2HINFP62_035" '�Y�����鐻���R�[�h�����݂��܂���B
	Public Const gc_strMsgHINFP62_E_036 As String = "2HINFP62_036" '�i�����ݒ肳��Ă��܂���B
	Public Const gc_strMsgHINFP62_E_037 As String = "2HINFP62_037" '�Y������P�ʃR�[�h�����݂��܂���B
	Public Const gc_strMsgHINFP62_E_038 As String = "2HINFP62_038" '�Y������q�ɃR�[�h�����݂��܂���B
	Public Const gc_strMsgHINFP62_E_039 As String = "2HINFP62_039" '�q�ɃR�[�h���Ԉ���Ă��܂��B
	Public Const gc_strMsgHINFP62_E_040 As String = "2HINFP62_040" '�݌Ƀ����N���Ԉ���Ă��܂��B
	Public Const gc_strMsgHINFP62_E_041 As String = "2HINFP62_041" '���i�敪�͂P�A�Q�ȊO�͎w��ł��܂���B
	Public Const gc_strMsgHINFP62_E_042 As String = "2HINFP62_042" '�񋟋敪�͂O�A�Q�ȊO�͎w��ł��܂���B
	Public Const gc_strMsgHINFP62_E_043 As String = "2HINFP62_043" '�󒍒�~�͂P�A�X�ȊO�͎w��ł��܂���B
	Public Const gc_strMsgHINFP62_E_044 As String = "2HINFP62_044" '�̔������͂P�A�X�ȊO�͎w��ł��܂���B
	Public Const gc_strMsgHINFP62_E_045 As String = "2HINFP62_045" '��z�I���͂P�A�X�ȊO�͎w��ł��܂���B
	Public Const gc_strMsgHINFP62_E_046 As String = "2HINFP62_046" '�C����t�͂P�A�X�ȊO�͎w��ł��܂���B
	Public Const gc_strMsgHINFP62_E_047 As String = "2HINFP62_047" '�󒍒�~���@���t�G���[�B
	Public Const gc_strMsgHINFP62_E_048 As String = "2HINFP62_048" '�󒍒�~�����ݒ肳��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_049 As String = "2HINFP62_049" '�󒍒�~�����ݒ肳��Ă��܂���B
	Public Const gc_strMsgHINFP62_E_050 As String = "2HINFP62_050" '�̔��������@���t�G���[�B
	Public Const gc_strMsgHINFP62_E_051 As String = "2HINFP62_051" '�̔����������ݒ肳��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_052 As String = "2HINFP62_052" '�̔����������ݒ肳��Ă��܂���B
	Public Const gc_strMsgHINFP62_E_053 As String = "2HINFP62_053" '��z�I�����@���t�G���[�B
	Public Const gc_strMsgHINFP62_E_054 As String = "2HINFP62_054" '��z�I�������ݒ肳��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_055 As String = "2HINFP62_055" '��z�I�������ݒ肳��Ă��܂���B
	Public Const gc_strMsgHINFP62_E_056 As String = "2HINFP62_056" '�C����t���@���t�G���[�B
	Public Const gc_strMsgHINFP62_E_057 As String = "2HINFP62_057" '�C����t�����ݒ肳��Ă��܂��B
	Public Const gc_strMsgHINFP62_E_058 As String = "2HINFP62_058" '�C����t�����ݒ肳��Ă��܂���B
	Public Const gc_strMsgHINFP62_E_059 As String = "2HINFP62_059" '�X�V�f�[�^���ꌏ������܂���ł����B
	Public Const gc_strMsgHINFP62_E_060 As String = "2HINFP62_060" 'DB�X�V���ɃG���[������܂����B
	Public Const gc_strMsgHINFP62_E_061 As String = "2HINFP62_061" 'DB���o���ɃG���[������܂����B
	Public Const gc_strMsgHINFP62_E_062 As String = "2HINFP62_062" '���O�������ݎ��ɃG���[������܂����B
	Public Const gc_strMsgHINFP62_E_063 As String = "2HINFP62_063" 'CSV�ǂݎ�莞�ɂɃG���[������܂����B
	Public Const gc_strMsgHINFP62_E_064 As String = "2HINFP62_064" 'DB�A�N�Z�X�ł��܂���ł����B
	Public Const gc_strMsgHINFP62_E_065 As String = "2HINFP62_065" '���ڐ��Ɍ�肪����܂��B
	Public Const gc_strMsgHINFP62_E_066 As String = "2HINFP62_066" 'INI�t�@�C���邩��擾�ł��܂���ł����B
	Public Const gc_strMsgHINFP62_E_067 As String = "2HINFP62_067" '�e�L�X�g�t�@�C�����T�[�o�ɃR�s�[�ł��܂���ł����B
	Public Const gc_strMsgHINFP62_E_068 As String = "2HINFP62_068" '���O�t�@�C�����T�[�o����R�s�[�ł��܂���ł����B
End Module