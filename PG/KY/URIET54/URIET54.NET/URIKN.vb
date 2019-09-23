Option Strict Off
Option Explicit On
Module URIKN_F53
	'
	' �X���b�g��        : ������z�E��ʍ��ڃX���b�g
	' ���j�b�g��        : URIKN.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/12
	' �g�p�v���O������  : URIET54
	'
	
	'����P�������㐔��
	Function URIKN_Derived(ByVal URIKN As Object, ByVal URITK As Object, ByVal URISU As Object, ByVal HINID As Object, ByRef CP_URIKN As clsCP) As Object
		'
		'''' UPD 2011/03/07  FKS) T.Yamamoto    Start    �A���[��CF11011701
		'    '�y�ʔ́z�y�сy�V�X�e���ŏ������i�z���A�Z�o�������
		'    If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
		'�V�X�e���ŏ������i�̏ꍇ��������z���Z�o����i�ԕi�o�^��ʂł͏������i�͓�����ŃG���[�ƂȂ�j
		If Trim(WG_JDNINKB) = "2" Then
			'''' UPD 2011/03/07  FKS) T.Yamamoto    End
			'UPGRADE_WARNING: �I�u�W�F�N�g URIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g URIKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URIKN_Derived = URIKN
			Exit Function
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URIKN_Derived = URIKN
		'UPGRADE_WARNING: �I�u�W�F�N�g URITK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(URITK) = "" Or Not IsNumeric(URITK) Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(URISU) = "" Or Not IsNumeric(URISU) Then Exit Function
		On Error GoTo OverFlow
		'' 2003/08/28 �ύX�����P�� �� 0 �̏ꍇ�O��̋��z���c��
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g URITK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If URITK <> 0 Or URISU <> 0 Then
			''If URITK <> 0 And URISU <> 0 Then
			'        URIKN_Derived = URITK * URISU                  '1996/08/26 Delete
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g URITK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URIKN_Derived = DCMFRC(URITK * URISU, 0, 0) '1996/08/26 Insert
		End If
		Exit Function
OverFlow: 
		CP_URIKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URIKN_Derived = "??????????????????"
	End Function
End Module