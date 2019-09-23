Option Strict Off
Option Explicit On
Module SBAFRUKN_F53
	'
	' �X���b�g��        : �`�[���v�O�ݔ�����z���ځE��ʍ��ڃX���b�g
	' ���j�b�g��        : SBAFRUKN.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URIET01
	
	'���㍇�v���z���v�Z���ĕ\������B
	Function SBAFRUKN_Derived(ByVal FURIKN As Object, ByRef PP As clsPP, ByRef CP_SBAFRUKN As clsCP) As Object
		Dim NullSw, I As Short
		Dim Sum As Decimal
		Dim VALU As Decimal
		'
		On Error GoTo OverFlow
		NullSw = True
		Sum = 0
		I = 0
		Do While I < PP.LastDe
			VALU = 0
			If IsNumeric(RD_SSSMAIN_FURIKN(I)) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FURIKN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				VALU = RD_SSSMAIN_FURIKN(I)
				Sum = Sum + VALU
				NullSw = False
			End If
			I = I + 1
		Loop 
		If NullSw = False Then 'Null�ȊO�̎󒍋��z������ꍇ�B
			'UPGRADE_WARNING: �I�u�W�F�N�g SBAFRUKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SBAFRUKN_Derived = Sum
		Else '�󒍋��z�͑S��Null�̏ꍇ�B
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SBAFRUKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SBAFRUKN_Derived = System.DBNull.Value
		End If
		Exit Function
OverFlow: 
		CP_SBAFRUKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: �I�u�W�F�N�g SBAFRUKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SBAFRUKN_Derived = "??????????????????"
	End Function
End Module