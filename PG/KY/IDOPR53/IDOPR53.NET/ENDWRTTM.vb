Option Strict Off
Option Explicit On
Module ENDWRTTM_F51
	'
	' �X���b�g��        : �I���E���͓��t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ENDWRTDT.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/24
	' �g�p�v���O������  : IDOPR53
	'
	
	Function ENDWRTTM_CheckC(ByVal ENDWRTTM As Object) As Object
		Dim Rtn As Short
		Dim strWRTTM As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTTM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strWRTTM = DeCNV_TIME(CStr(ENDWRTTM))
		
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTTM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDWRTTM_CheckC = 0
		If strWRTTM < "000000" Or strWRTTM > "235959" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTTM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDWRTTM_CheckC = -1
		Else
			If Mid(strWRTTM, 1, 2) < "00" Or Mid(strWRTTM, 1, 2) > "23" Or Mid(strWRTTM, 3, 2) < "00" Or Mid(strWRTTM, 3, 2) > "59" Or Mid(strWRTTM, 5, 2) < "00" Or Mid(strWRTTM, 5, 2) > "59" Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTTM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ENDWRTTM_CheckC = -1
			End If
		End If
		
	End Function
	
	Function ENDWRTTM_InitVal(ByVal ENDWRTTM As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTTM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDWRTTM_InitVal = "23:59:59"
	End Function
End Module