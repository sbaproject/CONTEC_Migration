Option Strict Off
Option Explicit On
Module SSSMSG_BAS
	'Copyright 1994-2002 by AppliTech, Inc. All Rights Reserved.
	'
	'Message Library V6.60 '���x���A�b�v�̍ۂɕύX�B
	'
	'�F �̒l�B
	'UPGRADE_NOTE: Cn_BLACK �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_BLACK As System.Drawing.Color = System.Drawing.Color.Black '���F = &H0&
	'UPGRADE_NOTE: Cn_RED �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_RED As System.Drawing.Color = System.Drawing.Color.Red '�ԐF = &HFF&
	'UPGRADE_NOTE: Cn_GREEN �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_GREEN As System.Drawing.Color = System.Drawing.Color.Lime '�ΐF = &HFF00&
	'UPGRADE_NOTE: Cn_YELLOW �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_YELLOW As System.Drawing.Color = System.Drawing.Color.Yellow '���F = &HFFFF&
	'UPGRADE_NOTE: Cn_BLUE �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_BLUE As System.Drawing.Color = System.Drawing.Color.Blue '�F = &HFF0000
	Public Const Cn_GREENBLUE As Integer = &H808000 '�ΐF = &H808000
	'UPGRADE_NOTE: Cn_MAGENTA �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_MAGENTA As System.Drawing.Color = System.Drawing.Color.Magenta '���F = &HFF00FF
	'UPGRADE_NOTE: Cn_CYAN �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_CYAN As System.Drawing.Color = System.Drawing.Color.Cyan '���F = &HFFFF00
	'UPGRADE_NOTE: Cn_WHITE �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_WHITE As System.Drawing.Color = System.Drawing.Color.White '���F = &HFFFFFF
	'
	'UPGRADE_NOTE: Cn_ClBrightON �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_ClBrightON As System.Drawing.Color = System.Drawing.Color.Yellow '���F = &HFFFF&
	'Public Const Cn_ClBrightON = vbCyan     '���F = &HFFFF00
	Public Const Cn_ClIncomplete As Integer = &H808000 '�ΐF = &H808000
	'Public Const Cn_ClIncomplete = vbBlack  '���F = &H0&
	'UPGRADE_NOTE: Cn_ClCheckError �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_ClCheckError As System.Drawing.Color = System.Drawing.Color.Red '�ԐF = &HFF&
	'Public Const Cn_ClCheckError = &H8080FF '���邢�ԐF
	'UPGRADE_NOTE: Cn_ClRelCheck �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_ClRelCheck As System.Drawing.Color = System.Drawing.Color.Magenta '���F = &HFF00FF
	'UPGRADE_NOTE: Cn_ClChecked �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_ClChecked As System.Drawing.Color = System.Drawing.Color.Black '���F = &H0&
	'UPGRADE_NOTE: Cn_ClIndicator �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_ClIndicator As System.Drawing.Color = System.Drawing.Color.White '���F = &HFFFFFF
	'UPGRADE_NOTE: Cn_ClNormalBack �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_ClNormalBack As System.Drawing.Color = System.Drawing.Color.White '���F = &HFFFFFF
	'
	'UPGRADE_NOTE: Cn_ClPromptStatus �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_ClPromptStatus As System.Drawing.Color = System.Drawing.Color.Blue '�F = &HFF0000
	'UPGRADE_NOTE: Cn_ClErrorStatus �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public Cn_ClErrorStatus As System.Drawing.Color = System.Drawing.Color.Red '�ԐF = &HFF&
	'
	Public Const Cn_ai21 As Boolean = False
	'
	Public AE_Title As String
	'
	Public AE_NL As String 'New Line (CRLF) �R�[�h
	'
	'Private AE_LogPointer As Integer
	'Private AE_LogBody$(100)
	'
	'�A�v���̎��s���ɏo�͂����W�����b�Z�[�W��ύX������A�o�͂�}�~�����肷���
	'�́A�悸���̃��W���[���̖��O AE_MSGL0.BAS ��ύX���Ă��������B
	'�Ȃ��A���O��ύX����ɂ́AVisual Basic �́w�t�@�C��(F)�x�Ƃ������j���[���J��
	'�āA�w���O��t���ăt�@�C���̕ۑ�(A)...�x�Ƃ���������s���Ă��������B
	'�����āA�v���V�W�� AE_MsgLibrary �̒��̈ȉ��̂悤�ȓ_���̊ԂɍX�V�X�e�b�v��
	'�}�����Ă��������B
	'
	'------------------------------------------------------------------ 'Original
	'�i����͌��{�ł��̂ŁA�����ɑ}�����Ă͂����܂���B�j
	'------------------------------------------------------------------ 'Original
	'
	'�Ⴆ�΁A���b�Z�[�W�R�[�h "APPEND" �� "�`�[�𔭍s���܂��B" �Ƃ������b�Z�[�W��
	'�o�͂�}�~���A���b�Z�[�W�R�[�h "APPENDC" �� "�f�[�^�G���g���Ɉڍs���܂��B"
	'�Ƃ������b�Z�[�W�� "�ݏo���Ɩ��Ɉڍs���܂��B" �Ƃ������b�Z�[�W�ɕύX����ɂ�
	'�_���̊ԂɈȉ��̂悤�ȍX�V�X�e�b�v��}�����܂��B
	'�Ȃ��A�ȉ��ł͍X�V�X�e�b�v���R�����g�ɂȂ��Ă��܂����A�����ɂ̓R�����g������
	'���Ȃ����߂ɂ����Ȃ��Ă���킯�ŁA���ۂɂ̓R�����g�ɂ��Ȃ��ł��������B
	'
	'------------------------------------------------------------------ 'Original
	'        Case "APPEND"
	'        Case "APPENDC"
	'            If AE_MsgBox("�ݏo���Ɩ��Ɉڍs���܂��B", vbQuestion + vbOkCancel, AE_Title$) <> vbOk Then AE_MsgLibrary = True
	'------------------------------------------------------------------ 'Original
	'
	
	'�L�[�C���\�ȕ������ǂ����̔���B
	Public Function AE_KeyInOkChar(ByRef PP As clsPP, ByRef Pm_Moji As String, ByVal Pm_KeyInOkClass As Short) As Boolean
		AE_KeyInOkChar = False
		If PP.Mode = Cn_Mode3 Then Exit Function '---------- 'V6.54I
		Select Case UCase(Chr(Pm_KeyInOkClass))
			Case "0" '����
				If Pm_Moji >= "0" And Pm_Moji <= "9" Then AE_KeyInOkChar = True
			Case "1", "2", "3" '�����P�������� 'V4.30
				If Pm_Moji >= "0" And Pm_Moji <= "9" Then AE_KeyInOkChar = True
			Case "A" 'Alphanumeric
				Select Case Pm_Moji
					Case "A" To "Z", "a" To "z", "0" To "9", "-", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "B" 'Basic Idetifier
				Select Case Pm_Moji
					Case "A" To "Z", "a" To "z", "0" To "9", "_"
						AE_KeyInOkChar = True
				End Select
			Case "C" 'Currency
				If InStr("0123456789+-. ", Pm_Moji) > 0 Then AE_KeyInOkChar = True
				'
				'-------�J���v���W�F�N�g���Ƃɒ�`���镔��(�J�n) --------
			Case "D" 'Project Definition 1
				Pm_Moji = UCase(Pm_Moji) 'V4.24
				If Asc(Pm_Moji) >= 0 And Asc(Pm_Moji) < 256 And Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Space(1) Then AE_KeyInOkChar = True 'V4.24
			Case "E" 'Project Definition 2
				Pm_Moji = UCase(Pm_Moji) 'V4.25
				Select Case Pm_Moji
					Case "�" To "�", "0" To "9", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "F" 'Project Definition 3
				Pm_Moji = UCase(Pm_Moji)
				Select Case Pm_Moji
					Case "A" To "Z", "0" To "9", "-", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "G" 'Project Definition 4
				Pm_Moji = UCase(Pm_Moji)
				Select Case Pm_Moji
					Case "A" To "Z", "0" To "9", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "H" 'Project Definition 5
				Pm_Moji = UCase(Pm_Moji) 'V4.34
				If Asc(Pm_Moji) >= 0 And Asc(Pm_Moji) < 256 And Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) Then AE_KeyInOkChar = True 'V4.34
				'-------�J���v���W�F�N�g���Ƃɒ�`���镔��(�I��) --------
				'
			Case "K" 'Katakana
				If Pm_Moji = "�@" Then Pm_Moji = Space(1) '�S�p�󔒕ϊ�
				Select Case Pm_Moji
					Case "�" To "�", "0" To "9", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "L" 'Lower Case
				Pm_Moji = LCase(Pm_Moji)
				Select Case Pm_Moji
					Case "a" To "z", "0" To "9", "-", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "M" '�Q�o�C�g�R�[�h
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Pm_Moji$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If LenWid(Pm_Moji) = 2 Then
					AE_KeyInOkChar = True
				ElseIf Pm_Moji = Space(1) Then  '�㍏�A�Q�o�C�g�����̃X�y�[�X�ɕϊ��B
					AE_KeyInOkChar = True
				End If
			Case "N" 'Nihongo (�󔒕ϊ�����)
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) Then AE_KeyInOkChar = True
			Case "S" 'Single Byte
				If Asc(Pm_Moji) >= 0 And Asc(Pm_Moji) < 256 And Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) Then AE_KeyInOkChar = True
				'If Asc(Pm_Moji$) >= 0 And Asc(Pm_Moji$) < 256 And Pm_Moji$ <> Chr$(vbKeyReturn) And Pm_Moji$ <> Chr$(vbKeyBack) And Pm_Moji$ <> Space$(1) Then AE_KeyInOkChar = True
			Case "T" '�d�b�ԍ�(Telephone Number)
				'            If InStr("0123456789-()", Pm_Moji$) > 0 Then AE_KeyInOkChar = True
				If InStr("0123456789-", Pm_Moji) > 0 Then AE_KeyInOkChar = True
			Case "U" 'Upper Case
				Pm_Moji = UCase(Pm_Moji)
				Select Case Pm_Moji
					Case "A" To "Z", "0" To "9", "-", Space(1)
						AE_KeyInOkChar = True
				End Select
			Case "V" 'Nihongo (�󔒕ϊ��Ȃ�)
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) Then AE_KeyInOkChar = True
			Case "W" '�a��
				Pm_Moji = UCase(Pm_Moji) 'If InStr("mtsh", Pm_Moji$) > 0 Then
				If InStr("MTSH", Pm_Moji) > 0 Then
					Pm_Moji = Mid("���叺��", InStr("MTSH", Pm_Moji), 1)
					AE_KeyInOkChar = True
				ElseIf InStr("0123456789���叺��", Pm_Moji) > 0 Then 
					AE_KeyInOkChar = True
				End If
			Case "Z" '�X�֔ԍ�(Zip Code)
				If InStr("0123456789- ", Pm_Moji) > 0 Then AE_KeyInOkChar = True
			Case "-" '��؂̕����̃C���v�b�g���s��
		End Select
	End Function
	
	
	Public Sub AE_Log(ByRef PP As clsPP, ByVal Pm_LogMsg As String)
		'    AE_LogBody$(AE_LogPointer) = PP.MainForm & Str$(Timer) & ": " & Pm_LogMsg$
		'    AE_LogPointer = AE_LogPointer + 1
		'    If AE_LogPointer >= 100 Then AE_LogPointer = 0
	End Sub
	
	'MsgBox �̑���ɁAAE_MsgBox ��p���邱�Ƃł��̕����̕ύX���ꊇ���Ăł���悤�ɂ��Ă���B
	Function AE_MsgBox(ByVal Pm_Msg As String, Optional ByVal Pm_MsgCode As Object = Nothing, Optional ByVal Pm_MsgTitle As Object = Nothing) As Object
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(Pm_MsgCode) Then
			'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
			If IsNothing(Pm_MsgTitle) Then
				AE_MsgBox = MsgBox(Pm_Msg)
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Pm_MsgTitle �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_MsgBox = MsgBox(Pm_Msg,  , Pm_MsgTitle)
			End If
		Else
			'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
			If IsNothing(Pm_MsgTitle) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Pm_MsgCode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_MsgBox = MsgBox(Pm_Msg, Pm_MsgCode)
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Pm_MsgTitle �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Pm_MsgCode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_MsgBox = MsgBox(Pm_Msg, Pm_MsgCode, Pm_MsgTitle)
			End If
		End If
	End Function
	
	'�A�v���̎��s���ɏo�͂����W�����b�Z�[�W�B
	Public Function AE_MsgLibrary(ByRef PP As clsPP, ByVal Pm_MsgCode As String) As Boolean 'Original
		Dim Wk_Msg As String 'Original
		Dim rtn As Short
		Dim frm As String
		'
		'���A�l AE_MsgLibrary ����U False �ɂ�����ɏ������s���B'Original
		AE_MsgLibrary = False 'Original
		'�Ȃ��A���A�l�� False ���ƒ��f�����ɏ������p�����邱�Ƃ��Ӗ�����B'Original
		'      ���A�l�� True ���Ə����𒆒f���邱�Ƃ��Ӗ�����B'Original
		'
		Call Init_Prompt()
		frm = Mid(SSS_PrgId, 4, 2)
		'
		AE_NL = Chr(13) & Chr(10) 'Original
		'
		PP.SlistCall = False
		'
		'SSS_VALKB(�L���f�[�^�敪)=True �̏ꍇ�A���׍s�Ȃ��ł��o�^��
		If SSS_VALKB = True Then
			Select Case UCase(Pm_MsgCode)
				Case "CURRENT", "NEXTCM", "PREVCM", "FIRSTCM", "LASTCM"
					AE_MsgLibrary = True
					Exit Function
			End Select
		End If
		'
		Select Case UCase(Pm_MsgCode) 'Original
			'�ȉ��̓_���̊ԂɍX�V�X�e�b�v��}�����Ă��������B'Original
			'------------------------------------------------------------------ 'SSS/Win
			'------------------------------------------------------------------ 'Original
			Case "APPEND" ' �f�[�^���X�V���܂��B
				If PP.MainForm = "SSSMAIN" Then
					Select Case frm
						Case "ET"
							If PP_sssmain.LastDe = 0 And SSS_VALKB = False Then
								rtn = DSP_MsgBox(SSS_EEE, "_APPEND", 2)
								AE_MsgLibrary = True
							ElseIf SSS_BILFL = 9 Then 
								If DSP_MsgBox(SSS_EEE, "_APPEND", 0) <> 6 Then AE_MsgLibrary = True
							End If
						Case "FP"
							If DSP_MsgBox(SSS_EEE, "_APPEND", 1) <> 6 Then AE_MsgLibrary = True
						Case "PR"
						Case Else
							If DSP_MsgBox(SSS_EEE, "_APPEND", 0) <> 6 Then AE_MsgLibrary = True
					End Select
				Else
					AE_MsgLibrary = False
				End If
			Case "APPENDC"
			Case "CANCEL" ' ���͓r���̃f�[�^�͔��f����܂���B
				PP.SuppressGotLostFocus = 1 'Original (Cancel �����̒��ŁA�ȉ��̂悤�� MsgBox �𔭂���ꍇ�ɂ̂ݕK�v�ł�) 'V6.47
				If DSP_MsgBox(SSS_EEE, "_CANCEL", 0) <> 6 Then AE_MsgLibrary = True
			Case "CLEARDE" ' �󔒂̖��׍s���ɍ폜���Ă��������B
				rtn = DSP_MsgBox(SSS_EEE, "_CLEARDE", 0)
			Case "COMPLETEC" ' �s���S�ȓ��͍��ڂ�����܂��B
				Beep()
				rtn = DSP_MsgBox(SSS_EEE, "_COMPLETEC", 0)
			Case "COPYDE", "COPYITEM" 'Original
				Beep()
				rtn = DSP_MsgBox(SSS_EEE, "_COPYDE", 0)
			Case "CURRENT" ' �f�[�^�����݂��܂���B
				rtn = DSP_MsgBox(SSS_EEE, "_CURRENT", 0)
			Case "CURSOR" ' ��ɏ�̍s����͂��Ă��������B
				rtn = DSP_MsgBox(SSS_EEE, "_CURSOR", 0)
			Case "DELETECM" ' �f�[�^���폜���܂��B
				If DSP_MsgBox(SSS_EEE, "_DELETECM", 0) <> 6 Then AE_MsgLibrary = True
			Case "ENDCK" ' �I�����܂��B
				If PP.MainForm = "SSSMAIN" Then
					Select Case frm
						'Case "PR"
						'Case "FP"
						'Case "DL"
						Case "DL", "FP", "PR"
							If DSP_MsgBox(SSS_EEE, "_ENDCM", 0) <> 6 Then AE_MsgLibrary = True
						Case Else
							If DSP_MsgBox(SSS_EEE, "_ENDCK", 0) <> 6 Then AE_MsgLibrary = True
					End Select
				Else
					AE_MsgLibrary = False
				End If
			Case "ENDCM" ' �I�����܂��B
				If PP.MainForm = "SSSMAIN" Then
					If DSP_MsgBox(SSS_EEE, "_ENDCM", 0) <> 6 Then AE_MsgLibrary = True
				Else
					AE_MsgLibrary = False
				End If
			Case "FIRSTC" ' �擪�̃f�[�^�Ɉڂ�܂��B
				If DSP_MsgBox(SSS_EEE, "_FIRSTC", 0) <> 6 Then AE_MsgLibrary = True
			Case "FIRSTCM" ' �f�[�^�����݂��܂���B
				rtn = DSP_MsgBox(SSS_EEE, "_FIRSTCM", 0)
			Case "HARDCOPY" ' ��ʂ̃C���[�W��������܂��B
				If DSP_MsgBox(SSS_EEE, "_HARDCOPY", 0) <> 6 Then AE_MsgLibrary = True
			Case "HARDCOPYERROR" ' �v�����^�[���m�F���Ă��������B
				rtn = DSP_MsgBox(SSS_EEE, "_HARDCOPYERROR", 0)
			Case "HEADCOMPLETEC" ' ���o���̓��͂��ɍς܂��Ă��������B
				Beep()
				rtn = DSP_MsgBox(SSS_EEE, "_HEADCOMPLETEC", 0)
			Case "INACTIVEDE" ' ���͉\�ȍ��ڂł͂���܂���B
				rtn = DSP_MsgBox(SSS_EEE, "_INACTIVEDE", 0)
			Case "INDICATE"
			Case "INSERTDE" ' ���ו��ɗ]�T������܂���B
				rtn = DSP_MsgBox(SSS_EEE, "_INSERTDE", 0)
			Case "LASTC" ' �Ō�̃f�[�^�Ɉڂ�܂��B
				If DSP_MsgBox(SSS_EEE, "_LASTC", 0) <> 6 Then AE_MsgLibrary = True
			Case "LASTCM" ' �f�[�^�����݂��܂���B
				rtn = DSP_MsgBox(SSS_EEE, "_LASTCM", 0)
				'Case "MUSTINPUT"
				'Rtn = DSP_MsgBox(SSS_EEE, "_MUSTINPUT", 0)
			Case "NEXTC"
			Case "NEXTCM" ' �Ō�̃f�[�^�ł��B
				rtn = DSP_MsgBox(SSS_EEE, "_NEXTCM", 0)
			Case "OUTPUTONLY" ' ���̍��ڂɂ͓��͂ł��܂���B
				rtn = DSP_MsgBox(SSS_EEE, "_OUTPUTONLY", 0)
			Case "PRECHECK1" 'Original 'V4.28
                'Call AE_StatusOut(PP, "���̍��ڂɂ̓C���v�b�g���K�v�ł��B", vbRed) 'Original 'V4.28
            Case "PRECHECK2" 'Original 'V4.28
				'Call AE_StatusOut(PP, "���̍��ڂɂ͍��[����E�[�܂ŕ������C���v�b�g���Ă��������B", vbRed) 'Original 'V4.28
			Case "QUERYUNLOAD" ' ���s���ł��B
				rtn = DSP_MsgBox(SSS_EEE, "_QUERYUNLOAD", 0)
			Case "PREVC" ' ��O�̃f�[�^�Ɉڂ�܂��B
			Case "PREVCM" ' �ŏ��̃f�[�^�ł��B
				rtn = DSP_MsgBox(SSS_EEE, "_PREVCM", 0)
			Case "RECALC" ' ��肪����܂��B�C�����Ă��������B
				rtn = DSP_MsgBox(SSS_EEE, "_RECALC", 0)
			Case "RELCHECK" ' ��ɃG���[���ڂ��C�����Ă��������B
				rtn = DSP_MsgBox(SSS_EEE, "_RELCHECK", 0)
			Case "SELECTCM" ' ���͓r���̃f�[�^�͔��f����܂���B
			Case "SELECTE" '1998/03/30  �ǉ�
			Case "UPDATE" ' �X�V���܂��B
				If PP.MainForm = "SSSMAIN" Then
					Select Case frm
						Case "ET"
							If PP_sssmain.LastDe = 0 And SSS_VALKB = False Then
								rtn = DSP_MsgBox(SSS_EEE, "_UPDATE", 2)
								AE_MsgLibrary = True
							ElseIf SSS_BILFL = 9 Then 
								If DSP_MsgBox(SSS_EEE, "_UPDATE", 0) <> 6 Then AE_MsgLibrary = True
							End If
						Case Else
							If DSP_MsgBox(SSS_EEE, "_APPEND", 0) <> 6 Then AE_MsgLibrary = True
					End Select
				End If
			Case "UPDATE2" ' �X�V���܂��B
				If PP.MainForm = "SSSMAIN" Then
					Select Case frm
						Case "ET"
							If PP_sssmain.LastDe = 0 And SSS_VALKB = False Then
								rtn = DSP_MsgBox(SSS_EEE, "_UPDATE2", 2)
								AE_MsgLibrary = True
							ElseIf SSS_BILFL = 9 Then 
								If DSP_MsgBox(SSS_EEE, "_UPDATE2", 0) <> 6 Then AE_MsgLibrary = True
							End If
						Case Else
							If DSP_MsgBox(SSS_EEE, "_APPEND", 0) <> 6 Then AE_MsgLibrary = True
					End Select
				End If
			Case "UPDATEC" ' ���͓r���̃f�[�^�͔��f����܂���B
			Case Else 'Original
				Wk_Msg = "�A�v���P�[�V�����J�����Ɏ��{�������b�Z�[�W�̕ύX�ɖ�肪����܂��B" 'Original
				Wk_Msg = Wk_Msg & AE_NL & "���b�Z�[�W�R�[�h�i" & Pm_MsgCode & "�j�̎󂯌��̃v���O����������܂���B" 'Original
				AE_MsgBox(Wk_Msg, MsgBoxStyle.Exclamation, AE_Title) 'Original
		End Select
	End Function 'Original
	
	Public Sub AE_Stop()
		'Dim LogF
		'Dim LogFName$
		'Dim I As Integer
		'    LogFName$ = App.Path & "\@ApplLog.LOG" '���O�t�@�C����
		'    LogF = FreeFile
		'    Open LogFName$ For Output As #LogF
		'    Print #LogF, "LogPointer = " & CStr(AE_LogPointer) & "     (Next Point to Log)"
		'    For I = 0 To 99
		'        Print #LogF, "Log[" & Right$("00" & CStr(I), 2) & "] = """ & AE_LogBody$(I) & """"
		'    Next I
		'    Close #LogF
		Call Error_Exit("AE_Stop �ɂ�钆�f")
		'   Stop
	End Sub
End Module