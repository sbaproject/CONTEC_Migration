Option Strict Off
Option Explicit On
Module AE_PROC
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'Common Library 1 V6.60 '���x���A�b�v�̍ۂɕύX�B
	'
	Declare Function CspAddAltKeyCode Lib "AE_SUP32.DLL" (ByVal fhWnd As Integer, ByVal hwnd As Integer, ByVal ReqC As Integer) As Integer
	Declare Function CspDelAltKeyCode Lib "AE_SUP32.DLL" (ByVal fhWnd As Integer, ByVal hwnd As Integer, ByVal ReqC As Integer) As Integer
	Declare Function CspPurgeFilterReq Lib "AE_SUP32.DLL" (ByVal fhWnd As Integer) As Integer
	Declare Function SendMessage Lib "user32"  Alias "SendMessageA"(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer 'V4.33
	Declare Function SetTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
	Declare Function ReleaseTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
	Declare Function ImmGetContext Lib "imm32.dll" (ByVal hwnd As Integer) As Integer
	Declare Function ImmReleaseContext Lib "imm32.dll" (ByVal hwnd As Integer, ByVal hIMC As Integer) As Integer
	Declare Function ImmGetCompositionString Lib "imm32.dll"  Alias "ImmGetCompositionStringA"(ByVal hIMC As Integer, ByVal dw As Integer, ByVal lpv As String, ByVal dw2 As Integer) As Integer
	Declare Function CallWindowProc Lib "user32"  Alias "CallWindowProcA"(ByVal lpPrevWndFunc As Integer, ByVal hwnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer 'V6.59Pop
	Declare Function SetWindowLong Lib "user32"  Alias "SetWindowLongA"(ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer 'V6.59Pop
	Private Declare Function GetClassName Lib "user32"  Alias "GetClassNameA"(ByVal hwnd As Integer, ByVal lpClassName As String, ByVal nMaxCount As Integer) As Integer 'V6.59Pop
	Public Const GWL_WNDPROC As Short = -4 'V6.59Pop
	
	Public Function AE_BodyPx(ByRef PP As clsPP, ByVal pm_Px As Object, ByVal pm_Index As Object) As Short 'V5.39
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Px �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_BodyPx = PP.BodyPx + ((pm_Px - PP.BodyPx + PP.BodyV) Mod PP.BodyV) + PP.BodyV * pm_Index
	End Function
	
	Public Function AE_Change(ByRef PP As clsPP, ByRef CP As clsCP, ByRef Ct As Object) As Boolean
		'Non Static Sub
		'pm_Value ----> PP.NewVal
		'pm_TA$ ----> CP.TpStr
		Dim wk_ItemFlag As Boolean '�f�[�^���ڂ̋�؂�Ȃ� True �ɂ���B
		Dim wk_Tx As Short
		Dim wk_Ln As Integer
		Dim wk_LnB As Integer
		Dim wk_MaxLB As Integer
		Dim wk_AutoEnter As Short
		Dim wk_Ln2 As Integer
		Dim wk_Moji As String
		Dim wk_Pad As Short
		Dim wk_SaveMaskMode As Boolean
		Dim wk_SSorg As Integer
		Dim wk_SS As Integer
		Dim wk_LastSS As Integer 'V4.30
		Dim wk_WkSS As Integer
		Dim wk_LenTxt As Integer
		Dim wk_BeepSw As Boolean
		Dim wk_Txt As String
		Dim wk_CurTxt As String
		Dim wk_FractionC As Short
		Dim wk_NewTxt As String
		Dim wk_Pos As Short
		Dim wk_FracN As Short
		Dim wk_FormatChr As String 'V4.31
		'
		'PP.InitValStatus = Cn_ModeDataChanged 'AE_InitVal �Ȃǂ̌�ɉ�ʂւ̃C���v�b�g����B
		Call AE_SetInitValStatus(PP, CP) 'V6.56S
		'
		wk_BeepSw = False
		wk_ItemFlag = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_CurTxt = Ct
		wk_Txt = wk_CurTxt
		'LenWid ��p����B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_LnB = LenWid(wk_Txt)
		'
		'Auto Enter �w��̍��ڂɂ��ẮA���{��̃C���v�b�g�� IME �ϊ����ꂽ�擪����
		'�̕�����ō��ڃt���ɂȂ�ƁA�㑱�̕ϊ���������󂯂�Ƃ��� PP.Tx �̕����i��
		'�ł��邪�ACt.TabIndex �̕��͌��̂܂܂Ȃ̂ŁAPP.Tx <> Ct.TabIndex �ƂȂ邱��
		'������B�Ȃ��A���̂Ƃ��Ƀ{�f�B�����X�N���[������P�[�X�ɂ����ẮA�X�N���[��
		'��� Ct.TabIndex �� PP.Tx ����v���Ă��܂��ꍇ�i�Ⴆ�΁A�{�f�B���ɍ��ڂ����
		'�����Ȃ��ꍇ�j�ɂ́A���̌��ۂ͊ɘa�����B
		wk_Tx = PP.Tx
		'
		If CP.CIn = Cn_NoInput Then '0: No Input
			If wk_Txt <> CP.TpStr Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If PP.Tx <> Ct.TabIndex Then 'V6.45
					Call AE_SystemError("AE_Change ��", 104)
					Exit Function '--------------------
				ElseIf CP.KeyInOkClass = Asc("N") Then  'Or CP.KeyInOkClass = Asc("M") Then
					'���p�󔒂ւ̕ϊ�
					wk_SS = 1
					Do While wk_SS <= Len(wk_Txt)
						If CP.KeyInOkClass = Asc("N") Then
							If Mid(wk_Txt, wk_SS, 1) = "�@" Then '�Q�o�C�g�����̃X�y�[�X�B
								wk_Txt = Left(wk_Txt, wk_SS - 1) & Space(2) & Mid(wk_Txt, wk_SS + 1)
								wk_SS = wk_SS + 1
								GoTo AE_ChangeSet '---------->
							End If
						End If
						wk_SS = wk_SS + 1
					Loop 
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_SS = Ct.SelStart
					CP.TpStr = wk_Txt
					GoTo AE_ChangeRet '---------->
				ElseIf CP.KeyInOkClass = Asc("M") Or CP.KeyInOkClass = Asc("V") Then 
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_SS = Ct.SelStart
					CP.TpStr = wk_Txt
					GoTo AE_ChangeRet '---------->
				Else
					wk_SS = 1
					Do While wk_SS <= Len(wk_Txt)
						'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Mid$(wk_Txt$, wk_SS, 1)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If LenWid(Mid(wk_Txt, wk_SS, 1)) = 2 Then
							Beep()
							wk_BeepSw = True 'V4.24
							wk_Txt = Left(wk_Txt, wk_SS - 1) & Mid(CP.TpStr, wk_SS, 1) & Mid(wk_Txt, wk_SS + 1) 'V4.05
							wk_SS = wk_SS - 1
							GoTo AE_ChangeSet '---------->
						End If
						wk_SS = wk_SS + 1
					Loop 
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_SS = Ct.SelStart
					CP.TpStr = wk_Txt
					GoTo AE_ChangeRet '---------->
				End If
AE_ChangeSet: 
				CP.TpStr = wk_Txt
				wk_SaveMaskMode = PP.MaskMode
				PP.MaskMode = True
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ct = wk_Txt
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ct.SelStart = wk_SS
				PP.MaskMode = wk_SaveMaskMode
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_SS = Ct.SelStart
			End If
AE_ChangeRet: 
			AE_Change = True '(wk_ItemFlag)
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ct.SelLength = PP.Override
			'V6.45 �ŁA���̏�Ɉړ��B
			'If PP.Tx <> Ct.TabIndex Then Exit Function '--------------------
			GoTo AE_ChangeLabel1 '---------->
		End If
		'V4.16
		If CP.KeyInOkClass = Asc("M") Then
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_SS = Ct.SelStart
			wk_NewTxt = ""
			wk_WkSS = 1
			wk_LenTxt = Len(RTrim(wk_Txt))
			Do While wk_WkSS <= wk_LenTxt
				If Mid(wk_Txt, wk_WkSS, 1) = Space(1) Then
					wk_NewTxt = wk_NewTxt & "�@" '�Q�o�C�g�����̃X�y�[�X�B
				Else
					wk_NewTxt = wk_NewTxt & Mid(wk_Txt, wk_WkSS, 1)
				End If
				wk_WkSS = wk_WkSS + 1
			Loop 
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(wk_NewTxt$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If wk_LnB >= LenWid(wk_NewTxt) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_Txt = wk_NewTxt & Space(wk_LnB - LenWid(wk_NewTxt))
			Else
				wk_Txt = MidWid(wk_NewTxt, 1, wk_LnB)
			End If
			CP.TpStr = wk_Txt
			wk_SaveMaskMode = PP.MaskMode
			PP.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ct = wk_Txt
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ct.SelStart = wk_SS
			PP.MaskMode = wk_SaveMaskMode
		End If
		'
		'�ȉ��̐������̃`�F�b�N�́ACP.CIn = Cn_NoInput �̃`�F�b�N�̌�ɂ���B
		If wk_Tx < 0 Or wk_Tx >= PP.ControlsC Then
			Call AE_SystemError("AE_Change ��", 100)
			AE_Change = False '(wk_ItemFlag)
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CP.TypeA = Cn_NormalOrV Then Ct.SelLength = PP.Override
			Exit Function '--------------------
		End If
		'
		wk_AutoEnter = (CP.AutoEnter And Cn_AutoEnter) And (CP.KeyInOkClass <> Asc("M")) And (CP.KeyInOkClass <> Asc("V")) And (CP.KeyInOkClass <> Asc("N")) And (CP.KeyInOkClass <> Asc("K")) 'V6.45 'V6.53
		'
		If CP.TypeA = Cn_InputOnly Then
			wk_ItemFlag = Not PP.ComboUpDown And wk_AutoEnter = Cn_AutoEnter
			PP.ComboUpDown = False
			GoTo AE_ChangeReFormat '---------->
		End If
		'
		'LenWid ��p����B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_LnB = LenWid(wk_Txt)
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_SSorg = Ct.SelStart 'V4.30
		wk_SS = wk_SSorg 'V4.30
		wk_MaxLB = CP.MaxLength ': If InStr(wk_Txt$, "-") = 0 Then wk_MaxLB = wk_MaxLB - 1 'V6.45
		'�o�b�N�X�y�[�X�܂��̓f���[�g�̏ꍇ�B
		If CP.CIn = Cn_BSorDL Then '1: Back Space or Delete
			CP.CIn = Cn_NoInput '0: No Input
			If wk_MaxLB > 0 Then
				If CP.Alignment <> 1 Then '���l��/(����)
					wk_Txt = wk_Txt & Space(wk_MaxLB - wk_LnB)
				Else '�E�l��
					'�ʉݕ\���̏ꍇ�� \ �����������B
					wk_Txt = Space(wk_MaxLB - wk_LnB) & wk_Txt
					If Right(wk_Txt, 1) = "\" Then 'V4.31
						If Left(CP.FormatChr, 2) = "\\" Then wk_Txt = Space(wk_MaxLB)
					End If 'V4.31
					wk_SS = wk_SS + (wk_MaxLB - wk_LnB)
				End If
			End If
			GoTo AE_ChangeReFormat '----------> 'Skip to AE_ChangeReFormat when Back Space or Delete
		End If
		'
		CP.CIn = Cn_NoInput '0: No Input
		'
		'���c�m�s�a�Ŕ���������Q�H������B'V6.48
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabStop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (Not Ct.TabStop Or Not Ct.Enabled Or Not Ct.Visible) And Not AE_SSSWin Then 'V6.48
			'���������s����邱�Ƃ͂Ȃ��H
			Call AE_SystemError("AE_Change ��", 101)
			AE_Change = False '(wk_ItemFlag)
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CP.TypeA = Cn_NormalOrV Then Ct.SelLength = PP.Override
			Exit Function '--------------------
		End If
		If wk_MaxLB > 0 Then
			wk_Ln = Len(wk_Txt)
			If CP.FixedFormat <> 1 Then
				'������̒����̃`�F�b�N�B
				wk_NewTxt = AE_Format(CP, AE_Val(CP, wk_Txt, wk_FractionC), 0, True) '�m�肾�Ɖ��肵�ĕ���������߂�B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_Ln2 = LenWid(Trim(wk_NewTxt))
				If wk_Ln2 > wk_MaxLB Or wk_Ln2 > wk_MaxLB - 1 And (CP.FormatClass = Cn_Snum Or CP.FormatClass = Cn_Schn) And InStr(wk_NewTxt, "-") = 0 Then 'V6.50N '������
					Beep()
					If wk_SS > 0 And wk_SS + 1 <= wk_Ln Then
						If Mid(CP.TpStr, wk_SS, 1) = "." Then
							wk_Txt = Left(wk_Txt, wk_SS - 1) & "." & Mid(wk_Txt, wk_SS + 1, wk_Ln - wk_SS)
						Else
							wk_Txt = Left(wk_Txt, wk_SS - 1) & Mid(wk_Txt, wk_SS + 1, wk_Ln - wk_SS)
						End If
					ElseIf wk_SS > 0 And wk_SS = wk_Ln Then 
						wk_Txt = Left(wk_Txt, wk_SS - 1)
					End If
					GoTo AE_ChangeLabel1 '---------->
				End If
			ElseIf PP.Override = 0 Then  'And CP.FixedFormat = 1
				'�Œ�J�����̏����B
				If wk_SS > 0 And wk_SS + 1 <= wk_Ln Then
					wk_Txt = Left(wk_Txt, wk_SS - 1) & Mid(wk_Txt, wk_SS + 1, wk_Ln - wk_SS)
				ElseIf wk_SS > 0 And wk_SS = wk_Ln Then 
					wk_Txt = Left(wk_Txt, wk_SS - 1)
				End If
			End If
		End If
		'�Q�o�C�g�����̃X�y�[�X��ύX����B
		If wk_SS > 0 And CP.KeyInOkClass <> Asc("M") And CP.KeyInOkClass <> Asc("V") Then 'V4.19
			If Mid(wk_Txt, wk_SS, 1) = "�@" Then '�Q�o�C�g�����̃X�y�[�X�B
				wk_Txt = Left(wk_Txt, wk_SS - 1) & Space(2) & Mid(wk_Txt, wk_SS + 1)
				wk_SS = wk_SS + 1
			End If
		End If
		'
AE_ChangeLabel1: 
		If wk_MaxLB > 0 And CP.Alignment <> 1 Then '���l��/(����)
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(wk_Txt$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do While LenWid(wk_Txt) > wk_MaxLB 'Len �ł̓_���B
				If Right(wk_Txt, 1) <> Space(1) Then
					Beep()
					wk_BeepSw = True
					If PP.Override = 0 And Mid(wk_Txt, wk_SS + 1) <> "" Then
						wk_Txt = Left(wk_Txt, wk_SS - 1) & Mid(wk_Txt, wk_SS + 1)
					Else
						wk_Txt = Left(wk_Txt, Len(wk_Txt) - 1)
					End If
				Else
					wk_Txt = Left(wk_Txt, Len(wk_Txt) - 1)
				End If
			Loop 
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_LnB = LenWid(wk_Txt) 'Len �ł̓_���B
			If wk_LnB < wk_MaxLB Then wk_Txt = wk_Txt & Space(wk_MaxLB - wk_LnB)
			'
			wk_Ln = Len(wk_Txt)
			Do While wk_SS < wk_Ln
				wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
				If wk_Moji = Space(1) Or AE_KeyInOkChar(PP, wk_Moji, CP.KeyInOkClass) Then Exit Do '----------
				wk_SS = wk_SS + 1
			Loop 
			wk_LastSS = wk_SS
			Do While wk_LastSS < wk_Ln
				wk_Moji = Mid(wk_Txt, wk_LastSS + 1, 1)
				If wk_Moji = Space(1) Then Exit Do '----------
				wk_LastSS = wk_LastSS + 1
			Loop 
			'wk_ItemFlag = True �ɂ���ŏ��̃R�[�h�B
			If wk_AutoEnter = 1 And wk_BeepSw = False Then
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Left$(wk_Txt$, wk_LastSS)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If PP.Override = 0 And LenWid(Left(wk_Txt, wk_LastSS)) >= wk_MaxLB And CP.FixedFormat <> 1 Then wk_ItemFlag = True
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Left$(wk_Txt$, wk_SS)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If LenWid(Left(wk_Txt, wk_SS)) >= wk_MaxLB Then wk_ItemFlag = True
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_LnB = LenWid(Trim(wk_Txt)) 'Len �ł̓_���B'V4.30
				If CP.KeyInOkClass = Asc("1") And wk_LnB >= 1 Then wk_ItemFlag = True 'V4.18
				If CP.KeyInOkClass = Asc("2") And wk_LnB >= 2 And wk_SSorg >= 2 Then wk_ItemFlag = True 'V4.30
				If CP.KeyInOkClass = Asc("3") And wk_LnB >= 3 And wk_SSorg >= 3 Then wk_ItemFlag = True 'V4.30
			End If
		ElseIf wk_MaxLB > 0 And CP.Alignment = 1 Then  '�E�l��
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(wk_Txt$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Do While wk_SS > 0 And LenWid(wk_Txt) > wk_MaxLB 'Len �ł̓_���B
				If Left(wk_Txt, 1) <> Space(1) Then
					Beep()
					wk_BeepSw = True
					If PP.Override = 0 And Mid(wk_Txt, wk_SS + 1) <> "" Then
						wk_Txt = Left(wk_Txt, wk_SS - 1) & Mid(wk_Txt, wk_SS + 1)
					Else
						wk_Txt = Left(wk_Txt, Len(wk_Txt) - 1) 'Right �łȂ��B
					End If
				Else
					wk_Txt = Right(wk_Txt, Len(wk_Txt) - 1)
				End If
				wk_SS = wk_SS - 1
			Loop 
			'LenWid ��p����B
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_Pad = wk_MaxLB - LenWid(RTrim(wk_Txt))
			'If wk_Pad > 0 Then wk_Txt$ = Space$(wk_Pad) & wk_Txt$: wk_SS = wk_SS + wk_Pad
			If wk_Pad > 0 Then 'V6.55
				wk_Txt = Space(wk_Pad) & wk_Txt 'V6.55
				'�u���� If AE_Numerical(CP.FormatClass) Or Not AE_KeyInOkChar(PP, Space$(1), CP.KeyInOkClass) Then wk_SS = wk_SS + wk_Pad 'V6.55
				wk_SS = wk_SS + wk_Pad 'V6.60
			End If 'V6.55
			wk_Ln = Len(wk_Txt)
			Do While wk_SS < wk_Ln
				wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
				If Cn_ai21 And AE_Numerical(CP.FormatClass) Then 'V6.53
					If wk_Moji = Space(1) Or (AE_KeyInOkChar(PP, wk_Moji, CP.KeyInOkClass) And wk_Moji <> ".") Then GoTo AE_ChangeLabel2 '----------> 'V6.53
				Else 'V6.53
					If wk_Moji = Space(1) Or AE_KeyInOkChar(PP, wk_Moji, CP.KeyInOkClass) Then GoTo AE_ChangeLabel2 '---------->
				End If
				wk_SS = wk_SS + 1
			Loop 
			'wk_SS = wk_Ln �Ƃ�����B
			If wk_AutoEnter = 1 And wk_BeepSw = False Then
				If Left(wk_Txt, 1) <> Space(1) Then
					wk_ItemFlag = True '�E�l�߂ō��[���X�y�[�X�łȂ��B
					'ElseIf Left$(wk_NewTxt$, 1) <> Space$(1) Then 'V4.32
				ElseIf Left(wk_NewTxt, 1) <> Space(1) And Not (AE_SSSWin And Left(CP.FormatChr, 1) = "0") And InStr(CP.FormatChr, ".") = 0 Then  'V4.33
					wk_ItemFlag = True '�E�l�߂ō��[���X�y�[�X�łȂ��B
					'ElseIf CP.FixedFormat <> 1 And LenWid(Trim$(wk_NewTxt$)) >= wk_MaxLB And wk_MaxLB > 0 Then
				ElseIf CP.FixedFormat <> 1 And (wk_Ln2 >= wk_MaxLB Or wk_Ln2 >= wk_MaxLB - 1 And (CP.FormatClass = Cn_Snum Or CP.FormatClass = Cn_Schn) And InStr(wk_NewTxt, "-") = 0) And wk_MaxLB > 0 Then  'V6.48 'V6.50N '������
					If InStr(wk_NewTxt, ".") > 0 Then
						If InStr(wk_Txt, ".") = InStr(wk_NewTxt, ".") Then wk_ItemFlag = True
						'Else 'V4.21
					ElseIf Not AE_SSSWin Then  'V4.24
						'wk_ItemFlag = True 'V4.21 #,##0 �̂悤�ɕҏW��A����������������ꍇ�B
						'���� Or �������A�Q�������A- ���́AAutoEnter 'V6.50
						If (CP.FormatClass <> Cn_Snum And CP.FormatClass <> Cn_Schn) Or wk_MaxLB <> 2 Or ((Ct) <> " -" And (Ct) <> "  -") Then wk_ItemFlag = True 'V6.48 'V6.50N '������
					End If
				ElseIf InStr(CP.FormatChr, ".") > 0 Then  'V4.31
					'�����_�̂���ꍇ (�t�����͏�Ń`�F�b�N�ς�)�B
					wk_Pos = InStr(CP.FormatChr, ";") 'V4.31
					If wk_Pos = 0 Then 'V4.31
						wk_FormatChr = CP.FormatChr 'V4.31
					Else 'V4.31
						wk_FormatChr = Left(CP.FormatChr, wk_Pos - 1) 'V4.31
					End If 'V4.31
					wk_Pos = InStr(wk_FormatChr, ".") 'V4.31
					If wk_Pos > 0 Then 'V4.31
						wk_FracN = Len(wk_FormatChr) - wk_Pos 'V4.31
						'
						wk_Pos = InStr(wk_Txt, ".") 'V4.31
						If wk_Pos > 0 Then 'V4.31
							If wk_FracN = Len(wk_Txt) - wk_Pos Then wk_ItemFlag = True 'V4.31
						End If 'V4.31
					End If 'V4.31
				End If
			End If
AE_ChangeLabel2: 
			'ElseIf wk_MaxLB = 0 And AE_Numerical(CP.FormatClass) Then 'V6.50
		End If
		'
AE_ChangeReFormat: 
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP.NewVal = AE_Val(CP, wk_Txt, wk_FractionC)
		If CP.KeyInOkClass = Asc("V") Then
			If CP.FormatChr = "" And CP.FormatClass <> Cn_Date And Not AE_Numerical(CP.FormatClass) Then
				wk_NewTxt = wk_Txt
			Else
				wk_NewTxt = AE_Format(CP, wk_Txt, 0, False)
			End If
		Else
			wk_NewTxt = AE_Format(CP, PP.NewVal, wk_FractionC, False)
		End If
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(wk_NewTxt$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(wk_NewTxt) > wk_MaxLB And wk_MaxLB > 0 Then
			Beep()
			If CP.Alignment <> 1 Then '���l��/(����)
				wk_NewTxt = LeftWid(wk_NewTxt, wk_MaxLB) '�Q�o�C�g�����̓r���B
			Else
				wk_NewTxt = RightWid(wk_NewTxt, wk_MaxLB)
			End If
		End If
		'
		If CP.TypeA = Cn_NormalOrV Then
			If CP.Alignment <> 1 Then '���l��/(����)
				wk_SS = wk_SS + Len(RTrim(wk_NewTxt)) - Len(RTrim(wk_Txt))
				If wk_SS < 0 Then wk_SS = 0
			End If
			'
			wk_SaveMaskMode = PP.MaskMode
			PP.MaskMode = True
			If wk_NewTxt <> wk_CurTxt Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ct = wk_NewTxt
				wk_CurTxt = wk_NewTxt
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ct.SelStart = wk_SS
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ct.SelLength = PP.Override
			PP.MaskMode = wk_SaveMaskMode
		End If
		'
		CP.TpStr = wk_NewTxt
		'
		CP.StatusC = Cn_Status1 'Incomplete
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Ct.ForeColor = AE_Color(Cn_Status1) 'Incomplete
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CP.TypeA = Cn_NormalOrV Or CP.TypeA = Cn_InputOnly Then Ct.BackColor = PP.BrightOnOff
		'
		If PP.Tx >= PP.BodyTx And PP.Tx < PP.EBodyTx Then
			If PP.ActiveDe = PP.De Then
				PP.ActiveDe = -1 : Call AE_ScrlMax(PP)
				'ElseIf PP.ActiveDe < 0 And PP.DeApendable Then '���� wk_DeC = 0
			ElseIf PP.ActiveDe < 0 And AE_GetDeApendable(PP) Then  '���� wk_DeC = 0 'V6.55I
				'If PP.De > PP.LastDe Then
				If Not PP.AllowNullDes And (PP.De > PP.LastDe) Then 'V6.47B
					Call AE_SystemError("AE_Change ��", 102)
				End If
				If PP.De >= PP.LastDe Then
					PP.LastDe = PP.De + 1 : Call AE_ScrlMax(PP)
					'LastReadDe �̏����͕s�v�B'V6.47(5)
					If PP.UniScrl Then PP.LastEDe = PP.De + 1 : Call AE_EScrlMax(PP) 'V6.46
					'LastReadEDe �̏����͕s�v�B'V6.47(5)
				End If
				'ElseIf PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then
				'No Operation
			End If
		ElseIf PP.Tx >= PP.EBodyTx And PP.Tx < PP.TailTx Then  'V4.26
			If PP.ActiveEDe = PP.De Then
				PP.ActiveEDe = -1 : Call AE_EScrlMax(PP)
				'ElseIf PP.ActiveEDe < 0 And PP.EDeApendable Then '���� wk_EDeC = 0
			ElseIf PP.ActiveEDe < 0 And AE_GetEDeApendable(PP) Then  '���� wk_EDeC = 0 'V6.55I
				'If PP.De > PP.LastEDe Then
				If Not PP.AllowNullDes And (PP.De > PP.LastEDe) Then 'V6.47B
					Call AE_SystemError("AE_Change ��", 103)
				End If
				If PP.De >= PP.LastEDe Then
					PP.LastEDe = PP.De + 1 : Call AE_EScrlMax(PP)
					'LastReadEDe �̏����͕s�v�B'V6.47(5)
					If PP.UniScrl Then PP.LastDe = PP.De + 1 : Call AE_ScrlMax(PP) 'V6.46
					'LastReadDe �̏����͕s�v�B'V6.47(5)
				End If
				'ElseIf PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then
				'No Operation
			End If
		End If
		AE_Change = wk_ItemFlag
	End Function
	
	'Direction �̕ύX�B
	Public Function AE_ChangeDirection(ByVal pm_Direction As Short) As Short
		Select Case pm_Direction
			Case Cn_Direction3
				AE_ChangeDirection = Cn_Direction1
			Case Cn_Direction4
				AE_ChangeDirection = Cn_Direction2
			Case Else
				AE_ChangeDirection = pm_Direction
		End Select
	End Function
	
	'�\�����ڂւ̃y�[�X�g��}�~����B
	Public Function AE_ChangePre(ByRef PP As clsPP, ByRef CP As clsCP, ByRef Ct As Object) As Boolean
		Dim wk_SaveMaskMode As Boolean 'V7.00
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If PP.Tx <> Ct.TabIndex Then
			wk_SaveMaskMode = PP.MaskMode
			PP.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ct = CP.TpStr
			PP.MaskMode = wk_SaveMaskMode
			AE_ChangePre = True
		Else
			AE_ChangePre = False
		End If
	End Function
	
	'���샂�[�h(Mode)���㍏�ύX����BCheck �����C�x���g���[�`���̒��ȊO����̌Ăяo���͋֎~�ł��B
	Public Function AE_ChOprtLater(ByRef PP As clsPP, ByVal pm_Mode As Short) As Boolean
		If PP.RecalcMode = True Then AE_ChOprtLater = True : Exit Function '--------------------
		'
		If pm_Mode <> PP.Mode Then
			Select Case pm_Mode
				Case Cn_Mode1
					If AE_MsgLibrary(PP, "AppendC") Then AE_ChOprtLater = False : Exit Function '--------------------
				Case Cn_Mode15 'V4.28
					If PP.Mode <> Cn_Mode1 Then
						If AE_MsgLibrary(PP, "AppendC") Then AE_ChOprtLater = False : Exit Function '-------------------- 'V4.28
					End If
				Case Cn_Mode16 'V6.56
				Case Cn_Mode2
					If AE_MsgLibrary(PP, "SelectCm") Then AE_ChOprtLater = False : Exit Function '--------------------
				Case Cn_Mode25 'V6.59CL
					If AE_MsgLibrary(PP, "SelectCm") Then AE_ChOprtLater = False : Exit Function '--------------------
				Case Cn_Mode3
					If AE_MsgLibrary(PP, "Indicate") Then AE_ChOprtLater = False : Exit Function '--------------------
				Case Cn_Mode4
					If AE_MsgLibrary(PP, "UpdateC") Then AE_ChOprtLater = False : Exit Function '--------------------
				Case Else
					Call AE_SystemError("AE_ChOprtLater ��", 110)
					Exit Function '--------------------
			End Select
		End If
		'
		PP.ChOprtMode = pm_Mode
		AE_ChOprtLater = True
	End Function
	
	'AE_Controls �� ForeColor, BackColor �̐ݒ�B
	Public Sub AE_ColorSub(ByRef PP As clsPP, ByRef CP As clsCP, ByVal pm_Ptr As Short) 'V5.39
		Static wk_Tx As Short
		wk_Tx = AE_Tx(PP, CP.CpPx) 'V5.39
		If wk_Tx >= 0 Then Call AE_ColorSub2(PP, CP, pm_Ptr, wk_Tx) 'V5.39
	End Sub
	
	'AE_Controls �� ForeColor, BackColor �̐ݒ�B
	Public Sub AE_ColorSub2(ByRef PP As clsPP, ByRef CP As clsCP, ByVal pm_Ptr As Short, ByVal pm_Tx As Short) 'V5.39
		If CP.TypeA = Cn_NormalOrV Or CP.TypeA = Cn_InputOnly Then
			Select Case CP.StatusC
				Case Cn_Status2
					If Trim(AE_Controls(PP.CtB + pm_Tx).ToString()) = "" Or PP.ErrorByBackColor Then
						AE_Controls(PP.CtB + pm_Tx).ForeColor = System.Drawing.ColorTranslator.FromOle(AE_ForeColor(pm_Ptr \ 10))
						AE_Controls(PP.CtB + pm_Tx).BackColor = System.Drawing.ColorTranslator.FromOle(AE_Color(CP.StatusC))
					Else
						AE_Controls(PP.CtB + pm_Tx).ForeColor = System.Drawing.ColorTranslator.FromOle(AE_Color(CP.StatusC))
						AE_Controls(PP.CtB + pm_Tx).BackColor = System.Drawing.ColorTranslator.FromOle(AE_BackColor(pm_Ptr Mod 10))
					End If
				Case Cn_Status3 To Cn_Status5
					If Trim(AE_Controls(PP.CtB + pm_Tx).ToString()) = "" Or PP.ErrorByBackColor Then
						AE_Controls(PP.CtB + pm_Tx).ForeColor = System.Drawing.ColorTranslator.FromOle(AE_ForeColor(pm_Ptr \ 10)) 'V4.30
						AE_Controls(PP.CtB + pm_Tx).BackColor = System.Drawing.ColorTranslator.FromOle(AE_Color(CP.StatusC))
					Else
						AE_Controls(PP.CtB + pm_Tx).ForeColor = System.Drawing.ColorTranslator.FromOle(AE_Color(CP.StatusC))
						AE_Controls(PP.CtB + pm_Tx).BackColor = System.Drawing.ColorTranslator.FromOle(AE_BackColor(pm_Ptr Mod 10))
					End If
				Case Cn_Status6 To Cn_Status8
					AE_Controls(PP.CtB + pm_Tx).ForeColor = System.Drawing.ColorTranslator.FromOle(AE_ForeColor(pm_Ptr \ 10))
					'If AE_GetInOutMode(CP.InOutMode, PP.Mode) < Cn_InOutMode2 And PP.ErrorByBackColor Then 'V4.30
					'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 And Cn_ClIndicator <> Cn_ClNormalBack Then 'V5.44
					'(CP.AutoEnter And Cn_Enabled) = 0 �Ƃ�������͕s�v�B'V6.47X
					If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 And Not SSSMSG_BAS.Cn_ClIndicator.equals(SSSMSG_BAS.Cn_ClNormalBack) And (pm_Ptr Mod 10) = 0 Then 'V6.47X
						If Cn_ai21 And AE_BackColor(pm_Ptr Mod 10) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow) Then 'V6.46
							AE_Controls(PP.CtB + pm_Tx).BackColor = System.Drawing.Color.Yellow 'V6.46
						Else
							AE_Controls(PP.CtB + pm_Tx).BackColor = SSSMSG_BAS.Cn_ClIndicator
						End If
					Else 'V4.30
						AE_Controls(PP.CtB + pm_Tx).BackColor = System.Drawing.ColorTranslator.FromOle(AE_BackColor(pm_Ptr Mod 10))
					End If 'V4.30
					'Case Else
					'    'Stop '��
			End Select
		ElseIf CP.TypeA = Cn_OutputOnly Then 
			AE_Controls(PP.CtB + pm_Tx).ForeColor = System.Drawing.ColorTranslator.FromOle(AE_ForeColor(pm_Ptr \ 10))
			If PP.ErrorByBackColor Then 'V4.30
				AE_Controls(PP.CtB + pm_Tx).BackColor = SSSMSG_BAS.Cn_ClIndicator
			Else 'V4.30
				AE_Controls(PP.CtB + pm_Tx).BackColor = System.Drawing.ColorTranslator.FromOle(AE_BackColor(pm_Ptr Mod 10))
			End If 'V4.30
		End If
	End Sub
	
	Public Sub AE_CtSet(ByRef PP As clsPP, ByVal pm_Px As Short, ByVal pm_Txt As String, ByVal pm_TypeA As Short, ByVal pm_DeSetSw As Boolean)
		Dim wk_Tx As Short
		Dim wk_SS As Integer
		Dim wk_De As Short
		Dim wk_SaveMaskMode As Boolean
		Dim wk_PxTx As Short
		Dim st_Work As String
		wk_Tx = AE_Tx(PP, pm_Px)
		'If wk_Tx <> pm_Tx Then
		'    Call AE_SystemError("AE_CtSet ��", 120)
		'End If
		If wk_Tx < 0 Then Exit Sub '-------------------- 'V4.17
		'
		If pm_Px < 0 Or pm_Px >= PP.TailPx + PP.TailN Then
			Call AE_SystemError("AE_CtSet ��", 121)
			Exit Sub '--------------------
		End If
		'
		wk_SaveMaskMode = PP.MaskMode
		PP.MaskMode = True
		Select Case pm_TypeA
			Case Cn_NormalOrV
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_SS = AE_Controls(PP.CtB + wk_Tx).SelStart
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP.CtB + wk_Tx) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_Controls(PP.CtB + wk_Tx) = pm_Txt
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_Controls(PP.CtB + wk_Tx).SelStart = wk_SS
			Case Cn_OutputOnly
				'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP.CtB + wk_Tx) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If TypeOf AE_Controls(PP.CtB + wk_Tx) Is System.Windows.Forms.Label Then AE_Controls(PP.CtB + wk_Tx) = pm_Txt 'V4.31
			Case Cn_OptionButtonH, Cn_OptionButtonC
				If Trim(pm_Txt) = "" Then
					st_Work = UCase(AE_Controls(PP.CtB + wk_Tx).Name)
					wk_PxTx = 0
					Do While wk_Tx + wk_PxTx < PP.ControlsC 'V4.18
						If UCase(AE_Controls(PP.CtB + wk_Tx + wk_PxTx).Name) <> st_Work Then Exit Do '---------- 'V4.18
						'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP.CtB + wk_Tx + wk_PxTx) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						AE_Controls(PP.CtB + wk_Tx + wk_PxTx) = False
						AE_Controls(PP.CtB + wk_Tx + wk_PxTx).TabStop = False
						'Control.TabStop �̐ݒ肠��B
						'If PP.ActiveBlockNo > 0 Then 'V5.41
						'    AE_Controls(PP.CtB + wk_Tx).Enabled = (CP.BlockNo = PP.ActiveBlockNo) 'V5.41
						'End If 'V5.41
						wk_PxTx = wk_PxTx + 1
					Loop 
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP.CtB + wk_Tx + CInt(pm_Txt$)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Controls(PP.CtB + wk_Tx + CShort(pm_Txt)) = True
				End If
			Case Cn_CheckBox
				If Trim(pm_Txt) = "1" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP.CtB + wk_Tx) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Controls(PP.CtB + wk_Tx) = "1"
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP.CtB + wk_Tx) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Controls(PP.CtB + wk_Tx) = "0"
				End If
			Case Else 'Cn_InputOnly, Cn_ListBox 'V4.18
				If Trim(pm_Txt) = "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().ListIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Controls(PP.CtB + wk_Tx).ListIndex = -1 'Null �l�̏ꍇ�̈ʒu�B
				Else
					wk_PxTx = 0
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP.CtB + wk_Tx).ListCount �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Do While wk_PxTx < AE_Controls(PP.CtB + wk_Tx).ListCount
						'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().List �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(AE_Controls(PP.CtB + wk_Tx).List(wk_PxTx)) = Trim(pm_Txt) Then
							'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().ListIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							AE_Controls(PP.CtB + wk_Tx).ListIndex = wk_PxTx
							GoTo AE_CtSetLabel1 '---------->
						End If
						wk_PxTx = wk_PxTx + 1
					Loop 
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().ListIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Controls(PP.CtB + wk_Tx).ListIndex = -1 'Null �l�̏ꍇ�̈ʒu�B
				End If
AE_CtSetLabel1: 
		End Select
		PP.MaskMode = wk_SaveMaskMode
		'
		If Not pm_DeSetSw Then Exit Sub '--------------------
		'AE_Change �����悤�ȏ����B
		If wk_Tx >= PP.BodyTx And wk_Tx < PP.EBodyTx Then
			wk_De = (pm_Px - PP.BodyPx) \ PP.BodyV
			If PP.ActiveDe = wk_De Then
				PP.ActiveDe = -1 : Call AE_ScrlMax(PP)
				'ElseIf PP.ActiveDe < 0 And PP.DeApendable Then '���� wk_DeC = 0
			ElseIf PP.ActiveDe < 0 And AE_GetDeApendable(PP) Then  '���� wk_DeC = 0 'V6.55I
				If wk_De > PP.LastDe Then
					Call AE_SystemError("AE_CtSet ��", 122)
				End If
				If wk_De >= PP.LastDe Then
					PP.LastDe = wk_De + 1 : Call AE_ScrlMax(PP)
					'LastReadDe �̏����͕s�v�B'V6.47(5)
					If PP.UniScrl Then PP.LastEDe = wk_De + 1 : Call AE_EScrlMax(PP) 'V6.46
					'LastReadEDe �̏����͕s�v�B'V6.47(5)
				End If
				'ElseIf PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then
				'No Operation
			End If
		ElseIf wk_Tx >= PP.EBodyTx And wk_Tx < PP.TailTx Then 
			wk_De = (pm_Px - PP.EBodyPx) \ PP.EBodyV
			If PP.ActiveEDe = wk_De Then
				PP.ActiveEDe = -1 : Call AE_EScrlMax(PP)
				'ElseIf PP.ActiveEDe < 0 And PP.EDeApendable Then '���� wk_EDeC = 0
			ElseIf PP.ActiveEDe < 0 And AE_GetEDeApendable(PP) Then  '���� wk_EDeC = 0 'V6.55I
				If wk_De > PP.LastEDe Then
					Call AE_SystemError("AE_CtSet ��", 123)
				End If
				If wk_De >= PP.LastEDe Then
					PP.LastEDe = wk_De + 1 : Call AE_EScrlMax(PP)
					'LastReadEDe �̏����͕s�v�B'V6.47(5)
					If PP.UniScrl Then PP.LastDe = wk_De + 1 : Call AE_ScrlMax(PP) 'V6.46
					'LastReadDe �̏����͕s�v�B'V6.47(5)
				End If
				'ElseIf PP.ActiveDe >= 0 Or Not AE_GetEDeApendable(PP) Then
				'No Operation
			End If
		End If
	End Sub
	
	'ai21 �V�X�e������
	Public Sub AE_CtSet2(ByRef PP As clsPP, ByRef CP As clsCP) 'V5.42
		Dim wk_Tx As Short
		wk_Tx = AE_Tx(PP, CP.CpPx)
		If wk_Tx < 0 Then Exit Sub '--------------------
		'
		Select Case CP.TypeA
			Case Cn_OutputOnly
				'If TypeOf AE_Controls(PP.CtB + wk_Tx) Is Label Then AE_Controls(PP.CtB + wk_Tx).Enabled = (CP.BlockNo = PP.ActiveBlockNo) 'V5.42
				'If TypeOf AE_Controls(PP.CtB + wk_Tx) Is Label Then 'V6.47E 'V6.47X �ō폜
				'    If CP.BlockNo = PP.ActiveBlockNo Then 'V6.47E 'V6.47X �ō폜
				'        CP.AutoEnter = CP.AutoEnter Or Cn_Enabled 'V6.47E 'V6.47X �ō폜
				'    Else 'V6.47E 'V6.47X �ō폜
				'        CP.AutoEnter = CP.AutoEnter And &HFFEF 'Cn_Enabled 'V6.47E 'V6.47X �ō폜
				'    End If 'V6.47E 'V6.47X �ō폜
				'End If 'V6.47E 'V6.47X �ō폜
				If PP.VisibleForItem And CP.CpPx >= PP.BodyPx And CP.CpPx < PP.TailPx Then AE_Controls(PP.CtB + wk_Tx).Visible = ((CP.AutoEnter And Cn_VisibleCur) = Cn_VisibleCur) 'V6.47V
			Case Cn_OptionButtonH, Cn_OptionButtonC
			Case Cn_CheckBox
			Case Else 'Cn_NormalOrV, Cn_InputOnly, Cn_ListBox 'V5.42
				'AE_Controls(PP.CtB + wk_Tx).Enabled = (CP.BlockNo = PP.ActiveBlockNo) 'V5.42
				'If CP.BlockNo = PP.ActiveBlockNo Then 'V6.47E 'V6.47X �ō폜
				'    CP.AutoEnter = CP.AutoEnter Or Cn_Enabled 'V6.47E 'V6.47X �ō폜
				'Else 'V6.47E 'V6.47X �ō폜
				'    CP.AutoEnter = CP.AutoEnter And &HFFEF 'Cn_Enabled 'V6.47E 'V6.47X �ō폜
				'End If 'V6.47E 'V6.47X �ō폜
				'AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And ((CP.AutoEnter And Cn_Enabled) = Cn_Enabled) 'V6.47E
				AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) 'V6.47X
				If PP.VisibleForItem And CP.CpPx >= PP.BodyPx And CP.CpPx < PP.TailPx Then AE_Controls(PP.CtB + wk_Tx).Visible = ((CP.AutoEnter And Cn_VisibleCur) = Cn_VisibleCur) 'V6.47V
		End Select
	End Sub
	
	Public Function AE_EBodyPx(ByRef PP As clsPP, ByVal pm_Px As Object, ByVal pm_Index As Object) As Short 'V5.39
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Px �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_EBodyPx = PP.EBodyPx + ((pm_Px - PP.EBodyPx + PP.EBodyV) Mod PP.EBodyV) + PP.EBodyV * pm_Index
	End Function
	
	'Error Code Check Routine
	Function AE_ErrorToInteger(ByVal Ck_Error As Object) As Short
		'UPGRADE_WARNING: VarType �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Select Case VarType(Ck_Error)
			Case VariantType.Empty, VariantType.Null '0, 1
				AE_ErrorToInteger = 0
			Case VariantType.Short To VariantType.Decimal '2 To 6
				'If Ck_Error = 0 Then
				'    AE_ErrorToInteger = 0
				'ElseIf Ck_Error < 0 Then
				'    AE_ErrorToInteger = -1
				'Else
				'    AE_ErrorToInteger = 1
				'End If
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_ErrorToInteger = Ck_Error
			Case Else
				AE_ErrorToInteger = 1
		End Select
	End Function
	
	Public Function AE_EScrlDisp(ByRef PP As clsPP, ByVal pm_DeNo As Short) As Short
		Static wk_EDeC As Short
		Static wk_Displacement As Short
		Static wk_MaxEDe As Short 'V4.28
		Static wk_Limit As Short 'V6.46S
		'If PP.No2Scroll And Not PP.EDeApendable And PP.Mode >= Cn_Mode3 Then 'V6.46S
		If PP.No2Scroll And Not AE_GetEDeApendable(PP) And PP.Mode >= Cn_Mode3 Then 'V6.55I
			wk_Limit = PP.LastEDe - 1 'V6.46S
		Else 'V6.46S
			wk_Limit = PP.MaxEDe 'V6.46S
		End If 'V6.46S
		'
		'wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not PP.EDeApendable Then wk_EDeC = 1
		wk_EDeC = 0 : If PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then wk_EDeC = 1 'V6.55I
		'�_���I�ȏ����ɂ���� wk_Displacement ���Z�o����B
		If PP.AllowNullDes Then 'V6.47B
			wk_Displacement = pm_DeNo - PP.TopEDe 'V6.47B
		ElseIf PP.MaxEDspC = 0 Then  '�{�f�B���� 1 �s�̏ꍇ�B
			If PP.LastEDe - wk_EDeC <= 0 Then
				wk_Displacement = 0
			ElseIf pm_DeNo > PP.LastEDe - wk_EDeC Then 
				wk_Displacement = 0
			Else
				wk_Displacement = pm_DeNo - PP.TopEDe
			End If
		Else
			If PP.MaxEDspC >= PP.MaxEDe Then 'PP.MaxEDe - PP.MaxEDspC = 0 'V6.48
				wk_Displacement = 0 'V6.48
				'If PP.LastEDe - wk_EDeC <= PP.MaxEDspC And PP.ReadableMaxEDe <= PP.MaxEDspC Then 'V4.29
			ElseIf PP.TopEDe = 0 And PP.LastEDe - wk_EDeC <= PP.MaxEDspC And PP.ReadableMaxEDe <= PP.MaxEDspC Then  'V4.32
				wk_Displacement = 0 'V4.29
			ElseIf pm_DeNo < PP.ReadableMaxEDe - PP.MaxEDspC And PP.ReadableMaxEDe >= wk_Limit Then  'V6.46S
				wk_Displacement = pm_DeNo - PP.TopEDe 'V4.28
			ElseIf pm_DeNo >= PP.ReadableMaxEDe - PP.MaxEDspC And PP.ReadableMaxEDe > PP.LastEDe Then  'V4.28
				wk_Displacement = PP.ReadableMaxEDe - PP.MaxEDspC - PP.TopEDe 'V4.28
			ElseIf pm_DeNo >= PP.LastEDe - wk_EDeC And pm_DeNo >= PP.ReadableMaxEDe - PP.MaxEDspC Then  'V4.28
				wk_Displacement = PP.LastEDe - wk_EDeC - 1 - PP.TopEDe 'V4.28
				'ElseIf PP.TopEDe + PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then
				'ElseIf PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then 'V4.28
			ElseIf PP.TopEDe = 0 And PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then  'V4.32
				wk_Displacement = 0
			Else
				wk_Displacement = pm_DeNo - PP.TopEDe
			End If
		End If
		'�����I�Ȑ���̃`�F�b�N�B
		If wk_Limit > PP.ReadableMaxEDe Then 'V6.46S
			wk_MaxEDe = wk_Limit 'V6.46S
		Else 'V4.28
			wk_MaxEDe = PP.ReadableMaxEDe 'V4.28
		End If 'V4.28
		If PP.TopEDe + wk_Displacement < 0 Then
			AE_EScrlDisp = -PP.TopEDe
			'ElseIf PP.TopEDe + wk_Displacement > wk_MaxEDe - PP.MaxEDspC Then 'V4.28
		ElseIf PP.TopEDe + wk_Displacement > wk_MaxEDe - PP.MaxEDspC And wk_MaxEDe - PP.MaxEDspC > 0 Then  'V6.46S 'V6.47(4)
			AE_EScrlDisp = wk_MaxEDe - PP.MaxEDspC - PP.TopEDe 'V4.28
		Else
			AE_EScrlDisp = wk_Displacement
		End If
	End Function
	
	Public Sub AE_EScrlMax(ByRef PP As clsPP)
		Static wk_EDeC As Short
		Static wk_Max As Short 'V4.28
		Static wk_Limit As Short 'V6.46S
		'If PP.No2Scroll And Not PP.EDeApendable And PP.Mode >= Cn_Mode3 Then 'V6.46S
		If PP.No2Scroll And Not AE_GetEDeApendable(PP) And PP.Mode >= Cn_Mode3 Then 'V6.55I
			wk_Limit = PP.LastEDe - 1 'V6.46S
		Else 'V6.46S
			wk_Limit = PP.MaxEDe 'V6.46S
		End If 'V6.46S
		'
		'wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not PP.EDeApendable Then wk_EDeC = 1
		wk_EDeC = 0 : If PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then wk_EDeC = 1 'V6.55I
		If PP.MaxEDspC = 0 Then '�{�f�B���� 1 �s�̏ꍇ�B
			wk_Max = PP.LastEDe - wk_EDeC 'V4.28
			'ElseIf PP.TopEDe + PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then
		ElseIf PP.TopEDe = 0 And PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then  'V4.32
			wk_Max = 0 'V4.28
		ElseIf PP.LastEDe - wk_EDeC > wk_Limit - PP.MaxEDspC Then  'V6.46S
			wk_Max = wk_Limit - PP.MaxEDspC 'V6.46S
		Else
			wk_Max = PP.LastEDe - wk_EDeC - 1 'V4.28
		End If
		'
		If PP.AllowNullDes Then 'V6.47B
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_EScrlBar().Max �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_EScrlBar(PP.ScX).Max = wk_Limit - PP.MaxEDspC 'V6.47B, 'V6.46S
		ElseIf wk_Max > PP.ReadableMaxEDe - PP.MaxEDspC Then  'V4.28
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_EScrlBar().Max �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_EScrlBar(PP.ScX).Max = wk_Max 'V4.28
		Else 'V4.28
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_EScrlBar().Max �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_EScrlBar(PP.ScX).Max = PP.ReadableMaxEDe - PP.MaxEDspC 'V4.28
		End If 'V4.28
	End Sub
	
	Public Function AE_Format(ByRef CP As clsCP, ByVal pm_Value As Object, ByRef pm_FractionC As Short, ByVal pm_Final As Short) As String
		'Non Static Public Functin�iAE_Change ����ďo����邽�߁j
		'pm_FractionC �p�����^�͖{�� ByVal ��t����ׂ��B�������A�p�����^�̌v�Z���ɍ��E����Ȃ��悤�� ByRef �Ƃ���B
		'pm_Final �p�����^  False: �����̃C���v�b�g�r�� (AE_KeyPress, AE_KeyDown, AE_Change �̓r��)
		'         �@�@�@�@  True:  �m�� (AE_InitVal, AE_Check, AE_Derived, DD_ , AE_Change)
		'         �@�@�@�@  True �̏ꍇ�ɂ́AFractionC �͈Ӗ��������Ȃ��B
		Dim wk_Txt As String
		Dim st_Work As String
		Dim wk_MaxLB As Integer
		Dim wk_Ln As Integer
		Dim wk_Pos As Short
		Dim wk_FracN As Short
		Dim wk_FracN2 As Short 'V4.31
		Dim wk_FormatDate As Date 'Variant
		Dim wk_FormatChr As String 'V4.31
		'
		wk_MaxLB = CP.MaxLength
		'wk_FmtLn = Len(CP.FormatChr) 'V6.50 �ō폜�B
		'
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(pm_Value) Then
			If wk_MaxLB = 0 And pm_FractionC > 0 And Not pm_Final Then
				wk_Txt = Space(pm_FractionC)
			Else
				wk_Txt = Space(wk_MaxLB)
			End If
			'If CP.FixedFormat = 1 Then
			'   Call AE_SystemError("FixedFormat �̎w�肪����Ă��鍀�ڂ̒l�� Null �ɂł��Ȃ��Ƃ���", 130)
			'End If
		ElseIf CP.FormatClass = Cn_Date Then  '���t�B
			'���t�̏ꍇ�B
			'If InStr(pm_Value, Space$(1)) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If InStr(pm_Value, Space(1)) > 0 Then 'V7.00
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_Txt = pm_Value '�C���v�b�g�r���Ȃ̂ŁB
			Else
				If Cn_ai21 Then 'V5.42
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					st_Work = pm_Value
					'ElseIf VarType(pm_Value) = vbDate Then
				ElseIf IsDate(pm_Value) Then  'V4.16
					'st_Work$ = Format$(pm_Value, CP.FormatChr)
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					st_Work = VB6.Format(pm_Value, CP.FormatChr) 'V6.50F
					'UPGRADE_WARNING: VarType �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
					If VarType(pm_Value) <> VariantType.Date And Len(st_Work) > Len(pm_Value) Then 'V4.16
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						st_Work = pm_Value 'V4.16
					ElseIf CP.FixedFormat = 1 And Left(st_Work, 1) >= "1" And Left(st_Work, 1) <= "9" Then  'V4.15
						If LCase(Left(CP.FormatChr, 4)) = "ggee" Then 'V4.15
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							st_Work = "��01" & Mid(pm_Value, 5) 'V4.15
						ElseIf LCase(Left(CP.FormatChr, 4)) = "gggee" Then  'V4.15
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							st_Work = "����01" & Mid(pm_Value, 7) 'V4.15
						Else 'V4.22
							wk_FormatDate = CDate(st_Work) 'V4.22
							If wk_FormatDate < #1/1/1000# Then 'V4.22
								st_Work = "0" & st_Work 'V4.22
							Else 'V4.22
								st_Work = st_Work 'V4.22
							End If 'V4.22
						End If 'V4.15
					End If 'V4.15
					'���t�Ƃ݂Ȃ��Ȃ��l�̂Ƃ��ɁA�����ŃG���[�ɂ��Ă��悢���A���i�ł̃G���[���b�Z�[�W���o�Ȃ��Ȃ��Ă��܂��B
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					st_Work = pm_Value
				End If
				If CP.Alignment = 1 Then '�E�l�߁B
					wk_Txt = RightWid(st_Work, wk_MaxLB)
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Ln = LenWid(wk_Txt) 'V4.15
					If wk_Ln < wk_MaxLB Then wk_Txt = Space(wk_MaxLB - wk_Ln) & wk_Txt 'V4.15
				Else
					wk_Txt = LeftWid(st_Work, wk_MaxLB)
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Ln = LenWid(wk_Txt) 'V4.15
					If wk_Ln < wk_MaxLB Then wk_Txt = wk_Txt & Space(wk_MaxLB - wk_Ln) 'V4.15
				End If
			End If
			'ElseIf CP.FormatClass = Cn_Time Then '�����B
		ElseIf Not AE_Numerical(CP.FormatClass) Then  '���l�A�����l�A�����A�������A�ȊO�B'V6.50
			'���t�Ɛ��l (�����l�A�����A������) �ȊO�̏ꍇ�B(�R�[�h�A�����A���́A����)
			'If wk_FmtLn = 0 Or Not pm_Final Then
			If CP.FormatChr = "" Or Not pm_Final Then 'V6.50
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				st_Work = pm_Value
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Not pm_Final Then st_Work = pm_Value & Space(pm_FractionC)
			Else
				'st_Work$ = Format$(pm_Value, CP.FormatChr)
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				st_Work = VB6.Format(pm_Value, CP.FormatChr) 'V6.50F
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_Ln = LenWid(st_Work)
			If wk_Ln < wk_MaxLB Then
				If CP.Alignment = 1 Then '�E�l�߁B
					wk_Txt = Space(wk_MaxLB - wk_Ln) & st_Work
				Else
					wk_Txt = st_Work & Space(wk_MaxLB - wk_Ln)
				End If
			ElseIf wk_Ln > wk_MaxLB And wk_MaxLB > 0 Then 
				If CP.Alignment = 1 Then '�E�l�߁B
					wk_Txt = RightWid(st_Work, wk_MaxLB)
				Else
					wk_Txt = LeftWid(st_Work, wk_MaxLB)
				End If
			Else
				wk_Txt = st_Work
			End If
		Else 'If AE_Numerical(CP.FormatClass) Then '���l�A�����l�A�����A�������B'V6.50
			'���l (�����l�A�����A������) �̏ꍇ�B
			If CP.Alignment = 1 Then '�E�l�ߐ��l�B
				'If wk_FmtLn = 0 Then
				If CP.FormatChr = "" Then 'V6.50
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Txt = CStr(pm_Value)
					If pm_Final Then 'V5.41
					ElseIf pm_FractionC = -1000 Then  'V5.41
						wk_Txt = "-" 'V5.41
					ElseIf pm_FractionC = -1001 Then  'V5.41
						wk_Txt = "-0" 'V5.41
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ElseIf pm_FractionC < 0 And pm_Value = 0 Then  'V5.41
						wk_Txt = "-0." & New String("0", -pm_FractionC - 1) 'V5.41
						'ElseIf Abs(pm_FractionC) = 1 And Right$(wk_Txt$, 1) <> "." Then
						''Abs(pm_FractionC) = 1 �̏ꍇ�B
						'   wk_Txt$ = wk_Txt$ & "."
					ElseIf System.Math.Abs(pm_FractionC) >= 1 Then 
						'wk_Txt$ = CStr(pm_Value) 'V5.41
						wk_Pos = InStr(wk_Txt, ".") 'V5.41
						If wk_Pos = 0 Then 'V5.41
							wk_FracN = 0 'V5.41
							wk_Txt = wk_Txt & "."
						Else 'V5.41
							wk_FracN = Len(wk_Txt) - wk_Pos 'V5.41
						End If 'V5.41
						'
						If System.Math.Abs(pm_FractionC) - 1 > wk_FracN Then '������ 0 ���C���v�b�g�r���B
							wk_Txt = wk_Txt & New String("0", System.Math.Abs(pm_FractionC) - wk_FracN - 1) 'V5.41
						End If 'V5.41
					End If
				Else
					'wk_Pos = InStr(CP.FormatChr, ".")
					wk_Pos = InStr(CP.FormatChr, ";") 'V4.31
					If wk_Pos = 0 Then 'V4.31
						wk_FormatChr = AE_FormatNorm(CP.FormatChr) 'V4.31 'V6.50
					Else 'V4.31
						wk_FormatChr = AE_FormatNorm(Left(CP.FormatChr, wk_Pos - 1)) 'V4.31 'V6.50
					End If 'V4.31
					wk_Pos = InStr(wk_FormatChr, ".") 'V4.31
					If wk_Pos = 0 Then 'V4.31
						wk_FracN = 0 'V4.31
					Else 'V4.31
						wk_FracN = Len(wk_FormatChr) - wk_Pos 'V4.31
					End If 'V4.31
					'
					'wk_Txt$ = Format$(CStr(pm_Value), CP.FormatChr)
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Txt = FormatAndRound(CStr(pm_Value), AE_FormatNorm(CP.FormatChr)) 'V6.50F
					If pm_Final Then
					ElseIf pm_FractionC = -1000 Then 
						wk_Txt = "-"
					ElseIf pm_FractionC = -1001 Then 
						wk_Txt = "-0"
					ElseIf pm_FractionC < 0 Then 
						wk_Txt = "-0." & New String("0", -pm_FractionC - 1)
						'ElseIf wk_FracN = 0 Then 'V4.31
						'   wk_Txt$ = Format$(CStr(pm_Value), CP.FormatChr)
					ElseIf wk_FracN <> 0 Then 
						'pm_FractionC �͗L�������Ȃ̂ŁA321.0 �̂悤�ȏꍇ�Ɏg���Ȃ��B
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						wk_Txt = CStr(pm_Value) 'V4.31
						wk_FracN2 = InStr(wk_Txt, ".") 'V4.31
						If wk_FracN2 > 0 Then wk_FracN2 = Len(wk_Txt) - wk_FracN2 'V4.31
						'
						If System.Math.Abs(pm_FractionC) <= wk_FracN Then '�����_�̓r���C���v�b�g�B
							wk_Txt = VB6.Format(wk_Txt, Left(wk_FormatChr, wk_Pos - 1 + System.Math.Abs(pm_FractionC))) 'V4.31
						ElseIf wk_FracN2 > wk_FracN Then  '�L�������_�I�[�o�B
							wk_Txt = FormatAndRound(Left(wk_Txt, Len(wk_Txt) - wk_FracN2 + wk_FracN), wk_FormatChr) 'V4.31
						Else '�L�������_�s�b�^���B
							wk_Txt = FormatAndRound(wk_Txt, wk_FormatChr) 'V4.31
						End If 'V4.31
					End If
				End If
				'LenWid ��p����B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_Ln = LenWid(wk_Txt)
				If wk_Ln < wk_MaxLB Then
					wk_Txt = Space(wk_MaxLB - wk_Ln) & wk_Txt
					'�ȉ��̂Q�s�͑��݂��Ă͂����Ȃ��
					'ElseIf wk_Ln > wk_MaxLB And wk_MaxLB > 0 Then
					'   wk_Txt$ = Right$(wk_Txt$, wk_MaxLB)
				End If
			Else 'If wk_Txt$ <> "" And CP.Alignment <> 1 Then '���l�ߐ��l�B
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_Txt = CStr(pm_Value)
				If pm_Final Then 'V5.41
				ElseIf pm_FractionC = -1000 Then  'V5.41
					wk_Txt = "-" 'V5.41
				ElseIf pm_FractionC = -1001 Then  'V5.41
					wk_Txt = "-0" 'V5.41
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ElseIf pm_FractionC < 0 And pm_Value = 0 Then  'V5.41
					wk_Txt = "-0." & New String("0", -pm_FractionC - 1) 'V5.41
					'ElseIf Abs(pm_FractionC) = 1 And Right$(wk_Txt$, 1) <> "." Then
					''Abs(pm_FractionC) = 1 �̏ꍇ�B
					'   wk_Txt$ = wk_Txt$ & "."
				ElseIf System.Math.Abs(pm_FractionC) >= 1 Then 
					'wk_Txt$ = CStr(pm_Value) 'V5.41
					wk_Pos = InStr(wk_Txt, ".") 'V5.41
					If wk_Pos = 0 Then 'V5.41
						wk_FracN = 0 'V5.41
						wk_Txt = wk_Txt & "."
					Else 'V5.41
						wk_FracN = Len(wk_Txt) - wk_Pos 'V5.41
					End If 'V5.41
					'
					If System.Math.Abs(pm_FractionC) - 1 > wk_FracN Then '������ 0 ���C���v�b�g�r���B
						wk_Txt = wk_Txt & New String("0", System.Math.Abs(pm_FractionC) - wk_FracN - 1) 'V5.41
					End If 'V5.41
				End If
				'
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_Ln = LenWid(wk_Txt)
				If wk_Ln < wk_MaxLB Then
					st_Work = wk_Txt & New String(Space(1), wk_MaxLB - wk_Ln)
				ElseIf wk_Ln > wk_MaxLB And wk_MaxLB > 0 Then 
					'LeftWid$ ��p����B
					st_Work = LeftWid(wk_Txt, wk_MaxLB)
				Else
					st_Work = wk_Txt
				End If
				'If wk_FmtLn > 0 Then
				If CP.FormatChr <> "" Then 'V6.50
					'wk_Txt$ = Format$(st_Work$, CP.FormatChr)
					wk_Txt = FormatAndRound(st_Work, AE_FormatNorm(CP.FormatChr)) 'V6.50F
					'LenWid ��p����B
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Ln = LenWid(wk_Txt)
					If wk_Ln < wk_MaxLB Then
						wk_Txt = wk_Txt & Space(wk_MaxLB - wk_Ln)
					ElseIf wk_Ln > wk_MaxLB And wk_MaxLB > 0 Then 
						'LeftWid$ ��p����B
						wk_Txt = LeftWid(wk_Txt, wk_MaxLB)
					End If
				Else
					wk_Txt = st_Work
				End If
			End If
		End If
		'
		AE_Format = wk_Txt
	End Function
	
	Public Function AE_FormatC(ByRef CP As clsCP, ByVal pm_NewVal As Object) As String 'V6.56
		Dim sr_Work As String
		sr_Work = FormatAndRound(pm_NewVal, CP.FormatChr)
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(sr_Work) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CP.Alignment = 1 And LenWid(sr_Work) < CP.MaxLength Then '�E�l��
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_FormatC = Space(CP.MaxLength - LenWid(sr_Work)) & sr_Work
		Else
			AE_FormatC = sr_Work
		End If
	End Function
	
	Public Function AE_FormatNorm(ByVal pm_FormatChr As String) As String 'V6.50F
		Dim wk_Pos As Integer
		Dim wk_FormatNorm As String
		Dim wk_FormatChr As String
		Dim wk_FormatLeft As String
		Dim wk_FormatRight As String
		pm_FormatChr = ";" & pm_FormatChr '�擪�� ";" ��t������B
		wk_FormatNorm = ""
		'
		Do While pm_FormatChr <> ""
			wk_Pos = InStr(2, pm_FormatChr, ";")
			If wk_Pos = 0 Then
				wk_FormatChr = pm_FormatChr
				pm_FormatChr = ""
			Else
				wk_FormatChr = Left(pm_FormatChr, wk_Pos - 1)
				pm_FormatChr = Mid(pm_FormatChr, wk_Pos)
			End If
			'
			wk_Pos = InStr(wk_FormatChr, ".")
			If wk_Pos > 0 Then
				wk_FormatLeft = Left(wk_FormatChr, wk_Pos)
				wk_FormatRight = Mid(wk_FormatChr, wk_Pos + 1)
				Do While wk_FormatRight <> "" And Left(wk_FormatRight, 1) = "0"
					wk_FormatLeft = wk_FormatLeft & "0"
					wk_FormatRight = Mid(wk_FormatRight, 2)
				Loop 
				If wk_FormatRight = New String("#", Len(wk_FormatRight)) Then
					wk_FormatChr = wk_FormatLeft & New String("0", Len(wk_FormatRight))
				End If
			End If
			'
			wk_FormatNorm = wk_FormatNorm & wk_FormatChr
		Loop 
		'
		AE_FormatNorm = Mid(wk_FormatNorm, 2) '�擪�� ";" ����菜���B
	End Function
	
	Public Function AE_FormatRZS(ByVal pm_TpStr As String, ByVal pm_MaxLength As Short, ByVal pm_FracN As Integer) As String 'Right Zero Suppress 'V6.50
		Dim wk_N As Short
		wk_N = 0
		Do While Mid(pm_TpStr, pm_MaxLength - wk_N, 1) = "0" And wk_N < pm_FracN
			wk_N = wk_N + 1
		Loop 
		AE_FormatRZS = Left(pm_TpStr, pm_MaxLength - wk_N) & Space(wk_N)
	End Function
	
	Public Function AE_FormInit(ByRef PP As clsPP, ByRef pm_Form As System.Windows.Forms.Form, ByVal pm_Title As String, ByVal pm_IColor As Integer, ByVal pm_EColor As Integer, ByVal pm_RColor As Integer, ByVal pm_CColor As Integer) As String 'V4.07
		'�p�����^ pm_Title$ �͎g�p���Ă��Ȃ��B
		'
		System.Windows.Forms.Application.DoEvents()
		'
		AE_FormInit = "V6.60" '���x���A�b�v�̍ۂɕύX�B
		'
		AE_AppPath = My.Application.Info.DirectoryPath & "\"
		'
		AE_Color(Cn_Status1) = pm_IColor
		AE_Color(Cn_Status2) = pm_EColor
		AE_Color(Cn_Status3) = pm_RColor
		AE_Color(Cn_Status4) = pm_RColor
		AE_Color(Cn_Status5) = pm_RColor
		AE_Color(Cn_Status6) = pm_CColor
		AE_Color(Cn_Status7) = pm_CColor
		AE_Color(Cn_Status8) = pm_CColor
		'
		AE_ForeColor(0) = pm_CColor
		AE_BackColor(0) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClNormalBack)
		'
		'    PP.HeadTx = 0
		PP.BodyTx = PP.HeadN
		PP.EBodyTx = PP.BodyTx + PP.BodyN * (PP.MaxDsp + 1)
		PP.TailTx = PP.EBodyTx + PP.EBodyN * (PP.MaxEDsp + 1)
		PP.TailPx = PP.EBodyPx + PP.EBodyV * (PP.MaxEDe + 1)
		PP.ControlsC = PP.TailTx + PP.TailN
		'
		PP.MaxDspC = PP.MaxDsp
		PP.MaxEDspC = PP.MaxEDsp
		PP.TopDe = 0
		PP.TopEDe = 0
		PP.LastDe = 0
		PP.LastEDe = 0
		PP.LastReadDe = 0 'V6.47(5)
		PP.LastReadEDe = 0 'V6.47(5)
		PP.ActiveDe = -1
		PP.ActiveEDe = -1
		PP.DeApendable = True
		PP.EDeApendable = True
		'
		PP.MaskMode = True '�����ݒ蒆�́A�}�X�N���Ă����B
		PP.RecalcMode = False
		'
		PP.CursorDirection = Cn_Direction1 '1: Next
		PP.CursorDest = Cn_Dest0 'V6.45 'V6.51X
		'
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP.SlistCom = System.DBNull.Value
		PP.JustAfterSList = False 'V4.24 �ō폜�������AV4.27 �ŕ����B
		'
		PP.Tx = 0
		PP.NextTx = Cn_NextTxCleared 'Clear PP.NextTx
		PP.CursorSet = False
		'FormInit �� GotFocus �ɂ����Đݒ�B
		PP.Override = 1
		'
		PP.CloseCode = -1 'V4.17
		'
		PP.DateSaveFormat = "YYYY/MM/DD" 'V4.24
		'
		PP.NeglectLostFocusCheck = False 'V4.24
		'
		PP.AlreadyCDe = False 'V4.38
		PP.AlreadyCEDe = False 'V4.38
		'
		PP.SSCommand5Ajst = False 'V4.38
		'
		PP.SlistPx = -1 'V5.44
		'
		PP.MouseDownTx = -1 'V6.44
		'
		PP.ScrollObject = 3 'V6.44
		'
		'PP.RightButtonTx = -1 'V6.49
		PP.SuppressKeyPress = -1 'V6.53
		'
		PP.ExplicitExec = False 'V6.45
		PP.Executing = False
		PP.OnFocus = False
		PP.Operable = False
		PP.SlistCall = False
		PP.SuppressGotLostFocus = 0
		PP.LostFocusCheck = False
		PP.ServerCheck = 0
		PP.Activated = 0
		'
		PP.UnderFurigana = False 'Furigana �␳ 'V6.57
		PP.MaskFurigana = False 'Furigana �␳ 'V6.57
		'
		Static nName As String 'V6.59Pop
		nName = New String(Chr(0), 250) 'V6.59Pop
		Static nLeng As Integer 'V6.59Pop
		nLeng = Len(nName) 'V6.59Pop
		If (GetClassName(pm_Form.Handle.ToInt32, nName, nLeng) <> 0) Then 'V6.59Pop
			Cn_DebugMode = ((Left(nName, 13) = "ThunderFormDC")) 'V6.59Pop
		End If 'V6.59Pop
		'�e�X�g�p Cn_DebugMode = False '�e�X�g�p
	End Function
	
	Public Function AE_GetDeApendable(ByRef PP As clsPP) As Boolean 'V6.55I
		AE_GetDeApendable = PP.DeApendable 'V6.55I
		If PP.Mode = Cn_Mode3 Then AE_GetDeApendable = False 'V6.55I
	End Function 'V6.55I
	
	Public Function AE_GetEDeApendable(ByRef PP As clsPP) As Boolean 'V6.55I
		AE_GetEDeApendable = PP.EDeApendable 'V6.55I
		If PP.Mode = Cn_Mode3 Then AE_GetEDeApendable = False 'V6.55I
	End Function 'V6.55I
	
	Public Function AE_GetInOutMode(ByVal pm_InOutMode As Integer, ByVal pm_Mode As Short) As Short
		Static wk_PowerOfFour As Short
		Select Case pm_Mode
			Case 1
				wk_PowerOfFour = 64
			Case 2
				wk_PowerOfFour = 16
			Case 3
				wk_PowerOfFour = 4
			Case 4
				wk_PowerOfFour = 1
		End Select
		AE_GetInOutMode = (pm_InOutMode \ wk_PowerOfFour) Mod 4
	End Function
	
	Public Function AE_IsNullZero(ByRef PP As clsPP, ByRef CP As clsCP) As Boolean
		If AE_SSSWin Then
			AE_IsNullZero = (PP.NullZero And CP.BlockNo = 1)
		Else
			AE_IsNullZero = PP.NullZero
		End If
	End Function 'AE_IsNullZero
	
	Public Function AE_IsWritableInOutMode(ByRef PP As clsPP, ByRef CP As clsCP) As Boolean 'V6.59IsWritable
		If PP.Mode <> Cn_Mode3 And CP.KeyInOkClass <> Asc("-") And AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2 Then
			AE_IsWritableInOutMode = True '----------
		Else
			AE_IsWritableInOutMode = False '----------
		End If
	End Function
	
	Public Function AE_GotFocus(ByRef PP As clsPP, ByRef CP As clsCP, ByRef Ct As Object) As Short
		Static wk_Ln As Integer
		Static wk_MaxLB As Integer
		Static wk_P As Integer
		Static wk_DeC As Short
		Static wk_EDeC As Short
		Static wk_ww As Short
		Static wk_FractionC As Short 'V6.50
		PP.OnFocus = True
		PP.CursorSet = False
		'FormInit �� GotFocus �ɂ����Đݒ�B
		PP.Override = 1
		If AE_SSSWin Then
			PP.SelValid = (AE_Numerical(CP.FormatClass) Or CP.KeyInOkClass = Asc("0") Or CP.KeyInOkClass = Asc("C")) 'V6.60
		ElseIf Cn_ai21 Then  'V6.52
			PP.SelValid = AE_Numerical(CP.FormatClass) 'V6.52
		ElseIf PP.SpecSubID = "sdy" Then 
			PP.SelValid = AE_Numerical(CP.FormatClass) And CP.Alignment = 1 '�E�l�� 'V6.50
		End If
		'�������̃`�F�b�N�B
		If PP.Px < PP.BodyTx Then
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If PP.Px <> Ct.TabIndex Then
				If CP.TypeA <> Cn_OptionButtonH And CP.TypeA <> Cn_OptionButtonC Then 'V4.15
					Call AE_SystemError("AE_GotFocus ��", 140)
				End If 'V4.15
			End If
		ElseIf PP.Px < PP.EBodyPx Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_ww = Ct.TabIndex - PP.BodyTx
			If PP.Px <> PP.BodyPx + wk_ww Mod PP.BodyN + (wk_ww \ PP.BodyN + PP.TopDe) * PP.BodyV Then
				Call AE_SystemError("AE_GotFocus ��", 141)
			End If
		ElseIf PP.Px < PP.TailPx Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_ww = Ct.TabIndex - PP.EBodyTx
			If PP.Px <> PP.EBodyPx + wk_ww Mod PP.EBodyN + (wk_ww \ PP.EBodyN + PP.TopEDe) * PP.EBodyV Then
				Call AE_SystemError("AE_GotFocus ��", 142)
			End If
		Else
			If PP.Px - PP.TailPx + PP.TailTx >= PP.ControlsC Then
				Call AE_SystemError("AE_GotFocus ��", 143)
			End If
		End If
		'
		If PP.SuppressGotLostFocus = 1 Then PP.SuppressGotLostFocus = 2 : PP.JustAfterSList = False : AE_GotFocus = Cn_CuNop100 : Exit Function 'V4.27 �ŕ����B'--------------------
		'
		If TypeOf Ct Is System.Windows.Forms.TextBox Then
			'Locked �̂܂܂ɂȂ��Q�̏C���B
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ct.Locked = False 'V6.49
		End If
		PP.MultiLineF = 0 'V6.50
		'
		If Cn_ai21 And AE_Numerical(CP.FormatClass) And CP.Alignment = 1 And Right(CP.TpStr, 1) = Space(1) Then 'V6.50
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ct = AE_Format(CP, AE_Val(CP, CP.TpStr, wk_FractionC), wk_FractionC, False) 'V6.50
			PP.ChangeAtGotFocus = True 'V6.50
		Else 'V6.50
			PP.ChangeAtGotFocus = False 'V6.50
		End If 'V6.50
		'
		'   TX_Message = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_Ln = LenWid(Ct) 'Len �ł͂��߁B
		wk_MaxLB = CP.MaxLength 'Field Length
		Select Case CP.TypeA
			'Case Cn_NormalOrV, Cn_OutputOnly
			Case Cn_NormalOrV 'V4.31
				If PP.SelValid And PP.Override = 1 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.SelStart = 0
				ElseIf CP.Alignment <> 1 Then  '���l��
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.SelStart = 0
				Else 'If CP.Alignment = 1 Then '�E�l��
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If wk_MaxLB > wk_Ln Then Ct = Space(wk_MaxLB - wk_Ln) & Ct
					'If wk_Ln > 0 Then Ct.SelStart = Len((Ct)) - PP.Override
					If wk_Ln > 0 Then
						'If AE_Numerical(CP.FormatClass) And CP.Alignment = 1 And PP.SpecSubID = "sdy" Then 'V6.46 'V6.50
						'   Ct.SelStart = 0
						'ElseIf Cn_ai21 Then 'V6.45
						If Cn_ai21 Then 'V6.45
							If PP.ClickPosition = -1 Then 'And CP.Alignment = 1 Then 'V5.46
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Ct.SelStart = Len(LeftWid(Ct, CP.MaxLength)) - PP.Override 'V6.45
							Else 'V5.46
								'If PP.ClickPosition = -1 Then PP.ClickPosition = 0 'V5.46
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Do While PP.ClickPosition < Len(LeftWid(Ct, CP.MaxLength)) 'V6.45
									'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If AE_KeyInOkChar(PP, Mid(Ct, PP.ClickPosition + 1, 1), CP.KeyInOkClass) Then
										'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If Not (AE_Numerical(CP.FormatClass)) Or Mid(Ct, PP.ClickPosition + 1, 1) <> Space(1) Then Exit Do '----------'V6.50
									End If
									PP.ClickPosition = PP.ClickPosition + 1 'V6.45
								Loop  'V6.45
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If PP.ClickPosition >= Len(LeftWid(Ct, CP.MaxLength)) Then PP.ClickPosition = Len(LeftWid(Ct, CP.MaxLength)) - 1 'V6.45
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Ct.SelStart = PP.ClickPosition 'V6.45
								'PP.ClickPosition = -1 'V6.46
							End If
						ElseIf PP.SetCursorRR = False Then  'V6.46
							wk_P = 0
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Do While wk_P < Len(LeftWid(Ct, CP.MaxLength)) 'V6.45
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If AE_KeyInOkChar(PP, Mid(Ct, wk_P + 1, 1), CP.KeyInOkClass) Then Exit Do '----------
								wk_P = wk_P + 1 'V6.45
							Loop  'V6.45
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If wk_P >= Len(LeftWid(Ct, CP.MaxLength)) Then wk_P = Len(LeftWid(Ct, CP.MaxLength)) - 1 'V6.45
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Ct.SelStart = wk_P 'V6.45
						Else
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Ct.SelStart = Len(LeftWid(Ct, CP.MaxLength)) - PP.Override 'V6.45
						End If
					End If
				End If
				'Case Else 'Cn_InputOnly, Cn_OptionButtonH, Cn_OptionButtonC, Cn_CheckBox, Cn_ListBox, Cn_OutputOnly
		End Select
		'
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If PP.NextTx = PP.Tx Or Not IsDbNull(PP.SlistCom) Then
			PP.NextTx = Cn_NextTxCleared 'Clear PP.NextTx
			PP.JustAfterSList = False 'V4.27 �ŕ����B
			'AE_GotFocus = Cn_CuNop '-1
			If Cn_ai21 And Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.51C
				AE_GotFocus = Cn_CuCursorRest 'Cn_CuCursorRest '2 'V6.51C
			Else 'V6.51C
				AE_GotFocus = Cn_CuNop '-1
			End If 'V6.51C
		ElseIf PP.JustAfterSList Then  'V4.27 �ŕ����B
			PP.JustAfterSList = False 'V4.27 �ŕ����B
			AE_GotFocus = Cn_CuNop '-1 'V4.27 �ŕ����B
		Else
			'�ȉ��� Tab �L�[�� Mouse �Ŗ����Ƀt�H�[�J�X���ړ������ꍇ�B
			'V6.49 �ňȉ��̂S�s���폜�B
			'If PP.RightButtonTx = PP.Tx Then 'V6.49
			'    Ct.Enabled = False 'V6.49
			'    'Debug.Print "Ct.Enabled = False " & CStr(Ct.TabIndex)
			'End If 'V6.49
			'
			PP.CursorDirection = Cn_Direction0 '0: Mouse
			'wk_DeC = 0: If PP.ActiveDe >= 0 Or Not PP.DeApendable Then wk_DeC = 1
			wk_DeC = 0 : If PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then wk_DeC = 1 'V6.55I
			'wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not PP.EDeApendable Then wk_EDeC = 1
			wk_EDeC = 0 : If PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then wk_EDeC = 1 'V6.55I
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabStop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CP.TypeA <> Cn_OptionButtonH And CP.TypeA <> Cn_OptionButtonC And CP.TypeA <> Cn_CheckBox And (Not Ct.TabStop Or Not Ct.Enabled Or Not Ct.Visible) Then
				If PP.Mode = Cn_Mode3 And PP.Mode <> PP.ExMode Then
					PP.ExMode = PP.Mode
					AE_GotFocus = Cn_CuExTx '�ȑO�̍��ڂɃJ�[�\����߂��B
				ElseIf PP.Mode = PP.ExMode Then 
					'Beep 'V6.46 �ō폜�B
					AE_GotFocus = Cn_CuExTx '�ȑO�̍��ڂɃJ�[�\����߂��B
				Else
					PP.ExMode = PP.Mode
					AE_GotFocus = Cn_CuInit '�擪���ڂɃJ�[�\�����ړ��B
				End If
				Exit Function '--------------------
			ElseIf PP.AllowNullDes Then  'V6.47B
				AE_GotFocus = Cn_CuNop '-1
			ElseIf PP.Px >= PP.BodyTx And PP.Px < PP.EBodyPx And PP.De > PP.LastDe - wk_DeC Then 
				Beep()
				'"���̏�ɋ󔒂̖��׍s������̂ŁA�����Ƀf�[�^���C���v�b�g���邱�Ƃ͂ł��܂���B"
				If PP.Mode = PP.ExMode Then wk_Bool = AE_MsgLibrary(PP, "Cursor")
				AE_GotFocus = Cn_CuExTx : Exit Function '-------------------- '�ȑO�̍��ڂɃJ�[�\����߂��B
			ElseIf PP.Px >= PP.EBodyPx And PP.Px < PP.TailPx And PP.De > PP.LastEDe - wk_EDeC Then 
				Beep()
				'"���̏�ɋ󔒂̖��׍s������̂ŁA�����Ƀf�[�^���C���v�b�g���邱�Ƃ͂ł��܂���B"
				If PP.Mode = PP.ExMode Then wk_Bool = AE_MsgLibrary(PP, "Cursor")
				AE_GotFocus = Cn_CuExTx : Exit Function '-------------------- '�ȑO�̍��ڂɃJ�[�\����߂��B
			Else
				AE_GotFocus = Cn_CuNop '-1
			End If
		End If
		'���[�h�̐؂芷������𔻒肷�邽�߂� ExMode ���X�V����B
		PP.ExMode = PP.Mode
	End Function
	
	Sub AE_InitValSub(ByRef CP As clsCP, ByVal pm_Value As Object, ByVal pm_Status As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g CP.CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP.ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CP.ExVal = CP.CuVal
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(pm_Value) Then 'V4.27
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP.CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CP.CuVal = System.DBNull.Value 'V4.27
		Else 'V4.27
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val5() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP.CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CP.CuVal = AE_Val5(CP, pm_Value) 'V4.27
		End If 'V4.27
		'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP.CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If IsNothing(pm_Value) Then CP.CuVal = System.DBNull.Value
		CP.ExStatus = pm_Status
		CP.TpStr = AE_Format(CP, CP.CuVal, 0, True)
		CP.StatusC = Cn_Status8
		CP.StatusF = Cn_Status8
		CP.RelCheckStatus = "" 'V4.29
		'CP.ErrorFlg = False 'V6.53
		CP.CheckRtnCode = 0 'V6.54
	End Sub
	
	Sub AE_InitValSubNorm(ByRef CP As clsCP, ByVal pm_Value As Object, ByVal pm_Status As Short) 'V6.59NData
		Call AE_InitValSub(CP, AE_NormData(CP, pm_Value), pm_Status) 'V6.59NData
	End Sub
	
	'���d�v�F���̑���ɁAAE_InOutMode2 ���g�p���Ă��������B���� AE_InOutMode �͌݊����̂��߂Ɏc���Ă�����̂ł��B
	Public Sub AE_InOutMode(ByRef PP As clsPP, ByRef CP As clsCP, ByVal pm_Tx As Short, ByVal pm_Mode As String)
		If Len(pm_Mode) <> 4 Then
			Call AE_SystemError("AE_InOutMode �̃p�����^ pm_Mode$ ��", 150)
			Exit Sub '--------------------
		End If
		Call AE_InOutMode2(PP, CP, pm_Mode)
	End Sub
	
	'CP �Ŏw�肳�ꂽ���ڂ�Ώۂ� InOutMode ��ύX����B
	Public Sub AE_InOutMode2(ByRef PP As clsPP, ByRef CP As clsCP, ByVal pm_Mode As String)
		Static wk_Px As Short
		Static wk_Tx As Short
		If Len(pm_Mode) <> 4 Then
			Call AE_SystemError("AE_InOutMode2 �̃p�����^ pm_Mode$ ��", 151)
			Exit Sub '--------------------
		End If
		If Cn_ai21 Then Stop 'AE_InOutMode2 �̑���� AE_InOutModeN_̫�ї��� ���g�p���Ă��������B
		'If PP.RecalcMode Then Exit Sub '--------------------
		wk_Px = CP.CpPx
		CP.InOutMode = (CP.InOutMode \ 256) * 256 + CInt(Mid(pm_Mode, 1, 1)) * 64 + CInt(Mid(pm_Mode, 2, 1)) * 16 + CInt(Mid(pm_Mode, 3, 1)) * 4 + CInt(Mid(pm_Mode, 4, 1)) 'InOutMode V4.33
		wk_Tx = AE_Tx(PP, wk_Px)
		If wk_Tx >= 0 Then
			Select Case CP.TypeA
				Case Cn_NormalOrV, Cn_InputOnly
					'AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) 'V4.31
					'AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And ((CP.AutoEnter And Cn_Enabled) = Cn_Enabled) 'V6.47E
					AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) 'V6.47X
					'Control.TabStop �̐ݒ肠��B
				Case Cn_OptionButtonH, Cn_OptionButtonC, Cn_CheckBox 'V4.25
					'AE_Controls(PP.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) 'V4.31
					'���̂܂�
					'AE_Controls(PP.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And ((CP.AutoEnter And Cn_Enabled) = Cn_Enabled) 'V6.47E
					AE_Controls(PP.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) 'V6.47X
				Case Else 'Cn_OutputOnly, Cn_ListBox
			End Select
		End If
	End Sub
	
	'���d�v�F���̑���ɁAAE_InOutModeM_̫�ї��� ���g�p���Ă��������B���� AE_InOutModeM �͌݊����̂��߂Ɏc���Ă�����̂ł��B
	Public Sub AE_InOutModeM(ByRef PP As clsPP, ByRef CP As clsCP, ByVal pm_Mode As String)
		If Len(pm_Mode) <> 4 Then
			Call AE_SystemError("AE_InOutModeM �̃p�����^ pm_Mode$ ��", 152)
			Exit Sub '--------------------
		End If
		'
		Call AE_MsgBox("AE_InOutModeM_̫�ї���(""���۰ٗ���"", ""���o�̒l"") �Ƃ������[�`���ɐؑւ��Ă��������B", MsgBoxStyle.Exclamation, AE_Title) 'V4.24
	End Sub
	
	Public Function AE_IsEnable(ByVal pm_BlockNo As Short, ByVal pm_ActiveBlockNo As Short) As Boolean 'V6.47X
		If pm_ActiveBlockNo = -1 Then
			AE_IsEnable = True
		ElseIf pm_BlockNo = pm_ActiveBlockNo Then 
			AE_IsEnable = True
		Else
			AE_IsEnable = False
		End If
	End Function
	
	'KeyPress �C�x���g�̋��ʃ��[�`���B
	Public Sub AE_KeyPress(ByRef PP As clsPP, ByRef CP As clsCP, ByRef Ct As Object, ByRef pm_KeyAscii As Short)
		'pm_TA$ ----> CP.TpStr
		Static wk_Tx As Short
		Static wk_SL As Integer
		Static wk_Ln As Integer
		Static wk_SaveMaskMode As Boolean
		Static wk_Txt As String
		Static wk_SS As Integer
		Static wk_Moji As String
		Static wk_Moji2 As String
		Static wk_Moji3 As String
		Static st_Work As String
		Static wk_FractionC As Short
		Static wk_DeC As Short
		Static wk_EDeC As Short
		Static wk_FlushInput As Boolean
		'
		'Auto Enter �w��̍��ڂɂ��ẮA���{��̃C���v�b�g�� IME �ϊ����ꂽ�擪����
		'�̕�����ō��ڃt���ɂȂ�ƁA�㑱�̕ϊ���������󂯂�Ƃ��� PP.Tx �̕����i��
		'�ł��邪�ACT.TabIndex �̕��͌��̂܂܂Ȃ̂ŁAPP.Tx <> CT.TabIndex �ƂȂ邱��
		'������B�Ȃ��A�{�f�B���̃X�N���[������������ꍇ�A�X�N���[����� CT.TabIndex
		'�� PP.Tx ����v���Ă��܂��ꍇ�i�Ⴆ�΁A�{�f�B���ɍ��ڂ�������Ȃ��ꍇ�j��
		'�́A���̌��ۂ͊ɘa�����B
		wk_Tx = PP.Tx
		'
		If wk_Tx < 0 Or wk_Tx >= PP.ControlsC Then
			Call AE_SystemError("AE_KeyPress ��", 160)
			Exit Sub '--------------------
		End If
		If wk_Tx = PP.SuppressKeyPress Then 'V6.53
			PP.SuppressKeyPress = -1 'V6.53
			pm_KeyAscii = 0 'V6.53
			Exit Sub '--------------------
		End If
		'
		Select Case pm_KeyAscii 'V6.45
			'Case 3, 22, 24, 26 'Copy, Paste, Cut, UnDo
			'    Beep
			'    pm_KeyAscii = 0
			'    Exit Sub '--------------------
			Case 1 To 7, 9 To 12, 14 To 29, 127
				Beep()
				pm_KeyAscii = 0
				Exit Sub '--------------------
		End Select
		'
		'VB MultiLine Bug �̉�����u�B'V4.12
		If TypeOf Ct Is System.Windows.Forms.TextBox Then
			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.MultiLine �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Ct.MultiLine Then
				PP.MultiLineF = 2
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				st_Work = Mid(Ct, Ct.SelStart + 1, 1)
				If st_Work <> "" Then
					'If Asc(st_Work$) = pm_KeyAscii Then PP.MultiLineF = 1
					If (Asc(st_Work) = pm_KeyAscii And (pm_KeyAscii <> 32 Or CP.KeyInOkClass <> Asc("M"))) Or (st_Work = "�@" And pm_KeyAscii = 32 And CP.KeyInOkClass = Asc("M")) Then '�Q�o�C�g�����̃X�y�[�X�B'V6.52
						PP.MultiLineF = 1 'V6.52
					End If 'V6.52
				End If
			End If
		End If
		'
		PP.CursorDirection = Cn_Direction1 '1:Next
		'
		If pm_KeyAscii = System.Windows.Forms.Keys.Escape Then 'Esc 'V5.40
			pm_KeyAscii = 0
			Exit Sub '--------------------
		ElseIf CP.TypeA <> Cn_NormalOrV Then  'TypeA
			'If CP.TypeA <> Cn_InputOnly And pm_KeyAscii <> vbKeyEscape Then Beep 'ComboBox2 �ł� ESCAPE�B
			Beep()
			pm_KeyAscii = 0
			Exit Sub '--------------------
			'ElseIf Not Ct.TabStop Or Not Ct.Enabled Or Not Ct.Visible Then
			'ElseIf AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 And pm_KeyAscii <> vbKeyReturn Then 'V5.39
			'ElseIf (AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or (CP.AutoEnter And Cn_Enabled) = 0) And pm_KeyAscii <> vbKeyReturn Then 'V6.47E
			'ElseIf (AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo)) And pm_KeyAscii <> vbKeyReturn Then 'V6.47X
		ElseIf (Not AE_IsWritableInOutMode(PP, CP) Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo)) And pm_KeyAscii <> System.Windows.Forms.Keys.Return Then  'V6.59IsWritable
			'���͕s�̍��ڂ���̃C���v�b�g�B
			Beep()
			pm_KeyAscii = 0
			Exit Sub '--------------------
		End If
		'
		wk_Txt = (Ct) 'V4.33
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_SL = Ct.SelLength 'If CP.TypeA = Cn_NormalOrV Then
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_SS = Ct.SelStart 'wk_SS + 1 �����ڂ��J�����g�����B
		wk_FlushInput = False
		If CP.KeyInOkClass = Asc("1") Then 'V4.18
			wk_FlushInput = True 'V4.18
		ElseIf CP.KeyInOkClass = Asc("2") Then  'V4.30
			If wk_SS = 0 And wk_SL >= Len(RTrim(wk_Txt)) Then wk_FlushInput = True 'V4.30
		ElseIf CP.KeyInOkClass = Asc("3") Then  'V4.30
			If wk_SS = 0 And wk_SL >= Len(RTrim(wk_Txt)) Then wk_FlushInput = True 'V4.30
			'ElseIf wk_SL = CP.MaxLength And wk_SL > 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Left$(wk_Txt$, wk_SL)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf wk_SS = 0 And LenWid(Left(wk_Txt, wk_SL)) = CP.MaxLength And wk_SL > 0 Then  'V6.45
			PP.Override = 1
			wk_FlushInput = True
		ElseIf wk_SL > 1 Then 
			If (CP.FormatClass = Cn_Memo Or CP.FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
			Else 'V6.52
				Beep()
			End If 'V6.52
			PP.Override = 1
			'      pm_KeyAscii = 0
			'      Exit Sub '--------------------
		ElseIf wk_SL = 1 Then 
			PP.Override = 1
		ElseIf wk_SL = 0 And wk_SS < Len(wk_Txt) Then 
			PP.Override = 0
		End If
		'
		If pm_KeyAscii = 32 And CP.KeyInOkClass = Asc("M") Then pm_KeyAscii = Asc("�@") '�Q�o�C�g�����̃X�y�[�X�B'V6.52
		wk_Moji = Chr(pm_KeyAscii) '�C���v�b�g�����B
		Static wk_Ln2 As Short
		If AE_KeyInOkChar(PP, wk_Moji, CP.KeyInOkClass) Then
			'wk_DeC = 0: If PP.ActiveDe >= 0 Or Not PP.DeApendable Then wk_DeC = 1
			wk_DeC = 0 : If PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then wk_DeC = 1 'V6.55I
			'wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not PP.EDeApendable Then wk_EDeC = 1
			wk_EDeC = 0 : If PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then wk_EDeC = 1 'V6.55I
			'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Then
			'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or (CP.AutoEnter And Cn_Enabled) = 0 Then 'V6.47E
			'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.47X
			If Not AE_IsWritableInOutMode(PP, CP) Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.59IsWritable
				wk_Bool = AE_MsgLibrary(PP, "OutputOnly")
				pm_KeyAscii = 0 : Exit Sub '--------------------
				'ElseIf PP.Px >= PP.BodyTx And PP.Px < PP.EBodyPx And PP.De > PP.LastDe - wk_DeC Then
			ElseIf Not PP.AllowNullDes And (PP.Px >= PP.BodyTx And PP.Px < PP.EBodyPx And PP.De > PP.LastDe - wk_DeC) Then  'V6.47B
				'"�����Ƀf�[�^���C���v�b�g���邱�Ƃ͂ł��܂���B"
				wk_Bool = AE_MsgLibrary(PP, "InActiveDe")
				pm_KeyAscii = 0 : Exit Sub '--------------------
				'ElseIf PP.Px >= PP.EBodyPx And PP.Px < PP.TailPx And PP.De > PP.LastEDe - wk_EDeC Then
			ElseIf Not PP.AllowNullDes And (PP.Px >= PP.EBodyPx And PP.Px < PP.TailPx And PP.De > PP.LastEDe - wk_EDeC) Then  'V6.47B
				'"�����Ƀf�[�^���C���v�b�g���邱�Ƃ͂ł��܂���B"
				wk_Bool = AE_MsgLibrary(PP, "InActiveDe")
				pm_KeyAscii = 0 : Exit Sub '--------------------
			Else
				'�a��̃`�F�b�N�����B
				If CP.KeyInOkClass = Asc("W") Then
					If wk_SS = 0 And InStr("01234", wk_Moji) > 0 Then 'V4.15
						wk_Moji = Mid("�����喾��", CShort(wk_Moji) + 1, 1) 'V4.15
					ElseIf wk_SS = 0 Xor InStr("Mm��Tt��Ss��Hh��", wk_Moji) > 0 Then 
						pm_KeyAscii = 0
						Beep()
						Exit Sub '--------------------
					End If
				End If
				'�Œ�t�H�[�}�b�g�̍��ڂ̃f�[�^������Ȃ��悤�Ƀ`�F�b�N�B
				If CP.FixedFormat = 1 Then
					wk_Moji2 = Mid(wk_Txt, wk_SS + 1, 1)
					If PP.Override And wk_SL <> 1 Then
						'Beep ���́A��Ŗ炵�Ă���̂ŁA�����ł͍s��Ȃ��B
						pm_KeyAscii = 0 : Exit Sub '--------------------
						'ElseIf Not AE_KeyInOkChar(PP, wk_Moji2$, CP.KeyInOkClass) Then
					ElseIf Not AE_KeyInOkChar(PP, wk_Moji2, CP.KeyInOkClass) And wk_Moji2 <> Space(1) And wk_Moji2 <> "�@" Then  '�Q�o�C�g�����̃X�y�[�X�B'V4.15
						Beep()
						pm_KeyAscii = 0 : Exit Sub '--------------------
						'Else
						'���ʏ���
					End If
				End If
				'
				pm_KeyAscii = Asc(wk_Moji) 'AE_KeyInOkChar �ŕ������ύX����邱�Ƃ����邽�߂̏��u�B
				If wk_FlushInput = True Then
					wk_Txt = Mid(wk_Txt, wk_SS + 1, 1)
					wk_SaveMaskMode = PP.MaskMode
					PP.MaskMode = True
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct = wk_Txt '�����ł��AChange �C�x���g���������邪�����B
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.SelStart = wk_SS
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.SelLength = PP.Override 'If CP.TypeA = Cn_NormalOrV Then
					PP.MaskMode = wk_SaveMaskMode
				ElseIf PP.Override >= 1 Then  '���ۂɂ� PP.Override = 1
					wk_Moji2 = Mid(wk_Txt, wk_SS + 1, 1)
					If wk_Moji2 = "" Or wk_Moji2 = Space(1) Or wk_Moji2 = "\" Or wk_Moji2 = "�@" Then '�Q�o�C�g�����̃X�y�[�X�B
					ElseIf Not AE_KeyInOkChar(PP, wk_Moji2, CP.KeyInOkClass) Then 
						If wk_SL <= 1 Then Beep()
						pm_KeyAscii = 0 : Exit Sub '--------------------
					End If
					'���l�̃`�F�b�N�B'V5.41
					If AE_Numerical(CP.FormatClass) Then 'V6.50
						wk_Moji2 = Mid(wk_Txt, wk_SS + 1, 1)
						If wk_Moji <> wk_Moji2 And InStr("0123456789 ", wk_Moji) = 0 Then 'V6.48
							Select Case wk_Moji
								Case "+"
									If wk_Moji2 <> "-" And wk_Moji2 <> "" And wk_Moji2 <> Space(1) Then
										Beep()
										pm_KeyAscii = 0 : Exit Sub '--------------------
									End If
								Case "-"
									If wk_Moji2 <> "" And wk_Moji2 <> Space(1) Then
										Beep()
										pm_KeyAscii = 0 : Exit Sub '--------------------
									End If
								Case "."
									If InStr(wk_Txt, ".") > 0 Or InStr(CP.FormatChr, ".") = 0 Then 'V6.48
										'Beep
										If PP.SuppressBeep Then 'V6.49
											PP.SuppressBeep = False 'V6.49
										Else 'V6.49
											Beep()
										End If
										pm_KeyAscii = 0 : Exit Sub '--------------------
									End If
								Case Else 'V6.48
									Beep() 'V6.48
									pm_KeyAscii = 0 : Exit Sub '--------------------
							End Select
						End If
					End If
					'
					If wk_SL > 1 And (CP.FormatClass = Cn_Memo Or CP.FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
						If CP.Alignment <> 1 Then 'V6.52
							'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Chr$(pm_KeyAscii)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							wk_Txt = Left(wk_Txt, wk_SS) & Chr(pm_KeyAscii) & Mid(wk_Txt, wk_SS + wk_SL + 1) & Space(LenWid(Mid(Ct, wk_SS + 1, wk_SL)) - LenWid(Chr(pm_KeyAscii))) 'V6.52
						Else 'V6.52
							'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Chr$(pm_KeyAscii)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							wk_Txt = Space(LenWid(Mid(Ct, wk_SS + 1, wk_SL)) - LenWid(Chr(pm_KeyAscii))) & Left(wk_Txt, wk_SS) & Chr(pm_KeyAscii) & Mid(wk_Txt, wk_SS + wk_SL + 1) 'V6.52
							pm_KeyAscii = 0 'V6.52
						End If 'V6.52
					ElseIf Len(wk_Txt) >= wk_SS + 1 Then 
						wk_Txt = Left(wk_Txt, wk_SS) & Chr(pm_KeyAscii) & Mid(wk_Txt, wk_SS + 2) 'V4.05
						'If pm_KeyAscii = -32448 And Mid$(wk_Txt$, wk_SS + 1, 1) = Space$(1) And Mid$(wk_Txt$, wk_SS + 2, 1) = Space$(1) Then 'V6.52
						'    wk_Txt$ = Left$(wk_Txt$, wk_SS) & Chr$(pm_KeyAscii) & Mid$(wk_Txt$, wk_SS + 3) 'V6.52
						'Else 'V6.52
						'    wk_Txt$ = Left$(wk_Txt$, wk_SS) & Chr$(pm_KeyAscii) & Mid$(wk_Txt$, wk_SS + 2) 'V4.05
						'End If 'V6.52
					End If
					wk_SaveMaskMode = PP.MaskMode
					PP.MaskMode = True
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct = wk_Txt '�����ł��AChange �C�x���g���������邪�����B
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.SelStart = wk_SS
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.SelLength = PP.Override 'If CP.TypeA = Cn_NormalOrV Then
					PP.MaskMode = wk_SaveMaskMode
				Else 'If PP.Override = 0 Then
					'���l�̃`�F�b�N�B'V5.41
					If AE_Numerical(CP.FormatClass) Then 'V6.50
						If InStr("0123456789 ", wk_Moji) = 0 Then 'V6.48
							wk_Moji2 = "" : If wk_SS > 0 Then wk_Moji2 = Mid(wk_Txt, wk_SS, 1)
							wk_Moji3 = Trim(Left(wk_Txt, wk_SS))
							Select Case wk_Moji
								Case "+"
									If wk_Moji3 <> "" And wk_Moji2 <> "\" Then 'V6.48
										Beep()
										pm_KeyAscii = 0 : Exit Sub '--------------------
									End If 'V6.48
								Case "-"
									If wk_Moji3 <> "" And wk_Moji2 <> "\" Then 'V6.48
										Beep()
										pm_KeyAscii = 0 : Exit Sub '--------------------
									End If 'V6.48
								Case "."
									If InStr(wk_Txt, ".") > 0 Or InStr(CP.FormatChr, ".") = 0 Then 'V6.48
										Beep()
										pm_KeyAscii = 0 : Exit Sub '--------------------
									End If
								Case Else 'V6.48
									Beep() 'V6.48
									pm_KeyAscii = 0 : Exit Sub '--------------------
							End Select
						End If
					End If
				End If
				CP.CIn = Cn_ChrInput '2: Character Input
				'AE_EndOfCharacterCheck: 'V4.22
			End If
		Else 'If Not AE_KeyInOkChar(PP, wk_Moji$, CP.KeyInOkClass) Then
			Select Case pm_KeyAscii
				Case System.Windows.Forms.Keys.Return 'RETURN is caught and processed by KeyDown.
					'�����ɐ��䂪�n����邱�Ƃ͂Ȃ��B
					pm_KeyAscii = 0
				Case System.Windows.Forms.Keys.Back 'Back Space
					pm_KeyAscii = 0
					'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Then
					'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or (CP.AutoEnter And Cn_Enabled) = 0 Then 'V6.47E
					'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.47X
					If Not AE_IsWritableInOutMode(PP, CP) Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.59IsWritable
						Exit Sub '--------------------
					ElseIf CP.KeyInOkClass = Asc("-") Then  'V5.39
						Exit Sub '--------------------
					ElseIf CP.FixedFormat = 1 Then 
						If AE_KeyInOkChar(PP, Space(1), CP.KeyInOkClass) Then
							'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							wk_Txt = Left(wk_Txt, wk_SS) & Space(LenWid(Mid(wk_Txt, wk_SS + 1, 1))) & Mid(wk_Txt, wk_SS + 2)
						End If
						Do While wk_SS > 0 '�\������Ă��镶�� Moji2$ �𒲂� wk_SS ��i�߂�B
							wk_Moji2 = Mid(wk_Txt, wk_SS, 1)
							wk_SS = wk_SS - 1
							If AE_KeyInOkChar(PP, wk_Moji2, CP.KeyInOkClass) Then GoTo AE_KeyPressSetCt1 '---------->
						Loop 
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						wk_SS = Ct.SelStart '���Ƃ� SelStart �̂܂܂ɂ���B
AE_KeyPressSetCt1: 
						CP.TpStr = wk_Txt
						PP.MaskMode = True 'Change �C�x���g�𖳎����郂�[�h�B
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Ct = CP.TpStr '�����ŁAChange �C�x���g����������B
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Ct.SelStart = wk_SS
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Ct.SelLength = PP.Override 'If CP.TypeA = Cn_NormalOrV Then
						PP.MaskMode = wk_SaveMaskMode
						'PP.InitValStatus = Cn_ModeDataChanged
						Call AE_SetInitValStatus(PP, CP) 'V6.56S
						CP.StatusC = Cn_Status1 'Incomplete
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Ct.ForeColor = AE_Color(Cn_Status1) 'Incomplete
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If CP.TypeA = Cn_NormalOrV Or CP.TypeA = Cn_InputOnly Then Ct.BackColor = PP.BrightOnOff
						Exit Sub '--------------------
					ElseIf CP.MaxLength = 0 Then 
						If wk_SS = 0 Then
							If Len(wk_Txt) > 0 Then wk_Txt = Right(wk_Txt, Len(wk_Txt) - 1)
						Else
							wk_Txt = Left(wk_Txt, wk_SS - 1) & Mid(wk_Txt, wk_SS + 1)
							wk_SS = wk_SS - 1
						End If
						CP.TpStr = AE_Format(CP, AE_Val(CP, wk_Txt, wk_FractionC), wk_FractionC, False) 'V4.34
					ElseIf CP.Alignment = 1 Then  '�E�l�� And CP.FixedFormat <> 1 And CP.MaxLength <> 0
						wk_Ln = Len(wk_Txt)
						If AE_Numerical(CP.FormatClass) Then 'V6.50
							'If Cn_ai21 Then 'V6.48
							'    wk_Txt$ = Left$(wk_Txt$, wk_SS) 'V6.48
							'    CP.TpStr = AE_Format$(CP, AE_Val(CP, wk_Txt$, wk_FractionC), wk_FractionC, False) 'V6.48
							'    wk_SS = wk_Ln
							'    GoTo AE_KeyPressSetCt2 '---------->
							'Else
							'�����_�� Delete ���邱�ƂŤ �����I�[�o���錅���ɂȂ�Ȃ����`�F�b�N����B
							If wk_SS = 0 Then 'V6.L45
							ElseIf Mid(wk_Txt, wk_SS, 1) = "." Then  'V6.L48
								wk_Ln2 = Len(Trim(AE_Format(CP, AE_Val(CP, Left(wk_Txt, wk_SS - 1) & Mid(wk_Txt, wk_SS + 1), wk_FractionC), wk_FractionC, True))) 'V6.L48
								If wk_Ln2 > CP.MaxLength Or (wk_Ln2 > CP.MaxLength - 1 And (CP.FormatClass = Cn_Snum Or CP.FormatClass = Cn_Schn) And InStr(wk_Txt, "-") = 0) Then 'V6.L48 'V6.L50N '������
									Beep() 'V6.L45
									Exit Sub '--------------------
								End If 'V6.L48
							End If 'V6.L45
						End If
						'
						If wk_SS > 0 Then
							If AE_KeyInOkChar(PP, Mid(wk_Txt, wk_SS, 1), CP.KeyInOkClass) Then
								st_Work = Left(wk_Txt, wk_SS)
								If RTrim(wk_Txt) <> "" Then
									'LenWid ��p����B
									'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									wk_Txt = Space(LenWid(Left(st_Work, 1))) & Left(st_Work, Len(st_Work) - 1) & Right(wk_Txt, wk_Ln - wk_SS)
								Else
									wk_Txt = Space(CP.MaxLength)
								End If
							ElseIf wk_SS > 1 Then 
								st_Work = Left(wk_Txt, wk_SS - 1)
								If RTrim(wk_Txt) <> "" Then
									'LenWid ��p����B
									'wk_Txt$ = Space$(LenWid(Left$(st_Work$, 1))) & Left$(st_Work$, Len(st_Work$) - 1) & Right$(wk_Txt$, wk_Ln - wk_SS + 1)
									'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									wk_Txt = Space(LenWid(Left(st_Work, 1))) & Left(st_Work, Len(st_Work)) & Right(wk_Txt, wk_Ln - wk_SS) 'V6.57
								Else
									wk_Txt = Space(CP.MaxLength)
								End If
							End If
						Else
							Exit Sub '--------------------
						End If
						If AE_Numerical(CP.FormatClass) Then 'V6.50
							'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
							If IsDbNull(AE_Val(CP, wk_Txt, wk_FractionC)) Then 'V4.31
								wk_SS = wk_Ln 'V6.48
								'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val(CP, wk_Txt$, wk_FractionC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							ElseIf AE_Val(CP, wk_Txt, wk_FractionC) = 0 Then  'V4.31
								wk_Txt = "" 'V4.31
								wk_SS = wk_Ln 'V6.48
							End If 'V4.31
						End If 'V4.31
						CP.TpStr = AE_Format(CP, AE_Val(CP, wk_Txt, wk_FractionC), wk_FractionC, False) 'V4.34
						Do While wk_SS < wk_Ln 'V4.34
							If AE_KeyInOkChar(PP, Mid(CP.TpStr, wk_SS + 1, 1), CP.KeyInOkClass) Then Exit Do '---------- 'V4.34
							wk_SS = wk_SS + 1 'V4.34
						Loop  'V4.34
					Else '���l�� And CP.FixedFormat <> 1 And CP.MaxLength <> 0
						If AE_Numerical(CP.FormatClass) Then 'V6.50
							If Cn_ai21 Then 'V6.48
								wk_Txt = Left(wk_Txt, wk_SS) 'V6.48
								CP.TpStr = AE_Format(CP, AE_Val(CP, wk_Txt, wk_FractionC), wk_FractionC, False) 'V6.48
								wk_SS = wk_Ln
								GoTo AE_KeyPressSetCt2 '---------->
							End If
						End If
						If wk_SS = 0 Then
							If RTrim(wk_Txt) <> "" Then
								'Len �� LenWid ��p����B
								'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								wk_Txt = Right(wk_Txt, Len(wk_Txt) - 1) & Space(LenWid(Left(wk_Txt, 1)))
							Else
								wk_Txt = Space(CP.MaxLength)
							End If
						Else
							'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							wk_Txt = Left(wk_Txt, wk_SS - 1) & Mid(wk_Txt, wk_SS + 1) & Space(LenWid(Mid(wk_Txt, wk_SS, 1)))
							wk_SS = wk_SS - 1
						End If
						If AE_Numerical(CP.FormatClass) Then 'V6.50
							'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
							If IsDbNull(AE_Val(CP, wk_Txt, wk_FractionC)) Then 'V4.31
								'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val(CP, wk_Txt$, wk_FractionC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							ElseIf AE_Val(CP, wk_Txt, wk_FractionC) = 0 Then  'V4.31
								wk_Txt = "" 'V4.31
							End If 'V4.31
						End If 'V4.31
						CP.TpStr = AE_Format(CP, AE_Val(CP, wk_Txt, wk_FractionC), wk_FractionC, False) 'V4.34
					End If
AE_KeyPressSetCt2: 
					wk_SaveMaskMode = PP.MaskMode
					PP.MaskMode = True 'Change �C�x���g�𖳎����郂�[�h�B
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct = CP.TpStr '�����ŁAChange �C�x���g����������B
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.SelStart = wk_SS
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.SelLength = PP.Override 'If CP.TypeA = Cn_NormalOrV Then
					PP.MaskMode = wk_SaveMaskMode
					'PP.InitValStatus = Cn_ModeDataChanged
					Call AE_SetInitValStatus(PP, CP) 'V6.56S
					CP.StatusC = Cn_Status1 'Incomplete
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.ForeColor = AE_Color(Cn_Status1) 'Incomplete
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If CP.TypeA = Cn_NormalOrV Or CP.TypeA = Cn_InputOnly Then Ct.BackColor = PP.BrightOnOff
				Case System.Windows.Forms.Keys.Escape 'Esc 'V5.40
				Case Else
					pm_KeyAscii = 0
					'Beep
					If PP.SuppressBeep Then 'V6.49
						PP.SuppressBeep = False 'V6.49
					Else 'V6.49
						Beep()
					End If
			End Select
		End If
	End Sub
	
	Public Function AE_NormData(ByRef CP As clsCP, ByVal pm_Value As Object) As Object 'V6.59NData
		Dim wk_FractionC As Short
		Dim wk_Txt As String
		wk_Txt = AE_Format(CP, pm_Value, wk_FractionC, True)
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_NormData = AE_Val(CP, wk_Txt, wk_FractionC)
	End Function
	
	Public Function AE_Numerical(ByVal pm_FormatClass As Short) As Boolean 'V6.50
		Select Case pm_FormatClass 'V6.50
			Case Cn_Numb, Cn_Snum, Cn_Chnu, Cn_Schn 'V6.50
				AE_Numerical = True
			Case Else
				AE_Numerical = False
		End Select
	End Function
	
	Public Sub AE_NotRelCheckError(ByRef CP_StatusC As Short)
		If CP_StatusC >= Cn_Status6 Then
			CP_StatusC = CP_StatusC + 3
		ElseIf CP_StatusC >= Cn_Status3 Then 
			CP_StatusC = CP_StatusC + 6
		End If
	End Sub
	
	Public Sub AE_Paste(ByRef PP As clsPP, ByRef CP As clsCP, ByRef Ct As System.Windows.Forms.TextBox) 'V6.55
		Dim wk_Clip As String
		Dim wk_Moji As String
		Dim wk_Txt As String
		Dim st_Work1 As String
		Dim st_Work2 As String
		Dim wk_MaxLB As Short
		Dim wk_ii As Short
		Dim wk_Ln As Short
		Dim st_Work3 As String 'V6.57
		'UPGRADE_ISSUE: Clipboard ���\�b�h Clipboard.GetText �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
		wk_Clip = My.Computer.Clipboard.GetText()
		wk_Txt = ""
		Do While wk_Clip <> ""
			wk_Moji = Left(wk_Clip, 1)
			If AE_KeyInOkChar(PP, wk_Moji, CP.KeyInOkClass) Then wk_Txt = wk_Txt & wk_Moji
			wk_Clip = Mid(wk_Clip, 2)
		Loop 
		'
		wk_MaxLB = CP.MaxLength
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If wk_MaxLB = 0 Then wk_MaxLB = LenWid(wk_Txt)
		If wk_MaxLB = 0 Then Exit Sub '---------->
		'
		If CP.Alignment = 1 Then '�E�l�߁B
			wk_Ln = wk_MaxLB
			Do 
				st_Work2 = RightWid(wk_Txt, wk_Ln)
				If CP.FormatChr <> "" Then
					On Error Resume Next
					st_Work2 = FormatAndRound(RightWid(wk_Txt, wk_Ln), CP.FormatChr)
				End If
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work2$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If LenWid(st_Work2) <= wk_MaxLB Then Exit Do '---------->
				wk_Ln = wk_Ln - 1
			Loop 
			'
			CP.CIn = Cn_ChrInput '2: Character Input
			Ct.Text = st_Work2
			Ct.SelectionStart = wk_MaxLB
			Ct.SelectionLength = PP.Override
		Else '���l�߁B
			If CP.FormatChr <> "" And CP.FormatClass = Cn_Date Then
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_Ln = LenWid(AE_TrimS(CP.FormatChr))
				wk_Txt = LeftWid(wk_Txt, wk_Ln)
			End If
			'
			st_Work3 = "" 'V6.57
			If PP.SpecSubID = "sss" And (CP.FormatClass >= Cn_Code And CP.FormatClass <= Cn_Name) Then 'V6.57
				st_Work1 = "" 'V6.57
				If Ct.SelectionLength >= 2 Then 'V6.57
					st_Work3 = Mid(Ct.Text, Ct.SelectionStart + Ct.SelectionLength + 1) 'V6.57
				End If 'V6.57
			Else 'V6.57
				st_Work1 = Ct.Text
			End If 'V6.57
			st_Work2 = Left(Ct.Text, Ct.SelectionStart)
			wk_Ln = 0
			For wk_ii = Ct.SelectionStart + 1 To wk_MaxLB 'V6.57
				wk_Moji = Mid(st_Work1, wk_ii, 1)
				If wk_Txt = "" Then
				ElseIf wk_Moji = " " Or wk_Moji = "" Then 
					wk_Moji = Left(wk_Txt, 1)
					wk_Txt = Mid(wk_Txt, 2)
				ElseIf AE_KeyInOkChar(PP, wk_Moji, CP.KeyInOkClass) Then 
					wk_Moji = Left(wk_Txt, 1)
					wk_Txt = Mid(wk_Txt, 2)
				End If
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				wk_Ln = wk_Ln + LenWid(wk_Moji)
				If wk_Ln > wk_MaxLB Then Exit For '---------->
				st_Work2 = st_Work2 & wk_Moji
				If wk_Ln = wk_MaxLB Then Exit For '---------->
			Next wk_ii
			'
			CP.CIn = Cn_ChrInput '2: Character Input
			Ct.Text = LeftWid(st_Work2 & st_Work3, wk_MaxLB) 'V6.57
			Ct.SelectionStart = 0
			Ct.SelectionLength = PP.Override
		End If
	End Sub
	
	Public Function AE_PopupMenu(ByRef PP As clsPP, ByRef CP As clsCP, ByRef Ct As Object) As Boolean 'V6.55S
		'�u���� PP.CursorSave = -1 'V6.55S
		'�u���� If PP.Tx = Ct.TabIndex Then Call AE_SaveFocus(PP) 'V6.55S
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If PP.Tx = Ct.TabIndex Then 'V6.59Pop
			PP.PopupTx = PP.Tx 'V6.59Pop
		Else
			PP.PopupTx = -1 'V6.59Pop
		End If
		PP.NeglectPopupFocus = True 'V6.59Pop
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Ct.Enabled = False 'V6.49
		'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP.ShortCutTx = Ct.TabIndex 'V6.55S
		AE_PopupMenu = False 'V6.55S
		Const CF_TEXT As Short = 1
		If TypeOf Ct Is System.Windows.Forms.TextBox Then
			'UPGRADE_ISSUE: Clipboard ���\�b�h Clipboard.GetFormat �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
			If My.Computer.Clipboard.GetFormat(CF_TEXT) Then
				'If AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then AE_PopupMenu = (PP.Tx = Ct.TabIndex) 'V6.47X
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.TabIndex �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_IsWritableInOutMode(PP, CP) And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then AE_PopupMenu = (PP.Tx = Ct.TabIndex) 'V6.59IsWritable
			End If
		End If
		'V6.57 If CP.FixedFormat = 1 Then AE_PopupMenu = False
		'PopupMenu SM_ShortCut, vbPopupMenuRightButton 'V6.49
		'If PP.CursorSave = CT.TabIndex Then Call AE_RestoreFocus(PP) 'V6.55S
		'CT.Enabled = True 'V6.49
	End Function
	
	Public Function AE_Px(ByRef PP As clsPP, ByVal pm_Tx As Short) As Short
		Static wk_ww As Short
		If pm_Tx < 0 Or pm_Tx >= PP.ControlsC Then
			Call AE_SystemError("AE_Px �̃p�����^��", 170)
			AE_Px = 0
		ElseIf pm_Tx < PP.BodyTx Then 
			AE_Px = pm_Tx
		ElseIf pm_Tx < PP.EBodyTx Then 
			wk_ww = pm_Tx - PP.BodyTx
			AE_Px = PP.BodyPx + wk_ww Mod PP.BodyN + (wk_ww \ PP.BodyN + PP.TopDe) * PP.BodyV
		ElseIf pm_Tx < PP.TailTx Then 
			wk_ww = pm_Tx - PP.EBodyTx
			AE_Px = PP.EBodyPx + wk_ww Mod PP.EBodyN + (wk_ww \ PP.EBodyN + PP.TopEDe) * PP.EBodyV
		Else
			AE_Px = pm_Tx - PP.TailTx + PP.TailPx
		End If
	End Function
	
	Public Sub AE_Resize(ByRef PP As clsPP)
	End Sub
	
	'�ǂ̃R���g���[���Ƀt�H�[�J�X�����邩�Ƃ����ʒu�𕜌�����B
	Public Sub AE_RestoreFocus(ByRef PP As clsPP)
		If PP.CursorSave >= 0 Then
			PP.TimerWorkId = 8
			AE_Timer(PP.ScX).Interval = 10
			AE_Timer(PP.ScX).Enabled = True
		End If
	End Sub
	
	'�ǂ̃R���g���[���Ƀt�H�[�J�X�����邩�Ƃ����ʒu��ۑ�����B
	Public Sub AE_SaveFocus(ByRef PP As clsPP)
		PP.CursorSet = True
		PP.CursorSave = PP.Tx
		If PP.CursorSave >= 0 Then
			AE_CursorRest(PP.ScX).TabStop = True
			PP.CursorToWhere = Cn_CursorToRest
			PP.NextTx = Cn_NextTxCleared
			On Error Resume Next 'V4.32
			AE_CursorRest(PP.ScX).Focus()
		End If
	End Sub
	
	Public Function AE_ScrlDisp(ByRef PP As clsPP, ByVal pm_DeNo As Short) As Short
		Static wk_DeC As Short
		Static wk_Displacement As Short
		Static wk_MaxDe As Short 'V4.28
		Static wk_Limit As Short 'V6.46S
		'If PP.No2Scroll And Not PP.DeApendable And PP.Mode >= Cn_Mode3 Then 'V6.46S
		If PP.No2Scroll And Not AE_GetDeApendable(PP) And PP.Mode >= Cn_Mode3 Then 'V6.55I
			wk_Limit = PP.LastDe - 1 'V6.46S
		Else 'V6.46S
			wk_Limit = PP.MaxDe 'V6.46S
		End If 'V6.46S
		'
		'wk_DeC = 0: If PP.ActiveDe >= 0 Or Not PP.DeApendable Then wk_DeC = 1 'V6.52
		wk_DeC = 0 : If PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then wk_DeC = 1 'V6.55I
		'�_���I�ȏ����ɂ���� wk_Displacement ���Z�o����B
		If PP.AllowNullDes Then 'V6.47B
			wk_Displacement = pm_DeNo - PP.TopDe 'V6.47B
		ElseIf PP.MaxDspC = 0 Then  '�{�f�B���� 1 �s�̏ꍇ�B
			If PP.LastDe - wk_DeC <= 0 Then
				wk_Displacement = 0
			ElseIf pm_DeNo > PP.LastDe - wk_DeC Then 
				wk_Displacement = 0
			Else
				wk_Displacement = pm_DeNo - PP.TopDe
			End If
		Else
			If PP.MaxDspC >= PP.MaxDe Then 'PP.MaxDe - PP.MaxDspC = 0 'V6.48
				wk_Displacement = 0 'V6.48
				'If PP.LastDe - wk_DeC <= PP.MaxDspC And PP.ReadableMaxDe <= PP.MaxDspC Then 'V4.29
			ElseIf PP.TopDe = 0 And PP.LastDe - wk_DeC <= PP.MaxDspC And PP.ReadableMaxDe <= PP.MaxDspC Then  'V4.32
				wk_Displacement = 0 'V4.29
			ElseIf pm_DeNo < PP.ReadableMaxDe - PP.MaxDspC And PP.ReadableMaxDe >= wk_Limit Then  'V6.46S
				wk_Displacement = pm_DeNo - PP.TopDe 'V4.28
			ElseIf pm_DeNo >= PP.ReadableMaxDe - PP.MaxDspC And PP.ReadableMaxDe > PP.LastDe Then  'V4.28
				wk_Displacement = PP.ReadableMaxDe - PP.MaxDspC - PP.TopDe 'V4.28
			ElseIf pm_DeNo >= PP.LastDe - wk_DeC And pm_DeNo >= PP.ReadableMaxDe - PP.MaxDspC Then  'V4.28
				wk_Displacement = PP.LastDe - wk_DeC - 1 - PP.TopDe 'V4.28
				'ElseIf PP.TopDe + PP.LastDe - wk_DeC <= PP.MaxDspC Then
				'ElseIf PP.LastDe - wk_DeC <= PP.MaxDspC Then 'V4.28
			ElseIf PP.TopDe = 0 And PP.LastDe - wk_DeC <= PP.MaxDspC Then  'V4.32
				wk_Displacement = 0
			Else
				wk_Displacement = pm_DeNo - PP.TopDe
			End If
		End If
		'�����I�Ȑ���̃`�F�b�N�B
		If wk_Limit > PP.ReadableMaxDe Then 'V6.46S
			wk_MaxDe = wk_Limit 'V6.46S
		Else 'V4.28
			wk_MaxDe = PP.ReadableMaxDe 'V4.28
		End If 'V4.28
		If PP.TopDe + wk_Displacement < 0 Then
			AE_ScrlDisp = -PP.TopDe
			'ElseIf PP.TopDe + wk_Displacement > wk_MaxDe - PP.MaxDspC Then 'V4.28
		ElseIf PP.TopDe + wk_Displacement > wk_MaxDe - PP.MaxDspC And wk_MaxDe - PP.MaxDspC > 0 Then  'V6.46S 'V6.47(4)
			AE_ScrlDisp = wk_MaxDe - PP.MaxDspC - PP.TopDe 'V4.28
		Else
			AE_ScrlDisp = wk_Displacement
		End If
	End Function
	
	Public Sub AE_ScrlMax(ByRef PP As clsPP)
		Static wk_DeC As Short
		Static wk_Max As Short 'V4.28
		Static wk_Limit As Short 'V6.46S
		'If PP.No2Scroll And Not PP.DeApendable And PP.Mode >= Cn_Mode3 Then 'V6.46S
		If PP.No2Scroll And Not AE_GetDeApendable(PP) And PP.Mode >= Cn_Mode3 Then 'V6.55I
			wk_Limit = PP.LastDe - 1 'V6.46S
		Else 'V6.46S
			wk_Limit = PP.MaxDe 'V6.46S
		End If 'V6.46S
		'
		'wk_DeC = 0: If PP.ActiveDe >= 0 Or Not PP.DeApendable Then wk_DeC = 1
		wk_DeC = 0 : If PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then wk_DeC = 1 'V6.55I
		If PP.MaxDspC = 0 Then '�{�f�B���� 1 �s�̏ꍇ�B
			wk_Max = PP.LastDe - wk_DeC 'V4.28
			'ElseIf PP.TopDe + PP.LastDe - wk_DeC <= PP.MaxDspC Then
		ElseIf PP.TopDe = 0 And PP.LastDe - wk_DeC <= PP.MaxDspC Then  'V4.32
			wk_Max = 0 'V4.28
		ElseIf PP.LastDe - wk_DeC > wk_Limit - PP.MaxDspC Then  'V6.46S
			wk_Max = wk_Limit - PP.MaxDspC 'V6.46S
		Else
			wk_Max = PP.LastDe - wk_DeC - 1 'V4.28
		End If
		'
		If PP.AllowNullDes Then 'V6.47B
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_ScrlBar().Max �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_ScrlBar(PP.ScX).Max = wk_Limit - PP.MaxDspC 'V6.47B, 'V6.46S
		ElseIf wk_Max > PP.ReadableMaxDe - PP.MaxDspC Then  'V4.28
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_ScrlBar().Max �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_ScrlBar(PP.ScX).Max = wk_Max 'V4.28
		Else 'V4.28
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_ScrlBar().Max �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_ScrlBar(PP.ScX).Max = PP.ReadableMaxDe - PP.MaxDspC 'V4.28
		End If 'V4.28
	End Sub
	
	Public Sub AE_SetCp(ByRef CP As clsCP, ByVal pm_Px As Object, ByRef pm_SmrBuf As String, ByRef pm_CQ As String)
		Static wk_Item As String
		Static wk_InOutMode As Integer 'V4.29
		Static wk_HandMadeCtrl As Boolean 'V4.34
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		pm_CQ = wk_Item
		'���o�͋敪
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'  Len ��p����B
		If Len(wk_Item) <> 4 Then
			'AE_MsgBox ��p����B
			AE_MsgBox("Obj ���Ɍ��(���o�͋敪��4�����łȂ�)�B", MsgBoxStyle.Exclamation, AE_Title)
			CP.InOutMode = 0
		Else
			wk_InOutMode = CInt(Mid(wk_Item, 1, 1)) * 64 + CInt(Mid(wk_Item, 2, 1)) * 16 + CInt(Mid(wk_Item, 3, 1)) * 4 + CInt(Mid(wk_Item, 4, 1)) 'InOutMode V4.29
			CP.InOutMode = wk_InOutMode * 256 + wk_InOutMode 'InOutMode V4.29
		End If
		'���t, ���l �Ȃǂ̌^ (FormatClass)
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(�\���`���̎w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		If LCase(Left(wk_Item, 4)) = "date" Or Left(wk_Item, 2) = "���t" Then
			CP.FormatClass = Cn_Date '���t�B
		ElseIf LCase(Left(wk_Item, 4)) = "time" Or Left(wk_Item, 2) = "����" Then  'V6.45
			CP.FormatClass = Cn_Time 'V6.45
		ElseIf LCase(Left(wk_Item, 4)) = "numb" Or Left(wk_Item, 2) = "���l" Then 
			CP.FormatClass = Cn_Numb
		ElseIf LCase(Left(wk_Item, 4)) = "chnu" Or Left(wk_Item, 2) = "�����l" Then  'V6.50
			CP.FormatClass = Cn_Chnu 'V6.50
		ElseIf LCase(Left(wk_Item, 4)) = "snum" Or Left(wk_Item, 3) = "����" Then  'V6.45
			CP.FormatClass = Cn_Snum 'V6.45
		ElseIf LCase(Left(wk_Item, 4)) = "schn" Or Left(wk_Item, 3) = "������" Then  'V6.50
			CP.FormatClass = Cn_Schn 'V6.50
		ElseIf LCase(Left(wk_Item, 4)) = "code" Or Left(wk_Item, 3) = "�R�[�h" Then 
			CP.FormatClass = Cn_Code
		ElseIf LCase(Left(wk_Item, 4)) = "memo" Or Left(wk_Item, 2) = "����" Then 
			CP.FormatClass = Cn_Memo
		ElseIf LCase(Left(wk_Item, 4)) = "name" Or Left(wk_Item, 2) = "����" Then 
			CP.FormatClass = Cn_Name
		Else
			CP.FormatClass = Cn_NonC
		End If
		'���ڂ̒��� (MaxLength)
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(�\���̒����̎w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		CP.MaxLength = CShort(wk_Item)
		'���ڂ̌���
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(�����̎w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		'�����G���^�[�̎w��(Auto Enter)
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(�����G���^�[�̎w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		'  Len ��p����B          AE_MsgBox ��p����B
		If Len(wk_Item) > 1 Then AE_MsgBox("Obj ���Ɍ��(�����G���^�[�̎w�肪1�����łȂ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		If wk_Item = "-" Or wk_Item = "0" Or wk_Item = "M" Then
			'CP.AutoEnter = CP.AutoEnter And &HFFFE 'V6.45
			'CP.AutoEnter = Cn_Enabled '16 Or 0 'V6.47E
			CP.AutoEnter = 0 'V6.47X
		ElseIf wk_Item = "1" Or wk_Item = "A" Then 
			'CP.AutoEnter = CP.AutoEnter Or 1 'V6.45
			'CP.AutoEnter = Cn_Enabled + Cn_AutoEnter '16 Or 1 'V6.47E
			CP.AutoEnter = Cn_AutoEnter '1 'V6.47X
		End If
		'�������A�E�����̎w��(Alignment)
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(�������A�E�����̎w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		'  Len ��p����B          AE_MsgBox ��p����B
		If Len(wk_Item) > 1 Then AE_MsgBox("Obj ���Ɍ��(�������A�E�����̎w�肪1�����łȂ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		Select Case wk_Item 'V6.45
			Case "-", "0", "L", "M", "C", "N" 'MANDALA �� Alignment �w��B'V6.45
				CP.Alignment = 0 '���l�߁B
			Case "1", "R", "Q" 'MANDALA �� Alignment �w��B'V6.45
				CP.Alignment = 1 '�E�l�߁B
		End Select
		'�Œ�t�H�[�}�b�g�̎w��(Fixed Format)
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(�Œ�t�H�[�}�b�g�̎w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		'  Len ��p����B         AE_MsgBox ��p����B
		If Len(wk_Item) > 1 Then AE_MsgBox("Obj ���Ɍ��(�Œ�t�H�[�}�b�g�̎w�肪1�����łȂ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		If wk_Item = "-" Or wk_Item = "0" Or wk_Item = "N" Then
			CP.FixedFormat = 0
		ElseIf wk_Item = "1" Or wk_Item = "Y" Then 
			CP.FixedFormat = 1
		End If
		'��{�t�H�[�}�b�g�̎w��(Key In OK Character Set)
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(��{�t�H�[�}�b�g�̎w�肪�w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		'  Len ��p����B          AE_MsgBox ��p����B
		If Len(wk_Item) > 1 Then AE_MsgBox("Obj ���Ɍ��(��{�t�H�[�}�b�g�̎w�肪1�����łȂ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		'    If wk_Item$ = "-" Then 'V4.17 �ō폜
		'        CP.KeyInOkClass = Asc("0") 'V4.17 �ō폜
		'    Else 'V4.17 �ō폜
		CP.KeyInOkClass = Asc(wk_Item)
		'    End If 'V4.17 �ō폜
		'�t�H�[�}�b�g�̎w��(Format Characters)
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(�t�H�[�}�b�g�̎w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		If wk_Item = "-" Then
			CP.FormatChr = ""
		Else
			CP.FormatChr = wk_Item
		End If
		'Tab �ԍ��̎w��(SSTab Tab) 'V4.21
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf) 'V4.21
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(Tab �ԍ��̎w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		If wk_Item = "-" Then
			CP.TabTab = -1
		Else
			CP.TabTab = CShort(wk_Item)
		End If
		'
		'�u���b�N�ԍ��̎w��(Block No) 'V5.40
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf) 'V5.40
		'AE_MsgBox ��p����B
		If wk_Item = "" Then AE_MsgBox("Obj ���Ɍ��(�u���b�N�ԍ��̎w�肪����Ȃ�)�B", MsgBoxStyle.Exclamation, AE_Title) 'V5.40
		'  Len ��p����B          AE_MsgBox ��p����B
		If Len(wk_Item) > 1 Then AE_MsgBox("Obj ���Ɍ��(�u���b�N�ԍ��̎w�肪1�����łȂ�)�B", MsgBoxStyle.Exclamation, AE_Title) 'V5.40
		'CP.BlockNo = CInt(wk_Item$) 'V5.40
		CP.BlockNo = InStr("123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ", wk_Item) 'V6.45
		'
		'CP.NZero = InStr("123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ", wk_Item$) 'V6.45
		'
		'������ PSI ����ǉ������ꍇ�ɂ́A���̏�ɂ��ǉ����K�v�B
		'
		'�I�u�W�F�N�g�ȗ��^�C�v�̎w��(Object Type Abbr)
		Call AE_SmrGetPrm(wk_Item, pm_SmrBuf)
		'  Len ��p����B          AE_MsgBox ��p����B
		If Len(wk_Item) > 1 Then AE_MsgBox("Obj ���Ɍ��(�I�u�W�F�N�g�^�C�v�̎w�肪1�����łȂ�)�B", MsgBoxStyle.Exclamation, AE_Title)
		If wk_Item = "o" Then '�������� "o" = Chr$(Cn_HandMadeC) �́AHand Made Control�B'V4.34
			wk_HandMadeCtrl = True 'V4.34
			CP.TypeA = Cn_OutputOnly 'V4.34
		ElseIf wk_Item <> "" Then 
			wk_HandMadeCtrl = False 'V4.34
			CP.TypeA = Asc(wk_Item) 'V4.16 "R"(Cn_OptionButtonH) �� "r"(Cn_OptionButtonC) ����ʂ��邽�߁B
		Else
			wk_HandMadeCtrl = False 'V4.34
			CP.TypeA = Cn_NormalOrV
		End If
		'
		'CInSw �̐ݒ�
		CP.CIn = Cn_NoInput '0: No Input
		'
		'Status ��ݒ肷�邱�ƂŁAExStatus �̏����ݒ���s���BInitVal �Ŕg�y�B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Px �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CP.CpPx = pm_Px
		If wk_HandMadeCtrl Then 'V4.34
			CP.StatusC = Cn_Status8 'Space$(1)
			CP.StatusF = Cn_Status8 'Space$(1)
		Else
			CP.StatusC = Cn_Status0 'Space$(1)
			CP.StatusF = Cn_Status0 'Space$(1)
		End If
		CP.ExStatus = Cn_Status0 'Space$(1)
		'
		'CP.ErrorFlg = False 'Error Flag 'V4.24
		CP.CheckRtnCode = 0 'Error Flag 'V6.54
		'
		CP.LineCount = 1 'V4.24
	End Sub
	
	'�w��̃R���g���[���Ƀt�H�[�J�X���ړ�����B
	Public Function AE_SetFocus(ByRef PP As clsPP, ByVal pm_Tx As Short) As Short
		If pm_Tx < 0 Or pm_Tx >= PP.ControlsC Then '��ʃR���g���[��
			AE_SetFocus = 1
		ElseIf PP.Mode = Cn_Mode3 Then 
			AE_SetFocus = 0
		ElseIf AE_Controls(PP.CtB + pm_Tx).TabStop And AE_Controls(PP.CtB + pm_Tx).Enabled And AE_Controls(PP.CtB + pm_Tx).Visible Then 
			If pm_Tx = PP.Tx Then
				PP.CursorToWhere = pm_Tx
				If AE_CursorRest(PP.ScX).Visible And AE_CursorRest(PP.ScX).Enabled Then
					AE_CursorRest(PP.ScX).TabStop = True
					PP.NextTx = Cn_NextTxCleared
					On Error Resume Next 'V4.32
					AE_CursorRest(PP.ScX).Focus()
					PP.CursorSet = True
				End If
			Else 'If pm_Tx <> PP.Tx Then
				AE_CursorRest(PP.ScX).TabStop = False
				PP.NextTx = pm_Tx
				On Error Resume Next 'V4.32
				AE_Controls(PP.CtB + pm_Tx).Focus()
				PP.CursorSet = True
			End If
			AE_SetFocus = -1
		Else
			AE_SetFocus = 0
		End If
	End Function
	
	Sub AE_SetInitValStatus(ByRef PP As clsPP, ByRef CP As clsCP) 'V6.56S
		PP.InitValStatus = Cn_ModeDataChanged
		CP.Modified = Cn_ModeDataChanged
	End Sub
	
	'MouseUp �̍ۂ� SelStart �� SelLength ���Z�b�g����B
	Public Sub AE_SetSel(ByRef PP As clsPP, ByRef CP As clsCP, ByRef Ct As Object)
		Static wk_Ln As Integer
		Static wk_MaxLB As Integer
		Static wk_P As Integer
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_Ln = LenWid(Ct) 'Len �ł͂��߁B
		wk_MaxLB = CP.MaxLength 'Field Length
		Select Case CP.TypeA
			'Case Cn_NormalOrV, Cn_OutputOnly
			Case Cn_NormalOrV 'V4.31
				If PP.SelValid And PP.Override = 1 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Ct.SelStart = 0
				ElseIf CP.Alignment <> 1 Then  '���l��
					'Ct.SelStart = 0
					If Cn_ai21 Then 'V6.45
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If PP.ClickPosition >= Len(LeftWid(Ct, CP.MaxLength)) Then PP.ClickPosition = Len(LeftWid(Ct, CP.MaxLength)) - 1 'V6.45
						If PP.ClickPosition < 0 Then PP.ClickPosition = 0 'V5.46
						Do While PP.ClickPosition > 0 'V6.45
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If AE_KeyInOkChar(PP, Mid(Ct, PP.ClickPosition + 1, 1), CP.KeyInOkClass) Then
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If Not (AE_Numerical(CP.FormatClass)) Or Mid(Ct, PP.ClickPosition + 1, 1) <> Space(1) Then Exit Do '----------'V6.50
							End If
							PP.ClickPosition = PP.ClickPosition - 1 'V6.45
						Loop  'V6.45
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Ct.SelStart = PP.ClickPosition 'V6.45
						PP.ClickPosition = -1 'V6.46
					Else 'V6.45
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Ct.SelStart = 0
					End If 'V6.45
				Else 'If CP.Alignment = 1 Then '�E�l��
					'If wk_Ln > 0 Then Ct.SelStart = Len((Ct)) - PP.Override
					If wk_Ln > 0 Then
						'If AE_Numerical(CP.FormatClass) And CP.Alignment = 1 And PP.SpecSubID = "sdy" Then 'V6.46 'V6.50
						'   Ct.SelStart = 0
						'ElseIf Cn_ai21 Then 'V6.45
						If Cn_ai21 Then 'V6.45
							If PP.ClickPosition = -1 Then 'And CP.Alignment = 1 Then 'V5.46
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Ct.SelStart = Len(LeftWid(Ct, CP.MaxLength)) - PP.Override 'V6.46
							Else 'V5.46
								'If PP.ClickPosition = -1 Then PP.ClickPosition = 0 'V5.46
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Do While PP.ClickPosition < Len(LeftWid(Ct, CP.MaxLength)) 'V6.45
									'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If AE_KeyInOkChar(PP, Mid(Ct, PP.ClickPosition + 1, 1), CP.KeyInOkClass) Then
										'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If Not (AE_Numerical(CP.FormatClass)) Or Mid(Ct, PP.ClickPosition + 1, 1) <> Space(1) Then Exit Do '----------'V6.50
									End If
									PP.ClickPosition = PP.ClickPosition + 1 'V6.45
								Loop  'V6.45
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If PP.ClickPosition >= Len(LeftWid(Ct, CP.MaxLength)) Then PP.ClickPosition = Len(LeftWid(Ct, CP.MaxLength)) - 1 'V6.45
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Ct.SelStart = PP.ClickPosition 'V6.45
								'PP.ClickPosition = -1 'V6.46
							End If
						ElseIf PP.SetCursorRR = False Then  'V6.45
							wk_P = 0
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Do While wk_P < Len(LeftWid(Ct, CP.MaxLength)) 'V6.45
								'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If AE_KeyInOkChar(PP, Mid(Ct, wk_P + 1, 1), CP.KeyInOkClass) Then Exit Do '----------
								wk_P = wk_P + 1 'V6.45
							Loop  'V6.45
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If wk_P >= Len(LeftWid(Ct, CP.MaxLength)) Then wk_P = Len(LeftWid(Ct, CP.MaxLength)) - 1 'V6.45
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Ct.SelStart = wk_P 'V6.45
						Else 'V6.45
							'If wk_Ln > 0 Then Ct.SelStart = Len(LeftWid$((Ct), CP.MaxLength)) - PP.Override 'V6.45
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Ct.SelStart = Len(LeftWid(Ct, CP.MaxLength)) - PP.Override 'V6.46
						End If 'V6.45
					End If
				End If
				'
				If CP.TypeA = Cn_NormalOrV Then
					If (PP.SelValid Or (PP.SetCursorLF And CP.Alignment <> 1)) And CP.FixedFormat <> 1 Then 'V6.56F
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Ct.SelLength = Len(Ct)
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Ct.SelLength = PP.Override
					End If
				End If
				'Case Else 'Cn_InputOnly, Cn_OptionButtonH, Cn_OptionButtonC, Cn_CheckBox, Cn_ListBox, Cn_OutputOnly
		End Select
	End Sub
	
	'�J�[�\���̈ړ���ڗ����Ȃ����邽�߂ɁA���� AE_SetSelLen �ŏ����B
	Public Sub AE_SetSelLen(ByRef PP As clsPP, ByRef CP As clsCP, ByRef Ct As Object, Optional ByVal pm_NeglectSetCursorLF As Object = Nothing)
		If CP.TypeA = Cn_NormalOrV Then
			'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_NeglectSetCursorLF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If IsNothing(pm_NeglectSetCursorLF) Then pm_NeglectSetCursorLF = False 'V6.57
			'If (PP.SelValid Or (Not pm_NeglectSetCursorLF And PP.SetCursorLF And CP.Alignment <> 1)) And CP.FixedFormat <> 1 Then 'V6.56F, 'V6.57
			If Not pm_NeglectSetCursorLF And (PP.SelValid Or (PP.SetCursorLF And CP.Alignment <> 1)) And CP.FixedFormat <> 1 Then 'V6.56F, 'V6.57
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ct.SelLength = Len(Ct)
			ElseIf AE_Numerical(CP.FormatClass) And CP.Alignment = 1 And PP.SpecSubID = "sdy" Then  'V6.50
				'Ct.SelLength = Len((Ct)) - Ct.SelStart
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ct.SelLength = Len(Ct)
			ElseIf CP.KeyInOkClass = Asc("1") Then  'V4.18
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ct.SelLength = Len(Ct) 'V4.18
			ElseIf CP.KeyInOkClass = Asc("2") Then  'V4.18
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ct.SelLength = Len(Ct) 'V4.18
			ElseIf CP.KeyInOkClass = Asc("3") Then  'V4.18
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ct.SelLength = Len(Ct) 'V4.18
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ct.SelLength = PP.Override
			End If
		End If
	End Sub
	
	Private Sub AE_SmrGetPrm(ByRef pm_Item As String, ByRef pm_SmrBuf As String)
		Dim wk_Pos As Short
		Dim wk_Ln As Integer
		wk_Pos = InStr(pm_SmrBuf, Space(1))
		If wk_Pos = 0 Then
			pm_Item = ""
		ElseIf wk_Pos >= 2 Then 
			pm_Item = Left(pm_SmrBuf, wk_Pos - 1)
			wk_Ln = Len(pm_SmrBuf)
			If wk_Ln > wk_Pos Then
				pm_SmrBuf = LTrim(Right(pm_SmrBuf, wk_Ln - wk_Pos))
			ElseIf wk_Ln = wk_Pos Then 
				pm_SmrBuf = ""
			Else
				Call AE_SystemError("SmrGetPrm ��", 180)
			End If
		Else
			Call AE_SystemError("SmrGetPrm ��", 181)
		End If
	End Sub
	
	'Status Bar �̃��b�Z�[�W���N���A����B�������A�w��̕����F�̏ꍇ�Ɍ���N���A�B
	Public Sub AE_StatusClear(ByRef PP As clsPP, ByVal pm_ForeColor As Integer)
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP.ScX).ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_ForeColor < 0 Or AE_StatusBar(PP.ScX).ForeColor = pm_ForeColor Then
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_StatusCodeBar(PP.ScX) = "" 'V4.24
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_StatusBar(PP.ScX) = ""
		End If
	End Sub
	
	'Status Bar �̃��b�Z�[�W�������I�ɃN���A����B
	Public Sub AE_StatusClearForce(ByRef PP As clsPP)
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_StatusCodeBar(PP.ScX) = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_StatusBar(PP.ScX) = ""
	End Sub
	
	'Status Bar �Ƀ��b�Z�[�W���o�͂���B
	Public Sub AE_StatusOut(ByRef PP As clsPP, ByVal Pm_Msg As String, ByVal pm_ForeColor As Integer, Optional ByVal pm_Code As Object = Nothing)
		AE_StatusCodeBar(PP.ScX).ForeColor = System.Drawing.ColorTranslator.FromOle(pm_ForeColor) 'V4.24
		AE_StatusBar(PP.ScX).ForeColor = System.Drawing.ColorTranslator.FromOle(pm_ForeColor)
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(pm_Code) And Not PP.SuppressCodeClear Then 'V4.34
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_StatusCodeBar(PP.ScX) = "" 'V4.34
			'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		ElseIf Not IsNothing(pm_Code) Then  'V4.34
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Code �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_StatusCodeBar(PP.ScX) = pm_Code 'V4.24
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_StatusBar(PP.ScX) = Space(1) & Pm_Msg
	End Sub
	
	'�V�X�e���G���[���b�Z�[�W��\������B'V4.33
	Public Sub AE_SystemError(ByVal Pm_Msg As String, ByVal pm_ErrorId As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_MsgBox(Pm_Msg$ & �G���[������܂� (System Error & CStr(pm_ErrorId) & )�B���A�������肢�������܂��B, vbExclamation, AE_Title$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If AE_MsgBox(Pm_Msg & "�G���[������܂� (System Error" & CStr(pm_ErrorId) & ")�B���A�������肢�������܂��B", MsgBoxStyle.Exclamation, AE_Title) Then Call AE_Stop()
	End Sub
	
	Public Function AE_Tpstr(ByVal pm_Txt As String, ByVal pm_TypeA As Short) As String 'V4.35
		If pm_TypeA = Cn_CheckBox Then
			If Trim(pm_Txt) = "1" Then
				AE_Tpstr = "1"
			Else
				AE_Tpstr = "0"
			End If
		Else
			AE_Tpstr = pm_Txt
		End If
	End Function
	
	Public Function AE_TrimS(ByVal pm_Str As String) As String 'V5.42
		Dim st_Work As String
		Dim wk_Chr As String
		Dim Pos As Short
		Dim Ln As Short
		st_Work = ""
		Ln = Len(pm_Str)
		Pos = 1
		Do While Pos <= Ln
			wk_Chr = Mid(pm_Str, Pos, 1)
			Select Case wk_Chr
				Case "/", "-", ".", ":" 'V6.45
				Case Else
					st_Work = st_Work & wk_Chr
			End Select
			Pos = Pos + 1
		Loop 
		AE_TrimS = st_Work
	End Function
	
	'Px �� Tx �ɕϊ�����B
	Public Function AE_Tx(ByRef PP As clsPP, ByVal pm_Px As Short) As Short
		Static wk_ww As Short
		Static wk_De As Short
		AE_Tx = -1
		If pm_Px < PP.BodyPx Then
			If pm_Px < PP.BodyTx Then AE_Tx = pm_Px
		ElseIf pm_Px < PP.EBodyPx Then 
			wk_ww = pm_Px - PP.BodyPx
			If wk_ww Mod PP.BodyV < PP.BodyN Then
				wk_De = wk_ww \ PP.BodyV - PP.TopDe
				If wk_De >= 0 And wk_De <= PP.MaxDsp Then AE_Tx = PP.BodyTx + wk_ww Mod PP.BodyV + wk_De * PP.BodyN
			End If
		ElseIf pm_Px < PP.TailPx Then 
			wk_ww = pm_Px - PP.EBodyPx
			If wk_ww Mod PP.EBodyV < PP.EBodyN Then
				wk_De = wk_ww \ PP.EBodyV - PP.TopEDe
				If wk_De >= 0 And wk_De <= PP.MaxEDsp Then AE_Tx = PP.EBodyTx + wk_ww Mod PP.EBodyV + wk_De * PP.EBodyN
			End If
		Else 'If pm_Px >= PP.TailPx Then
			wk_ww = pm_Px - PP.TailPx + PP.TailTx
			If wk_ww < PP.ControlsC Then AE_Tx = wk_ww
		End If
	End Function
	
	Public Function AE_Val(ByRef CP As clsCP, ByVal pm_Txt As String, ByRef pm_FractionC As Short) As Object
		'Non Static Sub �iAE_Change ����ďo����邽�߁j
		Dim wk_Moji As String
		Dim wk_TrimTxt As String
		Dim wk_Presentation As String
		Dim wk_Fraction As Short
		Dim wk_ValidValue As Boolean
		Dim Wx As Short
		Dim wk_Ln As Integer
		wk_TrimTxt = Trim(pm_Txt)
		'
		If CP.FormatClass = Cn_Date Then '���t�B
			pm_FractionC = 0 'V4.32
			If wk_TrimTxt = "" Then
				'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_Val = System.DBNull.Value : Exit Function
			End If '--------------------
			If Cn_ai21 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_Val = pm_Txt : Exit Function
			End If '--------------------'V5.42
			'If InStr(pm_Txt$, Space$(1)) And Not AE_SSSWin Then AE_Val = pm_Txt$: Exit Function '--------------------'V4.34
			'If InStr(wk_TrimTxt$, Space$(1)) And Not AE_SSSWin Then AE_Val = pm_Txt$: Exit Function '--------------------'V4.38
			If InStr(wk_TrimTxt, Space(1)) > 0 And Not AE_SSSWin Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_Val = pm_Txt : Exit Function
			End If '--------------------'V7.00
			'���l�ߓ��t�B
			If CP.Alignment <> 1 And Left(pm_Txt, 1) = Space(1) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_Val = pm_Txt : Exit Function
			End If '--------------------'V5.42
			Do 
				If Len(wk_TrimTxt) = 8 Then
					For Wx = 1 To 8 'V4.11
						wk_Moji = Mid(wk_TrimTxt, Wx, 1) 'V4.11
						If wk_Moji < "0" Or wk_Moji > "9" Then Exit Do '---------- 'V4.11
					Next Wx 'V4.11
					'��؂��Ă��Ȃ��ꍇ�A��؂蕶����t����B
					wk_TrimTxt = Left(wk_TrimTxt, 4) & "/" & Mid(wk_TrimTxt, 5, 2) & "/" & Right(wk_TrimTxt, 2) 'V4.24
					'V4.37 (YYYYMM)
					'ElseIf Len(wk_TrimTxt$) = 6 Then 'V4.37 (YYYYMM)
					'ElseIf Len(wk_TrimTxt$) = 6 And AE_SSSWin Then 'V4.37 (YYYYMM)
				ElseIf Len(wk_TrimTxt) = 6 And UCase(Right(CP.FormatChr, 2)) = "MM" And AE_SSSWin Then  'V4.38 (YYYYMM)
					For Wx = 1 To 6
						wk_Moji = Mid(wk_TrimTxt, Wx, 1)
						If wk_Moji < "0" Or wk_Moji > "9" Then Exit Do '----------
					Next Wx
					'��؂��Ă��Ȃ��ꍇ�A��؂蕶����t����B
					wk_TrimTxt = Left(wk_TrimTxt, 4) & "/" & Mid(wk_TrimTxt, 5, 2)
				ElseIf Len(wk_TrimTxt) = 9 Then  'V4.14
					' "." �ŋ�؂��Ă���ꍇ�ɂ͓��t�Ƃ݂Ȃ���Ȃ��̂ŁA���̕␳������B
					wk_TrimTxt = Left(wk_TrimTxt, 3) & "/" & Mid(wk_TrimTxt, 5, 2) & "/" & Right(wk_TrimTxt, 2) 'V4.24
				End If
			Loop Until True 'No Loop
			If IsDate(wk_TrimTxt) Then 'V4.32
				'V4.37 (YYYYMM)
				If UCase(Right(CP.FormatChr, 2)) = "MM" And Right(wk_TrimTxt, 2) = Right(VB6.Format(wk_TrimTxt, "YYYY/MM"), 2) And AE_SSSWin Then 'V4.37 (YYYYMM)
					AE_Val = RTrim(wk_TrimTxt) 'Trim$ �ł̓_���B
				ElseIf UCase(Right(CP.FormatChr, 2)) = "DD" And Right(wk_TrimTxt, 2) = Right(VB6.Format(wk_TrimTxt, "YYYY/MM/DD"), 2) Then  'V4.11
					'Dim wk_FormatDate As Variant
					'wk_FormatDate = CVDate(wk_TrimTxt$)
					'If wk_FormatDate < CDate("1000/01/01") Then 'V4.22
					'    AE_Val = "0" & CStr(wk_FormatDate) 'V4.22
					'Else 'V4.22
					'    AE_Val = CStr(wk_FormatDate) 'V4.22
					'End If 'V4.22
					AE_Val = RTrim(wk_TrimTxt) 'Trim$ �ł̓_���B
				Else
					AE_Val = RTrim(pm_Txt) 'Trim$ �ł̓_���B
				End If
			Else
				AE_Val = RTrim(pm_Txt) 'Trim$ �ł̓_���B
			End If
		ElseIf CP.FormatClass = Cn_Time Then  '�����B
			'If Cn_ai21 Then AE_Val = pm_Txt$: Exit Function '--------------------'V6.45
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_Val = pm_Txt : Exit Function '--------------------'V6.45
		ElseIf AE_Numerical(CP.FormatClass) Then  '���l�n�B'V6.50
			If wk_TrimTxt = "" Then
				'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_Val = System.DBNull.Value : pm_FractionC = 0 : Exit Function
			End If '--------------------
			wk_ValidValue = False
			wk_Fraction = 0 '���̃[���ȊO�̐����B
			wk_Presentation = ""
			wk_Ln = Len(wk_TrimTxt)
			For Wx = 1 To wk_Ln
				wk_Moji = Mid(wk_TrimTxt, Wx, 1)
				If wk_Moji >= "1" And wk_Moji <= "9" Then
					If wk_Fraction > 0 Then wk_Fraction = wk_Fraction + 1 '���܂��͕��̏����B
					If wk_Fraction <= -1000 Then wk_Fraction = 0 '���̃[���ȊO�̐����B
					If wk_Fraction < 0 Then wk_Fraction = -wk_Fraction + 1 '���܂��͕��̏����B
					wk_Presentation = wk_Presentation & wk_Moji
					wk_ValidValue = True
				ElseIf wk_Moji = "0" Then 
					If wk_Fraction > 0 Then
						wk_Fraction = wk_Fraction + 1 '���܂��͕��̏����B
						wk_Presentation = wk_Presentation & wk_Moji
					ElseIf wk_Fraction <= -1000 Then 
						wk_Fraction = -1001 '���̃[���B
						wk_Presentation = "-0"
					ElseIf wk_Fraction < 0 Then 
						wk_Fraction = wk_Fraction - 1 '���̃[���̏����B
						wk_Presentation = wk_Presentation & wk_Moji
					Else
						wk_Presentation = wk_Presentation & wk_Moji
					End If
					wk_ValidValue = True
				ElseIf wk_Moji = "." Then 
					If wk_Fraction = 0 Then
						wk_Fraction = 1 '�ŏI�̕����� . �̐��̐��B
						wk_Presentation = wk_Presentation & wk_Moji
					ElseIf wk_Fraction <= -1000 Then 
						wk_Fraction = -1 '�ŏI�̕����� . �̃[���B
						wk_Presentation = "-0."
					Else
						Beep()
					End If
				ElseIf wk_Moji = "+" Or wk_Moji = "-" Then 
					If Wx = 1 Then
						'If wk_Presentation$ = "" Then
						wk_Presentation = wk_Moji
						If wk_Moji = "-" Then wk_Fraction = -1000 '���̃[���B
					Else
						Beep()
					End If
				ElseIf wk_Moji = "\" Or wk_Moji = "," Then 
				Else
					'Beep
					If wk_Moji <> Space(1) Then Beep() 'V6.48
				End If
			Next Wx
			pm_FractionC = wk_Fraction
			'
			If CP.FormatClass = Cn_Numb Or CP.FormatClass = Cn_Snum Then '���l�A����
				If wk_ValidValue Then
					'�ʉ݌^�́A��Βl�� 99999999999999.9999 �ȏ�̒l��ۏ؂ł��܂���B
					Wx = 0 : If Left(wk_Presentation, 1) = "-" Then Wx = 1
					If InStr(wk_Presentation, ".") > 0 Then
						If InStr(wk_Presentation, ".") > 15 + Wx Then
							Beep()
							wk_Presentation = Left(wk_Presentation, 14 + Wx)
						Else
							If Len(Mid(wk_Presentation, InStr(wk_Presentation, ".") + 1)) > 4 Then
								Beep()
								wk_Presentation = Left(wk_Presentation, InStr(wk_Presentation, ".") + 4)
							End If
						End If
					ElseIf Len(wk_Presentation) >= 15 + Wx Then 
						Beep()
						wk_Presentation = Left(wk_Presentation, 14 + Wx)
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Val = CDec(wk_Presentation)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Val = 0@
				End If
			Else '�����l�A������
				If wk_ValidValue Then 'V6.50
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Val = wk_Presentation 'V6.50
				Else 'V6.50
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Val = "0" 'V6.50
				End If 'V6.50
			End If
			'
		Else '���t�A���l�ȊO�B
			wk_Presentation = RTrim(pm_Txt) 'Trim$ �ł̓_���B
			If wk_Presentation = "" Then
				If CP.KeyInOkClass = Asc("M") Then
					'
					Wx = 0
					Do While Mid(pm_Txt, Wx + 1, 1) = "�@" '�Q�o�C�g�����̃X�y�[�X�B
						Wx = Wx + 1
					Loop 
					If Wx = 0 Then
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						AE_Val = System.DBNull.Value
					Else
						AE_Val = Left(pm_Txt, Wx)
					End If
				Else
					'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Val = System.DBNull.Value
				End If
				pm_FractionC = 0 'V4.10
			ElseIf AE_SSSWin Then  'V4.10
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_Val = pm_Txt 'V4.10
				pm_FractionC = 0 'V4.10
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				AE_Val = wk_Presentation
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(wk_Presentation$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_FractionC = LenWid(pm_Txt) - LenWid(wk_Presentation)
			End If
		End If
	End Function
	
	Public Function AE_Val2(ByRef CP As clsCP) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_Val2 = AE_Val(CP, CP.TpStr, CP.FractionC)
	End Function
	
	Public Function AE_Val3(ByRef CP As clsCP, ByVal pm_Txt As String) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_Val3 = AE_Val(CP, pm_Txt, CP.FractionC)
	End Function
	
	Public Function AE_Val4(ByRef CP As clsCP) As Object
		Dim wk_FractionC As Short
		wk_FractionC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_Val4 = AE_Val(CP, CP.TpStr, wk_FractionC)
	End Function
	
	Public Function AE_Val5(ByRef CP As clsCP, ByVal pm_Txt As String) As Object
		Dim wk_FractionC As Short
		wk_FractionC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AE_Val5 = AE_Val(CP, pm_Txt, wk_FractionC)
	End Function
	
	Function AE_ValX(ByVal pm_Value As Object) As Object 'V6.50
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(pm_Value) Then
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_ValX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_ValX = System.DBNull.Value
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_ValX = Val(pm_Value)
		End If
	End Function
	
	Sub AE_WindowProcReset(ByRef PP As clsPP)
		If Cn_DebugMode Then Exit Sub
		Dim wk_Tx As Short
		For wk_Tx = 0 To PP.ControlsC - 1
			wk_Lng = SetWindowLong(AE_Controls(PP.CtB + wk_Tx).Handle.ToInt32, GWL_WNDPROC, PP.lpPrevWndProc)
		Next wk_Tx
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf AE_StatusBar(PP.ScX) Is System.Windows.Forms.TextBox Then
			wk_Lng = SetWindowLong(AE_StatusBar(PP.ScX).Handle.ToInt32, GWL_WNDPROC, PP.lpPrevWndProc)
		End If
		wk_Lng = SetWindowLong(AE_ModeBar(PP.ScX).Handle.ToInt32, GWL_WNDPROC, PP.lpPrevWndProc)
	End Sub
	
	Public Function LeftWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LeftB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		LeftWid = StrConv(LeftB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
	End Function
	
	Public Function LenWid(ByVal pm_Characters As Object) As Object
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(pm_Characters) Then
			Call AE_SystemError("LenWid �̃p�����^��", 190)
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			LenWid = System.DBNull.Value
			Exit Function '--------------------
		End If
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Characters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		LenWid = LenB(StrConv(pm_Characters, vbFromUnicode))
	End Function
	
	Public Function MidWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer, Optional ByVal pm_LnWid As Object = Nothing) As String
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(pm_LnWid) Then
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			MidWid = StrConv(MidB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
		Else
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			MidWid = StrConv(MidB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid, pm_LnWid), vbUnicode)
		End If
	End Function
	
	Public Function RightWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: RightB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		RightWid = StrConv(RightB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
	End Function
	
	Public Function FormatAndRound(ByVal pm_Value As Object, ByVal pm_FormatChr As String) As String 'V6.59
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(pm_Value) Then
			FormatAndRound = ""
			Exit Function '----------
		End If
		Dim sg_Value As String
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		sg_Value = CStr(pm_Value)
		'
		Dim M As Integer
		Dim Ln As Integer
		Dim N As Integer
		Dim I As Integer
		Dim OneChr As String '�����_��艺�̌� '�擪�̃t�H�[�}�b�g�������ڂ̕�����
		Do 
			M = InStr(sg_Value, ".")
			If M > 0 Then M = Len(sg_Value) - M
			'
			Ln = InStr(pm_FormatChr, ";") - 1
			If Ln < 0 Then Ln = Len(pm_FormatChr)
			'
			N = InStr(pm_FormatChr, ".")
			If N > 0 Then N = Ln - N
			'
			If N >= 0 And N + 1 = M And Right(sg_Value, 1) = "5" Then
				For I = 1 To Ln
					OneChr = Mid(pm_FormatChr, I, 1)
					Select Case OneChr
						Case "#", ",", ".", "\", "+", "-"
						Case Else
							If OneChr >= "0" And OneChr <= "9" Then
							Else
								Exit Do '-----
							End If
					End Select
				Next I
				FormatAndRound = VB6.Format(sg_Value & "1", pm_FormatChr) 'V6.59
				Exit Function '----------
			Else
				Exit Do '-----
			End If
		Loop 
		'
		FormatAndRound = VB6.Format(sg_Value, pm_FormatChr) 'V6.59
	End Function 'V6.59
	
	' === 20081205 === INSERT S - ACE)Masaki �u'�v�Ή�
	Public Function AE_EditSQLText(ByVal pin_strSQLText As String) As String
		
		AE_EditSQLText = ""
		
		pin_strSQLText = Replace(pin_strSQLText, "'", "''")
		
		AE_EditSQLText = pin_strSQLText
		
	End Function
	' === 20081205 === INSERT E
End Module