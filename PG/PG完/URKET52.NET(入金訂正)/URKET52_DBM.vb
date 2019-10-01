Option Strict Off
Option Explicit On
Module URKET52_DBM
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPUDNTHA_SEARCH
	'   �T�v�F  ���㌩�o�g���� �f�[�^����
	'   �����F  pin_strDATNO     : ����`�[�Ǘ��ԍ�
	'           pot_DB_UDNTHA    : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPUDNTHA_SEARCH(ByVal pin_strDATNO As String, ByRef pot_DB_UDNTHA As TYPE_DB_UDNTHA) As Short
		
		Dim strSQL As String
		Dim strCountSQL As String
		Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_LC As U_Ody

        '2019/06/03 ADD START
        Dim dt As DataTable = New DataTable
        '2019/06/03 ADD END

        On Error GoTo ERR_DSPUDNTHA_SEARCH

        DSPUDNTHA_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM UDNTHA "
		strSQL = strSQL & " WHERE DATNO = '" & CF_Ora_Sgl(pin_strDATNO) & "'"

        'DB�A�N�Z�X
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        '      If CF_Ora_EOF(Usr_Ody_LC) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/06/03 CHG END

            '�擾�f�[�^�Ȃ�
            DSPUDNTHA_SEARCH = 1
            GoTo END_DSPUDNTHA_SEARCH
        End If

        '�擾�f�[�^�ޔ�
        '2019/06/03 CHG START
        'If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '    Call DB_UDNTHA_SetData(Usr_Ody_LC, pot_DB_UDNTHA)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            Call DB_UDNTHA_SetData(dt, pot_DB_UDNTHA)
            '2019/06/03 CHG END
        End If

        DSPUDNTHA_SEARCH = 0

END_DSPUDNTHA_SEARCH: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPUDNTHA_SEARCH: 
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_UDNTHA_SetData
    '   �T�v�F  ���㌩�o�g���� �f�[�^�\���̃f�[�^�ޔ�
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_UDNTHA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_UDNTHA As TYPE_DB_UDNTHA)
        '�f�[�^�ޔ�
        With pot_DB_UDNTHA
            '2019/06/03 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DATNO = CF_Ora_GetDyn(pin_Usr_Ody, "DATNO", "") '�`�[�Ǘ�NO.
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '�`�[�폜�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.AKAKROKB = CF_Ora_GetDyn(pin_Usr_Ody, "AKAKROKB", "") '�ԍ��敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DENKB = CF_Ora_GetDyn(pin_Usr_Ody, "DENKB", "") '�`�[�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "UDNNO", "") '����`�[�ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "FDNNO", "") '�`�[�Ǘ�NO.
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.JDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "JDNNO", "") '�󒍔ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.USDNO = CF_Ora_GetDyn(pin_Usr_Ody, "USDNO", "") '�����`�[NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UDNDT = CF_Ora_GetDyn(pin_Usr_Ody, "UDNDT", "") '����`�[���t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DENDT = CF_Ora_GetDyn(pin_Usr_Ody, "DENDT", "") '�`�[���t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.REGDT = CF_Ora_GetDyn(pin_Usr_Ody, "REGDT", "") '����`�[���t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKRN = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRN", "") '���Ӑ旪��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSCD = CF_Ora_GetDyn(pin_Usr_Ody, "NHSCD", "") '�[����R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSRN = CF_Ora_GetDyn(pin_Usr_Ody, "NHSRN", "") '�[���旪��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSNMA = CF_Ora_GetDyn(pin_Usr_Ody, "NHSNMA", "") '�[���於�̂P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSNMB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSNMB", "") '�[���於�̂Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TANCD = CF_Ora_GetDyn(pin_Usr_Ody, "TANCD", "") '�S���҃R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TANNM = CF_Ora_GetDyn(pin_Usr_Ody, "TANNM", "") '�S���Җ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BUMCD = CF_Ora_GetDyn(pin_Usr_Ody, "BUMCD", "") '����R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BUMNM = CF_Ora_GetDyn(pin_Usr_Ody, "BUMNM", "") '���喼
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSEICD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSEICD", "") '������R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SOUCD = CF_Ora_GetDyn(pin_Usr_Ody, "SOUCD", "") '�q�ɃR�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SOUNM = CF_Ora_GetDyn(pin_Usr_Ody, "SOUNM", "") '�q�ɖ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NXTKB = CF_Ora_GetDyn(pin_Usr_Ody, "NXTKB", "") '���[�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NXTNM = CF_Ora_GetDyn(pin_Usr_Ody, "NXTNM", "") '���[����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EMGODNKB = CF_Ora_GetDyn(pin_Usr_Ody, "EMGODNKB", "") '�ً}�o�׋敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.OKRJONO = CF_Ora_GetDyn(pin_Usr_Ody, "OKRJONO", "") '�����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.INVNO = CF_Ora_GetDyn(pin_Usr_Ody, "INVNO", "") '�C���{�C�X��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SMADT = CF_Ora_GetDyn(pin_Usr_Ody, "SMADT", "") '�o�������t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SSADT = CF_Ora_GetDyn(pin_Usr_Ody, "SSADT", "") '�����t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KESDT = CF_Ora_GetDyn(pin_Usr_Ody, "KESDT", "") '���ϓ��t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NYUCD = CF_Ora_GetDyn(pin_Usr_Ody, "NYUCD", "") '�����敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ZKTKB = CF_Ora_GetDyn(pin_Usr_Ody, "ZKTKB", "") '����敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ZKTNM = CF_Ora_GetDyn(pin_Usr_Ody, "ZKTNM", "") '����敪��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KENNMA = CF_Ora_GetDyn(pin_Usr_Ody, "KENNMA", "") '�����P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KENNMB = CF_Ora_GetDyn(pin_Usr_Ody, "KENNMB", "") '�����Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSADA = CF_Ora_GetDyn(pin_Usr_Ody, "NHSADA", "") '�[����Z���P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSADB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSADB", "") '�[����Z���Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSADC = CF_Ora_GetDyn(pin_Usr_Ody, "NHSADC", "") '�[����Z���R
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MAEUKNM = CF_Ora_GetDyn(pin_Usr_Ody, "MAEUKNM", "") '�O��敪����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KEIBUMCD = CF_Ora_GetDyn(pin_Usr_Ody, "KEIBUMCD", "") '�o������R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UPFKB = CF_Ora_GetDyn(pin_Usr_Ody, "UPFKB", "") '���㓯���o�׋敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SBAURIKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAURIKN", 0) '������z(�{�̍��v)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SBAUZEKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAUZEKN", 0) '������z(����Ŋz)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SBAUZKKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAUZKKN", 0) '������z(�`�[�v)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SBAFRUKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAFRUKN", 0) '�O�ݔ�����z(�`�[�v)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SBANYUKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBANYUKN", 0) '�������z(�`�[�v)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SBAFRNKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAFRNKN", 0) '�O�ݓ����z(�`�[�v)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DENCM = CF_Ora_GetDyn(pin_Usr_Ody, "DENCM", "") '���l
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DENCMIN = CF_Ora_GetDyn(pin_Usr_Ody, "DENCMIN", "") '�Г����l
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSMEKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEKB", "") '���敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSMEDD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEDD", "") '���������t(����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSMECC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMECC", "") '���T�C�N��(����)
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
            '.TOKJUNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKJUNKB", "") '���ʕ\�o�͋敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKMSTKB", "") '�}�X�^�敪(���Ӑ�)
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
            '.TOKNMMKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMMKB", "") '�����ƭ�ً敪�i���j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSMSTKB", "") '�}�X�^�敪(�[����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSNMMKB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSNMMKB", "") '�����ƭ�ً敪�i�[�j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TANMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TANMSTKB", "") '�}�X�^�敪(�S����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.URIKJN = CF_Ora_GetDyn(pin_Usr_Ody, "URIKJN", "") '����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MAEUKKB = CF_Ora_GetDyn(pin_Usr_Ody, "MAEUKKB", "") '�O��敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SEIKB = CF_Ora_GetDyn(pin_Usr_Ody, "SEIKB", "") '�����敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.JDNTRKB = CF_Ora_GetDyn(pin_Usr_Ody, "JDNTRKB", "") '�󒍎���敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TUKKB = CF_Ora_GetDyn(pin_Usr_Ody, "TUKKB", "") '�ʉ݋敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FRNKB = CF_Ora_GetDyn(pin_Usr_Ody, "FRNKB", "") '�C�O����敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UDNPRAKB = CF_Ora_GetDyn(pin_Usr_Ody, "UDNPRAKB", "") '�[�i�����s�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UDNPRBKB = CF_Ora_GetDyn(pin_Usr_Ody, "UDNPRBKB", "") '�ʐ������s�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MOTDATNO = CF_Ora_GetDyn(pin_Usr_Ody, "MOTDATNO", "") '���`�[�Ǘ��ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '����o�^հ�ްID
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '����o�^�ײ���ID
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") '��ѽ����(�o�^����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") '��ѽ����(�o�^��)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") '��ѽ����(����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") '��ѽ����(���t)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") '���[�UID(�ޯ�)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") '�ײ���ID(�ޯ�)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") '��ѽ����(����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") '��ѽ����(���t)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") '�v���O����ID
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DLFLG = CF_Ora_GetDyn(pin_Usr_Ody, "DLFLG", "") '�폜�t���O

            .DATNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATNO"), "") '�`�[�Ǘ�NO.
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATKB"), "") '�`�[�폜�敪
            .AKAKROKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("AKAKROKB"), "") '�ԍ��敪
            .DENKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENKB"), "") '�`�[�敪
            .UDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNNO"), "") '����`�[�ԍ�
            .FDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("FDNNO"), "") '�`�[�Ǘ�NO.
            .JDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("JDNNO"), "") '�󒍔ԍ�
            .USDNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("USDNO"), "") '�����`�[NO
            .UDNDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNDT"), "") '����`�[���t
            .DENDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENDT"), "") '�`�[���t
            .REGDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("REGDT"), "") '����`�[���t
            .TOKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCD"), "") '���Ӑ�R�[�h
            .TOKRN = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRN"), "") '���Ӑ旪��
            .NHSCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSCD"), "") '�[����R�[�h
            .NHSRN = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSRN"), "") '�[���旪��
            .NHSNMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSNMA"), "") '�[���於�̂P
            .NHSNMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSNMB"), "") '�[���於�̂Q
            .TANCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANCD"), "") '�S���҃R�[�h
            .TANNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANNM"), "") '�S���Җ�
            .BUMCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("BUMCD"), "") '����R�[�h
            .BUMNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("BUMNM"), "") '���喼
            .TOKSEICD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSEICD"), "") '������R�[�h
            .SOUCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("SOUCD"), "") '�q�ɃR�[�h
            .SOUNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("SOUNM"), "") '�q�ɖ�
            .NXTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NXTKB"), "") '���[�敪
            .NXTNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("NXTNM"), "") '���[����
            .EMGODNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("EMGODNKB"), "") '�ً}�o�׋敪
            .OKRJONO = DB_NullReplace(pin_Usr_Ody.Rows(0)("OKRJONO"), "") '�����
            .INVNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("INVNO"), "") '�C���{�C�X��
            .SMADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SMADT"), "") '�o�������t
            .SSADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSADT"), "") '�����t
            .KESDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("KESDT"), "") '���ϓ��t
            .NYUCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUCD"), "") '�����敪
            .ZKTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKTKB"), "") '����敪
            .ZKTNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKTNM"), "") '����敪��
            .KENNMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("KENNMA"), "") '�����P
            .KENNMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("KENNMB"), "") '�����Q
            .NHSADA = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSADA"), "") '�[����Z���P
            .NHSADB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSADB"), "") '�[����Z���Q
            .NHSADC = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSADC"), "") '�[����Z���R
            .MAEUKNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("MAEUKNM"), "") '�O��敪����
            .KEIBUMCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("KEIBUMCD"), "") '�o������R�[�h
            .UPFKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("UPFKB"), "") '���㓯���o�׋敪
            .SBAURIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAURIKN"), "0") '������z(�{�̍��v)
            .SBAUZEKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAUZEKN"), "0") '������z(����Ŋz)
            .SBAUZKKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAUZKKN"), "0") '������z(�`�[�v)
            .SBAFRUKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAFRUKN"), "0") '�O�ݔ�����z(�`�[�v)
            .SBANYUKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBANYUKN"), "0") '�������z(�`�[�v)
            .SBAFRNKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAFRNKN"), "0") '�O�ݓ����z(�`�[�v)
            .DENCM = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENCM"), "") '���l
            .DENCMIN = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENCMIN"), "") '�Г����l
            .TOKSMEKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEKB"), "") '���敪
            .TOKSMEDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEDD"), "") '���������t(����)
            .TOKSMECC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMECC"), "") '���T�C�N��(����)
            .TOKSDWKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSDWKB"), "") '���ߗj��
            .TOKKESCC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKESCC"), "") '����T�C�N��
            .TOKKESDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKESDD"), "") '������t
            .TOKKDWKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKDWKB"), "") '����j��
            .LSTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("LSTID"), "") '�`�[���
            .TOKJUNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKJUNKB"), "") '���ʕ\�o�͋敪
            .TOKMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKMSTKB"), "") '�}�X�^�敪(���Ӑ�)
            .TKNRPSKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TKNRPSKB"), "") '���z�[����������
            .TKNZRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TKNZRNKB"), "") '���z�[�������敪
            .TOKZEIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZEIKB"), "") '����ŋ敪
            .TOKZCLKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZCLKB"), "") '����ŎZ�o�敪
            .TOKRPSKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRPSKB"), "") '����Œ[����������
            .TOKZRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZRNKB"), "") '����Œ[�������敪
            .TOKNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMMKB"), "") '�����ƭ�ً敪�i���j
            .NHSMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSMSTKB"), "") '�}�X�^�敪(�[����)
            .NHSNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSNMMKB"), "") '�����ƭ�ً敪�i�[�j
            .TANMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANMSTKB"), "") '�}�X�^�敪(�S����)
            .URIKJN = DB_NullReplace(pin_Usr_Ody.Rows(0)("URIKJN"), "") '����
            .MAEUKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MAEUKKB"), "") '�O��敪
            .SEIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("SEIKB"), "") '�����敪
            .JDNTRKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("JDNTRKB"), "") '�󒍎���敪
            .TUKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TUKKB"), "") '�ʉ݋敪
            .FRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("FRNKB"), "") '�C�O����敪
            .UDNPRAKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNPRAKB"), "") '�[�i�����s�敪
            .UDNPRBKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNPRBKB"), "") '�ʐ������s�敪
            .MOTDATNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("MOTDATNO"), "") '���`�[�Ǘ��ԍ�
            .FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FOPEID"), "") '����o�^հ�ްID
            .FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FCLTID"), "") '����o�^�ײ���ID
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTTM"), "") '��ѽ����(�o�^����)
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTDT"), "") '��ѽ����(�o�^��)
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTTM"), "") '��ѽ����(����)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTDT"), "") '��ѽ����(���t)
            .UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UOPEID"), "") '���[�UID(�ޯ�)
            .UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UCLTID"), "") '�ײ���ID(�ޯ�)
            .UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTTM"), "") '��ѽ����(����)
            .UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTDT"), "") '��ѽ����(���t)
            .PGID = DB_NullReplace(pin_Usr_Ody.Rows(0)("PGID"), "") '�v���O����ID
            .DLFLG = DB_NullReplace(pin_Usr_Ody.Rows(0)("DLFLG"), "") '�폜�t���O
            '2019/06/03 CHG END

        End With
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_UDNTHA_Exicz
    '   �T�v�F  ���㌩�o�g�����r������
    '   �����F  pin_strDATNO     �F�`�[�Ǘ�NO.
    '           pin_strFOPEID    �F����o�^հ�ްID
    '           pin_strFCLTID    �F����o�^�ײ���ID
    '           pin_strWRTFSTTM  �F��ѽ����(�o�^����)
    '           pin_strWRTFSTDT  �F��ѽ����(�o�^��)
    '           pin_strOPEID     �F�ŏI��Ǝ҃R�[�h
    '           pin_strCLTID     �F�N���C�A���g�h�c
    '           pin_strWRTTM     �F��ѽ����(����)
    '           pin_strWRTDT     �F��ѽ����(���t)
    '           pin_strUOPEID    �F���[�UID(�ޯ�)
    '           pin_strUCLTID    �F�ײ���ID(�ޯ�)
    '           pin_strUWRTTM    �F��ѽ����(����)
    '           pin_strUWRTDT    �F��ѽ����(���t)
    '   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_UDNTHA_Exicz(ByVal pin_strDATNO As String, ByVal pin_strFOPEID As String, ByVal pin_strFCLTID As String, ByVal pin_strWRTFSTTM As String, ByVal pin_strWRTFSTDT As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strWRTTM As String, ByVal pin_strWRTDT As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strUWRTTM As String, ByVal pin_strUWRTDT As String) As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
        Dim strSQL As String
        '2019/06/03 ADD START
        Dim dt As DataTable
        '2019/06/03 ADD END

        On Error GoTo F_UDNTHA_Exicz_err
		
		F_UDNTHA_Exicz = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " SELECT FOPEID " '����o�^հ�ްID
		strSQL = strSQL & "      , FCLTID " '����o�^�ײ���ID
		strSQL = strSQL & "      , WRTFSTTM " '��ѽ����(�o�^����)
		strSQL = strSQL & "      , WRTFSTDT " '��ѽ����(�o�^��)
		strSQL = strSQL & "      , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID " '�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "      , UOPEID " '���[�UID(�ޯ�)
		strSQL = strSQL & "      , UCLTID " '�ײ���ID(�ޯ�)
		strSQL = strSQL & "      , UWRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , UWRTDT " '��ѽ����(���t)
		strSQL = strSQL & " FROM UDNTHA "
		strSQL = strSQL & " WHERE DATNO = '" & CF_Ora_String(pin_strDATNO, 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "   AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '�`�[�폜�敪
		strSQL = strSQL & " FOR UPDATE "

        ' DB�A�N�Z�X
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        If DBSTAT <> 0 Then
			' �f�[�^�Ȃ��̏ꍇ
			F_UDNTHA_Exicz = 1
			GoTo F_UDNTHA_Exicz_end
			
		Else
            ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTFSTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTFSTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, FCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, FOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190826 kuwa
            'If pin_strFOPEID <> CF_Ora_GetDyn(Usr_Ody, "FOPEID", "") Or pin_strFCLTID <> CF_Ora_GetDyn(Usr_Ody, "FCLTID", "") Or pin_strWRTFSTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") Or pin_strWRTFSTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") Or pin_strOPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or pin_strCLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or pin_strWRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or pin_strWRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or pin_strUOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or pin_strUCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or pin_strUWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or pin_strUWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
            If pin_strFOPEID <> DB_NullReplace(dt.Rows(0)("FOPEID"), "") Or pin_strFCLTID <> DB_NullReplace(dt.Rows(0)("FCLTID"), "") Or pin_strWRTFSTTM <> DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") Or pin_strWRTFSTDT <> DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") Or pin_strOPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or pin_strCLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or pin_strWRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or pin_strWRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or pin_strUOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or pin_strUCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or pin_strUWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or pin_strUWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                'change end 20190826 kuwa
                GoTo F_UDNTHA_Exicz_end
            End If
        End If
		
		F_UDNTHA_Exicz = 0
		
F_UDNTHA_Exicz_end:

        '�N���[�Y
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/06/03 DLT END

        Exit Function
		
F_UDNTHA_Exicz_err: 
		GoTo F_UDNTHA_Exicz_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPUDNTRA_SEARCH
	'   �T�v�F  ����g���� �f�[�^����
	'   �����F  pin_strDATNO     : ����`�[�Ǘ��ԍ�
	'           pot_DB_UDNTHA    : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPUDNTRA_SEARCH(ByVal pin_strDATNO As String, ByRef pot_DB_UDNTRA() As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim strCountSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
        '2019/06/03 ADD START
        Dim dt As DataTable
        '2019/06/03 ADD END

        On Error GoTo ERR_DSPUDNTRA_SEARCH
		
		DSPUDNTRA_SEARCH = 9
		
		'�߂�l�̃N���A
		Erase pot_DB_UDNTRA
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM UDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & CF_Ora_Sgl(pin_strDATNO) & "'"
		strSQL = strSQL & " ORDER BY LINNO "
		
		'�����J�E���gSQL
		strCountSQL = ""
		strCountSQL = strCountSQL & " SELECT COUNT(*) AS CNTDATA "
		strCountSQL = strCountSQL & " FROM ( " & strSQL & " ) "

        'DB�A�N�Z�X
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strCountSQL)
        dt = DB_GetTable(strCountSQL)
        '2019/06/03 CHG END

        '�����擾
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/06/03 CHG START
        'intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))
        intData = CF_Get_CCurString(DB_NullReplace(dt.Rows(0)("CNTDATA"), 0))
        '2019/06/03 CHG END

        '�N���[�Y
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/03 CHG END

        ReDim pot_DB_UDNTRA(intData)

        'DB�A�N�Z�X
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        '�擾�f�[�^�ޔ�
        intData = 1
        '2019/06/03 CHG START
        '      Do Until CF_Ora_EOF(Usr_Ody_LC) = True

        '	Call DB_UDNTRA_SetData(Usr_Ody_LC, pot_DB_UDNTRA(intData))

        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        '	intData = intData + 1
        'Loop 
        For i As Integer = 0 To dt.Rows.Count - 1
            'change start 20190827 kuwa
            'Call DB_UDNTRA_SetData(dt, pot_DB_UDNTRA(intData))
            Call DB_UDNTRA_SetData(dt, pot_DB_UDNTRA(intData), i)
            'change end 20190827 kuwa
            intData = intData + 1
        Next
        '2019/06/03 CHG END

        DSPUDNTRA_SEARCH = 0
		
END_DSPUDNTRA_SEARCH:
        '�N���[�Y
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/03 DLT END
        Exit Function
		
ERR_DSPUDNTRA_SEARCH: 
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_UDNTRA_SetData
    '   �T�v�F  ����g���� �f�[�^�\���̃f�[�^�ޔ�
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_UDNTRA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_UDNTRA As TYPE_DB_UDNTRA)
        '�f�[�^�ޔ�
        With pot_DB_UDNTRA
            '2019/06/03 CHF START
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DATNO = CF_Ora_GetDyn(pin_Usr_Ody, "DATNO", "") '�`�[�Ǘ�NO.
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '�`�[�폜�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.AKAKROKB = CF_Ora_GetDyn(pin_Usr_Ody, "AKAKROKB", "") '�ԍ��敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DENKB = CF_Ora_GetDyn(pin_Usr_Ody, "DENKB", "") '�`�[�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "UDNNO", "") '����`�[�ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.LINNO = CF_Ora_GetDyn(pin_Usr_Ody, "LINNO", "") '�s�ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ZKTKB = CF_Ora_GetDyn(pin_Usr_Ody, "ZKTKB", "") '����敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ODNNO = CF_Ora_GetDyn(pin_Usr_Ody, "ODNNO", "") '�o�ד`�[�ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ODNLINNO = CF_Ora_GetDyn(pin_Usr_Ody, "ODNLINNO", "") '�s�ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.JDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "JDNNO", "") '�󒍔ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.JDNLINNO = CF_Ora_GetDyn(pin_Usr_Ody, "JDNLINNO", "") '�󒍍s�ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.RECNO = CF_Ora_GetDyn(pin_Usr_Ody, "RECNO", "") '���R�[�h�Ǘ�NO.
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.USDNO = CF_Ora_GetDyn(pin_Usr_Ody, "USDNO", "") '�����`�[NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UDNDT = CF_Ora_GetDyn(pin_Usr_Ody, "UDNDT", "") '����`�[���t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBSB = CF_Ora_GetDyn(pin_Usr_Ody, "DKBSB", "") '�`�[����敪���
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBID = CF_Ora_GetDyn(pin_Usr_Ody, "DKBID", "") '����敪�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DKBNM = CF_Ora_GetDyn(pin_Usr_Ody, "DKBNM", "") '����敪����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HENRSNCD = CF_Ora_GetDyn(pin_Usr_Ody, "HENRSNCD", "") '�ԕi���R
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HENSTTCD = CF_Ora_GetDyn(pin_Usr_Ody, "HENSTTCD", "") '�ԕi���
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SMADT = CF_Ora_GetDyn(pin_Usr_Ody, "SMADT", "") '�o�������t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SSADT = CF_Ora_GetDyn(pin_Usr_Ody, "SSADT", "") '�����t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KESDT = CF_Ora_GetDyn(pin_Usr_Ody, "KESDT", "") '���ϓ��t
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TANCD = CF_Ora_GetDyn(pin_Usr_Ody, "TANCD", "") '�S���҃R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSCD = CF_Ora_GetDyn(pin_Usr_Ody, "NHSCD", "") '�[����R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKSEICD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSEICD", "") '������R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SOUCD = CF_Ora_GetDyn(pin_Usr_Ody, "SOUCD", "") '�q�ɃR�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SBNNO = CF_Ora_GetDyn(pin_Usr_Ody, "SBNNO", "") '����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HINCD = CF_Ora_GetDyn(pin_Usr_Ody, "HINCD", "") '���i�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKJDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "TOKJDNNO", "") '�q�撍���ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HINNMA = CF_Ora_GetDyn(pin_Usr_Ody, "HINNMA", "") '�^��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HINNMB = CF_Ora_GetDyn(pin_Usr_Ody, "HINNMB", "") '���i���P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UNTCD = CF_Ora_GetDyn(pin_Usr_Ody, "UNTCD", "") '�P�ʃR�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UNTNM = CF_Ora_GetDyn(pin_Usr_Ody, "UNTNM", "") '�P�ʖ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.IRISU = CF_Ora_GetDyn(pin_Usr_Ody, "IRISU", 0) '����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CASSU = CF_Ora_GetDyn(pin_Usr_Ody, "CASSU", 0) '�P�[�X��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.URISU = CF_Ora_GetDyn(pin_Usr_Ody, "URISU", 0) '���㐔��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.URITK = CF_Ora_GetDyn(pin_Usr_Ody, "URITK", 0) '�P��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.GNKTK = CF_Ora_GetDyn(pin_Usr_Ody, "GNKTK", 0) '�����P��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SIKTK = CF_Ora_GetDyn(pin_Usr_Ody, "SIKTK", 0) '�c�Ǝd�ؒP��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FURITK = CF_Ora_GetDyn(pin_Usr_Ody, "FURITK", 0) '�O�ݒP��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.URIKN = CF_Ora_GetDyn(pin_Usr_Ody, "URIKN", 0) '������z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FURIKN = CF_Ora_GetDyn(pin_Usr_Ody, "FURIKN", 0) '�O�ݔ�����z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.SIKKN = CF_Ora_GetDyn(pin_Usr_Ody, "SIKKN", 0) '�c�Ǝd�؋��z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UZEKN = CF_Ora_GetDyn(pin_Usr_Ody, "UZEKN", 0) '����ŋ��z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NYUDT = CF_Ora_GetDyn(pin_Usr_Ody, "NYUDT", "") '������
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NYUKN = CF_Ora_GetDyn(pin_Usr_Ody, "NYUKN", 0) '�����z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FNYUKN = CF_Ora_GetDyn(pin_Usr_Ody, "FNYUKN", 0) '�O�ݓ����z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.GNKKN = CF_Ora_GetDyn(pin_Usr_Ody, "GNKKN", 0) '�������z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.JKESIKN = CF_Ora_GetDyn(pin_Usr_Ody, "JKESIKN", 0) '�������z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FKESIKN = CF_Ora_GetDyn(pin_Usr_Ody, "FKESIKN", 0) '�O�ݏ������z
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.KESIKB = CF_Ora_GetDyn(pin_Usr_Ody, "KESIKB", "") '�����敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NYUKB = CF_Ora_GetDyn(pin_Usr_Ody, "NYUKB", "") '�������
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TNKID = CF_Ora_GetDyn(pin_Usr_Ody, "TNKID", "") '���
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TUKKB = CF_Ora_GetDyn(pin_Usr_Ody, "TUKKB", "") '�ʉ݋敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.RATERT = CF_Ora_GetDyn(pin_Usr_Ody, "RATERT", 0) '�בփ��[�g
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.EMGODNKB = CF_Ora_GetDyn(pin_Usr_Ody, "EMGODNKB", "") '�ً}�o�׋敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.OKRJONO = CF_Ora_GetDyn(pin_Usr_Ody, "OKRJONO", "") '�����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.INVNO = CF_Ora_GetDyn(pin_Usr_Ody, "INVNO", "") '�C���{�C�X��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.LINCMA = CF_Ora_GetDyn(pin_Usr_Ody, "LINCMA", "") '���ה��l�P
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.LINCMB = CF_Ora_GetDyn(pin_Usr_Ody, "LINCMB", "") '���ה��l�Q
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BNKCD = CF_Ora_GetDyn(pin_Usr_Ody, "BNKCD", "") '��s�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BNKNM = CF_Ora_GetDyn(pin_Usr_Ody, "BNKNM", "") '��s����
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TEGNO = CF_Ora_GetDyn(pin_Usr_Ody, "TEGNO", "") '��`�ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TEGDT = CF_Ora_GetDyn(pin_Usr_Ody, "TEGDT", "") '��`����
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
            '.LSTID = CF_Ora_GetDyn(pin_Usr_Ody, "LSTID", "") '�`�[���
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HINZEIKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINZEIKB", "") '���i����ŋ敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HINMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINMSTKB", "") '�}�X�^�敪(���i)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TOKMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKMSTKB", "") '�}�X�^�敪(���Ӑ�)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.NHSMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSMSTKB", "") '�}�X�^�敪(�[����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TANMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TANMSTKB", "") '�}�X�^�敪(�S����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ZEIRNKKB = CF_Ora_GetDyn(pin_Usr_Ody, "ZEIRNKKB", "") '����Ń����N
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HINKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINKB", "") '���i�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ZEIRT = CF_Ora_GetDyn(pin_Usr_Ody, "ZEIRT", 0) '����ŗ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ZAIKB = CF_Ora_GetDyn(pin_Usr_Ody, "ZAIKB", "") '�݌ɊǗ��敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MRPKB = CF_Ora_GetDyn(pin_Usr_Ody, "MRPKB", "") '�W�J�敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HINJUNKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINJUNKB", "") '���ʕ\�o�͋敪
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MAKCD = CF_Ora_GetDyn(pin_Usr_Ody, "MAKCD", "") '���[�J�[�R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HINSIRCD = CF_Ora_GetDyn(pin_Usr_Ody, "HINSIRCD", "") '���i�d����R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HINNMMKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINNMMKB", "") '�����ƭ�ً敪�i���j
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.HRTDD = CF_Ora_GetDyn(pin_Usr_Ody, "HRTDD", "") '�������[�h�^�C��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ORTDD = CF_Ora_GetDyn(pin_Usr_Ody, "ORTDD", "") '�o�׃��[�h�^�C��
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ZNKURIKN = CF_Ora_GetDyn(pin_Usr_Ody, "ZNKURIKN", 0) '�Ŕ��ېőΏۊz
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ZKMURIKN = CF_Ora_GetDyn(pin_Usr_Ody, "ZKMURIKN", 0) '�ō��ېőΏۊz
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ZKMUZEKN = CF_Ora_GetDyn(pin_Usr_Ody, "ZKMUZEKN", 0) '�ō������
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MOTDATNO = CF_Ora_GetDyn(pin_Usr_Ody, "MOTDATNO", "") '���`�[�Ǘ��ԍ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '����o�^հ�ްID
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '����o�^�ײ���ID
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") '��ѽ����(�o�^����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") '��ѽ����(�o�^��)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") '��ѽ����(����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") '��ѽ����(���t)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") '���[�UID(�ޯ�)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") '�ײ���ID(�ޯ�)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") '��ѽ����(����)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") '��ѽ����(���t)
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") '�v���O����ID
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.DLFLG = CF_Ora_GetDyn(pin_Usr_Ody, "DLFLG", "") '�폜�t���O

            .DATNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATNO"), "") '�`�[�Ǘ�NO.
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATKB"), "") '�`�[�폜�敪
            .AKAKROKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("AKAKROKB"), "") '�ԍ��敪
            .DENKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENKB"), "") '�`�[�敪
            .UDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNNO"), "") '����`�[�ԍ�
            .LINNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("LINNO"), "") '�s�ԍ�	
            .ZKTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKTKB"), "") '����敪
            .ODNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("ODNNO"), "") '�o�ד`�[�ԍ�
            .ODNLINNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("ODNLINNO"), "") '�s�ԍ�
            .JDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("JDNNO"), "") '�󒍔ԍ�
            .JDNLINNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("JDNLINNO"), "") '�󒍍s�ԍ�
            .RECNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("RECNO"), "") '���R�[�h�Ǘ�NO.
            .USDNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("USDNO"), "") '�����`�[NO
            .UDNDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNDT"), "") '����`�[���t
            .DKBSB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBSB"), "") '�`�[����敪���
            .DKBID = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBID"), "") '����敪�R�[�h
            .DKBNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBNM"), "") '����敪����
            .HENRSNCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HENRSNCD"), "") '�ԕi���R
            .HENSTTCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HENSTTCD"), "") '�ԕi���
            .SMADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SMADT"), "") '�o�������t
            .SSADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSADT"), "") '�����t
            .KESDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("KESDT"), "") '���ϓ��t
            .TOKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCD"), "") '���Ӑ�R�[�h
            .TANCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANCD"), "") '�S���҃R�[�h
            .NHSCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSCD"), "") '�[����R�[�h
            .TOKSEICD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSEICD"), "") '������R�[�h
            .SOUCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("SOUCD"), "") '�q�ɃR�[�h
            .SBNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBNNO"), "") '����
            .HINCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINCD"), "") '���i�R�[�h
            .TOKJDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKJDNNO"), "") '�q�撍���ԍ�
            .HINNMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINNMA"), "") '�^��
            .HINNMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINNMB"), "") '���i���P
            .UNTCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("UNTCD"), "") '�P�ʃR�[�h
            .UNTNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("UNTNM"), "") '�P�ʖ�
            .IRISU = DB_NullReplace(pin_Usr_Ody.Rows(0)("IRISU"), "0") '����
            .CASSU = DB_NullReplace(pin_Usr_Ody.Rows(0)("CASSU"), "0") '�P�[�X��
            .URISU = DB_NullReplace(pin_Usr_Ody.Rows(0)("URISU"), "0") '���㐔��
            .URITK = DB_NullReplace(pin_Usr_Ody.Rows(0)("URITK"), "0") '�P��
            .GNKTK = DB_NullReplace(pin_Usr_Ody.Rows(0)("GNKTK"), "0") '�����P��
            .SIKTK = DB_NullReplace(pin_Usr_Ody.Rows(0)("SIKTK"), "0") '�c�Ǝd�ؒP��
            .FURITK = DB_NullReplace(pin_Usr_Ody.Rows(0)("FURITK"), "0") '�O�ݒP��
            .URIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("URIKN"), "0") '������z
            .FURIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("FURIKN"), "0") '�O�ݔ�����z
            .SIKKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SIKKN"), "0") '�c�Ǝd�؋��z
            .UZEKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("UZEKN"), "0") '����ŋ��z
            .NYUDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUDT"), "") '������
            .NYUKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUKN"), "0") '�����z
            .FNYUKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("FNYUKN"), "0") '�O�ݓ����z
            .GNKKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("GNKKN"), "0") '�������z
            .JKESIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("JKESIKN"), "0") '�������z
            .FKESIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("FKESIKN"), "0") '�O�ݏ������z
            .KESIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("KESIKB"), "") '�����敪
            .NYUKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUKB"), "") '�������
            .TNKID = DB_NullReplace(pin_Usr_Ody.Rows(0)("TNKID"), "") '���
            .TUKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TUKKB"), "") '�ʉ݋敪
            .RATERT = DB_NullReplace(pin_Usr_Ody.Rows(0)("RATERT"), "0") '�בփ��[�g
            .EMGODNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("EMGODNKB"), "") '�ً}�o�׋敪
            .OKRJONO = DB_NullReplace(pin_Usr_Ody.Rows(0)("OKRJONO"), "") '�����
            .INVNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("INVNO"), "") '�C���{�C�X��
            .LINCMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("LINCMA"), "") '���ה��l�P
            .LINCMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("LINCMB"), "") '���ה��l�Q
            .BNKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("BNKCD"), "") '��s�R�[�h
            .BNKNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("BNKNM"), "") '��s����
            .TEGNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGNO"), "") '��`�ԍ�
            .TEGDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGDT"), "") '��`����
            .UPDID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UPDID"), "") '�X�V�p���ޯ��(ACNT)
            .DFLDKBCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("DFLDKBCD"), "") '�f�t�H���g�R�[�h
            .DKBZAIFL = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBZAIFL"), "") '�݌Ɋ֘A�t���O
            .DKBTEGFL = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBTEGFL"), "") '��`�����t���O
            .DKBFLA = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBFLA"), "") '�_�~�[�t���O�P
            .DKBFLB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBFLB"), "") '�_�~�[�t���O�Q
            .DKBFLC = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBFLC"), "") '�_�~�[�t���O�R
            .LSTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("LSTID"), "") '�`�[���
            .HINZEIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINZEIKB"), "") '���i����ŋ敪
            .HINMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINMSTKB"), "") '�}�X�^�敪(���i)
            .TOKMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKMSTKB"), "") '�}�X�^�敪(���Ӑ�)
            .NHSMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSMSTKB"), "") '�}�X�^�敪(�[����)
            .TANMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANMSTKB"), "") '�}�X�^�敪(�S����)
            .ZEIRNKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZEIRNKKB"), "") '����Ń����N
            .HINKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINKB"), "") '���i�敪
            .ZEIRT = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZEIRT"), "0") '����ŗ�
            .ZAIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZAIKB"), "") '�݌ɊǗ��敪
            .MRPKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MRPKB"), "") '�W�J�敪
            .HINJUNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINJUNKB"), "") '���ʕ\�o�͋敪
            .MAKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("MAKCD"), "") '���[�J�[�R�[�h
            .HINSIRCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINSIRCD"), "") '���i�d����R�[�h
            .HINNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINNMMKB"), "") '�����ƭ�ً敪�i���j
            .HRTDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HRTDD"), "") '�������[�h�^�C��
            .ORTDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("ORTDD"), "") '�o�׃��[�h�^�C��
            .ZNKURIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZNKURIKN"), "0") '�Ŕ��ېőΏۊz
            .ZKMURIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKMURIKN"), "0") '�ō��ېőΏۊz
            .ZKMUZEKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKMUZEKN"), "0") '�ō������
            .MOTDATNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("MOTDATNO"), "") '���`�[�Ǘ��ԍ�
            .FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FOPEID"), "") '����o�^հ�ްID
            .FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FCLTID"), "") '����o�^�ײ���ID
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTTM"), "") '��ѽ����(�o�^����)
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTDT"), "") '��ѽ����(�o�^��)
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTTM"), "") '��ѽ����(����)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTDT"), "") '��ѽ����(���t)
            .UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UOPEID"), "") '���[�UID(�ޯ�)
            .UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UCLTID"), "") '�ײ���ID(�ޯ�)
            .UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTTM"), "") '��ѽ����(����)
            .UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTDT"), "") '��ѽ����(���t)
            .PGID = DB_NullReplace(pin_Usr_Ody.Rows(0)("PGID"), "") '�v���O����ID
            .DLFLG = DB_NullReplace(pin_Usr_Ody.Rows(0)("DLFLG"), "") '�폜�t���O
            '2019/06/03 CHG END

        End With
    End Sub

    'add start 20190827 kuwa
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_UDNTRA_SetData
    '   �T�v�F  ����g���� �f�[�^�\���̃f�[�^�ޔ�
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_UDNTRA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_UDNTRA As TYPE_DB_UDNTRA, Optional ByRef i As Integer = 0)
        '�f�[�^�ޔ�
        With pot_DB_UDNTRA
            .DATNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("DATNO"), "") '�`�[�Ǘ�NO.
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("DATKB"), "") '�`�[�폜�敪
            .AKAKROKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("AKAKROKB"), "") '�ԍ��敪
            .DENKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("DENKB"), "") '�`�[�敪
            .UDNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("UDNNO"), "") '����`�[�ԍ�
            .LINNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("LINNO"), "") '�s�ԍ�	
            .ZKTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZKTKB"), "") '����敪
            .ODNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("ODNNO"), "") '�o�ד`�[�ԍ�
            .ODNLINNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("ODNLINNO"), "") '�s�ԍ�
            .JDNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("JDNNO"), "") '�󒍔ԍ�
            .JDNLINNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("JDNLINNO"), "") '�󒍍s�ԍ�
            .RECNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("RECNO"), "") '���R�[�h�Ǘ�NO.
            .USDNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("USDNO"), "") '�����`�[NO
            .UDNDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("UDNDT"), "") '����`�[���t
            .DKBSB = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBSB"), "") '�`�[����敪���
            .DKBID = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBID"), "") '����敪�R�[�h
            .DKBNM = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBNM"), "") '����敪����
            .HENRSNCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HENRSNCD"), "") '�ԕi���R
            .HENSTTCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HENSTTCD"), "") '�ԕi���
            .SMADT = DB_NullReplace(pin_Usr_Ody.Rows(i)("SMADT"), "") '�o�������t
            .SSADT = DB_NullReplace(pin_Usr_Ody.Rows(i)("SSADT"), "") '�����t
            .KESDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("KESDT"), "") '���ϓ��t
            .TOKCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("TOKCD"), "") '���Ӑ�R�[�h
            .TANCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("TANCD"), "") '�S���҃R�[�h
            .NHSCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("NHSCD"), "") '�[����R�[�h
            .TOKSEICD = DB_NullReplace(pin_Usr_Ody.Rows(i)("TOKSEICD"), "") '������R�[�h
            .SOUCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("SOUCD"), "") '�q�ɃR�[�h
            .SBNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("SBNNO"), "") '����
            .HINCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINCD"), "") '���i�R�[�h
            .TOKJDNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("TOKJDNNO"), "") '�q�撍���ԍ�
            .HINNMA = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINNMA"), "") '�^��
            .HINNMB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINNMB"), "") '���i���P
            .UNTCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("UNTCD"), "") '�P�ʃR�[�h
            .UNTNM = DB_NullReplace(pin_Usr_Ody.Rows(i)("UNTNM"), "") '�P�ʖ�
            .IRISU = DB_NullReplace(pin_Usr_Ody.Rows(i)("IRISU"), "0") '����
            .CASSU = DB_NullReplace(pin_Usr_Ody.Rows(i)("CASSU"), "0") '�P�[�X��
            .URISU = DB_NullReplace(pin_Usr_Ody.Rows(i)("URISU"), "0") '���㐔��
            .URITK = DB_NullReplace(pin_Usr_Ody.Rows(i)("URITK"), "0") '�P��
            .GNKTK = DB_NullReplace(pin_Usr_Ody.Rows(i)("GNKTK"), "0") '�����P��
            .SIKTK = DB_NullReplace(pin_Usr_Ody.Rows(i)("SIKTK"), "0") '�c�Ǝd�ؒP��
            .FURITK = DB_NullReplace(pin_Usr_Ody.Rows(i)("FURITK"), "0") '�O�ݒP��
            .URIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("URIKN"), "0") '������z
            .FURIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("FURIKN"), "0") '�O�ݔ�����z
            .SIKKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("SIKKN"), "0") '�c�Ǝd�؋��z
            .UZEKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("UZEKN"), "0") '����ŋ��z
            .NYUDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("NYUDT"), "") '������
            .NYUKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("NYUKN"), "0") '�����z
            .FNYUKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("FNYUKN"), "0") '�O�ݓ����z
            .GNKKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("GNKKN"), "0") '�������z
            .JKESIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("JKESIKN"), "0") '�������z
            .FKESIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("FKESIKN"), "0") '�O�ݏ������z
            .KESIKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("KESIKB"), "") '�����敪
            .NYUKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("NYUKB"), "") '�������
            .TNKID = DB_NullReplace(pin_Usr_Ody.Rows(i)("TNKID"), "") '���
            .TUKKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("TUKKB"), "") '�ʉ݋敪
            .RATERT = DB_NullReplace(pin_Usr_Ody.Rows(i)("RATERT"), "0") '�בփ��[�g
            .EMGODNKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("EMGODNKB"), "") '�ً}�o�׋敪
            .OKRJONO = DB_NullReplace(pin_Usr_Ody.Rows(i)("OKRJONO"), "") '�����
            .INVNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("INVNO"), "") '�C���{�C�X��
            .LINCMA = DB_NullReplace(pin_Usr_Ody.Rows(i)("LINCMA"), "") '���ה��l�P
            .LINCMB = DB_NullReplace(pin_Usr_Ody.Rows(i)("LINCMB"), "") '���ה��l�Q
            .BNKCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("BNKCD"), "") '��s�R�[�h
            .BNKNM = DB_NullReplace(pin_Usr_Ody.Rows(i)("BNKNM"), "") '��s����
            .TEGNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("TEGNO"), "") '��`�ԍ�
            .TEGDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("TEGDT"), "") '��`����
            .UPDID = DB_NullReplace(pin_Usr_Ody.Rows(i)("UPDID"), "") '�X�V�p���ޯ��(ACNT)
            .DFLDKBCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("DFLDKBCD"), "") '�f�t�H���g�R�[�h
            .DKBZAIFL = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBZAIFL"), "") '�݌Ɋ֘A�t���O
            .DKBTEGFL = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBTEGFL"), "") '��`�����t���O
            .DKBFLA = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBFLA"), "") '�_�~�[�t���O�P
            .DKBFLB = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBFLB"), "") '�_�~�[�t���O�Q
            .DKBFLC = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBFLC"), "") '�_�~�[�t���O�R
            .LSTID = DB_NullReplace(pin_Usr_Ody.Rows(i)("LSTID"), "") '�`�[���
            .HINZEIKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINZEIKB"), "") '���i����ŋ敪
            .HINMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINMSTKB"), "") '�}�X�^�敪(���i)
            .TOKMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("TOKMSTKB"), "") '�}�X�^�敪(���Ӑ�)
            .NHSMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("NHSMSTKB"), "") '�}�X�^�敪(�[����)
            .TANMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("TANMSTKB"), "") '�}�X�^�敪(�S����)
            .ZEIRNKKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZEIRNKKB"), "") '����Ń����N
            .HINKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINKB"), "") '���i�敪
            .ZEIRT = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZEIRT"), "0") '����ŗ�
            .ZAIKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZAIKB"), "") '�݌ɊǗ��敪
            .MRPKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("MRPKB"), "") '�W�J�敪
            .HINJUNKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINJUNKB"), "") '���ʕ\�o�͋敪
            .MAKCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("MAKCD"), "") '���[�J�[�R�[�h
            .HINSIRCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINSIRCD"), "") '���i�d����R�[�h
            .HINNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINNMMKB"), "") '�����ƭ�ً敪�i���j
            .HRTDD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HRTDD"), "") '�������[�h�^�C��
            .ORTDD = DB_NullReplace(pin_Usr_Ody.Rows(i)("ORTDD"), "") '�o�׃��[�h�^�C��
            .ZNKURIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZNKURIKN"), "0") '�Ŕ��ېőΏۊz
            .ZKMURIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZKMURIKN"), "0") '�ō��ېőΏۊz
            .ZKMUZEKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZKMUZEKN"), "0") '�ō������
            .MOTDATNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("MOTDATNO"), "") '���`�[�Ǘ��ԍ�
            .FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(i)("FOPEID"), "") '����o�^հ�ްID
            .FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(i)("FCLTID"), "") '����o�^�ײ���ID
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(i)("WRTFSTTM"), "") '��ѽ����(�o�^����)
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("WRTFSTDT"), "") '��ѽ����(�o�^��)
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(i)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(i)("CLTID"), "") '�N���C�A���g�h�c
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(i)("WRTTM"), "") '��ѽ����(����)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("WRTDT"), "") '��ѽ����(���t)
            .UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(i)("UOPEID"), "") '���[�UID(�ޯ�)
            .UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(i)("UCLTID"), "") '�ײ���ID(�ޯ�)
            .UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(i)("UWRTTM"), "") '��ѽ����(����)
            .UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("UWRTDT"), "") '��ѽ����(���t)
            .PGID = DB_NullReplace(pin_Usr_Ody.Rows(i)("PGID"), "") '�v���O����ID
            .DLFLG = DB_NullReplace(pin_Usr_Ody.Rows(i)("DLFLG"), "") '�폜�t���O
            '2019/06/03 CHG END

        End With
    End Sub
    'add end 20190827 kuwa



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_UDNTRA_Exicz
    '   �T�v�F  ����g�����r������
    '   �����F  pin_strDATNO     �F�`�[�Ǘ�NO.
    '           pin_intLINNO     �F�s�ԍ�
    '           pin_strFOPEID    �F����o�^հ�ްID
    '           pin_strFCLTID    �F����o�^�ײ���ID
    '           pin_strWRTFSTTM  �F��ѽ����(�o�^����)
    '           pin_strWRTFSTDT  �F��ѽ����(�o�^��)
    '           pin_strOPEID     �F�ŏI��Ǝ҃R�[�h
    '           pin_strCLTID     �F�N���C�A���g�h�c
    '           pin_strWRTTM     �F��ѽ����(����)
    '           pin_strWRTDT     �F��ѽ����(���t)
    '           pin_strUOPEID    �F���[�UID(�ޯ�)
    '           pin_strUCLTID    �F�ײ���ID(�ޯ�)
    '           pin_strUWRTTM    �F��ѽ����(����)
    '           pin_strUWRTDT    �F��ѽ����(���t)
    '   �ߒl�F  0:����   1:�f�[�^����  9:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_UDNTRA_Exicz(ByVal pin_strDATNO As String, ByVal pin_intLINNO As Short, ByVal pin_strFOPEID As String, ByVal pin_strFCLTID As String, ByVal pin_strWRTFSTTM As String, ByVal pin_strWRTFSTDT As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strWRTTM As String, ByVal pin_strWRTDT As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strUWRTTM As String, ByVal pin_strUWRTDT As String) As Short
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		On Error GoTo F_UDNTRA_Exicz_err
		
		F_UDNTRA_Exicz = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " SELECT FOPEID " '����o�^հ�ްID
		strSQL = strSQL & "      , FCLTID " '����o�^�ײ���ID
		strSQL = strSQL & "      , WRTFSTTM " '��ѽ����(�o�^����)
		strSQL = strSQL & "      , WRTFSTDT " '��ѽ����(�o�^��)
		strSQL = strSQL & "      , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID " '�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "      , UOPEID " '���[�UID(�ޯ�)
		strSQL = strSQL & "      , UCLTID " '�ײ���ID(�ޯ�)
		strSQL = strSQL & "      , UWRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , UWRTDT " '��ѽ����(���t)
		strSQL = strSQL & " FROM UDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & CF_Ora_String(pin_strDATNO, 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "   AND LINNO = '" & VB6.Format(pin_intLINNO, "000") & "' " '�s�ԍ�
		strSQL = strSQL & "   AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '�`�[�폜�敪
		strSQL = strSQL & " FOR UPDATE "

        ' DB�A�N�Z�X
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        If DBSTAT <> 0 Then
			' �f�[�^�Ȃ��̏ꍇ
			F_UDNTRA_Exicz = 1
			GoTo F_UDNTRA_Exicz_end
			
		Else
            ' �X�V�O�f�[�^�ƈقȂ�f�[�^�����݂����ꍇ�̓G���[�Ƃ���B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, UOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, CLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, OPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTFSTDT, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, WRTFSTTM, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, FCLTID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, FOPEID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190826 kuwa
            'If pin_strFOPEID <> CF_Ora_GetDyn(Usr_Ody, "FOPEID", "") Or pin_strFCLTID <> CF_Ora_GetDyn(Usr_Ody, "FCLTID", "") Or pin_strWRTFSTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") Or pin_strWRTFSTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") Or pin_strOPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or pin_strCLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or pin_strWRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or pin_strWRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or pin_strUOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or pin_strUCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or pin_strUWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or pin_strUWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
            If pin_strFOPEID <> DB_NullReplace(dt.Rows(0)("FOPEID"), "") Or pin_strFCLTID <> DB_NullReplace(dt.Rows(0)("FCLTID"), "") Or pin_strWRTFSTTM <> DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") Or pin_strWRTFSTDT <> DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") Or pin_strOPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or pin_strCLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or pin_strWRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or pin_strWRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or pin_strUOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or pin_strUCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or pin_strUWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or pin_strUWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                'change end 20190826 kuwa
                GoTo F_UDNTRA_Exicz_end
            End If
        End If
		
		F_UDNTRA_Exicz = 0
		
F_UDNTRA_Exicz_end:

        '�N���[�Y
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/06/03 DLT END

        Exit Function
		
F_UDNTRA_Exicz_err: 
		GoTo F_UDNTRA_Exicz_end
		
	End Function
	
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
        '2019/06/03 ADD START
        Dim dt As DataTable
        '2019/06/03 ADD END

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
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        '�����擾
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/06/04 CHG START
        'intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))
        intData = CF_Get_CCurString(DB_NullReplace(dt.Rows(0)("CNTDATA"), 0))
        '2019/06/04 CHG END

        '�N���[�Y
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/03 DLT END

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
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        '�擾�f�[�^�ޔ�
        '2019/06/03 CHG START
        intData = 1
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True

        '	Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intData))

        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        '	intData = intData + 1
        'Loop 

        For i As Integer = 0 To dt.Rows.Count - 1
            'change 20190729 START hou
            'Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData))
            Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData), intData)
            'change 20190729 END hou
            intData = intData + 1
        Next
        '2019/06/03 CHG END

        DSPMEIMTA_SEARCH_SORTUSE = 0
		
END_DSPMEIMTA_SEARCH_SORTUSE:
        '�N���[�Y
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/03 DLT END

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
    Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, ByRef intData As Integer)
        '�f�[�^�ޔ�
        With pot_DB_MEIMTA
            '2019/06/04 CHG START
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

            'change 20190729 START hou
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
            '2019/06/04 CHG END
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
            'change 20190729 END hou
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
	Public Function SYSTBD_SEARCH(ByVal Pin_strDKBSB As String, ByVal pin_strDKBID As String, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_SYSTBD_SEARCH
		
		SYSTBD_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from SYSTBD "
		strSQL = strSQL & "  Where DKBSB = '" & CF_Ora_Sgl(Pin_strDKBSB) & "' "
		strSQL = strSQL & "    And DKBID = '" & CF_Ora_Sgl(pin_strDKBID) & "' "

        'DB�A�N�Z�X
        '2019/06/04 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/06/04 CHG END
            '�擾�f�[�^�Ȃ�
            SYSTBD_SEARCH = 1
            GoTo END_SYSTBD_SEARCH
        End If
        '2019/06/04 CHG START
        '      If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '	Call DB_SYSTBD_SetData(Usr_Ody_LC, pot_DB_SYSTBD)
        'End If
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            Call DB_SYSTBD_SetData(dt, pot_DB_SYSTBD, 0)
        End If
        '2019/06/04 CHG END

        SYSTBD_SEARCH = 0
		
END_SYSTBD_SEARCH:

        '�N���[�Y
        '2019/06/04 CHG START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/04 CHG END

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
	Public Function SYSTBD_SEARCH_ALL(ByVal Pin_strDKBSB As String, ByRef pot_DB_SYSTBD() As TYPE_DB_SYSTBD) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
        Dim intIdx As Short
        '2019/06/04 CHG START
        Dim dt As DataTable
        '2019/06/04 CHG END
        On Error GoTo ERR_SYSTBD_SEARCH_ALL
		
		SYSTBD_SEARCH_ALL = 9
		
		strSQL = ""
		strSQL = strSQL & "   from SYSTBD "
		strSQL = strSQL & "  Where DKBSB = '" & CF_Ora_Sgl(Pin_strDKBSB) & "' "
		strSQL = strSQL & " order by DKBID "
		
		'�����擾
		strSQLCount = ""
		strSQLCount = strSQLCount & " Select Count(*) as DataCount "
		strSQLCount = strSQLCount & strSQL

        'DB�A�N�Z�X
        '2019/06/04 CHG START
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)

        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)
        dt = DB_GetTable(strSQLCount)
        intData = DB_NullReplace(dt.Rows(0)("DataCount"), 0)
        '2019/06/04 CHG END

        '�N���[�Y
        '2019/06/04 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/04 DLT END

        If intData = 0 Then
			'�擾�f�[�^�Ȃ�
			SYSTBD_SEARCH_ALL = 1
			Exit Function
		End If
		
		strSQL = " Select * " & strSQL

        'DB�A�N�Z�X
        '2019/06/04 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/06/04 CHG END
            '�擾�f�[�^�Ȃ�
            SYSTBD_SEARCH_ALL = 1
            GoTo END_SYSTBD_SEARCH_ALL
        End If

        '�擾�f�[�^�ޔ�
        ReDim pot_DB_SYSTBD(intData)
        '2019/06/04 CHG START
        'intIdx = 1
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
        '	Call DB_SYSTBD_SetData(Usr_Ody_LC, pot_DB_SYSTBD(intIdx))
        '	intIdx = intIdx + 1
        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        'Loop 
        For i As Integer = 0 To dt.Rows.Count - 1
            Call DB_SYSTBD_SetData(dt, pot_DB_SYSTBD(i), i)
        Next
        '2019/06/04 CHG END

        SYSTBD_SEARCH_ALL = 0
		
END_SYSTBD_SEARCH_ALL:

        '�N���[�Y
        '2019/06/04 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/04 DLT END
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
    'Private Sub DB_SYSTBD_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD)
    Private Sub DB_SYSTBD_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD, ByVal DataCount As Integer)

        '�f�[�^�ޔ�
        With pot_DB_SYSTBD
            ''2019/06/04 CHG START
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
            '2019/06/04 CHG END
        End With
    End Sub
End Module