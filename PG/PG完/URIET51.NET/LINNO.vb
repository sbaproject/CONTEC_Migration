Option Strict Off
Option Explicit On
Module LINNO_F01
	'
	' �X���b�g��        : �s�ԍ��E��ʍ��ڃX���b�g
	' ���j�b�g��        : LINNO.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : UODET01 / URIET01 / TNAET01
	'
	
	Function LINNO_InitVal(ByVal De_index As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g De_index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		LINNO_InitVal = VB6.Format(De_index + 1, "000")
	End Function
End Module