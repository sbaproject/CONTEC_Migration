Option Strict Off
Option Explicit On
Module SOUZP_F51
	'
	'�X���b�g��      :�X�֔ԍ��E��ʍ��ڃX���b�g
	'���j�b�g��      :SOUZP.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/06/05
	'�g�p�v���O����  :SOUMT51
	'
	
	Function SOUZP_CheckC(ByVal SOUZP As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUZP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SOUZP_CheckC = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUZP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(SOUZP)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(SOUZP)) = 0 Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUZP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Len(Trim(SOUZP)) <> Len508 Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "SOUMT51", 0) '�X�֔ԍ������G���[
				'UPGRADE_WARNING: �I�u�W�F�N�g SOUZP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SOUZP_CheckC = -1
				Exit Function
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUZP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Mid(SOUZP, Len509, 1) <> "-" Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "SOUMT51", 1) '�X�֔ԍ��n�C�t���ʒu�G���[
				'UPGRADE_WARNING: �I�u�W�F�N�g SOUZP_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SOUZP_CheckC = -1
				Exit Function
			End If
		End If
		
	End Function
End Module