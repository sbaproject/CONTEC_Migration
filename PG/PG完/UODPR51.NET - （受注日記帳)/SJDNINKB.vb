Option Strict Off
Option Explicit On
Module SJDNINKB_F61
	'
	' �X���b�g��        : �󒍎捞��ʋ敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : SJDNINKB.F61
	' �L�q��            : DVP_NT40
	' �쐬���t          : 2007/01/11
	' �g�p�v���O������  : UODPR51
	'
	' ���l              : 1:����
	'                     2:�j����
	
	Function SJDNINKB_CheckC(ByRef SJDNINKB As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SJDNINKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SJDNINKB_CheckC = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SJDNINKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(SJDNINKB) = "" Then '2007.01.11
			'UPGRADE_WARNING: �I�u�W�F�N�g SJDNINKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SJDNINKB = " " '2007.01.11
			Exit Function '2007.01.11
		End If '2007.01.11
		
		Select Case SJDNINKB
			Case "1", "2", "3", "4"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g SJDNINKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SJDNINKB = " "
				Call DSP_MsgBox(SSS_CONFRM, "UODPR51", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g SJDNINKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SJDNINKB_CheckC = -1
		End Select
		
	End Function
	
	Function SJDNINKB_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SJDNINKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SJDNINKB_InitVal = " "
	End Function
End Module