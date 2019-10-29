Option Strict Off
Option Explicit On
Module SSSMAIN_ET1
	'
	'for NewRRR VA03 by SWaN Corp.
	'�ŏI�X�V��=2002/8/28
	''''''''''''''''''''''''''''''
	Sub SSS_CLOSE()
		'
		Call DB_End()
		Call CRW_END()
	End Sub
	
	'�t�@�C���ɃJ�����g���R�[�h�̒ǉ��������s���B
	Function SSSMAIN_Append() As Object
		If SSS_UPDATEFL Then
			' ��s�ǉ�  PL/SQL�Ή�
			G_PlCnd.nJobMode = 0 'Insert MODE
			FR_SSSMAIN.Enabled = False
			'UPGRADE_WARNING: �I�u�W�F�N�g INQ_UPDATE() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSMAIN_Append = INQ_UPDATE()
			FR_SSSMAIN.Enabled = True
			PP_SSSMAIN.SuppressGotLostFocus = 1
		Else
			MsgBox("���̃f�[�^�͒ǉ��ł��܂���B")
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Append �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSMAIN_Append = 0
		End If
	End Function
	
	'�ǉ����[�h�ɂȂ�Ƃ��̏������s���B
	Function SSSMAIN_AppendC() As Object
		'   If FR_SSSMAIN.BackColor <> &HC0C0C0 Then FR_SSSMAIN.BackColor = &HC0C0C0
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_AppendC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_AppendC = True
	End Function
	
	'��ʕ\���O�̏����ݒ菈�����s���B
	Function SSSMAIN_BeginPrg(ByRef PP As clsPP) As Object
        'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '2019/10/28 DEL START
        'If App.PrevInstance Then
        '    MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/10/28 DEL E N D
        ' "���΂炭���҂���������" �E�B���h�E�\��  97/05/29
        'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        '2019/10/28 CHG START
        'Load(ICN_ICON)
        ICN_ICON.ShowDialog()
        '2019/10/28 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SSSMAIN_BeginPrg = True
		'----------------------------------
		'   SSSWIN �v���O�����N���`�F�b�N
		'----------------------------------
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		Call Set_StripeColor()
		' �r���e�[�u���X�V�iOPEN�j
		'Call SSSWIN_EXCTBZ_OPEN
		'ADD START FKS)INABA 2009/11/19 *********************
		'�A���[��758
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If
		'ADD  END  FKS)INABA 2009/11/19 *********************
		Call INITDSP()
		' �N���X�^�����|�[�g
		If CRW_INIT() = False Then
			Call Error_Exit("ERROE CRW_INIT")
		End If
		' "���΂炭���҂���������" �E�B���h�E����  97/05/29
		ICN_ICON.Close()
	End Function
	
	'�I�����̌㏈�����s���B
	Function SSSMAIN_Close() As Object
		' �r���e�[�u���X�V�iCLOSE�j
		Call SSSWIN_EXCTBZ_CLOSE()
		' === 20130416 === INSERT S - FWEST)Koroyasu �r������̉���
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130416 === INSERT E -
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Close = True
	End Function
	
	'�����Ώۂ̃f�[�^�̒��̃J�����g���R�[�h���ēx�ǂݍ��ށB
	Function SSSMAIN_Current() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g DSPTRN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Current = DSPTRN()
	End Function
	
	'�t�@�C������J�����g���R�[�h���폜����B
	Function SSSMAIN_Delete() As Object
		Dim Rtn As Short
		'
		If SSS_UPDATEFL Then
			' ��s�ǉ�  PL/SQL�Ή�
			G_PlCnd.nJobMode = 2 'Delete MODE
			FR_SSSMAIN.Enabled = False
			Rtn = DELTRN()
			FR_SSSMAIN.Enabled = True
			PP_SSSMAIN.SuppressGotLostFocus = 1
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Delete �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSMAIN_Delete = Rtn
		Else
			MsgBox("���̃f�[�^�͍폜�ł��܂���B")
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Delete �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSMAIN_Delete = 0
		End If
	End Function
	
	'�����Ώۂ̃f�[�^�̒��̐擪�̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_First() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_First �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_First = False
	End Function
	
	'�X�V���[�h�ɂȂ�Ƃ��̏������s���B
	Function SSSMAIN_Indicate() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Indicate �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Indicate = 3
	End Function
	
	Function SSSMAIN_Init() As Object
		SSS_UPDATEFL = True
	End Function
	
	'�����Ώۂ̃f�[�^�̒��̍ŏI�̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_Last() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Last �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Last = False
	End Function
	
	'�����Ώۂ̃f�[�^�̒�����J�����g�̎��̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_Next() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Next �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Next = False
	End Function
	
	'�����Ώۂ̃f�[�^�̒�����J�����g�̈�O�̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_Prev() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Prev �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Prev = False
	End Function
	
	'�����Ώۂ̃f�[�^�͈̔͂�ݒ肷��B
	Function SSSMAIN_Select() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Select �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Select = 2 '���샂�[�h�̕ύX���s��Ȃ�
	End Function
	
	'�t�@�C���̒��̃J�����g���R�[�h�̍X�V���s���B
	Function SSSMAIN_Update() As Object
		If SSS_UPDATEFL Then
			' ��s�ǉ�  PL/SQL�Ή�
			G_PlCnd.nJobMode = 1 'Update MODE
			FR_SSSMAIN.Enabled = False
			'UPGRADE_WARNING: �I�u�W�F�N�g INQ_UPDATE() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSMAIN_Update = INQ_UPDATE()
			FR_SSSMAIN.Enabled = True
			'SSSMAIN_Update = 5
			PP_SSSMAIN.SuppressGotLostFocus = 1
		Else
			MsgBox("���̃f�[�^�͍X�V�ł��܂���B")
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSMAIN_Update = 0
		End If
	End Function
	
	'�X�V���[�h�ɂȂ�Ƃ��̏������s���B
	Function SSSMAIN_UpdateC() As Object
		'   If FR_SSSMAIN.BackColor <> &HE0FFFF Then FR_SSSMAIN.BackColor = &HE0FFFF
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_UpdateC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_UpdateC = True
	End Function
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
		'PP_SSSMAIN.CursorDirection = 1
		'WLS_SLISTCOM = SlistCom
	End Sub
End Module