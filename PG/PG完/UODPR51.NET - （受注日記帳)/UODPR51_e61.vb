Option Strict Off
Option Explicit On
Module UODPR51_E61
	'
	' �X���b�g��        : ��ʓ��������E��ʏ����X���b�g
	' ���j�b�g��        : UODPR51.E61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/09/28
	' �g�p�v���O������  : UODPR51
	'
	
	Sub Chain_Proc()
		
	End Sub

    Sub InitDsp()
        AE_BackColor(1) = &H8000000F
        '
        CL_SSSMAIN(0) = 1
        CL_SSSMAIN(1) = 1
        CL_SSSMAIN(3) = 1
        CL_SSSMAIN(11) = 1
        '
        '2019.03.27 DEL START
        'CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
        '2019.03.27 DEL END

        '''''    '---�����擾---
        '''''   Dim wkDATE As String, wkCRW As Control
        '''''   wkDATE = Format(Now, "YYYYMMDD")
        '''''   gs_userid = Left(SSS_OPEID, 6)          '���[�UID
        '''''   gs_pgid = "THSMR51"                     '�v���O����ID
        '''''   If Get_Authority(wkDATE, wkCRW) = 9 Then
        '''''      Call MsgBox("���s����������܂���B", vbOKOnly)
        '''''      End
        '''''   End If

        '���s�����̎擾
        '2019.03.27 DEL START
        'Call Get_Authority(DB_UNYMTA.UNYDT)

        ''��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
        'If gs_PRTAUTH = "1" Then '��������L��
        '    CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = True
        '    CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'Else
        '    CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
        '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = False
        '    CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'End If
        'If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
        '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        '    CType(FR_SSSMAIN.Controls("MN_FSTART"), Object).Enabled = True
        'Else
        '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
        '    CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        '    CType(FR_SSSMAIN.Controls("MN_FSTART"), Object).Enabled = False
        'End If

        '2019.03.27 DEL END

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
		'
		CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
	End Sub
End Module