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
		'    SELECTED        As Boolean          '�I��/��I��
		'    SELECTB         As Variant
		Dim IsDataRow As Boolean '�f�[�^�ێ��s�t���O
		Dim LINNO As String '�s�ԍ�
		Dim HINCD As String '���i�R�[�h
		Dim HINNMA As String '�^��
		Dim HINNMB As String '���i���P
		Dim UODSU As Decimal '�󒍐���
		Dim UNTNM As String '�P�ʖ�
		Dim UODTK As Decimal '�󒍒P��
		Dim UODKN As Decimal '�󒍋��z
		Dim SIKTK As Decimal '�c�Ǝd�ؒP��
		Dim TEIKATK As Decimal '�艿
		Dim SIKRT As Decimal '�d�ؗ�
		Dim LINCMA As String '���ה��l�P
		Dim LINCMB As String '���ה��l�Q
		Dim ODNYTDT As String '�o�ח\���
		Dim GNKCD As String '�����Ǘ��R�[�h
		Dim TOKJDNNO As String '�q�撍��No.
		Dim PUDLNO As String '���o�ɔԍ�
		'20080725 ADD START RISE)Tanimura '�r������
		Dim OPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim CLTID As String ' �N���C�A���g�h�c
		Dim WRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim WRTDT As String ' �^�C���X�^���v�i�o�b�`���j
		Dim UOPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim UCLTID As String ' �N���C�A���g�h�c
		Dim UWRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim UWRTDT As String ' �^�C���X�^���v�i�o�b�`���j
		'20080725 ADD END   RISE)Tanimura
		'''�݌Ɉ����^�ʉ�����ʗp
		Dim SUB_IsDataRow As Boolean '�f�[�^�ێ��s�t���O
		Dim SUB_KB As String '�f�[�^�敪(1:�q�ɕʍ݌� 2:���ח\��)
		Dim SUB_SOUCD As String '�q�ɃR�[�h
		Dim SUB_HINCD As String '���i�R�[�h
		Dim SUB_SISNKB As String '���Y���敪
		Dim SUB_SOUTRICD As String '�����R�[�h
		Dim SUB_SOUKOKB As String '�q�ɋ敪
		Dim SUB_SOUNM As String '�q�ɖ�
		Dim SUB_LOTNO As String '���b�g�ԍ�
		Dim SUB_NYUYTDT As String '���ɗ\���
		Dim SUB_RELZAISU As Decimal '���݌ɐ�
		Dim SUB_ZUMISU As Decimal '�����ϐ�
		Dim SUB_HIKSU As Decimal '�����\��
		Dim SUB_INP_HIKSU As Decimal '������
		Dim SUB_MOTO_HIKSU As Decimal '������(�X�V�O�̒l)
		' === 20060109 === INSERT S - ACE)Nagasawa
		Dim SUB_HIKSU_BEF As Decimal '�O����͈����ϐ�
		' === 20060109 === INSERT E -
		' === 20070205 === INSERT S - ACE)Yano
		Dim SUB_MNSU As Decimal '�蓮������
		' === 20070205 === INSERT E -
		' === 20080715 === INSERT S - ACE)Nagasawa �����������s���͉��������s�������ς̉��ł͍s���Ȃ�
		Dim SUB_FRDSU As Decimal '�o�׎w����
		' === 20080715 === INSERT E -
		'20080725 ADD START RISE)Tanimura '�r������
		Dim SUB_OPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim SUB_CLTID As String ' �N���C�A���g�h�c
		Dim SUB_WRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim SUB_WRTDT As String ' �^�C���X�^���v�i�o�b�`���j
		Dim SUB_UOPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim SUB_UCLTID As String ' �N���C�A���g�h�c
		Dim SUB_UWRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim SUB_UWRTDT As String ' �^�C���X�^���v�i�o�b�`���j
		'20080725 ADD END   RISE)Tanimura
	End Structure
	''================================================================================
	'�݌Ɉ�������,�݌Ɉ����^����
	Public Const gc_strMsgHIKET51_A_001 As String = "1HIKET51_001" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgHIKET51_E_002 As String = "2HIKET51_002" '������������͂��Ă��������B
	Public Const gc_strMsgHIKET51_E_003 As String = "2HIKET51_003" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgHIKET51_E_004 As String = "2HIKET51_004" '���ό������́A���ϔԍ��E�Ő��Ƃ��ɕK�{�ł��B
	Public Const gc_strMsgHIKET51_E_005 As String = "2HIKET51_005" '���ϔԍ��A�󒍔ԍ������ꂩ����̂ݓ��͂��ĉ������B
	Public Const gc_strMsgHIKET51_E_006 As String = "2HIKET51_006" '�������̓}�C�i�X���͂ł��܂���B
	Public Const gc_strMsgHIKET51_E_007 As String = "2HIKET51_007" '�������������\���𒴂��Ă��܂��B
	Public Const gc_strMsgHIKET51_E_008 As String = "2HIKET51_008" '���������v���`�[���ʂ𒴂��Ă��܂��B
	Public Const gc_strMsgHIKET51_E_009 As String = "2HIKET51_009" '�Ώۂ̖��ׂ����݂��܂���B
	Public Const gc_strMsgHIKET51_E_010 As String = "2HIKET51_010" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgHIKET51_E_011 As String = "2HIKET51_011" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgHIKET51_E_012 As String = "2HIKET51_012" '�X�V�ُ�
	Public Const gc_strMsgHIKET51_A_013 As String = "1HIKET51_013" '���o�^�̂܂܏I�����Ă���낵���ł����H
	Public Const gc_strMsgHIKET51_A_014 As String = "1HIKET51_014" '�X�V���Ă�낵���ł����H
	' === 20060818 === INSERT S - ACE)Nagasawa
	Public Const gc_strMsgHIKET51_E_015 As String = "2HIKET51_015" '���������`�[���ʂ𒴂��Ă��܂��B
	' === 20060818 === INSERT E -
	' === 20060908 === INSERT S - ACE)Sejima ���Ɏ󒍂ƂȂ��Ă��錩��
	Public Const gc_strMsgHIKET51_E_016 As String = "2HIKET51_016" '���Ɏ󒍂ƂȂ��Ă��錩�ςł��B
	' === 20060908 === INSERT E
	' === 20060926 === INSERT S - ACE)Nagasawa �����I�����b�Z�[�W�ǉ�
	Public Const gc_strMsgHIKET51_A_017 As String = "1HIKET51_017" '�������I�����܂����B
	' === 20060926 === INSERT E -
	' === 20061105 === INSERT S - ACE)Nagasawa �r������̒ǉ�
	Public Const gc_strMsgHIKET51_E_018 As String = "2HIKET51_018" '�����s���ł��B���΂炭���Ď��s���Ă��������B
	' === 20061105 === INSERT E -
	' === 20061129 === INSERT S - ACE)Nagasawa �X�V�����`�F�b�N��ύX����
	Public Const gc_strMsgHIKET51_E_019 As String = "2HIKET51_019" '�X�V����������܂���B
	' === 20061129 === INSERT E -
	' === 20061129 === INSERT S - ACE)Nagasawa �X�V�����`�F�b�N��ύX����
	Public Const gc_strMsgHIKET51_E_020 As String = "2HIKET51_020" '�����̑ΏۂƂȂ閾�ׂ����݂��܂���B
	' === 20061129 === INSERT E -
	'2014/02/26 START ADD FWEST)Koroyasu ����Ŗ@�����Ή�
	Public Const gc_strMsgHIKET51_E_021 As String = "2HIKET51_021" '���݂̓K�p�ŗ��̎󒍂łȂ����߁A�����ł��܂���B
	'2014/02/26 END ADD FWEST)Koroyasu ����Ŗ@�����Ή�
	'2014/03/04 START ADD FWEST)Koroyasu HAN20131203-01
	Public Const gc_strMsgHIKET51_E_022 As String = "2HIKET51_022" '�W���q�ɂ̏ꏊ��SSC�ł��邽�߁A�����ł��܂���B
	'2014/03/04 END ADD FWEST)Koroyasu HAN20131203-01
	'20080725 ADD START RISE)Tanimura '�r������
	Public Const gc_strMsgHIKET51_E_901 As String = "2HIKET51_901" '���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
	'20080725 ADD END   RISE)Tanimura
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
	Public Structure Cls_HIKET51_Interface
		Dim Mode As Short '�`�[��ʁi1:���Ϗ��/2:�󒍏��j
		Dim DATNO As String '�`�[�Ǘ���
		Dim DENNO1 As String '�`�[�ԍ��P
		Dim DENNO2 As String '�`�[�ԍ��Q
		Dim TANNM As String '�S���Җ�
		Dim LINNO As String '�s�ԍ�
		Dim PUDLNO As String '���o�ɔԍ�
		Dim HINCD As String '���i�R�[�h
		Dim HINNMA As String '�^��
		Dim HINNMB As String '���i���P
		Dim UODSU As Decimal '�󒍐���
		Dim TOKCD As String '���Ӑ�R�[�h
		Dim JDNTRKB As String '�󒍎���敪
		Dim SOUCD As String '�q�ɃR�[�h
		Dim ODNYTDT As String '�o�ח\���
		' === 20071230 === INSERT S - ACE)Yano
		Dim JDNINKB As String '�󒍎捞���
		' === 20071230 === INSERT E -
		'20080725 ADD START RISE)Tanimura '�r������
		Dim OPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim CLTID As String ' �N���C�A���g�h�c
		Dim WRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim WRTDT As String ' �^�C���X�^���v�i�o�b�`���j
		Dim UOPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim UCLTID As String ' �N���C�A���g�h�c
		Dim UWRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim UWRTDT As String ' �^�C���X�^���v�i�o�b�`���j
		'20080725 ADD END   RISE)Tanimura
	End Structure
	Public HIKET51_Interface As Cls_HIKET51_Interface
End Module