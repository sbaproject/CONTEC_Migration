Option Strict Off
Option Explicit On
Module NHSZP_F71
	'
	'�X���b�g��      :�X�֔ԍ��E��ʍ��ڃX���b�g
	'���j�b�g��      :NHSZP.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/09/22
	'�g�p�v���O����  :NHSMR51
	'
	
	Function NHSZP_CheckC(ByVal NHSZP As Object, ByVal FRNKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSZP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSZP_CheckC = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g FRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If FRNKB = "0" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSZP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(NHSZP)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LenWid(Trim(NHSZP)) = 0 Then
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSZP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Len(Trim(NHSZP)) <> Len508 Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "NHSMR52", 0) '�X�֔ԍ������G���[
					'UPGRADE_WARNING: �I�u�W�F�N�g NHSZP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					NHSZP_CheckC = -1
					Exit Function
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSZP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Mid(NHSZP, Len509, 1) <> "-" Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "NHSMR52", 1) '�X�֔ԍ��n�C�t���ʒu�G���[
					'UPGRADE_WARNING: �I�u�W�F�N�g NHSZP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					NHSZP_CheckC = -1
					Exit Function
				End If
			End If
		End If
		
	End Function
End Module