Option Strict Off
Option Explicit On
Module WRTFSTTM_F51
	'
	' �X���b�g��        : �ŏI��Ǝ҃R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : WRTFSTTM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/05
	' �g�p�v���O������  : SODET51
	'
	
	Function WRTFSTTM_InitVal(ByVal WRTFSTTM As Object, ByRef PP As clsPP, ByRef CP_WRTFSTTM As clsCP) As Object
		'
		WRTFSTTM_InitVal = VB6.Format(WG_WRTFSTTM, "00:00:00")
		
	End Function
End Module