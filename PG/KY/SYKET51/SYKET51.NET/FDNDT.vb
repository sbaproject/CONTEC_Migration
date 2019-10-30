Option Strict Off
Option Explicit On
Module FDNDT_F51
	'
	' �X���b�g��        : �o�ח\����E��ʍ��ڃX���b�g
	' ���j�b�g��        : FDNDT.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2005/06/20
	' �g�p�v���O������  : SYKET51
	'
	'
	Dim NotFirst As Short
	
	Function FDNDT_CheckC(ByVal FDNDT As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FDNDT_CheckC = 0
		rtn = CHECK_DATE(FDNDT)
		If rtn Then
			'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If FDNDT < CNV_DATE(DB_UNYMTA.UNYDT) Then
				rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 1) '�������O���w��͓��͂ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				FDNDT_CheckC = -1
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CHK_KADOYMD(FDNDT) = False Then
					rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 2) '�\�����ғ����ȍ~���͓��͂ł��܂���B
					'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					FDNDT_CheckC = -1
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If FDNDT <> CNV_DATE(DB_UNYMTA.UNYDT) Then
						If DSP_MsgBox(SSS_CONFRM, "SYKET51", 3) <> IDYES Then '���ғ������w�肵�Ă��܂��B���s���Ă���낵���ł����H
							'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							FDNDT_CheckC = 1
						End If
					End If
				End If
			End If
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FDNDT_CheckC = -1
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_FDNDT = FDNDT
		
	End Function
	
	Function FDNDT_InitVal(ByVal FDNDT As Object) As Object
		'
		If NotFirst = False Or Not IsDate(FDNDT) Then
			NotFirst = True
			'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FDNDT_InitVal = DB_UNYMTA.UNYDT '�^�p���}�X�^�̉^�p���B
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FDNDT_InitVal = FDNDT '�O�̓`�[�̓��t�B
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WG_FDNDT = FDNDT_InitVal
		
	End Function
	
	Function FDNDT_Skip(ByRef CT_FDNDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g CT_FDNDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CT_FDNDT.SelStart = 8 'yyyy-mm-dd �� dd �̏ꏊ�փX�L�b�v�B
		'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FDNDT_Skip = False
	End Function
	''
	'''''Function FDNDT_DerivedC(ByVal FDNDT, ByVal JDNNO)
	'''''Dim Rtn As Integer
	'''''    '
	'''''    FDNDT_DerivedC = FDNDT
	'''''    Rtn = CHECK_DATE(FDNDT)
	'''''    If Rtn Then
	'''''        If FDNDT < CNV_DATE(DB_UNYMTA.UNYDT) Then
	'''''            Rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 1) '�������O���w��͓��͂ł��܂���B
	'''''            FDNDT_DerivedC = -1
	'''''        Else
	'''''            If CHK_KADOYMD(FDNDT) = False Then
	'''''                Rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 2) '�\�����ғ����ȍ~���͓��͂ł��܂���B
	'''''                FDNDT_DerivedC = -1
	'''''            Else
	'''''                If FDNDT <> CNV_DATE(DB_UNYMTA.UNYDT) Then
	'''''                    If DSP_MsgBox(SSS_CONFRM, "SYKET51", 3) <> IDYES Then  '���ғ������w�肵�Ă��܂��B���s���Ă���낵���ł����H
	'''''                        FDNDT_DerivedC = 1
	'''''                    End If
	'''''                End If
	'''''            End If
	'''''        End If
	'''''    Else
	'''''        Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
	'''''        FDNDT_DerivedC = -1
	'''''    End If
	''
	'''''End Function
	
	Function FDNDT_Slist(ByVal FDNDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = FDNDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g FDNDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FDNDT_Slist = Set_date.Value
	End Function
End Module