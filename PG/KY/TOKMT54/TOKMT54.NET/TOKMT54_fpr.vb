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
	Public gv_bolTOKMT54_INIT As Boolean '��ʏ������t���O�iTrue:�ύX����j
	' === 20060801 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���E����W�\�����̕s��Ή�
	Public gv_bolTOKMT54_LF_Enable As Boolean 'LF�������s�t���O(False�F���s���Ȃ�)
	Public gv_bolKeyFlg As Boolean
	' === 20060801 === INSERT E
	' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
	Public gv_bolUpdFlg As Boolean
	' === 20060808 === INSERT E
	Public gv_bolSelectCmFlg As Boolean '�ꗗ�\���t���O�iTrue:�ꗗ�\���{�^�������j
	
	Public Structure TOKMT54_TYPE_TOKMTA
		Dim DATKB As String '�폜�敪
		Dim DSPKB As String '�����\���敪
		Dim TOKCD As String '���Ӑ�R�[�h
		Dim TOKRN As String '���Ӑ旪��
		' 2006/11/15  ADD START  KUMEDA
		Dim UDPATE As String '�X�V�t���O
		' 2006/11/15  ADD END
	End Structure
	'���Ӑ�}�X�^���
	Public TOKMT54_TOKMTA_Inf As TOKMT54_TYPE_TOKMTA
	
	Public Structure TOKMT54_TYPE_MEIMTA
		Dim DATKB As String '�폜�敪
		Dim MEICDA As String '�R�[�h�P
		Dim MEINMA As String '���̂P
	End Structure
	'���̃}�X�^���
	Public TOKMT54_MEIMTA_Inf As TOKMT54_TYPE_MEIMTA
	
	Public Structure TOKMT54_TYPE_TRKMTA
		Dim UPDKB As String '���[�h
		Dim DATKB As String '�폜�敪
		Dim TOKCD As String '���Ӑ�R�[�h
		Dim SKHINGRP As String '�d�ؗp���i�Q
		Dim TRKRNK As String '�����N
		Dim STTKSTDT As String '�J�n�P���ݒ���t
		Dim BEFDATKB As String '�ύX�O�폜�敪
		' === 20080926 === INSERT S - RISE)Izumi
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char '�N���C�A���g�h�c�i�o�b�`�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
		' === 20080926 === INSERT E - RISE)Izumi
	End Structure
	'���Ӑ�ʏ��i�����N�}�X�^���
	Public TOKMT54_TRKMTA_Inf As TOKMT54_TYPE_TRKMTA
	
	' === 20080926 === DELETE S - RISE)Izumi
	'' === 20080909 === INSERT S - RISE)Izumi
	'Public Type M_TYPE_TRKMTA_MOTO
	'    TOKCD           As String           '���Ӑ�R�[�h
	'    SKHINGRP        As String           '�d�ؗp���i�Q
	'    STTKSTDT        As String           '�J�n�P���ݒ���t
	'    OPEID           As String * 8       '�ŏI��Ǝ҃R�[�h
	'    CLTID           As String * 5       '�N���C�A���g�h�c
	'    UOPEID          As String * 8       '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
	'    UCLTID          As String * 5       '�N���C�A���g�h�c�i�o�b�`�j
	'    WRTTM           As String * 6       '��ѽ����(����)        9(06)
	'    WRTDT           As String * 8       '��ѽ����(���t)        YYYY/MM/DD
	'    UWRTTM          As String * 6       '��ѽ����(����)        9(06)
	'    UWRTDT          As String * 8       '��ѽ����(���t)        YYYY/MM/DD
	'End Type
	'Public M_TRKMTA_MOTO_inf       As M_TYPE_TRKMTA_MOTO
	'Public M_TRKMTA_MOTO_A_inf()   As M_TYPE_TRKMTA_MOTO
	'' === 20080909 === INSERT E - RISE)Izumi
	' === 20080926 === DELETE E - RISE)Izumi
	
	'�y�[�W���
	Public MaxPageNum As Short '���ׂ̍ő�y�[�W��
	Public NowPageNum As Short '���ׂ̌��݂̃y�[�W��
	Public MinPageNum As Short '���ׂ̍ŏ��y�[�W��
	
	'�C���f�b�N�X���
	Public Current_Skhingrp_Index As Short '�d�ؗp���i�Q�̑���Ώۍs
	
	'��\��ЃR�[�h
	Public pv_TOKMT54_TOKCD As String
	'�d�ؗp���i�Q
	Public pv_TOKMT54_SKHINGRP As String
	'�K�p��
	Public pv_TOKMT54_STTKSTDT As String
	
	'���͎Ҍ���
	Public pv_InpTan_TOK As Boolean 'True:�������� False:�����Ȃ�
	
	'���[�h
	Public Const UPDKB_INS As String = "�ǉ�"
	Public Const UPDKB_UPD As String = "�X�V"
	Public Const UPDKB_DEL As String = "�폜"
	
	'��ԍ�
	Private Const pc_COL_UPDKB As Short = 1 '���[�h
	Private Const pc_COL_SKHINGRP As Short = 2 '�d�ؗp���i�Q
	Private Const pc_COL_STTKSTDT As Short = 3 '�K�p��
	Private Const pc_COL_TRKRNK As Short = 4 '�����N
	' 2006/11/15  ADD START  KUMEDA
	Private Const pc_COL_UPDATE As Short = 5 '�X�V�t���O
	' 2006/11/15  ADD END
	
	'
	Private pv_bolMEISAI_INPUT As Boolean '���ד��̓t���O(True:���͂���j
	Private pv_intMeisaiCnt As Short '���͖��א��i�X�V���g�p�j
	Private pv_bolInput_Bef_Row As Boolean '�O�s���̓t���O�iTrue:���͍ρj
	
	Private Const pv_Skhingrp_Keycode As String = "043" '���̃}�X�^�̎d�ؗp���i�Q�R�[�h
	Private Const pv_Trkrnk_Keycode As String = "064" '���̃}�X�^�̎d�؃����N�R�[�h
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
	'   ���́F  Function F_GET_TRK_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_TRK_SQL() As String
		
		Dim strSQL As String
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     DATKB " '�`�[�폜�敪
		strSQL = strSQL & "    ,TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "    ,SKHINGRP " '�d�ؗp���i�Q
		strSQL = strSQL & "    ,TRKRNK " '�����N
		strSQL = strSQL & "    ,TRKOEM " '�n�d�l
		strSQL = strSQL & "    ,STTKSTDT " '�J�n�P���ݒ���t
		strSQL = strSQL & "    ,NBKRT " '�l����
		' === 20080909 === INSERT S - RISE)Izumi
		strSQL = strSQL & "    ,OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "    ,CLTID " '�N���C�A���g�h�c
		strSQL = strSQL & "    ,WRTTM " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "    ,WRTDT " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "    ,UOPEID " '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		strSQL = strSQL & "    ,UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "    ,UWRTTM " '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "    ,UWRTDT " '�^�C���X�^���v�i�o�b�`���t�j
		' === 20080909 === INSERT E - RISE)Izumi
		strSQL = strSQL & " From "
		strSQL = strSQL & "     TRKMTA "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     TOKCD = '" & CF_Ora_String(pv_TOKMT54_TOKCD, 10) & "' "
		
		'�d�ؗp���i�Q�ɓ��͂�����ꍇ
		If Trim(pv_TOKMT54_SKHINGRP) <> "" Then
			strSQL = strSQL & " And SKHINGRP >= '" & CF_Ora_String(pv_TOKMT54_SKHINGRP, 4) & "' "
		End If
		
		'    '�K�p���ɓ��͂�����ꍇ
		'    If Trim(pv_TOKMT54_STTKSTDT) <> "" Then
		'        strSQL = strSQL & " And STTKSTDT >= '" & CF_Ora_Date(pv_TOKMT54_STTKSTDT) & "'"
		'    End If
		
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     SKHINGRP "
		strSQL = strSQL & "    ,STTKSTDT DESC"
		
		F_GET_TRK_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA
	'   �T�v�F  �{�f�B���f�[�^�擾
	'   �����F  pm_all      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA(ByRef pm_All As Cls_All) As Short
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		
		On Error GoTo ERR_F_GET_BD_DATA
		
		F_GET_BD_DATA = -1
		
		'������
		strSQL = ""
		Err_Cd = ""
		' === 20080926 === DELETE S - RISE)Izumi
		'' === 20080910 === INSERT S - RISE)Izumi
		'    '�^�C���X�^���v���̏�����
		'    Erase M_TRKMTA_MOTO_A_inf
		'    ReDim M_TRKMTA_MOTO_A_inf(0)
		'' === 20080910 === INSERT E - RISE)Izumi
		' === 20080926 === DELETE E - RISE)Izumi
		
		'�����r�p�k����
		strSQL = F_GET_TRK_SQL()
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'�擾�f�[�^�Ȃ�
			F_GET_BD_DATA = 0
			Err_Cd = gc_strMsgTOKMT54_E_002
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
			Exit Function
		Else
			
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
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
					If .Bus_Inf.DATKB = gc_strDATKB_USE Then
						'�g�p��
						.Bus_Inf.UPDKB = UPDKB_UPD '���[�h
					Else
						'�폜
						.Bus_Inf.UPDKB = UPDKB_DEL '���[�h
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "") '�d�ؗp���i�Q
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.TRKRNK = CF_Ora_GetDyn(Usr_Ody, "TRKRNK", "") '�����N
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.STTKSTDT = CF_Ora_GetDyn(Usr_Ody, "STTKSTDT", "") '�J�n�P���ݒ���t
					' === 20080926 === UPDATE S - RISE)Izumi
					'' === 20080910 === INSERT S - RISE)Izumi
					'                ReDim Preserve M_TRKMTA_MOTO_A_inf(intCnt)
					'                '�^�C���X�^���v��ޔ�
					'                With M_TRKMTA_MOTO_A_inf(intCnt)
					'                    .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")
					'                    .SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "")
					'                    .STTKSTDT = CF_Ora_GetDyn(Usr_Ody, "STTKSTDT", "")
					'                    .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
					'                    .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
					'                    .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")
					'                    .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")
					'                    .UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")
					'                    .UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")
					'                    .UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")
					'                    .UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")
					'                End With
					'' === 20080910 === INSERT E - RISE)Izumi
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.Bus_Inf.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")
					' === 20080926 === UPDATE E - RISE)Izumi
					
					'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
					'���[�h
					Wk_Index = CShort(FR_SSSMAIN.BD_UPDKB(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.UPDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'�d�ؗp���i�Q
					Wk_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SKHINGRP, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(2).Focus_Ctl = True
					'�K�p��
					Wk_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.STTKSTDT, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(3).Focus_Ctl = True
					'�����N
					Wk_Index = CShort(FR_SSSMAIN.BD_TRKRNK(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.TRKRNK, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(4).Focus_Ctl = True
					' 2006/11/15  ADD START  KUMEDA
					'�X�V�t���O
					Wk_Index = CShort(FR_SSSMAIN.BD_UPDATE(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.UPDATE, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(5).Focus_Ctl = True
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
					
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Index_Wk), ITEM_NORMAL_STATUS, pm_All)
					
					'�t�H�[�J�X�L���̔���
					Fcs_Flg = F_Jge_Focus(Index_Wk, pm_All, Available_Flg)
					'�t�H�[�J�X�̐���
					Call CF_Set_Item_Focus_Ctl(Fcs_Flg, pm_All.Dsp_Sub_Inf(Index_Wk))
					
					'�f�[�^�L�s�m�n�̑ޔ�
					If Available_Flg = True Then
						Index_Of_Window = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					End If
				End If
				
			Next 
			
			'��\��Ђ������͂̏ꍇ
			If (Index_Of_Window = 0) And (Trim(FR_SSSMAIN.HD_TOKCD.Text) = "") Then
				Exit Function
			End If
			
			'�\���f�[�^������ʕ\�����א���菬�����ꍇ
			If Index_Of_Window < pm_All.Dsp_Base.Dsp_Body_Cnt Then
				'�f�[�^�ŏI�s�̎��s��Index���擾
				Index_Wk = CShort(FR_SSSMAIN.BD_SKHINGRP(Index_Of_Window + 1).Tag)
				'�P�s�̃t�H�[�J�X�̐���
				For Index_Cnt = Index_Wk To Index_Wk + pm_All.Dsp_Base.Body_Col_Cnt - 2
					Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Cnt))
				Next 
				
				'�f�[�^�ŏI�s��Index���擾
				Index_Wk = CShort(FR_SSSMAIN.BD_SKHINGRP(Index_Of_Window).Tag)
				'���s�̉�ʃ{�f�B�s��Ԃ��ŏI�����s�ɐݒ�
				Call F_Set_NextRow_Status(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
			End If
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
		
		'������
		F_Jge_Focus = False
		pm_Av_Flg = False
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(pm_Index_Tag), pm_All)
		
		'���ڂ��u���[�h�v�łȂ��ꍇ
		If pm_All.Dsp_Sub_Inf(pm_Index_Tag).Ctl.Name <> FR_SSSMAIN.BD_UPDKB(1).Name Then
			'�Ώۍs�̏�Ԃ�������ԈȊO�̏ꍇ
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status <> BODY_ROW_STATE_DEFAULT Then
				F_Jge_Focus = True
				pm_Av_Flg = True
				
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
		'    Call CF_Edi_Dsp_Body_Inf(pm_Bd_Index _
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
		'���s�̉�ʃ{�f�B�s��Ԃ��ŏI�����s�ɐݒ�
		Call F_Set_NextRow_Status(pm_Dsp_Sub_Inf, pm_All)
		
		' 2006/11/15  CHG START  KUMEDA
		'    gv_bolTOKMT54_INIT = True
		Call F_SET_UPDFLG(pm_Dsp_Sub_Inf, pm_All)
		' 2006/11/15  ADD END
		
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
			If (pm_Dsp_Sub_Inf.Detail.Body_Index = 1) And (pm_Dsp_Sub_Inf.Ctl.Tag <> FR_SSSMAIN.BD_SKHINGRP(1).Tag) Then
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(1).Tag) + 1
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
						' === 20060825 === UPDATE S
						'                    Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
						Case NEXT_FOCUS_MODE_KEYDOWN
							' === 20060825 === UPDATE E
							'KEYRETURN�AKEYDOWN�̏ꍇ
							'======================= �ύX���� 2006.07.02 End =================================
							'�����J�n�̓t�b�^���̍ŏ��̍��ڂ���
							Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
							
							' === 20060825 === UPDATE S
							'                    Case NEXT_FOCUS_MODE_KEYRIGHT
						Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYRIGHT
							' === 20060825 === UPDATE E
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
								Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) - pm_All.Dsp_Base.Body_Col_Cnt + 1
								
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
				'            'ͯ�ޕ�����
				'            Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				'�d���������������������������������������������������������d
				If Rtn_Chk <> CHK_OK Then
					'�`�F�b�N�m�f�̏ꍇ
					'�L�[�t���O�����ɖ߂�
					gv_bolKeyFlg = False
					Exit For
				End If
				''' === 20060824 === INSERT E
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
						' === 20060825 === UPDATE S
						If pm_Chk_Dsp_Sub_Inf.Ctl.Name <> FR_SSSMAIN.BD_SKHINGRP(1).Name Then
							'���ڂ��d�ؗp���i�Q�ȊO�̏ꍇ
							' === 20060825 === UPDATE E
							'���f
							Rtn_Cd = CHK_STOP
							'���b�Z�[�W��\��
							pm_Msg_Flg = False
							'�ړ���
							pm_Move = True
							'�`�F�b�N�n�j
							pm_Err_Rtn = CHK_OK
							' === 20060825 === UPDATE S
						End If
						' === 20060825 === UPDATE E
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
									pm_Move = True
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
								'                            '�ړ��n�j
								'                            pm_Move = True
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
	
	' 2006/11/15  ADD START  KUMEDA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TGRPCD_SEARCH
	'   �T�v�F  ��\��ЃR�[�h����
	'   �����F�@pin_strTOKCD�F���Ӑ�R�[�h
	'   �ߒl�F�@����
	'   ���l�F�@���Ӑ悪��\��ЃR�[�h�Ƃ��Ďw�肳��Ă��邩�̔��f
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TGRPCD_SEARCH(ByVal pin_strTOKCD As String) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		
		On Error GoTo ERR_TGRPCD_SEARCH
		
		TGRPCD_SEARCH = 0
		
		strSQL = ""
		strSQL = strSQL & " Select count(1) as DataCnt"
		strSQL = strSQL & "   from TOKMTA "
		strSQL = strSQL & "  Where TGRPCD = '" & pin_strTOKCD & "' "
		strSQL = strSQL & "    and DATKB = '1' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'�擾�f�[�^����
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			TGRPCD_SEARCH = CF_Ora_GetDyn(Usr_Ody, "DataCnt", "")
			GoTo END_TGRPCD_SEARCH
		End If
		
END_TGRPCD_SEARCH: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_TGRPCD_SEARCH: 
		GoTo END_TGRPCD_SEARCH
		
	End Function
	' 2006/11/15  ADD END
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HD_TOKCD
	'   �T�v�F  ���Ӑ�R�[�h������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TOKCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_TOKMTA
		Dim Mst_Inf_Clr As TYPE_DB_TOKMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_TOKCD = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		Call DB_TOKMTA_Clear(Mst_Inf)
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			TOKMT54_TOKMTA_Inf.DATKB = Mst_Inf_Clr.DATKB
			TOKMT54_TOKMTA_Inf.DSPKB = Mst_Inf_Clr.DSPKB
			TOKMT54_TOKMTA_Inf.TOKCD = Mst_Inf_Clr.TOKCD '���Ӑ�R�[�h
			TOKMT54_TOKMTA_Inf.TOKRN = Mst_Inf_Clr.TOKRN '���Ӑ旪��
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgTOKMT54_E_001
			Else
				'�}�X�^�`�F�b�N
				If DSPTOKCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
					'�_���폜�`�F�b�N
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgTOKMT54_E_003
						'�����\���敪�`�F�b�N
					ElseIf Mst_Inf.DSPKB = gc_strDSPKB_NG Then 
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgTOKMT54_E_004
					Else
						' 2006/11/15  ADD START  KUMEDA
						If TGRPCD_SEARCH(Input_Value) > 0 Then
							' 2006/11/15  ADD END
							'�n�j
							Retn_Code = CHK_OK
							pm_Chk_Move = True
							TOKMT54_TOKMTA_Inf.DATKB = Mst_Inf.DATKB
							TOKMT54_TOKMTA_Inf.DSPKB = Mst_Inf.DSPKB
							TOKMT54_TOKMTA_Inf.TOKCD = Mst_Inf.TOKCD '���Ӑ�R�[�h
							TOKMT54_TOKMTA_Inf.TOKRN = Mst_Inf.TOKRN '���Ӑ旪��
							' 2006/11/15  ADD START  KUMEDA
						Else
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgTOKMT54_E_023
						End If
						' 2006/11/15  ADD END
					End If
					'�Y���f�[�^����
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgTOKMT54_E_002
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
		
		F_Chk_HD_TOKCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_SKHINGRP
	'   �T�v�F  �d�ؗp���i�Q������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_SKHINGRP(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf_T As TYPE_DB_TRKMTA
		Dim Mst_Inf_M As TYPE_DB_MEIMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		Dim Wk_Row As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_SKHINGRP = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'��ʂ̍s
		Wk_Row = pm_Chk_Dsp_Sub_Inf.Detail.Body_Index
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			'�K�p���������͂̏ꍇ
			If Trim(FR_SSSMAIN.BD_STTKSTDT(Wk_Row).Text) = "" Then
				TOKMT54_TRKMTA_Inf.UPDKB = "" '���[�h
				TOKMT54_TRKMTA_Inf.DATKB = "" '�폜�敪
				TOKMT54_TRKMTA_Inf.TOKCD = Space(10) '���Ӑ�R�[�h
				TOKMT54_TRKMTA_Inf.SKHINGRP = Space(4) '�d�ؗp���i�Q
				TOKMT54_TRKMTA_Inf.TRKRNK = Space(1) '�����N
				TOKMT54_TRKMTA_Inf.STTKSTDT = Space(8) '�J�n�P���ݒ���t
				
				'�K�p���ɓ��͂�����ꍇ
			Else
				TOKMT54_TRKMTA_Inf.UPDKB = UPDKB_INS '���[�h�i�ǉ��j
				TOKMT54_TRKMTA_Inf.DATKB = gc_strDATKB_USE '�`�[�폜�敪
				TOKMT54_TRKMTA_Inf.TOKCD = FR_SSSMAIN.HD_TOKCD.Text '���Ӑ�R�[�h
				TOKMT54_TRKMTA_Inf.SKHINGRP = Space(4) '�d�ؗp���i�Q
				TOKMT54_TRKMTA_Inf.TRKRNK = FR_SSSMAIN.BD_TRKRNK(Wk_Row).Text '�����N
				TOKMT54_TRKMTA_Inf.STTKSTDT = FR_SSSMAIN.BD_STTKSTDT(Wk_Row).Text '�J�n�P���ݒ���t
			End If
			' === 20080926 === INSERT S - RISE)Izumi
			'�^�C���X�^���v���폜
			With pm_All.Dsp_Body_Inf.Row_Inf(pm_Chk_Dsp_Sub_Inf.Detail.Body_Index)
				.Bus_Inf.TOKCD = "" '���Ӑ�R�[�h
				.Bus_Inf.SKHINGRP = "" '�d�ؗp���i�Q
				.Bus_Inf.STTKSTDT = "" '�J�n�P���ݒ���t
				.Bus_Inf.OPEID = "" '�ŏI��Ǝ҃R�[�h
				.Bus_Inf.CLTID = "" '�N���C�A���g�h�c
				.Bus_Inf.WRTTM = "" '�X�V����
				.Bus_Inf.WRTDT = "" '�X�V���t
				.Bus_Inf.UOPEID = "" '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
				.Bus_Inf.UCLTID = "" '�N���C�A���g�h�c�i�o�b�`�j
				.Bus_Inf.UWRTTM = "" '�o�b�`�X�V����
				.Bus_Inf.UWRTDT = "" '�o�b�`�X�V���t
			End With
			' === 20080926 === INSERT E - RISE)Izumi
			Retn_Code = CHK_ERR_NOT_INPUT
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgTOKMT54_E_001
			Else
				Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
					Case CHK_FROM_ALL_CHK
						'�ꊇ�`�F�b�N�̏ꍇ
						'���̃}�X�^�`�F�b�N
						If DSPMEIM_SEARCH(pv_Skhingrp_Keycode, Input_Value, Mst_Inf_M) = 0 Then
							'�_���폜�`�F�b�N
							If Mst_Inf_M.DATKB = gc_strDATKB_DEL Then
								Retn_Code = CHK_ERR_ELSE
								Err_Cd = gc_strMsgTOKMT54_E_003
							End If
							'�Y���f�[�^����
						Else
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgTOKMT54_E_016
						End If
						
					Case Else
						'�ꊇ�`�F�b�N�ȊO�̏ꍇ
						'�}�X�^�`�F�b�N
						If TRKMTA_SEARCH_ALL(Input_Value, FR_SSSMAIN.BD_STTKSTDT(Wk_Row).Text, Mst_Inf_T) = 0 Then
							'�Y���f�[�^�L��
							Retn_Code = CHK_OK
							pm_Chk_Move = True
							If Mst_Inf_T.DATKB = gc_strDATKB_USE Then
								TOKMT54_TRKMTA_Inf.UPDKB = UPDKB_UPD '���[�h�i�X�V�j
							Else
								TOKMT54_TRKMTA_Inf.UPDKB = UPDKB_DEL '���[�h�i�폜�j
							End If
							TOKMT54_TRKMTA_Inf.DATKB = Mst_Inf_T.DATKB '�`�[�폜�敪
							TOKMT54_TRKMTA_Inf.TOKCD = Mst_Inf_T.TOKCD '���Ӑ�R�[�h
							TOKMT54_TRKMTA_Inf.SKHINGRP = Mst_Inf_T.SKHINGRP '�d�ؗp���i�Q
							TOKMT54_TRKMTA_Inf.TRKRNK = Mst_Inf_T.TRKRNK '�����N
							TOKMT54_TRKMTA_Inf.STTKSTDT = Mst_Inf_T.STTKSTDT '�J�n�P���ݒ���t
							' === 20080926 === UPDATE S - RISE)Izumi
							'' === 20080909 === INSERT S - RISE)Izumi
							'                        ReDim Preserve M_TRKMTA_MOTO_A_inf(Wk_Row)
							'                        '�^�C���X�^���v��ޔ�
							'                        With M_TRKMTA_MOTO_A_inf(Wk_Row)
							'                            .SKHINGRP = Mst_Inf_T.SKHINGRP
							'                            .TOKCD = Mst_Inf_T.TOKCD
							'                            .STTKSTDT = Mst_Inf_T.STTKSTDT
							'                            .OPEID = Mst_Inf_T.OPEID
							'                            .CLTID = Mst_Inf_T.CLTID
							'                            .WRTTM = Mst_Inf_T.WRTTM
							'                            .WRTDT = Mst_Inf_T.WRTDT
							'                            .UOPEID = Mst_Inf_T.UOPEID
							'                            .UCLTID = Mst_Inf_T.UCLTID
							'                            .UWRTTM = Mst_Inf_T.UWRTTM
							'                            .UWRTDT = Mst_Inf_T.UWRTDT
							'                        End With
							'' === 20080909 === INSERT E - RISE)Izumi
							'�^�C���X�^���v��ޔ�
							With pm_All.Dsp_Body_Inf.Row_Inf(pm_Chk_Dsp_Sub_Inf.Detail.Body_Index)
								.Bus_Inf.TOKCD = Mst_Inf_T.TOKCD '���Ӑ�R�[�h
								.Bus_Inf.SKHINGRP = Mst_Inf_T.SKHINGRP '�d�ؗp���i�Q
								.Bus_Inf.STTKSTDT = Mst_Inf_T.STTKSTDT '�J�n�P���ݒ���t
								.Bus_Inf.OPEID = Mst_Inf_T.OPEID '�ŏI��Ǝ҃R�[�h
								.Bus_Inf.CLTID = Mst_Inf_T.CLTID '�N���C�A���g�h�c
								.Bus_Inf.WRTTM = Mst_Inf_T.WRTTM '�X�V���t
								.Bus_Inf.WRTDT = Mst_Inf_T.WRTDT '�X�V����
								.Bus_Inf.UOPEID = Mst_Inf_T.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
								.Bus_Inf.UCLTID = Mst_Inf_T.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
								.Bus_Inf.UWRTTM = Mst_Inf_T.UWRTTM '�o�b�`�X�V����
								.Bus_Inf.UWRTDT = Mst_Inf_T.UWRTDT '�o�b�`�X�V���t
							End With
							' === 20080926 === UPDATE E - RISE)Izumi
							
							'�Y���f�[�^����
						Else
							' === 20080926 === INSERT S - RISE)Izumi
							'�^�C���X�^���v���폜
							With pm_All.Dsp_Body_Inf.Row_Inf(pm_Chk_Dsp_Sub_Inf.Detail.Body_Index)
								.Bus_Inf.TOKCD = "" '���Ӑ�R�[�h
								.Bus_Inf.SKHINGRP = "" '�d�ؗp���i�Q
								.Bus_Inf.STTKSTDT = "" '�J�n�P���ݒ���t
								.Bus_Inf.OPEID = "" '�ŏI��Ǝ҃R�[�h
								.Bus_Inf.CLTID = "" '�N���C�A���g�h�c
								.Bus_Inf.WRTTM = "" '�X�V����
								.Bus_Inf.WRTDT = "" '�X�V���t
								.Bus_Inf.UOPEID = "" '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
								.Bus_Inf.UCLTID = "" '�N���C�A���g�h�c�i�o�b�`�j
								.Bus_Inf.UWRTTM = "" '�o�b�`�X�V����
								.Bus_Inf.UWRTDT = "" '�o�b�`�X�V���t
							End With
							' === 20080926 === INSERT E - RISE)Izumi
							'���̃}�X�^�`�F�b�N
							If DSPMEIM_SEARCH(pv_Skhingrp_Keycode, Input_Value, Mst_Inf_M) = 0 Then
								'�_���폜�`�F�b�N
								If Mst_Inf_M.DATKB = gc_strDATKB_DEL Then
									Retn_Code = CHK_ERR_ELSE
									Err_Cd = gc_strMsgTOKMT54_E_003
								Else
									'�n�j
									Retn_Code = CHK_OK
									pm_Chk_Move = True
									TOKMT54_TRKMTA_Inf.UPDKB = UPDKB_INS '���[�h�i�ǉ��j
									TOKMT54_TRKMTA_Inf.DATKB = gc_strDATKB_USE '�`�[�폜�敪
									TOKMT54_TRKMTA_Inf.TOKCD = FR_SSSMAIN.HD_TOKCD.Text '���Ӑ�R�[�h
									TOKMT54_TRKMTA_Inf.SKHINGRP = Input_Value '�d�ؗp���i�Q
									TOKMT54_TRKMTA_Inf.TRKRNK = FR_SSSMAIN.BD_TRKRNK(Wk_Row).Text '�����N
									TOKMT54_TRKMTA_Inf.STTKSTDT = FR_SSSMAIN.BD_STTKSTDT(Wk_Row).Text '�J�n�P���ݒ���t
								End If
								'�Y���f�[�^����
							Else
								Retn_Code = CHK_ERR_ELSE
								Err_Cd = gc_strMsgTOKMT54_E_016
							End If
						End If
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
		
		F_Chk_BD_SKHINGRP = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_STTKSTDT
	'   �T�v�F  �K�p��������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :�`�F�b�N����
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_STTKSTDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf_T As TYPE_DB_TRKMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		Dim Wk_Row As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_STTKSTDT = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'��ʂ̍s
		Wk_Row = pm_Chk_Dsp_Sub_Inf.Detail.Body_Index
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			'�d�ؗp���i�Q�������͂̏ꍇ
			If Trim(FR_SSSMAIN.BD_SKHINGRP(Wk_Row).Text) = "" Then
				TOKMT54_TRKMTA_Inf.UPDKB = "" '���[�h
				TOKMT54_TRKMTA_Inf.DATKB = "" '�폜�敪
				TOKMT54_TRKMTA_Inf.TOKCD = Space(10) '���Ӑ�R�[�h
				TOKMT54_TRKMTA_Inf.SKHINGRP = Space(4) '�d�ؗp���i�Q
				TOKMT54_TRKMTA_Inf.TRKRNK = Space(1) '�����N
				TOKMT54_TRKMTA_Inf.STTKSTDT = Space(8) '�J�n�P���ݒ���t
				
				'�d�ؗp���i�Q�ɓ��͂�����ꍇ
			Else
				TOKMT54_TRKMTA_Inf.UPDKB = UPDKB_INS '���[�h�i�ǉ��j
				TOKMT54_TRKMTA_Inf.DATKB = gc_strDATKB_USE '�`�[�폜�敪
				TOKMT54_TRKMTA_Inf.TOKCD = FR_SSSMAIN.HD_TOKCD.Text '���Ӑ�R�[�h
				TOKMT54_TRKMTA_Inf.SKHINGRP = FR_SSSMAIN.BD_SKHINGRP(Wk_Row).Text '�d�ؗp���i�Q
				TOKMT54_TRKMTA_Inf.TRKRNK = FR_SSSMAIN.BD_TRKRNK(Wk_Row).Text '�����N
				TOKMT54_TRKMTA_Inf.STTKSTDT = Space(8) '�J�n�P���ݒ���t
			End If
			' === 20080926 === INSERT S - RISE)Izumi
			'�^�C���X�^���v���폜
			With pm_All.Dsp_Body_Inf.Row_Inf(pm_Chk_Dsp_Sub_Inf.Detail.Body_Index)
				.Bus_Inf.TOKCD = "" '���Ӑ�R�[�h
				.Bus_Inf.SKHINGRP = "" '�d�ؗp���i�Q
				.Bus_Inf.STTKSTDT = "" '�J�n�P���ݒ���t
				.Bus_Inf.OPEID = "" '�ŏI��Ǝ҃R�[�h
				.Bus_Inf.CLTID = "" '�N���C�A���g�h�c
				.Bus_Inf.WRTTM = "" '�X�V����
				.Bus_Inf.WRTDT = "" '�X�V���t
				.Bus_Inf.UOPEID = "" '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
				.Bus_Inf.UCLTID = "" '�N���C�A���g�h�c�i�o�b�`�j
				.Bus_Inf.UWRTTM = "" '�o�b�`�X�V����
				.Bus_Inf.UWRTDT = "" '�o�b�`�X�V���t
			End With
			' === 20080926 === INSERT E - RISE)Izumi
			Retn_Code = CHK_ERR_NOT_INPUT
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgTOKMT54_E_015 '���͔͈͊O
			Else
				'�}�X�^�`�F�b�N
				If TRKMTA_SEARCH_ALL(FR_SSSMAIN.BD_SKHINGRP(Wk_Row).Text, Input_Value, Mst_Inf_T) = 0 Then
					'�Y���f�[�^�L��
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					If Mst_Inf_T.DATKB = gc_strDATKB_USE Then
						TOKMT54_TRKMTA_Inf.UPDKB = UPDKB_UPD '���[�h�i�X�V�j
					Else
						TOKMT54_TRKMTA_Inf.UPDKB = UPDKB_DEL '���[�h�i�폜�j
					End If
					TOKMT54_TRKMTA_Inf.DATKB = Mst_Inf_T.DATKB '�`�[�폜�敪
					TOKMT54_TRKMTA_Inf.TOKCD = Mst_Inf_T.TOKCD '���Ӑ�R�[�h
					TOKMT54_TRKMTA_Inf.SKHINGRP = Mst_Inf_T.SKHINGRP '�d�ؗp���i�Q
					TOKMT54_TRKMTA_Inf.TRKRNK = Mst_Inf_T.TRKRNK '�����N
					TOKMT54_TRKMTA_Inf.STTKSTDT = Mst_Inf_T.STTKSTDT '�J�n�P���ݒ���t
					' === 20080926 === UPDATE S - RISE)Izumi
					'' === 20080909 === INSERT S - RISE)Izumi
					'                ReDim Preserve M_TRKMTA_MOTO_A_inf(Wk_Row)
					'                '�^�C���X�^���v��ޔ�
					'                With M_TRKMTA_MOTO_A_inf(Wk_Row)
					'                    .SKHINGRP = Mst_Inf_T.SKHINGRP
					'                    .TOKCD = Mst_Inf_T.TOKCD
					'                    .STTKSTDT = Mst_Inf_T.STTKSTDT
					'                    .OPEID = Mst_Inf_T.OPEID
					'                    .CLTID = Mst_Inf_T.CLTID
					'                    .WRTTM = Mst_Inf_T.WRTTM
					'                    .WRTDT = Mst_Inf_T.WRTDT
					'                    .UOPEID = Mst_Inf_T.UOPEID
					'                    .UCLTID = Mst_Inf_T.UCLTID
					'                    .UWRTTM = Mst_Inf_T.UWRTTM
					'                    .UWRTDT = Mst_Inf_T.UWRTDT
					'                End With
					'' === 20080909 === INSERT E - RISE)Izumi
					'�^�C���X�^���v��ޔ�
					With pm_All.Dsp_Body_Inf.Row_Inf(pm_Chk_Dsp_Sub_Inf.Detail.Body_Index)
						.Bus_Inf.TOKCD = Mst_Inf_T.TOKCD '���Ӑ�R�[�h
						.Bus_Inf.SKHINGRP = Mst_Inf_T.SKHINGRP '�d�ؗp���i�Q
						.Bus_Inf.STTKSTDT = Mst_Inf_T.STTKSTDT '�J�n�P���ݒ���t
						.Bus_Inf.OPEID = Mst_Inf_T.OPEID '�ŏI��Ǝ҃R�[�h
						.Bus_Inf.CLTID = Mst_Inf_T.CLTID '�N���C�A���g�h�c
						.Bus_Inf.WRTTM = Mst_Inf_T.WRTTM '�X�V���t
						.Bus_Inf.WRTDT = Mst_Inf_T.WRTDT '�X�V����
						.Bus_Inf.UOPEID = Mst_Inf_T.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
						.Bus_Inf.UCLTID = Mst_Inf_T.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
						.Bus_Inf.UWRTTM = Mst_Inf_T.UWRTTM '�o�b�`�X�V����
						.Bus_Inf.UWRTDT = Mst_Inf_T.UWRTDT '�o�b�`�X�V���t
					End With
					' === 20080926 === UPDATE E - RISE)Izumi
					
					'�Y���f�[�^����
				Else
					' === 20080926 === INSERT S - RISE)Izumi
					'�^�C���X�^���v���폜
					With pm_All.Dsp_Body_Inf.Row_Inf(pm_Chk_Dsp_Sub_Inf.Detail.Body_Index)
						.Bus_Inf.TOKCD = "" '���Ӑ�R�[�h
						.Bus_Inf.SKHINGRP = "" '�d�ؗp���i�Q
						.Bus_Inf.STTKSTDT = "" '�J�n�P���ݒ���t
						.Bus_Inf.OPEID = "" '�ŏI��Ǝ҃R�[�h
						.Bus_Inf.CLTID = "" '�N���C�A���g�h�c
						.Bus_Inf.WRTTM = "" '�X�V����
						.Bus_Inf.WRTDT = "" '�X�V���t
						.Bus_Inf.UOPEID = "" '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
						.Bus_Inf.UCLTID = "" '�N���C�A���g�h�c�i�o�b�`�j
						.Bus_Inf.UWRTTM = "" '�o�b�`�X�V����
						.Bus_Inf.UWRTDT = "" '�o�b�`�X�V���t
					End With
					' === 20080926 === INSERT E - RISE)Izumi
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					TOKMT54_TRKMTA_Inf.UPDKB = UPDKB_INS '���[�h�i�ǉ��j
					TOKMT54_TRKMTA_Inf.DATKB = gc_strDATKB_USE '�`�[�폜�敪
					TOKMT54_TRKMTA_Inf.TOKCD = FR_SSSMAIN.HD_TOKCD.Text '���Ӑ�R�[�h
					TOKMT54_TRKMTA_Inf.SKHINGRP = FR_SSSMAIN.BD_SKHINGRP(Wk_Row).Text '�d�ؗp���i�Q
					TOKMT54_TRKMTA_Inf.TRKRNK = FR_SSSMAIN.BD_TRKRNK(Wk_Row).Text '�����N
					TOKMT54_TRKMTA_Inf.STTKSTDT = Input_Value '�J�n�P���ݒ���t
				End If
			End If
		End If
		'�d���������������������������������������������������������d
		
		'''' ADD 2008/06/10  FKS) S.Nakajima    Start
		
		'�K�p���������ȍ~�݂̂Ƃ���
		Dim strDate As String
		If Retn_Code = CHK_OK Then
			strDate = Trim(GV_UNYDate)
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CDate(pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value) < CDate(Mid(strDate, 1, 4) & "/" & Mid(strDate, 5, 2) & "/" & Mid(strDate, 7, 2)) Then
				'�`�F�b�N�G���[�Ƃ���
				pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
				pm_Chk_Move = False
				Msg_Flg = True
				Err_Cd = gc_strMsgTOKMT54_E_026
				Retn_Code = CHK_ERR_ELSE
			End If
			
		End If
		
		'''' ADD 2008/06/10  FKS) S.Nakajima    End
		
		'''' ADD 2008/06/05  FKS) S.Nakajima    Start
		
		'�X�V�̏ꍇ�`�F�b�N
		If Retn_Code = CHK_OK Then
			
			Retn_Code = F_CHECK_STTKSTDT(pm_Chk_Dsp_Sub_Inf, pm_All)
			
			If Retn_Code <> CHK_OK Then
				pm_Chk_Move = False
				Msg_Flg = True
				Err_Cd = gc_strMsgTOKMT54_E_025
			Else
				pm_Chk_Move = True
			End If
			
		End If
		
		'''' ADD 2008/06/05  FKS) S.Nakajima    End
		'�ߒl�A���b�Z�[�W�A�X�e�[�^�X�A�ړ�����
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'�r���������������������������������������������������������r
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		'�d���������������������������������������������������������d
		
		F_Chk_BD_STTKSTDT = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_TRKRNK
	'   �T�v�F  �����N������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_TRKRNK(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf_T As TYPE_DB_TRKMTA
		Dim Mst_Inf_M As TYPE_DB_MEIMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		Dim Wk_Row As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_TRKRNK = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'��ʂ̍s
		Wk_Row = pm_Chk_Dsp_Sub_Inf.Detail.Body_Index
		
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
				Err_Cd = gc_strMsgTOKMT54_E_001
			Else
				'���̃}�X�^�`�F�b�N
				If DSPMEIM_SEARCH(pv_Trkrnk_Keycode, Input_Value, Mst_Inf_M) = 0 Then
					'�_���폜�`�F�b�N
					If Mst_Inf_M.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgTOKMT54_E_003
					Else
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						TOKMT54_TRKMTA_Inf.UPDKB = UPDKB_INS '���[�h�i�ǉ��j
						TOKMT54_TRKMTA_Inf.DATKB = gc_strDATKB_USE '�`�[�폜�敪
						TOKMT54_TRKMTA_Inf.TOKCD = FR_SSSMAIN.HD_TOKCD.Text '���Ӑ�R�[�h
						TOKMT54_TRKMTA_Inf.SKHINGRP = FR_SSSMAIN.BD_SKHINGRP(Wk_Row).Text '�d�ؗp���i�Q
						TOKMT54_TRKMTA_Inf.TRKRNK = Input_Value '�����N
						TOKMT54_TRKMTA_Inf.STTKSTDT = FR_SSSMAIN.BD_STTKSTDT(Wk_Row).Text '�J�n�P���ݒ���t
					End If
					'�Y���f�[�^����
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgTOKMT54_E_017
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
		
		F_Chk_BD_TRKRNK = Retn_Code
		
	End Function
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TRKMTA_SEARCH_ALL
	'   �T�v�F  ���ӕʏ��i�����N�}�X�^����
	'   �����F  pin_strSKHINGRP�@: �d�ؗp���i�Q
	'   �@�@�@�@pin_strSTTKSTDT  : �J�n�P���ݒ���t
	'   �@�@�@�@pot_DB_TRKMTA�@�@: ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TRKMTA_SEARCH_ALL(ByVal pin_strSKHINGRP As String, ByVal pin_strSTTKSTDT As String, ByRef pot_DB_TRKMTA As TYPE_DB_TRKMTA) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strTGRPCD As String
		
		On Error GoTo ERR_TRKMTA_SEARCH_ALL
		
		TRKMTA_SEARCH_ALL = 9
		
		Call DB_TRKMTA_Clear(pot_DB_TRKMTA)
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from TRKMTA "
		strSQL = strSQL & "  Where TOKCD     = '" & CF_Ora_String(pv_TOKMT54_TOKCD, 10) & "' "
		strSQL = strSQL & "    and SKHINGRP  = '" & CF_Ora_String(pin_strSKHINGRP, 4) & "' "
		strSQL = strSQL & "    and STTKSTDT  = '" & CF_Ora_Date(pin_strSTTKSTDT) & "' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'�擾�f�[�^�Ȃ�
			TRKMTA_SEARCH_ALL = 1
			GoTo END_TRKMTA_SEARCH_ALL
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			With pot_DB_TRKMTA
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "") '�d�ؗp���i�Q
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.TRKRNK = CF_Ora_GetDyn(Usr_Ody, "TRKRNK", "") '�����N
				'            .TRKOEM = CF_Ora_GetDyn(Usr_Ody, "TRKOEM", "")                  'OEM
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.STTKSTDT = CF_Ora_GetDyn(Usr_Ody, "STTKSTDT", "") '�J�n�P���ݒ���t
				'            .NBKRT = CF_Ora_GetDyn(Usr_Ody, "NBKRT", "")                    '�l����
				' === 20080909 === INSERT S - RISE)Izumi
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") '�N���C�A���g�h�c�i�o�b�`�j
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") '�^�C���X�^���v�i�o�b�`���ԁj
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") '�^�C���X�^���v�i�o�b�`���t�j
				' === 20080909 === INSERT E - RISE)Izumi
			End With
		End If
		
		TRKMTA_SEARCH_ALL = 0
		
END_TRKMTA_SEARCH_ALL: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_TRKMTA_SEARCH_ALL: 
		GoTo END_TRKMTA_SEARCH_ALL
		
	End Function
	' === 20060825 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_CM_SelectCm
	'   �T�v�F  �ꗗ�\���O����
	'   �����F  pm_All�@�@�@�@�@      :�S�\����
	'�@�@�@�@�@ pm_intErr             :�G���[��������
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_CM_SelectCm(ByRef pm_All As Cls_All) As Boolean
		
		Dim bolChk As Boolean
		
		'������
		bolChk = False
		
		'���͍��ڑS�Ă������͂��`�F�b�N
		If F_Chk_All_Input_Serch(pm_All) Then
			bolChk = True
		End If
		
		F_Chk_CM_SelectCm = bolChk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_All_Input_Serch
	'   �T�v�F  �����������S�Ė����͂�����
	'   �����F  pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_All_Input_Serch(ByRef pm_All As Cls_All) As Boolean
		
		Dim bolAll As Boolean
		Dim Err_Cd As String
		
		'������
		bolAll = False
		Err_Cd = ""
		
		'���������������͂Ȃ�G���[
		With FR_SSSMAIN
			
			If Trim(.HD_TOKCD.Text) = "" Then
				
				Err_Cd = gc_strMsgTOKMT54_E_014
				'���b�Z�[�W�o��
				Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
				bolAll = True
				
			End If
		End With
		
		F_Chk_All_Input_Serch = bolAll
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_CM_Execute
	'   �T�v�F  ���s�O����
	'   �����F  pm_All�@�@�@�@�@      :�S�\����
	'�@�@�@�@�@ pm_intErr             :�G���[��������
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_CM_Execute(ByRef pm_All As Cls_All) As Boolean
		
		Dim bolChk As Boolean
		
		'������
		bolChk = False
		
		'���׍s�ɓ��͂����邩�`�F�b�N
		If F_Chk_All_Input(pm_All) Then
			bolChk = True
		End If
		
		F_Chk_CM_Execute = bolChk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_All_Input
	'   �T�v�F  ���׍s�ɓ��͂����邩����
	'   �����F  pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_All_Input(ByRef pm_All As Cls_All) As Boolean
		
		Dim bolAll As Boolean
		Dim Err_Cd As String
		
		'������
		bolAll = False
		Err_Cd = ""
		
		'���׍s�ɓ��͂��Ȃ��Ȃ�G���[
		With FR_SSSMAIN
			If Trim(.BD_SKHINGRP(1).Text) = "" And Trim(.BD_STTKSTDT(1).Text) = "" And Trim(.BD_TRKRNK(1).Text) = "" And Trim(.BD_SKHINGRP(2).Text) = "" And Trim(.BD_STTKSTDT(2).Text) = "" And Trim(.BD_TRKRNK(2).Text) = "" And Trim(.BD_SKHINGRP(3).Text) = "" And Trim(.BD_STTKSTDT(3).Text) = "" And Trim(.BD_TRKRNK(3).Text) = "" And Trim(.BD_SKHINGRP(4).Text) = "" And Trim(.BD_STTKSTDT(4).Text) = "" And Trim(.BD_TRKRNK(4).Text) = "" And Trim(.BD_SKHINGRP(5).Text) = "" And Trim(.BD_STTKSTDT(5).Text) = "" And Trim(.BD_TRKRNK(5).Text) = "" And Trim(.BD_SKHINGRP(6).Text) = "" And Trim(.BD_STTKSTDT(6).Text) = "" And Trim(.BD_TRKRNK(6).Text) = "" And Trim(.BD_SKHINGRP(7).Text) = "" And Trim(.BD_STTKSTDT(7).Text) = "" And Trim(.BD_TRKRNK(7).Text) = "" And Trim(.BD_SKHINGRP(8).Text) = "" And Trim(.BD_STTKSTDT(8).Text) = "" And Trim(.BD_TRKRNK(8).Text) = "" And Trim(.BD_SKHINGRP(9).Text) = "" And Trim(.BD_STTKSTDT(9).Text) = "" And Trim(.BD_TRKRNK(9).Text) = "" And Trim(.BD_SKHINGRP(10).Text) = "" And Trim(.BD_STTKSTDT(10).Text) = "" And Trim(.BD_TRKRNK(10).Text) = "" And Trim(.BD_SKHINGRP(11).Text) = "" And Trim(.BD_STTKSTDT(11).Text) = "" And Trim(.BD_TRKRNK(11).Text) = "" And Trim(.BD_SKHINGRP(12).Text) = "" And Trim(.BD_STTKSTDT(12).Text) = "" And Trim(.BD_TRKRNK(12).Text) = "" And Trim(.BD_SKHINGRP(13).Text) = "" And Trim(.BD_STTKSTDT(13).Text) = "" And Trim(.BD_TRKRNK(13).Text) = "" And Trim(.BD_SKHINGRP(14).Text) = "" And Trim(.BD_STTKSTDT(14).Text) = "" And Trim(.BD_TRKRNK(14).Text) = "" And Trim(.BD_SKHINGRP(15).Text) = "" And Trim(.BD_STTKSTDT(15).Text) = "" And Trim(.BD_TRKRNK(15).Text) = "" Then
				
				Err_Cd = gc_strMsgTOKMT54_E_005
				'���b�Z�[�W�o��
				Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
				bolAll = True
				
			End If
		End With
		
		F_Chk_All_Input = bolAll
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
		
		gv_bolTOKMT54_INIT = True
		
	End Function
	' 2006/11/15  ADD END
	
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
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'�r���������������������������������������������������������r
			Case FR_SSSMAIN.HD_TOKCD.Name
				'���Ӑ�R�[�h�ɂ���ʕ\��
				Call F_Dsp_HD_TOKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pv_TOKMT54_TOKCD = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
				
			Case FR_SSSMAIN.BD_SKHINGRP(1).Name
				'�d�ؗp���i�Q(�R�[�h)�ɂ���ʕ\��
				Call F_Dsp_BD_SKHINGRP_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All, pm_Dsp_Sub_Inf.Detail.Body_Index)
				
			Case FR_SSSMAIN.BD_STTKSTDT(1).Name
				'�K�p���ɂ���ʕ\��
				Call F_Dsp_BD_STTKSTDT_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All, pm_Dsp_Sub_Inf.Detail.Body_Index)
				
			Case FR_SSSMAIN.BD_TRKRNK(1).Name
				'�����N�ɂ���ʕ\��
				Call F_Dsp_BD_TRKRNK_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All, pm_Dsp_Sub_Inf.Detail.Body_Index)
				
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
	'   ���́F  Function F_Dsp_HD_TOKCD_Inf
	'   �T�v�F  ���Ӑ�R�[�h�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TOKCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			'���Ӑ�R�[�h���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'��ʃ{�f�B��������
				Call F_Init_Clr_Dsp_Body(-1, pm_All)
				
				'�f�[�^�ҏW
				Call F_SET_BD_DATA(pm_All)
				
				'�y���Ӑ於�z
				Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(TOKMT54_TOKMTA_Inf.TOKRN, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			'��ʃ{�f�B��������
			Call F_Init_Clr_Dsp_Body(-1, pm_All)
			
			'�f�[�^�ҏW
			Call F_SET_BD_DATA(pm_All)
			
			'�y���Ӑ於�z
			Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_SKHINGRP_Inf
	'   �T�v�F  �d�ؗp���i�Q�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'           pm_Index            :�z��v�f�ԍ�
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_SKHINGRP_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All, ByRef pm_Index As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			'�d�ؗp���i�Q���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'�y���[�h�z
				Trg_Index = CShort(FR_SSSMAIN.BD_UPDKB(pm_Index).Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(TOKMT54_TRKMTA_Inf.UPDKB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�y�����N�z
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(pm_Index).Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(TOKMT54_TRKMTA_Inf.TRKRNK, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�t�H�[�J�X����
				Call F_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All, pm_Index)
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			If pm_Index = 0 Then
				'            '�y���[�h�z
				'            Trg_Index = CInt(FR_SSSMAIN.BD_UPDKB(pm_Index).Tag)
				'            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
				
				'�y�d�ؗp���i�Q�z
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(pm_Index).Tag)
				Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
				
				'�y�K�p���z
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(pm_Index).Tag)
				Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
				
				'�y�����N�z
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(pm_Index).Tag)
				Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			End If
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_STTKSTDT_Inf
	'   �T�v�F  �K�p���ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'           pm_Index            :�z��v�f�ԍ�
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_STTKSTDT_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All, ByRef pm_Index As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			'�K�p�����ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'�y���[�h�z
				Trg_Index = CShort(FR_SSSMAIN.BD_UPDKB(pm_Index).Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(TOKMT54_TRKMTA_Inf.UPDKB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�y�����N�z
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(pm_Index).Tag)
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(TOKMT54_TRKMTA_Inf.TRKRNK, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�t�H�[�J�X����
				Call F_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All, pm_Index)
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			If pm_Index = 0 Then
				'            '�y���[�h�z
				'            Trg_Index = CInt(FR_SSSMAIN.BD_UPDKB(pm_Index).Tag)
				'            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
				'
				'            '�y�d�ؗp���i�Q�z
				'            Trg_Index = CInt(FR_SSSMAIN.BD_SKHINGRP(pm_Index).Tag)
				'            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
				'
				'            '�y�K�p���z
				'            Trg_Index = CInt(FR_SSSMAIN.BD_STTKSTDT(pm_Index).Tag)
				'            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
				'
				'            '�y�����N�z
				'            Trg_Index = CInt(FR_SSSMAIN.BD_TRKRNK(pm_Index).Tag)
				'            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			End If
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_BD_TRKRNK_Inf
	'   �T�v�F  �����N�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'           pm_Index            :�z��v�f�ԍ�
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_TRKRNK_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All, ByRef pm_Index As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			'�d�ؗp���i�Q���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'�t�H�[�J�X����
				Call F_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All, pm_Index)
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Focus_Ctl
	'   �T�v�F  �d�ؗp���i�Q�A�K�p���ɂ���ʕ\����̃t�H�[�J�X����
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'           pm_Index            :�z��v�f�ԍ�
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Focus_Ctl(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Index As Short) As Short
		
		Dim Trg_Index As Short
		Dim Fcs_Flg As Boolean
		Dim Index_Cnt As Short
		
		If Trim(FR_SSSMAIN.BD_UPDKB(pm_Index).Text) <> "" Then
			'���[�h����łȂ��ꍇ
			Fcs_Flg = True
		Else
			'���[�h����̏ꍇ
			Fcs_Flg = False
		End If
		
		'�y���s�̃t�H�[�J�X����z
		'�J�����g���ŏI�s�łȂ��ꍇ
		If pm_Index < pm_All.Dsp_Base.Dsp_Body_Cnt Then
			'���s�̃��[�h����̏ꍇ
			If Trim(FR_SSSMAIN.BD_UPDKB(pm_Index + 1).Text) = "" Then
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(pm_Index + 1).Tag)
				For Index_Cnt = Trg_Index To Trg_Index + pm_All.Dsp_Base.Body_Col_Cnt - 2
					Call CF_Set_Item_Focus_Ctl(Fcs_Flg, pm_All.Dsp_Sub_Inf(Index_Cnt))
				Next 
			End If
		End If
		
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
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		'�@��{���͓��e�̃`�F�b�N
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'�r���������������������������������������������������������r
			Case FR_SSSMAIN.HD_TOKCD.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'���Ӑ�R�[�h������
				Rtn_Chk = F_Chk_HD_TOKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_SKHINGRP(1).Name
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'�d�ؗp���i�Q������
				Rtn_Chk = F_Chk_BD_SKHINGRP(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
				'            If pm_Process = CHK_FROM_KEYRETURN Then
				'                gv_bolTOKMT54_INIT = True
				'            End If
				
			Case FR_SSSMAIN.BD_STTKSTDT(1).Name
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'�K�p��������
				Rtn_Chk = F_Chk_BD_STTKSTDT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
				'            If pm_Process = CHK_FROM_KEYRETURN Then
				'                gv_bolTOKMT54_INIT = True
				'            End If
				
			Case FR_SSSMAIN.BD_TRKRNK(1).Name
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'�����N������
				Rtn_Chk = F_Chk_BD_TRKRNK(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
				'            If pm_Process = CHK_FROM_KEYRETURN Then
				'                gv_bolTOKMT54_INIT = True
				'            End If
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
			'�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
			pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
			'�t�b�^�����J������
			Call F_Foot_In_Ready(pm_All)
			'�`�F�b�N�n�j
			pm_All.Dsp_Base.Head_Ok_Flg = True
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_UPDKB
	'   �T�v�F  ���[�h�ύX����
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_UPDKB(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Trg_Index As Short
		Dim Mode_Now As String
		Dim Mode_Changed As String
		Dim Row_Index As Short
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'��ʏ�̍s�m�n���擾
		Row_Index = Bd_Index - (pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1))
		
		'���ݍs�̃��[�h���擾
		Mode_Now = FR_SSSMAIN.BD_UPDKB(Row_Index).Text
		
		If Trim(Mode_Now) <> "" Then
			Select Case Mode_Now
				Case UPDKB_UPD '�X�V��
					Mode_Changed = UPDKB_DEL
					
				Case UPDKB_DEL '�폜��
					Mode_Changed = UPDKB_UPD
					
				Case UPDKB_INS '�ǉ���
					Mode_Changed = UPDKB_INS
			End Select
			
			'�����ݒ�
			Trg_Index = CShort(FR_SSSMAIN.BD_UPDKB(Row_Index).Tag)
			Call CF_Set_Item_Direct(Mode_Changed, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
			
			' 2006/11/15  CHG START  KUMEDA
			'        gv_bolTOKMT54_INIT = True
			Call F_SET_UPDFLG(pm_Dsp_Sub_Inf, pm_All)
			' 2006/11/15  CHG END
		End If
		
	End Function
	' === 20060825 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_TOKCD
	'   �T�v�F  �Ώۍ��ڂ̓��Ӑ挟�����݂̐���
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_TOKCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		' === 20060702 === INSERT S
		Dim Next_Focus As Short
		' === 20060702 === INSERT E
		
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
		' === 20060702 === INSERT S
		Next_Focus = Trg_Index + 1
		' === 20060702 === INSERT E
		
		'̫����𓾈Ӑ�R�[�h�ֈړ�
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			' === 20060702 === INSERT S
			' 2006/11/28  ADD START  KUMEDA
			If FR_SSSMAIN.ActiveControl Is Nothing Then
				Exit Function
			End If
			' 2006/11/28  ADD END
			
			'���݂�Active�R���g���[���̑I����ԉ���
			'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			' === 20060702 === INSERT E
			'̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
			gv_bolTOKMT54_LF_Enable = False
			' === 20060801 === INSERT E - _Enable
			
			'======================= �ύX���� 2006.06.12 Start =================================
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			'======================= �ύX���� 2006.06.12 End =================================
			
			'���Ӑ挟����ʂ��Ăяo��
			' === 20060824 === INSERT S �����Ή�
			WLSTOK_SKCHKB = gc_strSKCHKB_NML
			' === 20060824 === INSERT E
			WLSTOK.ShowDialog()
			' === 20060725 === INSERT S -
			WLSTOK.Close()
			' === 20060725 === INSERT E -
			
			' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
			gv_bolTOKMT54_LF_Enable = True
			' === 20060801 === INSERT E - _Enable
			
			If WLSTOK_RTNCODE <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(WLSTOK_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'�`�F�b�N
				'�e���ڂ�����ٰ��
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
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
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				' === 20060702 === INSERT S -
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					' === 20060801 === UPDATE S - �����{�^�����������悤�Ɍ�����悤�ɑΉ�
					'                '������ړ��Ȃ�
					'                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
					'                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
					'                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
					
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
					' === 20060801 === UPDATE E -
				End If
				' === 20060702 === INSERT E
			End If
			' === 20060801 === INSERT S - �����{�^�����������悤�Ɍ�����悤�ɑΉ�
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
			' === 20060801 === INSERT E -
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_SKHINGRP
	'   �T�v�F  �Ώۍ��ڂ̎d�ؗp���i�Q���݂̐���
	'   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
	'           pm_All              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SKHINGRP(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		' === 20060702 === INSERT S
		Dim Next_Focus As Short
		' === 20060702 === INSERT E
		Dim Bd_Index As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(Current_Skhingrp_Index).Tag)
		' === 20060702 === INSERT S
		Next_Focus = Trg_Index
		' === 20060702 === INSERT E
		
		'̫������d�ؗp���i�Q�ֈړ�
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			' === 20060702 === INSERT S
			' 2006/11/28  ADD START  KUMEDA
			If FR_SSSMAIN.ActiveControl Is Nothing Then
				Exit Function
			End If
			' 2006/11/28  ADD END
			
			'���݂�Active�R���g���[���̑I����ԉ���
			'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			' === 20060702 === INSERT E
			'̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
			gv_bolTOKMT54_LF_Enable = False
			' === 20060801 === INSERT E - _Enable
			
			'======================= �ύX���� 2006.06.12 Start =================================
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			'======================= �ύX���� 2006.06.12 End =================================
			
			'���̌�����ʂ��Ăяo��
			' === 20060825 === INSERT S
			WLSMEI_KEYCD = pv_Skhingrp_Keycode
			' === 20060825 === INSERT E
			WLS_MEI.ShowDialog()
			' === 20060725 === INSERT S
			WLS_MEI.Close()
			' === 20060725 === INSERT E -
			
			' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
			gv_bolTOKMT54_LF_Enable = True
			' === 20060801 === INSERT E - _Enable
			
			If WLSMEI_RTNMEICDA <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(WLSMEI_RTNMEICDA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				' 2006/11/15  ADD START  KUMEDA
				Call F_SET_UPDFLG(pm_Dsp_Sub_Inf, pm_All)
				' 2006/11/15  ADD END
				
				'�`�F�b�N
				'�e���ڂ�����ٰ��
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
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
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				' === 20060825 === INSERT S
				Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'�ҏW�����s�̏�Ԃ���͍ς݂ɐݒ�
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_INPUT
				'���s�̉�ʃ{�f�B�s��Ԃ��ŏI�����s�ɐݒ�
				Call F_Set_NextRow_Status(pm_Dsp_Sub_Inf, pm_All)
				' === 20060825 === INSERT E
				
				' === 20060702 === INSERT S -
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					' === 20060801 === UPDATE S - �����{�^�����������悤�Ɍ�����悤�ɑΉ�
					'                '������ړ��Ȃ�
					'                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
					'                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
					'                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
					
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
					' === 20060801 === UPDATE E -
				End If
				' === 20060702 === INSERT E
			End If
			' === 20060801 === INSERT S - �����{�^�����������悤�Ɍ�����悤�ɑΉ�
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
			' === 20060801 === INSERT E -
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_STTKSTDT
	'   �T�v�F  �Ώۍ��ڂ̓K�p���������݂̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_STTKSTDT(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		' === 20060702 === INSERT S
		Dim Next_Focus As Short
		' === 20060702 === INSERT E
		Dim Bd_Index As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(Current_Skhingrp_Index).Tag)
		' === 20060702 === INSERT S
		Next_Focus = Trg_Index
		' === 20060702 === INSERT E
		
		'̫�����K�p���ֈړ�
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			' === 20060702 === INSERT S
			' 2006/11/28  ADD START  KUMEDA
			If FR_SSSMAIN.ActiveControl Is Nothing Then
				Exit Function
			End If
			' 2006/11/28  ADD END
			
			'���݂�Active�R���g���[���̑I����ԉ���
			'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			' === 20060702 === INSERT E
			'̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
			gv_bolTOKMT54_LF_Enable = False
			' === 20060801 === INSERT E - _Enable
			
			' === 20060901 === INSERT S - �J�����_�̏����\���̏C��
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Set_date.Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(Trg_Index)))
			' === 20060901 === INSERT E -
			
			'======================= �ύX���� 2006.06.12 Start =================================
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			'======================= �ύX���� 2006.06.12 End =================================
			
			'�J�����_�[��ʂ��Ăяo��
			WLS_DATE.ShowDialog()
			' === 20060725 === INSERT S
			WLS_DATE.Close()
			' === 20060725 === INSERT E -
			
			' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
			gv_bolTOKMT54_LF_Enable = True
			' === 20060801 === INSERT E - _Enable
			
			If WLSDATE_RTNCODE <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(WLSDATE_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				' 2006/11/15  ADD START  KUMEDA
				Call F_SET_UPDFLG(pm_Dsp_Sub_Inf, pm_All)
				' 2006/11/15  ADD END
				
				'�`�F�b�N
				'�e���ڂ�����ٰ��
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
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
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				' === 20060825 === INSERT S
				Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'�ҏW�����s�̏�Ԃ���͍ς݂ɐݒ�
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_INPUT
				'���s�̉�ʃ{�f�B�s��Ԃ��ŏI�����s�ɐݒ�
				Call F_Set_NextRow_Status(pm_Dsp_Sub_Inf, pm_All)
				' === 20060825 === INSERT E
				
				' === 20060702 === INSERT S -
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					' === 20060801 === UPDATE S - �����{�^�����������悤�Ɍ�����悤�ɑΉ�
					'                '������ړ��Ȃ�
					'                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
					'                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
					'                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
					
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
					' === 20060801 === UPDATE E -
				End If
				' === 20060702 === INSERT E
			End If
			' === 20060801 === INSERT S - �����{�^�����������悤�Ɍ�����悤�ɑΉ�
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
			' === 20060801 === INSERT E -
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_TRKRNK
	'   �T�v�F  �Ώۍ��ڂ̃����N���݂̐���
	'   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
	'           pm_All              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_TRKRNK(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		' === 20060702 === INSERT S
		Dim Next_Focus As Short
		' === 20060702 === INSERT E
		Dim Bd_Index As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(Current_Skhingrp_Index).Tag)
		' === 20060702 === INSERT S
		Next_Focus = Trg_Index + 1
		' === 20060702 === INSERT E
		
		'̫����������N�ֈړ�
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			' === 20060702 === INSERT S
			' 2006/11/28  ADD START  KUMEDA
			If FR_SSSMAIN.ActiveControl Is Nothing Then
				Exit Function
			End If
			' 2006/11/28  ADD END
			
			'���݂�Active�R���g���[���̑I����ԉ���
			'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			' === 20060702 === INSERT E
			'̫����ړ�
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'�I����Ԃ̐ݒ�i�����I���j
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
			gv_bolTOKMT54_LF_Enable = False
			' === 20060801 === INSERT E - _Enable
			
			'======================= �ύX���� 2006.06.12 Start =================================
			'Windows�ɏ�����Ԃ�
			System.Windows.Forms.Application.DoEvents()
			'======================= �ύX���� 2006.06.12 End =================================
			
			'���̌�����ʂ��Ăяo��
			' === 20060825 === INSERT S
			WLSMEI_KEYCD = pv_Trkrnk_Keycode
			' === 20060825 === INSERT E
			WLS_MEI.ShowDialog()
			' === 20060725 === INSERT S
			WLS_MEI.Close()
			' === 20060725 === INSERT E -
			
			' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
			gv_bolTOKMT54_LF_Enable = True
			' === 20060801 === INSERT E - _Enable
			
			If WLSMEI_RTNMEICDA <> "" Then
				'�����n�j
				'��ʂɕҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Dsp_Value = CF_Cnv_Dsp_Item(WLSMEI_RTNMEICDA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				' 2006/11/15  ADD START  KUMEDA
				Call F_SET_UPDFLG(pm_Dsp_Sub_Inf, pm_All)
				' 2006/11/15  ADD END
				
				'�`�F�b�N
				'�e���ڂ�����ٰ��
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
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
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				' === 20060825 === INSERT S
				Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'�ҏW�����s�̏�Ԃ���͍ς݂ɐݒ�
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_INPUT
				'���s�̉�ʃ{�f�B�s��Ԃ��ŏI�����s�ɐݒ�
				Call F_Set_NextRow_Status(pm_Dsp_Sub_Inf, pm_All)
				' === 20060825 === INSERT E
				
				' === 20060702 === INSERT S -
				If Chk_Move_Flg = True Then
					'������ړ�����
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					' === 20060801 === UPDATE S - �����{�^�����������悤�Ɍ�����悤�ɑΉ�
					'                '������ړ��Ȃ�
					'                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
					'                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
					'                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
					
					'̫����ړ�
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'���ڐF�ݒ�
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
					' === 20060801 === UPDATE E -
				End If
				' === 20060702 === INSERT E
			End If
			' === 20060801 === INSERT S - �����{�^�����������悤�Ɍ�����悤�ɑΉ�
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
			' === 20060801 === INSERT E -
		End If
		
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
			
			Case CShort(FR_SSSMAIN.HD_TOKCD.Tag)
				'���Ӑ�
				'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CS_TOKCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Trg_Index = CShort(FR_SSSMAIN.CS_TOKCD.Tag)
				Call F_Ctl_CS_TOKCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(1).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(1).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(2).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(2).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(3).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(3).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(4).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(4).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(5).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(5).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(6).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(6).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(7).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(7).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(8).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(8).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(9).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(9).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(10).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(10).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(11).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(11).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(12).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(12).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(13).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(13).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(14).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(14).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_SKHINGRP(15).Tag)
				'�d�ؗp���i�Q
				Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(15).Tag)
				Call F_Ctl_CS_SKHINGRP(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(1).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(1).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(2).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(2).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(3).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(3).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(4).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(4).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(5).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(5).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(6).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(6).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(7).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(7).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(8).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(8).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(9).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(9).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(10).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(10).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(11).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(11).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(12).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(12).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(13).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(13).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(14).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(14).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_STTKSTDT(15).Tag)
				'�K�p��
				Trg_Index = CShort(FR_SSSMAIN.BD_STTKSTDT(15).Tag)
				Call F_Ctl_CS_STTKSTDT(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(1).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(1).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(2).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(2).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(3).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(3).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(4).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(4).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(5).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(5).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(6).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(6).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(7).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(7).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(8).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(8).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(9).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(9).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(10).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(10).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(11).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(11).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(12).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(12).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(13).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(13).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(14).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(14).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
			Case CShort(FR_SSSMAIN.BD_TRKRNK(15).Tag)
				'�����N
				Trg_Index = CShort(FR_SSSMAIN.BD_TRKRNK(15).Tag)
				Call F_Ctl_CS_TRKRNK(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
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
		
		'���Ӑ�
		WLSTOK.Close()
		'UPGRADE_NOTE: �I�u�W�F�N�g WLSTOK ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		WLSTOK = Nothing
		
		'�d�ؗp���i�Q�A�����N
		WLS_MEI.Close()
		'UPGRADE_NOTE: �I�u�W�F�N�g WLS_MEI ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		WLS_MEI = Nothing
		
		'�K�p��
		WLS_DATE.Close()
		'UPGRADE_NOTE: �I�u�W�F�N�g WLS_DATE ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		WLS_DATE = Nothing
		
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
		
		F_Ctl_Upd_Process = 9
		
		' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		' === 20060808 === INSERT E
		
		' 2007/01/11  DLT START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
		'    '�o�^�����������ꍇ
		'    If pv_InpTan_TOK = False Then
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
		intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_A_008, pm_All)
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		Dim bolTrn As Boolean
		Dim strSQL As String
		Dim Chk_Start As Short
		Dim Chk_End As Short
		Dim intLoop As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Select Case intRet
			Case MsgBoxResult.Yes
				' 2007/01/11  ADD START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
				If pv_InpTan_TOK = False Then
					gv_bolUpdFlg = False
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_024, pm_All)
					GoTo End_F_Ctl_Upd_Process
				End If
				' 2007/01/11  ADD END
				'�{�^����\��
				FR_SSSMAIN.CM_Execute.Visible = False
				
				' === 20080909 === INSERT S - RISE)Izumi
				
				'�g�����U�N�V�����̊J�n
				Call CF_Ora_BeginTrans(gv_Oss_USR1)
				bolTrn = True
				
				
				'���[�v�J�n�A�I���̌v�Z
				Chk_Start = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1
				Chk_End = pm_All.Dsp_Base.Dsp_Body_Cnt * NowPageNum
				
				'���ו��^�C���X�^���v�̃`�F�b�N���s��
				For intLoop = Chk_Start To Chk_End
					With pm_All.Dsp_Body_Inf.Row_Inf(intLoop)
						If .Status = BODY_ROW_STATE_INPUT Then
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intLoop).Item_Detail(pc_COL_UPDATE).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If .Item_Detail(pc_COL_UPDATE).Dsp_Value = "1" Then
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intLoop).Item_Detail(pc_COL_UPDKB).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If .Item_Detail(pc_COL_UPDKB).Dsp_Value <> UPDKB_INS Then
									strSQL = ""
									strSQL = strSQL & " SELECT"
									strSQL = strSQL & "  OPEID"
									strSQL = strSQL & ", CLTID"
									strSQL = strSQL & ", WRTTM"
									strSQL = strSQL & ", WRTDT"
									strSQL = strSQL & ", UOPEID"
									strSQL = strSQL & ", UCLTID"
									strSQL = strSQL & ", UWRTTM"
									strSQL = strSQL & ", UWRTDT"
									strSQL = strSQL & " FROM"
									strSQL = strSQL & "  TRKMTA"
									strSQL = strSQL & " WHERE"
									' === 20080926 === UPDATE S - RISE)Izumi
									'                                strSQL = strSQL & "  SKHINGRP = '" & M_TRKMTA_MOTO_A_inf(intLoop).SKHINGRP & "'"
									'                                strSQL = strSQL & " AND"
									'                                strSQL = strSQL & "  TOKCD = '" & M_TRKMTA_MOTO_A_inf(intLoop).TOKCD & "'"
									'                                strSQL = strSQL & " AND"
									'                                strSQL = strSQL & "  STTKSTDT = '" & M_TRKMTA_MOTO_A_inf(intLoop).STTKSTDT & "'"
									strSQL = strSQL & "  SKHINGRP = '" & .Bus_Inf.SKHINGRP & "'"
									strSQL = strSQL & " AND"
									strSQL = strSQL & "  TOKCD = '" & .Bus_Inf.TOKCD & "'"
									strSQL = strSQL & " AND"
									strSQL = strSQL & "  STTKSTDT = '" & .Bus_Inf.STTKSTDT & "'"
									' === 20080926 === UPDATE E - RISE)Izumi
									strSQL = strSQL & " FOR UPDATE"
									
									'DB�A�N�Z�X
									Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
									
									If CF_Ora_EOF(Usr_Ody) = True Then
										'���[���o�b�N
										Call CF_Ora_RollbackTrans(gv_Oss_USR1)
										bolTrn = False
										gv_bolUpdFlg = False
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intLoop).Item_Detail(pc_COL_UPDKB).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If .Item_Detail(pc_COL_UPDKB).Dsp_Value = UPDKB_UPD Then
											Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_901, pm_All)
										Else
											Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_902, pm_All)
										End If
										GoTo End_F_Ctl_Upd_Process
									Else
										' === 20080926 === UPDATE S - RISE)Izumi
										'                                    If Trim$(M_TRKMTA_MOTO_A_inf(intLoop).OPEID) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "OPEID", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).CLTID) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).WRTTM) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).WRTDT) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).UOPEID) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).UCLTID) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).UWRTTM) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).UWRTDT) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")) Then
										'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If Trim(.Bus_Inf.OPEID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "OPEID", "")) Or Trim(.Bus_Inf.CLTID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) Or Trim(.Bus_Inf.WRTTM) <> Trim(CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")) Or Trim(.Bus_Inf.WRTDT) <> Trim(CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")) Or Trim(.Bus_Inf.UOPEID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")) Or Trim(.Bus_Inf.UCLTID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")) Or Trim(.Bus_Inf.UWRTTM) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")) Or Trim(.Bus_Inf.UWRTDT) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")) Then
											' === 20080926 === UPDATE E - RISE)Izumi
											'���[���o�b�N
											Call CF_Ora_RollbackTrans(gv_Oss_USR1)
											bolTrn = False
											gv_bolUpdFlg = False
											'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intLoop).Item_Detail(pc_COL_UPDKB).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
											If .Item_Detail(pc_COL_UPDKB).Dsp_Value = UPDKB_UPD Then
												Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_901, pm_All)
											Else
												Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_902, pm_All)
											End If
											GoTo End_F_Ctl_Upd_Process
										End If
									End If
								End If
							End If
						End If
					End With
				Next intLoop
				' === 20080909 === INSERT E - RISE)Izumi
				
				'�o�^����
				intRet = F_Update_Main(pm_All)
				If intRet <> 0 Then
					GoTo Err_F_Ctl_Upd_Process
				End If
				
				' === 20080909 === INSERT S - RISE)Izumi
				'�R�~�b�g
				Call CF_Ora_CommitTrans(gv_Oss_USR1)
				bolTrn = False
				' === 20080909 === INSERT E - RISE)Izumi
				
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
		intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_009, pm_All)
		
		F_Ctl_Upd_Process = 0
		
End_F_Ctl_Upd_Process: 
		
		' === 20080909 === INSERT S - RISE)Izumi
		If bolTrn = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
			bolTrn = False
		End If
		' === 20080909 === INSERT E - RISE)Izumi
		
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
		
		F_Ctl_Upd_Process2 = 9
		
		' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		' === 20060808 === INSERT E
		
		' 2007/01/11  DLT START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
		'    '�o�^�����������ꍇ
		'    If pv_InpTan_TOK = False Then
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
		
		If gv_bolTOKMT54_INIT = True Then
			'�m�F���b�Z�[�W�\��
			intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_A_018, pm_All)
		End If
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		Dim bolTrn As Boolean
		Dim strSQL As String
		Dim Chk_Start As Short
		Dim Chk_End As Short
		Dim intLoop As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Select Case intRet
			Case MsgBoxResult.Yes
				' 2007/01/11  ADD START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
				If pv_InpTan_TOK = False Then
					gv_bolUpdFlg = False
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_024, pm_All)
					GoTo End_F_Ctl_Upd_Process2
				End If
				' 2007/01/11  ADD END
				'�{�^����\��
				FR_SSSMAIN.CM_Execute.Visible = False
				
				' === 20080909 === INSERT S - RISE)Izumi
				
				'�g�����U�N�V�����̊J�n
				Call CF_Ora_BeginTrans(gv_Oss_USR1)
				bolTrn = True
				
				
				'���[�v�J�n�A�I���̌v�Z
				Chk_Start = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1
				Chk_End = pm_All.Dsp_Base.Dsp_Body_Cnt * NowPageNum
				
				'���ו��^�C���X�^���v�̃`�F�b�N���s��
				For intLoop = Chk_Start To Chk_End
					With pm_All.Dsp_Body_Inf.Row_Inf(intLoop)
						If .Status = BODY_ROW_STATE_INPUT Then
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intLoop).Item_Detail(pc_COL_UPDATE).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If .Item_Detail(pc_COL_UPDATE).Dsp_Value = "1" Then
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intLoop).Item_Detail(pc_COL_UPDKB).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If .Item_Detail(pc_COL_UPDKB).Dsp_Value <> UPDKB_INS Then
									strSQL = ""
									strSQL = strSQL & " SELECT"
									strSQL = strSQL & "  OPEID"
									strSQL = strSQL & ", CLTID"
									strSQL = strSQL & ", WRTTM"
									strSQL = strSQL & ", WRTDT"
									strSQL = strSQL & ", UOPEID"
									strSQL = strSQL & ", UCLTID"
									strSQL = strSQL & ", UWRTTM"
									strSQL = strSQL & ", UWRTDT"
									strSQL = strSQL & " FROM"
									strSQL = strSQL & "  TRKMTA"
									strSQL = strSQL & " WHERE"
									' === 20080926 === UPDATE S - RISE)Izumi
									'                                strSQL = strSQL & "  SKHINGRP = '" & M_TRKMTA_MOTO_A_inf(intLoop).SKHINGRP & "'"
									'                                strSQL = strSQL & " AND"
									'                                strSQL = strSQL & "  TOKCD = '" & M_TRKMTA_MOTO_A_inf(intLoop).TOKCD & "'"
									'                                strSQL = strSQL & " AND"
									'                                strSQL = strSQL & "  STTKSTDT = '" & M_TRKMTA_MOTO_A_inf(intLoop).STTKSTDT & "'"
									strSQL = strSQL & "  SKHINGRP = '" & .Bus_Inf.SKHINGRP & "'"
									strSQL = strSQL & " AND"
									strSQL = strSQL & "  TOKCD = '" & .Bus_Inf.TOKCD & "'"
									strSQL = strSQL & " AND"
									strSQL = strSQL & "  STTKSTDT = '" & .Bus_Inf.STTKSTDT & "'"
									' === 20080926 === UPDATE E - RISE)Izumi
									strSQL = strSQL & " FOR UPDATE"
									
									'DB�A�N�Z�X
									Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
									
									If CF_Ora_EOF(Usr_Ody) = True Then
										'���[���o�b�N
										Call CF_Ora_RollbackTrans(gv_Oss_USR1)
										bolTrn = False
										gv_bolUpdFlg = False
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intLoop).Item_Detail(pc_COL_UPDKB).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If .Item_Detail(pc_COL_UPDKB).Dsp_Value = UPDKB_UPD Then
											Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_901, pm_All)
										Else
											Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_902, pm_All)
										End If
										GoTo End_F_Ctl_Upd_Process2
									Else
										' === 20080926 === UPDATE S - RISE)Izumi
										'                                    If Trim$(M_TRKMTA_MOTO_A_inf(intLoop).OPEID) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "OPEID", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).CLTID) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).WRTTM) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).WRTDT) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).UOPEID) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).UCLTID) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).UWRTTM) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")) Or _
										''                                       Trim$(M_TRKMTA_MOTO_A_inf(intLoop).UWRTDT) <> Trim$(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")) Then
										'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If Trim(.Bus_Inf.OPEID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "OPEID", "")) Or Trim(.Bus_Inf.CLTID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) Or Trim(.Bus_Inf.WRTTM) <> Trim(CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")) Or Trim(.Bus_Inf.WRTDT) <> Trim(CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")) Or Trim(.Bus_Inf.UOPEID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")) Or Trim(.Bus_Inf.UCLTID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")) Or Trim(.Bus_Inf.UWRTTM) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")) Or Trim(.Bus_Inf.UWRTDT) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")) Then
											' === 20080926 === UPDATE E - RISE)Izumi
											'���[���o�b�N
											Call CF_Ora_RollbackTrans(gv_Oss_USR1)
											bolTrn = False
											gv_bolUpdFlg = False
											'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intLoop).Item_Detail(pc_COL_UPDKB).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
											If .Item_Detail(pc_COL_UPDKB).Dsp_Value = UPDKB_UPD Then
												Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_901, pm_All)
											Else
												Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_902, pm_All)
											End If
											GoTo End_F_Ctl_Upd_Process2
										End If
									End If
								End If
							End If
						End If
					End With
				Next intLoop
				' === 20080909 === INSERT E - RISE)Izumi
				
				'�o�^����
				intRet = F_Update_Main(pm_All)
				If intRet <> 0 Then
					GoTo Err_F_Ctl_Upd_Process2
				End If
				
				' === 20080909 === INSERT S - RISE)Izumi
				'�R�~�b�g
				Call CF_Ora_CommitTrans(gv_Oss_USR1)
				bolTrn = False
				' === 20080909 === INSERT E - RISE)Izumi
				
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
				intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_009, pm_All)
				
			Case MsgBoxResult.No
				'�o�^�����ɏ����p��
				gv_bolTOKMT54_INIT = False
				
			Case MsgBoxResult.Cancel
				'�������~
				GoTo End_F_Ctl_Upd_Process2
				
			Case Else
				'���b�Z�[�W�\���Ȃ�
				
		End Select
		
		F_Ctl_Upd_Process2 = 0
		
End_F_Ctl_Upd_Process2: 
		
		' === 20080909 === INSERT S - RISE)Izumi
		If bolTrn = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
			bolTrn = False
		End If
		' === 20080909 === INSERT E - RISE)Izumi
		
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
		
		Dim Upd_Start As Short
		Dim Upd_End As Short
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_OK
		
		pv_bolMEISAI_INPUT = False
		pv_intMeisaiCnt = 0
		pv_bolInput_Bef_Row = True
		
		'���[�v�J�n�A�I���̌v�Z
		Upd_Start = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1
		Upd_End = pm_All.Dsp_Base.Dsp_Body_Cnt * NowPageNum
		
		'�[���s�ڏ��ޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g Row_inf_Zero �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Row_inf_Zero = pm_All.Dsp_Body_Inf.Row_Inf(0)
		
		'�{�f�B���̍ŏI���ڂ܂Ŋe���ڂ��������s��
		'For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		For Index_Wk_Row = Upd_Start To Upd_End
			
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
						
						' === 20060825 === UPDATE S
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(pc_COL_UPDKB).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(pc_COL_UPDKB).Dsp_Value <> UPDKB_DEL Then
							'�e����������S�������Ƃ��Čďo
							Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
						Else
							Rtn_Chk = CHK_OK
						End If
						' === 20060825 === UPDATE E
						
						'''' ADD 2008/06/06  FKS) S.Nakajima    Start
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(pc_COL_UPDKB).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(pc_COL_UPDKB).Dsp_Value = UPDKB_DEL Then
							Select Case Dsp_Sub_Inf_Wk.Ctl.Name
								Case FR_SSSMAIN.BD_STTKSTDT(1).Name
									Call CF_Set_Chk_From_Process(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, pm_All)
									'�K�p��������
									Rtn_Chk = F_Chk_BD_STTKSTDT(Dsp_Sub_Inf_Wk, Chk_Move_Flg, pm_All)
							End Select
						End If
						'''' ADD 2008/06/06  FKS) S.Nakajima    End
						
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
		'    '�Ώۍs����ʂɕ\��
		'    Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
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
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index), SEL_INI_MODE_2)
			'���ڐF�ݒ�
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index), ITEM_SELECT_STATUS, pm_All)
			
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
		Dim intSKHINGRP As Short
		Dim intSTTKSTDT As Short
		Dim intTRKRNK As Short
		Dim bolCheck As Boolean
		Dim bolNotInput As Boolean
		Dim strKbn As String
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrRow = pm_intRow
		pm_ErrIdx = CShort(FR_SSSMAIN.BD_SKHINGRP(1).Tag)
		bolNotInput = False
		
		'�P�s�`�F�b�N
		intUPDKB = CShort(FR_SSSMAIN.BD_UPDKB(0).Tag)
		intSKHINGRP = CShort(FR_SSSMAIN.BD_SKHINGRP(0).Tag)
		intSTTKSTDT = CShort(FR_SSSMAIN.BD_STTKSTDT(0).Tag)
		intTRKRNK = CShort(FR_SSSMAIN.BD_TRKRNK(0).Tag)
		
		bolCheck = False
		'�P�s�ɕK�v�ȏ�񂪓��͂���Ă���ꍇ�AOK
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSKHINGRP))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSTTKSTDT))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTRKRNK))) <> "" Then
			bolCheck = True
			pv_bolMEISAI_INPUT = True
			pv_intMeisaiCnt = pv_intMeisaiCnt + 1
			
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case True
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSKHINGRP))) <> ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_SKHINGRP(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSTTKSTDT))) <> ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_STTKSTDT(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTRKRNK))) <> ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TRKRNK(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSKHINGRP))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_SKHINGRP(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSTTKSTDT))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_STTKSTDT(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTRKRNK))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TRKRNK(1).Tag)
			End Select
		End If
		
		'�P�s�S�������͂̏ꍇOK
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If bolCheck = False And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSKHINGRP))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSTTKSTDT))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTRKRNK))) = "" Then
			
			'���u���͍ςݏ�ԁv"�łȂ�"�ꍇ
			If pm_All.Dsp_Body_Inf.Row_Inf(pm_intRow).Status <> BODY_ROW_STATE_INPUT Then
				bolCheck = True
				bolNotInput = True
			End If
		End If
		
		If bolCheck = False Then
			Err_Cd = gc_strMsgTOKMT54_E_010
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
				Err_Cd = gc_strMsgTOKMT54_E_010
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
		Dim Mst_Inf_T As TYPE_DB_TRKMTA
		Dim Clr_TOKMT54_TRKMTA As TYPE_DB_TRKMTA
		
		'''' ADD 2008/06/05  FKS) S.Nakajima    Start
		Dim intCheckRet As Short
		'''' ADD 2008/06/05  FKS) S.Nakajima    End
		
		On Error GoTo F_Update_Main_Err
		
		intRet = CHK_OK
		bolTrn = False
		
		'�X�V�����擾
		Call CF_Get_SysDt()
		
		'���[�v�J�n�A�I���̌v�Z
		Upd_Start = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1
		Upd_End = pm_All.Dsp_Base.Dsp_Body_Cnt * NowPageNum
		
		' === 20080909 === DELETE S - RISE)Izumi
		'    '�g�����U�N�V�����̊J�n
		'    Call CF_Ora_BeginTrans(gv_Oss_USR1)
		'    bolTrn = True
		' === 20080909 === DELETE E - RISE)Izumi
		
		For intCnt = Upd_Start To Upd_End
			With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				If .Status = BODY_ROW_STATE_INPUT Then
					' 2006/11/15  ADD START  KUMEDA
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(pc_COL_UPDATE).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If .Item_Detail(pc_COL_UPDATE).Dsp_Value = "1" Then
						' 2006/11/15  ADD END
						'���[�h�ʏ���
						Select Case .Item_Detail(pc_COL_UPDKB).Dsp_Value
							Case UPDKB_INS
								'���[�h���ǉ��̏ꍇ
								'���Ӑ�ʏ��i�����N�}�X�^�\���̂̃N���A
								'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf_T �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Mst_Inf_T = Clr_TOKMT54_TRKMTA
								
								'''' UPD 2008/06/05  FKS) S.Nakajima    Start
								
								'�}�X�^�`�F�b�N
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(pc_COL_TRKRNK).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(pc_COL_STTKSTDT).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								intCheckRet = TRKMTA_SEARCH_Check(.Item_Detail(pc_COL_SKHINGRP).Dsp_Value, .Item_Detail(pc_COL_STTKSTDT).Dsp_Value, .Item_Detail(pc_COL_TRKRNK).Dsp_Value, Mst_Inf_T)
								
								If intCheckRet = 2 Then
									'�}�X�^�`�F�b�N�G���[
									'���꓾�Ӑ�ɑ΂��A�����̃����N�͓o�^�ł��܂���B
									Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_025, pm_All)
									intRet = intCheckRet
									GoTo F_Update_Main_Err
								Else
									'�}�X�^�`�F�b�N
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(pc_COL_STTKSTDT).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If TRKMTA_SEARCH_ALL(.Item_Detail(pc_COL_SKHINGRP).Dsp_Value, .Item_Detail(pc_COL_STTKSTDT).Dsp_Value, Mst_Inf_T) = 0 Then
										'�Y���f�[�^�L��
										'���Ӑ�ʏ��i�����N�}�X�^�X�V
										intRet = F_TRKMTA_Update(intCnt, pm_All)
									Else
										'�Y���f�[�^����
										'���Ӑ�ʏ��i�����N�}�X�^�ǉ�
										intRet = F_TRKMTA_Insert(intCnt, pm_All)
									End If
									
								End If
								
								'                            '�}�X�^�`�F�b�N
								'                            If TRKMTA_SEARCH_ALL(.Item_Detail(pc_COL_SKHINGRP).Dsp_Value, _
								''                                                 .Item_Detail(pc_COL_STTKSTDT).Dsp_Value, _
								''                                                 Mst_Inf_T) = 0 Then
								'                                '�Y���f�[�^�L��
								'                                '���Ӑ�ʏ��i�����N�}�X�^�X�V
								'                                intRet = F_TRKMTA_Update(intCnt, pm_All)
								'                            Else
								'                                '�Y���f�[�^����
								'                                '���Ӑ�ʏ��i�����N�}�X�^�ǉ�
								'                                intRet = F_TRKMTA_Insert(intCnt, pm_All)
								'                            End If
								
								'''' UPD 2008/06/05  FKS) S.Nakajima    End
								
							Case UPDKB_UPD
								'���[�h���X�V�̏ꍇ
								'���Ӑ�ʏ��i�����N�}�X�^�X�V
								intRet = F_TRKMTA_Update(intCnt, pm_All)
								
							Case UPDKB_DEL
								'���[�h���폜�̏ꍇ
								'���Ӑ�ʎ戵���i�}�X�^�\���̂̃N���A
								'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf_T �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								Mst_Inf_T = Clr_TOKMT54_TRKMTA
								
								'�}�X�^�`�F�b�N
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(pc_COL_STTKSTDT).Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If TRKMTA_SEARCH_ALL(.Item_Detail(pc_COL_SKHINGRP).Dsp_Value, .Item_Detail(pc_COL_STTKSTDT).Dsp_Value, Mst_Inf_T) = 0 Then
									'�Y���f�[�^�L��
									If Mst_Inf_T.DATKB = gc_strDATKB_USE Then
										'�g�p���f�[�^
										'���Ӑ�ʏ��i�����N�}�X�^�X�V
										intRet = F_TRKMTA_Update(intCnt, pm_All)
									End If
								End If
								
						End Select
						
						If intRet <> 0 Then
							GoTo F_Update_Main_Err
						End If
						' 2006/11/15  ADD START  KUMEDA
					End If
					' 2006/11/15  ADD END
				End If
			End With
			
		Next intCnt
		
		' === 20080909 === DELETE S - RISE)Izumi
		'    '�R�~�b�g
		'    Call CF_Ora_CommitTrans(gv_Oss_USR1)
		'    bolTrn = False
		' === 20080909 === DELETE E - RISE)Izumi
		
		intRet = CHK_OK
		
F_Update_Main_End: 
		
		' === 20080909 === DELETE S - RISE)Izumi
		'    If bolTrn = True Then
		'        '���[���o�b�N
		'        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		'        bolTrn = False
		'    End If
		' === 20080909 === DELETE E - RISE)Izumi
		
		F_Update_Main = intRet
		Exit Function
		
F_Update_Main_Err: 
		
		intRet = CHK_ERR_ELSE
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TRKMTA_Update
	'   �T�v�F  ���Ӑ�ʏ��i�����N�}�X�^�X�V����
	'   �����F  pm_intCnt   : �z��ԍ�
	'           pm_All      : �S�\����
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_TRKMTA_Update(ByRef pm_intCnt As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim UPD_DATKB As String
		
		On Error GoTo F_TRKMTA_Update_err
		
		F_TRKMTA_Update = 9
		
		'�`�[�폜�敪
		Select Case pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt).Item_Detail(pc_COL_UPDKB).Dsp_Value
			Case UPDKB_INS, UPDKB_UPD '�ǉ��A�X�V
				UPD_DATKB = gc_strDATKB_USE
			Case UPDKB_DEL '�폜
				UPD_DATKB = gc_strDATKB_DEL
		End Select
		
		'���Ӑ�ʏ��i�����N�}�X�^�X�V
		With pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt)
			strSQL = ""
			strSQL = strSQL & " Update TRKMTA  "
			strSQL = strSQL & "    Set DATKB       = '" & CF_Ora_String(UPD_DATKB, 1) & "' " '�`�[�폜�敪
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "      , TRKRNK      = '" & CF_Ora_String(.Item_Detail(pc_COL_TRKRNK).Dsp_Value, 1) & "' " '�����N
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
			strSQL = strSQL & "      , PGID        = '" & SSS_PrgId & "' " '�v���O�����h�c
			' 2006/11/19  ADD END
			strSQL = strSQL & "  Where TOKCD       = '" & CF_Ora_String(pv_TOKMT54_TOKCD, 10) & "' " '���Ӑ�R�[�h
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "    And SKHINGRP    = '" & CF_Ora_String(.Item_Detail(pc_COL_SKHINGRP).Dsp_Value, 4) & "' " '�d�ؗp���i�Q
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "    And STTKSTDT    = '" & CF_Ora_Date(.Item_Detail(pc_COL_STTKSTDT).Dsp_Value) & "' " '�J�n�P���ݒ���t
		End With
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TRKMTA_Update_err
		End If
		
		F_TRKMTA_Update = 0
		
F_TRKMTA_Update_End: 
		Exit Function
		
F_TRKMTA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_011, pm_All, "F_TRKMTA_Update")
		GoTo F_TRKMTA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_TRKMTA_Insert
	'   �T�v�F  ���Ӑ�ʏ��i�����N�}�X�^�ǉ�����
	'   �����F  pm_intCnt   : �z��ԍ�
	'           pm_All      : �S�\����
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_TRKMTA_Insert(ByRef pm_intCnt As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim UPD_DATKB As String
		
		On Error GoTo F_TRKMTA_Insert_err
		
		F_TRKMTA_Insert = 9
		
		'�`�[�폜�敪
		Select Case pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt).Item_Detail(pc_COL_UPDKB).Dsp_Value
			Case UPDKB_INS, UPDKB_UPD '�ǉ��A�X�V
				UPD_DATKB = gc_strDATKB_USE
			Case UPDKB_DEL '�폜
				UPD_DATKB = gc_strDATKB_DEL
		End Select
		
		'���Ӑ�ʏ��i�����N�}�X�^�ǉ�
		With pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt)
			strSQL = ""
			strSQL = strSQL & " Insert into TRKMTA "
			strSQL = strSQL & "        ( DATKB " '�`�[�폜�敪
			strSQL = strSQL & "        , TOKCD " '���Ӑ�R�[�h
			strSQL = strSQL & "        , SKHINGRP " '�d�ؗp���i�Q
			strSQL = strSQL & "        , TRKRNK " '�����N
			strSQL = strSQL & "        , TRKOEM " 'OEM
			strSQL = strSQL & "        , STTKSTDT " '�J�n�P���ݒ���t
			strSQL = strSQL & "        , NBKRT " '�l����
			strSQL = strSQL & "        , RELFL " '�A�g�t���O
			' 2006/11/19  CHG START  KUMEDA
			'        strSQL = strSQL & "        , OPEID "            '�ŏI��Ǝ҃R�[�h
			'        strSQL = strSQL & "        , CLTID "            '�N���C�A���g�h�c
			'        strSQL = strSQL & "        , WRTTM "            '�^�C���X�^���v�i���ԁj
			'        strSQL = strSQL & "        , WRTDT "            '�^�C���X�^���v�i���t�j
			'        strSQL = strSQL & "        , WRTFSTTM "         '�^�C���X�^���v�i�o�^���ԁj
			'        strSQL = strSQL & "        , WRTFSTDT "         '�^�C���X�^���v�i�o�^���j
			strSQL = strSQL & "        , FOPEID " '�ŏI��Ǝ҃R�[�h�i����o�^�j
			strSQL = strSQL & "        , FCLTID " '�N���C�A���g�h�c�i����o�^�j
			strSQL = strSQL & "        , WRTFSTTM " '�^�C���X�^���v (�o�^����)
			strSQL = strSQL & "        , WRTFSTDT " '�^�C���X�^���v (�o�^��)
			strSQL = strSQL & "        , OPEID " '�ŏI��Ǝ҃R�[�h
			strSQL = strSQL & "        , CLTID " '�N���C�A���g�h�c
			strSQL = strSQL & "        , WRTTM " '�^�C���X�^���v (����)
			strSQL = strSQL & "        , WRTDT " '�^�C���X�^���v (���t)
			strSQL = strSQL & "        , UOPEID " '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
			strSQL = strSQL & "        , UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
			strSQL = strSQL & "        , UWRTTM " '�^�C���X�^���v (�o�b�`����)
			strSQL = strSQL & "        , UWRTDT " '�^�C���X�^���v (�o�b�`���t)
			strSQL = strSQL & "        , PGID " '�v���O�����h�c
			' 2006/11/19  CHG END
			strSQL = strSQL & "        ) "
			strSQL = strSQL & " Values "
			strSQL = strSQL & "        (  '" & CF_Ora_String(UPD_DATKB, 1) & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_String(pv_TOKMT54_TOKCD, 10) & "' "
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "        ,  '" & CF_Ora_String(.Item_Detail(pc_COL_SKHINGRP).Dsp_Value, 4) & "' "
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "        ,  '" & CF_Ora_String(.Item_Detail(pc_COL_TRKRNK).Dsp_Value, 1) & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_String("", 1) & "' "
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "        ,  '" & CF_Ora_Date(.Item_Detail(pc_COL_STTKSTDT).Dsp_Value) & "' "
			strSQL = strSQL & "        ,   " & CF_Ora_Number("0") & " "
			strSQL = strSQL & "        ,  '" & CF_Ora_String("", 1) & "' "
			' 2006/11/19  CHG START  KUMEDA
			'        strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_OPEID, 8) & "' "
			'        strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_CLTID, 5) & "' "
			'        strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
			'        strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
			'        strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
			'        strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
			strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
			strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
			strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
			strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
			strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
			strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
			strSQL = strSQL & "        ,  '" & SSS_PrgId & "' "
			' 2006/11/19  CHG END
			strSQL = strSQL & "        ) "
		End With
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TRKMTA_Insert_err
		End If
		
		F_TRKMTA_Insert = 0
		
F_TRKMTA_Insert_End: 
		Exit Function
		
F_TRKMTA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT54_E_011, pm_All, "F_TRKMTA_Insert")
		GoTo F_TRKMTA_Insert_End
		
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
				'            '��ʈ��
				'            Trg_Index = CInt(FR_SSSMAIN.MN_HARDCOPY.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
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
		''    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = pv_InpTan_TOK
		'' 2007/01/11  END
		'���׍s�}���{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_INSERTDE.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_InsertDE.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'���׍s�폜�{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_DELETEDE.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_DeleteDE.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'�����{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_SLIST.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'�O�Ń{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_PREV.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Prev.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'���Ń{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_NEXTCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_NextCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'�ꗗ�\���{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_SelectCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_SelectCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
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
		
		'���Ӑ�(�R�[�h)
		Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
		Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
		
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
			'        Wk_Index = CInt(FR_SSSMAIN.BD_HINCD(Index_Bd_Wk).Tag)
			''�d���������������������������������������������������������d
			'        'Dsp_Body_Inf�̍s�m�n�ɕϊ�
			'        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			''�r���������������������������������������������������������r
			'        'Dsp_Body_Inf�ɒl�������l��ݒ�
			'        Call F_Init_Dsp_Body(Wk_Row, pm_All)
			''�d���������������������������������������������������������d
			
		Next 
		
		gv_bolTOKMT54_INIT = False
		
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
		
		'�r���������������������������������������������������������r
		'�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
		'���Ӑ�(�R�[�h)�Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
		
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
		
		'�r���������������������������������������������������������r
		'�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
		'�d�ؗp���i�Q�Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.BD_SKHINGRP(1).Tag)
		
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
	'   ���́F  Function F_Set_NextRow_Status
	'   �T�v�F  �ŏI�s�̎��s�̏�Ԃ��ŏI�����s�ɐݒ�
	'   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_NextRow_Status(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		Dim Bd_Index As Short
		
		'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		If Bd_Index = 0 Then
			Bd_Index = Bd_Index + pm_All.Dsp_Body_Inf.Cur_Top_Index - 1
		End If
		
		If Bd_Index - (pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1)) < pm_All.Dsp_Base.Dsp_Body_Cnt Then
			'���s�̉�ʃ{�f�B�s��Ԃ��ŏI�����s�ɐݒ�
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index + 1).Status = BODY_ROW_STATE_DEFAULT Then
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index + 1).Status = BODY_ROW_STATE_LST_ROW
			End If
		End If
		
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
	Public Function F_Reset_Item_Color(ByRef pm_All As Cls_All) As Short
		
		Dim Row_Cnt As Short
		
		For Row_Cnt = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
			FR_SSSMAIN.BD_SKHINGRP(Row_Cnt).ForeColor = ACE_CMN.COLOR_BLACK
			FR_SSSMAIN.BD_STTKSTDT(Row_Cnt).ForeColor = ACE_CMN.COLOR_BLACK
			FR_SSSMAIN.BD_TRKRNK(Row_Cnt).ForeColor = ACE_CMN.COLOR_BLACK
		Next 
	End Function
	' === 20060825 === INSERT E
	
	' === 20061031 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_Inp_TOK
	'   �T�v�F  ���͒S���ҍX�V�����擾
	'   �����F�@pm_Form        :�t�H�[��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_Inp_TOK(ByRef pm_All As Cls_All) As Short
		
		'������
		pv_InpTan_TOK = False
		
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
		'''        pv_InpTan_TOK = True
		'''    End If
		''    If gs_UPDAUTH = "1" Then
		''        pv_InpTan_TOK = True
		''    End If
		''' 2006/11/02  CHG END
		If Inp_Inf.InpJDNUPDKB = "1" Then
			pv_InpTan_TOK = True
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
			
			'���̓R�[�h����
			If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
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
						'���s�̎d�ؗp���i�Q�̲��ޯ���擾
						Trg_Index_Same_Row = CShort(FR_SSSMAIN.BD_SKHINGRP(pm_Row).Tag)
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
		
		'���݂̃t�H�[�J�X�����ׂɂȂ��ꍇ�͏������~
		If Bd_Index = 0 Then
			Exit Function
		End If
		
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
		
		'�G���[�F��߂�
		FR_SSSMAIN.BD_SKHINGRP(Bd_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index + 1).BackColor = ACE_CMN.COLOR_WHITE
		FR_SSSMAIN.BD_STTKSTDT(Bd_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index + 1).BackColor = ACE_CMN.COLOR_WHITE
		FR_SSSMAIN.BD_TRKRNK(Bd_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index + 1).BackColor = ACE_CMN.COLOR_WHITE
		'�d���������������������������������������������������������d
		
		'��ʕ\��
		'    Call CF_Body_Dsp(pm_All)
		Call F_Body_Dsp(pm_All)
		
		'�ҏW�ς݂Ƃ���
		' 2006/11/15  DLT START  KUMEDA
		'    gv_bolTOKMT54_INIT = True
		' 2006/11/15  DLT END
		
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
		
		'���݂̃t�H�[�J�X�����ׂɂȂ��ꍇ�͏������~
		If Bd_Index = 0 Then
			Exit Function
		End If
		
		'���ʂ̖��ב}��
		'If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
		If F_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
			'�r���������������������������������������������������������r
			'�}�������s�̃t�H�[�J�X������ɂ���
			For Clm_Cnt = 2 To 4
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
					For Clm_Cnt = 2 To 4
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
			' 2006/11/15  DLT START  KUMEDA
			'        gv_bolTOKMT54_INIT = True
			' 2006/11/15  DLT END
			
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
	
	'''' ADD 2008/06/05  FKS) S.Nakajima    Start
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TRKMTA_SEARCH_Check
	'   �T�v�F  ���꓾�Ӑ揤�i�ɑ΂��A�����̃����N�͑��݂ł��Ȃ��悤�ɂ���B
	'   �����F  pin_strSKHINGRP�@: �d�ؗp���i�Q
	'   �@�@�@�@pin_strSTTKSTDT  : �J�n�P���ݒ���t
	'   �@�@�@�@pin_strTRKRNK    : �����N
	'   �@�@�@�@pot_DB_TRKMTA�@�@: ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TRKMTA_SEARCH_Check(ByVal pin_strSKHINGRP As String, ByVal pin_strSTTKSTDT As String, ByVal pin_strTRKRNK As String, ByRef pot_DB_TRKMTA As TYPE_DB_TRKMTA) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strTGRPCD As String
		
		On Error GoTo ERR_TRKMTA_SEARCH_Check
		
		TRKMTA_SEARCH_Check = 9
		
		Call DB_TRKMTA_Clear(pot_DB_TRKMTA)
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from TRKMTA "
		strSQL = strSQL & "  Where TOKCD     = '" & CF_Ora_String(pv_TOKMT54_TOKCD, 10) & "' "
		strSQL = strSQL & "    and SKHINGRP  = '" & CF_Ora_String(pin_strSKHINGRP, 4) & "' "
		strSQL = strSQL & "    and STTKSTDT  = '" & CF_Ora_Date(pin_strSTTKSTDT) & "' "
		strSQL = strSQL & "    and DATKB     = '1' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'�擾�f�[�^�Ȃ�
			TRKMTA_SEARCH_Check = 1
			GoTo END_TRKMTA_SEARCH_Check
		End If
		
		'---------------------------------------
		' �}�X�^�`�F�b�N
		'---------------------------------------
		' ���꓾�Ӑ揤�i�ɑ΂��A�����̃����N��
		' ���݂ł��Ȃ��悤�ɂ���B
		'---------------------------------------
		If CF_Ora_EOF(Usr_Ody) = False Then
			With pot_DB_TRKMTA
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "") '�d�ؗp���i�Q
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.TRKRNK = CF_Ora_GetDyn(Usr_Ody, "TRKRNK", "") '�����N
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.STTKSTDT = CF_Ora_GetDyn(Usr_Ody, "STTKSTDT", "") '�J�n�P���ݒ���t
			End With
			'�o�^�s��
			TRKMTA_SEARCH_Check = 2
			GoTo END_TRKMTA_SEARCH_Check
		End If
		
		TRKMTA_SEARCH_Check = 0
		
END_TRKMTA_SEARCH_Check: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_TRKMTA_SEARCH_Check: 
		GoTo END_TRKMTA_SEARCH_Check
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_CHECK_STTKSTDT
	'   �T�v�F  �X�V���A�����f�[�^�����邩�`�F�b�N
	'   �����F  pm_All        : ��ʏ��
	'   �ߒl�F�@�������ʃX�e�[�^�X
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_CHECK_STTKSTDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim intCnt As Short
		Dim Wk_Row As Short
		Dim Upd_Start As Short
		Dim Upd_End As Short
		
		On Error GoTo F_CHECK_STTKSTDT_Err
		
		F_CHECK_STTKSTDT = CHK_OK
		
		'��ʂ̓��e���擾
		Call CF_Body_Bkup(pm_All)
		
		'���[�v�J�n�A�I���̌v�Z
		Upd_Start = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1
		Upd_End = pm_All.Dsp_Base.Dsp_Body_Cnt * NowPageNum
		
		' ��ʂ̍s�擾
		Wk_Row = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + pm_Chk_Dsp_Sub_Inf.Detail.Body_Index
		
		' �I���O���b�h�̉��
		If pm_Chk_Dsp_Sub_Inf.Detail.Body_Index = 0 Then
			For Wk_Row = Upd_Start To Upd_End
				For intCnt = Upd_Start To Upd_End
					
					With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
						
						'�f�[�^�����݂��邩�`�F�b�N
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(CStr(.Item_Detail(pc_COL_SKHINGRP).Dsp_Value)) = Trim(CStr(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(pc_COL_SKHINGRP).Dsp_Value)) And Trim(CStr(.Item_Detail(pc_COL_STTKSTDT).Dsp_Value)) = Trim(CStr(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(pc_COL_STTKSTDT).Dsp_Value)) Then
							
							'�����s�̓`�F�b�N���Ȃ�
							If intCnt <> Wk_Row Then
								F_CHECK_STTKSTDT = CHK_ERR_ELSE
								'�`�F�b�N�G���[�Ƃ���
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								Exit Function
							End If
							
						End If
						
					End With
					
				Next intCnt
			Next Wk_Row
		Else
			For intCnt = Upd_Start To Upd_End
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					
					'�f�[�^�����݂��邩�`�F�b�N
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(CStr(.Item_Detail(pc_COL_SKHINGRP).Dsp_Value)) = Trim(CStr(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(pc_COL_SKHINGRP).Dsp_Value)) And Trim(CStr(.Item_Detail(pc_COL_STTKSTDT).Dsp_Value)) = Trim(CStr(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(pc_COL_STTKSTDT).Dsp_Value)) Then
						
						'�����s�̓`�F�b�N���Ȃ�
						If intCnt <> Wk_Row Then
							F_CHECK_STTKSTDT = CHK_ERR_ELSE
							'�`�F�b�N�G���[�Ƃ���
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							Exit Function
						End If
						
					End If
					
				End With
				
			Next intCnt
		End If
		
		F_CHECK_STTKSTDT = CHK_OK
		
F_CHECK_STTKSTDT_End: 
		
		Exit Function
		
F_CHECK_STTKSTDT_Err: 
		
		GoTo F_CHECK_STTKSTDT_End
		
	End Function
	
	'''' ADD 2008/06/05  FKS) S.Nakajima    End
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module