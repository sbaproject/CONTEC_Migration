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
		'2009/06/05 ADD START FKS)NAKATA
		Dim OKRJONO As String
		'2009/06/05 ADD E.N.D FKS)NAKATA
		'2009/09/30 ADD START RISE)MIYAJIMA
		Dim DATNO As String
		Dim LINNO As String
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		Dim SYSTBD As TYPE_DB_SYSTBD
	End Structure
	
	''================================================================================
	'���b�Z�[�W�R�[�h
	'��������
	Public Const gc_strMsgURKET52_A_001 As String = "1URKET52_001" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgURKET52_A_002 As String = "1URKET52_002" '���o�^�̂܂܏I�����Ă���낵���ł����H
	Public Const gc_strMsgURKET52_E_003 As String = "2URKET52_003" '�X�V����������܂���B
	Public Const gc_strMsgURKET52_E_004 As String = "2URKET52_004" '�X�V�ُ�
	Public Const gc_strMsgURKET52_A_005 As String = "1URKET52_005" '�X�V���Ă�낵���ł����H
	Public Const gc_strMsgURKET52_A_006 As String = "1URKET52_006" '�������I�����܂����B
	Public Const gc_strMsgURKET52_E_007 As String = "2URKET52_007" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgURKET52_E_008 As String = "2URKET52_008" '���t�Ɍ�肪����܂��B�C�����Ă��������B
	Public Const gc_strMsgURKET52_E_009 As String = "2URKET52_009" '�폜�ς݃��R�[�h�ł��B
	Public Const gc_strMsgURKET52_E_010 As String = "2URKET52_010" '���̃R�[�h�͎g�p�ł��܂���B
	Public Const gc_strMsgURKET52_E_011 As String = "2URKET52_011" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgURKET52_E_012 As String = "2URKET52_012" '�`�[�̖��ו�����͂��ĉ������B
	Public Const gc_strMsgURKET52_E_013 As String = "2URKET52_013" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgURKET52_E_014 As String = "2URKET52_014" '���o���̓��͂��܂��̂��ߖ��׍s�̓��͂��ł��܂���B
	Public Const gc_strMsgURKET52_E_015 As String = "2URKET52_015" '�^�p���ȍ~�͓��͂ł��܂���B
	Public Const gc_strMsgURKET52_E_016 As String = "2URKET52_016" '�����X�V�ς݂ł��B���̓��t�ł͓��͂ł��܂���B
	Public Const gc_strMsgURKET52_E_017 As String = "2URKET52_017" '�}�X�^�o�^���e�Ɠ�����ʂ��قȂ�܂��B
	Public Const gc_strMsgURKET52_E_018 As String = "2URKET52_018" '���ׂɂ́A��`�̓��͂��K�v�ł��B
	Public Const gc_strMsgURKET52_E_019 As String = "2URKET52_019" '�U���̏ꍇ�A��s�R�[�h����͂��Ă��������B
	Public Const gc_strMsgURKET52_E_020 As String = "2URKET52_020" '��`�̏ꍇ�A��s�R�[�h����͂��Ă��������B
	Public Const gc_strMsgURKET52_E_021 As String = "2URKET52_021" '��`�̏ꍇ�A���ϓ�����͂��Ă��������B
	Public Const gc_strMsgURKET52_E_022 As String = "2URKET52_022" '��`�̏ꍇ�A��`�ԍ�����͂��Ă��������B
	Public Const gc_strMsgURKET52_E_023 As String = "2URKET52_023" '��`�̏ꍇ�A��`�x�����z�ȏ����͂��Ă��������B
	Public Const gc_strMsgURKET52_E_024 As String = "2URKET52_024" '�������������I�����Ă��������B
	Public Const gc_strMsgURKET52_E_025 As String = "2URKET52_025" '������ł͂���܂���B
	Public Const gc_strMsgURKET52_E_026 As String = "2URKET52_026" '���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
	Public Const gc_strMsgURKET52_E_027 As String = "2URKET52_027" '���Ӑ���������Z�o�ł��܂���B
	Public Const gc_strMsgURKET52_A_028 As String = "1URKET52_028" '�폜���Ă�낵���ł����H
	Public Const gc_strMsgURKET52_E_029 As String = "2URKET52_029" '�ύX���z�������z�𒴂��Ă��܂��B
	'// V1.10�� ADD
	Public Const gc_strMsgURKET52_E_030 As String = "2URKET52_030" '���ϓ����߂��Ă��܂��B������ʂ�ύX���Ă��������B
	'// V1.10�� ADD
	'2009/06/08 ADD START FKS)NAKATA
	Public Const gc_strMsgURKET52_E_031 As String = "2URKET52_031" '�󒍋��z�������Ă��܂��B
	Public Const gc_strMsgURKET52_E_032 As String = "2URKET52_032" '�󒍋��z��������Ă��܂��B
	'2009/06/08 ADD E.N.D FKS)NAKATA
	'2009/09/03 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET52_E_033 As String = "2URKET52_033" '���������ȑO�ł��B���̓��t�ł͓��͂ł��܂���B
	Public Const gc_strMsgURKET52_E_034 As String = "2URKET52_034" '������S���҂��c�Ƃł���܂���B
	Public Const gc_strMsgURKET52_E_035 As String = "2URKET52_035" '���������ł��B�{�����ς��m�F��A���������ĉ������B
	'2009/09/03 ADD E.N.D RISE)MIYAJIMA
	'2009/09/07 ADD START FKS)NAKATA
	Public Const gc_strMsgURKET52_E_036 As String = "2URKET52_036" '�[���ς̓����ł��B�X�V�ł��܂���B
	'2009/09/07 ADD E.N.D FKS)NAKATA
	'2009/09/23 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET52_E_037 As String = "2URKET52_037" '�g�p�ł��Ȃ�������ʂł��B
	'2009/09/23 ADD E.N.D RISE)MIYAJIMA
	'2009/10/05 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET52_E_038 As String = "2URKET52_038" '�֘A�����󒍂��������Ă���ׁA�X�V�ł��܂���B
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	'2009/11/10 ADD START FKS)YAMAMOTO
	Public Const gc_strMsgURKET52_E_039 As String = "2URKET52_039" '�󒍓`�[���t������������̎󒍂͓��͂ł��܂���B
	'2009/11/10 ADD E.N.D FKS)YAMAMOTO
	'2009/12/28 ADD START FKS)YAMAMOTO
	Public Const gc_strMsgURKET52_E_040 As String = "2URKET52_040" '��������̎�ʂ���`�ł͂���܂���B
	Public Const gc_strMsgURKET52_E_041 As String = "2URKET52_041" '��`�̊���������w�肳��Ă��܂��B
	'2009/12/28 ADD E.N.D FKS)YAMAMOTO
	'''' ADD 2011/01/14  FKS) T.Yamamoto    Start    �A���[��FC11011401
	Public Const gc_strMsgURKET52_E_042 As String = "2URKET52_042" '���߂��ׂ��ł̓��t�͓��͂ł��܂���
	'''' ADD 2011/01/14  FKS) T.Yamamoto    End
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module