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
		Dim IsDataRow As Boolean '�f�[�^�ێ��s�t���O
		Dim SYBT As Short '���(3:�x���i,4:���ԏo��)
		Dim SBNNO As String '����
		Dim HINCD As String '���i�R�[�h
		Dim HINNMA As String '�^��
		Dim HINNMB As String '���i���P
		Dim ODNYTDT As String '�o�ח\���
		Dim OUTYTSU As Decimal '�o�ח\�萔��
		Dim ORGSBNNO As String '������
		Dim OUTRSNCD As String '�o�ɗ��R�R�[�h
		Dim OUTRSNNM As String '�o�ɗ��R��
		Dim TOKCD As String '���Ӑ�R�[�h
		Dim TOKRN As String '���Ӑ旪��
		Dim SIRCD As String '�d����R�[�h
		Dim SIRRN As String '�d���旪��
		Dim WRTFSTDT As String '�o�^��
		Dim WRTFSTTM As String '�o�^����
		Dim SOUCD As String '�q�ɃR�[�h
		Dim SOUNM As String '�q�ɖ�
		Dim DATNO As String '�`�[�Ǘ���
		Dim SPRRENNO As String '�����A��
		Dim PUDLNO As String '���o�ɔԍ�
		' === 20080725 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		Dim OUTBMCD As String '����敔��R�[�h
		Dim OUTTANCD As String '�����S���҃R�[�h
		Dim NHSCD As String '�[����R�[�h
		' === 20080725 === INSERT E -
		'''���Ԉ����^�ʉ�����ʗp
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
		Dim SUB_HIKSU_BEF As Decimal '�O����͈����ϐ�
		Dim SUB_MNSU As Decimal '�蓮������
		' === 20080720 === INSERT S - ACE)Nagasawa �����������s���͉��������s�������ς̉��ł͍s���Ȃ�
		Dim SUB_FRDSU As Decimal '�o�׎w����
		' === 20080720 === INSERT E -
		' === 20080725 === INSERT S - RISE)Izumi
		Dim SUB_OPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim SUB_CLTID As String ' �N���C�A���g�h�c
		Dim SUB_WRTTM As String ' �^�C���X�^���v�i���ԁj
		Dim SUB_WRTDT As String ' �^�C���X�^���v�i���t�j
		Dim SUB_UOPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim SUB_UCLTID As String ' �N���C�A���g�h�c
		Dim SUB_UWRTTM As String ' �^�C���X�^���v�i�o�b�`���ԁj
		Dim SUB_UWRTDT As String ' �^�C���X�^���v�i�o�b�`���j
		' === 20080725 === INSERT E -
	End Structure
	''================================================================================
	'���Ԉ�������,�݌Ɉ����^����
	Public Const gc_strMsgHIKET54_A_001 As String = "1HIKET54_001" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgHIKET54_E_002 As String = "2HIKET54_002" '������������͂��Ă��������B
	Public Const gc_strMsgHIKET54_E_003 As String = "2HIKET54_003" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgHIKET54_E_004 As String = "2HIKET54_004" '�폜�ς݃��R�[�h�ł��B
	Public Const gc_strMsgHIKET54_E_005 As String = "2HIKET54_005" '�݌ɊǗ��ΏۊO�ł��B
	Public Const gc_strMsgHIKET54_E_006 As String = "2HIKET54_006" '�������̓}�C�i�X���͂ł��܂���B
	Public Const gc_strMsgHIKET54_E_007 As String = "2HIKET54_007" '�������������\���𒴂��Ă��܂��B
	Public Const gc_strMsgHIKET54_E_008 As String = "2HIKET54_008" '���������v���`�[���ʂ𒴂��Ă��܂��B
	Public Const gc_strMsgHIKET54_E_009 As String = "2HIKET54_009" '�Ώۂ̖��ׂ����݂��܂���B
	Public Const gc_strMsgHIKET54_E_010 As String = "2HIKET54_010" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgHIKET54_E_011 As String = "2HIKET54_011" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgHIKET54_E_012 As String = "2HIKET54_012" '�X�V�ُ�
	Public Const gc_strMsgHIKET54_A_013 As String = "1HIKET54_013" '���o�^�̂܂܏I�����Ă���낵���ł����H
	Public Const gc_strMsgHIKET54_A_014 As String = "1HIKET54_014" '�X�V���Ă�낵���ł����H
	Public Const gc_strMsgHIKET54_E_015 As String = "2HIKET54_015" '���������`�[���ʂ𒴂��Ă��܂��B
	Public Const gc_strMsgHIKET54_A_017 As String = "1HIKET54_017" '�������I�����܂����B
	Public Const gc_strMsgHIKET54_E_018 As String = "2HIKET54_018" '�����s���ł��B���΂炭���Ď��s���Ă��������B
	Public Const gc_strMsgHIKET54_E_019 As String = "2HIKET54_019" '�X�V����������܂���B
	Public Const gc_strMsgHIKET54_E_020 As String = "2HIKET54_020" '�����̑ΏۂƂȂ閾�ׂ����݂��܂���B
	' === 20080729 === INSERT S - RISE)Izumi
	Public Const gc_strMsgHIKET54_E_901 As String = "2HIKET54_901" '���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
	Public Const gc_strMsgHIKET54_E_902 As String = "2HIKET54_902" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgHIKET54_E_903 As String = "2HIKET54_903" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	' === 20080729 === INSERT E -
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
	Public Structure Cls_HIKET54_Interface
		Dim Mode As Short '�`�[��ʁi3:�x���i���/4:���ԏo�ɏ��j
		Dim DATNO As String '�`�[�Ǘ���
		Dim ODNYTDT As String '�o�ח\���
		Dim SPRRENNO As String '�����A��
		Dim SBNNO As String '����
		Dim HINCD As String '���i�R�[�h
		Dim HINNMA As String '�^��
		Dim HINNMB As String '���i���P
		Dim UODSU As Decimal '�󒍐���
		Dim TOKCD As String '���Ӑ�R�[�h
		Dim SOUCD As String '�q�ɃR�[�h
		Dim PUDLNO As String '���o�ɔԍ�
		' === 20080725 === INSERT S - ACE)Nagasawa ��������t�@�C���̈������ɂ͏o�׎w�������܂ނ悤�C��
		Dim OUTBMCD As String '����敔��R�[�h
		Dim OUTTANCD As String '�����S���҃R�[�h
		Dim NHSCD As String '�[����R�[�h
		' === 20080725 === INSERT E -
		' === 20080725 === INSERT S - RISE)Izumi
		Dim OPEID As String '�ŏI��Ǝ҃R�[�h
		Dim CLTID As String '�N���C�A���g�h�c
		Dim WRTTM As String '�^�C���X�^���v�i���ԁj
		Dim WRTDT As String '�^�C���X�^���v�i���t�j
		Dim UOPEID As String '�ŏI��Ǝ҃R�[�h
		Dim UCLTID As String '�N���C�A���g�h�c
		Dim UWRTTM As String '�^�C���X�^���v�i�o�b�`���ԁj
		Dim UWRTDT As String '�^�C���X�^���v�i�o�b�`���j
		' === 20080725 === INSERT E -
	End Structure
	Public HIKET54_Interface As Cls_HIKET54_Interface
End Module