Option Strict Off
Option Explicit On
Module NHSCD_F83
	'
	'�X���b�g��      :�[�i��R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :NHSCD.F83
	'�L�q��          :Standard Library
	'�쐬���t        :1996/07/03
	'�g�p�v���O����  :NHSMR52
	'
	
	Function NHSCD_CheckC(ByVal NHSCD As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSCD_CheckC = 0
		Call NHSMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(NHSCD) = "" Then
			'�K�{�`�F�b�N�~�߂�
			'        NHSCD_CheckC = -1
		Else
			'���̓R�[�h�Ɠ��l�̏ꍇ�`�F�b�N���Ȃ�
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(FR_SSSMAIN.HD_NHSCD.Text) <> Trim(NHSCD) Then
				Call DB_GetEq(DBN_NHSMTA, 1, NHSCD, BtrNormal)
				If DBSTAT <> 0 Then
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
					'UPGRADE_WARNING: �I�u�W�F�N�g NHSCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					NHSCD_CheckC = -1
				Else
					If DB_NHSMTA.DATKB = "9" Then
						Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
						'UPGRADE_WARNING: �I�u�W�F�N�g NHSCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						NHSCD_CheckC = 1
					End If
				End If
			End If
		End If
		
	End Function
End Module