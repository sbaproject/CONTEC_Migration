Option Strict Off
Option Explicit On
Module URKET52_E01
	'
	' �X���b�g��        : ��ʓ��������E��ʏ����X���b�g
	' ���j�b�g��        : URKET52.E01
	' �L�q��            : Muratani
	' �쐬���t          : 2006/08/29
	' �g�p�v���O������  : URKET52
	'
	'Global Const WG_TUKKB = "JPY"
	'Global Const WG_DKBSB = "050"
	'Global Const WG_DENKB = "8"
	Public DateFirst As Boolean
	
	Function DSPTRN() As Object
		'Dim WK_DATNO, i As Integer
		'Dim sumKSKZANKN As Currency
		'    '
		'
		'    DateFirst = True
		'
		'    i = 0
		'    Call DP_SSSMAIN_CHKFLG(i, "0")
		'    WK_DATNO = Trim$(SSS_LASTKEY)
		'    Call DB_GetGrEq(DBN_UDNTHA, 1, SSS_LASTKEY, BtrNormal)
		'    If DBSTAT = 0 Then
		''       If DB_UDNTHA.UDNDT <= DB_SYSTBA.MONUPDDT Then
		''           SSS_UPDATEFL = False   '�Ăяo���`�[�̌o���m�菈�����ȑO�̍X�V�𖳌���
		''       End If
		'        Call SCR_FromUDNTHA(0)
		'
		'        Call DP_SSSMAIN_SSANYUKN(0, DB_UDNTHA.SBANYUKN)
		'        Call DP_SSSMAIN_SSANYUKN(0, DB_UDNTHA.SBAFRNKN)
		'
		'        Call DB_GetEq(DBN_TOKMTA, 1, DB_UDNTHA.TOKCD, BtrNormal)
		''       Call TOKCD_CheckC(DB_UDNTHA.TOKCD, ByVal 0)
		'
		'        Call DB_GetGrEq(DBN_UDNTRA, 1, SSS_LASTKEY, BtrNormal)
		'        If (DBSTAT = 0) And (WK_DATNO = DB_UDNTRA.DATNO) Then
		'            Do While (DBSTAT = 0) And (WK_DATNO = DB_UDNTRA.DATNO) And (SSSVal(DB_UDNTRA.LINNO) < 990)
		'                Call SCR_FromMfil(i)
		'                If Trim$(DB_TOKMTA.FRNKB) = "0" Then
		'                    Call DP_SSSMAIN_FNYUKN(i, "")
		'                End If
		'                '2007.01.12 �w�������=02,03�̎��A��s�R�[�h���ύX�ł��Ȃ��x�Ή�
		'''''            If Trim$(DB_UDNTRA.DKBID) = "03" Then
		'''''                Call AE_InOutModeN_SSSMAIN("TEGDT", "2202", I)
		'''''                Call AE_InOutModeN_SSSMAIN("TEGNO", "2202", I)
		'''''            Else
		'''''                Call AE_InOutModeN_SSSMAIN("TEGDT", "0000", I)
		'''''                Call AE_InOutModeN_SSSMAIN("TEGNO", "0000", I)
		'''''            End If
		'                Select Case Trim$(DB_UDNTRA.DKBID)
		'                    Case "02"       '�U��
		'
		''2008/08/11 DEL START FKS)NAKATA
		'''��s�R�[�h�ւ̃J�[�\���J�ڂ��Ȃ�������
		'''                        Call AE_InOutModeN_SSSMAIN("BNKCD", "2202", i)
		'                        Call AE_InOutModeN_SSSMAIN("BNKCD", "0000", i)
		''2008/08/11 DEL E.N.D FKS)NAKATA
		'
		'                        Call AE_InOutModeN_SSSMAIN("TEGDT", "0000", i)
		'                        Call AE_InOutModeN_SSSMAIN("TEGNO", "0000", i)
		'                    Case "03"       '��`
		' '2008/08/11 DEL START FKS)NAKATA
		'''��s�R�[�h�ւ̃J�[�\���J�ڂ��Ȃ�������
		'''                        Call AE_InOutModeN_SSSMAIN("BNKCD", "2202", i)
		'                        Call AE_InOutModeN_SSSMAIN("BNKCD", "0000", i)
		''2008/08/11 DEL E.N.D FKS)NAKATA
		'                        Call AE_InOutModeN_SSSMAIN("TEGDT", "2202", i)
		'                        Call AE_InOutModeN_SSSMAIN("TEGNO", "2202", i)
		'                    Case Else
		'                        Call AE_InOutModeN_SSSMAIN("BNKCD", "0000", i)
		'                        Call AE_InOutModeN_SSSMAIN("TEGDT", "0000", i)
		'                        Call AE_InOutModeN_SSSMAIN("TEGNO", "0000", i)
		'                End Select
		'                '2007.01.12
		'
		'                If Trim$(DB_TOKMTA.FRNKB) = "0" Then
		'                    Call AE_InOutModeN_SSSMAIN("NYUKN", "3303", i)
		'                    Call AE_InOutModeN_SSSMAIN("FNYUKN", "0000", i)
		'                Else
		'                    Call AE_InOutModeN_SSSMAIN("NYUKN", "3303", i)
		'                    Call AE_InOutModeN_SSSMAIN("FNYUKN", "3303", i)
		'                End If
		'
		'
		'''''            If Trim$(DB_UDNTRA.DKBID) = "02" Or _
		''''''               Trim$(DB_UDNTRA.DKBID) = "03" Then
		'                If Trim$(DB_UDNTRA.DKBID) = "02" Then
		'                    Call DP_SSSMAIN_YKNKB(i, DB_TOKMTA.YKNKB)
		'                    Call DP_SSSMAIN_KOZNO(i, DB_TOKMTA.KOZNO)
		'                    Call DP_SSSMAIN_HMEIGI(i, DB_TOKMTA.HMEIGI)
		'                    Select Case DB_TOKMTA.YKNKB
		'                        Case 1: Call DP_SSSMAIN_YKNNM(i, "����")
		'                        Case 2: Call DP_SSSMAIN_YKNNM(i, "����")
		'                        Case 9: Call DP_SSSMAIN_YKNNM(i, "���̑�")
		'                    End Select
		'                End If
		'
		'                Call DB_GetNext(DBN_UDNTRA, BtrNormal)
		'                i = i + 1
		'            Loop
		'        End If
		'
		''       If DB_UDNTHA.UDNDT <= CNV_DATE(DB_SYSTBA.MONUPDDT) Then
		''           Call DSP_MsgBox(SSS_CONFRM, SSS_PrgId, 0)  '�u�O���x�̓`�[�������s���܂��v
		''       End If
		'    End If
		'
		'    DSPTRN = i
		'
	End Function
	
	Sub INITDSP()
		'Dim Px As Integer
		'Dim i As Integer
		'
		'    '���[�U���Ǘ��e�[�u��
		'    Call DB_GetEq(DBN_SYSTBA, 1, "001", BtrNormal)
		'
		'    '�^�p�����擾
		'    Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		'
		''    '�w�i�F�ύX
		'    AE_BackColor(1) = &H8000000F
		''    '
		''    ' �w�b�_
		'    CL_SSSMAIN(1) = 1
		'    CL_SSSMAIN(4) = 1
		'    CL_SSSMAIN(5) = 1
		'    CL_SSSMAIN(6) = 1
		'    CL_SSSMAIN(8) = 1
		'    CL_SSSMAIN(9) = 1
		''    '
		''    ' �{�f�B
		'    For i = 0 To PP_SSSMAIN.MaxDe
		'        CL_SSSMAIN(33 + (i * 25) + 0) = 1
		'        CL_SSSMAIN(33 + (i * 25) + 2) = 1
		'        CL_SSSMAIN(33 + (i * 25) + 6) = 1
		'        CL_SSSMAIN(33 + (i * 25) + 7) = 1
		'        CL_SSSMAIN(33 + (i * 25) + 8) = 1
		'        CL_SSSMAIN(33 + (i * 25) + 9) = 1
		'        CL_SSSMAIN(33 + (i * 25) + 10) = 1
		'        CL_SSSMAIN(33 + (i * 25) + 11) = 1
		'    Next
		''    '
		''    ' �e�C��
		'    CL_SSSMAIN(33 + (PP_SSSMAIN.MaxDe + 1) * 25 + 0) = 1
		'    CL_SSSMAIN(33 + (PP_SSSMAIN.MaxDe + 1) * 25 + 1) = 1
		'
		'    '���s�����̎擾
		'    Call Get_Authority(DB_UNYMTA.UNYDT)
		'
	End Sub
	
	Function INQ_UPDATE() As Object
		'
		'Dim Rtn             As Integer
		'Dim strSQL          As String
		''Dim sumKSKZANKN    As Currency
		''Dim wkKSKNYKKN     As Currency
		'Dim curCHECKKIN     As Currency
		'Dim curNYUKNZAN     As Currency
		'
		'    INQ_UPDATE = -1
		'
		'    '�����`�F�b�N
		'    If gs_UPDAUTH = "9" Then
		'        Rtn = DSP_MsgBox(SSS_ERROR, "UPDAUTH", 0) '�X�V�����Ȃ�
		'        INQ_UPDATE = 0
		'        Exit Function
		'    End If
		'
		'    '������̏��`�F�b�N           '2007.02.09 �`�F�b�N�����ύX
		'''''sumKSKZANKN = 0
		'''''wkKSKNYKKN = 0
		'''''If RD_SSSMAIN_FRNKB(0) = "0" Then
		'''''''''    If DB_UDNTHA.MAEUKKB = "1" Then         '2006.10.31
		'''''    '����
		'''''    If DB_UDNTHA.NYUCD = "1" Then
		'''''        '�ʏ����
		'''''        Call DB_GetLsEq(DBN_TOKSSA, 1, RD_SSSMAIN_TOKCD(0) & SSS_SSADT, BtrNormal)
		'''''        Do While (DBSTAT = 0) And (DB_TOKSSA.TOKCD = RD_SSSMAIN_TOKCD(0)) And (DB_TOKSSA.SSADT <= SSS_SSADT)
		'''''            sumKSKZANKN = sumKSKZANKN + DB_TOKSSA.KSKZANKN
		'''''            If DB_TOKSSA.SSADT = SSS_SSADT Then
		'''''                wkKSKNYKKN = DB_TOKSSA.KSKNYKKN
		'''''            End If
		'''''            Call DB_GetNext(DBN_TOKSSA, BtrNormal)
		'''''        Loop
		'''''    Else
		'''''        '�O�����
		'''''        Call DB_GetLsEq(DBN_TOKSSB, 1, RD_SSSMAIN_TOKCD(0) & SSS_SSADT, BtrNormal)
		'''''        Do While (DBSTAT = 0) And (DB_TOKSSB.TOKCD = RD_SSSMAIN_TOKCD(0)) And (DB_TOKSSB.SSADT <= SSS_SSADT)
		'''''            sumKSKZANKN = sumKSKZANKN + DB_TOKSSB.KSKZANKN
		'''''            If DB_TOKSSB.SSADT = SSS_SSADT Then
		'''''                wkKSKNYKKN = DB_TOKSSB.KSKNYKKN
		'''''            End If
		'''''            Call DB_GetNext(DBN_TOKSSB, BtrNormal)
		'''''        Loop
		'''''    End If
		'''''Else
		'''''    '�C�O
		'''''    Call DB_GetGrEq(DBN_TOKSSC, 1, RD_SSSMAIN_TOKCD(0) & RD_SSSMAIN_TUKKB(0) & SSS_SSADT, BtrNormal)
		'''''    Do While (DBSTAT = 0) And (DB_TOKSSC.TOKCD = RD_SSSMAIN_TOKCD(0)) _
		''''''                          And (DB_TOKSSC.TUKKB = RD_SSSMAIN_TUKKB(0)) And (DB_TOKSSC.SSADT <= SSS_SSADT)
		'''''        sumKSKZANKN = sumKSKZANKN + DB_TOKSSC.FKSZANKN
		'''''        If (DB_TOKSSC.SSADT = SSS_SSADT) And (DB_TOKSSC.TUKKB = RD_SSSMAIN_TUKKB(0)) Then
		'''''            wkKSKNYKKN = DB_TOKSSC.FKSNYKKN
		'''''        End If
		'''''        Call DB_GetNext(DBN_TOKSSC, BtrNormal)
		'''''    Loop
		'''''End If
		'
		'''''If DB_UDNTHA.FRNKB = "0" Then
		'''''    If DB_UDNTHA.SBANYUKN - RD_SSSMAIN_SBANYUKN(0) > sumKSKZANKN Then
		'''''        Rtn = DSP_MsgBox(SSS_CONFRM, SSS_PrgId, 3)  '�u�ύX���z�������z�𒴂��Ă��܂��B�v
		'''''        INQ_UPDATE = 0
		'''''        Exit Function
		'''''    End If
		'''''Else
		'''''    If DB_UDNTHA.SBAFRNKN - RD_SSSMAIN_SBAFRNKN(0) > sumKSKZANKN Then
		'''''        Rtn = DSP_MsgBox(SSS_CONFRM, SSS_PrgId, 3)  '�u�ύX���z�������z�𒴂��Ă��܂��B�v
		'''''        INQ_UPDATE = 0
		'''''        Exit Function
		'''''    End If
		'''''End If
		'
		'    '�ύX���z�`�F�b�N               '2007.02.09
		'    If DB_UDNTHA.FRNKB = "0" Then
		'        curCHECKKIN = DB_UDNTHA.SBANYUKN - RD_SSSMAIN_SBANYUKN(0)
		'    Else
		'        curCHECKKIN = DB_UDNTHA.SBAFRNKN - RD_SSSMAIN_SBAFRNKN(0)
		'    End If
		'
		'    '���������z�c���擾
		'    Call GET_KESIZAN(RD_SSSMAIN_TOKCD(0), _
		''                     DB_UDNTHA.FRNKB, _
		''                     DB_UDNTHA.NYUCD, _
		''                     RD_SSSMAIN_TUKKB(0), _
		''                     curNYUKNZAN)
		'
		'    If curCHECKKIN > curNYUKNZAN Then
		'        Rtn = DSP_MsgBox(SSS_CONFRM, SSS_PrgId, 3)  '�u�ύX���z�������z�𒴂��Ă��܂��B�v
		'        INQ_UPDATE = 0
		'        Exit Function
		'    End If
		'
		'    Rtn = DELTRN()
		'    Rtn = WRTTRN()
		'
	End Function
	
	'���������z�c���擾�i�ΏۃT�}���̓��������c�z��S�z�W�v����j                   '2007.02.09
	'
	'   pin_SEICD   : ������R�[�h
	'   pin_FRNKB   : �����E�C�O�敪    �i�O�F�����@�P�F�C�O�j  �K�{
	'   pin_NYUCD   : �����敪          �i�P�F�ʏ�@�Q�F�O��j  �����̏ꍇ�A�K�{
	'   pin_TUKKB   : �ʉ݋敪                                  �C�O�̏ꍇ�A�K�{
	'
	'   pot_KESIZAN : ���������z�c      �擾���z��Ԃ��B
	'
	Public Function GET_KESIZAN(ByVal pin_SEICD As String, ByVal pin_FRNKB As String, ByVal pin_NYUCD As String, ByVal pin_TUKKB As String, ByRef pot_KESIZAN As Decimal) As Object
		'
		'    Dim strSQL      As String
		'    Dim curZAN      As Currency
		'
		'    curZAN = 0
		'
		'    Select Case pin_FRNKB
		'
		'        Case "0"        '����
		'            Select Case pin_NYUCD
		'
		'                Case "1"            '�ʏ�
		'                    strSQL = ""
		'                    strSQL = strSQL & vbCrLf & "Select TOKCD, Sum(KSKZANKN)          From TOKSSA"
		'                    strSQL = strSQL & vbCrLf & " Where TOKCD = " & "'" & pin_SEICD & "'"
		'                    strSQL = strSQL & vbCrLf & " Group By TOKCD"
		'
		'                    Call DB_GetSQL2(DBN_TOKSSA, strSQL)
		'                    curZAN = DB_ExtNum.ExtNum(0)
		'
		'                Case "2"            '�O��
		'                    strSQL = ""
		'                    strSQL = strSQL & vbCrLf & "Select TOKCD, Sum(KSKZANKN)          From TOKSSB"
		'                    strSQL = strSQL & vbCrLf & " Where TOKCD = " & "'" & pin_SEICD & "'"
		'                    strSQL = strSQL & vbCrLf & " Group By TOKCD"
		'
		'                    Call DB_GetSQL2(DBN_TOKSSA, strSQL)
		'                    curZAN = DB_ExtNum.ExtNum(0)
		'            End Select
		'
		'        Case "1"        '�C�O
		'            strSQL = ""
		'            strSQL = strSQL & vbCrLf & "Select TOKCD, TUKKB, Sum(FKSZANKN)   From TOKSSC"
		'            strSQL = strSQL & vbCrLf & " Where TOKCD = " & "'" & pin_SEICD & "'"
		'            strSQL = strSQL & vbCrLf & "   And TUKKB = " & "'" & pin_TUKKB & "'"
		'            strSQL = strSQL & vbCrLf & " Group By TOKCD, TUKKB"
		'
		'            Call DB_GetSQL2(DBN_TOKSSA, strSQL)
		'            curZAN = DB_ExtNum.ExtNum(1)
		'
		'    End Select
		'
		'    pot_KESIZAN = curZAN
		'
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
	'
	'Function SSSMAIN_OPEID_BeginPrg(PP As clsPP, CP_OPEID As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_OPEID.CpPx) = 5
	'    SSSMAIN_OPEID_BeginPrg = True
	'End Function
	'Function SSSMAIN_OPENM_BeginPrg(PP As clsPP, CP_OPENM As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_OPENM.CpPx) = 5
	'    SSSMAIN_OPENM_BeginPrg = True
	'End Function
	'Function SSSMAIN_TOKRN_BeginPrg(PP As clsPP, CP_TOKRN As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_TOKRN.CpPx) = 5
	'    SSSMAIN_TOKRN_BeginPrg = True
	'End Function
	'Function SSSMAIN_TUKKB_BeginPrg(PP As clsPP, CP_TUKKB As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_TUKKB.CpPx) = 5
	'    SSSMAIN_TUKKB_BeginPrg = True
	'End Function
	'
	'Function SSSMAIN_LIMNO_BeginPrg(PP As clsPP, CP_LIMNO As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_LIMNO.CpPx) = 5
	'    SSSMAIN_LIMNO_BeginPrg = True
	'End Function
	'Function SSSMAIN_DKBNM_BeginPrg(PP As clsPP, CP_DKBNM As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_DKBNM.CpPx) = 5
	'    SSSMAIN_DKBNM_BeginPrg = True
	'End Function
	'Function SSSMAIN_BNKCD_BeginPrg(PP As clsPP, CP_BNKCD As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_BNKCD.CpPx) = 5
	'    SSSMAIN_BNKCD_BeginPrg = True
	'End Function
	'Function SSSMAIN_BNKNM_BeginPrg(PP As clsPP, CP_BNKNM As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_BNKNM.CpPx) = 5
	'    SSSMAIN_BNKNM_BeginPrg = True
	'End Function
	'Function SSSMAIN_YKNKB_BeginPrg(PP As clsPP, CP_YKNKB As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_YKNKB.CpPx) = 5
	'    SSSMAIN_YKNKB_BeginPrg = True
	'End Function
	'Function SSSMAIN_YKNNM_BeginPrg(PP As clsPP, CP_YKNNM As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_YKNNM.CpPx) = 5
	'    SSSMAIN_YKNNM_BeginPrg = True
	'End Function
	'Function SSSMAIN_KOZNO_BeginPrg(PP As clsPP, CP_KOZNO As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_KOZNO.CpPx) = 5
	'    SSSMAIN_KOZNO_BeginPrg = True
	'End Function
	'Function SSSMAIN_HMEIGI_BeginPrg(PP As clsPP, CP_HMEIGI As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_HMEIGI.CpPx) = 5
	'    SSSMAIN_HMEIGI_BeginPrg = True
	'End Function
	'
	'Function SSSMAIN_SBANYUKN_BeginPrg(PP As clsPP, CP_SBANYUKN As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_SBANYUKN.CpPx) = 5
	'    SSSMAIN_SBANYUKN_BeginPrg = True
	'End Function
	'Function SSSMAIN_SBAFRNKN_BeginPrg(PP As clsPP, CP_SBAFRNKN As clsCP)
	'    AE_BackColor(5) = &H8000000F  '�w�i�F�F�O���[
	'    CL_SSSMAIN(CP_SBAFRNKN.CpPx) = 5
	'    SSSMAIN_SBAFRNKN_BeginPrg = True
	'End Function
End Module