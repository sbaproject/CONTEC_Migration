Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSHIN
	Inherits System.Windows.Forms.Form
	'�ȉ��� �R�s�̐ݒ���s������
	Const WM_WLS_MSTKB As String = "5" '�}�X�^�敪�i1:���Ӑ� 2:�[�i�� 3:�S���� 4:�d���� 5:���i "":���ނȂ��j
	Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]
	Const WM_WLS_KanaINPUT As Boolean = False '�J�i���ړ��͎g�p�iTrue:���ړ��� False:�J�i�R���{�j
	
	'�����L�[No�i�g�p���Ȃ��ꍇ��-1��ݒ�j
	Const WM_WLS_NmaKey As Short = 1 '�^���R�[�h�̃\�[�g�L�[No
	Const WM_WLS_TextKey As Short = 2 '�J�n�R�[�h�̃\�[�g�L�[No
	Const WM_WLS_KanaKey As Short = 3 '�J�i�����̃\�[�g�L�[No+���L�[
	
	'�E�B���hհ�ް�ݒ�ϐ�
	Dim WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
	Dim WM_WLS_NMALEN As Short '�^�����͕�����
	Dim WM_WLS_LEN As Short '�J�n���ޓ��͕�����
	Dim WM_WLS_KANALEN As Short '�J�i���͕�����
	
	'�E�B���h�����g�p�ϐ�
	Dim WM_WLS_MAX As Short '�P��ʂ̕\������
	Dim WM_WLS_STTKEY As Object '�J�n�L�[
	Dim WM_WLS_ENDKEY As Object '�I���L�[
	Dim WM_WLS_KeyNo As Short 'Ҳ�̧�ٓǂݍ��݃L�[No
	Dim WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Dim WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Dim WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Dim WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Dim WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	Dim WM_WLS_INIT As Short '�E�B���h�����\���׸�(True or False)
	
	Dim WlsSelList As String
	Dim WlsHint As String
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	Dim DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07
	
	Private Sub WLS_FORM_INIT()
		'=== WINDOW �\���t�@�C���ݒ� ===
		WM_WLS_MFIL = DBN_HINMTA
		
		'=== �\���J�n�R�[�h�����ݒ� ===
		WM_WLS_NMALEN = Len(DB_HINMTA.HINNMA) 'LenWid �̓_��
		'    WM_WLS_LEN = Len(DB_HINMTA.HINCD)     'LenWid �̓_��
		WM_WLS_LEN = 8
		WM_WLS_KANALEN = Len(DB_HINMTA.HINNK) 'LenWid �̓_��
		WlsSelList = "HINCD, HINNMA, HINNMB, DATKB, KHNKB,DSPKB"
		
		'=== �k�`�a�d�k�ݒ� ===
		'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSLABEL = "���i���� �^�@�@��                       �i�@�@��                                          "
		'XXXXXXX8 XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5
		
		WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
		'HD_TEXT.Height = 330
		'    HD_NMA.MaxLength = WM_WLS_NMALEN
		'    HD_NMA.Width = (WM_WLS_NMALEN + 1) * 120
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_TEXT.Maxlength = WM_WLS_LEN
		HD_TEXT.Width = VB6.TwipsToPixelsX((WM_WLS_LEN + 1) * 120)
		WM_WLS_INIT = True
	End Sub
	
	Private Function WLS_DSP_CHECK() As Object
		Dim wkHINCD As String
		wkHINCD = DB_HINMTA.HINCD
		If DB_HINMTA.DATKB = "9" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLS_DSP_CHECK = SSS_NEXT
		Else
			If DB_HINMTA.KHNKB = "9" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_DSP_CHECK = SSS_NEXT
			Else
				If DB_HINMTA.DSPKB = "1" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WLS_DSP_CHECK = SSS_OK
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WLS_DSP_CHECK = SSS_NEXT
				End If
			End If
		End If
	End Function
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		Dim LeftWid As Object
		'====================================
		'   WINDOW ���אݒ�
		'====================================
		'UPGRADE_WARNING: �I�u�W�F�N�g LeftWid$(DB_HINMTA.HINNMB, 50) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LeftWid$(DB_HINMTA.HINNMA, 30) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LeftWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_HINMTA.HINCD, 8) & " " & LeftWid(DB_HINMTA.HINNMA, 30) & " " & LeftWid(DB_HINMTA.HINNMB, 50)
	End Sub
	
	Sub WLS_KbSQL()
		Dim AE_EditSQLText As Object
		WM_WLS_KeyNo = WM_WLS_TextKey
		''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
		'    WlsFromWhere = "From HINMTA Where HINKB = '" & WM_WLS_STTKEY & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_EditSQLText() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WlsFromWhere = "From HINMTA Where HINKB = '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		
		WlsOrderBy = "Order By HINCD"
		' === 20081205 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(WM_WLS_STTKEY) <> "" Then
			DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA06) */ " & WlsSelList & " " & WlsFromWhere & " AND DSPKB = '1' " & " UNION ALL " & "Select /*+ INDEX(HINMTA X_HINMTA06) */ " & WlsSelList & " " & WlsFromWhere & " AND DSPKB = '9' " & WlsOrderBy
		Else
			DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		End If
		' === 20081205 === UPDATE E
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Sub WLS_NmaSQL()
		Dim AE_EditSQLText As Object
		WM_WLS_KeyNo = WM_WLS_NmaKey
		''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		
		' === 20081205 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'D    WlsFromWhere = "From HINMTA Where HINNMA Like " & "'%" & WM_WLS_STTKEY & "%'"
		'D    If Trim(WLSHINKB.Text) <> "" Then
		'D        'DWlsFromWhere = WlsFromWhere & " and HINKB = '" & WLSHINKB.Text & "'"
		'D    End If
		'D
		'D    WlsOrderBy = "Order By HINCD"
		'D    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		
		Dim strSQL As String
		
		strSQL = " SELECT "
		
		'�q���g��̐ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Select Case True
			'�������Ȃ��ꍇ
			Case Trim(WM_WLS_STTKEY) = "" And Trim(WLSHINKB.Text) = ""
				strSQL = strSQL & " /*+ INDEX(HINMTA X_HINMTA01) */ "
				
				'��L�ȊO
			Case Else
				strSQL = strSQL & " /*+ INDEX(HINMTA X_HINMTA06) */ "
				
		End Select
		
		'�擾���ڕҏW
		strSQL = strSQL & WlsSelList
		
		'��������
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_EditSQLText() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & " FROM HINMTA WHERE HINNMA Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'" '�^��
		If Trim(WLSHINKB.Text) <> "" Then '���i�敪
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_EditSQLText() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & " AND HINKB = '" & AE_EditSQLText(WLSHINKB.Text) & "'"
		End If
		
		'SQL�̕ҏW�i���j�I��������j
		DB_SQLBUFF = strSQL
		DB_SQLBUFF = DB_SQLBUFF & " AND DSPKB = '1' "
		DB_SQLBUFF = DB_SQLBUFF & " UNION ALL "
		DB_SQLBUFF = DB_SQLBUFF & strSQL
		DB_SQLBUFF = DB_SQLBUFF & " AND DSPKB = '9' "
		DB_SQLBUFF = DB_SQLBUFF & " ORDER BY HINCD "
		' === 20081205 === UPDATE E
		
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Sub WLS_TextSQL()
		Dim AE_EditSQLText As Object
		WM_WLS_KeyNo = WM_WLS_TextKey
		''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
		'    WlsFromWhere = "From HINMTA Where HINCD >= '" & WM_WLS_STTKEY & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_EditSQLText() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WlsFromWhere = "From HINMTA Where HINCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		If Trim(WLSHINKB.Text) <> "" Then
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'        WlsFromWhere = WlsFromWhere & " and HINKB = '" & WLSHINKB.Text & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_EditSQLText() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WlsFromWhere = WlsFromWhere & " and HINKB = '" & AE_EditSQLText(WLSHINKB.Text) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		WlsOrderBy = "Order By HINCD"
		' === 20081205 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'D    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		
		'���i�敪�����͂���Ă���ꍇ
		If Trim(WLSHINKB.Text) <> "" Then
			DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA06) */ " & WlsSelList & " " & WlsFromWhere & " and DSPKB = '1' " & " UNION ALL " & " SELECT /*+ INDEX(HINMTA X_HINMTA06) */ " & WlsSelList & " " & WlsFromWhere & " and DSPKB = '9' " & WlsOrderBy
		Else
			DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA01) */ " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		End If
		' === 20081205 === UPDATE E
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Sub WLS_KanaSQL()
		Dim AE_EditSQLText As Object
		WM_WLS_KeyNo = WM_WLS_KanaKey
		''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
		'    WlsFromWhere = "From HINMTA Where HINNK >= '" & WM_WLS_STTKEY & "' And HINNK < '" & WM_WLS_ENDKEY & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_EditSQLText() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WlsFromWhere = "From HINMTA Where HINNK >= '" & WM_WLS_STTKEY & "' And HINNK < '" & AE_EditSQLText(WM_WLS_ENDKEY) & "'"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		'WlsOrderBy = "Order By HINNK, HINCD"
		If Trim(WLSHINKB.Text) <> "" Then
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'        WlsFromWhere = WlsFromWhere & " and HINKB = '" & WLSHINKB.Text & "'"
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_EditSQLText() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WlsFromWhere = WlsFromWhere & " and HINKB = '" & AE_EditSQLText(WLSHINKB.Text) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		WlsOrderBy = "Order By  HINCD"
		' === 20081205 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'D    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(WM_WLS_STTKEY) <> "" Then
			DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA02) */ " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		Else
			DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		End If
		' === 20081205 === UPDATE E
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Private Sub WLS_DspNew()
		Dim WL_Mode As Short
		Dim cnt As Short
		
		WL_Mode = 0
		cnt = 0
		Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_Mode = WLS_DSP_CHECK()
			If WL_Mode = SSS_OK Then
				If cnt = 0 Then
					WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
					WM_WLS_LastPage = WM_WLS_Pagecnt
					ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
				End If
				Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
				cnt = cnt + 1
			End If
			If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
				Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
			End If
		Loop 
		If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
		If cnt > 0 Then
			Call WLS_DspPage()
		Else
			LST.Items.Clear()
		End If
	End Sub
	
	Private Sub WLS_DspPage()
		Dim WL_Mode As Short
		Dim cnt As Short
		
		LST.Items.Clear()
		cnt = 0
		Do While cnt < WM_WLS_MAX
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt))
			End If
			cnt = cnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			LST.Focus()
		End If
	End Sub
	
	Sub WLS_Kana_Init()
		
		'�J�i���� Combo ������
		'���̈�s�����s���Ȃ���, WLSKANA.ListIndex = 0 �ŃG���[�ɂȂ�
		WLSKANA.Items.Add("�R�[�h")
		
		If WM_WLS_KanaKey < 1 Then
			'�J�i���������Ȃ�
			'UPGRADE_WARNING: �I�u�W�F�N�g PNL_USENM().Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PNL_USENM(3).Visible = False
			WLSKANA.Visible = False
			HD_Kana.Visible = False
		ElseIf WM_WLS_KanaINPUT Then 
			'�J�i����͍��ڂ̗L����
			WLSKANA.Visible = False
			HD_Kana.Visible = True
			HD_Kana.Width = WLSKANA.Width
			HD_Kana.Left = WLSKANA.Left
		Else
			WLSKANA.Items.Add("�A        ��")
			WLSKANA.Items.Add("�J        ��")
			WLSKANA.Items.Add("�T        ��")
			WLSKANA.Items.Add("�^        ��")
			WLSKANA.Items.Add("�i        ��")
			WLSKANA.Items.Add("�n        ��")
			WLSKANA.Items.Add("�}        ��")
			WLSKANA.Items.Add("��        ��")
			WLSKANA.Items.Add("��        ��")
			WLSKANA.Items.Add("��        ��")
		End If
	End Sub
	
	Private Sub COM_HINKB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_HINKB.Click
		Dim LenWid As Object
		Dim LeftWid As Object
		Dim wkHINKB As String
		Dim strSQL As String
		Dim W_BUF As Object
		
		WLS_MEI1.Text = "���i�敪�ꗗ"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 3, "077", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "077"
			If DB_MEIMTA.DATKB <> "9" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g LeftWid(DB_MEIMTA.MEINMA, 40) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LeftWid(DB_MEIMTA.MEICDA, 5) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		WLS_MEI1.ShowDialog()
		WLS_MEI1.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			WM_WLS_Dspflg = False
			System.Windows.Forms.Application.DoEvents()
			WM_WLS_Dspflg = True
			Exit Sub
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g LeftWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkHINKB = LeftWid(PP_SSSMAIN.SlistCom, 2) & Space(Len(DB_MEIMTA.MEICDA) - Len(LeftWid(PP_SSSMAIN.SlistCom, 2)))
			Call DB_GetEq(DBN_MEIMTA, 2, "077" & wkHINKB, BtrNormal)
			If DBSTAT = 0 Then
				WLSHINKB.Text = VB.Left(DB_MEIMTA.MEICDA, 2)
				'UPGRADE_ISSUE: LeftB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
				WLSHINKBNM.Text = LeftB$(DB_MEIMTA.MEINMA, 16)
				
				Select Case True
					
					Case Trim(HD_NMA.Text) <> ""
						WM_WLS_Dspflg = False
						HD_TEXT.Text = ""
						WLSKANA.SelectedIndex = 0
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_STTKEY = HD_NMA.Text
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_ENDKEY = HD_NMA.Text
						WM_WLS_Dspflg = True
						WM_WLS_Pagecnt = -1
						WM_WLS_LastPage = -1
						WM_WLS_LastFL = False
						ReDim WM_WLS_DSPArray(0)
						
						Call WLS_NmaSQL()
						Call WLS_DspNew()
					Case Trim(HD_TEXT.Text) <> ""
						WM_WLS_Dspflg = False
						'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
						HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_STTKEY = HD_TEXT.Text
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_ENDKEY = System.DBNull.Value
						WLSKANA.SelectedIndex = 0
						HD_NMA.Text = ""
						WM_WLS_Dspflg = True
						WM_WLS_Pagecnt = -1
						WM_WLS_LastPage = -1
						WM_WLS_LastFL = False
						ReDim WM_WLS_DSPArray(0)
						
						Call WLS_TextSQL()
						Call WLS_DspNew()
					Case WLSKANA.SelectedIndex > 0
						HD_TEXT.Text = ""
						HD_NMA.Text = ""
						'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
						'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_STTKEY = VB.Left(W_BUF, 1)
						'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_ENDKEY = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
						ReDim WM_WLS_DSPArray(0)
						Call WLS_KanaSQL()
						Call WLS_DspNew()
						
					Case Else
						WM_WLS_Dspflg = False
						HD_TEXT.Text = ""
						WLSKANA.SelectedIndex = 0
						HD_NMA.Text = ""
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_STTKEY = WLSHINKB.Text
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						WM_WLS_ENDKEY = System.DBNull.Value
						WM_WLS_Dspflg = True
						WM_WLS_Pagecnt = -1
						WM_WLS_LastPage = -1
						WM_WLS_LastFL = False
						ReDim WM_WLS_DSPArray(0)
						
						Call WLS_KbSQL()
						Call WLS_DspNew()
				End Select
				'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
				PP_SSSMAIN.SlistCom = System.DBNull.Value
			Else
				Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '���͋敪���Ⴂ�܂��B
				Call P_SetFocus(WLSHINKB)
				WLSHINKB.SelectionStart = 0
				WLSHINKB.SelectionLength = Len(WLSHINKB.Text)
			End If
		End If
		
	End Sub
	
	'
	'�ȉ��͉�ʃC�x���g����
	'
	'UPGRADE_WARNING: Form �C�x���g WLSHIN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSHIN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'=== WINDOW �ʒu�ݒ� ===
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		If WM_WLS_INIT = True Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_STTKEY = ""
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_ENDKEY = System.DBNull.Value
			HD_NMA.Text = ""
			HD_TEXT.Text = ""
			WM_WLS_Dspflg = False
			WLSKANA.SelectedIndex = 0
			HD_Kana.Text = ""
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			'''' UPD 2011/02/07  FKS) T.Yamamoto    Start    �A���[��FC11020701
			'��ʕ\�����Ɍ������Ȃ�
			'        Call WLS_TextSQL
			'        Call WLS_DspNew
			'�f�t�H���g�Ő��i��ݒ�
			WLSHINKB.Text = "1"
			Call DB_GetEq(DBN_MEIMTA, 2, "077" & WLSHINKB.Text, BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_ISSUE: LeftB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
				WLSHINKBNM.Text = LeftB$(DB_MEIMTA.MEINMA, 16)
			End If
			Call P_SetFocus(HD_NMA)
			'''' UPD 2011/02/07  FKS) T.Yamamoto    End
			WM_WLS_INIT = False
		End If
		
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = False
	End Sub
	
	Private Sub WLSHIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window�����ݒ�
		Call WLS_FORM_INIT()
		Call WLS_Kana_Init()
	End Sub
	
	Private Sub HD_Kana_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_Kana.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			HD_TEXT.Text = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_STTKEY = HD_Kana.Text
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_ENDKEY = Chr(Asc("�") + 1)
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_KanaSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_Kana_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_Kana.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii < Asc(" ") Then GoTo EventExitSub
		''2000/04/18 �J�i���͕����͈͂̌����C��
		''If KeyAscii < Asc("�") Or KeyAscii > Asc("�") Then
		If KeyAscii >= Asc("0") And KeyAscii <= Asc("9") Then GoTo EventExitSub
		If KeyAscii < Asc("�") Or KeyAscii > Asc("�") Then
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_NMA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_NMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NMA.TextChanged
		Dim S As Integer
		S = HD_NMA.SelectionStart
		HD_NMA.Text = StrConv(HD_NMA.Text, VbStrConv.UpperCase)
		HD_NMA.SelectionStart = S
	End Sub
	
	Private Sub HD_NMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NMA.Enter
		''    If LenWid(HD_NMA.Text) > 0 Then
		''        HD_NMA.Text = SSS_EDTITM_WLS(HD_NMA.Text, HD_NMA.MaxLength, WM_WLSKEY_ZOKUSEI)
		''    Else
		''        HD_NMA.Text = Space$(HD_NMA.MaxLength)
		''    End If
		HD_NMA.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_NMA.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_NMA.SelectionLength = HD_NMA.Maxlength
	End Sub
	
	Private Sub HD_NMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			HD_TEXT.Text = ""
			WLSKANA.SelectedIndex = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_STTKEY = HD_NMA.Text
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_ENDKEY = HD_NMA.Text
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_NmaSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_TEXT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_TEXT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.TextChanged
		Dim S As Integer
		S = HD_TEXT.SelectionStart
		HD_TEXT.Text = StrConv(HD_TEXT.Text, VbStrConv.UpperCase)
		HD_TEXT.SelectionStart = S
	End Sub
	
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		'''    If LenWid(HD_TEXT.Text) > 0 Then
		'''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
		'''    Else
		'''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
		'''    End If
		HD_TEXT.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_TEXT.SelectionLength = HD_TEXT.Maxlength
	End Sub
	
	Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_STTKEY = HD_TEXT.Text
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_ENDKEY = System.DBNull.Value
			WLSKANA.SelectedIndex = 0
			HD_NMA.Text = ""
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = True
		Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KEYCODE
			Case System.Windows.Forms.Keys.Return
				Call WLSOK_Click(WLSOK, New System.EventArgs())
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case System.Windows.Forms.Keys.Left '���L�[
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
			Case System.Windows.Forms.Keys.Right '���L�[
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
	End Sub
	
	Private Sub WLSHINKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSHINKB.Enter
		Dim LenWid As Object
		WLSHINKB.SelectionStart = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WLSHINKB.SelectionLength = LenWid(DB_HINMTA.HINKB)
	End Sub
	
	Private Sub WLSHINKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSHINKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim LenWid As Object
		Dim i As Object
		Dim STAT As Short
		Dim wkHINKB As String
		Dim strSQL As String
		Dim W_BUF As Object
		
		Select Case KEYCODE
			Case 13
				WM_WLS_Dspflg = False
				WLSHINKB.Text = SSS_EDTITM_WLS(WLSHINKB.Text, LenWid(DB_HINMTA.HINKB), "0")
				WLSHINKB.SelectionStart = 0
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLSHINKB.SelectionLength = LenWid(DB_HINMTA.HINKB)
				If Trim(WLSHINKB.Text) = "" Then
					WM_WLS_Dspflg = False
					WLSHINKB.Text = ""
					WLSHINKBNM.Text = ""
					'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WM_WLS_STTKEY = VB6.Format(HD_TEXT.Text)
					WLSKANA.SelectedIndex = 0
					HD_NMA.Text = ""
					WM_WLS_Dspflg = True
					WM_WLS_Pagecnt = -1
					WM_WLS_LastPage = -1
					WM_WLS_LastFL = False
					ReDim WM_WLS_DSPArray(0)
					
					Call WLS_TextSQL()
					Call WLS_DspNew()
				Else
					wkHINKB = WLSHINKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSHINKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
					Call DB_GetEq(DBN_MEIMTA, 2, "077" & wkHINKB, BtrNormal)
					If DBSTAT = 0 Then
						WLSHINKB.Text = VB.Left(DB_MEIMTA.MEICDA, 2)
						'UPGRADE_ISSUE: LeftB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
						WLSHINKBNM.Text = LeftB$(DB_MEIMTA.MEINMA, 16)
						Select Case True
							
							Case Trim(HD_NMA.Text) <> ""
								WM_WLS_Dspflg = False
								HD_TEXT.Text = ""
								WLSKANA.SelectedIndex = 0
								'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								WM_WLS_STTKEY = HD_NMA.Text
								'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								WM_WLS_ENDKEY = HD_NMA.Text
								WM_WLS_Dspflg = True
								WM_WLS_Pagecnt = -1
								WM_WLS_LastPage = -1
								WM_WLS_LastFL = False
								ReDim WM_WLS_DSPArray(0)
								
								Call WLS_NmaSQL()
								Call WLS_DspNew()
							Case Trim(HD_TEXT.Text) <> ""
								WM_WLS_Dspflg = False
								'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
								HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
								'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								WM_WLS_STTKEY = HD_TEXT.Text
								'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								WM_WLS_ENDKEY = System.DBNull.Value
								WLSKANA.SelectedIndex = 0
								HD_NMA.Text = ""
								WM_WLS_Dspflg = True
								WM_WLS_Pagecnt = -1
								WM_WLS_LastPage = -1
								WM_WLS_LastFL = False
								ReDim WM_WLS_DSPArray(0)
								
								Call WLS_TextSQL()
								Call WLS_DspNew()
							Case WLSKANA.SelectedIndex > 0
								HD_TEXT.Text = ""
								HD_NMA.Text = ""
								'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
								'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								WM_WLS_STTKEY = VB.Left(W_BUF, 1)
								'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								WM_WLS_ENDKEY = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
								ReDim WM_WLS_DSPArray(0)
								Call WLS_KanaSQL()
								Call WLS_DspNew()
								
							Case Else
								WM_WLS_Dspflg = False
								HD_TEXT.Text = ""
								WLSKANA.SelectedIndex = 0
								HD_NMA.Text = ""
								'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								WM_WLS_STTKEY = WLSHINKB.Text
								'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								WM_WLS_ENDKEY = System.DBNull.Value
								WM_WLS_Dspflg = True
								WM_WLS_Pagecnt = -1
								WM_WLS_LastPage = -1
								WM_WLS_LastFL = False
								ReDim WM_WLS_DSPArray(0)
								
								Call WLS_KbSQL()
								Call WLS_DspNew()
						End Select
					Else
						Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '���͋敪���Ⴂ�܂��B
						Call P_SetFocus(WLSHINKB)
						WLSHINKB.SelectionStart = 0
						WLSHINKB.SelectionLength = Len(WLSHINKB.Text)
						
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
	
	'UPGRADE_WARNING: �C�x���g WLSKANA.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSKANA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKANA.SelectedIndexChanged
		Dim W_BUF As Object
		If WM_WLS_Dspflg = False Then Exit Sub
		WM_WLS_Dspflg = False
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		ReDim WM_WLS_DSPArray(0)
		
		If WLSKANA.SelectedIndex > 0 Then
			HD_TEXT.Text = ""
			HD_NMA.Text = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
			'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_STTKEY = VB.Left(W_BUF, 1)
			'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_ENDKEY = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
			Call WLS_KanaSQL()
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_STTKEY = VB6.Format(HD_TEXT.Text)
			Call WLS_TextSQL()
		End If
		Call WLS_DspNew()
	End Sub
	
	Private Sub WLSKANA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKANA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = True
			Call WLSKANA_SelectedIndexChanged(WLSKANA, New System.EventArgs())
		Else
			WM_WLS_Dspflg = False
		End If
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
		Else
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_DspPage()
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
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
			Call WLS_DspPage()
		End If
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
		Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		'Unload Me
		Hide()
	End Sub
	
	Private Sub P_SetFocus(ByRef objCtl As System.Windows.Forms.Control)
		
		On Error Resume Next
		objCtl.Focus()
		
	End Sub
End Class