Option Strict Off
Option Explicit On
Module SSSMAIN_DL4
	'
	Public SSS_CHK As Short
	Public SSS_MFIL_KeyNo As Short
	Public SSS_SelectFL As Boolean
	
	Public SSS_MaxPage As Short '�ő�i�[�Ő�(1�` )
	Public SSS_SQLPage As Short '�r�p�k�擾�Ő�(1�` )
	Public SSS_CurPage As Short '�J�����g��(1�` )
	Public SSS_LastPage As Short '�ŏI��(1�` )
	Public SSS_PageLine As Short '�œ��s��(1�` )
	Public SSS_LastLine As Short '�ŏI�ōŏI�s�i1 �` SSS_PageLine�j
	Public SSS_WrkKey As String 'KEY�ݒ�p���[�N
	Public SSS_LastSTOP As Boolean
	Public SSS_NoDataDSP As Boolean
	
	Sub CRW_END()
	End Sub
	
	Sub SSS_CLOSE()
		Call DB_End()
	End Sub
	
	'�t�@�C���ɃJ�����g���R�[�h�̒ǉ��������s���B
	Function SSSMAIN_Append() As Object
	End Function
	
	'�ǉ����[�h�ɂȂ�Ƃ��̏������s���B
	Function SSSMAIN_AppendC() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_AppendC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_AppendC = True
	End Function
	
	'��ʕ\���O�̏����ݒ菈�����s���B
	Function SSSMAIN_BeginPrg(ByRef PP As clsPP) As Object
        'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '20190711 DEL START
        'If App.PrevInstance Then
        '    MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '' "���΂炭���҂���������" �E�B���h�E�\��  97/05/29
        ''UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        'Load(ICN_ICON)
        '20190711 DEL END
        SSS_NoDataDSP = False
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_BeginPrg = True
		'----------------------------------
		'   SSSWIN �v���O�����N���`�F�b�N
		'----------------------------------
		SSS_PageLine = PP_SSSMAIN.MaxDspC + 1
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		Call Set_StripeColor()
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
	
	'�J�����g�Ńf�[�^��\������B
	Function SSSMAIN_Current() As Object
		Dim I As Short
		Dim W_DBSTAT As Short
		'
		Call DSP_HEAD()
		If SSS_LastPage < 1 Then Exit Function
		I = 0
		Do While I < SSS_PageLine
			Call DSP_BODY(I)
			I = I + 1
			If SSS_CurPage = SSS_LastPage Then
				If I >= SSS_LastLine Then Exit Do
			End If
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Current �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Current = I
	End Function
	
	'�t�@�C������J�����g���R�[�h���폜����B
	Function SSSMAIN_Delete() As Object
	End Function
	
	'�����Ώۂ̃f�[�^�̒��̐擪�̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_First() As Object
	End Function
	
	'�\�����[�h�ɂȂ�Ƃ��̏������s���B
	Function SSSMAIN_Indicate() As Object
		Dim rtn As Short
		'
		SSS_CurPage = 0
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '�����v
		Call SET_GAMEN_KEY()
		rtn = GET_DSP_DATA()
		If rtn = True Then
			CType(FR_SSSMAIN.Controls("MN_PREV"), Object).Enabled = True
			CType(FR_SSSMAIN.Controls("MN_NEXTCM"), Object).Enabled = True
			If Link_ON And Not SSS_SelectFL Then
				CType(FR_SSSMAIN.Controls("MN_SELECTCM"), Object).Enabled = False
				CType(FR_SSSMAIN.Controls("CM_SELECTCM"), Object).Enabled = False
			Else
				CType(FR_SSSMAIN.Controls("MN_SELECTCM"), Object).Enabled = True
				CType(FR_SSSMAIN.Controls("CM_SELECTCM"), Object).Enabled = True
			End If
		Else
			If SSS_NoDataDSP Then
				Call DSP_HEAD()
			Else
				Call DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			End If
			CType(FR_SSSMAIN.Controls("MN_PREV"), Object).Enabled = False
			CType(FR_SSSMAIN.Controls("MN_NEXTCM"), Object).Enabled = False
		End If
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default '����l
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Indicate �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Indicate = rtn
	End Function
	
	'�����Ώۂ̃f�[�^�̒��̍ŏI�̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_Last() As Object
	End Function
	
	'�����Ώۂ̃f�[�^�̒�����J�����g�̎��̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_Next() As Object
		Dim rtn As Short
		'
		If SSS_CurPage < SSS_LastPage Then
			SSS_CurPage = SSS_CurPage + 1
		ElseIf SSS_CurPage >= SSS_MaxPage Then 
			'Call DSP_MsgBox(SSS_ERROR, "ENDREC", 0)     ' ����ȍ~�̃f�[�^�͂���܂���B
			MsgBox("�ŏI�łł�� �ēx��������͂��Ă��������")
		Else
			'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '�����v
			Call SET_DATA_KEY()
			rtn = GET_DSP_DATA()
			'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default '����l
			If rtn = False Then
				Call DSP_MsgBox(SSS_ERROR, "ENDREC", 0) ' ����ȍ~�̃f�[�^�͂���܂���B
			End If
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Current() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Next = SSSMAIN_Current()
	End Function
	
	'�����Ώۂ̃f�[�^�̒�����J�����g�̈�O�̃��R�[�h��ǂݍ��ށB
	Function SSSMAIN_Prev() As Object
		'
		If SSS_CurPage <= 1 Then
			MsgBox("�擪�łł�� �ēx��������͂��Ă��������")
		Else
			SSS_CurPage = SSS_CurPage - 1
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Current() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Prev = SSSMAIN_Current()
	End Function

    '�����Ώۂ̃f�[�^�͈̔͂�ݒ肷��B
    Function SSSMAIN_Select() As Object
        '20190712 DELL START
        'CType(FR_SSSMAIN.Controls("MN_PREV"), Object).Enabled = True
        'CType(FR_SSSMAIN.Controls("MN_NEXTCM"), Object).Enabled = True
        'CType(FR_SSSMAIN.Controls("MN_SELECTCM"), Object).Enabled = True
        '' 97/09/17 �����N���̏����\���Ή�
        ''SSSMAIN_Select = 1
        'If Link_ON And Not SSS_SelectFL Then
        '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Select �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    SSSMAIN_Select = 2
        'Else
        '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Select �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    SSSMAIN_Select = 1
        'End If
        '20190712 DELL END
    End Function

    '�t�@�C���̒��̃J�����g���R�[�h�̍X�V���s���B
    Function SSSMAIN_Update() As Object
	End Function
	
	'�X�V���[�h�ɂȂ�Ƃ��̏������s���B
	Function SSSMAIN_UpdateC() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_UpdateC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_UpdateC = True
	End Function
	
	'��ʂ�����o�̓o�b�t�@�Ƀf�[�^��]������B
	Sub SSSMfil_FromScr(ByVal De As Short)
	End Sub
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
	End Sub
End Module