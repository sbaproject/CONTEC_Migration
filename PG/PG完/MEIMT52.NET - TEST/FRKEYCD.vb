Option Strict Off
Option Explicit On
Module FRKEYCD_F51
	'
	'�X���b�g��      :���̃R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :FRKEYCD.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/07/12
	'�g�p�v���O����  :MEIMT51
	'
	
	Function FRKEYCD_InitVal(ByVal FRKEYCD As Object, ByRef PP As clsPP, ByRef CP_FRKEYCD As clsCP) As Object
		Dim Rtn As Short
		Dim I As Short
		'
		'FRKEYCD = DB_MEIMTB.KEYCD
		'
		If DB_MEIMTB.KEYCD = FR_SSSMAIN.HD_FRKEYCD.Text Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FRKEYCD_InitVal = FRKEYCD
		End If
		
	End Function
	
	Function FRKEYCD_CheckC(ByVal FRKEYCD As Object, ByVal Ex_FRKEYCD As Object) As Object
		Dim Rtn As Short
		Dim wkKey_set As String
        Dim I As Short
        '20190826 DEL START
        'Call MEIMTA_RClear()
        'Call MEIMTB_RClear()
        '20190826 DEL END

        'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        FRKEYCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(FRKEYCD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(Trim(FRKEYCD)) = 0 Then
			Call SCR_FromMEIMTB(-1)
			'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FRKEYCD_CheckC = -1
		Else
			'FRKEYCD = Format(FRKEYCD, "000")
			Call DB_GetEq(DBN_MEIMTB, 1, FRKEYCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					FRKEYCD_CheckC = 1
				Else
					'DB_MEIMTA�ւ̑�������
					'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wkKey_set = FRKEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB
					Call DB_GetEq(DBN_MEIMTA, 1, wkKey_set, BtrNormal)
					'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If DBSTAT = 0 And DB_MEIMTA.KEYCD = FRKEYCD Then
						'�R�[�h1�ƃR�[�h2�̃f�[�^�ő��݂̗L�����i�荞�ނ̂�
						'�����f�[�^���݂����ꍇ�\���iKEYCD��MEICDA��MEICDB�Ō���)
						If DB_MEIMTA.DATKB = "9" Then
							Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�폜")
						Else
							Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�X�V")
						End If
					Else
						'DB��Ɏw��L�[�̂��̂����݂��Ȃ��Ƃ�
						Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�ǉ�")
						'Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �Y�����R�[�h�͂���܂���B
						Call Dsp_Prompt("RNOTFOUND", 0) '�V�K���R�[�h�ł��B
						For I = 0 To PP_SSSMAIN.MaxDspC
							Call SCR_FromMEIMTB(-1)
							Call SCR_FromMfil(I)
							If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
						Next I
					End If
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				FRKEYCD_CheckC = -1
				For I = 0 To PP_SSSMAIN.MaxDspC
					Call SCR_FromMEIMTB(-1)
					Call SCR_FromMfil(I)
					If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
				Next I
			End If
		End If
		
		'    ' �����͂̏ꍇ�ɂ�, �G���[���������ɖ��̓����N���A����
		'    Call MEIMTA_RClear
		'    'Call FRKEYCD_Move(PP_SSSMAIN.De)�@'���͕̂ʕ��i�ŌĂяo���悤������
		'    wkKey_set = FRKEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB
		'    If LenWid(Trim$(FRKEYCD)) = 0 Then
		'      FRKEYCD_CheckC = -1
		'    Else
		'
		'        FRKEYCD = Format(FRKEYCD, "000")
		'
		'        Call DB_GetEq(DBN_MEIMTA, 1, wkKey_set, BtrNormal)
		'        If DBSTAT = 0 And DB_MEIMTA.KEYCD = FRKEYCD Then
		'        '�R�[�h1�ƃR�[�h2�̃f�[�^�ő��݂̗L�����i�荞�ނ̂�
		'        '�����f�[�^���݂����ꍇ�\���iKEYCD��MEICDA��MEICDB�Ō���)
		'              If DB_MEIMTA.DATKB = "9" Then
		'                 Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�폜")
		'              Else
		'                 Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�X�V")
		'              End If
		'        Else
		'            'DB��Ɏw��L�[�̂��̂����݂��Ȃ��Ƃ�
		'            Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�V�K")
		'            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �Y�����R�[�h�͂���܂���B
		'        End If
		'    End If
		
	End Function
	'Function FRKEYCD_Check(ByVal FRKEYCD, ByVal Ex_FRKEYCD)
	'Dim Rtn As Integer
	'Dim wkKey_set As String
	'Dim I As Integer
	'    Call MEIMTA_RClear
	'    'Call MEIMTB_RClear
	'    FRKEYCD_Check = 0
	'    If LenWid(Trim$(FRKEYCD)) = 0 Then
	'      Call SCR_FromMEIMTB(-1)
	'      FRKEYCD_Check = -1
	'    Else
	'      'FRKEYCD = Format(FRKEYCD, "000")
	'      Call DB_GetEq(DBN_MEIMTB, 1, FRKEYCD, BtrNormal)
	'        If DBSTAT = 0 Then
	'            If DB_MEIMTA.DATKB = "9" Then
	'               Call Dsp_Prompt("RNOTFOUND", 1)         ' �폜�σ��R�[�h�ł��B
	'               FRKEYCD_Check = 1
	'            Else
	'               'DB_MEIMTA�ւ̑�������
	'                wkKey_set = FRKEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB
	'                Call DB_GetEq(DBN_MEIMTA, 1, wkKey_set, BtrNormal)
	'                If DBSTAT = 0 And DB_MEIMTA.KEYCD = FRKEYCD Then
	'                '�R�[�h1�ƃR�[�h2�̃f�[�^�ő��݂̗L�����i�荞�ނ̂�
	'                '�����f�[�^���݂����ꍇ�\���iKEYCD��MEICDA��MEICDB�Ō���)
	'                      If DB_MEIMTA.DATKB = "9" Then
	'                         Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�폜")
	'                      Else
	'                         Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�X�V")
	'                      End If
	'                Else
	'                    'DB��Ɏw��L�[�̂��̂����݂��Ȃ��Ƃ�
	'                    Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "�V�K")
	'                    Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �Y�����R�[�h�͂���܂���B
	'
	'                    For I = 0 To PP_SSSMAIN.MaxDspC
	'                       Call SCR_FromMEIMTB(-1)
	'                       Call SCR_FromMfil(I)
	'                       If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
	'                    Next I
	'                End If
	'            End If
	'        Else
	'            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �V�K���R�[�h�ł��B
	'            FRKEYCD_Check = -1
	'            For I = 0 To PP_SSSMAIN.MaxDspC
	'            Call SCR_FromMEIMTB(-1)
	'            Call SCR_FromMfil(I)
	'            If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
	'            Next I
	'        End If
	'    End If
	'End Function
	
	Function FRKEYCD_Slist(ByRef PP As clsPP, ByVal FRKEYCD As Object) As Object
		'Dim strcd As String
		'    WLS_LIST.Caption = "���̈ꗗ"
		'    WLS_LIST!LST.Clear
		'    '
		'    WLS_LIST!LST.AddItem "001" & " " & "�ʉ� "
		'    WLS_LIST!LST.AddItem "002" & " " & "�֖� "
		'    WLS_LIST!LST.AddItem "003" & " " & "�Ǝ� "
		'    WLS_LIST!LST.AddItem "004" & " " & "�n�� "
		'    WLS_LIST!LST.AddItem "005" & " " & "���� "
		'    WLS_LIST!LST.AddItem "006" & " " & "�󒍎���敪 "
		'    WLS_LIST!LST.AddItem "007" & " " & "��������敪 "
		'    WLS_LIST!LST.AddItem "008" & " " & "�P����� "
		'    WLS_LIST!LST.AddItem "009" & " " & "�ԕi���R "
		'    WLS_LIST!LST.AddItem "010" & " " & "�ԕi��� "
		'    WLS_LIST!LST.AddItem "011" & " " & "�������R "
		'    WLS_LIST!LST.AddItem "012" & " " & "���Ϗ��󎚎x�����@ "
		'    WLS_LIST!LST.AddItem "013" & " " & "�L������ "
		'    WLS_LIST!LST.AddItem "014" & " " & "�d���n "
		'    WLS_LIST!LST.AddItem "015" & " " & "�ꏊ "
		'    WLS_LIST!LST.AddItem "016" & " " & "�󒍗��R "
		'    WLS_LIST!LST.AddItem "017" & " " & "�󒍷�ݾٗ��R "
		'    WLS_LIST!LST.AddItem "018" & " " & "�Đ����� "
		'    WLS_LIST!LST.AddItem "019" & " " & "���ԋ敪 "
		'    WLS_LIST!LST.AddItem "020" & " " & "�R���s���[�^�^�� "
		'    WLS_LIST!LST.AddItem "021" & " " & "��v���Ə� "
		'    WLS_LIST!LST.AddItem "022" & " " & "��v�敪 "
		'    WLS_LIST!LST.AddItem "023" & " " & "��v���� "
		'    WLS_LIST!LST.AddItem "024" & " " & "�����S�� "
		'    WLS_LIST!LST.AddItem "025" & " " & "���Y�S�� "
		'    WLS_LIST!LST.AddItem "026" & " " & "�q�ɋ敪 "
		'    WLS_LIST!LST.AddItem "027" & " " & "�����Ώۋ敪 "
		'    WLS_LIST!LST.AddItem "028" & " " & "���i��� "
		'    WLS_LIST!LST.AddItem "029" & " " & "�j���敪 "
		'    WLS_LIST!LST.AddItem "030" & " " & "�c�Ɠ��敪 "
		'    WLS_LIST!LST.AddItem "031" & " " & "�ێ�I���敪 "
		'    WLS_LIST!LST.AddItem "032" & " " & "�o�ג�~�敪 "
		'    WLS_LIST!LST.AddItem "033" & " " & "���Y�I���敪 "
		'    WLS_LIST!LST.AddItem "034" & " " & "�̔������敪 "
		'    WLS_LIST!LST.AddItem "035" & " " & "�󒍒�~�敪 "
		'    WLS_LIST!LST.AddItem "036" & " " & "�o�׋敪 "
		'
		'    '
		'    'FRKEYCD = Format(FRKEYCD, "000")
		'    'SSS_WLSLIST_KETA = LenWid(FRKEYCD)
		'    SSS_WLSLIST_KETA = 3
		'    WLS_LIST.Show 1
		'    Unload WLS_LIST
		'    FRKEYCD_Slist = PP.SlistCom
		
		WLS_MEI2.Text = "���̃L�[����"
		CType(WLS_MEI2.Controls("LST"), Object).Items.Clear()

        '20190827 CHG START
        'DB_PARA(DBN_MEIMTB).KeyNo = 1
        ''UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_PARA(DBN_MEIMTB).KeyBuf = FRKEYCD
        PP.SlistCom = System.DBNull.Value
        '20190827 CHG END

        WLS_MEI2.ShowDialog()
		WLS_MEI2.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FRKEYCD_Slist = PP.SlistCom
		
		'    WLS_MEI2.Caption = "���̃L�[����"
		'    WLS_MEI2!LST.Clear
		'    Call DB_GetFirst(DBN_MEIMTB, 1, BtrNormal)
		'    Do While DBSTAT = 0
		'        If DB_MEIMTA.DATKB <> "9" Then WLS_MEI2!LST.AddItem DB_MEIMTB.KEYCD & " " & Left(Trim(DB_MEIMTB.MEIKMKNM), 20)
		'        Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		'    Loop
		'    SSS_WLSLIST_KETA = CInt(LenWid(DB_MEIMTB.KEYCD))
		'    WLS_MEI2.Show 1
		'    Unload WLS_MEI2
		'    FRKEYCD_Slist = PP.SlistCom
		'
		
	End Function
	Sub FRKEYCD_Move(ByVal DE_INDEX As Object)
		'
		If Trim(DB_MEIMTA.KEYCD) = "" Then
		Else
			Call DP_SSSMAIN_FRKEYCD(PP_SSSMAIN.De, DB_MEIMTA.KEYCD)
			Call DP_SSSMAIN_MEIKMKNM(PP_SSSMAIN.De, DB_MEIMTA.MEIKMKNM)
		End If
	End Sub
End Module