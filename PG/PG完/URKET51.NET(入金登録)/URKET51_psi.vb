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
		Dim DKBID As String
		Dim DKBNM As String
		Dim KANKOZ As String
		Dim NYUKN As Decimal
		Dim FNYUKN As Double
		Dim BNKCD As String
		Dim BNKNM As String
		Dim JDNNO As String
		Dim JDNLINNO As String
		Dim STNNM As String
		Dim TEGDT As String
		Dim TEGNO As String
		Dim LINCMA As String
		Dim LINCMB As String
		Dim SYSTBD As TYPE_DB_SYSTBD
	End Structure
	
	''================================================================================
	'���b�Z�[�W�R�[�h
	'�����o�^
	Public Const gc_strMsgURKET51_A_001 As String = "1URKET51_001" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgURKET51_A_002 As String = "1URKET51_002" '���o�^�̂܂܏I�����Ă���낵���ł����H
	Public Const gc_strMsgURKET51_E_003 As String = "2URKET51_003" '�X�V����������܂���B
	Public Const gc_strMsgURKET51_E_004 As String = "2URKET51_004" '�X�V�ُ�
	Public Const gc_strMsgURKET51_A_005 As String = "1URKET51_005" '�X�V���Ă�낵���ł����H
	Public Const gc_strMsgURKET51_A_006 As String = "1URKET51_006" '�������I�����܂����B
	Public Const gc_strMsgURKET51_E_007 As String = "2URKET51_007" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgURKET51_E_008 As String = "2URKET51_008" '���t�Ɍ�肪����܂��B�C�����Ă��������B
	Public Const gc_strMsgURKET51_E_009 As String = "2URKET51_009" '�폜�ς݃��R�[�h�ł��B
	Public Const gc_strMsgURKET51_E_010 As String = "2URKET51_010" '���̃R�[�h�͎g�p�ł��܂���B
	Public Const gc_strMsgURKET51_E_011 As String = "2URKET51_011" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgURKET51_E_012 As String = "2URKET51_012" '�`�[�̖��ו�����͂��ĉ������B
	Public Const gc_strMsgURKET51_E_013 As String = "2URKET51_013" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgURKET51_E_014 As String = "2URKET51_014" '���o���̓��͂��܂��̂��ߖ��׍s�̓��͂��ł��܂���B
	Public Const gc_strMsgURKET51_E_015 As String = "2URKET51_015" '�^�p���ȍ~�͓��͂ł��܂���B
	Public Const gc_strMsgURKET51_E_016 As String = "2URKET51_016" '�����X�V�ς݂ł��B���̓��t�ł͓��͂ł��܂���B
	Public Const gc_strMsgURKET51_E_017 As String = "2URKET51_017" '�}�X�^�o�^���e�Ɠ�����ʂ��قȂ�܂��B
	Public Const gc_strMsgURKET51_E_018 As String = "2URKET51_018" '���ׂɂ́A��`�̓��͂��K�v�ł��B
	Public Const gc_strMsgURKET51_E_019 As String = "2URKET51_019" '�U���̏ꍇ�A��s�R�[�h����͂��Ă��������B
	Public Const gc_strMsgURKET51_E_020 As String = "2URKET51_020" '��`�̏ꍇ�A��s�R�[�h����͂��Ă��������B
	Public Const gc_strMsgURKET51_E_021 As String = "2URKET51_021" '��`�̏ꍇ�A���ϓ�����͂��Ă��������B
	Public Const gc_strMsgURKET51_E_022 As String = "2URKET51_022" '��`�̏ꍇ�A��`�ԍ�����͂��Ă��������B
	Public Const gc_strMsgURKET51_E_023 As String = "2URKET51_023" '��`�̏ꍇ�A��`�x�����z�ȏ����͂��Ă��������B
	Public Const gc_strMsgURKET51_E_024 As String = "2URKET51_024" '�o�[�`�������������Ӑ�ɑ��݂��܂���B
	Public Const gc_strMsgURKET51_E_025 As String = "2URKET51_025" '������ł͂���܂���B
	Public Const gc_strMsgURKET51_E_026 As String = "2URKET51_026" '���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
	Public Const gc_strMsgURKET51_E_027 As String = "2URKET51_027" '���Ӑ���������Z�o�ł��܂���B
	'2009/06/08 ADD START FKS)NAKATA
	Public Const gc_strMsgURKET51_E_028 As String = "2URKET51_028" '�󒍋��z�������Ă��܂��B
	Public Const gc_strMsgURKET51_E_029 As String = "2URKET51_029" '�󒍋��z��������Ă��܂��B
	'2009/06/08 ADD E.N.D FKS)NAKATA
	'2009/09/03 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET51_E_030 As String = "2URKET51_030" '���������ȑO�ł��B���̓��t�ł͓��͂ł��܂���B
	Public Const gc_strMsgURKET51_E_031 As String = "2URKET51_031" '������S���҂��c�Ƃł���܂���B
	'2009/09/03 ADD E.N.D RISE)MIYAJIMA
	'2009/09/07 ADD START FKS)NAKATA
	Public Const gc_strMsgURKET51_E_032 As String = "2URKET51_032" '�[���ς̓����ł��B�X�V�ł��܂���B
	'2009/09/07 ADD E.N.D FKS)NAKATA
	'2009/09/23 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET51_E_033 As String = "2URKET51_033" '�g�p�ł��Ȃ�������ʂł��B
	'2009/09/23 ADD E.N.D RISE)MIYAJIMA
	'2009/09/24 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET51_E_034 As String = "2URKET51_034" '�ύX���z�������z�𒴂��Ă��܂��B
	'2009/09/24 ADD E.N.D RISE)MIYAJIMA
	'2009/11/10 ADD START FKS)YAMAMOTO
	Public Const gc_strMsgURKET51_E_035 As String = "2URKET51_035" '�󒍓`�[���t������������̎󒍂͓��͂ł��܂���B
	'2009/11/10 ADD E.N.D FKS)YAMAMOTO
	'2009/12/28 ADD START FKS)YAMAMOTO
	Public Const gc_strMsgURKET51_E_036 As String = "2URKET51_036" '��������̎�ʂ���`�ł͂���܂���B
	Public Const gc_strMsgURKET51_E_037 As String = "2URKET51_037" '��`�̊���������w�肳��Ă��܂��B
	'2009/12/28 ADD E.N.D FKS)YAMAMOTO
	'''' ADD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
	Public Const gc_strMsgURKET51_E_038 As String = "2URKET51_038" '���߂��ׂ��ł̓��t�͓��͂ł��܂���
	'''' ADD 2011/01/14  FKS) T.Yamamoto    End
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module