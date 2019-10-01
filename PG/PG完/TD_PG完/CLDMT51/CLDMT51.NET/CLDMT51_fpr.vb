Option Strict Off
Option Explicit On
'20190809 CHG START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'20190809 CHG END
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(92 + 6 + 0 + 1) As clsCP
	Public CL_SSSMAIN(92) As Short
    Public CQ_SSSMAIN(8) As String


    '20190809  ADD START
    Public D0 = New ClsComn
    Public LV_Col_Order() As Integer
    '20190809 ADD END

    '2008/07/09 START ADD FNAP)YAMANE �A���[���F�r��-54
    Public HAITA_FLG As String
	'2008/07/09 E.N.D ADD FNAP)YAMANE �A���[���F�r��-54
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	'�r���������������������������������������������������������r
	'�����������`�F�b�N���s�t���O
	Public gv_bolInit As Boolean '������������True(�`�F�b�N�Ȃ��j�@����ȊO��False
	Public gv_bolCLDMT51_INIT As Boolean '��ʏ������t���O�iTrue:�ύX����j
	' === 20060801 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���E����W�\�����̕s��Ή�
	Public gv_bolCLDMT51_LF_Enable As Boolean 'LF�������s�t���O(False�F���s���Ȃ�)
	Public gv_bolKeyFlg As Boolean
	' === 20060801 === INSERT E
	' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
	Public gv_bolUpdFlg As Boolean
	' === 20060808 === INSERT E
	
	Public Structure CLDMT51_TYPE_CLDMTA
		Dim DATKB As String '�`�[�폜�敪
		Dim CLDDT As String '���t
		Dim CLDWKKB As String '�j��
		Dim CLDHLKB As String '�j��
		Dim SLSMDD As String '�c�ƒʎZ����
		Dim PRDKDDD As String '���Y�ғ�����
		Dim DTBKDDD As String '�����ғ�����
		Dim CLDSMDD As String '����ʎZ����
		Dim SLDKB As String '�c�Ɠ��敪
		Dim BNKKDKB As String '��s�ғ��敪
		Dim PRDKDKB As String '���Y�ғ��敪
		Dim DTBKDKB As String '�����ғ��敪
	End Structure
	'�J�����_�}�X�^���
	Public CLDMT51_CLDMTA_Inf As CLDMT51_TYPE_CLDMTA
	'�J�����_�}�X�^���i�X�V�p�j
	Public CLDMT51_CLDMTA_Update_Inf() As CLDMT51_TYPE_CLDMTA
	
	'�y�[�W���
	Public MaxPageNum As Short '���ׂ̍ő�y�[�W��
	Public NowPageNum As Short '���ׂ̌��݂̃y�[�W��
	Public MinPageNum As Short '���ׂ̍ŏ��y�[�W��
	
	'���[�h
	'Public Const UPDKB_INS              As String = "�ǉ�"
	Public Const UPDKB_UPD As String = "�X�V"
	'Public Const UPDKB_DEL              As String = "�폜"
	
	'
	Private pv_bolMEISAI_INPUT As Boolean '���ד��̓t���O(True:���͂���j
	Private pv_intMeisaiCnt As Short '���͖��א��i�X�V���g�p�j
	Private pv_bolInput_Bef_Row As Boolean '�O�s���̓t���O�iTrue:���͍ρj
	
	'LLLLL 20060913 INSERT S LLLLLLLLLLLLLLL
	'�y�[�W�J�ڃ{�^���������̕s��Ή��B�i�t�H�[�J�X�̒D������������j
	Public gb_pageChange As Boolean '�y�[�W�J�ڔ���t���O
	Public gb_txtChange As Boolean '�y�[�W�J�ڔ���t���O
	Public gb_dateYM As String '�O���^����
	'LLLLL 20060913 INSERT E LLLLLLLLLLLLLLL
	
	'LLLLL 20060913 INSERT S LLLLLLLLLLLLLLL
	Public gb_CldUpdFlg As Boolean '�J�����_�[�X�V�t���O�iTrue:�X�V�j
	'LLLLL 20060913 INSERT E LLLLLLLLLLLLLLL
	
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
	'//F_Dsp_Item_Detail�������[�h
	Public Const DSP_SET As Short = 0 '�\��
	Public Const DSP_CLR As Short = 1 '�N���A
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_CLD_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k����
	'   �����F�@pm_clddt    :�o�^�N���i�����j
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_CLD_SQL(ByRef pm_clddt As String) As String
		
		Dim strSQL As String
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "     DATKB " '�`�[�폜�敪
		strSQL = strSQL & "    ,CLDDT " '���t
		strSQL = strSQL & "    ,CLDWKKB " '�j��
		strSQL = strSQL & "    ,CLDHLKB " '�j��
		strSQL = strSQL & "    ,SLSMDD " '�c�ƒʎZ����
		strSQL = strSQL & "    ,PRDKDDD " '���Y�ғ�����
		strSQL = strSQL & "    ,DTBKDDD " '�����ғ�����
		strSQL = strSQL & "    ,CLDSMDD " '����ʎZ����
		strSQL = strSQL & "    ,SLDKB " '�c�Ɠ��敪
		strSQL = strSQL & "    ,BNKKDKB " '��s�ғ��敪
		strSQL = strSQL & "    ,PRDKDKB " '���Y�ғ��敪
		strSQL = strSQL & "    ,DTBKDKB " '�����ғ��敪
		' === 20081001 === UPDATE S - RISE)Izumi
		''2007/12/27 add-str M.SUEZAWA
		'    strSQL = strSQL & "    ,WRTTM "         '�X�V����
		'    strSQL = strSQL & "    ,WRTDT "         '�X�V���t
		'    strSQL = strSQL & "    ,UWRTTM "        '�o�b�`�X�V����
		'    strSQL = strSQL & "    ,UWRTDT "        '�o�b�`�X�V���t
		''2007/12/27 add-end M.SUEZAWA
		strSQL = strSQL & "    ,OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "    ,CLTID " '�N���C�A���g�h�c
		strSQL = strSQL & "    ,WRTTM " '�X�V����
		strSQL = strSQL & "    ,WRTDT " '�X�V���t
		strSQL = strSQL & "    ,UOPEID " '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		strSQL = strSQL & "    ,UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "    ,UWRTTM " '�o�b�`�X�V����
		strSQL = strSQL & "    ,UWRTDT " '�o�b�`�X�V���t
		' === 20081001 === UPDATE E - RISE)Izumi
		
		strSQL = strSQL & " FROM "
		strSQL = strSQL & "     CLDMTA "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     CLDDT LIKE '" & pm_clddt & "%' "
		strSQL = strSQL & " AND "
		strSQL = strSQL & "     DATKB = '1' "
		strSQL = strSQL & " ORDER BY "
		strSQL = strSQL & "     CLDDT "
		
		F_GET_CLD_SQL = strSQL
		
	End Function
	
	'LLLLL 20060913 INSERT S LLLLLLLLLLLLLLL
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_CLDUPDKB_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k����
	'   �����F�@pm_tancd    :�S���҃R�[�h�i�����j
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_CLDUPDKB_SQL(ByRef pm_TANCD As String) As String
		
		Dim strSQL As String
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " SELECT  "
		strSQL = strSQL & "     A.CLDUPDKB  "
		strSQL = strSQL & " FROM  "
		strSQL = strSQL & "     KNGMTA A "
		strSQL = strSQL & "   , TANMTA B "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     A.KNGGRCD = B.KNGGRCD "
		strSQL = strSQL & " AND "
		strSQL = strSQL & "     B.TANCD = '" & pm_TANCD & "' "
		
		F_Get_CLDUPDKB_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_KNGMTA_CLDUPDKB
	'   �T�v�F  �J�����_�[�}�X�^�X�V�����`�F�b�N
	'   �����F  pm_All      :�S�\����
	'   �ߒl�F�@Integer
	'   ���l�F  �J�����_�[�}�X�^�̍X�V�����L�����`�F�b�N
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_KNGMTA_CLDUPDKB(ByRef pm_All As Cls_All) As Short
		
		'�������擾�i�J�����_�X�V�����j
		F_Chk_KNGMTA_CLDUPDKB = F_Get_CLDUpdKB()
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_CLDUPdKB_Inf
	'   �T�v�F  �������擾
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�J�����_�X�V����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_CLDUpdKB() As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strKNGGRCD As String
		
		On Error GoTo ERR_F_Get_CLDUpdKB
		
		F_Get_CLDUpdKB = -1
		
		'��������A�����Ȃ��Ƃ���
		strKNGGRCD = gc_strTKCHGKB_NG
		
		' 2006/10/31  CHG START  KUMEDA
		'    '�����O���[�v�擾�r�p�k�쐬
		'    strSQL = F_Get_CLDUPDKB_SQL(Inp_Inf.InpTanCd)
		'
		'    'DB�A�N�Z�X
		'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		'
		'    If CF_Ora_EOF(Usr_Ody) = True Then
		'        '�擾�f�[�^�Ȃ�
		'        GoTo END_F_Get_CLDUpdKB
		'    Else
		'        strKNGGRCD = CF_Ora_GetDyn(Usr_Ody, "CLDUPDKB", "")          '�J�����_�[�X�V�敪
		'
		'        If Trim(strKNGGRCD) = gc_strTKCHGKB_OK Then
		'            F_Get_CLDUpdKB = CHK_OK
		'        End If
		'
		'    End If
		'' 2006/11/13  CHG START  KUMEDA
		''    gs_userid = Inp_Inf.InpTanCd
		''    gs_pgid = SSS_PrgId
		''
		''    gs_kengen = Get_Authority(GV_UNYDate)
		''
		''    strKNGGRCD = gs_UPDAUTH
		''
		''    If Trim(strKNGGRCD) = gc_strTKCHGKB_OK Then
		''        F_Get_CLDUpdKB = CHK_OK
		''    End If
		If Inp_Inf.InpJDNUPDKB = "1" Then
			F_Get_CLDUpdKB = CHK_OK
		End If
		'' 2006/11/13  CHG END
		' 2006/10/31  CHG END
		
		
END_F_Get_CLDUpdKB: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_F_Get_CLDUpdKB: 
		GoTo END_F_Get_CLDUpdKB
		
	End Function
	
	'LLLLL 20060913 INSERT E LLLLLLLLLLLLLLL
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA
	'   �T�v�F  �{�f�B���f�[�^�擾
	'   �����F  pm_All      :�S�\����
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
		Dim intDCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim Rtn_Str_Value As String
		Dim I As Short
		Dim strWKKBNM As String
		Dim Dsp_Value As Object
		
		On Error GoTo ERR_F_GET_BD_DATA
		
		F_GET_BD_DATA = -1
		
		'������
		strSQL = ""
		Err_Cd = ""
		
		'�����r�p�k����
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Rtn_Str_Value = CF_Get_Input_Ok_Item(CStr(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_CLDDT.Tag)))), pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_CLDDT.Tag)))
		
		If Trim(Rtn_Str_Value) = "" Then
			'�擾�f�[�^�Ȃ�
			F_GET_BD_DATA = 0
			
			GoTo END_F_GET_BD_DATA
		End If
		
		strSQL = F_GET_CLD_SQL(Rtn_Str_Value)

        'DB�A�N�Z�X
        '20190814 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '20190814 CHG END
            '�擾�f�[�^�Ȃ�
            F_GET_BD_DATA = 0
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_CLDDT.Tag)).Detail.Err_Status = ERR_ELSE
            Err_Cd = gc_strMsgCLDMT51_E_002
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

            GoTo END_F_GET_BD_DATA
        Else

            ' === 20081001 === DELETE S - RISE)Izumi
            ''2007/12/27 del-str T.KAWAMUKAI 2007/12/27 ���ɖ߂��@M.SUEZAWA
            '''2007/12/13 add-str T.KAWAMUKAI ���f�[�^�̃^�C���X�^���v�ޔ�
            '        M_MOTO_inf.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")      '�X�V����
            '        M_MOTO_inf.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")      '�X�V���t
            '        M_MOTO_inf.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")    '�o�b�`�X�V����
            '        M_MOTO_inf.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")    '�o�b�`�X�V���t
            '''2007/12/13 add-end T.KAWAMUKAI
            ''2007/12/27 del-end T.KAWAMUKAI
            ' === 20081001 === DELETE E - RISE)Izumi

            '������
            For intCnt = 0 To 30 Step 1
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					.Bus_Inf.Selected = CStr(False) '�I��/��I��
					.Bus_Inf.DATKB = "" '�`�[�폜�敪
					.Bus_Inf.CLDDT = "" '���t
					.Bus_Inf.CLDWKKB = "" '�j��
					.Bus_Inf.CLDHLKB = "" '�j��
					.Bus_Inf.SLSMDD = "" '�c�ƒʎZ����
					.Bus_Inf.PRDKDDD = "" '���Y�ғ�����
					.Bus_Inf.DTBKDDD = "" '�����ғ�����
					.Bus_Inf.CLDSMDD = "" '����ʎZ����
					.Bus_Inf.SLDKB = "" '�c�Ɠ��敪
					.Bus_Inf.BNKKDKB = "" '��s�ғ��敪
					.Bus_Inf.PRDKDKB = "" '���Y�ғ��敪
					.Bus_Inf.DTBKDKB = "" '�����ғ��敪
				End With
			Next intCnt
			
			'���[�h�ݒ�i�X�V�FUPDKB_UPD�j�̂�
			Wk_Index = CShort(FR_SSSMAIN.HD_UPDKB.Tag)
			Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UPDKB_UPD, pm_All.Dsp_Sub_Inf(Wk_Index), False), pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DEF)
			
			intCnt = 0
            'Do Until CF_Ora_EOF(Usr_Ody) = True
            For j As Integer = 0 To dt.Rows.Count - 1
                '�擾�S���R�[�h���{�f�B���ޔ�
                With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
                    .Bus_Inf.Selected = CStr(False) '�I��/��I��
                    '20190819 CHG START
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '               .Bus_Inf.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.CLDDT = CF_Ora_GetDyn(Usr_Ody, "CLDDT", "") '���t
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.CLDWKKB = CF_Ora_GetDyn(Usr_Ody, "CLDWKKB", "") '�j��
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.CLDHLKB = CF_Ora_GetDyn(Usr_Ody, "CLDHLKB", "") '�j��
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SLSMDD = CF_Ora_GetDyn(Usr_Ody, "SLSMDD", "") '�c�ƒʎZ����
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.PRDKDDD = CF_Ora_GetDyn(Usr_Ody, "PRDKDDD", "") '���Y�ғ�����
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.DTBKDDD = CF_Ora_GetDyn(Usr_Ody, "DTBKDDD", "") '�����ғ�����
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.CLDSMDD = CF_Ora_GetDyn(Usr_Ody, "CLDSMDD", "") '����ʎZ����
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.SLDKB = CF_Ora_GetDyn(Usr_Ody, "SLDKB", "") '�c�Ɠ��敪
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.BNKKDKB = CF_Ora_GetDyn(Usr_Ody, "BNKKDKB", "") '��s�ғ��敪
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.PRDKDKB = CF_Ora_GetDyn(Usr_Ody, "PRDKDKB", "") '���Y�ғ��敪
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.DTBKDKB = CF_Ora_GetDyn(Usr_Ody, "DTBKDKB", "") '�����ғ��敪

                    .Bus_Inf.DATKB = DB_NullReplace(dt.Rows(j)("DATKB"), "")
                    .Bus_Inf.CLDDT = DB_NullReplace(dt.Rows(j)("CLDDT"), "")
                    .Bus_Inf.CLDWKKB = DB_NullReplace(dt.Rows(j)("CLDWKKB"), "")
                    .Bus_Inf.CLDHLKB = DB_NullReplace(dt.Rows(j)("CLDHLKB"), "")
                    .Bus_Inf.SLSMDD = DB_NullReplace(dt.Rows(j)("SLSMDD"), "")
                    .Bus_Inf.PRDKDDD = DB_NullReplace(dt.Rows(j)("PRDKDDD"), "")
                    .Bus_Inf.DTBKDDD = DB_NullReplace(dt.Rows(j)("DTBKDDD"), "")
                    .Bus_Inf.CLDSMDD = DB_NullReplace(dt.Rows(j)("CLDSMDD"), "")
                    .Bus_Inf.SLDKB = DB_NullReplace(dt.Rows(j)("SLDKB"), "")
                    .Bus_Inf.BNKKDKB = DB_NullReplace(dt.Rows(j)("BNKKDKB"), "")
                    .Bus_Inf.PRDKDKB = DB_NullReplace(dt.Rows(j)("PRDKDKB"), "")
                    .Bus_Inf.DTBKDKB = DB_NullReplace(dt.Rows(j)("DTBKDKB"), "")

                    '2007/12/27 add-str T.KAWAMUKAI  2007/12/27 del M.SUEZAWA
                    '''                .Bus_Inf.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")            '�X�V���t
                    '''                .Bus_Inf.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")            '�X�V����
                    '''                .Bus_Inf.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")          '�o�b�`���t
                    '''                .Bus_Inf.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")          '�o�b�`����
                    '2007/12/27 add-end T.KAWAMUKAI
                    ' === 20081001 === INSERT S - RISE)Izumi
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '               .Bus_Inf.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�X�V���t
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�X�V����
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") '�N���C�A���g�h�c�i�o�b�`�j
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") '�o�b�`���t
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Bus_Inf.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") '�o�b�`����

                    .Bus_Inf.OPEID = DB_NullReplace(dt.Rows(j)("OPEID"), "")
                    .Bus_Inf.CLTID = DB_NullReplace(dt.Rows(j)("CLTID"), "")
                    .Bus_Inf.WRTDT = DB_NullReplace(dt.Rows(j)("WRTDT"), "")
                    .Bus_Inf.WRTTM = DB_NullReplace(dt.Rows(j)("WRTTM"), "")
                    .Bus_Inf.UOPEID = DB_NullReplace(dt.Rows(j)("UOPEID"), "")
                    .Bus_Inf.UCLTID = DB_NullReplace(dt.Rows(j)("UCLTID"), "")
                    .Bus_Inf.UWRTDT = DB_NullReplace(dt.Rows(j)("UWRTDT"), "")
                    .Bus_Inf.UWRTTM = DB_NullReplace(dt.Rows(j)("UWRTTM"), "")
                    '20190819 CHG END
                    ' === 20081001 === INSERT E - RISE)Izumi

                    '�Ώۍs�̏��
                    pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_DEFAULT

                End With

                intCnt = intCnt + 1

                If intCnt > 31 Then
                    Exit For
                End If

                '�����R�[�h
                'Call CF_Ora_MoveNext(Usr_Ody)
            Next

            intDCnt = intCnt - 1
			
			For intCnt = 0 To 30 Step 1
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					
					'�j���i���́j�̐ݒ�
					Select Case .Bus_Inf.CLDWKKB
						Case CStr(1)
							strWKKBNM = "��"
						Case CStr(2)
							strWKKBNM = "��"
						Case CStr(3)
							strWKKBNM = "��"
						Case CStr(4)
							strWKKBNM = "��"
						Case CStr(5)
							strWKKBNM = "��"
						Case CStr(6)
							strWKKBNM = "��"
						Case CStr(7)
							strWKKBNM = "�y"
					End Select
					
					'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
					'���t
					Wk_Index = CShort(FR_SSSMAIN.BD_CLDT(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(Right(.Bus_Inf.CLDDT, 2), pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'�j���i�R�[�h�j
					Wk_Index = CShort(FR_SSSMAIN.BD_WKKB(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.CLDWKKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'�j���i���́j
					Wk_Index = CShort(FR_SSSMAIN.BD_WKKBNM(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(strWKKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'�j�Փ�
					Wk_Index = CShort(FR_SSSMAIN.BD_CLDHLKB(1).Tag)
					'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.CLDHLKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(4).Focus_Ctl = True
					'�c�Ɠ��敪
					Wk_Index = CShort(FR_SSSMAIN.BD_SLDKB(1).Tag)
					'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.SLDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(5).Focus_Ctl = True
					'�����ғ��敪
					Wk_Index = CShort(FR_SSSMAIN.BD_DTBKDKB(1).Tag)
					'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.DTBKDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(6).Focus_Ctl = True
					'���Y�ғ��敪
					Wk_Index = CShort(FR_SSSMAIN.BD_PRDKDKB(1).Tag)
					'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.PRDKDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(7).Focus_Ctl = True
					'��s�ғ��敪
					Wk_Index = CShort(FR_SSSMAIN.BD_BNKKDKB(1).Tag)
					'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.BNKKDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(8).Focus_Ctl = True
					'�c�ƒʎZ�ғ�����
					Wk_Index = CShort(FR_SSSMAIN.BD_SLSMDD(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SLSMDD, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'�����ʎZ�ғ�����
					Wk_Index = CShort(FR_SSSMAIN.BD_DTBKDDD(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.DTBKDDD, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'���Y�ʎZ�ғ�����
					Wk_Index = CShort(FR_SSSMAIN.BD_PRDKDDD(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.PRDKDDD, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'����ʎZ����
					Wk_Index = CShort(FR_SSSMAIN.BD_CLDSMDD(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.CLDSMDD, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'�Ώۍs�̏��
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_INPUT
				End With
				
				strWKKBNM = ""
				
			Next intCnt
			
			'        '�f�[�^�ŏI�s�̏��
			'        For I = intDCnt To 30 Step 1
			'            pm_All.Dsp_Body_Inf.Row_Inf(I).Status = BODY_ROW_STATE_LST_ROW
			'        Next I
			
			'�s���\���̔z��� Redim
			MaxPageNum = 1
		End If
		
END_F_GET_BD_DATA: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_GET_BD_DATA = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA: 
		GoTo END_F_GET_BD_DATA
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
	'
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
		Dim Last_Data_Index As Short
		Dim Fcs_Flg As Boolean
		Dim Index_Of_Window As Short
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'���ו\���̉��
			
			'�{�f�B�����ŏ���
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call CF_Set_Item_Not_Change(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Value, pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					'�G���[�t���O�𗎂Ƃ�
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_DEF
					'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Index_Wk), ITEM_NORMAL_STATUS, pm_All)
					
					'�t�H�[�J�X�L���̔���
					Fcs_Flg = F_Jge_Focus(Index_Wk, pm_All)
					'�t�H�[�J�X�̐���
					Call CF_Set_Item_Focus_Ctl(Fcs_Flg, pm_All.Dsp_Sub_Inf(Index_Wk))
					
					'�f�[�^�L�s�m�n�̑ޔ�
					If Fcs_Flg = True Then
						Last_Data_Index = Bd_Index
					End If
				End If
				
			Next 
			
			'���׏�̲��ޯ�����擾
			If Last_Data_Index <> 0 Then
				Index_Of_Window = Last_Data_Index - (pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1)) + ((pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1) - pm_All.Dsp_Body_Inf.Cur_Top_Index)
			Else
				Index_Of_Window = Last_Data_Index
			End If
		End If
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060908 === INSERT S
	'
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Jge_Focus
	'   �T�v�F  �t�H�[�J�X�L���̔���
	'   �����F�@pm_All      :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Jge_Focus(ByRef pm_Index_Tag As Short, ByRef pm_All As Cls_All) As Boolean
		
		Dim Index_Wk As Short
		Dim Tgt_Index As Short
		Dim intCnt As Short
		
		'������
		F_Jge_Focus = False
		
		'���׍s�ԍ��̎擾
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Index_Wk = pm_All.Dsp_Sub_Inf(pm_Index_Tag).Detail.Body_Index
		
		'�u�敪�v���ڂ̏ꍇ
		For intCnt = 0 To 30
			'�f�[�^�����s�̏ꍇ�A�����𔲂���
			If Trim(FR_SSSMAIN.BD_CLDT(intCnt).Text) = "" Then
				Exit For
			End If
			
			Select Case pm_Index_Tag
				Case CShort(FR_SSSMAIN.BD_CLDHLKB(intCnt).Tag), CShort(FR_SSSMAIN.BD_SLDKB(intCnt).Tag), CShort(FR_SSSMAIN.BD_DTBKDKB(intCnt).Tag), CShort(FR_SSSMAIN.BD_PRDKDKB(intCnt).Tag), CShort(FR_SSSMAIN.BD_BNKKDKB(intCnt).Tag)
					F_Jge_Focus = True
			End Select
		Next intCnt
		
	End Function
	' === 20060908 === INSERT E
	
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
				
				' === 20060825 === INSERT S
				If intIdx = intBfrUBound + 1 Then
					'�ǉ��P�s�ڂ̏�Ԃ��ŏI�����s�ɐݒ�
					pm_All.Dsp_Body_Inf.Row_Inf(intIdx).Status = BODY_ROW_STATE_LST_ROW
					'�Ǘ��R�[�h���t�H�[�J�X����ɂ���
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_All.Dsp_Body_Inf.Row_Inf(intIdx).Item_Detail(2).Focus_Ctl = True
				End If
				' === 20060825 === INSERT E
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
		gv_bolCLDMT51_INIT = True
		
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
	Public Function F_Set_Befe_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'���̍��ڂ�����
		For Index_Wk = Trg_Index - 1 To 1 Step -1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�t�b�^������{�f�B���ֈړ�����ꍇ
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					Index_Wk = Focus_Ctl_Ok_Fst_Idx
				End If
				
			End If
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
				'�{�f�B������w�b�_���ֈړ�����ꍇ
				If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
					'���ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
					
					'��ʂ̓��e��ޔ�
					Call CF_Body_Bkup(pm_All)
					'�ړ��\�s����ԏ�ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
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
					
					'���͉\�ȍŌ�̃C���f�b�N�X���擾
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
					If Focus_Ctl_Ok_Lst_Idx > 0 Then
						Index_Wk = Focus_Ctl_Ok_Lst_Idx
					End If
					
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
		Dim SubRow As Short
		
		bolDsp = False
		bolAllChk = False
		RtnCode = -1
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'�{�f�B��
			'Dsp_Body_Inf�̍s�m�n���擾
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
				'�ŏI�����s�̏ꍇ
				'���͉\�ȍŏ��̃C���f�b�N�X���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
					'�\������Ă���ŏI�s�̏ꍇ
					'���͉\�ȍŌ�̃C���f�b�N�X���擾
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�w�b�_������{�f�B���ֈړ�����ꍇ
				
				''' === 20060824 === INSERT S
				'�r���������������������������������������������������������r
				'ͯ�ޕ�����
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
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
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            '���݂�÷�ď�̑I����Ԃ��擾
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190813 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190813 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '�P�����ڂ�I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '20190813 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(0, 1)
                    '20190813 CHG END
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
                        '20190813 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190813 CHG END
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
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'���݂̺��۰ق�÷���ޯ���̏ꍇ
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Dim SubRow As Short
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            '���݂�÷�ď�̑I����Ԃ��擾
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190813 CHG START
            '         Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            '         'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190813 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '�l���������l�̏ꍇ
                    '�ŏI������I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '20190813 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1, 1)
                    '20190813 CHG END
                Else
                    '�l���������l�ȊO�̏ꍇ
                    '�P���ڂ�I������
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '20190813 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(1, 1)
                    '20190813 CHG END
                End If
			Else
				If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
					'�I���J�n�ʒu����ԉE�̏ꍇ
					
					'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
					
					If pm_Move_Flg = False Then
						If pm_Dsp_Sub_Inf.Ctl.Name <> pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_CLDDT.Tag)).Ctl.Name Then
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							SubRow = pm_All.Dsp_Base.Dsp_Body_Cnt - pm_All.Dsp_Sub_Inf(CShort(pm_Dsp_Sub_Inf.Ctl.Tag)).Detail.Body_Index + 1
							'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
							Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - (pm_All.Dsp_Base.Body_Col_Cnt * SubRow) - 5), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						End If
					End If
				Else
					'�I���J�n�ʒu����ԉE�łȂ��ꍇ
					
					'�P�E�̂P�����擾
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)
					
					If Str_Wk = "" Then
						'���̂P�����Ȃ��ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                            '�l���������l�̏ꍇ
                            '��ԉE�ֈړ����I���Ȃ���Ԃ�
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '20190813 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                            '20190813 CHG END
                        Else
							'�l���������l�ȊO�̏ꍇ
							If Act_SelLength = 0 Then
                                '�ړ��O�̑I�𕶎������Ȃ��ꍇ
                                '��ԉE�ֈړ����I���Ȃ���Ԃ�
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '20190813 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                                '20190813 CHG END
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
							
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                            '20190813 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Next_SelStart, Wk_SelLength)
                            '20190813 CHG END
                        End If
					End If
				End If
				
			End If
		Else
			'���݂̺��۰ق�÷���ޯ���̈ȊO�ꍇ
			'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
		F_Set_Right_Next_Focus = Rtn_Chk
		
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
		Dim SubRow As Short
		
		
		'�ړ��t���O������
		pm_Move_Flg = False
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'���ו��̏ꍇ
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'���݂̍��ڂɗ񕪂������Ɉړ��������ޯ�������߂�
				Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				'            If Next_Index > pm_All.Dsp_Base.Foot_Fst_Idx - 1 Then
				If Next_Index > pm_All.Dsp_Base.Foot_Fst_Idx - 5 Then
					'���ڐ��𒴂����ꍇ
					'�ŏI�s�̐擪���ڈȊO�̏ꍇ
					If Trg_Index <> pm_All.Dsp_Base.Foot_Fst_Idx - pm_All.Dsp_Base.Body_Col_Cnt + 3 Then
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 5), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						
					End If
					Exit Do
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Trg_Index + pm_All.Dsp_Base.Body_Col_Cnt).Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_All.Dsp_Sub_Inf(Trg_Index + pm_All.Dsp_Base.Body_Col_Cnt).Detail.Focus_Ctl = False Then
					'�ŏI�f�[�^�s�̏ꍇ
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					SubRow = pm_All.Dsp_Base.Dsp_Body_Cnt - pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index + 1
					If Trg_Index <> pm_All.Dsp_Base.Foot_Fst_Idx - (pm_All.Dsp_Base.Body_Col_Cnt * SubRow) + 3 Then
						'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - (pm_All.Dsp_Base.Body_Col_Cnt * SubRow) - 5), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
					End If
					Exit Do
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
						'���ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
						'��ʂ̓��e��ޔ�
						Call CF_Body_Bkup(pm_All)
						'�ړ��\�s����ԏ�ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
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
						'���ׂ̈�ԏ�̓��ꍀ�ڂ̲��ޯ�����擾
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'������۰ق̏ꍇ
								'�ړ������ŏI��
								pm_Move_Flg = False
								Exit Do
							Else
								'������۰قłȂ��ꍇ
								'���ꍀ�ڂ̂P��납��
								'�P�O�̍��ڂ�
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'���͉\�ȍŏ��̃C���f�b�N�X���擾
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'���͉\�ȍŏ��̍��ڂ̂P��납��
								'�P�O�̍��ڂ�
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
							Else
								'�w�b�_���̍Ō�̍��ڂ̂P��납��
								'�P�O�̍��ڂ�
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
								
							End If
						End If
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
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'�O��Ɠ����`�F�b�N���e�̏ꍇ
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
		Else
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'�K�{���͂Ŗ�����
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'�`�F�b�N�n�j�Ƃ���
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
									'�O��Ɠ����`�F�b�N���e�̏ꍇ
									'�`�F�b�N�G���[�Ƃ���
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'���b�Z�[�W�o�͂Ȃ�
									pm_Msg_Flg = False
									'�ړ��n�j
									pm_Move = True
								Else
									'�O��ƈقȂ�`�F�b�N���e�̏ꍇ
									'�`�F�b�N�G���[�Ƃ���
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
							If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
								'�O��Ɠ����`�F�b�N���e�̏ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�O��ƈقȂ�`�F�b�N���e�̏ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'�`�F�b�N�n�j�Ƃ���
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'�`�F�b�N�G���[�Ƃ���
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							End If
						Case CHK_ERR_ELSE
							'���̑��G���[��
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'�P�x�������͈ȊO�`�F�b�N�����Ă��Ȃ��ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'���b�Z�[�W�o�͂Ȃ�
								pm_Msg_Flg = False
								'�ړ��n�j
								pm_Move = True
							Else
								'�P�x�ł������̓`�F�b�N�����Ă���ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'���b�Z�[�W�o�͂���
								pm_Msg_Flg = True
								'�ړ��m�f
								pm_Move = False
							End If
							
						Case CHK_ERR_ELSE
							'���̑��G���[��
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
						Case CHK_ERR_ELSE
							'���̑��G���[��
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'���b�Z�[�W�o�͂���
							pm_Msg_Flg = True
							'�ړ��m�f
							pm_Move = False
							
					End Select
					
			End Select
			
		End If
		
		'�`�F�b�N�֐��ďo���������N���A
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HD_CLDDT
	'   �T�v�F  �o�^�N��������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_CLDDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_CLDMTA
		Dim Mst_Inf_Clr As TYPE_DB_CLDMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		Dim Trg_Index As Short
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_CLDDT = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		Call DB_CLDMTA_Clear(Mst_Inf)
		Rtn_Cd = F_GET_BD_DATA(pm_All)
		
		If Rtn_Cd = 0 Then
			'�o�͂ł��閾�׃f�[�^������
			
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Chk_Dsp_Sub_Inf, pm_All)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(pm_Chk_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
			
			Retn_Code = CHK_ERR_ELSE
			F_Chk_HD_CLDDT = Retn_Code
			
			Exit Function
		Else
			'���̓R���g���[���̎g�p�ې���
			Call F_Set_Inp_Item_Focus_Ctl(False, pm_All)
			'���ׂ���ʂɕҏW
			Trg_Index = CShort(FR_SSSMAIN.HD_CLDDT.Tag)
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
			
			'���ו��Ƀt�H�[�J�X�Z�b�g
			'����̫����ʒu����E�ֈړ�
			Call F_Set_Right_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index), True, pm_All, True)
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
		
		F_Chk_HD_CLDDT = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_BD_CLDDT
	'   �T�v�F  ���ו�������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_CLDDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_CLDMTA
		Dim Mst_Inf_Clr As TYPE_DB_CLDMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_BD_CLDDT = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		Call DB_CLDMTA_Clear(Mst_Inf)
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgCLDMT51_E_006
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgCLDMT51_E_001
			Else
				'���͂��ꂽ�R�[�h��   1�C9�ȊO�̏ꍇ�̓G���[
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) <> 1 And CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) <> 9 Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgCLDMT51_E_001
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
		
		F_Chk_BD_CLDDT = Retn_Code
		
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
		
		'���͕K�{���ځi�o�^�N���j�������͂łȂ����`�F�b�N
		If F_Chk_Input_CTLCD(pm_All) Then
			bolChk = True
			'���׍s�ɖ����͍��ڂ����邩�`�F�b�N
		ElseIf F_Chk_All_Input(pm_All) Then 
			bolChk = True
		End If
		
		F_Chk_CM_Execute = bolChk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_Input_CTLCD
	'   �T�v�F  ���͕K�{���ځi�o�^�N���j�������͂łȂ�������
	'   �����F  pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Input_CTLCD(ByRef pm_All As Cls_All) As Boolean
		Dim bolAll As Boolean
		Dim Err_Cd As String
		Dim Dsp_Value As Object
		
		'������
		bolAll = False
		Err_Cd = ""
		
		With FR_SSSMAIN
			'���͕K�{���ځi�o�^�N���j�������͂Ȃ�G���[
			If Trim(.HD_CLDDT.Text) = "" Then
				
				Err_Cd = gc_strMsgCLDMT51_E_006
				'���b�Z�[�W�o��
				Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
				bolAll = True
				
			End If
			
			'�o�^�N�����ύX����Ă����ꍇ�G���[
			'���ݓ��e
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(.HD_CLDDT.Tag)))
			'�O����e�Ɣ�r
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag).Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If pm_All.Dsp_Sub_Inf(CInt(.HD_CLDDT.Tag)).Detail.Bef_Value <> Dsp_Value Then
				
				Err_Cd = gc_strMsgCLDMT51_E_010
				'���b�Z�[�W�o��
				Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
				bolAll = True
				
			End If
			
		End With
		
		F_Chk_Input_CTLCD = bolAll
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_All_Input
	'   �T�v�F  ���׍s�ɖ����͍��ڂ����邩����
	'   �����F  pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_All_Input(ByRef pm_All As Cls_All) As Boolean
		
		Dim bolAll As Boolean
		Dim Err_Cd As String
		Dim I As Short
		Dim Trg_Index As Short
		
		'������
		bolAll = False
		Err_Cd = ""
		
		If Trim(FR_SSSMAIN.HD_UPDKB.Text) = "" Then
			'���׍s�����݂��Ȃ��ꍇ�G���[
			Err_Cd = gc_strMsgCLDMT51_E_008
			'���b�Z�[�W�o��
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			bolAll = True
		Else
			'���׍s�ɖ����͍��ڂ�����ꍇ�G���[
			With FR_SSSMAIN
				For I = 0 To 30 Step 1
					If Trim(.BD_CLDT(I).Text) = "" Then
					ElseIf Trim(.BD_CLDHLKB(I).Text) = "" Or Trim(.BD_SLDKB(I).Text) = "" Or Trim(.BD_DTBKDKB(I).Text) = "" Or Trim(.BD_PRDKDKB(I).Text) = "" Or Trim(.BD_BNKKDKB(I).Text) = "" Then 
						
						Err_Cd = gc_strMsgCLDMT51_E_006
						'���b�Z�[�W�o��
						Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
						
						Select Case True
							Case Trim(.BD_CLDHLKB(I).Text) = ""
								'�u�j�Փ��v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_CLDHLKB(I).Tag)
							Case Trim(.BD_SLDKB(I).Text) = ""
								'�u�c�Ɠ��敪�v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_SLDKB(I).Tag)
							Case Trim(.BD_DTBKDKB(I).Text) = ""
								'�u�����ғ��敪�v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_DTBKDKB(I).Tag)
							Case Trim(.BD_PRDKDKB(I).Text) = ""
								'�u���Y�ғ��敪�v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_PRDKDKB(I).Tag)
							Case Trim(.BD_BNKKDKB(I).Text) = ""
								'�u��s�ғ��敪�v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_BNKKDKB(I).Tag)
						End Select
						
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Err_Status = ERR_NOT_INPUT
						
						'������ړ��Ȃ�
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
						'�I����Ԃ̐ݒ�i�����I���j
						Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
						'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
						Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)
						
						bolAll = True
						Exit For
						
					End If
				Next I
				
				If bolAll = True Then
					F_Chk_All_Input = bolAll
					Exit Function
				End If
				
				'�s���ȃR�[�h�����͂��ꂽ�ꍇ�G���[
				For I = 0 To 30 Step 1
					If Trim(.BD_CLDT(I).Text) = "" Then
					ElseIf (Trim(.BD_CLDHLKB(I).Text) <> "1" And Trim(.BD_CLDHLKB(I).Text) <> "9") Or (Trim(.BD_SLDKB(I).Text) <> "1" And Trim(.BD_SLDKB(I).Text) <> "9") Or (Trim(.BD_DTBKDKB(I).Text) <> "1" And Trim(.BD_DTBKDKB(I).Text) <> "9") Or (Trim(.BD_PRDKDKB(I).Text) <> "1" And Trim(.BD_PRDKDKB(I).Text) <> "9") Or (Trim(.BD_BNKKDKB(I).Text) <> "1" And Trim(.BD_BNKKDKB(I).Text) <> "9") Then 
						
						Err_Cd = gc_strMsgCLDMT51_E_001
						'���b�Z�[�W�o��
						Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
						
						Select Case True
							Case (Trim(.BD_CLDHLKB(I).Text) <> "1" And Trim(.BD_CLDHLKB(I).Text) <> "9")
								'�u�j�Փ��v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_CLDHLKB(I).Tag)
							Case (Trim(.BD_SLDKB(I).Text) <> "1" And Trim(.BD_SLDKB(I).Text) <> "9")
								'�u�c�Ɠ��敪�v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_SLDKB(I).Tag)
							Case (Trim(.BD_DTBKDKB(I).Text) <> "1" And Trim(.BD_DTBKDKB(I).Text) <> "9")
								'�u�����ғ��敪�v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_DTBKDKB(I).Tag)
							Case (Trim(.BD_PRDKDKB(I).Text) <> "1" And Trim(.BD_PRDKDKB(I).Text) <> "9")
								'�u���Y�ғ��敪�v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_PRDKDKB(I).Tag)
							Case (Trim(.BD_BNKKDKB(I).Text) <> "1" And Trim(.BD_BNKKDKB(I).Text) <> "9")
								'�u��s�ғ��敪�v�Ƀt�H�[�J�X�ݒ�
								'�������ޯ���擾
								Trg_Index = CShort(.BD_BNKKDKB(I).Tag)
						End Select
						
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Err_Status = ERR_NOT_INPUT
						
						'������ړ��Ȃ�
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
						'�I����Ԃ̐ݒ�i�����I���j
						Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
						'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
						Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)
						
						bolAll = True
						Exit For
						
					End If
				Next I
			End With
		End If
		
		F_Chk_All_Input = bolAll
	End Function
	
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
			Case FR_SSSMAIN.HD_CLDDT.Name
				'�o�^�N���ɂ���ʕ\��
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call F_Dsp_HD_CLDDT_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All, pm_Dsp_Sub_Inf.Detail.Body_Index)
				
				'        Case Else
				'            '���׍s�ɂ���ʕ\��
				'            '�������e�A�O����e��ޔ�
				'            Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
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
			Call F_Init_Cursor_Set(pm_All)
		End If
		
		'�������e�A�O����e��ޔ�
		Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_CLDDT_Inf
	'   �T�v�F  �o�^�N���ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'           pm_Index            :�z��v�f�ԍ�
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_CLDDT_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All, ByRef pm_Index As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim RtnCode As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'�o�^�N�����ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'===== 20060908 INSERT S ========
				'�t�H�[�J�X����
				Call F_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All, pm_Index)
				gv_bolCLDMT51_INIT = False
				
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			
			'��ʃ{�f�B��������
			'        Call F_Init_Clr_Dsp_Body(-1, pm_Dsp_Sub_Inf)
			
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Set_Focus_Ctl
	'   �T�v�F  �o�^�N���ɂ���ʕ\����̃t�H�[�J�X����
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'           pm_Index            :�z��v�f�ԍ�
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Focus_Ctl(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Index As Short) As Short
		
		Dim Trg_Index As Short
		Dim Fcs_Flg As Boolean
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) <> "" Then
			'�o�^�N������łȂ��ꍇ
			Fcs_Flg = True
		Else
			'�o�^�N������̏ꍇ
			Fcs_Flg = False
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
		
		
		'�r���������������������������������������������������������r
		'    '�t�H�[�J�X�ړ��̍��ڂ̂݃`�F�b�N
		'    If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True Then
		'�@��{���͓��e�̃`�F�b�N
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			Case FR_SSSMAIN.HD_CLDDT.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'�o�^�N��������
				Rtn_Chk = F_Chk_HD_CLDDT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
				'            Case Else
				'                '���ו��̃`�F�b�N���ꊇ���čs��
				'                '�����O����(�����֐��̑O�ŕK�{����)
				'                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'                '���ו�������
				'                Rtn_Chk = F_Chk_BD_CLDDT(pm_Dsp_Sub_Inf _
				''                                       , pm_Chk_Move_Flg _
				''                                       , pm_All)
				
		End Select
		'    End If
		
		If Rtn_Chk = CHK_OK Then
			pm_Chk_Move_Flg = True
		Else
			pm_Chk_Move_Flg = False
		End If
		'�d���������������������������������������������������������d
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
		
		'�o�^�N�������ďo
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
		
		'�֘A����
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'�`�F�b�N�n�j�ł���
			'�w�b�_���̃`�F�b�N�����߂Ă̏ꍇ
			'�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
			'        pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
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
		Dim intCnt As Short
		Dim intMoveFocus As Short
		Dim intErrRow As Short
		
		'2007/12/13 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		' === 20081001 === INSERT S - RISE)Izumi
		Dim bolTrn As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strHD_CLDDT As String '���t
		Dim strOPEID As String '�ŏI��Ǝ҃R�[�h
		Dim strCLTID As String '�N���C�A���g�h�c
		Dim strUOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim strUCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
		' === 20081001 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '�X�V���t
		Dim strWRTTM As String '�X�V����
		Dim strUWRTDT As String '�o�b�`�X�V���t
		Dim strUWRTTM As String '�o�b�`�X�V����
		'2007/12/13 add-end T.KAWAMUKAI
		
		F_Ctl_Upd_Process = 9
		
		' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		' === 20060808 === INSERT E
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		pv_intMeisaiCnt = 0
		
		'�{�f�B���̍ŏI���ڂ܂Ŋe���ڂ��������s��
		'    For intCnt = 0 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		For intCnt = 0 To 30
			
			'�֘A����
			intRet = F_Ctl_Body_RelChk(intCnt, pm_All, intMoveFocus, intErrRow)
			'�`�F�b�N�m�f
			If intRet <> CHK_OK Then
				F_Ctl_Upd_Process = intRet
			End If
			
		Next intCnt
		
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'Windows�ɏ�����Ԃ�
		'    DoEvents
		
		If gb_pageChange = True Then
			intRet = MsgBoxResult.Yes
		Else
			'�m�F���b�Z�[�W�\��
			intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_A_004, pm_All)
		End If
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		Select Case intRet
			Case MsgBoxResult.Yes
				' 2007/01/11  ADD START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
				If gb_CldUpdFlg = False Then
					gv_bolUpdFlg = False
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_012, pm_All)
					GoTo End_F_Ctl_Upd_Process
				End If
                ' 2007/01/11  ADD END
                '            '�{�^����\��
                '            FR_SSSMAIN.CM_Execute.Visible = False

                '2008/07/08 START ADD FNAP)YAMANE �A���[���F�r��-54
                '20190813 CHG START
                'Call CF_Ora_BeginTrans(gv_Oss_USR1)
                Call DB_BeginTrans(CON)
                '20190813 CHG END
                '2008/07/08 E.N.D ADD FNAP)YAMANE �A���[���F�r��-54
                ' === 20081001 === INSERT S - RISE)Izumi
                bolTrn = True
				' === 20081001 === INSERT E - RISE)Izumi
				
				' === 20081001 === DELETE S - RISE)Izumi
				''2007/12/13 add-str T.KAWAMUKAI �e�v���O�����̃��W���[���ŏ�������悤�ɕύX
				'            '�X�V���Ԏ擾
				'            Call PF_Get_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
				'
				'            '�X�V���ԃ`�F�b�N
				'            bolRet = MF_Chk_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
				'
				'            If bolRet = False Then
				''2007/12/27 upd-str M.SUEZAWA
				'''                intRet = MF_DspMsg(gc_strMsgCLDMT51_E_UPD)
				'                intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_UPD, pm_All)
				''2007/12/27 upd-end M.SUEZAWA
				'
				''2008/07/08 START ADD FNAP)YAMANE �A���[���F�r��-54
				''   [FOR UPDATE]���߂���������B�iABORT���������ߑ�p����j
				'                Call CF_Ora_RollbackTrans(gv_Oss_USR1)
				'                HAITA_FLG = 1
				''2008/07/08 E.N.D ADD FNAP)YAMANE �A���[���F�r��-54
				'                GoTo End_F_Ctl_Upd_Process
				'            End If
				''2007/12/13 add-end T.KAWAMUKAI
				' === 20081001 === DELETE E - RISE)Izumi
				
				' === 20081001 === INSERT S - RISE)Izumi �r������
				'�X�V�f�[�^�̓��t���擾
				strHD_CLDDT = FR_SSSMAIN.HD_CLDDT.Text
				strHD_CLDDT = CF_Get_Input_Ok_Item(CStr(strHD_CLDDT), pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_CLDDT.Tag)))
				
				For intCnt = 0 To pv_intMeisaiCnt - 1
					With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
						'�^�C���X�^���v�擾SQL�쐬
						strSQL = ""
						strSQL = strSQL & " SELECT "
						strSQL = strSQL & "     OPEID " '�ŏI��Ǝ҃R�[�h
						strSQL = strSQL & "    ,CLTID " '�N���C�A���g�h�c
						strSQL = strSQL & "    ,WRTTM " '�X�V����
						strSQL = strSQL & "    ,WRTDT " '�X�V���t
						strSQL = strSQL & "    ,UOPEID " '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
						strSQL = strSQL & "    ,UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
						strSQL = strSQL & "    ,UWRTTM " '�o�b�`�X�V����
						strSQL = strSQL & "    ,UWRTDT " '�o�b�`�X�V���t
						strSQL = strSQL & " FROM "
						strSQL = strSQL & "     CLDMTA "
						strSQL = strSQL & " WHERE "
						strSQL = strSQL & "CLDDT       = '" & CF_Ora_String(strHD_CLDDT & CLDMT51_CLDMTA_Update_Inf(intCnt + 1).CLDDT, 10) & "' " '���t
						strSQL = strSQL & " AND "
						strSQL = strSQL & "     DATKB = '1' "
						strSQL = strSQL & " FOR UPDATE "

                        'DB�A�N�Z�X
                        '20190814 CHG START
                        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                        Dim dt As DataTable = DB_GetTable(strSQL)
                        '20190814 CHG END
                        If CF_Ora_EOF(Usr_Ody) = True Then
                            '���[���o�b�N
                            '20190813 CHG START
                            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
                            Call DB_Rollback()
                            '20190813 CHG END
                            HAITA_FLG = CStr(1)
							bolTrn = False
							intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_UPD, pm_All)
							GoTo End_F_Ctl_Upd_Process
						End If
						
						'�X�V���ԃ`�F�b�N
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(.Bus_Inf.OPEID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "OPEID", "")) Or Trim(.Bus_Inf.CLTID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) Or Trim(.Bus_Inf.WRTTM) <> Trim(CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")) Or Trim(.Bus_Inf.WRTDT) <> Trim(CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")) Or Trim(.Bus_Inf.UOPEID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")) Or Trim(.Bus_Inf.UCLTID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")) Or Trim(.Bus_Inf.UWRTTM) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")) Or Trim(.Bus_Inf.UWRTDT) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")) Then
                            '���[���o�b�N
                            '20190813 CHG START
                            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
                            Call DB_Rollback()
                            '20190813 CHG END
                            HAITA_FLG = CStr(1)
							bolTrn = False
							intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_UPD, pm_All)
							GoTo End_F_Ctl_Upd_Process
						End If
					End With
				Next intCnt
				' === INSERT === UPDATE E - RISE)Izumi
				
				'�o�^����
				intRet = F_Update_Main(pm_All)
				If intRet <> 0 Then
					GoTo Err_F_Ctl_Upd_Process
				End If

                ' === 20081001 === INSERT S - RISE)Izumi
                '�R�~�b�g
                '20190816 CHG START
                'Call CF_Ora_CommitTrans(gv_Oss_USR1)
                Call DB_Commit()
                '20190816 CHG END
                bolTrn = False
				' === 20081001 === INSERT E - RISE)Izumi
				
			Case Else ' �߂�
				GoTo End_F_Ctl_Upd_Process
		End Select
		
		'���탁�b�Z�[�W�\��
		intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_005, pm_All)
		
		F_Ctl_Upd_Process = 0
		
End_F_Ctl_Upd_Process: 
		
		' === 20081001 === INSERT S - RISE)Izumi
		If bolTrn = True Then
            '���[���o�b�N
            '20190813 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '20190813 CHG END
            bolTrn = False
		End If
		' === 20081001 === INSERT E - RISE)Izumi
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'    '�{�^���\��
		'    FR_SSSMAIN.CM_Execute.Visible = True
		
		' === 20060808 === INSERT S - �G���^�[�L�[�A�łɂ��s��C���Q
		gv_bolUpdFlg = False
		
		'�L�[�t���O�����ɖ߂�
		gv_bolKeyFlg = False
		' === 20060808 === INSERT E
		
		Exit Function
		
Err_F_Ctl_Upd_Process: 
		
		GoTo End_F_Ctl_Upd_Process
		
	End Function
	
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
		ReDim CLDMT51_CLDMTA_Update_Inf(0)
		
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
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Item_Nm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm, pm_All)
						
						'���[�N�̢��ʍ��ڏ��ɉB�s���۰ق�����
						Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
						
						'���[�N�̢��ʍ��ڏ��ɢ��ʃ{�f�B����ҏW
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value, Dsp_Sub_Inf_Wk, pm_All)
						'��ʍ��ڏڍ׏���ݒ�
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Sub_Inf_Wk.Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail(Index_Wk_Col) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
								'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Sub_Inf_Wk.Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		Dim intCLDDT As Short
		Dim intCLDWKKB As Short
		Dim intCLDHLKB As Short
		Dim intSLDKB As Short
		Dim intBNKKDKB As Short
		Dim intPRDKDKB As Short
		Dim intDTBKDKB As Short
		Dim bolCheck As Boolean
		Dim bolNotInput As Boolean
		Dim strKbn As String
		
		'�e�����֐��Ɠ����ߒl
		Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrRow = pm_intRow
		pm_ErrIdx = CShort(FR_SSSMAIN.BD_CLDHLKB(pv_intMeisaiCnt).Tag)
		'    pm_ErrIdx = CInt(FR_SSSMAIN.BD_CLDHLKB(0).Tag)
		bolNotInput = False
		
		'�P�s�`�F�b�N
		intCLDDT = CShort(FR_SSSMAIN.BD_CLDT(pv_intMeisaiCnt).Tag)
		intCLDWKKB = CShort(FR_SSSMAIN.BD_WKKB(pv_intMeisaiCnt).Tag)
		intCLDHLKB = CShort(FR_SSSMAIN.BD_CLDHLKB(pv_intMeisaiCnt).Tag)
		intSLDKB = CShort(FR_SSSMAIN.BD_SLDKB(pv_intMeisaiCnt).Tag)
		intBNKKDKB = CShort(FR_SSSMAIN.BD_BNKKDKB(pv_intMeisaiCnt).Tag)
		intPRDKDKB = CShort(FR_SSSMAIN.BD_PRDKDKB(pv_intMeisaiCnt).Tag)
		intDTBKDKB = CShort(FR_SSSMAIN.BD_DTBKDKB(pv_intMeisaiCnt).Tag)
		'    intCLDDT = CInt(FR_SSSMAIN.BD_CLDT(0).Tag)
		'    intCLDWKKB = CInt(FR_SSSMAIN.BD_WKKB(0).Tag)
		'    intCLDHLKB = CInt(FR_SSSMAIN.BD_CLDHLKB(0).Tag)
		'    intSLDKB = CInt(FR_SSSMAIN.BD_SLDKB(0).Tag)
		'    intBNKKDKB = CInt(FR_SSSMAIN.BD_BNKKDKB(0).Tag)
		'    intPRDKDKB = CInt(FR_SSSMAIN.BD_PRDKDKB(0).Tag)
		'    intDTBKDKB = CInt(FR_SSSMAIN.BD_DTBKDKB(pm_intRow).Tag)
		
		bolCheck = False
		'�P�s�ɕK�v�ȏ�񂪓��͂���Ă���ꍇ�AOK
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDDT))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDWKKB))) <> "" Then
			bolCheck = True
			pv_bolMEISAI_INPUT = True
			pv_intMeisaiCnt = pv_intMeisaiCnt + 1
			
			'�J�����_�}�X�^���i�X�V�p�j�Ƀf�[�^����
			ReDim Preserve CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).CLDDT = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDDT)) '���t
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).CLDWKKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDWKKB)) '�j��
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).CLDHLKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDHLKB)) '�j��
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).SLDKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSLDKB)) '�c�Ɠ��敪
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).BNKKDKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKKDKB)) '��s�ғ��敪
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).PRDKDKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRDKDKB)) '���Y�ғ��敪
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).DTBKDKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDTBKDKB)) '�����ғ��敪
			
			'    Else
			'        Select Case True
			'            Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) = "" _
			''             And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCTLCD))) <> ""
			'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_CTLCD(1).Tag)
			'            Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" _
			''             And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCTLCD))) = ""
			'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_CTLCD(1).Tag)
			'        End Select
		End If
		
		'�P�s�S�������͂̏ꍇOK
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If bolCheck = False And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDDT))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDWKKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDHLKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSLDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKKDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRDKDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDTBKDKB))) = "" Then
			
			bolCheck = True
			bolNotInput = True
		End If
		
		If bolCheck = False Then
			Err_Cd = gc_strMsgCLDMT51_E_006
			GoTo F_Ctl_Body_RelChk_END
		End If
		
		'�����͂̏ꍇ�A��̃`�F�b�N�͖���
		If bolNotInput = True Then
			pv_bolInput_Bef_Row = False
			Rtn_Chk = CHK_OK
			GoTo F_Ctl_Body_RelChk_END
			'    Else
			'        '�����͈ȊO�őO�̍s�������͂̏ꍇ�G���[
			'        If pv_bolInput_Bef_Row = False Then
			'            Err_Cd = gc_strMsgCLDMT51_E_006
			'            pm_ErrRow = pm_intRow - 1
			'            GoTo F_Ctl_Body_RelChk_END
			'        End If
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
				
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		Dim strCLDDT As String
		Dim Trg_Index As Short
		
		On Error GoTo F_Update_Main_Err
		
		intRet = CHK_ERR_ELSE
		bolTrn = False
		
		'�X�V�����擾
		Call CF_Get_SysDt()
		
		' === 20081001 === DELETE S - RISE)Izumi
		'    '�g�����U�N�V�����̊J�n
		'    Call CF_Ora_BeginTrans(gv_Oss_USR1)
		'    bolTrn = True
		' === 20081001 === DELETE E - RISE)Izumi
		
		For intCnt = 1 To pv_intMeisaiCnt Step 1
			'�J�����_�}�X�^�X�V
			intRet = F_CLDMTA_Update(intCnt, pm_All)
			
			If intRet <> 0 Then
				GoTo F_Update_Main_Err
			End If
			
		Next intCnt
		
		'�ʎZ�ғ������Z�o�i�J�����_�}�X�^�X�V�j
		strCLDDT = FR_SSSMAIN.HD_CLDDT.Text
		strCLDDT = CF_Get_Input_Ok_Item(CStr(strCLDDT), pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_CLDDT.Tag))) & "01"
		'�X�g�A�h�L�b�N
		intRet = AE_Execute_PLSQL_CLC_SLSMDD(strCLDDT)
		
		If intRet <> 0 Then
			GoTo F_Update_Main_Err
		End If
		
		' === 20081001 === DELETE S - RISE)Izumi
		'    '�R�~�b�g
		'    Call CF_Ora_CommitTrans(gv_Oss_USR1)
		'    bolTrn = False
		' === 20081001 === DELETE E - RISE)Izumi
		
		intRet = CHK_OK
		
F_Update_Main_End: 
		
		' === 20081001 === DELETE S - RISE)Izumi
		'    If bolTrn = True Then
		'        '���[���o�b�N
		'        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		'        bolTrn = False
		'    End If
		' === 20081001 === DELETE E - RISE)Izumi
		
		F_Update_Main = intRet
		Exit Function
		
F_Update_Main_Err: 
		
		intRet = CHK_ERR_ELSE
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_CLDMTA_Update
	'   �T�v�F  �J�����_�}�X�^�X�V����
	'   �����F  pm_intCnt   : �z��ԍ�
	'           pm_All      : �S�\����
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_CLDMTA_Update(ByRef pm_intCnt As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim strHD_CLDDT As String
		
		On Error GoTo F_CLDMTA_Update_err
		
		F_CLDMTA_Update = 9
		
		strHD_CLDDT = FR_SSSMAIN.HD_CLDDT.Text
		strHD_CLDDT = CF_Get_Input_Ok_Item(CStr(strHD_CLDDT), pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_CLDDT.Tag)))
		
		'�J�����_�}�X�^�X�V
		strSQL = ""
		strSQL = strSQL & " UPDATE CLDMTA"
		strSQL = strSQL & "    SET CLDHLKB     = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).CLDHLKB, 1) & "' " '�j��
		strSQL = strSQL & "      , SLDKB       = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).SLDKB, 1) & "' " '�c�Ɠ��敪
		strSQL = strSQL & "      , BNKKDKB     = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).BNKKDKB, 1) & "' " '��s�ғ��敪
		strSQL = strSQL & "      , PRDKDKB     = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).PRDKDKB, 1) & "' " '���Y�ғ��敪
		strSQL = strSQL & "      , DTBKDKB     = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).DTBKDKB, 1) & "' " '�����ғ��敪
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
		strSQL = strSQL & "  WHERE CLDDT       = '" & CF_Ora_String(strHD_CLDDT & CLDMT51_CLDMTA_Update_Inf(pm_intCnt).CLDDT, 10) & "' " '���t
		strSQL = strSQL & "    AND DATKB      = '1' " '�폜�敪�F1�i�g�p���j
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_CLDMTA_Update_err
		End If
		
		F_CLDMTA_Update = 0
		
F_CLDMTA_Update_End: 
		Exit Function
		
F_CLDMTA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_007, pm_All, "F_CLDMTA_Update")
		GoTo F_CLDMTA_Update_End
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_GetTanka
	'   �T�v�F  PL/SQL���s����(�P���擾����)
	'   �����F�@Pin_strHINCD  : �Z�o�J�n��
	'   �ߒl�F�@0 : ���� 9: �ُ�
	'   ���l�F  �c�ƒʎZ�����Z�o�pPL/SQL(CLC_SLSMDD)�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_CLC_SLSMDD(ByVal pin_strCLDDT_S As String) As Short
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1(�Z�o�J�n��)
		Dim strPara2 As String '���Ұ�2(�ŏI��Ǝ҃R�[�h)
		Dim strPara3 As String '���Ұ�3(�N���C�A���g�h�c)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(4) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_CLC_SLSMDD = 9
		
		'��n���ϐ������ݒ�
		strPara1 = pin_strCLDDT_S
		strPara2 = CF_Ora_String(SSS_OPEID.Value, 8)
		strPara3 = CF_Ora_String(SSS_CLTID.Value, 5)
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		
		'PL/SQL�Ăяo��SQL
		strSQL = ""
		strSQL = strSQL & " DECLARE FC_STA NUMBER; "
		strSQL = strSQL & " BEGIN FC_STA := "
		strSQL = strSQL & " EDT_CLDMTA.CLC_SLSMDD(:P1,:P2,:P3); End; "
		'    strSQL = "BEGIN EDT_CLDMTA.CLC_SLSMDD(:P1,:P2,:P3); End;"
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_CLC_SLSMDD_END
		End If
		AE_Execute_PLSQL_CLC_SLSMDD = CHK_OK
		
AE_Execute_PLSQL_CLC_SLSMDD_END: 
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		
		
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
			'        Case CInt(FR_SSSMAIN.TX_Dummy.Tag)
			'            '�o�^
			'            Trg_Index = CInt(FR_SSSMAIN.MN_Execute.Tag)
			'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
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
		Wk_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
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
	'
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'    '   ���́F  Function F_Ctl_PageButton_Enabled
	'    '   �T�v�F  �O�y�[�W�E���y�[�W�g�p�ې���
	'    '   �����F�@pm_All           : �S�\����
	'    '   �ߒl�F�@�Ȃ�
	'    '   ���l�F
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_Ctl_PageButton_Enabled(pm_All As Cls_All) As Integer
	'
	'    Dim Trg_Index        As Integer
	'    Dim Wk_Index         As Integer
	'
	'    F_Ctl_PageButton_Enabled = 9
	'
	'    '�O��
	'    Trg_Index = CInt(FR_SSSMAIN.MN_Prev.Tag)
	''    If NowPageNum > MinPageNum Then
	'        pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
	''    Else
	''        pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
	''    End If
	'    '����
	'    Trg_Index = CInt(FR_SSSMAIN.MN_NextCm.Tag)
	''    If NowPageNum < MaxPageNum Then
	'        pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
	''    Else
	''        pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
	''    End If
	'
	'    '�O�Ń{�^��
	'    Trg_Index = CInt(FR_SSSMAIN.CM_PREV.Tag)
	'    Wk_Index = CInt(FR_SSSMAIN.MN_Prev.Tag)
	'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
	'    '���Ń{�^��
	'    Trg_Index = CInt(FR_SSSMAIN.CM_NEXTCm.Tag)
	'    Wk_Index = CInt(FR_SSSMAIN.MN_NextCm.Tag)
	'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
	'
	'    F_Ctl_PageButton_Enabled = 0
	'
	'End Function
	
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
			'LLLLL 20060912 INSERT S LLLLLLLLLLLLLLL
		ElseIf pm_Index = -2 Then 
			Wk_Index_S = 1
			Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
			pm_All.Dsp_Base.Head_Ok_Flg = False
			Wk_Mode = ITM_ALL_CLR
			
			'LLLLL 20060912 INSERT E LLLLLLLLLLLLLLL
		Else
			Wk_Index_S = pm_Index
			Wk_Index_E = pm_Index
			Wk_Mode = ITM_ALL_ONLY
		End If
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			
			With pm_All.Dsp_Sub_Inf(Index_Wk).Detail
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Item_Nm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Index = -2 And (.Item_Nm = "SYSDT" Or .Item_Nm = "HD_IN_TANCD" Or .Item_Nm = "HD_IN_TANNM") Then
				Else
					'���ʏ�����
					Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
					
					'�S�̏������̏ꍇ
					If Wk_Mode = ITM_ALL_CLR Then
						'�{�f�B���ȍ~�̍��ڂ�S̫����Ȃ��Ƃ���
						If Index_Wk > pm_All.Dsp_Base.Head_Lst_Idx Then
							Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
						End If
					End If
				End If
			End With
			
			'�r���������������������������������������������������������r
			'        '�ʏ�����
			'        Select Case Index_Wk
			'            '�o�^�N��
			'            Case CInt(FR_SSSMAIN.HD_CLDDT.Tag)
			'                Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(gb_dateYM, pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All, SET_FLG_DEF)
			''                If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value <> "0000/00" Then
			'                If Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value) <> "" Then
			'                    pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
			'                End If
			'
			'        End Select
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
		'�o�^�N���Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_CLDDT.Tag)
		
		'�o�^�N�����t�H�[�J�X����ɂ���
		Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		'̫����ړ�
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'���ڐF�ݒ�
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Init_Cursor_Set
	'   �T�v�F  ���ׂP�s�ڂւ̃t�H�[�J�X�ʒu�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Meisai_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'�r���������������������������������������������������������r
		'�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
		'�P�s�ڂ́u�j�Փ��v�Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.BD_CLDHLKB(0).Tag)
		
		'    '�j�Փ����t�H�[�J�X����ɂ���
		'    Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		'̫����ړ�
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'���ڐF�ݒ�
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'�d���������������������������������������������������������d
		
	End Function
	
	'
	'' === 20060825 === INSERT S
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'    '   ���́F  Function F_Set_NextRow_Status
	'    '   �T�v�F  �ŏI�s�̎��s�̏�Ԃ��ŏI�����s�ɐݒ�
	'    '   �����F�@pm_Dsp_Sub_Inf      :��ʍ��ڏ��
	'    '           pm_all              :�S�\����
	'    '   �ߒl�F�@�Ȃ�
	'    '   ���l�F
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_Set_NextRow_Status(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Boolean
	'
	'    Dim Bd_Index            As Integer
	'
	'    'pm_All.Dsp_Body_Inf�̍s�m�n���擾
	'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
	'
	'    If Bd_Index < pm_All.Dsp_Base.Dsp_Body_Cnt Then
	'        '���s�̉�ʃ{�f�B�s��Ԃ��ŏI�����s�ɐݒ�
	'        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index + 1).Status = BODY_ROW_STATE_DEFAULT Then
	'            pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index + 1).Status = BODY_ROW_STATE_LST_ROW
	'        End If
	'    End If
	'
	'End Function
	'' === 20060825 === INSERT E
	
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
                '20190813 CHG START
                '            Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                '            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '            Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '20190813 CHG END
                Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
				
				'���݂̒l���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
				
				Wk_EditMoji = ""
				
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		Dim retCode As Short
		
		intRet = CHK_OK
		
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
            '20190813 CHG START
            '         Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            '         'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190813 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'���݂̒l���擾
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
					
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'�l���������l�̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
						
					Else
						'�l���������l�ȊO�̏ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
						
					End If
					
					'�ҏW��̕�����\���`���ɕϊ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
					
					'�ҏW���SelStart������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                    '20190813 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    ''�ҏW���SelLength������
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                    '20190813 CHG END

                    ' === 20060801 === INSERT S - �P�����ڂœ��͌�Ƀt�H�[�J�X�ړ����Ȃ����Ƃւ̑Ή�
                    '���l���ړ��ʏ���
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
						
						'�����������菬�������Ɛݒ�l�������ꍇ
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
							'����̫����ʒu����E�ֈړ�
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'�ҏW��̕�����MAX�̏ꍇ
								'����̫����ʒu����E�ֈړ�
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
						
					Else
						'���l���ڈȊO
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                            '�ҏW��̕�����MAX�̏ꍇ
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '20190813 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            ''�ҏW���SelLength������
                            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 0)
                            '20190813 CHG END

                            '����̫����ʒu����E�ֈړ�
                            '                        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            intRet = F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
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
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
						
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'�󔒏�����̌��݂̕�����MAX�̏ꍇ�A�I�[�o�[�t���[
							
							'���l���ړ��ʏ���
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                                    '20190813 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    ''�ҏW���SelLength������
                                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                    '20190813 CHG END
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
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'�������Ő���������葽�����͂���Ă���ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'�����������菬�������Ɛݒ�l�������ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                        '20190813 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''�ҏW���SelLength������
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190813 CHG END

                        '�ҏW��̈ړ���𔻒�
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'�l���������l�̏ꍇ
							
							If Wk_SelStart >= Len(Wk_DspMoji) Then
								'�ҏW��̊J�n�ʒu����ԉE�̏ꍇ
								'���l���ړ��ʏ���
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
									'�����������菬�������Ɛݒ�l�������ꍇ
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									Else
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
											'�ҏW��̕�����MAX�̏ꍇ
											'����̫����ʒu����E�ֈړ�
											Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
										End If
									End If
								Else
									'���l���ڈȊO
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'�ҏW��̕�����MAX�̏ꍇ
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
							End If
						Else
							'�l���������l�ȊO�̏ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '�ҏW��̕�����MAX�̏ꍇ

                                '�ҏW���SelStart������
                                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '20190813 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                ''�ҏW���SelLength������
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 1)
                                '20190813 CHG END

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
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'�����������̏ꍇ
							'����������Ő���������葽�����͂���Ă���ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'���͕s��
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'�����������菬�������Ɛݒ�l�������ꍇ
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                        '20190813 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''�ҏW���SelLength������
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190813 CHG END

                        '�ҏW��̈ړ���𔻒�
                        If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
							'�ҏW��̊J�n�ʒu���Ō�̕����ȍ~�̏ꍇ
							'���l���ړ��ʏ���
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								
								'�����������菬�������Ɛݒ�l�������ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
									'����̫����ʒu����E�ֈړ�
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'�ҏW��̕�����MAX�̏ꍇ
										'����̫����ʒu����E�ֈړ�
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
								
							Else
								'���l���ڈȊO
								'                            If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'                                CF_Ctl_Item_KeyPress = F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								retCode = CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf))
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If retCode >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
									'�ҏW��̕�����MAX�̏ꍇ
									'����̫����ʒu����E�ֈړ�
									'                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									intRet = F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
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
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                                '20190813 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                ''�ҏW���SelLength������
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                '20190813 CHG END

                                '�폜�s��
                                Exit Function
							Case Else
								
						End Select
						
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								If Wk_DelMoji = "." Then
									'�폜�Ώۂ̕����������_�̏ꍇ
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
									'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
								
								'�폜���SelStart������
								Wk_SelStart = Act_SelStart
							Else
								'�����ҏW
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                        '20190813 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190813 CHG END

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
		
		CF_Ctl_Item_KeyPress = intRet
		
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
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'�E�N���b�N
			
			If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
				'�E�N���b�N�����R���g���[�����A�N�e�B�u�ȃR���g���[���ƈ�v
				'�J�[�\������p�e�L�X�g�Ƀt�H�[�J�X���ꎞ�I�ɑޔ�
				Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
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
                '20190813 DEL START
                'FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
                FR_SSSMAIN.SM_ShortCut.Show()
                '20190813 DEL END
                '۽�̫�������Ă̗}������
                pm_All.Dsp_Base.LostFocus_Flg = False
				' === 20060817 === DELETE S
				'����ƕs�����������̂ŁA�͂���
				'�i��F�߯�߱����ƭ��\����ԂŁ~���݉����ɂ��A���s���װ�����j
				'D            DoEvents
				' === 20060817 === DELETE E
			End If
			
			'�ΏۃR���g���[���̎g�p��
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'�t�H�[�J�X���ړ������ɖ߂�
			Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
			
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
		Call CF_Body_Dsp(pm_All)
		
		'��è�޺��۰ق����ו��̂ݐ���
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Act_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Act_Dsp_Sub_Inf.Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'���݂̍s���擾
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Act_Dsp_Sub_Inf.Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
	
	''======================= �ύX���� 2006.06.26 Start =================================
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'    '   ���́F  Function CF_Ctl_MN_Cmn_DE_Focus
	'    '   �T�v�F  ���j���[�̖��׏������^���׍폜�^���ו������̃t�H�[�J�X����
	'    '   �����F�@�Ȃ�
	'    '   �ߒl�F�@�Ȃ�
	'    '   ���l�F
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Row As Integer, pm_All As Cls_All) As Boolean
	'
	'    Dim Trg_Index               As Integer
	'    Dim Move_Flg                As Boolean
	'    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
	'    Dim Trg_Index_Same_Row      As Integer
	'
	'    '��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
	'    Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
	'
	'     If Trg_Index > 0 Then
	'        If Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) Then
	'        '�ړ��悪�����ꍇ
	'            If pm_Dsp_Sub_Inf.Ctl.TabStop = True Then
	'                '�I����Ԃ̐ݒ�i�����I���j
	'                Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
	'                '���ڐF�ݒ�
	'                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
	'
	'            Else
	'                '��Ԃ��ŏI�����s�̏ꍇ
	'                If pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Status = BODY_ROW_STATE_LST_ROW Then
	'                    '���s�̊Ǘ��R�[�h�̲��ޯ���擾
	'                    Trg_Index_Same_Row = CInt(FR_SSSMAIN.BD_CTLCD(pm_Row).Tag)
	'                    '̫����ړ�
	'                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index_Same_Row), pm_All)
	'                Else
	'                    '̫����ړ�
	'                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index - pm_All.Dsp_Base.Body_Col_Cnt), pm_All)
	'                End If
	'            End If
	'
	'        Else
	'            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
	'            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
	'        End If
	'
	'    Else
	'        '���͉\�ȍŏ��̃C���f�b�N�X���擾
	'        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
	'        If Focus_Ctl_Ok_Fst_Idx > 0 Then
	'            '���ꍀ�ڂ̂P�O����ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
	'            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
	'        End If
	'    End If
	'
	'End Function
	''======================= �ύX���� 2006.06.26 End =================================
	'
	'======================= �ύX���� 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_MN_ClearDE
	'   �T�v�F  ���j���[�̖��׏������̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		'
		'    Dim Bd_Index            As Integer
		'    Dim Row_Wk              As Integer
		'
		'    '��ʂ̓��e��ޔ�
		'    Call CF_Body_Bkup(pm_All)
		'
		'    'Dsp_Body_Inf�̍s�m�n���擾
		'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		'
		'    '���ʂ̖��׏�����
		'    If CF_Cmn_Ctl_MN_ClearDE(Bd_Index, pm_All) = True Then
		''�r���������������������������������������������������������r
		'        '�Ɩ��̏����l��ҏW
		'        Call F_Init_Dsp_Body(Bd_Index, pm_All)
		'
		'        '�s�m���̔ԏ���
		'        Call F_Edi_Saiban_No(pm_All)
		''�d���������������������������������������������������������d
		'
		'        '��ʕ\��
		'        'Call CF_Body_Dsp(pm_All)
		'        Call F_Body_Dsp(pm_All)
		'
		'        '���̉�ʂ̍s�Ɉړ�
		'        Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		'
		'        '�t�H�[�J�X����
		'        Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		'
		'    End If
		'
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
		'
		'    Dim Bd_Index            As Integer
		'    Dim Row_Inf_Max_S       As Integer
		'    Dim Row_Inf_Max_E       As Integer
		'    Dim Bd_Index_Wk         As Integer
		'    Dim Row_Wk              As Integer
		'    Dim Max_Row             As Integer
		'
		'    '��ʂ̓��e��ޔ�
		'    Call CF_Body_Bkup(pm_All)
		'
		'    'Dsp_Body_Inf�̍s�m�n���擾
		'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		'
		'    '���ʂ̖��׍폜
		'    Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		'
		''�r���������������������������������������������������������r
		'    '�y�[�W�̍Đݒ�
		'    If (UBound(pm_All.Dsp_Body_Inf.Row_Inf) Mod pm_All.Dsp_Base.Dsp_Body_Cnt) = 0 Then
		'        MaxPageNum = UBound(pm_All.Dsp_Body_Inf.Row_Inf) / pm_All.Dsp_Base.Dsp_Body_Cnt
		'
		'        If MaxPageNum < NowPageNum Then
		'            NowPageNum = MaxPageNum
		'        End If
		'    End If
		'
		'    '��ʃ{�f�B���̍Đݒ�
		'    If UBound(pm_All.Dsp_Body_Inf.Row_Inf) < pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum Then
		'        Max_Row = pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
		'        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row)
		'
		'        pm_All.Dsp_Body_Inf.Row_Inf(Max_Row).Item_Detail = pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail
		'    End If
		'
		'    '�Ώۍs�̏�Ԃ��Đݒ�
		'    For Bd_Index_Wk = 0 To pm_All.Dsp_Base.Dsp_Body_Cnt - 1
		'        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_LST_ROW Then
		''            pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_INPUT_WAIT
		'        End If
		'    Next
		''�d���������������������������������������������������������d
		'
		'    '��ʕ\��
		''    Call CF_Body_Dsp(pm_All)
		'    Call F_Body_Dsp(pm_All)
		'
		'    '���̉�ʂ̍s�Ɉړ�
		'    Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		'
		'    '�t�H�[�J�X����
		'    Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		'
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
		'
		'    Dim Bd_Index            As Integer
		'    Dim Bd_Index_Wk         As Integer
		'    Dim Ins_Bd_Index        As Integer
		'    Dim Row_Wk              As Integer
		'
		'    '��ʂ̓��e��ޔ�
		'    Call CF_Body_Bkup(pm_All)
		'
		'    'Dsp_Body_Inf�̍s�m�n���擾
		'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		'
		'    '���ʂ̖��ב}��
		'    If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
		'    '�r���������������������������������������������������������r
		'        '�Ɩ��̏����l��ҏW
		'        Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)
		'
		'        '�s�m���̔ԏ���
		'        Call F_Edi_Saiban_No(pm_All)
		'    '�d���������������������������������������������������������d
		'
		'        '�Ώۍs����ʂɕ\��
		'        Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)
		'
		'        '�ǉ��s�Ɉړ�
		'        Row_Wk = CF_Idx_To_Bd_Idx(Ins_Bd_Index, pm_All)
		'
		'        '�t�H�[�J�X����
		'        Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		'
		'    End If
		'
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
		'
		'    Dim Bd_Index            As Integer
		'    Dim Row_Inf_Max_S       As Integer
		'    Dim Row_Inf_Max_E       As Integer
		'    Dim Bd_Index_Wk         As Integer
		'    Dim Row_Wk              As Integer
		'
		'    '��ʂ̓��e��ޔ�
		'    Call CF_Body_Bkup(pm_All)
		'
		'    'Dsp_Body_Inf�̍s�m�n���擾
		'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		'
		'    '���ʂ̖��ו���
		'    If CF_Cmn_Ctl_MN_UnDoDe(pm_All, Row_Inf_Max_S, Row_Inf_Max_E) = True Then
		'    '�r���������������������������������������������������������r
		'        '�s��ǉ����ꂽ���
		'        '�����l��ǉ������s�ɑ΂��ă��[�v���łP�s���s��
		'        '�����ł̍s�́ADsp_Body_Inf�̍s�I�I
		'        For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
		'            Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
		'        Next
		'
		'        '�s�m���̔ԏ���
		'        Call F_Edi_Saiban_No(pm_All)
		'    '�d���������������������������������������������������������d
		'
		'        '��ʕ\��
		'        'Call CF_Body_Dsp(pm_All)
		'        Call F_Body_Dsp(pm_All)
		'
		'        '���̉�ʂ̍s�Ɉړ�
		'        Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		'
		'        '�t�H�[�J�X����
		'        Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		'
		'    End If
		'
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
        '20190813 CHG START
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '20190813 CHG END
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		'���݂̒l���擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		
		'�G���[�t���O�𗎂Ƃ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Err_Status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
		
		'��ݼ޲���Ă��N�������ɕҏW
		Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)

        '�ҏW���SelStart������
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190813 CHG START
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
        ''�ҏW���SelLength������
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
        '20190813 CHG END

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
        '20190813 DEL START
        'FR_SSSMAIN.PrintForm()
        '20190813 CHG END
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	'2007/12/13 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function PF_Get_UWRTDTTM
	'   �T�v�F  �X�V���t���Ԏ擾����
	'   �����F  pot_strWRTDT            : �X�V���t
	'           pot_strWRTTM            : �X�V����
	'           pot_strUWRTDT           : �o�b�`�X�V���t
	'           pot_strUWRTTM           : �o�b�`�X�V����
	'           pin_intIDX              : �g�p���Ȃ�
	'   �ߒl�F  0 : ����I��  9 : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function PF_Get_UWRTDTTM(ByRef pot_strWRTDT As String, ByRef pot_strWRTTM As String, ByRef pot_strUWRTDT As String, ByRef pot_strUWRTTM As String, Optional ByRef pin_intIDX As Short = 0) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		
		'2007/12/27 upd-str M.SUEZAWA
		'''2007/12/19 add-str T.KAWAMUKAI
		''    Dim strHD_CLDDT    As String
		''    Dim strHD_BD_CLDT    As String
		'''2007/12/19 add-end T.KAWAMUKAI
		Dim strHD_DT As String
		'2007/12/27 upd-end M.SUEZAWA
		
		On Error GoTo PF_Get_UWRTDTTM_ERR
		
		PF_Get_UWRTDTTM = 9
		
		'2007/12/27 upd-str M.SUEZAWA
		'''    strHD_CLDDT = Trim(FR_SSSMAIN.HD_CLDDT.Text)
		'''    strHD_BD_CLDT = Trim(FR_SSSMAIN.BD_CLDT(0).Text)
		''''2007/12/27 upd-str T.KAWAMUKAI
		'''    strHD_BD_CLDT = "/" & strHD_BD_CLDT
		''''2007/12/27 upd-end T.KAWAMUKAI
		''''''''    strHD_CLDDT = CF_Get_Input_Ok_Item(CStr(strHD_CLDDT), pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag))
		''''''    strHD_CLDDT = CF_Get_Input_Ok_Item(CStr(strHD_CLDDT), CStr(strHD_BD_CLDT))
		
		strHD_DT = Replace(Trim(FR_SSSMAIN.HD_CLDDT.Text), "/", "") & "01"
		'2007/12/27 upd-end M.SUEZAWA
		
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "   WRTDT, "
		strSQL = strSQL & "   WRTTM, "
		strSQL = strSQL & "   UWRTDT, "
		strSQL = strSQL & "   UWRTTM "
		strSQL = strSQL & " FROM "
		strSQL = strSQL & "   CLDMTA "
		strSQL = strSQL & " WHERE "
		'2007/12/27 upd-str M.SUEZAWA
		'''    strSQL = strSQL & "   CLDDT = '"
		''''2007/12/19 upd-str T.KAWAMUKAI
		''''''    strSQL = strSQL & FR_SSSMAIN.BD_CLDT(0).Text
		''''''    strSQL = strSQL & CF_Ora_String(strHD_CLDDT & CLDMT51_CLDMTA_Update_Inf(0).CLDDT, 10)
		'''    strSQL = strSQL & strHD_CLDDT & strHD_BD_CLDT & "'"
		''''2007/12/19 upd-end T.KAWAMUKAI
		strSQL = strSQL & "   CLDDT = '" & strHD_DT & "'"
		'2007/12/27 upd-end M.SUEZAWA
		
		'2008/07/08 START ADD FNAP)YAMANE �A���[���F�r��-54
		'���b�N����
		strSQL = strSQL & "          FOR UPDATE"
		'2008/07/08 E.N.D ADD FNAP)YAMANE �A���[���F�r��-54
		
		'// ������
		pot_strWRTDT = ""
		pot_strWRTTM = ""
		pot_strUWRTDT = ""
		pot_strUWRTTM = ""

        '20190814 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '20190814 CHG END

        If CF_Ora_EOF(Usr_Ody) = True Then
			GoTo PF_Get_UWRTDTTM_END
		End If
		
		'�f�[�^�̃^�C���X�^���v�ޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_strWRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�X�V���t
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_strWRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�X�V����
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_strUWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") '�o�b�`�X�V���t
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_strUWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") '�o�b�`�X�V����
		
		PF_Get_UWRTDTTM = 0
		
		
PF_Get_UWRTDTTM_END: 
		
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
PF_Get_UWRTDTTM_ERR: 
		
		GoTo PF_Get_UWRTDTTM_END
		
	End Function
    '2007/12/13 add-end T.KAWAMUKAI

    '���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������

    '20190813 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Set_Frm_IN_TANCD
    '   �T�v�F  ���͒S���ҕҏW
    '   �����F�@pm_Form        :�t�H�[��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object

        With pm_Form
            '���͒S���҃R�[�h
            'UPGRADE_ISSUE: Control HD_IN_TANCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Trg_Index = CShort(.HD_IN_TANCD.Tag)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)

            '���͒S���Җ�
            'UPGRADE_ISSUE: Control HD_IN_TANNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Trg_Index = CShort(.HD_IN_TANNM.Tag)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
        End With

    End Function
    '20190813 ADD END
End Module