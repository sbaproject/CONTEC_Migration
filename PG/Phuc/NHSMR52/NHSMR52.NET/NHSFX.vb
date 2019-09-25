Option Strict Off
Option Explicit On
Module NHSFX_F71
	'
	' �X���b�g��        : �d�b�ԍ��E��ʍ��ڃX���b�g
	' ���j�b�g��        : NHSFX.F81
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/22
	' �g�p�v���O������  : NHSMR51
	'
	' �X�V���t          :2006/11/09
	' �X�V���e          :�G���[�`�F�b�N�ǉ�
	
	Function NHSFX_CheckC(ByVal NHSFX As Object, ByVal FRNKB As Object) As Object
		
		Dim Rtn As Short
		Dim CntHP As Short
		Dim LenAll As Short
		Dim lngI As Integer
		Dim lngPOS As Integer
		
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSFX_CheckC = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		LenAll = Len(Trim(NHSFX))
		
		If LenAll = 0 Then
			Exit Function
		End If
		
		'�d�b�ԍ��n�C�t���擪�G���[
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Left(NHSFX, 1) = "-" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 0) '�n�C�t�����擪�ɂ���܂��B
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			NHSFX_CheckC = -1
			Exit Function
		End If
		
		'�d�b�ԍ��n�C�t�������G���[
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Right(Trim(NHSFX), 1) = "-" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 1) '�n�C�t���������ɂ���܂��B
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			NHSFX_CheckC = -1
			Exit Function
		End If
		
		'�d�b�ԍ��n�C�t���A�����̓G���[
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		For lngI = 1 To Len(Trim(NHSFX))
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Mid(Trim(NHSFX), lngI, 1) = "-" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Mid(Trim(NHSFX), lngI + 1, 1) = "-" Then
					Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 2) '�n�C�t���𕡐��A�����ē��͂��Ă��܂��B
					'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					NHSFX_CheckC = -1
					Exit Function
				End If
			End If
		Next 
		
		'�����̏ꍇ�̂݃`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g FRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If FRNKB = "0" Then
			
			'�������`�F�b�N
			If LenAll > Len506 Then
				Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 3) '�����I�[�o�[�ł��B
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				NHSFX_CheckC = -1
				Exit Function
			End If
			
			'�n�C�t�����`�F�b�N
			lngPOS = 0
			CntHP = 0
			For lngI = 1 To LenAll
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Mid(NHSFX, lngI, 1) = "-" Then
					CntHP = CntHP + 1
					If CntHP = Len507 Then
						lngPOS = lngI '2�ڂ̈ʒu��ޔ�
					End If
				End If
			Next 
			If CntHP <> Len507 Then
				Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 4) '�n�C�t�����̌��ł��B
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				NHSFX_CheckC = -1
				Exit Function
			End If
			
			'�d�b�ԍ������`�F�b�N
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Len(Mid(Trim(NHSFX), lngPOS + 1, Len(Trim(NHSFX)) - lngPOS)) <> Len511 Then
				Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 5) '���͂��s���ł��B
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				NHSFX_CheckC = -1
				Exit Function
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If IsNumeric(Mid(Trim(NHSFX), lngPOS + 1, Len(Trim(NHSFX)) - lngPOS)) = False Then
					Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 5) '���͂��s���ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g NHSFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					NHSFX_CheckC = -1
					Exit Function
				End If
			End If
			
		End If
		
	End Function
End Module