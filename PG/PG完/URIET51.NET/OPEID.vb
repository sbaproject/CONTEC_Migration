Option Strict Off
Option Explicit On
Module OPEID_F51
	'
	' �X���b�g��        : �ŏI��Ǝ҃R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : OPEID.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/05
	' �g�p�v���O������  : SODET51
	'
	
	Function OPEID_InitVal(ByVal OPEID As Object, ByRef PP As clsPP, ByRef CP_OPEID As clsCP) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g OPEID_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		OPEID_InitVal = SSS_OPEID.Value
        If Trim(SSS_OPEID.Value) = "" Then
            '20190709 DEL START
            'Call TANMTA_RClear()
            '20190709 DEL END
            Call OPEID_Move(-1)
        Else
            '20190709 DEL START
            'Call TANMTA_RClear()
            '20190709 DEL END
            '2019/03/27 CHG START
            'Call DB_GetEq(DBN_TANMTA, 1, SSS_OPEID.Value, BtrNormal)
            'Call TANMTA_GetFirst(SSS_OPEID.Value)
            Call GetRowsCommon("TANMTA", "")
            '2019/03/27 CHG E N D
            Call OPEID_Move(-1)
		End If
		
	End Function
	
	Sub OPEID_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_OPENM(De, LeftWid(DB_TANMTA.TANNM, 20))
	End Sub
End Module