Option Strict Off
Option Explicit On
Module URKFP51_M61
	'
	' �X���b�g��        : FB�f�[�^�捞ܰ��X�V�E���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : URKFP51.M61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/09/28
	' �g�p�v���O������  : URKFP51
	'
	Const lngItemMax As Integer = 13
	
	Sub BATMAN()
		Dim rtn As Integer
		
		rtn = WRTTRN
		
		'�߂�l�ɂ�胁�b�Z�[�W��ύX
		If rtn = 0 Then
			'����I����
			rtn = DSP_MsgBox("0", "CSV_CONFIRM", 4) 'CSV�t�@�C�����捞�܂����B
		End If
	End Sub
	
	Function WRTTRN() As Short
		
		Dim RecCount As Integer
		Dim rt As Short
		Dim rtn As Short
		Dim WL_WinDir As String
		Dim wLength As Short
		Dim rtnPara As New VB6.FixedLengthString(128)
		Dim wkPATH As String
		Dim wkFILE As String
		Dim strPath As String
		'
		Dim fso As Object
		Dim wkFil As String
		Dim wkExt As String
		
		WRTTRN = 9 '�r���ŏ��������s�����9���Ԃ� 2006/12/26 FJCL)Saito
		
		RecCount = 0
		'
		On Error GoTo ERR_SYORI
		'
		'DELETE 2006/12/26 FJCL)Saito
		'    WL_WinDir = Environ$("WINDIR")
		'    If WL_WinDir = "" Then
		'        MsgBox "���ϐ� ""WINDIR"" ���擾�ł��܂���B"
		'        Call Error_Exit("���ϐ� ""WINDIR"" ���擾�ł��܂���B")
		'    End If
		
		'    strPath = Trim(LC_strPG_ID) & ".csv"
		'    strPath = WL_WinDir
		'    CommonDialog1.InitDir = SSS_INIDAT(3)   '�����\���f�B���N�g�����Z�b�g
		'        CommonDialog1.FileName = strPath        '�t�@�C�������f�t�H���g�Z�b�g
		'DELETE
		
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.FILEDLG.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FR_SSSMAIN.FILEDLG.FileName = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.FILEDLG.ShowOpen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FR_SSSMAIN.FILEDLG.ShowOpen() '�_�C�A���O���J��
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.FILEDLG.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strPath = FR_SSSMAIN.FILEDLG.FileName '�I�����ꂽ�t�@�C������ϐ��Ɋi�[
		
		'�_�C�A���O��ʂŃp�X���擾�ł��Ȃ������Ƃ��͏����I��
		If strPath = "" Then
			WRTTRN = 1
			Exit Function
		End If
		
		'DELETE 2006/12/26 FJCL)Saito
		'    If Right$(Trim$(WL_WinDir), 1) <> "\" Then
		'        WL_WinDir = WL_WinDir & "\"
		'    End If
		'
		'    wLength = GetPrivateProfileString("FBDATA", ByVal "IN_PATH", "", rtnPara, 128, ByVal WL_WinDir & "SSSWIN.INI")
		'    If wLength = 0 Then
		'        MsgBox "SSSWIN.INI ���m�F���Ă��������B" & Chr(13) & "[" & "IN_PATH" & "]"
		'        Call Error_Exit("SSSWIN.INI ���m�F���Ă��������B[" & "IN_PATH" & "]")
		'    Else
		'        wkPATH = Left$(rtnPara, wLength)
		'    End If
		'
		'    If Right$(Trim$(wkPATH), 1) <> "\" Then
		'        wkPATH = wkPATH & "\"
		'    End If
		'
		'    wLength = GetPrivateProfileString("FBDATA", ByVal "IN_FILE", "", rtnPara, 128, ByVal WL_WinDir & "SSSWIN.INI")
		'    If wLength = 0 Then
		'        MsgBox "SSSWIN.INI ���m�F���Ă��������B" & Chr(13) & "[" & "IN_FILE" & "]"
		'        Call Error_Exit("SSSWIN.INI ���m�F���Ă��������B[" & "IN_FILE" & "]")
		'    Else
		'        wkFILE = Left$(rtnPara, wLength)
		'    End If
		'
		'DELETE 2006/12/26 FJCL)Saito
		
		'    wkFILE = wkPATH & wkFILE
		'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.FILEDLG.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wkFILE = FR_SSSMAIN.FILEDLG.FileName
		'
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'
		'''' ADD 2011/05/19  FKS) T.Yamamoto    Start    ���������o�^�Ή�
		'�`�F�b�N������ꍇ�́A�폜�������s��
		If FR_SSSMAIN.HD_ALLDEL.CheckState = 1 Then
			'''' ADD 2011/05/19  FKS) T.Yamamoto    End
			If DEL_FBDATA() = 9 Then '2006.11.06
				GoTo ERR_SYORI '2006.11.06
			End If '2006.11.06
			'''' ADD 2011/05/19  FKS) T.Yamamoto    Start    ���������o�^�Ή�
		End If
		'''' ADD 2011/05/19  FKS) T.Yamamoto    End
		
		'2006.11.06 �Œ蒷�b�r�u����ϒ��b�r�u�ɕύX
		If GET_FBDATA(wkFILE, RecCount) = 9 Then
			GoTo ERR_SYORI
		End If
		
		If RecCount = 0 Then
			rtn = MsgBox("�Y���f�[�^�͂���܂���B", CDbl(MsgBoxStyle.OKOnly & MB_ICONEXCLAMATION), SSS_PrgNm)
			'
			Call DB_AbortTransaction()
			WRTTRN = 8
		Else
			fso = CreateObject("Scripting.FileSystemObject")
			'
			'�x���f�[�^�̃t�@�C�����擾(�g���q�Ȃ��̖���)
			'UPGRADE_WARNING: �I�u�W�F�N�g fso.GetBaseName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkFil = fso.GetBaseName(wkFILE)
			'
			'�x���f�[�^�̊g���q�擾
			'UPGRADE_WARNING: �I�u�W�F�N�g fso.GetExtensionName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkExt = "." & fso.GetExtensionName(wkFILE)
			'
			'�t�@�C�����̕ύX(�����f�B���N�g�����ɕʖ��ňړ�����΁A���O��ύX�������ƂɂȂ�)
			'UPGRADE_WARNING: �I�u�W�F�N�g fso.MoveFile �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call fso.MoveFile(wkFILE, wkPATH & "�捞��_" & VB6.Format(Now, "YYYYMMDD") & wkFil & wkExt)
			'
			Call DB_EndTransaction()
			WRTTRN = 0
		End If
		
		Exit Function
		'
ERR_SYORI: 
		rt = DSP_MsgBox("0", "CSV_CONFIRM", 3)
		'    rt = MsgBox("�t�@�C���̒��o�Ɏ��s���܂����B", MB_OK + MB_ICONSTOP, Trim$(SSS_PrgNm))
		Call DB_AbortTransaction()
		'
	End Function
	
	Private Function DEL_FBDATA() As Short
		
		Dim strSQL As String
		
		DEL_FBDATA = 9
		
		'// �� UPD 2008-12-26 RISE)Morita
		''''    strSql = ""
		''''    strSql = strSql & "Delete From FBTRA"
		''''    strSql = strSql & " Where DATKB = '9'"
		strSQL = ""
		strSQL = strSQL & " DELETE "
		strSQL = strSQL & " FROM FBTRA"
		'''' DEL 2011/05/19  FKS) T.Yamamoto    Start    ���������o�^�Ή�
		'    If FR_SSSMAIN.HD_ALLDEL.Value = 1 Then
		'        '�`�F�b�N������ꍇ�́A�S�폜
		'    Else
		'        strSql = strSql & " WHERE DATKB = '9'"
		'    End If
		'''' DEL 2011/05/19  FKS) T.Yamamoto    End
		'// �� UPD 2008-12-26 RISE)Morita
		
		Call DB_Execute(DBN_FBTRA, strSQL)
		If DBSTAT = 0 Then
			DEL_FBDATA = 0
		End If
		
	End Function
	
	'�ő��FBRFNO�̔ԍ����擾����֐� Add 2006/12/26 FJCL)Saito
	Private Function GET_FBRFNO() As String
		Dim strSQL As String
		
		GET_FBRFNO = ""
		
		strSQL = ""
		strSQL = strSQL & "SELECT MAX(FBRFNO) From FBTRA"
		
		Call DB_GetSQL2(DBN_FBTRA, strSQL)
		'SQL���s�ɐ����������̏���
		If DBSTAT = 0 Then
			GET_FBRFNO = CStr(DB_ExtNum.ExtNum(0))
		End If
		
	End Function
	
	'''' ADD 2011/05/19  FKS) T.Yamamoto    Start    ���������o�^�Ή�
	'''' UPD 2011/09/02  FKS) T.Yamamoto    Start    �A���[��FC11090201
	''''' UPD 2011/07/20  FKS) T.Yamamoto    Start    �A���[��FC11072001
	''Private Function CNT_FBTRA(ByVal strFBRFNO As String) As Integer
	'Private Function CNT_FBTRA(ByVal strFBRFNO As String, ByVal strFBBNKCD As String) As Integer
	''''' UPD 2011/07/20  FKS) T.Yamamoto    End
	Private Function CNT_FBTRA(ByVal strFBRFNO As String, ByVal strFBCLTCD As String, ByVal strFBBNKCD As String) As Short
		'''' UPD 2011/09/02  FKS) T.Yamamoto    End
		Dim strSQL As String
		
		CNT_FBTRA = 0
		
		'''' UPD 2011/11/15  FKS) T.Yamamoto    Start    �A���[��FC11111501
		''''' UPD 2011/09/02  FKS) T.Yamamoto    Start    �A���[��FC11090201
		'''''' UPD 2011/07/20  FKS) T.Yamamoto    Start    �A���[��FC11072001
		'''    strSql = "SELECT COUNT(FBRFNO) FROM FBTRA WHERE FBRFNO = " & strFBRFNO
		''    strSql = "SELECT COUNT(FBRFNO) FROM FBTRA WHERE FBRFNO = " & strFBRFNO & " AND FBBNKCD = " & strFBBNKCD
		'''''' UPD 2011/07/20  FKS) T.Yamamoto    End
		'    strSql = "SELECT COUNT(FBRFNO) FROM FBTRA WHERE FBRFNO = " & strFBRFNO & " AND FBCLTCD = " & strFBCLTCD & " AND FBBNKCD = " & strFBBNKCD
		''''' UPD 2011/09/02  FKS) T.Yamamoto    End
		strSQL = "SELECT COUNT(FBRFNO) FROM FBTRA WHERE FBRFNO = '" & strFBRFNO & "' AND FBCLTCD = '" & strFBCLTCD & "' AND FBBNKCD = '" & strFBBNKCD & "'"
		'''' UPD 2011/11/15  FKS) T.Yamamoto    End
		
		Call DB_GetSQL2(DBN_FBTRA, strSQL)
		
		If DBSTAT = 0 Then
			CNT_FBTRA = DB_ExtNum.ExtNum(0)
		End If
		
	End Function
	'''' ADD 2011/05/19  FKS) T.Yamamoto    End
	
	Private Function GET_FBDATA(ByVal strFullPath As String, ByRef lngRecCount As Integer) As Short
		Dim Fno As Integer
		Dim strDATA As String
		Dim strAry(lngItemMax) As String
		Dim lngPos As Integer
		Dim i As Integer
		Dim lngStart As Integer
		'''' DEL 2011/05/19  FKS) T.Yamamoto    Start    ���������o�^�Ή�
		'    Dim strSeqno                        As String
		'''' DEL 2011/05/19  FKS) T.Yamamoto    End
		
		GET_FBDATA = 9
		
		lngRecCount = 0
		
		Fno = FreeFile
		
		FileOpen(Fno, strFullPath, OpenMode.Input)
		
		'''' DEL 2011/05/19  FKS) T.Yamamoto    Start    ���������o�^�Ή�
		'    '�����A�Ԓl���Z�b�g 2006/12/26 FJCL)Saito
		'    strSeqno = Format(GET_FBRFNO + 1, "000000")
		'''' DEL 2011/05/19  FKS) T.Yamamoto    End
		
		Do While Not EOF(1)
			strDATA = LineInput(Fno)
			lngRecCount = lngRecCount + 1
			
			'�_�u���N�H�[�e�[�V�����̍폜 2006/12/26 FJCL)Saito
			strDATA = Replace(strDATA, """", "", 1, -1)
			
			'�z��N���A
			For i = 0 To UBound(strAry)
				strAry(i) = ""
			Next i
			
			'���R�[�h���J���}�ŕ������Ĕz��ɃZ�b�g
			lngStart = 1
			lngPos = InStr(lngStart, strDATA, ",")
			i = 0
			Do While lngPos <> 0
				strAry(i) = strAry(i) & Mid(strDATA, lngStart, lngPos - lngStart)
				'
				lngStart = lngPos + 1
				lngPos = InStr(lngStart, strDATA, ",")
				i = i + 1
			Loop 
			
			'FB�����t�@�C���̃��R�[�h��ރ`�F�b�N
			Select Case strAry(0)
				Case "1" '�w�b�_
					DB_URKFP51A.FBDATKB = strAry(0) 'As String * 1     '�f�[�^�敪
					DB_URKFP51A.FBSBTCD = strAry(1) 'As String * 2     '��ʃR�[�h
					DB_URKFP51A.FBCODKB = strAry(2) 'As String * 1     '�R�[�h�敪
					DB_URKFP51A.FBMAKDT = strAry(3) 'As String * 6     '�쐬��
					DB_URKFP51A.FBKJSDT = strAry(4) 'As String * 6     '������i���j
					DB_URKFP51A.FBKJEDT = strAry(5) 'As String * 6     '������i���j
					DB_URKFP51A.FBGINCD = strAry(6) 'As String * 4     '��s�R�[�h
					DB_URKFP51A.FBGINNM = strAry(7) 'As String * 15    '��s��
					DB_URKFP51A.FBSTNCD = strAry(8) 'As String * 3     '�x�X�R�[�h
					DB_URKFP51A.FBSTNNM = strAry(9) 'As String * 15    '�x�X��
					DB_URKFP51A.FBYKNKB = strAry(10) 'As String * 1     '�a�����
					DB_URKFP51A.FBKOZNO = strAry(11) 'As String * 7     '�����ԍ�
					DB_URKFP51A.FBKOZNM = strAry(12) 'As String * 40    '������
					DB_URKFP51A.FBDMYELA = strAry(13) 'As String * 93    '�_�~�[A
				Case "2" '�f�[�^
					'�f�[�^A���f�[�^B�̔��肪�ł��Ȃ�������K�v�ȕ����ɂ͊֌W�Ȃ��̂Ńf�[�^A�̃��C�A�E�g�Ƃ���
					DB_URKFP51B.FBDATKB = strAry(0) 'As String * 1     '�f�[�^�敪
					'''' UPD 2011/05/19  FKS) T.Yamamoto    Start    ���������o�^�Ή�
					'�Ɖ�ԍ��̃Z�b�g��߂�
					'                '�Ɖ�ԍ��̃Z�b�g���@��A�ԂɕύX 2006/12/26 FJCL)Saito
					''               DB_URKFP51B.FBRFNO = strAry(1)          'As String * 6     '�Ɖ�ԍ�
					'                DB_URKFP51B.FBRFNO = strSeqno
					'                strSeqno = Format(strSeqno + 1, "000000")
					DB_URKFP51B.FBRFNO = strAry(1) 'As String * 6     '�Ɖ�ԍ�
					'''' UPD 2011/05/19  FKS) T.Yamamoto    End
					DB_URKFP51B.FBKJNDT = strAry(2) 'As String * 6     '�����
					DB_URKFP51B.FBKSNDT = strAry(3) 'As String * 6     '�N�Z��
					DB_URKFP51B.FBNYKEL = strAry(4) 'As String * 10    '���z
					DB_URKFP51B.FBTTKEL = strAry(5) 'As String * 10    '�������X�����z
					DB_URKFP51B.FBCLTCD = strAry(6) 'As String * 10    '�U���˗��l�R�[�h
					DB_URKFP51B.FBCLTNM = strAry(7) 'As String * 48    '�U���˗��l��
					DB_URKFP51B.FBSMGNM = strAry(8) 'As String * 15    '�d����s��
					DB_URKFP51B.FBSMSNM = strAry(9) 'As String * 15    '�d���x�X��
					DB_URKFP51B.FBDELKB = strAry(10) 'As String * 1     '����敪
					DB_URKFP51B.FBEDIEL = strAry(11) 'As String * 20    '�d�c�h���
					DB_URKFP51B.FBDMYELB = strAry(12) 'As String * 52    '�_�~�[B
				Case "8" '�g���[��
					'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
					DB_URKFP51D = LSet(DB_URKFP51)
					DB_URKFP51D.FBDATKB = strAry(0) 'As String * 1     '�f�[�^�敪
					DB_URKFP51D.FBFGSEL = strAry(1) 'As String * 6     '�U�����v����
					DB_URKFP51D.FBFGKEL = strAry(2) 'As String * 12    '�U�����v���z
					DB_URKFP51D.FBTGSEL = strAry(3) 'As String * 6     '������v����
					DB_URKFP51D.FBTGKEL = strAry(4) 'As String * 12    '������v���z
					DB_URKFP51D.FBDMYELD = strAry(5) 'As String * 163   '�_�~�[D
				Case "9" '�G���h
					'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
					DB_URKFP51E = LSet(DB_URKFP51)
					DB_URKFP51E.FBDATKB = strAry(0) 'As String * 1     '�f�[�^�敪
					DB_URKFP51E.FBDMYELE = strAry(1) 'As String * 199   '�_�~�[E
				Case Else '���̑�
			End Select
			
			If strAry(0) = "2" Then
				DB_FBTRA.DATKB = "1"
				'
				Call FBTRA_FromURKFP51A() '�������ڂ�IRT�ŃZ�b�g(�A�����t�̍��ڂƋ�s�͒P���]���ł��Ȃ��̂ŕʓ]���Ƃ���)
				Call FBTRA_FromURKFP51B() '�������ڂ�IRT�ŃZ�b�g(�A�����t�̍��ڂƋ��z�͒P���]���ł��Ȃ��̂ŕʓ]���Ƃ���)
				
				'���t���ڂ͕ϊ����K�v
				'2019/04/02 UPD START <C2-20190123-01> CIS)�R��
				'If Trim$(DB_URKFP51B.FBKJNDT) <> "" Then DB_FBTRA.FBKJDT = CStr(Val(DB_URKFP51B.FBKJNDT) + 19880000):
				'If Trim$(DB_URKFP51B.FBKSNDT) <> "" Then DB_FBTRA.FBKSDT = CStr(Val(DB_URKFP51B.FBKSNDT) + 19880000):
				'If Trim$(DB_URKFP51A.FBMAKDT) <> "" Then DB_FBTRA.FBSSDT = CStr(Val(DB_URKFP51A.FBMAKDT) + 19880000):
				'If Trim$(DB_URKFP51A.FBKJSDT) <> "" Then DB_FBTRA.FBKJJDT = CStr(Val(DB_URKFP51A.FBKJSDT) + 19880000):
				'If Trim$(DB_URKFP51A.FBKJEDT) <> "" Then DB_FBTRA.FBKJIDT = CStr(Val(DB_URKFP51A.FBKJEDT) + 19880000):
				If Trim(DB_URKFP51B.FBKJNDT) <> "" Then DB_FBTRA.FBKJDT = CStr(Val(DB_URKFP51B.FBKJNDT) + 20180000)
				If Trim(DB_URKFP51B.FBKSNDT) <> "" Then DB_FBTRA.FBKSDT = CStr(Val(DB_URKFP51B.FBKSNDT) + 20180000)
				If Trim(DB_URKFP51A.FBMAKDT) <> "" Then DB_FBTRA.FBSSDT = CStr(Val(DB_URKFP51A.FBMAKDT) + 20180000)
				If Trim(DB_URKFP51A.FBKJSDT) <> "" Then DB_FBTRA.FBKJJDT = CStr(Val(DB_URKFP51A.FBKJSDT) + 20180000)
				If Trim(DB_URKFP51A.FBKJEDT) <> "" Then DB_FBTRA.FBKJIDT = CStr(Val(DB_URKFP51A.FBKJEDT) + 20180000)
				'2019/04/02 UPD END <C2-20190123-01> CIS)�R��
				
				'�����ԍ��ҏW               '2006.11.06
				DB_FBTRA.FBKOZNO = New String("0", Len(DB_URKFP51A.FBKOZNO) - Len(Trim(DB_URKFP51A.FBKOZNO))) & Trim(DB_URKFP51A.FBKOZNO)
				
				'��s�R�[�h�ҏW             '2006.11.06
				DB_FBTRA.FBBNKCD = New String("0", Len(DB_URKFP51A.FBGINCD) - Len(Trim(DB_URKFP51A.FBGINCD))) & Trim(DB_URKFP51A.FBGINCD) & New String("0", Len(DB_URKFP51A.FBSTNCD) - Len(Trim(DB_URKFP51A.FBSTNCD))) & Trim(DB_URKFP51A.FBSTNCD)
				
				'�����z�ҏW
				DB_FBTRA.FBNYUKN = CDec(Val(DB_URKFP51B.FBNYKEL))
				
				'�U���˗��l���ҏW 2006/12/26 FJCL)Saito
				DB_FBTRA.FBCLTNM = Trim(Replace(DB_FBTRA.FBCLTNM, Trim(DB_FBTRA.FBCLTCD), "", 1, -1))
				
				'�U���˗��l�R�[�h�ҏW       '2006.11.06
				DB_FBTRA.FBCLTCD = Right(DB_FBTRA.FBCLTCD, 7) & "   "
				'
				DB_FBTRA.WRTTM = VB6.Format(Now, "hhmmss") '2006.11.06
				DB_FBTRA.WRTDT = VB6.Format(Now, "YYYYMMDD") '2006.11.06
				DB_FBTRA.WRTFSTTM = VB6.Format(Now, "hhmmss") '2006.11.06
				DB_FBTRA.WRTFSTDT = VB6.Format(Now, "YYYYMMDD") '2006.11.06
				
				'''' UPD 2011/05/19  FKS) T.Yamamoto    Start    ���������o�^�Ή�
				'            Call DB_Insert(DBN_FBTRA, 1)
				'''' UPD 2011/09/02  FKS) T.Yamamoto    Start    �A���[��FC11090201
				''''' UPD 2011/07/20  FKS) T.Yamamoto    Start    �A���[��FC11072001
				''��s�A�Ɖ�ԍ����L�[�Ƃ���悤�ύX
				''          If CNT_FBTRA(DB_FBTRA.FBRFNO) = 0 Then
				'          If CNT_FBTRA(DB_FBTRA.FBRFNO, DB_FBTRA.FBBNKCD) = 0 Then
				''''' UPD 2011/07/20  FKS) T.Yamamoto    End
				'��s�A�����A�Ɖ�ԍ����L�[�Ƃ���悤�ύX
				If CNT_FBTRA(DB_FBTRA.FBRFNO, DB_FBTRA.FBCLTCD, DB_FBTRA.FBBNKCD) = 0 Then
					'''' UPD 2011/09/02  FKS) T.Yamamoto    End
					Call DB_Insert(DBN_FBTRA, 1)
				End If
				'''' UPD 2011/05/19  FKS) T.Yamamoto    End
			End If
		Loop 
		
		FileClose(Fno)
		
		GET_FBDATA = 0
		
	End Function
End Module