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
	'�����������`�F�b�N���s�t���O
	Public gv_bolENDFP61_LF_Enable As Boolean 'LF�������s�t���O(False�F���s���Ȃ�)
	Public gv_bolKeyFlg As Boolean
	Public gv_bolCsvFlg As Boolean
	
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
	Public Const NEXT_FOCUS_MODE_KEYDOWN As Short = 3 'KEYDOWN�Ɠ��l�̐���
	'//F_Dsp_Item_Detail�������[�h
	Public Const DSP_SET As Short = 0 '�\��
	Public Const DSP_CLR As Short = 1 '�N���A
	
	'//�敪�R�[�h
	Public Const DSP_KBN_CLR As String = "1" '����
	Public Const DSP_KBN_SET As String = "2" '������
	'//�ΏۃR�[�h
	Public Const DSP_UKSMEDT As String = "1" '���グ
	Public Const DSP_SKSMEDT As String = "2" '�d����
	Public Const DSP_BOUTH As String = "3" '����
	'//�敪����
	Public Const CNST_KBN_CLR As String = "����"
	Public Const CNST_KBN_SET As String = "������"
	'//�Ώۖ���
	Public Const CNST_UKSMEDT As String = "���グ"
	Public Const CNST_SKSMEDT As String = "�d����"
	Public Const CNST_BOUTH As String = "����"
	
	'//�N������r����
	Public Const DSP_LITTLE As Short = -1 '�ߋ���
	Public Const DSP_SAME As Short = 0 '���ꌎ
	Public Const DSP_LARGE As Short = 1 '������
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_SEI_SQL
	'   �T�v�F  �f�[�^�擾�r�p�k����
	'   �����F  pm_Toksmedt :��������
	'   �ߒl�F�@����SQL
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_SEI_SQL(ByRef pm_Toksmedt As String) As String
		
		Dim strSQL As String
		
		'�����r�p�k���s
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "     A.TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & " FROM "
		strSQL = strSQL & "     TOKMTA A " '���Ӑ�}�X�^
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     A.TOKSMEDT = '" & pm_Toksmedt & "'" '���������t
		strSQL = strSQL & " AND "
		strSQL = strSQL & "     A.DATKB = '" & gc_strDATKB_USE & "' " '�`�[�폜�敪 = '1'�i�g�p���j
		
		F_GET_SEI_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_SYSTBA_NULL
	'   �T�v�F  �X�V�Ώۍ��ڂ̋󔒃`�F�b�N
	'   �����F  pm_SYSTBA    :SYSTBA���
	'       �F  pm_TARGET    :�Ώ�
	'   �ߒl�F�@�`�F�b�N���� :0��OK,-1��NG
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_SYSTBA_NULL(ByRef pm_SYSTBA As TYPE_DB_SYSTBA, ByRef pm_TARGET As String) As Short
		
		Dim Rtn_Chk As Short
		
		Rtn_Chk = CHK_OK
		
		With pm_SYSTBA
			'�O��o�������s�����󔒂̏ꍇ
			If Trim(.SMAUPDDT) = "" Then
				'�G���[�i�V�X�e���G���[�j
				Rtn_Chk = CHK_ERR_ELSE
			End If
			
			Select Case pm_TARGET
				Case DSP_UKSMEDT
					'���グ�̏ꍇ
					'�����������i����j���󔒂̏ꍇ
					If Trim(.UKSMEDT) = "" Then
						'�G���[�i�V�X�e���G���[�j
						Rtn_Chk = CHK_ERR_ELSE
					End If
					
				Case DSP_SKSMEDT
					'�d����̏ꍇ
					'�����������i�d���j���󔒂̏ꍇ
					If Trim(.SKSMEDT) = "" Then
						'�G���[�i�V�X�e���G���[�j
						Rtn_Chk = CHK_ERR_ELSE
					End If
					
				Case DSP_BOUTH
					'�����̏ꍇ
					'�����������i����j���󔒂̏ꍇ
					If Trim(.UKSMEDT) = "" Then
						'�G���[�i�V�X�e���G���[�j
						Rtn_Chk = CHK_ERR_ELSE
					End If
					
					'�����������i�d���j���󔒂̏ꍇ
					If Trim(.SKSMEDT) = "" Then
						'�G���[�i�V�X�e���G���[�j
						Rtn_Chk = CHK_ERR_ELSE
					End If
			End Select
		End With
		
		F_Chk_SYSTBA_NULL = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Jge_YMD
	'   �T�v�F  �N�����̔�r����
	'   �����F  pm_Moto_YMD    :��r���N����
	'       �F  pm_Saki_YMD    :��r��N����
	'   �ߒl�F�@��r����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Jge_YMD(ByRef pm_Moto_YMD As String, ByRef pm_Saki_YMD As String) As Short
		
		Dim strMOTO_Y As String '��r�����t�i�N�j
		Dim strMOTO_M As String '��r�����t�i���j
		Dim strMOTO_D As String '��r�����t�i���j
		
		Dim strSAKI_Y As String '��r����t�i�N�j
		Dim strSAKI_M As String '��r����t�i���j
		Dim strSAKI_D As String '��r����t�i���j
		
		Dim Rtn_Chk As Short
		
		'�����t��N�A���A���ɕ���
		Call F_Split_YMD(pm_Moto_YMD, strMOTO_Y, strMOTO_M, strMOTO_D)
		'����t��N�A���A���ɕ���
		Call F_Split_YMD(pm_Saki_YMD, strSAKI_Y, strSAKI_M, strSAKI_D)
		
		If (Int(CDbl(strMOTO_Y)) > Int(CDbl(strSAKI_Y))) Or (Int(CDbl(strMOTO_Y)) = Int(CDbl(strSAKI_Y)) And Int(CDbl(strMOTO_M)) > Int(CDbl(strSAKI_M))) Then
			'��r������r������������̏ꍇ
			Rtn_Chk = DSP_LARGE
			
		ElseIf Int(CDbl(strMOTO_Y)) = Int(CDbl(strSAKI_Y)) And Int(CDbl(strMOTO_M)) = Int(CDbl(strSAKI_M)) Then 
			'��r���Ɣ�r�悪���ꌎ�̏ꍇ
			Rtn_Chk = DSP_SAME
			
		Else
			'��r������r������ߋ����̏ꍇ
			Rtn_Chk = DSP_LITTLE
			
		End If
		
		F_Jge_YMD = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Split_YMD
	'   �T�v�F  �N�����̕�������
	'   �����F  pm_YMD    :�����O������
	'       �F  pm_Y      :�N
	'       �F  pm_M      :��
	'       �F  pm_D      :��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Split_YMD(ByRef pm_YMD As String, ByRef pm_Y As String, ByRef pm_M As String, ByRef pm_D As String) As Short
		
		'���t��N�A���A���ɕ���
		pm_Y = Mid(pm_YMD, 1, 4)
		pm_M = Mid(pm_YMD, 5, 2)
		pm_D = Mid(pm_YMD, 7, 2)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_UPD_SYSTBA_DATA
	'   �T�v�F  �������������擾
	'   �����F  pm_KBN      :�敪
	'       �F  pm_TARGET   :�Ώ�
	'       �F  pm_All      :�S�\����
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_UPD_SYSTBA_DATA(ByRef pm_KBN As String, ByRef pm_TARGET As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: �\���� Mst_Inf_SYSTBA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim Err_Cd As String
		
		Dim Rtn_Chk As Short
		Dim Rtn_Chk2 As Short
		Dim Rtn_Chk3 As Short
		Dim bol_UKSMEDT As Boolean '�����������i����j���s��
		Dim bol_SKSMEDT As Boolean '�����������i�d���j���s��
		Dim str_UKSMEDT As String '�����������i����j���H��N����
		Dim str_SKSMEDT As String '�����������i�d���j���H��N����
		Dim intAddMonth As Short
		
		On Error GoTo ERR_F_UPD_SYSTBA_DATA
		
		F_UPD_SYSTBA_DATA = -1
		
		'������
		Err_Cd = ""
		bol_UKSMEDT = False
		bol_SKSMEDT = False
		
		If pm_KBN = DSP_KBN_CLR Then
			'����
			intAddMonth = -1
		Else
			'������
			intAddMonth = 1
		End If
		'������������������������������������������������������������������������
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'���[�U�[���Ǘ��e�[�u������
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			'�擾�f�[�^�Ȃ�
			Err_Cd = gc_strMsgENDFP61_E_010
			GoTo END_F_UPD_SYSTBA_DATA
		End If
		'������������������������������������������������������������������������
		
		'������������������������������������������������������������������������
		'�󔒃`�F�b�N
		If F_Chk_SYSTBA_NULL(Mst_Inf_SYSTBA, pm_TARGET) <> CHK_OK Then
			'�G���[�i�V�X�e���G���[�j
			Err_Cd = gc_strMsgENDFP61_E_009
			GoTo END_F_UPD_SYSTBA_DATA
		End If
		'������������������������������������������������������������������������
		
		'�Ó����`�F�b�N
		With Mst_Inf_SYSTBA
			
			'������������������������������������������������������������������������
			' 2007/04/02  CHG START  KUMEDA
			''        '�O��o�������s���ƃV�X�e�����t�̔�r
			''        Rtn_Chk = F_Jge_YMD(.SMAUPDDT, GV_UNYDate)
			''
			''        Select Case pm_TARGET
			''            Case DSP_UKSMEDT
			''            '���グ
			''                '�����������i����j�ƃV�X�e�����t�̔�r
			''                Rtn_Chk2 = F_Jge_YMD(.UKSMEDT, GV_UNYDate)
			''
			''            Case DSP_SKSMEDT
			''            '�d����̏ꍇ
			''                '�����������i�d���j�ƃV�X�e�����t�̔�r
			''                Rtn_Chk3 = F_Jge_YMD(.SKSMEDT, GV_UNYDate)
			''
			''            Case DSP_BOUTH
			''            '�����̏ꍇ
			''                '�����������i����j�ƃV�X�e�����t�̔�r
			''                Rtn_Chk2 = F_Jge_YMD(.UKSMEDT, GV_UNYDate)
			''                '�����������i�d���j�ƃV�X�e�����t�̔�r
			''                Rtn_Chk3 = F_Jge_YMD(.SKSMEDT, GV_UNYDate)
			''
			''        End Select
			'''������������������������������������������������������������������������
			''
			''
			'''������������������������������������������������������������������������
			''        If pm_TARGET = DSP_UKSMEDT Or pm_TARGET = DSP_BOUTH Then
			''        '���グ or ����
			''
			''            If Rtn_Chk2 = DSP_SAME Then
			''            '�����������i����j���V�X�e�����t�i�N���j
			''
			''                Select Case pm_KBN
			''                    Case DSP_KBN_CLR
			''                    '����
			''                        If Rtn_Chk = DSP_LITTLE Then
			''                        '�O��o�������s�����V�X�e�����t�i�N���j
			''                            '�����߉����n�j�I�I�I(o'-^)b
			''                            bol_UKSMEDT = True
			''                        Else
			''                            '�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
			''                            Err_Cd = gc_strMsgENDFP61_E_003
			''                        End If
			''
			''                    Case DSP_KBN_SET
			''                    '������
			''                        '�G���[�i�������ւ̉����߂��s�����Ƃ͂ł��܂���B�j
			''                        Err_Cd = gc_strMsgENDFP61_E_004
			''
			''                End Select
			''
			''            ElseIf Rtn_Chk2 = DSP_LITTLE Then
			''            '�����������i����j���V�X�e�����t�i�N���j
			''
			''                Select Case pm_KBN
			''                    Case DSP_KBN_CLR
			''                    '����
			''                        '�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
			''                        Err_Cd = gc_strMsgENDFP61_E_003
			''
			''                    Case DSP_KBN_SET
			''                    '������
			''                        If Rtn_Chk = DSP_LITTLE Then
			''                        '�O��o�������s�����V�X�e�����t�i�N���j
			''                            '�����n�j�I�I�I(o'-^)b
			''                            bol_UKSMEDT = True
			''                        Else
			''                            '�G���[�i�������ւ̉����߂��s�����Ƃ͂ł��܂���B�j
			''                            Err_Cd = gc_strMsgENDFP61_E_004
			''                        End If
			''
			''                End Select
			''
			''            Else
			''            '�����������i����j���V�X�e�����t�i�N���j
			''
			''                Select Case pm_KBN
			''                    Case DSP_KBN_CLR
			''                    '����
			''                        If Rtn_Chk = DSP_LARGE Then
			''                        '�O��o�������s�����V�X�e�����t�i�N���j
			''                            '�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
			''                            Err_Cd = gc_strMsgENDFP61_E_003
			''                        Else
			''                            '�����߉����n�j�I�I�I(o'-^)b
			''                            bol_UKSMEDT = True
			''                        End If
			''
			''                    Case DSP_KBN_SET
			''                    '������
			''                        '�G���[�i�������ւ̉����߂��s�����Ƃ͂ł��܂���B�j
			''                        Err_Cd = gc_strMsgENDFP61_E_004
			''
			''                End Select
			''
			''            End If
			''
			''        End If
			''
			''        If pm_TARGET = DSP_SKSMEDT Or pm_TARGET = DSP_BOUTH Then
			''        '�d���� or ����
			''
			''            If Rtn_Chk3 = DSP_SAME Then
			''            '�����������i�d���j���V�X�e�����t�i�N���j
			''
			''                Select Case pm_KBN
			''                    Case DSP_KBN_CLR
			''                    '����
			''                        If Rtn_Chk = DSP_LITTLE Then
			''                        '�O��o�������s�����V�X�e�����t�i�N���j
			''                            '�����߉����n�j�I�I�I(o'-^)b
			''                            bol_SKSMEDT = True
			''                        Else
			''                            '�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
			''                            Err_Cd = gc_strMsgENDFP61_E_003
			''                        End If
			''
			''                    Case DSP_KBN_SET
			''                    '������
			''                        '�G���[�i�������ւ̉����߂��s�����Ƃ͂ł��܂���B�j
			''                        Err_Cd = gc_strMsgENDFP61_E_004
			''
			''                End Select
			''
			''            ElseIf Rtn_Chk3 = DSP_LITTLE Then
			''            '�����������i�d���j���V�X�e�����t�i�N���j
			''
			''                Select Case pm_KBN
			''                    Case DSP_KBN_CLR
			''                    '����
			''                        '�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
			''                        Err_Cd = gc_strMsgENDFP61_E_003
			''
			''                    Case DSP_KBN_SET
			''                    '������
			''                        If Rtn_Chk = DSP_LITTLE Then
			''                        '�O��o�������s�����V�X�e�����t�i�N���j
			''                            '�����n�j�I�I�I(o'-^)b
			''                            bol_SKSMEDT = True
			''                        Else
			''                            '�G���[�i�������ւ̉����߂��s�����Ƃ͂ł��܂���B�j
			''                            Err_Cd = gc_strMsgENDFP61_E_004
			''                        End If
			''
			''                End Select
			''
			''            Else
			''            '�����������i�d���j���V�X�e�����t�i�N���j
			''
			''                Select Case pm_KBN
			''                    Case DSP_KBN_CLR
			''                    '����
			''                        If Rtn_Chk = DSP_LARGE Then
			''                        '�O��o�������s�����V�X�e�����t�i�N���j
			''                            '�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
			''                            Err_Cd = gc_strMsgENDFP61_E_003
			''                        Else
			''                            '�����߉����n�j�I�I�I(o'-^)b
			''                            bol_SKSMEDT = True
			''                        End If
			''
			''                    Case DSP_KBN_SET
			''                    '������
			''                        '�G���[�i�������ւ̉����߂��s�����Ƃ͂ł��܂���B�j
			''                        Err_Cd = gc_strMsgENDFP61_E_004
			''                End Select
			''
			''            End If
			''
			''        End If
			Select Case pm_TARGET
				Case DSP_UKSMEDT
					'���グ
					'�����������i����j�ƃV�X�e�����t�̔�r
					Rtn_Chk2 = F_Jge_YMD(.UKSMEDT, .SMAUPDDT)
					
				Case DSP_SKSMEDT
					'�d����̏ꍇ
					'�����������i�d���j�ƃV�X�e�����t�̔�r
					Rtn_Chk3 = F_Jge_YMD(.SKSMEDT, .SMAUPDDT)
					
				Case DSP_BOUTH
					'�����̏ꍇ
					'�����������i����j�ƃV�X�e�����t�̔�r
					Rtn_Chk2 = F_Jge_YMD(.UKSMEDT, .SMAUPDDT)
					'�����������i�d���j�ƃV�X�e�����t�̔�r
					Rtn_Chk3 = F_Jge_YMD(.SKSMEDT, .SMAUPDDT)
					
			End Select
			
			If pm_TARGET = DSP_UKSMEDT Or pm_TARGET = DSP_BOUTH Then
				'���グ or ����
				
				If Rtn_Chk2 = DSP_SAME Then
					'�����������i����j���o�������t�͉����n�j
					
					Select Case pm_KBN
						Case DSP_KBN_CLR
							'����
							'�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
							Err_Cd = gc_strMsgENDFP61_E_003
							
						Case DSP_KBN_SET
							'������
							bol_UKSMEDT = True
							
					End Select
					
				ElseIf Rtn_Chk2 = DSP_LITTLE Then 
					'�����������i����j���o�������t�@����{�I�ɋN���肦�Ȃ�
					
					Select Case pm_KBN
						Case DSP_KBN_CLR
							'����
							'�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
							Err_Cd = gc_strMsgENDFP61_E_003
							
						Case DSP_KBN_SET
							'������
							bol_UKSMEDT = True
							
					End Select
					
				Else
					'�����������i����j���o�������t�͉��������n�j
					
					Select Case pm_KBN
						Case DSP_KBN_CLR
							'����
							bol_UKSMEDT = True
							
						Case DSP_KBN_SET
							'������
							'�G���[�i�������ւ̉����߂��s�����Ƃ͂ł��܂���B�j
							Err_Cd = gc_strMsgENDFP61_E_004
							
					End Select
					
				End If
				
			End If
			
			If pm_TARGET = DSP_SKSMEDT Or pm_TARGET = DSP_BOUTH Then
				'�d���� or ����
				
				If Rtn_Chk3 = DSP_SAME Then
					'�����������i�d���j���o�������t�͉����n�j
					
					Select Case pm_KBN
						Case DSP_KBN_CLR
							'����
							'�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
							Err_Cd = gc_strMsgENDFP61_E_003
							
						Case DSP_KBN_SET
							'������
							bol_SKSMEDT = True
							
					End Select
					
				ElseIf Rtn_Chk3 = DSP_LITTLE Then 
					'�����������i�d���j���o�������t�@����{�I�ɋN���肦�Ȃ�
					
					Select Case pm_KBN
						Case DSP_KBN_CLR
							'����
							'�G���[�i�{���ߍςׁ݂̈A�����ł��܂���B�j
							Err_Cd = gc_strMsgENDFP61_E_003
							
						Case DSP_KBN_SET
							'������
							bol_SKSMEDT = True
							
					End Select
					
				Else
					'�����������i�d���j���o�������t�͉��������n�j
					
					Select Case pm_KBN
						Case DSP_KBN_CLR
							'����
							bol_SKSMEDT = True
							
						Case DSP_KBN_SET
							'������
							'�G���[�i�������ւ̉����߂��s�����Ƃ͂ł��܂���B�j
							Err_Cd = gc_strMsgENDFP61_E_004
					End Select
					
				End If
				
			End If
			' 2007/04/02  CHG END
			'������������������������������������������������������������������������
			
			
			'������������������������������������������������������������������������
			If bol_UKSMEDT = False And bol_SKSMEDT = False Then
				'�����������i����j�A�����������i�d���j���ɍX�V�s�̏ꍇ
				GoTo END_F_UPD_SYSTBA_DATA
			End If
			'������������������������������������������������������������������������
			
			
			'������������������������������������������������������������������������
			'True�̍��ڂɑ΂��āA�����߁�+1�����A������-1�����̓��t���擾
			If bol_UKSMEDT = True Then
				strSQL = ""
				strSQL = strSQL & " SELECT ADD_MONTHS(TO_DATE('" & .UKSMEDT & "','YYYYMMDD')," & intAddMonth & ") AS NEW_DATE FROM DUAL  "
				
				'SQL���s
				Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
				
				If CF_Ora_EOF(Usr_Ody) = True Then
					GoTo END_F_UPD_SYSTBA_DATA
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				str_UKSMEDT = CF_Ora_GetDyn(Usr_Ody, "NEW_DATE", "")
				str_UKSMEDT = CF_Get_Input_Ok_Item(str_UKSMEDT, pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_UKSMEDT.Tag)))
				
			End If
			
			If bol_SKSMEDT = True Then
				strSQL = ""
				strSQL = strSQL & " SELECT ADD_MONTHS(TO_DATE('" & .SKSMEDT & "','YYYYMMDD')," & intAddMonth & ") AS NEW_DATE FROM DUAL  "
				
				'SQL���s
				Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
				
				If CF_Ora_EOF(Usr_Ody) = True Then
					GoTo END_F_UPD_SYSTBA_DATA
				End If
				
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				str_SKSMEDT = CF_Ora_GetDyn(Usr_Ody, "NEW_DATE", "")
				str_SKSMEDT = CF_Get_Input_Ok_Item(str_SKSMEDT, pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SKSMEDT.Tag)))
				
			End If
			'������������������������������������������������������������������������
			
		End With
		
		'������������������������������������������������������������������������
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBA  "
		strSQL = strSQL & "    SET OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		
		If bol_UKSMEDT = True Then
			strSQL = strSQL & "      , UKSMEDT  = '" & str_UKSMEDT & "' " '�����������i����j
		End If
		
		If bol_SKSMEDT = True Then
			strSQL = strSQL & "      , SKSMEDT  = '" & str_SKSMEDT & "' " '�����������i�d���j
		End If
		
		'SQL���s
		If CF_Ora_Execute(gv_Odb_USR1, strSQL) = False Then
			GoTo ERR_F_UPD_SYSTBA_DATA
		End If
		'������������������������������������������������������������������������
		
		Err_Cd = ""
		F_UPD_SYSTBA_DATA = CHK_OK
		
END_F_UPD_SYSTBA_DATA: 
		
		If Err_Cd <> "" Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_F_UPD_SYSTBA_DATA: 
		
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgENDFP61_E_009, pm_All, "F_UPD_SYSTBA_DATA")
		GoTo END_F_UPD_SYSTBA_DATA
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GET_NYK_SOUCD
	'   �T�v�F  �O����͂��ꂽ�q�ɃR�[�h�̎擾
	'   �����F  �Ȃ�
	'   �ߒl�F�@�擾�s��
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_NYK_SOUCD() As Short
		'
		'    Dim strSQL          As String
		'    Dim intData         As Integer
		'    Dim Usr_Ody         As U_Ody
		'    Dim intMode         As Integer
		'    Dim intCnt          As Integer
		'    Dim Wk_Index        As Integer
		'    Dim Err_Cd          As String
		'
		'    On Error GoTo ERR_F_GET_NYK_SOUCD
		'
		'    F_GET_NYK_SOUCD = -1
		'
		'    '������
		'    Err_Cd = ""
		'    gv_NYKDTRA_SOUCD = ""
		'
		'    '�����r�p�k����
		'    strSQL = F_GET_NYK_SOUCD_SQL
		'
		'    'DB�A�N�Z�X
		'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		'
		'    If CF_Ora_EOF(Usr_Ody) = True Then
		'        '�擾�f�[�^�Ȃ�
		'        gv_bolNYKDTRA_Flg = False
		'        F_GET_NYK_SOUCD = 0
		'    Else
		'        gv_NYKDTRA_SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")            '�q�ɃR�[�h
		'        gv_bolNYKDTRA_Flg = True
		'
		'        F_GET_NYK_SOUCD = 1
		'    End If
		'
		'    '�N���[�Y
		'    Call CF_Ora_CloseDyn(Usr_Ody)
		'
		'    Exit Function
		'
		'ERR_F_GET_NYK_SOUCD:
		'
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
		Call CF_Body_Dsp(pm_All)
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
					' === 20060823 === UPDATE S - ACE)Nagasawa �S�I�����A�Q�����ȏ����͂���Ɛ擪������������Ή�
					'                pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
					' === 20060823 === UPDATE E -
					'�ҏW���SelLength������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					
					' === 20060801 === INSERT S - ACE)Nagasawa �P�����ڂœ��͌�Ƀt�H�[�J�X�ړ����Ȃ����Ƃւ̑Ή�
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
		
		'�c�X�N���[���o�[�̒l���ŏ㖾�ײ��ޯ���ɐݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_All.Dsp_Body_Inf.Cur_Top_Index = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
		'��ʃ{�f�B���̔z����Đݒ�
		Call CF_Dell_Refresh_Body_Inf(pm_All)
		
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
						Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
							'KEYRETURN�AKEYDOWN�̏ꍇ
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
							
							'��ʃ{�f�B���̔z����Đݒ�
							Call CF_Dell_Refresh_Body_Inf(pm_All)
							
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
		
		'���̍��ڂ�����
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'�w�b�_������{�f�B���ֈړ�����ꍇ
				'�r��������������������������������������������������������
				'ͯ�ޕ�����
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				'�d���������������������������������������������������������d
				If Rtn_Chk = CHK_OK Then
					'�`�F�b�NOK�̏ꍇ
					'���s�O�`�F�b�N
					If F_Chk_CM_Execute(pm_All) Then
						Exit For
					End If
					
				Else
					'�`�F�b�N�m�f�̏ꍇ
					'�L�[�t���O�����ɖ߂�
					gv_bolKeyFlg = False
					Exit For
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
					'�P���ڂ�I������
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelStart = 1
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
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
						
						'�L�[�t���O�����ɖ߂�
						gv_bolKeyFlg = False
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
	'   ���́F  Function F_Chk_HD_KBN
	'   �T�v�F  �敪�i�R�[�h�j������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KBN(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_KBN = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Msg_Flg = False
		pm_Chk_Move = True
		Err_Cd = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgENDFP61_E_001
			Else
				'���͉\�R�[�h�`�F�b�N
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case DSP_KBN_CLR, DSP_KBN_SET
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						'�L�[�t���O�����ɖ߂�
						gv_bolKeyFlg = False
						
					Case Else
						'�m�f
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgENDFP61_E_001
						
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
		
		F_Chk_HD_KBN = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Chk_HD_TARGET
	'   �T�v�F  �Ώہi�R�[�h�j������
	'   �����F�@pm_Chk_Dsp_Sub_Inf    :��ʍ��ڏ��
	'           pm_Chk_Move�@�@�@�@�@ :�`�F�b�N��ړ��t���O�iT�F�ړ�OK�AF�F�ړ�NG�j
	'           pm_All�@�@�@�@�@      :�S�\����
	'   �ߒl�F�@�`�F�b�N����
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TARGET(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'�`�F�b�N���s����
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'���f�̏ꍇ
			F_Chk_HD_TARGET = Retn_Code
			Exit Function
		End If
		
		'�r���������������������������������������������������������r
		'������
		Retn_Code = CHK_OK
		Msg_Flg = False
		pm_Chk_Move = True
		Err_Cd = ""
		
		'�����̓`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			
		Else
			'�����͈ȊO�̃`�F�b�N��
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'��b�`�F�b�N
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgENDFP61_E_001
			Else
				'���͉\�R�[�h�`�F�b�N
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case DSP_UKSMEDT, DSP_SKSMEDT, DSP_BOUTH
						'�n�j
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						'�L�[�t���O�����ɖ߂�
						gv_bolKeyFlg = False
						
					Case Else
						'�m�f
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgENDFP61_E_001
						
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
		
		F_Chk_HD_TARGET = Retn_Code
		
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
		
		'���͍��ڂ������͂��`�F�b�N
		If F_Chk_All_Input_Serch(pm_All) Then
			bolChk = True
		End If
		
		F_Chk_CM_Execute = bolChk
		
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
		Dim Trg_Index As Short
		
		'������
		bolAll = False
		Err_Cd = ""
		
		'�����������S�Ė����͂Ȃ�G���[
		With FR_SSSMAIN
			
			If Trim(.HD_KBN.Text) = "" Then
				'�敪�i�R�[�h�j�������͂̏ꍇ
				'�������ޯ���擾
				Trg_Index = CShort(.HD_KBN.Tag)
				Err_Cd = gc_strMsgENDFP61_E_002
			ElseIf Trim(.HD_TARGET.Text) = "" Then 
				'�Ώہi�R�[�h�j�������͂̏ꍇ
				'�������ޯ���擾
				Trg_Index = CShort(.HD_TARGET.Tag)
				Err_Cd = gc_strMsgENDFP61_E_002
			End If
			
			If Err_Cd <> "" Then
				'���b�Z�[�W�o��
				Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
				
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)
				
				bolAll = True
			End If
			
		End With
		
		F_Chk_All_Input_Serch = bolAll
		
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
			Case FR_SSSMAIN.HD_KBN.Name
				'�敪�i�R�[�h�j�ɂ���ʕ\��
				Call F_Dsp_HD_KBN_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_TARGET.Name
				'�Ώہi�R�[�h�j�ɂ���ʕ\��
				Call F_Dsp_HD_TARGET_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
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
	Private Function F_DSP_BD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim intCnt As Short
		
		If pm_Mode = DSP_SET Then
			'�\��
			'�f�[�^�ҏW
			Call F_SET_BD_DATA(pm_All)
		End If
		
		'�������e�A�O����e��ޔ�
		Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_Update_Process
	'   �T�v�F  �����������C�����[�`��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0 :���������I���@9:���������Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Update_Process(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim intErrIdx As Short
		Dim strJdnNo As String
		Dim Trg_Index As Short
		Dim Chk_Move_Flg As Boolean
		
		Dim strKBN As String
		Dim strTARGET As String
		
		F_Ctl_Update_Process = 9
		
		If gv_bolCsvFlg = True Then
			Exit Function
		End If
		
		gv_bolCsvFlg = True
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'�e���ڂ�����ٰ��
		Trg_Index = CShort(FR_SSSMAIN.HD_KBN.Tag)
		intRet = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
		If intRet <> CHK_OK Then
			If intRet = CHK_ERR_NOT_INPUT Then
				'�����̓G���[
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgENDFP61_E_002, pm_All)
			End If
			GoTo End_F_Ctl_Update_Process
		End If
		'��ʂ̋敪�i�R�[�h�j���擾����
		strKBN = CF_Get_Input_Ok_Item((FR_SSSMAIN.HD_KBN.Text), pm_All.Dsp_Sub_Inf(Trg_Index))
		
		Trg_Index = CShort(FR_SSSMAIN.HD_TARGET.Tag)
		intRet = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
		If intRet <> CHK_OK Then
			If intRet = CHK_ERR_NOT_INPUT Then
				'�����̓G���[
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgENDFP61_E_002, pm_All)
			End If
			GoTo End_F_Ctl_Update_Process
		End If
		'��ʂ̑Ώہi�R�[�h�j���擾����
		strTARGET = CF_Get_Input_Ok_Item((FR_SSSMAIN.HD_TARGET.Text), pm_All.Dsp_Sub_Inf(Trg_Index))
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'�m�F���b�Z�[�W�\��
		If strKBN = DSP_KBN_CLR Then
			'����
			intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgENDFP61_A_005, pm_All)
		Else
			'������
			intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgENDFP61_A_006, pm_All)
		End If
		
		'�����v�ɂ���
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		Select Case intRet
			Case MsgBoxResult.Yes
				' 2007/01/11  ADD START  KUMEDA   *** �����`�F�b�N�ꏊ�̕ύX
				If Inp_Inf.InpJDNUPDKB = "9" Then
					gv_bolCsvFlg = False
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgENDFP61_E_011, pm_All)
					GoTo End_F_Ctl_Update_Process
				End If
				' 2007/01/11  ADD END
				'�{�^����\��
				FR_SSSMAIN.CM_Execute.Visible = False
				
				'����������������
				intRet = F_UPD_SYSTBA_DATA(strKBN, strTARGET, pm_All)
				If intRet <> 0 Then
					GoTo Err_F_Ctl_Update_Process
				End If
				
				'��ʍĕ`��
				Call Init_HD_Inf(pm_All)
				
			Case Else ' �߂�
				GoTo End_F_Ctl_Update_Process
		End Select
		
		'���탁�b�Z�[�W�\��
		intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgENDFP61_E_007, pm_All)
		
		F_Ctl_Update_Process = 0
		
End_F_Ctl_Update_Process: 
		
		'�}�E�X�|�C���^��߂�
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'�{�^���\��
		FR_SSSMAIN.CM_Execute.Visible = True
		
		gv_bolCsvFlg = False
		
		'�L�[�t���O�����ɖ߂�
		gv_bolKeyFlg = False
		
		Exit Function
		
Err_F_Ctl_Update_Process: 
		
		GoTo End_F_Ctl_Update_Process
		
	End Function
	
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_KBN_Inf
	'   �T�v�F  �敪�i�R�[�h�j�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf   : ��ʍ��ڏ��
	'           pm_Mode          : ��ʕ\�����[�h
	'           pm_All           : ��ʏ��
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KBN_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			'�敪�i�R�[�h�j���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'�y�敪���z
				Trg_Index = CShort(FR_SSSMAIN.HD_KBNNM.Tag)
				Select Case CF_Get_Item_Value(pm_Dsp_Sub_Inf)
					Case DSP_KBN_CLR
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Dsp_Value = CNST_KBN_CLR
					Case DSP_KBN_SET
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Dsp_Value = CNST_KBN_SET
					Case Else
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Dsp_Value = ""
				End Select
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			'�y�敪���z
			Trg_Index = CShort(FR_SSSMAIN.HD_KBNNM.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'�d���������������������������������������������������������d
		End If
		
		'�O��`�F�b�N���e�ɑޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Dsp_HD_TARGET_Inf
	'   �T�v�F  �Ώہi�R�[�h�j�ɂ���ʕ\��
	'   �����F  pm_Dsp_Sub_Inf      :��ʏ��
	'           pm_Mode             :���[�h
	'           pm_all              :�S�\����
	'   �ߒl�F
	'   ���l�F  �v���O�����P�ʂ̋��ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TARGET_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'�\��
			'�Ώہi�R�[�h�j���ύX���ꂽ�ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value(pm_Dsp_Sub_Inf) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'�r���������������������������������������������������������r
				'�y�Ώۖ��z
				Trg_Index = CShort(FR_SSSMAIN.HD_TARGETNM.Tag)
				Select Case CF_Get_Item_Value(pm_Dsp_Sub_Inf)
					Case DSP_UKSMEDT
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Dsp_Value = CNST_UKSMEDT
					Case DSP_SKSMEDT
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Dsp_Value = CNST_SKSMEDT
					Case DSP_BOUTH
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Dsp_Value = CNST_BOUTH
					Case Else
						'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Dsp_Value = ""
				End Select
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'�d���������������������������������������������������������d
				
				'�������e�A�O����e��ޔ�
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'�N���A
			'�r���������������������������������������������������������r
			'�y�Ώۖ��z
			Trg_Index = CShort(FR_SSSMAIN.HD_TARGETNM.Tag)
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
		
		'�@��{���͓��e�̃`�F�b�N
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'�r���������������������������������������������������������r
			Case FR_SSSMAIN.HD_KBN.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'�敪�i�R�[�h�j������
				Rtn_Chk = F_Chk_HD_KBN(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_TARGET.Name
				'�����O����(�����֐��̑O�ŕK�{����)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'�Ώہi�R�[�h�j������
				Rtn_Chk = F_Chk_HD_TARGET(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
		End Select
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
				Case FR_SSSMAIN.TX_Dummy.Name
					'�d���������������������������������������������������������d
					'������Ԃœ��͉\�Ⱥ��۰�
					'���͉\
					Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
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
		
		'    '���݂̃t�H�[�J�X�ʒu�ɉ����āA�e���۰ق̎g�p�ۂ𐧌�
		'    Select Case pm_All.Dsp_Base.Cursor_Idx
		'        Case CInt(FR_SSSMAIN.HD_KBN.Tag)
		'            '���s
		'            Trg_Index = CInt(FR_SSSMAIN.MN_Execute.Tag)
		'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		'''            '��ʈ��
		'''            Trg_Index = CInt(FR_SSSMAIN.MN_HARDCOPY.Tag)
		'''            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		'            '�I��
		'            Trg_Index = CInt(FR_SSSMAIN.MN_EndCm.Tag)
		'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		'
		'
		'    End Select
		
		'���j���[�{�^���C���[�W�̉�����
		'�I���{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_EndCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'���s�{�^��
		Trg_Index = CShort(FR_SSSMAIN.CM_Execute.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_MN_Enabled = 0
		
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
		
		'�敪�i�R�[�h�j
		Trg_Index = CShort(FR_SSSMAIN.HD_KBN.Tag)
		Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		'�Ώہi�R�[�h�j
		Trg_Index = CShort(FR_SSSMAIN.HD_TARGET.Tag)
		Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		'�_�~�[
		Trg_Index = CShort(FR_SSSMAIN.TX_Dummy.Tag)
		Call CF_Set_Item_Focus_Ctl(Not pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
		
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
		'    Dim Mst_Inf             As TYPE_DB_SOUMTA
		
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
			'�ʏ�����
			Select Case Index_Wk
				'�敪
				Case CShort(FR_SSSMAIN.HD_KBN.Tag)
					Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item("", pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_KBNNM.Tag)), False), pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_KBNNM.Tag)), pm_All, SET_FLG_DEF)
					
					'�Ώ�
				Case CShort(FR_SSSMAIN.HD_TARGET.Tag)
					Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item("", pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_TARGETNM.Tag)), False), pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_TARGETNM.Tag)), pm_All, SET_FLG_DEF)
					
			End Select
			'�d���������������������������������������������������������d
			
		Next 
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Set_Body_Location
	'   �T�v�F  ��ʏ����\�����e�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function Init_HD_Inf(ByRef pm_All As Cls_All) As Short
		'�r���������������������������������������������������������r
		
		'UPGRADE_WARNING: �\���� Mst_Inf_SYSTBA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim Wk_Index As Short
		
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'���[�U�[���Ǘ��e�[�u������
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			'�擾�f�[�^�Ȃ�
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgENDFP61_E_010, pm_All)
			Exit Function
		End If
		
		With Mst_Inf_SYSTBA
			'�O��o�������s��
			Wk_Index = CShort(FR_SSSMAIN.HD_SMAUPDDT.Tag)
			Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(.SMAUPDDT, pm_All.Dsp_Sub_Inf(Wk_Index), True), pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			'�����������i����j
			Wk_Index = CShort(FR_SSSMAIN.HD_UKSMEDT.Tag)
			Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(.UKSMEDT, pm_All.Dsp_Sub_Inf(Wk_Index), True), pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			'�����������i�d���j
			Wk_Index = CShort(FR_SSSMAIN.HD_SKSMEDT.Tag)
			Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(.SKSMEDT, pm_All.Dsp_Sub_Inf(Wk_Index), True), pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
		End With
		
		'�d���������������������������������������������������������d
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
		'�o�ɗ\����Ƀt�H�[�J�X�ݒ�
		'�������ޯ���擾
		Trg_Index = CShort(FR_SSSMAIN.HD_KBN.Tag)
		
		'̫����ړ�
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'���ڐF�ݒ�
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
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
		
		'    '��������
		'    Unload WLS_DATE
		'    Set WLS_DATE = Nothing
		
		F_Ctl_WLS_Close = 0
		
	End Function
	
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
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module