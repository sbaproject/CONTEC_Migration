Option Strict Off
Option Explicit On
Module ENDBNKCD_F52
    '
    '�X���b�g��      :�q�ɃR�[�h�E��ʍ��ڃX���b�g
    '���j�b�g��      :SOUCD.F55
    '�L�q��          :Standard Library
    '�쐬���t        :2006/08/11
    '�g�p�v���O����  :nykpr52
    '
    '
    '2019/10/03 CHG START
    'Function ENDBNKCD_Check(ByVal ENDBNKCD As Object, ByVal STTBNKCD As Object) As Object
    Function ENDBNKCD_Check(ByVal ENDBNKCD As Object, ByVal STTBNKCD As Object, ByVal De_Index As Object) As Object
        '2019/10/03 CHG END
        Dim rtn As Short
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ENDBNKCD_Check = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g STTBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If ENDBNKCD < STTBNKCD Then
            rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
            'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ENDBNKCD_Check = -1
            Exit Function
        End If

        '2019/09/20 DEL START
        'Call BNKMTA_RClear()
        '2019/09/20 DEL START
        'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(ENDBNKCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(ENDBNKCD) = 0 Or Trim(ENDBNKCD) = "" Then
        Else
            '2019/10/03 CHG START
            'Call DB_GetEq(DBN_BNKMTA, 1, ENDBNKCD, BtrNormal)
            GetRowsCommon(DBN_BNKMTA, "Where BNKCD = '" & ENDBNKCD & "'")

            If DBSTAT = 0 Then
                Call SCR_FromMfilENDBNKCD(De_Index)
            End If
            '2019/10/03 CHG END
            ''''''''If DBSTAT = 0 Then
            ''''''''    If DB_BNKMTA.DATKB = "9" Then
            ''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' �폜�σ��R�[�h�ł��B
            ''''''''        ENDBNKCD_Check = 1
            ''''''''    End If
            ''''''''Else
            ''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
            ''''''''    ENDBNKCD_Check = -1
            ''''''''End If
        End If
        'Call SCR_FromBNKMTA(De_Index)
    End Function

    Function ENDBNKCD_Slist(ByRef PP As clsPP, ByVal ENDBNKCD As Object) As Object
        '
        '2019/09/27 DEL START
        'DB_PARA(DBN_BNKMTA).KeyNo = 1
        ''UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_PARA(DBN_BNKMTA).KeyBuf = ENDBNKCD
        WLSBNK.ShowDialog()
		WLSBNK.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDBNKCD_Slist = PP.SlistCom
	End Function
	Function ENDBNKCD_InitVal(ByVal ENDBNKCD As Object) As Object
		''''ENDBNKCD_InitVal = " "
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDBNKCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDBNKCD_InitVal = "ZZZZZZZ"
	End Function
End Module