Option Strict Off
Option Explicit On
Module URITKDT_F51
	'
	' �X���b�g��        : �P���ݒ���t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : URITKDT.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/21
	' �g�p�v���O������  : TOKMT54
	'
	
	Function URITKDT_CheckC(ByVal HINCD As Object, ByVal TOKCD As Object, ByVal URITKDT As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		'Call HINMTA_RClear
		'Call TOKMTA_RClear
		'Call TOKMTC_RClear
		'Call SCR_FromMfil(De_Index)
		'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URITKDT_CheckC = 0
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(URITKDT) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂�
			'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URITKDT_CheckC = -1
		Else
			If Not IsDate(URITKDT) Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂�
				'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URITKDT_CheckC = -1
			Else
				'�^�p���t�Ƃ�����
				'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CInt(VB6.Format(URITKDT, "YYYYMMDD")) < CInt(DB_UNYMTA.UNYDT) Then
					Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) '���t�Ɍ�肪����܂��B�C�����Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					URITKDT_CheckC = -1
				End If
			End If
		End If
	End Function
	
	Function URITKDT_DerivedC(ByVal HINCD As Object, ByVal URITKDT As Object, ByVal De_Index As Object) As Object
		'
		'If Trim$(HINCD) <> "" And Trim$(TOKCD) <> "" And Trim$(URITKDT) = "" Then
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) = "" Then
			Call HINMTA_RClear()
			Call TOKMTA_RClear()
			Call TOKMTC_RClear()
			'URITKDT_DerivedC = Date           ' �{���̓��t�B
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case Trim(URITKDT)
				Case ""
					'URITKDT_DerivedC = Date           '�{���̓��t�B
					'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					URITKDT_DerivedC = DB_UNYMTA.UNYDT '�^�p���t
				Case Else
					'                If Trim$(URITKDT) <> "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					URITKDT_DerivedC = URITKDT
					'                Else
					'URITKDT_DerivedC = Date
					'                  URITKDT_DerivedC = DB_UNYMTA.UNYDT '�^�p���t
					'                End If
			End Select
		End If
	End Function
	
	Function URITKDT_InitVal(ByVal HINCD As Object, ByVal URITKDT As Object, ByVal De_Index As Object) As Object
		'
		'If Trim$(TOKCD) = "" Then Exit Function
		'URITKDT_InitVal = URITKDT          '�O�̓��t�B
		
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URITKDT_InitVal = " "
			Exit Function
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(URITKDT) = "" Then
				'URITKDT_InitVal = Date
				'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URITKDT_InitVal = DB_UNYMTA.UNYDT '�^�p���t
			End If
		End If
		
	End Function
	Sub URITKDT_Move(ByVal URITKDT As Object, ByVal De As Short)
		
		If Trim(DB_TOKMTC.URITKDT) = "" Then
			Call DP_SSSMAIN_URITKDT(De, "")
		Else
			Call DP_SSSMAIN_URITKDT(De, DB_TOKMTC.URITKDT)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_TOKMTC.URITK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(CStr(DB_TOKMTC.URITK)) = "" Or SSSVal(DB_TOKMTC.URITK) = 0 Then
			Call DP_SSSMAIN_URITK(De, "")
		Else
			Call DP_SSSMAIN_URITK(De, DB_TOKMTC.URITK)
		End If
		
	End Sub
	
	Function URITKDT_Skip(ByRef CT_URITKDT As System.Windows.Forms.Control, ByVal URITKDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(URITKDT) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CT_URITKDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CT_URITKDT.SelStart = 8 'yyyy-mm-dd �� dd �ɃJ�[�\�����ړ�����B
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URITKDT_Skip = False
	End Function
	
	Function URITKDT_Slist(ByVal URITKDT As Object, ByRef PP As clsPP, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = URITKDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g URITKDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URITKDT_Slist = Set_date.Value
		
	End Function
End Module