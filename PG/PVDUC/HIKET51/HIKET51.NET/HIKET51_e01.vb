Option Strict Off
Option Explicit On
Module HIKET51_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : UODET01.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 1997/09/18
	' �g�p�v���O������  : UODET01
	'
	
	Public Const WG_DKBSB As String = "010"
	
	Function DSPTRN() As Short
		Dim DATNO As String
		Dim I, Rtn As Short
		'
		I = 0
		DATNO = Trim(SSS_LASTKEY.Value)
		Call DB_GetGrEq(DBN_JDNTHA, 1, SSS_LASTKEY.Value, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_JDNTHA.JDNENDKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(DB_JDNTHA.JDNENDKB) > 0 Then ' �󒍊m���
				SSS_UPDATEFL = False
				Call DSP_MsgBox(SSS_CINFO, "CHANGE", 0) ' �󒍊m��ςׁ̈A�ύX�ł��܂���B
			ElseIf DB_JDNTHA.JDNDT <= DB_SYSTBA.MONUPDDT Then 
				SSS_UPDATEFL = False ' �Ăяo���`�[�̌o���m�菈�����ȑO�̍X�V�𖳌���
			End If
			Call SCR_FromJDNTHA(0)
			Call DB_GetGrEq(DBN_JDNTRA, 1, SSS_LASTKEY.Value, BtrNormal)
			If (DBSTAT = 0) And (DATNO = DB_JDNTRA.DATNO) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_JDNTRA.LINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Do While (DBSTAT = 0) And (DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
					Call SCR_FromMfil(I)
					Call DB_GetNext(DBN_JDNTRA, BtrNormal)
					I = I + 1
				Loop 
			End If
		End If
		'
		DSPTRN = I
	End Function
	
	Sub INITDSP()
		'
		Call DB_GetFirst(DBN_SYSTBA, 1, BtrNormal)
	End Sub
	
	Function INQ_UPDATE() As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g INQ_UPDATE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		INQ_UPDATE = -1
		'
		Select Case SSS_BILFL
			Case 1 ' �`�[���s�L��
				' �`�[���s�̏ꍇ�̓��b�Z�[�W�m�F�����Ȃ��̂ł����ŃE�B���h�E��\������
				DLGLST3.ShowDialog()
				Select Case SSSVal(SSS_RTNWIN)
					Case 0 ' �v��{���s
						Rtn = DELTRN()
						Rtn = WRTTRN()
						'1999/12/01 �X�V�G���[�̏ꍇ�ɂ͓`�[���s���Ȃ�
						If Rtn = True Then Call PRNBIL()
						'Call PRNBIL
					Case 1 ' �v��̂�
						Rtn = DELTRN()
						Rtn = WRTTRN()
					Case 2 ' ���s�̂�
						Call PRNBIL()
					Case Else ' �߂�
						'UPGRADE_WARNING: �I�u�W�F�N�g INQ_UPDATE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						INQ_UPDATE = 0
				End Select
			Case 9 ' �v��̂�
				Rtn = DELTRN()
				Rtn = WRTTRN()
		End Select
	End Function
	
	' �v�����^�؂�ւ��@�\��L���ɂ���ꍇ�͈ȉ��̃R�����g�A�E�g������L���ɂ���B
	' ���ɂr�e�c�܂��͂o�c�a�ŉ�ʂ́hCM_LCONFIG�h�C���[�W���\������\���֕ύX����B
	Function LCONFIG_GetEvent() As Short
		'   ' �v�����^�[�ݒ�
		'    LCONFIG_GetEvent = True
		'    DB_SYSTBI.PRGID = SSS_PrgId
		'    DB_SYSTBI.LSTID = RD_SSSMAIN_LSTID(0)
		'    Call DB_GetEq(DBN_SYSTBI, 1, DB_SYSTBI.PRGID & DB_SYSTBI.LSTID, BtrNormal)
		'    If DBSTAT = 0 Then
		'        SSS_RPTID = Trim$(DB_SYSTBI.RPTID)
		'    Else
		'        SSS_RPTID = ""
		'    End If
		'    WLS_PRN.Show 1
	End Function
End Module