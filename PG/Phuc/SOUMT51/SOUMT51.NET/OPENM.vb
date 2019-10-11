Option Strict Off
Option Explicit On
Module OPENM_F51
	'
	' �X���b�g��        : �ŏI��ƎҖ��E��ʍ��ڃX���b�g
	' ���j�b�g��        : OPENM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/05
	' �g�p�v���O������  : SODET51
	'
	
	Function OPENM_InitVal(ByVal OPENM As Object, ByRef PP As clsPP, ByRef CP_OPENM As clsCP) As Object
		'
		If Trim(SSS_OPEID.Value) = "" Then
			Call TANMTA_RClear()
			Call OPENM_Move(-1)
		Else
			Call DB_GetEq(DBN_TANMTA, 1, SSS_OPEID.Value, BtrNormal)
			Call OPENM_Move(-1)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g OPENM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		OPENM_InitVal = DB_TANMTA.TANNM
		
	End Function
	
	Sub OPENM_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_OPENM(De, DB_TANMTA.TANNM)
	End Sub
End Module