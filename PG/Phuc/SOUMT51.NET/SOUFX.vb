Option Strict Off
Option Explicit On
Module SOUFX_F51
	'
	'�X���b�g��      :FAX�ԍ��E��ʍ��ڃX���b�g
	'���j�b�g��      :SOUFX.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/28
	'�g�p�v���O����  :SOUMT51
	'
	'�X�V���t        :2006/11/09
	'�X�V���e        :�G���[�`�F�b�N�ǉ�
	
	Function SOUFX_CheckC(ByVal SOUFX As Object, ByVal De_Index As Object) As Object
		
		Dim Rtn As Short
		Dim CntHP As Short
		Dim LenAll As Short
		Dim lngI As Integer
		Dim lngPOS As Integer
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SOUFX_CheckC = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		LenAll = Len(Trim(SOUFX))
		
		If LenAll = 0 Then
			Exit Function
		End If
		
		'�d�b�ԍ��n�C�t���擪�G���[
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Left(SOUFX, 1) = "-" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 0) '�n�C�t�����擪�ɂ���܂��B
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SOUFX_CheckC = -1
			Exit Function
		End If
		
		'�d�b�ԍ��n�C�t�������G���[
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Right(Trim(SOUFX), 1) = "-" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 1) '�n�C�t���������ɂ���܂��B
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SOUFX_CheckC = -1
			Exit Function
		End If
		
		'�d�b�ԍ��n�C�t���A�����̓G���[
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		For lngI = 1 To Len(Trim(SOUFX))
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Mid(Trim(SOUFX), lngI, 1) = "-" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Mid(Trim(SOUFX), lngI + 1, 1) = "-" Then
					Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 2) '�n�C�t���𕡐��A�����ē��͂��Ă��܂��B
					'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					SOUFX_CheckC = -1
					Exit Function
				End If
			End If
		Next 
		
		'�������`�F�b�N
		If LenAll > Len506 Then
			Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 3) '�����I�[�o�[�ł��B
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SOUFX_CheckC = -1
			Exit Function
		End If
		
		'�n�C�t�����`�F�b�N
		lngPOS = 0
		CntHP = 0
		For lngI = 1 To LenAll
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Mid(SOUFX, lngI, 1) = "-" Then
				CntHP = CntHP + 1
				If CntHP = Len507 Then
					lngPOS = lngI '2�ڂ̈ʒu��ޔ�
				End If
			End If
		Next 
		If CntHP <> Len507 Then
			Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 4) '�n�C�t�����̌��ł��B
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SOUFX_CheckC = -1
			Exit Function
		End If
		
		'�d�b�ԍ������`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Len(Mid(Trim(SOUFX), lngPOS + 1, Len(Trim(SOUFX)) - lngPOS)) <> Len511 Then
			Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 5) '���͂��s���ł��B
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SOUFX_CheckC = -1
			Exit Function
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If IsNumeric(Mid(Trim(SOUFX), lngPOS + 1, Len(Trim(SOUFX)) - lngPOS)) = False Then
				Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 5) '���͂��s���ł��B
				'UPGRADE_WARNING: �I�u�W�F�N�g SOUFX_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SOUFX_CheckC = -1
				Exit Function
			End If
		End If
		
	End Function
End Module