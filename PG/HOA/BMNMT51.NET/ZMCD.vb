Option Strict Off
Option Explicit On
Module ZMCD_F51
	'
	' �X���b�g��        : ��v�敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ZMCD.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/05/30
	' �g�p�v���O������  : BMNMT51
	'
	Function ZMCD_CheckC(ByRef ZMCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkZMCD As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g ZMCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ZMCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g ZMCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(ZMCD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(ZMCD)) = 0 Then
			rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ZMCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ZMCD_CheckC = -1
		Else
            'UPGRADE_WARNING: �I�u�W�F�N�g ZMCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/03 CHG START
            'wkZMCD = ZMCD & Space(Len(DB_MEIMTA.MEICDA) - Len(ZMCD))
            If DB_MEIMTA.MEICDA Is Nothing OrElse Len(DB_MEIMTA.MEICDA) - Len(ZMCD) Then
                wkZMCD = (ZMCD)
            Else
                wkZMCD = (ZMCD) & Space(Len(DB_MEIMTA.MEICDA) - Len(ZMCD))
            End If
            '2019/10/03 CHG E N D

            '2019/10/03 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, "022" & wkZMCD, BtrNormal)
            Dim strSQL As String = ""
            strSQL = strSQL & "  Where KEYCD  = '022' AND MEICDA = '" & wkZMCD & "'"
            strSQL = strSQL & "  Order By MEICDA "

            Call GetRowsCommon("MEIMTA", strSQL)
            'If DB_MEIMTA.KEYCD Is Nothing Then
            '    DBSTAT = 0
            'Else
            '    DBSTAT = 1
            'End If
            '2019/10/03 CHG END
            If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g ZMCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ZMCD_CheckC = 1
				End If
			Else
				rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g ZMCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ZMCD_CheckC = -1
			End If
		End If
		
	End Function
End Module