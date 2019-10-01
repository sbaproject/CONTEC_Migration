Option Strict Off
Option Explicit On
Module URKET51_DBM
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPTOKMTA_KOZNO_SEARCH
	'   �T�v�F  ���Ӑ�R�[�h����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPTOKMTA_KOZNO_SEARCH(ByVal pin_strKOZNO As String, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody

        '2019/04/02 ADD START
        Dim dt As DataTable = New DataTable
        '2019/04/02 ADD E N D

		On Error GoTo ERR_DSPTOKMTA_KOZNO_SEARCH
		
		DSPTOKMTA_KOZNO_SEARCH = 9

        '2019/06/27 CHG START
        'Call DB_TOKMTA_Clear(pot_DB_TOKMTA)
        pot_DB_TOKMTA = New TYPE_DB_TOKMTA
        '2019/06/27 CHG E N D

        strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from TOKMTA "
		strSQL = strSQL & "  Where KOZNO = '" & pin_strKOZNO & "' "
		
        'DB�A�N�Z�X
        '2019/04/02 CHG START
        'Call CF_Ora_CreateDynK(gv_Odb_USR1, Usr_Ody, strSQL)
        'If CF_Ora_EOF(Usr_Ody) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/04/02 CHG E N D

            '�擾�f�[�^�Ȃ�
            DSPTOKMTA_KOZNO_SEARCH = 1
            GoTo END_DSPTOKMTA_KOZNO_SEARCH
        End If

        '2019/04/02 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        'Call DB_TOKMTA_SetData(Usr_Ody, pot_DB_TOKMTA)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            Call DB_TOKMTA_SetData(dt, pot_DB_TOKMTA)
            '2019/04/02 CHG E N D
        End If

        DSPTOKMTA_KOZNO_SEARCH = 0

END_DSPTOKMTA_KOZNO_SEARCH:
        '2019/04/10 DEL START
        ''�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/10 DEL E N D
        Exit Function

ERR_DSPTOKMTA_KOZNO_SEARCH:
        GoTo END_DSPTOKMTA_KOZNO_SEARCH
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_TOKMTA_SetData
    '   �T�v�F  ���Ӑ�}�X�^�\���̃f�[�^�ޔ�
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/08 CHG START
    'Private Sub DB_TOKMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA)
    Private Sub DB_TOKMTA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA)
        '2019/04/08 CHG E N D
        '�f�[�^�ޔ�
        With pot_DB_TOKMTA
            '2019/04/08 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '�`�[�폜�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKMSTKB", "") '�}�X�^�敪�i���Ӑ�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.THSCD = CF_Ora_GetDyn(pin_Usr_Ody, "THSCD", "") '����敪��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKNMA = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMA", "") '���Ӑ於�̂P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKNMB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMB", "") '���Ӑ於�̂Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKRN = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRN", "") '���Ӑ旪��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKNK = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNK", "") '���Ӑ於�̃J�i
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKNMC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMC", "") '���Ӑ於�̔��p�P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKNMD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMD", "") '���Ӑ於�̔��p�Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKRNNK = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRNNK", "") '���Ӑ旪�̃J�i
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKZP = CF_Ora_GetDyn(pin_Usr_Ody, "TOKZP", "") '���Ӑ�X�֔ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKADA = CF_Ora_GetDyn(pin_Usr_Ody, "TOKADA", "") '���Ӑ�Z���P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKADB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKADB", "") '���Ӑ�Z���Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKADC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKADC", "") '���Ӑ�Z���R
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKTL = CF_Ora_GetDyn(pin_Usr_Ody, "TOKTL", "") '���Ӑ�d�b�ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKFX = CF_Ora_GetDyn(pin_Usr_Ody, "TOKFX", "") '���Ӑ�e�`�w�ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKBOSNM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKBOSNM", "") '���Ӑ��\�Җ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKTANNM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKTANNM", "") '���Ӑ��S���Җ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKMLAD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKMLAD", "") '���Ӑ惁�[���A�h���X
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TANCD = CF_Ora_GetDyn(pin_Usr_Ody, "TANCD", "") '�S���҃R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TANNM = CF_Ora_GetDyn(pin_Usr_Ody, "TANNM", "") '�S���Җ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.LMTKN = CF_Ora_GetDyn(pin_Usr_Ody, "LMTKN", 0) '�^�M���x�z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCLAKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLAKB", "") '���ދ敪�P�i���Ӑ�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCLBKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLBKB", "") '���ދ敪�Q�i���Ӑ�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCLCKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLCKB", "") '���ދ敪�R�i���Ӑ�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCLAID = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLAID", "") '���ރR�[�h�P�i���Ӑ�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCLBID = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLBID", "") '���ރR�[�h�Q�i���Ӑ�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCLCID = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLCID", "") '���ރR�[�h�R�i���Ӑ�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCLANM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLANM", "") '�^�M���x�ݒ��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCLBNM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLBNM", "") '���ޖ��̂Q�i���Ӑ�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCLCNM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLCNM", "") '���ޖ��̂R�i���Ӑ�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DSPKB = CF_Ora_GetDyn(pin_Usr_Ody, "DSPKB", "") '�����\���敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKJUNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKJUNKB", "") '���ʕ\�o�͋敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSEICD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSEICD", "") '������R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MAINHSCD = CF_Ora_GetDyn(pin_Usr_Ody, "MAINHSCD", "") '��\�[����R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSMEKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEKB", "") '���敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSMEDD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEDD", "") '���������t�i����j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSMECC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMECC", "") '���T�C�N���i����j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSDWKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSDWKB", "") '���ߗj��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKKESCC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKKESCC", "") '����T�C�N��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKKESDD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKKESDD", "") '������t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKKDWKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKKDWKB", "") '����j��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.LSTID = CF_Ora_GetDyn(pin_Usr_Ody, "LSTID", "") '�`�[���
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TKNRPSKB = CF_Ora_GetDyn(pin_Usr_Ody, "TKNRPSKB", "") '���z�[����������
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TKNZRNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TKNZRNKB", "") '���z�[�������敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKZEIKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKZEIKB", "") '����ŋ敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKZCLKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKZCLKB", "") '����ŎZ�o�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKRPSKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRPSKB", "") '����Œ[����������
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKZRNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKZRNKB", "") '����Œ[�������敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKNMMKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMMKB", "") '�����ƭ�ً敪(��)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SKCHKB = CF_Ora_GetDyn(pin_Usr_Ody, "SKCHKB", "") '�����敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.IKOUKB = CF_Ora_GetDyn(pin_Usr_Ody, "IKOUKB", "") '�ڍs�f�[�^�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKLEADD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKLEADD", "") '�^������
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.URKZANDT = CF_Ora_GetDyn(pin_Usr_Ody, "URKZANDT", "") '���|�c�����t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.URKZANKN = CF_Ora_GetDyn(pin_Usr_Ody, "URKZANKN", 0) '���|�c�����z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SEIZANDT = CF_Ora_GetDyn(pin_Usr_Ody, "SEIZANDT", "") '�����c�����t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SEIZANKN = CF_Ora_GetDyn(pin_Usr_Ody, "SEIZANKN", 0) '�����c�����z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SMAZANDT = CF_Ora_GetDyn(pin_Usr_Ody, "SMAZANDT", "") '�o�����c�����t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SMAZANKN = CF_Ora_GetDyn(pin_Usr_Ody, "SMAZANKN", 0) '�o�����c�����z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SSAZANDT = CF_Ora_GetDyn(pin_Usr_Ody, "SSAZANDT", "") '�����E�x�����c�����t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SSAZANKN = CF_Ora_GetDyn(pin_Usr_Ody, "SSAZANKN", 0) '�����E�x�����c�����z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSMEDT = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEDT", "") '���������t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SSKKZADT = CF_Ora_GetDyn(pin_Usr_Ody, "SSKKZADT", "") '�����������c�����t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.OLDTOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "OLDTOKCD", "") '�������R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TGRPCD = CF_Ora_GetDyn(pin_Usr_Ody, "TGRPCD", "") '��\��ЃR�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.OLTGRPCD = CF_Ora_GetDyn(pin_Usr_Ody, "OLTGRPCD", "") '����\��ЃR�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KIGYOCD = CF_Ora_GetDyn(pin_Usr_Ody, "KIGYOCD", "") '�����ƃR�[�h�i���ʁj
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KGYEDACD = CF_Ora_GetDyn(pin_Usr_Ody, "KGYEDACD", "") '�����ƃR�[�h�i�}�ԁj
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KAKZUKE = CF_Ora_GetDyn(pin_Usr_Ody, "KAKZUKE", "") '�i�t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BNKCD = CF_Ora_GetDyn(pin_Usr_Ody, "BNKCD", "") '��s�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.YKNKB = CF_Ora_GetDyn(pin_Usr_Ody, "YKNKB", "") '�a�����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KOZNO = CF_Ora_GetDyn(pin_Usr_Ody, "KOZNO", "") '�����ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HMEIGI = CF_Ora_GetDyn(pin_Usr_Ody, "HMEIGI", "") '�U�����`
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SHAKB = CF_Ora_GetDyn(pin_Usr_Ody, "SHAKB", "") '�x���敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TEGSHKN = CF_Ora_GetDyn(pin_Usr_Ody, "TEGSHKN", 0) '��`�x�����z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TEGRT = CF_Ora_GetDyn(pin_Usr_Ody, "TEGRT", 0) '��`�䗦
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NYUDD = CF_Ora_GetDyn(pin_Usr_Ody, "NYUDD", 0) '�T�C�g
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TEGSHBS = CF_Ora_GetDyn(pin_Usr_Ody, "TEGSHBS", "") '��`�x���ꏊ
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HTSUKB = CF_Ora_GetDyn(pin_Usr_Ody, "HTSUKB", "") '�U���萔�����S�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FCTCMCD = CF_Ora_GetDyn(pin_Usr_Ody, "FCTCMCD", "") '�t�@�N�^�����O��ЃR�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.GYOSHU = CF_Ora_GetDyn(pin_Usr_Ody, "GYOSHU", "") '�Ǝ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CHIIKI = CF_Ora_GetDyn(pin_Usr_Ody, "CHIIKI", "") '�n��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SEIHKKB = CF_Ora_GetDyn(pin_Usr_Ody, "SEIHKKB", "") '���������s�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKDNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKDNKB", "") '�q��w��`�[�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TUKKB = CF_Ora_GetDyn(pin_Usr_Ody, "TUKKB", "") '�ʉ݋敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BINCD = CF_Ora_GetDyn(pin_Usr_Ody, "BINCD", "") '�֖��R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FRNKB = CF_Ora_GetDyn(pin_Usr_Ody, "FRNKB", "") '�C�O����敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SIMUKE = CF_Ora_GetDyn(pin_Usr_Ody, "SIMUKE", "") '�d���n
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKB = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKB", "") '�d�c�h�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBC = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBC", "") '�d�c�h�����敪�i�������j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBCU = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBCU", "") '�d�c�h�����敪�i�������j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBN = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBN", "") '�d�c�h�����敪�i�[���񓚁j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBS = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBS", "") '�d�c�h�����敪�i�o�גʒm�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBSEI = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBSEI", "") '�d�c�h�����敪�i�������j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBNYU = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBNYU", "") '�d�c�h�����敪�i�������j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBP = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBP", "") '�d�c�h�����敪�i�x�����ׁj
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBYBA = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBYBA", "") '�d�c�h�����敪�i���i���j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBYBB = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBYBB", "") '�d�c�h�����敪�i�\���Q�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EDIKBYBC = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBYBC", "") '�d�c�h�����敪�i�\���R�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.RELFL = CF_Ora_GetDyn(pin_Usr_Ody, "RELFL", "") '�A�g�t���O
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATKB"), "") '�`�[�폜�敪
            .TOKMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKMSTKB"), "") '�}�X�^�敪�i���Ӑ�j
            .THSCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("THSCD"), "") '����敪��
            .TOKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCD"), "") '���Ӑ�R�[�h
            .TOKNMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMA"), "") '���Ӑ於�̂P
            .TOKNMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMB"), "") '���Ӑ於�̂Q
            .TOKRN = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRN"), "") '���Ӑ旪��
            .TOKNK = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNK"), "") '���Ӑ於�̃J�i
            .TOKNMC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMC"), "") '���Ӑ於�̔��p�P
            .TOKNMD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMD"), "") '���Ӑ於�̔��p�Q
            .TOKRNNK = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRNNK"), "") '���Ӑ旪�̃J�i
            .TOKZP = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZP"), "") '���Ӑ�X�֔ԍ�
            .TOKADA = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKADA"), "") '���Ӑ�Z���P
            .TOKADB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKADB"), "") '���Ӑ�Z���Q
            .TOKADC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKADC"), "") '���Ӑ�Z���R
            .TOKTL = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKTL"), "") '���Ӑ�d�b�ԍ�
            .TOKFX = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKFX"), "") '���Ӑ�e�`�w�ԍ�
            .TOKBOSNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKBOSNM"), "") '���Ӑ��\�Җ�
            .TOKTANNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKTANNM"), "") '���Ӑ��S���Җ�
            .TOKMLAD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKMLAD"), "") '���Ӑ惁�[���A�h���X
            .TANCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANCD"), "") '�S���҃R�[�h
            .TANNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANNM"), "") '�S���Җ�
            .LMTKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("LMTKN"), 0) '�^�M���x�z
            .TOKCLAKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLAKB"), "") '���ދ敪�P�i���Ӑ�j
            .TOKCLBKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLBKB"), "") '���ދ敪�Q�i���Ӑ�j
            .TOKCLCKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLCKB"), "") '���ދ敪�R�i���Ӑ�j
            .TOKCLAID = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLAID"), "") '���ރR�[�h�P�i���Ӑ�j
            .TOKCLBID = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLBID"), "") '���ރR�[�h�Q�i���Ӑ�j
            .TOKCLCID = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLCID"), "") '���ރR�[�h�R�i���Ӑ�j
            .TOKCLANM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLANM"), "") '�^�M���x�ݒ��
            .TOKCLBNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLBNM"), "") '���ޖ��̂Q�i���Ӑ�j
            .TOKCLCNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLCNM"), "") '���ޖ��̂R�i���Ӑ�j
            .DSPKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DSPKB"), "") '�����\���敪
            .TOKJUNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKJUNKB"), "") '���ʕ\�o�͋敪
            .TOKSEICD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSEICD"), "") '������R�[�h
            .MAINHSCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("MAINHSCD"), "") '��\�[����R�[�h
            .TOKSMEKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEKB"), "") '���敪
            .TOKSMEDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEDD"), "") '���������t�i����j
            .TOKSMECC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMECC"), "") '���T�C�N���i����j
            .TOKSDWKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSDWKB"), "") '���ߗj��
            .TOKKESCC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKESCC"), "") '����T�C�N��
            .TOKKESDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKESDD"), "") '������t
            .TOKKDWKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKDWKB"), "") '����j��
            .LSTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("LSTID"), "") '�`�[���
            .TKNRPSKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TKNRPSKB"), "") '���z�[����������
            .TKNZRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TKNZRNKB"), "") '���z�[�������敪
            .TOKZEIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZEIKB"), "") '����ŋ敪
            .TOKZCLKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZCLKB"), "") '����ŎZ�o�敪
            .TOKRPSKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRPSKB"), "") '����Œ[����������
            .TOKZRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZRNKB"), "") '����Œ[�������敪
            .TOKNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMMKB"), "") '�����ƭ�ً敪(��)
            .SKCHKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("SKCHKB"), "") '�����敪
            .IKOUKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("IKOUKB"), "") '�ڍs�f�[�^�敪
            .TOKLEADD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKLEADD"), "") '�^������
            .URKZANDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("URKZANDT"), "") '���|�c�����t
            .URKZANKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("URKZANKN"), 0) '���|�c�����z
            .SEIZANDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SEIZANDT"), "") '�����c�����t
            .SEIZANKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SEIZANKN"), 0) '�����c�����z
            .SMAZANDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SMAZANDT"), "") '�o�����c�����t
            .SMAZANKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SMAZANKN"), 0) '�o�����c�����z
            .SSAZANDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSAZANDT"), "") '�����E�x�����c�����t
            .SSAZANKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSAZANKN"), 0) '�����E�x�����c�����z
            .TOKSMEDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEDT"), "") '���������t
            .SSKKZADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSKKZADT"), "") '�����������c�����t
            .OLDTOKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("OLDTOKCD"), "") '�������R�[�h
            .TGRPCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TGRPCD"), "") '��\��ЃR�[�h
            .OLTGRPCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("OLTGRPCD"), "") '����\��ЃR�[�h
            .KIGYOCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("KIGYOCD"), "") '�����ƃR�[�h�i���ʁj
            .KGYEDACD = DB_NullReplace(pin_Usr_Ody.Rows(0)("KGYEDACD"), "") '�����ƃR�[�h�i�}�ԁj
            .KAKZUKE = DB_NullReplace(pin_Usr_Ody.Rows(0)("KAKZUKE"), "") '�i�t
            .BNKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("BNKCD"), "") '��s�R�[�h
            .YKNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("YKNKB"), "") '�a�����
            .KOZNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("KOZNO"), "") '�����ԍ�
            .HMEIGI = DB_NullReplace(pin_Usr_Ody.Rows(0)("HMEIGI"), "") '�U�����`
            .SHAKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("SHAKB"), "") '�x���敪
            .TEGSHKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGSHKN"), 0) '��`�x�����z
            .TEGRT = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGRT"), 0) '��`�䗦
            .NYUDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUDD"), 0) '�T�C�g
            .TEGSHBS = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGSHBS"), "") '��`�x���ꏊ
            .HTSUKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HTSUKB"), "") '�U���萔�����S�敪
            .FCTCMCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("FCTCMCD"), "") '�t�@�N�^�����O��ЃR�[�h
            .GYOSHU = DB_NullReplace(pin_Usr_Ody.Rows(0)("GYOSHU"), "") '�Ǝ�
            .CHIIKI = DB_NullReplace(pin_Usr_Ody.Rows(0)("CHIIKI"), "") '�n��
            .SEIHKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("SEIHKKB"), "") '���������s�敪
            .TOKDNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKDNKB"), "") '�q��w��`�[�敪
            .TUKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TUKKB"), "") '�ʉ݋敪
            .BINCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("BINCD"), "") '�֖��R�[�h
            .FRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("FRNKB"), "") '�C�O����敪
            .SIMUKE = DB_NullReplace(pin_Usr_Ody.Rows(0)("SIMUKE"), "") '�d���n
            .EDIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKB"), "") '�d�c�h�敪
            .EDIKBC = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBC"), "") '�d�c�h�����敪�i�������j
            .EDIKBCU = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBCU"), "") '�d�c�h�����敪�i�������j
            .EDIKBN = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBN"), "") '�d�c�h�����敪�i�[���񓚁j
            .EDIKBS = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBS"), "") '�d�c�h�����敪�i�o�גʒm�j
            .EDIKBSEI = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBSEI"), "") '�d�c�h�����敪�i�������j
            .EDIKBNYU = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBNYU"), "") '�d�c�h�����敪�i�������j
            .EDIKBP = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBP"), "") '�d�c�h�����敪�i�x�����ׁj
            .EDIKBYBA = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBYBA"), "") '�d�c�h�����敪�i���i���j
            .EDIKBYBB = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBYBB"), "") '�d�c�h�����敪�i�\���Q�j
            .EDIKBYBC = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBYBC"), "") '�d�c�h�����敪�i�\���R�j
            .RELFL = DB_NullReplace(pin_Usr_Ody.Rows(0)("RELFL"), "") '�A�g�t���O
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j

            '2019/04/08 CHG E N D
        End With
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMEIMTA_SEARCH_SORTUSE
    '   �T�v�F  ���̃}�X�^����
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pot_DB_MEIMTA : �������ʁi�z��j
    '           pin_strSORT   : �\�[�gSQL������
    '   �ߒl�F�@0:����I�� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIMTA_SEARCH_SORTUSE(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA, ByVal pin_strSORT As String) As Short
		
		Dim strSQL As String
		Dim strSQL_Where As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
        '2019/10 ADD START
        Dim dt As DataTable
        '2019/04/10 ADD E N D

        On Error GoTo ERR_DSPMEIMTA_SEARCH_SORTUSE
		
		DSPMEIMTA_SEARCH_SORTUSE = 9
		
		'�߂�l�̃N���A
		Erase pot_DB_MEIMTA
		
		strSQL = ""
		strSQL = strSQL & " Select Count(*) As CNTDATA"
		
		strSQL_Where = ""
		strSQL_Where = strSQL_Where & "   from MEIMTA "
		strSQL_Where = strSQL_Where & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		
		strSQL = strSQL & strSQL_Where

        'DB�A�N�Z�X
        '2019/04/10 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/04/10 CHG E N D

        '�����擾
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/10 CHG START
        'intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))
        intData = CF_Get_CCurString(DB_NullReplace(dt.Rows(0)("CNTDATA"), 0))
        '2019/04/10 CHG E N D

        '2019/04/10 DEL START
        ''�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/10 DEL E N D

        '����
        strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & strSQL_Where
		
		'���я�
		If Trim(pin_strSORT) <> "" Then
			strSQL = strSQL & "  Order By " & pin_strSORT
		End If
		
		
		ReDim pot_DB_MEIMTA(intData)

        'DB�A�N�Z�X
        '2019/04/10 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/04/10 CHG E N D

        '�擾�f�[�^�ޔ�
        intData = 1
        '2019/04/10 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True

        '	Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intData))

        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        '	intData = intData + 1
        'Loop 
        For i As Integer = 0 To dt.Rows.Count - 1
            'change 20190807 START hou
            'Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData))
            Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData), intData)
            'change 20190807 END hou
            intData = intData + 1
        Next
        '2019/04/10 CHG E N D

        DSPMEIMTA_SEARCH_SORTUSE = 0

END_DSPMEIMTA_SEARCH_SORTUSE:
        '2019/04/10 DEL START
        ''�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/01 DEL E N D
        Exit Function
		
ERR_DSPMEIMTA_SEARCH_SORTUSE: 
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_MEIMTA_SetData
    '   �T�v�F  ���̃}�X�^�\���̃f�[�^�ޔ�
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/10 CHG START
    'Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)

    'change 20190807 START hou
    'Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)
    '    '2019/04/10 CHG E N D
    Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, ByRef intData As Integer)
        'change 20190807 END hou
        '�f�[�^�ޔ�
        With pot_DB_MEIMTA
            '2019/04/10 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '�`�[�폜�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KEYCD = CF_Ora_GetDyn(pin_Usr_Ody, "KEYCD", "") '�L�[
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEIKMKNM = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKMKNM", "") '���ږ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEICDA = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDA", "") '�R�[�h�P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEICDB = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDB", "") '�R�[�h�Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEINMA = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMA", "") '���̂P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEINMB = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMB", "") '���̂Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEINMC = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMC", "") '���̂R
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEISUA = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUA", 0) '���l���ڂP
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEISUB = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUB", 0) '���l���ڂQ
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEISUC = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUC", 0) '���l���ڂR
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEIKBA = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBA", "") '�敪�P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEIKBB = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBB", "") '�敪�Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MEIKBC = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBC", "") '�敪�R
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DSPORD = CF_Ora_GetDyn(pin_Usr_Ody, "DSPORD", "") '�\������
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.RELFL = CF_Ora_GetDyn(pin_Usr_Ody, "RELFL", "") '�A�g�t���O
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '����o�^�S����ID
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '����o�^�N���C�A���gID
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") '��ѽ����(����o�^����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") '��ѽ����(����o�^���t)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '�X�V�S���҃R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '�X�V�N���C�A���g�h�c
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") '��ѽ����(�X�V����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") '��ѽ����(�X�V���t)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") '�o�b�`�X�V�S���҃R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") '�o�b�`�X�V�N���C�A���gID
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") '��ѽ����(�o�b�`�X�V����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") '��ѽ����(�o�b�`�X�V���t)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") '��۸���ID

            'change 20190807 START  hou
            '.DATKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATKB"), "") '�`�[�폜�敪

            '.KEYCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("KEYCD"), "") '�L�[

            '.MEIKMKNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEIKMKNM"), "") '���ږ�

            '.MEICDA = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEICDA"), "") '�R�[�h�P

            '.MEICDB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEICDB"), "") '�R�[�h�Q

            '.MEINMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEINMA"), "") '���̂P

            '.MEINMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEINMB"), "") '���̂Q

            '.MEINMC = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEINMC"), "") '���̂R

            '.MEISUA = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEISUA"), "0") '���l���ڂP

            '.MEISUB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEISUB"), "0") '���l���ڂQ

            '.MEISUC = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEISUC"), "0") '���l���ڂR

            '.MEIKBA = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEIKBA"), "") '�敪�P

            '.MEIKBB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEIKBB"), "") '�敪�Q

            '.MEIKBC = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEIKBC"), "") '�敪�R

            '.DSPORD = DB_NullReplace(pin_Usr_Ody.Rows(0)("DSPORD"), "") '�\������

            '.RELFL = DB_NullReplace(pin_Usr_Ody.Rows(0)("RELFL"), "") '�A�g�t���O

            '.FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FOPEID"), "") '����o�^�S����ID

            '.FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FCLTID"), "") '����o�^�N���C�A���gID

            '.WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTTM"), "") '��ѽ����(����o�^����)

            '.WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTDT"), "") '��ѽ����(����o�^���t)

            '.OPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("OPEID"), "") '�X�V�S���҃R�[�h

            '.CLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("CLTID"), "") '�X�V�N���C�A���g�h�c

            '.WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTTM"), "") '��ѽ����(�X�V����)

            '.WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTDT"), "") '��ѽ����(�X�V���t)

            '.UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UOPEID"), "") '�o�b�`�X�V�S���҃R�[�h

            '.UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UCLTID"), "") '�o�b�`�X�V�N���C�A���gID

            '.UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTTM"), "") '��ѽ����(�o�b�`�X�V����)

            '.UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTDT"), "") '��ѽ����(�o�b�`�X�V���t)

            '.PGID = DB_NullReplace(pin_Usr_Ody.Rows(0)("PGID"), "") '��۸���ID
            ''2019/04/10 CHG E N D
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("DATKB"), "") '�`�[�폜�敪
            .KEYCD = DB_NullReplace(pin_Usr_Ody.Rows(intData)("KEYCD"), "") '�L�[
            .MEIKMKNM = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEIKMKNM"), "") '���ږ�
            .MEICDA = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEICDA"), "") '�R�[�h�P
            .MEICDB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEICDB"), "") '�R�[�h�Q
            .MEINMA = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEINMA"), "") '���̂P
            .MEINMB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEINMB"), "") '���̂Q
            .MEINMC = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEINMC"), "") '���̂R
            .MEISUA = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEISUA"), "0") '���l���ڂP
            .MEISUB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEISUB"), "0") '���l���ڂQ
            .MEISUC = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEISUC"), "0") '���l���ڂR
            .MEIKBA = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEIKBA"), "") '�敪�P
            .MEIKBB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEIKBB"), "") '�敪�Q
            .MEIKBC = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEIKBC"), "") '�敪�R
            .DSPORD = DB_NullReplace(pin_Usr_Ody.Rows(intData)("DSPORD"), "") '�\������
            .RELFL = DB_NullReplace(pin_Usr_Ody.Rows(intData)("RELFL"), "") '�A�g�t���O
            .FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("FOPEID"), "") '����o�^�S����ID
            .FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("FCLTID"), "") '����o�^�N���C�A���gID
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(intData)("WRTFSTTM"), "") '��ѽ����(����o�^����)
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(intData)("WRTFSTDT"), "") '��ѽ����(����o�^���t)
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("OPEID"), "") '�X�V�S���҃R�[�h
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("CLTID"), "") '�X�V�N���C�A���g�h�c
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(intData)("WRTTM"), "") '��ѽ����(�X�V����)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(intData)("WRTDT"), "") '��ѽ����(�X�V���t)
            .UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("UOPEID"), "") '�o�b�`�X�V�S���҃R�[�h
            .UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("UCLTID"), "") '�o�b�`�X�V�N���C�A���gID
            .UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(intData)("UWRTTM"), "") '��ѽ����(�o�b�`�X�V����)
            .UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(intData)("UWRTDT"), "") '��ѽ����(�o�b�`�X�V���t)
            .PGID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("PGID"), "") '��۸���ID
            'change 20190807 END hou
        End With
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_SYSTBD_Clear
    '   �T�v�F  �V�X�e�����b�Z�[�W�e�[�u���\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Sub DB_SYSTBD_Clear(ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD)
		
		Dim Clr_DB_SYSTBD As TYPE_DB_SYSTBD
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_DB_SYSTBD = Clr_DB_SYSTBD
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function SYSTBD_SEARCH
	'   �T�v�F  ����敪�e�[�u������
	'   �����F  pin_strDKBSB    : �`�[����敪���
	'           pin_strDKBID    : ����敪�R�[�h
	'           pot_DB_SYSTBD   : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SYSTBD_SEARCH(ByVal pin_strDKBSB As String, ByVal pin_strDKBID As String, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_SYSTBD_SEARCH
		
		SYSTBD_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from SYSTBD "
		strSQL = strSQL & "  Where DKBSB = '" & CF_Ora_Sgl(pin_strDKBSB) & "' "
            strSQL = strSQL & "    And DKBID = '" & CF_Ora_Sgl(pin_strDKBID) & "' "

        'DB�A�N�Z�X
        '2019/04/08 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then

        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/04/08 CHG E N D
            '�擾�f�[�^�Ȃ�
            SYSTBD_SEARCH = 1
            GoTo END_SYSTBD_SEARCH
        End If

        '2019/04/08 CHG START
        'If CF_Ora_EOF(Usr_Ody_LC) = False Then
        'Call DB_SYSTBD_SetData(Usr_Ody_LC, pot_DB_SYSTBD)
        'End If
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            Call DB_SYSTBD_SetData(dt, pot_DB_SYSTBD, 0)
        End If
        '2019/04/08 CHG E N D

        SYSTBD_SEARCH = 0
		
END_SYSTBD_SEARCH:

        '2019/04/08 DEL START
        ''�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/08 DEL E N D

        Exit Function
		
ERR_SYSTBD_SEARCH: 
		GoTo END_SYSTBD_SEARCH
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function SYSTBD_SEARCH_ALL
	'   �T�v�F  ����敪�e�[�u������
	'   �����F  pin_strDKBSB    : �`�[����敪���
	'           pot_DB_SYSTBD   : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SYSTBD_SEARCH_ALL(ByVal pin_strDKBSB As String, ByRef pot_DB_SYSTBD() As TYPE_DB_SYSTBD) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim intIdx As Short
        '2019/04/10 ADD START
        Dim dt As DataTable
        '2019/04/10 ADD E N D
        On Error GoTo ERR_SYSTBD_SEARCH_ALL
		
		SYSTBD_SEARCH_ALL = 9
		
		strSQL = ""
		strSQL = strSQL & "   from SYSTBD "
		strSQL = strSQL & "  Where DKBSB = '" & CF_Ora_Sgl(pin_strDKBSB) & "' "
		strSQL = strSQL & " order by DKBID "
		
		'�����擾
		strSQLCount = ""
		strSQLCount = strSQLCount & " Select Count(*) as DataCount "
		strSQLCount = strSQLCount & strSQL

        'DB�A�N�Z�X
        '2019/04/10 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)

        dt = DB_GetTable(strSQLCount)
        intData = DB_NullReplace(dt.Rows(0)("DataCount"), 0)
        '2019/04/10 CHG E N D

        '2019/04/10 DEL START
        ''�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/10 DEL E N D

        If intData = 0 Then
			'�擾�f�[�^�Ȃ�
			SYSTBD_SEARCH_ALL = 1
			Exit Function
		End If
		
		strSQL = " Select * " & strSQL

        'DB�A�N�Z�X
        '2019/04/08 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/04/08 CHG E N D
            '�擾�f�[�^�Ȃ�
            SYSTBD_SEARCH_ALL = 1
            GoTo END_SYSTBD_SEARCH_ALL
        End If

        '�擾�f�[�^�ޔ�
        ReDim pot_DB_SYSTBD(intData)
        '2019/04.08 CHG START
        'intIdx = 1
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
        '    Call DB_SYSTBD_SetData(Usr_Ody_LC, pot_DB_SYSTBD(intIdx))
        '    intIdx = intIdx + 1
        '    Call CF_Ora_MoveNext(Usr_Ody_LC)
        'Loop

        For i As Integer = 0 To dt.Rows.Count - 1
            Call DB_SYSTBD_SetData(dt, pot_DB_SYSTBD(i), i)
        Next
        '2019/04/08 CHG E N D

        SYSTBD_SEARCH_ALL = 0
		
END_SYSTBD_SEARCH_ALL:
        '2019/04/09 DEL START
        '�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/09 DEL E N D
        Exit Function
		
ERR_SYSTBD_SEARCH_ALL: 
		GoTo END_SYSTBD_SEARCH_ALL
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_SYSTBD_SetData
    '   �T�v�F  ����敪�e�[�u���\���̃f�[�^�ޔ�
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Sub DB_SYSTBD_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD)
    Private Sub DB_SYSTBD_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD, ByVal DataCount As Integer)
        '�f�[�^�ޔ�
        With pot_DB_SYSTBD
            '2019/04/08 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBSB = CF_Ora_GetDyn(pin_Usr_Ody, "DKBSB", "") '�`�[����敪���
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBID = CF_Ora_GetDyn(pin_Usr_Ody, "DKBID", "") '����敪�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBNM = CF_Ora_GetDyn(pin_Usr_Ody, "DKBNM", "") '����敪����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UPDID = CF_Ora_GetDyn(pin_Usr_Ody, "UPDID", "") '�X�V�p���ޯ��(ACNT)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DFLDKBCD = CF_Ora_GetDyn(pin_Usr_Ody, "DFLDKBCD", "") '�f�t�H���g�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBZAIFL = CF_Ora_GetDyn(pin_Usr_Ody, "DKBZAIFL", "") '�݌Ɋ֘A�t���O
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBTEGFL = CF_Ora_GetDyn(pin_Usr_Ody, "DKBTEGFL", "") '��`�����t���O
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBFLA = CF_Ora_GetDyn(pin_Usr_Ody, "DKBFLA", "") '�_�~�[�t���O�P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBFLB = CF_Ora_GetDyn(pin_Usr_Ody, "DKBFLB", "") '�_�~�[�t���O�Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBFLC = CF_Ora_GetDyn(pin_Usr_Ody, "DKBFLC", "") '�_�~�[�t���O�R
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") '��ѽ����(����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") '��ѽ����(���t)
            .DKBSB = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBSB"), "") '�`�[����敪���
            .DKBID = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBID"), "") '����敪�R�[�h
            .DKBNM = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBNM"), "") '����敪����
            .UPDID = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("UPDID"), "") '�X�V�p���ޯ��(ACNT)
            .DFLDKBCD = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DFLDKBCD"), "") '�f�t�H���g�R�[�h
            .DKBZAIFL = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBZAIFL"), "") '�݌Ɋ֘A�t���O
            .DKBTEGFL = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBTEGFL"), "") '��`�����t���O
            .DKBFLA = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBFLA"), "") '�_�~�[�t���O�P
            .DKBFLB = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBFLB"), "") '�_�~�[�t���O�Q
            .DKBFLC = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBFLC"), "") '�_�~�[�t���O�R
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("CLTID"), "") '�N���C�A���g�h�c
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("WRTTM"), "") '��ѽ����(����)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("WRTDT"), "") '��ѽ����(���t)
            '2019/04/08 CHG E N D
        End With
    End Sub
End Module