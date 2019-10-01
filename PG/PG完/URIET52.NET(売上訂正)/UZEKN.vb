Option Strict Off
Option Explicit On
Module UZEKN_F52
	'
	' �X���b�g��        : ��������(�Ŕ�)�E��ʍ��ڃX���b�g
	' ���j�b�g��        : UZEKN.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/11/07
	' �g�p�v���O������  : URIET51
	'
	
	Function UZEKN_Derived(ByVal De_index As Object, ByVal URIKN As Object, ByVal UZEKN As Object, ByVal TOKCD As Object, ByVal HINCD As Object, ByVal HINID As Object, ByVal UDNDT As Object, ByRef CP_UZEKN As clsCP) As Object
		Dim WL_HINZEIKB, WL_TOKRPSKB, WL_TOKZEIKB, WL_TOKZCLKB, WL_TOKZRNKB, WL_ZEIRNKKB As Object
		Dim WL_UZEKN, WL_ZEIRT As Decimal
		
		'UPGRADE_WARNING: �I�u�W�F�N�g UZEKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UZEKN_Derived = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(URIKN) = "" Or URIKN = 0 Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKZEIKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WL_TOKZEIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_TOKZEIKB = RD_SSSMAIN_TOKZEIKB(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKZCLKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WL_TOKZCLKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_TOKZCLKB = RD_SSSMAIN_TOKZCLKB(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKRPSKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WL_TOKRPSKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_TOKRPSKB = RD_SSSMAIN_TOKRPSKB(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKZRNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WL_TOKZRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_TOKZRNKB = RD_SSSMAIN_TOKZRNKB(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g De_index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HINZEIKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WL_HINZEIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_HINZEIKB = RD_SSSMAIN_HINZEIKB(De_index)
		'UPGRADE_WARNING: �I�u�W�F�N�g De_index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZEIRNKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WL_ZEIRNKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(De_index)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UDNDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WRKDT(0) = RD_SSSMAIN_UDNDT(0)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(WL_TOKZEIKB) = 9 Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZCLKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(WL_TOKZCLKB) <> 1 Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_HINZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(WL_HINZEIKB) <> 0 And SSSVal(WL_HINZEIKB) <> 1 Then Exit Function
		'    If SSSVal(WL_TOKZEIKB) = 0 And SSSVal(WL_HINZEIKB) <> 1 Then Exit Function  '1996/11/13 Delete
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_HINZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(WL_HINZEIKB) = 0 And SSSVal(WL_TOKZEIKB) <> 1 Then Exit Function '1996/11/13 Insert
		
		'   ����v��ł�, ����ł̎���͂͌����Ƃ��ĔF�߂Ȃ�
		'   ��������͂��K�v�ȏꍇ�ͤ UZEKN.F01�̂悤�Ɏ��s��L���ɂ���
		'    if &UKBCD[CWK]=10 RETURN
		WL_UZEKN = 0
		
		'2014/01/09 START UPD RS)Ishida ����Ŗ@�����Ή�
		'����E�ԕi�n��ʂł́A�󒍂̐ŗ����g�p���邽�ߐŗ��̍Ď擾�͕K�v�Ȃ�
		
		'Call DB_GetLsEq(DBN_SYSTBB, 2, WL_ZEIRNKKB & SSS_WRKDT(0), BtrNormal)
		'If (DBSTAT <> 0) Or (DB_SYSTBB.ZEIRNKKB <> WL_ZEIRNKKB) Then Exit Function
		
		'WL_ZEIRT = DB_SYSTBB.ZEIRT
		'UPGRADE_WARNING: �I�u�W�F�N�g De_index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZEIRT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_ZEIRT = RD_SSSMAIN_ZEIRT(De_index)
		'2014/01/09 E.N.D UPD RS)Ishida ����Ŗ@�����Ή�
		
		'======================================================================
		'   ���Ӑ�̐ŋ敪�ƁA���i�̐ŋ敪�̑g�ݍ��킹�ɂ��A�Ŕ��E�ō���
		'   ������s���B
		'======================================================================
		
		'�y�ʔ́z�y�сy�V�X�e���ŏ������i�z���A�Z�o�������
		'UPGRADE_WARNING: �I�u�W�F�N�g HINID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
			'UPGRADE_WARNING: �I�u�W�F�N�g UZEKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UZEKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UZEKN_Derived = UZEKN
			Exit Function
		End If
		
		On Error GoTo OverFlow
		'''' UPD 2011/08/25  FKS) T.Yamamoto    Start    �A���[��FC11082501
		'    If SSSVal(WL_HINZEIKB) = 1 Then                               '���i�E�Ŕ���
		'        WL_UZEKN = URIKN * WL_ZEIRT / 100
		'    Else
		'        If SSSVal(WL_TOKZEIKB) = 1 Then                           '���Ӑ�E�Ŕ���
		'            WL_UZEKN = URIKN * WL_ZEIRT / 100
		'        End If
		'    End If
		'    WL_UZEKN = DCMFRC(WL_UZEKN, SSSVal(WL_TOKZRNKB), SSSVal(WL_TOKRPSKB) - 1)
		Dim WL_ZURIKN As Decimal
		Dim WL_ZUZEKN As Decimal
		Dim strSQL As String
		
		'����ϕ��̔�����z�A����Ŋz���擾
		strSQL = ""
		strSQL = strSQL & "SELECT SUM(URIKN)" & vbCrLf
		strSQL = strSQL & "     , SUM(UZEKN)" & vbCrLf
		strSQL = strSQL & "  FROM UDNTRA" & vbCrLf
		strSQL = strSQL & " WHERE DATKB = '1'" & vbCrLf
		strSQL = strSQL & "   AND (JDNNO,JDNLINNO) = " & vbCrLf
		strSQL = strSQL & "       (SELECT JDNNO,JDNLINNO" & vbCrLf
		strSQL = strSQL & "          FROM UDNTRA" & vbCrLf
		strSQL = strSQL & "         WHERE DATNO = '" & Left(SSS_LASTKEY.Value, 10) & "'" & vbCrLf
		strSQL = strSQL & "           AND LINNO = '" & Mid(SSS_LASTKEY.Value, 11, 3) & "')" & vbCrLf

        'change start 20190830 kuwa
        'Call DB_GetSQL2(DBN_UDNTRA, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190830 kuwa
        '�ԕi��̎c�蔄����z���Z�o
        'UPGRADE_WARNING: �I�u�W�F�N�g URIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190830 kuwa �v�m�F
        'WL_ZURIKN = DB_ExtNum.ExtNum(0) - URIKN
        WL_ZURIKN = dt.Rows(0)("SUM(URIKN)") - URIKN
        'change end 20190830 kuwa

        '�ԕi��̎c�蔄����z�ɑ΂������Ŋz���Z�o
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_HINZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If SSSVal(WL_HINZEIKB) = 1 Then '���i�E�Ŕ���
			WL_ZUZEKN = WL_ZURIKN * WL_ZEIRT / 100
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(WL_TOKZEIKB) = 1 Then '���Ӑ�E�Ŕ���
				WL_ZUZEKN = WL_ZURIKN * WL_ZEIRT / 100
			End If
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKRPSKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_ZUZEKN = DCMFRC(WL_ZUZEKN, SSSVal(WL_TOKZRNKB), SSSVal(WL_TOKRPSKB) - 1)
		WL_UZEKN = DB_ExtNum.ExtNum(1) - WL_ZUZEKN
		'''' UPD 2011/08/25  FKS) T.Yamamoto    End
		'UPGRADE_WARNING: �I�u�W�F�N�g UZEKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UZEKN_Derived = WL_UZEKN
		Exit Function
OverFlow: 
		CP_UZEKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: �I�u�W�F�N�g UZEKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UZEKN_Derived = "??????????????????"
	End Function
End Module