Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSHIN
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@���i����
	'*  �v���O�����h�c�@�F  WLSSHIN
	'*  �쐬�ҁ@�@�@�@�@�F�@ACE)���V
	'*  �쐬���@�@�@�@�@�F  2006.05.12
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'************************************************************************************
	'   Private�萔
	'************************************************************************************
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]
	
	'************************************************************************************
	'   Private�ϐ�
	'************************************************************************************
	'�E�B���hհ�ް�ݒ�ϐ�
	Private WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
	Private WM_WLS_CODELEN As Short '�J�n���i���ޓ��͕�����
	Private WM_WLS_HINNMALEN As Short '�^�����͕�����
	Private WM_WLS_HINNMBLEN As Short '�i���\��������
	' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
	Private WM_WLS_HINKBLEN As Short '���i�敪������
	Private WM_WLS_HINKBNMLEN As Short '���i�敪��������
	' === 20061205 === INSERT E -
	
	'�E�B���h�����g�p�ϐ�
	Private WM_WLS_MAX As Short '�P��ʂ̕\������
	Private WM_WLS_CODE As String '���i�R�[�h�����p
	Private WM_WLS_HINNMA As String '�^�������p
	Private WM_WLS_HINNK_S As String '���i���J�i�����p(�J�n)
	Private WM_WLS_HINNK_E As String '���i���J�i�����p(�I��)
	' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
	Private WM_WLS_HINKB As String '���i�敪
	' === 20061205 === INSERT E -
	Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Usr_Ody As U_Ody '�ް��ް����ð���
	Private DB_HINMTA_W As TYPE_DB_HINMTA
	Private Dyn_Open As Boolean '�_�C�i�Z�b�g��ԁiTrue:Open False:Close)
	' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
	Private bolInitWindow As Boolean '��ʏ������t���O(True:������)
	' === 20061205 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_FORM_INIT
	'   �T�v�F  ��ʏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		'=== �\���J�n�R�[�h�����ݒ� ===
		'''' UPD 2009/02/19  FKS) S.Nakajima    Start
		'        WM_WLS_CODELEN = 8
		WM_WLS_CODELEN = 10
		'''' UPD 2009/02/19  FKS) S.Nakajima    End
		WM_WLS_HINNMALEN = 30
		' === 20060902 === UPDATE S - ACE)Nagasawa
		'        WM_WLS_HINNMBLEN = 30
		WM_WLS_HINNMBLEN = 50
		' === 20060902 === UPDATE E -
		' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
		WM_WLS_HINKBLEN = 1
		WM_WLS_HINKBNMLEN = 6
		' === 20061205 === INSERT E -
		WM_WLS_MAX = 15 '��ʕ\������
		
		'�ϐ�������
		WLSHIN_RTNCODE = ""
		Call WLS_Clear()
		Dyn_Open = False
		
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_SetArray
	'   �T�v�F  ���X�g�ҏW
	'   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_HINMTA_W.HINCD, WM_WLS_CODELEN) & Space(2) & LeftWid(DB_HINMTA_W.HINNMA, WM_WLS_HINNMALEN) & Space(2) & LeftWid(DB_HINMTA_W.HINNMB, WM_WLS_HINNMBLEN)
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_TextSQL
	'   �T�v�F  ����sql�쐬
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL()
		
		Dim strSQL As String
		Dim intData As Short
		
		strSQL = ""
		' === 20081205 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'D        strSQL = strSQL & " Select HINCD "          '���i�R�[�h
		strSQL = strSQL & " Select "
		
		'�q���g��̕ҏW
		Select Case True
			'���͌����������Ȃ��ꍇ�A��L�[����
			Case Trim(WM_WLS_CODE) & Trim(WM_WLS_HINNMA) & Trim(WM_WLS_HINNK_S) & Trim(WM_WLS_HINKB) = ""
				If Trim(WLSHIN_SKHINGRP) <> "" Then
					strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA07) */ "
				Else
					strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA01) */ "
				End If
				'�J�i���w�肳��Ă���ꍇ�A�L�[�O�Q�Ō���
			Case Trim(WM_WLS_HINNK_S) <> ""
				strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA02) */ "
				
				'�J�n���i�R�[�h���w�肳��Ă���ꍇ�A��L�[�Ō���
			Case Trim(WM_WLS_CODE) <> ""
				strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA01) */ "
				
				'�^�����P�����݂̂ł̏ꍇ�͎�L�[�Ō���
			Case Len(Trim(WM_WLS_HINNMA)) = 1 And Trim(WM_WLS_CODE) & Trim(WM_WLS_HINNK_S) & Trim(WM_WLS_HINKB) = ""
				strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA01) */ "
				
				'��L�ȊO�̏ꍇ�͕ҏW�Ȃ��i�L�[�O�U���g�p�����H�H�j
			Case Else
				
		End Select
		
		strSQL = strSQL & "        HINCD " '���i�R�[�h
		' === 20081205 === UPDATE E - ACE)Nagasawa
		strSQL = strSQL & "      , HINNMA " '�^��
		strSQL = strSQL & "      , HINNMB " '���i��
		' === 20060726 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "      , HINNK " '���i���J�i
		' === 20060726 === INSERT E -
		strSQL = strSQL & "   from HINMTA "
		strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    and DSPKB    = '" & gc_strDSPKB_OK & "' "
		'        strSQL = strSQL & "    and MNTENDKB = '" & gc_strMNTENDKB_NML & "' "
		'        strSQL = strSQL & "    and SLENDKB  = '" & gc_strSLENDKB_NML & "' "
		'        strSQL = strSQL & "    and JODSTPKB = '" & gc_strJODSTPKB_NML & "' "
		
		'���i�R�[�h����
		If Trim(WM_WLS_CODE) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
			'            strSQL = strSQL & "    and HINCD >=   '" & WM_WLS_CODE & "'"
			strSQL = strSQL & "    and HINCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
			' === 20080929 === UPDATE E -
		End If
		
		'�^������(�����܂�����)
		If Trim(WM_WLS_HINNMA) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
			'            strSQL = strSQL & "    and HINNMA LIKE '%" & WM_WLS_HINNMA & "%'"
			strSQL = strSQL & "    and HINNMA LIKE '%" & CF_Ora_String(WM_WLS_HINNMA, CF_Ctr_AnsiLenB(WM_WLS_HINNMA)) & "%'"
			' === 20080929 === UPDATE E -
		End If
		
		'���i���J�i����
		If Trim(WM_WLS_HINNK_S) <> "" Then
			strSQL = strSQL & "    and HINNK >= '" & WM_WLS_HINNK_S & "' And HINNK < '" & WM_WLS_HINNK_E & "'"
		End If
		
		' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
		'���i�敪����
		If Trim(WM_WLS_HINKB) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
			'            strSQL = strSQL & "    and HINKB  = '" & WM_WLS_HINKB & "' "
			strSQL = strSQL & "    and HINKB  = '" & CF_Ora_String(WM_WLS_HINKB, CF_Ctr_AnsiLenB(WM_WLS_HINKB)) & "' "
			' === 20080929 === UPDATE E -
		End If
		' === 20061205 === INSERT E -
		
		' === 20061026 === INSERT S - FKS)KUMEDA
		If Trim(WLSHIN_SKHINGRP) <> "" Then
			' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
			'            strSQL = strSQL & "    and SKHINGRP = '" & WLSHIN_SKHINGRP & "' "
			strSQL = strSQL & "    and SKHINGRP = '" & CF_Ora_String(WLSHIN_SKHINGRP, CF_Ctr_AnsiLenB(WLSHIN_SKHINGRP)) & "' "
			' === 20080929 === UPDATE E -
		End If
		' === 20061026 === INSERT E
		
		' === 20060828 === INSERT S - ACE)Sejima ���{�敪�Ή�
		' === 20060829 === UPDATE S - ACE)Nagasawa
		'        '���{�敪�����i����ʓ��͍��ڂłȂ��j
		'        If Trim(WLSHIN_KHNKB) <> "" Then
		'            strSQL = strSQL & "    and KHNKB = '" & WLSHIN_KHNKB & "'"
		'        End If
		
		'�{���i�̂݌����i����ʓ��͍��ڂłȂ��j
		If Trim(WLSHIN_KHNSEARCH) <> "1" Then
			strSQL = strSQL & "    and KHNKB = '" & gc_strKHNKB_HON & "'"
		End If
		
		' === 20060829 === UPDATE E -
		' === 20060828 === INSERT E
		
		'�Z�b�g�A�b�v�󒍓o�^�A�����͕��i���i�}�X�^�����킹�Č���
		If Trim(WLSHIN_BHNSEARCH) = "1" Then
			strSQL = strSQL & " union " '���i�R�[�h
			strSQL = strSQL & " Select HINCD " '���i�R�[�h
			strSQL = strSQL & "      , HINNMA " '�^��
			strSQL = strSQL & "      , HINNMB " '���i��
			' === 20060726 === INSERT S - ACE)Nagasawa
			strSQL = strSQL & "      , HINNK " '���i���J�i
			' === 20060726 === INSERT E -
			strSQL = strSQL & "   from BHNMTA "
			strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
			strSQL = strSQL & "    and DSPKB    = '" & gc_strDSPKB_OK & "' "
			strSQL = strSQL & "    and MNTENDKB = '" & gc_strMNTENDKB_NML & "' "
			strSQL = strSQL & "    and SLENDKB  = '" & gc_strSLENDKB_NML & "' "
			strSQL = strSQL & "    and JODSTPKB = '" & gc_strJODSTPKB_NML & "' "
			
			'���i�R�[�h����
			If Trim(WM_WLS_CODE) <> "" Then
				' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
				'                strSQL = strSQL & "    and HINCD >=   '" & WM_WLS_CODE & "'"
				strSQL = strSQL & "    and HINCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
				' === 20080929 === UPDATE E -
			End If
			
			'�^������(�����܂�����)
			If Trim(WM_WLS_HINNMA) <> "" Then
				' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
				'                strSQL = strSQL & "    and HINNMA LIKE '%" & WM_WLS_HINNMA & "%'"
				strSQL = strSQL & "    and HINNMA LIKE '%" & CF_Ora_String(WM_WLS_HINNMA, CF_Ctr_AnsiLenB(WM_WLS_HINNMA)) & "%'"
				' === 20080929 === UPDATE E -
			End If
			
			'���i���J�i����
			If Trim(WM_WLS_HINNK_S) <> "" Then
				strSQL = strSQL & "    and HINNK >= '" & WM_WLS_HINNK_S & "' And HINNK < '" & WM_WLS_HINNK_E & "'"
			End If
			
			' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
			'���i�敪����
			If Trim(WM_WLS_HINKB) <> "" Then
				' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
				'                strSQL = strSQL & "    and HINKB  = '" & WM_WLS_HINKB & "' "
				strSQL = strSQL & "    and HINKB  = '" & CF_Ora_String(WM_WLS_HINKB, CF_Ctr_AnsiLenB(WM_WLS_HINKB)) & "' "
				' === 20080929 === UPDATE E -
			End If
			' === 20061205 === INSERT E -
			
		End If
		'�\�[�g����
		strSQL = strSQL & "   order by "
		If Trim(WM_WLS_HINNK_S) <> "" Then
			'���i���J�i�����̏ꍇ
			strSQL = strSQL & "   HINNK "
			strSQL = strSQL & "  ,HINCD "
		Else
			'���i�R�[�h����,�^������
			strSQL = strSQL & "   HINCD "
		End If
		
		If Dyn_Open = True Then
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		Dyn_Open = True
		' === 20060726 === INSERT S - ACE)Nagasawa
		LST.Items.Clear()
		' === 20060726 === INSERT E -
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_DspNew
	'   �T�v�F  ���X�g�ҏW����(�������)
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		Dim Cnt As Integer
		
		Cnt = 0
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			'�擾���e�ޔ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_HINMTA_W.HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '���i�R�[�h
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_HINMTA_W.HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "") '�^��
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_HINMTA_W.HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "") '���i��
			
			'�\�����y�[�W
			If Cnt Mod WM_WLS_MAX = 0 Then
				WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
				ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
				Cnt = 0
				'�ŏI�y�[�W�ޔ�
				WM_WLS_LastPage = WM_WLS_Pagecnt
			End If
			
			'�\���������W�J
			Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)
			
			Cnt = Cnt + 1
			
			Call CF_Ora_MoveNext(Usr_Ody)
			
			If Cnt >= WM_WLS_MAX Then
				Exit Do
			End If
		Loop 
		
		'�ŏI�f�[�^���B
		If CF_Ora_EOF(Usr_Ody) = True Then
			WM_WLS_LastFL = True
		End If
		
		If Cnt > 0 Then
			'�y�[�W��\��
			Call WLS_DspPage()
		End If
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_DspPage
	'   �T�v�F  ���X�g�ҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspPage()
		Dim WL_Mode As Short
		Dim intCnt As Short
		
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		LST.Items.Clear()
		intCnt = 0
		Do While intCnt < WM_WLS_MAX
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt))
			End If
			intCnt = intCnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			' === 20061228 === INSERT S - ACE)Nagasawa
			On Error Resume Next
			' === 20061228 === INSERT E -
			LST.Focus()
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Kana_Init
	'   �T�v�F  �J�i�R���{�{�b�N�X������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Kana_Init()
		
		'�J�i���� Combo ������
		WLSKANA.Items.Add("�R�[�h")
		WLSKANA.Items.Add("�A�s      ��")
		WLSKANA.Items.Add("�J�s      ��")
		WLSKANA.Items.Add("�T�s      ��")
		WLSKANA.Items.Add("�^�s      ��")
		WLSKANA.Items.Add("�i�s      ��")
		WLSKANA.Items.Add("�n�s      ��")
		WLSKANA.Items.Add("�}�s      ��")
		WLSKANA.Items.Add("���s      ��")
		WLSKANA.Items.Add("���s      ��")
		WLSKANA.Items.Add("���s      ��")
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Clear
	'   �T�v�F  �ϐ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Clear()
		
		'��������
		WM_WLS_CODE = ""
		WM_WLS_HINNMA = ""
		WM_WLS_HINNK_S = ""
		WM_WLS_HINNK_E = ""
		' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
		WM_WLS_HINKB = ""
		' === 20061205 === INSERT E -
		
		'��ʕ\���y�[�W
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
		'�������ʕێ��z��
		ReDim WM_WLS_DSPArray(0)
		
	End Sub
	
	'
	'�ȉ��͉�ʃC�x���g����
	'
	'UPGRADE_WARNING: Form �C�x���g WLSHIN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSHIN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		
		' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
		If bolInitWindow = False Then
			Exit Sub
		Else
			bolInitWindow = False
		End If
		' === 20061205 === INSERT E -
		
		'WINDOW �ʒu�ݒ�
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WM_WLS_Dspflg = False
		
		'���ڏ�����
		Call WLS_Kana_Init()
		HD_CODE.Text = ""
		HD_KATA.Text = ""
		' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
		HD_HINKB.Text = ""
		HD_HINKBNM.Text = ""
		' === 20061205 === INSERT E -
		WLSKANA.SelectedIndex = 0
		LST.Items.Clear()
		WM_WLS_Dspflg = True
		
		ReDim WM_WLS_DSPArray(0)
		
		'''' UPD 2011/02/07  FKS) T.Yamamoto    Start    �A���[��FC11020701
		'��ʕ\�����Ɍ������Ȃ�
		'        '������ԑS���\��
		'        Call WLS_TextSQL
		'        Call WLS_DspNew
		'�f�t�H���g�Ő��i��ݒ�
		HD_HINKB.Text = "1"
		WM_WLS_HINKB = HD_HINKB.Text
		'���i�敪���ҏW
		Call F_Dsp_HD_HINKBNM()
		'''' UPD 2011/02/07  FKS) T.Yamamoto    End
		
		DblClickFl = False
		
		Me.Refresh()
		'''' UPD 2011/02/07  FKS) T.Yamamoto    Start    �A���[��FC11020701
		'' === 20060821 === UPDATE S - ACE)Nagasawa
		''        HD_KATA.SetFocus
		'' === 20061228 === INSERT S - ACE)Nagasawa
		'                On Error Resume Next
		'' === 20061228 === INSERT E -
		'        LST.SetFocus
		'' === 20060821 === UPDATE E -
		On Error Resume Next
		HD_KATA.Focus()
		'''' UPD 2011/02/07  FKS) T.Yamamoto    End
	End Sub
	
	Private Sub WLSHIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window�����ݒ�
		Call WLS_FORM_INIT()
		' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
		bolInitWindow = True
		' === 20061205 === INSERT E -
	End Sub
	
	Private Sub HD_CODE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CODE.Enter
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(HD_CODE.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(HD_CODE.Text) > 0 Then
			'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			'---------- 20061019 ACE MENTE START ----------
			'   Else
			'       HD_CODE.Text = Space$(HD_CODE.MaxLength)
			'---------- 20061019 ACE MENTE E N D ----------
		End If
		HD_CODE.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_CODE.SelectionLength = HD_CODE.Maxlength
	End Sub
	
	Private Sub HD_CODE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_CODE.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			
			'�����p�ϐ��Z�b�g
			Call WLS_Clear()
			WM_WLS_CODE = HD_CODE.Text
			' === 20061211 === INSERT S - ACE)Nagasawa
			WM_WLS_HINKB = HD_HINKB.Text
			' === 20061211 === INSERT E -
			
			'�����������N���A
			WLSKANA.SelectedIndex = 0
			HD_KATA.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_CODE_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_CODE.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		KeyAscii = Asc(UCase(Chr(KeyAscii)))
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'2008/08/13 START ADD FKS)HAYASHI-�A���[���FFC08081301
	'UPGRADE_WARNING: �C�x���g HD_KATA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_KATA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KATA.TextChanged
		
		Dim lngCnt As Integer
		
		lngCnt = HD_KATA.SelectionStart
		HD_KATA.Text = StrConv(HD_KATA.Text, VbStrConv.UpperCase)
		HD_KATA.SelectionStart = lngCnt
		
	End Sub
	'2008/08/13 E.N.D ADD FKS)HAYASHI-�A���[���FFC08081301
	
	Private Sub HD_KATA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KATA.Enter
		'---------- 20061019 ACE MENTE START ----------
		'   If LenWid(HD_KATA.Text) <= 0 Then
		'       HD_KATA.Text = Space$(HD_KATA.MaxLength)
		'   End If
		'---------- 20061019 ACE MENTE E N D ----------
		HD_KATA.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_KATA.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_KATA.SelectionLength = HD_KATA.Maxlength
	End Sub
	
	Private Sub HD_KATA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KATA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			
			'�����p�ϐ��Z�b�g
			Call WLS_Clear()
			WM_WLS_HINNMA = HD_KATA.Text
			' === 20061211 === INSERT S - ACE)Nagasawa
			WM_WLS_HINKB = HD_HINKB.Text
			' === 20061211 === INSERT E -
			
			'�����������N���A
			WLSKANA.SelectedIndex = 0
			HD_CODE.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSHIN_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KEYCODE
			'Enter�L�[����
			Case System.Windows.Forms.Keys.Return
				Call WLSOK_Click(WLSOK, New System.EventArgs())
				
				'Escape�L�[����
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
				
				'���L�[����
			Case System.Windows.Forms.Keys.Left
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
				
				'���L�[����
			Case System.Windows.Forms.Keys.Right
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSKANA.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSKANA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKANA.SelectedIndexChanged
		Dim W_BUF As Object
		If WM_WLS_Dspflg = False Then Exit Sub
		WM_WLS_Dspflg = False
		WM_WLS_Dspflg = True
		
		Call WLS_Clear()
		
		'�����p�ϐ��Z�b�g
		If WLSKANA.SelectedIndex > 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
			'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_HINNK_S = VB.Left(W_BUF, 1)
			'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_HINNK_E = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
			' === 20061211 === INSERT S - ACE)Nagasawa
			WM_WLS_HINKB = HD_HINKB.Text
			' === 20061211 === INSERT E -
			
			'�����������N���A
			HD_CODE.Text = ""
			HD_KATA.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
			' === 20061211 === INSERT S - ACE)Nagasawa
		Else
			If WLSKANA.SelectedIndex = 0 Then
				WM_WLS_HINNK_S = ""
				WM_WLS_HINNK_E = ""
				WM_WLS_HINKB = HD_HINKB.Text
				
				'�����������N���A
				HD_CODE.Text = ""
				HD_KATA.Text = ""
				WM_WLS_Dspflg = True
				
				Call WLS_TextSQL()
				Call WLS_DspNew()
			End If
			' === 20061211 === INSERT E -
		End If
		
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
		
		' === 20060728 === DELETE S - ACE)Furukawa
		'    Call WLS_DspNew
		' === 20060728 === DELETE E
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			' === 20060728 === UPDATE S - ACE)Furukawa
			'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
			' === 20060728 === UPDATE ��
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
			' === 20060728 === UPDATE E
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
		
		WLSHIN_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		If Dyn_Open = True Then
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
		Hide()
	End Sub
	
	' === 20061205 === INSERT S - ACE)Nagasawa ���������ɏ��i�敪�ǉ�
	Private Sub HD_HINKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINKB.Enter
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(HD_HINKB.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(HD_HINKB.Text) > 0 Then
			'UPGRADE_WARNING: TextBox �v���p�e�B HD_HINKB.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			HD_HINKB.Text = SSS_EDTITM_WLS(HD_HINKB.Text, HD_HINKB.Maxlength, WM_WLSKEY_ZOKUSEI)
		End If
		HD_HINKB.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_HINKB.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_HINKB.SelectionLength = HD_HINKB.Maxlength
	End Sub
	
	Private Sub HD_HINKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			' === 20061222 === INSERT S - ACE)Nagasawa
			'��ʕ\���y�[�W
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			
			'�������ʕێ��z��
			ReDim WM_WLS_DSPArray(0)
			' === 20061222 === INSERT E -
			
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox �v���p�e�B HD_HINKB.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			HD_HINKB.Text = SSS_EDTITM_WLS(HD_HINKB.Text, HD_HINKB.Maxlength, WM_WLSKEY_ZOKUSEI)
			
			'���i�敪���ҏW
			Call F_Dsp_HD_HINKBNM()
			
			WM_WLS_HINKB = HD_HINKB.Text
			
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_HINKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		KeyAscii = Asc(UCase(Chr(KeyAscii)))
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HINKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINKB.Leave
		
		WM_WLS_Dspflg = False
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_HINKB.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_HINKB.Text = SSS_EDTITM_WLS(HD_HINKB.Text, HD_HINKB.Maxlength, WM_WLSKEY_ZOKUSEI)
		
		'���i�敪���ҏW
		Call F_Dsp_HD_HINKBNM()
		
		'�����p�ϐ��Z�b�g
		WM_WLS_HINKB = HD_HINKB.Text
		
		WM_WLS_Dspflg = True
		
	End Sub
	
	Private Sub HD_HINKBNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINKBNM.Enter
		Call F_Ctl_HD_Focus()
	End Sub
	
	Private Function F_Dsp_HD_HINKBNM() As Short
		
		Dim Mst_Inf_MEI As TYPE_DB_MEIMTA
		
		'���i�敪���ҏW
		HD_HINKBNM.Text = ""
		If DSPMEIM_SEARCH(gc_strKEYCD_HINKB, HD_HINKB.Text, Mst_Inf_MEI) = 0 Then
			If Mst_Inf_MEI.DATKB = gc_strDATKB_USE Then
				'UPGRADE_WARNING: TextBox �v���p�e�B HD_HINKBNM.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
				HD_HINKBNM.Text = SSS_EDTITM_WLS(Mst_Inf_MEI.MEINMA, HD_HINKBNM.Maxlength, WM_WLSKEY_ZOKUSEI)
			End If
		End If
		
	End Function
	
	Private Function F_Ctl_HD_Focus() As Short
		If LST.Enabled = True Then
			' === 20061228 === INSERT S - ACE)Nagasawa
			On Error Resume Next
			' === 20061228 === INSERT E -
			LST.Focus()
		Else
			If WLSOK.Enabled = True Then
				' === 20061228 === INSERT S - ACE)Nagasawa
				On Error Resume Next
				' === 20061228 === INSERT E -
				WLSOK.Focus()
			End If
		End If
	End Function
	
	Private Sub CS_HINKB_Click()
		
		' === 20061228 === INSERT S - ACE)Nagasawa
		On Error Resume Next
		' === 20061228 === INSERT E -
		Me.HD_HINKB.Focus()
		
		WLSMEI_KEYCD = gc_strKEYCD_HINKB
		
		System.Windows.Forms.Application.DoEvents()
		
		WLS_MEI.ShowDialog()
		WLS_MEI.Close()
		
		'UPGRADE_NOTE: �I�u�W�F�N�g WLS_MEI ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		WLS_MEI = Nothing
		
		If Trim(WLSMEI_RTNMEICDA) <> "" Then
			'���i�敪�ҏW
			HD_HINKB.Text = Trim(WLSMEI_RTNMEICDA)
			
			Call HD_HINKB_KeyDown(HD_HINKB, New System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Return Or 0 * &H10000))
			
		End If
		
	End Sub
	' === 20061205 === INSERT E -
End Class