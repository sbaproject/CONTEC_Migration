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
		Dim UPDKB As String '���[�h
		Dim DATKB As String '�`�[�폜�敪
		Dim KNGGRCD As String '�����O���[�v
		Dim PGID As String '�v���O�����h�c
		Dim MEINMA As String '�v���O������
		Dim UPDFLG As String '�X�V�����ύX�\�t���O
		Dim UPDAUTH As String '�X�V����
		Dim PRTFLG As String '��������ύX�\�t���O
		Dim PRTAUTH As String '�������
		Dim FILEFLG As String '�t�@�C���o�͌����ύX�\�t���O
		Dim FILEAUTH As String '�t�@�C���o�͌���
		Dim SALTFLG As String '�̔��P���ύX�����ύX�\�t���O
		Dim SALTAUTH As String '�̔��P���ύX����
		Dim HDNTFLG As String '�����P���ύX�����ύX�\�t���O
		Dim HDNTAUTH As String '�����P���ύX����
		Dim SAPMFLG As String '�̔��v��N���v��C�������ύX�\�t���O
		Dim SAPMAUTH As String '�̔��v��N���v��C������
		' 2006/11/15  ADD START  KUMEDA
		Dim UPDATE As String '�X�V�t���O
		' 2006/11/15  ADD END
		'2007/12/18 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
		Dim MOTO_WRTDT As String '�X�V���t
		Dim MOTO_WRTTM As String '�X�V����
		Dim MOTO_UWRTDT As String '�o�b�`�X�V���t
		Dim MOTO_UWRTTM As String '�o�b�`�X�V����
		'2007/12/18 add-end M.SUEZAWA
		' === 20080902 === INSERT S - RISE)Izumi
		Dim MOTO_OPEID As String '�ŏI��Ǝ҃R�[�h
		Dim MOTO_CLTID As String '�N���C�A���g�h�c
		Dim MOTO_UOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim MOTO_UCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
		' === 20080902 === INSERT E - RISE)Izumi
	End Structure
	
	''================================================================================
	'���b�Z�[�W�R�[�h
	'�����o�^
	Public Const gc_strMsgKNGMT51_E_001 As String = "2KNGMT51_001" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgKNGMT51_E_002 As String = "2KNGMT51_002" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgKNGMT51_E_003 As String = "2KNGMT51_003" '�폜�ς݃��R�[�h�ł��B
	Public Const gc_strMsgKNGMT51_E_004 As String = "2KNGMT51_004" '���̃R�[�h�͎g�p�ł��܂���B
	Public Const gc_strMsgKNGMT51_E_005 As String = "2KNGMT51_005" '���׍s�ɓo�^����f�[�^������܂���B
	Public Const gc_strMsgKNGMT51_A_006 As String = "1KNGMT51_006" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgKNGMT51_E_007 As String = "2KNGMT51_007" '�����O���[�v�͕K�{���͍��ڂł��B
	Public Const gc_strMsgKNGMT51_A_008 As String = "1KNGMT51_008" '�X�V���Ă�낵���ł����H
	Public Const gc_strMsgKNGMT51_E_009 As String = "2KNGMT51_009" '�������I�����܂����
	Public Const gc_strMsgKNGMT51_E_010 As String = "2KNGMT51_010" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgKNGMT51_E_011 As String = "2KNGMT51_011" '�V�X�e���G���[
	Public Const gc_strMsgKNGMT51_A_012 As String = "1KNGMT51_012" '���o�^�̃f�[�^�����݂��܂��B�X�V���s���܂��B
	Public Const gc_strMsgKNGMT51_A_013 As String = "1KNGMT51_013" '���o�^�̂܂܏I�����Ă���낵���ł����H
	Public Const gc_strMsgKNGMT51_A_014 As String = "1KNGMT51_014" '���݂̕ҏW���e�͔j������܂��B��낵���ł����H
	Public Const gc_strMsgKNGMT51_E_015 As String = "2KNGMT51_015" '����ȍ~�̃f�[�^�͂���܂���B
	Public Const gc_strMsgKNGMT51_E_016 As String = "2KNGMT51_016" '�X�V����������܂���B
	'2007/12/18 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
	Public Const gc_strMsgKNGMT51_E_017 As String = "2KNGMT51_017" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	''    Public Const gc_strMsgKNGMT51_E_018         As String = "2KNGMT51_018"      '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'2007/12/18 add-end M.SUEZAWA
	'ADD START FKS)INABA 2009/10/08 ************************************************************************************************
	'�A���[��FC09101403
	Public Const gc_strMsgKNGMT51_E_020 As String = "2KNGMT51_020" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgKNGMT51_E_021 As String = "1KNGMT51_021" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	'ADD  END  FKS)INABA 2009/10/08 ************************************************************************************************
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module