Option Strict Off
Option Explicit On
Module URIPR52_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : URIPR52.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URIPR52
	'
	
	Sub Chain_Proc()
		
	End Sub
	
	Sub InitDsp()
		
		'�w�i�F�̐ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		CL_SSSMAIN(5) = 1
		CL_SSSMAIN(7) = 1
		CL_SSSMAIN(11) = 1
		CL_SSSMAIN(13) = 1

        '2019.04.08 del start
        ''�^�p���̎擾
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)

        ''���s�����̎擾
        'Call Get_Authority(DB_UNYMTA.UNYDT)

        ''��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
        'If gs_PRTAUTH = "1" Then '��������L��
        '	CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = True
        '	CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'Else
        '	CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = False
        '	CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'End If
        'If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'Else
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
        '	CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'End If

        ''ADD 2007/02/19 IMAI ����t���O������
        'SSS_DonePrintFlg = 0
        '2019.04.08 del end

	End Sub
	
	Sub INQ_LIST()
		Dim Rtn As Short
        '
        DLGLST1.ShowDialog()

        Select Case SSS_RTNWIN
            Case 0 ' ���
                '2019.04.12 del start
                'Rtn = LSTART_GetEvent()
                  '2019.04.12 del end
            Case 1 ' �v���r���[
                Rtn = VSTART_GetEvent()
            Case 2 ' �t�@�C���o��
                '2019.04.12 del start
                'Rtn = FSTART_GetEvent()
                '2019.04.12 del end
            Case Else
        End Select

    End Sub
End Module