Option Strict Off
Option Explicit On
Module IDOPR53_E01
	'
	' �X���b�g��        : ��ʓ��������E��ʏ����X���b�g
	' ���j�b�g��        : IDOPR53.E01
	' �L�q��            : Muratani
	' �쐬���t          : 2006/09/28
	' �g�p�v���O������  : IDOPR53
	'
	
	Sub Chain_Proc()
		
	End Sub
	
	Sub InitDsp()
		AE_BackColor(1) = &H8000000F
		'
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		CL_SSSMAIN(3) = 1
		'
		'���s�����̎擾
		Call Get_Authority(DB_UNYMTA.UNYDT)
		
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
End Module