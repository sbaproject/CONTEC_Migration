Option Strict Off
Option Explicit On
Module JDNLINNO_O01
	'
	' �X���b�g��        : �󒍓`�[���������E�I�v�V���i���X���b�g
	' ���j�b�g��        : JDNLINNO.O01
	' �L�q��            : Standard Library
	' �쐬���t          : 2001/12/19
	' �g�p�v���O������  : URIET16
	'
	
	' ���i�R�[�h�ύX����, ������񂪃N���A����Ă��܂����Ƃւ̌x���B
	' HINCD_CheckC ����Ă΂��B
	Function Check_Link(ByVal DE_INDEX As Object) As Boolean
		Dim JDNLINNO As String
		Dim Msg As String
		
		Check_Link = True
		'�����s�̕ύX���x������
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNLINNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		JDNLINNO = RD_SSSMAIN_JDNLINNO(DE_INDEX)
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(JDNLINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(JDNLINNO) <> 0 Then
			Msg = "���i�R�[�h��ύX����Ǝ󒍓`�[�����̑ΏۊO�ƂȂ�܂��B" & vbCrLf
			Msg = Msg & "�ύX�𒆎~���܂����H"
			If MsgBox(Msg, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "�x��") = MsgBoxResult.Yes Then
				Check_Link = False
			End If
		End If
	End Function
	
	' ���i�R�[�h���ύX���ꂽ�ꍇ��, �󒍓`�[�s�ԍ��� RECNO ���N���A����B
	' HINCD_CheckC ����Ă΂��B
	Function Clear_Link(ByVal DE_INDEX As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DP_SSSMAIN_JDNLINNO(DE_INDEX, "")
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DP_SSSMAIN_RECNO(DE_INDEX, "")
	End Function
	
	' �s�N���A����, ������񂪃N���A����Ă��܂����Ƃւ̌x���B
	Function ClearDe_GetEvent(ByVal DE_INDEX As Object, ByVal JDNLINNO As Object) As Object
		
		Dim Msg As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g ClearDe_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClearDe_GetEvent = True
		
		'�����s�̏��������x������
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(JDNLINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(JDNLINNO) <> 0 Then
			Msg = "���̍s������������Ǝ󒍓`�[�����̑ΏۊO�ƂȂ�܂��B" & vbCrLf
			Msg = Msg & "�s�������𒆎~���܂����H"
			If MsgBox(Msg, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "�x��") = MsgBoxResult.Yes Then
				'UPGRADE_WARNING: �I�u�W�F�N�g ClearDe_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ClearDe_GetEvent = False
			End If
		End If
	End Function
	
	' �s�폜����, ������񂪃N���A����Ă��܂����Ƃւ̌x���B
	Function DeleteDe_GetEvent(ByVal DE_INDEX As Object, ByVal JDNLINNO As Object) As Object
		Dim Msg As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DeleteDe_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DeleteDe_GetEvent = True
		
		'�����s�̍폜���x������
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(JDNLINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(JDNLINNO) <> 0 Then
			Msg = "���̍s���폜����Ǝ󒍓`�[�����̑ΏۊO�ƂȂ�܂��B" & vbCrLf
			Msg = Msg & "�s�폜�𒆎~���܂����H"
			If MsgBox(Msg, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "�x��") = MsgBoxResult.Yes Then
				'UPGRADE_WARNING: �I�u�W�F�N�g DeleteDe_GetEvent �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DeleteDe_GetEvent = False
			End If
		End If
	End Function
End Module