Option Strict Off
Option Explicit On
Module JDNTRNM_F61
	'
	' �X���b�g��        : �󒍎���敪���́E��ʍ��ڃX���b�g
	' ���j�b�g��        : JDNTRNM.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/25
	' �g�p�v���O������  : URIET51
	
	Function JDNTRNM_Derived(ByVal JDNTRKB As Object) As Object
		Dim Rtn As Short
		
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(JDNTRKB) <> "" Then
            '20190709 DEL START
            'Call MEIMTA_RClear()
            '20190709 DEL END

            'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/01 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 1, "006" & JDNTRKB & " ", BtrNormal)
            'Call MEIMTA_GetFirstRecByKEYCDAndMEICDA("006", JDNTRKB)
            Dim sqlWhereStr As String = ""
            sqlWhereStr = "WHERE KEYCD = '006' AND MEICDA = '" & JDNTRKB & "'"
            Call GetRowsCommon("MEIMTA", sqlWhereStr)
            '2019/04/01 CHG E N D
            If DBSTAT <> 0 Then
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				JDNTRNM_Derived = ""
				Exit Function
			End If
			Call SCR_FromMEIMTA(0)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			JDNTRNM_Derived = ""
		End If
	End Function
End Module