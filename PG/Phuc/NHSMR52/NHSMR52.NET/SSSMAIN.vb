Option Strict Off
Option Explicit On
Module SSSMAIN_MR1
	'
	'for NewRRR VA03 by SWaN Corp.
	'�ŏI�X�V��=2002/8/28
	''''''''''''''''''''''''''''''
	Sub SSS_CLOSE()
		'
		Call DB_RESET()
		Call DB_End()
	End Sub
	
	'�����Ώۂ̃f�[�^�͈̔͂�ݒ肷��B
	Function SSSMAIN_Select() As Object
		Call SET_GAMEN_KEY()
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Select �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Select = 4
	End Function
	
	'�t�@�C���̒��̃J�����g���R�[�h�̍X�V���s���B
	Function SSSMAIN_Update() As Object
		'
		FR_SSSMAIN.Enabled = False
		SSSMAIN_Update = UpdMst()
		FR_SSSMAIN.Enabled = True
	End Function
	
	'�X�V���[�h�ɂȂ�Ƃ��̏������s���B
	Function SSSMAIN_UpdateC() As Object
		'    If FR_SSSMAIN.BackColor <> &HE0FFFF Then FR_SSSMAIN.BackColor = &HE0FFFF
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_UpdateC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_UpdateC = True
	End Function
	
	'�t�@�C���ɃJ�����g���R�[�h�̒ǉ��������s���B
	Function SSSMAIN_Append() As Object
		'
		FR_SSSMAIN.Enabled = False
		SSSMAIN_Append = UpdMst()
		FR_SSSMAIN.Enabled = True
	End Function
	
	'�ǉ����[�h�ɂȂ�Ƃ��̏������s���B
	Function SSSMAIN_AppendC() As Object
		'    If FR_SSSMAIN.BackColor <> &HC0C0C0 Then FR_SSSMAIN.BackColor = &HC0C0C0
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_AppendC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_AppendC = True
	End Function
	
	'��ʕ\���O�̏����ݒ菈�����s���B
	Function SSSMAIN_BeginPrg() As Object
		'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
		If App.PrevInstance Then
			MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		End If
		' "���΂炭���҂���������" �E�B���h�E�\��  97/05/29
		'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
		Load(ICN_ICON)
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_BeginPrg = True
		'----------------------------------
		'   SSSWIN �v���O�����N���`�F�b�N
		'----------------------------------
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		Call INITDSP()
		' "���΂炭���҂���������" �E�B���h�E����  97/05/29
		ICN_ICON.Close()
	End Function
	
	'�I�����̌㏈�����s���B
	Function SSSMAIN_Close() As Object
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Close = True
	End Function
	
	'�����Ώۂ̃f�[�^�̒��̃J�����g���R�[�h���ēx�ǂݍ��ށB
	Function SSSMAIN_Current() As Object
		Dim I As Short
		'
		Call DB_GetGrEq(SSS_MFIL, 1, SSS_LASTKEY.Value, BtrNormal)
		If DBSTAT = 0 Then
			I = 1
			Call SSSMAIN_DSPMST()
		Else
			I = 0
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Current �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Current = I
	End Function
	
	'�t�@�C������J�����g���R�[�h���폜����B
	Function SSSMAIN_Delete() As Object
		'
		FR_SSSMAIN.Enabled = False
		SSSMAIN_Delete = DelMst()
		FR_SSSMAIN.Enabled = True
	End Function
	
	Sub SSSMAIN_DSPMST()
		Call SCR_FromMfil(0)
		SSS_LASTKEY.Value = DB_PARA(SSS_MFIL).KeyBuf
	End Sub
	
	Function SSSMAIN_First() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_First �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_First = 0
	End Function
	
	'�X�V���[�h�ɂȂ�Ƃ��̏������s���B
	Function SSSMAIN_Indicate() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Indicate �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Indicate = 3
	End Function
	
	Function SSSMAIN_Last() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Last �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Last = 0
	End Function
	
	'�����Ώۂ̃f�[�^�̒�����J�����g�̎��̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_Next() As Object
		'
		SSSMAIN_Next = MST_Next()
	End Function
	
	'�����Ώۂ̃f�[�^�̒�����J�����g�̈�O�̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_Prev() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g MST_Prev() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Prev = MST_Prev()
	End Function
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
	End Sub
	
	Function PREV_GETEVENT() As Short
		Dim Rtn As Object
		'�ύX�f�[�^�L�莞�X�V���菈��
		PREV_GETEVENT = -1
		If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode And PP_SSSMAIN.Mode >= 3 Then '1999/01/05  Update
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = MsgBox("���o�^�̃f�[�^�����݂��܂��B�X�V���s���܂��B", 48 + MsgBoxStyle.YesNoCancel)
			If Rtn = MsgBoxResult.Yes Then '�͂��I�����i�X�V�{���y�[�W�j
				If AE_CompleteCheck_SSSMAIN(0) = 0 Then '1999/01/05  Insert
					FR_SSSMAIN.Enabled = False
					Call UpdMst()
					FR_SSSMAIN.Enabled = True
				Else '1999/01/05  Insert
					PREV_GETEVENT = 0 '�K�{�����L�����Z��  '1999/01/05  Insert
				End If '1999/01/05  Insert
			ElseIf Rtn = MsgBoxResult.Cancel Then 
				PREV_GETEVENT = 0 '�L�����Z���I�����i�����L�����Z���j
			End If
		End If
	End Function
	
	Function NEXTCm_GETEVENT() As Short
		Dim Rtn As Object
		'�ύX�f�[�^�L�莞�X�V���菈��
		NEXTCm_GETEVENT = -1
		If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode And PP_SSSMAIN.Mode >= 3 Then '1999/01/05  Update
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = MsgBox("���o�^�̃f�[�^�����݂��܂��B�X�V���s���܂��B", 48 + MsgBoxStyle.YesNoCancel)
			If Rtn = MsgBoxResult.Yes Then '�͂��I�����i�X�V�{���y�[�W�j
				If AE_CompleteCheck_SSSMAIN(0) = 0 Then '1999/01/05  Insert
					FR_SSSMAIN.Enabled = False
					Call UpdMst()
					FR_SSSMAIN.Enabled = True
				Else '1999/01/05  Insert
					NEXTCm_GETEVENT = 0 '�K�{�����L�����Z��  '1999/01/05  Insert
				End If '1999/01/05  Insert
			ElseIf Rtn = MsgBoxResult.Cancel Then 
				NEXTCm_GETEVENT = 0 '�L�����Z���I�����i�����L�����Z���j
			End If
		End If
	End Function
End Module