Option Strict Off
Option Explicit On
Module TUKKB_F51
	'
	'�X���b�g��      :�ʉ݋敪�E��ʍ��ڃX���b�g
	'���j�b�g��      :TUKKB.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/05/31
	'�g�p�v���O����  :RATMT51
	'
	
	Function TUKKB_CheckC(ByRef PP As clsPP, ByRef CP_TUKKB As clsCP, ByRef TUKKB As Object, ByVal TEKIDT As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		Dim wkTUKKB As String
		'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TUKKB_CheckC = 0
        'Call TUKMTA_RClear()
        DB_TUKMTA = New TYPE_DB_TUKMTA
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(TUKKB) = "" Then
			'rtn = DSP_MsgBox(SSS_ERROR, "ITM", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			TUKKB_CheckC = -1
		Else
            '''''       Call SCR_FromMfil(De_INDEX)
            ''''
            '20190806 DELL START
            'Call MEIMTA_RClear()
            DB_TUKMTA = New TYPE_DB_TUKMTA
            '20190806 DELL END
            'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wkTUKKB = TUKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(TUKKB))
            '20190807 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, "001" & wkTUKKB, BtrNormal)
            Dim strSQL As String = ""
            strSQL = strSQL & "  Where KEYCD  = '001' AND MEICDA = '" & wkTUKKB & "'"
            strSQL = strSQL & "  Order By MEICDA "

            Call GetRowsCommon("MEIMTA", strSQL)
            '20190807 CHG END
            If DBSTAT = 0 Then '����Ͻ��ɓ��Y���ڂ��݂鎞
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					TUKKB_CheckC = -1
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				TUKKB_CheckC = -1
			End If

            'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If TUKKB_CheckC = 0 Then
                '20190807 DELL START
                'Call TUKMTA_RClear()
                DB_TUKMTA = New TYPE_DB_TUKMTA
                '20190807 DELL END
                'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If Trim(TUKKB) = "" Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    TUKKB_CheckC = -1
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '20190807 CHG START
                    'Call DB_GetEq(DBN_TUKMTA, 1, TUKKB & VB6.Format(TEKIDT, "YYYYMMDD"), BtrNormal)
                    Dim strSQL1 As String = ""
                    strSQL1 = strSQL1 & "  Where TUKKB  = '" & TUKKB & "' AND TEKIDT ='" & VB6.Format(TEKIDT, "YYYYMMDD") & "'"

                    Call GetRowsCommon("TUKMTA", strSQL1)
                    '20190807 CHG END
                    If DBSTAT = 0 Then
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        Call SCR_FromMfil(De_Index)
                        If DB_TUKMTA.DATKB = "9" Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            Call DP_SSSMAIN_UPDKB(De_Index, "�폜")
                        Else
                            'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            Call DP_SSSMAIN_UPDKB(De_Index, "�X�V")
                        End If
                        '20081002 ADD START RISE)Tanimura '�r������
                        ' [����De_Index�͉�ʏ�̍s��(0�`)]
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        M_RATMT_A_inf(De_Index).OPEID = DB_TUKMTA.OPEID ' �ŏI��Ǝ҃R�[�h
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        M_RATMT_A_inf(De_Index).CLTID = DB_TUKMTA.CLTID ' �N���C�A���g�h�c
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        M_RATMT_A_inf(De_Index).WRTTM = DB_TUKMTA.WRTTM ' �^�C���X�^���v�i���ԁj
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        M_RATMT_A_inf(De_Index).WRTDT = DB_TUKMTA.WRTDT ' �^�C���X�^���v�i���t�j
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        M_RATMT_A_inf(De_Index).UOPEID = DB_TUKMTA.UOPEID ' ���[�UID�i�o�b�`�j
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        M_RATMT_A_inf(De_Index).UCLTID = DB_TUKMTA.UCLTID ' �N���C�A���gID�i�o�b�`�j
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        M_RATMT_A_inf(De_Index).UWRTTM = DB_TUKMTA.UWRTTM ' �^�C���X�^���v�i�o�b�`���ԁj
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        M_RATMT_A_inf(De_Index).UWRTDT = DB_TUKMTA.UWRTDT ' �^�C���X�^���v�i�o�b�`���j
                        '20081002 ADD END   RISE)Tanimura
                    Else
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        Call DP_SSSMAIN_UPDKB(De_Index, "�ǉ�")
                        '20081002 ADD START RISE)Tanimura '�r������
                        'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        Call RATMT51_MF_Clear_UWRTDTTM(De_Index)
                        '20081002 ADD END   RISE)Tanimura
                        '20190807 dell start
                        'Call TUKMTA_RClear()
                        '20190807 dell end
                    End If
                End If
                'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call SCR_FromMfil(De_Index)
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Call SCR_FromMEIMTA(De_Index)
			
		End If
		
	End Function
	
	Function TUKKB_Slist(ByRef PP As clsPP, ByVal TUKKB As Object) As Object
		WLS_MEI1.Text = "�ʉ݋敪���̈ꗗ"
        CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
        '20190807 CHG START
        '      Call DB_GetGrEq(DBN_MEIMTA, 3, "001", BtrNormal)
        'Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "001"
        '	If DB_MEIMTA.DATKB <> "9" Then
        '		CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
        '	End If
        '	Call DB_GetNext(DBN_MEIMTA, BtrNormal)
        'Loop 
        ''UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.KEYCD)
        Dim strSQL As String

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "  from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  = '001' "
        strSQL = strSQL & "  Order By MEICDA "

        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Call Set_DB_MEIMTA(dt, DB_MEIMTA, i)
                If dt.Rows(i)("DATKB") <> "9" Then
                    CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(dt.Rows(i)("MEICDA"), 5) & " " & LeftWid(dt.Rows(i)("MEINMA"), 40))
                    SSS_WLSLIST_KETA = LenWid(dt.Rows(i)("MEICDA"))
                End If
            Next
        End If

        WLS_MEI1.ShowDialog()
		WLS_MEI1.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TUKKB_Slist = PP.SlistCom
		
	End Function
End Module