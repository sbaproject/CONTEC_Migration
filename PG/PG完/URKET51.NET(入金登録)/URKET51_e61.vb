Option Strict Off
Option Explicit On
Module URKET51_E61
	'
	' �X���b�g��        : ��ʓ��������E��ʏ����X���b�g
	' ���j�b�g��        : URKET51.E61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/09/28
	' �g�p�v���O������  : URKET51
	'
	'Global Const WG_TUKKB = "JPY"
	'Global Const WG_DKBSB = "050"
	'Global Const WG_DENKB = "8"
	Public DateFirst As Boolean
	Function DSPTRN() As Object
		'Dim WK_DATNO, I As Integer
		'    '
		'    I = 0
		'    WK_DATNO = Trim$(SSS_LASTKEY)
		'    Call DB_GetGrEq(DBN_UDNTHA, 1, SSS_LASTKEY, BtrNormal)
		'    If DBSTAT = 0 Then
		''        If DB_UDNTHA.UDNDT <= DB_SYSTBA.UKSMEDT Then
		''            SSS_UPDATEFL = False   '�Ăяo���`�[�̌o���m�菈�����ȑO�̍X�V�𖳌���
		''        End If
		'        Call SCR_FromUDNTHA(0)
		'        Call DB_GetGrEq(DBN_UDNTRA, 1, SSS_LASTKEY, BtrNormal)
		'        If (DBSTAT = 0) And (WK_DATNO = DB_UDNTRA.DATNO) Then
		'            Do While (DBSTAT = 0) And (WK_DATNO = DB_UDNTRA.DATNO) And (SSSVal(DB_UDNTRA.LINNO) < 990)
		'                Call SCR_FromMfil(I)
		'                Call DB_GetNext(DBN_UDNTRA, BtrNormal)
		'                I = I + 1
		'            Loop
		'        End If
		'    End If
		'    DSPTRN = I
	End Function
	
	Sub INITDSP()
		'Dim Px As Integer
		'Dim I As Integer
		'    '
		'    Call DB_GetEq(DBN_SYSTBA, 1, "001", BtrNormal)
		'    '
		'    '�w�i�F�ύX
		'    AE_BackColor(1) = &H8000000F
		'    AE_BackColor(2) = &HFFFFFF
		'    '
		'    ' �w�b�_
		'    CL_SSSMAIN(4) = 1
		'    CL_SSSMAIN(5) = 1
		'    CL_SSSMAIN(7) = 1
		'    CL_SSSMAIN(8) = 1
		'    '
		'    ' �{�f�B
		'    For I = 0 To PP_SSSMAIN.MaxDe
		'        CL_SSSMAIN(29 + (I * 23) + 0) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 2) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 6) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 7) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 8) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 9) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 10) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 11) = 1
		'    Next
		'    '
		'    ' �e�C��
		'    CL_SSSMAIN(29 + (PP_SSSMAIN.MaxDe + 1) * 23 + 0) = 11
		'    CL_SSSMAIN(29 + (PP_SSSMAIN.MaxDe + 1) * 23 + 1) = 11
		
	End Sub
	
	Function INQ_UPDATE() As Object
		'Dim Rtn As Integer
		'    '
		'    INQ_UPDATE = -1
		'    '
		'    Select Case SSS_BILFL
		'    Case 1      ' �`�[���s�L��
		'        ' �`�[���s�̏ꍇ�̓��b�Z�[�W�m�F�����Ȃ��̂ł����ŃE�B���h�E��\������
		'        DLGLST3.Show 1
		'        Select Case SSSVal(SSS_RTNWIN)
		'        Case 0              ' �v��{���s
		'            Rtn = DELTRN()
		'            Rtn = WRTTRN()
		'            '1999/12/01 �X�V�G���[�̏ꍇ�ɂ͓`�[���s���Ȃ�
		'            If Rtn = True Then Call PRNBIL
		'            'Call PRNBIL
		'        Case 1              ' �v��̂�
		'            Rtn = DELTRN()
		'            Rtn = WRTTRN()
		'        Case 2              ' ���s�̂�
		'            Call PRNBIL
		'        Case Else           ' �߂�
		'            INQ_UPDATE = 0
		'        End Select
		'    Case 9      ' �v��̂�
		'        Rtn = DELTRN()
		'        Rtn = WRTTRN()
		'    End Select
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