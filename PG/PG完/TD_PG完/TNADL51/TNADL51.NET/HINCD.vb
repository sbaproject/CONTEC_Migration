Option Strict Off
Option Explicit On
Module HINCD_F84
	'
	' �X���b�g��        : ���i�R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : HINCD.F81
	' �L�q��            : Muratani
	' �쐬���t          : 2006/08/29
	' �g�p�v���O������  : HINMR61
	'
	
	Function HINCD_CheckC(ByRef PP As clsPP, ByRef CP_HINCD As clsCP, ByVal De_Index As Object, ByRef HINCD As Object) As Object
		Dim Rtn As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HINCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) = "" Then Exit Function
		' < ORACLE�G���W����JET�G���W���̎d�l�̈Ⴂ�Ɋւ�������J�X�g�}�C�Y��h������ >
		' < ���j�b�g���ɖ{���s�v(eee�ŏ����ρj�ȃR�[�h���̉p����啶�������鏈����ǉ�  >
		'
		' �y����������͂ł���悤�ɃJ�X�g�}�C�Y����ꍇ�͈ȉ��̓_�ɒ��ӂ��Ă��������B�z
		'    -"ABC-0123"��"abc-0123"�Ƃ����Q�̃��R�[�h�̍쐬�͋�����܂���B
		'    -�R�[�h�̑召�́A��ʏ�ł͕����R�[�h���A���[��ł̓A���t�@�x�b�g���i�啶��
		'     �^�������֌W�Ȃ��j�ƂȂ�܂��̂Ń\�[�g���ʁA�������ʂɒ��ӂ��K�v�ł��B
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HINCD = UCase(HINCD)
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DB_GetEq(DBN_HINMTA, 1, HINCD & Space(10 - Len(HINCD)), BtrNormal)
        If DBSTAT <> 0 Then
            '20190705 DELL START
            'Call HINMTA_RClear()
            '20190705 DELL END
            '''        Call Dsp_Prompt("RNOTFOUND", 0)             ' �V�K���R�[�h�ł��B
            '''        HINCD_CheckC = -1
            'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �Y�����郌�R�[�h�����݂��܂���
            'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            HINCD_CheckC = 1

        Else

            If DB_HINMTA.DATKB = "9" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 4)
				'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				HINCD_CheckC = -1
			Else
				If DB_HINMTA.ZAIKB = "9" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Rtn = DSP_MsgBox(SSS_CONFRM, "TNADL51", 0) '�݌ɊǗ��ΏۊO�̈׃G���[
					'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					HINCD_CheckC = -1
				Else
					If DB_HINMTA.KHNKB = "9" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Rtn = DSP_MsgBox(SSS_ERROR, "HINCD", 0) '�����i�̈׃G���[
						'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						HINCD_CheckC = -1
					End If
				End If
			End If
			'
			'''        If Trim$(DB_HINMTA.KHNKB) = "9" Or Trim$(DB_HINMTA.KHNKB) = "" Then
			'''       '     FR_SSSMAIN.LB_KARINM.Caption = "���o�^"
			'''        Else
			'''      '      FR_SSSMAIN.LB_KARINM.Caption = ""
			'''        End If
			'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call SCR_FromHINMTA(De_Index)
			
			SSS_LASTKEY.Value = DB_HINMTA.HINCD
			
		End If
		
	End Function

    Function HINCD_Slist(ByRef PP As clsPP, ByVal HINCD As Object) As Object
        '20190708 CHG START
        'WLSHIN.Text = "���i�ꗗ"
        WLSHIN4.Text = "���i�ꗗ"
        '20190708 CHG END
        '20190708 DELL START
        'DB_PARA(DBN_HINMTA).KeyNo = 1
        ''    DB_PARA(DBN_HINMTA).KeyBuf = HINCD
        'DB_PARA(DBN_HINMTA).KeyBuf = ""
        '20190708 DELL END
        '20190708 CHG START
        'WLSHIN.ShowDialog()
        'WLSHIN.Close()
        WLSHIN4.ShowDialog()
        WLSHIN4.Close()
        '20190708 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        HINCD_Slist = PP.SlistCom
    End Function
End Module