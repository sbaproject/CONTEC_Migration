Option Strict Off
Option Explicit On
Module OPEID_F71
	'
	' �X���b�g��        : �ŏI��Ǝ҃R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : OPEID.F71
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/07/23
	' �g�p�v���O������  : NHSMR51
	'
	
	Function OPEID_InitVal(ByVal OPEID As Object, ByRef PP As clsPP, ByRef CP_OPEID As clsCP) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g OPEID_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		OPEID_InitVal = SSS_OPEID.Value
		If Trim(SSS_OPEID.Value) = "" Then
			Call TANMTA_RClear()
			Call OPEID_Move(-1)
		Else
			Call TANMTA_RClear()
			Call DB_GetEq(DBN_TANMTA, 1, SSS_OPEID.Value, BtrNormal)
			Call OPEID_Move(-1)
		End If
		
	End Function
	
	Sub OPEID_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_OPENM(De, LeftWid(DB_TANMTA.TANNM, 20))
	End Sub
End Module