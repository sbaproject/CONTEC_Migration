Option Strict Off
Option Explicit On
Module SYKFP51_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : SYKFP51.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/20
	' �g�p�v���O������  : SYKFP51
	'
	Public WG_WRKFSTDT As String
	Public WG_WRKFSTTM As String
	
	Sub INITDSP()
		
		Dim lngI As Integer
		Dim EXEPATH As String
		Dim I As Short
		Dim rtn As Short
		Dim strSQL As String
		
		
		'�w�i�F�̐ݒ�
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(2) = 1
		CL_SSSMAIN(3) = 1
		CL_SSSMAIN(4) = 1
		CL_SSSMAIN(5) = 1
		CL_SSSMAIN(6) = 1
		
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		
		'�o�ɗ\��t�@�C���̍폜
		''''Call DB_GetGrEq(DBN_SYKTRA, 3, SSS_CLTID & SSS_PrgId, BtrNormal)
		''''Do While (DBSTAT = 0) And (Trim$(DB_SYKTRA.CLTID) = Trim$(SSS_CLTID)) _
		'''''                      And (Trim$(DB_SYKTRA.PGID) = Trim$(SSS_PrgId))
		''''    Call DB_Delete(DBN_SYKTRA)
		''''    Call DB_GetNext(DBN_SYKTRA, BtrNormal)
		''''Loop
		
		'���s�����̎擾
		Call Get_Authority(DB_UNYMTA.UNYDT)
		
		'�����`�F�b�N
		If gs_UPDAUTH = "9" Then
			rtn = DSP_MsgBox(SSS_ERROR, "UPDAUTH", 0) '�X�V�����Ȃ�
			End
		End If
		
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("�y" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "���N�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If


        '�o�ɗ\��t�@�C���쐬���s

        EXEPATH = AE_AppPath & "\SYKFP70.EXE /CLTID:" & SSS_CLTID.Value & " /PGID:" & SSS_PrgId & " /PGNM:" & SSS_PrgNm
        '2019/10/03 ��
        'I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)

        '      strSQL = ""
        'strSQL = strSQL & "SELECT MAX(WRTFSTDT || WRTFSTTM) FROM FDNTHA"
        'strSQL = strSQL & "  WHERE PGID = 'SYKFP51'"
        'Call DB_GetSQL2(DBN_FDNTHA, strSQL)

        'WG_WRTFSTDT = Left(CStr(DB_ExtNum.ExtNum(0)), 8)
        'WG_WRTFSTTM = Mid(CStr(DB_ExtNum.ExtNum(0)), 9, 6)
        '2019/10/03 ��

    End Sub
End Module