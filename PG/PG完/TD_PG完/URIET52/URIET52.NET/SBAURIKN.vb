Option Strict Off
Option Explicit On
Module SBAURIKN_F52
	'
	' �X���b�g��        : �`�[���v������z���ځE��ʍ��ڃX���b�g
	' ���j�b�g��        : SBAURIKN.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/22
	' �g�p�v���O������  : URIET52
	
	'���㍇�v���z���v�Z���ĕ\������B
	Function SBAURIKN_CheckC(ByVal SBAURIKN As Object, ByVal URIKN As Object, ByRef PP As clsPP, ByRef CP_SBAURIKN As clsCP) As Object
		Dim Rtn As Short
		Dim NullSw, I As Short
		Dim Sum As Decimal
		Dim Valu As Decimal
		'
		NullSw = True
		Sum = 0
		I = 0
		Do While I < PP.LastDe
			Valu = 0
			If IsNumeric(RD_SSSMAIN_URIKN(I)) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URIKN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Valu = RD_SSSMAIN_URIKN(I)
				Sum = Sum + Valu
				NullSw = False
			End If
			I = I + 1
		Loop 
		If NullSw = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SBAURIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SBAURIKN <> Sum Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 6) '���v�l�Ɠ��͂��s��v�G���[
				'UPGRADE_WARNING: �I�u�W�F�N�g SBAURIKN_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SBAURIKN_CheckC = -1
			End If
		Else
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 6) '���v�l�Ɠ��͂��s��v�G���[
			'UPGRADE_WARNING: �I�u�W�F�N�g SBAURIKN_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SBAURIKN_CheckC = -1
		End If
		
	End Function
End Module