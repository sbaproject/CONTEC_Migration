Option Strict Off
Option Explicit On
Module ZMJGYCD_F51
	'
	' �X���b�g��        : ��v���Ə��R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ZMJGYCD.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/05/30
	' �g�p�v���O������  : BMNMT51
	'
	
	Function ZMJGYCD_CheckC(ByRef ZMJGYCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkZMJGYCD As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g ZMJGYCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ZMJGYCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g ZMJGYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(ZMJGYCD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(ZMJGYCD)) = 0 Then
			rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ZMJGYCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ZMJGYCD_CheckC = -1
		Else
            'UPGRADE_WARNING: �I�u�W�F�N�g ZMJGYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/03 CHG START
            'wkZMJGYCD = ZMJGYCD & Space(Len(DB_MEIMTA.MEICDA) - Len(ZMJGYCD))
            If DB_MEIMTA.MEICDA Is Nothing OrElse Len(DB_MEIMTA.MEICDA) - Len(ZMJGYCD) Then
                wkZMJGYCD = (ZMJGYCD)
            Else
                wkZMJGYCD = (ZMJGYCD) & Space(Len(DB_MEIMTA.MEICDA) - Len(ZMJGYCD))
            End If
            '2019/10/03 CHG E N D

            '2019/10/03 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, "021" & wkZMJGYCD, BtrNormal)
            Dim strSQL As String = ""
            strSQL = strSQL & "  Where KEYCD  = '021' AND MEICDA = '" & wkZMJGYCD & "'"
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
					'UPGRADE_WARNING: �I�u�W�F�N�g ZMJGYCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ZMJGYCD_CheckC = 1
				End If
			Else
				rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g ZMJGYCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ZMJGYCD_CheckC = -1
			End If
		End If
		
	End Function
End Module