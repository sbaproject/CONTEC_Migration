Option Strict Off
Option Explicit On
Module SBADENKN_F52
	'
	' �X���b�g��        : �`�[���v���z(�ō�)���ځE��ʍ��ڃX���b�g
	' ���j�b�g��        : SBADENKN.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/24
	' �g�p�v���O������  : URIET53
	
	'�d�����z�Ə���ŋ��z�����v�v�Z���ĕ\������B
	Function SBADENKN_Derived(ByVal URIKN As Object, ByVal UZEKN As Object, ByRef PP As clsPP) As Object
		Dim I As Short
		
		Do While I < PP.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UZEKN(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URIKN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SBADENKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SBADENKN_Derived = SBADENKN_Derived + RD_SSSMAIN_URIKN(I) + RD_SSSMAIN_UZEKN(I)
			I = I + 1
		Loop 
		
	End Function
End Module