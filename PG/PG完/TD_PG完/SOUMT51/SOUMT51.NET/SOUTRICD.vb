Option Strict Off
Option Explicit On
Module SOUTRICD_F51
	'
	'�X���b�g��      :�����R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :SOUTRICD.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/06/13
	'�g�p�v���O����  :SOUMT51
	'
	
	Function SOUTRICD_Check(ByVal SOUTRICD As Object, ByVal SOUKOKB As Object, ByVal SISNKB As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g SOUTRICD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SOUTRICD_Check = 0
        '20190819 DELL START
        'Call TOKMTA_RClear()
        '20190819 DELL END
        'UPGRADE_WARNING: �I�u�W�F�N�g SOUTRICD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(SOUTRICD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(Trim(SOUTRICD)) = 0 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g SOUKOKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If SOUKOKB = "03" Then
                'UPGRADE_WARNING: �I�u�W�F�N�g SOUTRICD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                SOUTRICD_Check = -1
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g SISNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If SISNKB = 1 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g SOUTRICD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                SOUTRICD_Check = -1
            End If
        Else
            '20190821 CHG START
            'Call DB_GetEq(DBN_TOKMTA, 1, SOUTRICD, BtrNormal)
            Dim strSQL As String = ""
            strSQL = strSQL & " SELECT * FROM TOKMTA  Where TOKCD = '" & SOUTRICD & "'"
            Dim dt2 As DataTable = DB_GetTable(strSQL)
            If dt2.Rows.Count > 0 Then
                DB_TOKMTA.TOKCD = DB_NullReplace(dt2.Rows(0)("TOKCD"), "")
                DB_TOKMTA.TOKRN = DB_NullReplace(dt2.Rows(0)("TOKRN"), "")
                DB_TOKMTA.DATKB = DB_NullReplace(dt2.Rows(0)("DATKB"), "")
            End If

            '20190821 CHG END
            If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g SOUTRICD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					SOUTRICD_Check = 1
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �Y�����R�[�h�͂���܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g SOUTRICD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SOUTRICD_Check = -1
			End If
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call SCR_FromTOKMTA(De_Index)
	End Function
	
	Function SOUTRICD_Slist(ByRef PP As clsPP, ByVal SOUTRICD As Object) As Object
        '20190821 DELL START
        'DB_PARA(DBN_TOKMTA).KeyNo = 1
        ''UPGRADE_WARNING: �I�u�W�F�N�g SOUTRICD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_PARA(DBN_TOKMTA).KeyBuf = SOUTRICD
        '20190821 DELL END
        '20190819 CHG START
        '      WLSTOK.ShowDialog()
        'WLSTOK.Close()
        WLSTOK3.ShowDialog()
        WLSTOK3.Close()
        '20190819 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g SOUTRICD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SOUTRICD_Slist = PP.SlistCom
	End Function
End Module