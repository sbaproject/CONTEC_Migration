Option Strict Off
Option Explicit On
Module BMNZP_F51
	'
	'�X���b�g��      :�X�֔ԍ��E��ʍ��ڃX���b�g
	'���j�b�g��      :BMNZP.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/30
	'�g�p�v���O����  :BMNMT51
	'
	
	Function BMNZP_CheckC(ByVal BMNZP As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g BMNZP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BMNZP_CheckC = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g BMNZP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(BMNZP)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(BMNZP)) = 0 Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNZP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Len(Trim(BMNZP)) <> Len508 Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "BMNMT51", 1) '�X�֔ԍ������G���[
				'UPGRADE_WARNING: �I�u�W�F�N�g BMNZP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				BMNZP_CheckC = -1
				Exit Function
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNZP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Mid(BMNZP, Len509, 1) <> "-" Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "BMNMT51", 2) '�X�֔ԍ��n�C�t���ʒu�G���[
				'UPGRADE_WARNING: �I�u�W�F�N�g BMNZP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				BMNZP_CheckC = -1
				Exit Function
			End If
		End If
		
	End Function
End Module