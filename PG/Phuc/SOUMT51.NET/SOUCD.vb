Option Strict Off
Option Explicit On
Module SOUCD_F51
	'
	'�X���b�g��      :�q�ɃR�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :SOUCD.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/06/14
	'�g�p�v���O����  :SOUMT51
	'
	
	Function SOUCD_CheckC(ByRef PP As clsPP, ByRef CP_SOUCD As clsCP, ByRef SOUCD As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		Dim wkSOUBSCD As String
        Dim wkSOUKOKB As String

        Dim sqlWhereStr As String = ""
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SOUCD_CheckC = 0
        'Call SOUMTA_RClear()
        'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(SOUCD) = "" Then
            'Call SOUMTA_RClear()
            'Call DP_SSSMAIN_UPDKB(De_Index, "")
            'Call DP_SSSMAIN_SOUBSNM(De_Index, "")
            'Call SCR_FromMfil(De_Index)
            'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            SOUCD_CheckC = -1
        Else
            '2019/10/10 CHG START
            'Call DB_GetEq(DBN_SOUMTA, 1, SOUCD, BtrNormal)
            GetRowsCommon(DBN_SOUMTA, "where SOUCD = '" & SOUCD & "'")
            '2019/10/10 CHG END
            If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call SCR_FromMfil(De_Index)
				If DB_SOUMTA.DATKB = "9" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_UPDKB(De_Index, "�폜")
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_UPDKB(De_Index, "�X�V")
				End If
                '''''                Call DB_GetGrEq(DBN_MEIMTA, 1, "002", BtrNormal)
                '''''                Call SOUBSCD_Move(De_Index)

                '2019/10/10 CHG START
                'wkSOUBSCD = DB_SOUMTA.SOUBSCD & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUBSCD))
                If DB_MEIMTA.MEICDA Is Nothing Then
                    wkSOUBSCD = DB_SOUMTA.SOUBSCD
                Else
                    wkSOUBSCD = DB_SOUMTA.SOUBSCD & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUBSCD))
                End If
                '2019/10/10 CHG E N D

                '2019/10/10 CHG START
                'Call DB_GetEq(DBN_MEIMTA, 2, "015" & wkSOUBSCD, BtrNormal)
                sqlWhereStr = "WHERE KEYCD = '015' AND MEICDA = '" & wkSOUBSCD & "'"
                Call GetRowsCommon(DBN_MEIMTA, sqlWhereStr)
                '2019/10/10 CHG END

                'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call DP_SSSMAIN_SOUBSNM(De_Index, Trim(DB_MEIMTA.MEINMA))
                '2019/09/25 DEL START
                'Call MEIMTA_RClear()
                '2019/09/25 DEL END

                '2019/10/10 CHG START
                'wkSOUKOKB = DB_SOUMTA.SOUKOKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUKOKB))
                If DB_MEIMTA.MEICDA Is Nothing Then
                    wkSOUKOKB = DB_SOUMTA.SOUKOKB
                Else
                    wkSOUKOKB = DB_SOUMTA.SOUKOKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUKOKB))
                End If
                '2019/10/10 CHG E N D

                '2019/10/10 CHG START
                'Call DB_GetEq(DBN_MEIMTA, 2, "026" & wkSOUKOKB, BtrNormal)
                sqlWhereStr = "WHERE KEYCD = '026' AND MEICDA = '" & wkSOUKOKB & "'"
                Call GetRowsCommon(DBN_MEIMTA, sqlWhereStr)
                '2019/10/10 CHG END

                'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call DP_SSSMAIN_SOUKONM(De_Index, Trim(DB_MEIMTA.MEINMA))
                '2019/09/25 DEL START
                'Call TOKMTA_RClear()
                '2019/09/25 DEL END

                '2019/10/10 CHG START
                'Call DB_GetEq(DBN_TOKMTA, 1, DB_SOUMTA.SOUTRICD, BtrNormal)
                sqlWhereStr = "WHERE TOKCD = '" & DB_SOUMTA.SOUTRICD & "'"
                Call GetRowsCommon(DBN_TOKMTA, sqlWhereStr)
                '2019/10/10 CHG END
                'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call SCR_FromTOKMTA(De_Index)
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_UPDKB(De_Index, "�ǉ�")
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_SOUBSNM(De_Index, "")
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_SOUKONM(De_Index, "")
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_SOUBSNM(De_Index, "")
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_SOUTRINM(De_Index, "")
                'Call SOUMTA_RClear()

            End If
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call SCR_FromMfil(De_Index)
	End Function
	
	Function SOUCD_Slist(ByRef PP As clsPP, ByVal SOUCD As Object) As Object
        '
        '2019/10/10 ��
        'DB_PARA(DBN_SOUMTA).KeyNo = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_PARA(DBN_SOUMTA).KeyBuf = SOUCD
        '2019/10/10 ��
        WLSSOU1.ShowDialog()
        WLSSOU1.Close()
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SOUCD_Slist = PP.SlistCom
	End Function
End Module