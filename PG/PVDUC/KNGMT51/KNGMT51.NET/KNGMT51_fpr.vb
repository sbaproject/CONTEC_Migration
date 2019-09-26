Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(92 + 6 + 0 + 1) As clsCP
	Public CL_SSSMAIN(92) As Short
	Public CQ_SSSMAIN(8) As String
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	'�r���������������������������������������������������������r
	'�����������`�F�b�N���s�t���O
	Public gv_bolInit As Boolean '������������True(�`�F�b�N�Ȃ��j�@����ȊO��False
	Public gv_bolKNGMT51_INIT As Boolean '��ʏ������t���O�iTrue:�ύX����j
	' === 20060801 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���E����W�\�����̕s��Ή�
	Public gv_bolKNGMT51_LF_Enable As Boolean 'LF�������s�t���O(False�F���s���Ȃ�)
	Public gv_bolKeyFlg As Boolean
	' === 20060801 === INSERT E
	' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
	Public gv_bolUpdFlg As Boolean
	' === 20060808 === INSERT E
	Public gv_bolMeiErrFlg As Boolean '���̃}�X�^�ƌ��т��f�[�^���Ȃ��G���[
	
	Public Structure KNGMT51_TYPE_KNGMTB
		Dim UPDKB As String '���[�h
		Dim DATKB As String '�폜�敪
		Dim KNGGRCD As String '�����O���[�v
		Dim PGID As String '�v���O�����h�c
		Dim MEINMA As String '�v���O������
		Dim UPDFLG As String '�X�V�����ύX�\�t���O
		Dim UPDAUTH As String '�X�V����
		Dim PRTFLG As String '��������ύX�\�t���O
		Dim PRTAUTH As String '�������
		Dim FILEFLG As String '�t�@�C���o�͌����ύX�\�t���O
		Dim FILEAUTH As String '�t�@�C���o�͌���
		Dim SALTFLG As String '�̔��P���ύX�����ύX�\�t���O
		Dim SALTAUTH As String '�̔��P���ύX����
		Dim HDNTFLG As String '�����P���ύX�����ύX�\�t���O
		Dim HDNTAUTH As String '�����P���ύX����
		Dim SAPMFLG As String '�̔��v��N���v��C�������ύX�\�t���O
		Dim SAPMAUTH As String '�̔��v��N���v��C������
		' 2006/11/15  ADD START  KUMEDA
		Dim UPDATE As String '�X�V�t���O
		' 2006/11/15  ADD END
	End Structure
	'�����}�X�^���
	Public KNGMT51_KNGMTB_Inf As KNGMT51_TYPE_KNGMTB
	
	'�y�[�W���
	Public MaxPageNum As Short '���ׂ̍ő�y�[�W��
	Public NowPageNum As Short '���ׂ̌��݂̃y�[�W��
	Public MinPageNum As Short '���ׂ̍ŏ��y�[�W��
	
	'�����O���[�v
	Public pv_KNGMT51_KNGGRCD As String
	
	'���͎Ҍ���
	Public pv_InpTan_KNG As Boolean 'True:�������� False:�����Ȃ�
	
	'���[�h
	Public Const UPDKB_INS As String = "�ǉ�"
	Public Const UPDKB_UPD As String = "�X�V"
	Public Const UPDKB_DEL As String = "�폜"
	
	'��ԍ�
	Private Const pc_COL_UPDKB As Short = 1 '���[�h
	Private Const pc_COL_PGID As Short = 2 '�v���O�����h�c
	Private Const pc_COL_MEINMA As Short = 3 '�v���O������
	' 2006/11/21  CHG START  KUMEDA
	'Private Const pc_COL_UPDAUTH        As Integer = 4      '�X�V
	'Private Const pc_COL_PRTAUTH        As Integer = 5      '���
	'Private Const pc_COL_FILEAUTH       As Integer = 6      '�t�@�C���o��
	'Private Const pc_COL_SALTAUTH       As Integer = 7      '�̔��P���ύX
	'Private Const pc_COL_HDNTAUTH       As Integer = 8      '�����P���ύX
	'Private Const pc_COL_SAPMAUTH       As Integer = 9      '�̔��v��N���v��C��
	'Private Const pc_COL_UPDATE         As Integer = 10     '�X�V�t���O
	Private Const pc_COL_DATKB As Short = 4 '�N��
	Private Const pc_COL_UPDAUTH As Short = 5 '�X�V
	Private Const pc_COL_PRTAUTH As Short = 6 '���
	Private Const pc_COL_FILEAUTH As Short = 7 '�t�@�C���o��
	Private Const pc_COL_SALTAUTH As Short = 8 '�̔��P���ύX
	Private Const pc_COL_HDNTAUTH As Short = 9 '�����P���ύX
	Private Const pc_COL_SAPMAUTH As Short = 10 '�̔��v��N���v��C��
	Private Const pc_COL_UPDATE As Short = 11 '�X�V�t���O
	' 2006/11/21  CHG END
	'
	Private pv_bolMEISAI_INPUT As Boolean '���ד��̓t���O(True:���͂���j
	Private pv_intMeisaiCnt As Short '���͖��א��i�X�V���g�p�j
	Private pv_bolInput_Bef_Row As Boolean '�O�s���̓t���O�iTrue:���͍ρj
	
	'���͒l
	Private Const pv_POS As String = "1" '��
	Private Const pv_INPOS As String = "9" '�s��
	
	'
	Private Const pv_Pgid_Keycode As String = "068" '���̃}�X�^�̃v���O����ID�R�[�h
	'�d���������������������������������������������������������d
	
	''**�����֐��֘A Start **
	'//�ߒl
	Public Const CHK_OK As Short = 0 '����
	Public Const CHK_WARN As Short = 1 '�x��
	Public Const CHK_ERR_NOT_INPUT As Short = 10 '�����̓G���[
	Public Const CHK_ERR_ELSE As Short = 11 '���̑��G���[
	
	'F_Chk_Jge_Action�֐��p
	Public Const CHK_KEEP As Short = 0 '�`�F�b�N���s
	Public Const CHK_STOP As Short = 1 '�`�F�b�N���f
	
	'**�����֐��֘A End  **
	
	'//F_Set_Next_Focus�������[�h
	Public Const NEXT_FOCUS_MODE_KEYRETURN As Short = 1 'KEYRETURN�Ɠ��l�̐���
	Public Const NEXT_FOCUS_MODE_KEYRIGHT As Short = 2 'KEYRIGHT�Ɠ��l�̐���
	'======================= �ύX���� 2006.07.02 Start =================================
	Public Const NEXT_FOCUS_MODE_KEYDOWN As Short = 3 'KEYDOWN�Ɠ��l�̐���
	'======================= �ύX���� 2006.07.02 End =================================
	'//F_Set_Befe_Focus�������[�h
	Public Const BEFE_FOCUS_MODE_KEYLEFT As Short = 4 'KEYLEFT�Ɠ��l�̐���
	Public Const BEFE_FOCUS_MODE_KEYUP As Short = 5 'KEYUP�Ɠ��l�̐���
	'//F_Dsp_Item_Detail�������[�h
	Public Const DSP_SET As Short = 0 '�\��
	Public Const DSP_CLR As Short = 1 '�N���A
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_KNG_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KNG_SQL() As String
		
		Dim strSQL As String
		
		'�����r�p�k���s
		strSQL = ""
		'CHG START FKS)INABA 2009/10/08 *************************************************************
		'�A���[��FC09101403
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     NVL(KNG.DATKB,9) DATKB " '�`�\�폜�敪
		strSQL = strSQL & "    ,KNG.KNGGRCD " '�����O���[�v
		strSQL = strSQL & "    ,NVL(KNG.PGID,MEI.MEICDA) PGID" '�v���O�����h�c
		strSQL = strSQL & "    ,MEI.MEINMA " '�v���O������
		strSQL = strSQL & "    ,DECODE(MEI.MEISUA,1,'1','9') UPDFLG" '�X�V�����ύX�\�t���O
		strSQL = strSQL & "    ,NVL(KNG.UPDAUTH,'9') UPDAUTH" '�X�V����
		strSQL = strSQL & "    ,DECODE(MEI.MEISUB,1,'1','9') PRTFLG" '��������ύX�\�t���O
		strSQL = strSQL & "    ,NVL(KNG.PRTAUTH,'9') PRTAUTH" '�������
		strSQL = strSQL & "    ,DECODE(MEI.MEISUC,1,'1','9') FILEFLG " '�t�@�C���o�͌����ύX�\�t���O
		strSQL = strSQL & "    ,NVL(KNG.FILEAUTH,'9') FILEAUTH" '�t�@�C���o�͌���
		strSQL = strSQL & "    ,DECODE(MEI.MEIKBA,'1','1','9') SALTFLG " '�̔��P���ύX�����ύX�\�t���O
		strSQL = strSQL & "    ,NVL(KNG.SALTAUTH,'9') SALTAUTH" '�̔��P���ύX����
		strSQL = strSQL & "    ,DECODE(MEI.MEIKBB,'1','1','9') HDNTFLG " '�����P���ύX�����ύX�\�t���O
		strSQL = strSQL & "    ,NVL(KNG.HDNTAUTH,'9') HDNTAUTH" '�����P���ύX����
		strSQL = strSQL & "    ,DECODE(MEI.MEIKBC,'1','1','9') SAPMFLG " '�̔��v��N���v��C�������ύX�\�t���O
		strSQL = strSQL & "    ,NVL(KNG.SAPMAUTH,'9') SAPMAUTH" '�̔��v��N���v��C������
		strSQL = strSQL & "    ,KNG.WRTDT " '�X�V���t
		strSQL = strSQL & "    ,KNG.WRTTM " '�X�V����
		strSQL = strSQL & "    ,KNG.UWRTDT " '�o�b�`�X�V���t
		strSQL = strSQL & "    ,KNG.UWRTTM " '�o�b�`�X�V����
		strSQL = strSQL & "    ,KNG.OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "    ,KNG.CLTID " '�N���C�A���g�h�c
		strSQL = strSQL & "    ,KNG.UOPEID " '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		strSQL = strSQL & "    ,KNG.UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & " From "
		strSQL = strSQL & "     KNGMTB KNG "
		strSQL = strSQL & "    ,MEIMTA MEI "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     KNG.KNGGRCD(+) = '" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' "
		strSQL = strSQL & " And MEI.KEYCD   = '" & pv_Pgid_Keycode & "' "
		strSQL = strSQL & " And MEI.MEICDA  = KNG.PGID(+) "
		strSQL = strSQL & " And MEI.MEICDA  <> '0000000             '"
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     MEI.DSPORD "
		
		'    strSQL = strSQL & " Select "
		'    strSQL = strSQL & "     KNG.DATKB "             '�`�\�폜�敪
		'    strSQL = strSQL & "    ,KNG.KNGGRCD "           '�����O���[�v
		'    strSQL = strSQL & "    ,KNG.PGID "              '�v���O�����h�c
		'    strSQL = strSQL & "    ,MEI.MEINMA "            '�v���O������
		'    strSQL = strSQL & "    ,KNG.UPDFLG "            '�X�V�����ύX�\�t���O
		'    strSQL = strSQL & "    ,KNG.UPDAUTH "           '�X�V����
		'    strSQL = strSQL & "    ,KNG.PRTFLG "            '��������ύX�\�t���O
		'    strSQL = strSQL & "    ,KNG.PRTAUTH "           '�������
		'    strSQL = strSQL & "    ,KNG.FILEFLG "           '�t�@�C���o�͌����ύX�\�t���O
		'    strSQL = strSQL & "    ,KNG.FILEAUTH "          '�t�@�C���o�͌���
		'    strSQL = strSQL & "    ,KNG.SALTFLG "           '�̔��P���ύX�����ύX�\�t���O
		'    strSQL = strSQL & "    ,KNG.SALTAUTH "          '�̔��P���ύX����
		'    strSQL = strSQL & "    ,KNG.HDNTFLG "           '�����P���ύX�����ύX�\�t���O
		'    strSQL = strSQL & "    ,KNG.HDNTAUTH "          '�����P���ύX����
		'    strSQL = strSQL & "    ,KNG.SAPMFLG "           '�̔��v��N���v��C�������ύX�\�t���O
		'    strSQL = strSQL & "    ,KNG.SAPMAUTH "          '�̔��v��N���v��C������
		'
		''2007/12/27 add-str T.KAWAMUKAI
		'    strSQL = strSQL & "    ,KNG.WRTDT "             '�X�V���t
		'    strSQL = strSQL & "    ,KNG.WRTTM "             '�X�V����
		'    strSQL = strSQL & "    ,KNG.UWRTDT "            '�o�b�`�X�V���t
		'    strSQL = strSQL & "    ,KNG.UWRTTM "            '�o�b�`�X�V����
		''2007/12/27 add-end T.KAWAMUKAI
		'
		'' === 20080902 === INSERT S - RISE)Izumi
		'    strSQL = strSQL & "    ,KNG.OPEID "             '�ŏI��Ǝ҃R�[�h
		'    strSQL = strSQL & "    ,KNG.CLTID "             '�N���C�A���g�h�c
		'    strSQL = strSQL & "    ,KNG.UOPEID "            '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		'    strSQL = strSQL & "    ,KNG.UCLTID "            '�N���C�A���g�h�c�i�o�b�`�j
		'' === 20080902 === INSERT E - RISE)Izumi
		'
		'    strSQL = strSQL & " From "
		'    strSQL = strSQL & "     KNGMTB KNG "
		'    strSQL = strSQL & "    ,MEIMTA MEI "
		'    strSQL = strSQL & " Where "
		'    strSQL = strSQL & "     KNG.KNGGRCD = '" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' "
		'    strSQL = strSQL & " And MEI.KEYCD   = '" & pv_Pgid_Keycode & "' "
		'    strSQL = strSQL & " And MEI.MEICDA  = KNG.PGID "
		'    strSQL = strSQL & " Order By "
		'    strSQL = strSQL & "     MEI.DSPORD "
		'CHG  END  FKS)INABA 2009/10/08 *************************************************************
		
		F_GET_KNG_SQL = strSQL
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Del_Process
	'   �T�v�F  �폜���C�����[�`��
	'   �����F�@pm_All        : �S�\����
	'   �ߒl�F�@�������ʃX�e�[�^�X
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Del_Process(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim intErrIdx As Short
		' === 20061031 === INSERT S - ACE)Nagasawa �r������̒ǉ�
		Dim strMsg As String
		' === 20061031 === INSERT E -
		' === 20070115 === INSERT S - ACE)Nagasawa �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		' === 20070115 === INSERT E -
		
		'20080821 ADD START RISE)Tanimura '�r������
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim ls_sql As String
		Dim intCnt As Short
		Dim intLoop As Short
		Dim intIndex As Short
		Dim bolTran As Boolean
		
		bolTran = False
		'20080821 ADD END   RISE)Tanimura
		
		On Error GoTo F_Ctl_Del_Process_Err
		
		intRet = CHK_ERR_ELSE
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'Windows�ɏ�����Ԃ�
		System.Windows.Forms.Application.DoEvents()
		
		'�폜�m�F
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_021, pm_All) = MsgBoxResult.No Then
			intRet = CHK_ERR_ELSE
			GoTo F_Ctl_Del_Process_End
		End If
		
		'    '�r���`�F�b�N���s��
		'    Select Case CF_Chk_Lock_EXCTBZ(gv_strUpdLockMsg)
		'        '����
		'        Case 0
		'
		'        '�r��������
		'        Case 1
		'            gv_bolUPDLock = True
		'            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_080, pm_All, "", gv_strUpdLockMsg)
		'            GoTo F_Ctl_Del_Process_Err
		'
		'        '�ُ�I��
		'        Case 9
		'            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_042, pm_All)
		'            GoTo F_Ctl_Del_Process_Err
		'
		'    End Select
		'' === 20061031 === INSERT E -
		
		'20080821 ADD START RISE)Tanimura '�r������
		'�g�����U�N�V�����̊J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'�{�^����\��
		FR_SSSMAIN.CM_Execute.Visible = False
		
		'�폜����
		intRet = F_Delete_Main(pm_All)
		Select Case intRet
			Case CHK_OK
				'����
				'�R�~�b�g
				Call CF_Ora_CommitTrans(gv_Oss_USR1)
				bolTran = False
				
			Case Else
				GoTo F_Ctl_Del_Process_Err
		End Select
		
		'�������b�Z�[�W
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_009, pm_All)
		
F_Ctl_Del_Process_End: 
		If bolTran Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		' �r������̒ǉ�
		Call CF_Unlock_EXCTBZ(strMsg)
		'  INSERT E -
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'�{�^���\��
		FR_SSSMAIN.CM_Execute.Visible = True
		
		F_Ctl_Del_Process = intRet
		Exit Function
		
F_Ctl_Del_Process_Err: 
		
		intRet = CHK_ERR_ELSE
		GoTo F_Ctl_Del_Process_End
		
	End Function
	
	'
	'ADD START FKS)INABA 2009/10/08 **********************************
	Public Function F_Delete_Main(ByRef pm_All As Cls_All) As Short
		Dim ls_sql As String
		Dim bolRet As Boolean
		On Error GoTo F_Delete_Main_ERR
		
		F_Delete_Main = -1
		ls_sql = ""
		ls_sql = ls_sql & " DELETE FROM KNGMTB "
		ls_sql = ls_sql & " WHERE KNGGRCD = '" & Trim(CF_Ora_String(pv_KNGMT51_KNGGRCD, 3)) & "' "
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, ls_sql)
		If bolRet = False Then
			GoTo F_Delete_Main_ERR
		End If
		
		F_Delete_Main = 0
		
		Exit Function
		
F_Delete_Main_ERR: 
		F_Delete_Main = -1
		Exit Function
	End Function
	'ADD  END  FKS)INABA 2009/10/08 **********************************
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA
	'   �T�v�F  �{�f�B���f�[�^�擾
	'   �����F  pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'CHG START FKS)INABA 2009/10/08 ********************************
	'�A���[��FC09101403
	Public Function F_GET_BD_DATA(ByRef pm_All As Cls_All, Optional ByRef ps_Syori As String = "") As Short
		'Public Function F_GET_BD_DATA(pm_All As Cls_All) As Integer
		'CHG  END  FKS)INABA 2009/10/08 ********************************
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		'ADD START FKS)INABA 2009/10/08 **************************
		'�A���[��FC09101403
		Dim ls_syori As String
		ls_syori = ps_Syori
		'ADD  END  FKS)INABA 2009/10/08 **************************
		
		On Error GoTo ERR_F_GET_BD_DATA
		
		F_GET_BD_DATA = -1
		'������
		strSQL = ""
		Err_Cd = ""
		
		'�����r�p�k����
		strSQL = F_GET_KNG_SQL()
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'�擾�f�[�^�Ȃ�
			F_GET_BD_DATA = 0
			Err_Cd = gc_strMsgKNGMT51_E_002
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			Exit Function
		Else
			'ADD START FKS)INABA 2009/10/08 **************************
			'�A���[��FC09101403
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, KNGGRCD, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If ls_syori = "F_Set_Next_Focus" And CF_Ora_GetDyn(Usr_Ody, "KNGGRCD", "") = "" Then
				Err_Cd = gc_strMsgKNGMT51_E_020
				Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			End If
			Err_Cd = ""
			'ADD  END  FKS)INABA 2009/10/08 **************************
			intCnt = 0
			Do Until CF_Ora_EOF(Usr_Ody) = True
				'�擾�S���R�[�h���{�f�B���ޔ�
				intCnt = intCnt + 1
				'�s�ǉ�
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				'�s���ڏ��R�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					
					.Bus_Inf.Selected = CStr(False) '�I��/��I��
					.Bus_Inf.UPDKB = UPDKB_UPD '���[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.KNGGRCD = CF_Ora_GetDyn(Usr_Ody, "KNGGRCD", "") '�����O���[�v
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.PGID = CF_Ora_GetDyn(Usr_Ody, "PGID", "") '�v���O�����h�c
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.MEINMA = CF_Ora_GetDyn(Usr_Ody, "MEINMA", "") '�v���O������
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.UPDFLG = CF_Ora_GetDyn(Usr_Ody, "UPDFLG", "") '�X�V�����ύX�\�t���O
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "") '�X�V����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.PRTFLG = CF_Ora_GetDyn(Usr_Ody, "PRTFLG", "") '��������ύX�\�t���O
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "") '�������
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.FILEFLG = CF_Ora_GetDyn(Usr_Ody, "FILEFLG", "") '�t�@�C���o�͌����ύX�\�t���O
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "") '�t�@�C���o�͌���
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SALTFLG = CF_Ora_GetDyn(Usr_Ody, "SALTFLG", "") '�̔��P���ύX�����ύX�\�t���O
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "") '�̔��P���ύX����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.HDNTFLG = CF_Ora_GetDyn(Usr_Ody, "HDNTFLG", "") '�����P���ύX�����ύX�\�t���O
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "") '�����P���ύX����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SAPMFLG = CF_Ora_GetDyn(Usr_Ody, "SAPMFLG", "") '�̔��v��N���v��C�������ύX�\�t���O
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "") '�̔��v��N���v��C������
					
					'2007/12/18 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.MOTO_WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�X�V���t
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.MOTO_WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�X�V����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.MOTO_UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") '�o�b�`�X�V���t
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.MOTO_UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") '�o�b�`�X�V����
					'2007/12/18 add-end M.SUEZAWA
					
					' === 20080902 === INSERT S - RISE)Izumi
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.MOTO_OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.MOTO_CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.MOTO_UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.MOTO_UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")
					' === 20080902 === INSERT E - RISE)Izumi
					
					'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
					'���[�h
					Wk_Index = CShort(FR_SSSMAIN.BD_UPDKB(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.UPDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'�v���O�����h�c
					Wk_Index = CShort(FR_SSSMAIN.BD_PGID(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.PGID, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'�v���O������
					Wk_Index = CShort(FR_SSSMAIN.BD_MEINMA(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.MEINMA, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					' 2006/11/21  ADD START  KUMEDA
					'�N��
					Wk_Index = CShort(FR_SSSMAIN.BD_DATKB(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.DATKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(3).Focus_Ctl = True
					' 2006/11/21  ADD END
					'�X�V
					Wk_Index = CShort(FR_SSSMAIN.BD_UPDAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.UPDAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(4).Focus_Ctl = True
					'���
					Wk_Index = CShort(FR_SSSMAIN.BD_PRTAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.PRTAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(5).Focus_Ctl = True
					'�t�@�C���o��
					Wk_Index = CShort(FR_SSSMAIN.BD_FILEAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.FILEAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(6).Focus_Ctl = True
					'�̔��P���ύX
					Wk_Index = CShort(FR_SSSMAIN.BD_SALTAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SALTAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(7).Focus_Ctl = True
					'�����P���ύX
					Wk_Index = CShort(FR_SSSMAIN.BD_HDNTAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.HDNTAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(8).Focus_Ctl = True
					'�̔��v��N���v��C��
					Wk_Index = CShort(FR_SSSMAIN.BD_SAPMAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SAPMAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(9).Focus_Ctl = True
					' 2006/11/15  ADD START  KUMEDA
					'�X�V�t���O
					Wk_Index = CShort(FR_SSSMAIN.BD_UPDATE(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.UPDATE, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(10).Focus_Ctl = True
					' 2006/11/15  ADD END
					'�Ώۍs�̏��
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_INPUT
				End With
				
				'�����R�[�h
				Call CF_Ora_MoveNext(Usr_Ody)
			Loop 
			'�s���\���̔z��� Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_GET_BD_DATA = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SET_BD_DATA
	'   �T�v�F  �{�f�B���f�[�^�擾
	'   �����F�@pm_All      :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SET_BD_DATA(ByRef pm_All As Cls_All) As Object
		'���וҏW
		'    Call CF_Body_Dsp(pm_All)
		Call F_Body_Dsp(pm_All)
		
	End Function
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Body_Dsp
	'   �T�v�F  �{�f�B������ʂɕҏW����
	'   �����F�@pm_All      :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Body_Dsp(ByRef pm_All As Cls_All) As Short
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Cur_Top_Index As Short
		Dim Fcs_Flg As Boolean
		Dim Index_Of_Window As Short
		Dim Index_Cnt As Short
		Dim Available_Flg As Boolean
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'���ו\���̉��
			
			'============================================================================
			'�ŏ㖾�ײ��ޯ���̍Đݒ�
			If pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 > UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
				'���݂̍ŏ㖾�ײ��ޯ�������ʕ\�������ꍇ��
				'�z�񐔂�����Ȃ��ꍇ
				'�ŏ㖾�ײ��ޯ����\���\�Ȉ�ԉ��̍s�ɐݒ�
				Cur_Top_Index = UBound(pm_All.Dsp_Body_Inf.Row_Inf) - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
				If Cur_Top_Index <= 0 Then
					Cur_Top_Index = 1
				End If
				pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
				If pm_All.Bd_Vs_Scrl Is Nothing = False Then
					'�c�X�N���[���o�[��ݒ�
					Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
				End If
			End If
			'============================================================================
			
			'�{�f�B�����ŏ���
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index >= 0 Then
					
					'pm_All.Dsp_Body_Inf�̍s�m�n���擾
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'���׍s�u���C�N
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'��ʍ��ڏڍ׏���ݒ�
					'�����ɂ���ĕύX����鍀�ڂ̂�
					Call CF_Dsp_Body_Inf_To_Dsp_Sub_Inf(pm_All.Dsp_Sub_Inf(Index_Wk).Detail, pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Item_Detail(Bd_Col_Index))
					
					'���ڂ̏�񂪕ύX���������R���g���[���ɐݒ�
					'��ݼ޲���Ă��N�������ɕҏW
					Call CF_Set_Item_Not_Change(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Value, pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					'�t�H�[�J�X�L���̔���
					Fcs_Flg = F_Jge_Focus(Index_Wk, pm_All, Available_Flg)
					'�t�H�[�J�X�̐���
					Call CF_Set_Item_Focus_Ctl(Fcs_Flg, pm_All.Dsp_Sub_Inf(Index_Wk))
					'ADD START FKS)INABA 2009/10/08 ************************************************
					'�A���[��FC09101403(���b�N����Ă���(�ړ��ł��Ȃ�)���ڂ̐F�ύX)
					If Fcs_Flg = False Then
						pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
					Else
						pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
					End If
					'���ڐF�̏����ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Index_Wk), ITEM_INITIAL_STATUS, pm_All, ITEM_COLOR_DEF)
					'ADD  END  FKS)INABA 2009/10/08 ************************************************
					'�f�[�^�L�s�m�n�̑ޔ�
					If Available_Flg = True Then
						Index_Of_Window = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					End If
				End If
			Next 
		End If
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Jge_Focus
	'   �T�v�F  �t�H�[�J�X�L���̔���
	'   �����F�@pm_All      :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Jge_Focus(ByRef pm_Index_Tag As Short, ByRef pm_All As Cls_All, ByRef pm_Av_Flg As Boolean) As Boolean
		
		Dim Bd_Index As Short
		Dim Tgt_Index As Short
		Dim Flg_Value As String
		
		'������
		F_Jge_Focus = False
		pm_Av_Flg = False
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(pm_Index_Tag), pm_All)
		
		'���ڂ��u���[�h�v�u�v���O�����h�c�v�u�v���O�������v�łȂ��ꍇ
		If (pm_All.Dsp_Sub_Inf(pm_Index_Tag).Ctl.Name <> FR_SSSMAIN.BD_UPDKB(1).Name) And (pm_All.Dsp_Sub_Inf(pm_Index_Tag).Ctl.Name <> FR_SSSMAIN.BD_PGID(1).Name) And (pm_All.Dsp_Sub_Inf(pm_Index_Tag).Ctl.Name <> FR_SSSMAIN.BD_MEINMA(1).Name) Then
			
			'�t���O�̒l���擾
			Select Case pm_All.Dsp_Sub_Inf(pm_Index_Tag).Ctl.Name
				' 2006/11/21  ADD START  KUMEDA
				Case FR_SSSMAIN.BD_DATKB(1).Name
					'�N��
					Flg_Value = "1"
					' 2006/11/21  ADD END
					
				Case FR_SSSMAIN.BD_UPDAUTH(1).Name
					'�X�V
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UPDFLG
					
				Case FR_SSSMAIN.BD_PRTAUTH(1).Name
					'���
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.PRTFLG
					
				Case FR_SSSMAIN.BD_FILEAUTH(1).Name
					'�t�@�C���o��
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FILEFLG
					
				Case FR_SSSMAIN.BD_SALTAUTH(1).Name
					'�̔��P���ύX
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SALTFLG
					
				Case FR_SSSMAIN.BD_HDNTAUTH(1).Name
					'�����P���ύX
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HDNTFLG
					
				Case FR_SSSMAIN.BD_SAPMAUTH(1).Name
					'�̔��v��N���v��C��
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SAPMFLG
					
			End Select
			
			
			'�Ώۍs�̏�Ԃ�������ԈȊO�̏ꍇ
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status <> BODY_ROW_STATE_DEFAULT Then
				If Flg_Value = pv_POS Then
					F_Jge_Focus = True
					pm_Av_Flg = True
				End If
				
				'�Ώۍs�̏�Ԃ��ŏI�����s�̏ꍇ
				If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
					pm_Av_Flg = False
				End If
			End If
		End If
		
	End Function
	' === 20060825 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Add_BlankRow
	'   �T�v�F  �󔒍s���ǉ�
	'   �����F�@pm_All                :�S�\����
	'   �ߒl�F�@�K�v�y�[�W��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Add_BlankRow(ByRef pm_All As Cls_All) As Short
		
		Dim Ret_Value As Short
		Dim intPage As Short
		Dim bolFind As Boolean
		Dim intBfrUBound As Short
		Dim intAfrUBound As Short
		Dim intIdx As Short
		
		Ret_Value = 0
		
		'������
		intBfrUBound = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		intAfrUBound = 0
		intPage = 0
		bolFind = False
		
		'�K�v�y�[�W�����擾
		'�i�y�[�W���ɏ������������ꍇ�́A������ "Or intPage > NN" ��ǉ��H�j
		Do Until bolFind = True
			'�C���N�������g
			intPage = intPage + 1
			'�y�[�W�������Ƃɍs���z��̏�����Z�o
			intAfrUBound = pm_All.Dsp_Base.Dsp_Body_Cnt * intPage
			'�s�\���̂̏���ȏ�ɂȂ�����y�[�W����ޔ����A�u���C�N
			' === 20060825 === UPDATE S
			'        If intAfrUBound >= intBfrUBound Then
			If intAfrUBound > intBfrUBound Then
				' === 20060825 === UPDATE E
				Ret_Value = intPage
				bolFind = True
			End If
		Loop 
		
		'�󔒍s����ǉ�
		If intAfrUBound > intBfrUBound Then
			'�s�ǉ�
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intAfrUBound)
			For intIdx = intBfrUBound + 1 To intAfrUBound
				'�s���ڏ��R�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intIdx))
				
			Next intIdx
		End If
		
		F_Ctl_Add_BlankRow = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Dsp_Body
	'   �T�v�F  �w�肳�ꂽ���ׂ̏����l��ݒ肷��
	'   �����F�@pm_Bd_Index     :���׍s�C���f�b�N�X
	'           pm_all          :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
		'�r���������������������������������������������������������r
		'    '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
		'    Call CF_Edi_Dsp_Body_Inf("9" _
		''                           , pm_All.Dsp_Sub_Inf(Wk_Index) _
		''                           , pm_Bd_Index _
		''                           , pm_All)
		'
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Item_Input_Aft
	'   �T�v�F  ��ʂō��ړ��͂��ꂽ�ꍇ�̌㏈�����s���܂�
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Input_Aft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index As Short
		
		'���ׂ̍č쐬���s��
		Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		'�r���������������������������������������������������������r
		'    '�s��ǉ����ꂽ���
		'    '�����l��ǉ������s�ɑ΂��ă��[�v���łP�s���s��
		'    '�����ł̍s�́ADsp_Body_Inf�̍s�I�I
		'    For Bd_Index = Row_Inf_Max_S To Row_Inf_Max_E
		'        Call F_Init_Dsp_Body(Bd_Index, pm_All)
		'    Next
		' === 20060825 === INSERT S
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD Then
			' 2006/11/15  CHG START  KUMEDA
			'        gv_bolKNGMT51_INIT = True
			Call F_SET_UPDFLG(pm_Dsp_Sub_Inf, pm_All)
			' 2006/11/15  CHG END
		End If
		' === 20060825 === INSERT E
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Befe_Focus
	'   �T�v�F  �O�̃t�H�[�J�X�ʒu�ݒ�(LEFT�Ȃ�)
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_Move_Flg         :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Befe_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True, Optional ByRef pm_Mode As Short = BEFE_FOCUS_MODE_KEYLEFT) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		' === 20060825 === UPDATE S
		'�������ޯ���擾
		If pm_Mode = BEFE_FOCUS_MODE_KEYUP Then
			If (pm_Dsp_Sub_Inf.Detail.Body_Index = 1) And (pm_Dsp_Sub_Inf.Ctl.Tag <> FR_SSSMAIN.BD_UPDAUTH(1).Tag) Then
				Trg_Index = CShort(FR_SSSMAIN.BD_UPDAUTH(1).Tag) + 1
			Else
				Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
			End If
		Else
			Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		End If
		' === 20060825 === UPDATE E
		
		'���̍��ڂ�����
		For Index_Wk = Trg_Index - 1 To 1 Step -1
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�t�b�^������{�f�B���ֈړ�����ꍇ
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					Index_Wk = Focus_Ctl_Ok_Fst_Idx
				End If
				
			End If
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
				'�{�f�B������w�b�_���ֈړ�����ꍇ
				If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
					' === 20060825 === DELATE S
					'            '���ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
					'
					'                '��ʂ̓��e��ޔ�
					'                Call CF_Body_Bkup(pm_All)
					'                '�ړ��\�s����ԏ�ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
					'                pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
					'                If pm_All.Bd_Vs_Scrl Is Nothing = False Then
					'                    '�c�X�N���[���o�[��ݒ�
					'                    Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
					'                End If
					'                '��ʃ{�f�B���̔z����Đݒ�
					'                Call CF_Dell_Refresh_Body_Inf(pm_All)
					'                '��ʕ\��
					'                'Call CF_Body_Dsp(pm_All)
					'                Call F_Body_Dsp(pm_All)
					'
					'                '���͉\�ȍŌ�̃C���f�b�N�X���擾
					'                Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
					'                If Focus_Ctl_Ok_Lst_Idx > 0 Then
					'                    Index_Wk = Focus_Ctl_Ok_Lst_Idx
					'                End If
					' === 20060825 === DELATE E
				End If
			End If
			
			'̫����ړ���OK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Then
					'���s�w�肪����ꍇ(��{����)
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'�ړ��t���O����
				pm_Move_Flg = True
				Exit For
			End If
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Next_Focus
	'   �T�v�F  ���̃t�H�[�J�X�ʒu�ݒ�(ENT�ARIGHT�Ȃ�)
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'           pm_Move_Flg         :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_Run_Flg          :���s�w��t���O�iT�F����AF�F�Ȃ��j
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Sta_Index As Short
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Bd_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		Dim Focus_Ctl_Ok_Fst_Idx_Wk As Short
		Dim Cur_Top_Index As Short
		
		Dim bolDsp As Boolean
		Dim bolAllChk As Boolean
		Dim RtnCode As Short
		
		bolDsp = False
		bolAllChk = False
		RtnCode = -1
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'�{�f�B��
			'Dsp_Body_Inf�̍s�m�n���擾
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
				'�ŏI�����s�̏ꍇ
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				
				If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
					'���͉\�ȍŏ��̍��ڂ̏ꍇ
					'���[�h�ɂ�茟���J�n�ʒu������
					Select Case pm_Mode
						'======================= �ύX���� 2006.07.02 Start =================================
						Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
							'KEYRETURN�AKEYDOWN�̏ꍇ
							'======================= �ύX���� 2006.07.02 End =================================
							'�����J�n�̓t�b�^���̍ŏ��̍��ڂ���
							Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
							
						Case NEXT_FOCUS_MODE_KEYRIGHT
							'KEYRIGHT�̏ꍇ
							'�������ޯ���擾
							'�����J�n�͑Ώۂ̍��ڂ̎�
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							
					End Select
				Else
					'�����J�n�͑Ώۂ̍��ڂ̎�
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
				
			Else
				'�ŏI�����s�ȊO�̏ꍇ
				If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
					'�\������Ă���ŏI�s�̏ꍇ
					'���͉\�ȍŌ�̃C���f�b�N�X���擾
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
					
					If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
						'���͉\�ȍŌ�̍��ڂ̏ꍇ
						' === 20060825 === INSERT S
						Select Case pm_Mode
							Case NEXT_FOCUS_MODE_KEYRETURN
								'�����J�n�̓t�b�^���̍ŏ��̍��ڂ���
								Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
								
							Case Else
								'�����J�n�͑Ώۂ̍��ڂ̐擪
								Sta_Index = CShort(FR_SSSMAIN.BD_UPDAUTH(pm_All.Dsp_Base.Dsp_Body_Cnt).Tag)
								
						End Select
						' === 20060825 === INSERT E
						' === 20060825 === DELETE S
						'                    If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
						'                    '�ŏI�����s�ȊO����ʏ�̍ŏI�s���ŏI����
						'                    '����ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
						'
						'                        '��ʂ̓��e��ޔ�
						'                        Call CF_Body_Bkup(pm_All)
						'                        '�ړ��\�s����ԉ��ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
						'                        pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						'                        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
						'                            '�c�X�N���[���o�[��ݒ�
						'                            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						'                        End If
						''======================= �ύX���� 2006.07.02 Start =================================
						'                        '��ʃ{�f�B���̔z����Đݒ�
						'                        Call CF_Dell_Refresh_Body_Inf(pm_All)
						''======================= �ύX���� 2006.07.02 End =================================
						'                        '��ʕ\��
						'                        'Call CF_Body_Dsp(pm_All)
						'                        Call F_Body_Dsp(pm_All)
						'
						'                        '���ׂP�ԉ��s�̓��͉\�ȍŏ��̃C���f�b�N�X���擾
						'                        Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
						'                        If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
						'                            '���ׂP�ԉ��s�̍ŏ��̍��ڂ̈�O���猟��
						'                            Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
						'                        Else
						'                            '�����J�n�͑Ώۂ̍��ڂ̎�
						'                            Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
						'                        End If
						'
						'                     Else
						'                    '����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
						'                        '�����J�n�͑Ώۂ̍��ڂ̎�
						'                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
						'                     End If
						' === 20060825 === DELETE E
					Else
						'���͉\�ȍŌ�̍��ڈȊO�̏ꍇ
						'�����J�n�͑Ώۂ̍��ڂ̎�
						Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
					End If
					
				Else
					'�ŏI�s�ȊO�ꍇ
					'�����J�n�͑Ώۂ̍��ڂ̎�
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
			End If
			
		Else
			'�{�f�B���ȊO
			'�����J�n�͑Ώۂ̍��ڂ̎�
			Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
		End If
		
		'���̍��ڂ�����
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�w�b�_������{�f�B���ֈړ�����ꍇ
				''' === 20060824 === INSERT S
				'�r���������������������������������������������������������r
				'�����O���[�v���ύX���ꂽ�ꍇ
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Value Then
					'�����O���[�v�̎擾
					pv_KNGMT51_KNGGRCD = Trim(FR_SSSMAIN.HD_KNGGRCD.Text)
					
					'��ʃ{�f�B��������
					Call F_Init_Clr_Dsp_Body(-1, pm_All)
					'CHG START FKS)INABA 2009/10/08 ********************************
					'�A���[��FC09101403
					RtnCode = F_GET_BD_DATA(pm_All, "F_Set_Next_Focus")
					'                RtnCode = F_GET_BD_DATA(pm_All)
					'CHG  END  FKS)INABA 2009/10/08 ********************************
					
					'���݂̃y�[�W��������
					NowPageNum = 1
					
					'�ŏ㖾�ײ��ޯ��������
					pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
					
					If RtnCode = 0 Then
						'�o�͂ł��閾�׃f�[�^������
						pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
						
						gv_bolMeiErrFlg = True
					Else
						pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
						
						gv_bolMeiErrFlg = False
					End If
					
					'���ׂ���ʂɕҏW
					Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(CShort(pm_Dsp_Sub_Inf.Ctl.Tag)), DSP_SET, pm_All)
					
					gv_bolKNGMT51_INIT = False
				End If
				
				'�d���������������������������������������������������������d
				''' === 20060824 === INSERT E
			End If
			
			'���ݑΏۈȊO
			If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) <> Index_Wk Then
				'̫����ړ���OK
				If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
					If pm_Run_Flg = True Then
						'���s�w�肪����ꍇ(��{����)
						'̫����ړ�
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					End If
					'�ړ��t���O����
					pm_Move_Flg = True
					Exit For
				End If
			End If
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Left_Next_Focus
	'   �T�v�F  Left�������̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_Move_Flg         :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Left_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Wk_Point As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			'���݂�÷�ď�̑I����Ԃ��擾
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'�l���������l�̏ꍇ
					'�P�����ڂ�I������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelStart = 0
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				Else
					'�l���������l�ȊO�̏ꍇ
					'�P�O�̍��ڂ�
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
					
				End If
			Else
				If Act_SelStart = 0 Then
					'�J�n�ʒu����ԍ��̏ꍇ
					'�P�O�̍��ڂ�
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
				Else
					
					'���ɂP�������炵���͉\�ȕ���������
					Wk_SelStart = -1
					For Wk_Point = Act_SelStart - 1 To 0 Step -1
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
							Wk_SelStart = Wk_Point
							Exit For
						End If
					Next 
					
					If Wk_SelStart = -1 Then
						'�I���\�ȕ������Ȃ��ꍇ
						'�P�O�̍��ڂ�
						Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
					Else
						'�I���\�ȕ���������ꍇ
						If Act_SelStart < Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) And Act_SelLength = 0 Then
							'�ړ��O�̑I���J�n�ʒu����ԉE�ȊO�ł���
							'�I�𕶎������Ȃ��ꍇ�̂݁A
							'�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					End If
					
				End If
			End If
		Else
			'���݂̺��۰ق�÷���ޯ���̈ȊO�ꍇ
			'�P�O�̍��ڂ�
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Right_Next_Focus
	'   �T�v�F  Right�������̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_Move_Flg         :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_all              :�S�\����
	'           pm_Run_Flg          :���s�w��t���O�iT�F����AF�F�Ȃ��j
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Right_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			'���݂�÷�ď�̑I����Ԃ��擾
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'�l���������l�̏ꍇ
					'�ŏI������I������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				Else
					'�l���������l�ȊO�̏ꍇ
					'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
				End If
			Else
				If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
					'�I���J�n�ʒu����ԉE�̏ꍇ
					'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
				Else
					'�I���J�n�ʒu����ԉE�łȂ��ꍇ
					
					'�P�E�̂P�����擾
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)
					
					If Str_Wk = "" Then
						'���̂P�����Ȃ��ꍇ
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'�l���������l�̏ꍇ
							'��ԉE�ֈړ����I���Ȃ���Ԃ�
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelLength = 0
						Else
							'�l���������l�ȊO�̏ꍇ
							If Act_SelLength = 0 Then
								'�ړ��O�̑I�𕶎������Ȃ��ꍇ
								'��ԉE�ֈړ����I���Ȃ���Ԃ�
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = 0
							Else
								'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						
						'�E�ɂP�������炵���͉\�ȕ���������
						Next_SelStart = -1
						For Wk_Point = Act_SelStart + 1 To Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Step 1
							
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
							
							Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
								Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
									'���t/�N��/�������ڂ̏ꍇ
									'���͉\�������Ƌ󔒂��ړ��\
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Or Str_Wk = Space(1) Then
										Next_SelStart = Wk_Point
										Exit For
									End If
								Case Else
									'���t/�N��/�������ڈȊO�̏ꍇ
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
										Next_SelStart = Wk_Point
										Exit For
									End If
									
							End Select
						Next 
						
						If Next_SelStart = -1 Then
							'�I���\�ȕ������Ȃ��ꍇ
							'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
							Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							'�I���\�ȕ���������ꍇ
							
							If Act_SelLength = 0 Then
								'�ړ��O�̑I�𕶎������Ȃ��ꍇ
								'�������ڂňړ�����ꍇ�ɑI�𕶎����͌p������
								Wk_SelLength = 0
							Else
								Wk_SelLength = 1
							End If
							
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						End If
					End If
				End If
				
			End If
		Else
			'���݂̺��۰ق�÷���ޯ���̈ȊO�ꍇ
			'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Down_Next_Focus
	'   �T�v�F  Down�������̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_Move_Flg         :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Down_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'���ו��̏ꍇ
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'���݂̍��ڂɗ񕪂������Ɉړ��������ޯ�������߂�
				Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				' === 20060825 === UPDATE S
				'            If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
				If Next_Index > pm_All.Dsp_Base.Foot_Fst_Idx - 1 Then
					' === 20060825 === UPDATE E
					'���ڐ��𒴂����ꍇ
					' === 20060825 === UPDATE S
					'�ŏI�s�̐擪���ڈȊO�̏ꍇ
					If Trg_Index <> pm_All.Dsp_Base.Foot_Fst_Idx - pm_All.Dsp_Base.Body_Col_Cnt + 1 Then
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						'                    Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
					End If
					' === 20060825 === UPDATE E
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'�ړ��悪���ו��ł��ړ��O�Ɠ������۰ٖ��̏ꍇ
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'̫������n�j
						'�����Ɉړ�
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'���̍��ږ������ו��łȂ��ꍇ
					If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
						'����ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
						'��ʂ̓��e��ޔ�
						Call CF_Body_Bkup(pm_All)
						'�ړ��\�s����ԉ��ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'�c�X�N���[���o�[��ݒ�
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'��ʃ{�f�B���̔z����Đݒ�
						Call CF_Dell_Refresh_Body_Inf(pm_All)
						'��ʕ\��
						'Call CF_Body_Dsp(pm_All)
						Call F_Body_Dsp(pm_All)
						'���ׂ̈�ԉ��̓��ꍀ�ڂ̲��ޯ�����擾
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'������۰ق̏ꍇ
								'�ړ������ŏI��
								pm_Move_Flg = False
								Exit Do
							Else
								'������۰قłȂ��ꍇ
								'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'���͉\�ȍŏ��̃C���f�b�N�X���擾
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'�t�b�^���̍ŏ��̍��ڂ̂P�O����
								'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
						'�t�b�^���̍ŏ��̍��ڂ̂P�O����
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						Exit Do
					End If
				End If
			Loop 
			
		Else
			'���ו��ȊO�̏ꍇ
			'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Up_Next_Focus
	'   �T�v�F  Up�������̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_Move_Flg         :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Up_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'���ו��̏ꍇ
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'���݂̍��ڂɗ񕪂�����Ɉړ��������ޯ�������߂�
				Next_Index = Trg_Index - (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index < 0 Then
					'�}�C�i�X�̏ꍇ
					'�P�O�̍��ڂ�
					' === 20060825 === UPDATE S
					'Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All,  , BEFE_FOCUS_MODE_KEYUP)
					' === 20060825 === UPDATE E
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'�ړ��悪���ו��ł��ړ��O�Ɠ������۰ٖ��̏ꍇ
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'̫������n�j
						'�����Ɉړ�
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'���̍��ږ������ו��łȂ��ꍇ
					If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
						' === 20060825 === DELATE S
						'                '���ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
						'                    '��ʂ̓��e��ޔ�
						'                    Call CF_Body_Bkup(pm_All)
						'                    '�ړ��\�s����ԏ�ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
						'                    pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						'                    If pm_All.Bd_Vs_Scrl Is Nothing = False Then
						'                        '�c�X�N���[���o�[��ݒ�
						'                        Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						'                    End If
						'                    '��ʃ{�f�B���̔z����Đݒ�
						'                    Call CF_Dell_Refresh_Body_Inf(pm_All)
						'                    '��ʕ\��
						'                    'Call CF_Body_Dsp(pm_All)
						'                    Call F_Body_Dsp(pm_All)
						'                    '���ׂ̈�ԏ�̓��ꍀ�ڂ̲��ޯ�����擾
						'                    Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
						'                    If Next_Index > 0 Then
						'                        If Next_Index = Trg_Index Then
						'                        '������۰ق̏ꍇ
						'                            '�ړ������ŏI��
						'                            pm_Move_Flg = False
						'                            Exit Do
						'                        Else
						'                        '������۰قłȂ��ꍇ
						'                            '���ꍀ�ڂ̂P��납��
						'                            '�P�O�̍��ڂ�
						'                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
						'                            Exit Do
						'                        End If
						'                    Else
						'                        '���͉\�ȍŏ��̃C���f�b�N�X���擾
						'                        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
						'                        If Focus_Ctl_Ok_Fst_Idx > 0 Then
						'                            '���͉\�ȍŏ��̍��ڂ̂P��납��
						'                            '�P�O�̍��ڂ�
						'                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
						'                            Exit Do
						'                        Else
						'                            '�w�b�_���̍Ō�̍��ڂ̂P��납��
						'                            '�P�O�̍��ڂ�
						'                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
						'                            Exit Do
						'
						'                        End If
						'                    End If
						' === 20060825 === DELATE E
					Else
						'�w�b�_���̍Ō�̍��ڂ̂P��납��
						'�P�O�̍��ڂ�
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
						Exit Do
					End If
					
				End If
			Loop 
		Else
			'���ו��ȊO�̏ꍇ
			'�P�O�̍��ڂ�
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_Jge_Action
	'   �T�v�F  �e�`�F�b�N�֐��̃`�F�b�N�O��
	'�@�@�@�@�@ �`�F�b�N���s�𔻒�
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_From_Process�@�@�@ :�ďo������
	'           pm_Err_Rtn�@�@     �@ :�G���[�ߒl
	'           pm_Msg_Flg�@�@     �@ :���b�Z�[�W�t���O
	'           pm_Move�@�@�@�@�@�@�@  :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Action(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		Dim Rtn_Cd As Short
		
		'���s
		Rtn_Cd = CHK_KEEP
		
		Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status <= ERR_NOT Then
						'���ڂ̃X�e�[�^�X���G���[�Ȃ�
						'���f
						Rtn_Cd = CHK_STOP
						'���b�Z�[�W��\��
						pm_Msg_Flg = False
						'�ړ���
						pm_Move = True
						'�`�F�b�N�n�j
						pm_Err_Rtn = CHK_OK
					End If
				End If
				
			Case CHK_FROM_KEYPRESS
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'���ڂ̃X�e�[�^�X���G���[�Ȃ�
						'���f
						Rtn_Cd = CHK_STOP
						'���b�Z�[�W��\��
						pm_Msg_Flg = False
						'�ړ���
						pm_Move = True
						'�`�F�b�N�n�j
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_KEYRETURN
				'�KEYRETURN�
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'���ڂ̃X�e�[�^�X���G���[�Ȃ�
						'���f
						Rtn_Cd = CHK_STOP
						'���b�Z�[�W��\��
						pm_Msg_Flg = False
						'�ړ���
						pm_Move = True
						'�`�F�b�N�n�j
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_ALL_CHK
				'�ꊇ�`�F�b�N�Ȃǣ
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT And pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True Then
						'���ڂ̃X�e�[�^�X���G���[�Ȃ��ł������͈ȊO�̃`�F�b�N���s���Ă���ꍇ
						'���f
						Rtn_Cd = CHK_STOP
						'���b�Z�[�W��\��
						pm_Msg_Flg = False
						'�ړ���
						pm_Move = True
						'�`�F�b�N�n�j
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
		End Select
		
		If Rtn_Cd = CHK_STOP Then
			'�`�F�b�N�𒆒f
			'�`�F�b�N�֐��ďo���������N���A
			pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		End If
		
		F_Chk_Jge_Action = Rtn_Cd
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_Jge_Msg_Move
	'   �T�v�F  �e�`�F�b�N�֐��̃`�F�b�N���
	'�@�@�@�@�@ ���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_From_Process�@�@�@ :�ďo������
	'           pm_Err_Rtn�@�@     �@ :�G���[�ߒl
	'           pm_Msg_Flg�@�@     �@ :���b�Z�[�W�t���O
	'           pm_Move�@�@�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Msg_Move(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		
		'���b�Z�[�W�\���Ȃ�
		pm_Msg_Flg = False
		'�ړ���
		pm_Move = True
		
		If pm_Err_Rtn = CHK_OK Then
			'�`�F�b�N�n�j
			pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
		Else
			
			Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'�`�F�b�N�n�j�Ƃ���
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
									'�O��Ɠ����`�F�b�N���e�̏ꍇ
									'�`�F�b�N�G���[�Ƃ���
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'���b�Z�[�W�o�͂Ȃ�
									pm_Msg_Flg = False
									'�ړ��n�j
									pm_Move = True
								Else
									'�O��ƈقȂ�`�F�b�N���e�̏ꍇ
									'�`�F�b�N�G���[�Ƃ���
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'���b�Z�[�W�o�͂Ȃ�
									pm_Msg_Flg = False
									'�ړ��n�j
									pm_Move = False
								End If
								
							End If
						Case CHK_ERR_ELSE
							'���̑��G���[��
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
								'�O��Ɠ����`�F�b�N���e�̏ꍇ
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�O��ƈقȂ�`�F�b�N���e�̏ꍇ
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'���b�Z�[�W�o�͂���
								pm_Msg_Flg = True
								'�ړ��n�j
								pm_Move = False
							End If
							
					End Select
					
				Case CHK_FROM_KEYPRESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'�`�F�b�N�n�j�Ƃ���
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'�`�F�b�N�G���[�Ƃ���
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							End If
						Case CHK_ERR_ELSE
							'���̑��G���[��
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
					End Select
					
				Case CHK_FROM_KEYRETURN
					'�KEYRETURN�
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'���b�Z�[�W�o�͂���
								pm_Msg_Flg = True
								'�ړ��m�f
								pm_Move = False
							End If
							
						Case CHK_ERR_ELSE
							'���̑��G���[��
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
					End Select
				Case CHK_FROM_ALL_CHK
					
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
						Case CHK_ERR_ELSE
							'���̑��G���[��
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
					End Select
					
			End Select
			
		End If
		
		'�`�F�b�N�֐��ďo���������N���A
		pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HD_KNGGRCD
	'   �T�v�F  �����O���[�v������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KNGGRCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_KNGMTB
		Dim Mst_Inf_Clr As TYPE_DB_KNGMTB
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_KNGGRCD = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_NOT_INPUT
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'�}�X�^�`�F�b�N
				If KNGMTB_SEARCH_ALL(Input_Value, Mst_Inf) = 0 Then
					'�Y���f�[�^�L��
					Retn_Code = CHK_OK
					pm_Chk_Move = True
				Else
					'CHG START FKS)INABA 2009/10/08 *******************************************************
					'�A���[��FC09101403
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					
					'                '�Y���f�[�^����
					'                Retn_Code = CHK_ERR_ELSE
					'
					'                If pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process <> CHK_FROM_LOSTFOCUS Then
					'                    Err_Cd = gc_strMsgKNGMT51_E_002
					'                End If
					'CHG  END  FKS)INABA 2009/10/08 *******************************************************
				End If
			End If
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_HD_KNGGRCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_DATKB
	'   �T�v�F  �N��������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_DATKB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_DATKB = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9�ȊO�̒l�����͂��ꂽ�ꍇ�̓G���[
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_BD_DATKB = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_UPDAUTH
	'   �T�v�F  �X�V������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_UPDAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_UPDAUTH = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9�ȊO�̒l�����͂��ꂽ�ꍇ�̓G���[
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_BD_UPDAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_PRTAUTH
	'   �T�v�F  ���������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_PRTAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_PRTAUTH = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9�ȊO�̒l�����͂��ꂽ�ꍇ�̓G���[
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_BD_PRTAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_FILEAUTH
	'   �T�v�F  �t�@�C���o�͂�����
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_FILEAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_FILEAUTH = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9�ȊO�̒l�����͂��ꂽ�ꍇ�̓G���[
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_BD_FILEAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_SALTAUTH
	'   �T�v�F  �̔��P���ύX������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_SALTAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_SALTAUTH = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9�ȊO�̒l�����͂��ꂽ�ꍇ�̓G���[
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_BD_SALTAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_HDNTAUTH
	'   �T�v�F  �����P���ύX������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_HDNTAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_HDNTAUTH = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9�ȊO�̒l�����͂��ꂽ�ꍇ�̓G���[
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_BD_HDNTAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_SAPMAUTH
	'   �T�v�F  �̔��v��N���v��C��������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_SAPMAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_SAPMAUTH = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9�ȊO�̒l�����͂��ꂽ�ꍇ�̓G���[
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'�d���������������������������������������������������������d
		
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_BD_SAPMAUTH = Retn_Code
		
	End Function
	
	' 2006/11/15  ADD START  KUMEDA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SET_UPDFLG
	'   �T�v�F  ������ʕ\��
	'   �����F�@pm_All          :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F�@�e�L�X�g�̓��e���ύX���ꂽ���ׂ̍X�V�t���O��ݒ�Z�b�g����
	'           �e�L�X�g�̓��e�ύX�ABackSpade�ADelete�A���ڏ������A�؎��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_SET_UPDFLG(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Item_Detail(pc_COL_UPDATE).Dsp_Value = "1"
		FR_SSSMAIN.BD_UPDATE(pm_Dsp_Sub_Inf.Detail.Body_Index).Text = "1"
		
		gv_bolKNGMT51_INIT = True
		
	End Function
	' 2006/11/15  ADD END
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function KNGMTB_SEARCH_ALL
	'   �T�v�F  �����}�X�^����
	'   �����F  pin_strKNGGRCD�@ : �����O���[�v
	'   �@�@�@�@pot_DB_KNGMTB  �@: ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function KNGMTB_SEARCH_ALL(ByVal pin_strKNGGRCD As String, ByRef pot_DB_KNGMTB As TYPE_DB_KNGMTB) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strTGRPCD As String
		
		On Error GoTo ERR_KNGMTB_SEARCH_ALL
		
		KNGMTB_SEARCH_ALL = 9
		
		Call DB_KNGMTB_Clear(pot_DB_KNGMTB)
		'CHG START FKS)INABA 2009/10/08 *****************************************************
		'�A���[��FC09101403
		strSQL = ""
		strSQL = strSQL & " Select KNG.* "
		strSQL = strSQL & "   from KNGMTB KNG "
		strSQL = strSQL & "    ,MEIMTA MEI "
		strSQL = strSQL & "  WHERE KNG.KNGGRCD = '" & CF_Ora_String(pin_strKNGGRCD, 3) & "' "
		strSQL = strSQL & "    AND MEI.KEYCD   = '" & pv_Pgid_Keycode & "' "
		strSQL = strSQL & "    AND MEI.MEICDA  = KNG.PGID "
		strSQL = strSQL & " ORDER BY "
		strSQL = strSQL & "     MEI.DSPORD "
		
		'    strSQL = ""
		'    strSQL = strSQL & " Select * "
		'    strSQL = strSQL & "   from KNGMTB "
		'    strSQL = strSQL & "  Where KNGGRCD = '" & CF_Ora_String(pin_strKNGGRCD, 3) & "' "
		'CHG  END  FKS)INABA 2009/10/08 *****************************************************
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'�擾�f�[�^�Ȃ�
			KNGMTB_SEARCH_ALL = 1
			GoTo END_KNGMTB_SEARCH_ALL
		End If
		
		KNGMTB_SEARCH_ALL = 0
		
END_KNGMTB_SEARCH_ALL: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_KNGMTB_SEARCH_ALL: 
		GoTo END_KNGMTB_SEARCH_ALL
		
	End Function
	' === 20060825 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_Item_Detail
	'   �T�v�F  �e���ڂ̉�ʕ\��
	'   �����F�@pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_Item_Detail(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'�r���������������������������������������������������������r
			Case FR_SSSMAIN.HD_KNGGRCD.Name
				'�����O���[�v�ɂ���ʕ\��
				
				'�d���������������������������������������������������������d
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_DSP_BD_Inf
	'   �T�v�F  �{�f�B���̉�ʕ\��
	'   �����F�@pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DSP_BD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim intCnt As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'�f�[�^�ҏW
			Call F_SET_BD_DATA(pm_All)
			
			'�t�H�[�J�X�ʒu�ݒ�
			Call F_Cursor_Set(pm_All)
		End If
		
		'�������e�A�O����e��ޔ�
		Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Item_Chk
	'   �T�v�F  �e���ڂ�����ٰ�ݐ���
	'   �����F�@pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Process          :�`�F�b�N�֐��ďo��
	'           pm_Chk_Move_Flg     :�e���ڂ̃`�F�b�N�t���O
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Chk(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Chk As Short
		Dim Bd_Index As Short
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		'�@��{���͓��e�̃`�F�b�N
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'�r���������������������������������������������������������r
			Case FR_SSSMAIN.HD_KNGGRCD.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'�����O���[�v������
				Rtn_Chk = F_Chk_HD_KNGGRCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
				' 2006/11/21  ADD START  KUMEDA
			Case FR_SSSMAIN.BD_DATKB(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'�����O����(�����֐��̑O�ŕK�{����)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'�N��������
					Rtn_Chk = F_Chk_BD_DATKB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				' 2006/11/21  ADD END
				
			Case FR_SSSMAIN.BD_UPDAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'�����O����(�����֐��̑O�ŕK�{����)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'�X�V������
					Rtn_Chk = F_Chk_BD_UPDAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_PRTAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'�����O����(�����֐��̑O�ŕK�{����)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'���������
					Rtn_Chk = F_Chk_BD_PRTAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_FILEAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'�����O����(�����֐��̑O�ŕK�{����)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'�t�@�C���o�͂�����
					Rtn_Chk = F_Chk_BD_FILEAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_SALTAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'�����O����(�����֐��̑O�ŕK�{����)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'�̔��P���ύX������
					Rtn_Chk = F_Chk_BD_SALTAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_HDNTAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'�����O����(�����֐��̑O�ŕK�{����)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'�����P���ύX������
					Rtn_Chk = F_Chk_BD_HDNTAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_SAPMAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'�����O����(�����֐��̑O�ŕK�{����)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'�̔��v��N���v��C��������
					Rtn_Chk = F_Chk_BD_SAPMAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
				'�d���������������������������������������������������������d
		End Select
		
		F_Ctl_Item_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Head_Chk
	'   �T�v�F  ͯ�ޕ�������ٰ�ݐ���
	'   �����F�@pm_all      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		'======================= �ύX���� 2006.06.12 Start =================================
		Dim Dsp_Mode As Short
		'======================= �ύX���� 2006.06.12 End =================================
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		
		'�w�b�_���̍ŏI���ڂ܂Ŋe���ڂ��������s��
		For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx
			
			'�e����������S�������Ƃ��Čďo
			Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			
			'======================= �ύX���� 2006.06.12 Start =================================
			If Rtn_Chk = CHK_OK Then
				'�`�F�b�N�n�j��
				'�擾���e�\��
				Dsp_Mode = DSP_SET
			Else
				'�`�F�b�N�m�f��
				'�擾���e�N���A
				Dsp_Mode = DSP_CLR
			End If
			
			'�擾���e�\��/�N���A
			Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
			'======================= �ύX���� 2006.06.12 End =================================
			
			'�`�F�b�N�m�f
			If Rtn_Chk <> CHK_OK Then
				
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'�֘A����
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'�`�F�b�N�n�j�ł���
			'�w�b�_���̃`�F�b�N�����߂Ă̏ꍇ
			'�t�b�^�����J������
			Call F_Foot_In_Ready(pm_All)
			'�`�F�b�N�n�j
			pm_All.Dsp_Base.Head_Ok_Flg = True
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS
	'   �T�v�F  ������ʕ\��
	'   �����F�@pm_All          :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  ������ʕ\���C���[�W���N���b�N�����ۂ̏���
	'           �t�H�[�J�X�͓��̓R���g���[���ɂ���܂܂̏��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS(ByRef pm_All As Cls_All) As Short
		
		Dim Cursor_Index As Short
		Dim Trg_Index As Short
		
		'���݂̃t�H�[�J�X�擾�R���g���[���̃C���f�b�N�X
		Cursor_Index = pm_All.Dsp_Base.Cursor_Idx
		
		Select Case Cursor_Index
			'�r���������������������������������������������������������r
			'�d���������������������������������������������������������d
		End Select
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_WLS_Close
	'   �T�v�F  �e������ʃN���[�Y����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_WLS_Close() As Short
		
		F_Ctl_WLS_Close = 9
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
		
		F_Ctl_WLS_Close = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Upd_Process
	'   �T�v�F  �X�V���C�����[�`��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0 :�X�V�I���@9:�X�V�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Upd_Process(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim intErrIdx As Short
		Dim strJdnNo As String
		Dim Index_Cnt As Short
		Dim Trg_Index As Short
		'2007/12/18 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		'2007/12/18 add-end M.SUEZAWA
		' === 20080902 === INSERT S - RISE)Izumi
		Dim bolTrn As Boolean
		' === 20080902 === INSERT E - RISE)Izumi
		
		F_Ctl_Upd_Process = 9
		
		' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		' === 20060808 === INSERT E
		
		' 2007/01/11  DLT START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
		'    '�o�^�����������ꍇ
		'    If pv_InpTan_KNG = False Then
		'        gv_bolUpdFlg = False
		'        Exit Function
		'    End If
		' 2007/01/11  DLT END
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'�{�f�B���̃`�F�b�N
		intRet = F_Ctl_Body_Chk(pm_All)
		If intRet <> CHK_OK Then
			'�`�F�b�N�m�f�̏ꍇ
			GoTo End_F_Ctl_Upd_Process
		End If
		
		'�����Ǝ��֘A����
		intRet = F_Update_RelChk(pm_All, intErrIdx)
		If intRet <> CHK_OK Then
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intErrIdx), pm_All)
			GoTo Err_F_Ctl_Upd_Process
		End If
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'Windows�ɏ�����Ԃ�
		'    DoEvents
		
		'�m�F���b�Z�[�W�\��
		intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_A_008, pm_All)
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		Select Case intRet
			Case MsgBoxResult.Yes
				' 2007/01/11  ADD START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
				If pv_InpTan_KNG = False Then
					gv_bolUpdFlg = False
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_016, pm_All)
					GoTo End_F_Ctl_Upd_Process
				End If
				' 2007/01/11  ADD END
				
				' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE�Ή��ɂ��g�����U�N�V�����J�n�ʒu�ύX
				'�g�����U�N�V�����̊J�n
				Call CF_Ora_BeginTrans(gv_Oss_USR1)
				bolTrn = True
				' === 20080902 === INSERT E - RISE)Izumi
				
				'2007/12/18 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
				'�X�V���ԃ`�F�b�N
				bolRet = F_Chk_UWRTDTTM(pm_All)
				If bolRet = False Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_017, pm_All)
					F_Ctl_Upd_Process = 0
					GoTo End_F_Ctl_Upd_Process
				End If
				'2007/12/18 add-end M.SUEZAWA
				
				'�{�^����\��
				FR_SSSMAIN.CM_Execute.Visible = False
				
				'�o�^����
				intRet = F_Update_Main(pm_All)
				If intRet <> 0 Then
					GoTo Err_F_Ctl_Upd_Process
				End If
				
				' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE�Ή��ɂ��g�����U�N�V�����J�n�ʒu�ύX
				'�R�~�b�g
				Call CF_Ora_CommitTrans(gv_Oss_USR1)
				bolTrn = False
				' === 20080902 === INSERT E - RISE)Izumi
				
				'�{�f�B���ڂ̏�����
				For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
					'�e��ʂ̍��ڂ�������
					With pm_All.Dsp_Sub_Inf(Index_Cnt).Detail
						'�O����e���N���A
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Bef_Value = System.DBNull.Value
						'�O����e�t���O���N���A
						.Bef_Value_Flg = VALUE_FLG_DEF
						
						'�������e���N���A
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Rest_Value = System.DBNull.Value
						'�������e�t���O���N���A
						.Rest_Value_Flg = VALUE_FLG_DEF
						
						'հ�ް���͖�
						.In_Value_Flg = False
						
						'���ڕ����t���O�m�f
						.Item_Rest_Flg = BODY_ROW_REST_FLG_NOT
						
						'�����͈ȊO�̃`�F�b�N�σt���O
						.Not_Input_Chk_Fin_Flg = False
					End With
					
					'�������e�A�O����e��ޔ�
					Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Index_Cnt))
				Next 
				
			Case Else ' �߂�
				GoTo End_F_Ctl_Upd_Process
		End Select
		
		'���탁�b�Z�[�W�\��
		intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_009, pm_All)
		
		F_Ctl_Upd_Process = 0
		
End_F_Ctl_Upd_Process: 
		
		' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE�Ή��ɂ��g�����U�N�V�����J�n�ʒu�ύX
		If bolTrn = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
			bolTrn = False
		End If
		' === 20080902 === INSERT E - RISE)Izumi
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'�{�^���\��
		FR_SSSMAIN.CM_Execute.Visible = True
		
		' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
		gv_bolUpdFlg = False
		
		'�L�[�t���O�����ɖ߂�
		gv_bolKeyFlg = False
		' === 20060808 === INSERT E
		
		Exit Function
		
Err_F_Ctl_Upd_Process: 
		
		GoTo End_F_Ctl_Upd_Process
		
	End Function
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Upd_Process2
	'   �T�v�F  �X�V���C�����[�`��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0 :�X�V�I���@9:�X�V�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Upd_Process2(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim intErrIdx As Short
		Dim strJdnNo As String
		Dim Index_Cnt As Short
		Dim Trg_Index As Short
		Dim Col_Index As Short
		'2007/12/18 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		'2007/12/18 add-end M.SUEZAWA
		' === 20080902 === INSERT S - RISE)Izumi
		Dim bolTrn As Boolean
		' === 20080902 === INSERT E - RISE)Izumi
		
		F_Ctl_Upd_Process2 = 9
		
		' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		' === 20060808 === INSERT E
		
		' 2007/01/11  DLT START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
		'    '�o�^�����������ꍇ
		'    If pv_InpTan_KNG = False Then
		'        F_Ctl_Upd_Process2 = 0
		'        gv_bolUpdFlg = False
		'        Exit Function
		'    End If
		' 2007/01/11  DLT END
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'�{�f�B���̃`�F�b�N
		intRet = F_Ctl_Body_Chk(pm_All)
		If intRet <> CHK_OK Then
			'�`�F�b�N�m�f�̏ꍇ
			GoTo End_F_Ctl_Upd_Process2
		End If
		
		'�����Ǝ��֘A����
		intRet = F_Update_RelChk(pm_All, intErrIdx)
		If intRet <> CHK_OK Then
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intErrIdx), pm_All)
			GoTo Err_F_Ctl_Upd_Process2
		End If
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'Windows�ɏ�����Ԃ�
		'    DoEvents
		
		If gv_bolKNGMT51_INIT = True Then
			'�m�F���b�Z�[�W�\��
			intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_A_012, pm_All)
		End If
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		Select Case intRet
			Case MsgBoxResult.Yes
				' 2007/01/11  ADD START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
				If pv_InpTan_KNG = False Then
					gv_bolUpdFlg = False
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_016, pm_All)
					GoTo End_F_Ctl_Upd_Process2
				End If
				' 2007/01/11  ADD END
				
				' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE�Ή��ɂ��g�����U�N�V�����J�n�ʒu�ύX
				'�g�����U�N�V�����̊J�n
				Call CF_Ora_BeginTrans(gv_Oss_USR1)
				bolTrn = True
				' === 20080902 === INSERT E - RISE)Izumi
				
				'2007/12/18 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
				'�X�V���ԃ`�F�b�N
				bolRet = F_Chk_UWRTDTTM(pm_All)
				If bolRet = False Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_017, pm_All)
					F_Ctl_Upd_Process2 = 0
					GoTo End_F_Ctl_Upd_Process2
				End If
				'2007/12/18 add-end M.SUEZAWA
				
				'�{�^����\��
				FR_SSSMAIN.CM_Execute.Visible = False
				
				'�o�^����
				intRet = F_Update_Main(pm_All)
				If intRet <> 0 Then
					GoTo Err_F_Ctl_Upd_Process2
				End If
				
				' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE�Ή��ɂ��g�����U�N�V�����J�n�ʒu�ύX
				'�R�~�b�g
				Call CF_Ora_CommitTrans(gv_Oss_USR1)
				bolTrn = False
				' === 20080902 === INSERT E - RISE)Izumi
				
				'�{�f�B���ڂ̏�����
				For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
					'�e��ʂ̍��ڂ�������
					With pm_All.Dsp_Sub_Inf(Index_Cnt).Detail
						'�O����e���N���A
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Bef_Value = System.DBNull.Value
						'�O����e�t���O���N���A
						.Bef_Value_Flg = VALUE_FLG_DEF
						
						'�������e���N���A
						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.Rest_Value = System.DBNull.Value
						'�������e�t���O���N���A
						.Rest_Value_Flg = VALUE_FLG_DEF
						
						'հ�ް���͖�
						.In_Value_Flg = False
						
						'���ڕ����t���O�m�f
						.Item_Rest_Flg = BODY_ROW_REST_FLG_NOT
						
						'�����͈ȊO�̃`�F�b�N�σt���O
						.Not_Input_Chk_Fin_Flg = False
					End With
					
					'�������e�A�O����e��ޔ�
					Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Index_Cnt))
				Next 
				
				'���탁�b�Z�[�W�\��
				intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_009, pm_All)
				
			Case MsgBoxResult.No
				'�o�^�����ɏ����p��
				gv_bolKNGMT51_INIT = False
				
			Case MsgBoxResult.Cancel
				'�������~
				GoTo End_F_Ctl_Upd_Process2
				
			Case Else
				'���b�Z�[�W�\���Ȃ�
				
		End Select
		
		F_Ctl_Upd_Process2 = 0
		
End_F_Ctl_Upd_Process2: 
		
		' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE�Ή��ɂ��g�����U�N�V�����J�n�ʒu�ύX
		If bolTrn = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
			bolTrn = False
		End If
		' === 20080902 === INSERT E - RISE)Izumi
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'�{�^���\��
		FR_SSSMAIN.CM_Execute.Visible = True
		
		' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
		gv_bolUpdFlg = False
		
		'�L�[�t���O�����ɖ߂�
		gv_bolKeyFlg = False
		' === 20060808 === INSERT E
		
		Exit Function
		
Err_F_Ctl_Upd_Process2: 
		
		GoTo End_F_Ctl_Upd_Process2
		
	End Function
	' === 20060825 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Body_Chk
	'   �T�v�F  ���ި��������ٰ�ݐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk_Col As Short
		Dim Index_Wk_Row As Short
		Dim Trg_Index As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Dsp_Mode As Short
		
		Dim Err_Row As Short
		Dim Err_Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Bd_Idx As Short
		Dim Err_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim intMoveFocus As Short
		Dim intErrRow As Short
		Dim curUodKn As Decimal
		Dim curZeiKn As Decimal
		'UPGRADE_WARNING: �\���� Row_inf_Zero �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Row_inf_Zero As Cls_Dsp_Body_Row_Inf
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		
		pv_bolMEISAI_INPUT = False
		pv_intMeisaiCnt = 0
		pv_bolInput_Bef_Row = True
		
		'�[���s�ڏ��ޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g Row_inf_Zero �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Row_inf_Zero = pm_All.Dsp_Body_Inf.Row_Inf(0)
		
		'�{�f�B���̍ŏI���ڂ܂Ŋe���ڂ��������s��
		For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
				'            Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT, BODY_ROW_STATE_LST_ROW
				'                '���͑ҏ�ԁA���͍Ϗ�ԁA�ŏI�����s��Ώ�
				Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
					'���͑ҏ�ԁA���͍Ϗ�Ԃ�Ώ�
					
					'�B�s�ɉ�ʖ��ׂ̑Ώۍs���R�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(0))
					
					For Index_Wk_Col = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail)
						
						'��ʖ��ׂ̉B�s�̍��ڂ̲��ޯ�����擾
						Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm, pm_All)
						
						'���[�N�̢��ʍ��ڏ��ɉB�s���۰ق�����
						Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
						
						'���[�N�̢��ʍ��ڏ��ɢ��ʃ{�f�B����ҏW
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value, Dsp_Sub_Inf_Wk, pm_All)
						'��ʍ��ڏڍ׏���ݒ�
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Sub_Inf_Wk.Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col)
						
						'�e����������S�������Ƃ��Čďo
						Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
						
						If Rtn_Chk = CHK_OK Then
							'�`�F�b�N�n�j��
							'�擾���e�\��
							Dsp_Mode = DSP_SET
						Else
							'�`�F�b�N�m�f��
							'�擾���e�N���A
							Dsp_Mode = DSP_CLR
						End If
						
						'�擾���e�\��/�N���A
						Call F_Dsp_Item_Detail(Dsp_Sub_Inf_Wk, Dsp_Mode, pm_All)
						
						'���ʃ{�f�B���Ƀ��[�N�̢��ʍ��ڏ���ҏW
						'��ʍ��ڏڍ׏���ݒ�
						'�����ɂ���ĕύX����鍀�ڂ̂�
						Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col), Dsp_Sub_Inf_Wk.Detail)
						
						'�`�F�b�N�m�f
						Select Case Rtn_Chk
							'OK�̏ꍇ
							Case CHK_OK
								
								'������
							Case CHK_ERR_NOT_INPUT
								
							Case Else
								
								'�G���[�̏ꍇ�A�Ώۍs��\����̫����ړ�����
								'�G���[�p�ϐ��i�[
								'�s���
								Err_Row = Index_Wk_Row
								'�Ώۺ��۰ُ��
								Err_Dsp_Sub_Inf_Wk.Ctl = Dsp_Sub_Inf_Wk.Ctl
								'��ʍ��ڏڍ׏���ݒ�
								'UPGRADE_WARNING: �I�u�W�F�N�g Err_Dsp_Sub_Inf_Wk.Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Err_Dsp_Sub_Inf_Wk.Detail = Dsp_Sub_Inf_Wk.Detail
								
								GoTo ERR_EXIT
						End Select
						
					Next 
					
					'�֘A����
					Rtn_Chk = F_Ctl_Body_RelChk(Index_Wk_Row, pm_All, intMoveFocus, intErrRow)
					'�`�F�b�N�m�f
					If Rtn_Chk <> CHK_OK Then
						
						F_Ctl_Body_Chk = Rtn_Chk
						'�G���[�p�ϐ��i�[
						Err_Row = intErrRow
						'�Ώۺ��۰ُ��
						Err_Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(intMoveFocus).Ctl
						'��ʍ��ڏڍ׏���ݒ�
						'UPGRADE_WARNING: �I�u�W�F�N�g Err_Dsp_Sub_Inf_Wk.Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Err_Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Sub_Inf(intMoveFocus).Detail
						
						GoTo ERR_EXIT
					End If
					
					'��ʖ��ׂ̑Ώۍs�ɉB�s���R�s�[(���ɖ߂�)
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row))
			End Select
		Next 
		
		'    '���׍s�ɓ��͂��Ȃ��ꍇ�A�G���[
		'    If pv_bolMEISAI_INPUT = False Then
		'
		'        '�G���[���b�Z�[�W�\��
		'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_046, pm_All)
		'
		'        '������ړ��Ȃ�
		'        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_HINCD(1).Tag), pm_All)
		'
		'        F_Ctl_Body_Chk = CHK_ERR_ELSE
		'        Exit Function
		'
		'    End If
		
		F_Ctl_Body_Chk = Rtn_Chk
		
		Exit Function
		
ERR_EXIT: 
		'�G���[���A̫����ړ�
		'�Ώۍs����ʂɕ\��
		Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
		'�R���g���[������
		Call F_Set_Body_Enable(pm_All)
		'�Ώۍs�����ʖ��ׂ̍s���擾
		Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
		'��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
		Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)
		
		If Err_Index > 0 Then
			'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index - 1), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index - 1), ITEM_NORMAL_STATUS, pm_All)
			
		Else
			'���͉\�ȍŏ��̃C���f�b�N�X���擾
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
		F_Ctl_Body_Chk = Rtn_Chk
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Body_RelChk
	'   �T�v�F  ���ި���̊֘A����
	'   �����F�@pm_intRow : �`�F�b�N�Ώۖ��׍s
	'         �@pm_all    : ��ʏ��
	'   �ߒl�F�@CHK_OK:�`�F�b�NOK�@CHK_ERR_ELSE:���̑��G���[
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_RelChk(ByRef pm_intRow As Short, ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short, ByRef pm_ErrRow As Short) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Trg_Index As Short
		Dim Err_Cd As String '�G���[�R�[�h
		Dim intUPDKB As Short
		Dim intUPDAUTH As Short
		Dim intPRTAUTH As Short
		Dim intFILEAUTH As Short
		Dim intSALTAUTH As Short
		Dim intHDNTAUTH As Short
		Dim intSAPMAUTH As Short
		Dim bolCheck As Boolean
		Dim bolNotInput As Boolean
		Dim strKbn As String
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrRow = pm_intRow
		pm_ErrIdx = CShort(FR_SSSMAIN.BD_UPDAUTH(1).Tag)
		bolNotInput = False
		
		'�P�s�`�F�b�N
		intUPDKB = CShort(FR_SSSMAIN.BD_UPDKB(0).Tag)
		intUPDAUTH = CShort(FR_SSSMAIN.BD_UPDAUTH(0).Tag)
		intPRTAUTH = CShort(FR_SSSMAIN.BD_PRTAUTH(0).Tag)
		intFILEAUTH = CShort(FR_SSSMAIN.BD_FILEAUTH(0).Tag)
		intSALTAUTH = CShort(FR_SSSMAIN.BD_SALTAUTH(0).Tag)
		intHDNTAUTH = CShort(FR_SSSMAIN.BD_HDNTAUTH(0).Tag)
		intSAPMAUTH = CShort(FR_SSSMAIN.BD_SAPMAUTH(0).Tag)
		
		bolCheck = False
		'�P�s�ɕK�v�ȏ�񂪓��͂���Ă���ꍇ�AOK
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRTAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFILEAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSALTAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHDNTAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSAPMAUTH))) <> "" Then
			bolCheck = True
			pv_bolMEISAI_INPUT = True
			pv_intMeisaiCnt = pv_intMeisaiCnt + 1
			
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case True
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_UPDAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRTAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_PRTAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFILEAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_FILEAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSALTAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_SALTAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHDNTAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_HDNTAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSAPMAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_SAPMAUTH(1).Tag)
			End Select
		End If
		
		'�P�s�S�������͂̏ꍇOK
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If bolCheck = False And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRTAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFILEAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSALTAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHDNTAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSAPMAUTH))) = "" Then
			
			'���u���͍ςݏ�ԁv"�łȂ�"�ꍇ
			If pm_All.Dsp_Body_Inf.Row_Inf(pm_intRow).Status <> BODY_ROW_STATE_INPUT Then
				bolCheck = True
				bolNotInput = True
			End If
		End If
		
		If bolCheck = False Then
			Err_Cd = gc_strMsgKNGMT51_E_010
			GoTo F_Ctl_Body_RelChk_END
		End If
		
		'�����͂̏ꍇ�A��̃`�F�b�N�͖���
		If bolNotInput = True Then
			pv_bolInput_Bef_Row = False
			Rtn_Chk = CHK_OK
			GoTo F_Ctl_Body_RelChk_END
		Else
			'�����͈ȊO�őO�̍s�������͂̏ꍇ�G���[
			If pv_bolInput_Bef_Row = False Then
				Err_Cd = gc_strMsgKNGMT51_E_010
				pm_ErrRow = pm_intRow - 1
				GoTo F_Ctl_Body_RelChk_END
			End If
		End If
		
		Rtn_Chk = CHK_OK
		
F_Ctl_Body_RelChk_END: 
		
		If Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Ctl_Body_RelChk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Body_Enable
	'   �T�v�F  �ŏ㖾�ײ��ޯ��(pm_All.Dsp_Body_Inf.Cur_Top_Index)�����
	'   �@�@�@�@���׍s�̺��۰ِ�����s��
	'   �����F�@pm_All�@: ��ʏ��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Enable(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Bd_Row_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Wk_Row As Short
		Dim Wk_Index As Short
		Dim InpRow As Short
		
		Bd_Row_Index = 0
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'���ו\���̉��
			
			'�{�f�B�����ŏ���
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					'pm_All.Dsp_Body_Inf�̍s�m�n���擾
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'���׍s�u���C�N
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
						Bd_Row_Index = Bd_Row_Index + 1
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'�r���������������������������������������������������������r
					'�d���������������������������������������������������������d
					
				End If
			Next 
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Update_RelChk
	'   �T�v�F  �����Ǝ��֘A����
	'   �����F�@pm_all    : ��ʏ��
	'   �ߒl�F�@CHK_OK:�`�F�b�NOK�@CHK_ERR_ELSE:���̑��G���[
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Update_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short
		
		Dim intRet As Short
		Dim Trg_Index As Short
		Dim Err_Cd As String '�G���[�R�[�h
		
		On Error GoTo F_Update_RelChk_Err
		
		intRet = CHK_ERR_ELSE
		
		
		
		intRet = CHK_OK
		
F_Update_RelChk_End: 
		
		If Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		F_Update_RelChk = intRet
		Exit Function
		
F_Update_RelChk_Err: 
		
		intRet = CHK_ERR_ELSE
		GoTo F_Update_RelChk_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Update_Main
	'   �T�v�F  �X�V���C������
	'   �����F  pm_All        : ��ʏ��
	'   �ߒl�F�@�������ʃX�e�[�^�X
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Update_Main(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim bolTrn As Boolean
		Dim intCnt As Short
		Dim strErrMsg As String
		Dim strCTLCD As String
		Dim Trg_Index As Short
		Dim Upd_Start As Short
		Dim Upd_End As Short
		Dim Mst_Inf As TYPE_DB_KNGMTB
		
		' On Error GoTo F_Update_Main_Err
		
		intRet = CHK_OK
		bolTrn = False
		
		'�X�V�����擾
		Call CF_Get_SysDt()
		
		'���[�v�J�n�A�I���̌v�Z
		Upd_Start = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1
		Upd_End = pm_All.Dsp_Base.Dsp_Body_Cnt * NowPageNum
		
		' === 20080902 === DELETE S - RISE)Izumi  FOR UPDATE�Ή��ɂ��g�����U�N�V�����J�n�ʒu�̕ύX
		'    '�g�����U�N�V�����̊J�n
		'    Call CF_Ora_BeginTrans(gv_Oss_USR1)
		'    bolTrn = True
		' === 20080902 === DELETE E - RISE)Izumi
		'ADD START FKS)INABA 2009/10/08 **************************
		'�A���[��FC09101403
		Upd_Start = 1
		Upd_End = pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
		'ADD  END  FKS)INABA 2009/10/08 **************************
		For intCnt = Upd_Start To Upd_End
			If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_INPUT Then
				'DEL START FKS)INABA 2009/10/08 **************************
				'�A���[��FC09101403
				'' 2006/11/15  ADD START  KUMEDA
				'            If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(pc_COL_UPDATE).Dsp_Value = "1" Then
				'' 2006/11/15  ADD END
				'DEL  END  FKS)INABA 2009/10/08 **************************
				'�����}�X�^�X�V
				intRet = F_KNGMTB_Update(intCnt, pm_All)
				
				If intRet <> 0 Then
					GoTo F_Update_Main_Err
				End If
				'DEL START FKS)INABA 2009/10/08 **************************
				'�A���[��FC09101403
				'' 2006/11/15  ADD START  KUMEDA
				'            End If
				'' 2006/11/15  ADD END
				'DEL  END  FKS)INABA 2009/10/08 **************************
			End If
			
		Next intCnt
		
		' === 20080902 === DELETE S - RISE)Izumi  FOR UPDATE�Ή��ɂ��g�����U�N�V�����J�n�ʒu�̕ύX
		'    '�R�~�b�g
		'    Call CF_Ora_CommitTrans(gv_Oss_USR1)
		'    bolTrn = False
		' === 20080902 === DELETE E - RISE)Izumi
		
		intRet = CHK_OK
		
F_Update_Main_End: 
		
		' === 20080902 === DELETE S - RISE)Izumi  FOR UPDATE�Ή��ɂ��g�����U�N�V�����J�n�ʒu�̕ύX
		'    If bolTrn = True Then
		'        '���[���o�b�N
		'        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		'        bolTrn = False
		'    End If
		' === 20080902 === DELETE E - RISE)Izumi
		
		F_Update_Main = intRet
		Exit Function
		
F_Update_Main_Err: 
		
		intRet = CHK_ERR_ELSE
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_KNGMTB_Update
	'   �T�v�F  �����}�X�^�X�V����
	'   �����F  pm_intCnt   : �z��ԍ�
	'           pm_All      : �S�\����
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_KNGMTB_Update(ByRef pm_intCnt As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_KNGMTB_Update_err
		
		F_KNGMTB_Update = 9
		'ADD START FKS)INABA 2009/10/08 *************************************
		'�A���[��FC09101403
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim ll_cnt As Short
		Dim ls_pgid As String
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ls_pgid = Trim(CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt).Item_Detail(pc_COL_PGID).Dsp_Value, 8))
		If ls_pgid = "" Then
			F_KNGMTB_Update = 0
			Exit Function
		End If
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) CNT_1 "
		strSQL = strSQL & "   FROM  KNGMTB  "
		strSQL = strSQL & "  WHERE KNGGRCD = '" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "    AND PGID    = '" & Trim(CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt).Item_Detail(pc_COL_PGID).Dsp_Value, 8)) & "' "
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ll_cnt = CF_Ora_GetDyn(Usr_Ody, "CNT_1", 0)
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		If ll_cnt = 0 Then
			With pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt)
				strSQL = ""
				strSQL = strSQL & " INSERT INTO KNGMTB VALUES("
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & " '" & CF_Ora_String(.Item_Detail(pc_COL_DATKB).Dsp_Value, 1) & "' " '(01)�N��
				strSQL = strSQL & ",'" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' " '(02)�����O���[�v
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & ",'" & Trim(CF_Ora_String(.Item_Detail(pc_COL_PGID).Dsp_Value, 8)) & "' " '(03)�v���O�����h�c
				strSQL = strSQL & ",'" & .Bus_Inf.UPDFLG & "' " '(04)�X�V�����ύX�\�t���O
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_UPDAUTH).Dsp_Value, 1) & "' " '(05)�X�V����
				strSQL = strSQL & ",'" & .Bus_Inf.PRTFLG & "'" '(06)��������ύX�\�t���O
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_PRTAUTH).Dsp_Value, 1) & "' " '(07)���
				strSQL = strSQL & ",'" & .Bus_Inf.FILEFLG & "'" '(08)�t�@�C���o�͌����ύX�\�t���O
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_FILEAUTH).Dsp_Value, 1) & "' " '(09)�t�@�C���o��
				strSQL = strSQL & ",'" & .Bus_Inf.SALTFLG & "'" '(10)�̔��P���ύX�����ύX�\�t���O
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_SALTAUTH).Dsp_Value, 1) & "' " '(11)�̔��P���ύX
				strSQL = strSQL & ",'" & .Bus_Inf.HDNTFLG & "'" '(12)�����P���ύX�����ύX�\�t���O
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_HDNTAUTH).Dsp_Value, 1) & "' " '(13)�����P���ύX
				strSQL = strSQL & ",'" & .Bus_Inf.SAPMFLG & "'" '(14)�̔��v��N���v��C�������ύX�\�t���O
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_SAPMAUTH).Dsp_Value, 1) & "' " '(15)�̔��v��N���v��C��
				strSQL = strSQL & ",'" & CF_Ora_String("", 1) & "' " '(16)�A�g�t���O
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '(17)����o�^���[�U
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '(18)����o�^�N���C�A���g�h�c
				strSQL = strSQL & ",'" & GV_SysTime & "' " '(19)�^�C���X�^���v�i����o�^���ԁj
				strSQL = strSQL & ",'" & GV_SysDate & "' " '(20)�^�C���X�^���v�i����o�^���t�j
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '(21)�ŏI��Ǝ҃R�[�h
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '(22)�N���C�A���g�h�c
				strSQL = strSQL & ",'" & GV_SysTime & "' " '(23)�^�C���X�^���v�i���ԁj
				strSQL = strSQL & ",'" & GV_SysDate & "' " '(24)�^�C���X�^���v�i���t�j
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '(25)�ŏI��Ǝ҃R�[�h�i�o�b�`�j
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '(26)�N���C�A���g�h�c�i�o�b�`�j
				strSQL = strSQL & ",'" & GV_SysTime & "' " '(27)�^�C���X�^���v�i�o�b�`���ԁj
				strSQL = strSQL & ",'" & GV_SysDate & "' " '(28)�^�C���X�^���v�i�o�b�`���t�j
				strSQL = strSQL & " )"
			End With
		Else
			'ADD  END  FKS)INABA 2009/10/08 *************************************
			'�����}�X�^�X�V
			With pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt)
				strSQL = ""
				strSQL = strSQL & " Update KNGMTB "
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "    Set UPDAUTH     = '" & CF_Ora_String(.Item_Detail(pc_COL_UPDAUTH).Dsp_Value, 1) & "' " '�X�V
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "      , PRTAUTH     = '" & CF_Ora_String(.Item_Detail(pc_COL_PRTAUTH).Dsp_Value, 1) & "' " '���
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "      , FILEAUTH    = '" & CF_Ora_String(.Item_Detail(pc_COL_FILEAUTH).Dsp_Value, 1) & "' " '�t�@�C���o��
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "      , SALTAUTH    = '" & CF_Ora_String(.Item_Detail(pc_COL_SALTAUTH).Dsp_Value, 1) & "' " '�̔��P���ύX
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "      , HDNTAUTH    = '" & CF_Ora_String(.Item_Detail(pc_COL_HDNTAUTH).Dsp_Value, 1) & "' " '�����P���ύX
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "      , SAPMAUTH    = '" & CF_Ora_String(.Item_Detail(pc_COL_SAPMAUTH).Dsp_Value, 1) & "' " '�̔��v��N���v��C��
				' 2006/11/21  ADD START  KUMEDA
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "      , DATKB       = '" & CF_Ora_String(.Item_Detail(pc_COL_DATKB).Dsp_Value, 1) & "' " '�N��
				' 2006/11/21  ADD END
				strSQL = strSQL & "      , RELFL       = '" & CF_Ora_String("", 1) & "' " '�A�g�t���O
				strSQL = strSQL & "      , OPEID       = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
				strSQL = strSQL & "      , CLTID       = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c
				strSQL = strSQL & "      , WRTTM       = '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
				strSQL = strSQL & "      , WRTDT       = '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
				' 2006/11/19  ADD START  KUMEDA
				strSQL = strSQL & "      , UOPEID      = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
				strSQL = strSQL & "      , UCLTID      = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�o�b�`�j
				strSQL = strSQL & "      , UWRTTM      = '" & GV_SysTime & "' " '�^�C���X�^���v�i�o�b�`���ԁj
				strSQL = strSQL & "      , UWRTDT      = '" & GV_SysDate & "' " '�^�C���X�^���v�i�o�b�`���t�j
				' 2006/11/19  ADD END
				'ADD START FKS)INABA 2009/10/08 *************************************
				'�A���[��FC09101403
				strSQL = strSQL & ",UPDFLG = '" & .Bus_Inf.UPDFLG & "' " '(04)�X�V�����ύX�\�t���O
				strSQL = strSQL & ",PRTFLG = '" & .Bus_Inf.PRTFLG & "'" '(06)��������ύX�\�t���O
				strSQL = strSQL & ",FILEFLG ='" & .Bus_Inf.FILEFLG & "'" '(08)�t�@�C���o�͌����ύX�\�t���O
				strSQL = strSQL & ",SALTFLG ='" & .Bus_Inf.SALTFLG & "'" '(10)�̔��P���ύX�����ύX�\�t���O
				strSQL = strSQL & ",HDNTFLG ='" & .Bus_Inf.HDNTFLG & "'" '(12)�����P���ύX�����ύX�\�t���O
				strSQL = strSQL & ",SAPMFLG ='" & .Bus_Inf.SAPMFLG & "'" '(14)�̔��v��N���v��C�������ύX�\�t���O
				'ADD  END  FKS)INABA 2009/10/08 *************************************
				strSQL = strSQL & "  Where KNGGRCD     = '" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' " '�����O���[�v
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSQL = strSQL & "    And PGID        = '" & CF_Ora_String(.Item_Detail(pc_COL_PGID).Dsp_Value, 8) & "' " '�v���O�����h�c
			End With
			'ADD START FKS)INABA 2009/10/08 *************************************
			'�A���[��FC09101403
		End If
		'ADD  END  FKS)INABA 2009/10/08 *************************************
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_KNGMTB_Update_err
		End If
		
		F_KNGMTB_Update = 0
		
F_KNGMTB_Update_End: 
		Exit Function
		
F_KNGMTB_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_011, pm_All, "F_KNGMTB_Update")
		GoTo F_KNGMTB_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Foot_In_Ready
	'   �T�v�F  �t�b�^���̓��͏���
	'   �����F�@pm_All      : �S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		
		'�t�b�^�����ŏ���
		For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
			Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
				'�r���������������������������������������������������������r
				'�d���������������������������������������������������������d
				' === 20060825 === DELETE S
				'            '������Ԃœ��͉\�Ⱥ��۰�
				'                '���͉\
				'                Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
				' === 20060825 === DELETE E
			End Select
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_MN_Enabled
	'   �T�v�F  ���j���[�g�p�ې���
	'   �����F�@pm_All        : �S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_MN_Enabled(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		F_Ctl_MN_Enabled = 9
		
		'���݂̃t�H�[�J�X�ʒu�ɉ����āA�e���۰ق̎g�p�ۂ𐧌�
		Select Case pm_All.Dsp_Base.Cursor_Idx
			Case Else
				'�o�^
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'            '�I��
				'            Trg_Index = CInt(FR_SSSMAIN.MN_EndCm.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'            '��ʏ�����
				'            Trg_Index = CInt(FR_SSSMAIN.MN_APPENDC.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '���ڏ�����
				'            Trg_Index = CInt(FR_SSSMAIN.MN_ClearItm.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '���ڕ���
				'            Trg_Index = CInt(FR_SSSMAIN.MN_UnDoItem.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '���׍s������
				'            Trg_Index = CInt(FR_SSSMAIN.MN_ClearDE.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '���׍s�폜
				'            Trg_Index = CInt(FR_SSSMAIN.MN_DeleteDE.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '���׍s�}��
				'            Trg_Index = CInt(FR_SSSMAIN.MN_InsertDE.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '���׍s����
				'            Trg_Index = CInt(FR_SSSMAIN.MN_UnDoDe.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '�؂���
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Cut.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '�R�s�[
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Copy.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '�\��t��
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Paste.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '�O��
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Prev.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '����
				'            Trg_Index = CInt(FR_SSSMAIN.MN_NextCm.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '�ꗗ�\��
				'            Trg_Index = CInt(FR_SSSMAIN.MN_SelectCm.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'            '�E�C���h�E�\��
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Slist.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '���[�h�ύX
				'            Trg_Index = CInt(FR_SSSMAIN.MN_UPDKB.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
		End Select
		
		'���j���[�{�^���C���[�W�̉�����
		'�I���{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_EndCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'�o�^�{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_Execute.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_Execute.Tag)
		'' 2007/01/11  START ���ɖ߂�
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		''    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = pv_InpTan_KNG
		'' 2007/01/11  END
		'    '���׍s�}���{�^��
		'    Trg_Index = CInt(FR_SSSMAIN.CM_INSERTDE.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_InsertDE.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '���׍s�폜�{�^��
		'    Trg_Index = CInt(FR_SSSMAIN.CM_DELETEDE.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_DeleteDE.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '�����{�^��
		'    Trg_Index = CInt(FR_SSSMAIN.CM_SLIST.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_Slist.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'�O�Ń{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_PREV.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Prev.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'���Ń{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_NEXTCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_NextCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '�ꗗ�\���{�^��
		'    Trg_Index = CInt(FR_SSSMAIN.CM_SelectCm.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_SelectCm.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_MN_Enabled = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_PageButton_Enabled
	'   �T�v�F  �O�y�[�W�E���y�[�W�g�p�ې���
	'   �����F�@pm_All           : �S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_PageButton_Enabled(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		F_Ctl_PageButton_Enabled = 9
		
		'�O��
		Trg_Index = CShort(FR_SSSMAIN.MN_Prev.Tag)
		If NowPageNum > MinPageNum Then
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		Else
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
		End If
		'����
		Trg_Index = CShort(FR_SSSMAIN.MN_NextCm.Tag)
		If NowPageNum < MaxPageNum Then
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		Else
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
		End If
		
		'�O�Ń{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_PREV.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Prev.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'���Ń{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_NEXTCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_NextCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_PageButton_Enabled = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Inp_Item_Focus_Ctl
	'   �T�v�F  ���̓R���g���[���̎g�p�ې���
	'   �����F�@pm_Value              :�ݒ�l
	'           pm_All                :�S�\����
	'   �ߒl�F�@��������
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Inp_Item_Focus_Ctl(ByRef pm_Value As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		F_Set_Inp_Item_Focus_Ctl = 9
		
		If pm_Value = True Then
			'�y�[�W���i���݃y�[�W�A�ő�y�[�W���̑ޔ�ϐ��j���N���A
			'���׃y�[�W��������
			MaxPageNum = 1
			NowPageNum = 1
		End If
		
		F_Set_Inp_Item_Focus_Ctl = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Clr_Dsp
	'   �T�v�F  �e��ʂ̍��ڂ�������
	'   �����F�@pm_Index    :�I�u�W�F�N�g�̃C���f�b�N�X
	'   �ߒl�F  �Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp(ByRef pm_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Wk_Index_S As Short
		Dim Wk_Index_E As Short
		Dim Wk_Mode As Short
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
		
		If pm_Index = -1 Then
			Wk_Index_S = 1
			Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
			pm_All.Dsp_Base.Head_Ok_Flg = False
			Wk_Mode = ITM_ALL_CLR
		Else
			Wk_Index_S = pm_Index
			Wk_Index_E = pm_Index
			Wk_Mode = ITM_ALL_ONLY
		End If
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			
			'���ʏ�����
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
			
			'�S�̏������̏ꍇ
			If Wk_Mode = ITM_ALL_CLR Then
				'�{�f�B���ȍ~�̍��ڂ�S̫����Ȃ��Ƃ���
				If Index_Wk > pm_All.Dsp_Base.Head_Lst_Idx Then
					Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
				End If
			End If
			
			'�r���������������������������������������������������������r
			'�d���������������������������������������������������������d
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Clr_Dsp_Body
	'   �T�v�F  �e��ʂ̃{�f�B���ڂ�������
	'   �����F�@pm_Bd_Index     :���׍s�C���f�b�N�X
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Bd_Wk As Short
		Dim Wk_Bd_Index_S As Short
		Dim Wk_Bd_Index_E As Short
		Dim Wk_Mode As Short
		Dim Wk_Index As Short
		Dim Wk_Row As Short
		
		If pm_Bd_Index = -1 Then
			Wk_Bd_Index_S = 0
			Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
			
			'��ʃ{�f�B���
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
			
			'�r���������������������������������������������������������r
			'        '�X�N���[��������
			'        '�ő�l
			'        Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '�ŏ��l
			'        Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '�ő彸۰ٗ�
			'        Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Cnt - 1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '�ŏ���۰ٗ�
			'        Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '�����l
			'        Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'�d���������������������������������������������������������d
			Wk_Mode = BODY_ALL_CLR
		Else
			Wk_Bd_Index_S = pm_Bd_Index
			Wk_Bd_Index_E = pm_Bd_Index
			Wk_Mode = BODY_ALL_ONLY
		End If
		
		For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
			
			'���ʏ�����
			Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
			
			'�z��O�̏�������Ώۍs�ɃR�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
			
			'�S�̏������̏ꍇ
			If Wk_Mode = BODY_ALL_CLR Then
				'�S�s�������
				pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
			End If
			
			'�ʏ�����
			''�r���������������������������������������������������������r
			'        '�ȉ��̺��۰ق͖��ו����̺��۰قł���΂Ȃ�ł��n�j�ł�
			'        '(�Ώۂ̖��ׂ̔ԍ���񂾂����K�v�A)
			'        Wk_Index = CInt(FR_SSSMAIN.BD_CTLCD(Index_Bd_Wk).Tag)
			''�d���������������������������������������������������������d
			'        'Dsp_Body_Inf�̍s�m�n�ɕϊ�
			'        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			''�r���������������������������������������������������������r
			'        'Dsp_Body_Inf�ɒl�������l��ݒ�
			'        Call F_Init_Dsp_Body(Wk_Row, pm_All)
			''�d���������������������������������������������������������d
			
		Next 
		
		gv_bolKNGMT51_INIT = False
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Cursor_Set
	'   �T�v�F  ��ʏ�����Ԏ��̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Index_Cnt As Short
		
		'�r���������������������������������������������������������r
		'�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
		'�����O���[�v�Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_KNGGRCD.Tag)
		
		'̫����ړ�
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'���ڐF�ݒ�
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'�d���������������������������������������������������������d
		
	End Function
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Cursor_Set
	'   �T�v�F  �t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Index_Cnt As Short
		Dim Index_Wk As Short
		
		'�r���������������������������������������������������������r
		'�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
		'�t�H�[�J�X���������
		For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
			If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True Then
				'�������ޯ���擾
				Trg_Index = CShort(pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Tag)
				
				Exit For
			End If
		Next 
		
		'̫����ړ�
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'���ڐF�ݒ�
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'�d���������������������������������������������������������d
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Cmn_Ctl_MN_InsertDE
	'   �T�v�F  ���j���[�̖��ב}���̋��ʐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Cmn_Ctl_MN_InsertDE(ByRef pm_Bd_Index As Short, ByRef pm_Ins_Bd_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		'UPGRADE_WARNING: �\���� WK_Dsp_Body_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim WK_Dsp_Body_Inf As Cls_Dsp_Body_Inf
		Dim Max_Row As Short
		Dim Wk_Row As Short
		Dim Wk_Row_New As Short
		Dim Iput_Cnt As Short
		Dim Input_Wait_Cnt As Short
		
		F_Cmn_Ctl_MN_InsertDE = False
		
		'�������\������
		'����͑ҏ�ԣ�̌������擾
		Input_Wait_Cnt = 0
		For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
				Input_Wait_Cnt = Input_Wait_Cnt + 1
				Exit For
			End If
		Next 
		
		If Input_Wait_Cnt > 0 Then
			'����͑ҏ�ԣ�����݂��Ă���ꍇ�A�}���s�I�I
			MsgBox("�󔒂̖��׍s���ɍ폜���Ă��������B")
			F_Cmn_Ctl_MN_InsertDE = False
			Exit Function
		End If
		
		'���݂̍ő�s���擾
		Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		
		'�ꎞ�ޔ�
		ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		Iput_Cnt = 0
		For Wk_Row = 1 To Max_Row
			'�Ώۍs�ɃR�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
				'����͍Ϗ�ԣ
				Iput_Cnt = Iput_Cnt + 1
			End If
			
		Next 
		
		'�����`�F�b�N
		If pm_All.Dsp_Base.Max_Body_Cnt > 0 Then
			'�ő���͖��א����ݒ肳�ꂢ��ꍇ
			If Iput_Cnt >= pm_All.Dsp_Base.Max_Body_Cnt Then
				'����͏�ԣ�̌������ő���͖��א��ɓ��B����ꍇ
				MsgBox("���׍s�͂���ȏ�}���ł��܂���B")
				F_Cmn_Ctl_MN_InsertDE = False
				Exit Function
			End If
		End If
		
		Wk_Row_New = 0
		Iput_Cnt = 0
		For Wk_Row = 1 To Max_Row
			
			If Wk_Row = pm_Bd_Index Then
				'�Ώۍs�̏ꍇ
				Wk_Row_New = Wk_Row_New + 1
				'����
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
				'�z��̏�������Ώۍs�ɃR�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
				
				'�������㢓��͑ҏ�ԣ
				pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_INPUT_WAIT
				
				'�ǉ��s���ďo���ɒʒm
				pm_Ins_Bd_Index = Wk_Row_New
				
			End If
			
			Select Case WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Status
				Case BODY_ROW_STATE_DEFAULT, BODY_ROW_STATE_INPUT
					'�������ԣ�A����͍Ϗ�ԣ�����ޔ�
					Wk_Row_New = Wk_Row_New + 1
					'����
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
					
					'�Ώۍs�ɃR�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
					
			End Select
			
		Next 
		
		'���׏��̍s��Ԃ��Đݒ�
		Call CF_Set_Body_Row_Status(pm_All)
		
		F_Cmn_Ctl_MN_InsertDE = True
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Cmn_Ctl_MN_DeleteDE
	'   �T�v�F  ���j���[�̖��׍폜�̋��ʐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Cmn_Ctl_MN_DeleteDE(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Short
		
		'UPGRADE_WARNING: �\���� WK_Dsp_Body_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim WK_Dsp_Body_Inf As Cls_Dsp_Body_Inf
		Dim Max_Row As Short
		Dim Wk_Row As Short
		Dim Wk_Row_New As Short
		Dim Def_Cnt As Short
		Dim Iput_Cnt As Short
		Dim Copy_Flg As Boolean
		Dim Input_Wait_Row As Short
		Dim Wk_Col As Short
		
		'�������\������
		'����͑ҏ�ԣ�̍s�ԍ����擾
		Input_Wait_Row = 0
		For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
				Input_Wait_Row = Wk_Row
				Exit For
			End If
		Next 
		
		If Input_Wait_Row > 0 Then
			'����͑ҏ�ԣ�����݂��Ă���ꍇ�A�����艺�̍s�̍폜�s�I�I
			If pm_Bd_Index > Input_Wait_Row Then
				MsgBox("�󔒂̖��׍s���ɍ폜���Ă��������B")
				F_Cmn_Ctl_MN_DeleteDE = False
				Exit Function
			End If
		End If
		
		'�������A�t�]������I
		pm_Row_Inf_Max_S = 0
		pm_Row_Inf_Max_E = -1
		
		'���݂̍ő�s���擾
		Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		
		'�ꎞ�ޔ�
		ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		For Wk_Row = 1 To Max_Row
			'�Ώۍs�ɃR�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		Next 
		
		Copy_Flg = True
		Wk_Row_New = pm_All.Dsp_Body_Inf.Cur_Top_Index - 1
		Def_Cnt = 1 '�K���P�s�͍폜�����ׁA�������ԣ�̊J�n���P����Ƃ���
		Iput_Cnt = 0
		For Wk_Row = pm_All.Dsp_Body_Inf.Cur_Top_Index To pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1
			'�ŏI�����s�ȍ~�̓R�s�[���Ȃ�
			If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
				Copy_Flg = False
			End If
			
			'�s������
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
			
			If Wk_Row = pm_Bd_Index Then
				'�Ώۍs�̏ꍇ
				'�폜�s�𕜌����ɑޔ�
				Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf)
				'�����s
				pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = Wk_Row
				'�������̗L(���׍폜�̕������)
				pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_DEL
				
				'�G���[��̏ꍇ�A���ڐF��߂�
				For Wk_Col = 2 To UBound(WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail)
					If WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(Wk_Col).Err_Status > ERR_NOT Then
						Call F_Reset_Item_Color(Wk_Row, Wk_Col)
					End If
				Next 
			Else
				Wk_Row_New = Wk_Row_New + 1
				If Copy_Flg = True Then
					'�Ώۍs�ɃR�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
				End If
				
				If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_DEFAULT Then
					'�������ԣ
					Def_Cnt = Def_Cnt + 1
				End If
				
				If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_INPUT Then
					'����͍Ϗ�ԣ
					Iput_Cnt = Iput_Cnt + 1
				End If
				
			End If
		Next 
		
		'���׏��̍s��Ԃ��Đݒ�
		Call CF_Set_Body_Row_Status(pm_All)
		
		'�z�񐔂��ύX���Ȃ��ꍇ�́A�ŏI�s�̏��������K�v
		If Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
			pm_Row_Inf_Max_S = Max_Row
			pm_Row_Inf_Max_E = Max_Row
		End If
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Reset_Item_Color
	'   �T�v�F  ���G���[�̂��������ڂ̐F��߂�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Reset_Item_Color(ByRef pm_Wk_Row As Short, ByRef pm_Wk_Col As Short) As Short
		
		Select Case pm_Wk_Col
			' 2006/11/21  ADD START  KUMEDA
			Case pc_COL_DATKB '�N��
				FR_SSSMAIN.BD_UPDAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
				' 2006/11/21  ADD END
			Case pc_COL_UPDAUTH '�X�V
				FR_SSSMAIN.BD_UPDAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_PRTAUTH '���
				FR_SSSMAIN.BD_PRTAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_FILEAUTH '�t�@�C���o��
				FR_SSSMAIN.BD_FILEAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_SALTAUTH '�̔��P���ύX
				FR_SSSMAIN.BD_SALTAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_HDNTAUTH '�����P���ύX
				FR_SSSMAIN.BD_HDNTAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_SAPMAUTH '�̔��v��N���v��C��
				FR_SSSMAIN.BD_SAPMAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
		End Select
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Input_Str
	'   �T�v�F  ���͕����𔻒肷��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Jge_Input_Str(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef Pm_Moji As String) As Short
		'�������i���͕s�j
		F_Jge_Input_Str = 0
		
		'���͕����^�C�v�Ő���
		Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
			Case IN_STR_TYP_X
				'���p�p���̂�
				If (Pm_Moji >= "0" And Pm_Moji <= "9") Or (Pm_Moji >= "a" And Pm_Moji <= "z") Or (Pm_Moji >= "A" And Pm_Moji <= "Z") Or (Pm_Moji = " ") Then
					F_Jge_Input_Str = 1
				End If
				' 2006/12/01  ADD START  KUMEDA
				Pm_Moji = UCase(Pm_Moji)
				' 2006/12/01  ADD END
				
		End Select
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20061031 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_Inp_KNG
	'   �T�v�F  ���͒S���ҍX�V�����擾
	'   �����F�@pm_Form        :�t�H�[��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_Inp_KNG(ByRef pm_All As Cls_All) As Short
		
		'������
		pv_InpTan_KNG = False
		
		'' 2006/11/13  CHG START  KUMEDA
		''    '���[�U�[�h�c���
		''    gs_userid = Inp_Inf.InpTanCd
		''    '�v���O�����h�c���
		''    gs_pgid = SSS_PrgId
		''
		''    '�������e�`�F�b�N
		''    gs_kengen = Get_Authority(GV_UNYDate)
		''' 2006/11/02  CHG START  KUMEDA
		'''    If gs_kengen = "1" Then
		'''        pv_InpTan_KNG = True
		'''    End If
		''    If gs_UPDAUTH = "1" Then
		''        pv_InpTan_KNG = True
		''    End If
		''' 2006/11/02  CHG END
		If Inp_Inf.InpJDNUPDKB = "1" Then
			pv_InpTan_KNG = True
		End If
		'' 2006/11/13  CHG END
		
	End Function
	' === 20061031 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Item_Change
	'   �T�v�F  �Ώۍ��ڂ�CHANGE�̐���
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_CurMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Move_Flg As Boolean
		
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Select Case True
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'÷���ޯ���̏ꍇ
				'���݂�÷�ď�̑I����Ԃ��擾
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
				Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
				
				'���݂̒l���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
				
				Wk_EditMoji = ""
				
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_NUM
						'���l���ڂ̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_DATE
						'���t���ڂ̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_CODE, IN_TYP_STR
						'�R�[�h�A��������
						Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
							'�ύX��̒l�ϊ�
							Case IN_STR_TYP_N
								'�S�p�̏ꍇ
								'���p�󔒁ˑS�p��
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = Space(1) Then
										Wk_EditMoji = Wk_EditMoji & "�@"
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
							Case Else
								'�S�p�ȊO
								'���p�󔒁ˑS�p��
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = "�@" Then
										Wk_EditMoji = Wk_EditMoji & Space(2)
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
						End Select
					Case IN_TYP_YYYYMM
						'�N�����ڂ̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case IN_TYP_HHMM
						'�������ڂ̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case Else
				End Select
				
				'�ҏW��̕�����\���`���ɕϊ�
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
				
				'�I�𕶎��Ɠ��͕����̒u������
				'�����ݒ�
				Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
				
				'����̫����ʒu����E�ֈړ�
				Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, pm_All, True)
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
				
		End Select
		
		'���͌㏈��
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'���ד��͌�̌㏈��
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	'======================= �ύX���� 2006.06.12 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Item_GotFocus
	'   �T�v�F  �Ώۍ��ڂ�GOTFOCUS�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_GotFocus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Move_Flg As Boolean
		
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = False Then
			'̫������󂯎��Ȃ��ꍇ
			'@'        '���̍��ڂ�̫����ړ�
			'@'        If TypeOf pm_Dsp_Sub_Inf.Ctl Is SSCommand5 Then
			'@'            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, Move_Flg, pm_All)
			'@'        Else
			'@'        '���̍��ڂ�̫����ړ�
			'@'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
			'@'        End If
			
			'���̍��ڂ�̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
		Else
			
			'�ړ��O�ƈقȂ�ꍇ�̂ݑޔ�
			If pm_All.Dsp_Base.Cursor_Idx <> CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'�O̫����̲��ޯ����ޔ�
				pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
				'�ړ���̲��ޯ����ޔ�
				pm_All.Dsp_Base.Cursor_Idx = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
			End If
			
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
		End If
		
	End Function
	'======================= �ύX���� 2006.06.12 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_KeyPress
	'   �T�v�F  �Ώۍ��ڂ�KEYPRESS�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyPress(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_KeyAscii As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim All_Sel_Flg As Boolean
		Dim wk_Moji As String
		Dim Wk_SelMoji As String
		Dim Wk_BefMoji As String
		Dim Wk_DelMoji As String
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_CurMoji As String
		Dim Input_Flg As Boolean
		Dim Re_Body_Crt As Boolean
		Dim intRet As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'���̓t���O������
		Input_Flg = False
		'���ו��č쐬�t���O������
		Re_Body_Crt = False
		
		'�ȉ��̓��͂̏ꍇ�A��������
		Select Case pm_KeyAscii
			Case 1 To 7, 9 To 12, 14 To 29, 127
				Beep()
				pm_KeyAscii = 0
				Exit Function
		End Select
		
		'���͕����擾
		wk_Moji = Chr(pm_KeyAscii)
		
		'÷���ޯ���̂ݑΏ�
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			'���݂�÷�ď�̑I����Ԃ��擾
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'���݂̒l���擾
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				All_Sel_Flg = True
			End If
			
			' === 20060825 === UPDATE S
			'        '���̓R�[�h����
			'        If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
			'���̓R�[�h����
			If pm_Dsp_Sub_Inf.Ctl.Name = FR_SSSMAIN.HD_KNGGRCD.Name Then
				'���荀�ڂ������O���[�v�̏ꍇ
				intRet = F_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji)
			Else
				'���荀�ڂ������O���[�v�ȊO�̏ꍇ
				intRet = CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji)
			End If
			
			If intRet = 1 Then
				' === 20060825 === UPDATE E
				'���͉\�����̏ꍇ
				
				'���͉\�ȕ����̏ꍇ�A���͌㏈���A���ו��č쐬���s��
				Input_Flg = True
				Re_Body_Crt = True
				
				'CF_Jge_Input_Str�֐��̕����ύX���l��
				pm_KeyAscii = Asc(wk_Moji)
				
				'���t/�N��/�����ł��I����Ԃ��P�ȊO�̏ꍇ�A���͕s��
				'�\���`�������܂��Ă��邽�߈�����͂�����
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
						If Act_SelLength <> 1 Then
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
				End Select
				
				If All_Sel_Flg = True Then
					'�S�I����
					
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'�l���������l�̏ꍇ
						Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
						
					Else
						'�l���������l�ȊO�̏ꍇ
						Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
						
					End If
					
					'�ҏW��̕�����\���`���ɕϊ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
					
					'�ҏW���SelStart������
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'�l���������l�̏ꍇ
						'�E�[�ֈړ�
						Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
						Wk_SelLength = 0
					Else
						'�l���������l�ȊO�̏ꍇ
						Wk_SelStart = 0
						Wk_SelLength = 1
					End If
					
					'�폜��̕����u������
					'�����ݒ�
					Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
					pm_KeyAscii = 0
					
					'�ҏW���SelStart������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
					'�ҏW���SelLength������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					
					' === 20060801 === INSERT S - �P�����ڂœ��͌�Ƀt�H�[�J�X�ړ����Ȃ����Ƃւ̑Ή�
					'���l���ړ��ʏ���
					If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
						
						'�����������菬�������Ɛݒ�l�������ꍇ
						If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
							'����̫����ʒu����E�ֈړ�
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'�ҏW��̕�����MAX�̏ꍇ
								'����̫����ʒu����E�ֈړ�
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
						
					Else
						'���l���ڈȊO
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'�ҏW��̕�����MAX�̏ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
							'�ҏW���SelLength������
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelLength = 0
							'����̫����ʒu����E�ֈړ�
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
					End If
					' === 20060801 === INSERT E
					
				Else
					'�����I���������́A�I���Ȃ�
					
					If Act_SelLength = 0 Then
						'�I���Ȃ��̏ꍇ(�}�����)
						'�}�������̑O�̕������擾
						Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
						'���l���ړ��ʏ���
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'��{����͎�
									If Trim(Wk_BefMoji) <> "" Then
										'�O��������L�̕����ȊO�͑}���ł��Ȃ�
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'��|����͎�
									If Trim(Wk_BefMoji) <> "" Then
										'�O��������L�̕����ȊO�͑}���ł��Ȃ�
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'��D����͎�
									If InStr(Wk_CurMoji, ".") > 1 Then
										'���łɢ�D������͂��ꂢ��ꍇ
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'�󔒏�����̌��݂̕�����MAX�̏ꍇ�A�I�[�o�[�t���[
							
							'���l���ړ��ʏ���
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'��ԉE�ŃI�[�o�[�t���[�����ꍇ�A���̍��ڂ�
								If Act_SelStart >= Len(Wk_CurMoji) Then
									'�ҏW�O�̊J�n�ʒu����ԉE�̏ꍇ
									'����̫����ʒu����E�ֈړ�
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									'���͕s��
									Beep()
								End If
							Else
								
								'�ҏW��̈ړ���𔻒�
								If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
									'�l���������l�̏ꍇ
								Else
									'�ҏW���SelStart������
									If Act_SelStart + 1 > Len(Wk_CurMoji) Then
										'�P�E�̈ʒu���E�[�̏ꍇ
										Wk_SelStart = Len(Wk_CurMoji)
									Else
										'�P�E��
										Wk_SelStart = Act_SelStart + 1
									End If
									'�ҏW���SelLength������
									Wk_SelLength = 0
									
									'�ҏW���SelStart������
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
									'�ҏW���SelLength������
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
								End If
								
								'���͕s��
								Beep()
							End If
							
							'���͕s��
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'�����ҏW
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + 1)
						
						'�ҏW��̕�����\���`���ɕϊ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'���l���ړ��ʏ���
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'�������Ő���������葽�����͂���Ă���ꍇ
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'�����������菬�������Ɛݒ�l�������ꍇ
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'����̫����ʒu����E�ֈړ�
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						'�ҏW���SelStart������
						If Act_SelStart + 1 > Len(Wk_DspMoji) Then
							'�P�E�̈ʒu���E�[�̏ꍇ
							Wk_SelStart = Len(Wk_DspMoji)
						Else
							'�P�E��
							Wk_SelStart = Act_SelStart + 1
						End If
						'�ҏW���SelLength������
						Wk_SelLength = 0
						
						'�폜��̕����u������
						'�����ݒ�
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0
						
						'�ҏW���SelStart������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'�ҏW���SelLength������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
						'�ҏW��̈ړ���𔻒�
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'�l���������l�̏ꍇ
							
							If Wk_SelStart >= Len(Wk_DspMoji) Then
								'�ҏW��̊J�n�ʒu����ԉE�̏ꍇ
								'���l���ړ��ʏ���
								If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
									'�����������菬�������Ɛݒ�l�������ꍇ
									If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									Else
										If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
											'�ҏW��̕�����MAX�̏ꍇ
											'����̫����ʒu����E�ֈړ�
											Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
										End If
									End If
								Else
									'���l���ڈȊO
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'�ҏW��̕�����MAX�̏ꍇ
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
							End If
						Else
							'�l���������l�ȊO�̏ꍇ
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'�ҏW��̕�����MAX�̏ꍇ
								
								'�ҏW���SelStart������
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
								'�ҏW���SelLength������
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
								
								'����̫����ʒu����E�ֈړ�
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						'�ꕔ�I��
						'���ݑI������Ă��镶���̂P�����擾
						Wk_SelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						If Trim(Wk_SelMoji) <> "" And CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_SelMoji) <> 1 Then
							'�I�𕶎����󕶎��ȊO�ł����͑Ώۂ̕����ȊO�̏ꍇ
							
							'���͕s��
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'���l���ړ��ʏ���
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'��{����͎�
									If Wk_SelMoji <> "-" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'�I�𕶎�����L�̕����ȊO�͒u���������Ȃ�
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'��|����͎�
									If Wk_SelMoji <> "+" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'�I�𕶎�����L�̕����ȊO�͒u���������Ȃ�
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'��D����͎�
									If InStr(Wk_CurMoji, ".") > 0 Then
										'���łɢ�D������͂��ꂢ��ꍇ
										'���͕s��
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						'�����ҏW
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
						
						'�ҏW��̕�����\���`���ɕϊ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'���l���ړ��ʏ���
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'�����������̏ꍇ
							'����������Ő���������葽�����͂���Ă���ꍇ
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'�����������菬�������Ɛݒ�l�������ꍇ
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'����̫����ʒu����E�ֈړ�
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						If Act_SelStart >= Len(Wk_DspMoji) - 1 Then
							'�ҏW�O�̊J�n�ʒu���Ō�̕����ȍ~�̏ꍇ
							'�ҏW���SelStart������
							Wk_SelStart = Len(Wk_DspMoji)
							'�ҏW���SelLength������
							Wk_SelLength = 0
						Else
							'�ҏW���SelStart������
							Wk_SelStart = Act_SelStart
							'�ҏW���SelLength������
							Wk_SelLength = 1
						End If
						
						'���l���ړ��ʏ���
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							If Len(CF_Get_Input_Ok_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) = 1 Then
								'���͉\�ȕ������P���̏ꍇ
								'�J�n�ʒu����ԉE�ɐݒ�
								'�ҏW���SelStart������
								Wk_SelStart = Len(Wk_DspMoji)
								'�ҏW���SelLength������
								Wk_SelLength = 0
							End If
							
						End If
						
						'�ҏW��̕����u������
						'�����ݒ�
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0
						
						'�ҏW���SelStart������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'�ҏW���SelLength������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
						'�ҏW��̈ړ���𔻒�
						If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
							'�ҏW��̊J�n�ʒu���Ō�̕����ȍ~�̏ꍇ
							'���l���ړ��ʏ���
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								
								'�����������菬�������Ɛݒ�l�������ꍇ
								If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
									'����̫����ʒu����E�ֈړ�
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'�ҏW��̕�����MAX�̏ꍇ
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
								
							Else
								'���l���ڈȊO
								If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
									'�ҏW��̕�����MAX�̏ꍇ
									'����̫����ʒu����E�ֈړ�
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								End If
							End If
						Else
							'����̫����ʒu����E�ֈړ�
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
						
					End If
				End If
				
			Else
				'���̓R�[�h�ȊO
				Select Case pm_KeyAscii
					Case System.Windows.Forms.Keys.Back
						'BackSpace�L�[
						pm_KeyAscii = 0
						
						'���t/�N��/�����̏ꍇ
						Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
							Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
								'�폜���SelStart������
								Wk_SelStart = Act_SelStart
								For Wk_Cnt = Act_SelStart - 1 To 0 Step -1
									'�팻�݂̊J�n�ʒu���獶�ֈړ������������͑Ώۂ��𔻒�
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_CurMoji, Wk_Cnt + 1, 1)) = 1 Then
										'���͕����łȂ��ꍇ
										Wk_SelStart = Wk_Cnt
										Exit For
									End If
									
								Next 
								'�ҏW���SelLength������
								Wk_SelLength = Act_SelLength
								
								'�ҏW���SelStart������
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
								'�ҏW���SelLength������
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
								
								'�폜�s��
								Exit Function
							Case Else
								
						End Select
						
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'�l���������l�̏ꍇ
							'�J�n�ʒu�����̏ꍇ�A�I��
							If Act_SelStart = 0 Then
								'�폜�s��
								Exit Function
							End If
							
							'�폜�Ώۂ̕����P�����擾
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
							
							'���l���ړ��ʏ���
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								If Wk_DelMoji = "." Then
									'�폜�Ώۂ̕����������_�̏ꍇ
									If Len(CF_Get_Num_Int_Part(Wk_CurMoji)) + Len(CF_Get_Num_Fra_Part(Wk_CurMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
										'�폜��̌����I�[�o�[�̏ꍇ
										'�폜�s��
										Exit Function
									End If
								End If
							End If
							
							'�폜�����̔���
							If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
								'�폜���������͑Ώۂ̕����̏ꍇ
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'�����ҏW
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'�폜���������͑Ώۂ̕����̈ȊO�ꍇ
								'���̂܂�
								Wk_EditMoji = Wk_CurMoji
							End If
							
							'�폜��̕�����\���`���ɕϊ�
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'�폜���SelStart������
							Wk_SelStart = Act_SelStart
							For Wk_Cnt = Act_SelStart To Len(Wk_CurMoji) - 1
								'�폜��Ɍ��݂̊J�n�ʒu����̕��������͑Ώۂ��𔻒�
								If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_DspMoji, Wk_Cnt + 1, 1)) = 1 Then
									Exit For
								End If
								'���͕����łȂ��ꍇ�A�E�ֈړ�
								Wk_SelStart = Wk_SelStart + 1
							Next 
							'�ҏW���SelLength������
							Wk_SelLength = Act_SelLength
							
							'���l���ړ��ʏ���
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'���l���ڂŖ����͂̏ꍇ�́A��ԉE���J�n�ʒu�ɐݒ�
								If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
									Wk_SelStart = Len(Wk_DspMoji)
									'�ҏW���SelLength������
									Wk_SelLength = 0
								End If
							End If
						Else
							'�l���������l�ȊO�̏ꍇ
							If Act_SelStart = 0 Then
								'�J�n�ʒu����ԍ��̏ꍇ
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'�����ҏW
									Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
								
								'�폜���SelStart������
								Wk_SelStart = Act_SelStart
							Else
								'�����ҏW
								Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								
								'�폜���SelStart������
								Wk_SelStart = Act_SelStart - 1
							End If
							'�ҏW���SelLength������
							Wk_SelLength = Act_SelLength
							
							'�ҏW��̕�����\���`���ɕϊ�
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						End If
						
						'�폜��̕����u������
						'�����ݒ�
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
					Case Else
						pm_KeyAscii = 0
						
				End Select
			End If
		End If
		
		If Input_Flg = True Then
			'���͌㏈��
			Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
		If Re_Body_Crt = True Then
			'���ד��͌�̌㏈��
			Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
	End Function
	
	'======================= �ύX���� 2006.07.02 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Item_MouseDown
	'   �T�v�F  �Ώۍ��ڂ�MOUSEDOWN�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_MouseDown(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Button As Short, ByRef pm_Shift As Short, ByRef pm_X As Single, ByRef pm_Y As Single) As Short
		Dim Wk_Index As Short
		Dim bolSameCtl As Boolean
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'�E�N���b�N
			
			bolSameCtl = False
			If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
				'�E�N���b�N�����R���g���[�����A�N�e�B�u�ȃR���g���[���ƈ�v
				'�J�[�\������p�e�L�X�g�Ƀt�H�[�J�X���ꎞ�I�ɑޔ�
				Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				bolSameCtl = True
			End If
			
			'����ړ��e�R�s�[�����
			FR_SSSMAIN.SM_AllCopy.Enabled = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'����ړ��e�ɓ\��t�������
			FR_SSSMAIN.SM_FullPast.Enabled = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'�ΏۃR���g���[���̎g�p�s��
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'��߯�߱����ƭ������
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'۽�̫�������Ă̗}��
				pm_All.Dsp_Base.LostFocus_Flg = True
				'�߯�߱����ƭ��\��
				'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
				FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
				'۽�̫�������Ă̗}������
				pm_All.Dsp_Base.LostFocus_Flg = False
				System.Windows.Forms.Application.DoEvents()
			End If
			
			'�߯�߱����ƭ��\����Ԃŉ�ʂ̏I�������ɓ����Ă��܂����ꍇ�́A
			'�ȍ~�̏����͍s��Ȃ��B
			If pm_All.Dsp_Base.IsUnload = True Then
				Exit Function
			End If
			
			'�ΏۃR���g���[���̎g�p��
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'�t�H�[�J�X���ړ������ɖ߂�
			If bolSameCtl = True Then
				Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
			End If
			
		End If
		
	End Function
	'======================= �ύX���� 2006.07.02 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_VS_Scrl_CHANGE
	'   �T�v�F  VS_Scrl��MOUSEDOWN�̐���
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_Act_Dsp_Sub_Inf  :��ʍ��ڏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_VS_Scrl_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'�ŏ㖾�ײ��ޯ����ޔ�
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		'======================= �ύX���� 2006.06.26 Start =================================
		'�c�X�N���[���o�[�̒l���ŏ㖾�ײ��ޯ���ɐݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_All.Dsp_Body_Inf.Cur_Top_Index = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
		'��ʃ{�f�B���̔z����Đݒ�
		Call CF_Dell_Refresh_Body_Inf(pm_All)
		'======================= �ύX���� 2006.06.26 End =================================
		'��ʕ\��
		'Call CF_Body_Dsp(pm_All)
		Call F_Body_Dsp(pm_All)
		
		'��è�޺��۰ق����ו��̂ݐ���
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'���݂̍s���擾
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'̫�������
			'�ړ���
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'�ړ���̍s
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'�ړ���̍s�̂̓��ꍀ�ڂ̲��ޯ�����擾
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'������۰ق̏ꍇ
					'�I����Ԃ̐ݒ�i�����I���j
					Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
				Else
					'������۰قłȂ��ꍇ
					'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'��ֈړ�
						'�w�b�_���̍Ō�̍��ڂ̂P��납��
						'�P�O�̍��ڂ�
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'���ֈړ�
						'�t�b�^���̍ŏ��̍��ڂ̂P�O����
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Dsp_Body_Page
	'   �T�v�F  ���ו����̃y�[�W����
	'   �����F�@pm_Page_Value       :���ׂ̃y�[�W��
	'           pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_all              :�S�\����
	'           pm_Border_Body_Cnt  :
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Dsp_Body_Page(ByRef pm_Page_Value As Short, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, Optional ByRef pm_Border_Body_Cnt As Short = 0) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'    '�y�[�W�{�^���g�p�ې���
		'    Call F_Ctl_PageButton_Enabled(pm_All)
		
		'�ŏ㖾�ײ��ޯ����ޔ�
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'    '��ʂ̓��e��ޔ�
		'    Call CF_Body_Bkup(pm_All)
		'�ŏ㖾�ײ��ޯ���ɐݒ�
		'�i��ʕ\�����א��|���E���א��j�~�i�y�[�W���|�P�j�{�P�@�@�˂P�A�U�A�P�P�A�P�U�ƂȂ�
		pm_All.Dsp_Body_Inf.Cur_Top_Index = (pm_All.Dsp_Base.Dsp_Body_Cnt - pm_Border_Body_Cnt) * (pm_Page_Value - 1) + 1
		'��ʕ\��
		'Call CF_Body_Dsp(pm_All)
		Call F_Body_Dsp(pm_All)
		
		'��è�޺��۰ق����ו��̂ݐ���
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'���݂̍s���擾
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'̫�������
			'�ړ���
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'�ړ���̍s
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'�ړ���̍s�̂̓��ꍀ�ڂ̲��ޯ�����擾
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'������۰ق̏ꍇ
					'�I����Ԃ̐ݒ�i�����I���j
					Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
				Else
					'������۰قłȂ��ꍇ
					'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'��ֈړ�
						'�w�b�_���̍Ō�̍��ڂ̂P��납��
						'�P�O�̍��ڂ�
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'���ֈړ�
						'�t�b�^���̍ŏ��̍��ڂ̂P�O����
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	'======================= �ύX���� 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_Cmn_DE_Focus
	'   �T�v�F  ���j���[�̖��׏������^���׍폜�^���ו������̃t�H�[�J�X����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Cmn_DE_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Boolean
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Trg_Index_Same_Row As Short
		
		'��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		If Trg_Index > 0 Then
			If Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'�ړ��悪�����ꍇ
				If pm_Dsp_Sub_Inf.Ctl.TabStop = True Then
					'�I����Ԃ̐ݒ�i�����I���j
					Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
					
				Else
					'��Ԃ��ŏI�����s�̏ꍇ
					If pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Status = BODY_ROW_STATE_LST_ROW Then
						'                If pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Status = BODY_ROW_STATE_LST_ROW Or _
						''                   pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
						'���s�̍X�V�̲��ޯ���擾
						Trg_Index_Same_Row = CShort(FR_SSSMAIN.BD_UPDAUTH(pm_Row).Tag)
						'̫����ړ�
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index_Same_Row), pm_All)
					Else
						'̫����ړ�
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index - pm_All.Dsp_Base.Body_Col_Cnt), pm_All)
					End If
				End If
				
			Else
				'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
			
		Else
			'���͉\�ȍŏ��̃C���f�b�N�X���擾
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
	End Function
	'======================= �ύX���� 2006.06.26 End =================================
	
	'======================= �ύX���� 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_ClearDE
	'   �T�v�F  ���j���[�̖��׏������̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Wk As Short
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'���ʂ̖��׏�����
		If CF_Cmn_Ctl_MN_ClearDE(Bd_Index, pm_All) = True Then
			'�r���������������������������������������������������������r
			'�Ɩ��̏����l��ҏW
			Call F_Init_Dsp_Body(Bd_Index, pm_All)
			
			'�s�m���̔ԏ���
			Call F_Edi_Saiban_No(pm_All)
			'�d���������������������������������������������������������d
			
			'��ʕ\��
			'Call CF_Body_Dsp(pm_All)
			Call F_Body_Dsp(pm_All)
			
			'���̉�ʂ̍s�Ɉړ�
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'�t�H�[�J�X����
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= �ύX���� 2006.06.26 End =================================
	
	'======================= �ύX���� 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_DeleteDE
	'   �T�v�F  ���j���[�̖��׍폜�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_DeleteDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		Dim Max_Row As Short
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'���ʂ̖��׍폜
		'Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		Call F_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		'�r���������������������������������������������������������r
		'�y�[�W�̍Đݒ�
		If (UBound(pm_All.Dsp_Body_Inf.Row_Inf) Mod pm_All.Dsp_Base.Dsp_Body_Cnt) = 0 Then
			MaxPageNum = UBound(pm_All.Dsp_Body_Inf.Row_Inf) / pm_All.Dsp_Base.Dsp_Body_Cnt
			
			If MaxPageNum < NowPageNum Then
				NowPageNum = MaxPageNum
			End If
		End If
		
		'��ʃ{�f�B���̍Đݒ�
		If UBound(pm_All.Dsp_Body_Inf.Row_Inf) < pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum Then
			Max_Row = pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row)
			
			pm_All.Dsp_Body_Inf.Row_Inf(Max_Row).Item_Detail = VB6.CopyArray(pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail)
		End If
		
		'�Ώۍs�̏�Ԃ��Đݒ�
		For Bd_Index_Wk = 0 To pm_All.Dsp_Base.Dsp_Body_Cnt - 1
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_LST_ROW Then
				'            pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_INPUT_WAIT
			End If
		Next 
		'�d���������������������������������������������������������d
		
		'��ʕ\��
		'    Call CF_Body_Dsp(pm_All)
		Call F_Body_Dsp(pm_All)
		
		'�ҏW�ς݂Ƃ���
		gv_bolKNGMT51_INIT = True
		
		'���̉�ʂ̍s�Ɉړ�
		Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		
		'�t�H�[�J�X����
		Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		
	End Function
	'======================= �ύX���� 2006.06.26 End =================================
	
	'======================= �ύX���� 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_InsertDE
	'   �T�v�F  ���j���[�̖��ב}���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_InsertDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Bd_Index_Wk As Short
		Dim Ins_Bd_Index As Short
		Dim Row_Wk As Short
		Dim Max_Row As Short
		Dim Clm_Cnt As Short
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'���ʂ̖��ב}��
		'If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
		If F_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
			'�r���������������������������������������������������������r
			'�}�������s�̃t�H�[�J�X������ɂ���
			For Clm_Cnt = 2 To 28
				pm_All.Dsp_Body_Inf.Row_Inf(Ins_Bd_Index).Item_Detail(Clm_Cnt).Focus_Ctl = True
			Next 
			
			'��ʃ{�f�B���̍Đݒ�
			If UBound(pm_All.Dsp_Body_Inf.Row_Inf) < pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum Then
				Max_Row = pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row)
				
				pm_All.Dsp_Body_Inf.Row_Inf(Max_Row).Item_Detail = VB6.CopyArray(pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail)
			End If
			
			'�ŏI�s�̍Đݒ�
			For Bd_Index_Wk = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
				If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_DEFAULT Then
					'�Ώۍs�̏�Ԃ��ŏI�����s�ɐݒ�
					pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_LST_ROW
					'�t�H�[�J�X�̐���
					For Clm_Cnt = 2 To 28
						pm_All.Dsp_Body_Inf.Row_Inf(Ins_Bd_Index).Item_Detail(Clm_Cnt).Focus_Ctl = True
					Next 
					
					Exit For
				End If
			Next 
			
			'�Ɩ��̏����l��ҏW
			Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)
			
			'�s�m���̔ԏ���
			Call F_Edi_Saiban_No(pm_All)
			'�d���������������������������������������������������������d
			
			'�Ώۍs����ʂɕ\��
			Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)
			
			'�ҏW�ς݂Ƃ���
			gv_bolKNGMT51_INIT = True
			
			'�ǉ��s�Ɉړ�
			Row_Wk = CF_Idx_To_Bd_Idx(Ins_Bd_Index, pm_All)
			
			'�t�H�[�J�X����
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= �ύX���� 2006.06.26 End =================================
	
	'======================= �ύX���� 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_UnDoDe
	'   �T�v�F  ���j���[�̖��ו����̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'���ʂ̖��ו���
		If CF_Cmn_Ctl_MN_UnDoDe(pm_All, Row_Inf_Max_S, Row_Inf_Max_E) = True Then
			'�r���������������������������������������������������������r
			'�s��ǉ����ꂽ���
			'�����l��ǉ������s�ɑ΂��ă��[�v���łP�s���s��
			'�����ł̍s�́ADsp_Body_Inf�̍s�I�I
			For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
				Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
			Next 
			
			'�s�m���̔ԏ���
			Call F_Edi_Saiban_No(pm_All)
			'�d���������������������������������������������������������d
			
			'��ʕ\��
			'Call CF_Body_Dsp(pm_All)
			Call F_Body_Dsp(pm_All)
			
			'���̉�ʂ̍s�Ɉړ�
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'�t�H�[�J�X����
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= �ύX���� 2006.06.26 Start =================================
	
	'======================= �ύX���� 2006.07.02 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_Paste
	'   �T�v�F  ���j���[�̓\��t���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Paste(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Clip_Value As String
		Dim Paste_Value As String
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_EditMoji As String
		Dim Wk_CurMoji As String
		Dim Wk_DspMoji As String
		
		'�د���ް�ނ�����e�擾
		'UPGRADE_ISSUE: Clipboard ���\�b�h Clipboard.GetText �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
		Clip_Value = My.Computer.Clipboard.GetText()
		'���͕����\�����o��
		Paste_Value = CF_Get_Input_Ok_Item(Clip_Value, pm_Dsp_Sub_Inf)
		
		'�\��t�����e���Ȃ��ꍇ�A�������f
		If Paste_Value = "" Then
			Exit Function
		End If
		
		'���݂�÷�ď�̑I����Ԃ��擾
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		'���݂̒l���擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
		
		If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
			'�l���������l�̏ꍇ
			
			'�����ҏW
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Wk_EditMoji = CF_Cnv_Dsp_Item(Paste_Value, pm_Dsp_Sub_Inf, False)
			
			'�ҏW���SelStart������
			'�E�[�ֈړ�
			Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
			Wk_SelLength = 0
		Else
			'�l���������l�ȊO�̏ꍇ
			
			If Act_SelLength = 0 Then
				'�I���Ȃ��̏ꍇ(�}�����)
				'�����ҏW
				Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + 1)
			Else
				'�ꕔ�I��
				If Act_SelLength >= 2 Then
					'�Q�����ȏ�I�����Ă���ꍇ��
					'�I�𕶎������̕���������
					'�����ҏW
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
				Else
					'�P�����ȉ��I�����Ă���ꍇ��
					'�I�𕶎��ȍ~�͓��ꊷ��
					'�����ҏW
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value
					
				End If
				
			End If
			
			'�ҏW���SelStart������
			'���[�ֈړ�
			Wk_SelStart = 0
			Wk_SelLength = 1
			
		End If
		
		Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
			Case IN_TYP_DATE
				'���t�̏ꍇ�A���͌`�������܂��Ă���ꍇ
				'���t���͌`���̌��������擾
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_DATE))
			Case IN_TYP_YYYYMM
				'�N���̏ꍇ�A���͌`�������܂��Ă���ꍇ
				'���t���͌`���̌��������擾
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_YYYMM))
			Case IN_TYP_HHMM
				'�����̏ꍇ�A���͌`�������܂��Ă���ꍇ
				'���t���͌`���̌��������擾
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_HHMM))
			Case Else
				
		End Select
		
		'�ҏW��̕�����\���`���ɕϊ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
		
		'��ݼ޲���Ă��N�������ɕҏW
		Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
		
		'�ҏW���SelStart������
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
		'�ҏW���SelLength������
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
		
		'���ד��͌�̌㏈��
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	'======================= �ύX���� 2006.07.02 End =================================
	
	'======================= �ύX���� 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Edi_Saiban_No
	'   �T�v�F  �S���ׂ̍s�m�n��ݒ肷��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̏���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Edi_Saiban_No(ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Bd_Index As Short
		
		
	End Function
	'======================= �ύX���� 2006.06.26 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Hardcopy_SSSMAIN
	'   �T�v�F  �n�[�h�R�s�[��ʌďo���㏈��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Hardcopy_SSSMAIN() As Short 'Generated.
		If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		On Error Resume Next
		System.Windows.Forms.Application.DoEvents()
		FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.WaitCursor
		'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PrintForm �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		FR_SSSMAIN.PrintForm()
		FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	'2007/12/18 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_UWRTDTTM
	'   �T�v�F  �X�V���ԃ`�F�b�N����
	'   �����F  pm_All        : ��ʏ��
	'   �ߒl�F�@True�F�`�F�b�NOK�@False�F�`�F�b�NNG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_UWRTDTTM(ByRef pm_All As Cls_All) As Boolean
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim strWRTDT As String
		Dim strWRTTM As String
		Dim strUWRTDT As String
		Dim strUWRTTM As String
		Dim strUWRT_MOTO As String
		' === 20080901 === INSERT S - RISE)Izumi
		Dim strOPEID As String
		Dim strCLTID As String
		Dim strUOPEID As String
		Dim strUCLTID As String
		' === 20080901 === INSERT E - RISE)Izumi
		
		Dim intCnt As Short
		Dim intRet As Short
		Dim strWhere As String
		
		'2007/12/27 add-str M.SUEZAWA
		Dim Upd_Start As Short
		Dim Upd_End As Short
		'2007/12/27 add-end M.SUEZAWA
		
		On Error GoTo F_Chk_UWRTDTTM_err
		
		F_Chk_UWRTDTTM = False
		
		'2007/12/27 add-str M.SUEZAWA
		'���[�v�J�n�A�I���̌v�Z
		Upd_Start = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1
		Upd_End = pm_All.Dsp_Base.Dsp_Body_Cnt * NowPageNum
		'2007/12/27 add-end M.SUEZAWA
		
		'�X�V���Ԏ擾
		'2007/12/27 upd-str M.SUEZAWA
		''    For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		For intCnt = Upd_Start To Upd_End
			'2007/12/27 upd-end M.SUEZAWA
			
			'2007/12/27 add-str T.KAWAMUKAI
			'2007/12/27 upd-str M.SUEZAWA
			''        If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.PGID) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(pc_COL_UPDKB).Dsp_Value) = "" Then
				'2007/12/27 upd-end M.SUEZAWA
				Exit For
			End If
			'2007/12/27 add-end T.KAWAMUKAI
			
			'2007/12/27 add-str M.SUEZAWA
			''        strUWRT_MOTO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTDT) _
			'''                     & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTTM)
			' === 20080902 === UPDATE S - RISE)Izumi
			'        strUWRT_MOTO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_WRTDT) _
			''                     & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_WRTTM) _
			''                     & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTDT) _
			''                     & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTTM)
			strUWRT_MOTO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_WRTDT) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_WRTTM) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTDT) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTTM) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_OPEID) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_CLTID) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UOPEID) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UCLTID)
			' === 20080902 === UPDATE E - RISE)Izumi
			'2007/12/27 add-end M.SUEZAWA
			If strUWRT_MOTO <> "" Then
				'�X�V���Ԏ擾
				'2007/12/27 upd-str T.KAWAMUKAI
				''            intRet = F_Get_UWRTDTTM("TRKMTA",
				' === 20080901 === UPDATE S - RISE)Izumi
				'            intRet = F_Get_UWRTDTTM("KNGMTB", _
				''                                    pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.KNGGRCD, _
				''                                    pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.PGID, _
				''                                    strWRTDT, _
				''                                    strWRTTM, _
				''                                    strUWRTDT, _
				''                                    strUWRTTM)
				intRet = F_Get_UWRTDTTM("KNGMTB", pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.KNGGRCD, pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.PGID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, strOPEID, strCLTID, strUOPEID, strUCLTID)
				' === 20080901 === UPDATE E - RISE)Izumi
				'2007/12/27 upd-end T.KAWAMUKAI
				If intRet <> 0 Then
					GoTo F_Chk_UWRTDTTM_End
				End If
				
				'�X�V���ԃ`�F�b�N
				' === 20080902 === UPDATE S - RISE)Izumi
				'            If Trim(strWRTDT) & Trim(strWRTTM) & Trim(strUWRTDT) & Trim(strUWRTTM) <> strUWRT_MOTO Then
				'                GoTo F_Chk_UWRTDTTM_End
				'            End If
				If Trim(strWRTDT) & Trim(strWRTTM) & Trim(strUWRTDT) & Trim(strUWRTTM) & Trim(strOPEID) & Trim(strCLTID) & Trim(strUOPEID) & Trim(strUCLTID) <> strUWRT_MOTO Then
					GoTo F_Chk_UWRTDTTM_End
				End If
				' === 20080902 === UPDATE E - RISE)Izumi
			End If
		Next 
		
		F_Chk_UWRTDTTM = True
		
F_Chk_UWRTDTTM_End: 
		Exit Function
		
F_Chk_UWRTDTTM_err: 
		GoTo F_Chk_UWRTDTTM_End
		
	End Function
	
	' === 20080902 === UPDATE S - RISE)Izumi
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F  Function F_Get_UWRTDTTM
	''   �T�v�F  �X�V���t���Ԏ擾����
	''   �����F  pin_strTBLNM            : �����Ώۃe�[�u����
	''           pin_strKNGGRCD          : �����O���[�v
	''           pin_strPGID             : �v���O�����h�c
	''           pot_strWRTDT            : �X�V���t
	''           pot_strWRTTM            : �X�V����
	''           pot_strUWRTDT           : �o�b�`�X�V���t
	''           pot_strUWRTTM           : �o�b�`�X�V����
	''   �ߒl�F  0 : ����I��  9 : �ُ�I��
	''   ���l�F
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_Get_UWRTDTTM(ByVal pin_strTBLNM As String, _
	''                                ByVal pin_strKNGGRCD As String, _
	''                                ByVal pin_strPGID As String, _
	''                                ByRef pot_strWRTDT As String, _
	''                                ByRef pot_strWRTTM As String, _
	''                                ByRef pot_strUWRTDT As String, _
	''                                ByRef pot_strUWRTTM As String) As Integer
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_UWRTDTTM
	'   �T�v�F  �X�V���t���Ԏ擾����
	'   �����F  pin_strTBLNM            : �����Ώۃe�[�u����
	'           pin_strKNGGRCD          : �����O���[�v
	'           pin_strPGID             : �v���O�����h�c
	'           pot_strWRTDT            : �X�V���t
	'           pot_strWRTTM            : �X�V����
	'           pot_strUWRTDT           : �o�b�`�X�V���t
	'           pot_strUWRTTM           : �o�b�`�X�V����
	'           pot_strOPEID            : �ŏI��Ǝ҃R�[�h
	'           pot_strCLTID            : �N���C�A���g�h�c
	'           pot_strUOPEID           : �ŏI��Ǝ҃R�[�h�i�o�b�`�j
	'           pot_strUCLTID           : �N���C�A���g�h�c�i�o�b�`�j
	'   �ߒl�F  0 : ����I��  9 : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_UWRTDTTM(ByVal pin_strTBLNM As String, ByVal pin_strKNGGRCD As String, ByVal pin_strPGID As String, ByRef pot_strWRTDT As String, ByRef pot_strWRTTM As String, ByRef pot_strUWRTDT As String, ByRef pot_strUWRTTM As String, ByRef pot_strOPEID As String, ByRef pot_strCLTID As String, ByRef pot_strUOPEID As String, ByRef pot_strUCLTID As String) As Short
		' === 20080902 === UPDATE E - RISE)Izumi
		
		On Error GoTo F_Get_UWRTDTTM_ERR
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		
		F_Get_UWRTDTTM = 9
		
		'// ������
		pot_strWRTDT = ""
		pot_strWRTTM = ""
		pot_strUWRTDT = ""
		pot_strUWRTTM = ""
		' === 20080902 === INSERT S - RISE)Izumi
		pot_strOPEID = ""
		pot_strCLTID = ""
		pot_strUOPEID = ""
		pot_strUCLTID = ""
		' === 20080902 === INSERT E - RISE)Izumi
		
		'�����`�F�b�N
		If Trim(pin_strKNGGRCD) = "" Or Trim(pin_strPGID) = "" Then
			GoTo F_Get_UWRTDTTM_END
		End If
		
		Str_Sql = ""
		Str_Sql = Str_Sql & " SELECT "
		Str_Sql = Str_Sql & "        WRTDT  "
		Str_Sql = Str_Sql & "      , WRTTM  "
		Str_Sql = Str_Sql & "      , UWRTDT "
		Str_Sql = Str_Sql & "      , UWRTTM "
		' === 20080901 === INSERT S - RISE)Izumi
		Str_Sql = Str_Sql & "      , OPEID  "
		Str_Sql = Str_Sql & "      , CLTID "
		Str_Sql = Str_Sql & "      , UOPEID "
		Str_Sql = Str_Sql & "      , UCLTID "
		' === 20080901 === INSERT E - RISE)Izumi
		Str_Sql = Str_Sql & "   FROM "
		Str_Sql = Str_Sql & "        " & Trim(pin_strTBLNM)
		Str_Sql = Str_Sql & "   WHERE "
		Str_Sql = Str_Sql & "        KNGGRCD  = '" & Trim(pin_strKNGGRCD) & "'"
		Str_Sql = Str_Sql & "    AND PGID     = '" & Trim(pin_strPGID) & "'"
		' === 20080901 === INSERT S - RISE)Izumi
		Str_Sql = Str_Sql & "    FOR UPDATE"
		' === 20080901 === INSERT E - RISE)Izumi
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo F_Get_UWRTDTTM_ERR
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strWRTDT = Trim(CF_Ora_GetDyn(Usr_Ody, "WRTDT"))
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strWRTTM = Trim(CF_Ora_GetDyn(Usr_Ody, "WRTTM"))
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strUWRTDT = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTDT"))
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strUWRTTM = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTTM"))
			' === 20080902 === INSERT S - RISE)Izumi
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strOPEID = Trim(CF_Ora_GetDyn(Usr_Ody, "OPEID"))
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strCLTID = Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID"))
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strUOPEID = Trim(CF_Ora_GetDyn(Usr_Ody, "UOPEID"))
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strUCLTID = Trim(CF_Ora_GetDyn(Usr_Ody, "UCLTID"))
			' === 20080902 === INSERT E - RISE)Izumi
		End If
		
		F_Get_UWRTDTTM = 0
		
F_Get_UWRTDTTM_END: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
F_Get_UWRTDTTM_ERR: 
		GoTo F_Get_UWRTDTTM_END
		
	End Function
	'2007/12/18 add-end M.SUEZAWA
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module