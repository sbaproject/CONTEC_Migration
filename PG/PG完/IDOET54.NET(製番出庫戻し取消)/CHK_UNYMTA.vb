Option Strict Off
Option Explicit On
Module CHK_UNYMTA
    '2019/06/21 DELL START
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   ���́F  Function CHK_UNYDT
    '    '   �T�v�F  �^�p���t�`�F�b�N
    '    '   �����F
    '    '   �ߒl�F�@0:����(�^�p���t�������̓��t�Ɠ���) -1:�^�p���}�X�^��
    '    '�@�@�@�@�@ 1:�^�p���t�������̓��t���傫�� 2:�^�p���t�������̓��t��菬����
    '    '   ���l�F�A���[��739
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    Function CHK_UNYDT(ByRef CHK_DT As String) As Object

    '		Dim strSQL As String
    '		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '		Dim Usr_Ody As U_Ody
    '		Dim ls_UNYDT As String
    '		Dim ls_CHK_DT As String

    '		On Error GoTo ERR_CHK_UNYDT
    '		ls_CHK_DT = Trim(CHK_DT)

    '		'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		CHK_UNYDT = 9

    '		strSQL = ""
    '		strSQL = strSQL & " SELECT UNYDT "
    '		strSQL = strSQL & "   FROM UNYMTA "

    '		'DB�A�N�Z�X
    '		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    '		If CF_Ora_EOF(Usr_Ody) = True Then
    '			'�擾�f�[�^�Ȃ�
    '			'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			CHK_UNYDT = -1
    '			GoTo END_CHK_UNYDT
    '		Else
    '			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			ls_UNYDT = CF_Ora_GetDyn(Usr_Ody, "UNYDT", "") '�^�p���t
    '			If ls_UNYDT = ls_CHK_DT Then
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				CHK_UNYDT = 0
    '			ElseIf ls_UNYDT > ls_CHK_DT Then 
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				CHK_UNYDT = 1
    '			Else
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				CHK_UNYDT = 2
    '			End If
    '		End If

    'END_CHK_UNYDT: 
    '		'�N���[�Y
    '		Call CF_Ora_CloseDyn(Usr_Ody)
    '		Exit Function

    'ERR_CHK_UNYDT: 
    '		GoTo END_CHK_UNYDT
    '	End Function
    '2019/06/21 DELL END
End Module