Option Strict Off
Option Explicit On
Module NHSMR52_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : NHSMR52.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 1997/06/02
	' �g�p�v���O������  : NHSMR52
	'
	Public Len506 As Short
	Public Len508 As Short
	Public Len509 As Short
	Public Len507 As Short
	Public Len511 As Short
	
	Sub INITDSP()
		
		Dim wkCRW As System.Windows.Forms.Control
		
		'�w�i�F�̐ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(18) = 1 '�֖�
		CL_SSSMAIN(20) = 1 '�Ǝ�
		CL_SSSMAIN(22) = 1 '�n��
		CL_SSSMAIN(33) = 1 '���͒S���҃R�[�h
		CL_SSSMAIN(34) = 1 '���͒S����
		
		
		Call SET_GAMEN_KEY()
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		If DBSTAT <> 0 Then Exit Sub
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CS_NHSCLAID.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CType(FR_SSSMAIN.Controls("CS_NHSCLAID"), Object).Caption = Trim(DB_SYSTBF.USENMA)
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CS_NHSCLBID.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CType(FR_SSSMAIN.Controls("CS_NHSCLBID"), Object).Caption = Trim(DB_SYSTBF.USENMB)
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CS_NHSCLCID.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CType(FR_SSSMAIN.Controls("CS_NHSCLCID"), Object).Caption = Trim(DB_SYSTBF.USENMC)
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(DB_SYSTBF.CLAKB)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(DB_SYSTBF.CLAKB)) = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CS_NHSCLAID.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(FR_SSSMAIN.Controls("CS_NHSCLAID"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("HD_NHSCLAID"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("HD_NHSCLANM"), Object).Visible = False
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(DB_SYSTBF.CLBKB)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(DB_SYSTBF.CLBKB)) = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CS_NHSCLBID.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(FR_SSSMAIN.Controls("CS_NHSCLBID"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("HD_NHSCLBID"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("HD_NHSCLBNM"), Object).Visible = False
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(DB_SYSTBF.CLCKB)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(DB_SYSTBF.CLCKB)) = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN!CS_NHSCLCID.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CType(FR_SSSMAIN.Controls("CS_NHSCLCID"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("HD_NHSCLCID"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("HD_NHSCLCNM"), Object).Visible = False
		End If
		
		'���s�����`�F�b�N
		gs_userid = Left(SSS_OPEID.Value, 6) '���[�UID
		gs_pgid = SSS_PrgId '�v���O����ID
		
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		'���s�����̎擾
		If CDbl(Get_Authority(DB_UNYMTA.UNYDT, wkCRW)) = 9 Then
			Call MsgBox("���s����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		
		'�}�X�^�l�擾�i�Œ�l�}�X�^�j
		Call DB_GetEq(DBN_FIXMTA, 1, "506", BtrNormal) '14
		If DBSTAT = 0 Then Len506 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "507", BtrNormal) '2
		If DBSTAT = 0 Then Len507 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "508", BtrNormal) '8
		If DBSTAT = 0 Then Len508 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "509", BtrNormal) '4
		If DBSTAT = 0 Then Len509 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "511", BtrNormal) '4
		If DBSTAT = 0 Then Len511 = CShort(DB_FIXMTA.FIXVAL)
		
	End Sub
	
	Function MST_Next() As Short
		Dim Rtn As Short
		'
		Call SET_GAMEN_KEY()
		'
		Call DB_GetGr(SSS_MFIL, SSS_MFILKEYNO, SSS_LASTKEY.Value, BtrNormal)
		Do While DBSTAT = 0 And DB_NHSMTA.DATKB = "9"
			Call DB_GetNext(SSS_MFIL, BtrNormal)
		Loop 
		If DBSTAT = 0 Then
			Rtn = 1
		Else
			Call DB_GetLast(SSS_MFIL, 1, BtrNormal)
			Do While DBSTAT = 0 And DB_NHSMTA.DATKB = "9"
				Call DB_GetPre(SSS_MFIL, BtrNormal)
			Loop 
			If DBSTAT = 0 Then
				Rtn = 1
			Else
				Rtn = 0
			End If
		End If
		If Rtn > 0 Then
			' === 20080916 === INSERT S - RISE)Izumi
			'�[����}�X�^�F�r���X�V�����擾
			HAITA_NHSMTA.NHSCD = DB_NHSMTA.NHSCD
			HAITA_NHSMTA.WRTDT = DB_NHSMTA.WRTDT
			HAITA_NHSMTA.WRTTM = DB_NHSMTA.WRTTM
			HAITA_NHSMTA.UWRTDT = DB_NHSMTA.UWRTDT
			HAITA_NHSMTA.UWRTTM = DB_NHSMTA.UWRTTM
			HAITA_NHSMTA.OPEID = DB_NHSMTA.OPEID
			HAITA_NHSMTA.CLTID = DB_NHSMTA.CLTID
			HAITA_NHSMTA.UOPEID = DB_NHSMTA.UOPEID
			HAITA_NHSMTA.UCLTID = DB_NHSMTA.UCLTID
			' === 20080916 === INSERT E - RISE)Izumi
			Call SSSMAIN_DSPMST()
		End If
		MST_Next = Rtn
	End Function
	
	Function MST_Prev() As Object
		Dim Rtn As Short
		'
		Call SET_GAMEN_KEY()
		'
		Call DB_GetLs(SSS_MFIL, SSS_MFILKEYNO, SSS_LASTKEY.Value, BtrNormal)
		Do While DBSTAT = 0 And DB_NHSMTA.DATKB = "9"
			Call DB_GetPre(SSS_MFIL, BtrNormal)
		Loop 
		If DBSTAT = 0 Then
			Rtn = 1
		Else
			Call DB_GetFirst(SSS_MFIL, 1, BtrNormal)
			Do While DBSTAT = 0 And DB_NHSMTA.DATKB = "9"
				Call DB_GetNext(SSS_MFIL, BtrNormal)
			Loop 
			If DBSTAT = 0 Then
				Rtn = 1
			Else
				Rtn = 0
			End If
		End If
		If Rtn = 1 Then
			' === 20080916 === INSERT S - RISE)Izumi
			'�[����}�X�^�F�r���X�V�����擾
			HAITA_NHSMTA.NHSCD = DB_NHSMTA.NHSCD
			HAITA_NHSMTA.WRTDT = DB_NHSMTA.WRTDT
			HAITA_NHSMTA.WRTTM = DB_NHSMTA.WRTTM
			HAITA_NHSMTA.UWRTDT = DB_NHSMTA.UWRTDT
			HAITA_NHSMTA.UWRTTM = DB_NHSMTA.UWRTTM
			HAITA_NHSMTA.OPEID = DB_NHSMTA.OPEID
			HAITA_NHSMTA.CLTID = DB_NHSMTA.CLTID
			HAITA_NHSMTA.UOPEID = DB_NHSMTA.UOPEID
			HAITA_NHSMTA.UCLTID = DB_NHSMTA.UCLTID
			' === 20080916 === INSERT E - RISE)Izumi
			Call SSSMAIN_DSPMST()
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g MST_Prev �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		MST_Prev = Rtn
	End Function
	
	Sub SET_GAMEN_KEY()
		'
		SSS_MFIL = DBN_NHSMTA
		SSS_MFILKEYNO = 1
		SSS_MSTKB.Value = MSTKB_NHSMTA
	End Sub
End Module