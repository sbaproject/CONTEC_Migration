Option Strict Off
Option Explicit On
Module FRDSU_F51
	'
	' �X���b�g��        : �o�׎w�����ʁE��ʍ��ڃX���b�g
	' ���j�b�g��        : FRDSU.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/07/16
	' �g�p�v���O������  : SYKET51
	'
	'��)2008/05/20����OTPSU�͏������ł͖��g�p
	Function FRDSU_CheckC(ByVal FRDSU As Object, ByVal OTPSU As Object, ByVal FRDKNSU As Object, ByVal BKTHKKB As Object, ByVal HINCD As Object, ByVal WRKKB As Object, ByVal De_index As Object, ByVal Ex_FRDSU As Object) As Object
		Dim rtn As Short
		Dim wkHINCD As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g FRDSU_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRDSU_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(FRDSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(FRDSU) = 0 Then Exit Function
		
		'�o�׎w�����������
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(FRDSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(FRDKNSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(FRDKNSU) < SSSVal(FRDSU) Then
			rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 5)
			'UPGRADE_WARNING: �I�u�W�F�N�g FRDSU_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FRDSU_CheckC = -1
			Exit Function
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(FRDSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(FRDKNSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g BKTHKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (BKTHKKB = "9") And (SSSVal(FRDKNSU) <> SSSVal(FRDSU)) Then
				rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 6)
				'UPGRADE_WARNING: �I�u�W�F�N�g FRDSU_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				FRDSU_CheckC = -1
				Exit Function
			End If
		End If
		
		'�ړ����������͕͂s�Ƃ���
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(FRDSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(FRDKNSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(FRDKNSU) <> SSSVal(FRDSU) Then
			rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 6)
			'UPGRADE_WARNING: �I�u�W�F�N�g FRDSU_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FRDSU_CheckC = -1
			Exit Function
		End If
		
		'�o�ג�~���i
		Call HINMTA_RClear()
		Call DB_GetEq(DBN_HINMTA, 1, HINCD, BtrNormal)
		If DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Or DB_SYKTRA.WRKKB = "5" Then
		Else
			''''2007.03.08 UPD-START
			''''    If (DBSTAT = "9") Or (DB_HINMTA.ORTSTPKB = "9" And DB_HINMTA.ORTSTPDT <= DB_UNYMTA.UNYDT) Then
			''''        rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 7)
			''''        FRDSU_CheckC = -1
			''''    End If
			If DBSTAT = CDbl("9") Then
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '�Y�����R�[�h����
				'UPGRADE_WARNING: �I�u�W�F�N�g FRDSU_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				FRDSU_CheckC = -1
			Else
				If DB_HINMTA.ORTSTPKB = "9" And DB_HINMTA.ORTSTPDT <= DB_UNYMTA.UNYDT Then
					rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 7)
					'UPGRADE_WARNING: �I�u�W�F�N�g FRDSU_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					FRDSU_CheckC = -1
				End If
				If DB_HINMTA.ORTSTPKB = "8" Then
					rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 8)
					'UPGRADE_WARNING: �I�u�W�F�N�g FRDSU_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					FRDSU_CheckC = -1
				End If
			End If
			''''2007.03.08 UPD-END
		End If
		
	End Function
	
	Function FRDSU_DerivedC(ByVal HINCD As Object, ByVal FRDSU As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g FRDSU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FRDSU_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRDSU_DerivedC = FRDSU
		
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) = "" Then Exit Function
	End Function
End Module