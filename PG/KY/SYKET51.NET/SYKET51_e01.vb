Option Strict Off
Option Explicit On
Module SYKET51_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : SYKET51.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/07/16
	' �g�p�v���O������  : SYKET51
	'
	Public WG_WRKKB As String
	Public WG_FDNDT As String
	Public WG_SOUCD As String
	Public WG_TOKCD As String
	Public Const WG_DKBSB As String = "020"
	
	Function DSPTRN() As Object
		Dim I As Short
		Dim WL_JDNNO As String
		Dim WL_CASSU, WL_FRDSU As Decimal
		Dim rtn As Object
		
		I = 0
		WL_JDNNO = Trim(SSS_LASTKEY.Value) & Space(Len(DB_SYKTRA.JDNNO) - Len(Trim(SSS_LASTKEY.Value)))
		Call DB_GetGrEq(DBN_SYKTRA, 2, SSS_CLTID.Value & SSS_PrgId & "1" & SSS_LASTKEY.Value, BtrNormal)
		Do While (DBSTAT = 0) And (WL_JDNNO = DB_SYKTRA.JDNNO)
			If Trim(WG_SOUCD) <> "" And WG_SOUCD <> DB_SYKTRA.OUTSOUCD Then
			Else
				'''' UPD 2008/08/30  FKS) S.Nakajima    Start
				'            If Trim(WG_TOKCD) <> "" And WG_TOKCD <> DB_SYKTRA.TOKCD Then
				If Trim(WG_TOKCD) <> "" And Trim(WG_TOKCD) <> Trim(DB_SYKTRA.TOKCD) Then
					'''' UPD 2008/08/30  FKS) S.Nakajima    End
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYKTRA.FRDSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYKTRA.HIKSU) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If SSSVal(DB_SYKTRA.HIKSU) <= SSSVal(DB_SYKTRA.FRDSU) Then ' �o�׎w����
					Else
						''''''''            If CHK_KADOYMD(CNV_DATE(DB_SYKTRA.ODNYTDT)) = False Then    '�\�����ғ����ȍ~�͓��͂ł��܂���B
						''''''''            Else
						If WG_FDNDT < CNV_DATE(DB_SYKTRA.ODNYTDT) Then '�Ώۓ��ȊO
						Else
							Select Case WG_WRKKB
								Case "2"
									If DB_SYKTRA.WRKKB = "4" Then
										Call DSPTRN_Move(I)
									End If
								Case "3"
									If DB_SYKTRA.WRKKB = "6" Then
										Call DSPTRN_Move(I)
									End If
								Case "4"
									If DB_SYKTRA.WRKKB = "7" Then
										Call DSPTRN_Move(I)
									End If
								Case "5"
									If DB_SYKTRA.WRKKB = "8" Then
										Call DSPTRN_Move(I)
									End If
								Case "6"
									If DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Then
										Call DSPTRN_Move(I)
									End If
								Case Else
									''''''''''''''''''''''''''''''''If DB_SYKTRA.WRKKB = "1" Or DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Or DB_SYKTRA.WRKKB = "5" Then
									If DB_SYKTRA.WRKKB = "1" Or DB_SYKTRA.WRKKB = "5" Then
										Call DSPTRN_Move(I)
									End If
							End Select
						End If
						''''''''            End If
					End If
				End If
			End If
			Call DB_GetNext(DBN_SYKTRA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g DSPTRN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DSPTRN = I
		
	End Function
	
	Sub DSPTRN_Move(ByRef I As Short)
		
		Dim wkFRDSU As Short
		
		'''''    Call SCR_FromMfil(I)
		Call SCR_FromSYKTRA(I)
		
		'�q�ɃZ�b�g
		If I = 0 Then
            'Call SOUMTA_RClear()
            Call DB_GetEq(DBN_SOUMTA, 1, DB_SYKTRA.OUTSOUCD, BtrNormal)
			Call SCR_FromSOUMTA(I)
		End If
		
		'���[�敪�Z�b�g
		Select Case DB_SYKTRA.BKTHKKB
			Case "1"
				Call DP_SSSMAIN_BKTHKNM(I, "��")
			Case "9"
				Call DP_SSSMAIN_BKTHKNM(I, "�s��")
			Case Else
				Call DP_SSSMAIN_BKTHKNM(I, "")
		End Select
		
		'�o�ח\��c��/�o�׉\��/�o�׎w����
		wkFRDSU = DB_SYKTRA.HIKSU - DB_SYKTRA.FRDSU
		Call DP_SSSMAIN_FRDYZSU(I, wkFRDSU)
		Call DP_SSSMAIN_FRDKNSU(I, wkFRDSU)
		Call DP_SSSMAIN_FRDSU(I, wkFRDSU)

        '�o�ג�~���i
        'Call HINMTA_RClear()
        Call DB_GetEq(DBN_HINMTA, 1, DB_SYKTRA.HINCD, BtrNormal)
		
		If DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Or DB_SYKTRA.WRKKB = "5" Then
		Else
			If DB_HINMTA.ORTSTPKB = "9" And DB_HINMTA.ORTSTPDT <= DB_UNYMTA.UNYDT Then
				Call DP_SSSMAIN_FRDSU(I, 0)
			End If
			If DB_HINMTA.ORTSTPKB = "8" Then
				Call DP_SSSMAIN_FRDSU(I, 0)
			End If
			
		End If
		
		I = I + 1
	End Sub
	
	Sub INITDSP()
		Dim lngI As Integer
		Dim EXEPATH As String
		Dim I As Short
		
		'�w�i�F�̐ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(3) = 1 '�q�ɺ���
		CL_SSSMAIN(4) = 1 '�q�ɖ�
		CL_SSSMAIN(5) = 1 '���Ӑ溰��
		CL_SSSMAIN(6) = 1 '���Ӑ於
		CL_SSSMAIN(7) = 1 '���͒S���Һ���
		CL_SSSMAIN(8) = 1 '���͒S���Җ�
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			CL_SSSMAIN(10 + (lngI * 15)) = 1 '����
			CL_SSSMAIN(11 + (lngI * 15)) = 1 '�o�ח\���
			CL_SSSMAIN(12 + (lngI * 15)) = 1 '���i����
			CL_SSSMAIN(13 + (lngI * 15)) = 1 '�^��
			CL_SSSMAIN(14 + (lngI * 15)) = 1 '���[
			CL_SSSMAIN(15 + (lngI * 15)) = 1 '������
			CL_SSSMAIN(16 + (lngI * 15)) = 1 '�o�ח\��c��
			CL_SSSMAIN(17 + (lngI * 15)) = 1 '�o�׉\��
			CL_SSSMAIN(18 + (lngI * 15)) = 1 '�o�ɐ�
		Next 
		
		'�^�p���̎擾
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		
		'�o�ɗ\��t�@�C���̍폜
		''''Call DB_GetGrEq(DBN_SYKTRA, 3, SSS_CLTID & SSS_PrgId, BtrNormal)
		''''
		''''Do While (DBSTAT = 0) And (Trim$(DB_SYKTRA.CLTID) = Trim$(SSS_CLTID)) _
		'''''                      And (Trim$(DB_SYKTRA.PGID) = Trim$(SSS_PrgId))
		''''    Call DB_Delete(DBN_SYKTRA)
		''''    Call DB_GetNext(DBN_SYKTRA, BtrNormal)
		''''Loop
		
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "���N�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If
		
		'���s�����̎擾
		Call Get_Authority(DB_UNYMTA.UNYDT)
		
		'�o�ɗ\��t�@�C���쐬���s
		EXEPATH = AE_AppPath & "\SYKFP70.EXE /CLTID:" & SSS_CLTID.Value & " /PGID:" & SSS_PrgId & " /PGNM:" & SSS_PrgNm
		I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)
		
	End Sub
	
	Function INQ_UPDATE() As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g INQ_UPDATE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		INQ_UPDATE = -1
		
		'�����`�F�b�N
		If gs_UPDAUTH = "9" Then
			rtn = DSP_MsgBox(SSS_ERROR, "UPDAUTH", 0) '�X�V�����Ȃ�
			'UPGRADE_WARNING: �I�u�W�F�N�g INQ_UPDATE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			INQ_UPDATE = 0
			Exit Function
		End If
		
		'
		rtn = DELTRN()
		rtn = WRTTRN()
		
	End Function
End Module