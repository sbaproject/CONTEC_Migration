Attribute VB_Name = "SSSMAIN0002"
Option Explicit
'�v���O�����������v���V�W��

'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
''================================================================================
'���@��ʃ{�f�B���̍s�P�ʂ̋Ɩ����@�@�@�@�@��
'���@�@Cls_Dsp_Body_Row_Inf�Ƃ̌݊������@�@�@��
'���@�@���ʂ̑S�Ă̂o�f�Ő錾����@�@�@�@�@�@��
'���@�@���̂��߈ȉ��̢Dummy��͕K�{�I�I �@�@�@��
Public Type Cls_Dsp_Body_Bus_Inf
    Dummy                 As String        '�_�~�[
End Type
''================================================================================
'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������

'���b�Z�[�W�R�[�h
'����
Public Const gc_strMsgTNAPR81_I_001         As String = "1TNAPR81_001"      '�����s���Ă�낵���ł����H
Public Const gc_strMsgTNAPR81_I_002         As String = "1TNAPR81_002"      '���I�����Ă�낵���ł����H
Public Const gc_strMsgTNAPR81_I_003         As String = "1TNAPR81_003"      '���������I�����܂����B
Public Const gc_strMsgTNAPR81_I_004         As String = "1TNAPR81_014"      '�������𒆒f���܂����B
'---------------------------------------------------------------------------------------------------------------------
Public Const gc_strMsgTNAPR81_E_005         As String = "2TNAPR81_005"      '�����͒l�����e�͈͊O�ł��B
Public Const gc_strMsgTNAPR81_E_006         As String = "2TNAPR81_006"      '���Y������f�[�^�����݂��܂���B
Public Const gc_strMsgTNAPR81_E_007         As String = "2TNAPR81_017"      '���V�[�P���X�擾�ŃG���[���������܂����B
Public Const gc_strMsgTNAPR81_E_008         As String = "2TNAPR81_008"      '���c�a�X�V�G���[���������܂����B
Public Const gc_strMsgTNAPR81_E_009         As String = "2TNAPR81_009"      '���c�a�Q�ƃG���[���������܂����B
Public Const gc_strMsgTNAPR81_E_010         As String = "2TNAPR81_010"      '���c�a�A�N�Z�X�G���[���������܂����B
Public Const gc_strMsgTNAPR81_E_011         As String = "2TNAPR81_011"      '�����[�o�͏����ŃG���[���������܂����B
Public Const gc_strMsgTNAPR81_E_012         As String = "2TNAPR81_012"      '�����͂���Ă��Ȃ����ڂ�����܂��B���͂��ĉ������B
Public Const gc_strMsgTNAPR81_E_013         As String = "2TNAPR81_013"      '�����t�Ɍ�肪����܂��B�C�����Ă��������B
'---------------------------------------------------------------------------------------------------------------------
Public Const gc_strMsgTNAPR81_E_014         As String = "2TNAPR81_014"      '���N���Ɍ�肪����܂��B�C�����Ă��������B
Public Const gc_strMsgTNAPR81_E_015         As String = "2TNAPR81_015"      '���K�{���͍��ڂł��B

