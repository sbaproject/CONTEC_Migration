Option Strict Off
Option Explicit On
Module URIKJNNM_F51
	'
	' �X���b�g��        : �������́E��ʍ��ڃX���b�g
	' ���j�b�g��        : URIKJNNM.F51
	' �L�q��            :
	' �쐬���t          : 2006/09/22
	' �g�p�v���O������  : URIET52
	
	'''' ADD 2010/07/02  FKS) T.Yamamoto    Start    �A���[��FC10070201
	Structure M_TYPE_EVTTBL_PARA
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public IVWRDT() As Char ' �C�x���g������
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public IVWRTM() As Char ' �C�x���g��������
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public PGID() As Char ' �v���O�����h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char ' �N���C�A���g�h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public IVCLASS() As Char ' �C�x���g���
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public IVCODE() As Char ' �C�x���g�R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public IVPOINT() As Char ' �C�x���g�����ӏ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SNDPROFLG() As Char ' ���M�ۃt���O
		Dim IVMSG As String ' �C�x���g���e
	End Structure
	Private M_EVTTBL_PARA As M_TYPE_EVTTBL_PARA
	'''' ADD 2010/07/02  FKS) T.Yamamoto    End
	
	Function URIKJNNM_Derived(ByVal URIKJN As Object) As Object
		Dim Rtn As Short
		Dim KEY_CODE As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKJN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Dim strSQL As String
		Dim strExePath As String
		If Trim(URIKJN) <> "" Then
			'''' ADD 2010/07/02  FKS) T.Yamamoto    Start    �A���[��FC10070201
			
			strSQL = ""
			strSQL = strSQL & "SELECT DISTINCT 1 FROM SYSTBH" & vbCrLf
			strSQL = strSQL & " WHERE EXISTS (" & vbCrLf
			strSQL = strSQL & "               SELECT C_JYUCYU_NO" & vbCrLf
			strSQL = strSQL & "                 FROM JDN_SHINKO" & vbCrLf
			strSQL = strSQL & "                WHERE C_FAC_CD = 'CONTEC'" & vbCrLf
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNNO() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "                  AND C_JYUCYU_NO = TRIM('" & RD_SSSMAIN_JDNNO(-1) & "')" & vbCrLf
			strSQL = strSQL & "                  AND  C_SHINKO_CLS = '1'" & vbCrLf
			strSQL = strSQL & "              )" & vbCrLf
			Call DB_GetSQL4(DBN_SYSTBH, strSQL)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g URIKJNNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				URIKJNNM_Derived = "�i�s�"
			Else
				'EOF, NULL�ȊO
				If Not (DBSTAT = 1403 Or DBSTAT = 1405) Then
					'�C�x���g�e�[�u���փ��b�Z�[�W����������
					With M_EVTTBL_PARA
						.IVWRDT = VB6.Format(Now, "YYYYMMDD") ' �C�x���g������
						.IVWRTM = VB6.Format(Now, "HHMMSS") ' �C�x���g��������
						.PGID = SSS_PrgId ' �v���O�����h�c
						.CLTID = SSS_CLTID.Value ' �N���C�A���g�h�c
						.IVCLASS = "ERR" ' �C�x���g���
						.IVCODE = "0" ' �C�x���g�R�[�h
						.IVPOINT = "URIKJNNM_Derived" ' �C�x���g�����ӏ�
						.SNDPROFLG = "1" ' ���M�ۃt���O
						.IVMSG = "OraError=[JDN_SHINKO:" & DBSTAT & "]" ' �C�x���g���e
						
						strExePath = SSS_INIDAT(2) & "EXE\EVTLG01.EXE " & Chr(34) & .IVWRDT & .IVWRTM & .PGID & .CLTID & .IVCLASS & .IVCODE & .IVPOINT & .SNDPROFLG & .IVMSG & Chr(34)
					End With
					Call Shell(strExePath)
				End If
                '''' ADD 2010/07/02  FKS) T.Yamamoto    End
                '''
                '20190627 DELL START
                'Call MEIMTA_RClear()
                '20190726 DELL END
                'UPGRADE_WARNING: �I�u�W�F�N�g URIKJN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                KEY_CODE = VB6.Format(URIKJN, "00")
				Call DB_GetEq(DBN_MEIMTA, 1, "005" & KEY_CODE & " ", BtrNormal)
				If DBSTAT <> 0 Then
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
					'UPGRADE_WARNING: �I�u�W�F�N�g URIKJNNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					URIKJNNM_Derived = ""
					Exit Function
				End If
				Call SCR_FromMEIMTA_URIKJN(0)
				'''' ADD 2010/07/02  FKS) T.Yamamoto    Start    �A���[��FC10070201
			End If
			'''' ADD 2010/07/02  FKS) T.Yamamoto    End
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g URIKJNNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URIKJNNM_Derived = ""
		End If
		
		'
		'    If Trim$(URIKJN) <> "" Then
		'        Select Case Trim$(URIKJN)
		'            Case "1"
		'                URIKJNNM_Derived = "�o�׊"
		'            Case "2"
		'                URIKJNNM_Derived = "�����"
		'            Case "3"
		'                URIKJNNM_Derived = "�𖱊����"
		'            Case "4"
		'                URIKJNNM_Derived = "�H�������"
		'        End Select
		'    Else
		'        URIKJNNM_Derived = ""
		'    End If
	End Function
	
	Sub SCR_FromMEIMTA_URIKJN(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_URIKJN(De, Trim(DB_MEIMTA.MEICDA))
		Call DP_SSSMAIN_URIKJNNM(De, Trim(DB_MEIMTA.MEINMA))
	End Sub
End Module