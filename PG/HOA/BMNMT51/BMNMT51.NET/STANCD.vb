Option Strict Off
Option Explicit On
Module STANCD_F51
	'
	'�X���b�g��      :���Y����E��ʍ��ڃX���b�g
	'���j�b�g��      :STANCD.F01
	'�L�q��          :Standard Library
	'�쐬���t        :2006/06/15
	'�g�p�v���O����  :BMNMT51
	'
	Function STANCD_CheckC(ByRef STANCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkSTANCD As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g STANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STANCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g STANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(STANCD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(STANCD)) = 0 Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g STANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkSTANCD = STANCD & Space(Len(DB_MEIMTA.MEICDA) - Len(STANCD))
			Call DB_GetEq(DBN_MEIMTA, 2, "025" & wkSTANCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g STANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					STANCD_CheckC = 1
				End If
			Else
				rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g STANCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				STANCD_CheckC = -1
			End If
		End If
		
	End Function
End Module