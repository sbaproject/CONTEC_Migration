Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'���b�Z�[�W�R�[�h
	'����
	Public Const gc_strMsgTHSFP61_I_001 As String = "1THSFP61_001" '�����s���Ă�낵���ł����H
	Public Const gc_strMsgTHSFP61_I_002 As String = "1THSFP61_002" '���I�����Ă�낵���ł����H
	Public Const gc_strMsgTHSFP61_I_003 As String = "1THSFP61_003" '���������I�����܂����B
	Public Const gc_strMsgTHSFP61_I_004 As String = "1THSFP61_004" '�������𒆒f���܂����B
	Public Const gc_strMsgTHSFP61_I_005 As String = "1THSFP61_005" '���t�@�C�������݂��܂��B�㏑�����Ă���낵���ł���?
	Public Const gc_strMsgTHSFP61_I_006 As String = "1THSFP61_006" '�����o�����f�[�^���t�@�C���ɏo�͂��܂��B
	Public Const gc_strMsgTHSFP61_I_007 As String = "1THSFP61_007" '���I�����܂��B
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgTHSFP61_E_008 As String = "2THSFP61_008" '�����͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgTHSFP61_E_009 As String = "2THSFP61_009" '���Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgTHSFP61_E_010 As String = "2THSFP61_010" '���c�a�Q�ƃG���[���������܂����B
	Public Const gc_strMsgTHSFP61_E_011 As String = "2THSFP61_011" '���b�r�u�o�͏����ŃG���[���������܂����B
	'�v���O�����������v���V�W��
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(7)
		AE_PSIC = 8
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(2) = "HD_THSCD 3303 code 1 - A L N 0 - - 1 -"
		AE_PSI(3) = "HD_FRNKB 3303 code 1 - A L N 0 - - 1 -"
		AE_PSI(4) = "HD_STTTOKCD 2202 code 5 - A L N S - - 1 -"
		AE_PSI(5) = "HD_STTTOKNM 0000 code 40 - A L N U - - 1 -"
		AE_PSI(6) = "HD_ENDTOKCD 2202 code 5 - A L N S - - 1 -"
		AE_PSI(7) = "HD_ENDTOKNM 0000 code 40 - A L N U - - 1 -"
	End Sub
End Module