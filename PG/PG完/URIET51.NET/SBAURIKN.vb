Option Strict Off
Option Explicit On
Module SBAURIKN_F54
	'
	' �X���b�g��        : �`�[���㍇�v���z�E��ʍ��ڃX���b�g
	' ���j�b�g��        : SBAURIKN.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/25
	' �g�p�v���O������  : URIET51
	'
	
	'����P�������㐔��
	Function SBAURIKN_CHECKC(ByVal SBAURIKN As Object, ByRef PP As clsPP, ByRef CP_SBAURIKN As clsCP) As Object
		Dim Rtn As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g SBAURIKN_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SBAURIKN_CHECKC = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SBAURIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(SBAURIKN) = "" Or Not IsNumeric(SBAURIKN) Then Exit Function
		On Error GoTo OverFlow
		
		' �V�X�e����̐Ŕ������z�ƁA����͐Ŕ������z����v����ꍇ�A�ŋ��E�ō����z��\���B
		' ����ȊO�̓G���[���b�Z�[�W��\��
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SBAUZEKN(0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SBAURIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (SBAURIKN + RD_SSSMAIN_SBAUZEKN(0)) <> RD_SSSMAIN_SBADENKN(0) Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '���׍��v�l�Ɠ��͒l���قȂ�|�̃G���[���b�Z�[�W
            MsgBox("���׍��v�l�Ɠ��͒l���قȂ�܂��B", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			'UPGRADE_WARNING: �I�u�W�F�N�g SBAURIKN_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SBAURIKN_CHECKC = -1
		End If
		Exit Function
OverFlow: 
		CP_SBAURIKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: �I�u�W�F�N�g SBAURIKN_CHECKC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SBAURIKN_CHECKC = "??????????????????"
	End Function
End Module