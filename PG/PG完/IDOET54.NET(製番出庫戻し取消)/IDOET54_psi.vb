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
		Dim LINNO As String '�s�ԍ�
		Dim SMADT As String '�o�������t
		Dim HINCD As String '���i�R�[�h
		Dim HINNMA As String '�^��
		Dim HINNMB As String '���i���P
		Dim UODSU As String '�󒍐���
		Dim UNTCD As String '�P�ʃR�[�h
		Dim UNTNM As String '�P�ʖ�
		Dim UODTK As String '�󒍒P��
		Dim UODTK_INIT As String '�󒍒P���i�����\���p�j
		Dim UODKN As String '�󒍋��z
		Dim SIKTK As String '�c�Ǝd�ؒP��
		Dim SIKKN As String '�c�Ǝd�؋��z
		Dim TEIKATK As String '�艿
		Dim SIKRT As String '�d�ؗ�
		Dim KONSIKRT As String '����d�ؗ�
		Dim SIKRT_NOMAL As Decimal '�W���d�ؗ�
		Dim SIKSA As String '�d�؍�
		Dim ZAIKB As String '�݌ɊǗ��敪
		Dim LINCMA As String '���ה��l�P
		Dim LINCMB As String '���ה��l�Q
		Dim LSTID As String '�`�[���
		Dim HINZEIKB As String '���i����ŋ敪
		Dim ZEIRT As String '����ŗ�
		Dim UZEKN As Decimal '����Ŋz
		Dim ZEIRNKKB As String '����Ń����N
		Dim HINNMMKB As String '�����ƭ�ً敪�i���i�j
		Dim MAKCD As String '���[�J�[�R�[�h
		Dim HINKB As String '���i�敪
		Dim HRTDD As String '�������[�h�^�C��
		Dim ORTDD As String '�o�׃��[�h�^�C��
		Dim ODNYTDT As String '�o�ח\���
		Dim UDNYTDT As String '����\���
		Dim TNKKB As String '�P�����
		Dim TNKKBNM As String '�P����ʖ�
		Dim GNKCD As String '�����Ǘ��R�[�h
		Dim CLMDL As String '���ތ^��
		Dim HINGRP As String '���i�Q
		Dim MAKNM As String '���[�J�[��
		Dim SBNNO As String '����
		Dim ZAIRNK As String '�݌Ƀ����N
		Dim SODUNTSU As Decimal '�����P�ʐ�
		Dim MITTRA_ZAIHIKSU As String '���σg����.�݌Ɉ�����
		Dim MITTRA_NYTHIKSU As String '���σg����.���ɗ\�������
		Dim HINMTA_HINID As String '���i�}�X�^.���i���
		Dim HINMTA_PRDENDKB As String '���i�}�X�^.���Y�I��
		Dim HINMTA_PRDENDDT As String '���i�}�X�^.���Y�I�����t
		Dim HINMTA_SLENDKB As String '���i�}�X�^.�̔�����
		Dim HINMTA_SLENDDT As String '���i�}�X�^.�̔��������t
		Dim HINMTA_JODSTPKB As String '���i�}�X�^.�󒍒�~
		Dim HINMTA_JODSTPDT As String '���i�}�X�^.�󒍒�~���t
		Dim HINMTA_MDLCL As String '���i�}�X�^.�@�핪��
		Dim HINMTA_HINGRP As String '���i�}�X�^.���i�Q
		Dim HINMTA_JANCD As String '���i�}�X�^.JAN�R�[�h
		Dim HINMTA_KHNKB As String '���i�}�X�^.���{�敪
		Dim TOKJDNNO As String '�����ԍ�
		Dim TOKJDNED As String '�������׍s�ԍ�
		Dim ORD_HINCD As String '�������.���i�R�[�h
		Dim SIKRT_PER As String '�d�ؗ��p�[�Z���g
		Dim SIKSA_DSP As String '�d�؍��w�i
		Dim JANCD As String 'JAN�R�[�h
		'ADD START FKS)INABA 2007/02/15 *************************
		Dim TNACM As String
		'ADD  END  FKS)INABA 2007/02/15 *************************
	End Structure
	''================================================================================
	'���b�Z�[�W�R�[�h
	'�󒍓o�^
	Public Const gc_strMsgIDOET52_E_001 As String = "2IDOET52_001" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgIDOET52_E_002 As String = "2IDOET52_002" '�폜�ς݃��R�[�h�ł��B
	Public Const gc_strMsgIDOET52_E_003 As String = "2IDOET52_003" '���̃R�[�h�͎g�p�ł��܂���B
	Public Const gc_strMsgIDOET52_E_004 As String = "2IDOET52_004" '���̏��i�͕ێ�I���i�ł��B
	Public Const gc_strMsgIDOET52_E_005 As String = "2IDOET52_005" '���̏��i�͔̔������i�ł��B
	Public Const gc_strMsgIDOET52_E_006 As String = "2IDOET52_006" '���̏��i�͎󒍒�~�i�ł��B
	Public Const gc_strMsgIDOET52_W_007 As String = "2IDOET52_007" '���̏��i�͐��Y�I���i�ł��B
	Public Const gc_strMsgIDOET52_W_008 As String = "2IDOET52_008" '���̏��i�͏o�ג�~�i�ł��B
	Public Const gc_strMsgIDOET52_E_009 As String = "2IDOET52_009" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgIDOET52_E_011 As String = "2IDOET52_011" '���o���̓��͂��܂��̂��ߖ��׍s�̓��͂��ł��܂���B
	Public Const gc_strMsgIDOET52_E_013 As String = "2IDOET52_013" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgIDOET52_E_014 As String = "2IDOET52_014" '�`�[�̖��ו�����͂��ĉ������B
	Public Const gc_strMsgIDOET52_A_031 As String = "1IDOET52_031" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgIDOET52_A_032 As String = "1IDOET52_032" '���o�^�̂܂܏I�����Ă���낵���ł����H
	Public Const gc_strMsgIDOET52_E_034 As String = "2IDOET52_034" '�X�V�ُ�
	Public Const gc_strMsgIDOET52_E_036 As String = "2IDOET52_036" '���[���ōX�V���ł��B
	Public Const gc_strMsgIDOET52_A_037 As String = "1IDOET52_037" '�X�V���Ă�낵���ł����H
	Public Const gc_strMsgIDOET52_E_057 As String = "2IDOET52_057" '�o�ɗ��R�i�R�[�h�j����͂��ĉ������B
	Public Const gc_strMsgIDOET52_E_058 As String = "2IDOET52_058" '�q�ɃR�[�h����͂��ĉ������B
	Public Const gc_strMsgIDOET52_E_059 As String = "2IDOET52_059" '���Ԃ���͂��ĉ������B
	Public Const gc_strMsgIDOET52_E_060 As String = "2IDOET52_060" '���Ԃ̓��������s���ł��B
	Public Const gc_strMsgIDOET52_E_061 As String = "2IDOET52_061" '���Ԃ̕����񒷂��s���ł��B
	Public Const gc_strMsgIDOET52_E_062 As String = "2IDOET52_062" '���Ԃ����ԃ}�X�^�ɓo�^����Ă��܂���B
	Public Const gc_strMsgIDOET52_E_063 As String = "2IDOET52_063" '�L���݌ɐ����傫�Ȓl�͓��͂ł��܂���B
	Public Const gc_strMsgIDOET52_E_064 As String = "2IDOET52_064" '�݌ɊǗ��i�̂ݓ��͂ł��܂��B
	Public Const gc_strMsgIDOET52_E_065 As String = "2IDOET52_065" '�ً}�o�Ɏ��͑�֏o�ׂ�I���ł��܂���B
	Public Const gc_strMsgIDOET52_E_066 As String = "2IDOET52_066" '�������������Ă�������
	Public Const gc_strMsgIDOET52_E_067 As String = "2IDOET52_067" '�o�׎w�����������Ă�������
	Public Const gc_strMsgIDOET52_E_068 As String = "2IDOET52_068" '�o�ɒ����Ώۂ�I�����Ă�������
	Public Const gc_strMsgIDOET52_E_070 As String = "2IDOET52_070" '���Ԃ���p���ԃ}�X�^�ɓo�^����Ă��܂���B
	Public Const gc_strMsgIDOET52_E_071 As String = "2IDOET52_071" '���͂��ꂽ��p���Ԃ͓��͓K�p�͈͊O�ł�
	Public Const gc_strMsgIDOET52_E_072 As String = "2IDOET52_072" '���R���o�ɖ߂��p�̏ꍇ�̓}�C�i�X�œ��͂��Ă��������B
	Public Const gc_strMsgIDOET52_E_073 As String = "2IDOET52_073" '�Г��o�ɂƎЊO�o�ɂ̏��͓����ɓ��͂ł��܂���B
	Public Const gc_strMsgIDOET52_E_074 As String = "2IDOET52_074" '�ЊO�o�ɂ̏ꍇ�A���Ӑ�R�[�h�͕K�{�ł��B
	Public Const gc_strMsgIDOET52_E_075 As String = "2IDOET52_075" '�ЊO�o�ɂ̏ꍇ�A�[����Z���͕K�{�ł��B
	Public Const gc_strMsgIDOET52_E_076 As String = "2IDOET52_076" '�ЊO�o�ɂ̏ꍇ�A�֖��͕K�{�ł��B
	Public Const gc_strMsgIDOET52_E_077 As String = "2IDOET52_077" '�Г��o�ɂ̏ꍇ�A���t��S���҂͕K�{�ł��B
	Public Const gc_strMsgIDOET52_E_078 As String = "2IDOET52_078" '�Г��o�ɂ̏ꍇ�A���t�敔��͕K�{�ł��B
	Public Const gc_strMsgIDOET52_E_079 As String = "2IDOET52_079" '���R���o�ɗp�̏ꍇ�̓}�C�i�X�l����͂ł��܂���B
	Public Const gc_strMsgIDOET52_E_080 As String = "2IDOET52_080" '�߂����ʂ͎x���o�ɍϐ��ʂ�葽���͓��͂ł��܂���B
	Public Const gc_strMsgIDOET52_E_081 As String = "2IDOET52_081" '���i�}�X�^�ɑ��݂��܂���B
	
	Public Const gc_strMsgIDOET52_A_082 As String = "1IDOET52_082" '�������I�����܂����B
	Public Const gc_strMsgIDOET52_E_083 As String = "2IDOET52_083" '�����I�[�o�[�ł��B
	Public Const gc_strMsgIDOET52_E_084 As String = "2IDOET52_084" '�n�C�t�����̌��ł��B
	Public Const gc_strMsgIDOET52_E_085 As String = "2IDOET52_085" '�n�C�t�����擪�ɂ���܂��B
	Public Const gc_strMsgIDOET52_E_086 As String = "2IDOET52_086" '�n�C�t���������ɂ���܂��B
	Public Const gc_strMsgIDOET52_E_087 As String = "2IDOET52_087" '�n�C�t����A�����ē��͂��Ă��܂��B
	Public Const gc_strMsgIDOET52_E_088 As String = "2IDOET52_088" '���͂��s���ł��B
	Public Const gc_strMsgIDOET52_E_089 As String = "2IDOET52_089" '�n�C�t���̈ʒu������������܂���B
	Public Const gc_strMsgIDOET52_E_090 As String = "2IDOET52_090" '����������������܂���B
	Public Const gc_strMsgIDOET52_E_091 As String = "2IDOET52_091" '�X�֔ԍ�����͂��Ă��������B
	Public Const gc_strMsgIDOET52_E_092 As String = "2IDOET52_092" '�d�b�ԍ�����͂��Ă��������B
	
	Public Const gc_strMsgIDOET52_W_093 As String = "2IDOET52_093" '�o�׏������ł��B
	Public Const gc_strMsgIDOET52_W_094 As String = "2IDOET52_094" '�n�d�l�i�ł��B
	'ADD START FKS)INABA 2007/01/08*******************************************************************
	Public Const gc_strMsgIDOET52_W_095 As String = "2IDOET52_095" '�o�ɐ������݌ɐ��𒴂��Ă��܂��B
	Public Const gc_strMsgIDOET52_W_096 As String = "2IDOET52_096" '�o�ɐ����L���݌ɐ��𒴂��Ă��܂��B
	Public Const gc_strMsgIDOET52_W_097 As String = "2IDOET52_097" '���S�݌ɐ��������܂��B
	'ADD START FKS)INABA 2007/01/08*******************************************************************
	Public Const gc_strMsgUODET51_E_066 As String = "2UODET51_066" '�X�V����������܂���B
	Public Const gc_strMsgUODET52_E_080 As String = "2UODET52_080" '�ȉ��̏��������s���̂��߂��̉�ʂ͎g�p�ł��܂���B
	Public Const gc_strMsgUODET52_E_042 As String = "2UODET52_042" '�V�X�e���G���[
	
	Public Const gc_strMsgIDOET52_E_098 As String = "2IDOET52_098" '�o�ɍςݐ��ȉ��͎w��ł��܂���B
	'ADD START FKS)INABA 2007/02/15 ******************************************************************************
	Public Const gc_strMsgIDOET52_A_099 As String = "1IDOET52_099" '���͂����q�ɂƕW���q�ɂ��Ⴂ�܂����A��낵���ł����H
	Public Const gc_strMsgIDOET52_A_100 As String = "1IDOET52_100" '�W���q�ɂ�ݒ肵�܂����H
	Public Const gc_strMsgIDOET52_W_101 As String = "2IDOET52_101" '���͂����q�ɂƕW���q�ɂ��Ⴂ�܂��B�m�F���Ă��������B
	'ADD  END  FKS)INABA 2007/02/15 ******************************************************************************
	'ADD START FKS)INABA 2007/03/06 ******************************************************************************
	Public Const gc_strMsgIDOET52_A_102 As String = "1IDOET52_102" '������ꂽ���Ԃ��w�肵�Ă��܂����A��낵���ł����H
	'ADD  END  FKS)INABA 2007/03/06 ******************************************************************************
	'ADD STRAT FKS)INABA 2007/03/26 ******************************************************************************
	Public Const gc_strMsgIDOET52_E_103 As String = "2IDOET52_103" '���̑q�ɂ͗��p�ł��܂���B
	'ADD  END  FKS)INABA 2007/03/26 ******************************************************************************
	Public Const gc_strMsgIDOET52_E_010 As String = "2IDOET52_010" '���i�R�[�h����͂��Ă��������B
	Public Const gc_strMsgIDOET52_E_012 As String = "2IDOET52_012" '���ʂ���͂��Ă��������B
	Public Const gc_strMsgIDOET52_E_015 As String = "2IDOET52_015" '�ً}�o�׈ȊO�̓V���A���̓��͂͏o���܂���B
	
	Public Const gc_strMsgIDOET52_A_016 As String = "1IDOET52_016" '�V���A�����o�^����Ă��Ȃ����ׂ��L��܂��B
	'ADD START FKS)INABA 2007/12/14 ***************************************************************************************
	Public Const gc_strMsgIDOET52_E_016 As String = "2IDOET52_016" '�o�ɐ������݌ɐ��𒴂��Ă��܂��B
	Public Const gc_strMsgIDOET52_E_017 As String = "2IDOET52_017" '�o�ɐ����L���݌ɐ��𒴂��Ă��܂��B
	'ADD  END  FKS)INABA 2007/12/14 ***************************************************************************************
	'ADD START FKS)INABA 2008/01/23 ***************************************************************************************
	Public Const gc_strMsgIDOET52_E_018 As String = "2IDOET52_018" '�I�Ԃ̓o�^�ɉߕs�����L��܂��B�ēo�^���ĉ������B
	'ADD  END  FKS)INABA 2008/01/23 ***************************************************************************************
	
	'' �ȉ��g�p���m�F
	'DEL START FKS)INABA 2007/12/14 ***************************************************************************************
	'    Public Const gc_strMsgIDOET52_E_016         As String = "2IDOET52_016"  '���͂��ꂽ���t�͕����ғ����ł͂���܂���B
	'    Public Const gc_strMsgIDOET52_E_017         As String = "2IDOET52_017"  '���݂̕ҏW���e�͔j������܂��B��낵���ł����H
	'DEL  END  FKS)INABA 2007/12/14 ***************************************************************************************
	Public Const gc_strMsgIDOET52_E_019 As String = "2IDOET52_019" '���Ӑ���������Z�o�ł��܂���B
	Public Const gc_strMsgIDOET52_E_020 As String = "2IDOET52_020" '�Č������݂���ꍇ�͎󒍗��R����͂��ĉ������B
	Public Const gc_strMsgIDOET52_E_021 As String = "2IDOET52_021" '�ێ�̏ꍇ�͑O��敪����͂��Ă��������B
	Public Const gc_strMsgIDOET52_E_022 As String = "2IDOET52_022" '�ێ�̏ꍇ�͐����敪����͂��Ă��������B
	Public Const gc_strMsgIDOET52_E_023 As String = "2IDOET52_023" '���ɓ��͂���Ă��鐻�i�R�[�h�ł��B
	Public Const gc_strMsgIDOET52_E_024 As String = "2IDOET52_024" '�݌ɂ�����܂���B
	Public Const gc_strMsgIDOET52_E_025 As String = "2IDOET52_025" '�P���擾���ł��܂���ł����B
	Public Const gc_strMsgIDOET52_W_026 As String = "2IDOET52_026" '�������ꂵ�܂�
	Public Const gc_strMsgIDOET52_E_027 As String = "2IDOET52_027" '�{�̍��v���z���󒍉\�z�𒴂��Ă��܂��B
	Public Const gc_strMsgIDOET52_E_028 As String = "2IDOET52_028" '�{�̍��v���z�����׋��z�ƈ�v���܂���B
	Public Const gc_strMsgIDOET52_E_029 As String = "2IDOET52_029" '���͂��ꂽ���t�̓J�����_�ɓo�^����Ă��܂���B
	Public Const gc_strMsgIDOET52_E_030 As String = "2IDOET52_030" 'CLOSE���ꂽ�Č����ł��B
	Public Const gc_strMsgIDOET52_E_033 As String = "2IDOET52_033" 'Ini�t�@�C����CRM�A�g�p�̃p�X���ݒ肳��Ă��܂���B
	Public Const gc_strMsgIDOET52_E_035 As String = "2IDOET52_035" '�d�ؗ���W����艺����ꍇ�͓����̐ݒ肪�K�v�ł��B
	Public Const gc_strMsgIDOET52_E_038 As String = "2IDOET52_038" '�{�̍��v���z���󒍉\�z�𒴂��Ă��܂��B
	Public Const gc_strMsgIDOET52_E_039 As String = "2IDOET52_039" '���t�Ɍ�肪����܂��B�C�����Ă��������B
	Public Const gc_strMsgIDOET52_E_040 As String = "2IDOET52_040" '�Q�Ƃ����Ő��ȊO�ɉ��������s���Ă��܂��B
	Public Const gc_strMsgIDOET52_E_041 As String = "2IDOET52_041" '���͂��ꂽ�Č�ID�͊��Ɏ󒍓��͂��s���Ă��܂��B
	Public Const gc_strMsgIDOET52_E_042 As String = "2IDOET52_042" '�Q�Ƃ��ꂽ�Ő��ȊO�̌��ςɉ��������s���Ă��܂��B
	Public Const gc_strMsgIDOET52_E_043 As String = "2IDOET52_043" '�o�ח\�������͂��ĉ������B
	Public Const gc_strMsgIDOET52_W_044 As String = "2IDOET52_044" '���ʂ�����󒍐��𒴂��Ă��܂��B
	Public Const gc_strMsgIDOET52_E_045 As String = "2IDOET52_045" '���̓��Ӑ�͊C�O�����ł��B
	Public Const gc_strMsgIDOET52_E_046 As String = "2IDOET52_046" '�[����R�[�h����͂��ĉ������B
	Public Const gc_strMsgIDOET52_W_047 As String = "2IDOET52_047" '�����̓��Ӑ�ł��B
	Public Const gc_strMsgIDOET52_E_048 As String = "2IDOET52_048" '�����̓��Ӑ�͎󒍂ł��܂���B
	Public Const gc_strMsgIDOET52_W_049 As String = "2IDOET52_049" '���o�^���ꂽ���i�����ׂɑ��݂��܂��B
	Public Const gc_strMsgIDOET52_E_050 As String = "2IDOET52_050" '���o�^���ꂽ���i�̎󒍓o�^�͍s���܂���B
	Public Const gc_strMsgIDOET52_E_051 As String = "2IDOET52_051" '���͂��ꂽ���t�͉c�Ɠ��ł͂���܂���B
	Public Const gc_strMsgIDOET52_E_052 As String = "2IDOET52_052" '�������������߂��Ă��܂��B
	Public Const gc_strMsgIDOET52_E_053 As String = "2IDOET52_053" '�o�^���ꂽ���Ӑ�̐����������߂��Ă��܂��B
	Public Const gc_strMsgIDOET52_E_054 As String = "2IDOET52_054" '�V�X�e����Z�b�g�A�b�v�̌��ς͎Q�Ƃł��܂���
	Public Const gc_strMsgIDOET52_E_055 As String = "2IDOET52_055" 'CRM�A�ģ�ق͑�հ�ް�Ŏg�p���̂��ߏ������߂܂���B
	Public Const gc_strMsgIDOET52_E_056 As String = "2IDOET52_056" '���̎󒍂Ŋ��ɎQ�Ƃ��ꂽ���Ϗ��ł��B
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module