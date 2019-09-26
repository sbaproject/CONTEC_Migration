Option Strict Off
Option Explicit On
Module NHSMTA_M81
	'
	' �X���b�g��        : �[�i��}�X�^�E���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : NHSMTA.M81
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : NHSMR01
	'
	
	' === 20080916 === INSERT S - RISE)Izumi
	Structure TYPE_HAITA_NHSMTA
		Dim NHSCD As String '�[����R�[�h
		Dim WRTTM As String '��ѽ����(����)
		Dim WRTDT As String '��ѽ����(���t)
		Dim UWRTTM As String '��ѽ����(����)
		Dim UWRTDT As String '��ѽ����(���t)
		Dim OPEID As String '�ŏI��Ǝ҃R�[�h
		Dim CLTID As String '�N���C�A���g�h�c
		Dim UOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim UCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
	End Structure
	Public HAITA_NHSMTA As TYPE_HAITA_NHSMTA
	' === 20080916 === INSERT E - RISE)Izumi
	
	Function DelMst() As Short
		Dim wkWRTTM, keyVal, wkWRTDT As String
		' === 20080916 === INSERT S - RISE)Izumi
		Dim intRtn As Short
		' === 20080916 === INSERT E - RISE)Izumi
		
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		
		' === 20080916 === DELETE S - RISE)Izumi
		''2007/12/11 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    Dim bolRet      As Boolean
		'    Dim intRet      As Integer
		''2007/12/11 add-end T.KAWAMUKAI
		''2007/12/13 add-str M.SUEZAWA �e�v���O�����̃��W���[���ŏ�������悤�ɕύX
		'    Dim strWRTDT        As String       '�X�V���t
		'    Dim strWRTTM        As String       '�X�V����
		'    Dim strUWRTDT       As String       '�o�b�`�X�V���t
		'    Dim strUWRTTM       As String       '�o�b�`�X�V����
		''2007/12/13 add-end M.SUEZAWA
		' === 20080916 === DELETE E - RISE)Izumi
		
		'�X�V�����`�F�b�N
		If gs_UPDAUTH = "9" Then
			Call MsgBox("�X�V����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Function
		End If
		
		' === 20080916 === DELETE S - RISE)Izumi
		''2007/12/13 add-str M.SUEZAWA �e�v���O�����̃��W���[���ŏ�������悤�ɕύX
		'    '�X�V���Ԏ擾
		'    Call PF_Get_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
		''2007/12/13 add-end M.SUEZAWA
		'
		''2007/12/11 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    '�X�V���ԃ`�F�b�N
		''2007/12/13 upd-str M.SUEZAWA �e�v���O�����̃��W���[���ŏ�������悤�ɕύX
		''''    bolRet = MF_Chk_UWRTDTTM()
		'    bolRet = MF_Chk_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
		''2007/12/13 upd-end M.SUEZAWA
		'    If bolRet = False Then
		'        intRet = MF_DspMsg(gc_strMsgNHSMR52_E_DEL)
		'        Exit Function
		'    End If
		''2007/12/11 add-end T.KAWAMUKAI
		' === 20080916 === DELETE E - RISE)Izumi
		
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_NHSCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		keyVal = RD_SSSMAIN_NHSCD(0)
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetEq(DBN_NHSMTA, 1, keyVal, BtrLock)
		' === 20080916 === DELETE S - RISE)Izumi
		'    Call Mfil_FromSCR(0)
		' === 20080916 === DELETE E - RISE)Izumi
		If DBSTAT = 0 Then
			' === 20080916 === INSERT S - RISE)Izumi
			'�r���X�V�����`�F�b�N
			If Val(HAITA_NHSMTA.OPEID) <> Val(DB_NHSMTA.OPEID) Or Val(HAITA_NHSMTA.CLTID) <> Val(DB_NHSMTA.CLTID) Or Val(HAITA_NHSMTA.WRTDT) <> Val(DB_NHSMTA.WRTDT) Or Val(HAITA_NHSMTA.WRTTM) <> Val(DB_NHSMTA.WRTTM) Or Val(HAITA_NHSMTA.UOPEID) <> Val(DB_NHSMTA.UOPEID) Or Val(HAITA_NHSMTA.UCLTID) <> Val(DB_NHSMTA.UCLTID) Or Val(HAITA_NHSMTA.UWRTDT) <> Val(DB_NHSMTA.UWRTDT) Or Val(HAITA_NHSMTA.UWRTTM) <> Val(DB_NHSMTA.UWRTTM) Then
				
				Call DB_AbortTransaction()
				intRtn = MF_DspMsg(gc_strMsgNHSMR52_E_DEL) ' ���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
				Exit Function
			End If
			Call Mfil_FromSCR(0)
			' === 20080916 === INSERT E - RISE)Izumi
			DB_NHSMTA.DATKB = "9"
			DB_NHSMTA.RELFL = "1"
			DB_NHSMTA.WRTTM = wkWRTTM 'Format(Now, "hhmmss")
			DB_NHSMTA.WRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
			DB_NHSMTA.UOPEID = SSS_OPEID.Value
			DB_NHSMTA.UCLTID = SSS_CLTID.Value
			DB_NHSMTA.UWRTTM = wkWRTTM 'Format(Now, "hhmmss")
			DB_NHSMTA.UWRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
			DB_NHSMTA.PGID = SSS_PrgId
			
			Call DB_Update(DBN_NHSMTA, 1)
		End If
		DelMst = 9 ' �ǉ����[�h�ւ̈ڍs
		Call DB_EndTransaction()
	End Function
	
	Function UpdMst() As Short
		Dim wkWRTTM, keyVal, wkWRTDT As String
		' === 20080916 === INSERT S - RISE)Izumi
		Dim intRtn As Short
		' === 20080916 === INSERT E - RISE)Izumi
		
		' === 20080916 === DELETE S - RISE)Izumi
		''2007/12/11 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    Dim bolRet      As Boolean
		'    Dim intRet      As Integer
		''2007/12/11 add-end T.KAWAMUKAI
		''2007/12/13 add-str M.SUEZAWA �e�v���O�����̃��W���[���ŏ�������悤�ɕύX
		'    Dim strWRTDT        As String       '�X�V���t
		'    Dim strWRTTM        As String       '�X�V����
		'    Dim strUWRTDT       As String       '�o�b�`�X�V���t
		'    Dim strUWRTTM       As String       '�o�b�`�X�V����
		''2007/12/13 add-end M.SUEZAWA
		' === 20080916 === DELETE E - RISE)Izumi
		
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		
		
		'�X�V�����`�F�b�N
		If gs_UPDAUTH = "9" Then
			Call MsgBox("�X�V����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Function
		End If
		
		' === 20080916 === DELETE S - RISE)Izumi
		''2007/12/13 add-str M.SUEZAWA �e�v���O�����̃��W���[���ŏ�������悤�ɕύX
		'    '�X�V���Ԏ擾
		'    Call PF_Get_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
		''2007/12/13 add-end M.SUEZAWA
		'
		''2007/12/11 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'    '�X�V���ԃ`�F�b�N
		''2007/12/13 upd-str M.SUEZAWA �e�v���O�����̃��W���[���ŏ�������悤�ɕύX
		''''    bolRet = MF_Chk_UWRTDTTM()
		'    bolRet = MF_Chk_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
		''2007/12/13 upd-end M.SUEZAWA
		'    If bolRet = False Then
		'        intRet = MF_DspMsg(gc_strMsgNHSMR52_E_UPD)
		'        Exit Function
		'    End If
		''2007/12/11 add-end T.KAWAMUKAI
		' === 20080916 === DELETE E - RISE)Izumi
		
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_NHSCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		keyVal = RD_SSSMAIN_NHSCD(0)
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetEq(DBN_NHSMTA, 1, keyVal, BtrLock)
        If DBSTAT = 0 Then
            If DB_NHSMTA.DATKB <> "9" Then
                ' === 20080916 === INSERT S - RISE)Izumi
                '�r���X�V�����`�F�b�N
                If Val(HAITA_NHSMTA.OPEID) <> Val(DB_NHSMTA.OPEID) Or Val(HAITA_NHSMTA.CLTID) <> Val(DB_NHSMTA.CLTID) Or Val(HAITA_NHSMTA.WRTDT) <> Val(DB_NHSMTA.WRTDT) Or Val(HAITA_NHSMTA.WRTTM) <> Val(DB_NHSMTA.WRTTM) Or Val(HAITA_NHSMTA.UOPEID) <> Val(DB_NHSMTA.UOPEID) Or Val(HAITA_NHSMTA.UCLTID) <> Val(DB_NHSMTA.UCLTID) Or Val(HAITA_NHSMTA.UWRTDT) <> Val(DB_NHSMTA.UWRTDT) Or Val(HAITA_NHSMTA.UWRTTM) <> Val(DB_NHSMTA.UWRTTM) Then

                    Call DB_AbortTransaction()
                    intRtn = MF_DspMsg(gc_strMsgNHSMR52_E_UPD) ' ���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
                    Exit Function
                End If
                ' === 20080916 === INSERT E - RISE)Izumi
                Call Mfil_FromSCR(0)
                Call NHSMTA_FromSYSTBF()
                DB_NHSMTA.RELFL = "1"
                DB_NHSMTA.WRTTM = wkWRTTM ' Format(Now, "hhmmss")
                DB_NHSMTA.WRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
                DB_NHSMTA.UOPEID = SSS_OPEID.Value
                DB_NHSMTA.UCLTID = SSS_CLTID.Value
                DB_NHSMTA.UWRTTM = wkWRTTM ' Format(Now, "hhmmss")
                DB_NHSMTA.UWRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
                DB_NHSMTA.PGID = SSS_PrgId

            End If
            Call DB_Update(DBN_NHSMTA, 1)
        Else
            '2019/09/26 DEL START
            'Call NHSMTA_RClear()
            '2019/09/26 DEL END
            Call Mfil_FromSCR(0)
			Call NHSMTA_FromSYSTBF()
			DB_NHSMTA.NHSMSTKB = SSS_MSTKB.Value
			DB_NHSMTA.DATKB = "1"
			DB_NHSMTA.RELFL = "1"
			DB_NHSMTA.FOPEID = SSS_OPEID.Value
			DB_NHSMTA.FCLTID = SSS_CLTID.Value
			DB_NHSMTA.WRTFSTTM = wkWRTTM ' Format(Now, "hhmmss")
			DB_NHSMTA.WRTFSTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
			DB_NHSMTA.WRTTM = wkWRTTM 'Format(Now, "hhmmss")
			DB_NHSMTA.WRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
			DB_NHSMTA.UOPEID = SSS_OPEID.Value
			DB_NHSMTA.UCLTID = SSS_CLTID.Value
			DB_NHSMTA.UWRTTM = wkWRTTM 'Format(Now, "hhmmss")
			DB_NHSMTA.UWRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
			DB_NHSMTA.PGID = SSS_PrgId
			
			Call DB_Insert(DBN_NHSMTA, 1)
		End If
		UpdMst = 9 ' �ǉ����[�h�ւ̈ڍs
		Call DB_EndTransaction()
	End Function
End Module