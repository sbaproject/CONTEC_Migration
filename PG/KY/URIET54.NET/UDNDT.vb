Option Strict Off
Option Explicit On
Module UDNDT_F56
	'
	' �X���b�g��        : ������t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : UDNDT.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/24
	' �g�p�v���O������  : URIET53
	'
	'
	Dim NotFirst As Short
	
	Function UDNDT_Check(ByVal UDNDT As Object) As Object
		Dim Rtn As Short
		Dim wkTOKCD As String
		'
		''''UDNDT_Check = 0
		''''rtn = CHECK_DATE(UDNDT)
		''''If rtn Then
		''''    If UDNDT <= CNV_DATE(DB_SYSTBA.MONUPDDT) Then
		''''        rtn = DSP_MsgBox(SSS_ERROR, "DATE", 1) '�����X�V�ς݂ł��B���̓��t�ł͓��͂ł��܂���B
		''''        UDNDT_Check = -1
		''''    End If
		''''Else
		''''    rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
		''''    UDNDT_Check = -1
		''''End If
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UDNDT_Check = 0
		Rtn = CHECK_DATE(UDNDT)
		If Rtn Then
			'�����������`�F�b�N
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If UDNDT <= CNV_DATE(DB_SYSTBA.UKSMEDT) Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 0) '�������������߂��Ă��܂��B
				'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				UDNDT_Check = -1
				Exit Function
			End If
			'���������`�F�b�N
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_TOKMTA.TOKCD) - Len(RD_SSSMAIN_TOKCD(-1)))
			Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If UDNDT <= CNV_DATE(DB_TOKMTA.TOKSMEDT) Then
					Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 1) '�o�^���ꂽ���Ӑ�̐����������߂��Ă��܂��B
					'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					UDNDT_Check = -1
					Exit Function
				End If
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CNV_DATE(DB_UNYMTA.UNYDT) < UDNDT Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 3) '�^�p���ȍ~�͓��͂ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				UDNDT_Check = -1
				Exit Function
			Else
				'2013/07/24 START CHG FWEST)Koroyasu-�A���[��:HAN20130705-01
				'            Call FIXMTA_RClear
				'            Call DB_GetEq(DBN_FIXMTA, 1, "104", BtrNormal)
				'2008/09/11 START CHG FKS)HAYASHI-�A���[��:609
				'''            If Trim$(DB_FIXMTA.FIXVAL) = "9" Then
				'[�ԕi�o�^]�̏ꍇ�̂݃`�F�b�N
				'            If Trim$(DB_FIXMTA.FIXVAL) = "9" And SSS_PrgId = "URIET54" Then
				If SSS_PrgId = "URIET54" Then
					'2008/09/11 E.N.D CHG FKS)HAYASHI-�A���[��:609
					'2013/07/24 E.N.D CHG FWEST)Koroyasu-�A���[��:HAN20130705-01
					'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If UDNDT < Get_STTTouAcedt(CShort(Left(DB_UNYMTA.UNYDT, 4)), CShort(Mid(DB_UNYMTA.UNYDT, 5, 2))) Then
						Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 4) '�O���x�̓��t�͓��͂ł��܂���B
						'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						UDNDT_Check = -1
						Exit Function
					End If
				End If
			End If
			'2007/11/01 FKS)minamoto ADD START
			'2007/11/26 FKS)minamoto CHG START
			'If UDNDT < CNV_DATE(DB_JDNTHA.JDNDT) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If UDNDT < CNV_DATE(DB_JDNTHA.REGDT) Then
				'2007/11/26 FKS)minamoto CHG END
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 6) '�󒍓����O�̓��ׁ̈A���͂ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				UDNDT_Check = -1
				Exit Function
			End If
			'2007/11/01 FKS)minamoto ADD END
			'ADD START FKS)INABA 2010/06/03 **************************************************************
			'�A���[��799
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Left(UDNDT, 7) < Left(CNV_DATE(DB_JDNTHA.JDNDT), 7) Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 8) '���㌎���󒍌��ȑO�̈ד��͂ł��܂���
				'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				UDNDT_Check = -1
				Exit Function
			End If
			'ADD  END  FKS)INABA 2010/06/03 **************************************************************
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNDT_Check = -1
			Exit Function
		End If
		
	End Function
	
	Function UDNDT_InitVal(ByVal UDNDT As Object) As Object
		'
		If NotFirst = False Or Not IsDate(UDNDT) Then
			NotFirst = True
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNDT_InitVal = DB_UNYMTA.UNYDT '�{���̓��t�B
			'�Q�s�ǉ� 1998/05/23 �����X�V�ς݃`�F�b�N
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf UDNDT <= CNV_DATE(DB_SYSTBA.MONUPDDT) Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNDT_InitVal = DB_UNYMTA.UNYDT
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNDT_InitVal = UDNDT '�O�̓`�[�̓��t�B
		End If
	End Function
	
	Function UDNDT_Skip(ByRef CT_UDNDT As System.Windows.Forms.Control) As Object
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g CT_UDNDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/09/19 CHG START
        'CT_UDNDT.SelStart = 8 'yyyy-mm-dd �� dd �̏ꏊ�փX�L�b�v�B
        DirectCast(CT_UDNDT, TextBox).SelectionStart = 8 'yyyy-mm-dd �� dd �̏ꏊ�փX�L�b�v�B
        '2019/09/19 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        UDNDT_Skip = False
	End Function
	
	Function UDNDT_Slist(ByVal UDNDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = UDNDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UDNDT_Slist = Set_date.Value
	End Function
End Module