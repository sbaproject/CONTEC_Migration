Option Strict Off
Option Explicit On
Module TEKIDT_F51
	'
	' �X���b�g��        : �P���ݒ���t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : TEKIDT.FM1
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/28
	' �g�p�v���O������  : RATMT51
	'
	
	Function TEKIDT_Check(ByVal TUKKB As Object, ByVal TEKIDT As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		Dim wkTUKKB As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TEKIDT_Check = 0
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(TEKIDT) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂�
			'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			TEKIDT_Check = -1
			'Call TUKMTA_RClear
			
		Else
			If Not IsDate(TEKIDT) Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂�
				'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				TEKIDT_Check = -1
				'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				TEKIDT = ""
			Else
				'�ŐV�f�[�^��������
				'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If TEKIDT_Check = 0 Then
                    '                If CLng(Format(TEKIDT, "YYYYMMDD")) < CLng(DB_UNYMTA.UNYDT) Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B                    
                    '2019/10/14 CHG START
                    'Call DB_GetGrEq(DBN_TUKMTA, 2, "1" & TUKKB & VB6.Format(TEKIDT, "YYYYMMDD"), BtrNormal)
                    GetRowsCommon(DBN_TUKMTA, "WHERE DATKB = '1' AND TUKKB = '" & TUKKB & "' AND TEKIDT = '" & VB6.Format(TEKIDT, "YYYYMMDD") & "'")
                    '2019/10/14 CHG END
                    'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If (DBSTAT = 0) And (DB_TUKMTA.DATKB = "1") And (DB_TUKMTA.TUKKB = TUKKB) And (DB_TUKMTA.TEKIDT > VB6.Format(TEKIDT, "YYYYMMDD")) Then
						Rtn = DSP_MsgBox(SSS_CONFRM, "RATMT51", 0) '���ɐV�������t�œo�^�ς̈׃G���[
						'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						TEKIDT_Check = -1
					End If
					'                End If
				End If
			End If
		End If
		
		'�K�p���Ƀf�[�^����������A���Y�f�[�^������
		'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If TEKIDT_Check = 0 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/14 CHG START
            'Call DB_GetEq(DBN_TUKMTA, 1, TUKKB & VB6.Format(TEKIDT, "YYYYMMDD"), BtrNormal)
            GetRowsCommon(DBN_TUKMTA, "WHERE DATKB = '1' AND TUKKB = '" & TUKKB & "' AND TEKIDT = '" & VB6.Format(TEKIDT, "YYYYMMDD") & "'")
            '2019/10/14 CHG END
            If DBSTAT = 0 Then
				Call SCR_FromMfil(De_Index)
				If DB_TUKMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(De_Index, "�폜")
				Else
					Call DP_SSSMAIN_UPDKB(De_Index, "�X�V")
				End If
				'20081002 ADD START RISE)Tanimura '�r������
				' [����De_Index�͉�ʏ�̍s��(0�`)]
				M_RATMT_A_inf(De_Index).OPEID = DB_TUKMTA.OPEID ' �ŏI��Ǝ҃R�[�h
				M_RATMT_A_inf(De_Index).CLTID = DB_TUKMTA.CLTID ' �N���C�A���g�h�c
				M_RATMT_A_inf(De_Index).WRTTM = DB_TUKMTA.WRTTM ' �^�C���X�^���v�i���ԁj
				M_RATMT_A_inf(De_Index).WRTDT = DB_TUKMTA.WRTDT ' �^�C���X�^���v�i���t�j
				M_RATMT_A_inf(De_Index).UOPEID = DB_TUKMTA.UOPEID ' ���[�UID�i�o�b�`�j
				M_RATMT_A_inf(De_Index).UCLTID = DB_TUKMTA.UCLTID ' �N���C�A���gID�i�o�b�`�j
				M_RATMT_A_inf(De_Index).UWRTTM = DB_TUKMTA.UWRTTM ' �^�C���X�^���v�i�o�b�`���ԁj
				M_RATMT_A_inf(De_Index).UWRTDT = DB_TUKMTA.UWRTDT ' �^�C���X�^���v�i�o�b�`���j
				'20081002 ADD END   RISE)Tanimura
			Else
				Call DP_SSSMAIN_UPDKB(De_Index, "�ǉ�")
				'20081002 ADD START RISE)Tanimura '�r������
				Call RATMT51_MF_Clear_UWRTDTTM(De_Index)
				'20081002 ADD END   RISE)Tanimura
			End If
			
		End If
	End Function
	
	Function TEKIDT_DerivedC(ByVal TUKKB As Object, ByVal TEKIDT As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		
		'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TEKIDT_DerivedC = TEKIDT
        'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(TUKKB) = "" Then
            '2019/09/24 DEL START
            'Call TUKMTA_RClear()
            '2019/09/24 DEL E N D
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Select Case Trim(TEKIDT)
				Case ""
					'TEKIDT_DerivedC = Date           '�{���̓��t�B
					'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					TEKIDT_DerivedC = DB_UNYMTA.UNYDT '�^�p���t
				Case Else
					'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(TEKIDT) <> "" Then
						'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						TEKIDT_DerivedC = TEKIDT
					Else
						'TEKIDT_DerivedC = Date
						'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						TEKIDT_DerivedC = DB_UNYMTA.UNYDT '�^�p���t
					End If
			End Select
			
		End If
	End Function
	
	Function TEKIDT_InitVal(ByVal TEKIDT As Object, ByVal TUKKB As Object, ByVal De_Index As Short) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g TUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(TUKKB) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			TEKIDT_InitVal = " "
			Exit Function
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(TEKIDT) = "" Then
				'TEKIDT_InitVal = Date
				'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				TEKIDT_InitVal = DB_UNYMTA.UNYDT '�^�p���t
			End If
		End If
		
	End Function
	
	Function TEKIDT_Skip(ByRef CT_TEKIDT As System.Windows.Forms.Control, ByVal TEKIDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(TEKIDT) <> "" Then
            'UPGRADE_WARNING: �I�u�W�F�N�g CT_TEKIDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/09/24 CHG START
            'CT_TEKIDT.SelStart = 8 'yyyy-mm-dd �� dd �ɃJ�[�\�����ړ�����B
            DirectCast(CT_TEKIDT, TextBox).SelectionStart = 8 'yyyy-mm-dd �� dd �ɃJ�[�\�����ړ�����B
            '2019/09/24 CHG E N D
        End If
		'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TEKIDT_Skip = False
	End Function
	
	Function TEKIDT_Slist(ByVal TEKIDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = TEKIDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g TEKIDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TEKIDT_Slist = Set_date.Value
	End Function
End Module