Option Strict Off
Option Explicit On
Module UDNNO_F61
	'
	' �X���b�g��        : ����`�[�ԍ��E��ʍ��ڃX���b�g
	' ���j�b�g��        : UDNNO.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/25
	' �g�p�v���O������  : URIET51
	'
	
	'����`�[No�̏����l��ݒ肷��B
	Function UDNNO_InitVal(ByVal UDNNO As Object, ByRef PP As clsPP, ByRef CP_UDNNO As clsCP) As Object
        Dim WK_UDNNO As Object
        '2019/03/27 CHG START
        'Call DB_GetEq(DBN_SYSTBC, 1, WG_DKBSB, BtrNormal)
        '2019/06/26 CHG START
        'Call SYSTBC_GetFirstRecByDKBSB(WG_DKBSB)
        Dim sqlWhereStr As String = ""
        If DB_NullReplace(WG_DKBSB, "") = "" Then
            sqlWhereStr = ""
        Else
            sqlWhereStr = "WHERE DKBSB = '" & WG_DKBSB & "'"
        End If

        Call GetRowsCommon("SYSTBC", sqlWhereStr)

        If DB_SYSTBC.DKBSB Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '2019/06/26 CHG E N D
        '2019/03/27 CHG E N D
        If DBSTAT = 0 Then '�`�[�e�[�u�������������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WK_UDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WK_UDNNO = SSSVal(DB_SYSTBC.DENNO) + 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g WK_UDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WK_UDNNO = 1
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g SSS_EDTITM_EEE() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UDNNO_InitVal = SSS_EDTITM_EEE(CP_UDNNO, WK_UDNNO, -1)
	End Function
End Module