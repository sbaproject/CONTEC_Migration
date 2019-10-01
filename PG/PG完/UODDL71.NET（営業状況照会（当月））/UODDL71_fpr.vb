Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(82) As String

    '���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
    '�r���������������������������������������������������������r
    'Invalid_string_refer_to_original_code
    Public gv_bolUODDL71_LF_Enable As Boolean 'LF�������s�t���O(False�F���s���Ȃ�)
	Public gv_bolKeyFlg As Boolean
	' === 20060801 === INSERT E
	Public gv_bolUODDL71_Active As Boolean 'Form_Active���s����
	Public gv_bolUODDL71_EndFlg As Boolean '�I���t���O

    'ADD 20190402  START saiki
    Public UODDL71_fpr As FR_SSSMAIN
    Public UODDL71 As FR_SSSMAIN1 = New FR_SSSMAIN1
    Public UODDL712 As FR_SSSMAIN2 = New FR_SSSMAIN2
    'ADD 20190402  END saiki

    'add start 20190805 kuwahara
    '�}�C�O���O�̓{�^���̃L���v�V�����ŉ�ʂ̐ؑւ𔻒f���Ă������߁A�}�C�O���ɔ�����ʐؑ֗p�̃t���O�ϐ���p��
    '�����l��1�ɂ��Ă����Ȃ��ƁA��x�ڂ̃N���b�N�ŁA������ʂ��ĕ\�����Ă��܂��B
    Public Judge1 As Integer = 1 '��/����ؑ֗p�ϐ� 0 = �󒍁@1������ �@
    Public Judge2 As Integer = 1 '�P��/�݌v�ؑ֗p�ϐ� 0 = �P���@1���݌v 
    'add end 20190805 kuwahara


    Public Structure UODDL71_TYPE_MEIMTC
		Dim DATKB As String '�폜�敪
		Dim MEICDA As String '�R�[�h�P
		Dim MEINMA As String '���̂P
	End Structure
	'���̃}�X�^���
	Public UODDL71_MEIMTC_Inf As UODDL71_TYPE_MEIMTC
	
	Public Structure UODDL71_TYPE_BMNSOU
		Dim BMNCD As String '����R�[�h
		Dim BMNNM As String '���喼��
		Dim BMNBR As Decimal '�����s��
		Dim TIKKB As String '�n��敪
		Dim TIKNM As String '�n�於��
		Dim TIKBR As Decimal '�n���s��
		Dim EIGYOCD As String '�c�Ə��R�[�h
		Dim EIGYONM As String '�c�Ə�����
		Dim EIGYOBR As Decimal '�c�Ə���s��
		Dim DSPORD As String '�\����
		Dim UODSU As Decimal '�󒍐���
		Dim UODKN As Decimal '�󒍋��z
		Dim SIKKN As Decimal '�d��
		Dim BAISA As Decimal '����
		Dim BSART As Decimal '������
	End Structure
	'����ʑ����\���
	Public UODDL71_BMNSOU_Inf() As UODDL71_TYPE_BMNSOU
	
	Public Structure UODDL71_TYPE_KISSOU
		Dim PCODE As String '�W�v�R�[�h
		' 2007/01/10  ADD START  KUMEDA
		Dim HGROUP As String '���i�W�v�O���[�v
		' 2007/01/10  ADD END
		'2007/10/12 FKS)minamoto ADD START
		Dim HGROUPNM As String '���i�W�v�O���[�v����
		'2007/10/12 FKS)minamoto ADD END
		Dim SYOHIN As String '���i
		Dim NAIGAICD As String '�����O�R�[�h
		Dim NAIGAINM As String '�����O
		Dim UODSU As Decimal '�󒍐���
		Dim UODKN As Decimal '�󒍋��z
		Dim SIKKN As Decimal '�d��
		Dim BAISA As Decimal '����
		Dim BSART As Decimal '������
	End Structure
	'�@��ʑ����\���
	Public UODDL71_KISSOU_Inf() As UODDL71_TYPE_KISSOU
	
	Public Structure UODDL71_TYPE_KISMEI
		Dim SYOHIN As String '���i�Q����
		Dim SYOHINRM As String '���i�Q����
		Dim BUNRUIA As String '���ނ`
		Dim BUNRUIB As String '���ނa
		Dim BUNRUIC As String '���ނb
		Dim UODSU_T As Decimal '�󒍐���
		Dim UODKN_T As Decimal '�󒍋��z
		Dim SIKKN_T As Decimal '�d��
		Dim BAISA_T As Decimal '����
		Dim BSART_T As Decimal '������
	End Structure
	'�@�햾�ו\���
	Public UODDL71_KISMEI_Inf() As UODDL71_TYPE_KISMEI
	
	'�y�[�W���
	Public MaxPageNum As Short '���ׂ̍ő�y�[�W��
	Public NowPageNum As Short '���ׂ̌��݂̃y�[�W��
	Public MinPageNum As Short '���ׂ̍ŏ��y�[�W��
	
	'����R�[�h
	Public gv_UODDL71_BMNCD As String
	'�n��敪
	Public gv_UODDL71_TIKCD As String
	'�c�Ə��R�[�h
	Public gv_UODDL71_EIGCD As String
	'�󒍁^����
	Public gv_UODDL71_JUC_URI As String '1:�󒍁A2:����
	'�����^����
	Public gv_UODDL71_GETU_KI As String '1:�����A2:����
	
	
	'�����̒l�̕ύX�t���O
	Private pv_JYOKEN_INPUT As Boolean
	
	'��ԍ�
	Private Const pc_COL_MEISYO As Short = 1 '����
	Private Const pc_COL_UODSU_T As Short = 2 '�󒍐�
	Private Const pc_COL_UODKN_T As Short = 3 '�󒍋��z
	Private Const pc_COL_SIKKN_T As Short = 4 '�d��
	Private Const pc_COL_BAISA_T As Short = 5 '����
	Private Const pc_COL_BSART_T As Short = 6 '������
	
	Private Const pc_Bmncd_Keycode As String = "069" '���̃}�X�^�̕���
	Private Const pc_Tikcd_Keycode As String = "060" '���̃}�X�^�̒n��敪
	Private Const pc_Eigcd_Keycode As String = "058" '���̃}�X�^�̉c�Ə�
	Private Const pc_Syohin_Keycode As String = "042" '���̃}�X�^�̏��i�Q
	Private Const pc_BunruiA_Keycode As String = "051" '���̃}�X�^�̕��ނ`
	Private Const pc_BunruiB_Keycode As String = "052" '���̃}�X�^�̕��ނa
	Private Const pc_BunruiC_Keycode As String = "053" '���̃}�X�^�̕��ނb
	'2007/10/12 FKS)minamoto ADD START
	Private Const pc_Hgroup_Keycode As String = "091" '���̃}�X�^�̏��i�W�v�O���[�v����
	'2007/10/12 FKS)minamoto ADD END
	
	Public Const gc_Sum_Text_Kei As String = "�@�@�@�@�v"
	Public Const gc_Sum_Text_Syokei As String = "�@�@���v"
	Public Const gc_Sum_Text_Gokei As String = "�@�@���v"
	' 2007/03/04  ADD START  KUMEDA
	Public Const DATE_GET_INF As String = "�f�[�^�ǂݍ��ݒ��ł��B" '�f�[�^�ǂݍ���
	' 2007/03/04  ADD END
	
	'//���אF�ݒ�
	Public Const COLOR_DTL_GREEN As Integer = &H80FF80 '�ΐF
	Public Const COLOR_DTL_LIGHTGREEN As Integer = &HC0FFC0 '���ΐF
	Public Const COLOR_DTL_BLUE As Integer = &HFFFFC0 '�F
	Public Const COLOR_DTL_LIGHTYELLOW As Integer = &H80FFFF '�����F
	
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
	'   ���́F  Function F_GET_FIRSTDAY
	'   �T�v�F  �������܂��͊������Ԃ�
	'   �����F�@pm_Kind         1:�������A2:�����
	'           pm_Date         ���
	'   �ߒl�F�@�������܂��͊����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_FIRSTDAY(ByVal pm_Kind As String, ByVal pm_Date As String) As String
		
		Dim Fst_Day As String
		Dim Wk_Year As String
		Dim Wk_Month As String
		
		Select Case pm_Kind
			Case "1"
				'������
				Fst_Day = Left(pm_Date, 6) & "01"
				
			Case "2"
				'�����
				Wk_Year = Left(pm_Date, 4)
				Wk_Month = Mid(pm_Date, 5, 2)
				
				'�P���`�R���̏ꍇ�A�O�N���v�Z
				If Wk_Month >= "01" And Wk_Month <= "03" Then
					Wk_Year = CStr(CShort(Wk_Year) - 1)
				End If
				
				Fst_Day = Wk_Year & "0401"
				
		End Select
		
		F_GET_FIRSTDAY = Fst_Day
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BMN_SOUKATU_JUC_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k�����i����ʑ����\�F�󒍁j
	'   �����F�@pm_Kind         1:�������A2:�����
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BMN_SOUKATU_JUC_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'�����J�n���̎擾
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     WAKU.BMNCD As BMNCD "
		strSQL = strSQL & "    ,WAKU.BMNNM As BMNNM "
		strSQL = strSQL & "    ,WAKU.BMNBR As BMNBR "
		strSQL = strSQL & "    ,WAKU.TIKKB As TIKKB "
		strSQL = strSQL & "    ,WAKU.TIKNM As TIKNM "
		strSQL = strSQL & "    ,WAKU.TIKBR As TIKBR "
		strSQL = strSQL & "    ,WAKU.EIGYOCD As EIGYOCD "
		strSQL = strSQL & "    ,WAKU.EIGYONM As EIGYONM "
		strSQL = strSQL & "    ,WAKU.EIGYOBR As EIGYOBR "
		strSQL = strSQL & "    ,WAKU.DSPORD58 As DSPORD "
		strSQL = strSQL & "    ,SUM(MAIN.UODSU) As UODSU "
		strSQL = strSQL & "    ,Round(SUM(MAIN.UODKN)) As UODKN "
		strSQL = strSQL & "    ,Round(SUM(MAIN.SIKKN)) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select  "
		strSQL = strSQL & "             JIGYOBU AS BMNCD "
		strSQL = strSQL & "            ,TIKKB "
		strSQL = strSQL & "            ,EIGYOCD "
		strSQL = strSQL & "            ,SUM(UODSU) AS UODSU "
		strSQL = strSQL & "            ,SUM(UODKN) AS UODKN "
		strSQL = strSQL & "            ,SUM(SIKKN) AS SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             JDNDLA "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             JDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "         And JDNDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             JIGYOBU "
		strSQL = strSQL & "            ,TIKKB "
		strSQL = strSQL & "            ,EIGYOCD "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "         Select Distinct "
		strSQL = strSQL & "             MEI58.MEIKBA As BMNCD "
		'''' UPD 2010/03/16  FKS) T.Yamamoto    Start    �A���[��CF09122201
		'    strSQL = strSQL & "            ,MEI69.MEINMA As BMNNM "
		strSQL = strSQL & "            ,MEI69.MEINMC As BMNNM "
		'''' UPD 2010/03/16  FKS) T.Yamamoto    End
		strSQL = strSQL & "            ,MEI69.MEISUA As BMNBR "
		strSQL = strSQL & "            ,BMN.TIKKB As TIKKB "
		strSQL = strSQL & "            ,MEI60.MEINMA As TIKNM "
		strSQL = strSQL & "            ,MEI60.MEISUA As TIKBR "
		strSQL = strSQL & "            ,BMN.EIGYOCD As EIGYOCD "
		strSQL = strSQL & "            ,MEI58.MEINMA As EIGYONM "
		strSQL = strSQL & "            ,MEI58.MEISUA As EIGYOBR "
		strSQL = strSQL & "            ,MEI58.DSPORD As DSPORD58 "
		strSQL = strSQL & "            ,MEI60.DSPORD As DSPORD60 "
		strSQL = strSQL & "            ,MEI69.DSPORD As DSPORD69 "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             ( "
		strSQL = strSQL & "                 Select * "
		strSQL = strSQL & "                 From MEIMTC "
		strSQL = strSQL & "                 Where KEYCD = '" & pc_Tikcd_Keycode & "' "
		strSQL = strSQL & "                 And   STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And   ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "             ) MEI60 "
		strSQL = strSQL & "            ,BMNMTA BMN "
		strSQL = strSQL & "            ,MEIMTC MEI69 "
		strSQL = strSQL & "            ,MEIMTC MEI58 "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             MEI58.KEYCD = '" & pc_Eigcd_Keycode & "' "
		strSQL = strSQL & "         And MEI58.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI58.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.KEYCD = '" & pc_Bmncd_Keycode & "' "
		strSQL = strSQL & "         And MEI69.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.MEICDA = MEI58.MEIKBA "
		strSQL = strSQL & "         And BMN.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And BMN.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And BMN.EIGYOCD = MEI58.MEICDA "
		strSQL = strSQL & "         And MEI60.MEICDA(+) = BMN.TIKKB "
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.BMNCD(+) = WAKU.BMNCD "
		strSQL = strSQL & " And MAIN.TIKKB(+) = WAKU.TIKKB "
		strSQL = strSQL & " And MAIN.EIGYOCD(+) = WAKU.EIGYOCD "
		strSQL = strSQL & " GROUP BY"
		strSQL = strSQL & "     WAKU.BMNCD "
		strSQL = strSQL & "    ,WAKU.BMNNM "
		strSQL = strSQL & "    ,WAKU.BMNBR "
		strSQL = strSQL & "    ,WAKU.TIKKB "
		strSQL = strSQL & "    ,WAKU.TIKNM "
		strSQL = strSQL & "    ,WAKU.TIKBR "
		strSQL = strSQL & "    ,WAKU.EIGYOCD "
		strSQL = strSQL & "    ,WAKU.EIGYONM "
		strSQL = strSQL & "    ,WAKU.EIGYOBR "
		strSQL = strSQL & "    ,WAKU.DSPORD58 "
		strSQL = strSQL & "    ,WAKU.DSPORD60 "
		strSQL = strSQL & "    ,WAKU.DSPORD69 "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     WAKU.DSPORD69 "
		strSQL = strSQL & "    ,WAKU.BMNCD "
		strSQL = strSQL & "    ,WAKU.DSPORD60 "
		strSQL = strSQL & "    ,TIKKB DESC "
		strSQL = strSQL & "    ,WAKU.DSPORD58 "
		strSQL = strSQL & "    ,WAKU.EIGYOCD "
		
		F_GET_BMN_SOUKATU_JUC_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BMN_SOUKATU_URI_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k�����i����ʑ����\�F����j
	'   �����F�@pm_Kind         1:�������A2:�����
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BMN_SOUKATU_URI_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'�����J�n���̎擾
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     WAKU.BMNCD As BMNCD "
		strSQL = strSQL & "    ,WAKU.BMNNM As BMNNM "
		strSQL = strSQL & "    ,WAKU.BMNBR As BMNBR "
		strSQL = strSQL & "    ,WAKU.TIKKB As TIKKB "
		strSQL = strSQL & "    ,WAKU.TIKNM As TIKNM "
		strSQL = strSQL & "    ,WAKU.TIKBR As TIKBR "
		strSQL = strSQL & "    ,WAKU.EIGYOCD As EIGYOCD "
		strSQL = strSQL & "    ,WAKU.EIGYONM As EIGYONM "
		strSQL = strSQL & "    ,WAKU.EIGYOBR As EIGYOBR "
		strSQL = strSQL & "    ,WAKU.DSPORD58 As DSPORD "
		strSQL = strSQL & "    ,SUM(MAIN.URISU) As UODSU "
		strSQL = strSQL & "    ,Round(SUM(MAIN.URIKN)) As UODKN "
		strSQL = strSQL & "    ,Round(SUM(MAIN.SIKKN)) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select  "
		strSQL = strSQL & "             JIGYOBU AS BMNCD "
		strSQL = strSQL & "            ,TIKKB "
		strSQL = strSQL & "            ,EIGYOCD "
		strSQL = strSQL & "            ,SUM(URISU) AS URISU "
		strSQL = strSQL & "            ,SUM(URIKN) AS URIKN "
		strSQL = strSQL & "            ,SUM(SIKKN) AS SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             UDNDLA "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             UDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "         And UDNDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             JIGYOBU "
		strSQL = strSQL & "            ,TIKKB "
		strSQL = strSQL & "            ,EIGYOCD "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "         Select Distinct "
		strSQL = strSQL & "             MEI58.MEIKBA As BMNCD "
		'''' UPD 2010/03/16  FKS) T.Yamamoto    Start    �A���[��CF09122201
		'    strSQL = strSQL & "            ,MEI69.MEINMA As BMNNM "
		strSQL = strSQL & "            ,MEI69.MEINMC As BMNNM "
		'''' UPD 2010/03/16  FKS) T.Yamamoto    End
		strSQL = strSQL & "            ,MEI69.MEISUA As BMNBR "
		strSQL = strSQL & "            ,BMN.TIKKB As TIKKB "
		strSQL = strSQL & "            ,MEI60.MEINMA As TIKNM "
		strSQL = strSQL & "            ,MEI60.MEISUA As TIKBR "
		strSQL = strSQL & "            ,BMN.EIGYOCD As EIGYOCD "
		strSQL = strSQL & "            ,MEI58.MEINMA As EIGYONM "
		strSQL = strSQL & "            ,MEI58.MEISUA As EIGYOBR "
		strSQL = strSQL & "            ,MEI58.DSPORD As DSPORD58 "
		strSQL = strSQL & "            ,MEI60.DSPORD As DSPORD60 "
		strSQL = strSQL & "            ,MEI69.DSPORD As DSPORD69 "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             ( "
		strSQL = strSQL & "                 Select * "
		strSQL = strSQL & "                 From MEIMTC "
		strSQL = strSQL & "                 Where KEYCD = '" & pc_Tikcd_Keycode & "' "
		strSQL = strSQL & "                 And   STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And   ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "             ) MEI60 "
		strSQL = strSQL & "            ,BMNMTA BMN "
		strSQL = strSQL & "            ,MEIMTC MEI69 "
		strSQL = strSQL & "            ,MEIMTC MEI58 "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             MEI58.KEYCD = '" & pc_Eigcd_Keycode & "' "
		strSQL = strSQL & "         And MEI58.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI58.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.KEYCD = '" & pc_Bmncd_Keycode & "' "
		strSQL = strSQL & "         And MEI69.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI69.MEICDA = MEI58.MEIKBA "
		strSQL = strSQL & "         And BMN.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And BMN.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And BMN.EIGYOCD = MEI58.MEICDA "
		strSQL = strSQL & "         And MEI60.MEICDA(+) = BMN.TIKKB "
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.BMNCD(+) = WAKU.BMNCD "
		strSQL = strSQL & " And MAIN.TIKKB(+) = WAKU.TIKKB "
		strSQL = strSQL & " And MAIN.EIGYOCD(+) = WAKU.EIGYOCD "
		strSQL = strSQL & " GROUP BY"
		strSQL = strSQL & "     WAKU.BMNCD "
		strSQL = strSQL & "    ,WAKU.BMNNM "
		strSQL = strSQL & "    ,WAKU.BMNBR "
		strSQL = strSQL & "    ,WAKU.TIKKB "
		strSQL = strSQL & "    ,WAKU.TIKNM "
		strSQL = strSQL & "    ,WAKU.TIKBR "
		strSQL = strSQL & "    ,WAKU.EIGYOCD "
		strSQL = strSQL & "    ,WAKU.EIGYONM "
		strSQL = strSQL & "    ,WAKU.EIGYOBR "
		strSQL = strSQL & "    ,WAKU.DSPORD58 "
		strSQL = strSQL & "    ,WAKU.DSPORD60 "
		strSQL = strSQL & "    ,WAKU.DSPORD69 "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     WAKU.DSPORD69 "
		strSQL = strSQL & "    ,WAKU.BMNCD "
		strSQL = strSQL & "    ,WAKU.DSPORD60 "
		strSQL = strSQL & "    ,TIKKB DESC "
		strSQL = strSQL & "    ,WAKU.DSPORD58 "
		strSQL = strSQL & "    ,WAKU.EIGYOCD "
		
		F_GET_BMN_SOUKATU_URI_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_BMN_SOUKATU_JUC
	'   �T�v�F  �{�f�B���f�[�^�擾�i����ʑ����\�F�󒍁j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_BMN_SOUKATU_JUC(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki
		
		'�����r�p�k����
		strSQL = F_GET_BMN_SOUKATU_JUC_SQL(pm_Kind)
		
		'Ret_Value = F_GET_BD_DATA_BMN_SOUKATU(strSQL, pm_All)
		Ret_Value = F_GET_BD_DATA_BMN_SOUKATU2(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
        'UPGRADE_ISSUE: Control lab_exc �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'delete 20190325�@START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then

        'Call F_Ctl_LAB_EXC(pm_All)

        'End If
        'delete 20190325�@END saiki
        'ADD 20150710 END C2-20150708-01

        F_GET_BD_DATA_BMN_SOUKATU_JUC = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_BMN_SOUKATU_URI
	'   �T�v�F  �{�f�B���f�[�^�擾�i����ʑ����\�F����j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_BMN_SOUKATU_URI(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki

		
		'�����r�p�k����
		strSQL = F_GET_BMN_SOUKATU_URI_SQL(pm_Kind)
		
		'Ret_Value = F_GET_BD_DATA_BMN_SOUKATU(strSQL, pm_All)
		Ret_Value = F_GET_BD_DATA_BMN_SOUKATU2(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
        'UPGRADE_ISSUE: Control lab_exc �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'delete 20190325�@START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then

        'Call F_Ctl_LAB_EXC(pm_All)

        'End If
        'delete 20190327�@END saiki
        'ADD 20150710 END C2-20150708-01

        F_GET_BD_DATA_BMN_SOUKATU_URI = Ret_Value

    End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_BMN_SOUKATU
	'   �T�v�F  �{�f�B���f�[�^�擾�i����ʑ����\�j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_BMN_SOUKATU(ByVal pm_SQL As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim intRowCnt As Short
		Dim intBmnCnt As Short
		Dim intTikCnt As Short
		Dim BmnGokei() As UODDL71_TYPE_BMNSOU
		Dim TikGokei() As UODDL71_TYPE_BMNSOU
		Dim ZenGokei As UODDL71_TYPE_BMNSOU
		Dim Wk_BmnCd As String
		Dim Wk_TikCd As String
		
		On Error GoTo ERR_F_GET_BD_DATA_BMN_SOUKATU
		F_GET_BD_DATA_BMN_SOUKATU = -1
		
		' 2007/03/04  ADD START  KUMEDA
		Call FR_SSSMAIN.Ctl_MN_APPENDC_Click()
		Call CF_Set_Prompt(DATE_GET_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), pm_All)
		System.Windows.Forms.Application.DoEvents()
		' 2007/03/04  ADD END
		
		'������
		Err_Cd = ""
		Wk_BmnCd = ""
		Wk_TikCd = ""
		ReDim BmnGokei(0)
		ReDim TikGokei(0)
		
		'�����r�p�k����
		strSQL = pm_SQL
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'�擾�f�[�^�Ȃ�
			F_GET_BD_DATA_BMN_SOUKATU = 0
			Err_Cd = gc_strMsgUODDL71_E_002
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
			Exit Function
		Else
			
			intCnt = 0
			Do Until CF_Ora_EOF(Usr_Ody) = True
				'�擾�S���R�[�h���{�f�B���ޔ�
				intCnt = intCnt + 1
				'�s�ǉ�
				ReDim Preserve UODDL71_BMNSOU_Inf(intCnt)
				
				With UODDL71_BMNSOU_Inf(intCnt)
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "") '����R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "") '���喼��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "") '�n��敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.TIKNM = CF_Ora_GetDyn(Usr_Ody, "TIKNM", "") '�n�於��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "") '�c�Ə��R�[�h
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.EIGYONM = CF_Ora_GetDyn(Usr_Ody, "EIGYONM", "") '�c�Ə�����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.DSPORD = CF_Ora_GetDyn(Usr_Ody, "DSPORD", "") '�\����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.UODSU = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0) '�󒍐���
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.UODKN = CF_Ora_GetDyn(Usr_Ody, "UODKN", 0) '�󒍋��z
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.SIKKN = CF_Ora_GetDyn(Usr_Ody, "SIKKN", 0) '�d��
					.BAISA = .UODKN - .SIKKN '����
				End With
				
				'�����R�[�h
				Call CF_Ora_MoveNext(Usr_Ody)
			Loop 
			
			intRowCnt = 0
			intBmnCnt = 0
			intTikCnt = 0
			For intData = 1 To intCnt
				With UODDL71_BMNSOU_Inf(intData)
					'�O�f�[�^�̕���R�[�h�ƈقȂ�ꍇ
					If Wk_BmnCd <> .BMNCD Then
						'�ŏ��̒n��łȂ��ꍇ�A�O�̒n��̌v�s���쐬
						If Trim(Wk_TikCd) <> "" Then
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = gc_Sum_Text_Kei
								.BD_UODSU_T = TikGokei(intTikCnt).UODSU '�󒍐�
								.BD_UODKN_T = TikGokei(intTikCnt).UODKN '�󒍋��z
								.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '�d��
								.BD_BAISA_T = TikGokei(intTikCnt).BAISA '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'delete 20190325 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'delete 20190325 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'�󒍋��z
								'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'�d��
								'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'delete 20190325 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'����
								'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'������
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
									'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								Else
									'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'�ŏ��̕���łȂ��ꍇ�A�O�̕���̏��v�s���쐬
						If Trim(Wk_BmnCd) <> "" Then
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = gc_Sum_Text_Syokei
								.BD_UODSU_T = BmnGokei(intBmnCnt).UODSU '�󒍐�
								.BD_UODKN_T = BmnGokei(intBmnCnt).UODKN '�󒍋��z
								.BD_SIKKN_T = BmnGokei(intBmnCnt).SIKKN '�d��
								.BD_BAISA_T = BmnGokei(intBmnCnt).BAISA '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If
								
								'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
								'����
								'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'����
                                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'������
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								Else
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'����̃J�E���g
						intBmnCnt = intBmnCnt + 1
						'���升�v�v�Z�p
						ReDim Preserve BmnGokei(intBmnCnt)
						BmnGokei(intBmnCnt).BMNCD = .BMNCD '����R�[�h
						BmnGokei(intBmnCnt).BMNNM = .BMNNM '���喼��
						BmnGokei(intBmnCnt).UODSU = 0 '�󒍐���
						BmnGokei(intBmnCnt).UODKN = 0 '�󒍋��z
						BmnGokei(intBmnCnt).SIKKN = 0 '�d��
						BmnGokei(intBmnCnt).BAISA = 0 '����
						
						'�s�ǉ�
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'�s���ڏ��R�s�[
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = .BMNNM
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "1"
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .BMNCD
						
						'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
						'����
                        'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
					
					'�O�f�[�^�̒n��敪�ƈقȂ�ꍇ
					If Wk_TikCd <> .TIKKB Then
						'�ŏ��̒n��łȂ��ꍇ�A�O�̒n��̌v�s���쐬�i�O�f�[�^�̕���R�[�h�Ɠ����j
						If Trim(Wk_TikCd) <> "" And Wk_BmnCd = .BMNCD Then
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = gc_Sum_Text_Kei
								.BD_UODSU_T = TikGokei(intTikCnt).UODSU '�󒍐�
								.BD_UODKN_T = TikGokei(intTikCnt).UODKN '�󒍋��z
								.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '�d��
								.BD_BAISA_T = TikGokei(intTikCnt).BAISA '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If
								
								'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
								'����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'delete 20190325 END saiki
								Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'����
                                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'delete 20190325 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'delete 20190325 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								'������
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								Else
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    'delete 20190325 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    'delete 20190325 END saiki
									Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'���f�[�^�̒n��敪������ꍇ
						If Trim(.TIKKB) <> "" Then
							'�n��̃J�E���g
							intTikCnt = intTikCnt + 1
							'�n�捇�v�v�Z�p
							ReDim Preserve TikGokei(intTikCnt)
							TikGokei(intTikCnt).TIKNM = .TIKNM '�n�於��
							TikGokei(intTikCnt).UODSU = 0 '�󒍐���
							TikGokei(intTikCnt).UODKN = 0 '�󒍋��z
							TikGokei(intTikCnt).SIKKN = 0 '�d��
							TikGokei(intTikCnt).BAISA = 0 '����
							
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�@�@" & .TIKNM
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "2"
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .TIKKB
							
							'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
							'����
                            'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            'delete 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                            'delete 20190325 END saiki
							Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End If
					
					'�s�ǉ�
					intRowCnt = intRowCnt + 1
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
					'�s���ڏ��R�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
					
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�@�@�@�@" & .EIGYONM & .EIGYOCD
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "3"
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .EIGYOCD
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODSU_T = .UODSU '�󒍐�
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODKN_T = .UODKN '�󒍋��z
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_SIKKN_T = .SIKKN '�d��
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BAISA_T = .BAISA '����
					If .UODKN = 0 Then
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = 0
					Else
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(.BAISA / .UODKN * 100, 1) '������
					End If
					
					'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
					With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
						'����
                        'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'�󒍐�
                        'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'�󒍋��z
                        'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'�d��
                        'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'����
                        'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'������
						If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            'delete 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            'delete 20190325 END saiki
							Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						Else
                            'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            'delete 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            'delete 20190325 END saiki
							Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End With
					
					'�n�捇�v�v�Z
					If .TIKNM <> "" Then
						TikGokei(intTikCnt).UODSU = TikGokei(intTikCnt).UODSU + .UODSU '�󒍐���
						TikGokei(intTikCnt).UODKN = TikGokei(intTikCnt).UODKN + .UODKN '�󒍋��z
						TikGokei(intTikCnt).SIKKN = TikGokei(intTikCnt).SIKKN + .SIKKN '�d��
						TikGokei(intTikCnt).BAISA = TikGokei(intTikCnt).BAISA + .BAISA '����
					End If
					
					'�c�Ə����v�v�Z
					BmnGokei(intBmnCnt).UODSU = BmnGokei(intBmnCnt).UODSU + .UODSU '�󒍐���
					BmnGokei(intBmnCnt).UODKN = BmnGokei(intBmnCnt).UODKN + .UODKN '�󒍋��z
					BmnGokei(intBmnCnt).SIKKN = BmnGokei(intBmnCnt).SIKKN + .SIKKN '�d��
					BmnGokei(intBmnCnt).BAISA = BmnGokei(intBmnCnt).BAISA + .BAISA '����
					
					'���f�[�^�̑ޔ�
					Wk_BmnCd = .BMNCD
					Wk_TikCd = .TIKKB
				End With
			Next 
			
			'�n��敪������ꍇ�A�ŏI�̒n��̌v�s���쐬
			If Trim(Wk_TikCd) <> "" Then
				'�s�ǉ�
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'�s���ڏ��R�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					.MEISYO = gc_Sum_Text_Kei
					.BD_UODSU_T = TikGokei(intTikCnt).UODSU '�󒍐�
					.BD_UODKN_T = TikGokei(intTikCnt).UODKN '�󒍋��z
					.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '�d��
					.BD_BAISA_T = TikGokei(intTikCnt).BAISA '����
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
					End If
					
					'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
					'����
                    'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'�󒍐�
                    'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'�󒍋��z
                    'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    'delete 20190325 END saiki

					Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'�d��
					'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    'delete 20190325 END saiki

					Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'����
					'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    'delete 20190325 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'������
					If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
						'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					Else
						'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
				End With
			End If
			
			'�ŏI�̉c�Ə��̏��v�s���쐬
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = gc_Sum_Text_Syokei
				.BD_UODSU_T = BmnGokei(intBmnCnt).UODSU '�󒍐�
				.BD_UODKN_T = BmnGokei(intBmnCnt).UODKN '�󒍋��z
				.BD_SIKKN_T = BmnGokei(intBmnCnt).SIKKN '�d��
				.BD_BAISA_T = BmnGokei(intBmnCnt).BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				'����
				'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'�󒍐�
				'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'�󒍋��z
				'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'�d��
				'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'����
				'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'������
				If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
					'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				Else
					'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				End If
			End With
			
			'�S�Ѝs�̍쐬
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�S��"
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "99"
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = "Z"
			
			'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
			'����
			'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

            'delete 20190325 START saiki
            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
            'delete 20190325 END saiki
			Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			
			'�S�З��̎��ƕ����v�s�̍쐬
			For intData = 1 To intBmnCnt
				'�s�ǉ�
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'�s���ڏ��R�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					.DIVISION = "1"
					.DIVCODE = BmnGokei(intData).BMNCD
					.MEISYO = "�@�@" & BmnGokei(intData).BMNNM '���喼��
					.BD_UODSU_T = BmnGokei(intData).UODSU '�󒍐�
					.BD_UODKN_T = BmnGokei(intData).UODKN '�󒍋��z
					.BD_SIKKN_T = BmnGokei(intData).SIKKN '�d��
					.BD_BAISA_T = BmnGokei(intData).BAISA '����
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
					End If
					
					'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
					'����
					'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'�󒍐�
					'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    ''delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'�󒍋��z
					'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'�d��
					'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'����
					'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'������
					If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
						'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					Else
						'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'delete 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        'delete 20190325 END saiki
						Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
				End With
				
				'�S�Ѝ��v�v�Z
				ZenGokei.UODSU = ZenGokei.UODSU + BmnGokei(intData).UODSU '�󒍐���
				ZenGokei.UODKN = ZenGokei.UODKN + BmnGokei(intData).UODKN '�󒍋��z
				ZenGokei.SIKKN = ZenGokei.SIKKN + BmnGokei(intData).SIKKN '�d��
				ZenGokei.BAISA = ZenGokei.BAISA + BmnGokei(intData).BAISA '����
			Next 
			
			'�S�Ѝ��v�s�̍쐬
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = gc_Sum_Text_Gokei
				.BD_UODSU_T = ZenGokei.UODSU '�󒍐�
				.BD_UODKN_T = ZenGokei.UODKN '�󒍋��z
				.BD_SIKKN_T = ZenGokei.SIKKN '�d��
				.BD_BAISA_T = ZenGokei.BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If
				
				'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
				'����
				'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'�󒍐�
				'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'�󒍋��z
				'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'�d��
				'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'����
				'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'delete 20190325 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'delete 20190325 END saiki
				Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				'������
				If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
					'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				Else
					'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'delete 20190325 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    'delete 20190325 END saiki
					Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
				End If
			End With
			
			'�s���\���̔z��� Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
			
			NowPageNum = 1
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' 2007/03/04  ADD START  KUMEDA
		Call CF_Clr_Prompt(pm_All)
		' 2007/03/04  ADD END
		
		F_GET_BD_DATA_BMN_SOUKATU = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA_BMN_SOUKATU: 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_BMN_SOUKATU
	'   �T�v�F  �{�f�B���f�[�^�擾�i����ʑ����\�j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_BMN_SOUKATU2(ByVal pm_SQL As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim intRowCnt As Short
		Dim intBmnCnt As Short
		Dim intTikCnt As Short
		Dim BmnGokei() As UODDL71_TYPE_BMNSOU
		Dim TikGokei() As UODDL71_TYPE_BMNSOU
		Dim ZenGokei As UODDL71_TYPE_BMNSOU
		Dim Wk_BmnCd As String
		Dim Wk_TikCd As String
		Dim Wk_Bmn_Index As Short
		Dim Wk_Tik_Index As Short
		Dim Wk_Zen_Index As Short
		Dim Br_Cnt As Short
		
		On Error GoTo ERR_F_GET_BD_DATA_BMN_SOUKATU2
		F_GET_BD_DATA_BMN_SOUKATU2 = -1
		
		' 2007/03/04  ADD START  KUMEDA
		Call FR_SSSMAIN.Ctl_MN_APPENDC_Click()
		Call CF_Set_Prompt(DATE_GET_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), pm_All)
		System.Windows.Forms.Application.DoEvents()
		' 2007/03/04  ADD END
		
		'������
		Err_Cd = ""
		Wk_BmnCd = ""
		Wk_TikCd = ""
		ReDim BmnGokei(0)
		ReDim TikGokei(0)
		
		'�����r�p�k����
		strSQL = pm_SQL

        'change 20190327 START saiki
		'DB�A�N�Z�X
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change 20190327 END saiki

        'change 20190329 START saiki
        ' If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                'change 20190329 END saiki
                '�擾�f�[�^�Ȃ�
                F_GET_BD_DATA_BMN_SOUKATU2 = 0
                Err_Cd = gc_strMsgUODDL71_E_002
                Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

                Exit Function
            Else

            intCnt = 0
            'change 20190329 START saiki
            ' Do Until CF_Ora_EOF(Usr_Ody) = True
            ''�擾�S���R�[�h���{�f�B���ޔ�
            'intCnt = intCnt + 1
            '    '�s�ǉ�
            '    ReDim Preserve UODDL71_BMNSOU_Inf(intCnt)

            '    With UODDL71_BMNSOU_Inf(intCnt)
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "") '����R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "") '���喼��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNBR = CF_Ora_GetDyn(Usr_Ody, "BMNBR", 0) '�����s��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "") '�n��敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TIKNM = CF_Ora_GetDyn(Usr_Ody, "TIKNM", "") '�n�於��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TIKBR = CF_Ora_GetDyn(Usr_Ody, "TIKBR", 0) '�n���s��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "") '�c�Ə��R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .EIGYONM = CF_Ora_GetDyn(Usr_Ody, "EIGYONM", "") '�c�Ə�����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .EIGYOBR = CF_Ora_GetDyn(Usr_Ody, "EIGYOBR", 0) '�c�Ə���s��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DSPORD = CF_Ora_GetDyn(Usr_Ody, "DSPORD", "") '�\����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .UODSU = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0) '�󒍐���
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .UODKN = CF_Ora_GetDyn(Usr_Ody, "UODKN", 0) '�󒍋��z
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SIKKN = CF_Ora_GetDyn(Usr_Ody, "SIKKN", 0) '�d��
            '        .BAISA = .UODKN - .SIKKN '����
            '    End With


            'Do Until dt IsNot Nothing OrElse dt.Rows.Count > 0
            For Each row As DataRow In dt.Rows
                '�擾�S���R�[�h���{�f�B���ޔ�
                intCnt = intCnt + 1
                '�s�ǉ�
                ReDim Preserve UODDL71_BMNSOU_Inf(intCnt)

                With UODDL71_BMNSOU_Inf(intCnt)
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .BMNCD = DB_NullReplace(row("BMNCD"), "") '����R�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .BMNNM = DB_NullReplace(row("BMNNM"), "") '���喼��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .BMNBR = DB_NullReplace(row("BMNBR"), 0) '�����s��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .TIKKB = DB_NullReplace(row("TIKKB"), "") '�n��敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .TIKNM = DB_NullReplace(row("TIKNM"), "") '�n�於��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .TIKBR = DB_NullReplace(row("TIKBR"), 0) '�n���s��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .EIGYOCD = DB_NullReplace(row("EIGYOCD"), "") '�c�Ə��R�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .EIGYONM = DB_NullReplace(row("EIGYONM"), "") '�c�Ə�����
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .EIGYOBR = DB_NullReplace(row("EIGYOBR"), 0) '�c�Ə���s��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .DSPORD = DB_NullReplace(row("DSPORD"), "") '�\����
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .UODSU = DB_NullReplace(row("UODSU"), 0) '�󒍐���
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .UODKN = DB_NullReplace(row("UODKN"), 0) '�󒍋��z
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SIKKN = DB_NullReplace(row("SIKKN"), 0) '�d��
                    .BAISA = .UODKN - .SIKKN '����
                End With

                'change 20190329 END saiki

                'delete 20190329 START saiki
                ''�����R�[�h
                'Call CF_Ora_MoveNext(Usr_Ody)
                'delete 20190329 END saiki
            Next

            intRowCnt = 0
			intBmnCnt = 0
			intTikCnt = 0
			For intData = 1 To intCnt
				With UODDL71_BMNSOU_Inf(intData)
					'�O�f�[�^�̕���R�[�h�ƈقȂ�ꍇ
					If Wk_BmnCd <> .BMNCD Then
						'�ŏ��̕���łȂ��ꍇ�A�O�̕���̏��v���^�C�g���s�ɑ��
						If Trim(Wk_BmnCd) <> "" Then
							With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Bmn_Index).Bus_Inf
								.BD_UODSU_T = BmnGokei(intBmnCnt).UODSU '�󒍐�
								.BD_UODKN_T = BmnGokei(intBmnCnt).UODKN '�󒍋��z
								.BD_SIKKN_T = BmnGokei(intBmnCnt).SIKKN '�d��
								.BD_BAISA_T = BmnGokei(intBmnCnt).BAISA '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'change 20190329 START saiki
                                '  Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                                'change 20190329 END saiki

                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                                'change 20190329 END saiki

                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                                'change 20190329 END saiki

                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                                'change 20190329 END saiki

                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                                'change 20190329 END saiki

                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
								'������
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                    'change 20190329 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                                    'change 20190329 END saiki

                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
								Else
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                    'change 20190329 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                                    'change 20190329 END saiki

                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'�ŏ��̕���łȂ��ꍇ
						If Trim(Wk_BmnCd) <> "" Then
							'�}�X�^�ɓo�^����Ă���s�����̋�s�쐬
							For Br_Cnt = 1 To BmnGokei(intBmnCnt).BMNBR
								'�s�ǉ�
								intRowCnt = intRowCnt + 1
								ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
								'�s���ڏ��R�s�[
								Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							Next 
						End If
						
						'����̃J�E���g
						intBmnCnt = intBmnCnt + 1
						'���升�v�v�Z�p
						ReDim Preserve BmnGokei(intBmnCnt)
						BmnGokei(intBmnCnt).BMNCD = .BMNCD '����R�[�h
						BmnGokei(intBmnCnt).BMNNM = .BMNNM '���喼��
						BmnGokei(intBmnCnt).BMNBR = .BMNBR '�����s��
						BmnGokei(intBmnCnt).UODSU = 0 '�󒍐���
						BmnGokei(intBmnCnt).UODKN = 0 '�󒍋��z
						BmnGokei(intBmnCnt).SIKKN = 0 '�d��
						BmnGokei(intBmnCnt).BAISA = 0 '����
						
						'�s�ǉ�
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'�s���ڏ��R�s�[
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = .BMNNM
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "1"
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .BMNCD

                        '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                        '����
                        'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)

                        '����̃^�C�g���s�̔ԍ���ޔ�
                        Wk_Bmn_Index = intRowCnt
					End If
					
					'�O�f�[�^�̒n��敪�ƈقȂ�ꍇ
					If Wk_TikCd <> .TIKKB Then
						'�ŏ��̒n��łȂ��ꍇ�A�O�̒n��̌v���^�C�g���s�ɑ��
						If Trim(Wk_TikCd) <> "" Then
							With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Tik_Index).Bus_Inf
								.BD_UODSU_T = TikGokei(intTikCnt).UODSU '�󒍐�
								.BD_UODKN_T = TikGokei(intTikCnt).UODKN '�󒍋��z
								.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '�d��
								.BD_BAISA_T = TikGokei(intTikCnt).BAISA '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                                'change 20190329 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                                'change 20190329 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                                'change 20190329 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                'change 20190329 START saiki
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                                'change 20190329 END saiki
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
								'������
								If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                    'change 20190329 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                                    'change 20190329 END saiki
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
								Else
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                                    'change 20190329 START saiki
                                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                                    'change 20190329 END saiki
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
								End If
							End With
						End If
						
						'�ŏ��̒n��łȂ��ꍇ
						If Trim(Wk_TikCd) <> "" Then
							'�}�X�^�ɓo�^����Ă���s�����̋�s�쐬
							For Br_Cnt = 1 To TikGokei(intTikCnt).TIKBR
								'�s�ǉ�
								intRowCnt = intRowCnt + 1
								ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
								'�s���ڏ��R�s�[
								Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							Next 
						End If
						
						'���f�[�^�̒n��敪������ꍇ
						If Trim(.TIKKB) <> "" Then
							'�n��̃J�E���g
							intTikCnt = intTikCnt + 1
							'�n�捇�v�v�Z�p
							ReDim Preserve TikGokei(intTikCnt)
							TikGokei(intTikCnt).TIKNM = .TIKNM '�n�於��
							TikGokei(intTikCnt).TIKBR = .TIKBR '�n���s��
							TikGokei(intTikCnt).UODSU = 0 '�󒍐���
							TikGokei(intTikCnt).UODKN = 0 '�󒍋��z
							TikGokei(intTikCnt).SIKKN = 0 '�d��
							TikGokei(intTikCnt).BAISA = 0 '����
							
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�@�@" & .TIKNM
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "2"
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .TIKKB

                            '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                            '����
                            'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                            'change 20190329 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                            Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                            'change 20190329 END saiki

                            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
							
							'����̃^�C�g���s�̔ԍ���ޔ�
							Wk_Tik_Index = intRowCnt
						End If
					End If
					
					'�c�Ə����׍s�̕ҏW
					'�s�ǉ�
					intRowCnt = intRowCnt + 1
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
					'�s���ڏ��R�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
					
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�@�@�@�@" & .EIGYONM & .EIGYOCD
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "3"
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = .EIGYOCD
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODSU_T = .UODSU '�󒍐�
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODKN_T = .UODKN '�󒍋��z
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_SIKKN_T = .SIKKN '�d��
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BAISA_T = .BAISA '����
					If .UODKN = 0 Then
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = 0
					Else
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(.BAISA / .UODKN * 100, 1) '������
					End If
					
					'��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
					With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                        '����
                        'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '�󒍐�
                        'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '�󒍋��z
                        'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '�d��
                        'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '����
                        'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						'������
						If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                            'change 20190329 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                            'change 20190329 END saiki
                            Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						Else
                            'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                            'change 20190329 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                            'change 20190329 END saiki
                            Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End With
					
					'�}�X�^�ɓo�^����Ă���s�����̋�s�쐬
					For Br_Cnt = 1 To .EIGYOBR
						'�s�ǉ�
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'�s���ڏ��R�s�[
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
					Next 
					
					'�n�捇�v�v�Z
					If .TIKNM <> "" Then
						TikGokei(intTikCnt).UODSU = TikGokei(intTikCnt).UODSU + .UODSU '�󒍐���
						TikGokei(intTikCnt).UODKN = TikGokei(intTikCnt).UODKN + .UODKN '�󒍋��z
						TikGokei(intTikCnt).SIKKN = TikGokei(intTikCnt).SIKKN + .SIKKN '�d��
						TikGokei(intTikCnt).BAISA = TikGokei(intTikCnt).BAISA + .BAISA '����
					End If
					
					'�c�Ə����v�v�Z
					BmnGokei(intBmnCnt).UODSU = BmnGokei(intBmnCnt).UODSU + .UODSU '�󒍐���
					BmnGokei(intBmnCnt).UODKN = BmnGokei(intBmnCnt).UODKN + .UODKN '�󒍋��z
					BmnGokei(intBmnCnt).SIKKN = BmnGokei(intBmnCnt).SIKKN + .SIKKN '�d��
					BmnGokei(intBmnCnt).BAISA = BmnGokei(intBmnCnt).BAISA + .BAISA '����
					
					'���f�[�^�̑ޔ�
					Wk_BmnCd = .BMNCD
					Wk_TikCd = .TIKKB
				End With
			Next 
			
			'�n��敪������ꍇ�A�ŏI�̒n��̌v���^�C�g���s�ɑ��
			If Trim(Wk_TikCd) <> "" Then
				With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Tik_Index).Bus_Inf
					.BD_UODSU_T = TikGokei(intTikCnt).UODSU '�󒍐�
					.BD_UODKN_T = TikGokei(intTikCnt).UODKN '�󒍋��z
					.BD_SIKKN_T = TikGokei(intTikCnt).SIKKN '�d��
					.BD_BAISA_T = TikGokei(intTikCnt).BAISA '����
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
					End If

                    '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    '�󒍐�
                    'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                    '�󒍋��z
                    'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                    '�d��
                    'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
                    '����
                    'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
					'������
					If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
					Else
                        'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Tik_Index, pm_All, SET_FLG_DB)
					End If
				End With
				
				'�}�X�^�ɓo�^����Ă���s�����̋�s�쐬
				For Br_Cnt = 1 To TikGokei(intTikCnt).TIKBR
					'�s�ǉ�
					intRowCnt = intRowCnt + 1
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
					'�s���ڏ��R�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				Next 
			End If
			
			'�ŏI�̉c�Ə��̏��v���^�C�g���s�ɑ��
			With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Bmn_Index).Bus_Inf
				.BD_UODSU_T = BmnGokei(intBmnCnt).UODSU '�󒍐�
				.BD_UODKN_T = BmnGokei(intBmnCnt).UODKN '�󒍋��z
				.BD_SIKKN_T = BmnGokei(intBmnCnt).SIKKN '�d��
				.BD_BAISA_T = BmnGokei(intBmnCnt).BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'change 20190329 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                'change 20190329 END saiki
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'change 20190329 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                'change 20190329 END saiki
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'change 20190329 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                'change 20190329 END saiki
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'change 20190329 START saiki
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                'change 20190329 END saiki
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
				'������
				If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
				Else
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Bmn_Index, pm_All, SET_FLG_DB)
				End If
			End With
			
			'�}�X�^�ɓo�^����Ă���s�����̋�s�쐬
			For Br_Cnt = 1 To BmnGokei(intBmnCnt).BMNBR
				'�s�ǉ�
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'�s���ڏ��R�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			Next 
			
			'�S�Ѝs�̍쐬
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�S��"
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "99"
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVCODE = "Z"

            '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
            '����
            'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

            'change 20190329 START saiki
            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
            Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
            'change 20190329 END saiki
            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			
			'�S�Ђ̃^�C�g���s�̔ԍ���ޔ�
			Wk_Zen_Index = intRowCnt
			
			'�S�З��̎��ƕ����v�s�̍쐬
			For intData = 1 To intBmnCnt
				'�s�ǉ�
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'�s���ڏ��R�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					.DIVISION = "1"
					.DIVCODE = BmnGokei(intData).BMNCD
					.MEISYO = "�@�@" & BmnGokei(intData).BMNNM '���喼��
					.BD_UODSU_T = BmnGokei(intData).UODSU '�󒍐�
					.BD_UODKN_T = BmnGokei(intData).UODKN '�󒍋��z
					.BD_SIKKN_T = BmnGokei(intData).SIKKN '�d��
					.BD_BAISA_T = BmnGokei(intData).BAISA '����
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
					End If

                    '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    '����
                    'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_MEISYO(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '�󒍐�
                    'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '�󒍋��z
                    'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '�d��
                    'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '����
                    'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                    'change 20190329 START saiki
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                    'change 20190329 END saiki
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					'������
					If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					Else
                        'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190329 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                        Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                        'change 20190329 END saiki
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
				End With
				
				'�S�Ѝ��v�v�Z
				ZenGokei.UODSU = ZenGokei.UODSU + BmnGokei(intData).UODSU '�󒍐���
				ZenGokei.UODKN = ZenGokei.UODKN + BmnGokei(intData).UODKN '�󒍋��z
				ZenGokei.SIKKN = ZenGokei.SIKKN + BmnGokei(intData).SIKKN '�d��
				ZenGokei.BAISA = ZenGokei.BAISA + BmnGokei(intData).BAISA '����
			Next 
			
			'�S�Ѝ��v���^�C�g���s�ɑ��
			With pm_All.Dsp_Body_Inf.Row_Inf(Wk_Zen_Index).Bus_Inf
				.BD_UODSU_T = ZenGokei.UODSU '�󒍐�
				.BD_UODKN_T = ZenGokei.UODKN '�󒍋��z
				.BD_SIKKN_T = ZenGokei.SIKKN '�d��
				.BD_BAISA_T = ZenGokei.BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                'change 20190325 START saiki
                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                ''�󒍐�
                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                ''�󒍋��z
                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                ''�d��
                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                ''����
                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                ''������
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '            End If

                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71_fpr.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71_fpr.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71_fpr.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71_fpr.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                '������
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71_fpr.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Zen_Index, pm_All, SET_FLG_DB)
                End If
                'change 20190329 END saiki
            End With
			
			'�s���\���̔z��� Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
			
			NowPageNum = 1
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' 2007/03/04  ADD START  KUMEDA
		Call CF_Clr_Prompt(pm_All)
		' 2007/03/04  ADD END
		
		F_GET_BD_DATA_BMN_SOUKATU2 = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA_BMN_SOUKATU2: 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_KIS_SOUKATU_JUC_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k�����i�@��ʑ����\�F�󒍁j
	'   �����F�@pm_Kind         1:�������A2:�����
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KIS_SOUKATU_JUC_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'�����J�n���̎擾
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "     WAKU.SYOHIN As SYOHIN "
		strSQL = strSQL & "     WAKU.SYOHINC As SYOHIN "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "    ,WAKU.HGROUP As HGROUP "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "    ,WAKU.HGROUPNM As HGROUPNM "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "    ,WAKU.FRNKB As FRNKB "
		strSQL = strSQL & "    ,WAKU.NAIGAI As NAIGAI "
		strSQL = strSQL & "    ,MAIN.UODSU As UODSU "
		strSQL = strSQL & "    ,Round(MAIN.UODKN) As UODKN "
		strSQL = strSQL & "    ,Round(MAIN.SIKKN) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             KSY.HINGRPRM "
		strSQL = strSQL & "            ,PSUM.FRNKB "
		strSQL = strSQL & "            ,Sum(PSUM.UODSU) As UODSU "
		strSQL = strSQL & "            ,Sum(PSUM.UODKN) As UODKN "
		strSQL = strSQL & "            ,Sum(PSUM.SIKKN) As SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             ( "
		strSQL = strSQL & "                 Select "
		strSQL = strSQL & "                     PCODE "
		strSQL = strSQL & "                    ,FRNKB "
		strSQL = strSQL & "                    ,JDNDT "
		strSQL = strSQL & "                    ,Sum(UODSU) As UODSU "
		strSQL = strSQL & "                    ,Sum(UODKN) As UODKN "
		strSQL = strSQL & "                    ,Sum(SIKKN) As SIKKN "
		strSQL = strSQL & "                 From "
		strSQL = strSQL & "                     JDNDLA "
		strSQL = strSQL & "                 Where "
		strSQL = strSQL & "                     JDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "                 And JDNDT <= '" & GV_UNYDate & "' "
		
		If Trim(gv_UODDL71_TIKCD) <> "" Then
			strSQL = strSQL & "                 And TIKKB = '" & gv_UODDL71_TIKCD & "' "
		End If
		
		If Trim(gv_UODDL71_EIGCD) <> "" Then
			strSQL = strSQL & "                 And EIGYOCD = '" & gv_UODDL71_EIGCD & "' "
		End If
		
		If Trim(gv_UODDL71_BMNCD) <> "" Then
			strSQL = strSQL & "                 And JIGYOBU = '" & gv_UODDL71_BMNCD & "' "
		End If
		
		strSQL = strSQL & "                 Group By "
		strSQL = strSQL & "                     PCODE "
		strSQL = strSQL & "                    ,FRNKB "
		strSQL = strSQL & "                    ,JDNDT "
		strSQL = strSQL & "             ) PSUM "
		strSQL = strSQL & "            ,( "
		strSQL = strSQL & "                 Select Distinct "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     HINGRPRM "
		'strSQL = strSQL & "                    ,PCODE "
		'2007/07/11  DLT START  KUMEDA
		''    strSQL = strSQL & "                    ,STTTKDT "
		''    strSQL = strSQL & "                    ,ENDTKDT "
		'2007/07/11  DLT END
		strSQL = strSQL & "                     K.HINGRPRM HINGRPRM "
		strSQL = strSQL & "                    ,K.PCODE    PCODE "
		strSQL = strSQL & "                    ,M.STTTKDT  STTTKDT "
		strSQL = strSQL & "                    ,M.ENDTKDT  ENDTKDT "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "                 From "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     KSYMTA "
		strSQL = strSQL & "                     KSYMTA K, MEIMTC M "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "                 Where "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     STTTKDT <= '" & GV_UNYDate & "' "
		'strSQL = strSQL & "                 And ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                     K.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And K.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And M.KEYCD = '" & pc_Syohin_Keycode & "' "
		strSQL = strSQL & "                 And K.HINGRPRM = M.MEINMB "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "             ) KSY "
		strSQL = strSQL & "         Where "
		'2007/12/07 FKS)minamoto CHG START
		'2007/07/11  CHG START  KUMEDA
		''    strSQL = strSQL & "             KSY.STTTKDT <= PSUM.JDNDT "
		''    strSQL = strSQL & "         And KSY.ENDTKDT >= PSUM.JDNDT "
		''    strSQL = strSQL & "         And KSY.PCODE = PSUM.PCODE "
		'    strSQL = strSQL & "             KSY.PCODE = PSUM.PCODE "
		'2007/07/11  CHG END
		strSQL = strSQL & "             KSY.STTTKDT <= PSUM.JDNDT "
		strSQL = strSQL & "         And KSY.ENDTKDT >= PSUM.JDNDT "
		strSQL = strSQL & "         And KSY.PCODE = PSUM.PCODE "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             KSY.HINGRPRM "
		strSQL = strSQL & "            ,PSUM.FRNKB "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             MEI.MEINMB As SYOHIN "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,MEI.MEINMC As SYOHINC "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "            ,MEI.DSPORD As DSPORD "
		strSQL = strSQL & "            ,MEI.MEIKBA As HGROUP "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,HG.MEINMA As HGROUPNM "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "            ,FRN.FRNKB As FRNKB "
		strSQL = strSQL & "            ,FRN.NAIGAI As NAIGAI "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             MEIMTC MEI "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "             ,MEIMTC HG "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,( "
		strSQL = strSQL & "                 Select '0' As FRNKB, '����' As NAIGAI "
		strSQL = strSQL & "                 From DUAL "
		strSQL = strSQL & "                 Union "
		strSQL = strSQL & "                 Select '1' As FRNKB, '�C�O' As NAIGAI "
		strSQL = strSQL & "                 From DUAL "
		strSQL = strSQL & "             ) FRN "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             MEI.KEYCD = '" & pc_Syohin_Keycode & "' "
		strSQL = strSQL & "         And MEI.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "         And HG.KEYCD = '" & pc_Hgroup_Keycode & "' "
		strSQL = strSQL & "         And HG.MEIKBA = MEI.MEIKBA "
		strSQL = strSQL & "         And HG.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And HG.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.HINGRPRM(+) = WAKU.SYOHIN "
		strSQL = strSQL & " And MAIN.FRNKB(+) = WAKU.FRNKB "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     WAKU.HGROUP "
		strSQL = strSQL & "    ,WAKU.DSPORD "
		strSQL = strSQL & "    ,WAKU.FRNKB "
		
		F_GET_KIS_SOUKATU_JUC_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_KIS_SOUKATU_URI_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k�����i�@��ʑ����\�F����j
	'   �����F�@pm_Kind         1:�������A2:�����
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KIS_SOUKATU_URI_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'�����J�n���̎擾
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select"
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "     WAKU.SYOHIN As SYOHIN "
		strSQL = strSQL & "     WAKU.SYOHINC As SYOHIN "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "    ,WAKU.HGROUP As HGROUP "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "    ,WAKU.HGROUPNM As HGROUPNM "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "    ,WAKU.FRNKB As FRNKB "
		strSQL = strSQL & "    ,WAKU.NAIGAI As NAIGAI "
		strSQL = strSQL & "    ,MAIN.URISU As UODSU "
		strSQL = strSQL & "    ,Round(MAIN.URIKN) As UODKN "
		strSQL = strSQL & "    ,Round(MAIN.SIKKN) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             KSY.HINGRPRM "
		strSQL = strSQL & "            ,PSUM.FRNKB "
		strSQL = strSQL & "            ,Sum(PSUM.URISU) As URISU "
		strSQL = strSQL & "            ,Sum(PSUM.URIKN) As URIKN "
		strSQL = strSQL & "            ,Sum(PSUM.SIKKN) As SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             ( "
		strSQL = strSQL & "                 Select "
		strSQL = strSQL & "                     PCODE "
		strSQL = strSQL & "                    ,FRNKB "
		strSQL = strSQL & "                    ,UDNDT "
		strSQL = strSQL & "                    ,Sum(URISU) As URISU "
		strSQL = strSQL & "                    ,Sum(URIKN) As URIKN "
		strSQL = strSQL & "                    ,Sum(SIKKN) As SIKKN "
		strSQL = strSQL & "                 From "
		strSQL = strSQL & "                     UDNDLA "
		strSQL = strSQL & "                 Where "
		strSQL = strSQL & "                     UDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "                 And UDNDT <= '" & GV_UNYDate & "' "
		
		If Trim(gv_UODDL71_TIKCD) <> "" Then
			strSQL = strSQL & "                 And TIKKB = '" & gv_UODDL71_TIKCD & "' "
		End If
		
		If Trim(gv_UODDL71_EIGCD) <> "" Then
			strSQL = strSQL & "                 And EIGYOCD = '" & gv_UODDL71_EIGCD & "' "
		End If
		
		If Trim(gv_UODDL71_BMNCD) <> "" Then
			strSQL = strSQL & "                 And JIGYOBU = '" & gv_UODDL71_BMNCD & "' "
		End If
		
		strSQL = strSQL & "                 Group By "
		strSQL = strSQL & "                     PCODE "
		strSQL = strSQL & "                    ,FRNKB "
		strSQL = strSQL & "                    ,UDNDT "
		strSQL = strSQL & "             ) PSUM "
		strSQL = strSQL & "            ,( "
		strSQL = strSQL & "                 Select Distinct "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     HINGRPRM "
		'strSQL = strSQL & "                    ,PCODE "
		'2007/07/11  DLT START  KUMEDA
		''    strSQL = strSQL & "                    ,STTTKDT "
		''    strSQL = strSQL & "                    ,ENDTKDT "
		'2007/07/11  DLT END
		strSQL = strSQL & "                     K.HINGRPRM HINGRPRM "
		strSQL = strSQL & "                    ,K.PCODE    PCODE "
		strSQL = strSQL & "                    ,M.STTTKDT  STTTKDT "
		strSQL = strSQL & "                    ,M.ENDTKDT  ENDTKDT "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "                 From "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     KSYMTA "
		strSQL = strSQL & "                     KSYMTA K, MEIMTC M "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "                 Where "
		'2007/12/07 FKS)minamoto CHG START
		'strSQL = strSQL & "                     STTTKDT <= '" & GV_UNYDate & "' "
		'strSQL = strSQL & "                 And ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                     K.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And K.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "                 And M.KEYCD = '" & pc_Syohin_Keycode & "' "
		strSQL = strSQL & "                 And K.HINGRPRM = M.MEINMB "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "             ) KSY "
		strSQL = strSQL & "         Where "
		'2007/12/07 FKS)minamoto CHG START
		'2007/07/11  CHG START  KUMEDA
		''    strSQL = strSQL & "             KSY.STTTKDT <= PSUM.UDNDT "
		''    strSQL = strSQL & "         And KSY.ENDTKDT >= PSUM.UDNDT "
		''    strSQL = strSQL & "         And KSY.PCODE = PSUM.PCODE "
		'    strSQL = strSQL & "             KSY.PCODE = PSUM.PCODE "
		'2007/07/11  CHG END
		strSQL = strSQL & "             KSY.STTTKDT <= PSUM.UDNDT "
		strSQL = strSQL & "         And KSY.ENDTKDT >= PSUM.UDNDT "
		strSQL = strSQL & "         And KSY.PCODE = PSUM.PCODE "
		'2007/12/07 FKS)minamoto CHG END
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             KSY.HINGRPRM "
		strSQL = strSQL & "            ,PSUM.FRNKB "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             MEI.MEINMB As SYOHIN "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,MEI.MEINMC As SYOHINC "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "            ,MEI.DSPORD As DSPORD "
		strSQL = strSQL & "            ,MEI.MEIKBA As HGROUP "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,HG.MEINMA As HGROUPNM "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "            ,FRN.FRNKB As FRNKB "
		strSQL = strSQL & "            ,FRN.NAIGAI As NAIGAI "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             MEIMTC MEI "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "             ,MEIMTC HG "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,( "
		strSQL = strSQL & "                 Select '0' As FRNKB, '����' As NAIGAI "
		strSQL = strSQL & "                 From DUAL "
		strSQL = strSQL & "                 Union "
		strSQL = strSQL & "                 Select '1' As FRNKB, '�C�O' As NAIGAI "
		strSQL = strSQL & "                 From DUAL "
		strSQL = strSQL & "             ) FRN "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             MEI.KEYCD = '" & pc_Syohin_Keycode & "' "
		strSQL = strSQL & "         And MEI.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEI.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "         And HG.KEYCD = '" & pc_Hgroup_Keycode & "' "
		strSQL = strSQL & "         And HG.MEIKBA = MEI.MEIKBA "
		strSQL = strSQL & "         And HG.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And HG.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.HINGRPRM(+) = WAKU.SYOHIN "
		strSQL = strSQL & " And MAIN.FRNKB(+) = WAKU.FRNKB "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     WAKU.HGROUP "
		strSQL = strSQL & "    ,WAKU.DSPORD "
		strSQL = strSQL & "    ,WAKU.FRNKB "
		
		F_GET_KIS_SOUKATU_URI_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_KIS_SOUKATU_JUC
	'   �T�v�F  �{�f�B���f�[�^�擾�i�@��ʑ����\�F�󒍁j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_SOUKATU_JUC(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki
		
		'�����r�p�k����
		strSQL = F_GET_KIS_SOUKATU_JUC_SQL(pm_Kind)
		
		Ret_Value = F_GET_BD_DATA_KIS_SOUKATU(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
		'UPGRADE_ISSUE: Control lab_exc �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'delete 20190325 START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then
        '    Call F_Ctl_LAB_EXC(pm_All)
        'End If
        'delete 20190325 END saiki
		'ADD 20150710 END C2-20150708-01
		
		F_GET_BD_DATA_KIS_SOUKATU_JUC = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_KIS_SOUKATU_URI
	'   �T�v�F  �{�f�B���f�[�^�擾�i�@��ʑ����\�F����j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_SOUKATU_URI(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki
		
		'�����r�p�k����
		strSQL = F_GET_KIS_SOUKATU_URI_SQL(pm_Kind)
		
		Ret_Value = F_GET_BD_DATA_KIS_SOUKATU(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
		'UPGRADE_ISSUE: Control lab_exc �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'delete 20190325 START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then
        '    Call F_Ctl_LAB_EXC(pm_All)
        'End If
        'delete 20190325 END saiki
		'ADD 20150710 END C2-20150708-01
		
		F_GET_BD_DATA_KIS_SOUKATU_URI = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_BMN_SOUKATU
	'   �T�v�F  �{�f�B���f�[�^�擾�i����ʑ����\�j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_SOUKATU(ByVal pm_SQL As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim intRowCnt As Short
		Dim intKisCnt As Short
		Dim KisGokei() As UODDL71_TYPE_KISSOU
		' 2007/01/13  ADD START  KUMEDA
		Dim KisGokeiNai() As UODDL71_TYPE_KISSOU
		Dim KisGokeiGai() As UODDL71_TYPE_KISSOU
		Dim SumGokeiNai As UODDL71_TYPE_KISSOU
		Dim SumGokeiGai As UODDL71_TYPE_KISSOU
		' 2007/01/13  ADD END
		Dim SumGokei As UODDL71_TYPE_KISSOU
		Dim Wk_KisCd As String
		Dim Wk_DivNm As String
		Dim Wk_DivRn As String
		' 2007/01/10  ADD START  KUMEDA
		Dim Wk_GrpCd As String
		' 2007/01/10  ADD END
		' 2007/01/12  ADD START  KUMEDA
		Dim bufRowCnt As Short
		Dim sumUODSU As Decimal
		Dim sumUODKN As Decimal
		Dim sumSIKKN As Decimal
		Dim sumBAISA As Decimal
		
		bufRowCnt = 0
		sumUODSU = 0
		sumUODKN = 0
		sumSIKKN = 0
		sumBAISA = 0
		' 2007/01/12  ADD END
		' 2007/01/13  ADD START  KUMEDA
		Dim bufGrpCnt As Short
		Dim bufGrpCntNai As Short
		Dim bufGrpCntGai As Short
		' 2007/01/13  ADD END
		
		On Error GoTo ERR_F_GET_BD_DATA_KIS_SOUKATU
		F_GET_BD_DATA_KIS_SOUKATU = -1

        ' 2007/03/04  ADD START  KUMEDA
        'delete 20190403 START saiki
        'Call FR_SSSMAIN1.Ctl_MN_APPENDC_Click()
        'delete 20190403 END saiki
        Call CF_Set_Prompt(DATE_GET_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), pm_All)
		System.Windows.Forms.Application.DoEvents()
		' 2007/03/04  ADD END
		
		'������
		Err_Cd = ""
        Wk_KisCd = ""
        'ADD 20190403 START saiki
        Wk_GrpCd = ""
        'ADD 20190403 END saiki
        ReDim KisGokei(0)
		' 2007/01/13  ADD START  KUMEDA
		ReDim KisGokeiNai(0)
		ReDim KisGokeiGai(0)
        ' 2007/01/13  ADD END

        'change 20190403  START saiki
        '����or�n��or�c�Ə� �擾
        'If Trim(gv_UODDL71_BMNCD) <> "" Then
        '	Wk_DivNm = "����"
        '	'UPGRADE_ISSUE: Control HD_BMNNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '	Wk_DivRn = pm_All.Dsp_Base.FormCtl.HD_BMNNM.Text
        'ElseIf Trim(gv_UODDL71_TIKCD) <> "" Then 
        '	Wk_DivNm = "�n��"
        '	'UPGRADE_ISSUE: Control HD_TIKNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '	Wk_DivRn = pm_All.Dsp_Base.FormCtl.HD_TIKNM.Text
        'ElseIf Trim(gv_UODDL71_EIGCD) <> "" Then 
        '	Wk_DivNm = "�c�Ə�"
        '	'UPGRADE_ISSUE: Control HD_EIGNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '	Wk_DivRn = pm_All.Dsp_Base.FormCtl.HD_EIGNM.Text
        'Else
        '	Wk_DivNm = "�S��"
        '	Wk_DivRn = "�S��"
        'End If

        '����or�n��or�c�Ə� �擾
        If Trim(gv_UODDL71_BMNCD) <> "" Then
            Wk_DivNm = "����"
            'UPGRADE_ISSUE: Control HD_BMNNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Wk_DivRn = UODDL71.HD_BMNNM.Text
        ElseIf Trim(gv_UODDL71_TIKCD) <> "" Then
            Wk_DivNm = "�n��"
            'UPGRADE_ISSUE: Control HD_TIKNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Wk_DivRn = UODDL71.HD_TIKNM.Text
        ElseIf Trim(gv_UODDL71_EIGCD) <> "" Then
            Wk_DivNm = "�c�Ə�"
            'UPGRADE_ISSUE: Control HD_EIGNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Wk_DivRn = UODDL71.HD_EIGNM.Text
        Else
            Wk_DivNm = "�S��"
            Wk_DivRn = "�S��"
        End If
        'change 20190403  END saiki

        '�����r�p�k����
        strSQL = pm_SQL

        'DB�A�N�Z�X
        'change 20190326 START saiki
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        dt = Nothing
        dt = DB_GetTable(strSQL)
        'change 20190326 END saiki

        'change 20190403 START saiki
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            'change 20190403 END saiki
            '�擾�f�[�^�Ȃ�
            F_GET_BD_DATA_KIS_SOUKATU = 0
            Err_Cd = gc_strMsgUODDL71_E_002
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

            Exit Function
        Else

            intCnt = 0

            'change 20190403 START saiki
            'Do Until CF_Ora_EOF(Usr_Ody) = True
            '    '�擾�S���R�[�h���{�f�B���ޔ�
            '    intCnt = intCnt + 1
            '    '�s�ǉ�
            '    ReDim Preserve UODDL71_KISSOU_Inf(intCnt)

            '    With UODDL71_KISSOU_Inf(intCnt)
            '        ' 2007/01/10  ADD START  KUMEDA
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .HGROUP = CF_Ora_GetDyn(Usr_Ody, "HGROUP", "") '���i�W�v�O���[�v
            '        ' 2007/01/10  ADD END
            '        '2007/10/12 FKS)minamoto ADD START
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .HGROUPNM = CF_Ora_GetDyn(Usr_Ody, "HGROUPNM", "") '���i�W�v�O���[�v����
            '        '2007/10/12 FKS)minamoto ADD END
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SYOHIN = CF_Ora_GetDyn(Usr_Ody, "SYOHIN", "") '���i
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NAIGAICD = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "") '�����O�R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NAIGAINM = CF_Ora_GetDyn(Usr_Ody, "NAIGAI", "") '�����O
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .UODSU = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0) '�󒍐���
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .UODKN = CF_Ora_GetDyn(Usr_Ody, "UODKN", 0) '�󒍋��z
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SIKKN = CF_Ora_GetDyn(Usr_Ody, "SIKKN", 0) '�d��
            '        .BAISA = .UODKN - .SIKKN '����
            '    End With

            '    '�����R�[�h
            '    Call CF_Ora_MoveNext(Usr_Ody)
            'Loop

            For Each row As DataRow In dt.Rows
                '�擾�S���R�[�h���{�f�B���ޔ�
                intCnt = intCnt + 1
                '�s�ǉ�
                ReDim Preserve UODDL71_KISSOU_Inf(intCnt)

                With UODDL71_KISSOU_Inf(intCnt)
                    ' 2007/01/10  ADD START  KUMEDA
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HGROUP = DB_NullReplace(row("HGROUP"), "") '���i�W�v�O���[�v
                    ' 2007/01/10  ADD END
                    '2007/10/12 FKS)minamoto ADD START
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HGROUPNM = DB_NullReplace(row("HGROUPNM"), "") '���i�W�v�O���[�v����
                    '2007/10/12 FKS)minamoto ADD END
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SYOHIN = DB_NullReplace(row("SYOHIN"), "") '���i
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .NAIGAICD = DB_NullReplace(row("FRNKB"), "") '�����O�R�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .NAIGAINM = DB_NullReplace(row("NAIGAI"), "") '�����O
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .UODSU = DB_NullReplace(row("UODSU"), 0) '�󒍐���
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .UODKN = DB_NullReplace(row("UODKN"), 0) '�󒍋��z
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SIKKN = DB_NullReplace(row("SIKKN"), 0) '�d��
                    .BAISA = .UODKN - .SIKKN '����
                End With

            Next
            'change 20190403 END saiki


            intRowCnt = 0
			intKisCnt = 0
			
			'����or�n��or�c�Ə����̍s���쐬
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
			pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = Wk_DivRn

            '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
            '����
            'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

            'change 20190325 START saiki
            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
            Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
            'change 20190325 END saiki
            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			
			For intData = 1 To intCnt
				With UODDL71_KISSOU_Inf(intData)
					' 2007/01/10  CHG START  KUMEDA
					''                '�O�f�[�^�̏��i�Q�P���ڂƈقȂ�ꍇ
					''                If Left(Wk_KisCd, 1) <> Left(.SYOHIN, 1) Then
					'�O�f�[�^�̏��i�W�v�O���[�v�ƈقȂ�ꍇ
					If Wk_GrpCd <> .HGROUP Then
						' 2007/01/10  CHG END
						'�ŏ��̏��i�Q�łȂ��ꍇ�A�O�̏��i�Q�̍��v�s���쐬
						If Trim(Wk_KisCd) <> "" Then
							' 2007/01/13  CHG START  KUMEDA   ---> intRowCnt �� bufGrpCnt �ɕύX
							With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = KisGokei(intKisCnt).SYOHIN '���i�Q
								.DIVISION = "1"
								.BD_UODSU_T = KisGokei(intKisCnt).UODSU '�󒍐�
								.BD_UODKN_T = KisGokei(intKisCnt).UODKN '�󒍋��z
								.BD_SIKKN_T = KisGokei(intKisCnt).SIKKN '�d��
								.BD_BAISA_T = KisGokei(intKisCnt).BAISA '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                'change 20190403  START saiki
                                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                ''����
                                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''�󒍐�
                                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''�󒍋��z
                                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''�d��
                                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''����
                                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                ''������
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190403  END saiki
                            End With
							'---> �����A�C�O�f�[�^�̍��v�s�ǉ�
							With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCntNai).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = KisGokeiNai(intKisCnt).SYOHIN '���i�Q
								.DIVISION = "2"
								.BD_UODSU_T = KisGokeiNai(intKisCnt).UODSU '�󒍐�
								.BD_UODKN_T = KisGokeiNai(intKisCnt).UODKN '�󒍋��z
								.BD_SIKKN_T = KisGokeiNai(intKisCnt).SIKKN '�d��
								.BD_BAISA_T = KisGokeiNai(intKisCnt).BAISA '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                'change 20190403  START saiki
                                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                ''����
                                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''�󒍐�
                                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''�󒍋��z
                                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''�d��
                                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''����
                                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                ''������
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '                        End If

                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                                                        End If
                                'change 20190403 END saiki
                            End With
							
							With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCntGai).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = KisGokeiGai(intKisCnt).SYOHIN '���i�Q
								.DIVISION = "2"
								.BD_UODSU_T = KisGokeiGai(intKisCnt).UODSU '�󒍐�
								.BD_UODKN_T = KisGokeiGai(intKisCnt).UODKN '�󒍋��z
								.BD_SIKKN_T = KisGokeiGai(intKisCnt).SIKKN '�d��
								.BD_BAISA_T = KisGokeiGai(intKisCnt).BAISA '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                'change 20190403  START saiki
                                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                ''����
                                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''�󒍐�
                                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''�󒍋��z
                                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''�d��
                                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''����
                                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                ''������
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '                        End If

                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                                End If
                                'change 20190403  END saiki

                            End With
							'<--- �����A�C�O�f�[�^�̍��v�s�ǉ�
							'�󔒍s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							'���i�Q���v�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'���i�Q���v�s�̑ޔ�
							bufGrpCnt = intRowCnt
							
							'���i�Q�i�����j���v�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'���i�Q���v�s�̑ޔ�
							bufGrpCntNai = intRowCnt
							
							'���i�Q�i�C�O�j���v�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'���i�Q���v�s�̑ޔ�
							bufGrpCntGai = intRowCnt
							' 2007/01/13  CHG END
							
							' 2007/01/13  ADD START  KUMEDA
						Else
							'���i�Q���v�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'���i�Q���v�s�̑ޔ�
							bufGrpCnt = intRowCnt
							
							'���i�Q�i�����j���v�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'���i�Q���v�s�̑ޔ�
							bufGrpCntNai = intRowCnt
							
							'���i�Q�i�C�O�j���v�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							'���i�Q���v�s�̑ޔ�
							bufGrpCntGai = intRowCnt
							' 2007/01/13  ADD END
						End If
						
						'���i�Q�̃J�E���g
						intKisCnt = intKisCnt + 1
						'���i�Q���v�v�Z�p
						ReDim Preserve KisGokei(intKisCnt)
						' 2007/03/04  CHG START  KUMEDA
						'                    KisGokei(intKisCnt).SYOHIN = "�@�@" & Left(.SYOHIN, 1) & "���v" '���i�Q
						'2007/10/12 FKS)minamoto CHG START
						'                    KisGokei(intKisCnt).SYOHIN = "�@�@" & Left(.SYOHIN, 1) & "�v" '���i�Q
						KisGokei(intKisCnt).SYOHIN = "�@�@" & Trim(.HGROUPNM) & "�v" '���i�W�v�O���[�v����
						'2007/10/12 FKS)minamoto CHG END
						' 2007/03/04  CHG END
						KisGokei(intKisCnt).UODSU = 0 '�󒍐���
						KisGokei(intKisCnt).UODKN = 0 '�󒍋��z
						KisGokei(intKisCnt).SIKKN = 0 '�d��
						KisGokei(intKisCnt).BAISA = 0 '����
						'Invalid_string_refer_to_original_code
						'���i�Q���v�v�Z�p
						ReDim Preserve KisGokeiNai(intKisCnt)
						KisGokeiNai(intKisCnt).SYOHIN = "�@�@" & "�@�@����" '���i�Q
						KisGokeiNai(intKisCnt).UODSU = 0 '�󒍐���
						KisGokeiNai(intKisCnt).UODKN = 0 '�󒍋��z
						KisGokeiNai(intKisCnt).SIKKN = 0 '�d��
						KisGokeiNai(intKisCnt).BAISA = 0 '����
						'���i�Q���v�v�Z�p
						ReDim Preserve KisGokeiGai(intKisCnt)
						KisGokeiGai(intKisCnt).SYOHIN = "�@�@" & "�@�@�C�O" '���i�Q
						KisGokeiGai(intKisCnt).UODSU = 0 '�󒍐���
						KisGokeiGai(intKisCnt).UODKN = 0 '�󒍋��z
						KisGokeiGai(intKisCnt).SIKKN = 0 '�d��
						KisGokeiGai(intKisCnt).BAISA = 0 '����
						' 2007/01/13  ADD END
						
					End If
					
					'�O�f�[�^�̏��i�Q�ƈقȂ�ꍇ
					If Wk_KisCd <> .SYOHIN Then
						'�s�ǉ�
						intRowCnt = intRowCnt + 1
						
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'�s���ڏ��R�s�[
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�@�@" & .SYOHIN

                        '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                        '����
                        'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                        'change 20190403 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                        'change 20190403 END saiki
                        Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						' 2007/01/12  ADD START  KUMEDA   *** ���i�Q���v�ǉ�
						If bufRowCnt <> 0 Then
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.DIVISION = "3"
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_UODSU_T = sumUODSU
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_UODKN_T = sumUODKN
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_SIKKN_T = sumSIKKN
							pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BAISA_T = sumBAISA
							If sumUODKN = 0 Then
								pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BSART_T = 0
							Else
								pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(sumBAISA / sumUODKN * 100, 1)
							End If

                            'change 20190403 START saiki
                            'With pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf
                            '	'�󒍐�
                            '	'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                            '	Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	'�󒍋��z
                            '	'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                            '	Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	'�d��
                            '	'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                            '	Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	'����
                            '	'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                            '	Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	'������
                            '	If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            '		'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            '		Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	Else
                            '		'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                            '		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                            '	End If
                            '                     End With


                            With pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                                End If
                            End With
                            'change 20190403 END saiki
                        End If
						'���i�Q���v���[�N�̏�����
						bufRowCnt = intRowCnt
						sumUODSU = 0
						sumUODKN = 0
						sumSIKKN = 0
						sumBAISA = 0
						' 2007/01/12  ADD END
					End If
					
					'�s�ǉ�
					intRowCnt = intRowCnt + 1
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
					'�s���ڏ��R�s�[
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
					
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�@�@�@�@" & .NAIGAINM
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.DIVISION = "2"
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODSU_T = .UODSU '�󒍐�
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODKN_T = .UODKN '�󒍋��z
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_SIKKN_T = .SIKKN '�d��
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BAISA_T = .BAISA '����
					If .UODKN = 0 Then
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = 0
					Else
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(.BAISA / .UODKN * 100, 1) '������
					End If
					
					' 2007/01/12  ADD START  KUMEDA   *** ���i�Q���v
					sumUODSU = sumUODSU + .UODSU
					sumUODKN = sumUODKN + .UODKN
					sumSIKKN = sumSIKKN + .SIKKN
					sumBAISA = sumBAISA + .BAISA
                    ' 2007/01/12  ADD END

                    'change 20190403 START saiki
                    ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    'With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                    '	'����
                    '	'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'�󒍐�
                    '	'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'�󒍋��z
                    '	'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'�d��
                    '	'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'����
                    '	'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'������
                    '	If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    '		'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    '		Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	Else
                    '		'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                    '		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	End If
                    '               End With


                    '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                        '����
                        'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '�󒍐�
                        'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '�󒍋��z
                        'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '�d��
                        'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '����
                        'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '������
                        If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                            Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        Else
                            'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                            Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        End If
                    End With
                    'change 20190403 END saiki

                    '���i�Q���v�v�Z
                    KisGokei(intKisCnt).UODSU = KisGokei(intKisCnt).UODSU + .UODSU '�󒍐���
					KisGokei(intKisCnt).UODKN = KisGokei(intKisCnt).UODKN + .UODKN '�󒍋��z
					KisGokei(intKisCnt).SIKKN = KisGokei(intKisCnt).SIKKN + .SIKKN '�d��
					KisGokei(intKisCnt).BAISA = KisGokei(intKisCnt).BAISA + .BAISA '����
					' 2007/01/13  ADD START  KUMEDA
					If .NAIGAICD = "0" Then '�������v
						KisGokeiNai(intKisCnt).UODSU = KisGokeiNai(intKisCnt).UODSU + .UODSU '�󒍐���
						KisGokeiNai(intKisCnt).UODKN = KisGokeiNai(intKisCnt).UODKN + .UODKN '�󒍋��z
						KisGokeiNai(intKisCnt).SIKKN = KisGokeiNai(intKisCnt).SIKKN + .SIKKN '�d��
						KisGokeiNai(intKisCnt).BAISA = KisGokeiNai(intKisCnt).BAISA + .BAISA '����
					Else
						KisGokeiGai(intKisCnt).UODSU = KisGokeiGai(intKisCnt).UODSU + .UODSU '�󒍐���
						KisGokeiGai(intKisCnt).UODKN = KisGokeiGai(intKisCnt).UODKN + .UODKN '�󒍋��z
						KisGokeiGai(intKisCnt).SIKKN = KisGokeiGai(intKisCnt).SIKKN + .SIKKN '�d��
						KisGokeiGai(intKisCnt).BAISA = KisGokeiGai(intKisCnt).BAISA + .BAISA '����
					End If
					' 2007/01/13  ADD END
					
					'���f�[�^�̑ޔ�
					Wk_KisCd = .SYOHIN
					' 2007/01/10  ADD START  KUMEDA
					Wk_GrpCd = .HGROUP
					' 2007/01/10  ADD END
				End With
			Next 
			
			' 2007/01/12  ADD START  KUMEDA   *** �ŏI�̏��i�Q�̍��v�ǉ�
			If bufRowCnt <> 0 Then
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.DIVISION = "3"
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_UODSU_T = sumUODSU
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_UODKN_T = sumUODKN
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_SIKKN_T = sumSIKKN
				pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BAISA_T = sumBAISA
				If sumUODKN = 0 Then
					pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BSART_T = 0
				Else
					pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(sumBAISA / sumUODKN * 100, 1)
				End If

                'change 20190325 START saiki
                'With pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf
                '	'�󒍐�
                '	'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	'�󒍋��z
                '	'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	'�d��
                '	'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	'����
                '	'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	'������
                '	If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '		'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '		Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	Else
                '		'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                '	End If
                '            End With


                With pm_All.Dsp_Body_Inf.Row_Inf(bufRowCnt).Bus_Inf
                    '�󒍐�
                    'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    '�󒍋��z
                    'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    '�d��
                    'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    '����
                    'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    '������
                    If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    Else
                        'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufRowCnt, pm_All, SET_FLG_DB)
                    End If
                End With
                'change 20190325 END saiki
            End If
			' 2007/01/12  ADD END
			
			' 2007/01/13  CHG START  KUMEDA   ---> intRowCnt �� bufGrpCnt �ɕύX
			'�ŏI�̏��i�Q�O���[�v�̍��v�s���쐬
			'�s�ǉ�
			''        intRowCnt = intRowCnt + 1
			''        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			''        '�s���ڏ��R�s�[
			''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = KisGokei(intKisCnt).SYOHIN '���i�Q
				.DIVISION = "1"
				.BD_UODSU_T = KisGokei(intKisCnt).UODSU '�󒍐�
				.BD_UODKN_T = KisGokei(intKisCnt).UODKN '�󒍋��z
				.BD_SIKKN_T = KisGokei(intKisCnt).SIKKN '�d��
				.BD_BAISA_T = KisGokei(intKisCnt).BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                'change 20190325 START saiki
                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                ''����
                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''�󒍐�
                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''�󒍋��z
                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''�d��
                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''����
                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                ''������
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '            End If


                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '����
                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                '������
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			'---> �����A�C�O�f�[�^�̍��v�s�ǉ�
			With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCntNai).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = KisGokeiNai(intKisCnt).SYOHIN '���i�Q
				.DIVISION = "2"
				.BD_UODSU_T = KisGokeiNai(intKisCnt).UODSU '�󒍐�
				.BD_UODKN_T = KisGokeiNai(intKisCnt).UODKN '�󒍋��z
				.BD_SIKKN_T = KisGokeiNai(intKisCnt).SIKKN '�d��
				.BD_BAISA_T = KisGokeiNai(intKisCnt).BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                'change 20190325 START saiki
                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                ''����
                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''�󒍐�
                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''�󒍋��z
                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''�d��
                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''����
                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                ''������
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '            End If

                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '����
                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                '������
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntNai, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			With pm_All.Dsp_Body_Inf.Row_Inf(bufGrpCntGai).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = KisGokeiGai(intKisCnt).SYOHIN '���i�Q
				.DIVISION = "2"
				.BD_UODSU_T = KisGokeiGai(intKisCnt).UODSU '�󒍐�
				.BD_UODKN_T = KisGokeiGai(intKisCnt).UODKN '�󒍋��z
				.BD_SIKKN_T = KisGokeiGai(intKisCnt).SIKKN '�d��
				.BD_BAISA_T = KisGokeiGai(intKisCnt).BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                'change 20190325 START saiki
                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                ''����
                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''�󒍐�
                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''�󒍋��z
                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''�d��
                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''����
                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                ''������
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '            End If


                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '����
                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                '������
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), bufGrpCntGai, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			'<--- �����A�C�O�f�[�^�̍��v�s�ǉ�
			' 2007/01/13  CHG END
			
			'���v�v�Z
			For intData = 1 To intKisCnt
				SumGokei.UODSU = SumGokei.UODSU + KisGokei(intData).UODSU '�󒍐���
				SumGokei.UODKN = SumGokei.UODKN + KisGokei(intData).UODKN '�󒍋��z
				SumGokei.SIKKN = SumGokei.SIKKN + KisGokei(intData).SIKKN '�d��
				SumGokei.BAISA = SumGokei.BAISA + KisGokei(intData).BAISA '����
				' 2007/01/13  ADD START  KUMEDA   '�������v�A�C�O���v
				SumGokeiNai.UODSU = SumGokeiNai.UODSU + KisGokeiNai(intData).UODSU '�󒍐���
				SumGokeiNai.UODKN = SumGokeiNai.UODKN + KisGokeiNai(intData).UODKN '�󒍋��z
				SumGokeiNai.SIKKN = SumGokeiNai.SIKKN + KisGokeiNai(intData).SIKKN '�d��
				SumGokeiNai.BAISA = SumGokeiNai.BAISA + KisGokeiNai(intData).BAISA '����
				SumGokeiGai.UODSU = SumGokeiGai.UODSU + KisGokeiGai(intData).UODSU '�󒍐���
				SumGokeiGai.UODKN = SumGokeiGai.UODKN + KisGokeiGai(intData).UODKN '�󒍋��z
				SumGokeiGai.SIKKN = SumGokeiGai.SIKKN + KisGokeiGai(intData).SIKKN '�d��
				SumGokeiGai.BAISA = SumGokeiGai.BAISA + KisGokeiGai(intData).BAISA '����
				' 2007/01/13  ADD END
			Next 
			
			'���v�s�̍쐬
			' 2007/01/13  ADD START  KUMEDA
			'�󔒍s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			' 2007/01/13  ADD END
			
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = Wk_DivNm & "���v"
				.DIVISION = "99"
				.BD_UODSU_T = SumGokei.UODSU '�󒍐�
				.BD_UODKN_T = SumGokei.UODKN '�󒍋��z
				.BD_SIKKN_T = SumGokei.SIKKN '�d��
				.BD_BAISA_T = SumGokei.BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                'change 20190325 START saiki
                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                ''����
                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍐�
                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍋��z
                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�d��
                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''����
                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''������
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '����
                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '������
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			'---> �������v�A�C�O���v�̕\���ǉ�
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = "�@�@" & "�@�@����" '���i�Q
				.DIVISION = "2"
				.BD_UODSU_T = SumGokeiNai.UODSU '�󒍐�
				.BD_UODKN_T = SumGokeiNai.UODKN '�󒍋��z
				.BD_SIKKN_T = SumGokeiNai.SIKKN '�d��
				.BD_BAISA_T = SumGokeiNai.BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                'change 20190325 START saiki
                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                ''����
                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍐�
                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍋��z
                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�d��
                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''����
                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''������
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '����
                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '������
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = "�@�@" & "�@�@�C�O" '���i�Q
				.DIVISION = "2"
				.BD_UODSU_T = SumGokeiGai.UODSU '�󒍐�
				.BD_UODKN_T = SumGokeiGai.UODKN '�󒍋��z
				.BD_SIKKN_T = SumGokeiGai.SIKKN '�d��
				.BD_BAISA_T = SumGokeiGai.BAISA '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                'change 20190325 START saiki
                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                ''����
                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍐�
                ''UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍋��z
                ''UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�d��
                ''UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''����
                ''UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''������
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '����
                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODSU(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_UODKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_SIKKN(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL71.BD_BAISA(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '������
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL71.BD_BSART(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			'<--- �������v�A�C�O���v�̕\���ǉ�
			
			'        '���v�s�̍쐬
			'        '�s�ǉ�
			'        intRowCnt = intRowCnt + 1
			'        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'        '�s���ڏ��R�s�[
			'        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			'
			'        With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
			'            .Selected = False
			'            .MEISYO = "���v"
			'            .BD_UODSU_T = SumGokei.UODSU   '�󒍐�
			'            .BD_UODKN_T = SumGokei.UODKN   '�󒍋��z
			'            .BD_SIKKN_T = SumGokei.SIKKN   '�d��
			'            .BD_BAISA_T = SumGokei.BAISA   '����
			'            If .BD_UODKN_T = 0 Then
			'                .BD_BSART_T = 0
			'            Else
			'                .BD_BSART_T = Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
			'            End If
			'
			'            '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
			'            '����
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '�󒍐�
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_UODSU(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '�󒍋��z
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_UODKN(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '�d��
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_SIKKN(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '����
			'            Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_BAISA(1).Tag)
			'            Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            '������
			'            If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
			'                Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
			'                Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            Else
			'                Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.BD_BSART(1).Tag)
			'                Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
			'            End If
			'        End With
			
			'�s���\���̔z��� Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
			
			NowPageNum = 1
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' 2007/03/04  ADD START  KUMEDA
		Call CF_Clr_Prompt(pm_All)
		' 2007/03/04  ADD END
		
		F_GET_BD_DATA_KIS_SOUKATU = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA_KIS_SOUKATU: 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_KIS_MEISAI_JUC_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k�����i�@�햾�ו\�F�󒍁j
	'   �����F�@pm_Kind         1:�������A2:�����
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KIS_MEISAI_JUC_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'�����J�n���̎擾
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     Max(WAKU.HINDSP) As HINDSP "
		strSQL = strSQL & "    ,WAKU.HINGRPNM As SYOHIN "
		strSQL = strSQL & "    ,WAKU.HINGRPRM As SYOHINRM "
		strSQL = strSQL & "    ,WAKU.HINBRNMA As HINBRNMA "
		strSQL = strSQL & "    ,WAKU.HINBRNMB As HINBRNMB "
		strSQL = strSQL & "    ,WAKU.HINBRNMC As HINBRNMC "
		strSQL = strSQL & "    ,Sum(MAIN.UODSU) As UODSU "
		strSQL = strSQL & "    ,Round(Sum(MAIN.UODKN)) As UODKN "
		strSQL = strSQL & "    ,Round(Sum(MAIN.SIKKN)) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             PCODE "
		strSQL = strSQL & "            ,Sum(UODSU) As UODSU "
		strSQL = strSQL & "            ,Sum(UODKN) As UODKN "
		strSQL = strSQL & "            ,Sum(SIKKN) As SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             JDNDLA "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             JDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "         And JDNDT <= '" & GV_UNYDate & "' "
		
		If Trim(gv_UODDL71_TIKCD) <> "" Then
			strSQL = strSQL & "         And TIKKB = '" & gv_UODDL71_TIKCD & "' "
		End If
		
		If Trim(gv_UODDL71_EIGCD) <> "" Then
			strSQL = strSQL & "         And EIGYOCD = '" & gv_UODDL71_EIGCD & "' "
		End If
		
		If Trim(gv_UODDL71_BMNCD) <> "" Then
			strSQL = strSQL & "         And JIGYOBU = '" & gv_UODDL71_BMNCD & "' "
		End If
		
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             PCODE "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,("
		strSQL = strSQL & "         Select Distinct "
		strSQL = strSQL & "             HINDSP "
		strSQL = strSQL & "            ,HINGRPNM "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "            ,HINGRPRM "
		strSQL = strSQL & "            ,MEINMC HINGRPRM "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "            ,HINBRNMA "
		strSQL = strSQL & "            ,HINBRNMB "
		strSQL = strSQL & "            ,HINBRNMC "
		strSQL = strSQL & "            ,PCODE "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             KSYMTA "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,MEIMTC "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "         Where "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "             STTTKDT <= '" & GV_UNYDate & "' "
		'strSQL = strSQL & "         And ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "             MEIMTC.MEINMB = KSYMTA.HINGRPRM"
		strSQL = strSQL & "         And KSYMTA.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And KSYMTA.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEIMTC.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEIMTC.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.PCODE(+) = WAKU.PCODE "
		strSQL = strSQL & " Group By "
		strSQL = strSQL & "     WAKU.HINGRPNM "
		strSQL = strSQL & "    ,WAKU.HINGRPRM "
		strSQL = strSQL & "    ,WAKU.HINBRNMA "
		strSQL = strSQL & "    ,WAKU.HINBRNMB "
		strSQL = strSQL & "    ,WAKU.HINBRNMC "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     HINDSP "
		
		F_GET_KIS_MEISAI_JUC_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_KIS_MEISAI_URI_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k�����i�@�햾�ו\�F����j
	'   �����F�@pm_Kind         1:�������A2:�����
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KIS_MEISAI_URI_SQL(ByVal pm_Kind As String) As String
		
		Dim strSQL As String
		Dim StartDate As String
		
		'�����J�n���̎擾
		StartDate = F_GET_FIRSTDAY(pm_Kind, GV_UNYDate)
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     Max(WAKU.HINDSP) As HINDSP "
		strSQL = strSQL & "    ,WAKU.HINGRPNM As SYOHIN "
		strSQL = strSQL & "    ,WAKU.HINGRPRM As SYOHINRM "
		strSQL = strSQL & "    ,WAKU.HINBRNMA As HINBRNMA "
		strSQL = strSQL & "    ,WAKU.HINBRNMB As HINBRNMB "
		strSQL = strSQL & "    ,WAKU.HINBRNMC As HINBRNMC "
		strSQL = strSQL & "    ,Sum(MAIN.URISU) As UODSU "
		strSQL = strSQL & "    ,Round(Sum(MAIN.URIKN)) As UODKN "
		strSQL = strSQL & "    ,Round(Sum(MAIN.SIKKN)) As SIKKN "
		strSQL = strSQL & " From "
		strSQL = strSQL & "     ( "
		strSQL = strSQL & "         Select "
		strSQL = strSQL & "             PCODE "
		strSQL = strSQL & "            ,Sum(URISU) As URISU "
		strSQL = strSQL & "            ,Sum(URIKN) As URIKN "
		strSQL = strSQL & "            ,Sum(SIKKN) As SIKKN "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             UDNDLA "
		strSQL = strSQL & "         Where "
		strSQL = strSQL & "             UDNDT >= '" & StartDate & "' "
		strSQL = strSQL & "         And UDNDT <= '" & GV_UNYDate & "' "
		
		If Trim(gv_UODDL71_TIKCD) <> "" Then
			strSQL = strSQL & "         And TIKKB = '" & gv_UODDL71_TIKCD & "' "
		End If
		
		If Trim(gv_UODDL71_EIGCD) <> "" Then
			strSQL = strSQL & "         And EIGYOCD = '" & gv_UODDL71_EIGCD & "' "
		End If
		
		If Trim(gv_UODDL71_BMNCD) <> "" Then
			strSQL = strSQL & "         And JIGYOBU = '" & gv_UODDL71_BMNCD & "' "
		End If
		
		strSQL = strSQL & "         Group By "
		strSQL = strSQL & "             PCODE "
		strSQL = strSQL & "     ) MAIN "
		strSQL = strSQL & "    ,( "
		strSQL = strSQL & "        Select Distinct "
		strSQL = strSQL & "             HINDSP "
		strSQL = strSQL & "            ,HINGRPNM "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "            ,HINGRPRM "
		strSQL = strSQL & "            ,MEINMC HINGRPRM "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "            ,HINBRNMA "
		strSQL = strSQL & "            ,HINBRNMB "
		strSQL = strSQL & "            ,HINBRNMC "
		strSQL = strSQL & "            ,PCODE "
		strSQL = strSQL & "         From "
		strSQL = strSQL & "             KSYMTA "
		'2007/10/12 FKS)minamoto ADD START
		strSQL = strSQL & "            ,MEIMTC "
		'2007/10/12 FKS)minamoto ADD END
		strSQL = strSQL & "         Where "
		'2007/10/12 FKS)minamoto CHG START
		'strSQL = strSQL & "             STTTKDT <= '" & GV_UNYDate & "' "
		'strSQL = strSQL & "         And ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "             MEIMTC.MEINMB = KSYMTA.HINGRPRM"
		strSQL = strSQL & "         And KSYMTA.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And KSYMTA.ENDTKDT >= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEIMTC.STTTKDT <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "         And MEIMTC.ENDTKDT >= '" & GV_UNYDate & "' "
		'2007/10/12 FKS)minamoto CHG END
		strSQL = strSQL & "     ) WAKU "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     MAIN.PCODE(+) = WAKU.PCODE "
		strSQL = strSQL & " Group By "
		strSQL = strSQL & "     WAKU.HINGRPNM "
        strSQL = strSQL & "    ,WAKU.HINGRPRM "
        strSQL = strSQL & "    ,WAKU.HINBRNMA "
		strSQL = strSQL & "    ,WAKU.HINBRNMB "
		strSQL = strSQL & "    ,WAKU.HINBRNMC "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     HINDSP "
		
		F_GET_KIS_MEISAI_URI_SQL = strSQL
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_KIS_SOUKATU_JUC
	'   �T�v�F  �{�f�B���f�[�^�擾�i�@��ʑ����\�F�󒍁j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_MEISAI_JUC(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki

		
		'�����r�p�k����
		strSQL = F_GET_KIS_MEISAI_JUC_SQL(pm_Kind)
		
		Ret_Value = F_GET_BD_DATA_KIS_MEISAI(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
		'UPGRADE_ISSUE: Control lab_exc �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'delete 20190325 START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then
        '    Call F_Ctl_LAB_EXC(pm_All)
        'End If
        'delete 20190325 END saiki
		'ADD 20150710 END C2-20150708-01
		
		F_GET_BD_DATA_KIS_MEISAI_JUC = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_KIS_SOUKATU_URI
	'   �T�v�F  �{�f�B���f�[�^�擾�i�@��ʑ����\�F����j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_MEISAI_URI(ByVal pm_Kind As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim Ret_Value As Short

        'delete 20190327 START saiki
		'ADD 20150710 START C2-20150708-01
        'Call F_Ctl_LAB_EXC(pm_All)
        'ADD 20150710 END C2-20150708-01
        'delete 20190327 END saiki
		
		'�����r�p�k����
		strSQL = F_GET_KIS_MEISAI_URI_SQL(pm_Kind)
		
		Ret_Value = F_GET_BD_DATA_KIS_MEISAI(strSQL, pm_All)
		
		'ADD 20150710 START C2-20150708-01
		'UPGRADE_ISSUE: Control lab_exc �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'delete 20190325 START saiki
        'If pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False Then
        '    Call F_Ctl_LAB_EXC(pm_All)
        'End If
        'delete 20190325 END saiki
		'ADD 20150710 END C2-20150708-01
		
		F_GET_BD_DATA_KIS_MEISAI_URI = Ret_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_BD_DATA_BMN_SOUKATU
	'   �T�v�F  �{�f�B���f�[�^�擾�i����ʑ����\�j
	'   �����F  pm_Kind     1:�������A2:�����
	'           pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA_KIS_MEISAI(ByVal pm_SQL As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim intRowCnt As Short
		Dim intSyoCnt As Short
		Dim intBrACnt As Short
		Dim intBrBCnt As Short
		Dim SyoGokei() As UODDL71_TYPE_KISMEI
		Dim BrAGokei() As UODDL71_TYPE_KISMEI
		Dim BrBGokei() As UODDL71_TYPE_KISMEI
		Dim ZenGokei As UODDL71_TYPE_KISMEI
		Dim Wk_SyoCd As String
		Dim Wk_BrACd As String
		Dim Wk_BrBCd As String
		Dim Wk_BrCCd As String
		
		On Error GoTo ERR_F_GET_BD_DATA_KIS_MEISAI
		F_GET_BD_DATA_KIS_MEISAI = -1

        'UODDL712.BD_UODSU_T(1).Tag = pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag

        ' 2007/03/04  ADD START  KUMEDA
        Call FR_SSSMAIN2.Ctl_MN_APPENDC_Click()
		Call CF_Set_Prompt(DATE_GET_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), pm_All)
		System.Windows.Forms.Application.DoEvents()
		' 2007/03/04  ADD END
		
		'������
		Err_Cd = ""
		Wk_SyoCd = ""
		Wk_BrACd = ""
		Wk_BrBCd = ""
		Wk_BrCCd = ""
		ReDim SyoGokei(0)
		ReDim BrAGokei(0)
		ReDim BrBGokei(0)
		
		'�����r�p�k����
		strSQL = pm_SQL

        'DB�A�N�Z�X
        'change 20190403 START saiki
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change 20190403 END saiki

        'change 20190403 START saiki
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                'change 20190403 END saiki
                '�擾�f�[�^�Ȃ�
                F_GET_BD_DATA_KIS_MEISAI = 0
                Err_Cd = gc_strMsgUODDL71_E_002
                Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

                Exit Function
            Else

            intCnt = 0
            'change 20190403 START saiki
            '         Do Until CF_Ora_EOF(Usr_Ody) = True
            '	'�擾�S���R�[�h���{�f�B���ޔ�
            '	intCnt = intCnt + 1
            '	'�s�ǉ�
            '	ReDim Preserve UODDL71_KISMEI_Inf(intCnt)

            '	With UODDL71_KISMEI_Inf(intCnt)
            '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		.SYOHIN = CF_Ora_GetDyn(Usr_Ody, "SYOHIN", "") '���i�Q����
            '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		.SYOHINRM = CF_Ora_GetDyn(Usr_Ody, "SYOHINRM", "") '���i�Q����
            '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		.BUNRUIA = CF_Ora_GetDyn(Usr_Ody, "HINBRNMA", "") '���ނ`
            '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		.BUNRUIB = CF_Ora_GetDyn(Usr_Ody, "HINBRNMB", "") '���ނa
            '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		.BUNRUIC = CF_Ora_GetDyn(Usr_Ody, "HINBRNMC", "") '���ނb
            '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		.UODSU_T = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0) '�󒍐���
            '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		.UODKN_T = CF_Ora_GetDyn(Usr_Ody, "UODKN", 0) '�󒍋��z
            '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		.SIKKN_T = CF_Ora_GetDyn(Usr_Ody, "SIKKN", 0) '�d��
            '		.BAISA_T = .UODKN_T - .SIKKN_T '����
            '	End With

            '	'�����R�[�h
            '	Call CF_Ora_MoveNext(Usr_Ody)
            'Loop 

            For Each row As DataRow In dt.Rows
                '�擾�S���R�[�h���{�f�B���ޔ�
                intCnt = intCnt + 1
                '�s�ǉ�
                ReDim Preserve UODDL71_KISMEI_Inf(intCnt)

                With UODDL71_KISMEI_Inf(intCnt)
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SYOHIN = DB_NullReplace(row("SYOHIN"), "") '���i�Q����
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SYOHINRM = DB_NullReplace(row("SYOHINRM"), "") '���i�Q����
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .BUNRUIA = DB_NullReplace(row("HINBRNMA"), "") '���ނ`
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .BUNRUIB = DB_NullReplace(row("HINBRNMB"), "") '���ނa
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .BUNRUIC = DB_NullReplace(row("HINBRNMC"), "") '���ނb
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .UODSU_T = DB_NullReplace(row("UODSU"), 0) '�󒍐���
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .UODKN_T = DB_NullReplace(row("UODKN"), 0) '�󒍋��z
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SIKKN_T = DB_NullReplace(row("SIKKN"), 0) '�d��
                    .BAISA_T = .UODKN_T - .SIKKN_T '����
                End With

            Next
            'change 20190403 END saiki


            intRowCnt = 0
			intSyoCnt = 0
			intBrACnt = 0
			intBrBCnt = 0
			For intData = 1 To intCnt
				With UODDL71_KISMEI_Inf(intData)
					'�O�f�[�^�̏��i�Q�ƈقȂ�ꍇ
					If Wk_SyoCd <> .SYOHIN Then
						'���ނb������ꍇ�A�O�̕��ނa�̌v�s���쐬
						If Trim(Wk_BrCCd) <> "" Then
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								' 2007/03/04  CHG START  KUMEDA
								'                            .MEISYO = "�@�@�@�@-- �v --"
								.MEISYO = "�@�@�@�@-- " & Trim(BrBGokei(intBrBCnt).BUNRUIB) & "�v --"
								' 2007/03/04  CHG END
								.DIVISION = "3"
								.BD_UODSU_T = BrBGokei(intBrBCnt).UODSU_T '�󒍐�
								.BD_UODKN_T = BrBGokei(intBrBCnt).UODKN_T '�󒍋��z
								.BD_SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T '�d��
								.BD_BAISA_T = BrBGokei(intBrBCnt).BAISA_T '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                'change 20190325 START saiki
                                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                ''����
                                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍐�
                                ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍋��z
                                ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�d��
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''����
                                ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''������
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'���ނa������ꍇ�A�O�̕��ނ`�̌v�s���쐬
						If Trim(Wk_BrBCd) <> "" Then
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = "�@�@< " & Trim(BrAGokei(intBrACnt).BUNRUIA) & "�v >"
								.DIVISION = "2"
								.BD_UODSU_T = BrAGokei(intBrACnt).UODSU_T '�󒍐�
								.BD_UODKN_T = BrAGokei(intBrACnt).UODKN_T '�󒍋��z
								.BD_SIKKN_T = BrAGokei(intBrACnt).SIKKN_T '�d��
								.BD_BAISA_T = BrAGokei(intBrACnt).BAISA_T '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                'change 20190325 START saiki
                                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                ''����
                                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍐�
                                ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍋��z
                                ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�d��
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''����
                                ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''������
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'�ŏ��̏��i�Q�łȂ��ꍇ�A�O�̏��i�Q�̍��v�s���쐬
						If Trim(Wk_SyoCd) <> "" Then
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								' 2007/03/04  CHG START  KUMEDA
								'                            .MEISYO = "�` " & Trim(SyoGokei(intSyoCnt).SYOHINRM) & "���v �`"
								'2007/11/06 FKS)minamoto CHG START
								'.MEISYO = "�` " & Trim(SyoGokei(intSyoCnt).SYOHINRM) & "�v �`"
								.MEISYO = "�` " & Trim(SyoGokei(intSyoCnt).SYOHIN) & "�v �`"
								'2007/11/06 FKS)minamoto CHG END
								' 2007/030/4  CHG END
								.DIVISION = "1"
								.BD_UODSU_T = SyoGokei(intSyoCnt).UODSU_T '�󒍐�
								.BD_UODKN_T = SyoGokei(intSyoCnt).UODKN_T '�󒍋��z
								.BD_SIKKN_T = SyoGokei(intSyoCnt).SIKKN_T '�d��
								.BD_BAISA_T = SyoGokei(intSyoCnt).BAISA_T '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                'change 20190325 START saiki
                                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                ''����
                                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍐�
                                ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍋��z
                                ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�d��
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''����
                                ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''������
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'���i�Q�̃J�E���g
						intSyoCnt = intSyoCnt + 1
						'���i�Q���v�v�Z�p
						ReDim Preserve SyoGokei(intSyoCnt)
						SyoGokei(intSyoCnt).SYOHIN = .SYOHIN '���i�Q����
						SyoGokei(intSyoCnt).SYOHINRM = .SYOHINRM '���i�Q����
						SyoGokei(intSyoCnt).UODSU_T = 0 '�󒍐���
						SyoGokei(intSyoCnt).UODKN_T = 0 '�󒍋��z
						SyoGokei(intSyoCnt).SIKKN_T = 0 '�d��
						SyoGokei(intSyoCnt).BAISA_T = 0 '����
						
						'�s�ǉ�
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'�s���ڏ��R�s�[
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = .SYOHIN

                        '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                        '����
                        'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        'change 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                        'change 20190325 END saiki
                        Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
					
					'�O�f�[�^�̕��ނ`�ƈقȂ�ꍇ
					If Wk_BrACd <> .BUNRUIA Then
						'���ނb������ꍇ�A�O�̕��ނa�̌v�s���쐬�i�O�f�[�^�̏��i�Q�Ɠ����j
						If Trim(Wk_BrCCd) <> "" And Wk_SyoCd = .SYOHIN Then
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								' 2007/03/04  CHG START  KUMEDA
								'                            .MEISYO = "�@�@�@�@-- �v --"
								.MEISYO = "�@�@�@�@-- " & Trim(BrBGokei(intBrBCnt).BUNRUIB) & "�v --"
								' 2007/03/04  CHG END
								.DIVISION = "3"
								.BD_UODSU_T = BrBGokei(intBrBCnt).UODSU_T '�󒍐�
								.BD_UODKN_T = BrBGokei(intBrBCnt).UODKN_T '�󒍋��z
								.BD_SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T '�d��
								.BD_BAISA_T = BrBGokei(intBrBCnt).BAISA_T '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                'change 20190325 START saiki
                                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                ''����
                                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍐�
                                ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍋��z
                                ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�d��
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''����
                                ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''������
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'�ŏ��̕��ނ`�łȂ��ꍇ�A�O�̕��ނ`�̌v�s���쐬�i�O�f�[�^�̏��i�Q�Ɠ����j
						If Trim(Wk_BrACd) <> "" And Trim(Wk_BrBCd) <> "" And Wk_SyoCd = .SYOHIN Then
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								.MEISYO = "�@�@< " & Trim(BrAGokei(intBrACnt).BUNRUIA) & "�v >"
								.DIVISION = "2"
								.BD_UODSU_T = BrAGokei(intBrACnt).UODSU_T '�󒍐�
								.BD_UODKN_T = BrAGokei(intBrACnt).UODKN_T '�󒍋��z
								.BD_SIKKN_T = BrAGokei(intBrACnt).SIKKN_T '�d��
								.BD_BAISA_T = BrAGokei(intBrACnt).BAISA_T '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                '                        'change 20190325 START saiki
                                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                ''����
                                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍐�
                                ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍋��z
                                ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�d��
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''����
                                ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''������
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'���f�[�^�̕��ނ`������ꍇ
						If Trim(.BUNRUIA) <> "" Then
							'���ނ`�̃J�E���g
							intBrACnt = intBrACnt + 1
							'���ނ`���v�v�Z�p
							ReDim Preserve BrAGokei(intBrACnt)
							BrAGokei(intBrACnt).BUNRUIA = .BUNRUIA '���ނ`����
							BrAGokei(intBrACnt).UODSU_T = 0 '�󒍐���
							BrAGokei(intBrACnt).UODKN_T = 0 '�󒍋��z
							BrAGokei(intBrACnt).SIKKN_T = 0 '�d��
							BrAGokei(intBrACnt).BAISA_T = 0 '����
							
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�@�@" & .BUNRUIA

                            '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                            '����
                            'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            'change 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                            Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                            'change 20190325 END saiki
                            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End If
					
					'�O�f�[�^�̕��ނa�ƈقȂ�ꍇ
					If Wk_BrBCd <> .BUNRUIB Then
						'�ŏ��̕��ނa�łȂ��ꍇ�A�O�̕��ނa�̌v�s���쐬�i�O�f�[�^�̏��i�Q�A���ނ`�Ɠ����j
						If Trim(Wk_BrBCd) <> "" And Trim(Wk_BrCCd) <> "" And Wk_SyoCd = .SYOHIN And Wk_BrACd = .BUNRUIA Then
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
								.Selected = CStr(False)
								' 2007/03/04  CHG START  KUMEDA
								'                            .MEISYO = "�@�@�@�@-- �v --"
								.MEISYO = "�@�@�@�@-- " & Trim(BrBGokei(intBrBCnt).BUNRUIB) & "�v --"
								' 2007/03/04  CHG END
								.DIVISION = "3"
								.BD_UODSU_T = BrBGokei(intBrBCnt).UODSU_T '�󒍐�
								.BD_UODKN_T = BrBGokei(intBrBCnt).UODKN_T '�󒍋��z
								.BD_SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T '�d��
								.BD_BAISA_T = BrBGokei(intBrBCnt).BAISA_T '����
								If .BD_UODKN_T = 0 Then
									.BD_BSART_T = 0
								Else
									.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
								End If

                                'change 20190325 START saiki
                                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                ''����
                                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍐�
                                ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�󒍋��z
                                ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''�d��
                                ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''����
                                ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                ''������
                                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                'Else
                                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '                        End If


                                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                                '����
                                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍐�
                                'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�󒍋��z
                                'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '�d��
                                'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '����
                                'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                '������
                                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                Else
                                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                                End If
                                'change 20190325 END saiki
                            End With
						End If
						
						'���f�[�^�̕��ނa������ꍇ
						If Trim(.BUNRUIB) <> "" Then
							'���ނa�̃J�E���g
							intBrBCnt = intBrBCnt + 1
							'���ނa���v�v�Z�p
							ReDim Preserve BrBGokei(intBrBCnt)
							BrBGokei(intBrBCnt).BUNRUIB = .BUNRUIB '���ނa����
							BrBGokei(intBrBCnt).UODSU_T = 0 '�󒍐���
							BrBGokei(intBrBCnt).UODKN_T = 0 '�󒍋��z
							BrBGokei(intBrBCnt).SIKKN_T = 0 '�d��
							BrBGokei(intBrBCnt).BAISA_T = 0 '����
							
							'�s�ǉ�
							intRowCnt = intRowCnt + 1
							ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
							'�s���ڏ��R�s�[
							Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
							
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
							pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�@�@�@�@" & .BUNRUIB

                            '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                            '����
                            'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            'change 20190325 START saiki
                            'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                            Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                            'change 20190325 END saiki
                            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
						End If
					End If
					
					'���f�[�^�̕��ނb������ꍇ
					If Trim(.BUNRUIC) <> "" Then
						'�s�ǉ�
						intRowCnt = intRowCnt + 1
						ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
						'�s���ڏ��R�s�[
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
						
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.Selected = CStr(False)
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO = "�@�@�@�@�@�@" & .BUNRUIC

                        '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                        '����
                        'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        'change 20190325 START saiki
                        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                        Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                        'change 20190325 END saiki
                        Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
					End If
					
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODSU_T = .UODSU_T '�󒍐�
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_UODKN_T = .UODKN_T '�󒍋��z
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_SIKKN_T = .SIKKN_T '�d��
					pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BAISA_T = .BAISA_T '����
					If .UODKN_T = 0 Then
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = 0
					Else
						pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf.BD_BSART_T = System.Math.Round(.BAISA_T / .UODKN_T * 100, 1) '������
					End If

                    'change 20190325 START saiki
                    ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    'With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                    '	'�󒍐�
                    '	'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'�󒍋��z
                    '	'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'�d��
                    '	'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'����
                    '	'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	'������
                    '	If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    '		'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '		Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	Else
                    '		'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '		Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '	End If
                    '               End With


                    '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
                        '�󒍐�
                        'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '�󒍋��z
                        'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '�d��
                        'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '����
                        'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        '������
                        If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                            'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                            Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        Else
                            'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                            Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                            Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                        End If
                    End With
                    'change 20190325 END saiki

                    '���ނa���v�v�Z
                    If .BUNRUIB <> "" Then
						BrBGokei(intBrBCnt).UODSU_T = BrBGokei(intBrBCnt).UODSU_T + .UODSU_T '�󒍐���
						BrBGokei(intBrBCnt).UODKN_T = BrBGokei(intBrBCnt).UODKN_T + .UODKN_T '�󒍋��z
						BrBGokei(intBrBCnt).SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T + .SIKKN_T '�d��
						BrBGokei(intBrBCnt).BAISA_T = BrBGokei(intBrBCnt).BAISA_T + .BAISA_T '����
					End If
					
					'���ނ`���v�v�Z
					If .BUNRUIA <> "" Then
						BrAGokei(intBrACnt).UODSU_T = BrAGokei(intBrACnt).UODSU_T + .UODSU_T '�󒍐���
						BrAGokei(intBrACnt).UODKN_T = BrAGokei(intBrACnt).UODKN_T + .UODKN_T '�󒍋��z
						BrAGokei(intBrACnt).SIKKN_T = BrAGokei(intBrACnt).SIKKN_T + .SIKKN_T '�d��
						BrAGokei(intBrACnt).BAISA_T = BrAGokei(intBrACnt).BAISA_T + .BAISA_T '����
					End If
					
					'���i�Q���v�v�Z
					SyoGokei(intSyoCnt).UODSU_T = SyoGokei(intSyoCnt).UODSU_T + .UODSU_T '�󒍐���
					SyoGokei(intSyoCnt).UODKN_T = SyoGokei(intSyoCnt).UODKN_T + .UODKN_T '�󒍋��z
					SyoGokei(intSyoCnt).SIKKN_T = SyoGokei(intSyoCnt).SIKKN_T + .SIKKN_T '�d��
					SyoGokei(intSyoCnt).BAISA_T = SyoGokei(intSyoCnt).BAISA_T + .BAISA_T '����
					
					'���f�[�^�̑ޔ�
					Wk_SyoCd = .SYOHIN
					Wk_BrACd = .BUNRUIA
					Wk_BrBCd = .BUNRUIB
					Wk_BrCCd = .BUNRUIC
				End With
			Next 
			
			'���ނb������ꍇ�A�ŏI�̕��ނa�̌v�s���쐬
			If Trim(Wk_BrCCd) <> "" Then
				'�s�ǉ�
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'�s���ڏ��R�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					' 2007/03/04  CHG START  KUMEDA
					'                .MEISYO = "�@�@�@�@-- �v --"
					.MEISYO = "�@�@�@�@-- " & Trim(BrBGokei(intBrBCnt).BUNRUIB) & "�v --"
					' 2007/03/04  CHG END
					.DIVISION = "3"
					.BD_UODSU_T = BrBGokei(intBrBCnt).UODSU_T '�󒍐�
					.BD_UODKN_T = BrBGokei(intBrBCnt).UODKN_T '�󒍋��z
					.BD_SIKKN_T = BrBGokei(intBrBCnt).SIKKN_T '�d��
					.BD_BAISA_T = BrBGokei(intBrBCnt).BAISA_T '����
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
					End If

                    'change 20190325 START saiki
                    ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    ''����
                    ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''�󒍐�
                    ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''�󒍋��z
                    ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''�d��
                    ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''����
                    ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''������
                    'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    'Else
                    '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '               End If

                    '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    '����
                    'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '�󒍐�
                    'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '�󒍋��z
                    'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '�d��
                    'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '����
                    'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '������
                    If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    Else
                        'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    End If
                    'change 20190325 END saiki
                End With
			End If
			
			'���ނa������ꍇ�A�ŏI�̕��ނ`�̌v�s���쐬
			If Trim(Wk_BrBCd) <> "" Then
				'�s�ǉ�
				intRowCnt = intRowCnt + 1
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
				'�s���ڏ��R�s�[
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
					.Selected = CStr(False)
					.MEISYO = "�@�@< " & Trim(BrAGokei(intBrACnt).BUNRUIA) & "�v >"
					.DIVISION = "2"
					.BD_UODSU_T = BrAGokei(intBrACnt).UODSU_T '�󒍐�
					.BD_UODKN_T = BrAGokei(intBrACnt).UODKN_T '�󒍋��z
					.BD_SIKKN_T = BrAGokei(intBrACnt).SIKKN_T '�d��
					.BD_BAISA_T = BrAGokei(intBrACnt).BAISA_T '����
					If .BD_UODKN_T = 0 Then
						.BD_BSART_T = 0
					Else
						.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
					End If

                    'change 20190325 START saiki
                    ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    ''����
                    ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''�󒍐�
                    ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''�󒍋��z
                    ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''�d��
                    ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''����
                    ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                    'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    ''������
                    'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    'Else
                    '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                    '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '               End If

                    '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                    '����
                    'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '�󒍐�
                    'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '�󒍋��z
                    'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '�d��
                    'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '����
                    'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    '������
                    If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                        'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    Else
                        'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                    End If
                    'change 20190325 END saiki
                End With
			End If
			
			'�ŏI�̏��i�Q�̍��v�s���쐬
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				' 2007/03/04  CHG START  KUMEDA
				'            .MEISYO = "�` " & Trim(SyoGokei(intSyoCnt).SYOHINRM) & "���v �`"
				'2007/11/06 FKS)minamoto CHG START
				'.MEISYO = "�` " & Trim(SyoGokei(intSyoCnt).SYOHINRM) & "�v �`"
				.MEISYO = "�` " & Trim(SyoGokei(intSyoCnt).SYOHIN) & "�v �`"
				'2007/11/06 FKS)minamoto CHG END
				' 2007/03/04  CHG END
				.DIVISION = "1"
				.BD_UODSU_T = SyoGokei(intSyoCnt).UODSU_T '�󒍐�
				.BD_UODKN_T = SyoGokei(intSyoCnt).UODKN_T '�󒍋��z
				.BD_SIKKN_T = SyoGokei(intSyoCnt).SIKKN_T '�d��
				.BD_BAISA_T = SyoGokei(intSyoCnt).BAISA_T '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                'change 20190325 START saiki
                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                ''����
                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍐�
                ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍋��z
                ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�d��
                ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''����
                ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''������
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '����
                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '������
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			'�����v�̍쐬
			For intData = 1 To intSyoCnt
				With SyoGokei(intData)
					ZenGokei.UODSU_T = ZenGokei.UODSU_T + .UODSU_T '�󒍐���
					ZenGokei.UODKN_T = ZenGokei.UODKN_T + .UODKN_T '�󒍋��z
					ZenGokei.SIKKN_T = ZenGokei.SIKKN_T + .SIKKN_T '�d��
					ZenGokei.BAISA_T = ZenGokei.BAISA_T + .BAISA_T '����
				End With
			Next 
			
			'�����v�s�̍쐬
			'�s�ǉ�
			intRowCnt = intRowCnt + 1
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt)
			'�s���ڏ��R�s�[
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt))
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intRowCnt).Bus_Inf
				.Selected = CStr(False)
				.MEISYO = "���v"
				.DIVISION = "99"
				.BD_UODSU_T = ZenGokei.UODSU_T '�󒍐�
				.BD_UODKN_T = ZenGokei.UODKN_T '�󒍋��z
				.BD_SIKKN_T = ZenGokei.SIKKN_T '�d��
				.BD_BAISA_T = ZenGokei.BAISA_T '����
				If .BD_UODKN_T = 0 Then
					.BD_BSART_T = 0
				Else
					.BD_BSART_T = System.Math.Round(.BD_BAISA_T / .BD_UODKN_T * 100, 1) '������
				End If

                'change 20190325 START saiki
                ''��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                ''����
                ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_MEISYO(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍐�
                ''UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODSU_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�󒍋��z
                ''UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_UODKN_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''�d��
                ''UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_SIKKN_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''����
                ''UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BAISA_T(1).Tag)
                'Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                ''������
                'If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                'Else
                '	'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '	Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.BD_BSART_T(1).Tag)
                '	Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '            End If


                '��ʃ{�f�B���(PM_ALL.Dsp_Body_Inf)�ɕҏW
                '����
                'UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_MEISYO(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.MEISYO, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍐�
                'UPGRADE_ISSUE: Control BD_UODSU_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_UODSU_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODSU_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�󒍋��z
                'UPGRADE_ISSUE: Control BD_UODKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_UODKN_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_UODKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '�d��
                'UPGRADE_ISSUE: Control BD_SIKKN_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_SIKKN_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_SIKKN_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '����
                'UPGRADE_ISSUE: Control BD_BAISA_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                Wk_Index = CShort(UODDL712.BD_BAISA_T(1).Tag)
                Call CF_Edi_Dsp_Body_Inf(.BD_BAISA_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                '������
                If (.BD_BSART_T <= 999.9) And (.BD_BSART_T >= -999.9) Then
                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.BD_BSART_T, pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                Else
                    'UPGRADE_ISSUE: Control BD_BSART_T �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    Wk_Index = CShort(UODDL712.BD_BSART_T(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), intRowCnt, pm_All, SET_FLG_DB)
                End If
                'change 20190325 END saiki
            End With
			
			'�s���\���̔z��� Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
			
			NowPageNum = 1
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' 2007/03/04  ADD START  KUMEDA
		Call CF_Clr_Prompt(pm_All)
		' 2007/03/04  ADD END
		
		F_GET_BD_DATA_KIS_MEISAI = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA_KIS_MEISAI: 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SET_BD_DATA
	'   �T�v�F  �{�f�B���f�[�^�擾
	'   �����F�@pm_All      :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SET_BD_DATA(ByRef pm_All As Cls_All) As Object
		
		Dim Row_Cnt As Short
		Dim Index_Cnt As Short
		Dim Bd_Index As Short
		
		'���וҏW
		Call CF_Body_Dsp(pm_All)
		
		If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN" Then
			'����ʑ����\���
			'�I�v�V�����{�^���g�p����
			For Row_Cnt = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
                With pm_All.Dsp_Base.FormCtl
                    'delete 20190325 START saiki
                    ''UPGRADE_ISSUE: Control BD_MEISYO �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    'If (Trim(.BD_MEISYO(Row_Cnt).Text) = Trim(gc_Sum_Text_Kei)) Or (Trim(.BD_MEISYO(Row_Cnt).Text) = Trim(gc_Sum_Text_Syokei)) Or (Trim(.BD_MEISYO(Row_Cnt).Text) = Trim(gc_Sum_Text_Gokei)) Or (Trim(.BD_MEISYO(Row_Cnt).Text) = "") Then
                    '    '�W�v���A�܂��͋󗓂̏ꍇ
                    '    'UPGRADE_ISSUE: Control BD_SELECTB �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '    .BD_SELECTB(Row_Cnt).Enabled = False

                    'Else
                    '    '����A�n��A�c�Ɨ��̏ꍇ
                    '    'UPGRADE_ISSUE: Control BD_SELECTB �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                    '    .BD_SELECTB(Row_Cnt).Enabled = True

                    'End If
                    'delete 20190325 END saiki
                End With
			Next 
			
			For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name <> "BD_SELECTB" Then
					'Dsp_Body_Inf�̍s�m�n�擾
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Cnt), pm_All)
					
					'�w�i�F����
					Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DIVISION
						Case "1"
							'����
							pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTGREEN)
						Case "2"
							'�n��
							pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_BLUE)
						Case "99"
							'�S��
							pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_GREEN)
					End Select
				End If
				
				If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name = "BD_BSART" Then
					'�������̔w�i�F����
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Detail.Dsp_Value) <> "") And (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt).Detail.Dsp_Value) = "") Then
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = ACE_CMN.COLOR_RED
                        'delete 20190325 START saiki
                        'Else
                        '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '                   pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor)
                        'delete 20190325 END saiki
					End If
				End If
			Next 
			
		ElseIf pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN1" Then 
			'�@��ʑ����\���
			For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				'Dsp_Body_Inf�̍s�m�n�擾
				Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Cnt), pm_All)
				
				'�w�i�F����
				Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DIVISION
					Case "1"
						'���i�Q�O���[�v�ʍ��v
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTGREEN)
						' 2007/01/12  ADD START  KUMEDA
					Case "3"
						'���i�Q�ʍ��v
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_BLUE)
						' 2007/01/12  ADD END
					Case "99"
						'�����v
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_GREEN)
				End Select
				If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name = "BD_BSART" Then
					'�������̔w�i�F����
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Detail.Dsp_Value) <> "") And (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt).Detail.Dsp_Value) = "") Then
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = ACE_CMN.COLOR_RED
                        'delete 20190325 START saiki
                        'Else
                        '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '                   pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor)
                        'delete 20190325 END saiki
					End If
				End If
			Next 
			
		ElseIf pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN2" Then 
			'�@�햾�ו\���
			For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				'Dsp_Body_Inf�̍s�m�n�擾
				Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Cnt), pm_All)
				
				'�w�i�F����
				Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DIVISION
					Case "1"
						'���i�Q���v
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTGREEN)
					Case "2"
						'���ނ`���v
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_BLUE)
					Case "3"
						'���ނa���v
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTYELLOW)
					Case "99"
						'�����v
						pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_GREEN)
				End Select
				
				If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name = "BD_BSART_T" Then
					'�������̔w�i�F����
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Detail.Dsp_Value) <> "") And (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt).Detail.Dsp_Value) = "") Then
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = ACE_CMN.COLOR_RED
                        'delete 20190325 START saiki
                        'Else
                        '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '                   pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor)
                        'delete 20190325 END saiki
					End If
				End If
			Next 
		End If
		
	End Function
	
	
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
                'change start 20190805 kuwahara
                '÷���ޯ���̏ꍇ()
                '���݂�÷�ď�̑I����Ԃ��擾()
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                'change end 20190805 kuwahara

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
			' 2006/12/18  CHG START  KUMEDA
			'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
			Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
			' 2006/12/18  CHG END
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
            'change start 20190805 kuwahara
            '÷���ޯ���̏ꍇ()
            '���݂�÷�ď�̑I����Ԃ��擾()
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            'change end 20190805 kuwahara

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

                    'change start 20190805 kuwa
                    ''�ҏW���SelStart������
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart + 1
                    ''�ҏW���SelLength������
                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '               pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                    'change end 20190805 kuwahara

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
                            'change start 20190805 kuwahara
                            ''�ҏW��̕�����MAX�̏ꍇ
                            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(wk_Moji)
                            ''�ҏW���SelLength������
                            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                            'change end 20190805
                            '����̫����ʒu����E�ֈړ�
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                        End If
					End If
					
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
                                    'change start 20190805 kuwahara
                                    '�ҏW���SelStart������
                                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                    ''�ҏW���SelLength������
                                    ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '                           pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                    'change end 20190805 kuwahara
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

                        'change start 20190805 kuwahara
                        '�ҏW���SelStart������
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        ''�ҏW���SelLength������
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '                  pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        'change end 20190805 kuwahara

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
                                'change start 20190805 kuwahara
                                ''�ҏW���SelStart������
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(Wk_DspMoji)
                                ''�ҏW���SelLength������
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                                'change end 20190805 kuwahara
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
                        'change start 20190805 kuwahara
                        ''�ҏW���SelStart������
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        ''�ҏW���SelLength������
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        'change end 20190805 kuwahara
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
                                'change start 20190805 kuwahara
                                ''�ҏW���SelStart������
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                ''�ҏW���SelLength������
                                ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                'change end 20190805 kuwahara
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
                        'change start 20190805 kuwahara
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        'change end 20190805�@kuwahara

                        'add start 20190823 kuwa
                        '÷���ޯ�����󔒎��ɃG���^�[�������Ɖ��F�̃t�H�[�J�X���c��s����C��
                    Case System.Windows.Forms.Keys.Return
                        pm_Move_Flg = True
                        pm_KeyAscii = 0
                        'add end 20190823 kuwa
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
                'delete 20190325 START saiki
                '�E�N���b�N�����R���g���[�����A�N�e�B�u�ȃR���g���[���ƈ�v
                '�J�[�\������p�e�L�X�g�Ƀt�H�[�J�X���ꎞ�I�ɑޔ�
                'UPGRADE_ISSUE: Control TX_CursorRest �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.TX_CursorRest.Tag)
                'delete 20190325 END saiki
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
                bolSameCtl = True
            End If
            'delete 20190325 START saiki
            ''����ړ��e�R�s�[�����
            ''UPGRADE_ISSUE: Control SM_AllCopy �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'pm_All.Dsp_Base.FormCtl.SM_AllCopy = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)

            ''����ړ��e�ɓ\��t�������
            ''UPGRADE_ISSUE: Control SM_FullPast �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'pm_All.Dsp_Base.FormCtl.SM_FullPast = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
            'delete 20190325 END saiki
			'�ΏۃR���g���[���̎g�p�s��
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'��߯�߱����ƭ������
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'۽�̫�������Ă̗}��
				pm_All.Dsp_Base.LostFocus_Flg = True
				'�߯�߱����ƭ��\��
				'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: Control SM_ShortCut �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: Form ���\�b�h Dsp_Base.FormCtl.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                'delete 20190325 START saiki
                'pm_All.Dsp_Base.FormCtl.PopupMenu(pm_All.Dsp_Base.FormCtl.SM_ShortCut, vbPopupMenuLeftButton)
                'delete 20190325 END saiki
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
		Call CF_Body_Dsp(pm_All)
		
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
					' 2006/12/18  CHG START  KUMEDA
					'                Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
					Call CF_Set_Item_Color_MEISAI(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
					' 2006/12/18  CHG END
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
		
		'�ŏ㖾�ײ��ޯ����ޔ�
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		'�ŏ㖾�ײ��ޯ���ɐݒ�
		'�i��ʕ\�����א��|���E���א��j�~�i�y�[�W���|�P�j�{�P�@�@�˂P�A�U�A�P�P�A�P�U�ƂȂ�
		pm_All.Dsp_Body_Inf.Cur_Top_Index = (pm_All.Dsp_Base.Dsp_Body_Cnt - pm_Border_Body_Cnt) * (pm_Page_Value - 1) + 1
		'��ʕ\��
		Call CF_Body_Dsp(pm_All)
		
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
			If intAfrUBound >= intBfrUBound Then
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
					Call CF_Body_Dsp(pm_All)
					
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
		
		Dim Trg_Index As Short
        Dim Chk_Move_Flg As Boolean

        'add start 20190805 kuwa
        Dim form71 As Object

        If Trim(pm_All.Dsp_Base.FormCtl.Name) = "FR_SSSMAIN1" Then
            form71 = UODDL71
        Else
            form71 = UODDL712
        End If

        'add end 20190805 kuwa


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
						If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
							'�ŏI�����s�ȊO����ʏ�̍ŏI�s���ŏI����
							'����ړ������ꍇ�A̫����ړ��\�ȍs�����飏ꍇ
							
							'��ʂ̓��e��ޔ�
							Call CF_Body_Bkup(pm_All)
							'�ړ��\�s����ԉ��ɕ\�������ꍇ�̍ŏ㖾�׃C���f�b�N�X��ݒ�
							pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
							If pm_All.Bd_Vs_Scrl Is Nothing = False Then
								'�c�X�N���[���o�[��ݒ�
								Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
							End If
							'======================= �ύX���� 2006.07.02 Start =================================
							'��ʃ{�f�B���̔z����Đݒ�
							Call CF_Dell_Refresh_Body_Inf(pm_All)
							'======================= �ύX���� 2006.07.02 End =================================
							'��ʕ\��
							Call CF_Body_Dsp(pm_All)
							
							'���ׂP�ԉ��s�̓��͉\�ȍŏ��̃C���f�b�N�X���擾
							Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
							If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
								'���ׂP�ԉ��s�̍ŏ��̍��ڂ̈�O���猟��
								Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
							Else
								'�����J�n�͑Ώۂ̍��ڂ̎�
								Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							End If
							
						Else
							'����ړ������ꍇ�A̫����ړ��\�ȍs���Ȃ���ꍇ
							'�����J�n�͑Ώۂ̍��ڂ̎�
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
						End If
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
		
		'����̏ꍇ
		If (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_BMNCD") Then
			'�O��l�Ɠ��͒l���قȂ�ꍇ
			If pv_JYOKEN_INPUT = True Then
                '���͒l�̑ޔ�
                'UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwa
                'gv_UODDL71_BMNCD = pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text
                gv_UODDL71_BMNCD = pm_Dsp_Sub_Inf.Ctl.Text
                'change end 20190805 kuwa

                gv_UODDL71_TIKCD = ""
				gv_UODDL71_EIGCD = ""

                '�n��i�N���A�j
                'UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwa
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
                Trg_Index = CShort(form71.HD_TIKCD.Tag)
                'change end 20190805 kuwa
                Call CF_Set_Item_Direct(Space(2), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)

                '�c�Ə��i�N���A�j
                'UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwa
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
                Trg_Index = CShort(form71.HD_EIGCD.Tag)
                'change end 20190805 kuwa
                Call CF_Set_Item_Direct(Space(1), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)
			End If
		End If
		' 2007/01/17  ADD START  KUMEDA
		If Trim(gv_UODDL71_BMNCD) = "9" Then
			gv_UODDL71_BMNCD = " "
		End If
		If Trim(gv_UODDL71_TIKCD) = "99" Then
			gv_UODDL71_TIKCD = "  "
		End If
		If Trim(gv_UODDL71_EIGCD) = "9" Then
			gv_UODDL71_EIGCD = " "
		End If
        ' 2007/01/17  ADD END

        '�n��̏ꍇ
        If (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_TIKCD") Then
            '�O��l�Ɠ��͒l���قȂ�ꍇ
            If pv_JYOKEN_INPUT = True Then
                '���͒l�̑ޔ�
                gv_UODDL71_BMNCD = ""
                'UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwa
                'gv_UODDL71_TIKCD = pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text
                gv_UODDL71_TIKCD = pm_Dsp_Sub_Inf.Ctl.Text
                'change end 20190805 kuwa
                gv_UODDL71_EIGCD = ""

                '����i�N���A�j
                'UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwa
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
                Trg_Index = CShort(form71.HD_BMNCD.Tag)
                'change end 20190805 kuwa
                Call CF_Set_Item_Direct(Space(1), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)

                '�c�Ə��i�N���A�j
                'UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwa
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
                Trg_Index = CShort(form71.HD_EIGCD.Tag)
                'change end 20190805 kuwa
                Call CF_Set_Item_Direct(Space(1), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)
            End If
        End If
        ' 2007/01/17  ADD START  KUMEDA
        If Trim(gv_UODDL71_BMNCD) = "9" Then
			gv_UODDL71_BMNCD = " "
		End If
		If Trim(gv_UODDL71_TIKCD) = "99" Then
			gv_UODDL71_TIKCD = "  "
		End If
		If Trim(gv_UODDL71_EIGCD) = "9" Then
			gv_UODDL71_EIGCD = " "
		End If
        ' 2007/01/17  ADD END

        '�c�Ə��̏ꍇ
        If (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_EIGCD") Then
            '�O��l�Ɠ��͒l���قȂ�ꍇ
            If pv_JYOKEN_INPUT = True Then
                '���͒l�̑ޔ�
                gv_UODDL71_BMNCD = ""
                gv_UODDL71_TIKCD = ""
                'UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwahara
                'gv_UODDL71_EIGCD = pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text
                gv_UODDL71_EIGCD = pm_Dsp_Sub_Inf.Ctl.Text
                'change end 20190805 kuwahara
                ' 2007/01/17  ADD START  KUMEDA
                If Trim(gv_UODDL71_BMNCD) = "9" Then
                    gv_UODDL71_BMNCD = " "
                End If
                If Trim(gv_UODDL71_TIKCD) = "99" Then
                    gv_UODDL71_TIKCD = "  "
                End If
                If Trim(gv_UODDL71_EIGCD) = "9" Then
                    gv_UODDL71_EIGCD = " "
                End If
                ' 2007/01/17  ADD END
                '����i�N���A�j
                'UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwahara
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
                Trg_Index = CShort(form71.HD_BMNCD.Tag)
                'change end 20190805 kuwahara
                Call CF_Set_Item_Direct(Space(1), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)

                '�n��i�N���A�j
                'UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwahara
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
                Trg_Index = CShort(form71.HD_TIKCD.Tag)
                'change end 20190805 kuwahara
                Call CF_Set_Item_Direct(Space(2), pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_CLR, pm_All)
            End If
        End If

        '����or�n��or�c�Ə��̏ꍇ
        If (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_BMNCD") Or (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_TIKCD") Or (pm_Dsp_Sub_Inf.Detail.Item_Nm = "HD_EIGCD") Then
			
			'�O��l�Ɠ��͒l���قȂ�ꍇ
			If pv_JYOKEN_INPUT = True Then
				'ͯ�ޕ�����
				Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
				If Rtn_Chk = CHK_OK Then
					'�`�F�b�NOK�̏ꍇ
					If bolDsp = False Then
						'�܂���ʂɖ��ׂ�ҏW���Ă��Ȃ��ꍇ
						bolDsp = True
						
						If gv_UODDL71_JUC_URI = "1" Then
							'��
							If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN1" Then
								'�@��ʑ����\
								RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
							ElseIf pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN2" Then 
								'�@�햾�ו\
								RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)
							End If
						Else
							'����
							If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN1" Then
								'�@��ʑ����\
								RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
							ElseIf pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN2" Then 
								'�@�햾�ו\
								RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)
							End If
						End If
						
						If RtnCode = 0 Then
							'�o�͂ł��閾�׃f�[�^������
							Exit Function
						Else
							'���݂̃y�[�W��������
							NowPageNum = 1
							
							'�ŏ㖾�ײ��ޯ��������
							pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
							
							'���ׂ���ʂɕҏW
							Call F_DSP_BD_Inf(pm_Dsp_Sub_Inf, DSP_SET, pm_All)
						End If
					End If
				Else
					'�`�F�b�N�m�f�̏ꍇ
					Exit Function
				End If
			End If
		End If
		
		'���̍��ڂ�����
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
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
		
		'�ړ��\���ڂ��Ȃ��ꍇ
		If Index_Wk = pm_All.Dsp_Base.Item_Cnt + 1 Then
			'̫����ړ�
			Call F_Init_Cursor_Set(pm_All)
			
			'�ړ��t���O����
			pm_Move_Flg = True
		End If
		
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
            'change start 20190805 kuwahara
            '÷���ޯ���̏ꍇ()
            '���݂�÷�ď�̑I����Ԃ��擾()
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            'change end 20190805 kuwahara
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                '�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    'change start 20190805 kuwahara
                    '    '�l���������l�̏ꍇ
                    '    '�P�����ڂ�I������
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = 0
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                    'change end 20190805 kuwahara
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
                        'change start 20190805 kuwahara
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        'change end 20190805 kuwahara
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
            'delete 20190325 START saiki
            ''���݂�÷�ď�̑I����Ԃ��擾
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            'delete 20190325 END saiki
            'add 20190725 START hou
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            'add 20190725 END hou
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                'change start 20190805 kuwahara
                '�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '    '�l���������l�̏ꍇ
                    '    '�ŏI������I������
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                Else
                    '    '�l���������l�ȊO�̏ꍇ
                    '    '�P���ڂ�I������
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = 1
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                End If
                'change end 20190805 kuwahara
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
                            'change start 20190805 kuwahara
                            '    '�l���������l�̏ꍇ
                            '    '��ԉE�ֈړ����I���Ȃ���Ԃ�
                            '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '    pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '    pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                        Else
                            '    '�l���������l�ȊO�̏ꍇ
                            If Act_SelLength = 0 Then
                                '        '�ړ��O�̑I�𕶎������Ȃ��ꍇ
                                '        '��ԉE�ֈړ����I���Ȃ���Ԃ�
                                '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '        pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '        pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                            Else
                                'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
                                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                            End If
                            'change end 20190805 kuwahara
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
                            'change start 20190805 kuwahara
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Next_SelStart
                            ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                            'change end 20190805 kuwahara
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
				
				If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
					'���ڐ��𒴂����ꍇ
					'ENT�L�[�����Ɠ��l�Ɏ��̍��ڂ�
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
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
						Call CF_Body_Dsp(pm_All)
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
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
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
						Call CF_Body_Dsp(pm_All)
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
	'   ���́F  Function F_Chk_HD_BMNCD
	'   �T�v�F  ����R�[�h������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_BMNCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_MEIMTC
		Dim Mst_Inf_Clr As TYPE_DB_MEIMTC
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_BMNCD = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True

        '20190701 CHG START
        'Call DB_MEIMTC_Clear(Mst_Inf)
        Call InitDataCommon("MEIMTC")
        '20190701 CHG END

        '�����̓`�F�b�N
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			UODDL71_MEIMTC_Inf.DATKB = Mst_Inf_Clr.DATKB
			UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf_Clr.MEICDA '�R�[�h�P
			UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf_Clr.MEINMA '���̂P
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODDL71_E_001
			Else
				'�}�X�^�`�F�b�N
				If DSPMEIC_SEARCH(pc_Bmncd_Keycode, Input_Value, GV_UNYDate, Mst_Inf) = 0 Then
					'�_���폜�`�F�b�N
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODDL71_E_003
					Else
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						UODDL71_MEIMTC_Inf.DATKB = Mst_Inf.DATKB
						UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf.MEICDA '�R�[�h�P
						'''' UPD 2010/03/16  FKS) T.Yamamoto    Start    �A���[��CF09122201
						'                    UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf.MEINMA      '���̂P
						UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf.MEINMC '���̂R
						'''' UPD 2010/03/16  FKS) T.Yamamoto    End
					End If
					'�Y���f�[�^����
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgUODDL71_E_002
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
		
		F_Chk_HD_BMNCD = Retn_Code
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HD_TIKCD
	'   �T�v�F  ����R�[�h������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TIKCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_MEIMTC
		Dim Mst_Inf_Clr As TYPE_DB_MEIMTC
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_TIKCD = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
        pm_Chk_Move = True

        '20190701 CHG START
        'Call DB_MEIMTC_Clear(Mst_Inf)
        Call InitDataCommon("MEIMTC")
        '20190701 CHG END

        '�����̓`�F�b�N
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			UODDL71_MEIMTC_Inf.DATKB = Mst_Inf_Clr.DATKB
			UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf_Clr.MEICDA '�R�[�h�P
			UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf_Clr.MEINMA '���̂P
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODDL71_E_001
			Else
				'�}�X�^�`�F�b�N
				If DSPMEIC_SEARCH(pc_Tikcd_Keycode, Input_Value, GV_UNYDate, Mst_Inf) = 0 Then
					'�_���폜�`�F�b�N
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODDL71_E_003
					Else
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						UODDL71_MEIMTC_Inf.DATKB = Mst_Inf.DATKB
						UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf.MEICDA '�R�[�h�P
						UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf.MEINMA '���̂P
					End If
					'�Y���f�[�^����
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgUODDL71_E_002
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
		
		F_Chk_HD_TIKCD = Retn_Code
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HD_EIGCD
	'   �T�v�F  ����R�[�h������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_EIGCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_MEIMTC
		Dim Mst_Inf_Clr As TYPE_DB_MEIMTC
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_EIGCD = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True

        '20190701 CHG START
        'Call DB_MEIMTC_Clear(Mst_Inf)
        Call InitDataCommon("MEIMTC")
        '20190701 CHG END

        '�����̓`�F�b�N
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			UODDL71_MEIMTC_Inf.DATKB = Mst_Inf_Clr.DATKB
			UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf_Clr.MEICDA '�R�[�h�P
			UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf_Clr.MEINMA '���̂P
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODDL71_E_001
			Else
				'�}�X�^�`�F�b�N
				If DSPMEIC_SEARCH(pc_Eigcd_Keycode, Input_Value, GV_UNYDate, Mst_Inf) = 0 Then
					'�_���폜�`�F�b�N
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODDL71_E_003
					Else
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						UODDL71_MEIMTC_Inf.DATKB = Mst_Inf.DATKB
						UODDL71_MEIMTC_Inf.MEICDA = Mst_Inf.MEICDA '�R�[�h�P
						UODDL71_MEIMTC_Inf.MEINMA = Mst_Inf.MEINMA '���̂P
					End If
					'�Y���f�[�^����
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgUODDL71_E_002
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
		
		F_Chk_HD_EIGCD = Retn_Code
		
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
		
		If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN" Then
			Exit Function
		End If
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)

        'UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

        'change 20190403 END saiki
        'Select Case pm_Dsp_Sub_Inf.Ctl.Name
        '    '�r���������������������������������������������������������r
        '    Case pm_All.Dsp_Base.FormCtl.HD_BMNCD.NAME
        '        '����R�[�h�ɂ���ʕ\��
        '        Call F_Dsp_HD_BMNCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

        '    Case pm_All.Dsp_Base.FormCtl.HD_TIKCD.NAME
        '        '�n��敪�ɂ���ʕ\��
        '        Call F_Dsp_HD_TIKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

        '    Case pm_All.Dsp_Base.FormCtl.HD_EIGCD.NAME
        '        '�c�Ə��R�[�h�ɂ���ʕ\��
        '        Call F_Dsp_HD_EIGCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
        '        '�d���������������������������������������������������������d

        'End Select

        Select Case pm_Dsp_Sub_Inf.Ctl.Name
            Case UODDL71.HD_BMNCD.Name
                '����R�[�h�ɂ���ʕ\��
                Call F_Dsp_HD_BMNCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case UODDL71.HD_TIKCD.Name
                '�n��敪�ɂ���ʕ\��
                Call F_Dsp_HD_TIKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case UODDL71.HD_EIGCD.Name
                '�c�Ə��R�[�h�ɂ���ʕ\��
                Call F_Dsp_HD_EIGCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

        End Select
        'change 20190403 END saiki

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
			
			'        '�t�H�[�J�X�ʒu�ݒ�
			'        Call F_Init_Cursor_Set(pm_All)
		End If
		
		'�������e�A�O����e��ޔ�
		Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_BMNCD_Inf
	'   �T�v�F  ����R�[�h�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_BMNCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			pv_JYOKEN_INPUT = False
			
			'����R�[�h���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '�r���������������������������������������������������������r
                '�y���喼�z
                'UPGRADE_ISSUE: Control HD_BMNNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change 20190405 START saiki
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNNM.Tag)

                Trg_Index = CShort(UODDL71.HD_BMNNM.Tag)
                'change 20190405 END saiki

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Dsp_Value = CF_Cnv_Dsp_Item(UODDL71_MEIMTC_Inf.MEINMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)

                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				pv_JYOKEN_INPUT = True
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
            '�N���A
            '�r���������������������������������������������������������r
            '�y���喼�z
            'UPGRADE_ISSUE: Control HD_BMNNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'change 20190405 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNNM.Tag)
            Trg_Index = CShort(UODDL71.HD_BMNNM.Tag)
            'change 20190405 END saiki
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_TIKCD_Inf
	'   �T�v�F  �n��敪�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TIKCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			pv_JYOKEN_INPUT = False
			
			'�n��敪���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '�r���������������������������������������������������������r
                '�y�n�於�z
                'UPGRADE_ISSUE: Control HD_TIKNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change 20190408 START saiki
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKNM.Tag)
                Trg_Index = CShort(UODDL71.HD_TIKNM.Tag)
                'change 20190408 END saiki
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Dsp_Value = CF_Cnv_Dsp_Item(UODDL71_MEIMTC_Inf.MEINMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				pv_JYOKEN_INPUT = True
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
            '�N���A
            '�r���������������������������������������������������������r
            '�y�n�於�z
            'UPGRADE_ISSUE: Control HD_TIKNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'change 20190408 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKNM.Tag)
            Trg_Index = CShort(UODDL71.HD_TIKNM.Tag)
            'change 20190408 END saiki
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_EIGCD_Inf
	'   �T�v�F  �c�Ə��R�[�h�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_EIGCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			pv_JYOKEN_INPUT = False
			
			'�c�Ə��R�[�h���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '�r���������������������������������������������������������r
                '�y�c�Ə����z
                'UPGRADE_ISSUE: Control HD_EIGNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change 20190325 START saiki
                'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGNM.Tag)
                Trg_Index = CShort(UODDL71.HD_EIGNM.Tag)
                'change 20190325 END saiki
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Dsp_Value = CF_Cnv_Dsp_Item(UODDL71_MEIMTC_Inf.MEINMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				pv_JYOKEN_INPUT = True
                '�d���������������������������������������������������������d

                '�������e�A�O����e��ޔ�
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
            End If
		Else
            '�N���A
            '�r���������������������������������������������������������r
            '�y�c�Ə����z
            'UPGRADE_ISSUE: Control HD_EIGNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'change 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGNM.Tag)
            Trg_Index = CShort(UODDL71.HD_EIGNM.Tag)
            'change 20190325 END saiki
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
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
		
		If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN" Then
			F_Ctl_Item_Chk = Rtn_Chk
			Exit Function
		End If

        '�@��{���͓��e�̃`�F�b�N
        'UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'change 20190325 START saiki
        'Select Case pm_Dsp_Sub_Inf.Ctl.Name
        '    '�r���������������������������������������������������������r

        '    Case pm_All.Dsp_Base.FormCtl.HD_BMNCD.NAME
        '        '�����O����(�����֐��̑O�ŕK�{����)
        '        Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
        '        '����R�[�h������
        '        Rtn_Chk = F_Chk_HD_BMNCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        '    Case pm_All.Dsp_Base.FormCtl.HD_TIKCD.NAME
        '        Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
        '        '�n��敪������
        '        Rtn_Chk = F_Chk_HD_TIKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        '    Case pm_All.Dsp_Base.FormCtl.HD_EIGCD.NAME
        '        Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
        '        '�c�Ə��R�[�h������
        '        Rtn_Chk = F_Chk_HD_EIGCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        'End Select

        Select Case pm_Dsp_Sub_Inf.Ctl.Name
            '�r���������������������������������������������������������r

            Case "HD_BMNCD"
                '�����O����(�����֐��̑O�ŕK�{����)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '����R�[�h������
                Rtn_Chk = F_Chk_HD_BMNCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case "HD_TIKCD"
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '�n��敪������
                Rtn_Chk = F_Chk_HD_TIKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case "HD_EIGCD"
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '�c�Ə��R�[�h������
                Rtn_Chk = F_Chk_HD_EIGCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        End Select
        'change 20190325 END saiki
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
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_JUC_URI_BMN
	'   �T�v�F  �󒍁^�����ʌďo�i����ʑ����\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_JUC_URI_BMN(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If

        'change 20190329 START saiki
        'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '	Case "��@��"
        '		gv_UODDL71_JUC_URI = "1"

        '		'�L���v�V�����ύX
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "��@�@��"
        '		' 2007/01/16  CHG END
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "�󒍐�"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "�󒍋��z"
        '		'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "���@��"
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'�A���[��CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************
        '		'�f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

        '	Case "���@��"
        '		gv_UODDL71_JUC_URI = "2"

        '		'�L���v�V�����ύX
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "���@�@��"
        '		' 2007/01/16  CHG END
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "���㐔"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "������z"
        '		'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "��@��"

        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'�A���[��CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************
        '		'�f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        '      End Select

        'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'change start 20190805 kuwahara
        'Select Case UODDL71_fpr.btnF6.Text
        '    Case "(F6)" & vbCrLf & "��@��"
        Select Case Judge1
            Case 0
                'change end 20190805 kuwhara
                gv_UODDL71_JUC_URI = "1"

                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_11.Text = "��@�@��"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_4.Text = "�󒍐�"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_5.Text = "�󒍋��z"
                'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'change start 20190805 kuwahara
                'UODDL71_fpr.btnF6.Text = "(F6)" & vbCrLf & "���@��"
                'Judge1 = 1
                'change end 20190805 kuwahara

                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr.lab_uri.Visible = False
                'ADD  END  FKS)INABA 2010/10/05 ****************************************
                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

                'change start 20190805 kuwahara
                'Case "(F6)" & vbCrLf & "���@��"
            Case 1
                'change end 20190805 kuwahara
                gv_UODDL71_JUC_URI = "2"

                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_11.Text = "���@�@��"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_4.Text = "���㐔"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_5.Text = "������z"
                'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'change start 20190805 kuwahara
                'UODDL71_fpr.btnF6.Text = "(F6)" & vbCrLf & "��@��"
                'Judge1 = 0
                'change end 20190805 kuwahara

                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************
                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        End Select
        'change 20190329 END saiki

        If RtnCode = 0 Then
			'�o�͂ł��閾�׃f�[�^������
			Exit Function
		Else
			'���݂̃y�[�W��������
			NowPageNum = 1
			
			'�ŏ㖾�ײ��ޯ��������
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1

            '���ׂ���ʂɕҏW
            'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'change 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            Trg_Index = CShort(UODDL71_fpr.btnF1.Tag)
            'change 20190329 END saiki
            Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_GETU_KI_BMN
	'   �T�v�F  �����^������ʌďo�i����ʑ����\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_GETU_KI_BMN(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0

        'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '      'change 20190329 START saiki
        'Select Case pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption
        '    Case "���@��"
        '        gv_UODDL71_GETU_KI = "1"
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            Wk_GetuKi = "����"
        '        Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '        Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
        '        ' 2007/01/16  CHG END

        '        '�L���v�V�����ύX
        '        'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "�݁@�v"

        '    Case "�݁@�v"
        '        gv_UODDL71_GETU_KI = "2"
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            Wk_GetuKi = "����"
        '        Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '        Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
        '        Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
        '        ' 2007/01/16  CHG END

        '        '�L���v�V�����ύX
        '        'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "���@��"

        'End Select

        'Select Case gv_UODDL71_JUC_URI
        '    Case "1"
        '        '��
        '        '�L���v�V�����ύX
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "��@�@��"
        '        ' 2007/01/16  CHG END
        '        'ADD START FKS)INABA 2010/10/05 ****************************************
        '        '�A���[��CF10100501
        '        'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '        'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '        '�f�[�^�擾
        '        RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
        '    Case "2"
        '        '����
        '        '�L���v�V�����ύX
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "���@�@��"
        '        ' 2007/01/16  CHG END
        '        'ADD START FKS)INABA 2010/10/05 ****************************************
        '        '�A���[��CF10100501
        '        'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '        'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '        '�f�[�^�擾
        '        RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        'End Select

        'change start 20190805 kuwahara
        'Select Case UODDL71_fpr.btnF7.Text
        'Case "(F7)" & vbCrLf & "���@��"
        Select Case Judge2
            Case 0
                'change end 20190805 kuwahara
                gv_UODDL71_GETU_KI = "1"
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "����"
                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
                ' 2007/01/16  CHG END

                '�L���v�V�����ύX
                'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change stat 20190805 kuwahara
                'UODDL71_fpr.btnF7.Text = "(F7)" & vbCrLf & "�݁@�v"
                'Judge2 = 1
                'change end 20190805 kuwahara

                'change start 20190805 kuwahara
                'Case "(F7)" & vbCrLf & "�݁@�v"
            Case 1
                'change end 20190805 kuwahara
                gv_UODDL71_GETU_KI = "2"
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "����"
                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
                Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
                ' 2007/01/16  CHG END

                '�L���v�V�����ύX
                'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwahara
                'UODDL71_fpr.btnF7.Text = "(F7)" & vbCrLf & "���@��"
                'Judge2 = 0
                'change end 20190805 kuwahara
        End Select

        Select Case gv_UODDL71_JUC_URI
            Case "1"
                '��
                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

                'change 20190329 START saiki
                'UODDL71_fpr.FM_Panel3D1(3).Text = Wk_GetuKi
                ''UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'UODDL71_fpr.FM_Panel3D1(11).Text = "��@�@��"

                UODDL71_fpr._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_11.Text = "��@�@��"
                'change 20190329 END saiki

                ' 2007/01/16  CHG END
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr.lab_uri.Visible = False
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
            Case "2"
                '����
                '�L���v�V�����ύX

                'change 20190329 START saiki
                '' 2007/01/16  CHG START  KUMEDA
                ''            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
                ''UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'UODDL71_fpr.FM_Panel3D1(3).Text = Wk_GetuKi
                ''UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'UODDL71_fpr.FM_Panel3D1(11).Text = "���@�@��"
                '' 2007/01/16  CHG END


                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr._FM_Panel3D1_11.Text = "���@�@��"
                'change 20190401 END saiki

                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71_fpr.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        End Select
        'change 20190329 END saiki

        If RtnCode = 0 Then
            '�o�͂ł��閾�׃f�[�^������
            Exit Function
        Else
            '���݂̃y�[�W��������
            NowPageNum = 1
			
			'�ŏ㖾�ײ��ޯ��������
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1

            '���ׂ���ʂɕҏW
            'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'change 20190329 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Tag)
            Trg_Index = CShort(UODDL71_fpr.btnF11.Tag)
            'change 20190329 END saiki
            Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_SOUKATU_BMN
	'   �T�v�F  �@��ʑ����\��ʌďo�i����ʑ����\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SOUKATU_BMN(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Row_Cnt As Short
		Dim Row_Index As Short
		Dim Div_Kind As String
		Dim Div_Code As String
		
		Div_Kind = ""
		Div_Code = ""

        'delete 20190325 START saiki
        For Row_Cnt = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
            '�I�v�V�����{�^�����I������Ă���ꍇ
            'UPGRADE_ISSUE: Control BD_SELECTB �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B

            'change 20190402 START saiki
            'If pm_All.Dsp_Base.FormCtl.BD_SELECTB(Row_Cnt).Value = True Then
            If UODDL71_fpr.BD_SELECTB(Row_Cnt).Checked = True Then
                'change 20190402 END saiki
                'Dsp_Body_Inf.Row_Inf�̍s�m�n�֕ϊ�
                Row_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index + Row_Cnt - 1

                '�I���f�[�^�̃R�[�h���擾
                With pm_All.Dsp_Body_Inf.Row_Inf(Row_Index).Bus_Inf
                    Div_Kind = .DIVISION
                    Div_Code = .DIVCODE
                End With

                Exit For
            End If

        Next


        If Div_Code = "" Then
            '�I������Ă��Ȃ��ꍇ
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODDL71_E_008, pm_All)

            '����̫����ʒu�ݒ�
            Call F_Init_Cursor_Set(pm_All)

            Exit Function
        Else
            '�I������Ă���ꍇ
            Select Case Div_Kind
				Case "1"
					gv_UODDL71_BMNCD = Div_Code
					gv_UODDL71_TIKCD = ""
					gv_UODDL71_EIGCD = ""
				Case "2"
					gv_UODDL71_BMNCD = ""
					gv_UODDL71_TIKCD = Div_Code
					gv_UODDL71_EIGCD = ""
				Case "3"
					gv_UODDL71_BMNCD = ""
					gv_UODDL71_TIKCD = ""
					gv_UODDL71_EIGCD = Div_Code
				Case "99"
					' 2007/01/17  CHG START  KUMEDA
					'                gv_UODDL71_BMNCD = ""
					gv_UODDL71_BMNCD = "9"
					' 2007/01/17  CHG END
					gv_UODDL71_TIKCD = ""
					gv_UODDL71_EIGCD = ""
			End Select
		End If
		
		'����ʁi����ʑ����\�j���\��
		FR_SSSMAIN.Hide()
		
		'�@��ʑ����\��\��
		gv_bolUODDL71_Active = True
        'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        'change 20190325 START saiki
        'Load(FR_SSSMAIN1)
        'FR_SSSMAIN1.Show()


        'UODDL71.ShowDialog()
        UODDL71.Show()
        'Change 20190325 END saiki


    End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_SAIYOMI_BMN
	'   �T�v�F  �ēǍ��i����ʑ����\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SAIYOMI_BMN(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		
		Select Case gv_UODDL71_JUC_URI
			Case "1"
				'��
				'�f�[�^�擾
				RtnCode = F_GET_BD_DATA_BMN_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
			Case "2"
				'����
				'�f�[�^�擾
				RtnCode = F_GET_BD_DATA_BMN_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
		End Select
		
		If RtnCode = 0 Then
			'�o�͂ł��閾�׃f�[�^������
			Exit Function
		Else
			'���݂̃y�[�W��������
			NowPageNum = 1
			
			'�ŏ㖾�ײ��ޯ��������
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'���ׂ���ʂɕҏW
			'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
	End Function
	
	' 2007/01/12  ADD START  KUMEDA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_SAIYOMI_KSY
	'   �T�v�F  �ēǍ��i�@��ʑ����\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SAIYOMI_KSY(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If
        'delete 20190325 START saiki
        ''UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '      gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
		' 2007/01/17  ADD START  KUMEDA
		If Trim(gv_UODDL71_BMNCD) = "9" Then
			gv_UODDL71_BMNCD = " "
		End If
		If Trim(gv_UODDL71_TIKCD) = "99" Then
			gv_UODDL71_TIKCD = "  "
		End If
		If Trim(gv_UODDL71_EIGCD) = "9" Then
			gv_UODDL71_EIGCD = " "
		End If
        ' 2007/01/17  ADD END
        'delete 20190325 START saiki
        'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '	Case "���@��"

        '		'�󒍃f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

        '	Case "��@��"

        '		'����f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        'End Select
        'delete 20190325 END saiki

        'add 20190719 START hou
        Select Case gv_UODDL71_JUC_URI
            Case "1"
                '�󒍃f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
            Case "2"

                '����f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        End Select
        'add 20190719 END hou

        If RtnCode = 0 Then
			'�o�͂ł��閾�׃f�[�^������
			Exit Function
		Else
			'���݂̃y�[�W��������
			NowPageNum = 1
			
			'�ŏ㖾�ײ��ޯ��������
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'���ׂ���ʂɕҏW
			'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_SAIYOMI_MEI
	'   �T�v�F  �ēǍ��i�@��ʑ����\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SAIYOMI_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If
        'delete 20190325 START saiki
        ''UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '      gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
		' 2007/01/17  ADD START  KUMEDA
		If Trim(gv_UODDL71_BMNCD) = "9" Then
			gv_UODDL71_BMNCD = " "
		End If
		If Trim(gv_UODDL71_TIKCD) = "99" Then
			gv_UODDL71_TIKCD = "  "
		End If
		If Trim(gv_UODDL71_EIGCD) = "9" Then
			gv_UODDL71_EIGCD = " "
		End If
        ' 2007/01/17  ADD END
        'delete 20190325 START saiki
        'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '	Case "���@��"

        '		'�󒍃f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)

        '	Case "��@��"

        '		'����f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)

        'End Select
        'delete 20190325 END saiki
        'add start 20190806 kuwahara
        Select Case Judge1
            Case 0

                '�󒍃f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)

            Case 1

                '����f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)

        End Select
        'add end 20190806 kuwahara
        If RtnCode = 0 Then
			'�o�͂ł��閾�׃f�[�^������
			Exit Function
		Else
			'���݂̃y�[�W��������
			NowPageNum = 1
			
			'�ŏ㖾�ײ��ޯ��������
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'���ׂ���ʂɕҏW
			'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	' 2007/01/12  ADD END
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_JUC_URI_KIS
	'   �T�v�F  �󒍁^�����ʌďo�i�@��ʑ����\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_JUC_URI_KIS(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If
        'change 20190403 START saiki
        ''UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '    Case "��@��"
        '        gv_UODDL71_JUC_URI = "1"

        '        '�L���v�V�����ύX
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "��@�@��"
        '        ' 2007/01/16  CHG END
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "�󒍐�"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "�󒍋��z"
        '        'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "���@��"
        '        'ADD START FKS)INABA 2010/10/05 ****************************************
        '        '�A���[��CF10100501
        '        'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '        'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '        '�f�[�^�擾
        '        RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

        '    Case "���@��"
        '        gv_UODDL71_JUC_URI = "2"

        '        '�L���v�V�����ύX
        '        ' 2007/01/16  CHG START  KUMEDA
        '        '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "���@�@��"
        '        ' 2007/01/16  CHG END
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "���㐔"
        '        'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "������z"
        '        'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "��@��"
        '        'ADD START FKS)INABA 2010/10/05 ****************************************
        '        '�A���[��CF10100501
        '        'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '        pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '        'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '        '�f�[�^�擾
        '        RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        'End Select


        'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'change start 20190805 kuwahara
        'Select Case UODDL71.btnF6.Text
        'Case "(F6)" & vbCrLf & "��@��"
        Select Case Judge1
            Case 0
                'change end 20190805 kuwahara
                gv_UODDL71_JUC_URI = "1"

            '�L���v�V�����ύX
            ' 2007/01/16  CHG START  KUMEDA
            '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
            'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            UODDL71._FM_Panel3D1_3.Text = Wk_GetuKi
            'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            UODDL71._FM_Panel3D1_11.Text = "��@�@��"
            ' 2007/01/16  CHG END
            'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            UODDL71._FM_Panel3D1_4.Text = "�󒍐�"
            'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            UODDL71._FM_Panel3D1_5.Text = "�󒍋��z"
                'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwahara
                'UODDL71.btnF6.Text = "(F6)" & vbCrLf & "���@��"
                'Judge1 = 1
                'change end 20190805 kuwahara
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71.lab_uri.Visible = False
            'ADD  END  FKS)INABA 2010/10/05 ****************************************

            '�f�[�^�擾
            RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)

                'change start 20190805 kuwahara
                'Case "(F6)" & vbCrLf & "���@��"
            Case 1
                gv_UODDL71_JUC_URI = "2"

                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71._FM_Panel3D1_11.Text = "���@�@��"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71._FM_Panel3D1_4.Text = "���㐔"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71._FM_Panel3D1_5.Text = "������z"
                'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwahara
                'UODDL71.btnF6.Text = "(F6)" & vbCrLf & "��@��"
                'Judge1 = 0
                'change end 20190805 kuwahara
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)

        End Select
        'change 20190403 END saiki
        If RtnCode = 0 Then
            '�o�͂ł��閾�׃f�[�^������
            Exit Function
        Else
            '���݂̃y�[�W��������
            NowPageNum = 1
			
			'�ŏ㖾�ײ��ޯ��������
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'���ׂ���ʂɕҏW
			'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_GETU_KI_KIS
	'   �T�v�F  �����^������ʌďo�i�@��ʑ����\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_GETU_KI_KIS(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
        'change 20190403 START saiki
        'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Select Case pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption
        '	Case "���@��"
        '		gv_UODDL71_GETU_KI = "1"
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            Wk_GetuKi = "����"
        '		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '		Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
        '		' 2007/01/16  CHG END

        '		'�L���v�V�����ύX
        '		'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "�݁@�v"

        '	Case "�݁@�v"
        '		gv_UODDL71_GETU_KI = "2"
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            Wk_GetuKi = "����"
        '		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '		Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
        '		Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
        '		' 2007/01/16  CHG END

        '		'�L���v�V�����ύX
        '		'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "���@��"

        'End Select

        'Select Case gv_UODDL71_JUC_URI
        '	Case "1"
        '		'��
        '		'�L���v�V�����ύX
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "��@�@��"
        '		' 2007/01/16
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'�A���[��CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'�f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
        '	Case "2"
        '		'����
        '		'�L���v�V�����ύX
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "���@�@��"
        '		' 2007/01/16  CHG END
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'�A���[��CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'�f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        'End Select


        'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'change start 20190805 kuwahara
        'Select Case UODDL71.btnF7.Text
        'Case "(F7)" & vbCrLf & "���@��"
        Select Case Judge2
            Case 0
                'change end 20190805 kuwahara
                gv_UODDL71_GETU_KI = "1"

                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
            Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)

                '�L���v�V�����ύX
                'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'UODDL71.btnF7.Text = "(F7)" & vbCrLf & "�݁@�v"
                'Judge2 = 1
                'change end 20190805 kuwahara

                'change start 20190805 kuwahara
                'Case "(F7)" & vbCrLf & "�݁@�v"
            Case 1
                'change end 20190805 kuwahara
                gv_UODDL71_GETU_KI = "2"

                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
                Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)

                '�L���v�V�����ύX
                'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'change start 20190805 kuwahara
                'UODDL71.btnF7.Text = "(F7)" & vbCrLf & "���@��"
                'Judge2 = 0
                'change end 20190805�@kuwahara

        End Select

        Select Case gv_UODDL71_JUC_URI
            Case "1"
                '��
                '�L���v�V�����ύX

                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71._FM_Panel3D1_11.Text = "��@�@��"

                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71.lab_uri.Visible = False

                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_JUC(gv_UODDL71_GETU_KI, pm_All)
            Case "2"
                '����
                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71._FM_Panel3D1_11.Text = "���@�@��"
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL71.lab_uri.Visible = True

                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_SOUKATU_URI(gv_UODDL71_GETU_KI, pm_All)
        End Select
        'change 20190403 END saiki

        If RtnCode = 0 Then
			'�o�͂ł��閾�׃f�[�^������
			Exit Function
		Else
			'���݂̃y�[�W��������
			NowPageNum = 1
			
			'�ŏ㖾�ײ��ޯ��������
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'���ׂ���ʂɕҏW
			'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_CS_BMNSOU_KIS
    '   �T�v�F  ����ʑ����\��ʌďo�i�@��ʑ����\�j
    '   �����F  pm_Dsp_Sub_Inf      :��ʏ��
    '           pm_all              :�S�\����
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_BMNSOU_KIS(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
        '�@��ʑ����\��\��
        '20190718 CHG START
        'FR_SSSMAIN1.Hide()
        UODDL71.Hide()
        '20190718 CHG END

        'delete 20190325 START saiki
        '' 2007/01/18  ADD START  KUMEDA
        ''UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
        gv_bolUODDL71_Active = True
		' 2007/01/18  ADD END
		
		'����ʑ����\�\��
		FR_SSSMAIN.Show()
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_MEISAI_KIS
	'   �T�v�F  �@�햾�ו\��ʌďo�i�@��ʑ����\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_MEISAI_KIS(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
        '����ʁi�@��ʑ����\�j���\��
        '20190718 CHG START
        'FR_SSSMAIN1.Hide()
        UODDL71.Hide()
        '20190718 CHG END
        'change 20190325 START saiki
        '' 2007/01/17  ADD START  KUMEDA
        ''UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        '' 2007/01/17  ADD END

        ' 2007/01/17  ADD START  KUMEDA
        'UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        gv_UODDL71_BMNCD = Trim(UODDL71.HD_BMNCD.Text)
        'UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        gv_UODDL71_TIKCD = Trim(UODDL71.HD_TIKCD.Text)
        'UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        gv_UODDL71_EIGCD = Trim(UODDL71.HD_EIGCD.Text)
        ' 2007/01/17  ADD END
        'change 20190325 END saiki

        '�@��ʑ����\��\��
        gv_bolUODDL71_Active = True
        'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        'change 20190325 START saiki
        'Load(FR_SSSMAIN2)
        'FR_SSSMAIN2.ShowDialog()
        'change 20190325 END saiki
        FR_SSSMAIN2.Show()
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_JUC_URI_MEI
	'   �T�v�F  �󒍁^�����ʌďo�i�@�햾�ו\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_JUC_URI_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		' 2007/01/16  ADD START  KUMEDA
		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
		' 2007/01/16  ADD END
		
		If gv_UODDL71_GETU_KI = "1" Then
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
			' 2007/01/16  CHG END
		Else
			'����
			' 2007/01/16  CHG START  KUMEDA
			'        Wk_GetuKi = "����"
			Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
			Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
			' 2007/01/16  CHG END
		End If
        'change start 20190806 kuwahara
        'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Select Case pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption
        '	Case "��@��"
        '		gv_UODDL71_JUC_URI = "1"

        '		'�L���v�V�����ύX
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "��@�@��"
        '		' 2007/01/16  CHG END
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "�󒍐�"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "�󒍋��z"
        '		'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "���@��"
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'�A���[��CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'�f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)

        '	Case "���@��"
        '		gv_UODDL71_JUC_URI = "2"

        '		'�L���v�V�����ύX
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "���@�@��"
        '		' 2007/01/16  CHG END
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(4).Caption = "���㐔"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(5).Caption = "������z"
        '		'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Caption = "��@��"
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'�A���[��CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'�f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)

        'End Select

        Select Case Judge1
            Case 0
                gv_UODDL71_JUC_URI = "1"

                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_11.Text = "��@�@��"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_4.Text = "�󒍐�"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_5.Text = "�󒍋��z"
                'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712.lab_uri.Visible = False
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)

            Case 1
                gv_UODDL71_JUC_URI = "2"

                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_11.Text = "���@�@��"
                ' 2007/01/16  CHG END
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_4.Text = "���㐔"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_5.Text = "������z"
                'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)

        End Select
        'change end 20190806 kuwahara
        If RtnCode = 0 Then
			'�o�͂ł��閾�׃f�[�^������
			Exit Function
		Else
			'���݂̃y�[�W��������
			NowPageNum = 1
			
			'�ŏ㖾�ײ��ޯ��������
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'���ׂ���ʂɕҏW
			'UPGRADE_ISSUE: Control CS_JUC_URI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_JUC_URI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_GETU_KI_MEI
	'   �T�v�F  �����^������ʌďo�i�@�햾�ו\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_GETU_KI_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		Dim Wk_GetuKi As String
		' 2007/01/16  ADD START  KUMEDA
		Dim Wk_NENGETU As String
		' 2007/01/16  ADD END
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
        'change start 20190806 kuwahara
        'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Select Case pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption
        '	Case "���@��"
        '		gv_UODDL71_GETU_KI = "1"
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            Wk_GetuKi = "����"
        '		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '		Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
        '		' 2007/01/16  CHG END

        '		'�L���v�V�����ύX
        '		'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "�݁@�v"

        '	Case "�݁@�v"
        '		gv_UODDL71_GETU_KI = "2"
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            Wk_GetuKi = "����"
        '		Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
        '		Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
        '		Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
        '		' 2007/01/16  CHG END

        '		'�L���v�V�����ύX
        '		'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Caption = "���@��"

        'End Select

        'Select Case gv_UODDL71_JUC_URI
        '	Case "1"
        '		'��
        '		'�L���v�V�����ύX
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "��@�@��"
        '		' 2007/01/16  CHG END
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'�A���[��CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = False
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'�f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)
        '	Case "2"
        '		'����
        '		'�L���v�V�����ύX
        '		' 2007/01/16  CHG START  KUMEDA
        '		'            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi
        '		'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.FM_Panel3D1(11).Caption = "���@�@��"
        '		' 2007/01/16  CHG END
        '		'ADD START FKS)INABA 2010/10/05 ****************************************
        '		'�A���[��CF10100501
        '		'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		pm_All.Dsp_Base.FormCtl.lab_uri.Visible = True
        '		'ADD  END  FKS)INABA 2010/10/05 ****************************************

        '		'�f�[�^�擾
        '		RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)
        'End Select

        Select Case Judge2
            Case 0
                gv_UODDL71_GETU_KI = "1"
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "����"
                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
                ' 2007/01/16  CHG END


            Case 1
                gv_UODDL71_GETU_KI = "2"
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "����"
                Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
                Wk_GetuKi = Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
                Wk_GetuKi = Wk_GetuKi & Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
                ' 2007/01/16  CHG END

        End Select

        Select Case gv_UODDL71_JUC_URI
            Case "1"
                '��
                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            pm_All.Dsp_Base.FormCtl.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_11.Text = "��@�@��"
                ' 2007/01/16  CHG END
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712.lab_uri.Visible = False
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, pm_All)
            Case "2"
                '����
                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            UODDL712.FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_ISSUE: Control FM_Panel3D1 �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712._FM_Panel3D1_11.Text = "���@�@��"
                ' 2007/01/16  CHG END
                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                'UPGRADE_ISSUE: Control lab_uri �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                UODDL712.lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                '�f�[�^�擾
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, pm_All)
        End Select

        'change end 20190806 kuwahara
        If RtnCode = 0 Then
			'�o�͂ł��閾�׃f�[�^������
			Exit Function
		Else
			'���݂̃y�[�W��������
			NowPageNum = 1
			
			'�ŏ㖾�ײ��ޯ��������
			pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
			
			'���ׂ���ʂɕҏW
			'UPGRADE_ISSUE: Control CS_GETU_KI �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            'delete 20190325 START saiki
            'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_GETU_KI.Tag)
            'delete 20190325 END saiki
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
		End If
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_BMNSOU_MEI
	'   �T�v�F  ����ʑ����\��ʌďo�i�@�햾�ו\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_BMNSOU_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
        '�@�햾�ו\��\��
        '20190718 CHG START
        'FR_SSSMAIN2.Hide()
        UODDL712.Hide()
        '20190718 CHG END

        '      'delete 20190325 START saiki
        '' 2007/01/18  ADD START  KUMEDA
        ''UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
        gv_bolUODDL71_Active = True
		' 2007/01/18  ADD END
		
		'����ʑ����\�\��
		FR_SSSMAIN.Show()
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CS_SOUKATU_MEI
	'   �T�v�F  �@��ʑ����\��ʌďo�i�@�햾�ו\�j
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_all              :�S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_SOUKATU_MEI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
        '�@�햾�ו\��\��
        '20190718 CHG START
        'FR_SSSMAIN2.Hide()
        UODDL712.Hide()
        '20190718 CHG END

        'delete 20190325 START saiki
        '' 2007/01/18  ADD START  KUMEDA
        ''UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_BMNCD = Trim(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Text)
        ''UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_TIKCD = Trim(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Text)
        ''UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'gv_UODDL71_EIGCD = Trim(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Text)
        'delete 20190325 END saiki
        gv_bolUODDL71_Active = True
        ' 2007/01/18  ADD END

        '�@��ʑ����\�\��
        '20190718 CHG START
        'FR_SSSMAIN1.Show()
        UODDL71.Show()
        '20190718 CHG END

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_CS_BMNCD
    '   �T�v�F  �Ώۍ��ڂ̕��匟�����݂̐���
    '   �����F  pm_Dsp_Sub_Inf      :��ʏ��
    '           pm_all              :�S�\����
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'change 20190405 START saiki
    'Public Function F_Ctl_CS_BMNCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
    Public Function F_Ctl_CS_BMNCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef UODDL As Integer) As Short
        'change 20190405 END saiki

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'change 20190325 START saiki
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
        If UODDL = 711 Then
            Trg_Index = CShort(UODDL71.HD_BMNCD.Tag)
        Else
            Trg_Index = CShort(UODDL712.HD_BMNCD.Tag)
        End If
        'change 20190325 END saiki
        Next_Focus = Trg_Index

        '̫����𕔖�R�[�h�ֈړ�
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            ' 2006/11/28  ADD START  KUMEDA
            If pm_All.Dsp_Base.FormCtl.ActiveControl Is Nothing Then
                Exit Function
            End If
            ' 2006/11/28  ADD END

            '���݂�Active�R���g���[���̑I����ԉ���
            'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(pm_All.Dsp_Base.FormCtl.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            '̫����ړ�
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '���ڐF�ݒ�
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODDL71_LF_Enable = False

            '======================= �ύX���� 2006.06.12 Start =================================
            'Windows�ɏ�����Ԃ�
            System.Windows.Forms.Application.DoEvents()
            '======================= �ύX���� 2006.06.12 End =================================

            '���匟����ʂ��Ăяo��
            WLSMEIC_KEYCD = pc_Bmncd_Keycode
            WLSMEIC_TKDT = GV_UNYDate
            WLS_MEI4.ShowDialog()
            WLS_MEI4.Close()

            gv_bolUODDL71_LF_Enable = True

            If WLSMEIC_RTNMEICDA <> "" Then
                '�����n�j
                '��ʂɕҏW
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Dsp_Value = CF_Cnv_Dsp_Item(WLSMEIC_RTNMEICDA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
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

                'ADD 20190408 START saiki
                If UODDL = 711 Then
                    UODDL71.HD_EIGCD.Text = ""
                    UODDL71.HD_EIGNM.Text = ""
                    UODDL71.HD_TIKCD.Text = ""
                    UODDL71.HD_TIKNM.Text = ""
                    gv_UODDL71_BMNCD = UODDL71.HD_BMNCD.Text
                    gv_bolUODDL71_Active = True

                Else
                    UODDL712.HD_EIGCD.Text = ""
                    UODDL712.HD_EIGNM.Text = ""
                    UODDL712.HD_TIKCD.Text = ""
                    UODDL712.HD_TIKNM.Text = ""

                End If


                'ADD 20190408 END saiki

                If Chk_Move_Flg = True Then
                    '������ړ�����
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else

                    '̫����ړ�
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '���ڐF�ݒ�
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                End If
            End If
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_CS_TIKCD
    '   �T�v�F  �Ώۍ��ڂ̒n�挟�����݂̐���
    '   �����F  pm_Dsp_Sub_Inf      :��ʏ��
    '           pm_all              :�S�\����
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'change 20190405 START saiki
    'Public Function F_Ctl_CS_TIKCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
    Public Function F_Ctl_CS_TIKCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef UODDL As Integer) As Short
        'change 20190405 END saiki

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'change 20190325 START saiki
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
        If UODDL = 711 Then
            Trg_Index = CShort(UODDL71.HD_TIKCD.Tag)
        Else
            Trg_Index = CShort(UODDL712.HD_TIKCD.Tag)
        End If
        'change 20190325 END saiki
        Next_Focus = Trg_Index

        '̫�����n��敪�ֈړ�
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            ' 2006/11/28  ADD START  KUMEDA
            If pm_All.Dsp_Base.FormCtl.ActiveControl Is Nothing Then
                Exit Function
            End If
            ' 2006/11/28  ADD END

            '���݂�Active�R���g���[���̑I����ԉ���
            'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(pm_All.Dsp_Base.FormCtl.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            '̫����ړ�
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '���ڐF�ݒ�
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODDL71_LF_Enable = False

            '======================= �ύX���� 2006.06.12 Start =================================
            'Windows�ɏ�����Ԃ�
            System.Windows.Forms.Application.DoEvents()
            '======================= �ύX���� 2006.06.12 End =================================

            '�n�挟����ʂ��Ăяo��
            WLSMEIC_KEYCD = pc_Tikcd_Keycode
            WLSMEIC_TKDT = GV_UNYDate
            WLS_MEI4.ShowDialog()
            WLS_MEI4.Close()

            gv_bolUODDL71_LF_Enable = True

            If WLSMEIC_RTNMEICDA <> "" Then
                '�����n�j
                '��ʂɕҏW
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Dsp_Value = CF_Cnv_Dsp_Item(WLSMEIC_RTNMEICDA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
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


                If Chk_Move_Flg = True Then
                    '������ړ�����
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else

                    '̫����ړ�
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '���ڐF�ݒ�
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                End If


                'ADD 20190408 START saiki
                If UODDL = 711 Then
                    UODDL71.HD_BMNCD.Text = ""
                    UODDL71.HD_BMNNM.Text = ""
                    UODDL71.HD_EIGCD.Text = ""
                    UODDL71.HD_EIGNM.Text = ""


                Else
                    UODDL712.HD_BMNCD.Text = ""
                    UODDL712.HD_BMNNM.Text = ""
                    UODDL712.HD_EIGCD.Text = ""
                    UODDL712.HD_EIGNM.Text = ""
                    gv_UODDL71_BMNCD = ""
                    gv_UODDL71_TIKCD = UODDL712.HD_TIKCD.Text
                    gv_bolUODDL71_Active = True

                End If
                'ADD 20190408 END saiki
            End If
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Ctl_CS_EIGCD
    '   �T�v�F  �Ώۍ��ڂ̉c�Ə��������݂̐���
    '   �����F  pm_Dsp_Sub_Inf      :��ʏ��
    '           pm_all              :�S�\����
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function F_Ctl_CS_EIGCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
    Public Function F_Ctl_CS_EIGCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef UODDL As Integer) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'change 20190325 START saiki
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
        If UODDL = 711 Then
            Trg_Index = CShort(UODDL71.HD_EIGCD.Tag)
        Else
            Trg_Index = CShort(UODDL712.HD_EIGCD.Tag)
        End If
        'change 20190325 END saiki
        Next_Focus = Trg_Index

        '̫������c�Ə��R�[�h�ֈړ�
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            ' 2006/11/28  ADD START  KUMEDA
            If pm_All.Dsp_Base.FormCtl.ActiveControl Is Nothing Then
                Exit Function
            End If
            ' 2006/11/28  ADD END

            '���݂�Active�R���g���[���̑I����ԉ���
            'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(pm_All.Dsp_Base.FormCtl.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            '̫����ړ�
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '���ڐF�ݒ�
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODDL71_LF_Enable = False

            '======================= �ύX���� 2006.06.12 Start =================================
            'Windows�ɏ�����Ԃ�
            System.Windows.Forms.Application.DoEvents()
            '======================= �ύX���� 2006.06.12 End =================================

            '�c�Ə�������ʂ��Ăяo��
            WLSMEIC_KEYCD = pc_Eigcd_Keycode
            WLSMEIC_TKDT = GV_UNYDate
            WLS_MEI4.ShowDialog()
            WLS_MEI4.Close()

            gv_bolUODDL71_LF_Enable = True

            If WLSMEIC_RTNMEICDA <> "" Then
                '�����n�j
                '��ʂɕҏW
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Dsp_Value = CF_Cnv_Dsp_Item(WLSMEIC_RTNMEICDA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
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

                'ADD 20190408 START saiki
                If UODDL = 711 Then
                    UODDL71.HD_BMNCD.Text = ""
                    UODDL71.HD_BMNNM.Text = ""
                    UODDL71.HD_TIKCD.Text = ""
                    UODDL71.HD_TIKNM.Text = ""
                Else
                    UODDL712.HD_BMNCD.Text = ""
                    UODDL712.HD_BMNNM.Text = ""
                    UODDL712.HD_TIKCD.Text = ""
                    UODDL712.HD_TIKNM.Text = ""
                    gv_UODDL71_EIGCD = UODDL712.HD_EIGCD.Text
                    gv_bolUODDL71_Active = True
                End If

                'ADD 20190408 END saiki

                If Chk_Move_Flg = True Then
                    '������ړ�����
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else

                    '̫����ړ�
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '���ڐF�ݒ�
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                End If
            End If
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
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
    'change start 20190806 kuwahara
    'Public Function F_Ctl_CS(ByRef pm_All As Cls_All) As Short
    Public Function F_Ctl_CS(ByRef pm_All As Cls_All, ByRef UODDL As Integer) As Short
        'change end 20190806 kuwahara

        Dim Cursor_Index As Short
        Dim Trg_Index As Short

        '���݂̃t�H�[�J�X�擾�R���g���[���̃C���f�b�N�X
        Cursor_Index = pm_All.Dsp_Base.Cursor_Idx
        'UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'change start 20190806 kuwahara
        '	Case CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
        '		'����
        '		'UPGRADE_ISSUE: Control CS_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_BMNCD.Tag)
        '		Call F_Ctl_CS_BMNCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

        '	Case CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
        '		'�n��
        '		'UPGRADE_ISSUE: Control CS_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_TIKCD.Tag)
        '		Call F_Ctl_CS_TIKCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

        '	Case CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
        '		'�c�Ə�
        '		'UPGRADE_ISSUE: Control CS_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '		Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CS_EIGCD.Tag)
        '		Call F_Ctl_CS_EIGCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        'add start 20190806 kuwahara
        If UODDL = 711 Then

                Select Case Cursor_Index
                    Case CShort(UODDL71.HD_BMNCD.Tag)
                        '����
                        'UPGRADE_ISSUE: Control CS_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Trg_Index = CShort(FR_SSSMAIN1.CS_BMNCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_BMNCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)

                    Case CShort(UODDL71.HD_TIKCD.Tag)
                        '�n��
                        'UPGRADE_ISSUE: Control CS_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Trg_Index = CShort(FR_SSSMAIN1.CS_TIKCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_TIKCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)

                    Case CShort(UODDL71.HD_EIGCD.Tag)
                        '�c�Ə�
                        'UPGRADE_ISSUE: Control CS_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Trg_Index = CShort(FR_SSSMAIN1.CS_EIGCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_EIGCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)
                End Select

            Else
                Select Case Cursor_Index

                    Case CShort(UODDL712.HD_BMNCD.Tag)
                        '����
                        'UPGRADE_ISSUE: Control CS_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Trg_Index = CShort(FR_SSSMAIN1.CS_BMNCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_BMNCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)

                    Case CShort(UODDL712.HD_TIKCD.Tag)
                        '�n��
                        'UPGRADE_ISSUE: Control CS_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Trg_Index = CShort(FR_SSSMAIN1.CS_TIKCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_TIKCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)

                    Case CShort(UODDL712.HD_EIGCD.Tag)
                        '�c�Ə�
                        'UPGRADE_ISSUE: Control CS_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                        Trg_Index = CShort(FR_SSSMAIN1.CS_EIGCD.Tag)
                        Call SSSMAIN0001.F_Ctl_CS_EIGCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, UODDL)
                End Select

            End If
        'add end 20190806 kuwahara

        'change end 20190806 kuwahara
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
        'delete 20190325 START saiki
		'�t�b�^�����ŏ���
        'For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
        '	'UPGRADE_ISSUE: Control TX_Dummy �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '	Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
        '		'�r���������������������������������������������������������r
        '		Case pm_All.Dsp_Base.FormCtl.TX_Dummy.NAME
        '			'�d���������������������������������������������������������d
        '			'������Ԃœ��͉\�Ⱥ��۰�
        '			'���͉\
        '			Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
        '	End Select
        'Next 
        'delete 20190325 END saiki
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
        'delete 20190325 START saiki
        ''���j���[�{�^���C���[�W�̉�����
        ''�I���{�^��
        ''UPGRADE_ISSUE: Control CM_EndCm �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_EndCm.Tag)
        ''UPGRADE_ISSUE: Control MN_EndCm �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '      Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_EndCm.Tag)
        'delete 20190325 END saiki
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '���s�{�^��
		'    Trg_Index = CInt(pm_All.Dsp_Base.FormCtl.CM_Execute.Tag)
		'    Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.MN_Execute.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '������ʕ\���{�^��
		'    Trg_Index = CInt(pm_All.Dsp_Base.FormCtl.CM_SLIST.Tag)
		'    Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.MN_Slist.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '���ו��N���A�{�^��
		'    Trg_Index = CInt(pm_All.Dsp_Base.FormCtl.CM_SELECTCM.Tag)
		'    Wk_Index = CInt(pm_All.Dsp_Base.FormCtl.MN_SELECTCM.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
        '�O�Ń{�^��
        'delete 20190325 START saiki
        ''UPGRADE_ISSUE: Control CM_PREV �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_PREV.Tag)
        ''UPGRADE_ISSUE: Control MN_PREV �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_PREV.Tag)
        'pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
        ''���Ń{�^��
        ''UPGRADE_ISSUE: Control CM_NEXTCM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_NEXTCM.Tag)
        ''UPGRADE_ISSUE: Control MN_NEXTCM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '      Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_NEXTCM.Tag)
        'delete 20190325 END saiki
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_MN_Enabled = 0
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_PageButton_Enabled
	'Invalid_string_refer_to_original_code
	'   �����F�@pm_All           : �S�\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_PageButton_Enabled(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		F_Ctl_PageButton_Enabled = 9
        'delete 20190325 START saiki
		'�O��
		'UPGRADE_ISSUE: Control MN_PREV �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_PREV.Tag)
        'delete 20190325 END saiki
		If NowPageNum > MinPageNum Then
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		Else
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
        End If
        'delete 20190325 START saiki
		'����
		'UPGRADE_ISSUE: Control MN_NEXTCM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_NEXTCM.Tag)
        'delete 20190325 END saiki
		If NowPageNum < MaxPageNum Then
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		Else
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
		End If

        'delete 20190325 START saiki
        ''�O�Ń{�^��
        ''UPGRADE_ISSUE: Control CM_PREV �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_PREV.Tag)
        ''UPGRADE_ISSUE: Control MN_PREV �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_PREV.Tag)
        'pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
        ''���Ń{�^��
        ''UPGRADE_ISSUE: Control CM_NEXTCM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.CM_NEXTCM.Tag)
        ''UPGRADE_ISSUE: Control MN_NEXTCM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '      Wk_Index = CShort(pm_All.Dsp_Base.FormCtl.MN_NEXTCM.Tag)
        'delete 20190325 END saiki
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
        'delete 20190325 START saiki
        ''����
        ''UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
        'Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
        ''�n��
        ''UPGRADE_ISSUE: Control HD_TIKCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_TIKCD.Tag)
        'Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
        ''�c�Ə�
        ''UPGRADE_ISSUE: Control HD_EIGCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_EIGCD.Tag)
        'Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
        ''�_�~�[
        ''UPGRADE_ISSUE: Control TX_Dummy �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.TX_Dummy.Tag)
        'Call CF_Set_Item_Focus_Ctl(Not pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
        'delete 20190325 END saiki
		If pm_Value = True Then
			'�y�[�W���i���݃y�[�W�A�ő�y�[�W���̑ޔ�ϐ��j���N���A
			'���׃y�[�W��������
			MinPageNum = 1
			MaxPageNum = 1
			NowPageNum = 0
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
			Wk_Bd_Index_S = 1
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
			'        Wk_Index = CInt(BD_LINNO(Index_Bd_Wk).Tag)
			''�d���������������������������������������������������������d
			'        'Dsp_Body_Inf�̍s�m�n�ɕϊ�
			'        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			''�r���������������������������������������������������������r
			'        'Dsp_Body_Inf�ɒl�������l��ݒ�
			'        Call F_F_Init_Dsp_Body(Wk_Row, pm_All)
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
        'delete 20190325 START saiki
        ''�r���������������������������������������������������������r
        ''�e��ʌʐݒ�(�K��DSP_SUB_INF.Detail.Focus_Ctl=True�̍��ځI�I)
        ''�_�~�[�Ƀt�H�[�J�X�ݒ�
        ''�������ޯ���擾
        'If pm_All.Dsp_Base.FormCtl.Name = "FR_SSSMAIN" Then
        '	'UPGRADE_ISSUE: Control TX_Dummy �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '	Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.TX_Dummy.Tag)
        'Else
        '	'UPGRADE_ISSUE: Control HD_BMNCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        '	Trg_Index = CShort(pm_All.Dsp_Base.FormCtl.HD_BMNCD.Tag)
        'End If
        'delete 20190325 END saiki
		'̫����ړ�
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'���ڐF�ݒ�
		' 2006/12/18  CHG START  KUMEDA
		'    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		Call CF_Set_Item_Color_MEISAI(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		' 2006/12/18  CHG END
		
		'�d���������������������������������������������������������d
		
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
		
		'��ʖ��ׂ̍s�Ɠ���̖��ׂ��C���f�b�N�X���擾
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		If Trg_Index > 0 Then
			If Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'�ړ��悪�����ꍇ
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'���ڐF�ݒ�
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				
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
			Call CF_Body_Dsp(pm_All)
			
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
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'���ʂ̖��׍폜
		Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
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
		Call CF_Body_Dsp(pm_All)
		
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
		
		'��ʂ̓��e��ޔ�
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Inf�̍s�m�n���擾
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'���ʂ̖��ב}��
		If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
			'�r���������������������������������������������������������r
			'�Ɩ��̏����l��ҏW
			Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)
			
			'�s�m���̔ԏ���
			Call F_Edi_Saiban_No(pm_All)
			'�d���������������������������������������������������������d
			
			'�Ώۍs����ʂɕ\��
			Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)
			
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
			Call CF_Body_Dsp(pm_All)
			
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
	'   �T�v�F  �\��t��
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
        'change 20190725 START hou
        '      '���݂�÷�ď�̑I����Ԃ��擾
        '      'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '      Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        '      'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '      Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        'change 20190725 END hou
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
        'change start 20190805 kuwahara
        '�ҏW���SelStart������
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
        ''�ҏW���SelLength������
        ''UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
        'change end 20190805 kuwahara
        '���ד��͌�̌㏈��
        Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	'======================= �ύX���� 2006.07.02 End =================================
	
	'======================= �ύX���� 2006.06.26 Start =================================
	'�r���������������������������������������������������������r
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
	'�d���������������������������������������������������������d
	'======================= �ύX���� 2006.06.26 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_WLS_Close
	'   �T�v�F  �e������ʃN���[�Y����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_WLS_Close() As Short
		
		F_Ctl_WLS_Close = 9
		
		'����
		WLS_MEI4.Close()
		'UPGRADE_NOTE: �I�u�W�F�N�g WLS_MEI4 ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		WLS_MEI4 = Nothing
		
		F_Ctl_WLS_Close = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Hardcopy_SSSMAIN
	'   �T�v�F  �n�[�h�R�s�[��ʌďo���㏈��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Hardcopy_SSSMAIN(ByRef pm_All As Cls_All) As Short 'Generated.
		If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		On Error Resume Next
		System.Windows.Forms.Application.DoEvents()
		pm_All.Dsp_Base.FormCtl.Cursor = System.Windows.Forms.Cursors.WaitCursor
		'UPGRADE_ISSUE: Form ���\�b�h Dsp_Base.FormCtl.PrintForm �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
        'delete 20190325 START saiki
        'pm_All.Dsp_Base.FormCtl.PrintForm()
        'delete 20190325 END saiki
		pm_All.Dsp_Base.FormCtl.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
	
	' 2007/01/18  ADD START  KUMEDA
	Public Function setSELECTB(ByRef pINDEX As Short, ByRef pm_All As Cls_All) As Object
		Dim Data_Row As Short
		Dim Index_Cnt As Short
		
		For Index_Cnt = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
			pm_All.Dsp_Body_Inf.Row_Inf(Index_Cnt).Bus_Inf.Selected = CStr(False)
		Next Index_Cnt
		
		Data_Row = (NowPageNum - 1) * pm_All.Dsp_Base.Dsp_Body_Cnt + pINDEX
		pm_All.Dsp_Body_Inf.Row_Inf(Data_Row).Bus_Inf.Selected = CStr(True)
		
	End Function
	'2007/01/18  ADD END
    'delete 20190325 START saiki
    ''ADD 20150710 START C2-20150708-01
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   ���́F  Sub F_Ctl_LAB_EXC
    ''   �T�v�F  �W���u���s�����b�Z�[�W����
    ''   �����F  pm_all              :�S�\����
    ''   �ߒl�F�@�Ȃ�
    ''   ���l�F
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Sub F_Ctl_LAB_EXC(ByRef pm_All As Cls_All)

    '	Dim intRet As Short
    '	Dim strMsg As String

    '	'�r���`�F�b�N
    '       intRet = AE_Execute_PLSQL_EXCTBZ("C", strMsg)

    '       Select Case intRet
    '           Case 0
    '               '�r���Ȃ�
    '               'UPGRADE_ISSUE: Control lab_exc �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
    '               pm_All.Dsp_Base.FormCtl.lab_exc.Visible = False
    '           Case 1
    '               '�r���G���[
    '               'UPGRADE_ISSUE: Control lab_exc �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
    '               pm_All.Dsp_Base.FormCtl.lab_exc.Visible = True
    '           Case Else
    '               '�ُ�I��
    '               MsgBox("�r���`�F�b�N�����G���[�F" & strMsg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
    '               End
    '       End Select


    'End Sub
    'ADD 20150710 END C2-20150708-01
    'delete 20190325 END saiki
End Module