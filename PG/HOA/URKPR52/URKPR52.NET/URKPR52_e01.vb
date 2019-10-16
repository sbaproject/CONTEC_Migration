Option Strict Off
Option Explicit On
Module URKPR52_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : URKPR52.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/31
	' �g�p�v���O������  : URKPR52
	'
	
	Sub Chain_Proc()
		
	End Sub
	
	Sub InitDsp()
		
		
		'2009/01/14 CHG START FKS)NAKATA �A���[��514
		''    '���s�����̎擾
		''    Call Get_Authority(DB_UNYMTA.UNYDT)
		
		''���s�������Ȃ��ꍇ�́A�G���[���b�Z�[�W��\�����N�������Ȃ��B
		If CDbl(Get_Authority(DB_UNYMTA.UNYDT)) = 9 Then
			Call MsgBox("���s����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		'2009/01/14 CHG E.N.D FKS)NAKATA
		
		
		
		'��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
		If gs_PRTAUTH = "1" Then '��������L��
			CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = True
			CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
		Else
			CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = False
			CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
		End If
		If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
			CType(FR_SSSMAIN.Controls("MN_FSTART"), Object).Enabled = True
		Else
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
			CType(FR_SSSMAIN.Controls("MN_FSTART"), Object).Enabled = False
		End If
		
		
	End Sub
	
	Sub INQ_LIST()
		Dim Rtn As Short
		'
		DLGLST1.ShowDialog()
		Select Case SSS_RTNWIN
			Case 0 ' ���
				Rtn = LSTART_GetEvent()
			Case 1 ' �v���r���[
				Rtn = VSTART_GetEvent()
			Case 2 ' �t�@�C���o��
				Rtn = FSTART_GetEvent()
			Case Else
		End Select
	End Sub
	Function SSSMAIN_OPEID_BeginPrg(ByRef PP As clsPP, ByRef CP_OPEID As clsCP) As Object
		AE_BackColor(5) = &H8000000F '�w�i�F�F�O���[
		CL_SSSMAIN(CP_OPEID.CpPx) = 5
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_OPEID_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_OPEID_BeginPrg = True
	End Function
	Function SSSMAIN_OPENM_BeginPrg(ByRef PP As clsPP, ByRef CP_OPENM As clsCP) As Object
		AE_BackColor(5) = &H8000000F '�w�i�F�F�O���[
		CL_SSSMAIN(CP_OPENM.CpPx) = 5
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_OPENM_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_OPENM_BeginPrg = True
	End Function
	Function SSSMAIN_STTTOKRN_BeginPrg(ByRef PP As clsPP, ByRef CP_STTTOKRN As clsCP) As Object
		AE_BackColor(5) = &H8000000F '�w�i�F�F�O���[
		CL_SSSMAIN(CP_STTTOKRN.CpPx) = 5
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_STTTOKRN_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_STTTOKRN_BeginPrg = True
	End Function
	Function SSSMAIN_STTTANNM_BeginPrg(ByRef PP As clsPP, ByRef CP_STTTANNM As clsCP) As Object
		AE_BackColor(5) = &H8000000F '�w�i�F�F�O���[
		CL_SSSMAIN(CP_STTTANNM.CpPx) = 5
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_STTTANNM_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_STTTANNM_BeginPrg = True
	End Function
End Module