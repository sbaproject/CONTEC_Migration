Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSUDN
	Inherits System.Windows.Forms.Form
	
	' 2008/07/02 ADD START FKS)NAKATA
	'XX �X�V���t :   2008/7/02
	'XX �X�V���R :   ���X�|���X�Ή�
	'XX �X�V���e
	'XX �@�u*�󒍎��v���T�u��ʂɂđI�������ꍇ�A�������������Ȃ�
	'XX �A�������ʂ��O���̏ꍇ�̓��b�Z�[�W��\��������
	'XX
	'XX �{���X�|���X�Ή��ł̓R�����g�A�E�g�� �u 'XX �v�ɂĕ\�L����B
	' 2008/07/02 ADD E.N.D FKS)NAKATA
	
	' 2008/07/03 ADD START FKS)NAKATA
	'XX �X�V���t :  2008/7/03
	'XX �X�V���R :   ���X�|���X�Ή�
	'XX �X�V���e
	'XX �@��ʕ\���u*�󒍎��v(COM_JDNTRKB)���u�󒍎��v�ɕύX
	'XX �A�������ʐ���\��������(100���ȏ�̏ꍇ)
	'XX �B���͕K�{���ڂ��u�󒍎��+�q�撍���ԍ��v�u�󒍔ԍ��v�ɐݒ肷��
	'XX �C�K�{���ڂ̓��͂��Ȃ��ꍇ�̓��b�Z�[�W��\��������
	' 2008/07/03 ADD E.N.D FKS)NAKATA
	
	
	'2008/07/05 ADD START FKS)NAKATA
	'XX ��ʕ\���L�^�p
	Private Structure TYPE_LSTBOX_EXC
		Dim LSTNO As String '���X�g�{�b�N�X�ԍ�
		Dim JDNNO As String '�󒍇�
		Dim UDNDT As String '�����
	End Structure
	Private WK_LSTBOX_BEF() As TYPE_LSTBOX_EXC
	
	Dim WM_WLS_LIST_END As Boolean '�ŏI�y�[�W�t���O
	
	Dim WM_WLS_PAGE_END As Short '�ŏI�y�[�W�ԍ�
	Dim WM_WLS_LIST_CNT As Short '�ŏI���X�g�ԍ�
	Dim WM_WLS_PAGE_CLICK_NUM As Short '�y�[�W����{�^���N���b�N��
	
	'2008/07/05 ADD E.N.D FKS)NAKATA
	
	
	
	'�ȉ��̂S�s�̐ݒ���s������
	Const WM_WLS_MSTKB As String = "1" '�}�X�^�敪(1:���Ӑ� 2:�[�i�� 3:�S���� 4:�d���� 5:���i)
	Const WM_WLSKEY_ZOKUSEI As String = "0" '�J�n�R�[�h���͑��� [0,X]
	
	'�����L�[No�i�g�p���Ȃ��ꍇ��-1��ݒ�j
	Const WM_WLS_TextKey As Short = 10 '�J�n�R�[�h�̃\�[�g�L�[No
	Const WM_WLS_CDKey As Short = -1 '�J�i�����̃\�[�g�L�[No+���L�[
	
	'�E�B���hհ�ް�ݒ�ϐ�
	Dim WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
	Dim WM_WLS_SFIL1 As Short '�E�B���h�\�����̧��
	Dim WM_WLS_SFIL2 As Short '�E�B���h�\�����̧��
	Dim WM_WLS_SFIL3 As Short '�E�B���h�\�����̧��
	
	Dim WM_WLS_LEN As Short '�J�n���ޓ��͕�����
	
	'�E�B���h�����g�p�ϐ�
	Dim WM_WLS_MAX As Short '�P��ʂ̕\������
	Dim WM_WLS_STTKEY As Object '�J�n�L�[
	Dim WM_WLS_ENDKEY As Object '�I���L�[
	Dim WM_WLS_KeyCode As Short '�����ޯ���\���p
	Dim WM_WLS_KeyNo As Short 'Ҳ�̧�ٓǂݍ��݃L�[No
	Dim WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Dim WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	Dim WM_WLS_INIT As Short '�E�B���h�����\���׸�(True or False)
	
	Dim WlsSelList As String
	Dim SWlsSelList As Object
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	
	Private pv_blnChange_Flg As Boolean
	
	Private DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07
	
	'20090115 ADD START RISE)Tanimura '�A���[No.523
	Private mJDNTRKB As String ' �󒍎��
	Private mJDNNO As String ' �󒍔ԍ�
	Private mTOKJDNNO As String ' �q�撍���ԍ�
	'20090115 ADD END   RISE)Tanimura
	
	Private Sub COM_JDNTRKB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_JDNTRKB.Click
		Dim wkJDNTRKB As String
		Dim strSQL As String
		
		WLS_MEI1.Text = "�󒍎���敪�ꗗ"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		
		Call DB_GetGrEq(DBN_MEIMTA, 3, "006", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "006"
			If DB_MEIMTA.DATKB <> "9" Then
				CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
		WLS_MEI1.ShowDialog()
		WLS_MEI1.Close()
		
		'2008/07/02 ADD START FKS)NAKATA
		'XX �󒍎���敪�ꗗ�T�u��ʂɂċ敪���I�����ꂽ���A�������������Ȃ����ߒǉ�
		WLSJDNTRKB.Text = ""
		WLSJDNTRNM.Text = ""
		'2008/07/02 ADD E.N.D FKS)NAKATA
		
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			WLSJDNTRKB.Text = ""
			WLSJDNTRNM.Text = ""
			Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '���͋敪���Ⴂ�܂��B
			Call P_SetFocus(WLSJDNTRKB)
			WLSJDNTRKB.SelectionStart = 0
			WLSJDNTRKB.SelectionLength = Len(WLSJDNTRKB.Text)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkJDNTRKB = LeftWid(PP_SSSMAIN.SlistCom, 2) & Space(Len(DB_MEIMTA.MEICDA) - Len(LeftWid(PP_SSSMAIN.SlistCom, 2)))
			Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
			If DBSTAT = 0 Then
				WLSJDNTRKB.Text = VB.Left(DB_MEIMTA.MEICDA, 2)
				WLSJDNTRNM.Text = DB_MEIMTA.MEINMA
				
				'2008/07/02 DEL START FKS)NAKATA
				'XX �󒍎���敪�ꗗ�T�u��ʂɂċ敪���I�����ꂽ���A�������������Ȃ����ߏ���
				
				'XX '            WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
				'XX '            WM_WLS_ENDKEY = "9"
				'XX            WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
				'XX            WM_WLS_ENDKEY = "1" & "9"
				'XX            WM_WLS_KeyCode = 0
				'XX            WM_WLS_Dspflg = True
				'XX            WM_WLS_Pagecnt = -1
				'XX            DoEvents
				'XX '''            strSQL = ""
				'XX '''            strSQL = strSQL & " SELECT * FROM ( "
				'XX '''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B "
				'XX '''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'XX '''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'XX '''            strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || A.WRTFSTTM = B.DT "
				'XX '''            strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
				'XX '''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
				'XX '''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'XX '''
				'XX '''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'XX '''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
				'XX            Call WLS_BaseSQL(WM_WLS_STTKEY)
				'XX            If WLSSSS_SET_KEYBAK() = True Then
				'XX                Call WLSSSS_DSP
				'XX            End If
				'XX            PP_SSSMAIN.SlistCom = Null
				'2008/07/02 DEL E.N.D FKS)NAKATA
			Else
				Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '���͋敪���Ⴂ�܂��B
				Call P_SetFocus(WLSJDNTRKB)
				WLSJDNTRKB.SelectionStart = 0
				WLSJDNTRKB.SelectionLength = Len(WLSJDNTRKB.Text)
			End If
		End If
		
	End Sub
	
	Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		
		DB_PARA(DBN_TOKMTA).KeyBuf = WLSTOKCD.Text
		WLSTOK.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
		''98/09/25 �ǉ�
		WLSTOK.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			DB_TOKMTA.TOKCD = ""
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_TOKMTA, 1, VB.Left(PP_SSSMAIN.SlistCom, 5), BtrNormal)
			If DBSTAT = 0 Then
				WLSTOKCD.Text = RTrim(DB_TOKMTA.TOKCD)
				WM_WLS_KeyCode = -1
				WM_WLS_Dspflg = False
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_Pagecnt = -1
				
				'2008/07/04 DEL START FKS)NAKATA
				'XX �T�u��ʂɂđI�΂ꂽ�ꍇ�A�������s���Ȃ��悤�ɂ���B
				'XX            W_Key = "1" & "1" & HD_TEXT.Text
				'XX            DoEvents
				'XX'''            strSQL = ""
				'XX'''            strSQL = strSQL & " SELECT * FROM ( "
				'XX'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
				'XX'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'XX'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'XX'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
				'XX'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'XX'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'XX            Call WLS_BaseSQL(W_Key)
				'XX'''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
				'XX            If WLSSSS_SET_KEYBAK() = True Then
				'XX                WM_WLS_INIT = 1
				'XX                Call WLSSSS_DSP
				'XX            End If
				'2008/07/04 DEL E.N.D FKS)NAKATA
				
			End If
		End If
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
	
	Private Sub COM_NHSCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_NHSCD.Click
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		
		DB_PARA(DBN_NHSMTA).KeyBuf = WLSNHSCD.Text
		WLSNHS.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
		''98/09/25 �ǉ�
		WLSNHS.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			DB_NHSMTA.NHSCD = ""
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_NHSMTA, 1, VB.Left(PP_SSSMAIN.SlistCom, 9), BtrNormal)
			If DBSTAT = 0 Then
				WLSNHSCD.Text = DB_NHSMTA.NHSCD
				WM_WLS_KeyCode = -1
				WM_WLS_Dspflg = False
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_Pagecnt = -1
				
				'2008/07/05 DEL START FKS)NAKATA
				'XX �{�^���������ꂽ�ꍇ�A�������ɍs���Ȃ�
				'XX            W_Key = "1" & "1" & HD_TEXT.Text
				'XX            DoEvents
				'XX'''            strSQL = ""
				'XX'''            strSQL = strSQL & " SELECT * FROM ( "
				'XX'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B "
				'XX'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'XX'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'XX'''            strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || A.WRTFSTTM = B.DT "
				'XX'''            strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
				'XX'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
				'XX'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'XX'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'XX            Call WLS_BaseSQL(W_Key)
				'XX'''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
				'XX            If WLSSSS_SET_KEYBAK() = True Then
				'XX                WM_WLS_INIT = 1
				'XX                Call WLSSSS_DSP
				'XX            End If
				'2008/07/05 DEL E.N.D FKS)NAKATA
			End If
		End If
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
	
	Private Sub COM_UDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_UDNDT.Click
		Dim I As Short
		Dim strSQL As String
		
		Set_date.Value = CNV_DATE(DB_UNYMTA.UNYDT)
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		System.Windows.Forms.Application.DoEvents()
		
		WLSUDNDT.Text = Set_date.Value
		'    WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
		'    WM_WLS_ENDKEY = "9"
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_ENDKEY = "1" & "9"
		WM_WLS_KeyCode = 0
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		System.Windows.Forms.Application.DoEvents()
		'''    strSQL = ""
		'''    strSQL = strSQL & " SELECT * FROM ( "
		'''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
		'''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
		'''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
		'''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
		'''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
		'''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
		'''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
		
		'2008/07/05 DEL START FKS)NAKATA
		'XX ���t���I������Ď��ɑ������ɂ����Ȃ��悤����
		'XX    Call WLS_BaseSQL(WM_WLS_STTKEY)
		'XX    If WLSSSS_SET_KEYBAK() = True Then
		'XX        Call WLSSSS_DSP
		'XX    End If
		'2008/07/05 DEL E.ND FKS)NAKATA
		
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
		
	End Sub
	
	'UPGRADE_WARNING: Form �C�x���g WLSUDN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSUDN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Call WLSSSS_FORM_ACTIVATE()
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = False
	End Sub
	
	Private Sub WLSUDN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Call WLS_FORM_LOAD()
		Call WLSSSS_FORM_INIT()
		pv_blnChange_Flg = False
	End Sub
	'
	
	'UPGRADE_WARNING: �C�x���g HD_TEXT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_TEXT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.TextChanged
		Dim s As Integer
		s = HD_TEXT.SelectionStart
		HD_TEXT.Text = StrConv(HD_TEXT.Text, VbStrConv.UpperCase)
		HD_TEXT.SelectionStart = s
	End Sub
	
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		''    If LenWid(HD_TEXT.Text) > 0 Then
		''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
		''    Else
		''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
		''    End If
		HD_TEXT.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_TEXT.SelectionLength = HD_TEXT.Maxlength
	End Sub
	
	Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Object
		Dim STAT As Short
		Dim strSQL As String
		
		Select Case KEYCODE
			Case 13
				WM_WLS_Dspflg = False
				'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
				HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
				HD_TEXT.SelectionStart = 0
				'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
				HD_TEXT.SelectionLength = HD_TEXT.Maxlength
				'            WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
				'            WM_WLS_ENDKEY = "9"
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WM_WLS_ENDKEY = "1" & "9"
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_KeyNo = WM_WLS_TextKey
				'''            strSQL = ""
				'''            strSQL = strSQL & " SELECT * FROM ( "
				'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
				'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
				'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call WLS_BaseSQL(WM_WLS_STTKEY)
				
				KEYBAK.Items.Clear()
				LST.Items.Clear()
				LST1.Items.Clear()
				WM_WLS_Pagecnt = -1
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If WLSSSS_SET_KEYBAK() = True Then
					Call WLSSSS_DSP()
				End If
				
				
				'        Case 40  '���L�[
				'            LST.ListIndex = 0
				'            LST.SetFocus
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
	End Sub
	
	Private Sub HD_TOKJDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.Enter
		HD_TOKJDNNO.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		HD_TOKJDNNO.SelectionLength = LenWid(HD_TOKJDNNO.Text)
	End Sub
	
	Private Sub HD_TOKJDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKJDNNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			Call WLS_BaseSQL(W_Key)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			WM_WLS_INIT = 1
			Call WLSSSS_DSP()
		End If
	End Sub
	
	''Private Sub HD_TOKJDNNO_LostFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 �폜
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	'''''''    If LST.ListCount > 0 Then
	'''''''        LST.ListIndex = 0
	'''''''    Else
	'''''''        WLSTOKCD.SetFocus
	'''''''    End If
	''
	''End Sub
	
	Private Sub WLSJDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSJDNTRKB.Enter
		''    If LenWid(WLSJDNTRKB.Text) > 0 Then
		''        WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_UDNTHA.JDNTRKB), "0")
		''    Else
		''        WLSJDNTRKB.Text = Space$(LenWid(DB_UDNTHA.JDNTRKB))
		''    End If
		WLSJDNTRKB.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSJDNTRKB.SelectionLength = LenWid(DB_UDNTHA.JDNTRKB)
		
	End Sub
	
	Private Sub WLSJDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSJDNTRKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Object
		Dim STAT As Short
		Dim wkJDNTRKB As String
		Dim strSQL As String
		
		Select Case KEYCODE
			Case 13
				WM_WLS_Dspflg = False
				KEYBAK.Items.Clear()
				LST.Items.Clear()
				LST1.Items.Clear()
				WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_UDNTHA.JDNTRKB), "0")
				WLSJDNTRKB.SelectionStart = 0
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLSJDNTRKB.SelectionLength = LenWid(DB_UDNTHA.JDNTRKB)
				If Trim(WLSJDNTRKB.Text) = "" Then
					Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '���͋敪���Ⴂ�܂��B
					Call P_SetFocus(WLSJDNTRKB)
					WLSJDNTRKB.SelectionStart = 0
					WLSJDNTRKB.SelectionLength = Len(WLSJDNTRKB.Text)
					'2008/07/02 ADD START FKS)NAKATA
					'XX �󒍎���敪���u�����N�̏ꍇ�A�\���������B
					WLSJDNTRNM.Text = ""
					'2008/07/02 ADD E.N.D FKS)NAKATA
				Else
					wkJDNTRKB = WLSJDNTRKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSJDNTRKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
					Call DB_GetEq(DBN_MEIMTA, 1, "006" & wkJDNTRKB, BtrNormal)
					If DBSTAT = 0 Then
						WLSJDNTRKB.Text = VB.Left(DB_MEIMTA.MEICDA, 2)
						WLSJDNTRNM.Text = DB_MEIMTA.MEINMA
						'                    WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
						'                    WM_WLS_ENDKEY = "9"
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_ENDKEY = "1" & "9"
						WM_WLS_KeyCode = 0
						WM_WLS_Dspflg = True
						WM_WLS_Pagecnt = -1
						'''                    strSQL = ""
						'''                    strSQL = strSQL & " SELECT * FROM ( "
						'''                    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
						'''                    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
						'''                    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
						'''                    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
						'''                    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
						'''                    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
						'''                    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call WLS_BaseSQL(WM_WLS_STTKEY)
						'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If WLSSSS_SET_KEYBAK() = True Then
							Call WLSSSS_DSP()
						End If
					Else
						Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '���͋敪���Ⴂ�܂��B
						Call P_SetFocus(WLSJDNTRKB)
						WLSJDNTRKB.SelectionStart = 0
						WLSJDNTRKB.SelectionLength = Len(WLSJDNTRKB.Text)
						
					End If
				End If
				'        Case 40  '���L�[
				'            LST.ListIndex = 0
				'            LST.SetFocus
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = True
		
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KEYCODE
			Case 13
				Call WLS_SLIST_MOVE(VB6.GetItemString(LST1, LST.SelectedIndex), WM_WLS_LEN)
				'DblClick�C�x���g��Q�Ή�  97/04/07
				'Call WLSCANCEL_CLICK
				If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case 27
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case 37 '���L�[
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
				'       Case 38  '���L�[
				'           If LST.ListIndex = 0 Then
				'               LST.ListIndex = -1
				'               HD_TEXT.SetFocus
				'           End If
			Case 39 '���L�[
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
			Case 112 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F��P�L�[
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
		
	End Sub
	
	Private Sub WLS_DISPLAY()
		'====================================
		'   WINDOW ���ו\��
		'====================================
		Dim WK_JDNNO As New VB6.FixedLengthString(8)
		Dim WK_DENDT As New VB6.FixedLengthString(10)
		Dim WK_UDNDT As New VB6.FixedLengthString(10)
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		' ����ς̏ꍇ
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			WK_JDNNO.Value = VB.Left(DB_UDNTRA.JDNNO, 6) & Mid(DB_UDNTRA.JDNLINNO, 2, 2)
			WK_UDNDT.Value = VB.Left(DB_UDNTRA.UDNDT, 4) & "/" & Mid(DB_UDNTRA.UDNDT, 5, 2) & "/" & VB.Right(DB_UDNTRA.UDNDT, 2)
			
			WlsFromWhere = "From TOKMTA Where TOKCD = '" & DB_UDNTRA.TOKCD & "'"
			WlsOrderBy = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL1, DB_SQLBUFF)
			
			Call NHSMTA_RClear()
			WlsFromWhere = "From NHSMTA Where NHSCD = '" & DB_UDNTRA.NHSCD & "'"
			WlsOrderBy = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL2, DB_SQLBUFF)
			
			Call JDNTRA_RClear()
			WlsFromWhere = "From JDNTRA     Where DATKB = '1'"
			WlsFromWhere = WlsFromWhere & "   AND AKAKROKB = '1'"
			WlsFromWhere = WlsFromWhere & "   AND JDNNO = '" & DB_UDNTRA.JDNNO & "'"
			WlsFromWhere = WlsFromWhere & "   AND LINNO = '" & DB_UDNTRA.JDNLINNO & "'"
			WlsOrderBy = " ORDER BY DATNO DESC"
			'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL3, DB_SQLBUFF)
			
			WK_DENDT.Value = VB.Left(DB_JDNTRA.DENDT, 4) & "/" & Mid(DB_JDNTRA.DENDT, 5, 2) & "/" & VB.Right(DB_JDNTRA.DENDT, 2)
			
			'20090115 ADD START RISE)Tanimura '�A���[No.523
			' ������̏ꍇ
		Else
			WK_JDNNO.Value = VB.Left(DB_ODNTRA.JDNNO, 6) & Mid(DB_ODNTRA.JDNLINNO, 2, 2)
			WK_UDNDT.Value = VB.Left(DB_ODNTRA.ODNDT, 4) & "/" & Mid(DB_ODNTRA.ODNDT, 5, 2) & "/" & VB.Right(DB_ODNTRA.ODNDT, 2)
			
			WlsFromWhere = "From TOKMTA Where TOKCD = '" & DB_ODNTRA.TOKCD & "'"
			WlsOrderBy = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL1, DB_SQLBUFF)
			
			Call NHSMTA_RClear()
			WlsFromWhere = "From NHSMTA Where NHSCD = '" & DB_ODNTRA.NHSCD & "'"
			WlsOrderBy = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL2, DB_SQLBUFF)
			
			Call JDNTRA_RClear()
			WlsFromWhere = "From JDNTRA     Where DATKB = '1'"
			WlsFromWhere = WlsFromWhere & "   AND AKAKROKB = '1'"
			WlsFromWhere = WlsFromWhere & "   AND JDNNO = '" & DB_ODNTRA.JDNNO & "'"
			WlsFromWhere = WlsFromWhere & "   AND LINNO = '" & DB_ODNTRA.JDNLINNO & "'"
			WlsOrderBy = " ORDER BY DATNO DESC"
			'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL3, DB_SQLBUFF)
			
			WK_DENDT.Value = VB.Left(DB_JDNTRA.DENDT, 4) & "/" & Mid(DB_JDNTRA.DENDT, 5, 2) & "/" & VB.Right(DB_JDNTRA.DENDT, 2)
		End If
		'20090115 ADD END   RISE)Tanimura
		
		'2008/07/05 ADD START FKS)NAKATA
		'XX �󒍔ԍ��Ō����������̂ɂ͎󒍎���\�����Ȃ�
		Dim wkTRKB As String
		If Trim(HD_TEXT.Text) <> "" Then
			wkTRKB = ""
		Else
			wkTRKB = WLSJDNTRKB.Text
		End If
		'2008/07/05 E.N.D START FKS)NAKATA
		
		
		'2008/04/07 FKS)ASANO ADD START
		If VB.Left(WK_DENDT.Value, 4) <> "    " Then
			'2008/04/07 FKS)ASANO ADD END
			'20090115 ADD START RISE)Tanimura '�A���[No.523
			' ����ς̏ꍇ
			If g_strURIKB = "1" Then
				'20090115 ADD END   RISE)Tanimura
				LST.Items.Add(WK_JDNNO.Value & " " & WK_UDNDT.Value & " " & WK_DENDT.Value & " " & LeftWid2(DB_UDNTRA.TOKCD, 5) & " " & LeftWid2(DB_TOKMTA.TOKRN, 20) & " " & LeftWid2(DB_UDNTRA.NHSCD, 9) & " " & LeftWid2(DB_NHSMTA.NHSRN, 20) & " " & LeftWid2(DB_UDNTRA.HINNMA, 20) & " " & LeftWid2(DB_UDNTRA.HINNMB, 10) & " " & New String(" ", 7 - Len(VB6.Format(DB_UDNTRA.URISU, "###,##0"))) & VB6.Format(DB_UDNTRA.URISU, "###,##0") & " " & wkTRKB)
				
				'2008/07/05 DEL START FKS)NAKATA
				'XX         + String(7 - Len(Format$(DB_UDNTRA.URISU, "###,##0")), " ") + Format$(DB_UDNTRA.URISU, "###,##0") + " " + WLSJDNTRKB       ' DB_UDNTHA.JDNTRKB
				'2008/07/05 DEL E.N.D FKS)NAKATA
				
				LST1.Items.Add(DB_UDNTRA.DATNO & DB_UDNTRA.LINNO & DB_UDNTRA.UDNNO)
				'20090115 ADD START RISE)Tanimura '�A���[No.523
				' ������̏ꍇ
			Else
				LST.Items.Add(WK_JDNNO.Value & " " & WK_UDNDT.Value & " " & WK_DENDT.Value & " " & LeftWid2(DB_ODNTRA.TOKCD, 5) & " " & LeftWid2(DB_TOKMTA.TOKRN, 20) & " " & LeftWid2(DB_ODNTRA.NHSCD, 9) & " " & LeftWid2(DB_NHSMTA.NHSRN, 20) & " " & LeftWid2(DB_ODNTRA.HINNMA, 20) & " " & LeftWid2(DB_ODNTRA.HINNMB, 10) & " " & New String(" ", 7 - Len(VB6.Format(DB_ODNTRA.OTPSU, "###,##0"))) & VB6.Format(DB_ODNTRA.OTPSU, "###,##0") & " " & wkTRKB)
				
				LST1.Items.Add(DB_ODNTRA.DATNO & DB_ODNTRA.LINNO & DB_ODNTRA.ODNNO)
			End If
			'20090115 ADD END   RISE)Tanimura
			
			'2008/07/05 ADD START FKS)NAKATA
			'XX ��ʂɕ\�������ListBox�̓��e��ޔ�������B
			If WM_WLS_LIST_END = False Then
				
				ReDim Preserve WK_LSTBOX_BEF(LST.Items.Count)
				
				WK_LSTBOX_BEF(LST.Items.Count).LSTNO = CStr(LST.Items.Count) '���X�g�ԍ�
				WK_LSTBOX_BEF(LST.Items.Count).JDNNO = WK_JDNNO.Value '�󒍇�
				WK_LSTBOX_BEF(LST.Items.Count).UDNDT = WK_UDNDT.Value '�����
			End If
			
			'2008/07/05 ADD E.N.D FKS)NAKATA
			
			'2008/04/07 FKS)ASANO ADD START
		End If
		'2008/04/07 FKS)ASANO ADD END
		
	End Sub
	
	Private Function WLS_DSP_CHECK() As Object
		Dim wkTOKCD As String
		Dim wkNHSCD As String
		
		'2008/07/04 ADD START FKS)NAKATA
		Dim wkTOKJDNNO As String
		Dim wkTOKCNT As Short
		'2008/07/04 ADD E.N.D FKS)NAKATA
		
		
		'====================================
		'   WINDOW �\���\�`�F�b�N
		'       WLS_DSP_CHECK = True  :�\����
		'       WLS_DSP_CHECK = FALSE :�\���s��
		'====================================
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		' ����ς̏ꍇ
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLS_DSP_CHECK = SSS_OK
			If DB_UDNTRA.DATKB <> "1" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_CHECK = SSS_END
				Exit Function
			End If
			If DB_UDNTRA.AKAKROKB <> "1" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_CHECK = SSS_END
				Exit Function
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If DB_UDNTRA.DENKB <> "1" Then WLS_DSP_CHECK = SSS_END
			'''    Call DB_GetEq(DBN_UDNTHA, 1, DB_UDNTRA.DATNO, BtrNormal)
			'''    If DBSTAT = 0 Then
			'''        If DB_UDNTHA.JDNTRKB <> WLSJDNTRKB Then WLS_DSP_CHECK = SSS_NEXT
			'''    Else
			'''        WLS_DSP_CHECK = SSS_NEXT
			'''    End If
			
			wkTOKCD = WLSTOKCD.Text & Space(Len(DB_UDNTRA.TOKCD) - Len(WLSTOKCD.Text))
			wkNHSCD = WLSNHSCD.Text & Space(Len(DB_UDNTRA.NHSCD) - Len(WLSNHSCD.Text))
			
			
			
			
			'2008/07/04 ADD START FKS)NAKATA
			wkTOKCNT = Len(HD_TOKJDNNO.Text)
			wkTOKJDNNO = VB.Left(Trim(DB_UDNTRA.TOKJDNNO), wkTOKCNT)
			'2008/07/04 ADD E.N.D FKS)NAKATA
			
			'2008/07/05 CHG START FKS)NAKATA
			'XX    If (Trim$(WLSNHSCD.Text) <> "") And (DB_UDNTRA.NHSCD <> WLSNHSCD) Then WLS_DSP_CHECK = SSS_NEXT
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (Trim(WLSNHSCD.Text) <> "") And (DB_UDNTRA.NHSCD <> wkNHSCD) Then WLS_DSP_CHECK = SSS_NEXT
			'2008/07/05 CHG START FKS)NAKATA
			
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (Trim(WLSTOKCD.Text) <> "") And (DB_UDNTRA.TOKCD <> wkTOKCD) Then WLS_DSP_CHECK = SSS_NEXT
			
			'2008/07/04 CHG STRAT FKS)NAKATA
			'XX    If (Trim$(HD_TOKJDNNO.Text) <> "") And (DB_UDNTRA.TOKJDNNO <> HD_TOKJDNNO.Text) Then WLS_DSP_CHECK = SSS_NEXT
			
			If (Trim(HD_TOKJDNNO.Text) <> "") And (Trim(HD_TOKJDNNO.Text) <> wkTOKJDNNO) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_CHECK = SSS_NEXT
			End If
			
			'2008/07/04 CHG E.N.D FKS)NAKATA
			
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (Trim(WLSUDNDT.Text) <> "") And (DB_UDNTRA.UDNDT < DeCNV_DATE(WLSUDNDT.Text)) Then WLS_DSP_CHECK = SSS_NEXT
			
			'20090115 ADD START RISE)Tanimura '�A���[No.523
			' ������̏ꍇ
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLS_DSP_CHECK = SSS_OK
			
			If DB_ODNTRA.DATKB <> "1" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_CHECK = SSS_END
				Exit Function
			End If
			
			If DB_ODNTRA.DENKB <> "1" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_CHECK = SSS_END
				Exit Function
			End If
			
			wkTOKCD = WLSTOKCD.Text & Space(Len(DB_ODNTRA.TOKCD) - Len(WLSTOKCD.Text))
			wkNHSCD = WLSNHSCD.Text & Space(Len(DB_ODNTRA.NHSCD) - Len(WLSNHSCD.Text))
			
			wkTOKCNT = Len(HD_TOKJDNNO.Text)
			wkTOKJDNNO = VB.Left(Trim(DB_ODNTRA.TOKJDNNO), wkTOKCNT)
			
			If Trim(WLSNHSCD.Text) <> "" And Trim(VB.Left(DB_ODNTRA.NHSCD, Len(Trim(wkNHSCD)))) <> Trim(wkNHSCD) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_CHECK = SSS_NEXT
			End If
			
			If Trim(WLSTOKCD.Text) <> "" And Trim(VB.Left(DB_ODNTRA.TOKCD, Len(Trim(wkTOKCD)))) <> Trim(wkTOKCD) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_CHECK = SSS_NEXT
			End If
			
			If Trim(HD_TOKJDNNO.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> wkTOKJDNNO Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_CHECK = SSS_NEXT
			End If
		End If
		'20090115 ADD END   RISE)Tanimura
	End Function
	
	Private Function WLS_DSP_SUB_CHECK() As Object
		'''''    Dim WL_OTPSU As Currency
		'''''    WLS_DSP_SUB_CHECK = SSS_OK
		'''''    Call DB_GetGrEq(DBN_UDNTRA, 1, "1" & DB_UDNTRA.JDNNO, BtrNormal)
		'''''    Do While (DBSTAT = 0) And (DB_UDNTRA.DATKB = "1") And (SSSVal(DB_UDNTRA.JDNLINNO) < 990)
		'''''        WL_OTPSU = 0
		'''''        Do While (DBSTAT = 0) And (DB_UDNTRA.DATKB = "1")
		'''''            Call DB_GetNext(DBN_UDNTRA, BtrNormal)
		'''''        Loop
		'''''        WL_OTPSU = DB_UDNTRA.FRDSU - DB_UDNTRA.HIKSU
		'''''        If WL_OTPSU > 0 Then
		'''''            WLS_DSP_SUB_CHECK = SSS_OK
		'''''            DBSTAT = 0
		'''''            Exit Function
		'''''        Else
		'''''            WLS_DSP_SUB_CHECK = SSS_NEXT
		'''''        End If
		'''''        Call DB_GetNext(DBN_UDNTRA, BtrNormal)
		'''''    Loop
		'''''    DBSTAT = 0
	End Function
	
	Private Sub WLS_FORM_LOAD()
		
		'=== WINDOW �ʒu�ݒ� ===
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		
		'=== ����TEXT ===
		'WLSTOKCD.Height = 285
		'WLSRN.Height = 285
		'WLSTOKCD.Text = ""
		
		
		'=== WINDOW �\���t�@�C���ݒ� ===
		WM_WLS_MFIL = DBN_UDNTRA
		WM_WLS_SFIL1 = DBN_TOKMTA
		WM_WLS_SFIL2 = DBN_NHSMTA
		WM_WLS_SFIL3 = DBN_JDNTRA
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SWlsSelList �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SWlsSelList = "*"
		
		
		'=== �\���J�n�R�[�h�����ݒ� ===
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(DB_UDNTRA.UDNNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(DB_UDNTRA.LINNO) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_LEN = LenWid(DB_UDNTRA.DATNO) + LenWid(DB_UDNTRA.LINNO) + LenWid(DB_UDNTRA.UDNNO)
		
		'=== �k�`�a�d�k�ݒ� ===
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSLABEL = "�󒍔ԍ� ������t   �󒍓��t   ���Ӑ�                     �[����                         �^��                 �i��       ����    �󒍎��"
		
		WM_WLS_INIT = 0
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		Dim WL_Key As String
		Dim strSQL As String
		
		
		'2008/07/05 ADD START FKS)NAKATA
		'XX �y�[�W����J�E���g
		If WM_WLS_PAGE_END > WM_WLS_PAGE_CLICK_NUM Then
			WM_WLS_PAGE_CLICK_NUM = WM_WLS_PAGE_CLICK_NUM + 1
		End If
		'2008/07/05 ADD E.N.D FKS)NAKATA
		
		
		If LST.Items.Count > 0 Then
			If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
				Exit Sub
			Else
				If (WM_WLS_Pagecnt + 1) > (KEYBAK.Items.Count - 1) Then
					'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
					'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If WLSSSS_SET_KEYBAK() = False Then Exit Sub
				Else
					WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
					WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
					
					
					'''                strSQL = ""
					'''                strSQL = strSQL & " SELECT * FROM ( "
					'''                strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
					'''                strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
					'''                strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
					'''                strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
					'''                strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
					'''                Call DB_GetSQL2(DBN_UDNTRA, strSQL)
					'2008/07/04 CHG START FKS)NAKATA
					'XX                Call WLS_BaseSQL(WL_Key)
					'20090115 CHG START RISE)Tanimura '�A���[No.523
					'                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
					' ����ς̏ꍇ
					If g_strURIKB = "1" Then
						Call DB_GetGrEq(WM_WLS_MFIL, 10, WL_Key, BtrNormal)
						
						' ������̏ꍇ
					Else
						' �󒍔ԍ����猟��
						If Trim(HD_TEXT.Text) <> "" Then
							strSQL = ""
							strSQL = strSQL & "SELECT"
							strSQL = strSQL & "  * "
							strSQL = strSQL & "FROM"
							strSQL = strSQL & "  ("
							strSQL = strSQL & "   SELECT"
							strSQL = strSQL & "     A.*"
							strSQL = strSQL & "   FROM"
							strSQL = strSQL & "     ODNTRA A"
							strSQL = strSQL & "   , ("
							strSQL = strSQL & "      SELECT"
							strSQL = strSQL & "        B2.*"
							strSQL = strSQL & "      FROM"
							strSQL = strSQL & "        JDNTHA B1"
							strSQL = strSQL & "      , JDNTRA B2"
							strSQL = strSQL & "      WHERE"
							strSQL = strSQL & "        B1.DATNO = B2.DATNO"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
							strSQL = strSQL & "                                 SELECT"
							strSQL = strSQL & "                                   MAX(DATNO) DATNO"
							strSQL = strSQL & "                                 , LINNO      LINNO"
							strSQL = strSQL & "                                 FROM"
							strSQL = strSQL & "                                   JDNTRA"
							strSQL = strSQL & "                                 WHERE"
							strSQL = strSQL & "                                   JDNNO " & mJDNNO
							strSQL = strSQL & "                                 GROUP BY"
							strSQL = strSQL & "                                   JDNNO"
							strSQL = strSQL & "                                 , LINNO"
							strSQL = strSQL & "                                )"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B2.OTPSU > B2.URISU"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
							strSQL = strSQL & "      AND"
							' === 20110305 === UPDATE S TOM)Morimoto �C�O�V�X�e���K�p
							'            strSQL = strSQL & "        B1.FRNKB = '0'"
							strSQL = strSQL & "       (B1.FRNKB = '0'"
							strSQL = strSQL & "        OR ("
							strSQL = strSQL & "                  B1.FRNKB   = '1' "
							strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
							strSQL = strSQL & "           )"
							strSQL = strSQL & "       )"
							' === 20110305 === UPDATE E TOM)Morimoto
							strSQL = strSQL & "     ) B "
							strSQL = strSQL & "   WHERE"
							strSQL = strSQL & "     A.JDNNO = B.JDNNO"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.DATKB = '1'"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.DENKB = '1'"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.OTPSU > 0"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNNO " & mJDNNO
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid(WL_Key, 3, 21) & "' "
							strSQL = strSQL & "  ) "
							strSQL = strSQL & "ORDER BY"
							strSQL = strSQL & "  DATKB "
							strSQL = strSQL & ", DENKB "
							strSQL = strSQL & ", JDNNO "
							strSQL = strSQL & ", JDNLINNO "
							strSQL = strSQL & ", ODNDT "
							
							' �󒍎�� + �q�撍���ԍ�
						ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then 
							strSQL = ""
							strSQL = strSQL & "SELECT"
							strSQL = strSQL & "  * "
							strSQL = strSQL & "FROM"
							strSQL = strSQL & "  ("
							strSQL = strSQL & "   SELECT"
							strSQL = strSQL & "     A.*"
							strSQL = strSQL & "   FROM"
							strSQL = strSQL & "     ODNTRA A"
							strSQL = strSQL & "   , ("
							strSQL = strSQL & "      SELECT"
							strSQL = strSQL & "        B2.*"
							strSQL = strSQL & "      FROM"
							strSQL = strSQL & "        JDNTHA B1"
							strSQL = strSQL & "      , JDNTRA B2"
							strSQL = strSQL & "      WHERE"
							strSQL = strSQL & "        B1.DATNO = B2.DATNO"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
							strSQL = strSQL & "                                 SELECT"
							strSQL = strSQL & "                                   MAX(DATNO) DATNO"
							strSQL = strSQL & "                                 , LINNO      LINNO"
							strSQL = strSQL & "                                 FROM"
							strSQL = strSQL & "                                   JDNTRA"
							strSQL = strSQL & "                                 GROUP BY"
							strSQL = strSQL & "                                   JDNNO"
							strSQL = strSQL & "                                 , LINNO"
							strSQL = strSQL & "                                )"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B2.OTPSU > B2.URISU"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
							strSQL = strSQL & "      AND"
							' === 20110305 === UPDATE S TOM)Morimoto �C�O�V�X�e���K�p
							'            strSQL = strSQL & "        B1.FRNKB = '0'"
							strSQL = strSQL & "       (B1.FRNKB = '0'"
							strSQL = strSQL & "        OR ("
							strSQL = strSQL & "                  B1.FRNKB   = '1' "
							strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
							strSQL = strSQL & "           )"
							strSQL = strSQL & "       )"
							' === 20110305 === UPDATE E TOM)Morimoto
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(mJDNTRKB) & "'"
							strSQL = strSQL & "     ) B "
							strSQL = strSQL & "   WHERE"
							strSQL = strSQL & "     A.JDNNO = B.JDNNO"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.DATKB = '1'"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.DENKB = '1'"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.OTPSU > 0"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.TOKJDNNO " & mTOKJDNNO
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid(WL_Key, 3, 21) & "' "
							strSQL = strSQL & "  ) "
							strSQL = strSQL & "ORDER BY"
							strSQL = strSQL & "  DATKB "
							strSQL = strSQL & ", DENKB "
							strSQL = strSQL & ", JDNNO "
							strSQL = strSQL & ", JDNLINNO "
							strSQL = strSQL & ", ODNDT "
						End If
						
						Call DB_GetSQL2(DBN_ODNTRA, strSQL)
					End If
					'20090115 CHG END   RISE)Tanimura
					'2008/07/04 CHG E.N.D FKS)NAKATA
					'''                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
				End If
				Call WLSSSS_DSP()
				'2008/07/05 ADD START FKS)NAKATA
				'XX �ŏI�y�[�W�̕\���`�F�b�N(�ŏI�y�[�W����x�m�F���Ă���ꍇ)
				If VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1) = "z" And LST.Items.Count > UBound(WK_LSTBOX_BEF) Then
					Call CHK_ListBox()
				ElseIf WM_WLS_PAGE_END = WM_WLS_PAGE_CLICK_NUM + 1 Then 
					Call CHK_ListBox()
				End If
				
				'2008/07/05 ADD E.N.D FKS)NAKATA
			End If
		End If
	End Sub
	
	Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(1).Image
	End Sub
	
	Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(0).Image
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		'Unload Me
		
		Hide()
	End Sub
	
	Private Sub WLSHINCD_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			Call WLS_BaseSQL(W_Key)
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			End If
		End If
	End Sub
	
	''Private Sub WLSHINCD_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 �폜
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	'''''''    If LST.ListCount > 0 Then
	'''''''        WLSHINNMA.SetFocus
	'''''''    Else
	'''''''        WLSHINCD.SetFocus
	'''''''    End If
	''
	''End Sub
	
	Private Sub WLSSOUCD_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			Call WLS_BaseSQL(W_Key)
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			End If
		End If
	End Sub
	
	''Private Sub WLSSOUCD_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 �폜
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	'''''''    If LST.ListCount > 0 Then
	'''''''        WLSSOUCD.SetFocus
	'''''''    Else
	'''''''        WLSUDNDT.SetFocus
	'''''''    End If
	''
	''End Sub
	
	Private Sub WLSHINNMA_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			Call WLS_BaseSQL(W_Key)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			End If
		End If
	End Sub
	
	''Private Sub WLSHINNMA_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 �폜
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	''''''''    If LST.ListCount > 0 Then
	''''''''        WLSTOKCD.SetFocus
	''''''''    Else
	''''''''        WLSHINNMA.SetFocus
	''''''''    End If
	''
	''End Sub
	
	''Private Sub WLSJDNTRKB_LostFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 �폜
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	''''''    If LST.ListCount > 0 Then
	''''''        LST.ListIndex = 0
	''''''    Else
	''''''        WLSTOKCD.SetFocus
	''''''    End If
	''
	''
	''End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSNHSCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSNHSCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNHSCD.TextChanged
		Dim s As Integer
		s = WLSNHSCD.SelectionStart
		WLSNHSCD.Text = StrConv(WLSNHSCD.Text, VbStrConv.UpperCase)
		WLSNHSCD.SelectionStart = s
	End Sub
	
	Private Sub WLSNHSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNHSCD.Enter
		WLSNHSCD.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSNHSCD.SelectionLength = LenWid(WLSNHSCD.Text)
	End Sub
	
	Private Sub WLSNHSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSNHSCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			Call WLS_BaseSQL(W_Key)
			
			'2008/07/02 CHG START FKS)NAKATA
			'XX        If WLSSSS_SET_KEYBAK() = True Then
			'XX            WM_WLS_INIT = 1
			'XX            Call WLSSSS_DSP
			'XX        End If
			KEYBAK.Items.Clear()
			LST.Items.Clear()
			LST1.Items.Clear()
			WM_WLS_Pagecnt = -1
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				Call WLSSSS_DSP()
			End If
			'2008/07/02 CHG START FKS)NAKATA
			
		End If
		
	End Sub
	
	''Private Sub WLSNHSCD_LostFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 �폜
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	''
	''End Sub
	''
	Private Sub WLSTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.Enter
		WLSTOKCD.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSTOKCD.SelectionLength = LenWid(WLSTOKCD.Text)
	End Sub
	
	Private Sub WLSTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTOKCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 �폜
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			Call WLS_BaseSQL(W_Key)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			
			'2008/07/05 ADD START FKS)NAKATA
			KEYBAK.Items.Clear()
			LST.Items.Clear()
			LST1.Items.Clear()
			WM_WLS_Pagecnt = -1
			WM_WLS_INIT = 1
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				Call WLSSSS_DSP()
			End If
			'2008/07/05 ADD E.N.D FKS)NAKATA
			
		End If
	End Sub
	
	''Private Sub WLSTOKCD_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 �폜
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	'''''''    If LST.ListCount > 0 Then
	'''''''        LST.ListIndex = 0
	'''''''    Else
	'''''''        WLSTOKCD.SetFocus
	'''''''    End If
	''
	''End Sub
	''
	'UPGRADE_WARNING: �C�x���g WLSUDNDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSUDNDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.TextChanged
		WLSUDNDT.SelectionLength = 1
		If pv_blnChange_Flg = True Then
			Exit Sub
		Else
			Call CtrlDatChange(WLSUDNDT)
		End If
		
	End Sub
	
	Private Sub WLSUDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.Click
		WLSUDNDT.SelectionStart = 0
		WLSUDNDT.SelectionLength = 1
	End Sub
	
	Private Sub WLSUDNDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.Enter
		If Len(Trim(WLSUDNDT.Text)) = 0 Then
			pv_blnChange_Flg = True
			WLSUDNDT.Text = Space(10)
			pv_blnChange_Flg = False
			WLSUDNDT.SelectionStart = 0
			WLSUDNDT.SelectionLength = 1
		ElseIf Len(Trim(WLSUDNDT.Text)) >= 8 Then 
			WLSUDNDT.SelectionStart = 8
			WLSUDNDT.SelectionLength = 1
		Else
			WLSUDNDT.SelectionStart = 0
			WLSUDNDT.SelectionLength = 1
		End If
	End Sub
	
	Private Sub WLSUDNDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSUDNDT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim strDat As String
		
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		Select Case True
			'��������
			Case KEYCODE = System.Windows.Forms.Keys.Return And Shift = 0
				
				If Trim(WLSUDNDT.Text) <> "" Then
					If CHECK_DATE(WLSUDNDT) = False Then
						Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '���t�G���[
						Call P_SetFocus(WLSUDNDT)
						Exit Sub
					End If
				End If
				
				'        WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
				'        WM_WLS_ENDKEY = "9"
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WM_WLS_ENDKEY = "1" & "9"
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_Pagecnt = -1
				'''            strSQL = ""
				'''            strSQL = strSQL & " SELECT * FROM ( "
				'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
				'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'''    '''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
				'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
				'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
				'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call WLS_BaseSQL(WM_WLS_STTKEY)
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If WLSSSS_SET_KEYBAK() = True Then
					Call WLSSSS_DSP()
				End If
				'����
			Case KEYCODE = System.Windows.Forms.Keys.Right And Shift = 0
				KEYCODE = 0
				
				'������
				If WLSUDNDT.SelectionStart < Len(WLSUDNDT.Text) Then
					WLSUDNDT.SelectionStart = WLSUDNDT.SelectionStart + 1
					WLSUDNDT.SelectionLength = 1
					Call NextForcus(WLSUDNDT)
				End If
				
				'����
			Case KEYCODE = System.Windows.Forms.Keys.Down And Shift = 0
				'������
				KEYCODE = 0
				
				'����
			Case KEYCODE = System.Windows.Forms.Keys.Up And Shift = 0
				'������
				KEYCODE = 0
				
				'����
			Case KEYCODE = System.Windows.Forms.Keys.Left And Shift = 0
				KEYCODE = 0
				
				'������
				If WLSUDNDT.SelectionStart > 0 Then
					WLSUDNDT.SelectionStart = WLSUDNDT.SelectionStart - 1
					WLSUDNDT.SelectionLength = 1
					Call PrevForcus(WLSUDNDT)
				End If
				
			Case KEYCODE = System.Windows.Forms.Keys.Delete And Shift = 0
				KEYCODE = 0
				
				''        'TAB��
				''        Case KEYCODE = vbKeyF16
				''            Call F_SendKey(KEYCODE, "HD_KESIDT")
				''        Case KEYCODE = vbKeyS And Shift = 2
				''            pv_blnChange_Flg = True
				''            WLSUDNDT.Text = Space(10)
				''            WLSUDNDT.SelStart = 0
				''            WLSUDNDT.SelLength = 1
				''            pv_blnChange_Flg = False
				
		End Select
		
	End Sub
	
	Private Sub WLSUDNDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles WLSUDNDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = System.Windows.Forms.Keys.Back Then
			KeyAscii = 0
			pv_blnChange_Flg = True
			If WLSUDNDT.SelectionStart > 0 Then
				WLSUDNDT.SelectionStart = WLSUDNDT.SelectionStart - 1
			End If
			WLSUDNDT.SelectionLength = 1
			Call PrevForcus(WLSUDNDT)
			pv_blnChange_Flg = False
		Else
			' ADD 2007/02/20 ���l�ȊO�͓��͕s��
			Select Case True
				Case (KeyAscii >= Asc("0") And KeyAscii <= Asc("9"))
					
				Case Else
					KeyAscii = 0
			End Select
			' ADD 2007/02/20 ���l�ȊO�͓��͕s��
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	''Private Sub WLSUDNDT_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''    Dim strDat As String
	''
	''    If Trim$(WLSUDNDT) <> "" Then
	''        If ConvDat(Trim(WLSUDNDT.Text), strDat) = False Then
	''            WLSUDNDT.SetFocus
	''            Exit Sub
	''        End If
	''        If CHECK_DATE(WLSUDNDT) = False Then
	''            Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '���t�G���[
	''            Call P_SetFocus(WLSUDNDT)
	''            Exit Sub
	''        End If
	''    End If
	''    WM_WLS_STTKEY = "1" & "1"
	'''    WM_WLS_ENDKEY = "9"
	''    WM_WLS_ENDKEY = "1" & "9"
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        Call WLSSSS_DSP
	''    End If
	''
	''End Sub
	''
	
	'20090115 ADD START RISE)Tanimura '�A���[No.523
	Private Sub WLSURIKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSURIKB.Enter
		WLSURIKB.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSURIKB.SelectionLength = LenWid(WLSURIKB.Text)
	End Sub
	
	Private Sub WLSURIKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSURIKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim W_Key As String
		
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			
			' ���͂��ꂽ�l�� 1 or 2 �łȂ��ꍇ
			If WLSURIKB.Text <> "1" And WLSURIKB.Text <> "2" Then
				' �������� 1 �ɂ���
				WLSURIKB.Text = "1"
			End If
			
			W_Key = "1" & "1" & HD_TEXT.Text
			
			Call WLS_BaseSQL(W_Key)
			
			KEYBAK.Items.Clear()
			LST.Items.Clear()
			LST1.Items.Clear()
			WM_WLS_Pagecnt = -1
			WM_WLS_INIT = 1
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True Then
				Call WLSSSS_DSP()
			End If
		End If
	End Sub
	
	Private Sub WLSURIKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSURIKB.Leave
		' ���͂��ꂽ�l�� 1 or 2 �łȂ��ꍇ
		If WLSURIKB.Text <> "1" And WLSURIKB.Text <> "2" Then
			' �������� 1 �ɂ���
			WLSURIKB.Text = "1"
		End If
	End Sub
	'20090115 ADD END   RISE)Tanimura
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		Dim WL_Key As String
		Dim strSQL As String
		
		
		'2008/07/05 ADD START FKS)NAKATA
		'XX �y�[�W����J�E���g
		If WM_WLS_PAGE_CLICK_NUM > 0 Then
			WM_WLS_PAGE_CLICK_NUM = WM_WLS_PAGE_CLICK_NUM - 1
		End If
		'2008/07/05 ADD E.N.D FKS)NAKATA
		
		
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
		Else
			Exit Sub
		End If
		WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
		''    strSQL = ""
		''    strSQL = strSQL & " SELECT * FROM ( "
		''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
		''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
		''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
		''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
		''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
		''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
		'20080702 CHG START FKS)NAKATA
		'XX    Call WLS_BaseSQL(WL_Key)
		''     Call DB_GetPre(DBN_UDNTRA, BtrNormal)
		'20090115 CHG START RISE)Tanimura '�A���[No.523
		'       Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
		' ����ς̏ꍇ
		If g_strURIKB = "1" Then
			Call DB_GetGrEq(WM_WLS_MFIL, 10, WL_Key, BtrNormal)
			
			' ������̏ꍇ
		Else
			' �󒍔ԍ����猟��
			If Trim(HD_TEXT.Text) <> "" Then
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 WHERE"
				strSQL = strSQL & "                                   JDNNO " & mJDNNO
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto �C�O�V�X�e���K�p
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNNO " & mJDNNO
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid(WL_Key, 3, 21) & "' "
				strSQL = strSQL & "  ) "
				strSQL = strSQL & "ORDER BY"
				strSQL = strSQL & "  DATKB "
				strSQL = strSQL & ", DENKB "
				strSQL = strSQL & ", JDNNO "
				strSQL = strSQL & ", JDNLINNO "
				strSQL = strSQL & ", ODNDT "
				
				' �󒍎�� + �q�撍���ԍ�
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then 
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto �C�O�V�X�e���K�p
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(mJDNTRKB) & "'"
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.TOKJDNNO " & mTOKJDNNO
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid(WL_Key, 3, 21) & "' "
				strSQL = strSQL & "  ) "
				strSQL = strSQL & "ORDER BY"
				strSQL = strSQL & "  DATKB "
				strSQL = strSQL & ", DENKB "
				strSQL = strSQL & ", JDNNO "
				strSQL = strSQL & ", JDNLINNO "
				strSQL = strSQL & ", ODNDT "
			End If
			
			Call DB_GetSQL2(DBN_ODNTRA, strSQL)
		End If
		'20090115 CHG END   RISE)Tanimura
		'20080702 CHG END FKS)NAKATA
		
		''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
		Call WLSSSS_DSP()
	End Sub
	
	Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(1).Image
	End Sub
	
	Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(0).Image
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub WLSSSS_DSP()
		Dim WL_Mode As Short
		Dim WL_Key As String
		Dim strSQL As String
		
		If WM_WLS_Dspflg = False Then Exit Sub
		
		LST.Items.Clear()
		LST1.Items.Clear()
		
		'2008/07/05 ADD START FKS)NAKATA
		'XX �z��̏�����
		If WM_WLS_LIST_END = False Then
			ReDim Preserve WK_LSTBOX_BEF(0)
		End If
		'2008/07/05 ADD E.N.D FKS)NAKATA
		
		
		'2008/07/03 CHG START FKS)NAKATA
		'XX ���͕K�{�������u�󒍎��+�q�撍���ԍ��v�u�󒍔ԍ��v�ɂȂ������ߕύX
		'XX    If Trim$(WLSJDNTRKB) <> "" Then
		If (Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "") Or Trim(HD_TEXT.Text) <> "" Then
			'2008/07/03 CHG E.N.D FKS)NAKATA
			If DBSTAT = 0 Then
				Do While (DBSTAT = 0) And (LST.Items.Count < WM_WLS_MAX) And (WL_Mode <> SSS_END)
					'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WL_Mode = WLSSSS_DSP_CHECK()
					If WL_Mode = SSS_OK Then
						'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WL_Mode = WLS_DSP_CHECK()
						If WL_Mode = SSS_OK Then
							Call WLS_DISPLAY()
						End If
					End If
					If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
						Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
					ElseIf WL_Mode = SSS_RPSN Then 
						'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WL_Key = WLSSSS_RPSN()
						'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If LenWid(WL_Key) = 0 Then
							Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
						Else
							'''                        strSQL = ""
							'''                        strSQL = strSQL & " SELECT * FROM ( "
							'''                        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
							'''                        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
							'''                        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
							'''                        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
							'''                        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
							'''                        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
							Call WLS_BaseSQL(WL_Key)
							'''                        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
						End If
					ElseIf WL_Mode = SSS_NPSN Then 
						'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WL_Key = WLSSSS_NPSN()
						'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If LenWid(WL_Key) = 0 Then
							Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
						Else
							'''                        strSQL = ""
							'''                        strSQL = strSQL & " SELECT * FROM ( "
							'''                        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
							'''                        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
							'''                        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
							'''                        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
							'''                        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
							'''                        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
							Call WLS_BaseSQL(WL_Key)
							'''                        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
						End If
					End If
					
				Loop 
				If LST.Items.Count > 0 Then
					'                LST.SetFocus
					LST.SelectedIndex = 0
				End If
			End If
			
			If (DBSTAT <> 0) Or (WL_Mode = SSS_END) Then
				If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) <> HighValue(1)) Then
					KEYBAK.Items.Add(HighValue(1))
					WM_WLS_LIST_END = True
				End If
				'2008/07/05 ADD START FKS)NAKATA
				'Else
				'XX ��ʕ\���L�^�p�z��̏�����
				'    ReDim WK_LSTBOX_BEF(0)
				'2008/07/05 ADD E.N.D FKS)NAKATA
			End If
		End If
		
		If LST.Items.Count <= 0 Then
			MsgBox("      �Y������f�[�^�����݂��܂���B")
			WM_WLS_Dspflg = False
			Call UDNTRA_RClear()
			'20090115 ADD START RISE)Tanimura '�A���[No.523
			Call ODNTRA_RClear()
			'20090115 ADD END   RISE)Tanimura
			Call JDNTRA_RClear()
		End If
		
		
	End Sub
	
	Private Function WLSSSS_DSP_CHECK() As Object
		Dim CHKDAT As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSSSS_DSP_CHECK = SSS_OK
		
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If Not IsDbNull(WM_WLS_ENDKEY) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WM_WLS_ENDKEY) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LeftWid(DB_PARA(WM_WLS_MFIL).KeyBuf, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLSSSS_DSP_CHECK = SSS_END
				Exit Function
			End If
		End If
		
	End Function
	
	Private Sub WLSSSS_FORM_ACTIVATE()
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		
		WM_WLS_Dspflg = False
		WM_WLS_KeyCode = 2
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		''98/09/25 �폜
		''WM_WLS_KeyNo = WM_WLS_TextKey
		W_Key = "1" & "1" & HD_TEXT.Text
		Call UDNTRA_RClear()
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		Call ODNTRA_RClear()
		'20090115 ADD END   RISE)Tanimura
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WLSJDNTRKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(WLSJDNTRKB) <> 0 Then
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			Call WLS_BaseSQL(W_Key)
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If WLSSSS_SET_KEYBAK() = True And WM_WLS_INIT = 0 Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			End If
		Else
			Call P_SetFocus(WLSJDNTRKB)
		End If
	End Sub
	
	Private Sub WLSSSS_FORM_INIT()
		Dim I As Short
		
		WM_WLS_KeyCode = False
		'''''    WM_WLS_MAX = LST.Height \ 225
		'''''    WM_WLS_MAX = CInt((LST.Height - 15) / 240)
		WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 200)
		
		'HD_TEXT.Height = 285
		'''''    HD_TEXT.MaxLength = WM_WLS_LEN
		'''''    HD_TEXT.Width = (WM_WLS_LEN + 1) * 100
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_STTKEY = "1" & "1"
		'    WM_WLS_ENDKEY = "9"
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_ENDKEY = "1" & "9"
		
		'''''    HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
		'''''    If LenWid(Trim$(DB_PARA(WM_WLS_MFIL).KeyBuf)) = 0 Then
		'''''        HD_TEXT.Text = ""
		'''''    End If
		''98/09/25 �ǉ�
		WM_WLS_KeyNo = WM_WLS_TextKey
		
		WLSJDNTRKB.Text = ""
		HD_TOKJDNNO.Text = ""
		WLSNHSCD.Text = ""
		WLSTOKCD.Text = ""
		HD_TEXT.Text = ""
		
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		' �f�t�H���g�͔����
		WLSURIKB.Text = "1"
		'20090115 ADD END   RISE)Tanimura
		
	End Sub
	
	Private Function WLSSSS_NPSN() As Object
		Dim WL_Key As String
		WL_Key = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSSSS_NPSN = WL_Key
	End Function
	
	Private Function WLSSSS_RPSN() As Object
		Dim WL_Key As String
		WL_Key = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSSSS_RPSN = WL_Key
	End Function
	
	Private Function WLSSSS_SET_KEYBAK() As Object
		Dim WL_Mode As Short
		Dim WL_Key As String
		Dim strSQL As String
		
		
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSSSS_SET_KEYBAK = True
		
		
		LST.Items.Clear()
		LST1.Items.Clear()
		
		Do While DBSTAT = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_Mode = WLSSSS_DSP_CHECK()
			If WL_Mode = SSS_OK Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WL_Mode = WLS_DSP_CHECK()
				If WL_Mode = SSS_OK Then
					WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
					'KEYBAK.AddItem DB_PARA(WM_WLS_MFIL).KeyBuf
					'20090115 ADD START RISE)Tanimura '�A���[No.523
					' ����ς̏ꍇ
					If g_strURIKB = "1" Then
						'20090115 ADD END   RISE)Tanimura
						KEYBAK.Items.Add(DB_UDNTRA.DATKB & DB_UDNTRA.AKAKROKB & DB_UDNTRA.JDNNO & DB_UDNTRA.JDNLINNO & DB_UDNTRA.UDNDT)
						'20090115 ADD START RISE)Tanimura '�A���[No.523
						' ������̏ꍇ
					Else
						KEYBAK.Items.Add(DB_ODNTRA.DATKB & DB_ODNTRA.DENKB & DB_ODNTRA.JDNNO & DB_ODNTRA.JDNLINNO & DB_ODNTRA.ODNDT)
					End If
					'20090115 ADD END   RISE)Tanimura
				End If
			End If
			If WL_Mode = SSS_NEXT Then
				Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
			ElseIf WL_Mode = SSS_RPSN Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WL_Key = WLSSSS_RPSN()
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If LenWid(WL_Key) = 0 Then
					Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
				Else
					'''                strSQL = ""
					'''                strSQL = strSQL & " SELECT * FROM ( "
					'''                strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
					'''                strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
					'''                strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
					'''                strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
					'''                strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
					'''                Call DB_GetSQL2(DBN_UDNTRA, strSQL)
					'''                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
					Call WLS_BaseSQL(WL_Key)
				End If
			ElseIf WL_Mode = SSS_NPSN Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WL_Key = WLSSSS_NPSN()
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If LenWid(WL_Key) = 0 Then
					Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
				Else
					'''                strSQL = ""
					'''                strSQL = strSQL & " SELECT * FROM ( "
					'''                strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
					'''                strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
					'''                strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
					'''                strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
					'''                strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
					'''                Call DB_GetSQL2(DBN_UDNTRA, strSQL)
					Call WLS_BaseSQL(WL_Key)
					'''                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
				End If
			Else
				Exit Do
			End If
		Loop 
		If DBSTAT <> 0 Or WL_Mode = SSS_END Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLSSSS_SET_KEYBAK = False
		End If
	End Function
	
	Private Sub P_SetFocus(ByRef objCtl As System.Windows.Forms.Control)
		
		On Error Resume Next
		objCtl.Focus()
		
	End Sub
	
	Private Function LeftWid2(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
		
		Dim lngMoji As Integer
		Dim lngKeta As Integer
		
		lngMoji = 0
		lngKeta = 0
		LeftWid2 = ""
		
		If AnsiLenB(pm_Characters) <= pm_Wid Then
			LeftWid2 = pm_Characters & Space(pm_Wid - AnsiLenB(pm_Characters))
			Exit Function
		End If
		
		If AnsiLenB(pm_Characters) > pm_Wid Then
			
			Do Until lngKeta >= pm_Wid
				lngMoji = lngMoji + 1
				'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
				lngKeta = lngKeta + LenB(StrConv(Mid(pm_Characters, lngMoji, 1), vbFromUnicode))
			Loop 
			
			If lngKeta > pm_Wid Then
				LeftWid2 = VB.Left(pm_Characters, lngMoji - 1) & Space(1)
			Else
				LeftWid2 = VB.Left(pm_Characters, lngMoji)
			End If
		End If
		
	End Function
	
	
	Private Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
	End Function
	
	Private Function AnsiLenB(ByVal StrArg As String) As Integer
		'�T�v�F����������
		'�����FStrArg,Input,String,�Ώە�����
		'�����FAnsi���ނ��޲ĵ��ނŕ�������޲Đ���Ԃ�
#If Win32 Then
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiLenB = LenB(StrArg)
#End If
	End Function
	
	' StrConv ���Ăяo���܂��B
	Private Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g flag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g StrArg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiStrConv = StrArg
#End If
		
	End Function
	
	Private Function ConvDat(ByVal strTarget As String, ByRef strDat As String) As Boolean
		
		Dim blnRtnVal As Boolean
		Dim strYYYY As String
		Dim strMM As String
		Dim strDD As String
		
		blnRtnVal = False
		strDat = ""
		strYYYY = ""
		strMM = ""
		strDD = ""
		
		If IsDate(strTarget) = True Then
			strDat = strTarget
			blnRtnVal = True
		Else
			If Len(strTarget) = 8 Then
				strYYYY = VB.Left(strTarget, 4)
				strMM = Mid(strTarget, 5, 2)
				strDD = VB.Right(strTarget, 2)
				If IsDate(strYYYY & "/" & strMM & "/" & strDD) = True Then
					strDat = strYYYY & "/" & strMM & "/" & strDD
					blnRtnVal = True
				End If
			End If
		End If
		
		ConvDat = blnRtnVal
		
	End Function
	
	Private Function CtrlDatChange(ByRef Ctl As System.Windows.Forms.TextBox) As String
		
		Dim lngSelstart As Integer
		Dim Wk_DspMoji As String
		Dim Wk_EditMoji As String
		Wk_EditMoji = CnvDspItem_Date(Ctl.Text)
		
		'�ҏW��̕�����\���`���ɕϊ�
		Wk_DspMoji = CnvDspItem_Date(Wk_EditMoji)
		
		pv_blnChange_Flg = True
		lngSelstart = Ctl.SelectionStart
		Ctl.Text = VB.Left(Wk_DspMoji & Space(10), 10)
		Ctl.SelectionStart = lngSelstart
		Ctl.SelectionLength = 1
		'��ݼ޲���ĉ�
		pv_blnChange_Flg = False
		
		'����̫����ʒu����E�ֈړ�
		Call NextForcus(Ctl)
		
	End Function
	
	Private Function CnvDspItem_Date(ByVal strValue As String) As String
		
		Dim Rtn_Str_Value As String
		
		Rtn_Str_Value = strValue
		
		'���t�̏ꍇ
		If Trim(Rtn_Str_Value) = "" Then
			'�����͂̏ꍇ
			Rtn_Str_Value = New String(Space(1), 10)
		Else
			'���͂���̏ꍇ
			If Len(Trim(Rtn_Str_Value)) <> Len("YYYYMMDD") Then
				'���͌`�����قȂ�ꍇ
				'�l���������l�̏ꍇ�A�A�l�������o�C�g��(�����Ƃ��Ďg�p)�������ɒǉ�
				Rtn_Str_Value = LTrim(Rtn_Str_Value) & New String(Space(1), 10)
				'�E����o�C�g���������擾
				Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, 10)
			Else
				'�\���`���L
				Rtn_Str_Value = CF_Ctr_AnsiLeftB(VB6.Format(Rtn_Str_Value, "0000/00/00") & New String(Space(1), 10), 10)
			End If
		End If
		
		CnvDspItem_Date = Rtn_Str_Value
		
	End Function
	
	Private Function NextForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object
		
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'    '�ړ��t���O������
		'    pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		
		'���݂�÷�ď�̑I����Ԃ��擾
		Act_SelStart = Ctl.SelectionStart
		Act_SelLength = Ctl.SelectionLength
		Act_SelStr = Ctl.SelectedText
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		
		If Act_SelStart = 0 And Act_SelStrB = 10 Then
			'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
			'�l���������l�̏ꍇ
			'�ŏI������I������
			Ctl.SelectionStart = Len(Ctl.Text) - 1
			Ctl.SelectionLength = 1
		Else
			If Act_SelStart = Len(Ctl.Text) Then
				'�I���J�n�ʒu����ԉE�̏ꍇ
				''                Select Case Ctl.NAME
				''                    Case WLSHDNDT.NAME
				''                        If IsDate(Ctl.Text) = True Then
				''                            WLSHDNDT.ForeColor = COLOR_BLACK
				''                            WLSSIRCD.SetFocus
				''                        End If
				''                End Select
				Ctl.SelectionStart = Len(Ctl.Text) - 1
				Ctl.SelectionLength = 1
			Else
				'�I���J�n�ʒu����ԉE�łȂ��ꍇ
				
				'�P�E�̂P�����擾
				Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)
				
				If Str_Wk = "" Then
					'��ԉE�ֈړ����I���Ȃ���Ԃ�
					Ctl.SelectionStart = Len(Ctl.Text)
					Ctl.SelectionLength = 0
				Else
					'�E�ɂP�������炵���͉\�ȕ���������
					Next_SelStart = -1
					For Wk_Point = Act_SelStart + 1 To Len(Ctl.Text) Step 1
						
						Str_Wk = Mid(Ctl.Text, Wk_Point, 1)
						
						'���t/�N��/�������ڂ̏ꍇ
						'���͉\�������Ƌ󔒂��ړ��\
						If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
							Next_SelStart = Wk_Point - 1
							Exit For
						End If
					Next 
					
					If Next_SelStart = -1 Then
						'�I���\�ȕ������Ȃ��ꍇ
						''                        Select Case Ctl.NAME
						''                            Case WLSHDNDT.NAME
						''                                If IsDate(Ctl.Text) = True Then
						''                                    WLSHDNDT.ForeColor = COLOR_BLACK
						''                                    WLSSIRCD.SetFocus
						''                                End If
						''                        End Select
					Else
						'�I���\�ȕ���������ꍇ
						
						If Act_SelLength = 0 Then
							'�ړ��O�̑I�𕶎������Ȃ��ꍇ
							'�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						Ctl.SelectionStart = Next_SelStart
						Ctl.SelectionLength = Wk_SelLength
					End If
				End If
			End If
			
		End If
		
	End Function
	
	Private Function PrevForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object
		
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'    '�ړ��t���O������
		'    pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		
		'���݂�÷�ď�̑I����Ԃ��擾
		Act_SelStart = Ctl.SelectionStart
		Act_SelLength = Ctl.SelectionLength
		Act_SelStr = Ctl.SelectedText
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		
		If Act_SelStart = 0 And Act_SelStrB = 10 Then
			'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
			'�l���������l�̏ꍇ
			'�ŏI������I������
			Ctl.SelectionStart = Len(Ctl.Text) - 1
			Ctl.SelectionLength = 1
		Else
			If Act_SelStart = Len(Ctl.Text) Then
				'�I���J�n�ʒu����ԉE�̏ꍇ
				''                Select Case Ctl.NAME
				''                    Case WLSHDNDT.NAME
				''                        If IsDate(Ctl.Text) = True Then
				''                            WLSHDNDT.ForeColor = COLOR_BLACK
				''                            WLSHDNTRKB.SetFocus
				''                        End If
				''                End Select
			Else
				'�I���J�n�ʒu����ԉE�łȂ��ꍇ
				
				'�P�E�̂P�����擾
				Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)
				
				If Str_Wk = "" Then
					'��ԉE�ֈړ����I���Ȃ���Ԃ�
					Ctl.SelectionStart = Len(Ctl.Text)
					Ctl.SelectionLength = 0
				Else
					'�E�ɂP�������炵���͉\�ȕ���������
					Next_SelStart = -1
					'                    For Wk_Point = Act_SelStart + 1 To 0 Step -1       ' DEL 2007/02/20
					For Wk_Point = Act_SelStart + 1 To 1 Step -1 ' ADD 2007/02/20
						
						Str_Wk = Mid(Ctl.Text, Wk_Point, 1)
						
						'���t/�N��/�������ڂ̏ꍇ
						'���͉\�������Ƌ󔒂��ړ��\
						If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
							Next_SelStart = Wk_Point - 1
							Exit For
						End If
					Next 
					
					If Next_SelStart = -1 Then
						'�I���\�ȕ������Ȃ��ꍇ
						''                Select Case Ctl.NAME
						''                    Case WLSHDNDT.NAME
						''                        If IsDate(Ctl.Text) = True Then
						''                            WLSHDNDT.ForeColor = COLOR_BLACK
						''                            WLSHDNTRKB.SetFocus
						''                        End If
						''                End Select
					Else
						'�I���\�ȕ���������ꍇ
						
						If Act_SelLength = 0 Then
							'�ړ��O�̑I�𕶎������Ȃ��ꍇ
							'�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						Ctl.SelectionStart = Next_SelStart
						Ctl.SelectionLength = Wk_SelLength
					End If
				End If
			End If
			
		End If
		
	End Function
	
	
	Private Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer
		
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))
		
		Exit Function
		
	End Function
	
	Private Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
		
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	
	Private Function GP_Get_NM(ByVal strNM As String, ByVal lngMR As Integer) As String
		
		Dim lngMoji As Integer
		Dim lngKeta As Integer
		
		lngMoji = 0
		lngKeta = 0
		GP_Get_NM = ""
		
		If AnsiLenB(strNM) <= lngMR Then
			GP_Get_NM = strNM
			Exit Function
		End If
		
		If AnsiLenB(strNM) > lngMR Then
			
			Do Until lngKeta >= lngMR
				lngMoji = lngMoji + 1
				'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
				lngKeta = lngKeta + LenB(StrConv(Mid(strNM, lngMoji, 1), vbFromUnicode))
			Loop 
			
			If lngKeta > lngMR Then
				GP_Get_NM = VB.Left(strNM, lngMoji - 1)
			Else
				GP_Get_NM = VB.Left(strNM, lngMoji)
			End If
		End If
		
	End Function
	
	
	Sub WLS_BaseSQL(Optional ByVal strKeyBak As String = " ")
		Dim strSQL As String
		Dim wkTOKCD As String
		Dim wkTANCD As String
		Dim strSQLWhere As String
		Dim strSQLWhereB As String
		
		'2008/07/03 ADD START FKS)NAKATA
		'XX �����܂������p�ϐ�
		Dim wkJDNNO As String '�󒍔ԍ�
		Dim wkTOKJDNNO As String '�q�撍���ԍ�
		
		Dim wkKEYBAK As String
		'2008/07/03 ADD START FKS)NAKATA
		
		
		'XX �ŏI�y�[�W�t���O�̏�����
		WM_WLS_LIST_END = False
		WM_WLS_PAGE_CLICK_NUM = 0
		
		
		'2008/07/03 ADD START FKS)NAKATA
		'XX �K�{���ڂ����͂���Ă��Ȃ��ꍇ�A���b�Z�[�W��\��������B
		If (Trim(WLSJDNTRKB.Text) = "" Or Trim(HD_TOKJDNNO.Text) = "") And Trim(HD_TEXT.Text) = "" Then
			MsgBox("[�󒍎��{�q�撍���ԍ��v�܂��́u�󒍔ԍ��v����͂��ĉ������B")
			Exit Sub
		End If
		
		
		'XX �󒍔ԍ��������p�����ɕύX����B
		If Len(Trim(HD_TEXT.Text)) >= 6 Then
			'XX �󒍔ԍ����U�����͂���Ă���ꍇ�A�u = JDNNO�v�̌`�ɂ���
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'            wkJDNNO = " = '" + Trim(HD_TEXT.Text) + "'"
			wkJDNNO = " = '" & AE_EditSQLText(Trim(HD_TEXT.Text)) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		ElseIf Len(Trim(HD_TEXT.Text)) > 0 And Len(Trim(HD_TEXT.Text)) < 6 Then 
			'XX �󒍔ԍ����U���ȉ��̏ꍇ�A�u LIKE JDNNO%�v�̌`�ɂ���
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'            wkJDNNO = " LIKE '" + Trim(HD_TEXT.Text) + "%'"
			wkJDNNO = " LIKE '" & AE_EditSQLText(Trim(HD_TEXT.Text)) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		
		'XX �q�撍���ԍ��������p�����ɕύX����B�ԍ��ɋK�����Ȃ����ߌ���Ɂu���v��t����B
		If Trim(HD_TOKJDNNO.Text) <> "" Then
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'            wkTOKJDNNO = " LIKE '" + Trim(HD_TOKJDNNO.Text) + "%'"
			wkTOKJDNNO = " LIKE '" & AE_EditSQLText(Trim(HD_TOKJDNNO.Text)) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		' �����Ԃ�ޔ�����
		g_strURIKB = WLSURIKB.Text
		'20090115 ADD END   RISE)Tanimura
		
		'XX �����擾
		If SerchCount(wkJDNNO, wkTOKJDNNO) <> True Then
			Exit Sub
		End If
		
		
		'    If WM_WLS_Pagecnt > -1 Then
		'
		'    'XX �u���v�{�^���������ꂽ�ꍇ
		'    wkKEYBAK = KEYBAK.List(WM_WLS_Pagecnt)
		'    wkJDNNO = Mid$(wkKEYBAK, 3, 8)
		'    wkUDNDT = Right$(wkKEYBAK, 8)
		'
		'
		'         strSQL = ""
		'        strSQL = strSQL & " SELECT * "
		'        strSQL = strSQL & " FROM "
		'        strSQL = strSQL & "   (SELECT UDNTRA.*  "
		'        strSQL = strSQL & "    FROM UDNTRA ,UDNTHA , "
		'        strSQL = strSQL & "      (SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
		'        strSQL = strSQL & "        FROM UDNTHA "
		'        strSQL = strSQL & "        WHERE DENKB = '1' "
		'        strSQL = strSQL & "          AND JDNNO >= '" & wkJDNNO & "'"
		'        strSQL = strSQL & "          AND UDNDT >= '" & wkUDNDT & "'"
		'        strSQL = strSQL & "        GROUP BY UDNNO ) B"
		'        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
		'        strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
		'        strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
		'        strSQL = strSQL & "   AND UDNTRA.DATKB = '1' "
		'        strSQL = strSQL & "   AND UDNTRA.AKAKROKB = '1' "
		'        strSQL = strSQL & "   AND UDNTRA.JDNNO  >= '" & wkJDNNO & "'"
		'        strSQL = strSQL & " ) "
		'        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
		'
		
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		' ����ς̏ꍇ
		If g_strURIKB = "1" Then
			'=== �k�`�a�d�k�ݒ� ===
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLSLABEL = "�󒍔ԍ� ������t   �󒍓��t   ���Ӑ�                     �[����                         �^��                 �i��       ����    �󒍎��"
			
			WM_WLS_MFIL = DBN_UDNTRA
			'20090115 ADD END   RISE)Tanimura
			'XX �u�󒍔ԍ��v�����͂���Ă���ꍇ�A�ȉ��̏����ɂČ�������B
			If Trim(HD_TEXT.Text) <> "" Then
				
				'XX �K�{���ڂ��󒍔ԍ��̏ꍇ
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM "
				strSQL = strSQL & "   (SELECT UDNTRA.*  "
				strSQL = strSQL & "    FROM UDNTRA ,UDNTHA , "
				strSQL = strSQL & "      (SELECT /*+ INDEX(UDNTHA X_UDNTHA91)*/ UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "        FROM UDNTHA "
				strSQL = strSQL & "        WHERE DENKB = '1' "
				strSQL = strSQL & "          AND JDNNO " & wkJDNNO
				strSQL = strSQL & "        GROUP BY UDNNO ) B"
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
				strSQL = strSQL & "     ,(SELECT RECNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "        FROM  UDNTRA "
				strSQL = strSQL & "        WHERE DENKB = '1' "
				strSQL = strSQL & "          AND DATKB = '1' "
				strSQL = strSQL & "          AND AKAKROKB = '1' "
				strSQL = strSQL & "          AND JDNNO " & wkJDNNO
				strSQL = strSQL & "        GROUP BY RECNO ) C"
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
				strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
				strSQL = strSQL & "   AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = C.DT "
				strSQL = strSQL & "   AND UDNTRA.RECNO = C.RECNO "
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "   AND UDNTRA.DATKB = '1' "
				strSQL = strSQL & "   AND UDNTRA.AKAKROKB = '1' "
				strSQL = strSQL & "   AND UDNTRA.JDNNO  " & wkJDNNO
				strSQL = strSQL & " ) "
				strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				
				'XX �u�󒍎�� + �q�撍���ԍ��v�����͂���Ă���ꍇ
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then 
				
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM (SELECT UDNTRA. * "
				strSQL = strSQL & "         FROM UDNTRA , "
				strSQL = strSQL & "         UDNTHA ,"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
				'            strSQL = strSQL & "         (SELECT /*+ INDEX(UDNTRA X_UDNTRA91)*/ UDNNO,MAX(WRTFSTDT || WRTFSTTM) DT "
				'            strSQL = strSQL & "             FROM    UDNTRA "
				'            strSQL = strSQL & "             WHERE   TOKJDNNO " & wkTOKJDNNO
				'            strSQL = strSQL & "             AND     AKAKROKB = '1' "
				'            strSQL = strSQL & "             AND     DATKB = '1' "
				'            strSQL = strSQL & "             GROUP BY UDNNO "
				'            strSQL = strSQL & "         ) B "
				strSQL = strSQL & "         (SELECT   RECNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "             FROM  UDNTRA "
				strSQL = strSQL & "             WHERE DENKB = '1' "
				strSQL = strSQL & "             AND   DATKB = '1' "
				strSQL = strSQL & "             AND   AKAKROKB = '1' "
				strSQL = strSQL & "             AND   TOKJDNNO " & wkTOKJDNNO
				strSQL = strSQL & "             GROUP BY RECNO "
				strSQL = strSQL & "         ) B "
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "     WHERE UDNTHA.DATNO = UDNTRA.DATNO "
				strSQL = strSQL & "     AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = B.DT "
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
				'            strSQL = strSQL & "     AND UDNTRA.UDNNO = B.UDNNO "
				strSQL = strSQL & "     AND UDNTRA.RECNO = B.RECNO "
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "     AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB.Text & "'"
				strSQL = strSQL & "     AND UDNTHA.DENKB = '1' ) "
				strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO , UDNDT "
				
			End If
			
			'2008/07/03 ADD E.N.D FKS)NAKATA
			'2008/07/03 DEL START FKS)NAKATA
			'XX    strSQL = ""
			'XX    strSQL = strSQL & " SELECT * FROM ( "
			'XX    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B "
			'XX    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'XX    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'XX''    strSQL = strSQL & "    AND UDNTHA.URIKJN <> '02'"       '���������͕ԕi�s�� 2007.08.23 ADD
			'XX    strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
			'XX    strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
			'XX    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & strKeyBak & "')"
			'XX    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'2008/07/03 DEL E.N.D FKS)NAKATA
			
			
			Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			
			'20090115 ADD START RISE)Tanimura '�A���[No.523
			' ������̏ꍇ
		Else
			'=== �k�`�a�d�k�ݒ� ===
			'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLSLABEL = "�󒍔ԍ� �o�ד��t   �󒍓��t   ���Ӑ�                     �[����                         �^��                 �i��       ����    �󒍎��"
			
			WM_WLS_MFIL = DBN_ODNTRA
			
			' �󒍔ԍ����猟��
			If Trim(HD_TEXT.Text) <> "" Then
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 WHERE"
				strSQL = strSQL & "                                   JDNNO " & wkJDNNO
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto �C�O�V�X�e���K�p
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNNO " & wkJDNNO
				strSQL = strSQL & "  ) "
				strSQL = strSQL & "ORDER BY"
				strSQL = strSQL & "  DATKB "
				strSQL = strSQL & ", DENKB "
				strSQL = strSQL & ", JDNNO "
				strSQL = strSQL & ", JDNLINNO "
				strSQL = strSQL & ", ODNDT "
				
				' �󒍎�� + �q�撍���ԍ�
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then 
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto �C�O�V�X�e���K�p
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "'"
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.TOKJDNNO " & wkTOKJDNNO
				strSQL = strSQL & "  ) "
				strSQL = strSQL & "ORDER BY"
				strSQL = strSQL & "  DATKB "
				strSQL = strSQL & ", DENKB "
				strSQL = strSQL & ", JDNNO "
				strSQL = strSQL & ", JDNLINNO "
				strSQL = strSQL & ", ODNDT "
			End If
			
			Call DB_GetSQL2(DBN_ODNTRA, strSQL)
		End If
		'20090115 ADD END   RISE)Tanimura
		
	End Sub
	
	'2008/07/04/ ADD START FKS)NAKATA
	Private Function SerchCount(ByRef wkJDNNO As Object, ByRef wkTOKJDNNO As Object) As Boolean
		'XX
		'XX ���������擾�t�@���N�V���� (�߂�l�FTrue / False)
		'XX
		
		
		Dim strSQL As String
		Dim strMSG As String '���������\���p
		
		Dim wkCNT As Double
		Dim wkPAGE As Double
		Dim wkLIST As Double
		Dim I As Short
		
		
		
		'2008/07/05 ADD START FKS)NAKATA
		Dim wkTOKCD As String
		Dim wkNHSCD As String
		Dim wkUDNDT As String
		
		
		'XX ���Ӑ�������p�����ɕύX����B
		If Len(Trim(WLSTOKCD.Text)) >= 5 Then
			'XX ���Ӑ悪�S�����͂���Ă���ꍇ�A�u = TOKCD�v�̌`�ɂ���
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'            wkTOKCD = " = '" + Trim(WLSTOKCD.Text) + "'"
			wkTOKCD = " = '" & AE_EditSQLText(Trim(WLSTOKCD.Text)) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		ElseIf Len(Trim(WLSTOKCD.Text)) > 0 And Len(Trim(WLSTOKCD.Text)) < 5 Then 
			'XX ���Ӑ悪�S���ȉ��̏ꍇ�A�u LIKE TOKCD%�v�̌`�ɂ���
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'            wkTOKCD = " LIKE '" + Trim(WLSTOKCD.Text) + "%'"
			wkTOKCD = " LIKE '" & AE_EditSQLText(Trim(WLSTOKCD.Text)) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		
		'XX �[����������p�����ɕύX����B
		If Len(Trim(WLSNHSCD.Text)) >= 9 Then
			'XX �[���悪�X�����͂���Ă���ꍇ�A�u = wkNHSCD�v�̌`�ɂ���
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'            wkNHSCD = " = '" + Trim(WLSNHSCD.Text) + "'"
			wkNHSCD = " = '" & AE_EditSQLText(Trim(WLSNHSCD.Text)) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		ElseIf Len(Trim(WLSNHSCD.Text)) > 0 And Len(Trim(WLSNHSCD.Text)) < 9 Then 
			'XX �[���悪�X���ȉ��̏ꍇ�A�u LIKE TOKCD%�v�̌`�ɂ���
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'            wkNHSCD = " LIKE '" + Trim(WLSNHSCD.Text) + "%'"
			wkNHSCD = " LIKE '" & AE_EditSQLText(Trim(WLSNHSCD.Text)) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		
		'XX ��������uyyyy/mm/dd�v����uyyyymmdd�v�ɕύX����B
		wkUDNDT = WLSUDNDT.Text
		wkUDNDT = VB.Left(wkUDNDT, 4) & Mid(wkUDNDT, 6, 2) & VB.Right(wkUDNDT, 2)
		
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		' ����������ޔ����Ă���
		mJDNTRKB = WLSJDNTRKB.Text ' �󒍎��
		'UPGRADE_WARNING: �I�u�W�F�N�g wkJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mJDNNO = wkJDNNO ' �󒍔ԍ�
		'UPGRADE_WARNING: �I�u�W�F�N�g wkTOKJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mTOKJDNNO = wkTOKJDNNO ' �q�撍���ԍ�
		'20090115 ADD END   RISE)Tanimura
		
		'2008/07/05 ADD E.N.D FKS)NAKATA
		
		SerchCount = True
		
		'20090115 ADD START RISE)Tanimura '�A���[No.523
		' ����ς̏ꍇ
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			'UPGRADE_WARNING: �I�u�W�F�N�g wkJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(wkJDNNO) <> "" Then
				
				'XX �󒍔ԍ����猟��
				strSQL = ""
				'        strSQL = strSQL & " SELECT /*+ INDEX(JDNTRA.X_JDNTRA02)*/ COUNT(DATNO)"
				'        strSQL = strSQL & " FROM JDNTRA"
				'        strSQL = strSQL & " WHERE TRIM(JDNNO) || TRIM(LINNO) IN"
				'        strSQL = strSQL & " ("
				'        strSQL = strSQL & "  SELECT TRIM(JDNNO) || TRIM(JDNLINNO) "
				strSQL = strSQL & "  SELECT COUNT(DATNO) "
				strSQL = strSQL & "  FROM "
				strSQL = strSQL & "    (SELECT UDNTRA.*  "
				strSQL = strSQL & "     FROM UDNTRA ,UDNTHA , "
				strSQL = strSQL & "       (SELECT /*+ INDEX(UDNTHA X_UDNTHA91)*/ UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "         FROM UDNTHA "
				strSQL = strSQL & "         WHERE DENKB = '1' "
				'UPGRADE_WARNING: �I�u�W�F�N�g wkJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "           AND JDNNO " & wkJDNNO
				If wkUDNDT <> "" Then
					strSQL = strSQL & "           AND UDNDT >= '" & wkUDNDT & "'"
				End If
				If wkTOKCD <> "" Then
					strSQL = strSQL & "           AND TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "           AND NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "         GROUP BY UDNNO ) B"
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
				strSQL = strSQL & "      ,(SELECT RECNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "         FROM  UDNTRA "
				strSQL = strSQL & "         WHERE DENKB = '1' "
				strSQL = strSQL & "           AND DATKB = '1' "
				strSQL = strSQL & "           AND AKAKROKB = '1' "
				'UPGRADE_WARNING: �I�u�W�F�N�g wkJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "           AND JDNNO " & wkJDNNO
				If wkUDNDT <> "" Then
					strSQL = strSQL & "           AND UDNDT >= '" & wkUDNDT & "'"
				End If
				If wkTOKCD <> "" Then
					strSQL = strSQL & "           AND TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "           AND NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "         GROUP BY RECNO ) C"
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "   WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				strSQL = strSQL & "    AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
				strSQL = strSQL & "    AND UDNTHA.UDNNO = B.UDNNO "
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
				strSQL = strSQL & "    AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = C.DT "
				strSQL = strSQL & "    AND UDNTRA.RECNO = C.RECNO "
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "    AND UDNTRA.DATKB = '1' "
				strSQL = strSQL & "    AND UDNTRA.AKAKROKB = '1' "
				'UPGRADE_WARNING: �I�u�W�F�N�g wkJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "    AND UDNTRA.JDNNO  " & wkJDNNO
				strSQL = strSQL & "   ) "
				'        strSQL = strSQL & " ) "
				
				'UPGRADE_WARNING: �I�u�W�F�N�g wkTOKJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(wkTOKJDNNO) <> "" Then 
				
				'XX �󒍎�� + �q�撍���ԍ�
				strSQL = ""
				'        strSQL = strSQL & " SELECT /*+ INDEX(JDNTRA.X_JDNTRA02)*/ COUNT(DATNO)"
				'        strSQL = strSQL & " FROM JDNTRA"
				'        strSQL = strSQL & " WHERE TRIM(JDNNO) || TRIM(LINNO) IN (SELECT TRIM(JDNNO) || TRIM(JDNLINNO)"
				strSQL = strSQL & "  SELECT COUNT(DATNO) "
				strSQL = strSQL & " FROM (SELECT UDNTRA. *"
				strSQL = strSQL & "     FROM UDNTRA ,"
				strSQL = strSQL & "         UDNTHA ,"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
				'        strSQL = strSQL & "         (SELECT /*+ INDEX(UDNTRA X_UDNTRA91)*/ UDNNO"
				strSQL = strSQL & "         (SELECT RECNO"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "             ,MAX(WRTFSTDT || WRTFSTTM) DT"
				strSQL = strSQL & "         FROM UDNTRA"
				'UPGRADE_WARNING: �I�u�W�F�N�g wkTOKJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "         WHERE TOKJDNNO" & wkTOKJDNNO
				If wkUDNDT <> "" Then
					strSQL = strSQL & "           AND UDNDT >= '" & wkUDNDT & "'"
				End If
				If wkTOKCD <> "" Then
					strSQL = strSQL & "           AND TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "           AND NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "         AND AKAKROKB = '1'"
				strSQL = strSQL & "         AND DATKB = '1'"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
				'        strSQL = strSQL & "         GROUP BY UDNNO) B"
				strSQL = strSQL & "         GROUP BY RECNO) B"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "     WHERE UDNTHA.DATNO = UDNTRA.DATNO"
				strSQL = strSQL & "     AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = B.DT"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    �A���[��FC12060501
				'        strSQL = strSQL & "     AND UDNTRA.UDNNO = B.UDNNO"
				strSQL = strSQL & "     AND UDNTRA.RECNO = B.RECNO "
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
				'        strSQL = strSQL & "     AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB.Text & "'"
				strSQL = strSQL & "     AND UDNTHA.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "'"
				'''' UPD 2009/12/03  FKS) T.Yamamoto    End
				strSQL = strSQL & "     AND UDNTHA.DENKB = '1')"
				'       strSQL = strSQL & " )"
			End If
			
			'20090115 ADD START RISE)Tanimura '�A���[No.523
			' ������̏ꍇ
		Else
			' �󒍔ԍ����猟��
			'UPGRADE_WARNING: �I�u�W�F�N�g wkJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(wkJDNNO) <> "" Then
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  COUNT(DATNO) "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 WHERE"
				'UPGRADE_WARNING: �I�u�W�F�N�g wkJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "                                   JDNNO " & wkJDNNO
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto �C�O�V�X�e���K�p
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				'UPGRADE_WARNING: �I�u�W�F�N�g wkJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "     A.JDNNO " & wkJDNNO
				If wkTOKCD <> "" Then
					strSQL = strSQL & "   AND"
					strSQL = strSQL & "     A.TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "   AND"
					strSQL = strSQL & "     A.NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "  ) "
				
				' �󒍎�� + �q�撍���ԍ�
				'UPGRADE_WARNING: �I�u�W�F�N�g wkTOKJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(wkTOKJDNNO) <> "" Then 
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  COUNT(DATNO) "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto �C�O�V�X�e���K�p
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "'"
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				'UPGRADE_WARNING: �I�u�W�F�N�g wkTOKJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "     A.TOKJDNNO " & wkTOKJDNNO
				If wkTOKCD <> "" Then
					strSQL = strSQL & "   AND"
					strSQL = strSQL & "     A.TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "   AND"
					strSQL = strSQL & "     A.NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "  ) "
			End If
		End If
		'20090115 ADD END   RISE)Tanimura
		
		Call DB_GetSQL2(DBN_JDNTHA, strSQL)
		
		
		'XX�@�������ʂ��P�O�O���ȏ�Ȃ烁�b�Z�[�W��\��
		If DB_ExtNum.ExtNum(0) >= 100 Then
			
			strMSG = strMSG & "���������F" & DB_ExtNum.ExtNum(0) & "��"
			
			If MsgBox(strMSG, MsgBoxStyle.OKCancel) = MsgBoxResult.Cancel Then
				SerchCount = False
				WM_WLS_Dspflg = False
				Call JDNTRA_RClear()
				Exit Function
			End If
		End If
		
		'XX �Y���f�[�^���Ȃ��ꍇ�A���b�Z�[�W��\��������
		If DB_ExtNum.ExtNum(0) <= 0 Then
			MsgBox("      �Y������f�[�^�����݂��܂���B")
			SerchCount = False
			WM_WLS_Dspflg = False
			Call UDNTRA_RClear()
			Exit Function
		End If
		
		
		'XX �y�[�W����p�ɁA�ŏI�y�[�W�ԍ��ƍŏI���X�g�ԍ����Z�o����B
		
		wkCNT = DB_ExtNum.ExtNum(0)
		
		'�ŏI�y�[�W�ԍ�
		'UPGRADE_WARNING: Mod �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		WM_WLS_PAGE_END = Int(wkCNT / 18) + CShort(IIf((wkCNT Mod 18) = 0, 0, 1))
		
		'�ŏI���X�g�ԍ�
		Do While (wkCNT > 18)
			wkCNT = wkCNT - 18
		Loop 
		
		WM_WLS_LIST_CNT = wkCNT
		
	End Function
	'2008/07/04/ ADD E.N.D FKS)NAKATA
	
	'2008/07/05 ADD START FKS)NAKATA
	Private Sub CHK_ListBox()
		
		
		Dim wkLSTCNT As String
		Dim wkJDNNO As String
		Dim wkUDNDT As String
		
		Dim lstLSTCNT As String
		Dim lstJDNNO As String
		Dim lstUDNDT As String
		
		Dim wkStr As String
		
		Dim I As Short
		
		
		If LST.Items.Count <> UBound(WK_LSTBOX_BEF) Then
			
			'XX�@�z��̎��o��
			wkLSTCNT = Trim(WK_LSTBOX_BEF(UBound(WK_LSTBOX_BEF)).LSTNO)
			wkJDNNO = Trim(WK_LSTBOX_BEF(CInt(wkLSTCNT)).JDNNO)
			wkUDNDT = Trim(WK_LSTBOX_BEF(CInt(wkLSTCNT)).UDNDT)
			
			'XX ListBox����̎��o��
			wkStr = VB6.GetItemString(LST, CDbl(wkLSTCNT) - 1)
			
			lstJDNNO = VB.Left(Trim(wkStr), 8)
			lstUDNDT = Mid(Trim(wkStr), 10, 10)
			
			If wkJDNNO = lstJDNNO And wkUDNDT = lstUDNDT Then
				
				For I = LST.Items.Count - 1 To CInt(wkLSTCNT) Step -1
					LST.Items.RemoveAt((I))
				Next 
			Else
				Exit Sub
			End If
			
			'XX �y�[�W���肳�ꂽ�ꍇ�̑Ώ�
		ElseIf WM_WLS_PAGE_END = WM_WLS_PAGE_CLICK_NUM + 1 Then 
			
			For I = LST.Items.Count - 1 To WM_WLS_LIST_CNT Step -1
				LST.Items.RemoveAt((I))
			Next 
		End If
		
	End Sub
	'2008/07/05 ADD START FKS)NAKATA
End Class