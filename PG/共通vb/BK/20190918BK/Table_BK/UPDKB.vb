Option Strict Off
Option Explicit On
Module UPDKB_FM1
    '
    ' �X���b�g��        : �������[�h�E��ʍ��ڃX���b�g
    ' ���j�b�g��        : UPDKB.FM1
    ' �L�q��            : Standard Library
    ' �쐬���t          : 1997/05/27
    ' �g�p�v���O������  : TOKMT01 /SIRMT01 /NHSMT01 /TANMT01 /HINMT01 /BNKMT01/
    '                     UNTMT01 /SIZMT01 /COLMT01 /MAKMT01 /SOUMT01 /CLSMT01/
    '                     CLSMT02 /TOKMT03 /SIRMT03 /SYSMT02/RATMT51/FIXMT51

    'Function UPDKB_GetEvent() As Object
    '	Dim updkb As String
    '	'
    '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	updkb = RD_SSSMAIN_UPDKB(PP_SSSMAIN.De)
    '	If updkb = "�X�V" Then
    '		Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�폜")
    '	ElseIf updkb = "�폜" Then 
    '		Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�X�V")
    '	End If
    '	'1999/12/13 ��Ԃ��ύX���ꂽ���Ƃ��������ɒʒm����
    '	PP_SSSMAIN.InitValStatus = 0
    'End Function
End Module