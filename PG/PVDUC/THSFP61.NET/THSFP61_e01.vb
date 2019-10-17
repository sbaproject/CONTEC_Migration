Option Strict Off
Option Explicit On
Module THSFP61_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : THSPR61.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 2011/02/21
	' �g�p�v���O������  : THSFP61
	'
	Public GV_UNYDT As String
	
	Sub Chain_Proc()
		
	End Sub
	
	Sub InitDsp()
		'�w�i�F�ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		CL_SSSMAIN(5) = 1
		CL_SSSMAIN(7) = 1

        '�^�p���擾
        '2019/10/15 CHG START
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")
        '2019/10/15 CHG END
        GV_UNYDT = DB_UNYMTA.UNYDT
		
		
		'���s�����̎擾
		Call Get_Authority(DB_UNYMTA.UNYDT)
		
		
	End Sub
	
	Public Function SSS_CLOSE() As Object
		
	End Function
	Function SSSMAIN_BeginPrg() As Object
        '��ʕ\���O�̏����ݒ菈�����s���B
        'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '2019/10/15 DEL START
        'If App.PrevInstance Then
        '    '2019/10/15 CHG START
        '    MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/10/15 DEL END
        ' "���΂炭���҂���������" �E�B���h�E�\��
        'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        '2019/10/15 CHG START
        'Load(ICN_ICON)
        ICN_ICON.Show()
        '2019/10/15 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SSSMAIN_BeginPrg = True
		SSS_ExportFLG = False '�����l�F�������
		'----------------------------------
		'   SSSWIN �v���O�����N���`�F�b�N
		'----------------------------------
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		'
		'�f�t�H���g�p���T�C�Y�ƈ���̌�����ǂݎ��
		Call Set_defaultPrintInfo()
		
		Call InitDsp()
		' "���΂炭���҂���������" �E�B���h�E����
		ICN_ICON.Close()
	End Function
	
	Function SSSMAIN_Close() As Object
		'�I�����̌㏈�����s���B
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Close = True
	End Function
	
	Function SSSMAIN_Current() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Current �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Current = 0
	End Function
	
	Function SSSMAIN_Init() As Object
		'
		Call WORKING_VIEW(False)
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
	
	Function SSSMAIN_Select() As Object
		'�����Ώۂ̃f�[�^�͈̔͂�ݒ肷��B
		'SSSMAIN_Select = SET_GAMEN_KEY()
	End Function
	
	Function SSSMAIN_Update() As Object
		'�t�@�C���̒��̃J�����g���R�[�h�̍X�V���s���B
		Dim Wk As Object
		'MsgBox "�f�[�^���X�V���܂����B"
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_Update = 9
	End Function
	
	Function VSTART_GetEvent() As Short
		'
		VSTART_GetEvent = True
		'
		'#Start/2002.1.23
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		Call AE_RecalcAll_SSSMAIN()
		If AE_CompleteCheck_SSSMAIN(0) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
			VSTART_GetEvent = False
			Exit Function
		End If
		'#End/2002.1.23
		SSS_Makkb = SSS_VIEW
		'    Call SSS_LIST(SSS_VIEW)
		'
	End Function
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
	End Sub
	
	Sub WORKING_VIEW(ByRef Sw As Short)
        '�Q�[�W�̕\�� etc...
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.FloodPercent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/15 DEL START
        'CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = 0
        '2019/10/15 DEL END
        If Sw Then
			'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '�����v
            '2019/10/15 CHG START
            'Call AE_StatusOut(PP_SSSMAIN, "��ƒ��I ���΂炭���҂����������B", System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLUE))
            '2019/10/15 CHG END
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 DEL START
            'CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = True
            '2019/10/15 DEL END
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CM_LCANCEL.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = True
		Else
			'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default '����l
			CType(FR_SSSMAIN.Controls("TX_Message"), Object).Text = ""
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!GAUGE.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 DEL START
            'CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = False
            '2019/10/15 DEL END
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CM_LCANCEL.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = False
		End If
		System.Windows.Forms.Application.DoEvents()
	End Sub
End Module