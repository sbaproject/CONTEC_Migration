Option Strict Off
Option Explicit On
Module SSSMAIN_FP1
	
	Sub DSPCNT(ByRef RECSU As Integer, ByRef CNT As Integer)
		Dim I As Integer
		'
		I = 0
		If CNT <> 0 And RECSU <> 0 Then I = CNT / RECSU * 100
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CNT.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CType(FR_SSSMAIN.Controls("CNT"), Object).FloodPercent = I
		If I < 50 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CNT.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(FR_SSSMAIN.Controls("CNT"), Object).ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLACK)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CNT.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(FR_SSSMAIN.Controls("CNT"), Object).ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_WHITE)
		End If
		System.Windows.Forms.Application.DoEvents()
	End Sub
	
	Sub SSS_CLOSE()
		Call DB_End()
	End Sub
	
	'�t�@�C���ɃJ�����g���R�[�h�̒ǉ��������s���B
	Function SSSMAIN_Append() As Object
		FR_SSSMAIN.Enabled = False
		Call BATMAN()
		FR_SSSMAIN.Enabled = True
		MsgBox("�������I�����܂����B", MB_OK, Trim(SSS_PrgNm))
		Call DSPCNT(0, 0)
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CNT.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CType(FR_SSSMAIN.Controls("CNT"), Object).Visible = False
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Append �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Append = 1
	End Function
	
	'��ʕ\���O�̏����ݒ菈�����s���B
	Function SSSMAIN_BeginPrg() As Object 'Generated.
        'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '2019/09/23�@��
        'If App.PrevInstance Then
        '    MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/09/23�@��
        ' "���΂炭���҂���������" �E�B���h�E�\��  97/05/29
        'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        '2019/09/23�@CHG START
        'Load(ICN_ICON)
        ICN_ICON.Show()
        '2019/09/23�@�� E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SSSMAIN_BeginPrg = True
		'----------------------------------
		'   SSSWIN �v���O�����N���`�F�b�N
		'----------------------------------
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		'
		Call INITDSP()
		' "���΂炭���҂���������" �E�B���h�E����  97/05/29
		ICN_ICON.Close()
	End Function
	
	'�I�����̌㏈�����s���B
	Function SSSMAIN_Close() As Object 'Generated.
		' �r���e�[�u���X�V�iCLOSE�j
		Call SSSWIN_EXCTBZ_CLOSE()
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Close = True
	End Function
	
	Function SSSMAIN_Current() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Current �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Current = 0
	End Function
	
	Function SSSMAIN_Init() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Init �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Init = True
	End Function
	
	Function SSSMAIN_Last() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Last �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Last = 0
	End Function
	
	Function SSSMAIN_Next() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Next �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Next = 0
	End Function
	
	'�����Ώۂ̃f�[�^�͈̔͂�ݒ肷��B
	Function SSSMAIN_Select() As Object 'Generated.
		'SSSMAIN_Select = SET_GAMEN_KEY()
	End Function
	
	'�t�@�C���̒��̃J�����g���R�[�h�̍X�V���s���B
	Function SSSMAIN_Update() As Object 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Update = 9
	End Function
	
	Sub WLS_SLIST_MOVE(ByVal SLISTCOM As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g SLISTCOM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SLISTCOM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SLISTCOM = LeftWid(SLISTCOM, LENGTH)
	End Sub
End Module