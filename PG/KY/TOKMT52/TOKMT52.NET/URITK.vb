Option Strict Off
Option Explicit On
Module URITK_F81
	'
	'�X���b�g��      :�P���E��ʍ��ڃX���b�g
	'���j�b�g��      :URITK.F81
	'�L�q��          :Standard Library
	'�쐬���t        :1997/07/03
	'�g�p�v���O����  :TOKMT52
	
	Function URITK_CheckC(ByVal URITK As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g URITK_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URITK_CheckC = 0
		
		If gs_SALTAUTH = "9" Then
			Call MsgBox("�̔��P���ύX����������܂���", MsgBoxStyle.OKOnly)
			'UPGRADE_WARNING: �I�u�W�F�N�g URITK_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URITK_CheckC = -1
			Exit Function
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(URITK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(URITK) = 0 Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "TOKMT52", 1)
			'UPGRADE_WARNING: �I�u�W�F�N�g URITK_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URITK_CheckC = -1
		End If
		
		
	End Function
End Module