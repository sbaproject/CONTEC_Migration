Option Strict Off
Option Explicit On
Module IDOET52_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : UODET01.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 1997/09/18
	' �g�p�v���O������  : UODET01
	'
	
	Public Const WG_DKBSB As String = "010"
	
	Function DSPTRN() As Short
		'Dim DATNO As String, I As Integer, rtn As Integer
		'    '
		'    I = 0
		'    DATNO = Trim$(SSS_LASTKEY)
		'    Call DB_GetGrEq(DBN_JDNTHA, 1, SSS_LASTKEY, BtrNormal)
		'    If DBSTAT = 0 Then
		'        If SSSVal(DB_JDNTHA.JDNENDKB) > 0 Then        ' �󒍊m���
		'            SSS_UPDATEFL = False
		'            Call DSP_MsgBox(SSS_CINFO, "CHANGE", 0)   ' �󒍊m��ςׁ̈A�ύX�ł��܂���B
		'        ElseIf DB_JDNTHA.JDNDT <= DB_SYSTBA.MONUPDDT Then
		'            SSS_UPDATEFL = False                      ' �Ăяo���`�[�̌o���m�菈�����ȑO�̍X�V�𖳌���
		'        End If
		'        Call SCR_FromJDNTHA(0)
		'        Call DB_GetGrEq(DBN_JDNTRA, 1, SSS_LASTKEY, BtrNormal)
		'        If (DBSTAT = 0) And (DATNO = DB_JDNTRA.DATNO) Then
		'            Do While (DBSTAT = 0) And (DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
		'                Call SCR_FromMfil(I)
		'                Call DB_GetNext(DBN_JDNTRA, BtrNormal)
		'                I = I + 1
		'            Loop
		'        End If
		'    End If
		'    '
		'    DSPTRN = I
	End Function
	
	Sub INITDSP()
		'
		'    Call DB_GetFirst(DBN_SYSTBA, 1, BtrNormal)
	End Sub
	
	Function INQ_UPDATE() As Object
		'Dim rtn As Integer
		'    '
		'    INQ_UPDATE = -1
		'    '
		'    Select Case SSS_BILFL
		'    Case 1      ' �`�[���s�L��
		'        ' �`�[���s�̏ꍇ�̓��b�Z�[�W�m�F�����Ȃ��̂ł����ŃE�B���h�E��\������
		'        DLGLST3.Show 1
		'        Select Case SSSVal(SSS_RTNWIN)
		'        Case 0              ' �v��{���s
		'            rtn = DELTRN()
		'            rtn = WRTTRN()
		'            '1999/12/01 �X�V�G���[�̏ꍇ�ɂ͓`�[���s���Ȃ�
		'            If rtn = True Then Call PRNBIL
		'            'Call PRNBIL
		'        Case 1              ' �v��̂�
		'            rtn = DELTRN()
		'            rtn = WRTTRN()
		'        Case 2              ' ���s�̂�
		'            Call PRNBIL
		'        Case Else           ' �߂�
		'            INQ_UPDATE = 0
		'        End Select
		'    Case 9      ' �v��̂�
		'        rtn = DELTRN()
		'        rtn = WRTTRN()
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