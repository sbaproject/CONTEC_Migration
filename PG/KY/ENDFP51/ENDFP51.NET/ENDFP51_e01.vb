Option Strict Off
Option Explicit On
Module ENDFP51_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : ENDFP51.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : ENDFP51
	'
	
	Sub INITDSP()
		'�w�i�F�ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "���N�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If
		
	End Sub
End Module